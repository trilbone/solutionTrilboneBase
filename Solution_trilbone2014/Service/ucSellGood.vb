Imports Service
Imports Service.clsApplicationTypes
Imports Service.Agents
Imports System.Linq
Public Class ucSellGood
    Private oMsi As iMoySkladDataProvider
    Private oSelectedAgent As AUCTIONDATAAGENT

    Dim oDemand As iMoySkladDataProvider.clsOperationInfo
    Dim oOrder As iMoySkladDataProvider.clsOperationInfo
    Dim oInPayment As iMoySkladDataProvider.clsPaymentInfo

    Dim oGoodList As List(Of iMoySkladDataProvider.clsPosition)
    Dim oInMoySklad As Boolean
    Dim oSoldDate As Date


    Public Sub New()

        ' Этот вызов является обязательным для конструктора.
        InitializeComponent()

        ' Добавьте все инициализирующие действия после вызова InitializeComponent().
    End Sub

    Public Sub init()
        Me.lbxAgentList.DataSource = (From c In clsApplicationTypes.AuctionAgent.AGENT Where Not c.account.Contains("test")).ToList
        oMsi = clsApplicationTypes.MoySklad(False)
        If oMsi Is Nothing Then
            Me.btLoadMC.BackColor = Drawing.Color.Red
        End If
        Clear()
    End Sub

    Public Sub Clear()
        Me.tbCtlMain.TabPages.Clear()
        Me.tbCtlMain.TabPages.Add(tpAgentSelect)

        Me.MonthCalendar1.SelectionStart = Date.Now
        Me.lbDate.Text = Me.MonthCalendar1.SelectionStart.ToShortDateString

        Me.lbxAgentList.SelectedIndex = 0
        oSelectedAgent = Me.lbxAgentList.SelectedItem
        Me.lbAgent.Text = If(oSelectedAgent Is Nothing, oSelectedAgent.ToString, "место продажи не задано")

        Me.btStartRegister.Enabled = False
        Me.cbxDemand.Enabled = False
        Me.cbxOrder.Enabled = False
        Me.cbxPayment.Enabled = False
        Me.cbxDemand.DataSource = Nothing
        Me.cbxOrder.DataSource = Nothing
        Me.cbxPayment.DataSource = Nothing
        Me.oDemand = Nothing
        Me.oOrder = Nothing
        Me.oInPayment = Nothing
        Me.cbxInMoySklad.Checked = False
        Me.PictureBox1.Image = Nothing
        Me.TextBox1.Text = ""

        cbxInMoySklad_CheckedChanged(Me.cbxInMoySklad, EventArgs.Empty)

    End Sub

    ''' <summary>
    ''' выбор предварительной даты
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub SelectYear_Click(sender As Object, e As EventArgs) Handles bt_2011.Click, bt_2012.Click, bt_2013.Click, bt_2014.Click, bt_2015.Click
        Dim _year = sender.text
        Me.MonthCalendar1.SelectionStart = New Date(_year, Date.Now.Month, Date.Now.Day)
    End Sub

    Private Sub lbxAgentList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbxAgentList.SelectedIndexChanged
        If Me.lbxAgentList.SelectedItem Is Nothing Then Me.lbAgent.Text = "место продажи не задано" : Return
        Me.lbAgent.Text = Me.lbxAgentList.SelectedItem.ToString
        oSelectedAgent = Me.lbxAgentList.SelectedItem
        If (Not oSelectedAgent Is Nothing) Then
            Me.btStartRegister.Enabled = True
        End If
        Me.cbActiveSellList.DataSource = Nothing
        oSoldActiveItem = Nothing
        Me.PictureBox1.Image = Nothing
        Me.TextBox1.Text = ""
    End Sub

    Private Sub MonthCalendar1_DateChanged(sender As Object, e As Windows.Forms.DateRangeEventArgs) Handles MonthCalendar1.DateChanged
        Me.lbDate.Text = Me.MonthCalendar1.SelectionStart.ToShortDateString
        If (Not oSelectedAgent Is Nothing) Then
            Me.btStartRegister.Enabled = True
        End If
    End Sub

    Private Sub btLoadMC_Click(sender As Object, e As EventArgs) Handles btLoadMC.Click
        If Not Me.btLoadMC.BackColor = Drawing.Color.Red Then
            oMsi = clsApplicationTypes.MoySklad(True, True)
        Else
            oMsi = clsApplicationTypes.MoySklad(True)
        End If
        If Not oMsi Is Nothing Then
            Me.btLoadMC.BackColor = Windows.Forms.Button.DefaultBackColor
            'If (Not oSelectedAgent Is Nothing) And (Not String.IsNullOrEmpty(Me.lbDate.Text)) Then
            '    Me.btStartRegister.Enabled = True
            'End If
        End If
    End Sub

    Private oSelectedCustomer As iMoySkladDataProvider.clsClientInfo

