Imports Service

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class fmMoySklad
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
        Dim Label39 As System.Windows.Forms.Label
        Dim Label35 As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fmMoySklad))
        Me.WeightLabel = New System.Windows.Forms.Label()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.tbCtlMain = New System.Windows.Forms.TabControl()
        Me.tpMain = New System.Windows.Forms.TabPage()
        Me.Label60 = New System.Windows.Forms.Label()
        Me.btSetName = New System.Windows.Forms.Button()
        Me.btSetArticul = New System.Windows.Forms.Button()
        Me.pbLabel = New System.Windows.Forms.PictureBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.cbxBuyCalc = New System.Windows.Forms.CheckBox()
        Me.lbLossUom = New System.Windows.Forms.Label()
        Me.cbxNakladnye = New System.Windows.Forms.CheckBox()
        Me.cbLossLocations = New System.Windows.Forms.ListBox()
        Me.tbBuyPriceGoodCurrency = New System.Windows.Forms.TextBox()
        Me.tbBuyPriceGood = New System.Windows.Forms.TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.tbShippingPrice = New System.Windows.Forms.TextBox()
        Me.cbxWriteAdditionalPrices = New System.Windows.Forms.CheckBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.btLoss = New System.Windows.Forms.Button()
        Me.BtCopyName = New System.Windows.Forms.Button()
        Me.tbLossQty = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.cbxIncomingPrices = New System.Windows.Forms.CheckBox()
        Me.btGetLossSource = New System.Windows.Forms.Button()
        Me.tbLossSourceName = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.tbLossSourceArticul = New System.Windows.Forms.TextBox()
        Me.btGetArticulList = New System.Windows.Forms.Button()
        Me.lbArticuls = New System.Windows.Forms.ListBox()
        Me.dgv_Goods = New System.Windows.Forms.DataGridView()
        Me.ArticulDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SalePrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bs_Goods_dgv_Goods = New System.Windows.Forms.BindingSource(Me.components)
        Me.cbxLossEnable = New System.Windows.Forms.CheckBox()
        Me.tpPreparation = New System.Windows.Forms.TabPage()
        Me.GroupBox11 = New System.Windows.Forms.GroupBox()
        Me.cbxCalculateBuy = New System.Windows.Forms.CheckBox()
        Me.cbxSetExport = New System.Windows.Forms.CheckBox()
        Me.cbSchemePrice = New System.Windows.Forms.ComboBox()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.btGetPrices = New System.Windows.Forms.Button()
        Me.cbWeightTariff = New System.Windows.Forms.ComboBox()
        Me.tbWeightTariff = New System.Windows.Forms.TextBox()
        Me.GroupBox10 = New System.Windows.Forms.GroupBox()
        Me.cbxNeedRepair = New System.Windows.Forms.CheckBox()
        Me.cbxNeedRePrep = New System.Windows.Forms.CheckBox()
        Me.cbRePrepDetails = New System.Windows.Forms.ComboBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.cbxNeedMakeLabel = New System.Windows.Forms.CheckBox()
        Me.GroupBox9 = New System.Windows.Forms.GroupBox()
        Me.btBuildCondition = New System.Windows.Forms.Button()
        Me.btCondition = New System.Windows.Forms.Button()
        Me.lbBuildDescription = New System.Windows.Forms.Label()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cbxIncomingIncludePrep = New System.Windows.Forms.CheckBox()
        Me.btFromInvoice = New System.Windows.Forms.Button()
        Me.cbxIncomingIncludeExport = New System.Windows.Forms.CheckBox()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.btFromBuy = New System.Windows.Forms.Button()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.tbBuyCost = New System.Windows.Forms.TextBox()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.btToPrepTime = New System.Windows.Forms.Button()
        Me.btClearPrep = New System.Windows.Forms.Button()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.tbFullPrepCost = New System.Windows.Forms.TextBox()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.tbPrepCost = New System.Windows.Forms.TextBox()
        Me.btAddPrep = New System.Windows.Forms.Button()
        Me.tbPrepTimeAdd = New System.Windows.Forms.TextBox()
        Me.cbPreparatorAdd = New System.Windows.Forms.ComboBox()
        Me.tbPrepList = New System.Windows.Forms.TextBox()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.tbPrepTime = New System.Windows.Forms.TextBox()
        Me.cbMainPreparator = New System.Windows.Forms.ComboBox()
        Me.RawNumberLabel = New System.Windows.Forms.Label()
        Me.tbRawNumber = New System.Windows.Forms.TextBox()
        Me.bsCurrentGood = New System.Windows.Forms.BindingSource(Me.components)
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.cbxNeedPackaging = New System.Windows.Forms.CheckBox()
        Me.tbBoxType = New System.Windows.Forms.TextBox()
        Me.cbBoxTypes = New System.Windows.Forms.ComboBox()
        Me.btBoxTypeFromName = New System.Windows.Forms.Button()
        Me.btBoxTypeSelect = New System.Windows.Forms.Button()
        Me.cbFixPrepTab = New System.Windows.Forms.CheckBox()
        Me.cbxInCommission = New System.Windows.Forms.CheckBox()
        Me.cbInExpedition = New System.Windows.Forms.CheckBox()
        Me.gbBuy = New System.Windows.Forms.GroupBox()
        Me.cbSupplier = New System.Windows.Forms.ComboBox()
        Me.gbExpedition = New System.Windows.Forms.GroupBox()
        Me.cbExpedition = New System.Windows.Forms.ComboBox()
        Me.tbExpedNumber = New System.Windows.Forms.TextBox()
        Me.tbExpeditInfo = New System.Windows.Forms.TextBox()
        Me.tpPrices = New System.Windows.Forms.TabPage()
        Me.tbCoeff = New System.Windows.Forms.TextBox()
        Me.Label61 = New System.Windows.Forms.Label()
        Me.cbxWithoutPriceLabelType = New System.Windows.Forms.CheckBox()
        Me.cbFixPriceTab = New System.Windows.Forms.CheckBox()
        Me.btShowLabelAny2 = New System.Windows.Forms.Button()
        Me.pbLabel2 = New System.Windows.Forms.PictureBox()
        Me.Label59 = New System.Windows.Forms.Label()
        Me.btRet4 = New System.Windows.Forms.Button()
        Me.btRet32 = New System.Windows.Forms.Button()
        Me.btImpMinus30 = New System.Windows.Forms.Button()
        Me.btImpPlus30 = New System.Windows.Forms.Button()
        Me.btRet2 = New System.Windows.Forms.Button()
        Me.btCallCalculator = New System.Windows.Forms.Button()
        Me.btRusPlus30 = New System.Windows.Forms.Button()
        Me.btRusMinus30 = New System.Windows.Forms.Button()
        Me.btSetPrices = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.tbPRICE7 = New System.Windows.Forms.TextBox()
        Me.UcPriceCalc_clsPriceDataBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.tbPRICE6 = New System.Windows.Forms.TextBox()
        Me.tbPRICE5 = New System.Windows.Forms.TextBox()
        Me.tbPRICE4 = New System.Windows.Forms.TextBox()
        Me.tbPRICE3 = New System.Windows.Forms.TextBox()
        Me.Label53 = New System.Windows.Forms.Label()
        Me.CR1 = New System.Windows.Forms.Label()
        Me.tbPRICE1 = New System.Windows.Forms.TextBox()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.Label54 = New System.Windows.Forms.Label()
        Me.Label55 = New System.Windows.Forms.Label()
        Me.Label56 = New System.Windows.Forms.Label()
        Me.Label57 = New System.Windows.Forms.Label()
        Me.CR3 = New System.Windows.Forms.Label()
        Me.CR4 = New System.Windows.Forms.Label()
        Me.CR5 = New System.Windows.Forms.Label()
        Me.CR6 = New System.Windows.Forms.Label()
        Me.CR7 = New System.Windows.Forms.Label()
        Me.tbPrice8 = New System.Windows.Forms.TextBox()
        Me.CR8cb = New System.Windows.Forms.ComboBox()
        Me.tbPRICE2 = New System.Windows.Forms.TextBox()
        Me.CR2 = New System.Windows.Forms.Label()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.cbRoundPrices = New System.Windows.Forms.CheckBox()
        Me.btWritePrices = New System.Windows.Forms.Button()
        Me.UcPriceCalc1 = New Service.ucPriceCalc()
        Me.tpRfid = New System.Windows.Forms.TabPage()
        Me.cbFixTabRfid = New System.Windows.Forms.CheckBox()
        Me.UcGoodLabel1 = New Service.ucGoodLabel()
        Me.BindingNavigatorImages = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.cbx_UCAutoprintWithPrice = New System.Windows.Forms.CheckBox()
        Me.bt_UCRequest = New System.Windows.Forms.Button()
        Me.UC_rfid1 = New Service.UC_rfid()
        Me.tpWareCells = New System.Windows.Forms.TabPage()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.btAddCurrent = New System.Windows.Forms.Button()
        Me.tbNumberForPlacing = New System.Windows.Forms.TextBox()
        Me.btAddToPlacing = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btCreateInventory = New System.Windows.Forms.Button()
        Me.lbxSelectedNumbers = New System.Windows.Forms.ListBox()
        Me.bs_currentMove = New System.Windows.Forms.BindingSource(Me.components)
        Me.lbSlotInfo = New System.Windows.Forms.Label()
        Me.lbSelectedSlotNumbers = New System.Windows.Forms.Label()
        Me.btDeleteNumber = New System.Windows.Forms.Button()
        Me.btAddToSelected = New System.Windows.Forms.Button()
        Me.btToFreeLocation = New System.Windows.Forms.Button()
        Me.btAddAllNumbers = New System.Windows.Forms.Button()
        Me.btFromSlot = New System.Windows.Forms.Button()
        Me.nudLabelsCountCopy = New System.Windows.Forms.NumericUpDown()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btClearPrintJob = New System.Windows.Forms.Button()
        Me.btPrintLabel = New System.Windows.Forms.Button()
        Me.btAddLabel = New System.Windows.Forms.Button()
        Me.pnLabel = New System.Windows.Forms.Panel()
        Me.btToSlot = New System.Windows.Forms.Button()
        Me.lbSlotNumbers = New System.Windows.Forms.Label()
        Me.lbxnumbers = New System.Windows.Forms.ListBox()
        Me.lbCurrentSlot = New System.Windows.Forms.Label()
        Me.bs_Curr_slot_location = New System.Windows.Forms.BindingSource(Me.components)
        Me.bs_Curr_stor_location = New System.Windows.Forms.BindingSource(Me.components)
        Me.lbSlotForPlacing = New System.Windows.Forms.ListBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cbStoreForPlacing = New System.Windows.Forms.ComboBox()
        Me.tpInfo = New System.Windows.Forms.TabPage()
        Me.Uc_trilbone_history1 = New Service.Uc_trilbone_history()
        Me.tpLotEnterTabPage = New System.Windows.Forms.TabPage()
        Me.tpAuctions = New System.Windows.Forms.TabPage()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btAuctionUncompleted = New System.Windows.Forms.Button()
        Me.lbAuctionStatus = New System.Windows.Forms.Label()
        Me.btAuctionCompleted = New System.Windows.Forms.Button()
        Me.lbAuctions = New System.Windows.Forms.ListBox()
        Me.RefTODataGridView = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RefTOBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.tbAuGetSampleList = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbUnReady = New System.Windows.Forms.RadioButton()
        Me.rbReady = New System.Windows.Forms.RadioButton()
        Me.cbAuStoreList = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cbAuAuctionList = New System.Windows.Forms.ComboBox()
        Me.ClsBulkEnterObjBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.btAddWeightToName = New System.Windows.Forms.Button()
        Me.cbAutoprint = New System.Windows.Forms.CheckBox()
        Me.Label58 = New System.Windows.Forms.Label()
        Me.cbPrintCurrency = New System.Windows.Forms.ComboBox()
        Me.lbWarning = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tbWeight = New System.Windows.Forms.TextBox()
        Me.cbxNeedPhotos = New System.Windows.Forms.CheckBox()
        Me.btLabel = New System.Windows.Forms.Button()
        Me.btLabelWithPrice = New System.Windows.Forms.Button()
        Me.SalePricesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.btPrinterClear = New System.Windows.Forms.Button()
        Me.ClsMSGoodBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cbRetailTargetCurrency = New System.Windows.Forms.ComboBox()
        Me.tbRetailTargetValue = New System.Windows.Forms.TextBox()
        Me.cbxSetRetail = New System.Windows.Forms.CheckBox()
        Me.btSaveChanges = New System.Windows.Forms.Button()
        Me.btClear = New System.Windows.Forms.Button()
        Me.btSearchInSklad = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tbNumber = New System.Windows.Forms.TextBox()
        Me.tbArticul = New System.Windows.Forms.TextBox()
        Me.tbName = New System.Windows.Forms.TextBox()
        Me.tbBarCode = New System.Windows.Forms.TextBox()
        Me.cbTargetStores = New System.Windows.Forms.ComboBox()
        Me.bs_GoodLocation = New System.Windows.Forms.BindingSource(Me.components)
        Me.SlotGoodBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label8 = New System.Windows.Forms.Label()
        Me.rtbDescription = New System.Windows.Forms.RichTextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cbSlot = New System.Windows.Forms.ComboBox()
        Me.btAddGoodToWare = New System.Windows.Forms.Button()
        Me.tbQty = New System.Windows.Forms.TextBox()
        Me.cbxWithoutSlot = New System.Windows.Forms.CheckBox()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
        Me.btCreateGood = New System.Windows.Forms.Button()
        Me.btHide = New System.Windows.Forms.Button()
        Me.btOnePcs = New System.Windows.Forms.Button()
        Me.btServiceForm = New System.Windows.Forms.Button()
        Me.cbxAddIfExists = New System.Windows.Forms.CheckBox()
        Me.SlotListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.btNewNumber = New System.Windows.Forms.Button()
        Me.cbxFixStore = New System.Windows.Forms.CheckBox()
        Me.cbxFixCurrency = New System.Windows.Forms.CheckBox()
        Me.cbxFixSeries = New System.Windows.Forms.CheckBox()
        Me.btLoadTree = New System.Windows.Forms.Button()
        Me.cbMaterial = New System.Windows.Forms.ComboBox()
        Me.cbListOfTree = New System.Windows.Forms.ComboBox()
        Me.cbDBNames = New System.Windows.Forms.ComboBox()
        Me.rbEnglish = New System.Windows.Forms.RadioButton()
        Me.rbRussian = New System.Windows.Forms.RadioButton()
        Me.btCopyNameFromTrees = New System.Windows.Forms.Button()
        Me.btCheckCodes = New System.Windows.Forms.Button()
        Me.cbUom = New System.Windows.Forms.ComboBox()
        Me.btMoveToArticul = New System.Windows.Forms.Button()
        Me.btSubNumberPlus = New System.Windows.Forms.Button()
        Me.btSubNumberMinus = New System.Windows.Forms.Button()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.tbBuyTargetValue = New System.Windows.Forms.TextBox()
        Me.cbxSetBuy = New System.Windows.Forms.CheckBox()
        Me.cbBuyTargetCurrency = New System.Windows.Forms.ComboBox()
        Me.btMoveToCode = New System.Windows.Forms.Button()
        Me.btOption = New System.Windows.Forms.Button()
        Me.cbLocations = New System.Windows.Forms.ListBox()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.tbMyTreeCode = New System.Windows.Forms.TextBox()
        Me.btOpenTreeForm = New System.Windows.Forms.Button()
        Me.btAddNameFromTree = New System.Windows.Forms.Button()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lbToolWarning = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.lbRetail = New System.Windows.Forms.Label()
        Me.lbIncoming = New System.Windows.Forms.Label()
        Me.btNumberMinus = New System.Windows.Forms.Button()
        Me.btNumberPlus = New System.Windows.Forms.Button()
        Me.btRoundRetailPrice = New System.Windows.Forms.Button()
        Me.btClear2 = New System.Windows.Forms.Button()
        Me.pbImage = New System.Windows.Forms.PictureBox()
        Me.cbInvoceCurrency = New System.Windows.Forms.ComboBox()
        Me.tbInvoice = New System.Windows.Forms.TextBox()
        Me.cbxInvoice = New System.Windows.Forms.CheckBox()
        Me.btShowLabelAny = New System.Windows.Forms.Button()
        Me.btSearchLabel = New System.Windows.Forms.Button()
        Me.btIncomingCalculate = New System.Windows.Forms.Button()
        Label39 = New System.Windows.Forms.Label()
        Label35 = New System.Windows.Forms.Label()
        Me.tbCtlMain.SuspendLayout()
        Me.tpMain.SuspendLayout()
        CType(Me.pbLabel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dgv_Goods, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bs_Goods_dgv_Goods, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpPreparation.SuspendLayout()
        Me.GroupBox11.SuspendLayout()
        Me.GroupBox10.SuspendLayout()
        Me.GroupBox9.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        CType(Me.bsCurrentGood, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        Me.gbBuy.SuspendLayout()
        Me.gbExpedition.SuspendLayout()
        Me.tpPrices.SuspendLayout()
        CType(Me.pbLabel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.UcPriceCalc_clsPriceDataBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpRfid.SuspendLayout()
        Me.UcGoodLabel1.SuspendLayout()
        CType(Me.BindingNavigatorImages, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpWareCells.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        CType(Me.bs_currentMove, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudLabelsCountCopy, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bs_Curr_slot_location, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bs_Curr_stor_location, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpInfo.SuspendLayout()
        Me.tpAuctions.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.RefTODataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RefTOBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.ClsBulkEnterObjBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SalePricesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ClsMSGoodBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bs_GoodLocation, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SlotGoodBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SlotListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.pbImage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label39
        '
        Label39.Location = New System.Drawing.Point(6, 71)
        Label39.Name = "Label39"
        Label39.Size = New System.Drawing.Size(114, 33)
        Label39.TabIndex = 11
        Label39.Text = "Примечание или надпись со свертка"
        '
        'Label35
        '
        Label35.AutoSize = True
        Label35.Location = New System.Drawing.Point(5, 47)
        Label35.Name = "Label35"
        Label35.Size = New System.Drawing.Size(148, 13)
        Label35.TabIndex = 102
        Label35.Text = "Ответственный препаратор"
        '
        'WeightLabel
        '
        Me.WeightLabel.AutoSize = True
        Me.WeightLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.WeightLabel.Location = New System.Drawing.Point(663, 156)
        Me.WeightLabel.Name = "WeightLabel"
        Me.WeightLabel.Size = New System.Drawing.Size(43, 12)
        Me.WeightLabel.TabIndex = 113
        Me.WeightLabel.Text = "Вес ед."
        '
        'Label38
        '
        Me.Label38.Location = New System.Drawing.Point(9, 43)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(103, 26)
        Me.Label38.TabIndex = 9
        Me.Label38.Text = "Экспедиционный/закупочный номер"
        '
        'tbCtlMain
        '
        Me.tbCtlMain.Controls.Add(Me.tpMain)
        Me.tbCtlMain.Controls.Add(Me.tpPreparation)
        Me.tbCtlMain.Controls.Add(Me.tpPrices)
        Me.tbCtlMain.Controls.Add(Me.tpRfid)
        Me.tbCtlMain.Controls.Add(Me.tpWareCells)
        Me.tbCtlMain.Controls.Add(Me.tpInfo)
        Me.tbCtlMain.Controls.Add(Me.tpLotEnterTabPage)
        Me.tbCtlMain.Controls.Add(Me.tpAuctions)
        Me.tbCtlMain.Location = New System.Drawing.Point(239, 180)
        Me.tbCtlMain.Name = "tbCtlMain"
        Me.tbCtlMain.SelectedIndex = 0
        Me.tbCtlMain.Size = New System.Drawing.Size(893, 395)
        Me.tbCtlMain.TabIndex = 0
        Me.tbCtlMain.TabStop = False
        '
        'tpMain
        '
        Me.tpMain.Controls.Add(Me.Label60)
        Me.tpMain.Controls.Add(Me.btSetName)
        Me.tpMain.Controls.Add(Me.btSetArticul)
        Me.tpMain.Controls.Add(Me.pbLabel)
        Me.tpMain.Controls.Add(Me.GroupBox3)
        Me.tpMain.Controls.Add(Me.btGetArticulList)
        Me.tpMain.Controls.Add(Me.lbArticuls)
        Me.tpMain.Controls.Add(Me.dgv_Goods)
        Me.tpMain.Controls.Add(Me.cbxLossEnable)
        Me.tpMain.Location = New System.Drawing.Point(4, 22)
        Me.tpMain.Name = "tpMain"
        Me.tpMain.Padding = New System.Windows.Forms.Padding(3)
        Me.tpMain.Size = New System.Drawing.Size(885, 369)
        Me.tpMain.TabIndex = 0
        Me.tpMain.Text = "Справочник товаров"
        Me.tpMain.UseVisualStyleBackColor = True
        '
        'Label60
        '
        Me.Label60.AutoSize = True
        Me.Label60.Location = New System.Drawing.Point(258, 12)
        Me.Label60.Name = "Label60"
        Me.Label60.Size = New System.Drawing.Size(220, 13)
        Me.Label60.TabIndex = 58
        Me.Label60.Text = "Список найденых товары в Моем Складе:"
        '
        'btSetName
        '
        Me.btSetName.Location = New System.Drawing.Point(407, 221)
        Me.btSetName.Name = "btSetName"
        Me.btSetName.Size = New System.Drawing.Size(114, 23)
        Me.btSetName.TabIndex = 57
        Me.btSetName.TabStop = False
        Me.btSetName.Text = "Перенести имя"
        Me.btSetName.UseVisualStyleBackColor = True
        '
        'btSetArticul
        '
        Me.btSetArticul.Location = New System.Drawing.Point(529, 221)
        Me.btSetArticul.Name = "btSetArticul"
        Me.btSetArticul.Size = New System.Drawing.Size(113, 23)
        Me.btSetArticul.TabIndex = 20
        Me.btSetArticul.TabStop = False
        Me.btSetArticul.Text = "Перенести артикул"
        Me.btSetArticul.UseVisualStyleBackColor = True
        '
        'pbLabel
        '
        Me.pbLabel.Location = New System.Drawing.Point(660, 221)
        Me.pbLabel.Name = "pbLabel"
        Me.pbLabel.Size = New System.Drawing.Size(202, 139)
        Me.pbLabel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbLabel.TabIndex = 19
        Me.pbLabel.TabStop = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cbxBuyCalc)
        Me.GroupBox3.Controls.Add(Me.lbLossUom)
        Me.GroupBox3.Controls.Add(Me.cbxNakladnye)
        Me.GroupBox3.Controls.Add(Me.cbLossLocations)
        Me.GroupBox3.Controls.Add(Me.tbBuyPriceGoodCurrency)
        Me.GroupBox3.Controls.Add(Me.tbBuyPriceGood)
        Me.GroupBox3.Controls.Add(Me.Label31)
        Me.GroupBox3.Controls.Add(Me.Label34)
        Me.GroupBox3.Controls.Add(Me.tbShippingPrice)
        Me.GroupBox3.Controls.Add(Me.cbxWriteAdditionalPrices)
        Me.GroupBox3.Controls.Add(Me.Label33)
        Me.GroupBox3.Controls.Add(Me.btLoss)
        Me.GroupBox3.Controls.Add(Me.BtCopyName)
        Me.GroupBox3.Controls.Add(Me.tbLossQty)
        Me.GroupBox3.Controls.Add(Me.Label21)
        Me.GroupBox3.Controls.Add(Me.cbxIncomingPrices)
        Me.GroupBox3.Controls.Add(Me.btGetLossSource)
        Me.GroupBox3.Controls.Add(Me.tbLossSourceName)
        Me.GroupBox3.Controls.Add(Me.Label20)
        Me.GroupBox3.Controls.Add(Me.Label19)
        Me.GroupBox3.Controls.Add(Me.Label18)
        Me.GroupBox3.Controls.Add(Me.tbLossSourceArticul)
        Me.GroupBox3.Location = New System.Drawing.Point(7, 31)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(244, 332)
        Me.GroupBox3.TabIndex = 17
        Me.GroupBox3.TabStop = False
        '
        'cbxBuyCalc
        '
        Me.cbxBuyCalc.AutoSize = True
        Me.cbxBuyCalc.Checked = True
        Me.cbxBuyCalc.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbxBuyCalc.Location = New System.Drawing.Point(141, 206)
        Me.cbxBuyCalc.Name = "cbxBuyCalc"
        Me.cbxBuyCalc.Size = New System.Drawing.Size(87, 17)
        Me.cbxBuyCalc.TabIndex = 31
        Me.cbxBuyCalc.TabStop = False
        Me.cbxBuyCalc.Text = "рассчет цен"
        Me.cbxBuyCalc.UseVisualStyleBackColor = True
        '
        'lbLossUom
        '
        Me.lbLossUom.AutoSize = True
        Me.lbLossUom.Location = New System.Drawing.Point(116, 278)
        Me.lbLossUom.Name = "lbLossUom"
        Me.lbLossUom.Size = New System.Drawing.Size(22, 13)
        Me.lbLossUom.TabIndex = 30
        Me.lbLossUom.Text = "ед."
        '
        'cbxNakladnye
        '
        Me.cbxNakladnye.AutoSize = True
        Me.cbxNakladnye.Location = New System.Drawing.Point(7, 228)
        Me.cbxNakladnye.Name = "cbxNakladnye"
        Me.cbxNakladnye.Size = New System.Drawing.Size(91, 17)
        Me.cbxNakladnye.TabIndex = 29
        Me.cbxNakladnye.TabStop = False
        Me.cbxNakladnye.Text = "+ накладные"
        Me.cbxNakladnye.UseVisualStyleBackColor = True
        '
        'cbLossLocations
        '
        Me.cbLossLocations.FormattingEnabled = True
        Me.cbLossLocations.Location = New System.Drawing.Point(5, 133)
        Me.cbLossLocations.Name = "cbLossLocations"
        Me.cbLossLocations.Size = New System.Drawing.Size(231, 43)
        Me.cbLossLocations.TabIndex = 28
        Me.cbLossLocations.TabStop = False
        '
        'tbBuyPriceGoodCurrency
        '
        Me.tbBuyPriceGoodCurrency.Enabled = False
        Me.tbBuyPriceGoodCurrency.Location = New System.Drawing.Point(127, 179)
        Me.tbBuyPriceGoodCurrency.Name = "tbBuyPriceGoodCurrency"
        Me.tbBuyPriceGoodCurrency.Size = New System.Drawing.Size(42, 20)
        Me.tbBuyPriceGoodCurrency.TabIndex = 27
        Me.tbBuyPriceGoodCurrency.TabStop = False
        '
        'tbBuyPriceGood
        '
        Me.tbBuyPriceGood.Location = New System.Drawing.Point(56, 179)
        Me.tbBuyPriceGood.Name = "tbBuyPriceGood"
        Me.tbBuyPriceGood.Size = New System.Drawing.Size(63, 20)
        Me.tbBuyPriceGood.TabIndex = 26
        Me.tbBuyPriceGood.TabStop = False
        Me.tbBuyPriceGood.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(9, 182)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(41, 13)
        Me.Label31.TabIndex = 25
        Me.Label31.Text = "invoice"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(163, 253)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(30, 13)
        Me.Label34.TabIndex = 23
        Me.Label34.Text = "EUR"
        '
        'tbShippingPrice
        '
        Me.tbShippingPrice.Location = New System.Drawing.Point(127, 249)
        Me.tbShippingPrice.Name = "tbShippingPrice"
        Me.tbShippingPrice.Size = New System.Drawing.Size(30, 20)
        Me.tbShippingPrice.TabIndex = 22
        Me.tbShippingPrice.TabStop = False
        Me.tbShippingPrice.Text = "0"
        Me.tbShippingPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cbxWriteAdditionalPrices
        '
        Me.cbxWriteAdditionalPrices.AutoSize = True
        Me.cbxWriteAdditionalPrices.Location = New System.Drawing.Point(7, 251)
        Me.cbxWriteAdditionalPrices.Name = "cbxWriteAdditionalPrices"
        Me.cbxWriteAdditionalPrices.Size = New System.Drawing.Size(115, 17)
        Me.cbxWriteAdditionalPrices.TabIndex = 21
        Me.cbxWriteAdditionalPrices.TabStop = False
        Me.cbxWriteAdditionalPrices.Text = "+ доставка за ед."
        Me.cbxWriteAdditionalPrices.UseVisualStyleBackColor = True
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(16, 104)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(215, 26)
        Me.Label33.TabIndex = 20
        Me.Label33.Text = "*после запроса выбери товар в таблице " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "для просмотра и выбора остатка >>"
        '
        'btLoss
        '
        Me.btLoss.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btLoss.Location = New System.Drawing.Point(150, 274)
        Me.btLoss.Name = "btLoss"
        Me.btLoss.Size = New System.Drawing.Size(86, 23)
        Me.btLoss.TabIndex = 19
        Me.btLoss.TabStop = False
        Me.btLoss.Text = "Списать"
        Me.btLoss.UseVisualStyleBackColor = True
        '
        'BtCopyName
        '
        Me.BtCopyName.Location = New System.Drawing.Point(7, 303)
        Me.BtCopyName.Name = "BtCopyName"
        Me.BtCopyName.Size = New System.Drawing.Size(230, 23)
        Me.BtCopyName.TabIndex = 17
        Me.BtCopyName.TabStop = False
        Me.BtCopyName.Text = "Перенести название от общего артикула"
        Me.BtCopyName.UseVisualStyleBackColor = True
        '
        'tbLossQty
        '
        Me.tbLossQty.Location = New System.Drawing.Point(67, 275)
        Me.tbLossQty.Name = "tbLossQty"
        Me.tbLossQty.Size = New System.Drawing.Size(43, 20)
        Me.tbLossQty.TabIndex = 16
        Me.tbLossQty.TabStop = False
        Me.tbLossQty.Text = "0"
        Me.tbLossQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(11, 278)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(49, 13)
        Me.Label21.TabIndex = 15
        Me.Label21.Text = "Списать"
        '
        'cbxIncomingPrices
        '
        Me.cbxIncomingPrices.AutoSize = True
        Me.cbxIncomingPrices.Checked = True
        Me.cbxIncomingPrices.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbxIncomingPrices.Location = New System.Drawing.Point(7, 205)
        Me.cbxIncomingPrices.Name = "cbxIncomingPrices"
        Me.cbxIncomingPrices.Size = New System.Drawing.Size(119, 17)
        Me.cbxIncomingPrices.TabIndex = 10
        Me.cbxIncomingPrices.TabStop = False
        Me.cbxIncomingPrices.Text = "рассчет входящей"
        Me.cbxIncomingPrices.UseVisualStyleBackColor = True
        '
        'btGetLossSource
        '
        Me.btGetLossSource.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btGetLossSource.Location = New System.Drawing.Point(6, 75)
        Me.btGetLossSource.Name = "btGetLossSource"
        Me.btGetLossSource.Size = New System.Drawing.Size(230, 26)
        Me.btGetLossSource.TabIndex = 6
        Me.btGetLossSource.TabStop = False
        Me.btGetLossSource.Text = "Запрос остатков списания"
        Me.btGetLossSource.UseVisualStyleBackColor = True
        '
        'tbLossSourceName
        '
        Me.tbLossSourceName.Location = New System.Drawing.Point(62, 48)
        Me.tbLossSourceName.Name = "tbLossSourceName"
        Me.tbLossSourceName.Size = New System.Drawing.Size(176, 20)
        Me.tbLossSourceName.TabIndex = 5
        Me.tbLossSourceName.TabStop = False
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(15, 34)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(25, 13)
        Me.Label20.TabIndex = 4
        Me.Label20.Text = "или"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(4, 51)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(55, 13)
        Me.Label19.TabIndex = 3
        Me.Label19.Text = "название"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label18.Location = New System.Drawing.Point(4, 17)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(83, 13)
        Me.Label18.TabIndex = 2
        Me.Label18.Text = "код, артикул"
        '
        'tbLossSourceArticul
        '
        Me.tbLossSourceArticul.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.tbLossSourceArticul.Location = New System.Drawing.Point(91, 14)
        Me.tbLossSourceArticul.Name = "tbLossSourceArticul"
        Me.tbLossSourceArticul.Size = New System.Drawing.Size(72, 24)
        Me.tbLossSourceArticul.TabIndex = 1
        Me.tbLossSourceArticul.TabStop = False
        '
        'btGetArticulList
        '
        Me.btGetArticulList.Location = New System.Drawing.Point(258, 221)
        Me.btGetArticulList.Name = "btGetArticulList"
        Me.btGetArticulList.Size = New System.Drawing.Size(141, 23)
        Me.btGetArticulList.TabIndex = 14
        Me.btGetArticulList.TabStop = False
        Me.btGetArticulList.Text = "Запрос артикулов"
        Me.btGetArticulList.UseVisualStyleBackColor = True
        '
        'lbArticuls
        '
        Me.lbArticuls.FormattingEnabled = True
        Me.lbArticuls.Location = New System.Drawing.Point(258, 252)
        Me.lbArticuls.Name = "lbArticuls"
        Me.lbArticuls.Size = New System.Drawing.Size(382, 108)
        Me.lbArticuls.Sorted = True
        Me.lbArticuls.TabIndex = 13
        Me.lbArticuls.TabStop = False
        '
        'dgv_Goods
        '
        Me.dgv_Goods.AutoGenerateColumns = False
        Me.dgv_Goods.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_Goods.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ArticulDataGridViewTextBoxColumn, Me.CodeDataGridViewTextBoxColumn, Me.NameDataGridViewTextBoxColumn, Me.SalePrice})
        Me.dgv_Goods.DataSource = Me.bs_Goods_dgv_Goods
        Me.dgv_Goods.Location = New System.Drawing.Point(257, 31)
        Me.dgv_Goods.Name = "dgv_Goods"
        Me.dgv_Goods.Size = New System.Drawing.Size(591, 184)
        Me.dgv_Goods.TabIndex = 11
        Me.dgv_Goods.TabStop = False
        '
        'ArticulDataGridViewTextBoxColumn
        '
        Me.ArticulDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.ArticulDataGridViewTextBoxColumn.DataPropertyName = "Articul"
        Me.ArticulDataGridViewTextBoxColumn.HeaderText = "Артикул"
        Me.ArticulDataGridViewTextBoxColumn.Name = "ArticulDataGridViewTextBoxColumn"
        Me.ArticulDataGridViewTextBoxColumn.Width = 73
        '
        'CodeDataGridViewTextBoxColumn
        '
        Me.CodeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.CodeDataGridViewTextBoxColumn.DataPropertyName = "Code"
        Me.CodeDataGridViewTextBoxColumn.HeaderText = "Код"
        Me.CodeDataGridViewTextBoxColumn.Name = "CodeDataGridViewTextBoxColumn"
        Me.CodeDataGridViewTextBoxColumn.Width = 51
        '
        'NameDataGridViewTextBoxColumn
        '
        Me.NameDataGridViewTextBoxColumn.DataPropertyName = "Name"
        Me.NameDataGridViewTextBoxColumn.HeaderText = "Название"
        Me.NameDataGridViewTextBoxColumn.Name = "NameDataGridViewTextBoxColumn"
        Me.NameDataGridViewTextBoxColumn.Width = 280
        '
        'SalePrice
        '
        Me.SalePrice.DataPropertyName = "SalePrice"
        Me.SalePrice.HeaderText = "Цена"
        Me.SalePrice.Name = "SalePrice"
        '
        'bs_Goods_dgv_Goods
        '
        Me.bs_Goods_dgv_Goods.DataSource = GetType(RestMS_Client.clsMSGood)
        '
        'cbxLossEnable
        '
        Me.cbxLossEnable.AutoSize = True
        Me.cbxLossEnable.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.cbxLossEnable.Location = New System.Drawing.Point(13, 10)
        Me.cbxLossEnable.Name = "cbxLossEnable"
        Me.cbxLossEnable.Size = New System.Drawing.Size(191, 17)
        Me.cbxLossEnable.TabIndex = 0
        Me.cbxLossEnable.TabStop = False
        Me.cbxLossEnable.Text = "Списать для разбивки лота"
        Me.cbxLossEnable.UseVisualStyleBackColor = True
        '
        'tpPreparation
        '
        Me.tpPreparation.AutoScroll = True
        Me.tpPreparation.Controls.Add(Me.GroupBox11)
        Me.tpPreparation.Controls.Add(Me.GroupBox10)
        Me.tpPreparation.Controls.Add(Me.GroupBox9)
        Me.tpPreparation.Controls.Add(Me.GroupBox7)
        Me.tpPreparation.Controls.Add(Me.GroupBox6)
        Me.tpPreparation.Controls.Add(Me.GroupBox5)
        Me.tpPreparation.Controls.Add(Me.cbFixPrepTab)
        Me.tpPreparation.Controls.Add(Me.cbxInCommission)
        Me.tpPreparation.Controls.Add(Me.cbInExpedition)
        Me.tpPreparation.Controls.Add(Me.gbBuy)
        Me.tpPreparation.Controls.Add(Me.gbExpedition)
        Me.tpPreparation.Location = New System.Drawing.Point(4, 22)
        Me.tpPreparation.Name = "tpPreparation"
        Me.tpPreparation.Padding = New System.Windows.Forms.Padding(3)
        Me.tpPreparation.Size = New System.Drawing.Size(885, 369)
        Me.tpPreparation.TabIndex = 5
        Me.tpPreparation.Text = "Препарация/Детали"
        Me.tpPreparation.UseVisualStyleBackColor = True
        '
        'GroupBox11
        '
        Me.GroupBox11.Controls.Add(Me.cbxCalculateBuy)
        Me.GroupBox11.Controls.Add(Me.cbxSetExport)
        Me.GroupBox11.Controls.Add(Me.cbSchemePrice)
        Me.GroupBox11.Controls.Add(Me.Label50)
        Me.GroupBox11.Controls.Add(Me.btGetPrices)
        Me.GroupBox11.Controls.Add(Me.cbWeightTariff)
        Me.GroupBox11.Controls.Add(Me.tbWeightTariff)
        Me.GroupBox11.Location = New System.Drawing.Point(648, 237)
        Me.GroupBox11.Name = "GroupBox11"
        Me.GroupBox11.Size = New System.Drawing.Size(234, 122)
        Me.GroupBox11.TabIndex = 121
        Me.GroupBox11.TabStop = False
        Me.GroupBox11.Text = "Цены"
        '
        'cbxCalculateBuy
        '
        Me.cbxCalculateBuy.AutoSize = True
        Me.cbxCalculateBuy.Checked = True
        Me.cbxCalculateBuy.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbxCalculateBuy.Location = New System.Drawing.Point(141, 87)
        Me.cbxCalculateBuy.Name = "cbxCalculateBuy"
        Me.cbxCalculateBuy.Size = New System.Drawing.Size(76, 30)
        Me.cbxCalculateBuy.TabIndex = 120
        Me.cbxCalculateBuy.Text = "Рассчет" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "входящей"
        Me.cbxCalculateBuy.UseVisualStyleBackColor = True
        '
        'cbxSetExport
        '
        Me.cbxSetExport.AutoSize = True
        Me.cbxSetExport.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.cbxSetExport.Location = New System.Drawing.Point(6, 63)
        Me.cbxSetExport.Name = "cbxSetExport"
        Me.cbxSetExport.Size = New System.Drawing.Size(112, 17)
        Me.cbxSetExport.TabIndex = 119
        Me.cbxSetExport.Text = "будет перевоз"
        Me.cbxSetExport.UseVisualStyleBackColor = True
        '
        'cbSchemePrice
        '
        Me.cbSchemePrice.FormattingEnabled = True
        Me.cbSchemePrice.Location = New System.Drawing.Point(2, 34)
        Me.cbSchemePrice.Name = "cbSchemePrice"
        Me.cbSchemePrice.Size = New System.Drawing.Size(226, 21)
        Me.cbSchemePrice.TabIndex = 115
        '
        'Label50
        '
        Me.Label50.AutoSize = True
        Me.Label50.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label50.Location = New System.Drawing.Point(5, 16)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(177, 12)
        Me.Label50.TabIndex = 114
        Me.Label50.Text = "Схема рассчета совместного материала"
        '
        'btGetPrices
        '
        Me.btGetPrices.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btGetPrices.Location = New System.Drawing.Point(2, 86)
        Me.btGetPrices.Name = "btGetPrices"
        Me.btGetPrices.Size = New System.Drawing.Size(132, 33)
        Me.btGetPrices.TabIndex = 118
        Me.btGetPrices.Text = "4. Рассчитать цены"
        Me.btGetPrices.UseVisualStyleBackColor = True
        '
        'cbWeightTariff
        '
        Me.cbWeightTariff.FormattingEnabled = True
        Me.cbWeightTariff.Items.AddRange(New Object() {"EUR/кг", "EUR/шт", "EUR/е"})
        Me.cbWeightTariff.Location = New System.Drawing.Point(155, 61)
        Me.cbWeightTariff.Name = "cbWeightTariff"
        Me.cbWeightTariff.Size = New System.Drawing.Size(73, 21)
        Me.cbWeightTariff.TabIndex = 17
        '
        'tbWeightTariff
        '
        Me.tbWeightTariff.Location = New System.Drawing.Point(122, 61)
        Me.tbWeightTariff.Name = "tbWeightTariff"
        Me.tbWeightTariff.Size = New System.Drawing.Size(30, 20)
        Me.tbWeightTariff.TabIndex = 18
        '
        'GroupBox10
        '
        Me.GroupBox10.Controls.Add(Me.cbxNeedRepair)
        Me.GroupBox10.Controls.Add(Me.cbxNeedRePrep)
        Me.GroupBox10.Controls.Add(Me.cbRePrepDetails)
        Me.GroupBox10.Controls.Add(Me.Label37)
        Me.GroupBox10.Controls.Add(Me.cbxNeedMakeLabel)
        Me.GroupBox10.Location = New System.Drawing.Point(647, 105)
        Me.GroupBox10.Name = "GroupBox10"
        Me.GroupBox10.Size = New System.Drawing.Size(235, 125)
        Me.GroupBox10.TabIndex = 120
        Me.GroupBox10.TabStop = False
        Me.GroupBox10.Text = "Флаги"
        '
        'cbxNeedRepair
        '
        Me.cbxNeedRepair.AutoSize = True
        Me.cbxNeedRepair.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.cbxNeedRepair.Location = New System.Drawing.Point(6, 17)
        Me.cbxNeedRepair.Name = "cbxNeedRepair"
        Me.cbxNeedRepair.Size = New System.Drawing.Size(135, 17)
        Me.cbxNeedRepair.TabIndex = 74
        Me.cbxNeedRepair.TabStop = False
        Me.cbxNeedRepair.Text = "Требуется ремонт"
        Me.cbxNeedRepair.UseVisualStyleBackColor = True
        '
        'cbxNeedRePrep
        '
        Me.cbxNeedRePrep.AutoSize = True
        Me.cbxNeedRePrep.Location = New System.Drawing.Point(6, 39)
        Me.cbxNeedRePrep.Name = "cbxNeedRePrep"
        Me.cbxNeedRePrep.Size = New System.Drawing.Size(154, 17)
        Me.cbxNeedRePrep.TabIndex = 69
        Me.cbxNeedRePrep.TabStop = False
        Me.cbxNeedRePrep.Text = "Требуется допрепарация"
        Me.cbxNeedRePrep.UseVisualStyleBackColor = True
        '
        'cbRePrepDetails
        '
        Me.cbRePrepDetails.FormattingEnabled = True
        Me.cbRePrepDetails.Location = New System.Drawing.Point(9, 76)
        Me.cbRePrepDetails.Name = "cbRePrepDetails"
        Me.cbRePrepDetails.Size = New System.Drawing.Size(171, 21)
        Me.cbRePrepDetails.TabIndex = 70
        Me.cbRePrepDetails.TabStop = False
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(6, 59)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(139, 13)
        Me.Label37.TabIndex = 71
        Me.Label37.Text = "Допрепарация подробно.."
        '
        'cbxNeedMakeLabel
        '
        Me.cbxNeedMakeLabel.AutoSize = True
        Me.cbxNeedMakeLabel.Location = New System.Drawing.Point(6, 103)
        Me.cbxNeedMakeLabel.Name = "cbxNeedMakeLabel"
        Me.cbxNeedMakeLabel.Size = New System.Drawing.Size(171, 17)
        Me.cbxNeedMakeLabel.TabIndex = 68
        Me.cbxNeedMakeLabel.TabStop = False
        Me.cbxNeedMakeLabel.Text = "Требуется сделать этикетку"
        Me.cbxNeedMakeLabel.UseVisualStyleBackColor = True
        '
        'GroupBox9
        '
        Me.GroupBox9.Controls.Add(Me.btBuildCondition)
        Me.GroupBox9.Controls.Add(Me.btCondition)
        Me.GroupBox9.Controls.Add(Me.lbBuildDescription)
        Me.GroupBox9.Location = New System.Drawing.Point(647, 4)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(235, 96)
        Me.GroupBox9.TabIndex = 119
        Me.GroupBox9.TabStop = False
        Me.GroupBox9.Text = "Сохранность"
        '
        'btBuildCondition
        '
        Me.btBuildCondition.Location = New System.Drawing.Point(6, 13)
        Me.btBuildCondition.Name = "btBuildCondition"
        Me.btBuildCondition.Size = New System.Drawing.Size(102, 29)
        Me.btBuildCondition.TabIndex = 87
        Me.btBuildCondition.Text = "Настроить сост."
        Me.btBuildCondition.UseVisualStyleBackColor = True
        '
        'btCondition
        '
        Me.btCondition.Location = New System.Drawing.Point(114, 13)
        Me.btCondition.Name = "btCondition"
        Me.btCondition.Size = New System.Drawing.Size(103, 26)
        Me.btCondition.TabIndex = 85
        Me.btCondition.Text = "+ в название"
        Me.btCondition.UseVisualStyleBackColor = True
        '
        'lbBuildDescription
        '
        Me.lbBuildDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbBuildDescription.Location = New System.Drawing.Point(9, 45)
        Me.lbBuildDescription.Name = "lbBuildDescription"
        Me.lbBuildDescription.Size = New System.Drawing.Size(196, 41)
        Me.lbBuildDescription.TabIndex = 86
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.Label11)
        Me.GroupBox7.Controls.Add(Me.cbxIncomingIncludePrep)
        Me.GroupBox7.Controls.Add(Me.btFromInvoice)
        Me.GroupBox7.Controls.Add(Me.cbxIncomingIncludeExport)
        Me.GroupBox7.Controls.Add(Me.Label49)
        Me.GroupBox7.Controls.Add(Me.btFromBuy)
        Me.GroupBox7.Controls.Add(Me.Label42)
        Me.GroupBox7.Controls.Add(Me.tbBuyCost)
        Me.GroupBox7.Location = New System.Drawing.Point(306, 7)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(335, 103)
        Me.GroupBox7.TabIndex = 117
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Стоимость сырья или инвойс"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label11.Location = New System.Drawing.Point(204, 57)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(120, 13)
        Me.Label11.TabIndex = 128
        Me.Label11.Text = "* проверь галочки!"
        '
        'cbxIncomingIncludePrep
        '
        Me.cbxIncomingIncludePrep.AutoSize = True
        Me.cbxIncomingIncludePrep.Location = New System.Drawing.Point(167, 16)
        Me.cbxIncomingIncludePrep.Name = "cbxIncomingIncludePrep"
        Me.cbxIncomingIncludePrep.Size = New System.Drawing.Size(146, 30)
        Me.cbxIncomingIncludePrep.TabIndex = 127
        Me.cbxIncomingIncludePrep.Text = "Препарация уже учтена" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "во входящей"
        Me.cbxIncomingIncludePrep.UseVisualStyleBackColor = True
        '
        'btFromInvoice
        '
        Me.btFromInvoice.Location = New System.Drawing.Point(12, 52)
        Me.btFromInvoice.Name = "btFromInvoice"
        Me.btFromInvoice.Size = New System.Drawing.Size(82, 23)
        Me.btFromInvoice.TabIndex = 126
        Me.btFromInvoice.Text = "из инвойса"
        Me.btFromInvoice.UseVisualStyleBackColor = True
        '
        'cbxIncomingIncludeExport
        '
        Me.cbxIncomingIncludeExport.AutoSize = True
        Me.cbxIncomingIncludeExport.Location = New System.Drawing.Point(12, 16)
        Me.cbxIncomingIncludeExport.Name = "cbxIncomingIncludeExport"
        Me.cbxIncomingIncludeExport.Size = New System.Drawing.Size(140, 30)
        Me.cbxIncomingIncludeExport.TabIndex = 125
        Me.cbxIncomingIncludeExport.Text = "Перевозка уже учтена" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "во входящей"
        Me.cbxIncomingIncludeExport.UseVisualStyleBackColor = True
        '
        'Label49
        '
        Me.Label49.AutoSize = True
        Me.Label49.Location = New System.Drawing.Point(232, 82)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(24, 13)
        Me.Label49.TabIndex = 123
        Me.Label49.Text = "руб"
        '
        'btFromBuy
        '
        Me.btFromBuy.Location = New System.Drawing.Point(103, 52)
        Me.btFromBuy.Name = "btFromBuy"
        Me.btFromBuy.Size = New System.Drawing.Size(82, 23)
        Me.btFromBuy.TabIndex = 111
        Me.btFromBuy.Text = "из входящей"
        Me.btFromBuy.UseVisualStyleBackColor = True
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label42.Location = New System.Drawing.Point(9, 81)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(143, 13)
        Me.Label42.TabIndex = 109
        Me.Label42.Text = "1. Инвойс или закупка"
        '
        'tbBuyCost
        '
        Me.tbBuyCost.Location = New System.Drawing.Point(159, 79)
        Me.tbBuyCost.Name = "tbBuyCost"
        Me.tbBuyCost.Size = New System.Drawing.Size(67, 20)
        Me.tbBuyCost.TabIndex = 15
        Me.tbBuyCost.TabStop = False
        Me.tbBuyCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.btToPrepTime)
        Me.GroupBox6.Controls.Add(Me.btClearPrep)
        Me.GroupBox6.Controls.Add(Me.Label47)
        Me.GroupBox6.Controls.Add(Me.Label48)
        Me.GroupBox6.Controls.Add(Me.tbFullPrepCost)
        Me.GroupBox6.Controls.Add(Me.Label44)
        Me.GroupBox6.Controls.Add(Me.Label45)
        Me.GroupBox6.Controls.Add(Me.tbPrepCost)
        Me.GroupBox6.Controls.Add(Me.btAddPrep)
        Me.GroupBox6.Controls.Add(Me.tbPrepTimeAdd)
        Me.GroupBox6.Controls.Add(Me.cbPreparatorAdd)
        Me.GroupBox6.Controls.Add(Me.tbPrepList)
        Me.GroupBox6.Controls.Add(Me.Label40)
        Me.GroupBox6.Controls.Add(Me.Label43)
        Me.GroupBox6.Controls.Add(Me.Label36)
        Me.GroupBox6.Controls.Add(Me.tbPrepTime)
        Me.GroupBox6.Controls.Add(Me.cbMainPreparator)
        Me.GroupBox6.Controls.Add(Label35)
        Me.GroupBox6.Controls.Add(Me.RawNumberLabel)
        Me.GroupBox6.Controls.Add(Me.tbRawNumber)
        Me.GroupBox6.Location = New System.Drawing.Point(306, 116)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(335, 243)
        Me.GroupBox6.TabIndex = 116
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Стоимость препарации/доделки"
        '
        'btToPrepTime
        '
        Me.btToPrepTime.Location = New System.Drawing.Point(235, 163)
        Me.btToPrepTime.Name = "btToPrepTime"
        Me.btToPrepTime.Size = New System.Drawing.Size(65, 23)
        Me.btToPrepTime.TabIndex = 127
        Me.btToPrepTime.Text = "к преп."
        Me.btToPrepTime.UseVisualStyleBackColor = True
        '
        'btClearPrep
        '
        Me.btClearPrep.Location = New System.Drawing.Point(267, 189)
        Me.btClearPrep.Name = "btClearPrep"
        Me.btClearPrep.Size = New System.Drawing.Size(65, 23)
        Me.btClearPrep.TabIndex = 126
        Me.btClearPrep.Text = "Очистить"
        Me.btClearPrep.UseVisualStyleBackColor = True
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.Location = New System.Drawing.Point(304, 220)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(24, 13)
        Me.Label47.TabIndex = 125
        Me.Label47.Text = "руб"
        '
        'Label48
        '
        Me.Label48.AutoSize = True
        Me.Label48.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label48.Location = New System.Drawing.Point(6, 220)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(228, 13)
        Me.Label48.TabIndex = 123
        Me.Label48.Text = "3. Стоимость препарации к рассчету"
        '
        'tbFullPrepCost
        '
        Me.tbFullPrepCost.Location = New System.Drawing.Point(239, 217)
        Me.tbFullPrepCost.Name = "tbFullPrepCost"
        Me.tbFullPrepCost.Size = New System.Drawing.Size(60, 20)
        Me.tbFullPrepCost.TabIndex = 124
        Me.tbFullPrepCost.TabStop = False
        Me.tbFullPrepCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Location = New System.Drawing.Point(227, 195)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(24, 13)
        Me.Label44.TabIndex = 122
        Me.Label44.Text = "руб"
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Location = New System.Drawing.Point(9, 195)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(148, 13)
        Me.Label45.TabIndex = 120
        Me.Label45.Text = "К оплате препараторам (вх)"
        '
        'tbPrepCost
        '
        Me.tbPrepCost.Location = New System.Drawing.Point(162, 192)
        Me.tbPrepCost.Name = "tbPrepCost"
        Me.tbPrepCost.Size = New System.Drawing.Size(60, 20)
        Me.tbPrepCost.TabIndex = 121
        Me.tbPrepCost.TabStop = False
        Me.tbPrepCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btAddPrep
        '
        Me.btAddPrep.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btAddPrep.Location = New System.Drawing.Point(9, 106)
        Me.btAddPrep.Name = "btAddPrep"
        Me.btAddPrep.Size = New System.Drawing.Size(76, 23)
        Me.btAddPrep.TabIndex = 119
        Me.btAddPrep.Text = "Добавить"
        Me.btAddPrep.UseVisualStyleBackColor = True
        '
        'tbPrepTimeAdd
        '
        Me.tbPrepTimeAdd.Location = New System.Drawing.Point(284, 135)
        Me.tbPrepTimeAdd.Name = "tbPrepTimeAdd"
        Me.tbPrepTimeAdd.Size = New System.Drawing.Size(45, 20)
        Me.tbPrepTimeAdd.TabIndex = 118
        '
        'cbPreparatorAdd
        '
        Me.cbPreparatorAdd.FormattingEnabled = True
        Me.cbPreparatorAdd.Location = New System.Drawing.Point(8, 135)
        Me.cbPreparatorAdd.Name = "cbPreparatorAdd"
        Me.cbPreparatorAdd.Size = New System.Drawing.Size(270, 21)
        Me.cbPreparatorAdd.TabIndex = 117
        Me.cbPreparatorAdd.TabStop = False
        '
        'tbPrepList
        '
        Me.tbPrepList.Location = New System.Drawing.Point(88, 70)
        Me.tbPrepList.Multiline = True
        Me.tbPrepList.Name = "tbPrepList"
        Me.tbPrepList.Size = New System.Drawing.Size(241, 59)
        Me.tbPrepList.TabIndex = 115
        '
        'Label40
        '
        Me.Label40.Location = New System.Drawing.Point(6, 73)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(76, 27)
        Me.Label40.TabIndex = 114
        Me.Label40.Text = "Препараторы и время"
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Location = New System.Drawing.Point(206, 167)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(24, 13)
        Me.Label43.TabIndex = 113
        Me.Label43.Text = "час"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(13, 168)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(140, 13)
        Me.Label36.TabIndex = 111
        Me.Label36.Text = "Общее время препарации"
        '
        'tbPrepTime
        '
        Me.tbPrepTime.Location = New System.Drawing.Point(162, 164)
        Me.tbPrepTime.Name = "tbPrepTime"
        Me.tbPrepTime.Size = New System.Drawing.Size(38, 20)
        Me.tbPrepTime.TabIndex = 112
        Me.tbPrepTime.TabStop = False
        Me.tbPrepTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cbMainPreparator
        '
        Me.cbMainPreparator.FormattingEnabled = True
        Me.cbMainPreparator.Location = New System.Drawing.Point(159, 43)
        Me.cbMainPreparator.Name = "cbMainPreparator"
        Me.cbMainPreparator.Size = New System.Drawing.Size(170, 21)
        Me.cbMainPreparator.TabIndex = 103
        Me.cbMainPreparator.TabStop = False
        '
        'RawNumberLabel
        '
        Me.RawNumberLabel.AutoSize = True
        Me.RawNumberLabel.Location = New System.Drawing.Point(16, 20)
        Me.RawNumberLabel.Name = "RawNumberLabel"
        Me.RawNumberLabel.Size = New System.Drawing.Size(130, 13)
        Me.RawNumberLabel.TabIndex = 100
        Me.RawNumberLabel.Text = "Препарационный номер"
        Me.RawNumberLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tbRawNumber
        '
        Me.tbRawNumber.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsCurrentGood, "RawNumber", True))
        Me.tbRawNumber.Location = New System.Drawing.Point(159, 17)
        Me.tbRawNumber.Name = "tbRawNumber"
        Me.tbRawNumber.Size = New System.Drawing.Size(128, 20)
        Me.tbRawNumber.TabIndex = 101
        Me.tbRawNumber.TabStop = False
        '
        'bsCurrentGood
        '
        Me.bsCurrentGood.DataSource = GetType(RestMS_Client.clsMSGood)
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.cbxNeedPackaging)
        Me.GroupBox5.Controls.Add(Me.tbBoxType)
        Me.GroupBox5.Controls.Add(Me.cbBoxTypes)
        Me.GroupBox5.Controls.Add(Me.btBoxTypeFromName)
        Me.GroupBox5.Controls.Add(Me.btBoxTypeSelect)
        Me.GroupBox5.Location = New System.Drawing.Point(5, 239)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(294, 122)
        Me.GroupBox5.TabIndex = 102
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Упаковка/коробочка"
        '
        'cbxNeedPackaging
        '
        Me.cbxNeedPackaging.AutoSize = True
        Me.cbxNeedPackaging.Location = New System.Drawing.Point(7, 19)
        Me.cbxNeedPackaging.Name = "cbxNeedPackaging"
        Me.cbxNeedPackaging.Size = New System.Drawing.Size(194, 17)
        Me.cbxNeedPackaging.TabIndex = 73
        Me.cbxNeedPackaging.TabStop = False
        Me.cbxNeedPackaging.Text = "Требуется изготовить коробочку"
        Me.cbxNeedPackaging.UseVisualStyleBackColor = True
        '
        'tbBoxType
        '
        Me.tbBoxType.Location = New System.Drawing.Point(6, 42)
        Me.tbBoxType.Name = "tbBoxType"
        Me.tbBoxType.Size = New System.Drawing.Size(250, 20)
        Me.tbBoxType.TabIndex = 93
        '
        'cbBoxTypes
        '
        Me.cbBoxTypes.FormattingEnabled = True
        Me.cbBoxTypes.Location = New System.Drawing.Point(5, 65)
        Me.cbBoxTypes.Name = "cbBoxTypes"
        Me.cbBoxTypes.Size = New System.Drawing.Size(251, 21)
        Me.cbBoxTypes.TabIndex = 89
        '
        'btBoxTypeFromName
        '
        Me.btBoxTypeFromName.Location = New System.Drawing.Point(110, 94)
        Me.btBoxTypeFromName.Name = "btBoxTypeFromName"
        Me.btBoxTypeFromName.Size = New System.Drawing.Size(146, 23)
        Me.btBoxTypeFromName.TabIndex = 92
        Me.btBoxTypeFromName.Text = "убрать из названия"
        Me.btBoxTypeFromName.UseVisualStyleBackColor = True
        '
        'btBoxTypeSelect
        '
        Me.btBoxTypeSelect.Location = New System.Drawing.Point(5, 94)
        Me.btBoxTypeSelect.Name = "btBoxTypeSelect"
        Me.btBoxTypeSelect.Size = New System.Drawing.Size(87, 23)
        Me.btBoxTypeSelect.TabIndex = 90
        Me.btBoxTypeSelect.Text = "запомнить"
        Me.btBoxTypeSelect.UseVisualStyleBackColor = True
        '
        'cbFixPrepTab
        '
        Me.cbFixPrepTab.AutoSize = True
        Me.cbFixPrepTab.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.cbFixPrepTab.Location = New System.Drawing.Point(4, 3)
        Me.cbFixPrepTab.Name = "cbFixPrepTab"
        Me.cbFixPrepTab.Size = New System.Drawing.Size(136, 16)
        Me.cbFixPrepTab.TabIndex = 101
        Me.cbFixPrepTab.Text = "Фиксировать эту вкладку"
        Me.cbFixPrepTab.UseVisualStyleBackColor = True
        '
        'cbxInCommission
        '
        Me.cbxInCommission.AutoSize = True
        Me.cbxInCommission.Location = New System.Drawing.Point(7, 32)
        Me.cbxInCommission.Name = "cbxInCommission"
        Me.cbxInCommission.Size = New System.Drawing.Size(272, 17)
        Me.cbxInCommission.TabIndex = 17
        Me.cbxInCommission.TabStop = False
        Me.cbxInCommission.Text = "Комиссионный образец/лот (взят на комиссию)"
        Me.cbxInCommission.UseVisualStyleBackColor = True
        '
        'cbInExpedition
        '
        Me.cbInExpedition.AutoSize = True
        Me.cbInExpedition.Location = New System.Drawing.Point(5, 108)
        Me.cbInExpedition.Name = "cbInExpedition"
        Me.cbInExpedition.Size = New System.Drawing.Size(180, 17)
        Me.cbInExpedition.TabIndex = 16
        Me.cbInExpedition.TabStop = False
        Me.cbInExpedition.Text = "Экспедиционный образец/лот"
        Me.cbInExpedition.UseVisualStyleBackColor = True
        '
        'gbBuy
        '
        Me.gbBuy.Controls.Add(Me.cbSupplier)
        Me.gbBuy.Location = New System.Drawing.Point(7, 54)
        Me.gbBuy.Name = "gbBuy"
        Me.gbBuy.Size = New System.Drawing.Size(293, 47)
        Me.gbBuy.TabIndex = 14
        Me.gbBuy.TabStop = False
        Me.gbBuy.Text = "Поставщик"
        '
        'cbSupplier
        '
        Me.cbSupplier.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbSupplier.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbSupplier.FormattingEnabled = True
        Me.cbSupplier.Location = New System.Drawing.Point(6, 17)
        Me.cbSupplier.Name = "cbSupplier"
        Me.cbSupplier.Size = New System.Drawing.Size(278, 21)
        Me.cbSupplier.TabIndex = 10
        Me.cbSupplier.TabStop = False
        '
        'gbExpedition
        '
        Me.gbExpedition.Controls.Add(Me.cbExpedition)
        Me.gbExpedition.Controls.Add(Me.tbExpedNumber)
        Me.gbExpedition.Controls.Add(Me.Label38)
        Me.gbExpedition.Controls.Add(Me.tbExpeditInfo)
        Me.gbExpedition.Controls.Add(Label39)
        Me.gbExpedition.Location = New System.Drawing.Point(5, 131)
        Me.gbExpedition.Name = "gbExpedition"
        Me.gbExpedition.Size = New System.Drawing.Size(294, 104)
        Me.gbExpedition.TabIndex = 13
        Me.gbExpedition.TabStop = False
        Me.gbExpedition.Text = "Экспедиция"
        '
        'cbExpedition
        '
        Me.cbExpedition.FormattingEnabled = True
        Me.cbExpedition.Location = New System.Drawing.Point(11, 18)
        Me.cbExpedition.Name = "cbExpedition"
        Me.cbExpedition.Size = New System.Drawing.Size(275, 21)
        Me.cbExpedition.TabIndex = 8
        Me.cbExpedition.TabStop = False
        '
        'tbExpedNumber
        '
        Me.tbExpedNumber.Location = New System.Drawing.Point(118, 48)
        Me.tbExpedNumber.Name = "tbExpedNumber"
        Me.tbExpedNumber.Size = New System.Drawing.Size(108, 20)
        Me.tbExpedNumber.TabIndex = 10
        '
        'tbExpeditInfo
        '
        Me.tbExpeditInfo.Location = New System.Drawing.Point(118, 78)
        Me.tbExpeditInfo.Multiline = True
        Me.tbExpeditInfo.Name = "tbExpeditInfo"
        Me.tbExpeditInfo.Size = New System.Drawing.Size(167, 21)
        Me.tbExpeditInfo.TabIndex = 12
        Me.tbExpeditInfo.TabStop = False
        '
        'tpPrices
        '
        Me.tpPrices.AutoScroll = True
        Me.tpPrices.Controls.Add(Me.tbCoeff)
        Me.tpPrices.Controls.Add(Me.Label61)
        Me.tpPrices.Controls.Add(Me.cbxWithoutPriceLabelType)
        Me.tpPrices.Controls.Add(Me.cbFixPriceTab)
        Me.tpPrices.Controls.Add(Me.btShowLabelAny2)
        Me.tpPrices.Controls.Add(Me.pbLabel2)
        Me.tpPrices.Controls.Add(Me.Label59)
        Me.tpPrices.Controls.Add(Me.btRet4)
        Me.tpPrices.Controls.Add(Me.btRet32)
        Me.tpPrices.Controls.Add(Me.btImpMinus30)
        Me.tpPrices.Controls.Add(Me.btImpPlus30)
        Me.tpPrices.Controls.Add(Me.btRet2)
        Me.tpPrices.Controls.Add(Me.btCallCalculator)
        Me.tpPrices.Controls.Add(Me.btRusPlus30)
        Me.tpPrices.Controls.Add(Me.btRusMinus30)
        Me.tpPrices.Controls.Add(Me.btSetPrices)
        Me.tpPrices.Controls.Add(Me.TableLayoutPanel1)
        Me.tpPrices.Controls.Add(Me.cbRoundPrices)
        Me.tpPrices.Controls.Add(Me.btWritePrices)
        Me.tpPrices.Controls.Add(Me.UcPriceCalc1)
        Me.tpPrices.Location = New System.Drawing.Point(4, 22)
        Me.tpPrices.Name = "tpPrices"
        Me.tpPrices.Padding = New System.Windows.Forms.Padding(3)
        Me.tpPrices.Size = New System.Drawing.Size(885, 369)
        Me.tpPrices.TabIndex = 3
        Me.tpPrices.Text = "Цены"
        Me.tpPrices.UseVisualStyleBackColor = True
        '
        'tbCoeff
        '
        Me.tbCoeff.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.tbCoeff.Location = New System.Drawing.Point(290, 105)
        Me.tbCoeff.Name = "tbCoeff"
        Me.tbCoeff.Size = New System.Drawing.Size(41, 29)
        Me.tbCoeff.TabIndex = 133
        '
        'Label61
        '
        Me.Label61.AutoSize = True
        Me.Label61.Location = New System.Drawing.Point(665, 335)
        Me.Label61.Name = "Label61"
        Me.Label61.Size = New System.Drawing.Size(211, 13)
        Me.Label61.TabIndex = 132
        Me.Label61.Text = "*если надо точные цены, сними флажок"
        '
        'cbxWithoutPriceLabelType
        '
        Me.cbxWithoutPriceLabelType.Checked = True
        Me.cbxWithoutPriceLabelType.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbxWithoutPriceLabelType.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.cbxWithoutPriceLabelType.Location = New System.Drawing.Point(167, 2)
        Me.cbxWithoutPriceLabelType.Name = "cbxWithoutPriceLabelType"
        Me.cbxWithoutPriceLabelType.Size = New System.Drawing.Size(105, 16)
        Me.cbxWithoutPriceLabelType.TabIndex = 91
        Me.cbxWithoutPriceLabelType.TabStop = False
        Me.cbxWithoutPriceLabelType.Text = "этик. без цены фикс."
        Me.cbxWithoutPriceLabelType.UseVisualStyleBackColor = True
        '
        'cbFixPriceTab
        '
        Me.cbFixPriceTab.AutoSize = True
        Me.cbFixPriceTab.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.cbFixPriceTab.Location = New System.Drawing.Point(18, 3)
        Me.cbFixPriceTab.Name = "cbFixPriceTab"
        Me.cbFixPriceTab.Size = New System.Drawing.Size(136, 16)
        Me.cbFixPriceTab.TabIndex = 131
        Me.cbFixPriceTab.Text = "Фиксировать эту вкладку"
        Me.cbFixPriceTab.UseVisualStyleBackColor = True
        '
        'btShowLabelAny2
        '
        Me.btShowLabelAny2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btShowLabelAny2.Location = New System.Drawing.Point(18, 297)
        Me.btShowLabelAny2.Name = "btShowLabelAny2"
        Me.btShowLabelAny2.Size = New System.Drawing.Size(75, 41)
        Me.btShowLabelAny2.TabIndex = 130
        Me.btShowLabelAny2.TabStop = False
        Me.btShowLabelAny2.Text = "просм. этик.$"
        Me.btShowLabelAny2.UseVisualStyleBackColor = True
        '
        'pbLabel2
        '
        Me.pbLabel2.Location = New System.Drawing.Point(208, 225)
        Me.pbLabel2.Name = "pbLabel2"
        Me.pbLabel2.Size = New System.Drawing.Size(202, 139)
        Me.pbLabel2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbLabel2.TabIndex = 129
        Me.pbLabel2.TabStop = False
        '
        'Label59
        '
        Me.Label59.AutoSize = True
        Me.Label59.Location = New System.Drawing.Point(286, 181)
        Me.Label59.Name = "Label59"
        Me.Label59.Size = New System.Drawing.Size(114, 13)
        Me.Label59.TabIndex = 128
        Me.Label59.Text = "рассчет от входящей"
        '
        'btRet4
        '
        Me.btRet4.Location = New System.Drawing.Point(377, 198)
        Me.btRet4.Name = "btRet4"
        Me.btRet4.Size = New System.Drawing.Size(33, 23)
        Me.btRet4.TabIndex = 127
        Me.btRet4.Text = "x4"
        Me.btRet4.UseVisualStyleBackColor = True
        '
        'btRet32
        '
        Me.btRet32.Location = New System.Drawing.Point(323, 198)
        Me.btRet32.Name = "btRet32"
        Me.btRet32.Size = New System.Drawing.Size(51, 23)
        Me.btRet32.TabIndex = 126
        Me.btRet32.Text = "x3.2"
        Me.btRet32.UseVisualStyleBackColor = True
        '
        'btImpMinus30
        '
        Me.btImpMinus30.Location = New System.Drawing.Point(285, 148)
        Me.btImpMinus30.Name = "btImpMinus30"
        Me.btImpMinus30.Size = New System.Drawing.Size(108, 23)
        Me.btImpMinus30.TabIndex = 125
        Me.btImpMinus30.Text = "calc. office (-30%)"
        Me.btImpMinus30.UseVisualStyleBackColor = True
        '
        'btImpPlus30
        '
        Me.btImpPlus30.Location = New System.Drawing.Point(289, 71)
        Me.btImpPlus30.Name = "btImpPlus30"
        Me.btImpPlus30.Size = New System.Drawing.Size(66, 23)
        Me.btImpPlus30.TabIndex = 124
        Me.btImpPlus30.Text = "calc. retail"
        Me.btImpPlus30.UseVisualStyleBackColor = True
        '
        'btRet2
        '
        Me.btRet2.Location = New System.Drawing.Point(285, 198)
        Me.btRet2.Name = "btRet2"
        Me.btRet2.Size = New System.Drawing.Size(33, 23)
        Me.btRet2.TabIndex = 123
        Me.btRet2.Text = "x2"
        Me.btRet2.UseVisualStyleBackColor = True
        '
        'btCallCalculator
        '
        Me.btCallCalculator.Location = New System.Drawing.Point(415, 319)
        Me.btCallCalculator.Name = "btCallCalculator"
        Me.btCallCalculator.Size = New System.Drawing.Size(238, 31)
        Me.btCallCalculator.TabIndex = 122
        Me.btCallCalculator.Text = "Калькулятор лотов"
        Me.btCallCalculator.UseVisualStyleBackColor = True
        '
        'btRusPlus30
        '
        Me.btRusPlus30.Location = New System.Drawing.Point(288, 46)
        Me.btRusPlus30.Name = "btRusPlus30"
        Me.btRusPlus30.Size = New System.Drawing.Size(90, 23)
        Me.btRusPlus30.TabIndex = 121
        Me.btRusPlus30.Text = "calc. розн."
        Me.btRusPlus30.UseVisualStyleBackColor = True
        '
        'btRusMinus30
        '
        Me.btRusMinus30.Location = New System.Drawing.Point(288, 21)
        Me.btRusMinus30.Name = "btRusMinus30"
        Me.btRusMinus30.Size = New System.Drawing.Size(108, 23)
        Me.btRusMinus30.TabIndex = 120
        Me.btRusMinus30.Text = "calc. офис (-30%)"
        Me.btRusMinus30.UseVisualStyleBackColor = True
        '
        'btSetPrices
        '
        Me.btSetPrices.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btSetPrices.Location = New System.Drawing.Point(364, 94)
        Me.btSetPrices.Name = "btSetPrices"
        Me.btSetPrices.Size = New System.Drawing.Size(48, 48)
        Me.btSetPrices.TabIndex = 119
        Me.btSetPrices.Text = "<<"
        Me.btSetPrices.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 56.61017!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.13559!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.91525!))
        Me.TableLayoutPanel1.Controls.Add(Me.Label13, 0, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.tbPRICE7, 1, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.tbPRICE6, 1, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.tbPRICE5, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.tbPRICE4, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.tbPRICE3, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label53, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.CR1, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.tbPRICE1, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label51, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label54, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Label55, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.Label56, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.Label57, 0, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.CR3, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.CR4, 2, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.CR5, 2, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.CR6, 2, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.CR7, 2, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.tbPrice8, 1, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.CR8cb, 2, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.tbPRICE2, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.CR2, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label52, 0, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(18, 20)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 8
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(263, 202)
        Me.TableLayoutPanel1.TabIndex = 118
        '
        'Label13
        '
        Me.Label13.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(3, 182)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(45, 13)
        Me.Label13.TabIndex = 128
        Me.Label13.Text = "Инвойс"
        '
        'tbPRICE7
        '
        Me.tbPRICE7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.tbPRICE7.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.UcPriceCalc_clsPriceDataBindingSource, "eBay", True))
        Me.tbPRICE7.Location = New System.Drawing.Point(153, 153)
        Me.tbPRICE7.Name = "tbPRICE7"
        Me.tbPRICE7.Size = New System.Drawing.Size(65, 20)
        Me.tbPRICE7.TabIndex = 125
        '
        'UcPriceCalc_clsPriceDataBindingSource
        '
        Me.UcPriceCalc_clsPriceDataBindingSource.DataSource = GetType(Service.ucPriceCalc.clsPriceData)
        '
        'tbPRICE6
        '
        Me.tbPRICE6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.tbPRICE6.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.UcPriceCalc_clsPriceDataBindingSource, "Eu_show", True))
        Me.tbPRICE6.Location = New System.Drawing.Point(153, 128)
        Me.tbPRICE6.Name = "tbPRICE6"
        Me.tbPRICE6.Size = New System.Drawing.Size(65, 20)
        Me.tbPRICE6.TabIndex = 124
        '
        'tbPRICE5
        '
        Me.tbPRICE5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.tbPRICE5.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.UcPriceCalc_clsPriceDataBindingSource, "Eu_post_paypal", True))
        Me.tbPRICE5.Location = New System.Drawing.Point(153, 103)
        Me.tbPRICE5.Name = "tbPRICE5"
        Me.tbPRICE5.Size = New System.Drawing.Size(65, 20)
        Me.tbPRICE5.TabIndex = 123
        '
        'tbPRICE4
        '
        Me.tbPRICE4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.tbPRICE4.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.UcPriceCalc_clsPriceDataBindingSource, "Eu_post_bank", True))
        Me.tbPRICE4.Location = New System.Drawing.Point(153, 78)
        Me.tbPRICE4.Name = "tbPRICE4"
        Me.tbPRICE4.Size = New System.Drawing.Size(65, 20)
        Me.tbPRICE4.TabIndex = 122
        '
        'tbPRICE3
        '
        Me.tbPRICE3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.tbPRICE3.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.UcPriceCalc_clsPriceDataBindingSource, "Eu_office", True))
        Me.tbPRICE3.Location = New System.Drawing.Point(153, 53)
        Me.tbPRICE3.Name = "tbPRICE3"
        Me.tbPRICE3.Size = New System.Drawing.Size(65, 20)
        Me.tbPRICE3.TabIndex = 121
        '
        'Label53
        '
        Me.Label53.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label53.AutoSize = True
        Me.Label53.Location = New System.Drawing.Point(3, 56)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(88, 13)
        Me.Label53.TabIndex = 2
        Me.Label53.Text = "Буржуи в офисе"
        '
        'CR1
        '
        Me.CR1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.CR1.AutoSize = True
        Me.CR1.Location = New System.Drawing.Point(226, 31)
        Me.CR1.Name = "CR1"
        Me.CR1.Size = New System.Drawing.Size(31, 13)
        Me.CR1.TabIndex = 14
        Me.CR1.Text = "RUR"
        Me.CR1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tbPRICE1
        '
        Me.tbPRICE1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.tbPRICE1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.UcPriceCalc_clsPriceDataBindingSource, "Rus_office", True))
        Me.tbPRICE1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.tbPRICE1.Location = New System.Drawing.Point(153, 28)
        Me.tbPRICE1.Name = "tbPRICE1"
        Me.tbPRICE1.Size = New System.Drawing.Size(65, 20)
        Me.tbPRICE1.TabIndex = 119
        '
        'Label51
        '
        Me.Label51.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label51.AutoSize = True
        Me.Label51.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label51.Location = New System.Drawing.Point(3, 31)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(136, 13)
        Me.Label51.TabIndex = 0
        Me.Label51.Text = "Россия в офисе(опорная)"
        '
        'Label54
        '
        Me.Label54.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label54.AutoSize = True
        Me.Label54.Location = New System.Drawing.Point(3, 81)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(117, 13)
        Me.Label54.TabIndex = 3
        Me.Label54.Text = "Почта оплата на банк"
        '
        'Label55
        '
        Me.Label55.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label55.AutoSize = True
        Me.Label55.Location = New System.Drawing.Point(3, 106)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(119, 13)
        Me.Label55.TabIndex = 4
        Me.Label55.Text = "Почта оплата PAYPAL"
        '
        'Label56
        '
        Me.Label56.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label56.AutoSize = True
        Me.Label56.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label56.Location = New System.Drawing.Point(3, 131)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(129, 13)
        Me.Label56.TabIndex = 5
        Me.Label56.Text = "Буржуи на выставке"
        '
        'Label57
        '
        Me.Label57.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label57.AutoSize = True
        Me.Label57.Location = New System.Drawing.Point(3, 156)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(31, 13)
        Me.Label57.TabIndex = 6
        Me.Label57.Text = "Ebay"
        '
        'CR3
        '
        Me.CR3.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.CR3.AutoSize = True
        Me.CR3.Location = New System.Drawing.Point(226, 56)
        Me.CR3.Name = "CR3"
        Me.CR3.Size = New System.Drawing.Size(30, 13)
        Me.CR3.TabIndex = 16
        Me.CR3.Text = "EUR"
        Me.CR3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CR4
        '
        Me.CR4.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.CR4.AutoSize = True
        Me.CR4.Location = New System.Drawing.Point(226, 81)
        Me.CR4.Name = "CR4"
        Me.CR4.Size = New System.Drawing.Size(30, 13)
        Me.CR4.TabIndex = 17
        Me.CR4.Text = "USD"
        Me.CR4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CR5
        '
        Me.CR5.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.CR5.AutoSize = True
        Me.CR5.Location = New System.Drawing.Point(226, 106)
        Me.CR5.Name = "CR5"
        Me.CR5.Size = New System.Drawing.Size(30, 13)
        Me.CR5.TabIndex = 18
        Me.CR5.Text = "USD"
        Me.CR5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CR6
        '
        Me.CR6.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.CR6.AutoSize = True
        Me.CR6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.CR6.Location = New System.Drawing.Point(226, 131)
        Me.CR6.Name = "CR6"
        Me.CR6.Size = New System.Drawing.Size(33, 13)
        Me.CR6.TabIndex = 19
        Me.CR6.Text = "EUR"
        Me.CR6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CR7
        '
        Me.CR7.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.CR7.AutoSize = True
        Me.CR7.Location = New System.Drawing.Point(226, 156)
        Me.CR7.Name = "CR7"
        Me.CR7.Size = New System.Drawing.Size(30, 13)
        Me.CR7.TabIndex = 20
        Me.CR7.Text = "USD"
        Me.CR7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tbPrice8
        '
        Me.tbPrice8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.tbPrice8.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.UcPriceCalc_clsPriceDataBindingSource, "Invoce", True))
        Me.tbPrice8.Location = New System.Drawing.Point(153, 178)
        Me.tbPrice8.Name = "tbPrice8"
        Me.tbPrice8.Size = New System.Drawing.Size(65, 20)
        Me.tbPrice8.TabIndex = 126
        '
        'CR8cb
        '
        Me.CR8cb.DataBindings.Add(New System.Windows.Forms.Binding("SelectedItem", Me.UcPriceCalc_clsPriceDataBindingSource, "InvoceCurrency", True))
        Me.CR8cb.FormattingEnabled = True
        Me.CR8cb.Items.AddRange(New Object() {"EUR", "RUR", "USD"})
        Me.CR8cb.Location = New System.Drawing.Point(226, 178)
        Me.CR8cb.Name = "CR8cb"
        Me.CR8cb.Size = New System.Drawing.Size(34, 21)
        Me.CR8cb.TabIndex = 129
        '
        'tbPRICE2
        '
        Me.tbPRICE2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.tbPRICE2.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.UcPriceCalc_clsPriceDataBindingSource, "Rus_show", True))
        Me.tbPRICE2.Location = New System.Drawing.Point(153, 3)
        Me.tbPRICE2.Name = "tbPRICE2"
        Me.tbPRICE2.Size = New System.Drawing.Size(65, 20)
        Me.tbPRICE2.TabIndex = 120
        '
        'CR2
        '
        Me.CR2.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.CR2.AutoSize = True
        Me.CR2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.CR2.Location = New System.Drawing.Point(226, 6)
        Me.CR2.Name = "CR2"
        Me.CR2.Size = New System.Drawing.Size(34, 13)
        Me.CR2.TabIndex = 15
        Me.CR2.Text = "RUR"
        Me.CR2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label52
        '
        Me.Label52.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label52.AutoSize = True
        Me.Label52.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label52.Location = New System.Drawing.Point(3, 6)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(140, 13)
        Me.Label52.TabIndex = 1
        Me.Label52.Text = "Россия в лавке (розн)"
        '
        'cbRoundPrices
        '
        Me.cbRoundPrices.AutoSize = True
        Me.cbRoundPrices.Checked = True
        Me.cbRoundPrices.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbRoundPrices.Location = New System.Drawing.Point(678, 314)
        Me.cbRoundPrices.Name = "cbRoundPrices"
        Me.cbRoundPrices.Size = New System.Drawing.Size(178, 17)
        Me.cbRoundPrices.TabIndex = 116
        Me.cbRoundPrices.Text = "Округлять цены при рассчете"
        Me.cbRoundPrices.UseVisualStyleBackColor = True
        '
        'btWritePrices
        '
        Me.btWritePrices.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btWritePrices.Location = New System.Drawing.Point(18, 230)
        Me.btWritePrices.Name = "btWritePrices"
        Me.btWritePrices.Size = New System.Drawing.Size(184, 59)
        Me.btWritePrices.TabIndex = 113
        Me.btWritePrices.Text = "Записать цены в карточку товара"
        Me.btWritePrices.UseVisualStyleBackColor = True
        '
        'UcPriceCalc1
        '
        Me.UcPriceCalc1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.UcPriceCalc1.Location = New System.Drawing.Point(413, 7)
        Me.UcPriceCalc1.Margin = New System.Windows.Forms.Padding(4)
        Me.UcPriceCalc1.Name = "UcPriceCalc1"
        Me.UcPriceCalc1.Size = New System.Drawing.Size(466, 300)
        Me.UcPriceCalc1.TabIndex = 112
        '
        'tpRfid
        '
        Me.tpRfid.Controls.Add(Me.cbFixTabRfid)
        Me.tpRfid.Controls.Add(Me.UcGoodLabel1)
        Me.tpRfid.Controls.Add(Me.cbx_UCAutoprintWithPrice)
        Me.tpRfid.Controls.Add(Me.bt_UCRequest)
        Me.tpRfid.Controls.Add(Me.UC_rfid1)
        Me.tpRfid.Location = New System.Drawing.Point(4, 22)
        Me.tpRfid.Name = "tpRfid"
        Me.tpRfid.Size = New System.Drawing.Size(885, 369)
        Me.tpRfid.TabIndex = 7
        Me.tpRfid.Text = "RFID/Этикетки"
        Me.tpRfid.UseVisualStyleBackColor = True
        '
        'cbFixTabRfid
        '
        Me.cbFixTabRfid.AutoSize = True
        Me.cbFixTabRfid.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.cbFixTabRfid.Location = New System.Drawing.Point(129, 7)
        Me.cbFixTabRfid.Name = "cbFixTabRfid"
        Me.cbFixTabRfid.Size = New System.Drawing.Size(136, 16)
        Me.cbFixTabRfid.TabIndex = 132
        Me.cbFixTabRfid.Text = "Фиксировать эту вкладку"
        Me.cbFixTabRfid.UseVisualStyleBackColor = True
        '
        'UcGoodLabel1
        '
        Me.UcGoodLabel1.Controls.Add(Me.BindingNavigatorImages)
        Me.UcGoodLabel1.Location = New System.Drawing.Point(295, 7)
        Me.UcGoodLabel1.Margin = New System.Windows.Forms.Padding(4)
        Me.UcGoodLabel1.Name = "UcGoodLabel1"
        Me.UcGoodLabel1.NameForLabel = Nothing
        Me.UcGoodLabel1.Size = New System.Drawing.Size(540, 262)
        Me.UcGoodLabel1.Source = Service.ucGoodLabel.emLabelSource.DrawAi
        Me.UcGoodLabel1.TabIndex = 3
        '
        'BindingNavigatorImages
        '
        Me.BindingNavigatorImages.AddNewItem = Nothing
        Me.BindingNavigatorImages.CountItem = Nothing
        Me.BindingNavigatorImages.DeleteItem = Nothing
        Me.BindingNavigatorImages.Dock = System.Windows.Forms.DockStyle.None
        Me.BindingNavigatorImages.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.BindingNavigatorImages.Location = New System.Drawing.Point(3, 67)
        Me.BindingNavigatorImages.MoveFirstItem = Nothing
        Me.BindingNavigatorImages.MoveLastItem = Nothing
        Me.BindingNavigatorImages.MoveNextItem = Nothing
        Me.BindingNavigatorImages.MovePreviousItem = Nothing
        Me.BindingNavigatorImages.Name = "BindingNavigatorImages"
        Me.BindingNavigatorImages.PositionItem = Nothing
        Me.BindingNavigatorImages.Size = New System.Drawing.Size(111, 25)
        Me.BindingNavigatorImages.TabIndex = 75
        Me.BindingNavigatorImages.Text = "BindingNavigator1"
        '
        'cbx_UCAutoprintWithPrice
        '
        Me.cbx_UCAutoprintWithPrice.AutoSize = True
        Me.cbx_UCAutoprintWithPrice.Location = New System.Drawing.Point(129, 28)
        Me.cbx_UCAutoprintWithPrice.Margin = New System.Windows.Forms.Padding(2)
        Me.cbx_UCAutoprintWithPrice.Name = "cbx_UCAutoprintWithPrice"
        Me.cbx_UCAutoprintWithPrice.Size = New System.Drawing.Size(126, 17)
        Me.cbx_UCAutoprintWithPrice.TabIndex = 2
        Me.cbx_UCAutoprintWithPrice.Text = "Автопечать с ценой"
        Me.cbx_UCAutoprintWithPrice.UseVisualStyleBackColor = True
        '
        'bt_UCRequest
        '
        Me.bt_UCRequest.Location = New System.Drawing.Point(8, 7)
        Me.bt_UCRequest.Margin = New System.Windows.Forms.Padding(2)
        Me.bt_UCRequest.Name = "bt_UCRequest"
        Me.bt_UCRequest.Size = New System.Drawing.Size(110, 38)
        Me.bt_UCRequest.TabIndex = 1
        Me.bt_UCRequest.Text = "запрос c RFID"
        Me.bt_UCRequest.UseVisualStyleBackColor = True
        '
        'UC_rfid1
        '
        Me.UC_rfid1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.UC_rfid1.Location = New System.Drawing.Point(7, 51)
        Me.UC_rfid1.Margin = New System.Windows.Forms.Padding(4)
        Me.UC_rfid1.Name = "UC_rfid1"
        Me.UC_rfid1.SampleNumber = ""
        Me.UC_rfid1.Size = New System.Drawing.Size(274, 274)
        Me.UC_rfid1.TabIndex = 0
        '
        'tpWareCells
        '
        Me.tpWareCells.Controls.Add(Me.Label14)
        Me.tpWareCells.Controls.Add(Me.GroupBox8)
        Me.tpWareCells.Controls.Add(Me.Label12)
        Me.tpWareCells.Controls.Add(Me.btCreateInventory)
        Me.tpWareCells.Controls.Add(Me.lbxSelectedNumbers)
        Me.tpWareCells.Controls.Add(Me.lbSlotInfo)
        Me.tpWareCells.Controls.Add(Me.lbSelectedSlotNumbers)
        Me.tpWareCells.Controls.Add(Me.btDeleteNumber)
        Me.tpWareCells.Controls.Add(Me.btAddToSelected)
        Me.tpWareCells.Controls.Add(Me.btToFreeLocation)
        Me.tpWareCells.Controls.Add(Me.btAddAllNumbers)
        Me.tpWareCells.Controls.Add(Me.btFromSlot)
        Me.tpWareCells.Controls.Add(Me.nudLabelsCountCopy)
        Me.tpWareCells.Controls.Add(Me.PictureBox1)
        Me.tpWareCells.Controls.Add(Me.btClearPrintJob)
        Me.tpWareCells.Controls.Add(Me.btPrintLabel)
        Me.tpWareCells.Controls.Add(Me.btAddLabel)
        Me.tpWareCells.Controls.Add(Me.pnLabel)
        Me.tpWareCells.Controls.Add(Me.btToSlot)
        Me.tpWareCells.Controls.Add(Me.lbSlotNumbers)
        Me.tpWareCells.Controls.Add(Me.lbxnumbers)
        Me.tpWareCells.Controls.Add(Me.lbCurrentSlot)
        Me.tpWareCells.Controls.Add(Me.lbSlotForPlacing)
        Me.tpWareCells.Controls.Add(Me.Label7)
        Me.tpWareCells.Controls.Add(Me.cbStoreForPlacing)
        Me.tpWareCells.Location = New System.Drawing.Point(4, 22)
        Me.tpWareCells.Name = "tpWareCells"
        Me.tpWareCells.Padding = New System.Windows.Forms.Padding(3)
        Me.tpWareCells.Size = New System.Drawing.Size(885, 369)
        Me.tpWareCells.TabIndex = 1
        Me.tpWareCells.Text = "Ячейки"
        Me.tpWareCells.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(733, 141)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(98, 13)
        Me.Label14.TabIndex = 65
        Me.Label14.Text = "сколько этикеток"
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.btAddCurrent)
        Me.GroupBox8.Controls.Add(Me.tbNumberForPlacing)
        Me.GroupBox8.Controls.Add(Me.btAddToPlacing)
        Me.GroupBox8.Location = New System.Drawing.Point(464, 6)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(126, 100)
        Me.GroupBox8.TabIndex = 64
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Добавить в список"
        '
        'btAddCurrent
        '
        Me.btAddCurrent.Location = New System.Drawing.Point(15, 18)
        Me.btAddCurrent.Name = "btAddCurrent"
        Me.btAddCurrent.Size = New System.Drawing.Size(100, 23)
        Me.btAddCurrent.TabIndex = 59
        Me.btAddCurrent.Text = "текущий №>>"
        Me.btAddCurrent.UseVisualStyleBackColor = True
        '
        'tbNumberForPlacing
        '
        Me.tbNumberForPlacing.Location = New System.Drawing.Point(15, 47)
        Me.tbNumberForPlacing.Name = "tbNumberForPlacing"
        Me.tbNumberForPlacing.Size = New System.Drawing.Size(100, 20)
        Me.tbNumberForPlacing.TabIndex = 7
        Me.tbNumberForPlacing.TabStop = False
        '
        'btAddToPlacing
        '
        Me.btAddToPlacing.Location = New System.Drawing.Point(15, 73)
        Me.btAddToPlacing.Name = "btAddToPlacing"
        Me.btAddToPlacing.Size = New System.Drawing.Size(100, 23)
        Me.btAddToPlacing.TabIndex = 8
        Me.btAddToPlacing.TabStop = False
        Me.btAddToPlacing.Text = "добавить>>"
        Me.btAddToPlacing.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(466, 112)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(138, 13)
        Me.Label12.TabIndex = 63
        Me.Label12.Text = "список для перемещения"
        '
        'btCreateInventory
        '
        Me.btCreateInventory.Location = New System.Drawing.Point(329, 105)
        Me.btCreateInventory.Name = "btCreateInventory"
        Me.btCreateInventory.Size = New System.Drawing.Size(119, 37)
        Me.btCreateInventory.TabIndex = 62
        Me.btCreateInventory.Text = "Создать инвентаризацию"
        Me.btCreateInventory.UseVisualStyleBackColor = True
        '
        'lbxSelectedNumbers
        '
        Me.lbxSelectedNumbers.DataSource = Me.bs_currentMove
        Me.lbxSelectedNumbers.DisplayMember = "SlotString"
        Me.lbxSelectedNumbers.FormattingEnabled = True
        Me.lbxSelectedNumbers.Location = New System.Drawing.Point(464, 130)
        Me.lbxSelectedNumbers.Name = "lbxSelectedNumbers"
        Me.lbxSelectedNumbers.Size = New System.Drawing.Size(120, 173)
        Me.lbxSelectedNumbers.TabIndex = 61
        '
        'bs_currentMove
        '
        Me.bs_currentMove.DataSource = GetType(Service.iMoySkladDataProvider.strGoodMapQty)
        '
        'lbSlotInfo
        '
        Me.lbSlotInfo.AutoSize = True
        Me.lbSlotInfo.Location = New System.Drawing.Point(468, 312)
        Me.lbSlotInfo.Name = "lbSlotInfo"
        Me.lbSlotInfo.Size = New System.Drawing.Size(24, 13)
        Me.lbSlotInfo.TabIndex = 60
        Me.lbSlotInfo.Text = "info"
        '
        'lbSelectedSlotNumbers
        '
        Me.lbSelectedSlotNumbers.AutoSize = True
        Me.lbSelectedSlotNumbers.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lbSelectedSlotNumbers.Location = New System.Drawing.Point(622, 244)
        Me.lbSelectedSlotNumbers.Name = "lbSelectedSlotNumbers"
        Me.lbSelectedSlotNumbers.Size = New System.Drawing.Size(51, 15)
        Me.lbSelectedSlotNumbers.TabIndex = 58
        Me.lbSelectedSlotNumbers.Text = "ячейку"
        '
        'btDeleteNumber
        '
        Me.btDeleteNumber.Location = New System.Drawing.Point(465, 337)
        Me.btDeleteNumber.Name = "btDeleteNumber"
        Me.btDeleteNumber.Size = New System.Drawing.Size(120, 23)
        Me.btDeleteNumber.TabIndex = 57
        Me.btDeleteNumber.TabStop = False
        Me.btDeleteNumber.Text = "удалить из списка"
        Me.btDeleteNumber.UseVisualStyleBackColor = True
        '
        'btAddToSelected
        '
        Me.btAddToSelected.Location = New System.Drawing.Point(329, 148)
        Me.btAddToSelected.Name = "btAddToSelected"
        Me.btAddToSelected.Size = New System.Drawing.Size(119, 23)
        Me.btAddToSelected.TabIndex = 56
        Me.btAddToSelected.Text = "в список перем. >>"
        Me.btAddToSelected.UseVisualStyleBackColor = True
        '
        'btToFreeLocation
        '
        Me.btToFreeLocation.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btToFreeLocation.Location = New System.Drawing.Point(329, 203)
        Me.btToFreeLocation.Name = "btToFreeLocation"
        Me.btToFreeLocation.Size = New System.Drawing.Size(119, 46)
        Me.btToFreeLocation.TabIndex = 54
        Me.btToFreeLocation.TabStop = False
        Me.btToFreeLocation.Text = "очистить ячейку (вынуть на склад)"
        Me.btToFreeLocation.UseVisualStyleBackColor = True
        '
        'btAddAllNumbers
        '
        Me.btAddAllNumbers.Location = New System.Drawing.Point(329, 256)
        Me.btAddAllNumbers.Name = "btAddAllNumbers"
        Me.btAddAllNumbers.Size = New System.Drawing.Size(119, 47)
        Me.btAddAllNumbers.TabIndex = 51
        Me.btAddAllNumbers.TabStop = False
        Me.btAddAllNumbers.Text = "Добавить все номера в печать"
        Me.btAddAllNumbers.UseVisualStyleBackColor = True
        '
        'btFromSlot
        '
        Me.btFromSlot.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btFromSlot.Location = New System.Drawing.Point(185, 39)
        Me.btFromSlot.Name = "btFromSlot"
        Me.btFromSlot.Size = New System.Drawing.Size(133, 36)
        Me.btFromSlot.TabIndex = 50
        Me.btFromSlot.TabStop = False
        Me.btFromSlot.Text = "в ячейке >>"
        Me.btFromSlot.UseVisualStyleBackColor = True
        '
        'nudLabelsCountCopy
        '
        Me.nudLabelsCountCopy.Location = New System.Drawing.Point(844, 138)
        Me.nudLabelsCountCopy.Name = "nudLabelsCountCopy"
        Me.nudLabelsCountCopy.Size = New System.Drawing.Size(35, 20)
        Me.nudLabelsCountCopy.TabIndex = 48
        Me.nudLabelsCountCopy.TabStop = False
        Me.nudLabelsCountCopy.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(150, 244)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(167, 119)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 47
        Me.PictureBox1.TabStop = False
        '
        'btClearPrintJob
        '
        Me.btClearPrintJob.Location = New System.Drawing.Point(733, 262)
        Me.btClearPrintJob.Name = "btClearPrintJob"
        Me.btClearPrintJob.Size = New System.Drawing.Size(147, 23)
        Me.btClearPrintJob.TabIndex = 45
        Me.btClearPrintJob.TabStop = False
        Me.btClearPrintJob.Text = "Очистить очередь печати"
        Me.btClearPrintJob.UseVisualStyleBackColor = True
        '
        'btPrintLabel
        '
        Me.btPrintLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btPrintLabel.Location = New System.Drawing.Point(733, 306)
        Me.btPrintLabel.Name = "btPrintLabel"
        Me.btPrintLabel.Size = New System.Drawing.Size(147, 54)
        Me.btPrintLabel.TabIndex = 44
        Me.btPrintLabel.TabStop = False
        Me.btPrintLabel.Text = "Печать этикеток"
        Me.btPrintLabel.UseVisualStyleBackColor = True
        '
        'btAddLabel
        '
        Me.btAddLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btAddLabel.Location = New System.Drawing.Point(733, 163)
        Me.btAddLabel.Name = "btAddLabel"
        Me.btAddLabel.Size = New System.Drawing.Size(147, 57)
        Me.btAddLabel.TabIndex = 33
        Me.btAddLabel.TabStop = False
        Me.btAddLabel.Text = "Добавить этикетку в список печати"
        Me.btAddLabel.UseVisualStyleBackColor = True
        '
        'pnLabel
        '
        Me.pnLabel.Location = New System.Drawing.Point(733, 8)
        Me.pnLabel.Name = "pnLabel"
        Me.pnLabel.Size = New System.Drawing.Size(147, 118)
        Me.pnLabel.TabIndex = 11
        '
        'btToSlot
        '
        Me.btToSlot.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btToSlot.Location = New System.Drawing.Point(587, 172)
        Me.btToSlot.Name = "btToSlot"
        Me.btToSlot.Size = New System.Drawing.Size(136, 67)
        Me.btToSlot.TabIndex = 10
        Me.btToSlot.TabStop = False
        Me.btToSlot.Text = "переместить по списку в"
        Me.btToSlot.UseVisualStyleBackColor = True
        '
        'lbSlotNumbers
        '
        Me.lbSlotNumbers.AutoSize = True
        Me.lbSlotNumbers.Location = New System.Drawing.Point(185, 86)
        Me.lbSlotNumbers.Name = "lbSlotNumbers"
        Me.lbSlotNumbers.Size = New System.Drawing.Size(51, 13)
        Me.lbSlotNumbers.TabIndex = 6
        Me.lbSlotNumbers.Text = "в ячейке"
        '
        'lbxnumbers
        '
        Me.lbxnumbers.DisplayMember = """SlotString"""
        Me.lbxnumbers.FormattingEnabled = True
        Me.lbxnumbers.Location = New System.Drawing.Point(185, 105)
        Me.lbxnumbers.Name = "lbxnumbers"
        Me.lbxnumbers.Size = New System.Drawing.Size(133, 134)
        Me.lbxnumbers.TabIndex = 5
        Me.lbxnumbers.TabStop = False
        '
        'lbCurrentSlot
        '
        Me.lbCurrentSlot.AutoSize = True
        Me.lbCurrentSlot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbCurrentSlot.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bs_Curr_slot_location, "ESlot", True))
        Me.lbCurrentSlot.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lbCurrentSlot.ForeColor = System.Drawing.Color.Red
        Me.lbCurrentSlot.Location = New System.Drawing.Point(254, 13)
        Me.lbCurrentSlot.Name = "lbCurrentSlot"
        Me.lbCurrentSlot.Size = New System.Drawing.Size(62, 18)
        Me.lbCurrentSlot.TabIndex = 4
        Me.lbCurrentSlot.Text = "ячейка"
        '
        'bs_Curr_slot_location
        '
        Me.bs_Curr_slot_location.AllowNew = False
        Me.bs_Curr_slot_location.DataMember = "SlotGood"
        Me.bs_Curr_slot_location.DataSource = Me.bs_Curr_stor_location
        '
        'bs_Curr_stor_location
        '
        Me.bs_Curr_stor_location.DataSource = GetType(RestMS_Client.clsGoodLocation)
        '
        'lbSlotForPlacing
        '
        Me.lbSlotForPlacing.DataSource = Me.bs_Curr_slot_location
        Me.lbSlotForPlacing.DisplayMember = "ESlot"
        Me.lbSlotForPlacing.FormattingEnabled = True
        Me.lbSlotForPlacing.Location = New System.Drawing.Point(16, 38)
        Me.lbSlotForPlacing.Name = "lbSlotForPlacing"
        Me.lbSlotForPlacing.Size = New System.Drawing.Size(108, 329)
        Me.lbSlotForPlacing.TabIndex = 3
        Me.lbSlotForPlacing.TabStop = False
        Me.lbSlotForPlacing.ValueMember = "SlotUUID"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(11, 15)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(37, 13)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "склад"
        '
        'cbStoreForPlacing
        '
        Me.cbStoreForPlacing.DataSource = Me.bs_Curr_stor_location
        Me.cbStoreForPlacing.DisplayMember = "Ewarehouse"
        Me.cbStoreForPlacing.FormattingEnabled = True
        Me.cbStoreForPlacing.Location = New System.Drawing.Point(54, 12)
        Me.cbStoreForPlacing.Name = "cbStoreForPlacing"
        Me.cbStoreForPlacing.Size = New System.Drawing.Size(185, 21)
        Me.cbStoreForPlacing.TabIndex = 0
        Me.cbStoreForPlacing.TabStop = False
        Me.cbStoreForPlacing.ValueMember = "WarehouseUUID"
        '
        'tpInfo
        '
        Me.tpInfo.Controls.Add(Me.Uc_trilbone_history1)
        Me.tpInfo.Location = New System.Drawing.Point(4, 22)
        Me.tpInfo.Name = "tpInfo"
        Me.tpInfo.Size = New System.Drawing.Size(885, 369)
        Me.tpInfo.TabIndex = 6
        Me.tpInfo.Text = "Info"
        Me.tpInfo.UseVisualStyleBackColor = True
        '
        'Uc_trilbone_history1
        '
        Me.Uc_trilbone_history1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Uc_trilbone_history1.Location = New System.Drawing.Point(0, 0)
        Me.Uc_trilbone_history1.Margin = New System.Windows.Forms.Padding(4)
        Me.Uc_trilbone_history1.Name = "Uc_trilbone_history1"
        Me.Uc_trilbone_history1.Size = New System.Drawing.Size(885, 369)
        Me.Uc_trilbone_history1.TabIndex = 0
        '
        'tpLotEnterTabPage
        '
        Me.tpLotEnterTabPage.Location = New System.Drawing.Point(4, 22)
        Me.tpLotEnterTabPage.Name = "tpLotEnterTabPage"
        Me.tpLotEnterTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.tpLotEnterTabPage.Size = New System.Drawing.Size(885, 369)
        Me.tpLotEnterTabPage.TabIndex = 4
        Me.tpLotEnterTabPage.Text = "                    "
        Me.tpLotEnterTabPage.UseVisualStyleBackColor = True
        '
        'tpAuctions
        '
        Me.tpAuctions.AutoScroll = True
        Me.tpAuctions.Controls.Add(Me.GroupBox2)
        Me.tpAuctions.Controls.Add(Me.RefTODataGridView)
        Me.tpAuctions.Controls.Add(Me.tbAuGetSampleList)
        Me.tpAuctions.Controls.Add(Me.GroupBox1)
        Me.tpAuctions.Controls.Add(Me.cbAuStoreList)
        Me.tpAuctions.Controls.Add(Me.Label16)
        Me.tpAuctions.Controls.Add(Me.Label15)
        Me.tpAuctions.Controls.Add(Me.cbAuAuctionList)
        Me.tpAuctions.Location = New System.Drawing.Point(4, 22)
        Me.tpAuctions.Name = "tpAuctions"
        Me.tpAuctions.Padding = New System.Windows.Forms.Padding(3)
        Me.tpAuctions.Size = New System.Drawing.Size(885, 369)
        Me.tpAuctions.TabIndex = 2
        Me.tpAuctions.Text = "подготовка к аукционам"
        Me.tpAuctions.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btAuctionUncompleted)
        Me.GroupBox2.Controls.Add(Me.lbAuctionStatus)
        Me.GroupBox2.Controls.Add(Me.btAuctionCompleted)
        Me.GroupBox2.Controls.Add(Me.lbAuctions)
        Me.GroupBox2.Location = New System.Drawing.Point(213, 31)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(193, 208)
        Me.GroupBox2.TabIndex = 49
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Аукционы"
        '
        'btAuctionUncompleted
        '
        Me.btAuctionUncompleted.Location = New System.Drawing.Point(6, 173)
        Me.btAuctionUncompleted.Name = "btAuctionUncompleted"
        Me.btAuctionUncompleted.Size = New System.Drawing.Size(176, 23)
        Me.btAuctionUncompleted.TabIndex = 32
        Me.btAuctionUncompleted.TabStop = False
        Me.btAuctionUncompleted.Text = "отметить не поготовленным"
        Me.btAuctionUncompleted.UseVisualStyleBackColor = True
        '
        'lbAuctionStatus
        '
        Me.lbAuctionStatus.AutoSize = True
        Me.lbAuctionStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lbAuctionStatus.Location = New System.Drawing.Point(9, 125)
        Me.lbAuctionStatus.Name = "lbAuctionStatus"
        Me.lbAuctionStatus.Size = New System.Drawing.Size(46, 13)
        Me.lbAuctionStatus.TabIndex = 33
        Me.lbAuctionStatus.Text = "статус"
        '
        'btAuctionCompleted
        '
        Me.btAuctionCompleted.Location = New System.Drawing.Point(8, 144)
        Me.btAuctionCompleted.Name = "btAuctionCompleted"
        Me.btAuctionCompleted.Size = New System.Drawing.Size(176, 23)
        Me.btAuctionCompleted.TabIndex = 31
        Me.btAuctionCompleted.TabStop = False
        Me.btAuctionCompleted.Text = "отметить поготовленным"
        Me.btAuctionCompleted.UseVisualStyleBackColor = True
        '
        'lbAuctions
        '
        Me.lbAuctions.FormattingEnabled = True
        Me.lbAuctions.Location = New System.Drawing.Point(6, 19)
        Me.lbAuctions.Name = "lbAuctions"
        Me.lbAuctions.Size = New System.Drawing.Size(120, 95)
        Me.lbAuctions.TabIndex = 29
        Me.lbAuctions.TabStop = False
        '
        'RefTODataGridView
        '
        Me.RefTODataGridView.AutoGenerateColumns = False
        Me.RefTODataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.RefTODataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn4})
        Me.RefTODataGridView.DataSource = Me.RefTOBindingSource
        Me.RefTODataGridView.Location = New System.Drawing.Point(644, 12)
        Me.RefTODataGridView.Name = "RefTODataGridView"
        Me.RefTODataGridView.Size = New System.Drawing.Size(220, 311)
        Me.RefTODataGridView.TabIndex = 6
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "code"
        Me.DataGridViewTextBoxColumn6.HeaderText = "code"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "name"
        Me.DataGridViewTextBoxColumn5.HeaderText = "name"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.Width = 300
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "objectType"
        Me.DataGridViewTextBoxColumn7.HeaderText = "objectType"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "uuid"
        Me.DataGridViewTextBoxColumn4.HeaderText = "uuid"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'RefTOBindingSource
        '
        Me.RefTOBindingSource.DataSource = GetType(RestMS_Client.SerialObj.refTO)
        '
        'tbAuGetSampleList
        '
        Me.tbAuGetSampleList.Location = New System.Drawing.Point(22, 217)
        Me.tbAuGetSampleList.Name = "tbAuGetSampleList"
        Me.tbAuGetSampleList.Size = New System.Drawing.Size(75, 23)
        Me.tbAuGetSampleList.TabIndex = 5
        Me.tbAuGetSampleList.TabStop = False
        Me.tbAuGetSampleList.Text = "запрос"
        Me.tbAuGetSampleList.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbUnReady)
        Me.GroupBox1.Controls.Add(Me.rbReady)
        Me.GroupBox1.Location = New System.Drawing.Point(19, 127)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(139, 64)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        '
        'rbUnReady
        '
        Me.rbUnReady.AutoSize = True
        Me.rbUnReady.Location = New System.Drawing.Point(6, 37)
        Me.rbUnReady.Name = "rbUnReady"
        Me.rbUnReady.Size = New System.Drawing.Size(121, 17)
        Me.rbUnReady.TabIndex = 1
        Me.rbUnReady.Text = "неподготовленные"
        Me.rbUnReady.UseVisualStyleBackColor = True
        '
        'rbReady
        '
        Me.rbReady.AutoSize = True
        Me.rbReady.Location = New System.Drawing.Point(6, 13)
        Me.rbReady.Name = "rbReady"
        Me.rbReady.Size = New System.Drawing.Size(109, 17)
        Me.rbReady.TabIndex = 0
        Me.rbReady.Text = "подготовленные"
        Me.rbReady.UseVisualStyleBackColor = True
        '
        'cbAuStoreList
        '
        Me.cbAuStoreList.FormattingEnabled = True
        Me.cbAuStoreList.Location = New System.Drawing.Point(19, 32)
        Me.cbAuStoreList.Name = "cbAuStoreList"
        Me.cbAuStoreList.Size = New System.Drawing.Size(121, 21)
        Me.cbAuStoreList.TabIndex = 3
        Me.cbAuStoreList.TabStop = False
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(19, 12)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(37, 13)
        Me.Label16.TabIndex = 2
        Me.Label16.Text = "склад"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(19, 70)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(48, 13)
        Me.Label15.TabIndex = 1
        Me.Label15.Text = "аукцион"
        '
        'cbAuAuctionList
        '
        Me.cbAuAuctionList.FormattingEnabled = True
        Me.cbAuAuctionList.Location = New System.Drawing.Point(19, 89)
        Me.cbAuAuctionList.Name = "cbAuAuctionList"
        Me.cbAuAuctionList.Size = New System.Drawing.Size(121, 21)
        Me.cbAuAuctionList.TabIndex = 0
        Me.cbAuAuctionList.TabStop = False
        '
        'ClsBulkEnterObjBindingSource
        '
        Me.ClsBulkEnterObjBindingSource.DataSource = GetType(RestMS_Client.clsBulkEnterObj)
        '
        'btAddWeightToName
        '
        Me.btAddWeightToName.Location = New System.Drawing.Point(784, 149)
        Me.btAddWeightToName.Name = "btAddWeightToName"
        Me.btAddWeightToName.Size = New System.Drawing.Size(93, 23)
        Me.btAddWeightToName.TabIndex = 83
        Me.btAddWeightToName.Text = "вес в название"
        Me.btAddWeightToName.UseVisualStyleBackColor = True
        '
        'cbAutoprint
        '
        Me.cbAutoprint.AutoSize = True
        Me.cbAutoprint.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.cbAutoprint.Location = New System.Drawing.Point(611, 28)
        Me.cbAutoprint.Name = "cbAutoprint"
        Me.cbAutoprint.Size = New System.Drawing.Size(85, 16)
        Me.cbAutoprint.TabIndex = 92
        Me.cbAutoprint.TabStop = False
        Me.cbAutoprint.Text = "Auto print label"
        Me.cbAutoprint.UseVisualStyleBackColor = True
        '
        'Label58
        '
        Me.Label58.AutoSize = True
        Me.Label58.Location = New System.Drawing.Point(908, 153)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(77, 13)
        Me.Label58.TabIndex = 93
        Me.Label58.Text = "Печатаю цену"
        '
        'cbPrintCurrency
        '
        Me.cbPrintCurrency.FormattingEnabled = True
        Me.cbPrintCurrency.Items.AddRange(New Object() {"Россия магазин", "Буржуи магазин", "eBay", "Инвойс", "Входящая"})
        Me.cbPrintCurrency.Location = New System.Drawing.Point(990, 149)
        Me.cbPrintCurrency.Name = "cbPrintCurrency"
        Me.cbPrintCurrency.Size = New System.Drawing.Size(132, 21)
        Me.cbPrintCurrency.TabIndex = 92
        '
        'lbWarning
        '
        Me.lbWarning.AutoSize = True
        Me.lbWarning.BackColor = System.Drawing.Color.Red
        Me.lbWarning.Location = New System.Drawing.Point(1052, 154)
        Me.lbWarning.Name = "lbWarning"
        Me.lbWarning.Size = New System.Drawing.Size(0, 13)
        Me.lbWarning.TabIndex = 16
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(755, 156)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(18, 13)
        Me.Label4.TabIndex = 115
        Me.Label4.Text = "кг"
        '
        'tbWeight
        '
        Me.tbWeight.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsCurrentGood, "Weight", True))
        Me.tbWeight.Location = New System.Drawing.Point(712, 152)
        Me.tbWeight.Name = "tbWeight"
        Me.tbWeight.Size = New System.Drawing.Size(37, 20)
        Me.tbWeight.TabIndex = 114
        Me.tbWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cbxNeedPhotos
        '
        Me.cbxNeedPhotos.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Me.bsCurrentGood, "NotHasPhoto", True))
        Me.cbxNeedPhotos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.cbxNeedPhotos.Location = New System.Drawing.Point(31, 508)
        Me.cbxNeedPhotos.Name = "cbxNeedPhotos"
        Me.cbxNeedPhotos.Size = New System.Drawing.Size(186, 25)
        Me.cbxNeedPhotos.TabIndex = 72
        Me.cbxNeedPhotos.TabStop = False
        Me.cbxNeedPhotos.Text = "Требуется сделать фотки"
        Me.cbxNeedPhotos.UseVisualStyleBackColor = True
        '
        'btLabel
        '
        Me.btLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btLabel.Location = New System.Drawing.Point(1145, 249)
        Me.btLabel.Name = "btLabel"
        Me.btLabel.Size = New System.Drawing.Size(74, 53)
        Me.btLabel.TabIndex = 52
        Me.btLabel.TabStop = False
        Me.btLabel.Text = "Этикетка б.ц."
        Me.btLabel.UseVisualStyleBackColor = True
        '
        'btLabelWithPrice
        '
        Me.btLabelWithPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btLabelWithPrice.Location = New System.Drawing.Point(1145, 308)
        Me.btLabelWithPrice.Name = "btLabelWithPrice"
        Me.btLabelWithPrice.Size = New System.Drawing.Size(74, 66)
        Me.btLabelWithPrice.TabIndex = 54
        Me.btLabelWithPrice.TabStop = False
        Me.btLabelWithPrice.Text = "Этикетка с ценой"
        Me.btLabelWithPrice.UseVisualStyleBackColor = True
        '
        'SalePricesBindingSource
        '
        Me.SalePricesBindingSource.DataSource = GetType(RestMS_Client.MoySkladAPI.price)
        '
        'btPrinterClear
        '
        Me.btPrinterClear.Location = New System.Drawing.Point(1137, 147)
        Me.btPrinterClear.Name = "btPrinterClear"
        Me.btPrinterClear.Size = New System.Drawing.Size(75, 47)
        Me.btPrinterClear.TabIndex = 0
        Me.btPrinterClear.TabStop = False
        Me.btPrinterClear.Text = "Сброс принтера"
        '
        'ClsMSGoodBindingSource
        '
        Me.ClsMSGoodBindingSource.DataSource = GetType(RestMS_Client.clsMSGood)
        '
        'cbRetailTargetCurrency
        '
        Me.cbRetailTargetCurrency.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.cbRetailTargetCurrency.FormattingEnabled = True
        Me.cbRetailTargetCurrency.Location = New System.Drawing.Point(594, 88)
        Me.cbRetailTargetCurrency.Name = "cbRetailTargetCurrency"
        Me.cbRetailTargetCurrency.Size = New System.Drawing.Size(52, 21)
        Me.cbRetailTargetCurrency.TabIndex = 13
        Me.cbRetailTargetCurrency.TabStop = False
        '
        'tbRetailTargetValue
        '
        Me.tbRetailTargetValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.tbRetailTargetValue.Location = New System.Drawing.Point(534, 89)
        Me.tbRetailTargetValue.Name = "tbRetailTargetValue"
        Me.tbRetailTargetValue.Size = New System.Drawing.Size(54, 20)
        Me.tbRetailTargetValue.TabIndex = 12
        Me.tbRetailTargetValue.TabStop = False
        Me.tbRetailTargetValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cbxSetRetail
        '
        Me.cbxSetRetail.AutoSize = True
        Me.cbxSetRetail.Location = New System.Drawing.Point(430, 91)
        Me.cbxSetRetail.Name = "cbxSetRetail"
        Me.cbxSetRetail.Size = New System.Drawing.Size(68, 17)
        Me.cbxSetRetail.TabIndex = 32
        Me.cbxSetRetail.TabStop = False
        Me.cbxSetRetail.Text = "розница"
        Me.cbxSetRetail.UseVisualStyleBackColor = True
        '
        'btSaveChanges
        '
        Me.btSaveChanges.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btSaveChanges.Location = New System.Drawing.Point(34, 307)
        Me.btSaveChanges.Name = "btSaveChanges"
        Me.btSaveChanges.Size = New System.Drawing.Size(167, 49)
        Me.btSaveChanges.TabIndex = 23
        Me.btSaveChanges.TabStop = False
        Me.btSaveChanges.Text = "Сохранить изменения в карточке товара"
        Me.btSaveChanges.UseVisualStyleBackColor = True
        '
        'btClear
        '
        Me.btClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btClear.Location = New System.Drawing.Point(240, 31)
        Me.btClear.Name = "btClear"
        Me.btClear.Size = New System.Drawing.Size(120, 25)
        Me.btClear.TabIndex = 2
        Me.btClear.TabStop = False
        Me.btClear.Text = "очистить все"
        Me.btClear.UseVisualStyleBackColor = True
        '
        'btSearchInSklad
        '
        Me.btSearchInSklad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btSearchInSklad.Location = New System.Drawing.Point(142, 3)
        Me.btSearchInSklad.Name = "btSearchInSklad"
        Me.btSearchInSklad.Size = New System.Drawing.Size(92, 51)
        Me.btSearchInSklad.TabIndex = 1
        Me.btSearchInSklad.TabStop = False
        Me.btSearchInSklad.Text = "Запрос"
        Me.btSearchInSklad.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(0, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Номер(Код)"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(311, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Артикул"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label3.Location = New System.Drawing.Point(5, 44)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 12)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Название"
        '
        'tbNumber
        '
        Me.tbNumber.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsCurrentGood, "Code", True))
        Me.tbNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.tbNumber.Location = New System.Drawing.Point(72, 6)
        Me.tbNumber.Name = "tbNumber"
        Me.tbNumber.Size = New System.Drawing.Size(61, 22)
        Me.tbNumber.TabIndex = 0
        Me.tbNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbArticul
        '
        Me.tbArticul.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsCurrentGood, "Articul", True))
        Me.tbArticul.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.tbArticul.Location = New System.Drawing.Point(365, 6)
        Me.tbArticul.Name = "tbArticul"
        Me.tbArticul.Size = New System.Drawing.Size(61, 22)
        Me.tbArticul.TabIndex = 5
        Me.tbArticul.TabStop = False
        Me.tbArticul.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbName
        '
        Me.tbName.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsCurrentGood, "Name", True))
        Me.tbName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.tbName.Location = New System.Drawing.Point(6, 60)
        Me.tbName.Multiline = True
        Me.tbName.Name = "tbName"
        Me.tbName.Size = New System.Drawing.Size(420, 61)
        Me.tbName.TabIndex = 7
        Me.tbName.TabStop = False
        '
        'tbBarCode
        '
        Me.tbBarCode.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsCurrentGood, "Barcode", True))
        Me.tbBarCode.Location = New System.Drawing.Point(366, 34)
        Me.tbBarCode.Name = "tbBarCode"
        Me.tbBarCode.Size = New System.Drawing.Size(97, 20)
        Me.tbBarCode.TabIndex = 8
        Me.tbBarCode.TabStop = False
        Me.tbBarCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cbTargetStores
        '
        Me.cbTargetStores.DataSource = Me.bs_GoodLocation
        Me.cbTargetStores.DisplayMember = "Ewarehouse"
        Me.cbTargetStores.FormattingEnabled = True
        Me.cbTargetStores.Location = New System.Drawing.Point(48, 150)
        Me.cbTargetStores.Name = "cbTargetStores"
        Me.cbTargetStores.Size = New System.Drawing.Size(169, 21)
        Me.cbTargetStores.TabIndex = 19
        Me.cbTargetStores.TabStop = False
        Me.cbTargetStores.ValueMember = "WarehouseUUID"
        '
        'bs_GoodLocation
        '
        Me.bs_GoodLocation.DataMember = "Locations"
        Me.bs_GoodLocation.DataSource = Me.bsCurrentGood
        '
        'SlotGoodBindingSource
        '
        Me.SlotGoodBindingSource.AllowNew = False
        Me.SlotGoodBindingSource.DataMember = "SlotGood"
        Me.SlotGoodBindingSource.DataSource = Me.bs_GoodLocation
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(1044, 1)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(57, 13)
        Me.Label8.TabIndex = 9
        Me.Label8.Text = "Описание"
        '
        'rtbDescription
        '
        Me.rtbDescription.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsCurrentGood, "Description", True))
        Me.rtbDescription.Enabled = False
        Me.rtbDescription.Location = New System.Drawing.Point(975, 16)
        Me.rtbDescription.Name = "rtbDescription"
        Me.rtbDescription.Size = New System.Drawing.Size(234, 64)
        Me.rtbDescription.TabIndex = 10
        Me.rtbDescription.TabStop = False
        Me.rtbDescription.Text = ""
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(4, 154)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(37, 13)
        Me.Label9.TabIndex = 23
        Me.Label9.Text = "склад"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(317, 154)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(42, 13)
        Me.Label10.TabIndex = 25
        Me.Label10.Text = "ячейка"
        '
        'cbSlot
        '
        Me.cbSlot.DataSource = Me.SlotGoodBindingSource
        Me.cbSlot.DisplayMember = "ESlot"
        Me.cbSlot.FormattingEnabled = True
        Me.cbSlot.Location = New System.Drawing.Point(363, 150)
        Me.cbSlot.Name = "cbSlot"
        Me.cbSlot.Size = New System.Drawing.Size(85, 21)
        Me.cbSlot.TabIndex = 24
        Me.cbSlot.TabStop = False
        Me.cbSlot.ValueMember = "SlotUUID"
        '
        'btAddGoodToWare
        '
        Me.btAddGoodToWare.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btAddGoodToWare.Location = New System.Drawing.Point(906, 92)
        Me.btAddGoodToWare.Name = "btAddGoodToWare"
        Me.btAddGoodToWare.Size = New System.Drawing.Size(81, 47)
        Me.btAddGoodToWare.TabIndex = 29
        Me.btAddGoodToWare.Text = "2." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "На склад"
        Me.btAddGoodToWare.UseVisualStyleBackColor = True
        '
        'tbQty
        '
        Me.tbQty.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.SlotGoodBindingSource, "Qty", True))
        Me.tbQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.tbQty.Location = New System.Drawing.Point(538, 148)
        Me.tbQty.Name = "tbQty"
        Me.tbQty.Size = New System.Drawing.Size(52, 24)
        Me.tbQty.TabIndex = 30
        Me.tbQty.TabStop = False
        Me.tbQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cbxWithoutSlot
        '
        Me.cbxWithoutSlot.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.cbxWithoutSlot.Location = New System.Drawing.Point(228, 153)
        Me.cbxWithoutSlot.Name = "cbxWithoutSlot"
        Me.cbxWithoutSlot.Size = New System.Drawing.Size(83, 17)
        Me.cbxWithoutSlot.TabIndex = 31
        Me.cbxWithoutSlot.TabStop = False
        Me.cbxWithoutSlot.Text = "без ячейки"
        Me.cbxWithoutSlot.UseVisualStyleBackColor = True
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'PrintPreviewDialog1
        '
        Me.PrintPreviewDialog1.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.ClientSize = New System.Drawing.Size(400, 300)
        Me.PrintPreviewDialog1.Enabled = True
        Me.PrintPreviewDialog1.Icon = CType(resources.GetObject("PrintPreviewDialog1.Icon"), System.Drawing.Icon)
        Me.PrintPreviewDialog1.Name = "PrintPreviewDialog1"
        Me.PrintPreviewDialog1.Visible = False
        '
        'btCreateGood
        '
        Me.btCreateGood.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btCreateGood.Location = New System.Drawing.Point(825, 92)
        Me.btCreateGood.Name = "btCreateGood"
        Me.btCreateGood.Size = New System.Drawing.Size(75, 47)
        Me.btCreateGood.TabIndex = 44
        Me.btCreateGood.Text = "1. Карточка"
        Me.btCreateGood.UseVisualStyleBackColor = True
        '
        'btHide
        '
        Me.btHide.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btHide.Location = New System.Drawing.Point(7, 540)
        Me.btHide.Name = "btHide"
        Me.btHide.Size = New System.Drawing.Size(228, 35)
        Me.btHide.TabIndex = 45
        Me.btHide.TabStop = False
        Me.btHide.Text = "Скрыть окно"
        Me.btHide.UseVisualStyleBackColor = True
        '
        'btOnePcs
        '
        Me.btOnePcs.Location = New System.Drawing.Point(504, 149)
        Me.btOnePcs.Name = "btOnePcs"
        Me.btOnePcs.Size = New System.Drawing.Size(27, 23)
        Me.btOnePcs.TabIndex = 46
        Me.btOnePcs.TabStop = False
        Me.btOnePcs.Text = "+1"
        Me.btOnePcs.UseVisualStyleBackColor = True
        '
        'btServiceForm
        '
        Me.btServiceForm.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btServiceForm.Location = New System.Drawing.Point(1137, 500)
        Me.btServiceForm.Name = "btServiceForm"
        Me.btServiceForm.Size = New System.Drawing.Size(75, 35)
        Me.btServiceForm.TabIndex = 47
        Me.btServiceForm.TabStop = False
        Me.btServiceForm.Text = "служебная"
        Me.btServiceForm.UseVisualStyleBackColor = True
        '
        'cbxAddIfExists
        '
        Me.cbxAddIfExists.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.cbxAddIfExists.Location = New System.Drawing.Point(24, 179)
        Me.cbxAddIfExists.Name = "cbxAddIfExists"
        Me.cbxAddIfExists.Size = New System.Drawing.Size(199, 36)
        Me.cbxAddIfExists.TabIndex = 50
        Me.cbxAddIfExists.TabStop = False
        Me.cbxAddIfExists.Text = "добавить к имеющимся остаткам"
        Me.cbxAddIfExists.UseVisualStyleBackColor = True
        '
        'SlotListBindingSource
        '
        Me.SlotListBindingSource.DataMember = "SlotList"
        Me.SlotListBindingSource.DataSource = Me.bsCurrentGood
        '
        'btNewNumber
        '
        Me.btNewNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btNewNumber.Location = New System.Drawing.Point(479, 28)
        Me.btNewNumber.Name = "btNewNumber"
        Me.btNewNumber.Size = New System.Drawing.Size(117, 23)
        Me.btNewNumber.TabIndex = 55
        Me.btNewNumber.TabStop = False
        Me.btNewNumber.Text = "получить номер"
        Me.btNewNumber.UseVisualStyleBackColor = True
        '
        'cbxFixStore
        '
        Me.cbxFixStore.AutoSize = True
        Me.cbxFixStore.Location = New System.Drawing.Point(49, 127)
        Me.cbxFixStore.Name = "cbxFixStore"
        Me.cbxFixStore.Size = New System.Drawing.Size(126, 17)
        Me.cbxFixStore.TabIndex = 57
        Me.cbxFixStore.TabStop = False
        Me.cbxFixStore.Text = "фиксировать склад"
        Me.cbxFixStore.UseVisualStyleBackColor = True
        '
        'cbxFixCurrency
        '
        Me.cbxFixCurrency.AutoSize = True
        Me.cbxFixCurrency.Location = New System.Drawing.Point(611, 6)
        Me.cbxFixCurrency.Name = "cbxFixCurrency"
        Me.cbxFixCurrency.Size = New System.Drawing.Size(94, 17)
        Me.cbxFixCurrency.TabIndex = 58
        Me.cbxFixCurrency.TabStop = False
        Me.cbxFixCurrency.Text = "фикс. валюту"
        Me.cbxFixCurrency.UseVisualStyleBackColor = True
        '
        'cbxFixSeries
        '
        Me.cbxFixSeries.AutoSize = True
        Me.cbxFixSeries.Location = New System.Drawing.Point(479, 5)
        Me.cbxFixSeries.Name = "cbxFixSeries"
        Me.cbxFixSeries.Size = New System.Drawing.Size(125, 17)
        Me.cbxFixSeries.TabIndex = 60
        Me.cbxFixSeries.TabStop = False
        Me.cbxFixSeries.Text = "фик. серию номера"
        Me.cbxFixSeries.UseVisualStyleBackColor = True
        '
        'btLoadTree
        '
        Me.btLoadTree.Location = New System.Drawing.Point(804, 1)
        Me.btLoadTree.Name = "btLoadTree"
        Me.btLoadTree.Size = New System.Drawing.Size(161, 25)
        Me.btLoadTree.TabIndex = 61
        Me.btLoadTree.TabStop = False
        Me.btLoadTree.Text = "Загрузить названия.."
        Me.btLoadTree.UseVisualStyleBackColor = True
        '
        'cbMaterial
        '
        Me.cbMaterial.FormattingEnabled = True
        Me.cbMaterial.Location = New System.Drawing.Point(804, 30)
        Me.cbMaterial.Name = "cbMaterial"
        Me.cbMaterial.Size = New System.Drawing.Size(161, 21)
        Me.cbMaterial.TabIndex = 62
        Me.cbMaterial.TabStop = False
        '
        'cbListOfTree
        '
        Me.cbListOfTree.FormattingEnabled = True
        Me.cbListOfTree.Location = New System.Drawing.Point(804, 60)
        Me.cbListOfTree.Name = "cbListOfTree"
        Me.cbListOfTree.Size = New System.Drawing.Size(162, 21)
        Me.cbListOfTree.TabIndex = 63
        Me.cbListOfTree.TabStop = False
        '
        'cbDBNames
        '
        Me.cbDBNames.FormattingEnabled = True
        Me.cbDBNames.Location = New System.Drawing.Point(494, 60)
        Me.cbDBNames.Name = "cbDBNames"
        Me.cbDBNames.Size = New System.Drawing.Size(305, 21)
        Me.cbDBNames.TabIndex = 64
        Me.cbDBNames.TabStop = False
        '
        'rbEnglish
        '
        Me.rbEnglish.AutoSize = True
        Me.rbEnglish.Checked = True
        Me.rbEnglish.Location = New System.Drawing.Point(731, 9)
        Me.rbEnglish.Name = "rbEnglish"
        Me.rbEnglish.Size = New System.Drawing.Size(59, 17)
        Me.rbEnglish.TabIndex = 66
        Me.rbEnglish.TabStop = True
        Me.rbEnglish.Text = "English"
        Me.rbEnglish.UseVisualStyleBackColor = True
        '
        'rbRussian
        '
        Me.rbRussian.AutoSize = True
        Me.rbRussian.Location = New System.Drawing.Point(731, 31)
        Me.rbRussian.Name = "rbRussian"
        Me.rbRussian.Size = New System.Drawing.Size(67, 17)
        Me.rbRussian.TabIndex = 65
        Me.rbRussian.Text = "Русский"
        Me.rbRussian.UseVisualStyleBackColor = True
        '
        'btCopyNameFromTrees
        '
        Me.btCopyNameFromTrees.Location = New System.Drawing.Point(431, 58)
        Me.btCopyNameFromTrees.Name = "btCopyNameFromTrees"
        Me.btCopyNameFromTrees.Size = New System.Drawing.Size(29, 23)
        Me.btCopyNameFromTrees.TabIndex = 67
        Me.btCopyNameFromTrees.TabStop = False
        Me.btCopyNameFromTrees.Text = "<<"
        Me.btCopyNameFromTrees.UseVisualStyleBackColor = True
        '
        'btCheckCodes
        '
        Me.btCheckCodes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btCheckCodes.Location = New System.Drawing.Point(1137, 555)
        Me.btCheckCodes.Name = "btCheckCodes"
        Me.btCheckCodes.Size = New System.Drawing.Size(75, 23)
        Me.btCheckCodes.TabIndex = 70
        Me.btCheckCodes.TabStop = False
        Me.btCheckCodes.Text = "пров. EAN"
        Me.btCheckCodes.UseVisualStyleBackColor = True
        '
        'cbUom
        '
        Me.cbUom.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.cbUom.FormattingEnabled = True
        Me.cbUom.Location = New System.Drawing.Point(597, 147)
        Me.cbUom.Name = "cbUom"
        Me.cbUom.Size = New System.Drawing.Size(49, 26)
        Me.cbUom.TabIndex = 71
        Me.cbUom.TabStop = False
        '
        'btMoveToArticul
        '
        Me.btMoveToArticul.Location = New System.Drawing.Point(247, 5)
        Me.btMoveToArticul.Name = "btMoveToArticul"
        Me.btMoveToArticul.Size = New System.Drawing.Size(26, 23)
        Me.btMoveToArticul.TabIndex = 72
        Me.btMoveToArticul.TabStop = False
        Me.btMoveToArticul.Text = ">"
        Me.btMoveToArticul.UseVisualStyleBackColor = True
        '
        'btSubNumberPlus
        '
        Me.btSubNumberPlus.Location = New System.Drawing.Point(431, 6)
        Me.btSubNumberPlus.Name = "btSubNumberPlus"
        Me.btSubNumberPlus.Size = New System.Drawing.Size(15, 23)
        Me.btSubNumberPlus.TabIndex = 73
        Me.btSubNumberPlus.TabStop = False
        Me.btSubNumberPlus.Text = "+"
        Me.btSubNumberPlus.UseVisualStyleBackColor = True
        '
        'btSubNumberMinus
        '
        Me.btSubNumberMinus.Location = New System.Drawing.Point(449, 6)
        Me.btSubNumberMinus.Name = "btSubNumberMinus"
        Me.btSubNumberMinus.Size = New System.Drawing.Size(15, 23)
        Me.btSubNumberMinus.TabIndex = 74
        Me.btSubNumberMinus.TabStop = False
        Me.btSubNumberMinus.Text = "-"
        Me.btSubNumberMinus.UseVisualStyleBackColor = True
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(12, 222)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(163, 13)
        Me.Label32.TabIndex = 75
        Me.Label32.Text = "Остатки по товару на складах:"
        '
        'tbBuyTargetValue
        '
        Me.tbBuyTargetValue.Location = New System.Drawing.Point(534, 119)
        Me.tbBuyTargetValue.Name = "tbBuyTargetValue"
        Me.tbBuyTargetValue.Size = New System.Drawing.Size(54, 20)
        Me.tbBuyTargetValue.TabIndex = 76
        Me.tbBuyTargetValue.TabStop = False
        Me.tbBuyTargetValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cbxSetBuy
        '
        Me.cbxSetBuy.AutoSize = True
        Me.cbxSetBuy.Location = New System.Drawing.Point(430, 121)
        Me.cbxSetBuy.Name = "cbxSetBuy"
        Me.cbxSetBuy.Size = New System.Drawing.Size(67, 17)
        Me.cbxSetBuy.TabIndex = 77
        Me.cbxSetBuy.TabStop = False
        Me.cbxSetBuy.Text = "входящ."
        Me.cbxSetBuy.UseVisualStyleBackColor = True
        '
        'cbBuyTargetCurrency
        '
        Me.cbBuyTargetCurrency.FormattingEnabled = True
        Me.cbBuyTargetCurrency.Location = New System.Drawing.Point(594, 119)
        Me.cbBuyTargetCurrency.Name = "cbBuyTargetCurrency"
        Me.cbBuyTargetCurrency.Size = New System.Drawing.Size(52, 21)
        Me.cbBuyTargetCurrency.TabIndex = 78
        Me.cbBuyTargetCurrency.TabStop = False
        '
        'btMoveToCode
        '
        Me.btMoveToCode.Location = New System.Drawing.Point(276, 5)
        Me.btMoveToCode.Name = "btMoveToCode"
        Me.btMoveToCode.Size = New System.Drawing.Size(26, 23)
        Me.btMoveToCode.TabIndex = 79
        Me.btMoveToCode.TabStop = False
        Me.btMoveToCode.Text = "<"
        Me.btMoveToCode.UseVisualStyleBackColor = True
        '
        'btOption
        '
        Me.btOption.Location = New System.Drawing.Point(1137, 454)
        Me.btOption.Name = "btOption"
        Me.btOption.Size = New System.Drawing.Size(75, 35)
        Me.btOption.TabIndex = 80
        Me.btOption.TabStop = False
        Me.btOption.Text = "Настройки"
        Me.btOption.UseVisualStyleBackColor = True
        '
        'cbLocations
        '
        Me.cbLocations.DataSource = Me.SlotListBindingSource
        Me.cbLocations.DisplayMember = "SlotString"
        Me.cbLocations.FormattingEnabled = True
        Me.cbLocations.Location = New System.Drawing.Point(0, 243)
        Me.cbLocations.Name = "cbLocations"
        Me.cbLocations.Size = New System.Drawing.Size(234, 56)
        Me.cbLocations.TabIndex = 81
        Me.cbLocations.TabStop = False
        Me.cbLocations.ValueMember = "SlotUUID"
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Location = New System.Drawing.Point(992, 89)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(91, 13)
        Me.Label41.TabIndex = 82
        Me.Label41.Text = "Код узла дерева"
        '
        'tbMyTreeCode
        '
        Me.tbMyTreeCode.Location = New System.Drawing.Point(1090, 86)
        Me.tbMyTreeCode.Name = "tbMyTreeCode"
        Me.tbMyTreeCode.Size = New System.Drawing.Size(119, 20)
        Me.tbMyTreeCode.TabIndex = 83
        Me.tbMyTreeCode.TabStop = False
        '
        'btOpenTreeForm
        '
        Me.btOpenTreeForm.Enabled = False
        Me.btOpenTreeForm.Location = New System.Drawing.Point(1107, 114)
        Me.btOpenTreeForm.Name = "btOpenTreeForm"
        Me.btOpenTreeForm.Size = New System.Drawing.Size(99, 23)
        Me.btOpenTreeForm.TabIndex = 84
        Me.btOpenTreeForm.TabStop = False
        Me.btOpenTreeForm.Text = "Открыть дерево"
        Me.btOpenTreeForm.UseVisualStyleBackColor = True
        '
        'btAddNameFromTree
        '
        Me.btAddNameFromTree.Location = New System.Drawing.Point(465, 58)
        Me.btAddNameFromTree.Name = "btAddNameFromTree"
        Me.btAddNameFromTree.Size = New System.Drawing.Size(23, 23)
        Me.btAddNameFromTree.TabIndex = 85
        Me.btAddNameFromTree.TabStop = False
        Me.btAddNameFromTree.Text = "+"
        Me.btAddNameFromTree.UseVisualStyleBackColor = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(998, 115)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(100, 23)
        Me.ProgressBar1.TabIndex = 89
        '
        'StatusStrip1
        '
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.lbToolWarning})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 580)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1229, 22)
        Me.StatusStrip1.TabIndex = 90
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(0, 17)
        '
        'lbToolWarning
        '
        Me.lbToolWarning.Name = "lbToolWarning"
        Me.lbToolWarning.Size = New System.Drawing.Size(0, 17)
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label46.Location = New System.Drawing.Point(451, 154)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(47, 13)
        Me.Label46.TabIndex = 92
        Me.Label46.Text = "Кол-во"
        '
        'lbRetail
        '
        Me.lbRetail.AutoSize = True
        Me.lbRetail.Location = New System.Drawing.Point(505, 93)
        Me.lbRetail.Name = "lbRetail"
        Me.lbRetail.Size = New System.Drawing.Size(19, 13)
        Me.lbRetail.TabIndex = 93
        Me.lbRetail.Text = "kp"
        '
        'lbIncoming
        '
        Me.lbIncoming.AutoSize = True
        Me.lbIncoming.Location = New System.Drawing.Point(506, 122)
        Me.lbIncoming.Name = "lbIncoming"
        Me.lbIncoming.Size = New System.Drawing.Size(19, 13)
        Me.lbIncoming.TabIndex = 94
        Me.lbIncoming.Text = "kp"
        '
        'btNumberMinus
        '
        Me.btNumberMinus.Location = New System.Drawing.Point(99, 32)
        Me.btNumberMinus.Name = "btNumberMinus"
        Me.btNumberMinus.Size = New System.Drawing.Size(15, 23)
        Me.btNumberMinus.TabIndex = 96
        Me.btNumberMinus.TabStop = False
        Me.btNumberMinus.Text = "-"
        Me.btNumberMinus.UseVisualStyleBackColor = True
        '
        'btNumberPlus
        '
        Me.btNumberPlus.Location = New System.Drawing.Point(118, 32)
        Me.btNumberPlus.Name = "btNumberPlus"
        Me.btNumberPlus.Size = New System.Drawing.Size(15, 23)
        Me.btNumberPlus.TabIndex = 95
        Me.btNumberPlus.TabStop = False
        Me.btNumberPlus.Text = "+"
        Me.btNumberPlus.UseVisualStyleBackColor = True
        '
        'btRoundRetailPrice
        '
        Me.btRoundRetailPrice.Location = New System.Drawing.Point(652, 88)
        Me.btRoundRetailPrice.Name = "btRoundRetailPrice"
        Me.btRoundRetailPrice.Size = New System.Drawing.Size(15, 23)
        Me.btRoundRetailPrice.TabIndex = 97
        Me.btRoundRetailPrice.TabStop = False
        Me.btRoundRetailPrice.Text = "o"
        Me.btRoundRetailPrice.UseVisualStyleBackColor = True
        '
        'btClear2
        '
        Me.btClear2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btClear2.Location = New System.Drawing.Point(1137, 391)
        Me.btClear2.Name = "btClear2"
        Me.btClear2.Size = New System.Drawing.Size(75, 54)
        Me.btClear2.TabIndex = 99
        Me.btClear2.TabStop = False
        Me.btClear2.Text = "Очистить все"
        '
        'pbImage
        '
        Me.pbImage.Location = New System.Drawing.Point(16, 366)
        Me.pbImage.Name = "pbImage"
        Me.pbImage.Size = New System.Drawing.Size(202, 139)
        Me.pbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbImage.TabIndex = 100
        Me.pbImage.TabStop = False
        '
        'cbInvoceCurrency
        '
        Me.cbInvoceCurrency.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.cbInvoceCurrency.FormattingEnabled = True
        Me.cbInvoceCurrency.Location = New System.Drawing.Point(772, 120)
        Me.cbInvoceCurrency.Name = "cbInvoceCurrency"
        Me.cbInvoceCurrency.Size = New System.Drawing.Size(46, 20)
        Me.cbInvoceCurrency.TabIndex = 113
        Me.cbInvoceCurrency.TabStop = False
        '
        'tbInvoice
        '
        Me.tbInvoice.Location = New System.Drawing.Point(707, 120)
        Me.tbInvoice.Name = "tbInvoice"
        Me.tbInvoice.Size = New System.Drawing.Size(59, 20)
        Me.tbInvoice.TabIndex = 112
        Me.tbInvoice.TabStop = False
        Me.tbInvoice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cbxInvoice
        '
        Me.cbxInvoice.AutoSize = True
        Me.cbxInvoice.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.cbxInvoice.Location = New System.Drawing.Point(651, 122)
        Me.cbxInvoice.Name = "cbxInvoice"
        Me.cbxInvoice.Size = New System.Drawing.Size(54, 16)
        Me.cbxInvoice.TabIndex = 114
        Me.cbxInvoice.TabStop = False
        Me.cbxInvoice.Text = "инвойс"
        Me.cbxInvoice.UseVisualStyleBackColor = True
        '
        'btShowLabelAny
        '
        Me.btShowLabelAny.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btShowLabelAny.Location = New System.Drawing.Point(1138, 201)
        Me.btShowLabelAny.Name = "btShowLabelAny"
        Me.btShowLabelAny.Size = New System.Drawing.Size(75, 41)
        Me.btShowLabelAny.TabIndex = 116
        Me.btShowLabelAny.TabStop = False
        Me.btShowLabelAny.Text = "просм. этик.$"
        Me.btShowLabelAny.UseVisualStyleBackColor = True
        '
        'btSearchLabel
        '
        Me.btSearchLabel.Location = New System.Drawing.Point(228, 124)
        Me.btSearchLabel.Name = "btSearchLabel"
        Me.btSearchLabel.Size = New System.Drawing.Size(109, 20)
        Me.btSearchLabel.TabIndex = 117
        Me.btSearchLabel.Text = "этикетка?"
        Me.btSearchLabel.UseVisualStyleBackColor = True
        '
        'btIncomingCalculate
        '
        Me.btIncomingCalculate.Location = New System.Drawing.Point(707, 89)
        Me.btIncomingCalculate.Margin = New System.Windows.Forms.Padding(2)
        Me.btIncomingCalculate.Name = "btIncomingCalculate"
        Me.btIncomingCalculate.Size = New System.Drawing.Size(110, 22)
        Me.btIncomingCalculate.TabIndex = 118
        Me.btIncomingCalculate.Text = "Рассчет входящей"
        Me.btIncomingCalculate.UseVisualStyleBackColor = True
        '
        'fmMoySklad
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1229, 602)
        Me.Controls.Add(Me.btIncomingCalculate)
        Me.Controls.Add(Me.Label58)
        Me.Controls.Add(Me.btSearchLabel)
        Me.Controls.Add(Me.cbPrintCurrency)
        Me.Controls.Add(Me.btShowLabelAny)
        Me.Controls.Add(Me.cbInvoceCurrency)
        Me.Controls.Add(Me.cbAutoprint)
        Me.Controls.Add(Me.btAddWeightToName)
        Me.Controls.Add(Me.pbImage)
        Me.Controls.Add(Me.tbInvoice)
        Me.Controls.Add(Me.cbxInvoice)
        Me.Controls.Add(Me.btClear2)
        Me.Controls.Add(Me.lbWarning)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btRoundRetailPrice)
        Me.Controls.Add(Me.btNumberMinus)
        Me.Controls.Add(Me.btNumberPlus)
        Me.Controls.Add(Me.lbIncoming)
        Me.Controls.Add(Me.tbWeight)
        Me.Controls.Add(Me.WeightLabel)
        Me.Controls.Add(Me.lbRetail)
        Me.Controls.Add(Me.btLabel)
        Me.Controls.Add(Me.cbxNeedPhotos)
        Me.Controls.Add(Me.btLabelWithPrice)
        Me.Controls.Add(Me.Label46)
        Me.Controls.Add(Me.cbxFixStore)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.btAddNameFromTree)
        Me.Controls.Add(Me.btOpenTreeForm)
        Me.Controls.Add(Me.tbMyTreeCode)
        Me.Controls.Add(Me.btPrinterClear)
        Me.Controls.Add(Me.Label41)
        Me.Controls.Add(Me.cbLocations)
        Me.Controls.Add(Me.btOption)
        Me.Controls.Add(Me.btMoveToCode)
        Me.Controls.Add(Me.cbBuyTargetCurrency)
        Me.Controls.Add(Me.cbxSetBuy)
        Me.Controls.Add(Me.tbBuyTargetValue)
        Me.Controls.Add(Me.Label32)
        Me.Controls.Add(Me.btSubNumberMinus)
        Me.Controls.Add(Me.btSubNumberPlus)
        Me.Controls.Add(Me.btMoveToArticul)
        Me.Controls.Add(Me.cbUom)
        Me.Controls.Add(Me.btCheckCodes)
        Me.Controls.Add(Me.btCopyNameFromTrees)
        Me.Controls.Add(Me.rbEnglish)
        Me.Controls.Add(Me.rbRussian)
        Me.Controls.Add(Me.cbDBNames)
        Me.Controls.Add(Me.cbListOfTree)
        Me.Controls.Add(Me.cbMaterial)
        Me.Controls.Add(Me.btLoadTree)
        Me.Controls.Add(Me.cbxFixCurrency)
        Me.Controls.Add(Me.cbxFixSeries)
        Me.Controls.Add(Me.btNewNumber)
        Me.Controls.Add(Me.cbRetailTargetCurrency)
        Me.Controls.Add(Me.tbRetailTargetValue)
        Me.Controls.Add(Me.cbxAddIfExists)
        Me.Controls.Add(Me.cbxSetRetail)
        Me.Controls.Add(Me.btSaveChanges)
        Me.Controls.Add(Me.btServiceForm)
        Me.Controls.Add(Me.btOnePcs)
        Me.Controls.Add(Me.btHide)
        Me.Controls.Add(Me.btCreateGood)
        Me.Controls.Add(Me.cbxWithoutSlot)
        Me.Controls.Add(Me.tbQty)
        Me.Controls.Add(Me.btClear)
        Me.Controls.Add(Me.btAddGoodToWare)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.cbSlot)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.rtbDescription)
        Me.Controls.Add(Me.btSearchInSklad)
        Me.Controls.Add(Me.cbTargetStores)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.tbBarCode)
        Me.Controls.Add(Me.tbName)
        Me.Controls.Add(Me.tbArticul)
        Me.Controls.Add(Me.tbNumber)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tbCtlMain)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "fmMoySklad"
        Me.Text = "Мой склад v2.2"
        Me.tbCtlMain.ResumeLayout(False)
        Me.tpMain.ResumeLayout(False)
        Me.tpMain.PerformLayout()
        CType(Me.pbLabel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.dgv_Goods, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bs_Goods_dgv_Goods, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpPreparation.ResumeLayout(False)
        Me.tpPreparation.PerformLayout()
        Me.GroupBox11.ResumeLayout(False)
        Me.GroupBox11.PerformLayout()
        Me.GroupBox10.ResumeLayout(False)
        Me.GroupBox10.PerformLayout()
        Me.GroupBox9.ResumeLayout(False)
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        CType(Me.bsCurrentGood, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.gbBuy.ResumeLayout(False)
        Me.gbExpedition.ResumeLayout(False)
        Me.gbExpedition.PerformLayout()
        Me.tpPrices.ResumeLayout(False)
        Me.tpPrices.PerformLayout()
        CType(Me.pbLabel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.UcPriceCalc_clsPriceDataBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpRfid.ResumeLayout(False)
        Me.tpRfid.PerformLayout()
        Me.UcGoodLabel1.ResumeLayout(False)
        Me.UcGoodLabel1.PerformLayout()
        CType(Me.BindingNavigatorImages, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpWareCells.ResumeLayout(False)
        Me.tpWareCells.PerformLayout()
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        CType(Me.bs_currentMove, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudLabelsCountCopy, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bs_Curr_slot_location, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bs_Curr_stor_location, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpInfo.ResumeLayout(False)
        Me.tpAuctions.ResumeLayout(False)
        Me.tpAuctions.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.RefTODataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RefTOBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.ClsBulkEnterObjBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SalePricesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ClsMSGoodBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bs_GoodLocation, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SlotGoodBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SlotListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.pbImage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tbCtlMain As System.Windows.Forms.TabControl
    Friend WithEvents tpMain As System.Windows.Forms.TabPage
    Friend WithEvents btSearchInSklad As System.Windows.Forms.Button
    Friend WithEvents tpWareCells As System.Windows.Forms.TabPage
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tbNumber As System.Windows.Forms.TextBox
    Friend WithEvents tbArticul As System.Windows.Forms.TextBox
    Friend WithEvents tbName As System.Windows.Forms.TextBox
    Friend WithEvents tbBarCode As System.Windows.Forms.TextBox
    Friend WithEvents bs_Goods_dgv_Goods As System.Windows.Forms.BindingSource
    Friend WithEvents dgv_Goods As System.Windows.Forms.DataGridView
    Friend WithEvents EAN13DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bsCurrentGood As System.Windows.Forms.BindingSource
    Friend WithEvents btGetArticulList As System.Windows.Forms.Button
    Friend WithEvents lbArticuls As System.Windows.Forms.ListBox
    Friend WithEvents lbWarning As System.Windows.Forms.Label
    Friend WithEvents cbTargetStores As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents rtbDescription As System.Windows.Forms.RichTextBox
    Friend WithEvents btSaveChanges As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cbSlot As System.Windows.Forms.ComboBox
    Friend WithEvents bs_GoodLocation As System.Windows.Forms.BindingSource
    Friend WithEvents SlotGoodBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents btClear As System.Windows.Forms.Button
    Friend WithEvents btAddGoodToWare As System.Windows.Forms.Button
    Friend WithEvents tbQty As System.Windows.Forms.TextBox
    Friend WithEvents cbxWithoutSlot As System.Windows.Forms.CheckBox
    Friend WithEvents pnLabel As System.Windows.Forms.Panel
    Friend WithEvents btToSlot As System.Windows.Forms.Button
    Friend WithEvents btAddToPlacing As System.Windows.Forms.Button
    Friend WithEvents tbNumberForPlacing As System.Windows.Forms.TextBox
    Friend WithEvents lbSlotNumbers As System.Windows.Forms.Label
    Friend WithEvents lbxnumbers As System.Windows.Forms.ListBox
    Friend WithEvents lbCurrentSlot As System.Windows.Forms.Label
    Friend WithEvents lbSlotForPlacing As System.Windows.Forms.ListBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cbStoreForPlacing As System.Windows.Forms.ComboBox
    Friend WithEvents btAddLabel As System.Windows.Forms.Button
    Friend WithEvents btClearPrintJob As System.Windows.Forms.Button
    Friend WithEvents btPrintLabel As System.Windows.Forms.Button
    Friend WithEvents bs_Curr_stor_location As System.Windows.Forms.BindingSource
    Friend WithEvents bs_Curr_slot_location As System.Windows.Forms.BindingSource
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents PrintPreviewDialog1 As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents nudLabelsCountCopy As System.Windows.Forms.NumericUpDown
    Friend WithEvents btFromSlot As System.Windows.Forms.Button
    Friend WithEvents btCreateGood As System.Windows.Forms.Button
    Friend WithEvents btAddAllNumbers As System.Windows.Forms.Button
    Friend WithEvents btHide As System.Windows.Forms.Button
    Friend WithEvents btOnePcs As System.Windows.Forms.Button
    Friend WithEvents btServiceForm As System.Windows.Forms.Button
    Friend WithEvents tpAuctions As System.Windows.Forms.TabPage
    Friend WithEvents tbAuGetSampleList As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbUnReady As System.Windows.Forms.RadioButton
    Friend WithEvents rbReady As System.Windows.Forms.RadioButton
    Friend WithEvents cbAuStoreList As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cbAuAuctionList As System.Windows.Forms.ComboBox
    Friend WithEvents tpPrices As System.Windows.Forms.TabPage
    Friend WithEvents SalePricesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents RefTODataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RefTOBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cbRetailTargetCurrency As System.Windows.Forms.ComboBox
    Friend WithEvents tbRetailTargetValue As System.Windows.Forms.TextBox
    Friend WithEvents cbxSetRetail As System.Windows.Forms.CheckBox
    Friend WithEvents cbxIncomingPrices As System.Windows.Forms.CheckBox
    Friend WithEvents btGetLossSource As System.Windows.Forms.Button
    Friend WithEvents tbLossSourceName As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents tbLossSourceArticul As System.Windows.Forms.TextBox
    Friend WithEvents cbxLossEnable As System.Windows.Forms.CheckBox
    Friend WithEvents tbLossQty As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents cbxAddIfExists As System.Windows.Forms.CheckBox
    Friend WithEvents pbLabel As System.Windows.Forms.PictureBox
    Friend WithEvents btLabel As System.Windows.Forms.Button
    Friend WithEvents btLabelWithPrice As System.Windows.Forms.Button
    Friend WithEvents BtCopyName As System.Windows.Forms.Button
    Friend WithEvents btNewNumber As System.Windows.Forms.Button
    Friend WithEvents btSetArticul As System.Windows.Forms.Button
    Friend WithEvents tpLotEnterTabPage As System.Windows.Forms.TabPage
    Friend WithEvents cbxFixStore As System.Windows.Forms.CheckBox
    Friend WithEvents cbxFixCurrency As System.Windows.Forms.CheckBox
    Friend WithEvents cbxFixSeries As System.Windows.Forms.CheckBox
    Friend WithEvents btPrinterClear As System.Windows.Forms.Button
    Friend WithEvents btLoadTree As System.Windows.Forms.Button
    Friend WithEvents cbMaterial As System.Windows.Forms.ComboBox
    Friend WithEvents cbListOfTree As System.Windows.Forms.ComboBox
    Friend WithEvents cbDBNames As System.Windows.Forms.ComboBox
    Friend WithEvents rbEnglish As System.Windows.Forms.RadioButton
    Friend WithEvents rbRussian As System.Windows.Forms.RadioButton
    Friend WithEvents btCopyNameFromTrees As System.Windows.Forms.Button
    Friend WithEvents btSetName As System.Windows.Forms.Button
    Friend WithEvents cbxNeedMakeLabel As System.Windows.Forms.CheckBox
    Friend WithEvents cbxNeedRePrep As System.Windows.Forms.CheckBox
    Friend WithEvents btCheckCodes As System.Windows.Forms.Button
    Friend WithEvents SlotListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ClsMSGoodBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents cbUom As System.Windows.Forms.ComboBox
    Friend WithEvents btMoveToArticul As System.Windows.Forms.Button
    Friend WithEvents btSubNumberPlus As System.Windows.Forms.Button
    Friend WithEvents btSubNumberMinus As System.Windows.Forms.Button
    Friend WithEvents ClsBulkEnterObjBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents btLoss As System.Windows.Forms.Button
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents tbBuyTargetValue As System.Windows.Forms.TextBox
    Friend WithEvents cbxSetBuy As System.Windows.Forms.CheckBox
    Friend WithEvents cbBuyTargetCurrency As System.Windows.Forms.ComboBox
    Friend WithEvents cbxWriteAdditionalPrices As System.Windows.Forms.CheckBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents tbShippingPrice As System.Windows.Forms.TextBox
    Friend WithEvents btMoveToCode As System.Windows.Forms.Button
    Friend WithEvents btOption As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btAuctionUncompleted As System.Windows.Forms.Button
    Friend WithEvents lbAuctionStatus As System.Windows.Forms.Label
    Friend WithEvents btAuctionCompleted As System.Windows.Forms.Button
    Friend WithEvents lbAuctions As System.Windows.Forms.ListBox
    Friend WithEvents cbLocations As System.Windows.Forms.ListBox
    Friend WithEvents tpPreparation As System.Windows.Forms.TabPage
    Friend WithEvents tbBuyCost As System.Windows.Forms.TextBox
    Friend WithEvents cbSupplier As System.Windows.Forms.ComboBox
    Friend WithEvents gbExpedition As System.Windows.Forms.GroupBox
    Friend WithEvents tbExpeditInfo As System.Windows.Forms.TextBox
    Friend WithEvents cbExpedition As System.Windows.Forms.ComboBox
    Friend WithEvents tbExpedNumber As System.Windows.Forms.TextBox
    Friend WithEvents cbxInCommission As System.Windows.Forms.CheckBox
    Friend WithEvents cbInExpedition As System.Windows.Forms.CheckBox
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents cbxNeedRepair As System.Windows.Forms.CheckBox
    Friend WithEvents cbxNeedPackaging As System.Windows.Forms.CheckBox
    Friend WithEvents cbxNeedPhotos As System.Windows.Forms.CheckBox
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents cbRePrepDetails As System.Windows.Forms.ComboBox
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents tbMyTreeCode As System.Windows.Forms.TextBox
    Friend WithEvents btOpenTreeForm As System.Windows.Forms.Button
    Friend WithEvents tbBuyPriceGood As System.Windows.Forms.TextBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents tbBuyPriceGoodCurrency As System.Windows.Forms.TextBox
    Friend WithEvents btAddNameFromTree As System.Windows.Forms.Button
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents cbxWithoutPriceLabelType As System.Windows.Forms.CheckBox
    Friend WithEvents cbLossLocations As System.Windows.Forms.ListBox
    Friend WithEvents cbxNakladnye As System.Windows.Forms.CheckBox
    Friend WithEvents lbLossUom As System.Windows.Forms.Label
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents lbToolWarning As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents cbAutoprint As System.Windows.Forms.CheckBox
    Friend WithEvents tpInfo As System.Windows.Forms.TabPage
    Friend WithEvents Uc_trilbone_history1 As Service.Uc_trilbone_history
    Friend WithEvents btToFreeLocation As System.Windows.Forms.Button
    Friend WithEvents lbSelectedSlotNumbers As System.Windows.Forms.Label
    Friend WithEvents btDeleteNumber As System.Windows.Forms.Button
    Friend WithEvents btAddToSelected As System.Windows.Forms.Button
    Friend WithEvents btAddCurrent As System.Windows.Forms.Button
    Friend WithEvents lbSlotInfo As System.Windows.Forms.Label
    Friend WithEvents lbxSelectedNumbers As System.Windows.Forms.ListBox
    Friend WithEvents bs_currentMove As System.Windows.Forms.BindingSource
    Friend WithEvents btAddWeightToName As System.Windows.Forms.Button
    Friend WithEvents btCondition As System.Windows.Forms.Button
    Friend WithEvents lbBuildDescription As System.Windows.Forms.Label
    Friend WithEvents btBuildCondition As System.Windows.Forms.Button
    Friend WithEvents tbBoxType As System.Windows.Forms.TextBox
    Friend WithEvents btBoxTypeFromName As System.Windows.Forms.Button
    Friend WithEvents btBoxTypeSelect As System.Windows.Forms.Button
    Friend WithEvents cbBoxTypes As System.Windows.Forms.ComboBox
    Friend WithEvents lbRetail As System.Windows.Forms.Label
    Friend WithEvents lbIncoming As System.Windows.Forms.Label
    Friend WithEvents btNumberMinus As System.Windows.Forms.Button
    Friend WithEvents btNumberPlus As System.Windows.Forms.Button
    Friend WithEvents btRoundRetailPrice As System.Windows.Forms.Button
    Friend WithEvents tpRfid As System.Windows.Forms.TabPage
    Friend WithEvents UC_rfid1 As Service.UC_rfid
    Friend WithEvents btClear2 As System.Windows.Forms.Button
    Friend WithEvents pbImage As System.Windows.Forms.PictureBox
    Friend WithEvents cbFixPrepTab As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents Label48 As System.Windows.Forms.Label
    Friend WithEvents tbFullPrepCost As System.Windows.Forms.TextBox
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents tbPrepCost As System.Windows.Forms.TextBox
    Friend WithEvents btAddPrep As System.Windows.Forms.Button
    Friend WithEvents tbPrepTimeAdd As System.Windows.Forms.TextBox
    Friend WithEvents cbPreparatorAdd As System.Windows.Forms.ComboBox
    Friend WithEvents tbPrepList As System.Windows.Forms.TextBox
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents tbPrepTime As System.Windows.Forms.TextBox
    Friend WithEvents cbMainPreparator As System.Windows.Forms.ComboBox
    Friend WithEvents RawNumberLabel As System.Windows.Forms.Label
    Friend WithEvents tbRawNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tbWeight As System.Windows.Forms.TextBox
    Friend WithEvents cbWeightTariff As System.Windows.Forms.ComboBox
    Friend WithEvents tbWeightTariff As System.Windows.Forms.TextBox
    Friend WithEvents cbxBuyCalc As System.Windows.Forms.CheckBox
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents btGetPrices As System.Windows.Forms.Button
    Friend WithEvents cbInvoceCurrency As System.Windows.Forms.ComboBox
    Friend WithEvents tbInvoice As System.Windows.Forms.TextBox
    Friend WithEvents cbxInvoice As System.Windows.Forms.CheckBox
    Friend WithEvents UcPriceCalc1 As Service.ucPriceCalc
    Friend WithEvents btWritePrices As System.Windows.Forms.Button
    Friend WithEvents btFromBuy As System.Windows.Forms.Button
    Friend WithEvents Label49 As System.Windows.Forms.Label
    Friend WithEvents btClearPrep As System.Windows.Forms.Button
    Friend WithEvents cbSchemePrice As System.Windows.Forms.ComboBox
    Friend WithEvents Label50 As System.Windows.Forms.Label
    Friend WithEvents cbRoundPrices As System.Windows.Forms.CheckBox
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents Label53 As System.Windows.Forms.Label
    Friend WithEvents Label54 As System.Windows.Forms.Label
    Friend WithEvents Label55 As System.Windows.Forms.Label
    Friend WithEvents Label56 As System.Windows.Forms.Label
    Friend WithEvents Label57 As System.Windows.Forms.Label
    Friend WithEvents CR1 As System.Windows.Forms.Label
    Friend WithEvents CR2 As System.Windows.Forms.Label
    Friend WithEvents CR3 As System.Windows.Forms.Label
    Friend WithEvents CR4 As System.Windows.Forms.Label
    Friend WithEvents CR5 As System.Windows.Forms.Label
    Friend WithEvents CR6 As System.Windows.Forms.Label
    Friend WithEvents CR7 As System.Windows.Forms.Label
    Friend WithEvents tbPRICE7 As System.Windows.Forms.TextBox
    Friend WithEvents tbPRICE6 As System.Windows.Forms.TextBox
    Friend WithEvents tbPRICE5 As System.Windows.Forms.TextBox
    Friend WithEvents tbPRICE4 As System.Windows.Forms.TextBox
    Friend WithEvents tbPRICE3 As System.Windows.Forms.TextBox
    Friend WithEvents tbPRICE2 As System.Windows.Forms.TextBox
    Friend WithEvents tbPRICE1 As System.Windows.Forms.TextBox
    Friend WithEvents UcPriceCalc_clsPriceDataBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents cbPrintCurrency As System.Windows.Forms.ComboBox
    Friend WithEvents btToPrepTime As System.Windows.Forms.Button
    Friend WithEvents Label58 As System.Windows.Forms.Label
    Friend WithEvents btSetPrices As System.Windows.Forms.Button
    Friend WithEvents WeightLabel As System.Windows.Forms.Label
    Friend WithEvents cbx_UCAutoprintWithPrice As System.Windows.Forms.CheckBox
    Friend WithEvents bt_UCRequest As System.Windows.Forms.Button
    Friend WithEvents btShowLabelAny As System.Windows.Forms.Button
    Friend WithEvents UcGoodLabel1 As Service.ucGoodLabel
    Friend WithEvents BindingNavigatorImages As BindingNavigator
    Friend WithEvents btSearchLabel As Button
    Friend WithEvents cbxIncomingIncludeExport As System.Windows.Forms.CheckBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents tbPrice8 As System.Windows.Forms.TextBox
    Friend WithEvents CR8cb As System.Windows.Forms.ComboBox
    Friend WithEvents btRusPlus30 As System.Windows.Forms.Button
    Friend WithEvents btRusMinus30 As System.Windows.Forms.Button
    Friend WithEvents btCallCalculator As System.Windows.Forms.Button
    Friend WithEvents btRet2 As System.Windows.Forms.Button
    Friend WithEvents btImpMinus30 As System.Windows.Forms.Button
    Friend WithEvents btImpPlus30 As System.Windows.Forms.Button
    Friend WithEvents btRet4 As System.Windows.Forms.Button
    Friend WithEvents btRet32 As System.Windows.Forms.Button
    Friend WithEvents Label59 As System.Windows.Forms.Label
    Friend WithEvents Label60 As System.Windows.Forms.Label
    Friend WithEvents ArticulDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CodeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalePrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pbLabel2 As System.Windows.Forms.PictureBox
    Friend WithEvents btShowLabelAny2 As System.Windows.Forms.Button
    Friend WithEvents cbFixPriceTab As System.Windows.Forms.CheckBox
    Friend WithEvents cbFixTabRfid As System.Windows.Forms.CheckBox
    Friend WithEvents btCreateInventory As Button
    Friend WithEvents Label14 As Label
    Friend WithEvents GroupBox8 As GroupBox
    Friend WithEvents Label12 As Label
    Friend WithEvents GroupBox11 As System.Windows.Forms.GroupBox
    Friend WithEvents cbxSetExport As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox10 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox9 As System.Windows.Forms.GroupBox
    Friend WithEvents btFromInvoice As System.Windows.Forms.Button
    Friend WithEvents cbxCalculateBuy As System.Windows.Forms.CheckBox
    Friend WithEvents cbxIncomingIncludePrep As System.Windows.Forms.CheckBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label61 As System.Windows.Forms.Label
    Friend WithEvents btIncomingCalculate As System.Windows.Forms.Button
    Friend WithEvents tbCoeff As System.Windows.Forms.TextBox
    Friend WithEvents gbBuy As System.Windows.Forms.GroupBox
End Class
