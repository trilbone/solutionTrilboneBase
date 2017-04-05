
Public Class clsImageCatalog
    Inherits clsImageFolder


    Private oLowImages As List(Of String)
    Dim oTitleImagesList As List(Of String)
    Public ReadOnly Property LowImages As System.Collections.Generic.List(Of String)
        Get
            Return oLowImages
        End Get

    End Property

    Public ReadOnly Property TitleImages As System.Collections.Generic.List(Of String)
        Get
            Return oTitleImagesList
        End Get

    End Property

    ''' <summary>
    ''' титульное изображение
    ''' </summary>
    Public Overrides ReadOnly Property Title As Image
        Get
            If oTitleImagesList.Count > 0 Then
                Dim p = IO.Path.Combine(oBasePath, "title", oTitleImagesList.First)

                Return Image.FromFile(p)
            End If
            Return Nothing

        End Get

    End Property


    Public Overrides ReadOnly Property BasePath As String
        Get
            Return IO.Path.Combine(oBasePath, "low")
        End Get

    End Property

    ''' <summary>
    ''' разбирает директорию, возвращает статус
    ''' </summary>
    ''' <param name="path">путь к файлу</param>
    Protected Overrides Function parse(path As String) As Boolean
        'Try
        oSampleNumber = New IO.DirectoryInfo(path).Name
        oBasePath = path

        Dim xlist = IO.Directory.EnumerateFiles(IO.Path.Combine(path, "high"))
        Dim c = From x In xlist Select x

        oHighImages = c.ToList

        xlist = IO.Directory.EnumerateFiles(IO.Path.Combine(path, "low"))
        Dim c1 = From x In xlist Select x

        oLowImages = c1.ToList

        xlist = IO.Directory.EnumerateFiles(IO.Path.Combine(path, "title"))
        Dim c2 = From x In xlist Select x

        oTitleImagesList = c2.ToList
        'Catch ex As Exception
        '    Return False
        'End Try

        Return True

    End Function

    Public Overrides Function ToString() As String
        Return SampleNumber
    End Function


    Public Overloads Shared Function CreateInstanse(path As String) As clsImageCatalog
        Debug.Assert(IO.Directory.Exists(path), "папка не существует")
        If Not IO.Directory.Exists(path) Then Return Nothing
        Dim t As New clsImageCatalog(path)
        If t.parse(path) Then Return t
        Return Nothing
    End Function


    Private Sub New(path As String)
        MyBase.New(path)
    End Sub
End Class


Public Class clsImageFolder

    Protected oHighImages As List(Of String)

    Protected oSampleNumber As String

    Protected oBasePath As String
    Protected oTitleImage As Image

    Public ReadOnly Property SampleNumber As String
        Get
            Return oSampleNumber
        End Get

    End Property

    Public ReadOnly Property HighImages As List(Of String)
        Get
            Return oHighImages
        End Get

    End Property




    ''' <summary>
    ''' титульное изображение
    ''' </summary>
    Public Overridable ReadOnly Property Title As Image
        Get
            Return oTitleImage

        End Get
       
    End Property

    Public Overridable ReadOnly Property BasePath As String
        Get
            Return oBasePath
        End Get

    End Property


    Public Shared Function CreateInstanse(path As String) As clsImageFolder
        Debug.Assert(IO.Directory.Exists(path), "папка не существует")
        If Not IO.Directory.Exists(path) Then Return Nothing
        Dim t As New clsImageFolder(path)
        If t.parse(path) Then Return t
        Return Nothing
    End Function

    ''' <summary>
    ''' разбирает директорию, возвращает статус
    ''' </summary>
    ''' <param name="path">путь к файлу</param>
    Protected Overridable Function parse(path As String) As Boolean
        'Try
        If Service.clsApplicationTypes.clsSampleNumber.CreateFromString(New IO.DirectoryInfo(path).Name) Is Nothing Then
            Return False
        Else
            oSampleNumber = Service.clsApplicationTypes.clsSampleNumber.CreateFromString(New IO.DirectoryInfo(path).Name).EAN13
        End If


        oBasePath = path

        Dim xlist = IO.Directory.EnumerateFiles(path)
        Dim c = From x In xlist Select x

        oHighImages = c.ToList


        'Catch ex As Exception
        '    Return False
        'End Try

        Return True

    End Function

    Public Overrides Function ToString() As String
        Return SampleNumber
    End Function


    Protected Sub New(path As String)

    End Sub







End Class
