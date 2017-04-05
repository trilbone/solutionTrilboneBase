Imports System.Windows.Forms
Imports Service
Imports Service.clsApplicationTypes
'Imports LiveSwitch.TextControl
Imports Service.Agents
Imports System.Globalization
Imports nopRestClient
Imports System.Linq
Imports Service.Catalog
Public Class fmcatalog
#Region "Обьявления"
    ''' <summary>
    ''' показывает, что обект сайта уже инициализован
    ''' </summary>
    ''' <remarks></remarks>
    Private oSite_IsInit As Boolean = False
    Private oEbay_IsInit As Boolean = False
    Private oEmail_IsInit As Boolean = False

    Private oSplashscreen As Form

    Private oManager As clsTemplateManager
    Private WithEvents oCurrentCatalogSampleObj As CATALOGSAMPLE
    Private oCurrentFullPathToSampleXMLFile As String
    Private oNeedCheckandLoadPhotosFromArhive As Boolean = False
    Private oCurrentFileSource As Service.clsFilesSources
    Private oSampleNumber As Service.clsApplicationTypes.clsSampleNumber

    Private oCurrentImagesPath As List(Of String)
    ''' <summary>
    ''' текущий HTML образца для формы
    ''' </summary>
    ''' <remarks></remarks>
    Private oCurrentHTML As String
    ''' <summary>
    ''' переданное описание
    ''' </summary>
    ''' <remarks></remarks>
    Dim oDescriptionXMLelements As String
    ''' <summary>
    ''' информация лабел инфо
    ''' </summary>
    ''' <remarks></remarks>
    Dim oLablelIfoXML As String

    ''' <summary>
    ''' карты мультиязычные {ru,en}
    ''' </summary>
    ''' <remarks></remarks>
    Dim oXMLMAPcollection As XDocument()


    ''' <summary>
    ''' цена розницы из МС для тех, у кого доступа к ценам нет В USD!!!
    ''' </summary>
    ''' <remarks></remarks>
    Private oRecommentPrice As Decimal
    Private oRecommendedPriceCurrency As String
    Private oUSDRate As Decimal
    Private oEURRate As Decimal


    Private oImageChangedFlag As Boolean
    Private oActiveImagePopUp As Windows.Forms.Form
    Private oCurrentCulture As CultureInfo = clsApplicationTypes.EnglishCulture


    Private oGoogleQuery As String
    ''' <summary>
    ''' текщий выбраный элемент из таблицы на вкладке поиск мой склад
    ''' </summary>
    ''' <remarks></remarks>
    Private oCurrentGoodInfo As clsApplicationTypes.clsSampleNumber.strGoodInfo
#End Region

#Region "Ctor"
    Dim oIsInitProcedure As Boolean

    Public Sub New()
        ' Этот вызов является обязательным для конструктора.
        InitializeComponent()
        ' Добавьте все инициализирующие действия после вызова InitializeComponent().
        init()
    End Sub

    ''' <summary>
    ''' принимает:  _paramXMLFile=карта XML или путь к файлу с картой /  _paramXMLelements=полное Описание XML / _paramXMLLabel=xml из labelinfo
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New(PathOrXML() As String, paramXMLelements As String, LabelInfoXML As String, SampleNumber As clsSampleNumber)

        ' Этот вызов является обязательным для конструктора.
        InitializeComponent()
        init()
        Me.oLablelIfoXML = LabelInfoXML
        Me.oDescriptionXMLelements = paramXMLelements
        Me.oSampleNumber = SampleNumber
        initXML(PathOrXML)
    End Sub

