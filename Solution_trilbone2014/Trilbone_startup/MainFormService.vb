Imports Service.clsApplicationTypes

Public Class clsMainOrderService
    Private Shared oActiveOrder As clsOrder

    Public Sub New()
        'регистрация Сервис активного заказа: источник fmMain
        DelegatStoreActiveOrder = _
         New ActiveOrderDelegateFunction(AddressOf GetActiveOrder)
    End Sub

    ''' <summary>
    ''' Исполнитель: Сервис активного заказа
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function GetActiveOrder() As clsOrder
        Return ActiveOrder
    End Function
    ''' <summary>
    ''' метод-исполнитель
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Shared Property ActiveOrder As clsOrder
        Get
            Return oActiveOrder
        End Get
        Set(ByVal value As clsOrder)
            oActiveOrder = value
        End Set
    End Property



End Class
