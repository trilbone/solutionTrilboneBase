Imports System.Xml.Linq
Imports Service.clsApplicationTypes
Imports System.Linq
Imports System.Windows.Forms

Public Class uc_mailer
#Region "определения и закрытые свойства"
    ''' <summary>
    ''' хранит текущее описание из построителя качества
    ''' </summary>
    ''' <remarks></remarks>
    Private oCurrentQualityDescr As String
    Private oSplashscreen As Windows.Forms.Form
    Private oSampleNumber As clsApplicationTypes.clsSampleNumber
    Private oCurrentImagesPath As List(Of String)
    Private oCurrentHTML As String

   

    Dim oSendedParametrs As clsSendingParameter

    Public Event CultureChanged(sender As Object, e As CultureChangedEventArgs)

    Dim oCurrentCulture As Globalization.CultureInfo = clsApplicationTypes.EnglishCulture


    Private Property Culture As Globalization.CultureInfo
        Get

            Return oCurrentCulture
        End Get
        Set(value As Globalization.CultureInfo)
            If value.Name.Equals(oCurrentCulture.Name) Then Return
            Dim _oldCulture = oCurrentCulture
            oCurrentCulture = value
            'изменения языка
            Select Case MsgBox("Изменить язык письма? Тексты заголовков будут сгенерированы заново.", vbYesNo)
                Case MsgBoxResult.Yes
                    'изменения языка
                    CreateCultureTexts()
                    Me.UserControlQalityMail.Culture = oCurrentCulture
                    oCurrentQualityDescr = Me.UserControlQalityMail.QualityText

                    RaiseEvent CultureChanged(Me, New CultureChangedEventArgs(oCurrentCulture))
                Case MsgBoxResult.No
                    oCurrentCulture = _oldCulture
                    Select Case oCurrentCulture.Name
                        Case clsApplicationTypes.EnglishCulture.Name
                            Me.rbEnglish.Checked = True
                        Case RussianCulture.Name
                            Me.rbRussian.Checked = True
                    End Select
                    Return
            End Select
        End Set
    End Property

#End Region

#Region "Конструкторы, инициализация"


    Public Sub New()
        ' Этот вызов является обязательным для конструктора.
        InitializeComponent()
        ' Добавьте все инициализирующие действия после вызова InitializeComponent().
        oSplashscreen = clsApplicationTypes.SplashScreen
        Me.cbSenderMail.Items.AddRange(clsApplicationTypes.SendersMailList)
    End Sub
   

    ''' <summary>
    ''' инициализация ЭУ
    ''' </summary>
    ''' <param name="SampleNumber"></param>
    ''' <param name="CurrentHTML"></param>
    ''' <param name="CurrentImagesPath"></param>
    ''' <remarks></remarks>
    Public Sub init(SampleNumber As clsApplicationTypes.clsSampleNumber, Optional HTML As String = "", Optional CurrentImagesPath As List(Of String) = Nothing)
        oSampleNumber = SampleNumber
        '------
        If CurrentImagesPath Is Nothing OrElse CurrentImagesPath.Count = 0 Then
            Me.PicturePaths = clsApplicationTypes.SamplePhotoObject.GetImagesURI(oSampleNumber, clsFilesSources.Arhive).Select(Function(x) x.AbsolutePath).ToList
        Else
            Me.PicturePaths = CurrentImagesPath
        End If
        '-------
        If String.IsNullOrEmpty(HTML) Then
            Me.CurrentHTML = <p>HTML отсутствует</p>.ToString()
        Else
            Me.CurrentHTML = HTML
        End If
        '------------
    End Sub
#End Region

#Region "открытые методы и свойства"

    ''' <summary>
    ''' принудительно установит цену
    ''' </summary>
    ''' <param name="Price"></param>
    ''' <param name="Currency"></param>
    ''' <remarks></remarks>
    Public Sub SetPrice(Price As Decimal, Currency As String)
        Me.tbPrice.Text = Price
        Me.cbCurrency.SelectedItem = Currency
    End Sub

    ''' <summary>
    ''' очистка ЭУ
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Clear()
        oSendedParametrs = Nothing
        Me.tbNameInMail.Text = ""
        Me.tbNameInMail.Enabled = False
        Me.rtbCaptionText.Text = ""
        Me.rtbCaptionText.Enabled = False

        Me.tbSendTo.Text = ""
        Me.cbSenderMail.SelectedIndex = -1
        Me.tbPassword.Enabled = False
        Me.tbPassword.Text = ""

        Me.tbCaption.Enabled = False
        Me.tbCaption.Text = ""

        Me.gbAttachments.Enabled = False
        Me.rbNoAttachments.Checked = True

        Me.gbMailMessage.Enabled = False
        Me.rbMailAsText.Checked = True

        Me.btSendMail.Enabled = False

        Me.tbctlMail.Enabled = False
        Me.rtbMailText.Text = ""
        Me.wbMailHTML.DocumentText = ""

        Me.gbTextMail.Enabled = False
        Me.tbPrice.Text = ""
        Me.lbPriceInfo.Text = "-30%=...   +30%=..."
        Me.cbCurrency.SelectedIndex = -1
        Me.UserControlQalityMail.Enabled = False
        Me.UserControlQalityMail.Clear()
        Me.oCurrentImagesPath.Clear()
        Me.oCurrentHTML = ""
        Me.oCurrentQualityDescr = ""
        Me.oSampleNumber = Nothing
    End Sub


    ''' <summary>
    ''' установит HTML
    ''' </summary>
    ''' <param name="Html"></param>
    ''' <remarks></remarks>
    Public Sub SetHTML(Html As String)
        Me.CurrentHTML = Html
    End Sub

    ''' <summary>
    ''' список путей фото для загрузки
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property PicturePaths As List(Of String)
        Get
            Return Me.oCurrentImagesPath
        End Get
        Set(value As List(Of String))
            Me.oCurrentImagesPath = value
        End Set
    End Property
