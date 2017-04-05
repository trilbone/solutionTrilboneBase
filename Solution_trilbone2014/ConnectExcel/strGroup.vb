Imports System.Xml
Imports System.ComponentModel
Imports System.Xml.Linq

Public Structure strGroup
    Private oName As String
    ''' <summary>
    ''' имя группы
    ''' </summary>
    Public ReadOnly Property NAME As String
        Get
            Return oName
        End Get
    End Property
    Dim oCount As Integer

    ''' <summary>
    ''' кол-во в группе
    ''' </summary>
    Public ReadOnly Property COUNT As Integer
        Get
            Return oCount
        End Get
    End Property
    Private oSampleList As List(Of String)

    ''' <summary>
    ''' список образцов в группе
    ''' </summary>
    Public ReadOnly Property SampleList As List(Of String)
        Get
            If oSampleList Is Nothing Then
                Return New List(Of String)
            End If

            Return oSampleList
        End Get
    End Property
    Private Sub New(path As String)

    End Sub
    Public Shared Function CreateInstanse(path As String) As strGroup
        Debug.Assert(IO.File.Exists(path), "файл не существует")
        If Not IO.File.Exists(path) Then Return Nothing
        Dim t As New strGroup(path)
        If t.parse(path) Then Return t
        Return Nothing
    End Function


    ''' <param name="path">путь к файлу</param>
    Private Function parse(path As String) As Boolean

        Try
            'разберем xml файл
            Dim dc As XElement = XElement.Load(path)

            'NAME
            Dim c = From s In dc...<NAME> Select s.Value

            oName = c.First

            'COUNT
            Dim c1 = From s In dc...<COUNT> Select s.Value

            oCount = Integer.Parse(c1.First)

            'Sample list
            Dim c2 = From s In dc...<SAMPLE> Select s.@BAR

            oSampleList = c2.ToList
        Catch ex As Exception
            Return False
        End Try

        Return True

    End Function


End Structure
