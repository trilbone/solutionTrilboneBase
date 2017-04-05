<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserControlEbaySearch
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
        Me.btGetFromClipboard = New System.Windows.Forms.Button()
        Me.lbQueryCount = New System.Windows.Forms.Label()
        Me.tbctlMain = New System.Windows.Forms.TabControl()
        Me.tpSearchResult = New System.Windows.Forms.TabPage()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tbFirstWord = New System.Windows.Forms.TextBox()
        Me.btRemove2 = New System.Windows.Forms.Button()
        Me.btRunEbay = New System.Windows.Forms.Button()
        Me.btStopTracking = New System.Windows.Forms.Button()
        Me.tbCurrentWord = New System.Windows.Forms.TextBox()
        Me.label4 = New System.Windows.Forms.Label()
        Me.lbTrackingWord = New System.Windows.Forms.ListBox()
        Me.btTrackWord = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.SearchItemDataGridView = New System.Windows.Forms.DataGridView()
        Me.galleryImage = New System.Windows.Forms.DataGridViewImageColumn()
        Me.TotalPriceString = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.seller = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bidCount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.timeLeftString = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.listingType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SearchItemBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.tbFullPrice = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbxRemoveNoiseWords = New System.Windows.Forms.CheckBox()
        Me.btCancelFilter = New System.Windows.Forms.Button()
        Me.btFilter = New System.Windows.Forms.Button()
        Me.btToBadWord = New System.Windows.Forms.Button()
        Me.lbBadWorld = New System.Windows.Forms.ListBox()
        Me.btSaveWorlds = New System.Windows.Forms.Button()
        Me.btCopyToClipboard = New System.Windows.Forms.Button()
        Me.btRemoveFromSelectted = New System.Windows.Forms.Button()
        Me.btAddToSelected = New System.Windows.Forms.Button()
        Me.lbActualWord = New System.Windows.Forms.ListBox()
        Me.lbWorldSource = New System.Windows.Forms.ListBox()
        Me.tpSingleItem = New System.Windows.Forms.TabPage()
        Me.SimpleItemTypeDataGridView = New System.Windows.Forms.DataGridView()
        Me.DataGridViewImageColumn1 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.ListingStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sellingStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.quantitySold = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.location = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.viewItemURL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.primaryCategory = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bidCountSpecified = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.currentPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.currencyId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.shippingServiceCost = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ShippingCurrencyId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.startTimeString = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.endTimeString = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.buyItNowAvailable = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.bestOfferEnabled = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.WatchCount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SimpleItemTypeBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser()
        Me.tbItemInfo = New System.Windows.Forms.TabPage()
        Me.rtbDescription = New System.Windows.Forms.RichTextBox()
        Me.btSingleItemQuery = New System.Windows.Forms.Button()
        Me.cdCategory = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbCriteria = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btQuery = New System.Windows.Forms.Button()
        Me.tbItemID = New System.Windows.Forms.TextBox()
        Me.TitleDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SellerDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.QuantitySoldDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IsEndedDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.IsSoldDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.WordDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WordIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TimeMarkDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TimeMarkStringDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ItemIdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LocationDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GalleryURLDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GalleryImageDataGridViewImageColumn = New System.Windows.Forms.DataGridViewImageColumn()
        Me.ViewItemURLDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PrimaryCategoryDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SellingStatusDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BidCountSpecifiedDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.BidCountDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CurrentPriceDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CurrencyIdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalPriceStringDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ShippingServiceCostDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ShippingCurrencyIdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StartTimeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StartTimeStringDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StartTimeSpecifiedDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.EndTimeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EndTimeStringDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EndTimeSpecifiedDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.TimeLeftDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TimeLeftStringDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ListingTypeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BuyItNowAvailableDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.BestOfferEnabledDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.WatchCountDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WatchCountSpecifiedDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ListingStatusDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tbctlMain.SuspendLayout()
        Me.tpSearchResult.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchItemDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchItemBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpSingleItem.SuspendLayout()
        CType(Me.SimpleItemTypeDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SimpleItemTypeBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbItemInfo.SuspendLayout()
        Me.SuspendLayout()
        '
        'btGetFromClipboard
        '
        Me.btGetFromClipboard.Location = New System.Drawing.Point(6, 32)
        Me.btGetFromClipboard.Name = "btGetFromClipboard"
        Me.btGetFromClipboard.Size = New System.Drawing.Size(152, 23)
        Me.btGetFromClipboard.TabIndex = 21
        Me.btGetFromClipboard.Text = "Get from ClipBoard"
        Me.btGetFromClipboard.UseVisualStyleBackColor = True
        '
        'lbQueryCount
        '
        Me.lbQueryCount.AutoSize = True
        Me.lbQueryCount.Location = New System.Drawing.Point(595, 37)
        Me.lbQueryCount.Name = "lbQueryCount"
        Me.lbQueryCount.Size = New System.Drawing.Size(47, 13)
        Me.lbQueryCount.TabIndex = 20
        Me.lbQueryCount.Text = "Count: ?"
        '
        'tbctlMain
        '
        Me.tbctlMain.Controls.Add(Me.tpSearchResult)
        Me.tbctlMain.Controls.Add(Me.tpSingleItem)
        Me.tbctlMain.Controls.Add(Me.tbItemInfo)
        Me.tbctlMain.Location = New System.Drawing.Point(6, 57)
        Me.tbctlMain.Name = "tbctlMain"
        Me.tbctlMain.SelectedIndex = 0
        Me.tbctlMain.Size = New System.Drawing.Size(1077, 432)
        Me.tbctlMain.TabIndex = 19
        '
        'tpSearchResult
        '
        Me.tpSearchResult.Controls.Add(Me.Label5)
        Me.tpSearchResult.Controls.Add(Me.tbFirstWord)
        Me.tpSearchResult.Controls.Add(Me.btRemove2)
        Me.tpSearchResult.Controls.Add(Me.btRunEbay)
        Me.tpSearchResult.Controls.Add(Me.btStopTracking)
        Me.tpSearchResult.Controls.Add(Me.tbCurrentWord)
        Me.tpSearchResult.Controls.Add(Me.label4)
        Me.tpSearchResult.Controls.Add(Me.lbTrackingWord)
        Me.tpSearchResult.Controls.Add(Me.btTrackWord)
        Me.tpSearchResult.Controls.Add(Me.PictureBox1)
        Me.tpSearchResult.Controls.Add(Me.SearchItemDataGridView)
        Me.tpSearchResult.Controls.Add(Me.tbFullPrice)
        Me.tpSearchResult.Controls.Add(Me.Label3)
        Me.tpSearchResult.Controls.Add(Me.cbxRemoveNoiseWords)
        Me.tpSearchResult.Controls.Add(Me.btCancelFilter)
        Me.tpSearchResult.Controls.Add(Me.btFilter)
        Me.tpSearchResult.Controls.Add(Me.btToBadWord)
        Me.tpSearchResult.Controls.Add(Me.lbBadWorld)
        Me.tpSearchResult.Controls.Add(Me.btSaveWorlds)
        Me.tpSearchResult.Controls.Add(Me.btCopyToClipboard)
        Me.tpSearchResult.Controls.Add(Me.btRemoveFromSelectted)
        Me.tpSearchResult.Controls.Add(Me.btAddToSelected)
        Me.tpSearchResult.Controls.Add(Me.lbActualWord)
        Me.tpSearchResult.Controls.Add(Me.lbWorldSource)
        Me.tpSearchResult.Location = New System.Drawing.Point(4, 22)
        Me.tpSearchResult.Name = "tpSearchResult"
        Me.tpSearchResult.Padding = New System.Windows.Forms.Padding(3, 3, 3, 3)
        Me.tpSearchResult.Size = New System.Drawing.Size(1069, 406)
        Me.tpSearchResult.TabIndex = 0
        Me.tpSearchResult.Text = "Результаты поиска"
        Me.tpSearchResult.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(662, 42)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 13)
        Me.Label5.TabIndex = 36
        Me.Label5.Text = "2 поля"
        '
        'tbFirstWord
        '
        Me.tbFirstWord.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.tbFirstWord.Location = New System.Drawing.Point(458, 72)
        Me.tbFirstWord.Name = "tbFirstWord"
        Me.tbFirstWord.Size = New System.Drawing.Size(155, 20)
        Me.tbFirstWord.TabIndex = 35
        '
        'btRemove2
        '
        Me.btRemove2.Location = New System.Drawing.Point(569, 253)
        Me.btRemove2.Name = "btRemove2"
        Me.btRemove2.Size = New System.Drawing.Size(41, 29)
        Me.btRemove2.TabIndex = 34
        Me.btRemove2.Text = "<<"
        Me.btRemove2.UseVisualStyleBackColor = True
        '
        'btRunEbay
        '
        Me.btRunEbay.Location = New System.Drawing.Point(860, 373)
        Me.btRunEbay.Name = "btRunEbay"
        Me.btRunEbay.Size = New System.Drawing.Size(203, 27)
        Me.btRunEbay.TabIndex = 33
        Me.btRunEbay.Text = "Запуск трекинга"
        Me.btRunEbay.UseVisualStyleBackColor = True
        '
        'btStopTracking
        '
        Me.btStopTracking.Location = New System.Drawing.Point(806, 115)
        Me.btStopTracking.Name = "btStopTracking"
        Me.btStopTracking.Size = New System.Drawing.Size(41, 23)
        Me.btStopTracking.TabIndex = 32
        Me.btStopTracking.Text = "<<"
        Me.btStopTracking.UseVisualStyleBackColor = True
        '
        'tbCurrentWord
        '
        Me.tbCurrentWord.Location = New System.Drawing.Point(458, 96)
        Me.tbCurrentWord.Name = "tbCurrentWord"
        Me.tbCurrentWord.Size = New System.Drawing.Size(155, 20)
        Me.tbCurrentWord.TabIndex = 31
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(849, 20)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(75, 13)
        Me.label4.TabIndex = 30
        Me.label4.Text = "Отслеживать"
        '
        'lbTrackingWord
        '
        Me.lbTrackingWord.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lbTrackingWord.FormattingEnabled = True
        Me.lbTrackingWord.Location = New System.Drawing.Point(852, 40)
        Me.lbTrackingWord.Name = "lbTrackingWord"
        Me.lbTrackingWord.Size = New System.Drawing.Size(132, 316)
        Me.lbTrackingWord.TabIndex = 29
        '
        'btTrackWord
        '
        Me.btTrackWord.BackColor = System.Drawing.Color.Turquoise
        Me.btTrackWord.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btTrackWord.Location = New System.Drawing.Point(806, 64)
        Me.btTrackWord.Name = "btTrackWord"
        Me.btTrackWord.Size = New System.Drawing.Size(41, 39)
        Me.btTrackWord.TabIndex = 28
        Me.btTrackWord.Text = ">>"
        Me.btTrackWord.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(6, 205)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(235, 177)
        Me.PictureBox1.TabIndex = 27
        Me.PictureBox1.TabStop = False
        '
        'SearchItemDataGridView
        '
        Me.SearchItemDataGridView.AllowUserToAddRows = False
        Me.SearchItemDataGridView.AllowUserToDeleteRows = False
        Me.SearchItemDataGridView.AutoGenerateColumns = False
        Me.SearchItemDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.SearchItemDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.galleryImage, Me.TotalPriceString, Me.seller, Me.bidCount, Me.timeLeftString, Me.listingType, Me.DataGridViewTextBoxColumn5})
        Me.SearchItemDataGridView.DataSource = Me.SearchItemBindingSource
        Me.SearchItemDataGridView.Location = New System.Drawing.Point(6, 6)
        Me.SearchItemDataGridView.Name = "SearchItemDataGridView"
        Me.SearchItemDataGridView.Size = New System.Drawing.Size(428, 193)
        Me.SearchItemDataGridView.TabIndex = 25
        '
        'galleryImage
        '
        Me.galleryImage.DataPropertyName = "galleryImage"
        Me.galleryImage.HeaderText = "Фото"
        Me.galleryImage.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom
        Me.galleryImage.Name = "galleryImage"
        Me.galleryImage.ReadOnly = True
        '
        'TotalPriceString
        '
        Me.TotalPriceString.DataPropertyName = "TotalPriceString"
        Me.TotalPriceString.HeaderText = "цена"
        Me.TotalPriceString.Name = "TotalPriceString"
        Me.TotalPriceString.ReadOnly = True
        '
        'seller
        '
        Me.seller.DataPropertyName = "seller"
        Me.seller.HeaderText = "продавец"
        Me.seller.Name = "seller"
        '
        'bidCount
        '
        Me.bidCount.DataPropertyName = "bidCount"
        Me.bidCount.HeaderText = "ставок"
        Me.bidCount.Name = "bidCount"
        '
        'timeLeftString
        '
        Me.timeLeftString.DataPropertyName = "timeLeftString"
        Me.timeLeftString.HeaderText = "осталось"
        Me.timeLeftString.Name = "timeLeftString"
        Me.timeLeftString.ReadOnly = True
        '
        'listingType
        '
        Me.listingType.DataPropertyName = "listingType"
        Me.listingType.HeaderText = "тип"
        Me.listingType.Name = "listingType"
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "primaryCategory"
        Me.DataGridViewTextBoxColumn5.HeaderText = "категория"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.Width = 5
        '
        'SearchItemBindingSource
        '
        Me.SearchItemBindingSource.DataSource = GetType(eBayFinding.clseBayHistoryItem)
        '
        'tbFullPrice
        '
        Me.tbFullPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.tbFullPrice.Location = New System.Drawing.Point(247, 232)
        Me.tbFullPrice.Name = "tbFullPrice"
        Me.tbFullPrice.Size = New System.Drawing.Size(147, 29)
        Me.tbFullPrice.TabIndex = 24
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label3.Location = New System.Drawing.Point(249, 205)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(99, 24)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "Full Price"
        '
        'cbxRemoveNoiseWords
        '
        Me.cbxRemoveNoiseWords.AutoSize = True
        Me.cbxRemoveNoiseWords.Location = New System.Drawing.Point(458, 41)
        Me.cbxRemoveNoiseWords.Name = "cbxRemoveNoiseWords"
        Me.cbxRemoveNoiseWords.Size = New System.Drawing.Size(104, 17)
        Me.cbxRemoveNoiseWords.TabIndex = 21
        Me.cbxRemoveNoiseWords.Text = "исключить шум"
        Me.cbxRemoveNoiseWords.UseVisualStyleBackColor = True
        '
        'btCancelFilter
        '
        Me.btCancelFilter.Location = New System.Drawing.Point(570, 12)
        Me.btCancelFilter.Name = "btCancelFilter"
        Me.btCancelFilter.Size = New System.Drawing.Size(59, 23)
        Me.btCancelFilter.TabIndex = 20
        Me.btCancelFilter.Text = "сброс"
        Me.btCancelFilter.UseVisualStyleBackColor = True
        '
        'btFilter
        '
        Me.btFilter.Location = New System.Drawing.Point(456, 12)
        Me.btFilter.Name = "btFilter"
        Me.btFilter.Size = New System.Drawing.Size(106, 23)
        Me.btFilter.TabIndex = 19
        Me.btFilter.Text = "Фильтр"
        Me.btFilter.UseVisualStyleBackColor = True
        '
        'btToBadWord
        '
        Me.btToBadWord.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btToBadWord.Location = New System.Drawing.Point(458, 250)
        Me.btToBadWord.Name = "btToBadWord"
        Me.btToBadWord.Size = New System.Drawing.Size(41, 36)
        Me.btToBadWord.TabIndex = 16
        Me.btToBadWord.Text = ">>"
        Me.btToBadWord.UseVisualStyleBackColor = False
        '
        'lbBadWorld
        '
        Me.lbBadWorld.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lbBadWorld.FormattingEnabled = True
        Me.lbBadWorld.Location = New System.Drawing.Point(456, 292)
        Me.lbBadWorld.Name = "lbBadWorld"
        Me.lbBadWorld.Size = New System.Drawing.Size(155, 82)
        Me.lbBadWorld.TabIndex = 15
        '
        'btSaveWorlds
        '
        Me.btSaveWorlds.Location = New System.Drawing.Point(994, 40)
        Me.btSaveWorlds.Name = "btSaveWorlds"
        Me.btSaveWorlds.Size = New System.Drawing.Size(60, 98)
        Me.btSaveWorlds.TabIndex = 14
        Me.btSaveWorlds.Text = "Синхронизовать слова с БД"
        Me.btSaveWorlds.UseVisualStyleBackColor = True
        '
        'btCopyToClipboard
        '
        Me.btCopyToClipboard.Location = New System.Drawing.Point(639, 12)
        Me.btCopyToClipboard.Name = "btCopyToClipboard"
        Me.btCopyToClipboard.Size = New System.Drawing.Size(75, 23)
        Me.btCopyToClipboard.TabIndex = 13
        Me.btCopyToClipboard.Text = "Copy"
        Me.btCopyToClipboard.UseVisualStyleBackColor = True
        '
        'btRemoveFromSelectted
        '
        Me.btRemoveFromSelectted.Location = New System.Drawing.Point(616, 147)
        Me.btRemoveFromSelectted.Name = "btRemoveFromSelectted"
        Me.btRemoveFromSelectted.Size = New System.Drawing.Size(41, 31)
        Me.btRemoveFromSelectted.TabIndex = 11
        Me.btRemoveFromSelectted.Text = "<<"
        Me.btRemoveFromSelectted.UseVisualStyleBackColor = True
        '
        'btAddToSelected
        '
        Me.btAddToSelected.BackColor = System.Drawing.Color.Lime
        Me.btAddToSelected.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btAddToSelected.Location = New System.Drawing.Point(617, 64)
        Me.btAddToSelected.Name = "btAddToSelected"
        Me.btAddToSelected.Size = New System.Drawing.Size(41, 39)
        Me.btAddToSelected.TabIndex = 10
        Me.btAddToSelected.Text = ">>"
        Me.btAddToSelected.UseVisualStyleBackColor = False
        '
        'lbActualWord
        '
        Me.lbActualWord.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lbActualWord.FormattingEnabled = True
        Me.lbActualWord.Location = New System.Drawing.Point(664, 64)
        Me.lbActualWord.Name = "lbActualWord"
        Me.lbActualWord.Size = New System.Drawing.Size(132, 329)
        Me.lbActualWord.TabIndex = 9
        '
        'lbWorldSource
        '
        Me.lbWorldSource.FormattingEnabled = True
        Me.lbWorldSource.Location = New System.Drawing.Point(458, 120)
        Me.lbWorldSource.Name = "lbWorldSource"
        Me.lbWorldSource.Size = New System.Drawing.Size(153, 121)
        Me.lbWorldSource.TabIndex = 8
        '
        'tpSingleItem
        '
        Me.tpSingleItem.AutoScroll = True
        Me.tpSingleItem.Controls.Add(Me.SimpleItemTypeDataGridView)
        Me.tpSingleItem.Controls.Add(Me.WebBrowser1)
        Me.tpSingleItem.Location = New System.Drawing.Point(4, 22)
        Me.tpSingleItem.Name = "tpSingleItem"
        Me.tpSingleItem.Padding = New System.Windows.Forms.Padding(3, 3, 3, 3)
        Me.tpSingleItem.Size = New System.Drawing.Size(1069, 406)
        Me.tpSingleItem.TabIndex = 1
        Me.tpSingleItem.Text = "Запрос одиночки"
        Me.tpSingleItem.UseVisualStyleBackColor = True
        '
        'SimpleItemTypeDataGridView
        '
        Me.SimpleItemTypeDataGridView.AutoGenerateColumns = False
        Me.SimpleItemTypeDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.SimpleItemTypeDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewImageColumn1, Me.ListingStatus, Me.sellingStatus, Me.quantitySold, Me.DataGridViewTextBoxColumn1, Me.location, Me.viewItemURL, Me.primaryCategory, Me.bidCountSpecified, Me.DataGridViewTextBoxColumn2, Me.currentPrice, Me.currencyId, Me.shippingServiceCost, Me.ShippingCurrencyId, Me.DataGridViewTextBoxColumn3, Me.startTimeString, Me.endTimeString, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn6, Me.buyItNowAvailable, Me.bestOfferEnabled, Me.WatchCount, Me.TitleDataGridViewTextBoxColumn, Me.SellerDataGridViewTextBoxColumn, Me.QuantitySoldDataGridViewTextBoxColumn, Me.IsEndedDataGridViewCheckBoxColumn, Me.IsSoldDataGridViewCheckBoxColumn, Me.WordDataGridViewTextBoxColumn, Me.WordIDDataGridViewTextBoxColumn, Me.TimeMarkDataGridViewTextBoxColumn, Me.TimeMarkStringDataGridViewTextBoxColumn, Me.ItemIdDataGridViewTextBoxColumn, Me.LocationDataGridViewTextBoxColumn, Me.GalleryURLDataGridViewTextBoxColumn, Me.GalleryImageDataGridViewImageColumn, Me.ViewItemURLDataGridViewTextBoxColumn, Me.PrimaryCategoryDataGridViewTextBoxColumn, Me.SellingStatusDataGridViewTextBoxColumn, Me.BidCountSpecifiedDataGridViewCheckBoxColumn, Me.BidCountDataGridViewTextBoxColumn, Me.CurrentPriceDataGridViewTextBoxColumn, Me.CurrencyIdDataGridViewTextBoxColumn, Me.TotalPriceStringDataGridViewTextBoxColumn, Me.ShippingServiceCostDataGridViewTextBoxColumn, Me.ShippingCurrencyIdDataGridViewTextBoxColumn, Me.StartTimeDataGridViewTextBoxColumn, Me.StartTimeStringDataGridViewTextBoxColumn, Me.StartTimeSpecifiedDataGridViewCheckBoxColumn, Me.EndTimeDataGridViewTextBoxColumn, Me.EndTimeStringDataGridViewTextBoxColumn, Me.EndTimeSpecifiedDataGridViewCheckBoxColumn, Me.TimeLeftDataGridViewTextBoxColumn, Me.TimeLeftStringDataGridViewTextBoxColumn, Me.ListingTypeDataGridViewTextBoxColumn, Me.BuyItNowAvailableDataGridViewCheckBoxColumn, Me.BestOfferEnabledDataGridViewCheckBoxColumn, Me.WatchCountDataGridViewTextBoxColumn, Me.WatchCountSpecifiedDataGridViewCheckBoxColumn, Me.ListingStatusDataGridViewTextBoxColumn})
        Me.SimpleItemTypeDataGridView.DataSource = Me.SimpleItemTypeBindingSource
        Me.SimpleItemTypeDataGridView.Location = New System.Drawing.Point(6, 6)
        Me.SimpleItemTypeDataGridView.Name = "SimpleItemTypeDataGridView"
        Me.SimpleItemTypeDataGridView.Size = New System.Drawing.Size(1060, 82)
        Me.SimpleItemTypeDataGridView.TabIndex = 2
        '
        'DataGridViewImageColumn1
        '
        Me.DataGridViewImageColumn1.DataPropertyName = "galleryImage"
        Me.DataGridViewImageColumn1.HeaderText = "galleryImage"
        Me.DataGridViewImageColumn1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom
        Me.DataGridViewImageColumn1.Name = "DataGridViewImageColumn1"
        Me.DataGridViewImageColumn1.ReadOnly = True
        '
        'ListingStatus
        '
        Me.ListingStatus.DataPropertyName = "ListingStatus"
        Me.ListingStatus.HeaderText = "ListingStatus"
        Me.ListingStatus.Name = "ListingStatus"
        '
        'sellingStatus
        '
        Me.sellingStatus.DataPropertyName = "sellingStatus"
        Me.sellingStatus.HeaderText = "sellingStatus"
        Me.sellingStatus.Name = "sellingStatus"
        '
        'quantitySold
        '
        Me.quantitySold.DataPropertyName = "quantitySold"
        Me.quantitySold.HeaderText = "quantitySold"
        Me.quantitySold.Name = "quantitySold"
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "seller"
        Me.DataGridViewTextBoxColumn1.HeaderText = "seller"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        '
        'location
        '
        Me.location.DataPropertyName = "location"
        Me.location.HeaderText = "location"
        Me.location.Name = "location"
        '
        'viewItemURL
        '
        Me.viewItemURL.DataPropertyName = "viewItemURL"
        Me.viewItemURL.HeaderText = "viewItemURL"
        Me.viewItemURL.Name = "viewItemURL"
        '
        'primaryCategory
        '
        Me.primaryCategory.DataPropertyName = "primaryCategory"
        Me.primaryCategory.HeaderText = "primaryCategory"
        Me.primaryCategory.Name = "primaryCategory"
        '
        'bidCountSpecified
        '
        Me.bidCountSpecified.DataPropertyName = "bidCountSpecified"
        Me.bidCountSpecified.HeaderText = "bidCountSpecified"
        Me.bidCountSpecified.Name = "bidCountSpecified"
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "bidCount"
        Me.DataGridViewTextBoxColumn2.HeaderText = "bidCount"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'currentPrice
        '
        Me.currentPrice.DataPropertyName = "currentPrice"
        Me.currentPrice.HeaderText = "currentPrice"
        Me.currentPrice.Name = "currentPrice"
        '
        'currencyId
        '
        Me.currencyId.DataPropertyName = "currencyId"
        Me.currencyId.HeaderText = "currencyId"
        Me.currencyId.Name = "currencyId"
        '
        'shippingServiceCost
        '
        Me.shippingServiceCost.DataPropertyName = "shippingServiceCost"
        Me.shippingServiceCost.HeaderText = "shippingServiceCost"
        Me.shippingServiceCost.Name = "shippingServiceCost"
        '
        'ShippingCurrencyId
        '
        Me.ShippingCurrencyId.DataPropertyName = "ShippingCurrencyId"
        Me.ShippingCurrencyId.HeaderText = "ShippingCurrencyId"
        Me.ShippingCurrencyId.Name = "ShippingCurrencyId"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "TotalPriceString"
        Me.DataGridViewTextBoxColumn3.HeaderText = "TotalPriceString"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        '
        'startTimeString
        '
        Me.startTimeString.DataPropertyName = "startTimeString"
        Me.startTimeString.HeaderText = "startTimeString"
        Me.startTimeString.Name = "startTimeString"
        Me.startTimeString.ReadOnly = True
        '
        'endTimeString
        '
        Me.endTimeString.DataPropertyName = "endTimeString"
        Me.endTimeString.HeaderText = "endTimeString"
        Me.endTimeString.Name = "endTimeString"
        Me.endTimeString.ReadOnly = True
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "timeLeftString"
        Me.DataGridViewTextBoxColumn4.HeaderText = "timeLeftString"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "listingType"
        Me.DataGridViewTextBoxColumn6.HeaderText = "listingType"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        '
        'buyItNowAvailable
        '
        Me.buyItNowAvailable.DataPropertyName = "buyItNowAvailable"
        Me.buyItNowAvailable.HeaderText = "buyItNowAvailable"
        Me.buyItNowAvailable.Name = "buyItNowAvailable"
        '
        'bestOfferEnabled
        '
        Me.bestOfferEnabled.DataPropertyName = "bestOfferEnabled"
        Me.bestOfferEnabled.HeaderText = "bestOfferEnabled"
        Me.bestOfferEnabled.Name = "bestOfferEnabled"
        '
        'WatchCount
        '
        Me.WatchCount.DataPropertyName = "WatchCount"
        Me.WatchCount.HeaderText = "WatchCount"
        Me.WatchCount.Name = "WatchCount"
        '
        'SimpleItemTypeBindingSource
        '
        Me.SimpleItemTypeBindingSource.DataSource = GetType(eBayFinding.clseBayHistoryItem)
        '
        'WebBrowser1
        '
        Me.WebBrowser1.Location = New System.Drawing.Point(6, 94)
        Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.Size = New System.Drawing.Size(1057, 306)
        Me.WebBrowser1.TabIndex = 1
        '
        'tbItemInfo
        '
        Me.tbItemInfo.Controls.Add(Me.rtbDescription)
        Me.tbItemInfo.Location = New System.Drawing.Point(4, 22)
        Me.tbItemInfo.Name = "tbItemInfo"
        Me.tbItemInfo.Padding = New System.Windows.Forms.Padding(3, 3, 3, 3)
        Me.tbItemInfo.Size = New System.Drawing.Size(1069, 406)
        Me.tbItemInfo.TabIndex = 2
        Me.tbItemInfo.Text = "Инфо о листинге"
        Me.tbItemInfo.UseVisualStyleBackColor = True
        '
        'rtbDescription
        '
        Me.rtbDescription.Location = New System.Drawing.Point(19, 23)
        Me.rtbDescription.Name = "rtbDescription"
        Me.rtbDescription.Size = New System.Drawing.Size(817, 380)
        Me.rtbDescription.TabIndex = 0
        Me.rtbDescription.Text = ""
        '
        'btSingleItemQuery
        '
        Me.btSingleItemQuery.Location = New System.Drawing.Point(835, 9)
        Me.btSingleItemQuery.Name = "btSingleItemQuery"
        Me.btSingleItemQuery.Size = New System.Drawing.Size(75, 23)
        Me.btSingleItemQuery.TabIndex = 18
        Me.btSingleItemQuery.Text = "Запрос ID"
        Me.btSingleItemQuery.UseVisualStyleBackColor = True
        '
        'cdCategory
        '
        Me.cdCategory.FormattingEnabled = True
        Me.cdCategory.Location = New System.Drawing.Point(500, 9)
        Me.cdCategory.Name = "cdCategory"
        Me.cdCategory.Size = New System.Drawing.Size(231, 21)
        Me.cdCategory.TabIndex = 16
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(437, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 13)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Категория"
        '
        'tbCriteria
        '
        Me.tbCriteria.Location = New System.Drawing.Point(231, 9)
        Me.tbCriteria.Name = "tbCriteria"
        Me.tbCriteria.Size = New System.Drawing.Size(201, 20)
        Me.tbCriteria.TabIndex = 14
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(226, 13)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Выражение ( пробел разделитель условий)"
        '
        'btQuery
        '
        Me.btQuery.Location = New System.Drawing.Point(737, 8)
        Me.btQuery.Name = "btQuery"
        Me.btQuery.Size = New System.Drawing.Size(75, 23)
        Me.btQuery.TabIndex = 12
        Me.btQuery.Text = "Запрос"
        Me.btQuery.UseVisualStyleBackColor = True
        '
        'tbItemID
        '
        Me.tbItemID.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.SearchItemBindingSource, "itemId", True))
        Me.tbItemID.Location = New System.Drawing.Point(913, 11)
        Me.tbItemID.Name = "tbItemID"
        Me.tbItemID.Size = New System.Drawing.Size(152, 20)
        Me.tbItemID.TabIndex = 22
        '
        'TitleDataGridViewTextBoxColumn
        '
        Me.TitleDataGridViewTextBoxColumn.DataPropertyName = "title"
        Me.TitleDataGridViewTextBoxColumn.HeaderText = "title"
        Me.TitleDataGridViewTextBoxColumn.Name = "TitleDataGridViewTextBoxColumn"
        '
        'SellerDataGridViewTextBoxColumn
        '
        Me.SellerDataGridViewTextBoxColumn.DataPropertyName = "seller"
        Me.SellerDataGridViewTextBoxColumn.HeaderText = "seller"
        Me.SellerDataGridViewTextBoxColumn.Name = "SellerDataGridViewTextBoxColumn"
        '
        'QuantitySoldDataGridViewTextBoxColumn
        '
        Me.QuantitySoldDataGridViewTextBoxColumn.DataPropertyName = "quantitySold"
        Me.QuantitySoldDataGridViewTextBoxColumn.HeaderText = "quantitySold"
        Me.QuantitySoldDataGridViewTextBoxColumn.Name = "QuantitySoldDataGridViewTextBoxColumn"
        '
        'IsEndedDataGridViewCheckBoxColumn
        '
        Me.IsEndedDataGridViewCheckBoxColumn.DataPropertyName = "IsEnded"
        Me.IsEndedDataGridViewCheckBoxColumn.HeaderText = "IsEnded"
        Me.IsEndedDataGridViewCheckBoxColumn.Name = "IsEndedDataGridViewCheckBoxColumn"
        Me.IsEndedDataGridViewCheckBoxColumn.ReadOnly = True
        '
        'IsSoldDataGridViewCheckBoxColumn
        '
        Me.IsSoldDataGridViewCheckBoxColumn.DataPropertyName = "IsSold"
        Me.IsSoldDataGridViewCheckBoxColumn.HeaderText = "IsSold"
        Me.IsSoldDataGridViewCheckBoxColumn.Name = "IsSoldDataGridViewCheckBoxColumn"
        Me.IsSoldDataGridViewCheckBoxColumn.ReadOnly = True
        '
        'WordDataGridViewTextBoxColumn
        '
        Me.WordDataGridViewTextBoxColumn.DataPropertyName = "Word"
        Me.WordDataGridViewTextBoxColumn.HeaderText = "Word"
        Me.WordDataGridViewTextBoxColumn.Name = "WordDataGridViewTextBoxColumn"
        '
        'WordIDDataGridViewTextBoxColumn
        '
        Me.WordIDDataGridViewTextBoxColumn.DataPropertyName = "WordID"
        Me.WordIDDataGridViewTextBoxColumn.HeaderText = "WordID"
        Me.WordIDDataGridViewTextBoxColumn.Name = "WordIDDataGridViewTextBoxColumn"
        '
        'TimeMarkDataGridViewTextBoxColumn
        '
        Me.TimeMarkDataGridViewTextBoxColumn.DataPropertyName = "TimeMark"
        Me.TimeMarkDataGridViewTextBoxColumn.HeaderText = "TimeMark"
        Me.TimeMarkDataGridViewTextBoxColumn.Name = "TimeMarkDataGridViewTextBoxColumn"
        '
        'TimeMarkStringDataGridViewTextBoxColumn
        '
        Me.TimeMarkStringDataGridViewTextBoxColumn.DataPropertyName = "TimeMarkString"
        Me.TimeMarkStringDataGridViewTextBoxColumn.HeaderText = "TimeMarkString"
        Me.TimeMarkStringDataGridViewTextBoxColumn.Name = "TimeMarkStringDataGridViewTextBoxColumn"
        Me.TimeMarkStringDataGridViewTextBoxColumn.ReadOnly = True
        '
        'ItemIdDataGridViewTextBoxColumn
        '
        Me.ItemIdDataGridViewTextBoxColumn.DataPropertyName = "itemId"
        Me.ItemIdDataGridViewTextBoxColumn.HeaderText = "itemId"
        Me.ItemIdDataGridViewTextBoxColumn.Name = "ItemIdDataGridViewTextBoxColumn"
        '
        'LocationDataGridViewTextBoxColumn
        '
        Me.LocationDataGridViewTextBoxColumn.DataPropertyName = "location"
        Me.LocationDataGridViewTextBoxColumn.HeaderText = "location"
        Me.LocationDataGridViewTextBoxColumn.Name = "LocationDataGridViewTextBoxColumn"
        '
        'GalleryURLDataGridViewTextBoxColumn
        '
        Me.GalleryURLDataGridViewTextBoxColumn.DataPropertyName = "galleryURL"
        Me.GalleryURLDataGridViewTextBoxColumn.HeaderText = "galleryURL"
        Me.GalleryURLDataGridViewTextBoxColumn.Name = "GalleryURLDataGridViewTextBoxColumn"
        '
        'GalleryImageDataGridViewImageColumn
        '
        Me.GalleryImageDataGridViewImageColumn.DataPropertyName = "galleryImage"
        Me.GalleryImageDataGridViewImageColumn.HeaderText = "galleryImage"
        Me.GalleryImageDataGridViewImageColumn.Name = "GalleryImageDataGridViewImageColumn"
        Me.GalleryImageDataGridViewImageColumn.ReadOnly = True
        '
        'ViewItemURLDataGridViewTextBoxColumn
        '
        Me.ViewItemURLDataGridViewTextBoxColumn.DataPropertyName = "viewItemURL"
        Me.ViewItemURLDataGridViewTextBoxColumn.HeaderText = "viewItemURL"
        Me.ViewItemURLDataGridViewTextBoxColumn.Name = "ViewItemURLDataGridViewTextBoxColumn"
        '
        'PrimaryCategoryDataGridViewTextBoxColumn
        '
        Me.PrimaryCategoryDataGridViewTextBoxColumn.DataPropertyName = "primaryCategory"
        Me.PrimaryCategoryDataGridViewTextBoxColumn.HeaderText = "primaryCategory"
        Me.PrimaryCategoryDataGridViewTextBoxColumn.Name = "PrimaryCategoryDataGridViewTextBoxColumn"
        '
        'SellingStatusDataGridViewTextBoxColumn
        '
        Me.SellingStatusDataGridViewTextBoxColumn.DataPropertyName = "sellingStatus"
        Me.SellingStatusDataGridViewTextBoxColumn.HeaderText = "sellingStatus"
        Me.SellingStatusDataGridViewTextBoxColumn.Name = "SellingStatusDataGridViewTextBoxColumn"
        '
        'BidCountSpecifiedDataGridViewCheckBoxColumn
        '
        Me.BidCountSpecifiedDataGridViewCheckBoxColumn.DataPropertyName = "bidCountSpecified"
        Me.BidCountSpecifiedDataGridViewCheckBoxColumn.HeaderText = "bidCountSpecified"
        Me.BidCountSpecifiedDataGridViewCheckBoxColumn.Name = "BidCountSpecifiedDataGridViewCheckBoxColumn"
        '
        'BidCountDataGridViewTextBoxColumn
        '
        Me.BidCountDataGridViewTextBoxColumn.DataPropertyName = "bidCount"
        Me.BidCountDataGridViewTextBoxColumn.HeaderText = "bidCount"
        Me.BidCountDataGridViewTextBoxColumn.Name = "BidCountDataGridViewTextBoxColumn"
        '
        'CurrentPriceDataGridViewTextBoxColumn
        '
        Me.CurrentPriceDataGridViewTextBoxColumn.DataPropertyName = "currentPrice"
        Me.CurrentPriceDataGridViewTextBoxColumn.HeaderText = "currentPrice"
        Me.CurrentPriceDataGridViewTextBoxColumn.Name = "CurrentPriceDataGridViewTextBoxColumn"
        '
        'CurrencyIdDataGridViewTextBoxColumn
        '
        Me.CurrencyIdDataGridViewTextBoxColumn.DataPropertyName = "currencyId"
        Me.CurrencyIdDataGridViewTextBoxColumn.HeaderText = "currencyId"
        Me.CurrencyIdDataGridViewTextBoxColumn.Name = "CurrencyIdDataGridViewTextBoxColumn"
        '
        'TotalPriceStringDataGridViewTextBoxColumn
        '
        Me.TotalPriceStringDataGridViewTextBoxColumn.DataPropertyName = "TotalPriceString"
        Me.TotalPriceStringDataGridViewTextBoxColumn.HeaderText = "TotalPriceString"
        Me.TotalPriceStringDataGridViewTextBoxColumn.Name = "TotalPriceStringDataGridViewTextBoxColumn"
        Me.TotalPriceStringDataGridViewTextBoxColumn.ReadOnly = True
        '
        'ShippingServiceCostDataGridViewTextBoxColumn
        '
        Me.ShippingServiceCostDataGridViewTextBoxColumn.DataPropertyName = "shippingServiceCost"
        Me.ShippingServiceCostDataGridViewTextBoxColumn.HeaderText = "shippingServiceCost"
        Me.ShippingServiceCostDataGridViewTextBoxColumn.Name = "ShippingServiceCostDataGridViewTextBoxColumn"
        '
        'ShippingCurrencyIdDataGridViewTextBoxColumn
        '
        Me.ShippingCurrencyIdDataGridViewTextBoxColumn.DataPropertyName = "ShippingCurrencyId"
        Me.ShippingCurrencyIdDataGridViewTextBoxColumn.HeaderText = "ShippingCurrencyId"
        Me.ShippingCurrencyIdDataGridViewTextBoxColumn.Name = "ShippingCurrencyIdDataGridViewTextBoxColumn"
        '
        'StartTimeDataGridViewTextBoxColumn
        '
        Me.StartTimeDataGridViewTextBoxColumn.DataPropertyName = "startTime"
        Me.StartTimeDataGridViewTextBoxColumn.HeaderText = "startTime"
        Me.StartTimeDataGridViewTextBoxColumn.Name = "StartTimeDataGridViewTextBoxColumn"
        '
        'StartTimeStringDataGridViewTextBoxColumn
        '
        Me.StartTimeStringDataGridViewTextBoxColumn.DataPropertyName = "startTimeString"
        Me.StartTimeStringDataGridViewTextBoxColumn.HeaderText = "startTimeString"
        Me.StartTimeStringDataGridViewTextBoxColumn.Name = "StartTimeStringDataGridViewTextBoxColumn"
        Me.StartTimeStringDataGridViewTextBoxColumn.ReadOnly = True
        '
        'StartTimeSpecifiedDataGridViewCheckBoxColumn
        '
        Me.StartTimeSpecifiedDataGridViewCheckBoxColumn.DataPropertyName = "startTimeSpecified"
        Me.StartTimeSpecifiedDataGridViewCheckBoxColumn.HeaderText = "startTimeSpecified"
        Me.StartTimeSpecifiedDataGridViewCheckBoxColumn.Name = "StartTimeSpecifiedDataGridViewCheckBoxColumn"
        '
        'EndTimeDataGridViewTextBoxColumn
        '
        Me.EndTimeDataGridViewTextBoxColumn.DataPropertyName = "endTime"
        Me.EndTimeDataGridViewTextBoxColumn.HeaderText = "endTime"
        Me.EndTimeDataGridViewTextBoxColumn.Name = "EndTimeDataGridViewTextBoxColumn"
        '
        'EndTimeStringDataGridViewTextBoxColumn
        '
        Me.EndTimeStringDataGridViewTextBoxColumn.DataPropertyName = "endTimeString"
        Me.EndTimeStringDataGridViewTextBoxColumn.HeaderText = "endTimeString"
        Me.EndTimeStringDataGridViewTextBoxColumn.Name = "EndTimeStringDataGridViewTextBoxColumn"
        Me.EndTimeStringDataGridViewTextBoxColumn.ReadOnly = True
        '
        'EndTimeSpecifiedDataGridViewCheckBoxColumn
        '
        Me.EndTimeSpecifiedDataGridViewCheckBoxColumn.DataPropertyName = "endTimeSpecified"
        Me.EndTimeSpecifiedDataGridViewCheckBoxColumn.HeaderText = "endTimeSpecified"
        Me.EndTimeSpecifiedDataGridViewCheckBoxColumn.Name = "EndTimeSpecifiedDataGridViewCheckBoxColumn"
        '
        'TimeLeftDataGridViewTextBoxColumn
        '
        Me.TimeLeftDataGridViewTextBoxColumn.DataPropertyName = "timeLeft"
        Me.TimeLeftDataGridViewTextBoxColumn.HeaderText = "timeLeft"
        Me.TimeLeftDataGridViewTextBoxColumn.Name = "TimeLeftDataGridViewTextBoxColumn"
        '
        'TimeLeftStringDataGridViewTextBoxColumn
        '
        Me.TimeLeftStringDataGridViewTextBoxColumn.DataPropertyName = "timeLeftString"
        Me.TimeLeftStringDataGridViewTextBoxColumn.HeaderText = "timeLeftString"
        Me.TimeLeftStringDataGridViewTextBoxColumn.Name = "TimeLeftStringDataGridViewTextBoxColumn"
        Me.TimeLeftStringDataGridViewTextBoxColumn.ReadOnly = True
        '
        'ListingTypeDataGridViewTextBoxColumn
        '
        Me.ListingTypeDataGridViewTextBoxColumn.DataPropertyName = "listingType"
        Me.ListingTypeDataGridViewTextBoxColumn.HeaderText = "listingType"
        Me.ListingTypeDataGridViewTextBoxColumn.Name = "ListingTypeDataGridViewTextBoxColumn"
        '
        'BuyItNowAvailableDataGridViewCheckBoxColumn
        '
        Me.BuyItNowAvailableDataGridViewCheckBoxColumn.DataPropertyName = "buyItNowAvailable"
        Me.BuyItNowAvailableDataGridViewCheckBoxColumn.HeaderText = "buyItNowAvailable"
        Me.BuyItNowAvailableDataGridViewCheckBoxColumn.Name = "BuyItNowAvailableDataGridViewCheckBoxColumn"
        '
        'BestOfferEnabledDataGridViewCheckBoxColumn
        '
        Me.BestOfferEnabledDataGridViewCheckBoxColumn.DataPropertyName = "bestOfferEnabled"
        Me.BestOfferEnabledDataGridViewCheckBoxColumn.HeaderText = "bestOfferEnabled"
        Me.BestOfferEnabledDataGridViewCheckBoxColumn.Name = "BestOfferEnabledDataGridViewCheckBoxColumn"
        '
        'WatchCountDataGridViewTextBoxColumn
        '
        Me.WatchCountDataGridViewTextBoxColumn.DataPropertyName = "WatchCount"
        Me.WatchCountDataGridViewTextBoxColumn.HeaderText = "WatchCount"
        Me.WatchCountDataGridViewTextBoxColumn.Name = "WatchCountDataGridViewTextBoxColumn"
        '
        'WatchCountSpecifiedDataGridViewCheckBoxColumn
        '
        Me.WatchCountSpecifiedDataGridViewCheckBoxColumn.DataPropertyName = "WatchCountSpecified"
        Me.WatchCountSpecifiedDataGridViewCheckBoxColumn.HeaderText = "WatchCountSpecified"
        Me.WatchCountSpecifiedDataGridViewCheckBoxColumn.Name = "WatchCountSpecifiedDataGridViewCheckBoxColumn"
        '
        'ListingStatusDataGridViewTextBoxColumn
        '
        Me.ListingStatusDataGridViewTextBoxColumn.DataPropertyName = "ListingStatus"
        Me.ListingStatusDataGridViewTextBoxColumn.HeaderText = "ListingStatus"
        Me.ListingStatusDataGridViewTextBoxColumn.Name = "ListingStatusDataGridViewTextBoxColumn"
        '
        'UserControlEbaySearch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.tbItemID)
        Me.Controls.Add(Me.btGetFromClipboard)
        Me.Controls.Add(Me.lbQueryCount)
        Me.Controls.Add(Me.tbctlMain)
        Me.Controls.Add(Me.btSingleItemQuery)
        Me.Controls.Add(Me.cdCategory)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tbCriteria)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btQuery)
        Me.Name = "UserControlEbaySearch"
        Me.Size = New System.Drawing.Size(1089, 492)
        Me.tbctlMain.ResumeLayout(False)
        Me.tpSearchResult.ResumeLayout(False)
        Me.tpSearchResult.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchItemDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchItemBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpSingleItem.ResumeLayout(False)
        CType(Me.SimpleItemTypeDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SimpleItemTypeBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbItemInfo.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btGetFromClipboard As System.Windows.Forms.Button
    Friend WithEvents lbQueryCount As System.Windows.Forms.Label
    Friend WithEvents tbctlMain As System.Windows.Forms.TabControl
    Friend WithEvents tpSearchResult As System.Windows.Forms.TabPage
    Friend WithEvents tbFullPrice As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cbxRemoveNoiseWords As System.Windows.Forms.CheckBox
    Friend WithEvents btCancelFilter As System.Windows.Forms.Button
    Friend WithEvents btFilter As System.Windows.Forms.Button
    Friend WithEvents btToBadWord As System.Windows.Forms.Button
    Friend WithEvents lbBadWorld As System.Windows.Forms.ListBox
    Friend WithEvents btSaveWorlds As System.Windows.Forms.Button
    Friend WithEvents btCopyToClipboard As System.Windows.Forms.Button
    Friend WithEvents btRemoveFromSelectted As System.Windows.Forms.Button
    Friend WithEvents btAddToSelected As System.Windows.Forms.Button
    Friend WithEvents lbActualWord As System.Windows.Forms.ListBox
    Friend WithEvents lbWorldSource As System.Windows.Forms.ListBox
    Friend WithEvents tpSingleItem As System.Windows.Forms.TabPage
    Friend WithEvents WebBrowser1 As System.Windows.Forms.WebBrowser
    Friend WithEvents tbItemInfo As System.Windows.Forms.TabPage
    Friend WithEvents rtbDescription As System.Windows.Forms.RichTextBox
    Friend WithEvents btSingleItemQuery As System.Windows.Forms.Button
    Friend WithEvents cdCategory As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tbCriteria As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btQuery As System.Windows.Forms.Button
    Friend WithEvents SearchItemBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SimpleItemTypeBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SearchItemDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents SimpleItemTypeDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents tbItemID As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents label4 As System.Windows.Forms.Label
    Friend WithEvents lbTrackingWord As System.Windows.Forms.ListBox
    Friend WithEvents btTrackWord As System.Windows.Forms.Button
    Friend WithEvents tbCurrentWord As System.Windows.Forms.TextBox
    Friend WithEvents btStopTracking As System.Windows.Forms.Button
    Friend WithEvents btRunEbay As System.Windows.Forms.Button
    Friend WithEvents btRemove2 As System.Windows.Forms.Button
    Friend WithEvents tbFirstWord As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents galleryImage As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents TotalPriceString As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents seller As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bidCount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents timeLeftString As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents listingType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewImageColumn1 As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents ListingStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sellingStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents quantitySold As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend Shadows WithEvents location As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents viewItemURL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents primaryCategory As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bidCountSpecified As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents currentPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents currencyId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents shippingServiceCost As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShippingCurrencyId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents startTimeString As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents endTimeString As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents buyItNowAvailable As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents bestOfferEnabled As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents WatchCount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TitleDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SellerDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuantitySoldDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IsEndedDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents IsSoldDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents WordDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WordIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TimeMarkDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TimeMarkStringDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ItemIdDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LocationDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GalleryURLDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GalleryImageDataGridViewImageColumn As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents ViewItemURLDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PrimaryCategoryDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SellingStatusDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BidCountSpecifiedDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents BidCountDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CurrentPriceDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CurrencyIdDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalPriceStringDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShippingServiceCostDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShippingCurrencyIdDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StartTimeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StartTimeStringDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StartTimeSpecifiedDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents EndTimeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EndTimeStringDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EndTimeSpecifiedDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents TimeLeftDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TimeLeftStringDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ListingTypeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BuyItNowAvailableDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents BestOfferEnabledDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents WatchCountDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WatchCountSpecifiedDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ListingStatusDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
