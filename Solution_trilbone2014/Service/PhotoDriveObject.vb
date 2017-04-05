Imports System.Drawing
Imports System.Threading
Imports System.Runtime.Remoting.Messaging
Imports System.IO
Imports System.IO.MemoryMappedFiles
Imports System.Linq
Imports Service
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports System.Reflection



<Serializable()>
Public Class clsFilesSources
    Implements IComparable
    Implements IComparer(Of clsFilesSources)
    Public Enum emSources As Integer
        ''' <summary>
        ''' при выборе этого устройства путь не нужен
        ''' </summary>
        ''' <remarks></remarks>
        AZURE = 0

        ''' <summary>
        ''' папка arhive_photo. при выборе этого устройства путь не нужен
        ''' </summary>
        ''' <remarks></remarks>
        Arhive = 1

        ''' <summary>
        ''' все устройства для просмотра. при выборе этого устройства путь не нужен
        ''' </summary>
        ''' <remarks></remarks>
        AllSources = 2

        ''' <summary>
        ''' папка с заказом (требуется номер заказа)
        ''' </summary>
        ''' <remarks></remarks>
        SpecificOrder = 3

        ''' <summary>
        ''' любая папка с фото образца (требуется путь к папке)
        ''' </summary>
        ''' <remarks></remarks>
        FreeFolder = 4

        ''' <summary>
        ''' любая папка с инфой для проги (требуется путь к папке)
        ''' </summary>
        ''' <remarks></remarks>
        SystemVolume = 5




        ''' <summary>
        ''' папка (или сетевой) к описаниям
        ''' </summary>
        ''' <remarks></remarks>
        FolderForTrees = 6

        FtpInfoTrilbone = 7

        FtpMapTrilbone = 8

        FtpClientFolderTrilbone = 9

        FtpEbayPhotoArhive = 10

    End Enum

    'Private oConnection As iSource
    Private oSource As emSources
    Private oOrder As clsApplicationTypes.clsOrder
    Private oAllSources As Boolean
    Private oFreeFolder As String
    ' ''' <summary>
    ' ''' из строкового значения перечисления (потом разбирается)
    ' ''' </summary>
    ' ''' <param name="SourceString"></param>
    ' ''' <returns></returns>
    ' ''' <remarks></remarks>
    'Public Overloads Shared Function CreateInstance(ByVal SourceString As String) As clsFilesSources
    '    If SourceString.Length = 0 Then Return Nothing

    '    Dim _em As emSources = [Enum].Parse(GetType(emSources), SourceString)

    '    Return CreateInstance(_em)

    'End Function
    ' ''' <summary>
    ' ''' буфер подключений. Кей - экземпляр emSources
    ' ''' </summary>
    ' ''' <remarks></remarks>
    'Private Shared oConnectionBuffer As Generic.Dictionary(Of emSources, iSource)

    ''' <summary>
    ''' подключиться к устройству
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Connect() As iSource
        Debug.Assert(Me.AllSources = False, "Подключение к Allsources необходимо вызвать перегруженную версию!")
        Dim _connection As iSource = Nothing
        'init connection
        If Not clsConnectionBase.ConnectToSource(Me, _connection) Then
            Return Nothing
        End If
        Return _connection
    End Function


    Public Overloads Shared Function CreateInstance(ByVal SourceString As String) As clsFilesSources
        'для совместимости после переименования устройства.
        'TODO переделать вызывающие списки на использование перечисления, а не его текстового значения!!
        If SourceString = "Current" Then
            SourceString = "AZURE"
            Debug.Fail("Измени вызывающий обьект для использования перечисления, а не названия устройства!!")
        End If

        Dim _result As emSources
        If [Enum].TryParse(Of emSources)(SourceString, _result) Then
            Return clsFilesSources.CreateInstance(_result)
        End If
        Return Nothing
    End Function

    Public Shared Function Arhive() As clsFilesSources
        Return CreateInstance(emSources.Arhive)
    End Function

    Public Shared Function FTPinfoTRILBONE() As clsFilesSources
        Return CreateInstance(emSources.FtpInfoTrilbone)
    End Function
    Public Shared Function MapOnTRILBONE() As clsFilesSources
        Return CreateInstance(emSources.FtpMapTrilbone)
    End Function
    Public Shared Function EbayPhotoArhiveOnTRILBONE() As clsFilesSources
        Return CreateInstance(emSources.FtpEbayPhotoArhive)
    End Function
    Public Shared Function ClientPagesOnTRILBONE() As clsFilesSources
        Return CreateInstance(emSources.FtpClientFolderTrilbone)
    End Function



    Public Shared Function AZURE() As clsFilesSources
        Return CreateInstance(emSources.AZURE)
    End Function

    ''' <summary>
    ''' создает описатель устройства. При создании автоматически подключается к устройству.FreePath путь к папке!
    ''' </summary>
    ''' <param name="Source"></param>
    ''' <param name="Order"></param>
    ''' <param name="AllSources"></param>
    ''' <param name="FreePath"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Shared Function CreateInstance(ByVal Source As emSources, Optional ByVal Order As clsApplicationTypes.clsOrder = Nothing, Optional ByVal AllSources As Boolean = False, Optional ByVal FreePath As String = "", Optional CreateFreeFolder As Boolean = False) As clsFilesSources
        Dim _filesource As New clsFilesSources
        Select Case Source
            Case emSources.Arhive
                _filesource.oSource = emSources.Arhive
                _filesource.oAllSources = False
                _filesource.oOrder = Nothing
                _filesource.oFreeFolder = ""
            Case emSources.AZURE
                _filesource.oSource = emSources.AZURE
                _filesource.oAllSources = False
                _filesource.oOrder = Nothing
                _filesource.oFreeFolder = ""
            Case emSources.SpecificOrder
                If (Not Order = Nothing) AndAlso (Order.IsValidOrder = True) Then
                    _filesource.oSource = Source
                    _filesource.oAllSources = False
                    _filesource.oOrder = Order
                    _filesource.oFreeFolder = ""
                Else
                    Return Nothing
                End If
            Case emSources.FreeFolder
                If FreePath.Length > 0 Then
                    If Not FileIO.FileSystem.DirectoryExists(FreePath) Then
                        If CreateFreeFolder Then
                            Try
                                FileIO.FileSystem.CreateDirectory(FreePath)
                            Catch ex As Exception
                                Return Nothing
                            End Try
                        Else
                            Return Nothing
                        End If
                    End If


                    _filesource.oSource = Source
                    _filesource.oAllSources = False
                    _filesource.oOrder = Nothing
                    _filesource.oFreeFolder = FreePath
                Else
                    Return Nothing
                End If
            Case emSources.SystemVolume
                _filesource.oSource = Source
                _filesource.oAllSources = False
                _filesource.oOrder = Nothing
                _filesource.oFreeFolder = FreePath

            Case emSources.AllSources
                _filesource.oSource = Source
                _filesource.oAllSources = True
                _filesource.oOrder = Nothing
                _filesource.oFreeFolder = ""

            Case emSources.FtpInfoTrilbone
                _filesource.oSource = emSources.FtpInfoTrilbone
                _filesource.oAllSources = False
                _filesource.oOrder = Nothing
                _filesource.oFreeFolder = ""

            Case emSources.FtpMapTrilbone
                _filesource.oSource = emSources.FtpMapTrilbone
                _filesource.oAllSources = False
                _filesource.oOrder = Nothing
                _filesource.oFreeFolder = ""

            Case emSources.FtpEbayPhotoArhive
                _filesource.oSource = emSources.FtpEbayPhotoArhive
                _filesource.oAllSources = False
                _filesource.oOrder = Nothing
                _filesource.oFreeFolder = ""

            Case emSources.FtpClientFolderTrilbone
                _filesource.oSource = emSources.FtpClientFolderTrilbone
                _filesource.oAllSources = False
                _filesource.oOrder = Nothing
                _filesource.oFreeFolder = ""
            Case Else
                Debug.Fail("необходимо добавить в перечень новый тип устройства")
                _filesource.oSource = emSources.SystemVolume
        End Select
        Return _filesource

    End Function
    Private Sub New()

    End Sub

    Public ReadOnly Property AllSources As Boolean

        Get
            Return oAllSources
        End Get
    End Property


    Public ReadOnly Property Order As clsApplicationTypes.clsOrder

        Get
            Return Me.oOrder
        End Get
    End Property

    'Public ReadOnly Property Connection As iSource
    '    Get
    '        Return oConnection
    '    End Get
    'End Property

    Public ReadOnly Property Source As emSources

        Get
            Return oSource
        End Get
    End Property
    ''' <summary>
    ''' тут лежит путь к папке FreeFolder или SystemVolume - требуется для хранения в файловой системе
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ContainerPath As String
        Get
            Return oFreeFolder
        End Get
        Set(value As String)
            oFreeFolder = value
        End Set
    End Property


    Public Overrides Function Equals(ByVal obj As Object) As Boolean
        If obj Is Nothing Then Return False
        If Not TypeOf (obj) Is clsFilesSources Then Return False

        If CType(obj, clsFilesSources).GetID.Equals(Me.GetID) Then Return True

        'If CType(obj, clsFilesSources).Source.Equals(Me.Source) Then
        '    If CType(obj, clsFilesSources).Order.Equals(Me.Order) Then
        '        If CType(obj, clsFilesSources).AllSources.Equals(Me.AllSources) Then

        '            If CType(obj, clsFilesSources).FreePath.Equals(Me.FreePath) Then
        '                Return True
        '            End If

        '        End If
        '    End If
        'End If

        Return False

    End Function
    Private Function CompareTo(ByVal obj As Object) As Integer Implements System.IComparable.CompareTo
        If Not TypeOf (obj) Is clsFilesSources Then Return 0
        Return Compare(Me, obj)
    End Function

    Private Function Compare(ByVal x As clsFilesSources, ByVal y As clsFilesSources) As Integer Implements System.Collections.Generic.IComparer(Of clsFilesSources).Compare
        If x.Equals(y) Then Return 0
        If x.Source > y.Source Then Return -1
        Return 1
    End Function
    Public Shared Operator =(ByVal x As clsFilesSources, ByVal y As clsFilesSources) As Boolean
        If Not x.Source = y.Source Then Return False
        If Not x.Order = y.Order Then Return False
        If Not x.ContainerPath = y.ContainerPath Then Return False
        Return True
    End Operator
    Public Shared Operator <>(ByVal x As clsFilesSources, ByVal y As clsFilesSources) As Boolean
        If Not x.Source = y.Source Then Return True
        If Not x.Order = y.Order Then Return True
        If Not x.ContainerPath = y.ContainerPath Then Return True
        Return False
    End Operator
    Public Function GetID() As String
        Select Case Me.oSource
            Case emSources.SpecificOrder
                Return Me.oOrder.OrderID.Trim

            Case emSources.FreeFolder
                Return Me.oFreeFolder.Trim

            Case emSources.Arhive, emSources.AZURE, emSources.AllSources, emSources.SystemVolume, emSources.FtpInfoTrilbone, emSources.FtpMapTrilbone, emSources.FtpClientFolderTrilbone, emSources.FtpEbayPhotoArhive

                Return [Enum].GetName(GetType(emSources), Me.oSource).Trim
            Case Else
                Debug.Fail("добавить действие для вновь созданного элемента перечисления")
                Return "unknownsource"

        End Select
    End Function
    Public ReadOnly Property GetStringForUser As String
        Get
            Select Case Me.Source
                Case emSources.FreeFolder, emSources.SystemVolume
                    Return "Папка " & Me.ContainerPath
                Case emSources.AZURE
                    Return "Облако Azure"
                Case emSources.AllSources
                    Return "Все устройства хранения"
                Case emSources.Arhive
                    Return "GoogleDrive(локально)"
                Case emSources.SpecificOrder
                    If Not Me.Order Is Nothing Then
                        Return "Предложение " & Me.Order.OrderID
                    End If
                    Return [Enum].GetName(GetType(emSources), Me.oSource)
                Case Else
                    Return [Enum].GetName(GetType(emSources), Me.oSource)
            End Select
        End Get
    End Property



    ' ''' <summary>
    ' ''' выводит название типа устройства хранения - для лузера
    ' ''' </summary>
    ' ''' <returns></returns>
    ' ''' <remarks></remarks>
    'Public Overloads Function ToString(ForUser As Boolean) As String
    '    Select Case Me.Source
    '        Case emSources.FreeFolder, emSources.SystemVolume
    '            Return "Папка " & Me.ContainerPath
    '        Case emSources.AZURE
    '            Return "Облако Azure"
    '        Case emSources.AllSources
    '            Return "Все устройства хранения"
    '        Case emSources.Arhive
    '            Return "GoogleDrive(локально)"
    '        Case emSources.SpecificOrder
    '            If Not Me.Order Is Nothing Then
    '                Return "Предложение " & Me.Order.OrderID
    '            End If
    '            Return [Enum].GetName(GetType(emSources), Me.oSource)
    '        Case Else
    '            Return [Enum].GetName(GetType(emSources), Me.oSource)
    '    End Select
    'End Function
    ''' <summary>
    ''' выводит название типа устройства хранения - для программы
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overrides Function ToString() As String
        ' Return [Enum].GetName(GetType(emSources), Me.oSource)
        Select Case Me.Source
            Case emSources.FreeFolder, emSources.SystemVolume
                Return "Папка " & Me.ContainerPath
            Case emSources.AZURE
                Return "Облако Azure"
            Case emSources.AllSources
                Return "Все устройства хранения"
            Case emSources.Arhive
                Return "GoogleDrive(локально)"
            Case emSources.SpecificOrder
                If Not Me.Order Is Nothing Then
                    Return "Предложение " & Me.Order.OrderID
                End If
                Return [Enum].GetName(GetType(emSources), Me.oSource)
            Case Else
                Return [Enum].GetName(GetType(emSources), Me.oSource)
        End Select
    End Function

    ''' <summary>
    ''' список существующих устройств, кроме AllSources
    ''' </summary>
    Public Shared Function GetSourcesList() As List(Of emSources)

        Dim _result = (From c In [Enum].GetNames(GetType(emSources)) Where Not c = "AllSources" Select CType([Enum].Parse(GetType(emSources), c), emSources)).ToList

        Return _result


    End Function
    ''' <summary>
    ''' список обьектов для существующих устройств, кроме AllSources
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetSourcesListObj() As List(Of clsFilesSources)
        Dim _result = (From c In GetSourcesList() Select clsFilesSources.CreateInstance(c)).ToList
        Return _result


    End Function

    Public Overrides Function GetHashCode() As Integer
        Return Me.GetID.GetHashCode
    End Function



End Class

' ''' <summary>
' ''' описывает содержимое источника(папки) на устройстве хранения
' ''' </summary>
' ''' <remarks></remarks>
'Public Class clsInfoFolderDescriptor
'    ''' <summary>
'    ''' разбирает папку по файлам, создает структуру источника. 
'    ''' </summary>
'    ''' <returns>структуру - описатель источника (папки с номером или подпапки)</returns>
'    ''' <remarks>шаблоны поиска определяют разбираемые типы файлов</remarks>
'    Private Function Parse_Folder(path As String) As clsInfoFolderDescriptor
'        Debug.Assert(IO.Directory.Exists(Path) = True, "Обращение к несуществующей папке (Parse_Folder)")
'        If IO.Directory.Exists(Path) = False Then Return Nothing

'        'разбираем основную директорию
'        Dim _strSampleInfo As New clsInfoFolderDescriptor
'        _strSampleInfo.oFolderURI = Path

'        With _strSampleInfo
'            'искать все файлы
'            Dim _list_files As String()

