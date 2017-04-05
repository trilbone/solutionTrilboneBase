<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uc_mailer
    Inherits System.Windows.Forms.UserControl

    'Пользовательский элемент управления (UserControl) переопределяет метод Dispose для очистки списка компонентов.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Является обязательной для конструктора форм Windows Forms
    Private components As System.ComponentModel.IContainer

    'Примечание: следующая процедура является обязательной для конструктора форм Windows Forms
    'Для ее изменения используйте конструктор форм Windows Form.  
    'Не изменяйте ее в редакторе исходного кода.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.btAskClientsFromMS = New System.Windows.Forms.Button()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.btRefreshMailHtml = New System.Windows.Forms.Button()
        Me.gbMailMessage = New System.Windows.Forms.GroupBox()
        Me.rbMailAsHTML = New System.Windows.Forms.RadioButton()
        Me.rbMailAsText = New System.Windows.Forms.RadioButton()
        Me.gbAttachments = New System.Windows.Forms.GroupBox()
        Me.rbAttachmentsAsZip = New System.Windows.Forms.RadioButton()
        Me.rbNoAttachments = New System.Windows.Forms.RadioButton()
        Me.rbAttachmentsAsFiles = New System.Windows.Forms.RadioButton()
        Me.tbPassword = New System.Windows.Forms.TextBox()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.cbSenderMail = New System.Windows.Forms.ComboBox()
        Me.tbSendTo = New System.Windows.Forms.TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.gbTextMail = New System.Windows.Forms.GroupBox()
        Me.btAskSampleInfo = New System.Windows.Forms.Button()
        Me.btInsertPrice = New System.Windows.Forms.Button()
        Me.btInsertDescription = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbNameInMail = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.cbCurrency = New System.Windows.Forms.ComboBox()
        Me.tbPrice = New System.Windows.Forms.TextBox()
        Me.btSendMail = New System.Windows.Forms.Button()
        Me.tbCaption = New System.Windows.Forms.TextBox()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbctlMail = New System.Windows.Forms.TabControl()
        Me.tpMailText = New System.Windows.Forms.TabPage()
        Me.rtbMailText = New System.Windows.Forms.RichTextBox()
        Me.tpMailHTML = New System.Windows.Forms.TabPage()
        Me.BindingSourceClients = New System.Windows.Forms.BindingSource(Me.components)
        Me.rbEnglish = New System.Windows.Forms.RadioButton()
        Me.rbRussian = New System.Windows.Forms.RadioButton()
        Me.btRefreshText = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lbPriceInfo = New System.Windows.Forms.Label()
        Me.rtbCaptionText = New System.Windows.Forms.RichTextBox()
        Me.cbxEnableRegister = New System.Windows.Forms.CheckBox()
        Me.btAskPrice = New System.Windows.Forms.Button()
        Me.lbClients = New System.Windows.Forms.ListBox()
        Me.tbClientFilter = New System.Windows.Forms.TextBox()
        Me.cbxReloadClient = New System.Windows.Forms.CheckBox()
        Me.btSaveCustomer = New System.Windows.Forms.Button()
        Me.btCreateMail = New System.Windows.Forms.Button()
        Me.wbMailHTML = New System.Windows.Forms.WebBrowser()
        Me.UserControlQalityMail = New Service.UserControlQality()
        Me.btEraseHeader = New System.Windows.Forms.Button()
        Me.gbMailMessage.SuspendLayout()
        Me.gbAttachments.SuspendLayout()
        Me.gbTextMail.SuspendLayout()
        Me.tbctlMail.SuspendLayout()
        Me.tpMailText.SuspendLayout()
        Me.tpMailHTML.SuspendLayout()
        CType(Me.BindingSourceClients, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btAskClientsFromMS
        '
        Me.btAskClientsFromMS.Location = New System.Drawing.Point(539, 5)
        Me.btAskClientsFromMS.Name = "btAskClientsFromMS"
        Me.btAskClientsFromMS.Size = New System.Drawing.Size(75, 23)
        Me.btAskClientsFromMS.TabIndex = 7
        Me.btAskClientsFromMS.Text = "Запрос МС"
        Me.btAskClientsFromMS.UseVisualStyleBackColor = True
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(191, 11)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(43, 13)
        Me.Label30.TabIndex = 6
        Me.Label30.Text = "Клиент"
        '
        'btRefreshMailHtml
        '
        Me.btRefreshMailHtml.Location = New System.Drawing.Point(196, 214)
        Me.btRefreshMailHtml.Name = "btRefreshMailHtml"
        Me.btRefreshMailHtml.Size = New System.Drawing.Size(113, 40)
        Me.btRefreshMailHtml.TabIndex = 35
        Me.btRefreshMailHtml.Text = "обновить HTML"
        Me.btRefreshMailHtml.UseVisualStyleBackColor = True
        '
        'gbMailMessage
        '
        Me.gbMailMessage.Controls.Add(Me.rbMailAsHTML)
        Me.gbMailMessage.Controls.Add(Me.rbMailAsText)
        Me.gbMailMessage.Location = New System.Drawing.Point(14, 206)
        Me.gbMailMessage.Name = "gbMailMessage"
        Me.gbMailMessage.Size = New System.Drawing.Size(161, 49)
        Me.gbMailMessage.TabIndex = 34
        Me.gbMailMessage.TabStop = False
        Me.gbMailMessage.Text = "Тип письма"
        '
        'rbMailAsHTML
        '
        Me.rbMailAsHTML.AutoSize = True
        Me.rbMailAsHTML.Location = New System.Drawing.Point(93, 19)
        Me.rbMailAsHTML.Name = "rbMailAsHTML"
        Me.rbMailAsHTML.Size = New System.Drawing.Size(55, 17)
        Me.rbMailAsHTML.TabIndex = 13
        Me.rbMailAsHTML.Text = "HTML"
        Me.rbMailAsHTML.UseVisualStyleBackColor = True
        '
        'rbMailAsText
        '
        Me.rbMailAsText.AutoSize = True
        Me.rbMailAsText.Checked = True
        Me.rbMailAsText.Location = New System.Drawing.Point(21, 19)
        Me.rbMailAsText.Name = "rbMailAsText"
        Me.rbMailAsText.Size = New System.Drawing.Size(53, 17)
        Me.rbMailAsText.TabIndex = 12
        Me.rbMailAsText.TabStop = True
        Me.rbMailAsText.Text = "текст"
        Me.rbMailAsText.UseVisualStyleBackColor = True
        '
        'gbAttachments
        '
        Me.gbAttachments.Controls.Add(Me.rbAttachmentsAsZip)
        Me.gbAttachments.Controls.Add(Me.rbNoAttachments)
        Me.gbAttachments.Controls.Add(Me.rbAttachmentsAsFiles)
        Me.gbAttachments.Location = New System.Drawing.Point(14, 154)
        Me.gbAttachments.Name = "gbAttachments"
        Me.gbAttachments.Size = New System.Drawing.Size(330, 49)
        Me.gbAttachments.TabIndex = 33
        Me.gbAttachments.TabStop = False
        Me.gbAttachments.Text = "вложить фото"
        '
        'rbAttachmentsAsZip
        '
        Me.rbAttachmentsAsZip.AutoSize = True
        Me.rbAttachmentsAsZip.Location = New System.Drawing.Point(243, 19)
        Me.rbAttachmentsAsZip.Name = "rbAttachmentsAsZip"
        Me.rbAttachmentsAsZip.Size = New System.Drawing.Size(71, 17)
        Me.rbAttachmentsAsZip.TabIndex = 13
        Me.rbAttachmentsAsZip.Text = "Архив zip"
        Me.rbAttachmentsAsZip.UseVisualStyleBackColor = True
        '
        'rbNoAttachments
        '
        Me.rbNoAttachments.AutoSize = True
        Me.rbNoAttachments.Location = New System.Drawing.Point(21, 19)
        Me.rbNoAttachments.Name = "rbNoAttachments"
        Me.rbNoAttachments.Size = New System.Drawing.Size(103, 17)
        Me.rbNoAttachments.TabIndex = 14
        Me.rbNoAttachments.TabStop = True
        Me.rbNoAttachments.Text = "Не вкладывать"
        Me.rbNoAttachments.UseVisualStyleBackColor = True
        '
        'rbAttachmentsAsFiles
        '
        Me.rbAttachmentsAsFiles.AutoSize = True
        Me.rbAttachmentsAsFiles.Checked = True
        Me.rbAttachmentsAsFiles.Location = New System.Drawing.Point(129, 19)
        Me.rbAttachmentsAsFiles.Name = "rbAttachmentsAsFiles"
        Me.rbAttachmentsAsFiles.Size = New System.Drawing.Size(108, 17)
        Me.rbAttachmentsAsFiles.TabIndex = 12
        Me.rbAttachmentsAsFiles.TabStop = True
        Me.rbAttachmentsAsFiles.Text = "отдельные фото"
        Me.rbAttachmentsAsFiles.UseVisualStyleBackColor = True
        '
        'tbPassword
        '
        Me.tbPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.tbPassword.Location = New System.Drawing.Point(196, 97)
        Me.tbPassword.Name = "tbPassword"
        Me.tbPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.tbPassword.Size = New System.Drawing.Size(144, 22)
        Me.tbPassword.TabIndex = 32
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label38.Location = New System.Drawing.Point(135, 98)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(55, 16)
        Me.Label38.TabIndex = 31
        Me.Label38.Text = "пароль"
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label37.Location = New System.Drawing.Point(15, 72)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(129, 16)
        Me.Label37.TabIndex = 30
        Me.Label37.Text = "отправить с ящика"
        '
        'cbSenderMail
        '
        Me.cbSenderMail.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.cbSenderMail.FormattingEnabled = True
        Me.cbSenderMail.Location = New System.Drawing.Point(150, 68)
        Me.cbSenderMail.Name = "cbSenderMail"
        Me.cbSenderMail.Size = New System.Drawing.Size(190, 24)
        Me.cbSenderMail.TabIndex = 29
        '
        'tbSendTo
        '
        Me.tbSendTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.tbSendTo.Location = New System.Drawing.Point(84, 37)
        Me.tbSendTo.Name = "tbSendTo"
        Me.tbSendTo.Size = New System.Drawing.Size(256, 26)
        Me.tbSendTo.TabIndex = 28
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label31.Location = New System.Drawing.Point(29, 41)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(48, 20)
        Me.Label31.TabIndex = 27
        Me.Label31.Text = "кому"
        '
        'gbTextMail
        '
        Me.gbTextMail.Controls.Add(Me.btAskSampleInfo)
        Me.gbTextMail.Controls.Add(Me.btInsertPrice)
        Me.gbTextMail.Controls.Add(Me.btInsertDescription)
        Me.gbTextMail.Location = New System.Drawing.Point(492, 131)
        Me.gbTextMail.Name = "gbTextMail"
        Me.gbTextMail.Size = New System.Drawing.Size(163, 126)
        Me.gbTextMail.TabIndex = 36
        Me.gbTextMail.TabStop = False
        Me.gbTextMail.Text = "Для текстового письма"
        '
        'btAskSampleInfo
        '
        Me.btAskSampleInfo.Location = New System.Drawing.Point(6, 15)
        Me.btAskSampleInfo.Name = "btAskSampleInfo"
        Me.btAskSampleInfo.Size = New System.Drawing.Size(148, 33)
        Me.btAskSampleInfo.TabIndex = 19
        Me.btAskSampleInfo.Text = "Вставить инфо + $ + опис."
        Me.btAskSampleInfo.UseVisualStyleBackColor = True
        '
        'btInsertPrice
        '
        Me.btInsertPrice.Location = New System.Drawing.Point(6, 95)
        Me.btInsertPrice.Name = "btInsertPrice"
        Me.btInsertPrice.Size = New System.Drawing.Size(113, 28)
        Me.btInsertPrice.TabIndex = 20
        Me.btInsertPrice.Text = "Вставить цену"
        Me.btInsertPrice.UseVisualStyleBackColor = True
        '
        'btInsertDescription
        '
        Me.btInsertDescription.Location = New System.Drawing.Point(6, 57)
        Me.btInsertDescription.Name = "btInsertDescription"
        Me.btInsertDescription.Size = New System.Drawing.Size(113, 29)
        Me.btInsertDescription.TabIndex = 24
        Me.btInsertDescription.Text = "Вставить описание"
        Me.btInsertDescription.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label1.Location = New System.Drawing.Point(11, 290)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(106, 16)
        Me.Label1.TabIndex = 45
        Me.Label1.Text = "Приветствие"
        '
        'tbNameInMail
        '
        Me.tbNameInMail.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.tbNameInMail.Location = New System.Drawing.Point(123, 286)
        Me.tbNameInMail.Name = "tbNameInMail"
        Me.tbNameInMail.Size = New System.Drawing.Size(300, 26)
        Me.tbNameInMail.TabIndex = 44
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label27.Location = New System.Drawing.Point(429, 289)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(52, 20)
        Me.Label27.TabIndex = 43
        Me.Label27.Text = "Цена"
        '
        'cbCurrency
        '
        Me.cbCurrency.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.cbCurrency.FormattingEnabled = True
        Me.cbCurrency.Items.AddRange(New Object() {"USD", "EUR", "RUR"})
        Me.cbCurrency.Location = New System.Drawing.Point(579, 286)
        Me.cbCurrency.Name = "cbCurrency"
        Me.cbCurrency.Size = New System.Drawing.Size(66, 28)
        Me.cbCurrency.TabIndex = 42
        '
        'tbPrice
        '
        Me.tbPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.tbPrice.Location = New System.Drawing.Point(487, 287)
        Me.tbPrice.Name = "tbPrice"
        Me.tbPrice.Size = New System.Drawing.Size(83, 26)
        Me.tbPrice.TabIndex = 41
        Me.tbPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btSendMail
        '
        Me.btSendMail.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btSendMail.Location = New System.Drawing.Point(863, 333)
        Me.btSendMail.Name = "btSendMail"
        Me.btSendMail.Size = New System.Drawing.Size(168, 66)
        Me.btSendMail.TabIndex = 40
        Me.btSendMail.Text = "Отправить"
        Me.btSendMail.UseVisualStyleBackColor = True
        '
        'tbCaption
        '
        Me.tbCaption.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.tbCaption.Location = New System.Drawing.Point(56, 262)
        Me.tbCaption.Name = "tbCaption"
        Me.tbCaption.Size = New System.Drawing.Size(599, 20)
        Me.tbCaption.TabIndex = 39
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label39.Location = New System.Drawing.Point(12, 265)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(36, 13)
        Me.Label39.TabIndex = 38
        Me.Label39.Text = "тема"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label2.Location = New System.Drawing.Point(44, 345)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 20)
        Me.Label2.TabIndex = 47
        Me.Label2.Text = "Текст"
        '
        'tbctlMail
        '
        Me.tbctlMail.Controls.Add(Me.tpMailText)
        Me.tbctlMail.Controls.Add(Me.tpMailHTML)
        Me.tbctlMail.Location = New System.Drawing.Point(14, 405)
        Me.tbctlMail.Name = "tbctlMail"
        Me.tbctlMail.SelectedIndex = 0
        Me.tbctlMail.Size = New System.Drawing.Size(1058, 294)
        Me.tbctlMail.TabIndex = 48
        '
        'tpMailText
        '
        Me.tpMailText.Controls.Add(Me.rtbMailText)
        Me.tpMailText.Location = New System.Drawing.Point(4, 22)
        Me.tpMailText.Name = "tpMailText"
        Me.tpMailText.Padding = New System.Windows.Forms.Padding(3)
        Me.tpMailText.Size = New System.Drawing.Size(1050, 268)
        Me.tpMailText.TabIndex = 0
        Me.tpMailText.Text = "Текст"
        Me.tpMailText.UseVisualStyleBackColor = True
        '
        'rtbMailText
        '
        Me.rtbMailText.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rtbMailText.Location = New System.Drawing.Point(3, 3)
        Me.rtbMailText.Name = "rtbMailText"
        Me.rtbMailText.Size = New System.Drawing.Size(1044, 262)
        Me.rtbMailText.TabIndex = 0
        Me.rtbMailText.Text = ""
        '
        'tpMailHTML
        '
        Me.tpMailHTML.Controls.Add(Me.wbMailHTML)
        Me.tpMailHTML.Location = New System.Drawing.Point(4, 22)
        Me.tpMailHTML.Name = "tpMailHTML"
        Me.tpMailHTML.Padding = New System.Windows.Forms.Padding(3)
        Me.tpMailHTML.Size = New System.Drawing.Size(1050, 268)
        Me.tpMailHTML.TabIndex = 1
        Me.tpMailHTML.Text = "HTML"
        Me.tpMailHTML.UseVisualStyleBackColor = True
        '
        'rbEnglish
        '
        Me.rbEnglish.AutoSize = True
        Me.rbEnglish.Checked = True
        Me.rbEnglish.Location = New System.Drawing.Point(127, 10)
        Me.rbEnglish.Margin = New System.Windows.Forms.Padding(2)
        Me.rbEnglish.Name = "rbEnglish"
        Me.rbEnglish.Size = New System.Drawing.Size(59, 17)
        Me.rbEnglish.TabIndex = 49
        Me.rbEnglish.TabStop = True
        Me.rbEnglish.Text = "English"
        Me.rbEnglish.UseVisualStyleBackColor = True
        '
        'rbRussian
        '
        Me.rbRussian.AutoSize = True
        Me.rbRussian.Location = New System.Drawing.Point(204, 10)
        Me.rbRussian.Margin = New System.Windows.Forms.Padding(2)
        Me.rbRussian.Name = "rbRussian"
        Me.rbRussian.Size = New System.Drawing.Size(67, 17)
        Me.rbRussian.TabIndex = 50
        Me.rbRussian.Text = "Русский"
        Me.rbRussian.UseVisualStyleBackColor = True
        '
        'btRefreshText
        '
        Me.btRefreshText.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btRefreshText.Location = New System.Drawing.Point(664, 333)
        Me.btRefreshText.Name = "btRefreshText"
        Me.btRefreshText.Size = New System.Drawing.Size(168, 66)
        Me.btRefreshText.TabIndex = 51
        Me.btRefreshText.Text = "Обновить текст"
        Me.btRefreshText.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbEnglish)
        Me.GroupBox1.Controls.Add(Me.rbRussian)
        Me.GroupBox1.Location = New System.Drawing.Point(17, 124)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Size = New System.Drawing.Size(327, 30)
        Me.GroupBox1.TabIndex = 52
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Язык письма"
        '
        'lbPriceInfo
        '
        Me.lbPriceInfo.AutoSize = True
        Me.lbPriceInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lbPriceInfo.Location = New System.Drawing.Point(660, 293)
        Me.lbPriceInfo.Name = "lbPriceInfo"
        Me.lbPriceInfo.Size = New System.Drawing.Size(170, 20)
        Me.lbPriceInfo.TabIndex = 53
        Me.lbPriceInfo.Text = "-30% = ...   +30%=..."
        '
        'rtbCaptionText
        '
        Me.rtbCaptionText.Location = New System.Drawing.Point(107, 345)
        Me.rtbCaptionText.Name = "rtbCaptionText"
        Me.rtbCaptionText.Size = New System.Drawing.Size(538, 54)
        Me.rtbCaptionText.TabIndex = 46
        Me.rtbCaptionText.Text = ""
        '
        'cbxEnableRegister
        '
        Me.cbxEnableRegister.Checked = True
        Me.cbxEnableRegister.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbxEnableRegister.Location = New System.Drawing.Point(111, 318)
        Me.cbxEnableRegister.Name = "cbxEnableRegister"
        Me.cbxEnableRegister.Size = New System.Drawing.Size(410, 21)
        Me.cbxEnableRegister.TabIndex = 54
        Me.cbxEnableRegister.Text = "Регистрировать при отправке в БД (снять, если регистрация не нужна)"
        Me.cbxEnableRegister.UseVisualStyleBackColor = True
        '
        'btAskPrice
        '
        Me.btAskPrice.Location = New System.Drawing.Point(675, 259)
        Me.btAskPrice.Name = "btAskPrice"
        Me.btAskPrice.Size = New System.Drawing.Size(131, 23)
        Me.btAskPrice.TabIndex = 55
        Me.btAskPrice.Text = "Запрос цены"
        Me.btAskPrice.UseVisualStyleBackColor = True
        '
        'lbClients
        '
        Me.lbClients.FormattingEnabled = True
        Me.lbClients.Location = New System.Drawing.Point(364, 4)
        Me.lbClients.Name = "lbClients"
        Me.lbClients.Size = New System.Drawing.Size(157, 121)
        Me.lbClients.TabIndex = 56
        '
        'tbClientFilter
        '
        Me.tbClientFilter.Location = New System.Drawing.Point(240, 7)
        Me.tbClientFilter.Name = "tbClientFilter"
        Me.tbClientFilter.Size = New System.Drawing.Size(100, 20)
        Me.tbClientFilter.TabIndex = 57
        '
        'cbxReloadClient
        '
        Me.cbxReloadClient.AutoSize = True
        Me.cbxReloadClient.Location = New System.Drawing.Point(539, 34)
        Me.cbxReloadClient.Name = "cbxReloadClient"
        Me.cbxReloadClient.Size = New System.Drawing.Size(90, 17)
        Me.cbxReloadClient.TabIndex = 58
        Me.cbxReloadClient.Text = "запрос в МС"
        Me.cbxReloadClient.UseVisualStyleBackColor = True
        '
        'btSaveCustomer
        '
        Me.btSaveCustomer.Location = New System.Drawing.Point(539, 58)
        Me.btSaveCustomer.Name = "btSaveCustomer"
        Me.btSaveCustomer.Size = New System.Drawing.Size(113, 56)
        Me.btSaveCustomer.TabIndex = 59
        Me.btSaveCustomer.Text = "Изменить email's в МС"
        Me.btSaveCustomer.UseVisualStyleBackColor = True
        '
        'btCreateMail
        '
        Me.btCreateMail.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btCreateMail.Location = New System.Drawing.Point(364, 134)
        Me.btCreateMail.Name = "btCreateMail"
        Me.btCreateMail.Size = New System.Drawing.Size(117, 70)
        Me.btCreateMail.TabIndex = 60
        Me.btCreateMail.Text = "Сформировать письмо"
        Me.btCreateMail.UseVisualStyleBackColor = True
        '
        'wbMailHTML
        '
        Me.wbMailHTML.Dock = System.Windows.Forms.DockStyle.Fill
        Me.wbMailHTML.Location = New System.Drawing.Point(3, 3)
        Me.wbMailHTML.MinimumSize = New System.Drawing.Size(20, 20)
        Me.wbMailHTML.Name = "wbMailHTML"
        Me.wbMailHTML.Size = New System.Drawing.Size(1044, 262)
        Me.wbMailHTML.TabIndex = 0
        '
        'UserControlQalityMail
        '
        Me.UserControlQalityMail.Culture = New System.Globalization.CultureInfo("en-US")
        Me.UserControlQalityMail.Location = New System.Drawing.Point(659, 4)
        Me.UserControlQalityMail.Margin = New System.Windows.Forms.Padding(4)
        Me.UserControlQalityMail.Name = "UserControlQalityMail"
        Me.UserControlQalityMail.QualityText = ""
        Me.UserControlQalityMail.Size = New System.Drawing.Size(406, 253)
        Me.UserControlQalityMail.TabIndex = 37
        Me.UserControlQalityMail.Tag = ""
        '
        'btEraseHeader
        '
        Me.btEraseHeader.Location = New System.Drawing.Point(364, 214)
        Me.btEraseHeader.Name = "btEraseHeader"
        Me.btEraseHeader.Size = New System.Drawing.Size(117, 40)
        Me.btEraseHeader.TabIndex = 61
        Me.btEraseHeader.Text = "удалить текст и приветствие"
        Me.btEraseHeader.UseVisualStyleBackColor = True
        '
        'uc_mailer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btEraseHeader)
        Me.Controls.Add(Me.btCreateMail)
        Me.Controls.Add(Me.btSaveCustomer)
        Me.Controls.Add(Me.cbxReloadClient)
        Me.Controls.Add(Me.tbClientFilter)
        Me.Controls.Add(Me.lbClients)
        Me.Controls.Add(Me.btAskPrice)
        Me.Controls.Add(Me.cbxEnableRegister)
        Me.Controls.Add(Me.lbPriceInfo)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btRefreshText)
        Me.Controls.Add(Me.tbctlMail)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.rtbCaptionText)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tbNameInMail)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.cbCurrency)
        Me.Controls.Add(Me.tbPrice)
        Me.Controls.Add(Me.btSendMail)
        Me.Controls.Add(Me.tbCaption)
        Me.Controls.Add(Me.Label39)
        Me.Controls.Add(Me.UserControlQalityMail)
        Me.Controls.Add(Me.gbTextMail)
        Me.Controls.Add(Me.btRefreshMailHtml)
        Me.Controls.Add(Me.gbMailMessage)
        Me.Controls.Add(Me.gbAttachments)
        Me.Controls.Add(Me.tbPassword)
        Me.Controls.Add(Me.Label38)
        Me.Controls.Add(Me.Label37)
        Me.Controls.Add(Me.cbSenderMail)
        Me.Controls.Add(Me.tbSendTo)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.btAskClientsFromMS)
        Me.Controls.Add(Me.Label30)
        Me.Name = "uc_mailer"
        Me.Size = New System.Drawing.Size(1075, 702)
        Me.gbMailMessage.ResumeLayout(False)
        Me.gbMailMessage.PerformLayout()
        Me.gbAttachments.ResumeLayout(False)
        Me.gbAttachments.PerformLayout()
        Me.gbTextMail.ResumeLayout(False)
        Me.tbctlMail.ResumeLayout(False)
        Me.tpMailText.ResumeLayout(False)
        Me.tpMailHTML.ResumeLayout(False)
        CType(Me.BindingSourceClients, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btAskClientsFromMS As System.Windows.Forms.Button
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents btRefreshMailHtml As System.Windows.Forms.Button
    Friend WithEvents gbMailMessage As System.Windows.Forms.GroupBox
    Friend WithEvents rbMailAsHTML As System.Windows.Forms.RadioButton
    Friend WithEvents rbMailAsText As System.Windows.Forms.RadioButton
    Friend WithEvents gbAttachments As System.Windows.Forms.GroupBox
    Friend WithEvents rbAttachmentsAsZip As System.Windows.Forms.RadioButton
    Friend WithEvents rbNoAttachments As System.Windows.Forms.RadioButton
    Friend WithEvents rbAttachmentsAsFiles As System.Windows.Forms.RadioButton
    Friend WithEvents tbPassword As System.Windows.Forms.TextBox
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents cbSenderMail As System.Windows.Forms.ComboBox
    Friend WithEvents tbSendTo As System.Windows.Forms.TextBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents gbTextMail As System.Windows.Forms.GroupBox
    Friend WithEvents btAskSampleInfo As System.Windows.Forms.Button
    Friend WithEvents btInsertPrice As System.Windows.Forms.Button
    Friend WithEvents btInsertDescription As System.Windows.Forms.Button
    Friend WithEvents UserControlQalityMail As Service.UserControlQality
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tbNameInMail As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents cbCurrency As System.Windows.Forms.ComboBox
    Friend WithEvents tbPrice As System.Windows.Forms.TextBox
    Friend WithEvents btSendMail As System.Windows.Forms.Button
    Friend WithEvents tbCaption As System.Windows.Forms.TextBox
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tbctlMail As System.Windows.Forms.TabControl
    Friend WithEvents tpMailText As System.Windows.Forms.TabPage
    Friend WithEvents rtbMailText As System.Windows.Forms.RichTextBox
    Friend WithEvents tpMailHTML As System.Windows.Forms.TabPage
    Friend WithEvents wbMailHTML As System.Windows.Forms.WebBrowser
    Friend WithEvents BindingSourceClients As System.Windows.Forms.BindingSource
    Friend WithEvents rbEnglish As System.Windows.Forms.RadioButton
    Friend WithEvents rbRussian As System.Windows.Forms.RadioButton
    Friend WithEvents btRefreshText As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lbPriceInfo As System.Windows.Forms.Label
    Friend WithEvents rtbCaptionText As System.Windows.Forms.RichTextBox
    Friend WithEvents cbxEnableRegister As System.Windows.Forms.CheckBox
    Friend WithEvents btAskPrice As System.Windows.Forms.Button
    Friend WithEvents lbClients As System.Windows.Forms.ListBox
    Friend WithEvents tbClientFilter As System.Windows.Forms.TextBox
    Friend WithEvents cbxReloadClient As System.Windows.Forms.CheckBox
    Friend WithEvents btSaveCustomer As System.Windows.Forms.Button
    Friend WithEvents btCreateMail As System.Windows.Forms.Button
    Friend WithEvents btEraseHeader As Windows.Forms.Button
End Class
