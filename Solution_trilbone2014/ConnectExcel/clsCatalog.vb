
Public Class clsCatalog
    Private oBasePath As String
    Private oStrGroups As List(Of strGroup)
    Private ostrImages As List(Of clsImageCatalog)
    Private ostrSamples As List(Of strSample)

    Private Sub New()

    End Sub

    Public ReadOnly Property strGroups As List(Of strGroup)
        Get
            Return oStrGroups
        End Get

    End Property

    Public ReadOnly Property strSamples As List(Of strSample)
        Get
            Return Me.ostrSamples
        End Get

    End Property

    Public ReadOnly Property strImages As List(Of clsImageCatalog)
        Get
            Return ostrImages
        End Get

    End Property

    Public ReadOnly Property BasePath As String
        Get
            Return oBasePath
        End Get

    End Property

    Public ReadOnly Property Name As String
        Get
            Return New IO.DirectoryInfo(oBasePath).Name
        End Get

    End Property

    Private Function parse(path As String) As Boolean
        'здесь передан базовый путь каталога. надо перебрать все grops  samples  images
        Try

            oBasePath = path

            'SAMPLE
            Dim localPath = IO.Path.Combine(path, "Samples")

            ostrSamples = (From c In IO.Directory.EnumerateFiles(localPath) Where (c.ToLower.Contains("xml") And Not c.ToLower.Contains("template"))
                     Select strSample.CreateInstanse(IO.Path.Combine(localPath, c))).ToList

            'GROUPS
            localPath = IO.Path.Combine(path, "Groups")

            oStrGroups = (From c In IO.Directory.EnumerateFiles(localPath) Where (c.ToLower.Contains("xml") And Not c.ToLower.Contains("template"))
             Select strGroup.CreateInstanse(IO.Path.Combine(localPath, c))).ToList


            'Images
            localPath = IO.Path.Combine(path, "Images")

            ostrImages = (From c In IO.Directory.EnumerateDirectories(localPath)
             Select clsImageCatalog.CreateInstanse(IO.Path.Combine(localPath, c))).ToList

        Catch ex As Exception
            Return False
        End Try
        Return True

    End Function

    Public Shared Function CreateInstanse(BasePath As String, Optional version As String = "2") As clsCatalog
        Debug.Assert(IO.Directory.Exists(BasePath), "папка не существует")
        If Not IO.Directory.Exists(BasePath) Then Return Nothing
        Dim t As New clsCatalog()
        If t.parse(BasePath) Then Return t
        Return Nothing
    End Function

    Public Function GetstrImageByNumber(number As String) As clsImageCatalog
        For Each t In ostrImages
            If t.SampleNumber = number Then Return t
        Next
        Return Nothing
    End Function

End Class
