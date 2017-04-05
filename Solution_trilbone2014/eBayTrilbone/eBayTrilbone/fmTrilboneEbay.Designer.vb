<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fmTrilboneEbay
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
        Dim BuyerMessageLabel As System.Windows.Forms.Label
        Dim EmailLabel As System.Windows.Forms.Label
        Dim UserIDLabel As System.Windows.Forms.Label
        Dim UserFirstNameLabel As System.Windows.Forms.Label
        Dim UserLastNameLabel As System.Windows.Forms.Label
        Dim NameLabel As System.Windows.Forms.Label
        Dim FirstNameLabel As System.Windows.Forms.Label
        Dim LastNameLabel As System.Windows.Forms.Label
        Dim StreetLabel As System.Windows.Forms.Label
        Dim Street1Label As System.Windows.Forms.Label
        Dim Street2Label As System.Windows.Forms.Label
        Dim PostalCodeLabel As System.Windows.Forms.Label
        Dim CityNameLabel As System.Windows.Forms.Label
        Dim StateOrProvinceLabel As System.Windows.Forms.Label
        Dim CountryNameLabel As System.Windows.Forms.Label
        Dim PhoneLabel As System.Windows.Forms.Label
        Dim Phone2Label As System.Windows.Forms.Label
        Dim SKULabel As System.Windows.Forms.Label
        Dim ValueLabel As System.Windows.Forms.Label
        Dim ValueLabel1 As System.Windows.Forms.Label
        Dim ValueLabel2 As System.Windows.Forms.Label
        Dim ValueLabel3 As System.Windows.Forms.Label
        Dim PayPalEmailAddressLabel As System.Windows.Forms.Label
        Dim PaidTimeLabel As System.Windows.Forms.Label
        Dim CreatedDateLabel As System.Windows.Forms.Label
        Dim ValueLabel4 As System.Windows.Forms.Label
        Dim Label4 As System.Windows.Forms.Label
        Dim CityLabel As System.Windows.Forms.Label
        Dim CountryLabel As System.Windows.Forms.Label
        Dim NameLabel1 As System.Windows.Forms.Label
        Dim PhoneLabel1 As System.Windows.Forms.Label
        Dim PostIndexLabel As System.Windows.Forms.Label
        Dim StateLabel As System.Windows.Forms.Label
        Dim StreetLabel1 As System.Windows.Forms.Label
        Dim Label8 As System.Windows.Forms.Label
        Me.cbAccount = New System.Windows.Forms.ComboBox()
        Me.btReadAccounts = New System.Windows.Forms.Button()
        Me.btGetTransaction = New System.Windows.Forms.Button()
        Me.lblItemsList = New System.Windows.Forms.ListBox()
        Me.TransactionTypeBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.tbctlMain = New System.Windows.Forms.TabControl()
        Me.tpAddress = New System.Windows.Forms.TabPage()
        Me.tbctlAddressExternal = New System.Windows.Forms.TabControl()
        Me.tpAddressEbay = New System.Windows.Forms.TabPage()
        Me.Street1TextBox = New System.Windows.Forms.TextBox()
        Me.NameTextBox = New System.Windows.Forms.TextBox()
        Me.btBuildAddress = New System.Windows.Forms.Button()
        Me.FirstNameTextBox = New System.Windows.Forms.TextBox()
        Me.Phone2TextBox = New System.Windows.Forms.TextBox()
        Me.LastNameTextBox = New System.Windows.Forms.TextBox()
        Me.StreetTextBox = New System.Windows.Forms.TextBox()
        Me.PhoneTextBox = New System.Windows.Forms.TextBox()
        Me.CountryNameTextBox = New System.Windows.Forms.TextBox()
        Me.Street2TextBox = New System.Windows.Forms.TextBox()
        Me.StateOrProvinceTextBox = New System.Windows.Forms.TextBox()
        Me.PostalCodeTextBox = New System.Windows.Forms.TextBox()
        Me.CityNameTextBox = New System.Windows.Forms.TextBox()
        Me.tbAddressPayPal = New System.Windows.Forms.TabPage()
        Me.cbAddressIsCorrect = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.NameTextBox1 = New System.Windows.Forms.TextBox()
        Me.IMoySkladDataProvider_AddressBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PhoneTextBox1 = New System.Windows.Forms.TextBox()
        Me.CountryTextBox = New System.Windows.Forms.TextBox()
        Me.CityTextBox = New System.Windows.Forms.TextBox()
        Me.StreetTextBox1 = New System.Windows.Forms.TextBox()
        Me.PostIndexTextBox = New System.Windows.Forms.TextBox()
        Me.StateTextBox = New System.Windows.Forms.TextBox()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.tpPayPalInfo = New System.Windows.Forms.TabPage()
        Me.btLeaveFeedback = New System.Windows.Forms.Button()
        Me.tbfeedback = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.lbPaymentUUID = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.rtbPaymentComment = New System.Windows.Forms.RichTextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.rtbPaymentPurpose = New System.Windows.Forms.RichTextBox()
        Me.btCreateIncomingPayment = New System.Windows.Forms.Button()
        Me.ExternalTransactionDataGridView = New System.Windows.Forms.DataGridView()
        Me.AmountPaidDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AdjustmentAmountDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ConvertedAdjustmentAmountDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BuyerDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ShippingDetailsDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ConvertedAmountPaidDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ConvertedTransactionPriceDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CreatedDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CreatedDateSpecifiedDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DepositTypeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DepositTypeSpecifiedDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ItemDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.QuantityPurchasedDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.QuantityPurchasedSpecifiedDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.StatusDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TransactionIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TransactionPriceDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BestOfferSaleDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.BestOfferSaleSpecifiedDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.VATPercentDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VATPercentSpecifiedDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.SellingManagerProductDetailsDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ShippingServiceSelectedDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BuyerMessageDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DutchAuctionBidDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BuyerPaidStatusDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BuyerPaidStatusSpecifiedDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.SellerPaidStatusDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SellerPaidStatusSpecifiedDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.PaidTimeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PaidTimeSpecifiedDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ShippedTimeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ShippedTimeSpecifiedDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.TotalPriceDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FeedbackLeftDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FeedbackReceivedDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ContainingOrderDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FinalValueFeeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ListingCheckoutRedirectPreferenceDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TransactionSiteIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TransactionSiteIDSpecifiedDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.PlatformDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PlatformSpecifiedDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.CartIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SellerContactBuyerByEmailDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.SellerContactBuyerByEmailSpecifiedDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.PayPalEmailAddressDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PaisaPayIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BuyerGuaranteePriceDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VariationDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BuyerCheckoutMessageDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TaxesDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BundlePurchaseDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.BundlePurchaseSpecifiedDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ActualShippingCostDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ActualHandlingCostDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OrderLineItemIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PaymentHoldDetailsDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SellerDiscountsDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RefundAmountDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RefundStatusDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodiceFiscaleDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IsMultiLegShippingDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.IsMultiLegShippingSpecifiedDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.MultiLegShippingDetailsDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InvoiceSentTimeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InvoiceSentTimeSpecifiedDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.UnpaidItemDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IntangibleItemDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.IntangibleItemSpecifiedDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.MonetaryDetailsDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PickupDetailsDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PickupMethodSelectedDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ShippingConvenienceChargeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LogisticsPlanTypeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BuyerPackageEnclosuresDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InventoryReservationIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ExtendedOrderIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ExternalTransactionBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PayPalEmailAddressTextBox = New System.Windows.Forms.TextBox()
        Me.tpUser = New System.Windows.Forms.TabPage()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.lbClientInterest = New System.Windows.Forms.ListBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.rtbClientComment = New System.Windows.Forms.RichTextBox()
        Me.rtbClientInterestDetails = New System.Windows.Forms.RichTextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btCreateClient = New System.Windows.Forms.Button()
        Me.lbClientTags = New System.Windows.Forms.ListBox()
        Me.btSearchClientByFullName = New System.Windows.Forms.Button()
        Me.lbCustomers = New System.Windows.Forms.ListBox()
        Me.lbUserSearchStatus = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbFullName = New System.Windows.Forms.TextBox()
        Me.UserLastNameTextBox = New System.Windows.Forms.TextBox()
        Me.UserFirstNameTextBox = New System.Windows.Forms.TextBox()
        Me.UserIDTextBox = New System.Windows.Forms.TextBox()
        Me.EmailTextBox = New System.Windows.Forms.TextBox()
        Me.tpGoodInfoFromMC = New System.Windows.Forms.TabPage()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lbShipWokerUUID = New System.Windows.Forms.Label()
        Me.lbWokers = New System.Windows.Forms.ListBox()
        Me.lbDemandUUID = New System.Windows.Forms.Label()
        Me.lbOrderUUID = New System.Windows.Forms.Label()
        Me.lbGoodUUID = New System.Windows.Forms.Label()
        Me.btCreateMCBulk = New System.Windows.Forms.Button()
        Me.btSendParcel = New System.Windows.Forms.Button()
        Me.tpInDBTrilbone = New System.Windows.Forms.TabPage()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.tbCalcTotalPerOne = New System.Windows.Forms.TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.btPersonCalc = New System.Windows.Forms.Button()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.tbPersonCount = New System.Windows.Forms.TextBox()
        Me.btGetResorceFee = New System.Windows.Forms.Button()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.tbCalcTotal = New System.Windows.Forms.TextBox()
        Me.btTotal = New System.Windows.Forms.Button()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.tbSubTotal = New System.Windows.Forms.TextBox()
        Me.btSubTotal = New System.Windows.Forms.Button()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.tbFullAmount = New System.Windows.Forms.TextBox()
        Me.btWeightCalculate = New System.Windows.Forms.Button()
        Me.btMoneyOutCalculate = New System.Windows.Forms.Button()
        Me.btTrilboneCalculate = New System.Windows.Forms.Button()
        Me.btNalogCalculate = New System.Windows.Forms.Button()
        Me.tbTrilboneBase = New System.Windows.Forms.TextBox()
        Me.tbNalogBase = New System.Windows.Forms.TextBox()
        Me.tbMoneyOutBase = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.tbTrilboneTax = New System.Windows.Forms.TextBox()
        Me.tbNalogTax = New System.Windows.Forms.TextBox()
        Me.tbWeightTax = New System.Windows.Forms.TextBox()
        Me.tbWeight = New System.Windows.Forms.TextBox()
        Me.tbMoneyOutTax = New System.Windows.Forms.TextBox()
        Me.btWeightQuery = New System.Windows.Forms.Button()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.btGetFullAmount = New System.Windows.Forms.Button()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.btShipmentOutFee = New System.Windows.Forms.Button()
        Me.tbTrilboneFee = New System.Windows.Forms.TextBox()
        Me.tbNalogFee = New System.Windows.Forms.TextBox()
        Me.tbShipmentOutFee = New System.Windows.Forms.TextBox()
        Me.tbExportFee = New System.Windows.Forms.TextBox()
        Me.tbInsectionFee = New System.Windows.Forms.TextBox()
        Me.tbMoneyOutFee = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.btSaveInDb = New System.Windows.Forms.Button()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.BuyerMessageRichTextBox = New System.Windows.Forms.RichTextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lbShipped = New System.Windows.Forms.Label()
        Me.lbPaid = New System.Windows.Forms.Label()
        Me.CurrencyIDTextBox4 = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.ValueTextBox4 = New System.Windows.Forms.TextBox()
        Me.TitleTextBox = New System.Windows.Forms.TextBox()
        Me.CurrencyIDTextBox3 = New System.Windows.Forms.TextBox()
        Me.ValueTextBox3 = New System.Windows.Forms.TextBox()
        Me.CurrencyIDTextBox2 = New System.Windows.Forms.TextBox()
        Me.ValueTextBox2 = New System.Windows.Forms.TextBox()
        Me.CurrencyIDTextBox1 = New System.Windows.Forms.TextBox()
        Me.ValueTextBox1 = New System.Windows.Forms.TextBox()
        Me.CurrencyIDTextBox = New System.Windows.Forms.TextBox()
        Me.ValueTextBox = New System.Windows.Forms.TextBox()
        Me.SKUTextBox = New System.Windows.Forms.TextBox()
        Me.tbTotal = New System.Windows.Forms.TextBox()
        Me.tbFeePayPalCurrency = New System.Windows.Forms.TextBox()
        Me.tbPayPalFeeAmount = New System.Windows.Forms.TextBox()
        Me.btLoadMC = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        BuyerMessageLabel = New System.Windows.Forms.Label()
        EmailLabel = New System.Windows.Forms.Label()
        UserIDLabel = New System.Windows.Forms.Label()
        UserFirstNameLabel = New System.Windows.Forms.Label()
        UserLastNameLabel = New System.Windows.Forms.Label()
        NameLabel = New System.Windows.Forms.Label()
        FirstNameLabel = New System.Windows.Forms.Label()
        LastNameLabel = New System.Windows.Forms.Label()
        StreetLabel = New System.Windows.Forms.Label()
        Street1Label = New System.Windows.Forms.Label()
        Street2Label = New System.Windows.Forms.Label()
        PostalCodeLabel = New System.Windows.Forms.Label()
        CityNameLabel = New System.Windows.Forms.Label()
        StateOrProvinceLabel = New System.Windows.Forms.Label()
        CountryNameLabel = New System.Windows.Forms.Label()
        PhoneLabel = New System.Windows.Forms.Label()
        Phone2Label = New System.Windows.Forms.Label()
        SKULabel = New System.Windows.Forms.Label()
        ValueLabel = New System.Windows.Forms.Label()
        ValueLabel1 = New System.Windows.Forms.Label()
        ValueLabel2 = New System.Windows.Forms.Label()
        ValueLabel3 = New System.Windows.Forms.Label()
        PayPalEmailAddressLabel = New System.Windows.Forms.Label()
        PaidTimeLabel = New System.Windows.Forms.Label()
        CreatedDateLabel = New System.Windows.Forms.Label()
        ValueLabel4 = New System.Windows.Forms.Label()
        Label4 = New System.Windows.Forms.Label()
        CityLabel = New System.Windows.Forms.Label()
        CountryLabel = New System.Windows.Forms.Label()
        NameLabel1 = New System.Windows.Forms.Label()
        PhoneLabel1 = New System.Windows.Forms.Label()
        PostIndexLabel = New System.Windows.Forms.Label()
        StateLabel = New System.Windows.Forms.Label()
        StreetLabel1 = New System.Windows.Forms.Label()
        Label8 = New System.Windows.Forms.Label()
        CType(Me.TransactionTypeBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbctlMain.SuspendLayout()
        Me.tpAddress.SuspendLayout()
        Me.tbctlAddressExternal.SuspendLayout()
        Me.tpAddressEbay.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.IMoySkladDataProvider_AddressBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpPayPalInfo.SuspendLayout()
        CType(Me.ExternalTransactionDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ExternalTransactionBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpUser.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.tpGoodInfoFromMC.SuspendLayout()
        Me.tpInDBTrilbone.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'BuyerMessageLabel
        '
        BuyerMessageLabel.AutoSize = True
        BuyerMessageLabel.Location = New System.Drawing.Point(17, 336)
        BuyerMessageLabel.Name = "BuyerMessageLabel"
        BuyerMessageLabel.Size = New System.Drawing.Size(83, 13)
        BuyerMessageLabel.TabIndex = 0
        BuyerMessageLabel.Text = "Buyer Message:"
        '
        'EmailLabel
        '
        EmailLabel.AutoSize = True
        EmailLabel.Location = New System.Drawing.Point(58, 22)
        EmailLabel.Name = "EmailLabel"
        EmailLabel.Size = New System.Drawing.Size(35, 13)
        EmailLabel.TabIndex = 2
        EmailLabel.Text = "Email:"
        '
        'UserIDLabel
        '
        UserIDLabel.AutoSize = True
        UserIDLabel.Location = New System.Drawing.Point(195, 54)
        UserIDLabel.Name = "UserIDLabel"
        UserIDLabel.Size = New System.Drawing.Size(46, 13)
        UserIDLabel.TabIndex = 4
        UserIDLabel.Text = "User ID:"
        '
        'UserFirstNameLabel
        '
        UserFirstNameLabel.AutoSize = True
        UserFirstNameLabel.Location = New System.Drawing.Point(28, 88)
        UserFirstNameLabel.Name = "UserFirstNameLabel"
        UserFirstNameLabel.Size = New System.Drawing.Size(85, 13)
        UserFirstNameLabel.TabIndex = 6
        UserFirstNameLabel.Text = "User First Name:"
        '
        'UserLastNameLabel
        '
        UserLastNameLabel.AutoSize = True
        UserLastNameLabel.Location = New System.Drawing.Point(27, 123)
        UserLastNameLabel.Name = "UserLastNameLabel"
        UserLastNameLabel.Size = New System.Drawing.Size(86, 13)
        UserLastNameLabel.TabIndex = 8
        UserLastNameLabel.Text = "User Last Name:"
        '
        'NameLabel
        '
        NameLabel.AutoSize = True
        NameLabel.Location = New System.Drawing.Point(29, 7)
        NameLabel.Name = "NameLabel"
        NameLabel.Size = New System.Drawing.Size(38, 13)
        NameLabel.TabIndex = 0
        NameLabel.Text = "Name:"
        '
        'FirstNameLabel
        '
        FirstNameLabel.AutoSize = True
        FirstNameLabel.Location = New System.Drawing.Point(7, 33)
        FirstNameLabel.Name = "FirstNameLabel"
        FirstNameLabel.Size = New System.Drawing.Size(60, 13)
        FirstNameLabel.TabIndex = 2
        FirstNameLabel.Text = "First Name:"
        '
        'LastNameLabel
        '
        LastNameLabel.AutoSize = True
        LastNameLabel.Location = New System.Drawing.Point(6, 59)
        LastNameLabel.Name = "LastNameLabel"
        LastNameLabel.Size = New System.Drawing.Size(61, 13)
        LastNameLabel.TabIndex = 4
        LastNameLabel.Text = "Last Name:"
        '
        'StreetLabel
        '
        StreetLabel.AutoSize = True
        StreetLabel.Location = New System.Drawing.Point(57, 90)
        StreetLabel.Name = "StreetLabel"
        StreetLabel.Size = New System.Drawing.Size(38, 13)
        StreetLabel.TabIndex = 6
        StreetLabel.Text = "Street:"
        '
        'Street1Label
        '
        Street1Label.AutoSize = True
        Street1Label.Location = New System.Drawing.Point(51, 116)
        Street1Label.Name = "Street1Label"
        Street1Label.Size = New System.Drawing.Size(44, 13)
        Street1Label.TabIndex = 8
        Street1Label.Text = "Street1:"
        '
        'Street2Label
        '
        Street2Label.AutoSize = True
        Street2Label.Location = New System.Drawing.Point(51, 142)
        Street2Label.Name = "Street2Label"
        Street2Label.Size = New System.Drawing.Size(44, 13)
        Street2Label.TabIndex = 10
        Street2Label.Text = "Street2:"
        '
        'PostalCodeLabel
        '
        PostalCodeLabel.AutoSize = True
        PostalCodeLabel.Location = New System.Drawing.Point(74, 173)
        PostalCodeLabel.Name = "PostalCodeLabel"
        PostalCodeLabel.Size = New System.Drawing.Size(67, 13)
        PostalCodeLabel.TabIndex = 12
        PostalCodeLabel.Text = "Postal Code:"
        '
        'CityNameLabel
        '
        CityNameLabel.AutoSize = True
        CityNameLabel.Location = New System.Drawing.Point(83, 199)
        CityNameLabel.Name = "CityNameLabel"
        CityNameLabel.Size = New System.Drawing.Size(58, 13)
        CityNameLabel.TabIndex = 14
        CityNameLabel.Text = "City Name:"
        '
        'StateOrProvinceLabel
        '
        StateOrProvinceLabel.AutoSize = True
        StateOrProvinceLabel.Location = New System.Drawing.Point(79, 230)
        StateOrProvinceLabel.Name = "StateOrProvinceLabel"
        StateOrProvinceLabel.Size = New System.Drawing.Size(94, 13)
        StateOrProvinceLabel.TabIndex = 16
        StateOrProvinceLabel.Text = "State Or Province:"
        '
        'CountryNameLabel
        '
        CountryNameLabel.AutoSize = True
        CountryNameLabel.Location = New System.Drawing.Point(96, 256)
        CountryNameLabel.Name = "CountryNameLabel"
        CountryNameLabel.Size = New System.Drawing.Size(77, 13)
        CountryNameLabel.TabIndex = 18
        CountryNameLabel.Text = "Country Name:"
        '
        'PhoneLabel
        '
        PhoneLabel.AutoSize = True
        PhoneLabel.Location = New System.Drawing.Point(67, 287)
        PhoneLabel.Name = "PhoneLabel"
        PhoneLabel.Size = New System.Drawing.Size(41, 13)
        PhoneLabel.TabIndex = 20
        PhoneLabel.Text = "Phone:"
        '
        'Phone2Label
        '
        Phone2Label.AutoSize = True
        Phone2Label.Location = New System.Drawing.Point(61, 315)
        Phone2Label.Name = "Phone2Label"
        Phone2Label.Size = New System.Drawing.Size(47, 13)
        Phone2Label.TabIndex = 22
        Phone2Label.Text = "Phone2:"
        '
        'SKULabel
        '
        SKULabel.AutoSize = True
        SKULabel.Location = New System.Drawing.Point(35, 163)
        SKULabel.Name = "SKULabel"
        SKULabel.Size = New System.Drawing.Size(98, 13)
        SKULabel.TabIndex = 8
        SKULabel.Text = "Custom(SKU) label:"
        '
        'ValueLabel
        '
        ValueLabel.AutoSize = True
        ValueLabel.Location = New System.Drawing.Point(42, 195)
        ValueLabel.Name = "ValueLabel"
        ValueLabel.Size = New System.Drawing.Size(87, 13)
        ValueLabel.TabIndex = 11
        ValueLabel.Text = "Всего к оплате:"
        '
        'ValueLabel1
        '
        ValueLabel1.AutoSize = True
        ValueLabel1.Location = New System.Drawing.Point(70, 220)
        ValueLabel1.Name = "ValueLabel1"
        ValueLabel1.Size = New System.Drawing.Size(63, 13)
        ValueLabel1.TabIndex = 14
        ValueLabel1.Text = "Сам товар:"
        '
        'ValueLabel2
        '
        ValueLabel2.AutoSize = True
        ValueLabel2.Location = New System.Drawing.Point(79, 246)
        ValueLabel2.Name = "ValueLabel2"
        ValueLabel2.Size = New System.Drawing.Size(54, 13)
        ValueLabel2.TabIndex = 17
        ValueLabel2.Text = "Шиппинг:"
        '
        'ValueLabel3
        '
        ValueLabel3.AutoSize = True
        ValueLabel3.Location = New System.Drawing.Point(68, 272)
        ValueLabel3.Name = "ValueLabel3"
        ValueLabel3.Size = New System.Drawing.Size(65, 13)
        ValueLabel3.TabIndex = 20
        ValueLabel3.Text = "Обработка:"
        '
        'PayPalEmailAddressLabel
        '
        PayPalEmailAddressLabel.AutoSize = True
        PayPalEmailAddressLabel.Location = New System.Drawing.Point(16, 154)
        PayPalEmailAddressLabel.Name = "PayPalEmailAddressLabel"
        PayPalEmailAddressLabel.Size = New System.Drawing.Size(115, 13)
        PayPalEmailAddressLabel.TabIndex = 21
        PayPalEmailAddressLabel.Text = "Pay Pal Email Address:"
        '
        'PaidTimeLabel
        '
        PaidTimeLabel.AutoSize = True
        PaidTimeLabel.Location = New System.Drawing.Point(48, 181)
        PaidTimeLabel.Name = "PaidTimeLabel"
        PaidTimeLabel.Size = New System.Drawing.Size(82, 13)
        PaidTimeLabel.TabIndex = 22
        PaidTimeLabel.Text = "Дата платежа:"
        '
        'CreatedDateLabel
        '
        CreatedDateLabel.AutoSize = True
        CreatedDateLabel.Location = New System.Drawing.Point(45, 81)
        CreatedDateLabel.Name = "CreatedDateLabel"
        CreatedDateLabel.Size = New System.Drawing.Size(73, 13)
        CreatedDateLabel.TabIndex = 10
        CreatedDateLabel.Text = "Created Date:"
        '
        'ValueLabel4
        '
        ValueLabel4.AutoSize = True
        ValueLabel4.Location = New System.Drawing.Point(78, 298)
        ValueLabel4.Name = "ValueLabel4"
        ValueLabel4.Size = New System.Drawing.Size(55, 13)
        ValueLabel4.TabIndex = 24
        ValueLabel4.Text = "Fee eBay:"
        '
        'Label4
        '
        Label4.AutoSize = True
        Label4.Location = New System.Drawing.Point(54, 26)
        Label4.Name = "Label4"
        Label4.Size = New System.Drawing.Size(64, 13)
        Label4.TabIndex = 27
        Label4.Text = "Fee PayPal:"
        '
        'CityLabel
        '
        CityLabel.AutoSize = True
        CityLabel.Location = New System.Drawing.Point(12, 107)
        CityLabel.Name = "CityLabel"
        CityLabel.Size = New System.Drawing.Size(40, 13)
        CityLabel.TabIndex = 25
        CityLabel.Text = "Город:"
        '
        'CountryLabel
        '
        CountryLabel.AutoSize = True
        CountryLabel.Location = New System.Drawing.Point(6, 163)
        CountryLabel.Name = "CountryLabel"
        CountryLabel.Size = New System.Drawing.Size(46, 13)
        CountryLabel.TabIndex = 27
        CountryLabel.Text = "Страна:"
        '
        'NameLabel1
        '
        NameLabel1.AutoSize = True
        NameLabel1.Location = New System.Drawing.Point(20, 23)
        NameLabel1.Name = "NameLabel1"
        NameLabel1.Size = New System.Drawing.Size(32, 13)
        NameLabel1.TabIndex = 31
        NameLabel1.Text = "Имя:"
        '
        'PhoneLabel1
        '
        PhoneLabel1.AutoSize = True
        PhoneLabel1.Location = New System.Drawing.Point(11, 191)
        PhoneLabel1.Name = "PhoneLabel1"
        PhoneLabel1.Size = New System.Drawing.Size(41, 13)
        PhoneLabel1.TabIndex = 33
        PhoneLabel1.Text = "Phone:"
        '
        'PostIndexLabel
        '
        PostIndexLabel.AutoSize = True
        PostIndexLabel.Location = New System.Drawing.Point(4, 135)
        PostIndexLabel.Name = "PostIndexLabel"
        PostIndexLabel.Size = New System.Drawing.Size(48, 13)
        PostIndexLabel.TabIndex = 35
        PostIndexLabel.Text = "Индекс:"
        '
        'StateLabel
        '
        StateLabel.AutoSize = True
        StateLabel.Location = New System.Drawing.Point(5, 79)
        StateLabel.Name = "StateLabel"
        StateLabel.Size = New System.Drawing.Size(52, 13)
        StateLabel.TabIndex = 37
        StateLabel.Text = "Волость:"
        '
        'StreetLabel1
        '
        StreetLabel1.AutoSize = True
        StreetLabel1.Location = New System.Drawing.Point(10, 51)
        StreetLabel1.Name = "StreetLabel1"
        StreetLabel1.Size = New System.Drawing.Size(42, 13)
        StreetLabel1.TabIndex = 39
        StreetLabel1.Text = "Улица:"
        '
        'Label8
        '
        Label8.AutoSize = True
        Label8.Location = New System.Drawing.Point(54, 61)
        Label8.Name = "Label8"
        Label8.Size = New System.Drawing.Size(47, 13)
        Label8.TabIndex = 30
        Label8.Text = "Баланс:"
        '
        'cbAccount
        '
        Me.cbAccount.FormattingEnabled = True
        Me.cbAccount.Location = New System.Drawing.Point(121, 12)
        Me.cbAccount.Name = "cbAccount"
        Me.cbAccount.Size = New System.Drawing.Size(194, 21)
        Me.cbAccount.TabIndex = 1
        '
        'btReadAccounts
        '
        Me.btReadAccounts.Location = New System.Drawing.Point(25, 10)
        Me.btReadAccounts.Name = "btReadAccounts"
        Me.btReadAccounts.Size = New System.Drawing.Size(75, 23)
        Me.btReadAccounts.TabIndex = 2
        Me.btReadAccounts.Text = "Аккаунты"
        Me.btReadAccounts.UseVisualStyleBackColor = True
        '
        'btGetTransaction
        '
        Me.btGetTransaction.Location = New System.Drawing.Point(334, 9)
        Me.btGetTransaction.Name = "btGetTransaction"
        Me.btGetTransaction.Size = New System.Drawing.Size(95, 48)
        Me.btGetTransaction.TabIndex = 3
        Me.btGetTransaction.Text = "Текущие образцы"
        Me.btGetTransaction.UseVisualStyleBackColor = True
        '
        'lblItemsList
        '
        Me.lblItemsList.DataSource = Me.TransactionTypeBindingSource
        Me.lblItemsList.DisplayMember = "Title"
        Me.lblItemsList.FormattingEnabled = True
        Me.lblItemsList.Location = New System.Drawing.Point(435, 9)
        Me.lblItemsList.Name = "lblItemsList"
        Me.lblItemsList.Size = New System.Drawing.Size(447, 69)
        Me.lblItemsList.TabIndex = 4
        Me.lblItemsList.ValueMember = "Transaction"
        '
        'TransactionTypeBindingSource
        '
        Me.TransactionTypeBindingSource.AllowNew = False
        Me.TransactionTypeBindingSource.DataSource = GetType(clsTransactionItem)
        '
        'tbctlMain
        '
        Me.tbctlMain.Controls.Add(Me.tpAddress)
        Me.tbctlMain.Controls.Add(Me.tpPayPalInfo)
        Me.tbctlMain.Controls.Add(Me.tpUser)
        Me.tbctlMain.Controls.Add(Me.tpGoodInfoFromMC)
        Me.tbctlMain.Controls.Add(Me.tpInDBTrilbone)
        Me.tbctlMain.Controls.Add(Me.TabPage1)
        Me.tbctlMain.Location = New System.Drawing.Point(12, 86)
        Me.tbctlMain.Name = "tbctlMain"
        Me.tbctlMain.SelectedIndex = 0
        Me.tbctlMain.Size = New System.Drawing.Size(874, 525)
        Me.tbctlMain.TabIndex = 5
        '
        'tpAddress
        '
        Me.tpAddress.AutoScroll = True
        Me.tpAddress.Controls.Add(Me.tbctlAddressExternal)
        Me.tpAddress.Controls.Add(Me.cbAddressIsCorrect)
        Me.tpAddress.Controls.Add(Me.GroupBox2)
        Me.tpAddress.Controls.Add(Me.RichTextBox1)
        Me.tpAddress.Location = New System.Drawing.Point(4, 22)
        Me.tpAddress.Name = "tpAddress"
        Me.tpAddress.Padding = New System.Windows.Forms.Padding(3)
        Me.tpAddress.Size = New System.Drawing.Size(866, 499)
        Me.tpAddress.TabIndex = 1
        Me.tpAddress.Text = "Шиппинг Адрес"
        Me.tpAddress.UseVisualStyleBackColor = True
        '
        'tbctlAddressExternal
        '
        Me.tbctlAddressExternal.Controls.Add(Me.tpAddressEbay)
        Me.tbctlAddressExternal.Controls.Add(Me.tbAddressPayPal)
        Me.tbctlAddressExternal.Location = New System.Drawing.Point(6, 11)
        Me.tbctlAddressExternal.Name = "tbctlAddressExternal"
        Me.tbctlAddressExternal.SelectedIndex = 0
        Me.tbctlAddressExternal.Size = New System.Drawing.Size(481, 387)
        Me.tbctlAddressExternal.TabIndex = 43
        '
        'tpAddressEbay
        '
        Me.tpAddressEbay.Controls.Add(Me.Street1TextBox)
        Me.tpAddressEbay.Controls.Add(Me.NameTextBox)
        Me.tpAddressEbay.Controls.Add(NameLabel)
        Me.tpAddressEbay.Controls.Add(Me.btBuildAddress)
        Me.tpAddressEbay.Controls.Add(Phone2Label)
        Me.tpAddressEbay.Controls.Add(Me.FirstNameTextBox)
        Me.tpAddressEbay.Controls.Add(FirstNameLabel)
        Me.tpAddressEbay.Controls.Add(Me.Phone2TextBox)
        Me.tpAddressEbay.Controls.Add(Me.LastNameTextBox)
        Me.tpAddressEbay.Controls.Add(LastNameLabel)
        Me.tpAddressEbay.Controls.Add(PhoneLabel)
        Me.tpAddressEbay.Controls.Add(Me.StreetTextBox)
        Me.tpAddressEbay.Controls.Add(Me.PhoneTextBox)
        Me.tpAddressEbay.Controls.Add(StreetLabel)
        Me.tpAddressEbay.Controls.Add(CountryNameLabel)
        Me.tpAddressEbay.Controls.Add(Street1Label)
        Me.tpAddressEbay.Controls.Add(Me.CountryNameTextBox)
        Me.tpAddressEbay.Controls.Add(Me.Street2TextBox)
        Me.tpAddressEbay.Controls.Add(StateOrProvinceLabel)
        Me.tpAddressEbay.Controls.Add(Street2Label)
        Me.tpAddressEbay.Controls.Add(Me.StateOrProvinceTextBox)
        Me.tpAddressEbay.Controls.Add(Me.PostalCodeTextBox)
        Me.tpAddressEbay.Controls.Add(CityNameLabel)
        Me.tpAddressEbay.Controls.Add(PostalCodeLabel)
        Me.tpAddressEbay.Controls.Add(Me.CityNameTextBox)
        Me.tpAddressEbay.Location = New System.Drawing.Point(4, 22)
        Me.tpAddressEbay.Name = "tpAddressEbay"
        Me.tpAddressEbay.Padding = New System.Windows.Forms.Padding(3)
        Me.tpAddressEbay.Size = New System.Drawing.Size(473, 361)
        Me.tpAddressEbay.TabIndex = 0
        Me.tpAddressEbay.Text = "Адрес eBay"
        Me.tpAddressEbay.UseVisualStyleBackColor = True
        '
        'Street1TextBox
        '
        Me.Street1TextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TransactionTypeBindingSource, "Buyer.BuyerInfo.ShippingAddress.Street1", True, System.Windows.Forms.DataSourceUpdateMode.OnValidation, "нет"))
        Me.Street1TextBox.Location = New System.Drawing.Point(101, 113)
        Me.Street1TextBox.Name = "Street1TextBox"
        Me.Street1TextBox.Size = New System.Drawing.Size(266, 20)
        Me.Street1TextBox.TabIndex = 9
        '
        'NameTextBox
        '
        Me.NameTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TransactionTypeBindingSource, "Buyer.BuyerInfo.ShippingAddress.Name", True, System.Windows.Forms.DataSourceUpdateMode.OnValidation, "нет"))
        Me.NameTextBox.Location = New System.Drawing.Point(73, 5)
        Me.NameTextBox.Name = "NameTextBox"
        Me.NameTextBox.Size = New System.Drawing.Size(396, 20)
        Me.NameTextBox.TabIndex = 1
        '
        'btBuildAddress
        '
        Me.btBuildAddress.Location = New System.Drawing.Point(382, 262)
        Me.btBuildAddress.Name = "btBuildAddress"
        Me.btBuildAddress.Size = New System.Drawing.Size(75, 72)
        Me.btBuildAddress.TabIndex = 7
        Me.btBuildAddress.Text = " Собрать" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " адрес >>>"
        Me.btBuildAddress.UseVisualStyleBackColor = True
        '
        'FirstNameTextBox
        '
        Me.FirstNameTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TransactionTypeBindingSource, "Buyer.BuyerInfo.ShippingAddress.FirstName", True, System.Windows.Forms.DataSourceUpdateMode.OnValidation, "нет"))
        Me.FirstNameTextBox.Location = New System.Drawing.Point(73, 27)
        Me.FirstNameTextBox.Name = "FirstNameTextBox"
        Me.FirstNameTextBox.Size = New System.Drawing.Size(249, 20)
        Me.FirstNameTextBox.TabIndex = 3
        '
        'Phone2TextBox
        '
        Me.Phone2TextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TransactionTypeBindingSource, "Buyer.ShippingAddress.Phone2", True, System.Windows.Forms.DataSourceUpdateMode.OnValidation, "нет"))
        Me.Phone2TextBox.Location = New System.Drawing.Point(114, 312)
        Me.Phone2TextBox.Name = "Phone2TextBox"
        Me.Phone2TextBox.Size = New System.Drawing.Size(246, 20)
        Me.Phone2TextBox.TabIndex = 23
        '
        'LastNameTextBox
        '
        Me.LastNameTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TransactionTypeBindingSource, "Buyer.BuyerInfo.ShippingAddress.LastName", True, System.Windows.Forms.DataSourceUpdateMode.OnValidation, "нет"))
        Me.LastNameTextBox.Location = New System.Drawing.Point(73, 53)
        Me.LastNameTextBox.Name = "LastNameTextBox"
        Me.LastNameTextBox.Size = New System.Drawing.Size(249, 20)
        Me.LastNameTextBox.TabIndex = 5
        '
        'StreetTextBox
        '
        Me.StreetTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TransactionTypeBindingSource, "Buyer.BuyerInfo.ShippingAddress.Street", True, System.Windows.Forms.DataSourceUpdateMode.OnValidation, "нет"))
        Me.StreetTextBox.Location = New System.Drawing.Point(101, 87)
        Me.StreetTextBox.Name = "StreetTextBox"
        Me.StreetTextBox.Size = New System.Drawing.Size(266, 20)
        Me.StreetTextBox.TabIndex = 7
        '
        'PhoneTextBox
        '
        Me.PhoneTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TransactionTypeBindingSource, "Buyer.ShippingAddress.Phone", True, System.Windows.Forms.DataSourceUpdateMode.OnValidation, "нет"))
        Me.PhoneTextBox.Location = New System.Drawing.Point(114, 289)
        Me.PhoneTextBox.Name = "PhoneTextBox"
        Me.PhoneTextBox.Size = New System.Drawing.Size(246, 20)
        Me.PhoneTextBox.TabIndex = 21
        '
        'CountryNameTextBox
        '
        Me.CountryNameTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TransactionTypeBindingSource, "Buyer.BuyerInfo.ShippingAddress.CountryName", True, System.Windows.Forms.DataSourceUpdateMode.OnValidation, "нет"))
        Me.CountryNameTextBox.Location = New System.Drawing.Point(179, 254)
        Me.CountryNameTextBox.Name = "CountryNameTextBox"
        Me.CountryNameTextBox.Size = New System.Drawing.Size(181, 20)
        Me.CountryNameTextBox.TabIndex = 19
        '
        'Street2TextBox
        '
        Me.Street2TextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TransactionTypeBindingSource, "Buyer.BuyerInfo.ShippingAddress.Street2", True, System.Windows.Forms.DataSourceUpdateMode.OnValidation, "нет"))
        Me.Street2TextBox.Location = New System.Drawing.Point(101, 139)
        Me.Street2TextBox.Name = "Street2TextBox"
        Me.Street2TextBox.Size = New System.Drawing.Size(266, 20)
        Me.Street2TextBox.TabIndex = 11
        '
        'StateOrProvinceTextBox
        '
        Me.StateOrProvinceTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TransactionTypeBindingSource, "Buyer.BuyerInfo.ShippingAddress.StateOrProvince", True, System.Windows.Forms.DataSourceUpdateMode.OnValidation, "нет"))
        Me.StateOrProvinceTextBox.Location = New System.Drawing.Point(179, 228)
        Me.StateOrProvinceTextBox.Name = "StateOrProvinceTextBox"
        Me.StateOrProvinceTextBox.Size = New System.Drawing.Size(181, 20)
        Me.StateOrProvinceTextBox.TabIndex = 17
        '
        'PostalCodeTextBox
        '
        Me.PostalCodeTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TransactionTypeBindingSource, "Buyer.BuyerInfo.ShippingAddress.PostalCode", True, System.Windows.Forms.DataSourceUpdateMode.OnValidation, "нет"))
        Me.PostalCodeTextBox.Location = New System.Drawing.Point(147, 169)
        Me.PostalCodeTextBox.Name = "PostalCodeTextBox"
        Me.PostalCodeTextBox.Size = New System.Drawing.Size(160, 20)
        Me.PostalCodeTextBox.TabIndex = 13
        '
        'CityNameTextBox
        '
        Me.CityNameTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TransactionTypeBindingSource, "Buyer.BuyerInfo.ShippingAddress.CityName", True, System.Windows.Forms.DataSourceUpdateMode.OnValidation, "нет"))
        Me.CityNameTextBox.Location = New System.Drawing.Point(147, 198)
        Me.CityNameTextBox.Name = "CityNameTextBox"
        Me.CityNameTextBox.Size = New System.Drawing.Size(213, 20)
        Me.CityNameTextBox.TabIndex = 15
        '
        'tbAddressPayPal
        '
        Me.tbAddressPayPal.Location = New System.Drawing.Point(4, 22)
        Me.tbAddressPayPal.Name = "tbAddressPayPal"
        Me.tbAddressPayPal.Padding = New System.Windows.Forms.Padding(3)
        Me.tbAddressPayPal.Size = New System.Drawing.Size(473, 361)
        Me.tbAddressPayPal.TabIndex = 1
        Me.tbAddressPayPal.Text = "Адрес PayPal"
        Me.tbAddressPayPal.UseVisualStyleBackColor = True
        '
        'cbAddressIsCorrect
        '
        Me.cbAddressIsCorrect.AutoSize = True
        Me.cbAddressIsCorrect.Location = New System.Drawing.Point(553, 243)
        Me.cbAddressIsCorrect.Name = "cbAddressIsCorrect"
        Me.cbAddressIsCorrect.Size = New System.Drawing.Size(229, 17)
        Me.cbAddressIsCorrect.TabIndex = 42
        Me.cbAddressIsCorrect.Text = "Адрес подтверждаю для внесения в МС"
        Me.cbAddressIsCorrect.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.NameTextBox1)
        Me.GroupBox2.Controls.Add(Me.PhoneTextBox1)
        Me.GroupBox2.Controls.Add(PhoneLabel1)
        Me.GroupBox2.Controls.Add(Me.CountryTextBox)
        Me.GroupBox2.Controls.Add(CountryLabel)
        Me.GroupBox2.Controls.Add(Me.CityTextBox)
        Me.GroupBox2.Controls.Add(CityLabel)
        Me.GroupBox2.Controls.Add(NameLabel1)
        Me.GroupBox2.Controls.Add(Me.StreetTextBox1)
        Me.GroupBox2.Controls.Add(Me.PostIndexTextBox)
        Me.GroupBox2.Controls.Add(PostIndexLabel)
        Me.GroupBox2.Controls.Add(StreetLabel1)
        Me.GroupBox2.Controls.Add(Me.StateTextBox)
        Me.GroupBox2.Controls.Add(StateLabel)
        Me.GroupBox2.Location = New System.Drawing.Point(493, 15)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(367, 219)
        Me.GroupBox2.TabIndex = 41
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "В мой склад"
        '
        'NameTextBox1
        '
        Me.NameTextBox1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.IMoySkladDataProvider_AddressBindingSource, "Name", True))
        Me.NameTextBox1.Location = New System.Drawing.Point(60, 20)
        Me.NameTextBox1.Name = "NameTextBox1"
        Me.NameTextBox1.Size = New System.Drawing.Size(304, 20)
        Me.NameTextBox1.TabIndex = 32
        '
        'IMoySkladDataProvider_AddressBindingSource
        '
        Me.IMoySkladDataProvider_AddressBindingSource.DataSource = GetType(Service.iMoySkladDataProvider.clsAddress)
        '
        'PhoneTextBox1
        '
        Me.PhoneTextBox1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.IMoySkladDataProvider_AddressBindingSource, "Phone", True))
        Me.PhoneTextBox1.Location = New System.Drawing.Point(60, 188)
        Me.PhoneTextBox1.Name = "PhoneTextBox1"
        Me.PhoneTextBox1.Size = New System.Drawing.Size(274, 20)
        Me.PhoneTextBox1.TabIndex = 34
        '
        'CountryTextBox
        '
        Me.CountryTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.IMoySkladDataProvider_AddressBindingSource, "Country", True))
        Me.CountryTextBox.Location = New System.Drawing.Point(60, 160)
        Me.CountryTextBox.Name = "CountryTextBox"
        Me.CountryTextBox.Size = New System.Drawing.Size(249, 20)
        Me.CountryTextBox.TabIndex = 28
        '
        'CityTextBox
        '
        Me.CityTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.IMoySkladDataProvider_AddressBindingSource, "City", True))
        Me.CityTextBox.Location = New System.Drawing.Point(60, 104)
        Me.CityTextBox.Name = "CityTextBox"
        Me.CityTextBox.Size = New System.Drawing.Size(304, 20)
        Me.CityTextBox.TabIndex = 26
        '
        'StreetTextBox1
        '
        Me.StreetTextBox1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.IMoySkladDataProvider_AddressBindingSource, "Street", True))
        Me.StreetTextBox1.Location = New System.Drawing.Point(60, 48)
        Me.StreetTextBox1.Name = "StreetTextBox1"
        Me.StreetTextBox1.Size = New System.Drawing.Size(304, 20)
        Me.StreetTextBox1.TabIndex = 40
        '
        'PostIndexTextBox
        '
        Me.PostIndexTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.IMoySkladDataProvider_AddressBindingSource, "PostIndex", True))
        Me.PostIndexTextBox.Location = New System.Drawing.Point(60, 132)
        Me.PostIndexTextBox.Name = "PostIndexTextBox"
        Me.PostIndexTextBox.Size = New System.Drawing.Size(100, 20)
        Me.PostIndexTextBox.TabIndex = 36
        '
        'StateTextBox
        '
        Me.StateTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.IMoySkladDataProvider_AddressBindingSource, "State", True))
        Me.StateTextBox.Location = New System.Drawing.Point(60, 76)
        Me.StateTextBox.Name = "StateTextBox"
        Me.StateTextBox.Size = New System.Drawing.Size(304, 20)
        Me.StateTextBox.TabIndex = 38
        '
        'RichTextBox1
        '
        Me.RichTextBox1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.IMoySkladDataProvider_AddressBindingSource, "FullAddress", True))
        Me.RichTextBox1.Location = New System.Drawing.Point(496, 268)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(361, 130)
        Me.RichTextBox1.TabIndex = 6
        Me.RichTextBox1.Text = ""
        '
        'tpPayPalInfo
        '
        Me.tpPayPalInfo.Controls.Add(Me.btLeaveFeedback)
        Me.tpPayPalInfo.Controls.Add(Me.tbfeedback)
        Me.tpPayPalInfo.Controls.Add(Me.TextBox2)
        Me.tpPayPalInfo.Controls.Add(Me.lbPaymentUUID)
        Me.tpPayPalInfo.Controls.Add(Me.Label10)
        Me.tpPayPalInfo.Controls.Add(Me.rtbPaymentComment)
        Me.tpPayPalInfo.Controls.Add(Me.Label9)
        Me.tpPayPalInfo.Controls.Add(Me.rtbPaymentPurpose)
        Me.tpPayPalInfo.Controls.Add(Me.btCreateIncomingPayment)
        Me.tpPayPalInfo.Controls.Add(PaidTimeLabel)
        Me.tpPayPalInfo.Controls.Add(Me.ExternalTransactionDataGridView)
        Me.tpPayPalInfo.Controls.Add(PayPalEmailAddressLabel)
        Me.tpPayPalInfo.Controls.Add(Me.PayPalEmailAddressTextBox)
        Me.tpPayPalInfo.Location = New System.Drawing.Point(4, 22)
        Me.tpPayPalInfo.Name = "tpPayPalInfo"
        Me.tpPayPalInfo.Size = New System.Drawing.Size(866, 499)
        Me.tpPayPalInfo.TabIndex = 2
        Me.tpPayPalInfo.Text = "детали PayPal"
        Me.tpPayPalInfo.UseVisualStyleBackColor = True
        '
        'btLeaveFeedback
        '
        Me.btLeaveFeedback.Location = New System.Drawing.Point(386, 145)
        Me.btLeaveFeedback.Name = "btLeaveFeedback"
        Me.btLeaveFeedback.Size = New System.Drawing.Size(134, 23)
        Me.btLeaveFeedback.TabIndex = 35
        Me.btLeaveFeedback.Text = "Leave feedback"
        Me.btLeaveFeedback.UseVisualStyleBackColor = True
        '
        'tbfeedback
        '
        Me.tbfeedback.Location = New System.Drawing.Point(386, 173)
        Me.tbfeedback.Name = "tbfeedback"
        Me.tbfeedback.Size = New System.Drawing.Size(468, 20)
        Me.tbfeedback.TabIndex = 34
        '
        'TextBox2
        '
        Me.TextBox2.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TransactionTypeBindingSource, "PaidTime", True))
        Me.TextBox2.Location = New System.Drawing.Point(137, 178)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(129, 20)
        Me.TextBox2.TabIndex = 30
        '
        'lbPaymentUUID
        '
        Me.lbPaymentUUID.AutoSize = True
        Me.lbPaymentUUID.Location = New System.Drawing.Point(293, 429)
        Me.lbPaymentUUID.Name = "lbPaymentUUID"
        Me.lbPaymentUUID.Size = New System.Drawing.Size(34, 13)
        Me.lbPaymentUUID.TabIndex = 29
        Me.lbPaymentUUID.Text = "UUID"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(342, 271)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(77, 13)
        Me.Label10.TabIndex = 28
        Me.Label10.Text = "Комментарий"
        '
        'rtbPaymentComment
        '
        Me.rtbPaymentComment.Location = New System.Drawing.Point(345, 290)
        Me.rtbPaymentComment.Name = "rtbPaymentComment"
        Me.rtbPaymentComment.Size = New System.Drawing.Size(267, 96)
        Me.rtbPaymentComment.TabIndex = 27
        Me.rtbPaymentComment.Text = ""
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(29, 271)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(109, 13)
        Me.Label9.TabIndex = 26
        Me.Label9.Text = "Основание платежа"
        '
        'rtbPaymentPurpose
        '
        Me.rtbPaymentPurpose.Location = New System.Drawing.Point(32, 290)
        Me.rtbPaymentPurpose.Name = "rtbPaymentPurpose"
        Me.rtbPaymentPurpose.Size = New System.Drawing.Size(267, 96)
        Me.rtbPaymentPurpose.TabIndex = 25
        Me.rtbPaymentPurpose.Text = ""
        '
        'btCreateIncomingPayment
        '
        Me.btCreateIncomingPayment.Location = New System.Drawing.Point(32, 410)
        Me.btCreateIncomingPayment.Name = "btCreateIncomingPayment"
        Me.btCreateIncomingPayment.Size = New System.Drawing.Size(210, 50)
        Me.btCreateIncomingPayment.TabIndex = 24
        Me.btCreateIncomingPayment.Text = "Создать входящий платеж в МС.."
        Me.btCreateIncomingPayment.UseVisualStyleBackColor = True
        '
        'ExternalTransactionDataGridView
        '
        Me.ExternalTransactionDataGridView.AutoGenerateColumns = False
        Me.ExternalTransactionDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ExternalTransactionDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.AmountPaidDataGridViewTextBoxColumn, Me.AdjustmentAmountDataGridViewTextBoxColumn, Me.ConvertedAdjustmentAmountDataGridViewTextBoxColumn, Me.BuyerDataGridViewTextBoxColumn, Me.ShippingDetailsDataGridViewTextBoxColumn, Me.ConvertedAmountPaidDataGridViewTextBoxColumn, Me.ConvertedTransactionPriceDataGridViewTextBoxColumn, Me.CreatedDateDataGridViewTextBoxColumn, Me.CreatedDateSpecifiedDataGridViewCheckBoxColumn, Me.DepositTypeDataGridViewTextBoxColumn, Me.DepositTypeSpecifiedDataGridViewCheckBoxColumn, Me.ItemDataGridViewTextBoxColumn, Me.QuantityPurchasedDataGridViewTextBoxColumn, Me.QuantityPurchasedSpecifiedDataGridViewCheckBoxColumn, Me.StatusDataGridViewTextBoxColumn, Me.TransactionIDDataGridViewTextBoxColumn, Me.TransactionPriceDataGridViewTextBoxColumn, Me.BestOfferSaleDataGridViewCheckBoxColumn, Me.BestOfferSaleSpecifiedDataGridViewCheckBoxColumn, Me.VATPercentDataGridViewTextBoxColumn, Me.VATPercentSpecifiedDataGridViewCheckBoxColumn, Me.SellingManagerProductDetailsDataGridViewTextBoxColumn, Me.ShippingServiceSelectedDataGridViewTextBoxColumn, Me.BuyerMessageDataGridViewTextBoxColumn, Me.DutchAuctionBidDataGridViewTextBoxColumn, Me.BuyerPaidStatusDataGridViewTextBoxColumn, Me.BuyerPaidStatusSpecifiedDataGridViewCheckBoxColumn, Me.SellerPaidStatusDataGridViewTextBoxColumn, Me.SellerPaidStatusSpecifiedDataGridViewCheckBoxColumn, Me.PaidTimeDataGridViewTextBoxColumn, Me.PaidTimeSpecifiedDataGridViewCheckBoxColumn, Me.ShippedTimeDataGridViewTextBoxColumn, Me.ShippedTimeSpecifiedDataGridViewCheckBoxColumn, Me.TotalPriceDataGridViewTextBoxColumn, Me.FeedbackLeftDataGridViewTextBoxColumn, Me.FeedbackReceivedDataGridViewTextBoxColumn, Me.ContainingOrderDataGridViewTextBoxColumn, Me.FinalValueFeeDataGridViewTextBoxColumn, Me.ListingCheckoutRedirectPreferenceDataGridViewTextBoxColumn, Me.TransactionSiteIDDataGridViewTextBoxColumn, Me.TransactionSiteIDSpecifiedDataGridViewCheckBoxColumn, Me.PlatformDataGridViewTextBoxColumn, Me.PlatformSpecifiedDataGridViewCheckBoxColumn, Me.CartIDDataGridViewTextBoxColumn, Me.SellerContactBuyerByEmailDataGridViewCheckBoxColumn, Me.SellerContactBuyerByEmailSpecifiedDataGridViewCheckBoxColumn, Me.PayPalEmailAddressDataGridViewTextBoxColumn, Me.PaisaPayIDDataGridViewTextBoxColumn, Me.BuyerGuaranteePriceDataGridViewTextBoxColumn, Me.VariationDataGridViewTextBoxColumn, Me.BuyerCheckoutMessageDataGridViewTextBoxColumn, Me.TaxesDataGridViewTextBoxColumn, Me.BundlePurchaseDataGridViewCheckBoxColumn, Me.BundlePurchaseSpecifiedDataGridViewCheckBoxColumn, Me.ActualShippingCostDataGridViewTextBoxColumn, Me.ActualHandlingCostDataGridViewTextBoxColumn, Me.OrderLineItemIDDataGridViewTextBoxColumn, Me.PaymentHoldDetailsDataGridViewTextBoxColumn, Me.SellerDiscountsDataGridViewTextBoxColumn, Me.RefundAmountDataGridViewTextBoxColumn, Me.RefundStatusDataGridViewTextBoxColumn, Me.CodiceFiscaleDataGridViewTextBoxColumn, Me.IsMultiLegShippingDataGridViewCheckBoxColumn, Me.IsMultiLegShippingSpecifiedDataGridViewCheckBoxColumn, Me.MultiLegShippingDetailsDataGridViewTextBoxColumn, Me.InvoiceSentTimeDataGridViewTextBoxColumn, Me.InvoiceSentTimeSpecifiedDataGridViewCheckBoxColumn, Me.UnpaidItemDataGridViewTextBoxColumn, Me.IntangibleItemDataGridViewCheckBoxColumn, Me.IntangibleItemSpecifiedDataGridViewCheckBoxColumn, Me.MonetaryDetailsDataGridViewTextBoxColumn, Me.PickupDetailsDataGridViewTextBoxColumn, Me.PickupMethodSelectedDataGridViewTextBoxColumn, Me.ShippingConvenienceChargeDataGridViewTextBoxColumn, Me.LogisticsPlanTypeDataGridViewTextBoxColumn, Me.BuyerPackageEnclosuresDataGridViewTextBoxColumn, Me.InventoryReservationIDDataGridViewTextBoxColumn, Me.ExtendedOrderIDDataGridViewTextBoxColumn})
        Me.ExternalTransactionDataGridView.DataSource = Me.ExternalTransactionBindingSource
        Me.ExternalTransactionDataGridView.Location = New System.Drawing.Point(9, 7)
        Me.ExternalTransactionDataGridView.Name = "ExternalTransactionDataGridView"
        Me.ExternalTransactionDataGridView.Size = New System.Drawing.Size(854, 128)
        Me.ExternalTransactionDataGridView.TabIndex = 23
        '
        'AmountPaidDataGridViewTextBoxColumn
        '
        Me.AmountPaidDataGridViewTextBoxColumn.DataPropertyName = "AmountPaid"
        Me.AmountPaidDataGridViewTextBoxColumn.HeaderText = "AmountPaid"
        Me.AmountPaidDataGridViewTextBoxColumn.Name = "AmountPaidDataGridViewTextBoxColumn"
        '
        'AdjustmentAmountDataGridViewTextBoxColumn
        '
        Me.AdjustmentAmountDataGridViewTextBoxColumn.DataPropertyName = "AdjustmentAmount"
        Me.AdjustmentAmountDataGridViewTextBoxColumn.HeaderText = "AdjustmentAmount"
        Me.AdjustmentAmountDataGridViewTextBoxColumn.Name = "AdjustmentAmountDataGridViewTextBoxColumn"
        '
        'ConvertedAdjustmentAmountDataGridViewTextBoxColumn
        '
        Me.ConvertedAdjustmentAmountDataGridViewTextBoxColumn.DataPropertyName = "ConvertedAdjustmentAmount"
        Me.ConvertedAdjustmentAmountDataGridViewTextBoxColumn.HeaderText = "ConvertedAdjustmentAmount"
        Me.ConvertedAdjustmentAmountDataGridViewTextBoxColumn.Name = "ConvertedAdjustmentAmountDataGridViewTextBoxColumn"
        '
        'BuyerDataGridViewTextBoxColumn
        '
        Me.BuyerDataGridViewTextBoxColumn.DataPropertyName = "Buyer"
        Me.BuyerDataGridViewTextBoxColumn.HeaderText = "Buyer"
        Me.BuyerDataGridViewTextBoxColumn.Name = "BuyerDataGridViewTextBoxColumn"
        '
        'ShippingDetailsDataGridViewTextBoxColumn
        '
        Me.ShippingDetailsDataGridViewTextBoxColumn.DataPropertyName = "ShippingDetails"
        Me.ShippingDetailsDataGridViewTextBoxColumn.HeaderText = "ShippingDetails"
        Me.ShippingDetailsDataGridViewTextBoxColumn.Name = "ShippingDetailsDataGridViewTextBoxColumn"
        '
        'ConvertedAmountPaidDataGridViewTextBoxColumn
        '
        Me.ConvertedAmountPaidDataGridViewTextBoxColumn.DataPropertyName = "ConvertedAmountPaid"
        Me.ConvertedAmountPaidDataGridViewTextBoxColumn.HeaderText = "ConvertedAmountPaid"
        Me.ConvertedAmountPaidDataGridViewTextBoxColumn.Name = "ConvertedAmountPaidDataGridViewTextBoxColumn"
        '
        'ConvertedTransactionPriceDataGridViewTextBoxColumn
        '
        Me.ConvertedTransactionPriceDataGridViewTextBoxColumn.DataPropertyName = "ConvertedTransactionPrice"
        Me.ConvertedTransactionPriceDataGridViewTextBoxColumn.HeaderText = "ConvertedTransactionPrice"
        Me.ConvertedTransactionPriceDataGridViewTextBoxColumn.Name = "ConvertedTransactionPriceDataGridViewTextBoxColumn"
        '
        'CreatedDateDataGridViewTextBoxColumn
        '
        Me.CreatedDateDataGridViewTextBoxColumn.DataPropertyName = "CreatedDate"
        Me.CreatedDateDataGridViewTextBoxColumn.HeaderText = "CreatedDate"
        Me.CreatedDateDataGridViewTextBoxColumn.Name = "CreatedDateDataGridViewTextBoxColumn"
        '
        'CreatedDateSpecifiedDataGridViewCheckBoxColumn
        '
        Me.CreatedDateSpecifiedDataGridViewCheckBoxColumn.DataPropertyName = "CreatedDateSpecified"
        Me.CreatedDateSpecifiedDataGridViewCheckBoxColumn.HeaderText = "CreatedDateSpecified"
        Me.CreatedDateSpecifiedDataGridViewCheckBoxColumn.Name = "CreatedDateSpecifiedDataGridViewCheckBoxColumn"
        '
        'DepositTypeDataGridViewTextBoxColumn
        '
        Me.DepositTypeDataGridViewTextBoxColumn.DataPropertyName = "DepositType"
        Me.DepositTypeDataGridViewTextBoxColumn.HeaderText = "DepositType"
        Me.DepositTypeDataGridViewTextBoxColumn.Name = "DepositTypeDataGridViewTextBoxColumn"
        '
        'DepositTypeSpecifiedDataGridViewCheckBoxColumn
        '
        Me.DepositTypeSpecifiedDataGridViewCheckBoxColumn.DataPropertyName = "DepositTypeSpecified"
        Me.DepositTypeSpecifiedDataGridViewCheckBoxColumn.HeaderText = "DepositTypeSpecified"
        Me.DepositTypeSpecifiedDataGridViewCheckBoxColumn.Name = "DepositTypeSpecifiedDataGridViewCheckBoxColumn"
        '
        'ItemDataGridViewTextBoxColumn
        '
        Me.ItemDataGridViewTextBoxColumn.DataPropertyName = "Item"
        Me.ItemDataGridViewTextBoxColumn.HeaderText = "Item"
        Me.ItemDataGridViewTextBoxColumn.Name = "ItemDataGridViewTextBoxColumn"
        '
        'QuantityPurchasedDataGridViewTextBoxColumn
        '
        Me.QuantityPurchasedDataGridViewTextBoxColumn.DataPropertyName = "QuantityPurchased"
        Me.QuantityPurchasedDataGridViewTextBoxColumn.HeaderText = "QuantityPurchased"
        Me.QuantityPurchasedDataGridViewTextBoxColumn.Name = "QuantityPurchasedDataGridViewTextBoxColumn"
        '
        'QuantityPurchasedSpecifiedDataGridViewCheckBoxColumn
        '
        Me.QuantityPurchasedSpecifiedDataGridViewCheckBoxColumn.DataPropertyName = "QuantityPurchasedSpecified"
        Me.QuantityPurchasedSpecifiedDataGridViewCheckBoxColumn.HeaderText = "QuantityPurchasedSpecified"
        Me.QuantityPurchasedSpecifiedDataGridViewCheckBoxColumn.Name = "QuantityPurchasedSpecifiedDataGridViewCheckBoxColumn"
        '
        'StatusDataGridViewTextBoxColumn
        '
        Me.StatusDataGridViewTextBoxColumn.DataPropertyName = "Status"
        Me.StatusDataGridViewTextBoxColumn.HeaderText = "Status"
        Me.StatusDataGridViewTextBoxColumn.Name = "StatusDataGridViewTextBoxColumn"
        '
        'TransactionIDDataGridViewTextBoxColumn
        '
        Me.TransactionIDDataGridViewTextBoxColumn.DataPropertyName = "TransactionID"
        Me.TransactionIDDataGridViewTextBoxColumn.HeaderText = "TransactionID"
        Me.TransactionIDDataGridViewTextBoxColumn.Name = "TransactionIDDataGridViewTextBoxColumn"
        '
        'TransactionPriceDataGridViewTextBoxColumn
        '
        Me.TransactionPriceDataGridViewTextBoxColumn.DataPropertyName = "TransactionPrice"
        Me.TransactionPriceDataGridViewTextBoxColumn.HeaderText = "TransactionPrice"
        Me.TransactionPriceDataGridViewTextBoxColumn.Name = "TransactionPriceDataGridViewTextBoxColumn"
        '
        'BestOfferSaleDataGridViewCheckBoxColumn
        '
        Me.BestOfferSaleDataGridViewCheckBoxColumn.DataPropertyName = "BestOfferSale"
        Me.BestOfferSaleDataGridViewCheckBoxColumn.HeaderText = "BestOfferSale"
        Me.BestOfferSaleDataGridViewCheckBoxColumn.Name = "BestOfferSaleDataGridViewCheckBoxColumn"
        '
        'BestOfferSaleSpecifiedDataGridViewCheckBoxColumn
        '
        Me.BestOfferSaleSpecifiedDataGridViewCheckBoxColumn.DataPropertyName = "BestOfferSaleSpecified"
        Me.BestOfferSaleSpecifiedDataGridViewCheckBoxColumn.HeaderText = "BestOfferSaleSpecified"
        Me.BestOfferSaleSpecifiedDataGridViewCheckBoxColumn.Name = "BestOfferSaleSpecifiedDataGridViewCheckBoxColumn"
        '
        'VATPercentDataGridViewTextBoxColumn
        '
        Me.VATPercentDataGridViewTextBoxColumn.DataPropertyName = "VATPercent"
        Me.VATPercentDataGridViewTextBoxColumn.HeaderText = "VATPercent"
        Me.VATPercentDataGridViewTextBoxColumn.Name = "VATPercentDataGridViewTextBoxColumn"
        '
        'VATPercentSpecifiedDataGridViewCheckBoxColumn
        '
        Me.VATPercentSpecifiedDataGridViewCheckBoxColumn.DataPropertyName = "VATPercentSpecified"
        Me.VATPercentSpecifiedDataGridViewCheckBoxColumn.HeaderText = "VATPercentSpecified"
        Me.VATPercentSpecifiedDataGridViewCheckBoxColumn.Name = "VATPercentSpecifiedDataGridViewCheckBoxColumn"
        '
        'SellingManagerProductDetailsDataGridViewTextBoxColumn
        '
        Me.SellingManagerProductDetailsDataGridViewTextBoxColumn.DataPropertyName = "SellingManagerProductDetails"
        Me.SellingManagerProductDetailsDataGridViewTextBoxColumn.HeaderText = "SellingManagerProductDetails"
        Me.SellingManagerProductDetailsDataGridViewTextBoxColumn.Name = "SellingManagerProductDetailsDataGridViewTextBoxColumn"
        '
        'ShippingServiceSelectedDataGridViewTextBoxColumn
        '
        Me.ShippingServiceSelectedDataGridViewTextBoxColumn.DataPropertyName = "ShippingServiceSelected"
        Me.ShippingServiceSelectedDataGridViewTextBoxColumn.HeaderText = "ShippingServiceSelected"
        Me.ShippingServiceSelectedDataGridViewTextBoxColumn.Name = "ShippingServiceSelectedDataGridViewTextBoxColumn"
        '
        'BuyerMessageDataGridViewTextBoxColumn
        '
        Me.BuyerMessageDataGridViewTextBoxColumn.DataPropertyName = "BuyerMessage"
        Me.BuyerMessageDataGridViewTextBoxColumn.HeaderText = "BuyerMessage"
        Me.BuyerMessageDataGridViewTextBoxColumn.Name = "BuyerMessageDataGridViewTextBoxColumn"
        '
        'DutchAuctionBidDataGridViewTextBoxColumn
        '
        Me.DutchAuctionBidDataGridViewTextBoxColumn.DataPropertyName = "DutchAuctionBid"
        Me.DutchAuctionBidDataGridViewTextBoxColumn.HeaderText = "DutchAuctionBid"
        Me.DutchAuctionBidDataGridViewTextBoxColumn.Name = "DutchAuctionBidDataGridViewTextBoxColumn"
        '
        'BuyerPaidStatusDataGridViewTextBoxColumn
        '
        Me.BuyerPaidStatusDataGridViewTextBoxColumn.DataPropertyName = "BuyerPaidStatus"
        Me.BuyerPaidStatusDataGridViewTextBoxColumn.HeaderText = "BuyerPaidStatus"
        Me.BuyerPaidStatusDataGridViewTextBoxColumn.Name = "BuyerPaidStatusDataGridViewTextBoxColumn"
        '
        'BuyerPaidStatusSpecifiedDataGridViewCheckBoxColumn
        '
        Me.BuyerPaidStatusSpecifiedDataGridViewCheckBoxColumn.DataPropertyName = "BuyerPaidStatusSpecified"
        Me.BuyerPaidStatusSpecifiedDataGridViewCheckBoxColumn.HeaderText = "BuyerPaidStatusSpecified"
        Me.BuyerPaidStatusSpecifiedDataGridViewCheckBoxColumn.Name = "BuyerPaidStatusSpecifiedDataGridViewCheckBoxColumn"
        '
        'SellerPaidStatusDataGridViewTextBoxColumn
        '
        Me.SellerPaidStatusDataGridViewTextBoxColumn.DataPropertyName = "SellerPaidStatus"
        Me.SellerPaidStatusDataGridViewTextBoxColumn.HeaderText = "SellerPaidStatus"
        Me.SellerPaidStatusDataGridViewTextBoxColumn.Name = "SellerPaidStatusDataGridViewTextBoxColumn"
        '
        'SellerPaidStatusSpecifiedDataGridViewCheckBoxColumn
        '
        Me.SellerPaidStatusSpecifiedDataGridViewCheckBoxColumn.DataPropertyName = "SellerPaidStatusSpecified"
        Me.SellerPaidStatusSpecifiedDataGridViewCheckBoxColumn.HeaderText = "SellerPaidStatusSpecified"
        Me.SellerPaidStatusSpecifiedDataGridViewCheckBoxColumn.Name = "SellerPaidStatusSpecifiedDataGridViewCheckBoxColumn"
        '
        'PaidTimeDataGridViewTextBoxColumn
        '
        Me.PaidTimeDataGridViewTextBoxColumn.DataPropertyName = "PaidTime"
        Me.PaidTimeDataGridViewTextBoxColumn.HeaderText = "PaidTime"
        Me.PaidTimeDataGridViewTextBoxColumn.Name = "PaidTimeDataGridViewTextBoxColumn"
        '
        'PaidTimeSpecifiedDataGridViewCheckBoxColumn
        '
        Me.PaidTimeSpecifiedDataGridViewCheckBoxColumn.DataPropertyName = "PaidTimeSpecified"
        Me.PaidTimeSpecifiedDataGridViewCheckBoxColumn.HeaderText = "PaidTimeSpecified"
        Me.PaidTimeSpecifiedDataGridViewCheckBoxColumn.Name = "PaidTimeSpecifiedDataGridViewCheckBoxColumn"
        '
        'ShippedTimeDataGridViewTextBoxColumn
        '
        Me.ShippedTimeDataGridViewTextBoxColumn.DataPropertyName = "ShippedTime"
        Me.ShippedTimeDataGridViewTextBoxColumn.HeaderText = "ShippedTime"
        Me.ShippedTimeDataGridViewTextBoxColumn.Name = "ShippedTimeDataGridViewTextBoxColumn"
        '
        'ShippedTimeSpecifiedDataGridViewCheckBoxColumn
        '
        Me.ShippedTimeSpecifiedDataGridViewCheckBoxColumn.DataPropertyName = "ShippedTimeSpecified"
        Me.ShippedTimeSpecifiedDataGridViewCheckBoxColumn.HeaderText = "ShippedTimeSpecified"
        Me.ShippedTimeSpecifiedDataGridViewCheckBoxColumn.Name = "ShippedTimeSpecifiedDataGridViewCheckBoxColumn"
        '
        'TotalPriceDataGridViewTextBoxColumn
        '
        Me.TotalPriceDataGridViewTextBoxColumn.DataPropertyName = "TotalPrice"
        Me.TotalPriceDataGridViewTextBoxColumn.HeaderText = "TotalPrice"
        Me.TotalPriceDataGridViewTextBoxColumn.Name = "TotalPriceDataGridViewTextBoxColumn"
        '
        'FeedbackLeftDataGridViewTextBoxColumn
        '
        Me.FeedbackLeftDataGridViewTextBoxColumn.DataPropertyName = "FeedbackLeft"
        Me.FeedbackLeftDataGridViewTextBoxColumn.HeaderText = "FeedbackLeft"
        Me.FeedbackLeftDataGridViewTextBoxColumn.Name = "FeedbackLeftDataGridViewTextBoxColumn"
        '
        'FeedbackReceivedDataGridViewTextBoxColumn
        '
        Me.FeedbackReceivedDataGridViewTextBoxColumn.DataPropertyName = "FeedbackReceived"
        Me.FeedbackReceivedDataGridViewTextBoxColumn.HeaderText = "FeedbackReceived"
        Me.FeedbackReceivedDataGridViewTextBoxColumn.Name = "FeedbackReceivedDataGridViewTextBoxColumn"
        '
        'ContainingOrderDataGridViewTextBoxColumn
        '
        Me.ContainingOrderDataGridViewTextBoxColumn.DataPropertyName = "ContainingOrder"
        Me.ContainingOrderDataGridViewTextBoxColumn.HeaderText = "ContainingOrder"
        Me.ContainingOrderDataGridViewTextBoxColumn.Name = "ContainingOrderDataGridViewTextBoxColumn"
        '
        'FinalValueFeeDataGridViewTextBoxColumn
        '
        Me.FinalValueFeeDataGridViewTextBoxColumn.DataPropertyName = "FinalValueFee"
        Me.FinalValueFeeDataGridViewTextBoxColumn.HeaderText = "FinalValueFee"
        Me.FinalValueFeeDataGridViewTextBoxColumn.Name = "FinalValueFeeDataGridViewTextBoxColumn"
        '
        'ListingCheckoutRedirectPreferenceDataGridViewTextBoxColumn
        '
        Me.ListingCheckoutRedirectPreferenceDataGridViewTextBoxColumn.DataPropertyName = "ListingCheckoutRedirectPreference"
        Me.ListingCheckoutRedirectPreferenceDataGridViewTextBoxColumn.HeaderText = "ListingCheckoutRedirectPreference"
        Me.ListingCheckoutRedirectPreferenceDataGridViewTextBoxColumn.Name = "ListingCheckoutRedirectPreferenceDataGridViewTextBoxColumn"
        '
        'TransactionSiteIDDataGridViewTextBoxColumn
        '
        Me.TransactionSiteIDDataGridViewTextBoxColumn.DataPropertyName = "TransactionSiteID"
        Me.TransactionSiteIDDataGridViewTextBoxColumn.HeaderText = "TransactionSiteID"
        Me.TransactionSiteIDDataGridViewTextBoxColumn.Name = "TransactionSiteIDDataGridViewTextBoxColumn"
        '
        'TransactionSiteIDSpecifiedDataGridViewCheckBoxColumn
        '
        Me.TransactionSiteIDSpecifiedDataGridViewCheckBoxColumn.DataPropertyName = "TransactionSiteIDSpecified"
        Me.TransactionSiteIDSpecifiedDataGridViewCheckBoxColumn.HeaderText = "TransactionSiteIDSpecified"
        Me.TransactionSiteIDSpecifiedDataGridViewCheckBoxColumn.Name = "TransactionSiteIDSpecifiedDataGridViewCheckBoxColumn"
        '
        'PlatformDataGridViewTextBoxColumn
        '
        Me.PlatformDataGridViewTextBoxColumn.DataPropertyName = "Platform"
        Me.PlatformDataGridViewTextBoxColumn.HeaderText = "Platform"
        Me.PlatformDataGridViewTextBoxColumn.Name = "PlatformDataGridViewTextBoxColumn"
        '
        'PlatformSpecifiedDataGridViewCheckBoxColumn
        '
        Me.PlatformSpecifiedDataGridViewCheckBoxColumn.DataPropertyName = "PlatformSpecified"
        Me.PlatformSpecifiedDataGridViewCheckBoxColumn.HeaderText = "PlatformSpecified"
        Me.PlatformSpecifiedDataGridViewCheckBoxColumn.Name = "PlatformSpecifiedDataGridViewCheckBoxColumn"
        '
        'CartIDDataGridViewTextBoxColumn
        '
        Me.CartIDDataGridViewTextBoxColumn.DataPropertyName = "CartID"
        Me.CartIDDataGridViewTextBoxColumn.HeaderText = "CartID"
        Me.CartIDDataGridViewTextBoxColumn.Name = "CartIDDataGridViewTextBoxColumn"
        '
        'SellerContactBuyerByEmailDataGridViewCheckBoxColumn
        '
        Me.SellerContactBuyerByEmailDataGridViewCheckBoxColumn.DataPropertyName = "SellerContactBuyerByEmail"
        Me.SellerContactBuyerByEmailDataGridViewCheckBoxColumn.HeaderText = "SellerContactBuyerByEmail"
        Me.SellerContactBuyerByEmailDataGridViewCheckBoxColumn.Name = "SellerContactBuyerByEmailDataGridViewCheckBoxColumn"
        '
        'SellerContactBuyerByEmailSpecifiedDataGridViewCheckBoxColumn
        '
        Me.SellerContactBuyerByEmailSpecifiedDataGridViewCheckBoxColumn.DataPropertyName = "SellerContactBuyerByEmailSpecified"
        Me.SellerContactBuyerByEmailSpecifiedDataGridViewCheckBoxColumn.HeaderText = "SellerContactBuyerByEmailSpecified"
        Me.SellerContactBuyerByEmailSpecifiedDataGridViewCheckBoxColumn.Name = "SellerContactBuyerByEmailSpecifiedDataGridViewCheckBoxColumn"
        '
        'PayPalEmailAddressDataGridViewTextBoxColumn
        '
        Me.PayPalEmailAddressDataGridViewTextBoxColumn.DataPropertyName = "PayPalEmailAddress"
        Me.PayPalEmailAddressDataGridViewTextBoxColumn.HeaderText = "PayPalEmailAddress"
        Me.PayPalEmailAddressDataGridViewTextBoxColumn.Name = "PayPalEmailAddressDataGridViewTextBoxColumn"
        '
        'PaisaPayIDDataGridViewTextBoxColumn
        '
        Me.PaisaPayIDDataGridViewTextBoxColumn.DataPropertyName = "PaisaPayID"
        Me.PaisaPayIDDataGridViewTextBoxColumn.HeaderText = "PaisaPayID"
        Me.PaisaPayIDDataGridViewTextBoxColumn.Name = "PaisaPayIDDataGridViewTextBoxColumn"
        '
        'BuyerGuaranteePriceDataGridViewTextBoxColumn
        '
        Me.BuyerGuaranteePriceDataGridViewTextBoxColumn.DataPropertyName = "BuyerGuaranteePrice"
        Me.BuyerGuaranteePriceDataGridViewTextBoxColumn.HeaderText = "BuyerGuaranteePrice"
        Me.BuyerGuaranteePriceDataGridViewTextBoxColumn.Name = "BuyerGuaranteePriceDataGridViewTextBoxColumn"
        '
        'VariationDataGridViewTextBoxColumn
        '
        Me.VariationDataGridViewTextBoxColumn.DataPropertyName = "Variation"
        Me.VariationDataGridViewTextBoxColumn.HeaderText = "Variation"
        Me.VariationDataGridViewTextBoxColumn.Name = "VariationDataGridViewTextBoxColumn"
        '
        'BuyerCheckoutMessageDataGridViewTextBoxColumn
        '
        Me.BuyerCheckoutMessageDataGridViewTextBoxColumn.DataPropertyName = "BuyerCheckoutMessage"
        Me.BuyerCheckoutMessageDataGridViewTextBoxColumn.HeaderText = "BuyerCheckoutMessage"
        Me.BuyerCheckoutMessageDataGridViewTextBoxColumn.Name = "BuyerCheckoutMessageDataGridViewTextBoxColumn"
        '
        'TaxesDataGridViewTextBoxColumn
        '
        Me.TaxesDataGridViewTextBoxColumn.DataPropertyName = "Taxes"
        Me.TaxesDataGridViewTextBoxColumn.HeaderText = "Taxes"
        Me.TaxesDataGridViewTextBoxColumn.Name = "TaxesDataGridViewTextBoxColumn"
        '
        'BundlePurchaseDataGridViewCheckBoxColumn
        '
        Me.BundlePurchaseDataGridViewCheckBoxColumn.DataPropertyName = "BundlePurchase"
        Me.BundlePurchaseDataGridViewCheckBoxColumn.HeaderText = "BundlePurchase"
        Me.BundlePurchaseDataGridViewCheckBoxColumn.Name = "BundlePurchaseDataGridViewCheckBoxColumn"
        '
        'BundlePurchaseSpecifiedDataGridViewCheckBoxColumn
        '
        Me.BundlePurchaseSpecifiedDataGridViewCheckBoxColumn.DataPropertyName = "BundlePurchaseSpecified"
        Me.BundlePurchaseSpecifiedDataGridViewCheckBoxColumn.HeaderText = "BundlePurchaseSpecified"
        Me.BundlePurchaseSpecifiedDataGridViewCheckBoxColumn.Name = "BundlePurchaseSpecifiedDataGridViewCheckBoxColumn"
        '
        'ActualShippingCostDataGridViewTextBoxColumn
        '
        Me.ActualShippingCostDataGridViewTextBoxColumn.DataPropertyName = "ActualShippingCost"
        Me.ActualShippingCostDataGridViewTextBoxColumn.HeaderText = "ActualShippingCost"
        Me.ActualShippingCostDataGridViewTextBoxColumn.Name = "ActualShippingCostDataGridViewTextBoxColumn"
        '
        'ActualHandlingCostDataGridViewTextBoxColumn
        '
        Me.ActualHandlingCostDataGridViewTextBoxColumn.DataPropertyName = "ActualHandlingCost"
        Me.ActualHandlingCostDataGridViewTextBoxColumn.HeaderText = "ActualHandlingCost"
        Me.ActualHandlingCostDataGridViewTextBoxColumn.Name = "ActualHandlingCostDataGridViewTextBoxColumn"
        '
        'OrderLineItemIDDataGridViewTextBoxColumn
        '
        Me.OrderLineItemIDDataGridViewTextBoxColumn.DataPropertyName = "OrderLineItemID"
        Me.OrderLineItemIDDataGridViewTextBoxColumn.HeaderText = "OrderLineItemID"
        Me.OrderLineItemIDDataGridViewTextBoxColumn.Name = "OrderLineItemIDDataGridViewTextBoxColumn"
        '
        'PaymentHoldDetailsDataGridViewTextBoxColumn
        '
        Me.PaymentHoldDetailsDataGridViewTextBoxColumn.DataPropertyName = "PaymentHoldDetails"
        Me.PaymentHoldDetailsDataGridViewTextBoxColumn.HeaderText = "PaymentHoldDetails"
        Me.PaymentHoldDetailsDataGridViewTextBoxColumn.Name = "PaymentHoldDetailsDataGridViewTextBoxColumn"
        '
        'SellerDiscountsDataGridViewTextBoxColumn
        '
        Me.SellerDiscountsDataGridViewTextBoxColumn.DataPropertyName = "SellerDiscounts"
        Me.SellerDiscountsDataGridViewTextBoxColumn.HeaderText = "SellerDiscounts"
        Me.SellerDiscountsDataGridViewTextBoxColumn.Name = "SellerDiscountsDataGridViewTextBoxColumn"
        '
        'RefundAmountDataGridViewTextBoxColumn
        '
        Me.RefundAmountDataGridViewTextBoxColumn.DataPropertyName = "RefundAmount"
        Me.RefundAmountDataGridViewTextBoxColumn.HeaderText = "RefundAmount"
        Me.RefundAmountDataGridViewTextBoxColumn.Name = "RefundAmountDataGridViewTextBoxColumn"
        '
        'RefundStatusDataGridViewTextBoxColumn
        '
        Me.RefundStatusDataGridViewTextBoxColumn.DataPropertyName = "RefundStatus"
        Me.RefundStatusDataGridViewTextBoxColumn.HeaderText = "RefundStatus"
        Me.RefundStatusDataGridViewTextBoxColumn.Name = "RefundStatusDataGridViewTextBoxColumn"
        '
        'CodiceFiscaleDataGridViewTextBoxColumn
        '
        Me.CodiceFiscaleDataGridViewTextBoxColumn.DataPropertyName = "CodiceFiscale"
        Me.CodiceFiscaleDataGridViewTextBoxColumn.HeaderText = "CodiceFiscale"
        Me.CodiceFiscaleDataGridViewTextBoxColumn.Name = "CodiceFiscaleDataGridViewTextBoxColumn"
        '
        'IsMultiLegShippingDataGridViewCheckBoxColumn
        '
        Me.IsMultiLegShippingDataGridViewCheckBoxColumn.DataPropertyName = "IsMultiLegShipping"
        Me.IsMultiLegShippingDataGridViewCheckBoxColumn.HeaderText = "IsMultiLegShipping"
        Me.IsMultiLegShippingDataGridViewCheckBoxColumn.Name = "IsMultiLegShippingDataGridViewCheckBoxColumn"
        '
        'IsMultiLegShippingSpecifiedDataGridViewCheckBoxColumn
        '
        Me.IsMultiLegShippingSpecifiedDataGridViewCheckBoxColumn.DataPropertyName = "IsMultiLegShippingSpecified"
        Me.IsMultiLegShippingSpecifiedDataGridViewCheckBoxColumn.HeaderText = "IsMultiLegShippingSpecified"
        Me.IsMultiLegShippingSpecifiedDataGridViewCheckBoxColumn.Name = "IsMultiLegShippingSpecifiedDataGridViewCheckBoxColumn"
        '
        'MultiLegShippingDetailsDataGridViewTextBoxColumn
        '
        Me.MultiLegShippingDetailsDataGridViewTextBoxColumn.DataPropertyName = "MultiLegShippingDetails"
        Me.MultiLegShippingDetailsDataGridViewTextBoxColumn.HeaderText = "MultiLegShippingDetails"
        Me.MultiLegShippingDetailsDataGridViewTextBoxColumn.Name = "MultiLegShippingDetailsDataGridViewTextBoxColumn"
        '
        'InvoiceSentTimeDataGridViewTextBoxColumn
        '
        Me.InvoiceSentTimeDataGridViewTextBoxColumn.DataPropertyName = "InvoiceSentTime"
        Me.InvoiceSentTimeDataGridViewTextBoxColumn.HeaderText = "InvoiceSentTime"
        Me.InvoiceSentTimeDataGridViewTextBoxColumn.Name = "InvoiceSentTimeDataGridViewTextBoxColumn"
        '
        'InvoiceSentTimeSpecifiedDataGridViewCheckBoxColumn
        '
        Me.InvoiceSentTimeSpecifiedDataGridViewCheckBoxColumn.DataPropertyName = "InvoiceSentTimeSpecified"
        Me.InvoiceSentTimeSpecifiedDataGridViewCheckBoxColumn.HeaderText = "InvoiceSentTimeSpecified"
        Me.InvoiceSentTimeSpecifiedDataGridViewCheckBoxColumn.Name = "InvoiceSentTimeSpecifiedDataGridViewCheckBoxColumn"
        '
        'UnpaidItemDataGridViewTextBoxColumn
        '
        Me.UnpaidItemDataGridViewTextBoxColumn.DataPropertyName = "UnpaidItem"
        Me.UnpaidItemDataGridViewTextBoxColumn.HeaderText = "UnpaidItem"
        Me.UnpaidItemDataGridViewTextBoxColumn.Name = "UnpaidItemDataGridViewTextBoxColumn"
        '
        'IntangibleItemDataGridViewCheckBoxColumn
        '
        Me.IntangibleItemDataGridViewCheckBoxColumn.DataPropertyName = "IntangibleItem"
        Me.IntangibleItemDataGridViewCheckBoxColumn.HeaderText = "IntangibleItem"
        Me.IntangibleItemDataGridViewCheckBoxColumn.Name = "IntangibleItemDataGridViewCheckBoxColumn"
        '
        'IntangibleItemSpecifiedDataGridViewCheckBoxColumn
        '
        Me.IntangibleItemSpecifiedDataGridViewCheckBoxColumn.DataPropertyName = "IntangibleItemSpecified"
        Me.IntangibleItemSpecifiedDataGridViewCheckBoxColumn.HeaderText = "IntangibleItemSpecified"
        Me.IntangibleItemSpecifiedDataGridViewCheckBoxColumn.Name = "IntangibleItemSpecifiedDataGridViewCheckBoxColumn"
        '
        'MonetaryDetailsDataGridViewTextBoxColumn
        '
        Me.MonetaryDetailsDataGridViewTextBoxColumn.DataPropertyName = "MonetaryDetails"
        Me.MonetaryDetailsDataGridViewTextBoxColumn.HeaderText = "MonetaryDetails"
        Me.MonetaryDetailsDataGridViewTextBoxColumn.Name = "MonetaryDetailsDataGridViewTextBoxColumn"
        '
        'PickupDetailsDataGridViewTextBoxColumn
        '
        Me.PickupDetailsDataGridViewTextBoxColumn.DataPropertyName = "PickupDetails"
        Me.PickupDetailsDataGridViewTextBoxColumn.HeaderText = "PickupDetails"
        Me.PickupDetailsDataGridViewTextBoxColumn.Name = "PickupDetailsDataGridViewTextBoxColumn"
        '
        'PickupMethodSelectedDataGridViewTextBoxColumn
        '
        Me.PickupMethodSelectedDataGridViewTextBoxColumn.DataPropertyName = "PickupMethodSelected"
        Me.PickupMethodSelectedDataGridViewTextBoxColumn.HeaderText = "PickupMethodSelected"
        Me.PickupMethodSelectedDataGridViewTextBoxColumn.Name = "PickupMethodSelectedDataGridViewTextBoxColumn"
        '
        'ShippingConvenienceChargeDataGridViewTextBoxColumn
        '
        Me.ShippingConvenienceChargeDataGridViewTextBoxColumn.DataPropertyName = "ShippingConvenienceCharge"
        Me.ShippingConvenienceChargeDataGridViewTextBoxColumn.HeaderText = "ShippingConvenienceCharge"
        Me.ShippingConvenienceChargeDataGridViewTextBoxColumn.Name = "ShippingConvenienceChargeDataGridViewTextBoxColumn"
        '
        'LogisticsPlanTypeDataGridViewTextBoxColumn
        '
        Me.LogisticsPlanTypeDataGridViewTextBoxColumn.DataPropertyName = "LogisticsPlanType"
        Me.LogisticsPlanTypeDataGridViewTextBoxColumn.HeaderText = "LogisticsPlanType"
        Me.LogisticsPlanTypeDataGridViewTextBoxColumn.Name = "LogisticsPlanTypeDataGridViewTextBoxColumn"
        '
        'BuyerPackageEnclosuresDataGridViewTextBoxColumn
        '
        Me.BuyerPackageEnclosuresDataGridViewTextBoxColumn.DataPropertyName = "BuyerPackageEnclosures"
        Me.BuyerPackageEnclosuresDataGridViewTextBoxColumn.HeaderText = "BuyerPackageEnclosures"
        Me.BuyerPackageEnclosuresDataGridViewTextBoxColumn.Name = "BuyerPackageEnclosuresDataGridViewTextBoxColumn"
        '
        'InventoryReservationIDDataGridViewTextBoxColumn
        '
        Me.InventoryReservationIDDataGridViewTextBoxColumn.DataPropertyName = "InventoryReservationID"
        Me.InventoryReservationIDDataGridViewTextBoxColumn.HeaderText = "InventoryReservationID"
        Me.InventoryReservationIDDataGridViewTextBoxColumn.Name = "InventoryReservationIDDataGridViewTextBoxColumn"
        '
        'ExtendedOrderIDDataGridViewTextBoxColumn
        '
        Me.ExtendedOrderIDDataGridViewTextBoxColumn.DataPropertyName = "ExtendedOrderID"
        Me.ExtendedOrderIDDataGridViewTextBoxColumn.HeaderText = "ExtendedOrderID"
        Me.ExtendedOrderIDDataGridViewTextBoxColumn.Name = "ExtendedOrderIDDataGridViewTextBoxColumn"
        '
        'ExternalTransactionBindingSource
        '
        Me.ExternalTransactionBindingSource.DataMember = "Transaction"
        Me.ExternalTransactionBindingSource.DataSource = Me.TransactionTypeBindingSource
        '
        'PayPalEmailAddressTextBox
        '
        Me.PayPalEmailAddressTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TransactionTypeBindingSource, "PayPalEmailAddress", True))
        Me.PayPalEmailAddressTextBox.Location = New System.Drawing.Point(136, 151)
        Me.PayPalEmailAddressTextBox.Name = "PayPalEmailAddressTextBox"
        Me.PayPalEmailAddressTextBox.Size = New System.Drawing.Size(181, 20)
        Me.PayPalEmailAddressTextBox.TabIndex = 22
        '
        'tpUser
        '
        Me.tpUser.AutoScroll = True
        Me.tpUser.Controls.Add(Me.GroupBox3)
        Me.tpUser.Controls.Add(Me.btSearchClientByFullName)
        Me.tpUser.Controls.Add(Me.lbCustomers)
        Me.tpUser.Controls.Add(Me.lbUserSearchStatus)
        Me.tpUser.Controls.Add(Me.Label2)
        Me.tpUser.Controls.Add(Me.tbFullName)
        Me.tpUser.Controls.Add(UserLastNameLabel)
        Me.tpUser.Controls.Add(Me.UserLastNameTextBox)
        Me.tpUser.Controls.Add(UserFirstNameLabel)
        Me.tpUser.Controls.Add(Me.UserFirstNameTextBox)
        Me.tpUser.Controls.Add(UserIDLabel)
        Me.tpUser.Controls.Add(Me.UserIDTextBox)
        Me.tpUser.Controls.Add(EmailLabel)
        Me.tpUser.Controls.Add(Me.EmailTextBox)
        Me.tpUser.Location = New System.Drawing.Point(4, 22)
        Me.tpUser.Name = "tpUser"
        Me.tpUser.Padding = New System.Windows.Forms.Padding(3)
        Me.tpUser.Size = New System.Drawing.Size(866, 499)
        Me.tpUser.TabIndex = 0
        Me.tpUser.Text = "Покупатель"
        Me.tpUser.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.lbClientInterest)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.rtbClientComment)
        Me.GroupBox3.Controls.Add(Me.rtbClientInterestDetails)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.btCreateClient)
        Me.GroupBox3.Controls.Add(Me.lbClientTags)
        Me.GroupBox3.Location = New System.Drawing.Point(28, 252)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(832, 203)
        Me.GroupBox3.TabIndex = 31
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Новый клиент"
        '
        'lbClientInterest
        '
        Me.lbClientInterest.FormattingEnabled = True
        Me.lbClientInterest.Location = New System.Drawing.Point(19, 41)
        Me.lbClientInterest.Name = "lbClientInterest"
        Me.lbClientInterest.Size = New System.Drawing.Size(160, 95)
        Me.lbClientInterest.TabIndex = 23
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(567, 28)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(77, 13)
        Me.Label7.TabIndex = 30
        Me.Label7.Text = "Комментарий"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(19, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(102, 13)
        Me.Label3.TabIndex = 24
        Me.Label3.Text = "Интересы клиента"
        '
        'rtbClientComment
        '
        Me.rtbClientComment.Location = New System.Drawing.Point(570, 44)
        Me.rtbClientComment.Name = "rtbClientComment"
        Me.rtbClientComment.Size = New System.Drawing.Size(128, 74)
        Me.rtbClientComment.TabIndex = 29
        Me.rtbClientComment.Text = ""
        '
        'rtbClientInterestDetails
        '
        Me.rtbClientInterestDetails.Location = New System.Drawing.Point(188, 44)
        Me.rtbClientInterestDetails.Name = "rtbClientInterestDetails"
        Me.rtbClientInterestDetails.Size = New System.Drawing.Size(184, 74)
        Me.rtbClientInterestDetails.TabIndex = 25
        Me.rtbClientInterestDetails.Text = ""
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(394, 25)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(88, 13)
        Me.Label6.TabIndex = 28
        Me.Label6.Text = "Группы клиента"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(552, 166)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 13)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "*проверь адрес!!"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(185, 28)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(153, 13)
        Me.Label5.TabIndex = 26
        Me.Label5.Text = "Интересы клиента подробно"
        '
        'btCreateClient
        '
        Me.btCreateClient.Location = New System.Drawing.Point(345, 147)
        Me.btCreateClient.Name = "btCreateClient"
        Me.btCreateClient.Size = New System.Drawing.Size(195, 50)
        Me.btCreateClient.TabIndex = 13
        Me.btCreateClient.Text = "Создать клиента в МС.."
        Me.btCreateClient.UseVisualStyleBackColor = True
        '
        'lbClientTags
        '
        Me.lbClientTags.FormattingEnabled = True
        Me.lbClientTags.Location = New System.Drawing.Point(394, 44)
        Me.lbClientTags.Name = "lbClientTags"
        Me.lbClientTags.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lbClientTags.Size = New System.Drawing.Size(165, 95)
        Me.lbClientTags.TabIndex = 27
        '
        'btSearchClientByFullName
        '
        Me.btSearchClientByFullName.Location = New System.Drawing.Point(437, 12)
        Me.btSearchClientByFullName.Name = "btSearchClientByFullName"
        Me.btSearchClientByFullName.Size = New System.Drawing.Size(111, 55)
        Me.btSearchClientByFullName.TabIndex = 22
        Me.btSearchClientByFullName.Text = "Найти в клиента в Мой склад"
        Me.btSearchClientByFullName.UseVisualStyleBackColor = True
        '
        'lbCustomers
        '
        Me.lbCustomers.FormattingEnabled = True
        Me.lbCustomers.Location = New System.Drawing.Point(598, 10)
        Me.lbCustomers.Name = "lbCustomers"
        Me.lbCustomers.Size = New System.Drawing.Size(169, 225)
        Me.lbCustomers.TabIndex = 21
        '
        'lbUserSearchStatus
        '
        Me.lbUserSearchStatus.AutoSize = True
        Me.lbUserSearchStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lbUserSearchStatus.Location = New System.Drawing.Point(446, 89)
        Me.lbUserSearchStatus.Name = "lbUserSearchStatus"
        Me.lbUserSearchStatus.Size = New System.Drawing.Size(102, 16)
        Me.lbUserSearchStatus.TabIndex = 19
        Me.lbUserSearchStatus.Text = "Search status"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(106, 153)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(142, 13)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "*для внесения в мойсклад"
        '
        'tbFullName
        '
        Me.tbFullName.Location = New System.Drawing.Point(105, 169)
        Me.tbFullName.Name = "tbFullName"
        Me.tbFullName.Size = New System.Drawing.Size(276, 20)
        Me.tbFullName.TabIndex = 16
        '
        'UserLastNameTextBox
        '
        Me.UserLastNameTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TransactionTypeBindingSource, "Buyer.UserLastName", True, System.Windows.Forms.DataSourceUpdateMode.OnValidation, "нет"))
        Me.UserLastNameTextBox.Location = New System.Drawing.Point(119, 120)
        Me.UserLastNameTextBox.Name = "UserLastNameTextBox"
        Me.UserLastNameTextBox.Size = New System.Drawing.Size(264, 20)
        Me.UserLastNameTextBox.TabIndex = 9
        '
        'UserFirstNameTextBox
        '
        Me.UserFirstNameTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TransactionTypeBindingSource, "Buyer.UserFirstName", True, System.Windows.Forms.DataSourceUpdateMode.OnValidation, "нет"))
        Me.UserFirstNameTextBox.Location = New System.Drawing.Point(119, 85)
        Me.UserFirstNameTextBox.Name = "UserFirstNameTextBox"
        Me.UserFirstNameTextBox.Size = New System.Drawing.Size(264, 20)
        Me.UserFirstNameTextBox.TabIndex = 7
        '
        'UserIDTextBox
        '
        Me.UserIDTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TransactionTypeBindingSource, "Buyer.UserID", True, System.Windows.Forms.DataSourceUpdateMode.OnValidation, "нет"))
        Me.UserIDTextBox.Location = New System.Drawing.Point(247, 51)
        Me.UserIDTextBox.Name = "UserIDTextBox"
        Me.UserIDTextBox.Size = New System.Drawing.Size(136, 20)
        Me.UserIDTextBox.TabIndex = 5
        '
        'EmailTextBox
        '
        Me.EmailTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TransactionTypeBindingSource, "Buyer.Email", True, System.Windows.Forms.DataSourceUpdateMode.OnValidation, "нет"))
        Me.EmailTextBox.Location = New System.Drawing.Point(99, 19)
        Me.EmailTextBox.Name = "EmailTextBox"
        Me.EmailTextBox.Size = New System.Drawing.Size(284, 20)
        Me.EmailTextBox.TabIndex = 3
        '
        'tpGoodInfoFromMC
        '
        Me.tpGoodInfoFromMC.AutoScroll = True
        Me.tpGoodInfoFromMC.Controls.Add(Me.Label12)
        Me.tpGoodInfoFromMC.Controls.Add(Me.lbShipWokerUUID)
        Me.tpGoodInfoFromMC.Controls.Add(Me.lbWokers)
        Me.tpGoodInfoFromMC.Controls.Add(Me.lbDemandUUID)
        Me.tpGoodInfoFromMC.Controls.Add(Me.lbOrderUUID)
        Me.tpGoodInfoFromMC.Controls.Add(Me.lbGoodUUID)
        Me.tpGoodInfoFromMC.Controls.Add(Me.btCreateMCBulk)
        Me.tpGoodInfoFromMC.Controls.Add(Me.btSendParcel)
        Me.tpGoodInfoFromMC.Location = New System.Drawing.Point(4, 22)
        Me.tpGoodInfoFromMC.Name = "tpGoodInfoFromMC"
        Me.tpGoodInfoFromMC.Size = New System.Drawing.Size(866, 499)
        Me.tpGoodInfoFromMC.TabIndex = 3
        Me.tpGoodInfoFromMC.Text = "Товар в МС"
        Me.tpGoodInfoFromMC.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(10, 117)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(130, 13)
        Me.Label12.TabIndex = 29
        Me.Label12.Text = "Сотрудники на отправку"
        '
        'lbShipWokerUUID
        '
        Me.lbShipWokerUUID.AutoSize = True
        Me.lbShipWokerUUID.Location = New System.Drawing.Point(10, 274)
        Me.lbShipWokerUUID.Name = "lbShipWokerUUID"
        Me.lbShipWokerUUID.Size = New System.Drawing.Size(71, 13)
        Me.lbShipWokerUUID.TabIndex = 28
        Me.lbShipWokerUUID.Text = "отправитель"
        '
        'lbWokers
        '
        Me.lbWokers.FormattingEnabled = True
        Me.lbWokers.Location = New System.Drawing.Point(10, 133)
        Me.lbWokers.Name = "lbWokers"
        Me.lbWokers.Size = New System.Drawing.Size(120, 134)
        Me.lbWokers.TabIndex = 27
        '
        'lbDemandUUID
        '
        Me.lbDemandUUID.AutoSize = True
        Me.lbDemandUUID.Location = New System.Drawing.Point(334, 11)
        Me.lbDemandUUID.Name = "lbDemandUUID"
        Me.lbDemandUUID.Size = New System.Drawing.Size(84, 13)
        Me.lbDemandUUID.TabIndex = 26
        Me.lbDemandUUID.Text = "Отгрузка UUID"
        '
        'lbOrderUUID
        '
        Me.lbOrderUUID.AutoSize = True
        Me.lbOrderUUID.Location = New System.Drawing.Point(185, 11)
        Me.lbOrderUUID.Name = "lbOrderUUID"
        Me.lbOrderUUID.Size = New System.Drawing.Size(63, 13)
        Me.lbOrderUUID.TabIndex = 25
        Me.lbOrderUUID.Text = "Order UUID"
        '
        'lbGoodUUID
        '
        Me.lbGoodUUID.AutoSize = True
        Me.lbGoodUUID.Location = New System.Drawing.Point(7, 11)
        Me.lbGoodUUID.Name = "lbGoodUUID"
        Me.lbGoodUUID.Size = New System.Drawing.Size(63, 13)
        Me.lbGoodUUID.TabIndex = 24
        Me.lbGoodUUID.Text = "Good UUID"
        '
        'btCreateMCBulk
        '
        Me.btCreateMCBulk.Location = New System.Drawing.Point(10, 39)
        Me.btCreateMCBulk.Name = "btCreateMCBulk"
        Me.btCreateMCBulk.Size = New System.Drawing.Size(157, 59)
        Me.btCreateMCBulk.TabIndex = 23
        Me.btCreateMCBulk.Text = "Снять с резерва/создать заказ/отгрузку"
        Me.btCreateMCBulk.UseVisualStyleBackColor = True
        '
        'btSendParcel
        '
        Me.btSendParcel.Location = New System.Drawing.Point(9, 310)
        Me.btSendParcel.Name = "btSendParcel"
        Me.btSendParcel.Size = New System.Drawing.Size(158, 58)
        Me.btSendParcel.TabIndex = 8
        Me.btSendParcel.Text = "Отправить посылку"
        Me.btSendParcel.UseVisualStyleBackColor = True
        '
        'tpInDBTrilbone
        '
        Me.tpInDBTrilbone.Controls.Add(Me.Label35)
        Me.tpInDBTrilbone.Controls.Add(Me.Label34)
        Me.tpInDBTrilbone.Controls.Add(Me.Label33)
        Me.tpInDBTrilbone.Controls.Add(Me.Label32)
        Me.tpInDBTrilbone.Controls.Add(Me.tbCalcTotalPerOne)
        Me.tpInDBTrilbone.Controls.Add(Me.Label31)
        Me.tpInDBTrilbone.Controls.Add(Me.btPersonCalc)
        Me.tpInDBTrilbone.Controls.Add(Me.Label30)
        Me.tpInDBTrilbone.Controls.Add(Me.tbPersonCount)
        Me.tpInDBTrilbone.Controls.Add(Me.btGetResorceFee)
        Me.tpInDBTrilbone.Controls.Add(Me.Label29)
        Me.tpInDBTrilbone.Controls.Add(Me.tbCalcTotal)
        Me.tpInDBTrilbone.Controls.Add(Me.btTotal)
        Me.tpInDBTrilbone.Controls.Add(Me.Label28)
        Me.tpInDBTrilbone.Controls.Add(Me.tbSubTotal)
        Me.tpInDBTrilbone.Controls.Add(Me.btSubTotal)
        Me.tpInDBTrilbone.Controls.Add(Me.Label27)
        Me.tpInDBTrilbone.Controls.Add(Me.tbFullAmount)
        Me.tpInDBTrilbone.Controls.Add(Me.btWeightCalculate)
        Me.tpInDBTrilbone.Controls.Add(Me.btMoneyOutCalculate)
        Me.tpInDBTrilbone.Controls.Add(Me.btTrilboneCalculate)
        Me.tpInDBTrilbone.Controls.Add(Me.btNalogCalculate)
        Me.tpInDBTrilbone.Controls.Add(Me.tbTrilboneBase)
        Me.tpInDBTrilbone.Controls.Add(Me.tbNalogBase)
        Me.tpInDBTrilbone.Controls.Add(Me.tbMoneyOutBase)
        Me.tpInDBTrilbone.Controls.Add(Me.Label26)
        Me.tpInDBTrilbone.Controls.Add(Me.Label25)
        Me.tpInDBTrilbone.Controls.Add(Me.Label24)
        Me.tpInDBTrilbone.Controls.Add(Me.tbTrilboneTax)
        Me.tpInDBTrilbone.Controls.Add(Me.tbNalogTax)
        Me.tpInDBTrilbone.Controls.Add(Me.tbWeightTax)
        Me.tpInDBTrilbone.Controls.Add(Me.tbWeight)
        Me.tpInDBTrilbone.Controls.Add(Me.tbMoneyOutTax)
        Me.tpInDBTrilbone.Controls.Add(Me.btWeightQuery)
        Me.tpInDBTrilbone.Controls.Add(Me.Label23)
        Me.tpInDBTrilbone.Controls.Add(Me.Label22)
        Me.tpInDBTrilbone.Controls.Add(Me.btGetFullAmount)
        Me.tpInDBTrilbone.Controls.Add(Me.Label21)
        Me.tpInDBTrilbone.Controls.Add(Me.Label20)
        Me.tpInDBTrilbone.Controls.Add(Me.btShipmentOutFee)
        Me.tpInDBTrilbone.Controls.Add(Me.tbTrilboneFee)
        Me.tpInDBTrilbone.Controls.Add(Me.tbNalogFee)
        Me.tpInDBTrilbone.Controls.Add(Me.tbShipmentOutFee)
        Me.tpInDBTrilbone.Controls.Add(Me.tbExportFee)
        Me.tpInDBTrilbone.Controls.Add(Me.tbInsectionFee)
        Me.tpInDBTrilbone.Controls.Add(Me.tbMoneyOutFee)
        Me.tpInDBTrilbone.Controls.Add(Me.Label19)
        Me.tpInDBTrilbone.Controls.Add(Me.Label18)
        Me.tpInDBTrilbone.Controls.Add(Me.Label17)
        Me.tpInDBTrilbone.Controls.Add(Me.Label16)
        Me.tpInDBTrilbone.Controls.Add(Me.Label15)
        Me.tpInDBTrilbone.Controls.Add(Me.Label14)
        Me.tpInDBTrilbone.Controls.Add(Me.btSaveInDb)
        Me.tpInDBTrilbone.Location = New System.Drawing.Point(4, 22)
        Me.tpInDBTrilbone.Name = "tpInDBTrilbone"
        Me.tpInDBTrilbone.Padding = New System.Windows.Forms.Padding(3)
        Me.tpInDBTrilbone.Size = New System.Drawing.Size(866, 499)
        Me.tpInDBTrilbone.TabIndex = 4
        Me.tpInDBTrilbone.Text = "Товар в БД Trilbone"
        Me.tpInDBTrilbone.UseVisualStyleBackColor = True
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(671, 146)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(134, 13)
        Me.Label35.TabIndex = 56
        Me.Label35.Text = "*вес нетто, без упаковки"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(391, 111)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(249, 13)
        Me.Label34.TabIndex = 55
        Me.Label34.Text = "*стоимость, записанная при отправке посылки"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(386, 78)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(326, 13)
        Me.Label33.TabIndex = 54
        Me.Label33.Text = "*суммируются все выстановочные fee в истории предложений"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(53, 12)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(219, 13)
        Me.Label32.TabIndex = 53
        Me.Label32.Text = "Оформляется после оплаты и отправки!!!"
        '
        'tbCalcTotalPerOne
        '
        Me.tbCalcTotalPerOne.Location = New System.Drawing.Point(313, 377)
        Me.tbCalcTotalPerOne.Name = "tbCalcTotalPerOne"
        Me.tbCalcTotalPerOne.Size = New System.Drawing.Size(52, 20)
        Me.tbCalcTotalPerOne.TabIndex = 52
        Me.tbCalcTotalPerOne.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(184, 381)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(121, 13)
        Me.Label31.TabIndex = 51
        Me.Label31.Text = "На каждого дольщика"
        '
        'btPersonCalc
        '
        Me.btPersonCalc.Location = New System.Drawing.Point(456, 376)
        Me.btPersonCalc.Name = "btPersonCalc"
        Me.btPersonCalc.Size = New System.Drawing.Size(75, 23)
        Me.btPersonCalc.TabIndex = 50
        Me.btPersonCalc.Text = "рассчет"
        Me.btPersonCalc.UseVisualStyleBackColor = True
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(376, 381)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(40, 13)
        Me.Label30.TabIndex = 49
        Me.Label30.Text = "Долей"
        '
        'tbPersonCount
        '
        Me.tbPersonCount.Location = New System.Drawing.Point(422, 377)
        Me.tbPersonCount.Name = "tbPersonCount"
        Me.tbPersonCount.Size = New System.Drawing.Size(23, 20)
        Me.tbPersonCount.TabIndex = 48
        Me.tbPersonCount.Text = "1"
        Me.tbPersonCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btGetResorceFee
        '
        Me.btGetResorceFee.Location = New System.Drawing.Point(305, 73)
        Me.btGetResorceFee.Name = "btGetResorceFee"
        Me.btGetResorceFee.Size = New System.Drawing.Size(75, 23)
        Me.btGetResorceFee.TabIndex = 46
        Me.btGetResorceFee.Text = "получить"
        Me.btGetResorceFee.UseVisualStyleBackColor = True
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(372, 347)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(132, 13)
        Me.Label29.TabIndex = 45
        Me.Label29.Text = "*после вычета % Trilbone"
        '
        'tbCalcTotal
        '
        Me.tbCalcTotal.Location = New System.Drawing.Point(313, 344)
        Me.tbCalcTotal.Name = "tbCalcTotal"
        Me.tbCalcTotal.Size = New System.Drawing.Size(52, 20)
        Me.tbCalcTotal.TabIndex = 44
        Me.tbCalcTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btTotal
        '
        Me.btTotal.Location = New System.Drawing.Point(133, 342)
        Me.btTotal.Name = "btTotal"
        Me.btTotal.Size = New System.Drawing.Size(171, 23)
        Me.btTotal.TabIndex = 43
        Me.btTotal.Text = "для выплаты дольщикам"
        Me.btTotal.UseVisualStyleBackColor = True
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(375, 262)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(156, 13)
        Me.Label28.TabIndex = 42
        Me.Label28.Text = "*после вычета всех расходов"
        '
        'tbSubTotal
        '
        Me.tbSubTotal.Location = New System.Drawing.Point(316, 259)
        Me.tbSubTotal.Name = "tbSubTotal"
        Me.tbSubTotal.Size = New System.Drawing.Size(52, 20)
        Me.tbSubTotal.TabIndex = 41
        Me.tbSubTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btSubTotal
        '
        Me.btSubTotal.Location = New System.Drawing.Point(182, 257)
        Me.btSubTotal.Name = "btSubTotal"
        Me.btSubTotal.Size = New System.Drawing.Size(125, 23)
        Me.btSubTotal.TabIndex = 40
        Me.btSubTotal.Text = "налик после вычетов"
        Me.btSubTotal.UseVisualStyleBackColor = True
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(260, 42)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(143, 13)
        Me.Label27.TabIndex = 39
        Me.Label27.Text = "Всего получено (на PayPal)"
        '
        'tbFullAmount
        '
        Me.tbFullAmount.Location = New System.Drawing.Point(191, 39)
        Me.tbFullAmount.Name = "tbFullAmount"
        Me.tbFullAmount.Size = New System.Drawing.Size(52, 20)
        Me.tbFullAmount.TabIndex = 38
        Me.tbFullAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btWeightCalculate
        '
        Me.btWeightCalculate.Location = New System.Drawing.Point(584, 141)
        Me.btWeightCalculate.Name = "btWeightCalculate"
        Me.btWeightCalculate.Size = New System.Drawing.Size(75, 23)
        Me.btWeightCalculate.TabIndex = 36
        Me.btWeightCalculate.Text = "рассчет"
        Me.btWeightCalculate.UseVisualStyleBackColor = True
        '
        'btMoneyOutCalculate
        '
        Me.btMoneyOutCalculate.Location = New System.Drawing.Point(538, 176)
        Me.btMoneyOutCalculate.Name = "btMoneyOutCalculate"
        Me.btMoneyOutCalculate.Size = New System.Drawing.Size(75, 23)
        Me.btMoneyOutCalculate.TabIndex = 35
        Me.btMoneyOutCalculate.Text = "рассчет"
        Me.btMoneyOutCalculate.UseVisualStyleBackColor = True
        '
        'btTrilboneCalculate
        '
        Me.btTrilboneCalculate.Location = New System.Drawing.Point(538, 294)
        Me.btTrilboneCalculate.Name = "btTrilboneCalculate"
        Me.btTrilboneCalculate.Size = New System.Drawing.Size(75, 23)
        Me.btTrilboneCalculate.TabIndex = 34
        Me.btTrilboneCalculate.Text = "рассчет"
        Me.btTrilboneCalculate.UseVisualStyleBackColor = True
        '
        'btNalogCalculate
        '
        Me.btNalogCalculate.Location = New System.Drawing.Point(538, 210)
        Me.btNalogCalculate.Name = "btNalogCalculate"
        Me.btNalogCalculate.Size = New System.Drawing.Size(75, 23)
        Me.btNalogCalculate.TabIndex = 33
        Me.btNalogCalculate.Text = "рассчет"
        Me.btNalogCalculate.UseVisualStyleBackColor = True
        '
        'tbTrilboneBase
        '
        Me.tbTrilboneBase.Location = New System.Drawing.Point(470, 295)
        Me.tbTrilboneBase.Name = "tbTrilboneBase"
        Me.tbTrilboneBase.Size = New System.Drawing.Size(52, 20)
        Me.tbTrilboneBase.TabIndex = 32
        Me.tbTrilboneBase.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbNalogBase
        '
        Me.tbNalogBase.Location = New System.Drawing.Point(470, 211)
        Me.tbNalogBase.Name = "tbNalogBase"
        Me.tbNalogBase.Size = New System.Drawing.Size(52, 20)
        Me.tbNalogBase.TabIndex = 31
        Me.tbNalogBase.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbMoneyOutBase
        '
        Me.tbMoneyOutBase.Location = New System.Drawing.Point(470, 177)
        Me.tbMoneyOutBase.Name = "tbMoneyOutBase"
        Me.tbMoneyOutBase.Size = New System.Drawing.Size(52, 20)
        Me.tbMoneyOutBase.TabIndex = 30
        Me.tbMoneyOutBase.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(408, 181)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(56, 13)
        Me.Label26.TabIndex = 29
        Me.Label26.Text = "от суммы"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(408, 215)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(56, 13)
        Me.Label25.TabIndex = 28
        Me.Label25.Text = "от суммы"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(408, 299)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(56, 13)
        Me.Label24.TabIndex = 27
        Me.Label24.Text = "от суммы"
        '
        'tbTrilboneTax
        '
        Me.tbTrilboneTax.Location = New System.Drawing.Point(375, 295)
        Me.tbTrilboneTax.Name = "tbTrilboneTax"
        Me.tbTrilboneTax.Size = New System.Drawing.Size(27, 20)
        Me.tbTrilboneTax.TabIndex = 26
        Me.tbTrilboneTax.Text = "30"
        Me.tbTrilboneTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbNalogTax
        '
        Me.tbNalogTax.Location = New System.Drawing.Point(375, 211)
        Me.tbNalogTax.Name = "tbNalogTax"
        Me.tbNalogTax.Size = New System.Drawing.Size(27, 20)
        Me.tbNalogTax.TabIndex = 25
        Me.tbNalogTax.Text = "7"
        Me.tbNalogTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbWeightTax
        '
        Me.tbWeightTax.Location = New System.Drawing.Point(543, 142)
        Me.tbWeightTax.Name = "tbWeightTax"
        Me.tbWeightTax.Size = New System.Drawing.Size(27, 20)
        Me.tbWeightTax.TabIndex = 24
        Me.tbWeightTax.Text = "12"
        Me.tbWeightTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbWeight
        '
        Me.tbWeight.Location = New System.Drawing.Point(408, 142)
        Me.tbWeight.Name = "tbWeight"
        Me.tbWeight.Size = New System.Drawing.Size(27, 20)
        Me.tbWeight.TabIndex = 23
        Me.tbWeight.Text = "1"
        Me.tbWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbMoneyOutTax
        '
        Me.tbMoneyOutTax.Location = New System.Drawing.Point(375, 177)
        Me.tbMoneyOutTax.Name = "tbMoneyOutTax"
        Me.tbMoneyOutTax.Size = New System.Drawing.Size(27, 20)
        Me.tbMoneyOutTax.TabIndex = 22
        Me.tbMoneyOutTax.Text = "5"
        Me.tbMoneyOutTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btWeightQuery
        '
        Me.btWeightQuery.Location = New System.Drawing.Point(306, 141)
        Me.btWeightQuery.Name = "btWeightQuery"
        Me.btWeightQuery.Size = New System.Drawing.Size(96, 23)
        Me.btWeightQuery.TabIndex = 21
        Me.btWeightQuery.Text = "получить вес"
        Me.btWeightQuery.UseVisualStyleBackColor = True
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(439, 146)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(98, 13)
        Me.Label23.TabIndex = 20
        Me.Label23.Text = "кг; ставка за вес:"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(313, 181)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(56, 13)
        Me.Label22.TabIndex = 19
        Me.Label22.Text = "ставка, %"
        '
        'btGetFullAmount
        '
        Me.btGetFullAmount.Location = New System.Drawing.Point(48, 37)
        Me.btGetFullAmount.Name = "btGetFullAmount"
        Me.btGetFullAmount.Size = New System.Drawing.Size(125, 23)
        Me.btGetFullAmount.TabIndex = 18
        Me.btGetFullAmount.Text = "база для рассчетов"
        Me.btGetFullAmount.UseVisualStyleBackColor = True
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(313, 299)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(56, 13)
        Me.Label21.TabIndex = 17
        Me.Label21.Text = "ставка, %"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(313, 215)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(56, 13)
        Me.Label20.TabIndex = 16
        Me.Label20.Text = "ставка, %"
        '
        'btShipmentOutFee
        '
        Me.btShipmentOutFee.Location = New System.Drawing.Point(305, 107)
        Me.btShipmentOutFee.Name = "btShipmentOutFee"
        Me.btShipmentOutFee.Size = New System.Drawing.Size(75, 23)
        Me.btShipmentOutFee.TabIndex = 15
        Me.btShipmentOutFee.Text = "получить"
        Me.btShipmentOutFee.UseVisualStyleBackColor = True
        '
        'tbTrilboneFee
        '
        Me.tbTrilboneFee.Location = New System.Drawing.Point(245, 295)
        Me.tbTrilboneFee.Name = "tbTrilboneFee"
        Me.tbTrilboneFee.Size = New System.Drawing.Size(52, 20)
        Me.tbTrilboneFee.TabIndex = 13
        Me.tbTrilboneFee.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbNalogFee
        '
        Me.tbNalogFee.Location = New System.Drawing.Point(245, 211)
        Me.tbNalogFee.Name = "tbNalogFee"
        Me.tbNalogFee.Size = New System.Drawing.Size(52, 20)
        Me.tbNalogFee.TabIndex = 12
        Me.tbNalogFee.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbShipmentOutFee
        '
        Me.tbShipmentOutFee.Location = New System.Drawing.Point(244, 108)
        Me.tbShipmentOutFee.Name = "tbShipmentOutFee"
        Me.tbShipmentOutFee.Size = New System.Drawing.Size(52, 20)
        Me.tbShipmentOutFee.TabIndex = 11
        Me.tbShipmentOutFee.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbExportFee
        '
        Me.tbExportFee.Location = New System.Drawing.Point(245, 142)
        Me.tbExportFee.Name = "tbExportFee"
        Me.tbExportFee.Size = New System.Drawing.Size(52, 20)
        Me.tbExportFee.TabIndex = 10
        Me.tbExportFee.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbInsectionFee
        '
        Me.tbInsectionFee.Location = New System.Drawing.Point(245, 76)
        Me.tbInsectionFee.Name = "tbInsectionFee"
        Me.tbInsectionFee.Size = New System.Drawing.Size(52, 20)
        Me.tbInsectionFee.TabIndex = 9
        Me.tbInsectionFee.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbMoneyOutFee
        '
        Me.tbMoneyOutFee.Location = New System.Drawing.Point(245, 177)
        Me.tbMoneyOutFee.Name = "tbMoneyOutFee"
        Me.tbMoneyOutFee.Size = New System.Drawing.Size(52, 20)
        Me.tbMoneyOutFee.TabIndex = 8
        Me.tbMoneyOutFee.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(11, 299)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(228, 13)
        Me.Label19.TabIndex = 7
        Me.Label19.Text = "Сумма, списываемая конторой за продажу"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(133, 215)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(106, 13)
        Me.Label18.TabIndex = 6
        Me.Label18.Text = "Стоимость налогов"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(28, 112)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(210, 13)
        Me.Label17.TabIndex = 5
        Me.Label17.Text = "Стоимость отправки, включая упаковку"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(127, 146)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(112, 13)
        Me.Label16.TabIndex = 4
        Me.Label16.Text = "Стоимость экспорта"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(60, 80)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(174, 13)
        Me.Label15.TabIndex = 3
        Me.Label15.Text = "Стоимость выставления на eBay"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(95, 181)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(145, 13)
        Me.Label14.TabIndex = 2
        Me.Label14.Text = "Стоимость вывода (PayPal)"
        '
        'btSaveInDb
        '
        Me.btSaveInDb.Location = New System.Drawing.Point(681, 341)
        Me.btSaveInDb.Name = "btSaveInDb"
        Me.btSaveInDb.Size = New System.Drawing.Size(165, 51)
        Me.btSaveInDb.TabIndex = 0
        Me.btSaveInDb.Text = "Сохранить в базу и в МС"
        Me.btSaveInDb.UseVisualStyleBackColor = True
        '
        'TabPage1
        '
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(866, 499)
        Me.TabPage1.TabIndex = 5
        Me.TabPage1.Text = "TabPage1"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'BuyerMessageRichTextBox
        '
        Me.BuyerMessageRichTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TransactionTypeBindingSource, "BuyerMessage", True, System.Windows.Forms.DataSourceUpdateMode.OnValidation, "нет"))
        Me.BuyerMessageRichTextBox.Location = New System.Drawing.Point(6, 358)
        Me.BuyerMessageRichTextBox.Name = "BuyerMessageRichTextBox"
        Me.BuyerMessageRichTextBox.Size = New System.Drawing.Size(266, 51)
        Me.BuyerMessageRichTextBox.TabIndex = 1
        Me.BuyerMessageRichTextBox.Text = ""
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lbShipped)
        Me.GroupBox1.Controls.Add(Me.lbPaid)
        Me.GroupBox1.Controls.Add(Me.CurrencyIDTextBox4)
        Me.GroupBox1.Controls.Add(Me.TextBox1)
        Me.GroupBox1.Controls.Add(ValueLabel4)
        Me.GroupBox1.Controls.Add(CreatedDateLabel)
        Me.GroupBox1.Controls.Add(Me.ValueTextBox4)
        Me.GroupBox1.Controls.Add(Me.TitleTextBox)
        Me.GroupBox1.Controls.Add(Me.CurrencyIDTextBox3)
        Me.GroupBox1.Controls.Add(ValueLabel3)
        Me.GroupBox1.Controls.Add(Me.ValueTextBox3)
        Me.GroupBox1.Controls.Add(Me.CurrencyIDTextBox2)
        Me.GroupBox1.Controls.Add(ValueLabel2)
        Me.GroupBox1.Controls.Add(Me.ValueTextBox2)
        Me.GroupBox1.Controls.Add(BuyerMessageLabel)
        Me.GroupBox1.Controls.Add(Me.CurrencyIDTextBox1)
        Me.GroupBox1.Controls.Add(Me.BuyerMessageRichTextBox)
        Me.GroupBox1.Controls.Add(ValueLabel1)
        Me.GroupBox1.Controls.Add(Me.ValueTextBox1)
        Me.GroupBox1.Controls.Add(Me.CurrencyIDTextBox)
        Me.GroupBox1.Controls.Add(ValueLabel)
        Me.GroupBox1.Controls.Add(Me.ValueTextBox)
        Me.GroupBox1.Controls.Add(SKULabel)
        Me.GroupBox1.Controls.Add(Me.SKUTextBox)
        Me.GroupBox1.Location = New System.Drawing.Point(892, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(278, 421)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Детали по товару eBay"
        '
        'lbShipped
        '
        Me.lbShipped.AutoSize = True
        Me.lbShipped.DataBindings.Add(New System.Windows.Forms.Binding("Enabled", Me.TransactionTypeBindingSource, "Shipped", True))
        Me.lbShipped.Location = New System.Drawing.Point(16, 40)
        Me.lbShipped.Name = "lbShipped"
        Me.lbShipped.Size = New System.Drawing.Size(91, 13)
        Me.lbShipped.TabIndex = 27
        Me.lbShipped.Text = "Статус отправки"
        '
        'lbPaid
        '
        Me.lbPaid.AutoSize = True
        Me.lbPaid.DataBindings.Add(New System.Windows.Forms.Binding("Enabled", Me.TransactionTypeBindingSource, "Paid", True, System.Windows.Forms.DataSourceUpdateMode.Never))
        Me.lbPaid.Location = New System.Drawing.Point(16, 19)
        Me.lbPaid.Name = "lbPaid"
        Me.lbPaid.Size = New System.Drawing.Size(81, 13)
        Me.lbPaid.TabIndex = 26
        Me.lbPaid.Text = "Статус оплаты"
        '
        'CurrencyIDTextBox4
        '
        Me.CurrencyIDTextBox4.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TransactionTypeBindingSource, "FinalValueFeeCurrency", True))
        Me.CurrencyIDTextBox4.Location = New System.Drawing.Point(211, 295)
        Me.CurrencyIDTextBox4.Name = "CurrencyIDTextBox4"
        Me.CurrencyIDTextBox4.Size = New System.Drawing.Size(38, 20)
        Me.CurrencyIDTextBox4.TabIndex = 23
        '
        'TextBox1
        '
        Me.TextBox1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TransactionTypeBindingSource, "CreatedDate", True))
        Me.TextBox1.Location = New System.Drawing.Point(124, 78)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 20)
        Me.TextBox1.TabIndex = 13
        '
        'ValueTextBox4
        '
        Me.ValueTextBox4.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TransactionTypeBindingSource, "FinalValueFee", True))
        Me.ValueTextBox4.Location = New System.Drawing.Point(138, 295)
        Me.ValueTextBox4.Name = "ValueTextBox4"
        Me.ValueTextBox4.Size = New System.Drawing.Size(67, 20)
        Me.ValueTextBox4.TabIndex = 25
        '
        'TitleTextBox
        '
        Me.TitleTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TransactionTypeBindingSource, "Title", True))
        Me.TitleTextBox.Location = New System.Drawing.Point(20, 104)
        Me.TitleTextBox.Multiline = True
        Me.TitleTextBox.Name = "TitleTextBox"
        Me.TitleTextBox.Size = New System.Drawing.Size(252, 45)
        Me.TitleTextBox.TabIndex = 22
        '
        'CurrencyIDTextBox3
        '
        Me.CurrencyIDTextBox3.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TransactionTypeBindingSource, "ActualHandlingCostCurrency", True))
        Me.CurrencyIDTextBox3.Location = New System.Drawing.Point(211, 269)
        Me.CurrencyIDTextBox3.Name = "CurrencyIDTextBox3"
        Me.CurrencyIDTextBox3.Size = New System.Drawing.Size(38, 20)
        Me.CurrencyIDTextBox3.TabIndex = 19
        '
        'ValueTextBox3
        '
        Me.ValueTextBox3.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TransactionTypeBindingSource, "ActualHandlingCost", True))
        Me.ValueTextBox3.Location = New System.Drawing.Point(138, 269)
        Me.ValueTextBox3.Name = "ValueTextBox3"
        Me.ValueTextBox3.Size = New System.Drawing.Size(67, 20)
        Me.ValueTextBox3.TabIndex = 21
        '
        'CurrencyIDTextBox2
        '
        Me.CurrencyIDTextBox2.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TransactionTypeBindingSource, "ActualShippingCostCurrency", True))
        Me.CurrencyIDTextBox2.Location = New System.Drawing.Point(211, 243)
        Me.CurrencyIDTextBox2.Name = "CurrencyIDTextBox2"
        Me.CurrencyIDTextBox2.Size = New System.Drawing.Size(38, 20)
        Me.CurrencyIDTextBox2.TabIndex = 16
        '
        'ValueTextBox2
        '
        Me.ValueTextBox2.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TransactionTypeBindingSource, "ActualShippingCost", True))
        Me.ValueTextBox2.Location = New System.Drawing.Point(138, 243)
        Me.ValueTextBox2.Name = "ValueTextBox2"
        Me.ValueTextBox2.Size = New System.Drawing.Size(67, 20)
        Me.ValueTextBox2.TabIndex = 18
        '
        'CurrencyIDTextBox1
        '
        Me.CurrencyIDTextBox1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TransactionTypeBindingSource, "TransactionCurrency", True))
        Me.CurrencyIDTextBox1.Location = New System.Drawing.Point(211, 217)
        Me.CurrencyIDTextBox1.Name = "CurrencyIDTextBox1"
        Me.CurrencyIDTextBox1.Size = New System.Drawing.Size(38, 20)
        Me.CurrencyIDTextBox1.TabIndex = 13
        '
        'ValueTextBox1
        '
        Me.ValueTextBox1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TransactionTypeBindingSource, "TransactionPriceValue", True))
        Me.ValueTextBox1.Location = New System.Drawing.Point(138, 217)
        Me.ValueTextBox1.Name = "ValueTextBox1"
        Me.ValueTextBox1.Size = New System.Drawing.Size(67, 20)
        Me.ValueTextBox1.TabIndex = 15
        '
        'CurrencyIDTextBox
        '
        Me.CurrencyIDTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TransactionTypeBindingSource, "AmountCurrencyID", True))
        Me.CurrencyIDTextBox.Location = New System.Drawing.Point(211, 191)
        Me.CurrencyIDTextBox.Name = "CurrencyIDTextBox"
        Me.CurrencyIDTextBox.Size = New System.Drawing.Size(38, 20)
        Me.CurrencyIDTextBox.TabIndex = 10
        '
        'ValueTextBox
        '
        Me.ValueTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TransactionTypeBindingSource, "AmountPaidValue", True))
        Me.ValueTextBox.Location = New System.Drawing.Point(138, 191)
        Me.ValueTextBox.Name = "ValueTextBox"
        Me.ValueTextBox.Size = New System.Drawing.Size(67, 20)
        Me.ValueTextBox.TabIndex = 12
        '
        'SKUTextBox
        '
        Me.SKUTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TransactionTypeBindingSource, "ItemSKU", True))
        Me.SKUTextBox.Location = New System.Drawing.Point(138, 160)
        Me.SKUTextBox.Name = "SKUTextBox"
        Me.SKUTextBox.Size = New System.Drawing.Size(111, 20)
        Me.SKUTextBox.TabIndex = 9
        '
        'tbTotal
        '
        Me.tbTotal.Location = New System.Drawing.Point(124, 58)
        Me.tbTotal.Name = "tbTotal"
        Me.tbTotal.Size = New System.Drawing.Size(67, 20)
        Me.tbTotal.TabIndex = 29
        '
        'tbFeePayPalCurrency
        '
        Me.tbFeePayPalCurrency.Location = New System.Drawing.Point(197, 23)
        Me.tbFeePayPalCurrency.Name = "tbFeePayPalCurrency"
        Me.tbFeePayPalCurrency.Size = New System.Drawing.Size(38, 20)
        Me.tbFeePayPalCurrency.TabIndex = 26
        '
        'tbPayPalFeeAmount
        '
        Me.tbPayPalFeeAmount.Location = New System.Drawing.Point(124, 23)
        Me.tbPayPalFeeAmount.Name = "tbPayPalFeeAmount"
        Me.tbPayPalFeeAmount.Size = New System.Drawing.Size(67, 20)
        Me.tbPayPalFeeAmount.TabIndex = 28
        '
        'btLoadMC
        '
        Me.btLoadMC.Location = New System.Drawing.Point(26, 47)
        Me.btLoadMC.Name = "btLoadMC"
        Me.btLoadMC.Size = New System.Drawing.Size(118, 23)
        Me.btLoadMC.TabIndex = 12
        Me.btLoadMC.Text = "Мой склад"
        Me.btLoadMC.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.tbPayPalFeeAmount)
        Me.GroupBox4.Controls.Add(Label8)
        Me.GroupBox4.Controls.Add(Label4)
        Me.GroupBox4.Controls.Add(Me.tbFeePayPalCurrency)
        Me.GroupBox4.Controls.Add(Me.tbTotal)
        Me.GroupBox4.Location = New System.Drawing.Point(892, 442)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(278, 100)
        Me.GroupBox4.TabIndex = 31
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Детали по товару PayPal"
        '
        'fmTrilboneEbay
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1182, 623)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.btLoadMC)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.tbctlMain)
        Me.Controls.Add(Me.lblItemsList)
        Me.Controls.Add(Me.btGetTransaction)
        Me.Controls.Add(Me.btReadAccounts)
        Me.Controls.Add(Me.cbAccount)
        Me.Name = "fmTrilboneEbay"
        Me.Text = "eBay manager 1.0"
        CType(Me.TransactionTypeBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbctlMain.ResumeLayout(False)
        Me.tpAddress.ResumeLayout(False)
        Me.tpAddress.PerformLayout()
        Me.tbctlAddressExternal.ResumeLayout(False)
        Me.tpAddressEbay.ResumeLayout(False)
        Me.tpAddressEbay.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.IMoySkladDataProvider_AddressBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpPayPalInfo.ResumeLayout(False)
        Me.tpPayPalInfo.PerformLayout()
        CType(Me.ExternalTransactionDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ExternalTransactionBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpUser.ResumeLayout(False)
        Me.tpUser.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.tpGoodInfoFromMC.ResumeLayout(False)
        Me.tpGoodInfoFromMC.PerformLayout()
        Me.tpInDBTrilbone.ResumeLayout(False)
        Me.tpInDBTrilbone.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cbAccount As System.Windows.Forms.ComboBox
    Friend WithEvents btReadAccounts As System.Windows.Forms.Button
    Friend WithEvents btGetTransaction As System.Windows.Forms.Button
    Friend WithEvents lblItemsList As System.Windows.Forms.ListBox
    Friend WithEvents tbctlMain As System.Windows.Forms.TabControl
    Friend WithEvents tpUser As System.Windows.Forms.TabPage
    Friend WithEvents tpAddress As System.Windows.Forms.TabPage
    Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
    Friend WithEvents btBuildAddress As System.Windows.Forms.Button
    Friend WithEvents UserLastNameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents TransactionTypeBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents UserFirstNameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents UserIDTextBox As System.Windows.Forms.TextBox
    Friend WithEvents EmailTextBox As System.Windows.Forms.TextBox
    Friend WithEvents BuyerMessageRichTextBox As System.Windows.Forms.RichTextBox
    Friend WithEvents Phone2TextBox As System.Windows.Forms.TextBox
    Friend WithEvents PhoneTextBox As System.Windows.Forms.TextBox
    Friend WithEvents CountryNameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents StateOrProvinceTextBox As System.Windows.Forms.TextBox
    Friend WithEvents CityNameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PostalCodeTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Street2TextBox As System.Windows.Forms.TextBox
    Friend WithEvents Street1TextBox As System.Windows.Forms.TextBox
    Friend WithEvents StreetTextBox As System.Windows.Forms.TextBox
    Friend WithEvents LastNameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents FirstNameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents NameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btCreateClient As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents SKUTextBox As System.Windows.Forms.TextBox
    Friend WithEvents CurrencyIDTextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents ValueTextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents CurrencyIDTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ValueTextBox As System.Windows.Forms.TextBox
    Friend WithEvents tbFullName As System.Windows.Forms.TextBox
    Friend WithEvents tpPayPalInfo As System.Windows.Forms.TabPage
    Friend WithEvents ExternalTransactionDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents ExternalTransactionBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PayPalEmailAddressTextBox As System.Windows.Forms.TextBox
    Friend WithEvents CurrencyIDTextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents ValueTextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents CurrencyIDTextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents ValueTextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents lbUserSearchStatus As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btCreateIncomingPayment As System.Windows.Forms.Button
    Friend WithEvents tpGoodInfoFromMC As System.Windows.Forms.TabPage
    Friend WithEvents btCreateMCBulk As System.Windows.Forms.Button
    Friend WithEvents TitleTextBox As System.Windows.Forms.TextBox
    Friend WithEvents tbFeePayPalCurrency As System.Windows.Forms.TextBox
    Friend WithEvents tbPayPalFeeAmount As System.Windows.Forms.TextBox
    Friend WithEvents CurrencyIDTextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents ValueTextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents cbAddressIsCorrect As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents NameTextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents IMoySkladDataProvider_AddressBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PhoneTextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents CountryTextBox As System.Windows.Forms.TextBox
    Friend WithEvents CityTextBox As System.Windows.Forms.TextBox
    Friend WithEvents StreetTextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents PostIndexTextBox As System.Windows.Forms.TextBox
    Friend WithEvents StateTextBox As System.Windows.Forms.TextBox
    Friend WithEvents lbCustomers As System.Windows.Forms.ListBox
    Friend WithEvents btSearchClientByFullName As System.Windows.Forms.Button
    Friend WithEvents btLoadMC As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lbClientInterest As System.Windows.Forms.ListBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents rtbClientInterestDetails As System.Windows.Forms.RichTextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lbClientTags As System.Windows.Forms.ListBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents rtbClientComment As System.Windows.Forms.RichTextBox
    Friend WithEvents tbTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents rtbPaymentComment As System.Windows.Forms.RichTextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents rtbPaymentPurpose As System.Windows.Forms.RichTextBox
    Friend WithEvents lbPaymentUUID As System.Windows.Forms.Label
    Friend WithEvents btSendParcel As System.Windows.Forms.Button
    Friend WithEvents lbGoodUUID As System.Windows.Forms.Label
    Friend WithEvents lbOrderUUID As System.Windows.Forms.Label
    Friend WithEvents lbDemandUUID As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lbShipWokerUUID As System.Windows.Forms.Label
    Friend WithEvents lbWokers As System.Windows.Forms.ListBox
    Friend WithEvents tbctlAddressExternal As System.Windows.Forms.TabControl
    Friend WithEvents tpAddressEbay As System.Windows.Forms.TabPage
    Friend WithEvents tbAddressPayPal As System.Windows.Forms.TabPage
    Friend WithEvents tpInDBTrilbone As System.Windows.Forms.TabPage
    Friend WithEvents btSaveInDb As System.Windows.Forms.Button
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents tbTrilboneFee As System.Windows.Forms.TextBox
    Friend WithEvents tbNalogFee As System.Windows.Forms.TextBox
    Friend WithEvents tbShipmentOutFee As System.Windows.Forms.TextBox
    Friend WithEvents tbExportFee As System.Windows.Forms.TextBox
    Friend WithEvents tbInsectionFee As System.Windows.Forms.TextBox
    Friend WithEvents tbMoneyOutFee As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents btMoneyOutCalculate As System.Windows.Forms.Button
    Friend WithEvents btTrilboneCalculate As System.Windows.Forms.Button
    Friend WithEvents btNalogCalculate As System.Windows.Forms.Button
    Friend WithEvents tbTrilboneBase As System.Windows.Forms.TextBox
    Friend WithEvents tbNalogBase As System.Windows.Forms.TextBox
    Friend WithEvents tbMoneyOutBase As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents tbTrilboneTax As System.Windows.Forms.TextBox
    Friend WithEvents tbNalogTax As System.Windows.Forms.TextBox
    Friend WithEvents tbWeightTax As System.Windows.Forms.TextBox
    Friend WithEvents tbWeight As System.Windows.Forms.TextBox
    Friend WithEvents tbMoneyOutTax As System.Windows.Forms.TextBox
    Friend WithEvents btWeightQuery As System.Windows.Forms.Button
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents btGetFullAmount As System.Windows.Forms.Button
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents btShipmentOutFee As System.Windows.Forms.Button
    Friend WithEvents btWeightCalculate As System.Windows.Forms.Button
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents tbFullAmount As System.Windows.Forms.TextBox
    Friend WithEvents btGetResorceFee As System.Windows.Forms.Button
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents tbCalcTotal As System.Windows.Forms.TextBox
    Friend WithEvents btTotal As System.Windows.Forms.Button
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents tbSubTotal As System.Windows.Forms.TextBox
    Friend WithEvents btSubTotal As System.Windows.Forms.Button
    Friend WithEvents tbCalcTotalPerOne As System.Windows.Forms.TextBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents tbPersonCount As System.Windows.Forms.TextBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents btPersonCalc As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents AmountPaidDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AdjustmentAmountDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ConvertedAdjustmentAmountDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BuyerDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShippingDetailsDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ConvertedAmountPaidDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ConvertedTransactionPriceDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreatedDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreatedDateSpecifiedDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DepositTypeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DepositTypeSpecifiedDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ItemDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuantityPurchasedDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuantityPurchasedSpecifiedDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents StatusDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TransactionIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TransactionPriceDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BestOfferSaleDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents BestOfferSaleSpecifiedDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents VATPercentDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VATPercentSpecifiedDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents SellingManagerProductDetailsDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShippingServiceSelectedDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BuyerMessageDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DutchAuctionBidDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BuyerPaidStatusDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BuyerPaidStatusSpecifiedDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents SellerPaidStatusDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SellerPaidStatusSpecifiedDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents PaidTimeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PaidTimeSpecifiedDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ShippedTimeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShippedTimeSpecifiedDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents TotalPriceDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FeedbackLeftDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FeedbackReceivedDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ContainingOrderDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FinalValueFeeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ListingCheckoutRedirectPreferenceDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TransactionSiteIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TransactionSiteIDSpecifiedDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents PlatformDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PlatformSpecifiedDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents CartIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SellerContactBuyerByEmailDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents SellerContactBuyerByEmailSpecifiedDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents PayPalEmailAddressDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PaisaPayIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BuyerGuaranteePriceDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VariationDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BuyerCheckoutMessageDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TaxesDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BundlePurchaseDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents BundlePurchaseSpecifiedDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ActualShippingCostDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ActualHandlingCostDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OrderLineItemIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PaymentHoldDetailsDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SellerDiscountsDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RefundAmountDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RefundStatusDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CodiceFiscaleDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IsMultiLegShippingDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents IsMultiLegShippingSpecifiedDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents MultiLegShippingDetailsDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceSentTimeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceSentTimeSpecifiedDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents UnpaidItemDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IntangibleItemDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents IntangibleItemSpecifiedDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents MonetaryDetailsDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PickupDetailsDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PickupMethodSelectedDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShippingConvenienceChargeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LogisticsPlanTypeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BuyerPackageEnclosuresDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InventoryReservationIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ExtendedOrderIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lbShipped As System.Windows.Forms.Label
    Friend WithEvents lbPaid As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents btLeaveFeedback As System.Windows.Forms.Button
    Friend WithEvents tbfeedback As System.Windows.Forms.TextBox
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage

End Class
