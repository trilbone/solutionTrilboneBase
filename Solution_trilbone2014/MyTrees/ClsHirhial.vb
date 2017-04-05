Imports Microsoft.SqlServer.Types
Imports System.ComponentModel
Imports <xmlns:trb="http://www.trilbone.com">
Imports <xmlns:treeout="http://www.trilbone.com/treeout">
Imports System.Xml.Linq
Imports Trilbone
Imports Service
Imports Service.Catalog

Friend Class clsNodeComparatorByName
    Implements IEqualityComparer(Of SerializableNodeObject)

    Public Function Equals1(x As SerializableNodeObject, y As SerializableNodeObject) As Boolean Implements IEqualityComparer(Of SerializableNodeObject).Equals
        If x.Name.ToLower.Equals(y.Name.ToLower) Then Return True
        Return False
    End Function

    Public Function GetHashCode1(obj As SerializableNodeObject) As Integer Implements IEqualityComparer(Of SerializableNodeObject).GetHashCode
        Return obj.Name.GetHashCode
    End Function

    Private Shared Function CompareBoth(x As SerializableNodeObject, y As SerializableNodeObject) As Integer
        Return x.Name.ToLower.CompareTo(y.Name.ToLower)
    End Function

    Public Shared Function Comparison() As System.Comparison(Of SerializableNodeObject)
        Return New System.Comparison(Of SerializableNodeObject)(AddressOf CompareBoth)
    End Function

    ''' <summary>
    ''' только из двух слов
    ''' </summary>
    ''' <param name="data"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Filter(data As IEnumerable(Of SerializableNodeObject)) As IEnumerable(Of SerializableNodeObject)
        Return From c In data Where c.Name.Split(" ").Count > 0 Select c
    End Function

End Class
<Serializable()>
Friend Class SerializableNodeObject
    Implements INotifyPropertyChanged

    <NonSerialized()>
    Public Event PropertyChanged(ByVal sender As Object, ByVal e As System.ComponentModel.PropertyChangedEventArgs) Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged
    ''' <summary>
    ''' ID узла
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property id As Integer

    Private oDataFolder As String
    ''' <summary>
    ''' сюда пока пишется артикул в виде 123/256/12... (номера связанных узлов)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property DataFolder As String
        Get
            If oDataFolder Is Nothing Then oDataFolder = ""
            Return oDataFolder
        End Get
        Set(value As String)
            oDataFolder = value
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("DataFolder"))
        End Set
    End Property



    Private oName As String
    ''' <summary>
    ''' имя узла английское
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Name As String
        Get
            If oName Is Nothing Then oName = ""
            Return oName
        End Get
        Set(ByVal value As String)
            oName = value
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("Name"))
        End Set
    End Property
    Private oNameRus As String
    ''' <summary>
    ''' имя узла русское (локализовано для лузера)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property NameRUS As String
        Get
            If oNameRus Is Nothing Then oNameRus = ""

            Return oNameRus
        End Get
        Set(ByVal value As String)
            oNameRus = value
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("NameRUS"))
        End Set
    End Property
    Private oDescr As String
    ''' <summary>
    ''' описание узла на английском
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Descr As String
        Get
            If oDescr Is Nothing Then oDescr = ""

            Return oDescr
        End Get
        Set(ByVal value As String)
            oDescr = value
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("Descr"))

        End Set
    End Property
    Private oDescrRus As String
    ''' <summary>
    ''' описание узла на русском (или локальном для лузера)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property DescrRUS As String
        Get
            If oDescrRus Is Nothing Then oDescrRus = ""

            Return oDescrRus
        End Get
        Set(ByVal value As String)
            oDescrRus = value
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("DescrRUS"))

        End Set
    End Property
    Private oFullPath As String
    ''' <summary>
    ''' путь в дереве. НЕ ИСПОЛЬЗОВАТЬ для изменения иерархии. Для этого задать процедурой SetHierID(newfullpath) !!!
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property FullPath As String
        Get
            If oFullPath Is Nothing Then oFullPath = ""

            Return oFullPath
        End Get
        Set(ByVal value As String)
            oFullPath = value
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("FullPath"))

        End Set
    End Property
    Private oInfo As String
    ''' <summary>
    ''' справочник для лузера. Не добавляется в описание.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property info As String
        Get
            If oInfo Is Nothing Then oInfo = ""

            Return oInfo
        End Get
        Set(ByVal value As String)
            oInfo = value
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("info"))

        End Set
    End Property
    Private WithEvents oImage As NodeObject.clsImageList

    ''' <summary>
    ''' коллекция изображений. свойство tag - путь к папке с файлами
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property image As NodeObject.clsImageList
        Get
            Return oImage
        End Get
        Set(ByVal value As NodeObject.clsImageList)
            oImage = value
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("Image"))

        End Set
    End Property
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Private WithEvents oLink As Generic.Dictionary(Of String, List(Of Integer))
    ''' <summary>
    ''' коллекция связей = (Имя дерева -> коллекция ID узлов)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Link As Generic.Dictionary(Of String, List(Of Integer))
        Get
            'If oLink Is Nothing Then
            '    Return New Generic.Dictionary(Of String, List(Of Integer))
            'End If
            Return oLink
        End Get
        Set(ByVal value As Generic.Dictionary(Of String, List(Of Integer)))
            oLink = value
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("Link"))

        End Set
    End Property

    ''' <summary>
    ''' вернет имя узла на нужном языек (пока ru-RU, en-US)
    ''' </summary>
    Public Function NodeNameByCulture(ByVal culture As System.Globalization.CultureInfo) As String
        Debug.Assert(Not culture Is Nothing)
        Select Case culture.Name
            Case clsApplicationTypes.RussianCulture.Name
                If NameRUS.Length = 0 Then Return Name
                Return NameRUS
            Case clsApplicationTypes.EnglishCulture.Name
                Return Name
            Case Else
                Debug.Fail("operation for this culture name is missing")
                Return Name
        End Select
    End Function
    ''' <summary>
    ''' вернет описание на нужном языек (пока ru-RU, en-US)
    ''' </summary>
    Public Function GetDescriptionStringByCulture(ByVal culture As System.Globalization.CultureInfo) As String
        Debug.Assert(Not culture Is Nothing)
        Select Case culture.Name
            Case clsApplicationTypes.RussianCulture.Name
                If DescrRUS.Length = 0 Then Return Descr
                Return DescrRUS
            Case clsApplicationTypes.EnglishCulture.Name
                Return Descr
            Case Else
                Debug.Fail("operation for this culture name is missing")
                Return Descr
        End Select
    End Function


    Private Sub oImage_PropertyChanged(ByVal sender As Object, ByVal e As System.ComponentModel.PropertyChangedEventArgs) Handles oImage.PropertyChanged
        RaiseEvent PropertyChanged(sender, e)
    End Sub


    Public Overrides Function ToString() As String
        Return Me.Name
    End Function
End Class


'<Serializable()>
'Friend Class SerializableNodeObject
'    Implements INotifyPropertyChanged
'    Dim oid As Integer

'    ''' <summary>
'    '''  разбирает XML HierObj и изображения по ключу Name
'    ''' </summary>
'    ''' <param name="data"></param>
'    ''' <param name="images"></param>
'    ''' <returns></returns>
'    ''' <remarks></remarks>
'    Public Overloads Shared Function ParceFromXML(data As XElement, Optional ByVal images As Generic.Dictionary(Of Integer, NodeObject.clsImageList) = Nothing) As SerializableNodeObject
'        Dim _out As SerializableNodeObject = New SerializableNodeObject With {.id = data.@id, .Name = data...<name>.Value, .NameRUS = data...<nameRUS>.Value, .Descr = data...<descr>.Value, .DescrRUS = data...<descrRUS>.Value, .info = data...<info>.Value, .FullPath = data...<fullpath>.Value, .Link = Nothing, .image = If(images Is Nothing, Nothing, (From k In images Where k.Key = data.@id Select k.Value))}
'        Dim _link = New Dictionary(Of String, List(Of Integer))
'        For Each t In data...<Link>
'            If Not t.@name Is Nothing Then
'                Dim _key = t.@name
'                Dim _values As New List(Of Integer)
'                For Each k In t...<To>
'                    _values.Add(Integer.Parse(k.@nodeid))
'                Next
'                _link.Add(_key, _values)
'            End If
'        Next
'        _out.Link = _link
'        Return _out
'    End Function

'    Public Function GetAsXElement() As XElement
'        Dim _out As XElement = <HierObj id=<%= Me.id %>>
'                                   <name><%= Me.Name %></name>
'                                   <nameRUS><%= Me.NameRUS %></nameRUS>
'                                   <descr><%= Me.Descr %></descr>
'                                   <descrRUS><%= Me.DescrRUS %></descrRUS>
'                                   <info><%= Me.info %></info>
'                                   <fullpath><%= Me.FullPath %></fullpath>
'                                   <image><%= Not IsNothing(Me.image) %></image>
'                                   <%= If(IsNothing(Me.Link), <Link>false</Link>, From c In Me.Link Select <Link name=<%= c.Key %>><%= From c1 In c.Value Select <To nodeid=<%= c1 %>></To> %></Link>) %>
'                               </HierObj>
'        Return _out
'    End Function

'    Private Sub RaisePropertyChanged(ByVal propertyName As String)
'        Dim propertyChanged As System.ComponentModel.PropertyChangedEventHandler = Me.PropertyChangedEvent
'        If (Not (propertyChanged) Is Nothing) Then
'            propertyChanged(Me, New System.ComponentModel.PropertyChangedEventArgs(propertyName))
'        End If
'    End Sub

'    <NonSerialized()>
'    Public Event PropertyChanged(ByVal sender As Object, ByVal e As System.ComponentModel.PropertyChangedEventArgs) Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged
'    ''' <summary>
'    ''' ID узла
'    ''' </summary>
'    ''' <value></value>
'    ''' <returns></returns>
'    ''' <remarks></remarks>
'    Public Property id As Integer
'        Get
'            Return oid
'        End Get
'        Set(value As Integer)
'            oid = value
'            RaisePropertyChanged("id")
'        End Set
'    End Property

'    Private oDataFolder As String
'    ''' <summary>
'    ''' сюда пока пишется артикул в виде 123/256/12... (номера связанных узлов)
'    ''' </summary>
'    ''' <value></value>
'    ''' <returns></returns>
'    ''' <remarks></remarks>
'    Public Property DataFolder As String
'        Get
'            If oDataFolder Is Nothing Then oDataFolder = ""
'            Return oDataFolder
'        End Get
'        Set(value As String)
'            oDataFolder = value
'            RaisePropertyChanged("DataFolder")
'        End Set
'    End Property



'    Private oName As String
'    ''' <summary>
'    ''' имя узла английское
'    ''' </summary>
'    ''' <value></value>
'    ''' <returns></returns>
'    ''' <remarks></remarks>
'    Public Property Name As String
'        Get
'            If oName Is Nothing Then oName = ""
'            Return oName
'        End Get
'        Set(ByVal value As String)
'            oName = value
'            RaisePropertyChanged("Name")
'        End Set
'    End Property
'    Private oNameRus As String
'    ''' <summary>
'    ''' имя узла русское (локализовано для лузера)
'    ''' </summary>
'    ''' <value></value>
'    ''' <returns></returns>
'    ''' <remarks></remarks>
'    Public Property NameRUS As String
'        Get
'            If oNameRus Is Nothing Then oNameRus = ""

'            Return oNameRus
'        End Get
'        Set(ByVal value As String)
'            oNameRus = value
'            RaisePropertyChanged("NameRUS")
'        End Set
'    End Property
'    Private oDescr As String
'    ''' <summary>
'    ''' описание узла на английском
'    ''' </summary>
'    ''' <value></value>
'    ''' <returns></returns>
'    ''' <remarks></remarks>
'    Public Property Descr As String
'        Get
'            If oDescr Is Nothing Then oDescr = ""

'            Return oDescr
'        End Get
'        Set(ByVal value As String)
'            oDescr = value
'            RaisePropertyChanged("Descr")
'        End Set
'    End Property
'    Private oDescrRus As String
'    ''' <summary>
'    ''' описание узла на русском (или локальном для лузера)
'    ''' </summary>
'    ''' <value></value>
'    ''' <returns></returns>
'    ''' <remarks></remarks>
'    Public Property DescrRUS As String
'        Get
'            If oDescrRus Is Nothing Then oDescrRus = ""

'            Return oDescrRus
'        End Get
'        Set(ByVal value As String)
'            oDescrRus = value
'            RaisePropertyChanged("DescrRUS")
'        End Set
'    End Property
'    Private oFullPath As String
'    ''' <summary>
'    ''' путь в дереве. НЕ ИСПОЛЬЗОВАТЬ для изменения иерархии. Для этого задать процедурой SetHierID(newfullpath) !!!
'    ''' </summary>
'    ''' <value></value>
'    ''' <returns></returns>
'    ''' <remarks></remarks>
'    Public Property FullPath As String
'        Get
'            If oFullPath Is Nothing Then oFullPath = ""

'            Return oFullPath
'        End Get
'        Set(ByVal value As String)
'            oFullPath = value
'            RaisePropertyChanged("FullPath")
'        End Set
'    End Property
'    Private oInfo As String
'    ''' <summary>
'    ''' справочник для лузера. Не добавляется в описание.
'    ''' </summary>
'    ''' <value></value>
'    ''' <returns></returns>
'    ''' <remarks></remarks>
'    Public Property info As String
'        Get
'            If oInfo Is Nothing Then oInfo = ""