#Region "Регистрация"
    ''' <summary>
    ''' начало регистрации
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btStartRegister_Click(sender As Object, e As EventArgs) Handles btStartRegister.Click
        Debug.Assert(Not oSelectedAgent Is Nothing)
        If oMsi Is Nothing Then Return

        '1 этап. выбрать клиента
        'результат будет передан в UcClient1_CustomerSelected
        Me.UcClient1.init(oMsi)
        'предварительно выбранный итем на оформление
        If Not oSoldActiveItem Is Nothing Then
            Dim _item As ieBayDataProvider.ieBayTransactionItem = TryCast(oSoldActiveItem, ieBayDataProvider.ieBayTransactionItem)

            If Not _item Is Nothing Then
                Me.UcClient1.ClientAddress = _item.Address
                Me.UcClient1.UserID = _item.Order.BuyerUserID
            End If
        End If

        'дата продажи для документов
        Me.oSoldDate = Me.MonthCalendar1.SelectionStart

        Me.tbCtlMain.TabPages.Add(tpClient)
        Me.tbCtlMain.SelectedTab = tpClient

        Me.btStartRegister.Enabled = False '   btStartRegister
    End Sub

    ''' <summary>
    ''' клиент выбран
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub UcClient1_CustomerSelected(sender As Object, e As ucClient.CustomerSelectedEventArgs) Handles UcClient1.CustomerSelected
        oSelectedCustomer = e.Customer
        '2 этап. формирование списка товаров
        'а также создание заказа(снятие с резерва автоматом), создание отгрузки
        'результат будет передан в UcMCOreder1_OrderCreated
        Me.UcGoodList1.init(msi:=oMsi, agent:=oSelectedAgent, customer:=oSelectedCustomer, DocumentDate:=oSoldDate)

        'предварительно выбранный итем на оформление
        If Not oSoldActiveItem Is Nothing Then
            Dim _item As ieBayDataProvider.ieBayTransactionItem = TryCast(oSoldActiveItem, ieBayDataProvider.ieBayTransactionItem)
            If Not _item Is Nothing Then
                'тут надо получить список товаров при комбинированном шиппинге
                If _item.Order.TransactionCount > 1 Then
                    ''комбинированный шиппинг
                    For Each c In _item.Order.TransactionArray
                        'добавить сам товар
                        Me.UcGoodList1.ExternalSetGood(SampleNumber:=_item.ItemSKU, CheckingMC:=True, MCCreateIfNotExist:=False, GoodName:="", GoodAmount:=_item.TransactionPrice.Value, AmountCurrency:=_item.TransactionPrice.Currency, ExternalID:=_item.ItemID, ShippingDate:=_item.ShippedDate)
                        Me.UcGoodList1.SelectGood(_item.ItemSKU)
                    Next
                Else
                    'добавить сам товар
                    Me.UcGoodList1.ExternalSetGood(SampleNumber:=_item.ItemSKU, CheckingMC:=True, MCCreateIfNotExist:=False, GoodName:="", GoodAmount:=_item.TransactionPrice.Value, AmountCurrency:=_item.TransactionPrice.Currency, ExternalID:=_item.ItemID, ShippingDate:=_item.ShippedDate)
                    Me.UcGoodList1.SelectGood(_item.ItemSKU)
                End If


                '============
                'заполнение fee
                '1
                For Each fl In oSelectedAgent.GetFIELD("moysklad.fee").ITEM
                    If fl.agentID.Length > 3 Then
                        'UUID присутствует
                        Select Case fl.value
                            Case "EbayFeeEnd"
                                If _item.FinalValueFee.Value > 0 Then
                                    _item.FeeList.Add(New iMoySkladDataProvider.clsFee With {.UUID = fl.agentID, .Value = _item.FinalValueFee.Value, .Currency = _item.FinalValueFee.Currency, .Name = fl.value})
                                End If
                        End Select
                    End If
                Next
                '2
                'все транзакции PayPal, fee суммарно
                For Each fl In oSelectedAgent.GetFIELD("moysklad.PayPal").ITEM
                    If fl.value.Contains(_item.PayPalEmailAddress) Then
                        If fl.value.Contains("PayPalStrartFee") Then
                            _item.FeeList.Add(New iMoySkladDataProvider.clsFee With {.UUID = fl.agentID, .Value = _item.ExternalTotalValueFee.Value, .Currency = _item.ExternalTotalValueFee.Currency, .Name = fl.value})
                        End If
                    End If
                Next
                '
                '3
                Dim _sm = clsApplicationTypes.clsSampleNumber.CreateFromString(_item.ItemSKU)
                If _sm.CodeIsCorrect Then
                    Dim _ReadySampleDBContext = clsApplicationTypes.SampleDataObject.GetdbReadySampleObjectContext
                    'fee за выставления - из БД trilbone tbSLSample.resourcefee - записывается при выставлении образца на ресурс
                    Dim _result = (_ReadySampleDBContext.pSLGetSampleInsectionFeeTotal(_sm.GetEan13)).ToList

                    If _result.Count > 0 Then
                        If _result(0).totalfee > 0 Then
                            _item.FeeList.Add(New iMoySkladDataProvider.clsFee With {.UUID = oSelectedAgent.GetAgentID("moysklad.fee", "EbayFeeStart"), .Value = _result(0).totalfee, .Currency = _result(0).currency, .Name = "EbayFeeStart"})
                        End If
                    End If
                End If

                '4
                'если плата за выставление в контору применяется агентом - цена и валюта берется из карточки товара
                Dim _trfeeUUID = oSelectedAgent.GetAgentID("moysklad.fee", "TrilboneFee")
                If Not String.IsNullOrEmpty(_trfeeUUID) Then
                    _item.FeeList.Add(New iMoySkladDataProvider.clsFee With {.UUID = _trfeeUUID, .Value = 0, .Currency = "", .Name = "TrilboneFee"})
                End If

                'передать параметры ЭУ
                Me.UcGoodList1.SetFeeGoods(_item)
            End If
        End If

        Me.tbCtlMain.TabPages.Remove(tpClient)
        Me.tbCtlMain.TabPages.Add(tpGoods)
        Me.tbCtlMain.SelectedTab = tpGoods

        'Select Case Me.cbxInMoySklad.Checked
        '    Case True
        '        '
        '    Case Else
        '        'в МС не пишем
        'End Select

    End Sub


    ''' <summary>
    ''' список образцов заказа создан
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub UcGoodList1_OrderCreated(sender As Object, e As ucGoodList.GoodListCreatedEventArgs) Handles UcGoodList1.GoodListCreated
        If Not e.Order Is Nothing Then
            'заказ создан

        End If
        If Not e.Demand Is Nothing Then
            'отгрузка создана

        End If

        'этап 3. оформить входящий платеж
        'результат будет передан в UcPaymentDemand1_PaymentCreated
        Me.UcPaymentDemand1.init(Agent:=Me.oSelectedAgent, msi:=oMsi, Customer:=oSelectedCustomer, Order:=e.Order, Demand:=e.Demand, GoodList:=e.GoodList)

        'предварительно выбранный итем на оформление
        If Not oSoldActiveItem Is Nothing Then
            Dim _item As ieBayDataProvider.ieBayTransactionItem = TryCast(oSoldActiveItem, ieBayDataProvider.ieBayTransactionItem)
            If Not _item Is Nothing Then
                'установить счет получателя
                Dim _AccepterUUID = oSelectedAgent.GetAgentID("moysklad.account", _item.PayPalEmailAddress)
                Me.UcPaymentDemand1.SetAccount(_AccepterUUID)
                'установить сумму и валюту полученного платежа/ установить дату платежа
                Me.UcPaymentDemand1.SetPaimentDetails(_item.AmountPaidValue.Value, _item.AmountPaidValue.Currency, _item.PaidTime)
            End If
        End If

        Me.tbCtlMain.TabPages.Remove(tpGoods)
        Me.tbCtlMain.TabPages.Add(tpPayment)
        Me.tbCtlMain.SelectedTab = tpPayment
    End Sub

    ''' <summary>
    ''' платеж введен
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub UcPaymentDemand1_PaymentApproved(sender As Object, e As ucPaymentDemand.PaymentCreatedEventArgs) Handles UcPaymentDemand1.PaymentApproved

        Me.oInPayment = e.Payment
        If e.DocumentsLinked Then
            MsgBox("Документы успешно связаны", vbInformation)

        End If

        'ВРЕМЕННО новая продажа
        Me.Clear()

        'этап 4. Создание задания на шиппинг или запись суммы шипинга??
        'Общие расходы на шиппинг из нарвы 8-3491-1  UUID=095e1e33-8a03-11e4-90a2-8ecb00197aa6


        'этап 5. Регистрация в базе трилбон
        'For Each t In Me.oGoodList
        '    Dim _tp = New Windows.Forms.TabPage
        '    With _tp
        '        Dim _ctl = New ucTrilboneRegister
        '        _ctl.init(Agent:=oSelectedAgent, msi:=oMsi, SampleNumber:=t.SampleNumber, ClearPayment:=t.BasePriceInCurrency, Demand:=Me.oDemand, OutFeeGoodUUID:=e.OutFeeGoodUUID)
        '        .Controls.Add(_ctl)
        '        .Location = New System.Drawing.Point(4, 22)
        '        .Name = t.ActualCode
        '        .Padding = New System.Windows.Forms.Padding(3)
        '        .Size = New System.Drawing.Size(716, 383)
        '        .TabIndex = 1
        '        .Text = t.ActualCode
        '        .UseVisualStyleBackColor = True
        '    End With
        '    Me.tbCtlSamples.TabPages.Add(_tp)
        'Next
        'Me.tbCtlMain.TabPages.Add(tpTrilboneRegister)
    End Sub

