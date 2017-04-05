<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uc_lot
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
        Me.tbLotArticulBase = New System.Windows.Forms.TextBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.tbLotTotalQTY = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.cbLotUom = New System.Windows.Forms.ComboBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.btPrintCategoryLabels = New System.Windows.Forms.Button()
        Me.cbxPrintAllLabels = New System.Windows.Forms.CheckBox()
        Me.btAddCategory = New System.Windows.Forms.Button()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.cbxLossRemains = New System.Windows.Forms.CheckBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.cbxLotNormalizeCat5 = New System.Windows.Forms.CheckBox()
        Me.cbLotCurrency = New System.Windows.Forms.ComboBox()
        Me.BtGetLotInfo = New System.Windows.Forms.Button()
        Me.tbLotQTYCat5 = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tbLotTotalAmount = New System.Windows.Forms.TextBox()
        Me.tbLotQTYcat1 = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.tbLotCourceToRetailCurr = New System.Windows.Forms.TextBox()
        Me.tbLotMaxPriceCat5 = New System.Windows.Forms.TextBox()
        Me.cbLotRetailCurrency = New System.Windows.Forms.ComboBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.tbLotMinPriceCat1 = New System.Windows.Forms.TextBox()
        Me.cbRetailUom = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btEnteringLot = New System.Windows.Forms.Button()
        Me.btRequestLotMS = New System.Windows.Forms.Button()
        Me.dgvLot = New System.Windows.Forms.DataGridView()
        Me.GroupBox4.SuspendLayout()
        CType(Me.dgvLot, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tbLotArticulBase
        '
        Me.tbLotArticulBase.Location = New System.Drawing.Point(235, 9)
        Me.tbLotArticulBase.Margin = New System.Windows.Forms.Padding(4)
        Me.tbLotArticulBase.Name = "tbLotArticulBase"
        Me.tbLotArticulBase.Size = New System.Drawing.Size(81, 22)
        Me.tbLotArticulBase.TabIndex = 49
        Me.tbLotArticulBase.TabStop = False
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(131, 13)
        Me.Label30.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(97, 17)
        Me.Label30.TabIndex = 48
        Me.Label30.Text = "Артикул лота"
        '
        'tbLotTotalQTY
        '
        Me.tbLotTotalQTY.Location = New System.Drawing.Point(438, 9)
        Me.tbLotTotalQTY.Margin = New System.Windows.Forms.Padding(4)
        Me.tbLotTotalQTY.Name = "tbLotTotalQTY"
        Me.tbLotTotalQTY.Size = New System.Drawing.Size(48, 22)
        Me.tbLotTotalQTY.TabIndex = 47
        Me.tbLotTotalQTY.TabStop = False
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(334, 13)
        Me.Label29.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(91, 17)
        Me.Label29.TabIndex = 46
        Me.Label29.Text = "Всего в лоте"
        '
        'cbLotUom
        '
        Me.cbLotUom.FormattingEnabled = True
        Me.cbLotUom.Location = New System.Drawing.Point(604, 9)
        Me.cbLotUom.Margin = New System.Windows.Forms.Padding(4)
        Me.cbLotUom.Name = "cbLotUom"
        Me.cbLotUom.Size = New System.Drawing.Size(63, 24)
        Me.cbLotUom.TabIndex = 45
        Me.cbLotUom.TabStop = False
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(502, 13)
        Me.Label28.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(91, 17)
        Me.Label28.TabIndex = 44
        Me.Label28.Text = "ед. изм лота"
        '
        'btPrintCategoryLabels
        '
        Me.btPrintCategoryLabels.Location = New System.Drawing.Point(604, 358)
        Me.btPrintCategoryLabels.Margin = New System.Windows.Forms.Padding(4)
        Me.btPrintCategoryLabels.Name = "btPrintCategoryLabels"
        Me.btPrintCategoryLabels.Size = New System.Drawing.Size(263, 28)
        Me.btPrintCategoryLabels.TabIndex = 43
        Me.btPrintCategoryLabels.TabStop = False
        Me.btPrintCategoryLabels.Text = "Печатать комплект для категории"
        Me.btPrintCategoryLabels.UseVisualStyleBackColor = True
        '
        'cbxPrintAllLabels
        '
        Me.cbxPrintAllLabels.AutoSize = True
        Me.cbxPrintAllLabels.Location = New System.Drawing.Point(615, 329)
        Me.cbxPrintAllLabels.Margin = New System.Windows.Forms.Padding(4)
        Me.cbxPrintAllLabels.Name = "cbxPrintAllLabels"
        Me.cbxPrintAllLabels.Size = New System.Drawing.Size(222, 21)
        Me.cbxPrintAllLabels.TabIndex = 42
        Me.cbxPrintAllLabels.TabStop = False
        Me.cbxPrintAllLabels.Text = "Печатать комплект этикеток"
        Me.cbxPrintAllLabels.UseVisualStyleBackColor = True
        '
        'btAddCategory
        '
        Me.btAddCategory.Location = New System.Drawing.Point(6, 324)
        Me.btAddCategory.Margin = New System.Windows.Forms.Padding(4)
        Me.btAddCategory.Name = "btAddCategory"
        Me.btAddCategory.Size = New System.Drawing.Size(59, 28)
        Me.btAddCategory.TabIndex = 41
        Me.btAddCategory.TabStop = False
        Me.btAddCategory.Text = "+ кат."
        Me.btAddCategory.UseVisualStyleBackColor = True
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(22, 382)
        Me.Label26.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(485, 17)
        Me.Label26.TabIndex = 40
        Me.Label26.Text = "Раскидывает лот по категориям, за общий принимается текущий товар"
        '
        'cbxLossRemains
        '
        Me.cbxLossRemains.AutoSize = True
        Me.cbxLossRemains.Location = New System.Drawing.Point(300, 329)
        Me.cbxLossRemains.Margin = New System.Windows.Forms.Padding(4)
        Me.cbxLossRemains.Name = "cbxLossRemains"
        Me.cbxLossRemains.Size = New System.Drawing.Size(280, 21)
        Me.cbxLossRemains.TabIndex = 39
        Me.cbxLossRemains.TabStop = False
        Me.cbxLossRemains.Text = "Списать остаток после приходования"
        Me.cbxLossRemains.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label27)
        Me.GroupBox4.Controls.Add(Me.cbxLotNormalizeCat5)
        Me.GroupBox4.Controls.Add(Me.cbLotCurrency)
        Me.GroupBox4.Controls.Add(Me.BtGetLotInfo)
        Me.GroupBox4.Controls.Add(Me.tbLotQTYCat5)
        Me.GroupBox4.Controls.Add(Me.Label25)
        Me.GroupBox4.Controls.Add(Me.Label6)
        Me.GroupBox4.Controls.Add(Me.tbLotTotalAmount)
        Me.GroupBox4.Controls.Add(Me.tbLotQTYcat1)
        Me.GroupBox4.Controls.Add(Me.Label24)
        Me.GroupBox4.Controls.Add(Me.Label17)
        Me.GroupBox4.Controls.Add(Me.tbLotCourceToRetailCurr)
        Me.GroupBox4.Controls.Add(Me.tbLotMaxPriceCat5)
        Me.GroupBox4.Controls.Add(Me.cbLotRetailCurrency)
        Me.GroupBox4.Controls.Add(Me.Label23)
        Me.GroupBox4.Controls.Add(Me.Label22)
        Me.GroupBox4.Controls.Add(Me.tbLotMinPriceCat1)
        Me.GroupBox4.Location = New System.Drawing.Point(892, 35)
        Me.GroupBox4.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox4.Size = New System.Drawing.Size(267, 373)
        Me.GroupBox4.TabIndex = 38
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Прогноз"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(24, 107)
        Me.Label27.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(119, 17)
        Me.Label27.TabIndex = 22
        Me.Label27.Text = "Валюта розницы"
        '
        'cbxLotNormalizeCat5
        '
        Me.cbxLotNormalizeCat5.AutoSize = True
        Me.cbxLotNormalizeCat5.Location = New System.Drawing.Point(65, 277)
        Me.cbxLotNormalizeCat5.Margin = New System.Windows.Forms.Padding(4)
        Me.cbxLotNormalizeCat5.Name = "cbxLotNormalizeCat5"
        Me.cbxLotNormalizeCat5.Size = New System.Drawing.Size(135, 21)
        Me.cbxLotNormalizeCat5.TabIndex = 21
        Me.cbxLotNormalizeCat5.TabStop = False
        Me.cbxLotNormalizeCat5.Text = "Нормализовано"
        Me.cbxLotNormalizeCat5.UseVisualStyleBackColor = True
        '
        'cbLotCurrency
        '
        Me.cbLotCurrency.FormattingEnabled = True
        Me.cbLotCurrency.Location = New System.Drawing.Point(155, 39)
        Me.cbLotCurrency.Margin = New System.Windows.Forms.Padding(4)
        Me.cbLotCurrency.Name = "cbLotCurrency"
        Me.cbLotCurrency.Size = New System.Drawing.Size(68, 24)
        Me.cbLotCurrency.TabIndex = 8
        Me.cbLotCurrency.TabStop = False
        '
        'BtGetLotInfo
        '
        Me.BtGetLotInfo.Location = New System.Drawing.Point(49, 335)
        Me.BtGetLotInfo.Margin = New System.Windows.Forms.Padding(4)
        Me.BtGetLotInfo.Name = "BtGetLotInfo"
        Me.BtGetLotInfo.Size = New System.Drawing.Size(183, 28)
        Me.BtGetLotInfo.TabIndex = 5
        Me.BtGetLotInfo.TabStop = False
        Me.BtGetLotInfo.Text = "Рассчитать лот"
        Me.BtGetLotInfo.UseVisualStyleBackColor = True
        '
        'tbLotQTYCat5
        '
        Me.tbLotQTYCat5.Location = New System.Drawing.Point(155, 303)
        Me.tbLotQTYCat5.Margin = New System.Windows.Forms.Padding(4)
        Me.tbLotQTYCat5.Name = "tbLotQTYCat5"
        Me.tbLotQTYCat5.Size = New System.Drawing.Size(56, 22)
        Me.tbLotQTYCat5.TabIndex = 20
        Me.tbLotQTYCat5.TabStop = False
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(53, 306)
        Me.Label25.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(91, 17)
        Me.Label25.TabIndex = 19
        Me.Label25.Text = "Кол-во кат.5"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(40, 21)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(134, 17)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Цена закупки лота"
        '
        'tbLotTotalAmount
        '
        Me.tbLotTotalAmount.Location = New System.Drawing.Point(44, 41)
        Me.tbLotTotalAmount.Margin = New System.Windows.Forms.Padding(4)
        Me.tbLotTotalAmount.Name = "tbLotTotalAmount"
        Me.tbLotTotalAmount.Size = New System.Drawing.Size(101, 22)
        Me.tbLotTotalAmount.TabIndex = 7
        Me.tbLotTotalAmount.TabStop = False
        '
        'tbLotQTYcat1
        '
        Me.tbLotQTYcat1.Location = New System.Drawing.Point(155, 247)
        Me.tbLotQTYcat1.Margin = New System.Windows.Forms.Padding(4)
        Me.tbLotQTYcat1.Name = "tbLotQTYcat1"
        Me.tbLotQTYcat1.Size = New System.Drawing.Size(56, 22)
        Me.tbLotQTYcat1.TabIndex = 18
        Me.tbLotQTYcat1.TabStop = False
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(53, 251)
        Me.Label24.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(91, 17)
        Me.Label24.TabIndex = 17
        Me.Label24.Text = "Кол-во кат.1"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(95, 76)
        Me.Label17.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(39, 17)
        Me.Label17.TabIndex = 9
        Me.Label17.Text = "Курс"
        '
        'tbLotCourceToRetailCurr
        '
        Me.tbLotCourceToRetailCurr.Location = New System.Drawing.Point(148, 71)
        Me.tbLotCourceToRetailCurr.Margin = New System.Windows.Forms.Padding(4)
        Me.tbLotCourceToRetailCurr.Name = "tbLotCourceToRetailCurr"
        Me.tbLotCourceToRetailCurr.Size = New System.Drawing.Size(76, 22)
        Me.tbLotCourceToRetailCurr.TabIndex = 10
        Me.tbLotCourceToRetailCurr.TabStop = False
        '
        'tbLotMaxPriceCat5
        '
        Me.tbLotMaxPriceCat5.Location = New System.Drawing.Point(49, 217)
        Me.tbLotMaxPriceCat5.Margin = New System.Windows.Forms.Padding(4)
        Me.tbLotMaxPriceCat5.Name = "tbLotMaxPriceCat5"
        Me.tbLotMaxPriceCat5.Size = New System.Drawing.Size(101, 22)
        Me.tbLotMaxPriceCat5.TabIndex = 15
        Me.tbLotMaxPriceCat5.TabStop = False
        '
        'cbLotRetailCurrency
        '
        Me.cbLotRetailCurrency.FormattingEnabled = True
        Me.cbLotRetailCurrency.Location = New System.Drawing.Point(155, 103)
        Me.cbLotRetailCurrency.Margin = New System.Windows.Forms.Padding(4)
        Me.cbLotRetailCurrency.Name = "cbLotRetailCurrency"
        Me.cbLotRetailCurrency.Size = New System.Drawing.Size(68, 24)
        Me.cbLotRetailCurrency.TabIndex = 13
        Me.cbLotRetailCurrency.TabStop = False
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(45, 197)
        Me.Label23.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(167, 17)
        Me.Label23.TabIndex = 14
        Me.Label23.Text = "Макс. розн. цена - кат.5"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(45, 146)
        Me.Label22.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(161, 17)
        Me.Label22.TabIndex = 11
        Me.Label22.Text = "Мин. розн. цена - кат.1"
        '
        'tbLotMinPriceCat1
        '
        Me.tbLotMinPriceCat1.Location = New System.Drawing.Point(49, 166)
        Me.tbLotMinPriceCat1.Margin = New System.Windows.Forms.Padding(4)
        Me.tbLotMinPriceCat1.Name = "tbLotMinPriceCat1"
        Me.tbLotMinPriceCat1.Size = New System.Drawing.Size(101, 22)
        Me.tbLotMinPriceCat1.TabIndex = 12
        Me.tbLotMinPriceCat1.TabStop = False
        '
        'cbRetailUom
        '
        Me.cbRetailUom.FormattingEnabled = True
        Me.cbRetailUom.Location = New System.Drawing.Point(820, 11)
        Me.cbRetailUom.Margin = New System.Windows.Forms.Padding(4)
        Me.cbRetailUom.Name = "cbRetailUom"
        Me.cbRetailUom.Size = New System.Drawing.Size(63, 24)
        Me.cbRetailUom.TabIndex = 37
        Me.cbRetailUom.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(679, 14)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(127, 17)
        Me.Label5.TabIndex = 36
        Me.Label5.Text = "ед. изм категорий"
        '
        'btEnteringLot
        '
        Me.btEnteringLot.Location = New System.Drawing.Point(107, 324)
        Me.btEnteringLot.Margin = New System.Windows.Forms.Padding(4)
        Me.btEnteringLot.Name = "btEnteringLot"
        Me.btEnteringLot.Size = New System.Drawing.Size(159, 28)
        Me.btEnteringLot.TabIndex = 35
        Me.btEnteringLot.TabStop = False
        Me.btEnteringLot.Text = "Приходовать лот"
        Me.btEnteringLot.UseVisualStyleBackColor = True
        '
        'btRequestLotMS
        '
        Me.btRequestLotMS.Location = New System.Drawing.Point(6, 6)
        Me.btRequestLotMS.Margin = New System.Windows.Forms.Padding(4)
        Me.btRequestLotMS.Name = "btRequestLotMS"
        Me.btRequestLotMS.Size = New System.Drawing.Size(117, 28)
        Me.btRequestLotMS.TabIndex = 34
        Me.btRequestLotMS.TabStop = False
        Me.btRequestLotMS.Text = "Запросить"
        Me.btRequestLotMS.UseVisualStyleBackColor = True
        '
        'dgvLot
        '
        Me.dgvLot.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvLot.Location = New System.Drawing.Point(6, 44)
        Me.dgvLot.Margin = New System.Windows.Forms.Padding(4)
        Me.dgvLot.Name = "dgvLot"
        Me.dgvLot.Size = New System.Drawing.Size(861, 272)
        Me.dgvLot.TabIndex = 33
        '
        'uc_lot
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.tbLotArticulBase)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.tbLotTotalQTY)
        Me.Controls.Add(Me.Label29)
        Me.Controls.Add(Me.cbLotUom)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.btPrintCategoryLabels)
        Me.Controls.Add(Me.cbxPrintAllLabels)
        Me.Controls.Add(Me.btAddCategory)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.cbxLossRemains)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.cbRetailUom)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.btEnteringLot)
        Me.Controls.Add(Me.btRequestLotMS)
        Me.Controls.Add(Me.dgvLot)
        Me.Name = "uc_lot"
        Me.Size = New System.Drawing.Size(1183, 457)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.dgvLot, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tbLotArticulBase As System.Windows.Forms.TextBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents tbLotTotalQTY As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents cbLotUom As System.Windows.Forms.ComboBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents btPrintCategoryLabels As System.Windows.Forms.Button
    Friend WithEvents cbxPrintAllLabels As System.Windows.Forms.CheckBox
    Friend WithEvents btAddCategory As System.Windows.Forms.Button
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents cbxLossRemains As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents cbxLotNormalizeCat5 As System.Windows.Forms.CheckBox
    Friend WithEvents cbLotCurrency As System.Windows.Forms.ComboBox
    Friend WithEvents BtGetLotInfo As System.Windows.Forms.Button
    Friend WithEvents tbLotQTYCat5 As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents tbLotTotalAmount As System.Windows.Forms.TextBox
    Friend WithEvents tbLotQTYcat1 As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents tbLotCourceToRetailCurr As System.Windows.Forms.TextBox
    Friend WithEvents tbLotMaxPriceCat5 As System.Windows.Forms.TextBox
    Friend WithEvents cbLotRetailCurrency As System.Windows.Forms.ComboBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents tbLotMinPriceCat1 As System.Windows.Forms.TextBox
    Friend WithEvents cbRetailUom As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btEnteringLot As System.Windows.Forms.Button
    Friend WithEvents btRequestLotMS As System.Windows.Forms.Button
    Friend WithEvents dgvLot As System.Windows.Forms.DataGridView

End Class