#End Region
#Region "Инициализация при загрузке"
    ''' <summary>
    ''' основная процедура инициализации
    ''' </summary>
    ''' <param name="PathOrXml"></param>
    ''' <remarks></remarks>
    Private Sub initXML(PathOrXml() As String)
        Dim _xml As String = ""
        '------проверка на xml
        'задать рабочий путь к файлу. Он будет иметь расширение tmp
        Dim _tmp = IO.Path.GetTempFileName
        Dim _xmlPath = IO.Path.Combine(IO.Path.GetDirectoryName(_tmp), Math.Abs(clsApplicationTypes.GetCurrentTime.GetHashCode), IO.Path.GetFileName(IO.Path.ChangeExtension(_tmp, ".xml")))
        Me.btSaveXMLMap.BackColor = Button.DefaultBackColor
        'проверка целостности массива
      
        If PathOrXml(0) Is Nothing Then PathOrXml(0) = ""
        If PathOrXml(1) Is Nothing Then PathOrXml(1) = ""
        Select Case PathOrXml(0).Length
            Case 0
                ''ничего не приняли - диалог открытия файла
                MsgBox("Из БД передана пустая карта образца. Следует закрыть открывшееся окно, снять галочку Взять из БД и заново создать и проверить карту образца.", vbCritical)
                Return
            Case 1 To 300
                'приняли путь к файлу
                'проверка наличия файла
                If IO.File.Exists(PathOrXml(0)) Then
                    _xmlPath = PathOrXml(0)
                    _xml = My.Computer.FileSystem.ReadAllText(_xmlPath)
                    'задать устройство с фотками
                    oCurrentFileSource = Service.clsFilesSources.CreateInstance(Service.clsFilesSources.emSources.FreeFolder, , , IO.Path.GetDirectoryName(_xmlPath), True)
                    oCurrentFullPathToSampleXMLFile = _xmlPath
                    My.Settings.CurrentSamplePath = _xmlPath
                    My.Settings.Save()
                    Try
                        Dim _map = XDocument.Parse(_xml)
                        Me.oXMLMAPcollection = {_map, _map}
                    Catch ex As Exception
                        oNeedCheckandLoadPhotosFromArhive = True
                        GenerateMap(True)
                    End Try
                Else
                    'передали путь к папке
                    _xmlPath = IO.Path.Combine(PathOrXml(0), oSampleNumber.ShotCode & ".xml")
                    'задать устройство с фотками
                    oCurrentFileSource = Service.clsFilesSources.CreateInstance(Service.clsFilesSources.emSources.FreeFolder, , , IO.Path.GetDirectoryName(_xmlPath), True)
                    oCurrentFullPathToSampleXMLFile = _xmlPath
                    My.Settings.CurrentSamplePath = _xmlPath
                    My.Settings.Save()
                    'фотки только из папки
                    oNeedCheckandLoadPhotosFromArhive = False
                    GenerateMap(True)
                End If
                Me.btSaveXMLMap.BackColor = Drawing.Color.Red
            Case Else
                'приняли XML чистый (Из БД)
                'создаем временный каталог
                _xmlPath = My.Computer.FileSystem.GetTempFileName
                _xmlPath = IO.Path.Combine(IO.Path.GetDirectoryName(_xmlPath), IO.Path.GetFileNameWithoutExtension(_xmlPath), IO.Path.GetFileName(_xmlPath))
                '
                'задать устройство с фотками
                oCurrentFileSource = Service.clsFilesSources.CreateInstance(Service.clsFilesSources.emSources.FreeFolder, , , IO.Path.GetDirectoryName(_xmlPath), True)
                oCurrentFullPathToSampleXMLFile = _xmlPath
                My.Settings.CurrentSamplePath = _xmlPath
                My.Settings.Save()

                Try
                    Dim _mapru = XDocument.Parse(PathOrXml(0))
                    Dim _mapen = XDocument.Parse(PathOrXml(1))
                    Me.oXMLMAPcollection = {_mapru, _mapen}
                Catch ex As Exception
                    MsgBox("Невозможно разобрать переданный XML. Ошибка: " & ex.Message, vbCritical)
                    oNeedCheckandLoadPhotosFromArhive = True
                    GenerateMap(True)
                End Try

                oNeedCheckandLoadPhotosFromArhive = True
        End Select

        '------текущий обьект образца oCurrentCatalogSampleObj
        'задается в обработке свойства culture
        'необходимо для смены культуры
        oCurrentCulture = clsApplicationTypes.RussianCulture
        Me.Culture = clsApplicationTypes.EnglishCulture
        '---запись файла
        oManager.WriteFile(Me.oCurrentFullPathToSampleXMLFile, oCurrentCatalogSampleObj.GetXML)

        '-------------------
        'номер образца
        Dim _sn = Service.clsApplicationTypes.clsSampleNumber.CreateFromString(oCurrentCatalogSampleObj.bar)
        If Not _sn.CodeIsCorrect Then
            MsgBox("Номер образца не удалось разобрать из XML файла! Проверте атрибут bar тега SAMPLE.", vbCritical)
        End If
        oSampleNumber = _sn
        '-------------------
        'установка мой склад
        Me.UserControlMC1.SampleNumber = _sn
        '---------------
        oIsInitProcedure = True
        'загрузка списка серверов
        Dim _servers = clsApplicationTypes.AuctionAgent.AGENT.Where(Function(x) x.name = "site").Select(Function(x) x.account).ToArray
        ''загрузка данных сайта в событии cbSite
        Me.cbSite.Items.AddRange(_servers)
        Me.cbSite.SelectedItem = "trilbone"
        oIsInitProcedure = False

        Me.unLockCtl()
        '------------
        ''грузим фотки
        LoadPhotos()
        '---------------

    End Sub

    ''' <summary>
    '''
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub init()
        oSplashscreen = clsApplicationTypes.SplashScreen
        oManager = New clsTemplateManager

        Dim _list = Me.oManager.TemplateNamesList
        Me.lbTemplates.DataSource = _list
        Me.lbTemplates.SelectedIndex = clsApplicationTypes.MainXMLTemplateIndex

    
        Me.rtbRoot.Visible = False
        Me.StartPosition = Windows.Forms.FormStartPosition.CenterScreen
        'курсы валют
        oUSDRate = clsApplicationTypes.GetRateByCurrencyCB103("USD")
        oEURRate = clsApplicationTypes.GetRateByCurrencyCB103("EUR")

        '-------------------
        'установка разрешений
        If Not GetAccess("редактирование цен для eBay") Then
            Me.tbcMain.TabPages.Remove(Me.tpPrices)
        End If

        If Not GetAccess("отправка писем клиентам") Then
            Me.tbcMain.TabPages.Remove(Me.tpEmail)
        End If

        If Not GetAccess("выставление на eBay") Then
            Me.tbcMain.TabPages.Remove(Me.tpEbay)
        End If
ex:     '-----------------------
        LockCtl()
    End Sub
#End Region

#Region "Utilites"
    ''' <summary>
    ''' создает xml карту для текущего языка
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub GenerateMap(PhotoFromArhive As Boolean)
        Dim _status As Integer
        ''получить все имеющиеся фото
        Dim _imgSours As clsFilesSources
        If PhotoFromArhive Then
            _imgSours = clsFilesSources.Arhive
        Else
            _imgSours = oCurrentFileSource
        End If
        Dim _ru = clsApplicationTypes.DelegateStoreGetSampleInfoTransformed.Invoke(oSampleNumber, "", _status, oCurrentFileSource, Nothing, clsApplicationTypes.RussianCulture, False)
        Dim _en = clsApplicationTypes.DelegateStoreGetSampleInfoTransformed.Invoke(oSampleNumber, "", _status, oCurrentFileSource, Nothing, clsApplicationTypes.EnglishCulture, False)
        Me.oXMLMAPcollection = {XDocument.Parse(_ru), XDocument.Parse(_en)}
    End Sub


    ''' <summary>
    ''' подгружает фото
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadPhotos(Optional renewManager As Boolean = True, Optional selectedKey As String = "")
        'проверить наличие в папке фото и подгрузить их из архива
        Dim _mainImg As String = ""
        'получить список фото, указанных в XML файле
        Dim _imgList = (From c In Me.oCurrentCatalogSampleObj.GetSampleImages(_mainImg) Select IO.Path.GetFileName(c)).ToList

        'подгрузить 
        If oNeedCheckandLoadPhotosFromArhive Then
            Dim _result = Service.clsApplicationTypes.CreateFolderForSampleWithImages(oSampleNumber, oCurrentFileSource, _imgList, 1600, False, False)
            Me.oNeedCheckandLoadPhotosFromArhive = False
        End If

        If renewManager Then
            Me.UcPhotoManager1.LoadImages(oSampleNumber, oCurrentFileSource, Nothing, oCurrentCatalogSampleObj.GetSampleImages.ToArray)
        End If

        Me.tbPathToFolder.Text = oCurrentFileSource.GetStringForUser

        'imagelist
        Dim _ImageList = Service.clsApplicationTypes.SamplePhotoObject.GetSampleImageList(oSampleNumber, oCurrentFileSource, New Drawing.Size(160, 120), False, oCurrentCatalogSampleObj.GetSampleImages.ToArray)

        Me.lvPhotos.Clear()
        Me.lvPhotos.View = View.LargeIcon
        If Not (_ImageList Is Nothing OrElse _ImageList.CountImages = 0) Then
            Me.lvPhotos.Items.AddRange(_ImageList.ListViewItems)
            Me.lvPhotos.SmallImageList = _ImageList.ImageList
            Me.lvPhotos.LargeImageList = _ImageList.ImageList
        End If

        'тут надо отсортировать фото как в XML == _imgList
        Dim _coll = Me.lvPhotos.Items
        Dim _len = _coll.Count - 1
        Dim _max As Integer = _len
        For i = 0 To _len
            'найти фотку в листе
            Dim j = i
            If Not j > _imgList.Count - 1 Then
                Dim _res = (From c As ListViewItem In _coll Where c.Text = _imgList(j) Select c).FirstOrDefault
                'переместить на место
                If Not _res Is Nothing Then
                    _coll.Remove(_res)
                    _coll.Insert(i, _res)
                End If
            End If
        Next
        Me.lvPhotos.Refresh()
        If Not String.IsNullOrEmpty(selectedKey) Then
            'выбрать итем
            Dim _found = lvPhotos.Items.Find(selectedKey, False).FirstOrDefault
            If Not _found Is Nothing Then
                _found.Selected = True
            End If
        End If
        '------------------------


        'путь к папке с фото
        Dim _path = Me.oCurrentFileSource.ContainerPath

        'этот массив путей к фото (из папки!!) используется для загруки фото на сервер
        Me.CurrentImagesPath = (From c In _imgList Select IO.Path.Combine(_path, c)).ToList
        Me.HTMLgenerate()
    End Sub

    ''' <summary>
    ''' записывает текущий HTML в файл
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub HTMLFileWrite()
        Dim path = IO.Path.Combine((Me.oCurrentFileSource.ContainerPath), oSampleNumber.ShotCode & ".html")
        oManager.WriteFile(path, Me.CurrentHTML)
    End Sub

    ''' <summary>
    ''' вернет HTML для текущего образца используя текущий шаблон
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub HTMLgenerate()
        If oCurrentCatalogSampleObj Is Nothing Then Me.CurrentHTML = "" : Return
        If lbTemplates.SelectedIndex < 0 Then
            Me.CurrentHTML = <p>Необходимо выбрать шаблон для генерации HTML</p>
            MsgBox("Необходимо выбрать шаблон для генерации HTML", vbCritical)
            Return
        End If
        '---------------
        Dim _out As String
        '--------------
        Dim _xml = oManager.GetTransform(Me.oCurrentCatalogSampleObj.GetXML, emTemplateType.ByName, Me.lbTemplates.SelectedItem)

        _out = _xml
        If cbxFull.Checked Then
            'full copy
            GoTo ex
        End If
        '---------------
        _out = ""
        Dim _elem = XElement.Parse(_xml)

        If cbxHTML.Checked Then
            'add html+
            If _elem.Name = "html" Then
                _out = _xml
            Else
                _out = _elem.Element("html").ToString
            End If
        End If
        GoTo ex

        If cbxHEAD.Checked Then
            'add HEAD+
            _out = _elem.Element("head").ToString & ChrW(13)
        End If

        If cbxBODY.Checked Then
            'add BODY+
            _out += _elem.Element("head").NextNode.ToString
            GoTo ex
        End If
        '---------------
        'add only DIV+
        _out = _elem.Element("body").Element("div").ToString

ex:
        If Me.Culture.Name = clsApplicationTypes.RussianCulture.Name Then
            Me.oXMLMAPcollection(0) = XDocument.Parse(Me.oCurrentCatalogSampleObj.GetXML)
            'а тут надо согласовать языковые версии
            Me.SynchonizeLangVersion(0, 1)
        Else
            Me.oXMLMAPcollection(1) = XDocument.Parse(Me.oCurrentCatalogSampleObj.GetXML)
            'а тут надо согласовать языковые версии
            Me.SynchonizeLangVersion(1, 0)
        End If

        'присвоение результата
        'описание на сайте
        Dim _ex As clsExternalData = clsApplicationTypes.SiteExternalObject
        If Not _ex Is Nothing Then
            Dim _ruHTML = oManager.GetTransform(oXMLMAPcollection(0).ToString, emTemplateType.ByName, Me.lbTemplates.SelectedItem)
            Dim _enHTML = oManager.GetTransform(oXMLMAPcollection(1).ToString, emTemplateType.ByName, Me.lbTemplates.SelectedItem)
            _ex.ChangeFullDescription(_enHTML, _ruHTML)
        End If
        'html для формы
        Me.CurrentHTML = _out
    End Sub

    ''' <summary>
    ''' ловит изменения HTML
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Property CurrentHTML As String
        Get
            Return oCurrentHTML
        End Get
        Set(value As String)
            oCurrentHTML = value
            Me.wbMain.DocumentText = Me.CurrentHTML
            'передача вкладкам
            Me.UC_ebay1.CurrentHTML = value
            Me.Uc_mailer1.SetHTML(value)
        End Set
    End Property
    ''' <summary>
    ''' ловит изменения списка фоток
    ''' </summary>
    ''' <value></value>
    ''' <remarks></remarks>
    Private Property CurrentImagesPath As List(Of String)
        Get
            Return oCurrentImagesPath
        End Get
        Set(value As List(Of String))
            oCurrentImagesPath = value
            'передача вкладкам
            Me.UC_ebay1.PicturePaths = value
            Me.Uc_mailer1.PicturePaths = value
        End Set
    End Property

   

    ''' <summary>
    ''' согласовывает языковые версии: Mapping, Pictures
    ''' </summary>
    ''' <param name="main"></param>
    ''' <param name="toCorrection"></param>
    ''' <remarks></remarks>
    Private Sub SynchonizeLangVersion(main As Integer, toCorrection As Integer)
        Dim _main = Me.oXMLMAPcollection(main)
        Dim _toCorrect = Me.oXMLMAPcollection(toCorrection)
        If Not (_main Is Nothing Or _toCorrect Is Nothing) Then
            Dim _mimg = _main...<IMAGES>.FirstOrDefault
            Dim _cimg = _toCorrect...<IMAGES>.FirstOrDefault
            If Not _cimg Is Nothing Then
                _cimg.ReplaceAll(_mimg...<IMAGE>)
            Else
                Debug.Fail("Попытка удалить все фото из XML")
            End If

            'маппинг
            Dim _mmap = _main...<MAP>

            For Each t In _mmap
                Dim _name = t.Ancestors("ELEMENT").@name

                Dim _elem = _toCorrect...<ELEMENT>
                Dim _target = _elem.FirstOrDefault(Function(x) x.@name.Equals(_name))

                If Not _target Is Nothing Then
                    _target.Add(t)
                End If


            Next
        End If



    End Sub

    ''' <summary>
    ''' вернет имя текущего образца без скобок
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetCurrentSampleName() As String
        Dim _res = (From c In oCurrentCatalogSampleObj.DATA Where c.name = "NAME" Select c.Text).FirstOrDefault
        If Not _res Is Nothing Then
            'удалить скобки
            Return clsTemplateManager.ReplaceParenthesis(_res) & " "
        End If
        Return ""
    End Function

    ''' <summary>
    ''' показать увеличенное изображение
    ''' </summary>
    ''' <param name="SampleMainName"></param>
    ''' <param name="ShowAllImages"></param>
    ''' <remarks></remarks>
    Private Sub ShowImageForm(Optional ByVal SampleMainName As String = "", Optional ByVal ShowAllImages As Boolean = False)

        Dim _prm As Object

        If ShowAllImages Then
            _prm = Service.clsApplicationTypes.SamplePhotoObject.GetImageCollection(Me.oSampleNumber, oCurrentFileSource, False)
        Else
            _prm = Service.clsApplicationTypes.SamplePhotoObject.GetImage(oCurrentFileSource, Me.oSampleNumber, SampleMainName, False)
        End If

        'show image form
        'использование сервисов
        'по запросу выполняем вызов из сервиса

        Dim _param As Object
        If Not SampleMainName = "" Then
            _param = {_prm, SampleMainName}
        Else
            _param = {_prm}
        End If

        'если делегата нет, то сервис недоступен
        If Not Global.Service.clsApplicationTypes.DelegateStoreApplicationForm(Service.clsApplicationTypes.emFormsList.fmImage) Is Nothing Then
            'сервис зарегестрирован - вызываем
            oActiveImagePopUp = Global.Service.clsApplicationTypes.DelegateStoreApplicationForm(Service.clsApplicationTypes.emFormsList.fmImage).Invoke(_param)
            If Not oActiveImagePopUp Is Nothing Then
                'show form
                With oActiveImagePopUp
                    .Width = 640
                    .Height = 480

                    .Name = "ImageShowForm"
                    .StartPosition = Windows.Forms.FormStartPosition.CenterScreen
                    'привязка обработчика
                    'Me.cbSourcesList.SelectedItem
                    'Me.oSampleNumber
                    Service.clsApplicationTypes.DelegatStorefmImageDeleteDelegate = New Service.clsApplicationTypes.fmImageDeleteDelegat(AddressOf DelImage_eventHandler)
                    Service.clsApplicationTypes.DelegatStorefmImageCopyDelegate = New Service.clsApplicationTypes.fmImageCopyDelegat(AddressOf CopyImage_eventHandler)
                    oImageChangedFlag = False
                    .ShowDialog()
                    Service.clsApplicationTypes.DelegatStorefmImageDeleteDelegate = Nothing
                    Service.clsApplicationTypes.DelegatStorefmImageCopyDelegate = Nothing
                    If oImageChangedFlag Then
                        Me.LoadPhotos()
                    End If
                End With

            End If
        Else

        End If

    End Sub


    ''' <summary>
    ''' шаблон поиска
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetPatternForLabels(name As String)
        If Me.UserControlMC1.SampleName = "" Then Return
        'https://www.google.ru/search?q=asaphus+kowalewskii
        'зададим шаблон поиска
        Dim _gs = "https://www.google.ru/search?q="
        Dim _pattern = ""
        Dim _gpattern = ""
        Dim _names = name.Split({" ".ToArray(0), "(".ToArray(0)})
        'берем два первых слова
        Select Case _names.Length
            Case Is < 1
                'выход
            Case 1
                _pattern = _names(0).Trim
                _gpattern = _gs & _names(0).TrimEnd
                Me.nudWorldCount.Value = 1
            Case Is > 1
                If Me.nudWorldCount.Value = 1 Then
                    _pattern = _names(0).Trim
                    _gpattern = _gs & _names(0).TrimEnd
                Else
                    _gpattern = _gs
                    For i = 0 To Me.nudWorldCount.Value - 1

                        If i < _names.Length Then
                            _pattern += _names(i).Trim & " "
                            _gpattern += _names(i).TrimEnd & "+"
                        End If

                    Next
                    _pattern.TrimEnd()
                End If
        End Select

        Me.tbPatternSearch.Text = _pattern.Trim

        If _pattern.Length > 0 Then
            'установить по ЭУ
            'Me.UserControlEbaySearch1.SearchName = _pattern.Trim
            oGoogleQuery = _gpattern.Trim.TrimEnd("+")
        End If

    End Sub

    ''' <summary>
    ''' запрос имени склада
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetWarehouseNameForSample() As String

        oSplashscreen.Show()
        Application.DoEvents()

        Dim _msi = clsApplicationTypes.MoySklad(True)
        If _msi Is Nothing Then
            oSplashscreen.Hide()
            MsgBox("Мой склад пока не доступен. Повторите запрос через несколько минут.", vbInformation)
            Return ""
        End If

        'найти карточки
        Dim _info = _msi.FindGoods("", oSampleNumber.ShotCode)
        Select Case _info.Count
            Case 0
                oSplashscreen.Hide()
                MsgBox("Ненайдена карточка образца. Не занесен в Мой Склад? Проверте карточку образца в МС.", vbCritical)
                Return ""
            Case 1
                'ok
                'поиск по складу
                Dim _loc = _info(0).goodWareInfo
                Select Case _loc.Count
                    Case 0
                        oSplashscreen.Hide()
                        MsgBox("Невозможно определить склад образца. Нет остатка по складам? Проверте размещение образца в МС.", vbCritical)
                        Return ""
                    Case 1
                        'ok
                        oSplashscreen.Hide()
                        clsApplicationTypes.BeepYES()
                        Return _loc.FirstOrDefault
                    Case Else
                        'выбрать склад
                        Dim _mss As String = "Введите номер склада: "
                        Dim _index As Integer = 1
                        For Each t In _loc
                            _mss += "  " & _index & " = " & t & ";" & ChrW(13)
                            _index += 1
                        Next