'            '1 файлы изображений
'            Dim _coll As New Collections.Specialized.StringCollection
'            Dim _main As String = ""
'            For Each _em In [Enum].GetNames(GetType(clsInfoFolderDescriptor.emImageExtention))
'                For Each _path As String In GetFileNamesInFolder(Path, "*." & _em)
'                    If _path.StartsWith(_constMainImagePrephics) Then
'                        'главное фото
'                        _main = _path
'                    Else
'                        _coll.Add(_path)
'                    End If
'                Next
'            Next

'            Select Case _coll.Count
'                Case 0
'                    .oImageFileCollection.Clear()
'                    .MainImageFileName = ""
'                Case Else
'                    .oImageFileCollection = _coll
'                    .MainImageFileName = _main
'            End Select

'            '2. txt файл
'            _list_files = GetFileNamesInFolder(Path, _ConstTXTPattern)
'            Select Case _list_files.Length
'                Case 0
'                    .DataTXTFile = ""
'                Case 1
'                    .DataTXTFile = _list_files(0)
'                Case Is > 1
'                    'файлов больше чем 1
'                    'ошибка
'                    'берем первый
'                    MsgBox("Внимание! В источнике " & Path & " более одного .txt файла (допустим только один). Будет обработан первый по порядку.", MsgBoxStyle.Information)
'                    .DataTXTFile = _list_files(0)
'            End Select

'            '3. xml файл
'            _list_files = GetFileNamesInFolder(Path, _ConstXMLPattern)
'            Select Case _list_files.Length
'                Case 0
'                    .DataXMLFile = ""
'                Case 1
'                    .DataXMLFile = _list_files(0)
'                Case Is > 1
'                    'файлов больше чем 1
'                    'ошибка
'                    'берем первый
'                    MsgBox("Внимание! В источнике " & Path & " более одного .xml файла (допустим только один). Будет обработан первый по порядку.", MsgBoxStyle.Information)
'                    .DataXMLFile = _list_files(0)
'            End Select

'            '4. html файл
'            _list_files = GetFileNamesInFolder(Path, _ConstHTMLPattern)
'            Select Case _list_files.Length
'                Case 0
'                    .DataHTMLFile = ""
'                Case 1
'                    .DataHTMLFile = _list_files(0)
'                Case Is > 1
'                    'файлов больше чем 1
'                    'ошибка
'                    'берем первый
'                    MsgBox("Внимание! В источнике " & Path & " более одного .html файла (допустим только один). Будет обработан первый по порядку.", MsgBoxStyle.Information)
'                    .DataHTMLFile = _list_files(0)
'            End Select

'            '5. video file
'            _list_files = GetFileNamesInFolder(Path, _ConstVideoPattern)
'            Select Case _list_files.Length
'                Case 0
'                    .DataVideoFile = ""
'                Case 1
'                    .DataVideoFile = _list_files(0)
'                Case Is > 1
'                    'файлов больше чем 1
'                    'ошибка
'                    'берем первый
'                    MsgBox("Внимание! В источнике " & Path & " более одного video файла (допустим только один). Будет обработан первый по порядку.", MsgBoxStyle.Information)
'                    .DataVideoFile = _list_files(0)
'            End Select


'        End With

'        Return _strSampleInfo

'    End Function


'    ''' <summary>
'    ''' перечисление типов устойств(иерархии папок) хранения
'    ''' </summary>
'    ''' <remarks></remarks>
'    Public Enum emFolderType
'        ''' <summary>
'        ''' Основная папка с номером level 0
'        ''' </summary>
'        RootInfo = 0
'        ''' <summary>
'        ''' Подпапки с доп. информацией level1
'        ''' </summary>
'        AdditionalInfo = 1
'    End Enum

'    Friend Enum emImageExtention
'        jpg = 0
'        jpeg = 1
'        bmp = 2
'        tiff = 3
'    End Enum

'    ' ''' <summary>
'    ' ''' устройство хранения
'    ' ''' </summary>
'    ' ''' <remarks></remarks>
'    'Private oSource As strFilesSources
'    ''' <summary>
'    ''' корневой путь к папке на устройстве хранения. Однозначно индиентифицирует папку.
'    ''' </summary>
'    ''' <remarks></remarks>
'    Private oFolderURI As String
'    ''' <summary>
'    ''' тип папки хранения
'    ''' </summary>
'    ''' <remarks></remarks>
'    Private oFolderType As emFolderType
'    ''' <summary>
'    ''' коллекция файлов изображений
'    ''' </summary>
'    ''' <remarks></remarks>
'    Private oImageFileCollection As Collections.Specialized.StringCollection
'    ''' <summary>
'    ''' видеофайл
'    ''' </summary>
'    ''' <remarks></remarks>
'    Private DataVideoFile As String
'    ''' <summary>
'    ''' текстовый файл 
'    ''' </summary>
'    ''' <remarks>генерируется при оформлении</remarks>
'    Private DataTXTFile As String
'    ''' <summary>
'    ''' xml файл 
'    ''' </summary>
'    ''' <remarks>генерируется при оформлении</remarks>
'    Private DataXMLFile As String
'    ''' <summary>
'    ''' html файл 
'    ''' </summary>
'    ''' <remarks>генерируется при оформлении</remarks>
'    Private DataHTMLFile As String
'    ''' <summary>
'    ''' имя основного изображение образца 
'    ''' </summary>
'    ''' <remarks>генерируется при оформлении</remarks>
'    Private MainImageFileName As String


'    Sub New()
'        oImageFileCollection = New Collections.Specialized.StringCollection
'        MainImageFileName = ""
'    End Sub

'    ''' <summary>
'    ''' количество изображений
'    ''' </summary>
'    Public ReadOnly Property ImageCount As Integer
'        Get
'            Return Me.oImageFileCollection.Count
'        End Get

'    End Property






'    Public ReadOnly Property HasImages As Boolean
'        Get
'            If Me.ImageCount > 0 Then Return True
'            Return False
'        End Get
'    End Property









'    ''' <summary>
'    ''' возвращает массив путей к изображениям
'    ''' </summary>
'    ''' <returns></returns>
'    ''' <remarks></remarks>
'    Private Function GetImagePaths(Optional ByVal IncludeMainImage As Boolean = False) As String()
'        Dim _coll As New Collections.Specialized.StringCollection
'        For Each _str As String In Me.oImageFileCollection
'            _coll.Add(IO.Path.Combine(Me.oFolderURI, _str))
'        Next

'        '19.01.2012
'        If IncludeMainImage Then
'            'добавить главное изображение
'            If Not Me.MainImageFileName = "" Then
'                _coll.Add(IO.Path.Combine(Me.oFolderURI, Me.MainImageFileName))
'            End If
'        End If



'        Dim _arr(_coll.Count - 1) As String
'        If _coll.Count > 0 Then
'            _coll.CopyTo(_arr, 0)
'        End If
'        Return _arr
'    End Function

'    ''' <summary>
'    ''' путь к файлу. если файла нет, возвращает путь к новому файлу [номер].[расширение]
'    ''' </summary>
'    Public Function GetDataHTMLFileURI() As String
'        If Me.DataHTMLFile.Length > 0 Then
'            Return IO.Path.Combine(Me.oFolderURI, Me.DataHTMLFile)
'        Else
'            Dim _name As String = IO.Path.GetDirectoryName(Me.oFolderURI) & _ConstHTMLPattern
'            Return IO.Path.Combine(Me.oFolderURI, _name)
'        End If

'    End Function

'    ''' <summary>
'    ''' путь к файлу. если файла нет, возвращает путь к новому файлу [номер].[расширение]
'    ''' </summary>
'    Public Function GetDataTXTFileURI() As String
'        If Me.DataTXTFile.Length > 0 Then
'            Return IO.Path.Combine(Me.oFolderURI, Me.DataTXTFile)
'        Else
'            Dim _name As String = IO.Path.GetDirectoryName(Me.oFolderURI) & _ConstTXTPattern
'            Return IO.Path.Combine(Me.oFolderURI, _name)
'        End If

'    End Function

'    ''' <summary>
'    ''' путь к файлу. если файла нет, возвращает путь к новому файлу [номер].[расширение]
'    ''' </summary>
'    Public Function GetDataVideoFileURI() As String
'        If Me.DataVideoFile.Length > 0 Then
'            Return IO.Path.Combine(Me.oFolderURI, Me.DataVideoFile)
'        Else
'            Dim _name As String = IO.Path.GetDirectoryName(Me.oFolderURI) & _ConstVideoPattern
'            Return IO.Path.Combine(Me.oFolderURI, _name)
'        End If
'    End Function

'    ''' <summary>
'    ''' путь к файлу. если файла нет, возвращает путь к новому файлу [номер].[расширение]
'    ''' </summary>
'    Public Function GetDataXMLFileURI() As String
'        If Me.DataXMLFile.Length > 0 Then
'            Return IO.Path.Combine(Me.oFolderURI, Me.DataXMLFile)
'        Else
'            Dim _name As String = IO.Path.GetDirectoryName(Me.oFolderURI) & _ConstXMLPattern
'            Return IO.Path.Combine(Me.oFolderURI, _name)
'        End If
'    End Function
'    ''' <summary>
'    ''' возвращает ограниченный входным массивом набор путей 
'    ''' </summary>
'    ''' <param name="ImageNames">массив требуемых имен</param>
'    ''' <returns></returns>
'    ''' <remarks></remarks>
'    Private Function GetImagePath_FilterNames(ByVal ImageNames As String(), Optional ByVal IncludeMainImage As Boolean = False) As String()
'        Dim _coll As New Collections.Specialized.StringCollection
'        'перебрать входящие файлы
'        For Each _name In ImageNames
'            'найти в коллекции файлов
'            If Me.oImageFileCollection.Contains(_name) Then
'                'добавить на выход
'                _coll.Add(IO.Path.Combine(Me.oFolderURI, _name))

'                'добавлено 19.01.2012 работа с mainimage
'                If IncludeMainImage Then
'                    'проверить на наличие в имени главного изображения
'                    If Me.MainImageFileName.Contains(_name) Then
'                        'есть соответствие главному изображению
'                        _coll.Add(IO.Path.Combine(Me.oFolderURI, Me.MainImageFileName))
'                    End If
'                End If
'                '-----
'            Else
'                Debug.Fail("передано имя файла, отсутствующее в коллекции имен файлов образца")
'            End If
'        Next
'        Dim _arr(_coll.Count - 1) As String
'        If _coll.Count > 0 Then
'            _coll.CopyTo(_arr, 0)

'        End If
'        Return _arr
'    End Function


'    ''' <summary>
'    ''' возвращает путь к главному изображению образца
'    ''' </summary>
'    Public Function GetMainImageURI() As String
'        ' имя главного файла 
'        If Me.MainImageFileName = "" Then Return ""
'        Return IO.Path.Combine(Me.oFolderURI, Me.MainImageFileName)

'    End Function
'    'коллекция загруженных файлов в память
'    'value = уникальное имя файла. при одинаковых именах и разных путях, к имени прибавить цифру!
'    'key = уникальный путь к файлу на диске
'    Private Shared oImageInMemBuffer As New Collections.Generic.Dictionary(Of String, Image)


'    ''' <summary>
'    ''' получить одно изображение
'    ''' </summary>
'    ''' <param name="ImageName">имя файла</param>
'    Public Function GetImage(ByVal ImageName As String) As Image
'        Dim _tmp As String() = Me.GetImagePath_FilterNames({ImageName})
'        Select Case _tmp.Length
'            Case 0
'                'файла нет
'                Return Nothing
'            Case 1
'                'один файл
'                'исправлено 01.06.2011
'                Return clsInfoFolderDescriptor.LoadImage(_tmp(0))
'            Case Else
'                'более одного файла
'                Debug.Fail("(GetImage) Более одного файла c одинаковым именем!")
'                Return clsInfoFolderDescriptor.LoadImage(_tmp(0))
'        End Select

'    End Function
'    ''' <summary>
'    ''' вернет словарь изображений, где ключ - это имя изображения
'    ''' </summary>
'    ''' <returns></returns>
'    ''' <remarks></remarks>
'    Public Overloads Function GetImagesList() As Generic.Dictionary(Of String, Image)
'        Dim _result As New Generic.Dictionary(Of String, Image)
'        For Each i In Me.GetImagesURI
'            Dim _image = LoadImage(i)
'            If Not IsNothing(_image) Then
'                _result.Add(_image.Tag, _image)
'            End If
'        Next
'        Return _result
'    End Function
'    ''' <summary>
'    ''' вернет словарь изображений, где ключ - это имя изображения
'    ''' </summary>
'    ''' <returns></returns>
'    ''' <remarks></remarks>
'    Public Overloads Function GetImagesList(ByVal FilterNames As String()) As Generic.Dictionary(Of String, Image)

'        Dim _res = From c In FilterNames Select (From c1 In Me.GetImagesList Where c1.Key = c Select c1).FirstOrDefault

'        Return _res

'    End Function


'    ''' <summary>
'    ''' загружает обьект image файлом изображения.
'    ''' </summary>
'    ''' <param name="_path"></param>
'    ''' <returns></returns>
'    ''' <remarks></remarks>
'    Private Shared Function LoadImage(ByVal _path As String) As Image
'        Dim _image As Image = Nothing
'        'Dim _imageStream As IO.Stream
'        'Dim _iserr_status As Boolean = False

'        'переписано 06.10.2011
'        If Not IO.File.Exists(_path) Then
'            Debug.Fail("запрошенный файл не существует " & _path)
'            Return Nothing
'        End If

'        Dim _flagFromBuffer As Boolean = False
'        'ищем путь в буфере
'        If Not oImageInMemBuffer.ContainsKey(_path) Then
'            'такого пути в буфере нет
'            ''проверим наличие имени в буфере
'            'Dim _name As String = IO.Path.GetFileName(_path)
'            'If oImageInMemBuffer.ContainsValue(_name) Then
'            '    _name += "z"
'            'End If
'            Dim _buffer() As Byte
'            Try
'                'прочитаем файл в память
'                _buffer = File.ReadAllBytes(_path)
'            Catch ex As Exception
'                Debug.Fail("Ошибка чтения файла " & _path)
'                Return Nothing
'            End Try

'            'создать поток в памяти
'            Using _mmf As MemoryMappedFile = MemoryMappedFile.CreateNew(IO.Path.GetFileName(_path), _buffer.LongLength)

'                Using _Stream As MemoryMappedViewStream = _mmf.CreateViewStream()
'                    Dim _writer As BinaryWriter = New BinaryWriter(_Stream)
'                    _writer.Write(_buffer)
'                    _writer.Flush()
'                    Dim _tmp = Image.FromStream(_Stream)
'                    _image = _tmp.Clone
'                    _image.Tag = IO.Path.GetFileName(_path)

'                    _tmp = Nothing
'                    _writer.Close()
'                    _buffer = Nothing
'                    _Stream.Close()
'                    '--------------------
'                    ''изменить размер изображения в памяти до ширины 800
'                    ''добавлено 07.03.2012 - не работает!
'                    'Dim _OptimizeImageWight As Integer = 120
'                    'Dim _optimizeImageHeight As Integer
'                    'Dim _deleg As New System.Drawing.Image.GetThumbnailImageAbort(AddressOf _trubab)
'                    'Dim _optiImage As Image
'                    '_optimizeImageHeight = CType(_OptimizeImageWight / _image.Size.Width * _image.Size.Height, Integer)
'                    '_optiImage = _image.GetThumbnailImage(_OptimizeImageWight, _optimizeImageHeight, _deleg, System.IntPtr.Zero)
'                    '_image = _optiImage
'                    '-----------------------

'                End Using
'            End Using

'            If _image.Width = 5 Then

