<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fmSampleInfo
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim CostsLabel As System.Windows.Forms.Label
        Dim RateOfExchangeLabel As System.Windows.Forms.Label
        Dim BasePriceLabel As System.Windows.Forms.Label
        Dim SoldPriceLabel As System.Windows.Forms.Label
        Me.tcSampleInfo = New System.Windows.Forms.TabControl()
        Me.tpageStatus = New System.Windows.Forms.TabPage()
        Me.btShowInBrowser = New System.Windows.Forms.Button()
        Me.btAddSource = New System.Windows.Forms.Button()
        Me.cbxRewritefile = New System.Windows.Forms.CheckBox()
        Me.gbCatalogBySkladID = New System.Windows.Forms.GroupBox()
        Me.btCreateCatalog = New System.Windows.Forms.Button()
        Me.lblMsOrder = New System.Windows.Forms.Label()
        Me.lbSampleInMCOrder = New System.Windows.Forms.ListBox()
        Me.tbMSnumber = New System.Windows.Forms.TextBox()
        Me.btGetMScatalog = New System.Windows.Forms.Button()
        Me.btCreateByTemplate = New System.Windows.Forms.Button()
        Me.cbxExtendedOutput = New System.Windows.Forms.CheckBox()
        Me.cbxRemoteConnections = New System.Windows.Forms.CheckBox()
        Me.lbCurrentCulture = New System.Windows.Forms.Label()
        Me.btUnselectAll = New System.Windows.Forms.Button()
        Me.lbLinkedSources = New System.Windows.Forms.ListBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.btAddTemplate = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cbxRepalceImages = New System.Windows.Forms.CheckBox()
        Me.btCopyByTemplate = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lbTemplates = New System.Windows.Forms.ListBox()
        Me.btSelectAll = New System.Windows.Forms.Button()
        Me.pbMainImage = New System.Windows.Forms.PictureBox()
        Me.cbSourcesList = New System.Windows.Forms.ComboBox()
        Me.btCopyToFolder = New System.Windows.Forms.Button()
        Me.rb1024Optimize = New System.Windows.Forms.RadioButton()
        Me.rb2048Optimize = New System.Windows.Forms.RadioButton()
        Me.rbNoOptimize = New System.Windows.Forms.RadioButton()
        Me.cbShowPreview = New System.Windows.Forms.CheckBox()
        Me.tbPrevievTime = New System.Windows.Forms.TextBox()
        Me.imgLwPhoto = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.tpageSold = New System.Windows.Forms.TabPage()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.CurrencyNameTextBox = New System.Windows.Forms.TextBox()
        Me.Select_tb_SamplesOnSaleBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SampleOnSale = New OrdersAndClients.SampleOnSale()
        Me.CostsTextBox = New System.Windows.Forms.TextBox()
        Me.SoldPriceTextBox = New System.Windows.Forms.TextBox()
        Me.FreeShippingPossibleFlagCheckBox = New System.Windows.Forms.CheckBox()
        Me.RateOfExchangeTextBox = New System.Windows.Forms.TextBox()
        Me.BasePriceTextBox = New System.Windows.Forms.TextBox()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.OrderIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OrderDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OrderCheckOutStatusDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.OrderStockOutStatusDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.OrderCancellationStatusDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ClientFullNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SampleConfirmStatusDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.SampleCheckOutStatusDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.RetailPriceDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OfferPriceDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OfferDiscountDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SampleConfirmPriceDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SampleShippingPriceDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CurrencyDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OnSaleFlagDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.SoldFlagDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.SampleCheckOutDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OrderStockOutDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OrderCancellationDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OrderCheckOutDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReservedFlagDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.SelectSampleOrdersInfoBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsOrders_new = New OrdersAndClients.dsOrders_new()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tpageStoreInfo = New System.Windows.Forms.TabPage()
        Me.tbSampleNumber = New System.Windows.Forms.TextBox()
        Me.btSearchInfo = New System.Windows.Forms.Button()
        Me.lbSample = New System.Windows.Forms.Label()
        Me.lbSampleStatus = New System.Windows.Forms.Label()
        Me.btAddSampleData = New System.Windows.Forms.Button()
        Me.btAddOnSale = New System.Windows.Forms.Button()
        Me.btAddImages = New System.Windows.Forms.Button()
        Me.btAddtoOrder = New System.Windows.Forms.Button()
        Me.cbOrders = New System.Windows.Forms.ComboBox()
        Me.btAcceptOrder = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btCopyNumber = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.RTBSampleData = New System.Windows.Forms.RichTextBox()
        Me.RbEnglish = New System.Windows.Forms.RadioButton()
        Me.rbRussian = New System.Windows.Forms.RadioButton()
        Me.tbName = New System.Windows.Forms.TextBox()
        Me.SelectSampleInfoBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsService = New OrdersAndClients.dsService()
        Me.btCopyName = New System.Windows.Forms.Button()
        Me.SelectFossilInfoBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Select_SampleOrdersInfoTableAdapter = New OrdersAndClients.dsOrders_newTableAdapters.Select_SampleOrdersInfoTableAdapter()
        Me.Select_tb_SamplesOnSaleTableAdapter = New OrdersAndClients.SampleOnSaleTableAdapters.Select_tb_SamplesOnSaleTableAdapter()
        Me.Select_SampleInfoTableAdapter1 = New OrdersAndClients.dsServiceTableAdapters.Select_SampleInfoTableAdapter()
        Me.SelectFossilInfoTableAdapter = New OrdersAndClients.dsServiceTableAdapters.SelectFossilInfoTableAdapter()
        Me.SamplesAndOrdersBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SamplesAndOrdersTableAdapter = New OrdersAndClients.dsOrders_newTableAdapters.SamplesAndOrdersTableAdapter()
        Me.TableAdapterManager1 = New OrdersAndClients.SampleOnSaleTableAdapters.TableAdapterManager()
        Me.DataGridViewCheckBoxColumn1 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DataGridViewCheckBoxColumn2 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.btCopyArticul = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.DataGridViewCheckBoxColumn3 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DataGridViewCheckBoxColumn4 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.DataGridViewCheckBoxColumn5 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        CostsLabel = New System.Windows.Forms.Label()
        RateOfExchangeLabel = New System.Windows.Forms.Label()
        BasePriceLabel = New System.Windows.Forms.Label()
        SoldPriceLabel = New System.Windows.Forms.Label()
        Me.tcSampleInfo.SuspendLayout()
        Me.tpageStatus.SuspendLayout()
        Me.gbCatalogBySkladID.SuspendLayout()
        CType(Me.pbMainImage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpageSold.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.Select_tb_SamplesOnSaleBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SampleOnSale, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SelectSampleOrdersInfoBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsOrders_new, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SelectSampleInfoBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsService, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SelectFossilInfoBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SamplesAndOrdersBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CostsLabel
        '
        CostsLabel.AutoSize = True
        CostsLabel.Location = New System.Drawing.Point(18, 48)
        CostsLabel.Name = "CostsLabel"
        CostsLabel.Size = New System.Drawing.Size(89, 13)
        CostsLabel.TabIndex = 19
        CostsLabel.Text = "Себестоимость:"
        '
        'RateOfExchangeLabel
        '
        RateOfExchangeLabel.AutoSize = True
        RateOfExchangeLabel.Location = New System.Drawing.Point(30, 22)
        RateOfExchangeLabel.Name = "RateOfExchangeLabel"
        RateOfExchangeLabel.Size = New System.Drawing.Size(34, 13)
        RateOfExchangeLabel.TabIndex = 25
        RateOfExchangeLabel.Text = "Курс:"
        '
        'BasePriceLabel
        '
        BasePriceLabel.AutoSize = True
        BasePriceLabel.Location = New System.Drawing.Point(35, 104)
        BasePriceLabel.Name = "BasePriceLabel"
        BasePriceLabel.Size = New System.Drawing.Size(61, 13)
        BasePriceLabel.TabIndex = 37
        BasePriceLabel.Text = "Base Price:"
        '
        'SoldPriceLabel
        '
        SoldPriceLabel.AutoSize = True
        SoldPriceLabel.Location = New System.Drawing.Point(36, 130)
        SoldPriceLabel.Name = "SoldPriceLabel"
        SoldPriceLabel.Size = New System.Drawing.Size(58, 13)
        SoldPriceLabel.TabIndex = 38
        SoldPriceLabel.Text = "Sold Price:"
        '
        'tcSampleInfo
        '
        Me.tcSampleInfo.Controls.Add(Me.tpageStatus)
        Me.tcSampleInfo.Controls.Add(Me.tpageSold)
        Me.tcSampleInfo.Controls.Add(Me.tpageStoreInfo)
        Me.tcSampleInfo.Location = New System.Drawing.Point(9, 199)
        Me.tcSampleInfo.Name = "tcSampleInfo"
        Me.tcSampleInfo.SelectedIndex = 0
        Me.tcSampleInfo.Size = New System.Drawing.Size(1041, 538)
        Me.tcSampleInfo.TabIndex = 0
        '
        'tpageStatus
        '
        Me.tpageStatus.AutoScroll = True
        Me.tpageStatus.Controls.Add(Me.btShowInBrowser)
        Me.tpageStatus.Controls.Add(Me.btAddSource)
        Me.tpageStatus.Controls.Add(Me.cbxRewritefile)
        Me.tpageStatus.Controls.Add(Me.gbCatalogBySkladID)
        Me.tpageStatus.Controls.Add(Me.cbxExtendedOutput)
        Me.tpageStatus.Controls.Add(Me.cbxRemoteConnections)
        Me.tpageStatus.Controls.Add(Me.lbCurrentCulture)
        Me.tpageStatus.Controls.Add(Me.btUnselectAll)
        Me.tpageStatus.Controls.Add(Me.lbLinkedSources)
        Me.tpageStatus.Controls.Add(Me.Label14)
        Me.tpageStatus.Controls.Add(Me.btAddTemplate)
        Me.tpageStatus.Controls.Add(Me.Label13)
        Me.tpageStatus.Controls.Add(Me.cbxRepalceImages)
        Me.tpageStatus.Controls.Add(Me.btCopyByTemplate)
        Me.tpageStatus.Controls.Add(Me.Label2)
        Me.tpageStatus.Controls.Add(Me.lbTemplates)
        Me.tpageStatus.Controls.Add(Me.btSelectAll)
        Me.tpageStatus.Controls.Add(Me.pbMainImage)
        Me.tpageStatus.Controls.Add(Me.cbSourcesList)
        Me.tpageStatus.Controls.Add(Me.btCopyToFolder)
        Me.tpageStatus.Controls.Add(Me.rb1024Optimize)
        Me.tpageStatus.Controls.Add(Me.rb2048Optimize)
        Me.tpageStatus.Controls.Add(Me.rbNoOptimize)
        Me.tpageStatus.Controls.Add(Me.cbShowPreview)
        Me.tpageStatus.Controls.Add(Me.tbPrevievTime)
        Me.tpageStatus.Controls.Add(Me.imgLwPhoto)
        Me.tpageStatus.Location = New System.Drawing.Point(4, 22)
        Me.tpageStatus.Name = "tpageStatus"
        Me.tpageStatus.Padding = New System.Windows.Forms.Padding(3)
        Me.tpageStatus.Size = New System.Drawing.Size(1033, 512)
        Me.tpageStatus.TabIndex = 0
        Me.tpageStatus.Text = "Данные"
        Me.tpageStatus.UseVisualStyleBackColor = True
        '
        'btShowInBrowser
        '
        Me.btShowInBrowser.Location = New System.Drawing.Point(220, 422)
        Me.btShowInBrowser.Name = "btShowInBrowser"
        Me.btShowInBrowser.Size = New System.Drawing.Size(160, 23)
        Me.btShowInBrowser.TabIndex = 79
        Me.btShowInBrowser.Text = "Браузер"
        Me.btShowInBrowser.UseVisualStyleBackColor = True
        '
        'btAddSource
        '
        Me.btAddSource.Location = New System.Drawing.Point(214, 289)
        Me.btAddSource.Name = "btAddSource"
        Me.btAddSource.Size = New System.Drawing.Size(113, 23)
        Me.btAddSource.TabIndex = 78
        Me.btAddSource.Text = "Добавить устр-во"
        Me.btAddSource.UseVisualStyleBackColor = True
        '
        'cbxRewritefile
        '
        Me.cbxRewritefile.AutoSize = True
        Me.cbxRewritefile.Location = New System.Drawing.Point(208, 457)
        Me.cbxRewritefile.Name = "cbxRewritefile"
        Me.cbxRewritefile.Size = New System.Drawing.Size(119, 17)
        Me.cbxRewritefile.TabIndex = 77
        Me.cbxRewritefile.Text = "переписать из БД"
        Me.cbxRewritefile.UseVisualStyleBackColor = True
        '
        'gbCatalogBySkladID
        '
        Me.gbCatalogBySkladID.Controls.Add(Me.btCreateCatalog)
        Me.gbCatalogBySkladID.Controls.Add(Me.lblMsOrder)
        Me.gbCatalogBySkladID.Controls.Add(Me.lbSampleInMCOrder)
        Me.gbCatalogBySkladID.Controls.Add(Me.tbMSnumber)
        Me.gbCatalogBySkladID.Controls.Add(Me.btGetMScatalog)
        Me.gbCatalogBySkladID.Controls.Add(Me.btCreateByTemplate)
        Me.gbCatalogBySkladID.Location = New System.Drawing.Point(11, 185)
        Me.gbCatalogBySkladID.Name = "gbCatalogBySkladID"
        Me.gbCatalogBySkladID.Size = New System.Drawing.Size(191, 251)
        Me.gbCatalogBySkladID.TabIndex = 75
        Me.gbCatalogBySkladID.TabStop = False
        Me.gbCatalogBySkladID.Text = "Каталог по номеру МС"
        '
        'btCreateCatalog
        '
        Me.btCreateCatalog.Location = New System.Drawing.Point(13, 186)
        Me.btCreateCatalog.Name = "btCreateCatalog"
        Me.btCreateCatalog.Size = New System.Drawing.Size(163, 23)
        Me.btCreateCatalog.TabIndex = 77
        Me.btCreateCatalog.Text = "Создать каталог"
        Me.btCreateCatalog.UseVisualStyleBackColor = True
        '
        'lblMsOrder
        '
        Me.lblMsOrder.AutoSize = True
        Me.lblMsOrder.Location = New System.Drawing.Point(6, 58)
        Me.lblMsOrder.Name = "lblMsOrder"
        Me.lblMsOrder.Size = New System.Drawing.Size(101, 13)
        Me.lblMsOrder.TabIndex = 76
        Me.lblMsOrder.Text = "Образцы в заказе"
        '
        'lbSampleInMCOrder
        '
        Me.lbSampleInMCOrder.FormattingEnabled = True
        Me.lbSampleInMCOrder.Location = New System.Drawing.Point(6, 75)
        Me.lbSampleInMCOrder.Name = "lbSampleInMCOrder"
        Me.lbSampleInMCOrder.Size = New System.Drawing.Size(176, 95)
        Me.lbSampleInMCOrder.TabIndex = 75
        '
        'tbMSnumber
        '
        Me.tbMSnumber.Location = New System.Drawing.Point(8, 19)
        Me.tbMSnumber.Name = "tbMSnumber"
        Me.tbMSnumber.Size = New System.Drawing.Size(80, 20)
        Me.tbMSnumber.TabIndex = 73
        '
        'btGetMScatalog
        '
        Me.btGetMScatalog.Location = New System.Drawing.Point(102, 18)
        Me.btGetMScatalog.Name = "btGetMScatalog"
        Me.btGetMScatalog.Size = New System.Drawing.Size(74, 23)
        Me.btGetMScatalog.TabIndex = 74
        Me.btGetMScatalog.Text = "запрос"
        Me.btGetMScatalog.UseVisualStyleBackColor = True
        '
        'btCreateByTemplate
        '
        Me.btCreateByTemplate.Location = New System.Drawing.Point(13, 218)
        Me.btCreateByTemplate.Name = "btCreateByTemplate"
        Me.btCreateByTemplate.Size = New System.Drawing.Size(166, 23)
        Me.btCreateByTemplate.TabIndex = 56
        Me.btCreateByTemplate.Text = "Создать файлы по шаблону.."
        Me.btCreateByTemplate.UseVisualStyleBackColor = True
        '
        'cbxExtendedOutput
        '
        Me.cbxExtendedOutput.AutoSize = True
        Me.cbxExtendedOutput.Checked = True
        Me.cbxExtendedOutput.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbxExtendedOutput.Location = New System.Drawing.Point(208, 399)
        Me.cbxExtendedOutput.Name = "cbxExtendedOutput"
        Me.cbxExtendedOutput.Size = New System.Drawing.Size(191, 17)
        Me.cbxExtendedOutput.TabIndex = 72
        Me.cbxExtendedOutput.Text = "расширенная настройка вывода"
        Me.cbxExtendedOutput.UseVisualStyleBackColor = True
        '
        'cbxRemoteConnections
        '
        Me.cbxRemoteConnections.AutoSize = True
        Me.cbxRemoteConnections.Location = New System.Drawing.Point(206, 6)
        Me.cbxRemoteConnections.Name = "cbxRemoteConnections"
        Me.cbxRemoteConnections.Size = New System.Drawing.Size(118, 17)
        Me.cbxRemoteConnections.TabIndex = 37
        Me.cbxRemoteConnections.Text = "+ удаленные фото"
        Me.cbxRemoteConnections.UseVisualStyleBackColor = True
        '
        'lbCurrentCulture
        '
        Me.lbCurrentCulture.AutoSize = True
        Me.lbCurrentCulture.Location = New System.Drawing.Point(16, 161)
        Me.lbCurrentCulture.Name = "lbCurrentCulture"
        Me.lbCurrentCulture.Size = New System.Drawing.Size(81, 13)
        Me.lbCurrentCulture.TabIndex = 61
        Me.lbCurrentCulture.Text = "Текущий язык"
        '
        'btUnselectAll
        '
        Me.btUnselectAll.Location = New System.Drawing.Point(825, 5)
        Me.btUnselectAll.Name = "btUnselectAll"
        Me.btUnselectAll.Size = New System.Drawing.Size(100, 23)
        Me.btUnselectAll.TabIndex = 60
        Me.btUnselectAll.Text = "снять все"
        Me.btUnselectAll.UseVisualStyleBackColor = True
        '
        'lbLinkedSources
        '
        Me.lbLinkedSources.FormattingEnabled = True
        Me.lbLinkedSources.Location = New System.Drawing.Point(214, 226)
        Me.lbLinkedSources.Name = "lbLinkedSources"
        Me.lbLinkedSources.Size = New System.Drawing.Size(148, 56)
        Me.lbLinkedSources.TabIndex = 59
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(217, 24)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(124, 13)
        Me.Label14.TabIndex = 58
        Me.Label14.Text = "показано с устройства"
        '
        'btAddTemplate
        '
        Me.btAddTemplate.Enabled = False
        Me.btAddTemplate.Location = New System.Drawing.Point(10, 130)
        Me.btAddTemplate.Name = "btAddTemplate"
        Me.btAddTemplate.Size = New System.Drawing.Size(114, 23)
        Me.btAddTemplate.TabIndex = 57
        Me.btAddTemplate.Text = "Добавить шаблон"
        Me.btAddTemplate.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Enabled = False
        Me.Label13.Location = New System.Drawing.Point(213, 183)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(146, 39)
        Me.Label13.TabIndex = 55
        Me.Label13.Text = "доступные устройства" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(фото будут скопированы," & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " если их нет на устройстве)"
        '
        'cbxRepalceImages
        '
        Me.cbxRepalceImages.AutoSize = True
        Me.cbxRepalceImages.Enabled = False
        Me.cbxRepalceImages.Location = New System.Drawing.Point(214, 347)
        Me.cbxRepalceImages.Name = "cbxRepalceImages"
        Me.cbxRepalceImages.Size = New System.Drawing.Size(179, 17)
        Me.cbxRepalceImages.TabIndex = 53
        Me.cbxRepalceImages.Text = "Заменить фото на устройстве"
        Me.cbxRepalceImages.UseVisualStyleBackColor = True
        '
        'btCopyByTemplate
        '
        Me.btCopyByTemplate.Enabled = False
        Me.btCopyByTemplate.Location = New System.Drawing.Point(214, 370)
        Me.btCopyByTemplate.Name = "btCopyByTemplate"
        Me.btCopyByTemplate.Size = New System.Drawing.Size(166, 23)
        Me.btCopyByTemplate.TabIndex = 52
        Me.btCopyByTemplate.Text = "Изменить/создать XML"
        Me.btCopyByTemplate.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Enabled = False
        Me.Label2.Location = New System.Drawing.Point(14, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(110, 13)
        Me.Label2.TabIndex = 51
        Me.Label2.Text = "доступные шаблоны"
        '
        'lbTemplates
        '
        Me.lbTemplates.Enabled = False
        Me.lbTemplates.FormattingEnabled = True
        Me.lbTemplates.Location = New System.Drawing.Point(11, 26)
        Me.lbTemplates.Name = "lbTemplates"
        Me.lbTemplates.Size = New System.Drawing.Size(184, 95)
        Me.lbTemplates.TabIndex = 50
        '
        'btSelectAll
        '
        Me.btSelectAll.Location = New System.Drawing.Point(932, 5)
        Me.btSelectAll.Name = "btSelectAll"
        Me.btSelectAll.Size = New System.Drawing.Size(95, 23)
        Me.btSelectAll.TabIndex = 49
        Me.btSelectAll.Text = "выделить все"
        Me.btSelectAll.UseVisualStyleBackColor = True
        '
        'pbMainImage
        '
        Me.pbMainImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbMainImage.Location = New System.Drawing.Point(222, 68)
        Me.pbMainImage.Name = "pbMainImage"
        Me.pbMainImage.Size = New System.Drawing.Size(140, 106)
        Me.pbMainImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbMainImage.TabIndex = 48
        Me.pbMainImage.TabStop = False
        '
        'cbSourcesList
        '
        Me.cbSourcesList.FormattingEnabled = True
        Me.cbSourcesList.Location = New System.Drawing.Point(214, 41)
        Me.cbSourcesList.Name = "cbSourcesList"
        Me.cbSourcesList.Size = New System.Drawing.Size(166, 21)
        Me.cbSourcesList.TabIndex = 47
        '
        'btCopyToFolder
        '
        Me.btCopyToFolder.Location = New System.Drawing.Point(214, 318)
        Me.btCopyToFolder.Name = "btCopyToFolder"
        Me.btCopyToFolder.Size = New System.Drawing.Size(166, 23)
        Me.btCopyToFolder.TabIndex = 46
        Me.btCopyToFolder.Text = "Скопировать фото.."
        Me.btCopyToFolder.UseVisualStyleBackColor = True
        '
        'rb1024Optimize
        '
        Me.rb1024Optimize.AutoSize = True
        Me.rb1024Optimize.Location = New System.Drawing.Point(763, 8)
        Me.rb1024Optimize.Name = "rb1024Optimize"
        Me.rb1024Optimize.Size = New System.Drawing.Size(49, 17)
        Me.rb1024Optimize.TabIndex = 45
        Me.rb1024Optimize.Text = "1024"
        Me.rb1024Optimize.UseVisualStyleBackColor = True
        '
        'rb2048Optimize
        '
        Me.rb2048Optimize.AutoSize = True
        Me.rb2048Optimize.Location = New System.Drawing.Point(708, 8)
        Me.rb2048Optimize.Name = "rb2048Optimize"
        Me.rb2048Optimize.Size = New System.Drawing.Size(49, 17)
        Me.rb2048Optimize.TabIndex = 44
        Me.rb2048Optimize.Text = "2048"
        Me.rb2048Optimize.UseVisualStyleBackColor = True
        '
        'rbNoOptimize
        '
        Me.rbNoOptimize.AutoSize = True
        Me.rbNoOptimize.Checked = True
        Me.rbNoOptimize.Location = New System.Drawing.Point(589, 8)
        Me.rbNoOptimize.Name = "rbNoOptimize"
        Me.rbNoOptimize.Size = New System.Drawing.Size(113, 17)
        Me.rbNoOptimize.TabIndex = 43
        Me.rbNoOptimize.TabStop = True
        Me.rbNoOptimize.Text = "без оптимизации"
        Me.rbNoOptimize.UseVisualStyleBackColor = True
        '
        'cbShowPreview
        '
        Me.cbShowPreview.AutoSize = True
        Me.cbShowPreview.Location = New System.Drawing.Point(462, 10)
        Me.cbShowPreview.Name = "cbShowPreview"
        Me.cbShowPreview.Size = New System.Drawing.Size(75, 17)
        Me.cbShowPreview.TabIndex = 36
        Me.cbShowPreview.Text = "просмотр"
        Me.cbShowPreview.UseVisualStyleBackColor = True
        '
        'tbPrevievTime
        '
        Me.tbPrevievTime.Location = New System.Drawing.Point(553, 8)
        Me.tbPrevievTime.Name = "tbPrevievTime"
        Me.tbPrevievTime.Size = New System.Drawing.Size(23, 20)
        Me.tbPrevievTime.TabIndex = 35
        Me.tbPrevievTime.Text = "1"
        '
        'imgLwPhoto
        '
        Me.imgLwPhoto.CheckBoxes = True
        Me.imgLwPhoto.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3})
        Me.imgLwPhoto.Location = New System.Drawing.Point(414, 34)
        Me.imgLwPhoto.Name = "imgLwPhoto"
        Me.imgLwPhoto.Size = New System.Drawing.Size(613, 466)
        Me.imgLwPhoto.TabIndex = 1
        Me.imgLwPhoto.UseCompatibleStateImageBehavior = False
        '
        'tpageSold
        '
        Me.tpageSold.Controls.Add(Me.GroupBox2)
        Me.tpageSold.Controls.Add(Me.DataGridView2)
        Me.tpageSold.Controls.Add(Me.Label1)
        Me.tpageSold.Controls.Add(Me.Label3)
        Me.tpageSold.Controls.Add(Me.Label4)
        Me.tpageSold.Controls.Add(Me.Label9)
        Me.tpageSold.Controls.Add(Me.Label6)
        Me.tpageSold.Location = New System.Drawing.Point(4, 22)
        Me.tpageSold.Name = "tpageSold"
        Me.tpageSold.Padding = New System.Windows.Forms.Padding(3)
        Me.tpageSold.Size = New System.Drawing.Size(1033, 512)
        Me.tpageSold.TabIndex = 2
        Me.tpageSold.Text = "Продажа"
        Me.tpageSold.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.CurrencyNameTextBox)
        Me.GroupBox2.Controls.Add(Me.CostsTextBox)
        Me.GroupBox2.Controls.Add(SoldPriceLabel)
        Me.GroupBox2.Controls.Add(CostsLabel)
        Me.GroupBox2.Controls.Add(Me.SoldPriceTextBox)
        Me.GroupBox2.Controls.Add(Me.FreeShippingPossibleFlagCheckBox)
        Me.GroupBox2.Controls.Add(BasePriceLabel)
        Me.GroupBox2.Controls.Add(Me.RateOfExchangeTextBox)
        Me.GroupBox2.Controls.Add(Me.BasePriceTextBox)
        Me.GroupBox2.Controls.Add(RateOfExchangeLabel)
        Me.GroupBox2.Location = New System.Drawing.Point(7, 269)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(200, 152)
        Me.GroupBox2.TabIndex = 41
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "цены"
        '
        'CurrencyNameTextBox
        '
        Me.CurrencyNameTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Select_tb_SamplesOnSaleBindingSource, "CurrencyName", True))
        Me.CurrencyNameTextBox.Enabled = False
        Me.CurrencyNameTextBox.Location = New System.Drawing.Point(128, 19)
        Me.CurrencyNameTextBox.Name = "CurrencyNameTextBox"
        Me.CurrencyNameTextBox.Size = New System.Drawing.Size(49, 20)
        Me.CurrencyNameTextBox.TabIndex = 25
        '
        'Select_tb_SamplesOnSaleBindingSource
        '
        Me.Select_tb_SamplesOnSaleBindingSource.DataMember = "Select_tb_SamplesOnSale"
        Me.Select_tb_SamplesOnSaleBindingSource.DataSource = Me.SampleOnSale
        '
        'SampleOnSale
        '
        Me.SampleOnSale.DataSetName = "SampleOnSale"
        Me.SampleOnSale.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'CostsTextBox
        '
        Me.CostsTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Select_tb_SamplesOnSaleBindingSource, "Costs", True))
        Me.CostsTextBox.Enabled = False
        Me.CostsTextBox.Location = New System.Drawing.Point(113, 45)
        Me.CostsTextBox.Name = "CostsTextBox"
        Me.CostsTextBox.Size = New System.Drawing.Size(64, 20)
        Me.CostsTextBox.TabIndex = 20
        '
        'SoldPriceTextBox
        '
        Me.SoldPriceTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Select_tb_SamplesOnSaleBindingSource, "SoldPrice", True))
        Me.SoldPriceTextBox.Location = New System.Drawing.Point(114, 127)
        Me.SoldPriceTextBox.Name = "SoldPriceTextBox"
        Me.SoldPriceTextBox.Size = New System.Drawing.Size(63, 20)
        Me.SoldPriceTextBox.TabIndex = 39
        '
        'FreeShippingPossibleFlagCheckBox
        '
        Me.FreeShippingPossibleFlagCheckBox.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.Select_tb_SamplesOnSaleBindingSource, "FreeShippingPossibleFlag", True))
        Me.FreeShippingPossibleFlagCheckBox.Enabled = False
        Me.FreeShippingPossibleFlagCheckBox.Location = New System.Drawing.Point(39, 71)
        Me.FreeShippingPossibleFlagCheckBox.Name = "FreeShippingPossibleFlagCheckBox"
        Me.FreeShippingPossibleFlagCheckBox.Size = New System.Drawing.Size(158, 24)
        Me.FreeShippingPossibleFlagCheckBox.TabIndex = 24
        Me.FreeShippingPossibleFlagCheckBox.Text = "Free Shipping возможен"
        Me.FreeShippingPossibleFlagCheckBox.UseVisualStyleBackColor = True
        '
        'RateOfExchangeTextBox
        '
        Me.RateOfExchangeTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Select_tb_SamplesOnSaleBindingSource, "RateOfExchange", True))
        Me.RateOfExchangeTextBox.Enabled = False
        Me.RateOfExchangeTextBox.Location = New System.Drawing.Point(70, 19)
        Me.RateOfExchangeTextBox.Name = "RateOfExchangeTextBox"
        Me.RateOfExchangeTextBox.Size = New System.Drawing.Size(49, 20)
        Me.RateOfExchangeTextBox.TabIndex = 26
        '
        'BasePriceTextBox
        '
        Me.BasePriceTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Select_tb_SamplesOnSaleBindingSource, "BasePrice", True))
        Me.BasePriceTextBox.Location = New System.Drawing.Point(113, 101)
        Me.BasePriceTextBox.Name = "BasePriceTextBox"
        Me.BasePriceTextBox.Size = New System.Drawing.Size(64, 20)
        Me.BasePriceTextBox.TabIndex = 38
        '
        'DataGridView2
        '
        Me.DataGridView2.AllowUserToAddRows = False
        Me.DataGridView2.AllowUserToDeleteRows = False
        Me.DataGridView2.AutoGenerateColumns = False
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.OrderIDDataGridViewTextBoxColumn, Me.OrderDateDataGridViewTextBoxColumn, Me.OrderCheckOutStatusDataGridViewCheckBoxColumn, Me.OrderStockOutStatusDataGridViewCheckBoxColumn, Me.OrderCancellationStatusDataGridViewCheckBoxColumn, Me.ClientFullNameDataGridViewTextBoxColumn, Me.SampleConfirmStatusDataGridViewCheckBoxColumn, Me.SampleCheckOutStatusDataGridViewCheckBoxColumn, Me.RetailPriceDataGridViewTextBoxColumn, Me.OfferPriceDataGridViewTextBoxColumn, Me.OfferDiscountDataGridViewTextBoxColumn, Me.SampleConfirmPriceDataGridViewTextBoxColumn, Me.SampleShippingPriceDataGridViewTextBoxColumn, Me.CurrencyDataGridViewTextBoxColumn, Me.OnSaleFlagDataGridViewCheckBoxColumn, Me.SoldFlagDataGridViewCheckBoxColumn, Me.SampleCheckOutDateDataGridViewTextBoxColumn, Me.OrderStockOutDateDataGridViewTextBoxColumn, Me.OrderCancellationDateDataGridViewTextBoxColumn, Me.OrderCheckOutDateDataGridViewTextBoxColumn, Me.ReservedFlagDataGridViewCheckBoxColumn})
        Me.DataGridView2.DataSource = Me.SelectSampleOrdersInfoBindingSource
        Me.DataGridView2.Location = New System.Drawing.Point(6, 6)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.ReadOnly = True
        Me.DataGridView2.Size = New System.Drawing.Size(1002, 235)
        Me.DataGridView2.TabIndex = 0
        '
        'OrderIDDataGridViewTextBoxColumn
        '
        Me.OrderIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.OrderIDDataGridViewTextBoxColumn.DataPropertyName = "OrderID"
        Me.OrderIDDataGridViewTextBoxColumn.HeaderText = "OrderID"
        Me.OrderIDDataGridViewTextBoxColumn.Name = "OrderIDDataGridViewTextBoxColumn"
        Me.OrderIDDataGridViewTextBoxColumn.ReadOnly = True
        Me.OrderIDDataGridViewTextBoxColumn.Width = 69
        '
        'OrderDateDataGridViewTextBoxColumn
        '
        Me.OrderDateDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.OrderDateDataGridViewTextBoxColumn.DataPropertyName = "OrderDate"
        Me.OrderDateDataGridViewTextBoxColumn.HeaderText = "OrderDate"
        Me.OrderDateDataGridViewTextBoxColumn.Name = "OrderDateDataGridViewTextBoxColumn"
        Me.OrderDateDataGridViewTextBoxColumn.ReadOnly = True
        Me.OrderDateDataGridViewTextBoxColumn.Width = 81
        '
        'OrderCheckOutStatusDataGridViewCheckBoxColumn
        '
        Me.OrderCheckOutStatusDataGridViewCheckBoxColumn.DataPropertyName = "Order CheckOut Status"
        Me.OrderCheckOutStatusDataGridViewCheckBoxColumn.HeaderText = "Order CheckOut"
        Me.OrderCheckOutStatusDataGridViewCheckBoxColumn.Name = "OrderCheckOutStatusDataGridViewCheckBoxColumn"
        Me.OrderCheckOutStatusDataGridViewCheckBoxColumn.ReadOnly = True
        Me.OrderCheckOutStatusDataGridViewCheckBoxColumn.Width = 50
        '
        'OrderStockOutStatusDataGridViewCheckBoxColumn
        '
        Me.OrderStockOutStatusDataGridViewCheckBoxColumn.DataPropertyName = "Order StockOut Status"
        Me.OrderStockOutStatusDataGridViewCheckBoxColumn.HeaderText = "Order StockOut"
        Me.OrderStockOutStatusDataGridViewCheckBoxColumn.Name = "OrderStockOutStatusDataGridViewCheckBoxColumn"
        Me.OrderStockOutStatusDataGridViewCheckBoxColumn.ReadOnly = True
        Me.OrderStockOutStatusDataGridViewCheckBoxColumn.Width = 50
        '
        'OrderCancellationStatusDataGridViewCheckBoxColumn
        '
        Me.OrderCancellationStatusDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.OrderCancellationStatusDataGridViewCheckBoxColumn.DataPropertyName = "Order Cancellation Status"
        Me.OrderCancellationStatusDataGridViewCheckBoxColumn.HeaderText = "Order Cancellation"
        Me.OrderCancellationStatusDataGridViewCheckBoxColumn.Name = "OrderCancellationStatusDataGridViewCheckBoxColumn"
        Me.OrderCancellationStatusDataGridViewCheckBoxColumn.ReadOnly = True
        Me.OrderCancellationStatusDataGridViewCheckBoxColumn.Width = 50
        '
        'ClientFullNameDataGridViewTextBoxColumn
        '
        Me.ClientFullNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.ClientFullNameDataGridViewTextBoxColumn.DataPropertyName = "Client full name"
        Me.ClientFullNameDataGridViewTextBoxColumn.HeaderText = "Client full name"
        Me.ClientFullNameDataGridViewTextBoxColumn.Name = "ClientFullNameDataGridViewTextBoxColumn"
        Me.ClientFullNameDataGridViewTextBoxColumn.ReadOnly = True
        Me.ClientFullNameDataGridViewTextBoxColumn.Width = 95
        '
        'SampleConfirmStatusDataGridViewCheckBoxColumn
        '
        Me.SampleConfirmStatusDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.SampleConfirmStatusDataGridViewCheckBoxColumn.DataPropertyName = "Sample Confirm Status"
        Me.SampleConfirmStatusDataGridViewCheckBoxColumn.HeaderText = "Sample Confirm"
        Me.SampleConfirmStatusDataGridViewCheckBoxColumn.Name = "SampleConfirmStatusDataGridViewCheckBoxColumn"
        Me.SampleConfirmStatusDataGridViewCheckBoxColumn.ReadOnly = True
        Me.SampleConfirmStatusDataGridViewCheckBoxColumn.Width = 77
        '
        'SampleCheckOutStatusDataGridViewCheckBoxColumn
        '
        Me.SampleCheckOutStatusDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.SampleCheckOutStatusDataGridViewCheckBoxColumn.DataPropertyName = "Sample CheckOut Status"
        Me.SampleCheckOutStatusDataGridViewCheckBoxColumn.HeaderText = "Sample CheckOut"
        Me.SampleCheckOutStatusDataGridViewCheckBoxColumn.Name = "SampleCheckOutStatusDataGridViewCheckBoxColumn"
        Me.SampleCheckOutStatusDataGridViewCheckBoxColumn.ReadOnly = True
        Me.SampleCheckOutStatusDataGridViewCheckBoxColumn.Width = 89
        '
        'RetailPriceDataGridViewTextBoxColumn
        '
        Me.RetailPriceDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.RetailPriceDataGridViewTextBoxColumn.DataPropertyName = "Retail price"
        Me.RetailPriceDataGridViewTextBoxColumn.HeaderText = "Retail price"
        Me.RetailPriceDataGridViewTextBoxColumn.Name = "RetailPriceDataGridViewTextBoxColumn"
        Me.RetailPriceDataGridViewTextBoxColumn.ReadOnly = True
        Me.RetailPriceDataGridViewTextBoxColumn.Width = 78
        '
        'OfferPriceDataGridViewTextBoxColumn
        '
        Me.OfferPriceDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.OfferPriceDataGridViewTextBoxColumn.DataPropertyName = "Offer Price"
        Me.OfferPriceDataGridViewTextBoxColumn.HeaderText = "Offer Price"
        Me.OfferPriceDataGridViewTextBoxColumn.Name = "OfferPriceDataGridViewTextBoxColumn"
        Me.OfferPriceDataGridViewTextBoxColumn.ReadOnly = True
        Me.OfferPriceDataGridViewTextBoxColumn.Width = 76
        '
        'OfferDiscountDataGridViewTextBoxColumn
        '
        Me.OfferDiscountDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.OfferDiscountDataGridViewTextBoxColumn.DataPropertyName = "Offer Discount"
        Me.OfferDiscountDataGridViewTextBoxColumn.HeaderText = "Offer Discount"
        Me.OfferDiscountDataGridViewTextBoxColumn.Name = "OfferDiscountDataGridViewTextBoxColumn"
        Me.OfferDiscountDataGridViewTextBoxColumn.ReadOnly = True
        Me.OfferDiscountDataGridViewTextBoxColumn.Width = 92
        '
        'SampleConfirmPriceDataGridViewTextBoxColumn
        '
        Me.SampleConfirmPriceDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.SampleConfirmPriceDataGridViewTextBoxColumn.DataPropertyName = "Sample Confirm Price"
        Me.SampleConfirmPriceDataGridViewTextBoxColumn.HeaderText = "Sample Confirm Price"
        Me.SampleConfirmPriceDataGridViewTextBoxColumn.Name = "SampleConfirmPriceDataGridViewTextBoxColumn"
        Me.SampleConfirmPriceDataGridViewTextBoxColumn.ReadOnly = True
        Me.SampleConfirmPriceDataGridViewTextBoxColumn.Width = 99
        '
        'SampleShippingPriceDataGridViewTextBoxColumn
        '
        Me.SampleShippingPriceDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.SampleShippingPriceDataGridViewTextBoxColumn.DataPropertyName = "Sample shipping price"
        Me.SampleShippingPriceDataGridViewTextBoxColumn.HeaderText = "Sample shipping price"
        Me.SampleShippingPriceDataGridViewTextBoxColumn.Name = "SampleShippingPriceDataGridViewTextBoxColumn"
        Me.SampleShippingPriceDataGridViewTextBoxColumn.ReadOnly = True
        Me.SampleShippingPriceDataGridViewTextBoxColumn.Width = 103
        '
        'CurrencyDataGridViewTextBoxColumn
        '
        Me.CurrencyDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.CurrencyDataGridViewTextBoxColumn.DataPropertyName = "Currency"
        Me.CurrencyDataGridViewTextBoxColumn.HeaderText = "Currency"
        Me.CurrencyDataGridViewTextBoxColumn.Name = "CurrencyDataGridViewTextBoxColumn"
        Me.CurrencyDataGridViewTextBoxColumn.ReadOnly = True
        Me.CurrencyDataGridViewTextBoxColumn.Width = 74
        '
        'OnSaleFlagDataGridViewCheckBoxColumn
        '
        Me.OnSaleFlagDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.OnSaleFlagDataGridViewCheckBoxColumn.DataPropertyName = "OnSaleFlag"
        Me.OnSaleFlagDataGridViewCheckBoxColumn.HeaderText = "OnSaleFlag"
        Me.OnSaleFlagDataGridViewCheckBoxColumn.Name = "OnSaleFlagDataGridViewCheckBoxColumn"
        Me.OnSaleFlagDataGridViewCheckBoxColumn.ReadOnly = True
        Me.OnSaleFlagDataGridViewCheckBoxColumn.Width = 68
        '
        'SoldFlagDataGridViewCheckBoxColumn
        '
        Me.SoldFlagDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.SoldFlagDataGridViewCheckBoxColumn.DataPropertyName = "SoldFlag"
        Me.SoldFlagDataGridViewCheckBoxColumn.HeaderText = "SoldFlag"
        Me.SoldFlagDataGridViewCheckBoxColumn.Name = "SoldFlagDataGridViewCheckBoxColumn"
        Me.SoldFlagDataGridViewCheckBoxColumn.ReadOnly = True
        Me.SoldFlagDataGridViewCheckBoxColumn.Width = 54
        '
        'SampleCheckOutDateDataGridViewTextBoxColumn
        '
        Me.SampleCheckOutDateDataGridViewTextBoxColumn.DataPropertyName = "Sample CheckOut Date"
        Me.SampleCheckOutDateDataGridViewTextBoxColumn.HeaderText = "Sample CheckOut Date"
        Me.SampleCheckOutDateDataGridViewTextBoxColumn.Name = "SampleCheckOutDateDataGridViewTextBoxColumn"
        Me.SampleCheckOutDateDataGridViewTextBoxColumn.ReadOnly = True
        '
        'OrderStockOutDateDataGridViewTextBoxColumn
        '
        Me.OrderStockOutDateDataGridViewTextBoxColumn.DataPropertyName = "Order StockOut Date"
        Me.OrderStockOutDateDataGridViewTextBoxColumn.HeaderText = "Order StockOut Date"
        Me.OrderStockOutDateDataGridViewTextBoxColumn.Name = "OrderStockOutDateDataGridViewTextBoxColumn"
        Me.OrderStockOutDateDataGridViewTextBoxColumn.ReadOnly = True
        '
        'OrderCancellationDateDataGridViewTextBoxColumn
        '
        Me.OrderCancellationDateDataGridViewTextBoxColumn.DataPropertyName = "Order Cancellation Date"
        Me.OrderCancellationDateDataGridViewTextBoxColumn.HeaderText = "Order Cancellation Date"
        Me.OrderCancellationDateDataGridViewTextBoxColumn.Name = "OrderCancellationDateDataGridViewTextBoxColumn"
        Me.OrderCancellationDateDataGridViewTextBoxColumn.ReadOnly = True
        '
        'OrderCheckOutDateDataGridViewTextBoxColumn
        '
        Me.OrderCheckOutDateDataGridViewTextBoxColumn.DataPropertyName = "Order CheckOut Date"
        Me.OrderCheckOutDateDataGridViewTextBoxColumn.HeaderText = "Order CheckOut Date"
        Me.OrderCheckOutDateDataGridViewTextBoxColumn.Name = "OrderCheckOutDateDataGridViewTextBoxColumn"
        Me.OrderCheckOutDateDataGridViewTextBoxColumn.ReadOnly = True
        '
        'ReservedFlagDataGridViewCheckBoxColumn
        '
        Me.ReservedFlagDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.ReservedFlagDataGridViewCheckBoxColumn.DataPropertyName = "ReservedFlag"
        Me.ReservedFlagDataGridViewCheckBoxColumn.HeaderText = "ReservedFlag"
        Me.ReservedFlagDataGridViewCheckBoxColumn.Name = "ReservedFlagDataGridViewCheckBoxColumn"
        Me.ReservedFlagDataGridViewCheckBoxColumn.ReadOnly = True
        Me.ReservedFlagDataGridViewCheckBoxColumn.Width = 79
        '
        'SelectSampleOrdersInfoBindingSource
        '
        Me.SelectSampleOrdersInfoBindingSource.DataMember = "Select_SampleOrdersInfo"
        Me.SelectSampleOrdersInfoBindingSource.DataSource = Me.DsOrders_new
        '
        'DsOrders_new
        '
        Me.DsOrders_new.DataSetName = "dsOrders_new"
        Me.DsOrders_new.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(103, 244)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 13)
        Me.Label1.TabIndex = 29
        Me.Label1.Text = "Error: check offer"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(4, 244)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(75, 13)
        Me.Label3.TabIndex = 28
        Me.Label3.Text = "предложения"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Orange
        Me.Label4.Location = New System.Drawing.Point(215, 244)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(136, 13)
        Me.Label4.TabIndex = 30
        Me.Label4.Text = "Error: check sample in offer"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Green
        Me.Label9.Location = New System.Drawing.Point(374, 244)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(50, 13)
        Me.Label9.TabIndex = 34
        Me.Label9.Text = "complete"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Blue
        Me.Label6.Location = New System.Drawing.Point(447, 244)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(84, 13)
        Me.Label6.TabIndex = 32
        Me.Label6.Text = "sample reserved"
        '
        'tpageStoreInfo
        '
        Me.tpageStoreInfo.Location = New System.Drawing.Point(4, 22)
        Me.tpageStoreInfo.Name = "tpageStoreInfo"
        Me.tpageStoreInfo.Padding = New System.Windows.Forms.Padding(3)
        Me.tpageStoreInfo.Size = New System.Drawing.Size(1033, 512)
        Me.tpageStoreInfo.TabIndex = 4
        Me.tpageStoreInfo.Text = "Склад"
        Me.tpageStoreInfo.UseVisualStyleBackColor = True
        '
        'tbSampleNumber
        '
        Me.tbSampleNumber.Location = New System.Drawing.Point(68, 13)
        Me.tbSampleNumber.Name = "tbSampleNumber"
        Me.tbSampleNumber.Size = New System.Drawing.Size(118, 20)
        Me.tbSampleNumber.TabIndex = 1
        '
        'btSearchInfo
        '
        Me.btSearchInfo.Location = New System.Drawing.Point(197, 12)
        Me.btSearchInfo.Name = "btSearchInfo"
        Me.btSearchInfo.Size = New System.Drawing.Size(64, 23)
        Me.btSearchInfo.TabIndex = 2
        Me.btSearchInfo.Text = "поиск.."
        Me.btSearchInfo.UseVisualStyleBackColor = True
        '
        'lbSample
        '
        Me.lbSample.AutoSize = True
        Me.lbSample.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbSample.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lbSample.Location = New System.Drawing.Point(9, 43)
        Me.lbSample.Name = "lbSample"
        Me.lbSample.Size = New System.Drawing.Size(119, 19)
        Me.lbSample.TabIndex = 3
        Me.lbSample.Text = "Текущий статус:"
        '
        'lbSampleStatus
        '
        Me.lbSampleStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbSampleStatus.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbSampleStatus.Location = New System.Drawing.Point(10, 101)
        Me.lbSampleStatus.Name = "lbSampleStatus"
        Me.lbSampleStatus.Size = New System.Drawing.Size(1036, 41)
        Me.lbSampleStatus.TabIndex = 4
        Me.lbSampleStatus.Text = "нет данных"
        '
        'btAddSampleData
        '
        Me.btAddSampleData.Location = New System.Drawing.Point(514, 40)
        Me.btAddSampleData.Name = "btAddSampleData"
        Me.btAddSampleData.Size = New System.Drawing.Size(75, 23)
        Me.btAddSampleData.TabIndex = 5
        Me.btAddSampleData.Text = "Данные.."
        Me.btAddSampleData.UseVisualStyleBackColor = True
        '
        'btAddOnSale
        '
        Me.btAddOnSale.Location = New System.Drawing.Point(595, 40)
        Me.btAddOnSale.Name = "btAddOnSale"
        Me.btAddOnSale.Size = New System.Drawing.Size(86, 23)
        Me.btAddOnSale.TabIndex = 6
        Me.btAddOnSale.Text = "На продажу.."
        Me.btAddOnSale.UseVisualStyleBackColor = True
        '
        'btAddImages
        '
        Me.btAddImages.Location = New System.Drawing.Point(687, 40)
        Me.btAddImages.Name = "btAddImages"
        Me.btAddImages.Size = New System.Drawing.Size(75, 23)
        Me.btAddImages.TabIndex = 7
        Me.btAddImages.Text = "Фото.."
        Me.btAddImages.UseVisualStyleBackColor = True
        '
        'btAddtoOrder
        '
        Me.btAddtoOrder.Location = New System.Drawing.Point(776, 40)
        Me.btAddtoOrder.Name = "btAddtoOrder"
        Me.btAddtoOrder.Size = New System.Drawing.Size(93, 23)
        Me.btAddtoOrder.TabIndex = 8
        Me.btAddtoOrder.Text = "предложить.."
        Me.btAddtoOrder.UseVisualStyleBackColor = True
        '
        'cbOrders
        '
        Me.cbOrders.FormattingEnabled = True
        Me.cbOrders.Location = New System.Drawing.Point(776, 69)
        Me.cbOrders.Name = "cbOrders"
        Me.cbOrders.Size = New System.Drawing.Size(245, 21)
        Me.cbOrders.TabIndex = 10
        Me.cbOrders.Visible = False
        '
        'btAcceptOrder
        '
        Me.btAcceptOrder.Location = New System.Drawing.Point(875, 40)
        Me.btAcceptOrder.Name = "btAcceptOrder"
        Me.btAcceptOrder.Size = New System.Drawing.Size(146, 23)
        Me.btAcceptOrder.TabIndex = 11
        Me.btAcceptOrder.Text = "добавить в.."
        Me.btAcceptOrder.UseVisualStyleBackColor = True
        Me.btAcceptOrder.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Green
        Me.Label5.Location = New System.Drawing.Point(773, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(74, 13)
        Me.Label5.TabIndex = 31
        Me.Label5.Text = "data complete"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Red
        Me.Label7.Location = New System.Drawing.Point(602, 9)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(83, 13)
        Me.Label7.TabIndex = 33
        Me.Label7.Text = "Error: enter data"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Orange
        Me.Label8.Location = New System.Drawing.Point(691, 9)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(76, 13)
        Me.Label8.TabIndex = 33
        Me.Label8.Text = "Error: half data"
        '
        'btCopyNumber
        '
        Me.btCopyNumber.Location = New System.Drawing.Point(277, 43)
        Me.btCopyNumber.Name = "btCopyNumber"
        Me.btCopyNumber.Size = New System.Drawing.Size(137, 23)
        Me.btCopyNumber.TabIndex = 34
        Me.btCopyNumber.Text = "Копировать EAN font"
        Me.btCopyNumber.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'RTBSampleData
        '
        Me.RTBSampleData.Location = New System.Drawing.Point(9, 146)
        Me.RTBSampleData.Name = "RTBSampleData"
        Me.RTBSampleData.Size = New System.Drawing.Size(939, 47)
        Me.RTBSampleData.TabIndex = 36
        Me.RTBSampleData.Text = ""
        '
        'RbEnglish
        '
        Me.RbEnglish.AutoSize = True
        Me.RbEnglish.Checked = True
        Me.RbEnglish.Location = New System.Drawing.Point(963, 146)
        Me.RbEnglish.Name = "RbEnglish"
        Me.RbEnglish.Size = New System.Drawing.Size(59, 17)
        Me.RbEnglish.TabIndex = 38
        Me.RbEnglish.TabStop = True
        Me.RbEnglish.Text = "English"
        Me.RbEnglish.UseVisualStyleBackColor = True
        '
        'rbRussian
        '
        Me.rbRussian.AutoSize = True
        Me.rbRussian.Location = New System.Drawing.Point(963, 169)
        Me.rbRussian.Name = "rbRussian"
        Me.rbRussian.Size = New System.Drawing.Size(67, 17)
        Me.rbRussian.TabIndex = 39
        Me.rbRussian.Text = "Русский"
        Me.rbRussian.UseVisualStyleBackColor = True
        '
        'tbName
        '
        Me.tbName.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.SelectSampleInfoBindingSource, "Sample_main_species", True))
        Me.tbName.Location = New System.Drawing.Point(277, 14)
        Me.tbName.Name = "tbName"
        Me.tbName.Size = New System.Drawing.Size(312, 20)
        Me.tbName.TabIndex = 40
        '
        'SelectSampleInfoBindingSource
        '
        Me.SelectSampleInfoBindingSource.DataMember = "Select_SampleInfo"
        Me.SelectSampleInfoBindingSource.DataSource = Me.DsService
        '
        'DsService
        '
        Me.DsService.DataSetName = "dsService"
        Me.DsService.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'btCopyName
        '
        Me.btCopyName.Location = New System.Drawing.Point(277, 72)
        Me.btCopyName.Name = "btCopyName"
        Me.btCopyName.Size = New System.Drawing.Size(137, 23)
        Me.btCopyName.TabIndex = 41
        Me.btCopyName.Text = "Копировать имя"
        Me.btCopyName.UseVisualStyleBackColor = True
        '
        'SelectFossilInfoBindingSource
        '
        Me.SelectFossilInfoBindingSource.DataMember = "SelectFossilInfo"
        Me.SelectFossilInfoBindingSource.DataSource = Me.DsService
        '
        'Select_SampleOrdersInfoTableAdapter
        '
        Me.Select_SampleOrdersInfoTableAdapter.ClearBeforeFill = True
        '
        'Select_tb_SamplesOnSaleTableAdapter
        '
        Me.Select_tb_SamplesOnSaleTableAdapter.ClearBeforeFill = True
        '
        'Select_SampleInfoTableAdapter1
        '
        Me.Select_SampleInfoTableAdapter1.ClearBeforeFill = True
        '
        'SelectFossilInfoTableAdapter
        '
        Me.SelectFossilInfoTableAdapter.ClearBeforeFill = True
        '
        'SamplesAndOrdersBindingSource
        '
        Me.SamplesAndOrdersBindingSource.DataMember = "SamplesAndOrders"
        Me.SamplesAndOrdersBindingSource.DataSource = Me.DsOrders_new
        '
        'SamplesAndOrdersTableAdapter
        '
        Me.SamplesAndOrdersTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager1
        '
        Me.TableAdapterManager1.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager1.Select_tb_SamplesOnSaleTableAdapter = Me.Select_tb_SamplesOnSaleTableAdapter
        Me.TableAdapterManager1.UpdateOrder = OrdersAndClients.SampleOnSaleTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'DataGridViewCheckBoxColumn1
        '
        Me.DataGridViewCheckBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewCheckBoxColumn1.DataPropertyName = "ReservedFlag"
        Me.DataGridViewCheckBoxColumn1.HeaderText = "ReservedFlag"
        Me.DataGridViewCheckBoxColumn1.Name = "DataGridViewCheckBoxColumn1"
        '
        'DataGridViewCheckBoxColumn2
        '
        Me.DataGridViewCheckBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewCheckBoxColumn2.DataPropertyName = "ReservedFlag"
        Me.DataGridViewCheckBoxColumn2.HeaderText = "ReservedFlag"
        Me.DataGridViewCheckBoxColumn2.Name = "DataGridViewCheckBoxColumn2"
        Me.DataGridViewCheckBoxColumn2.ReadOnly = True
        '
        'btCopyArticul
        '
        Me.btCopyArticul.Location = New System.Drawing.Point(173, 43)
        Me.btCopyArticul.Name = "btCopyArticul"
        Me.btCopyArticul.Size = New System.Drawing.Size(98, 23)
        Me.btCopyArticul.TabIndex = 42
        Me.btCopyArticul.Text = "Копир. артикул"
        Me.btCopyArticul.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Button2.Location = New System.Drawing.Point(173, 72)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(98, 23)
        Me.Button2.TabIndex = 45
        Me.Button2.Text = "Копир. код"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'DataGridViewCheckBoxColumn3
        '
        Me.DataGridViewCheckBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewCheckBoxColumn3.DataPropertyName = "ReservedFlag"
        Me.DataGridViewCheckBoxColumn3.HeaderText = "ReservedFlag"
        Me.DataGridViewCheckBoxColumn3.Name = "DataGridViewCheckBoxColumn3"
        Me.DataGridViewCheckBoxColumn3.ReadOnly = True
        '
        'DataGridViewCheckBoxColumn4
        '
        Me.DataGridViewCheckBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewCheckBoxColumn4.DataPropertyName = "ReservedFlag"
        Me.DataGridViewCheckBoxColumn4.HeaderText = "ReservedFlag"
        Me.DataGridViewCheckBoxColumn4.Name = "DataGridViewCheckBoxColumn4"
        Me.DataGridViewCheckBoxColumn4.ReadOnly = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(13, 16)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(41, 13)
        Me.Label10.TabIndex = 46
        Me.Label10.Text = "Номер"
        '
        'DataGridViewCheckBoxColumn5
        '
        Me.DataGridViewCheckBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewCheckBoxColumn5.DataPropertyName = "ReservedFlag"
        Me.DataGridViewCheckBoxColumn5.HeaderText = "ReservedFlag"
        Me.DataGridViewCheckBoxColumn5.Name = "DataGridViewCheckBoxColumn5"
        Me.DataGridViewCheckBoxColumn5.ReadOnly = True
        '
        'fmSampleInfo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1056, 741)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.btCopyArticul)
        Me.Controls.Add(Me.btCopyName)
        Me.Controls.Add(Me.tbName)
        Me.Controls.Add(Me.rbRussian)
        Me.Controls.Add(Me.RbEnglish)
        Me.Controls.Add(Me.RTBSampleData)
        Me.Controls.Add(Me.btCopyNumber)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.btAcceptOrder)
        Me.Controls.Add(Me.cbOrders)
        Me.Controls.Add(Me.btAddtoOrder)
        Me.Controls.Add(Me.btAddImages)
        Me.Controls.Add(Me.btAddOnSale)
        Me.Controls.Add(Me.btAddSampleData)
        Me.Controls.Add(Me.lbSampleStatus)
        Me.Controls.Add(Me.lbSample)
        Me.Controls.Add(Me.btSearchInfo)
        Me.Controls.Add(Me.tbSampleNumber)
        Me.Controls.Add(Me.tcSampleInfo)
        Me.Name = "fmSampleInfo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Менеджер образцов"
        Me.tcSampleInfo.ResumeLayout(false)
        Me.tpageStatus.ResumeLayout(false)
        Me.tpageStatus.PerformLayout
        Me.gbCatalogBySkladID.ResumeLayout(false)
        Me.gbCatalogBySkladID.PerformLayout
        CType(Me.pbMainImage,System.ComponentModel.ISupportInitialize).EndInit
        Me.tpageSold.ResumeLayout(false)
        Me.tpageSold.PerformLayout
        Me.GroupBox2.ResumeLayout(false)
        Me.GroupBox2.PerformLayout
        CType(Me.Select_tb_SamplesOnSaleBindingSource,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.SampleOnSale,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.DataGridView2,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.SelectSampleOrdersInfoBindingSource,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.DsOrders_new,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.SelectSampleInfoBindingSource,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.DsService,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.SelectFossilInfoBindingSource,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.SamplesAndOrdersBindingSource,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents tcSampleInfo As System.Windows.Forms.TabControl
    Friend WithEvents tpageStatus As System.Windows.Forms.TabPage
    Friend WithEvents tbSampleNumber As System.Windows.Forms.TextBox
    Friend WithEvents btSearchInfo As System.Windows.Forms.Button
    Friend WithEvents tpageSold As System.Windows.Forms.TabPage
    Friend WithEvents tpageStoreInfo As System.Windows.Forms.TabPage
    Friend WithEvents lbSample As System.Windows.Forms.Label
    Friend WithEvents lbSampleStatus As System.Windows.Forms.Label
    Friend WithEvents DsOrders_new As OrdersAndClients.dsOrders_new
    Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
    Friend WithEvents SelectSampleOrdersInfoBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Select_SampleOrdersInfoTableAdapter As OrdersAndClients.dsOrders_newTableAdapters.Select_SampleOrdersInfoTableAdapter
    Friend WithEvents imgLwPhoto As System.Windows.Forms.ListView
    'Friend WithEvents DsService As OrdersAndClients.dsService
    Friend WithEvents Select_SampleInfoTableAdapter As OrdersAndClients.dsServiceTableAdapters.Select_SampleInfoTableAdapter
    Friend WithEvents TableAdapterManager As OrdersAndClients.dsServiceTableAdapters.TableAdapterManager
    'Friend WithEvents SelectFossilInfoTableAdapter As OrdersAndClients.dsServiceTableAdapters.SelectFossilInfoTableAdapter
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SampleOnSale As OrdersAndClients.SampleOnSale
    Friend WithEvents Select_tb_SamplesOnSaleBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Select_tb_SamplesOnSaleTableAdapter As OrdersAndClients.SampleOnSaleTableAdapters.Select_tb_SamplesOnSaleTableAdapter
    Friend WithEvents RateOfExchangeTextBox As System.Windows.Forms.TextBox
    Friend WithEvents CurrencyNameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents FreeShippingPossibleFlagCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents CostsTextBox As System.Windows.Forms.TextBox
    Friend WithEvents btAddSampleData As System.Windows.Forms.Button
    Friend WithEvents btAddOnSale As System.Windows.Forms.Button
    Friend WithEvents btAddImages As System.Windows.Forms.Button
    Friend WithEvents btAddtoOrder As System.Windows.Forms.Button
    Friend WithEvents cbOrders As System.Windows.Forms.ComboBox
    Friend WithEvents btAcceptOrder As System.Windows.Forms.Button
    Friend WithEvents DsService1 As OrdersAndClients.dsService
    'Friend WithEvents SelectFossilInfoTableAdapter1 As OrdersAndClients.dsServiceTableAdapters.SelectFossilInfoTableAdapter
    Friend WithEvents IDSamplenumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FossilNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FossilfullnameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FossillengthDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FossilwidthDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FossilheightDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FossilDimensionDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DsService2 As OrdersAndClients.dsService
    'Friend WithEvents SelectFossilInfoTableAdapter2 As OrdersAndClients.dsServiceTableAdapters.SelectFossilInfoTableAdapter
    Friend WithEvents DsService As OrdersAndClients.dsService
    Friend WithEvents SelectSampleInfoBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Select_SampleInfoTableAdapter1 As OrdersAndClients.dsServiceTableAdapters.Select_SampleInfoTableAdapter
    Friend WithEvents SelectFossilInfoBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SelectFossilInfoTableAdapter As OrdersAndClients.dsServiceTableAdapters.SelectFossilInfoTableAdapter
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents SamplesAndOrdersBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SamplesAndOrdersTableAdapter As OrdersAndClients.dsOrders_newTableAdapters.SamplesAndOrdersTableAdapter
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents OrderIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OrderDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OrderCheckOutStatusDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents OrderStockOutStatusDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents OrderCancellationStatusDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ClientFullNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SampleConfirmStatusDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents SampleCheckOutStatusDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents RetailPriceDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OfferPriceDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OfferDiscountDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SampleConfirmPriceDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SampleShippingPriceDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CurrencyDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OnSaleFlagDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ReservedFlagDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents SoldFlagDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents SampleCheckOutDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OrderStockOutDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OrderCancellationDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OrderCheckOutDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btCopyNumber As System.Windows.Forms.Button
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents cbShowPreview As System.Windows.Forms.CheckBox
    Friend WithEvents tbPrevievTime As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents SoldPriceTextBox As System.Windows.Forms.TextBox
    Friend WithEvents BasePriceTextBox As System.Windows.Forms.TextBox
    Friend WithEvents TableAdapterManager1 As OrdersAndClients.SampleOnSaleTableAdapters.TableAdapterManager
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents rb1024Optimize As System.Windows.Forms.RadioButton
    Friend WithEvents rb2048Optimize As System.Windows.Forms.RadioButton
    Friend WithEvents rbNoOptimize As System.Windows.Forms.RadioButton
    Friend WithEvents RTBSampleData As System.Windows.Forms.RichTextBox
    Friend WithEvents btCopyToFolder As System.Windows.Forms.Button
    Friend WithEvents cbxRemoteConnections As System.Windows.Forms.CheckBox
    Friend WithEvents cbSourcesList As System.Windows.Forms.ComboBox
    Friend WithEvents pbMainImage As System.Windows.Forms.PictureBox
    Friend WithEvents RbEnglish As System.Windows.Forms.RadioButton
    Friend WithEvents rbRussian As System.Windows.Forms.RadioButton
    Friend WithEvents btSelectAll As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lbTemplates As System.Windows.Forms.ListBox
    Friend WithEvents cbxRepalceImages As System.Windows.Forms.CheckBox
    Friend WithEvents btCopyByTemplate As System.Windows.Forms.Button
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents btCreateByTemplate As System.Windows.Forms.Button
    Friend WithEvents btAddTemplate As System.Windows.Forms.Button
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents lbLinkedSources As System.Windows.Forms.ListBox
    Friend WithEvents btUnselectAll As System.Windows.Forms.Button
    Friend WithEvents lbCurrentCulture As System.Windows.Forms.Label
    Friend WithEvents tbName As System.Windows.Forms.TextBox
    Friend WithEvents btCopyName As System.Windows.Forms.Button
    Friend WithEvents DataGridViewCheckBoxColumn1 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn2 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents btCopyArticul As System.Windows.Forms.Button
    Friend WithEvents cbxExtendedOutput As System.Windows.Forms.CheckBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents DataGridViewCheckBoxColumn3 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents btGetMScatalog As System.Windows.Forms.Button
    Friend WithEvents tbMSnumber As System.Windows.Forms.TextBox
    Friend WithEvents gbCatalogBySkladID As System.Windows.Forms.GroupBox
    Friend WithEvents lblMsOrder As System.Windows.Forms.Label
    Friend WithEvents lbSampleInMCOrder As System.Windows.Forms.ListBox
    Friend WithEvents DataGridViewCheckBoxColumn4 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents btCreateCatalog As System.Windows.Forms.Button
    Friend WithEvents cbxRewritefile As System.Windows.Forms.CheckBox
    Friend WithEvents btAddSource As System.Windows.Forms.Button
    Friend WithEvents btShowInBrowser As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents DataGridViewCheckBoxColumn5 As System.Windows.Forms.DataGridViewCheckBoxColumn
    'Friend WithEvents SelectFossilInfoTableAdapter3 As OrdersAndClients.dsServiceTableAdapters.SelectFossilInfoTableAdapter
End Class
