Imports Microsoft.WindowsAzure.Storage
Imports Microsoft.WindowsAzure.Storage.Auth
Imports Microsoft.WindowsAzure.Storage.Blob
Imports System.Linq
Imports System.Reflection

Public Class clsAzureConnection
    Inherits clsConnectionBase

    Private oAccount As CloudStorageAccount
    Private oBlobClient As CloudBlobClient
    ''' <summary>
    ''' synhro read file
    ''' </summary>
    ''' <param name="BlobReference"></param>
    ''' <param name="_status"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ReadFile(BlobReference As KeyValuePair(Of String, String), ByRef _status As Integer) As IO.Stream

        ''Retrieve a reference to a container. 
        Dim container As CloudBlobContainer = Me.oBlobClient.GetContainerReference(BlobReference.Key)
        If container Is Nothing Then
            _status = -1
            Debug.Fail("Для чтения запрошен не существующий на сервере контейнер")
            Return Nothing
        End If
        ' Retrieve reference to a blob named "myblob".
        Dim _blockBlob As CloudBlockBlob = container.GetBlockBlobReference(BlobReference.Value)
        If _blockBlob Is Nothing Then
            _status = -1
            Debug.Fail("Для чтения запрошен не существующий на сервере Blob. Контейнер существует.")
            Return Nothing
        End If
        Dim _stream As New IO.MemoryStream
        Try
            _blockBlob.DownloadToStream(_stream)
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
            Return Nothing
        End Try

        '_stream.Flush()

        Return _stream

        '' Create or overwrite the "myblob" blob with contents from a local file.
        'Using fileStream = System.IO.File.OpenRead("D:\Documents and Settings\White\Мои документы\Мои рисунки\IMG_2479.JPG")
        '    _blockBlob.UploadFromStream(fileStream)
        'End Using
        ''D:\Documents and Settings\White\Мои документы\Мои рисунки\IMG_2479.JPG

        'MsgBox("File loaded")

        'Process.Start("http://trilbone.blob.core.windows.net/images/myblob.jpg")


    End Function
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="DestinationSource"></param>
    ''' <param name="AccountName"></param>
    ''' <param name="PublicKey"></param>
    ''' <returns></returns>
    ''' <remarks>ContainerReference - номер образца, BlockBlobReference - ключ контента</remarks>
    Friend Shared Function InitConnection(DestinationSource As clsFilesSources, AccountName As String, PublicKey As String) As clsAzureConnection
        'FFGGSdfxvpmyPH7MsWn/p4AjxeK/nhpzZ50FjSAdpEqeZYll90+vXmLTlMKMYEFly7QNsyytwvsqcn3EdYPlPQ==
        'trilbone

        Dim _tmp As New clsAzureConnection(DestinationSource)
        'connect to azure
        Try
            Dim _access As New StorageCredentials(AccountName, PublicKey)
            _tmp.oAccount = New CloudStorageAccount(_access, False)

            _tmp.oBlobClient = _tmp.oAccount.CreateCloudBlobClient


        Catch ex As Exception
            Debug.Fail("Ошибка подключения к аккаунту AZURE")
            Return Nothing
        End Try
        If _tmp.oBlobClient Is Nothing Then
            Debug.Fail("Ошибка подключения к аккаунту AZURE")
            Return Nothing
        End If
        Return _tmp
    End Function

    Private Sub New(DestinationSource As clsFilesSources)
        MyBase.New(DestinationSource)
    End Sub

    Public Overrides Function CallService(name As String) As Func(Of Object, MethodInfo)
        Return Nothing
    End Function

    Public Overrides Function CheckConnection() As Boolean
        If Me.oBlobClient Is Nothing Then Return False
        Return True
    End Function

    Public Overrides Function ContainsContent(Idcontent As clsIDcontent) As Boolean
        If Me.GetListKeys(Idcontent, {Idcontent.ObjectKey}).Count > 0 Then Return True
        Return False
    End Function

    Public Overrides Function CountContent(Idcontent As clsIDcontent) As Integer
        Return GetListKeys(Idcontent).Count
    End Function

    Public Overrides Function DeleteBlock(Idcontent As clsIDcontent) As Integer
        Dim _tmp = Me.oBlobClient.GetContainerReference(Idcontent.ContainerName)
        If _tmp Is Nothing Then
            Debug.Fail("Для удаления запрошен не существующий на сервере контейнер")
            Return -1
        End If
        If _tmp.DeleteIfExists() Then
            Return 1
        End If
        Return 0
    End Function

    Public Overrides Function DeleteKey(Idcontent As clsIDcontent) As Integer
        Dim _tmp = Me.oBlobClient.GetContainerReference(Idcontent.ContainerName)
        If _tmp Is Nothing Then
            Debug.Fail("Для удаления запрошен не существующий на сервере контейнер")
            Return -1
        End If

        Dim _blb = _tmp.GetBlockBlobReference(Idcontent.ObjectKey)

        If _blb Is Nothing Then
            Debug.Fail("Для удаления запрошен не существующий на сервере Blob. Контейнер существует.")
            Return -1
        End If


        If _blb.DeleteIfExists() Then
            Return 1
        End If

        Return 0
    End Function

    'Private Shared Sub Rename(container As CloudBlobContainer, oldName As String, newName As String)
    '    Dim source = container.GetBlobReferenceFromServer(oldName)
    '    Dim target = container.GetBlockBlobReference(newName)
    '    target.StartCopyFromBlob(source.Uri)
    '    source.Delete()

    '    '        public static class BlobContainerExtensions 
    '    '{
    '    '    public static void Rename(this CloudBlobContainer container, string oldName, string newName)
    '    '    {
    '    '        var source = container.GetBlobReferenceFromServer(oldName);
    '    '        var target = container.GetBlockBlobReference(newName);
    '    '        target.StartCopyFromBlob(source.Uri);
    '    '        source.Delete();
    '    '    }

    '    '    public static async Task RenameAsync(this CloudBlobContainer container, string oldName, string newName)
    '    '    {
    '    '        var source = await container.GetBlobReferenceFromServerAsync(oldName);
    '    '        var target = container.GetBlockBlobReference(newName);
    '    '        await target.StartCopyFromBlobAsync(source.Uri);
    '    '        await source.DeleteAsync();
    '    '    }
    '    '}

    'End Sub


    Public Overrides Function RenameKey(Idcontent As clsIDcontent, newKeyName As String) As Integer
        Dim _old = Me.oBlobClient.GetContainerReference(Idcontent.ContainerName)
        If _old Is Nothing Then
            Debug.Fail("Для удаления запрошен не существующий на сервере контейнер")
            Return -1
        End If



        Dim _oldblb = _old.GetBlockBlobReference(Idcontent.ObjectKey)


        If _oldblb Is Nothing Then
            Debug.Fail("Для удаления запрошен не существующий на сервере Blob. Контейнер существует.")
            Return -1
        End If

        Dim _newblb = _old.GetBlockBlobReference(newKeyName)

        _newblb.StartCopyFromBlob(_oldblb.Uri)

        If _oldblb.DeleteIfExists Then
            Return 1
        End If

        Return 0
    End Function


    Public Overrides Function GetContentURI(Idcontent As clsIDcontent, ByRef _status As Integer) As System.Uri
        If Not Me.ContainsContent(Idcontent) Then
            _status = 0
            Return Nothing
        End If

        Dim _out = (From c In GetListBlobs(Idcontent) Where c.Name = Idcontent.ObjectKey Select c.Uri).ToList
        _status = _out.Count
        If _status = 0 Then
            Debug.Fail("запрос ContainsContent дал положительные результаты, а GetListBlobs не выдал блобов с требуемым ключом. Проверить логику!! ")
            _status = -1
            Return Nothing
        End If

        Return _out.First

    End Function

    Public Overrides Function GetListKeys(Idcontent As clsIDcontent, Optional Filter() As String = Nothing) As System.Collections.Generic.List(Of String)
        Dim _out = From c In GetListBlobs(Idcontent, Filter) Select c.Name
        'сортировка
        Return MyBase.SortKeys(_out.ToList)
    End Function

    Private Function GetListBlobs(Idcontent As clsIDcontent, Optional Filter() As String = Nothing) As List(Of CloudBlockBlob)
        Dim _list As New List(Of String)
        'find a Container
        Dim _tmpContainer As Microsoft.WindowsAzure.Storage.Blob.CloudBlobContainer = Nothing
        Try
            _tmpContainer = Me.oBlobClient.ListContainers(GetBlobReferenceByIdContent(Idcontent).Key, ContainerListingDetails.All).FirstOrDefault
        Catch ex As Exception
            MsgBox(ex.Message)
            Return New List(Of CloudBlockBlob)()
        End Try

        If _tmpContainer Is Nothing Then Return New List(Of CloudBlockBlob)

        'получить полный список блобов в контейнере
        Dim _blobList As IEnumerable(Of IListBlobItem)
        If Filter Is Nothing Then
            _blobList = _tmpContainer.ListBlobs()
        Else
            'с фильтром
            _blobList = (From c In Filter Select _tmpContainer.ListBlobs(c, True)).SelectMany(Function(x) x).ToList
        End If

        'список паттернов
        Dim _patterns = (From c In clsIDcontent.GetExtentionListByContentType(Idcontent.ContentType) Select (c)).ToList

        Dim _out = New List(Of CloudBlockBlob)
        For Each tbb In _blobList
            If TypeOf tbb Is CloudBlockBlob Then
                _out.Add(tbb)
            ElseIf TypeOf tbb Is CloudBlobDirectory Then
                For Each f In CType(tbb, CloudBlobDirectory).ListBlobs

                    '_out.Add(f)
                Next

                '_out.AddRange(CType(tbb, CloudBlobDirectory).ListBlobs.ToList)
            End If
        Next
        'теперь их надо отфильтровать по расширению
        'теперь их надо отфильтровать по расширению
        Dim _result = (From c In _out, c1 In _patterns Where CType(c, CloudBlockBlob).Name.EndsWith(c1, StringComparison.InvariantCultureIgnoreCase) Select c)
        Return _result.Cast(Of CloudBlockBlob).ToList

        'Return New List(Of CloudBlockBlob)
    End Function


    Public Overrides Function GetSampleList(Optional Filter As String = "") As System.Collections.Generic.List(Of clsApplicationTypes.clsSampleNumber)
        'Dim _a1 = New BlobRequestOptions
        'Dim _a2 = New OperationContext

        'Me.oBlobClient.MaximumExecutionTime = System.TimeSpan.FromMinutes(1)

        'Dim _f = (Me.oBlobClient.ListContainers("602", ContainerListingDetails.All)).ToList

        'find a Container

        Dim _tmpContainer As List(Of clsApplicationTypes.clsSampleNumber)
        Try
            If Filter = "" Then

                _tmpContainer = (From c In Me.oBlobClient.ListContainers() Let c1 As CloudBlobContainer = c Select clsApplicationTypes.clsSampleNumber.CreateFromString(c1.Name)).ToList
            Else
                _tmpContainer = (From c In Me.oBlobClient.ListContainers(Filter, ContainerListingDetails.All) Let c1 As CloudBlobContainer = c Select clsApplicationTypes.clsSampleNumber.CreateFromString(c1.Name)).ToList
            End If
        Catch ex As Exception
            Debug.Fail(ex.Message)
            Return New List(Of clsApplicationTypes.clsSampleNumber)
        End Try


        Return _tmpContainer

    End Function

    Public Overrides Function GetSeriesList() As System.Collections.Generic.List(Of String)
        'медленно!! переделать как в fsLocal
        Dim _res = GetSampleList()
        If _res.Count = 0 Then Return New List(Of String)


        Dim _result = From c In GetSampleList() Group By sr = c.Series Into tst = Group, Any() Select sr

        Return _result.ToList
    End Function

    Public Overrides Sub ReadKeyObj(ByVal Idcontent As clsIDcontent, ByRef _status As Integer, Optional ByVal _asynhronCall As Boolean = False, Optional ByRef _asynhResult As IAsyncResult = Nothing, Optional ByVal IgnoreBuffer As Boolean = False)
        '0 проверка буфера
        Dim _result As IO.Stream = Nothing
        If CheckInBuffer(Idcontent, _result) Then
            If _result.CanRead Then
                If Not IgnoreBuffer Then
                    'венуть из буфера
                    _status = 1
                    OnContentReadyForRead(_result, Idcontent)
                    '  Return _result
                End If
            Else
                _result.Flush()
                _result.Close()
                'удалить из буфера
                DeleteFromBuffer(Idcontent)
                'удалить из буфера!!!
            End If
        End If


        ''0.1 проверка существования файла
        'Dim _path = GetKeyPathByIdContent(Idcontent)
        'If _path = "" Then
        '    _status = -1
        '    Return Nothing
        'End If

        Select Case _asynhronCall
            Case True
                ''асинхронный вызов
                ''1 вызов ReadFile  сделать асинхронным
                ''он должен выдать обьект
                'Dim _dg As New ReadContentCall(AddressOf BeginReadFile)
                ''сообщим получателю контент
                'Dim _param As Object = Idcontent
                ''асинхронная установка соединения
                '_asynhResult = _dg.BeginInvoke(_path, Idcontent, AddressOf ReadContentCallBack, _param)
                '_status = -2
                Debug.Fail("асинхронное чтение не реализовано")

                '   Return Nothing

            Case False
                'синхронный вызов
                _result = ReadFile(GetBlobReferenceByIdContent(Idcontent), _status)
                If _result Is Nothing AndAlso _result.Length = 0 Then
                    _status = 0
                    ' Return Nothing
                End If
                'ok
                _status = 1
                'добавить в буфер
                If Idcontent.IsLoppedObject = False Then
                    AddInBuffer(Idcontent.GetID, _result, False)
                End If
                OnContentReadyForRead(_result, Idcontent)
                'Return _result
        End Select
        '  Return Nothing
    End Sub

    ''' <summary>
    ''' вернет ссылку на контейнер (key) и Blob (value) Azure в зависимости от содержания IdContent
    ''' </summary>
    ''' <param name="IdContent"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetBlobReferenceByIdContent(IdContent As clsIDcontent) As KeyValuePair(Of String, String)
        Dim _tmp As New KeyValuePair(Of String, String)(IdContent.ContainerName, IdContent.ObjectKey)
        Return _tmp
    End Function

    Public Overrides Function WriteKeyObj(ByVal Idcontent As clsIDcontent, ByRef data As IO.Stream, Optional ByVal _asynhronCall As Boolean = False, Optional ByRef _asynhResult As IAsyncResult = Nothing) As Integer
        'проверить наличие контейнера, если нет - то создать

        Dim _tmp = Me.oBlobClient.GetContainerReference(Idcontent.ContainerName)

        _tmp.CreateIfNotExists()

        If _tmp Is Nothing Then
            Debug.Fail("Ошибка создания контейнера на сервере")
            Return -1
        End If
        'установим права доступа
        Dim _permission = _tmp.GetPermissions()
        If _permission.PublicAccess = BlobContainerPublicAccessType.Off Then
            _permission = New BlobContainerPermissions
            _permission.PublicAccess = BlobContainerPublicAccessType.Container
            _tmp.SetPermissions(_permission)
        End If
        'проверить существование blob с запрошенным ключем
        Dim _blob = _tmp.GetBlockBlobReference(Idcontent.ObjectKey)
        If _blob.Exists Then
            'удалить blob
            If Not _blob.DeleteIfExists Then
                Debug.Fail("Ошибка удаления существующего blob")
                Return -1
            End If
        End If

        'проверить данные на вшивость
        If data Is Nothing OrElse data.Length = 0 Then
            Return -1
            Debug.Fail("Данные не переданы")
        End If

        'проверка получателя данных
        Dim _result As IO.Stream = Nothing

        If CheckInBuffer(Idcontent, _result) Then
            'поток открыт в буфере
            'If _result.CanRead Or _result.CanWrite Then
            '    _result.Close()
            'End If
            DeleteFromBuffer(Idcontent)
        End If

        ''все ок
        'поместим поток в буфер
        'AddInBuffer(Idcontent.GetID, data)

        Select Case _asynhronCall
            Case True
                ''вызовем запись файла - асинхронно!!
                ''он должен выдать обьект
                'Dim _dg As New WriteContentCall(AddressOf WriteFile)
                ''сообщим получателю контент
                'Dim _param As Object = Idcontent
                ''асинхронная установка соединения
                '_asynhResult = _dg.BeginInvoke(_path, data, AddressOf WriteContentCallBack, _param)
                ''подождем чутка)) 100mc
                'If _asynhResult.AsyncWaitHandle.WaitOne(100) Then
                '    If _asynhResult.IsCompleted Then
                '        'операция завершена. событие уже прошло. необходимо простовернуть результат
                '        'он помещен при вызове WriteContentCallBack во внутр. переменную
                '        Return _oWriteResult
                '    End If
                'End If
                ''обьект еще не готов! вернем статус незавершенной записи
                'Return -2
                Debug.Fail("асинхронная запись нереализована")
                Return -1
            Case False
                'вызовем запись файла - синхронно!!

                Dim _result1 = Me.WriteFile(GetBlobReferenceByIdContent(Idcontent), data)
                OnContentWrited(_result1)
                Return _result1
        End Select

        Return -1
    End Function
    ''' <summary>
    ''' записывает файл на устройство. 0 - не записан; -1 - ошибка; 1 - записан
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function WriteFile(BlobReference As KeyValuePair(Of String, String), ByRef data As IO.Stream) As Integer
        Dim _container = Me.oBlobClient.GetContainerReference(BlobReference.Key)
        If _container Is Nothing Then
            Debug.Fail("Для записи запрошен не существующий на сервере контейнер")
            Return -1
        End If

        Dim _blb = _container.GetBlockBlobReference(BlobReference.Value)

        If _blb Is Nothing Then
            Debug.Fail("Для записи запрошен не существующий на сервере Blob. Контейнер существует.")
            Return -1
        End If

        _blb.UploadFromStream(data)

        If CheckInBuffer(data) Then
            DeleteFromBuffer(data)
        End If
        'data.Close()
        Return 1

    End Function


    Public Overrides Function ToString() As String
        Return "Azure " & oAccount.Credentials.AccountName
    End Function



End Class
