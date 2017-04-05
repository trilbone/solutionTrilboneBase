Imports nopRestClient

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UC_ebay
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
        Me.bs_FieldItemList = New System.Windows.Forms.BindingSource(Me.components)
        Me.bs_AgentFieldList = New System.Windows.Forms.BindingSource(Me.components)
        Me.bs_AuctionAgentList = New System.Windows.Forms.BindingSource(Me.components)
        Me.bs_Root = New System.Windows.Forms.BindingSource(Me.components)
        Me.ITEMBindingSource_title = New System.Windows.Forms.BindingSource(Me.components)
        Me.BindingSourceClients = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.btCreateTextDescription = New System.Windows.Forms.Button()
        Me.pnAccounts = New System.Windows.Forms.FlowLayoutPanel()
        Me.gbCategory = New System.Windows.Forms.GroupBox()
        Me.cbCategory = New System.Windows.Forms.ComboBox()
        Me.cbStoreCategory2 = New System.Windows.Forms.ComboBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.cbCategory2 = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cbStoreCategory = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btOpenCategoryForm = New System.Windows.Forms.Button()
        Me.btToAuction = New System.Windows.Forms.Button()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.btCopyTosourceFromArhive = New System.Windows.Forms.Button()
        Me.lblPhotoSources = New System.Windows.Forms.ListBox()
        Me.gbShipping = New System.Windows.Forms.GroupBox()
        Me.cbxeBayUK = New System.Windows.Forms.CheckBox()
        Me.cbxFreeShipping = New System.Windows.Forms.CheckBox()
        Me.cbxPrivateListing = New System.Windows.Forms.CheckBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.btShippingConvertation = New System.Windows.Forms.Button()
        Me.cbPayPal = New System.Windows.Forms.ComboBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.tbInterShipCostUSD = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.tbDomesticShipCostUSD = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lbCurrency1 = New System.Windows.Forms.Label()
        Me.tbInterShipCost = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lbCurrency = New System.Windows.Forms.Label()
        Me.tbDomesticShipCost = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbWeightKG = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbWeightOZ = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tbWeightLBS = New System.Windows.Forms.TextBox()
        Me.gbReclama = New System.Windows.Forms.GroupBox()
        Me.cbxValuePack = New System.Windows.Forms.CheckBox()
        Me.cbxBoldTitle = New System.Windows.Forms.CheckBox()
        Me.cbxPicturePack = New System.Windows.Forms.CheckBox()
        Me.cbxGalleryPlus = New System.Windows.Forms.CheckBox()
        Me.gbListingtype = New System.Windows.Forms.GroupBox()
        Me.btGetPrice = New System.Windows.Forms.Button()
        Me.pnAuctionType = New System.Windows.Forms.FlowLayoutPanel()
        Me.cbxAcceptOffers = New System.Windows.Forms.CheckBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.tbReserveAuctionPriceUSD = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.tbStartAuctionPriceUSD = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cbListingType = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.tbBuyItNowPriceUSD = New System.Windows.Forms.TextBox()
        Me.cbxBuyItNow = New System.Windows.Forms.CheckBox()
        Me.gbTitle = New System.Windows.Forms.GroupBox()
        Me.lbWordRemainSub = New System.Windows.Forms.Label()
        Me.lbWorldRemain = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.tbItemSpecificTotal = New System.Windows.Forms.TextBox()
        Me.cbGeologyAge = New System.Windows.Forms.ComboBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.cbCountry = New System.Windows.Forms.ComboBox()
        Me.btAddName = New System.Windows.Forms.Button()
        Me.cbxAddSuffics = New System.Windows.Forms.CheckBox()
        Me.cbxRarePrefix = New System.Windows.Forms.CheckBox()
        Me.btSetSubTitle = New System.Windows.Forms.Button()
        Me.btAddSubTitle = New System.Windows.Forms.Button()
        Me.btRemoveSubTitle = New System.Windows.Forms.Button()
        Me.cbSubTitles = New System.Windows.Forms.ComboBox()
        Me.cbxEnableSubTitle = New System.Windows.Forms.CheckBox()
        Me.btSetTitle = New System.Windows.Forms.Button()
        Me.btRemoveTitle = New System.Windows.Forms.Button()
        Me.tbTitleValue = New System.Windows.Forms.TextBox()
        Me.btAddTitle = New System.Windows.Forms.Button()
        Me.lblTitles = New System.Windows.Forms.ListBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.UserControlQalityEbay = New Service.UserControlQality()
        Me.bs_AgentParameters = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.bs_FieldItemList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bs_AgentFieldList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bs_AuctionAgentList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bs_Root, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ITEMBindingSource_title, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingSourceClients, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbCategory.SuspendLayout()
        Me.gbShipping.SuspendLayout()
        Me.gbReclama.SuspendLayout()
        Me.gbListingtype.SuspendLayout()
        Me.gbTitle.SuspendLayout()
        CType(Me.bs_AgentParameters, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'bs_FieldItemList
        '
        Me.bs_FieldItemList.DataSource = Me.bs_AgentFieldList
        '
        'bs_AgentFieldList
        '
        Me.bs_AgentFieldList.DataMember = "FIELD"
        Me.bs_AgentFieldList.DataSource = Me.bs_AuctionAgentList
        '
        'bs_AuctionAgentList
        '
        Me.bs_AuctionAgentList.DataMember = "AGENT"
        Me.bs_AuctionAgentList.DataSource = GetType(Service.Agents.AUCTIONAGENT)
        '
        'ITEMBindingSource_title
        '
        Me.ITEMBindingSource_title.DataMember = "ITEM"
        Me.ITEMBindingSource_title.DataSource = Me.bs_FieldItemList
        Me.ITEMBindingSource_title.Filter = "name='title'"
        '
        'Label26
        '
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label26.Location = New System.Drawing.Point(3, 304)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(114, 42)
        Me.Label26.TabIndex = 57
        Me.Label26.Text = "1. Проветрить описание <<"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label25
        '
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label25.Location = New System.Drawing.Point(5, 344)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(114, 42)
        Me.Label25.TabIndex = 56
        Me.Label25.Text = "2, Заполнить поля листинга >>"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btCreateTextDescription
        '
        Me.btCreateTextDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btCreateTextDescription.Location = New System.Drawing.Point(3, 542)
        Me.btCreateTextDescription.Name = "btCreateTextDescription"
        Me.btCreateTextDescription.Size = New System.Drawing.Size(119, 71)
        Me.btCreateTextDescription.TabIndex = 55
        Me.btCreateTextDescription.Text = "Прямая коррекция описания"
        Me.btCreateTextDescription.UseVisualStyleBackColor = True
        '
        'pnAccounts
        '
        Me.pnAccounts.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.pnAccounts.Location = New System.Drawing.Point(0, 11)
        Me.pnAccounts.Name = "pnAccounts"
        Me.pnAccounts.Size = New System.Drawing.Size(119, 141)
        Me.pnAccounts.TabIndex = 54
        '
        'gbCategory
        '
        Me.gbCategory.Controls.Add(Me.cbCategory)
        Me.gbCategory.Controls.Add(Me.cbStoreCategory2)
        Me.gbCategory.Controls.Add(Me.Label22)
        Me.gbCategory.Controls.Add(Me.cbCategory2)
        Me.gbCategory.Controls.Add(Me.Label10)
        Me.gbCategory.Controls.Add(Me.Label8)
        Me.gbCategory.Controls.Add(Me.cbStoreCategory)
        Me.gbCategory.Controls.Add(Me.Label9)
        Me.gbCategory.Controls.Add(Me.btOpenCategoryForm)
        Me.gbCategory.Location = New System.Drawing.Point(125, 422)
        Me.gbCategory.Name = "gbCategory"
        Me.gbCategory.Size = New System.Drawing.Size(469, 193)
        Me.gbCategory.TabIndex = 53
        Me.gbCategory.TabStop = False
        Me.gbCategory.Text = "Категории Ebay и магазина"
        '
        'cbCategory
        '
        Me.cbCategory.FormattingEnabled = True
        Me.cbCategory.Location = New System.Drawing.Point(10, 37)
        Me.cbCategory.Name = "cbCategory"
        Me.cbCategory.Size = New System.Drawing.Size(450, 21)
        Me.cbCategory.TabIndex = 7
        '
        'cbStoreCategory2
        '
        Me.cbStoreCategory2.FormattingEnabled = True
        Me.cbStoreCategory2.Location = New System.Drawing.Point(10, 165)
        Me.cbStoreCategory2.Name = "cbStoreCategory2"
        Me.cbStoreCategory2.Size = New System.Drawing.Size(450, 21)
        Me.cbStoreCategory2.TabIndex = 27
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(13, 149)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(239, 13)
        Me.Label22.TabIndex = 26
        Me.Label22.Text = "(Store Category 2) Вторая категория Магазина"
        '
        'cbCategory2
        '
        Me.cbCategory2.FormattingEnabled = True
        Me.cbCategory2.Location = New System.Drawing.Point(10, 80)
        Me.cbCategory2.Name = "cbCategory2"
        Me.cbCategory2.Size = New System.Drawing.Size(450, 21)
        Me.cbCategory2.TabIndex = 24
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(13, 64)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(185, 13)
        Me.Label10.TabIndex = 23
        Me.Label10.Text = "(Category 2) Вторая категория eBay"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label8.Location = New System.Drawing.Point(13, 21)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(251, 13)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "(Category) Категория eBay - обязательно"
        '
        'cbStoreCategory
        '
        Me.cbStoreCategory.FormattingEnabled = True
        Me.cbStoreCategory.Location = New System.Drawing.Point(10, 124)
        Me.cbStoreCategory.Name = "cbStoreCategory"
        Me.cbStoreCategory.Size = New System.Drawing.Size(450, 21)
        Me.cbStoreCategory.TabIndex = 10
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(13, 108)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(192, 13)
        Me.Label9.TabIndex = 9
        Me.Label9.Text = "(Store Category) Категория Магазина"
        '
        'btOpenCategoryForm
        '
        Me.btOpenCategoryForm.Enabled = False
        Me.btOpenCategoryForm.Location = New System.Drawing.Point(377, 9)
        Me.btOpenCategoryForm.Name = "btOpenCategoryForm"
        Me.btOpenCategoryForm.Size = New System.Drawing.Size(82, 23)
        Me.btOpenCategoryForm.TabIndex = 11
        Me.btOpenCategoryForm.Text = "управлять.."
        Me.btOpenCategoryForm.UseVisualStyleBackColor = True
        '
        'btToAuction
        '
        Me.btToAuction.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btToAuction.Location = New System.Drawing.Point(3, 446)
        Me.btToAuction.Name = "btToAuction"
        Me.btToAuction.Size = New System.Drawing.Size(118, 53)
        Me.btToAuction.TabIndex = 48
        Me.btToAuction.Text = "4. Выставить"
        Me.btToAuction.UseVisualStyleBackColor = True
        '
        'Label20
        '
        Me.Label20.Location = New System.Drawing.Point(9, 166)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(100, 32)
        Me.Label20.TabIndex = 51
        Me.Label20.Text = "Фото загрузить на ресурс:"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btCopyTosourceFromArhive
        '
        Me.btCopyTosourceFromArhive.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btCopyTosourceFromArhive.Location = New System.Drawing.Point(3, 392)
        Me.btCopyTosourceFromArhive.Name = "btCopyTosourceFromArhive"
        Me.btCopyTosourceFromArhive.Size = New System.Drawing.Size(119, 45)
        Me.btCopyTosourceFromArhive.TabIndex = 52
        Me.btCopyTosourceFromArhive.Text = "3. Загрузить фото в eBay"
        Me.btCopyTosourceFromArhive.UseVisualStyleBackColor = True
        '
        'lblPhotoSources
        '
        Me.lblPhotoSources.FormattingEnabled = True
        Me.lblPhotoSources.Location = New System.Drawing.Point(1, 203)
        Me.lblPhotoSources.Name = "lblPhotoSources"
        Me.lblPhotoSources.Size = New System.Drawing.Size(120, 95)
        Me.lblPhotoSources.TabIndex = 50
        '
        'gbShipping
        '
        Me.gbShipping.Controls.Add(Me.cbxeBayUK)
        Me.gbShipping.Controls.Add(Me.cbxFreeShipping)
        Me.gbShipping.Controls.Add(Me.cbxPrivateListing)
        Me.gbShipping.Controls.Add(Me.Label16)
        Me.gbShipping.Controls.Add(Me.btShippingConvertation)
        Me.gbShipping.Controls.Add(Me.cbPayPal)
        Me.gbShipping.Controls.Add(Me.Label18)
        Me.gbShipping.Controls.Add(Me.tbInterShipCostUSD)
        Me.gbShipping.Controls.Add(Me.Label17)
        Me.gbShipping.Controls.Add(Me.tbDomesticShipCostUSD)
        Me.gbShipping.Controls.Add(Me.Label5)
        Me.gbShipping.Controls.Add(Me.lbCurrency1)
        Me.gbShipping.Controls.Add(Me.tbInterShipCost)
        Me.gbShipping.Controls.Add(Me.Label7)
        Me.gbShipping.Controls.Add(Me.lbCurrency)
        Me.gbShipping.Controls.Add(Me.tbDomesticShipCost)
        Me.gbShipping.Controls.Add(Me.Label1)
        Me.gbShipping.Controls.Add(Me.tbWeightKG)
        Me.gbShipping.Controls.Add(Me.Label4)
        Me.gbShipping.Controls.Add(Me.Label2)
        Me.gbShipping.Controls.Add(Me.tbWeightOZ)
        Me.gbShipping.Controls.Add(Me.Label3)
        Me.gbShipping.Controls.Add(Me.tbWeightLBS)
        Me.gbShipping.Location = New System.Drawing.Point(598, 479)
        Me.gbShipping.Name = "gbShipping"
        Me.gbShipping.Size = New System.Drawing.Size(408, 134)
        Me.gbShipping.TabIndex = 49
        Me.gbShipping.TabStop = False
        Me.gbShipping.Text = "Шиппинг и PayPal"
        '
        'cbxeBayUK
        '
        Me.cbxeBayUK.AutoSize = True
        Me.cbxeBayUK.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.cbxeBayUK.Location = New System.Drawing.Point(296, 23)
        Me.cbxeBayUK.Name = "cbxeBayUK"
        Me.cbxeBayUK.Size = New System.Drawing.Size(108, 17)
        Me.cbxeBayUK.TabIndex = 44
        Me.cbxeBayUK.Text = "eBayUK ($0.5)"
        Me.cbxeBayUK.UseVisualStyleBackColor = True
        '
        'cbxFreeShipping
        '
        Me.cbxFreeShipping.AutoSize = True
        Me.cbxFreeShipping.Location = New System.Drawing.Point(296, 63)
        Me.cbxFreeShipping.Name = "cbxFreeShipping"
        Me.cbxFreeShipping.Size = New System.Drawing.Size(89, 17)
        Me.cbxFreeShipping.TabIndex = 43
        Me.cbxFreeShipping.Text = "Free shipping"
        Me.cbxFreeShipping.UseVisualStyleBackColor = True
        '
        'cbxPrivateListing
        '
        Me.cbxPrivateListing.AutoSize = True
        Me.cbxPrivateListing.Checked = True
        Me.cbxPrivateListing.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbxPrivateListing.Location = New System.Drawing.Point(296, 109)
        Me.cbxPrivateListing.Name = "cbxPrivateListing"
        Me.cbxPrivateListing.Size = New System.Drawing.Size(88, 17)
        Me.cbxPrivateListing.TabIndex = 16
        Me.cbxPrivateListing.Text = "Private listing"
        Me.cbxPrivateListing.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label16.Location = New System.Drawing.Point(8, 111)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(54, 13)
        Me.Label16.TabIndex = 19
        Me.Label16.Text = "PAYPAL"
        '
        'btShippingConvertation
        '
        Me.btShippingConvertation.Location = New System.Drawing.Point(171, 59)
        Me.btShippingConvertation.Name = "btShippingConvertation"
        Me.btShippingConvertation.Size = New System.Drawing.Size(24, 23)
        Me.btShippingConvertation.TabIndex = 39
        Me.btShippingConvertation.Text = ">"
        Me.btShippingConvertation.UseVisualStyleBackColor = True
        '
        'cbPayPal
        '
        Me.cbPayPal.FormattingEnabled = True
        Me.cbPayPal.Items.AddRange(New Object() {"eugeny.litvinov@mail.ru", "fossilcollecting@gmail.com"})
        Me.cbPayPal.Location = New System.Drawing.Point(70, 107)
        Me.cbPayPal.Name = "cbPayPal"
        Me.cbPayPal.Size = New System.Drawing.Size(191, 21)
        Me.cbPayPal.TabIndex = 18
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(254, 79)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(24, 13)
        Me.Label18.TabIndex = 38
        Me.Label18.Text = "usd"
        '
        'tbInterShipCostUSD
        '
        Me.tbInterShipCostUSD.Location = New System.Drawing.Point(201, 76)
        Me.tbInterShipCostUSD.Name = "tbInterShipCostUSD"
        Me.tbInterShipCostUSD.Size = New System.Drawing.Size(47, 20)
        Me.tbInterShipCostUSD.TabIndex = 37
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(254, 52)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(24, 13)
        Me.Label17.TabIndex = 36
        Me.Label17.Text = "usd"
        '
        'tbDomesticShipCostUSD
        '
        Me.tbDomesticShipCostUSD.Location = New System.Drawing.Point(201, 49)
        Me.tbDomesticShipCostUSD.Name = "tbDomesticShipCostUSD"
        Me.tbDomesticShipCostUSD.Size = New System.Drawing.Size(47, 20)
        Me.tbDomesticShipCostUSD.TabIndex = 35
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(10, 21)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(41, 13)
        Me.Label5.TabIndex = 34
        Me.Label5.Text = "Брутто"
        '
        'lbCurrency1
        '
        Me.lbCurrency1.AutoSize = True
        Me.lbCurrency1.Location = New System.Drawing.Point(138, 77)
        Me.lbCurrency1.Name = "lbCurrency1"
        Me.lbCurrency1.Size = New System.Drawing.Size(28, 13)
        Me.lbCurrency1.TabIndex = 33
        Me.lbCurrency1.Text = "euro"
        '
        'tbInterShipCost
        '
        Me.tbInterShipCost.Location = New System.Drawing.Point(85, 74)
        Me.tbInterShipCost.Name = "tbInterShipCost"
        Me.tbInterShipCost.Size = New System.Drawing.Size(47, 20)
        Me.tbInterShipCost.TabIndex = 32
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(13, 77)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(65, 13)
        Me.Label7.TabIndex = 31
        Me.Label7.Text = "International"
        '
        'lbCurrency
        '
        Me.lbCurrency.AutoSize = True
        Me.lbCurrency.Location = New System.Drawing.Point(138, 51)
        Me.lbCurrency.Name = "lbCurrency"
        Me.lbCurrency.Size = New System.Drawing.Size(28, 13)
        Me.lbCurrency.TabIndex = 30
        Me.lbCurrency.Text = "euro"
        '
        'tbDomesticShipCost
        '
        Me.tbDomesticShipCost.Location = New System.Drawing.Point(85, 48)
        Me.tbDomesticShipCost.Name = "tbDomesticShipCost"
        Me.tbDomesticShipCost.Size = New System.Drawing.Size(47, 20)
        Me.tbDomesticShipCost.TabIndex = 29
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(27, 51)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 28
        Me.Label1.Text = "Domestic"
        '
        'tbWeightKG
        '
        Me.tbWeightKG.Location = New System.Drawing.Point(58, 19)
        Me.tbWeightKG.Name = "tbWeightKG"
        Me.tbWeightKG.Size = New System.Drawing.Size(50, 20)
        Me.tbWeightKG.TabIndex = 22
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(258, 24)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(18, 13)
        Me.Label4.TabIndex = 27
        Me.Label4.Text = "oz"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(115, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(19, 13)
        Me.Label2.TabIndex = 23
        Me.Label2.Text = "kg"
        '
        'tbWeightOZ
        '
        Me.tbWeightOZ.Enabled = False
        Me.tbWeightOZ.Location = New System.Drawing.Point(216, 19)
        Me.tbWeightOZ.Name = "tbWeightOZ"
        Me.tbWeightOZ.Size = New System.Drawing.Size(36, 20)
        Me.tbWeightOZ.TabIndex = 26
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(186, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(20, 13)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "lbs"
        '
        'tbWeightLBS
        '
        Me.tbWeightLBS.Enabled = False
        Me.tbWeightLBS.Location = New System.Drawing.Point(141, 19)
        Me.tbWeightLBS.Name = "tbWeightLBS"
        Me.tbWeightLBS.Size = New System.Drawing.Size(40, 20)
        Me.tbWeightLBS.TabIndex = 24
        '
        'gbReclama
        '
        Me.gbReclama.Controls.Add(Me.cbxValuePack)
        Me.gbReclama.Controls.Add(Me.cbxBoldTitle)
        Me.gbReclama.Controls.Add(Me.cbxPicturePack)
        Me.gbReclama.Controls.Add(Me.cbxGalleryPlus)
        Me.gbReclama.Enabled = False
        Me.gbReclama.Location = New System.Drawing.Point(598, 399)
        Me.gbReclama.Name = "gbReclama"
        Me.gbReclama.Size = New System.Drawing.Size(408, 74)
        Me.gbReclama.TabIndex = 47
        Me.gbReclama.TabStop = False
        Me.gbReclama.Text = "Рекламные удорожители"
        '
        'cbxValuePack
        '
        Me.cbxValuePack.AutoSize = True
        Me.cbxValuePack.Location = New System.Drawing.Point(208, 45)
        Me.cbxValuePack.Name = "cbxValuePack"
        Me.cbxValuePack.Size = New System.Drawing.Size(184, 17)
        Me.cbxValuePack.TabIndex = 3
        Me.cbxValuePack.Text = "Value Pack все вместе +subtitle"
        Me.cbxValuePack.UseVisualStyleBackColor = True
        '
        'cbxBoldTitle
        '
        Me.cbxBoldTitle.AutoSize = True
        Me.cbxBoldTitle.Location = New System.Drawing.Point(208, 22)
        Me.cbxBoldTitle.Name = "cbxBoldTitle"
        Me.cbxBoldTitle.Size = New System.Drawing.Size(126, 17)
        Me.cbxBoldTitle.TabIndex = 2
        Me.cbxBoldTitle.Text = "Bold (жирный титул)"
        Me.cbxBoldTitle.UseVisualStyleBackColor = True
        '
        'cbxPicturePack
        '
        Me.cbxPicturePack.AutoSize = True
        Me.cbxPicturePack.Location = New System.Drawing.Point(13, 46)
        Me.cbxPicturePack.Name = "cbxPicturePack"
        Me.cbxPicturePack.Size = New System.Drawing.Size(137, 17)
        Me.cbxPicturePack.TabIndex = 1
        Me.cbxPicturePack.Text = "Picture Pack (галерея)"
        Me.cbxPicturePack.UseVisualStyleBackColor = True
        '
        'cbxGalleryPlus
        '
        Me.cbxGalleryPlus.AutoSize = True
        Me.cbxGalleryPlus.Location = New System.Drawing.Point(12, 23)
        Me.cbxGalleryPlus.Name = "cbxGalleryPlus"
        Me.cbxGalleryPlus.Size = New System.Drawing.Size(190, 17)
        Me.cbxGalleryPlus.TabIndex = 0
        Me.cbxGalleryPlus.Text = "Gallery plus (лупа Enlage у фоток)"
        Me.cbxGalleryPlus.UseVisualStyleBackColor = True
        '
        'gbListingtype
        '
        Me.gbListingtype.Controls.Add(Me.btGetPrice)
        Me.gbListingtype.Controls.Add(Me.pnAuctionType)
        Me.gbListingtype.Controls.Add(Me.cbxAcceptOffers)
        Me.gbListingtype.Controls.Add(Me.Label14)
        Me.gbListingtype.Controls.Add(Me.tbReserveAuctionPriceUSD)
        Me.gbListingtype.Controls.Add(Me.Label15)
        Me.gbListingtype.Controls.Add(Me.Label13)
        Me.gbListingtype.Controls.Add(Me.tbStartAuctionPriceUSD)
        Me.gbListingtype.Controls.Add(Me.Label12)
        Me.gbListingtype.Controls.Add(Me.cbListingType)
        Me.gbListingtype.Controls.Add(Me.Label11)
        Me.gbListingtype.Controls.Add(Me.tbBuyItNowPriceUSD)
        Me.gbListingtype.Controls.Add(Me.cbxBuyItNow)
        Me.gbListingtype.Location = New System.Drawing.Point(598, 265)
        Me.gbListingtype.Name = "gbListingtype"
        Me.gbListingtype.Size = New System.Drawing.Size(408, 131)
        Me.gbListingtype.TabIndex = 46
        Me.gbListingtype.TabStop = False
        Me.gbListingtype.Text = "Тип листинга и цена"
        '
        'btGetPrice
        '
        Me.btGetPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btGetPrice.Location = New System.Drawing.Point(293, 101)
        Me.btGetPrice.Name = "btGetPrice"
        Me.btGetPrice.Size = New System.Drawing.Size(109, 23)
        Me.btGetPrice.TabIndex = 33
        Me.btGetPrice.Text = "Получить цену"
        Me.btGetPrice.UseVisualStyleBackColor = True
        '
        'pnAuctionType
        '
        Me.pnAuctionType.Location = New System.Drawing.Point(16, 46)
        Me.pnAuctionType.Name = "pnAuctionType"
        Me.pnAuctionType.Size = New System.Drawing.Size(386, 50)
        Me.pnAuctionType.TabIndex = 32
        '
        'cbxAcceptOffers
        '
        Me.cbxAcceptOffers.AutoSize = True
        Me.cbxAcceptOffers.Location = New System.Drawing.Point(295, 17)
        Me.cbxAcceptOffers.Name = "cbxAcceptOffers"
        Me.cbxAcceptOffers.Size = New System.Drawing.Size(91, 17)
        Me.cbxAcceptOffers.TabIndex = 31
        Me.cbxAcceptOffers.Text = "Accept Offers"
        Me.cbxAcceptOffers.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(257, 107)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(30, 13)
        Me.Label14.TabIndex = 15
        Me.Label14.Text = "USD"
        '
        'tbReserveAuctionPriceUSD
        '
        Me.tbReserveAuctionPriceUSD.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.tbReserveAuctionPriceUSD.Location = New System.Drawing.Point(195, 102)
        Me.tbReserveAuctionPriceUSD.Name = "tbReserveAuctionPriceUSD"
        Me.tbReserveAuctionPriceUSD.Size = New System.Drawing.Size(57, 22)
        Me.tbReserveAuctionPriceUSD.TabIndex = 14
        Me.tbReserveAuctionPriceUSD.Text = "9999.99"
        Me.tbReserveAuctionPriceUSD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(144, 107)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(47, 13)
        Me.Label15.TabIndex = 13
        Me.Label15.Text = "Reserve"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(109, 107)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(30, 13)
        Me.Label13.TabIndex = 12
        Me.Label13.Text = "USD"
        '
        'tbStartAuctionPriceUSD
        '
        Me.tbStartAuctionPriceUSD.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.tbStartAuctionPriceUSD.Location = New System.Drawing.Point(47, 102)
        Me.tbStartAuctionPriceUSD.Name = "tbStartAuctionPriceUSD"
        Me.tbStartAuctionPriceUSD.Size = New System.Drawing.Size(57, 22)
        Me.tbStartAuctionPriceUSD.TabIndex = 11
        Me.tbStartAuctionPriceUSD.Text = "9999.99"
        Me.tbStartAuctionPriceUSD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(14, 107)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(29, 13)
        Me.Label12.TabIndex = 10
        Me.Label12.Text = "Start"
        '
        'cbListingType
        '
        Me.cbListingType.FormattingEnabled = True
        Me.cbListingType.Location = New System.Drawing.Point(14, 17)
        Me.cbListingType.Name = "cbListingType"
        Me.cbListingType.Size = New System.Drawing.Size(81, 21)
        Me.cbListingType.TabIndex = 9
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(253, 20)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(30, 13)
        Me.Label11.TabIndex = 8
        Me.Label11.Text = "USD"
        '
        'tbBuyItNowPriceUSD
        '
        Me.tbBuyItNowPriceUSD.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.tbBuyItNowPriceUSD.Location = New System.Drawing.Point(191, 15)
        Me.tbBuyItNowPriceUSD.Name = "tbBuyItNowPriceUSD"
        Me.tbBuyItNowPriceUSD.Size = New System.Drawing.Size(57, 22)
        Me.tbBuyItNowPriceUSD.TabIndex = 7
        Me.tbBuyItNowPriceUSD.Text = "9999.99"
        Me.tbBuyItNowPriceUSD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cbxBuyItNow
        '
        Me.cbxBuyItNow.AutoSize = True
        Me.cbxBuyItNow.Location = New System.Drawing.Point(115, 18)
        Me.cbxBuyItNow.Name = "cbxBuyItNow"
        Me.cbxBuyItNow.Size = New System.Drawing.Size(72, 17)
        Me.cbxBuyItNow.TabIndex = 6
        Me.cbxBuyItNow.Text = "BuyItNow"
        Me.cbxBuyItNow.UseVisualStyleBackColor = True
        '
        'gbTitle
        '
        Me.gbTitle.Controls.Add(Me.lbWordRemainSub)
        Me.gbTitle.Controls.Add(Me.lbWorldRemain)
        Me.gbTitle.Controls.Add(Me.Label21)
        Me.gbTitle.Controls.Add(Me.tbItemSpecificTotal)
        Me.gbTitle.Controls.Add(Me.cbGeologyAge)
        Me.gbTitle.Controls.Add(Me.Label23)
        Me.gbTitle.Controls.Add(Me.cbCountry)
        Me.gbTitle.Controls.Add(Me.btAddName)
        Me.gbTitle.Controls.Add(Me.cbxAddSuffics)
        Me.gbTitle.Controls.Add(Me.cbxRarePrefix)
        Me.gbTitle.Controls.Add(Me.btSetSubTitle)
        Me.gbTitle.Controls.Add(Me.btAddSubTitle)
        Me.gbTitle.Controls.Add(Me.btRemoveSubTitle)
        Me.gbTitle.Controls.Add(Me.cbSubTitles)
        Me.gbTitle.Controls.Add(Me.cbxEnableSubTitle)
        Me.gbTitle.Controls.Add(Me.btSetTitle)
        Me.gbTitle.Controls.Add(Me.btRemoveTitle)
        Me.gbTitle.Controls.Add(Me.tbTitleValue)
        Me.gbTitle.Controls.Add(Me.btAddTitle)
        Me.gbTitle.Controls.Add(Me.lblTitles)
        Me.gbTitle.Controls.Add(Me.Label6)
        Me.gbTitle.Location = New System.Drawing.Point(125, 4)
        Me.gbTitle.Name = "gbTitle"
        Me.gbTitle.Size = New System.Drawing.Size(469, 412)
        Me.gbTitle.TabIndex = 45
        Me.gbTitle.TabStop = False
        Me.gbTitle.Text = "Название в листинге, категория, состояние обьекта"
        '
        'lbWordRemainSub
        '
        Me.lbWordRemainSub.AutoSize = True
        Me.lbWordRemainSub.Location = New System.Drawing.Point(179, 366)
        Me.lbWordRemainSub.Name = "lbWordRemainSub"
        Me.lbWordRemainSub.Size = New System.Drawing.Size(53, 13)
        Me.lbWordRemainSub.TabIndex = 31
        Me.lbWordRemainSub.Text = "remain 55"
        '
        'lbWorldRemain
        '
        Me.lbWorldRemain.AutoSize = True
        Me.lbWorldRemain.Location = New System.Drawing.Point(404, 242)
        Me.lbWorldRemain.Name = "lbWorldRemain"
        Me.lbWorldRemain.Size = New System.Drawing.Size(53, 13)
        Me.lbWorldRemain.TabIndex = 30
        Me.lbWorldRemain.Text = "remain 80"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label21.Location = New System.Drawing.Point(8, 333)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(50, 13)
        Me.Label21.TabIndex = 29
        Me.Label21.Text = "I. spec."
        '
        'tbItemSpecificTotal
        '
        Me.tbItemSpecificTotal.Location = New System.Drawing.Point(64, 330)
        Me.tbItemSpecificTotal.Name = "tbItemSpecificTotal"
        Me.tbItemSpecificTotal.Size = New System.Drawing.Size(395, 20)
        Me.tbItemSpecificTotal.TabIndex = 28
        '
        'cbGeologyAge
        '
        Me.cbGeologyAge.FormattingEnabled = True
        Me.cbGeologyAge.Location = New System.Drawing.Point(322, 304)
        Me.cbGeologyAge.Name = "cbGeologyAge"
        Me.cbGeologyAge.Size = New System.Drawing.Size(92, 21)
        Me.cbGeologyAge.TabIndex = 27
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label23.Location = New System.Drawing.Point(176, 287)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(287, 13)
        Me.Label23.TabIndex = 26
        Me.Label23.Text = "страна, возраст = добавится как item specifics"
        '
        'cbCountry
        '
        Me.cbCountry.FormattingEnabled = True
        Me.cbCountry.Location = New System.Drawing.Point(221, 303)
        Me.cbCountry.Name = "cbCountry"
        Me.cbCountry.Size = New System.Drawing.Size(92, 21)
        Me.cbCountry.TabIndex = 25
        '
        'btAddName
        '
        Me.btAddName.Location = New System.Drawing.Point(67, 286)
        Me.btAddName.Name = "btAddName"
        Me.btAddName.Size = New System.Drawing.Size(79, 23)
        Me.btAddName.TabIndex = 23
        Me.btAddName.Text = ">Название"
        Me.btAddName.UseVisualStyleBackColor = True
        '
        'cbxAddSuffics
        '
        Me.cbxAddSuffics.AutoSize = True
        Me.cbxAddSuffics.Location = New System.Drawing.Point(10, 312)
        Me.cbxAddSuffics.Name = "cbxAddSuffics"
        Me.cbxAddSuffics.Size = New System.Drawing.Size(87, 17)
        Me.cbxAddSuffics.TabIndex = 22
        Me.cbxAddSuffics.Text = "from Trilbone"
        Me.cbxAddSuffics.UseVisualStyleBackColor = True
        '
        'cbxRarePrefix
        '
        Me.cbxRarePrefix.AutoSize = True
        Me.cbxRarePrefix.Location = New System.Drawing.Point(11, 289)
        Me.cbxRarePrefix.Name = "cbxRarePrefix"
        Me.cbxRarePrefix.Size = New System.Drawing.Size(56, 17)
        Me.cbxRarePrefix.TabIndex = 21
        Me.cbxRarePrefix.Text = "RARE"
        Me.cbxRarePrefix.UseVisualStyleBackColor = True
        '
        'btSetSubTitle
        '
        Me.btSetSubTitle.Enabled = False
        Me.btSetSubTitle.Location = New System.Drawing.Point(319, 359)
        Me.btSetSubTitle.Name = "btSetSubTitle"
        Me.btSetSubTitle.Size = New System.Drawing.Size(66, 23)
        Me.btSetSubTitle.TabIndex = 19
        Me.btSetSubTitle.Text = "изменить"
        Me.btSetSubTitle.UseVisualStyleBackColor = True
        '
        'btAddSubTitle
        '
        Me.btAddSubTitle.Enabled = False
        Me.btAddSubTitle.Location = New System.Drawing.Point(247, 359)
        Me.btAddSubTitle.Name = "btAddSubTitle"
        Me.btAddSubTitle.Size = New System.Drawing.Size(66, 23)
        Me.btAddSubTitle.TabIndex = 17
        Me.btAddSubTitle.Text = "добавить"
        Me.btAddSubTitle.UseVisualStyleBackColor = True
        '
        'btRemoveSubTitle
        '
        Me.btRemoveSubTitle.Enabled = False
        Me.btRemoveSubTitle.Location = New System.Drawing.Point(391, 359)
        Me.btRemoveSubTitle.Name = "btRemoveSubTitle"
        Me.btRemoveSubTitle.Size = New System.Drawing.Size(66, 23)
        Me.btRemoveSubTitle.TabIndex = 16
        Me.btRemoveSubTitle.Text = "удалить"
        Me.btRemoveSubTitle.UseVisualStyleBackColor = True
        '
        'cbSubTitles
        '
        Me.cbSubTitles.FormattingEnabled = True
        Me.cbSubTitles.Location = New System.Drawing.Point(11, 386)
        Me.cbSubTitles.Name = "cbSubTitles"
        Me.cbSubTitles.Size = New System.Drawing.Size(450, 21)
        Me.cbSubTitles.TabIndex = 4
        '
        'cbxEnableSubTitle
        '
        Me.cbxEnableSubTitle.AutoSize = True
        Me.cbxEnableSubTitle.Location = New System.Drawing.Point(13, 365)
        Me.cbxEnableSubTitle.Name = "cbxEnableSubTitle"
        Me.cbxEnableSubTitle.Size = New System.Drawing.Size(141, 17)
        Me.cbxEnableSubTitle.TabIndex = 3
        Me.cbxEnableSubTitle.Text = "**SubTitle  (за деньги!!)"
        Me.cbxEnableSubTitle.UseVisualStyleBackColor = True
        '
        'btSetTitle
        '
        Me.btSetTitle.Location = New System.Drawing.Point(104, 231)
        Me.btSetTitle.Name = "btSetTitle"
        Me.btSetTitle.Size = New System.Drawing.Size(75, 23)
        Me.btSetTitle.TabIndex = 5
        Me.btSetTitle.Text = "Изменить"
        Me.btSetTitle.UseVisualStyleBackColor = True
        '
        'btRemoveTitle
        '
        Me.btRemoveTitle.Location = New System.Drawing.Point(195, 231)
        Me.btRemoveTitle.Name = "btRemoveTitle"
        Me.btRemoveTitle.Size = New System.Drawing.Size(75, 23)
        Me.btRemoveTitle.TabIndex = 4
        Me.btRemoveTitle.Text = "Удалить"
        Me.btRemoveTitle.UseVisualStyleBackColor = True
        '
        'tbTitleValue
        '
        Me.tbTitleValue.Location = New System.Drawing.Point(13, 263)
        Me.tbTitleValue.Name = "tbTitleValue"
        Me.tbTitleValue.Size = New System.Drawing.Size(447, 20)
        Me.tbTitleValue.TabIndex = 2
        '
        'btAddTitle
        '
        Me.btAddTitle.Location = New System.Drawing.Point(13, 231)
        Me.btAddTitle.Name = "btAddTitle"
        Me.btAddTitle.Size = New System.Drawing.Size(75, 23)
        Me.btAddTitle.TabIndex = 3
        Me.btAddTitle.Text = "Добавить"
        Me.btAddTitle.UseVisualStyleBackColor = True
        '
        'lblTitles
        '
        Me.lblTitles.FormattingEnabled = True
        Me.lblTitles.Location = New System.Drawing.Point(12, 41)
        Me.lblTitles.Name = "lblTitles"
        Me.lblTitles.Size = New System.Drawing.Size(427, 186)
        Me.lblTitles.Sorted = True
        Me.lblTitles.TabIndex = 0
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label6.Location = New System.Drawing.Point(9, 18)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(428, 13)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Title (как в листинге, 80 символов)  <dblClick - втавить выбор в поле>"
        '
        'UserControlQalityEbay
        '
        Me.UserControlQalityEbay.Culture = New System.Globalization.CultureInfo("en-US")
        Me.UserControlQalityEbay.Location = New System.Drawing.Point(600, 6)
        Me.UserControlQalityEbay.Name = "UserControlQalityEbay"
        Me.UserControlQalityEbay.QualityText = ""
        Me.UserControlQalityEbay.Size = New System.Drawing.Size(406, 253)
        Me.UserControlQalityEbay.TabIndex = 58
        Me.UserControlQalityEbay.Tag = ""
        '
        'bs_AgentParameters
        '
        Me.bs_AgentParameters.DataSource = GetType(Service.Agents.clsAgentEbayParameters)
        '
        'UC_ebay
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.UserControlQalityEbay)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.btCreateTextDescription)
        Me.Controls.Add(Me.pnAccounts)
        Me.Controls.Add(Me.gbCategory)
        Me.Controls.Add(Me.btToAuction)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.btCopyTosourceFromArhive)
        Me.Controls.Add(Me.lblPhotoSources)
        Me.Controls.Add(Me.gbShipping)
        Me.Controls.Add(Me.gbReclama)
        Me.Controls.Add(Me.gbListingtype)
        Me.Controls.Add(Me.gbTitle)
        Me.Name = "UC_ebay"
        Me.Size = New System.Drawing.Size(1010, 619)
        CType(Me.bs_FieldItemList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bs_AgentFieldList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bs_AuctionAgentList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bs_Root, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ITEMBindingSource_title, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingSourceClients, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbCategory.ResumeLayout(False)
        Me.gbCategory.PerformLayout()
        Me.gbShipping.ResumeLayout(False)
        Me.gbShipping.PerformLayout()
        Me.gbReclama.ResumeLayout(False)
        Me.gbReclama.PerformLayout()
        Me.gbListingtype.ResumeLayout(False)
        Me.gbListingtype.PerformLayout()
        Me.gbTitle.ResumeLayout(False)
        Me.gbTitle.PerformLayout()
        CType(Me.bs_AgentParameters, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents bs_FieldItemList As System.Windows.Forms.BindingSource
    Friend WithEvents bs_AgentFieldList As System.Windows.Forms.BindingSource
    Friend WithEvents bs_AuctionAgentList As System.Windows.Forms.BindingSource
    Friend WithEvents bs_Root As System.Windows.Forms.BindingSource
    Friend WithEvents bs_AgentParameters As System.Windows.Forms.BindingSource
    Friend WithEvents ITEMBindingSource_title As System.Windows.Forms.BindingSource
    Friend WithEvents BindingSourceClients As System.Windows.Forms.BindingSource
    Friend WithEvents UserControlQalityEbay As Service.UserControlQality
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents btCreateTextDescription As System.Windows.Forms.Button
    Friend WithEvents pnAccounts As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents gbCategory As System.Windows.Forms.GroupBox
    Friend WithEvents cbCategory As System.Windows.Forms.ComboBox
    Friend WithEvents cbStoreCategory2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents cbCategory2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cbStoreCategory As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btOpenCategoryForm As System.Windows.Forms.Button
    Friend WithEvents btToAuction As System.Windows.Forms.Button
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents btCopyTosourceFromArhive As System.Windows.Forms.Button
    Friend WithEvents lblPhotoSources As System.Windows.Forms.ListBox
    Friend WithEvents gbShipping As System.Windows.Forms.GroupBox
    Friend WithEvents cbxFreeShipping As System.Windows.Forms.CheckBox
    Friend WithEvents cbxPrivateListing As System.Windows.Forms.CheckBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents btShippingConvertation As System.Windows.Forms.Button
    Friend WithEvents cbPayPal As System.Windows.Forms.ComboBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents tbInterShipCostUSD As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents tbDomesticShipCostUSD As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lbCurrency1 As System.Windows.Forms.Label
    Friend WithEvents tbInterShipCost As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lbCurrency As System.Windows.Forms.Label
    Friend WithEvents tbDomesticShipCost As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tbWeightKG As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tbWeightOZ As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tbWeightLBS As System.Windows.Forms.TextBox
    Friend WithEvents gbReclama As System.Windows.Forms.GroupBox
    Friend WithEvents cbxValuePack As System.Windows.Forms.CheckBox
    Friend WithEvents cbxBoldTitle As System.Windows.Forms.CheckBox
    Friend WithEvents cbxPicturePack As System.Windows.Forms.CheckBox
    Friend WithEvents cbxGalleryPlus As System.Windows.Forms.CheckBox
    Friend WithEvents gbListingtype As System.Windows.Forms.GroupBox
    Friend WithEvents pnAuctionType As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents cbxAcceptOffers As System.Windows.Forms.CheckBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents tbReserveAuctionPriceUSD As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents tbStartAuctionPriceUSD As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cbListingType As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents tbBuyItNowPriceUSD As System.Windows.Forms.TextBox
    Friend WithEvents cbxBuyItNow As System.Windows.Forms.CheckBox
    Friend WithEvents gbTitle As System.Windows.Forms.GroupBox
    Friend WithEvents lbWordRemainSub As System.Windows.Forms.Label
    Friend WithEvents lbWorldRemain As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents tbItemSpecificTotal As System.Windows.Forms.TextBox
    Friend WithEvents cbGeologyAge As System.Windows.Forms.ComboBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents cbCountry As System.Windows.Forms.ComboBox
    Friend WithEvents btAddName As System.Windows.Forms.Button
    Friend WithEvents cbxAddSuffics As System.Windows.Forms.CheckBox
    Friend WithEvents cbxRarePrefix As System.Windows.Forms.CheckBox
    Friend WithEvents btSetSubTitle As System.Windows.Forms.Button
    Friend WithEvents btAddSubTitle As System.Windows.Forms.Button
    Friend WithEvents btRemoveSubTitle As System.Windows.Forms.Button
    Friend WithEvents cbSubTitles As System.Windows.Forms.ComboBox
    Friend WithEvents cbxEnableSubTitle As System.Windows.Forms.CheckBox
    Friend WithEvents btSetTitle As System.Windows.Forms.Button
    Friend WithEvents btRemoveTitle As System.Windows.Forms.Button
    Friend WithEvents tbTitleValue As System.Windows.Forms.TextBox
    Friend WithEvents btAddTitle As System.Windows.Forms.Button
    Friend WithEvents lblTitles As System.Windows.Forms.ListBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btGetPrice As Windows.Forms.Button
    Friend WithEvents cbxeBayUK As Windows.Forms.CheckBox
End Class
