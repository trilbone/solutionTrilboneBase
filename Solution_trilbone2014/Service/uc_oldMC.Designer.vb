<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uc_oldMC
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgv_OldGoodMap = New System.Windows.Forms.DataGridView()
        Me.OldGoodMap_ResultBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.btQuery = New System.Windows.Forms.Button()
        Me.tbCodePartSearch = New System.Windows.Forms.TextBox()
        Me.tbNamePart = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btClearParam = New System.Windows.Forms.Button()
        Me.lbRecordCount = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tbGroupName = New System.Windows.Forms.TextBox()
        Me.btSortByName = New System.Windows.Forms.Button()
        Me.btSortByGroup = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.tbCodePartFilter = New System.Windows.Forms.TextBox()
        Me.btCodeFilter = New System.Windows.Forms.Button()
        Me.btCancelFilter = New System.Windows.Forms.Button()
        Me.tbFiltered = New System.Windows.Forms.TextBox()
        Me.btNameFilter = New System.Windows.Forms.Button()
        Me.btUpdateRow = New System.Windows.Forms.Button()
        Me.BtCreateNewRow = New System.Windows.Forms.Button()
        Me.btSortByNumber = New System.Windows.Forms.Button()
        Me.bt_fromClip = New System.Windows.Forms.Button()
        Me.btAddToList = New System.Windows.Forms.Button()
        Me.cbxOfflineOldMap = New System.Windows.Forms.CheckBox()
        Me.btSaveToDb = New System.Windows.Forms.Button()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Буржуи_на_выставке = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Валюта__Буржуи_на_выставке_ = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Производственный_номер_или_EAN13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Ответственный_Препаратор = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Время_препарации_в_часах__общее_ = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Препараторы_и_время = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Полная_стоимость_препарации_в_рублях = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Полная_стоимость_закупки_в_рублях = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Экспедиция__код_ = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Экспедиционный_закупочный_номер = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Экспедиционное_закупочное_примечание = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgv_OldGoodMap, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OldGoodMap_ResultBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgv_OldGoodMap
        '
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_OldGoodMap.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv_OldGoodMap.AutoGenerateColumns = False
        Me.dgv_OldGoodMap.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgv_OldGoodMap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_OldGoodMap.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn8, Me.DataGridViewTextBoxColumn9, Me.DataGridViewTextBoxColumn10, Me.DataGridViewTextBoxColumn11, Me.Буржуи_на_выставке, Me.Валюта__Буржуи_на_выставке_, Me.DataGridViewTextBoxColumn12, Me.DataGridViewTextBoxColumn13, Me.Производственный_номер_или_EAN13, Me.Ответственный_Препаратор, Me.Время_препарации_в_часах__общее_, Me.Препараторы_и_время, Me.Полная_стоимость_препарации_в_рублях, Me.Полная_стоимость_закупки_в_рублях, Me.Экспедиция__код_, Me.Экспедиционный_закупочный_номер, Me.Экспедиционное_закупочное_примечание})
        Me.dgv_OldGoodMap.DataSource = Me.OldGoodMap_ResultBindingSource
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_OldGoodMap.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgv_OldGoodMap.Location = New System.Drawing.Point(3, 123)
        Me.dgv_OldGoodMap.Name = "dgv_OldGoodMap"
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_OldGoodMap.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dgv_OldGoodMap.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_OldGoodMap.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgv_OldGoodMap.Size = New System.Drawing.Size(974, 479)
        Me.dgv_OldGoodMap.TabIndex = 1
        '
        'OldGoodMap_ResultBindingSource
        '
        Me.OldGoodMap_ResultBindingSource.DataSource = GetType(Service.oldGoodMap_Result)
        '
        'btQuery
        '
        Me.btQuery.Location = New System.Drawing.Point(111, 51)
        Me.btQuery.Name = "btQuery"
        Me.btQuery.Size = New System.Drawing.Size(249, 26)
        Me.btQuery.TabIndex = 2
        Me.btQuery.Text = "Запрос в базу"
        Me.btQuery.UseVisualStyleBackColor = True
        '
        'tbCodePartSearch
        '
        Me.tbCodePartSearch.Location = New System.Drawing.Point(141, 25)
        Me.tbCodePartSearch.Name = "tbCodePartSearch"
        Me.tbCodePartSearch.Size = New System.Drawing.Size(100, 20)
        Me.tbCodePartSearch.TabIndex = 4
        '
        'tbNamePart
        '
        Me.tbNamePart.Location = New System.Drawing.Point(260, 25)
        Me.tbNamePart.Name = "tbNamePart"
        Me.tbNamePart.Size = New System.Drawing.Size(100, 20)
        Me.tbNamePart.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(143, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(99, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Код/артикул част."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(263, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "часть названия"
        '
        'btClearParam
        '
        Me.btClearParam.Location = New System.Drawing.Point(19, 51)
        Me.btClearParam.Name = "btClearParam"
        Me.btClearParam.Size = New System.Drawing.Size(62, 26)
        Me.btClearParam.TabIndex = 3
        Me.btClearParam.Text = "очистить"
        Me.btClearParam.UseVisualStyleBackColor = True
        '
        'lbRecordCount
        '
        Me.lbRecordCount.AutoSize = True
        Me.lbRecordCount.Location = New System.Drawing.Point(1063, 46)
        Me.lbRecordCount.Name = "lbRecordCount"
        Me.lbRecordCount.Size = New System.Drawing.Size(50, 13)
        Me.lbRecordCount.TabIndex = 8
        Me.lbRecordCount.Text = "Записей"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(121, 13)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Часть наимен. группы"
        '
        'tbGroupName
        '
        Me.tbGroupName.Location = New System.Drawing.Point(19, 25)
        Me.tbGroupName.Name = "tbGroupName"
        Me.tbGroupName.Size = New System.Drawing.Size(100, 20)
        Me.tbGroupName.TabIndex = 9
        '
        'btSortByName
        '
        Me.btSortByName.Location = New System.Drawing.Point(381, 3)
        Me.btSortByName.Name = "btSortByName"
        Me.btSortByName.Size = New System.Drawing.Size(122, 34)
        Me.btSortByName.TabIndex = 11
        Me.btSortByName.Text = "Сортировка по названию"
        Me.btSortByName.UseVisualStyleBackColor = True
        '
        'btSortByGroup
        '
        Me.btSortByGroup.Location = New System.Drawing.Point(381, 43)
        Me.btSortByGroup.Name = "btSortByGroup"
        Me.btSortByGroup.Size = New System.Drawing.Size(122, 34)
        Me.btSortByGroup.TabIndex = 12
        Me.btSortByGroup.Text = "Сортировка по группе"
        Me.btSortByGroup.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.tbCodePartFilter)
        Me.GroupBox1.Controls.Add(Me.btCodeFilter)
        Me.GroupBox1.Controls.Add(Me.btCancelFilter)
        Me.GroupBox1.Controls.Add(Me.tbFiltered)
        Me.GroupBox1.Controls.Add(Me.btNameFilter)
        Me.GroupBox1.Location = New System.Drawing.Point(509, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(236, 113)
        Me.GroupBox1.TabIndex = 16
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Фильтры"
        '
        'tbCodePartFilter
        '
        Me.tbCodePartFilter.Location = New System.Drawing.Point(123, 20)
        Me.tbCodePartFilter.Name = "tbCodePartFilter"
        Me.tbCodePartFilter.Size = New System.Drawing.Size(107, 20)
        Me.tbCodePartFilter.TabIndex = 16
        '
        'btCodeFilter
        '
        Me.btCodeFilter.Location = New System.Drawing.Point(121, 46)
        Me.btCodeFilter.Name = "btCodeFilter"
        Me.btCodeFilter.Size = New System.Drawing.Size(109, 34)
        Me.btCodeFilter.TabIndex = 15
        Me.btCodeFilter.Text = "Фильтр по части кода"
        Me.btCodeFilter.UseVisualStyleBackColor = True
        '
        'btCancelFilter
        '
        Me.btCancelFilter.Location = New System.Drawing.Point(8, 86)
        Me.btCancelFilter.Name = "btCancelFilter"
        Me.btCancelFilter.Size = New System.Drawing.Size(222, 23)
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
        Me.btNameFilter.Size = New System.Drawing.Size(109, 34)
        Me.btNameFilter.TabIndex = 11
        Me.btNameFilter.Text = "Фильтр по части названия"
        Me.btNameFilter.UseVisualStyleBackColor = True
        '
        'btUpdateRow
        '
        Me.btUpdateRow.Location = New System.Drawing.Point(808, 32)
        Me.btUpdateRow.Name = "btUpdateRow"
        Me.btUpdateRow.Size = New System.Drawing.Size(162, 23)
        Me.btUpdateRow.TabIndex = 17
        Me.btUpdateRow.Text = "Сохранить текущую строку"
        Me.btUpdateRow.UseVisualStyleBackColor = True
        '
        'BtCreateNewRow
        '
        Me.BtCreateNewRow.Location = New System.Drawing.Point(808, 61)
        Me.BtCreateNewRow.Name = "BtCreateNewRow"
        Me.BtCreateNewRow.Size = New System.Drawing.Size(162, 23)
        Me.BtCreateNewRow.TabIndex = 18
        Me.BtCreateNewRow.Text = "Скопировать строку"
        Me.BtCreateNewRow.UseVisualStyleBackColor = True
        '
        'btSortByNumber
        '
        Me.btSortByNumber.Location = New System.Drawing.Point(381, 83)
        Me.btSortByNumber.Name = "btSortByNumber"
        Me.btSortByNumber.Size = New System.Drawing.Size(122, 34)
        Me.btSortByNumber.TabIndex = 19
        Me.btSortByNumber.Text = "Сортировка по номеру"
        Me.btSortByNumber.UseVisualStyleBackColor = True
        '
        'bt_fromClip
        '
        Me.bt_fromClip.Location = New System.Drawing.Point(19, 83)
        Me.bt_fromClip.Name = "bt_fromClip"
        Me.bt_fromClip.Size = New System.Drawing.Size(172, 23)
        Me.bt_fromClip.TabIndex = 20
        Me.bt_fromClip.Text = "Загрузка номеров из буфера"
        Me.bt_fromClip.UseVisualStyleBackColor = True
        '
        'btAddToList
        '
        Me.btAddToList.Location = New System.Drawing.Point(206, 83)
        Me.btAddToList.Name = "btAddToList"
        Me.btAddToList.Size = New System.Drawing.Size(154, 23)
        Me.btAddToList.TabIndex = 21
        Me.btAddToList.Text = "Добавить из буфера"
        Me.btAddToList.UseVisualStyleBackColor = True
        '
        'cbxOfflineOldMap
        '
        Me.cbxOfflineOldMap.AutoSize = True
        Me.cbxOfflineOldMap.Location = New System.Drawing.Point(808, 9)
        Me.cbxOfflineOldMap.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.cbxOfflineOldMap.Name = "cbxOfflineOldMap"
        Me.cbxOfflineOldMap.Size = New System.Drawing.Size(85, 17)
        Me.cbxOfflineOldMap.TabIndex = 22
        Me.cbxOfflineOldMap.Text = "Offilne mode"
        Me.cbxOfflineOldMap.UseVisualStyleBackColor = True
        '
        'btSaveToDb
        '
        Me.btSaveToDb.Location = New System.Drawing.Point(808, 90)
        Me.btSaveToDb.Name = "btSaveToDb"
        Me.btSaveToDb.Size = New System.Drawing.Size(162, 23)
        Me.btSaveToDb.TabIndex = 23
        Me.btSaveToDb.Text = "Сохранить на сервере"
        Me.btSaveToDb.UseVisualStyleBackColor = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(61, 4)
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "Группы"
        Me.DataGridViewTextBoxColumn1.HeaderText = "Группы"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "Наименование"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Наименование"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Width = 240
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "Артикул"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Артикул"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Width = 50
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "Код"
        Me.DataGridViewTextBoxColumn4.HeaderText = "Код"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Width = 50
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "Единица_измерения"
        Me.DataGridViewTextBoxColumn5.HeaderText = "Ед."
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.Width = 25
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "Закупочная_цена"
        Me.DataGridViewTextBoxColumn6.HeaderText = "Закупка"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.Width = 50
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "Валюта__Закупочная_цена_"
        Me.DataGridViewTextBoxColumn7.HeaderText = "Вал."
        Me.DataGridViewTextBoxColumn7.Items.AddRange(New Object() {"", "EUR", "RUR", "USD"})
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewTextBoxColumn7.Width = 50
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "Инвойс"
        Me.DataGridViewTextBoxColumn8.HeaderText = "Инвойс"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.Width = 50
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "Валюта__Инвойс_"
        Me.DataGridViewTextBoxColumn9.HeaderText = "Вал."
        Me.DataGridViewTextBoxColumn9.Items.AddRange(New Object() {"", "EUR", "RUR", "USD"})
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewTextBoxColumn9.Width = 50
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "Розничная_цена_в_магазине"
        Me.DataGridViewTextBoxColumn10.HeaderText = "Розничная"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.Width = 50
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "Валюта__Розничная_цена_в_магазине_"
        Me.DataGridViewTextBoxColumn11.HeaderText = "Вал."
        Me.DataGridViewTextBoxColumn11.Items.AddRange(New Object() {"", "EUR", "RUR", "USD"})
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn11.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewTextBoxColumn11.Width = 50
        '
        'Буржуи_на_выставке
        '
        Me.Буржуи_на_выставке.DataPropertyName = "Буржуи_на_выставке"
        Me.Буржуи_на_выставке.HeaderText = "Буржуи"
        Me.Буржуи_на_выставке.Name = "Буржуи_на_выставке"
        Me.Буржуи_на_выставке.Width = 50
        '
        'Валюта__Буржуи_на_выставке_
        '
        Me.Валюта__Буржуи_на_выставке_.DataPropertyName = "Валюта__Буржуи_на_выставке_"
        Me.Валюта__Буржуи_на_выставке_.HeaderText = "Вал."
        Me.Валюта__Буржуи_на_выставке_.Items.AddRange(New Object() {"", "EUR", "RUR", "USD"})
        Me.Валюта__Буржуи_на_выставке_.Name = "Валюта__Буржуи_на_выставке_"
        Me.Валюта__Буржуи_на_выставке_.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Валюта__Буржуи_на_выставке_.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Валюта__Буржуи_на_выставке_.Width = 50
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.DataPropertyName = "Розничная_в_офисе"
        Me.DataGridViewTextBoxColumn12.HeaderText = "офис"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.Width = 50
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.DataPropertyName = "Валюта__Розничная_в_офисе_"
        Me.DataGridViewTextBoxColumn13.HeaderText = "Вал."
        Me.DataGridViewTextBoxColumn13.Items.AddRange(New Object() {"", "EUR", "RUR", "USD"})
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn13.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewTextBoxColumn13.Width = 50
        '
        'Производственный_номер_или_EAN13
        '
        Me.Производственный_номер_или_EAN13.DataPropertyName = "Производственный_номер_или_EAN13"
        Me.Производственный_номер_или_EAN13.HeaderText = "Произв_номер"
        Me.Производственный_номер_или_EAN13.Name = "Производственный_номер_или_EAN13"
        Me.Производственный_номер_или_EAN13.Width = 50
        '
        'Ответственный_Препаратор
        '
        Me.Ответственный_Препаратор.DataPropertyName = "Ответственный_Препаратор"
        Me.Ответственный_Препаратор.HeaderText = "Препаратор"
        Me.Ответственный_Препаратор.Name = "Ответственный_Препаратор"
        '
        'Время_препарации_в_часах__общее_
        '
        Me.Время_препарации_в_часах__общее_.DataPropertyName = "Время_препарации_в_часах__общее_"
        Me.Время_препарации_в_часах__общее_.HeaderText = "Преп. час."
        Me.Время_препарации_в_часах__общее_.Name = "Время_препарации_в_часах__общее_"
        '
        'Препараторы_и_время
        '
        Me.Препараторы_и_время.DataPropertyName = "Препараторы_и_время"
        Me.Препараторы_и_время.HeaderText = "Преп. время"
        Me.Препараторы_и_время.Name = "Препараторы_и_время"
        '
        'Полная_стоимость_препарации_в_рублях
        '
        Me.Полная_стоимость_препарации_в_рублях.DataPropertyName = "Полная_стоимость_препарации_в_рублях"
        Me.Полная_стоимость_препарации_в_рублях.HeaderText = "Преп. в руб."
        Me.Полная_стоимость_препарации_в_рублях.Name = "Полная_стоимость_препарации_в_рублях"
        '
        'Полная_стоимость_закупки_в_рублях
        '
        Me.Полная_стоимость_закупки_в_рублях.DataPropertyName = "Полная_стоимость_закупки_в_рублях"
        Me.Полная_стоимость_закупки_в_рублях.HeaderText = "Закупка в руб."
        Me.Полная_стоимость_закупки_в_рублях.Name = "Полная_стоимость_закупки_в_рублях"
        '
        'Экспедиция__код_
        '
        Me.Экспедиция__код_.DataPropertyName = "Экспедиция__код_"
        Me.Экспедиция__код_.HeaderText = "Экспедиция"
        Me.Экспедиция__код_.Name = "Экспедиция__код_"
        '
        'Экспедиционный_закупочный_номер
        '
        Me.Экспедиционный_закупочный_номер.DataPropertyName = "Экспедиционный_закупочный_номер"
        Me.Экспедиционный_закупочный_номер.HeaderText = "Эксп. номер"
        Me.Экспедиционный_закупочный_номер.Name = "Экспедиционный_закупочный_номер"
        '
        'Экспедиционное_закупочное_примечание
        '
        Me.Экспедиционное_закупочное_примечание.DataPropertyName = "Экспедиционное_закупочное_примечание"
        Me.Экспедиционное_закупочное_примечание.HeaderText = "Эксп. прим."
        Me.Экспедиционное_закупочное_примечание.Name = "Экспедиционное_закупочное_примечание"
        '
        'uc_oldMC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btSaveToDb)
        Me.Controls.Add(Me.cbxOfflineOldMap)
        Me.Controls.Add(Me.btAddToList)
        Me.Controls.Add(Me.bt_fromClip)
        Me.Controls.Add(Me.btSortByNumber)
        Me.Controls.Add(Me.BtCreateNewRow)
        Me.Controls.Add(Me.btUpdateRow)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btSortByGroup)
        Me.Controls.Add(Me.btSortByName)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.tbGroupName)
        Me.Controls.Add(Me.lbRecordCount)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tbNamePart)
        Me.Controls.Add(Me.tbCodePartSearch)
        Me.Controls.Add(Me.btClearParam)
        Me.Controls.Add(Me.btQuery)
        Me.Controls.Add(Me.dgv_OldGoodMap)
        Me.Name = "uc_oldMC"
        Me.Size = New System.Drawing.Size(980, 605)
        CType(Me.dgv_OldGoodMap, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OldGoodMap_ResultBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents OldGoodMap_ResultBindingSource As Windows.Forms.BindingSource
    Friend WithEvents dgv_OldGoodMap As Windows.Forms.DataGridView
    Friend WithEvents btQuery As Windows.Forms.Button
    Friend WithEvents tbCodePartSearch As Windows.Forms.TextBox
    Friend WithEvents tbNamePart As Windows.Forms.TextBox
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents btClearParam As Windows.Forms.Button
    Friend WithEvents lbRecordCount As Windows.Forms.Label
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents tbGroupName As Windows.Forms.TextBox
    Friend WithEvents btSortByName As Windows.Forms.Button
    Friend WithEvents btSortByGroup As Windows.Forms.Button
    Friend WithEvents GroupBox1 As Windows.Forms.GroupBox
    Friend WithEvents btCancelFilter As Windows.Forms.Button
    Friend WithEvents tbFiltered As Windows.Forms.TextBox
    Friend WithEvents btNameFilter As Windows.Forms.Button
    Friend WithEvents btUpdateRow As Windows.Forms.Button
    Friend WithEvents BtCreateNewRow As Windows.Forms.Button
    Friend WithEvents btSortByNumber As Windows.Forms.Button
    Friend WithEvents tbCodePartFilter As Windows.Forms.TextBox
    Friend WithEvents btCodeFilter As Windows.Forms.Button
    Friend WithEvents bt_fromClip As Windows.Forms.Button
    Friend WithEvents btAddToList As Windows.Forms.Button
    Friend WithEvents cbxOfflineOldMap As System.Windows.Forms.CheckBox
    Friend WithEvents btSaveToDb As System.Windows.Forms.Button
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents DataGridViewTextBoxColumn1 As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents Буржуи_на_выставке As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Валюта__Буржуи_на_выставке_ As Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn13 As Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents Производственный_номер_или_EAN13 As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Ответственный_Препаратор As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Время_препарации_в_часах__общее_ As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Препараторы_и_время As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Полная_стоимость_препарации_в_рублях As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Полная_стоимость_закупки_в_рублях As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Экспедиция__код_ As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Экспедиционный_закупочный_номер As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Экспедиционное_закупочное_примечание As Windows.Forms.DataGridViewTextBoxColumn
End Class