'            End If
'            'все успешно - поместим данные в буфер
'            If oImageInMemBuffer.Count > 10 Then oImageInMemBuffer.Clear()
'            oImageInMemBuffer.Add(_path, _image)
'        Else
'            'читаем из буфера
'            'Dim _name As String = oImageInMemBuffer.Item(_path)
'            'Using _mmf As MemoryMappedFile = MemoryMappedFile.OpenExisting(_name)
'            '    Using _Stream As MemoryMappedViewStream = _mmf.CreateViewStream()
'            '        _image = Image.FromStream(_Stream)
'            '    End Using
'            'End Using
'            If Not IO.File.Exists(_path) Then
'                Debug.Fail("Error! image " & _path & " not exist on disk!")
'            Else
'                _image = oImageInMemBuffer.Item(_path)
'                _flagFromBuffer = True
'            End If

'        End If
'        '------------------------
'        'Dim _buffer() As Byte
'        'Try
'        '    'прочитаем файл в память
'        '    _buffer = File.ReadAllBytes(_path)
'        'Catch ex As Exception
'        '    Debug.Fail("Ошибка чтения файла " & _path)
'        '    Return Nothing
'        'End Try

'        ''создать поток в памяти
'        'Using _mmf As MemoryMappedFile = MemoryMappedFile.CreateNew(IO.Path.GetFileName(_path), _buffer.LongLength)
'        '    Using _Stream As MemoryMappedViewStream = _mmf.CreateViewStream()
'        '        Dim _writer As BinaryWriter = New BinaryWriter(_Stream)
'        '        _writer.Write(_buffer)
'        '        _writer.Flush()
'        '        _image = Image.FromStream(_Stream)
'        '        _image.Tag = IO.Path.GetFileName(_path)
'        '        _writer.Close()
'        '    End Using
'        'End Using
'        '-----------------------

'        Return _image

'        'Try
'        '    _image = Drawing.Image.FromFile(_path)
'        'Catch ex As Exception
'        '    _iserr_status = True
'        'End Try

'        'If (Not _iserr_status) AndAlso (Not _image Is Nothing) Then
'        '    Return _image
'        'End If

'        'Return Nothing

'    End Function
'    'Private Shared Function _trubab() As Boolean
'    '    Return True
'    'End Function




'    ''' <summary>
'    ''' удаляет файлы на устройстве хранения
'    ''' </summary>
'    ''' <param name="FullPathsToDelete">массив путей к удаляемым файлам</param>
'    ''' <returns></returns>
'    ''' <remarks></remarks>
'    Private Shared Function DeleteFiles(ByVal FullPathsToDelete As String()) As Integer
'        Dim _count As Integer = 0
'        GC.Collect()
'        For Each _path In FullPathsToDelete
'            Debug.Assert(IO.File.Exists(_path), "файл, который требуется удалить, не существует")
'            If IO.File.Exists(_path) Then
'                My.Computer.FileSystem.DeleteFile(_path, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.SendToRecycleBin)
'                If oImageInMemBuffer.ContainsKey(_path) Then
'                    oImageInMemBuffer.Remove(_path)
'                End If
'                _count += 1
'            End If
'        Next
'        Return _count
'    End Function

'    ' ''' <summary>
'    ' ''' разбирает папку по файлам, создает структуру источника. 
'    ' ''' </summary>
'    ' ''' <param name="path">путь к папке</param>
'    ' ''' <returns>структуру - описатель источника (папки с номером или подпапки)</returns>
'    ' ''' <remarks>шаблоны поиска определяют разбираемые типы файлов</remarks>
'    'Private Shared Function Parse_Folder(ByVal path As String) As clsInfoFolderDescriptor
'    '    Debug.Assert(IO.Directory.Exists(path) = True, "Обращение к несуществующей папке (Parse_Folder)")
'    '    If IO.Directory.Exists(path) = False Then Return Nothing

'    '    'разбираем основную директорию
'    '    Dim _strSampleInfo As New clsInfoFolderDescriptor
'    '    _strSampleInfo.oFolderURI = path

'    '    With _strSampleInfo
'    '        'искать все файлы
'    '        Dim _list_files As String()

'    '        '1 файлы изображений
'    '        Dim _coll As New Collections.Specialized.StringCollection
'    '        Dim _main As String = ""
'    '        For Each _em In [Enum].GetNames(GetType(clsInfoFolderDescriptor.emImageExtention))
'    '            For Each _path As String In GetFileNamesInFolder(path, "*." & _em)
'    '                If _path.StartsWith(_constMainImagePrephics) Then
'    '                    'главное фото
'    '                    _main = _path
'    '                Else
'    '                    _coll.Add(_path)
'    '                End If
'    '            Next
'    '        Next

'    '        Select Case _coll.Count
'    '            Case 0
'    '                .oImageFileCollection.Clear()
'    '                .MainImageFileName = ""
'    '            Case Else
'    '                .oImageFileCollection = _coll
'    '                .MainImageFileName = _main
'    '        End Select

'    '        '2. txt файл
'    '        _list_files = GetFileNamesInFolder(path, _ConstTXTPattern)
'    '        Select Case _list_files.Length
'    '            Case 0
'    '                .DataTXTFile = ""
'    '            Case 1
'    '                .DataTXTFile = _list_files(0)
'    '            Case Is > 1
'    '                'файлов больше чем 1
'    '                'ошибка
'    '                'берем первый
'    '                MsgBox("Внимание! В источнике " & path & " более одного .txt файла (допустим только один). Будет обработан первый по порядку.", MsgBoxStyle.Information)
'    '                .DataTXTFile = _list_files(0)
'    '        End Select

'    '        '3. xml файл
'    '        _list_files = GetFileNamesInFolder(path, _ConstXMLPattern)
'    '        Select Case _list_files.Length
'    '            Case 0
'    '                .DataXMLFile = ""
'    '            Case 1
'    '                .DataXMLFile = _list_files(0)
'    '            Case Is > 1
'    '                'файлов больше чем 1
'    '                'ошибка
'    '                'берем первый
'    '                MsgBox("Внимание! В источнике " & path & " более одного .xml файла (допустим только один). Будет обработан первый по порядку.", MsgBoxStyle.Information)
'    '                .DataXMLFile = _list_files(0)
'    '        End Select

'    '        '4. html файл
'    '        _list_files = GetFileNamesInFolder(path, _ConstHTMLPattern)
'    '        Select Case _list_files.Length
'    '            Case 0
'    '                .DataHTMLFile = ""
'    '            Case 1
'    '                .DataHTMLFile = _list_files(0)
'    '            Case Is > 1
'    '                'файлов больше чем 1
'    '                'ошибка
'    '                'берем первый
'    '                MsgBox("Внимание! В источнике " & path & " более одного .html файла (допустим только один). Будет обработан первый по порядку.", MsgBoxStyle.Information)
'    '                .DataHTMLFile = _list_files(0)
'    '        End Select

'    '        '5. video file
'    '        _list_files = GetFileNamesInFolder(path, _ConstVideoPattern)
'    '        Select Case _list_files.Length
'    '            Case 0
'    '                .DataVideoFile = ""
'    '            Case 1
'    '                .DataVideoFile = _list_files(0)
'    '            Case Is > 1
'    '                'файлов больше чем 1
'    '                'ошибка
'    '                'берем первый
'    '                MsgBox("Внимание! В источнике " & path & " более одного video файла (допустим только один). Будет обработан первый по порядку.", MsgBoxStyle.Information)
'    '                .DataVideoFile = _list_files(0)
'    '        End Select


'    '    End With

'    '    Return _strSampleInfo

'    'End Function

'    ''' <summary>
'    ''' читает список файлов в директории по шаблону
'    ''' </summary>
'    ''' <param name="path">путь</param>
'    ''' <param name="pattern">фильтр файлов</param>
'    ''' <returns>список имен файлов</returns>
'    ''' <remarks></remarks>
'    Private Shared Function GetFileNamesInFolder(ByVal path As String, ByVal pattern As String) As String()
'        Dim _list_files As String()
'        'создать список файлов 
'        _list_files = IO.Directory.GetFiles(path, pattern)
'        'оставть только имена файлов
'        For i = 0 To _list_files.Length - 1
'            _list_files(i) = IO.Path.GetFileName(_list_files(i))
'        Next
'        Return _list_files
'    End Function

'    ' ''' <summary>
'    ' ''' просматривает корневую и дополнительные папки источника (папки образца)
'    ' ''' </summary>
'    ' ''' <param name="source">устройство источника</param>
'    ' ''' <returns>кол-во успешно разобранных папок (1 и боллее для одного источника)</returns>
'    ' ''' <remarks></remarks>
'    'Public Shared Function CreateInstances(source As clsFilesSources) As Collections.Generic.List(Of clsInfoFolderDescriptor)

'    '    Return source.Connection.GetDescriptors

'    '    'Dim _tmpclsInfoFolderDescriptor As clsInfoFolderDescriptor
'    '    'Dim _coll As New Collections.Generic.List(Of clsInfoFolderDescriptor)

'    '    ''просматриваем корневую папку
'    '    '_tmpclsInfoFolderDescriptor = source.Connection.Parse_Folder()
'    '    'If Not _tmpclsInfoFolderDescriptor Is Nothing Then
'    '    '    'корневая папка найдена
'    '    '    _tmpclsInfoFolderDescriptor.oFolderType = clsInfoFolderDescriptor.emFolderType.RootInfo
'    '    '    '_tmpclsInfoFolderDescriptor.oSource = source
'    '    '    _tmpclsInfoFolderDescriptor.oFolderURI = Path

'    '    '    ''добавить в коллекцию
'    '    '    _coll.Add(_tmpclsInfoFolderDescriptor)

'    '    '    'просмотреть подпапки
'    '    '    'просматриваем подпапки
'    '    '    For Each _tmpDirLevel2 As String In IO.Directory.GetDirectories(Path, "*", IO.SearchOption.AllDirectories)
'    '    '        _tmpclsInfoFolderDescriptor = clsInfoFolderDescriptor.Parse_Folder(_tmpDirLevel2)
'    '    '        If Not _tmpclsInfoFolderDescriptor Is Nothing Then
'    '    '            'подпапка найдена
'    '    '            _tmpclsInfoFolderDescriptor.oFolderType = clsInfoFolderDescriptor.emFolderType.AdditionalInfo
'    '    '            '_tmpclsInfoFolderDescriptor.oSource = source
'    '    '            _tmpclsInfoFolderDescriptor.oFolderURI = _tmpDirLevel2
'    '    '            'добавить в коллекцию
'    '    '            _coll.Add(_tmpclsInfoFolderDescriptor)
'    '    '        End If
'    '    '    Next
'    '    'End If
'    '    'Return _coll
'    'End Function
'    ''' <summary>
'    ''' записывает файл на устройство. 0 - не записан; -1 - ошибка; 1 - записан
'    ''' </summary>
'    ''' <param name="ImageName"></param>
'    ''' <param name="Image"></param>
'    ''' <param name="OptimizeImageWight">конечная ширина картинки. задать, если нужен ресайз. результирующий файл будет .jpg!</param>
'    ''' <param name="OverwriteIfExist">false для сохранения имеющегося файла на получателе</param>
'    ''' <returns></returns>
'    ''' <remarks></remarks>
'    Private Function AddFile(ByVal ImageName As String, ByVal Image As Image, Optional ByVal OptimizeImageWight As Integer = 0, Optional ByVal OverwriteIfExist As Boolean = True) As Integer
'        Debug.Assert(ImageName.Length > 0, "имя изображения не может быть пустым")
'        If ImageName.Length = 0 Then ImageName = "default.jpg"

'        Dim _JpegQuatly As emJpegQuality = emJpegQuality.High
'        Dim jpgEncoder As System.Drawing.Imaging.ImageCodecInfo = GetEncoder(Imaging.ImageFormat.Jpeg)
'        Dim MyEncoder As System.Drawing.Imaging.Encoder = System.Drawing.Imaging.Encoder.Quality
'        Dim MyEncoderParameters As New System.Drawing.Imaging.EncoderParameters(1)
'        Dim MyEncoderParameter As New System.Drawing.Imaging.EncoderParameter(MyEncoder, _JpegQuatly)
'        MyEncoderParameters.Param(0) = MyEncoderParameter

'        'resize image if request
'        If OptimizeImageWight > 0 Then
'            Try
'                ' Dim _image As Image = Image
'                Dim _resizedImage As Bitmap
'                Dim _optimizeImageHeight As Integer

'                _optimizeImageHeight = CType(OptimizeImageWight / Image.Size.Width * Image.Size.Height, Integer)
'                _resizedImage = New Bitmap(Image, New Size(OptimizeImageWight, _optimizeImageHeight))
'                Image = CType(_resizedImage, Image)
'            Catch ex As Exception
'                Return -1
'            End Try
'        End If

'        'get full path
'        Try
'            Dim _fullpath As String = IO.Path.Combine(Me.oFolderURI, ImageName)
'            If IO.File.Exists(_fullpath) Then
'                If Not OverwriteIfExist Then
'                    Return 0
'                Else
'                    IO.File.Delete(_fullpath)
'                End If
'            End If
'            'write file 
'            Image.Save(_fullpath, jpgEncoder, MyEncoderParameters)
'        Catch ex As Exception
'            Return -1

'        End Try

'        Return 1

'    End Function


'    '            ''' <summary>
'    '            ''' копирует файлы из источника в получатель
'    '            ''' </summary>
'    '            ''' <param name="SourcePaths">источник - массив полных путей</param>
'    '            ''' <param name="DestinationPaths">получатель - массив полных путей</param>
'    '            ''' <param name="OptimizeImageWight">конечная ширина картинки. задать, если нужен ресайз. результирующий файл будет .jpg! </param>
'    '            ''' <param name="OverwriteIfExist">true для удаления имеющегося файла на получателе</param>
'    '            ''' <param name="DeleteSource">true для удаления файла из источника</param>
'    '            ''' <returns></returns>
'    '            ''' <remarks></remarks>
'    '            Public Shared Function CopyFiles(ByVal SourcePaths As String(), ByVal DestinationPaths As String(), Optional ByVal OptimizeImageWight As Integer = 0, Optional ByVal OverwriteIfExist As Boolean = False, Optional ByVal DeleteSource As Boolean = False) As Integer
'    '                Debug.Assert(DestinationPaths.Length = SourcePaths.Length, "количество путей источника и получателя различны ")
'    '                Debug.Assert(SourcePaths.Length > 0, "Передано 0 путей для копирования")

'    '                Dim _count As Integer = 0
'    '                Dim _err As Boolean = False
'    '                Dim _index As Integer = 0

'    '                For Each _destin In DestinationPaths
'    '                    'проверка наличия на получателе
'    '                    If IO.File.Exists(_destin) Then
'    '                        'файл существует
'    '                        If Not OverwriteIfExist Then
'    '                            MsgBox("Файл " & _destin & "уже существует.", MsgBoxStyle.Critical)
'    '                            ' next file
'    '                            GoTo nextfile
'    '                        Else
'    '                            'удалим файл
'    '                            clsInfoFolderDescriptor.DeleteFiles({_destin})
'    '                        End If
'    '                    End If
'    '                    'проверка наличия на источнике
'    '                    If Not IO.File.Exists(SourcePaths(_index)) Then
'    '                        'файла нет
'    '                        MsgBox("Файл " & SourcePaths(_index) & "не существует.", MsgBoxStyle.Critical)
'    '                        ' next file
'    '                        GoTo nextfile
'    '                    End If
'    '                    'ресайз и копирование
'    '                    Select Case OptimizeImageWight
'    '                        Case 0
'    '                            'пишем как есть
'    '                            My.Computer.FileSystem.CopyFile(SourcePaths(_index), _destin, True)

'    '                            _count = _count + 1
'    '                        Case Else

