Imports nopRestClient

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fmcatalog
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
        Me.btLoadFile = New System.Windows.Forms.Button()
        Me.btCreateMapping = New System.Windows.Forms.Button()
        Me.btSaveXMLMap = New System.Windows.Forms.Button()
        Me.lbTemplates = New System.Windows.Forms.ListBox()
        Me.btShowHTML = New System.Windows.Forms.Button()
        Me.btRoot = New System.Windows.Forms.Button()
        Me.rtbRoot = New System.Windows.Forms.RichTextBox()
        Me.tbRootCaption = New System.Windows.Forms.TextBox()
        Me.btCopyHTML = New System.Windows.Forms.Button()
        Me.cbxHTML = New System.Windows.Forms.CheckBox()
        Me.cbxHEAD = New System.Windows.Forms.CheckBox()
        Me.cbxBODY = New System.Windows.Forms.CheckBox()
        Me.cbxFull = New System.Windows.Forms.CheckBox()
        Me.btShowXML = New System.Windows.Forms.Button()
        Me.btCopyCode = New System.Windows.Forms.Button()
        Me.btCopyEAN13 = New System.Windows.Forms.Button()
        Me.btCopyMainName = New System.Windows.Forms.Button()
        Me.tbcMain = New System.Windows.Forms.TabControl()
        Me.tpDescription = New System.Windows.Forms.TabPage()
        Me.wbMain = New System.Windows.Forms.WebBrowser()
        Me.tbPhoto = New System.Windows.Forms.TabPage()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.tbPathToFolder = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.btDownphoto = New System.Windows.Forms.Button()
        Me.btUPphoto = New System.Windows.Forms.Button()
        Me.btImageManager = New System.Windows.Forms.Button()
        Me.UcPhotoManager1 = New Service.ucPhotoManager()
        Me.lvPhotos = New System.Windows.Forms.ListView()
        Me.tpPrices = New System.Windows.Forms.TabPage()
        Me.UserControlMC1 = New Service.UserControlMC()
        Me.tbctlSearch = New System.Windows.Forms.TabControl()
        Me.tbTrilboneSearch = New System.Windows.Forms.TabPage()
        Me.Uс_trilbone_history1 = New Service.Uc_trilbone_history()
        Me.tpEbaySearch = New System.Windows.Forms.TabPage()
        Me.tpGoogleSearch = New System.Windows.Forms.TabPage()
        Me.wbGoogleSearch = New System.Windows.Forms.WebBrowser()
        Me.tpMCSearch = New System.Windows.Forms.TabPage()
        Me.btResetMC = New System.Windows.Forms.Button()
        Me.btCorrectInMC = New System.Windows.Forms.Button()
        Me.tbGoodLocation = New System.Windows.Forms.TextBox()
        Me.btSearchLocation = New System.Windows.Forms.Button()
        Me.btSearchInMoySklad = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.ActualNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RetailPriceDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RetailCurrencyDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WeightDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BuyPriceDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BuyCurrencyDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InvocePriceDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InvoceCurrencyDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LoadStatusDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ClsApplicationTypes_clsSampleNumber_strGoodInfoBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.tpTimeSearch = New System.Windows.Forms.TabPage()
        Me.pbFirstImg = New System.Windows.Forms.PictureBox()
        Me.gbSearch = New System.Windows.Forms.GroupBox()
        Me.btSearchByUser = New System.Windows.Forms.Button()
        Me.tbPatternSearch = New System.Windows.Forms.TextBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.nudWorldCount = New System.Windows.Forms.NumericUpDown()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.tpEbay = New System.Windows.Forms.TabPage()
        Me.UC_ebay1 = New UC_ebay()
        Me.tpEmail = New System.Windows.Forms.TabPage()
        Me.Uc_mailer1 = New Service.uc_mailer()
        Me.tpSite = New System.Windows.Forms.TabPage()
        Me.Uc_nopGood1 = New nopRestClient.uc_nopGood()
        Me.Button13 = New System.Windows.Forms.Button()
        Me.tbRootID = New System.Windows.Forms.TextBox()
        Me.btClose = New System.Windows.Forms.Button()
        Me.rbEnglish = New System.Windows.Forms.RadioButton()
        Me.rbRussian = New System.Windows.Forms.RadioButton()
        Me.bs_Root = New System.Windows.Forms.BindingSource(Me.components)
        Me.BindingSourceClients = New System.Windows.Forms.BindingSource(Me.components)
        Me.btSiteReload = New System.Windows.Forms.Button()
        Me.cbSite = New System.Windows.Forms.ComboBox()
        Me.tbcMain.SuspendLayout()
        Me.tpDescription.SuspendLayout()
        Me.tbPhoto.SuspendLayout()
        Me.tpPrices.SuspendLayout()
        Me.tbctlSearch.SuspendLayout()
        Me.tbTrilboneSearch.SuspendLayout()
        Me.tpGoogleSearch.SuspendLayout()
        Me.tpMCSearch.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ClsApplicationTypes_clsSampleNumber_strGoodInfoBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbFirstImg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbSearch.SuspendLayout()
        CType(Me.nudWorldCount, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpEbay.SuspendLayout()
        Me.tpEmail.SuspendLayout()
        Me.tpSite.SuspendLayout()
        CType(Me.bs_Root, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingSourceClients, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btLoadFile
        '
        Me.btLoadFile.Location = New System.Drawing.Point(13, 7)
        Me.btLoadFile.Name = "btLoadFile"
        Me.btLoadFile.Size = New System.Drawing.Size(120, 36)
        Me.btLoadFile.TabIndex = 1
        Me.btLoadFile.Text = "открыть файл образца.."
        Me.btLoadFile.UseVisualStyleBackColor = True
        '
        'btCreateMapping
        '
        Me.btCreateMapping.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btCreateMapping.Location = New System.Drawing.Point(13, 103)
        Me.btCreateMapping.Name = "btCreateMapping"
        Me.btCreateMapping.Size = New System.Drawing.Size(120, 37)
        Me.btCreateMapping.TabIndex = 2
        Me.btCreateMapping.Text = "изменить маппинг.."
        Me.btCreateMapping.UseVisualStyleBackColor = True
        '
        'btSaveXMLMap
        '
        Me.btSaveXMLMap.Location = New System.Drawing.Point(13, 49)
        Me.btSaveXMLMap.Name = "btSaveXMLMap"
        Me.btSaveXMLMap.Size = New System.Drawing.Size(120, 34)
        Me.btSaveXMLMap.TabIndex = 4
        Me.btSaveXMLMap.Text = "сохранить карту в БД"
        Me.btSaveXMLMap.UseVisualStyleBackColor = True
        '
        'lbTemplates
        '
        Me.lbTemplates.FormattingEnabled = True
        Me.lbTemplates.Location = New System.Drawing.Point(13, 164)
        Me.lbTemplates.Name = "lbTemplates"
        Me.lbTemplates.Size = New System.Drawing.Size(120, 147)
        Me.lbTemplates.TabIndex = 5
        '
        'btShowHTML
        '
        Me.btShowHTML.Location = New System.Drawing.Point(8, 367)
        Me.btShowHTML.Name = "btShowHTML"
        Me.btShowHTML.Size = New System.Drawing.Size(122, 39)
        Me.btShowHTML.TabIndex = 7
        Me.btShowHTML.Text = "обновить HTML"
        Me.btShowHTML.UseVisualStyleBackColor = True
        '
        'btRoot
        '
        Me.btRoot.Location = New System.Drawing.Point(8, 422)
        Me.btRoot.Name = "btRoot"
        Me.btRoot.Size = New System.Drawing.Size(120, 41)
        Me.btRoot.TabIndex = 8
        Me.btRoot.Text = "инфо типа материала"
        Me.btRoot.UseVisualStyleBackColor = True
        '
        'rtbRoot
        '
        Me.rtbRoot.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.rtbRoot.Location = New System.Drawing.Point(4, 27)
        Me.rtbRoot.Name = "rtbRoot"
        Me.rtbRoot.Size = New System.Drawing.Size(1008, 577)
        Me.rtbRoot.TabIndex = 9
        Me.rtbRoot.Text = ""
        Me.rtbRoot.Visible = False
        '
        'tbRootCaption
        '
        Me.tbRootCaption.Dock = System.Windows.Forms.DockStyle.Top
        Me.tbRootCaption.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.tbRootCaption.Location = New System.Drawing.Point(3, 3)
        Me.tbRootCaption.Name = "tbRootCaption"
        Me.tbRootCaption.Size = New System.Drawing.Size(1086, 22)
        Me.tbRootCaption.TabIndex = 10
        Me.tbRootCaption.Visible = False
        '
        'btCopyHTML
        '
        Me.btCopyHTML.Location = New System.Drawing.Point(8, 608)
        Me.btCopyHTML.Name = "btCopyHTML"
        Me.btCopyHTML.Size = New System.Drawing.Size(93, 47)
        Me.btCopyHTML.TabIndex = 12
        Me.btCopyHTML.Text = "Копировать HTML"
        Me.btCopyHTML.UseVisualStyleBackColor = True
        '
        'cbxHTML
        '
        Me.cbxHTML.AutoSize = True
        Me.cbxHTML.Checked = True
        Me.cbxHTML.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbxHTML.Location = New System.Drawing.Point(575, 747)
        Me.cbxHTML.Name = "cbxHTML"
        Me.cbxHTML.Size = New System.Drawing.Size(105, 17)
        Me.cbxHTML.TabIndex = 13
        Me.cbxHTML.Text = "включить<html>"
        Me.cbxHTML.UseVisualStyleBackColor = True
        '
        'cbxHEAD
        '
        Me.cbxHEAD.AutoSize = True
        Me.cbxHEAD.Checked = True
        Me.cbxHEAD.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbxHEAD.Location = New System.Drawing.Point(446, 747)
        Me.cbxHEAD.Name = "cbxHEAD"
        Me.cbxHEAD.Size = New System.Drawing.Size(113, 17)
        Me.cbxHEAD.TabIndex = 14
        Me.cbxHEAD.Text = "включить <head>"
        Me.cbxHEAD.UseVisualStyleBackColor = True
        '
        'cbxBODY
        '
        Me.cbxBODY.AutoSize = True
        Me.cbxBODY.Checked = True
        Me.cbxBODY.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbxBODY.Location = New System.Drawing.Point(318, 747)
        Me.cbxBODY.Name = "cbxBODY"
        Me.cbxBODY.Size = New System.Drawing.Size(112, 17)
        Me.cbxBODY.TabIndex = 15
        Me.cbxBODY.Text = "включить <body>"
        Me.cbxBODY.UseVisualStyleBackColor = True
        '
        'cbxFull
        '
        Me.cbxFull.AutoSize = True
        Me.cbxFull.Checked = True
        Me.cbxFull.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbxFull.Location = New System.Drawing.Point(699, 747)
        Me.cbxFull.Name = "cbxFull"
        Me.cbxFull.Size = New System.Drawing.Size(81, 17)
        Me.cbxFull.TabIndex = 16
        Me.cbxFull.Text = "полностью"
        Me.cbxFull.UseVisualStyleBackColor = True
        '
        'btShowXML
        '
        Me.btShowXML.Location = New System.Drawing.Point(796, 744)
        Me.btShowXML.Name = "btShowXML"
        Me.btShowXML.Size = New System.Drawing.Size(128, 23)
        Me.btShowXML.TabIndex = 17
        Me.btShowXML.Text = "Показать XML"
        Me.btShowXML.UseVisualStyleBackColor = True
        '
        'btCopyCode
        '
        Me.btCopyCode.Location = New System.Drawing.Point(8, 579)
        Me.btCopyCode.Name = "btCopyCode"
        Me.btCopyCode.Size = New System.Drawing.Size(93, 23)
        Me.btCopyCode.TabIndex = 18
        Me.btCopyCode.Text = "копир. артикул"
        Me.btCopyCode.UseVisualStyleBackColor = True
        '
        'btCopyEAN13
        '
        Me.btCopyEAN13.Location = New System.Drawing.Point(8, 550)
        Me.btCopyEAN13.Name = "btCopyEAN13"
        Me.btCopyEAN13.Size = New System.Drawing.Size(85, 23)
        Me.btCopyEAN13.TabIndex = 19
        Me.btCopyEAN13.Text = "копир. EAN13"
        Me.btCopyEAN13.UseVisualStyleBackColor = True
        '
        'btCopyMainName
        '
        Me.btCopyMainName.Location = New System.Drawing.Point(8, 505)
        Me.btCopyMainName.Name = "btCopyMainName"
        Me.btCopyMainName.Size = New System.Drawing.Size(115, 39)
        Me.btCopyMainName.TabIndex = 21
        Me.btCopyMainName.Text = "Копировать название"
        Me.btCopyMainName.UseVisualStyleBackColor = True
        '
        'tbcMain
        '
        Me.tbcMain.Controls.Add(Me.tpDescription)
        Me.tbcMain.Controls.Add(Me.tbPhoto)
        Me.tbcMain.Controls.Add(Me.tpPrices)
        Me.tbcMain.Controls.Add(Me.tpEbay)
        Me.tbcMain.Controls.Add(Me.tpEmail)
        Me.tbcMain.Controls.Add(Me.tpSite)
        Me.tbcMain.Location = New System.Drawing.Point(136, 3)
        Me.tbcMain.Name = "tbcMain"
        Me.tbcMain.SelectedIndex = 0
        Me.tbcMain.Size = New System.Drawing.Size(1100, 736)
        Me.tbcMain.TabIndex = 29
        '
        'tpDescription
        '
        Me.tpDescription.Controls.Add(Me.tbRootCaption)
        Me.tpDescription.Controls.Add(Me.wbMain)
        Me.tpDescription.Controls.Add(Me.rtbRoot)
        Me.tpDescription.Location = New System.Drawing.Point(4, 22)
        Me.tpDescription.Name = "tpDescription"
        Me.tpDescription.Padding = New System.Windows.Forms.Padding(3)
        Me.tpDescription.Size = New System.Drawing.Size(1092, 710)
        Me.tpDescription.TabIndex = 0
        Me.tpDescription.Text = "HTML"
        Me.tpDescription.UseVisualStyleBackColor = True
        '
        'wbMain
        '
        Me.wbMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.wbMain.Location = New System.Drawing.Point(3, 3)
        Me.wbMain.MinimumSize = New System.Drawing.Size(20, 20)
        Me.wbMain.Name = "wbMain"
        Me.wbMain.Size = New System.Drawing.Size(1086, 704)
        Me.wbMain.TabIndex = 0
        '
        'tbPhoto
        '
        Me.tbPhoto.Controls.Add(Me.Label1)
        Me.tbPhoto.Controls.Add(Me.Label40)
        Me.tbPhoto.Controls.Add(Me.tbPathToFolder)
        Me.tbPhoto.Controls.Add(Me.Label24)
        Me.tbPhoto.Controls.Add(Me.btDownphoto)
        Me.tbPhoto.Controls.Add(Me.btUPphoto)
        Me.tbPhoto.Controls.Add(Me.btImageManager)
        Me.tbPhoto.Controls.Add(Me.UcPhotoManager1)
        Me.tbPhoto.Controls.Add(Me.lvPhotos)
        Me.tbPhoto.Location = New System.Drawing.Point(4, 22)
        Me.tbPhoto.Name = "tbPhoto"
        Me.tbPhoto.Size = New System.Drawing.Size(1092, 710)
        Me.tbPhoto.TabIndex = 4
        Me.tbPhoto.Text = "Фотки"
        Me.tbPhoto.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(847, 102)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(208, 13)
        Me.Label1.TabIndex = 41
        Me.Label1.Text = "выделить + del - удалить фото из карты"
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Location = New System.Drawing.Point(13, 510)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(73, 13)
        Me.Label40.TabIndex = 40
        Me.Label40.Text = "Путь к папке"
        '
        'tbPathToFolder
        '
        Me.tbPathToFolder.Location = New System.Drawing.Point(92, 507)
        Me.tbPathToFolder.Name = "tbPathToFolder"
        Me.tbPathToFolder.Size = New System.Drawing.Size(453, 20)
        Me.tbPathToFolder.TabIndex = 39
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(847, 64)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(180, 13)
        Me.Label24.TabIndex = 38
        Me.Label24.Text = "rightclick - открыть просмотр фото"
        '
        'btDownphoto
        '
        Me.btDownphoto.Location = New System.Drawing.Point(850, 239)
        Me.btDownphoto.Name = "btDownphoto"
        Me.btDownphoto.Size = New System.Drawing.Size(44, 46)
        Me.btDownphoto.TabIndex = 34
        Me.btDownphoto.Text = "Down"
        Me.btDownphoto.UseVisualStyleBackColor = True
        '
        'btUPphoto
        '
        Me.btUPphoto.Location = New System.Drawing.Point(850, 178)
        Me.btUPphoto.Name = "btUPphoto"
        Me.btUPphoto.Size = New System.Drawing.Size(44, 42)
        Me.btUPphoto.TabIndex = 33
        Me.btUPphoto.Text = "Up"
        Me.btUPphoto.UseVisualStyleBackColor = True
        '
        'btImageManager
        '
        Me.btImageManager.Location = New System.Drawing.Point(623, 14)
        Me.btImageManager.Name = "btImageManager"
        Me.btImageManager.Size = New System.Drawing.Size(130, 23)
        Me.btImageManager.TabIndex = 31
        Me.btImageManager.Text = "Управление фотками"
        Me.btImageManager.UseVisualStyleBackColor = True
        '
        'UcPhotoManager1
        '
        Me.UcPhotoManager1.GetLayerTextNumberDelegate = Nothing
        Me.UcPhotoManager1.Location = New System.Drawing.Point(3, 3)
        Me.UcPhotoManager1.Name = "UcPhotoManager1"
        Me.UcPhotoManager1.Size = New System.Drawing.Size(542, 487)
        Me.UcPhotoManager1.TabIndex = 0
        '
        'lvPhotos
        '
        Me.lvPhotos.Location = New System.Drawing.Point(623, 43)
        Me.lvPhotos.Name = "lvPhotos"
        Me.lvPhotos.Size = New System.Drawing.Size(203, 574)
        Me.lvPhotos.TabIndex = 32
        Me.lvPhotos.UseCompatibleStateImageBehavior = False
        '
        'tpPrices
        '
        Me.tpPrices.AutoScroll = True
        Me.tpPrices.Controls.Add(Me.UserControlMC1)
        Me.tpPrices.Controls.Add(Me.tbctlSearch)
        Me.tpPrices.Controls.Add(Me.pbFirstImg)
        Me.tpPrices.Controls.Add(Me.gbSearch)
        Me.tpPrices.Location = New System.Drawing.Point(4, 22)
        Me.tpPrices.Name = "tpPrices"
        Me.tpPrices.Padding = New System.Windows.Forms.Padding(3)
        Me.tpPrices.Size = New System.Drawing.Size(1092, 710)
        Me.tpPrices.TabIndex = 2
        Me.tpPrices.Text = "Цены"
        Me.tpPrices.UseVisualStyleBackColor = True
        '
        'UserControlMC1
        '
        Me.UserControlMC1.Location = New System.Drawing.Point(3, 0)
        Me.UserControlMC1.Name = "UserControlMC1"
        Me.UserControlMC1.SampleName = ""
        Me.UserControlMC1.SampleNumber = Nothing
        Me.UserControlMC1.SampleWeight = New Decimal(New Integer() {0, 0, 0, 0})
        Me.UserControlMC1.Size = New System.Drawing.Size(450, 260)
        Me.UserControlMC1.TabIndex = 12
        '
        'tbctlSearch
        '
        Me.tbctlSearch.Controls.Add(Me.tbTrilboneSearch)
        Me.tbctlSearch.Controls.Add(Me.tpEbaySearch)
        Me.tbctlSearch.Controls.Add(Me.tpGoogleSearch)
        Me.tbctlSearch.Controls.Add(Me.tpMCSearch)
        Me.tbctlSearch.Controls.Add(Me.tpTimeSearch)
        Me.tbctlSearch.Location = New System.Drawing.Point(6, 266)
        Me.tbctlSearch.Name = "tbctlSearch"
        Me.tbctlSearch.SelectedIndex = 0
        Me.tbctlSearch.Size = New System.Drawing.Size(1083, 438)
        Me.tbctlSearch.TabIndex = 10
        '
        'tbTrilboneSearch
        '
        Me.tbTrilboneSearch.Controls.Add(Me.Uс_trilbone_history1)
        Me.tbTrilboneSearch.Location = New System.Drawing.Point(4, 22)
        Me.tbTrilboneSearch.Name = "tbTrilboneSearch"
        Me.tbTrilboneSearch.Padding = New System.Windows.Forms.Padding(3)
        Me.tbTrilboneSearch.Size = New System.Drawing.Size(1075, 412)
        Me.tbTrilboneSearch.TabIndex = 2
        Me.tbTrilboneSearch.Text = "в Базе"
        Me.tbTrilboneSearch.UseVisualStyleBackColor = True
        '
        'Uс_trilbone_history1
        '
        Me.Uс_trilbone_history1.Location = New System.Drawing.Point(7, 7)
        Me.Uс_trilbone_history1.Name = "Uс_trilbone_history1"
        Me.Uс_trilbone_history1.Size = New System.Drawing.Size(713, 351)
        Me.Uс_trilbone_history1.TabIndex = 0
        '
        'tpEbaySearch
        '
        Me.tpEbaySearch.AutoScroll = True
        Me.tpEbaySearch.Location = New System.Drawing.Point(4, 22)
        Me.tpEbaySearch.Name = "tpEbaySearch"
        Me.tpEbaySearch.Padding = New System.Windows.Forms.Padding(3)
        Me.tpEbaySearch.Size = New System.Drawing.Size(1075, 412)
        Me.tpEbaySearch.TabIndex = 0
        Me.tpEbaySearch.Text = "В eBay"
        Me.tpEbaySearch.UseVisualStyleBackColor = True
        '
        'tpGoogleSearch
        '
        Me.tpGoogleSearch.Controls.Add(Me.wbGoogleSearch)
        Me.tpGoogleSearch.Location = New System.Drawing.Point(4, 22)
        Me.tpGoogleSearch.Name = "tpGoogleSearch"
        Me.tpGoogleSearch.Padding = New System.Windows.Forms.Padding(3)
        Me.tpGoogleSearch.Size = New System.Drawing.Size(1075, 412)
        Me.tpGoogleSearch.TabIndex = 1
        Me.tpGoogleSearch.Text = "в Google"
        Me.tpGoogleSearch.UseVisualStyleBackColor = True
        '
        'wbGoogleSearch
        '
        Me.wbGoogleSearch.Dock = System.Windows.Forms.DockStyle.Fill
        Me.wbGoogleSearch.Location = New System.Drawing.Point(3, 3)
        Me.wbGoogleSearch.MinimumSize = New System.Drawing.Size(20, 20)
        Me.wbGoogleSearch.Name = "wbGoogleSearch"
        Me.wbGoogleSearch.Size = New System.Drawing.Size(1069, 406)
        Me.wbGoogleSearch.TabIndex = 0
        '
        'tpMCSearch
        '
        Me.tpMCSearch.Controls.Add(Me.btResetMC)
        Me.tpMCSearch.Controls.Add(Me.btCorrectInMC)
        Me.tpMCSearch.Controls.Add(Me.tbGoodLocation)
        Me.tpMCSearch.Controls.Add(Me.btSearchLocation)
        Me.tpMCSearch.Controls.Add(Me.btSearchInMoySklad)
        Me.tpMCSearch.Controls.Add(Me.DataGridView1)
        Me.tpMCSearch.Location = New System.Drawing.Point(4, 22)
        Me.tpMCSearch.Name = "tpMCSearch"
        Me.tpMCSearch.Padding = New System.Windows.Forms.Padding(3)
        Me.tpMCSearch.Size = New System.Drawing.Size(1075, 412)
        Me.tpMCSearch.TabIndex = 3
        Me.tpMCSearch.Text = "в Моем Складе"
        Me.tpMCSearch.UseVisualStyleBackColor = True
        '
        'btResetMC
        '
        Me.btResetMC.Location = New System.Drawing.Point(149, 7)
        Me.btResetMC.Name = "btResetMC"
        Me.btResetMC.Size = New System.Drawing.Size(75, 23)
        Me.btResetMC.TabIndex = 5
        Me.btResetMC.Text = "Сброс"
        Me.btResetMC.UseVisualStyleBackColor = True
        '
        'btCorrectInMC
        '
        Me.btCorrectInMC.Location = New System.Drawing.Point(27, 332)
        Me.btCorrectInMC.Name = "btCorrectInMC"
        Me.btCorrectInMC.Size = New System.Drawing.Size(75, 23)
        Me.btCorrectInMC.TabIndex = 4
        Me.btCorrectInMC.Text = "Коррекция"
        Me.btCorrectInMC.UseVisualStyleBackColor = True
        '
        'tbGoodLocation
        '
        Me.tbGoodLocation.Location = New System.Drawing.Point(118, 294)
        Me.tbGoodLocation.Name = "tbGoodLocation"
        Me.tbGoodLocation.Size = New System.Drawing.Size(396, 20)
        Me.tbGoodLocation.TabIndex = 3
        '
        'btSearchLocation
        '
        Me.btSearchLocation.Location = New System.Drawing.Point(27, 292)
        Me.btSearchLocation.Name = "btSearchLocation"
        Me.btSearchLocation.Size = New System.Drawing.Size(75, 23)
        Me.btSearchLocation.TabIndex = 2
        Me.btSearchLocation.Text = "Где лежит"
        Me.btSearchLocation.UseVisualStyleBackColor = True
        '
        'btSearchInMoySklad
        '
        Me.btSearchInMoySklad.Location = New System.Drawing.Point(27, 7)
        Me.btSearchInMoySklad.Name = "btSearchInMoySklad"
        Me.btSearchInMoySklad.Size = New System.Drawing.Size(75, 23)
        Me.btSearchInMoySklad.TabIndex = 1
        Me.btSearchInMoySklad.Text = "Запрос"
        Me.btSearchInMoySklad.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ActualNumberDataGridViewTextBoxColumn, Me.NameDataGridViewTextBoxColumn, Me.RetailPriceDataGridViewTextBoxColumn, Me.RetailCurrencyDataGridViewTextBoxColumn, Me.WeightDataGridViewTextBoxColumn, Me.BuyPriceDataGridViewTextBoxColumn, Me.BuyCurrencyDataGridViewTextBoxColumn, Me.InvocePriceDataGridViewTextBoxColumn, Me.InvoceCurrencyDataGridViewTextBoxColumn, Me.LoadStatusDataGridViewTextBoxColumn})
        Me.DataGridView1.DataSource = Me.ClsApplicationTypes_clsSampleNumber_strGoodInfoBindingSource
        Me.DataGridView1.Location = New System.Drawing.Point(27, 36)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(1025, 241)
        Me.DataGridView1.TabIndex = 0
        '
        'ActualNumberDataGridViewTextBoxColumn
        '
        Me.ActualNumberDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.ActualNumberDataGridViewTextBoxColumn.DataPropertyName = "ActualNumber"
        Me.ActualNumberDataGridViewTextBoxColumn.HeaderText = "Номер"
        Me.ActualNumberDataGridViewTextBoxColumn.Name = "ActualNumberDataGridViewTextBoxColumn"
        Me.ActualNumberDataGridViewTextBoxColumn.ReadOnly = True
        Me.ActualNumberDataGridViewTextBoxColumn.Width = 66
        '
        'NameDataGridViewTextBoxColumn
        '
        Me.NameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.NameDataGridViewTextBoxColumn.DataPropertyName = "Name"
        Me.NameDataGridViewTextBoxColumn.HeaderText = "Название"
        Me.NameDataGridViewTextBoxColumn.Name = "NameDataGridViewTextBoxColumn"
        Me.NameDataGridViewTextBoxColumn.Width = 82
        '
        'RetailPriceDataGridViewTextBoxColumn
        '
        Me.RetailPriceDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.RetailPriceDataGridViewTextBoxColumn.DataPropertyName = "RetailPrice"
        Me.RetailPriceDataGridViewTextBoxColumn.HeaderText = "Розница"
        Me.RetailPriceDataGridViewTextBoxColumn.Name = "RetailPriceDataGridViewTextBoxColumn"
        Me.RetailPriceDataGridViewTextBoxColumn.Width = 75
        '
        'RetailCurrencyDataGridViewTextBoxColumn
        '
        Me.RetailCurrencyDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.RetailCurrencyDataGridViewTextBoxColumn.DataPropertyName = "RetailCurrency"
        Me.RetailCurrencyDataGridViewTextBoxColumn.HeaderText = "вал"
        Me.RetailCurrencyDataGridViewTextBoxColumn.Name = "RetailCurrencyDataGridViewTextBoxColumn"
        Me.RetailCurrencyDataGridViewTextBoxColumn.Width = 50
        '
        'WeightDataGridViewTextBoxColumn
        '
        Me.WeightDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.WeightDataGridViewTextBoxColumn.DataPropertyName = "Weight"
        Me.WeightDataGridViewTextBoxColumn.HeaderText = "Вес"
        Me.WeightDataGridViewTextBoxColumn.Name = "WeightDataGridViewTextBoxColumn"
        Me.WeightDataGridViewTextBoxColumn.Width = 51
        '
        'BuyPriceDataGridViewTextBoxColumn
        '
        Me.BuyPriceDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.BuyPriceDataGridViewTextBoxColumn.DataPropertyName = "BuyPrice"
        Me.BuyPriceDataGridViewTextBoxColumn.HeaderText = "Закупка"
        Me.BuyPriceDataGridViewTextBoxColumn.Name = "BuyPriceDataGridViewTextBoxColumn"
        Me.BuyPriceDataGridViewTextBoxColumn.Width = 74
        '
        'BuyCurrencyDataGridViewTextBoxColumn
        '
        Me.BuyCurrencyDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.BuyCurrencyDataGridViewTextBoxColumn.DataPropertyName = "BuyCurrency"
        Me.BuyCurrencyDataGridViewTextBoxColumn.HeaderText = "вал"
        Me.BuyCurrencyDataGridViewTextBoxColumn.Name = "BuyCurrencyDataGridViewTextBoxColumn"
        Me.BuyCurrencyDataGridViewTextBoxColumn.Width = 50
        '
        'InvocePriceDataGridViewTextBoxColumn
        '
        Me.InvocePriceDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.InvocePriceDataGridViewTextBoxColumn.DataPropertyName = "InvocePrice"
        Me.InvocePriceDataGridViewTextBoxColumn.HeaderText = "Инвойс"
        Me.InvocePriceDataGridViewTextBoxColumn.Name = "InvocePriceDataGridViewTextBoxColumn"
        Me.InvocePriceDataGridViewTextBoxColumn.Width = 70
        '
        'InvoceCurrencyDataGridViewTextBoxColumn
        '
        Me.InvoceCurrencyDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.InvoceCurrencyDataGridViewTextBoxColumn.DataPropertyName = "InvoceCurrency"
        Me.InvoceCurrencyDataGridViewTextBoxColumn.HeaderText = "вал"
        Me.InvoceCurrencyDataGridViewTextBoxColumn.Name = "InvoceCurrencyDataGridViewTextBoxColumn"
        Me.InvoceCurrencyDataGridViewTextBoxColumn.Width = 50
        '
        'LoadStatusDataGridViewTextBoxColumn
        '
        Me.LoadStatusDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.LoadStatusDataGridViewTextBoxColumn.DataPropertyName = "LoadStatus"
        Me.LoadStatusDataGridViewTextBoxColumn.HeaderText = "LoadStatus"
        Me.LoadStatusDataGridViewTextBoxColumn.Name = "LoadStatusDataGridViewTextBoxColumn"
        Me.LoadStatusDataGridViewTextBoxColumn.Width = 86
        '
        'ClsApplicationTypes_clsSampleNumber_strGoodInfoBindingSource
        '
        Me.ClsApplicationTypes_clsSampleNumber_strGoodInfoBindingSource.DataSource = GetType(System.Collections.Generic.List(Of Service.clsApplicationTypes.clsSampleNumber.strGoodInfo))
        '
        'tpTimeSearch
        '
        Me.tpTimeSearch.Location = New System.Drawing.Point(4, 22)
        Me.tpTimeSearch.Name = "tpTimeSearch"
        Me.tpTimeSearch.Size = New System.Drawing.Size(1075, 412)
        Me.tpTimeSearch.TabIndex = 4
        Me.tpTimeSearch.Text = "Время образца"
        Me.tpTimeSearch.UseVisualStyleBackColor = True
        '
        'pbFirstImg
        '
        Me.pbFirstImg.Location = New System.Drawing.Point(812, 97)
        Me.pbFirstImg.Name = "pbFirstImg"
        Me.pbFirstImg.Size = New System.Drawing.Size(218, 163)
        Me.pbFirstImg.TabIndex = 11
        Me.pbFirstImg.TabStop = False
        '
        'gbSearch
        '
        Me.gbSearch.Controls.Add(Me.btSearchByUser)
        Me.gbSearch.Controls.Add(Me.tbPatternSearch)
        Me.gbSearch.Controls.Add(Me.Label32)
        Me.gbSearch.Controls.Add(Me.nudWorldCount)
        Me.gbSearch.Controls.Add(Me.CheckBox1)
        Me.gbSearch.Controls.Add(Me.Label29)
        Me.gbSearch.Controls.Add(Me.TextBox2)
        Me.gbSearch.Controls.Add(Me.Label28)
        Me.gbSearch.Location = New System.Drawing.Point(472, 137)
        Me.gbSearch.Name = "gbSearch"
        Me.gbSearch.Size = New System.Drawing.Size(312, 123)
        Me.gbSearch.TabIndex = 9
        Me.gbSearch.TabStop = False
        Me.gbSearch.Text = "Поиск"
        '
        'btSearchByUser
        '
        Me.btSearchByUser.Location = New System.Drawing.Point(231, 63)
        Me.btSearchByUser.Name = "btSearchByUser"
        Me.btSearchByUser.Size = New System.Drawing.Size(75, 23)
        Me.btSearchByUser.TabIndex = 14
        Me.btSearchByUser.Text = "Поиск"
        Me.btSearchByUser.UseVisualStyleBackColor = True
        '
        'tbPatternSearch
        '
        Me.tbPatternSearch.Location = New System.Drawing.Point(6, 95)
        Me.tbPatternSearch.Name = "tbPatternSearch"
        Me.tbPatternSearch.Size = New System.Drawing.Size(300, 20)
        Me.tbPatternSearch.TabIndex = 13
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(19, 73)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(92, 13)
        Me.Label32.TabIndex = 12
        Me.Label32.Text = "Слов для поиска"
        '
        'nudWorldCount
        '
        Me.nudWorldCount.Location = New System.Drawing.Point(117, 69)
        Me.nudWorldCount.Maximum = New Decimal(New Integer() {4, 0, 0, 0})
        Me.nudWorldCount.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudWorldCount.Name = "nudWorldCount"
        Me.nudWorldCount.Size = New System.Drawing.Size(34, 20)
        Me.nudWorldCount.TabIndex = 11
        Me.nudWorldCount.Value = New Decimal(New Integer() {2, 0, 0, 0})
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Enabled = False
        Me.CheckBox1.Location = New System.Drawing.Point(20, 42)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(179, 17)
        Me.CheckBox1.TabIndex = 9
        Me.CheckBox1.Text = "учитывать размер при поиске"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Enabled = False
        Me.Label29.Location = New System.Drawing.Point(174, 20)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(37, 13)
        Me.Label29.TabIndex = 7
        Me.Label29.Text = "см/кг"
        '
        'TextBox2
        '
        Me.TextBox2.Enabled = False
        Me.TextBox2.Location = New System.Drawing.Point(117, 16)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(51, 20)
        Me.TextBox2.TabIndex = 6
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Enabled = False
        Me.Label28.Location = New System.Drawing.Point(14, 19)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(83, 13)
        Me.Label28.TabIndex = 5
        Me.Label28.Text = "Размер/масса"
        '
        'tpEbay
        '
        Me.tpEbay.Controls.Add(Me.UC_ebay1)
        Me.tpEbay.Location = New System.Drawing.Point(4, 22)
        Me.tpEbay.Name = "tpEbay"
        Me.tpEbay.Padding = New System.Windows.Forms.Padding(3)
        Me.tpEbay.Size = New System.Drawing.Size(1092, 710)
        Me.tpEbay.TabIndex = 1
        Me.tpEbay.Text = "eBay"
        Me.tpEbay.UseVisualStyleBackColor = True
        '
        'UC_ebay1
        '
        Me.UC_ebay1.CurrentHTML = Nothing
        Me.UC_ebay1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UC_ebay1.Location = New System.Drawing.Point(3, 3)
        Me.UC_ebay1.Name = "UC_ebay1"
        Me.UC_ebay1.PicturePaths = Nothing
        Me.UC_ebay1.Size = New System.Drawing.Size(1086, 704)
        Me.UC_ebay1.TabIndex = 0
        '
        'tpEmail
        '
        Me.tpEmail.Controls.Add(Me.Uc_mailer1)
        Me.tpEmail.Location = New System.Drawing.Point(4, 22)
        Me.tpEmail.Name = "tpEmail"
        Me.tpEmail.Size = New System.Drawing.Size(1092, 710)
        Me.tpEmail.TabIndex = 3
        Me.tpEmail.Text = "eMail"
        Me.tpEmail.UseVisualStyleBackColor = True
        '
        'Uc_mailer1
        '
        Me.Uc_mailer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Uc_mailer1.Location = New System.Drawing.Point(0, 0)
        Me.Uc_mailer1.Name = "Uc_mailer1"
        Me.Uc_mailer1.PicturePaths = Nothing
        Me.Uc_mailer1.Size = New System.Drawing.Size(1092, 710)
        Me.Uc_mailer1.TabIndex = 0
        '
        'tpSite
        '
        Me.tpSite.Controls.Add(Me.Uc_nopGood1)
        Me.tpSite.Location = New System.Drawing.Point(4, 22)
        Me.tpSite.Name = "tpSite"
        Me.tpSite.Padding = New System.Windows.Forms.Padding(3)
        Me.tpSite.Size = New System.Drawing.Size(1092, 710)
        Me.tpSite.TabIndex = 5
        Me.tpSite.Text = "Сайт"
        Me.tpSite.UseVisualStyleBackColor = True
        '
        'Uc_nopGood1
        '
        Me.Uc_nopGood1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Uc_nopGood1.Location = New System.Drawing.Point(3, 3)
        Me.Uc_nopGood1.Name = "Uc_nopGood1"
        Me.Uc_nopGood1.Size = New System.Drawing.Size(1086, 704)
        Me.Uc_nopGood1.TabIndex = 0
        '
        'Button13
        '
        Me.Button13.Location = New System.Drawing.Point(945, 744)
        Me.Button13.Name = "Button13"
        Me.Button13.Size = New System.Drawing.Size(128, 23)
        Me.Button13.TabIndex = 30
        Me.Button13.Text = "Показать HTML"
        Me.Button13.UseVisualStyleBackColor = True
        '
        'tbRootID
        '
        Me.tbRootID.Location = New System.Drawing.Point(8, 469)
        Me.tbRootID.Name = "tbRootID"
        Me.tbRootID.Size = New System.Drawing.Size(120, 20)
        Me.tbRootID.TabIndex = 11
        Me.tbRootID.Visible = False
        '
        'btClose
        '
        Me.btClose.Location = New System.Drawing.Point(139, 743)
        Me.btClose.Name = "btClose"
        Me.btClose.Size = New System.Drawing.Size(128, 23)
        Me.btClose.TabIndex = 37
        Me.btClose.Text = "Закрыть"
        Me.btClose.UseVisualStyleBackColor = True
        '
        'rbEnglish
        '
        Me.rbEnglish.AutoSize = True
        Me.rbEnglish.Checked = True
        Me.rbEnglish.Location = New System.Drawing.Point(41, 318)
        Me.rbEnglish.Name = "rbEnglish"
        Me.rbEnglish.Size = New System.Drawing.Size(59, 17)
        Me.rbEnglish.TabIndex = 45
        Me.rbEnglish.TabStop = True
        Me.rbEnglish.Text = "English"
        Me.rbEnglish.UseVisualStyleBackColor = True
        '
        'rbRussian
        '
        Me.rbRussian.AutoSize = True
        Me.rbRussian.Location = New System.Drawing.Point(41, 341)
        Me.rbRussian.Name = "rbRussian"
        Me.rbRussian.Size = New System.Drawing.Size(67, 17)
        Me.rbRussian.TabIndex = 44
        Me.rbRussian.Text = "Русский"
        Me.rbRussian.UseVisualStyleBackColor = True
        '
        'btSiteReload
        '
        Me.btSiteReload.Location = New System.Drawing.Point(12, 672)
        Me.btSiteReload.Name = "btSiteReload"
        Me.btSiteReload.Size = New System.Drawing.Size(106, 46)
        Me.btSiteReload.TabIndex = 46
        Me.btSiteReload.Text = "Перегрузить данные сайта"
        Me.btSiteReload.UseVisualStyleBackColor = True
        '
        'cbSite
        '
        Me.cbSite.FormattingEnabled = True
        Me.cbSite.Location = New System.Drawing.Point(7, 724)
        Me.cbSite.Name = "cbSite"
        Me.cbSite.Size = New System.Drawing.Size(121, 21)
        Me.cbSite.TabIndex = 47
        '
        'fmcatalog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1239, 775)
        Me.Controls.Add(Me.cbSite)
        Me.Controls.Add(Me.btSiteReload)
        Me.Controls.Add(Me.rbEnglish)
        Me.Controls.Add(Me.rbRussian)
        Me.Controls.Add(Me.btClose)
        Me.Controls.Add(Me.Button13)
        Me.Controls.Add(Me.tbcMain)
        Me.Controls.Add(Me.btCopyMainName)
        Me.Controls.Add(Me.btCopyEAN13)
        Me.Controls.Add(Me.btCopyCode)
        Me.Controls.Add(Me.btShowXML)
        Me.Controls.Add(Me.cbxFull)
        Me.Controls.Add(Me.cbxBODY)
        Me.Controls.Add(Me.cbxHEAD)
        Me.Controls.Add(Me.cbxHTML)
        Me.Controls.Add(Me.btCopyHTML)
        Me.Controls.Add(Me.tbRootID)
        Me.Controls.Add(Me.btRoot)
        Me.Controls.Add(Me.btShowHTML)
        Me.Controls.Add(Me.lbTemplates)
        Me.Controls.Add(Me.btSaveXMLMap)
        Me.Controls.Add(Me.btCreateMapping)
        Me.Controls.Add(Me.btLoadFile)
        Me.Name = "fmcatalog"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Управление выводом образца"
        Me.tbcMain.ResumeLayout(False)
        Me.tpDescription.ResumeLayout(False)
        Me.tpDescription.PerformLayout()
        Me.tbPhoto.ResumeLayout(False)
        Me.tbPhoto.PerformLayout()
        Me.tpPrices.ResumeLayout(False)
        Me.tbctlSearch.ResumeLayout(False)
        Me.tbTrilboneSearch.ResumeLayout(False)
        Me.tpGoogleSearch.ResumeLayout(False)
        Me.tpMCSearch.ResumeLayout(False)
        Me.tpMCSearch.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ClsApplicationTypes_clsSampleNumber_strGoodInfoBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbFirstImg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbSearch.ResumeLayout(False)
        Me.gbSearch.PerformLayout()
        CType(Me.nudWorldCount, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpEbay.ResumeLayout(False)
        Me.tpEmail.ResumeLayout(False)
        Me.tpSite.ResumeLayout(False)
        CType(Me.bs_Root, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingSourceClients, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents wbMain As System.Windows.Forms.WebBrowser
    Friend WithEvents btLoadFile As System.Windows.Forms.Button
    Friend WithEvents btCreateMapping As System.Windows.Forms.Button
    Friend WithEvents btSaveXMLMap As System.Windows.Forms.Button
    Friend WithEvents lbTemplates As System.Windows.Forms.ListBox
    Friend WithEvents btShowHTML As System.Windows.Forms.Button
    Friend WithEvents btRoot As System.Windows.Forms.Button
    Friend WithEvents rtbRoot As System.Windows.Forms.RichTextBox
    Friend WithEvents tbRootCaption As System.Windows.Forms.TextBox
    Friend WithEvents btCopyHTML As System.Windows.Forms.Button
    Friend WithEvents cbxHTML As System.Windows.Forms.CheckBox
    Friend WithEvents cbxHEAD As System.Windows.Forms.CheckBox
    Friend WithEvents cbxBODY As System.Windows.Forms.CheckBox
    Friend WithEvents cbxFull As System.Windows.Forms.CheckBox
    Friend WithEvents btShowXML As System.Windows.Forms.Button
    Friend WithEvents btCopyCode As System.Windows.Forms.Button
    Friend WithEvents btCopyEAN13 As System.Windows.Forms.Button
    Friend WithEvents btCopyMainName As System.Windows.Forms.Button
    Friend WithEvents tbcMain As System.Windows.Forms.TabControl
    Friend WithEvents tpDescription As System.Windows.Forms.TabPage
    Friend WithEvents tpEbay As System.Windows.Forms.TabPage
    Friend WithEvents Button13 As System.Windows.Forms.Button
    Friend WithEvents btImageManager As System.Windows.Forms.Button
    Friend WithEvents lvPhotos As System.Windows.Forms.ListView
    Friend WithEvents tbRootID As System.Windows.Forms.TextBox
    Friend WithEvents btUPphoto As System.Windows.Forms.Button
    Friend WithEvents btDownphoto As System.Windows.Forms.Button
    Friend WithEvents btClose As System.Windows.Forms.Button
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents tpPrices As System.Windows.Forms.TabPage
    Friend WithEvents tbctlSearch As System.Windows.Forms.TabControl
    Friend WithEvents tpEbaySearch As System.Windows.Forms.TabPage
    Friend WithEvents tpGoogleSearch As System.Windows.Forms.TabPage
    Friend WithEvents tbTrilboneSearch As System.Windows.Forms.TabPage
    Friend WithEvents tpMCSearch As System.Windows.Forms.TabPage
    Friend WithEvents gbSearch As System.Windows.Forms.GroupBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents tpTimeSearch As System.Windows.Forms.TabPage
    Friend WithEvents tpEmail As System.Windows.Forms.TabPage
    Friend WithEvents pbFirstImg As System.Windows.Forms.PictureBox
    Friend WithEvents ClsApplicationTypes_clsSampleNumber_strGoodInfoBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents tbPhoto As System.Windows.Forms.TabPage
    Friend WithEvents UcPhotoManager1 As Service.ucPhotoManager
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents tbPathToFolder As System.Windows.Forms.TextBox
    Friend WithEvents UserControlMC1 As Service.UserControlMC
    'Friend WithEvents UserControlEbaySearch1 As Service.UserControlEbaySearch
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents nudWorldCount As System.Windows.Forms.NumericUpDown
    Friend WithEvents tbPatternSearch As System.Windows.Forms.TextBox
    Friend WithEvents wbGoogleSearch As System.Windows.Forms.WebBrowser
    Friend WithEvents btSearchByUser As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents btResetMC As System.Windows.Forms.Button
    Friend WithEvents btCorrectInMC As System.Windows.Forms.Button
    Friend WithEvents tbGoodLocation As System.Windows.Forms.TextBox
    Friend WithEvents btSearchLocation As System.Windows.Forms.Button
    Friend WithEvents btSearchInMoySklad As System.Windows.Forms.Button
    Friend WithEvents ActualNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RetailPriceDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RetailCurrencyDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WeightDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BuyPriceDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BuyCurrencyDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvocePriceDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoceCurrencyDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LoadStatusDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rbEnglish As System.Windows.Forms.RadioButton
    Friend WithEvents rbRussian As System.Windows.Forms.RadioButton
    Friend WithEvents tpSite As System.Windows.Forms.TabPage
    Friend WithEvents Uc_nopGood1 As nopRestClient.uc_nopGood
    Friend WithEvents bs_Root As System.Windows.Forms.BindingSource
    Friend WithEvents BindingSourceClients As System.Windows.Forms.BindingSource
    Friend WithEvents UC_ebay1 As UC_ebay
    Friend WithEvents btSiteReload As System.Windows.Forms.Button
    Friend WithEvents cbSite As System.Windows.Forms.ComboBox
    Friend WithEvents Uс_trilbone_history1 As Service.Uc_trilbone_history
    Friend WithEvents Uc_mailer1 As Service.uc_mailer
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
