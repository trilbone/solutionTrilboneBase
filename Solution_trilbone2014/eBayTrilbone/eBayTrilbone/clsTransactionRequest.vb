'Imports eBay.Service.Call
'Imports eBay.Service.Core.Sdk

'Imports eBay.Service.Core.Soap
Imports Service.com.ebay.developer
Imports Service.com.ebay
Imports System.Runtime.CompilerServices
Imports Service
Imports ClsTrilboneEbayService




Public Class clsTransactionOrder
    Inherits OrderType
    Implements Service.ieBayDataProvider.ieBayTransactionOrder
    Public Sub New(order As OrderType)
        MyBase.New()
        With Me
            .AdjustmentAmount = order.AdjustmentAmount
            .AmountPaid = order.AmountPaid
            .AmountSaved = order.AmountSaved
            .Any = order.Any
            .BundlePurchase = order.BundlePurchase
            .BundlePurchaseSpecified = order.BundlePurchaseSpecified
            .BuyerCheckoutMessage = order.BuyerCheckoutMessage
            .BuyerPackageEnclosures = order.BuyerPackageEnclosures
            .BuyerTaxIdentifier = order.BuyerTaxIdentifier
            .BuyerUserID = order.BuyerUserID
            .CancelDetail = order.CancelDetail
            .CancelReason = order.CancelReason
            .CancelReasonDetails = order.CancelReasonDetails
            .CancelStatus = order.CancelStatus
            .CancelStatusSpecified = order.CancelStatusSpecified
            .CheckoutStatus = order.CheckoutStatus
            .CreatedTime = order.CreatedTime
            .CreatedTimeSpecified = order.CreatedTimeSpecified
            .CreatingUserRole = order.CreatingUserRole
            .CreatingUserRoleSpecified = order.CreatingUserRoleSpecified
            .EIASToken = order.EIASToken
            .ExtendedOrderID = order.ExtendedOrderID
            .ExternalTransaction = order.ExternalTransaction
            .IntegratedMerchantCreditCardEnabled = order.IntegratedMerchantCreditCardEnabled
            .IntegratedMerchantCreditCardEnabledSpecified = order.IntegratedMerchantCreditCardEnabledSpecified
            .IsMultiLegShipping = order.IsMultiLegShipping
            .IsMultiLegShippingSpecified = order.IsMultiLegShippingSpecified
            .LogisticsPlanType = order.LogisticsPlanType
            .MonetaryDetails = order.MonetaryDetails
            .MultiLegShippingDetails = order.MultiLegShippingDetails
            .OrderID = order.OrderID
            .OrderStatus = order.OrderStatus
            .OrderStatusSpecified = order.OrderStatusSpecified
            .PaidTime = order.PaidTime
            .PaidTimeSpecified = order.PaidTimeSpecified
            .PaymentHoldDetails = order.PaymentHoldDetails
            .PaymentHoldStatus = order.PaymentHoldStatus
            .PaymentHoldStatusSpecified = order.PaymentHoldStatusSpecified
            .PaymentMethods = order.PaymentMethods
            .PickupDetails = order.PickupDetails
            .PickupMethodSelected = order.PickupMethodSelected
            .RefundAmount = order.RefundAmount
            .RefundArray = order.RefundArray
            .RefundStatus = order.RefundStatus
            .SellerEIASToken = order.SellerEIASToken
            .SellerEmail = order.SellerEmail
            .SellerUserID = order.SellerUserID
            .ShippedTime = order.ShippedTime
            .ShippedTimeSpecified = order.ShippedTimeSpecified
            .ShippingAddress = order.ShippingAddress
            .ShippingConvenienceCharge = order.ShippingConvenienceCharge
            .ShippingDetails = order.ShippingDetails
            .ShippingServiceSelected = order.ShippingServiceSelected
            .Subtotal = order.Subtotal
            .Total = order.Total
            'если зверь один, то значение отсутствует - если много, проверить!
            .TransactionArray = order.TransactionArray
        End With

    End Sub

    Private ReadOnly Property ieBayTransactionOrder_OrderID As String Implements ieBayDataProvider.ieBayTransactionOrder.OrderID
        Get
            Return Me.OrderID
        End Get
    End Property

    Private ReadOnly Property ieBayTransactionOrder_AmountPaid As ieBayDataProvider.strAmount Implements ieBayDataProvider.ieBayTransactionOrder.AmountPaid
        Get
            Return Me.AmountPaid.Amount
        End Get
    End Property

    Private ReadOnly Property ieBayTransactionOrder_Subtotal As ieBayDataProvider.strAmount Implements ieBayDataProvider.ieBayTransactionOrder.Subtotal
        Get
            Return Me.Subtotal.Amount
        End Get
    End Property

    Private ReadOnly Property ieBayTransactionOrder_Total As ieBayDataProvider.strAmount Implements ieBayDataProvider.ieBayTransactionOrder.Total
        Get
            Return Me.Total.Amount
        End Get
    End Property

    Private ReadOnly Property ieBayTransactionOrder_AmountSaved As ieBayDataProvider.strAmount Implements ieBayDataProvider.ieBayTransactionOrder.AmountSaved
        Get
            Return Me.AmountSaved.Amount
        End Get
    End Property

    Private ReadOnly Property ieBayTransactionOrder_RefundAmount As ieBayDataProvider.strAmount Implements ieBayDataProvider.ieBayTransactionOrder.RefundAmount
        Get
            Return Me.RefundAmount.Amount
        End Get
    End Property

    Private ReadOnly Property ieBayTransactionOrder_BuyerUserID As String Implements ieBayDataProvider.ieBayTransactionOrder.BuyerUserID
        Get
            Return Me.BuyerUserID
        End Get
    End Property

    Private ReadOnly Property ieBayTransactionOrder_CheckoutStatus As Boolean Implements ieBayDataProvider.ieBayTransactionOrder.CheckoutStatus
        Get
            If Me.CheckoutStatus.Status = CompleteStatusCodeType.Complete Then
                Return True
            Else
                Return False
            End If
        End Get
    End Property

    Private ReadOnly Property ieBayTransactionOrder_OrderStatus As ieBayDataProvider.ieBayTransactionOrder.emOrderStatus Implements ieBayDataProvider.ieBayTransactionOrder.OrderStatus
        Get
            Select Case Me.OrderStatus
                Case OrderStatusCodeType.Active
                    Return ieBayDataProvider.ieBayTransactionOrder.emOrderStatus.Active
                Case OrderStatusCodeType.All
                    Return ieBayDataProvider.ieBayTransactionOrder.emOrderStatus.All
                Case OrderStatusCodeType.Authenticated
                    Return ieBayDataProvider.ieBayTransactionOrder.emOrderStatus.All
                Case OrderStatusCodeType.Cancelled
                    Return ieBayDataProvider.ieBayTransactionOrder.emOrderStatus.Cancelled
                Case OrderStatusCodeType.CancelPending
                    Return ieBayDataProvider.ieBayTransactionOrder.emOrderStatus.Cancelled
                Case OrderStatusCodeType.Completed
                    Return ieBayDataProvider.ieBayTransactionOrder.emOrderStatus.Completed
                Case OrderStatusCodeType.CustomCode
                    Return ieBayDataProvider.ieBayTransactionOrder.emOrderStatus.All
                Case OrderStatusCodeType.Default
                    Return ieBayDataProvider.ieBayTransactionOrder.emOrderStatus.All
                Case OrderStatusCodeType.Inactive
                    Return ieBayDataProvider.ieBayTransactionOrder.emOrderStatus.All
                Case OrderStatusCodeType.InProcess
                    Return ieBayDataProvider.ieBayTransactionOrder.emOrderStatus.Active
                Case OrderStatusCodeType.Invalid
                    Return ieBayDataProvider.ieBayTransactionOrder.emOrderStatus.Cancelled
                Case OrderStatusCodeType.Shipped
                    Return ieBayDataProvider.ieBayTransactionOrder.emOrderStatus.All
                Case Else
                    Return ieBayDataProvider.ieBayTransactionOrder.emOrderStatus.Cancelled
            End Select
        End Get
    End Property

    Private ReadOnly Property ieBayTransactionOrder_ShippedTime As Date Implements ieBayDataProvider.ieBayTransactionOrder.ShippedTime
        Get
            If Me.ShippedTimeSpecified Then
                Return Me.ShippedTime
            Else
                'завтрашний день
                Return Today.AddDays(1)
            End If
        End Get
    End Property
    Private ReadOnly Property ieBayTransactionOrder_Shipped As Boolean Implements ieBayDataProvider.ieBayTransactionOrder.Shipped
        Get
            Return Me.ShippedTimeSpecified
        End Get
    End Property

    Private ReadOnly Property ieBayTransactionOrder_ShippingAddress As iMoySkladDataProvider.clsAddress Implements ieBayDataProvider.ieBayTransactionOrder.ShippingAddress
        Get
            Return Me.ShippingAddress.iAddress(Me.SellerEmail)
        End Get
    End Property

    Private ReadOnly Property ieBayTransactionOrder_TransactionArray As List(Of ieBayDataProvider.ieBayTransactionItem) Implements ieBayDataProvider.ieBayTransactionOrder.TransactionArray
        Get
            Return (From c As TransactionType In Me.TransactionArray Select clsTransactionItem.CreateInstance(c)).Cast(Of ieBayDataProvider.ieBayTransactionItem).ToList
        End Get
    End Property

    Public ReadOnly Property TransactionCount As Integer Implements ieBayDataProvider.ieBayTransactionOrder.TransactionCount
        Get
            Return Me.TransactionArray.Count
        End Get
    End Property






