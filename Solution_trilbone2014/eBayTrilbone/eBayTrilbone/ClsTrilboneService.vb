Imports Service
Imports Service.clsApplicationTypes
'Imports eBay.Service.Core.Soap
Imports Service.com.ebay.developer
Imports Service.com.ebay
Imports Service.Agents
Imports eBaySoapExtention
Imports System.Runtime.CompilerServices

Public Module eBaySoapExtention

    <Extension()>
    Public Function Amount(ByRef a As AmountType) As ieBayDataProvider.strAmount
        Dim _out As New ieBayDataProvider.strAmount
        If a Is Nothing Then Return _out
        _out.Value = a.Value
        _out.Currency = a.currencyID.ToString
        Return _out
    End Function

    <Extension()>
    Public Function ItemTitle(ByRef a As TransactionType) As String
        If a Is Nothing Then Return ""
        If a.Item Is Nothing Then Return ""
        Return a.Item.Title
    End Function

    ''' <summary>
    ''' преобразователь типа адреса во внутренний формат
    ''' </summary>
    ''' <param name="a"></param>
    ''' <returns></returns>
    <Extension()>
    Public Function iAddress(ByRef a As AddressType, email As String) As iMoySkladDataProvider.clsAddress
        Dim _address = New Service.iMoySkladDataProvider.clsAddress
        If a Is Nothing Then Return New iMoySkladDataProvider.clsAddress With {.email = email}
        With _address
            .Name = String.Format("{0} {1}", a.Name, a.LastName)
            .FullAddress += .Name & ChrW(13)

            .Street = String.Format("{0} {1} {2}", a.Street, a.Street1, a.Street2, ChrW(13))
            .FullAddress += .Street & ChrW(13)

            .PostIndex = a.PostalCode
            .City = a.CityName
            .FullAddress += String.Format("{0} {0}", .PostIndex, .Street) & ChrW(13)

            .State = a.StateOrProvince
            .FullAddress += .State & ChrW(13)

            .Country = a.CountryName
            .FullAddress += .Country & ChrW(13)

            .Phone = a.Phone
            .FullAddress += String.Format("{0}{2}{1}{2}", .Phone, a.Phone2, ChrW(13))

            .email = email
        End With
        Return _address
    End Function
End Module


Public Class ClsTrilboneEbayService
    Implements Service.ieBayDataProvider
    Public Sub New()
        '. сервис формы fmMoySklad
        'привязываем делегат к функции
        'передаем делегат (регестрируем) и список в сервисном классе
        Global.Service.clsApplicationTypes.DelegateStoreApplicationForm _
            (emFormsList.fmTrilboneEbay) =
            New ApplicationFormDelegateFunction(AddressOf GetTrilboneEbayFormAsForm)
        'интерфейс ебай
        Global.Service.clsApplicationTypes.DelegatStoreEbayinterface = New Func(Of Boolean, ieBayDataProvider)(AddressOf GetEbayDataProvider)
    End Sub



    Private Function GetTrilboneEbayFormAsForm(param As Object) As Form

        If param Is Nothing Then
            Return New fmTrilboneEbay
        End If

        If TypeOf param Is String Then

            Dim _accName As String = param

            Select Case _accName
                Case "trilbone"

            End Select
        End If
        Return New fmTrilboneEbay
    End Function

    ''' <summary>
    ''' вернет интерфейс
    ''' </summary>
    ''' <param name="agent"></param>
    ''' <returns></returns>
    Private Function RequestCurrentTransactions(agent As AUCTIONDATAAGENT) As ieBayDataProvider.ieBayTransactionList Implements ieBayDataProvider.RequestCurrentTransactions
        Return clsTransactionRequest.CreateInstance(agent)
    End Function


    ''' <summary>
    ''' вернет интерфейс
    ''' </summary>
    ''' <param name="param"></param>
    ''' <returns></returns>
    Private Function GetEbayDataProvider(param As Boolean) As ieBayDataProvider
        Return Me
    End Function

End Class
