Imports System.Drawing
Imports Service
Imports Service.clsApplicationTypes
Imports Service.Catalog
Imports System.Linq
Imports System.Xml.Linq
Namespace Catalog



    Partial Public Class clsTemplateManager

        Private oCurrentPath As String
        Private oTemplates As clsTemplates

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
            '        TIMESCALE =geological age(Возраст)
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
                Dim _descrsuffics = "DESCR"

                Dim _orderPos As Integer = 1
                Dim _tmpitag As Integer = 0
                'делаем element
                Select Case _descrELEMENT.@name.ToLower

                    Case "systematica", "devonian"
                        'СИСТЕМАТИКА
                        _value = ParseNodeXML(_descrELEMENT, "-> ", False)
                        _orderPos = 1
                        If culture.Name.Equals(clsApplicationTypes.RussianCulture.Name) Then
                            _element = CATALOGSAMPLEELEMENT.CreateDataElement("SYSTEMATICA", _value, CATALOGSAMPLEELEMENT.emPosition.down, "Систематика", , , , _orderPos)
                        Else
                            _element = CATALOGSAMPLEELEMENT.CreateDataElement("SYSTEMATICA", _value, CATALOGSAMPLEELEMENT.emPosition.down, "Systematica", , , , _orderPos)
                        End If
                        If Not _element Is Nothing Then
                            _out.Add(_element)
                            'описание оконечного тега
                            If _descrELEMENT.<NODE>.Last.<DESCRIPTION>.Count > 0 Then
                                Dim _valueTagDesc As String = ""
                                For Each t In _descrELEMENT.<NODE>.Last.<DESCRIPTION>
                                    _valueTagDesc += t.Value
                                Next
                                _element = CATALOGSAMPLEELEMENT.CreateDataElement("SYSTEMATICA" & _descrsuffics, _valueTagDesc, CATALOGSAMPLEELEMENT.emPosition.info, "", , , , _orderPos)
                                If Not _element Is Nothing Then
                                    _out.Add(_element)
                                End If
                            End If
                        End If

                    Case "timescale", "age", "geological age"
                        'ВОЗРАСТ
                        _orderPos = 2
                        _value = ParseNodeXML(_descrELEMENT, "-> ", False)
                        If culture.Name.Equals(clsApplicationTypes.RussianCulture.Name) Then
                            _element = CATALOGSAMPLEELEMENT.CreateDataElement("TIMESCALE", _value, CATALOGSAMPLEELEMENT.emPosition.down, "Возраст", , , , _orderPos)

                        Else
                            _element = CATALOGSAMPLEELEMENT.CreateDataElement("TIMESCALE", _value, CATALOGSAMPLEELEMENT.emPosition.down, "Geological age", , , , _orderPos)

                        End If
                        If Not _element Is Nothing Then
                            _out.Add(_element)
                            'описание оконечного тега
                            If _descrELEMENT.<NODE>.Last.<DESCRIPTION>.Count > 0 Then
                                Dim _valueTagDesc As String = ""
                                For Each t In _descrELEMENT.<NODE>.Last.<DESCRIPTION>
                                    _valueTagDesc += t.Value
                                Next
                                _element = CATALOGSAMPLEELEMENT.CreateDataElement("TIMESCALE" & _descrsuffics, _valueTagDesc, CATALOGSAMPLEELEMENT.emPosition.info, "", , , , _orderPos)
                                If Not _element Is Nothing Then
                                    _out.Add(_element)
                                End If
                            End If

                        End If

                    Case "locality", "localities"
                        'МЕСТОНАХОЖДЕНИЕ
                        _orderPos = 4
                        _value = ParseNodeXML(_descrELEMENT, ", ", False)
                        If culture.Name.Equals(clsApplicationTypes.RussianCulture.Name) Then
                            _element = CATALOGSAMPLEELEMENT.CreateDataElement("LOCALITY", _value, CATALOGSAMPLEELEMENT.emPosition.down, "Местонахождение", , , , _orderPos)

                        Else
                            _element = CATALOGSAMPLEELEMENT.CreateDataElement("LOCALITY", _value, CATALOGSAMPLEELEMENT.emPosition.down, "Locality", , , , _orderPos)

                        End If
                        If Not _element Is Nothing Then
                            _out.Add(_element)
                            'описание оконечного тега
                            If _descrELEMENT.<NODE>.Last.<DESCRIPTION>.Count > 0 Then
                                Dim _valueTagDesc As String = ""
                                For Each t In _descrELEMENT.<NODE>.Last.<DESCRIPTION>
                                    _valueTagDesc += t.Value
                                Next
                                _element = CATALOGSAMPLEELEMENT.CreateDataElement("LOCALITY" & _descrsuffics, _valueTagDesc, CATALOGSAMPLEELEMENT.emPosition.info, "", , , , _orderPos)
                                If Not _element Is Nothing Then
                                    _out.Add(_element)
                                End If
                            End If

                        End If


                    Case "stratigraphy", "geology"
                        'СТРАТИГРАФИЯ
                        _orderPos = 3
                        _value = ParseNodeXML(_descrELEMENT, "-> ", False)
                        If culture.Name.Equals(clsApplicationTypes.RussianCulture.Name) Then
                            _element = CATALOGSAMPLEELEMENT.CreateDataElement("STRATIGRAPHY", _value, CATALOGSAMPLEELEMENT.emPosition.down, "Стратиграфия", , , , _orderPos)

                        Else
                            _element = CATALOGSAMPLEELEMENT.CreateDataElement("STRATIGRAPHY", _value, CATALOGSAMPLEELEMENT.emPosition.down, "Stratigraphy", , , , _orderPos)

                        End If
                        If Not _element Is Nothing Then
                            _out.Add(_element)

                            'описание оконечного тега
                            If _descrELEMENT.<NODE>.Last.<DESCRIPTION>.Count > 0 Then
                                Dim _valueTagDesc As String = ""
                                For Each t In _descrELEMENT.<NODE>.Last.<DESCRIPTION>
                                    _valueTagDesc += t.Value
                                Next
                                _element = CATALOGSAMPLEELEMENT.CreateDataElement("STRATIGRAPHY" & _descrsuffics, _valueTagDesc, CATALOGSAMPLEELEMENT.emPosition.info, "", , , , _orderPos)
                                If Not _element Is Nothing Then
                                    _out.Add(_element)
                                End If
                            End If

                        End If


                    Case "item", "ITEM"
                        'описание вручную собственно образца
                        _orderPos = 1
                        _value = ParseNodeXML(_descrELEMENT, ", ", False)
                        If culture.Name.Equals(clsApplicationTypes.RussianCulture.Name) Then
                            _element = CATALOGSAMPLEELEMENT.CreateDataElement("ITEM", _value, CATALOGSAMPLEELEMENT.emPosition.title, _rootName, , , , _orderPos)

                        Else
                            _element = CATALOGSAMPLEELEMENT.CreateDataElement("ITEM", _value, CATALOGSAMPLEELEMENT.emPosition.title, _rootName, , , , _orderPos)

                        End If
                        If Not _element Is Nothing Then
                            _out.Add(_element)
                            'описание оконечного тега - старый вариант - <DESCRIPTION>
                            If _descrELEMENT.<NODE>.Last.<DESCRIPTION>.Count > 0 Then
                                Dim _valueTagDesc As String = ""
                                For Each t In _descrELEMENT.<NODE>.Last.<DESCRIPTION>
                                    _valueTagDesc += t.Value
                                Next
                                _element = CATALOGSAMPLEELEMENT.CreateDataElement("ITEM" & _descrsuffics, _valueTagDesc, CATALOGSAMPLEELEMENT.emPosition.down, "", , , , _orderPos)
                                If Not _element Is Nothing Then
                                    _out.Add(_element)
                                End If
                            End If

                        End If

                    Case Else
                        _orderPos = 1
                        Dim _tagName As String = _descrELEMENT.@name.ToLower
                        'для других значений (ИМЯ ТЕГА БУДЕТ В НИЖНЕМ РЕГИСТРЕ!!! ДЛЯ ОТЛИЧИЯ НЕОБРАБОТАННЫХ ТЕГОВ)
                        _value = ParseNodeXML(_descrELEMENT, ", ", False)
                        _element = CATALOGSAMPLEELEMENT.CreateDataElement(_tagName, _value, CATALOGSAMPLEELEMENT.emPosition.info, _rootName, , , , _orderPos)
                        If Not _element Is Nothing Then
                            _out.Add(_element)
                            'описание (блок description) основного узла
                            If _descrELEMENT.<NODE>.Last.<DESCRIPTION>.Count > 0 Then
                                Dim _valueTagDesc As String = ""
                                For Each t In _descrELEMENT.<NODE>.Last.<DESCRIPTION>
                                    _valueTagDesc += t.Value
                                Next
                                _element = CATALOGSAMPLEELEMENT.CreateDataElement(_tagName & _descrsuffics, _valueTagDesc, CATALOGSAMPLEELEMENT.emPosition.info, "", , , , _orderPos)
                                If Not _element Is Nothing Then
                                    _out.Add(_element)

                                End If
                            End If

                        End If
                End Select
            Next

            status = True
            Return _out
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