rpt:
                        If Integer.TryParse(InputBox(_mss, "Выбор склада", 1), _index) Then
                            If Not _index > _loc.Count Then
                                oSplashscreen.Hide()
                                Return _loc(_index - 1)
                            Else
                                MsgBox("Неверное значение номера склада", vbCritical) : GoTo rpt
                            End If
                        Else
                            MsgBox("Неверное значение номера склада", vbCritical) : GoTo rpt
                        End If
                End Select
            Case Else
                oSplashscreen.Hide()
                MsgBox("Невозможно определить склад образца. Повтор артикула в Мой Склад? Проверте размещение образца в МС.", vbCritical)
                Return ""
        End Select

    End Function

#End Region

#Region "работа с сервером сайта"
    ''' <summary>
    ''' Загрузка данных с сервера
    ''' </summary>
    ''' <remarks></remarks>
    Private Function LoadDatafromServer() As Boolean
        Me.oSplashscreen.Show()
        Application.DoEvents()

        clsApplicationTypes.SiteExternalObject = Nothing
        Dim _ex = New nopRestClient.clsExternalData(oSampleNumber.ShotCode)
        With _ex
            If Me.cbSite.SelectedIndex < 0 Then
                Me.cbSite.SelectedIndex = 0
                Me.oSplashscreen.Hide()
                MsgBox("выбери сервер из списка под кнопкой 'Перезагрузить данные с сайта'", vbCritical)
                Return False
            End If
            'найти агента
            Dim _agent = clsApplicationTypes.AuctionAgent.AGENT.FirstOrDefault(Function(x) x.name = "site" And x.account.ToLower.Equals(Me.cbSite.SelectedItem.ToString.ToLower))
            If _agent Is Nothing Then
                Me.oSplashscreen.Hide()
                MsgBox("Не удалось найти агента сайта, выставление на сайт невозможно. Обратись к админу.", vbCritical)
                .Init(False)
                Return False
            Else
                Dim _http = _agent.requestURI
                Dim _token = _agent.token
                Dim _folderAsSot As Boolean = False
                If _agent.account = "test" Then
                    _folderAsSot = True
                End If
                .initREST(_agent.account, _http, _token, _folderAsSot)
                .Init(True)
                'проверка соединения
                For Each t In .WebStatus
                    If Not t.RequestStatus = Net.WebExceptionStatus.Success Then
                        Me.oSplashscreen.Hide()

                        MsgBox(String.Format("Запрос к серверу выдал ошибку: {0}. Возможно сервер перегружен или недоступен. После открытия формы нажмите кнопку 'Перезагрузить данные с сайта'. При появлении этой ошибки при нажатии указанной кнопки, убедитесь в работе сайта dealer.paleotravel.com в браузере", t.ToString))
                        Return False
                    End If
                Next
                'привязать курсы валют
                _ex.RateDelagate = AddressOf clsApplicationTypes.GetRateByCurrencyCB103
                'запомнить обьект
                clsApplicationTypes.SiteExternalObject = _ex
                'инициализация сервера
                InitSiteWithoutRequest()
            End If
        End With
        Me.oSplashscreen.Hide()
        Application.DoEvents()
        Return True
    End Function


    ''' <summary>
    ''' инициализует ЭУ без запроса на сервер
    ''' </summary>
    ''' <remarks></remarks>
    Private Function InitSiteWithoutRequest() As Boolean
        Me.oSplashscreen.Show()
        Application.DoEvents()
        Dim _ex = clsApplicationTypes.SiteExternalObject
        If _ex Is Nothing Then
            If Not LoadDatafromServer() Then
                Return False
            End If
        End If
        'инициализация сервера
        If _ex Is Nothing Then Return False

        _ex.Init(False)
        Dim _ruHTML = oManager.GetTransform(oXMLMAPcollection(0).ToString, emTemplateType.ByName, Me.lbTemplates.SelectedItem)
        Dim _enHTML = oManager.GetTransform(oXMLMAPcollection(1).ToString, emTemplateType.ByName, Me.lbTemplates.SelectedItem)
        _ex.TrilboneParcer(oXMLMAPcollection, XElement.Parse(Me.oDescriptionXMLelements), {_ruHTML, _enHTML})
        _ex.ApplyValues()

        Me.Uc_nopGood1.init(clsApplicationTypes.SiteExternalObject, clsApplicationTypes.RussianCulture)
        oSite_IsInit = True
        Me.oSplashscreen.Hide()
        Return True
    End Function

    ''' <summary>
    ''' выставить на сайт
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Uc_nopGood1_ReadyForSite(sender As Object, e As nopRestClient.uc_nopGood.ObjectReadyEventArgs) Handles Uc_nopGood1.ObjectReady
        If oSplashscreen.Visible = False Then
            oSplashscreen.Show()
            Application.DoEvents()
        End If
        Dim _serverMessage As String = ""
        Dim _externalObj As nopRestClient.clsExternalData = clsApplicationTypes.SiteExternalObject

        '--запись фоток
        Dim _images = oCurrentCatalogSampleObj.IMAGES.IMAGE.Select(Function(x) x.src).ToArray
        _externalObj.Pictures(oSampleNumber.EAN13, oSampleNumber.ShotCode) = _images

        Dim _httpStatus = _externalObj.PutProduct(, _serverMessage)
        Dim _paramCollection = _externalObj.SendParameterCollection
        If _httpStatus = Net.HttpStatusCode.OK Then
            MsgBox("Образец успешно выставлен на сервер(сайт): " & Me.cbSite.SelectedItem, vbInformation)
        Else
            Dim _last = _externalObj.WebStatus.Last
            MsgBox(String.Format("Ошибка при выставлении: {0} ({1}). Выставление будет прервано.", _last.ResponseMessage, _last.RequestStatus), vbCritical)
            'ОШИБКА СЕРВЕРА
            oSplashscreen.Hide()
            Application.DoEvents()
            'запрос в БД сайта о сообщениях
            Dim _log = clsApplicationTypes.SampleDataObject.GetActivityByNumberFromSite(oSampleNumber, Not clsApplicationTypes.GetAccess("лог образца за все время"))
            If _log.Count = 0 Then
                MsgBox("Просмотр записей об ошибках не возможен. Журнал сервера пуст для текущего номера образца. Проверить можно только вручную.", vbCritical)
                Return
            End If
            'отобразить лог
            Dim _fm As New Windows.Forms.Form
            With _fm
                .Name = "Form1"
                .Text = "Просмотр журнал ошибок выставления с сервера для текущего образца"
                ' .MdiParent = Me
                .StartPosition = FormStartPosition.CenterParent
                .Size = New Drawing.Size(700, 150)
                Dim _list As New Windows.Forms.RichTextBox
                With _list
                    .Name = "Listbox1"
                    .TabStop = False
                    .Location = New Drawing.Point(0, 0)
                    .Size = New Drawing.Size(690, 140)
                    For Each d In _log
                        _list.Text += d & ChrW(13)
                    Next
                End With
                .Controls.Add(_list)
                .ShowDialog()
            End With
            Return
        End If

        ''===все ок
        Select Case MsgBox("Занести данные в МС?", vbYesNo)
            Case MsgBoxResult.No
                GoTo trdb
        End Select

        'по запросу выполняем вызов из сервиса
        'если делегата нет, то сервис недоступен
        If clsApplicationTypes.DelegatStoreMCinterface Is Nothing Then
            MsgBox("Сервис MC недоступен", vbCritical)
            GoTo trdb
        End If

        'сервис зарегестрирован - вызываем
        Dim _MCinterface = clsApplicationTypes.DelegatStoreMCinterface().Invoke(False)
        If _MCinterface Is Nothing Then
            MsgBox("Сервис MC недоступен", vbCritical)
            GoTo trdb
        End If

        '----------------------
        'занесение в МС
        Dim _agent = clsApplicationTypes.AuctionAgent.AGENT.FirstOrDefault(Function(x) x.name = "site" And x.account = clsApplicationTypes.SiteAgentAccount)
        If _agent Is Nothing Then
            MsgBox(String.Format("Не удалось найти агента {0} сайта, запись в МС не будет создана", clsApplicationTypes.SiteAgentAccount), vbCritical)
            GoTo trdb
        End If

        'цены
        Dim _amount As Decimal = 0
        Dim _resultPriceObj = _paramCollection.FirstOrDefault(Function(x) x.Currency = "RUR")
        If _resultPriceObj Is Nothing Then
            _resultPriceObj = _paramCollection.FirstOrDefault(Function(x) x.Currency = "USD")
            If _resultPriceObj Is Nothing Then
                _resultPriceObj = _paramCollection.FirstOrDefault(Function(x) x.Currency = "EUR")
                If _resultPriceObj Is Nothing Then
                    ' MsgBox("Нет доступных цен", vbCritical)
                Else
                    _amount = Math.Round(_resultPriceObj.Amount * oEURRate, 2)
                End If
            Else
                _amount = Math.Round(_resultPriceObj.Amount * oUSDRate, 2)
            End If
        Else
            _amount = Math.Round(_resultPriceObj.Amount, 2)
        End If

        'получить UUID заказа
        Dim _auctUUID = _agent.GetAgentID("moysklad", "ReservCustomerOrderUUID")
        If Not _auctUUID = "" Then
            If _MCinterface.SetSampleToAction(oSampleNumber, _auctUUID, _amount, False) Then
                MsgBox("Образец зарезервирован в соответствующем заказе", MsgBoxStyle.Information)
                GoTo trdb
            Else
                ' MsgBox("Образец не зарезервирован в соответствующем заказе, ошибка при помещении в заказ.", MsgBoxStyle.Critical)
                GoTo trdb
            End If
        Else
            MsgBox("Образец не зарезервирован в соответствующем заказе, ошибка при чтении параметра ReservCustomerOrderUUID из файла агента.", MsgBoxStyle.Critical)
            GoTo trdb
        End If

        'обновление цен в МС
        If Not _resultPriceObj Is Nothing Then
            'пробуем обновить цену и вес в МС
            If Not _MCinterface.UpdateGoodPrice(oSampleNumber.ShotCode, 0, "", _resultPriceObj.Amount, _resultPriceObj.Currency, "шт", "", 0) = "" Then
                MsgBox("Цена товара в МС обновлена", MsgBoxStyle.Information)
            Else
                MsgBox("Цена товара в МС не обновлена, ошибка при обновлении.", MsgBoxStyle.Critical)
            End If
        End If


