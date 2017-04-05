Imports Service.clsApplicationTypes
Imports Service

Public Class clsPhotoService
    '  Private Shared oCurrencyList As New Specialized.StringCollection
    Public Shared ReadOnly Property GetDigiKey As Object
        Get
            Return Service.clsApplicationTypes.GetDigiKeyBoardForm
        End Get
    End Property

    Public Sub New()
        'регистрируем предоставляемые сервисы
        ''1. сервис загрузки фото из источника
        ''привязываем делегат к функции
        ''передаем делегат (регестрируем) и список в сервисном классе
        'DelegatStoreImageService = _
        'New ImageServiceDelegateFunction(AddressOf LoadImagesFromSource)


        '3. сервис формы fmImage
        'привязываем делегат к функции
        'передаем делегат (регестрируем) и список в сервисном классе
        DelegateStoreApplicationForm(emFormsList.fmImage) = _
 New ApplicationFormDelegateFunction(AddressOf GetfmImageAsForm)


        '5. сервис формы fmSampleData
        'привязываем делегат к функции
        'передаем делегат (регестрируем) и список в сервисном классе
        DelegateStoreApplicationForm _
            (emFormsList.fmSampleData) = New ApplicationFormDelegateFunction(AddressOf GetfmSampleDataAsForm)

        '6. сервис формы fmPhotoList
        'привязываем делегат к функции
        'передаем делегат (регестрируем) и список в сервисном классе
        DelegateStoreApplicationForm _
            (emFormsList.fmPhotoList) = New ApplicationFormDelegateFunction(AddressOf GetfmPhotoListAsForm)

        '10 сервис формы fmListManager
        Global.Service.clsApplicationTypes.DelegateStoreApplicationForm _
            (emFormsList.fmListManager) = _
            New ApplicationFormDelegateFunction(AddressOf GetfmListManager)

        '10 сервис формы fmSampleList
        Global.Service.clsApplicationTypes.DelegateStoreApplicationForm _
            (emFormsList.fmSampleList) = _
            New ApplicationFormDelegateFunction(AddressOf GetfmSampleListAsForm)

        '7. сервис синхронизации fmSampleData
        DelegatStoreSynchroSampleDataDbo = _
         New SynchroSampleDataDboDelegateFunction(AddressOf SynchroSampleDataDbo)


        '8. сервис добавления данных образца в бд
        DelegateStoreAddSampleDataIntoDB = _
         New AddSampleDataIntoDBDelegateFunction(AddressOf AddSampleInfo)

        '--------обновление подключения к БД------------

        'БД не задействована

        '9. сервис формы управлением изображениями
        DelegateStoreApplicationForm _
            (emFormsList.fmImageManager) = New ApplicationFormDelegateFunction(AddressOf GetfmImageManagerAsForm)

    End Sub


#Region "Service use"

#End Region