'            Return oInfo
'        End Get
'        Set(ByVal value As String)
'            oInfo = value
'            RaisePropertyChanged("info")
'        End Set
'    End Property
'    Private WithEvents oImage As NodeObject.clsImageList

'    ''' <summary>
'    ''' коллекция изображений. свойство tag - путь к папке с файлами
'    ''' </summary>
'    ''' <value></value>
'    ''' <returns></returns>
'    ''' <remarks></remarks>
'    Public Property image As NodeObject.clsImageList
'        Get
'            Return oImage
'        End Get
'        Set(ByVal value As NodeObject.clsImageList)
'            oImage = value
'            RaisePropertyChanged("Image")
'        End Set
'    End Property
'    ''' <summary>
'    ''' 
'    ''' </summary>
'    ''' <remarks></remarks>
'    Private WithEvents oLink As Generic.Dictionary(Of String, List(Of Integer))
'    ''' <summary>
'    ''' коллекция связей = (Имя дерева -> коллекция ID узлов)
'    ''' </summary>
'    ''' <value></value>
'    ''' <returns></returns>
'    ''' <remarks></remarks>
'    Public Property Link As Generic.Dictionary(Of String, List(Of Integer))
'        Get
'            Return oLink
'        End Get
'        Set(ByVal value As Generic.Dictionary(Of String, List(Of Integer)))
'            oLink = value
'            RaisePropertyChanged("Link")
'        End Set
'    End Property

'    ''' <summary>
'    ''' вернет имя узла на нужном языек (пока ru-RU, en-US)
'    ''' </summary>
'    Public Function NodeNameByCulture(ByVal culture As System.Globalization.CultureInfo) As String
'        Debug.Assert(Not culture Is Nothing)
'        Select Case culture.Name
'            Case clsApplicationTypes.RussianCulture.Name
'                If NameRUS.Length = 0 Then Return Name
'                Return NameRUS
'            Case clsApplicationTypes.EnglishCulture.Name
'                Return Name
'            Case Else
'                Debug.Fail("operation for this culture name is missing")
'                Return Name
'        End Select
'    End Function
'    ''' <summary>
'    ''' вернет описание на нужном языек (пока ru-RU, en-US)
'    ''' </summary>
'    Public Function GetDescriptionStringByCulture(ByVal culture As System.Globalization.CultureInfo) As String
'        Debug.Assert(Not culture Is Nothing)
'        Select Case culture.Name
'            Case clsApplicationTypes.RussianCulture.Name
'                If DescrRUS.Length = 0 Then Return Descr
'                Return DescrRUS
'            Case clsApplicationTypes.EnglishCulture.Name
'                Return Descr
'            Case Else
'                Debug.Fail("operation for this culture name is missing")
'                Return Descr
'        End Select
'    End Function


'    Private Sub oImage_PropertyChanged(ByVal sender As Object, ByVal e As System.ComponentModel.PropertyChangedEventArgs) Handles oImage.PropertyChanged
'        RaisePropertyChanged("Image")
'    End Sub
'    Public Overrides Function ToString() As String
'        Return Me.Name
'    End Function
'End Class



