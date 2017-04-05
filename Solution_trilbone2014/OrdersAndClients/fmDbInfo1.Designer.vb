<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fmDbInfo1
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.lbNamesList = New System.Windows.Forms.ListBox()
        Me.lbNameCount = New System.Windows.Forms.Label()
        Me.tbName = New System.Windows.Forms.TextBox()
        Me.btQuery = New System.Windows.Forms.Button()
        Me.dgv_SampleResultByName = New System.Windows.Forms.DataGridView()
        Me.ColumnImage = New System.Windows.Forms.DataGridViewImageColumn()
        Me.lbSampleNumber = New System.Windows.Forms.Label()
        Me.lbSamplePrice = New System.Windows.Forms.Label()
        Me.lbStatus = New System.Windows.Forms.Label()
        Me.btSampleOnSale = New System.Windows.Forms.Button()
        Me.btShowCatalog = New System.Windows.Forms.Button()
        Me.tbCtlMain = New System.Windows.Forms.TabControl()
        Me.tpByName = New System.Windows.Forms.TabPage()
        Me.btShowInfo = New System.Windows.Forms.Button()
        Me.tpByWeight = New System.Windows.Forms.TabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btCancelFilter = New System.Windows.Forms.Button()
        Me.tbFiltered = New System.Windows.Forms.TextBox()
        Me.btNameFilter = New System.Windows.Forms.Button()
        Me.btSortByName = New System.Windows.Forms.Button()
        Me.gb_fromBuffer = New System.Windows.Forms.GroupBox()
        Me.btAddToList = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.bt_fromClip = New System.Windows.Forms.Button()
        Me.gb_byWeight = New System.Windows.Forms.GroupBox()
        Me.btWeightQuery = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbWeightFrom = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbWeightTo = New System.Windows.Forms.TextBox()
        Me.btClear = New System.Windows.Forms.Button()
        Me.lblWeightCount = New System.Windows.Forms.Label()
        Me.dgv_SampleWeightResult = New System.Windows.Forms.DataGridView()
        Me.Column_image = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Fossil_list = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tpGoodMap = New System.Windows.Forms.TabPage()
        Me.tpActiveWord = New System.Windows.Forms.TabPage()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.btTrilboneHistory = New System.Windows.Forms.Button()
        Me.Uc_oldMC1 = New Service.uc_oldMC()
        Me.SampleNumberDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SamplemainspeciesDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FossilcountDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SamplewidthDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SamplenetweightDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DatePhotoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WokerfullnameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FindByWeightResultBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SampleNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FossilfullnameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FossilcountDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FossillengthDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SamplemainspeciesDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SelecttbFossilsbynameResultBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.UcActiveWord1 = New Service.ucActiveWord()
        CType(Me.dgv_SampleResultByName, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbCtlMain.SuspendLayout()
        Me.tpByName.SuspendLayout()
        Me.tpByWeight.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.gb_fromBuffer.SuspendLayout()
        Me.gb_byWeight.SuspendLayout()
        CType(Me.dgv_SampleWeightResult, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpGoodMap.SuspendLayout()
        Me.tpActiveWord.SuspendLayout()
        CType(Me.FindByWeightResultBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SelecttbFossilsbynameResultBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbNamesList
        '
        Me.lbNamesList.FormattingEnabled = True
        Me.lbNamesList.Location = New System.Drawing.Point(6, 6)
        Me.lbNamesList.Name = "lbNamesList"
        Me.lbNamesList.Size = New System.Drawing.Size(215, 459)
        Me.lbNamesList.TabIndex = 0
        '
        'lbNameCount
        '
        Me.lbNameCount.AutoSize = True
        Me.lbNameCount.Location = New System.Drawing.Point(6, 476)
        Me.lbNameCount.Name = "lbNameCount"
        Me.lbNameCount.Size = New System.Drawing.Size(65, 13)
        Me.lbNameCount.TabIndex = 1
        Me.lbNameCount.Text = "вхождений "
        '
        'tbName
        '
        Me.tbName.Location = New System.Drawing.Point(6, 503)
        Me.tbName.Name = "tbName"
        Me.tbName.Size = New System.Drawing.Size(184, 20)
        Me.tbName.TabIndex = 2
        '
        'btQuery
        '
        Me.btQuery.Location = New System.Drawing.Point(6, 529)
        Me.btQuery.Name = "btQuery"
        Me.btQuery.Size = New System.Drawing.Size(154, 23)
        Me.btQuery.TabIndex = 3
        Me.btQuery.Text = "Запросить.."
        Me.btQuery.UseVisualStyleBackColor = True
        '
        'dgv_SampleResultByName
        '
        Me.dgv_SampleResultByName.AllowUserToAddRows = False
        Me.dgv_SampleResultByName.AllowUserToDeleteRows = False
        Me.dgv_SampleResultByName.AutoGenerateColumns = False
        Me.dgv_SampleResultByName.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.dgv_SampleResultByName.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_SampleResultByName.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColumnImage, Me.SampleNumberDataGridViewTextBoxColumn, Me.FossilfullnameDataGridViewTextBoxColumn, Me.FossilcountDataGridViewTextBoxColumn, Me.FossillengthDataGridViewTextBoxColumn, Me.SamplemainspeciesDataGridViewTextBoxColumn})
        Me.dgv_SampleResultByName.DataSource = Me.SelecttbFossilsbynameResultBindingSource
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_SampleResultByName.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgv_SampleResultByName.Location = New System.Drawing.Point(227, 6)
        Me.dgv_SampleResultByName.Name = "dgv_SampleResultByName"
        Me.dgv_SampleResultByName.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_SampleResultByName.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgv_SampleResultByName.Size = New System.Drawing.Size(753, 598)
        Me.dgv_SampleResultByName.TabIndex = 4
        '
        'ColumnImage
        '
        Me.ColumnImage.DataPropertyName = "Image"
        Me.ColumnImage.HeaderText = "фотка"
        Me.ColumnImage.Name = "ColumnImage"
        Me.ColumnImage.ReadOnly = True
        Me.ColumnImage.Width = 150
        '
        'lbSampleNumber
        '
        Me.lbSampleNumber.AutoSize = True
        Me.lbSampleNumber.Location = New System.Drawing.Point(1002, 26)
        Me.lbSampleNumber.Name = "lbSampleNumber"
        Me.lbSampleNumber.Size = New System.Drawing.Size(40, 13)
        Me.lbSampleNumber.TabIndex = 7
        Me.lbSampleNumber.Text = "sample"
        '
        'lbSamplePrice
        '
        Me.lbSamplePrice.AutoSize = True
        Me.lbSamplePrice.Location = New System.Drawing.Point(1002, 44)
        Me.lbSamplePrice.Name = "lbSamplePrice"
        Me.lbSamplePrice.Size = New System.Drawing.Size(31, 13)
        Me.lbSamplePrice.TabIndex = 9
        Me.lbSamplePrice.Text = "цена"
        '
        'lbStatus
        '
        Me.lbStatus.AutoSize = True
        Me.lbStatus.Location = New System.Drawing.Point(1002, 61)
        Me.lbStatus.Name = "lbStatus"
        Me.lbStatus.Size = New System.Drawing.Size(87, 13)
        Me.lbStatus.TabIndex = 10
        Me.lbStatus.Text = "статус продажи"
        '
        'btSampleOnSale
        '
        Me.btSampleOnSale.Location = New System.Drawing.Point(1005, 613)
        Me.btSampleOnSale.Name = "btSampleOnSale"
        Me.btSampleOnSale.Size = New System.Drawing.Size(112, 23)
        Me.btSampleOnSale.TabIndex = 11
        Me.btSampleOnSale.Text = "На продажу.."
        Me.btSampleOnSale.UseVisualStyleBackColor = True
        '
        'btShowCatalog
        '
        Me.btShowCatalog.Location = New System.Drawing.Point(1002, 93)
        Me.btShowCatalog.Name = "btShowCatalog"
        Me.btShowCatalog.Size = New System.Drawing.Size(112, 46)
        Me.btShowCatalog.TabIndex = 12
        Me.btShowCatalog.Text = "Каталог из таблицы.."
        Me.btShowCatalog.UseVisualStyleBackColor = True
        '
        'tbCtlMain
        '
        Me.tbCtlMain.Controls.Add(Me.tpGoodMap)
        Me.tbCtlMain.Controls.Add(Me.tpByWeight)
        Me.tbCtlMain.Controls.Add(Me.tpByName)
        Me.tbCtlMain.Controls.Add(Me.tpActiveWord)
        Me.tbCtlMain.Location = New System.Drawing.Point(2, 4)
        Me.tbCtlMain.Name = "tbCtlMain"
        Me.tbCtlMain.SelectedIndex = 0
        Me.tbCtlMain.Size = New System.Drawing.Size(994, 636)
        Me.tbCtlMain.TabIndex = 15
        '
        'tpByName
        '
        Me.tpByName.Controls.Add(Me.btShowInfo)
        Me.tpByName.Controls.Add(Me.dgv_SampleResultByName)
        Me.tpByName.Controls.Add(Me.lbNamesList)
        Me.tpByName.Controls.Add(Me.tbName)
        Me.tpByName.Controls.Add(Me.lbNameCount)
        Me.tpByName.Controls.Add(Me.btQuery)
        Me.tpByName.Location = New System.Drawing.Point(4, 22)
        Me.tpByName.Name = "tpByName"
        Me.tpByName.Padding = New System.Windows.Forms.Padding(3)
        Me.tpByName.Size = New System.Drawing.Size(986, 610)
        Me.tpByName.TabIndex = 0
        Me.tpByName.Text = "По имени"
        Me.tpByName.UseVisualStyleBackColor = True
        '
        'btShowInfo
        '
        Me.btShowInfo.Location = New System.Drawing.Point(6, 581)
        Me.btShowInfo.Name = "btShowInfo"
        Me.btShowInfo.Size = New System.Drawing.Size(154, 23)
        Me.btShowInfo.TabIndex = 14
        Me.btShowInfo.Text = "Показать стат по имени"
        Me.btShowInfo.UseVisualStyleBackColor = True
        '
        'tpByWeight
        '
        Me.tpByWeight.Controls.Add(Me.GroupBox1)
        Me.tpByWeight.Controls.Add(Me.btSortByName)
        Me.tpByWeight.Controls.Add(Me.gb_fromBuffer)
        Me.tpByWeight.Controls.Add(Me.gb_byWeight)
        Me.tpByWeight.Controls.Add(Me.btClear)
        Me.tpByWeight.Controls.Add(Me.lblWeightCount)
        Me.tpByWeight.Controls.Add(Me.dgv_SampleWeightResult)
        Me.tpByWeight.Location = New System.Drawing.Point(4, 22)
        Me.tpByWeight.Name = "tpByWeight"
        Me.tpByWeight.Padding = New System.Windows.Forms.Padding(3)
        Me.tpByWeight.Size = New System.Drawing.Size(986, 610)
        Me.tpByWeight.TabIndex = 1
        Me.tpByWeight.Text = "по списку или весу"
        Me.tpByWeight.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btCancelFilter)
        Me.GroupBox1.Controls.Add(Me.tbFiltered)
        Me.GroupBox1.Controls.Add(Me.btNameFilter)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 474)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(122, 130)
        Me.GroupBox1.TabIndex = 15
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Фильтры"
        '
        'btCancelFilter
        '
        Me.btCancelFilter.Location = New System.Drawing.Point(6, 95)
        Me.btCancelFilter.Name = "btCancelFilter"
        Me.btCancelFilter.Size = New System.Drawing.Size(107, 23)
        Me.btCancelFilter.TabIndex = 14
        Me.btCancelFilter.Text = "показать все"
        Me.btCancelFilter.UseVisualStyleBackColor = True
        '
        'tbFiltered
        '
        Me.tbFiltered.Location = New System.Drawing.Point(8, 20)
        Me.tbFiltered.Name = "tbFiltered"
        Me.tbFiltered.Size = New System.Drawing.Size(107, 20)
        Me.tbFiltered.TabIndex = 12
        '
        'btNameFilter
        '
        Me.btNameFilter.Location = New System.Drawing.Point(6, 46)
        Me.btNameFilter.Name = "btNameFilter"
        Me.btNameFilter.Size = New System.Drawing.Size(109, 43)
        Me.btNameFilter.TabIndex = 11
        Me.btNameFilter.Text = "Фильтр по части названия"
        Me.btNameFilter.UseVisualStyleBackColor = True
        '
        'btSortByName
        '
        Me.btSortByName.Location = New System.Drawing.Point(6, 434)
        Me.btSortByName.Name = "btSortByName"
        Me.btSortByName.Size = New System.Drawing.Size(122, 34)
        Me.btSortByName.TabIndex = 10
        Me.btSortByName.Text = "Сортировка по названию"
        Me.btSortByName.UseVisualStyleBackColor = True
        '
        'gb_fromBuffer
        '
        Me.gb_fromBuffer.Controls.Add(Me.btAddToList)
        Me.gb_fromBuffer.Controls.Add(Me.Label3)
        Me.gb_fromBuffer.Controls.Add(Me.bt_fromClip)
        Me.gb_fromBuffer.Location = New System.Drawing.Point(3, 79)
        Me.gb_fromBuffer.Name = "gb_fromBuffer"
        Me.gb_fromBuffer.Size = New System.Drawing.Size(123, 131)
        Me.gb_fromBuffer.TabIndex = 9
        Me.gb_fromBuffer.TabStop = False
        Me.gb_fromBuffer.Text = "номера из буфера"
        '
        'btAddToList
        '
        Me.btAddToList.Location = New System.Drawing.Point(6, 100)
        Me.btAddToList.Name = "btAddToList"
        Me.btAddToList.Size = New System.Drawing.Size(111, 23)
        Me.btAddToList.TabIndex = 2
        Me.btAddToList.Text = "Добавить"
        Me.btAddToList.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(8, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 48)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Сначала скопируй в буфер номера с разделителем"
        '
        'bt_fromClip
        '
        Me.bt_fromClip.Location = New System.Drawing.Point(6, 71)
        Me.bt_fromClip.Name = "bt_fromClip"
        Me.bt_fromClip.Size = New System.Drawing.Size(111, 23)
        Me.bt_fromClip.TabIndex = 0
        Me.bt_fromClip.Text = "Загрузка"
        Me.bt_fromClip.UseVisualStyleBackColor = True
        '
        'gb_byWeight
        '
        Me.gb_byWeight.Controls.Add(Me.btWeightQuery)
        Me.gb_byWeight.Controls.Add(Me.Label1)
        Me.gb_byWeight.Controls.Add(Me.tbWeightFrom)
        Me.gb_byWeight.Controls.Add(Me.Label2)
        Me.gb_byWeight.Controls.Add(Me.tbWeightTo)
        Me.gb_byWeight.Location = New System.Drawing.Point(3, 216)
        Me.gb_byWeight.Name = "gb_byWeight"
        Me.gb_byWeight.Size = New System.Drawing.Size(121, 110)
        Me.gb_byWeight.TabIndex = 8
        Me.gb_byWeight.TabStop = False
        Me.gb_byWeight.Text = "Поиск по весу"
        '
        'btWeightQuery
        '
        Me.btWeightQuery.Location = New System.Drawing.Point(6, 78)
        Me.btWeightQuery.Name = "btWeightQuery"
        Me.btWeightQuery.Size = New System.Drawing.Size(110, 23)
        Me.btWeightQuery.TabIndex = 5
        Me.btWeightQuery.Text = "Запрос"
        Me.btWeightQuery.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Вес от, кг"
        '
        'tbWeightFrom
        '
        Me.tbWeightFrom.Location = New System.Drawing.Point(66, 22)
        Me.tbWeightFrom.Name = "tbWeightFrom"
        Me.tbWeightFrom.Size = New System.Drawing.Size(50, 20)
        Me.tbWeightFrom.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Вес до, кг"
        '
        'tbWeightTo
        '
        Me.tbWeightTo.Location = New System.Drawing.Point(66, 48)
        Me.tbWeightTo.Name = "tbWeightTo"
        Me.tbWeightTo.Size = New System.Drawing.Size(50, 20)
        Me.tbWeightTo.TabIndex = 4
        '
        'btClear
        '
        Me.btClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btClear.Location = New System.Drawing.Point(18, 9)
        Me.btClear.Name = "btClear"
        Me.btClear.Size = New System.Drawing.Size(110, 36)
        Me.btClear.TabIndex = 7
        Me.btClear.Text = "Очистить"
        Me.btClear.UseVisualStyleBackColor = True
        '
        'lblWeightCount
        '
        Me.lblWeightCount.AutoSize = True
        Me.lblWeightCount.Location = New System.Drawing.Point(15, 54)
        Me.lblWeightCount.Name = "lblWeightCount"
        Me.lblWeightCount.Size = New System.Drawing.Size(65, 13)
        Me.lblWeightCount.TabIndex = 6
        Me.lblWeightCount.Text = "вхождений "
        '
        'dgv_SampleWeightResult
        '
        Me.dgv_SampleWeightResult.AutoGenerateColumns = False
        Me.dgv_SampleWeightResult.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.dgv_SampleWeightResult.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.dgv_SampleWeightResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_SampleWeightResult.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SampleNumberDataGridViewTextBoxColumn1, Me.SamplemainspeciesDataGridViewTextBoxColumn1, Me.Column_image, Me.FossilcountDataGridViewTextBoxColumn1, Me.Fossil_list, Me.SamplewidthDataGridViewTextBoxColumn, Me.SamplenetweightDataGridViewTextBoxColumn, Me.DatePhotoDataGridViewTextBoxColumn, Me.WokerfullnameDataGridViewTextBoxColumn})
        Me.dgv_SampleWeightResult.DataSource = Me.FindByWeightResultBindingSource
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_SampleWeightResult.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgv_SampleWeightResult.Location = New System.Drawing.Point(134, 6)
        Me.dgv_SampleWeightResult.Name = "dgv_SampleWeightResult"
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_SampleWeightResult.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dgv_SampleWeightResult.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_SampleWeightResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgv_SampleWeightResult.Size = New System.Drawing.Size(846, 598)
        Me.dgv_SampleWeightResult.TabIndex = 0
        '
        'Column_image
        '
        Me.Column_image.DataPropertyName = "Image"
        Me.Column_image.HeaderText = "img"
        Me.Column_image.Name = "Column_image"
        Me.Column_image.ReadOnly = True
        Me.Column_image.Width = 150
        '
        'Fossil_list
        '
        Me.Fossil_list.DataPropertyName = "Fossil_list"
        Me.Fossil_list.HeaderText = "Fossil_list"
        Me.Fossil_list.Name = "Fossil_list"
        Me.Fossil_list.Width = 200
        '
        'tpGoodMap
        '
        Me.tpGoodMap.Controls.Add(Me.Uc_oldMC1)
        Me.tpGoodMap.Location = New System.Drawing.Point(4, 22)
        Me.tpGoodMap.Name = "tpGoodMap"
        Me.tpGoodMap.Padding = New System.Windows.Forms.Padding(3)
        Me.tpGoodMap.Size = New System.Drawing.Size(986, 610)
        Me.tpGoodMap.TabIndex = 3
        Me.tpGoodMap.Text = "Карточки"
        Me.tpGoodMap.UseVisualStyleBackColor = True
        '
        'tpActiveWord
        '
        Me.tpActiveWord.Controls.Add(Me.UcActiveWord1)
        Me.tpActiveWord.Location = New System.Drawing.Point(4, 22)
        Me.tpActiveWord.Margin = New System.Windows.Forms.Padding(2)
        Me.tpActiveWord.Name = "tpActiveWord"
        Me.tpActiveWord.Padding = New System.Windows.Forms.Padding(2)
        Me.tpActiveWord.Size = New System.Drawing.Size(986, 610)
        Me.tpActiveWord.TabIndex = 2
        Me.tpActiveWord.Text = "Управление фразами eBay"
        Me.tpActiveWord.UseVisualStyleBackColor = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(61, 4)
        '
        'btTrilboneHistory
        '
        Me.btTrilboneHistory.Location = New System.Drawing.Point(1002, 163)
        Me.btTrilboneHistory.Name = "btTrilboneHistory"
        Me.btTrilboneHistory.Size = New System.Drawing.Size(111, 49)
        Me.btTrilboneHistory.TabIndex = 16
        Me.btTrilboneHistory.Text = "История предложений"
        Me.btTrilboneHistory.UseVisualStyleBackColor = True
        '
        'Uc_oldMC1
        '
        Me.Uc_oldMC1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Uc_oldMC1.Location = New System.Drawing.Point(0, 0)
        Me.Uc_oldMC1.Name = "Uc_oldMC1"
        Me.Uc_oldMC1.Size = New System.Drawing.Size(986, 604)
        Me.Uc_oldMC1.TabIndex = 0
        '
        'SampleNumberDataGridViewTextBoxColumn1
        '
        Me.SampleNumberDataGridViewTextBoxColumn1.DataPropertyName = "ShotNumber"
        Me.SampleNumberDataGridViewTextBoxColumn1.HeaderText = "Номер"
        Me.SampleNumberDataGridViewTextBoxColumn1.Name = "SampleNumberDataGridViewTextBoxColumn1"
        Me.SampleNumberDataGridViewTextBoxColumn1.ReadOnly = True
        Me.SampleNumberDataGridViewTextBoxColumn1.Width = 70
        '
        'SamplemainspeciesDataGridViewTextBoxColumn1
        '
        Me.SamplemainspeciesDataGridViewTextBoxColumn1.DataPropertyName = "Sample_main_species"
        Me.SamplemainspeciesDataGridViewTextBoxColumn1.HeaderText = "название"
        Me.SamplemainspeciesDataGridViewTextBoxColumn1.Name = "SamplemainspeciesDataGridViewTextBoxColumn1"
        Me.SamplemainspeciesDataGridViewTextBoxColumn1.Width = 200
        '
        'FossilcountDataGridViewTextBoxColumn1
        '
        Me.FossilcountDataGridViewTextBoxColumn1.DataPropertyName = "Fossil_count"
        Me.FossilcountDataGridViewTextBoxColumn1.HeaderText = "обьект."
        Me.FossilcountDataGridViewTextBoxColumn1.Name = "FossilcountDataGridViewTextBoxColumn1"
        Me.FossilcountDataGridViewTextBoxColumn1.Width = 30
        '
        'SamplewidthDataGridViewTextBoxColumn
        '
        Me.SamplewidthDataGridViewTextBoxColumn.DataPropertyName = "SampleDimension"
        Me.SamplewidthDataGridViewTextBoxColumn.HeaderText = "разм."
        Me.SamplewidthDataGridViewTextBoxColumn.Name = "SamplewidthDataGridViewTextBoxColumn"
        Me.SamplewidthDataGridViewTextBoxColumn.ReadOnly = True
        Me.SamplewidthDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.SamplewidthDataGridViewTextBoxColumn.Width = 70
        '
        'SamplenetweightDataGridViewTextBoxColumn
        '
        Me.SamplenetweightDataGridViewTextBoxColumn.DataPropertyName = "Sample_net_weight"
        Me.SamplenetweightDataGridViewTextBoxColumn.HeaderText = "вес, кг"
        Me.SamplenetweightDataGridViewTextBoxColumn.Name = "SamplenetweightDataGridViewTextBoxColumn"
        Me.SamplenetweightDataGridViewTextBoxColumn.Width = 40
        '
        'DatePhotoDataGridViewTextBoxColumn
        '
        Me.DatePhotoDataGridViewTextBoxColumn.DataPropertyName = "Date_Photo"
        Me.DatePhotoDataGridViewTextBoxColumn.HeaderText = "дата"
        Me.DatePhotoDataGridViewTextBoxColumn.Name = "DatePhotoDataGridViewTextBoxColumn"
        Me.DatePhotoDataGridViewTextBoxColumn.Width = 50
        '
        'WokerfullnameDataGridViewTextBoxColumn
        '
        Me.WokerfullnameDataGridViewTextBoxColumn.DataPropertyName = "Woker_full_name"
        Me.WokerfullnameDataGridViewTextBoxColumn.HeaderText = "сотрудник"
        Me.WokerfullnameDataGridViewTextBoxColumn.Name = "WokerfullnameDataGridViewTextBoxColumn"
        Me.WokerfullnameDataGridViewTextBoxColumn.Width = 70
        '
        'FindByWeightResultBindingSource
        '
        Me.FindByWeightResultBindingSource.DataSource = GetType(Service.FindByWeight_Result)
        '
        'SampleNumberDataGridViewTextBoxColumn
        '
        Me.SampleNumberDataGridViewTextBoxColumn.DataPropertyName = "SampleNumber"
        Me.SampleNumberDataGridViewTextBoxColumn.HeaderText = "номер"
        Me.SampleNumberDataGridViewTextBoxColumn.Name = "SampleNumberDataGridViewTextBoxColumn"
        '
        'FossilfullnameDataGridViewTextBoxColumn
        '
        Me.FossilfullnameDataGridViewTextBoxColumn.DataPropertyName = "Fossil_full_name"
        Me.FossilfullnameDataGridViewTextBoxColumn.HeaderText = "имя фосилии"
        Me.FossilfullnameDataGridViewTextBoxColumn.Name = "FossilfullnameDataGridViewTextBoxColumn"
        Me.FossilfullnameDataGridViewTextBoxColumn.Width = 200
        '
        'FossilcountDataGridViewTextBoxColumn
        '
        Me.FossilcountDataGridViewTextBoxColumn.DataPropertyName = "Fossil_count"
        Me.FossilcountDataGridViewTextBoxColumn.HeaderText = "шт на обр."
        Me.FossilcountDataGridViewTextBoxColumn.Name = "FossilcountDataGridViewTextBoxColumn"
        Me.FossilcountDataGridViewTextBoxColumn.Width = 50
        '
        'FossillengthDataGridViewTextBoxColumn
        '
        Me.FossillengthDataGridViewTextBoxColumn.DataPropertyName = "Fossil_length"
        Me.FossillengthDataGridViewTextBoxColumn.HeaderText = "длина ф."
        Me.FossillengthDataGridViewTextBoxColumn.Name = "FossillengthDataGridViewTextBoxColumn"
        Me.FossillengthDataGridViewTextBoxColumn.Width = 50
        '
        'SamplemainspeciesDataGridViewTextBoxColumn
        '
        Me.SamplemainspeciesDataGridViewTextBoxColumn.DataPropertyName = "Sample_main_species"
        Me.SamplemainspeciesDataGridViewTextBoxColumn.HeaderText = "Основной предмет"
        Me.SamplemainspeciesDataGridViewTextBoxColumn.Name = "SamplemainspeciesDataGridViewTextBoxColumn"
        Me.SamplemainspeciesDataGridViewTextBoxColumn.Width = 150
        '
        'SelecttbFossilsbynameResultBindingSource
        '
        Me.SelecttbFossilsbynameResultBindingSource.DataSource = GetType(Service.Select_tb_Fossils_byname_Result)
        '
        'UcActiveWord1
        '
        Me.UcActiveWord1.Location = New System.Drawing.Point(4, 2)
        Me.UcActiveWord1.Margin = New System.Windows.Forms.Padding(2)
        Me.UcActiveWord1.Name = "UcActiveWord1"
        Me.UcActiveWord1.Size = New System.Drawing.Size(461, 382)
        Me.UcActiveWord1.TabIndex = 0
        '
        'fmDbInfo1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1126, 652)
        Me.Controls.Add(Me.btTrilboneHistory)
        Me.Controls.Add(Me.tbCtlMain)
        Me.Controls.Add(Me.btShowCatalog)
        Me.Controls.Add(Me.btSampleOnSale)
        Me.Controls.Add(Me.lbStatus)
        Me.Controls.Add(Me.lbSamplePrice)
        Me.Controls.Add(Me.lbSampleNumber)
        Me.Name = "fmDbInfo1"
        Me.Text = "Информация по названиям (БД)"
        CType(Me.dgv_SampleResultByName, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbCtlMain.ResumeLayout(False)
        Me.tpByName.ResumeLayout(False)
        Me.tpByName.PerformLayout()
        Me.tpByWeight.ResumeLayout(False)
        Me.tpByWeight.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.gb_fromBuffer.ResumeLayout(False)
        Me.gb_byWeight.ResumeLayout(False)
        Me.gb_byWeight.PerformLayout()
        CType(Me.dgv_SampleWeightResult, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpGoodMap.ResumeLayout(False)
        Me.tpActiveWord.ResumeLayout(False)
        CType(Me.FindByWeightResultBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SelecttbFossilsbynameResultBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbNamesList As System.Windows.Forms.ListBox
    Friend WithEvents lbNameCount As System.Windows.Forms.Label
    Friend WithEvents tbName As System.Windows.Forms.TextBox
    Friend WithEvents btQuery As System.Windows.Forms.Button
    Friend WithEvents dgv_SampleResultByName As System.Windows.Forms.DataGridView
    Friend WithEvents SelecttbFossilsbynameResultBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents lbSampleNumber As System.Windows.Forms.Label
    Friend WithEvents lbSamplePrice As System.Windows.Forms.Label
    Friend WithEvents lbStatus As System.Windows.Forms.Label
    Friend WithEvents btSampleOnSale As System.Windows.Forms.Button
    Friend WithEvents btShowCatalog As System.Windows.Forms.Button
    Friend WithEvents tbCtlMain As System.Windows.Forms.TabControl
    Friend WithEvents tpByName As System.Windows.Forms.TabPage
    Friend WithEvents tpByWeight As System.Windows.Forms.TabPage
    Friend WithEvents btWeightQuery As System.Windows.Forms.Button
    Friend WithEvents tbWeightTo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tbWeightFrom As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgv_SampleWeightResult As System.Windows.Forms.DataGridView
    Friend WithEvents FindByWeightResultBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents lblWeightCount As System.Windows.Forms.Label
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents btShowInfo As System.Windows.Forms.Button
    Friend WithEvents tpActiveWord As System.Windows.Forms.TabPage
    Friend WithEvents UcActiveWord1 As Service.ucActiveWord
    Friend WithEvents gb_fromBuffer As GroupBox
    Friend WithEvents bt_fromClip As Button
    Friend WithEvents gb_byWeight As GroupBox
    Friend WithEvents btClear As Button
    Friend WithEvents ColumnImage As DataGridViewImageColumn
    Friend WithEvents SampleNumberDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents FossilfullnameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents FossilcountDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents FossillengthDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents SamplemainspeciesDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents Label3 As Label
    Friend WithEvents btTrilboneHistory As Button
    Friend WithEvents btSortByName As Button
    Friend WithEvents SampleNumberDataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents SamplemainspeciesDataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents Column_image As DataGridViewImageColumn
    Friend WithEvents FossilcountDataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents Fossil_list As DataGridViewTextBoxColumn
    Friend WithEvents SamplewidthDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents SamplenetweightDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents DatePhotoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents WokerfullnameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents btNameFilter As Button
    Friend WithEvents tbFiltered As TextBox
    Friend WithEvents btCancelFilter As Button
    Friend WithEvents btAddToList As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents tpGoodMap As TabPage
    Friend WithEvents Uc_oldMC1 As Service.uc_oldMC
End Class
