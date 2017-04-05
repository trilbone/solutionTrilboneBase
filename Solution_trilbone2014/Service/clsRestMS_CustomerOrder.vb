Public Class clsRestMS_CustomerOrder
    Public Structure strPrices
        Property BasePrice As Decimal
        Property Discount As Decimal
        Property Price As Decimal
    End Structure
    Public Property Description As String
    Public Property CustomerName As String
    Public Property Currency As String
    ''' <summary>
    ''' номер/цена в валюте
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SampleList As List(Of Service.clsApplicationTypes.clsSampleNumber)
    ''' <summary>
    ''' при заполнении с сервера были ошибки
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property HasError As Boolean
    Public Sub New()
        SampleList = New List(Of Service.clsApplicationTypes.clsSampleNumber)
    End Sub
End Class

