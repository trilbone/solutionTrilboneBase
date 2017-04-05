<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fmWtime
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
        Dim HandlingAmountLabel As System.Windows.Forms.Label
        Dim ShippingAmountLabel As System.Windows.Forms.Label
        Dim Label22 As System.Windows.Forms.Label
        Dim Label23 As System.Windows.Forms.Label
        Dim TrackNumberLabel As System.Windows.Forms.Label
        Dim CityLabel As System.Windows.Forms.Label
        Dim CountryLabel As System.Windows.Forms.Label
        Dim NameLabel As System.Windows.Forms.Label
        Dim PhoneLabel As System.Windows.Forms.Label
        Dim PostIndexLabel As System.Windows.Forms.Label
        Dim StateLabel As System.Windows.Forms.Label
        Dim StreetLabel As System.Windows.Forms.Label
        Dim Label33 As System.Windows.Forms.Label
        Dim Label34 As System.Windows.Forms.Label
        Dim Label25 As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fmWtime))
        Me.tbPin = New System.Windows.Forms.TextBox()
        Me.tbctlMain = New System.Windows.Forms.TabControl()
        Me.tpTime = New System.Windows.Forms.TabPage()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel_operations = New System.Windows.Forms.TableLayoutPanel()
        Me.btEditOperation = New System.Windows.Forms.Button()
        Me.btAddNewSample = New System.Windows.Forms.Button()
        Me.btStopSampleOperation = New System.Windows.Forms.Button()
        Me.btSuspendSampleOperation = New System.Windows.Forms.Button()
        Me.btStartSampleOperation = New System.Windows.Forms.Button()
        Me.btPhotoSample = New System.Windows.Forms.Button()
        Me.btAddNewInCurrentLot = New System.Windows.Forms.Button()
        Me.lbxCurrentUserOperation = New System.Windows.Forms.ListBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lbWokerCurrentTimeSpan = New System.Windows.Forms.Label()
        Me.ClsUserBindingSource = New System.Windows.Forms.BindingSource()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lbWokerStatus = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.btCreateTask = New System.Windows.Forms.Button()
        Me.btStopWork = New System.Windows.Forms.Button()
        Me.btSuspendWork = New System.Windows.Forms.Button()
        Me.btStartWork = New System.Windows.Forms.Button()
        Me.tpMyTime = New System.Windows.Forms.TabPage()
        Me.tbctlSalary = New System.Windows.Forms.TabControl()
        Me.tbFromLastSalary = New System.Windows.Forms.TabPage()
        Me.gbCorrectionwTime = New System.Windows.Forms.GroupBox()
        Me.btRemoveWRecord = New System.Windows.Forms.Button()
        Me.btAddWRecord = New System.Windows.Forms.Button()
        Me.DateTimePicker_CorrectWDate = New System.Windows.Forms.DateTimePicker()
        Me.btUserCorrect = New System.Windows.Forms.Button()
        Me.DateTimePicker_correctwTime = New System.Windows.Forms.DateTimePicker()
        Me.rbCorrectEndwtime = New System.Windows.Forms.RadioButton()
        Me.rbCorrectBeginwTime = New System.Windows.Forms.RadioButton()
        Me.WTimeSummary_ResultDataGridView = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WTimeSummary_ResultBindingSource = New System.Windows.Forms.BindingSource()
        Me.tpAllSalary = New System.Windows.Forms.TabPage()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DateTimePicker_salary = New System.Windows.Forms.DateTimePicker()
        Me.btPaySalary = New System.Windows.Forms.Button()
        Me.WSalaryInfo_ResultDataGridView = New System.Windows.Forms.DataGridView()
        Me.CalculateDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewCheckBoxColumn1 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn15 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WSalaryInfo_ResultBindingSource = New System.Windows.Forms.BindingSource()
        Me.tbEmployeeSum = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.gbSelectEmployee = New System.Windows.Forms.GroupBox()
        Me.cbEmployee = New System.Windows.Forms.ComboBox()
        Me.TbEmployeeBindingSource = New System.Windows.Forms.BindingSource()
        Me.btGetMyTime = New System.Windows.Forms.Button()
        Me.tpHwoInOffice = New System.Windows.Forms.TabPage()
        Me.btHwoInOffice = New System.Windows.Forms.Button()
        Me.WInOffice_ResultDataGridView = New System.Windows.Forms.DataGridView()
        Me.EmployeeNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TimeMarkerDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OperationNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OperationName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RegisterTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WInOffice_ResultBindingSource = New System.Windows.Forms.BindingSource()
        Me.tpNewSample = New System.Windows.Forms.TabPage()
        Me.tcSampleParam = New System.Windows.Forms.TabControl()
        Me.tpLotParam = New System.Windows.Forms.TabPage()
        Me.lbOperationPayment = New System.Windows.Forms.Label()
        Me.lbxOperations = New System.Windows.Forms.ListBox()
        Me.TbSMOperationBindingSource = New System.Windows.Forms.BindingSource()
        Me.btCreateOperation = New System.Windows.Forms.Button()
        Me.lbOperationWarning = New System.Windows.Forms.Label()
        Me.ComboBox4 = New System.Windows.Forms.ComboBox()
        Me.TbSMLotBindingSource = New System.Windows.Forms.BindingSource()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.btStartOperation = New System.Windows.Forms.Button()
        Me.tbQtyInLot = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.rbSingleSample = New System.Windows.Forms.RadioButton()
        Me.rbLotSample = New System.Windows.Forms.RadioButton()
        Me.cbUom = New System.Windows.Forms.ComboBox()
        Me.TbUomBindingSource = New System.Windows.Forms.BindingSource()
        Me.tpOperationParam = New System.Windows.Forms.TabPage()
        Me.rtbOperationComment = New System.Windows.Forms.RichTextBox()
        Me.lbxWorkOperation = New System.Windows.Forms.ListBox()
        Me.TbSMWorkOperationBindingSource = New System.Windows.Forms.BindingSource()
        Me.cbOperationUom = New System.Windows.Forms.ComboBox()
        Me.tbAccountingQty = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tpExpeditionParam = New System.Windows.Forms.TabPage()
        Me.btLoadExpeditionFromMC = New System.Windows.Forms.Button()
        Me.tbExpeditionNr = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.cbExpedition = New System.Windows.Forms.ComboBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.rtbRollText = New System.Windows.Forms.RichTextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.tpOperationPayment = New System.Windows.Forms.TabPage()
        Me.gbPayByWoker = New System.Windows.Forms.GroupBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.rbWokerPerHour = New System.Windows.Forms.RadioButton()
        Me.tbHourByWorker = New System.Windows.Forms.TextBox()
        Me.rbWokerPerSumma = New System.Windows.Forms.RadioButton()
        Me.tbSumByWoker = New System.Windows.Forms.TextBox()
        Me.gbPayByAdmin = New System.Windows.Forms.GroupBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cbTariff = New System.Windows.Forms.ComboBox()
        Me.TbSMTariffBindingSource = New System.Windows.Forms.BindingSource()
        Me.rbTariff = New System.Windows.Forms.RadioButton()
        Me.cbCurrencyOperation = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.rbPerHour = New System.Windows.Forms.RadioButton()
        Me.tbAdminHourPay = New System.Windows.Forms.TextBox()
        Me.rbSumma = New System.Windows.Forms.RadioButton()
        Me.tbAdminSumPay = New System.Windows.Forms.TextBox()
        Me.btResetPrinter2 = New System.Windows.Forms.Button()
        Me.btPrintNumberLabel2 = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.btRegisterSchema = New System.Windows.Forms.Button()
        Me.btWithoutNumber = New System.Windows.Forms.Button()
        Me.btClear = New System.Windows.Forms.Button()
        Me.btSaveLot = New System.Windows.Forms.Button()
        Me.tbSchemeNumber = New System.Windows.Forms.TextBox()
        Me.btCreateSchema = New System.Windows.Forms.Button()
        Me.tpAccepting = New System.Windows.Forms.TabPage()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Button10 = New System.Windows.Forms.Button()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tpToParts = New System.Windows.Forms.TabPage()
        Me.RichTextBox2 = New System.Windows.Forms.RichTextBox()
        Me.tpSmallScheme = New System.Windows.Forms.TabPage()
        Me.tpParcels = New System.Windows.Forms.TabPage()
        Me.tbctlParcels = New System.Windows.Forms.TabControl()
        Me.tpParcelToShip = New System.Windows.Forms.TabPage()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.lblItemsInParcel = New System.Windows.Forms.Label()
        Me.gbParcelCount = New System.Windows.Forms.GroupBox()
        Me.btRequestParcels = New System.Windows.Forms.Button()
        Me.BindingNavigator1 = New System.Windows.Forms.BindingNavigator()
        Me.IMoySkladDataProvider_ParcelInfoBindingSource = New System.Windows.Forms.BindingSource()
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel()
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox()
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.cbParcelType = New System.Windows.Forms.ComboBox()
        Me.IMoySkladDataProvider_ResultParcelInfoBindingSource = New System.Windows.Forms.BindingSource()
        Me.cbParcelGroup = New System.Windows.Forms.ComboBox()
        Me.cbCurrentItemList = New System.Windows.Forms.ComboBox()
        Me.btParcelResult = New System.Windows.Forms.Button()
        Me.TextBox10 = New System.Windows.Forms.TextBox()
        Me.TextBox11 = New System.Windows.Forms.TextBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.tbParcelSizeC = New System.Windows.Forms.TextBox()
        Me.tbParcelSizeB = New System.Windows.Forms.TextBox()
        Me.tbParcelSizeA = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.tbParcelWeight = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.tbSKU = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.CityTextBox = New System.Windows.Forms.TextBox()
        Me.CountryTextBox = New System.Windows.Forms.TextBox()
        Me.NameTextBox = New System.Windows.Forms.TextBox()
        Me.PhoneTextBox = New System.Windows.Forms.TextBox()
        Me.PostIndexTextBox = New System.Windows.Forms.TextBox()
        Me.StateTextBox = New System.Windows.Forms.TextBox()
        Me.StreetTextBox = New System.Windows.Forms.TextBox()
        Me.tbDeclaration = New System.Windows.Forms.TabPage()
        Me.IMoySkladDataProvider_Declaration_CP71_CN23DataGridView = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn17 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn18 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn19 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn20 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn23 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IMoySkladDataProvider_Declaration_CP71_CN23BindingSource = New System.Windows.Forms.BindingSource()
        Me.tpParcelResult = New System.Windows.Forms.TabPage()
        Me.btSaveShipping = New System.Windows.Forms.Button()
        Me.btRemovePackageGood = New System.Windows.Forms.Button()
        Me.btAddPackageGood = New System.Windows.Forms.Button()
        Me.tbEnterPackageGood = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.PackagingGoodsUUIDsAndQtysDataGridView = New System.Windows.Forms.DataGridView()
        Me.clmGoodName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn21 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn22 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PackagingGoodsUUIDsAndQtysBindingSource = New System.Windows.Forms.BindingSource()
        Me.TrackNumberTextBox = New System.Windows.Forms.TextBox()
        Me.cbShippingWoker = New System.Windows.Forms.ComboBox()
        Me.cbShippingCompany = New System.Windows.Forms.ComboBox()
        Me.cbShippingCurrency = New System.Windows.Forms.ComboBox()
        Me.ShippingAmountTextBox = New System.Windows.Forms.TextBox()
        Me.HandlingAmountTextBox = New System.Windows.Forms.TextBox()
        Me.tpSampleInfo = New System.Windows.Forms.TabPage()
        Me.Uc_trilbone_history1 = New Service.Uc_trilbone_history()
        Me.tpRfid = New System.Windows.Forms.TabPage()
        Me.cbxMoySkladAsk = New System.Windows.Forms.CheckBox()
        Me.lbLocationInfo = New System.Windows.Forms.Label()
        Me.btPrinterClear = New System.Windows.Forms.Button()
        Me.btPrintLabel = New System.Windows.Forms.Button()
        Me.pbEANLabel = New System.Windows.Forms.PictureBox()
        Me.UC_rfid1 = New Service.UC_rfid()
        Me.tpEmployee = New System.Windows.Forms.TabPage()
        Me.Uc_Employee1 = New Service.uc_Employee()
        Me.tpOnSale = New System.Windows.Forms.TabPage()
        Me.UcReadySamples1 = New Service.ucReadySamples()
        Me.tpSellRegister = New System.Windows.Forms.TabPage()
        Me.UcSellGood1 = New Service.ucSellGood()
        Me.tpeBayInfo = New System.Windows.Forms.TabPage()
        Me.UcEbayHistory1 = New Service.ucEbayHistory()
        Me.tpОформление = New System.Windows.Forms.TabPage()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Uc_createSample1 = New Service.uc_createSample()
        Me.StringDictionaryBindingSource = New System.Windows.Forms.BindingSource()
        Me.SamplesOnWorkBindingSource = New System.Windows.Forms.BindingSource()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TimerClock = New System.Windows.Forms.Timer()
        Me.lbCurrentTime = New System.Windows.Forms.Label()
        Me.lbWokername = New System.Windows.Forms.Label()
        Me.btLoadTrilboneForm = New System.Windows.Forms.Button()
        Me.lbConnectStatus = New System.Windows.Forms.Label()
        Me.btSingOut = New System.Windows.Forms.Button()
        Me.btPin = New System.Windows.Forms.Button()
        Me.btScannerON = New System.Windows.Forms.Button()
        Me.btRestartRFID = New System.Windows.Forms.Button()
        Me.lbMoySkladStatus = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        HandlingAmountLabel = New System.Windows.Forms.Label()
        ShippingAmountLabel = New System.Windows.Forms.Label()
        Label22 = New System.Windows.Forms.Label()
        Label23 = New System.Windows.Forms.Label()
        TrackNumberLabel = New System.Windows.Forms.Label()
        CityLabel = New System.Windows.Forms.Label()
        CountryLabel = New System.Windows.Forms.Label()
        NameLabel = New System.Windows.Forms.Label()
        PhoneLabel = New System.Windows.Forms.Label()
        PostIndexLabel = New System.Windows.Forms.Label()
        StateLabel = New System.Windows.Forms.Label()
        StreetLabel = New System.Windows.Forms.Label()
        Label33 = New System.Windows.Forms.Label()
        Label34 = New System.Windows.Forms.Label()
        Label25 = New System.Windows.Forms.Label()
        Me.tbctlMain.SuspendLayout()
        Me.tpTime.SuspendLayout()
        Me.TableLayoutPanel_operations.SuspendLayout()
        CType(Me.ClsUserBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.tpMyTime.SuspendLayout()
        Me.tbctlSalary.SuspendLayout()
        Me.tbFromLastSalary.SuspendLayout()
        Me.gbCorrectionwTime.SuspendLayout()
        CType(Me.WTimeSummary_ResultDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WTimeSummary_ResultBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpAllSalary.SuspendLayout()
        CType(Me.WSalaryInfo_ResultDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WSalaryInfo_ResultBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbSelectEmployee.SuspendLayout()
        CType(Me.TbEmployeeBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpHwoInOffice.SuspendLayout()
        CType(Me.WInOffice_ResultDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WInOffice_ResultBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpNewSample.SuspendLayout()
        Me.tcSampleParam.SuspendLayout()
        Me.tpLotParam.SuspendLayout()
        CType(Me.TbSMOperationBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TbSMLotBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TbUomBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpOperationParam.SuspendLayout()
        CType(Me.TbSMWorkOperationBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpExpeditionParam.SuspendLayout()
        Me.tpOperationPayment.SuspendLayout()
        Me.gbPayByWoker.SuspendLayout()
        Me.gbPayByAdmin.SuspendLayout()
        CType(Me.TbSMTariffBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.tpAccepting.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpToParts.SuspendLayout()
        Me.tpParcels.SuspendLayout()
        Me.tbctlParcels.SuspendLayout()
        Me.tpParcelToShip.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbParcelCount.SuspendLayout()
        CType(Me.BindingNavigator1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BindingNavigator1.SuspendLayout()
        CType(Me.IMoySkladDataProvider_ParcelInfoBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IMoySkladDataProvider_ResultParcelInfoBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbDeclaration.SuspendLayout()
        CType(Me.IMoySkladDataProvider_Declaration_CP71_CN23DataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IMoySkladDataProvider_Declaration_CP71_CN23BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpParcelResult.SuspendLayout()
        CType(Me.PackagingGoodsUUIDsAndQtysDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PackagingGoodsUUIDsAndQtysBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpSampleInfo.SuspendLayout()
        Me.tpRfid.SuspendLayout()
        CType(Me.pbEANLabel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpEmployee.SuspendLayout()
        Me.tpOnSale.SuspendLayout()
        Me.tpSellRegister.SuspendLayout()
        Me.tpeBayInfo.SuspendLayout()
        Me.tpОформление.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StringDictionaryBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SamplesOnWorkBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'HandlingAmountLabel
        '
        HandlingAmountLabel.AutoSize = True
        HandlingAmountLabel.Location = New System.Drawing.Point(6, 202)
        HandlingAmountLabel.Name = "HandlingAmountLabel"
        HandlingAmountLabel.Size = New System.Drawing.Size(306, 24)
        HandlingAmountLabel.TabIndex = 0
        HandlingAmountLabel.Text = "Стоимость упаковки и отправки:"
        '
        'ShippingAmountLabel
        '
        ShippingAmountLabel.AutoSize = True
        ShippingAmountLabel.Location = New System.Drawing.Point(109, 150)
        ShippingAmountLabel.Name = "ShippingAmountLabel"
        ShippingAmountLabel.Size = New System.Drawing.Size(203, 24)
        ShippingAmountLabel.TabIndex = 2
        ShippingAmountLabel.Text = "Почтовая стоимость:"
        '
        'Label22
        '
        Label22.AutoSize = True
        Label22.Location = New System.Drawing.Point(13, 58)
        Label22.Name = "Label22"
        Label22.Size = New System.Drawing.Size(192, 24)
        Label22.TabIndex = 6
        Label22.Text = "Почтовая компания:"
        '
        'Label23
        '
        Label23.AutoSize = True
        Label23.Location = New System.Drawing.Point(101, 9)
        Label23.Name = "Label23"
        Label23.Size = New System.Drawing.Size(104, 24)
        Label23.TabIndex = 8
        Label23.Text = "Отправил:"
        '
        'TrackNumberLabel
        '
        TrackNumberLabel.AutoSize = True
        TrackNumberLabel.Location = New System.Drawing.Point(13, 103)
        TrackNumberLabel.Name = "TrackNumberLabel"
        TrackNumberLabel.Size = New System.Drawing.Size(120, 24)
        TrackNumberLabel.TabIndex = 9
        TrackNumberLabel.Text = "Трек номер:"
        '
        'CityLabel
        '
        CityLabel.AutoSize = True
        CityLabel.Location = New System.Drawing.Point(13, 260)
        CityLabel.Name = "CityLabel"
        CityLabel.Size = New System.Drawing.Size(163, 24)
        CityLabel.TabIndex = 0
        CityLabel.Text = "Поселок (Город):"
        '
        'CountryLabel
        '
        CountryLabel.AutoSize = True
        CountryLabel.Location = New System.Drawing.Point(15, 110)
        CountryLabel.Name = "CountryLabel"
        CountryLabel.Size = New System.Drawing.Size(202, 24)
        CountryLabel.TabIndex = 2
        CountryLabel.Text = "Страна направления:"
        '
        'NameLabel
        '
        NameLabel.AutoSize = True
        NameLabel.Location = New System.Drawing.Point(84, 145)
        NameLabel.Name = "NameLabel"
        NameLabel.Size = New System.Drawing.Size(51, 24)
        NameLabel.TabIndex = 6
        NameLabel.Text = "Имя:"
        '
        'PhoneLabel
        '
        PhoneLabel.AutoSize = True
        PhoneLabel.Location = New System.Drawing.Point(12, 293)
        PhoneLabel.Name = "PhoneLabel"
        PhoneLabel.Size = New System.Drawing.Size(95, 24)
        PhoneLabel.TabIndex = 8
        PhoneLabel.Text = "Телефон:"
        '
        'PostIndexLabel
        '
        PostIndexLabel.AutoSize = True
        PostIndexLabel.Location = New System.Drawing.Point(14, 218)
        PostIndexLabel.Name = "PostIndexLabel"
        PostIndexLabel.Size = New System.Drawing.Size(81, 24)
        PostIndexLabel.TabIndex = 10
        PostIndexLabel.Text = "Индекс:"
        '
        'StateLabel
        '
        StateLabel.AutoSize = True
        StateLabel.Location = New System.Drawing.Point(258, 221)
        StateLabel.Name = "StateLabel"
        StateLabel.Size = New System.Drawing.Size(151, 24)
        StateLabel.TabIndex = 12
        StateLabel.Text = "Волость (штат):"
        '
        'StreetLabel
        '
        StreetLabel.AutoSize = True
        StreetLabel.Location = New System.Drawing.Point(10, 180)
        StreetLabel.Name = "StreetLabel"
        StreetLabel.Size = New System.Drawing.Size(125, 24)
        StreetLabel.TabIndex = 14
        StreetLabel.Text = "Улица/хутор:"
        '
        'Label33
        '
        Label33.AutoSize = True
        Label33.Location = New System.Drawing.Point(786, 82)
        Label33.Name = "Label33"
        Label33.Size = New System.Drawing.Size(76, 24)
        Label33.TabIndex = 39
        Label33.Text = "группа:"
        '
        'Label34
        '
        Label34.AutoSize = True
        Label34.Location = New System.Drawing.Point(776, 145)
        Label34.Name = "Label34"
        Label34.Size = New System.Drawing.Size(72, 24)
        Label34.TabIndex = 41
        Label34.Text = "услуга:"
        '
        'Label25
        '
        Label25.AutoSize = True
        Label25.Location = New System.Drawing.Point(834, 112)
        Label25.Name = "Label25"
        Label25.Size = New System.Drawing.Size(186, 24)
        Label25.TabIndex = 41
        Label25.Text = "скорость: lennupost"
        '
        'tbPin
        '
        Me.tbPin.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.tbPin.Location = New System.Drawing.Point(100, 19)
        Me.tbPin.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.tbPin.Name = "tbPin"
        Me.tbPin.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.tbPin.Size = New System.Drawing.Size(51, 31)
        Me.tbPin.TabIndex = 1
        '
        'tbctlMain
        '
        Me.tbctlMain.Controls.Add(Me.tpTime)
        Me.tbctlMain.Controls.Add(Me.tpMyTime)
        Me.tbctlMain.Controls.Add(Me.tpHwoInOffice)
        Me.tbctlMain.Controls.Add(Me.tpNewSample)
        Me.tbctlMain.Controls.Add(Me.tpAccepting)
        Me.tbctlMain.Controls.Add(Me.tpToParts)
        Me.tbctlMain.Controls.Add(Me.tpSmallScheme)
        Me.tbctlMain.Controls.Add(Me.tpParcels)
        Me.tbctlMain.Controls.Add(Me.tpSampleInfo)
        Me.tbctlMain.Controls.Add(Me.tpRfid)
        Me.tbctlMain.Controls.Add(Me.tpEmployee)
        Me.tbctlMain.Controls.Add(Me.tpOnSale)
        Me.tbctlMain.Controls.Add(Me.tpSellRegister)
        Me.tbctlMain.Controls.Add(Me.tpeBayInfo)
        Me.tbctlMain.Controls.Add(Me.tpОформление)
        Me.tbctlMain.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.tbctlMain.Location = New System.Drawing.Point(18, 98)
        Me.tbctlMain.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.tbctlMain.Name = "tbctlMain"
        Me.tbctlMain.SelectedIndex = 0
        Me.tbctlMain.Size = New System.Drawing.Size(1053, 471)
        Me.tbctlMain.TabIndex = 3
        '
        'tpTime
        '
        Me.tpTime.Controls.Add(Me.Button1)
        Me.tpTime.Controls.Add(Me.Label21)
        Me.tpTime.Controls.Add(Me.Label10)
        Me.tpTime.Controls.Add(Me.TableLayoutPanel_operations)
        Me.tpTime.Controls.Add(Me.lbxCurrentUserOperation)
        Me.tpTime.Controls.Add(Me.Label9)
        Me.tpTime.Controls.Add(Me.lbWokerCurrentTimeSpan)
        Me.tpTime.Controls.Add(Me.Label8)
        Me.tpTime.Controls.Add(Me.Label2)
        Me.tpTime.Controls.Add(Me.Label6)
        Me.tpTime.Controls.Add(Me.lbWokerStatus)
        Me.tpTime.Controls.Add(Me.TableLayoutPanel1)
        Me.tpTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.tpTime.Location = New System.Drawing.Point(4, 33)
        Me.tpTime.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.tpTime.Name = "tpTime"
        Me.tpTime.Padding = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.tpTime.Size = New System.Drawing.Size(1045, 434)
        Me.tpTime.TabIndex = 0
        Me.tpTime.Text = "Отметить время"
        Me.tpTime.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Button1.Location = New System.Drawing.Point(170, 304)
        Me.Button1.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(195, 51)
        Me.Button1.TabIndex = 11
        Me.Button1.Text = "Новое сообщение.."
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(30, 322)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(123, 18)
        Me.Label21.TabIndex = 10
        Me.Label21.Text = "Есть сообщения"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label10.Location = New System.Drawing.Point(680, 23)
        Me.Label10.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(212, 24)
        Me.Label10.TabIndex = 9
        Me.Label10.Text = "Возможные действия:"
        '
        'TableLayoutPanel_operations
        '
        Me.TableLayoutPanel_operations.ColumnCount = 2
        Me.TableLayoutPanel_operations.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel_operations.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel_operations.Controls.Add(Me.btEditOperation, 1, 1)
        Me.TableLayoutPanel_operations.Controls.Add(Me.btAddNewSample, 0, 0)
        Me.TableLayoutPanel_operations.Controls.Add(Me.btStopSampleOperation, 1, 3)
        Me.TableLayoutPanel_operations.Controls.Add(Me.btSuspendSampleOperation, 1, 2)
        Me.TableLayoutPanel_operations.Controls.Add(Me.btStartSampleOperation, 0, 2)
        Me.TableLayoutPanel_operations.Controls.Add(Me.btPhotoSample, 1, 0)
        Me.TableLayoutPanel_operations.Controls.Add(Me.btAddNewInCurrentLot, 0, 3)
        Me.TableLayoutPanel_operations.Location = New System.Drawing.Point(675, 57)
        Me.TableLayoutPanel_operations.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.TableLayoutPanel_operations.Name = "TableLayoutPanel_operations"
        Me.TableLayoutPanel_operations.RowCount = 4
        Me.TableLayoutPanel_operations.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel_operations.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel_operations.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel_operations.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel_operations.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel_operations.Size = New System.Drawing.Size(356, 298)
        Me.TableLayoutPanel_operations.TabIndex = 8
        '
        'btEditOperation
        '
        Me.btEditOperation.Enabled = False
        Me.btEditOperation.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btEditOperation.Location = New System.Drawing.Point(183, 78)
        Me.btEditOperation.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.btEditOperation.Name = "btEditOperation"
        Me.btEditOperation.Size = New System.Drawing.Size(168, 66)
        Me.btEditOperation.TabIndex = 13
        Me.btEditOperation.Text = "Редактировать"
        Me.btEditOperation.UseVisualStyleBackColor = True
        '
        'btAddNewSample
        '
        Me.btAddNewSample.Enabled = False
        Me.btAddNewSample.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btAddNewSample.Location = New System.Drawing.Point(5, 4)
        Me.btAddNewSample.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.btAddNewSample.Name = "btAddNewSample"
        Me.btAddNewSample.Size = New System.Drawing.Size(168, 66)
        Me.btAddNewSample.TabIndex = 12
        Me.btAddNewSample.Text = "Новый"
        Me.btAddNewSample.UseVisualStyleBackColor = True
        '
        'btStopSampleOperation
        '
        Me.btStopSampleOperation.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btStopSampleOperation.Location = New System.Drawing.Point(181, 225)
        Me.btStopSampleOperation.Name = "btStopSampleOperation"
        Me.btStopSampleOperation.Size = New System.Drawing.Size(172, 68)
        Me.btStopSampleOperation.TabIndex = 7
        Me.btStopSampleOperation.Text = "Сдать образец"
        Me.btStopSampleOperation.UseVisualStyleBackColor = True
        '
        'btSuspendSampleOperation
        '
        Me.btSuspendSampleOperation.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btSuspendSampleOperation.Location = New System.Drawing.Point(183, 152)
        Me.btSuspendSampleOperation.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.btSuspendSampleOperation.Name = "btSuspendSampleOperation"
        Me.btSuspendSampleOperation.Size = New System.Drawing.Size(168, 66)
        Me.btSuspendSampleOperation.TabIndex = 1
        Me.btSuspendSampleOperation.Text = "Отложить"
        Me.btSuspendSampleOperation.UseVisualStyleBackColor = True
        '
        'btStartSampleOperation
        '
        Me.btStartSampleOperation.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btStartSampleOperation.Location = New System.Drawing.Point(5, 152)
        Me.btStartSampleOperation.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.btStartSampleOperation.Name = "btStartSampleOperation"
        Me.btStartSampleOperation.Size = New System.Drawing.Size(168, 66)
        Me.btStartSampleOperation.TabIndex = 0
        Me.btStartSampleOperation.Text = "Начать"
        Me.btStartSampleOperation.UseVisualStyleBackColor = True
        '
        'btPhotoSample
        '
        Me.btPhotoSample.Enabled = False
        Me.btPhotoSample.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btPhotoSample.Location = New System.Drawing.Point(183, 4)
        Me.btPhotoSample.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.btPhotoSample.Name = "btPhotoSample"
        Me.btPhotoSample.Size = New System.Drawing.Size(168, 66)
        Me.btPhotoSample.TabIndex = 6
        Me.btPhotoSample.Text = "Сделать фото"
        Me.btPhotoSample.UseVisualStyleBackColor = True
        '
        'btAddNewInCurrentLot
        '
        Me.btAddNewInCurrentLot.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btAddNewInCurrentLot.Location = New System.Drawing.Point(3, 225)
        Me.btAddNewInCurrentLot.Name = "btAddNewInCurrentLot"
        Me.btAddNewInCurrentLot.Size = New System.Drawing.Size(172, 68)
        Me.btAddNewInCurrentLot.TabIndex = 9
        Me.btAddNewInCurrentLot.Text = "Добавить обр."
        Me.btAddNewInCurrentLot.UseVisualStyleBackColor = True
        '
        'lbxCurrentUserOperation
        '
        Me.lbxCurrentUserOperation.FormattingEnabled = True
        Me.lbxCurrentUserOperation.ItemHeight = 18
        Me.lbxCurrentUserOperation.Location = New System.Drawing.Point(390, 57)
        Me.lbxCurrentUserOperation.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.lbxCurrentUserOperation.Name = "lbxCurrentUserOperation"
        Me.lbxCurrentUserOperation.Size = New System.Drawing.Size(274, 292)
        Me.lbxCurrentUserOperation.TabIndex = 7
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label9.Location = New System.Drawing.Point(386, 23)
        Me.Label9.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(280, 24)
        Me.Label9.TabIndex = 6
        Me.Label9.Text = "Образцы (операции) в работе"
        '
        'lbWokerCurrentTimeSpan
        '
        Me.lbWokerCurrentTimeSpan.AutoSize = True
        Me.lbWokerCurrentTimeSpan.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ClsUserBindingSource, "CurrentTime", True, System.Windows.Forms.DataSourceUpdateMode.Never, "0:00", "d\ hh\:mm"))
        Me.lbWokerCurrentTimeSpan.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lbWokerCurrentTimeSpan.Location = New System.Drawing.Point(153, 73)
        Me.lbWokerCurrentTimeSpan.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lbWokerCurrentTimeSpan.Name = "lbWokerCurrentTimeSpan"
        Me.lbWokerCurrentTimeSpan.Size = New System.Drawing.Size(58, 25)
        Me.lbWokerCurrentTimeSpan.TabIndex = 5
        Me.lbWokerCurrentTimeSpan.Text = "0:00"
        '
        'ClsUserBindingSource
        '
        Me.ClsUserBindingSource.DataSource = GetType(Service.clsUser)
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label8.Location = New System.Drawing.Point(47, 73)
        Me.Label8.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(72, 24)
        Me.Label8.TabIndex = 4
        Me.Label8.Text = "Время:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label2.Location = New System.Drawing.Point(38, 5)
        Me.Label2.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(191, 24)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Текущее состояние:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label6.Location = New System.Drawing.Point(38, 116)
        Me.Label6.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(212, 24)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Возможные действия:"
        '
        'lbWokerStatus
        '
        Me.lbWokerStatus.AutoSize = True
        Me.lbWokerStatus.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ClsUserBindingSource, "CurrentStatusString", True))
        Me.lbWokerStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lbWokerStatus.Location = New System.Drawing.Point(71, 35)
        Me.lbWokerStatus.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lbWokerStatus.Name = "lbWokerStatus"
        Me.lbWokerStatus.Size = New System.Drawing.Size(124, 25)
        Me.lbWokerStatus.TabIndex = 1
        Me.lbWokerStatus.Text = "На работе"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.btCreateTask, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.btStopWork, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.btSuspendWork, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btStartWork, 0, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(33, 150)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(300, 139)
        Me.TableLayoutPanel1.TabIndex = 2
        '
        'btCreateTask
        '
        Me.btCreateTask.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btCreateTask.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btCreateTask.Location = New System.Drawing.Point(5, 73)
        Me.btCreateTask.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.btCreateTask.Name = "btCreateTask"
        Me.btCreateTask.Size = New System.Drawing.Size(140, 62)
        Me.btCreateTask.TabIndex = 3
        Me.btCreateTask.Text = "Отчет"
        Me.btCreateTask.UseVisualStyleBackColor = True
        '
        'btStopWork
        '
        Me.btStopWork.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btStopWork.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btStopWork.Location = New System.Drawing.Point(155, 73)
        Me.btStopWork.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.btStopWork.Name = "btStopWork"
        Me.btStopWork.Size = New System.Drawing.Size(140, 62)
        Me.btStopWork.TabIndex = 2
        Me.btStopWork.Text = "Закончить"
        Me.btStopWork.UseVisualStyleBackColor = True
        '
        'btSuspendWork
        '
        Me.btSuspendWork.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btSuspendWork.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btSuspendWork.Location = New System.Drawing.Point(155, 4)
        Me.btSuspendWork.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.btSuspendWork.Name = "btSuspendWork"
        Me.btSuspendWork.Size = New System.Drawing.Size(140, 61)
        Me.btSuspendWork.TabIndex = 1
        Me.btSuspendWork.Text = "Перерыв"
        Me.btSuspendWork.UseVisualStyleBackColor = True
        '
        'btStartWork
        '
        Me.btStartWork.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btStartWork.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btStartWork.Location = New System.Drawing.Point(5, 4)
        Me.btStartWork.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.btStartWork.Name = "btStartWork"
        Me.btStartWork.Size = New System.Drawing.Size(140, 61)
        Me.btStartWork.TabIndex = 0
        Me.btStartWork.Text = "Начать"
        Me.btStartWork.UseVisualStyleBackColor = True
        '
        'tpMyTime
        '
        Me.tpMyTime.AutoScroll = True
        Me.tpMyTime.Controls.Add(Me.tbctlSalary)
        Me.tpMyTime.Controls.Add(Me.tbEmployeeSum)
        Me.tpMyTime.Controls.Add(Me.Label17)
        Me.tpMyTime.Controls.Add(Me.gbSelectEmployee)
        Me.tpMyTime.Controls.Add(Me.btGetMyTime)
        Me.tpMyTime.Location = New System.Drawing.Point(4, 33)
        Me.tpMyTime.Name = "tpMyTime"
        Me.tpMyTime.Padding = New System.Windows.Forms.Padding(3)
        Me.tpMyTime.Size = New System.Drawing.Size(1045, 434)
        Me.tpMyTime.TabIndex = 6
        Me.tpMyTime.Text = "Мое время"
        Me.tpMyTime.UseVisualStyleBackColor = True
        '
        'tbctlSalary
        '
        Me.tbctlSalary.Controls.Add(Me.tbFromLastSalary)
        Me.tbctlSalary.Controls.Add(Me.tpAllSalary)
        Me.tbctlSalary.Location = New System.Drawing.Point(17, 87)
        Me.tbctlSalary.Name = "tbctlSalary"
        Me.tbctlSalary.SelectedIndex = 0
        Me.tbctlSalary.Size = New System.Drawing.Size(1013, 341)
        Me.tbctlSalary.TabIndex = 8
        '
        'tbFromLastSalary
        '
        Me.tbFromLastSalary.AutoScroll = True
        Me.tbFromLastSalary.Controls.Add(Me.gbCorrectionwTime)
        Me.tbFromLastSalary.Controls.Add(Me.WTimeSummary_ResultDataGridView)
        Me.tbFromLastSalary.Location = New System.Drawing.Point(4, 33)
        Me.tbFromLastSalary.Name = "tbFromLastSalary"
        Me.tbFromLastSalary.Padding = New System.Windows.Forms.Padding(3)
        Me.tbFromLastSalary.Size = New System.Drawing.Size(1005, 304)
        Me.tbFromLastSalary.TabIndex = 0
        Me.tbFromLastSalary.Text = "Неоплачено"
        Me.tbFromLastSalary.UseVisualStyleBackColor = True
        '
        'gbCorrectionwTime
        '
        Me.gbCorrectionwTime.Controls.Add(Me.btRemoveWRecord)
        Me.gbCorrectionwTime.Controls.Add(Me.btAddWRecord)
        Me.gbCorrectionwTime.Controls.Add(Me.DateTimePicker_CorrectWDate)
        Me.gbCorrectionwTime.Controls.Add(Me.btUserCorrect)
        Me.gbCorrectionwTime.Controls.Add(Me.DateTimePicker_correctwTime)
        Me.gbCorrectionwTime.Controls.Add(Me.rbCorrectEndwtime)
        Me.gbCorrectionwTime.Controls.Add(Me.rbCorrectBeginwTime)
        Me.gbCorrectionwTime.Location = New System.Drawing.Point(667, 15)
        Me.gbCorrectionwTime.Name = "gbCorrectionwTime"
        Me.gbCorrectionwTime.Size = New System.Drawing.Size(320, 178)
        Me.gbCorrectionwTime.TabIndex = 9
        Me.gbCorrectionwTime.TabStop = False
        Me.gbCorrectionwTime.Text = "Выбрано"
        '
        'btRemoveWRecord
        '
        Me.btRemoveWRecord.Location = New System.Drawing.Point(214, 141)
        Me.btRemoveWRecord.Name = "btRemoveWRecord"
        Me.btRemoveWRecord.Size = New System.Drawing.Size(100, 31)
        Me.btRemoveWRecord.TabIndex = 11
        Me.btRemoveWRecord.Text = "-"
        Me.btRemoveWRecord.UseVisualStyleBackColor = True
        '
        'btAddWRecord
        '
        Me.btAddWRecord.Location = New System.Drawing.Point(214, 102)
        Me.btAddWRecord.Name = "btAddWRecord"
        Me.btAddWRecord.Size = New System.Drawing.Size(100, 31)
        Me.btAddWRecord.TabIndex = 10
        Me.btAddWRecord.Text = "+"
        Me.btAddWRecord.UseVisualStyleBackColor = True
        '
        'DateTimePicker_CorrectWDate
        '
        Me.DateTimePicker_CorrectWDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.DateTimePicker_CorrectWDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker_CorrectWDate.Location = New System.Drawing.Point(171, 16)
        Me.DateTimePicker_CorrectWDate.Name = "DateTimePicker_CorrectWDate"
        Me.DateTimePicker_CorrectWDate.Size = New System.Drawing.Size(143, 35)
        Me.DateTimePicker_CorrectWDate.TabIndex = 9
        Me.DateTimePicker_CorrectWDate.Value = New Date(2015, 1, 28, 20, 52, 25, 0)
        '
        'btUserCorrect
        '
        Me.btUserCorrect.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btUserCorrect.Location = New System.Drawing.Point(29, 102)
        Me.btUserCorrect.Name = "btUserCorrect"
        Me.btUserCorrect.Size = New System.Drawing.Size(144, 64)
        Me.btUserCorrect.TabIndex = 4
        Me.btUserCorrect.Text = "Корректировка"
        Me.btUserCorrect.UseVisualStyleBackColor = True
        '
        'DateTimePicker_correctwTime
        '
        Me.DateTimePicker_correctwTime.CustomFormat = "HH':'mm"
        Me.DateTimePicker_correctwTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.DateTimePicker_correctwTime.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.DateTimePicker_correctwTime.Location = New System.Drawing.Point(198, 55)
        Me.DateTimePicker_correctwTime.Name = "DateTimePicker_correctwTime"
        Me.DateTimePicker_correctwTime.ShowUpDown = True
        Me.DateTimePicker_correctwTime.Size = New System.Drawing.Size(116, 35)
        Me.DateTimePicker_correctwTime.TabIndex = 8
        Me.DateTimePicker_correctwTime.Value = New Date(2015, 1, 28, 20, 52, 25, 0)
        '
        'rbCorrectEndwtime
        '
        Me.rbCorrectEndwtime.AutoSize = True
        Me.rbCorrectEndwtime.Location = New System.Drawing.Point(15, 62)
        Me.rbCorrectEndwtime.Name = "rbCorrectEndwtime"
        Me.rbCorrectEndwtime.Size = New System.Drawing.Size(127, 28)
        Me.rbCorrectEndwtime.TabIndex = 6
        Me.rbCorrectEndwtime.Text = "Окончание"
        Me.rbCorrectEndwtime.UseVisualStyleBackColor = True
        '
        'rbCorrectBeginwTime
        '
        Me.rbCorrectBeginwTime.AutoSize = True
        Me.rbCorrectBeginwTime.Checked = True
        Me.rbCorrectBeginwTime.Location = New System.Drawing.Point(15, 27)
        Me.rbCorrectBeginwTime.Name = "rbCorrectBeginwTime"
        Me.rbCorrectBeginwTime.Size = New System.Drawing.Size(92, 28)
        Me.rbCorrectBeginwTime.TabIndex = 5
        Me.rbCorrectBeginwTime.TabStop = True
        Me.rbCorrectBeginwTime.Text = "Начало"
        Me.rbCorrectBeginwTime.UseVisualStyleBackColor = True
        '
        'WTimeSummary_ResultDataGridView
        '
        Me.WTimeSummary_ResultDataGridView.AutoGenerateColumns = False
        Me.WTimeSummary_ResultDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.WTimeSummary_ResultDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn8, Me.DataGridViewTextBoxColumn9})
        Me.WTimeSummary_ResultDataGridView.DataSource = Me.WTimeSummary_ResultBindingSource
        Me.WTimeSummary_ResultDataGridView.Location = New System.Drawing.Point(12, 15)
        Me.WTimeSummary_ResultDataGridView.Name = "WTimeSummary_ResultDataGridView"
        Me.WTimeSummary_ResultDataGridView.Size = New System.Drawing.Size(649, 283)
        Me.WTimeSummary_ResultDataGridView.TabIndex = 3
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "CalculateDay"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Дата"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Width = 79
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "StartTime"
        Me.DataGridViewTextBoxColumn4.HeaderText = "Начало"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Width = 99
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "EndTime"
        Me.DataGridViewTextBoxColumn5.HeaderText = "Окончание"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.Width = 134
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "hourvalue"
        Me.DataGridViewTextBoxColumn7.HeaderText = "Часов"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.Width = 88
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "Cost"
        Me.DataGridViewTextBoxColumn8.HeaderText = "Оплата"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.Width = 101
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "Currency"
        Me.DataGridViewTextBoxColumn9.HeaderText = "Валюта"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.Width = 101
        '
        'WTimeSummary_ResultBindingSource
        '
        Me.WTimeSummary_ResultBindingSource.DataSource = GetType(Service.wTimeSummary_Result)
        '
        'tpAllSalary
        '
        Me.tpAllSalary.Controls.Add(Me.Label35)
        Me.tpAllSalary.Controls.Add(Me.Label1)
        Me.tpAllSalary.Controls.Add(Me.DateTimePicker_salary)
        Me.tpAllSalary.Controls.Add(Me.btPaySalary)
        Me.tpAllSalary.Controls.Add(Me.WSalaryInfo_ResultDataGridView)
        Me.tpAllSalary.Location = New System.Drawing.Point(4, 33)
        Me.tpAllSalary.Name = "tpAllSalary"
        Me.tpAllSalary.Padding = New System.Windows.Forms.Padding(3)
        Me.tpAllSalary.Size = New System.Drawing.Size(1005, 304)
        Me.tpAllSalary.TabIndex = 1
        Me.tpAllSalary.Text = "Все зарплаты"
        Me.tpAllSalary.UseVisualStyleBackColor = True
        '
        'Label35
        '
        Me.Label35.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label35.Location = New System.Drawing.Point(849, 180)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(147, 80)
        Me.Label35.TabIndex = 13
        Me.Label35.Text = "После оплаты зп в списке будут две одинаковых до регистрации работы"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(848, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 24)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "На дату"
        '
        'DateTimePicker_salary
        '
        Me.DateTimePicker_salary.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.DateTimePicker_salary.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker_salary.Location = New System.Drawing.Point(846, 40)
        Me.DateTimePicker_salary.Name = "DateTimePicker_salary"
        Me.DateTimePicker_salary.Size = New System.Drawing.Size(143, 35)
        Me.DateTimePicker_salary.TabIndex = 11
        Me.DateTimePicker_salary.Value = New Date(2015, 1, 28, 20, 52, 25, 0)
        '
        'btPaySalary
        '
        Me.btPaySalary.Location = New System.Drawing.Point(863, 100)
        Me.btPaySalary.Name = "btPaySalary"
        Me.btPaySalary.Size = New System.Drawing.Size(114, 63)
        Me.btPaySalary.TabIndex = 10
        Me.btPaySalary.Text = "Оплатить"
        Me.btPaySalary.UseVisualStyleBackColor = True
        '
        'WSalaryInfo_ResultDataGridView
        '
        Me.WSalaryInfo_ResultDataGridView.AllowUserToAddRows = False
        Me.WSalaryInfo_ResultDataGridView.AllowUserToDeleteRows = False
        Me.WSalaryInfo_ResultDataGridView.AutoGenerateColumns = False
        Me.WSalaryInfo_ResultDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.WSalaryInfo_ResultDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CalculateDate, Me.DataGridViewCheckBoxColumn1, Me.DataGridViewTextBoxColumn10, Me.DataGridViewTextBoxColumn11, Me.DataGridViewTextBoxColumn12, Me.DataGridViewTextBoxColumn15, Me.DataGridViewTextBoxColumn14, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn13})
        Me.WSalaryInfo_ResultDataGridView.DataSource = Me.WSalaryInfo_ResultBindingSource
        Me.WSalaryInfo_ResultDataGridView.Location = New System.Drawing.Point(6, 3)
        Me.WSalaryInfo_ResultDataGridView.Name = "WSalaryInfo_ResultDataGridView"
        Me.WSalaryInfo_ResultDataGridView.ReadOnly = True
        Me.WSalaryInfo_ResultDataGridView.Size = New System.Drawing.Size(823, 295)
        Me.WSalaryInfo_ResultDataGridView.TabIndex = 9
        '
        'CalculateDate
        '
        Me.CalculateDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        Me.CalculateDate.DataPropertyName = "CalculateDate"
        Me.CalculateDate.HeaderText = "Дата рассчета"
        Me.CalculateDate.Name = "CalculateDate"
        Me.CalculateDate.ReadOnly = True
        Me.CalculateDate.Width = 5
        '
        'DataGridViewCheckBoxColumn1
        '
        Me.DataGridViewCheckBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewCheckBoxColumn1.DataPropertyName = "Paid"
        Me.DataGridViewCheckBoxColumn1.HeaderText = "Оплата"
        Me.DataGridViewCheckBoxColumn1.Name = "DataGridViewCheckBoxColumn1"
        Me.DataGridViewCheckBoxColumn1.ReadOnly = True
        Me.DataGridViewCheckBoxColumn1.Width = 82
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "DateFromInclude"
        Me.DataGridViewTextBoxColumn10.HeaderText = "С (включ.)"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = True
        Me.DataGridViewTextBoxColumn10.Width = 124
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "DateToInclude"
        Me.DataGridViewTextBoxColumn11.HeaderText = "По (включ.)"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.ReadOnly = True
        Me.DataGridViewTextBoxColumn11.Width = 135
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn12.DataPropertyName = "DayCount"
        Me.DataGridViewTextBoxColumn12.HeaderText = "Дней"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.ReadOnly = True
        Me.DataGridViewTextBoxColumn12.Width = 82
        '
        'DataGridViewTextBoxColumn15
        '
        Me.DataGridViewTextBoxColumn15.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn15.DataPropertyName = "totalHour"
        Me.DataGridViewTextBoxColumn15.HeaderText = "Часов"
        Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
        Me.DataGridViewTextBoxColumn15.ReadOnly = True
        Me.DataGridViewTextBoxColumn15.Width = 88
        '
        'DataGridViewTextBoxColumn14
        '
        Me.DataGridViewTextBoxColumn14.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn14.DataPropertyName = "totalCost"
        Me.DataGridViewTextBoxColumn14.HeaderText = "Итого"
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        Me.DataGridViewTextBoxColumn14.ReadOnly = True
        Me.DataGridViewTextBoxColumn14.Width = 89
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "currency"
        Me.DataGridViewTextBoxColumn6.HeaderText = "Вал."
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Width = 72
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn13.DataPropertyName = "RecordCount"
        Me.DataGridViewTextBoxColumn13.HeaderText = "#зап."
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.ReadOnly = True
        Me.DataGridViewTextBoxColumn13.Width = 81
        '
        'WSalaryInfo_ResultBindingSource
        '
        Me.WSalaryInfo_ResultBindingSource.DataSource = GetType(Service.wSalaryInfo_Result)
        '
        'tbEmployeeSum
        '
        Me.tbEmployeeSum.Enabled = False
        Me.tbEmployeeSum.Location = New System.Drawing.Point(367, 23)
        Me.tbEmployeeSum.Name = "tbEmployeeSum"
        Me.tbEmployeeSum.Size = New System.Drawing.Size(117, 29)
        Me.tbEmployeeSum.TabIndex = 7
        Me.tbEmployeeSum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(192, 25)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(169, 24)
        Me.Label17.TabIndex = 6
        Me.Label17.Text = "Всего по таблице"
        '
        'gbSelectEmployee
        '
        Me.gbSelectEmployee.Controls.Add(Me.cbEmployee)
        Me.gbSelectEmployee.Location = New System.Drawing.Point(635, 6)
        Me.gbSelectEmployee.Name = "gbSelectEmployee"
        Me.gbSelectEmployee.Size = New System.Drawing.Size(401, 75)
        Me.gbSelectEmployee.TabIndex = 5
        Me.gbSelectEmployee.TabStop = False
        '
        'cbEmployee
        '
        Me.cbEmployee.DataSource = Me.TbEmployeeBindingSource
        Me.cbEmployee.DisplayMember = "Name"
        Me.cbEmployee.FormattingEnabled = True
        Me.cbEmployee.Location = New System.Drawing.Point(6, 28)
        Me.cbEmployee.Name = "cbEmployee"
        Me.cbEmployee.Size = New System.Drawing.Size(389, 32)
        Me.cbEmployee.TabIndex = 0
        Me.cbEmployee.ValueMember = "ID"
        '
        'TbEmployeeBindingSource
        '
        Me.TbEmployeeBindingSource.DataSource = GetType(Service.tbEmployee)
        '
        'btGetMyTime
        '
        Me.btGetMyTime.Location = New System.Drawing.Point(17, 16)
        Me.btGetMyTime.Name = "btGetMyTime"
        Me.btGetMyTime.Size = New System.Drawing.Size(126, 39)
        Me.btGetMyTime.TabIndex = 3
        Me.btGetMyTime.Text = "Запросить"
        Me.btGetMyTime.UseVisualStyleBackColor = True
        '
        'tpHwoInOffice
        '
        Me.tpHwoInOffice.Controls.Add(Me.btHwoInOffice)
        Me.tpHwoInOffice.Controls.Add(Me.WInOffice_ResultDataGridView)
        Me.tpHwoInOffice.Location = New System.Drawing.Point(4, 33)
        Me.tpHwoInOffice.Name = "tpHwoInOffice"
        Me.tpHwoInOffice.Padding = New System.Windows.Forms.Padding(3)
        Me.tpHwoInOffice.Size = New System.Drawing.Size(1045, 434)
        Me.tpHwoInOffice.TabIndex = 5
        Me.tpHwoInOffice.Text = "Кто на работе"
        Me.tpHwoInOffice.UseVisualStyleBackColor = True
        '
        'btHwoInOffice
        '
        Me.btHwoInOffice.Location = New System.Drawing.Point(22, 15)
        Me.btHwoInOffice.Name = "btHwoInOffice"
        Me.btHwoInOffice.Size = New System.Drawing.Size(126, 39)
        Me.btHwoInOffice.TabIndex = 2
        Me.btHwoInOffice.Text = "Запросить"
        Me.btHwoInOffice.UseVisualStyleBackColor = True
        '
        'WInOffice_ResultDataGridView
        '
        Me.WInOffice_ResultDataGridView.AutoGenerateColumns = False
        Me.WInOffice_ResultDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.WInOffice_ResultDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.EmployeeNameDataGridViewTextBoxColumn, Me.TimeMarkerDataGridViewTextBoxColumn, Me.OperationNameDataGridViewTextBoxColumn, Me.OperationName, Me.RegisterTime})
        Me.WInOffice_ResultDataGridView.DataSource = Me.WInOffice_ResultBindingSource
        Me.WInOffice_ResultDataGridView.Location = New System.Drawing.Point(22, 68)
        Me.WInOffice_ResultDataGridView.Name = "WInOffice_ResultDataGridView"
        Me.WInOffice_ResultDataGridView.Size = New System.Drawing.Size(1006, 360)
        Me.WInOffice_ResultDataGridView.TabIndex = 0
        '
        'EmployeeNameDataGridViewTextBoxColumn
        '
        Me.EmployeeNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.EmployeeNameDataGridViewTextBoxColumn.DataPropertyName = "EmployeeName"
        Me.EmployeeNameDataGridViewTextBoxColumn.HeaderText = "Имя"
        Me.EmployeeNameDataGridViewTextBoxColumn.Name = "EmployeeNameDataGridViewTextBoxColumn"
        Me.EmployeeNameDataGridViewTextBoxColumn.Width = 71
        '
        'TimeMarkerDataGridViewTextBoxColumn
        '
        Me.TimeMarkerDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.TimeMarkerDataGridViewTextBoxColumn.DataPropertyName = "RegisterDate"
        Me.TimeMarkerDataGridViewTextBoxColumn.HeaderText = "Дата"
        Me.TimeMarkerDataGridViewTextBoxColumn.Name = "TimeMarkerDataGridViewTextBoxColumn"
        Me.TimeMarkerDataGridViewTextBoxColumn.Width = 79
        '
        'OperationNameDataGridViewTextBoxColumn
        '
        Me.OperationNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.OperationNameDataGridViewTextBoxColumn.DataPropertyName = "RegisterTime"
        Me.OperationNameDataGridViewTextBoxColumn.HeaderText = "Время"
        Me.OperationNameDataGridViewTextBoxColumn.Name = "OperationNameDataGridViewTextBoxColumn"
        Me.OperationNameDataGridViewTextBoxColumn.Width = 92
        '
        'OperationName
        '
        Me.OperationName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.OperationName.DataPropertyName = "OperationName"
        Me.OperationName.HeaderText = "Операция"
        Me.OperationName.Name = "OperationName"
        Me.OperationName.Width = 125
        '
        'RegisterTime
        '
        Me.RegisterTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.RegisterTime.DataPropertyName = "RegisterTime"
        Me.RegisterTime.HeaderText = "Время регистрации"
        Me.RegisterTime.Name = "RegisterTime"
        Me.RegisterTime.Width = 194
        '
        'WInOffice_ResultBindingSource
        '
        Me.WInOffice_ResultBindingSource.DataSource = GetType(Service.wInOffice_Result)
        '
        'tpNewSample
        '
        Me.tpNewSample.Controls.Add(Me.tcSampleParam)
        Me.tpNewSample.Controls.Add(Me.btResetPrinter2)
        Me.tpNewSample.Controls.Add(Me.btPrintNumberLabel2)
        Me.tpNewSample.Controls.Add(Me.Label11)
        Me.tpNewSample.Controls.Add(Me.TableLayoutPanel3)
        Me.tpNewSample.Location = New System.Drawing.Point(4, 33)
        Me.tpNewSample.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.tpNewSample.Name = "tpNewSample"
        Me.tpNewSample.Padding = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.tpNewSample.Size = New System.Drawing.Size(1045, 434)
        Me.tpNewSample.TabIndex = 1
        Me.tpNewSample.Text = "Новый"
        Me.tpNewSample.UseVisualStyleBackColor = True
        '
        'tcSampleParam
        '
        Me.tcSampleParam.Controls.Add(Me.tpLotParam)
        Me.tcSampleParam.Controls.Add(Me.tpOperationParam)
        Me.tcSampleParam.Controls.Add(Me.tpExpeditionParam)
        Me.tcSampleParam.Controls.Add(Me.tpOperationPayment)
        Me.tcSampleParam.Location = New System.Drawing.Point(385, 22)
        Me.tcSampleParam.Name = "tcSampleParam"
        Me.tcSampleParam.SelectedIndex = 0
        Me.tcSampleParam.Size = New System.Drawing.Size(652, 335)
        Me.tcSampleParam.TabIndex = 34
        '
        'tpLotParam
        '
        Me.tpLotParam.Controls.Add(Me.lbOperationPayment)
        Me.tpLotParam.Controls.Add(Me.lbxOperations)
        Me.tpLotParam.Controls.Add(Me.btCreateOperation)
        Me.tpLotParam.Controls.Add(Me.lbOperationWarning)
        Me.tpLotParam.Controls.Add(Me.ComboBox4)
        Me.tpLotParam.Controls.Add(Me.Button6)
        Me.tpLotParam.Controls.Add(Me.btStartOperation)
        Me.tpLotParam.Controls.Add(Me.tbQtyInLot)
        Me.tpLotParam.Controls.Add(Me.Label7)
        Me.tpLotParam.Controls.Add(Me.rbSingleSample)
        Me.tpLotParam.Controls.Add(Me.rbLotSample)
        Me.tpLotParam.Controls.Add(Me.cbUom)
        Me.tpLotParam.Location = New System.Drawing.Point(4, 33)
        Me.tpLotParam.Name = "tpLotParam"
        Me.tpLotParam.Padding = New System.Windows.Forms.Padding(3)
        Me.tpLotParam.Size = New System.Drawing.Size(644, 298)
        Me.tpLotParam.TabIndex = 0
        Me.tpLotParam.Text = "Основное"
        Me.tpLotParam.UseVisualStyleBackColor = True
        '
        'lbOperationPayment
        '
        Me.lbOperationPayment.AutoSize = True
        Me.lbOperationPayment.Location = New System.Drawing.Point(10, 269)
        Me.lbOperationPayment.Name = "lbOperationPayment"
        Me.lbOperationPayment.Size = New System.Drawing.Size(200, 24)
        Me.lbOperationPayment.TabIndex = 40
        Me.lbOperationPayment.Text = "подробности оплаты"
        '
        'lbxOperations
        '
        Me.lbxOperations.DataSource = Me.TbSMOperationBindingSource
        Me.lbxOperations.FormattingEnabled = True
        Me.lbxOperations.ItemHeight = 24
        Me.lbxOperations.Location = New System.Drawing.Point(189, 141)
        Me.lbxOperations.Name = "lbxOperations"
        Me.lbxOperations.Size = New System.Drawing.Size(449, 124)
        Me.lbxOperations.TabIndex = 39
        '
        'TbSMOperationBindingSource
        '
        Me.TbSMOperationBindingSource.DataSource = GetType(Service.tbSMOperation)
        '
        'btCreateOperation
        '
        Me.btCreateOperation.Location = New System.Drawing.Point(13, 121)
        Me.btCreateOperation.Name = "btCreateOperation"
        Me.btCreateOperation.Size = New System.Drawing.Size(167, 63)
        Me.btCreateOperation.TabIndex = 38
        Me.btCreateOperation.Text = "Создать операцию"
        Me.btCreateOperation.UseVisualStyleBackColor = True
        '
        'lbOperationWarning
        '
        Me.lbOperationWarning.AutoSize = True
        Me.lbOperationWarning.Location = New System.Drawing.Point(267, 114)
        Me.lbOperationWarning.Name = "lbOperationWarning"
        Me.lbOperationWarning.Size = New System.Drawing.Size(273, 24)
        Me.lbOperationWarning.TabIndex = 18
        Me.lbOperationWarning.Text = "всего операций:   <выбрать>"
        '
        'ComboBox4
        '
        Me.ComboBox4.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TbSMLotBindingSource, "PreName", True))
        Me.ComboBox4.FormattingEnabled = True
        Me.ComboBox4.Location = New System.Drawing.Point(14, 79)
        Me.ComboBox4.Name = "ComboBox4"
        Me.ComboBox4.Size = New System.Drawing.Size(417, 32)
        Me.ComboBox4.TabIndex = 17
        '
        'TbSMLotBindingSource
        '
        Me.TbSMLotBindingSource.DataSource = GetType(Service.tbSMLot)
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(480, 4)
        Me.Button6.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(159, 65)
        Me.Button6.TabIndex = 16
        Me.Button6.Text = "Сделать фото"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'btStartOperation
        '
        Me.btStartOperation.Location = New System.Drawing.Point(12, 193)
        Me.btStartOperation.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.btStartOperation.Name = "btStartOperation"
        Me.btStartOperation.Size = New System.Drawing.Size(168, 65)
        Me.btStartOperation.TabIndex = 15
        Me.btStartOperation.Text = "операцию - в работу!"
        Me.btStartOperation.UseVisualStyleBackColor = True
        '
        'tbQtyInLot
        '
        Me.tbQtyInLot.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TbSMLotBindingSource, "qty", True))
        Me.tbQtyInLot.Location = New System.Drawing.Point(307, 17)
        Me.tbQtyInLot.Name = "tbQtyInLot"
        Me.tbQtyInLot.Size = New System.Drawing.Size(67, 29)
        Me.tbQtyInLot.TabIndex = 4
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(14, 52)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(344, 24)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "Предварительное название образца"
        '
        'rbSingleSample
        '
        Me.rbSingleSample.AutoSize = True
        Me.rbSingleSample.Checked = True
        Me.rbSingleSample.Location = New System.Drawing.Point(17, 17)
        Me.rbSingleSample.Name = "rbSingleSample"
        Me.rbSingleSample.Size = New System.Drawing.Size(133, 28)
        Me.rbSingleSample.TabIndex = 0
        Me.rbSingleSample.TabStop = True
        Me.rbSingleSample.Text = "Одиночный"
        Me.rbSingleSample.UseVisualStyleBackColor = True
        '
        'rbLotSample
        '
        Me.rbLotSample.AutoSize = True
        Me.rbLotSample.Location = New System.Drawing.Point(153, 17)
        Me.rbLotSample.Name = "rbLotSample"
        Me.rbLotSample.Size = New System.Drawing.Size(136, 28)
        Me.rbLotSample.TabIndex = 1
        Me.rbLotSample.TabStop = True
        Me.rbLotSample.Text = "Лот (кол-во)"
        Me.rbLotSample.UseVisualStyleBackColor = True
        '
        'cbUom
        '
        Me.cbUom.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.TbSMLotBindingSource, "uomID", True))
        Me.cbUom.DataSource = Me.TbUomBindingSource
        Me.cbUom.DisplayMember = "Name"
        Me.cbUom.FormattingEnabled = True
        Me.cbUom.Location = New System.Drawing.Point(389, 16)
        Me.cbUom.Name = "cbUom"
        Me.cbUom.Size = New System.Drawing.Size(67, 32)
        Me.cbUom.TabIndex = 2
        Me.cbUom.ValueMember = "ID"
        '
        'TbUomBindingSource
        '
        Me.TbUomBindingSource.DataSource = GetType(Service.tbUom)
        '
        'tpOperationParam
        '
        Me.tpOperationParam.Controls.Add(Me.rtbOperationComment)
        Me.tpOperationParam.Controls.Add(Me.lbxWorkOperation)
        Me.tpOperationParam.Controls.Add(Me.cbOperationUom)
        Me.tpOperationParam.Controls.Add(Me.tbAccountingQty)
        Me.tpOperationParam.Controls.Add(Me.Label5)
        Me.tpOperationParam.Location = New System.Drawing.Point(4, 33)
        Me.tpOperationParam.Name = "tpOperationParam"
        Me.tpOperationParam.Padding = New System.Windows.Forms.Padding(3)
        Me.tpOperationParam.Size = New System.Drawing.Size(644, 298)
        Me.tpOperationParam.TabIndex = 2
        Me.tpOperationParam.Text = "Операция подробно"
        Me.tpOperationParam.UseVisualStyleBackColor = True
        '
        'rtbOperationComment
        '
        Me.rtbOperationComment.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TbSMOperationBindingSource, "Remark", True))
        Me.rtbOperationComment.Location = New System.Drawing.Point(6, 196)
        Me.rtbOperationComment.Name = "rtbOperationComment"
        Me.rtbOperationComment.Size = New System.Drawing.Size(629, 96)
        Me.rtbOperationComment.TabIndex = 42
        Me.rtbOperationComment.Text = ""
        '
        'lbxWorkOperation
        '
        Me.lbxWorkOperation.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.TbSMOperationBindingSource, "SMWorkOperationID", True))
        Me.lbxWorkOperation.DataSource = Me.TbSMWorkOperationBindingSource
        Me.lbxWorkOperation.DisplayMember = "Name"
        Me.lbxWorkOperation.FormattingEnabled = True
        Me.lbxWorkOperation.ItemHeight = 24
        Me.lbxWorkOperation.Location = New System.Drawing.Point(6, 45)
        Me.lbxWorkOperation.Name = "lbxWorkOperation"
        Me.lbxWorkOperation.Size = New System.Drawing.Size(629, 148)
        Me.lbxWorkOperation.TabIndex = 41
        Me.lbxWorkOperation.ValueMember = "ID"
        '
        'TbSMWorkOperationBindingSource
        '
        Me.TbSMWorkOperationBindingSource.DataSource = GetType(Service.tbSMWorkOperation)
        '
        'cbOperationUom
        '
        Me.cbOperationUom.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.TbSMOperationBindingSource, "uomID", True))
        Me.cbOperationUom.DataSource = Me.TbUomBindingSource
        Me.cbOperationUom.DisplayMember = "Name"
        Me.cbOperationUom.FormattingEnabled = True
        Me.cbOperationUom.Location = New System.Drawing.Point(555, 7)
        Me.cbOperationUom.Name = "cbOperationUom"
        Me.cbOperationUom.Size = New System.Drawing.Size(67, 32)
        Me.cbOperationUom.TabIndex = 39
        Me.cbOperationUom.ValueMember = "ID"
        '
        'tbAccountingQty
        '
        Me.tbAccountingQty.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TbSMOperationBindingSource, "AccuntingQty", True))
        Me.tbAccountingQty.Location = New System.Drawing.Point(485, 8)
        Me.tbAccountingQty.Name = "tbAccountingQty"
        Me.tbAccountingQty.Size = New System.Drawing.Size(64, 29)
        Me.tbAccountingQty.TabIndex = 38
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(330, 11)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(149, 24)
        Me.Label5.TabIndex = 36
        Me.Label5.Text = "Учетное кол-во"
        '
        'tpExpeditionParam
        '
        Me.tpExpeditionParam.Controls.Add(Me.btLoadExpeditionFromMC)
        Me.tpExpeditionParam.Controls.Add(Me.tbExpeditionNr)
        Me.tpExpeditionParam.Controls.Add(Me.Label19)
        Me.tpExpeditionParam.Controls.Add(Me.cbExpedition)
        Me.tpExpeditionParam.Controls.Add(Me.Label18)
        Me.tpExpeditionParam.Controls.Add(Me.rtbRollText)
        Me.tpExpeditionParam.Controls.Add(Me.Label13)
        Me.tpExpeditionParam.Location = New System.Drawing.Point(4, 33)
        Me.tpExpeditionParam.Name = "tpExpeditionParam"
        Me.tpExpeditionParam.Padding = New System.Windows.Forms.Padding(3)
        Me.tpExpeditionParam.Size = New System.Drawing.Size(644, 298)
        Me.tpExpeditionParam.TabIndex = 1
        Me.tpExpeditionParam.Text = "Экспедиция"
        Me.tpExpeditionParam.UseVisualStyleBackColor = True
        '
        'btLoadExpeditionFromMC
        '
        Me.btLoadExpeditionFromMC.Location = New System.Drawing.Point(516, 179)
        Me.btLoadExpeditionFromMC.Name = "btLoadExpeditionFromMC"
        Me.btLoadExpeditionFromMC.Size = New System.Drawing.Size(119, 51)
        Me.btLoadExpeditionFromMC.TabIndex = 6
        Me.btLoadExpeditionFromMC.Text = "из МС"
        Me.btLoadExpeditionFromMC.UseVisualStyleBackColor = True
        '
        'tbExpeditionNr
        '
        Me.tbExpeditionNr.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TbSMLotBindingSource, "ExpeditionNumber", True))
        Me.tbExpeditionNr.Location = New System.Drawing.Point(464, 10)
        Me.tbExpeditionNr.Name = "tbExpeditionNr"
        Me.tbExpeditionNr.Size = New System.Drawing.Size(100, 29)
        Me.tbExpeditionNr.TabIndex = 5
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(284, 11)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(165, 24)
        Me.Label19.TabIndex = 4
        Me.Label19.Text = "Экспедиц. номер"
        '
        'cbExpedition
        '
        Me.cbExpedition.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TbSMLotBindingSource, "Expedition", True))
        Me.cbExpedition.FormattingEnabled = True
        Me.cbExpedition.Location = New System.Drawing.Point(11, 141)
        Me.cbExpedition.Name = "cbExpedition"
        Me.cbExpedition.Size = New System.Drawing.Size(624, 32)
        Me.cbExpedition.TabIndex = 3
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(13, 111)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(119, 24)
        Me.Label18.TabIndex = 2
        Me.Label18.Text = "Экспедиция"
        '
        'rtbRollText
        '
        Me.rtbRollText.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TbSMLotBindingSource, "RollText", True))
        Me.rtbRollText.Location = New System.Drawing.Point(10, 46)
        Me.rtbRollText.Name = "rtbRollText"
        Me.rtbRollText.Size = New System.Drawing.Size(628, 50)
        Me.rtbRollText.TabIndex = 1
        Me.rtbRollText.Text = ""
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(6, 19)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(165, 24)
        Me.Label13.TabIndex = 0
        Me.Label13.Text = "Текст со свертка"
        '
        'tpOperationPayment
        '
        Me.tpOperationPayment.AutoScroll = True
        Me.tpOperationPayment.Controls.Add(Me.gbPayByWoker)
        Me.tpOperationPayment.Controls.Add(Me.gbPayByAdmin)
        Me.tpOperationPayment.Location = New System.Drawing.Point(4, 33)
        Me.tpOperationPayment.Name = "tpOperationPayment"
        Me.tpOperationPayment.Padding = New System.Windows.Forms.Padding(3)
        Me.tpOperationPayment.Size = New System.Drawing.Size(644, 298)
        Me.tpOperationPayment.TabIndex = 3
        Me.tpOperationPayment.Text = "Оплата"
        Me.tpOperationPayment.UseVisualStyleBackColor = True
        '
        'gbPayByWoker
        '
        Me.gbPayByWoker.Controls.Add(Me.Label20)
        Me.gbPayByWoker.Controls.Add(Me.rbWokerPerHour)
        Me.gbPayByWoker.Controls.Add(Me.tbHourByWorker)
        Me.gbPayByWoker.Controls.Add(Me.rbWokerPerSumma)
        Me.gbPayByWoker.Controls.Add(Me.tbSumByWoker)
        Me.gbPayByWoker.Location = New System.Drawing.Point(9, 134)
        Me.gbPayByWoker.Name = "gbPayByWoker"
        Me.gbPayByWoker.Size = New System.Drawing.Size(632, 90)
        Me.gbPayByWoker.TabIndex = 41
        Me.gbPayByWoker.TabStop = False
        Me.gbPayByWoker.Text = "Оплата фактически или запрошена "
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(208, 35)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(45, 24)
        Me.Label20.TabIndex = 5
        Me.Label20.Text = "час."
        '
        'rbWokerPerHour
        '
        Me.rbWokerPerHour.AutoSize = True
        Me.rbWokerPerHour.Location = New System.Drawing.Point(16, 34)
        Me.rbWokerPerHour.Name = "rbWokerPerHour"
        Me.rbWokerPerHour.Size = New System.Drawing.Size(124, 28)
        Me.rbWokerPerHour.TabIndex = 0
        Me.rbWokerPerHour.TabStop = True
        Me.rbWokerPerHour.Text = "Почасовая"
        Me.rbWokerPerHour.UseVisualStyleBackColor = True
        '
        'tbHourByWorker
        '
        Me.tbHourByWorker.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TbSMOperationBindingSource, "timesetbywoker", True))
        Me.tbHourByWorker.Location = New System.Drawing.Point(146, 32)
        Me.tbHourByWorker.Name = "tbHourByWorker"
        Me.tbHourByWorker.Size = New System.Drawing.Size(56, 29)
        Me.tbHourByWorker.TabIndex = 4
        '
        'rbWokerPerSumma
        '
        Me.rbWokerPerSumma.AutoSize = True
        Me.rbWokerPerSumma.Location = New System.Drawing.Point(305, 30)
        Me.rbWokerPerSumma.Name = "rbWokerPerSumma"
        Me.rbWokerPerSumma.Size = New System.Drawing.Size(116, 28)
        Me.rbWokerPerSumma.TabIndex = 1
        Me.rbWokerPerSumma.TabStop = True
        Me.rbWokerPerSumma.Text = "Сдельная"
        Me.rbWokerPerSumma.UseVisualStyleBackColor = True
        '
        'tbSumByWoker
        '
        Me.tbSumByWoker.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TbSMOperationBindingSource, "amountsetbywoker", True))
        Me.tbSumByWoker.Location = New System.Drawing.Point(425, 29)
        Me.tbSumByWoker.Name = "tbSumByWoker"
        Me.tbSumByWoker.Size = New System.Drawing.Size(100, 29)
        Me.tbSumByWoker.TabIndex = 2
        '
        'gbPayByAdmin
        '
        Me.gbPayByAdmin.Controls.Add(Me.Label12)
        Me.gbPayByAdmin.Controls.Add(Me.cbTariff)
        Me.gbPayByAdmin.Controls.Add(Me.rbTariff)
        Me.gbPayByAdmin.Controls.Add(Me.cbCurrencyOperation)
        Me.gbPayByAdmin.Controls.Add(Me.Label16)
        Me.gbPayByAdmin.Controls.Add(Me.rbPerHour)
        Me.gbPayByAdmin.Controls.Add(Me.tbAdminHourPay)
        Me.gbPayByAdmin.Controls.Add(Me.rbSumma)
        Me.gbPayByAdmin.Controls.Add(Me.tbAdminSumPay)
        Me.gbPayByAdmin.Location = New System.Drawing.Point(6, 16)
        Me.gbPayByAdmin.Name = "gbPayByAdmin"
        Me.gbPayByAdmin.Size = New System.Drawing.Size(632, 112)
        Me.gbPayByAdmin.TabIndex = 35
        Me.gbPayByAdmin.TabStop = False
        Me.gbPayByAdmin.Text = "Оплата определена мастером"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(187, 77)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(126, 24)
        Me.Label12.TabIndex = 8
        Me.Label12.Text = "сумма/тариф"
        '
        'cbTariff
        '
        Me.cbTariff.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.TbSMOperationBindingSource, "tariffID", True))
        Me.cbTariff.DataSource = Me.TbSMTariffBindingSource
        Me.cbTariff.DisplayMember = "Name"
        Me.cbTariff.FormattingEnabled = True
        Me.cbTariff.Location = New System.Drawing.Point(411, 32)
        Me.cbTariff.Name = "cbTariff"
        Me.cbTariff.Size = New System.Drawing.Size(215, 32)
        Me.cbTariff.TabIndex = 7
        Me.cbTariff.ValueMember = "ID"
        '
        'TbSMTariffBindingSource
        '
        Me.TbSMTariffBindingSource.DataSource = GetType(Service.tbSMTariff)
        '
        'rbTariff
        '
        Me.rbTariff.AutoSize = True
        Me.rbTariff.Location = New System.Drawing.Point(317, 34)
        Me.rbTariff.Name = "rbTariff"
        Me.rbTariff.Size = New System.Drawing.Size(86, 28)
        Me.rbTariff.TabIndex = 6
        Me.rbTariff.TabStop = True
        Me.rbTariff.Text = "Тариф"
        Me.rbTariff.UseVisualStyleBackColor = True
        '
        'cbCurrencyOperation
        '
        Me.cbCurrencyOperation.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TbSMOperationBindingSource, "Currency", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.cbCurrencyOperation.FormattingEnabled = True
        Me.cbCurrencyOperation.Items.AddRange(New Object() {"RUR", "EUR", "USD"})
        Me.cbCurrencyOperation.Location = New System.Drawing.Point(428, 71)
        Me.cbCurrencyOperation.Name = "cbCurrencyOperation"
        Me.cbCurrencyOperation.Size = New System.Drawing.Size(70, 32)
        Me.cbCurrencyOperation.TabIndex = 3
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(78, 71)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(62, 24)
        Me.Label16.TabIndex = 5
        Me.Label16.Text = "часов"
        '
        'rbPerHour
        '
        Me.rbPerHour.AutoSize = True
        Me.rbPerHour.Location = New System.Drawing.Point(16, 34)
        Me.rbPerHour.Name = "rbPerHour"
        Me.rbPerHour.Size = New System.Drawing.Size(124, 28)
        Me.rbPerHour.TabIndex = 0
        Me.rbPerHour.TabStop = True
        Me.rbPerHour.Text = "Почасовая"
        Me.rbPerHour.UseVisualStyleBackColor = True
        '
        'tbAdminHourPay
        '
        Me.tbAdminHourPay.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TbSMOperationBindingSource, "timesetbyadmin", True))
        Me.tbAdminHourPay.Location = New System.Drawing.Point(16, 68)
        Me.tbAdminHourPay.Name = "tbAdminHourPay"
        Me.tbAdminHourPay.Size = New System.Drawing.Size(56, 29)
        Me.tbAdminHourPay.TabIndex = 4
        '
        'rbSumma
        '
        Me.rbSumma.AutoSize = True
        Me.rbSumma.Location = New System.Drawing.Point(169, 34)
        Me.rbSumma.Name = "rbSumma"
        Me.rbSumma.Size = New System.Drawing.Size(116, 28)
        Me.rbSumma.TabIndex = 1
        Me.rbSumma.TabStop = True
        Me.rbSumma.Text = "Сдельная"
        Me.rbSumma.UseVisualStyleBackColor = True
        '
        'tbAdminSumPay
        '
        Me.tbAdminSumPay.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TbSMOperationBindingSource, "amountsetbyadmin", True))
        Me.tbAdminSumPay.Location = New System.Drawing.Point(319, 74)
        Me.tbAdminSumPay.Name = "tbAdminSumPay"
        Me.tbAdminSumPay.Size = New System.Drawing.Size(100, 29)
        Me.tbAdminSumPay.TabIndex = 2
        '
        'btResetPrinter2
        '
        Me.btResetPrinter2.Location = New System.Drawing.Point(198, 283)
        Me.btResetPrinter2.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.btResetPrinter2.Name = "btResetPrinter2"
        Me.btResetPrinter2.Size = New System.Drawing.Size(168, 65)
        Me.btResetPrinter2.TabIndex = 31
        Me.btResetPrinter2.Text = "Сброс принтера"
        Me.btResetPrinter2.UseVisualStyleBackColor = True
        '
        'btPrintNumberLabel2
        '
        Me.btPrintNumberLabel2.Location = New System.Drawing.Point(24, 283)
        Me.btPrintNumberLabel2.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.btPrintNumberLabel2.Name = "btPrintNumberLabel2"
        Me.btPrintNumberLabel2.Size = New System.Drawing.Size(168, 65)
        Me.btPrintNumberLabel2.TabIndex = 14
        Me.btPrintNumberLabel2.Text = "Печать номера"
        Me.btPrintNumberLabel2.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(29, 22)
        Me.Label11.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(212, 24)
        Me.Label11.TabIndex = 11
        Me.Label11.Text = "Возможные действия:"
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 2
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.00001!))
        Me.TableLayoutPanel3.Controls.Add(Me.btRegisterSchema, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.btWithoutNumber, 1, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.btClear, 0, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.btSaveLot, 1, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.tbSchemeNumber, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.btCreateSchema, 0, 1)
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(24, 51)
        Me.TableLayoutPanel3.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 3
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(347, 224)
        Me.TableLayoutPanel3.TabIndex = 10
        '
        'btRegisterSchema
        '
        Me.btRegisterSchema.Location = New System.Drawing.Point(178, 4)
        Me.btRegisterSchema.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.btRegisterSchema.Name = "btRegisterSchema"
        Me.btRegisterSchema.Size = New System.Drawing.Size(164, 66)
        Me.btRegisterSchema.TabIndex = 1
        Me.btRegisterSchema.Text = "Есть схема/номер"
        Me.btRegisterSchema.UseVisualStyleBackColor = True
        '
        'btWithoutNumber
        '
        Me.btWithoutNumber.Location = New System.Drawing.Point(176, 77)
        Me.btWithoutNumber.Name = "btWithoutNumber"
        Me.btWithoutNumber.Size = New System.Drawing.Size(168, 68)
        Me.btWithoutNumber.TabIndex = 4
        Me.btWithoutNumber.Text = "Без номера"
        Me.btWithoutNumber.UseVisualStyleBackColor = True
        '
        'btClear
        '
        Me.btClear.Location = New System.Drawing.Point(5, 152)
        Me.btClear.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.btClear.Name = "btClear"
        Me.btClear.Size = New System.Drawing.Size(163, 66)
        Me.btClear.TabIndex = 0
        Me.btClear.Text = "Очистить"
        Me.btClear.UseVisualStyleBackColor = True
        '
        'btSaveLot
        '
        Me.btSaveLot.Location = New System.Drawing.Point(176, 151)
        Me.btSaveLot.Name = "btSaveLot"
        Me.btSaveLot.Size = New System.Drawing.Size(167, 70)
        Me.btSaveLot.TabIndex = 6
        Me.btSaveLot.Text = "Сохранить в БД"
        Me.btSaveLot.UseVisualStyleBackColor = True
        '
        'tbSchemeNumber
        '
        Me.tbSchemeNumber.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbSchemeNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbSchemeNumber.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TbSMLotBindingSource, "LotNumber", True))
        Me.tbSchemeNumber.Location = New System.Drawing.Point(3, 22)
        Me.tbSchemeNumber.Name = "tbSchemeNumber"
        Me.tbSchemeNumber.Size = New System.Drawing.Size(167, 29)
        Me.tbSchemeNumber.TabIndex = 5
        '
        'btCreateSchema
        '
        Me.btCreateSchema.Location = New System.Drawing.Point(5, 78)
        Me.btCreateSchema.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.btCreateSchema.Name = "btCreateSchema"
        Me.btCreateSchema.Size = New System.Drawing.Size(163, 66)
        Me.btCreateSchema.TabIndex = 3
        Me.btCreateSchema.Text = "Получить схему"
        Me.btCreateSchema.UseVisualStyleBackColor = True
        '
        'tpAccepting
        '
        Me.tpAccepting.Controls.Add(Me.Label15)
        Me.tpAccepting.Controls.Add(Me.Label14)
        Me.tpAccepting.Controls.Add(Me.Button10)
        Me.tpAccepting.Controls.Add(Me.Button9)
        Me.tpAccepting.Controls.Add(Me.Button8)
        Me.tpAccepting.Controls.Add(Me.Button7)
        Me.tpAccepting.Controls.Add(Me.DataGridView1)
        Me.tpAccepting.Controls.Add(Me.TextBox4)
        Me.tpAccepting.Controls.Add(Me.ListBox1)
        Me.tpAccepting.Controls.Add(Me.Label4)
        Me.tpAccepting.Location = New System.Drawing.Point(4, 33)
        Me.tpAccepting.Name = "tpAccepting"
        Me.tpAccepting.Size = New System.Drawing.Size(1045, 434)
        Me.tpAccepting.TabIndex = 4
        Me.tpAccepting.Text = "Приемка"
        Me.tpAccepting.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(589, 11)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(315, 24)
        Me.Label15.TabIndex = 34
        Me.Label15.Text = "завершает процесс учета номера"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(322, 220)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(335, 24)
        Me.Label14.TabIndex = 33
        Me.Label14.Text = "извлекает учетный образец из лота"
        '
        'Button10
        '
        Me.Button10.Location = New System.Drawing.Point(857, 289)
        Me.Button10.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(168, 65)
        Me.Button10.TabIndex = 32
        Me.Button10.Text = "Сброс принтера"
        Me.Button10.UseVisualStyleBackColor = True
        '
        'Button9
        '
        Me.Button9.Location = New System.Drawing.Point(857, 216)
        Me.Button9.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(168, 65)
        Me.Button9.TabIndex = 19
        Me.Button9.Text = "Печать номера"
        Me.Button9.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.Location = New System.Drawing.Point(669, 216)
        Me.Button8.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(168, 65)
        Me.Button8.TabIndex = 18
        Me.Button8.Text = "Получить номер"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Button7.Location = New System.Drawing.Point(400, 4)
        Me.Button7.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(169, 37)
        Me.Button7.TabIndex = 17
        Me.Button7.Text = "Завершить учет"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(205, 48)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(820, 161)
        Me.DataGridView1.TabIndex = 3
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(198, 4)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(175, 29)
        Me.TextBox4.TabIndex = 2
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 24
        Me.ListBox1.Location = New System.Drawing.Point(9, 38)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(190, 316)
        Me.ListBox1.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(11, 5)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(173, 24)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Сданные образцы"
        '
        'tpToParts
        '
        Me.tpToParts.Controls.Add(Me.RichTextBox2)
        Me.tpToParts.Location = New System.Drawing.Point(4, 33)
        Me.tpToParts.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.tpToParts.Name = "tpToParts"
        Me.tpToParts.Padding = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.tpToParts.Size = New System.Drawing.Size(1045, 434)
        Me.tpToParts.TabIndex = 3
        Me.tpToParts.Text = "В запчасти"
        Me.tpToParts.UseVisualStyleBackColor = True
        '
        'RichTextBox2
        '
        Me.RichTextBox2.Location = New System.Drawing.Point(23, 8)
        Me.RichTextBox2.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.RichTextBox2.Name = "RichTextBox2"
        Me.RichTextBox2.Size = New System.Drawing.Size(645, 302)
        Me.RichTextBox2.TabIndex = 0
        Me.RichTextBox2.Text = resources.GetString("RichTextBox2.Text")
        '
        'tpSmallScheme
        '
        Me.tpSmallScheme.Location = New System.Drawing.Point(4, 33)
        Me.tpSmallScheme.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.tpSmallScheme.Name = "tpSmallScheme"
        Me.tpSmallScheme.Size = New System.Drawing.Size(1045, 434)
        Me.tpSmallScheme.TabIndex = 2
        Me.tpSmallScheme.Text = "Схема"
        Me.tpSmallScheme.UseVisualStyleBackColor = True
        '
        'tpParcels
        '
        Me.tpParcels.Controls.Add(Me.tbctlParcels)
        Me.tpParcels.Location = New System.Drawing.Point(4, 33)
        Me.tpParcels.Name = "tpParcels"
        Me.tpParcels.Padding = New System.Windows.Forms.Padding(3)
        Me.tpParcels.Size = New System.Drawing.Size(1045, 434)
        Me.tpParcels.TabIndex = 7
        Me.tpParcels.Text = "Посылки на отправку"
        Me.tpParcels.UseVisualStyleBackColor = True
        '
        'tbctlParcels
        '
        Me.tbctlParcels.Controls.Add(Me.tpParcelToShip)
        Me.tbctlParcels.Controls.Add(Me.tbDeclaration)
        Me.tbctlParcels.Controls.Add(Me.tpParcelResult)
        Me.tbctlParcels.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbctlParcels.Location = New System.Drawing.Point(3, 3)
        Me.tbctlParcels.Name = "tbctlParcels"
        Me.tbctlParcels.SelectedIndex = 0
        Me.tbctlParcels.Size = New System.Drawing.Size(1039, 428)
        Me.tbctlParcels.TabIndex = 2
        '
        'tpParcelToShip
        '
        Me.tpParcelToShip.AutoScroll = True
        Me.tpParcelToShip.Controls.Add(Me.PictureBox1)
        Me.tpParcelToShip.Controls.Add(Me.Label32)
        Me.tpParcelToShip.Controls.Add(Me.Label31)
        Me.tpParcelToShip.Controls.Add(Me.lblItemsInParcel)
        Me.tpParcelToShip.Controls.Add(Me.gbParcelCount)
        Me.tpParcelToShip.Controls.Add(Label25)
        Me.tpParcelToShip.Controls.Add(Label34)
        Me.tpParcelToShip.Controls.Add(Me.cbParcelType)
        Me.tpParcelToShip.Controls.Add(Label33)
        Me.tpParcelToShip.Controls.Add(Me.cbParcelGroup)
        Me.tpParcelToShip.Controls.Add(Me.cbCurrentItemList)
        Me.tpParcelToShip.Controls.Add(Me.btParcelResult)
        Me.tpParcelToShip.Controls.Add(Me.TextBox10)
        Me.tpParcelToShip.Controls.Add(Me.TextBox11)
        Me.tpParcelToShip.Controls.Add(Me.Label30)
        Me.tpParcelToShip.Controls.Add(Me.Label29)
        Me.tpParcelToShip.Controls.Add(Me.tbParcelSizeC)
        Me.tpParcelToShip.Controls.Add(Me.tbParcelSizeB)
        Me.tpParcelToShip.Controls.Add(Me.tbParcelSizeA)
        Me.tpParcelToShip.Controls.Add(Me.Label28)
        Me.tpParcelToShip.Controls.Add(Me.tbParcelWeight)
        Me.tpParcelToShip.Controls.Add(Me.Label27)
        Me.tpParcelToShip.Controls.Add(Me.tbSKU)
        Me.tpParcelToShip.Controls.Add(Me.Label26)
        Me.tpParcelToShip.Controls.Add(CityLabel)
        Me.tpParcelToShip.Controls.Add(Me.CityTextBox)
        Me.tpParcelToShip.Controls.Add(CountryLabel)
        Me.tpParcelToShip.Controls.Add(Me.CountryTextBox)
        Me.tpParcelToShip.Controls.Add(NameLabel)
        Me.tpParcelToShip.Controls.Add(Me.NameTextBox)
        Me.tpParcelToShip.Controls.Add(PhoneLabel)
        Me.tpParcelToShip.Controls.Add(Me.PhoneTextBox)
        Me.tpParcelToShip.Controls.Add(PostIndexLabel)
        Me.tpParcelToShip.Controls.Add(Me.PostIndexTextBox)
        Me.tpParcelToShip.Controls.Add(StateLabel)
        Me.tpParcelToShip.Controls.Add(Me.StateTextBox)
        Me.tpParcelToShip.Controls.Add(StreetLabel)
        Me.tpParcelToShip.Controls.Add(Me.StreetTextBox)
        Me.tpParcelToShip.Location = New System.Drawing.Point(4, 33)
        Me.tpParcelToShip.Name = "tpParcelToShip"
        Me.tpParcelToShip.Padding = New System.Windows.Forms.Padding(3)
        Me.tpParcelToShip.Size = New System.Drawing.Size(1031, 391)
        Me.tpParcelToShip.TabIndex = 0
        Me.tpParcelToShip.Text = "Необходимо отправить"
        Me.tpParcelToShip.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(543, 64)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(209, 145)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 46
        Me.PictureBox1.TabStop = False
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label32.Location = New System.Drawing.Point(9, 84)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(382, 18)
        Me.Label32.TabIndex = 45
        Me.Label32.Text = "*будут запрошены ТОЛЬКО непроведенные отгрузки"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label31.Location = New System.Drawing.Point(650, 293)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(370, 18)
        Me.Label31.TabIndex = 44
        Me.Label31.Text = "* номера камней, которые должны быть в посылке"
        '
        'lblItemsInParcel
        '
        Me.lblItemsInParcel.AutoSize = True
        Me.lblItemsInParcel.Location = New System.Drawing.Point(385, 5)
        Me.lblItemsInParcel.Name = "lblItemsInParcel"
        Me.lblItemsInParcel.Size = New System.Drawing.Size(443, 24)
        Me.lblItemsInParcel.TabIndex = 43
        Me.lblItemsInParcel.Text = "(раскрой список) Надо упаковать в эту посылку:"
        '
        'gbParcelCount
        '
        Me.gbParcelCount.Controls.Add(Me.btRequestParcels)
        Me.gbParcelCount.Controls.Add(Me.BindingNavigator1)
        Me.gbParcelCount.Location = New System.Drawing.Point(6, 5)
        Me.gbParcelCount.Name = "gbParcelCount"
        Me.gbParcelCount.Size = New System.Drawing.Size(373, 77)
        Me.gbParcelCount.TabIndex = 42
        Me.gbParcelCount.TabStop = False
        Me.gbParcelCount.Text = "Всего посылок"
        '
        'btRequestParcels
        '
        Me.btRequestParcels.Location = New System.Drawing.Point(6, 28)
        Me.btRequestParcels.Name = "btRequestParcels"
        Me.btRequestParcels.Size = New System.Drawing.Size(105, 34)
        Me.btRequestParcels.TabIndex = 37
        Me.btRequestParcels.Text = "Получить"
        Me.btRequestParcels.UseVisualStyleBackColor = True
        '
        'BindingNavigator1
        '
        Me.BindingNavigator1.AddNewItem = Nothing
        Me.BindingNavigator1.BindingSource = Me.IMoySkladDataProvider_ParcelInfoBindingSource
        Me.BindingNavigator1.CountItem = Me.BindingNavigatorCountItem
        Me.BindingNavigator1.DeleteItem = Nothing
        Me.BindingNavigator1.Dock = System.Windows.Forms.DockStyle.None
        Me.BindingNavigator1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.BindingNavigator1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2})
        Me.BindingNavigator1.Location = New System.Drawing.Point(119, 33)
        Me.BindingNavigator1.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.BindingNavigator1.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.BindingNavigator1.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.BindingNavigator1.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.BindingNavigator1.Name = "BindingNavigator1"
        Me.BindingNavigator1.PositionItem = Me.BindingNavigatorPositionItem
        Me.BindingNavigator1.Size = New System.Drawing.Size(232, 29)
        Me.BindingNavigator1.TabIndex = 16
        Me.BindingNavigator1.Text = "BindingNavigator1"
        '
        'IMoySkladDataProvider_ParcelInfoBindingSource
        '
        Me.IMoySkladDataProvider_ParcelInfoBindingSource.DataSource = GetType(Service.iMoySkladDataProvider.clsParcelInfo)
        '
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(58, 26)
        Me.BindingNavigatorCountItem.Text = "для {0}"
        Me.BindingNavigatorCountItem.ToolTipText = "Общее число элементов"
        '
        'BindingNavigatorMoveFirstItem
        '
        Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
        Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(23, 26)
        Me.BindingNavigatorMoveFirstItem.Text = "Переместить в начало"
        '
        'BindingNavigatorMovePreviousItem
        '
        Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
        Me.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(23, 26)
        Me.BindingNavigatorMovePreviousItem.Text = "Переместить назад"
        '
        'BindingNavigatorSeparator
        '
        Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 29)
        '
        'BindingNavigatorPositionItem
        '
        Me.BindingNavigatorPositionItem.AccessibleName = "Положение"
        Me.BindingNavigatorPositionItem.AutoSize = False
        Me.BindingNavigatorPositionItem.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem"
        Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(50, 29)
        Me.BindingNavigatorPositionItem.Text = "0"
        Me.BindingNavigatorPositionItem.ToolTipText = "Текущее положение"
        '
        'BindingNavigatorSeparator1
        '
        Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator1"
        Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 29)
        '
        'BindingNavigatorMoveNextItem
        '
        Me.BindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveNextItem.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
        Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(23, 26)
        Me.BindingNavigatorMoveNextItem.Text = "Переместить вперед"
        '
        'BindingNavigatorMoveLastItem
        '
        Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
        Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(23, 26)
        Me.BindingNavigatorMoveLastItem.Text = "Переместить в конец"
        '
        'BindingNavigatorSeparator2
        '
        Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2"
        Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 29)
        '
        'cbParcelType
        '
        Me.cbParcelType.DataBindings.Add(New System.Windows.Forms.Binding("SelectedItem", Me.IMoySkladDataProvider_ResultParcelInfoBindingSource, "ParcelType", True))
        Me.cbParcelType.FormattingEnabled = True
        Me.cbParcelType.Items.AddRange(New Object() {"Maksikiri taht", "Standardpakk"})
        Me.cbParcelType.Location = New System.Drawing.Point(851, 142)
        Me.cbParcelType.Name = "cbParcelType"
        Me.cbParcelType.Size = New System.Drawing.Size(169, 32)
        Me.cbParcelType.TabIndex = 40
        '
        'IMoySkladDataProvider_ResultParcelInfoBindingSource
        '
        Me.IMoySkladDataProvider_ResultParcelInfoBindingSource.DataSource = GetType(Service.iMoySkladDataProvider.clsResultParcelInfo)
        '
        'cbParcelGroup
        '
        Me.cbParcelGroup.DataBindings.Add(New System.Windows.Forms.Binding("SelectedItem", Me.IMoySkladDataProvider_ResultParcelInfoBindingSource, "ParcelGroup", True))
        Me.cbParcelGroup.FormattingEnabled = True
        Me.cbParcelGroup.Items.AddRange(New Object() {"письма", "посылки"})
        Me.cbParcelGroup.Location = New System.Drawing.Point(868, 77)
        Me.cbParcelGroup.Name = "cbParcelGroup"
        Me.cbParcelGroup.Size = New System.Drawing.Size(152, 32)
        Me.cbParcelGroup.TabIndex = 38
        '
        'cbCurrentItemList
        '
        Me.cbCurrentItemList.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.cbCurrentItemList.FormattingEnabled = True
        Me.cbCurrentItemList.Location = New System.Drawing.Point(385, 32)
        Me.cbCurrentItemList.Name = "cbCurrentItemList"
        Me.cbCurrentItemList.Size = New System.Drawing.Size(635, 26)
        Me.cbCurrentItemList.TabIndex = 36
        '
        'btParcelResult
        '
        Me.btParcelResult.Location = New System.Drawing.Point(860, 324)
        Me.btParcelResult.Name = "btParcelResult"
        Me.btParcelResult.Size = New System.Drawing.Size(165, 61)
        Me.btParcelResult.TabIndex = 32
        Me.btParcelResult.Text = "Отправить"
        Me.btParcelResult.UseVisualStyleBackColor = True
        '
        'TextBox10
        '
        Me.TextBox10.Location = New System.Drawing.Point(196, 324)
        Me.TextBox10.Name = "TextBox10"
        Me.TextBox10.Size = New System.Drawing.Size(398, 29)
        Me.TextBox10.TabIndex = 30
        '
        'TextBox11
        '
        Me.TextBox11.Location = New System.Drawing.Point(349, 356)
        Me.TextBox11.Name = "TextBox11"
        Me.TextBox11.Size = New System.Drawing.Size(265, 29)
        Me.TextBox11.TabIndex = 29
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(16, 356)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(327, 24)
        Me.Label30.TabIndex = 28
        Me.Label30.Text = "*Оповещения получателя: телефон"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(14, 324)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(176, 24)
        Me.Label29.TabIndex = 26
        Me.Label29.Text = "*Контактное лицо:"
        '
        'tbParcelSizeC
        '
        Me.tbParcelSizeC.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.IMoySkladDataProvider_ResultParcelInfoBindingSource, "ParcelSizeC", True))
        Me.tbParcelSizeC.Location = New System.Drawing.Point(972, 225)
        Me.tbParcelSizeC.Name = "tbParcelSizeC"
        Me.tbParcelSizeC.Size = New System.Drawing.Size(48, 29)
        Me.tbParcelSizeC.TabIndex = 25
        '
        'tbParcelSizeB
        '
        Me.tbParcelSizeB.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.IMoySkladDataProvider_ResultParcelInfoBindingSource, "ParcelSizeB", True))
        Me.tbParcelSizeB.Location = New System.Drawing.Point(918, 225)
        Me.tbParcelSizeB.Name = "tbParcelSizeB"
        Me.tbParcelSizeB.Size = New System.Drawing.Size(48, 29)
        Me.tbParcelSizeB.TabIndex = 24
        '
        'tbParcelSizeA
        '
        Me.tbParcelSizeA.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.IMoySkladDataProvider_ResultParcelInfoBindingSource, "ParcelSizeA", True))
        Me.tbParcelSizeA.Location = New System.Drawing.Point(864, 225)
        Me.tbParcelSizeA.Name = "tbParcelSizeA"
        Me.tbParcelSizeA.Size = New System.Drawing.Size(48, 29)
        Me.tbParcelSizeA.TabIndex = 23
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(772, 228)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(90, 24)
        Me.Label28.TabIndex = 22
        Me.Label28.Text = "Д/Ш/В (м)"
        '
        'tbParcelWeight
        '
        Me.tbParcelWeight.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.IMoySkladDataProvider_ResultParcelInfoBindingSource, "ParcelWeight", True))
        Me.tbParcelWeight.Location = New System.Drawing.Point(953, 190)
        Me.tbParcelWeight.Name = "tbParcelWeight"
        Me.tbParcelWeight.Size = New System.Drawing.Size(67, 29)
        Me.tbParcelWeight.TabIndex = 21
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(872, 192)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(73, 24)
        Me.Label27.TabIndex = 20
        Me.Label27.Text = "Вес(кг)"
        '
        'tbSKU
        '
        Me.tbSKU.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.IMoySkladDataProvider_ResultParcelInfoBindingSource, "Comment", True))
        Me.tbSKU.Location = New System.Drawing.Point(701, 260)
        Me.tbSKU.Name = "tbSKU"
        Me.tbSKU.Size = New System.Drawing.Size(319, 29)
        Me.tbSKU.TabIndex = 19
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(557, 263)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(134, 24)
        Me.Label26.TabIndex = 18
        Me.Label26.Text = "Комментарий"
        '
        'CityTextBox
        '
        Me.CityTextBox.Location = New System.Drawing.Point(182, 257)
        Me.CityTextBox.Name = "CityTextBox"
        Me.CityTextBox.Size = New System.Drawing.Size(265, 29)
        Me.CityTextBox.TabIndex = 1
        '
        'CountryTextBox
        '
        Me.CountryTextBox.Location = New System.Drawing.Point(225, 107)
        Me.CountryTextBox.Name = "CountryTextBox"
        Me.CountryTextBox.Size = New System.Drawing.Size(186, 29)
        Me.CountryTextBox.TabIndex = 3
        '
        'NameTextBox
        '
        Me.NameTextBox.Location = New System.Drawing.Point(139, 142)
        Me.NameTextBox.Name = "NameTextBox"
        Me.NameTextBox.Size = New System.Drawing.Size(398, 29)
        Me.NameTextBox.TabIndex = 7
        '
        'PhoneTextBox
        '
        Me.PhoneTextBox.Location = New System.Drawing.Point(114, 290)
        Me.PhoneTextBox.Name = "PhoneTextBox"
        Me.PhoneTextBox.Size = New System.Drawing.Size(265, 29)
        Me.PhoneTextBox.TabIndex = 9
        '
        'PostIndexTextBox
        '
        Me.PostIndexTextBox.Location = New System.Drawing.Point(99, 215)
        Me.PostIndexTextBox.Name = "PostIndexTextBox"
        Me.PostIndexTextBox.Size = New System.Drawing.Size(144, 29)
        Me.PostIndexTextBox.TabIndex = 11
        '
        'StateTextBox
        '
        Me.StateTextBox.Location = New System.Drawing.Point(410, 218)
        Me.StateTextBox.Name = "StateTextBox"
        Me.StateTextBox.Size = New System.Drawing.Size(189, 29)
        Me.StateTextBox.TabIndex = 13
        '
        'StreetTextBox
        '
        Me.StreetTextBox.Location = New System.Drawing.Point(139, 180)
        Me.StreetTextBox.Name = "StreetTextBox"
        Me.StreetTextBox.Size = New System.Drawing.Size(398, 29)
        Me.StreetTextBox.TabIndex = 15
        '
        'tbDeclaration
        '
        Me.tbDeclaration.AutoScroll = True
        Me.tbDeclaration.Controls.Add(Me.IMoySkladDataProvider_Declaration_CP71_CN23DataGridView)
        Me.tbDeclaration.Location = New System.Drawing.Point(4, 33)
        Me.tbDeclaration.Name = "tbDeclaration"
        Me.tbDeclaration.Padding = New System.Windows.Forms.Padding(3)
        Me.tbDeclaration.Size = New System.Drawing.Size(178, 31)
        Me.tbDeclaration.TabIndex = 2
        Me.tbDeclaration.Text = "Декларация"
        Me.tbDeclaration.UseVisualStyleBackColor = True
        '
        'IMoySkladDataProvider_Declaration_CP71_CN23DataGridView
        '
        Me.IMoySkladDataProvider_Declaration_CP71_CN23DataGridView.AutoGenerateColumns = False
        Me.IMoySkladDataProvider_Declaration_CP71_CN23DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.IMoySkladDataProvider_Declaration_CP71_CN23DataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn17, Me.DataGridViewTextBoxColumn18, Me.DataGridViewTextBoxColumn19, Me.DataGridViewTextBoxColumn20, Me.DataGridViewTextBoxColumn23})
        Me.IMoySkladDataProvider_Declaration_CP71_CN23DataGridView.DataSource = Me.IMoySkladDataProvider_Declaration_CP71_CN23BindingSource
        Me.IMoySkladDataProvider_Declaration_CP71_CN23DataGridView.Location = New System.Drawing.Point(6, 6)
        Me.IMoySkladDataProvider_Declaration_CP71_CN23DataGridView.Name = "IMoySkladDataProvider_Declaration_CP71_CN23DataGridView"
        Me.IMoySkladDataProvider_Declaration_CP71_CN23DataGridView.Size = New System.Drawing.Size(1011, 125)
        Me.IMoySkladDataProvider_Declaration_CP71_CN23DataGridView.TabIndex = 0
        '
        'DataGridViewTextBoxColumn17
        '
        Me.DataGridViewTextBoxColumn17.DataPropertyName = "content"
        Me.DataGridViewTextBoxColumn17.HeaderText = "content"
        Me.DataGridViewTextBoxColumn17.Name = "DataGridViewTextBoxColumn17"
        '
        'DataGridViewTextBoxColumn18
        '
        Me.DataGridViewTextBoxColumn18.DataPropertyName = "Comments"
        Me.DataGridViewTextBoxColumn18.HeaderText = "Comments"
        Me.DataGridViewTextBoxColumn18.Name = "DataGridViewTextBoxColumn18"
        '
        'DataGridViewTextBoxColumn19
        '
        Me.DataGridViewTextBoxColumn19.DataPropertyName = "Instructionfornondelivery"
        Me.DataGridViewTextBoxColumn19.HeaderText = "Instructionfornondelivery"
        Me.DataGridViewTextBoxColumn19.Name = "DataGridViewTextBoxColumn19"
        '
        'DataGridViewTextBoxColumn20
        '
        Me.DataGridViewTextBoxColumn20.DataPropertyName = "ReturnSpeed"
        Me.DataGridViewTextBoxColumn20.HeaderText = "ReturnSpeed"
        Me.DataGridViewTextBoxColumn20.Name = "DataGridViewTextBoxColumn20"
        '
        'DataGridViewTextBoxColumn23
        '
        Me.DataGridViewTextBoxColumn23.DataPropertyName = "ReturnAddress"
        Me.DataGridViewTextBoxColumn23.HeaderText = "ReturnAddress"
        Me.DataGridViewTextBoxColumn23.Name = "DataGridViewTextBoxColumn23"
        '
        'IMoySkladDataProvider_Declaration_CP71_CN23BindingSource
        '
        Me.IMoySkladDataProvider_Declaration_CP71_CN23BindingSource.DataSource = GetType(Service.iMoySkladDataProvider.clsDeclaration_CP71_CN23)
        '
        'tpParcelResult
        '
        Me.tpParcelResult.AutoScroll = True
        Me.tpParcelResult.Controls.Add(Me.btSaveShipping)
        Me.tpParcelResult.Controls.Add(Me.btRemovePackageGood)
        Me.tpParcelResult.Controls.Add(Me.btAddPackageGood)
        Me.tpParcelResult.Controls.Add(Me.tbEnterPackageGood)
        Me.tpParcelResult.Controls.Add(Me.Label24)
        Me.tpParcelResult.Controls.Add(Me.PackagingGoodsUUIDsAndQtysDataGridView)
        Me.tpParcelResult.Controls.Add(TrackNumberLabel)
        Me.tpParcelResult.Controls.Add(Me.TrackNumberTextBox)
        Me.tpParcelResult.Controls.Add(Label23)
        Me.tpParcelResult.Controls.Add(Me.cbShippingWoker)
        Me.tpParcelResult.Controls.Add(Label22)
        Me.tpParcelResult.Controls.Add(Me.cbShippingCompany)
        Me.tpParcelResult.Controls.Add(Me.cbShippingCurrency)
        Me.tpParcelResult.Controls.Add(ShippingAmountLabel)
        Me.tpParcelResult.Controls.Add(Me.ShippingAmountTextBox)
        Me.tpParcelResult.Controls.Add(HandlingAmountLabel)
        Me.tpParcelResult.Controls.Add(Me.HandlingAmountTextBox)
        Me.tpParcelResult.Location = New System.Drawing.Point(4, 33)
        Me.tpParcelResult.Name = "tpParcelResult"
        Me.tpParcelResult.Padding = New System.Windows.Forms.Padding(3)
        Me.tpParcelResult.Size = New System.Drawing.Size(178, 31)
        Me.tpParcelResult.TabIndex = 1
        Me.tpParcelResult.Text = "Отправленная посылка"
        Me.tpParcelResult.UseVisualStyleBackColor = True
        '
        'btSaveShipping
        '
        Me.btSaveShipping.Location = New System.Drawing.Point(139, 258)
        Me.btSaveShipping.Name = "btSaveShipping"
        Me.btSaveShipping.Size = New System.Drawing.Size(181, 48)
        Me.btSaveShipping.TabIndex = 16
        Me.btSaveShipping.Text = "Сохранить"
        Me.btSaveShipping.UseVisualStyleBackColor = True
        '
        'btRemovePackageGood
        '
        Me.btRemovePackageGood.Location = New System.Drawing.Point(801, 51)
        Me.btRemovePackageGood.Name = "btRemovePackageGood"
        Me.btRemovePackageGood.Size = New System.Drawing.Size(75, 34)
        Me.btRemovePackageGood.TabIndex = 15
        Me.btRemovePackageGood.Text = "-"
        Me.btRemovePackageGood.UseVisualStyleBackColor = True
        '
        'btAddPackageGood
        '
        Me.btAddPackageGood.Location = New System.Drawing.Point(711, 51)
        Me.btAddPackageGood.Name = "btAddPackageGood"
        Me.btAddPackageGood.Size = New System.Drawing.Size(75, 34)
        Me.btAddPackageGood.TabIndex = 14
        Me.btAddPackageGood.Text = "+"
        Me.btAddPackageGood.UseVisualStyleBackColor = True
        '
        'tbEnterPackageGood
        '
        Me.tbEnterPackageGood.Location = New System.Drawing.Point(520, 53)
        Me.tbEnterPackageGood.Name = "tbEnterPackageGood"
        Me.tbEnterPackageGood.Size = New System.Drawing.Size(174, 29)
        Me.tbEnterPackageGood.TabIndex = 13
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(516, 9)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(361, 24)
        Me.Label24.TabIndex = 12
        Me.Label24.Text = "Доп. расходы для упаковки и отправки"
        '
        'PackagingGoodsUUIDsAndQtysDataGridView
        '
        Me.PackagingGoodsUUIDsAndQtysDataGridView.AutoGenerateColumns = False
        Me.PackagingGoodsUUIDsAndQtysDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.PackagingGoodsUUIDsAndQtysDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clmGoodName, Me.DataGridViewTextBoxColumn21, Me.DataGridViewTextBoxColumn22})
        Me.PackagingGoodsUUIDsAndQtysDataGridView.DataSource = Me.PackagingGoodsUUIDsAndQtysBindingSource
        Me.PackagingGoodsUUIDsAndQtysDataGridView.Location = New System.Drawing.Point(516, 96)
        Me.PackagingGoodsUUIDsAndQtysDataGridView.Name = "PackagingGoodsUUIDsAndQtysDataGridView"
        Me.PackagingGoodsUUIDsAndQtysDataGridView.Size = New System.Drawing.Size(498, 220)
        Me.PackagingGoodsUUIDsAndQtysDataGridView.TabIndex = 11
        '
        'clmGoodName
        '
        Me.clmGoodName.HeaderText = "Товар"
        Me.clmGoodName.Name = "clmGoodName"
        Me.clmGoodName.Width = 250
        '
        'DataGridViewTextBoxColumn21
        '
        Me.DataGridViewTextBoxColumn21.DataPropertyName = "Qty"
        Me.DataGridViewTextBoxColumn21.HeaderText = "Кол-во"
        Me.DataGridViewTextBoxColumn21.Name = "DataGridViewTextBoxColumn21"
        '
        'DataGridViewTextBoxColumn22
        '
        Me.DataGridViewTextBoxColumn22.DataPropertyName = "Amount"
        Me.DataGridViewTextBoxColumn22.HeaderText = "Цена"
        Me.DataGridViewTextBoxColumn22.Name = "DataGridViewTextBoxColumn22"
        '
        'PackagingGoodsUUIDsAndQtysBindingSource
        '
        Me.PackagingGoodsUUIDsAndQtysBindingSource.DataMember = "PackagingGoodsUUIDsAndQtys"
        Me.PackagingGoodsUUIDsAndQtysBindingSource.DataSource = Me.IMoySkladDataProvider_ResultParcelInfoBindingSource
        '
        'TrackNumberTextBox
        '
        Me.TrackNumberTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.IMoySkladDataProvider_ResultParcelInfoBindingSource, "TrackNumber", True))
        Me.TrackNumberTextBox.Location = New System.Drawing.Point(139, 100)
        Me.TrackNumberTextBox.Name = "TrackNumberTextBox"
        Me.TrackNumberTextBox.Size = New System.Drawing.Size(246, 29)
        Me.TrackNumberTextBox.TabIndex = 10
        '
        'cbShippingWoker
        '
        Me.cbShippingWoker.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.IMoySkladDataProvider_ResultParcelInfoBindingSource, "SenderUUID", True))
        Me.cbShippingWoker.DisplayMember = "Keys"
        Me.cbShippingWoker.FormattingEnabled = True
        Me.cbShippingWoker.Location = New System.Drawing.Point(237, 6)
        Me.cbShippingWoker.Name = "cbShippingWoker"
        Me.cbShippingWoker.Size = New System.Drawing.Size(190, 32)
        Me.cbShippingWoker.TabIndex = 7
        Me.cbShippingWoker.ValueMember = "Keys"
        '
        'cbShippingCompany
        '
        Me.cbShippingCompany.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.IMoySkladDataProvider_ResultParcelInfoBindingSource, "ShippingCompanyUUID", True))
        Me.cbShippingCompany.DisplayMember = "Keys"
        Me.cbShippingCompany.FormattingEnabled = True
        Me.cbShippingCompany.Location = New System.Drawing.Point(237, 53)
        Me.cbShippingCompany.Name = "cbShippingCompany"
        Me.cbShippingCompany.Size = New System.Drawing.Size(190, 32)
        Me.cbShippingCompany.TabIndex = 5
        Me.cbShippingCompany.ValueMember = "Keys"
        '
        'cbShippingCurrency
        '
        Me.cbShippingCurrency.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.IMoySkladDataProvider_ResultParcelInfoBindingSource, "ShippingAndHandlingCurrencyUUID", True))
        Me.cbShippingCurrency.DisplayMember = "Keys"
        Me.cbShippingCurrency.FormattingEnabled = True
        Me.cbShippingCurrency.Location = New System.Drawing.Point(428, 174)
        Me.cbShippingCurrency.Name = "cbShippingCurrency"
        Me.cbShippingCurrency.Size = New System.Drawing.Size(66, 32)
        Me.cbShippingCurrency.TabIndex = 4
        Me.cbShippingCurrency.ValueMember = "Keys"
        '
        'ShippingAmountTextBox
        '
        Me.ShippingAmountTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.IMoySkladDataProvider_ResultParcelInfoBindingSource, "ShippingAmount", True))
        Me.ShippingAmountTextBox.Location = New System.Drawing.Point(333, 149)
        Me.ShippingAmountTextBox.Name = "ShippingAmountTextBox"
        Me.ShippingAmountTextBox.Size = New System.Drawing.Size(78, 29)
        Me.ShippingAmountTextBox.TabIndex = 3
        '
        'HandlingAmountTextBox
        '
        Me.HandlingAmountTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.IMoySkladDataProvider_ResultParcelInfoBindingSource, "HandlingAmount", True))
        Me.HandlingAmountTextBox.Location = New System.Drawing.Point(333, 201)
        Me.HandlingAmountTextBox.Name = "HandlingAmountTextBox"
        Me.HandlingAmountTextBox.Size = New System.Drawing.Size(78, 29)
        Me.HandlingAmountTextBox.TabIndex = 1
        '
        'tpSampleInfo
        '
        Me.tpSampleInfo.Controls.Add(Me.Uc_trilbone_history1)
        Me.tpSampleInfo.Location = New System.Drawing.Point(4, 33)
        Me.tpSampleInfo.Name = "tpSampleInfo"
        Me.tpSampleInfo.Padding = New System.Windows.Forms.Padding(3)
        Me.tpSampleInfo.Size = New System.Drawing.Size(1045, 434)
        Me.tpSampleInfo.TabIndex = 8
        Me.tpSampleInfo.Text = "Инфо"
        Me.tpSampleInfo.UseVisualStyleBackColor = True
        '
        'Uc_trilbone_history1
        '
        Me.Uc_trilbone_history1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Uc_trilbone_history1.Location = New System.Drawing.Point(3, 3)
        Me.Uc_trilbone_history1.Margin = New System.Windows.Forms.Padding(6)
        Me.Uc_trilbone_history1.Name = "Uc_trilbone_history1"
        Me.Uc_trilbone_history1.Size = New System.Drawing.Size(1039, 428)
        Me.Uc_trilbone_history1.TabIndex = 0
        '
        'tpRfid
        '
        Me.tpRfid.Controls.Add(Me.cbxMoySkladAsk)
        Me.tpRfid.Controls.Add(Me.lbLocationInfo)
        Me.tpRfid.Controls.Add(Me.btPrinterClear)
        Me.tpRfid.Controls.Add(Me.btPrintLabel)
        Me.tpRfid.Controls.Add(Me.pbEANLabel)
        Me.tpRfid.Controls.Add(Me.UC_rfid1)
        Me.tpRfid.Location = New System.Drawing.Point(4, 33)
        Me.tpRfid.Name = "tpRfid"
        Me.tpRfid.Size = New System.Drawing.Size(1045, 434)
        Me.tpRfid.TabIndex = 9
        Me.tpRfid.Text = "RFID"
        Me.tpRfid.UseVisualStyleBackColor = True
        '
        'cbxMoySkladAsk
        '
        Me.cbxMoySkladAsk.AutoSize = True
        Me.cbxMoySkladAsk.Location = New System.Drawing.Point(520, 26)
        Me.cbxMoySkladAsk.Name = "cbxMoySkladAsk"
        Me.cbxMoySkladAsk.Size = New System.Drawing.Size(210, 28)
        Me.cbxMoySkladAsk.TabIndex = 5
        Me.cbxMoySkladAsk.Text = "Показывать данные"
        Me.cbxMoySkladAsk.UseVisualStyleBackColor = True
        '
        'lbLocationInfo
        '
        Me.lbLocationInfo.AutoSize = True
        Me.lbLocationInfo.Location = New System.Drawing.Point(520, 290)
        Me.lbLocationInfo.Name = "lbLocationInfo"
        Me.lbLocationInfo.Size = New System.Drawing.Size(0, 24)
        Me.lbLocationInfo.TabIndex = 4
        '
        'btPrinterClear
        '
        Me.btPrinterClear.Location = New System.Drawing.Point(833, 26)
        Me.btPrinterClear.Name = "btPrinterClear"
        Me.btPrinterClear.Size = New System.Drawing.Size(195, 35)
        Me.btPrinterClear.TabIndex = 3
        Me.btPrinterClear.Text = "Сброс принтера"
        Me.btPrinterClear.UseVisualStyleBackColor = True
        '
        'btPrintLabel
        '
        Me.btPrintLabel.Location = New System.Drawing.Point(520, 207)
        Me.btPrintLabel.Name = "btPrintLabel"
        Me.btPrintLabel.Size = New System.Drawing.Size(177, 58)
        Me.btPrintLabel.TabIndex = 2
        Me.btPrintLabel.Text = "Печать"
        Me.btPrintLabel.UseVisualStyleBackColor = True
        '
        'pbEANLabel
        '
        Me.pbEANLabel.Image = Global.Trilbone_load.My.Resources.Resources.City_No_Camera_icon
        Me.pbEANLabel.Location = New System.Drawing.Point(520, 76)
        Me.pbEANLabel.Name = "pbEANLabel"
        Me.pbEANLabel.Size = New System.Drawing.Size(177, 110)
        Me.pbEANLabel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbEANLabel.TabIndex = 1
        Me.pbEANLabel.TabStop = False
        '
        'UC_rfid1
        '
        Me.UC_rfid1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.UC_rfid1.Location = New System.Drawing.Point(0, 0)
        Me.UC_rfid1.Margin = New System.Windows.Forms.Padding(6)
        Me.UC_rfid1.Name = "UC_rfid1"
        Me.UC_rfid1.SampleNumber = ""
        Me.UC_rfid1.Size = New System.Drawing.Size(477, 428)
        Me.UC_rfid1.TabIndex = 0
        '
        'tpEmployee
        '
        Me.tpEmployee.Controls.Add(Me.Uc_Employee1)
        Me.tpEmployee.Location = New System.Drawing.Point(4, 33)
        Me.tpEmployee.Name = "tpEmployee"
        Me.tpEmployee.Padding = New System.Windows.Forms.Padding(3)
        Me.tpEmployee.Size = New System.Drawing.Size(1045, 434)
        Me.tpEmployee.TabIndex = 10
        Me.tpEmployee.Text = "Сотрудники"
        Me.tpEmployee.UseVisualStyleBackColor = True
        '
        'Uc_Employee1
        '
        Me.Uc_Employee1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Uc_Employee1.Location = New System.Drawing.Point(3, 3)
        Me.Uc_Employee1.Margin = New System.Windows.Forms.Padding(6)
        Me.Uc_Employee1.Name = "Uc_Employee1"
        Me.Uc_Employee1.Size = New System.Drawing.Size(1039, 428)
        Me.Uc_Employee1.TabIndex = 0
        '
        'tpOnSale
        '
        Me.tpOnSale.Controls.Add(Me.UcReadySamples1)
        Me.tpOnSale.Location = New System.Drawing.Point(4, 33)
        Me.tpOnSale.Name = "tpOnSale"
        Me.tpOnSale.Padding = New System.Windows.Forms.Padding(3)
        Me.tpOnSale.Size = New System.Drawing.Size(1045, 434)
        Me.tpOnSale.TabIndex = 11
        Me.tpOnSale.Text = "На сайт"
        Me.tpOnSale.UseVisualStyleBackColor = True
        '
        'UcReadySamples1
        '
        Me.UcReadySamples1.Location = New System.Drawing.Point(0, 6)
        Me.UcReadySamples1.Margin = New System.Windows.Forms.Padding(6)
        Me.UcReadySamples1.Name = "UcReadySamples1"
        Me.UcReadySamples1.Size = New System.Drawing.Size(661, 419)
        Me.UcReadySamples1.TabIndex = 0
        '
        'tpSellRegister
        '
        Me.tpSellRegister.Controls.Add(Me.UcSellGood1)
        Me.tpSellRegister.Location = New System.Drawing.Point(4, 33)
        Me.tpSellRegister.Name = "tpSellRegister"
        Me.tpSellRegister.Padding = New System.Windows.Forms.Padding(3)
        Me.tpSellRegister.Size = New System.Drawing.Size(1045, 434)
        Me.tpSellRegister.TabIndex = 12
        Me.tpSellRegister.Text = "Продажа"
        Me.tpSellRegister.UseVisualStyleBackColor = True
        '
        'UcSellGood1
        '
        Me.UcSellGood1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcSellGood1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.UcSellGood1.Location = New System.Drawing.Point(3, 3)
        Me.UcSellGood1.Margin = New System.Windows.Forms.Padding(6)
        Me.UcSellGood1.Name = "UcSellGood1"
        Me.UcSellGood1.Size = New System.Drawing.Size(1039, 428)
        Me.UcSellGood1.TabIndex = 0
        '
        'tpeBayInfo
        '
        Me.tpeBayInfo.Controls.Add(Me.UcEbayHistory1)
        Me.tpeBayInfo.Location = New System.Drawing.Point(4, 33)
        Me.tpeBayInfo.Name = "tpeBayInfo"
        Me.tpeBayInfo.Padding = New System.Windows.Forms.Padding(3)
        Me.tpeBayInfo.Size = New System.Drawing.Size(1045, 434)
        Me.tpeBayInfo.TabIndex = 13
        Me.tpeBayInfo.Text = "eBay"
        Me.tpeBayInfo.UseVisualStyleBackColor = True
        '
        'UcEbayHistory1
        '
        Me.UcEbayHistory1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcEbayHistory1.Location = New System.Drawing.Point(3, 3)
        Me.UcEbayHistory1.Margin = New System.Windows.Forms.Padding(6)
        Me.UcEbayHistory1.Name = "UcEbayHistory1"
        Me.UcEbayHistory1.Size = New System.Drawing.Size(1039, 428)
        Me.UcEbayHistory1.TabIndex = 0
        '
        'tpОформление
        '
        Me.tpОформление.Controls.Add(Me.PictureBox2)
        Me.tpОформление.Controls.Add(Me.Uc_createSample1)
        Me.tpОформление.Location = New System.Drawing.Point(4, 33)
        Me.tpОформление.Name = "tpОформление"
        Me.tpОформление.Padding = New System.Windows.Forms.Padding(3)
        Me.tpОформление.Size = New System.Drawing.Size(1045, 434)
        Me.tpОформление.TabIndex = 14
        Me.tpОформление.Text = "Оформление"
        Me.tpОформление.UseVisualStyleBackColor = True
        '
        'PictureBox2
        '
        Me.PictureBox2.Location = New System.Drawing.Point(872, 25)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(170, 125)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 1
        Me.PictureBox2.TabStop = False
        '
        'Uc_createSample1
        '
        Me.Uc_createSample1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Uc_createSample1.Location = New System.Drawing.Point(2, 0)
        Me.Uc_createSample1.Margin = New System.Windows.Forms.Padding(6)
        Me.Uc_createSample1.Name = "Uc_createSample1"
        Me.Uc_createSample1.Size = New System.Drawing.Size(1037, 428)
        Me.Uc_createSample1.TabIndex = 0
        '
        'StringDictionaryBindingSource
        '
        Me.StringDictionaryBindingSource.DataSource = GetType(System.Collections.Specialized.StringDictionary)
        '
        'SamplesOnWorkBindingSource
        '
        Me.SamplesOnWorkBindingSource.DataMember = "OperationOnWork"
        Me.SamplesOnWorkBindingSource.DataSource = Me.ClsUserBindingSource
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label3.Location = New System.Drawing.Point(360, 15)
        Me.Label3.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 24)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Сейчас:"
        '
        'TimerClock
        '
        Me.TimerClock.Interval = 60000
        '
        'lbCurrentTime
        '
        Me.lbCurrentTime.AutoSize = True
        Me.lbCurrentTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lbCurrentTime.Location = New System.Drawing.Point(484, 15)
        Me.lbCurrentTime.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lbCurrentTime.Name = "lbCurrentTime"
        Me.lbCurrentTime.Size = New System.Drawing.Size(107, 25)
        Me.lbCurrentTime.TabIndex = 6
        Me.lbCurrentTime.Text = "Пн 18:25"
        '
        'lbWokername
        '
        Me.lbWokername.AutoSize = True
        Me.lbWokername.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ClsUserBindingSource, "UserShotName", True))
        Me.lbWokername.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lbWokername.Location = New System.Drawing.Point(357, 49)
        Me.lbWokername.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lbWokername.Name = "lbWokername"
        Me.lbWokername.Size = New System.Drawing.Size(110, 24)
        Me.lbWokername.TabIndex = 7
        Me.lbWokername.Text = "введи ПИН"
        '
        'btLoadTrilboneForm
        '
        Me.btLoadTrilboneForm.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btLoadTrilboneForm.Location = New System.Drawing.Point(699, 16)
        Me.btLoadTrilboneForm.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.btLoadTrilboneForm.Name = "btLoadTrilboneForm"
        Me.btLoadTrilboneForm.Size = New System.Drawing.Size(173, 64)
        Me.btLoadTrilboneForm.TabIndex = 8
        Me.btLoadTrilboneForm.Text = "Войти"
        Me.btLoadTrilboneForm.UseVisualStyleBackColor = True
        '
        'lbConnectStatus
        '
        Me.lbConnectStatus.AutoSize = True
        Me.lbConnectStatus.BackColor = System.Drawing.Color.Red
        Me.lbConnectStatus.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ClsUserBindingSource, "IsConnected", True))
        Me.lbConnectStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lbConnectStatus.Location = New System.Drawing.Point(624, 18)
        Me.lbConnectStatus.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lbConnectStatus.Name = "lbConnectStatus"
        Me.lbConnectStatus.Size = New System.Drawing.Size(59, 24)
        Me.lbConnectStatus.TabIndex = 9
        Me.lbConnectStatus.Text = "offline"
        '
        'btSingOut
        '
        Me.btSingOut.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btSingOut.Location = New System.Drawing.Point(933, 16)
        Me.btSingOut.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.btSingOut.Name = "btSingOut"
        Me.btSingOut.Size = New System.Drawing.Size(132, 64)
        Me.btSingOut.TabIndex = 10
        Me.btSingOut.Text = "ВЫХОД"
        Me.btSingOut.UseVisualStyleBackColor = True
        '
        'btPin
        '
        Me.btPin.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btPin.Location = New System.Drawing.Point(22, 15)
        Me.btPin.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.btPin.Name = "btPin"
        Me.btPin.Size = New System.Drawing.Size(68, 41)
        Me.btPin.TabIndex = 11
        Me.btPin.Text = "ПИН"
        Me.btPin.UseVisualStyleBackColor = True
        '
        'btScannerON
        '
        Me.btScannerON.BackgroundImage = Global.Trilbone_load.My.Resources.Resources.IconRFID
        Me.btScannerON.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btScannerON.FlatAppearance.BorderColor = System.Drawing.Color.Red
        Me.btScannerON.FlatAppearance.BorderSize = 0
        Me.btScannerON.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btScannerON.Location = New System.Drawing.Point(192, 15)
        Me.btScannerON.Name = "btScannerON"
        Me.btScannerON.Size = New System.Drawing.Size(60, 60)
        Me.btScannerON.TabIndex = 12
        Me.btScannerON.UseVisualStyleBackColor = True
        '
        'btRestartRFID
        '
        Me.btRestartRFID.BackgroundImage = Global.Trilbone_load.My.Resources.Resources.Refreshicon
        Me.btRestartRFID.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btRestartRFID.FlatAppearance.BorderSize = 0
        Me.btRestartRFID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btRestartRFID.Location = New System.Drawing.Point(277, 16)
        Me.btRestartRFID.Name = "btRestartRFID"
        Me.btRestartRFID.Size = New System.Drawing.Size(48, 48)
        Me.btRestartRFID.TabIndex = 13
        Me.btRestartRFID.UseVisualStyleBackColor = True
        '
        'lbMoySkladStatus
        '
        Me.lbMoySkladStatus.AutoSize = True
        Me.lbMoySkladStatus.BackColor = System.Drawing.SystemColors.Control
        Me.lbMoySkladStatus.Location = New System.Drawing.Point(626, 52)
        Me.lbMoySkladStatus.Name = "lbMoySkladStatus"
        Me.lbMoySkladStatus.Size = New System.Drawing.Size(53, 18)
        Me.lbMoySkladStatus.TabIndex = 14
        Me.lbMoySkladStatus.Text = "Склад"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label36.Location = New System.Drawing.Point(552, 76)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(127, 15)
        Me.Label36.TabIndex = 15
        Me.Label36.Text = "*нажми для загрузки"
        '
        'fmWtime
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(1080, 572)
        Me.Controls.Add(Me.Label36)
        Me.Controls.Add(Me.lbMoySkladStatus)
        Me.Controls.Add(Me.btRestartRFID)
        Me.Controls.Add(Me.btScannerON)
        Me.Controls.Add(Me.btPin)
        Me.Controls.Add(Me.btSingOut)
        Me.Controls.Add(Me.lbConnectStatus)
        Me.Controls.Add(Me.btLoadTrilboneForm)
        Me.Controls.Add(Me.lbWokername)
        Me.Controls.Add(Me.lbCurrentTime)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.tbctlMain)
        Me.Controls.Add(Me.tbPin)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "fmWtime"
        Me.Text = "TrilboneTime 1.0"
        Me.tbctlMain.ResumeLayout(False)
        Me.tpTime.ResumeLayout(False)
        Me.tpTime.PerformLayout()
        Me.TableLayoutPanel_operations.ResumeLayout(False)
        CType(Me.ClsUserBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.tpMyTime.ResumeLayout(False)
        Me.tpMyTime.PerformLayout()
        Me.tbctlSalary.ResumeLayout(False)
        Me.tbFromLastSalary.ResumeLayout(False)
        Me.gbCorrectionwTime.ResumeLayout(False)
        Me.gbCorrectionwTime.PerformLayout()
        CType(Me.WTimeSummary_ResultDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WTimeSummary_ResultBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpAllSalary.ResumeLayout(False)
        Me.tpAllSalary.PerformLayout()
        CType(Me.WSalaryInfo_ResultDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WSalaryInfo_ResultBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbSelectEmployee.ResumeLayout(False)
        CType(Me.TbEmployeeBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpHwoInOffice.ResumeLayout(False)
        CType(Me.WInOffice_ResultDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WInOffice_ResultBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpNewSample.ResumeLayout(False)
        Me.tpNewSample.PerformLayout()
        Me.tcSampleParam.ResumeLayout(False)
        Me.tpLotParam.ResumeLayout(False)
        Me.tpLotParam.PerformLayout()
        CType(Me.TbSMOperationBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TbSMLotBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TbUomBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpOperationParam.ResumeLayout(False)
        Me.tpOperationParam.PerformLayout()
        CType(Me.TbSMWorkOperationBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpExpeditionParam.ResumeLayout(False)
        Me.tpExpeditionParam.PerformLayout()
        Me.tpOperationPayment.ResumeLayout(False)
        Me.gbPayByWoker.ResumeLayout(False)
        Me.gbPayByWoker.PerformLayout()
        Me.gbPayByAdmin.ResumeLayout(False)
        Me.gbPayByAdmin.PerformLayout()
        CType(Me.TbSMTariffBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        Me.tpAccepting.ResumeLayout(False)
        Me.tpAccepting.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpToParts.ResumeLayout(False)
        Me.tpParcels.ResumeLayout(False)
        Me.tbctlParcels.ResumeLayout(False)
        Me.tpParcelToShip.ResumeLayout(False)
        Me.tpParcelToShip.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbParcelCount.ResumeLayout(False)
        Me.gbParcelCount.PerformLayout()
        CType(Me.BindingNavigator1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BindingNavigator1.ResumeLayout(False)
        Me.BindingNavigator1.PerformLayout()
        CType(Me.IMoySkladDataProvider_ParcelInfoBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IMoySkladDataProvider_ResultParcelInfoBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbDeclaration.ResumeLayout(False)
        CType(Me.IMoySkladDataProvider_Declaration_CP71_CN23DataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IMoySkladDataProvider_Declaration_CP71_CN23BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpParcelResult.ResumeLayout(False)
        Me.tpParcelResult.PerformLayout()
        CType(Me.PackagingGoodsUUIDsAndQtysDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PackagingGoodsUUIDsAndQtysBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpSampleInfo.ResumeLayout(False)
        Me.tpRfid.ResumeLayout(False)
        Me.tpRfid.PerformLayout()
        CType(Me.pbEANLabel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpEmployee.ResumeLayout(False)
        Me.tpOnSale.ResumeLayout(False)
        Me.tpSellRegister.ResumeLayout(False)
        Me.tpeBayInfo.ResumeLayout(False)
        Me.tpОформление.ResumeLayout(False)
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StringDictionaryBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SamplesOnWorkBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tbPin As System.Windows.Forms.TextBox
    Friend WithEvents tbctlMain As System.Windows.Forms.TabControl
    Friend WithEvents tpTime As System.Windows.Forms.TabPage
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel_operations As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btSuspendSampleOperation As System.Windows.Forms.Button
    Friend WithEvents btStartSampleOperation As System.Windows.Forms.Button
    Friend WithEvents lbxCurrentUserOperation As System.Windows.Forms.ListBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lbWokerCurrentTimeSpan As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btStopWork As System.Windows.Forms.Button
    Friend WithEvents btSuspendWork As System.Windows.Forms.Button
    Friend WithEvents btStartWork As System.Windows.Forms.Button
    Friend WithEvents lbWokerStatus As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tpNewSample As System.Windows.Forms.TabPage
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TimerClock As System.Windows.Forms.Timer
    Friend WithEvents lbCurrentTime As System.Windows.Forms.Label
    Friend WithEvents btPhotoSample As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btRegisterSchema As System.Windows.Forms.Button
    Friend WithEvents btClear As System.Windows.Forms.Button
    Friend WithEvents btPrintNumberLabel2 As System.Windows.Forms.Button
    Friend WithEvents lbWokername As System.Windows.Forms.Label
    Friend WithEvents btLoadTrilboneForm As System.Windows.Forms.Button
    Friend WithEvents lbConnectStatus As System.Windows.Forms.Label
    Friend WithEvents btSingOut As System.Windows.Forms.Button
    Friend WithEvents btCreateSchema As System.Windows.Forms.Button
    Friend WithEvents tpSmallScheme As System.Windows.Forms.TabPage
    Friend WithEvents btResetPrinter2 As System.Windows.Forms.Button
    Friend WithEvents tpToParts As System.Windows.Forms.TabPage
    Friend WithEvents RichTextBox2 As System.Windows.Forms.RichTextBox
    Friend WithEvents ClsUserBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SamplesOnWorkBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents btStopSampleOperation As System.Windows.Forms.Button
    Friend WithEvents tpAccepting As System.Windows.Forms.TabPage
    Friend WithEvents btWithoutNumber As System.Windows.Forms.Button
    Friend WithEvents btAddNewInCurrentLot As System.Windows.Forms.Button
    Friend WithEvents cbUom As System.Windows.Forms.ComboBox
    Friend WithEvents rbLotSample As System.Windows.Forms.RadioButton
    Friend WithEvents rbSingleSample As System.Windows.Forms.RadioButton
    Friend WithEvents tbSchemeNumber As System.Windows.Forms.TextBox
    Friend WithEvents tcSampleParam As System.Windows.Forms.TabControl
    Friend WithEvents tpLotParam As System.Windows.Forms.TabPage
    Friend WithEvents btStartOperation As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents tpExpeditionParam As System.Windows.Forms.TabPage
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents tbQtyInLot As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents rtbRollText As System.Windows.Forms.RichTextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents ComboBox4 As System.Windows.Forms.ComboBox
    Friend WithEvents tbExpeditionNr As System.Windows.Forms.TextBox
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Button10 As System.Windows.Forms.Button
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents btPin As System.Windows.Forms.Button
    Friend WithEvents tpHwoInOffice As System.Windows.Forms.TabPage
    Friend WithEvents btHwoInOffice As System.Windows.Forms.Button
    Friend WithEvents WInOffice_ResultDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents WInOffice_ResultBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents tpOperationParam As System.Windows.Forms.TabPage
    Friend WithEvents gbPayByAdmin As System.Windows.Forms.GroupBox
    Friend WithEvents cbCurrencyOperation As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents rbPerHour As System.Windows.Forms.RadioButton
    Friend WithEvents tbAdminHourPay As System.Windows.Forms.TextBox
    Friend WithEvents rbSumma As System.Windows.Forms.RadioButton
    Friend WithEvents tbAdminSumPay As System.Windows.Forms.TextBox
    Friend WithEvents lbOperationWarning As System.Windows.Forms.Label
    Friend WithEvents rbTariff As System.Windows.Forms.RadioButton
    Friend WithEvents btSaveLot As System.Windows.Forms.Button
    Friend WithEvents btCreateOperation As System.Windows.Forms.Button
    Friend WithEvents lbxOperations As System.Windows.Forms.ListBox
    Friend WithEvents gbPayByWoker As System.Windows.Forms.GroupBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents rbWokerPerHour As System.Windows.Forms.RadioButton
    Friend WithEvents tbHourByWorker As System.Windows.Forms.TextBox
    Friend WithEvents rbWokerPerSumma As System.Windows.Forms.RadioButton
    Friend WithEvents tbSumByWoker As System.Windows.Forms.TextBox
    Friend WithEvents cbOperationUom As System.Windows.Forms.ComboBox
    Friend WithEvents tbAccountingQty As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cbTariff As System.Windows.Forms.ComboBox
    Friend WithEvents TbSMLotBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TbUomBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents TbSMOperationBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TbSMWorkOperationBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents lbOperationPayment As System.Windows.Forms.Label
    Friend WithEvents rtbOperationComment As System.Windows.Forms.RichTextBox
    Friend WithEvents lbxWorkOperation As System.Windows.Forms.ListBox
    Friend WithEvents tpOperationPayment As System.Windows.Forms.TabPage
    Friend WithEvents cbExpedition As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TbSMTariffBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents tpMyTime As System.Windows.Forms.TabPage
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TimeAccountingDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EmployeeNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TimeMarkerDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OperationNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OperationName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RegisterTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WTimeSummary_ResultDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WTimeSummary_ResultBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents btGetMyTime As System.Windows.Forms.Button
    Friend WithEvents gbSelectEmployee As System.Windows.Forms.GroupBox
    Friend WithEvents cbEmployee As System.Windows.Forms.ComboBox
    Friend WithEvents TbEmployeeBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents tbEmployeeSum As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents tbctlSalary As System.Windows.Forms.TabControl
    Friend WithEvents tbFromLastSalary As System.Windows.Forms.TabPage
    Friend WithEvents DateTimePicker_correctwTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents rbCorrectEndwtime As System.Windows.Forms.RadioButton
    Friend WithEvents rbCorrectBeginwTime As System.Windows.Forms.RadioButton
    Friend WithEvents btUserCorrect As System.Windows.Forms.Button
    Friend WithEvents tpAllSalary As System.Windows.Forms.TabPage
    Friend WithEvents gbCorrectionwTime As System.Windows.Forms.GroupBox
    Friend WithEvents DateTimePicker_CorrectWDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents btRemoveWRecord As System.Windows.Forms.Button
    Friend WithEvents btAddWRecord As System.Windows.Forms.Button
    Friend WithEvents btPaySalary As System.Windows.Forms.Button
    Friend WithEvents WSalaryInfo_ResultDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents WSalaryInfo_ResultBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DateTimePicker_salary As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CalculateDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn1 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tpParcels As System.Windows.Forms.TabPage
    Friend WithEvents IMoySkladDataProvider_ParcelInfoBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents tbctlParcels As System.Windows.Forms.TabControl
    Friend WithEvents tpParcelToShip As System.Windows.Forms.TabPage
    Friend WithEvents tpParcelResult As System.Windows.Forms.TabPage
    Friend WithEvents btSaveShipping As System.Windows.Forms.Button
    Friend WithEvents btRemovePackageGood As System.Windows.Forms.Button
    Friend WithEvents btAddPackageGood As System.Windows.Forms.Button
    Friend WithEvents tbEnterPackageGood As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents PackagingGoodsUUIDsAndQtysDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents clmGoodName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn21 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn22 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PackagingGoodsUUIDsAndQtysBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents IMoySkladDataProvider_ResultParcelInfoBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TrackNumberTextBox As System.Windows.Forms.TextBox
    Friend WithEvents cbShippingWoker As System.Windows.Forms.ComboBox
    Friend WithEvents StringDictionaryBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents cbShippingCompany As System.Windows.Forms.ComboBox
    Friend WithEvents cbShippingCurrency As System.Windows.Forms.ComboBox
    Friend WithEvents ShippingAmountTextBox As System.Windows.Forms.TextBox
    Friend WithEvents HandlingAmountTextBox As System.Windows.Forms.TextBox
    Friend WithEvents tbParcelSizeC As System.Windows.Forms.TextBox
    Friend WithEvents tbParcelSizeB As System.Windows.Forms.TextBox
    Friend WithEvents tbParcelSizeA As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents tbParcelWeight As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents tbSKU As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents BindingNavigator1 As System.Windows.Forms.BindingNavigator
    Friend WithEvents BindingNavigatorCountItem As System.Windows.Forms.ToolStripLabel
    Friend WithEvents BindingNavigatorMoveFirstItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CityTextBox As System.Windows.Forms.TextBox
    Friend WithEvents CountryTextBox As System.Windows.Forms.TextBox
    Friend WithEvents NameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PhoneTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PostIndexTextBox As System.Windows.Forms.TextBox
    Friend WithEvents StateTextBox As System.Windows.Forms.TextBox
    Friend WithEvents StreetTextBox As System.Windows.Forms.TextBox
    Friend WithEvents cbCurrentItemList As System.Windows.Forms.ComboBox
    Friend WithEvents btParcelResult As System.Windows.Forms.Button
    Friend WithEvents TextBox10 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox11 As System.Windows.Forms.TextBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents tbDeclaration As System.Windows.Forms.TabPage
    Friend WithEvents IMoySkladDataProvider_Declaration_CP71_CN23DataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn16 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn17 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn18 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn19 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn20 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn23 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IMoySkladDataProvider_Declaration_CP71_CN23BindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents btRequestParcels As System.Windows.Forms.Button
    Friend WithEvents gbParcelCount As System.Windows.Forms.GroupBox
    Friend WithEvents cbParcelType As System.Windows.Forms.ComboBox
    Friend WithEvents cbParcelGroup As System.Windows.Forms.ComboBox
    Friend WithEvents lblItemsInParcel As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents tpSampleInfo As System.Windows.Forms.TabPage
    Friend WithEvents Uc_trilbone_history1 As Service.Uc_trilbone_history
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents btScannerON As System.Windows.Forms.Button
    Friend WithEvents btRestartRFID As System.Windows.Forms.Button
    Friend WithEvents tpRfid As System.Windows.Forms.TabPage
    Friend WithEvents btPrinterClear As System.Windows.Forms.Button
    Friend WithEvents btPrintLabel As System.Windows.Forms.Button
    Friend WithEvents pbEANLabel As System.Windows.Forms.PictureBox
    Friend WithEvents UC_rfid1 As Service.UC_rfid
    Friend WithEvents lbMoySkladStatus As System.Windows.Forms.Label
    Friend WithEvents lbLocationInfo As System.Windows.Forms.Label
    Friend WithEvents cbxMoySkladAsk As System.Windows.Forms.CheckBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents tpEmployee As System.Windows.Forms.TabPage
    Friend WithEvents Uc_Employee1 As Service.uc_Employee
    Friend WithEvents btCreateTask As System.Windows.Forms.Button
    Friend WithEvents btAddNewSample As System.Windows.Forms.Button
    Friend WithEvents btLoadExpeditionFromMC As System.Windows.Forms.Button
    Friend WithEvents btEditOperation As System.Windows.Forms.Button
    Friend WithEvents tpOnSale As System.Windows.Forms.TabPage
    Friend WithEvents UcReadySamples1 As Service.ucReadySamples
    Friend WithEvents tpSellRegister As System.Windows.Forms.TabPage
    Friend WithEvents UcSellGood1 As Service.ucSellGood
    Friend WithEvents tpeBayInfo As System.Windows.Forms.TabPage
    Friend WithEvents UcEbayHistory1 As Service.ucEbayHistory
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents tpОформление As Windows.Forms.TabPage
    Friend WithEvents Uc_createSample1 As Service.uc_createSample
    Friend WithEvents PictureBox2 As Windows.Forms.PictureBox
End Class
