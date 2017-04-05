
Public Class clsdbMoySklad
    Implements iMoySkladDataProvider

    Public Property Busy As Boolean Implements iMoySkladDataProvider.Busy
        Get
            Return True
        End Get
        Set(value As Boolean)
            'Throw New NotImplementedException()
        End Set
    End Property

    Public Sub ReloadEntities() Implements iMoySkladDataProvider.ReloadEntities
        'Throw New NotImplementedException()
    End Sub

    Public Function AddGood(code As String, name As String, price As Decimal, currency As String, Optional IsArticul As Boolean = False) As iMoySkladDataProvider.clsPosition Implements iMoySkladDataProvider.AddGood
        Return New iMoySkladDataProvider.clsPosition
    End Function

    Public Function AddParcelInfoToDemand(DemandUUID As String, WokerUUID As String, ShippingCompanyUUID As String, DeclarationContent As iMoySkladDataProvider.clsDeclaration_CP71_CN23) As Boolean Implements iMoySkladDataProvider.AddParcelInfoToDemand
        Return False
    End Function

    Public Function ChangeStatusCustomerOrder(CustomerOrderUUID As String, NewStatusUUID As String) As Boolean Implements iMoySkladDataProvider.ChangeStatusCustomerOrder
        Return False
    End Function

    Public Function ChangeStatusDemand(DemandUUID As String, NewStatusUUID As String) As Boolean Implements iMoySkladDataProvider.ChangeStatusDemand
        Return False
    End Function

    Public Function CreateCustomer(FullName As String, CustomerCode As String, Email As String, Address As iMoySkladDataProvider.clsAddress, AddressString As String, ClientGetPlaceUUID As String, ClientInterestUUID As String, ClientInterestDetails As String, ClientMCTags() As String, ClientCountryUUID As String, description As String) As String Implements iMoySkladDataProvider.CreateCustomer
        Return False
    End Function

    Public Function CreateCustomerOrder(GoodsUUIDs() As String, GoodsQtys() As Decimal, GoodsAmounts() As Decimal, ShippingInAmount As Decimal, ShippingInQty As Decimal, ShippingInGoodUUID As String, MyCompanyUUID As String, ProjectUUID As String, CustomerUUID As String, CurrencyUUID As String, WokerUUID As String, HandlingTime As Integer, Orderstate1UUID As String, Description As String, Optional OrderDate As Date? = Nothing) As iMoySkladDataProvider.clsOperationInfo Implements iMoySkladDataProvider.CreateCustomerOrder
        Return New iMoySkladDataProvider.clsOperationInfo
    End Function

    Public Function CreateDemand(MyCompanyUUID As String, CustomerUUID As String, ProjectUUID As String, StateUUID As String, WarehouseUUID As String, InvocePaymentTypeUUID As String, CurrencyUUID As String, GoodsUUIDs() As String, GoodsAmounts() As Decimal, GoodsQtys() As Decimal, Description As String, Applicable As Boolean, Optional DemandDate As Date? = Nothing) As iMoySkladDataProvider.clsOperationInfo Implements iMoySkladDataProvider.CreateDemand
        Return New iMoySkladDataProvider.clsOperationInfo
    End Function

    Public Function CreateIncomingPayment(ProjectUUID As String, AccepterUUID As String, AccountUUID As String, CustomerUUID As String, Amount As String, CurrencyUUID As String, MyCompanyUUID As String, NoFeeIncluded As Boolean, paymentPurpose As String, Description As String, Optional PaymentDate As Date? = Nothing) As iMoySkladDataProvider.clsPaymentInfo Implements iMoySkladDataProvider.CreateIncomingPayment
        Return New iMoySkladDataProvider.clsPaymentInfo
    End Function

    Public Function CreateInventory(MyCompany As String, WarehouseName As String, GoodsUUIDs() As String, Description As String, Optional WareCellName As String = "", Optional StateUUID As String = "2fb659a6-d883-11e4-90a2-8ecb001c0a01", Optional Applicable As Boolean = True, Optional GoodsQtys() As Decimal = Nothing) As iMoySkladDataProvider.clsOperationInfo Implements iMoySkladDataProvider.CreateInventory
        Return New iMoySkladDataProvider.clsOperationInfo
    End Function

    Public Function CreateMove(sourceStoreName As String, targetStoreName As String, goodList() As iMoySkladDataProvider.strGoodMapQty, Optional MoveState As iMoySkladDataProvider.emMoveState = iMoySkladDataProvider.emMoveState.empty) As iMoySkladDataProvider.clsOperationInfo Implements iMoySkladDataProvider.CreateMove
        Return New iMoySkladDataProvider.clsOperationInfo
    End Function

    Public Function EndSampleOnAuction(GoodCode As String, ReservCustomerOrderUUID As String) As String Implements iMoySkladDataProvider.EndSampleOnAuction
        Return False
    End Function

    Public Function FindCellByGood(ShotCode As String, WareHouseName As String, Optional IncludeReserved As Boolean = False, Optional GoodUUID As String = "") As List(Of iMoySkladDataProvider.strGoodMapQty) Implements iMoySkladDataProvider.FindCellByGood
        Return New List(Of iMoySkladDataProvider.strGoodMapQty)
    End Function

    Public Function FindCustomer(PartName As String, Email As String, CustomerCode As String, Optional reload As Boolean = False) As iMoySkladDataProvider.clsClientInfo() Implements iMoySkladDataProvider.FindCustomer
        Return New iMoySkladDataProvider.clsClientInfo() {}
    End Function

    Public Function FindGoodCategory(ShotCode As String) As String Implements iMoySkladDataProvider.FindGoodCategory
        Return False
    End Function

    Public Function FindGoods(PartOfName As String, Optional GoodShotCode As String = "", Optional AllWord As Boolean = False) As List(Of clsApplicationTypes.clsSampleNumber.strGoodInfo) Implements iMoySkladDataProvider.FindGoods
        Return New List(Of clsApplicationTypes.clsSampleNumber.strGoodInfo)
    End Function

    Public Function FindGoodsByCell(WarehouseName As String, SlotName As String, ByRef _status As Integer, ByRef Optional _message As String = "") As List(Of iMoySkladDataProvider.strGoodMapQty) Implements iMoySkladDataProvider.FindGoodsByCell
        Return New List(Of iMoySkladDataProvider.strGoodMapQty)
    End Function

    Public Function FindGoodsByUUID(UUID As String) As clsApplicationTypes.clsSampleNumber.strGoodInfo Implements iMoySkladDataProvider.FindGoodsByUUID
        Return New clsApplicationTypes.clsSampleNumber.strGoodInfo
    End Function

    Public Function FindStokQuantity(PartName As String, Optional ShotCode As String = "", Optional WareHouseName As String = "", Optional IncludeReserved As Boolean = False, Optional GroupUUID As String = "", Optional GoodUUID As String = "") As List(Of iMoySkladDataProvider.clsStokQuantity) Implements iMoySkladDataProvider.FindStokQuantity
        Return New List(Of iMoySkladDataProvider.clsStokQuantity)
    End Function

    Public Function GetClients(Optional reload As Boolean = False) As iMoySkladDataProvider.clsClientInfo() Implements iMoySkladDataProvider.GetClients
        Dim _out As New List(Of iMoySkladDataProvider.clsClientInfo)
        Dim _new As iMoySkladDataProvider.clsClientInfo

        _new = New iMoySkladDataProvider.clsClientInfo
        With _new
            .Email = "hnsnail@gmail.com"
            .FullName = "Hiro"
            .MainSourceEmail = "nordstarservice@gmail.com"
            _out.Add(_new)
        End With
        _new = New iMoySkladDataProvider.clsClientInfo
        With _new
            .Email = "admin@geologicalenterprises.com"
            .FullName = "Donna"
            .MainSourceEmail = "nordstarservice@gmail.com"
            _out.Add(_new)
        End With
        'gpldsl@gmail.com
        _new = New iMoySkladDataProvider.clsClientInfo
        With _new
            .Email = "gpldsl@gmail.com"
            .FullName = "Gianpaolo"
            .MainSourceEmail = "paleotravel@gmail.com"
            _out.Add(_new)
        End With
        'minerals-fossils@mail.ru
        _new = New iMoySkladDataProvider.clsClientInfo
        With _new
            .Email = "minerals-fossils@mail.ru"
            .FullName = "Анатолий"
            .MainSourceEmail = "trilbone@mail.ru"
            _out.Add(_new)
        End With
        _new = New iMoySkladDataProvider.clsClientInfo
        With _new
            .Email = "paleotravel@outlook.com"
            .FullName = "Гриша"
            .MainSourceEmail = "nordstarservice@gmail.com"
            _out.Add(_new)
        End With

        Return _out.ToArray
    End Function

    Public Function GetClientsInterest() As Dictionary(Of String, String) Implements iMoySkladDataProvider.GetClientsInterest
        Return New Dictionary(Of String, String)
    End Function

    Public Function GetClientsTags() As String() Implements iMoySkladDataProvider.GetClientsTags
        Return New String() {}
    End Function

    Public Function GetCompanyList() As List(Of iMoySkladDataProvider.clsEntity) Implements iMoySkladDataProvider.GetCompanyList
        Return New List(Of iMoySkladDataProvider.clsEntity)
    End Function

    Public Function GetCurrencyUUIDByName(currencyName As String) As String Implements iMoySkladDataProvider.GetCurrencyUUIDByName
        Return "USD"
    End Function

    Public Function GetDemandInfo(DemandName As String, Optional DemandUUID As String = "") As List(Of iMoySkladDataProvider.clsOperationInfo) Implements iMoySkladDataProvider.GetDemandInfo
        Return New List(Of iMoySkladDataProvider.clsOperationInfo)
    End Function

    Public Function GetExpeditionList() As List(Of String) Implements iMoySkladDataProvider.GetExpeditionList
        Return New List(Of String)
    End Function

    Public Function GetGroupList() As List(Of iMoySkladDataProvider.clsEntity) Implements iMoySkladDataProvider.GetGroupList
        Return New List(Of iMoySkladDataProvider.clsEntity)
    End Function

    Public Function GetOrderInfo(OrderName As String, Optional OrderUUID As String = "") As List(Of iMoySkladDataProvider.clsOperationInfo) Implements iMoySkladDataProvider.GetOrderInfo
        Return New List(Of iMoySkladDataProvider.clsOperationInfo)
    End Function

    Public Function GetParcelsInfoForShip(StateUUID As String, Optional ExcludeGoodsUUID() As String = Nothing, Optional WokerUUID As String = Nothing) As iMoySkladDataProvider.clsParcelInfo() Implements iMoySkladDataProvider.GetParcelsInfoForShip
        Return New iMoySkladDataProvider.clsParcelInfo() {}
    End Function

    Public Function GetPaymentDestinations() As List(Of iMoySkladDataProvider.clsEntity) Implements iMoySkladDataProvider.GetPaymentDestinations
        Return New List(Of iMoySkladDataProvider.clsEntity)
    End Function

    Public Function GetPaymentInInfo(PaymentInName As String, Optional PaymentInNameUUID As String = "") As List(Of iMoySkladDataProvider.clsPaymentInfo) Implements iMoySkladDataProvider.GetPaymentInInfo
        Return New List(Of iMoySkladDataProvider.clsPaymentInfo)
    End Function

    Public Function GetPaymentOutInfo(PaymentOutName As String, Optional PaymentOutNameUUID As String = "") As List(Of iMoySkladDataProvider.clsPaymentInfo) Implements iMoySkladDataProvider.GetPaymentOutInfo
        Return New List(Of iMoySkladDataProvider.clsPaymentInfo)
    End Function

    Public Function GetProject() As List(Of iMoySkladDataProvider.clsEntity) Implements iMoySkladDataProvider.GetProject
        Return New List(Of iMoySkladDataProvider.clsEntity)
    End Function

    Public Function GetShippingCompanies() As Dictionary(Of String, String) Implements iMoySkladDataProvider.GetShippingCompanies
        Return New Dictionary(Of String, String)
    End Function

    Public Function GetSlotList(WarehouseUUID As String) As List(Of iMoySkladDataProvider.clsEntity) Implements iMoySkladDataProvider.GetSlotList
        Return New List(Of iMoySkladDataProvider.clsEntity)
    End Function

    Public Function GetTriboneWoker() As Dictionary(Of String, String) Implements iMoySkladDataProvider.GetTriboneWoker
        Return New Dictionary(Of String, String)
    End Function

    Public Function GetUserEntityListByName(name As String) As List(Of iMoySkladDataProvider.clsEntity) Implements iMoySkladDataProvider.GetUserEntityListByName
        Return New List(Of iMoySkladDataProvider.clsEntity)
    End Function

    Public Function GetWarehouse(GoodUUID As String) As iMoySkladDataProvider.clsEntity Implements iMoySkladDataProvider.GetWarehouse
        Return New iMoySkladDataProvider.clsEntity
    End Function

    Public Function GetWarehouseList() As List(Of iMoySkladDataProvider.clsEntity) Implements iMoySkladDataProvider.GetWarehouseList
        Return New List(Of iMoySkladDataProvider.clsEntity)
    End Function

    Public Function LinkOrderDemandPaymentIn(CustomerOrderUUID As String, DemandUUID As String, PaymentInUUID As String) As Boolean Implements iMoySkladDataProvider.LinkOrderDemandPaymentIn
        Return False
    End Function

    Public Function SaveCustomer(customer As iMoySkladDataProvider.clsClientInfo) As iMoySkladDataProvider.clsClientInfo Implements iMoySkladDataProvider.SaveCustomer
        Return New iMoySkladDataProvider.clsClientInfo
    End Function

    Public Function SetSampleToAction(SampleNumber As clsApplicationTypes.clsSampleNumber, ReservCustomerOrderUUID As String, ItemAmount As Decimal, Reserving As Boolean) As Boolean Implements iMoySkladDataProvider.SetSampleToAction
        Return False
    End Function

    Public Function UpdateDemandsAfterCalculate(DemandUUID As String, PayPalOutFeeAmount As Decimal, PayPalOutFeeGoodUUID As String, EbayFeeStartAmount As Decimal, EbayFeeStartGoodUUID As String, ExportFee As Decimal, ExportGoodUUID As String, exportQuantity As Decimal, NalogFee As Decimal, NalogFeeUUID As String, ShippingInGoodUUID As String, ShippingInAmount As Decimal, ShippingInQty As Decimal, PayPalStartFeeGoodUUID As String, EbayFeeEndGoodUUID As String, PayPalStartFeeAmount As Decimal, EbayFeeEndAmount As Decimal) As Boolean Implements iMoySkladDataProvider.UpdateDemandsAfterCalculate
        Return False
    End Function

    Public Function UpdateDemandsAfterShip(DemandUUID As String, ResultParcels() As iMoySkladDataProvider.clsResultParcelInfo, NewStateUUID As String) As Boolean Implements iMoySkladDataProvider.UpdateDemandsAfterShip
        Return False
    End Function

    Public Function UpdateGoodPrice(goodCodeToUpdate As String, inbuyPrice As Decimal, buyCurrencyName As String, insalePrice As Decimal, saleCurrencyName As String, uomName As String, ingoodname As String, goodweight As Decimal, Optional Prices As List(Of iMoySkladDataProvider.strPrices) = Nothing) As String Implements iMoySkladDataProvider.UpdateGoodPrice
        Return False
    End Function
End Class