#End Region


#Region "обработка событий ЭУ"
    ''' <summary>
    ''' выбор клиента
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub lbClients_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbClients.SelectedIndexChanged
        ''iMoySkladDataProvider.clsClientInfo
        If lbClients.SelectedItem Is Nothing Then Return
        If TypeOf lbClients.SelectedItem Is String Then
            Me.tbSendTo.Text = lbClients.SelectedValue
        Else
            Me.tbSendTo.Text = lbClients.SelectedValue.ToString
        End If

        Dim _info As iMoySkladDataProvider.clsClientInfo = Me.lbClients.SelectedItem
        If Not String.IsNullOrEmpty(_info.MainSourceEmail) Then
            Dim _item = (From c As clsApplicationTypes.clsMail In Me.cbSenderMail.Items Where c.Mail.ToLower.Equals(_info.MainSourceEmail.ToLower) Select c).FirstOrDefault
            If Not _item Is Nothing Then
                Me.cbSenderMail.SelectedItem = _item
            Else
                Me.cbSenderMail.SelectedIndex = -1
                tbPassword.Text = ""
            End If
        Else
            Me.cbSenderMail.SelectedIndex = -1
            tbPassword.Text = ""
        End If

    End Sub

    ''' <summary>
    ''' изменение email отправления
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cbSenderMail_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbSenderMail.SelectedIndexChanged
        If cbSenderMail.SelectedItem Is Nothing Then Return

        Me.tbPassword.Enabled = True

        '''при наличии доступа установить пароль
        If clsApplicationTypes.GetAccess("Отправка eMail") Then
            tbPassword.Text = cbSenderMail.SelectedItem.Password
        Else

            tbPassword.Text = ""
        End If

        'Me.tbCaption.Enabled = True
        'Me.gbAttachments.Enabled = True
        'Me.gbMailMessage.Enabled = True
        'Me.btSendMail.Enabled = True
        'Me.tbctlMail.Enabled = True
        'Me.gbTextMail.Enabled = True
        'Me.UserControlQalityMail.Enabled = True
        'Me.tbNameInMail.Enabled = True
        'Me.rtbCaptionText.Enabled = True

        ''установить письмо как HTML
        'Me.rbMailAsHTML.Checked = True
        ''установить имя клиента
        'Dim _prefix As String = "Hello, " & lbClients.SelectedItem.FullName & "!"
        'Select Case Me.Culture.Name
        '    Case RussianCulture.Name
        '        _prefix = "Здравствуйте, " & lbClients.SelectedItem.FullName & "!"
        '    Case EnglishCulture.Name
        '        _prefix = "Hello, " & lbClients.SelectedItem.FullName & "!"
        'End Select

        'Me.tbNameInMail.Text = _prefix

        ''языково-зависимые тексты
        'CreateCultureTexts()

    End Sub



    ''' <summary>
    ''' отправка запроса на посыл почты
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btSendMail_Click(sender As Object, e As EventArgs) Handles btSendMail.Click
        'send emal
        Dim _mailserver = Service.clsEmailBase.CreateInstance(Me.cbSenderMail.Text, Me.tbPassword.Text)

        If _mailserver Is Nothing Then
            MsgBox("Проверте отправителя или пароль к ящику!", vbCritical)
            Return
        End If

        'привязка обработчика
        AddHandler _mailserver.MailSend, AddressOf mailSended

        'картинки
        Dim _attachAsZip As Boolean = False
        Dim _noAttachments As Boolean = False
        Dim _attachments As String() = Nothing
        If rbNoAttachments.Checked = False Then
            If Me.PicturePaths Is Nothing OrElse Me.PicturePaths.Count = 0 Then
                MsgBox("Не передано фоток для вложения! Письмо будет без вложений!", vbInformation)
                _noAttachments = True
            Else
                If Me.rbAttachmentsAsFiles.Checked Then
                    _attachAsZip = False
                End If

                If Me.rbAttachmentsAsZip.Checked Then
                    _attachAsZip = True
                End If
                If Not PicturePaths Is Nothing Then
                    _attachments = PicturePaths.ToArray
                Else
                    MsgBox("Не удалось добавить пути к файлам вложений. Письмо будет без вложений!", vbCritical)
                    _noAttachments = True
                End If
            End If
        End If

        'сообщение
        Dim _sendasHTML As Boolean = False
        Dim _messagebody As String = ""

        If Me.rbMailAsText.Checked Then
            _messagebody = Me.rtbMailText.Text
            _sendasHTML = False
        End If
        If Me.rbMailAsHTML.Checked Then
            _messagebody = Me.CurrentHTML
            _sendasHTML = True
        End If

        'проверки
        If tbSendTo.Text = "" OrElse (Not tbSendTo.Text.Contains("@")) Then
            MsgBox("Введите правильно получателя сообщения!", vbCritical)
            Return
        End If
        If Me.tbCaption.Text = "" Then
            MsgBox("Тема сообщения пуста!", vbCritical)
            Return
        End If
        If _messagebody = "" Then
            MsgBox("Текст сообщения пуст!", vbCritical)
            Return
        End If

        Select Case MsgBox("Отправить письмо?", vbYesNo)
            Case MsgBoxResult.No
                Return
        End Select

        'проверка клиента
        Dim _client As iMoySkladDataProvider.clsClientInfo
        If Me.lbClients.SelectedItem Is Nothing Then
            'клиент не выбран (ручной ввод адреса)
            'проверка в МС по емайлу
            Dim _res = (From c In oFullClientList Where c.Email.ToLower.Equals(Me.tbSendTo.Text) Select c).ToList
            If _res.Count = 0 Then
                'клиента нет в МС
                Dim _clientName As String = InputBox("Имя получателя емайл", "новый клиент", Me.tbSendTo.Text.Split("@").First)
                _client = New iMoySkladDataProvider.clsClientInfo With {.FullName = _clientName, .Email = Me.tbSendTo.Text}
                Select Case MsgBox("Сохранить нового клиента в МС?", vbYesNo, "Вопрос")
                    Case vbYes
                        'сохранить клиента
                        Dim _mc = clsApplicationTypes.MoySklad(False)
                        Dim _mf As clsApplicationTypes.clsMail = cbSenderMail.SelectedItem
                        _client.MainSourceEmail = _mf.Mail
                        If _mc.SaveCustomer(_client) Is Nothing Then
                            MsgBox("Не удалось сохранить нового клиента", vbCritical)
                        Else
                            MsgBox("Новый клиент добавлен в МС", vbInformation)
                        End If
                End Select
            Else
                'клиент найден в списке из МС
                _client = _res.First
            End If
        Else
            'клиент выбран в списке
            _client = Me.lbClients.SelectedItem
            'проверка ручной корректировки емайла
            If Not CType(Me.lbClients.SelectedItem, iMoySkladDataProvider.clsClientInfo).Email.ToLower.Equals(Me.tbSendTo.Text.ToLower) Then
                'емайл изменен в поле емайла получателя
                Select Case MsgBox("Обновить email клиента в МС?", vbYesNo, "Вопрос")
                    Case vbYes
                        Dim _mc = clsApplicationTypes.MoySklad(False)
                        Dim _mf As clsApplicationTypes.clsMail = cbSenderMail.SelectedItem
                        _client.MainSourceEmail = _mf.Mail
                        _client.Email = Me.tbSendTo.Text
                        If _mc.SaveCustomer(_client) Is Nothing Then
                            MsgBox("Не удалось обновить данные клиента", vbCritical)
                        Else
                            MsgBox("Данные клиента обновлены в МС", vbInformation)
                        End If
                End Select
            End If
        End If

        'отправка письма
        oSendedParametrs = New clsSendingParameter With {.SendFrom = Me.cbSenderMail.Text, .Client = _client, .Caption = Me.tbCaption.Text, .QualityText = UserControlQalityMail.QualityText, .SendTo = Me.tbSendTo.Text, .Currency = IIf(Me.cbCurrency.SelectedItem Is Nothing, "", Me.cbCurrency.SelectedItem), .Price = clsApplicationTypes.ReplaceDecimalSplitter(Me.tbPrice)}

        If _mailserver.SendMailAsync(Me.tbSendTo.Text, Me.tbCaption.Text, _messagebody, _attachments, _attachAsZip, ((Me.oSampleNumber).ShotCode & ".zip"), _sendasHTML) Then
            MsgBox("Сообщение поставлено в очередь на отправку", vbInformation)
            'резервация вызывается из обработчика факта отправки сообщения
        End If


    End Sub

    Private Sub rbMailAsText_CheckedChanged(sender As Object, e As EventArgs) Handles rbMailAsText.CheckedChanged
        If rbMailAsText.Checked Then
            'выбран как текст
            Me.tbctlMail.SelectedTab = Me.tpMailText
            Me.gbTextMail.Enabled = True
        End If
    End Sub
    Private Sub rbMailAsHTML_CheckedChanged(sender As Object, e As EventArgs) Handles rbMailAsHTML.CheckedChanged
        If rbMailAsHTML.Checked Then
            'выбран как HTML
            Me.tbctlMail.SelectedTab = Me.tpMailHTML
            Me.wbMailHTML.DocumentText = Me.CurrentHTML
            Me.gbTextMail.Enabled = False
        End If
    End Sub
    Private Sub btAskSampleInfo_Click(sender As Object, e As EventArgs) Handles btAskSampleInfo.Click
        Me.rtbMailText.Text += (Me.oSampleNumber).GetExtendedInfo.DescriptionString & ChrW(13)
        Me.btInsertDescription_Click(Me, EventArgs.Empty)
        Me.btInsertPrice_Click(Me, EventArgs.Empty)
        Select Case Me.Culture.Name
            Case RussianCulture.Name
                Me.rtbMailText.Text += "Фото образца вложены в письмо." & ChrW(13)
                Me.rtbMailText.Text += "С наилучшими пожеланиями," & ChrW(13) & "Евгений"
            Case EnglishCulture.Name
                Me.rtbMailText.Text += "Photos are include into mail." & ChrW(13)
                Me.rtbMailText.Text += "Best Regards" & ChrW(13) & "Evgeny"
        End Select

    End Sub

    ''' <summary>
    ''' вставка цены
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btInsertPrice_Click(sender As Object, e As EventArgs) Handles btInsertPrice.Click
        Dim _prefix As String = "Special price for you:  "
        Select Case Me.Culture.Name
            Case RussianCulture.Name
                _prefix = "Специальная цена для вас:  "
            Case EnglishCulture.Name
                _prefix = "Special price for you:  "
        End Select
        Select Case rbMailAsText.Checked
            Case True
                'вставка в текст письма
                Me.rtbMailText.Text += _prefix & Me.tbPrice.Text & " " & Me.cbCurrency.Text & ChrW(13)
        End Select
    End Sub
    ''' <summary>
    ''' вставка описания
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btInsertDescription_Click(sender As Object, e As EventArgs) Handles btInsertDescription.Click
        Dim _prefix As String = "About specimen:  "
        Select Case Me.Culture.Name
            Case RussianCulture.Name
                _prefix = "Об образце:  "
            Case EnglishCulture.Name
                _prefix = "About specimen:  "
        End Select
        Select Case rbMailAsText.Checked
            Case True
                'вставка в текст письма
                Me.rtbMailText.Text += ChrW(13) & _prefix & Me.oCurrentQualityDescr
        End Select
    End Sub
    Private Sub btRefreshMailHtml_Click(sender As Object, e As EventArgs) Handles btRefreshMailHtml.Click
        Me.wbMailHTML.DocumentText = Me.CurrentHTML
    End Sub

  

    ''' <summary>
    ''' загрузка списка клиентов
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btAskClientsFromMS_Click(sender As Object, e As EventArgs) Handles btAskClientsFromMS.Click
        'выполняем вызов из сервиса
        ' dim _param as object={[parameters_list]}
        Dim _data As Dictionary(Of String, String) = Nothing
        Dim _message As String = ""
        'если делегата нет, то сервис недоступен
        If Not Global.Service.clsApplicationTypes.DelegatStoreGetClientsFromMS Is Nothing Then
            'сервис зарегестрирован - вызываем 
            Dim _result As iMoySkladDataProvider.clsClientInfo() = clsApplicationTypes.MoySklad(False).GetClients
            If Not _result Is Nothing Then
                oFullClientList = _result.ToList
                Me.BindingSourceClients.DataSource = oFullClientList
                Me.BindingSourceClients.Sort = "FullName"
                With Me.lbClients
                    ''''iMoySkladDataProvider.clsClientInfo
                    .DataSource = Me.BindingSourceClients
                    .DisplayMember = "FullName"
                    .ValueMember = "Email"
                    '.AutoCompleteMode = AutoCompleteMode.SuggestAppend
                    '.AutoCompleteSource = AutoCompleteSource.ListItems
                End With
                Me.cbxReloadClient.Checked = False
            Else
                MsgBox("Не могу загрузить клиентов. Попробуй еще раз.", vbCritical)
            End If
        Else
            MsgBox("Не могу загрузить клиентов. Ошибка сервиса. Попробуй еще раз.", vbCritical)
        End If
    End Sub

    Private oFullClientList As New List(Of iMoySkladDataProvider.clsClientInfo)

    ''' <summary>
    ''' фильтр клиентов
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tbClientFilter_TextChanged(sender As Object, e As EventArgs) Handles tbClientFilter.TextChanged
        If String.IsNullOrWhiteSpace(Me.tbClientFilter.Text) Then
            Me.BindingSourceClients.DataSource = oFullClientList
            Me.lbClients.SelectedIndex = -1
        Else
            Dim _fl = (From c In oFullClientList Where c.Equals(tbClientFilter.Text) = True Select c).ToArray
            Me.BindingSourceClients.DataSource = _fl
        End If
    End Sub


    Private Sub rbEnglish_CheckedChanged(sender As Object, e As EventArgs) Handles rbEnglish.CheckedChanged
        If rbEnglish.Checked Then
            Me.Culture = clsApplicationTypes.EnglishCulture
        End If
    End Sub

    Private Sub rbRussian_CheckedChanged(sender As Object, e As EventArgs) Handles rbRussian.CheckedChanged
        If rbRussian.Checked Then
            Me.Culture = clsApplicationTypes.RussianCulture
        End If
    End Sub

    ''' <summary>
    ''' обновит текст письма
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btRefreshText_Click(sender As Object, e As EventArgs) Handles btRefreshText.Click
        InsertHelloToHTML()
        InserPriceToHTML()
        InsertQualityText()
    End Sub

    ''' <summary>
    ''' вставляет описание качества образца
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub UserControlQalityMail_QualityTextChanged(sender As Object, e As UserControlQality.QualityTextChangedEventArgs) Handles UserControlQalityMail.QualityTextChanged
        oCurrentQualityDescr = e.text
    End Sub
