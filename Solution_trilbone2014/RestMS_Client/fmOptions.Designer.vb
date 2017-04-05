<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fmOptions
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
        Dim NakladnyeLabel As System.Windows.Forms.Label
        Dim ShippingTariffPerKGLabel As System.Windows.Forms.Label
        Dim ShippingTariffPerPCSLabel As System.Windows.Forms.Label
        Dim ShippingTariffPerELabel As System.Windows.Forms.Label
        Dim EUOMUUIDLabel As System.Windows.Forms.Label
        Dim GUomUUIDLabel As System.Windows.Forms.Label
        Dim KgUOMUUIDLabel As System.Windows.Forms.Label
        Dim PcsUOMUUIDLabel As System.Windows.Forms.Label
        Dim RetailPriceTypeUuidLabel As System.Windows.Forms.Label
        Dim WhosalePriceTypeUUIDLabel As System.Windows.Forms.Label
        Dim Label12 As System.Windows.Forms.Label
        Dim Label13 As System.Windows.Forms.Label
        Dim Label17 As System.Windows.Forms.Label
        Dim Label19 As System.Windows.Forms.Label
        Dim Label21 As System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lbWareList = New System.Windows.Forms.ListBox()
        Me.tbNewWare = New System.Windows.Forms.TextBox()
        Me.tbNewEnter = New System.Windows.Forms.TextBox()
        Me.lbEnters = New System.Windows.Forms.ListBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbNewLoss = New System.Windows.Forms.TextBox()
        Me.lbLoss = New System.Windows.Forms.ListBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btSave = New System.Windows.Forms.Button()
        Me.btClose = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.NakladnyeTextBox = New System.Windows.Forms.TextBox()
        Me.ShippingTariffPerKGTextBox = New System.Windows.Forms.TextBox()
        Me.ShippingTariffPerPCSTextBox = New System.Windows.Forms.TextBox()
        Me.ShippingTariffPerETextBox = New System.Windows.Forms.TextBox()
        Me.EUOMUUIDTextBox = New System.Windows.Forms.TextBox()
        Me.GUomUUIDTextBox = New System.Windows.Forms.TextBox()
        Me.KgUOMUUIDTextBox = New System.Windows.Forms.TextBox()
        Me.PcsUOMUUIDTextBox = New System.Windows.Forms.TextBox()
        Me.RetailPriceTypeUuidTextBox = New System.Windows.Forms.TextBox()
        Me.WhosalePriceTypeUUIDTextBox = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.tbWhourCost = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.btAddWarehouse = New System.Windows.Forms.Button()
        Me.btAddEnter = New System.Windows.Forms.Button()
        Me.btAddLoss = New System.Windows.Forms.Button()
        Me.btAcceptNewWare = New System.Windows.Forms.Button()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.btDelWare = New System.Windows.Forms.Button()
        Me.btDelEnter = New System.Windows.Forms.Button()
        Me.btDelLoss = New System.Windows.Forms.Button()
        Me.btSaveWare = New System.Windows.Forms.Button()
        Me.btReadWare = New System.Windows.Forms.Button()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.MySettingsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        NakladnyeLabel = New System.Windows.Forms.Label()
        ShippingTariffPerKGLabel = New System.Windows.Forms.Label()
        ShippingTariffPerPCSLabel = New System.Windows.Forms.Label()
        ShippingTariffPerELabel = New System.Windows.Forms.Label()
        EUOMUUIDLabel = New System.Windows.Forms.Label()
        GUomUUIDLabel = New System.Windows.Forms.Label()
        KgUOMUUIDLabel = New System.Windows.Forms.Label()
        PcsUOMUUIDLabel = New System.Windows.Forms.Label()
        RetailPriceTypeUuidLabel = New System.Windows.Forms.Label()
        WhosalePriceTypeUUIDLabel = New System.Windows.Forms.Label()
        Label12 = New System.Windows.Forms.Label()
        Label13 = New System.Windows.Forms.Label()
        Label17 = New System.Windows.Forms.Label()
        Label19 = New System.Windows.Forms.Label()
        Label21 = New System.Windows.Forms.Label()
        CType(Me.MySettingsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'NakladnyeLabel
        '
        NakladnyeLabel.AutoSize = True
        NakladnyeLabel.Location = New System.Drawing.Point(11, 360)
        NakladnyeLabel.Name = "NakladnyeLabel"
        NakladnyeLabel.Size = New System.Drawing.Size(180, 13)
        NakladnyeLabel.TabIndex = 18
        NakladnyeLabel.Text = "Коэфициент накладных расходов:"
        '
        'ShippingTariffPerKGLabel
        '
        ShippingTariffPerKGLabel.AutoSize = True
        ShippingTariffPerKGLabel.Location = New System.Drawing.Point(72, 384)
        ShippingTariffPerKGLabel.Name = "ShippingTariffPerKGLabel"
        ShippingTariffPerKGLabel.Size = New System.Drawing.Size(117, 13)
        ShippingTariffPerKGLabel.TabIndex = 19
        ShippingTariffPerKGLabel.Text = "Шиппинг тариф за кг:"
        '
        'ShippingTariffPerPCSLabel
        '
        ShippingTariffPerPCSLabel.AutoSize = True
        ShippingTariffPerPCSLabel.Location = New System.Drawing.Point(70, 409)
        ShippingTariffPerPCSLabel.Name = "ShippingTariffPerPCSLabel"
        ShippingTariffPerPCSLabel.Size = New System.Drawing.Size(119, 13)
        ShippingTariffPerPCSLabel.TabIndex = 20
        ShippingTariffPerPCSLabel.Text = "Шиппинг тариф за шт:"
        '
        'ShippingTariffPerELabel
        '
        ShippingTariffPerELabel.AutoSize = True
        ShippingTariffPerELabel.Location = New System.Drawing.Point(76, 435)
        ShippingTariffPerELabel.Name = "ShippingTariffPerELabel"
        ShippingTariffPerELabel.Size = New System.Drawing.Size(113, 13)
        ShippingTariffPerELabel.TabIndex = 22
        ShippingTariffPerELabel.Text = "Шиппинг тариф за E:"
        '
        'EUOMUUIDLabel
        '
        EUOMUUIDLabel.AutoSize = True
        EUOMUUIDLabel.Location = New System.Drawing.Point(441, 350)
        EUOMUUIDLabel.Name = "EUOMUUIDLabel"
        EUOMUUIDLabel.Size = New System.Drawing.Size(75, 13)
        EUOMUUIDLabel.TabIndex = 24
        EUOMUUIDLabel.Text = "E UOM UUID:"
        '
        'GUomUUIDLabel
        '
        GUomUUIDLabel.AutoSize = True
        GUomUUIDLabel.Location = New System.Drawing.Point(442, 386)
        GUomUUIDLabel.Name = "GUomUUIDLabel"
        GUomUUIDLabel.Size = New System.Drawing.Size(74, 13)
        GUomUUIDLabel.TabIndex = 26
        GUomUUIDLabel.Text = "g UOM UUID:"
        '
        'KgUOMUUIDLabel
        '
        KgUOMUUIDLabel.AutoSize = True
        KgUOMUUIDLabel.Location = New System.Drawing.Point(435, 422)
        KgUOMUUIDLabel.Name = "KgUOMUUIDLabel"
        KgUOMUUIDLabel.Size = New System.Drawing.Size(81, 13)
        KgUOMUUIDLabel.TabIndex = 28
        KgUOMUUIDLabel.Text = "Kg UOM UUID:"
        '
        'PcsUOMUUIDLabel
        '
        PcsUOMUUIDLabel.AutoSize = True
        PcsUOMUUIDLabel.Location = New System.Drawing.Point(430, 458)
        PcsUOMUUIDLabel.Name = "PcsUOMUUIDLabel"
        PcsUOMUUIDLabel.Size = New System.Drawing.Size(86, 13)
        PcsUOMUUIDLabel.TabIndex = 30
        PcsUOMUUIDLabel.Text = "Pcs UOM UUID:"
        '
        'RetailPriceTypeUuidLabel
        '
        RetailPriceTypeUuidLabel.AutoSize = True
        RetailPriceTypeUuidLabel.Location = New System.Drawing.Point(400, 490)
        RetailPriceTypeUuidLabel.Name = "RetailPriceTypeUuidLabel"
        RetailPriceTypeUuidLabel.Size = New System.Drawing.Size(116, 13)
        RetailPriceTypeUuidLabel.TabIndex = 32
        RetailPriceTypeUuidLabel.Text = "Retail Price Type Uuid:"
        '
        'WhosalePriceTypeUUIDLabel
        '
        WhosalePriceTypeUUIDLabel.AutoSize = True
        WhosalePriceTypeUUIDLabel.Location = New System.Drawing.Point(380, 529)
        WhosalePriceTypeUUIDLabel.Name = "WhosalePriceTypeUUIDLabel"
        WhosalePriceTypeUUIDLabel.Size = New System.Drawing.Size(136, 13)
        WhosalePriceTypeUUIDLabel.TabIndex = 34
        WhosalePriceTypeUUIDLabel.Text = "Whosale Price Type UUID:"
        '
        'Label12
        '
        Label12.AutoSize = True
        Label12.Location = New System.Drawing.Point(177, 544)
        Label12.Name = "Label12"
        Label12.Size = New System.Drawing.Size(90, 13)
        Label12.TabIndex = 39
        Label12.Text = "Конторский час:"
        '
        'Label13
        '
        Label13.AutoSize = True
        Label13.Location = New System.Drawing.Point(70, 337)
        Label13.Name = "Label13"
        Label13.Size = New System.Drawing.Size(116, 13)
        Label13.TabIndex = 42
        Label13.Text = "Рассчетные ""концы"":"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(25, 59)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(145, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Список доступных складов"
        '
        'lbWareList
        '
        Me.lbWareList.FormattingEnabled = True
        Me.lbWareList.Location = New System.Drawing.Point(28, 84)
        Me.lbWareList.Name = "lbWareList"
        Me.lbWareList.Size = New System.Drawing.Size(161, 95)
        Me.lbWareList.TabIndex = 1
        '
        'tbNewWare
        '
        Me.tbNewWare.Location = New System.Drawing.Point(31, 233)
        Me.tbNewWare.Name = "tbNewWare"
        Me.tbNewWare.Size = New System.Drawing.Size(142, 20)
        Me.tbNewWare.TabIndex = 2
        '
        'tbNewEnter
        '
        Me.tbNewEnter.Location = New System.Drawing.Point(229, 233)
        Me.tbNewEnter.Name = "tbNewEnter"
        Me.tbNewEnter.Size = New System.Drawing.Size(177, 20)
        Me.tbNewEnter.TabIndex = 6
        '
        'lbEnters
        '
        Me.lbEnters.FormattingEnabled = True
        Me.lbEnters.Location = New System.Drawing.Point(194, 84)
        Me.lbEnters.Name = "lbEnters"
        Me.lbEnters.Size = New System.Drawing.Size(247, 95)
        Me.lbEnters.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(223, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(180, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Список доступных оприходований"
        '
        'tbNewLoss
        '
        Me.tbNewLoss.Location = New System.Drawing.Point(460, 233)
        Me.tbNewLoss.Name = "tbNewLoss"
        Me.tbNewLoss.Size = New System.Drawing.Size(185, 20)
        Me.tbNewLoss.TabIndex = 10
        '
        'lbLoss
        '
        Me.lbLoss.FormattingEnabled = True
        Me.lbLoss.Location = New System.Drawing.Point(447, 84)
        Me.lbLoss.Name = "lbLoss"
        Me.lbLoss.Size = New System.Drawing.Size(254, 95)
        Me.lbLoss.TabIndex = 9
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(495, 59)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(151, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Список доступных списаний"
        '
        'btSave
        '
        Me.btSave.Location = New System.Drawing.Point(622, 556)
        Me.btSave.Name = "btSave"
        Me.btSave.Size = New System.Drawing.Size(75, 23)
        Me.btSave.TabIndex = 12
        Me.btSave.Text = "Сохранить"
        Me.btSave.UseVisualStyleBackColor = True
        '
        'btClose
        '
        Me.btClose.Location = New System.Drawing.Point(715, 556)
        Me.btClose.Name = "btClose"
        Me.btClose.Size = New System.Drawing.Size(75, 23)
        Me.btClose.TabIndex = 13
        Me.btClose.Text = "Закрыть"
        Me.btClose.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(28, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(529, 29)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "*если склад не отображается, то надо проверить также файл разрешений на доступ"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(30, 217)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(96, 13)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Название склада"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(229, 216)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(177, 13)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "Номер оприходования (с нолями)"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(475, 216)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(145, 13)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Номер списания(с нолями)"
        '
        'NakladnyeTextBox
        '
        Me.NakladnyeTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MySettingsBindingSource, "Nakladnye", True))
        Me.NakladnyeTextBox.Location = New System.Drawing.Point(196, 358)
        Me.NakladnyeTextBox.Name = "NakladnyeTextBox"
        Me.NakladnyeTextBox.Size = New System.Drawing.Size(42, 20)
        Me.NakladnyeTextBox.TabIndex = 19
        '
        'ShippingTariffPerKGTextBox
        '
        Me.ShippingTariffPerKGTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MySettingsBindingSource, "ShippingTariffPerKG", True))
        Me.ShippingTariffPerKGTextBox.Location = New System.Drawing.Point(196, 382)
        Me.ShippingTariffPerKGTextBox.Name = "ShippingTariffPerKGTextBox"
        Me.ShippingTariffPerKGTextBox.Size = New System.Drawing.Size(42, 20)
        Me.ShippingTariffPerKGTextBox.TabIndex = 20
        '
        'ShippingTariffPerPCSTextBox
        '
        Me.ShippingTariffPerPCSTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MySettingsBindingSource, "ShippingTariffPerPCS", True))
        Me.ShippingTariffPerPCSTextBox.Location = New System.Drawing.Point(196, 407)
        Me.ShippingTariffPerPCSTextBox.Name = "ShippingTariffPerPCSTextBox"
        Me.ShippingTariffPerPCSTextBox.Size = New System.Drawing.Size(42, 20)
        Me.ShippingTariffPerPCSTextBox.TabIndex = 21
        '
        'ShippingTariffPerETextBox
        '
        Me.ShippingTariffPerETextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MySettingsBindingSource, "ShippingTariffPerE", True))
        Me.ShippingTariffPerETextBox.Location = New System.Drawing.Point(196, 433)
        Me.ShippingTariffPerETextBox.Name = "ShippingTariffPerETextBox"
        Me.ShippingTariffPerETextBox.Size = New System.Drawing.Size(42, 20)
        Me.ShippingTariffPerETextBox.TabIndex = 23
        '
        'EUOMUUIDTextBox
        '
        Me.EUOMUUIDTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MySettingsBindingSource, "EUOMUUID", True))
        Me.EUOMUUIDTextBox.Location = New System.Drawing.Point(517, 347)
        Me.EUOMUUIDTextBox.Name = "EUOMUUIDTextBox"
        Me.EUOMUUIDTextBox.Size = New System.Drawing.Size(271, 20)
        Me.EUOMUUIDTextBox.TabIndex = 25
        '
        'GUomUUIDTextBox
        '
        Me.GUomUUIDTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MySettingsBindingSource, "gUomUUID", True))
        Me.GUomUUIDTextBox.Location = New System.Drawing.Point(517, 383)
        Me.GUomUUIDTextBox.Name = "GUomUUIDTextBox"
        Me.GUomUUIDTextBox.Size = New System.Drawing.Size(271, 20)
        Me.GUomUUIDTextBox.TabIndex = 27
        '
        'KgUOMUUIDTextBox
        '
        Me.KgUOMUUIDTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MySettingsBindingSource, "KgUOMUUID", True))
        Me.KgUOMUUIDTextBox.Location = New System.Drawing.Point(517, 419)
        Me.KgUOMUUIDTextBox.Name = "KgUOMUUIDTextBox"
        Me.KgUOMUUIDTextBox.Size = New System.Drawing.Size(271, 20)
        Me.KgUOMUUIDTextBox.TabIndex = 29
        '
        'PcsUOMUUIDTextBox
        '
        Me.PcsUOMUUIDTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MySettingsBindingSource, "PcsUOMUUID", True))
        Me.PcsUOMUUIDTextBox.Location = New System.Drawing.Point(517, 455)
        Me.PcsUOMUUIDTextBox.Name = "PcsUOMUUIDTextBox"
        Me.PcsUOMUUIDTextBox.Size = New System.Drawing.Size(271, 20)
        Me.PcsUOMUUIDTextBox.TabIndex = 31
        '
        'RetailPriceTypeUuidTextBox
        '
        Me.RetailPriceTypeUuidTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MySettingsBindingSource, "RetailPriceTypeUuid", True))
        Me.RetailPriceTypeUuidTextBox.Location = New System.Drawing.Point(520, 487)
        Me.RetailPriceTypeUuidTextBox.Name = "RetailPriceTypeUuidTextBox"
        Me.RetailPriceTypeUuidTextBox.Size = New System.Drawing.Size(268, 20)
        Me.RetailPriceTypeUuidTextBox.TabIndex = 33
        '
        'WhosalePriceTypeUUIDTextBox
        '
        Me.WhosalePriceTypeUUIDTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MySettingsBindingSource, "WhosalePriceTypeUUID", True))
        Me.WhosalePriceTypeUUIDTextBox.Location = New System.Drawing.Point(520, 526)
        Me.WhosalePriceTypeUUIDTextBox.Name = "WhosalePriceTypeUUIDTextBox"
        Me.WhosalePriceTypeUUIDTextBox.Size = New System.Drawing.Size(268, 20)
        Me.WhosalePriceTypeUUIDTextBox.TabIndex = 35
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(244, 385)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(30, 13)
        Me.Label8.TabIndex = 36
        Me.Label8.Text = "EUR"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(244, 409)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(30, 13)
        Me.Label9.TabIndex = 37
        Me.Label9.Text = "EUR"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(244, 435)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(30, 13)
        Me.Label10.TabIndex = 38
        Me.Label10.Text = "EUR"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(322, 544)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(31, 13)
        Me.Label11.TabIndex = 41
        Me.Label11.Text = "RUR"
        '
        'tbWhourCost
        '
        Me.tbWhourCost.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MySettingsBindingSource, "Whourcost", True))
        Me.tbWhourCost.Location = New System.Drawing.Point(274, 542)
        Me.tbWhourCost.Name = "tbWhourCost"
        Me.tbWhourCost.Size = New System.Drawing.Size(42, 20)
        Me.tbWhourCost.TabIndex = 40
        '
        'TextBox1
        '
        Me.TextBox1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MySettingsBindingSource, "ProfitSTD", True))
        Me.TextBox1.Location = New System.Drawing.Point(196, 335)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(42, 20)
        Me.TextBox1.TabIndex = 43
        '
        'btAddWarehouse
        '
        Me.btAddWarehouse.Location = New System.Drawing.Point(31, 259)
        Me.btAddWarehouse.Name = "btAddWarehouse"
        Me.btAddWarehouse.Size = New System.Drawing.Size(75, 23)
        Me.btAddWarehouse.TabIndex = 44
        Me.btAddWarehouse.Text = "Добавить"
        Me.btAddWarehouse.UseVisualStyleBackColor = True
        '
        'btAddEnter
        '
        Me.btAddEnter.Location = New System.Drawing.Point(232, 259)
        Me.btAddEnter.Name = "btAddEnter"
        Me.btAddEnter.Size = New System.Drawing.Size(75, 23)
        Me.btAddEnter.TabIndex = 45
        Me.btAddEnter.Text = "Добавить"
        Me.btAddEnter.UseVisualStyleBackColor = True
        '
        'btAddLoss
        '
        Me.btAddLoss.Location = New System.Drawing.Point(460, 259)
        Me.btAddLoss.Name = "btAddLoss"
        Me.btAddLoss.Size = New System.Drawing.Size(75, 23)
        Me.btAddLoss.TabIndex = 46
        Me.btAddLoss.Text = "Добавить"
        Me.btAddLoss.UseVisualStyleBackColor = True
        '
        'btAcceptNewWare
        '
        Me.btAcceptNewWare.Location = New System.Drawing.Point(668, 194)
        Me.btAcceptNewWare.Name = "btAcceptNewWare"
        Me.btAcceptNewWare.Size = New System.Drawing.Size(120, 88)
        Me.btAcceptNewWare.TabIndex = 47
        Me.btAcceptNewWare.Text = "Применить"
        Me.btAcceptNewWare.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(28, 285)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(529, 29)
        Me.Label14.TabIndex = 48
        Me.Label14.Text = "*для указания нового склада необходимо предварительно создать также оприходование" & _
    " и списание для этого склада, а затем ввести их номера в соответствующие поля."
        '
        'btDelWare
        '
        Me.btDelWare.Location = New System.Drawing.Point(73, 185)
        Me.btDelWare.Name = "btDelWare"
        Me.btDelWare.Size = New System.Drawing.Size(75, 23)
        Me.btDelWare.TabIndex = 49
        Me.btDelWare.Text = "удалить"
        Me.btDelWare.UseVisualStyleBackColor = True
        '
        'btDelEnter
        '
        Me.btDelEnter.Location = New System.Drawing.Point(274, 185)
        Me.btDelEnter.Name = "btDelEnter"
        Me.btDelEnter.Size = New System.Drawing.Size(75, 23)
        Me.btDelEnter.TabIndex = 50
        Me.btDelEnter.Text = "удалить"
        Me.btDelEnter.UseVisualStyleBackColor = True
        '
        'btDelLoss
        '
        Me.btDelLoss.Location = New System.Drawing.Point(545, 185)
        Me.btDelLoss.Name = "btDelLoss"
        Me.btDelLoss.Size = New System.Drawing.Size(75, 23)
        Me.btDelLoss.TabIndex = 51
        Me.btDelLoss.Text = "удалить"
        Me.btDelLoss.UseVisualStyleBackColor = True
        '
        'btSaveWare
        '
        Me.btSaveWare.Location = New System.Drawing.Point(715, 104)
        Me.btSaveWare.Name = "btSaveWare"
        Me.btSaveWare.Size = New System.Drawing.Size(75, 23)
        Me.btSaveWare.TabIndex = 52
        Me.btSaveWare.Text = "Сохранить"
        Me.btSaveWare.UseVisualStyleBackColor = True
        '
        'btReadWare
        '
        Me.btReadWare.Location = New System.Drawing.Point(715, 133)
        Me.btReadWare.Name = "btReadWare"
        Me.btReadWare.Size = New System.Drawing.Size(75, 23)
        Me.btReadWare.TabIndex = 53
        Me.btReadWare.Text = "Прочитать"
        Me.btReadWare.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(712, 73)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(81, 13)
        Me.Label15.TabIndex = 54
        Me.Label15.Text = "Файл складов"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(322, 461)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(15, 13)
        Me.Label16.TabIndex = 57
        Me.Label16.Text = "%"
        '
        'Label17
        '
        Label17.AutoSize = True
        Label17.Location = New System.Drawing.Point(4, 461)
        Label17.Name = "Label17"
        Label17.Size = New System.Drawing.Size(265, 13)
        Label17.TabIndex = 55
        Label17.Text = "Налоговая база(или расход по получению налика):"
        '
        'TextBox2
        '
        Me.TextBox2.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MySettingsBindingSource, "NLcost", True))
        Me.TextBox2.Location = New System.Drawing.Point(274, 458)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(42, 20)
        Me.TextBox2.TabIndex = 56
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(322, 487)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(15, 13)
        Me.Label18.TabIndex = 60
        Me.Label18.Text = "%"
        '
        'Label19
        '
        Label19.AutoSize = True
        Label19.Location = New System.Drawing.Point(66, 487)
        Label19.Name = "Label19"
        Label19.Size = New System.Drawing.Size(202, 13)
        Label19.TabIndex = 58
        Label19.Text = "Наша добавка с грязной оплаты часа:"
        '
        'TextBox3
        '
        Me.TextBox3.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MySettingsBindingSource, "TRsalary", True))
        Me.TextBox3.Location = New System.Drawing.Point(274, 484)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(42, 20)
        Me.TextBox3.TabIndex = 59
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(321, 513)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(15, 13)
        Me.Label20.TabIndex = 63
        Me.Label20.Text = "%"
        '
        'Label21
        '
        Label21.AutoSize = True
        Label21.Location = New System.Drawing.Point(121, 513)
        Label21.Name = "Label21"
        Label21.Size = New System.Drawing.Size(146, 13)
        Label21.TabIndex = 61
        Label21.Text = "Годовая кредитная ставка:"
        '
        'TextBox4
        '
        Me.TextBox4.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MySettingsBindingSource, "Credit", True))
        Me.TextBox4.Location = New System.Drawing.Point(273, 510)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(42, 20)
        Me.TextBox4.TabIndex = 62
        '
        'MySettingsBindingSource
        '
        Me.MySettingsBindingSource.DataSource = GetType(System.Configuration.ApplicationSettingsBase)
        '
        'fmOptions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(803, 588)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Label21)
        Me.Controls.Add(Me.TextBox4)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Label19)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Label17)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.btReadWare)
        Me.Controls.Add(Me.btSaveWare)
        Me.Controls.Add(Me.btDelLoss)
        Me.Controls.Add(Me.btDelEnter)
        Me.Controls.Add(Me.btDelWare)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.btAcceptNewWare)
        Me.Controls.Add(Me.btAddLoss)
        Me.Controls.Add(Me.btAddEnter)
        Me.Controls.Add(Me.btAddWarehouse)
        Me.Controls.Add(Label13)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Label12)
        Me.Controls.Add(Me.tbWhourCost)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(WhosalePriceTypeUUIDLabel)
        Me.Controls.Add(Me.WhosalePriceTypeUUIDTextBox)
        Me.Controls.Add(RetailPriceTypeUuidLabel)
        Me.Controls.Add(Me.RetailPriceTypeUuidTextBox)
        Me.Controls.Add(PcsUOMUUIDLabel)
        Me.Controls.Add(Me.PcsUOMUUIDTextBox)
        Me.Controls.Add(KgUOMUUIDLabel)
        Me.Controls.Add(Me.KgUOMUUIDTextBox)
        Me.Controls.Add(GUomUUIDLabel)
        Me.Controls.Add(Me.GUomUUIDTextBox)
        Me.Controls.Add(EUOMUUIDLabel)
        Me.Controls.Add(Me.EUOMUUIDTextBox)
        Me.Controls.Add(ShippingTariffPerELabel)
        Me.Controls.Add(Me.ShippingTariffPerETextBox)
        Me.Controls.Add(ShippingTariffPerPCSLabel)
        Me.Controls.Add(Me.ShippingTariffPerPCSTextBox)
        Me.Controls.Add(ShippingTariffPerKGLabel)
        Me.Controls.Add(Me.ShippingTariffPerKGTextBox)
        Me.Controls.Add(NakladnyeLabel)
        Me.Controls.Add(Me.NakladnyeTextBox)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btClose)
        Me.Controls.Add(Me.btSave)
        Me.Controls.Add(Me.tbNewLoss)
        Me.Controls.Add(Me.lbLoss)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.tbNewEnter)
        Me.Controls.Add(Me.lbEnters)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tbNewWare)
        Me.Controls.Add(Me.lbWareList)
        Me.Controls.Add(Me.Label1)
        Me.Name = "fmOptions"
        Me.Text = "Настройки"
        CType(Me.MySettingsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lbWareList As System.Windows.Forms.ListBox
    Friend WithEvents tbNewWare As System.Windows.Forms.TextBox
    Friend WithEvents tbNewEnter As System.Windows.Forms.TextBox
    Friend WithEvents lbEnters As System.Windows.Forms.ListBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tbNewLoss As System.Windows.Forms.TextBox
    Friend WithEvents lbLoss As System.Windows.Forms.ListBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btSave As System.Windows.Forms.Button
    Friend WithEvents btClose As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents NakladnyeTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ShippingTariffPerKGTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ShippingTariffPerPCSTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ShippingTariffPerETextBox As System.Windows.Forms.TextBox
    Friend WithEvents EUOMUUIDTextBox As System.Windows.Forms.TextBox
    Friend WithEvents GUomUUIDTextBox As System.Windows.Forms.TextBox
    Friend WithEvents KgUOMUUIDTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PcsUOMUUIDTextBox As System.Windows.Forms.TextBox
    Friend WithEvents RetailPriceTypeUuidTextBox As System.Windows.Forms.TextBox
    Friend WithEvents WhosalePriceTypeUUIDTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents tbWhourCost As System.Windows.Forms.TextBox
    Friend WithEvents MySettingsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents btAddWarehouse As System.Windows.Forms.Button
    Friend WithEvents btAddEnter As System.Windows.Forms.Button
    Friend WithEvents btAddLoss As System.Windows.Forms.Button
    Friend WithEvents btAcceptNewWare As System.Windows.Forms.Button
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents btDelWare As System.Windows.Forms.Button
    Friend WithEvents btDelEnter As System.Windows.Forms.Button
    Friend WithEvents btDelLoss As System.Windows.Forms.Button
    Friend WithEvents btSaveWare As System.Windows.Forms.Button
    Friend WithEvents btReadWare As System.Windows.Forms.Button
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
End Class
