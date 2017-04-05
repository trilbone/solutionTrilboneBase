<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserControlMC
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
        Dim UomNameLabel As System.Windows.Forms.Label
        Dim ActualNumberLabel As System.Windows.Forms.Label
        Dim Label1 As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UserControlMC))
        Me.tbctlMain = New System.Windows.Forms.TabControl()
        Me.tpGood = New System.Windows.Forms.TabPage()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.ClsApplicationTypes_clsSampleNumber_strGoodInfoBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.tbWeight = New System.Windows.Forms.TextBox()
        Me.rbeBay = New System.Windows.Forms.RadioButton()
        Me.rbRetail = New System.Windows.Forms.RadioButton()
        Me.btSetPrice = New System.Windows.Forms.Button()
        Me.UomNameTextBox = New System.Windows.Forms.TextBox()
        Me.ActualNumberTextBox = New System.Windows.Forms.TextBox()
        Me.BindingNavigator1 = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel()
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox()
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btSaveInMoySklad = New System.Windows.Forms.Button()
        Me.tbNameFromMoySklad = New System.Windows.Forms.TextBox()
        Me.btOpenMoySklad = New System.Windows.Forms.Button()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.tbWholesaleCalc = New System.Windows.Forms.TextBox()
        Me.tbRetailCalc = New System.Windows.Forms.TextBox()
        Me.btMoySkladAsk = New System.Windows.Forms.Button()
        Me.tbRateEUR = New System.Windows.Forms.TextBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.tbRateUSD = New System.Windows.Forms.TextBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.cbCurrencyIncoming = New System.Windows.Forms.ComboBox()
        Me.tbIncomingPrice = New System.Windows.Forms.TextBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.cbCurrency = New System.Windows.Forms.ComboBox()
        Me.tbeBay = New System.Windows.Forms.TextBox()
        Me.tbRetail = New System.Windows.Forms.TextBox()
        Me.tbSklad = New System.Windows.Forms.TabPage()
        Me.btPlaceToWare = New System.Windows.Forms.Button()
        Me.lbActiveSlot = New System.Windows.Forms.Label()
        Me.btPlaceToSlot = New System.Windows.Forms.Button()
        Me.lbxSlotCollection = New System.Windows.Forms.ListBox()
        Me.btSetWare = New System.Windows.Forms.Button()
        Me.btSearchSklad = New System.Windows.Forms.Button()
        Me.lbPlaceGood = New System.Windows.Forms.ListBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        UomNameLabel = New System.Windows.Forms.Label()
        ActualNumberLabel = New System.Windows.Forms.Label()
        Label1 = New System.Windows.Forms.Label()
        Me.tbctlMain.SuspendLayout()
        Me.tpGood.SuspendLayout()
        CType(Me.ClsApplicationTypes_clsSampleNumber_strGoodInfoBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingNavigator1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BindingNavigator1.SuspendLayout()
        Me.tbSklad.SuspendLayout()
        Me.SuspendLayout()
        '
        'UomNameLabel
        '
        UomNameLabel.AutoSize = True
        UomNameLabel.Location = New System.Drawing.Point(125, 34)
        UomNameLabel.Name = "UomNameLabel"
        UomNameLabel.Size = New System.Drawing.Size(51, 13)
        UomNameLabel.TabIndex = 55
        UomNameLabel.Text = "ед. изм.:"
        '
        'ActualNumberLabel
        '
        ActualNumberLabel.AutoSize = True
        ActualNumberLabel.Location = New System.Drawing.Point(39, 8)
        ActualNumberLabel.Name = "ActualNumberLabel"
        ActualNumberLabel.Size = New System.Drawing.Size(94, 13)
        ActualNumberLabel.TabIndex = 53
        ActualNumberLabel.Text = "Номер (Артикул):"
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.Location = New System.Drawing.Point(17, 34)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(45, 13)
        Label1.TabIndex = 60
        Label1.Text = "вес, кг:"
        '
        'tbctlMain
        '
        Me.tbctlMain.Controls.Add(Me.tpGood)
        Me.tbctlMain.Controls.Add(Me.tbSklad)
        Me.tbctlMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbctlMain.Location = New System.Drawing.Point(0, 0)
        Me.tbctlMain.Name = "tbctlMain"
        Me.tbctlMain.SelectedIndex = 0
        Me.tbctlMain.Size = New System.Drawing.Size(450, 260)
        Me.tbctlMain.TabIndex = 0
        '
        'tpGood
        '
        Me.tpGood.Controls.Add(Me.Label2)
        Me.tpGood.Controls.Add(Me.ComboBox1)
        Me.tpGood.Controls.Add(Label1)
        Me.tpGood.Controls.Add(Me.tbWeight)
        Me.tpGood.Controls.Add(Me.rbeBay)
        Me.tpGood.Controls.Add(Me.rbRetail)
        Me.tpGood.Controls.Add(Me.btSetPrice)
        Me.tpGood.Controls.Add(UomNameLabel)
        Me.tpGood.Controls.Add(Me.UomNameTextBox)
        Me.tpGood.Controls.Add(ActualNumberLabel)
        Me.tpGood.Controls.Add(Me.ActualNumberTextBox)
        Me.tpGood.Controls.Add(Me.BindingNavigator1)
        Me.tpGood.Controls.Add(Me.btSaveInMoySklad)
        Me.tpGood.Controls.Add(Me.tbNameFromMoySklad)
        Me.tpGood.Controls.Add(Me.btOpenMoySklad)
        Me.tpGood.Controls.Add(Me.Label27)
        Me.tpGood.Controls.Add(Me.Label36)
        Me.tpGood.Controls.Add(Me.tbWholesaleCalc)
        Me.tpGood.Controls.Add(Me.tbRetailCalc)
        Me.tpGood.Controls.Add(Me.btMoySkladAsk)
        Me.tpGood.Controls.Add(Me.tbRateEUR)
        Me.tpGood.Controls.Add(Me.Label35)
        Me.tpGood.Controls.Add(Me.tbRateUSD)
        Me.tpGood.Controls.Add(Me.Label34)
        Me.tpGood.Controls.Add(Me.cbCurrencyIncoming)
        Me.tpGood.Controls.Add(Me.tbIncomingPrice)
        Me.tpGood.Controls.Add(Me.Label32)
        Me.tpGood.Controls.Add(Me.cbCurrency)
        Me.tpGood.Controls.Add(Me.tbeBay)
        Me.tpGood.Controls.Add(Me.tbRetail)
        Me.tpGood.Location = New System.Drawing.Point(4, 22)
        Me.tpGood.Name = "tpGood"
        Me.tpGood.Padding = New System.Windows.Forms.Padding(3)
        Me.tpGood.Size = New System.Drawing.Size(442, 234)
        Me.tpGood.TabIndex = 0
        Me.tpGood.Text = "Товар"
        Me.tpGood.UseVisualStyleBackColor = True
        '
        'ComboBox1
        '
        Me.ComboBox1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ClsApplicationTypes_clsSampleNumber_strGoodInfoBindingSource, "eBayCurrecy", True))
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"USD", "EUR", "RUR"})
        Me.ComboBox1.Location = New System.Drawing.Point(134, 121)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(48, 21)
        Me.ComboBox1.TabIndex = 62
        '
        'ClsApplicationTypes_clsSampleNumber_strGoodInfoBindingSource
        '
        Me.ClsApplicationTypes_clsSampleNumber_strGoodInfoBindingSource.DataSource = GetType(System.Collections.Generic.List(Of Service.clsApplicationTypes.clsSampleNumber.strGoodInfo))
        '
        'tbWeight
        '
        Me.tbWeight.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ClsApplicationTypes_clsSampleNumber_strGoodInfoBindingSource, "Weight", True))
        Me.tbWeight.Location = New System.Drawing.Point(68, 31)
        Me.tbWeight.Name = "tbWeight"
        Me.tbWeight.Size = New System.Drawing.Size(51, 20)
        Me.tbWeight.TabIndex = 61
        Me.tbWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'rbeBay
        '
        Me.rbeBay.AutoSize = True
        Me.rbeBay.Location = New System.Drawing.Point(3, 124)
        Me.rbeBay.Name = "rbeBay"
        Me.rbeBay.Size = New System.Drawing.Size(49, 17)
        Me.rbeBay.TabIndex = 59
        Me.rbeBay.Text = "eBay"
        Me.rbeBay.UseVisualStyleBackColor = True
        '
        'rbRetail
        '
        Me.rbRetail.AutoSize = True
        Me.rbRetail.Checked = True
        Me.rbRetail.Location = New System.Drawing.Point(3, 94)
        Me.rbRetail.Name = "rbRetail"
        Me.rbRetail.Size = New System.Drawing.Size(68, 17)
        Me.rbRetail.TabIndex = 58
        Me.rbRetail.TabStop = True
        Me.rbRetail.Text = "Розница"
        Me.rbRetail.UseVisualStyleBackColor = True
        '
        'btSetPrice
        '
        Me.btSetPrice.Location = New System.Drawing.Point(7, 178)
        Me.btSetPrice.Name = "btSetPrice"
        Me.btSetPrice.Size = New System.Drawing.Size(175, 25)
        Me.btSetPrice.TabIndex = 57
        Me.btSetPrice.Text = "Запомнить цену"
        Me.btSetPrice.UseVisualStyleBackColor = True
        '
        'UomNameTextBox
        '
        Me.UomNameTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ClsApplicationTypes_clsSampleNumber_strGoodInfoBindingSource, "UomName", True))
        Me.UomNameTextBox.Location = New System.Drawing.Point(182, 31)
        Me.UomNameTextBox.Name = "UomNameTextBox"
        Me.UomNameTextBox.Size = New System.Drawing.Size(30, 20)
        Me.UomNameTextBox.TabIndex = 56
        Me.UomNameTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ActualNumberTextBox
        '
        Me.ActualNumberTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ClsApplicationTypes_clsSampleNumber_strGoodInfoBindingSource, "ActualNumber", True))
        Me.ActualNumberTextBox.Enabled = False
        Me.ActualNumberTextBox.Location = New System.Drawing.Point(139, 5)
        Me.ActualNumberTextBox.Name = "ActualNumberTextBox"
        Me.ActualNumberTextBox.Size = New System.Drawing.Size(83, 20)
        Me.ActualNumberTextBox.TabIndex = 54
        Me.ActualNumberTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'BindingNavigator1
        '
        Me.BindingNavigator1.AddNewItem = Nothing
        Me.BindingNavigator1.BindingSource = Me.ClsApplicationTypes_clsSampleNumber_strGoodInfoBindingSource
        Me.BindingNavigator1.CountItem = Me.BindingNavigatorCountItem
        Me.BindingNavigator1.DeleteItem = Nothing
        Me.BindingNavigator1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BindingNavigator1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.BindingNavigator1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2})
        Me.BindingNavigator1.Location = New System.Drawing.Point(3, 204)
        Me.BindingNavigator1.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.BindingNavigator1.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.BindingNavigator1.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.BindingNavigator1.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.BindingNavigator1.Name = "BindingNavigator1"
        Me.BindingNavigator1.PositionItem = Me.BindingNavigatorPositionItem
        Me.BindingNavigator1.Size = New System.Drawing.Size(436, 27)
        Me.BindingNavigator1.TabIndex = 52
        Me.BindingNavigator1.Text = "BindingNavigator1"
        '
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(43, 24)
        Me.BindingNavigatorCountItem.Text = "для {0}"
        Me.BindingNavigatorCountItem.ToolTipText = "Общее число элементов"
        '
        'BindingNavigatorMoveFirstItem
        '
        Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
        Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(24, 24)
        Me.BindingNavigatorMoveFirstItem.Text = "Переместить в начало"
        '
        'BindingNavigatorMovePreviousItem
        '
        Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
        Me.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(24, 24)
        Me.BindingNavigatorMovePreviousItem.Text = "Переместить назад"
        '
        'BindingNavigatorSeparator
        '
        Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 27)
        '
        'BindingNavigatorPositionItem
        '
        Me.BindingNavigatorPositionItem.AccessibleName = "Положение"
        Me.BindingNavigatorPositionItem.AutoSize = False
        Me.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem"
        Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(50, 23)
        Me.BindingNavigatorPositionItem.Text = "0"
        Me.BindingNavigatorPositionItem.ToolTipText = "Текущее положение"
        '
        'BindingNavigatorSeparator1
        '
        Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator1"
        Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 27)
        '
        'BindingNavigatorMoveNextItem
        '
        Me.BindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveNextItem.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
        Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(24, 24)
        Me.BindingNavigatorMoveNextItem.Text = "Переместить вперед"
        '
        'BindingNavigatorMoveLastItem
        '
        Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
        Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(24, 24)
        Me.BindingNavigatorMoveLastItem.Text = "Переместить в конец"
        '
        'BindingNavigatorSeparator2
        '
        Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2"
        Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 27)
        '
        'btSaveInMoySklad
        '
        Me.btSaveInMoySklad.Location = New System.Drawing.Point(330, 156)
        Me.btSaveInMoySklad.Name = "btSaveInMoySklad"
        Me.btSaveInMoySklad.Size = New System.Drawing.Size(111, 47)
        Me.btSaveInMoySklad.TabIndex = 50
        Me.btSaveInMoySklad.Text = "Сохранить"
        Me.btSaveInMoySklad.UseVisualStyleBackColor = True
        '
        'tbNameFromMoySklad
        '
        Me.tbNameFromMoySklad.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ClsApplicationTypes_clsSampleNumber_strGoodInfoBindingSource, "Name", True))
        Me.tbNameFromMoySklad.Location = New System.Drawing.Point(67, 53)
        Me.tbNameFromMoySklad.Name = "tbNameFromMoySklad"
        Me.tbNameFromMoySklad.Size = New System.Drawing.Size(374, 20)
        Me.tbNameFromMoySklad.TabIndex = 32
        '
        'btOpenMoySklad
        '
        Me.btOpenMoySklad.Location = New System.Drawing.Point(3, 3)
        Me.btOpenMoySklad.Name = "btOpenMoySklad"
        Me.btOpenMoySklad.Size = New System.Drawing.Size(30, 23)
        Me.btOpenMoySklad.TabIndex = 47
        Me.btOpenMoySklad.Text = ">>"
        Me.btOpenMoySklad.UseVisualStyleBackColor = True
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(4, 55)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(57, 13)
        Me.Label27.TabIndex = 31
        Me.Label27.Text = "Название"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(160, 75)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(112, 13)
        Me.Label36.TabIndex = 46
        Me.Label36.Text = "Разница с входящей"
        '
        'tbWholesaleCalc
        '
        Me.tbWholesaleCalc.Location = New System.Drawing.Point(188, 121)
        Me.tbWholesaleCalc.Name = "tbWholesaleCalc"
        Me.tbWholesaleCalc.Size = New System.Drawing.Size(51, 20)
        Me.tbWholesaleCalc.TabIndex = 45
        Me.tbWholesaleCalc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbRetailCalc
        '
        Me.tbRetailCalc.Location = New System.Drawing.Point(188, 92)
        Me.tbRetailCalc.Name = "tbRetailCalc"
        Me.tbRetailCalc.Size = New System.Drawing.Size(51, 20)
        Me.tbRetailCalc.TabIndex = 44
        Me.tbRetailCalc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btMoySkladAsk
        '
        Me.btMoySkladAsk.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btMoySkladAsk.Location = New System.Drawing.Point(331, 0)
        Me.btMoySkladAsk.Name = "btMoySkladAsk"
        Me.btMoySkladAsk.Size = New System.Drawing.Size(111, 43)
        Me.btMoySkladAsk.TabIndex = 43
        Me.btMoySkladAsk.Text = "Запрос"
        Me.btMoySkladAsk.UseVisualStyleBackColor = True
        '
        'tbRateEUR
        '
        Me.tbRateEUR.Enabled = False
        Me.tbRateEUR.Location = New System.Drawing.Point(348, 92)
        Me.tbRateEUR.Name = "tbRateEUR"
        Me.tbRateEUR.Size = New System.Drawing.Size(51, 20)
        Me.tbRateEUR.TabIndex = 42
        Me.tbRateEUR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(244, 95)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(97, 13)
        Me.Label35.TabIndex = 41
        Me.Label35.Text = "ЦБ курс EUR +3%"
        '
        'tbRateUSD
        '
        Me.tbRateUSD.Enabled = False
        Me.tbRateUSD.Location = New System.Drawing.Point(348, 118)
        Me.tbRateUSD.Name = "tbRateUSD"
        Me.tbRateUSD.Size = New System.Drawing.Size(51, 20)
        Me.tbRateUSD.TabIndex = 40
        Me.tbRateUSD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(244, 121)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(97, 13)
        Me.Label34.TabIndex = 39
        Me.Label34.Text = "ЦБ курс USD +3%"
        '
        'cbCurrencyIncoming
        '
        Me.cbCurrencyIncoming.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ClsApplicationTypes_clsSampleNumber_strGoodInfoBindingSource, "BuyCurrency", True))
        Me.cbCurrencyIncoming.FormattingEnabled = True
        Me.cbCurrencyIncoming.Items.AddRange(New Object() {"USD", "EUR", "RUR"})
        Me.cbCurrencyIncoming.Location = New System.Drawing.Point(134, 151)
        Me.cbCurrencyIncoming.Name = "cbCurrencyIncoming"
        Me.cbCurrencyIncoming.Size = New System.Drawing.Size(48, 21)
        Me.cbCurrencyIncoming.TabIndex = 38
        '
        'tbIncomingPrice
        '
        Me.tbIncomingPrice.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ClsApplicationTypes_clsSampleNumber_strGoodInfoBindingSource, "BuyPrice", True))
        Me.tbIncomingPrice.Location = New System.Drawing.Point(77, 152)
        Me.tbIncomingPrice.Name = "tbIncomingPrice"
        Me.tbIncomingPrice.Size = New System.Drawing.Size(51, 20)
        Me.tbIncomingPrice.TabIndex = 37
        Me.tbIncomingPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(4, 156)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(58, 13)
        Me.Label32.TabIndex = 36
        Me.Label32.Text = "Входящая"
        '
        'cbCurrency
        '
        Me.cbCurrency.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ClsApplicationTypes_clsSampleNumber_strGoodInfoBindingSource, "RetailCurrency", True))
        Me.cbCurrency.FormattingEnabled = True
        Me.cbCurrency.Items.AddRange(New Object() {"USD", "EUR", "RUR"})
        Me.cbCurrency.Location = New System.Drawing.Point(134, 91)
        Me.cbCurrency.Name = "cbCurrency"
        Me.cbCurrency.Size = New System.Drawing.Size(48, 21)
        Me.cbCurrency.TabIndex = 35
        '
        'tbeBay
        '
        Me.tbeBay.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ClsApplicationTypes_clsSampleNumber_strGoodInfoBindingSource, "eBayPrice", True))
        Me.tbeBay.Enabled = False
        Me.tbeBay.Location = New System.Drawing.Point(77, 121)
        Me.tbeBay.Name = "tbeBay"
        Me.tbeBay.Size = New System.Drawing.Size(51, 20)
        Me.tbeBay.TabIndex = 34
        Me.tbeBay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbRetail
        '
        Me.tbRetail.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ClsApplicationTypes_clsSampleNumber_strGoodInfoBindingSource, "RetailPrice", True))
        Me.tbRetail.Location = New System.Drawing.Point(77, 92)
        Me.tbRetail.Name = "tbRetail"
        Me.tbRetail.Size = New System.Drawing.Size(51, 20)
        Me.tbRetail.TabIndex = 33
        Me.tbRetail.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbSklad
        '
        Me.tbSklad.Controls.Add(Me.btPlaceToWare)
        Me.tbSklad.Controls.Add(Me.lbActiveSlot)
        Me.tbSklad.Controls.Add(Me.btPlaceToSlot)
        Me.tbSklad.Controls.Add(Me.lbxSlotCollection)
        Me.tbSklad.Controls.Add(Me.btSetWare)
        Me.tbSklad.Controls.Add(Me.btSearchSklad)
        Me.tbSklad.Controls.Add(Me.lbPlaceGood)
        Me.tbSklad.Location = New System.Drawing.Point(4, 22)
        Me.tbSklad.Name = "tbSklad"
        Me.tbSklad.Padding = New System.Windows.Forms.Padding(3)
        Me.tbSklad.Size = New System.Drawing.Size(442, 234)
        Me.tbSklad.TabIndex = 1
        Me.tbSklad.Text = "Склад"
        Me.tbSklad.UseVisualStyleBackColor = True
        '
        'btPlaceToWare
        '
        Me.btPlaceToWare.Location = New System.Drawing.Point(157, 188)
        Me.btPlaceToWare.Name = "btPlaceToWare"
        Me.btPlaceToWare.Size = New System.Drawing.Size(126, 35)
        Me.btPlaceToWare.TabIndex = 6
        Me.btPlaceToWare.Text = "Убрать из ячеек"
        Me.btPlaceToWare.UseVisualStyleBackColor = True
        '
        'lbActiveSlot
        '
        Me.lbActiveSlot.AutoSize = True
        Me.lbActiveSlot.Location = New System.Drawing.Point(154, 102)
        Me.lbActiveSlot.Name = "lbActiveSlot"
        Me.lbActiveSlot.Size = New System.Drawing.Size(50, 13)
        Me.lbActiveSlot.TabIndex = 5
        Me.lbActiveSlot.Text = "в ячейку"
        '
        'btPlaceToSlot
        '
        Me.btPlaceToSlot.Location = New System.Drawing.Point(157, 127)
        Me.btPlaceToSlot.Name = "btPlaceToSlot"
        Me.btPlaceToSlot.Size = New System.Drawing.Size(126, 44)
        Me.btPlaceToSlot.TabIndex = 4
        Me.btPlaceToSlot.Text = "Положить в ячейку"
        Me.btPlaceToSlot.UseVisualStyleBackColor = True
        '
        'lbxSlotCollection
        '
        Me.lbxSlotCollection.FormattingEnabled = True
        Me.lbxSlotCollection.Location = New System.Drawing.Point(7, 102)
        Me.lbxSlotCollection.Name = "lbxSlotCollection"
        Me.lbxSlotCollection.Size = New System.Drawing.Size(123, 121)
        Me.lbxSlotCollection.TabIndex = 3
        '
        'btSetWare
        '
        Me.btSetWare.Location = New System.Drawing.Point(333, 184)
        Me.btSetWare.Name = "btSetWare"
        Me.btSetWare.Size = New System.Drawing.Size(103, 44)
        Me.btSetWare.TabIndex = 2
        Me.btSetWare.Text = "Запомнить склад"
        Me.btSetWare.UseVisualStyleBackColor = True
        '
        'btSearchSklad
        '
        Me.btSearchSklad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btSearchSklad.Location = New System.Drawing.Point(302, 4)
        Me.btSearchSklad.Name = "btSearchSklad"
        Me.btSearchSklad.Size = New System.Drawing.Size(136, 99)
        Me.btSearchSklad.TabIndex = 1
        Me.btSearchSklad.Text = "Найти на складах"
        Me.btSearchSklad.UseVisualStyleBackColor = True
        '
        'lbPlaceGood
        '
        Me.lbPlaceGood.FormattingEnabled = True
        Me.lbPlaceGood.Location = New System.Drawing.Point(6, 6)
        Me.lbPlaceGood.Name = "lbPlaceGood"
        Me.lbPlaceGood.Size = New System.Drawing.Size(277, 56)
        Me.lbPlaceGood.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(233, 3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(92, 45)
        Me.Label2.TabIndex = 63
        Me.Label2.Text = "right click" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "выделенного" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "для статист."
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(61, 4)
        '
        'UserControlMC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.tbctlMain)
        Me.Name = "UserControlMC"
        Me.Size = New System.Drawing.Size(450, 260)
        Me.tbctlMain.ResumeLayout(False)
        Me.tpGood.ResumeLayout(False)
        Me.tpGood.PerformLayout()
        CType(Me.ClsApplicationTypes_clsSampleNumber_strGoodInfoBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingNavigator1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BindingNavigator1.ResumeLayout(False)
        Me.BindingNavigator1.PerformLayout()
        Me.tbSklad.ResumeLayout(False)
        Me.tbSklad.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tbctlMain As System.Windows.Forms.TabControl
    Friend WithEvents tpGood As System.Windows.Forms.TabPage
    Friend WithEvents tbSklad As System.Windows.Forms.TabPage
    Friend WithEvents ClsApplicationTypes_clsSampleNumber_strGoodInfoBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents UomNameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ActualNumberTextBox As System.Windows.Forms.TextBox
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
    Friend WithEvents btSaveInMoySklad As System.Windows.Forms.Button
    Friend WithEvents tbNameFromMoySklad As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents tbWholesaleCalc As System.Windows.Forms.TextBox
    Friend WithEvents tbRetailCalc As System.Windows.Forms.TextBox
    Friend WithEvents btMoySkladAsk As System.Windows.Forms.Button
    Friend WithEvents tbRateEUR As System.Windows.Forms.TextBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents tbRateUSD As System.Windows.Forms.TextBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents cbCurrencyIncoming As System.Windows.Forms.ComboBox
    Friend WithEvents tbIncomingPrice As System.Windows.Forms.TextBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents cbCurrency As System.Windows.Forms.ComboBox
    Friend WithEvents tbeBay As System.Windows.Forms.TextBox
    Friend WithEvents tbRetail As System.Windows.Forms.TextBox
    Friend WithEvents lbPlaceGood As System.Windows.Forms.ListBox
    Friend WithEvents btSetPrice As System.Windows.Forms.Button
    Friend WithEvents rbeBay As System.Windows.Forms.RadioButton
    Friend WithEvents rbRetail As System.Windows.Forms.RadioButton
    Friend WithEvents btSearchSklad As System.Windows.Forms.Button
    Friend WithEvents tbWeight As System.Windows.Forms.TextBox
    Friend WithEvents btSetWare As System.Windows.Forms.Button
    Friend WithEvents btPlaceToSlot As System.Windows.Forms.Button
    Friend WithEvents lbxSlotCollection As System.Windows.Forms.ListBox
    Friend WithEvents lbActiveSlot As System.Windows.Forms.Label
    Friend WithEvents btPlaceToWare As System.Windows.Forms.Button
    Friend WithEvents btOpenMoySklad As System.Windows.Forms.Button
    Friend WithEvents ComboBox1 As Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
End Class