End Class

''' <summary>
''' управляет получением транзакций с сервера
''' </summary>
''' <remarks></remarks>
Public Class clsTransactionRequest
    Implements Service.ieBayDataProvider.ieBayTransactionList

    Private oTransactionResponse As GetSellerTransactionsResponseType
    Private oOrderResponse As GetOrdersResponseType

    Private oAPIcontext As eBayAPIInterfaceService
    Private oRequestMessage As String
    Private oAgent As Service.Agents.AUCTIONDATAAGENT

    ReadOnly Property RequestMessage As String Implements Service.ieBayDataProvider.ieBayTransactionList.RequestMessage
        Get
            Return oRequestMessage
        End Get
    End Property

    ''' <summary>
    ''' получить список транзакций
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private ReadOnly Property TransactionList As List(Of Service.ieBayDataProvider.ieBayTransactionItem) Implements ieBayDataProvider.ieBayTransactionList.TransactionItemList
        Get
            Dim _transactionList As New List(Of clsTransactionItem)
            'запроса небыло
            If oAgent Is Nothing Then Return _transactionList.Cast(Of ieBayDataProvider.ieBayTransactionItem).ToList
            Dim _ReadySampleDBContext = clsApplicationTypes.SampleDataObject.GetdbReadySampleObjectContext
            For Each t As TransactionType In Me.oTransactionResponse.TransactionArray
                Dim _tmp = clsTransactionItem.CreateInstance(t)
                If _tmp.RequestStatus Then
                    'добавить в вывод
                    _transactionList.Add(_tmp)
                End If
            Next

            Return _transactionList.Cast(Of ieBayDataProvider.ieBayTransactionItem).ToList
        End Get
    End Property

    ''' <summary>
    ''' получить список оплаченных транзакций - т.е. на отправку
    ''' </summary>
    ''' <returns></returns>
    Private ReadOnly Property PaidNotShippedTransactionList As List(Of Service.ieBayDataProvider.ieBayTransactionItem) Implements ieBayDataProvider.ieBayTransactionList.PaidNotShippedTransactionList
        Get
            Return (From c In Me.TransactionList Where (c.Paid = True) And (c.Shipped = False) Select c).ToList
        End Get
    End Property



    ''' <summary>
    ''' запрос транзакций
    ''' </summary>
    ''' <param name="agent"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function RequestTransactions(agent As Service.Agents.AUCTIONDATAAGENT) As ieBayDataProvider Implements ieBayDataProvider.ieBayTransactionList.RequestTransactions
        Return clsTransactionRequest.CreateInstance(agent)
    End Function

    ''' <summary>
    '''выполняет запрос к ebay
    ''' </summary>
    ''' <param name="agent"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CreateInstance(agent As Service.Agents.AUCTIONDATAAGENT) As clsTransactionRequest
        Dim _out As New clsTransactionRequest
        _out.oAgent = agent

        _out.oAPIcontext = Service.Agents.clsAgentEbayParameters.CreateInstance(agent).ApiContext

        'Dim _Transaction As New GetSellerTransactionsCall(_out.oAPIcontext)
        Dim _Transaction As New GetSellerTransactionsRequestType()
        _Transaction.Version = "983"
        '_Transaction.DetailLevelList = New DetailLevelCodeTypeCollection()
        '_Transaction.DetailLevelList.Add(DetailLevelCodeType.ReturnAll)
        _Transaction.DetailLevel = {DetailLevelCodeType.ReturnAll}
        _Transaction.IncludeFinalValueFee = True
        _Transaction.IncludeContainingOrder = True
        _Transaction.IncludeCodiceFiscale = True
        _Transaction.IncludeContainingOrder = True

        Try
            '    ' Make the call to GeteBayOfficialTime
            '    Dim request As New GeteBayOfficialTimeRequestType()
            '    request.Version = "405"
            '    Dim response As GeteBayOfficialTimeResponseType = service.GeteBayOfficialTime(request)
            '_Transaction.Execute()
            _out.oTransactionResponse = _out.oAPIcontext.GetSellerTransactions(_Transaction)
            If _out.Count = 0 Then
                _out.oRequestMessage = "Нет текущих транзакций " & "// запрашивали " & agent.name
            Else
                _out.oRequestMessage = "Ok"
            End If

            Return _out

        Catch ex As Exception
            _out.oRequestMessage = "Запрос транзакций в eBay вернул ошибку: " & ex.Message & "// запрашивали " & agent.name
            Return Nothing
        End Try

    End Function

    ' ''' <summary>
    ' ''' номер заказа
    ' ''' </summary>
    ' ''' <param name="itemID"></param>
    ' ''' <returns></returns>
    ' ''' <remarks></remarks>
    'Public Function GetOrderLineItemID(itemID As String) As String
    '    Dim _tr = Me.GetTransaction(itemID)
    '    If _tr Is Nothing Then Return ""
    '    Return _tr.OrderLineItemID
    'End Function


    ''' <summary>
    ''' RequestStatus
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property IsSuccess As Boolean Implements Service.ieBayDataProvider.ieBayTransactionList.RequestStatus
        Get
            If Me.oTransactionResponse.Ack = AckCodeType.Success Then Return True
            Return False
        End Get
    End Property
    ''' <summary>
    ''' Count
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Count As Integer Implements Service.ieBayDataProvider.ieBayTransactionList.Count
        Get
            Return Me.oTransactionResponse.TransactionArray.Count
        End Get
    End Property


    'Public Function GetTransaction(itemID As String) As TransactionType
    '    Dim _out = (From c As TransactionType In oTransactionResponse.TransactionArray Where c.Item.ItemID = itemID Select c).ToList
    '    If _out.Count = 0 Then Return Nothing
    '    Return _out.First
    'End Function



