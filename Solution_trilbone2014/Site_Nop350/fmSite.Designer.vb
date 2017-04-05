<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fmSite
    Inherits System.Windows.Forms.Form

    'Форма переопределяет dispose для очистки списка компонентов.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fmSite))
        Me.tbCtlMain = New System.Windows.Forms.TabControl()
        Me.tpSamples = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbSiteCategories = New System.Windows.Forms.ComboBox()
        Me.btSendMails = New System.Windows.Forms.Button()
        Me.cbSenderMail = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbCurrency = New System.Windows.Forms.ComboBox()
        Me.btGetData = New System.Windows.Forms.Button()
        Me.nop_DataGridView = New System.Windows.Forms.DataGridView()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbWarehouse = New System.Windows.Forms.ComboBox()
        Me.btGetDataFromMC = New System.Windows.Forms.Button()
        Me.btSearchWare = New System.Windows.Forms.Button()
        Me.btLoadFromMC = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tbClientName = New System.Windows.Forms.TextBox()
        Me.btApplyFilter = New System.Windows.Forms.Button()
        Me.btLoadData = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tbNameFilter = New System.Windows.Forms.TextBox()
        Me.cbWithoutClients = New System.Windows.Forms.CheckBox()
        Me.NumericUpDownRole = New System.Windows.Forms.NumericUpDown()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.tbSampleNumberFilter = New System.Windows.Forms.TextBox()
        Me.tbCheckNumber = New System.Windows.Forms.TextBox()
        Me.btCheckNumber = New System.Windows.Forms.Button()
        Me.tbMailCaption = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btCreateCatalog = New System.Windows.Forms.Button()
        Me.cbxInternet = New System.Windows.Forms.CheckBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cbxRussian = New System.Windows.Forms.CheckBox()
        Me.cbxSendCatalogAsMail = New System.Windows.Forms.CheckBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cbDiscount = New System.Windows.Forms.ComboBox()
        Me.NumericUpDownPage = New System.Windows.Forms.NumericUpDown()
        Me.lblPage = New System.Windows.Forms.Label()
        Me.cbMCFolder = New System.Windows.Forms.ComboBox()
        Me.btClearList = New System.Windows.Forms.Button()
        Me.cbxOnlyWithImages = New System.Windows.Forms.CheckBox()
        Me.tpStatus = New System.Windows.Forms.TabPage()
        Me.btShowSampleData = New System.Windows.Forms.Button()
        Me.btSeeLog = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tbShotNumber = New System.Windows.Forms.TextBox()
        Me.UserControlMC1 = New Service.UserControlMC()
        Me.Uc_trilbone_history1 = New Service.Uc_trilbone_history()
        Me.lbLog = New System.Windows.Forms.ListBox()
        Me.tpSearch = New System.Windows.Forms.TabPage()
        Me.tpReadyForSite = New System.Windows.Forms.TabPage()
        Me.tpHelp = New System.Windows.Forms.TabPage()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.btCheckSamples = New System.Windows.Forms.Button()
        Me.tbCtlMain.SuspendLayout()
        Me.tpSamples.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.nop_DataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDownRole, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDownPage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpStatus.SuspendLayout()
        Me.tpHelp.SuspendLayout()
        Me.SuspendLayout()
        '
        'tbCtlMain
        '
        Me.tbCtlMain.Controls.Add(Me.tpSamples)
        Me.tbCtlMain.Controls.Add(Me.tpStatus)
        Me.tbCtlMain.Controls.Add(Me.tpSearch)
        Me.tbCtlMain.Controls.Add(Me.tpReadyForSite)
        Me.tbCtlMain.Controls.Add(Me.tpHelp)
        Me.tbCtlMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbCtlMain.Location = New System.Drawing.Point(0, 0)
        Me.tbCtlMain.Name = "tbCtlMain"
        Me.tbCtlMain.SelectedIndex = 0
        Me.tbCtlMain.Size = New System.Drawing.Size(1370, 712)
        Me.tbCtlMain.TabIndex = 0
        '
        'tpSamples
        '
        Me.tpSamples.Controls.Add(Me.TableLayoutPanel1)
        Me.tpSamples.Location = New System.Drawing.Point(4, 22)
        Me.tpSamples.Name = "tpSamples"
        Me.tpSamples.Padding = New System.Windows.Forms.Padding(3)
        Me.tpSamples.Size = New System.Drawing.Size(1362, 686)
        Me.tpSamples.TabIndex = 0
        Me.tpSamples.Text = "Образцы"
        Me.tpSamples.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 10
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cbSiteCategories, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btSendMails, 7, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cbSenderMail, 7, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.cbCurrency, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.btGetData, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.nop_DataGridView, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.Label6, 2, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.cbWarehouse, 3, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.btGetDataFromMC, 4, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.btSearchWare, 5, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.btLoadFromMC, 6, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Label3, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.tbClientName, 3, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.btApplyFilter, 4, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.btLoadData, 5, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label4, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.tbNameFilter, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cbWithoutClients, 4, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.NumericUpDownRole, 5, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label7, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.tbSampleNumberFilter, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.tbCheckNumber, 8, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.btCheckNumber, 9, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.tbMailCaption, 8, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label8, 8, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btCreateCatalog, 9, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.cbxInternet, 8, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label9, 5, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cbxRussian, 9, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cbxSendCatalogAsMail, 7, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label10, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.cbDiscount, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.NumericUpDownPage, 6, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblPage, 6, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cbMCFolder, 6, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.btClearList, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cbxOnlyWithImages, 7, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.btCheckSamples, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 5
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1356, 680)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(28, 4)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 26)
        Me.Label2.TabIndex = 27
        Me.Label2.Text = "Категория сайта"
        '
        'cbSiteCategories
        '
        Me.cbSiteCategories.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbSiteCategories.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbSiteCategories.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbSiteCategories.FormattingEnabled = True
        Me.cbSiteCategories.Location = New System.Drawing.Point(97, 7)
        Me.cbSiteCategories.Name = "cbSiteCategories"
        Me.cbSiteCategories.Size = New System.Drawing.Size(170, 21)
        Me.cbSiteCategories.TabIndex = 28
        '
        'btSendMails
        '
        Me.btSendMails.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btSendMails.Location = New System.Drawing.Point(948, 41)
        Me.btSendMails.Name = "btSendMails"
        Me.btSendMails.Size = New System.Drawing.Size(170, 23)
        Me.btSendMails.TabIndex = 48
        Me.btSendMails.Text = "Отправить почту"
        Me.btSendMails.UseVisualStyleBackColor = True
        '
        'cbSenderMail
        '
        Me.cbSenderMail.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbSenderMail.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.cbSenderMail.FormattingEnabled = True
        Me.cbSenderMail.Location = New System.Drawing.Point(948, 7)
        Me.cbSenderMail.Name = "cbSenderMail"
        Me.cbSenderMail.Size = New System.Drawing.Size(170, 21)
        Me.cbSenderMail.TabIndex = 49
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(46, 81)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 29
        Me.Label1.Text = "Валюта"
        '
        'cbCurrency
        '
        Me.cbCurrency.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbCurrency.FormattingEnabled = True
        Me.cbCurrency.Items.AddRange(New Object() {"RUR", "USD", "EUR"})
        Me.cbCurrency.Location = New System.Drawing.Point(97, 77)
        Me.cbCurrency.Name = "cbCurrency"
        Me.cbCurrency.Size = New System.Drawing.Size(47, 21)
        Me.cbCurrency.TabIndex = 30
        '
        'btGetData
        '
        Me.btGetData.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btGetData.Location = New System.Drawing.Point(97, 41)
        Me.btGetData.Name = "btGetData"
        Me.btGetData.Size = New System.Drawing.Size(170, 23)
        Me.btGetData.TabIndex = 37
        Me.btGetData.Text = "Получить данные"
        Me.btGetData.UseVisualStyleBackColor = True
        '
        'nop_DataGridView
        '
        Me.nop_DataGridView.AllowUserToAddRows = False
        Me.nop_DataGridView.AllowUserToDeleteRows = False
        Me.nop_DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.TableLayoutPanel1.SetColumnSpan(Me.nop_DataGridView, 10)
        Me.nop_DataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.nop_DataGridView.Location = New System.Drawing.Point(3, 143)
        Me.nop_DataGridView.Name = "nop_DataGridView"
        Me.nop_DataGridView.Size = New System.Drawing.Size(1350, 534)
        Me.nop_DataGridView.TabIndex = 47
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(299, 116)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(62, 13)
        Me.Label6.TabIndex = 32
        Me.Label6.Text = "Мой Склад"
        '
        'cbWarehouse
        '
        Me.cbWarehouse.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbWarehouse.FormattingEnabled = True
        Me.cbWarehouse.Location = New System.Drawing.Point(367, 112)
        Me.cbWarehouse.Name = "cbWarehouse"
        Me.cbWarehouse.Size = New System.Drawing.Size(170, 21)
        Me.cbWarehouse.TabIndex = 36
        '
        'btGetDataFromMC
        '
        Me.btGetDataFromMC.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btGetDataFromMC.Location = New System.Drawing.Point(543, 111)
        Me.btGetDataFromMC.Name = "btGetDataFromMC"
        Me.btGetDataFromMC.Size = New System.Drawing.Size(129, 23)
        Me.btGetDataFromMC.TabIndex = 38
        Me.btGetDataFromMC.Text = "Из Мой Склад"
        Me.btGetDataFromMC.UseVisualStyleBackColor = True
        '
        'btSearchWare
        '
        Me.btSearchWare.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btSearchWare.Location = New System.Drawing.Point(678, 111)
        Me.btSearchWare.Name = "btSearchWare"
        Me.btSearchWare.Size = New System.Drawing.Size(129, 23)
        Me.btSearchWare.TabIndex = 40
        Me.btSearchWare.Text = "Не выставлено"
        Me.btSearchWare.UseVisualStyleBackColor = True
        '
        'btLoadFromMC
        '
        Me.btLoadFromMC.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btLoadFromMC.Location = New System.Drawing.Point(813, 111)
        Me.btLoadFromMC.Name = "btLoadFromMC"
        Me.btLoadFromMC.Size = New System.Drawing.Size(129, 23)
        Me.btLoadFromMC.TabIndex = 41
        Me.btLoadFromMC.Text = "Добавить из МС"
        Me.btLoadFromMC.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(273, 81)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 13)
        Me.Label3.TabIndex = 50
        Me.Label3.Text = "Имя клиента"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbClientName
        '
        Me.tbClientName.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbClientName.Location = New System.Drawing.Point(367, 77)
        Me.tbClientName.Name = "tbClientName"
        Me.tbClientName.Size = New System.Drawing.Size(170, 20)
        Me.tbClientName.TabIndex = 51
        '
        'btApplyFilter
        '
        Me.btApplyFilter.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btApplyFilter.Location = New System.Drawing.Point(543, 76)
        Me.btApplyFilter.Name = "btApplyFilter"
        Me.btApplyFilter.Size = New System.Drawing.Size(129, 23)
        Me.btApplyFilter.TabIndex = 53
        Me.btApplyFilter.Text = "Фильтр"
        Me.btApplyFilter.UseVisualStyleBackColor = True
        '
        'btLoadData
        '
        Me.btLoadData.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btLoadData.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btLoadData.Location = New System.Drawing.Point(678, 76)
        Me.btLoadData.Name = "btLoadData"
        Me.btLoadData.Size = New System.Drawing.Size(129, 23)
        Me.btLoadData.TabIndex = 39
        Me.btLoadData.Text = "Загрузить"
        Me.btLoadData.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(306, 39)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 26)
        Me.Label4.TabIndex = 31
        Me.Label4.Text = "Часть названия"
        '
        'tbNameFilter
        '
        Me.tbNameFilter.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbNameFilter.Location = New System.Drawing.Point(367, 42)
        Me.tbNameFilter.Name = "tbNameFilter"
        Me.tbNameFilter.Size = New System.Drawing.Size(170, 20)
        Me.tbNameFilter.TabIndex = 35
        '
        'cbWithoutClients
        '
        Me.cbWithoutClients.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbWithoutClients.AutoSize = True
        Me.cbWithoutClients.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbWithoutClients.Location = New System.Drawing.Point(543, 44)
        Me.cbWithoutClients.Name = "cbWithoutClients"
        Me.cbWithoutClients.Size = New System.Drawing.Size(129, 17)
        Me.cbWithoutClients.TabIndex = 52
        Me.cbWithoutClients.Text = "Нераскиданные"
        Me.cbWithoutClients.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbWithoutClients.UseVisualStyleBackColor = True
        '
        'NumericUpDownRole
        '
        Me.NumericUpDownRole.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.NumericUpDownRole.Location = New System.Drawing.Point(678, 42)
        Me.NumericUpDownRole.Maximum = New Decimal(New Integer() {50, 0, 0, 0})
        Me.NumericUpDownRole.Name = "NumericUpDownRole"
        Me.NumericUpDownRole.Size = New System.Drawing.Size(30, 20)
        Me.NumericUpDownRole.TabIndex = 54
        Me.NumericUpDownRole.Value = New Decimal(New Integer() {2, 0, 0, 0})
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(273, 11)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(88, 13)
        Me.Label7.TabIndex = 57
        Me.Label7.Text = "Номер"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbSampleNumberFilter
        '
        Me.tbSampleNumberFilter.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbSampleNumberFilter.Location = New System.Drawing.Point(367, 7)
        Me.tbSampleNumberFilter.Name = "tbSampleNumberFilter"
        Me.tbSampleNumberFilter.Size = New System.Drawing.Size(170, 20)
        Me.tbSampleNumberFilter.TabIndex = 58
        '
        'tbCheckNumber
        '
        Me.tbCheckNumber.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbCheckNumber.Location = New System.Drawing.Point(1124, 112)
        Me.tbCheckNumber.Name = "tbCheckNumber"
        Me.tbCheckNumber.Size = New System.Drawing.Size(88, 20)
        Me.tbCheckNumber.TabIndex = 43
        '
        'btCheckNumber
        '
        Me.btCheckNumber.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btCheckNumber.Location = New System.Drawing.Point(1218, 111)
        Me.btCheckNumber.Name = "btCheckNumber"
        Me.btCheckNumber.Size = New System.Drawing.Size(135, 23)
        Me.btCheckNumber.TabIndex = 44
        Me.btCheckNumber.Text = "проверить в текущих"
        Me.btCheckNumber.UseVisualStyleBackColor = True
        '
        'tbMailCaption
        '
        Me.tbMailCaption.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.SetColumnSpan(Me.tbMailCaption, 2)
        Me.tbMailCaption.Location = New System.Drawing.Point(1124, 42)
        Me.tbMailCaption.Name = "tbMailCaption"
        Me.tbMailCaption.Size = New System.Drawing.Size(229, 20)
        Me.tbMailCaption.TabIndex = 60
        Me.tbMailCaption.Text = "New offer from Trilbone"
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(1137, 11)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(75, 13)
        Me.Label8.TabIndex = 59
        Me.Label8.Text = "Тема письма"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btCreateCatalog
        '
        Me.btCreateCatalog.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btCreateCatalog.Location = New System.Drawing.Point(1218, 76)
        Me.btCreateCatalog.Name = "btCreateCatalog"
        Me.btCreateCatalog.Size = New System.Drawing.Size(135, 23)
        Me.btCreateCatalog.TabIndex = 45
        Me.btCreateCatalog.Text = "Каталог из таблицы"
        Me.btCreateCatalog.UseVisualStyleBackColor = True
        '
        'cbxInternet
        '
        Me.cbxInternet.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cbxInternet.AutoSize = True
        Me.cbxInternet.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbxInternet.Checked = True
        Me.cbxInternet.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbxInternet.Location = New System.Drawing.Point(1143, 79)
        Me.cbxInternet.Name = "cbxInternet"
        Me.cbxInternet.Size = New System.Drawing.Size(69, 17)
        Me.cbxInternet.TabIndex = 46
        Me.cbxInternet.Text = "Из базы"
        Me.cbxInternet.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbxInternet.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(678, 22)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(77, 13)
        Me.Label9.TabIndex = 61
        Me.Label9.Text = "скрыть ролей"
        '
        'cbxRussian
        '
        Me.cbxRussian.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.cbxRussian.AutoSize = True
        Me.cbxRussian.Location = New System.Drawing.Point(1237, 3)
        Me.cbxRussian.Name = "cbxRussian"
        Me.cbxRussian.Size = New System.Drawing.Size(97, 29)
        Me.cbxRussian.TabIndex = 62
        Me.cbxRussian.Text = "Русский язык"
        Me.cbxRussian.UseVisualStyleBackColor = True
        '
        'cbxSendCatalogAsMail
        '
        Me.cbxSendCatalogAsMail.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbxSendCatalogAsMail.AutoSize = True
        Me.cbxSendCatalogAsMail.Location = New System.Drawing.Point(948, 73)
        Me.cbxSendCatalogAsMail.Name = "cbxSendCatalogAsMail"
        Me.cbxSendCatalogAsMail.Size = New System.Drawing.Size(170, 17)
        Me.cbxSendCatalogAsMail.TabIndex = 63
        Me.cbxSendCatalogAsMail.Text = "Каталог одним письмом"
        Me.cbxSendCatalogAsMail.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(22, 109)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(69, 26)
        Me.Label10.TabIndex = 64
        Me.Label10.Text = "Скидка, наценка(-) %"
        '
        'cbDiscount
        '
        Me.cbDiscount.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbDiscount.FormattingEnabled = True
        Me.cbDiscount.Items.AddRange(New Object() {"0", "5", "10", "15", "20", "25", "30", "35", "40", "45", "50", "-5", "-10", "-15", "-20", "-25", "-30"})
        Me.cbDiscount.Location = New System.Drawing.Point(97, 112)
        Me.cbDiscount.Name = "cbDiscount"
        Me.cbDiscount.Size = New System.Drawing.Size(47, 21)
        Me.cbDiscount.TabIndex = 65
        '
        'NumericUpDownPage
        '
        Me.NumericUpDownPage.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.NumericUpDownPage.Increment = New Decimal(New Integer() {5, 0, 0, 0})
        Me.NumericUpDownPage.Location = New System.Drawing.Point(813, 12)
        Me.NumericUpDownPage.Minimum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.NumericUpDownPage.Name = "NumericUpDownPage"
        Me.NumericUpDownPage.Size = New System.Drawing.Size(45, 20)
        Me.NumericUpDownPage.TabIndex = 56
        Me.NumericUpDownPage.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'lblPage
        '
        Me.lblPage.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPage.AutoSize = True
        Me.lblPage.Location = New System.Drawing.Point(813, 46)
        Me.lblPage.Name = "lblPage"
        Me.lblPage.Size = New System.Drawing.Size(129, 13)
        Me.lblPage.TabIndex = 55
        Me.lblPage.Text = "page"
        '
        'cbMCFolder
        '
        Me.cbMCFolder.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbMCFolder.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbMCFolder.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbMCFolder.FormattingEnabled = True
        Me.cbMCFolder.Location = New System.Drawing.Point(813, 77)
        Me.cbMCFolder.Name = "cbMCFolder"
        Me.cbMCFolder.Size = New System.Drawing.Size(129, 21)
        Me.cbMCFolder.TabIndex = 66
        '
        'btClearList
        '
        Me.btClearList.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btClearList.Location = New System.Drawing.Point(543, 6)
        Me.btClearList.Name = "btClearList"
        Me.btClearList.Size = New System.Drawing.Size(129, 23)
        Me.btClearList.TabIndex = 67
        Me.btClearList.Text = "Очистить список"
        Me.btClearList.UseVisualStyleBackColor = True
        '
        'cbxOnlyWithImages
        '
        Me.cbxOnlyWithImages.AutoSize = True
        Me.cbxOnlyWithImages.Location = New System.Drawing.Point(948, 108)
        Me.cbxOnlyWithImages.Name = "cbxOnlyWithImages"
        Me.cbxOnlyWithImages.Size = New System.Drawing.Size(120, 17)
        Me.cbxOnlyWithImages.TabIndex = 68
        Me.cbxOnlyWithImages.Text = "Только с фотками"
        Me.cbxOnlyWithImages.UseVisualStyleBackColor = True
        '
        'tpStatus
        '
        Me.tpStatus.Controls.Add(Me.btShowSampleData)
        Me.tpStatus.Controls.Add(Me.btSeeLog)
        Me.tpStatus.Controls.Add(Me.Label5)
        Me.tpStatus.Controls.Add(Me.tbShotNumber)
        Me.tpStatus.Controls.Add(Me.UserControlMC1)
        Me.tpStatus.Controls.Add(Me.Uc_trilbone_history1)
        Me.tpStatus.Controls.Add(Me.lbLog)
        Me.tpStatus.Location = New System.Drawing.Point(4, 22)
        Me.tpStatus.Name = "tpStatus"
        Me.tpStatus.Padding = New System.Windows.Forms.Padding(3)
        Me.tpStatus.Size = New System.Drawing.Size(1362, 686)
        Me.tpStatus.TabIndex = 1
        Me.tpStatus.Text = "Инфо"
        Me.tpStatus.UseVisualStyleBackColor = True
        '
        'btShowSampleData
        '
        Me.btShowSampleData.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btShowSampleData.Location = New System.Drawing.Point(683, 323)
        Me.btShowSampleData.Name = "btShowSampleData"
        Me.btShowSampleData.Size = New System.Drawing.Size(226, 85)
        Me.btShowSampleData.TabIndex = 17
        Me.btShowSampleData.Text = "Данные образца"
        Me.btShowSampleData.UseVisualStyleBackColor = True
        '
        'btSeeLog
        '
        Me.btSeeLog.Location = New System.Drawing.Point(174, 6)
        Me.btSeeLog.Name = "btSeeLog"
        Me.btSeeLog.Size = New System.Drawing.Size(147, 23)
        Me.btSeeLog.TabIndex = 14
        Me.btSeeLog.Text = "посмотреть лог"
        Me.btSeeLog.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(18, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(41, 13)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Номер"
        '
        'tbShotNumber
        '
        Me.tbShotNumber.Location = New System.Drawing.Point(76, 6)
        Me.tbShotNumber.Name = "tbShotNumber"
        Me.tbShotNumber.Size = New System.Drawing.Size(82, 20)
        Me.tbShotNumber.TabIndex = 12
        '
        'UserControlMC1
        '
        Me.UserControlMC1.Location = New System.Drawing.Point(683, 9)
        Me.UserControlMC1.Name = "UserControlMC1"
        Me.UserControlMC1.SampleName = ""
        Me.UserControlMC1.SampleNumber = Nothing
        Me.UserControlMC1.SampleWeight = New Decimal(New Integer() {0, 0, 0, 0})
        Me.UserControlMC1.Size = New System.Drawing.Size(450, 260)
        Me.UserControlMC1.TabIndex = 16
        '
        'Uc_trilbone_history1
        '
        Me.Uc_trilbone_history1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Uc_trilbone_history1.Location = New System.Drawing.Point(7, 265)
        Me.Uc_trilbone_history1.Name = "Uc_trilbone_history1"
        Me.Uc_trilbone_history1.Size = New System.Drawing.Size(628, 409)
        Me.Uc_trilbone_history1.TabIndex = 15
        '
        'lbLog
        '
        Me.lbLog.FormattingEnabled = True
        Me.lbLog.Location = New System.Drawing.Point(6, 38)
        Me.lbLog.Name = "lbLog"
        Me.lbLog.Size = New System.Drawing.Size(629, 212)
        Me.lbLog.TabIndex = 0
        '
        'tpSearch
        '
        Me.tpSearch.Location = New System.Drawing.Point(4, 22)
        Me.tpSearch.Name = "tpSearch"
        Me.tpSearch.Padding = New System.Windows.Forms.Padding(3)
        Me.tpSearch.Size = New System.Drawing.Size(1362, 686)
        Me.tpSearch.TabIndex = 2
        Me.tpSearch.Text = "Поиск"
        Me.tpSearch.UseVisualStyleBackColor = True
        '
        'tpReadyForSite
        '
        Me.tpReadyForSite.Location = New System.Drawing.Point(4, 22)
        Me.tpReadyForSite.Name = "tpReadyForSite"
        Me.tpReadyForSite.Padding = New System.Windows.Forms.Padding(3)
        Me.tpReadyForSite.Size = New System.Drawing.Size(1362, 686)
        Me.tpReadyForSite.TabIndex = 3
        Me.tpReadyForSite.Text = "На выставление"
        Me.tpReadyForSite.UseVisualStyleBackColor = True
        '
        'tpHelp
        '
        Me.tpHelp.Controls.Add(Me.RichTextBox1)
        Me.tpHelp.Location = New System.Drawing.Point(4, 22)
        Me.tpHelp.Name = "tpHelp"
        Me.tpHelp.Padding = New System.Windows.Forms.Padding(3)
        Me.tpHelp.Size = New System.Drawing.Size(1362, 686)
        Me.tpHelp.TabIndex = 4
        Me.tpHelp.Text = "Help"
        Me.tpHelp.UseVisualStyleBackColor = True
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Location = New System.Drawing.Point(31, 26)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(988, 235)
        Me.RichTextBox1.TabIndex = 0
        Me.RichTextBox1.Text = resources.GetString("RichTextBox1.Text")
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(61, 4)
        '
        'btCheckSamples
        '
        Me.btCheckSamples.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btCheckSamples.Location = New System.Drawing.Point(3, 38)
        Me.btCheckSamples.Name = "btCheckSamples"
        Me.btCheckSamples.Size = New System.Drawing.Size(88, 29)
        Me.btCheckSamples.TabIndex = 69
        Me.btCheckSamples.Text = "Наличие"
        Me.btCheckSamples.UseVisualStyleBackColor = True
        '
        'fmSite
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1370, 712)
        Me.Controls.Add(Me.tbCtlMain)
        Me.Name = "fmSite"
        Me.Text = "Анализ сайта 1.0"
        Me.tbCtlMain.ResumeLayout(False)
        Me.tpSamples.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.nop_DataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDownRole, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDownPage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpStatus.ResumeLayout(False)
        Me.tpStatus.PerformLayout()
        Me.tpHelp.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tbCtlMain As System.Windows.Forms.TabControl
    Friend WithEvents tpSamples As System.Windows.Forms.TabPage
    Friend WithEvents tpStatus As System.Windows.Forms.TabPage
    Friend WithEvents btSeeLog As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tbShotNumber As System.Windows.Forms.TextBox
    Friend WithEvents lbLog As System.Windows.Forms.ListBox
    Friend WithEvents UserControlMC1 As Service.UserControlMC
    Friend WithEvents Uc_trilbone_history1 As Service.Uc_trilbone_history
    Friend WithEvents tpSearch As System.Windows.Forms.TabPage
    Friend WithEvents UserControlEbaySearch1 As Service.UserControlEbaySearch
    Friend WithEvents btShowSampleData As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents nop_DataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbSiteCategories As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbCurrency As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents tbNameFilter As System.Windows.Forms.TextBox
    Friend WithEvents cbWarehouse As System.Windows.Forms.ComboBox
    Friend WithEvents btGetDataFromMC As System.Windows.Forms.Button
    Friend WithEvents btGetData As System.Windows.Forms.Button
    Friend WithEvents btLoadData As System.Windows.Forms.Button
    Friend WithEvents btSearchWare As System.Windows.Forms.Button
    Friend WithEvents btLoadFromMC As System.Windows.Forms.Button
    Friend WithEvents tbCheckNumber As System.Windows.Forms.TextBox
    Friend WithEvents btCheckNumber As System.Windows.Forms.Button
    Friend WithEvents btCreateCatalog As System.Windows.Forms.Button
    Friend WithEvents cbxInternet As System.Windows.Forms.CheckBox
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents btSendMails As System.Windows.Forms.Button
    Friend WithEvents cbSenderMail As System.Windows.Forms.ComboBox
    Friend WithEvents tpReadyForSite As System.Windows.Forms.TabPage
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tbClientName As System.Windows.Forms.TextBox
    Friend WithEvents cbWithoutClients As System.Windows.Forms.CheckBox
    Friend WithEvents btApplyFilter As System.Windows.Forms.Button
    Friend WithEvents NumericUpDownRole As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblPage As System.Windows.Forms.Label
    Friend WithEvents NumericUpDownPage As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents tbSampleNumberFilter As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents tbMailCaption As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cbxRussian As System.Windows.Forms.CheckBox
    Friend WithEvents cbxSendCatalogAsMail As System.Windows.Forms.CheckBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cbDiscount As System.Windows.Forms.ComboBox
    Friend WithEvents tpHelp As System.Windows.Forms.TabPage
    Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
    Friend WithEvents cbMCFolder As System.Windows.Forms.ComboBox
    Friend WithEvents btClearList As System.Windows.Forms.Button
    Friend WithEvents cbxOnlyWithImages As System.Windows.Forms.CheckBox
    Friend WithEvents btCheckSamples As System.Windows.Forms.Button

End Class
