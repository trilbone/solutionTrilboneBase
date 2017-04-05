Imports Trilbone
Imports RestMS_Client.MoySkladAPI
Imports System.Linq
Imports Service
Imports Service.clsApplicationTypes

Namespace MoySkladAPI
    Partial Class company

        Public Function GetSourceEmail() As String
            Dim _metadata As String
            'ищем флаг в атрибутах товара
            Dim _addfn = Function(metadataUUID As String, IsBooleanType As Boolean, IsStringType As Boolean, IsDecimalType As Boolean, IsTextType As Boolean, IsCustomEntityType As Boolean) As String
                             'ищем флаг в атрибутах товара
                             Dim _resAttrValue As agentAttributeValue
                             If Me.attribute Is Nothing Then Return ""
                             _resAttrValue = (From c In Me.attribute Where c.metadataUuid = metadataUUID Select c).FirstOrDefault
                             If Not _resAttrValue Is Nothing Then
                                 If IsBooleanType Then
                                     Return _resAttrValue.booleanValue
                                 End If
                                 If IsStringType Then
                                     Return _resAttrValue.valueString
                                 End If
                                 If IsDecimalType Then
                                     Return _resAttrValue.doubleValue
                                 End If
                                 If IsTextType Then
                                     Return _resAttrValue.valueText
                                 End If
                                 If IsCustomEntityType Then
                                     Return _resAttrValue.entityValueUuid
                                 End If
                             End If
                             Return ""
                         End Function
            ''предпочтительный емайл для отправки
            ''определим значение атрибута
            _metadata = "589dd945-4ac2-11e6-7a69-8f55001394f6"
            Return _addfn(_metadata, IsBooleanType:=False, IsStringType:=True, IsDecimalType:=False, IsTextType:=False, IsCustomEntityType:=False)
        End Function

        Public Function GetClientInfo() As iMoySkladDataProvider.clsClientInfo
            Dim _clt = New iMoySkladDataProvider.clsClientInfo
            With _clt
                .FullName = Me.name
                If Me.contact.email Is Nothing OrElse Me.contact.email = "" Then
                    .Email = "<добавь мыло в МС>"
                Else
                    .Email = Me.contact.email
                End If
                .MSCode = Me.code
                .UUID = Me.uuid
                'установка адреса
                .address = Me.GetAddress
                .MainSourceEmail = Me.GetSourceEmail
            End With
            Return _clt
        End Function

        ''' <summary>
        ''' вернет адрес клиента
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetAddress() As iMoySkladDataProvider.clsAddress
            Dim _out As New iMoySkladDataProvider.clsAddress
            Dim _metadata As String
            'ищем флаг в атрибутах товара
            Dim _addfn = Function(metadataUUID As String, IsBooleanType As Boolean, IsStringType As Boolean, IsDecimalType As Boolean, IsTextType As Boolean, IsCustomEntityType As Boolean) As String
                             'ищем флаг в атрибутах товара
                             Dim _resAttrValue As agentAttributeValue
                             If Me.attribute Is Nothing Then Return ""
                             _resAttrValue = (From c In Me.attribute Where c.metadataUuid = metadataUUID Select c).FirstOrDefault
                             If Not _resAttrValue Is Nothing Then
                                 If IsBooleanType Then
                                     Return _resAttrValue.booleanValue
                                 End If
                                 If IsStringType Then
                                     Return _resAttrValue.valueString
                                 End If
                                 If IsDecimalType Then
                                     Return _resAttrValue.doubleValue
                                 End If
                                 If IsTextType Then
                                     Return _resAttrValue.valueText
                                 End If
                                 If IsCustomEntityType Then
                                     Return _resAttrValue.entityValueUuid
                                 End If
                             End If
                             Return ""
                         End Function
            With _out
                ''почтовое имя
                ''определим значение атрибута
                _metadata = "4d014991-865e-11e4-90a2-8ecb00181219"
                .Name = _addfn(_metadata, IsBooleanType:=False, IsStringType:=True, IsDecimalType:=False, IsTextType:=False, IsCustomEntityType:=False)

                ''почта улица
                ''определим значение атрибута
                _metadata = "c44b2721-865d-11e4-90a2-8ecb001810f5"
                .Street = _addfn(_metadata, IsBooleanType:=False, IsStringType:=True, IsDecimalType:=False, IsTextType:=False, IsCustomEntityType:=False)

                ''почта город
                ''определим значение атрибута
                _metadata = "c44b28db-865d-11e4-90a2-8ecb001810f6"
                .City = _addfn(_metadata, IsBooleanType:=False, IsStringType:=True, IsDecimalType:=False, IsTextType:=False, IsCustomEntityType:=False)
                ''волость
                ''определим значение атрибута
                _metadata = "c44b2a2b-865d-11e4-90a2-8ecb001810f7"
                .State = _addfn(_metadata, IsBooleanType:=False, IsStringType:=True, IsDecimalType:=False, IsTextType:=False, IsCustomEntityType:=False)

                ''почта страна
                ''определим значение атрибута
                _metadata = "d2d87f24-966a-11e4-90a2-8ecb00867134"
                .Country = _addfn(_metadata, IsBooleanType:=False, IsStringType:=True, IsDecimalType:=False, IsTextType:=False, IsCustomEntityType:=False)
                ''почта индекс
                ''определим значение атрибута
                _metadata = "c44b2b78-865d-11e4-90a2-8ecb001810f8"
                .PostIndex = _addfn(_metadata, IsBooleanType:=False, IsStringType:=True, IsDecimalType:=False, IsTextType:=False, IsCustomEntityType:=False)

                If Not Me.requisite Is Nothing Then
                    .FullAddress = Me.requisite.actualAddress
                End If

                If Not Me.contact Is Nothing Then
                    .Phone = Me.contact.phones
                End If

            End With

            Return _out

        End Function

    End Class


    Public Class MOYsklad_extentions

    End Class

    Partial Class paymentOut

    End Class

    Partial Class financeIn

        Public Function GetpaymentInTrilbone(manager As clsMoyScladManager) As iMoySkladDataProvider.clsPaymentInfo
            Dim _out As New iMoySkladDataProvider.clsPaymentInfo
            With _out
                .IsIncomingPayment = True
                .created = Me.created
                .currencyUuid = Me.currencyUuid
                .currency = If(manager.GetCurrencyByUUID(Me.currencyUuid) Is Nothing, "", manager.GetCurrencyByUUID(Me.currencyUuid).name)
                .name = Me.name
                .projectUuid = Me.projectUuid
                .projectName = If(manager.GetProjectByUUID(Me.projectUuid) Is Nothing, "", manager.GetProjectByUUID(Me.projectUuid).name)

                .Applicable = Me.applicable
                .rate = Me.rate

                .sourceAgentUuid = Me.sourceAgentUuid
                .sourceAgentName = If(manager.GetCustomerByUUID(Me.sourceAgentUuid) Is Nothing, "", manager.GetCustomerByUUID(Me.sourceAgentUuid).name)
                If String.IsNullOrEmpty(.sourceAgentName) And Not String.IsNullOrEmpty(.sourceAgentUuid) Then
                    .sourceAgentName = If(manager.GetCompanyByUUID(Me.sourceAgentUuid) Is Nothing, "", manager.GetCompanyByUUID(Me.sourceAgentUuid).name)
                End If
                .targetAgentUuid = Me.targetAgentUuid
                .targetAgentName = If(manager.GetCustomerByUUID(Me.targetAgentUuid) Is Nothing, "", manager.GetCustomerByUUID(Me.targetAgentUuid).name)
                If String.IsNullOrEmpty(.targetAgentName) And Not String.IsNullOrEmpty(.targetAgentUuid) Then
                    .targetAgentName = If(manager.GetCompanyByUUID(Me.targetAgentUuid) Is Nothing, "", manager.GetCompanyByUUID(Me.targetAgentUuid).name)
                End If


                ''вопрос
                .TargetStoreUUID = Me.targetStoreUuid
                .TargetStoreName = If(manager.GetWarehouseByUUID(Me.targetStoreUuid) Is Nothing, "", manager.GetWarehouseByUUID(Me.targetStoreUuid).name)
                .sourceStoreUuid = Me.sourceStoreUuid
                .sourceStoreName = If(manager.GetWarehouseByUUID(Me.sourceStoreUuid) Is Nothing, "", manager.GetWarehouseByUUID(Me.sourceStoreUuid).name)
                .retailStoreUuid = Me.retailStoreUuid
                .retailStoreName = If(manager.GetWarehouseByUUID(Me.retailStoreUuid) Is Nothing, "", manager.GetWarehouseByUUID(Me.retailStoreUuid).name)

                .TotalAmountInCurrency = If(Me.sum Is Nothing, 0, Me.sum.sumInCurrency / 100)
                .UUID = Me.uuid
                .description = Me.description
                .paymentPurpose = Me.paymentPurpose

                .RefDemandUUID = Me.demandsUuid.FirstOrDefault
                .RefOrderUUID = Me.customerOrderUuid

                If Not String.IsNullOrEmpty(Me.customerOrderUuid) Then
                    'тут попытаться найти отгрузку в установленном заказе
                    Dim _order = manager.RequestCustomerOrderByUUID(Me.customerOrderUuid)
                    .RefDemandUUID = _order.demandsUuid.FirstOrDefault
                End If

                Dim _attrList As New List(Of iMoySkladDataProvider.clsEntity)

                For Each t In Me.attribute
                    Dim _new = New iMoySkladDataProvider.clsEntity
                    _new.UUID = t.uuid
                    Dim _cv = manager.GetCustomEntityByUUID(t.TryGetValue)

                    If Not _cv Is Nothing Then
                        'работаем с атрибутом сущности (подгруженной в МС)
                        _new.UUID = _cv.uuid
                        _new.Value = _cv.name
                        _new.MetaDataUUID = _cv.entityMetadataUuid
                        _new.MetaDataValue = manager.GetUserListNameByUUID(_cv.entityMetadataUuid)
                    Else
                        'в случае с неподгруженной сущностью MetaDataUUID будет пусто (проверь IsMetadataEmpty), а uuid сущности будет лежать в Value  -  по мере надобности можно подгрузить
                        _new.UUID = t.uuid
                        _new.Value = t.TryGetValue
                        'метод получения значения сущности(подзагружает в обьект значения)
                        _new.GetCustomValueDelegate = AddressOf manager.GetLoadCustomEntityByUUID
                    End If

                    _attrList.Add(_new)
                Next

                .attributes = _attrList
            End With
            Return _out
        End Function

    End Class


    Partial Class financeOut
        Public Function GetpaymentInTrilbone(manager As clsMoyScladManager) As iMoySkladDataProvider.clsPaymentInfo
            Dim _out As New iMoySkladDataProvider.clsPaymentInfo
            With _out
                .IsIncomingPayment = False
                .created = Me.created
                .currencyUuid = Me.currencyUuid
                .currency = If(manager.GetCurrencyByUUID(Me.currencyUuid) Is Nothing, "", manager.GetCurrencyByUUID(Me.currencyUuid).name)
                .name = Me.name
                .projectUuid = Me.projectUuid
                .projectName = If(manager.GetProjectByUUID(Me.projectUuid) Is Nothing, "", manager.GetProjectByUUID(Me.projectUuid).name)

                .Applicable = Me.applicable
                .rate = Me.rate

                .sourceAgentUuid = Me.sourceAgentUuid
                .sourceAgentName = If(manager.GetCustomerByUUID(Me.sourceAgentUuid) Is Nothing, "", manager.GetCustomerByUUID(Me.sourceAgentUuid).name)
                If String.IsNullOrEmpty(.sourceAgentName) And Not String.IsNullOrEmpty(.sourceAgentUuid) Then
                    .sourceAgentName = If(manager.GetCompanyByUUID(Me.sourceAgentUuid) Is Nothing, "", manager.GetCompanyByUUID(Me.sourceAgentUuid).name)
                End If
                .targetAgentUuid = Me.targetAgentUuid
                .targetAgentName = If(manager.GetCustomerByUUID(Me.targetAgentUuid) Is Nothing, "", manager.GetCustomerByUUID(Me.targetAgentUuid).name)
                If String.IsNullOrEmpty(.targetAgentName) And Not String.IsNullOrEmpty(.targetAgentUuid) Then
                    .targetAgentName = If(manager.GetCompanyByUUID(Me.targetAgentUuid) Is Nothing, "", manager.GetCompanyByUUID(Me.targetAgentUuid).name)
                End If


                ''вопрос
                .TargetStoreUUID = Me.targetStoreUuid
                .TargetStoreName = If(manager.GetWarehouseByUUID(Me.targetStoreUuid) Is Nothing, "", manager.GetWarehouseByUUID(Me.targetStoreUuid).name)
                .sourceStoreUuid = Me.sourceStoreUuid
                .sourceStoreName = If(manager.GetWarehouseByUUID(Me.sourceStoreUuid) Is Nothing, "", manager.GetWarehouseByUUID(Me.sourceStoreUuid).name)
                .retailStoreUuid = Me.retailStoreUuid
                .retailStoreName = If(manager.GetWarehouseByUUID(Me.retailStoreUuid) Is Nothing, "", manager.GetWarehouseByUUID(Me.retailStoreUuid).name)

                .TotalAmountInCurrency = If(Me.sum Is Nothing, 0, Me.sum.sumInCurrency / 100)
                .UUID = Me.uuid
                .description = Me.description
                .paymentPurpose = Me.paymentPurpose

                .RefDemandUUID = "" ' Не применимо
                .RefOrderUUID = ""  ' Не применимо 


                Dim _attrList As New List(Of iMoySkladDataProvider.clsEntity)

                For Each t In Me.attribute
                    Dim _new = New iMoySkladDataProvider.clsEntity
                    _new.UUID = t.uuid
                    Dim _cv = manager.GetCustomEntityByUUID(t.TryGetValue)

                    If Not _cv Is Nothing Then
                        'работаем с атрибутом сущности (подгруженной в МС)
                        _new.UUID = _cv.uuid
                        _new.Value = _cv.name
                        _new.MetaDataUUID = _cv.entityMetadataUuid
                        _new.MetaDataValue = manager.GetUserListNameByUUID(_cv.entityMetadataUuid)
                    Else
                        'в случае с неподгруженной сущностью MetaDataUUID будет пусто (проверь IsMetadataEmpty), а uuid сущности будет лежать в Value  -  по мере надобности можно подгрузить
                        _new.UUID = t.uuid
                        _new.Value = t.TryGetValue
                        'метод получения значения сущности(подзагружает в обьект значения)
                        _new.GetCustomValueDelegate = AddressOf manager.GetLoadCustomEntityByUUID
                    End If

                    _attrList.Add(_new)
                Next

                .attributes = _attrList
            End With
            Return _out
        End Function


    End Class


    Partial Class goodFolder
        Public Function GetTrilboneItem() As iMoySkladDataProvider.clsEntity
            Dim _new As New iMoySkladDataProvider.clsEntity
            _new.SetValued = True
            _new.Value = Me.name
            _new.UUID = Me.uuid
            _new.MetaDataUUID = ""
            _new.MetaDataValue = ""
            Return _new
        End Function
    End Class




    Partial Class warehouse
        Public Function GetTrilboneItem() As iMoySkladDataProvider.clsEntity
            Dim _new As New iMoySkladDataProvider.clsEntity
            _new.SetValued = True
            _new.Value = Me.name
            _new.UUID = Me.uuid
            _new.MetaDataUUID = ""
            _new.MetaDataValue = ""
            Return _new
        End Function
    End Class

    Partial Class slot
        Public Function GetTrilboneItem() As iMoySkladDataProvider.clsEntity
            Dim _new As New iMoySkladDataProvider.clsEntity
            _new.SetValued = True
            _new.Value = Me.name
            _new.UUID = Me.uuid
            _new.MetaDataUUID = ""
            _new.MetaDataValue = ""
            Return _new
        End Function
    End Class

    Partial Public Class myCompany
        Public Function GetTrilboneItem() As iMoySkladDataProvider.clsEntity
            Dim _new As New iMoySkladDataProvider.clsEntity
            _new.SetValued = True
            _new.Value = Me.name
            _new.UUID = Me.uuid
            _new.MetaDataUUID = Nothing
            _new.MetaDataValue = Nothing
            Return _new
        End Function
    End Class

    Partial Public Class customEntity
        Public Function GetTrilboneItem(metadataName As String) As iMoySkladDataProvider.clsEntity
            Dim _new As New iMoySkladDataProvider.clsEntity
            _new.SetValued = True
            _new.Value = Me.name
            _new.UUID = Me.uuid
            _new.MetaDataUUID = Me.entityMetadataUuid
            _new.MetaDataValue = metadataName
            Return _new
        End Function
    End Class

    Partial Class inventoryPosition
        Public Function GetPositionTrilbone(manager As clsMoyScladManager, Optional LoadGoodInfo As Boolean = True) As iMoySkladDataProvider.clsPosition
            Dim _out As New iMoySkladDataProvider.clsPosition

            With _out
                .goodUuid = Me.goodUuid
                .Discount = Me.discount

                .BasePriceInCurrency = If(Me.basePrice Is Nothing, 0, Me.basePrice.sumInCurrency / 100)
                .PriceInCurrency = If(Me.price Is Nothing, 0, Me.price.sumInCurrency / 100)
                .currencyName = "" 'не применимо
                .quantity = Me.quantity
                .ReserveQty = 0 'не применимо
                If LoadGoodInfo Then
                    Dim _good = manager.RequestGoodByUUID(Me.goodUuid)
                    If Not _good Is Nothing Then
                        .Articul = _good.productCode
                        .Code = _good.code
                        .GoodName = _good.name
                        .uomName = manager.GetUomByUUID(_good.uomUuid).name
                    End If
                End If
            End With
            Return _out
        End Function

    End Class

    Partial Class inventory
        Public Function GetAttributeValue(metadataUUID As String, IsBooleanType As Boolean, IsStringType As Boolean, IsDecimalType As Boolean, IsTextType As Boolean, IsCustomEntityType As Boolean) As String
            'ищем флаг в атрибутах товара
            Dim _resAttrValue As operationAttributeValue
            _resAttrValue = (From c In Me.attribute Where c.metadataUuid = metadataUUID Select c).FirstOrDefault
            If Not _resAttrValue Is Nothing Then
                Return _resAttrValue.GetAttributeValue(IsBooleanType, IsStringType, IsDecimalType, IsTextType, IsCustomEntityType)
            End If
            Return ""
        End Function

        Public Function GetInventoryTrilbone(manager As clsMoyScladManager) As iMoySkladDataProvider.clsOperationInfo
            Dim _out As New iMoySkladDataProvider.clsOperationInfo
            With _out
                .IsOutgoingOperation = True
                .created = Me.created
                .currencyUuid = Me.currencyUuid
                .currency = If(manager.GetCurrencyByUUID(Me.currencyUuid) Is Nothing, "", manager.GetCurrencyByUUID(Me.currencyUuid).name)
                .name = Me.name
                .projectUuid = Me.projectUuid
                .projectName = If(manager.GetProjectByUUID(Me.projectUuid) Is Nothing, "", manager.GetProjectByUUID(Me.projectUuid).name)

                .Applicable = Me.applicable
                .rate = Me.rate

                .sourceAgentUuid = Me.sourceAgentUuid
                .sourceAgentName = If(manager.GetCustomerByUUID(Me.sourceAgentUuid) Is Nothing, "", manager.GetCustomerByUUID(Me.sourceAgentUuid).name)
                If String.IsNullOrEmpty(.sourceAgentName) And Not String.IsNullOrEmpty(.sourceAgentUuid) Then
                    .sourceAgentName = If(manager.GetCompanyByUUID(Me.sourceAgentUuid) Is Nothing, "", manager.GetCompanyByUUID(Me.sourceAgentUuid).name)
                End If
                .targetAgentUuid = Me.targetAgentUuid
                .targetAgentName = If(manager.GetCustomerByUUID(Me.targetAgentUuid) Is Nothing, "", manager.GetCustomerByUUID(Me.targetAgentUuid).name)
                If String.IsNullOrEmpty(.targetAgentName) And Not String.IsNullOrEmpty(.targetAgentUuid) Then
                    .targetAgentName = If(manager.GetCompanyByUUID(Me.targetAgentUuid) Is Nothing, "", manager.GetCompanyByUUID(Me.targetAgentUuid).name)
                End If


                ''вопрос
                .TargetStoreUUID = Me.targetStoreUuid
                .TargetStoreName = If(manager.GetWarehouseByUUID(Me.targetStoreUuid) Is Nothing, "", manager.GetWarehouseByUUID(Me.targetStoreUuid).name)
                .sourceStoreUuid = Me.sourceStoreUuid
                .sourceStoreName = If(manager.GetWarehouseByUUID(Me.sourceStoreUuid) Is Nothing, "", manager.GetWarehouseByUUID(Me.sourceStoreUuid).name)
                .retailStoreUuid = Me.retailStoreUuid
                .retailStoreName = If(manager.GetWarehouseByUUID(Me.retailStoreUuid) Is Nothing, "", manager.GetWarehouseByUUID(Me.retailStoreUuid).name)

                .TotalAmountInCurrency = Me.sum.sumInCurrency / 100
                .UUID = Me.uuid
                .description = Me.description

                .RefDemandUUID = Me.uuid
                ' .RefOrderUUID = Me.customerOrderUuid
                .Position = If(Me.inventoryPosition Is Nothing OrElse Me.inventoryPosition.Count = 0, New List(Of iMoySkladDataProvider.clsPosition), Me.inventoryPosition.Select(Function(x) x.GetPositionTrilbone(manager, True)).ToList)

                '.RefFinanceUUID = Me.paymentsUuid.FirstOrDefault


                .reservedSum = 0 'не применимо

                Dim _attrList As New List(Of iMoySkladDataProvider.clsEntity)

                For Each t In Me.attribute
                    Dim _new = New iMoySkladDataProvider.clsEntity
                    _new.UUID = t.uuid
                    Dim _cv = manager.GetCustomEntityByUUID(t.TryGetValue)

                    If Not _cv Is Nothing Then
                        'работаем с атрибутом сущности (подгруженной в МС)
                        _new.UUID = _cv.uuid
                        _new.Value = _cv.name
                        _new.MetaDataUUID = _cv.entityMetadataUuid
                        _new.MetaDataValue = manager.GetUserListNameByUUID(_cv.entityMetadataUuid)
                    Else
                        'в случае с неподгруженной сущностью MetaDataUUID будет пусто (проверь IsMetadataEmpty), а uuid сущности будет лежать в Value  -  по мере надобности можно подгрузить
                        _new.UUID = t.uuid
                        _new.Value = t.TryGetValue
                        'метод получения значения сущности(подзагружает в обьект значения)
                        _new.GetCustomValueDelegate = AddressOf manager.GetLoadCustomEntityByUUID
                    End If

                    _attrList.Add(_new)
                Next

                .attributes = _attrList


            End With
            Return _out
        End Function

    End Class


    Partial Public Class demand

        Public Function GetAttributeValue(metadataUUID As String, IsBooleanType As Boolean, IsStringType As Boolean, IsDecimalType As Boolean, IsTextType As Boolean, IsCustomEntityType As Boolean) As String
            'ищем флаг в атрибутах товара

            Dim _resAttrValue As operationAttributeValue
            _resAttrValue = (From c In Me.attribute Where c.metadataUuid = metadataUUID Select c).FirstOrDefault
            If Not _resAttrValue Is Nothing Then
                Return _resAttrValue.GetAttributeValue(IsBooleanType, IsStringType, IsDecimalType, IsTextType, IsCustomEntityType)
                'If IsBooleanType Then
                '    Return _resAttrValue.booleanValue
                'End If
                'If IsStringType Then
                '    Return _resAttrValue.valueString
                'End If
                'If IsDecimalType Then
                '    Return _resAttrValue.doubleValue
                'End If
                'If IsTextType Then
                '    Return _resAttrValue.valueText
                'End If
                'If IsCustomEntityType Then
                '    Return _resAttrValue.entityValueUuid
                'End If
            End If
            Return ""
        End Function

        Public Function GetDemandTrilbone(manager As clsMoyScladManager) As iMoySkladDataProvider.clsOperationInfo
            'тестировано
            Dim _out As New iMoySkladDataProvider.clsOperationInfo
            With _out
                .IsOutgoingOperation = True
                .created = Me.created
                .currencyUuid = Me.currencyUuid
                .currency = If(manager.GetCurrencyByUUID(Me.currencyUuid) Is Nothing, "", manager.GetCurrencyByUUID(Me.currencyUuid).name)
                .name = Me.name
                .projectUuid = Me.projectUuid
                .projectName = If(manager.GetProjectByUUID(Me.projectUuid) Is Nothing, "", manager.GetProjectByUUID(Me.projectUuid).name)

                .Applicable = Me.applicable
                .rate = Me.rate

                .sourceAgentUuid = Me.sourceAgentUuid
                .sourceAgentName = If(manager.GetCustomerByUUID(Me.sourceAgentUuid) Is Nothing, "", manager.GetCustomerByUUID(Me.sourceAgentUuid).name)
                If String.IsNullOrEmpty(.sourceAgentName) And Not String.IsNullOrEmpty(.sourceAgentUuid) Then
                    .sourceAgentName = If(manager.GetCompanyByUUID(Me.sourceAgentUuid) Is Nothing, "", manager.GetCompanyByUUID(Me.sourceAgentUuid).name)
                End If
                .targetAgentUuid = Me.targetAgentUuid
                .targetAgentName = If(manager.GetCustomerByUUID(Me.targetAgentUuid) Is Nothing, "", manager.GetCustomerByUUID(Me.targetAgentUuid).name)
                If String.IsNullOrEmpty(.targetAgentName) And Not String.IsNullOrEmpty(.targetAgentUuid) Then
                    .targetAgentName = If(manager.GetCompanyByUUID(Me.targetAgentUuid) Is Nothing, "", manager.GetCompanyByUUID(Me.targetAgentUuid).name)
                End If


                ''вопрос
                .TargetStoreUUID = Me.targetStoreUuid
                .TargetStoreName = If(manager.GetWarehouseByUUID(Me.targetStoreUuid) Is Nothing, "", manager.GetWarehouseByUUID(Me.targetStoreUuid).name)
                .sourceStoreUuid = Me.sourceStoreUuid
                .sourceStoreName = If(manager.GetWarehouseByUUID(Me.sourceStoreUuid) Is Nothing, "", manager.GetWarehouseByUUID(Me.sourceStoreUuid).name)
                .retailStoreUuid = Me.retailStoreUuid
                .retailStoreName = If(manager.GetWarehouseByUUID(Me.retailStoreUuid) Is Nothing, "", manager.GetWarehouseByUUID(Me.retailStoreUuid).name)

                .TotalAmountInCurrency = Me.sum.sumInCurrency / 100
                .UUID = Me.uuid
                .description = Me.description

                .RefDemandUUID = Me.uuid
                .RefOrderUUID = Me.customerOrderUuid
                .Position = If(Me.shipmentOut Is Nothing OrElse Me.shipmentOut.Count = 0, New List(Of iMoySkladDataProvider.clsPosition), Me.shipmentOut.Select(Function(x) x.GetPositionTrilbone(manager, True)).ToList)

                .RefFinanceUUID = Me.paymentsUuid.FirstOrDefault


                .reservedSum = 0 'не применимо

                Dim _attrList As New List(Of iMoySkladDataProvider.clsEntity)

                For Each t In Me.attribute
                    Dim _new = New iMoySkladDataProvider.clsEntity
                    _new.UUID = t.uuid
                    Dim _cv = manager.GetCustomEntityByUUID(t.TryGetValue)

                    If Not _cv Is Nothing Then
                        'работаем с атрибутом сущности (подгруженной в МС)
                        _new.UUID = _cv.uuid
                        _new.Value = _cv.name
                        _new.MetaDataUUID = _cv.entityMetadataUuid
                        _new.MetaDataValue = manager.GetUserListNameByUUID(_cv.entityMetadataUuid)
                    Else
                        'в случае с неподгруженной сущностью MetaDataUUID будет пусто (проверь IsMetadataEmpty), а uuid сущности будет лежать в Value  -  по мере надобности можно подгрузить
                        _new.UUID = t.uuid
                        _new.Value = t.TryGetValue
                        'метод получения значения сущности(подзагружает в обьект значения)
                        _new.GetCustomValueDelegate = AddressOf manager.GetLoadCustomEntityByUUID
                    End If

                    _attrList.Add(_new)
                Next

                .attributes = _attrList


            End With
            Return _out
        End Function
    End Class

    Partial Class operationAttributeValue

        Public Function TryGetValue()
            If Me.booleanValueSpecified Then
                Return Me.booleanValue
            End If

            If Not String.IsNullOrEmpty(Me.valueString) Then
                Return Me.valueString
            End If

            If Me.doubleValueSpecified Then
                Return Me.doubleValue
            End If
            If Not String.IsNullOrEmpty(Me.valueText) Then
                Return Me.valueText
            End If
            If Not String.IsNullOrEmpty(Me.entityValueUuid) Then
                Return Me.entityValueUuid
            End If


            Return ""


        End Function



        Public Function GetAttributeValue(IsBooleanType As Boolean, IsStringType As Boolean, IsDecimalType As Boolean, IsTextType As Boolean, IsCustomEntityType As Boolean) As String
            'ищем флаг в атрибутах товара

            If IsBooleanType Then
                Return Me.booleanValue
            End If

            If IsStringType Then
                Return Me.valueString
            End If

            If IsDecimalType Then
                Return Me.doubleValue
            End If
            If IsTextType Then
                Return Me.valueText
            End If
            If IsCustomEntityType Then
                Return Me.entityValueUuid
            End If


            Return ""
        End Function



    End Class

    Partial Class move
        Public Function GetMoveTrilbone(manager As clsMoyScladManager) As iMoySkladDataProvider.clsOperationInfo
            Dim _out As New iMoySkladDataProvider.clsOperationInfo
            With _out
                .IsOutgoingOperation = False
                .created = Me.created
                .currencyUuid = Me.currencyUuid
                .currency = If(manager.GetCurrencyByUUID(Me.currencyUuid) Is Nothing, "", manager.GetCurrencyByUUID(Me.currencyUuid).name)
                .name = Me.name
                .projectUuid = Me.projectUuid
                .projectName = If(manager.GetProjectByUUID(Me.projectUuid) Is Nothing, "", manager.GetProjectByUUID(Me.projectUuid).name)

                .Applicable = Me.applicable
                .rate = Me.rate

                '.RefDemandUUID = Me.demandsUuidField.FirstOrDefault
                '.RefFinanceUUID = Me.paymentsUuid.FirstOrDefault
                .RefOrderUUID = Me.uuid

                '.reservedSum = Me.reservedSum / 100

                .sourceAgentUuid = Me.sourceAgentUuid
                .sourceAgentName = If(manager.GetCustomerByUUID(Me.sourceAgentUuid) Is Nothing, "", manager.GetCustomerByUUID(Me.sourceAgentUuid).name)
                If String.IsNullOrEmpty(.sourceAgentName) And Not String.IsNullOrEmpty(.sourceAgentUuid) Then
                    .sourceAgentName = If(manager.GetCompanyByUUID(Me.sourceAgentUuid) Is Nothing, "", manager.GetCompanyByUUID(Me.sourceAgentUuid).name)
                End If
                .targetAgentUuid = Me.targetAgentUuid
                .targetAgentName = If(manager.GetCustomerByUUID(Me.targetAgentUuid) Is Nothing, "", manager.GetCustomerByUUID(Me.targetAgentUuid).name)
                If String.IsNullOrEmpty(.targetAgentName) And Not String.IsNullOrEmpty(.targetAgentUuid) Then
                    .targetAgentName = If(manager.GetCompanyByUUID(Me.targetAgentUuid) Is Nothing, "", manager.GetCompanyByUUID(Me.targetAgentUuid).name)
                End If


                ''вопрос
                .TargetStoreUUID = Me.targetStoreUuid
                .TargetStoreName = If(manager.GetWarehouseByUUID(Me.targetStoreUuid) Is Nothing, "", manager.GetWarehouseByUUID(Me.targetStoreUuid).name)
                .sourceStoreUuid = Me.sourceStoreUuid
                .sourceStoreName = If(manager.GetWarehouseByUUID(Me.sourceStoreUuid) Is Nothing, "", manager.GetWarehouseByUUID(Me.sourceStoreUuid).name)
                .retailStoreUuid = Me.retailStoreUuid
                .retailStoreName = If(manager.GetWarehouseByUUID(Me.retailStoreUuid) Is Nothing, "", manager.GetWarehouseByUUID(Me.retailStoreUuid).name)

                .TotalAmountInCurrency = Me.sum.sumInCurrency / 100
                .UUID = Me.uuid

                .Position = If(Me.movePosition Is Nothing OrElse Me.movePosition.Count = 0, New List(Of iMoySkladDataProvider.clsPosition), Me.movePosition.Select(Function(x) x.GetPositionTrilbone(manager, True)).ToList)


                .description = Me.description

                Dim _attrList As New List(Of iMoySkladDataProvider.clsEntity)

                For Each t In Me.attribute
                    Dim _new = New iMoySkladDataProvider.clsEntity
                    _new.UUID = t.uuid
                    Dim _cv = manager.GetCustomEntityByUUID(t.TryGetValue)

                    If Not _cv Is Nothing Then
                        'работаем с атрибутом сущности (подгруженной в МС)
                        _new.UUID = _cv.uuid
                        _new.Value = _cv.name
                        _new.MetaDataUUID = _cv.entityMetadataUuid
                        _new.MetaDataValue = manager.GetUserListNameByUUID(_cv.entityMetadataUuid)
                    Else
                        'в случае с неподгруженной сущностью MetaDataUUID будет пусто (проверь IsMetadataEmpty), а uuid сущности будет лежать в Value  -  по мере надобности можно подгрузить
                        _new.UUID = t.uuid
                        _new.Value = t.TryGetValue
                        'метод получения значения сущности(подзагружает в обьект значения)
                        _new.GetCustomValueDelegate = AddressOf manager.GetLoadCustomEntityByUUID
                    End If

                    _attrList.Add(_new)
                Next

                .attributes = _attrList
            End With
            Return _out
        End Function
    End Class


    Partial Class customerOrder
        Public Function GetOrderTrilbone(manager As clsMoyScladManager) As iMoySkladDataProvider.clsOperationInfo
            Dim _out As New iMoySkladDataProvider.clsOperationInfo
            With _out
                .IsOutgoingOperation = False
                .created = Me.created
                .currencyUuid = Me.currencyUuid
                .currency = If(manager.GetCurrencyByUUID(Me.currencyUuid) Is Nothing, "", manager.GetCurrencyByUUID(Me.currencyUuid).name)
                .name = Me.name
                .projectUuid = Me.projectUuid
                .projectName = If(manager.GetProjectByUUID(Me.projectUuid) Is Nothing, "", manager.GetProjectByUUID(Me.projectUuid).name)

                .Applicable = Me.applicable
                .rate = Me.rate

                .RefDemandUUID = Me.demandsUuidField.FirstOrDefault
                .RefFinanceUUID = Me.paymentsUuid.FirstOrDefault
                .RefOrderUUID = Me.uuid

                .reservedSum = Me.reservedSum / 100

                .sourceAgentUuid = Me.sourceAgentUuid
                .sourceAgentName = If(manager.GetCustomerByUUID(Me.sourceAgentUuid) Is Nothing, "", manager.GetCustomerByUUID(Me.sourceAgentUuid).name)
                If String.IsNullOrEmpty(.sourceAgentName) And Not String.IsNullOrEmpty(.sourceAgentUuid) Then
                    .sourceAgentName = If(manager.GetCompanyByUUID(Me.sourceAgentUuid) Is Nothing, "", manager.GetCompanyByUUID(Me.sourceAgentUuid).name)
                End If
                .targetAgentUuid = Me.targetAgentUuid
                .targetAgentName = If(manager.GetCustomerByUUID(Me.targetAgentUuid) Is Nothing, "", manager.GetCustomerByUUID(Me.targetAgentUuid).name)
                If String.IsNullOrEmpty(.targetAgentName) And Not String.IsNullOrEmpty(.targetAgentUuid) Then
                    .targetAgentName = If(manager.GetCompanyByUUID(Me.targetAgentUuid) Is Nothing, "", manager.GetCompanyByUUID(Me.targetAgentUuid).name)
                End If


                ''вопрос
                .TargetStoreUUID = Me.targetStoreUuid
                .TargetStoreName = If(manager.GetWarehouseByUUID(Me.targetStoreUuid) Is Nothing, "", manager.GetWarehouseByUUID(Me.targetStoreUuid).name)
                .sourceStoreUuid = Me.sourceStoreUuid
                .sourceStoreName = If(manager.GetWarehouseByUUID(Me.sourceStoreUuid) Is Nothing, "", manager.GetWarehouseByUUID(Me.sourceStoreUuid).name)
                .retailStoreUuid = Me.retailStoreUuid
                .retailStoreName = If(manager.GetWarehouseByUUID(Me.retailStoreUuid) Is Nothing, "", manager.GetWarehouseByUUID(Me.retailStoreUuid).name)

                .TotalAmountInCurrency = Me.sum.sumInCurrency / 100
                .UUID = Me.uuid

                .Position = If(Me.customerOrderPosition Is Nothing OrElse Me.customerOrderPosition.Count = 0, New List(Of iMoySkladDataProvider.clsPosition), Me.customerOrderPosition.Select(Function(x) x.GetPositionTrilbone(manager, True)).ToList)


                .description = Me.description

                Dim _attrList As New List(Of iMoySkladDataProvider.clsEntity)

                For Each t In Me.attribute
                    Dim _new = New iMoySkladDataProvider.clsEntity
                    _new.UUID = t.uuid
                    Dim _cv = manager.GetCustomEntityByUUID(t.TryGetValue)

                    If Not _cv Is Nothing Then
                        'работаем с атрибутом сущности (подгруженной в МС)
                        _new.UUID = _cv.uuid
                        _new.Value = _cv.name
                        _new.MetaDataUUID = _cv.entityMetadataUuid
                        _new.MetaDataValue = manager.GetUserListNameByUUID(_cv.entityMetadataUuid)
                    Else
                        'в случае с неподгруженной сущностью MetaDataUUID будет пусто (проверь IsMetadataEmpty), а uuid сущности будет лежать в Value  -  по мере надобности можно подгрузить
                        _new.UUID = t.uuid
                        _new.Value = t.TryGetValue
                        'метод получения значения сущности(подзагружает в обьект значения)
                        _new.GetCustomValueDelegate = AddressOf manager.GetLoadCustomEntityByUUID
                    End If

                    _attrList.Add(_new)
                Next

                .attributes = _attrList
            End With
            Return _out
        End Function
    End Class

    Partial Class movePosition
        Public Function GetPositionTrilbone(manager As clsMoyScladManager, Optional LoadGoodInfo As Boolean = True) As iMoySkladDataProvider.clsPosition
            Dim _out As New iMoySkladDataProvider.clsPosition

            With _out
                .goodUuid = Me.goodUuid
                .Discount = Me.discount

                .BasePriceInCurrency = If(Me.basePrice Is Nothing, 0, Me.basePrice.sumInCurrency / 100)
                .PriceInCurrency = If(Me.price Is Nothing, 0, Me.price.sumInCurrency / 100)

                .quantity = Me.quantity
                '.ReserveQty = Me.reserve
                If LoadGoodInfo Then
                    Dim _good = manager.RequestGoodByUUID(Me.goodUuid)
                    If Not _good Is Nothing Then
                        .Articul = _good.productCode
                        .Code = _good.code
                        .GoodName = _good.name
                    End If
                End If
            End With
            Return _out
        End Function

    End Class

    Partial Class customerOrderPosition
        ''' <summary>
        '''LoadGoodInfo запросит артикул код и  имя позиции
        ''' </summary>
        ''' <param name="manager"></param>
        ''' <param name="LoadGoodInfo"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetPositionTrilbone(manager As clsMoyScladManager, Optional LoadGoodInfo As Boolean = True) As iMoySkladDataProvider.clsPosition
            Dim _out As New iMoySkladDataProvider.clsPosition

            With _out
                .goodUuid = Me.goodUuid
                .Discount = Me.discount

                .BasePriceInCurrency = If(Me.basePrice Is Nothing, 0, Me.basePrice.sumInCurrency / 100)
                .PriceInCurrency = If(Me.price Is Nothing, 0, Me.price.sumInCurrency / 100)

                .quantity = Me.quantity
                .ReserveQty = Me.reserve
                If LoadGoodInfo Then
                    Dim _good = manager.RequestGoodByUUID(Me.goodUuid)
                    If Not _good Is Nothing Then
                        .Articul = _good.productCode
                        .Code = _good.code
                        .GoodName = _good.name
                    End If
                End If
            End With
            Return _out
        End Function



    End Class


    Partial Class shipmentOut
        ''' <summary>
        '''LoadGoodInfo запросит артикул код и  имя позиции
        ''' </summary>
        ''' <param name="manager"></param>
        ''' <param name="LoadGoodInfo"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetPositionTrilbone(manager As clsMoyScladManager, Optional LoadGoodInfo As Boolean = True) As iMoySkladDataProvider.clsPosition
            Dim _out As New iMoySkladDataProvider.clsPosition

            With _out
                .goodUuid = Me.goodUuid
                .Discount = Me.discount

                .BasePriceInCurrency = If(Me.basePrice Is Nothing, 0, Me.basePrice.sumInCurrency / 100)
                .PriceInCurrency = If(Me.price Is Nothing, 0, Me.price.sumInCurrency / 100)
                .currencyName = "" 'не применимо
                .quantity = Me.quantity
                .ReserveQty = 0 'не применимо
                If LoadGoodInfo Then
                    Dim _good = manager.RequestGoodByUUID(Me.goodUuid)
                    If Not _good Is Nothing Then
                        .Articul = _good.productCode
                        .Code = _good.code
                        .GoodName = _good.name
                        .uomName = manager.GetUomByUUID(_good.uomUuid).name
                    End If
                End If
            End With
            Return _out
        End Function
    End Class

    Partial Class good
        ''' <summary>
        ''' позиция из товара
        ''' </summary>
        ''' <param name="manager"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetPositionTrilbone(manager As clsMoyScladManager) As iMoySkladDataProvider.clsPosition

            Dim _out As New iMoySkladDataProvider.clsPosition

            With _out
                .goodUuid = Me.uuid
                .Discount = 0 'не применимо

                .BasePriceInCurrency = If(Me.salePriceSpecified, Me.salePrice / 100, 0)
                ' .PriceInCurrency = If(Me.salePriceSpecified, Me.salePrice / 100, 0)
                .currencyName = manager.GetCurrencyByUUID(Me.saleCurrencyUuid).name

                .quantity = 1 'не применимо
                .ReserveQty = 0 'не применимо
                .Articul = Me.productCode
                .Code = Me.code
                .GoodName = Me.name
                .uomName = manager.GetUomByUUID(Me.uomUuid).name
            End With
            Return _out
        End Function



        Public Sub SetRetailPrice(manager As clsMoyScladManager, value As Decimal, currency As String)
            Me.salePrice = value * 100
            Me.saleCurrencyUuid = manager.GetCurrencyUUIDByName(currency)
            Me.salePriceSpecified = True
            Me.SetPriceByType(manager, iMoySkladDataProvider.emPriceType.RusShop, value, currency)
        End Sub

        ''' <summary>
        ''' запишет/создаст определенную цену. Цену передаем обычную! Валюту название! Все операции делает функция!!
        ''' </summary>
        ''' <param name="manager"></param>
        ''' <param name="priceType"></param>
        ''' <param name="value"></param>
        ''' <param name="currency"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function SetPriceByType(manager As clsMoyScladManager, priceType As iMoySkladDataProvider.emPriceType, value As Decimal, Optional currency As String = "") As Integer
            Dim _pr = (From c In manager.PricesList Where c.PriceType = priceType Select c).FirstOrDefault

            Dim _currencyUuid As String
            If String.IsNullOrEmpty(currency) Then
                _currencyUuid = manager.GetCurrencyUUIDByName(_pr.BaseCurrency)
            Else
                _currencyUuid = manager.GetCurrencyUUIDByName(currency)
            End If

            'минимальная цена
            If _pr.PriceType = iMoySkladDataProvider.emPriceType.MinimumPrice Then
                Me.minPrice = Math.Round(value, 2) * 100
                Return 1
            End If

            'закупочная цена
            If _pr.PriceType = iMoySkladDataProvider.emPriceType.BuyPrice Then
                Me.buyPrice = Math.Round(value, 2) * 100
                Me.buyCurrencyUuid = _currencyUuid
                Me.buyPriceSpecified = True
                Return 1
            End If

            'другие цены
            Return Me.SetPriceByUUID(manager, _pr.PriceTypeUUID, _currencyUuid, value)
        End Function


        ''' <summary>
        ''' запишет/создаст определенную цену. Цену передаем обычную! Все операции делает функция!!
        ''' </summary>
        ''' <param name="priceTypeUuid"></param>
        ''' <param name="value"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function SetPriceByUUID(manager As clsMoyScladManager, priceTypeUuid As String, currencyUuid As String, value As Decimal) As Integer
            value = Math.Round(value, 2) * 100

            Dim _list = New List(Of price)

            If Me.salePrices Is Nothing Then
                'цен вообще нет
                'записать блок цен
                For Each pr In manager.PricesList
                    Dim _np = New price With {.priceTypeUuid = pr.PriceTypeUUID, .value = 0, .valueSpecified = False, .currencyUuid = manager.GetCurrencyUUIDByName(pr.BaseCurrency)}
                    If pr.PriceTypeUUID.Equals(priceTypeUuid) And value > 0 Then
                        _np.currencyUuid = currencyUuid
                        _np.value = value
                        _np.valueSpecified = True
                        _list.Add(_np)
                    End If
                Next
            Else
                'цены какие-то есть
                _list = Me.salePrices.ToList
                'проверить наличие цены
                Dim _result = (From c In _list Where c.priceTypeUuid = priceTypeUuid Select c).FirstOrDefault

                If _result Is Nothing Then
                    'такой цены нет, добавить
                    Dim _newPrice As New price
                    With _newPrice
                        .priceTypeUuid = priceTypeUuid
                        .value = value
                        .valueSpecified = True
                        .currencyUuid = currencyUuid
                    End With
                    _list.Add(_newPrice)
                Else
                    'цена така есть
                    'изменить цену
                    _result.value = value
                    _result.valueSpecified = True
                    _result.currencyUuid = currencyUuid
                End If
            End If

            'обновить список цен
            Me.salePrices = _list.ToArray
            Return 1
        End Function

        ''' <summary>
        ''' прочтет определенную цену
        ''' </summary>
        ''' <param name="manager"></param>
        ''' <param name="priceType"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetPriceByType(manager As clsMoyScladManager, priceType As iMoySkladDataProvider.emPriceType) As price
            If salePrices Is Nothing Then Return New price
            Dim _pr = (From c In manager.PricesList Where c.PriceType = priceType Select c).FirstOrDefault
            Return GetPriceByUUID(_pr.PriceTypeUUID)
        End Function

        ''' <summary>
        ''' прочтет определенную цену
        ''' </summary>
        ''' <param name="priceTypeUuid"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function GetPriceByUUID(priceTypeUuid As String) As price
            If salePrices Is Nothing Then Return New price
            Dim _result = (From c In Me.salePrices.ToList Where c.priceTypeUuid = priceTypeUuid Select c).FirstOrDefault
            If _result Is Nothing Then _result = New price
            Return _result
        End Function

        ''' <summary>
        ''' вернет значение атрибута товара - для других типов есть флаг в данных
        ''' </summary>
        ''' <param name="metadataUUID"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetAttributeValue(metadataUUID As String, IsStringType As Boolean, IsTextType As Boolean, IsCustomEntityType As Boolean) As Object
            'ищем флаг в атрибутах товара
            Dim _resAttrValue As goodAttributeValue
            If Me.attribute Is Nothing Then Return Nothing

            _resAttrValue = (From c In Me.attribute Where c.metadataUuid = metadataUUID Select c).FirstOrDefault
            If Not _resAttrValue Is Nothing Then
                'значение есть
                If _resAttrValue.booleanValueSpecified Then
                    Return _resAttrValue.booleanValue
                End If
                If _resAttrValue.doubleValueSpecified Then
                    Return _resAttrValue.doubleValue
                End If

                If IsCustomEntityType Then
                    Return _resAttrValue.entityValueUuid
                End If
                If IsStringType Then
                    Return _resAttrValue.valueString
                End If
                If IsTextType Then
                    Return _resAttrValue.valueText
                End If
            End If

            Return Nothing
        End Function

    End Class

End Namespace