#End Region





    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cbxInMoySklad_CheckedChanged(sender As Object, e As EventArgs) Handles cbxInMoySklad.CheckedChanged
        If cbxInMoySklad.Checked And (oMsi Is Nothing) Then
            MsgBox("Мой склад не загружен", vbCritical)
            cbxInMoySklad.Checked = False
            Return
        End If

        Me.oInMoySklad = cbxInMoySklad.Checked
        If Not oInMoySklad Then
            Me.btDemand.Enabled = False
            Me.btOrder.Enabled = False
            Me.btInPayment.Enabled = False

            Me.cbxDemand.Enabled = False
            Me.cbxOrder.Enabled = False
            Me.cbxPayment.Enabled = False

            Me.cbxDemand.DataSource = Nothing
            Me.cbxOrder.DataSource = Nothing
            Me.cbxPayment.DataSource = Nothing

            Me.oDemand = Nothing
            Me.oOrder = Nothing
            Me.oInPayment = Nothing

            Me.btOrder.Text = "Заказ"
            Me.btDemand.Text = "Отгрузка"
            Me.btInPayment.Text = "Вх.платеж"
        Else
            Me.btDemand.Enabled = True
            Me.btOrder.Enabled = True
            Me.btInPayment.Enabled = True

            Me.cbxDemand.Enabled = True
            Me.cbxOrder.Enabled = True
            Me.cbxPayment.Enabled = True
        End If
    End Sub


    ''' <summary>
    ''' запрос отгрузки
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btDemand_Click(sender As Object, e As EventArgs) Handles btDemand.Click
        If String.IsNullOrEmpty(Me.cbxDemand.Text) Or Not Me.cbxDemand.DataSource Is Nothing Then
            Return
        End If

        Dim _result = oMsi.GetDemandInfo(DemandName:=Me.cbxDemand.Text)
        Select Case _result.Count
            Case 0
                Me.btDemand.Text = String.Format("Отгрузка", _result.Count)

                Me.cbxDemand.DataSource = Nothing
            Case Else
                Me.btDemand.Text = String.Format("Отгрузка({0})", _result.Count)

                Me.cbxDemand.DataSource = _result
        End Select

    End Sub

    Private Sub btOrder_Click(sender As Object, e As EventArgs) Handles btOrder.Click
        If String.IsNullOrEmpty(Me.cbxOrder.Text) Or Not Me.cbxOrder.DataSource Is Nothing Then
            Return
        End If
        Dim _result = oMsi.GetOrderInfo(OrderName:=Me.cbxOrder.Text)
        Select Case _result.Count
            Case 0
                Me.btOrder.Text = String.Format("Заказ", _result.Count)

                Me.cbxOrder.DataSource = Nothing
            Case Else
                Me.btOrder.Text = String.Format("Заказ({0})", _result.Count)

                Me.cbxOrder.DataSource = _result
        End Select
    End Sub

    Private Sub btInPayment_Click(sender As Object, e As EventArgs) Handles btInPayment.Click
        If String.IsNullOrEmpty(Me.cbxPayment.Text) Or Not Me.cbxPayment.DataSource Is Nothing Then
            Return
        End If
        Dim _result = oMsi.GetPaymentInInfo(PaymentInName:=Me.cbxPayment.Text)
        Select Case _result.Count
            Case 0
                Me.btInPayment.Text = String.Format("Вх.платеж", _result.Count)
                Me.cbxPayment.DataSource = Nothing
            Case Else
                Me.btInPayment.Text = String.Format("Вх.платеж({0})", _result.Count)
                Me.cbxPayment.DataSource = _result
        End Select
    End Sub


    ''' <summary>
    ''' выбран заказ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cbxOrder_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxOrder.SelectedIndexChanged
        Dim _op As iMoySkladDataProvider.clsOperationInfo = cbxOrder.SelectedItem
        If _op Is Nothing Then Return
        'отгрузка
        If Not String.IsNullOrEmpty(_op.RefDemandUUID) Then
            If Not Me.cbxDemand.DataSource Is Nothing Then
                'выбрать отгрузку из загруженных по UUID
                Dim _list As List(Of iMoySkladDataProvider.clsOperationInfo) = Me.cbxDemand.DataSource

                Dim _item = _list.Find(Function(x) x.UUID.Equals(_op.RefDemandUUID))
                If Not _item Is Nothing Then
                    'нашли
                    Me.cbxDemand.SelectedItem = _item
                    Me.SetOperationParameters(_item)
                    GoTo nx
                End If
            End If
            'поиск отгрузки
            Dim _result = oMsi.GetDemandInfo(DemandName:="", DemandUUID:=_op.RefDemandUUID)
            Select Case _result.Count
                Case 0
                    Me.cbxDemand.DataSource = Nothing
                    Me.btDemand.Text = String.Format("Отгрузка", _result.Count)
                Case Else
                    Me.cbxDemand.DataSource = _result
                    Me.btDemand.Text = String.Format("Отгрузка({0})", _result.Count)
                    Me.SetOperationParameters(_result.First)
            End Select
        Else
            Me.cbxDemand.DataSource = Nothing
            Me.btDemand.Text = "Отгрузка"
        End If