End Class


Public Class clsTransactionItem
    Implements Service.ieBayDataProvider.ieBayTransactionItem
    Dim oRequestStatus As Boolean
    Dim oRequestMessage As String
    Dim oPaid As Boolean
    Dim oShipped As Boolean
    Dim oItemID As String
    Dim oOrder As clsTransactionOrder
    Dim oExternal As List(Of clsExternalTransaction)
    Dim oShippedDate As Date?

    ''' <summary>
    ''' заполняется позже, когда выясняется агент, создавший обьект
    ''' </summary>
    ''' <returns></returns>
    Public Property FeeList As List(Of iMoySkladDataProvider.clsFee) Implements iSoldItem.FeeList

    Public Property SKU As String Implements iSoldItem.SKU

    Public Property ItemTitle As String Implements iSoldItem.ItemTitle


    ''' <summary>
    ''' список внешних транзакций оплат
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property ExternalTransactionList As List(Of ieBayDataProvider.ieBayExternalTransaction) Implements ieBayDataProvider.ieBayTransactionItem.ExternalTransactionList
        Get
            Return oExternal.Cast(Of ieBayDataProvider.ieBayExternalTransaction).ToList
        End Get
    End Property

    ''' <summary>
    ''' для отображения в ЭУ
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property UserString As String Implements ieBayDataProvider.ieBayTransactionItem.UserString
        Get
            Dim _out As String = String.Format("{0} {3} {2} {1} {4}", Me.ItemSKU, If(Me.Shipped, "ОТПРАВЛЕН", "на отправку"), If(Me.Paid, "ОПЛАЧЕН", "ждем оплату"), If(Me.RequestStatus, "", "ошибка запроса"), If(Me.AmountPaidValue.Value = 0, "", "оплачено: " & Me.TransactionPrice.Value & Me.TransactionPrice.Currency & "+" & Me.ShippingServiceCost.Value & Me.ShippingServiceCost.Currency) & "=" & Me.AmountPaidValue.Value)
            Return _out
        End Get
    End Property

    Public Shared Function CreateInstance(trans As TransactionType) As clsTransactionItem
        Dim _new As New clsTransactionItem

        With _new
            If trans Is Nothing Then
                .oRequestMessage = String.Format("Не удалось получить данные транзакции: {0}{1}", .oItemID, ChrW(13))
                .oRequestStatus = False
                Return _new
            End If
            .Transaction = trans
            .oItemID = trans.Item.ItemID
            .oRequestMessage = "Ok"
            .oRequestStatus = True
            .oPaid = trans.PaidTimeSpecified
            .oShipped = trans.ShippedTimeSpecified
            If trans.ShippedTimeSpecified Then
                .oShippedDate = trans.ShippedTime
            Else
                .oShippedDate = Nothing
            End If

            .oOrder = New clsTransactionOrder(trans.ContainingOrder)
            'внешние оплаты
            .oExternal = (From c In trans.ExternalTransaction Select New clsExternalTransaction(c)).ToList

            If trans.Buyer Is Nothing Then
                .oRequestMessage = String.Format(" Не удалось получить данные транзакции - компонент Buyer: {0}{1}", .oItemID, ChrW(13))
                .oRequestStatus = False
            End If

            If trans.Buyer.BuyerInfo Is Nothing Then
                .oRequestMessage += String.Format(" Не удалось получить данные транзакции - компонент Buyer.BuyerInfo: {0}{1}", .oItemID, ChrW(13))
                .oRequestStatus = False
            End If

            If trans.Buyer.BuyerInfo.ShippingAddress Is Nothing Then
                .oRequestMessage += String.Format(" Не удалось получить данные транзакции - компонент Buyer.BuyerInfo.ShippingAddress: {0}{1}", .oItemID, ChrW(13))
                .oRequestStatus = False
            End If
            .FeeList = New List(Of iMoySkladDataProvider.clsFee)
            .SKU = trans.Item.SKU
            .ItemTitle = trans.Item.Title
        End With
        Return _new
    End Function



    ''' <summary>
    ''' не оплачен зверь
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property UnpaidItem As Boolean Implements ieBayDataProvider.ieBayTransactionItem.UnpaidItem
        Get
            If Me.Transaction.UnpaidItem Is Nothing Then Return False
            Return True
        End Get
    End Property




    ''' <summary>
    ''' номер заказа
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property OrderLineItemID As String Implements ieBayDataProvider.ieBayTransactionItem.OrderLineItemID
        Get
            Return Me.Transaction.OrderLineItemID
        End Get
    End Property


    ''' <summary>
    ''' сколько штук продали
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property QuantitySold As Integer Implements ieBayDataProvider.ieBayTransactionItem.QuantitySold
        Get
            Return Me.Transaction.Item.SellingStatus.QuantitySold
        End Get
    End Property

    ''' <summary>
    ''' за сколько выставили камень
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property StartPrice As ieBayDataProvider.strAmount Implements ieBayDataProvider.ieBayTransactionItem.StartPrice
        Get
            Return Me.Transaction.Item.StartPrice.Amount
        End Get
    End Property
    ''' <summary>
    ''' сколько стоил чисто шиппинг в ебай
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property ShippingServiceCost As ieBayDataProvider.strAmount Implements ieBayDataProvider.ieBayTransactionItem.ShippingServiceCost
        Get
            Return Me.Transaction.ActualShippingCost.Amount
        End Get
    End Property

    ''' <summary>
    ''' сколько стоила обработка отправления
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property HandlingCost As ieBayDataProvider.strAmount Implements ieBayDataProvider.ieBayTransactionItem.HandlingCost
        Get
            Return Me.Transaction.ActualHandlingCost.Amount
        End Get
    End Property

    ''' <summary>
    ''' сколько стоил чисто зверь в ебай
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property TransactionPrice As ieBayDataProvider.strAmount Implements ieBayDataProvider.ieBayTransactionItem.TransactionPrice
        Get
            Return Me.Transaction.TransactionPrice.Amount
        End Get
    End Property


    ''' <summary>
    ''' сколько всего взяли комиссии при получении средств (рассчитано на 1..n оплат одного камня)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property ExternalTotalValueFee As ieBayDataProvider.strAmount Implements ieBayDataProvider.ieBayTransactionItem.ExternalTotalValueFee
        Get
            Dim _out As New ieBayDataProvider.strAmount
            For Each t In Me.ExternalTransactionList
                _out += t.ExternalFeeAmount
            Next

            Return _out
        End Get
    End Property


    Public ReadOnly Property ItemId As String Implements ieBayDataProvider.ieBayTransactionItem.ItemID
        Get
            Return oItemID
        End Get
    End Property


    Public ReadOnly Property ShippedDate As Date? Implements ieBayDataProvider.ieBayTransactionItem.ShippedDate
        Get
            Return oShippedDate
        End Get
    End Property

    ''' <summary>
    ''' отправлен
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Shipped As Boolean Implements ieBayDataProvider.ieBayTransactionItem.Shipped
        Get
            Return oShipped
        End Get
    End Property
    ''' <summary>
    ''' оплачен
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Paid As Boolean Implements ieBayDataProvider.ieBayTransactionItem.Paid
        Get
            Return oPaid
        End Get
    End Property

    ''' <summary>
    ''' информация о запросе
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property RequestMessage As String Implements ieBayDataProvider.ieBayTransactionItem.RequestMessage
        Get
            Return oRequestMessage
        End Get
    End Property

    ''' <summary>
    ''' статус запроса
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property RequestStatus As Boolean Implements ieBayDataProvider.ieBayTransactionItem.RequestStatus
        Get
            Return oRequestStatus
        End Get
    End Property

    Public Property Transaction As TransactionType
    ''' <summary>
    ''' описавние
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property Title As String Implements ieBayDataProvider.ieBayTransactionItem.Title
        Get
            If Transaction Is Nothing Then Return "no transaction"
            Return Transaction.Item.Title
        End Get
    End Property

    ReadOnly Property ItemSKU As String Implements ieBayDataProvider.ieBayTransactionItem.ItemSKU
        Get
            If Transaction Is Nothing Then Return "no transaction"
            Return Transaction.Item.SKU
        End Get
    End Property
    ''' <summary>
    ''' оплачено
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property AmountPaidValue As ieBayDataProvider.strAmount Implements ieBayDataProvider.ieBayTransactionItem.AmountPaidValue
        Get
            If Transaction Is Nothing Then Return Nothing
            Return Transaction.AmountPaid.Amount
        End Get
    End Property

  
    ''' <summary>
    ''' сумма к оплате
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property TransactionPriceValue As ieBayDataProvider.strAmount Implements ieBayDataProvider.ieBayTransactionItem.TransactionPriceValue
        Get
            If Transaction Is Nothing Then Return Nothing
            Return Transaction.TransactionPrice.Amount
        End Get
    End Property

    

    ''' <summary>
    ''' оплачено за шиппинг
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property ActualShippingCost As ieBayDataProvider.strAmount Implements ieBayDataProvider.ieBayTransactionItem.ActualShippingCost
        Get
            If Transaction Is Nothing Then Return Nothing
           Return Transaction.ActualShippingCost.Amount

        End Get
    End Property

   

    ''' <summary>
    ''' уплачено за обработку
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property ActualHandlingCost As ieBayDataProvider.strAmount Implements ieBayDataProvider.ieBayTransactionItem.ActualHandlingCost
        Get
            If Transaction Is Nothing Then Return Nothing
            Return Transaction.ActualHandlingCost.Amount
        End Get
    End Property

    

    ''' <summary>
    ''' коммиссия при окончании
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property FinalValueFee As ieBayDataProvider.strAmount Implements ieBayDataProvider.ieBayTransactionItem.FinalValueFee
        Get
            If Transaction Is Nothing Then Return Nothing
            Return Transaction.FinalValueFee.Amount
        End Get
    End Property

   

    ''' <summary>
    ''' дата транзакции
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property CreatedDate As Date Implements ieBayDataProvider.ieBayTransactionItem.CreatedDate
        Get
            If Transaction Is Nothing Then Return "no transaction"
            Return Transaction.CreatedDate
        End Get
    End Property

    ''' <summary>
    ''' сообщение покупателя
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property BuyerMessage As String Implements ieBayDataProvider.ieBayTransactionItem.BuyerMessage
        Get
            If Transaction Is Nothing Then Return "no transaction"
            Return Transaction.BuyerMessage
        End Get
    End Property

    ReadOnly Property PaidTime As Date Implements ieBayDataProvider.ieBayTransactionItem.PaidTime
        Get
            If Transaction Is Nothing Then Return "no transaction"
            Return Transaction.PaidTime
        End Get
    End Property

    ReadOnly Property PayPalEmailAddress As String Implements ieBayDataProvider.ieBayTransactionItem.PayPalEmailAddress
        Get
            If Transaction Is Nothing Then Return "no transaction"
            Return Transaction.PayPalEmailAddress
        End Get
    End Property


    Private ReadOnly Property BuyerEmail As String
        Get
            If Not String.IsNullOrEmpty(Me.Buyer.Email) Then
                Return Me.Buyer.Email
            End If
            If Not String.IsNullOrEmpty(Me.Buyer.BillingEmail) Then
                Return Me.Buyer.BillingEmail
            End If
            'If Not String.IsNullOrEmpty(Me.em) Then
            '    Return Me.Buyer.BillingEmail
            'End If

            Return ""
        End Get
    End Property


    ''' <summary>
    ''' покупатель
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property Buyer As UserType
        Get
            If Transaction Is Nothing Then Return New UserType
            Return Transaction.Buyer
        End Get
    End Property

    ''' <summary>
    ''' товар
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property Item As ItemType
        Get
            If Transaction Is Nothing Then Return Nothing
            Return Transaction.Item
        End Get
    End Property

    ''' <summary>
    ''' адрес клиента
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property Address As Service.iMoySkladDataProvider.clsAddress Implements ieBayDataProvider.ieBayTransactionItem.Address
        Get
            Return Me.Buyer.BuyerInfo.ShippingAddress.iAddress(Me.BuyerEmail)
        End Get
    End Property


    ''' <summary>
    ''' вернет привязанный заказ
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property Order As ieBayDataProvider.ieBayTransactionOrder Implements ieBayDataProvider.ieBayTransactionItem.Order
        Get

            Return oOrder
        End Get
    End Property

    Public ReadOnly Property BuyerUserID As String Implements ieBayDataProvider.ieBayTransactionItem.BuyerUserID
        Get
            Return Me.Buyer.UserID
        End Get
    End Property