trdb:
        'добавить в базу образцов
        Select Case MsgBox("Занести данные в БД Trilbone?", vbYesNo)
            Case MsgBoxResult.No
                oSplashscreen.Hide()
                Application.DoEvents()
                Return
        End Select

        'записать в мою базу
        If _paramCollection Is Nothing OrElse _paramCollection.Count = 0 Then
            MsgBox("Нет доступных для занесения цен", vbCritical)
            oSplashscreen.Hide()
            Application.DoEvents()
            Return
        End If

        Dim _res As Integer = 0
        ' Резерв камня на Сайте/ ACL=роль клиента сайта (магазин указать в Site) / цена и валюта для этой комбинации
        For Each t In _paramCollection
            Dim _resultSite = clsApplicationTypes.SampleDataObject.RegisterSampleToSiteTrilbone(SampleNumber:=oSampleNumber, ResourceName:=t.ClientRole & " - " & t.ShopName, clientName:=t.ClientRole, ResourceID:=clsSampleDataManager.emSLResource.SiteTrilbone, currency:=t.Currency, itemamount:=t.Amount, itemcondition:=t.ItemCondition, InsectionFee:=0, itemtitle:=t.ItemTitle)
            If _resultSite Then
                _res += 1
            End If
        Next

        MsgBox(String.Format("Образец зарезервирован в БД  и записано {0} цен", _res), MsgBoxStyle.Information)
        oSplashscreen.Hide()
        Application.DoEvents()
        Return

    End Sub