nx:
        'платеж входящий
        If Not String.IsNullOrEmpty(_op.RefFinanceUUID) Then
            If Not Me.cbxPayment.DataSource Is Nothing Then
                'выбрать платеж из загруженных по UUID
                Dim _list As List(Of iMoySkladDataProvider.clsPaymentInfo) = Me.cbxPayment.DataSource

                Dim _item = _list.Find(Function(x) x.UUID.Equals(_op.RefFinanceUUID))
                If Not _item Is Nothing Then
                    'нашли
                    Me.cbxPayment.SelectedItem = _item
                    Return
                End If
            End If

            'поиск платежа
            Dim _result = oMsi.GetPaymentInInfo(PaymentInName:="", PaymentInNameUUID:=_op.RefFinanceUUID)
            Select Case _result.Count
                Case 0
                    Me.btInPayment.Text = String.Format("Вх.платеж", _result.Count)
                    Me.cbxPayment.DataSource = Nothing
                Case Else
                    Me.btInPayment.Text = String.Format("Вх.платеж({0})", _result.Count)
                    Me.cbxPayment.DataSource = _result
            End Select
        Else
            Me.btInPayment.Text = "Вх.платеж"
            Me.cbxPayment.DataSource = Nothing
        End If
    End Sub
    Private Sub cbxDemand_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxDemand.SelectedIndexChanged
        Dim _op As iMoySkladDataProvider.clsOperationInfo = cbxDemand.SelectedItem
        If _op Is Nothing Then Return

        Me.SetOperationParameters(_op)

        'заказ
        If Not String.IsNullOrEmpty(_op.RefOrderUUID) Then
            If Not Me.cbxOrder.DataSource Is Nothing Then
                'выбрать заказ из загруженных по UUID
                Dim _list As List(Of iMoySkladDataProvider.clsOperationInfo) = Me.cbxOrder.DataSource

                Dim _item = _list.Find(Function(x) x.UUID.Equals(_op.RefOrderUUID))
                If Not _item Is Nothing Then
                    'нашли
                    Me.cbxOrder.SelectedItem = _item
                    GoTo nx
                End If
            End If
            'поиск заказа
            Dim _result = oMsi.GetOrderInfo(OrderName:="", OrderUUID:=_op.RefOrderUUID)
            Select Case _result.Count
                Case 0
                    Me.btOrder.Text = String.Format("Заказ", _result.Count)
                    Me.cbxOrder.DataSource = Nothing
                Case Else
                    Me.btOrder.Text = String.Format("Заказ({0})", _result.Count)
                    Me.cbxOrder.DataSource = _result
            End Select
        Else
            Me.btOrder.Text = "Заказ"
            Me.cbxOrder.DataSource = Nothing
        End If