'    '                            'проводим ресайз и пишем jpg!
'    '                            Dim _jpg As String = IO.Path.GetExtension(SourcePaths(_index)).ToLower
'    '                            _jpg = Right(_jpg, _jpg.Length - 1)

'    '                            If Not [Enum].IsDefined(GetType(clsInfoFolderDescriptor.emImageExtention), _jpg) Then
'    '                                Debug.Fail("попытка ресайза файла, не  зарегестрированного как возможный файл изображения. см emImageExtention")
'    '                                'next file
'    '                                GoTo nextfile
'    '                            End If


'    '                            Try
'    '                                Dim _image As Image = Image.FromFile(SourcePaths(_index))
'    '                                Dim _resizedImage As Bitmap
'    '                                Dim _optimizeImageHeight As Integer
'    '                                Dim _JpegQuatly As emJpegQuality = emJpegQuality.High

'    '                                _optimizeImageHeight = CType(OptimizeImageWight / _image.Size.Width * _image.Size.Height, Integer)
'    '                                _resizedImage = New Bitmap(_image, New Size(OptimizeImageWight, _optimizeImageHeight))
'    '                                _image = CType(_resizedImage, Image)

'    '                                Dim jpgEncoder As System.Drawing.Imaging.ImageCodecInfo = GetEncoder(Imaging.ImageFormat.Jpeg)
'    '                                Dim MyEncoder As System.Drawing.Imaging.Encoder = System.Drawing.Imaging.Encoder.Quality
'    '                                Dim MyEncoderParameters As New System.Drawing.Imaging.EncoderParameters(1)
'    '                                Dim MyEncoderParameter As New System.Drawing.Imaging.EncoderParameter(MyEncoder, _JpegQuatly)
'    '                                MyEncoderParameters.Param(0) = MyEncoderParameter

'    '                                _image.Save(_destin, jpgEncoder, MyEncoderParameters)
'    '                                _count = _count + 1

'    '                            Catch ex As Exception
'    '                                _err = True
'    '                            End Try

'    '                    End Select
'    '                    'удалим из источника по запросу
'    '                    If DeleteSource = True Then
'    '                        'удалим файл
'    '                        clsInfoFolderDescriptor.DeleteFiles({SourcePaths(_index)})
'    '                    End If
'    '                    '-----------------
'    'nextfile:

'    '                    _index += 1
'    '                Next

'    '                If _err Then
'    '                    Return _count * -1
'    '                Else
'    '                    Return _count
'    '                End If
'    '            End Function


'    Public Function GetMainImage() As Image
'        Dim _tmp As String = Me.GetMainImageURI
'        Select Case _tmp.Length
'            Case 0
'                'файла нет
'                Return Nothing
'            Case Else
'                Return clsInfoFolderDescriptor.LoadImage(_tmp)
'        End Select
'    End Function


'    Function GetMainImageName() As String
'        Dim _tmp As String = Me.GetMainImageURI
'        Select Case _tmp.Length
'            Case 0
'                'файла нет
'                Return ""
'            Case Else
'                '
'                Return IO.Path.GetFileName(_tmp)
'        End Select
'    End Function

'    ''' <summary>
'    ''' возвращает список имен файлов изображений
'    ''' </summary>
'    Public Function GetImagesKeyList() As String()
'        Dim _arr() As String = {String.Empty}
'        If oImageFileCollection.Count > 0 Then
'            ReDim _arr(oImageFileCollection.Count - 1)
'            oImageFileCollection.CopyTo(_arr, 0)
'        End If
'        Return _arr
'    End Function

'    ''' <summary>
'    ''' список URI изображений
'    ''' </summary>
'    ''' <returns></returns>
'    ''' <remarks></remarks>
'    Public Function GetImagesURI() As String()
'        Dim _arr() As String = {String.Empty}
'        If oImageFileCollection.Count > 0 Then
'            ReDim _arr(Me.GetImagePaths.Count - 1)
'            Me.GetImagePaths.CopyTo(_arr, 0)
'        End If
'        Return _arr
'    End Function

'    ''' <summary>
'    ''' удалить файлы. вернет список имен удаленных изображений
'    ''' </summary>
'    ''' <param name="FileNamesFilter">имена файлов</param>
'    ''' <param name="DeleteAll">удалить все файлы</param>
'    ''' <returns>
'    ''' </returns>
'    Public Function DeleteImages(ByVal FileNamesFilter As String(), ByVal DeleteAll As Boolean) As List(Of String)
'        Dim _dellist As New List(Of String)
'        Select Case Me.ImageCount
'            Case 0
'                'на источнике нет данных
'                Debug.Fail("на назначении нет изображений")
'            Case Else
'                'на источнике есть данные
'                Dim _deletePaths As String() = {}

'                If DeleteAll = True Then
'                    'удаляем все
'                    _deletePaths = Me.GetImagePaths(True)
'                Else
'                    'удаляем только требуемые
'                    _deletePaths = Me.GetImagePath_FilterNames(FileNamesFilter, True)
'                End If

'                'удалить файлы
'                Dim _count = clsInfoFolderDescriptor.DeleteFiles(_deletePaths)
'                If _count > 0 Then
'                    _dellist = (From c In _deletePaths Select IO.Path.GetFileName(c)).ToList
'                End If
'        End Select
'        Return _dellist
'    End Function

'    ''' <summary>
'    ''' копировать файлы в папку.статус копирования:-1 ошибка, на источнике нет данных.0  ничего не скопировано.,1 и более кол-во скопированных файлов.
'    ''' </summary>
'    ''' <param name="OptimizeImageWight">привести изображение к размеру</param>
'    ''' <returns>
'    ''' статус копирования
'    ''' -1 ошибка, на источнике нет данных.
'    ''' 0  ничего не скопировано.
'    ''' &gt;1 кол-во скопированных файлов
'    ''' </returns>
'    Public Overloads Function AddImages(ByVal FromDictionary As Generic.Dictionary(Of String, Image), Optional ByVal OptimizeImageWight As Integer = 0) As Integer
'        Debug.Assert(Not FromDictionary Is Nothing, "Передана пустая ссылка")
'        Dim _result As Integer = 0
'        Dim _tr As Integer
'        'проверка наличия key на получатели
'        Dim _found As New Generic.Dictionary(Of String, Image)
'        For Each t In Me.GetImagesKeyList
'            Dim _tmp As String = t
'            Dim _r1 = (From c In FromDictionary Where c.Key = _tmp Select c).FirstOrDefault
'            If Not IsNothing(_r1) Then
'                'запомним повтор и удалим их из входящих
'                _found.Add(_r1.Key, _r1.Value)
'                FromDictionary.Remove(_r1.Key)
'            End If
'        Next

'        If _found.Count > 0 Then
'            'на получатели есть файлы с таким именем
'            'на получателе данные уже есть, заменить?, добавить?
'            Dim _respond As String = InputBox("на получателе уже есть изображения, введите: 0 - для добавления новых к имеющимся (добавляемые будут переименованы), 1 - для перезаписи имеющихся и добавления отсутствующих, 2 - для удаления(!) всех имеющихся и записи новых.", "добавление/замена изображений", "1")
'            Dim _selector As Integer
'            Try
'                _selector = CType(_respond, Integer)

'            Catch ex As Exception
'                _selector = 1
'            End Try
'            If _selector > 2 Then _selector = 1
'            '-------------
'            Select Case _selector
'                Case 0
'                    'для добавления новых к имеющимся (добавляемые будут переименованы)
'                    'пишем, которых нет
'                    For Each t In FromDictionary
'                        _tr = Me.AddFile(t.Key, t.Value, OptimizeImageWight, False)
'                        If _tr = -1 Then
'                            Debug.Fail("ошипка при записи файла")
'                            Return -1
'                        End If
'                        _result += _tr
'                    Next
'                    'пишем, которые есть - переименовывая
'                    For Each t In _found
'                        _tr = Me.AddFile("1-" & t.Key, t.Value, OptimizeImageWight, False)
'                        If _tr = -1 Then
'                            Debug.Fail("ошипка при записи файла")
'                            Return -1
'                        End If
'                        _result += _tr
'                    Next

'                Case 1
'                    'для перезаписи имеющихся и добавления отсутствующих
'                    'пишем, которых нет
'                    For Each t In FromDictionary
'                        _tr = Me.AddFile(t.Key, t.Value, OptimizeImageWight, False)
'                        If _tr = -1 Then
'                            Debug.Fail("ошипка при записи файла")
'                            Return -1
'                        End If
'                        _result += _tr
'                    Next
'                    'пишем, которые есть - перезаписывая
'                    For Each t In _found
'                        _tr = Me.AddFile(t.Key, t.Value, OptimizeImageWight, True)
'                        If _tr = -1 Then
'                            Debug.Fail("ошипка при записи файла")
'                            Return -1
'                        End If
'                        _result += _tr
'                    Next
'                Case 2
'                    'для удаления(!) всех имеющихся и записи новых.
'                    'удалить все на получателе
'                    Me.DeleteImages({String.Empty}, True)
'                    'пишем, которых нет
'                    For Each t In FromDictionary
'                        _tr = Me.AddFile(t.Key, t.Value, OptimizeImageWight, False)
'                        If _tr = -1 Then
'                            Debug.Fail("ошипка при записи файла")
'                            Return -1
'                        End If
'                        _result += _tr
'                    Next
'                    'пишем, которые есть - перезаписывая
'                    For Each t In _found
'                        _tr = Me.AddFile(t.Key, t.Value, OptimizeImageWight, True)
'                        If _tr = -1 Then
'                            Debug.Fail("ошипка при записи файла")
'                            Return -1
'                        End If
'                        _result += _tr
'                    Next
'                Case Else
'                    Debug.Fail("элемент перечисления не задан")
'            End Select
'        End If
'        Return _result
'    End Function

'    ''' <summary>
'    ''' создает главное фото из указанного изображения на устройстве. Проводит ресайз до 160*120. true если все успешно.
'    ''' </summary>
'    ''' <param name="FromFileKey">имя файла исходника для майн фото</param>
'    ''' <param name="OptimizeImageWight">по умолчанию 160</param>
'    ''' <returns></returns>
'    ''' <remarks></remarks>
'    Public Function AddMainImage(ByVal FromFileKey As String, Optional ByVal OptimizeImageWight As Integer = 160) As Integer
'        'определить имя файла
'        Dim _mainfilename = _constMainImagePrephics & FromFileKey
'        'получить файл
'        Dim _image = Me.GetImage(FromFileKey)
'        If _image Is Nothing Then Return -1
'        'добавить его как главный
'        Return Me.AddFile(_mainfilename, _image, OptimizeImageWight, True)

'    End Function


'    Public Enum emJpegQuality
'        Fine = 100&
'        High = 85&
'        Normal = 75&
'        Low = 50&
'        VeryLow = 0&
'    End Enum


'    Private Shared Function GetEncoder(ByVal format As System.Drawing.Imaging.ImageFormat) As System.Drawing.Imaging.ImageCodecInfo

'        Dim codecs As System.Drawing.Imaging.ImageCodecInfo() = System.Drawing.Imaging.ImageCodecInfo.GetImageDecoders()

'        Dim codec As System.Drawing.Imaging.ImageCodecInfo
'        For Each codec In codecs
'            If codec.FormatID = format.Guid Then
'                Return codec
'            End If
'        Next codec
'        Return Nothing

'    End Function


'    Public Const _constMainImagePrephics As String = "main_"


'    Protected Const _ConstHTMLPattern As String = "*.html"


'    Protected Const _ConstTXTPattern As String = "*.txt"


'    Protected Const _ConstVideoPattern As String = "*.avi"


'    Protected Const _ConstXMLPattern As String = "*.xml"
'End Class




''' <summary>
''' управляет действиями над фото
''' </summary>
''' <remarks>сжатие, распаковка и т.п.</remarks>
Public Class clsSamplePhotoManager
    ''' <summary>
    ''' сравнитель изображений в списках
    ''' </summary>
    ''' <remarks></remarks>
    Class clsListViewItemComparer
        Implements IComparer

        Private col As Integer

        Public Sub New()
            col = 0
        End Sub

        Public Sub New(ByVal column As Integer)
            col = column
        End Sub

        Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer _
           Implements IComparer.Compare
            If Not TypeOf (x) Is ListViewItem Then Return 0
            If Not TypeOf (y) Is ListViewItem Then Return 0
            If CType(x, ListViewItem).Text = "" Then Return 0
            If CType(y, ListViewItem).Text = "" Then Return 0

            Dim _arrx = CType(x, ListViewItem).Text.Split(clsConnectionBase._cntSplitter, 2, StringSplitOptions.None)
            Dim _arry = CType(y, ListViewItem).Text.Split(clsConnectionBase._cntSplitter, 2, StringSplitOptions.None)

            If _arrx.Length <= 1 Then
                GoTo ex
            End If
            If _arry.Length <= 1 Then
                GoTo ex
            End If
            'тут нормальное сравнение
            Dim _resultx As Decimal
            Dim _resulty As Decimal
            If Decimal.TryParse(_arrx(0), _resultx) Then
                If Decimal.TryParse(_arry(0), _resulty) Then
                    Return Decimal.Compare(_resultx, _resulty)
                End If
            End If

            Return 0