#End Region

#Region "Обработка событий ЭУ"


    Private Sub LockCtl()
        Me.wbMain.Visible = False
        For Each ctl As Windows.Forms.Control In Me.Controls
            ctl.Enabled = False
        Next
        Me.btLoadFile.Enabled = True
    End Sub

    Private Sub unLockCtl()
        For Each ctl As Windows.Forms.Control In Me.Controls
            ctl.Enabled = True
        Next
        If lbTemplates.Items.Count > 0 AndAlso lbTemplates.SelectedIndex > -1 Then
            Me.wbMain.Visible = True
        End If
    End Sub

#Region "Общие ЭУ"
    Private Sub btLoadFile_Click(sender As System.Object, e As System.EventArgs) Handles btLoadFile.Click
        'load sample file
        Dim _fd = New Windows.Forms.OpenFileDialog
        With _fd
            .Filter = ("XML|*.xml")
            .Title = "выбор файла образца"
            .Multiselect = False
            If Me.oCurrentFileSource.ContainerPath = "" Then
                .InitialDirectory = My.Settings.CurrentSamplePath
            Else
                .InitialDirectory = IO.Path.GetDirectoryName(Me.oCurrentFileSource.ContainerPath)
            End If

        End With

        Dim _xmlPath As String = ""

        Select Case _fd.ShowDialog
            Case Windows.Forms.DialogResult.OK, Windows.Forms.DialogResult.Yes
                _xmlPath = _fd.FileName
                My.Settings.CurrentSamplePath = _xmlPath
                My.Settings.Save()

                Dim _xml = My.Computer.FileSystem.ReadAllText(_xmlPath)
                'задать устройство с фотками
                oCurrentFileSource = Service.clsFilesSources.CreateInstance(Service.clsFilesSources.emSources.FreeFolder, , , IO.Path.GetDirectoryName(_xmlPath))
                oCurrentFullPathToSampleXMLFile = _xmlPath

                Try
                    Dim _ox = XDocument.Parse(_xml)
                    Me.oXMLMAPcollection = {_ox, _ox}
                Catch ex As Exception
                    Me.GenerateMap(True)
                End Try
                oNeedCheckandLoadPhotosFromArhive = True
                Me.HTMLgenerate()
                LoadPhotos()
        End Select
    End Sub

    Private Sub btShowFile_Click(sender As System.Object, e As System.EventArgs) Handles btShowHTML.Click
        Me.HTMLgenerate()
    End Sub

    Private Sub btCreateMapping_Click(sender As System.Object, e As System.EventArgs) Handles btCreateMapping.Click
        If Me.lbTemplates.SelectedItem Is Nothing Then Return
        Dim _fm = clsCatalogService.GetMappingForm(oCurrentCatalogSampleObj, Me.lbTemplates.SelectedItem) ' oCurrentCatalogSampleObj.GetMappingForm(Me.lbTemplates.SelectedItem)
        _fm.StartPosition = Windows.Forms.FormStartPosition.CenterScreen
        _fm.ShowDialog()
    End Sub

    ''' <summary>
    ''' свойство хранения делегата сохранения XML
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SaveDelegate As Func(Of XDocument(), Boolean)


    ''' <summary>
    ''' записывает текущий XML образца
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btSave_Click(sender As System.Object, e As System.EventArgs) Handles btSaveXMLMap.Click
        'create bak
        If IO.File.Exists(IO.Path.ChangeExtension(Me.oCurrentFullPathToSampleXMLFile, "bak")) Then
            IO.File.Delete(IO.Path.ChangeExtension(Me.oCurrentFullPathToSampleXMLFile, "bak"))
        End If

        If IO.File.Exists(Me.oCurrentFullPathToSampleXMLFile) Then
            IO.File.Move(Me.oCurrentFullPathToSampleXMLFile, IO.Path.ChangeExtension(Me.oCurrentFullPathToSampleXMLFile, "bak"))
        End If

        'запись XML
        If oManager.WriteFile(Me.oCurrentFullPathToSampleXMLFile, oCurrentCatalogSampleObj.GetXML) Then
            Me.HTMLFileWrite()
            If Not SaveDelegate Is Nothing Then
                'передача XML для сохранения.принят результат сохранения
                Dim _sres = SaveDelegate.Invoke(Me.oXMLMAPcollection)
                If _sres = False Then
                    MsgBox("Карту образца не удалось сохранить в БД", vbCritical)
                End If
            End If
            Me.btSaveXMLMap.BackColor = Windows.Forms.Control.DefaultBackColor
            BeepYES()
        Else
            MsgBox("Не удалось записать файл", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub lbTemplates_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lbTemplates.SelectedIndexChanged
        If oCurrentCatalogSampleObj Is Nothing Then Exit Sub
        Me.HTMLgenerate()
    End Sub

    Private Sub btRoot_Click(sender As System.Object, e As System.EventArgs) Handles btRoot.Click
        If Me.btRoot.Tag = True Then
            Me.btShowXML.Enabled = True
            Me.wbMain.Visible = True
            Me.tbRootCaption.Visible = False
            Me.tbRootID.Visible = False
            Me.rtbRoot.Visible = False
            Me.btRoot.Text = "Обновить инфо материале"
            Me.btRoot.Tag = False
            Me.btCreateMapping.Enabled = True
            Me.btSaveXMLMap.Enabled = True
            Me.btShowHTML.Enabled = True
            Me.btLoadFile.Enabled = True
            Me.lbTemplates.Enabled = True
            Me.HTMLgenerate()
            'ShowFileInBrowser(Me.WebBrowser1, "")
            Return
        End If


        If Me.rtbRoot.DataBindings.Count = 0 Then
            Me.rtbRoot.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bs_Root, "Text", True))
        End If

        If oCurrentCatalogSampleObj.ROOTINFO Is Nothing Then
            oCurrentCatalogSampleObj.SetRootInfo("id256", "Удалите эту надпись, чтобы не показывать в результате", "Text")
        End If

        Me.bs_Root.DataSource = oCurrentCatalogSampleObj.ROOTINFO
        Me.btShowXML.Enabled = False
        Me.btCreateMapping.Enabled = False
        Me.btSaveXMLMap.Enabled = False
        Me.btShowHTML.Enabled = False
        Me.btLoadFile.Enabled = False
        Me.lbTemplates.Enabled = False

        Me.wbMain.Visible = False
        Me.tbRootCaption.Visible = True
        Me.tbRootID.Visible = True
        Me.rtbRoot.Visible = True
        Me.btRoot.Text = "Сохранить/скрыть"
        Me.btRoot.Tag = True

    End Sub

    Private Sub btCopyHTML_Click(sender As System.Object, e As System.EventArgs) Handles btCopyHTML.Click
        '------------------
        Dim _data As String = Me.CurrentHTML
        Try
            My.Computer.Clipboard.Clear()
            My.Computer.Clipboard.SetText(_data)
        Catch ex As Exception
            MsgBox("Ошибка при помещении данных в буфер обмена.", vbCritical)
        End Try
        '-----------------

    End Sub

    Private Sub btShowXML_Click(sender As System.Object, e As System.EventArgs) Handles btShowXML.Click
        Select Case Me.btShowXML.Tag
            Case True
                'режим HTML
                'Me.GenerateMap(False)
                'генерация HTML
                Dim _tmp As XDocument
                Dim _status As Integer
                oCurrentCatalogSampleObj = CATALOGSAMPLE.ParseSample(Me.rtbRoot.Text, _status)
                If Not _status > 0 Then
                    MsgBox("Ошибка в отредактированном XML, исправь", vbCritical)
                    Return
                End If
                Select Case oCurrentCulture.Name
                    Case clsApplicationTypes.EnglishCulture.Name
                        _tmp = Me.oXMLMAPcollection(0)

                        Me.oXMLMAPcollection = {_tmp, XDocument.Parse(oCurrentCatalogSampleObj.GetXML)}
                    Case clsApplicationTypes.RussianCulture.Name
                        _tmp = Me.oXMLMAPcollection(1)

                        Me.oXMLMAPcollection = {XDocument.Parse(oCurrentCatalogSampleObj.GetXML), _tmp}
                End Select

                Me.wbMain.Visible = True
                Me.tbRootCaption.Visible = False
                Me.tbRootID.Visible = False
                Me.rtbRoot.Visible = False
                Me.btShowXML.Text = "Показать XML"
                Me.btShowXML.Tag = False
                Me.btCreateMapping.Enabled = True
                Me.btSaveXMLMap.Enabled = True
                Me.btShowHTML.Enabled = True
                Me.btLoadFile.Enabled = True
                Me.lbTemplates.Enabled = True
                Me.btRoot.Enabled = True

                Me.HTMLgenerate()

            Case False
                'режим XML
                Me.rtbRoot.DataBindings.Clear()
                Me.rtbRoot.Text = oCurrentCatalogSampleObj.GetXML

                Me.btCreateMapping.Enabled = False
                Me.btSaveXMLMap.Enabled = False
                Me.btShowHTML.Enabled = False
                Me.btLoadFile.Enabled = False
                Me.lbTemplates.Enabled = False
                Me.btRoot.Enabled = False

                Me.wbMain.Visible = False

                Me.rtbRoot.Visible = True
                Me.btShowXML.Text = "Сохранить XML/скрыть"
                Me.btShowXML.Tag = True
        End Select




    End Sub

    Private Sub btCopyCode_Click(sender As System.Object, e As System.EventArgs) Handles btCopyCode.Click
        '------------------
        Dim _data As String = oSampleNumber.ShotCode
        Try
            My.Computer.Clipboard.Clear()
            My.Computer.Clipboard.SetText(_data)
        Catch ex As Exception
            MsgBox("Ошибка при помещении данных в буфер обмена.", vbCritical)
        End Try
        '-----------------
    End Sub

    Private Sub btCopyEAN13_Click(sender As System.Object, e As System.EventArgs) Handles btCopyEAN13.Click
        '------------------
        Dim _data As String = oSampleNumber.EAN13
        Try
            My.Computer.Clipboard.Clear()
            My.Computer.Clipboard.SetText(_data)
        Catch ex As Exception
            MsgBox("Ошибка при помещении данных в буфер обмена.", vbCritical)
        End Try
        '-----------------
    End Sub

    Private Sub btCopyMainName_Click(sender As System.Object, e As System.EventArgs) Handles btCopyMainName.Click
        '------------------
        Dim _data As String = GetCurrentSampleName()
        Try
            My.Computer.Clipboard.Clear()
            My.Computer.Clipboard.SetText(_data)
        Catch ex As Exception
            MsgBox("Ошибка при помещении данных в буфер обмена.", vbCritical)
        End Try
        '-----------------
    End Sub

    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles btClose.Click
        Me.Close()
    End Sub

    Private Sub rbEnglish_CheckedChanged(sender As Object, e As EventArgs) Handles rbEnglish.CheckedChanged
        If rbEnglish.Checked Then
            Me.Culture = clsApplicationTypes.EnglishCulture
        End If
    End Sub

    Private Sub rbRussian_CheckedChanged(sender As Object, e As EventArgs) Handles rbRussian.CheckedChanged
        If rbRussian.Checked Then
            Me.Culture = clsApplicationTypes.RussianCulture
        End If
    End Sub

    Private Property Culture As CultureInfo
        Get
            Return oCurrentCulture
        End Get
        Set(value As CultureInfo)
            'при отсутствии изменения - выход
            If value.Name = oCurrentCulture.Name Then Return

            oCurrentCulture = value
            Select Case oCurrentCulture.Name
                Case clsApplicationTypes.EnglishCulture.Name
                    'культура изменилась на английскую
                    'запомнить русскую версию
                    If Not oCurrentCatalogSampleObj Is Nothing Then
                        oXMLMAPcollection(0) = XDocument.Parse(oCurrentCatalogSampleObj.GetXML())
                    End If

                    Dim _status As Integer
                    oCurrentCatalogSampleObj = CATALOGSAMPLE.ParseSample(oXMLMAPcollection(1).ToString, _status)
                    If _status > 0 Then
                        AddHandler oCurrentCatalogSampleObj.MappingChanged, AddressOf SampleMappingChanged
                        '-----------
                    End If
                    Me.rbEnglish.Checked = True
                Case clsApplicationTypes.RussianCulture.Name
                    'культура изменилась на русскую
                    'запомнить англо версию
                    If Not oCurrentCatalogSampleObj Is Nothing Then
                        oXMLMAPcollection(1) = XDocument.Parse(oCurrentCatalogSampleObj.GetXML())
                    End If


                    Dim _status As Integer
                    oCurrentCatalogSampleObj = CATALOGSAMPLE.ParseSample(oXMLMAPcollection(0).ToString, _status)
                    If _status > 0 Then
                        AddHandler oCurrentCatalogSampleObj.MappingChanged, AddressOf SampleMappingChanged
                        '-----------
                    End If
                    Me.rbRussian.Checked = True
            End Select

            Me.HTMLgenerate()
        End Set
    End Property

    ''' <summary>
    ''' смена главных вкладок
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tbctlMain_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tbcMain.SelectedIndexChanged
        '-------сайт
        If tbcMain.SelectedTab Is tpSite Then
            'сохраним карту
            If Me.btSaveXMLMap.BackColor = Drawing.Color.Red Then
                Me.btSave_Click(Me.btSaveXMLMap, EventArgs.Empty)
                Me.btSaveXMLMap.BackColor = Button.DefaultBackColor
            End If

            If Me.oSite_IsInit Then Return
            If InitSiteWithoutRequest() Then
                oSite_IsInit = True
            End If
        End If
        ' ----------mail
        If tbcMain.SelectedTab Is tpEmail Then
            If oEmail_IsInit Then Return
            Me.Uc_mailer1.Clear()
            Me.Uc_mailer1.init(oSampleNumber, Me.CurrentHTML, Me.CurrentImagesPath)
            oEmail_IsInit = True
        End If

        '---е бай--------------
        If tbcMain.SelectedTab Is tpEbay Then
            If oEbay_IsInit Then Return
            'установка разрешений
            If Not GetAccess("редактирование цен для eBay") Then

            End If

            'получить цену для ебай из МойСклад
            Dim _number = (Me.oSampleNumber)
            If _number Is Nothing Then Return
            Dim _info = _number.GetExtendedInfo(False)
            If _info Is Nothing Then Return
            Dim _msinfo = _info.GoodInfo
            Select Case _msinfo.Count
                Case 0
                    MsgBox("Информация в МС по образцу не найдена. Номер: " & _number.ShotCode, vbCritical)
                    oRecommentPrice = 0
                    'Return
                Case Is = 1
                    'нашли инфо о цене
                    Select Case _msinfo(0).eBayCurrecy
                        Case "USD"
                            oRecommentPrice = _msinfo(0).eBayPrice
                        Case "EUR"
                            oRecommentPrice = Math.Round(_msinfo(0).eBayPrice * (oUSDRate / oEURRate), 2)
                        Case "RUR"
                            oRecommentPrice = Math.Round(_msinfo(0).eBayPrice * oUSDRate, 2)
                    End Select
                    BeepYES()
                Case Is > 1
                    'более одного камня
                    MsgBox("Информация по образцу неоднозначна. Найдено более одной записи в Мой Склад. Номер: " & _number.ShotCode, vbCritical)
                    oRecommentPrice = 0
                    Return
            End Select

            'load eshops agents
            'сюда вставить инициализацию вкладки ебай
            Me.UC_ebay1.Clear()
            Me.UC_ebay1.init(oSampleNumber, oCurrentCatalogSampleObj, oCurrentFileSource, Me.CurrentHTML, Me.CurrentImagesPath, oRecommentPrice)
            oEbay_IsInit = True
        End If

        '----вкладка Price
        If tbcMain.SelectedTab Is tpPrices Then
            Dim _elem = XElement.Parse(oDescriptionXMLelements)...<ELEMENT>.Where(Function(x) x.@name = "Systematica")
            If _elem.Count > 0 Then
                Dim _ru = _elem.FirstOrDefault(Function(x) x.@lang = clsApplicationTypes.RussianCulture.Name)...<NODE>.Last.FirstNode.ToString.Trim
                Dim _en = _elem.FirstOrDefault(Function(x) x.@lang = clsApplicationTypes.EnglishCulture.Name)...<NODE>.Last.FirstNode.ToString.Trim
                If String.IsNullOrEmpty(_ru) Then
                    _ru = _en
                End If
                If String.IsNullOrEmpty(_en) Then
                    _en = _ru
                End If
                If Me.rbEnglish.Checked Then
                    Me.tbPatternSearch.Text = _en.Trim
                End If
                If Me.rbRussian.Checked Then
                    Me.tbPatternSearch.Text = _ru.Trim
                End If
            End If
            Me.Uс_trilbone_history1.SampleNumber(False) = oSampleNumber.EAN13
        End If

    End Sub
    ''' <summary>
    ''' кнопка обновить сайт
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btSiteReload_Click(sender As Object, e As EventArgs) Handles btSiteReload.Click
        LoadDatafromServer()
    End Sub
    ''' <summary>
    ''' смена сервера
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cbSite_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbSite.SelectedIndexChanged
        If oIsInitProcedure Then Return
        If cbSite.SelectedIndex < 0 Then Return
        Dim _agent = clsApplicationTypes.AuctionAgent.AGENT.FirstOrDefault(Function(x) x.name = "site" And x.account.ToLower.Equals(Me.cbSite.SelectedItem.ToString.ToLower))
        If _agent Is Nothing Then Return

        Dim _ex As clsExternalData = clsApplicationTypes.SiteExternalObject
        If _ex Is Nothing Then
            'загрузка сайта
            LoadDatafromServer()
            Return
        End If

        If _ex.ServerAgentName = _agent.account Then
            'выбран тот же сервер, что и был запомнен
            'обновить без запроса
            clsApplicationTypes.SiteExternalObject.Clear()
            InitSiteWithoutRequest()
            Return
        End If

        'меняем привязку HTTP
        Dim _http = _agent.requestURI
        Dim _token = _agent.token
        Dim _folderAsSot As Boolean = False
        If _agent.account = "test" Then
            _folderAsSot = True
        End If
        _ex.initREST(_agent.account, _http, _token, _folderAsSot)
        If LoadDatafromServer() Then
            MsgBox("Сервер выставления на сайт изменен.", vbOKOnly)
        End If
    End Sub

