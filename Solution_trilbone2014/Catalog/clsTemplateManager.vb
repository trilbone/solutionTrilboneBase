Imports System.Drawing
Imports Service
Imports Service.clsApplicationTypes

Namespace Trilbone

  

    Partial Public Class clsTemplateManager

        Private oCurrentPath As String
        Private oTemplates As clsTemplates
        'Private Sub LoadTemplates()
        '    Dim _path = IO.Path.Combine(Me.TemplatePath, My.Settings.TemplateCollectionFile)
        '    If IO.File.Exists(_path) Then
        '        'read template file
        '        Dim _s = IO.File.ReadAllText(_path)
        '        Me.oTemplates = clsTemplateManager.clsTemplates.ParseTemplates(_s)
        '    Else
        '        'create template file
        '        Me.oTemplates = New clsTemplates()
        '    End If

        '    If Me.oTemplates.MustSaved Then
        '        Me.SaveTemplateFile()
        '    End If

        'End Sub

        ' ''' <summary>
        ' ''' сосхранить файл с шаблонами
        ' ''' </summary>
        ' ''' <remarks></remarks>
        'Private Sub SaveTemplateFile()
        '    'save file
        '    Dim _path = IO.Path.Combine(Me.TemplatePath, My.Settings.TemplateCollectionFile)
        '    IO.File.WriteAllText(_path, Me.oTemplates.GetXML)
        'End Sub

        ''' <summary>
        ''' сосхранить файл с шаблонами
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub SaveMapFile()
            'save file
            Dim _path = IO.Path.Combine(clsApplicationTypes.TemplateFolderPath, My.Settings.MappingFileName)

            Dim _wrsett As New Xml.XmlWriterSettings
            Dim _xmlSerializer As Xml.Serialization.XmlSerializer
            Dim _xmlwriter As Xml.XmlWriter
            Dim _strBuilt As New System.Text.StringBuilder

            _xmlSerializer = New Xml.Serialization.XmlSerializer(GetType(List(Of CATALOGELEMENTMAP)))
            With _wrsett
                .Encoding = System.Text.Encoding.GetEncoding("windows-1251")
                .Indent = True
            End With
            Try
                _xmlwriter = Xml.XmlWriter.Create(_strBuilt, _wrsett)
                _xmlSerializer.Serialize(_xmlwriter, Me.oMaps)
                _xmlwriter.Flush()
                _xmlwriter.Close()
                IO.File.WriteAllText(_path, _strBuilt.ToString)

            Catch ex As Exception
                MsgBox("011. Ошибка XML " & ex.Message, vbCritical)
                Return
            End Try

            MsgBox("Файл карт сохранен.", vbInformation)


        End Sub

        Public Sub New()
            Me.oTemplates = New clsTemplates()
            LoadTemplates()
        End Sub

        ''' <summary>
        ''' загружает шаблоны из папки
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub LoadTemplates()
            If IO.Directory.Exists(clsApplicationTypes.TemplateFolderPath) Then
                Dim _filename As String
                For Each _file In IO.Directory.GetFiles(clsApplicationTypes.TemplateFolderPath, "*.xslt")
                    _filename = IO.Path.GetFileName(_file)
                    If Not Me.oTemplates.ContainsValue(_filename) Then
                        Me.oTemplates.Add(IO.Path.GetFileNameWithoutExtension(_file), _filename)
                    End If
                Next
            End If
        End Sub

        ''' <summary>
        ''' вернет форму управления XML образцов param={string,string,string} 
        ''' получим: _paramXMLFile=карта XML или путь к файлу с картой /  _paramXMLelements=полное Описание XML / _paramXMLLabel=xml из labelinfo
        ''' </summary>
        ''' <param name="param"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function GetFmCatalogSample(param As Object) As Windows.Forms.Form
            If param Is Nothing Then Return New fmcatalog
            If IsArray(param) Then
                Select Case CType(param, System.Array).Length
                    Case 0
                        'параметров нет
                        Return New fmcatalog
                    Case 1
                        If param(0) Is Nothing Then Return New fmcatalog

                        If TypeOf (param(0)) Is String Then
                            Return New fmcatalog(param(0), "", "", Nothing)
                        End If
                    Case Is > 1
                        If param(0) Is Nothing Then Return New fmcatalog

                        If TypeOf (param(0)) Is String Then
                            Return New fmcatalog(param(0), param(1), param(2), param(3))
                        End If
                    Case Else
                        Return New fmcatalog
                End Select
            Else
                If TypeOf (param) Is String Then
                    Return New fmcatalog(param, "", "", Nothing)
                End If

            End If

            Return New fmcatalog


        End Function

        ''' <summary>
        ''' вернет, требуется ли шаблону контейнер с превьюшкам /small
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetTemplateSmallFlag(TemplateType As emTemplateType, Optional TemplateName As String = "") As Boolean
            If TemplateName = "" Then
                TemplateName = Me.GetTemplateNameByType(TemplateType)
            End If
            Dim _res = From c In Me.oTemplates Where c.Key = TemplateName Select c
            If _res.Count > 0 Then
                Return _res(0).includesmall
            End If
            Return False
        End Function


        ''' <summary>
        ''' вернет по имени ширину изображений шаблона
        ''' </summary>
        ''' <param name="TemplateType"></param>
        ''' <param name="TemplateName"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetTemplateImageWidth(TemplateType As emTemplateType, Optional TemplateName As String = "") As Integer
            If TemplateName = "" Then
                TemplateName = Me.GetTemplateNameByType(TemplateType)
            End If
            Dim _res = From c In Me.oTemplates Where c.Key = TemplateName Select c
            If _res.Count > 0 Then
                Return _res(0).ImageWidth
            End If
            Return 0
        End Function
        ''' <summary>
        ''' менять по мере изменения шаблонов
        ''' </summary>
        ''' <param name="TemplateType"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function GetTemplateNameByType(TemplateType As emTemplateType) As String
            Dim _name As String = "noname"
            Select Case TemplateType
                Case emTemplateType.CatalogHTML
                    _name = "XSLTCatalog"
                Case emTemplateType.CatalogTXT
                    _name = "XSLTCatalog_text"
                Case emTemplateType.Site_mail_template
                    _name = "Site_mail"
                Case emTemplateType.eBay_Nordstar_txt
                    _name = "eBay_NordStar"
                Case emTemplateType.Tribone_template_img
                    _name = "eBay_Trilbone_img"
            End Select
            Return _name
        End Function

      


        ''' <summary>
        ''' разберет текстовое выражение в обьект XElement. Status -1 = ошибка
        ''' </summary>
        ''' <param name="xml"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function ParseTextToXElement(xml As String, ByRef status As Integer) As XElement
            Try
                Dim _xml = XElement.Parse(xml)
                status = 1
                Return _xml
            Catch ex As Exception
                status = -1
                Return Nothing
            End Try
        End Function


        ''' <summary>
        ''' возвращает разобранное описание для образца в каталог.
        ''' </summary>
        ''' <param name="XMLDescriptionString"></param>
        ''' <param name="culture"></param>
        ''' <param name="status"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function DescriptionParser(XMLDescriptionString As String, culture As System.Globalization.CultureInfo, ByRef status As Boolean) As List(Of CATALOGSAMPLEELEMENT)
            '        Генерируем(теги)

            '        SYSTEMATICA = Systematica(Систематика)
            '        TIMESCALE = Age(Возраст)
            '        LOCALITY = Locality(Местонахождение)
            '        STRATIGRAPHY = Stratigraphy(Стратиграфия)

            '       разделитель = ", "

            Debug.Assert(Not culture Is Nothing)
            Dim _out As New List(Of CATALOGSAMPLEELEMENT)
            If culture Is Nothing Then culture = EnglishCulture
            'пробуем описание
            Dim _status As Integer
            Dim _xml = ParseTextToXElement(XMLDescriptionString, _status)
            'не удалось разобрать строку
            If _status <= 0 Then status = False : Return _out
            'все ок.
            Dim _element As CATALOGSAMPLEELEMENT
            Dim _langfilter = From c In _xml...<ELEMENT> Where c.@lang = culture.Name Select c
            Dim _value As String

            'название элемента (alt)
            Dim _rootName As String
            For Each _descrELEMENT In _langfilter

                _rootName = _descrELEMENT.@root
                'немного перевода
                If _rootName.ToLower = "timescale" Then _rootName = "Age"
                If _rootName.ToLower = "localities" Then _rootName = "Locality"
                Dim _descrsuffics = My.Settings.DescriptionTagSuffics

                Dim _iitag As Integer = 1
                Dim _tmpitag As Integer = 0
                'делаем element
                Select Case _descrELEMENT.@name.ToLower

                    Case "systematica", "devonian"
                        'СИСТЕМАТИКА
                        _value = ParseNodeXML(_descrELEMENT, "-> ", False)
                        If culture.Name.Equals(clsApplicationTypes.RussianCulture.Name) Then
                            _element = CATALOGSAMPLEELEMENT.CreateDataElement("SYSTEMATICA", _value, CATALOGSAMPLEELEMENT.emPosition.down, "Систематика", , , , _iitag)
                        Else
                            _element = CATALOGSAMPLEELEMENT.CreateDataElement("SYSTEMATICA", _value, CATALOGSAMPLEELEMENT.emPosition.down, "Systematica", , , , _iitag)
                        End If
                        If Not _element Is Nothing Then
                            _out.Add(_element)
                            'описание оконечного тега
                            If _descrELEMENT.<NODE>.Last.<DESCRIPTION>.Count > 0 Then
                                Dim _valueTagDesc As String = ""
                                For Each t In _descrELEMENT.<NODE>.Last.<DESCRIPTION>
                                    _valueTagDesc += t.Value
                                Next
                                _element = CATALOGSAMPLEELEMENT.CreateDataElement("SYSTEMATICA" & _descrsuffics, _valueTagDesc, CATALOGSAMPLEELEMENT.emPosition.info, "", , , , _iitag)
                                If Not _element Is Nothing Then
                                    _out.Add(_element)
                                End If
                            End If
                            _iitag += 1
                        End If

                    Case "timescale", "age"
                        'ВОЗРАСТ
                        _value = ParseNodeXML(_descrELEMENT, ", ", False)
                        If culture.Name.Equals(clsApplicationTypes.RussianCulture.Name) Then
                            _element = CATALOGSAMPLEELEMENT.CreateDataElement("TIMESCALE", _value, CATALOGSAMPLEELEMENT.emPosition.down, "Возраст", , , , _iitag)

                        Else
                            _element = CATALOGSAMPLEELEMENT.CreateDataElement("TIMESCALE", _value, CATALOGSAMPLEELEMENT.emPosition.down, "Geological age", , , , _iitag)

                        End If
                        If Not _element Is Nothing Then
                            _out.Add(_element)
                            'описание оконечного тега
                            If _descrELEMENT.<NODE>.Last.<DESCRIPTION>.Count > 0 Then
                                Dim _valueTagDesc As String = ""
                                For Each t In _descrELEMENT.<NODE>.Last.<DESCRIPTION>
                                    _valueTagDesc += t.Value
                                Next
                                _element = CATALOGSAMPLEELEMENT.CreateDataElement("TIMESCALE" & _descrsuffics, _valueTagDesc, CATALOGSAMPLEELEMENT.emPosition.info, "", , , , _iitag)
                                If Not _element Is Nothing Then
                                    _out.Add(_element)
                                End If
                            End If
                            _iitag += 1
                        End If

                    Case "locality", "localities"
                        'МЕСТОНАХОЖДЕНИЕ
                        _value = ParseNodeXML(_descrELEMENT, ", ", False)
                        If culture.Name.Equals(clsApplicationTypes.RussianCulture.Name) Then
                            _element = CATALOGSAMPLEELEMENT.CreateDataElement("LOCALITY", _value, CATALOGSAMPLEELEMENT.emPosition.down, "Местонахождение", , , , _iitag)

                        Else
                            _element = CATALOGSAMPLEELEMENT.CreateDataElement("LOCALITY", _value, CATALOGSAMPLEELEMENT.emPosition.down, "Locality", , , , _iitag)

                        End If
                        If Not _element Is Nothing Then
                            _out.Add(_element)
                            'описание оконечного тега
                            If _descrELEMENT.<NODE>.Last.<DESCRIPTION>.Count > 0 Then
                                Dim _valueTagDesc As String = ""
                                For Each t In _descrELEMENT.<NODE>.Last.<DESCRIPTION>
                                    _valueTagDesc += t.Value
                                Next
                                _element = CATALOGSAMPLEELEMENT.CreateDataElement("LOCALITY" & _descrsuffics, _valueTagDesc, CATALOGSAMPLEELEMENT.emPosition.info, "", , , , _iitag)
                                If Not _element Is Nothing Then
                                    _out.Add(_element)
                                End If
                            End If
                            _iitag += 1
                        End If


                    Case "stratigraphy"
                        'СТРАТИГРАФИЯ
                        _value = ParseNodeXML(_descrELEMENT, "-> ", False)
                        If culture.Name.Equals(clsApplicationTypes.RussianCulture.Name) Then
                            _element = CATALOGSAMPLEELEMENT.CreateDataElement("STRATIGRAPHY", _value, CATALOGSAMPLEELEMENT.emPosition.down, "Стратиграфия", , , , _iitag)

                        Else
                            _element = CATALOGSAMPLEELEMENT.CreateDataElement("STRATIGRAPHY", _value, CATALOGSAMPLEELEMENT.emPosition.down, "Stratigraphy", , , , _iitag)

                        End If
                        If Not _element Is Nothing Then
                            _out.Add(_element)

                            'описание оконечного тега
                            If _descrELEMENT.<NODE>.Last.<DESCRIPTION>.Count > 0 Then
                                Dim _valueTagDesc As String = ""
                                For Each t In _descrELEMENT.<NODE>.Last.<DESCRIPTION>
                                    _valueTagDesc += t.Value
                                Next
                                _element = CATALOGSAMPLEELEMENT.CreateDataElement("STRATIGRAPHY" & _descrsuffics, _valueTagDesc, CATALOGSAMPLEELEMENT.emPosition.info, "", , , , _iitag)
                                If Not _element Is Nothing Then
                                    _out.Add(_element)
                                End If
                            End If
                            _iitag += 1
                        End If


                    Case "item", "ITEM"
                        'описание вручную собственно образца
                        _value = ParseNodeXML(_descrELEMENT, ", ", False)
                        If culture.Name.Equals(clsApplicationTypes.RussianCulture.Name) Then
                            _element = CATALOGSAMPLEELEMENT.CreateDataElement("ITEM", _value, CATALOGSAMPLEELEMENT.emPosition.title, _rootName, , , , _iitag)

                        Else
                            _element = CATALOGSAMPLEELEMENT.CreateDataElement("ITEM", _value, CATALOGSAMPLEELEMENT.emPosition.title, _rootName, , , , _iitag)

                        End If
                        If Not _element Is Nothing Then
                            _out.Add(_element)
                            'описание оконечного тега - старый вариант - <DESCRIPTION>
                            If _descrELEMENT.<NODE>.Last.<DESCRIPTION>.Count > 0 Then
                                Dim _valueTagDesc As String = ""
                                For Each t In _descrELEMENT.<NODE>.Last.<DESCRIPTION>
                                    _valueTagDesc += t.Value
                                Next
                                _element = CATALOGSAMPLEELEMENT.CreateDataElement("ITEM" & _descrsuffics, _valueTagDesc, CATALOGSAMPLEELEMENT.emPosition.down, "", , , , _iitag)
                                If Not _element Is Nothing Then
                                    _out.Add(_element)
                                End If
                            End If
                            _iitag += 1
                        End If

                    Case Else
                        Dim _tagName As String = _descrELEMENT.@name.ToLower
                        'для других значений (ИМЯ ТЕГА БУДЕТ В НИЖНЕМ РЕГИСТРЕ!!! ДЛЯ ОТЛИЧИЯ НЕОБРАБОТАННЫХ ТЕГОВ)
                        _value = ParseNodeXML(_descrELEMENT, ", ", False)
                        _element = CATALOGSAMPLEELEMENT.CreateDataElement(_tagName, _value, CATALOGSAMPLEELEMENT.emPosition.info, _rootName, , , , _iitag)
                        If Not _element Is Nothing Then
                            _out.Add(_element)
                            'описание (блок description) основного узла
                            If _descrELEMENT.<NODE>.Last.<DESCRIPTION>.Count > 0 Then
                                Dim _valueTagDesc As String = ""
                                For Each t In _descrELEMENT.<NODE>.Last.<DESCRIPTION>
                                    _valueTagDesc += t.Value
                                Next
                                _element = CATALOGSAMPLEELEMENT.CreateDataElement(_tagName & _descrsuffics, _valueTagDesc, CATALOGSAMPLEELEMENT.emPosition.info, "", , , , _iitag)
                                If Not _element Is Nothing Then
                                    _out.Add(_element)

                                End If
                            End If
                            _iitag += 1
                        End If
                End Select
            Next

            status = True
            Return _out
        End Function

        ''' <summary>
        '''ОСНОВНАЯ ФУНКЦИЯ СОЗДАНИЯ XML для ОБРАЗЦА// Создает образец для каталога и наполняет его данными из БД. Имена фото будут вынуты из требуемого устройства,либо по умолчанию из arhive.В случае указания Order будет записана цена из заказа, в противном случае - из БД. culture задает для какого языка будет создан XML/ NeedMapping вызовет форму маппинга. absolutePath = false - только имена файлов фото (иначе полные пути). foldertype - тип названия папки с фото: shot, ean13, hash
        ''' </summary>
        ''' <param name="SampleNumber"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function CreateCatalogSample(SampleNumber As Service.clsApplicationTypes.clsSampleNumber, foldertype As Service.clsApplicationTypes.emCatalogFolderType, Optional ImagesSource As clsFilesSources = Nothing, Optional ImageNamesFilter As String() = Nothing, Optional culture As System.Globalization.CultureInfo = Nothing, Optional version As String = "2", Optional NeedMapping As Boolean = False, Optional absolutePath As Boolean = False) As CATALOGSAMPLE
            '------------------------------------------------------------------------
            If ImagesSource Is Nothing Then
                ImagesSource = clsFilesSources.Arhive
            End If

            If ImagesSource.AllSources Then
                Debug.Fail("Для создания записи образца необходимо указать конкретное устройство, а не AllSources")
                ImagesSource = clsFilesSources.Arhive
            End If

            If culture Is Nothing Then
                culture = Service.clsApplicationTypes.EnglishCulture
            End If
            '------------------------------------------------------------------------
            If SampleNumber.HasExtendedInfo = False Then
                SampleNumber.GetExtendedInfo()
            End If
            '----------------------------------------
            If Not SamplePhotoObject.HasImages(SampleNumber, ImagesSource) AndAlso Not ImagesSource.Source = clsFilesSources.emSources.Arhive Then
                'копировать фотки
                Dim _res = SamplePhotoObject.CopyImagesFromSourceToSource(SampleNumber, clsFilesSources.Arhive, ImagesSource, False, , 1600)
                MsgBox("Скопировано " & _res & " фото в " & ImagesSource.ToString(), vbInformation)
            End If
            '-------------------------------
            Dim _CatalogSample = CATALOGSAMPLE.CreateInstance(SampleNumber.EAN13, foldertype)

            'загрузит из БД данные для него
            Dim _result As Integer
            Dim _sampleInfo As Service.tb_Samples_photo_data = clsApplicationTypes.SampleDataObject.GetSampleData(SampleNumber, _result)

            If Not _result = 1 Then
                'этих данных нет!!!!
                MsgBox("Данных для образца нет!", MsgBoxStyle.Critical)
                Return Nothing
            End If

            '------------------------------------------------------------------------
            '1. физические параметры образца и фоссилий
            'перебрать все записи о параметрах
            'параметры для всего образца - они одинаковы для всех фоссилий
            With _sampleInfo
                '---------------------------------------------------------------
                '1.1 номер образца
                'хеш исползуется для определения папки  на FTP
                Dim _hash = Math.Abs(SampleNumber.GetHashCode)
                Select Case culture.Name
                    Case clsApplicationTypes.RussianCulture.Name
                        _CatalogSample.AddDataElement("NUMBER", SampleNumber.ShotCode, CATALOGSAMPLEELEMENT.emPosition.down, "false", , , _hash)
                    Case clsApplicationTypes.EnglishCulture.Name
                        _CatalogSample.AddDataElement("NUMBER", SampleNumber.ShotCode, CATALOGSAMPLEELEMENT.emPosition.down, "false", , , _hash)
                    Case Else
                        Debug.Fail("operation for this culture name is missing")
                        _CatalogSample.AddDataElement("NUMBER", "", CATALOGSAMPLEELEMENT.emPosition.down, "", , , _hash)
                End Select


                '----------------------------------------------------------------
                '1.2 заголовок - название образца
                Select Case culture.Name
                    Case clsApplicationTypes.RussianCulture.Name
                        _CatalogSample.AddDataElement("NAME", .Sample_main_species, CATALOGSAMPLEELEMENT.emPosition.title, "Название", , , )
                    Case clsApplicationTypes.EnglishCulture.Name
                        _CatalogSample.AddDataElement("NAME", .Sample_main_species, CATALOGSAMPLEELEMENT.emPosition.title, "Specimen name", , , )
                    Case Else
                        Debug.Fail("operation for this culture name is missing")
                        _CatalogSample.AddDataElement("NAME", .Sample_main_species, CATALOGSAMPLEELEMENT.emPosition.title, "Specimen name", , , )
                End Select

                '--------------------------------------------------------------------
                '1.2.2 титул образца todo: найти титул
                'Dim _sourse As clsFilesSources

                'If IsNothing(OrderID) Then
                '    _sourse = clsFilesSources.CreateInstance(Service.clsApplicationTypes.clsFileSources.emSources.AllSources)
                'Else
                '    _sourse = clsFilesSources.CreateInstance(Service.clsApplicationTypes.clsFileSources.emSources.SpecificOrder, OrderID)
                'End If


                'Dim _title As String = Service.clsApplicationTypes.SamplePhotoObject.GetMainImageName(_sample, _sourse)
                'If _title.Length > 0 Then

                '    _CatalogSample.DATA(1) _
                '                .AddEnviropmentImage("image", "self", "div", "first-alt", _title)
                'End If


                '--------------------------------------------------------------------
                '1.2.3 описание происхождения todo: найти описание для главной объекта
                '------------------------------------------------------------------
                '1.3 размер матрикса
                If .Sample_length > 0 And .Sample_width > 0 Then
                    Dim _matrix As String = .Sample_length.ToString & "x" & .Sample_width
                    If Not .Sample_height = 0 Then
                        _matrix += "x" & .Sample_height
                    End If
                    Select Case culture.Name
                        Case clsApplicationTypes.RussianCulture.Name
                            _matrix += "см"
                            _CatalogSample.AddDataElement("MATRIXSIZE", _matrix, CATALOGSAMPLEELEMENT.emPosition.upperright, "Размер блока", , , )

                        Case clsApplicationTypes.EnglishCulture.Name
                            _matrix += "cm"
                            _CatalogSample.AddDataElement("MATRIXSIZE", _matrix, CATALOGSAMPLEELEMENT.emPosition.upperright, "Block size", , , )

                        Case Else
                            Debug.Fail("operation for this culture name is missing")
                            _matrix += "cm"
                            _CatalogSample.AddDataElement("MATRIXSIZE", _matrix, CATALOGSAMPLEELEMENT.emPosition.upperright, "Block size", , , )

                    End Select

                End If

                '-----------------------------------------------------------------
                '1.4 вес образца
                If .Sample_net_weight > 0 Then
                    Select Case culture.Name
                        Case clsApplicationTypes.RussianCulture.Name
                            _CatalogSample.AddDataElement("WEIGHT", .Sample_net_weight & "кг", CATALOGSAMPLEELEMENT.emPosition.upperright, "Вес образца", , , )
                        Case clsApplicationTypes.EnglishCulture.Name
                            _CatalogSample.AddDataElement("WEIGHT", .Sample_net_weight & "kg", CATALOGSAMPLEELEMENT.emPosition.upperright, "Net weight", , , )
                        Case Else
                            Debug.Fail("operation for this culture name is missing")
                            _CatalogSample.AddDataElement("WEIGHT", .Sample_net_weight & "kg", CATALOGSAMPLEELEMENT.emPosition.upperright, "Net weight", , , )
                    End Select

                End If
            End With
            '-----------------------------------------------------------------
            '1.5 размеры и названия фоссилий
            Dim _fossil1 = clsApplicationTypes.SampleDataObject.GetSampleData(SampleNumber)
            _fossil1.tb_Samples_Fossils.Load()
            Dim _index As Integer = 0

            For Each t In _fossil1.tb_Samples_Fossils
                Dim _text As String = ""
                Dim _fossilSizeText As String = ""
                _index += 1
                With t
                    'должна быть хотя бы длина фосилии
                    If .Fossil_length > 0 Then
                        '---------------
                        _fossilSizeText = .Fossil_length

                        If .Fossil_width > 0 Then
                            _fossilSizeText += "x" & .Fossil_width
                        End If

                        If .Fossil_height > 0 Then
                            _fossilSizeText += "x" & .Fossil_height
                        End If
                        '----------------
                        Select Case culture.Name
                            Case clsApplicationTypes.RussianCulture.Name
                                _fossilSizeText += "см"
                                _text = String.Format("[{1}]Размер {0}", clsApplicationTypes.FossilNamesParser({.Fossil_full_name.Trim}), IIf(t.FossilNumber.ToString.Length <= 2, t.FossilNumber.ToString, _index.ToString))
                            Case clsApplicationTypes.EnglishCulture.Name
                                _fossilSizeText += "cm"
                                _text = String.Format("[{1}]Size of {0}", clsApplicationTypes.FossilNamesParser({.Fossil_full_name.Trim}), IIf(t.FossilNumber.ToString.Length <= 2, t.FossilNumber.ToString, _index.ToString))

                            Case Else
                                Debug.Fail("operation for this culture name are missing")
                                _fossilSizeText += "cm"
                                _text = String.Format("[{1}]Size of {0}", clsApplicationTypes.FossilNamesParser({.Fossil_full_name.Trim}), IIf(t.FossilNumber.ToString.Length <= 2, t.FossilNumber.ToString, _index.ToString))
                        End Select
                        '----------
                        _CatalogSample.AddDataElement("FOSSILSIZE", _fossilSizeText, CATALOGSAMPLEELEMENT.emPosition.upperleft, _text, , , )
                    End If
                    _text = ""
                    _fossilSizeText = ""
                End With
            Next
            '---------------------------------------------------------------------------
            '1.9 описание образца
            Dim _result1 As Integer
            Dim _sons = clsApplicationTypes.SampleDataObject.GetSampleOnSale(SampleNumber, _result1)
            If _result1 > 0 Then
                With _sons
                    'новая версия с разобранным описанием 25.05.2013
                    'новая версия с маппингом от 02.02.2014
                    Dim _elements As List(Of CATALOGSAMPLEELEMENT)
                    Dim _status As Boolean
                    _elements = DescriptionParser(.Description, culture, _status)

                    If _status = True Then
                        For Each _elem In _elements
                            _CatalogSample.AddDataElement(_elem, PreserveOrder:=False)
                        Next
                    End If
                End With
            End If
            '---------------------------------------------------------------------------
            '----------------------------------------------------------------------
            ''1.6 местонахождение образца  todo: найти название локалити
            '------------------------------------------------------------------------
            '1.8 картинки
            'получить список изображений для образца
            ''по запросу выполняем вызов из сервиса
            'если делегата нет, то сервис недоступен
            'сервис зарегестрирован - вызываем
            'ссылка на фото будет получена в зависимости от требуемого устройства
            Dim _tmpsample = SampleNumber
            Dim _images As String()
            If absolutePath Then
                'имена файлов с путями
                If ImageNamesFilter Is Nothing Then
                    _images = Service.clsApplicationTypes.SamplePhotoObject.GetImagesURI(_tmpsample, ImagesSource).Select(Function(x) x.AbsolutePath).ToArray
                Else
                    _images = Service.clsApplicationTypes.SamplePhotoObject.GetImagesURI(_tmpsample, ImagesSource, ImageNamesFilter).Select(Function(x) x.AbsolutePath).ToArray
                End If
            Else
                'только имена файлов
                If ImageNamesFilter Is Nothing Then
                    _images = Service.clsApplicationTypes.SamplePhotoObject.GetImageNamesList(_tmpsample, ImagesSource)
                Else
                    _images = Service.clsApplicationTypes.SamplePhotoObject.GetImageNamesList(_tmpsample, ImagesSource).Intersect(ImageNamesFilter).ToArray
                End If
            End If


            For Each _tmp As String In _images
                _CatalogSample.AddSampleImage(_tmp, False)
            Next

            If absolutePath Then
                If Not _CatalogSample.IMAGES Is Nothing Then
                    _CatalogSample.IMAGES.titleimage = "absolute"
                End If

            Else
                If Not _CatalogSample.IMAGES Is Nothing Then
                    _CatalogSample.IMAGES.titleimage = "relative"
                End If
            End If

            '---------------------------------------------
            '1.7 цена образца 
            Dim _priceST, _discountST, _youpriceST As String
            Select Case culture.Name
                Case clsApplicationTypes.RussianCulture.Name
                    _priceST = "Цена"
                    _discountST = "Скидка"
                    _youpriceST = "Ваша цена с учетом скидки"
                Case clsApplicationTypes.EnglishCulture.Name
                    _priceST = "Price"
                    _discountST = "Discount"
                    _youpriceST = "Your price"

                Case Else
                    Debug.Fail("operation for this culture name is missing")
                    _priceST = "Price"
                    _discountST = "Discount"
                    _youpriceST = "Your price"
            End Select


            Select Case ImagesSource.Source
                Case Service.clsFilesSources.emSources.SpecificOrder
                    'пишем цену из заказа
                    _result = 0
                    Dim _order = clsApplicationTypes.SampleDataObject.GetSampleFinanceByOrder(SampleNumber, ImagesSource.Order, _result)
                    If _result = 1 Then
                        Dim _stringPrice As String
                        With _order
                            If .Price > 0 Then
                                _stringPrice = Decimal.Parse(.Price).ToString("C", Service.clsApplicationTypes.GetCultureByCurrency(.CurrencyName))
                                _CatalogSample.AddDataElement("PRICE", _stringPrice, CATALOGSAMPLEELEMENT.emPosition.down, _priceST, , , )

                                If .Discount > 0 Then
                                    '-----------------------------------
                                    '1.7.1 скидка
                                    _stringPrice = (.Discount * 0.01).ToString("0%")
                                    _CatalogSample.AddDataElement("DISCOUNT", _stringPrice, CATALOGSAMPLEELEMENT.emPosition.down, _discountST, , , )

                                    '-----------------------------------
                                    '1.7.2 you price
                                    Dim _youPrice As Decimal = .Price - (.Price * (.Discount * 0.01))
                                    _stringPrice = _youPrice.ToString("C", Service.clsApplicationTypes.GetCultureByCurrency(.CurrencyName))
                                    _CatalogSample.AddDataElement("YOUPRICE", _stringPrice, CATALOGSAMPLEELEMENT.emPosition.down, _youpriceST, , , )

                                End If
                            End If
                        End With
                    End If
                Case Else
                    'пишем цену из БД
                    If _result = 1 Then
                        Dim _stringPrice As String
                        With SampleNumber.GetExtendedInfo.Prices
                            If .BasePrice > 0 Then
                                _stringPrice = Decimal.Parse(.BasePrice).ToString("C", Service.clsApplicationTypes.GetCultureByCurrency(.Currency))
                                _CatalogSample.AddDataElement("PRICE", _stringPrice, CATALOGSAMPLEELEMENT.emPosition.down, _priceST, , , )

                                If .Discount > 0 Then
                                    '-----------------------------------
                                    '1.7.1 скидка
                                    _stringPrice = (.Discount * 0.01).ToString("0%")
                                    _CatalogSample.AddDataElement("DISCOUNT", _stringPrice, CATALOGSAMPLEELEMENT.emPosition.down, _discountST, , , )

                                    '-----------------------------------
                                    '1.7.2 you price
                                    Dim _youPrice As Decimal = .Price
                                    _stringPrice = _youPrice.ToString("C", Service.clsApplicationTypes.GetCultureByCurrency(.Currency))
                                    _CatalogSample.AddDataElement("YOUPRICE", _stringPrice, CATALOGSAMPLEELEMENT.emPosition.down, _youpriceST, , , )

                                End If
                            End If
                        End With
                    End If
            End Select
            '---------------------------------------------------------------------------
            'mapping
            If NeedMapping Then
                Dim _fm = _CatalogSample.GetMappingForm("")

                Dim _hdd = Sub(sender As Object, e As fmCreateMAP.clsCatalogSampleChangedEventArgs)
                               _CatalogSample = e.ChangedCatalogSample
                           End Sub
                AddHandler _fm.evAcceptChanges, _hdd
                _fm.ShowDialog()
            End If

            Return _CatalogSample
        End Function

        ''' <summary>
        ''' вернет строку шаблона (XSLT) заданного типа, или свободного типа по номеру. В случае отсутствия такового вернет пустую строку
        ''' </summary>
        ''' <param name="TemplateType"></param>
        ''' <param name="TemplateName"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetTemplate(TemplateType As emTemplateType, Optional TemplateName As String = "") As String
ex:
            Dim _path As String = ""
            Select Case TemplateType
                Case emTemplateType.ByName
                    If Not Me.oTemplates.ContainsKey(TemplateName) Then
                        Debug.Fail("данное имя отсутствует в списке шаблонов")
                        Return ""
                    End If
                    _path = IO.Path.Combine(clsApplicationTypes.TemplateFolderPath, Me.oTemplates(TemplateName))
                Case Else
                    _path = IO.Path.Combine(clsApplicationTypes.TemplateFolderPath, (Me.oTemplates(Me.GetTemplateNameByType(TemplateType))))
            End Select

            Try
                If IO.File.Exists(_path) Then
                    Return IO.File.ReadAllText(_path)
                End If
            Catch ex As Exception
                Debug.Fail(ex.Message)
                Return ""
            End Try

            Debug.Fail("Файл " & _path & " не существует")
            Return ""

        End Function

        Private oMaps As List(Of CATALOGELEMENTMAP)
        ''' <summary>
        ''' вернет первое слово. При наличии разделителей , или -> вернет перый узел
        ''' </summary>
        ''' <param name="input"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function GetFirstWord(input As String) As String
            If input = "" Then Return ""

            'проверка на наличие разделителей , ->
            Dim _result As String()

            input.Trim()
            '--------------
            _result = input.Split({"->"}, System.StringSplitOptions.RemoveEmptyEntries)
            If _result.Length > 1 Then
                'есть разделитель ->
                input = _result.First
                GoTo ex
            End If
            '------------
            _result = input.Split(",".ToCharArray, System.StringSplitOptions.RemoveEmptyEntries)
            If _result.Length > 1 Then
                'есть разделитель ,
                input = _result.First
                GoTo ex
            End If
            '----------------
            'нет разделителей
            _result = input.Split(" ".ToCharArray, System.StringSplitOptions.RemoveEmptyEntries)
            If _result.Length > 1 Then
                'есть разделитель пробел
                input = _result.First
                GoTo ex
            End If

            'Select Case _result.Length
            '    Case 0
            '        'нет разделителя
            '    Case 1
            '        'один разделитель
            '    Case Is >= 2
            '        Dim _out As String = _result.First
            '        'если нет скобок, вернем последнее имя
            '        '_result = input.Split("(".ToCharArray)
            '        'If _result.Length < 2 Then Return _out.Trim
            '        ''скобки есть
            '        ''случай ..,name(autor, 1903)
            '        'input = _result(_result.Count - 2) & "," & _result.Last
            '        GoTo ex
            'End Select
            '-------------

ex:
            ''убрать скобки
            '_result = input.Split("(".ToCharArray)
            'If _result.Length > 1 Then Return _result(0).Trim
            'скобок нет
            Return input.Trim
        End Function

        ''' <summary>
        ''' вернет все до первой скобки. При наличии разделителей , или -> вернет последний узел и отделит скобки
        ''' </summary>
        ''' <param name="input"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function ReplaceParenthesis(input As String) As String
            If input = "" Then Return ""

            'проверка на наличие разделителей , ->
            Dim _result As String()

            input.Trim()
            '--------------
            _result = input.Split("->".ToCharArray, System.StringSplitOptions.RemoveEmptyEntries)
            If _result.Length > 1 Then
                'есть разделитель ->
                input = _result.Last
                GoTo ex
            End If
            '------------
            _result = input.Split(",".ToCharArray, System.StringSplitOptions.RemoveEmptyEntries)
            Select Case _result.Length
                Case 0
                    'нет разделителя
                Case 1
                    'один разделитель
                Case Is >= 2
                    'больше двух разделителей
                    ' Dim _out As String = _result.Last

                    Dim _result2 = input.Split("()".ToCharArray)
                    'если нет скобок, вернем последнее имя (без скобок)
                    If _result2.Length < 3 Then Return _result.Last.Trim
                    'скобки есть
                    'случай ..,name(autor, 1903)
                    'input = _result2(0)
                    'GoTo ex
            End Select
            '-------------

ex:
            'убрать скобки
            _result = input.Split("()".ToCharArray)
            If _result.Length > 1 Then Return _result(0).Trim
            'скобок нет
            Return input.Trim
        End Function

        ''' <summary>
        ''' загрузка карт из XML
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function LoadMaps() As List(Of CATALOGELEMENTMAP)
            'read file
            Dim _path = IO.Path.Combine(clsApplicationTypes.TemplateFolderPath, My.Settings.MappingFileName)
            If IO.File.Exists(_path) Then
                'read template file
                Dim _s = IO.File.ReadAllText(_path)
                If _s.Length = 0 Then
                    MsgBox("012. в LoadMaps передана пустая строка")
                    Return New List(Of CATALOGELEMENTMAP)
                End If

                Dim _rdsett As New Xml.XmlReaderSettings
                Dim _xmlSerializer As Xml.Serialization.XmlSerializer = New Xml.Serialization.XmlSerializer(GetType(List(Of CATALOGELEMENTMAP)))
                Dim _xmlreader As Xml.XmlReader
                Dim _strBuilt As IO.StringReader


                ''schema
                'Dim _sh As New Xml.Schema.XmlSchema
                '_strBuilt = New IO.StringReader(My.Resources.XMLVisualCatalog)
                'Dim _xmlsh = New Xml.Schema.XmlSchemaSet()
                '_xmlsh.Add(Xml.Schema.XmlSchema.Read(_strBuilt, AddressOf ValidationEventHandler))

                'catalog
                _strBuilt = New IO.StringReader(_s)

                With _rdsett
                    .CloseInput = True
                    .IgnoreComments = True
                    '.Schemas = _xmlsh
                End With

                _xmlreader = Xml.XmlReader.Create(_strBuilt, _rdsett)
                oMaps = _xmlSerializer.Deserialize(_xmlreader)
                _xmlreader.Close()


            Else
                'create template file
                Me.oMaps = New List(Of CATALOGELEMENTMAP)
                Dim _map = CATALOGELEMENTMAP.CreateInstance("NWTrilobites.tree", "file:///z:\Schema2008-november_asery.gif", " Distribution of trilobites of St.petersburg district")
                Dim _over = CATALOGSAMPLEMAPOVERLAY.CreateInstance("602/1088", "file:///z:\arrow.png", CATALOGSAMPLEMAPOVERLAY.emOverlayType.arrow, True, 0.7, New Point(163, 482), New Size(40, 40), "asery horizone")
                _map.AddOverlay(_over)
                oMaps.Add(_map)
                _map = CATALOGELEMENTMAP.CreateInstance("NWTrilobites.tree-2", "file:///z:\Schema2008-november_ordovician_big.gif", " Test")
                oMaps.Add(_map)
            End If

            Return oMaps

        End Function


        Public Function SaveMaps(maps As List(Of CATALOGELEMENTMAP)) As Boolean
            oMaps = maps
            'save file
            Me.SaveMapFile()
            Return True
        End Function



        ' ''' <summary>
        ' ''' удаляет шаблон из списка. Но файл останется!
        ' ''' </summary>
        ' ''' <param name="Name"></param>
        ' ''' <returns></returns>
        ' ''' <remarks></remarks>
        'Public Function RemoveTemplate(Name As String) As Boolean
        '    If Me.oTemplates.ContainsKey(Name) Then
        '        Me.oTemplates.Remove(Name)
        '        Return True
        '    End If
        '    Return False
        'End Function

        ' ''' <summary>
        ' ''' путь к папке с шаблонами. При задании свойства переписывает соотв. поле в MySettings
        ' ''' </summary>
        ' ''' <value></value>
        ' ''' <returns></returns>
        ' ''' <remarks></remarks>
        'Private Property TemplatePath As String
        '    Get
        '        Return oCurrentPath
        '    End Get
        '    Set(ByVal value As String)
        '        Debug.Assert(IO.Directory.Exists(value), "А директория должна быть установлена существующая!!")
        '        '---------------------------------
        '        oCurrentPath = value
        '    End Set
        'End Property
        ''' <summary>
        ''' вернет список названий шаблонов
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property TemplateNamesList As List(Of String)
            Get

                Return Me.oTemplates.Keys
            End Get
        End Property

        ''' <summary>
        ''' создает файл с xml (html) данными по заданому пути
        ''' </summary>
        ''' <param name="FullPath"></param>
        ''' <param name="xmlData"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function WriteFile(ByVal FullPath As String, xmldata As String) As Boolean
            If xmldata = "" Then Return False
            Try
                Dim _dir = IO.Path.GetDirectoryName(FullPath)

                If Not IO.Directory.Exists(_dir) Then
                    IO.Directory.CreateDirectory(_dir)
                End If
            Catch ex As Exception
                MsgBox("014. по указанному пути запись файла не возможна")
                Return False
            End Try

            Try

                'My.Computer.FileSystem.WriteAllText(FullPath, xmldata, False, System.Text.Encoding.GetEncoding("windows-1251"))
                Using _writer As New IO.StreamWriter(FullPath, False, System.Text.Encoding.GetEncoding("windows-1251"))
                    _writer.Write(xmldata)
                    _writer.Flush()
                End Using
                Return True
            Catch ex As Exception
                MsgBox("013. Файл не может быть записан. Повторите попытку.", MsgBoxStyle.Critical)
                Return False
            End Try
        End Function
        ''' <summary>
        ''' вернет преобразованный xml. Для выбора по имени выбрать тип ByName
        ''' </summary>
        ''' <param name="TemplateType"></param>
        ''' <param name="Name"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overloads Function GetTransform(ByRef XMLData As String, TemplateType As emTemplateType, Optional Name As String = "") As String
            If XMLData = "" Then Return ""
            Dim _xslt = Me.GetTemplate(TemplateType, Name)
            Return Me.GetTransform(_xslt, XMLData)
        End Function

        ''' <summary>
        ''' преобразует данные XML используя шаблон XSLT. Вернет результат преобразования
        ''' </summary>
        ''' <param name="XSLT"></param>
        ''' <param name="XMLData"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Overloads Function GetTransform(ByVal XSLT As String, ByRef XMLData As String) As String
            'xslt transform block
            'Create a new XslTransform object.
            Dim _xslt As New Xml.Xsl.XslCompiledTransform
            Dim _strreader As IO.StringReader
            Dim _xsl_reader As Xml.XmlReader
            Dim _xmlReader As Xml.XmlReader = Xml.XmlReader.Create(New IO.StringReader(XMLData))
            Dim _wrsett As New Xml.XmlWriterSettings
            Dim _xmlwriter As Xml.XmlWriter
            Dim _strBuilt As New System.Text.StringBuilder

            With _wrsett
                .Encoding = System.Text.Encoding.GetEncoding("windows-1251")
                .Indent = True
                .ConformanceLevel = Xml.ConformanceLevel.Auto
            End With

            Try
                _xmlwriter = Xml.XmlWriter.Create(_strBuilt, _wrsett)
                '-----------------
                'шаблон XSLTString

                Dim _xsltSettings As Xml.Xsl.XsltSettings = Xml.Xsl.XsltSettings.TrustedXslt
                Dim resolver As New Xml.XmlUrlResolver()
                _strreader = New IO.StringReader(XSLT)
                _xsl_reader = Xml.XmlReader.Create(_strreader)
                _xslt.Load(_xsl_reader, _xsltSettings, resolver)

                'трансформация
                Try
                    _xslt.Transform(_xmlReader, _xmlwriter)
                Catch ex As Exception
                    MsgBox("015. Ошибка преобразования документа (шаблон xslt): " & ex.Message, vbCritical)
                    _xmlwriter.Flush()
                    _xmlwriter.Close()
                    _xsl_reader.Close()
                    _strreader.Close()
                    Return ""
                End Try
                _xmlwriter.Flush()
                _xmlwriter.Close()
                _xsl_reader.Close()
                _strreader.Close()
            Catch ex As Exception
                MsgBox("016. Преобразование XSLT невозможно. Ошибка: " & ex.Message, vbCritical)
                '_xmlwriter.Flush()
                '_xmlwriter.Close()
                '_xsl_reader.Close()
                '_strreader.Close()
                Return ""
            End Try


            Return _strBuilt.ToString
        End Function
        ''' <summary>
        ''' загружает имадж из сети0)
        ''' </summary>
        ''' <param name="ImageURI"></param>
        ''' <param name="status"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Shared Function loadHttpImage(ImageURI As Uri, ByRef status As Integer) As Uri
            Dim _path = My.Computer.FileSystem.GetTempFileName
            Dim _uri As New Uri(_path, System.UriKind.Absolute)
            Try
                Using _cl As New Net.WebClient
                    _cl.DownloadFile(ImageURI, _path)
                End Using
                status = 1
            Catch ex As Exception
                status = -1
            End Try

            Return _uri
            'Throw New NotImplementedException
        End Function

    End Class
End Namespace