ex:
            Return [String].Compare(CType(x, ListViewItem).Text, CType(y, ListViewItem).Text)
        End Function
    End Class



    Public Enum emJpegQuality
        Fine = 100&
        High = 85&
        Normal = 75&
        Low = 50&
        VeryLow = 0&
    End Enum
    Public Class RepositoryNotConnectedEventArgs
        Inherits EventArgs
        Public FileSource As clsFilesSources
    End Class

    Public Class ContentReadyForReadEventArgs
        Inherits EventArgs
        Public content As clsIDcontent
        Public [object] As Object
    End Class

    ''' <summary>
    ''' возникает, если обьект соединения с хранилищем выдает статус -1 (ошибка)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Event ConnectionError(sender As Object, e As EventArgs)
    ''' <summary>
    ''' возникает когда запрашиваемое хранилище недоступно
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Event RepositoryNotConnected(sender As Object, e As RepositoryNotConnectedEventArgs)

    ''' <summary>
    ''' внутренняя функция ожидания получения контента
    ''' </summary>
    ''' <param name="IDcontent"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ContentReadyGetter(IDcontent As clsIDcontent, FileSource As clsFilesSources) As Object
        Dim _tmp As Object = Nothing
        '-----version 1 - перехват появления в коллекции
        'проверим буфер
        If oReadyContentBuffer.ContainsKey(IDcontent.GetID) Then
            'есть в буфере
            Return oReadyContentBuffer(IDcontent.GetID)
        Else
            'нет в буфере
            'init connection
            Dim _connection As iSource = Me.GetConnection(IDcontent, FileSource)
            If _connection Is Nothing Then
                Return Nothing
            End If
            If Not _connection.ContainsContent(IDcontent) Then Return Nothing
            Dim _status As Integer
            'прочитать
            _connection.ReadKeyObj(IDcontent, _status, False)
        End If
        'подождем в буфере
        Dim i As Integer = 0
        Do Until oReadyContentBuffer.ContainsKey(IDcontent.GetID)
            i += 1
            If i > 20000 Then Return Nothing
        Loop
        _tmp = oReadyContentBuffer(IDcontent.GetID)
        If _tmp Is Nothing Then
            Debug.Fail("Не удалось получить обьект при вызове ReadObjectByKey")
        End If
        Return _tmp
    End Function

    ' ''' <summary>
    ' ''' обрабатывает событие добавления нового изображения
    ' ''' </summary>
    ' ''' <param name="sender"></param>
    ' ''' <remarks></remarks>
    'Public Shared Sub ContentReadyForRead_EventHandler(sender As Object, content As clsIDcontent)
    '    'If content.SampleNumber.Number = Me.oSampleNumber.Number Then
    '    '    'контент нужный
    '    '    'читаем файл
    '    '    Dim _img = CType(clsApplicationTypes.SamplePhotoObject.ReadyObjectBufferGetter(content.GetID), Image)
    '    '    If Not _img Is Nothing Then
    '    '        Me.AddImageItem(_img, content.Key)
    '    '    End If
    '    'End If
    'End Sub
    ''' <summary>
    ''' вернет лист первых(основных) фоток коллекции образцов
    ''' </summary>
    ''' <param name="SampleNumber"></param>
    ''' <param name="FileSource"></param>
    ''' <param name="ImageSizeInList"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetSampleCollectionImageList(ByVal SampleNumberCollection As clsApplicationTypes.clsSampleNumber(), ByVal FileSource As clsFilesSources, ByVal ImageSizeInList As Size) As SampleSourceImageList
        Debug.Assert(Not SampleNumberCollection Is Nothing, "передача пустой структуры номера образца недопустима")

        Dim _first = SampleNumberCollection(0)
        Dim _connection As iSource = Me.GetConnection(GetIdContent(_first.EAN13, "", clsIDcontent.emContentType.image), FileSource)
        If _connection Is Nothing Then
            Return New SampleSourceImageList(_first, FileSource)
        End If
        Dim _imagelist As SampleSourceImageList = New SampleSourceImageList(_first, _connection.DestinationFileSource)
        _imagelist.ImageListSize = ImageSizeInList

        For Each sn In SampleNumberCollection
            _connection = Me.GetConnection(GetIdContent(sn.EAN13, "", clsIDcontent.emContentType.image), FileSource)
            Dim _img As Image = Nothing
            'добавить ТОЛЬКО главное фото или первое из GetListKeys
            Dim _mainName = Me.GetMainImageName(sn, FileSource)
            If Not _mainName = "" Then
                'главное фото есть
                _img = Me.GetMainImage(FileSource, sn)
                If Not _img Is Nothing Then
                    _imagelist.AddImageItem(_img, sn.ShotCode)
                End If
            Else
                'главного фото нет
                'возьмем первое фото
                _mainName = _connection.GetListKeys(GetIdContent(sn.EAN13, "", clsIDcontent.emContentType.image)).FirstOrDefault
                If Not _mainName = "" Then
                    _img = Me.GetImage(FileSource, sn, _mainName, True)
                    If Not _img Is Nothing Then
                        _imagelist.AddImageItem(_img, sn.ShotCode)
                    End If
                Else
                    _imagelist.AddImageItem(Nothing, sn.ShotCode)
                End If
            End If
        Next

        Return _imagelist

    End Function


    ''' <summary>
    ''' возвращает imageList из устройства хранения
    ''' </summary>
    Public Function GetSampleImageList(ByVal SampleNumber As clsApplicationTypes.clsSampleNumber, ByVal FileSource As clsFilesSources, ByVal ImageSizeInList As Size, ByVal OnlyMainImage As Boolean, Optional ImageNameFilter As String() = Nothing) As SampleSourceImageList
        Debug.Assert(Not SampleNumber Is Nothing, "передача пустой структуры номера образца недопустима")

        'init connection
        Dim _connection As iSource = Me.GetConnection(GetIdContent(SampleNumber.EAN13, "", clsIDcontent.emContentType.image), FileSource)
        If _connection Is Nothing Then
            Return New SampleSourceImageList(SampleNumber, FileSource)
        End If

        Dim _imagelist As SampleSourceImageList

        _imagelist = New SampleSourceImageList(SampleNumber, _connection.DestinationFileSource)
        _imagelist.ImageListSize = ImageSizeInList

        ' oReadyContentBuffer.Clear()
        Dim _img As Image = Nothing
        'загружаем фотки в список КРОМЕ ГЛАВНОЙ (main image)
        If OnlyMainImage Then
            'добавить ТОЛЬКО главное фото или первое из GetListKeys
            Dim _mainName = Me.GetMainImageName(SampleNumber, FileSource)
            If Not _mainName = "" Then
                'главное фото есть
                _img = Me.GetMainImage(FileSource, SampleNumber)
                If Not _img Is Nothing Then
                    _imagelist.AddImageItem(_img, _mainName)
                End If
            Else
                'главного фото нет
                'возьмем первое фото
                _mainName = _connection.GetListKeys(GetIdContent(SampleNumber.EAN13, "", clsIDcontent.emContentType.image)).FirstOrDefault
                If Not _mainName = "" Then
                    _img = Me.GetImage(FileSource, SampleNumber, _mainName, True)
                    If Not _img Is Nothing Then
                        _imagelist.AddImageItem(_img, _mainName)
                    End If
                End If
            End If


        Else
            'добавить основные фото КРОМЕ ГЛАВНОЙ (main image)
            Dim _keys = _connection.GetListKeys(GetIdContent(SampleNumber.EAN13, "", clsIDcontent.emContentType.image))

            If Not ImageNameFilter Is Nothing Then
                _keys = _keys.Intersect(ImageNameFilter.ToList).ToList
            End If

            For Each _key In _keys
                _img = Me.GetImage(FileSource, SampleNumber, _key, True)
                If Not _img Is Nothing Then
                    _imagelist.AddImageItem(_img, _key)
                End If
            Next
        End If

#If DEBUG Then
        If Not _imagelist.Images.Count = _imagelist.ImageList.Images.Count Then
            MsgBox("Ошибка загрузки списка фото")
        End If
#End If


        Return _imagelist

    End Function
    ''' <summary>
    ''' пишет файл в контейнер с именем (задать). Имя и путь файла внутри контейнера определить как (папка/имя.расширение) = / обязательно!!!
    ''' при записи в файловую систему контейнер будет записан в папку, путь к которой лежит в свойстве ContainerPath. 
    ''' Если там будет пусто,то контейнер будет записан в папку локальных данных приложения.
    ''' </summary>
    ''' <param name="FileSource"></param>
    ''' <param name="IDContent"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function WriteFileToContainer(ByVal FileSource As clsFilesSources, IDContent As clsIDcontent, FileData As Object) As Integer
        'If FileSource.ContainerPath.Length = 0 Then
        '    'если корень не указан, то записать из установок приложения
        '    FileSource.ContainerPath = clsApplicationTypes.LocalDataFilePath
        'End If
        'init connection
        Dim _connection As iSource = Me.GetConnection(IDContent, FileSource)
        If _connection Is Nothing Then
            Return Nothing
        End If

        Dim _writestatus As Integer
        Dim _stream = clsIDcontent.ConvertToStream(IDContent, FileData)
        If Not _stream Is Nothing Then
            _writestatus = _connection.WriteKeyObj(IDContent, _stream, False)
            If _writestatus < 0 Then
                MsgBox(String.Format("Ошибка при записи файла {1} на {0}", FileSource.GetStringForUser, IDContent.ObjectKey))
            End If
        Else
            MsgBox(String.Format("Ошибка при записи файла {1} на {0}", FileSource.GetStringForUser, IDContent.ObjectKey))
            _writestatus = -1
        End If
        Return _writestatus
    End Function

    ''' <summary>
    ''' пишет файл в контейнер с именем (задать). Имя и путь файла внутри контейнера определить как (папка/имя.расширение) = / обязательно!!!
    ''' при записи в файловую систему контейнер будет записан в папку, путь к которой лежит в свойстве ContainerPath. 
    ''' Если там будет пусто,то контейнер будет записан в папку локальных данных приложения.
    ''' </summary>
    ''' <param name="ContainerName"></param>
    ''' <param name="FileNameAndPath"></param>
    ''' <param name="FileSource"></param>
    ''' <param name="TXTFileData"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function WriteFileToContainer(ContainerName As String, FileNameAndPath As String, ByVal FileSource As clsFilesSources, TXTFileData As String) As Integer
        Dim _content = GetIdContent(ContainerName, FileNameAndPath, contentType:=clsIDcontent.emContentType.text)
        Return Me.WriteFileToContainer(FileSource, _content, TXTFileData)
        'Return Me.WriteFileToContainer(ContainerName, FileNameAndPath, FileSource, clsIDcontent.ConvertToStream(_content, TXTFileData))
    End Function


    ''' <summary>
    ''' пишет файл в контейнер с именем (задать). Имя и путь файла внутри контейнера определить как (папка/имя.расширение) = / обязательно!!!
    ''' при записи в файловую систему контейнер будет записан в папку, путь к которой лежит в свойстве ContainerPath. Если там будет пусто,то контейнер будет записан в папку локальных данных приложения.
    ''' </summary>
    ''' <param name="ContainerName"></param>
    ''' <param name="FileNameAndPath"></param>
    ''' <param name="FileSource"></param>
    ''' <param name="FileData"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function WriteFileToContainer(ContainerName As String, FileNameAndPath As String, ByVal FileSource As clsFilesSources, FileData As Stream) As Integer
        Dim _content = GetIdContent(ContainerName, FileNameAndPath, contentType:=clsIDcontent.emContentType.stream)
        Return Me.WriteFileToContainer(FileSource, _content, FileData)


        'If FileSource.ContainerPath.Length = 0 Then
        '    'если корень не указан, то записать из установок приложения
        '    FileSource.ContainerPath = clsApplicationTypes.LocalDataFilePath
        'End If
        ''init connection
        'Dim _connection As iSource = Me.GetConnection(_content, FileSource)
        'If _connection Is Nothing Then
        '    Return Nothing
        'End If

        'Dim _writestatus As Integer
        'Dim _stream = clsIDcontent.ConvertToStream(_content, FileData)
        'If Not _stream Is Nothing Then
        '    _writestatus = _connection.WriteKeyObj(_content, _stream, False)
        'Else
        '    MsgBox("Ошибка при записи на устройство", vbCritical)
        '    _writestatus = -1
        'End If
        'Return _writestatus

    End Function
    ''' <summary>
    ''' читает файл и преобразует его в обьект из контейнера с именем (задать). Имя и путь файла внутри контейнера определить как (папка/имя.расширение) = / обязательно!!!
    ''' при чтении из файловой системы контейнер будет найден в папке, путь к которой лежит в свойстве ContainerPath
    ''' Если там будет пусто,то контейнер будет записан в папку локальных данных приложения.
    ''' </summary>
    ''' <param name="FileSource"></param>
    ''' <param name="IDcontent"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function ReadFileFromContainer(ByVal FileSource As clsFilesSources, IDcontent As clsIDcontent) As Object
        'If FileSource.ContainerPath.Length = 0 Then
        '    'если корень не указан, то записать из установок приложения
        '    FileSource.ContainerPath = clsApplicationTypes.LocalDataFilePath
        'End If
        Return ContentReadyGetter(IDcontent, FileSource)
    End Function

    Public Function DeleteFileFromContainer(ByVal FileSource As clsFilesSources, IDcontent As clsIDcontent) As Boolean
        'init connection
        Dim _connection As iSource = Me.GetConnection(IDcontent, FileSource)
        If _connection Is Nothing Then
            Return Nothing
        End If

        If _connection.DeleteKey(IDcontent) > 0 Then
            clsApplicationTypes.BeepYES()
            Return True
        Else
            Return False
        End If
    End Function


    ''' <summary>
    ''' читает файл из контейнера с именем (задать). Имя и путь файла внутри контейнера определить как (папка/имя.расширение) = / обязательно!!!
    ''' при чтении из файловой системы контейнер будет найден в папке, путь к которой лежит в свойстве ContainerPath
    ''' Если там будет пусто,то контейнер будет записан в папку локальных данных приложения.
    ''' </summary>
    ''' <param name="ContainerName"></param>
    ''' <param name="FileNameAndPath"></param>
    ''' <param name="FileSource"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function ReadFileFromContainer(ContainerName As String, FileNameAndPath As String, ByVal FileSource As clsFilesSources) As Stream
        Dim _content = GetIdContent(ContainerName, FileNameAndPath, contentType:=clsIDcontent.emContentType.stream)
        Return Me.ReadFileFromContainer(FileSource, _content)

    End Function



    ''' <summary>
    ''' вернет List(Of Image). вычислит макс. размер фото в листе.
    ''' </summary>
    ''' <param name="SampleNumber"></param>
    ''' <param name="FileSource"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetImageCollection(ByVal SampleNumber As clsApplicationTypes.clsSampleNumber, ByVal FileSource As clsFilesSources, IsLoppedObjects As Boolean, Optional ImageNameFilter As String() = Nothing) As List(Of Image)
        Dim _out As New List(Of Image)
        If SampleNumber Is Nothing Then Return New List(Of Image)

        'init connection
        Dim _connection As iSource = Me.GetConnection(GetIdContent(SampleNumber.EAN13, "", clsIDcontent.emContentType.image), FileSource)
        If _connection Is Nothing Then
            Return _out
        End If

        'иначе проблемы с фото
        oReadyContentBuffer.Clear()
        Dim _img As Image = Nothing
        'загружаем фотки в список КРОМЕ ГЛАВНОЙ (main image)
        Dim _keys = _connection.GetListKeys(GetIdContent(SampleNumber.EAN13, "", clsIDcontent.emContentType.image, IsLoppedObjects), ImageNameFilter)
        If _keys.Count > clsIDcontent.cntBufferSize Then
            ''увеличь резмер константы буфера до нужного числа
            MsgBox(String.Format("Папка образца содержит {0} фото, будет отображены первые {1}", _keys.Count, clsIDcontent.cntBufferSize), vbInformation)
            _keys = _keys.Take(clsIDcontent.cntBufferSize).ToList
        End If

        Dim _res = _keys.Select(Function(x) Me.GetImage(FileSource, SampleNumber, x, IsLoppedObjects)).ToList

        Return _res
    End Function


    ''' <summary>
    ''' возвращает список серий(папок) источника
    ''' </summary>
    ''' <param name="FileSource"></param>
    ''' <param name="Message"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetSeriesList(ByVal FileSource As clsFilesSources, ByRef Message As String) As String()
        Debug.Assert(FileSource.AllSources = False, "невозможно получить список образцов на всех устройствах")
        If FileSource.AllSources Then Return New String() {}
        'init connection
        Dim _connection As iSource = Me.GetConnection(FileSource)
        If _connection Is Nothing Then Return New String() {}
        Return _connection.GetSeriesList.ToArray
    End Function

    ''' <summary>
    ''' возвращает флаг наличия фото
    ''' </summary>
    ''' <param name="SampleNumber"></param>
    ''' <param name="FileSource"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function HasImages(ByVal SampleNumber As clsApplicationTypes.clsSampleNumber, ByVal FileSource As Service.clsFilesSources) As Boolean
        'Debug.Assert(FileSource.AllSources = False, "невозможно получить наличие фото на всех устройствах")
        'If FileSource.AllSources Then Return False
        ''init connection
        'Dim _connection As iSource = Me.GetConnection(FileSource)
        'If _connection Is Nothing Then Return False
        If Me.GetCountImages(SampleNumber, FileSource) = 0 Then
            Return False
        Else
            Return True
        End If
    End Function

    ''' <summary>
    ''' вернет кол-во изображений образца
    ''' </summary>
    ''' <param name="SampleNumber"></param>
    ''' <param name="FileSource"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetCountImages(ByVal SampleNumber As clsApplicationTypes.clsSampleNumber, ByVal FileSource As Service.clsFilesSources) As Integer
        Debug.Assert(FileSource.AllSources = False, "невозможно получить наличие фото на всех устройствах")
        If FileSource.AllSources Then Return False
        'init connection
        Dim _connection As iSource = Me.GetConnection(FileSource)
        If _connection Is Nothing Then Return False

        Return _connection.CountContent(GetIdContent(SampleNumber.EAN13, "", clsIDcontent.emContentType.image))
    End Function



    ''' <summary>
    ''' возвращает список имен файлов изображений
    ''' </summary>
    Public Function GetImageNamesList(ByVal SampleNumber As clsApplicationTypes.clsSampleNumber, ByVal FileSource As Service.clsFilesSources) As String()
        Debug.Assert(FileSource.AllSources = False, "невозможно получить список со всех устройств")
        If FileSource.AllSources Then Return New String() {}
        'init connection
        Dim _connection As iSource = Me.GetConnection(FileSource)
        If _connection Is Nothing Then Return New String() {}
        Return _connection.GetListKeys(GetIdContent(SampleNumber.EAN13, "", clsIDcontent.emContentType.image)).ToArray
    End Function
    ''' <summary>
    ''' вернет ссылку на контент
    ''' </summary>
    ''' <param name="IDContent"></param>
    ''' <param name="FileSource"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetContentURI(IDContent As clsIDcontent, FileSource As clsFilesSources) As Uri
        Debug.Assert(FileSource.AllSources = False, "невозможно получить список на всех устройствах")
        If FileSource.AllSources Then Return Nothing

        'init connection
        Dim _connection As iSource = Me.GetConnection(FileSource)
        If _connection Is Nothing Then Return Nothing
        Dim _status As Integer

        Dim _out = _connection.GetContentURI(IDContent, _status)
        If _status > 0 Then
            Return _out
        ElseIf _status = -1 Then
            RaiseEvent ConnectionError(Me, EventArgs.Empty)
        End If
        Return Nothing

    End Function

    ''' <summary>
    ''' возвращает список URI файлов требуемого типа на устройстве FileSource в контейнере ContainerName
    ''' </summary>
    ''' <param name="ContainerName"></param>
    ''' <param name="ContentType"></param>
    ''' <param name="FileSource"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetURIFromContainer(ContainerName As String, ContentType As clsIDcontent.emContentType, FileSource As clsFilesSources) As String()
        Debug.Assert(FileSource.AllSources = False, "невозможно получить список на всех устройствах")
        If FileSource.AllSources Then Return New String() {}

        'init connection
        Dim _connection As iSource = Me.GetConnection(FileSource)
        If _connection Is Nothing Then Return New String() {}


        Dim _keys As List(Of String) = _connection.GetListKeys(GetIdContent(ContainerName, "", ContentType))
        Dim _content As clsIDcontent
        Dim _uri As New List(Of Uri)
        Dim _tmp As Uri
        Dim _status As Integer

        For Each key In _keys
            'каждый файл
            _content = GetIdContent(ContainerName, key, clsIDcontent.emContentType.image)
            _tmp = _connection.GetContentURI(_content, _status)
            If _status > 0 Then
                _uri.Add(_tmp)
            ElseIf _status = -1 Then
                RaiseEvent ConnectionError(Me, EventArgs.Empty)
            End If
        Next
        'сдесь переделать возврат на тип uri
        If _uri.Count > 0 Then
            Dim _result() As String
            If _uri(0).IsAbsoluteUri Then
                _result = (From c In _uri Select c.AbsoluteUri).ToArray
            Else
                _result = (From c In _uri Select c.OriginalString).ToArray
            End If

            Return _result
        End If

        Return New String() {}

    End Function


    ''' <summary>
    ''' возвращает список URI файлов изображений на устройстве
    ''' </summary>
    Public Function GetImagesURI(ByVal SampleNumber As clsApplicationTypes.clsSampleNumber, ByVal FileSource As Service.clsFilesSources, Optional Filter As String() = Nothing) As Uri()
        Debug.Assert(FileSource.AllSources = False, "невозможно получить список на всех устройствах")
        If FileSource.AllSources Then Return New Uri() {}

        'init connection
        Dim _connection As iSource = Me.GetConnection(FileSource)
        If _connection Is Nothing Then Return New Uri() {}


        Dim _keys As List(Of String) = _connection.GetListKeys(GetIdContent(SampleNumber.EAN13, "", clsIDcontent.emContentType.image), Filter)

        Dim _content As clsIDcontent
        Dim _uri As New List(Of Uri)
        Dim _tmp As Uri
        Dim _status As Integer

        For Each key In _keys
            'каждый файл
            _content = GetIdContent(SampleNumber.EAN13, key, clsIDcontent.emContentType.image)
            _tmp = _connection.GetContentURI(_content, _status)
            If _status > 0 Then
                If Filter Is Nothing Then
                    _uri.Add(_tmp)
                Else
                    If Filter.Contains(key) Then
                        _uri.Add(_tmp)
                    End If
                End If

            ElseIf _status = -1 Then
                RaiseEvent ConnectionError(Me, EventArgs.Empty)
            End If
        Next
        'сдесь переделать возврат на тип uri
        If _uri.Count > 0 Then
            Dim _result() As String
            If _uri(0).IsAbsoluteUri Then
                _result = (From c In _uri Select c.AbsoluteUri).ToArray
            Else
                _result = (From c In _uri Select c.OriginalString).ToArray
            End If

            Return _uri.ToArray
        End If
        Return New Uri() {}
    End Function

    Private Class _IdContentBufferItem
        Implements IEquatable(Of _IdContentBufferItem)

        Public SampleNumber As String
        Public key As String
        Public contentType As clsIDcontent.emContentType
        Public IsLoppedObject As Boolean
        Public IdContentObject As clsIDcontent


        Public Overrides Function Equals(obj As Object) As Boolean
            If obj Is Nothing Then Return False
            If Not TypeOf obj Is _IdContentBufferItem Then Return False
            If Not Me.SampleNumber.Equals(obj.SampleNumber) Then Return False
            If Not Me.key.Equals(obj.key) Then Return False
            If Not Me.contentType.Equals(obj.contentType) Then Return False
            If Not Me.IsLoppedObject = obj.IsLoppedObject Then Return False
            Return True
        End Function

        Public Overrides Function GetHashCode() As Integer
            Return Me.SampleNumber.GetHashCode Xor Me.key.GetHashCode Xor Me.contentType.GetHashCode Xor Me.IsLoppedObject.ToString.GetHashCode

        End Function

        Public Overrides Function ToString() As String
            If Not Me.IdContentObject Is Nothing Then
                Me.IdContentObject.GetID()
            End If
            Return MyBase.ToString
        End Function

        Public Function Equals1(other As _IdContentBufferItem) As Boolean Implements IEquatable(Of _IdContentBufferItem).Equals
            Return Me.Equals(other)
        End Function
    End Class



    Private Shared oIdContentObjectBuffer As New List(Of _IdContentBufferItem)




    Public Shared Function GetIdContent(ContainerName As String, key As String, contentType As clsIDcontent.emContentType, Optional LoppedObject As Boolean = False) As clsIDcontent
        If key = "" Then key = "null"
        Dim _bufferItem As New _IdContentBufferItem
        _bufferItem.SampleNumber = ContainerName
        _bufferItem.key = key
        _bufferItem.contentType = contentType
        _bufferItem.IsLoppedObject = LoppedObject

        If oIdContentObjectBuffer.Contains(_bufferItem) Then
            Debug.Assert(Not oIdContentObjectBuffer.Item(oIdContentObjectBuffer.IndexOf(_bufferItem)).IdContentObject Is Nothing, "Ошибка в логике, обьект должен быть создан!")
            Return oIdContentObjectBuffer.Item(oIdContentObjectBuffer.IndexOf(_bufferItem)).IdContentObject
        Else
            Dim _new = clsIDcontent.CreateInstance(ContainerName, key, contentType, LoppedObject)
            Debug.Assert(Not _new Is Nothing, "Ошибка в логике, обьект должен быть создан!")
            'тут заменим наш ключ сгенерированным уникальным
            _bufferItem.key = _new.ObjectKey
            _bufferItem.IdContentObject = _new
            If oIdContentObjectBuffer.Count > 50 Then oIdContentObjectBuffer.Clear()
            oIdContentObjectBuffer.Add(_bufferItem)
            Return _new
        End If
    End Function
    ''' <summary>
    ''' создает контейнер(папку) для образца на запрашиваемом устройстве. Если fromSource не указано, будет использован Arhive, filter позволит указать нужные фото
    ''' ImageWidth задаст макс. ширину фото (по умолчанию 1600), 
    ''' при указании includeSmallContainer будет записан контейнер превьюшек по адресу \small\...
    ''' в URIlist будет помещены ссылки на фотки 
    ''' status >0 все ок. кол-во записанных фото(пропуски не считаем), 0 ошибка источника=фото нет, -1 ошибка при записи/чтении с устройства(серьезная), -2 ошибка входных параметров, -3 какой-то элемент isource не ест [key]='/small/img.jpg'
    ''' </summary>
    ''' <param name="SampleNumber"></param>
    ''' <param name="FileSource"></param>
    ''' <param name="fromSource"></param>
    ''' <param name="filter"></param>
    ''' <param name="ImageWidth"></param>
    ''' <param name="includeSmallContainer"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CreateSampleImagesContainerOnSource(SampleNumber As clsApplicationTypes.clsSampleNumber, FileSource As clsFilesSources, ByRef status As Integer, Optional ByRef URIlist As List(Of Uri) = Nothing, Optional fromSource As clsFilesSources = Nothing, Optional filter As String() = Nothing, Optional ImageWidth As Integer = 1600, Optional includeSmallContainer As Boolean = False) As clsFilesSources
        'проверки
        If SampleNumber Is Nothing Then status = -2 : Return Nothing
        If FileSource Is Nothing Then status = -2 : Return Nothing
        If FileSource.AllSources = True Then status = -2 : Return Nothing
        'доп условия
        If fromSource Is Nothing Then
            fromSource = clsFilesSources.CreateInstance(clsFilesSources.emSources.Arhive)
        End If
        If Me.HasImages(SampleNumber, fromSource) = False Then status = 0 : Return Nothing
        If FileSource = fromSource Then status = -2 : Return Nothing
        If filter Is Nothing Then
            filter = Me.GetImageNamesList(SampleNumber, fromSource)
        End If
        If filter Is Nothing OrElse filter.Length = 0 Then status = 0 : Return Nothing
        'тело
        Dim _status = Me.CopyImagesFromSourceToSource(SampleNumber, fromSource, FileSource, False, filter, ImageWidth)
        If _status = 0 Then status = 0 : Return Nothing
        If _status < 1 Then status = -1 : Return Nothing
        status = _status
        '-----------------
        If Not URIlist Is Nothing Then
            URIlist = Me.GetImagesURI(SampleNumber, FileSource, filter).ToList
        End If
        '-------------
        If includeSmallContainer Then
            Dim _iToSource = Me.GetConnection(FileSource)
            Dim _contentTo As clsIDcontent
            Dim _buff As Image
            For Each _namekey In filter
                _contentTo = GetIdContent(SampleNumber.EAN13, _namekey, clsIDcontent.emContentType.image, True)
                _buff = clsIDcontent.GetResizedImage(Me.GetImage(fromSource, SampleNumber, _namekey, False), clsIDcontent.constMainImageWidth)
                Try
                    Dim _writestatus = _iToSource.WriteKeyObj(_contentTo, clsIDcontent.ConvertToStream(_contentTo, _buff))
                    If _writestatus < 0 Then
                        MsgBox(String.Format("Ошибка при записи файла {1} на {0}", FileSource.GetStringForUser, _contentTo.ObjectKey))
                    End If
                Catch ex As Exception
                    status = -3
                    Return Nothing
                End Try
            Next
        End If

        Return FileSource

    End Function



    ''' <summary>
    ''' копирует изображения с устройства на устройство. Вернет кол-во скопированных файлов. -1 - ошибка. пишем, если фото отсутствует на устройстве!!!!
    ''' </summary>
    ''' <param name="FromSource">источник</param>
    ''' <param name="ToSource">получатель</param>
    ''' <param name="DeleteSourceFlag">удалить источник</param>
    Public Function CopyImagesFromSourceToSource(ByVal SampleNumber As clsApplicationTypes.clsSampleNumber, ByVal FromSource As clsFilesSources, ByVal ToSource As clsFilesSources, ByVal DeleteSourceFlag As Boolean, Optional ByVal FileNamesFilter As String() = Nothing, Optional ByVal OptimizeImageWight As Integer = 0, Optional includeSmallContainer As Boolean = False) As Integer
        Debug.Assert(ToSource.AllSources = False, "копирование на все устройства невозможно")
        If ToSource.AllSources Then Return -1

        'init connection
        Dim _FromConnection As iSource = Me.GetConnection(GetIdContent(SampleNumber.EAN13, "", clsIDcontent.emContentType.image), FromSource)
        If _FromConnection Is Nothing Then Return -1
        'init connection
        Dim _ToConnection As iSource = Me.GetConnection(ToSource)
        If _ToConnection Is Nothing Then Return -1


        Dim _keys = _FromConnection.GetListKeys(GetIdContent(SampleNumber.EAN13, "", clsIDcontent.emContentType.image), FileNamesFilter)
        Dim _content As clsIDcontent
        Dim _writestatus As Integer
        Dim _outStatus As Integer = 0
        'копируем файлы изображений
        For Each t In _keys
            _content = GetIdContent(SampleNumber.EAN13, t, clsIDcontent.emContentType.image)
            If Not _ToConnection.ContainsContent(_content) Then
                'пишем, если фото отсутствует на устройстве!!!!
                Dim _img = Me.GetImage(FromSource, SampleNumber, t, False)
                'преобразуем по запросу
                If OptimizeImageWight > 0 Then
                    _img = clsIDcontent.GetResizedImage(_img, OptimizeImageWight)
                End If

                'пишем
                Dim _stream = clsIDcontent.ConvertToStream(_content, _img)

                If Not _stream Is Nothing AndAlso _stream.CanRead = True Then
                    'пишем обычный обьект
                    _writestatus = _ToConnection.WriteKeyObj(_content, _stream, False)
                    If _writestatus < 0 Then
                        MsgBox(String.Format("Ошибка при записи файла {1} на {0}", ToSource.GetStringForUser, _content.ObjectKey))
                    Else
                        _outStatus += _writestatus
                    End If
                    If includeSmallContainer Then
                        Dim _loppedcontent = _content.GetAsLopped
                        'пишем мелкий обьект
                        _writestatus = _ToConnection.WriteKeyObj(_loppedcontent, clsIDcontent.ConvertToLoppedStream(_loppedcontent, _img), False)
                        If _writestatus < 0 Then
                            MsgBox(String.Format("Ошибка при записи файла {1} на {0}", ToSource.GetStringForUser, _content.ObjectKey))
                        Else
                            _outStatus += _writestatus
                        End If
                    End If
                Else
                    MsgBox(String.Format("Ошибка при записи файла {1} на {0}", ToSource.GetStringForUser, _content.ObjectKey))
                    '_writestatus = -1
                End If

                'If _writestatus > 0 Then
                '    _outStatus += _writestatus
                'End If

                _img = Nothing
                _writestatus = 0
            End If
        Next


        If DeleteSourceFlag Then
            Dim _status = _FromConnection.DeleteContainer(GetIdContent(SampleNumber.EAN13, "", clsIDcontent.emContentType.null))
            If _status > 0 Then
                _outStatus += 1
            ElseIf _status = -1 Then
                RaiseEvent ConnectionError(Me, EventArgs.Empty)
            End If
        End If
        Return _outStatus
    End Function

    ''' <summary>
    ''' удаляет фото с устройства. -1 - ошибка
    ''' </summary>
    ''' <param name="SampleNumber">номер образзца</param>
    ''' <param name="FileSource">устройство</param>
    ''' <param name="FileNamesFilter">массив имен файлов</param>
    ''' <param name="DeleteAllImageFiles">удалить все файлы</param>
    ''' <param name="DeleteFolder">удалить папку</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function DeleteImagesFromSource(ByVal SampleNumber As clsApplicationTypes.clsSampleNumber, ByVal FileSource As clsFilesSources, ByVal FileNamesFilter As String(), ByVal DeleteAllImageFiles As Boolean, ByVal DeleteFolder As Boolean) As Integer
        Debug.Assert(FileSource.AllSources = False, "невозможно удалить фото на всех устройствах")
        If FileSource Is Nothing Then Return -1
        If FileSource.AllSources Then Return -1
        'init connection
        Dim _content = GetIdContent(SampleNumber.EAN13, "", clsIDcontent.emContentType.image)
        Dim _connection As iSource = Me.GetConnection(_content, FileSource)
        If _connection Is Nothing Then Return -1

        Dim _keys As List(Of String)
        If DeleteAllImageFiles Then
            _keys = _connection.GetListKeys(_content)
        Else
            _keys = _connection.GetListKeys(_content, FileNamesFilter)

        End If

        ' Dim _content As clsIDcontent
        Dim _status As Integer
        Dim _result As Integer

        For Each key In _keys
            'удаляем каждый файл
            _content = GetIdContent(SampleNumber.EAN13, key, clsIDcontent.emContentType.image)
            _status = _connection.DeleteKey(_content)
            If _status > 0 Then
                _result += _status
            ElseIf _status = -1 Then
                RaiseEvent ConnectionError(Me, EventArgs.Empty)
            End If
        Next

        If DeleteFolder Then
            'delete block
            _content = GetIdContent(SampleNumber.EAN13, "", clsIDcontent.emContentType.null)
            _status = _connection.DeleteContainer(_content)
            If _status > 0 Then
                _result += _status
            ElseIf _status = -1 Then
                RaiseEvent ConnectionError(Me, EventArgs.Empty)

            End If
        End If

        Return _result

    End Function


    ''' <summary>
    ''' возвращает список номеров на устройстве
    ''' </summary>
    ''' <param name="FileSource">устройство</param>
    ''' <param name="Filter">фильтр</param>
    Public Function GetSampleListFromSource(ByVal FileSource As clsFilesSources, Optional ByVal Filter As String = "") As Collections.Generic.List(Of clsApplicationTypes.clsSampleNumber)
        Debug.Assert(FileSource.AllSources = False, "невозможно получить список образцов на всех устройствах")
        If FileSource.AllSources Then Return New List(Of clsApplicationTypes.clsSampleNumber)

        'init connection
        Dim _connection As iSource = Me.GetConnection(FileSource)
        If _connection Is Nothing Then Return New List(Of clsApplicationTypes.clsSampleNumber)

        Return _connection.GetSampleList(Filter)
    End Function

    Private Shared oConnectionBuffer As New Dictionary(Of clsFilesSources, iSource)

    ''' <summary>
    ''' управляет и инициализирует подключения
    ''' </summary>
    ''' <param name="Filesource"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Overloads Function GetConnection(Filesource As clsFilesSources) As iSource
        Debug.Assert(Filesource.AllSources = False, "Подключение к Allsources необходимо вызвать перегруженную версию!")
        Dim _connection As iSource = Nothing
        If oConnectionBuffer.ContainsKey(Filesource) Then Return oConnectionBuffer(Filesource)
        'init connection
        If Not clsConnectionBase.ConnectToSource(Filesource, _connection) Then
            Return Nothing
        End If
        AddHandler _connection.RepositoryNotConnected, AddressOf Me.RepositoryNotConnected_EventHandler
        AddHandler _connection.ContentReadyForRead, AddressOf Me.ContentReadyForRead_EventHandler
        'add in list
        oConnectionBuffer.Add(Filesource, _connection)
        Return _connection
    End Function

    ''' <summary>
    ''' управляет и инициализирует подключения.Ищет устройство, если на переданном нет файлов.
    ''' </summary>
    ''' <param name="Filesource"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Overloads Function GetConnection(IdContent As clsIDcontent, Filesource As clsFilesSources) As iSource
        Debug.Assert(Not Filesource Is Nothing, "Передано пустое устройство при запросе подключения!")
        If Filesource Is Nothing Then Return Nothing

        If oConnectionBuffer.ContainsKey(Filesource) Then Return oConnectionBuffer(Filesource)
        'init connection
        Dim _connection As iSource = Nothing
        If Filesource.AllSources Then
            If Not clsConnectionBase.FindConnection(IdContent, Filesource, _connection) Then
                Return Nothing
            End If
        End If
        If Not clsConnectionBase.FindConnection(IdContent, Filesource, _connection) Then

            Return Nothing
        End If
        AddHandler _connection.RepositoryNotConnected, AddressOf Me.RepositoryNotConnected_EventHandler
        AddHandler _connection.ContentReadyForRead, AddressOf Me.ContentReadyForRead_EventHandler
        'add in list
        oConnectionBuffer.Add(Filesource, _connection)
        Return _connection
    End Function

    Public Shared Function CreateInstance() As clsSamplePhotoManager
        Dim _new = New clsSamplePhotoManager
        Return _new
    End Function

    ''' <summary>
    ''' конструктор закрыт
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub New()

    End Sub

    ''' <summary>
    ''' вернет сортировщик для фоток
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetListViewComparier() As clsListViewItemComparer
        Return New clsListViewItemComparer
    End Function


    ''' <summary>
    ''' TextContentExtention - расширение файла без точки. Файл будет перезаписан.
    ''' </summary>
    ''' <param name="FileSource"></param>
    ''' <param name="SampleNumber"></param>
    ''' <param name="SampleInfoData"></param>
    ''' <param name="TextContentExtention"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function WriteSampleInfoToFile(ByVal FileSource As clsFilesSources, ByVal SampleNumber As clsApplicationTypes.clsSampleNumber, ByVal SampleInfoData As String, TextContentExtention As String) As Integer
        'create IDcontent
        Dim _content = clsIDcontent.CreateInstance(SampleNumber.EAN13, SampleNumber.ShotCode & "." & TextContentExtention, clsIDcontent.emContentType.text, False)
        'init connection
        Dim _connection As iSource = Me.GetConnection(GetIdContent(SampleNumber.EAN13, "", clsIDcontent.emContentType.text), FileSource)
        If _connection Is Nothing Then Return -1
        Dim _writestatus As Integer
        Dim _stream = clsIDcontent.ConvertToStream(_content, SampleInfoData)
        If Not _stream Is Nothing Then
            _writestatus = _connection.WriteKeyObj(_content, _stream, False)
            If _writestatus < 0 Then
                MsgBox(String.Format("Ошибка при записи файла {1} на {0}", FileSource.GetStringForUser, _content.ObjectKey))
            End If
        Else
            MsgBox(String.Format("Ошибка при записи файла {1} на {0}", FileSource.GetStringForUser, _content.ObjectKey))

            _writestatus = -1
        End If
        Return _writestatus
    End Function
    ''' <summary>
    ''' Отсортирует и переименует файлы в папке образца для УРЕЗАННЫХ фото.  -2 = ошибка инициализации сервиса, -1= ошибка при переименовании, 0 = переименование не требуется, >1 кол-во переименованных файлов 
    ''' </summary>
    ''' <param name="FileSource"></param>
    ''' <param name="SampleNumber"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ReorderLoppedPhoto(ByVal FileSource As clsFilesSources, ByVal SampleNumber As clsApplicationTypes.clsSampleNumber) As Integer


        'вызовет сервисную функцию SortAndRenameContent(Idcontent As clsIDcontent)
        Dim _content As clsIDcontent = GetIdContent(SampleNumber.EAN13, "", clsIDcontent.emContentType.image, True)
        If _content.ContentType = clsIDcontent.emContentType.null Then Return False
        Dim _connection As iSource = Me.GetConnection(_content, FileSource)
        If _connection Is Nothing Then Return -2
        Dim _service = _connection.CallService("SortAndRenameContent")
        If _service Is Nothing Then Return -2
        Dim _result = _service.Invoke(_content)
        Dim _outLopped = _result.Invoke(_connection, {_content})




        Return _outLopped


    End Function


    ''' <summary>
    ''' Отсортирует и переименует файлы в папке образца.  -2 = ошибка инициализации сервиса, -1= ошибка при переименовании, 0 = переименование не требуется, >1 кол-во переименованных файлов 
    ''' </summary>
    ''' <param name="FileSource"></param>
    ''' <param name="SampleNumber"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ReorderPhoto(ByVal FileSource As clsFilesSources, ByVal SampleNumber As clsApplicationTypes.clsSampleNumber) As Integer


        'вызовет сервисную функцию SortAndRenameContent(Idcontent As clsIDcontent)
        Dim _content As clsIDcontent = GetIdContent(SampleNumber.EAN13, "", clsIDcontent.emContentType.image, False)
        If _content.ContentType = clsIDcontent.emContentType.null Then Return False
        Dim _connection As iSource = Me.GetConnection(_content, FileSource)
        If _connection Is Nothing Then Return -2
        Dim _service = _connection.CallService("SortAndRenameContent")
        If _service Is Nothing Then Return -2
        Dim _result = _service.Invoke(_content)
        Dim _outNormal = _result.Invoke(_connection, {_content})





        Return _outNormal

     
    End Function


    ''' <summary>
    ''' Переименует изображение на устройстве
    ''' </summary>
    ''' <param name="FileSource"></param>
    ''' <param name="SampleNumber"></param>
    ''' <param name="ImageName"></param>
    ''' <param name="NewImageName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function RenameImage(ByVal FileSource As clsFilesSources, ByVal SampleNumber As clsApplicationTypes.clsSampleNumber, ByVal ImageName As String, NewImageName As String) As Boolean
        'init connection
        Dim _connection As iSource = Me.GetConnection(GetIdContent(SampleNumber.EAN13, "", clsIDcontent.emContentType.image), FileSource)
        If _connection Is Nothing Then Return Nothing
        Dim _content As clsIDcontent = GetIdContent(SampleNumber.EAN13, ImageName, clsIDcontent.emContentType.image)
        If _content.ContentType = clsIDcontent.emContentType.null Then Return False
        'вызвать синхронно
        Select Case _connection.RenameKey(_content, NewImageName)
            'Case -2
            '    'вызов стал асинхронным
            '    Debug.Fail("Ошибка в ReadKeyObj. Синхронный вызов был запущен как асинхронный")
            Case -1
                'ошибка при вызове
                Debug.Fail("Ошибка в RenameKey. Обьект небыл изменен из-за внутренней ошибки")
                Return False
            Case 0
                'обьект не найден
                Debug.Fail("Обьект не найден на устройстве")
                Return False
            Case Is > 0
                Return True
        End Select
        Return True
    End Function
    ''' <summary>
    ''' проверка наличия контента
    ''' </summary>
    ''' <param name="FileSource"></param>
    ''' <param name="Content"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function ContainsImage(ByVal FileSource As clsFilesSources, ByVal Content As clsIDcontent) As Boolean
        Dim _connection As iSource = Me.GetConnection(Content, FileSource)
        If _connection Is Nothing Then Return False
        Return _connection.ContainsContent(Content)
    End Function

    ''' <summary>
    ''' проверка наличия фото
    ''' </summary>
    ''' <param name="FileSource"></param>
    ''' <param name="SampleNumber"></param>
    ''' <param name="ImageName"></param>
    ''' <param name="IsLoppedImage"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function ContainsImage(ByVal FileSource As clsFilesSources, ByVal SampleNumber As clsApplicationTypes.clsSampleNumber, ByVal ImageName As String, IsLoppedImage As Boolean) As Boolean
        Dim _connection As iSource = Me.GetConnection(GetIdContent(SampleNumber.EAN13, "", clsIDcontent.emContentType.image), FileSource)
        If _connection Is Nothing Then Return False
        Dim _content As clsIDcontent
        If IsLoppedImage Then
            'пробуем получить обрезанный обьект
            _content = GetIdContent(SampleNumber.EAN13, ImageName, clsIDcontent.emContentType.image, True)
            If Not _connection.ContainsContent(_content) Then
                'мелкие фото отсутствуют, создать из обычной
                Me.CreateLoppedImageOnSource(_connection, _content.GetAsBig)
            End If
        Else
            _content = GetIdContent(SampleNumber.EAN13, ImageName, clsIDcontent.emContentType.image, False)
        End If
        Return _connection.ContainsContent(_content)
    End Function
    ''' <summary>
    ''' записывает мелкую фото из большой
    ''' </summary>
    ''' <param name="connection"></param>
    ''' <param name="content"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CreateLoppedImageOnSource(connection As iSource, content As clsIDcontent) As Boolean
        Dim _smallContent = content.GetAsLopped
        Dim _origimg = ContentReadyGetter(content, connection.DestinationFileSource)
        If _origimg Is Nothing Then Return False
        Dim _img = clsIDcontent.GetResizedImage(_origimg, clsIDcontent.constMainImageWidth)
        If connection.WriteKeyObj(_smallContent, clsIDcontent.ConvertToStream(_smallContent, _img)) >= 0 Then
            Return True
        Else
            MsgBox(String.Format("Ошибка при записи файла {1} на {0}", connection.DestinationFileSource.GetStringForUser, _smallContent.ObjectKey))
        End If
        Return False
    End Function


    ''' <summary>
    ''' получить одно изображение
    ''' </summary>
    ''' <param name="FileSource">хранилище</param>
    ''' <param name="SampleNumber">номер</param>
    ''' <param name="ImageName">имя файла</param>
    ''' <param name="IsLoppedImage">урезанный обьект</param>
    Public Function GetImage(ByVal FileSource As clsFilesSources, ByVal SampleNumber As clsApplicationTypes.clsSampleNumber, ByVal ImageName As String, IsLoppedImage As Boolean) As Image
        'init connection
        Dim _connection As iSource = Me.GetConnection(GetIdContent(SampleNumber.EAN13, "", clsIDcontent.emContentType.image), FileSource)
        If _connection Is Nothing Then Return Nothing
        Dim _content As clsIDcontent
        If IsLoppedImage Then
            'пробуем получить обрезанный обьект
            _content = GetIdContent(SampleNumber.EAN13, ImageName, clsIDcontent.emContentType.image, True)
            If Not _connection.ContainsContent(_content) Then
                'мелкие фото отсутствуют, создать из обычной
                CreateLoppedImageOnSource(_connection, _content.GetAsBig)
            End If
        Else
            _content = GetIdContent(SampleNumber.EAN13, ImageName, clsIDcontent.emContentType.image, False)
        End If
        Dim _obj = ContentReadyGetter(_content, FileSource)

        If Not _obj Is Nothing Then
            Dim _img As Image = CType(_obj, Image)
            _img.Tag = ImageName
            Return _img
        Else
            Return Nothing
        End If
    End Function
    ''' <summary>
    ''' получает список устройств, в которых присутствуют фото образца
    ''' </summary>
    Public Function GetSourcesList(ByVal SampleNumber As Service.clsApplicationTypes.clsSampleNumber, enableRemote As Boolean) As Collections.Generic.List(Of Service.clsFilesSources)
        If SampleNumber Is Nothing Then
            Return New Collections.Generic.List(Of Service.clsFilesSources)
        End If

        Return clsConnectionBase.GetExistConnectionList(GetIdContent(SampleNumber.EAN13, "", clsIDcontent.emContentType.image), enableRemote)

    End Function

    ''' <summary>
    ''' получить главное изображение. Если задан GetFirstIfNotExist, то вернет первую фото, если нет главной
    ''' </summary>
    ''' <param name="FileSource">хранилище</param>
    ''' <param name="SampleNumber">номер</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetMainImage(ByVal FileSource As clsFilesSources, ByVal SampleNumber As clsApplicationTypes.clsSampleNumber, Optional GetFirstIfNotExist As Boolean = False) As Image
        Debug.Assert((Not FileSource Is Nothing) AndAlso (FileSource.AllSources = False), "невозможно получить главное фото на всех устройствах")
        Dim _noimage = clsApplicationTypes.NoImage
        If FileSource Is Nothing OrElse FileSource.AllSources Then Return _noimage

        'init connection
        Dim _connection As iSource = Me.GetConnection(FileSource)
        If _connection Is Nothing Then Return Nothing

        Dim _content As clsIDcontent = Nothing
        Dim _mainKey = Me.GetMainImageName(SampleNumber, FileSource)
        If _mainKey = "" Then
            If GetFirstIfNotExist Then
                'берем первую фоту
                Dim _list = Me.GetImageNamesList(SampleNumber, FileSource)
                If _list.Count > 0 Then
                    _mainKey = _list(0)
                    _content = GetIdContent(SampleNumber.EAN13, _mainKey, clsIDcontent.emContentType.image, True)
                    Me.CreateLoppedImageOnSource(_connection, _content.GetAsBig)
                Else
                    Return _noimage
                End If
            Else
                Return _noimage
            End If
        Else
            _content = GetIdContent(SampleNumber.EAN13, _mainKey, clsIDcontent.emContentType.mainImage)
        End If

        Debug.Assert(Not _content Is Nothing)
        If _content Is Nothing Then Return _noimage

        'все ок
        Dim _obj = ContentReadyGetter(_content, FileSource)
        Dim _img As Image = clsIDcontent.ResizeToMainImage(CType(_obj, Image))

        If Not _img Is Nothing Then
            _img.Tag = _mainKey
            Return _img
        Else
            Return My.Resources.Resource.noimage
        End If
    End Function

    ''' <summary>
    ''' создает главное фото из указанного изображения на устройстве. Проводит ресайз до 160*120
    ''' </summary>
    ''' <param name="FromFileName">имя файла исходника для майн фото</param>
    ''' <param name="FileSource">устройство, где будет создано главное изображение</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CreateMainImageOnSource(ByVal SampleNumber As clsApplicationTypes.clsSampleNumber, ByVal FromFileName As String, ByVal FileSource As clsFilesSources) As Boolean
        Debug.Assert(FileSource.AllSources = False, "невозможно создать на всех устройствах главное фото")
        If FileSource.AllSources Then Return False

        'init connection
        Dim _connection As iSource = Me.GetConnection(GetIdContent(SampleNumber.EAN13, "", clsIDcontent.emContentType.mainImage), FileSource)
        If _connection Is Nothing Then Return False
        'from image
        Dim _img = Me.GetImage(FileSource, SampleNumber, FromFileName, False)
        If _img Is Nothing Then Return False
        Dim _content As clsIDcontent
        'удалим старое главное фото
        For Each t In _connection.GetListKeys(GetIdContent(SampleNumber.EAN13, "", clsIDcontent.emContentType.mainImage))
            _content = GetIdContent(SampleNumber.EAN13, t, clsIDcontent.emContentType.mainImage)
            _connection.DeleteKey(_content)
        Next
        'проводим ресайз до 160(*120)
        _img = clsIDcontent.ResizeToMainImage(_img)
        'пишем
        _content = GetIdContent(SampleNumber.EAN13, clsIDcontent.ConvertMainKeyFromImageKey(FromFileName), clsIDcontent.emContentType.mainImage)
        Dim _writestatus As Integer
        Dim _stream = clsIDcontent.ConvertToStream(_content, _img)
        If Not _stream Is Nothing Then
            _writestatus = _connection.WriteKeyObj(_content, _stream, False)
            If _writestatus < 0 Then
                MsgBox(String.Format("Ошибка при записи файла {1} на {0}", FileSource.GetStringForUser, _content.ObjectKey))
            End If
        Else
            MsgBox(String.Format("Ошибка при записи файла {1} на {0}", FileSource.GetStringForUser, _content.ObjectKey))
            _writestatus = -1
        End If
        If _writestatus > 0 Then
            Return True
        ElseIf _writestatus = -1 Then
            RaiseEvent ConnectionError(Me, EventArgs.Empty)
        End If
        Return False
    End Function

    Function GetMainImageName(ByVal SampleNumber As clsApplicationTypes.clsSampleNumber, ByVal FileSource As clsFilesSources) As String
        Debug.Assert(FileSource.AllSources = False, "невозможно получить имя фото на всех устройствах")
        If FileSource.AllSources Then Return ""
        'init connection
        Dim _connection As iSource = Me.GetConnection(FileSource)
        If _connection Is Nothing Then Return ""


        Dim _result = _connection.GetListKeys(GetIdContent(SampleNumber.EAN13, "", clsIDcontent.emContentType.mainImage))
        Select Case _result.Count
            Case 0
                Return ""
            Case 1
                Return _result(0)
            Case Is > 1
                'ошибка - более одного главного изображения
                '' Debug.Fail("ошибка - более одного главного изображения. нет реализации")
                Return _result(0)
        End Select
        Return ""

    End Function
    ''' <summary>
    ''' вернет делегат для вызова сервисной функции.
    ''' </summary>
    ''' <param name="FileSource"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ServiceCall(ByVal FileSource As clsFilesSources, name As String) As Func(Of Object, MethodInfo)
        Dim _connection As iSource = Nothing
        If Not clsConnectionBase.ConnectToSource(FileSource, _connection) Then
            Return Nothing
        End If

        'Dim _connection = clsConnectionBase.GetConnection(FileSource)
        'If _connection Is Nothing Then
        '    Return Nothing
        'End If
        AddHandler _connection.RepositoryNotConnected, AddressOf Me.RepositoryNotConnected_EventHandler

        Return _connection.CallService(name)
    End Function

    ''' <summary>
    ''' перехватывает событие об отсутствии соединения с хранилищем
    ''' </summary>
    Private Sub RepositoryNotConnected_EventHandler(sender As Object, message As String)
        Dim _e As New RepositoryNotConnectedEventArgs
        _e.FileSource = CType(sender, iSource).DestinationFileSource
        RaiseEvent RepositoryNotConnected(Me, _e)
    End Sub
    ''' <summary>
    ''' отвечает за хранение загруженного контента
    ''' </summary>
    ''' <remarks></remarks>
    Private Shared oReadyContentBuffer As New Dictionary(Of Integer, Object)

    ''' <summary>
    ''' перехватывает событие загрузки контента
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ContentReadyForRead_EventHandler(sender As Object, e As ContentReadyEventArgs)
        'тут можно получить готовый контент
        Debug.Assert(Not e.data Is Nothing, "сработало сообщение о готовности контента к чтению, но он nothing")
        'check obj
        Dim _obj = clsIDcontent.ConvertToObject(e.content, e.data)
        'обьект получен
        If _obj Is Nothing Then
            Debug.Fail("Ошибка при конвертации байт-массива в обьект")
            Return
        End If
        'obj created ok
        'check buffer size
        'ограничить буфер cntBufferSize контентами
        If oReadyContentBuffer.Count = clsIDcontent.cntBufferSize Then
            For Each t In oReadyContentBuffer.Values
                If TypeOf t Is Image Then
                    CType(t, Image).Dispose()
                End If
                t = Nothing
            Next
            oReadyContentBuffer.Clear()
            Return
            'Debug.Fail("В буфере более 1000 обьектов контента. Буфер будет очищен.")
        End If

        'place ready content into buffer
        If Not oReadyContentBuffer.ContainsKey(e.content.GetID) Then
            oReadyContentBuffer.Add(e.content.GetID, _obj)
        Else
            'buffer alredy contains content - replace it
            oReadyContentBuffer(e.content.GetID) = _obj
        End If

        'raise event
        'при синхронном вызове образует циклический вызов!!!!
        'Me.OnContentReadyForRead(New ContentReadyForReadEventArgs With {.content = e.content, .object = _obj})

    End Sub
    ''' <summary>
    ''' генериться, когда контент асинхронно загружен и читаемый обьект записан в буфер
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <remarks></remarks>
    Public Event ContentReadyForRead(sender As Object, e As ContentReadyForReadEventArgs)

    Private Sub OnContentReadyForRead(e As ContentReadyForReadEventArgs)
        RaiseEvent ContentReadyForRead(Me, e)
    End Sub


End Class

Public Class SampleSourceImageList
    Public Class LoadImageEventArgs
        Inherits System.EventArgs
        Public ImageName As String

    End Class

    Public Delegate Sub LoadImageEventHandler(ByVal sender As Object, ByVal e As LoadImageEventArgs)

    Public Event ImageLoaded As LoadImageEventHandler

    Sub New(ByVal SampleNumber As clsApplicationTypes.clsSampleNumber, ByVal FileSource As clsFilesSources)
        Me.oSampleNumber = SampleNumber
        Me.oImageList = New Windows.Forms.ImageList

        Me.oImageCollection = New List(Of Image)
        Me.oImageList.ImageSize = New Size(255, 255)
        Me.oImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit

        Me.oListViewItemCollection = New Collections.Generic.List(Of Windows.Forms.ListViewItem)
        Me.oFileSource = FileSource
    End Sub


    Private oSampleNumber As clsApplicationTypes.clsSampleNumber
    ''' <summary>
    ''' коллекция ListViewItem
    ''' </summary>
    Private oListViewItemCollection As Collections.Generic.List(Of Windows.Forms.ListViewItem)
    ''' <summary>
    ''' коллекция усеченных фото ImageList
    ''' </summary>
    Private oImageList As Windows.Forms.ImageList
    ''' <summary>
    ''' коллекция полных фоток
    ''' </summary>
    Private oImageCollection As List(Of Image)

    Public ReadOnly Property SampleNumber As clsApplicationTypes.clsSampleNumber
        Get
            Return oSampleNumber
        End Get
    End Property
    Private oFileSource As clsFilesSources
    Public ReadOnly Property FileSource As clsFilesSources
        Get
            Return oFileSource
        End Get
    End Property
    Public ReadOnly Property CountImages As Integer
        Get
            'changed 01.06.2011
            Return oImageList.Images.Count
            'Return oImageCollection.Count
        End Get
    End Property
    ''' <summary>
    ''' ImageList для форм (усеченные фото)
    ''' </summary>
    Public ReadOnly Property ImageList As Windows.Forms.ImageList
        Get
            Return oImageList
        End Get
    End Property
    ''' <summary>
    ''' ListViewItems для форм
    ''' </summary>
    Public ReadOnly Property ListViewItems As Windows.Forms.ListViewItem()
        Get
            Dim _tmp(0) As Windows.Forms.ListViewItem
            If Not Me.oListViewItemCollection Is Nothing Then
                'сортируем
                Me.oListViewItemCollection.Sort(Function(x, y) x.ImageKey > y.ImageKey)
                ReDim Preserve _tmp(Me.oListViewItemCollection.Count - 1)
                Me.oListViewItemCollection.CopyTo(_tmp)
            End If
            Return _tmp
        End Get
    End Property

    ''' <summary>
    ''' размер изображений в ImageList
    ''' </summary>
    Public Property ImageListSize As Size
        Get
            Return oImageList.ImageSize
        End Get
        Set(ByVal value As Size)

            'допустимый размер до 256px!
            If value.Width > 256 Then
                Dim _ratio As Single = value.Width / value.Height
                value.Width = 256
                value.Height = 256 / _ratio
            End If

            If value.Height > 256 Then
                value.Height = 256
            End If
            Me.oImageList.ImageSize = value

        End Set
    End Property

    ''' <summary>
    ''' фото
    ''' </summary>
    Default Public Overloads Property Item(ByVal index As Integer) As Image
        Get
            'changed 01.06.2011
            'Return oImageCollection(index)
            Return oImageList.Images(index)
        End Get
        Set(ByVal value As Image)
            If value Is Nothing Then Exit Property
            'changed 01.06.2011
            'Me.oImageCollection(index) = value
            oImageList.Images(index) = value
        End Set
    End Property

    Default Public Overloads ReadOnly Property Item(ByVal key As String) As Image
        Get
            Dim _index As Integer = -1

            For Each _tmp As Windows.Forms.ListViewItem In Me.oListViewItemCollection
                If _tmp.Name = key Then
                    _index = _tmp.Index
                End If
            Next

            If _index = -1 Then
                Return Nothing
            End If
            Return Me.oImageList.Images(_index)
        End Get

    End Property

    'deleted 01.06.2011
    'undelete property 05.09.2011
    'it used in datasource in text defenition
    Public ReadOnly Property Images As List(Of Image)
        Get
            Return oImageCollection
        End Get
    End Property

    ''' <summary>
    ''' добавляет фото в коллекцию listviewitem. _listviewitem.Name = _filename
    ''' </summary>
    Public Function AddImageItem(ByVal Image As Image, ByVal ImageKey As String) As Boolean
        Debug.Assert(ImageKey.Length > 0, "SampleSourceImageList -> AddImageItem -> key of image is ""!!")
        If ImageKey.Length = 0 Then
            Dim _rnd As New Random
            ImageKey = _rnd.Next.ToString & ".jpg"
        End If
        'add 23.02.2013
        'проверка наличия ключа в коллекции
        Dim _res = (From c In Me.oListViewItemCollection Where c.ImageKey = ImageKey Select c).ToList.Count
        If _res > 0 Then
            'ключ уже есть
            Return False
        End If

        If Image Is Nothing Then
            Image = My.Resources.Resource.noimage
        End If

        'key нужен для однозначной индиентификации фото при показе в отдельном окне
        'настроить ратио
        Dim _r As Single = Image.Size.Width / Image.Size.Height

        Dim _size = New Size(120 * _r, 120)

        'преобразовать Image
        Me.oImageCollection.Add(Image)
        'добавить в коллекцию
        Me.oImageList.Images.Add(ImageKey, Image)

        Dim _listviewitem As Windows.Forms.ListViewItem
        _listviewitem = New Windows.Forms.ListViewItem
        _listviewitem.Name = ImageKey
        _listviewitem.ImageKey = ImageKey
        _listviewitem.Text = ImageKey

        Me.oListViewItemCollection.Add(_listviewitem)

        Dim _e As New LoadImageEventArgs
        _e.ImageName = ImageKey
        RaiseEvent ImageLoaded(Me, _e)
        Return True

    End Function
    ''' <summary>
    ''' удаляет обьект изображения из коллекций и из памяти. результат - да, если удален; нет - если такой обект не найден.ключ - имя файла
    ''' </summary>
    ''' <param name="ImageKey">ключ - имя файла</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function RemoveImageItem(ByVal ImageKey As String) As Boolean
        Debug.Assert(ImageKey.Length > 0, "ImageKey не может быть пустым")


        Dim _del As Windows.Forms.ListViewItem = Nothing
        For Each _tmp As Windows.Forms.ListViewItem In Me.oListViewItemCollection
            If _tmp.Name.Equals(ImageKey) Then
                _del = _tmp
            End If
        Next

        If _del Is Nothing Then
            Return False
        Else
            Me.oListViewItemCollection.Remove(_del)

            'удалить из коллекций
            If Me.oImageList.Images.ContainsKey(ImageKey) Then
                Me.oImageList.Images.RemoveByKey(ImageKey)
            Else
                Return False
            End If

            Dim _idel As Image = Nothing
            For Each _img As Image In Me.oImageCollection
                If _img.Tag.ToString.Equals(ImageKey) Then
                    _idel = _img
                End If
            Next
            If Not _idel Is Nothing Then
                Me.oImageCollection.Remove(_idel)
                _idel.Dispose()
            Else
                Return False
            End If

            Return True
        End If



        ''added 05.09.2011
        'Me.oImageCollection.RemoveAt(_index)
        'Me.oListViewItemCollection.RemoveAt(_index)

        'удалить обьект
        '_image.Dispose()
        '_image = Nothing

        'Return True

    End Function


End Class

