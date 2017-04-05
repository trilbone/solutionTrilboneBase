<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucSellGood
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
        Me.tbCtlMain = New System.Windows.Forms.TabControl()
        Me.tpAgentSelect = New System.Windows.Forms.TabPage()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.btSearchSell = New System.Windows.Forms.Button()
        Me.cbActiveSellList = New System.Windows.Forms.ComboBox()
        Me.btClear = New System.Windows.Forms.Button()
        Me.bt_2015 = New System.Windows.Forms.Button()
        Me.cbxPayment = New System.Windows.Forms.ComboBox()
        Me.cbxOrder = New System.Windows.Forms.ComboBox()
        Me.cbxDemand = New System.Windows.Forms.ComboBox()
        Me.btInPayment = New System.Windows.Forms.Button()
        Me.btOrder = New System.Windows.Forms.Button()
        Me.btDemand = New System.Windows.Forms.Button()
        Me.cbxInMoySklad = New System.Windows.Forms.CheckBox()
        Me.bt_2011 = New System.Windows.Forms.Button()
        Me.bt_2012 = New System.Windows.Forms.Button()
        Me.bt_2013 = New System.Windows.Forms.Button()
        Me.bt_2014 = New System.Windows.Forms.Button()
        Me.btLoadMC = New System.Windows.Forms.Button()
        Me.lbDate = New System.Windows.Forms.Label()
        Me.MonthCalendar1 = New System.Windows.Forms.MonthCalendar()
        Me.btStartRegister = New System.Windows.Forms.Button()
        Me.lbAgent = New System.Windows.Forms.Label()
        Me.lbxAgentList = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tpClient = New System.Windows.Forms.TabPage()
        Me.UcClient1 = New Service.ucClient()
        Me.tpGoods = New System.Windows.Forms.TabPage()
        Me.UcGoodList1 = New Service.ucGoodList()
        Me.tpPayment = New System.Windows.Forms.TabPage()
        Me.UcPaymentDemand1 = New Service.ucPaymentDemand()
        Me.tpTrilboneRegister = New System.Windows.Forms.TabPage()
        Me.tbCtlSamples = New System.Windows.Forms.TabControl()
        Me.TabPage6 = New System.Windows.Forms.TabPage()
        Me.UcTrilboneRegister1 = New Service.ucTrilboneRegister()
        Me.tpMCdocs = New System.Windows.Forms.TabPage()
        Me.UcMCOrder1 = New Service.ucMCOrder()
        Me.tpDeclaration = New System.Windows.Forms.TabPage()
        Me.tbCtlMain.SuspendLayout()
        Me.tpAgentSelect.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpClient.SuspendLayout()
        Me.tpGoods.SuspendLayout()
        Me.tpPayment.SuspendLayout()
        Me.tpTrilboneRegister.SuspendLayout()
        Me.tbCtlSamples.SuspendLayout()
        Me.TabPage6.SuspendLayout()
        Me.tpMCdocs.SuspendLayout()
        Me.SuspendLayout()
        '
        'tbCtlMain
        '
        Me.tbCtlMain.Controls.Add(Me.tpAgentSelect)
        Me.tbCtlMain.Controls.Add(Me.tpClient)
        Me.tbCtlMain.Controls.Add(Me.tpGoods)
        Me.tbCtlMain.Controls.Add(Me.tpPayment)
        Me.tbCtlMain.Controls.Add(Me.tpTrilboneRegister)
        Me.tbCtlMain.Controls.Add(Me.tpMCdocs)
        Me.tbCtlMain.Controls.Add(Me.tpDeclaration)
        Me.tbCtlMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbCtlMain.Location = New System.Drawing.Point(0, 0)
        Me.tbCtlMain.Name = "tbCtlMain"
        Me.tbCtlMain.SelectedIndex = 0
        Me.tbCtlMain.Size = New System.Drawing.Size(738, 441)
        Me.tbCtlMain.TabIndex = 0
        '
        'tpAgentSelect
        '
        Me.tpAgentSelect.Controls.Add(Me.PictureBox1)
        Me.tpAgentSelect.Controls.Add(Me.TextBox1)
        Me.tpAgentSelect.Controls.Add(Me.btSearchSell)
        Me.tpAgentSelect.Controls.Add(Me.cbActiveSellList)
        Me.tpAgentSelect.Controls.Add(Me.btClear)
        Me.tpAgentSelect.Controls.Add(Me.bt_2015)
        Me.tpAgentSelect.Controls.Add(Me.cbxPayment)
        Me.tpAgentSelect.Controls.Add(Me.cbxOrder)
        Me.tpAgentSelect.Controls.Add(Me.cbxDemand)
        Me.tpAgentSelect.Controls.Add(Me.btInPayment)
        Me.tpAgentSelect.Controls.Add(Me.btOrder)
        Me.tpAgentSelect.Controls.Add(Me.btDemand)
        Me.tpAgentSelect.Controls.Add(Me.cbxInMoySklad)
        Me.tpAgentSelect.Controls.Add(Me.bt_2011)
        Me.tpAgentSelect.Controls.Add(Me.bt_2012)
        Me.tpAgentSelect.Controls.Add(Me.bt_2013)
        Me.tpAgentSelect.Controls.Add(Me.bt_2014)
        Me.tpAgentSelect.Controls.Add(Me.btLoadMC)
        Me.tpAgentSelect.Controls.Add(Me.lbDate)
        Me.tpAgentSelect.Controls.Add(Me.MonthCalendar1)
        Me.tpAgentSelect.Controls.Add(Me.btStartRegister)
        Me.tpAgentSelect.Controls.Add(Me.lbAgent)
        Me.tpAgentSelect.Controls.Add(Me.lbxAgentList)
        Me.tpAgentSelect.Controls.Add(Me.Label1)
        Me.tpAgentSelect.Location = New System.Drawing.Point(4, 22)
        Me.tpAgentSelect.Name = "tpAgentSelect"
        Me.tpAgentSelect.Size = New System.Drawing.Size(730, 415)
        Me.tpAgentSelect.TabIndex = 4
        Me.tpAgentSelect.Text = "Место"
        Me.tpAgentSelect.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(581, 235)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(137, 110)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 27
        Me.PictureBox1.TabStop = False
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(333, 235)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(231, 44)
        Me.TextBox1.TabIndex = 26
        '
        'btSearchSell
        '
        Me.btSearchSell.Location = New System.Drawing.Point(9, 235)
        Me.btSearchSell.Name = "btSearchSell"
        Me.btSearchSell.Size = New System.Drawing.Size(312, 23)
        Me.btSearchSell.TabIndex = 25
        Me.btSearchSell.Text = "Запросить неоформленные с места продажи"
        Me.btSearchSell.UseVisualStyleBackColor = True
        '
        'cbActiveSellList
        '
        Me.cbActiveSellList.FormattingEnabled = True
        Me.cbActiveSellList.Location = New System.Drawing.Point(9, 208)
        Me.cbActiveSellList.Name = "cbActiveSellList"
        Me.cbActiveSellList.Size = New System.Drawing.Size(709, 21)
        Me.cbActiveSellList.TabIndex = 24
        '
        'btClear
        '
        Me.btClear.Location = New System.Drawing.Point(590, 171)
        Me.btClear.Name = "btClear"
        Me.btClear.Size = New System.Drawing.Size(128, 31)
        Me.btClear.TabIndex = 23
        Me.btClear.Text = "Очистить"
        Me.btClear.UseVisualStyleBackColor = True
        '
        'bt_2015
        '
        Me.bt_2015.Location = New System.Drawing.Point(657, 113)
        Me.bt_2015.Name = "bt_2015"
        Me.bt_2015.Size = New System.Drawing.Size(61, 23)
        Me.bt_2015.TabIndex = 22
        Me.bt_2015.Text = "2015"
        Me.bt_2015.UseVisualStyleBackColor = True
        '
        'cbxPayment
        '
        Me.cbxPayment.FormattingEnabled = True
        Me.cbxPayment.Location = New System.Drawing.Point(9, 366)
        Me.cbxPayment.Name = "cbxPayment"
        Me.cbxPayment.Size = New System.Drawing.Size(208, 21)
        Me.cbxPayment.TabIndex = 21
        '
        'cbxOrder
        '
        Me.cbxOrder.FormattingEnabled = True
        Me.cbxOrder.Location = New System.Drawing.Point(9, 311)
        Me.cbxOrder.Name = "cbxOrder"
        Me.cbxOrder.Size = New System.Drawing.Size(208, 21)
        Me.cbxOrder.TabIndex = 20
        '
        'cbxDemand
        '
        Me.cbxDemand.FormattingEnabled = True
        Me.cbxDemand.Location = New System.Drawing.Point(9, 338)
        Me.cbxDemand.Name = "cbxDemand"
        Me.cbxDemand.Size = New System.Drawing.Size(208, 21)
        Me.cbxDemand.TabIndex = 19
        '
        'btInPayment
        '
        Me.btInPayment.Location = New System.Drawing.Point(223, 363)
        Me.btInPayment.Name = "btInPayment"
        Me.btInPayment.Size = New System.Drawing.Size(98, 23)
        Me.btInPayment.TabIndex = 18
        Me.btInPayment.Text = "Вх. платеж"
        Me.btInPayment.UseVisualStyleBackColor = True
        '
        'btOrder
        '
        Me.btOrder.Location = New System.Drawing.Point(223, 308)
        Me.btOrder.Name = "btOrder"
        Me.btOrder.Size = New System.Drawing.Size(98, 23)
        Me.btOrder.TabIndex = 16
        Me.btOrder.Text = "Заказ"
        Me.btOrder.UseVisualStyleBackColor = True
        '
        'btDemand
        '
        Me.btDemand.Location = New System.Drawing.Point(223, 336)
        Me.btDemand.Name = "btDemand"
        Me.btDemand.Size = New System.Drawing.Size(98, 23)
        Me.btDemand.TabIndex = 14
        Me.btDemand.Text = "Отгрузка"
        Me.btDemand.UseVisualStyleBackColor = True
        '
        'cbxInMoySklad
        '
        Me.cbxInMoySklad.AutoSize = True
        Me.cbxInMoySklad.Location = New System.Drawing.Point(9, 283)
        Me.cbxInMoySklad.Name = "cbxInMoySklad"
        Me.cbxInMoySklad.Size = New System.Drawing.Size(139, 17)
        Me.cbxInMoySklad.TabIndex = 13
        Me.cbxInMoySklad.Text = "Провести в МойСклад"
        Me.cbxInMoySklad.UseVisualStyleBackColor = True
        '
        'bt_2011
        '
        Me.bt_2011.Location = New System.Drawing.Point(657, 55)
        Me.bt_2011.Name = "bt_2011"
        Me.bt_2011.Size = New System.Drawing.Size(61, 23)
        Me.bt_2011.TabIndex = 12
        Me.bt_2011.Text = "2011"
        Me.bt_2011.UseVisualStyleBackColor = True
        '
        'bt_2012
        '
        Me.bt_2012.Location = New System.Drawing.Point(657, 84)
        Me.bt_2012.Name = "bt_2012"
        Me.bt_2012.Size = New System.Drawing.Size(61, 23)
        Me.bt_2012.TabIndex = 11
        Me.bt_2012.Text = "2012"
        Me.bt_2012.UseVisualStyleBackColor = True
        '
        'bt_2013
        '
        Me.bt_2013.Location = New System.Drawing.Point(590, 55)
        Me.bt_2013.Name = "bt_2013"
        Me.bt_2013.Size = New System.Drawing.Size(61, 23)
        Me.bt_2013.TabIndex = 10
        Me.bt_2013.Text = "2013"
        Me.bt_2013.UseVisualStyleBackColor = True
        '
        'bt_2014
        '
        Me.bt_2014.Location = New System.Drawing.Point(590, 84)
        Me.bt_2014.Name = "bt_2014"
        Me.bt_2014.Size = New System.Drawing.Size(61, 23)
        Me.bt_2014.TabIndex = 9
        Me.bt_2014.Text = "2014"
        Me.bt_2014.UseVisualStyleBackColor = True
        '
        'btLoadMC
        '
        Me.btLoadMC.Location = New System.Drawing.Point(634, 13)
        Me.btLoadMC.Name = "btLoadMC"
        Me.btLoadMC.Size = New System.Drawing.Size(84, 31)
        Me.btLoadMC.TabIndex = 8
        Me.btLoadMC.Text = "Мой Склад"
        Me.btLoadMC.UseVisualStyleBackColor = True
        '
        'lbDate
        '
        Me.lbDate.AutoSize = True
        Me.lbDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lbDate.Location = New System.Drawing.Point(342, 368)
        Me.lbDate.Name = "lbDate"
        Me.lbDate.Size = New System.Drawing.Size(119, 18)
        Me.lbDate.TabIndex = 7
        Me.lbDate.Text = "Выбрано дата"
        '
        'MonthCalendar1
        '
        Me.MonthCalendar1.FirstDayOfWeek = System.Windows.Forms.Day.Monday
        Me.MonthCalendar1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.MonthCalendar1.Location = New System.Drawing.Point(332, 9)
        Me.MonthCalendar1.MaxDate = New Date(2020, 12, 31, 0, 0, 0, 0)
        Me.MonthCalendar1.MaxSelectionCount = 1
        Me.MonthCalendar1.MinDate = New Date(1995, 1, 1, 0, 0, 0, 0)
        Me.MonthCalendar1.Name = "MonthCalendar1"
        Me.MonthCalendar1.TabIndex = 6
        '
        'btStartRegister
        '
        Me.btStartRegister.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btStartRegister.Location = New System.Drawing.Point(524, 351)
        Me.btStartRegister.Name = "btStartRegister"
        Me.btStartRegister.Size = New System.Drawing.Size(194, 51)
        Me.btStartRegister.TabIndex = 3
        Me.btStartRegister.Text = "Оформить.."
        Me.btStartRegister.UseVisualStyleBackColor = True
        '
        'lbAgent
        '
        Me.lbAgent.AutoSize = True
        Me.lbAgent.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lbAgent.Location = New System.Drawing.Point(342, 301)
        Me.lbAgent.Name = "lbAgent"
        Me.lbAgent.Size = New System.Drawing.Size(78, 18)
        Me.lbAgent.TabIndex = 2
        Me.lbAgent.Text = "Выбрано"
        '
        'lbxAgentList
        '
        Me.lbxAgentList.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lbxAgentList.FormattingEnabled = True
        Me.lbxAgentList.ItemHeight = 20
        Me.lbxAgentList.Location = New System.Drawing.Point(9, 38)
        Me.lbxAgentList.Name = "lbxAgentList"
        Me.lbxAgentList.Size = New System.Drawing.Size(312, 164)
        Me.lbxAgentList.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(148, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Доступные места продажи:"
        '
        'tpClient
        '
        Me.tpClient.Controls.Add(Me.UcClient1)
        Me.tpClient.Location = New System.Drawing.Point(4, 22)
        Me.tpClient.Name = "tpClient"
        Me.tpClient.Padding = New System.Windows.Forms.Padding(3)
        Me.tpClient.Size = New System.Drawing.Size(730, 415)
        Me.tpClient.TabIndex = 0
        Me.tpClient.Text = "Клиент"
        Me.tpClient.UseVisualStyleBackColor = True
        '
        'UcClient1
        '
        Me.UcClient1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcClient1.Location = New System.Drawing.Point(3, 3)
        Me.UcClient1.Name = "UcClient1"
        Me.UcClient1.Size = New System.Drawing.Size(724, 409)
        Me.UcClient1.TabIndex = 0
        Me.UcClient1.UserID = ""
        '
        'tpGoods
        '
        Me.tpGoods.Controls.Add(Me.UcGoodList1)
        Me.tpGoods.Location = New System.Drawing.Point(4, 22)
        Me.tpGoods.Name = "tpGoods"
        Me.tpGoods.Padding = New System.Windows.Forms.Padding(3)
        Me.tpGoods.Size = New System.Drawing.Size(730, 415)
        Me.tpGoods.TabIndex = 2
        Me.tpGoods.Text = "Товар(ы)"
        Me.tpGoods.UseVisualStyleBackColor = True
        '
        'UcGoodList1
        '
        Me.UcGoodList1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcGoodList1.Location = New System.Drawing.Point(3, 3)
        Me.UcGoodList1.Name = "UcGoodList1"
        Me.UcGoodList1.Size = New System.Drawing.Size(724, 409)
        Me.UcGoodList1.TabIndex = 0
        '
        'tpPayment
        '
        Me.tpPayment.Controls.Add(Me.UcPaymentDemand1)
        Me.tpPayment.Location = New System.Drawing.Point(4, 22)
        Me.tpPayment.Name = "tpPayment"
        Me.tpPayment.Padding = New System.Windows.Forms.Padding(3)
        Me.tpPayment.Size = New System.Drawing.Size(730, 415)
        Me.tpPayment.TabIndex = 1
        Me.tpPayment.Text = "Платеж"
        Me.tpPayment.UseVisualStyleBackColor = True
        '
        'UcPaymentDemand1
        '
        Me.UcPaymentDemand1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcPaymentDemand1.Location = New System.Drawing.Point(3, 3)
        Me.UcPaymentDemand1.Name = "UcPaymentDemand1"
        Me.UcPaymentDemand1.Size = New System.Drawing.Size(724, 409)
        Me.UcPaymentDemand1.TabIndex = 0
        '
        'tpTrilboneRegister
        '
        Me.tpTrilboneRegister.Controls.Add(Me.tbCtlSamples)
        Me.tpTrilboneRegister.Location = New System.Drawing.Point(4, 22)
        Me.tpTrilboneRegister.Name = "tpTrilboneRegister"
        Me.tpTrilboneRegister.Padding = New System.Windows.Forms.Padding(3)
        Me.tpTrilboneRegister.Size = New System.Drawing.Size(730, 415)
        Me.tpTrilboneRegister.TabIndex = 3
        Me.tpTrilboneRegister.Text = "роспись"
        Me.tpTrilboneRegister.UseVisualStyleBackColor = True
        '
        'tbCtlSamples
        '
        Me.tbCtlSamples.Controls.Add(Me.TabPage6)
        Me.tbCtlSamples.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbCtlSamples.Location = New System.Drawing.Point(3, 3)
        Me.tbCtlSamples.Name = "tbCtlSamples"
        Me.tbCtlSamples.SelectedIndex = 0
        Me.tbCtlSamples.Size = New System.Drawing.Size(724, 409)
        Me.tbCtlSamples.TabIndex = 0
        '
        'TabPage6
        '
        Me.TabPage6.Controls.Add(Me.UcTrilboneRegister1)
        Me.TabPage6.Location = New System.Drawing.Point(4, 22)
        Me.TabPage6.Name = "TabPage6"
        Me.TabPage6.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage6.Size = New System.Drawing.Size(716, 383)
        Me.TabPage6.TabIndex = 1
        Me.TabPage6.Text = "8-659"
        Me.TabPage6.UseVisualStyleBackColor = True
        '
        'UcTrilboneRegister1
        '
        Me.UcTrilboneRegister1.Location = New System.Drawing.Point(3, 6)
        Me.UcTrilboneRegister1.Name = "UcTrilboneRegister1"
        Me.UcTrilboneRegister1.Size = New System.Drawing.Size(696, 347)
        Me.UcTrilboneRegister1.TabIndex = 0
        '
        'tpMCdocs
        '
        Me.tpMCdocs.Controls.Add(Me.UcMCOrder1)
        Me.tpMCdocs.Location = New System.Drawing.Point(4, 22)
        Me.tpMCdocs.Name = "tpMCdocs"
        Me.tpMCdocs.Padding = New System.Windows.Forms.Padding(3)
        Me.tpMCdocs.Size = New System.Drawing.Size(730, 415)
        Me.tpMCdocs.TabIndex = 6
        Me.tpMCdocs.Text = "Документы"
        Me.tpMCdocs.UseVisualStyleBackColor = True
        '
        'UcMCOrder1
        '
        Me.UcMCOrder1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcMCOrder1.Location = New System.Drawing.Point(3, 3)
        Me.UcMCOrder1.Name = "UcMCOrder1"
        Me.UcMCOrder1.Size = New System.Drawing.Size(724, 409)
        Me.UcMCOrder1.TabIndex = 0
        '
        'tpDeclaration
        '
        Me.tpDeclaration.Location = New System.Drawing.Point(4, 22)
        Me.tpDeclaration.Name = "tpDeclaration"
        Me.tpDeclaration.Padding = New System.Windows.Forms.Padding(3)
        Me.tpDeclaration.Size = New System.Drawing.Size(730, 415)
        Me.tpDeclaration.TabIndex = 5
        Me.tpDeclaration.Text = "Декларация"
        Me.tpDeclaration.UseVisualStyleBackColor = True
        '
        'ucSellGood
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.tbCtlMain)
        Me.Name = "ucSellGood"
        Me.Size = New System.Drawing.Size(738, 441)
        Me.tbCtlMain.ResumeLayout(False)
        Me.tpAgentSelect.ResumeLayout(False)
        Me.tpAgentSelect.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpClient.ResumeLayout(False)
        Me.tpGoods.ResumeLayout(False)
        Me.tpPayment.ResumeLayout(False)
        Me.tpTrilboneRegister.ResumeLayout(False)
        Me.tbCtlSamples.ResumeLayout(False)
        Me.TabPage6.ResumeLayout(False)
        Me.tpMCdocs.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tbCtlMain As System.Windows.Forms.TabControl
    Friend WithEvents tpClient As System.Windows.Forms.TabPage
    Friend WithEvents UcClient1 As Service.ucClient
    Friend WithEvents tpPayment As System.Windows.Forms.TabPage
    Friend WithEvents UcPaymentDemand1 As Service.ucPaymentDemand
    Friend WithEvents tpGoods As System.Windows.Forms.TabPage
    Friend WithEvents UcGoodList1 As Service.ucGoodList
    Friend WithEvents tpTrilboneRegister As System.Windows.Forms.TabPage
    Friend WithEvents tbCtlSamples As System.Windows.Forms.TabControl
    Friend WithEvents TabPage6 As System.Windows.Forms.TabPage
    Friend WithEvents UcTrilboneRegister1 As Service.ucTrilboneRegister
    Friend WithEvents tpAgentSelect As System.Windows.Forms.TabPage
    Friend WithEvents lbDate As System.Windows.Forms.Label
    Friend WithEvents MonthCalendar1 As System.Windows.Forms.MonthCalendar
    Friend WithEvents btStartRegister As System.Windows.Forms.Button
    Friend WithEvents lbAgent As System.Windows.Forms.Label
    Friend WithEvents lbxAgentList As System.Windows.Forms.ListBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btLoadMC As System.Windows.Forms.Button
    Friend WithEvents bt_2011 As System.Windows.Forms.Button
    Friend WithEvents bt_2012 As System.Windows.Forms.Button
    Friend WithEvents bt_2013 As System.Windows.Forms.Button
    Friend WithEvents bt_2014 As System.Windows.Forms.Button
    Friend WithEvents btInPayment As System.Windows.Forms.Button
    Friend WithEvents btOrder As System.Windows.Forms.Button
    Friend WithEvents btDemand As System.Windows.Forms.Button
    Friend WithEvents cbxInMoySklad As System.Windows.Forms.CheckBox
    Friend WithEvents cbxPayment As System.Windows.Forms.ComboBox
    Friend WithEvents cbxOrder As System.Windows.Forms.ComboBox
    Friend WithEvents cbxDemand As System.Windows.Forms.ComboBox
    Friend WithEvents tpDeclaration As System.Windows.Forms.TabPage
    Friend WithEvents bt_2015 As System.Windows.Forms.Button
    Friend WithEvents btClear As System.Windows.Forms.Button
    Friend WithEvents tpMCdocs As System.Windows.Forms.TabPage
    Friend WithEvents UcMCOrder1 As Service.ucMCOrder
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents btSearchSell As System.Windows.Forms.Button
    Friend WithEvents cbActiveSellList As System.Windows.Forms.ComboBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox

End Class
