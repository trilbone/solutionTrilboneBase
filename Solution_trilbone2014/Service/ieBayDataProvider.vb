Imports Service

Public Interface iSoldItem
    ''' <summary>
    ''' дата создания
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property CreatedDate As Date
    ''' <summary>
    ''' список применяемых к продаже fee (вычетов)
    ''' </summary>
    ''' <returns></returns>
    Property FeeList As List(Of iMoySkladDataProvider.clsFee)

    ''' <summary>
    ''' номер камня
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property SKU As String

    ''' <summary>
    ''' торговое название предмета
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property ItemTitle As String
End Interface


''' <summary>
''' описывает получение списка транзакций
''' </summary>
''' <remarks></remarks>
Public Interface ieBayDataProvider
    Structure strAmount
        Property Value As Decimal
        Property Currency As String
        ''' <summary>
        ''' прибавлять можно любую валюту. Левое слагаемое определяет валюту, правое - конвертируется в нее
        ''' </summary>
        ''' <param name="left"></param>
        ''' <param name="right"></param>
        ''' <returns></returns>
        Public Shared Operator +(left As strAmount, right As strAmount) As strAmount
            Dim _new As New strAmount
            If String.IsNullOrEmpty(left.Currency) Then
                _new.Currency = right.Currency
                _new.Value = left.Value + right.Value
            ElseIf Not left.Currency.Equals(right.Currency) Then
                'пересчет валют
                _new.Value = left.Value + clsApplicationTypes.CurrencyConvert(right.Value, right.Currency, left.Currency)
                _new.Currency = left.Currency
            Else
                _new.Value = left.Value + right.Value
                _new.Currency = left.Currency
            End If


            Return _new
        End Operator
    End Structure

    Function RequestCurrentTransactions(agent As Service.Agents.AUCTIONDATAAGENT) As ieBayTransactionList



    ''' <summary>
    ''' описывает элемент транзакции (item)
    ''' </summary>
    ''' <remarks></remarks>
    Interface ieBayTransactionItem
        Inherits iSoldItem
        ''' <summary>
        ''' сколько штук продали
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ReadOnly Property QuantitySold As Integer

        ''' <summary>
        ''' за сколько выставили камень
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ReadOnly Property StartPrice As ieBayDataProvider.strAmount
        ''' <summary>
        ''' список внешних транзакций оплат
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ReadOnly Property ExternalTransactionList As List(Of ieBayDataProvider.ieBayExternalTransaction)

        ''' <summary>
        ''' сколько всего взяли комиссии при получении средств (рассчитано на 1..n оплат одного камня)
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ReadOnly Property ExternalTotalValueFee As strAmount

        ''' <summary>
        ''' сколько стоил чисто зверь в ебай
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ReadOnly Property TransactionPrice As ieBayDataProvider.strAmount
        ''' <summary>
        ''' сколько стоил чисто шиппинг в ебай
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ReadOnly Property ShippingServiceCost As ieBayDataProvider.strAmount

        ''' <summary>
        ''' сумма обработки отправления
        ''' </summary>
        ''' <returns></returns>
        ReadOnly Property HandlingCost As ieBayDataProvider.strAmount

        ''' <summary>
        ''' номер заказа - по нему видимо и будем обьединять продажи
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ReadOnly Property OrderLineItemID As String

        ''' <summary>
        ''' не оплачен зверь
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ReadOnly Property UnpaidItem As Boolean

        '---------
        ReadOnly Property Shipped As Boolean
        ReadOnly Property ShippedDate As Date?
        ReadOnly Property Paid As Boolean
        ReadOnly Property RequestMessage As String
        ReadOnly Property RequestStatus As Boolean
        '-------------
        ''' <summary>
        ''' ебайное название лузера - по нему видимо и будем обьединять продажи
        ''' </summary>
        ''' <returns></returns>
        ReadOnly Property BuyerUserID As String

        ReadOnly Property ItemID As String
        '----------
        ReadOnly Property Title As String
        ReadOnly Property ItemSKU As String
        ''' <summary>
        ''' Всего заплачено
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ReadOnly Property AmountPaidValue As strAmount
        ''' <summary>
        ''' всего к оплате
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ReadOnly Property TransactionPriceValue As strAmount
        ''' <summary>
        ''' оплачено за шиппинг - используем ShippingServiceCost
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ReadOnly Property ActualShippingCost As strAmount
        ''' <summary>
        ''' уплачено за обработку
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ReadOnly Property ActualHandlingCost As strAmount
        ''' <summary>
        ''' коммиссия при окончании
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ReadOnly Property FinalValueFee As strAmount

        ReadOnly Property BuyerMessage As String
        ReadOnly Property PaidTime As Date
        ReadOnly Property PayPalEmailAddress As String
        '------------
        ReadOnly Property Address As iMoySkladDataProvider.clsAddress

        ReadOnly Property Order As ieBayDataProvider.ieBayTransactionOrder
        ''' <summary>
        ''' строка для ЭУ (номер и т.п.)
        ''' </summary>
        ''' <returns></returns>
        ReadOnly Property UserString As String

    End Interface



    ''' <summary>
    ''' описывает транзакцию (1..n items в транзакции)
    ''' </summary>
    ''' <remarks></remarks>
    Interface ieBayTransactionList
        ReadOnly Property RequestMessage As String
        ReadOnly Property RequestStatus As Boolean
        ReadOnly Property Count As Integer
        ''' <summary>
        ''' список итемов в транзакции
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ReadOnly Property TransactionItemList As List(Of ieBayTransactionItem)
        ''' <summary>
        ''' получить список оплаченных и неотправленных транзакций - т.е. на отправку
        ''' </summary>
        ''' <returns></returns>
        ReadOnly Property PaidNotShippedTransactionList As List(Of ieBayTransactionItem)
        ''' <summary>
        ''' запросит список транзакций нужного аккаунта
        ''' </summary>
        ''' <remarks></remarks>
        Function RequestTransactions(agent As Service.Agents.AUCTIONDATAAGENT) As ieBayDataProvider
    End Interface

    ''' <summary>
    ''' описывает заказ (заказ=1 и более транзакций)
    ''' </summary>
    Interface ieBayTransactionOrder
        Enum emOrderStatus
            All
            Active
            Cancelled
            Completed
        End Enum


        ReadOnly Property OrderID As String

        ''' <summary>
        ''' This value indicates the total amount of the order. This amount includes the sale price of each line item, shipping and handling charges, shipping insurance (if offered and selected by the buyer), additional services, and any applied sales tax. This value is returned after the buyer has completed checkout (the CheckoutStatus.Status output field reads 'Complete'). 
        ''' </summary>
        ''' <returns></returns>
        ReadOnly Property AmountPaid As strAmount

        ''' <summary>
        ''' The subtotal amount for the order is the total cost of all order line items. This value does not include any shipping/handling, shipping insurance, or sales tax costs. 
        ''' </summary>
        ''' <returns></returns>
        ReadOnly Property Subtotal As strAmount

        ''' <summary>
        ''' The Total amount equals the Subtotal value plus the shipping/handling, shipping insurance, and sales tax costs. 
        ''' </summary>
        ''' <returns></returns>
        ReadOnly Property Total As strAmount


        ''' <summary>
        ''' при комбинированном шиппинге будет неотрицательное значение, которое сэкономил покупатель  This value indicates the shipping discount experienced by the buyer as a result of creating a Combined Invoice order. This value is returned as 0.00 for single line item orders.
        ''' </summary>
        ''' <returns></returns>
        ReadOnly Property AmountSaved As strAmount

        ''' <summary>
        ''' не ноль, если покупатель получил возврат Amount of the refund issued to the buyer. This field is only returned if the buyer has received a refund from the seller.
        ''' </summary>
        ''' <returns></returns>
        ReadOnly Property RefundAmount As strAmount

        ''' <summary>
        ''' ебайное название лузера
        ''' </summary>
        ''' <returns></returns>
        ReadOnly Property BuyerUserID As String

        ''' <summary>
        ''' при положительном ответе - заказ оплачен по мнению ебай(подробности - в реализации)
        ''' </summary>
        ''' <returns></returns>
        ReadOnly Property CheckoutStatus As Boolean

        ''' <summary>
        ''' статус заказа
        ''' </summary>
        ''' <returns></returns>
        ReadOnly Property OrderStatus As emOrderStatus

        ''' <summary>
        ''' когда отправлен
        ''' </summary>
        ''' <returns></returns>
        ReadOnly Property ShippedTime As Date

        ReadOnly Property Shipped As Boolean

        ReadOnly Property ShippingAddress As iMoySkladDataProvider.clsAddress

        ''' <summary>
        ''' список item заказа - пуст, видимо для одного итема в ордере
        ''' </summary>
        ''' <returns></returns>
        ReadOnly Property TransactionArray As List(Of ieBayTransactionItem)

        ''' <summary>
        ''' кол-во позиций в заказе
        ''' </summary>
        ''' <returns></returns>
        ReadOnly Property TransactionCount As Integer

    End Interface
    ''' <summary>
    ''' описывает внешнюю транзакцию (оплата)
    ''' </summary>
    ''' <remarks></remarks>
    Interface ieBayExternalTransaction
        Enum emTransactionStatus
            succeeded
            pending
            failed
            notapplied
        End Enum
        ReadOnly Property ExternalTransactionStatus As emTransactionStatus
        ReadOnly Property ExternalTransactionID As String

        ''' <summary>
        ''' комиссия пайпал
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ReadOnly Property ExternalFeeAmount As strAmount

        ''' <summary>
        ''' дата оплаты
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ReadOnly Property ExternalTransactionTime As Date

        ''' <summary>
        ''' уплачено всего покупателем (brutto)
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ReadOnly Property PaymentOrRefundAmount As strAmount


    End Interface

End Interface