End Class

Public Class clsExternalTransaction
    Inherits ExternalTransactionType
    Implements ieBayDataProvider.ieBayExternalTransaction


    Public Sub New(input As ExternalTransactionType)
        MyBase.New()
        With Me
            .FeeOrCreditAmount = input.FeeOrCreditAmount
            .ExternalTransactionID = input.ExternalTransactionID
            .ExternalTransactionStatus = input.ExternalTransactionStatus
            .ExternalTransactionStatusSpecified = input.ExternalTransactionStatusSpecified
            .ExternalTransactionTime = input.ExternalTransactionTime
            .ExternalTransactionTimeSpecified = input.ExternalTransactionTimeSpecified
            .PaymentOrRefundAmount = input.PaymentOrRefundAmount

        End With
    End Sub

    ''' <summary>
    ''' комиссия пайпал
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private ReadOnly Property FeeAmount As ieBayDataProvider.strAmount Implements ieBayDataProvider.ieBayExternalTransaction.ExternalFeeAmount
        Get

            Return Me.FeeOrCreditAmount.Amount
        End Get
    End Property

    Private ReadOnly Property TransactionID As String Implements ieBayDataProvider.ieBayExternalTransaction.ExternalTransactionID
        Get
            Return Me.ExternalTransactionID
        End Get
    End Property

    Private ReadOnly Property TransactionStatus As ieBayDataProvider.ieBayExternalTransaction.emTransactionStatus Implements ieBayDataProvider.ieBayExternalTransaction.ExternalTransactionStatus
        Get
            If Not Me.ExternalTransactionStatusSpecified Then
                Return ieBayDataProvider.ieBayExternalTransaction.emTransactionStatus.notapplied
            End If
            Select Case Me.ExternalTransactionStatus
                Case PaymentTransactionStatusCodeType.Succeeded
                    Return ieBayDataProvider.ieBayExternalTransaction.emTransactionStatus.succeeded
                Case PaymentTransactionStatusCodeType.Pending
                    Return ieBayDataProvider.ieBayExternalTransaction.emTransactionStatus.pending
                Case PaymentTransactionStatusCodeType.Failed
                    Return ieBayDataProvider.ieBayExternalTransaction.emTransactionStatus.failed
                Case Else
                    Return ieBayDataProvider.ieBayExternalTransaction.emTransactionStatus.notapplied
            End Select
        End Get
    End Property

    Private ReadOnly Property TransactionTime As Date Implements ieBayDataProvider.ieBayExternalTransaction.ExternalTransactionTime
        Get
            If Not Me.ExternalTransactionTimeSpecified Then
                Return Now.AddDays(1)
            End If
            Return Me.ExternalTransactionTime
        End Get
    End Property
    ''' <summary>
    ''' всего уплатил клиент
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private ReadOnly Property PaymentAmount As ieBayDataProvider.strAmount Implements ieBayDataProvider.ieBayExternalTransaction.PaymentOrRefundAmount
        Get
            Return Me.PaymentOrRefundAmount.Amount
        End Get
    End Property
End Class