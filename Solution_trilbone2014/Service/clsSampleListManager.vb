Imports System.Linq
Imports System.Xml.Linq
<Serializable()>
Public Class clsSampleListManager
    Inherits List(Of clsSampleList)

    Public Function GetListByName(ListName As String) As clsSampleList
        For Each t In Me
            If t.NameOfList = ListName Then Return t
        Next
        Return Nothing
    End Function

    ''' <summary>
    ''' файлу списков
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Property ListFileName As String

    Public ReadOnly Property version As String
        Get
            Return 1
        End Get
    End Property
    ''' <summary>
    ''' 0 - списка с таким именем нет // 1 - ок // -1 ошибка
    ''' </summary>
    ''' <param name="SampleListName"></param>
    ''' <param name="SampleNumber"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function AddSampleInList(SampleListName As String, SampleNumber As Service.clsApplicationTypes.clsSampleNumber) As Integer
        Dim _list = (From c In Me Where c.NameOfList = SampleListName Select c).FirstOrDefault
        If _list Is Nothing Then Return -1
        If SampleNumber Is Nothing Then
            'добавить номер
            Return -1
        End If

        'проверка наличия в списке
        If _list.Contains(SampleNumber) Then Return 0
        _list.Add(SampleNumber, SampleNumber.GetExtendedInfo.AnyName, SampleNumber.GetExtendedInfo.SampleNickName, SampleNumber.GetExtendedInfo.Prices.BasePrice, SampleNumber.GetExtendedInfo.Prices.Currency)
        Return 1

    End Function
    Public Function GetSampleItemFromList(SampleListName As String, SampleNumber As Service.clsApplicationTypes.clsSampleNumber) As clsSampleListItem
        If Me.ContainsInList(SampleListName, SampleNumber) Then
            Dim _list = (From c In Me Where c.NameOfList = SampleListName Select c).FirstOrDefault
            Return _list.Find(Function(x) (x.SampleNumberEAN13 = SampleNumber.GetEan13))
        End If


        'If _list Is Nothing Then Return False
        ''проверка наличия в списке
        'If _list.Contains(SampleNumber) Then Return True
        Return Nothing
    End Function


    Public Function ContainsInList(SampleListName As String, SampleNumber As Service.clsApplicationTypes.clsSampleNumber) As Boolean
        Dim _list = (From c In Me Where c.NameOfList = SampleListName Select c).FirstOrDefault
        If _list Is Nothing Then Return False
        'проверка наличия в списке
        If _list.Contains(SampleNumber) Then Return True
        Return False
    End Function

    Public Function RemoveSampleFromList(SampleListName As String, SampleNumber As Service.clsApplicationTypes.clsSampleNumber) As Boolean
        Dim a = (From c In Me Where c.NameOfList = SampleListName Select c).FirstOrDefault
        If a Is Nothing Then Return False
        Return a.Remove(SampleNumber)
    End Function
    ''' <summary>
    ''' вернет дерево обьекта
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetXML() As String
        Dim _d As New XDeclaration("1.0", "UTF-16", "true")

        Dim _xml As XElement = <DATA version=<%= Me.version %>>
                                   <%= From c In Me Select c.GetListXML %>
                               </DATA>

        Dim _xd As New XDocument(_d, _xml)
        Dim _wr As New IO.StringWriter()
        _xd.Save(_wr, SaveOptions.None)
        _wr.Flush()
        _wr.ToString()
        Return _wr.ToString
    End Function


    Public Function GetShotCollection(SampleListName As String) As String()
        Dim a = (From c In Me Where c.NameOfList = SampleListName Select c).FirstOrDefault
        If a Is Nothing Then Return New String() {}
        Return a.Select(Function(x) (x.ShotNumber)).ToArray
    End Function

    Public Function GetEAN13Collection(SampleListName As String) As String()
        Dim a = (From c In Me Where c.NameOfList = SampleListName Select c).FirstOrDefault
        If a Is Nothing Then Return New String() {}
        Return a.Select(Function(x) (x.SampleNumberEAN13)).ToArray
    End Function


    Public Function CreateSampleList(SampleListName As String, Optional SampleListDescription As String = "") As Boolean
        Dim a As New clsSampleList
        a.NameOfList = SampleListName
        a.Description = SampleListDescription
        a.Parent = Me
        If Not Me.Contains(a) Then
            Me.Add(a)
            MsgBox("Список создан", MsgBoxStyle.Information)

            Return True
        End If
        MsgBox("Список с таким именем уже есть", vbCritical)


        Return True
    End Function
    ''' <summary>
    ''' remove all lists
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ClearListCollection()
        Me.Clear()
    End Sub
    Public Sub ClearList(SampleListName As String)
        Dim _list = (From c In Me Where c.NameOfList = SampleListName Select c).FirstOrDefault
        If _list Is Nothing Then Exit Sub
        _list.Clear()
    End Sub

    Public Function GetNamesCollection(SampleListName As String) As String()
        Dim a = (From c In Me Where c.NameOfList = SampleListName Select c).FirstOrDefault
        If a Is Nothing Then Return New String() {}
        Return a.Select(Function(x) (x.Name)).ToArray
    End Function

    ''' <summary>
    ''' вернет список названий списков
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetNames() As String()

        Return Me.Select(Function(x) (x.NameOfList)).ToArray
    End Function
    ''' <summary>
    ''' можно задать путь для файла, иначе он будет взят из setting
    ''' </summary>
    ''' <param name="FileName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CreateInstance(Optional FileName As String = "") As clsSampleListManager
        If Not FileName = "" Then
            ListFileName = FileName
        Else
            ListFileName = "Lists.bin"
        End If

        Dim _newmanager As New clsSampleListManager

        Dim _source = clsFilesSources.CreateInstance(clsFilesSources.emSources.SystemVolume)

        Dim _stream = clsApplicationTypes.SamplePhotoObject.ReadFileFromContainer("SampleLists", ListFileName, _source)

        If _stream Is Nothing Then
            'файл отсутствует на устройстве
            MsgBox("Файл со списками отсутствует. Будет создан новый файл " & IO.Path.Combine(_source.ContainerPath, ListFileName), vbInformation)
            GoTo createnew
        End If

        Try
            Dim deserializer As New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter
            _stream.Position = 0
            _newmanager = CType(deserializer.Deserialize(_stream, Nothing), clsSampleListManager)
            _stream.Close()
            Return _newmanager
        Catch ex As Exception
            MsgBox(ex.Message)
            'ошибка при чтении файла
            MsgBox("Файл со списками не может быть прочитан. Будет создан новый файл " & IO.Path.Combine(_source.ContainerPath, ListFileName), vbCritical)
            GoTo createnew
        End Try

createnew:

        _newmanager.Save()
        Return _newmanager

    End Function


    Public Sub Save()
        Try
            Dim _stream As New IO.MemoryStream
            Dim serializer As New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter
            serializer.Serialize(_stream, Me)

            Dim _source = clsFilesSources.CreateInstance(clsFilesSources.emSources.SystemVolume)
            _stream.Flush()
            _stream.Position = 0

            Dim _bakup = IO.Path.ChangeExtension(ListFileName, "bak")
            'запишем бекап
            Dim _bkp = clsApplicationTypes.SamplePhotoObject.ReadFileFromContainer("SampleLists", ListFileName, _source)
            If clsApplicationTypes.SamplePhotoObject.WriteFileToContainer("SampleLists", _bakup, _source, _bkp) Then

            End If

            'запишем новый файл
            Dim _result = clsApplicationTypes.SamplePhotoObject.WriteFileToContainer("SampleLists", ListFileName, _source, _stream)
            If _result > 0 Then
                'теперь запишем XML
                _result = clsApplicationTypes.SamplePhotoObject.WriteFileToContainer("SampleLists", IO.Path.ChangeExtension(ListFileName, ".xml"), _source, Me.GetXML)
                If _result > 0 Then
                    MsgBox("Файлы " & ListFileName & " сохранены", MsgBoxStyle.Information)
                Else
                    MsgBox("Файл " & ListFileName & " сохранен без xml файла", MsgBoxStyle.Information)
                End If
            Else
                MsgBox("Не удалось создать файл", vbCritical)
            End If

        Catch ex As Exception

            MsgBox("Не удалось создать файл, проверте путь: " & ListFileName & ChrW(13) & ex.Message)
        End Try
    End Sub
    Private Sub New()

    End Sub


    

End Class
