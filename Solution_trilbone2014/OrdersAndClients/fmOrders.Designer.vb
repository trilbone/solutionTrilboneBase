<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fmOrders
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
    '<System.Diagnostics.DebuggerStepThrough()> 
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim OrderIDLabel As System.Windows.Forms.Label
        Dim ClientIDLabel As System.Windows.Forms.Label
        Dim CurrencyNameLabel As System.Windows.Forms.Label
        Dim RateOfExchangeLabel As System.Windows.Forms.Label
        Dim OrderTotalPriceLabel As System.Windows.Forms.Label
        Dim ShippingPriceLabel As System.Windows.Forms.Label
        Dim ConfirmTotalOrderPriceLabel As System.Windows.Forms.Label
        Dim ConfirmShippingPriceLabel As System.Windows.Forms.Label
        Dim SampleNumberLabel As System.Windows.Forms.Label
        Dim CurrencyNameLabel1 As System.Windows.Forms.Label
        Dim RateOfExchangeLabel1 As System.Windows.Forms.Label
        Dim DiscountLabel As System.Windows.Forms.Label
        Dim PriceLabel As System.Windows.Forms.Label
        Dim Label1 As System.Windows.Forms.Label
        Dim ConfirmPriceLabel As System.Windows.Forms.Label
        Dim Sample_net_weightLabel As System.Windows.Forms.Label
        Dim SampleDimensionLabel As System.Windows.Forms.Label
        Dim Sample_main_speciesLabel As System.Windows.Forms.Label
        Dim Fossil_countLabel As System.Windows.Forms.Label
        Dim CheckoutDateLabel1 As System.Windows.Forms.Label
        Dim OrderDateLabel As System.Windows.Forms.Label
        Dim ExpierensDateLabel As System.Windows.Forms.Label
        Dim ConfirmStockOutDateLabel As System.Windows.Forms.Label
        Dim CheckoutDateLabel As System.Windows.Forms.Label
        Dim CancellationDateLabel As System.Windows.Forms.Label
        Me.Select_tb_OrdersBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsOrders = New OrdersAndClients.dsOrders()
        Me.SelectClientstbClientsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsService = New OrdersAndClients.dsService()
        Me.Select_OrdersForClientBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Select_SampleInfoBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SamplesAndOrdersBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Select_AllSamplesInOrders_tb_SamplesAndOrdersBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Select_tb_OrdersTableAdapter = New OrdersAndClients.dsOrdersTableAdapters.OrdersTableAdapter()
        Me.TableAdapterManager = New OrdersAndClients.dsOrdersTableAdapters.TableAdapterManager()
        Me.Select_Clients_tb_ClientsTableAdapter = New OrdersAndClients.dsServiceTableAdapters.Select_Clients_tb_ClientsTableAdapter()
        Me.Select_AllSamplesInOrders_tb_SamplesAndOrdersTableAdapter = New OrdersAndClients.dsServiceTableAdapters.Select_AllSamplesInOrders_tb_SamplesAndOrdersTableAdapter()
        Me.SamplesAndOrdersTableAdapter = New OrdersAndClients.dsOrdersTableAdapters.SamplesAndOrdersTableAdapter()
        Me.Select_SampleInfoTableAdapter = New OrdersAndClients.dsServiceTableAdapters.Select_SampleInfoTableAdapter()
        Me.Select_OrdersForClientTableAdapter = New OrdersAndClients.dsServiceTableAdapters.Select_OrdersForClientTableAdapter()
        Me.tbOrderID = New System.Windows.Forms.TextBox()
        Me.ClientIDComboBox = New System.Windows.Forms.ComboBox()
        Me.main_TabControl = New System.Windows.Forms.TabControl()
        Me.TabPage_OrderInfo = New System.Windows.Forms.TabPage()
        Me.btCalculateOrder = New System.Windows.Forms.Button()
        Me.OrderCancellationDateTextBox = New System.Windows.Forms.TextBox()
        Me.OrderCheckoutDateTextBox = New System.Windows.Forms.TextBox()
        Me.OrderConfirmStockOutDateTextBox = New System.Windows.Forms.TextBox()
        Me.OrderExpierensDateTextBox = New System.Windows.Forms.TextBox()
        Me.OrderDateTextBox = New System.Windows.Forms.TextBox()
        Me.btCancelOrder = New System.Windows.Forms.Button()
        Me.Select_OrdersForClientDataGridView = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewCheckBoxColumn1 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewCheckBoxColumn2 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btSaveOrder = New System.Windows.Forms.Button()
        Me.OrderCancellationFlagCheckBox = New System.Windows.Forms.CheckBox()
        Me.OrderCheckoutFlagCheckBox = New System.Windows.Forms.CheckBox()
        Me.OrderConfirmStockOutFlagCheckBox = New System.Windows.Forms.CheckBox()
        Me.GbConfirmPrices = New System.Windows.Forms.GroupBox()
        Me.LabelUSD4 = New System.Windows.Forms.Label()
        Me.LabelUSD3 = New System.Windows.Forms.Label()
        Me.OrderConfirmShippingPriceTextBox = New System.Windows.Forms.TextBox()
        Me.OrderConfirmTotalOrderPriceTextBox = New System.Windows.Forms.TextBox()
        Me.GbStartPrices = New System.Windows.Forms.GroupBox()
        Me.LabelUSD2 = New System.Windows.Forms.Label()
        Me.LabelUSD1 = New System.Windows.Forms.Label()
        Me.OrderFreeShippingFlagCheckBox = New System.Windows.Forms.CheckBox()
        Me.OrderShippingPriceTextBox = New System.Windows.Forms.TextBox()
        Me.OrderTotalPriceTextBox = New System.Windows.Forms.TextBox()
        Me.btNewClient = New System.Windows.Forms.Button()
        Me.OrderRateOfExchangeTextBox = New System.Windows.Forms.TextBox()
        Me.OrderCurrencyNameComboBoxOrder = New System.Windows.Forms.ComboBox()
        Me.tbpgSamples = New System.Windows.Forms.TabPage()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btSampleOnSale = New System.Windows.Forms.Button()
        Me.tbMainFossilSize = New System.Windows.Forms.TextBox()
        Me.tbMainFossilName = New System.Windows.Forms.TextBox()
        Me.lbCountNewRowInSample = New System.Windows.Forms.Label()
        Me.btSampleInfo = New System.Windows.Forms.Button()
        Me.btImagesForm = New System.Windows.Forms.Button()
        Me.pbSampleImage = New System.Windows.Forms.PictureBox()
        Me.Dgv_SamplesINOrders = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn15 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewCheckBoxColumn3 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewCheckBoxColumn4 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DataGridViewTextBoxColumn16 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewCheckBoxColumn5 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DataGridViewTextBoxColumn17 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OrderID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SamplesINOrdersBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsSampleInOrder = New OrdersAndClients.dsSampleInOrder()
        Me.btCopySample = New System.Windows.Forms.Button()
        Me.btDeleteSample = New System.Windows.Forms.Button()
        Me.btCancelChanges = New System.Windows.Forms.Button()
        Me.btSaveChanges = New System.Windows.Forms.Button()
        Me.TabPage_XMLOrder = New System.Windows.Forms.TabPage()
        Me.cbxDelExists = New System.Windows.Forms.CheckBox()
        Me.cbxRefreshImages = New System.Windows.Forms.CheckBox()
        Me.btShowInBrowser = New System.Windows.Forms.Button()
        Me.cbTypeOfCatalog = New System.Windows.Forms.ComboBox()
        Me.Preview_TabControl = New System.Windows.Forms.TabControl()
        Me.PreviewHTML_TabPage = New System.Windows.Forms.TabPage()
        Me.OrderHTML_WebBrowser = New System.Windows.Forms.WebBrowser()
        Me.PreviewTXT_TabPage = New System.Windows.Forms.TabPage()
        Me.OrderText_RichTextBox = New System.Windows.Forms.RichTextBox()
        Me.PreviewXML_TabPage = New System.Windows.Forms.TabPage()
        Me.OrderInfoPaperRichTextBox = New System.Windows.Forms.RichTextBox()
        Me.btCopyText = New System.Windows.Forms.Button()
        Me.btCreateXML = New System.Windows.Forms.Button()
        Me.TabPage_SamplesInOrder = New System.Windows.Forms.TabPage()
        Me.btShowImages = New System.Windows.Forms.Button()
        Me.SampleCheckoutDateTextBox = New System.Windows.Forms.TextBox()
        Me.BtCancelSample = New System.Windows.Forms.Button()
        Me.btSaveSample = New System.Windows.Forms.Button()
        Me.TabControlSampleData = New System.Windows.Forms.TabControl()
        Me.TabPageImages = New System.Windows.Forms.TabPage()
        Me.ListViewSampleImages = New System.Windows.Forms.ListView()
        Me.TabPageData = New System.Windows.Forms.TabPage()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FossilheightDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SelectFossilInfoBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.GbSampleData = New System.Windows.Forms.GroupBox()
        Me.Fossil_countTextBox = New System.Windows.Forms.TextBox()
        Me.Sample_main_speciesTextBox = New System.Windows.Forms.TextBox()
        Me.SampleDimensionTextBox = New System.Windows.Forms.TextBox()
        Me.Sample_net_weightTextBox = New System.Windows.Forms.TextBox()
        Me.btMoveToAnotherOrder = New System.Windows.Forms.Button()
        Me.btRemoveSampleFromOrder = New System.Windows.Forms.Button()
        Me.btAddSampleToOrder = New System.Windows.Forms.Button()
        Me.SampleCheckOutCheckBox = New System.Windows.Forms.CheckBox()
        Me.SampleConfirmFlagCheckBox = New System.Windows.Forms.CheckBox()
        Me.GbSampleConfirmPrices = New System.Windows.Forms.GroupBox()
        Me.LabelUSDspl3 = New System.Windows.Forms.Label()
        Me.LabelUSDspl2 = New System.Windows.Forms.Label()
        Me.SampleConfirmShippingPriceTextBox = New System.Windows.Forms.TextBox()
        Me.SampleConfirmPriceTextBox = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LabelUSDspl1 = New System.Windows.Forms.Label()
        Me.SampleFreeShippingFlag = New System.Windows.Forms.CheckBox()
        Me.SampleDiscountTextBox = New System.Windows.Forms.TextBox()
        Me.SamplePriceTextBox = New System.Windows.Forms.TextBox()
        Me.SampleRateOfExchangeTextBox = New System.Windows.Forms.TextBox()
        Me.SampleCurrencyNameComboBox = New System.Windows.Forms.ComboBox()
        Me.SampleNumberListBox = New System.Windows.Forms.ListBox()
        Me.ImageListSampleImages = New System.Windows.Forms.ImageList(Me.components)
        Me.btRefreshOrder = New System.Windows.Forms.Button()
        Me.SelectFossilInfoTableAdapter = New OrdersAndClients.dsServiceTableAdapters.SelectFossilInfoTableAdapter()
        Me.SamplesINOrdersTableAdapter = New OrdersAndClients.dsSampleInOrderTableAdapters.SamplesINOrdersTableAdapter()
        Me.TableAdapterManager_dsSampleInOrder = New OrdersAndClients.dsSampleInOrderTableAdapters.TableAdapterManager()
        Me.DataTable_SampleInfoBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataTable_SampleInfoTableAdapter = New OrdersAndClients.dsSampleInOrderTableAdapters.DataTable_SampleInfoTableAdapter()
        OrderIDLabel = New System.Windows.Forms.Label()
        ClientIDLabel = New System.Windows.Forms.Label()
        CurrencyNameLabel = New System.Windows.Forms.Label()
        RateOfExchangeLabel = New System.Windows.Forms.Label()
        OrderTotalPriceLabel = New System.Windows.Forms.Label()
        ShippingPriceLabel = New System.Windows.Forms.Label()
        ConfirmTotalOrderPriceLabel = New System.Windows.Forms.Label()
        ConfirmShippingPriceLabel = New System.Windows.Forms.Label()
        SampleNumberLabel = New System.Windows.Forms.Label()
        CurrencyNameLabel1 = New System.Windows.Forms.Label()
        RateOfExchangeLabel1 = New System.Windows.Forms.Label()
        DiscountLabel = New System.Windows.Forms.Label()
        PriceLabel = New System.Windows.Forms.Label()
        Label1 = New System.Windows.Forms.Label()
        ConfirmPriceLabel = New System.Windows.Forms.Label()
        Sample_net_weightLabel = New System.Windows.Forms.Label()
        SampleDimensionLabel = New System.Windows.Forms.Label()
        Sample_main_speciesLabel = New System.Windows.Forms.Label()
        Fossil_countLabel = New System.Windows.Forms.Label()
        CheckoutDateLabel1 = New System.Windows.Forms.Label()
        OrderDateLabel = New System.Windows.Forms.Label()
        ExpierensDateLabel = New System.Windows.Forms.Label()
        ConfirmStockOutDateLabel = New System.Windows.Forms.Label()
        CheckoutDateLabel = New System.Windows.Forms.Label()
        CancellationDateLabel = New System.Windows.Forms.Label()
        CType(Me.Select_tb_OrdersBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsOrders, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SelectClientstbClientsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsService, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Select_OrdersForClientBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Select_SampleInfoBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SamplesAndOrdersBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Select_AllSamplesInOrders_tb_SamplesAndOrdersBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.main_TabControl.SuspendLayout()
        Me.TabPage_OrderInfo.SuspendLayout()
        CType(Me.Select_OrdersForClientDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GbConfirmPrices.SuspendLayout()
        Me.GbStartPrices.SuspendLayout()
        Me.tbpgSamples.SuspendLayout()
        CType(Me.pbSampleImage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dgv_SamplesINOrders, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SamplesINOrdersBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsSampleInOrder, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage_XMLOrder.SuspendLayout()
        Me.Preview_TabControl.SuspendLayout()
        Me.PreviewHTML_TabPage.SuspendLayout()
        Me.PreviewTXT_TabPage.SuspendLayout()
        Me.PreviewXML_TabPage.SuspendLayout()
        Me.TabPage_SamplesInOrder.SuspendLayout()
        Me.TabControlSampleData.SuspendLayout()
        Me.TabPageImages.SuspendLayout()
        Me.TabPageData.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SelectFossilInfoBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GbSampleData.SuspendLayout()
        Me.GbSampleConfirmPrices.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataTable_SampleInfoBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'OrderIDLabel
        '
        OrderIDLabel.AutoSize = True
        OrderIDLabel.Location = New System.Drawing.Point(1, 4)
        OrderIDLabel.Name = "OrderIDLabel"
        OrderIDLabel.Size = New System.Drawing.Size(50, 13)
        OrderIDLabel.TabIndex = 0
        OrderIDLabel.Text = "Order ID:"
        '
        'ClientIDLabel
        '
        ClientIDLabel.AutoSize = True
        ClientIDLabel.Location = New System.Drawing.Point(9, 11)
        ClientIDLabel.Name = "ClientIDLabel"
        ClientIDLabel.Size = New System.Drawing.Size(50, 13)
        ClientIDLabel.TabIndex = 2
        ClientIDLabel.Text = "Client ID:"
        '
        'CurrencyNameLabel
        '
        CurrencyNameLabel.AutoSize = True
        CurrencyNameLabel.Location = New System.Drawing.Point(11, 37)
        CurrencyNameLabel.Name = "CurrencyNameLabel"
        CurrencyNameLabel.Size = New System.Drawing.Size(83, 13)
        CurrencyNameLabel.TabIndex = 0
        CurrencyNameLabel.Text = "Currency Name:"
        '
        'RateOfExchangeLabel
        '
        RateOfExchangeLabel.AutoSize = True
        RateOfExchangeLabel.Location = New System.Drawing.Point(15, 61)
        RateOfExchangeLabel.Name = "RateOfExchangeLabel"
        RateOfExchangeLabel.Size = New System.Drawing.Size(98, 13)
        RateOfExchangeLabel.TabIndex = 2
        RateOfExchangeLabel.Text = "Rate Of Exchange:"
        '
        'OrderTotalPriceLabel
        '
        OrderTotalPriceLabel.AutoSize = True
        OrderTotalPriceLabel.Location = New System.Drawing.Point(11, 22)
        OrderTotalPriceLabel.Name = "OrderTotalPriceLabel"
        OrderTotalPriceLabel.Size = New System.Drawing.Size(90, 13)
        OrderTotalPriceLabel.TabIndex = 0
        OrderTotalPriceLabel.Text = "Order Total Price:"
        '
        'ShippingPriceLabel
        '
        ShippingPriceLabel.AutoSize = True
        ShippingPriceLabel.Location = New System.Drawing.Point(23, 54)
        ShippingPriceLabel.Name = "ShippingPriceLabel"
        ShippingPriceLabel.Size = New System.Drawing.Size(78, 13)
        ShippingPriceLabel.TabIndex = 2
        ShippingPriceLabel.Text = "Shipping Price:"
        '
        'ConfirmTotalOrderPriceLabel
        '
        ConfirmTotalOrderPriceLabel.AutoSize = True
        ConfirmTotalOrderPriceLabel.Location = New System.Drawing.Point(11, 38)
        ConfirmTotalOrderPriceLabel.Name = "ConfirmTotalOrderPriceLabel"
        ConfirmTotalOrderPriceLabel.Size = New System.Drawing.Size(128, 13)
        ConfirmTotalOrderPriceLabel.TabIndex = 0
        ConfirmTotalOrderPriceLabel.Text = "Confirm Total Order Price:"
        '
        'ConfirmShippingPriceLabel
        '
        ConfirmShippingPriceLabel.AutoSize = True
        ConfirmShippingPriceLabel.Location = New System.Drawing.Point(23, 67)
        ConfirmShippingPriceLabel.Name = "ConfirmShippingPriceLabel"
        ConfirmShippingPriceLabel.Size = New System.Drawing.Size(116, 13)
        ConfirmShippingPriceLabel.TabIndex = 2
        ConfirmShippingPriceLabel.Text = "Confirm Shipping Price:"
        '
        'SampleNumberLabel
        '
        SampleNumberLabel.AutoSize = True
        SampleNumberLabel.Location = New System.Drawing.Point(4, 9)
        SampleNumberLabel.Name = "SampleNumberLabel"
        SampleNumberLabel.Size = New System.Drawing.Size(126, 13)
        SampleNumberLabel.TabIndex = 0
        SampleNumberLabel.Text = "Sample numbers in order:"
        '
        'CurrencyNameLabel1
        '
        CurrencyNameLabel1.AutoSize = True
        CurrencyNameLabel1.Location = New System.Drawing.Point(183, 8)
        CurrencyNameLabel1.Name = "CurrencyNameLabel1"
        CurrencyNameLabel1.Size = New System.Drawing.Size(52, 13)
        CurrencyNameLabel1.TabIndex = 2
        CurrencyNameLabel1.Text = "Currency:"
        '
        'RateOfExchangeLabel1
        '
        RateOfExchangeLabel1.AutoSize = True
        RateOfExchangeLabel1.Location = New System.Drawing.Point(150, 35)
        RateOfExchangeLabel1.Name = "RateOfExchangeLabel1"
        RateOfExchangeLabel1.Size = New System.Drawing.Size(98, 13)
        RateOfExchangeLabel1.TabIndex = 4
        RateOfExchangeLabel1.Text = "Rate Of Exchange:"
        '
        'DiscountLabel
        '
        DiscountLabel.AutoSize = True
        DiscountLabel.Location = New System.Drawing.Point(44, 48)
        DiscountLabel.Name = "DiscountLabel"
        DiscountLabel.Size = New System.Drawing.Size(52, 13)
        DiscountLabel.TabIndex = 2
        DiscountLabel.Text = "Discount:"
        '
        'PriceLabel
        '
        PriceLabel.AutoSize = True
        PriceLabel.Location = New System.Drawing.Point(9, 22)
        PriceLabel.Name = "PriceLabel"
        PriceLabel.Size = New System.Drawing.Size(34, 13)
        PriceLabel.TabIndex = 0
        PriceLabel.Text = "Price:"
        '
        'Label1
        '
        Label1.Location = New System.Drawing.Point(6, 48)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(122, 13)
        Label1.TabIndex = 2
        Label1.Text = "Confirm Shipping Price:"
        '
        'ConfirmPriceLabel
        '
        ConfirmPriceLabel.AutoSize = True
        ConfirmPriceLabel.Location = New System.Drawing.Point(6, 22)
        ConfirmPriceLabel.Name = "ConfirmPriceLabel"
        ConfirmPriceLabel.Size = New System.Drawing.Size(72, 13)
        ConfirmPriceLabel.TabIndex = 0
        ConfirmPriceLabel.Text = "Confirm Price:"
        '
        'Sample_net_weightLabel
        '
        Sample_net_weightLabel.AutoSize = True
        Sample_net_weightLabel.Location = New System.Drawing.Point(18, 47)
        Sample_net_weightLabel.Name = "Sample_net_weightLabel"
        Sample_net_weightLabel.Size = New System.Drawing.Size(97, 13)
        Sample_net_weightLabel.TabIndex = 18
        Sample_net_weightLabel.Text = "Sample net weight:"
        '
        'SampleDimensionLabel
        '
        SampleDimensionLabel.AutoSize = True
        SampleDimensionLabel.Location = New System.Drawing.Point(18, 76)
        SampleDimensionLabel.Name = "SampleDimensionLabel"
        SampleDimensionLabel.Size = New System.Drawing.Size(97, 13)
        SampleDimensionLabel.TabIndex = 19
        SampleDimensionLabel.Text = "Sample Dimension:"
        '
        'Sample_main_speciesLabel
        '
        Sample_main_speciesLabel.AutoSize = True
        Sample_main_speciesLabel.Location = New System.Drawing.Point(6, 19)
        Sample_main_speciesLabel.Name = "Sample_main_speciesLabel"
        Sample_main_speciesLabel.Size = New System.Drawing.Size(109, 13)
        Sample_main_speciesLabel.TabIndex = 20
        Sample_main_speciesLabel.Text = "Sample main species:"
        '
        'Fossil_countLabel
        '
        Fossil_countLabel.AutoSize = True
        Fossil_countLabel.Location = New System.Drawing.Point(49, 101)
        Fossil_countLabel.Name = "Fossil_countLabel"
        Fossil_countLabel.Size = New System.Drawing.Size(66, 13)
        Fossil_countLabel.TabIndex = 21
        Fossil_countLabel.Text = "Fossil count:"
        '
        'CheckoutDateLabel1
        '
        CheckoutDateLabel1.AutoSize = True
        CheckoutDateLabel1.Location = New System.Drawing.Point(273, 279)
        CheckoutDateLabel1.Name = "CheckoutDateLabel1"
        CheckoutDateLabel1.Size = New System.Drawing.Size(82, 13)
        CheckoutDateLabel1.TabIndex = 24
        CheckoutDateLabel1.Text = "Checkout Date:"
        '
        'OrderDateLabel
        '
        OrderDateLabel.AutoSize = True
        OrderDateLabel.Location = New System.Drawing.Point(32, 88)
        OrderDateLabel.Name = "OrderDateLabel"
        OrderDateLabel.Size = New System.Drawing.Size(62, 13)
        OrderDateLabel.TabIndex = 23
        OrderDateLabel.Text = "Order Date:"
        '
        'ExpierensDateLabel
        '
        ExpierensDateLabel.AutoSize = True
        ExpierensDateLabel.Location = New System.Drawing.Point(12, 115)
        ExpierensDateLabel.Name = "ExpierensDateLabel"
        ExpierensDateLabel.Size = New System.Drawing.Size(82, 13)
        ExpierensDateLabel.TabIndex = 24
        ExpierensDateLabel.Text = "Expierens Date:"
        '
        'ConfirmStockOutDateLabel
        '
        ConfirmStockOutDateLabel.AutoSize = True
        ConfirmStockOutDateLabel.Location = New System.Drawing.Point(10, 158)
        ConfirmStockOutDateLabel.Name = "ConfirmStockOutDateLabel"
        ConfirmStockOutDateLabel.Size = New System.Drawing.Size(84, 13)
        ConfirmStockOutDateLabel.TabIndex = 25
        ConfirmStockOutDateLabel.Text = "Stock Out Date:"
        '
        'CheckoutDateLabel
        '
        CheckoutDateLabel.AutoSize = True
        CheckoutDateLabel.Location = New System.Drawing.Point(141, 310)
        CheckoutDateLabel.Name = "CheckoutDateLabel"
        CheckoutDateLabel.Size = New System.Drawing.Size(82, 13)
        CheckoutDateLabel.TabIndex = 26
        CheckoutDateLabel.Text = "Checkout Date:"
        '
        'CancellationDateLabel
        '
        CancellationDateLabel.AutoSize = True
        CancellationDateLabel.Location = New System.Drawing.Point(396, 310)
        CancellationDateLabel.Name = "CancellationDateLabel"
        CancellationDateLabel.Size = New System.Drawing.Size(94, 13)
        CancellationDateLabel.TabIndex = 27
        CancellationDateLabel.Text = "Cancellation Date:"
        '
        'Select_tb_OrdersBindingSource
        '
        Me.Select_tb_OrdersBindingSource.DataMember = "Select_tb_Orders"
        Me.Select_tb_OrdersBindingSource.DataSource = Me.DsOrders
        '
        'DsOrders
        '
        Me.DsOrders.DataSetName = "dsOrders"
        Me.DsOrders.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'SelectClientstbClientsBindingSource
        '
        Me.SelectClientstbClientsBindingSource.DataMember = "Select_Clients_tb_Clients"
        Me.SelectClientstbClientsBindingSource.DataSource = Me.DsService
        '
        'DsService
        '
        Me.DsService.DataSetName = "dsService"
        Me.DsService.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Select_OrdersForClientBindingSource
        '
        Me.Select_OrdersForClientBindingSource.DataMember = "Select_OrdersForClient"
        Me.Select_OrdersForClientBindingSource.DataSource = Me.DsService
        '
        'Select_SampleInfoBindingSource
        '
        Me.Select_SampleInfoBindingSource.DataMember = "Select_SampleInfo"
        Me.Select_SampleInfoBindingSource.DataSource = Me.DsService
        '
        'SamplesAndOrdersBindingSource
        '
        Me.SamplesAndOrdersBindingSource.DataMember = "SamplesAndOrders"
        Me.SamplesAndOrdersBindingSource.DataSource = Me.DsOrders
        '
        'Select_AllSamplesInOrders_tb_SamplesAndOrdersBindingSource
        '
        Me.Select_AllSamplesInOrders_tb_SamplesAndOrdersBindingSource.DataMember = "Select_AllSamplesInOrders_tb_SamplesAndOrders"
        Me.Select_AllSamplesInOrders_tb_SamplesAndOrdersBindingSource.DataSource = Me.DsService
        '
        'Select_tb_OrdersTableAdapter
        '
        Me.Select_tb_OrdersTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.OrdersTableAdapter = Me.Select_tb_OrdersTableAdapter
        Me.TableAdapterManager.SamplesAndOrdersTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = OrdersAndClients.dsOrdersTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'Select_Clients_tb_ClientsTableAdapter
        '
        Me.Select_Clients_tb_ClientsTableAdapter.ClearBeforeFill = True
        '
        'Select_AllSamplesInOrders_tb_SamplesAndOrdersTableAdapter
        '
        Me.Select_AllSamplesInOrders_tb_SamplesAndOrdersTableAdapter.ClearBeforeFill = True
        '
        'SamplesAndOrdersTableAdapter
        '
        Me.SamplesAndOrdersTableAdapter.ClearBeforeFill = True
        '
        'Select_SampleInfoTableAdapter
        '
        Me.Select_SampleInfoTableAdapter.ClearBeforeFill = True
        '
        'Select_OrdersForClientTableAdapter
        '
        Me.Select_OrdersForClientTableAdapter.ClearBeforeFill = True
        '
        'tbOrderID
        '
        Me.tbOrderID.Enabled = False
        Me.tbOrderID.Location = New System.Drawing.Point(57, 1)
        Me.tbOrderID.Name = "tbOrderID"
        Me.tbOrderID.Size = New System.Drawing.Size(121, 20)
        Me.tbOrderID.TabIndex = 1
        '
        'ClientIDComboBox
        '
        Me.ClientIDComboBox.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.Select_tb_OrdersBindingSource, "ClientID", True))
        Me.ClientIDComboBox.DataSource = Me.SelectClientstbClientsBindingSource
        Me.ClientIDComboBox.DisplayMember = "FullName"
        Me.ClientIDComboBox.FormattingEnabled = True
        Me.ClientIDComboBox.Location = New System.Drawing.Point(65, 8)
        Me.ClientIDComboBox.Name = "ClientIDComboBox"
        Me.ClientIDComboBox.Size = New System.Drawing.Size(121, 21)
        Me.ClientIDComboBox.TabIndex = 3
        Me.ClientIDComboBox.ValueMember = "ClientID"
        '
        'main_TabControl
        '
        Me.main_TabControl.Controls.Add(Me.TabPage_OrderInfo)
        Me.main_TabControl.Controls.Add(Me.tbpgSamples)
        Me.main_TabControl.Controls.Add(Me.TabPage_XMLOrder)
        Me.main_TabControl.Controls.Add(Me.TabPage_SamplesInOrder)
        Me.main_TabControl.Location = New System.Drawing.Point(4, 27)
        Me.main_TabControl.Name = "main_TabControl"
        Me.main_TabControl.SelectedIndex = 0
        Me.main_TabControl.Size = New System.Drawing.Size(866, 444)
        Me.main_TabControl.TabIndex = 6
        '
        'TabPage_OrderInfo
        '
        Me.TabPage_OrderInfo.AutoScroll = True
        Me.TabPage_OrderInfo.Controls.Add(Me.btCalculateOrder)
        Me.TabPage_OrderInfo.Controls.Add(CancellationDateLabel)
        Me.TabPage_OrderInfo.Controls.Add(Me.OrderCancellationDateTextBox)
        Me.TabPage_OrderInfo.Controls.Add(CheckoutDateLabel)
        Me.TabPage_OrderInfo.Controls.Add(Me.OrderCheckoutDateTextBox)
        Me.TabPage_OrderInfo.Controls.Add(ConfirmStockOutDateLabel)
        Me.TabPage_OrderInfo.Controls.Add(Me.OrderConfirmStockOutDateTextBox)
        Me.TabPage_OrderInfo.Controls.Add(ExpierensDateLabel)
        Me.TabPage_OrderInfo.Controls.Add(Me.OrderExpierensDateTextBox)
        Me.TabPage_OrderInfo.Controls.Add(OrderDateLabel)
        Me.TabPage_OrderInfo.Controls.Add(Me.OrderDateTextBox)
        Me.TabPage_OrderInfo.Controls.Add(Me.btCancelOrder)
        Me.TabPage_OrderInfo.Controls.Add(Me.Select_OrdersForClientDataGridView)
        Me.TabPage_OrderInfo.Controls.Add(Me.btSaveOrder)
        Me.TabPage_OrderInfo.Controls.Add(Me.OrderCancellationFlagCheckBox)
        Me.TabPage_OrderInfo.Controls.Add(Me.OrderCheckoutFlagCheckBox)
        Me.TabPage_OrderInfo.Controls.Add(Me.OrderConfirmStockOutFlagCheckBox)
        Me.TabPage_OrderInfo.Controls.Add(Me.GbConfirmPrices)
        Me.TabPage_OrderInfo.Controls.Add(Me.GbStartPrices)
        Me.TabPage_OrderInfo.Controls.Add(Me.btNewClient)
        Me.TabPage_OrderInfo.Controls.Add(RateOfExchangeLabel)
        Me.TabPage_OrderInfo.Controls.Add(Me.OrderRateOfExchangeTextBox)
        Me.TabPage_OrderInfo.Controls.Add(CurrencyNameLabel)
        Me.TabPage_OrderInfo.Controls.Add(Me.OrderCurrencyNameComboBoxOrder)
        Me.TabPage_OrderInfo.Controls.Add(ClientIDLabel)
        Me.TabPage_OrderInfo.Controls.Add(Me.ClientIDComboBox)
        Me.TabPage_OrderInfo.Location = New System.Drawing.Point(4, 22)
        Me.TabPage_OrderInfo.Name = "TabPage_OrderInfo"
        Me.TabPage_OrderInfo.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage_OrderInfo.Size = New System.Drawing.Size(858, 418)
        Me.TabPage_OrderInfo.TabIndex = 0
        Me.TabPage_OrderInfo.Text = "Order info"
        Me.TabPage_OrderInfo.UseVisualStyleBackColor = True
        '
        'btCalculateOrder
        '
        Me.btCalculateOrder.Location = New System.Drawing.Point(192, 360)
        Me.btCalculateOrder.Name = "btCalculateOrder"
        Me.btCalculateOrder.Size = New System.Drawing.Size(75, 23)
        Me.btCalculateOrder.TabIndex = 29
        Me.btCalculateOrder.Text = "Calculate"
        Me.btCalculateOrder.UseVisualStyleBackColor = True
        '
        'OrderCancellationDateTextBox
        '
        Me.OrderCancellationDateTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Select_tb_OrdersBindingSource, "CancellationDate", True))
        Me.OrderCancellationDateTextBox.Location = New System.Drawing.Point(390, 327)
        Me.OrderCancellationDateTextBox.Name = "OrderCancellationDateTextBox"
        Me.OrderCancellationDateTextBox.Size = New System.Drawing.Size(100, 20)
        Me.OrderCancellationDateTextBox.TabIndex = 28
        '
        'OrderCheckoutDateTextBox
        '
        Me.OrderCheckoutDateTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Select_tb_OrdersBindingSource, "CheckoutDate", True))
        Me.OrderCheckoutDateTextBox.Location = New System.Drawing.Point(132, 327)
        Me.OrderCheckoutDateTextBox.Name = "OrderCheckoutDateTextBox"
        Me.OrderCheckoutDateTextBox.Size = New System.Drawing.Size(100, 20)
        Me.OrderCheckoutDateTextBox.TabIndex = 27
        '
        'OrderConfirmStockOutDateTextBox
        '
        Me.OrderConfirmStockOutDateTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Select_tb_OrdersBindingSource, "ConfirmStockOutDate", True))
        Me.OrderConfirmStockOutDateTextBox.Location = New System.Drawing.Point(100, 155)
        Me.OrderConfirmStockOutDateTextBox.Name = "OrderConfirmStockOutDateTextBox"
        Me.OrderConfirmStockOutDateTextBox.Size = New System.Drawing.Size(100, 20)
        Me.OrderConfirmStockOutDateTextBox.TabIndex = 26
        '
        'OrderExpierensDateTextBox
        '
        Me.OrderExpierensDateTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Select_tb_OrdersBindingSource, "ExpierensDate", True))
        Me.OrderExpierensDateTextBox.Location = New System.Drawing.Point(100, 112)
        Me.OrderExpierensDateTextBox.Name = "OrderExpierensDateTextBox"
        Me.OrderExpierensDateTextBox.Size = New System.Drawing.Size(100, 20)
        Me.OrderExpierensDateTextBox.TabIndex = 25
        '
        'OrderDateTextBox
        '
        Me.OrderDateTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Select_tb_OrdersBindingSource, "OrderDate", True))
        Me.OrderDateTextBox.Location = New System.Drawing.Point(100, 85)
        Me.OrderDateTextBox.Name = "OrderDateTextBox"
        Me.OrderDateTextBox.Size = New System.Drawing.Size(100, 20)
        Me.OrderDateTextBox.TabIndex = 24
        '
        'btCancelOrder
        '
        Me.btCancelOrder.Location = New System.Drawing.Point(100, 360)
        Me.btCancelOrder.Name = "btCancelOrder"
        Me.btCancelOrder.Size = New System.Drawing.Size(75, 23)
        Me.btCancelOrder.TabIndex = 8
        Me.btCancelOrder.Text = "Cancel"
        Me.btCancelOrder.UseVisualStyleBackColor = True
        '
        'Select_OrdersForClientDataGridView
        '
        Me.Select_OrdersForClientDataGridView.AutoGenerateColumns = False
        Me.Select_OrdersForClientDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Select_OrdersForClientDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewCheckBoxColumn1, Me.DataGridViewTextBoxColumn5, Me.DataGridViewCheckBoxColumn2, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4})
        Me.Select_OrdersForClientDataGridView.DataSource = Me.Select_OrdersForClientBindingSource
        Me.Select_OrdersForClientDataGridView.Location = New System.Drawing.Point(293, 6)
        Me.Select_OrdersForClientDataGridView.Name = "Select_OrdersForClientDataGridView"
        Me.Select_OrdersForClientDataGridView.ReadOnly = True
        Me.Select_OrdersForClientDataGridView.RowHeadersVisible = False
        Me.Select_OrdersForClientDataGridView.Size = New System.Drawing.Size(486, 169)
        Me.Select_OrdersForClientDataGridView.TabIndex = 22
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "OrderID"
        Me.DataGridViewTextBoxColumn1.HeaderText = "OrderID"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 50
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "OrderDate"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Order Date"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 50
        '
        'DataGridViewCheckBoxColumn1
        '
        Me.DataGridViewCheckBoxColumn1.DataPropertyName = "CheckoutFlag"
        Me.DataGridViewCheckBoxColumn1.HeaderText = "Checkout"
        Me.DataGridViewCheckBoxColumn1.Name = "DataGridViewCheckBoxColumn1"
        Me.DataGridViewCheckBoxColumn1.ReadOnly = True
        Me.DataGridViewCheckBoxColumn1.Width = 59
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "CheckoutDate"
        Me.DataGridViewTextBoxColumn5.HeaderText = "Checkout Date"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Width = 60
        '
        'DataGridViewCheckBoxColumn2
        '
        Me.DataGridViewCheckBoxColumn2.DataPropertyName = "CancellationFlag"
        Me.DataGridViewCheckBoxColumn2.HeaderText = "Cancellation"
        Me.DataGridViewCheckBoxColumn2.Name = "DataGridViewCheckBoxColumn2"
        Me.DataGridViewCheckBoxColumn2.ReadOnly = True
        Me.DataGridViewCheckBoxColumn2.Width = 71
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "CancellationDate"
        Me.DataGridViewTextBoxColumn6.HeaderText = "Cancellation Date"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Width = 70
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "ConfirmTotalOrderPrice"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Total Amount"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 60
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "ConfirmShippingPrice"
        Me.DataGridViewTextBoxColumn4.HeaderText = "Ship amount"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 60
        '
        'btSaveOrder
        '
        Me.btSaveOrder.Location = New System.Drawing.Point(10, 360)
        Me.btSaveOrder.Name = "btSaveOrder"
        Me.btSaveOrder.Size = New System.Drawing.Size(75, 23)
        Me.btSaveOrder.TabIndex = 7
        Me.btSaveOrder.Text = "Save"
        Me.btSaveOrder.UseVisualStyleBackColor = True
        '
        'OrderCancellationFlagCheckBox
        '
        Me.OrderCancellationFlagCheckBox.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.Select_tb_OrdersBindingSource, "CancellationFlag", True))
        Me.OrderCancellationFlagCheckBox.Location = New System.Drawing.Point(286, 313)
        Me.OrderCancellationFlagCheckBox.Name = "OrderCancellationFlagCheckBox"
        Me.OrderCancellationFlagCheckBox.Size = New System.Drawing.Size(86, 24)
        Me.OrderCancellationFlagCheckBox.TabIndex = 20
        Me.OrderCancellationFlagCheckBox.Text = "Cancellation"
        Me.OrderCancellationFlagCheckBox.UseVisualStyleBackColor = True
        '
        'OrderCheckoutFlagCheckBox
        '
        Me.OrderCheckoutFlagCheckBox.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.Select_tb_OrdersBindingSource, "CheckoutFlag", True))
        Me.OrderCheckoutFlagCheckBox.Location = New System.Drawing.Point(20, 313)
        Me.OrderCheckoutFlagCheckBox.Name = "OrderCheckoutFlagCheckBox"
        Me.OrderCheckoutFlagCheckBox.Size = New System.Drawing.Size(80, 24)
        Me.OrderCheckoutFlagCheckBox.TabIndex = 15
        Me.OrderCheckoutFlagCheckBox.Text = "Check Out"
        Me.OrderCheckoutFlagCheckBox.UseVisualStyleBackColor = True
        '
        'OrderConfirmStockOutFlagCheckBox
        '
        Me.OrderConfirmStockOutFlagCheckBox.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.Select_tb_OrdersBindingSource, "ConfirmStockOutFlag", True))
        Me.OrderConfirmStockOutFlagCheckBox.Location = New System.Drawing.Point(23, 131)
        Me.OrderConfirmStockOutFlagCheckBox.Name = "OrderConfirmStockOutFlagCheckBox"
        Me.OrderConfirmStockOutFlagCheckBox.Size = New System.Drawing.Size(77, 24)
        Me.OrderConfirmStockOutFlagCheckBox.TabIndex = 12
        Me.OrderConfirmStockOutFlagCheckBox.Text = "Stock Out"
        Me.OrderConfirmStockOutFlagCheckBox.UseVisualStyleBackColor = True
        '
        'GbConfirmPrices
        '
        Me.GbConfirmPrices.Controls.Add(Me.LabelUSD4)
        Me.GbConfirmPrices.Controls.Add(Me.LabelUSD3)
        Me.GbConfirmPrices.Controls.Add(ConfirmShippingPriceLabel)
        Me.GbConfirmPrices.Controls.Add(Me.OrderConfirmShippingPriceTextBox)
        Me.GbConfirmPrices.Controls.Add(ConfirmTotalOrderPriceLabel)
        Me.GbConfirmPrices.Controls.Add(Me.OrderConfirmTotalOrderPriceTextBox)
        Me.GbConfirmPrices.Location = New System.Drawing.Point(338, 181)
        Me.GbConfirmPrices.Name = "GbConfirmPrices"
        Me.GbConfirmPrices.Size = New System.Drawing.Size(296, 117)
        Me.GbConfirmPrices.TabIndex = 9
        Me.GbConfirmPrices.TabStop = False
        Me.GbConfirmPrices.Text = "Confirm prices"
        '
        'LabelUSD4
        '
        Me.LabelUSD4.AutoSize = True
        Me.LabelUSD4.Location = New System.Drawing.Point(250, 67)
        Me.LabelUSD4.Name = "LabelUSD4"
        Me.LabelUSD4.Size = New System.Drawing.Size(39, 13)
        Me.LabelUSD4.TabIndex = 9
        Me.LabelUSD4.Text = "Label3"
        '
        'LabelUSD3
        '
        Me.LabelUSD3.AutoSize = True
        Me.LabelUSD3.Location = New System.Drawing.Point(250, 38)
        Me.LabelUSD3.Name = "LabelUSD3"
        Me.LabelUSD3.Size = New System.Drawing.Size(39, 13)
        Me.LabelUSD3.TabIndex = 8
        Me.LabelUSD3.Text = "Label3"
        '
        'OrderConfirmShippingPriceTextBox
        '
        Me.OrderConfirmShippingPriceTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Select_tb_OrdersBindingSource, "ConfirmShippingPrice", True))
        Me.OrderConfirmShippingPriceTextBox.Location = New System.Drawing.Point(145, 64)
        Me.OrderConfirmShippingPriceTextBox.Name = "OrderConfirmShippingPriceTextBox"
        Me.OrderConfirmShippingPriceTextBox.Size = New System.Drawing.Size(100, 20)
        Me.OrderConfirmShippingPriceTextBox.TabIndex = 3
        '
        'OrderConfirmTotalOrderPriceTextBox
        '
        Me.OrderConfirmTotalOrderPriceTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Select_tb_OrdersBindingSource, "ConfirmTotalOrderPrice", True))
        Me.OrderConfirmTotalOrderPriceTextBox.Location = New System.Drawing.Point(145, 35)
        Me.OrderConfirmTotalOrderPriceTextBox.Name = "OrderConfirmTotalOrderPriceTextBox"
        Me.OrderConfirmTotalOrderPriceTextBox.Size = New System.Drawing.Size(100, 20)
        Me.OrderConfirmTotalOrderPriceTextBox.TabIndex = 1
        '
        'GbStartPrices
        '
        Me.GbStartPrices.Controls.Add(Me.LabelUSD2)
        Me.GbStartPrices.Controls.Add(Me.LabelUSD1)
        Me.GbStartPrices.Controls.Add(Me.OrderFreeShippingFlagCheckBox)
        Me.GbStartPrices.Controls.Add(ShippingPriceLabel)
        Me.GbStartPrices.Controls.Add(Me.OrderShippingPriceTextBox)
        Me.GbStartPrices.Controls.Add(OrderTotalPriceLabel)
        Me.GbStartPrices.Controls.Add(Me.OrderTotalPriceTextBox)
        Me.GbStartPrices.Location = New System.Drawing.Point(12, 181)
        Me.GbStartPrices.Name = "GbStartPrices"
        Me.GbStartPrices.Size = New System.Drawing.Size(275, 117)
        Me.GbStartPrices.TabIndex = 8
        Me.GbStartPrices.TabStop = False
        Me.GbStartPrices.Text = "Start prices"
        '
        'LabelUSD2
        '
        Me.LabelUSD2.AutoSize = True
        Me.LabelUSD2.Location = New System.Drawing.Point(213, 58)
        Me.LabelUSD2.Name = "LabelUSD2"
        Me.LabelUSD2.Size = New System.Drawing.Size(39, 13)
        Me.LabelUSD2.TabIndex = 7
        Me.LabelUSD2.Text = "Label3"
        '
        'LabelUSD1
        '
        Me.LabelUSD1.AutoSize = True
        Me.LabelUSD1.Location = New System.Drawing.Point(213, 26)
        Me.LabelUSD1.Name = "LabelUSD1"
        Me.LabelUSD1.Size = New System.Drawing.Size(39, 13)
        Me.LabelUSD1.TabIndex = 6
        Me.LabelUSD1.Text = "Label3"
        '
        'OrderFreeShippingFlagCheckBox
        '
        Me.OrderFreeShippingFlagCheckBox.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.Select_tb_OrdersBindingSource, "FreeShippingFlag", True))
        Me.OrderFreeShippingFlagCheckBox.Location = New System.Drawing.Point(107, 77)
        Me.OrderFreeShippingFlagCheckBox.Name = "OrderFreeShippingFlagCheckBox"
        Me.OrderFreeShippingFlagCheckBox.Size = New System.Drawing.Size(104, 24)
        Me.OrderFreeShippingFlagCheckBox.TabIndex = 5
        Me.OrderFreeShippingFlagCheckBox.Text = "Free shipping"
        Me.OrderFreeShippingFlagCheckBox.UseVisualStyleBackColor = True
        '
        'OrderShippingPriceTextBox
        '
        Me.OrderShippingPriceTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Select_tb_OrdersBindingSource, "ShippingPrice", True))
        Me.OrderShippingPriceTextBox.Location = New System.Drawing.Point(107, 51)
        Me.OrderShippingPriceTextBox.Name = "OrderShippingPriceTextBox"
        Me.OrderShippingPriceTextBox.Size = New System.Drawing.Size(100, 20)
        Me.OrderShippingPriceTextBox.TabIndex = 3
        '
        'OrderTotalPriceTextBox
        '
        Me.OrderTotalPriceTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Select_tb_OrdersBindingSource, "OrderTotalPrice", True))
        Me.OrderTotalPriceTextBox.Location = New System.Drawing.Point(107, 19)
        Me.OrderTotalPriceTextBox.Name = "OrderTotalPriceTextBox"
        Me.OrderTotalPriceTextBox.Size = New System.Drawing.Size(100, 20)
        Me.OrderTotalPriceTextBox.TabIndex = 1
        '
        'btNewClient
        '
        Me.btNewClient.Location = New System.Drawing.Point(192, 8)
        Me.btNewClient.Name = "btNewClient"
        Me.btNewClient.Size = New System.Drawing.Size(95, 21)
        Me.btNewClient.TabIndex = 7
        Me.btNewClient.Text = "New client.."
        Me.btNewClient.UseVisualStyleBackColor = True
        '
        'OrderRateOfExchangeTextBox
        '
        Me.OrderRateOfExchangeTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Select_tb_OrdersBindingSource, "RateOfExchange", True))
        Me.OrderRateOfExchangeTextBox.Location = New System.Drawing.Point(119, 58)
        Me.OrderRateOfExchangeTextBox.Name = "OrderRateOfExchangeTextBox"
        Me.OrderRateOfExchangeTextBox.Size = New System.Drawing.Size(50, 20)
        Me.OrderRateOfExchangeTextBox.TabIndex = 3
        '
        'OrderCurrencyNameComboBoxOrder
        '
        Me.OrderCurrencyNameComboBoxOrder.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Select_tb_OrdersBindingSource, "CurrencyName", True))
        Me.OrderCurrencyNameComboBoxOrder.FormattingEnabled = True
        Me.OrderCurrencyNameComboBoxOrder.Location = New System.Drawing.Point(100, 34)
        Me.OrderCurrencyNameComboBoxOrder.Name = "OrderCurrencyNameComboBoxOrder"
        Me.OrderCurrencyNameComboBoxOrder.Size = New System.Drawing.Size(70, 21)
        Me.OrderCurrencyNameComboBoxOrder.TabIndex = 1
        '
        'tbpgSamples
        '
        Me.tbpgSamples.AutoScroll = True
        Me.tbpgSamples.Controls.Add(Me.Button1)
        Me.tbpgSamples.Controls.Add(Me.btSampleOnSale)
        Me.tbpgSamples.Controls.Add(Me.tbMainFossilSize)
        Me.tbpgSamples.Controls.Add(Me.tbMainFossilName)
        Me.tbpgSamples.Controls.Add(Me.lbCountNewRowInSample)
        Me.tbpgSamples.Controls.Add(Me.btSampleInfo)
        Me.tbpgSamples.Controls.Add(Me.btImagesForm)
        Me.tbpgSamples.Controls.Add(Me.pbSampleImage)
        Me.tbpgSamples.Controls.Add(Me.Dgv_SamplesINOrders)
        Me.tbpgSamples.Controls.Add(Me.btCopySample)
        Me.tbpgSamples.Controls.Add(Me.btDeleteSample)
        Me.tbpgSamples.Controls.Add(Me.btCancelChanges)
        Me.tbpgSamples.Controls.Add(Me.btSaveChanges)
        Me.tbpgSamples.Location = New System.Drawing.Point(4, 22)
        Me.tbpgSamples.Name = "tbpgSamples"
        Me.tbpgSamples.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpgSamples.Size = New System.Drawing.Size(858, 418)
        Me.tbpgSamples.TabIndex = 3
        Me.tbpgSamples.Text = "Samples"
        Me.tbpgSamples.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(777, 359)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 29
        Me.Button1.Text = "Фото мж.."
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btSampleOnSale
        '
        Me.btSampleOnSale.Location = New System.Drawing.Point(777, 389)
        Me.btSampleOnSale.Name = "btSampleOnSale"
        Me.btSampleOnSale.Size = New System.Drawing.Size(75, 23)
        Me.btSampleOnSale.TabIndex = 28
        Me.btSampleOnSale.Text = "Описание.."
        Me.btSampleOnSale.UseVisualStyleBackColor = True
        '
        'tbMainFossilSize
        '
        Me.tbMainFossilSize.Enabled = False
        Me.tbMainFossilSize.Location = New System.Drawing.Point(678, 236)
        Me.tbMainFossilSize.Name = "tbMainFossilSize"
        Me.tbMainFossilSize.Size = New System.Drawing.Size(96, 20)
        Me.tbMainFossilSize.TabIndex = 27
        '
        'tbMainFossilName
        '
        Me.tbMainFossilName.Enabled = False
        Me.tbMainFossilName.Location = New System.Drawing.Point(678, 151)
        Me.tbMainFossilName.Multiline = True
        Me.tbMainFossilName.Name = "tbMainFossilName"
        Me.tbMainFossilName.Size = New System.Drawing.Size(96, 79)
        Me.tbMainFossilName.TabIndex = 26
        '
        'lbCountNewRowInSample
        '
        Me.lbCountNewRowInSample.AutoSize = True
        Me.lbCountNewRowInSample.Location = New System.Drawing.Point(678, 72)
        Me.lbCountNewRowInSample.Name = "lbCountNewRowInSample"
        Me.lbCountNewRowInSample.Size = New System.Drawing.Size(0, 13)
        Me.lbCountNewRowInSample.TabIndex = 25
        '
        'btSampleInfo
        '
        Me.btSampleInfo.Location = New System.Drawing.Point(678, 389)
        Me.btSampleInfo.Name = "btSampleInfo"
        Me.btSampleInfo.Size = New System.Drawing.Size(75, 23)
        Me.btSampleInfo.TabIndex = 24
        Me.btSampleInfo.Text = "Данные.."
        Me.btSampleInfo.UseVisualStyleBackColor = True
        '
        'btImagesForm
        '
        Me.btImagesForm.Location = New System.Drawing.Point(678, 359)
        Me.btImagesForm.Name = "btImagesForm"
        Me.btImagesForm.Size = New System.Drawing.Size(75, 23)
        Me.btImagesForm.TabIndex = 23
        Me.btImagesForm.Text = "Фотки.."
        Me.btImagesForm.UseVisualStyleBackColor = True
        '
        'pbSampleImage
        '
        Me.pbSampleImage.Location = New System.Drawing.Point(678, 262)
        Me.pbSampleImage.Name = "pbSampleImage"
        Me.pbSampleImage.Size = New System.Drawing.Size(100, 91)
        Me.pbSampleImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbSampleImage.TabIndex = 22
        Me.pbSampleImage.TabStop = False
        '
        'Dgv_SamplesINOrders
        '
        Me.Dgv_SamplesINOrders.AutoGenerateColumns = False
        Me.Dgv_SamplesINOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv_SamplesINOrders.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn15, Me.DataGridViewTextBoxColumn11, Me.DataGridViewTextBoxColumn12, Me.DataGridViewCheckBoxColumn3, Me.DataGridViewTextBoxColumn13, Me.DataGridViewTextBoxColumn14, Me.DataGridViewCheckBoxColumn4, Me.DataGridViewTextBoxColumn16, Me.DataGridViewCheckBoxColumn5, Me.DataGridViewTextBoxColumn17, Me.OrderID})
        Me.Dgv_SamplesINOrders.DataSource = Me.SamplesINOrdersBindingSource
        Me.Dgv_SamplesINOrders.Location = New System.Drawing.Point(3, 3)
        Me.Dgv_SamplesINOrders.Name = "Dgv_SamplesINOrders"
        Me.Dgv_SamplesINOrders.Size = New System.Drawing.Size(669, 409)
        Me.Dgv_SamplesINOrders.TabIndex = 21
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "SampleNumber"
        Me.DataGridViewTextBoxColumn7.HeaderText = "Sample Number"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.Width = 90
        '
        'DataGridViewTextBoxColumn15
        '
        Me.DataGridViewTextBoxColumn15.DataPropertyName = "CurrencyName"
        Me.DataGridViewTextBoxColumn15.HeaderText = "Cur"
        Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
        Me.DataGridViewTextBoxColumn15.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn15.Width = 40
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "Price"
        Me.DataGridViewTextBoxColumn11.HeaderText = "Price"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.Width = 50
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.DataPropertyName = "Discount"
        Me.DataGridViewTextBoxColumn12.HeaderText = "Discount"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.Width = 60
        '
        'DataGridViewCheckBoxColumn3
        '
        Me.DataGridViewCheckBoxColumn3.DataPropertyName = "ConfirmFlag"
        Me.DataGridViewCheckBoxColumn3.HeaderText = "Confirm"
        Me.DataGridViewCheckBoxColumn3.Name = "DataGridViewCheckBoxColumn3"
        Me.DataGridViewCheckBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewCheckBoxColumn3.Width = 60
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.DataPropertyName = "ConfirmPrice"
        Me.DataGridViewTextBoxColumn13.HeaderText = "Confirm Price"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.Width = 60
        '
        'DataGridViewTextBoxColumn14
        '
        Me.DataGridViewTextBoxColumn14.DataPropertyName = "ConfirmShippingPrice"
        Me.DataGridViewTextBoxColumn14.HeaderText = "Ship Price"
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        Me.DataGridViewTextBoxColumn14.Width = 50
        '
        'DataGridViewCheckBoxColumn4
        '
        Me.DataGridViewCheckBoxColumn4.DataPropertyName = "FreeShippingFlag"
        Me.DataGridViewCheckBoxColumn4.HeaderText = "Free Ship"
        Me.DataGridViewCheckBoxColumn4.Name = "DataGridViewCheckBoxColumn4"
        Me.DataGridViewCheckBoxColumn4.Width = 50
        '
        'DataGridViewTextBoxColumn16
        '
        Me.DataGridViewTextBoxColumn16.DataPropertyName = "RateOfExchange"
        Me.DataGridViewTextBoxColumn16.HeaderText = "Rate"
        Me.DataGridViewTextBoxColumn16.Name = "DataGridViewTextBoxColumn16"
        Me.DataGridViewTextBoxColumn16.Width = 40
        '
        'DataGridViewCheckBoxColumn5
        '
        Me.DataGridViewCheckBoxColumn5.DataPropertyName = "CheckoutFlag"
        Me.DataGridViewCheckBoxColumn5.HeaderText = "Checkout"
        Me.DataGridViewCheckBoxColumn5.Name = "DataGridViewCheckBoxColumn5"
        Me.DataGridViewCheckBoxColumn5.Width = 60
        '
        'DataGridViewTextBoxColumn17
        '
        Me.DataGridViewTextBoxColumn17.DataPropertyName = "CheckoutDate"
        Me.DataGridViewTextBoxColumn17.HeaderText = "Checkout Date"
        Me.DataGridViewTextBoxColumn17.Name = "DataGridViewTextBoxColumn17"
        Me.DataGridViewTextBoxColumn17.Width = 60
        '
        'OrderID
        '
        Me.OrderID.DataPropertyName = "OrderID"
        Me.OrderID.HeaderText = "OrderID"
        Me.OrderID.Name = "OrderID"
        Me.OrderID.Visible = False
        '
        'SamplesINOrdersBindingSource
        '
        Me.SamplesINOrdersBindingSource.DataMember = "SamplesINOrders"
        Me.SamplesINOrdersBindingSource.DataSource = Me.DsSampleInOrder
        '
        'DsSampleInOrder
        '
        Me.DsSampleInOrder.DataSetName = "dsSampleInOrder"
        Me.DsSampleInOrder.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'btCopySample
        '
        Me.btCopySample.Enabled = False
        Me.btCopySample.Location = New System.Drawing.Point(678, 97)
        Me.btCopySample.Name = "btCopySample"
        Me.btCopySample.Size = New System.Drawing.Size(59, 23)
        Me.btCopySample.TabIndex = 21
        Me.btCopySample.Text = "Copy to.."
        Me.btCopySample.UseVisualStyleBackColor = True
        '
        'btDeleteSample
        '
        Me.btDeleteSample.Location = New System.Drawing.Point(678, 68)
        Me.btDeleteSample.Name = "btDeleteSample"
        Me.btDeleteSample.Size = New System.Drawing.Size(59, 23)
        Me.btDeleteSample.TabIndex = 20
        Me.btDeleteSample.Text = "Delete"
        Me.btDeleteSample.UseVisualStyleBackColor = True
        '
        'btCancelChanges
        '
        Me.btCancelChanges.Location = New System.Drawing.Point(678, 35)
        Me.btCancelChanges.Name = "btCancelChanges"
        Me.btCancelChanges.Size = New System.Drawing.Size(75, 23)
        Me.btCancelChanges.TabIndex = 2
        Me.btCancelChanges.Text = "Cancel"
        Me.btCancelChanges.UseVisualStyleBackColor = True
        '
        'btSaveChanges
        '
        Me.btSaveChanges.Location = New System.Drawing.Point(678, 6)
        Me.btSaveChanges.Name = "btSaveChanges"
        Me.btSaveChanges.Size = New System.Drawing.Size(75, 23)
        Me.btSaveChanges.TabIndex = 1
        Me.btSaveChanges.Text = "Save"
        Me.btSaveChanges.UseVisualStyleBackColor = True
        '
        'TabPage_XMLOrder
        '
        Me.TabPage_XMLOrder.AutoScroll = True
        Me.TabPage_XMLOrder.Controls.Add(Me.cbxDelExists)
        Me.TabPage_XMLOrder.Controls.Add(Me.cbxRefreshImages)
        Me.TabPage_XMLOrder.Controls.Add(Me.btShowInBrowser)
        Me.TabPage_XMLOrder.Controls.Add(Me.cbTypeOfCatalog)
        Me.TabPage_XMLOrder.Controls.Add(Me.Preview_TabControl)
        Me.TabPage_XMLOrder.Controls.Add(Me.btCopyText)
        Me.TabPage_XMLOrder.Controls.Add(Me.btCreateXML)
        Me.TabPage_XMLOrder.Location = New System.Drawing.Point(4, 22)
        Me.TabPage_XMLOrder.Name = "TabPage_XMLOrder"
        Me.TabPage_XMLOrder.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage_XMLOrder.Size = New System.Drawing.Size(858, 418)
        Me.TabPage_XMLOrder.TabIndex = 1
        Me.TabPage_XMLOrder.Text = "XML"
        Me.TabPage_XMLOrder.UseVisualStyleBackColor = True
        '
        'cbxDelExists
        '
        Me.cbxDelExists.AutoSize = True
        Me.cbxDelExists.Checked = True
        Me.cbxDelExists.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbxDelExists.Location = New System.Drawing.Point(134, 390)
        Me.cbxDelExists.Name = "cbxDelExists"
        Me.cbxDelExists.Size = New System.Drawing.Size(264, 17)
        Me.cbxDelExists.TabIndex = 8
        Me.cbxDelExists.Text = "Перезаписать файлы фоток, если существуют"
        Me.cbxDelExists.UseVisualStyleBackColor = True
        '
        'cbxRefreshImages
        '
        Me.cbxRefreshImages.AutoSize = True
        Me.cbxRefreshImages.Location = New System.Drawing.Point(13, 389)
        Me.cbxRefreshImages.Name = "cbxRefreshImages"
        Me.cbxRefreshImages.Size = New System.Drawing.Size(103, 17)
        Me.cbxRefreshImages.TabIndex = 7
        Me.cbxRefreshImages.Text = "Обновить фото"
        Me.cbxRefreshImages.UseVisualStyleBackColor = True
        '
        'btShowInBrowser
        '
        Me.btShowInBrowser.Location = New System.Drawing.Point(606, 360)
        Me.btShowInBrowser.Name = "btShowInBrowser"
        Me.btShowInBrowser.Size = New System.Drawing.Size(157, 23)
        Me.btShowInBrowser.TabIndex = 6
        Me.btShowInBrowser.Text = "Show in browser"
        Me.btShowInBrowser.UseVisualStyleBackColor = True
        '
        'cbTypeOfCatalog
        '
        Me.cbTypeOfCatalog.FormattingEnabled = True
        Me.cbTypeOfCatalog.Items.AddRange(New Object() {"Все образцы", "Заказанные", "Отмененные"})
        Me.cbTypeOfCatalog.Location = New System.Drawing.Point(134, 362)
        Me.cbTypeOfCatalog.Name = "cbTypeOfCatalog"
        Me.cbTypeOfCatalog.Size = New System.Drawing.Size(121, 21)
        Me.cbTypeOfCatalog.TabIndex = 5
        '
        'Preview_TabControl
        '
        Me.Preview_TabControl.Controls.Add(Me.PreviewHTML_TabPage)
        Me.Preview_TabControl.Controls.Add(Me.PreviewTXT_TabPage)
        Me.Preview_TabControl.Controls.Add(Me.PreviewXML_TabPage)
        Me.Preview_TabControl.Location = New System.Drawing.Point(6, 6)
        Me.Preview_TabControl.Name = "Preview_TabControl"
        Me.Preview_TabControl.SelectedIndex = 0
        Me.Preview_TabControl.Size = New System.Drawing.Size(757, 348)
        Me.Preview_TabControl.TabIndex = 4
        '
        'PreviewHTML_TabPage
        '
        Me.PreviewHTML_TabPage.Controls.Add(Me.OrderHTML_WebBrowser)
        Me.PreviewHTML_TabPage.Location = New System.Drawing.Point(4, 22)
        Me.PreviewHTML_TabPage.Name = "PreviewHTML_TabPage"
        Me.PreviewHTML_TabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.PreviewHTML_TabPage.Size = New System.Drawing.Size(749, 322)
        Me.PreviewHTML_TabPage.TabIndex = 0
        Me.PreviewHTML_TabPage.Text = "HTML"
        Me.PreviewHTML_TabPage.UseVisualStyleBackColor = True
        '
        'OrderHTML_WebBrowser
        '
        Me.OrderHTML_WebBrowser.Dock = System.Windows.Forms.DockStyle.Fill
        Me.OrderHTML_WebBrowser.Location = New System.Drawing.Point(3, 3)
        Me.OrderHTML_WebBrowser.MinimumSize = New System.Drawing.Size(20, 20)
        Me.OrderHTML_WebBrowser.Name = "OrderHTML_WebBrowser"
        Me.OrderHTML_WebBrowser.Size = New System.Drawing.Size(743, 316)
        Me.OrderHTML_WebBrowser.TabIndex = 0
        '
        'PreviewTXT_TabPage
        '
        Me.PreviewTXT_TabPage.Controls.Add(Me.OrderText_RichTextBox)
        Me.PreviewTXT_TabPage.Location = New System.Drawing.Point(4, 22)
        Me.PreviewTXT_TabPage.Name = "PreviewTXT_TabPage"
        Me.PreviewTXT_TabPage.Size = New System.Drawing.Size(749, 322)
        Me.PreviewTXT_TabPage.TabIndex = 2
        Me.PreviewTXT_TabPage.Text = "Text"
        Me.PreviewTXT_TabPage.UseVisualStyleBackColor = True
        '
        'OrderText_RichTextBox
        '
        Me.OrderText_RichTextBox.Location = New System.Drawing.Point(3, 0)
        Me.OrderText_RichTextBox.Name = "OrderText_RichTextBox"
        Me.OrderText_RichTextBox.Size = New System.Drawing.Size(743, 325)
        Me.OrderText_RichTextBox.TabIndex = 0
        Me.OrderText_RichTextBox.Text = ""
        '
        'PreviewXML_TabPage
        '
        Me.PreviewXML_TabPage.Controls.Add(Me.OrderInfoPaperRichTextBox)
        Me.PreviewXML_TabPage.Location = New System.Drawing.Point(4, 22)
        Me.PreviewXML_TabPage.Name = "PreviewXML_TabPage"
        Me.PreviewXML_TabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.PreviewXML_TabPage.Size = New System.Drawing.Size(749, 322)
        Me.PreviewXML_TabPage.TabIndex = 1
        Me.PreviewXML_TabPage.Text = "XML"
        Me.PreviewXML_TabPage.UseVisualStyleBackColor = True
        '
        'OrderInfoPaperRichTextBox
        '
        Me.OrderInfoPaperRichTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Select_tb_OrdersBindingSource, "OrderInfoPaper", True))
        Me.OrderInfoPaperRichTextBox.Location = New System.Drawing.Point(6, 6)
        Me.OrderInfoPaperRichTextBox.Name = "OrderInfoPaperRichTextBox"
        Me.OrderInfoPaperRichTextBox.Size = New System.Drawing.Size(737, 313)
        Me.OrderInfoPaperRichTextBox.TabIndex = 1
        Me.OrderInfoPaperRichTextBox.Text = ""
        '
        'btCopyText
        '
        Me.btCopyText.Location = New System.Drawing.Point(288, 360)
        Me.btCopyText.Name = "btCopyText"
        Me.btCopyText.Size = New System.Drawing.Size(129, 23)
        Me.btCopyText.TabIndex = 3
        Me.btCopyText.Text = "Copy text to clipboard"
        Me.btCopyText.UseVisualStyleBackColor = True
        '
        'btCreateXML
        '
        Me.btCreateXML.Location = New System.Drawing.Point(6, 360)
        Me.btCreateXML.Name = "btCreateXML"
        Me.btCreateXML.Size = New System.Drawing.Size(95, 23)
        Me.btCreateXML.TabIndex = 2
        Me.btCreateXML.Text = "Refresh XML"
        Me.btCreateXML.UseVisualStyleBackColor = True
        '
        'TabPage_SamplesInOrder
        '
        Me.TabPage_SamplesInOrder.AutoScroll = True
        Me.TabPage_SamplesInOrder.Controls.Add(Me.btShowImages)
        Me.TabPage_SamplesInOrder.Controls.Add(Me.SampleCheckoutDateTextBox)
        Me.TabPage_SamplesInOrder.Controls.Add(CheckoutDateLabel1)
        Me.TabPage_SamplesInOrder.Controls.Add(Me.BtCancelSample)
        Me.TabPage_SamplesInOrder.Controls.Add(Me.btSaveSample)
        Me.TabPage_SamplesInOrder.Controls.Add(Me.TabControlSampleData)
        Me.TabPage_SamplesInOrder.Controls.Add(Me.btMoveToAnotherOrder)
        Me.TabPage_SamplesInOrder.Controls.Add(Me.btRemoveSampleFromOrder)
        Me.TabPage_SamplesInOrder.Controls.Add(Me.btAddSampleToOrder)
        Me.TabPage_SamplesInOrder.Controls.Add(Me.SampleCheckOutCheckBox)
        Me.TabPage_SamplesInOrder.Controls.Add(Me.SampleConfirmFlagCheckBox)
        Me.TabPage_SamplesInOrder.Controls.Add(Me.GbSampleConfirmPrices)
        Me.TabPage_SamplesInOrder.Controls.Add(Me.GroupBox1)
        Me.TabPage_SamplesInOrder.Controls.Add(RateOfExchangeLabel1)
        Me.TabPage_SamplesInOrder.Controls.Add(Me.SampleRateOfExchangeTextBox)
        Me.TabPage_SamplesInOrder.Controls.Add(CurrencyNameLabel1)
        Me.TabPage_SamplesInOrder.Controls.Add(Me.SampleCurrencyNameComboBox)
        Me.TabPage_SamplesInOrder.Controls.Add(SampleNumberLabel)
        Me.TabPage_SamplesInOrder.Controls.Add(Me.SampleNumberListBox)
        Me.TabPage_SamplesInOrder.Location = New System.Drawing.Point(4, 22)
        Me.TabPage_SamplesInOrder.Name = "TabPage_SamplesInOrder"
        Me.TabPage_SamplesInOrder.Size = New System.Drawing.Size(858, 418)
        Me.TabPage_SamplesInOrder.TabIndex = 2
        Me.TabPage_SamplesInOrder.Text = "S.old"
        Me.TabPage_SamplesInOrder.UseVisualStyleBackColor = True
        '
        'btShowImages
        '
        Me.btShowImages.Location = New System.Drawing.Point(419, 356)
        Me.btShowImages.Name = "btShowImages"
        Me.btShowImages.Size = New System.Drawing.Size(91, 23)
        Me.btShowImages.TabIndex = 26
        Me.btShowImages.Text = "Show images.."
        Me.btShowImages.UseVisualStyleBackColor = True
        '
        'SampleCheckoutDateTextBox
        '
        Me.SampleCheckoutDateTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.SamplesAndOrdersBindingSource, "CheckoutDate", True))
        Me.SampleCheckoutDateTextBox.Location = New System.Drawing.Point(266, 295)
        Me.SampleCheckoutDateTextBox.Name = "SampleCheckoutDateTextBox"
        Me.SampleCheckoutDateTextBox.Size = New System.Drawing.Size(100, 20)
        Me.SampleCheckoutDateTextBox.TabIndex = 25
        '
        'BtCancelSample
        '
        Me.BtCancelSample.Location = New System.Drawing.Point(97, 359)
        Me.BtCancelSample.Name = "BtCancelSample"
        Me.BtCancelSample.Size = New System.Drawing.Size(75, 23)
        Me.BtCancelSample.TabIndex = 24
        Me.BtCancelSample.Text = "Cancel"
        Me.BtCancelSample.UseVisualStyleBackColor = True
        '
        'btSaveSample
        '
        Me.btSaveSample.Location = New System.Drawing.Point(7, 359)
        Me.btSaveSample.Name = "btSaveSample"
        Me.btSaveSample.Size = New System.Drawing.Size(75, 23)
        Me.btSaveSample.TabIndex = 23
        Me.btSaveSample.Text = "Save"
        Me.btSaveSample.UseVisualStyleBackColor = True
        '
        'TabControlSampleData
        '
        Me.TabControlSampleData.Controls.Add(Me.TabPageImages)
        Me.TabControlSampleData.Controls.Add(Me.TabPageData)
        Me.TabControlSampleData.Enabled = False
        Me.TabControlSampleData.Location = New System.Drawing.Point(417, 3)
        Me.TabControlSampleData.Name = "TabControlSampleData"
        Me.TabControlSampleData.SelectedIndex = 0
        Me.TabControlSampleData.Size = New System.Drawing.Size(346, 343)
        Me.TabControlSampleData.TabIndex = 22
        Me.TabControlSampleData.Visible = False
        '
        'TabPageImages
        '
        Me.TabPageImages.Controls.Add(Me.ListViewSampleImages)
        Me.TabPageImages.Location = New System.Drawing.Point(4, 22)
        Me.TabPageImages.Name = "TabPageImages"
        Me.TabPageImages.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageImages.Size = New System.Drawing.Size(338, 317)
        Me.TabPageImages.TabIndex = 0
        Me.TabPageImages.Text = "Images"
        Me.TabPageImages.UseVisualStyleBackColor = True
        '
        'ListViewSampleImages
        '
        Me.ListViewSampleImages.Location = New System.Drawing.Point(3, 3)
        Me.ListViewSampleImages.Name = "ListViewSampleImages"
        Me.ListViewSampleImages.Size = New System.Drawing.Size(326, 308)
        Me.ListViewSampleImages.TabIndex = 15
        Me.ListViewSampleImages.UseCompatibleStateImageBehavior = False
        Me.ListViewSampleImages.View = System.Windows.Forms.View.SmallIcon
        '
        'TabPageData
        '
        Me.TabPageData.Controls.Add(Me.DataGridView1)
        Me.TabPageData.Controls.Add(Me.GbSampleData)
        Me.TabPageData.Location = New System.Drawing.Point(4, 22)
        Me.TabPageData.Name = "TabPageData"
        Me.TabPageData.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageData.Size = New System.Drawing.Size(338, 317)
        Me.TabPageData.TabIndex = 1
        Me.TabPageData.Text = "Data"
        Me.TabPageData.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn8, Me.DataGridViewTextBoxColumn9, Me.FossilheightDataGridViewTextBoxColumn})
        Me.DataGridView1.DataSource = Me.SelectFossilInfoBindingSource
        Me.DataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DataGridView1.Location = New System.Drawing.Point(6, 141)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(316, 170)
        Me.DataGridView1.TabIndex = 22
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "Fossil_full_name"
        Me.DataGridViewTextBoxColumn8.HeaderText = "Fossil_full_name"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        Me.DataGridViewTextBoxColumn8.Width = 109
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "Fossil dimension"
        Me.DataGridViewTextBoxColumn9.HeaderText = "Fossil dimension"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        Me.DataGridViewTextBoxColumn9.Width = 99
        '
        'FossilheightDataGridViewTextBoxColumn
        '
        Me.FossilheightDataGridViewTextBoxColumn.DataPropertyName = "Fossil_height"
        Me.FossilheightDataGridViewTextBoxColumn.HeaderText = "Fossil_height"
        Me.FossilheightDataGridViewTextBoxColumn.Name = "FossilheightDataGridViewTextBoxColumn"
        Me.FossilheightDataGridViewTextBoxColumn.ReadOnly = True
        Me.FossilheightDataGridViewTextBoxColumn.Width = 93
        '
        'SelectFossilInfoBindingSource
        '
        Me.SelectFossilInfoBindingSource.DataMember = "SelectFossilInfo"
        Me.SelectFossilInfoBindingSource.DataSource = Me.DsService
        '
        'GbSampleData
        '
        Me.GbSampleData.Controls.Add(Fossil_countLabel)
        Me.GbSampleData.Controls.Add(Me.Fossil_countTextBox)
        Me.GbSampleData.Controls.Add(Sample_main_speciesLabel)
        Me.GbSampleData.Controls.Add(Me.Sample_main_speciesTextBox)
        Me.GbSampleData.Controls.Add(Me.SampleDimensionTextBox)
        Me.GbSampleData.Controls.Add(SampleDimensionLabel)
        Me.GbSampleData.Controls.Add(Me.Sample_net_weightTextBox)
        Me.GbSampleData.Controls.Add(Sample_net_weightLabel)
        Me.GbSampleData.Location = New System.Drawing.Point(6, 6)
        Me.GbSampleData.Name = "GbSampleData"
        Me.GbSampleData.Size = New System.Drawing.Size(316, 129)
        Me.GbSampleData.TabIndex = 21
        Me.GbSampleData.TabStop = False
        '
        'Fossil_countTextBox
        '
        Me.Fossil_countTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Select_SampleInfoBindingSource, "FossilCount", True))
        Me.Fossil_countTextBox.Location = New System.Drawing.Point(121, 98)
        Me.Fossil_countTextBox.Name = "Fossil_countTextBox"
        Me.Fossil_countTextBox.Size = New System.Drawing.Size(31, 20)
        Me.Fossil_countTextBox.TabIndex = 22
        '
        'Sample_main_speciesTextBox
        '
        Me.Sample_main_speciesTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Select_SampleInfoBindingSource, "Sample_main_species", True))
        Me.Sample_main_speciesTextBox.Location = New System.Drawing.Point(121, 16)
        Me.Sample_main_speciesTextBox.Name = "Sample_main_speciesTextBox"
        Me.Sample_main_speciesTextBox.Size = New System.Drawing.Size(151, 20)
        Me.Sample_main_speciesTextBox.TabIndex = 21
        '
        'SampleDimensionTextBox
        '
        Me.SampleDimensionTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Select_SampleInfoBindingSource, "Sample dimension", True))
        Me.SampleDimensionTextBox.Location = New System.Drawing.Point(121, 72)
        Me.SampleDimensionTextBox.Name = "SampleDimensionTextBox"
        Me.SampleDimensionTextBox.Size = New System.Drawing.Size(100, 20)
        Me.SampleDimensionTextBox.TabIndex = 20
        '
        'Sample_net_weightTextBox
        '
        Me.Sample_net_weightTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Select_SampleInfoBindingSource, "Sample_net_weight", True))
        Me.Sample_net_weightTextBox.Location = New System.Drawing.Point(121, 44)
        Me.Sample_net_weightTextBox.Name = "Sample_net_weightTextBox"
        Me.Sample_net_weightTextBox.Size = New System.Drawing.Size(100, 20)
        Me.Sample_net_weightTextBox.TabIndex = 19
        '
        'btMoveToAnotherOrder
        '
        Me.btMoveToAnotherOrder.Location = New System.Drawing.Point(97, 323)
        Me.btMoveToAnotherOrder.Name = "btMoveToAnotherOrder"
        Me.btMoveToAnotherOrder.Size = New System.Drawing.Size(75, 23)
        Me.btMoveToAnotherOrder.TabIndex = 18
        Me.btMoveToAnotherOrder.Text = "Copy to.."
        Me.btMoveToAnotherOrder.UseVisualStyleBackColor = True
        '
        'btRemoveSampleFromOrder
        '
        Me.btRemoveSampleFromOrder.Location = New System.Drawing.Point(182, 323)
        Me.btRemoveSampleFromOrder.Name = "btRemoveSampleFromOrder"
        Me.btRemoveSampleFromOrder.Size = New System.Drawing.Size(75, 23)
        Me.btRemoveSampleFromOrder.TabIndex = 17
        Me.btRemoveSampleFromOrder.Text = "Delete"
        Me.btRemoveSampleFromOrder.UseVisualStyleBackColor = True
        '
        'btAddSampleToOrder
        '
        Me.btAddSampleToOrder.Location = New System.Drawing.Point(7, 323)
        Me.btAddSampleToOrder.Name = "btAddSampleToOrder"
        Me.btAddSampleToOrder.Size = New System.Drawing.Size(75, 23)
        Me.btAddSampleToOrder.TabIndex = 16
        Me.btAddSampleToOrder.Text = "Add"
        Me.btAddSampleToOrder.UseVisualStyleBackColor = True
        '
        'SampleCheckOutCheckBox
        '
        Me.SampleCheckOutCheckBox.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.SamplesAndOrdersBindingSource, "CheckoutFlag", True))
        Me.SampleCheckOutCheckBox.Location = New System.Drawing.Point(153, 279)
        Me.SampleCheckOutCheckBox.Name = "SampleCheckOutCheckBox"
        Me.SampleCheckOutCheckBox.Size = New System.Drawing.Size(91, 24)
        Me.SampleCheckOutCheckBox.TabIndex = 12
        Me.SampleCheckOutCheckBox.Text = "Check Out"
        Me.SampleCheckOutCheckBox.UseVisualStyleBackColor = True
        '
        'SampleConfirmFlagCheckBox
        '
        Me.SampleConfirmFlagCheckBox.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.SamplesAndOrdersBindingSource, "ConfirmFlag", True))
        Me.SampleConfirmFlagCheckBox.Location = New System.Drawing.Point(153, 165)
        Me.SampleConfirmFlagCheckBox.Name = "SampleConfirmFlagCheckBox"
        Me.SampleConfirmFlagCheckBox.Size = New System.Drawing.Size(104, 24)
        Me.SampleConfirmFlagCheckBox.TabIndex = 10
        Me.SampleConfirmFlagCheckBox.Text = "Confirm"
        Me.SampleConfirmFlagCheckBox.UseVisualStyleBackColor = True
        '
        'GbSampleConfirmPrices
        '
        Me.GbSampleConfirmPrices.Controls.Add(Me.LabelUSDspl3)
        Me.GbSampleConfirmPrices.Controls.Add(Me.LabelUSDspl2)
        Me.GbSampleConfirmPrices.Controls.Add(Label1)
        Me.GbSampleConfirmPrices.Controls.Add(Me.SampleConfirmShippingPriceTextBox)
        Me.GbSampleConfirmPrices.Controls.Add(ConfirmPriceLabel)
        Me.GbSampleConfirmPrices.Controls.Add(Me.SampleConfirmPriceTextBox)
        Me.GbSampleConfirmPrices.Location = New System.Drawing.Point(153, 195)
        Me.GbSampleConfirmPrices.Name = "GbSampleConfirmPrices"
        Me.GbSampleConfirmPrices.Size = New System.Drawing.Size(262, 78)
        Me.GbSampleConfirmPrices.TabIndex = 9
        Me.GbSampleConfirmPrices.TabStop = False
        Me.GbSampleConfirmPrices.Text = "Confirm prices"
        '
        'LabelUSDspl3
        '
        Me.LabelUSDspl3.AutoSize = True
        Me.LabelUSDspl3.Location = New System.Drawing.Point(217, 48)
        Me.LabelUSDspl3.Name = "LabelUSDspl3"
        Me.LabelUSDspl3.Size = New System.Drawing.Size(39, 13)
        Me.LabelUSDspl3.TabIndex = 8
        Me.LabelUSDspl3.Text = "Label3"
        '
        'LabelUSDspl2
        '
        Me.LabelUSDspl2.AutoSize = True
        Me.LabelUSDspl2.Location = New System.Drawing.Point(217, 22)
        Me.LabelUSDspl2.Name = "LabelUSDspl2"
        Me.LabelUSDspl2.Size = New System.Drawing.Size(39, 13)
        Me.LabelUSDspl2.TabIndex = 7
        Me.LabelUSDspl2.Text = "Label3"
        '
        'SampleConfirmShippingPriceTextBox
        '
        Me.SampleConfirmShippingPriceTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.SamplesAndOrdersBindingSource, "ConfirmShippingPrice", True))
        Me.SampleConfirmShippingPriceTextBox.Location = New System.Drawing.Point(134, 45)
        Me.SampleConfirmShippingPriceTextBox.Name = "SampleConfirmShippingPriceTextBox"
        Me.SampleConfirmShippingPriceTextBox.Size = New System.Drawing.Size(79, 20)
        Me.SampleConfirmShippingPriceTextBox.TabIndex = 3
        '
        'SampleConfirmPriceTextBox
        '
        Me.SampleConfirmPriceTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.SamplesAndOrdersBindingSource, "ConfirmPrice", True))
        Me.SampleConfirmPriceTextBox.Location = New System.Drawing.Point(124, 19)
        Me.SampleConfirmPriceTextBox.Name = "SampleConfirmPriceTextBox"
        Me.SampleConfirmPriceTextBox.Size = New System.Drawing.Size(89, 20)
        Me.SampleConfirmPriceTextBox.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.LabelUSDspl1)
        Me.GroupBox1.Controls.Add(Me.SampleFreeShippingFlag)
        Me.GroupBox1.Controls.Add(DiscountLabel)
        Me.GroupBox1.Controls.Add(Me.SampleDiscountTextBox)
        Me.GroupBox1.Controls.Add(PriceLabel)
        Me.GroupBox1.Controls.Add(Me.SamplePriceTextBox)
        Me.GroupBox1.Location = New System.Drawing.Point(153, 58)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(202, 102)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Start prices"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(155, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(15, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "%"
        '
        'LabelUSDspl1
        '
        Me.LabelUSDspl1.AutoSize = True
        Me.LabelUSDspl1.Location = New System.Drawing.Point(156, 20)
        Me.LabelUSDspl1.Name = "LabelUSDspl1"
        Me.LabelUSDspl1.Size = New System.Drawing.Size(39, 13)
        Me.LabelUSDspl1.TabIndex = 6
        Me.LabelUSDspl1.Text = "Label3"
        '
        'SampleFreeShippingFlag
        '
        Me.SampleFreeShippingFlag.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.SamplesAndOrdersBindingSource, "FreeShippingFlag", True))
        Me.SampleFreeShippingFlag.Location = New System.Drawing.Point(45, 71)
        Me.SampleFreeShippingFlag.Name = "SampleFreeShippingFlag"
        Me.SampleFreeShippingFlag.Size = New System.Drawing.Size(104, 24)
        Me.SampleFreeShippingFlag.TabIndex = 5
        Me.SampleFreeShippingFlag.Text = "Free shipping"
        Me.SampleFreeShippingFlag.UseVisualStyleBackColor = True
        '
        'SampleDiscountTextBox
        '
        Me.SampleDiscountTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.SamplesAndOrdersBindingSource, "Discount", True))
        Me.SampleDiscountTextBox.Location = New System.Drawing.Point(102, 45)
        Me.SampleDiscountTextBox.Name = "SampleDiscountTextBox"
        Me.SampleDiscountTextBox.Size = New System.Drawing.Size(47, 20)
        Me.SampleDiscountTextBox.TabIndex = 3
        '
        'SamplePriceTextBox
        '
        Me.SamplePriceTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.SamplesAndOrdersBindingSource, "Price", True))
        Me.SamplePriceTextBox.Location = New System.Drawing.Point(49, 19)
        Me.SamplePriceTextBox.Name = "SamplePriceTextBox"
        Me.SamplePriceTextBox.Size = New System.Drawing.Size(100, 20)
        Me.SamplePriceTextBox.TabIndex = 1
        '
        'SampleRateOfExchangeTextBox
        '
        Me.SampleRateOfExchangeTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.SamplesAndOrdersBindingSource, "RateOfExchange", True))
        Me.SampleRateOfExchangeTextBox.Location = New System.Drawing.Point(254, 32)
        Me.SampleRateOfExchangeTextBox.Name = "SampleRateOfExchangeTextBox"
        Me.SampleRateOfExchangeTextBox.Size = New System.Drawing.Size(64, 20)
        Me.SampleRateOfExchangeTextBox.TabIndex = 5
        '
        'SampleCurrencyNameComboBox
        '
        Me.SampleCurrencyNameComboBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.SamplesAndOrdersBindingSource, "CurrencyName", True))
        Me.SampleCurrencyNameComboBox.FormattingEnabled = True
        Me.SampleCurrencyNameComboBox.Location = New System.Drawing.Point(255, 5)
        Me.SampleCurrencyNameComboBox.Name = "SampleCurrencyNameComboBox"
        Me.SampleCurrencyNameComboBox.Size = New System.Drawing.Size(63, 21)
        Me.SampleCurrencyNameComboBox.TabIndex = 3
        '
        'SampleNumberListBox
        '
        Me.SampleNumberListBox.DataSource = Me.Select_AllSamplesInOrders_tb_SamplesAndOrdersBindingSource
        Me.SampleNumberListBox.DisplayMember = "SampleNumber"
        Me.SampleNumberListBox.FormattingEnabled = True
        Me.SampleNumberListBox.Location = New System.Drawing.Point(7, 26)
        Me.SampleNumberListBox.Name = "SampleNumberListBox"
        Me.SampleNumberListBox.Size = New System.Drawing.Size(125, 290)
        Me.SampleNumberListBox.TabIndex = 1
        Me.SampleNumberListBox.ValueMember = "SampleNumber"
        '
        'ImageListSampleImages
        '
        Me.ImageListSampleImages.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
        Me.ImageListSampleImages.ImageSize = New System.Drawing.Size(16, 16)
        Me.ImageListSampleImages.TransparentColor = System.Drawing.Color.Transparent
        '
        'btRefreshOrder
        '
        Me.btRefreshOrder.Location = New System.Drawing.Point(197, 2)
        Me.btRefreshOrder.Name = "btRefreshOrder"
        Me.btRefreshOrder.Size = New System.Drawing.Size(106, 23)
        Me.btRefreshOrder.TabIndex = 30
        Me.btRefreshOrder.Text = "Refresh.."
        Me.btRefreshOrder.UseVisualStyleBackColor = True
        '
        'SelectFossilInfoTableAdapter
        '
        Me.SelectFossilInfoTableAdapter.ClearBeforeFill = True
        '
        'SamplesINOrdersTableAdapter
        '
        Me.SamplesINOrdersTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager_dsSampleInOrder
        '
        Me.TableAdapterManager_dsSampleInOrder.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager_dsSampleInOrder.SamplesINOrdersTableAdapter = Me.SamplesINOrdersTableAdapter
        Me.TableAdapterManager_dsSampleInOrder.UpdateOrder = OrdersAndClients.dsSampleInOrderTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'DataTable_SampleInfoBindingSource
        '
        Me.DataTable_SampleInfoBindingSource.DataMember = "DataTable_SampleInfo"
        Me.DataTable_SampleInfoBindingSource.DataSource = Me.DsSampleInOrder
        '
        'DataTable_SampleInfoTableAdapter
        '
        Me.DataTable_SampleInfoTableAdapter.ClearBeforeFill = True
        '
        'fmOrders
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(882, 474)
        Me.Controls.Add(Me.btRefreshOrder)
        Me.Controls.Add(Me.main_TabControl)
        Me.Controls.Add(OrderIDLabel)
        Me.Controls.Add(Me.tbOrderID)
        Me.Name = "fmOrders"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Orders"
        CType(Me.Select_tb_OrdersBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsOrders, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SelectClientstbClientsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsService, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Select_OrdersForClientBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Select_SampleInfoBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SamplesAndOrdersBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Select_AllSamplesInOrders_tb_SamplesAndOrdersBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.main_TabControl.ResumeLayout(False)
        Me.TabPage_OrderInfo.ResumeLayout(False)
        Me.TabPage_OrderInfo.PerformLayout()
        CType(Me.Select_OrdersForClientDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GbConfirmPrices.ResumeLayout(False)
        Me.GbConfirmPrices.PerformLayout()
        Me.GbStartPrices.ResumeLayout(False)
        Me.GbStartPrices.PerformLayout()
        Me.tbpgSamples.ResumeLayout(False)
        Me.tbpgSamples.PerformLayout()
        CType(Me.pbSampleImage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dgv_SamplesINOrders, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SamplesINOrdersBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsSampleInOrder, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage_XMLOrder.ResumeLayout(False)
        Me.TabPage_XMLOrder.PerformLayout()
        Me.Preview_TabControl.ResumeLayout(False)
        Me.PreviewHTML_TabPage.ResumeLayout(False)
        Me.PreviewTXT_TabPage.ResumeLayout(False)
        Me.PreviewXML_TabPage.ResumeLayout(False)
        Me.TabPage_SamplesInOrder.ResumeLayout(False)
        Me.TabPage_SamplesInOrder.PerformLayout()
        Me.TabControlSampleData.ResumeLayout(False)
        Me.TabPageImages.ResumeLayout(False)
        Me.TabPageData.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SelectFossilInfoBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GbSampleData.ResumeLayout(False)
        Me.GbSampleData.PerformLayout()
        Me.GbSampleConfirmPrices.ResumeLayout(False)
        Me.GbSampleConfirmPrices.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DataTable_SampleInfoBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DsOrders As OrdersAndClients.dsOrders
    'Friend WithEvents OrdersBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Select_tb_OrdersTableAdapter As OrdersAndClients.dsOrdersTableAdapters.OrdersTableAdapter
    Friend WithEvents TableAdapterManager As OrdersAndClients.dsOrdersTableAdapters.TableAdapterManager
    Friend WithEvents tbOrderID As System.Windows.Forms.TextBox
    Friend WithEvents ClientIDComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents main_TabControl As System.Windows.Forms.TabControl
    Friend WithEvents TabPage_OrderInfo As System.Windows.Forms.TabPage
    Friend WithEvents OrderCheckoutFlagCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents OrderConfirmStockOutFlagCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents GbConfirmPrices As System.Windows.Forms.GroupBox
    Friend WithEvents OrderConfirmShippingPriceTextBox As System.Windows.Forms.TextBox
    Friend WithEvents OrderConfirmTotalOrderPriceTextBox As System.Windows.Forms.TextBox
    Friend WithEvents GbStartPrices As System.Windows.Forms.GroupBox
    Friend WithEvents OrderFreeShippingFlagCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents OrderShippingPriceTextBox As System.Windows.Forms.TextBox
    Friend WithEvents OrderTotalPriceTextBox As System.Windows.Forms.TextBox
    Friend WithEvents btNewClient As System.Windows.Forms.Button
    Friend WithEvents OrderRateOfExchangeTextBox As System.Windows.Forms.TextBox
    Friend WithEvents OrderCurrencyNameComboBoxOrder As System.Windows.Forms.ComboBox
    Friend WithEvents TabPage_SamplesInOrder As System.Windows.Forms.TabPage
    Friend WithEvents TabPage_XMLOrder As System.Windows.Forms.TabPage
    Friend WithEvents OrderInfoPaperRichTextBox As System.Windows.Forms.RichTextBox
    Friend WithEvents btSaveOrder As System.Windows.Forms.Button
    Friend WithEvents btCancelOrder As System.Windows.Forms.Button
    Friend WithEvents DsService As OrdersAndClients.dsService
    Friend WithEvents SelectClientstbClientsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Select_Clients_tb_ClientsTableAdapter As OrdersAndClients.dsServiceTableAdapters.Select_Clients_tb_ClientsTableAdapter
    Friend WithEvents Select_tb_OrdersBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents OrderCancellationFlagCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents Select_AllSamplesInOrders_tb_SamplesAndOrdersBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Select_AllSamplesInOrders_tb_SamplesAndOrdersTableAdapter As OrdersAndClients.dsServiceTableAdapters.Select_AllSamplesInOrders_tb_SamplesAndOrdersTableAdapter
    Friend WithEvents SampleNumberListBox As System.Windows.Forms.ListBox
    Friend WithEvents SamplesAndOrdersBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SamplesAndOrdersTableAdapter As OrdersAndClients.dsOrdersTableAdapters.SamplesAndOrdersTableAdapter
    Friend WithEvents SampleRateOfExchangeTextBox As System.Windows.Forms.TextBox
    Friend WithEvents SampleCurrencyNameComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents SampleFreeShippingFlag As System.Windows.Forms.CheckBox
    Friend WithEvents SampleDiscountTextBox As System.Windows.Forms.TextBox
    Friend WithEvents SamplePriceTextBox As System.Windows.Forms.TextBox
    Friend WithEvents GbSampleConfirmPrices As System.Windows.Forms.GroupBox
    Friend WithEvents SampleConfirmShippingPriceTextBox As System.Windows.Forms.TextBox
    Friend WithEvents SampleConfirmPriceTextBox As System.Windows.Forms.TextBox
    Friend WithEvents SampleConfirmFlagCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents SampleCheckOutCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents ListViewSampleImages As System.Windows.Forms.ListView
    Friend WithEvents btMoveToAnotherOrder As System.Windows.Forms.Button
    Friend WithEvents btRemoveSampleFromOrder As System.Windows.Forms.Button
    Friend WithEvents btAddSampleToOrder As System.Windows.Forms.Button
    Friend WithEvents ImageListSampleImages As System.Windows.Forms.ImageList
    Friend WithEvents Select_SampleInfoBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Select_SampleInfoTableAdapter As OrdersAndClients.dsServiceTableAdapters.Select_SampleInfoTableAdapter
    Friend WithEvents Sample_net_weightTextBox As System.Windows.Forms.TextBox
    Friend WithEvents TabControlSampleData As System.Windows.Forms.TabControl
    Friend WithEvents TabPageImages As System.Windows.Forms.TabPage
    Friend WithEvents TabPageData As System.Windows.Forms.TabPage
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents FossilNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FossilfullnameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FossilDimensionDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GbSampleData As System.Windows.Forms.GroupBox
    Friend WithEvents Fossil_countTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Sample_main_speciesTextBox As System.Windows.Forms.TextBox
    Friend WithEvents SampleDimensionTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Select_OrdersForClientBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Select_OrdersForClientTableAdapter As OrdersAndClients.dsServiceTableAdapters.Select_OrdersForClientTableAdapter
    Friend WithEvents Select_OrdersForClientDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents btCopyText As System.Windows.Forms.Button
    Friend WithEvents btCreateXML As System.Windows.Forms.Button
    Friend WithEvents LabelUSD4 As System.Windows.Forms.Label
    Friend WithEvents LabelUSD3 As System.Windows.Forms.Label
    Friend WithEvents LabelUSD2 As System.Windows.Forms.Label
    Friend WithEvents LabelUSD1 As System.Windows.Forms.Label
    Friend WithEvents LabelUSDspl3 As System.Windows.Forms.Label
    Friend WithEvents LabelUSDspl2 As System.Windows.Forms.Label
    Friend WithEvents LabelUSDspl1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents BtCancelSample As System.Windows.Forms.Button
    Friend WithEvents btSaveSample As System.Windows.Forms.Button
    Friend WithEvents OrderCancellationDateTextBox As System.Windows.Forms.TextBox
    Friend WithEvents OrderCheckoutDateTextBox As System.Windows.Forms.TextBox
    Friend WithEvents OrderConfirmStockOutDateTextBox As System.Windows.Forms.TextBox
    Friend WithEvents OrderExpierensDateTextBox As System.Windows.Forms.TextBox
    Friend WithEvents OrderDateTextBox As System.Windows.Forms.TextBox
    Friend WithEvents SampleCheckoutDateTextBox As System.Windows.Forms.TextBox
    Friend WithEvents btShowImages As System.Windows.Forms.Button
    Friend WithEvents btCalculateOrder As System.Windows.Forms.Button
    Friend WithEvents Preview_TabControl As System.Windows.Forms.TabControl
    Friend WithEvents PreviewHTML_TabPage As System.Windows.Forms.TabPage
    Friend WithEvents OrderHTML_WebBrowser As System.Windows.Forms.WebBrowser
    Friend WithEvents PreviewXML_TabPage As System.Windows.Forms.TabPage
    Friend WithEvents PreviewTXT_TabPage As System.Windows.Forms.TabPage
    Friend WithEvents OrderText_RichTextBox As System.Windows.Forms.RichTextBox
    Friend WithEvents btRefreshOrder As System.Windows.Forms.Button
    Friend WithEvents tbpgSamples As System.Windows.Forms.TabPage
    Friend WithEvents SelectFossilInfoBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SelectFossilInfoTableAdapter As OrdersAndClients.dsServiceTableAdapters.SelectFossilInfoTableAdapter
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FossilheightDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DsSampleInOrder As OrdersAndClients.dsSampleInOrder
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn1 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn2 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btCancelChanges As System.Windows.Forms.Button
    Friend WithEvents btSaveChanges As System.Windows.Forms.Button
    Friend WithEvents btCopySample As System.Windows.Forms.Button
    Friend WithEvents btDeleteSample As System.Windows.Forms.Button
    Friend WithEvents SamplesINOrdersBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SamplesINOrdersTableAdapter As OrdersAndClients.dsSampleInOrderTableAdapters.SamplesINOrdersTableAdapter
    Friend WithEvents TableAdapterManager_dsSampleInOrder As OrdersAndClients.dsSampleInOrderTableAdapters.TableAdapterManager
    Friend WithEvents Dgv_SamplesINOrders As System.Windows.Forms.DataGridView
    Friend WithEvents btSampleInfo As System.Windows.Forms.Button
    Friend WithEvents btImagesForm As System.Windows.Forms.Button
    Friend WithEvents pbSampleImage As System.Windows.Forms.PictureBox
    Friend WithEvents lbCountNewRowInSample As System.Windows.Forms.Label
    Friend WithEvents cbTypeOfCatalog As System.Windows.Forms.ComboBox
    Friend WithEvents tbMainFossilSize As System.Windows.Forms.TextBox
    Friend WithEvents tbMainFossilName As System.Windows.Forms.TextBox
    Friend WithEvents DataTable_SampleInfoBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DataTable_SampleInfoTableAdapter As OrdersAndClients.dsSampleInOrderTableAdapters.DataTable_SampleInfoTableAdapter
    Friend WithEvents btShowInBrowser As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents btSampleOnSale As System.Windows.Forms.Button
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn3 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn4 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn16 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn5 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn17 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OrderID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cbxRefreshImages As System.Windows.Forms.CheckBox
    Friend WithEvents cbxDelExists As System.Windows.Forms.CheckBox
End Class