#End Region

#Region "Утилиты"
   

    ''' <summary>
    ''' пишет текстовое содержание в основные поля
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CreateCultureTexts()
        Select Case oCurrentCulture.Name
            Case clsApplicationTypes.EnglishCulture.Name
                'сформировать заголовок
                Me.tbCaption.Text = "New offer from Trilbone - " & (Me.oSampleNumber).GetExtendedInfo.SampleName
                'установить прелюдию
                Me.rtbCaptionText.Text = "I got new speciment. Please see."

                'добавить текст письма
                Me.rtbMailText.Text = Me.tbNameInMail.Text & ChrW(13)
                Me.rtbMailText.Text += "Please see our new offer: " & ChrW(13)
            Case clsApplicationTypes.RussianCulture.Name
                'сформировать заголовок
                Me.tbCaption.Text = "Новое предложение от Paleotravel - " & (Me.oSampleNumber).GetExtendedInfo.SampleName
                'установить прелюдию
                Me.rtbCaptionText.Text = "У нас появилась новинка. Пожалуйста, посмотрите."

                'добавить текст письма
                Me.rtbMailText.Text = Me.tbNameInMail.Text & ChrW(13)
                Me.rtbMailText.Text += "Пожалуйста, посмотрите наше предложение: " & ChrW(13)
        End Select
    End Sub

    ''' <summary>
    ''' почта ушла
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub mailSended(sender As Object, e As clsEmailBase.MailSendedEventArgs)
        If e.MailSendedStatus Then
            MsgBox(String.Format("Сообщение успешно отправлено: {0}", e.MailServerMessage), vbInformation)

            If Me.cbxEnableRegister.Checked Then
                'добавить в МойСклад
                'добавить в БД
                ReserveInMoySklad()
                ReserveInDBTrilbone()
            End If

            Clear()
        Else
            MsgBox(String.Format("Сообщение НЕ отправлено: {0}. {1} Убедитесь в правильности пароля от почты (отправления), а также, в случае с Gmail, что при входе в веб-интерфейс Gmail не запрашивает подтверждения и не требует проверок.", e.MailServerMessage, ChrW(13)), vbCritical)
            oSendedParametrs = Nothing
        End If
    End Sub

    Private Sub ReserveInMoySklad()
        ''Пересчет валют!!! Целевая = USD
        'курс выбранной валюты к рублю
        Dim _mailRate = clsApplicationTypes.GetRateByCurrencyCB103(oSendedParametrs.Currency)
        'курс документа резервации
        Dim _ReservedRate = clsApplicationTypes.GetRateByCurrencyCB103("USD")
        Dim _convertprice = Math.Round(oSendedParametrs.Price * _mailRate / _ReservedRate)

        'по запросу выполняем вызов из сервиса
        'если делегата нет, то сервис недоступен
        If Not clsApplicationTypes.DelegatStoreMCinterface Is Nothing Then
            'сервис зарегестрирован - вызываем
            'надо добавить, если на требуемом устройстве нет фото, то скопировать из архива
            'надо добавить выбор шаблона для каталога
            If oSplashscreen.Visible = False Then
                oSplashscreen.Show()
                Application.DoEvents()
            End If
            Dim _resultMC = clsApplicationTypes.MoySklad(True)

            oSplashscreen.Hide()
            Application.DoEvents()

            If _resultMC Is Nothing Then
                Return
            End If

            Dim _CurrentAgent = clsApplicationTypes.AuctionAgent.AGENT.Where(Function(x) x.name = "email").FirstOrDefault

            If _CurrentAgent Is Nothing Then
                MsgBox("Не удалось загрузить агента email. Резервация в МС отменена", vbCritical)
                Return
            End If

            '''убедись, то заказ существует!!!!
            Dim _auctUUID = _CurrentAgent.GetAgentID("moysklad", "ReservCustomerOrderUUID")

            If Not _auctUUID = "" Then
                If _resultMC.SetSampleToAction(oSampleNumber, _auctUUID, _convertprice, True) Then
                    MsgBox("Образец зарезервирован в соответствующем заказе МС", MsgBoxStyle.Information)
                End If
            Else
                MsgBox("Образец не зарезервирован в соответствующем заказе, ошибка при чтении параметра из файла агента.", MsgBoxStyle.Critical)
            End If
        Else
            MsgBox("Сервис MC недоступен", vbCritical)
        End If
    End Sub

    Private Sub ReserveInDBTrilbone()
        'записать в мою базу
        Dim _sendFrom As String = oSendedParametrs.SendFrom & "/" & clsApplicationTypes.CurrentUser.UserShotName
        Dim _client As Service.iMoySkladDataProvider.clsClientInfo = oSendedParametrs.Client
        Dim _clientName = ""
        Dim _clientMoySkladCode = ""
        If Not _client Is Nothing Then
            _clientName = _client.FullName
            _clientMoySkladCode = _client.MSCode
        End If
        Try
            'записвывает сумму и стоимость отправки письма))
            Dim _result = clsApplicationTypes.SampleDataObject.RegisterSampleToMailOffer(SampleNumber:=oSampleNumber, SendFromMail:=_sendFrom, clientEmail:=oSendedParametrs.SendTo, clientName:=_clientName, clientMoySkladCode:=_clientMoySkladCode, mailtitle:=oSendedParametrs.Caption, itemcondition:=oSendedParametrs.QualityText, itemamount:=oSendedParametrs.Price, InsectionFee:=My.Settings.MailInsectionFee, currency:=oSendedParametrs.Currency)

            If _result Then
                MsgBox("Образец зарезервирован в БД", MsgBoxStyle.Information)
            Else
                MsgBox("Образец не зарезервирован в БД, ошибка при помещении в БД.", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            Dim _msg As String
#If DEBUG Then
            _msg = "Образец не зарезервирован в БД, ошибка при помещении в БД: " & ex.Message

#Else
 _msg = "Образец не зарезервирован в БД, ошибка при помещении в БД."
#End If


            MsgBox(_msg, MsgBoxStyle.Critical)
        End Try

    End Sub


#Region "вставка в HTML"

    Private Property CurrentHTML As String
        Get
            Return oCurrentHTML
        End Get
        Set(value As String)
            oCurrentHTML = value
            Me.wbMailHTML.DocumentText = oCurrentHTML
            'Me.wbMailHTML.Refresh()
        End Set
    End Property

    Private Sub InsertQualityText()
        Dim _prefix As String = "About specimen:  "
        Select Case Me.UserControlQalityMail.Culture.Name
            Case RussianCulture.Name
                _prefix = "Об образце:  "
            Case EnglishCulture.Name
                _prefix = "About specimen:  "
        End Select

        Select Case rbMailAsHTML.Checked
            Case True
                'вставка в HTML
                Dim _xe As XElement = <span style="border: 0px outset rgb(78,63,33); ">
                                          <font class="alt"><%= _prefix %></font><%= oCurrentQualityDescr %><br/></span>



                Dim _xml = XElement.Parse(Me.CurrentHTML)
                Dim _ins = (From c In _xml.Descendants("td") Where (Not c.Attribute("id") Is Nothing) AndAlso (c.Attribute("id").Value = "63") Select c)
                If _ins.Count > 0 Then
                    _ins(0).RemoveNodes()
                    If Not String.IsNullOrEmpty(oCurrentQualityDescr) Then
                        _ins(0).AddFirst(_xe)
                        BeepYES()
                    End If
                    Me.CurrentHTML = _xml.ToString
                End If
        End Select
    End Sub



    ''' <summary>
    ''' вставляет цену в HTML
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub InserPriceToHTML()
        Dim _prefix As String = "Price for you:  "
        Select Case Me.Culture.Name
            Case RussianCulture.Name
                _prefix = "Специальная цена:  "
            Case EnglishCulture.Name
                _prefix = "Special price:  "
        End Select
        Select Case rbMailAsHTML.Checked
            Case True
                'вставка в HTML
                Dim _xe As XElement = <span style="border: 0px outset rgb(78,63,33); "><br/>
                                          <font class="alt"><%= _prefix %></font><%= Me.tbPrice.Text & " " & Me.cbCurrency.Text %>
                                          <br/>
                                      </span>
                Dim _xml = XElement.Parse(Me.CurrentHTML)
                Dim _ins = (From c In _xml.Descendants("td") Where (Not c.Attribute("id") Is Nothing) AndAlso (c.Attribute("id").Value = "64") Select c)
                If _ins.Count > 0 Then
                    _ins(0).RemoveNodes()
                    If (Not Me.tbPrice.Text = "") And (Not clsApplicationTypes.ReplaceDecimalSplitter(Me.tbPrice) = 0) Then
                        _ins(0).AddFirst(_xe)
                        BeepYES()
                    End If
                    Me.CurrentHTML = _xml.ToString
                End If
        End Select
    End Sub

    ''' <summary>
    ''' вставляет имя и прелюдию
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub InsertHelloToHTML()
        Select Case rbMailAsHTML.Checked
            Case True
                'вставка в HTML
                Dim _xe As XElement = <span>
                                          <p style="border: 1px outset rgb(78,63,33);padding:5px;">
                                              <font class="alt" style="font-size:medium; font-weight: normal"><%= tbNameInMail.Text %><br/></font>
                                          </p>
                                      </span>


                For Each t In Me.rtbCaptionText.Lines
                    Dim _tmp As XElement = <font class="alt" style="font-size:small; font-weight: normal;"><%= t %><br/></font>

                    If Not String.IsNullOrEmpty(t) Then
                        _xe...<font>.Last.AddAfterSelf(_tmp)
                    End If
                Next


                Dim _xml = XElement.Parse(Me.CurrentHTML)
                Dim _ins = (From c In _xml.Descendants("p") Where (Not c.Attribute("id") Is Nothing) AndAlso (c.Attribute("id").Value = "66") Select c)
                If _ins.Count > 0 Then
                    _ins(0).RemoveNodes()
                    If Not String.IsNullOrEmpty(tbNameInMail.Text) Or Not String.IsNullOrEmpty(Me.rtbCaptionText.Text) Then
                        _ins(0).AddFirst(_xe)
                        BeepYES()
                    End If
                    Me.CurrentHTML = _xml.ToString
                End If
        End Select
    End Sub


#End Region

#End Region
    ''' <summary>
    ''' рассет дилерской
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tbPrice_TextChanged(sender As Object, e As EventArgs) Handles tbPrice.TextChanged
        Dim _price = clsApplicationTypes.ReplaceDecimalSplitter(Me.tbPrice)
        Me.lbPriceInfo.Text = String.Format("-30% = {0}   +30% = {1}", RoundPrice(_price * 0.7), RoundPrice(_price / 0.7))
    End Sub
    ''' <summary>
    ''' запрос цены в МС
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btAskPrice_Click(sender As Object, e As EventArgs) Handles btAskPrice.Click
        Dim _ex = oSampleNumber.GetExtendedInfo(True)
        Dim _gd = _ex.GoodInfo
        Select Case _gd.Count
            Case 0
                'не учтен в МС
                MsgBox("Образец не учтен в Мой Склад", vbCritical)
                Me.tbPrice.Text = ""
                Me.cbCurrency.SelectedIndex = -1
            Case 1
                If _gd(0).RetailPrice > 0 Then
                    'ok
                    Me.tbPrice.Text = _gd(0).RetailPrice
                    If Not String.IsNullOrEmpty(_gd(0).RetailCurrency) Then
                        Me.cbCurrency.SelectedItem = _gd(0).RetailCurrency
                    Else
                        MsgBox("Валюта розничной цены не указана в Мой Склад", vbCritical)
                        Me.cbCurrency.SelectedIndex = -1
                    End If
                    clsApplicationTypes.BeepYES()
                Else
                    MsgBox("Розничная цена образца отсутствует в Мой Склад, смотри карточку товара.", vbCritical)
                    Me.tbPrice.Text = ""
                    Me.cbCurrency.SelectedIndex = -1
                End If
            Case Else
                'много с этим номером
                MsgBox("С этим номером несколько образцов зарегистрировано в Мой Склад. Исправте ошибку.", vbCritical)
                Me.tbPrice.Text = ""
                Me.cbCurrency.SelectedIndex = -1
        End Select

   
    End Sub

   
    ''' <summary>
    ''' сохранить данные клиента (пока только мейлы)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btSaveCustomer_Click(sender As Object, e As EventArgs) Handles btSaveCustomer.Click
        If lbClients.SelectedItem Is Nothing Then Return

        Dim _mc = clsApplicationTypes.MoySklad(False)

        Dim _cl As Service.iMoySkladDataProvider.clsClientInfo = lbClients.SelectedItem
        'изменить данные
        _cl.Email = Me.tbSendTo.Text
        If Not cbSenderMail.SelectedItem Is Nothing Then
            Dim _mf As clsApplicationTypes.clsMail = cbSenderMail.SelectedItem
            _cl.MainSourceEmail = _mf.Mail
        End If

        If _mc.SaveCustomer(_cl) Is Nothing Then
            MsgBox("Не удалось обновить данные клиента", vbCritical)
        Else
            MsgBox("Данные клиента обновлены в МС", vbInformation)
        End If
    End Sub

    Private Sub btCreateMail_Click(sender As Object, e As EventArgs) Handles btCreateMail.Click
        Me.tbCaption.Enabled = True
        Me.gbAttachments.Enabled = True
        Me.gbMailMessage.Enabled = True
        Me.btSendMail.Enabled = True
        Me.tbctlMail.Enabled = True
        Me.gbTextMail.Enabled = True
        Me.UserControlQalityMail.Enabled = True
        Me.tbNameInMail.Enabled = True
        Me.rtbCaptionText.Enabled = True

        'установить письмо как HTML
        Me.rbMailAsHTML.Checked = True
        'установить имя клиента
        Dim _prefix As String = "Hello, " & lbClients.SelectedItem.FullName & "!"
        Select Case Me.Culture.Name
            Case RussianCulture.Name
                _prefix = "Здравствуйте, " & lbClients.SelectedItem.FullName & "!"
            Case EnglishCulture.Name
                _prefix = "Hello, " & lbClients.SelectedItem.FullName & "!"
        End Select

        Me.tbNameInMail.Text = _prefix

        'языково-зависимые тексты
        CreateCultureTexts()
    End Sub

    Private Sub btEraseHeader_Click(sender As Object, e As EventArgs) Handles btEraseHeader.Click
        Me.tbNameInMail.Text = ""
        Me.rtbCaptionText.Text = ""
    End Sub
End Class
