<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucTrilboneRegister
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
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.tbCalcTotalPerOne = New System.Windows.Forms.TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.btPersonCalc = New System.Windows.Forms.Button()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.tbPersonCount = New System.Windows.Forms.TextBox()
        Me.btGetResorceFee = New System.Windows.Forms.Button()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.tbCalcTotal = New System.Windows.Forms.TextBox()
        Me.btTotal = New System.Windows.Forms.Button()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.tbSubTotal = New System.Windows.Forms.TextBox()
        Me.btSubTotal = New System.Windows.Forms.Button()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.tbFullAmount = New System.Windows.Forms.TextBox()
        Me.btWeightCalculate = New System.Windows.Forms.Button()
        Me.btMoneyOutCalculate = New System.Windows.Forms.Button()
        Me.btTrilboneCalculate = New System.Windows.Forms.Button()
        Me.btNalogCalculate = New System.Windows.Forms.Button()
        Me.tbTrilboneBase = New System.Windows.Forms.TextBox()
        Me.tbNalogBase = New System.Windows.Forms.TextBox()
        Me.tbMoneyOutBase = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.tbTrilboneTax = New System.Windows.Forms.TextBox()
        Me.tbNalogTax = New System.Windows.Forms.TextBox()
        Me.tbWeightTax = New System.Windows.Forms.TextBox()
        Me.tbWeight = New System.Windows.Forms.TextBox()
        Me.tbMoneyOutTax = New System.Windows.Forms.TextBox()
        Me.btWeightQuery = New System.Windows.Forms.Button()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.btGetFullAmount = New System.Windows.Forms.Button()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.btShipmentOutFee = New System.Windows.Forms.Button()
        Me.tbTrilboneFee = New System.Windows.Forms.TextBox()
        Me.tbNalogFee = New System.Windows.Forms.TextBox()
        Me.tbShipmentOutFee = New System.Windows.Forms.TextBox()
        Me.tbExportFee = New System.Windows.Forms.TextBox()
        Me.tbInsectionFee = New System.Windows.Forms.TextBox()
        Me.tbMoneyOutFee = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.btSaveInDb = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbWokerAdd = New System.Windows.Forms.ComboBox()
        Me.btCreatePayment = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(81, 127)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(134, 13)
        Me.Label35.TabIndex = 109
        Me.Label35.Text = "*вес нетто, без упаковки"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(368, 79)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(249, 13)
        Me.Label34.TabIndex = 108
        Me.Label34.Text = "*стоимость, записанная при отправке посылки"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(363, 46)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(326, 13)
        Me.Label33.TabIndex = 107
        Me.Label33.Text = "*суммируются все выстановочные fee в истории предложений"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(6, 0)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(219, 13)
        Me.Label32.TabIndex = 106
        Me.Label32.Text = "Оформляется после оплаты и отправки!!!"
        '
        'tbCalcTotalPerOne
        '
        Me.tbCalcTotalPerOne.Location = New System.Drawing.Point(199, 286)
        Me.tbCalcTotalPerOne.Name = "tbCalcTotalPerOne"
        Me.tbCalcTotalPerOne.Size = New System.Drawing.Size(52, 20)
        Me.tbCalcTotalPerOne.TabIndex = 105
        Me.tbCalcTotalPerOne.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(70, 290)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(121, 13)
        Me.Label31.TabIndex = 104
        Me.Label31.Text = "На каждого дольщика"
        '
        'btPersonCalc
        '
        Me.btPersonCalc.Location = New System.Drawing.Point(342, 285)
        Me.btPersonCalc.Name = "btPersonCalc"
        Me.btPersonCalc.Size = New System.Drawing.Size(75, 23)
        Me.btPersonCalc.TabIndex = 103
        Me.btPersonCalc.Text = "рассчет"
        Me.btPersonCalc.UseVisualStyleBackColor = True
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(262, 290)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(40, 13)
        Me.Label30.TabIndex = 102
        Me.Label30.Text = "Долей"
        '
        'tbPersonCount
        '
        Me.tbPersonCount.Location = New System.Drawing.Point(308, 286)
        Me.tbPersonCount.Name = "tbPersonCount"
        Me.tbPersonCount.Size = New System.Drawing.Size(23, 20)
        Me.tbPersonCount.TabIndex = 101
        Me.tbPersonCount.Text = "1"
        Me.tbPersonCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btGetResorceFee
        '
        Me.btGetResorceFee.Location = New System.Drawing.Point(282, 41)
        Me.btGetResorceFee.Name = "btGetResorceFee"
        Me.btGetResorceFee.Size = New System.Drawing.Size(75, 23)
        Me.btGetResorceFee.TabIndex = 100
        Me.btGetResorceFee.Text = "получить"
        Me.btGetResorceFee.UseVisualStyleBackColor = True
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(260, 264)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(132, 13)
        Me.Label29.TabIndex = 99
        Me.Label29.Text = "*после вычета % Trilbone"
        '
        'tbCalcTotal
        '
        Me.tbCalcTotal.Location = New System.Drawing.Point(201, 261)
        Me.tbCalcTotal.Name = "tbCalcTotal"
        Me.tbCalcTotal.Size = New System.Drawing.Size(52, 20)
        Me.tbCalcTotal.TabIndex = 98
        Me.tbCalcTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btTotal
        '
        Me.btTotal.Location = New System.Drawing.Point(21, 259)
        Me.btTotal.Name = "btTotal"
        Me.btTotal.Size = New System.Drawing.Size(171, 23)
        Me.btTotal.TabIndex = 97
        Me.btTotal.Text = "для выплаты дольщикам"
        Me.btTotal.UseVisualStyleBackColor = True
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(282, 209)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(156, 13)
        Me.Label28.TabIndex = 96
        Me.Label28.Text = "*после вычета всех расходов"
        '
        'tbSubTotal
        '
        Me.tbSubTotal.Location = New System.Drawing.Point(223, 206)
        Me.tbSubTotal.Name = "tbSubTotal"
        Me.tbSubTotal.Size = New System.Drawing.Size(52, 20)
        Me.tbSubTotal.TabIndex = 95
        Me.tbSubTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btSubTotal
        '
        Me.btSubTotal.Location = New System.Drawing.Point(89, 204)
        Me.btSubTotal.Name = "btSubTotal"
        Me.btSubTotal.Size = New System.Drawing.Size(125, 23)
        Me.btSubTotal.TabIndex = 94
        Me.btSubTotal.Text = "налик после вычетов"
        Me.btSubTotal.UseVisualStyleBackColor = True
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(199, 22)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(224, 13)
        Me.Label27.TabIndex = 93
        Me.Label27.Text = "Всего получено денег (счет, PayPal, налик)"
        '
        'tbFullAmount
        '
        Me.tbFullAmount.Location = New System.Drawing.Point(141, 19)
        Me.tbFullAmount.Name = "tbFullAmount"
        Me.tbFullAmount.Size = New System.Drawing.Size(52, 20)
        Me.tbFullAmount.TabIndex = 92
        Me.tbFullAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btWeightCalculate
        '
        Me.btWeightCalculate.Location = New System.Drawing.Point(561, 109)
        Me.btWeightCalculate.Name = "btWeightCalculate"
        Me.btWeightCalculate.Size = New System.Drawing.Size(75, 23)
        Me.btWeightCalculate.TabIndex = 91
        Me.btWeightCalculate.Text = "рассчет"
        Me.btWeightCalculate.UseVisualStyleBackColor = True
        '
        'btMoneyOutCalculate
        '
        Me.btMoneyOutCalculate.Location = New System.Drawing.Point(515, 146)
        Me.btMoneyOutCalculate.Name = "btMoneyOutCalculate"
        Me.btMoneyOutCalculate.Size = New System.Drawing.Size(75, 23)
        Me.btMoneyOutCalculate.TabIndex = 90
        Me.btMoneyOutCalculate.Text = "рассчет"
        Me.btMoneyOutCalculate.UseVisualStyleBackColor = True
        '
        'btTrilboneCalculate
        '
        Me.btTrilboneCalculate.Location = New System.Drawing.Point(542, 230)
        Me.btTrilboneCalculate.Name = "btTrilboneCalculate"
        Me.btTrilboneCalculate.Size = New System.Drawing.Size(75, 23)
        Me.btTrilboneCalculate.TabIndex = 89
        Me.btTrilboneCalculate.Text = "рассчет"
        Me.btTrilboneCalculate.UseVisualStyleBackColor = True
        '
        'btNalogCalculate
        '
        Me.btNalogCalculate.Location = New System.Drawing.Point(515, 175)
        Me.btNalogCalculate.Name = "btNalogCalculate"
        Me.btNalogCalculate.Size = New System.Drawing.Size(75, 23)
        Me.btNalogCalculate.TabIndex = 88
        Me.btNalogCalculate.Text = "рассчет"
        Me.btNalogCalculate.UseVisualStyleBackColor = True
        '
        'tbTrilboneBase
        '
        Me.tbTrilboneBase.Location = New System.Drawing.Point(474, 231)
        Me.tbTrilboneBase.Name = "tbTrilboneBase"
        Me.tbTrilboneBase.Size = New System.Drawing.Size(52, 20)
        Me.tbTrilboneBase.TabIndex = 87
        Me.tbTrilboneBase.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbNalogBase
        '
        Me.tbNalogBase.Location = New System.Drawing.Point(447, 176)
        Me.tbNalogBase.Name = "tbNalogBase"
        Me.tbNalogBase.Size = New System.Drawing.Size(52, 20)
        Me.tbNalogBase.TabIndex = 86
        Me.tbNalogBase.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbMoneyOutBase
        '
        Me.tbMoneyOutBase.Location = New System.Drawing.Point(447, 147)
        Me.tbMoneyOutBase.Name = "tbMoneyOutBase"
        Me.tbMoneyOutBase.Size = New System.Drawing.Size(52, 20)
        Me.tbMoneyOutBase.TabIndex = 85
        Me.tbMoneyOutBase.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(385, 151)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(56, 13)
        Me.Label26.TabIndex = 84
        Me.Label26.Text = "от суммы"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(385, 180)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(56, 13)
        Me.Label25.TabIndex = 83
        Me.Label25.Text = "от суммы"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(412, 235)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(56, 13)
        Me.Label24.TabIndex = 82
        Me.Label24.Text = "от суммы"
        '
        'tbTrilboneTax
        '
        Me.tbTrilboneTax.Location = New System.Drawing.Point(379, 231)
        Me.tbTrilboneTax.Name = "tbTrilboneTax"
        Me.tbTrilboneTax.Size = New System.Drawing.Size(27, 20)
        Me.tbTrilboneTax.TabIndex = 81
        Me.tbTrilboneTax.Text = "30"
        Me.tbTrilboneTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbNalogTax
        '
        Me.tbNalogTax.Location = New System.Drawing.Point(352, 176)
        Me.tbNalogTax.Name = "tbNalogTax"
        Me.tbNalogTax.Size = New System.Drawing.Size(27, 20)
        Me.tbNalogTax.TabIndex = 80
        Me.tbNalogTax.Text = "7"
        Me.tbNalogTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbWeightTax
        '
        Me.tbWeightTax.Location = New System.Drawing.Point(520, 110)
        Me.tbWeightTax.Name = "tbWeightTax"
        Me.tbWeightTax.Size = New System.Drawing.Size(27, 20)
        Me.tbWeightTax.TabIndex = 79
        Me.tbWeightTax.Text = "12"
        Me.tbWeightTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbWeight
        '
        Me.tbWeight.Location = New System.Drawing.Point(385, 110)
        Me.tbWeight.Name = "tbWeight"
        Me.tbWeight.Size = New System.Drawing.Size(27, 20)
        Me.tbWeight.TabIndex = 78
        Me.tbWeight.Text = "1"
        Me.tbWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbMoneyOutTax
        '
        Me.tbMoneyOutTax.Location = New System.Drawing.Point(352, 147)
        Me.tbMoneyOutTax.Name = "tbMoneyOutTax"
        Me.tbMoneyOutTax.Size = New System.Drawing.Size(27, 20)
        Me.tbMoneyOutTax.TabIndex = 77
        Me.tbMoneyOutTax.Text = "5"
        Me.tbMoneyOutTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btWeightQuery
        '
        Me.btWeightQuery.Location = New System.Drawing.Point(283, 109)
        Me.btWeightQuery.Name = "btWeightQuery"
        Me.btWeightQuery.Size = New System.Drawing.Size(96, 23)
        Me.btWeightQuery.TabIndex = 76
        Me.btWeightQuery.Text = "получить вес"
        Me.btWeightQuery.UseVisualStyleBackColor = True
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(416, 114)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(98, 13)
        Me.Label23.TabIndex = 75
        Me.Label23.Text = "кг; ставка за вес:"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(290, 151)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(56, 13)
        Me.Label22.TabIndex = 74
        Me.Label22.Text = "ставка, %"
        '
        'btGetFullAmount
        '
        Me.btGetFullAmount.Location = New System.Drawing.Point(8, 17)
        Me.btGetFullAmount.Name = "btGetFullAmount"
        Me.btGetFullAmount.Size = New System.Drawing.Size(125, 23)
        Me.btGetFullAmount.TabIndex = 73
        Me.btGetFullAmount.Text = "база для рассчетов"
        Me.btGetFullAmount.UseVisualStyleBackColor = True
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(317, 235)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(56, 13)
        Me.Label21.TabIndex = 72
        Me.Label21.Text = "ставка, %"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(290, 180)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(56, 13)
        Me.Label20.TabIndex = 71
        Me.Label20.Text = "ставка, %"
        '
        'btShipmentOutFee
        '
        Me.btShipmentOutFee.Location = New System.Drawing.Point(282, 75)
        Me.btShipmentOutFee.Name = "btShipmentOutFee"
        Me.btShipmentOutFee.Size = New System.Drawing.Size(75, 23)
        Me.btShipmentOutFee.TabIndex = 70
        Me.btShipmentOutFee.Text = "получить"
        Me.btShipmentOutFee.UseVisualStyleBackColor = True
        '
        'tbTrilboneFee
        '
        Me.tbTrilboneFee.Location = New System.Drawing.Point(249, 231)
        Me.tbTrilboneFee.Name = "tbTrilboneFee"
        Me.tbTrilboneFee.Size = New System.Drawing.Size(52, 20)
        Me.tbTrilboneFee.TabIndex = 69
        Me.tbTrilboneFee.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbNalogFee
        '
        Me.tbNalogFee.Location = New System.Drawing.Point(222, 176)
        Me.tbNalogFee.Name = "tbNalogFee"
        Me.tbNalogFee.Size = New System.Drawing.Size(52, 20)
        Me.tbNalogFee.TabIndex = 68
        Me.tbNalogFee.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbShipmentOutFee
        '
        Me.tbShipmentOutFee.Location = New System.Drawing.Point(221, 76)
        Me.tbShipmentOutFee.Name = "tbShipmentOutFee"
        Me.tbShipmentOutFee.Size = New System.Drawing.Size(52, 20)
        Me.tbShipmentOutFee.TabIndex = 67
        Me.tbShipmentOutFee.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbExportFee
        '
        Me.tbExportFee.Location = New System.Drawing.Point(222, 110)
        Me.tbExportFee.Name = "tbExportFee"
        Me.tbExportFee.Size = New System.Drawing.Size(52, 20)
        Me.tbExportFee.TabIndex = 66
        Me.tbExportFee.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbInsectionFee
        '
        Me.tbInsectionFee.Location = New System.Drawing.Point(222, 44)
        Me.tbInsectionFee.Name = "tbInsectionFee"
        Me.tbInsectionFee.Size = New System.Drawing.Size(52, 20)
        Me.tbInsectionFee.TabIndex = 65
        Me.tbInsectionFee.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbMoneyOutFee
        '
        Me.tbMoneyOutFee.Location = New System.Drawing.Point(222, 147)
        Me.tbMoneyOutFee.Name = "tbMoneyOutFee"
        Me.tbMoneyOutFee.Size = New System.Drawing.Size(52, 20)
        Me.tbMoneyOutFee.TabIndex = 64
        Me.tbMoneyOutFee.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(15, 235)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(228, 13)
        Me.Label19.TabIndex = 63
        Me.Label19.Text = "Сумма, списываемая конторой за продажу"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(110, 180)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(106, 13)
        Me.Label18.TabIndex = 62
        Me.Label18.Text = "Стоимость налогов"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(5, 80)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(210, 13)
        Me.Label17.TabIndex = 61
        Me.Label17.Text = "Стоимость отправки, включая упаковку"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(104, 114)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(112, 13)
        Me.Label16.TabIndex = 60
        Me.Label16.Text = "Стоимость экспорта"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(37, 48)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(174, 13)
        Me.Label15.TabIndex = 59
        Me.Label15.Text = "Стоимость выставления на eBay"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(41, 151)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(175, 13)
        Me.Label14.TabIndex = 58
        Me.Label14.Text = "Стоимость вывода (PayPal, банк)"
        '
        'btSaveInDb
        '
        Me.btSaveInDb.Location = New System.Drawing.Point(515, 280)
        Me.btSaveInDb.Name = "btSaveInDb"
        Me.btSaveInDb.Size = New System.Drawing.Size(165, 51)
        Me.btSaveInDb.TabIndex = 57
        Me.btSaveInDb.Text = "Сохранить в базу и в МС"
        Me.btSaveInDb.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(100, 320)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 110
        Me.Label1.Text = "дольшик"
        '
        'cbWokerAdd
        '
        Me.cbWokerAdd.FormattingEnabled = True
        Me.cbWokerAdd.Location = New System.Drawing.Point(162, 316)
        Me.cbWokerAdd.Name = "cbWokerAdd"
        Me.cbWokerAdd.Size = New System.Drawing.Size(211, 21)
        Me.cbWokerAdd.TabIndex = 111
        '
        'btCreatePayment
        '
        Me.btCreatePayment.Location = New System.Drawing.Point(388, 314)
        Me.btCreatePayment.Name = "btCreatePayment"
        Me.btCreatePayment.Size = New System.Drawing.Size(75, 23)
        Me.btCreatePayment.TabIndex = 112
        Me.btCreatePayment.Text = "начислить"
        Me.btCreatePayment.UseVisualStyleBackColor = True
        '
        'ucTrilboneRegister
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btCreatePayment)
        Me.Controls.Add(Me.cbWokerAdd)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label35)
        Me.Controls.Add(Me.Label34)
        Me.Controls.Add(Me.Label33)
        Me.Controls.Add(Me.Label32)
        Me.Controls.Add(Me.tbCalcTotalPerOne)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.btPersonCalc)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.tbPersonCount)
        Me.Controls.Add(Me.btGetResorceFee)
        Me.Controls.Add(Me.Label29)
        Me.Controls.Add(Me.tbCalcTotal)
        Me.Controls.Add(Me.btTotal)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.tbSubTotal)
        Me.Controls.Add(Me.btSubTotal)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.tbFullAmount)
        Me.Controls.Add(Me.btWeightCalculate)
        Me.Controls.Add(Me.btMoneyOutCalculate)
        Me.Controls.Add(Me.btTrilboneCalculate)
        Me.Controls.Add(Me.btNalogCalculate)
        Me.Controls.Add(Me.tbTrilboneBase)
        Me.Controls.Add(Me.tbNalogBase)
        Me.Controls.Add(Me.tbMoneyOutBase)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.tbTrilboneTax)
        Me.Controls.Add(Me.tbNalogTax)
        Me.Controls.Add(Me.tbWeightTax)
        Me.Controls.Add(Me.tbWeight)
        Me.Controls.Add(Me.tbMoneyOutTax)
        Me.Controls.Add(Me.btWeightQuery)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.btGetFullAmount)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.btShipmentOutFee)
        Me.Controls.Add(Me.tbTrilboneFee)
        Me.Controls.Add(Me.tbNalogFee)
        Me.Controls.Add(Me.tbShipmentOutFee)
        Me.Controls.Add(Me.tbExportFee)
        Me.Controls.Add(Me.tbInsectionFee)
        Me.Controls.Add(Me.tbMoneyOutFee)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.btSaveInDb)
        Me.Name = "ucTrilboneRegister"
        Me.Size = New System.Drawing.Size(696, 347)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents tbCalcTotalPerOne As System.Windows.Forms.TextBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents btPersonCalc As System.Windows.Forms.Button
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents tbPersonCount As System.Windows.Forms.TextBox
    Friend WithEvents btGetResorceFee As System.Windows.Forms.Button
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents tbCalcTotal As System.Windows.Forms.TextBox
    Friend WithEvents btTotal As System.Windows.Forms.Button
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents tbSubTotal As System.Windows.Forms.TextBox
    Friend WithEvents btSubTotal As System.Windows.Forms.Button
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents tbFullAmount As System.Windows.Forms.TextBox
    Friend WithEvents btWeightCalculate As System.Windows.Forms.Button
    Friend WithEvents btMoneyOutCalculate As System.Windows.Forms.Button
    Friend WithEvents btTrilboneCalculate As System.Windows.Forms.Button
    Friend WithEvents btNalogCalculate As System.Windows.Forms.Button
    Friend WithEvents tbTrilboneBase As System.Windows.Forms.TextBox
    Friend WithEvents tbNalogBase As System.Windows.Forms.TextBox
    Friend WithEvents tbMoneyOutBase As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents tbTrilboneTax As System.Windows.Forms.TextBox
    Friend WithEvents tbNalogTax As System.Windows.Forms.TextBox
    Friend WithEvents tbWeightTax As System.Windows.Forms.TextBox
    Friend WithEvents tbWeight As System.Windows.Forms.TextBox
    Friend WithEvents tbMoneyOutTax As System.Windows.Forms.TextBox
    Friend WithEvents btWeightQuery As System.Windows.Forms.Button
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents btGetFullAmount As System.Windows.Forms.Button
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents btShipmentOutFee As System.Windows.Forms.Button
    Friend WithEvents tbTrilboneFee As System.Windows.Forms.TextBox
    Friend WithEvents tbNalogFee As System.Windows.Forms.TextBox
    Friend WithEvents tbShipmentOutFee As System.Windows.Forms.TextBox
    Friend WithEvents tbExportFee As System.Windows.Forms.TextBox
    Friend WithEvents tbInsectionFee As System.Windows.Forms.TextBox
    Friend WithEvents tbMoneyOutFee As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents btSaveInDb As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbWokerAdd As System.Windows.Forms.ComboBox
    Friend WithEvents btCreatePayment As System.Windows.Forms.Button

End Class
