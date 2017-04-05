Imports Microsoft.SqlServer.Types
Imports System
Imports System.IO
Imports System.Runtime.Serialization
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Threading
Imports Service
Imports Service.Catalog

<Serializable()>
Friend Class clsTreeManager
    ''' <summary>
    ''' коллекция списков
    ''' </summary>
    Private oTreesCollection As New Generic.SortedList(Of String, ClsTree)
    'Public Shared ReadOnly cntDbImageSize As Drawing.Size = New Drawing.Size(228, 171)



    Public Shared AppHeader As String = "Описание 3.0"
    ''' <summary>
    ''' очистить коллекцию деревьев (при создании нового файла)
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ClearTreeCollection()
        oTreesCollection.Clear()
    End Sub
    Private oFileLoaded As Boolean = False
    Public ReadOnly Property FileLoaded As Boolean
        Get
            Return oFileLoaded
        End Get
    End Property


    ''' <summary>
    ''' загружет файл, путь которого прописан в свойстве GroupFilePath
    ''' </summary>
    ''' <remarks></remarks>
    Friend Function LoadFile() As Boolean
        ' Opens file "data.xml" and deserializes the object from it.
        Debug.Assert(Me.GroupFilePath.Length > 0)
        oFileLoaded = False
        oTreesCollection.Clear()
        If Not File.Exists(Me.GroupFilePath) Then
            MsgBox("Файл не найден", vbCritical, clsTreeManager.AppHeader)
            Return False
        End If
        '------------------------------
        Try
            Using Stream = File.Open(Me.GroupFilePath, FileMode.Open)

                'получим обьекты из хранилища в связке [имя дерева]+[список обьектов]
                Dim Formatter = New BinaryFormatter
                '  Dim _result = Formatter.Deserialize(Stream)
                Dim _tmp = CType(Formatter.Deserialize(Stream), Generic.SortedList(Of String, List(Of Trilbone.SerializableNodeObject)))

                'формируем деревья
                Dim _tree As ClsTree
                For Each t In _tmp
                    _tree = ClsTree.CreateFromSerializableNodeList(t.Value, Me)
                    AddHandler _tree.TreeNameChanged, AddressOf TreeNameChanged_eventHandler
                    _tree.TreeKeyName = t.Key
                    If Not oTreesCollection.ContainsKey(t.Key) Then
                        TreeCollection.Add(t.Key, _tree)
                    End If
                Next
                'Stream.Close()
            End Using
        Catch ex As Exception
            MsgBox("Не удается прочитать данные из файла. " & ex.Message, vbCritical, clsTreeManager.AppHeader)
            Return False
        End Try

        Me.RegisterChangedEvent()

        clsTreeManager.AppHeader = "Oп3.0 " & IO.Path.GetFileNameWithoutExtension(Me.GroupFilePath)
        oFileLoaded = True
        Return True
    End Function

#Region "Import Nodes"
    ''' <summary>
    ''' Вернет список директорий для импорта. деревья должны быть загружены.
    ''' </summary>
    ''' <param name="TreeName">имя дерева, куда будем импортировать данные</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Function LoadImportFolderCollection(TreeName As String) As List(Of String)
        'предусловия
        If TreeName.Length = 0 Then GoTo ex
        Debug.Assert(TreeName.Length > 0)


        If Not Me.ContainsTree(TreeName) Then GoTo ex
        Debug.Assert(Me.ContainsTree(TreeName))

        'body
        'select root folder
        Dim _dg As New Windows.Forms.FolderBrowserDialog
        With _dg
            .RootFolder = Environment.SpecialFolder.MyComputer
            .Description = "Выберете папку с описаниями обьектов для дерева " & TreeName & "  группы " & Me.LoadedGroupName
        End With

        Select Case _dg.ShowDialog()
            Case DialogResult.OK, DialogResult.Yes
                If Not IO.Directory.Exists(_dg.SelectedPath) Then GoTo ex
                Dim _result As IEnumerable(Of String)
                Try
                    _result = (IO.Directory.EnumerateDirectories(_dg.SelectedPath)).ToList
                    Return _result
                Catch ex As Exception
                    GoTo ex
                End Try

            Case Else
                GoTo ex
        End Select


ex:
        Return New List(Of String)

    End Function
    ''' <summary>
    ''' создает список обьектов (и файлов) по переданным путям.Используется для привязки к форме.
    ''' </summary>
    ''' <param name="paths"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Function CreateList(paths As List(Of String)) As clsListOfImportsObj
        'создает список обьектов по переданным путям
        Dim _out As New List(Of clsImportsObj)
        For Each t In paths
            Dim _files = IO.Directory.EnumerateFiles(t, "*.*", IO.SearchOption.TopDirectoryOnly).ToList
            Dim _new As New clsImportsObj
            'parcer??
            _new.NodeName = IO.Path.GetFileName(t)
            _new.DataFilePaths = _files
            _out.Add(_new)
        Next
        Return _out
    End Function
    ''' <summary>
    ''' источник данных для формы
    ''' </summary>
    ''' <remarks></remarks>
    Public Class clsListOfImportsObj
        Inherits List(Of clsImportsObj)

    End Class


    ''' <summary>
    ''' описывает импортируемый элемент
    ''' </summary>
    ''' <remarks></remarks>
    Public Class clsImportsObj
        Public NodeName
        Public DataFilePaths As List(Of String)
        Public ReadOnly Property ListOfDataFileNames As List(Of String)
            Get
                Dim _res = From c In DataFilePaths Select IO.Path.GetFileName(c)
                Return _res.ToList
            End Get
        End Property
        ''' <summary>
        ''' вернет все узлы для дерева, сравнение которых по всем словам до скобок положительно. Ищет в двух культурах.
        ''' </summary>
        ''' <param name="Tree"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function ListOfComparedNodes(Tree As ClsTree) As List(Of NodeObject)
            Return Tree.SearchNode(Me.NameParcer(NodeName))
        End Function
        ''' <summary>
        ''' вернет только слова с одним пробелом между ними, скобки уберем
        ''' </summary>
        ''' <param name="Name"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function NameParcer(Name As String) As String
            Dim _frase As String
            Dim _result As String()
            If Name.IndexOf("(".ToCharArray) = -1 Then
                'только разделить пробелы
                _frase = Name
            Else
                'удалить скобки
                _result = Name.Split("(".ToCharArray)
                If _result.Length > 0 Then
                    _frase = _result(0)
                Else
                    'что-то не так
                    Return Name.Trim
                End If
            End If

            'отделим слова
            _frase.Trim()
            _result = _frase.Split(New Char() {}, System.StringSplitOptions.RemoveEmptyEntries)

            Select Case _result.Length
                Case 0
                    'пробелов нет и вернуть слово
                    Return _frase
                Case 1
                    'пробел есть, но не между словами
                    Return _frase

                Case Is > 1
                    'вернем нормализованное имя
                    Return String.Join(" ", _result)
            End Select

            Return Name.Trim

        End Function

    End Class


#End Region




    ''' <summary>
    ''' load xml. path - путь к файлу
    ''' </summary>
    ''' <param name="path"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function LoadFromXML(ByVal path As String) As Boolean
        Debug.Assert(path.Length > 0)
        If Not File.Exists(path) Then
            MsgBox("Файл не найден", vbCritical, clsTreeManager.AppHeader)
            Return False
        End If
        ' load xml file
        '1 - загрузить хмл файл. Название дерева = имя хмл файла без расширения.
        '2 - отобрать подпапки, содержащие [id узла]. Там лежат фото, которые надо загрузить в bin!
        '3 - DATAFILES лежат в папке с именем узла. Ни чего не делаем.


        ''сюда запрос отбирающий узлы группы (например, Ammonites) = аналог файла
        '

        Dim _xmlForTree = XElement.Load(path)
        'пытаемся установить корневой путь
        ' Me.FilePath = IO.Directory.GetParent(path).FullName


        Dim _ic As New Dictionary(Of Integer, NodeObject.clsImageList)
        'проверим наличие директории для фоток к этому файлу в текущей директории
        Dim _treePath = IO.Path.Combine(IO.Path.GetDirectoryName(path), Me.DataBlockName)

        If Not IO.Directory.Exists(_treePath) Then
            'если директории для дерева нет - сделать дерево без фото
            GoTo makeTree
        End If

        ' load fotos
        '------------func----------
        'грузит фото
        Dim _loadPhoto = Function(_path As String)
                             Try
                                 Dim _tmp = clsApplicationTypes.GetResizedImageForTree(_path)
                                 If IsNothing(_tmp) = False Then
                                     Return New Bitmap(_tmp)
                                 End If

                             Catch ex As Exception
                                 MsgBox("ошибка при чтении файлов изображений: " & ex.Message, , clsTreeManager.AppHeader)
                                 Return Nothing
                             End Try
                             Return Nothing
                         End Function
        '--------------func-------------
        'заполняет словарь парами: [имя_узла][clsImageList]
        Dim _loadarray = Function(key As Integer, ByRef _imglist As NodeObject.clsImageList)
                             _ic.Add(key, _imglist)
                             Return _imglist.Count
                         End Function

        '---------------fun---------------
        'создает clsImageList из List(Of Bitmap)
        Dim _cast = Function(inp As List(Of Bitmap))
                        Dim _c As New NodeObject.clsImageList
                        For Each t In inp
                            _c.Add(t)
                        Next
                        Return _c
                    End Function
        '-----------------------------------------------

        'read photo files во всех поддиректориях дерева
        'переберем поддиректории дерева, содержащие суффикс директории для хмл
        For Each _dir In Directory.GetDirectories(_treePath, "*")
            'create list of image files in specific photo directory
            Dim _ls As New List(Of String)
            'ищем фото с заданными расширениями
            For Each _ptt In Me.ImagePattern
                Dim _list = (From c In Directory.GetFiles(_dir, _ptt, IO.SearchOption.TopDirectoryOnly) Where c.Length > 0 Select IO.Path.GetFullPath(c)).ToList
                If _list.Count > 0 Then
                    _ls.AddRange(_list)
                End If
            Next

            'в _list лежит список путей к фото конкретного узла
            'грузим фото
            Dim _li = (From c In _ls Where c.Length > 0 Select _loadPhoto(c)).ToList
            Dim _btm = _cast(_li)

            Dim _key As Integer
            If Integer.TryParse(New DirectoryInfo(_dir).Name, _key) Then
                _ic.Add(_key, _btm)
            End If
        Next
        If Not _ic Is Nothing AndAlso _ic.Count = 0 Then
            _ic = Nothing
        End If


makeTree:
        'формируем обьект дерева
        Dim _tree = ClsTree.ParseFromXML(Me, _xmlForTree, _ic)

        If Not _tree Is Nothing Then
            AddHandler _tree.TreeNameChanged, AddressOf TreeNameChanged_eventHandler
            If Not oTreesCollection.ContainsKey(_tree.TreeKeyName) Then
                TreeCollection.Add(_tree.TreeKeyName, _tree)
                MsgBox("Дерево разобрано, фотки скопированы в дерево. Для сохранения оригиналов, скопируйте их в вновь созданную директорию этого дерева", vbInformation)
            End If
            Return True
        End If
        Return False



    End Function
    ''' <summary>
    ''' возвращает/задает коллекцию деревьев Key=TreeName
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend ReadOnly Property TreeCollection As Generic.SortedList(Of String, ClsTree)
        Get
            Return oTreesCollection
        End Get

    End Property
    ''' <summary>
    ''' возвращает список деревьев как list
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend ReadOnly Property TreeList As List(Of ClsTree)
        Get
            Return (From c In oTreesCollection Select c.Value).ToList
        End Get
    End Property
    ''' <summary>
    ''' вернет имя файла без пути
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property LoadedGroupName As String
        Get
            Return My.Settings.LastFileName
        End Get
    End Property
    ' ''' <summary>
    ' ''' имя загруженной группы
    ' ''' </summary>
    ' ''' <remarks></remarks>
    'Private oLoadedGroupName As String 

    ''' <summary>
    ''' полный путь и имя файла данных.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property GroupFilePath As String
        Get
            If Not My.Settings.LastFileName = "" Then
                Return IO.Path.Combine(clsApplicationTypes.TreeFolderPath, My.Settings.LastFileName
)
            Else
                Return ""
            End If
        End Get
        Set(ByVal value As String)
            If IO.File.Exists(value) Then
                clsApplicationTypes.TreeFolderPath = IO.Path.GetDirectoryName(value)
                My.Settings.LastFileName = IO.Path.GetFileName(value)
                My.Settings.Save()
            Else
                Debug.Fail("файл по указанному пути не существует: " & value)
            End If

        End Set
    End Property
    Public ReadOnly ImagePattern As String() = {"*.jpg", "*.jpeg", "*.png", "*.tiff", "*.gif", "*.bmp"}
    'Public Const XMLImageFolderSuffics As String = "_images"

    ' ''' <summary>
    ' ''' Имя группы деревьев (блока данных)
    ' ''' </summary>
    ' ''' <remarks></remarks>
    'Private oDataBlockName As String
    ''' <summary>
    '''  Имя группы деревьев (блока данных)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property DataBlockName As String
        Get
            Debug.Assert(Me.GroupFilePath.Length > 0, "Запрос имени блока до определения имени и пути файла деревьев")

            Return IO.Path.GetFileNameWithoutExtension(Me.GroupFilePath)
        End Get
    End Property

    <NonSerializedAttribute> _
    Private oXMLDescription As XElement

    ' ''' <summary>
    ' ''' текущее описание
    ' ''' </summary>
    ' ''' <value></value>
    ' ''' <returns></returns>
    ' ''' <remarks></remarks>
    'Public ReadOnly Property Description As String
    '    Get

    '    End Get
    '    'Set(value As String)
    '    '    oDescription = value
    '    'End Set
    'End Property
    'Public ReadOnly Property XMLDescription As String
    '    Get

    '    End Get
    'End Property
    'Public Property Parent As fmDescription

    ''' <summary>
    ''' в поле этого свойства отображаются все добавленные элементы описания
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property XMLDescriptionElement As XElement
        Get
            Return oXMLDescription
        End Get

    End Property

    ''' <summary>
    ''' сохранить файл
    ''' </summary>
    Public Function SaveFile(fileFullPath As String, warning As Boolean) As String
        ' Opens a file and serializes the object into it in binary format.
        If Me.TreeCollection.Count = 0 Then
            Return "Нельзя сохранить пустую коллекцию деревьев."
        End If

        If fileFullPath = "" Then
            Return "Путь для сохранения должен быть задан"
        End If

        'создание папок
        If Not Directory.Exists(Path.GetDirectoryName(fileFullPath)) Then
            Directory.CreateDirectory(Path.GetDirectoryName(fileFullPath))
        End If


        Dim _tempName = My.Computer.FileSystem.GetTempFileName

        'ВАЖНО проверить активное дерево
        If Not Me.GroupFilePath.Trim = fileFullPath.Trim Then
            '' MsgBox(String.Format("", clsTreeManager.GroupFilePath, fileFullPath), vbCritical)
            Return String.Format("Попытка сохранить дерево {0} в файле {1}. Сохранение отменено.", IO.Path.GetFileName(Me.GroupFilePath), IO.Path.GetFileName(fileFullPath))
        End If

        'сериализация коллекции
        Dim _xmlObject = New Generic.SortedList(Of String, List(Of SerializableNodeObject))
        For Each t In Me.TreeCollection
            Dim _tmp = t.Value.GetAsSerializableList
            Dim _name = t.Key
            _xmlObject.Add(_name, _tmp)
        Next

        Dim sc As New StreamingContext(StreamingContextStates.File, _xmlObject)
        Dim formatter As New BinaryFormatter(Nothing, sc)
        formatter.FilterLevel = Formatters.TypeFilterLevel.Low
        formatter.TypeFormat = Formatters.FormatterTypeStyle.TypesWhenNeeded
        Try
            Using stream As Stream = File.Open(_tempName, FileMode.Create)
                formatter.Serialize(stream, _xmlObject)
            End Using
        Catch ex As Exception
            Return "Файл не сохранен! " & ex.Message
        End Try

        If warning AndAlso File.Exists(fileFullPath) Then
            Select Case MsgBox("Заменить существующий файл " & Path.GetFileName(fileFullPath) & " ?", MsgBoxStyle.YesNo, "Внимание! Перезапись файла")
                Case MsgBoxResult.No
                    Return "Файл не перезаписан!"
            End Select
        End If

        File.Copy(_tempName, fileFullPath, True)
        File.Delete(_tempName)
        'проверка директории данных
        'Dim _res = Me.GetDataFolderRootPath(True)
        ' clsTreeManager.GroupFilePath = fileFullPath
        Return "Файл сохранен"
    End Function
    ''' <summary>
    ''' вернет путь для xml файла конкретного дерева (файл называется по имени дерева с расширением xml)
    ''' </summary>
    ''' <param name="Tree"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Function GetFileXMLTreePath(ByVal Tree As ClsTree) As String
        Dim _str = IO.Path.Combine(Me.GetDataFolderRootPath(), Me.DataBlockName, Tree.TreeKeyName & ".xml")
        Return _str
        'Return IO.Path.Combine(IO.Path.GetDirectoryName(Me.FilePath), IO.Path.GetFileNameWithoutExtension(Me.FilePath) & "_" & )
    End Function
    ''' <summary>
    ''' вернет путь для папки конкретного дерева (папка называется по имени дерева)
    ''' </summary>
    ''' <param name="Tree"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Overloads Function GetDataFolderPathForTree(ByVal Tree As ClsTree, Optional CreateIfNotExists As Boolean = False) As String
        Debug.Assert(Me.GetDataFolderRootPath(False).Length > 0, "Не задан корневой путь")
        If Me.GetDataFolderRootPath(False).Length < 2 Then Return ""
        Dim _str = IO.Path.Combine(Me.GetDataFolderRootPath(False), Me.DataBlockName, Tree.TreeKeyName)

        If CreateIfNotExists And (Not IO.Directory.Exists(_str)) Then
            'create
            IO.Directory.CreateDirectory(_str)
        End If
        Return _str
        ' Return IO.Path.Combine(IO.Path.GetDirectoryName(Me.FilePath), (IO.Path.GetFileNameWithoutExtension(Me.FilePath)).Split("_").First & "_images" & "_" & Tree.TreeName)
    End Function
    ' ''' <summary>
    ' ''' вернет путь для папки конкретного дерева (папка называется по имени дерева)
    ' ''' </summary>
    ' ''' <param name="TreeName"></param>
    ' ''' <returns></returns>
    ' ''' <remarks></remarks>
    'Public Overloads Function GetDataFolderPathForTree(ByVal TreeName As String) As String
    '    Debug.Assert(TreeName.Length > 0, "имя дерева не может быть пустым")
    '    Dim _str = IO.Path.Combine(Me.GetDataFolderRootPath(), TreeName)
    '    Return _str
    'End Function
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="TreeName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ContainsTree(TreeName As String) As Boolean
        If TreeCollection.ContainsKey(TreeName) Then Return True
        Return False
    End Function
    ''' <summary>
    ''' ищет узел по ИД по всем деревьям
    ''' </summary>
    ''' <param name="NodeID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function FindNode(NodeID As Integer, treename As String) As NodeObject
        Dim _tree = Me.GetTreeOf(treename)
        If _tree Is Nothing Then Return Nothing

        Return _tree.Item(NodeID)

        'For Each t In Me.TreeList
        '    If Not t.Item(NodeID) Is Nothing Then
        '        Return t.Item(NodeID)
        '    End If
        'Next

        'Dim _result = (From c In Me.TreeList Where Not c.Item(NodeID) Is Nothing Select c.Item(NodeID)).ToList

        'If _result.Count > 0 Then Return _result(0)
        Return Nothing
    End Function
    ''' <summary>
    ''' ищет узел по имени (точное совпадение) по всем деревьям/ Count будет содержать кол-во найденых соответствий
    ''' </summary>
    ''' <param name="NodeName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function FindNode(NodeName As String, Optional ByRef Count As Integer = 0) As NodeObject
        Dim _result As List(Of NodeObject)
        Dim _out As New List(Of NodeObject)
        For Each t In Me.TreeList
            _result = (From c In t Where c.Name.Equals(NodeName) Select c).ToList
            If _result.Count > 0 Then
                _out.AddRange(_result)
            End If
        Next
        Count = _out.Count
        Return _out.FirstOrDefault
    End Function


    ''' <summary>
    ''' вернет путь для папки текущей группы деревьев (папка называется по имени файла без расширения)
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetDataFolderRootPath(Optional CreateIfNotExists As Boolean = False) As String
        'Debug.Assert(Me.FilePath.Length > 0, "Корневой путь не задан")
        'If Not Me.FileLoaded Then Return ""
        If Me.GroupFilePath = "" Then Return ""
        Dim _str = IO.Path.Combine(IO.Path.GetDirectoryName(Me.GroupFilePath), Me.DataBlockName)
        'изменено 15,07,2015
        _str = IO.Path.GetDirectoryName(Me.GroupFilePath)
        If CreateIfNotExists And (Not IO.Directory.Exists(_str)) Then
            'create
            IO.Directory.CreateDirectory(_str)
        End If
        Return _str
    End Function
    ''' <summary>
    ''' вернет обьект диалогового окна для открытия файла с деревьями. Запускать самостоятельно. initialCatalog перезапишет директорию .
    ''' </summary>
    ''' <param name="initialCatalog"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetFileTreeOpenDialog(Optional initialCatalog As String = "") As Windows.Forms.OpenFileDialog
        Dim s As New OpenFileDialog
        With s
            .InitialDirectory = clsApplicationTypes.TreeFolderPath
            If Not initialCatalog = "" Then .InitialDirectory = initialCatalog

            .Filter = " Tree files|*.tree"
            .DefaultExt = "tree"
            .AddExtension = True
            .CheckFileExists = True
            .CheckPathExists = True
            .RestoreDirectory = True
            .Title = "Откыть файл с деревьями"
            .Multiselect = False
        End With
        Return s
    End Function
    ' ''' <summary>
    ' ''' переименует папку с файлами
    ' ''' </summary>
    ' ''' <param name="Tree"></param>
    ' ''' <param name="Node"></param>
    ' ''' <param name="NewName"></param>
    ' ''' <returns></returns>
    ' ''' <remarks></remarks>
    'Friend Function ChangeFolderNameForNode(Tree As ClsTree, Node As NodeObject, NewName As String) As Boolean
    '    'Dim _old = GetDataFolderPathForNode(Tree, Node)
    '    'требуется добавить событие ПЕРЕД изменением имени, чтобы получить старое имя

    'End Function

    ''' <summary>
    '''  вернет путь для папки с файлами конкретного узла (папка называется по ID узла)!!!
    ''' </summary>
    ''' <param name="Tree"></param>
    ''' <param name="Node"></param>
    ''' <param name="CreateIfNotExists"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Function GetDataFolderPathForNode(Tree As ClsTree, Node As NodeObject, Optional CreateIfNotExists As Boolean = True) As String
        Dim _out As String = ""
        _out = IO.Path.Combine(Me.GetDataFolderRootPath(), Tree.GetDataFileContainerRelativePath(Node)) 'IO.Path.Combine(Me.GetDataFolderPathForTree(Tree), Node.GetDataFolderName)
        Try
            If CreateIfNotExists And (Not IO.Directory.Exists(_out)) Then
                'create
                IO.Directory.CreateDirectory(_out)
            End If
            Return _out
        Catch ex As Exception
            Debug.Fail(Node.Name & "  " & ex.Message)
            Return ""
        End Try
    End Function
    ''' <summary>
    ''' вернет список урезанных фоток из дата папки Filter = "фото|*.jpg;*.jpeg;*.png;*.tiff;*.gif;*.bmp;*.tif"
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Function GetDataFolderImagesForNode(Tree As ClsTree, Node As NodeObject, Optional original As Boolean = False) As List(Of Image)
        Dim _out As New List(Of Image)

        If Not Me.TestDataFolderForNode(Node) Then Return _out
        Dim _path = Me.GetDataFolderPathForNode(Tree, Node)

        Return clsApplicationTypes.GetImagesFromFolder(_path, original)


    End Function




    Friend Function GetCountAIFiles(Tree As ClsTree, Node As NodeObject) As Integer
        If Not Me.TestDataFolderForNode(Node) Then Return 0
        Dim _path = Me.GetDataFolderPathForNode(Tree, Node)
        Return IO.Directory.GetFiles(_path, "*.ai").Count
    End Function



    ''' <summary>
    ''' вернет список урезанных этикеток из дата папки Filter = "файлы этикеток|*.ai;*.pdf". В tag лежит путь к файлу
    ''' </summary>
    ''' <param name="Tree"></param>
    ''' <param name="Node"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Function GetDataFolderAiImagesForNode(Tree As ClsTree, Node As NodeObject, dpi As Double) As List(Of Image)
        Dim _out As New List(Of Image)

        If Not Me.TestDataFolderForNode(Node) Then Return _out
        Dim _path = Me.GetDataFolderPathForNode(Tree, Node)
        Dim _files As New List(Of String)

        Dim _fl = IO.Directory.GetFiles(_path, "*.ai")
        _files.AddRange(_fl)

        Dim _image As Image
        For Each t In _files
            _image = clsApplicationTypes.GetPdfImageFromAIFile(t, dpi)
            If Not _image Is Nothing Then
                _image.Tag = t
                _out.Add(_image)
            End If

        Next
        Return _out
    End Function


    ''' <summary>
    ''' вернет флаг наличия папки с данными для узла
    ''' </summary>
    ''' <param name="Node"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Function TestDataFolderForNode(Node As NodeObject) As Boolean
        If Node Is Nothing Then Return False
        If Not Me.FileLoaded Then
            'корневой путь не задан
            Return False
        End If

        Dim _destination = Me.GetDataFolderPathForNode(Node.Parent, Node, True)

        If Not IO.Directory.Exists(_destination) Then Return False

        If IO.Directory.GetFiles(_destination).Length = 0 Then Return False

        Return True
    End Function

    Public Sub New()

    End Sub

    ' ''' <summary>
    ' ''' генерирует путь к файлу данных (DataFileFullName=someimage.ext). Наличие расширения ОБЯЗАТЕЛЬНО.
    ' ''' вернет путь к файлу в соответствии с [node.name]_[index].[extention]/ index будет сгенерирован следующий, после имеющихся!
    ' ''' </summary>
    ' ''' <param name="Node"></param>
    ' ''' <returns></returns>
    ' ''' <remarks></remarks>
    'Private Function GetNodeNewFilePath(Tree As ClsTree, Node As NodeObject, DataFileFullName As String) As String
    '    'проверка директории
    '    Dim _destination = Me.GetDataFolderPathForNode(Tree, Node, True)
    '    If Not IO.Directory.Exists(_destination) Then Return ""
    '    'проверка расширения
    '    Dim _destExst = IO.Path.GetExtension(DataFileFullName)
    '    If _destExst.Length = 0 Then Return ""
    '    'генерация индекса
    '    Dim _destName = Node.Name
    '    Dim _index As Integer = 0
    '    Do While IO.File.Exists(IO.Path.Combine(_destination, _destName & "_" & _index.ToString & _destExst))
    '        _index += 1
    '    Loop
    '    'формируем имя  [NAME]_[INDEX].[extention]
    '    _destName = _destName & "_" & _index.ToString & _destExst
    '    'формируем полный путь
    '    Dim _dest = IO.Path.Combine(_destination, _destName)
    '    Return _dest
    'End Function


    ''' <summary>
    ''' скопировать в папку узла файл данных. Вернет новое имя файла или "" если не удалось скопировать
    ''' </summary>
    ''' <param name="Tree"></param>
    ''' <param name="Node"></param>
    ''' <param name="SourceDataFileFullPath">полный путь к файлу данных</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Function AttachDataFile(Tree As ClsTree, Node As NodeObject, SourceDataFileFullPath As String) As String
        Debug.Assert(SourceDataFileFullPath.Length > 0)
        'папка-ID узла!!

        If Not IO.File.Exists(SourceDataFileFullPath) Then Return ""
        Dim _sourcefilename = IO.Path.GetFileName(SourceDataFileFullPath)
        Dim _newpath = IO.Path.Combine(Me.GetDataFolderPathForNode(Tree, Node, True), _sourcefilename)

        If IO.File.Exists(_newpath) Then
            'переименуем
            _sourcefilename = IO.Path.GetFileNameWithoutExtension(_newpath) & "_1" & IO.Path.GetExtension(_newpath)
            _newpath = IO.Path.Combine(Me.GetDataFolderPathForNode(Tree, Node, True), _sourcefilename)
        End If

        Try
            If _newpath = "" Then
                Debug.Fail("Не удалось сгенерировать путь к файлу данных")
            Else
                IO.File.Copy(SourceDataFileFullPath, _newpath)
                Return _newpath
            End If

        Catch ex As Exception
            MsgBox("Ошибка при копировании файла: " & ex.Message, vbCritical, clsTreeManager.AppHeader)
        End Try
        Return ""
    End Function

    ' ''' <summary>
    ' ''' получает путь к папке с данными узла: папка называется по имени узла
    ' ''' </summary>
    ' ''' <param name="Tree">дерево</param>
    ' ''' <param name="Node">HierID узла</param>
    ' ''' <param name="CreateIfNotExists">создать, если отсутствует</param>
    ' ''' <returns></returns>
    ' ''' <remarks></remarks>
    'Public Function GetDataFolderPath(Tree As ClsTree, Node As SqlHierarchyId, Optional CreateIfNotExists As Boolean = False) As String
    '    Dim _root = Me.GetDataFolderPathForTree(Tree)
    '    Dim _nodeInfo = Tree.Item(Node).Name
    '    Dim _rezult = IO.Path.Combine(_root, _nodeInfo)

    '    If CreateIfNotExists Then
    '        If Not Directory.Exists(_rezult) Then
    '            Directory.CreateDirectory(_rezult)
    '        End If
    '    End If

    '    Return _rezult
    'End Function


    ''' <summary>
    ''' каталог основного файла
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CreateMainCatalog() As CATALOG
        Dim _catalog = CATALOG.CreateInstance(Date.Now.ToShortDateString, Me.DataBlockName, Me.DataBlockName, "Tree")
        Dim _node As CATALOGSAMPLE
        Dim _count As Integer = 0
        For Each _elem In Me.TreeCollection

            _node = _catalog.AddSample(_count, Service.clsApplicationTypes.emCatalogFolderType.shot)
            Dim _file = IO.Path.Combine(Me.DataBlockName, _elem.Key & ".htm")
            _node.AddDataElement("Tree", _elem.Value.RootNodeNameByCulture(clsApplicationTypes.EnglishCulture), CATALOGSAMPLEELEMENT.emPosition.title, "(English)Tree").AddEnviropment(_file, "", CATALOGSAMPLEELEMENTENVIRONMENT.emEnviropmentType.html)
            'русский
            _file = IO.Path.Combine(Me.DataBlockName, _elem.Key & ".html")
            _node.AddDataElement("Tree", _elem.Value.RootNodeNameByCulture(clsApplicationTypes.RussianCulture), CATALOGSAMPLEELEMENT.emPosition.title, "(Русский)Дерево").AddEnviropment(_file, "", CATALOGSAMPLEELEMENTENVIRONMENT.emEnviropmentType.html)

            _count += 1
        Next
        Return _catalog
    End Function


    ''' <summary>
    ''' сохранить XML файлы
    ''' </summary>
    Public Function Save_XML_HTML(Optional ByVal saveFiles As Boolean = False, Optional ByVal CreateImageFolder As Boolean = False, Optional ImagesFromInternet As Boolean = False) As String

        If Me.TreeCollection.Count = 0 Then Return "нельзя сохранить пустую коллекцию"

        '1 - создать хмл файл в папке дерева
        '2 - создать папки для сжатых фото из двоичного файла


        Dim _catalogEN As CATALOG
        Dim _catalogRUS As CATALOG

        Dim _tempName = My.Computer.FileSystem.GetTempFileName

        ' Try
        'для каждого дерева
        For Each _tree In Me.TreeCollection
            Dim _xmlDocument As XDocument
            Dim _path = Me.GetFileXMLTreePath(_tree.Value)
            Dim _treeFolderPath = Me.GetDataFolderPathForTree(_tree.Value)



            If CreateImageFolder Then
                'В _imgcoll лежит [ID узла], {коллекция фото}
                Dim _imgcoll As New Generic.Dictionary(Of Integer, List(Of Bitmap))
                _xmlDocument = _tree.Value.GetAsXMLDocument(_imgcoll)
                _catalogEN = _tree.Value.GetAsCatalog(clsApplicationTypes.EnglishCulture, True, ImagesFromInternet)
                _catalogRUS = _tree.Value.GetAsCatalog(clsApplicationTypes.RussianCulture, True, ImagesFromInternet)
                Dim _xml = _catalogEN.GetXML
                'save images
                If saveFiles Then
                    'проверим директорию
                    If Not IO.Directory.Exists(_treeFolderPath) Then
                        IO.Directory.CreateDirectory(_treeFolderPath)
                    End If
                    'сохранить файлы
                    For Each _item In _imgcoll
                        Dim _filePath As String

                        Dim _NodeName = _tree.Value.Item(_item.Key)
                        Dim _dirNode As String = Me.GetDataFolderPathForNode(_tree.Value, _NodeName, False) ' IO.Path.Combine(_treeFolderPath, _NodeName & clsTreeManager.XMLImageFolderSuffics)
                        'проверим директорию
                        If Not IO.Directory.Exists(_dirNode) Then
                            IO.Directory.CreateDirectory(_dirNode)
                        End If
                        'удалить все jpg
                        For Each _f In IO.Directory.GetFiles(_dirNode, "*.jpg", SearchOption.TopDirectoryOnly)
                            IO.File.Delete(_f)
                        Next
                        'пишем фото
                        Dim _counter As Integer = 0
                        For Each _image In _item.Value
                            'имя файла узла
                            Dim _fileName = _NodeName.Name & "_" & _counter & ".jpg"
                            'путь, куда сохраняем
                            _filePath = IO.Path.Combine(_dirNode, _fileName)
                            _image.Save(_filePath, Drawing.Imaging.ImageFormat.Jpeg)
                            _counter += 1
                        Next
                    Next
                End If

            Else
                _xmlDocument = _tree.Value.GetAsXMLDocument
                _catalogEN = _tree.Value.GetAsCatalog(clsApplicationTypes.EnglishCulture, , ImagesFromInternet)
                _catalogRUS = _tree.Value.GetAsCatalog(clsApplicationTypes.RussianCulture, , ImagesFromInternet)
            End If

            '----------------
            If saveFiles Then
                'сохранить xml дерева
                _xmlDocument.Save(_path)
                'сохранить файлы каталога
                Try
                    _catalogEN.CreateHTMLFile(IO.Path.ChangeExtension(Me.GetFileXMLTreePath(_tree.Value), "htm"))
                    _catalogRUS.CreateHTMLFile(IO.Path.ChangeExtension(Me.GetFileXMLTreePath(_tree.Value), "html"))
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try

            End If


        Next



        'сохранить файл основного каталога
        Dim _main = Me.CreateMainCatalog
        Dim _mainpath = IO.Path.ChangeExtension(Me.GroupFilePath, "htm")

        Try
            _main.CreateHTMLFile(_mainpath)
            Return "Файл(ы) сохранен(ы)"
        Catch ex As Exception
            MsgBox("Не удалось сохранить файлы каталога!", vbCritical)
        End Try


        'If Not _catalogForms Is Nothing Then
        '    _catalogForms.Add(_main.GetCatalogForm)
        '    'Dim _f As Form = _catalog.GetCatalogForm
        '    'If IsNothing(_f) = False Then
        '    '    _catalogForms.Add(_catalog.GetCatalogForm)
        '    'End If
        'End If

        'Catch ex As Exception
        '    Return "clsTreeManager-->AsXML-->Файл(ы) не сохранен(ы)! " & ex.Message
        'End Try

        Return "Файл(ы) сохранен(ы)"



    End Function


    ''' <summary>
    ''' вернец дерево по его названию
    ''' </summary>
    Friend Function GetTreeOf(ByVal Name As String) As ClsTree
        Debug.Assert(Name.Length > 0)
        Dim _q = Name.Substring(0, 5).ToLower


        For Each t In Me.oTreesCollection.Keys
            If t.ToLower.StartsWith(_q) Then
                Return Me.oTreesCollection.Item(t)
            End If
        Next

        'If Me.oTreesCollection.ContainsKey(Name) Then
        '    Return Me.oTreesCollection.Item(Name)
        'End If

        Return Nothing

    End Function


    ''' <summary>
    ''' изменит id узла
    ''' </summary>
    ''' <param name="node"></param>
    ''' <param name="newID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Function CorrectIndividualID(node As NodeObject, newID As Integer) As Boolean
        Dim _errors As Integer = 0
        Dim _changedLinkCount As Integer = 0
        Dim _changedArticulCount As Integer = 0
        Dim _changedFolderCount As Integer = 0
        Dim _oldID = node.id

        'меняем ID
        node.id = newID

        'исправить директорию с файлами
        Dim _basepeth = Me.GetDataFolderPathForTree(node.Parent, False)
        If IO.Directory.Exists(IO.Path.Combine(_basepeth, _oldID)) Then
            Try
                IO.Directory.Move(IO.Path.Combine(_basepeth, _oldID), IO.Path.Combine(_basepeth, newID))
                _changedFolderCount += 1
            Catch ex As Exception
                _errors += 1
            End Try
        End If

        'перебрать узлы
        For Each _tr In Me.TreeCollection
            For Each _node In _tr.Value
                'перебрать узлы
                'артикулы
                If _node.HasTiedNodes Then
                    Dim _newArticul As New List(Of Integer)
                    For Each ar In _node.GetTiedID
                        If ar = _oldID Then
                            _newArticul.Add(newID)
                            _changedArticulCount += 1
                        Else
                            _newArticul.Add(ar)
                        End If
                    Next
                    If _newArticul.Count > 0 Then
                        _node.SetTiedNodes(_newArticul)
                    End If
                End If


                'связи
                Dim _newlink As New Dictionary(Of String, List(Of Integer))
                Dim _changed As Boolean = False
                If Not _node.Link Is Nothing Then
                    For Each _link In _node.Link
                        'перебрать связи узла по деревьям
                        Dim _newIdColl As New List(Of Integer)
                        For Each _linkId In _link.Value
                            If _linkId = _oldID Then
                                _newIdColl.Add(newID)
                                _changedLinkCount += 1
                                _changed = True
                            Else
                                _newIdColl.Add(_linkId)
                            End If
                        Next
                        _newlink.Add(_link.Key, _newIdColl)
                    Next
                    'заменить коллекцию
                    If _changed Then
                        _node.Link = _newlink
                    End If
                End If

            Next
        Next


        MsgBox("ID изменен с " & _oldID & " на " & newID & ". Ошибок " & _errors & " / изменено папок " & _changedFolderCount & " / изменено артикулов " & _changedArticulCount & " / изменено связей " & _changedLinkCount, vbInformation)
        Return True
    End Function


    ''' <summary>
    ''' поменяет все ID узлов, начиная с initialID. Последний доступный ID будет записан в LastFreeID. Вернет кол-во измененных связей.
    ''' </summary>
    ''' <param name="initialID"></param>
    ''' <param name="LastFreeID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CorrectIdTMP(initialID As Integer, ByRef LastFreeID As Integer) As Integer
        Dim _coll As New Dictionary(Of String, Dictionary(Of Integer, Integer))
        Dim _errors As Integer = 0
        For Each _tree In Me.oTreesCollection.Values
            'имя дерева, (старыйID,новыйID)
            Dim _tmp = _tree.CorrectIdTMP(initialID, LastFreeID)
            _coll.Add(_tmp.Key, _tmp.Value)
            initialID = LastFreeID
            'исправить в дереве директории с файлами
            Dim _basepeth = Me.GetDataFolderPathForTree(_tree, False)
            Dim _count As Integer = 0
            For Each _id In _tmp.Value
                ' (старыйID,новыйID)
                If IO.Directory.Exists(IO.Path.Combine(_basepeth, _id.Key)) Then
                    Try
                        IO.Directory.Move(IO.Path.Combine(_basepeth, _id.Key), IO.Path.Combine(_basepeth, _id.Value))
                        _count += 1
                    Catch ex As Exception
                        _errors += 1
                    End Try


                End If
            Next

            ''-перебрать все директории в директории дерева, содержащие определенное имя узла
            '
            'For Each _node In _tree
            '    'Dim _dircoll = IO.Directory.EnumerateDirectories(Me.GetDataFolderPathForTree(_tree, False), "*" & _node.Name & "*")
            '    Dim _dircoll = IO.Directory.EnumerateDirectories(Me.GetDataFolderPathForTree(_tree, False), "*" & _node.Name & "*")
            '    'проверить наличие в них файлов
            '    For i = 0 To _dircoll.Count - 1
            '        Dim _res = IO.Directory.GetFiles(_dircoll(i))
            '        If _res.Length > 0 Then
            '            'перенести файлы в  новую папку с ID
            '            For Each _file In _res
            '                If Not Me.AttachDataFile(_tree, _node, _file) = "" Then
            '                    _count += 1
            '                End If
            '            Next

            '        End If
            '    Next

            'Next
            MsgBox("для дерева " + _tree.TreeKeyName + " исправлено " + _count.ToString + " папок." & "Ошибок  - " & _errors, vbInformation)
        Next



        Dim _linkCount As Integer = 0

        'корректировка артикула



        'correct links
        'имя дерева, (старыйID,новыйID)
        For Each t In _coll
            'перебрать деревья
            Dim _tr = Me.oTreesCollection.Item(t.Key)
            For Each _node In _tr
                'перебрать узлы
                '


                'артикулы
                If _node.HasTiedNodes Then
                    Dim _newArticul As New List(Of Integer)
                    For Each ar In _node.GetTiedID
                        Dim ar1 = ar
                        'найти артикул
                        Dim _result = From c In _coll, c1 In c.Value Where c1.Key = ar1 Select c1.Value
                        If _result.Count > 0 Then
                            _newArticul.Add(_result(0))
                        End If
                    Next
                    If _newArticul.Count > 0 Then
                        _node.SetTiedNodes(_newArticul)
                    End If
                End If


                'связи
                Dim _newlink As New Dictionary(Of String, List(Of Integer))
                If Not _node.Link Is Nothing Then
                    For Each _link In _node.Link
                        'перебрать связи узла по деревьям
                        If _coll.ContainsKey(_link.Key) Then
                            Dim _Linkedtree = _coll(_link.Key)
                            Dim _newIdColl As New List(Of Integer)
                            For Each _linkId In _link.Value
                                'перебрать связи в пределах дерева
                                If _Linkedtree.ContainsKey(_linkId) Then
                                    Dim _newId = _Linkedtree(_linkId)
                                    _newIdColl.Add(_newId)
                                    _linkCount += 1
                                End If

                            Next
                            _newlink.Add(_link.Key, _newIdColl)
                        End If

                    Next
                    'заменить коллекцию
                    _node.Link = _newlink
                End If

            Next
        Next
        Return _linkCount
    End Function




    ''' <summary>
    ''' строит строку описания, добавляет элемент
    ''' </summary>
    ''' <param name="elements"></param>
    ''' <remarks></remarks>
    Public Sub AddElementToDescription(elements As XElement)
        Dim _xml As XElement = clsTreeService.GetRootDescriptionTag
        If Me.XMLDescriptionElement Is Nothing Then
            Me.oXMLDescription = _xml
        End If

        Me.oXMLDescription.Add(elements)

    End Sub
    ''' <summary>
    ''' коллекция имен деревьев
    ''' </summary>
    Public Function GetTreesNames() As List(Of String)
        Return Me.oTreesCollection.Keys
    End Function


    Public Sub RegisterChangedEvent()
        For Each t In Me.oTreesCollection.Values
            AddHandler t.PropertyChanged, AddressOf PropertyChanged_handler
        Next
    End Sub
    ''' <summary>
    ''' здесь ловим изменения в деревьях
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub PropertyChanged_handler(ByVal sender As Object, ByVal e As System.ComponentModel.PropertyChangedEventArgs)
        RaiseEvent TreeChanged(Me, New TreeChangedEventArg(sender))
    End Sub

    Friend Event TreeChanged(ByVal sender As Object, ByVal e As TreeChangedEventArg)

    Friend Class TreeChangedEventArg
        Inherits EventArgs
        Public Property TreeName As String
        Public Property Tree As ClsTree
        Public Sub New(ByVal Tree As ClsTree)
            Me.Tree = Tree
            Me.TreeName = Tree.TreeKeyName
        End Sub
    End Class

    ''' <summary>
    ''' создает пустое дерево с заданым именем и добавляет его в коллекцию деревьев
    ''' </summary>
    Friend Function CreateTree(ByRef Name As String) As ClsTree
        Debug.Assert(Name.Length > 0)
        If Name = "" Then Name = "Unnamed"
        If Me.oTreesCollection.ContainsKey(Name) Then Name = Name & "1"

        Dim _tree = ClsTree.CreateEmptyTree(Me, Name)
        AddHandler _tree.PropertyChanged, AddressOf PropertyChanged_handler
        AddHandler _tree.TreeNameChanged, AddressOf TreeNameChanged_eventHandler

        Me.oTreesCollection.Add(Name, _tree)

        Return _tree
    End Function

    ''' <summary>
    ''' удаляет дерево из коллекции
    ''' </summary>
    Friend Function RemoveTree(ByVal Name As String) As ClsTree
        Debug.Assert(Name.Length > 0)

        If Me.oTreesCollection.ContainsKey(Name) Then
            Dim _tmp = Me.oTreesCollection.Item(Name)
            Me.oTreesCollection.Remove(Name)
            Return _tmp
        End If

        Debug.Fail("попытка удалить несуществующее дерево")
        Return Nothing

    End Function
    ''' <summary>
    ''' открыть файл в браузере
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ShowBrowser(Optional ShowImagesFromInternet As Boolean = False)
        'показать главную htm
        Dim _path = IO.Path.ChangeExtension(Me.GroupFilePath, "htm")

        If _path.Length > 0 AndAlso IO.File.Exists(_path) Then
            System.Diagnostics.Process.Start(_path)
        Else
            'создать файл
            Me.Save_XML_HTML(True, True, ShowImagesFromInternet)
            System.Diagnostics.Process.Start(_path)
            'MsgBox("Отсутствует файл", vbCritical, clsTreeManager.AppHeader)
        End If

    End Sub
    ''' <summary>
    ''' сохраняет описание в буфере
    ''' </summary>
    Public Sub CopyDescriptionToClipboard()
        '------------------
        Dim _data As String = Me.XMLDescriptionElement.ToString
        Try
            My.Computer.Clipboard.Clear()
            My.Computer.Clipboard.SetText(_data, TextDataFormat.Text)
        Catch ex As Exception
            MsgBox("Ошибка при помещении данных в буфер обмена.", vbCritical)
        End Try
        '-----------------
    End Sub
    Public Sub ClearDescription()
        Me.oXMLDescription = Nothing
    End Sub

    ''' <summary>
    ''' перехватывает событие изменения имени
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TreeNameChanged_eventHandler(ByVal sender As Object, ByVal e As ClsTree.TreeNameChangedEventArgs)
        'Throw New NotImplementedException
        'изменить имя в коллекции
        Dim _obj = Me.oTreesCollection.Item(e.OldName)
        Dim _alt = Me.oTreesCollection.IndexOfValue(_obj)

        Me.oTreesCollection.RemoveAt(_alt)

        _obj.TreeKeyName = e.NewName

        Me.oTreesCollection.Add(e.NewName, _obj)

        'сообщить об этом форме!
        RaiseEvent TreeNameChanged(Me, e)
        RaiseEvent TreeChanged(Me, New TreeChangedEventArg(_obj))
    End Sub

    Friend Event TreeNameChanged(ByVal sender As Object, ByVal e As ClsTree.TreeNameChangedEventArgs)

    ' ''' <summary>
    ' ''' получить и конвертировать фото для узла
    ' ''' </summary>
    'Public Shared Function GetResizedImageForTree(ByVal ImageFileFullPath As String, Optional original As Boolean = False) As Image
    '    Debug.Assert(ImageFileFullPath.Length > 0)
    '    'get image
    '    If Not IO.File.Exists(ImageFileFullPath) Then Return Nothing
    '    Try
    '        Using _img = Image.FromFile(ImageFileFullPath, True)
    '            Dim _x = _img.Width
    '            Dim _y = _img.Height
    '            Dim _x1 As Integer = 0
    '            Dim _y1 As Integer
    '            If original Then
    '                Return _img.Clone
    '            Else
    '                _y1 = cntDbImageSize.Height
    '                Dim _prop = (_y / _y1)
    '                _x1 = Math.Round(_x / _prop)
    '                Return New Bitmap(_img.Clone, New Drawing.Size(_x1, _y1))
    '            End If
    '        End Using
    '    Catch ex As Exception
    '        Return Nothing
    '    End Try

    '    'Return _trb

    'End Function

    ''' <summary>
    ''' обьект культуры по умолчанию (Английский)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property EnglishCulture As Globalization.CultureInfo
        Get
            Return clsApplicationTypes.EnglishCulture
        End Get
    End Property

    ''' <summary>
    ''' обьект культуры Русский
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property RussianCulture As Globalization.CultureInfo
        Get
            Return clsApplicationTypes.RussianCulture
        End Get
    End Property



End Class