nx:
        'платеж входящий
        If Not String.IsNullOrEmpty(_op.RefFinanceUUID) Then
            If Not Me.cbxPayment.DataSource Is Nothing Then
                'выбрать платеж из загруженных по UUID
                Dim _list As List(Of iMoySkladDataProvider.clsPaymentInfo) = Me.cbxPayment.DataSource

                Dim _item = _list.Find(Function(x) x.UUID.Equals(_op.RefFinanceUUID))
                If Not _item Is Nothing Then
                    'нашли
                    Me.cbxPayment.SelectedItem = _item
                    Return
                End If
            End If

            'поиск платежа
            Dim _result = oMsi.GetPaymentInInfo(PaymentInName:="", PaymentInNameUUID:=_op.RefFinanceUUID)
            Select Case _result.Count
                Case 0
                    Me.btInPayment.Text = String.Format("Вх.платеж", _result.Count)
                    Me.cbxPayment.DataSource = Nothing
                Case Else
                    Me.btInPayment.Text = String.Format("Вх.платеж({0})", _result.Count)
                    Me.cbxPayment.DataSource = _result
            End Select
        Else
            Me.btInPayment.Text = "Вх.платеж"
            Me.cbxPayment.DataSource = Nothing
        End If
    End Sub
    Private Sub cbxPayment_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxPayment.SelectedIndexChanged
        Dim _pay As iMoySkladDataProvider.clsPaymentInfo = cbxPayment.SelectedItem
        If _pay Is Nothing Then Return
        'заказ
        If Not String.IsNullOrEmpty(_pay.RefOrderUUID) Then
            If Not Me.cbxOrder.DataSource Is Nothing Then
                'выбрать заказ из загруженных по UUID
                Dim _list As List(Of iMoySkladDataProvider.clsOperationInfo) = Me.cbxOrder.DataSource

                Dim _item = _list.Find(Function(x) x.UUID.Equals(_pay.RefOrderUUID))
                If Not _item Is Nothing Then
                    'нашли
                    Me.cbxOrder.SelectedItem = _item
                    Me.SetOperationParameters(_item)
                    GoTo nx
                End If
            End If
            'поиск заказа
            Dim _result = oMsi.GetOrderInfo(OrderName:="", OrderUUID:=_pay.RefOrderUUID)
            Select Case _result.Count
                Case 0
                    Me.btOrder.Text = String.Format("Заказ", _result.Count)

                    Me.cbxOrder.DataSource = Nothing
                Case Else
                    Me.btOrder.Text = String.Format("Заказ({0})", _result.Count)

                    Me.cbxOrder.DataSource = _result
                    Me.SetOperationParameters(_result.First)
            End Select
        Else
            Me.btOrder.Text = "Заказ"
            Me.cbxOrder.DataSource = Nothing
        End If