''' <summary>
''' представляет обьект дерева 
''' </summary>
''' <remarks></remarks>
<Serializable()>
Friend Class NodeObject
    Inherits SerializableNodeObject
    Implements IComparable
    Implements INotifyPropertyChanged
    Implements ICloneable

    <Serializable()>
    Public Class clsImageList
        Inherits List(Of Bitmap)
        Implements INotifyPropertyChanged
        Private Sub RaisePropertyChanged(ByVal propertyName As String)
            Dim propertyChanged As System.ComponentModel.PropertyChangedEventHandler = Me.PropertyChangedEvent
            If (Not (propertyChanged) Is Nothing) Then
                propertyChanged(Me, New System.ComponentModel.PropertyChangedEventArgs(propertyName))
            End If
        End Sub
        Public Shadows Sub Add(ByVal item As Bitmap)
            MyBase.Add(item)
            RaisePropertyChanged("Count")
        End Sub
        Public Shadows Function Remove(ByVal item As Bitmap) As Boolean
            Dim _t = MyBase.Remove(item)
            RaisePropertyChanged("Count")
            Return _t
        End Function
        Public Shadows Sub RemoveAt(ByVal index As Integer)
            MyBase.RemoveAt(index)
            RaisePropertyChanged("Count")
        End Sub

        Public Event PropertyChanged(ByVal sender As Object, ByVal e As System.ComponentModel.PropertyChangedEventArgs) Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged
    End Class

    ''' <summary>
    ''' представляет поддерево узлов. Добавлять только один корневой узел методом ADD. Читаются все его дети. Для вставки этого поддерева в другое дерево используйте функцию PasteMeIntoParentTree
    ''' </summary>
    ''' <remarks></remarks>
    ''' 
    <Serializable()>
    Public Class NodeObjectSubTree
        Inherits List(Of NodeObject)
        Implements IDisposable

        ''' <summary>
        ''' переопределяет метод добавления. rootnode - корневой узел поддерева. Читаются все дети из дерева rootnode.Parent. Добавить можно только один корневой узел.
        ''' </summary>
        ''' <param name="rootnode"></param>
        ''' <remarks></remarks>
        Public Shadows Function Add(rootnode As NodeObject, Optional ClearLink As Boolean = True) As Boolean
            If Me.Count > 0 Then Return False
            'добавим всех потомков данного узла
            Dim _result As New List(Of NodeObject)
            Me.AddChildrens(rootnode, _result)

            'очистить связи
            If ClearLink Then
                If Not rootnode.Link Is Nothing Then
                    rootnode.Link = Nothing
                End If

                For Each t In _result
                    If Not t.Link Is Nothing Then
                        t.Link = Nothing
                    End If
                Next
            End If


            MyBase.AddRange(_result)
            MyBase.Add(rootnode)
            'сортировка по HierID
            Me.RootNode = rootnode
            Return True
        End Function
        ''' <summary>
        ''' читает всех детей
        ''' </summary>
        ''' <param name="node"></param>
        ''' <param name="_result"></param>
        ''' <remarks></remarks>
        Private Sub AddChildrens(node As NodeObject, ByRef _result As List(Of NodeObject))
            For Each n In node.Parent.GetChildrens(node)
                _result.Add(n)
                AddChildrens(n, _result)
            Next
        End Sub


        ''' <summary>
        ''' кореневой узел поддерева
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property RootNode As NodeObject

        ''' <summary>
        ''' вывести отформатированую строку поддерева
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overrides Function ToString() As String
            'вывести отформатированую строку объекта
            'пока так
            Dim _out As String = ""
            For Each n In Me
                _out += n.Name & " --> "
            Next
            Return _out.TrimEnd(" --> ")
        End Function
        ''' <summary>
        ''' перемещает всех детей (поддерево) узла _oldId в узел _newId
        ''' </summary>
        ''' <param name="_oldId"></param>
        ''' <param name="_newId"></param>
        ''' <remarks></remarks>
        Private Sub MoveChild(ByVal _oldId As SqlHierarchyId, ByVal _newId As SqlHierarchyId)
            'выбрать всех с _oldId
            Dim _current = (From c In Me Where c.HierID.GetAncestor(1).Equals(_oldId)).ToList
            Dim _prev As SqlHierarchyId = Nothing
            For Each _gr In _current
                'сделать их потомками _newId
                _oldId = _gr.HierID
                _gr.HierID = _newId.GetDescendant(_prev, Nothing)
                _prev = _gr.HierID

                'рекурсия
                Dim _rec = (From c In Me Where c.HierID.GetAncestor(1).Equals(_oldId)).ToList
                If _rec.Count > 0 Then
                    Me.MoveChild(_oldId, _gr.HierID)
                End If
            Next
        End Sub

        ''' <summary>
        ''' устанавливает новый HierID для корня, корректируя соответственно HierID детей. Дерево для вставки - из ToNode.parent
        ''' </summary>
        ''' <param name="ToNode"></param>
        ''' <remarks></remarks>
        Public Sub PasteMeIntoParentTree(ToNode As NodeObject)
            Debug.Assert(Not ToNode.Parent Is Nothing)
            'восстановить HierID
            For Each n In Me
                n.SetHierID(n.FullPath)
            Next

            Dim _tree = ToNode.Parent
            Dim _oldID = Me.RootNode.HierID
            'исправить иерархию
            'найти последний потомок
            Dim _res = (From c In _tree.NodeCollection Where c.HierID.GetAncestor(1).Equals(ToNode.HierID) Select c.HierID)
            Dim _newrootHierID As SqlHierarchyId
            If _res.Count > 0 Then
                _newrootHierID = ToNode.HierID.GetDescendant(_res.Max, Nothing)
            Else
                _newrootHierID = ToNode.HierID.GetDescendant(Nothing, Nothing)
            End If

            ''теперь переделаем детей
            Me.MoveChild(_oldID, _newrootHierID)
            Me.RootNode.HierID = _newrootHierID

            'добавить узлы в дерево
            For Each n In Me
                _tree.AppendNode(n)
            Next
        End Sub

#Region "IDisposable Support"
        Private disposedValue As Boolean ' Чтобы обнаружить избыточные вызовы

        ' IDisposable
        Protected Overridable Sub Dispose(disposing As Boolean)
            If Not Me.disposedValue Then
                If disposing Then
                    ' TODO: освободить управляемое состояние (управляемые объекты).
                    RootNode = Nothing
                End If

                ' TODO: освободить неуправляемые ресурсы (неуправляемые объекты) и переопределить ниже Finalize().

                ' TODO: задать большие поля как null.
                RootNode = Nothing
            End If
            Me.disposedValue = True
        End Sub

        ' Этот код добавлен редактором Visual Basic для правильной реализации шаблона высвобождаемого класса.
        Public Sub Dispose() Implements IDisposable.Dispose
            ' Не изменяйте этот код. Разместите код очистки выше в Dispose(ByVal disposing As Boolean).
            Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub
#End Region

    End Class



    <NonSerialized()>
    Private oHierID As SqlHierarchyId

    ''' <summary>
    '''  разбирает XML HierObj и изображения по ключу Name
    ''' </summary>
    ''' <param name="data"></param>
    ''' <param name="images"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Shared Function ParceFromXML(data As XElement, Optional ByVal images As Generic.Dictionary(Of Integer, NodeObject.clsImageList) = Nothing) As SerializableNodeObject
        Dim _out As SerializableNodeObject = New SerializableNodeObject With {.id = data.@id, .Name = data...<name>.Value, .NameRUS = data...<nameRUS>.Value, .Descr = data...<descr>.Value, .DescrRUS = data...<descrRUS>.Value, .info = data...<info>.Value, .FullPath = data...<fullpath>.Value, .Link = Nothing, .image = If(images Is Nothing, Nothing, (From k In images Where k.Key = data.@id Select k.Value))}
        Dim _link = New Dictionary(Of String, List(Of Integer))
        For Each t In data...<Link>
            If Not t.@name Is Nothing Then
                Dim _key = t.@name
                Dim _values As New List(Of Integer)
                For Each k In t...<To>
                    _values.Add(Integer.Parse(k.@nodeid))
                Next
                _link.Add(_key, _values)
            End If
        Next
        _out.Link = _link
        Return _out
    End Function


    Public Function RemoveAllChildrens() As Boolean
        Dim _ch = Me.Parent.GetChildrens(Me)
        If _ch.Count > 0 Then
            For Each t In _ch
                Me.Parent.DeleteNode(t)
            Next
            Return True
        End If
        Return False
    End Function

    Public ReadOnly Property HasChildren As Boolean
        Get
            If Me.Parent.GetChildrens(Me).Count > 0 Then
                Return True
            Else
                Return False
            End If
        End Get
    End Property


    Public Property HierID As SqlHierarchyId
        Get
            Return oHierID
        End Get
        Set(ByVal value As SqlHierarchyId)
            Me.FullPath = value.ToString
            oHierID = value
        End Set
    End Property
    <NonSerialized()>
    Private oParent As ClsTree

    <NonSerialized()>
    Public Tag As Object

    Public Property Parent As ClsTree
        Get
            Return oParent
        End Get
        Set(ByVal value As ClsTree)
            oParent = value
        End Set
    End Property
    Public ReadOnly Property HasDataFolder As Boolean
        Get
            Return Me.Parent.Parent.TestDataFolderForNode(Me)
        End Get
    End Property
    Public ReadOnly Property HasLink As Boolean
        Get
            If IsNothing(Me.Link) Then Return False
            If Me.Link.Count = 0 Then Return False
            Return True
        End Get
    End Property
    Public ReadOnly Property HasImage As Boolean
        Get
            If IsNothing(Me.image) Then Return False
            If Me.image.Count = 0 Then Return False
            Return True
        End Get
    End Property
    ''' <summary>
    ''' вернет уровень узла в иерархии
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetLevel() As Integer
        Debug.Assert(IsDBNull(HierID) = False)
        Return HierID.GetLevel
    End Function
    ''' <summary>
    ''' переместит узел вверх (т.е. большее значение последнего числа в SqlHierarchyId)
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function MoveUp() As SqlHierarchyId
        Me.HierID = Me.HierID.GetAncestor(1).GetDescendant(Me.HierID, Nothing)
        Return Me.HierID
    End Function

    ''' <summary>
    '''  переместит узел вниз (т.е. меньшее значение последнего числа в SqlHierarchyId)
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function MoveDown() As SqlHierarchyId
        Me.HierID = Me.HierID.GetAncestor(1).GetDescendant(Nothing, Me.HierID)
        Return Me.HierID
    End Function
    ''' <summary>
    ''' вернет название папки для узла
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetDataFolderName() As String
        Return Me.id.ToString
    End Function
    ''' <summary>
    ''' первая версия, основана на названии узла [Name]_images
    ''' </summary>
    ''' <param name="imagefolder"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetDataFolderNameOLDTMP(imagefolder As Boolean) As String
        '_treeNode.Name & clsTreeManager.XMLImageFolderSuffics, _treeNode.Name & "_" & _counter & ".jpg"
        Select Case imagefolder
            Case True
                Return Me.Name & "_images"
            Case False
                Return Me.Name
        End Select
        Return Me.Name
    End Function

    Private Const _cntSplitter As Char = "/"

    ''' <summary>
    ''' вернет список сцепленных ID включая свой
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetTiedID() As List(Of Integer)
        Dim _out As New List(Of Integer)
        Dim _parse = Me.DataFolder.Split({_cntSplitter}, System.StringSplitOptions.RemoveEmptyEntries)
        If _parse Is Nothing Then Return _out
        If _parse.Length = 0 Then Return _out
        Dim _id As Integer
        For Each t In _parse
            'переберем id 
            If Integer.TryParse(t, _id) Then
                'найти узел
                _out.Add(_id)
            End If
        Next

        Return _out

    End Function


    ''' <summary>
    ''' вернет коллекцию сцепленных узлов. Пока разберет строку из DataFolder формата 152/256/144... Себя в коллекцию тоже включит!
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetTiedNodes() As List(Of NodeObject)
        Dim _out As New List(Of NodeObject)
        If Me.DataFolder Is Nothing Then Return _out
        If Me.DataFolder = "" Then Return _out

        Dim _parse = Me.DataFolder.Split({_cntSplitter}, System.StringSplitOptions.RemoveEmptyEntries)
        If _parse Is Nothing Then Return _out
        If _parse.Length = 0 Then Return _out
        Dim _id As Integer
        Dim _tmp As NodeObject
        For Each t In _parse
            'переберем id 
            If Integer.TryParse(t, _id) Then
                'найти узел
                _tmp = Me.Parent.Parent.FindNode(t)
                If Not _tmp Is Nothing Then
                    _out.Add(_tmp)
                End If
            End If
        Next

        Return _out

    End Function
    ''' <summary>
    ''' покажет, есть ли сцепленные узлы (артикулы)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property HasTiedNodes As Boolean
        Get
            If Me.DataFolder Is Nothing Then Return False
            If Me.DataFolder = "" Then Return False
            Return True
        End Get
    End Property
    ''' <summary>
    ''' установит коллекцию сцепленных узлов. Пока сделает строку в DataFolder формата 152/256/144... 
    ''' </summary>
    ''' <param name="nodes"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function SetTiedNodes(nodes As List(Of Integer)) As Boolean
        Debug.Assert(Not nodes Is Nothing)
        Debug.Assert(nodes.Count > 0)
        If nodes Is Nothing Then Return False
        If nodes.Count = 0 Then Return False

        Dim _out As String = ""
        For Each t In nodes
            _out += t & _cntSplitter
        Next

        _out = _out.TrimEnd(_cntSplitter)

        Me.DataFolder = _out

        Return True
    End Function


    ''' <summary>
    ''' установит коллекцию сцепленных узлов. Пока сделает строку в DataFolder формата 152/256/144... 
    ''' </summary>
    ''' <param name="nodes"></param>
    ''' <remarks></remarks>
    Public Overloads Function SetTiedNodes(nodes As List(Of NodeObject)) As Boolean
        Debug.Assert(Not nodes Is Nothing)
        Debug.Assert(nodes.Count > 0)
        If nodes Is Nothing Then Return False
        If nodes.Count = 0 Then Return False

        Dim _tmp = (From c In nodes Select c.id).ToList

        Return SetTiedNodes(_tmp)
        'Dim _out As String = ""
        'For Each t In nodes
        '    _out += t.id & _cntSplitter
        'Next

        '_out.TrimEnd(_cntSplitter)

        'Me.DataFolder = _out

        'Return True
    End Function
    ''' <summary>
    ''' удалит сцепленные узлы
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ClearTiedNodes()
        Me.DataFolder = ""
    End Sub

    ''' <summary>
    ''' создет корневой узел
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetRoot() As NodeObject
        Dim c As New NodeObject
        c.HierID = SqlHierarchyId.GetRoot
        c.Name = "Root Node"
        Return c
    End Function
    ''' <summary>
    ''' вернет связанный узел
    ''' </summary>
    ''' <param name="TreeName"></param>
    ''' <param name="NodeId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetLinkedNode(TreeName As String, NodeId As Integer) As NodeObject
        Debug.Assert(TreeName.Length > 0)
        Debug.Assert(NodeId >= 0)

        Dim _tree = Me.Parent.Parent.TreeCollection(TreeName)
        If IsNothing(_tree) Then Return Nothing
        Dim _node = _tree.Item(NodeId)
        If IsNothing(_node) Then Return Nothing
        Return _node
    End Function
    ''' <summary>
    ''' выберет все привязанные к дереву Tree узлы/ IncludeChierarchy задает включение всех дочерних узлов связанного узла
    ''' </summary>
    ''' <param name="Tree"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function GetLinkedNodesCollection(Tree As ClsTree, Optional IncludeChierarchy As Boolean = False) As List(Of NodeObject)
        'check parametr
        If Not Me.HasLink And IncludeChierarchy = False Then Return New List(Of NodeObject)
        Dim _manager = Me.Parent.Parent
        If _manager Is Nothing Then Return New List(Of NodeObject)
        If Tree Is Nothing Then Return New List(Of NodeObject)
        '-------------------


        Dim _res As New List(Of NodeObject)

        Select Case IncludeChierarchy
            Case True

                If Not Me.Link Is Nothing Then
                    'просмотреть связи текущего узла Ме
                    _res = (From c In Me.Link From c1 In c.Value Where (Not _manager.TreeCollection(c.Key) Is Nothing) And (c.Key = Tree.TreeKeyName) And (Not _manager.TreeCollection(c.Key).Item(c1) Is Nothing)
                                                 Select _manager.TreeCollection(c.Key).Item(c1)).ToList

                End If
                Dim _add As New List(Of NodeObject)
                'просмотреть связи дочерних узлов
                Dim _ch = Me.Parent.GetChildrens(Me)
                For Each _nd In Me.Parent.GetChildrens(Me)
                    If Not _nd.Link Is Nothing Then
                        _add = (From c In _nd.Link From c1 In c.Value Where (Not _manager.TreeCollection(c.Key) Is Nothing) And (c.Key = Tree.TreeKeyName) And (Not _manager.TreeCollection(c.Key).Item(c1) Is Nothing)
                                                                      Select _manager.TreeCollection(c.Key).Item(c1)).ToList

                        If _add.Count > 0 Then
                            _res.AddRange(_add)
                        End If
                    End If

                Next
                'If _res.Count = 0 Then

                'End If


            Case Else

                _res = (From c In Me.Link From c1 In c.Value Where (Not _manager.TreeCollection(c.Key) Is Nothing) And (c.Key = Tree.TreeKeyName) And (Not _manager.TreeCollection(c.Key).Item(c1) Is Nothing)
                                   Select _manager.TreeCollection(c.Key).Item(c1)).ToList
        End Select

        Return _res
    End Function



    ''' <summary>
    ''' выберет все связанные узлы 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function GetLinkedNodesCollection() As List(Of NodeObject)
        If Not Me.HasLink Then Return New List(Of NodeObject)
        Dim _manager = Me.Parent.Parent
        If _manager Is Nothing Then Return New List(Of NodeObject)
        Dim _res = (From c In Me.Link From c1 In c.Value Where (Not _manager.TreeCollection(c.Key) Is Nothing) And (Not _manager.TreeCollection(c.Key).Item(c1) Is Nothing)
                    Select _manager.TreeCollection(c.Key).Item(c1)).ToList
        Return _res
    End Function
    ''' <summary>
    ''' вернет обьект для сортировки массива NodeObject
    ''' </summary>
    ''' <param name="culture"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetComparisonObjectByCulture(culture As System.Globalization.CultureInfo) As System.Comparison(Of NodeObject)
        Dim _sort As System.Comparison(Of NodeObject)
        Select Case culture.Name
            Case clsApplicationTypes.RussianCulture.Name
                _sort = New System.Comparison(Of NodeObject)(Function(x As NodeObject, y As NodeObject) x.NameRUS.CompareTo(y.NameRUS))

            Case clsApplicationTypes.EnglishCulture.Name
                _sort = New System.Comparison(Of NodeObject)(Function(x As NodeObject, y As NodeObject) x.Name.CompareTo(y.Name))

            Case Else
                Debug.Fail("operation for this culture name is missing")
                _sort = New System.Comparison(Of NodeObject)(Function(x As NodeObject, y As NodeObject) x.Name.CompareTo(y.Name))

        End Select
        Return _sort
    End Function
    ''' <summary>
    ''' генерирует xElement для узла
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shadows Function GetAsXElement(culture As System.Globalization.CultureInfo, order As Integer) As XElement
        'получить список ссылок на фото
        Dim _imgUriList As New List(Of String)
        Dim _folderPath As String
        If Me.Parent.Parent.GetDataFolderRootPath.Length > 2 Then
            'путь задан
            _folderPath = Me.Parent.Parent.GetDataFolderPathForNode(Me.Parent, Me)
        Else
            _folderPath = ""
        End If


        If Not (IsNothing(Me.image) OrElse Me.image.Count = 0 OrElse _folderPath = "") Then
            For Each img In Me.image
                If Not (img.Tag Is Nothing OrElse img.Tag.ToString = "") Then
                    _imgUriList.Add(IO.Path.Combine(_folderPath, img.Tag))
                End If
            Next
        End If

        Dim _xml As XElement = <NODE order=<%= order %> nodeid=<%= Me.id %>>
                                   <%= Me.NodeNameByCulture(culture) %>
                                   <%= If(Me.GetDescriptionStringByCulture(culture) = "", Nothing, <DESCRIPTION><%= Me.GetDescriptionStringByCulture(culture) %></DESCRIPTION>) %>
                                   <%= If(Me.info = "", Nothing, <INFO><%= Me.info %></INFO>) %>
                                   <%= If(_imgUriList.Count = 0, Nothing, <IMAGES><%= From i In _imgUriList Select <IMG href=<%= i %>></IMG> %></IMAGES>) %>
                                   <%= If(Me.Link Is Nothing, Nothing, <LINKS><%= From i In Me.Link Select <LINK treename=<%= i.Key %>><%= From j In i.Value Select <NODEID value=<%= j %>></NODEID> %></LINK> %></LINKS>) %>
                               </NODE>
        Return _xml

    End Function
    ''' <summary>
    ''' создаст XML узла с иерархией на level уровней вверх
    ''' </summary>
    ''' <param name="Node"></param>
    ''' <param name="culture"></param>
    ''' <param name="level"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Shared Function CreateDescriptionElement(Node As NodeObject, culture As System.Globalization.CultureInfo, Optional level As Integer = -1) As XElement
        'предварительные условия
        If (From c1 In Node.Parent Where c1.HierID.GetLevel = 1 Select c1).Min Is Nothing Then
            Return clsTreeService.clsDescriptionElement.CreateInstance(Node.id, Node.Parent.Parent.LoadedGroupName, Node.Parent.RootNodeName, Node.Parent.RootNodeNameByCulture(culture), culture, "").GetXElement
        End If

        Dim _collNodes As New Generic.List(Of NodeObject)

        'выбрать всех предков данного узла
        'уровень предка
        'если уровень не задан - вернем все
        If level = -1 Then
            level = Node.GetLevel() - 1
        End If

        'добавить текущий узел
        _collNodes.Add(Node)
        'перебрать узлы вверх по дереву
        For _tl As Integer = 1 To level
            Dim _index = _tl
            Dim c = From t In Node.Parent Where t.HierID.Equals(Node.HierID.GetAncestor(_index)) Select t

            For Each c1 In c
                'если с1 не есть корень
                If Not c1.HierID.Equals(SqlHierarchyId.GetRoot) Then
                    'добавить соответствующий узел
                    _collNodes.Add(c1)
                End If
            Next
        Next

        'переставим все по порядку
        _collNodes.Reverse()
        Dim _out As New List(Of XElement)
        Dim _order As Integer = 1
        For Each nd In _collNodes
            _out.Add(nd.GetAsXElement(culture, _order))
            _order += 1
        Next

        Dim _xml = clsTreeService.clsDescriptionElement.CreateInstance(Node.id, Node.Parent.Parent.LoadedGroupName, Node.Parent.RootNodeName, Node.Parent.RootNodeNameByCulture(culture), culture, _out)

        Return _xml.GetXElement
    End Function

    ''' <summary>
    ''' формирует описание узла в виде XML 
    ''' </summary>
    ''' <param name="culture"></param>
    ''' <param name="level"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetDescriptionElement(culture As System.Globalization.CultureInfo, Optional level As Integer = -1) As XElement
        Return CreateDescriptionElement(Me, culture, level)

        ''если узел содержит артикул, то добавить в вывод описание всех узлов артикула!
        'If Me.HasTiedNodes Then
        '    'переставим все по порядку
        '    'Me.GetTiedNodes.Reverse()
        '    Dim _out As New List(Of XElement)
        '    Dim _order As Integer = 1
        '    For Each nd In Me.GetTiedNodes
        '        _out.Add(nd.GetAsXElement(culture, _order))
        '        _order += 1
        '    Next
        '    ''тут надо создать несколько элементов!!!!!
        '    Debug.Fail("переделать функцию!!!")
        '    Dim _xml = clsTreeService.clsDescriptionElement.CreateInstance(Me.id, Me.Parent.Parent.BlockName, Me.Parent.RootNodeName, Me.Parent.RootNodeNameByCulture(culture), culture, _out)
        '    Dim _out1 = _xml.GetXElement
        '    Return _xml.GetXElement

        'Else
        '    Return CreateDescriptionElement(Me, culture, level)
        'End If

        ''предварительные условия
        'If (From c1 In Me.Parent Where c1.HierID.GetLevel = 1 Select c1).Min Is Nothing Then
        '    Return clsTreeService.clsDescriptionElement.CreateInstance(Me.id, Me.Parent.Parent.BlockName, Me.Parent.RootNodeName, Me.Parent.RootNodeNameByCulture(culture), culture, "").GetXElement
        'End If

        'Dim _collNodes As New Generic.List(Of NodeObject)

        ''выбрать всех предков данного узла
        ''уровень предка
        ''если уровень не задан - вернем все
        'If level = -1 Then
        '    level = Me.GetLevel() - 1
        'End If

        ''добавить текущий узел
        '_collNodes.Add(Me)
        ''перебрать узлы вверх по дереву
        'For _tl As Integer = 1 To level
        '    Dim _index = _tl
        '    Dim c = From t In Me.Parent Where t.HierID.Equals(Me.HierID.GetAncestor(_index)) Select t

        '    For Each c1 In c
        '        'если с1 не есть корень
        '        If Not c1.HierID.Equals(SqlHierarchyId.GetRoot) Then
        '            'добавить соответствующий узел
        '            _collNodes.Add(c1)
        '        End If
        '    Next
        'Next

        ''переставим все по порядку
        '_collNodes.Reverse()
        'Dim _out As New List(Of XElement)
        'Dim _order As Integer = 1
        'For Each nd In _collNodes
        '    _out.Add(nd.GetAsXElement(culture, _order))
        '    _order += 1
        'Next

        'Dim _xml = clsTreeService.clsDescriptionElement.CreateInstance(Me.id, Me.Parent.Parent.BlockName, Me.Parent.RootNodeName, Me.Parent.RootNodeNameByCulture(culture), culture, _out)

        'Return _xml.GetXElement

    End Function

    'Friend Function GetDataFileNameForNode() As String
    '    'проверка расширения
    '    Dim _destExst = IO.Path.GetExtension(DataFileFullName)
    '    If _destExst.Length = 0 Then Return ""
    '    'генерация индекса
    '    Dim _destName = Me.Name
    '    Dim _index As Integer = 0
    '    Do While IO.File.Exists(IO.Path.Combine(_destination, _destName & "_" & _index.ToString & _destExst))
    '        _index += 1
    '    Loop
    '    'формируем имя
    '    _destName = _destName & "_" & _index.ToString & _destExst
    'End Function
    ''' <summary>
    ''' добавить связь. вернет -1=ошибка, 0=ссылка уже есть, 1=добавлено
    ''' </summary>
    ''' <param name="TreeName"></param>
    ''' <param name="NodeID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function AddLink(TreeName As String, NodeID As Integer) As Integer
        If Me.Link Is Nothing Then
            Me.Link = New Dictionary(Of String, List(Of Integer))
        End If
        'check tree name exists
        If Not Me.Link.ContainsKey(TreeName) Then
            'создать запись в словаре
            Me.Link.Add(TreeName, New List(Of Integer))
        End If
        'получить список ID
        If Me.Link.Item(TreeName).Contains(NodeID) Then
            'link already exist
            Return 0
        End If
        'добавить связь
        Me.Link.Item(TreeName).Add(NodeID)
        Return 1
    End Function
    ''' <summary>
    ''' добавить связь. вернет -1=ошибка, 0=ссылка уже есть, 1=добавлено
    ''' </summary>
    ''' <param name="node"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function AddLink(node As NodeObject) As Integer
        Return Me.AddLink(node.Parent.TreeKeyName, node.id)
    End Function
    ''' <summary>
    ''' проверит связь 
    ''' </summary>
    ''' <param name="node"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function TestLink(node As NodeObject) As Boolean
        Return Me.TestLink(node.Parent.TreeKeyName, node.id)
    End Function

    Public Overrides Function ToString() As String
        If Me.HasLink Then
            Return String.Format("{0}({1})", Me.Name, Me.Link.Count)
        Else
            Return String.Format("{0}(0)", Me.Name)
        End If
    End Function

    ''' <summary>
    ''' проверит связь 
    ''' </summary>
    ''' <param name="TreeName"></param>
    ''' <param name="NodeID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function TestLink(TreeName As String, NodeID As Integer) As Boolean
        If IsNothing(Me.Link) Then Return False
        If Not Me.Link.ContainsKey(TreeName) Then Return False
        If IsNothing(Me.Link.Item(TreeName)) Then Return False
        If Not Me.Link.Item(TreeName).Contains(NodeID) Then Return False
        Return True
    End Function
    ''' <summary>
    ''' удалить все связи к определенному дереву
    ''' </summary>
    ''' <param name="TreeName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function RemoveLink(TreeName As String) As Boolean
        If IsNothing(Me.Link) Then Return False
        If Not Me.Link.ContainsKey(TreeName) Then Return False
        Me.Link.Remove(TreeName)
        Return True
    End Function

    ''' <summary>
    ''' удалить связь
    ''' </summary>
    ''' <param name="TreeName"></param>
    ''' <param name="NodeID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function RemoveLink(TreeName As String, NodeID As Integer) As Boolean
        'проверить наличие связи
        If Me.TestLink(TreeName, NodeID) Then
            'удалить исходящую связь
            Me.Link.Item(TreeName).Remove(NodeID)
            If Me.Link.Item(TreeName).Count = 0 Then
                Me.Link.Remove(TreeName)
            End If
            Return True
        End If
        Return False
    End Function

    ''' <summary>
    ''' удалить связь
    ''' </summary>
    ''' <param name="node"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function RemoveLink(node As NodeObject) As Boolean
        Return RemoveLink(node.Parent.TreeKeyName, node.id)
    End Function
    ''' <summary>
    ''' вернет имя связанного узла
    ''' </summary>
    ''' <param name="TreeName"></param>
    ''' <param name="NodeId"></param>
    ''' <param name="culture"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetLinkedNameByCulture(TreeName As String, NodeId As Integer, ByVal culture As System.Globalization.CultureInfo) As String
        Debug.Assert(Not culture Is Nothing)
        Dim _node = GetLinkedNode(TreeName, NodeId)
        If IsNothing(_node) Then Return ""
        Return _node.NodeNameByCulture(culture)
    End Function
    Public Function AsSerializableNode() As SerializableNodeObject
        Return Me
    End Function

    ''' <summary>
    ''' создать узел без ID
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CreateNewNodeWithoutID(ByVal Name As String, ByVal FullPath As String) As NodeObject
        Debug.Assert(Name.Length > 0)
        Debug.Assert(FullPath.Length > 0)

        Dim _new = New NodeObject
        _new.Name = Name
        _new.FullPath = FullPath
        _new.SetHierID(FullPath)
        Return _new
    End Function

    ''' <summary>
    ''' создать узел из хранимых данных (node). Параметр (tree) нужен для установки родителя узла и обработчика событий изменения, который будет включен, если задать параметр PropretyChangedEventOn=true. 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CreateFromSerializableNode(node As SerializableNodeObject, tree As ClsTree, PropretyChangedEventOn As Boolean) As NodeObject
        Debug.Assert(Not tree Is Nothing)
        Dim _n As NodeObject
        _n = New NodeObject
        With _n
            .Descr = node.Descr
            .DescrRUS = node.DescrRUS
            .Name = node.Name
            .NameRUS = node.NameRUS
            .id = node.id
            If Not node.FullPath = "" Then
                .SetHierID(node.FullPath)
            End If
            .info = node.info
            .image = node.image

            .DataFolder = node.DataFolder
            .Link = node.Link
            .Parent = tree

            If PropretyChangedEventOn And (Not tree Is Nothing) Then
                AddHandler .PropertyChanged, AddressOf tree.NodeChangedEventHandler
            End If
        End With
        Return _n
    End Function

    ''' <summary>
    ''' Устанавливает иерархическое свойство, разбирая переданный текстом уровень
    ''' </summary>
    ''' <param name="FullPath">уровень узла</param>
    ''' <remarks></remarks>
    Public Sub SetHierID(ByVal FullPath As String)
        Debug.Assert(FullPath <> "")
        Me.HierID = SqlHierarchyId.Parse(FullPath)
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        Me.image = New NodeObject.clsImageList
    End Sub



    Public Function CompareTo(ByVal obj As Object) As Integer Implements System.IComparable.CompareTo
        If obj Is Nothing Then Return 0
        If Not obj.GetType = Me.GetType Then Return 0
        If CType(obj, NodeObject).oHierID.Equals(Me.oHierID) Then Return 0
        If CType(obj, NodeObject).oHierID > Me.oHierID Then Return -1
        Return 1
    End Function
    ''' <summary>
    ''' сравнивает ID и name
    ''' </summary>
    ''' <param name="obj"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overrides Function Equals(obj As Object) As Boolean
        If obj Is Nothing Then Return False
        If Not obj.GetType = Me.GetType Then Return False
        If Not CType(obj, NodeObject).id = (Me.id) Then Return False
        If Not CType(obj, NodeObject).Name.Equals(Me.Name) Then Return False
        Return True
    End Function
    ''' <summary>
    ''' берет хеш от ID и name
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overrides Function GetHashCode() As Integer
        Dim _a = Me.id.GetHashCode
        Dim _b = Me.Name.GetHashCode
        Return _a Xor _b
    End Function
    ''' <summary>
    ''' копирует обьект. SetAsRoot сбрасывает HierID в адрес корневого узла. PropertyChangedEventOn включает отслеживание событий изменения свойств для нового обьекта.
    ''' </summary>
    ''' <param name="SetAsRoot"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function Clone(SetAsRoot As Boolean, PropertyChangedEventOn As Boolean) As NodeObject
        Dim _new = Me.AsSerializableNode

        Dim _snew = NodeObject.CreateFromSerializableNode(_new, Me.Parent, PropertyChangedEventOn)
        If SetAsRoot Then
            _snew.SetHierID(NodeObject.GetRoot.FullPath)
        End If

        Return _snew
    End Function

    Private Overloads Function Clone() As Object Implements ICloneable.Clone
        Dim _new = Me.AsSerializableNode
        Dim _snew = NodeObject.CreateFromSerializableNode(_new, Me.Parent, True)
        Return _snew
    End Function
End Class



Friend Class ClsTree
    Inherits List(Of NodeObject)
    Implements INotifyPropertyChanged

    Private Sub New(Parent As clsTreeManager)
        oParent = Parent
    End Sub
    ''' <summary>
    ''' добавляет узел к коллекции НЕ ИЗМЕНЯЯ HierID, т.е. в дерево он будет не включен!
    ''' </summary>
    ''' <param name="item"></param>
    ''' <remarks></remarks>
    Private Overloads Sub Add(ByVal item As NodeObject)
        Debug.Assert(Not item Is Nothing)
        item.Parent = Me
        MyBase.Add(item)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("Add"))
    End Sub

    Public Event NodeNameCorrected(sender As Object, e As EventArgs)

    Public Sub OnNodeNameCorrected()

        RaiseEvent NodeNameCorrected(Me, EventArgs.Empty)
    End Sub

    Public Event PropertyChanged(ByVal sender As Object, ByVal e As System.ComponentModel.PropertyChangedEventArgs) Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged
    Public ReadOnly Property NodeCollection As List(Of NodeObject)
        Get
            Return Me.ToList
        End Get
    End Property
    ''' <summary>
    ''' вернет имя корневого узла (Название дерева = root узла)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property RootNodeName As String
        Get
            Return Me.RootNode.Name
        End Get
    End Property


    ''' <summary>
    ''' возвращает (Название дерева = root узла) дерева в соотв. с культурой
    ''' </summary>
    ''' <param name="culture"></param>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property RootNodeNameByCulture(ByVal culture As System.Globalization.CultureInfo) As String
        Get
            Dim _node = Me.RootNode
            If Not _node Is Nothing Then
                Return _node.NodeNameByCulture(culture)
            Else
                Return "No root"
            End If
        End Get
    End Property

    Public Property CurrentNodeID As Integer
        Get
            'запросить из БД ID
            Return oCurrentNodeID
        End Get
        Set(value As Integer)
            oCurrentNodeID = value
        End Set
    End Property



    ''' <summary>
    ''' вернет ID для нового узла, изменит значение внутреннего счетчика!
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Function GetNodeIDForNewNode() As Integer
        oCurrentNodeID = oCurrentNodeID + 1
        Return oCurrentNodeID
    End Function

    ''' <summary>
    ''' вернет корневой узел дерева
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property RootNode As NodeObject
        Get
            Return Me.Item(SqlHierarchyId.GetRoot)
        End Get
    End Property
    ''' <summary>
    ''' вернет все оконечные листья дерева(без детей)
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetLeafNodes(Optional ByVal culture As System.Globalization.CultureInfo = Nothing, Optional FilterNode As NodeObject = Nothing) As List(Of NodeObject)
        Dim _result As New List(Of NodeObject)
        If culture Is Nothing Then culture = clsTreeManager.EnglishCulture

        Select Case IsNothing(FilterNode)
            Case True
                _result = (From q1 In Me Where q1.HasTiedNodes Select q1).ToList

            Case Else
                If FilterNode.Parent.TreeKeyName = Me.TreeKeyName Then
                    'мы находимся в том же дереве, что и узел фильтра
                    'создадим только лист этого узла!
                    _result = (From q1 In Me, q2 In FilterNode.GetLinkedNodesCollection(Me, True) Where (q2.Equals(q1))
                                     Select q1).ToList

                    'If _result.Count = 0 Then

                    'End If
                    _result.Add(FilterNode)
                Else
                    'применить фильтр по связям
                    'задан фильтр
                    'если q2(узел в связях) является потомком тестируемого узла q1
                    _result = (From q1 In Me, q2 In FilterNode.GetLinkedNodesCollection(Me, True) Where (q2.Equals(q1))
                                      Select q1).ToList

                End If

        End Select

        _result.Sort(NodeObject.GetComparisonObjectByCulture(culture))

        Dim _m = _result.ToArray
        Return _result
    End Function
    ''' <summary>
    ''' запишет в WithoutChildren все бездетные узлы
    ''' </summary>
    ''' <param name="node"></param>
    ''' <param name="_WithoutChildren"></param>
    ''' <remarks></remarks>
    Private Sub GetNodesWithoutChildren(node As NodeObject, ByRef _WithoutChildren As List(Of NodeObject))
        Dim _res = Me.GetChildrens(node)
        If _res.Count = 0 Then
            _WithoutChildren.Add(node)
            Exit Sub
        Else
            For Each t In _res
                Call GetNodesWithoutChildren(t, _WithoutChildren)
            Next
        End If
    End Sub
    ''' <summary>
    ''' вернет предка узла. Если предака нет, вернет сам узел
    ''' </summary>
    ''' <param name="node"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetParentNode(node As NodeObject) As NodeObject
        Dim _HierID As SqlHierarchyId = Nothing
        _HierID = node.HierID.GetAncestor(1)
        If _HierID.IsNull Then Return node
        Return Me.Item(_HierID)
    End Function

    ''' <summary>
    ''' выдает список детей входящего узла. если детей нет, то вернется пустая коллекция
    ''' </summary>
    ''' <param name="node"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetChildrens(node As NodeObject) As List(Of NodeObject)
        Dim _HierID As SqlHierarchyId = Nothing
        Dim _out As New List(Of NodeObject)

        Do
            _HierID = node.HierID.GetDescendant(_HierID, Nothing)
            If Not Me.Item(_HierID) Is Nothing Then
                _out.Add(Me.Item(_HierID))
            Else
                'потомков после _HierID нет
                Exit Do
            End If
        Loop
        'в _out находится коллекция детей узла _node
        Return _out
    End Function

    Private oName As String

    ''' <summary>
    ''' имя коллекции. !работает как ID!
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property TreeKeyName As String
        Get
            Return oName
        End Get
        Set(ByVal value As String)
            Dim _old As String = oName
            oName = value
            If (Not _old = "") And (Not _old = value) Then
                RaiseEvent TreeNameChanged(Me, New TreeNameChangedEventArgs(_old, value))
            End If
        End Set
    End Property

    Private oNameRUS As String = ""

    ''' <summary>
    ''' имя коллекции в русском (Не использовать для отображаемых значений (используй rootnodename)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property TreeKeyNameRUS As String
        Get
            If oNameRUS.Length > 0 Then
                Return oNameRUS
            Else
                'вернем корневой узел
                Return (From c In Me.NodeCollection Where c.HierID.Equals(SqlHierarchyId.GetRoot) Select c.NameRUS).FirstOrDefault
            End If


        End Get
        Set(ByVal value As String)
            'сдесь нельзя вызывать событие TreeNameChanged, поскольку оно нужно для синхронизации коллекции деревьев в менеджере
            If value Is Nothing Then value = ""
            oNameRUS = value
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("NameRUS"))
            'Dim _old As String = oNameRUS
            'If (Not _old = "") And (Not _old = value) Then
            '    RaiseEvent TreeNameChanged(Me, New TreeNameChangedEventArgs(_old, value))
            'End If
        End Set
    End Property



    Private oParent As clsTreeManager

    Public ReadOnly Property Parent As clsTreeManager
        Get
            Return oParent
        End Get
    End Property

    ''' <summary>
    ''' получить узел по его SqlHierarchyId
    ''' </summary>
    ''' <param name="HierId"></param>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads ReadOnly Property Item(ByVal HierId As SqlHierarchyId) As NodeObject
        Get
            Dim s = (From c In Me Where c.HierID.Equals(HierId) Select c).ToList

            Select Case s.Count
                Case 0
                    Return Nothing
                Case 1
                    Return s.First
                Case Is > 1
                    Debug.Fail("Более одного элемента с одинаковым SqlHierarchyId")
                    'исправить ошибку
                    s(1).HierID = Me.CorrectHierID(s(0).HierID)
                    Return s(0)
            End Select
            Return Nothing
        End Get
    End Property
    ''' <summary>
    ''' получить узел по его ID
    ''' </summary>
    ''' <param name="Id"></param>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads ReadOnly Property Item(ByVal Id As Integer) As NodeObject
        Get
            Dim s = (From c In Me Where c.id = Id Select c).ToList
            Select Case s.Count
                Case 0
                    Return Nothing
                Case 1
                    Return s.First
                Case Is > 1
                    Debug.Fail("Более одного элемента с одинаковым ID")
                    'исправить ошибку
                    s(1).id = Me.GetNodeIDForNewNode
                    Return s(0)
            End Select
            Return Nothing
        End Get
    End Property
    ''' <summary>
    ''' вернет узел по имени (первый)
    ''' </summary>
    ''' <param name="Name"></param>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads ReadOnly Property Item(ByVal Name As String) As NodeObject
        Get
            Dim s = (From c In Me Where c.Name = Name Select c).ToList
            Select Case s.Count
                Case 0
                    Return Nothing
                Case 1
                    Return s.First
                Case Is > 1
                    Return s.First
            End Select
            Return Nothing
        End Get
    End Property

    Public Event TreeNameChanged(ByVal sender As Object, ByVal e As TreeNameChangedEventArgs)

    Public Class TreeNameChangedEventArgs
        Inherits EventArgs
        Public Property OldName As String
        Public Property NewName As String
        Public Sub New(ByVal _oldname As String, ByVal _newname As String)
            Me.OldName = _oldname
            Me.NewName = _newname
        End Sub

    End Class
    ''' <summary>
    ''' вернет список сериализуемых обьектов 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetAsSerializableList() As List(Of SerializableNodeObject)
        Dim _list = New List(Of SerializableNodeObject)
        For Each t In Me
            _list.Add(t)
        Next
        Return _list
    End Function
    ''' <summary>
    ''' поучить каталог дерева. DataFolderPath задает путь к фото
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetAsCatalog(ByVal culture As System.Globalization.CultureInfo, Optional ByVal WithImage As Boolean = False, Optional RelativeImages As Boolean = False) As CATALOG
        'источник узлов
        Dim _source As List(Of NodeObject) = Me.GetLeafNodes(culture)
        'пере.сортировка по описанию - узлы в файле сортируются по шапке с ID
        _source.Sort(NodeObject.GetComparisonObjectByCulture(culture))

        'каталог
        Dim _catalog As CATALOG = CATALOG.CreateInstance(Date.Now.ToShortDateString, Me.TreeKeyName, Me.RootNodeNameByCulture(culture), "ID:")
        Dim _node As CATALOGSAMPLE

        Select Case culture.IetfLanguageTag
            Case clsApplicationTypes.EnglishCulture.Name
                For Each _treeNode In _source
                    _node = _catalog.AddSample(_treeNode.id.ToString, Service.clsApplicationTypes.emCatalogFolderType.shot)
                    With _node
                        'Dim _name = _elem.GetNodeDescription(culture)
                        .AddDataElement("Name", _treeNode.NodeNameByCulture(culture), CATALOGSAMPLEELEMENT.emPosition.title, "Node ID " & _treeNode.id)
                        .AddDataElement("FullName", clsApplicationTypes.ParseNodeXML(_treeNode.GetDescriptionElement(culture), , False), CATALOGSAMPLEELEMENT.emPosition.info, "Full node value")
                        If Not _treeNode.Descr Is Nothing AndAlso _treeNode.Descr.Length > 0 Then
                            .AddDataElement("ENGdescription", _treeNode.Descr, CATALOGSAMPLEELEMENT.emPosition.down, "Description")
                        End If
                        'If _treeNode.info.Length > 1 Then
                        '    .AddDataElement("Info", _treeNode.info, Catalog.CATALOGSAMPLEELEMENT.emPosition.down, "Info")
                        'End If
                        'link_to
                        'создать связи внутри каталога
                        'имеем - название xml файла и id элемента.
                        'загрузить xml и выбрать элемент
                        If Not IsNothing(_treeNode.Link) Then
                            For Each _tree In _treeNode.Link
                                Dim _file = _tree.Key & ".htm"
                                For Each _link In _tree.Value
                                    Dim _href = _file & "#" & _link

                                    'получить имя связанного узла
                                    Dim _xl = IO.Path.Combine(Me.Parent.GetDataFolderRootPath, Me.Parent.DataBlockName, _tree.Key & ".xml")

                                    Dim _linkAlt As String = _tree.Key & ": "
                                    If IO.File.Exists(_xl) Then
                                        Dim _lk = _link
                                        Dim _xe = XElement.Load(_xl)
                                        Dim _res = (From q In _xe.Elements Where q.@id = _lk Select q).FirstOrDefault

                                        If Not IsNothing(_res) Then
                                            _linkAlt += _res...<name>.Value
                                        Else
                                            _linkAlt += "not exist linked file"
                                        End If

                                    End If
                                    'вставить линк связи
                                    Dim _de = CATALOGSAMPLEELEMENT.CreateDataElement("Link", _linkAlt, CATALOGSAMPLEELEMENT.emPosition.down, "Linked")
                                    _de.AddEnviropment(_href, "", CATALOGSAMPLEELEMENTENVIRONMENT.emEnviropmentType.html)
                                    .AddDataElement(_de)
                                Next
                            Next
                        End If

                        'images
                        If (Not _treeNode.image Is Nothing) And (WithImage) Then
                            Dim _counter As Integer = 0
                            For Each img In _treeNode.image
                                Dim _src As String
                                If RelativeImages Then
                                    _src = IO.Path.Combine(Me.GetDataFileContainerRelativePath(_treeNode), _treeNode.Name & "_" & _counter & ".jpg")
                                Else
                                    _src = IO.Path.Combine(clsApplicationTypes.TreeFolderPath, Me.GetDataFileContainerRelativePath(_treeNode), _treeNode.Name & "_" & _counter & ".jpg")
                                End If

                                .AddSampleImage(_src, True)
                                If RelativeImages Then
                                    If Not .IMAGES Is Nothing Then
                                        .IMAGES.titleimage = "relative"
                                    End If

                                Else
                                    If Not .IMAGES Is Nothing Then
                                        .IMAGES.titleimage = "absolute"
                                    End If

                                End If
                                _counter += 1
                            Next
                        End If
                    End With
                Next

                '=============РУССКИЙ===================================
            Case clsApplicationTypes.RussianCulture.Name
                For Each _elem In _source
                    _node = _catalog.AddSample(_elem.id.ToString, Service.clsApplicationTypes.emCatalogFolderType.shot)
                    With _node
                        'Dim _name = _elem.GetNodeDescription(culture)
                        .AddDataElement("NameRus", _elem.NodeNameByCulture(culture), CATALOGSAMPLEELEMENT.emPosition.title, "Узел ID " & _elem.id)
                        .AddDataElement("FullName", clsApplicationTypes.ParseNodeXML(_elem.GetDescriptionElement(culture), , False), CATALOGSAMPLEELEMENT.emPosition.info, "Полное значение узла")
                        If Not _elem.DescrRUS Is Nothing AndAlso _elem.DescrRUS.Length > 0 Then
                            .AddDataElement("RUSdescription", _elem.DescrRUS, CATALOGSAMPLEELEMENT.emPosition.down, "Описание")
                        End If

                        'If _elem.info.Length > 1 Then
                        '    .AddDataElement("Info", _elem.info, Catalog.CATALOGSAMPLEELEMENT.emPosition.down, "Справочник")
                        'End If
                        'link_to
                        'создать связи внутри каталога
                        'имеем - название xml файла и id элемента.
                        'загрузить xml и выбрать элемент
                        If Not IsNothing(_elem.Link) Then
                            For Each _tree In _elem.Link
                                Dim _file = _tree.Key & ".html"
                                For Each _link In _tree.Value
                                    Dim _href = _file & "#" & _link

                                    'получить имя связанного узла
                                    Dim _xl = IO.Path.Combine(Me.Parent.GetDataFolderRootPath, Me.Parent.DataBlockName, _tree.Key & ".xml")

                                    Dim _linkAltRus As String = _tree.Key & ": "
                                    If IO.File.Exists(_xl) Then
                                        Dim _lk = _link
                                        Dim _xe = XElement.Load(_xl)
                                        Dim _res = (From q In _xe.Elements Where q.@id = _lk Select q).FirstOrDefault

                                        If Not IsNothing(_res) Then
                                            _linkAltRus += _res...<nameRUS>.Value
                                            If _linkAltRus.Length = 0 Then
                                                _linkAltRus = "нет названия на русском"
                                            End If
                                        Else
                                            _linkAltRus += "связанный файл не найден"
                                        End If

                                    End If
                                    'вставить линк связи
                                    Dim _de = CATALOGSAMPLEELEMENT.CreateDataElement("Link", _linkAltRus, CATALOGSAMPLEELEMENT.emPosition.down, "Cвязан")
                                    _de.AddEnviropment(_href, "", CATALOGSAMPLEELEMENTENVIRONMENT.emEnviropmentType.html)
                                    .AddDataElement(_de)
                                Next

                            Next
                        End If
                        'images
                        If (Not _elem.image Is Nothing) And (WithImage) Then
                            Dim _counter As Integer = 0
                            For Each img In _elem.image
                                Dim _src As String
                                If RelativeImages Then
                                    _src = IO.Path.Combine(Me.GetDataFileContainerRelativePath(_elem), _elem.Name & "_" & _counter & ".jpg")

                                Else
                                    _src = IO.Path.Combine(clsApplicationTypes.TreeFolderPath, Me.GetDataFileContainerRelativePath(_elem), _elem.Name & "_" & _counter & ".jpg")

                                End If

                                .AddSampleImage(_src, True)
                                If RelativeImages Then
                                    If Not .IMAGES Is Nothing Then
                                        .IMAGES.titleimage = "relative"
                                    End If

                                Else
                                    If Not .IMAGES Is Nothing Then
                                        .IMAGES.titleimage = "absolute"
                                    End If

                                End If
                                _counter += 1
                            Next
                        End If
                    End With
                Next

            Case Else
                Throw New NotImplementedException
        End Select


        Return _catalog

    End Function

    ''' <summary>
    ''' получить xml документ дерева. В imageCollection лежит [ID узла], {коллекция фото}
    ''' </summary>
    ''' <param name="imageCollection"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetAsXMLDocument(Optional ByRef imageCollection As Generic.Dictionary(Of Integer, List(Of Bitmap)) = Nothing) As XDocument
        Dim _coll = Me.GetAsSerializableList
        '.AddDataElement("FullName", clsTreeService.ParseNodeXML(_elem.GetDescriptionElement(culture), , False), Catalog.CATALOGSAMPLEELEMENT.emPosition.info, "Полное значение узла")
        Dim _xml As XElement = <DATA name=<%= Me.TreeKeyName %> nameRUS=<%= Me.TreeKeyNameRUS %>>
                                   <%= From q In _coll Select <HierObj id=<%= q.id %>>
                                                                  <name><%= q.Name %></name>
                                                                  <nameRUS><%= q.NameRUS %></nameRUS>
                                                                  <descr><%= q.Descr %></descr>
                                                                  <descrRUS><%= q.DescrRUS %></descrRUS>
                                                                  <info><%= q.info %></info>
                                                                  <fullpath><%= q.FullPath %></fullpath>
                                                                  <image><%= Not IsNothing(q.image) %></image>
                                                                  <%= If(IsNothing(q.Link), <Link>false</Link>, From c In q.Link Select <Link name=<%= c.Key %>><%= From c1 In c.Value Select <To nodeid=<%= c1 %>></To> %></Link>) %>

                                                              </HierObj> %>
                               </DATA>


        Dim _doc = New XDocument(New XDeclaration("1.0", "windows-1251", "yes"), _xml)

        'коллекция изображений
        If Not imageCollection Is Nothing Then
            'заполним ее фото
            For Each q In _coll
                If Not q.image Is Nothing Then
                    imageCollection.Add(q.id, q.image)
                End If
            Next
        End If


        'MsgBox(_doc.ToString(Xml.Linq.SaveOptions.None))

        Return _doc

    End Function
    ''' <summary>
    ''' разбирает XML и изображения по ключу Name
    ''' </summary>
    ''' <param name="xml"></param>
    ''' <param name="images"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ParseFromXML(Parent As clsTreeManager, ByVal xml As XElement, Optional ByVal images As Generic.Dictionary(Of Integer, NodeObject.clsImageList) = Nothing) As ClsTree

        'TODO проверка документа

        Dim _obj As ClsTree
        Dim _hierobjColl As List(Of SerializableNodeObject)
        '----------------------
        Try

            If images Is Nothing Then
                _hierobjColl = (From q In xml.Elements Select New SerializableNodeObject With {.id = q.@id, .Name = q...<name>.Value, .NameRUS = q...<nameRUS>.Value, .Descr = q...<descr>.Value, .DescrRUS = q...<descrRUS>.Value, .info = q...<info>.Value, .FullPath = q...<fullpath>.Value, .Link = Nothing}).ToList
            Else
                Dim _imagelist = New NodeObject.clsImageList

                _hierobjColl = (From q In xml.Elements Select New SerializableNodeObject() With {.id = q.@id, .Name = q...<name>.Value, .NameRUS = q...<nameRUS>.Value, .Descr = q...<descr>.Value, .DescrRUS = q...<descrRUS>.Value, .info = q...<info>.Value, .FullPath = q...<fullpath>.Value, .Link = Nothing, .image = (From k In images Where k.Key = q.@id Select k.Value).FirstOrDefault}).ToList
            End If


            If _hierobjColl Is Nothing Then Return Nothing
            If _hierobjColl.Count = 0 Then Return Nothing

            _obj = ClsTree.CreateFromSerializableNodeList(_hierobjColl)

            _obj.oName = xml.@name
            _obj.TreeKeyNameRUS = ""
            _obj.oParent = Parent

            Return _obj

        Catch ex As Exception
            MsgBox("Не удалось разобрать дерево: " & ex.Message, vbCritical)
            Return Nothing
        End Try



    End Function

    'Public Shared Function CreateFromNodeObjectList(ByVal _list As List(Of NodeObject), Optional TreeManager As clsTreeManager = Nothing) As ClsTree
    '    Debug.Assert(Not _list Is Nothing)
    '    Debug.Assert(_list.Count > 0)
    '    Dim _tree = New ClsTree(TreeManager)
    '    For Each _n In _list
    '        AddHandler _n.PropertyChanged, AddressOf _tree.NodeChangedEventHandler
    '        _tree.Add(_n)
    '    Next
    '    _tree.oCurrentNodeID = (From t1 In _list Select t1.id).Max + 1
    '    Return _tree
    'End Function


    ''' <summary>
    ''' преобразует SerializableNodeObject в NodeObject
    ''' </summary>
    ''' <param name="_list"></param>
    ''' <remarks></remarks>
    Public Shared Function CreateFromSerializableNodeList(ByVal _list As List(Of SerializableNodeObject), Optional TreeManager As clsTreeManager = Nothing) As ClsTree
        Debug.Assert(Not _list Is Nothing)
        Debug.Assert(_list.Count > 0)
        Dim _tree = New ClsTree(TreeManager)
        Dim _n As NodeObject
        For Each _snode In _list
            If _snode.FullPath = "" Then GoTo label
            _n = NodeObject.CreateFromSerializableNode(_snode, _tree, True)
            _tree.Add(_n)
            'установить максимальный id+1
            'TODO запросить ID из БД!!!!
            _tree.oCurrentNodeID = (From t1 In _list Select t1.id).Max + 1
