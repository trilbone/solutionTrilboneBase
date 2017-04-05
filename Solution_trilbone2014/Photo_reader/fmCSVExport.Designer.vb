<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fmCSVExport
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
        Dim SampleNumberEAN13Label As System.Windows.Forms.Label
        Dim NameLabel As System.Windows.Forms.Label
        Dim ShotNameLabel As System.Windows.Forms.Label
        Dim PriceLabel As System.Windows.Forms.Label
        Dim CurrencyLabel As System.Windows.Forms.Label
        Dim DescriptionTXTLabel As System.Windows.Forms.Label
        Dim LinkToNameLabel As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fmCSVExport))
        Me.lbGoods = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbCurrentGood = New System.Windows.Forms.TextBox()
        Me.btAddGoodGroup = New System.Windows.Forms.Button()
        Me.btRemoveGoodGroup = New System.Windows.Forms.Button()
        Me.btRemoveSample = New System.Windows.Forms.Button()
        Me.btAddSample = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lbSamples = New System.Windows.Forms.ListBox()
        Me.ClsSampleListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SampleNumberEAN13TextBox = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cbConvertToCurr = New System.Windows.Forms.ComboBox()
        Me.btConversion = New System.Windows.Forms.Button()
        Me.LinkToNameTextBox = New System.Windows.Forms.TextBox()
        Me.DescriptionTXTRichTextBox = New System.Windows.Forms.RichTextBox()
        Me.CurrencyTextBox = New System.Windows.Forms.TextBox()
        Me.PriceTextBox = New System.Windows.Forms.TextBox()
        Me.ShotNameTextBox = New System.Windows.Forms.TextBox()
        Me.NameTextBox = New System.Windows.Forms.TextBox()
        Me.btSaveDataSource = New System.Windows.Forms.Button()
        Me.btClose = New System.Windows.Forms.Button()
        Me.btWriteCSV = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CSVCommaTextBox = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CSVpathTextBox = New System.Windows.Forms.TextBox()
        Me.btCSVpath = New System.Windows.Forms.Button()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.btChangeGood = New System.Windows.Forms.Button()
        Me.BindingNavigator1 = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorAddNewItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel()
        Me.BindingNavigatorDeleteItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox()
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.СохранитьToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btRefresh = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        SampleNumberEAN13Label = New System.Windows.Forms.Label()
        NameLabel = New System.Windows.Forms.Label()
        ShotNameLabel = New System.Windows.Forms.Label()
        PriceLabel = New System.Windows.Forms.Label()
        CurrencyLabel = New System.Windows.Forms.Label()
        DescriptionTXTLabel = New System.Windows.Forms.Label()
        LinkToNameLabel = New System.Windows.Forms.Label()
        CType(Me.ClsSampleListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.BindingNavigator1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BindingNavigator1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SampleNumberEAN13Label
        '
        SampleNumberEAN13Label.AutoSize = True
        SampleNumberEAN13Label.Location = New System.Drawing.Point(6, 22)
        SampleNumberEAN13Label.Name = "SampleNumberEAN13Label"
        SampleNumberEAN13Label.Size = New System.Drawing.Size(96, 13)
        SampleNumberEAN13Label.TabIndex = 10
        SampleNumberEAN13Label.Text = "Штрих-код EAN13"
        '
        'NameLabel
        '
        NameLabel.AutoSize = True
        NameLabel.Location = New System.Drawing.Point(6, 55)
        NameLabel.Name = "NameLabel"
        NameLabel.Size = New System.Drawing.Size(108, 13)
        NameLabel.TabIndex = 11
        NameLabel.Text = "Основное название"
        '
        'ShotNameLabel
        '
        ShotNameLabel.AutoSize = True
        ShotNameLabel.Location = New System.Drawing.Point(6, 84)
        ShotNameLabel.Name = "ShotNameLabel"
        ShotNameLabel.Size = New System.Drawing.Size(106, 13)
        ShotNameLabel.TabIndex = 12
        ShotNameLabel.Text = "Короткое название"
        '
        'PriceLabel
        '
        PriceLabel.AutoSize = True
        PriceLabel.Location = New System.Drawing.Point(6, 110)
        PriceLabel.Name = "PriceLabel"
        PriceLabel.Size = New System.Drawing.Size(33, 13)
        PriceLabel.TabIndex = 13
        PriceLabel.Text = "Цена"
        '
        'CurrencyLabel
        '
        CurrencyLabel.AutoSize = True
        CurrencyLabel.Location = New System.Drawing.Point(6, 133)
        CurrencyLabel.Name = "CurrencyLabel"
        CurrencyLabel.Size = New System.Drawing.Size(45, 13)
        CurrencyLabel.TabIndex = 14
        CurrencyLabel.Text = "Валюта"
        '
        'DescriptionTXTLabel
        '
        DescriptionTXTLabel.AutoSize = True
        DescriptionTXTLabel.Location = New System.Drawing.Point(6, 173)
        DescriptionTXTLabel.Name = "DescriptionTXTLabel"
        DescriptionTXTLabel.Size = New System.Drawing.Size(57, 13)
        DescriptionTXTLabel.TabIndex = 15
        DescriptionTXTLabel.Text = "Описание"
        '
        'LinkToNameLabel
        '
        LinkToNameLabel.AutoSize = True
        LinkToNameLabel.Location = New System.Drawing.Point(6, 297)
        LinkToNameLabel.Name = "LinkToNameLabel"
        LinkToNameLabel.Size = New System.Drawing.Size(104, 13)
        LinkToNameLabel.TabIndex = 16
        LinkToNameLabel.Text = "Ссылка на инет 2D"
        '
        'lbGoods
        '
        Me.lbGoods.FormattingEnabled = True
        Me.lbGoods.Location = New System.Drawing.Point(12, 80)
        Me.lbGoods.Name = "lbGoods"
        Me.lbGoods.Size = New System.Drawing.Size(287, 277)
        Me.lbGoods.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(93, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Товарная группа"
        '
        'tbCurrentGood
        '
        Me.tbCurrentGood.Location = New System.Drawing.Point(12, 25)
        Me.tbCurrentGood.Name = "tbCurrentGood"
        Me.tbCurrentGood.Size = New System.Drawing.Size(287, 20)
        Me.tbCurrentGood.TabIndex = 2
        '
        'btAddGoodGroup
        '
        Me.btAddGoodGroup.Location = New System.Drawing.Point(15, 51)
        Me.btAddGoodGroup.Name = "btAddGoodGroup"
        Me.btAddGoodGroup.Size = New System.Drawing.Size(71, 23)
        Me.btAddGoodGroup.TabIndex = 3
        Me.btAddGoodGroup.Text = "Добавить"
        Me.btAddGoodGroup.UseVisualStyleBackColor = True
        '
        'btRemoveGoodGroup
        '
        Me.btRemoveGoodGroup.Location = New System.Drawing.Point(224, 51)
        Me.btRemoveGoodGroup.Name = "btRemoveGoodGroup"
        Me.btRemoveGoodGroup.Size = New System.Drawing.Size(75, 23)
        Me.btRemoveGoodGroup.TabIndex = 4
        Me.btRemoveGoodGroup.Text = "Удалить"
        Me.btRemoveGoodGroup.UseVisualStyleBackColor = True
        '
        'btRemoveSample
        '
        Me.btRemoveSample.Location = New System.Drawing.Point(407, 25)
        Me.btRemoveSample.Name = "btRemoveSample"
        Me.btRemoveSample.Size = New System.Drawing.Size(75, 23)
        Me.btRemoveSample.TabIndex = 9
        Me.btRemoveSample.Text = "Удалить"
        Me.btRemoveSample.UseVisualStyleBackColor = True
        '
        'btAddSample
        '
        Me.btAddSample.Enabled = False
        Me.btAddSample.Location = New System.Drawing.Point(320, 25)
        Me.btAddSample.Name = "btAddSample"
        Me.btAddSample.Size = New System.Drawing.Size(75, 23)
        Me.btAddSample.TabIndex = 8
        Me.btAddSample.Text = "Добавить"
        Me.btAddSample.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(317, -1)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(95, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Список образцов"
        '
        'lbSamples
        '
        Me.lbSamples.DataSource = Me.ClsSampleListBindingSource
        Me.lbSamples.DisplayMember = "SampleNumberEAN13"
        Me.lbSamples.FormattingEnabled = True
        Me.lbSamples.Location = New System.Drawing.Point(320, 54)
        Me.lbSamples.Name = "lbSamples"
        Me.lbSamples.Size = New System.Drawing.Size(185, 329)
        Me.lbSamples.TabIndex = 5
        Me.lbSamples.ValueMember = "SampleNumberEAN13"
        '
        'ClsSampleListBindingSource
        '
        Me.ClsSampleListBindingSource.DataSource = GetType(Service.clsSampleListItem)
        '
        'SampleNumberEAN13TextBox
        '
        Me.SampleNumberEAN13TextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ClsSampleListBindingSource, "SampleNumberEAN13", True))
        Me.SampleNumberEAN13TextBox.Enabled = False
        Me.SampleNumberEAN13TextBox.Location = New System.Drawing.Point(118, 19)
        Me.SampleNumberEAN13TextBox.Name = "SampleNumberEAN13TextBox"
        Me.SampleNumberEAN13TextBox.Size = New System.Drawing.Size(130, 20)
        Me.SampleNumberEAN13TextBox.TabIndex = 11
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cbConvertToCurr)
        Me.GroupBox1.Controls.Add(Me.btConversion)
        Me.GroupBox1.Controls.Add(LinkToNameLabel)
        Me.GroupBox1.Controls.Add(Me.LinkToNameTextBox)
        Me.GroupBox1.Controls.Add(DescriptionTXTLabel)
        Me.GroupBox1.Controls.Add(Me.DescriptionTXTRichTextBox)
        Me.GroupBox1.Controls.Add(CurrencyLabel)
        Me.GroupBox1.Controls.Add(Me.CurrencyTextBox)
        Me.GroupBox1.Controls.Add(PriceLabel)
        Me.GroupBox1.Controls.Add(Me.PriceTextBox)
        Me.GroupBox1.Controls.Add(ShotNameLabel)
        Me.GroupBox1.Controls.Add(Me.ShotNameTextBox)
        Me.GroupBox1.Controls.Add(NameLabel)
        Me.GroupBox1.Controls.Add(Me.NameTextBox)
        Me.GroupBox1.Controls.Add(Me.SampleNumberEAN13TextBox)
        Me.GroupBox1.Controls.Add(SampleNumberEAN13Label)
        Me.GroupBox1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ClsSampleListBindingSource, "ShotNumber", True))
        Me.GroupBox1.Location = New System.Drawing.Point(525, 62)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(447, 324)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "shot"
        '
        'cbConvertToCurr
        '
        Me.cbConvertToCurr.FormattingEnabled = True
        Me.cbConvertToCurr.Items.AddRange(New Object() {"EUR", "USD", "RUR"})
        Me.cbConvertToCurr.Location = New System.Drawing.Point(276, 108)
        Me.cbConvertToCurr.Name = "cbConvertToCurr"
        Me.cbConvertToCurr.Size = New System.Drawing.Size(65, 21)
        Me.cbConvertToCurr.TabIndex = 20
        '
        'btConversion
        '
        Me.btConversion.Location = New System.Drawing.Point(157, 106)
        Me.btConversion.Name = "btConversion"
        Me.btConversion.Size = New System.Drawing.Size(102, 23)
        Me.btConversion.TabIndex = 19
        Me.btConversion.Text = "Пересчитать в.."
        Me.btConversion.UseVisualStyleBackColor = True
        '
        'LinkToNameTextBox
        '
        Me.LinkToNameTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ClsSampleListBindingSource, "LinkToName", True))
        Me.LinkToNameTextBox.Location = New System.Drawing.Point(116, 294)
        Me.LinkToNameTextBox.Name = "LinkToNameTextBox"
        Me.LinkToNameTextBox.Size = New System.Drawing.Size(316, 20)
        Me.LinkToNameTextBox.TabIndex = 17
        '
        'DescriptionTXTRichTextBox
        '
        Me.DescriptionTXTRichTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ClsSampleListBindingSource, "DescriptionTXT", True))
        Me.DescriptionTXTRichTextBox.Location = New System.Drawing.Point(69, 173)
        Me.DescriptionTXTRichTextBox.Name = "DescriptionTXTRichTextBox"
        Me.DescriptionTXTRichTextBox.Size = New System.Drawing.Size(363, 96)
        Me.DescriptionTXTRichTextBox.TabIndex = 16
        Me.DescriptionTXTRichTextBox.Text = ""
        '
        'CurrencyTextBox
        '
        Me.CurrencyTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ClsSampleListBindingSource, "Currency", True))
        Me.CurrencyTextBox.Location = New System.Drawing.Point(69, 130)
        Me.CurrencyTextBox.Name = "CurrencyTextBox"
        Me.CurrencyTextBox.Size = New System.Drawing.Size(61, 20)
        Me.CurrencyTextBox.TabIndex = 15
        '
        'PriceTextBox
        '
        Me.PriceTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ClsSampleListBindingSource, "Price", True))
        Me.PriceTextBox.Location = New System.Drawing.Point(69, 106)
        Me.PriceTextBox.Name = "PriceTextBox"
        Me.PriceTextBox.Size = New System.Drawing.Size(61, 20)
        Me.PriceTextBox.TabIndex = 14
        '
        'ShotNameTextBox
        '
        Me.ShotNameTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ClsSampleListBindingSource, "NickName", True))
        Me.ShotNameTextBox.Location = New System.Drawing.Point(118, 80)
        Me.ShotNameTextBox.Name = "ShotNameTextBox"
        Me.ShotNameTextBox.Size = New System.Drawing.Size(167, 20)
        Me.ShotNameTextBox.TabIndex = 13
        '
        'NameTextBox
        '
        Me.NameTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ClsSampleListBindingSource, "Name", True))
        Me.NameTextBox.Location = New System.Drawing.Point(118, 55)
        Me.NameTextBox.Name = "NameTextBox"
        Me.NameTextBox.Size = New System.Drawing.Size(314, 20)
        Me.NameTextBox.TabIndex = 12
        '
        'btSaveDataSource
        '
        Me.btSaveDataSource.Enabled = False
        Me.btSaveDataSource.Location = New System.Drawing.Point(664, 398)
        Me.btSaveDataSource.Name = "btSaveDataSource"
        Me.btSaveDataSource.Size = New System.Drawing.Size(85, 23)
        Me.btSaveDataSource.TabIndex = 18
        Me.btSaveDataSource.Text = "сохранить.."
        Me.btSaveDataSource.UseVisualStyleBackColor = True
        '
        'btClose
        '
        Me.btClose.Location = New System.Drawing.Point(897, 398)
        Me.btClose.Name = "btClose"
        Me.btClose.Size = New System.Drawing.Size(75, 23)
        Me.btClose.TabIndex = 13
        Me.btClose.Text = "Закрыть"
        Me.btClose.UseVisualStyleBackColor = True
        '
        'btWriteCSV
        '
        Me.btWriteCSV.Location = New System.Drawing.Point(775, 398)
        Me.btWriteCSV.Name = "btWriteCSV"
        Me.btWriteCSV.Size = New System.Drawing.Size(102, 23)
        Me.btWriteCSV.TabIndex = 14
        Me.btWriteCSV.Text = "Записать CSV"
        Me.btWriteCSV.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(490, 395)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(113, 13)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "символ-разделитель"
        '
        'CSVCommaTextBox
        '
        Me.CSVCommaTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.CSVCommaTextBox.Location = New System.Drawing.Point(619, 392)
        Me.CSVCommaTextBox.Name = "CSVCommaTextBox"
        Me.CSVCommaTextBox.Size = New System.Drawing.Size(20, 29)
        Me.CSVCommaTextBox.TabIndex = 16
        Me.CSVCommaTextBox.Text = ";"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 398)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 13)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "Путь к файлу"
        '
        'CSVpathTextBox
        '
        Me.CSVpathTextBox.Location = New System.Drawing.Point(89, 395)
        Me.CSVpathTextBox.Name = "CSVpathTextBox"
        Me.CSVpathTextBox.Size = New System.Drawing.Size(303, 20)
        Me.CSVpathTextBox.TabIndex = 18
        '
        'btCSVpath
        '
        Me.btCSVpath.Location = New System.Drawing.Point(407, 393)
        Me.btCSVpath.Name = "btCSVpath"
        Me.btCSVpath.Size = New System.Drawing.Size(75, 23)
        Me.btCSVpath.TabIndex = 19
        Me.btCSVpath.Text = "Задать.."
        Me.btCSVpath.UseVisualStyleBackColor = True
        '
        'btChangeGood
        '
        Me.btChangeGood.Location = New System.Drawing.Point(117, 51)
        Me.btChangeGood.Name = "btChangeGood"
        Me.btChangeGood.Size = New System.Drawing.Size(71, 23)
        Me.btChangeGood.TabIndex = 20
        Me.btChangeGood.Text = "Изменить"
        Me.btChangeGood.UseVisualStyleBackColor = True
        '
        'BindingNavigator1
        '
        Me.BindingNavigator1.AddNewItem = Me.BindingNavigatorAddNewItem
        Me.BindingNavigator1.BindingSource = Me.ClsSampleListBindingSource
        Me.BindingNavigator1.CountItem = Me.BindingNavigatorCountItem
        Me.BindingNavigator1.DeleteItem = Me.BindingNavigatorDeleteItem
        Me.BindingNavigator1.Dock = System.Windows.Forms.DockStyle.None
        Me.BindingNavigator1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem, Me.СохранитьToolStripButton, Me.toolStripSeparator, Me.toolStripSeparator1})
        Me.BindingNavigator1.Location = New System.Drawing.Point(654, 4)
        Me.BindingNavigator1.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.BindingNavigator1.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.BindingNavigator1.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.BindingNavigator1.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.BindingNavigator1.Name = "BindingNavigator1"
        Me.BindingNavigator1.PositionItem = Me.BindingNavigatorPositionItem
        Me.BindingNavigator1.Size = New System.Drawing.Size(298, 25)
        Me.BindingNavigator1.TabIndex = 21
        Me.BindingNavigator1.Text = "BindingNavigator1"
        '
        'BindingNavigatorAddNewItem
        '
        Me.BindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorAddNewItem.Image = CType(resources.GetObject("BindingNavigatorAddNewItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorAddNewItem.Name = "BindingNavigatorAddNewItem"
        Me.BindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorAddNewItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorAddNewItem.Text = "Добавить"
        '
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(45, 22)
        Me.BindingNavigatorCountItem.Text = "для {0}"
        Me.BindingNavigatorCountItem.ToolTipText = "Общее число элементов"
        '
        'BindingNavigatorDeleteItem
        '
        Me.BindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorDeleteItem.Image = CType(resources.GetObject("BindingNavigatorDeleteItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorDeleteItem.Name = "BindingNavigatorDeleteItem"
        Me.BindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorDeleteItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorDeleteItem.Text = "Удалить"
        '
        'BindingNavigatorMoveFirstItem
        '
        Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
        Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveFirstItem.Text = "Переместить в начало"
        '
        'BindingNavigatorMovePreviousItem
        '
        Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
        Me.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMovePreviousItem.Text = "Переместить назад"
        '
        'BindingNavigatorSeparator
        '
        Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorPositionItem
        '
        Me.BindingNavigatorPositionItem.AccessibleName = "Положение"
        Me.BindingNavigatorPositionItem.AutoSize = False
        Me.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem"
        Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(50, 21)
        Me.BindingNavigatorPositionItem.Text = "0"
        Me.BindingNavigatorPositionItem.ToolTipText = "Текущее положение"
        '
        'BindingNavigatorSeparator1
        '
        Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator1"
        Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorMoveNextItem
        '
        Me.BindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveNextItem.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
        Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveNextItem.Text = "Переместить вперед"
        '
        'BindingNavigatorMoveLastItem
        '
        Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
        Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveLastItem.Text = "Переместить в конец"
        '
        'BindingNavigatorSeparator2
        '
        Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2"
        Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'СохранитьToolStripButton
        '
        Me.СохранитьToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.СохранитьToolStripButton.Image = CType(resources.GetObject("СохранитьToolStripButton.Image"), System.Drawing.Image)
        Me.СохранитьToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.СохранитьToolStripButton.Name = "СохранитьToolStripButton"
        Me.СохранитьToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.СохранитьToolStripButton.Text = "&Сохранить"
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'toolStripSeparator1
        '
        Me.toolStripSeparator1.Name = "toolStripSeparator1"
        Me.toolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(15, 369)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(231, 13)
        Me.Label5.TabIndex = 22
        Me.Label5.Text = "разделитель групп товаров - звездочка (*) !!"
        '
        'btRefresh
        '
        Me.btRefresh.Location = New System.Drawing.Point(511, 4)
        Me.btRefresh.Name = "btRefresh"
        Me.btRefresh.Size = New System.Drawing.Size(101, 23)
        Me.btRefresh.TabIndex = 23
        Me.btRefresh.Text = "обновить.."
        Me.btRefresh.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(511, 33)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(101, 23)
        Me.Button1.TabIndex = 24
        Me.Button1.Text = "обновить все.."
        Me.Button1.UseVisualStyleBackColor = True
        '
        'fmCSVExport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(992, 427)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btRefresh)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.BindingNavigator1)
        Me.Controls.Add(Me.btSaveDataSource)
        Me.Controls.Add(Me.btChangeGood)
        Me.Controls.Add(Me.btCSVpath)
        Me.Controls.Add(Me.CSVpathTextBox)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.CSVCommaTextBox)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btWriteCSV)
        Me.Controls.Add(Me.btClose)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btRemoveSample)
        Me.Controls.Add(Me.btAddSample)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lbSamples)
        Me.Controls.Add(Me.btRemoveGoodGroup)
        Me.Controls.Add(Me.btAddGoodGroup)
        Me.Controls.Add(Me.tbCurrentGood)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lbGoods)
        Me.Name = "fmCSVExport"
        Me.Text = "CSV Export 1.0"
        CType(Me.ClsSampleListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.BindingNavigator1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BindingNavigator1.ResumeLayout(False)
        Me.BindingNavigator1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbGoods As System.Windows.Forms.ListBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tbCurrentGood As System.Windows.Forms.TextBox
    Friend WithEvents btAddGoodGroup As System.Windows.Forms.Button
    Friend WithEvents btRemoveGoodGroup As System.Windows.Forms.Button
    Friend WithEvents btRemoveSample As System.Windows.Forms.Button
    Friend WithEvents btAddSample As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lbSamples As System.Windows.Forms.ListBox
    Friend WithEvents SampleNumberEAN13TextBox As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cbConvertToCurr As System.Windows.Forms.ComboBox
    Friend WithEvents btConversion As System.Windows.Forms.Button
    Friend WithEvents btSaveDataSource As System.Windows.Forms.Button
    Friend WithEvents LinkToNameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents DescriptionTXTRichTextBox As System.Windows.Forms.RichTextBox
    Friend WithEvents CurrencyTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PriceTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ShotNameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents NameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents btClose As System.Windows.Forms.Button
    Friend WithEvents btWriteCSV As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CSVCommaTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CSVpathTextBox As System.Windows.Forms.TextBox
    Friend WithEvents btCSVpath As System.Windows.Forms.Button
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents btChangeGood As System.Windows.Forms.Button
    Friend WithEvents BindingNavigator1 As System.Windows.Forms.BindingNavigator
    Friend WithEvents BindingNavigatorAddNewItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorCountItem As System.Windows.Forms.ToolStripLabel
    Friend WithEvents BindingNavigatorDeleteItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveFirstItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents СохранитьToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ClsSampleListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents btRefresh As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