#End Region

#Region "Вкладка Фото"

    Private Sub lvPhotos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles lvPhotos.KeyPress

    End Sub

    Private Sub lvPhotos_KeyUp(sender As Object, e As KeyEventArgs) Handles lvPhotos.KeyUp
        If e.KeyCode = Keys.Delete Then
            If Not lvPhotos.SelectedItems Is Nothing OrElse lvPhotos.SelectedItems.Count > 0 Then
                Dim _res = (From c In lvPhotos.SelectedItems Select CType(c.Name, String)).ToArray

                Me.UcPhotoManager1_PhotosDeleted(Me, New ucPhotoManager.PhotoEventArgs With {.ImageNamesList = _res})

            End If
        End If
    End Sub
    Private Sub lvPhotos_MouseClick(sender As Object, e As Windows.Forms.MouseEventArgs) Handles lvPhotos.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim _item = sender.GetItemAt(e.X, e.Y)
            If Not _item Is Nothing Then
                Call Me.ShowImageForm(_item.Name, True)
            End If
        End If
    End Sub
    Private Sub btImageManager_Click(sender As Object, e As EventArgs) Handles btImageManager.Click
        'параметр param{0} - SampleNumber (Decimal); param{1} - ActiveFolder (string) (путь)
        Dim _filesrc = oCurrentFileSource
        Dim _prm As Object = {_filesrc, oSampleNumber}
        Dim _fm = Service.clsApplicationTypes.DelegateStoreApplicationForm(Service.clsApplicationTypes.emFormsList.fmImageManager).Invoke(_prm)

        If Not _fm Is Nothing Then
            _fm.ShowDialog()
        End If

    End Sub
    Private Sub btUPphoto_Click(sender As Object, e As EventArgs) Handles btUPphoto.Click
        Dim _itemColl = lvPhotos.SelectedItems
        If _itemColl.Count = 0 Then Return
        Dim _item = _itemColl.Item(0)
        'задача передвинуть элем. наверх, чтобы получить порядок загрузки.
        If Not Me.oCurrentCatalogSampleObj.IMAGES.MoveImageIndexDown(_item.Text) Then
            Service.clsApplicationTypes.BeepNOT()
        End If
        LoadPhotos(False, _item.ImageKey)


    End Sub

    Private Sub btDownphoto_Click(sender As Object, e As EventArgs) Handles btDownphoto.Click
        Dim _itemColl = lvPhotos.SelectedItems
        If _itemColl.Count = 0 Then Return
        Dim _item = _itemColl.Item(0)
        'задача передвинуть элем. наверх, чтобы получить порядок загрузки.
        If Not Me.oCurrentCatalogSampleObj.IMAGES.MoveImageIndexUp(_item.Text) Then
            Service.clsApplicationTypes.BeepNOT()
        End If
        LoadPhotos(False, _item.ImageKey)
    End Sub

