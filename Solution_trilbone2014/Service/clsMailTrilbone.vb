Imports System.Net
Imports System.Net.Mail
Imports System.Diagnostics
Imports Ionic.Zip
Imports Ionic.Zlib

'Использование класса (пример)
'Private WithEvents oMailHelper As clsEmailBase

'Public Sub New()

'    ' Этот вызов является обязательным для конструктора.
'    InitializeComponent()

'    ' Добавьте все инициализирующие действия после вызова InitializeComponent().
'    oMailHelper = clsEmailBase.CreateInstance(clsEmailBase.emServers.Gmail, "fossilcollecting@gmail.com", "illaenus2009")
'End Sub
'Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
'    Dim _attach = "Z:\IMG_4360.JPG"
'    If oMailHelper.SendMailAsync(Me.tbToMail.Text, Me.tbSubject.Text, Me.rtbMessage.Text, {_attach}, True, , Me.CheckBox1.Checked) Then
'        MsgBox("Письмо поставлено в очередь на отправку")
'    End If
'End Sub

'Private Sub oMailHelper_MailSend(sender As Object, e As clsEmailBase.MailSendedEventArgs) Handles oMailHelper.MailSend
'    MsgBox(e.MailServerMessage)
'End Sub


''' <summary>
''' Управление почтой
''' </summary>
''' <remarks></remarks>
Public Class clsEmailBase
    ''' <summary>
    ''' сервер почты
    ''' </summary>
    ''' <remarks></remarks>
    Private Enum emServers
        Unknown
        Gmail
        MailRu
    End Enum

    Private WithEvents oClient As SmtpClient
    Private oFromSender As MailAddress


    Private Sub New()

    End Sub
    ''' <summary>
    ''' емайл, с которого отправляем
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property FromMail As String
        Get
            Return oFromSender.Address
        End Get
    End Property

    ''' <summary>
    ''' создает клиента почты user-полностью имя пользователя (проверено gmail и mail.ru) = отправитель. Проверить на Nothing!!!
    ''' </summary>
    ''' <param name="server"></param>
    ''' <param name="user"></param>
    ''' <param name="pass"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CreateInstance(user As String, pass As String) As clsEmailBase
        Dim _new As New clsEmailBase
        Dim server As emServers = emServers.Unknown
        'возможно для некоторых сайтов надо так!!! '(user.Split("@")(0), password)
        Dim _credential = New NetworkCredential(user, pass)
        _new.oFromSender = New MailAddress(user)

        Dim _client As New SmtpClient
        Dim _smtpHost As String = ""
        Dim _smtpPort As Integer = 0
        Dim _reqSSL As Boolean

        If user.ToLower.Contains("gmail.com") Then
            server = emServers.Gmail
        End If

        If user.ToLower.Contains("mail.ru") Then
            server = emServers.MailRu
        End If

        If server = emServers.Unknown Then Return Nothing

        Select Case server
            Case emServers.Gmail
                _smtpHost = "smtp.gmail.com"
                'важно - порт, если не работает - проверить изменение на сайте провайдера 465 - не работает, 587, 25
                _smtpPort = 587
                _reqSSL = True
            Case emServers.MailRu
                _smtpHost = "smtp.mail.ru"
                _smtpPort = 2525
                _reqSSL = True
            Case Else
                Throw New ArgumentException
        End Select

        'TODO проверка доступа
        '_credential.Domain = ""
        '_credential.GetCredential("", "")


        With _client
            .Host = _smtpHost
            .Port = _smtpPort
            .EnableSsl = _reqSSL
            .Credentials = _credential
            .DeliveryMethod = SmtpDeliveryMethod.Network

        End With

        _new.oClient = _client

        Return _new
    End Function

    Private oSendedParameter As clsApplicationTypes.clsSendingParameter

    Public Function SendMail(MailTo As String, HeaderCaption As String, MessageBody As String, attachFilesPath As String(), Optional zipcompress As Boolean = False, Optional ZipName As String = "attachment.zip", Optional IsMessageHtml As Boolean = False, Optional SendedParameter As clsApplicationTypes.clsSendingParameter = Nothing) As Boolean
        Me.oSendedParameter = SendedParameter
        Dim _statemessage As String = "сообщение отправлено на " & MailTo
        Dim _mail = New MailMessage
        With _mail
            .From = oFromSender
            .To.Add(New MailAddress(MailTo))
            .Subject = HeaderCaption
            .Body = MessageBody
            .IsBodyHtml = IsMessageHtml

            If (Not attachFilesPath Is Nothing) AndAlso attachFilesPath.Length > 0 Then
                If zipcompress Then
                    ''сжимаем вложения в один файл
                    Dim _out As String
                    Try
                        Dim _tmp = My.Computer.FileSystem.GetTempFileName
                        ZipName = IO.Path.Combine(IO.Path.GetDirectoryName(_tmp), ZipName)
                        _out = ZipFiles(ZipName, attachFilesPath)
                        .Attachments.Add(New Attachment(_out))
                    Catch ex As Exception
                        _statemessage = "сообщение отправлено на " & MailTo & ", но вложения не удалось сжать в массив."
                        For Each t In attachFilesPath
                            .Attachments.Add(New Attachment(t))
                        Next
                    End Try
                Else
                    For Each t In attachFilesPath
                        .Attachments.Add(New Attachment(t))
                    Next
                End If
            End If

        End With

        Try
            oClient.Send(_mail)
            ' oClient.Send(_mail, _statemessage)
            Return True
        Catch ex As Exception

            RaiseEvent MailSend(Me, New clsEmailBase.MailSendedEventArgs("При попытке отправить почту возникла ошибка. Попробуйте еще раз.", False, ex))
            Return False
        End Try


    End Function


    ''' <summary>
    ''' MailTo - адресат, HeaderCaption - заголовок, attachFilesPath - массив путей вложений, zipcompress - если ставим, то будет создан и вложен zip архив из вложений, ZipName - имя файла архива (вкл расширение .zip), IsMessageHtml - если сообщение html. Обработайте событие MailSend для получения результата отправки
    ''' </summary>
    ''' <param name="mailto"></param>
    ''' <param name="HeaderCaption"></param>
    ''' <param name="MessageBody"></param>
    ''' <param name="attachFilesPath"></param>
    ''' <param name="zipcompress"></param>
    ''' <param name="IsMessageHtml"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SendMailAsync(MailTo As String, HeaderCaption As String, MessageBody As String, attachFilesPath As String(), Optional zipcompress As Boolean = False, Optional ZipName As String = "attachment.zip", Optional IsMessageHtml As Boolean = False, Optional SendedParameter As clsApplicationTypes.clsSendingParameter = Nothing) As Boolean

        If oBusy Then
            RaiseEvent MailSend(Me, New clsEmailBase.MailSendedEventArgs("Метод занят отправкой сообщения из очереди. Попробуйте позже.", False, New Exception, Nothing, True))
            Return False
        End If

        Me.oSendedParameter = SendedParameter
        Dim _statemessage As String = "сообщение отправлено на " & MailTo
        Dim _mail = New MailMessage
        With _mail
            .From = oFromSender
            .To.Add(New MailAddress(MailTo))
            '.Subject = "new offer"

            ' Dim _sub = HeaderCaption.Replace("\r", " ").Replace("\n", " ")
            .Subject = HeaderCaption.Replace(Chr(10), " ").Replace(Chr(13), " ")
            .Body = MessageBody
            .IsBodyHtml = IsMessageHtml

            If (Not attachFilesPath Is Nothing) AndAlso attachFilesPath.Length > 0 Then
                'замена %20 пробелом
                For i = 0 To attachFilesPath.Length - 1
                    attachFilesPath(i) = IO.Path.GetFullPath(attachFilesPath(i))
                    ' Dim a = IO.Path.GetFullPath(attachFilesPath(i))
                Next

                If zipcompress Then
                    ''сжимаем вложения в один файл
                    Dim _out As String
                    Try
                        Dim _tmp = My.Computer.FileSystem.GetTempFileName
                        ZipName = IO.Path.Combine(IO.Path.GetDirectoryName(_tmp), ZipName)
                        _out = ZipFiles(ZipName, attachFilesPath)
                        .Attachments.Add(New Attachment(_out))
                    Catch ex As Exception
                        _statemessage = "сообщение отправлено на " & MailTo & ", но вложения не удалось сжать в массив. Письмо отправлено без вложений."
                        'For Each t In attachFilesPath
                        '    .Attachments.Add(New Attachment(t))
                        'Next
                    End Try
                Else
                    For Each t In attachFilesPath
                        .Attachments.Add(New Attachment(t))
                    Next
                End If
            End If

        End With

        Try
            oClient.SendAsync(_mail, _statemessage)
            oBusy = True
            Return True
        Catch ex As Exception
            oBusy = False
            RaiseEvent MailSend(Me, New clsEmailBase.MailSendedEventArgs("При попытке отправить почту возникла ошибка. Попробуйте еще раз.", False, ex))
            Return False
        End Try

    End Function

    Private oBusy As Boolean
    ''' <summary>
    ''' если флаг установлен, то компонент занят отправкой
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property IsBusy As Boolean
        Get
            Return oBusy
        End Get
    End Property


    ''' <summary>
    ''' для добавления папки в новый массив. zipfileName - путь к новому файлу массива, sourceDirectory - путь к добавляемой папке
    ''' </summary>
    ''' <param name="zipfileName"></param>
    ''' <param name="sourceDirectory"></param>
    ''' <remarks></remarks>
    Public Shared Function ZipDirectory(zipfileName As String, sourceDirectory As String, Optional Compression As CompressionLevel = CompressionLevel.BestCompression) As String
        If IO.File.Exists(zipfileName) Then
            IO.File.Delete(zipfileName)
        End If
        Using _zipfile = New ZipFile(zipfileName)
            With _zipfile
                .CompressionLevel = Compression
                Dim _res = .AddDirectory(sourceDirectory, "\" & IO.Path.GetDirectoryName(sourceDirectory))
                .Save()
                Return _zipfile.Name
            End With
        End Using
    End Function


    ''' <summary>
    ''' для добавления отдельных файлов в корень массива. zipfileName - путь к новому файлу массива, sourceFiles - пути источников
    ''' </summary>
    ''' <param name="zipfileName"></param>
    ''' <param name="sourceFiles"></param>
    ''' <param name="Compression"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ZipFiles(zipfileName As String, sourceFiles As String(), Optional Compression As CompressionLevel = CompressionLevel.BestCompression) As String
        If IO.File.Exists(zipfileName) Then
            IO.File.Delete(zipfileName)
        End If

        Using _zipfile = New ZipFile(zipfileName)
            With _zipfile
                .CompressionLevel = Compression
                For Each file In sourceFiles
                    .AddFile(file, "\")
                Next
                .Save()
                Return _zipfile.Name
            End With
        End Using
    End Function
    Private oSendMailMessage As String

    Public ReadOnly Property SendMailMessage As String
        Get
            Return oSendMailMessage
        End Get
    End Property

    Private oSendMailStatus As Boolean
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property SendMailStatus As Boolean
        Get
            Return oSendMailStatus
        End Get
    End Property

    Private Sub oClient_SendCompleted(sender As Object, e As ComponentModel.AsyncCompletedEventArgs) Handles oClient.SendCompleted
        oBusy = False
        Dim _token As String = e.UserState
        If e.Cancelled Then
            oSendMailMessage = "Отправка отменена"
            oSendMailStatus = False
            RaiseEvent MailSend(Me, New MailSendedEventArgs(oSendMailMessage, oSendMailStatus, e.Error))
            Return
        End If

        If Not e.Error Is Nothing Then
            oSendMailMessage = "Ошибка при отправке сообщения: " & e.Error.Message
            oSendMailStatus = False
            RaiseEvent MailSend(Me, New MailSendedEventArgs(oSendMailMessage, oSendMailStatus, e.Error))
            Return
        End If

        oSendMailMessage = _token
        oSendMailStatus = True
        RaiseEvent MailSend(Me, New MailSendedEventArgs(oSendMailMessage, oSendMailStatus, e.Error, Me.oSendedParameter))
    End Sub

    Public Event MailSend(sender As Object, e As MailSendedEventArgs)

    Public Class MailSendedEventArgs
        Inherits EventArgs
        Public Property MailServerMessage As String
        Public Property MailSendedStatus As Boolean
        Public Property exception As Exception
        Public Property SendedParameter As clsApplicationTypes.clsSendingParameter
        Public Property IsBusy As Boolean
        Public Sub New(servermsg As String, mailstate As Boolean, ex As Exception, Optional SendedParameter As clsApplicationTypes.clsSendingParameter = Nothing, Optional IsBusy As Boolean = False)
            Me.MailSendedStatus = mailstate
            Me.MailServerMessage = servermsg
            Me.exception = ex
            Me.SendedParameter = SendedParameter
            Me.IsBusy = IsBusy
        End Sub
    End Class

End Class
