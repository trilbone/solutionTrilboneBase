<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucEbayHistory
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
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.btLockSeller = New System.Windows.Forms.Button()
        Me.cbOnlySold = New System.Windows.Forms.CheckBox()
        Me.cbOnlyUnsold = New System.Windows.Forms.CheckBox()
        Me.btQuery = New System.Windows.Forms.Button()
        Me.btLockCategory = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cbWords = New System.Windows.Forms.ComboBox()
        Me.tbCtlMain = New System.Windows.Forms.TabControl()
        Me.tpGrid = New System.Windows.Forms.TabPage()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.WordDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.title = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GalleryURLDataGridViewImageColumn = New System.Windows.Forms.DataGridViewImageColumn()
        Me.TotalPriceStringDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.seller = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ListingTypeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ListingStatusDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.quantitySold = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BidCountDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TimeLeftDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LocationDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PrimaryCategoryDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ViewItemURLDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ClseBayHistoryItemBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.tpLists = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.lbNOTpresent = New System.Windows.Forms.ListBox()
        Me.lbPresent = New System.Windows.Forms.ListBox()
        Me.lbSold = New System.Windows.Forms.ListBox()
        Me.lbNotSold = New System.Windows.Forms.ListBox()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.TableLayoutPanel1.SuspendLayout()
        Me.tbCtlMain.SuspendLayout()
        Me.tpGrid.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ClseBayHistoryItemBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpLists.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 6
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.btLockSeller, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cbOnlySold, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cbOnlyUnsold, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btQuery, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btLockCategory, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Button1, 5, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cbWords, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.tbCtlMain, 0, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(4)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1052, 498)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'btLockSeller
        '
        Me.btLockSeller.Location = New System.Drawing.Point(475, 4)
        Me.btLockSeller.Margin = New System.Windows.Forms.Padding(4)
        Me.btLockSeller.Name = "btLockSeller"
        Me.btLockSeller.Size = New System.Drawing.Size(149, 28)
        Me.btLockSeller.TabIndex = 4
        Me.btLockSeller.Text = "Lock продавца"
        Me.btLockSeller.UseVisualStyleBackColor = True
        '
        'cbOnlySold
        '
        Me.cbOnlySold.AutoSize = True
        Me.cbOnlySold.Location = New System.Drawing.Point(4, 4)
        Me.cbOnlySold.Margin = New System.Windows.Forms.Padding(4)
        Me.cbOnlySold.Name = "cbOnlySold"
        Me.cbOnlySold.Size = New System.Drawing.Size(106, 21)
        Me.cbOnlySold.TabIndex = 0
        Me.cbOnlySold.Text = "Проданные"
        Me.cbOnlySold.UseVisualStyleBackColor = True
        '
        'cbOnlyUnsold
        '
        Me.cbOnlyUnsold.AutoSize = True
        Me.cbOnlyUnsold.Location = New System.Drawing.Point(160, 2)
        Me.cbOnlyUnsold.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cbOnlyUnsold.Name = "cbOnlyUnsold"
        Me.cbOnlyUnsold.Size = New System.Drawing.Size(126, 21)
        Me.cbOnlyUnsold.TabIndex = 3
        Me.cbOnlyUnsold.Text = "Не проданные"
        Me.cbOnlyUnsold.UseVisualStyleBackColor = True
        '
        'btQuery
        '
        Me.btQuery.Location = New System.Drawing.Point(318, 4)
        Me.btQuery.Margin = New System.Windows.Forms.Padding(4)
        Me.btQuery.Name = "btQuery"
        Me.btQuery.Size = New System.Drawing.Size(131, 28)
        Me.btQuery.TabIndex = 1
        Me.btQuery.Text = "Запрос"
        Me.btQuery.UseVisualStyleBackColor = True
        '
        'btLockCategory
        '
        Me.btLockCategory.Location = New System.Drawing.Point(632, 4)
        Me.btLockCategory.Margin = New System.Windows.Forms.Padding(4)
        Me.btLockCategory.Name = "btLockCategory"
        Me.btLockCategory.Size = New System.Drawing.Size(147, 28)
        Me.btLockCategory.TabIndex = 5
        Me.btLockCategory.Text = "Lock Категории"
        Me.btLockCategory.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(789, 4)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(196, 28)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "Применить Lock"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'cbWords
        '
        Me.cbWords.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbWords.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TableLayoutPanel1.SetColumnSpan(Me.cbWords, 2)
        Me.cbWords.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.cbWords.FormattingEnabled = True
        Me.cbWords.Location = New System.Drawing.Point(3, 40)
        Me.cbWords.Name = "cbWords"
        Me.cbWords.Size = New System.Drawing.Size(308, 33)
        Me.cbWords.TabIndex = 7
        '
        'tbCtlMain
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.tbCtlMain, 6)
        Me.tbCtlMain.Controls.Add(Me.tpGrid)
        Me.tbCtlMain.Controls.Add(Me.tpLists)
        Me.tbCtlMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbCtlMain.Location = New System.Drawing.Point(3, 75)
        Me.tbCtlMain.Name = "tbCtlMain"
        Me.tbCtlMain.SelectedIndex = 0
        Me.tbCtlMain.Size = New System.Drawing.Size(1046, 420)
        Me.tbCtlMain.TabIndex = 8
        '
        'tpGrid
        '
        Me.tpGrid.Controls.Add(Me.DataGridView1)
        Me.tpGrid.Location = New System.Drawing.Point(4, 25)
        Me.tpGrid.Name = "tpGrid"
        Me.tpGrid.Padding = New System.Windows.Forms.Padding(3)
        Me.tpGrid.Size = New System.Drawing.Size(1038, 391)
        Me.tpGrid.TabIndex = 0
        Me.tpGrid.Text = "Подробно"
        Me.tpGrid.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.WordDataGridViewTextBoxColumn, Me.title, Me.GalleryURLDataGridViewImageColumn, Me.TotalPriceStringDataGridViewTextBoxColumn, Me.seller, Me.ListingTypeDataGridViewTextBoxColumn, Me.ListingStatusDataGridViewTextBoxColumn, Me.quantitySold, Me.BidCountDataGridViewTextBoxColumn, Me.TimeLeftDataGridViewTextBoxColumn, Me.LocationDataGridViewTextBoxColumn, Me.PrimaryCategoryDataGridViewTextBoxColumn, Me.ViewItemURLDataGridViewTextBoxColumn})
        Me.DataGridView1.DataSource = Me.ClseBayHistoryItemBindingSource
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(3, 3)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(1032, 385)
        Me.DataGridView1.TabIndex = 2
        '
        'WordDataGridViewTextBoxColumn
        '
        Me.WordDataGridViewTextBoxColumn.DataPropertyName = "Word"
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.WordDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle11
        Me.WordDataGridViewTextBoxColumn.HeaderText = "Фраза"
        Me.WordDataGridViewTextBoxColumn.Name = "WordDataGridViewTextBoxColumn"
        '
        'title
        '
        Me.title.DataPropertyName = "title"
        Me.title.HeaderText = "title"
        Me.title.Name = "title"
        '
        'GalleryURLDataGridViewImageColumn
        '
        Me.GalleryURLDataGridViewImageColumn.DataPropertyName = "galleryImage"
        Me.GalleryURLDataGridViewImageColumn.HeaderText = "фото"
        Me.GalleryURLDataGridViewImageColumn.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom
        Me.GalleryURLDataGridViewImageColumn.Name = "GalleryURLDataGridViewImageColumn"
        Me.GalleryURLDataGridViewImageColumn.ReadOnly = True
        Me.GalleryURLDataGridViewImageColumn.Width = 160
        '
        'TotalPriceStringDataGridViewTextBoxColumn
        '
        Me.TotalPriceStringDataGridViewTextBoxColumn.DataPropertyName = "TotalPriceString"
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.TotalPriceStringDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle12
        Me.TotalPriceStringDataGridViewTextBoxColumn.HeaderText = "цена(полн.)"
        Me.TotalPriceStringDataGridViewTextBoxColumn.Name = "TotalPriceStringDataGridViewTextBoxColumn"
        Me.TotalPriceStringDataGridViewTextBoxColumn.ReadOnly = True
        '
        'seller
        '
        Me.seller.DataPropertyName = "seller"
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.seller.DefaultCellStyle = DataGridViewCellStyle13
        Me.seller.HeaderText = "продавец"
        Me.seller.Name = "seller"
        '
        'ListingTypeDataGridViewTextBoxColumn
        '
        Me.ListingTypeDataGridViewTextBoxColumn.DataPropertyName = "listingType"
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ListingTypeDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle14
        Me.ListingTypeDataGridViewTextBoxColumn.HeaderText = "тип"
        Me.ListingTypeDataGridViewTextBoxColumn.Name = "ListingTypeDataGridViewTextBoxColumn"
        '
        'ListingStatusDataGridViewTextBoxColumn
        '
        Me.ListingStatusDataGridViewTextBoxColumn.DataPropertyName = "ListingStatus"
        DataGridViewCellStyle15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ListingStatusDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle15
        Me.ListingStatusDataGridViewTextBoxColumn.HeaderText = "статус"
        Me.ListingStatusDataGridViewTextBoxColumn.Name = "ListingStatusDataGridViewTextBoxColumn"
        '
        'quantitySold
        '
        Me.quantitySold.DataPropertyName = "quantitySold"
        Me.quantitySold.HeaderText = "продано"
        Me.quantitySold.Name = "quantitySold"
        '
        'BidCountDataGridViewTextBoxColumn
        '
        Me.BidCountDataGridViewTextBoxColumn.DataPropertyName = "bidCount"
        DataGridViewCellStyle16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.BidCountDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle16
        Me.BidCountDataGridViewTextBoxColumn.HeaderText = "ставок"
        Me.BidCountDataGridViewTextBoxColumn.Name = "BidCountDataGridViewTextBoxColumn"
        '
        'TimeLeftDataGridViewTextBoxColumn
        '
        Me.TimeLeftDataGridViewTextBoxColumn.DataPropertyName = "timeLeftString"
        DataGridViewCellStyle17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.TimeLeftDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle17
        Me.TimeLeftDataGridViewTextBoxColumn.HeaderText = "осталось"
        Me.TimeLeftDataGridViewTextBoxColumn.Name = "TimeLeftDataGridViewTextBoxColumn"
        Me.TimeLeftDataGridViewTextBoxColumn.ReadOnly = True
        '
        'LocationDataGridViewTextBoxColumn
        '
        Me.LocationDataGridViewTextBoxColumn.DataPropertyName = "location"
        DataGridViewCellStyle18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.LocationDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle18
        Me.LocationDataGridViewTextBoxColumn.HeaderText = "страна"
        Me.LocationDataGridViewTextBoxColumn.Name = "LocationDataGridViewTextBoxColumn"
        '
        'PrimaryCategoryDataGridViewTextBoxColumn
        '
        Me.PrimaryCategoryDataGridViewTextBoxColumn.DataPropertyName = "primaryCategory"
        DataGridViewCellStyle19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.PrimaryCategoryDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle19
        Me.PrimaryCategoryDataGridViewTextBoxColumn.HeaderText = "категория"
        Me.PrimaryCategoryDataGridViewTextBoxColumn.Name = "PrimaryCategoryDataGridViewTextBoxColumn"
        '
        'ViewItemURLDataGridViewTextBoxColumn
        '
        Me.ViewItemURLDataGridViewTextBoxColumn.DataPropertyName = "viewItemURL"
        DataGridViewCellStyle20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ViewItemURLDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle20
        Me.ViewItemURLDataGridViewTextBoxColumn.HeaderText = "ссылка"
        Me.ViewItemURLDataGridViewTextBoxColumn.Name = "ViewItemURLDataGridViewTextBoxColumn"
        '
        'ClseBayHistoryItemBindingSource
        '
        Me.ClseBayHistoryItemBindingSource.DataSource = GetType(eBayFinding.clseBayHistoryItem)
        '
        'tpLists
        '
        Me.tpLists.Controls.Add(Me.TableLayoutPanel2)
        Me.tpLists.Location = New System.Drawing.Point(4, 25)
        Me.tpLists.Name = "tpLists"
        Me.tpLists.Padding = New System.Windows.Forms.Padding(3)
        Me.tpLists.Size = New System.Drawing.Size(1038, 391)
        Me.tpLists.TabIndex = 1
        Me.tpLists.Text = "Списки"
        Me.tpLists.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 3
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.lbNOTpresent, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.lbPresent, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.lbSold, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.lbNotSold, 2, 1)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1032, 385)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'lbNOTpresent
        '
        Me.lbNOTpresent.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lbNOTpresent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbNOTpresent.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lbNOTpresent.FormattingEnabled = True
        Me.lbNOTpresent.ItemHeight = 25
        Me.lbNOTpresent.Location = New System.Drawing.Point(3, 3)
        Me.lbNOTpresent.Name = "lbNOTpresent"
        Me.TableLayoutPanel2.SetRowSpan(Me.lbNOTpresent, 2)
        Me.lbNOTpresent.Size = New System.Drawing.Size(334, 379)
        Me.lbNOTpresent.TabIndex = 0
        '
        'lbPresent
        '
        Me.lbPresent.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lbPresent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbPresent.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lbPresent.FormattingEnabled = True
        Me.lbPresent.ItemHeight = 25
        Me.lbPresent.Location = New System.Drawing.Point(343, 3)
        Me.lbPresent.Name = "lbPresent"
        Me.TableLayoutPanel2.SetRowSpan(Me.lbPresent, 2)
        Me.lbPresent.Size = New System.Drawing.Size(334, 379)
        Me.lbPresent.TabIndex = 1
        '
        'lbSold
        '
        Me.lbSold.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lbSold.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbSold.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lbSold.FormattingEnabled = True
        Me.lbSold.ItemHeight = 25
        Me.lbSold.Location = New System.Drawing.Point(683, 3)
        Me.lbSold.Name = "lbSold"
        Me.lbSold.Size = New System.Drawing.Size(346, 186)
        Me.lbSold.TabIndex = 2
        '
        'lbNotSold
        '
        Me.lbNotSold.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lbNotSold.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbNotSold.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lbNotSold.FormattingEnabled = True
        Me.lbNotSold.ItemHeight = 25
        Me.lbNotSold.Location = New System.Drawing.Point(683, 195)
        Me.lbNotSold.Name = "lbNotSold"
        Me.lbNotSold.Size = New System.Drawing.Size(346, 187)
        Me.lbNotSold.TabIndex = 3
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(61, 4)
        '
        'ucEbayHistory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "ucEbayHistory"
        Me.Size = New System.Drawing.Size(1052, 498)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.tbCtlMain.ResumeLayout(False)
        Me.tpGrid.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ClseBayHistoryItemBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpLists.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents cbOnlySold As System.Windows.Forms.CheckBox
    Friend WithEvents btQuery As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents ClseBayHistoryItemBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents cbOnlyUnsold As System.Windows.Forms.CheckBox
    Friend WithEvents btLockSeller As System.Windows.Forms.Button
    Friend WithEvents btLockCategory As System.Windows.Forms.Button
    Friend WithEvents SellerDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QtySoldDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IsClosedDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents cbWords As System.Windows.Forms.ComboBox
    Friend WithEvents tbCtlMain As System.Windows.Forms.TabControl
    Friend WithEvents tpGrid As System.Windows.Forms.TabPage
    Friend WithEvents tpLists As System.Windows.Forms.TabPage
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lbNOTpresent As System.Windows.Forms.ListBox
    Friend WithEvents lbPresent As System.Windows.Forms.ListBox
    Friend WithEvents lbSold As System.Windows.Forms.ListBox
    Friend WithEvents lbNotSold As System.Windows.Forms.ListBox
    Friend WithEvents WordDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents title As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GalleryURLDataGridViewImageColumn As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents TotalPriceStringDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents seller As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ListingTypeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ListingStatusDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents quantitySold As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BidCountDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TimeLeftDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LocationDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PrimaryCategoryDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ViewItemURLDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip

End Class