#End Region


#Region "Вкладка Цены"
    Private Sub nudWorldCount_ValueChanged(sender As Object, e As EventArgs) Handles nudWorldCount.ValueChanged
        Me.SetPatternForLabels(Me.tbPatternSearch.Text)
        If Not Me.lvPhotos.LargeImageList Is Nothing AndAlso Me.lvPhotos.LargeImageList.Images.Count > 0 Then
            Me.pbFirstImg.Image = Me.lvPhotos.LargeImageList.Images(0)
        End If

    End Sub
    Private Sub tbctlSearch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tbctlSearch.SelectedIndexChanged
        If tbctlSearch.SelectedTab Is tpGoogleSearch Then
            wbGoogleSearch.Navigate(oGoogleQuery)
        End If
    End Sub
    Private Sub btSearchByUser_Click(sender As Object, e As EventArgs) Handles btSearchByUser.Click

        If String.IsNullOrEmpty(Me.tbPatternSearch.Text) Then
            Me.SetPatternForLabels(Me.UserControlMC1.SampleName)
        End If

        Me.SetPatternForLabels(Me.tbPatternSearch.Text)

        If tbctlSearch.SelectedTab Is tpGoogleSearch Then
            wbGoogleSearch.Navigate(oGoogleQuery)
        End If

    End Sub

    Private Sub btSearchInMoySklad_Click(sender As Object, e As EventArgs) Handles btSearchInMoySklad.Click
        Me.oSplashscreen.Show()
        Dim _mcinterface = clsApplicationTypes.MoySklad(True)

        If _mcinterface Is Nothing Then
            ' MsgBox("Мой склад еще загружается..", vbInformation)
            Me.oSplashscreen.Hide()
            Return
        End If

        Dim _result = _mcinterface.FindGoods(tbPatternSearch.Text.Trim)
        Me.ClsApplicationTypes_clsSampleNumber_strGoodInfoBindingSource.DataSource = _result
        If _result.Count > 0 Then BeepYES()
        Me.oSplashscreen.Hide()
    End Sub
    Private Sub btSearchLocation_Click(sender As Object, e As EventArgs) Handles btSearchLocation.Click
        If oCurrentGoodInfo Is Nothing Then Return
        Dim _result = oCurrentGoodInfo.goodLocationInfo(oCurrentGoodInfo)
        Dim _tmp As String = ""
        If _result.Count > 0 Then
            For Each t In _result
                _tmp += t & ", "
            Next
            _tmp.TrimEnd(", ".ToCharArray)
        Else
            _tmp = "нет данных о местоположении"
        End If

        Me.tbGoodLocation.Text = _tmp
    End Sub
    Private Sub btResetMC_Click(sender As Object, e As EventArgs) Handles btResetMC.Click
        If Not Me.lvPhotos.LargeImageList Is Nothing AndAlso Me.lvPhotos.LargeImageList.Images.Count > 0 Then
            Me.pbFirstImg.Image = Me.lvPhotos.LargeImageList.Images(0)
        End If
        Me.tbGoodLocation.Text = ""
        Me.ClsApplicationTypes_clsSampleNumber_strGoodInfoBindingSource.DataSource = New List(Of clsSampleNumber.strGoodInfo)
        Me.UserControlMC1.SampleNumber = oSampleNumber
    End Sub
    Private Sub btCorrectInMC_Click(sender As Object, e As EventArgs) Handles btCorrectInMC.Click
        Dim _num = clsSampleNumber.CreateFromString(oCurrentGoodInfo.ActualNumber)
        Me.UserControlMC1.SampleNumber = _num
    End Sub


