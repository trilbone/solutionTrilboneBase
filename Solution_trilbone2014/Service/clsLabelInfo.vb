Imports System.Xml.Linq
Imports System.Linq
''' <summary>
''' обьект подписи к узлу для этикетки
''' </summary>
''' <remarks></remarks>
Public Class clsLabelInfo
    Implements IComparable
    Implements IComparable(Of clsLabelInfo)
    Private oid As Integer

    Private Sub New()

    End Sub
    ''' <summary>
    ''' хеш-код для id вычисляется без учета регистра !!!!! важно - далее, когда значения узлов будут одинаковыми, последние два параметра отбросим = использовать перегрузку!!!
    ''' </summary>
    ''' <param name="descriptionNodeID"></param>
    ''' <param name="groupname"></param>
    ''' <param name="treename"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Shared Function CalculateID(descriptionNodeID As Integer, groupname As String, treename As String, lang As String) As Integer
        '!!!!! важно - далее, когда значения узлов будут одинаковыми, первые два параметра отбросим = использовать перегрузку!!!
        If groupname Is Nothing Then groupname = ""
        If treename Is Nothing Then treename = ""

        Return groupname.ToLower.GetHashCode Xor treename.ToLower.GetHashCode Xor descriptionNodeID.GetHashCode Xor lang.GetHashCode
    End Function

    ' ''' <summary>
    ' ''' прототип функции на будущее
    ' ''' </summary>
    ' ''' <param name="descriptionNodeID"></param>
    ' ''' <returns></returns>
    ' ''' <remarks></remarks>
    'Private Overloads Shared Function CalculateID(descriptionNodeID As Integer) As Integer
    '    Return descriptionNodeID
    'End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="xml"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Shared Function CreateInstance(xml As XElement) As clsLabelInfo
        Debug.Assert(xml.Name = "LABELINFO", "Требуется корневой тег LABELINFO")
        If Not xml.Name = "LABELINFO" Then
            Return Nothing
        End If
        '--------xml-parcer---------
        Dim _new As New clsLabelInfo
        With _new
            .oid = xml.@id
            .oParentGroup = xml.@group
            .oParentTreename = xml.@treename
            .orootnode = xml.@rootnode
            .oParentNodeID = xml.@nodeid
            .Order = xml.@order
            .oCulture = System.Globalization.CultureInfo.CreateSpecificCulture(xml.@lang)
            .Value = xml.FirstNode.ToString
        End With
        Return _new
    End Function

    ''' <summary>
    ''' хеш-код для id вычисляется без учета регистра
    ''' </summary>
    ''' <param name="groupname"></param>
    ''' <param name="treename"></param>
    ''' <param name="descriptionNodeID"></param>
    ''' <param name="Culture"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Shared Function CreateInstance(descriptionNodeID As Integer, Culture As System.Globalization.CultureInfo, groupname As String, treename As String, rootnode As String, Optional labelvalue As String = "") As clsLabelInfo
        'Debug.Assert(groupname.Length > 0, "имя группы деревьев необходимо задать")
        Debug.Assert(treename.Length > 0, "имя дерева необходимо задать")
        If groupname Is Nothing Then groupname = ""
        Dim _new As New clsLabelInfo
        With _new
            'задать id 
            .oid = CalculateID(descriptionNodeID, groupname, treename, Culture.Name)
            .oCulture = Culture
            .oParentGroup = groupname
            .oParentTreename = treename
            .oParentNodeID = descriptionNodeID
            .orootnode = rootnode
            .Value = labelvalue

            'задать order по умолчанию
            Select Case treename.ToLower
                Case "systematica"
                    .Order = 1
                Case "timescale", "age", "geological age"
                    .Order = 2
                Case "locality", "localities"
                    .Order = 3
                Case Else
                    .Order = 0
            End Select

        End With
        Return _new
    End Function


    ''' <summary>
    ''' id обьекта/ задается при создании
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property iD As Integer
        Get
            Return oid
        End Get
    End Property

    Private oParentGroup As String

    ''' <summary>
    ''' имя группы (группы деревьев) - родителя
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property parentGroup As String
        Get
            Return oParentGroup
        End Get
    End Property

    Private oParentTreename As String

    ''' <summary>
    ''' имя дерева - родителя
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property parentTreename As String
        Get
            Return oParentTreename
        End Get
    End Property

    Private orootnode As String

    ''' <summary>
    ''' значение корневого узла родившего дерева
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property rootnode As String
        Get
            Return orootnode
        End Get
    End Property

    Private oParentNodeID As Integer

    ''' <summary>
    ''' ID родившего узла
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property parentNodeID As Integer
        Get
            Return oParentNodeID
        End Get
    End Property

    ''' <summary>
    ''' порядок при выводе на этикетке/есть реализация по умолчанию
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Order As Integer
    ''' <summary>
    ''' текстовое значение, отображаемое на этикетке
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Value As String


    Private oCulture As System.Globalization.CultureInfo


    ''' <summary>
    ''' язык текста
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property culture As System.Globalization.CultureInfo
        Get
            Return oCulture
        End Get
    End Property

    Public Overrides Function Equals(obj As Object) As Boolean
        If Not TypeOf obj Is clsLabelInfo Then Return False
        Dim _tmp = CType(obj, clsLabelInfo)
        If Not _tmp.iD = Me.iD Then Return False
        If Value Is Nothing Then Value = ""
        If Not String.Equals(_tmp.Value, Me.Value) Then Return False
        If Not _tmp.culture.Name = Me.culture.Name Then Return False
        If Not _tmp.Order = Me.Order Then Return False
        Return True
    End Function

    Public Overrides Function GetHashCode() As Integer
        If Value Is Nothing Then Value = ""
        Return oid.GetHashCode Xor Me.Order.GetHashCode Xor Me.culture.Name.GetHashCode Xor Me.Value.GetHashCode
    End Function

    Public Overrides Function ToString() As String
        Return Value
    End Function

    Private Function xCompareTo(obj As Object) As Integer Implements System.IComparable.CompareTo
        If Not TypeOf obj Is clsLabelInfo Then Return 0
        Return xCompareTo(obj)
    End Function

    Public Function CompareTo(other As clsLabelInfo) As Integer Implements System.IComparable(Of clsLabelInfo).CompareTo
        If Me.Order > other.Order Then Return 1
        If Me.Order = other.Order Then Return 0
        If Me.Order < other.Order Then Return -1
        Return 0
    End Function

    ''' <summary>
    ''' xml представление элемента
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetXElement() As XElement
        Dim _xml As XElement = <LABELINFO id=<%= Me.iD %> group=<%= Me.parentGroup %> treename=<%= Me.parentTreename %> rootnode=<%= Me.rootnode %> nodeid=<%= Me.parentNodeID %> order=<%= Me.Order %> lang=<%= Me.culture.Name %>>
                                   <%= Me.Value %>
                               </LABELINFO>
        Return _xml

    End Function
End Class
''' <summary>
''' описывает полный комплект
''' </summary>
''' <remarks></remarks>
Public Class clsLabelBase

    ''' <summary>
    ''' создаст этикетку
    ''' </summary>
    ''' <param name="labelinfoColl"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Shared Function CreateLabelObjCollection(labelinfoColl As List(Of clsLabelInfo), culture As Globalization.CultureInfo, Optional files As List(Of clsLabel.strFile) = Nothing, Optional allculture As Boolean = False) As List(Of clsLabel)
        Dim _out As New List(Of clsLabel)
        Dim _new As clsLabel
        If allculture Then
            _new = (clsLabel.CreateInstanse(labelinfoColl, clsApplicationTypes.EnglishCulture))
            _out.Add(_new)
            _new = (clsLabel.CreateInstanse(labelinfoColl, clsApplicationTypes.RussianCulture))
            _out.Add(_new)
        Else
            _new = (clsLabel.CreateInstanse(labelinfoColl, culture))
            If Not files Is Nothing Then
                _new.Files = files
            End If
            _out.Add(_new)
        End If
        Return _out
    End Function
    ''' <summary>
    ''' вернет список обьектов - этикеток, если нет таких, вернет Nothing
    ''' </summary>
    ''' <param name="xml"></param>
    ''' <param name="culture"></param>
    ''' <param name="allCulture"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Shared Function CreateLabelObjCollection(xml As XElement, culture As System.Globalization.CultureInfo, Optional allCulture As Boolean = False) As List(Of clsLabel)
        Debug.Assert(xml.Name = "DATA", "Требуется корневой тег DATA")
        If Not xml.Name = "DATA" Then
            Return Nothing
        End If
        Dim _result As List(Of clsLabel)
        If allCulture = False Then
            _result = (From c In xml...<LABEL>...<FILE> Where c.@lang = culture.IetfLanguageTag Select clsLabel.CreateInstance(c.Parent)).ToList
        Else
            _result = (From c In xml...<LABEL> Select clsLabel.CreateInstance(c)).ToList
        End If
        Return _result
    End Function

    ''' <summary>
    ''' вернет список обьектов - подписей к этикетке
    ''' </summary>
    ''' <param name="xml"></param>
    ''' <param name="culture"></param>
    ''' <param name="allCulture"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CreateLabelInfoCollection(xml As XElement, culture As System.Globalization.CultureInfo, Optional allCulture As Boolean = False) As List(Of clsLabelInfo)
        Debug.Assert(xml.Name = "DATA", "Требуется корневой тег DATA")
        If Not xml.Name = "DATA" Then
            Return Nothing
        End If
        Dim _result As List(Of clsLabelInfo)
        If allCulture = False Then
            _result = (From c In xml...<LABELINFO> Where c.@lang = culture.IetfLanguageTag Select clsLabelInfo.CreateInstance(c)).ToList
        Else
            _result = (From c In xml...<LABELINFO> Select clsLabelInfo.CreateInstance(c)).ToList
        End If
        Return _result
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

    Public Function GetLabelsByCulture(culture As Globalization.CultureInfo) As List(Of clsLabel)
        If LabelCollection Is Nothing Then Return New List(Of clsLabel)

        Dim _res = (From c In LabelCollection Where c.culture.Name = culture.Name Select c).ToList
        _res.Sort()
        Return _res
    End Function


    Public Function GetInfoByCulture(culture As Globalization.CultureInfo) As List(Of clsLabelInfo)
        If LabelInfoCollection Is Nothing Then Return New List(Of clsLabelInfo)

        Dim _res = (From c In LabelInfoCollection Where c.culture.Name = culture.Name Select c).ToList
        _res.Sort()
        Return _res
    End Function
    Private oLabelInfoCollection As List(Of clsLabelInfo)

    Property LabelInfoCollection As List(Of clsLabelInfo)
        Get
            If oLabelInfoCollection Is Nothing Then
                oLabelInfoCollection = New List(Of clsLabelInfo)
            End If
            Return oLabelInfoCollection
        End Get
        Set(value As List(Of clsLabelInfo))
            oLabelInfoCollection = value
        End Set
    End Property

    Private oLabelCollection As List(Of clsLabel)


    Property LabelCollection As List(Of clsLabel)
        Get
            If oLabelCollection Is Nothing Then

                oLabelCollection = New List(Of clsLabel)
            End If
            Return oLabelCollection
        End Get
        Set(value As List(Of clsLabel))
            oLabelCollection = value
        End Set
    End Property
    ''' <summary>
    ''' вернет xml
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetXElements() As XElement



        Dim _xml As XElement = <DATA>

                               </DATA>

        If Not LabelInfoCollection Is Nothing Then
            _xml.Add((From t In LabelInfoCollection Select t.GetXElement).ToList)
        End If

        If Not LabelCollection Is Nothing Then
            _xml.Add((From t In LabelCollection Select t.GetXElement).ToList)
        End If


        Return _xml
    End Function

    Public Overloads Overrides Function ToString() As String
        Return Me.GetType.Name
    End Function

    Public Overloads Function ToString(culture As Globalization.CultureInfo) As String
        If LabelCollection Is Nothing Then Return ""

        Dim _res = (From c In LabelCollection Where c.culture.Name = culture.Name Select c).FirstOrDefault

        If _res Is Nothing Then Return ""

        Return _res.ToString

    End Function
End Class

Public Class clsLabel
    Public Class clsNode
        Implements IComparable
        Implements IComparable(Of clsNode)

        Private oNodeIDCollection As List(Of strNodeID)

        Property NodeIDCollection As List(Of strNodeID)
            Get
                If oNodeIDCollection Is Nothing Then
                    oNodeIDCollection = New List(Of strNodeID)
                End If
                Return oNodeIDCollection
            End Get
            Set(value As List(Of strNodeID))
                oNodeIDCollection = value
            End Set
        End Property
        ''' <summary>
        ''' имя дерева, используем для вычисления пути к файлам
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property Treename As String
        ''' <summary>
        ''' текстовое значение корневого узла дерева, к которому принадлежит узел с ID. используем для подписи в формах.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property Rootnode As String

        ''' <summary>
        ''' тут редактированный сцепленный текст узлов
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property Value As String

        ''' <summary>
        ''' задано, если узел содержит более 2-х узлов
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ReadOnly Property Combined As Boolean
            Get
                If NodeIDCollection.Count > 1 Then Return True
                Return False
            End Get
        End Property
        ''' <summary>
        ''' порядок отображения в этикетке
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property Order As Integer

        Public Function xCompareTo(obj As Object) As Integer Implements System.IComparable.CompareTo
            If Not TypeOf obj Is clsNode Then Return 0
            Return CompareTo(obj)
        End Function

        Public Function CompareTo(other As clsNode) As Integer Implements System.IComparable(Of clsNode).CompareTo
            If Me.Order > other.Order Then Return 1
            If Me.Order = other.Order Then Return 0
            If Me.Order < other.Order Then Return -1
            Return 0
        End Function
    End Class


    Public Structure strNodeID
        Property LabelinfoID As Integer

        ''' <summary>
        ''' это ID узла из дерева, потом оно будет уникальным и два предыдущих не нужны
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property NodeID As Integer
    End Structure

    Public Structure strFile
        ''' <summary>
        ''' только имя файла с расширением
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property Name As String
        Property Labeltype As String
        Property Href As String
    End Structure

    Public Sub New(id As Integer, group As String, culture As Globalization.CultureInfo)
        Me.oID = id
        Me.oCulture = culture
        Me.oGroup = group

    End Sub
    ''' <summary>
    ''' установит коллекцию узлов
    ''' </summary>
    ''' <param name="collection"></param>
    ''' <remarks></remarks>
    Public Sub SetNodeCollection(collection As List(Of clsLabel.clsNode))
        Me.oNodeCollection = collection
    End Sub


    Private Sub New()

    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="xml"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Shared Function CreateInstance(xml As XElement) As clsLabel
        Debug.Assert(xml.Name = "LABEL", "Требуется корневой тег LABEL")
        If Not xml.Name = "LABEL" Then
            Return Nothing
        End If
        '--------xml-parcer---------
        Dim _new As New clsLabel
        With _new
            .oID = xml.@id
            .Href = xml.@href
            .oGroup = xml.@group
            .oCulture = System.Globalization.CultureInfo.CreateSpecificCulture(xml.@lang)

            .oNodeCollection = (From c In xml...<NODE> Select New clsNode With {.Order = c.@order, .Rootnode = c.@rootnode, .Treename = c.@treename, .Value = (From c3 In c.Nodes Where c3.NodeType = System.Xml.XmlNodeType.Text Select c3).FirstOrDefault.ToString, .NodeIDCollection = (From c1 In c...<NODEID> Select New strNodeID With {.LabelinfoID = c1.@labelinfoid, .NodeID = c1.@nodeid}).ToList}).ToList


            .Files = (From c1 In xml...<FILE> Select New strFile With {.Href = c1.@href, .Name = c1.@name, .Labeltype = c1.@labeltype}).ToList

        End With



        Return _new
    End Function


    ''' <summary>
    ''' создает обьект clsLabel из обьектов labelinfo
    ''' </summary>
    ''' <param name="NodesToLink"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Shared Function CreateInstanse(NodesToLink As List(Of clsLabelInfo), culture As Globalization.CultureInfo) As clsLabel
        Dim _group As String = ""

        For Each c In NodesToLink
            If Not _group = "" Then
                If Not _group.ToLower = c.parentGroup.ToLower Then
                    'добавлены узлы из разных файлов (групп), что недопустимо!
                    ' Err.Raise(255, NodesToLink, "добавлены узлы из разных файлов (групп), что недопустимо!")
                    'удалить лишние узлы
                    NodesToLink = NodesToLink.FindAll(Function(c1) c1.parentGroup = _group)
                    Exit For
                End If
            End If
            _group = c.parentGroup
        Next

        ''сцепляет элементы value (главная функция преобразования названий
        Dim _fnShotNames = Function(input As IEnumerable(Of clsLabelInfo)) As String
                               If input.Count = 1 Then
                                   'если значение одно, не сцеплять значения
                                   Return input.First.Value
                               End If

                               Dim _out As String = ""
                               For Each t In input
                                   Dim _vl = t.Value
                                   'преобразовать значение
                                   Select Case t.parentTreename.ToLower
                                       Case "systematica"
                                           _vl = t.Value.Split(",").Last

                                       Case "geological age", "timescale"
                                           _vl = t.Value.Split(",").Last
                                   End Select

                                   If _out = "" Then
                                       _out += _vl
                                   Else
                                       Select Case t.culture.Name
                                           Case clsApplicationTypes.EnglishCulture.Name
                                               _out += " and " & _vl
                                           Case clsApplicationTypes.RussianCulture.Name
                                               _out += " и " & _vl
                                       End Select
                                   End If
                               Next
                               Return _out
                           End Function

        'группируем по rootnode и оставляем только запрашиваемую культуру
        Dim _r = From c In NodesToLink Where c.culture.Name = culture.Name Group By rootnd = c.rootnode Into ab = Group, thn = First()

        'создаем обьекты strNode и strNodeID
        Dim _r1 = From c In _r Select New clsNode With {.Order = c.thn.Order, .Rootnode = c.rootnd, .Treename = c.thn.parentTreename, .NodeIDCollection = (From c2 In c.ab Select New strNodeID With {.LabelinfoID = c2.iD, .NodeID = c2.parentNodeID}).ToList, .Value = _fnShotNames(c.ab)}

        Dim _new = New clsLabel
        With _new
            .oNodeCollection = _r1.ToList
            .oID = CalculateLabelID(NodesToLink)
            .oGroup = _group
            .oCulture = culture
        End With
        Return _new
    End Function
    ''' <summary>
    ''' вычисляет ID этикетки. вернет 0 если список пуст, -1 если nothing
    ''' </summary>
    ''' <param name="NodesToLink"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CalculateLabelID(NodesToLink As List(Of clsLabelInfo)) As Integer
        If NodesToLink Is Nothing Then Return -1
        If NodesToLink.Count = 0 Then Return 0

        Dim _arr = NodesToLink.ToArray
        Dim _res As Integer = _arr(0).iD

        For i = 1 To NodesToLink.Count
            _res = _res Xor _arr(i - 1).iD
        Next
        Return _res
    End Function

    Private oNodeCollection As New List(Of clsNode)

    ''' <summary>
    ''' список узлов, формирующих этикетку (Не изменять список!!!)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property NodeCollection As List(Of clsNode)
        Get
            Return oNodeCollection
        End Get
    End Property




    ''' <summary>
    ''' коллекция файлов этикеток
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Files As New List(Of strFile)

    Private oID As Integer

    ''' <summary>
    ''' уникальный ключ этикетки
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property iD As Integer
        Get
            Return oID
        End Get
    End Property

    Private oGroup As String

    ''' <summary>
    ''' группа для этикетки. пока это название файла (ammonites.tree).Необходимо для вычисления пути к файлам этикеток
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property group As String
        Get
            Return oGroup
        End Get
    End Property
    ''' <summary>
    ''' вернет название папки для конкретного файла деревьев, указанного в св-ве group (ammonites.tree-->ammonites)
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetGroupNameForPath() As String
        Return IO.Path.GetFileNameWithoutExtension(Me.group)
    End Function
    ''' <summary>
    ''' вернет коллекцию локальных путей папок ко всем привязанным узлам
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetFolderPathsToLinkedNodes() As String()
        Dim _mainfolder As String = GetGroupNameForPath()
        Dim _res = From c In Me.NodeCollection From c1 In c.NodeIDCollection Select IO.Path.Combine(clsApplicationTypes.TreeFolderPath, _mainfolder, c.Treename, c1.NodeID)
        Return _res.ToArray
    End Function


    ''' <summary>
    ''' ссылка на доп. папку с файлами этикетки. Путь относительный корня (родителя) Archive_photo. Корень будет взят из установок. Еще будут вычислены пути для конкретных узлов, из которых сформирована этикетка
    ''' по этому пути искать файлы в последнюю очередь?
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Href As String


    Public Overrides Function ToString() As String
        Dim _out As String = ""
        Me.NodeCollection.Sort()
        For Each t In Me.NodeCollection
            _out += t.Value & ChrW(13)
        Next
        Return _out
    End Function

    ''' <summary>
    ''' xml представление элемента
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetXElement() As XElement

        Dim _xml As XElement = <LABEL id=<%= Me.iD %> href=<%= Me.Href %> group=<%= Me.group %> lang=<%= Me.culture.Name %>>
                                   <%= From c In Me.NodeCollection Select <NODE order=<%= c.Order %> treename=<%= c.Treename %> rootnode=<%= c.Rootnode %> combined=<%= c.Combined.ToString %>><%= From c2 In c.NodeIDCollection Select <NODEID labelinfoid=<%= c2.LabelinfoID %> nodeid=<%= c2.NodeID %>></NODEID> %><%= c.Value.ToString %></NODE> %>

                                   <%= From c1 In Me.Files Select <FILE href=<%= c1.Href %> name=<%= c1.Name %> labeltype=<%= c1.Labeltype %>></FILE> %>
                               </LABEL>

        Return _xml

    End Function

    ''' <summary>
    ''' язык текста
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property culture As System.Globalization.CultureInfo
        Get
            Return oCulture
        End Get
    End Property


    Private oCulture As System.Globalization.CultureInfo

End Class