#Region "inner functions"

    '''' <summary>
    ''''  возвращает структуру SampleSourceImageList = изображения для образца
    '''' </summary>
    '''' <param name="SampleNumberStructure">структура номера</param>
    '''' <param name="ImageSizeInList">размер изображения в ЭУ</param>
    '''' <param name="LoadOnlyOne">загрузить только первую фотку</param>
    '''' <returns></returns>
    '''' <remarks>в свойстве key лежит путь к изображению</remarks>
    'Friend Overloads Shared Function LoadImagesFromSource(ByVal SampleNumberStructure As clsSampleNumber, ByVal ImageSizeInList As Size, _
    'ByVal LoadOnlyOne As Boolean) As SampleSourceImageList

    'Dim _struct As New SampleSourceImageList

    'Dim _imagesPaths As String() = GetImagesPaths(SampleNumberStructure)
    '_struct.CountImages = _imagesPaths.Length

    'If LoadOnlyOne Then
    ''берем только первый файл
    ''в дальнейшем надо брать главную фотку
    '_imagesPaths = {_imagesPaths.GetValue(0)}
    'End If


    '_struct.ListViewItemCollection = New Collections.Generic.List(Of Windows.Forms.ListViewItem)
    '_struct.ImageList = New Windows.Forms.ImageList
    '_struct.ImageList.ImageSize = ImageSizeInList
    '_struct.ImageList.ColorDepth = ColorDepth.Depth32Bit


    '' тут начнется сама загрузка фото
    '' в _imagesPaths лежат все пути

    'Dim _listviewitem As Windows.Forms.ListViewItem

    ''загружаем фотки в список
    'For Each _showImagePath As String In _imagesPaths
    'Dim _filename As String = IO.Path.GetFileName(_showImagePath)
    ''key нужен для однозначной индиентификации фото при показе в отдельном окне
    '_struct.ImageList.Images.Add(_showImagePath, Drawing.Image.FromFile(_showImagePath))

    ''_struct.ImageList.Images.Add(Drawing.Image.FromFile(_showImagePath))

    '_listviewitem = New Windows.Forms.ListViewItem

    '_listviewitem.Name = _filename
    '_listviewitem.ImageIndex = _struct.ImageList.Images.Count - 1

    '_struct.ListViewItemCollection.Add(_listviewitem)

    '_struct.RaiseLoadImageEvent(_filename)

    'Next

    'Return _struct
    'End Function
    '''' <summary>
    '''' возвращает список путей для требуемого образца
    '''' </summary>
    '''' <param name="SampleNumberStructure"></param>
    '''' <returns></returns>
    '''' <remarks></remarks>
    'Private Shared Function GetImagesPaths(ByVal SampleNumberStructure As clsSampleNumber) As String()
    ''проверить наличие директории
    'If Not IO.Directory.Exists(SampleNumberStructure.FolderPath) Then
    'MsgBox("source inaccessible" & SampleNumberStructure.FolderPath, MsgBoxStyle.Information)
    'Return {""}
    'End If

    ''проверить наличие файлов в директории
    'If IO.Directory.GetFiles(SampleNumberStructure.FolderPath, "*.jpg").Length = 0 Then
    'MsgBox("There are no image for show in source path " & SampleNumberStructure.FolderPath, MsgBoxStyle.Information)
    'Return {""}
    'End If

    'Return IO.Directory.GetFiles(SampleNumberStructure.FolderPath, "*.jpg")

    'End Function

    '''' <summary>
    '''' возвращает коллекцию номеров образцов по результату поиска в источнике
    '''' используется выражение фильтра
    '''' </summary>
    'Friend Overloads Shared Function GetSamplesNumberListWithPhotoFilter _
    '(ByVal Filter As String, ByVal source As emSources) As Generic.List(Of clsSampleNumber)
    ''!!!!функция перенесена!!!!! удалить!!!! 
    'Dim _sources As String() = Nothing
    ''------------------------------------------
    'Select Case source
    'Case emSources.AllSources
    '_sources = {SampleInfoObject.CurrentPhotoPath, SampleInfoObject.ArhivePhotoPath}
    'Case emSources.Arhive
    '_sources = {SampleInfoObject.ArhivePhotoPath}
    'Case emSources.Current
    '_sources = {SampleInfoObject.CurrentPhotoPath}

    'Case emSources.SpecificOrder
    ''выбрать путь текущего (активного) заказа
    'Dim _activeOrder As strOrder
    ''по запросу выполняем вызов из сервиса
    ''если делегата нет, то сервис недоступен
    'If Not DelegatStoreActiveOrder Is Nothing Then
    ''сервис зарегестрирован - вызываем
    '_activeOrder = DelegatStoreActiveOrder.Invoke()
    'Else
    ''делегат недоступен
    ''вернуть пустой список
    'Return New Generic.List(Of clsSampleNumber)

    'End If

    ' ''check order name
    'Dim _orderName As String = Trim(_activeOrder.OrderID)

    '_sources = {IO.Path.Combine(OrdersPath, _orderName)}

    'End Select
    ''------------------------------------------------------------------
    'Dim _sampleColl As New Generic.List(Of clsSampleNumber)

    'Dim _filter As String = Filter

    'If Not Filter.Length = 13 Then
    '_filter = Filter & "*"
    'End If

    'For Each _connection As String In _sources
    'If IO.Directory.Exists(_connection) Then
    ''ищем директорию с номером  в корне
    'For Each _tmpDir As String In _
    'IO.Directory.GetDirectories(_connection, _filter, IO.SearchOption.AllDirectories)
    ''номер найден
    'Dim _struct As clsSampleNumber = clsSampleNumber.CreateInstace(_tmpDir, IO.Path.GetFileName(_tmpDir))
    'If Not _struct Is Nothing Then
    '_sampleColl.Add(_struct)
    'End If
    'Next

    'End If
    'Next

    '_sampleColl.Sort()


    'Return _sampleColl


    'End Function

