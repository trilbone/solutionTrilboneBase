Imports Service
Imports Service.Agents
Imports Service.clsApplicationTypes
Imports System.Linq
Imports Service.ucGoodList
Imports Service.clsSampleDataManager

Public Class ucPaymentDemand
    Private oAgent As AUCTIONDATAAGENT
    Private oMsi As iMoySkladDataProvider
    Private oPayment As iMoySkladDataProvider.clsPaymentInfo
    Dim oOrder As iMoySkladDataProvider.clsOperationInfo
    Dim oDemand As iMoySkladDataProvider.clsOperationInfo
    Private oGoodList As List(Of iMoySkladDataProvider.clsPosition)
    Private oCustomer As iMoySkladDataProvider.clsClientInfo
    Private oPayPalEmailAddress As String
    Dim oOutFeeGoodUUID As String


    Public Event PaymentApproved(sender As Object, e As PaymentCreatedEventArgs)
    Public Class PaymentCreatedEventArgs
        Inherits EventArgs

        Property Payment As iMoySkladDataProvider.clsPaymentInfo
        Property PaymentCurrency As String
        Property PaymentAmount As Decimal
        ''' <summary>
        ''' UUID товара для записи расходов при обналичке
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property OutFeeGoodUUID As String
        Property DocumentsLinked As Boolean
    End Class

    Public Sub New()

        ' Этот вызов является обязательным для конструктора.
        InitializeComponent()

        ' Добавьте все инициализирующие действия после вызова InitializeComponent().

    End Sub

    Public Sub init(Agent As AUCTIONDATAAGENT, msi As iMoySkladDataProvider, Customer As iMoySkladDataProvider.clsClientInfo, Order As iMoySkladDataProvider.clsOperationInfo, Demand As iMoySkladDataProvider.clsOperationInfo, GoodList As List(Of iMoySkladDataProvider.clsPosition))
        oMsi = msi
        oAgent = Agent
        oCustomer = Customer
        oOrder = Order
        oDemand = Demand
        oGoodList = GoodList
        '''загрузить направление платежей
        Me.cbGoPayment.DataSource = oMsi.GetPaymentDestinations
    End Sub

    ''' <summary>
    ''' установить аккаунт получения платежа
    ''' </summary>
    ''' <param name="Accepter"></param>
    ''' <remarks></remarks>
    Public Sub SetAccount(AccepterUUID As String)
        Me.cbGoPayment.SelectedItem = (From c In CType(Me.cbGoPayment.DataSource, List(Of iMoySkladDataProvider.clsEntity)) Where c.UUID.Equals(AccepterUUID) Select c).FirstOrDefault
    End Sub

    ''' <summary>
    ''' установить сумму, валюту, дату платежа
    ''' </summary>
    ''' <param name="Amount"></param>
    ''' <param name="Currency"></param>
    ''' <param name="PaidDate"></param>
    ''' <remarks></remarks>
    Public Sub SetPaimentDetails(Amount As Decimal, Currency As String, PaidDate As Date)
        Me.tbAmount.Text = Amount
        Me.cbCurrency.SelectedItem = Currency
        Me.PaidTimeDateTimePicker.Value = PaidDate
        If oGoodList.Count > 0 Then
            Dim _comm As String = ""
            For Each t In oGoodList
                _comm += t.ActualCode & ", "
            Next
            _comm = _comm.TrimEnd(", ")
            Me.rtbPaymentPurpose.Text = String.Format("Оплата за товар {0}", _comm)
            Dim _order As String = ""
            If Not oOrder Is Nothing Then
                _order = String.Format("за заказ {0}", oOrder.name)
            End If
            Me.rtbPaymentComment.Text = String.Format("Запись платежа {0} по продаже из формы оформления платежа", _order)
        End If
    End Sub


    Private Sub tbCreatePayment_Click(sender As Object, e As EventArgs) Handles tbCreatePayment.Click
        If Me.cbGoPayment.SelectedItem Is Nothing Then
            MsgBox("Выбери куда поступил платеж", vbCritical)
            Return
        End If

        'входящий платеж в МС
        Dim _CustomerUUID = oCustomer.UUID
        Dim _MyCompanyUUID = oAgent.GetAgentID("moysklad", "MyCompanyUUID")
        Dim _ProjectUUID = oAgent.GetAgentID("moysklad", "ProjectUUID")

        ''это направление платежа
        Dim _Account As iMoySkladDataProvider.clsEntity = Me.cbGoPayment.SelectedItem

        ''это получатель
        Dim _AccepterUUID = clsApplicationTypes.CurrentUser.UserPermission.mcuuid
        Dim _CurrencyUUID = oMsi.GetCurrencyUUIDByName(cbCurrency.SelectedItem)
        Dim _amount As Decimal = clsApplicationTypes.ReplaceDecimalSplitter(tbAmount)

        If _amount = 0 Then
            MsgBox("Введи сумму платежа", vbCritical)
            Return
        End If

        'Dim _comm As String = ""
        'For Each t In oGoodList
        '    _comm += t.ActualCode & ", "
        'Next
        '_comm = _comm.TrimEnd(", ")
        Dim _PaymentPurpose As String = Me.rtbPaymentPurpose.Text ' String.Format("Оплата за товар {0}", _comm)
        Dim _PaymentComment As String = Me.rtbPaymentComment.Text ' "Запись продажи из формы учета продаж"
        If String.IsNullOrEmpty(_PaymentComment) Then
            _PaymentComment = "Запись продажи из формы учета продаж"
        End If

        'создать платеж
        oPayment = Me.oMsi.CreateIncomingPayment(AccepterUUID:=_AccepterUUID, AccountUUID:=_Account.UUID, CurrencyUUID:=_CurrencyUUID, Amount:=_amount, CustomerUUID:=_CustomerUUID, MyCompanyUUID:=_MyCompanyUUID, ProjectUUID:=_ProjectUUID, NoFeeIncluded:=True, paymentPurpose:=_PaymentPurpose, Description:=_PaymentComment, PaymentDate:=Me.PaidTimeDateTimePicker.Value)

        If Not oPayment Is Nothing Then
            MsgBox(String.Format("Платеж {0} успешно создан.", oPayment.name), vbOKOnly)
        Else
            MsgBox("Платеж не создан!", vbCritical)
        End If
    End Sub

    Private Sub btImportPayment_Click(sender As Object, e As EventArgs) Handles btImportPayment.Click
        'TODO импорт платежа
    End Sub


    Private Sub btLinkDocuments_Click(sender As Object, e As EventArgs) Handles btLinkDocuments.Click
        If Not oPayment Is Nothing Then
            'надо переделать - взять из  платежа oPayment
            Dim _amount As Decimal = clsApplicationTypes.ReplaceDecimalSplitter(tbAmount)

            'пробуем связать документы
            Dim _linkresult = oMsi.LinkOrderDemandPaymentIn(If(Me.oOrder Is Nothing, Nothing, Me.oOrder.UUID), Me.oDemand.UUID, Me.oPayment.UUID)

            'TODO регистрация в базе трилбон
            'If RegisterInDb() Then

            'End If
            RaiseEvent PaymentApproved(Me, New PaymentCreatedEventArgs With {.Payment = oPayment, .PaymentCurrency = cbCurrency.SelectedItem, .PaymentAmount = _amount, .OutFeeGoodUUID = oOutFeeGoodUUID, .DocumentsLinked = _linkresult})
        Else
            MsgBox("Платеж не создан!", vbCritical)
        End If


        ''изменение отгрузки доп платежи
        'Dim _EbayFeeEndGoodUUID = oAgent.GetAgentID("moysklad", "EbayFeeEnd")
        ''Dim _EbayFeeEndAmount = clsApplicationTypes.ReplaceDecimalSplitter(tbEbayFeeAmount)

        ''НЕ ЗАБЫТЬ ЗАДАТЬ адрес PAYPAL из списка получателей
        'Debug.Assert(Not String.IsNullOrEmpty(oPayPalEmailAddress), "НЕ ЗАБЫТЬ ЗАДАТЬ адрес PAYPAL из списка получателей")

        'Dim _PayPalStartFeeGoodUUID = oAgent.GetAgentID("moysklad.PayPal", "PayPalStrartFee " & oPayPalEmailAddress)
        '' Dim _PayPalStartFeeAmount = clsApplicationTypes.ReplaceDecimalSplitter(tbPayPalFeeAmount)


        'Dim _ShippingInGoodUUID = oAgent.GetAgentID("moysklad", "ShippingIn")
        ''Dim _ShippingInAmount As Decimal = clsApplicationTypes.ReplaceDecimalSplitter(ValueTextBox2)

        ''UUID товара PayPal вывод, коммиссия.  для каждого PAYPAL аккаунта свой. Зависит от выбранного paypal аккаунта для входящего платежа.
        'Dim _PayPalOutFeeAmount As Decimal = clsApplicationTypes.ReplaceDecimalSplitter(tbMoneyOutFee)
        'Dim _PayPalOutFeeGoodUUID = oAgent.GetValue("moysklad.PayPal", "PayPalOutFee " & oPayPalEmailAddress)
        'If _PayPalOutFeeAmount > 0 And String.IsNullOrEmpty(Me.oPayPalEmailAddress) Then
        '    Select Case MsgBox("PalPal адрес не указан, сумма fee не будет учтена, отменить регистрацию?", vbYesNo)
        '        Case MsgBoxResult.No
        '            Return
        '    End Select
        'End If


        '   Me.oMsi.UpdateDemandsAfterCalculate(DemandUUID:=oDemand.UUID, PayPalOutFeeAmount:=0, PayPalOutFeeGoodUUID:="", EbayFeeStartAmount:=0, EbayFeeStartGoodUUID:="", ExportFee:=0, ExportGoodUUID:="", NalogFee:=0, NalogFeeUUID:="", exportQuantity:=0, EbayFeeEndAmount:=_EbayFeeEndAmount, EbayFeeEndGoodUUID:=_EbayFeeEndGoodUUID, PayPalStartFeeAmount:=_PayPalStartFeeAmount, PayPalStartFeeGoodUUID:=_PayPalStartFeeGoodUUID, ShippingInAmount:=_ShippingInAmount, ShippingInGoodUUID:=_ShippingInGoodUUID, ShippingInQty:=1)


    End Sub

    ''' <summary>
    ''' добавить продажу в БД
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function RegisterInDb() As Boolean
        '==========================
        'добавить продажу в БД
        For Each t In Me.oGoodList
            'Dim _ShippingInAmount As Decimal = clsApplicationTypes.ReplaceDecimalSplitter(ValueTextBox2)
            'Dim _EbayFeeEndAmount = clsApplicationTypes.ReplaceDecimalSplitter(tbEbayFeeAmount)
            'Dim _tbPayPalFeeAmount = clsApplicationTypes.ReplaceDecimalSplitter(tbPayPalFeeAmount)

            Dim _GoodAmount As Decimal = Aggregate c In Me.oGoodList Into Sum(c.BasePriceInCurrency)

            Dim EbayAccount As emSLResource
            Select Case oAgent.account
                Case "trilbone"
                    EbayAccount = emSLResource.eBayTrilbone
                Case "nordstarfossils"
                    EbayAccount = emSLResource.eBayNordstar
                Case "trilbone_test"
                    Return False
                Case Else
                    MsgBox(String.Format("Обработка аккаунта {0} из файла агента не задана. Внесите изменения в fmTrilboneEbay.vb строка 598", oAgent.account), vbCritical)
                    Return False
            End Select


            ''первоначальная регистрация продажи камня
            'Dim _res = clsApplicationTypes.SampleDataObject.RegisterSampleToSoldViaEbay(SampleNumber:=t.SampleNumber, clientName:=oCustomer.FullName, clientEmail:=oCustomer.Email, clientMoySkladCode:=oCustomer.MSCode, EbayItemID:="", EbayAccount:=EbayAccount, itemAmount:=_GoodAmount, itemShippingAmount:=_ShippingInAmount, itemauctionfee:=_EbayFeeEndAmount, itemgetmoneyfee:=_tbPayPalFeeAmount, currency:=cbCurrency.SelectedItem)

            'If Not _res Then
            '    MsgBox(String.Format("Образец {0} не удалось зарегистрировать в базе", t.ActualCode), vbCritical)
            'End If
        Next
        Return True
    End Function

    Private Sub cbGoPayment_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbGoPayment.SelectedIndexChanged
        'выбор куда поступает платеж
        Dim _SelectedPayPalEmail = ""
        oOutFeeGoodUUID = oAgent.GetAgentID("moysklad.PayPal", "PayPalOutFee " & _SelectedPayPalEmail)
    End Sub
End Class
