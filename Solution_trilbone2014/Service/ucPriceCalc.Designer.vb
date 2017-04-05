<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucPriceCalc
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
        Me.tbWeight = New System.Windows.Forms.TextBox()
        Me.UcPriceCalc_clsPriceDataBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.lbW = New System.Windows.Forms.Label()
        Me.lbR = New System.Windows.Forms.Label()
        Me.tbRaw = New System.Windows.Forms.TextBox()
        Me.lbP = New System.Windows.Forms.Label()
        Me.tbPrep = New System.Windows.Forms.TextBox()
        Me.lbrr = New System.Windows.Forms.Label()
        Me.lbrr1 = New System.Windows.Forms.Label()
        Me.lbR1 = New System.Windows.Forms.Label()
        Me.tbRateEu = New System.Windows.Forms.TextBox()
        Me.lbR2 = New System.Windows.Forms.Label()
        Me.tbRateEuUs = New System.Windows.Forms.TextBox()
        Me.btCalculate = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.lbC = New System.Windows.Forms.Label()
        Me.L1 = New System.Windows.Forms.Label()
        Me.L2 = New System.Windows.Forms.Label()
        Me.L3 = New System.Windows.Forms.Label()
        Me.L4 = New System.Windows.Forms.Label()
        Me.L5 = New System.Windows.Forms.Label()
        Me.L6 = New System.Windows.Forms.Label()
        Me.L7 = New System.Windows.Forms.Label()
        Me.lbC1 = New System.Windows.Forms.Label()
        Me.R1 = New System.Windows.Forms.Label()
        Me.R2 = New System.Windows.Forms.Label()
        Me.R3 = New System.Windows.Forms.Label()
        Me.R4 = New System.Windows.Forms.Label()
        Me.R5 = New System.Windows.Forms.Label()
        Me.R6 = New System.Windows.Forms.Label()
        Me.R7 = New System.Windows.Forms.Label()
        Me.W2 = New System.Windows.Forms.Label()
        Me.W3 = New System.Windows.Forms.Label()
        Me.W4 = New System.Windows.Forms.Label()
        Me.W5 = New System.Windows.Forms.Label()
        Me.W6 = New System.Windows.Forms.Label()
        Me.W1 = New System.Windows.Forms.Label()
        Me.B1 = New System.Windows.Forms.RadioButton()
        Me.B2 = New System.Windows.Forms.RadioButton()
        Me.B3 = New System.Windows.Forms.RadioButton()
        Me.B4 = New System.Windows.Forms.RadioButton()
        Me.B5 = New System.Windows.Forms.RadioButton()
        Me.B6 = New System.Windows.Forms.RadioButton()
        Me.B7 = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbTunePrice = New System.Windows.Forms.TextBox()
        Me.btTunePrice = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btSowExcel = New System.Windows.Forms.Button()
        Me.tbPercent = New System.Windows.Forms.TextBox()
        Me.btPlus = New System.Windows.Forms.Button()
        Me.btMinus = New System.Windows.Forms.Button()
        Me.cbScheme5050 = New System.Windows.Forms.CheckBox()
        CType(Me.UcPriceCalc_clsPriceDataBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tbWeight
        '
        Me.tbWeight.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.UcPriceCalc_clsPriceDataBindingSource, "Weight", True))
        Me.tbWeight.Location = New System.Drawing.Point(170, 0)
        Me.tbWeight.Name = "tbWeight"
        Me.tbWeight.Size = New System.Drawing.Size(48, 20)
        Me.tbWeight.TabIndex = 0
        '
        'UcPriceCalc_clsPriceDataBindingSource
        '
        Me.UcPriceCalc_clsPriceDataBindingSource.DataSource = GetType(Service.ucPriceCalc.clsPriceData)
        '
        'lbW
        '
        Me.lbW.AutoSize = True
        Me.lbW.Location = New System.Drawing.Point(91, 3)
        Me.lbW.Name = "lbW"
        Me.lbW.Size = New System.Drawing.Size(70, 13)
        Me.lbW.TabIndex = 1
        Me.lbW.Text = "вес образца"
        '
        'lbR
        '
        Me.lbR.Location = New System.Drawing.Point(3, 23)
        Me.lbR.Name = "lbR"
        Me.lbR.Size = New System.Drawing.Size(161, 29)
        Me.lbR.TabIndex = 3
        Me.lbR.Text = "добыча(стоимость сырого материала, включая прибыль)"
        '
        'tbRaw
        '
        Me.tbRaw.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.UcPriceCalc_clsPriceDataBindingSource, "Hunt_cost", True))
        Me.tbRaw.Location = New System.Drawing.Point(170, 32)
        Me.tbRaw.Name = "tbRaw"
        Me.tbRaw.Size = New System.Drawing.Size(51, 20)
        Me.tbRaw.TabIndex = 2
        '
        'lbP
        '
        Me.lbP.Location = New System.Drawing.Point(3, 55)
        Me.lbP.Name = "lbP"
        Me.lbP.Size = New System.Drawing.Size(161, 29)
        Me.lbP.TabIndex = 5
        Me.lbP.Text = "препарация (включая прибыль)"
        '
        'tbPrep
        '
        Me.tbPrep.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.UcPriceCalc_clsPriceDataBindingSource, "Prep_cost", True))
        Me.tbPrep.Location = New System.Drawing.Point(170, 64)
        Me.tbPrep.Name = "tbPrep"
        Me.tbPrep.Size = New System.Drawing.Size(51, 20)
        Me.tbPrep.TabIndex = 4
        '
        'lbrr
        '
        Me.lbrr.AutoSize = True
        Me.lbrr.Location = New System.Drawing.Point(227, 36)
        Me.lbrr.Name = "lbrr"
        Me.lbrr.Size = New System.Drawing.Size(27, 13)
        Me.lbrr.TabIndex = 6
        Me.lbrr.Text = "руб."
        '
        'lbrr1
        '
        Me.lbrr1.AutoSize = True
        Me.lbrr1.Location = New System.Drawing.Point(227, 67)
        Me.lbrr1.Name = "lbrr1"
        Me.lbrr1.Size = New System.Drawing.Size(27, 13)
        Me.lbrr1.TabIndex = 7
        Me.lbrr1.Text = "руб."
        '
        'lbR1
        '
        Me.lbR1.AutoSize = True
        Me.lbR1.Location = New System.Drawing.Point(319, 6)
        Me.lbR1.Name = "lbR1"
        Me.lbR1.Size = New System.Drawing.Size(57, 13)
        Me.lbR1.TabIndex = 9
        Me.lbR1.Text = "курс евро"
        '
        'tbRateEu
        '
        Me.tbRateEu.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.UcPriceCalc_clsPriceDataBindingSource, "Eu_rate", True))
        Me.tbRateEu.Location = New System.Drawing.Point(382, 3)
        Me.tbRateEu.Name = "tbRateEu"
        Me.tbRateEu.Size = New System.Drawing.Size(68, 20)
        Me.tbRateEu.TabIndex = 8
        Me.tbRateEu.Text = "70,00"
        '
        'lbR2
        '
        Me.lbR2.AutoSize = True
        Me.lbR2.Location = New System.Drawing.Point(278, 29)
        Me.lbR2.Name = "lbR2"
        Me.lbR2.Size = New System.Drawing.Size(98, 13)
        Me.lbR2.TabIndex = 11
        Me.lbR2.Text = "курс доллар/евро"
        '
        'tbRateEuUs
        '
        Me.tbRateEuUs.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.UcPriceCalc_clsPriceDataBindingSource, "Eu_Us_rate", True))
        Me.tbRateEuUs.Location = New System.Drawing.Point(382, 26)
        Me.tbRateEuUs.Name = "tbRateEuUs"
        Me.tbRateEuUs.Size = New System.Drawing.Size(68, 20)
        Me.tbRateEuUs.TabIndex = 10
        Me.tbRateEuUs.Text = "1,140"
        '
        'btCalculate
        '
        Me.btCalculate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btCalculate.Location = New System.Drawing.Point(230, 269)
        Me.btCalculate.Name = "btCalculate"
        Me.btCalculate.Size = New System.Drawing.Size(104, 27)
        Me.btCalculate.TabIndex = 12
        Me.btCalculate.Text = "Рассчитать"
        Me.btCalculate.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 166.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.lbC, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.L1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.L2, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.L3, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.L4, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.L5, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.L6, 0, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.L7, 0, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.lbC1, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.R1, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.R2, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.R3, 2, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.R4, 2, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.R5, 2, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.R6, 2, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.R7, 2, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.W2, 3, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.W3, 3, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.W4, 3, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.W5, 3, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.W6, 3, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.W1, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.B1, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.B2, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.B3, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.B4, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.B5, 1, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.B6, 1, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.B7, 1, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.cbScheme5050, 3, 7)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(4, 102)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 8
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(449, 162)
        Me.TableLayoutPanel1.TabIndex = 13
        '
        'lbC
        '
        Me.lbC.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbC.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.lbC, 2)
        Me.lbC.Location = New System.Drawing.Point(169, 3)
        Me.lbC.Name = "lbC"
        Me.lbC.Size = New System.Drawing.Size(149, 13)
        Me.lbC.TabIndex = 0
        Me.lbC.Text = "Розница"
        '
        'L1
        '
        Me.L1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.L1.AutoSize = True
        Me.L1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.L1.Location = New System.Drawing.Point(3, 23)
        Me.L1.Name = "L1"
        Me.L1.Size = New System.Drawing.Size(106, 13)
        Me.L1.TabIndex = 2
        Me.L1.Text = "Россия в офисе "
        '
        'L2
        '
        Me.L2.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.L2.AutoSize = True
        Me.L2.Location = New System.Drawing.Point(3, 43)
        Me.L2.Name = "L2"
        Me.L2.Size = New System.Drawing.Size(147, 13)
        Me.L2.TabIndex = 3
        Me.L2.Text = "Россия на выставке(лавке)"
        '
        'L3
        '
        Me.L3.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.L3.AutoSize = True
        Me.L3.Location = New System.Drawing.Point(3, 63)
        Me.L3.Name = "L3"
        Me.L3.Size = New System.Drawing.Size(88, 13)
        Me.L3.TabIndex = 4
        Me.L3.Text = "Буржуи в офисе"
        '
        'L4
        '
        Me.L4.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.L4.AutoSize = True
        Me.L4.Location = New System.Drawing.Point(3, 83)
        Me.L4.Name = "L4"
        Me.L4.Size = New System.Drawing.Size(117, 13)
        Me.L4.TabIndex = 5
        Me.L4.Text = "Почта оплата на банк"
        '
        'L5
        '
        Me.L5.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.L5.AutoSize = True
        Me.L5.Location = New System.Drawing.Point(3, 103)
        Me.L5.Name = "L5"
        Me.L5.Size = New System.Drawing.Size(119, 13)
        Me.L5.TabIndex = 6
        Me.L5.Text = "Почта оплата PAYPAL"
        '
        'L6
        '
        Me.L6.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.L6.AutoSize = True
        Me.L6.Location = New System.Drawing.Point(3, 123)
        Me.L6.Name = "L6"
        Me.L6.Size = New System.Drawing.Size(111, 13)
        Me.L6.TabIndex = 7
        Me.L6.Text = "Буржуи на выставке"
        '
        'L7
        '
        Me.L7.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.L7.AutoSize = True
        Me.L7.Location = New System.Drawing.Point(3, 144)
        Me.L7.Name = "L7"
        Me.L7.Size = New System.Drawing.Size(31, 13)
        Me.L7.TabIndex = 8
        Me.L7.Text = "Ebay"
        '
        'lbC1
        '
        Me.lbC1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbC1.AutoSize = True
        Me.lbC1.Location = New System.Drawing.Point(324, 3)
        Me.lbC1.Name = "lbC1"
        Me.lbC1.Size = New System.Drawing.Size(122, 13)
        Me.lbC1.TabIndex = 1
        Me.lbC1.Text = "Опт"
        '
        'R1
        '
        Me.R1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.R1.AutoSize = True
        Me.R1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.UcPriceCalc_clsPriceDataBindingSource, "Rus_office", True))
        Me.R1.Location = New System.Drawing.Point(197, 23)
        Me.R1.Name = "R1"
        Me.R1.Size = New System.Drawing.Size(39, 13)
        Me.R1.TabIndex = 16
        Me.R1.Text = "Label1"
        '
        'R2
        '
        Me.R2.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.R2.AutoSize = True
        Me.R2.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.UcPriceCalc_clsPriceDataBindingSource, "Rus_show", True))
        Me.R2.Location = New System.Drawing.Point(197, 43)
        Me.R2.Name = "R2"
        Me.R2.Size = New System.Drawing.Size(39, 13)
        Me.R2.TabIndex = 17
        Me.R2.Text = "Label2"
        '
        'R3
        '
        Me.R3.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.R3.AutoSize = True
        Me.R3.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.UcPriceCalc_clsPriceDataBindingSource, "Eu_office", True))
        Me.R3.Location = New System.Drawing.Point(197, 63)
        Me.R3.Name = "R3"
        Me.R3.Size = New System.Drawing.Size(39, 13)
        Me.R3.TabIndex = 18
        Me.R3.Text = "Label3"
        '
        'R4
        '
        Me.R4.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.R4.AutoSize = True
        Me.R4.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.UcPriceCalc_clsPriceDataBindingSource, "Eu_post_bank", True))
        Me.R4.Location = New System.Drawing.Point(197, 83)
        Me.R4.Name = "R4"
        Me.R4.Size = New System.Drawing.Size(39, 13)
        Me.R4.TabIndex = 19
        Me.R4.Text = "Label4"
        '
        'R5
        '
        Me.R5.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.R5.AutoSize = True
        Me.R5.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.UcPriceCalc_clsPriceDataBindingSource, "Eu_post_paypal", True))
        Me.R5.Location = New System.Drawing.Point(197, 103)
        Me.R5.Name = "R5"
        Me.R5.Size = New System.Drawing.Size(39, 13)
        Me.R5.TabIndex = 20
        Me.R5.Text = "Label5"
        '
        'R6
        '
        Me.R6.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.R6.AutoSize = True
        Me.R6.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.UcPriceCalc_clsPriceDataBindingSource, "Eu_show", True))
        Me.R6.Location = New System.Drawing.Point(197, 123)
        Me.R6.Name = "R6"
        Me.R6.Size = New System.Drawing.Size(39, 13)
        Me.R6.TabIndex = 21
        Me.R6.Text = "Label6"
        '
        'R7
        '
        Me.R7.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.R7.AutoSize = True
        Me.R7.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.UcPriceCalc_clsPriceDataBindingSource, "eBay", True))
        Me.R7.Location = New System.Drawing.Point(197, 144)
        Me.R7.Name = "R7"
        Me.R7.Size = New System.Drawing.Size(39, 13)
        Me.R7.TabIndex = 22
        Me.R7.Text = "Label7"
        '
        'W2
        '
        Me.W2.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.W2.AutoSize = True
        Me.W2.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.UcPriceCalc_clsPriceDataBindingSource, "Rus_show_w", True))
        Me.W2.Location = New System.Drawing.Point(324, 43)
        Me.W2.Name = "W2"
        Me.W2.Size = New System.Drawing.Size(39, 13)
        Me.W2.TabIndex = 24
        Me.W2.Text = "Label9"
        '
        'W3
        '
        Me.W3.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.W3.AutoSize = True
        Me.W3.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.UcPriceCalc_clsPriceDataBindingSource, "Eu_office_w", True))
        Me.W3.Location = New System.Drawing.Point(324, 63)
        Me.W3.Name = "W3"
        Me.W3.Size = New System.Drawing.Size(45, 13)
        Me.W3.TabIndex = 25
        Me.W3.Text = "Label17"
        '
        'W4
        '
        Me.W4.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.W4.AutoSize = True
        Me.W4.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.UcPriceCalc_clsPriceDataBindingSource, "Eu_post_bank_w", True))
        Me.W4.Location = New System.Drawing.Point(324, 83)
        Me.W4.Name = "W4"
        Me.W4.Size = New System.Drawing.Size(45, 13)
        Me.W4.TabIndex = 26
        Me.W4.Text = "Label18"
        '
        'W5
        '
        Me.W5.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.W5.AutoSize = True
        Me.W5.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.UcPriceCalc_clsPriceDataBindingSource, "Eu_post_paypal_w", True))
        Me.W5.Location = New System.Drawing.Point(324, 103)
        Me.W5.Name = "W5"
        Me.W5.Size = New System.Drawing.Size(45, 13)
        Me.W5.TabIndex = 27
        Me.W5.Text = "Label19"
        '
        'W6
        '
        Me.W6.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.W6.AutoSize = True
        Me.W6.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.UcPriceCalc_clsPriceDataBindingSource, "Eu_show_w", True))
        Me.W6.Location = New System.Drawing.Point(324, 123)
        Me.W6.Name = "W6"
        Me.W6.Size = New System.Drawing.Size(45, 13)
        Me.W6.TabIndex = 28
        Me.W6.Text = "Label20"
        '
        'W1
        '
        Me.W1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.W1.AutoSize = True
        Me.W1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.UcPriceCalc_clsPriceDataBindingSource, "Rus_office_w", True))
        Me.W1.Location = New System.Drawing.Point(324, 23)
        Me.W1.Name = "W1"
        Me.W1.Size = New System.Drawing.Size(39, 13)
        Me.W1.TabIndex = 23
        Me.W1.Text = "Label8"
        '
        'B1
        '
        Me.B1.AutoSize = True
        Me.B1.Location = New System.Drawing.Point(169, 23)
        Me.B1.Name = "B1"
        Me.B1.Size = New System.Drawing.Size(14, 13)
        Me.B1.TabIndex = 29
        Me.B1.TabStop = True
        Me.B1.UseVisualStyleBackColor = True
        '
        'B2
        '
        Me.B2.AutoSize = True
        Me.B2.Location = New System.Drawing.Point(169, 43)
        Me.B2.Name = "B2"
        Me.B2.Size = New System.Drawing.Size(14, 13)
        Me.B2.TabIndex = 30
        Me.B2.TabStop = True
        Me.B2.UseVisualStyleBackColor = True
        '
        'B3
        '
        Me.B3.AutoSize = True
        Me.B3.Location = New System.Drawing.Point(169, 63)
        Me.B3.Name = "B3"
        Me.B3.Size = New System.Drawing.Size(14, 13)
        Me.B3.TabIndex = 31
        Me.B3.TabStop = True
        Me.B3.UseVisualStyleBackColor = True
        '
        'B4
        '
        Me.B4.AutoSize = True
        Me.B4.Location = New System.Drawing.Point(169, 83)
        Me.B4.Name = "B4"
        Me.B4.Size = New System.Drawing.Size(14, 13)
        Me.B4.TabIndex = 32
        Me.B4.TabStop = True
        Me.B4.UseVisualStyleBackColor = True
        '
        'B5
        '
        Me.B5.AutoSize = True
        Me.B5.Location = New System.Drawing.Point(169, 103)
        Me.B5.Name = "B5"
        Me.B5.Size = New System.Drawing.Size(14, 13)
        Me.B5.TabIndex = 33
        Me.B5.TabStop = True
        Me.B5.UseVisualStyleBackColor = True
        '
        'B6
        '
        Me.B6.AutoSize = True
        Me.B6.Location = New System.Drawing.Point(169, 123)
        Me.B6.Name = "B6"
        Me.B6.Size = New System.Drawing.Size(14, 13)
        Me.B6.TabIndex = 34
        Me.B6.TabStop = True
        Me.B6.UseVisualStyleBackColor = True
        '
        'B7
        '
        Me.B7.AutoSize = True
        Me.B7.Location = New System.Drawing.Point(169, 143)
        Me.B7.Name = "B7"
        Me.B7.Size = New System.Drawing.Size(14, 13)
        Me.B7.TabIndex = 35
        Me.B7.TabStop = True
        Me.B7.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 277)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 13)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Задать цену"
        '
        'tbTunePrice
        '
        Me.tbTunePrice.Location = New System.Drawing.Point(81, 273)
        Me.tbTunePrice.Name = "tbTunePrice"
        Me.tbTunePrice.Size = New System.Drawing.Size(43, 20)
        Me.tbTunePrice.TabIndex = 15
        '
        'btTunePrice
        '
        Me.btTunePrice.Location = New System.Drawing.Point(132, 269)
        Me.btTunePrice.Name = "btTunePrice"
        Me.btTunePrice.Size = New System.Drawing.Size(75, 27)
        Me.btTunePrice.TabIndex = 16
        Me.btTunePrice.Text = "Подобрать"
        Me.btTunePrice.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(224, 3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(18, 13)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "кг"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label3.Location = New System.Drawing.Point(262, 63)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(102, 13)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "Коэфф прибыли"
        '
        'btSowExcel
        '
        Me.btSowExcel.Enabled = False
        Me.btSowExcel.Location = New System.Drawing.Point(355, 269)
        Me.btSowExcel.Name = "btSowExcel"
        Me.btSowExcel.Size = New System.Drawing.Size(98, 27)
        Me.btSowExcel.TabIndex = 20
        Me.btSowExcel.Text = "Excel"
        Me.btSowExcel.UseVisualStyleBackColor = True
        '
        'tbPercent
        '
        Me.tbPercent.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.UcPriceCalc_clsPriceDataBindingSource, "Clear_Profit", True))
        Me.tbPercent.Location = New System.Drawing.Point(368, 60)
        Me.tbPercent.Name = "tbPercent"
        Me.tbPercent.Size = New System.Drawing.Size(34, 20)
        Me.tbPercent.TabIndex = 19
        Me.tbPercent.Text = "1"
        '
        'btPlus
        '
        Me.btPlus.Location = New System.Drawing.Point(409, 51)
        Me.btPlus.Name = "btPlus"
        Me.btPlus.Size = New System.Drawing.Size(27, 23)
        Me.btPlus.TabIndex = 21
        Me.btPlus.Text = "+"
        Me.btPlus.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btPlus.UseVisualStyleBackColor = True
        '
        'btMinus
        '
        Me.btMinus.Location = New System.Drawing.Point(409, 74)
        Me.btMinus.Name = "btMinus"
        Me.btMinus.Size = New System.Drawing.Size(27, 23)
        Me.btMinus.TabIndex = 22
        Me.btMinus.Text = "-"
        Me.btMinus.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btMinus.UseVisualStyleBackColor = True
        '
        'cbScheme5050
        '
        Me.cbScheme5050.AutoSize = True
        Me.cbScheme5050.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.cbScheme5050.Location = New System.Drawing.Point(324, 143)
        Me.cbScheme5050.Name = "cbScheme5050"
        Me.cbScheme5050.Size = New System.Drawing.Size(100, 16)
        Me.cbScheme5050.TabIndex = 36
        Me.cbScheme5050.Text = "схема 50/50"
        Me.cbScheme5050.UseVisualStyleBackColor = True
        '
        'ucPriceCalc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btMinus)
        Me.Controls.Add(Me.btPlus)
        Me.Controls.Add(Me.btSowExcel)
        Me.Controls.Add(Me.tbPercent)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btTunePrice)
        Me.Controls.Add(Me.tbTunePrice)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.btCalculate)
        Me.Controls.Add(Me.lbR2)
        Me.Controls.Add(Me.tbRateEuUs)
        Me.Controls.Add(Me.lbR1)
        Me.Controls.Add(Me.tbRateEu)
        Me.Controls.Add(Me.lbrr1)
        Me.Controls.Add(Me.lbrr)
        Me.Controls.Add(Me.lbP)
        Me.Controls.Add(Me.tbPrep)
        Me.Controls.Add(Me.lbR)
        Me.Controls.Add(Me.tbRaw)
        Me.Controls.Add(Me.lbW)
        Me.Controls.Add(Me.tbWeight)
        Me.Name = "ucPriceCalc"
        Me.Size = New System.Drawing.Size(456, 300)
        CType(Me.UcPriceCalc_clsPriceDataBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tbWeight As System.Windows.Forms.TextBox
    Friend WithEvents lbW As System.Windows.Forms.Label
    Friend WithEvents lbR As System.Windows.Forms.Label
    Friend WithEvents tbRaw As System.Windows.Forms.TextBox
    Friend WithEvents lbP As System.Windows.Forms.Label
    Friend WithEvents tbPrep As System.Windows.Forms.TextBox
    Friend WithEvents lbrr As System.Windows.Forms.Label
    Friend WithEvents lbrr1 As System.Windows.Forms.Label
    Friend WithEvents lbR1 As System.Windows.Forms.Label
    Friend WithEvents tbRateEu As System.Windows.Forms.TextBox
    Friend WithEvents lbR2 As System.Windows.Forms.Label
    Friend WithEvents tbRateEuUs As System.Windows.Forms.TextBox
    Friend WithEvents btCalculate As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lbC As System.Windows.Forms.Label
    Friend WithEvents lbC1 As System.Windows.Forms.Label
    Friend WithEvents L1 As System.Windows.Forms.Label
    Friend WithEvents L2 As System.Windows.Forms.Label
    Friend WithEvents L3 As System.Windows.Forms.Label
    Friend WithEvents L4 As System.Windows.Forms.Label
    Friend WithEvents L5 As System.Windows.Forms.Label
    Friend WithEvents L6 As System.Windows.Forms.Label
    Friend WithEvents L7 As System.Windows.Forms.Label
    Friend WithEvents R1 As System.Windows.Forms.Label
    Friend WithEvents R2 As System.Windows.Forms.Label
    Friend WithEvents R3 As System.Windows.Forms.Label
    Friend WithEvents R4 As System.Windows.Forms.Label
    Friend WithEvents R5 As System.Windows.Forms.Label
    Friend WithEvents R6 As System.Windows.Forms.Label
    Friend WithEvents R7 As System.Windows.Forms.Label
    Friend WithEvents W1 As System.Windows.Forms.Label
    Friend WithEvents W2 As System.Windows.Forms.Label
    Friend WithEvents W3 As System.Windows.Forms.Label
    Friend WithEvents W4 As System.Windows.Forms.Label
    Friend WithEvents W5 As System.Windows.Forms.Label
    Friend WithEvents W6 As System.Windows.Forms.Label
    Friend WithEvents B1 As System.Windows.Forms.RadioButton
    Friend WithEvents B2 As System.Windows.Forms.RadioButton
    Friend WithEvents B3 As System.Windows.Forms.RadioButton
    Friend WithEvents B4 As System.Windows.Forms.RadioButton
    Friend WithEvents B5 As System.Windows.Forms.RadioButton
    Friend WithEvents B6 As System.Windows.Forms.RadioButton
    Friend WithEvents B7 As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tbTunePrice As System.Windows.Forms.TextBox
    Friend WithEvents btTunePrice As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents UcPriceCalc_clsPriceDataBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents btSowExcel As System.Windows.Forms.Button
    Friend WithEvents tbPercent As System.Windows.Forms.TextBox
    Friend WithEvents btPlus As System.Windows.Forms.Button
    Friend WithEvents btMinus As System.Windows.Forms.Button
    Friend WithEvents cbScheme5050 As System.Windows.Forms.CheckBox

End Class