#End Region


#Region "Service provide"




    ''' <summary>
    ''' записывает в БД инфо об образце, принимая строгую структуру данных
    ''' </summary>
    ''' <param name="Sample_parameter">номер,основное название, длина, ширина, вес в кг, исходная дата записи</param>
    ''' <param name="fossil_parameter">имена(), длины(), ширины(). Для добавления объекта необходимо в параметре Sample_parameter только номер образца</param>
    ''' <returns>-3: ошибка в переданной структуре, -2: образец уже есть в базе, -1: переданных данных недостаточно для записи в БД, 0: некорректный номер, 1 и более: успешно добавлено </returns>
    ''' <remarks></remarks>
    Public Shared Function AddSampleInfo(ByVal Sample_parameter As Object, ByVal fossil_parameter As Object) As Integer
        Dim _flagRecordOnlyAdditionalFossil As Boolean = False

        Dim _Sample_number As Decimal = 0
        Dim _Sample_main_name As String = ""
        Dim _Sample_Lenght As Decimal = 0
        Dim _Sample_Width As Decimal = 0
        Dim _Sample_Height As Decimal = 0
        Dim _Sample_Weight As Decimal = 0
        Dim _sample_date As Date = Date.Parse("01.01.1980")
        'Dim _sample_description As String = ""

        Dim _fossil_names() As String = {""}
        Dim _fossil_Lenghts() As Decimal = {0}
        Dim _fossil_Widths() As Decimal = {0}

        Try
            Select Case CType(Sample_parameter, Array).Length

                Case 1
                    'received number only
                    'записать фоссилию
                    _Sample_number = Decimal.Parse(Sample_parameter(0))
                    _flagRecordOnlyAdditionalFossil = True

                Case 2
                    _Sample_number = Decimal.Parse(Sample_parameter(0))
                    _Sample_main_name = Sample_parameter(1)
                Case 3
                    _Sample_number = Decimal.Parse(Sample_parameter(0))
                    _Sample_main_name = Sample_parameter(1)
                    _Sample_Lenght = Decimal.Parse(Sample_parameter(2))
                Case 4
                    _Sample_number = Decimal.Parse(Sample_parameter(0))
                    _Sample_main_name = Sample_parameter(1)
                    _Sample_Lenght = Decimal.Parse(Sample_parameter(2))
                    _Sample_Width = Decimal.Parse(Sample_parameter(3))

                Case 5
                    _Sample_number = Decimal.Parse(Sample_parameter(0))
                    _Sample_main_name = Sample_parameter(1)
                    _Sample_Lenght = Decimal.Parse(Sample_parameter(2))
                    _Sample_Width = Decimal.Parse(Sample_parameter(3))
                    _Sample_Height = Decimal.Parse(Sample_parameter(4))

                Case 6
                    _Sample_number = Decimal.Parse(Sample_parameter(0))
                    _Sample_main_name = Sample_parameter(1)
                    _Sample_Lenght = Decimal.Parse(Sample_parameter(2))
                    _Sample_Width = Decimal.Parse(Sample_parameter(3))
                    _Sample_Height = Decimal.Parse(Sample_parameter(4))
                    _Sample_Weight = Decimal.Parse(Sample_parameter(5))

                Case 7
                    _Sample_number = Decimal.Parse(Sample_parameter(0))
                    _Sample_main_name = Sample_parameter(1)
                    _Sample_Lenght = Decimal.Parse(Sample_parameter(2))
                    _Sample_Width = Decimal.Parse(Sample_parameter(3))
                    _Sample_Height = Decimal.Parse(Sample_parameter(4))
                    _Sample_Weight = Decimal.Parse(Sample_parameter(5))
                    _sample_date = Date.Parse(Sample_parameter(6))
                Case Else
                    Return -3

            End Select

            '------------------

            'parce fossils
            Select Case CType(fossil_parameter, Array).Rank
                Case 1
                    'передан одномерный массив - только одна фоссилия
                    Select Case CType(fossil_parameter, Array).Length
                        Case 1
                            'fossil names
                            _fossil_names = {fossil_parameter(0)}
                        Case 2
                            'fossil lens
                            _fossil_names = {fossil_parameter(0)}
                            _fossil_Lenghts = {fossil_parameter(1)}
                        Case 3
                            'fossil wights
                            _fossil_names = {fossil_parameter(0)}
                            _fossil_Lenghts = {Decimal.Parse(fossil_parameter(1))}
                            _fossil_Widths = {Decimal.Parse(fossil_parameter(2))}
                        Case Else
                            Return -3
                    End Select
                Case 2
                    'передан двумерный массив - может быть несколько фоссилий
                    Dim _uppBd As Integer = CType(fossil_parameter, Array).GetUpperBound(1)
                    ReDim _fossil_names(_uppBd)
                    ReDim _fossil_Lenghts(_uppBd)
                    ReDim _fossil_Widths(_uppBd)
                    For j = 0 To _uppBd
                        Select Case CType(fossil_parameter, Array).GetUpperBound(0)
                            Case 0
                                _fossil_names(j) = fossil_parameter(0, j)
                            Case 1
                                _fossil_names(j) = fossil_parameter(0, j)
                                _fossil_Lenghts(j) = Decimal.Parse(fossil_parameter(1, j))
                            Case 2
                                _fossil_names(j) = fossil_parameter(0, j)
                                _fossil_Lenghts(j) = Decimal.Parse(fossil_parameter(1, j))
                                _fossil_Widths(j) = Decimal.Parse(fossil_parameter(2, j))
                            Case Else
                                Return -3
                        End Select

                    Next
            End Select



        Catch ex As FormatException
            Return -3
        Catch ex As InvalidCastException
            Return -3
        Catch ex As IndexOutOfRangeException
            Return -3

        End Try

        '=================
        'здесь все параметры верны
        'проверить наличие образца в бд
        Dim _ds As New dsPhotoData
        Dim _adaptSample As New dsPhotoDataTableAdapters.Select_tb_Samples_photo_dataTableAdapter
        Dim _adaptFoss As New dsPhotoDataTableAdapters.Select_tb_Samples_FossilsTableAdapter

        '---------------------------------
        'создать или обновить запись образца
        Dim _sample_row As dsPhotoData.Select_tb_Samples_photo_dataRow
        Dim _flagSampleExist As Boolean = False

        Dim _count As Integer
        Try
            _count = _adaptSample.Fill(_ds.Select_tb_Samples_photo_data, _Sample_number)
        Catch ex As Exception
            MsgBox("Can't connect to DB. Connection string: " & _adaptSample.Connection.ConnectionString)
            Return -1
        End Try

        If _count > 0 Then
            'образец существует в БД
            _sample_row = _ds.Select_tb_Samples_photo_data(0)
            _flagSampleExist = True

            If Not _flagRecordOnlyAdditionalFossil Then
                'update existing sample fields
                With _sample_row


                    .Sample_length = _Sample_Lenght
                    .Sample_height = _Sample_Height
                    .Sample_main_species = _Sample_main_name.Substring(0, 49)
                    .Sample_net_weight = _Sample_Weight
                    .Sample_nickname += " rev."
                    .Sample_width = _Sample_Width
                    .Woker_full_name = "visual studio"
                    .Date_Photo = _sample_date
                    .Fossil_count = _fossil_names.Length
                End With
            End If
        Else
            'create new sample row
            If _flagRecordOnlyAdditionalFossil Then
                'для добавления объекта необходимо указать существующий номер образца
                Return -3
            End If
            _sample_row = _ds.Select_tb_Samples_photo_data.AddSelect_tb_Samples_photo_dataRow(SampleNumber:=_Sample_number, Sample_net_weight:=_Sample_Weight, Sample_width:=_Sample_Width, Sample_height:=_Sample_Height, Sample_length:=_Sample_Lenght, Sample_main_species:=_Sample_main_name, Woker_full_name:="visual studio", Fossil_count:=_fossil_names.Length, Sample_nickname:="programm added", Date_Photo:=_sample_date, Version:={0})

        End If

        '----------------------------
        'создать или обновить записи фоссилий
        Dim _flagFossilsExist As Boolean = False

        If _adaptFoss.Fill(_ds.Select_tb_Samples_Fossils, _Sample_number) > 0 Then
            _flagFossilsExist = True
        End If

        Dim _curr_name As String
        Dim _curr_leigh As Decimal
        Dim _curr_width As Decimal

        For i = 0 To _fossil_names.Length - 1
            'check unput values
            Try
                If _fossil_names(i).Length > 49 Then
                    _curr_name = _fossil_names(i).Substring(0, 49)
                Else
                    _curr_name = _fossil_names(i)
                End If

                If _fossil_Lenghts.GetUpperBound(0) >= i Then
                    _curr_leigh = _fossil_Lenghts(i)
                End If
                If _fossil_Widths.GetUpperBound(0) >= i Then
                    _curr_width = _fossil_Widths(i)
                End If
            Catch ex As InvalidCastException
                Return -3
            End Try
            'данные фоссилий ок.
            'заполнить БД
            If Not _flagSampleExist Then
                'sample not exist
                'add current fossil
                _ds.Select_tb_Samples_Fossils.AddSelect_tb_Samples_FossilsRow(_sample_row, _curr_name, {0}, _curr_leigh, _curr_width, 0, i + 1)
            Else
                'sample exist
                If _flagRecordOnlyAdditionalFossil Then
                    'add current fossil
                    _ds.Select_tb_Samples_Fossils.AddSelect_tb_Samples_FossilsRow(_sample_row, _curr_name, {0}, _curr_leigh, _curr_width, 0, i + 1)
                End If
            End If
        Next

        '--------------------------------------
        'сохранить изменения в бд
        'sample record

        If Not _flagRecordOnlyAdditionalFossil Then
            _adaptSample.Update(_ds.Select_tb_Samples_photo_data)
        End If

        'fossils records
        Return _adaptFoss.Update(_ds.Select_tb_Samples_Fossils)

    End Function

    ''' <summary>
    ''' сервис синхронизации
    ''' </summary>
    ''' <param name="xml">xml файл для датасет</param>
    ''' <returns>результат операции</returns>
    ''' <remarks>В форме fmSampleData нельзя использовать AcceptChanges!</remarks>
    Public Shared Function SynchroSampleDataDbo(ByVal xml As String) As Boolean
        Dim _fm As New fmSampleData
        'прочитать хмл
        Dim _xmlReader As New IO.StringReader(xml)
        _fm.DsPhotoData.ReadXml(_xmlReader, XmlReadMode.Auto)
        'сохранить в БД
        _fm.TableAdapterManager.UpdateAll(_fm.DsPhotoData)

        _fm = Nothing

        Return True

    End Function

    ''' <summary>
    ''' регистрирует форму как форму-источник списка номеров
    ''' </summary>
    ''' <param name="fm"></param>
    ''' <remarks></remarks>
    Public Shared Sub RegisterFormToSampleListService(fm As Form)
        If Not TypeOf fm Is Service.iListSampleDataProvider Then Exit Sub
        ofmListManager.RegisterForm(fm)
    End Sub
    ''' <summary>
    ''' удаляет регистрацию формы как форму-источник списка номеров
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub UnRegisterAnyFormToSampleListService()
        ofmListManager.UnRegisterAnyForm()
    End Sub
