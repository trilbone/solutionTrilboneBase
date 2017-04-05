Imports System.Linq
Public Class clsNopDataBuilder
    Implements iNopDataProvider

    Private oContext As ModelNop350Container

    Public ReadOnly Property IsConnect As Boolean Implements iNopDataProvider.IsConnect
        Get
            If oContext Is Nothing Then Return False
            Return True
        End Get
    End Property


    Public Sub New(datacontext As Service.ModelNop350Container)
        oContext = datacontext
    End Sub


    Public Function AllowRole(sku As String, roleId As Integer, allowed As Boolean) As Boolean Implements iNopDataProvider.AllowRole

        Dim _product = (From c In oContext.Product Where c.Sku = sku Select c).FirstOrDefault
        If _product Is Nothing Then Return False

        Dim _resultACL = (From c In oContext.AclRecord Where c.CustomerRoleId = roleId And c.EntityId = _product.Id And c.EntityName = "Product" Select c).ToList

        If allowed Then
            'открыть доступ
            If _resultACL.Count > 0 Then
                'доступ уже есть
                Return False
            Else
                'открыть доступ
                Dim _new = Service.AclRecord.CreateAclRecord(id:=0, entityId:=_product.Id, customerRoleId:=roleId, entityName:="Product")
                oContext.AclRecord.AddObject(_new)
            End If
        Else
            'закрыть доступ
            If _resultACL.Count > 0 Then
                For Each t In _resultACL
                    oContext.AclRecord.DeleteObject(t)
                Next
            Else
                'доступа нет
                Return False
            End If
        End If
        Dim _anwer = oContext.SaveChanges()
        If _anwer > 0 Then Return True
        Return False
    End Function

    Public Function AllowShop(sku As String, shopId As Integer, allowed As Boolean) As Boolean Implements iNopDataProvider.AllowShop
        Dim _product = (From c In oContext.Product Where c.Sku = sku Select c).FirstOrDefault
        If _product Is Nothing Then Return False

        Dim _result = (From c In oContext.StoreMapping Where c.EntityId = _product.Id And c.EntityName = "Product" And c.StoreId = shopId Select c).ToList

        If allowed Then
            'открыть доступ
            If _result.Count > 0 Then
                'доступ уже есть
                Return False
            End If
            Dim _new = Service.StoreMapping.CreateStoreMapping(id:=0, entityId:=_product.Id, storeId:=shopId, entityName:="Product")
            oContext.StoreMapping.AddObject(_new)
            'проверить цены
            Select Case MsgBox(String.Format("Цена на текущий образец при просмотре из магазина {0} будет одинакова для всех - цена на образец по умолчанию. Чтобы скопировать заданные ранее индивидуальные цены для этого магазина, нажмите ДА.", _new.StoreReference.Value.Name), vbYesNo)
                Case MsgBoxResult.Yes
                    'для каждой цены с другим магазином создать новую с текущим магазином
                    'проверка наличия цен для открываемого магазина
                    Dim _shopTierLists = (From c In oContext.TierPrice Where c.ProductId = _product.Id And Not (c.StoreId = shopId) Group By c.StoreId Into shopPrices = Group).ToList
                    If _shopTierLists.Count > 0 Then
                        'цены заданы
                        'берем магазин, где больше всего цен
                        Dim _target = _shopTierLists.Where(Function(x1) x1.shopPrices.Count = _shopTierLists.Max(Function(x) x.shopPrices.Count)).FirstOrDefault.shopPrices

                        'берем магазин, где больше всего цен
                        For Each tr In _target
                            'проверка наличия цены для клиента и магазина
                            Dim _tier = (From c In oContext.TierPrice Where c.CustomerRoleId = tr.CustomerRoleId And c.StoreId = shopId And c.ProductId = _product.Id Select c).FirstOrDefault
                            If _tier Is Nothing Then
                                'добавить цену для текущего клиента
                                Dim _newprice = Service.TierPrice.CreateTierPrice(id:=0, price:=tr.Price, productId:=_product.Id, quantity:=1, storeId:=shopId)
                                _newprice.CustomerRoleId = tr.CustomerRoleId
                                oContext.TierPrice.AddObject(_newprice)
                            Else
                                'изменить цену
                                _tier.Price = tr.Price
                            End If
                        Next
                    End If
            End Select
        Else
            'закрыть доступ
            If _result.Count = 0 Then
                'доступ уже закрыт
                Return False
            End If
            For Each t In _result
                oContext.StoreMapping.DeleteObject(t)
            Next
        End If

        Dim _anwer = oContext.SaveChanges()
        If _anwer > 0 Then Return True
        Return False
    End Function

    ''' <summary>
    ''' цена задается для пары магазин+роль. В StoreId передаются доступные магазины
    ''' </summary>
    ''' <param name="sku"></param>
    ''' <param name="roleId"></param>
    ''' <param name="StoreId"></param>
    ''' <param name="price"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SetPrice(sku As String, roleId As Integer, price As Decimal) As Boolean Implements iNopDataProvider.SetPrice

        Dim _product = (From c In oContext.Product Where c.Sku = sku Select c).FirstOrDefault
        If _product Is Nothing Then Return False

        If roleId = 0 Then
            'меняем базовую цену
            _product.Price = price
            oContext.SaveChanges()
            Return True
        End If

        'проверяем доступные магазины 
        Dim _store = (From c In oContext.StoreMapping Where c.EntityId = _product.Id And c.EntityName = "Product" Select c).ToList

        Dim _tierPriceCollection = (From c In oContext.TierPrice Where c.ProductId = _product.Id And c.CustomerRoleId = roleId Select c).ToList

        If _tierPriceCollection.Count = 0 Then
            'добавить цену для роли (для каждого доступного магазина)
            For Each _st In _store
                Dim _new = Service.TierPrice.CreateTierPrice(id:=0, price:=price, productId:=_product.Id, quantity:=1, storeId:=_st.StoreId)
                _new.CustomerRoleId = roleId
                oContext.TierPrice.AddObject(_new)
            Next
        ElseIf price > 0 And (Not _tierPriceCollection.Count = _store.Count) Then
            'не для всех магазинов выставлена цена
            'изменить цену для роли (для каждого доступного магазина)
            For Each t In _tierPriceCollection
                t.Price = price
            Next
            'добавить отсутствующие
            For Each s In _store
                Dim _res = (From c In _tierPriceCollection Where c.StoreId = s.Id Select c).FirstOrDefault

                If _res Is Nothing Then
                    Dim _new = Service.TierPrice.CreateTierPrice(id:=0, price:=price, productId:=_product.Id, quantity:=1, storeId:=s.StoreId)
                    _new.CustomerRoleId = roleId
                    oContext.TierPrice.AddObject(_new)
                End If
            Next

        Else
            If price > 0 Then
                'изменить цену для роли (для каждого доступного магазина)
                For Each t In _tierPriceCollection
                    t.Price = price
                Next
            Else
                For Each t In _tierPriceCollection
                    oContext.TierPrice.DeleteObject(t)
                Next
            End If

        End If
        Dim _anwer = oContext.SaveChanges()
        If _anwer > 0 Then Return True
        Return False
    End Function


    Public Function GetAviableStore(sku As String) As List(Of iNopDataProvider.clsNopStore) Implements iNopDataProvider.GetAviableStore

        Dim _qr = oContext.GetProductStoreInfo(sku).ToList

        Dim _result = From c In _qr Select New iNopDataProvider.clsNopStore With {.id = c.Id, .Name = c.Name}

        Return _result.ToList
    End Function


    Public Function GetACL(sku As String) As List(Of iNopDataProvider.clsNopACL) Implements iNopDataProvider.GetACL
        Dim _qr = oContext.GetProductACLinfo(sku).ToList
        If _qr Is Nothing Then Return New List(Of iNopDataProvider.clsNopACL)
        Dim _result = From c In _qr Select New iNopDataProvider.clsNopACL With {.Discount = c.discount, .LimitedToStores = c.LimitedToStores, .Name = c.Name, .price = c.price, .productid = c.productid, .Quantity = c.Quantity, .roleid = c.roleid, .rolename = c.rolename, .Sku = c.Sku, .StoreId = c.StoreId, .storename = c.storename, .SubjectToAcl = c.SubjectToAcl, .tierprice = c.tierprice}

        Return _result.ToList
    End Function

    Public Function GetCategories() As List(Of iNopDataProvider.clsNopCategory) Implements iNopDataProvider.GetCategories
        Dim _result = From c In oContext.Category Select New iNopDataProvider.clsNopCategory With {.id = c.Id, .Name = c.Name, .ParentCategoryId = c.ParentCategoryId}

        If _result Is Nothing Then Return New List(Of iNopDataProvider.clsNopCategory)

        Return _result.ToList
    End Function

    Public Function GetProduct(Optional CategoryID As Integer = 0) As List(Of iNopDataProvider.clsNopProduct) Implements iNopDataProvider.GetProduct

        Dim _qr = oContext.GetProduct(CategoryID).ToList
        If _qr Is Nothing Then Return New List(Of iNopDataProvider.clsNopProduct)

        Dim _result = (From c As GetProduct_Result In _qr Select New iNopDataProvider.clsNopProduct With {.Id = c.Id, .HasTierPrices = c.HasTierPrices, .LimitedToStores = c.LimitedToStores, .Name = c.Name, .Price = c.Price, .Currency = "RUR", .Published = c.Published, .ShowOnHomePage = c.ShowOnHomePage, .Sku = c.Sku, .StockQuantity = c.StockQuantity, .SubjectToAcl = c.SubjectToAcl, .WarehouseId = c.WarehouseId, .warename = c.warename}).ToList

        For Each t In _result
            'подгрузить роли
            If t.SubjectToAcl Then
                t.CustomerRolesIdList = (From c In oContext.AclRecord Where c.EntityId = t.Id Select c.CustomerRoleId).ToList
                If t.CustomerRolesIdList Is Nothing Then
                    t.CustomerRolesIdList = New List(Of Integer)
                End If
            Else
                t.CustomerRolesIdList = New List(Of Integer)
            End If
            'подгрузить размеры
            Dim _sm = clsApplicationTypes.clsSampleNumber.CreateFromString(t.Sku).GetEan13
            t.fossilsSizes = (From b In clsApplicationTypes.SampleDataObject.GetdbPhotoObjectContext.tb_Samples_Fossils Where b.ID_Sample_number = _sm Select If(b.Fossil_length > b.Fossil_width, b.Fossil_length, b.Fossil_width)).ToList().Select(Function(x) x.GetValueOrDefault).ToArray
            If t.fossilsSizes Is Nothing Then t.fossilsSizes = {}
        Next
        Return _result.ToList
    End Function

    Public Function GetRoles() As List(Of iNopDataProvider.clsNopRole) Implements iNopDataProvider.GetRoles

        Dim _result = From c In oContext.CustomerRole Select New iNopDataProvider.clsNopRole With {.id = c.Id, .Name = c.Name}

        If _result Is Nothing Then Return New List(Of iNopDataProvider.clsNopRole)

        Return _result.ToList
    End Function

    Public Function GetStores() As List(Of iNopDataProvider.clsNopStore) Implements iNopDataProvider.GetStores
        Dim _result = From c In oContext.Store Select New iNopDataProvider.clsNopStore With {.id = c.Id, .Name = c.Name}

        If _result Is Nothing Then Return New List(Of iNopDataProvider.clsNopStore)

        Return _result.ToList
    End Function
   
End Class
