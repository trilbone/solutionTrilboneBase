Imports PriceCalculator
Imports PriceCalculator.clsPriceCalculatorData
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Linq
Imports System.Drawing

Public Class ucPriceCalc
    Private oExcelObj As clsPriceCalculatorData
    Private oPriceData As clsPriceData
    Private oTargetLabel As Label
    Private oTargetPrice As Label
    Private oTargetPriceType As clsPriceCalculatorData.emOutPriceType
    Private oStartKoeff As Decimal
    ''' <summary>
    ''' инициализация начальная
    ''' </summary>
    ''' <param name="euroRate"></param>
    ''' <param name="usdEurRate"></param>
    ''' <param name="bookPath"></param>
    ''' <remarks></remarks>
    Public Sub init(euroRate As Decimal, usdEurRate As Decimal, bookPath As String)
        oExcelObj = New clsPriceCalculatorData(euroRate, usdEurRate, bookPath)

        oPriceData = New clsPriceData
        oPriceData.Eu_rate = euroRate
        oPriceData.Eu_Us_rate = usdEurRate

        oTargetLabel = L1
        oTargetPrice = R1
        oTargetPriceType = emOutPriceType.mainRusInOffice
        Me.UcPriceCalc_clsPriceDataBindingSource.DataSource = oPriceData
    End Sub

    ''' <summary>
    ''' установка входных данных
    ''' </summary>
    ''' <param name="Hunt_cost"></param>
    ''' <param name="Prep_cost"></param>
    ''' <param name="Weight"></param>
    ''' <param name="ClearProfit"></param>
    ''' <remarks></remarks>
    Public Sub SetData(Hunt_cost As Decimal, Prep_cost As Decimal, Weight As Decimal, Optional ClearProfit As Decimal = 1)
        ' Clear()
        With Me.oPriceData
            ' Me.oPriceData = New clsPriceData
            .Hunt_cost = Decimal.Round(Hunt_cost, 2)
            .Prep_cost = Decimal.Round(Prep_cost, 2)
            .Weight = Decimal.Round(Weight, 3)
            .Clear_Profit = ClearProfit
            oStartKoeff = ClearProfit
        End With

        Me.btCalculate_Click(Me.btCalculate, EventArgs.Empty)

        'oExcelObj.SetValues(Me.oPriceData.Weight, Me.oPriceData.Hunt_cost, Me.oPriceData.Prep_cost, Me.oPriceData.Clear_Profit)
        'Me.oPriceData.SetPrices(oExcelObj.Prices)
        'RaiseEvent CalcComplete(Me, New CalcCompleteEventArgs(oPriceData))
    End Sub

    ''' <summary>
    ''' вернет список цен для МС
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property GetPrices As clsPrices
        Get
            If oExcelObj Is Nothing Then Return Nothing
            Return oExcelObj.Prices
        End Get
    End Property


    Public Sub ClearAll()
        Dim _euroRate = oPriceData.Eu_rate
        Dim _usdEurRate = oPriceData.Eu_Us_rate
        oPriceData = New clsPriceData
        oPriceData.Eu_rate = _euroRate
        oPriceData.Eu_Us_rate = _usdEurRate

        Me.UcPriceCalc_clsPriceDataBindingSource.DataSource = oPriceData
        oStartKoeff = 0
        Clear()
    End Sub


    Private Sub Clear()

        If Not oTargetLabel Is Nothing Then
            oTargetLabel.BackColor = Label.DefaultBackColor
            oTargetPriceType = emOutPriceType.mainRusInOffice
            Dim _index As Integer = oTargetLabel.Name.Substring(1, oTargetLabel.Name.Length - 1).Trim
            Dim _ln As String = "B" + _index.ToString
            Dim _TargetRadio As RadioButton = (From c In Me.TableLayoutPanel1.Controls Where c.name.Equals(_ln) Select c).FirstOrDefault
            _TargetRadio.Checked = False
            Me.tbTunePrice.Text = ""
            btTunePrice.Enabled = False
            If Not oTargetPrice Is Nothing Then
                oTargetPrice.BackColor = Label.DefaultBackColor
                oTargetPriceType = emOutPriceType.mainRusInOffice
            End If
        Else
            Me.tbTunePrice.Text = ""
            btTunePrice.Enabled = False
        End If

    End Sub

    Public Event CalcComplete(sender As Object, e As CalcCompleteEventArgs)
    Public Class CalcCompleteEventArgs
        Inherits EventArgs

        Property PriceData As clsPriceData

        Sub New(PriceData As clsPriceData)
            Me.PriceData = PriceData
        End Sub
    End Class

    ''' <summary>
    '''обьект с ценами
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property PriceData As clsPriceData
        Get
            Return oPriceData
        End Get
    End Property
    ''' <summary>
    ''' посчитать
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Calculate()
        If oPriceData Is Nothing Then Return
        If oExcelObj Is Nothing Then Return

        btCalculate_Click(Me.btCalculate, EventArgs.Empty)
    End Sub


    Private Sub btCalculate_Click(sender As Object, e As EventArgs) Handles btCalculate.Click
        Clear()
        If Me.cbScheme5050.Checked Then
            Dim _baseinRUR = Me.oPriceData.Hunt_cost * 2 + Me.oPriceData.Prep_cost

            Dim _pr As New clsPriceCalculatorData.clsPrices
            'базовые цены  Россия в офисе 
            Dim _prItem As New KeyValuePair(Of String, Decimal)("RUR", _baseinRUR)
            _pr.Add(emOutPriceType.mainRusInOffice, _prItem)
            _prItem = New KeyValuePair(Of String, Decimal)("RUR", _baseinRUR)
            _pr.Add(emOutPriceType.mainRusInOffice_w, _prItem)
            'Россия на выставке(лавке)
            _prItem = New KeyValuePair(Of String, Decimal)("RUR", _baseinRUR)
            _pr.Add(emOutPriceType.RusShop, _prItem)
            _prItem = New KeyValuePair(Of String, Decimal)("RUR", _baseinRUR)
            _pr.Add(emOutPriceType.RusShop_w, _prItem)
            'Буржуи в офисе
            _prItem = New KeyValuePair(Of String, Decimal)("EUR", clsApplicationTypes.CurrencyConvert(_baseinRUR, "RUR", "EUR"))
            _pr.Add(emOutPriceType.EUinOffice, _prItem)
            _prItem = New KeyValuePair(Of String, Decimal)("EUR", clsApplicationTypes.CurrencyConvert(_baseinRUR, "RUR", "EUR"))
            _pr.Add(emOutPriceType.EUinOffice_w, _prItem)
            'Буржуи через почту оплата на банк
            _prItem = New KeyValuePair(Of String, Decimal)("USD", clsApplicationTypes.CurrencyConvert(_baseinRUR, "RUR", "USD"))
            _pr.Add(emOutPriceType.EUbyPostBank, _prItem)
            _prItem = New KeyValuePair(Of String, Decimal)("USD", clsApplicationTypes.CurrencyConvert(_baseinRUR, "RUR", "USD"))
            _pr.Add(emOutPriceType.EUbyPostBank_w, _prItem)
            'Буржуи через почту оплата PAYPAL
            _prItem = New KeyValuePair(Of String, Decimal)("USD", clsApplicationTypes.CurrencyConvert(_baseinRUR, "RUR", "USD"))
            _pr.Add(emOutPriceType.EUbyPostPayPal, _prItem)
            _prItem = New KeyValuePair(Of String, Decimal)("USD", clsApplicationTypes.CurrencyConvert(_baseinRUR, "RUR", "USD"))
            _pr.Add(emOutPriceType.EUbyPostPayPal_w, _prItem)
            'Буржуи на выставке
            _prItem = New KeyValuePair(Of String, Decimal)("EUR", clsApplicationTypes.CurrencyConvert(_baseinRUR, "RUR", "EUR"))
            _pr.Add(emOutPriceType.EUShop, _prItem)
            _prItem = New KeyValuePair(Of String, Decimal)("EUR", clsApplicationTypes.CurrencyConvert(_baseinRUR, "RUR", "EUR"))
            _pr.Add(emOutPriceType.EUShop_w, _prItem)
            'Ebay
            _prItem = New KeyValuePair(Of String, Decimal)("USD", clsApplicationTypes.CurrencyConvert(_baseinRUR, "RUR", "USD"))
            _pr.Add(emOutPriceType.Ebay, _prItem)

            Me.oPriceData.SetPrices(_pr)
        Else
            oExcelObj.SetValues(Me.oPriceData.Weight, Me.oPriceData.Hunt_cost, Me.oPriceData.Prep_cost, Me.oPriceData.Clear_Profit)
            Me.oPriceData.SetPrices(oExcelObj.Prices)
        End If


        RaiseEvent CalcComplete(Me, New CalcCompleteEventArgs(oPriceData))
    End Sub


    Private Sub B1_CheckedChanged(sender As Object, e As EventArgs) Handles B1.CheckedChanged, B2.CheckedChanged, B3.CheckedChanged, B4.CheckedChanged, B5.CheckedChanged, B6.CheckedChanged, B7.CheckedChanged
        If CType(sender, RadioButton).Checked Then
            If Not oTargetLabel Is Nothing Then
                oTargetLabel.BackColor = Label.DefaultBackColor
            End If
            If Not oTargetPrice Is Nothing Then
                oTargetPrice.BackColor = Label.DefaultBackColor
            End If

            Me.tbTunePrice.Text = ""
            btTunePrice.Enabled = True
            oTargetPriceType = emOutPriceType.mainRusInOffice
            Dim _index As Integer = CType(sender, RadioButton).Name.Substring(1, CType(sender, RadioButton).Name.Length - 1).Trim
            Dim _ln As String = "L" + _index.ToString
            Dim _pn As String = "R" + _index.ToString
            oTargetLabel = (From c In Me.TableLayoutPanel1.Controls Where c.name.Equals(_ln) Select c).FirstOrDefault
            oTargetPrice = (From c In Me.TableLayoutPanel1.Controls Where c.name.Equals(_pn) Select c).FirstOrDefault

            If Not oTargetLabel Is Nothing Then
                oTargetLabel.BackColor = Drawing.Color.Red
                oTargetPrice.BackColor = Drawing.Color.Red
                Me.tbTunePrice.Text = oTargetPrice.Text
                Select Case _index
                    Case 1
                        oTargetPriceType = emOutPriceType.mainRusInOffice
                    Case 2
                        oTargetPriceType = emOutPriceType.RusShop
                    Case 3
                        oTargetPriceType = emOutPriceType.EUinOffice
                    Case 4
                        oTargetPriceType = emOutPriceType.EUbyPostBank
                    Case 5
                        oTargetPriceType = emOutPriceType.EUbyPostPayPal
                    Case 6
                        oTargetPriceType = emOutPriceType.EUShop
                    Case 7
                        oTargetPriceType = emOutPriceType.Ebay
                    Case Else
                        MsgBox("Для индекса цены не задано действие -  B1_CheckedChanged в ucPriceCals в Service", vbCritical)
                End Select
                Me.tbTunePrice.Focus()
            End If
        End If
    End Sub
    ''' <summary>
    ''' настройка цены
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btTunePrice_Click(sender As Object, e As EventArgs) Handles btTunePrice.Click
        Dim _prValue As Decimal = clsApplicationTypes.ReplaceDecimalSplitter(Me.tbTunePrice)
        Me.oPriceData.Clear_Profit = oExcelObj.TunePrices(_prValue, oTargetPriceType, 0.01, False)
        Me.oPriceData.SetPrices(oExcelObj.Prices)
        RaiseEvent CalcComplete(Me, New CalcCompleteEventArgs(oPriceData))

    End Sub

    Public Class clsPriceData
        Implements INotifyPropertyChanged

        Dim oRus_office As Decimal
        Dim oWeight As Decimal
        Dim oEu_post_bank_w As Decimal
        Dim oRus_show_w As Decimal
        Dim oEu_office As Decimal
        Dim oeBay As Decimal
        Dim oHunt_cost As Decimal
        Dim oPrep_cost As Decimal
        Dim oEu_rate As Decimal
        Dim oEu_Us_rate As Decimal
        Dim oClear_Profit As Decimal
        Dim oRus_office_w As Decimal
        Dim oRus_show As Decimal
        Dim oEu_post_paypal As Decimal
        Dim oEu_office_w As Decimal
        Dim oEu_show_w As Decimal
        Dim oEu_post_paypal_w As Decimal
        Dim oEu_post_bank As Decimal
        Dim oEu_show As Decimal
        Dim oInvoice As Decimal
        Dim oInvoiceCurrency As String
        Dim oBuy_cost As Decimal

        Property Invoce As Decimal
            Get
                Return oInvoice
            End Get
            Set(value As Decimal)
                oInvoice = value
                RaisePropertyChanged("Invoce")
            End Set
        End Property
        Property InvoceCurrency As String
            Get
                Return oInvoiceCurrency
            End Get
            Set(value As String)
                oInvoiceCurrency = value
                RaisePropertyChanged("InvoceCurrency")
            End Set
        End Property

        Property Weight As Decimal
            Get
                Return oWeight
            End Get
            Set(value As Decimal)
                oWeight = value
                RaisePropertyChanged("Weight")
            End Set
        End Property
        Property Hunt_cost As Decimal
            Get
                Return oHunt_cost
            End Get
            Set(value As Decimal)
                oHunt_cost = value
                RaisePropertyChanged("Hunt_cost")
            End Set
        End Property
        Property Prep_cost As Decimal
            Get
                Return oPrep_cost
            End Get
            Set(value As Decimal)
                oPrep_cost = value
                RaisePropertyChanged("Prep_cost")
            End Set
        End Property
        ''' <summary>
        ''' полная цена закупки (oHunt_cost + oPrep_cost)
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property Buy_cost As Decimal
            Get
                If oBuy_cost = 0 Then
                    oBuy_cost = oHunt_cost + oPrep_cost
                End If

                Return oBuy_cost
            End Get
            Set(value As Decimal)
                oBuy_cost = value
                RaisePropertyChanged("Buy_cost")
            End Set
        End Property

        Property Eu_rate As Decimal
            Get
                Return oEu_rate
            End Get
            Set(value As Decimal)
                oEu_rate = value
                RaisePropertyChanged("Eu_rate")
            End Set
        End Property
        Property Eu_Us_rate As Decimal
            Get
                Return oEu_Us_rate
            End Get
            Set(value As Decimal)
                oEu_Us_rate = value
                RaisePropertyChanged("Eu_Us_rate")
            End Set
        End Property
        Property Clear_Profit As Decimal
            Get
                Return oClear_Profit
            End Get
            Set(value As Decimal)
                oClear_Profit = value
                RaisePropertyChanged("Clear_Profit")
            End Set
        End Property

        Property Rus_office As Decimal
            Get
                Return oRus_office
            End Get
            Set(value As Decimal)
                oRus_office = value
                RaisePropertyChanged("Rus_office")
            End Set
        End Property

        Property Rus_office_w As Decimal
            Get
                Return oRus_office_w
            End Get
            Set(value As Decimal)
                oRus_office_w = value
                RaisePropertyChanged("Rus_office_w")
            End Set
        End Property

        Property Rus_show As Decimal
            Get
                Return oRus_show
            End Get
            Set(value As Decimal)
                oRus_show = value
                RaisePropertyChanged("Rus_show")
            End Set
        End Property
        Property Rus_show_w As Decimal
            Get
                Return oRus_show_w
            End Get
            Set(value As Decimal)
                oRus_show_w = value
                RaisePropertyChanged("Rus_show_w")
            End Set
        End Property

        Property Eu_office As Decimal
            Get
                Return oEu_office
            End Get
            Set(value As Decimal)
                oEu_office = value
                RaisePropertyChanged("Eu_office")
            End Set
        End Property
        Property Eu_office_w As Decimal
            Get
                Return oEu_office_w
            End Get
            Set(value As Decimal)
                oEu_office_w = value
                RaisePropertyChanged("Eu_office_w")
            End Set
        End Property

        Property Eu_post_bank As Decimal
            Get
                Return oEu_post_bank
            End Get
            Set(value As Decimal)
                oEu_post_bank = value
                RaisePropertyChanged("Eu_post_bank")
            End Set
        End Property
        Property Eu_post_bank_w As Decimal
            Get
                Return oEu_post_bank_w
            End Get
            Set(value As Decimal)
                oEu_post_bank_w = value
                RaisePropertyChanged("Eu_post_bank_w")
            End Set
        End Property

        Property Eu_post_paypal As Decimal
            Get
                Return oEu_post_paypal
            End Get
            Set(value As Decimal)
                oEu_post_paypal = value
                RaisePropertyChanged("Eu_post_paypal")
            End Set
        End Property
        Property Eu_post_paypal_w As Decimal
            Get
                Return oEu_post_paypal_w
            End Get
            Set(value As Decimal)
                oEu_post_paypal_w = value
                RaisePropertyChanged("Eu_post_paypal_w")
            End Set
        End Property

        Property Eu_show As Decimal
            Get
                Return oEu_show
            End Get
            Set(value As Decimal)
                oEu_show = value
                RaisePropertyChanged("Eu_show")
            End Set
        End Property
        Property Eu_show_w As Decimal
            Get
                Return oEu_show_w
            End Get
            Set(value As Decimal)
                oEu_show_w = value
                RaisePropertyChanged("Eu_show_w")
            End Set
        End Property

        Property eBay As Decimal
            Get
                Return oeBay
            End Get
            Set(value As Decimal)
                oeBay = value
                RaisePropertyChanged("eBay")
            End Set
        End Property

        ''' <summary>
        ''' запишет цены
        ''' </summary>
        ''' <param name="prices"></param>
        ''' <remarks></remarks>
        Public Sub SetPrices(prices As clsPrices)
            With Me
                For Each pr In prices
                    Select Case pr.Key
                        Case emOutPriceType.mainRusInOffice
                            .Rus_office = pr.Value.Value
                        Case emOutPriceType.mainRusInOffice_w
                            .Rus_office_w = pr.Value.Value

                        Case emOutPriceType.RusShop
                            .Rus_show = pr.Value.Value
                        Case emOutPriceType.RusShop_w
                            .Rus_show_w = pr.Value.Value

                        Case emOutPriceType.EUinOffice
                            .Eu_office = pr.Value.Value
                        Case emOutPriceType.EUinOffice_w
                            .Eu_office_w = pr.Value.Value

                        Case emOutPriceType.EUbyPostBank
                            .Eu_post_bank = pr.Value.Value
                        Case emOutPriceType.EUbyPostBank_w
                            .Eu_post_bank_w = pr.Value.Value

                        Case emOutPriceType.EUbyPostPayPal
                            .Eu_post_paypal = pr.Value.Value
                        Case emOutPriceType.EUbyPostPayPal_w
                            .Eu_post_paypal_w = pr.Value.Value

                        Case emOutPriceType.EUShop
                            .Eu_show = pr.Value.Value
                        Case emOutPriceType.EUShop_w
                            .Eu_show_w = pr.Value.Value

                        Case emOutPriceType.Ebay
                            .eBay = pr.Value.Value


                    End Select
                Next

                .Invoce = 0
                .InvoceCurrency = ""
            End With
        End Sub

        Public Event PropertyChanged(sender As Object, e As PropertyChangedEventArgs) Implements INotifyPropertyChanged.PropertyChanged

        Private Sub RaisePropertyChanged(propertyname As String)
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyname))
        End Sub

    End Class




    Private Sub tbTunePrice_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbTunePrice.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Me.btTunePrice_Click(sender, e)
        End If
    End Sub

    Private Sub tbWeight_Validating(sender As Object, e As CancelEventArgs) Handles tbWeight.Validating, tbRaw.Validating, tbPrep.Validating, tbRateEu.Validating, tbRateEuUs.Validating, tbTunePrice.Validating, tbPercent.Validating
        If sender.Text = "" Then sender.Text = "0" : Return
        If sender.Text = " " Then sender.Text = "0" : Return
        sender.text = clsApplicationTypes.ReplaceDecimalSplitter(sender.text)
        sender.backcolor = Color.FromKnownColor(KnownColor.Window)
        Select Case sender.name
            Case "tbWeight"
                'замена гр на кг
                Dim _control As Control = CType(sender, Windows.Forms.Control)
                Dim _result As Decimal
                If Decimal.TryParse(_control.Text, _result) Then
                    'проверить, есть ли точка
                    For Each s In _control.Text
                        If Char.IsPunctuation(s) Then
                            'есть точка, выход
                            Return
                        End If
                    Next
                    'точки нет, и значение больше 10
                    If _result > 10 Then
                        _result = _result / 1000
                        _control.Text = _result.ToString
                    End If
                End If
        End Select
    End Sub

    Private Sub ucPriceCalc_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        If Not oExcelObj Is Nothing Then
            oExcelObj.Dispose()

        End If
    End Sub

    Private Sub btSowExcel_Click(sender As Object, e As EventArgs) Handles btSowExcel.Click
        Me.oExcelObj.showexcel()
    End Sub


    Private Sub Label1_MouseClick(sender As Object, e As MouseEventArgs) Handles Label1.MouseClick
        GetDigi.connect(Me.tbTunePrice)
    End Sub

    Private Sub Label3_MouseClick(sender As Object, e As MouseEventArgs) Handles Label3.MouseClick
        GetDigi.connect(Me.tbPercent)
    End Sub

    Private Sub lbW_MouseClick(sender As Object, e As MouseEventArgs) Handles lbW.MouseClick
        GetDigi.connect(Me.tbWeight)
    End Sub
    Private Sub lbR_MouseClick(sender As Object, e As MouseEventArgs) Handles lbR.MouseClick
        GetDigi.connect(Me.tbRaw)
    End Sub

    Private Sub lbR1_MouseClick(sender As Object, e As MouseEventArgs) Handles lbR1.MouseClick
        GetDigi.connect(Me.tbRateEu)
    End Sub

    Private Sub lbR2_MouseClick(sender As Object, e As MouseEventArgs) Handles lbR2.MouseClick
        GetDigi.connect(Me.tbRateEuUs)
    End Sub
    Private Sub lbP_MouseClick(sender As Object, e As MouseEventArgs) Handles lbP.MouseClick
        GetDigi.connect(Me.tbPrep)
    End Sub
    Private Function GetDigi() As Object
        Return clsApplicationTypes.GetDigiKeyBoardForm
    End Function

    Private Sub btPlus_Click(sender As Object, e As EventArgs) Handles btPlus.Click
        oPriceData.Clear_Profit += 0.2

        Clear()
        oExcelObj.SetValues(Me.oPriceData.Weight, Me.oPriceData.Hunt_cost, Me.oPriceData.Prep_cost, Me.oPriceData.Clear_Profit)
        Me.oPriceData.SetPrices(oExcelObj.Prices)
    End Sub

    Private Sub btMinus_Click(sender As Object, e As EventArgs) Handles btMinus.Click
        If oPriceData.Clear_Profit = 0 Then Return
        If (oPriceData.Clear_Profit - 0.2) < 0 Then Return
        oPriceData.Clear_Profit -= 0.2

        Clear()
        oExcelObj.SetValues(Me.oPriceData.Weight, Me.oPriceData.Hunt_cost, Me.oPriceData.Prep_cost, Me.oPriceData.Clear_Profit)
        Me.oPriceData.SetPrices(oExcelObj.Prices)
    End Sub

    Private Sub cbScheme5050_CheckedChanged(sender As Object, e As EventArgs) Handles cbScheme5050.CheckedChanged
        btCalculate_Click(Me.btCalculate, EventArgs.Empty)
    End Sub
End Class