#End Region

#End Region
#Region "Работа с фотками"

    Private Sub CopyImage_eventHandler(ByVal sender As Object, ByVal e As Service.clsApplicationTypes.fmImageCopyEventArg)
        If e.ImageNames.Length = 0 Then Exit Sub

        'скопировать изображения, список имен в аргументе
        'Dim _tmpSample As Decimal = Me.Dgv_SamplesINOrders.CurrentRow.Cells(0).Value
        'Dim _filesrc = Me.cbSourcesList.SelectedItem
        Dim _sampleNumber = Me.oSampleNumber

        'задать устройство принимающее
        Dim _Tosource As Service.clsFilesSources = oCurrentFileSource

        'задать устройство источник
        Dim _Fromsource As Service.clsFilesSources = Service.clsFilesSources.CreateInstance(Service.clsFilesSources.emSources.FreeFolder, , False, e.ImagesPath)


        'вычислить оптимизацию
        Dim _optimize As Integer = 1024
        Dim _message As String = "Копировать " & e.ImageNames.Length & " файлов "
        _message += "с оптимизацией по длинной стороне " & _optimize.ToString & "?"
        'задать вопрос
        Select Case MsgBox(_message, MsgBoxStyle.YesNo)
            Case MsgBoxResult.Yes
                'копировать
                Dim _count As Integer = Service.clsApplicationTypes.SamplePhotoObject.CopyImagesFromSourceToSource(_sampleNumber, _Fromsource, _Tosource, False, e.ImageNames, _optimize)

                'добавим в XML
                For Each _src In e.ImageNames
                    Dim _im As New CATALOGSAMPLEIMAGESIMAGE
                    _im.src = _src
                    Me.oCurrentCatalogSampleObj.IMAGES.AddImage(_im)
                Next

                MsgBox(_count & " фото скопированы для образца" & _sampleNumber.GetEan13 & " на уст-во " & _Tosource.ToString, vbInformation)
                Me.oImageChangedFlag = True
            Case MsgBoxResult.No
                Exit Sub
        End Select



    End Sub

    ''' <summary>
    ''' удаление фоток
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub DelImage_eventHandler(ByVal sender As Object, ByVal e As Service.clsApplicationTypes.fmImageDelEventArg)
        If e.ImageNames.Count = 0 Then Exit Sub

        'удалить изображения, список имен в аргументе
        'Dim _filesrc = Service.clsFilesSources.CreateInstance(Service.clsFilesSources.emSources.FreeFolder, , , IO.Path.GetDirectoryName(oCurrentFullPathToSampleXMLFile))
        Dim _sampleNumber = Me.oSampleNumber
        Dim _coll(e.ImageNames.Count - 1) As String
        e.ImageNames.CopyTo(_coll, 0)


        Dim _count As Integer = Service.clsApplicationTypes.SamplePhotoObject.DeleteImagesFromSource(_sampleNumber, oCurrentFileSource, _coll, False, False)

        'удалим из XML
        For Each _src In _coll
            Me.oCurrentCatalogSampleObj.RemoveSampleImage(_src, False)
        Next

        MsgBox("Удалено " & _count & " фото с устр-ва " & oCurrentFileSource.ToString, vbInformation)
        Me.oImageChangedFlag = True
        Me.LoadPhotos()
    End Sub

    Private Sub UcPhotoManager1_PhotosAdded(sender As Object, e As ucPhotoManager.PhotoEventArgs) Handles UcPhotoManager1.PhotosAdded
        For Each _img In e.ImageNamesList
            Me.oCurrentCatalogSampleObj.AddSampleImage(_img, False)
            LoadPhotos(False)
        Next
    End Sub
    Private Sub UcPhotoManager1_PhotosDeleted(sender As Object, e As ucPhotoManager.PhotoEventArgs) Handles UcPhotoManager1.PhotosDeleted
        For Each _img In e.ImageNamesList
            Me.oCurrentCatalogSampleObj.RemoveSampleImage(_img, False)
        Next
        LoadPhotos(True)
    End Sub


#End Region

#Region "События источников данных"
    ''' <summary>
    ''' сохранение карты образца
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub oCurrentSample_PropertyChanged(sender As Object, e As System.ComponentModel.PropertyChangedEventArgs) Handles oCurrentCatalogSampleObj.PropertyChanged
        Me.btSaveXMLMap.BackColor = Drawing.Color.Red
    End Sub
    ''' <summary>
    ''' когда меняется маппинг образца
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub SampleMappingChanged(sender As Object, e As EventArgs)
        If Me.wbMain.Visible Then
            Me.HTMLgenerate()
        End If
        Me.btSaveXMLMap.BackColor = Drawing.Color.Red
    End Sub


    ''' <summary>
    ''' установка цен из МС
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub UserControlMC1_PriceSet(sender As Object, e As UserControlMC.PriceSetEventArgs) Handles UserControlMC1.PriceSet
        Me.oRecommentPrice = e.Price
        Me.oRecommendedPriceCurrency = e.Currency
        Me.Uc_mailer1.SetPrice(oRecommentPrice, oRecommendedPriceCurrency)
        clsApplicationTypes.BeepYES()
        nudWorldCount_ValueChanged(Me, EventArgs.Empty)
    End Sub



    Private Sub ClsApplicationTypes_clsSampleNumber_strGoodInfoBindingSource_CurrentItemChanged(sender As Object, e As EventArgs) Handles ClsApplicationTypes_clsSampleNumber_strGoodInfoBindingSource.CurrentItemChanged
        If ClsApplicationTypes_clsSampleNumber_strGoodInfoBindingSource.Current Is Nothing Then oCurrentGoodInfo = Nothing : Return
        'текущий обьект
        oCurrentGoodInfo = ClsApplicationTypes_clsSampleNumber_strGoodInfoBindingSource.Current
        'фотка
        Dim _num = clsSampleNumber.CreateFromString(oCurrentGoodInfo.ActualNumber)
        Me.pbFirstImg.SizeMode = PictureBoxSizeMode.Zoom
        Me.pbFirstImg.Image = clsApplicationTypes.SamplePhotoObject.GetMainImage(clsFilesSources.Arhive, _num, True)
        Me.tbGoodLocation.Text = ""
    End Sub

#End Region

#Region "Puplic properties"
    Public ReadOnly Property CurrentSample As CATALOGSAMPLE
        Get
            If oCurrentCatalogSampleObj Is Nothing Then
                Dim _status As Integer
                If Me.rbEnglish.Checked Then
                    oCurrentCatalogSampleObj = CATALOGSAMPLE.ParseSample(oXMLMAPcollection(1).ToString, _status)
                End If
                If Me.rbRussian.Checked Then
                    oCurrentCatalogSampleObj = CATALOGSAMPLE.ParseSample(oXMLMAPcollection(0).ToString, _status)
                End If
            End If
            Return oCurrentCatalogSampleObj
        End Get
    End Property

#End Region

    ''' <summary>
    ''' запрос склада
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Uc_nopGood1_RequestWarehouse(sender As Object, e As uc_nopGood.RequestWarehouseEventArgs) Handles Uc_nopGood1.RequestWarehouse
        '--поиск склада
        Dim _externalObj As nopRestClient.clsExternalData = clsApplicationTypes.SiteExternalObject
        '--запись склада
        _externalObj.WarehouseString = Me.GetWarehouseNameForSample
    End Sub

    Private Sub Uc_mailer1_CultureChanged(sender As Object, e As CultureChangedEventArgs) Handles Uc_mailer1.CultureChanged
        Me.Culture = e.Culture
        'Me.Uc_mailer1.SetHTML(Me.CurrentHTML)
    End Sub

   
End Class