#End Region

#Region "Forms provide"
    ''' <summary>
    ''' return fmImage of this progect
    ''' </summary>
    Private Overloads Shared Function GetfmImage(ByVal image As Image, ByVal formText As String) As fmImage
        Return New fmImage(image, formText)
    End Function
    Private Overloads Shared Function GetfmImage(ByVal imageList As Windows.Forms.ImageList, ByVal formText As String) As fmImage
        Return New fmImage(imageList, formText)
    End Function
    Private Overloads Shared Function GetfmImage(ByVal imageList As SampleSourceImageList, ByVal formText As String) As fmImage
        Return New fmImage(imageList, formText)
    End Function
    Private Overloads Shared Function GetfmImage(ImageList As List(Of Image), formText As String) As Form
        Return New fmImage(ImageList, formText)
    End Function


    'Private Overloads Shared Function GetfmImage(param As Object, formText As String) As Form
    '    'получить imagelist из списка номеров
    '    'Param(0) = list(of clsSamplenumber)
    '    'Param(1) = filesource
    '    clsApplicationTypes.SamplePhotoObject.GetImageNamesList()

    '    Return New fmImage(list, formText)
    'End Function
    ''' <summary>
    ''' delegat linked
    ''' </summary>
    ''' <param name="param"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function GetfmImageAsForm(ByVal param As Object) As Form
        If IsArray(param) Then
            Select Case CType(param, System.Array).Length
                Case 0
                    Return Nothing
                Case 1
                    If param(0) Is Nothing Then Return Nothing

                    Select Case param(0).GetType.Name
                        Case "Image"

                            Return GetfmImage(CType(param(0), Image), "")
                        Case "Bitmap"
                            Return GetfmImage(CType(param(0), Image), "")
                        Case "ImageList"
                            Return GetfmImage(CType(param(0), ImageList), "")
                        Case "SampleSourceImageList"
                            Return GetfmImage(CType(param(0), SampleSourceImageList), "")
                        Case "List`1"
                           Return GetfmImage(CType(param(0), List(Of Image)), "")

                        Case Else
                            Return Nothing
                    End Select

                Case 2
                    Select Case param(0).GetType.Name
                        Case "Image"
                            Return GetfmImage(CType(param(0), Image), CType(param(1), String))
                        Case "Bitmap"
                            Return GetfmImage(CType(param(0), Image), CType(param(1), String))
                        Case "ImageList"
                            Return GetfmImage(CType(param(0), ImageList), CType(param(1), String))
                        Case "SampleSourceImageList"
                            Return GetfmImage(CType(param(0), SampleSourceImageList), CType(param(1), String))
                        Case "List`1"
                            Return GetfmImage(CType(param(0), List(Of Image)), CType(param(1), String))
                        Case Else
                            Return Nothing
                    End Select
                Case Else
                    Return Nothing
            End Select
        Else
            Select Case param.GetType.Name
                Case "Image"
                    Return GetfmImage(CType(param(0), Image), "")
                Case "ImageList"
                    Return GetfmImage(CType(param(0), ImageList), "")
                Case Else
                    Return Nothing
            End Select
        End If



    End Function

    Public Shared Function GetfmSampleData(ByVal SampleNumber As Decimal) As fmSampleData
        Dim _fm = New fmSampleData(SampleNumber)

        Return _fm
    End Function
    ''' <summary>
    ''' delegat linked
    ''' </summary>
    ''' <param name="param"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function GetfmSampleDataAsForm(ByVal param As Object) As Form
        If param Is Nothing Then Return New fmSampleData
        Dim _SampleNumber As Decimal = CType(param(0), Decimal)

        Return GetfmSampleData(_SampleNumber)

    End Function
    Public Shared Function GetfmImageManager(sampleNumber As clsSampleNumber) As fmImageManager
        Return GetfmImageManagerAsForm({sampleNumber})
    End Function

    Private Shared Function GetfmImageManagerAsForm(formparam As Object) As Form
        Dim _SampleNumber As Decimal
        Dim _fm As fmImageManager
        If Not formparam Is Nothing Then

            If TypeOf formparam Is String() Then
                _SampleNumber = CType(formparam(0), Decimal)
                _fm = New fmImageManager(clsSampleNumber.CreateFromString(CType(formparam(0), String)))
            ElseIf CType(formparam, Array).Length = 0 Then
                _fm = New fmImageManager()
            ElseIf TypeOf formparam(0) Is clsSampleNumber Then
                _fm = New fmImageManager(CType(formparam(0), clsSampleNumber))
            ElseIf TypeOf formparam(0) Is Decimal Then
                _fm = New fmImageManager(clsSampleNumber.CreateFromString(formparam(0).ToString))
            ElseIf TypeOf formparam(0) Is clsFilesSources Then
                _fm = New fmImageManager(CType(formparam(0), clsFilesSources), CType(formparam(1), clsSampleNumber))
            Else
                _fm = New fmImageManager()
            End If

            If IsArray(formparam) AndAlso CType(formparam, Array).Length > 1 Then
                Dim _pm = CType(formparam, Array)
                If _pm.Length > 1 And TypeOf (_pm(1)) Is String Then
                    Dim _path As String = _pm(1)
                    If _path.Length > 0 Then
                        _fm.ActiveFolder = _path
                    End If

                End If

            End If

            Return _fm
        Else
            Return New fmImageManager()
        End If
    End Function
    Public Shared Function GetfmSampleListAsForm(param As Object) As Form
        Dim _list As String() = Nothing
        Dim _caption As String = Nothing

        If param Is Nothing Then Return Nothing
        If TypeOf param Is Array Then
            If param(0) Is Nothing Then Return Nothing
            If Not TypeOf param(0) Is String() Then Return Nothing
            _list = param(0)
            If CType(param, Array).Length > 1 Then
                _caption = param(1)
                Return New fmSelectSample(_list, _caption)
            End If
        Else
            Return Nothing
        End If

        Return Nothing

    End Function

    'Public Shared Function GetfmSampleOnSale(ByVal SampleNumber As Decimal) As fmSampleOnSale
    ''Dim _param As Object = {SampleNumber}

    ' ''по запросу выполняем вызов из сервиса
    ''Dim _fmtpy As MyFormsList = MyFormsList.fmSampleOnSale
    ' ''если делегата нет, то сервис недоступен
    ''If Not ApplicationFormDelegateStore(_fmtpy) Is Nothing Then
    ' ''сервис зарегестрирован - вызываем
    ''Return ApplicationFormDelegateStore(_fmtpy).Invoke(_fmtpy, _param)
    ''Else
    ''Return Nothing
    ''End If


    'Return New fmSampleOnSale(SampleNumber, CurrencyList)
    'End Function
    '''' <summary>
    '''' delegat linked
    '''' </summary>
    '''' <param name="param"></param>
    '''' <returns></returns>
    '''' <remarks></remarks>
    'Private Shared Function GetfmSampleOnSaleAsForm(ByVal param As Object) As Form
    'Dim _SampleNumber As Decimal = CType(param(0), Decimal)

    'Return GetfmSampleOnSale(_SampleNumber)

    'End Function

    Public Shared Function GetfmPhotoList(ByVal param As Object) As fmPhotoList



        Return New fmPhotoList(Nothing)
    End Function
    ''' <summary>
    ''' delegat linked
    ''' </summary>
    ''' <param name="param"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function GetfmPhotoListAsForm(ByVal param As Object) As Form

        Return GetfmPhotoList(param)

    End Function
    ''' <summary>
    ''' в param(0) положить обьект, который реализует iListSampleDataProvider. если в буфере есть форма списков, то вернет ее, проверив регистрацию обьекта, или создаст новую.
    ''' </summary>
    ''' <param name="param"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function GetfmListManager(param As Object) As Form
        If param Is Nothing Then Return Nothing
        If TypeOf param Is Array Then
            If CType(param, Array).Length = 0 Then Return Nothing
            If param(0) Is Nothing Then Return Nothing
            If TypeOf param(0) Is Service.iListSampleDataProvider Then
                'вернуть привязанную форму
                If ofmListManager Is Nothing Then
                    ofmListManager = New fmListManager()
                Else
                    'отменяет регистрацию любой формы как источника событий iListSampleDataProvider
                    Call UnRegisterAnyFormToSampleListService()
                End If
                Call RegisterFormToSampleListService(param(0))
                Return ofmListManager
            ElseIf TypeOf param(0) Is String Then
                'вернуть свободную форму с источником данных - param(0) имя файла
                Dim _filename As String = CType(param(0), String)
                Return New fmListManager(_filename)
            End If

        End If
        Return Nothing
    End Function
    Private Shared ofmListManager As fmListManager

#End Region


End Class
