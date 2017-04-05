Imports PDFLibNet
Imports System.Drawing
Imports System.Collections.Generic
Imports System.Text
Imports System.Linq
Imports System.Xml.Linq
Imports Service
Imports Service.clsApplicationTypes



Public Class clsTreeService
    Implements iMyTreesDataProvider

    ''' <summary>
    ''' возвращает строку с данными образца по номеру/ status (-1) - error, (0) - data of sample is abscent, (1) - data present, (2) - full data present
    ''' </summary>
    ''' <param name="SampleNumber"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetSampleInfoText(SampleNumber As Service.clsApplicationTypes.clsSampleNumber, culture As System.Globalization.CultureInfo, ByRef _status As Integer) As String
        Debug.Assert(Not SampleNumber Is Nothing, "Передан пустой номер образца!")
        If SampleNumber Is Nothing Then Return ""
        'заполняем адаптеры
        Dim _SampleMainName As String = ""
        Dim _out As String = ""
        'по проверке заполнения всех столбцов образца
        Const _cnsStatusSampleDataComplete As String = "Полнота данных образца"
        'по проверке заполнения всех столбцов фоссилий
        Const _cnsStatusFossilDataComplete As String = "Полнота данных фоссилий"
        Const _cnsStatusSampleData As String = "Данные образца"
        Const _cnsStatusFossilData As String = "Данные фоссилий"

        'коллекция с данными заполнения образца
        Dim _infoStatus As New Collections.Generic.Dictionary(Of String, Boolean)

        Dim _result As Integer

        'фото БД
        _result = 0
        Dim _dbReadyData = Service.clsApplicationTypes.SampleDataObject.GetSampleData(SampleNumber, _result)
        If _result > 0 Then
            'проверка заполнения всех необходимых полей
            Dim _flagComplete As Boolean = True
            With _dbReadyData
                If .Sample_main_species = "" Then
                    _flagComplete = False
                Else
                    _SampleMainName = .Sample_main_species
                    _out += SampleNumber.ShotCode & " "
                    _out += .Sample_main_species & " " & Chr(13)
                End If

                If .Sample_length = 0 Then
                    _flagComplete = False
                Else
                    Select Case culture.Name
                        Case clsApplicationTypes.RussianCulture.Name
                            _out += "Размер блока: " & .Sample_length.ToString & "x"
                        Case clsApplicationTypes.EnglishCulture.Name
                            _out += "Stone size: " & .Sample_length.ToString & "x"
                        Case Else
                            Debug.Fail("operation for this culture name is missing")
                            _out += "Stone size: " & .Sample_length.ToString & "x"
                    End Select
                End If

                If .Sample_width = 0 Then
                    _flagComplete = False
                Else
                    Select Case culture.Name
                        Case clsApplicationTypes.RussianCulture.Name
                            _out += .Sample_width.ToString & "см; "
                        Case clsApplicationTypes.EnglishCulture.Name
                            _out += .Sample_width.ToString & "cm; "
                        Case Else
                            Debug.Fail("operation for this culture name is missing")
                            _out += .Sample_width.ToString & "cm; "
                    End Select
                End If

                If .Sample_net_weight = 0 Then
                    _flagComplete = False
                Else

                    Select Case culture.Name
                        Case clsApplicationTypes.RussianCulture.Name
                            _out += "Вес " & .Sample_net_weight.ToString & "кг;"
                        Case clsApplicationTypes.EnglishCulture.Name
                            _out += "Weight " & .Sample_net_weight.ToString & "kg;"
                        Case Else
                            Debug.Fail("operation for this culture name is missing")
                            _out += "Weight " & .Sample_net_weight.ToString & "kg;"
                    End Select


                End If
            End With
            _infoStatus.Add(_cnsStatusSampleDataComplete, _flagComplete)

            '--------load fossils
            _dbReadyData.tb_Samples_Fossils.Load()
            If _dbReadyData.tb_Samples_Fossils.Count = 0 Then
                ''данные о фоссилиях отсутствуют
                _infoStatus.Add(_cnsStatusFossilData, False)
            Else
                _infoStatus.Add(_cnsStatusFossilData, True)
                'проверка заполнения всех необходимых полей
                _flagComplete = True
                Dim _index As Integer = 1
                Select Case culture.Name
                    Case clsApplicationTypes.RussianCulture.Name
                        _out += " объектов на блоке: "
                    Case clsApplicationTypes.EnglishCulture.Name
                        _out += " Objects: "
                    Case Else
                        Debug.Fail("operation for this culture name is missing")
                        _out += " Objects: "
                End Select
                For Each _fs In _dbReadyData.tb_Samples_Fossils
                    With _fs
                        If .Fossil_full_name = "" Then
                            _flagComplete = False
                        Else
                            Select Case culture.Name
                                Case clsApplicationTypes.RussianCulture.Name
                                    _out += "(" & _index.ToString & ")" & "название: " + .Fossil_full_name + ","
                                Case clsApplicationTypes.EnglishCulture.Name
                                    _out += "(" & _index.ToString & ")" & "name: " + .Fossil_full_name + ","
                                Case Else
                                    Debug.Fail("operation for this culture name is missing")
                                    _out += "(" & _index.ToString & ")" & "name: " + .Fossil_full_name + ","
                            End Select
                        End If

                        If .Fossil_length = 0 Then
                            _flagComplete = False
                        Else
                            Dim _ffd = Function() As String
                                           Dim _res As String = ""
                                           If (Not IsDBNull(.Fossil_length)) AndAlso .Fossil_length > 0 Then
                                               _res = .Fossil_length.ToString
                                           End If
                                           If (Not IsDBNull(.Fossil_width)) AndAlso .Fossil_width > 0 Then
                                               _res += "X" & .Fossil_width.ToString
                                           End If

                                           If (Not IsDBNull(.Fossil_height)) AndAlso .Fossil_height > 0 Then
                                               _res += "X" & .Fossil_width.ToString
                                           End If
                                           Return _res
                                       End Function

                            Dim _ffdResult = _ffd()

                            If Not _ffdResult = "" Then
                                Select Case culture.Name
                                    Case clsApplicationTypes.RussianCulture.Name
                                        _out += " размер: " + _ffdResult + ";"
                                    Case clsApplicationTypes.EnglishCulture.Name
                                        _out += " size: " + _ffdResult + ";"
                                    Case Else
                                        Debug.Fail("operation for this culture name is missing")
                                        _out += " size: " + _ffdResult + ";"
                                End Select
                            End If
                        End If
                    End With
                Next
                _infoStatus.Add(_cnsStatusFossilDataComplete, _flagComplete)
            End If
            '---------------
            '---------------load description
            _result = 0
            Dim _sinfo = Service.clsApplicationTypes.SampleDataObject.GetSampleOnSale(SampleNumber, _result)
            If _result > 0 Then
                _out += Chr(13)
                _out += ParseDescriptionXML(culture, _sinfo.Description, _status)
                _infoStatus.Add(_sinfo.Description, _status)
            End If

            If _infoStatus.ContainsValue(False) Then
                'данные об образце не полные
                _status = 1
            Else
                'данные полные
                _status = 2
            End If
            Return _out
        Else
            'данных dbReadyData нет
            ''данных образца нет
            _infoStatus.Add(_cnsStatusSampleData, False)
            _status = 0
            Return "Данных для образца нет"
            '----> EXIT
        End If


    End Function


    ''' <summary>
    ''' передать наружу событие обновления описания
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub DescriptionAcceptfmDescription_EventHandler(ByVal sender As Object, ByVal e As clsTreeService.DescriptionAcceptEventArg)
        RaiseEvent DescriptionAccepted(Me, e)
    End Sub

    Friend Class NodeCreatedEventArg
        Inherits EventArgs
        Friend Property NewNode As NodeObject
    End Class

    Public Class AddLabelToPrintEventArg
        Inherits EventArgs
        Friend Property Node As NodeObject
        Friend Property Image As Image
    End Class

    Public Class DescriptionAcceptEventArg
        Inherits EventArgs
        Friend Property Culture As System.Globalization.CultureInfo
        Public Property DescriptionXelements As XElement
        ''' <summary>
        ''' вернет строку описания полностью, для интернета
        ''' </summary>
        ''' <param name="needculture"></param>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property DescriptionString(Optional needculture As Globalization.CultureInfo = Nothing) As String
            Get
                If needculture Is Nothing Then
                    If Culture Is Nothing Then
                        needculture = My.Computer.Info.InstalledUICulture
                    Else
                        Return clsTreeService.ParseDescriptionXML(Culture, DescriptionXelements)
                    End If
                End If

                Return clsTreeService.ParseDescriptionXML(Culture, DescriptionXelements)
            End Get
        End Property





        Friend Sub New(description As XElement, culture As System.Globalization.CultureInfo)
            Me.DescriptionXelements = description
            Me.Culture = culture
        End Sub
    End Class



    ''' <summary>
    ''' обькт-элемент описания
    ''' </summary>
    ''' <remarks></remarks>
    Public Class clsDescriptionElement
        Implements IComparable
        Implements IComparable(Of clsDescriptionElement)
        Implements IComparer
        Implements IComparer(Of clsDescriptionElement)

        ''' <summary>
        ''' коллекция тегов Node
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Friend Property NodeCollection As List(Of XElement)
        ''' <summary>
        ''' имя файла, кому пренадлежит элемент = значение тега filename
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property FileName As String
        ''' <summary>
        ''' имя дерева = тег name
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Name As String
        ''' <summary>
        ''' значение корневого узла дерева = тег root
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Friend Property Root As String

        ''' <summary>
        ''' id узла в дереве
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Friend Property ID As Integer
        ''' <summary>
        ''' язык элемента описания
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Culture As System.Globalization.CultureInfo

        Private Sub New()

        End Sub
        ''' <summary>
        ''' текстовое значение значение последнего тега NODE
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Value As String
            Get
                Dim _res = (From c In NodeCollection.Last.Nodes Where c.NodeType = Xml.XmlNodeType.Text Select CType(c, XText)).FirstOrDefault
                Return _res.Value
            End Get
            Set(value As String)
                NodeCollection.Last.Value = value
            End Set
        End Property

        ''' <summary>
        ''' вернет id последнего тега Node
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property LastNodeID As Integer
            Get
                Dim _result As Integer
                If Integer.TryParse(NodeCollection.Last.@nodeid, _result) Then
                    Return _result
                End If
                Return 0
            End Get
        End Property


        ''' <summary>
        ''' вернет строку описания для элемента описания
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property Description As String
            Get
                Dim _xml As XElement = <DATA>

                                       </DATA>
                _xml.Add(Me.GetXElement)
                Dim _out = clsTreeService.ParseDescriptionXML(Culture, _xml)
                Return _out
            End Get
        End Property


        ''' <summary>
        ''' имя элемента
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property ElementName As String
            Get
                Return Root
            End Get
        End Property

        ''' <summary>
        ''' xml представление элемента
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Friend Function GetXElement() As XElement
            Dim _xml As XElement = <ELEMENT filename=<%= Me.FileName %> name=<%= Me.Name %> root=<%= Me.Root %> lang=<%= Me.Culture.Name %> id=<%= Me.ID %>>

                                   </ELEMENT>
            _xml.Add(NodeCollection)

            Return _xml

        End Function
        ''' <summary>
        '''  создает элемент из xElement описания
        ''' </summary>
        ''' <param name="xml"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Friend Overloads Shared Function CreateInstance(xml As XElement) As clsDescriptionElement
            Debug.Assert(xml.Name = "ELEMENT", "Требуется корневой тег ELEMENT")
            If Not xml.Name = "ELEMENT" Then
                Return Nothing
            End If
            '--------xml-parcer---------
            Dim _new As New clsDescriptionElement
            With _new
                .FileName = xml.@filename
                .Name = xml.@name
                .Root = xml.@root
                .ID = xml.@id
                .Culture = System.Globalization.CultureInfo.CreateSpecificCulture(xml.@lang)
                .NodeCollection = (From c In xml...<NODE> Select c).ToList
            End With
            Return _new
        End Function

        ''' <summary>
        ''' вернет значения текстовых узлов узлов NODE
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property NodeValuesCollection As List(Of String)
            Get
                Dim _list As New List(Of String)

                Dim _res = (From c In Me.NodeCollection From d In c.Nodes Where d.NodeType = Xml.XmlNodeType.Text Select CType(d, XText).Value).ToList

                Return _res
            End Get
        End Property

        ''' <summary>
        '''  создает элемент из произвольных значений
        ''' </summary>
        ''' <param name="BlockName"> Название группы деревьев, например, Аммониты (берется из названия файла Аммониты.tree)</param>
        ''' <param name="SystemTreeName">Имя дерева в системе (англ) = корневой узел</param>
        ''' <param name="CultureTreeName">Имя дерева в культуре culture </param>
        ''' <param name="culture"></param>
        ''' <param name="NodeCollection">коллекция узлов вверх по дереву до корня</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Friend Overloads Shared Function CreateInstance(Nodeid As Integer, BlockName As String, SystemTreeName As String, CultureTreeName As String, culture As System.Globalization.CultureInfo, NodeCollection As List(Of XElement)) As clsDescriptionElement
            Dim _new As New clsDescriptionElement
            With _new
                .ID = Nodeid
                .FileName = BlockName
                .Name = SystemTreeName
                .Root = CultureTreeName
                .Culture = culture
                .NodeCollection = NodeCollection
            End With
            Return _new
        End Function
        ''' <summary>
        ''' создает элемент только с одним тегом NODE, Или без него, если FirstNodeValue=""
        ''' </summary>
        ''' <param name="FirstNodeValue"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overloads Shared Function CreateInstance(Nodeid As Integer, BlockName As String, SystemTreeName As String, CultureTreeName As String, culture As System.Globalization.CultureInfo, FirstNodeValue As String) As clsDescriptionElement
            Dim _out = New List(Of XElement)

            If Not FirstNodeValue = "" Then
                _out.Add(CreateInnerNode(FirstNodeValue, 1))
            End If

            Return CreateInstance(Nodeid, BlockName, SystemTreeName, CultureTreeName, culture, _out)
        End Function

        Private Shared Function CreateInnerNode(NodeValue As String, Optional order As Integer = 0) As XElement
            Dim _xmlNode As XElement = <NODE order=<%= 1 %>>
                                           <%= NodeValue %>
                                       </NODE>
            Return _xmlNode
        End Function




        ''' <summary>
        ''' создаст из себя обьект для отображения на этикетке/ newvalue перезапишет полное значение элемента
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function CreateLabelInfoObject(Optional newvalue As String = "") As clsLabelInfo
            Dim _new = clsLabelInfo.CreateInstance(Me.LastNodeID, Me.Culture, Me.FileName, Me.Name, Me.Root)
            If Not newvalue = "" Then
                'запишем переданное значение
                _new.Value = newvalue
            Else
                'по умолчанию вкатаем полное описание
                _new.Value = clsApplicationTypes.ParseNodeXML(Me.GetXElement, ", ", False)
            End If
            Return _new
        End Function

        ''' <summary>
        ''' вычислит ID labelinfo для проверки в базе
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function CalculateLabelInfoID() As Integer
            Return clsLabelInfo.CalculateID(Me.LastNodeID, Me.FileName, Me.Name, Me.Culture.Name)
        End Function


        Public Overrides Function ToString() As String
            Return Me.Root & ": " & Me.Value
        End Function

        Public Overrides Function Equals(obj As Object) As Boolean
            If Not TypeOf obj Is clsDescriptionElement Then Return False
            Dim _tmp = CType(obj, clsDescriptionElement)
            If Not _tmp.ID = Me.ID Then Return False
            If Not _tmp.FileName = Me.FileName Then Return False
            If Not _tmp.Name = Me.Name Then Return False
            If Not _tmp.Root = Me.Root Then Return False
            If Not _tmp.Value = Me.Value Then Return False
            Return True
        End Function





        Public Overrides Function GetHashCode() As Integer
            Return Me.ID.GetHashCode Xor Me.FileName.GetHashCode Xor Me.Name.GetHashCode Xor Me.Root.GetHashCode Xor Me.Value.GetHashCode
        End Function

        Private Function xCompareTo(obj As Object) As Integer Implements System.IComparable.CompareTo
            If Not TypeOf obj Is clsDescriptionElement Then Return 0
            Return CompareTo(obj)
        End Function

        Public Function CompareTo(other As clsDescriptionElement) As Integer Implements System.IComparable(Of clsDescriptionElement).CompareTo
            Return Compare(Me, other)
        End Function

        Private Function xCompare(x As Object, y As Object) As Integer Implements System.Collections.IComparer.Compare
            If Not TypeOf x Is clsDescriptionElement Then Return 0
            If Not TypeOf y Is clsDescriptionElement Then Return 0
            Return Compare(x, y)
        End Function

        Public Function Compare(x As clsDescriptionElement, y As clsDescriptionElement) As Integer Implements System.Collections.Generic.IComparer(Of clsDescriptionElement).Compare
            Return x.Name.CompareTo(y.Name)
        End Function
    End Class



    ''' <summary>
    ''' добавит в описание элементы
    ''' </summary>
    ''' <param name="xml"></param>
    ''' <param name="DescriptionElementCollection"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function AddElementToDescription(xml As XElement, DescriptionElementCollection As Trilbone.clsTreeService.clsDescriptionElement()) As XElement
        If DescriptionElementCollection Is Nothing OrElse DescriptionElementCollection.Count = 0 Then Return xml
        For Each t In DescriptionElementCollection
            xml.Add(t.GetXElement)
        Next
        Return xml
    End Function


    ''' <summary>
    ''' обьеденит два элемента описания. xml1 может быть NOTHING. 
    ''' </summary>
    ''' <param name="xml1"></param>
    ''' <param name="xml2"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function JoinDescriptionElements(xml1 As XElement, xml2 As XElement, Optional ByRef _status As Integer = 0) As XElement
        'xml2 не может быть пустым
        Debug.Assert(Not xml2 Is Nothing, "xml2 не может быть пустым")
        If xml2 Is Nothing Then _status = -1 : Return Nothing

        Dim _out As XElement

        If xml1 Is Nothing Then
            'xml1 = nothing, вернуть xml2
            _out = xml2
        Else
            'сцепить xml1 и xml2 
            _out = xml1
            'надо добавлять теги после одинаковых
            Dim _elemInXML2Coll = xml2...<ELEMENT>
            Dim _elemInXML1Coll = xml1...<ELEMENT>
            For Each _elemXML2 In _elemInXML2Coll
                Dim c2 = _elemXML2
                Dim _elemFoundInXML1 = (From c In _elemInXML1Coll Where c.@name = c2.@name Select c).LastOrDefault
                If Not _elemFoundInXML1 Is Nothing Then
                    'найден одинаковый ELEMENT
                    If Not _out.Element(_elemFoundInXML1.Name) Is Nothing Then
                        _out.Element(_elemFoundInXML1.Name).AddAfterSelf(_elemXML2)
                    End If
                    '_elemFoundInXML1.AddAfterSelf(_elemXML2)
                Else
                    _out.Add(_elemXML2)
                End If
            Next

        End If
        _status = 1
        '#If DEBUG Then
        '        MsgBox(_out.ToString, vbInformation)
        '#End If
        Return _out
    End Function
    ' ''' <summary>
    ' ''' вернет последнее значение узла
    ' ''' </summary>
    ' ''' <param name="xml"></param>
    ' ''' <returns></returns>
    ' ''' <remarks></remarks>
    'Friend Shared Function ParseNodeXMLForLabel(xml As XElement) As String
    '    Dim _out As New List(Of String)
    '    For Each nd In xml...<NODE>
    '        _out.Add(nd.FirstNode.ToString)
    '    Next
    '    Return _out.Last
    'End Function


   

    ' ''' <summary>
    ' ''' разберет текстовое выражение в обьект XElement. Status -1 = ошибка
    ' ''' </summary>
    ' ''' <param name="xml"></param>
    ' ''' <returns></returns>
    ' ''' <remarks></remarks>
    'Public Shared Function ParseTextToXElement(xml As String, ByRef status As Integer) As XElement
    '    Try
    '        Dim _xml = XElement.Parse(xml)
    '        status = 1
    '        Return _xml
    '    Catch ex As Exception
    '        status = -1
    '        Return Nothing
    '    End Try
    'End Function

    ''' <summary>
    ''' разберет описание как в первой версии. вернет строку описания полностью, для интернета.
    ''' </summary>
    ''' <param name="culture"></param>
    ''' <param name="xmlstring"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Shared Function ParseDescriptionXML(culture As System.Globalization.CultureInfo, xmlstring As String, ByRef status As Integer) As String
        Try
            Dim _xml = XElement.Parse(xmlstring)
            status = 1
            Return ParseDescriptionXML(culture, _xml)
        Catch ex As Exception
            status = -1
            Return ""
        End Try

    End Function
    ''' <summary>
    ''' разберет описание. Тег ELEMENT должен быть вложен в тег DATA!! Иначе вернет пустую строку!
    ''' </summary>
    ''' <param name="culture"></param>
    ''' <param name="xml"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Overloads Shared Function ParseDescriptionXML(culture As System.Globalization.CultureInfo, xml As XElement) As String
        Debug.Assert(xml.Name = "DATA", "Требуется корневой тег DATA")
        If Not xml.Name = "DATA" Then
            Return Nothing
        End If
        '--------xml-parcer---------
        If xml Is Nothing Then Return ""
        If culture Is Nothing Then culture = My.Computer.Info.InstalledUICulture
        Dim _lx = From c As XElement In xml...<ELEMENT> Where c.@lang = culture.Name
        Dim _out As New List(Of String)
        For Each t In _lx
            Dim _pr = ParseNodeXML(t)
            _out.Add(_pr)
        Next
        Return String.Join(ChrW(13), _out)
    End Function
    ''' <summary>
    ''' вернет короткое описание для этикетки. 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Overloads Shared Function ParseLabelDescriptionXML(culture As System.Globalization.CultureInfo, xml As XElement, Optional separator As String = "") As String
        Debug.Assert(xml.Name = "DATA", "Требуется корневой тег DATA")
        If Not xml.Name = "DATA" Then
            Return Nothing
        End If
        '--------xml-parcer---------
        If xml Is Nothing Then Return ""
        If culture Is Nothing Then culture = My.Computer.Info.InstalledUICulture
        Dim _res = (From c In xml...<LABELINFO> Where c.@lang = culture.Name Select c.FirstNode).ToList
        Dim _out As New List(Of String)
        For Each t In _res
            _out.Add(t.ToString)
        Next

        Return String.Join(separator & ChrW(13), _out)
    End Function
    ''' <summary>
    ''' вернет короткое описание для этикетки. только сами выбранные узлы.
    ''' </summary>
    ''' <param name="culture"></param>
    ''' <param name="xmlstring"></param>
    ''' <param name="status"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Shared Function ParseLabelDescriptionXML(culture As System.Globalization.CultureInfo, xmlstring As String, ByRef status As Integer, Optional separator As String = "") As String
        Try
            Dim _xml = XElement.Parse(xmlstring)
            status = 1
            Return ParseLabelDescriptionXML(culture, _xml, separator)
        Catch ex As Exception
            status = -1
            Return ""
        End Try

    End Function


    ''' <summary>
    ''' высчитывает id этикетки для заданной культуры, для проверки по базе. вернет 0 или -1 в случае ошибки
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CalculateLabelID(descripElemColl As List(Of clsDescriptionElement), culture As Globalization.CultureInfo) As Integer
        Dim _res = From c In descripElemColl Where c.Culture.Name = culture.Name Select c.CreateLabelInfoObject
        Return clsLabel.CalculateLabelID(_res.ToList)
    End Function



   






    ''' <summary>
    ''' вернет список обьектов для описания
    ''' </summary>
    ''' <param name="xml"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CreateElementCollection(xml As XElement, culture As System.Globalization.CultureInfo, Optional allCulture As Boolean = False) As List(Of clsDescriptionElement)
        Debug.Assert(xml.Name = "DATA", "Требуется корневой тег DATA")
        If Not xml.Name = "DATA" Then
            Return Nothing
        End If
        Dim _result As List(Of clsDescriptionElement)
        If allCulture = False Then
            _result = (From c In xml...<ELEMENT> Where c.@lang = culture.IetfLanguageTag Select clsDescriptionElement.CreateInstance(c)).ToList
        Else
            _result = (From c In xml...<ELEMENT> Select clsDescriptionElement.CreateInstance(c)).ToList
        End If
        Return _result
    End Function




    ''' <summary>
    ''' вернет xml описание этикетки из списка обьектов
    ''' </summary>
    ''' <param name="labelinfocollection"></param>
    ''' <param name="label"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetLabelDescriptionFromCollections(labelinfocollection As List(Of clsLabelInfo), Optional label As clsLabel = Nothing) As XElement
        Dim _xml = GetRootDescriptionTag()
        _xml.Add(From c In labelinfocollection Select c.GetXElement)
        If Not label Is Nothing Then
            _xml.Add(label.GetXElement)
        End If
        Return _xml
    End Function



    ''' <summary>
    ''' вернет коллекцию распознанных элементов описания образца. При ошибках вернет пустую коллекцию.
    ''' </summary>
    ''' <param name="XMLDescription"></param>
    ''' <param name="culture"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function DescriptionObjCollection(XMLDescription As String, Optional culture As Globalization.CultureInfo = Nothing) As List(Of Trilbone.clsTreeService.clsDescriptionElement)
        If culture Is Nothing Then culture = clsApplicationTypes.EnglishCulture


        Dim _status As Integer
        Dim _result = clsLabelBase.ParseTextToXElement(XMLDescription, _status)
        If _status > 0 Then
            Return Trilbone.clsTreeService.CreateElementCollection(_result, culture)
        Else
            Return New List(Of Trilbone.clsTreeService.clsDescriptionElement)
        End If
    End Function




    ''' <summary>
    ''' вернет описание узла по его ID
    ''' </summary>
    ''' <param name="NodeID"></param>
    ''' <param name="culture"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetDescriptionElementByNodeID(NodeID As Integer, treename As String, culture As Globalization.CultureInfo) As XElement
        Dim _node = oManager.FindNode(NodeID, treename)
        If Not _node Is Nothing Then Return _node.GetDescriptionElement(culture)
        Return Nothing
    End Function

    ''' <summary>
    ''' вернет xml описание из списка обьектов
    ''' </summary>
    ''' <param name="elements"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetDescriptionFromElementCollection(elements As List(Of clsDescriptionElement)) As XElement
        Dim _xml = GetRootDescriptionTag()
        _xml.Add(From c In elements Select c.GetXElement)
        Return _xml
    End Function
    ''' <summary>
    ''' строит оболочку (корневой тег) для элементов описания
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetRootDescriptionTag() As XElement
        Dim _xml As XElement = <DATA></DATA>
        Return _xml
    End Function

    ''' <summary>
    ''' вспомогательное поле для передачи параметров в общих свойствах класса
    ''' </summary>
    ''' <remarks></remarks>
    Private Shared oActiveManager As clsTreeManager

    ''' <summary>
    ''' путь текущего загруженного файла
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property CurrentFilePath As String
        Get
            Return IIf(oActiveManager Is Nothing, "", oActiveManager.GroupFilePath)
            'If oManager.FileLoaded Then
            '    Return clsTreeManager.GroupFilePath
            'End If
            'Return ""
        End Get
    End Property




    ''' <summary>
    ''' имя текущего загруженного файла без пути = название блока деревьев
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property CurrentGroupName As String
        Get
            Return IIf(oActiveManager Is Nothing, "", oActiveManager.LoadedGroupName)
            'If oManager.FileLoaded Then
            '    Return clsTreeManager.LoadedGroupName
            'End If
            'Return ""
        End Get
    End Property


    Public Sub New()
        'регистрируем предоставляемые сервисы

        '1. сервис загрузки полного списка фоссилий по названию типа
        DelegateStoreGetTreesListFromFile = _
New TreesNameListFromFileDelegateFunction(AddressOf GetTreesListFromFile)
        '2. сервис загрузки полного списка типа фоссилий
        DelegateStoreGetTreeLeafNodeNames = _
New TreeFossilNamesDelegateFunction(AddressOf GetTreeLeafNodeNames)

        '4. сервис формы myTrees
        '(короткая форма)
        DelegateStoreApplicationForm _
             (emFormsList.fmDescriptionTreeBuilder) = New ApplicationFormDelegateFunction(AddressOf GetformDescriptionBuilder)
        '//////////////////////

        oManager = New clsTreeManager
        oActiveManager = oManager

    End Sub

#Region "Form provide"
    ''' <summary>
    ''' привязка обработчика 
    ''' </summary>
    ''' <param name="_fm"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function AddHandlerToForm(_fm As Trilbone.fmDescription) As Trilbone.fmDescription
        RemoveHandler _fm.DescriptionAcceptedfmDescription, AddressOf Me.DescriptionAcceptfmDescription_EventHandler
        AddHandler _fm.DescriptionAcceptedfmDescription, AddressOf Me.DescriptionAcceptfmDescription_EventHandler
        Return _fm
    End Function


    ''' <summary>
    ''' вернет форму DescriptionBuilder
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Overloads Function GetformDescriptionBuilder(param As Object) As Windows.Forms.Form
        'при отсутствии параметра ИЛИ пустом менеджере загружаем новый обьект
        If param Is Nothing OrElse oManager Is Nothing Then
            'If oManager Is Nothing Then
            '    oManager = New clsTreeManager
            '    oActiveManager = oManager
            'ElseIf oManager.FileLoaded = False And oManager.GroupFilePath.Length > 1 Then
            '    oManager.LoadFile()
            'End If
            oManager = New clsTreeManager
            oActiveManager = oManager
            Return AddHandlerToForm(New Trilbone.fmDescription(oManager))
        End If

        Select Case param.GetType
            Case GetType(String)
                'параметр - имя узла
                Return GetformDescriptionBuilder(CType(param, String))
            Case GetType(clsTreeService.clsDescriptionElement)
                'параметр - элемент описания
                Return GetformDescriptionBuilder(CType(param, clsTreeService.clsDescriptionElement))
        End Select

        Return Nothing
    End Function


    ''' <summary>
    ''' вернет форму DescriptionBuilder. пробует найти узел с именем  NodeName
    ''' </summary>
    ''' <param name="NodeName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function GetformDescriptionBuilder(NodeName As String) As Windows.Forms.Form
        If oManager Is Nothing Then
            oManager = New clsTreeManager
            oActiveManager = oManager
        End If
        '----------
        Dim _fm = New Trilbone.fmDescription(oManager)
        If NodeName.Length = 0 Then GoTo ex
        If Not IO.File.Exists(oManager.GroupFilePath) Then GoTo ex

        If Me.oManager.FileLoaded Then
            'обработка имени
            Dim _name = NodeName.Split("(")(0)

            For Each _tr In oManager.TreeCollection
                Dim _result = (From c In _tr.Value Where c.Name.Contains(_name) Select c).FirstOrDefault
                If Not _result Is Nothing Then
                    'Found!!!
                    Dim _uc = _fm.SelectTab(_tr.Key)
                    If Not _uc Is Nothing Then
                        'вкладка систематика существует
                        _uc.SelectNode(_result)
                    End If
                End If
            Next
            'NOT found
        End If

ex:
        Return AddHandlerToForm(_fm)
    End Function

    ''' <summary>
    ''' вернет форму DescriptionBuilder. пробует найти элемент element
    ''' </summary>
    ''' <param name="element"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function GetformDescriptionBuilder(element As clsTreeService.clsDescriptionElement) As Windows.Forms.Form
        If oManager Is Nothing Then
            oManager = New clsTreeManager
            oActiveManager = oManager
        End If
        '-------------
        Dim _fm = New Trilbone.fmDescription(oManager)
        If element Is Nothing Then GoTo ex
        If element.FileName Is Nothing Then GoTo ex
        If Not IO.File.Exists(oManager.GroupFilePath) Then GoTo ex
        'замена дерева по сохраненному пути
        oManager.GroupFilePath = IO.Path.Combine(IO.Path.GetDirectoryName(oManager.GroupFilePath), element.FileName)
        Me.oManager.LoadFile()
        If Me.oManager.FileLoaded Then
            If Me.oManager.ContainsTree(element.Name) Then
                Dim _uc = _fm.SelectTab(element.Name)
                If Not _uc Is Nothing Then
                    'выбрать узел
                    Dim _tree = Me.oManager.GetTreeOf(element.Name)
                    Dim _id As Integer = element.ID
                    Dim _node = _tree.Item(_id)
                    _uc.SelectNode(_node)
                End If
            End If
        End If

ex:
        Return AddHandlerToForm(_fm)
    End Function

#End Region

    Private oManager As clsTreeManager
    ' Private Shared oServiceBurrer As New Dictionary(Of String, clsTreeService)

    ''' <summary>
    ''' вернет экземпляр. внутри содержит буфер по имени группы. для принудит. загрузки оставте имя пустым
    ''' </summary>
    ''' <param name="GroupName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CreateInstance(Optional GroupName As String = "") As clsTreeService
        If GroupName = "" Then Return New clsTreeService
        'If oServiceBurrer.ContainsKey(GroupName) Then
        '    Return oServiceBurrer.Item(GroupName)
        'End If
        'add in buffer
        Dim _new = New clsTreeService
        Dim _status = _new.LoadFileByGroupName(GroupName)
        If _status Then
            'oServiceBurrer.Add(GroupName, _new)
        End If
        Return _new
    End Function


    Private Shared IsConnected As Boolean
    Private Shared oMyTreeDBBuilder As EntityClient.EntityConnectionStringBuilder
    'Private Shared odbModelMyTreesObjectContext As dbMyTreesContainer
    ' ''' <summary>
    ' ''' устанавливает соединение с хранилищем. Инициализует обьекты-контексты.
    ' ''' </summary>
    'Public Shared Function Connect(Optional ByRef ConnectMessage As String = "") As Boolean
    '    If Not IsConnected Then

    '        '----------My Trees DB--------------
    '        Dim _SqlBuilder = New SqlClient.SqlConnectionStringBuilder(clsApplicationTypes.dbMyTreesConnectionString)
    '        _SqlBuilder.ConnectTimeout = 30
    '        oMyTreeDBBuilder = New EntityClient.EntityConnectionStringBuilder
    '        With oMyTreeDBBuilder
    '            .Provider = "System.Data.SqlClient"
    '            .ProviderConnectionString = _SqlBuilder.ToString
    '            .Metadata = "res://*/dbMyTrees.csdl|" & _
    '                              "res://*/dbMyTrees.ssdl|" & _
    '                              "res://*/dbMyTrees.msl"
    '        End With

    '        Try
    '            odbModelMyTreesObjectContext = New dbMyTreesContainer(oMyTreeDBBuilder.ToString)

    '        Catch ex As Exception
    '            ConnectMessage += " MyTrees НЕ ПОДКЛЮЧЕНА."
    '        End Try

    '        ConnectMessage += " MyTrees подключена."
    '        IsConnected = True

    '    End If


    '    Return IsConnected
    'End Function

    'Public Shared ReadOnly Property MyTreeContext As dbMyTreesContainer
    '    Get
    '        Return odbModelMyTreesObjectContext
    '    End Get
    'End Property


    'Private Sub New()
    '    oManager = New clsTreeManager
    'End Sub
    ''' <summary>
    ''' показать страничку
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ShowBrowser()
        'показать главную htm
        Me.oManager.ShowBrowser()
        'Dim _path = IO.Path.ChangeExtension(Me.oManager.BlockFilePath, "htm")

        'If _path.Length > 0 AndAlso IO.File.Exists(_path) Then
        '    System.Diagnostics.Process.Start(_path)
        'Else
        '    MsgBox("Отсутствует файл", vbCritical, clsTreeManager.AppHeader)
        'End If

    End Sub
    ''' <summary>
    ''' загрузить файл деревьев по сути по имени файла, а так-по имени группы
    ''' </summary>
    ''' <param name="GroupName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function LoadFileByGroupName(GroupName As String) As Boolean
        If GroupName.Length = 0 Then Return False
        Dim _path = IO.Path.Combine(clsApplicationTypes.TreeFolderPath, GroupName)
        If Not IO.File.Exists(_path) Then Return False
        Return Me.LoadFile(_path)
    End Function





    ''' <summary>
    ''' загрузить файл деревьев по пути FilePath
    ''' </summary>
    ''' <param name="FilePath"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function LoadFile(FilePath As String) As Boolean
        'проверки
        'Debug.Assert(FilePath.Length > 0, "передана пустая строка пути файла")
        'Debug.Assert(IO.File.Exists(FilePath), "файл по указанному пути не существует")
        If FilePath Is Nothing OrElse FilePath.Length = 0 OrElse IO.File.Exists(FilePath) = False Then
            Return False
        End If
        'выбрать файл
        Try
            oManager.GroupFilePath = FilePath
            Return oManager.LoadFile
        Catch ex As Exception
            Debug.Fail("Невозможно открыть файл по пути " & oManager.GroupFilePath)
            Return False
        End Try

    End Function


    ''' <summary>
    ''' Вернет список деревьев в текущем файле
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function GetTreesListFromFile() As String()
        If Not oManager.FileLoaded Then Return GetTreeLeafNodesNames("")
        Return oManager.TreeCollection.Keys.ToArray
    End Function
   

   

    'Public Shared Function GetResizedImageForTree(ByVal ImageFileFullPath As String, Optional original As Boolean = False) As Image
    '    Return Service.clsApplicationTypes.GetResizedImageForTree(ImageFileFullPath, original)
    'End Function

    ''' <summary>
    ''' вернет коллекцию имаджев для узла
    ''' </summary>
    ''' <param name="treename"></param>
    ''' <param name="nodeid"></param>
    ''' <param name="dpi"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetAiImagesByNodeID(treename As String, nodeid As Integer, dpi As Integer) As List(Of Image)
        Debug.Assert(treename.Length > 0)
        Dim _node = oManager.FindNode(nodeid, treename)

        If _node Is Nothing Then Return New List(Of Image)

        Return oManager.GetDataFolderAiImagesForNode(_node.Parent, _node, dpi)
    End Function
   



    ''' <summary>
    ''' Вернет список деревьев в файле treeFilePath (полный путь). Перезагрузит загруженный файл. Если передать "", то откроет окно выбора файла
    ''' </summary>
    ''' <param name="treeFilePath"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function GetTreesListFromFile(ByRef treeFilePath As String) As String()

        If oManager Is Nothing OrElse (Not oManager.FileLoaded) Then
            'открыть новый менеджер
            If treeFilePath = "" Then
                Dim s = clsTreeManager.GetFileTreeOpenDialog
                Select Case s.ShowDialog
                    Case DialogResult.OK
                        treeFilePath = s.FileName
                    Case Else
                        Return New String() {""}
                End Select
            End If

            If Me.LoadFile(treeFilePath) Then
                Return Me.GetTreesListFromFile()
            End If

            ''выбрать файл
            'Try
            '    oManager.FilePath = treeFilePath
            '    oManager.LoadFile()
            'Catch ex As Exception
            '    Debug.Fail("Невозможно открыть файл по пути " & oManager.FilePath)
            '    Return _list.ToArray
            'End Try
        Else
            Return Me.GetTreesListFromFile()
        End If

        Return New String() {""}

    End Function
    ''' <summary>
    ''' вернет список "листьев" для дерева TreeName в текущем файле
    ''' </summary>
    ''' <param name="TreeName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function GetTreeLeafNodesNames(TreeName As String, Optional culture As Globalization.CultureInfo = Nothing) As String()
        Debug.Assert(TreeName.Length > 0, "необходимо передать значимое имя дерева")
        Dim _list As New List(Of String)
        If Not oManager.FileLoaded Then
            Debug.Fail("файл деревьев не загружен")
            Return New String() {""}
        End If

        If oManager.TreeCollection.ContainsKey(TreeName) Then
            Dim _tree = oManager.TreeCollection.Item(TreeName)
            If _tree Is Nothing Then
                Debug.Fail("Внутренняя ошибка класса Tree. Элемент словаря не содержит обьекта.")
                Return New String() {""}
            End If
            'берем список имен
            If culture Is Nothing Then culture = clsTreeManager.EnglishCulture
            Dim _result = From c In _tree.GetLeafNodes(culture) Select c.NodeNameByCulture(culture)

            Dim _m = _result.ToArray
            Return _result.ToArray
        Else
            Debug.Fail("файл " & oManager.LoadedGroupName & " не содержит дерева с именем " & TreeName)
            Return New String() {""}
        End If
    End Function

    ''' <summary>
    ''' вернет список "листьев" для дерева TreeName в файле treeFilePath
    ''' </summary>
    ''' <param name="treeFilePath"></param>
    ''' <param name="TreeName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function GetTreeLeafNodeNames(treeFilePath As String, TreeName As String, Optional culture As Globalization.CultureInfo = Nothing) As String()
        Debug.Assert(TreeName.Length > 0, "необходимо передать значимое имя дерева")
        If oManager Is Nothing OrElse (Not oManager.FileLoaded) OrElse (Not oManager.GroupFilePath = treeFilePath) Then
            If Me.LoadFile(treeFilePath) Then
                Return Me.GetTreeLeafNodesNames(TreeName, culture)
            End If
        End If
        Return Me.GetTreeLeafNodesNames(TreeName, culture)

    End Function
    Public Shared Event DescriptionAccepted(sender As Object, e As DescriptionAcceptEventArg)


    Public Function GetAllNamesByVolume(VolumeFilter As String) As List(Of String) Implements iMyTreesDataProvider.GetAllNamesByVolume

        Dim _out As New List(Of SerializableNodeObject)
        For Each f In GetTreesNames()
            Dim _find = IO.Path.Combine(clsApplicationTypes.TreeFolderPath, f)
            If IO.Directory.Exists(_find) Then
                Dim _path = IO.Directory.EnumerateFiles(_find, String.Format("{0}*.xml", VolumeFilter), IO.SearchOption.TopDirectoryOnly).FirstOrDefault
                If Not String.IsNullOrEmpty(_path) Then
                    Dim _xe = XElement.Load(_path)
                    Dim _res = From c In _xe...<HierObj> Select NodeObject.ParceFromXML(c)
                    _out.AddRange(_res)
                End If
            End If
        Next

        'фильтр на одинаковые по имени и сортировка
        _out.Distinct(New clsNodeComparatorByName)
        _out.Sort(clsNodeComparatorByName.Comparison)

        Return (From c In _out Select c.Name).ToList
    End Function



    Public Function GetTreesNames() As String() Implements iMyTreesDataProvider.GetTreesNames
        If clsApplicationTypes.TreeFolderPath = "" Then Return New String() {}
        Dim _out = IO.Directory.EnumerateFiles(clsApplicationTypes.TreeFolderPath, "*.tree", IO.SearchOption.TopDirectoryOnly).Select(Function(x) IO.Path.GetFileNameWithoutExtension(x))
        Return _out.ToArray
    End Function


    Public Function Version() As Integer Implements iMyTreesDataProvider.Version
        Return 1
    End Function


    ' ''' <summary>
    ' ''' разбор узла
    ' ''' </summary>
    ' ''' <param name="node"></param>
    ' ''' <returns></returns>
    ' ''' <remarks></remarks>
    'Private Function ParceNode(node As SerializableNodeObject) As String
    '    'If node.Link Is Nothing Then Return node.Name
    '    'If node.Link.Count = 0 Then Return node.Name
    '    'Dim _out As String = node.Name & ", "
    '    'For Each ln In node.Link
    '    '    If ln.Key.ToLower.StartsWith("loc") And Not clsApplicationTypes.MyTreesLocalityNames Is Nothing Then
    '    '        For Each nd In ln.Value
    '    '            Dim _ndd = (From c In clsApplicationTypes.MyTreesLocalityNames Where c.id = nd Select c.Name)
    '    '            If Not _ndd Is Nothing Then
    '    '                For Each t In _ndd
    '    '                    If Not String.IsNullOrEmpty(t) Then
    '    '                        _out += t & ", "
    '    '                    End If
    '    '                Next
    '    '            End If
    '    '        Next
    '    '    End If
    '    '    If ln.Key.ToLower.StartsWith("time") And Not clsApplicationTypes.MyTreesTimeScaleNames Is Nothing Then
    '    '        For Each nd In ln.Value
    '    '            Dim _ndd = (From c In clsApplicationTypes.MyTreesTimeScaleNames Where c.id = nd Select c.Name)
    '    '            If Not _ndd Is Nothing Then
    '    '                For Each t In _ndd
    '    '                    If Not String.IsNullOrEmpty(t) Then
    '    '                        _out += t & ", "
    '    '                    End If
    '    '                Next
    '    '            End If
    '    '        Next
    '    '    End If
    '    'Next
    '    'Return _out
    'End Function
End Class