label:
        Next

        Return _tree
    End Function
    ''' <summary>
    ''' ловит изменение свойств
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Friend Sub NodeChangedEventHandler(ByVal sender As Object, ByVal e As PropertyChangedEventArgs)
        Select Case e.PropertyName
            Case "Name"
                'изменили имя узла
                'изменить имя папки!
                'Dim _folder = Me.Parent.GetDataFolderPathForNode(Me, CType(sender, NodeObject), False)

        End Select

        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("Tree"))
    End Sub



    ''' <summary>
    ''' текущий (последний использованный) ID. для нового узла необходимо прибавить еденицу!
    ''' </summary>
    ''' <remarks></remarks>
    Private oCurrentNodeID As Integer
    ''' <summary>
    ''' создает дерево, делая переданный узел корнем дерева. ID сохраняется. ChangPropertyEventOn - true - догда будет подключен обработчик изменения свойств узлов в дереве
    ''' </summary>
    ''' <param name="TreeName"></param>
    ''' <param name="Node"></param>
    ''' <param name="Parent"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CreateEmptyTreeFromNode(ByVal TreeName As String, ByVal Node As NodeObject, Optional Parent As clsTreeManager = Nothing, Optional ChangPropertyEventOn As Boolean = True) As ClsTree
        Dim ch = New ClsTree(Parent)
        ch.TreeKeyName = TreeName
        'надо изменить адрес узла на корень
        'корень
        Dim _node = Node.Clone(True, ChangPropertyEventOn)
        ch.oCurrentNodeID = _node.id
        ch.Add(_node)
        Return ch
    End Function

    ''' <summary>
    ''' создает пустое дерево с корнем
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CreateEmptyTree(Parent As clsTreeManager, ByVal Name As String) As ClsTree
        Dim ch = New ClsTree(Parent)
        ch.TreeKeyName = Name
        'корень
        Dim s = NodeObject.GetRoot
        'установит корневой узел в Имя Дерева
        s.Name = Name
        ch.oCurrentNodeID = 0
        s.id = 0
        ch.Add(s)
        Return ch
    End Function
    ' ''' <summary>
    ' ''' создать узел
    ' ''' </summary>
    ' ''' <returns></returns>
    ' ''' <remarks></remarks>
    'Private Overloads Shared Function CreateNode(ByVal Name As String, ByVal FullPath As String) As NodeObject
    '    Debug.Assert(Name.Length > 0)
    '    Debug.Assert(FullPath.Length > 0)

    '    Dim _new = New NodeObject
    '    _new.Name = Name
    '    _new.FullPath = FullPath
    '    _new.SetHierID(FullPath)
    '    Return _new
    'End Function

    'Public Overloads Shared Function CreateNode(ByVal parentNode As SqlHierarchyId, ByVal Name As String, Optional ByVal prevNode As SqlHierarchyId = Nothing) As NodeObject
    '    Debug.Assert(IsDBNull(parentNode) = False)
    '    Dim _new = NodeObject.CreateNewNodeWithoutID(Name, parentNode.GetDescendant(prevNode, Nothing).ToString)
    '    '

    '    Return _new

    'End Function

    ''' <summary>
    ''' создать id и добавить узел в коллекцию БЕЗ HIERID!PreserveID отменяет автоматическую нумерацию ID
    ''' </summary>
    ''' <param name="s"></param>
    ''' <remarks></remarks>
    Friend Sub AppendNode(ByVal s As NodeObject, Optional PreserveID As Boolean = False)
        Debug.Assert(Not s Is Nothing)
        Debug.Assert(s.FullPath.Length > 0, "свойство FullPath должно быть задано.")
        s.Parent = Me
        If PreserveID Then
            If s.id = 0 Then
                s.id = Me.GetNodeIDForNewNode
            End If
        Else
            s.id = Me.GetNodeIDForNewNode
        End If

        Me.Add(s)
    End Sub
    ''' <summary>
    ''' добавить узел NewNode в тот же уровень после узла ToNode. Вернет новый узел. 
    ''' </summary>
    ''' <param name="ToNode"></param>
    ''' <param name="NewNode"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function AddSameLevelToNode(ByVal ToNode As NodeObject, ByVal NewNode As NodeObject) As NodeObject
        Debug.Assert(IsDBNull(ToNode) = False)
        Dim _corrNodeHierID = Me.CorrectHierID(ToNode.HierID)
        If _corrNodeHierID.IsNull Then
            Debug.Fail("Неверное использование функции AddSameLevelToNode")
            Return Nothing
        End If

        NewNode.SetHierID(_corrNodeHierID.ToString)
        Me.AppendNode(NewNode)
        Return NewNode
    End Function

    ''' <summary>
    ''' добавить новый пустой узел с именем name в тот же уровень после узла ToNode 
    ''' </summary>
    ''' <param name="ToNode"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function AddSameLevelToNode(ByVal ToNode As NodeObject, ByVal name As String) As NodeObject
        Debug.Assert(IsDBNull(ToNode) = False)
        Dim _corrNodeHierID = Me.CorrectHierID(ToNode.HierID)
        If _corrNodeHierID.IsNull Then
            Debug.Fail("Неверное использование функции AddSameLevelToNode")
            Return Nothing
        End If
        Dim _new = NodeObject.CreateNewNodeWithoutID(name, _corrNodeHierID.ToString)
        Me.AppendNode(_new)
        Return _new
    End Function
    ''' <summary>
    ''' добавить предка узла node  с именем name
    ''' </summary>
    ''' <param name="ToNode"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function AddAncesorNode(ByVal ToNode As NodeObject, ByVal name As String) As NodeObject
        Debug.Assert(IsDBNull(ToNode.HierID) = False)
        '------найти предка
        Dim _parent = Me.Item(ToNode.HierID.GetAncestor(1))
        If _parent Is Nothing Then Return Nothing
        'создать новый узел для предка
        Dim _new = Me.AddChildrenToNode(_parent, name)
        If _new Is Nothing Then Return Nothing

        Dim _oldID = ToNode.HierID
        'получить и установить новый адрес для входящего узла = он будет первый, т.к. узел новый
        ToNode.HierID = _new.HierID.GetDescendant(Nothing, Nothing)
        'переместить детей входящего узла
        Me.MoveChild(_oldID, ToNode.HierID)

        Return _new
    End Function
    ''' <summary>
    ''' добавить потомка NewNode к узлу ToNode. PreserveID отменяет автоматическую нумерацию ID
    ''' </summary>
    ''' <param name="ToNode"></param>
    ''' <param name="NewNode"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function AddChildrenToNode(ByVal ToNode As NodeObject, ByVal NewNode As NodeObject, Optional PreserveID As Boolean = False) As NodeObject
        Debug.Assert(IsDBNull(ToNode.HierID) = False)
        'после него добавить дочерний узел
        NewNode.SetHierID(GetPathToChildren(ToNode))
        Me.AppendNode(NewNode, PreserveID)
        Return NewNode
    End Function
    ''' <summary>
    ''' вспомогательная функция к AddChildrenToNode
    ''' </summary>
    ''' <param name="ToNode"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetPathToChildren(ByVal ToNode As NodeObject) As String
        Debug.Assert(IsDBNull(ToNode.HierID) = False)
        'выбрать всех потомков узла
        Dim s = From c In Me Where c.HierID.GetAncestor(1).Equals(ToNode.HierID) Select c
        Dim _append As SqlHierarchyId
        'если потомков нет - добавить первый дочерний узел
        Dim _chil As SqlHierarchyId = ToNode.HierID
        If s.Count > 0 Then
            'выбрать самого последнего потомка
            _chil = s.Max().HierID
            _append = ToNode.HierID.GetDescendant(_chil, Nothing)
        Else
            'добавить первый дочерний узел
            _append = ToNode.HierID.GetDescendant(Nothing, Nothing)
        End If
        Return _append.ToString
    End Function

    ''' <summary>
    ''' добавить пустого потомка с именем Name к узлу ToNode 
    ''' </summary>
    ''' <param name="ToNode"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function AddChildrenToNode(ByVal ToNode As NodeObject, ByVal name As String) As NodeObject
        Debug.Assert(IsDBNull(ToNode.HierID) = False)
        'после него добавить дочерний узел
        Dim _new = NodeObject.CreateNewNodeWithoutID(name, GetPathToChildren(ToNode))
        Me.AppendNode(_new)
        Return _new
    End Function
    ''' <summary>
    ''' создать узлы для ЭУ дерево
    ''' </summary>
    ''' <param name="culture"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CreateNodesForTreeView(Optional ByVal culture As System.Globalization.CultureInfo = Nothing, Optional CreateLeaf As Boolean = False, Optional FilterNode As NodeObject = Nothing) As List(Of TreeNode)

        For Each t In Me
            t.Tag = Nothing
        Next

        Dim _nodeCollection As New List(Of NodeObject)

        If culture Is Nothing Then culture = clsApplicationTypes.EnglishCulture
        'покажем все узлы дерева
        'найти корень (или корни)
        Dim _test = New SqlHierarchyId
        'т.е. те узлы, у которых предок = null  c1.HierID.GetLevel = 1
        _nodeCollection = (From c1 In Me Where c1.HierID.GetAncestor(1).Equals(_test) Select c1).ToList

        Select Case IsNothing(FilterNode)
            Case True
                'временно для исправления старых огрехов создать корень дерева!! найти корень по-старому, первый уровень
                If _nodeCollection.Count = 0 Then
                    _nodeCollection = (From c1 In Me Where c1.HierID.GetLevel = 1 Select c1).ToList
                    If _nodeCollection.Count > 0 Then
                        Dim _new = NodeObject.CreateNewNodeWithoutID("Root", "/")
                        Me.AppendNode(_new)
                        _nodeCollection = (From c1 In Me Where c1.HierID.GetAncestor(1).Equals(_test) Select c1).ToList
                    End If
                End If

            Case Else
                If FilterNode.Parent.TreeKeyName = Me.TreeKeyName Then
                    'мы находимся в том же дереве, что и узел фильтра
                    'создадим только лист этого узла!
                    CreateLeaf = True
                Else
                    'применить фильтр по связям
                    'задан фильтр
                    'если q2(узел в связях) является потомком тестируемого узла q1
                    Dim _tmp = FilterNode.GetLinkedNodesCollection(Me, True)

                    _nodeCollection = (From q1 In _nodeCollection, q2 In _tmp Where (q2.HierID.IsDescendantOf(q1.HierID)) Group By _obj = q1 Into _cnt = Group Select _obj).ToList

                    'Debug.Assert(_nodeCollection.Count > 0, "коллекция корневых узлов не может быть пустой!")

                End If
        End Select

        'сортировка коллекции
        _nodeCollection.Sort(NodeObject.GetComparisonObjectByCulture(culture))

        'создать узлы
        Dim _treeViewNodeList As New List(Of TreeNode)

        Dim _result As Integer = 0
        Select Case CreateLeaf
            Case False
                'обычная обработка
                For Each _tmpNode In _nodeCollection
                    'создать узел для каждого корня
                    Dim _ntr = Me.CreateTreeNode(_tmpNode, culture)
                    _treeViewNodeList.Add(_ntr)
                    _result += 1
                    'посмотреть детей
                    Me.CreateChildrenNodesForTree(_tmpNode, _ntr, culture, _result, FilterNode)
                Next

                '---------проверка на потерянные (не отраженные в дереве узлы)
                If Me.Count <> _result And _treeViewNodeList.Count > 0 Then
                    Select Case IsNothing(FilterNode)
                        Case True
                            ''------создать пустую коллекцию
                            'создать узел 
                            Dim _unBoundedRootNode = New TreeNode()
                            With _unBoundedRootNode
                                .Name = "UNBOUNDED"
                                .Tag = Nothing
                                .BackColor = Color.Red
                            End With


                            'проверим наличие узлов в дереве
                            'For Each _node In Me
                            '    Dim _r As Boolean = False
                            '    SearchNodeInTree(_node, _treeViewNodeList(0), _r)
                            '    If _r = False Then
                            '        'добавим узел в UNBOUNDED
                            '        _unBoundedRootNode.Nodes.Add(Me.CreateTreeNode(_node, culture))
                            '    End If
                            'Next
                            For Each _node In Me
                                If _node.Tag Is Nothing Then
                                    'добавим узел в UNBOUNDED
                                    _unBoundedRootNode.Nodes.Add(Me.CreateTreeNode(_node, culture))
                                End If
                            Next
                            Select Case culture.IetfLanguageTag
                                Case clsTreeManager.EnglishCulture.IetfLanguageTag
                                    _unBoundedRootNode.Text = "UNBOUNDED (" & (Me.Count - _result).ToString & ")!"
                                Case clsTreeManager.RussianCulture.IetfLanguageTag
                                    _unBoundedRootNode.Text = "Не включены в дерево (" & (Me.Count - _result).ToString & ")!"
                            End Select

                            _treeViewNodeList(0).Nodes.Add(_unBoundedRootNode)
                            _treeViewNodeList(0).BackColor = Color.Red

                        Case Else
                            'в случае фильтра непривязанными останутся узлы без фильтра
                            Dim _unBoundedRootNode = New TreeNode()
                            With _unBoundedRootNode

                                .Name = "FILTERED"
                                .Tag = Nothing
                                .BackColor = Color.Red
                            End With


                            'проверим наличие узлов в дереве
                            Dim _count As Integer = 0
                            For Each _node In Me
                                If _node.Tag Is Nothing And _node.HasTiedNodes Then
                                    'добавим узел в UNBOUNDED
                                    _unBoundedRootNode.Nodes.Add(Me.CreateTreeNode(_node, culture))
                                    _count += 1
                                End If
                            Next

                            Select Case culture.IetfLanguageTag
                                Case clsTreeManager.EnglishCulture.IetfLanguageTag
                                    _unBoundedRootNode.Text = "Filtered nodes (" & _count.ToString & ")"
                                Case clsTreeManager.RussianCulture.IetfLanguageTag
                                    _unBoundedRootNode.Text = "Отфильтрованные узлы (" & _count.ToString & ")"
                            End Select


                            'For Each _node In Me
                            '    Dim _r As Boolean = False
                            '    SearchNodeInTree(_node, _treeViewNodeList(0), _r)
                            '    If _r = False And _node.HasTiedNodes Then
                            '        'добавим узел c артикулом в FILTERED
                            '        _unBoundedRootNode.Nodes.Add(Me.CreateTreeNode(_node, culture))
                            '    End If
                            'Next
                            _treeViewNodeList(0).Nodes.Add(_unBoundedRootNode)

                    End Select


                End If
                '--------------------------
            Case True
                'обработка при показе листьев
                For Each _tmpNode In Me.GetLeafNodes(culture, FilterNode)
                    'создать узел для каждого корня
                    Dim _ntr = Me.CreateTreeNode(_tmpNode, culture)
                    _treeViewNodeList.Add(_ntr)
                Next
        End Select


        Return _treeViewNodeList

    End Function
    ''' <summary>
    ''' ищет узел в узле дерева
    ''' </summary>
    ''' <param name="Node"></param>
    ''' <param name="_tree"></param>
    ''' <param name="_result"></param>
    ''' <remarks></remarks>
    Private Sub SearchNodeInTree(Node As NodeObject, _tree As Windows.Forms.TreeNode, ByRef _result As Boolean)
        If _tree.Tag Is Nothing Then _result = False : Exit Sub
        If _tree.Tag.Equals(Node) Then
            _result = True
            Exit Sub
        End If

        If _tree.Nodes.Count = 0 Then
            '_result = False
            Exit Sub
        End If

        For Each _dc As Windows.Forms.TreeNode In _tree.Nodes
            Call SearchNodeInTree(Node, _dc, _result)
        Next

    End Sub




    ''' <summary>
    ''' создает лист дерева, в tag лежит обьект NodeObject
    ''' </summary>
    ''' <param name="_node"></param>
    ''' <param name="culture"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CreateTreeNode(ByRef _node As NodeObject, ByVal culture As System.Globalization.CultureInfo) As TreeNode
        'создать узел для каждого корня
        Dim _ntr = New TreeNode()
        _node.Tag = _ntr
        With _ntr
            .Text = _node.NodeNameByCulture(culture)
            .Name = _node.Name
            .Tag = _node
            'при наличии фоток добавим скобки с кол-вом
            If _node.HasImage Then
                '.NodeFont = New Font("Microsoft Sans Serif", 8, FontStyle.Bold)
                .Text += "(" & _node.image.Count & ")"
            End If
            'при наличии связей текст будет зеленым
            If _node.HasLink Then
                .ForeColor = Color.Green
                '_ntr.NodeFont = New Font("Microsoft Sans Serif", 8, FontStyle.Bold)
            End If

            'при наличии артикула  для узла, шрифт будет подчеркнут
            If _node.HasTiedNodes Then
                .NodeFont = New Font("Microsoft Sans Serif", 8, FontStyle.Underline)
            End If
        End With
        Return _ntr
    End Function

    ''' <summary>
    ''' искать детей переданного обьекта (он уже добавлен в дерево)
    ''' </summary>
    ''' <param name="NodeObj">узел БД</param>
    ''' <param name="TreeNode">узел ЭУ</param>
    ''' <param name="FilterNode">узел, по связям которого фильтруется дерево</param>
    ''' <remarks></remarks>
    Private Sub CreateChildrenNodesForTree(ByVal NodeObj As NodeObject, ByRef TreeNode As TreeNode, ByVal culture As System.Globalization.CultureInfo, Optional ByRef _result As Integer = 0, Optional FilterNode As NodeObject = Nothing)
        Debug.Assert(Not NodeObj Is Nothing)
        Debug.Assert(Not TreeNode Is Nothing)
        Debug.Assert(Not culture Is Nothing)
        Dim _childrenNodes As New List(Of NodeObject)

        Select Case IsNothing(FilterNode)
            Case True
                'выбрать всех детей узла коллекции
                _childrenNodes = (From q1 In Me Where q1.HierID.GetAncestor(1).Equals(NodeObj.HierID) Select q1).ToList
            Case Else
                'задан фильтр
                'если q2(узел в связях) является потомком тестируемого узла q1
                Dim _tmp = FilterNode.GetLinkedNodesCollection(Me, True)
                _childrenNodes = (From q1 In Me, q2 In _tmp Where (q1.HierID.GetAncestor(1).Equals(NodeObj.HierID)) And (q2.HierID.IsDescendantOf(q1.HierID)) Group By _obj = q1 Into _cnt = Group
                                  Select _obj).ToList
        End Select



        If _childrenNodes.Count = 0 Then
            'у NodeObj детей нет - возврат
            Exit Sub
        Else
            'сортировка коллекции
            _childrenNodes.Sort(NodeObject.GetComparisonObjectByCulture(culture))
            'создать узлы для детей
            For Each t In _childrenNodes
                'создать дочерний узел дерева
                'создать узел для каждого корня
                Dim _ntr = Me.CreateTreeNode(t, culture)
                TreeNode.Nodes.Add(_ntr)
                'прибавить результат
                _result += 1
                'проверить внуков (рекурсия)
                Me.CreateChildrenNodesForTree(t, _ntr, culture, _result, FilterNode)
            Next
        End If

    End Sub
    ''' <summary>
    ''' копирует узел и добавляет его в дерево в той же плоскости (новый ID)
    ''' </summary>
    ''' <param name="node"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CopyNode(node As NodeObject) As NodeObject
        Dim _new = node.Clone(False, True)
        Return Me.AddSameLevelToNode(node, _new)
    End Function


    ''' <summary>
    ''' удалить узел 
    ''' </summary>
    Public Function DeleteNode(ByVal node As NodeObject) As Boolean
        Debug.Assert(IsDBNull(node) = False)

        'проверка на повтор HierID
        Dim _count As Integer = 0
        Dim t = (From q In Me Where q.HierID.Equals(node.HierID) Select q).ToList
        'в t лежат узлы с требуемым hierID
        If t.Count > 1 Then
            Debug.Fail("Обнаружено более одного узла к удалению. Удаление отменено.")
            'исправим дерево
            'первый - это корректный ID
            For i = 1 To t.Count - 1
                t(i).HierID = Me.CorrectHierID(t(0).HierID)
            Next
            Return False
        End If




        'найти узел-родитель удаляемого
        Dim _parentNode = (From c In Me Where c.HierID.Equals(node.HierID.GetAncestor(1)) Select c).ToList.FirstOrDefault
        If _parentNode Is Nothing Then
            Debug.Fail("Не удалось получить корректного родителя узла. Удаление отменено.")
            Return False
        End If
        'удалить узел из коллекции
        Me.Remove(node)
        'найти у удаляемого братьев сверху
        'они есть - перемещаем
        Dim _nex = node.HierID
        Dim _test As NodeObject
        Do
            _test = (From c In Me Where c.HierID.Equals(_parentNode.HierID.GetDescendant(_nex, Nothing)) Select c).ToList.FirstOrDefault
            If Not _test Is Nothing Then
                'рекурсия
                _nex = _test.HierID
                _test.MoveDown()
            End If
        Loop Until _test Is Nothing

        'переместить(прицепить) поддерево к узлу родителя 
        If Not _parentNode Is Nothing Then
            Me.MoveSubTree(node, _parentNode)
        End If

        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("Delete"))

        Return True
    End Function
    ''' <summary>
    ''' ищет узлы в соответствии с поисковым выражением. просматривает две культуры
    ''' </summary>
    ''' <param name="pattern"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SearchNode(pattern As String) As List(Of NodeObject)
        Dim _out As New List(Of NodeObject)
        _out.AddRange(Me.SearchNodeByCulture(pattern, clsApplicationTypes.EnglishCulture))
        _out.AddRange(Me.SearchNodeByCulture(pattern, clsApplicationTypes.RussianCulture))
        Return _out
    End Function


    ''' <summary>
    ''' ищет узлы в соответствии с поисковым выражением
    ''' </summary>
    ''' <param name="pattern"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SearchNodeByCulture(pattern As String, culture As System.Globalization.CultureInfo) As List(Of NodeObject)

        If culture Is Nothing Then
            culture = clsTreeManager.EnglishCulture
        End If

        Dim _result As New List(Of NodeObject)
        Select Case culture.Name
            Case clsApplicationTypes.RussianCulture.Name
                _result = (From c In Me Where FindFrase(c.NameRUS, pattern) Select c).ToList
                If _result.Count = 0 Then
                    _result = (From c In Me Where FindFrase(c.Name, pattern) Select c).ToList
                End If
            Case clsApplicationTypes.EnglishCulture.Name
                _result = (From c In Me Where FindFrase(c.Name, pattern) Select c).ToList
                If _result.Count = 0 Then
                    _result = (From c In Me Where FindFrase(c.NameRUS, pattern) Select c).ToList
                End If
            Case Else
                Debug.Fail("operation for this culture name is missing")


        End Select
        Return _result
    End Function
    ''' <summary>
    ''' ищет выражение в словах
    ''' </summary>
    ''' <param name="Name"></param>
    ''' <param name="Pattern"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function FindFrase(Name As String, Pattern As String) As Boolean
        Dim _instr = Name.ToLower
        Dim _ptt = Pattern.ToLower

        'бьем на слова
        Dim _worlds = _instr.Split(" ".ToCharArray, System.StringSplitOptions.RemoveEmptyEntries)
        If Not _worlds Is Nothing Then
            For Each w In _worlds
                If w.StartsWith(_ptt) Then Return True
            Next
        End If

        Return False

    End Function




    ''' <summary>
    ''' перемещает поддерево, ИСКЛЮЧАЯ сам FromNode (чтобы его переместить, установите флаг IncludeFromObj) в дочерний узел toNode
    ''' </summary>
    ''' <param name="FromNode"></param>
    ''' <param name="toNode"></param>
    ''' <remarks></remarks>
    Public Function MoveSubTree(ByVal FromNode As NodeObject, ByVal toNode As NodeObject, Optional ByVal IncludeFromNode As Boolean = False) As SqlHierarchyId
        'исправим HierID 
        If FromNode.HierID.IsNull Then
            FromNode.SetHierID(FromNode.FullPath)
        End If

        Dim mainId As SqlHierarchyId

        If IncludeFromNode Then
            'переместим сам обьект
            'планируемый новый id узла
            Dim _HierId = FromNode.HierID.GetReparentedValue(FromNode.HierID.GetAncestor(1), toNode.HierID)
            'проверим, сколько уже есть с таким id и 
            Dim _res = (From c In Me Where c.HierID.Equals(_HierId)).ToList
            Dim _oldId = FromNode.HierID
            If _res.Count > 0 Then
                'есть красавцы - возьмем последний для исправления id
                _HierId = Me.CorrectHierID(_res.Last.HierID)
            Else
                'нет конкурентов - но надо проверить, чтобы он был следующий за существующими детьми
                If Me.GetChildrens(toNode).Count > 0 Then
                    'дети есть
                    'найти с макс. hierID
                    Dim _result = Me.GetChildrens(toNode).Max.HierID
                    _HierId = Me.CorrectHierID(_result)
                Else
                    'детей нет
                    'установить level=1
                    _HierId = toNode.HierID.GetDescendant(Nothing, Nothing)
                End If
            End If
            mainId = _HierId
        Else
            mainId = toNode.HierID
        End If

        ''отобрать узлы, родителем которых является FromNode
        Dim _children = (From c In Me Where c.HierID.GetAncestor(1).Equals(FromNode.HierID) Select c).ToList
        'переместить детей (поддерево)
        For Each chi In _children
            'планируемый новый id узла
            'Dim _id = chi.HierID.GetReparentedValue(FromNode.HierID, toNode.HierID)
            Dim _id = chi.HierID.GetReparentedValue(FromNode.HierID, mainId)

            'проверим, сколько уже есть с таким id и 
            Dim _res = (From c In Me Where c.HierID.Equals(_id)).ToList
            Dim _oldId = chi.HierID
            If _res.Count > 0 Then
                'есть красавцы - возьмем последний для исправления id
                _id = Me.CorrectHierID(_res.Last.HierID)
            Else
                'нет конкурентов
            End If
            'присвоим новый id
            chi.HierID = _id
            'переместим поддерево
            Me.MoveChild(_oldId, _id)
        Next

        If IncludeFromNode Then
            FromNode.HierID = mainId
        End If

    End Function

    ''' <summary>
    ''' перемещает всех ДЕТЕЙ (поддерево) узла _oldId в узел _newId. 
    ''' </summary>
    ''' <param name="_oldId"></param>
    ''' <param name="_newId"></param>
    ''' <remarks></remarks>
    Public Sub MoveChild(ByVal _oldId As SqlHierarchyId, ByVal _newId As SqlHierarchyId)
        'выбрать всех, у кого предок = _oldId
        Dim _current = (From c In Me Where c.HierID.GetAncestor(1).Equals(_oldId)).ToList
        Dim _prev As SqlHierarchyId = Nothing
        'сделать их потомками _newId
        For Each _gr In _current
            _oldId = _gr.HierID
            _gr.HierID = _newId.GetDescendant(_prev, Nothing)
            'переместить детей = рекурсия
            MoveChild(_oldId, _gr.HierID)
            _prev = _gr.HierID
        Next
    End Sub

    ''' <summary>
    ''' перемещает узел в одной плоскости за узел RightNode (т.е. делает больше, чем RightNode)
    ''' </summary>
    ''' <param name="RightNode"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Overloads Function CorrectHierID(ByVal RightNode As SqlHierarchyId) As SqlHierarchyId
        'берем старшего брата правильного узла
        Dim s As New List(Of SqlHierarchyId)
        Dim nextNode = RightNode
        Do
            'взять предка
            nextNode = RightNode.GetAncestor(1).GetDescendant(nextNode, Nothing)
            'если он пустой, то его и вернем
            s = (From c In Me Where c.HierID.Equals(nextNode) Select c.HierID).ToList
        Loop Until s.Count = 0
        Return nextNode
    End Function



    ''' <summary>
    ''' добавить изображение в узел
    ''' </summary>
    Public Function AttachImage(ByVal Node As NodeObject, ByVal Image As Image, ImageName As String) As Boolean
        Debug.Assert(IsDBNull(Node.HierID) = False)
        'выбрать узел
        Dim s = (From c In Me Where c.HierID.Equals(Node.HierID) Select c).ToList
        Debug.Assert(s.Count > 0, "попытка добавить фото в несуществующий узел")
        Debug.Assert(s.Count = 1, "обнаружено более одного узла с одним SqlHierarchyId")
        'это временная операция коррекции hierID
        If s.Count = 2 Then
            s(1).HierID = Me.CorrectHierID(s(0).HierID)
        End If
        Dim _no = s.First

        If IsNothing(_no) = False Then
            If IsNothing(_no.image) Then
                _no.image = New NodeObject.clsImageList
            End If
            'запомнить имя файла
            Image.Tag = ImageName
            _no.image.Add(Image)
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("Image"))
            Return True
        End If

        Return False

    End Function

    ''' <summary>
    ''' вернет имя xml файла для дерева
    ''' </summary>
    Public Function GetXMLFileName() As String
        Return Me.TreeKeyName & ".xml"
    End Function

    Public Overrides Function ToString() As String
        Return Me.TreeKeyName
    End Function




    ''' <summary>
    ''' вернет пару для дерева (имя, (старый ID,новый ID)/ требуется корректировка связей!!!
    ''' </summary>
    ''' <param name="initialId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Function CorrectIdTMP(initialId As Integer, ByRef LastFreeId As Integer) As KeyValuePair(Of String, Dictionary(Of Integer, Integer))
        Dim _out As New Dictionary(Of Integer, Integer)
        Dim _NewId As Integer = initialId
        For Each _node In Me
            _out.Add(_node.id, _NewId)
            _node.id = _NewId
            ''correct folder name
            'Dim _nodeName = Me.Parent.GetDataFolderPathForNode(Me, _node, False)
            'Dim _oldName = Me.TreeName + _node.Name
            _NewId += 1
        Next
        LastFreeId = _NewId + 1
        Return New KeyValuePair(Of String, Dictionary(Of Integer, Integer))(Me.TreeKeyName, _out)
    End Function


    ''' <summary>
    ''' вернет относительный (от контейнера) путь к папке узла, без имени файла
    ''' </summary>
    ''' <param name="node"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetDataFileContainerRelativePath(node As NodeObject) As String
        Dim _base = Me.Parent.DataBlockName
        Dim _tree = Me.TreeKeyName
        Dim _node = node.GetDataFolderName

        Return IO.Path.Combine(_base, _tree, _node)
    End Function
    ' ''' <summary>
    ' ''' вернет полный относительный путь от папки коллекции деревьев(например, венд)!!!, под которым надо записать файл данных. FileIndex надо вычислить по кол-ву файлов в контейнере(папке)
    ' ''' </summary>
    ' ''' <param name="node"></param>
    ' ''' <param name="SourceDataFileName"></param>
    ' ''' <param name="FileIndex"></param>
    ' ''' <returns></returns>
    ' ''' <remarks></remarks>
    'Public Function GetDataFileRelativeFullPath(node As NodeObject, SourceDataFileName As String, FileIndex As Integer) As String
    '    Dim _sext = IO.Path.GetExtension(SourceDataFileName)
    '    Return IO.Path.Combine(Me.TreeName, node.GetDataFolderName, node.Name & "_" & FileIndex.ToString & _sext)
    'End Function


End Class