nx:
        'отгрузка
        If Not String.IsNullOrEmpty(_pay.RefDemandUUID) Then
            If Not Me.cbxDemand.DataSource Is Nothing Then
                'выбрать отгрузку из загруженных по UUID
                Dim _list As List(Of iMoySkladDataProvider.clsOperationInfo) = Me.cbxDemand.DataSource

                Dim _item = _list.Find(Function(x) x.UUID.Equals(_pay.RefDemandUUID))
                If Not _item Is Nothing Then
                    'нашли
                    Me.cbxDemand.SelectedItem = _item
                    Me.SetOperationParameters(_item)
                    Return
                End If
            End If
            'поиск отгрузки
            Dim _result = oMsi.GetDemandInfo(DemandName:="", DemandUUID:=_pay.RefDemandUUID)
            Select Case _result.Count
                Case 0
                    Me.cbxDemand.DataSource = Nothing
                    Me.btDemand.Text = String.Format("Отгрузка", _result.Count)
                Case Else
                    Me.cbxDemand.DataSource = _result
                    Me.btDemand.Text = String.Format("Отгрузка({0})", _result.Count)
                    Me.SetOperationParameters(_result.First)
            End Select
        Else
            Me.cbxDemand.DataSource = Nothing
            Me.btDemand.Text = "Отгрузка"
        End If

    End Sub


    Private Sub btClear_Click(sender As Object, e As EventArgs) Handles btClear.Click
        Me.Clear()
    End Sub
    ''' <summary>
    ''' установить дату и агента
    ''' </summary>
    ''' <param name="op"></param>
    ''' <remarks></remarks>
    Private Sub SetOperationParameters(op As iMoySkladDataProvider.clsOperationInfo)
        'агент
        Dim _agentsList As List(Of Service.Agents.AUCTIONDATAAGENT) = Me.lbxAgentList.DataSource
        Dim _agent = _agentsList.Find(Function(x) x.GetAgentID(FieldName:="moysklad", ItemValue:="ProjectUUID").Equals(op.projectUuid))
        If Not _agent Is Nothing Then
            Me.lbxAgentList.SelectedItem = _agent
        Else
            Me.lbxAgentList.SelectedIndex = -1
            Me.lbAgent.Text = "место продажи не задано"
        End If
        'дата
        Me.MonthCalendar1.SelectionStart = op.created
    End Sub

    Private Sub UcClient1_Load(sender As Object, e As EventArgs) Handles UcClient1.Load

    End Sub

    Private oSplash = clsApplicationTypes.SplashScreen


    Private Sub btSearchSell_Click(sender As Object, e As EventArgs) Handles btSearchSell.Click
        If oSelectedAgent Is Nothing Then Return

        Select Case oSelectedAgent.name
            Case "ebay"
                'получить список для ебай агента
                Dim _res = clsApplicationTypes.eBayDataProvider.RequestCurrentTransactions(oSelectedAgent)
                If _res Is Nothing Then
                    MsgBox("eBay не ответил", vbCritical)
                    Return
                End If
                If Not _res.RequestStatus Then
                    MsgBox(_res.RequestMessage, vbCritical)
                    Return
                End If
                If _res.Count = 0 Then
                    MsgBox("На сервере eBay нет неоформленных транзакций", vbInformation)
                    Return
                End If


                Me.PictureBox1.Image = Nothing
                Me.TextBox1.Text = ""
                oSplash.Show()
                'отобрать только неоформленные - подробности в процедуре InStock
                'что уже занесено из учета продаж - проверка остатка БЕЗ РЕЗЕРВА по складам - резерв в заказе на аукцион автоматом снимается
                Dim _message As String = ""
                Me.cbActiveSellList.DataSource = (From c In _res.TransactionItemList Where Me.InStock(c.ItemSKU, _message) = True Select c).ToList
                oSplash.Hide()

                If Not _message = "" Then
                    'сообщение появится для всех уже оформленных
                    MsgBox(_message, vbOKOnly)
                End If

                Me.cbActiveSellList.DisplayMember = "UserString"

                Me.cbActiveSellList.Refresh()

                clsApplicationTypes.BeepYES()
        End Select
    End Sub
    ''' <summary>
    ''' выясняет, что уже занесено из учета продаж - проверка остатка БЕЗ РЕЗЕРВА по складам - резерв в заказе на аукцион автоматом снимается
    ''' </summary>
    ''' <param name="itemSKU"></param>
    ''' <returns></returns>
    Private Function InStock(itemSKU As String, ByRef _message As String) As Boolean
        'Решение - ориентироваться по статусу отгрузки НА ОТПРАВКУ, а все отгрузки ПРОВОДИТЬ 
        'т.е. после оформления образец исчезает со склада, но фактически он не отправлен!!!
        'значит надо оставлять в резерве: при оформлении заказа в нем РЕЗЕРВИРУЮТСЯ позиции
        'т.е. при запросе неоформленных надо ловить те, которые стоят не в резерве, и есть на складе.
        'НО резерв также существует при выставлении на eBay, а значит снятие с этого резерва должно проходить при запросе неоформленных
        'тогда оставшиеся в резерве ждут отправку, а без резерва - подлежат оформлению!
        '21.04.2016

        Dim _ReservCustomerOrderUUID = oSelectedAgent.GetAgentID("moysklad", "ReservCustomerOrderUUID")
        If oMsi Is Nothing Then
            oMsi = clsApplicationTypes.MoySklad(True)
            Return False
        End If

        'снять с резерва общего (фиктивный заказ для выбранного агента)
        If Not _ReservCustomerOrderUUID = "" Then
            Dim _resultStop = oMsi.EndSampleOnAuction(GoodCode:=itemSKU, ReservCustomerOrderUUID:=_ReservCustomerOrderUUID)
        Else
            'заказ резервации отсутствует для выбранного агента
        End If

        'запрос наличия на складе по SKU - без резерва
        Dim _result = oMsi.FindStokQuantity(PartName:="", ShotCode:=itemSKU, WareHouseName:="Внутренний Нарва", IncludeReserved:=False)

        'нет на основном складе отправки, смотрим другие
        If _result.Count = 0 Then
            _result = oMsi.FindStokQuantity(PartName:="", ShotCode:=itemSKU, WareHouseName:="Внутренний Питер", IncludeReserved:=False)
            If _result.Count = 0 Then GoTo ex
        End If

        Dim _qty As Decimal = 0
        For Each t In _result
            _qty += t.Stok
        Next
        If _qty = 0 Then GoTo ex
        Return True

ex:
        _message += String.Format("Образец {0} видимо уже оформлен - нулевое кол-во (без резерва(!)) на складах отправки (Внутренний Нарва и Внутренний Питер){1}", itemSKU, ChrW(13))
        Return False

    End Function

    ''' <summary>
    ''' это выбранный в списке проданных итем на оформление, разных типов
    ''' </summary>
    Private oSoldActiveItem As iSoldItem



    Private Sub cbActiveSellList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbActiveSellList.SelectedIndexChanged
        If cbActiveSellList.SelectedItem Is Nothing Then Return
        oSoldActiveItem = cbActiveSellList.SelectedItem
        Me.MonthCalendar1.SetDate(oSoldActiveItem.CreatedDate)

        Dim _sm = clsApplicationTypes.clsSampleNumber.CreateFromString(oSoldActiveItem.SKU)
        If _sm.CodeIsCorrect Then
            Me.PictureBox1.Image = clsApplicationTypes.SamplePhotoObject.GetMainImage(clsFilesSources.Arhive, _sm, True)
        Else
            Me.PictureBox1.Image = Nothing
        End If

        Me.TextBox1.Text = oSoldActiveItem.ItemTitle
    End Sub
End Class
