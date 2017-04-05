Imports Service.clsApplicationTypes
Imports Service
Imports Trilbone
Imports System.ComponentModel
Imports RestMS_Client.MoySkladAPI
Imports RestMS_Client.mdMoySkladExtentions.clsMoyScladManager
Imports RestMS_Client.SerialObj

Public Class clsRestMS_service
    Implements iMoySkladDataProvider

    ''' <summary>
    ''' delegat linked
    ''' </summary>
    ''' <param name="param"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetMoySkladFormAsForm(ByVal param As Object) As Form
        Dim _new As fmMoySklad = Nothing
        If oMoySkladManadger Is Nothing Then Return Nothing

        If param Is Nothing Then
            _new = New fmMoySklad(oMoySkladManadger)
        End If

        If TypeOf param Is String Then
            _new = New fmMoySklad(oMoySkladManadger)
        End If

        If TypeOf param Is Array Then
            Try
                Select Case CType(param, Array).Length
                    Case 1
                        'только номер (короткий)
                        _new = New fmMoySklad(oMoySkladManadger, CType(param(0), String), "")
                    Case 2
                        'номер и имя
                        _new = New fmMoySklad(oMoySkladManadger, CType(param(0), String), CType(param(1), String))
                    Case 3
                        'номер, имя и штрих-код
                        _new = New fmMoySklad(oMoySkladManadger, CType(param(0), String), CType(param(1), String), , CType(param(2), String))
                    Case 4
                        'номер, имя, штрих-код и артикул
                        _new = New fmMoySklad(oMoySkladManadger, CType(param(0), String), CType(param(1), String), CType(param(3), String), CType(param(2), String))
                    Case 5
                        'ошибка - не задана валюта
                        _new = New fmMoySklad(oMoySkladManadger)
                    Case 6
                        'номер, имя, штрих-код,артикул и данные о ценах
                        _new = New fmMoySklad(oMoySkladManadger, CType(param(0), String), CType(param(1), String), CType(param(3), String), CType(param(2), String), CType(param(4), Dictionary(Of String, Decimal)), CType(param(5), String))

                End Select
            Catch ex As Exception
                'неверные параметры
                _new = New fmMoySklad(oMoySkladManadger)
            End Try
        End If

        Return _new

    End Function

    'Public Shared ReadOnly Property User As emUsers
    '    Get
    '        Return ActiveUser
    '    End Get
    'End Property


    Public Sub New()
        '. сервис формы fmMoySklad
        'привязываем делегат к функции
        'передаем делегат (регестрируем) и список в сервисном классе
        Global.Service.clsApplicationTypes.DelegateStoreApplicationForm _
            (emFormsList.fmMoySklad) = _
            New ApplicationFormDelegateFunction(AddressOf GetMoySkladFormAsForm)

        ''привязываем делегат к функции
        ''передаем делегат (регестрируем) и список в сервисном классе
        'блокировка МС 14/11/2016
        Global.Service.clsApplicationTypes.DelegatStoreMCCreateManager = New Func(Of String, String, Object)(AddressOf CreateManager)


        Global.Service.clsApplicationTypes.DelegatStoreMCinterface = New Func(Of Boolean, iMoySkladDataProvider)(AddressOf GetInterface)


        ''клиенты
        Global.Service.clsApplicationTypes.DelegatStoreGetClientsFromMS = New clsApplicationTypes.GetClientsFromMSDelegateFunction(AddressOf GetClients)


        'GetSampleListFromMSDelegateFunction
        Global.Service.clsApplicationTypes.DelegateStoreGetSampleListFromMS = New Service.clsApplicationTypes.GetSampleListFromMSDelegateFunction(AddressOf GetSampleListFromOrder)


        'SetSampleToAuction
        Global.Service.clsApplicationTypes.DelegateStoreSetSampleToDemandMS = New Service.clsApplicationTypes.SetSampleToDemandMSDelegateFunction(AddressOf SetSampleToAuctionOld)

    End Sub

    Private Shared oMoySkladManadger As clsMoyScladManager

    ''' <summary>
    ''' вернет обьект управления МС
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property Manager As clsMoyScladManager
        Get
            Return oMoySkladManadger
        End Get
    End Property

    ''' <summary>
    ''' создает менеджер мойсклад и вернет обьект
    ''' </summary>
    ''' <param name="username"></param>
    ''' <param name="password"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CreateManager(username As String, password As String) As clsMoyScladManager
        '15/11/2016 блокировать МС
        Return Nothing

        If oMoySkladManadger Is Nothing Then
            oMoySkladManadger = clsMoyScladManager.CreateInstance(username, password)
            If oMoySkladManadger Is Nothing Then
                MsgBox("Проблема с подключением по интернету или сервером Мой Склад: перезапустите приложение.", vbCritical)
                Return Nothing
            End If
            'делегат инфо о товаре
            clsApplicationTypes.DelegatStoreMCGoodInfo = New Func(Of String, List(Of clsApplicationTypes.clsSampleNumber.strGoodInfo))(AddressOf oMoySkladManadger.GetGoodInfo)
        Else
            If Not oMoySkladManadger.CurrentMSUserName.ToLower.Equals(username.ToLower) Then
                'смена лузера мс
                oMoySkladManadger = clsMoyScladManager.CreateInstance(username, password)
            End If
        End If
        Return oMoySkladManadger
    End Function

    Public Shared Function GetSampleListFromOrder(MoySkladOrderNumber As String, ByRef CustomerName As String) As List(Of clsSampleNumber)
        Dim _or = RestMS_Client.clsRestMS_service.GetOrderByName(MoySkladOrderNumber).FirstOrDefault
        Dim _out As New List(Of clsSampleNumber)
        If _or Is Nothing Then Return _out
        _out.AddRange(_or.SampleList)
        CustomerName = _or.CustomerName
        Return _out
    End Function



    ''' <summary>
    ''' поставит образец в отгрузку по заданному аукциону. AgentName определит отгрузку 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function SetSampleToAuctionOld(ShotNumber As String, AgentName As String, AgentAccount As String, FeeAmount As Decimal, ItemFirstPrice As Decimal) As Integer
        'получить обьект отгрузки AuctionDemandUUID As String
        'получить UUID образца
        'добавить запись в ShipmentOut
        'сохранить отгрузку
        'записать в мой склад списание и fee в расходы???
        'есть - имя агента
        'номер камня
        'сумма денег за выставление
        'дата выставления

        Dim AuctionDemandUUID As String = ""
        Dim _demand As MoySkladAPI.demand
        Dim _good As MoySkladAPI.good

        If AgentName.ToLower = "ebay".ToLower And AgentAccount.ToLower = "trilbone" Then
            AuctionDemandUUID = My.Settings.EbayTrilboneDemandUUID
        End If
        ''времмено
        If AgentName.ToLower = "ebay".ToLower And AgentAccount.ToLower = "trilbone_test" Then
            AuctionDemandUUID = My.Settings.EbayTrilboneDemandUUID
        End If


        If AuctionDemandUUID = "" Then Return -1

        If oMoySkladManadger Is Nothing Then
            Return -1
        End If

        Dim _result As IEnumerable(Of Object) = Nothing

        Dim _message As String = ""
        Dim _rawdata As String = ""
        Dim _status = oMoySkladManadger.RequestAnyCollection(clsMoyScladManager.emMoySkladObjectTypes.Demand, _result, AuctionDemandUUID, clsMoyScladManager.emMoySkladFilterTypes.uuid, _message, _rawdata, "")

        Select Case _status

            Case Net.HttpStatusCode.OK
                If _result.Count = 0 Then
                    Return -1
                End If

                _demand = CType(_result(0), MoySkladAPI.demand)

                'получим образец
                'ищем по артикулу
                _status = oMoySkladManadger.RequestAnyCollection(clsMoyScladManager.emMoySkladObjectTypes.Good, _result, ShotNumber, clsMoyScladManager.emMoySkladFilterTypes.productCode, _message)
                Select Case _status
                    Case Net.HttpStatusCode.OK
                        If _result.Count = 0 Then
                            'не найдено
                            'ищем по коду
                            _status = oMoySkladManadger.RequestAnyCollection(clsMoyScladManager.emMoySkladObjectTypes.Good, _result, ShotNumber, clsMoyScladManager.emMoySkladFilterTypes.code, _message)
                            Select Case _status
                                Case Net.HttpStatusCode.OK
                                    If _result.Count = 0 Then
                                        'не найдено
                                        GoTo notfound
                                    Else
                                        clsApplicationTypes.BeepYES()
                                        GoTo ex
                                    End If
                                Case Net.HttpStatusCode.NotFound
                                    GoTo notfound
                                Case Else
                                    'ошибка запроса
                                    '    Me.oSplashscreen1.Hide()
                                    MsgBox("Ошибка запроса товара по коду " & ShotNumber & " !" & ChrW(13) & _message, MsgBoxStyle.Critical)
                                    Return -1
                            End Select
                        Else
                            clsApplicationTypes.BeepYES()
                            GoTo ex
                        End If

                    Case Net.HttpStatusCode.NotFound
                        'ищем по коду
                        _status = oMoySkladManadger.RequestAnyCollection(clsMoyScladManager.emMoySkladObjectTypes.Good, _result, ShotNumber, clsMoyScladManager.emMoySkladFilterTypes.code, _message)
                        Select Case _status
                            Case Net.HttpStatusCode.OK
                                If _result.Count = 0 Then
                                    'не найдено
                                    GoTo notfound
                                Else
                                    clsApplicationTypes.BeepYES()
                                    GoTo ex
                                End If
                            Case Net.HttpStatusCode.NotFound
                                GoTo notfound
                            Case Else
                                'ошибка запроса
                                ' Me.oSplashscreen1.Hide()
                                MsgBox("Ошибка запроса товара по коду " & ShotNumber & " !" & ChrW(13) & _message, MsgBoxStyle.Critical)
                                Return -1
                        End Select
                    Case Else
                        'ошибка запроса
                        ' Me.oSplashscreen1.Hide()
                        MsgBox("Ошибка запроса товара по артикулу " & ShotNumber & " !" & ChrW(13) & _message, MsgBoxStyle.Critical)
                        Return -1
                End Select


            Case Else

                Return -1



        End Select

ex:
        'карточка есть
        _good = CType(_result(0), MoySkladAPI.good)
        'проверим склад
        Dim _msGood = clsMSGood.CreateInstance(_good)
        If _msGood.FindLocations(oMoySkladManadger, True) = False Then
            'нет на складе
            Return -1
        End If
        If _msGood.TotalQTY = 0 Then
            Return -1
        End If

        'в этой точке есть товар и он есть на складе
        'список доступных местоположений товара (как в основной форме)
        Dim _strLoc = (From c In _msGood.SlotList Select c.SlotString).ToList

        'ОТГРУЗКА
        Dim _old = _demand.shipmentOut

        Dim _pos As New List(Of RestMS_Client.MoySkladAPI.shipmentOut)

        If _demand.shipmentOut Is Nothing Then
            _demand.shipmentOut = _pos.ToArray
        End If

        'сохраним старые позиции 
        For Each t In _demand.shipmentOut
            _pos.Add(t)
        Next
        Dim _demandcurrencyUUID = _demand.currencyUuid

        Dim _new = New MoySkladAPI.shipmentOut
        With _new
            'товар
            .goodUuid = _msGood.Good.uuid
            'количество
            .quantity = 1
            'ячейка
            '.slotUuid =
            '---------------
            Dim _price As New RestMS_Client.MoySkladAPI.moneyAmount

            If Not _demandcurrencyUUID = "" Then
                _price.sumInCurrency = Math.Round(ItemFirstPrice * 100, 2)
                _price.sumInCurrencySpecified = True
            End If
            _price.sum = Math.Round(ItemFirstPrice * 100, 2)
            _price.sumSpecified = True
            '-----
            .price = _price
            .basePrice = _price
        End With

        _pos.Add(_new)

        'обновит 
        _demand.shipmentOut = _pos.ToArray
        'теперь вызовем обновление базы
        Dim _out As String = ""
        Dim _serverMessage As String = ""

        Dim _res2 = oMoySkladManadger.AddAnyToServer(clsMoyScladManager.emMoySkladObjectTypes.Demand, _demand, _out, _serverMessage)
        Select Case _res2
            Case Net.HttpStatusCode.OK
                Return 1
            Case Else
                MsgBox("Не удалось поместить товар в оприходование на сервер", vbCritical)
                Return -1
        End Select


notfound:
        'товара нет в карточках
        Return -2
    End Function



    ''' <summary>
    ''' вернет обьекты по номеру заказа
    ''' </summary>
    ''' <param name="OrderNumber"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetOrderByName(OrderNumber As String) As List(Of Service.clsRestMS_CustomerOrder)
        Dim _result As New List(Of Service.clsRestMS_CustomerOrder)

        'Dim _manager = clsMoyScladManager.CreateInstance("solution@trilbone", "Hasmops2014")

        If oMoySkladManadger Is Nothing Then
            Return _result
        End If

        Dim _filter As clsMoyScladManager.emMoySkladFilterTypes = clsMoyScladManager.emMoySkladFilterTypes.name
        Dim _reqresult As IEnumerable(Of Object) = Nothing
        Dim _out As IEnumerable(Of Object) = Nothing

        Dim _message As String = ""
        Dim _rawdata As String = ""
        Dim _status = oMoySkladManadger.RequestAnyCollection(clsMoyScladManager.emMoySkladObjectTypes.CustomerOrder, _reqresult, OrderNumber, _filter, _message, _rawdata, "")
        If _status = Net.HttpStatusCode.OK Then
            'заказ найден
            For Each t As MoySkladAPI.customerOrder In _reqresult
                Dim _new = New Service.clsRestMS_CustomerOrder

                'запрос покупателя
                _filter = clsMoyScladManager.emMoySkladFilterTypes.uuid
                _status = oMoySkladManadger.RequestAnyCollection(clsMoyScladManager.emMoySkladObjectTypes.Company, _out, t.sourceAgentUuid, _filter, _message, _rawdata, "")
                If _status = Net.HttpStatusCode.OK Then
                    If _out.Count > 0 Then
                        _new.CustomerName = CType(_out(0), MoySkladAPI.company).name

                    End If
                Else
                    _new.HasError = True
                End If
                'запрос валюты
                _status = oMoySkladManadger.RequestAnyCollection(clsMoyScladManager.emMoySkladObjectTypes.Currency, _out, t.currencyUuid, _filter, _message, _rawdata, "")
                If _status = Net.HttpStatusCode.OK Then
                    If _out.Count > 0 Then
                        _new.Currency = CType(_out(0), MoySkladAPI.currency).name
                    End If

                Else
                    _new.HasError = True
                End If
                'описание
                _new.Description = t.description
                'запрос списка образцов
                For Each s In t.customerOrderPosition
nx:
                    _status = oMoySkladManadger.RequestAnyCollection(clsMoyScladManager.emMoySkladObjectTypes.Good, _out, s.goodUuid, _filter, _message, _rawdata, "")
                    If _status = Net.HttpStatusCode.OK AndAlso _out.Count > 0 Then
                        Dim _good = CType(_out(0), MoySkladAPI.good)
                        Dim _code As String = _good.code
                        If _code = "" Then
                            _code = _good.productCode
                        End If
                        Dim _number = Service.clsApplicationTypes.clsSampleNumber.CreateFromString(_code)

                        If Not (_number Is Nothing OrElse _number.CodeIsCorrect = False) Then
                            Dim _prices As New Service.clsApplicationTypes.clsSampleNumber.strPrices
                            With _prices
                                .PriceWithDiscount = Math.Round(s.price.sumInCurrency / 100, 2)
                                .Discount = s.discount
                                .BasePrice = Math.Round(s.basePrice.sumInCurrency / 100, 2)
                                .Currency = _new.Currency
                            End With
                            Dim _info = _number.GetExtendedInfo(_prices)
                            _info.SetSampleName(_good.name)
                            _new.SampleList.Add(_number)
                        Else
                            _new.HasError = True
                        End If

                    ElseIf _status = Net.HttpStatusCode.Unauthorized Then
                        For i = 0 To 10000

                        Next
                        GoTo nx
                    Else
                        _new.HasError = True
                    End If
                Next
                _result.Add(_new)
            Next
        End If

        Return _result
    End Function


    ''' <summary>
    ''' вызовет цифровую клавиатуру
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property GetDigiKey As Object
        Get
            Return Service.clsApplicationTypes.GetDigiKeyBoardForm
        End Get
    End Property

#Region "Интерфейс iMoySkladDataProvider - раздел Операции с аукционами"




    ''' <summary>
    ''' Свяжет документы вместе
    ''' </summary>
    ''' <param name="CustomerOrderUUID">заказ клиента</param>
    ''' <param name="DemandUUID">отгрузка</param>
    ''' <param name="PaymentInUUID">входящий платеж</param>
    Public Function LinkOrderDemandPaymentIn(CustomerOrderUUID As String, DemandUUID As String, PaymentInUUID As String) As Boolean Implements iMoySkladDataProvider.LinkOrderDemandPaymentIn
        'НЕ ПРОТЕСТИРОВАНО
        'получить UUID
        Dim _message As String = ""
        Dim _result As IEnumerable(Of Object) = Nothing
        Dim _order As customerOrder
        Dim _demand As demand = Nothing
        Dim _paymentin As paymentIn = Nothing

        If String.IsNullOrWhiteSpace(CustomerOrderUUID) Then Return False

        Select Case oMoySkladManadger.RequestAnyCollection(clsMoyScladManager.emMoySkladObjectTypes.CustomerOrder, _result, CustomerOrderUUID, clsMoyScladManager.emMoySkladFilterTypes.uuid, _message)
            Case Net.HttpStatusCode.OK
                _order = _result.Cast(Of customerOrder)().FirstOrDefault
                If _order Is Nothing Then
                    MsgBox("Не удалось получить заказ. Не найден. Серверное сообщение: " & _message)
                    Return False
                End If
            Case Else
                MsgBox("Не удалось получить заказ. Серверное сообщение: " & _message)
                Return False
        End Select

        _message = ""
        _result = Nothing
        If Not DemandUUID = "" Then
            Select Case oMoySkladManadger.RequestAnyCollection(clsMoyScladManager.emMoySkladObjectTypes.Demand, _result, DemandUUID, clsMoyScladManager.emMoySkladFilterTypes.uuid, _message)
                Case Net.HttpStatusCode.OK
                    _demand = _result.Cast(Of demand)().FirstOrDefault
                    If _demand Is Nothing Then
                        MsgBox("Не удалось получить отгрузку. Не найдена. Серверное сообщение: " & _message)
                        Return False
                    End If
                Case Else
                    MsgBox("Не удалось получить отгрузку. Серверное сообщение: " & _message)
                    Return False
            End Select
        End If


        _message = ""
        _result = Nothing
        If Not PaymentInUUID = "" Then
            Select Case oMoySkladManadger.RequestAnyCollection(clsMoyScladManager.emMoySkladObjectTypes.PaymentIn, _result, PaymentInUUID, clsMoyScladManager.emMoySkladFilterTypes.uuid, _message)
                Case Net.HttpStatusCode.OK
                    _paymentin = _result.Cast(Of paymentIn)().FirstOrDefault
                    If _paymentin Is Nothing Then
                        MsgBox("Не удалось получить входящий платеж. Не найден. Серверное сообщение: " & _message)
                        Return False
                    End If
                Case Else
                    MsgBox("Не удалось получить входящий платеж. Серверное сообщение: " & _message)
                    Return False
            End Select
        End If


        'все ок и получено
        If Not _demand Is Nothing Then
            _order.demandsUuid = {_demand.uuid}
            _demand.customerOrderUuid = _order.uuid
        End If

        If Not _paymentin Is Nothing Then
            _order.paymentsUuid = {_paymentin.uuid}
            _paymentin.customerOrderUuid = _order.uuid
        End If


        'сохранить
        Dim _respond As String = ""

        _respond = ""
        If Not _demand Is Nothing Then
            Select Case oMoySkladManadger.AddAnyToServer(clsMoyScladManager.emMoySkladObjectTypes.Demand, _demand, _respond, _message)
                Case Net.HttpStatusCode.OK
                    If clsMSObjectReader(Of demand).CreatInstance(_respond) Is Nothing Then
                        MsgBox("Не удалось обновить отгрузку. Серверное сообщение: " & _message)
                        Return False
                    End If
                Case Else
                    MsgBox("Не удалось обновить отгрузку. Серверное сообщение: " & _message)
                    Return False
            End Select
        End If

        _respond = ""
        If Not _paymentin Is Nothing Then
            Select Case oMoySkladManadger.AddAnyToServer(clsMoyScladManager.emMoySkladObjectTypes.PaymentIn, _paymentin, _respond, _message)
                Case Net.HttpStatusCode.OK
                    If clsMSObjectReader(Of paymentIn).CreatInstance(_respond) Is Nothing Then
                        MsgBox("Не удалось обновить входящий платеж. Серверное сообщение: " & _message)
                        Return False
                    End If
                Case Else
                    MsgBox("Не удалось обновить входящий платеж. Серверное сообщение: " & _message)
                    Return False
            End Select
        End If

        _respond = ""
        Select Case oMoySkladManadger.AddAnyToServer(clsMoyScladManager.emMoySkladObjectTypes.CustomerOrder, _order, _respond, _message)
            Case Net.HttpStatusCode.OK
                If clsMSObjectReader(Of customerOrder).CreatInstance(_respond) Is Nothing Then
                    MsgBox("Не удалось обновить заказ. Серверное сообщение: " & _message)
                    Return False
                End If
            Case Else
                MsgBox("Не удалось обновить заказ. Серверное сообщение: " & _message)
                Return False
        End Select




     

        Return True
    End Function

    ''' <summary>
    ''' Смена статуса выполнения заказа
    ''' </summary>
    Public Function ChangeStatusCustomerOrder(CustomerOrderUUID As String, NewStatusUUID As String) As Boolean Implements iMoySkladDataProvider.ChangeStatusCustomerOrder
        'ТЕСТИРОВАНО
        'получить UUID
        Dim _message As String = ""
        Dim _result As IEnumerable(Of Object) = Nothing
        Dim _order As customerOrder

        Select Case oMoySkladManadger.RequestAnyCollection(clsMoyScladManager.emMoySkladObjectTypes.CustomerOrder, _result, CustomerOrderUUID, clsMoyScladManager.emMoySkladFilterTypes.uuid, _message)
            Case Net.HttpStatusCode.OK
                _order = _result.Cast(Of customerOrder)().FirstOrDefault
                If _order Is Nothing Then
                    MsgBox("Не удалось получить заказ. Не найден. Серверное сообщение: " & _message)
                    Return False
                End If
            Case Else
                MsgBox("Не удалось получить заказ. Серверное сообщение: " & _message)
                Return False
        End Select

        _order.stateUuid = NewStatusUUID


        'сохранить
        Dim _respond As String = ""
        Select Case oMoySkladManadger.AddAnyToServer(clsMoyScladManager.emMoySkladObjectTypes.CustomerOrder, _order, _respond, _message)
            Case Net.HttpStatusCode.OK
                If clsMSObjectReader(Of customerOrder).CreatInstance(_respond) Is Nothing Then
                    MsgBox("Не удалось обновить заказ. Серверное сообщение: " & _message)
                    Return False
                End If
            Case Else
                MsgBox("Не удалось обновить заказ. Серверное сообщение: " & _message)
                Return False
        End Select

        Return True
    End Function

    ''' <summary>
    ''' Смена статуса отгрузки
    ''' </summary>
    Public Function ChangeStatusDemand(DemandUUID As String, NewStatusUUID As String) As Boolean Implements iMoySkladDataProvider.ChangeStatusDemand

        'ТЕСТИРОВАНО

        'получить UUID
        Dim _message As String = ""
        Dim _result As IEnumerable(Of Object) = Nothing
        Dim _demand As demand

        Select Case oMoySkladManadger.RequestAnyCollection(clsMoyScladManager.emMoySkladObjectTypes.Demand, _result, DemandUUID, clsMoyScladManager.emMoySkladFilterTypes.uuid, _message)
            Case Net.HttpStatusCode.OK
                _demand = _result.Cast(Of demand)().FirstOrDefault
                If _demand Is Nothing Then
                    MsgBox("Не удалось получить заказ. Не найден. Серверное сообщение: " & _message)
                    Return False
                End If
            Case Else
                MsgBox("Не удалось получить заказ. Серверное сообщение: " & _message)
                Return False
        End Select

        _demand.stateUuid = NewStatusUUID


        'сохранить
        Dim _respond As String = ""
        Select Case oMoySkladManadger.AddAnyToServer(clsMoyScladManager.emMoySkladObjectTypes.Demand, _demand, _respond, _message)
            Case Net.HttpStatusCode.OK
                If clsMSObjectReader(Of demand).CreatInstance(_respond) Is Nothing Then
                    MsgBox("Не удалось обновить заказ. Серверное сообщение: " & _message)
                    Return False
                End If
            Case Else
                MsgBox("Не удалось обновить заказ. Серверное сообщение: " & _message)
                Return False
        End Select

        Return True
    End Function
    ''' <summary>
    ''' получить папку товара
    ''' </summary>
    ''' <param name="ShotCode"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function FindGoodCategory(ShotCode As String) As String Implements iMoySkladDataProvider.FindGoodCategory
        Dim _result As New List(Of good)
        If oMoySkladManadger.FindGoods(ShotCode:=ShotCode, ShotArticul:="", PartOfName:="", FoundGoods:=_result) > 0 Then
            Dim _good = _result(0)
            Return _good.parentUuid
        Else
            Return ""
        End If
    End Function

    Public Function FindCellByGood(ShotCode As String, WareHouseName As String, Optional IncludeReserved As Boolean = False, Optional GoodUUID As String = "") As List(Of iMoySkladDataProvider.strGoodMapQty) Implements iMoySkladDataProvider.FindCellByGood

        Dim _wareUUID = oMoySkladManadger.GetWarehousUUIDbyName(WareHouseName)

        If String.IsNullOrEmpty(_wareUUID) Then
            Return New List(Of iMoySkladDataProvider.strGoodMapQty)
        End If


        Dim _uuID As String = ""
        If String.IsNullOrEmpty(ShotCode) Then
            If Not String.IsNullOrEmpty(GoodUUID) Then
                _uuID = GoodUUID
            Else
                Return New List(Of iMoySkladDataProvider.strGoodMapQty)
            End If
        Else
            Dim _goods As IEnumerable(Of good) = Nothing
            Dim _req = oMoySkladManadger.FindGoods(ShotCode, "", "", _goods)
            If _req <= 0 Then
                Return New List(Of iMoySkladDataProvider.strGoodMapQty)
            End If
            _uuID = _goods(0).uuid
        End If

        Return oMoySkladManadger.FindCellsForGood(_uuID, _wareUUID, IncludeReserved)
    End Function

    Private oBusy As Boolean

    Public Property Busy As Boolean Implements iMoySkladDataProvider.Busy
        Get
            Return oBusy
        End Get
        Set(value As Boolean)
            oBusy = value
        End Set
    End Property

    ''' <summary>
    ''' найдет товары в ячейке
    ''' </summary>
    ''' <param name="WarehouseName"></param>
    ''' <param name="SlotName"></param>
    ''' <param name="_status"></param>
    ''' <param name="_message"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function FindGoodsByCell(WarehouseName As String, SlotName As String, ByRef _status As Integer, Optional ByRef _message As String = "") As List(Of iMoySkladDataProvider.strGoodMapQty) Implements iMoySkladDataProvider.FindGoodsByCell
        Do While Me.Busy
            'занят другим запросом
        Loop
        ''--------
        Dim _out As New List(Of iMoySkladDataProvider.strGoodMapQty)
        Dim _ServerMessage As String = ""
        Dim _wareUUID = oMoySkladManadger.GetWarehousUUIDbyName(WarehouseName)
        If String.IsNullOrEmpty(_wareUUID) Then
            _status = -1
            _message = "Имя склада указано неверно"
            Me.Busy = False
            Return _out
        End If
        Dim _slotUUID = oMoySkladManadger.GetSlotUUIDByName(_wareUUID, SlotName)
        If String.IsNullOrEmpty(_slotUUID) Then
            _status = -2
            _message = "Имя(номер) ячейки указан неверно"
            Me.Busy = False
            Return _out
        End If

        Dim _data As IEnumerable(Of Object) = Nothing

        Dim _req = oMoySkladManadger.RequestAnyCollection(clsMoyScladManager.emTOMoySkladTypes.slotStateReportTO, _data, _wareUUID, , , , _ServerMessage, "")


        Select Case _req
            Case Net.HttpStatusCode.OK
                Dim _slotCollection = (From c As SerialObj.slotStateReportTO In _data Where (c.slotRef.name = SlotName) And c.quantity > 0 Select c).ToList
                'отобранные по имени ячейки с товарами
                _out = _slotCollection.Select(Function(x) x.GetGoodQty).ToList
                _status = _out.Count
                _message = "Ok"
                Me.Busy = False
                Return _out
            Case Else
                _status = -3
                _message = _ServerMessage
                Me.Busy = False
                Return _out
        End Select
    End Function

    ''' <summary>
    ''' запрос остатков/ вернет массив по складам NamePart можно и не задавать
    ''' </summary>
    ''' <param name="NamePart"></param>
    ''' <param name="ShotCode"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function FindStokQuantity(NamePart As String, Optional ShotCode As String = "", Optional WareHouseName As String = "", Optional IncludeReserved As Boolean = False, Optional GroupUUID As String = "", Optional GoodUUID As String = "") As List(Of iMoySkladDataProvider.clsStokQuantity) Implements iMoySkladDataProvider.FindStokQuantity
        Dim _message As String = ""
        Dim _out = New List(Of iMoySkladDataProvider.clsStokQuantity)
        Dim _result As IEnumerable(Of Object) = Nothing
        Dim _goodUUID As String() = {}

        If String.IsNullOrEmpty(GroupUUID) Then
            'фильтр по товару
            If Not String.IsNullOrEmpty(GoodUUID) Then
                _goodUUID = {GoodUUID}
            ElseIf Not String.IsNullOrEmpty(ShotCode) Then
                _goodUUID = Me.FindGoods("", ShotCode).Select(Function(x) x.UUID).ToArray
            Else
                _goodUUID = {}
            End If
        Else
            'фильтр по группе
            _goodUUID = {GroupUUID}
        End If

        'тип остатка
        Dim _sm = emStockMode.POSITIVE_ONLY
        If IncludeReserved Then
            _sm = emStockMode.POSITIVE_INCLUDING_RESERVE_ONLY
        End If

        'фильтр по складам
        Dim _wareUUIDColl As New List(Of String)
        If Not String.IsNullOrEmpty(WareHouseName) Then
            'задан склад - только запрашиваемый
            Dim _ware = oMoySkladManadger.GetWarehousUUIDbyName(WareHouseName)
            If Not String.IsNullOrEmpty(_ware) Then
                _wareUUIDColl.Add(_ware)
            Else
                'склад не найден - все доступные
                _wareUUIDColl = (From c In oMoySkladManadger.WarehouseList Select c.uuid).ToList
            End If
        Else
            'склад не задан - все доступные
            _wareUUIDColl = (From c In oMoySkladManadger.WarehouseList Select c.uuid).ToList
        End If

        'запрос
        For Each w In _wareUUIDColl
            Dim _status = oMoySkladManadger.RequestAnyCollection(TOobjectType:=emTOMoySkladTypes.stockTO, GoodNamePart:=NamePart, _data:=_result, _requestbody:="", ServerMessage:=_message, WarehouseUUID:=w, StockMode:=_sm, goodUUID:=_goodUUID)
            If _status = Net.HttpStatusCode.OK Then
                If _result.Count = 0 Then Return _out
                Dim _stok = _result.Cast(Of stockTO)().ToList

                Dim _res = (From c In _stok Where ((Not String.IsNullOrEmpty(c.productCode)) Or (Not String.IsNullOrEmpty(c.goodRef.code))) And c.stock > 0 Select c.GetStokQuantity(oMoySkladManadger.GetWarehouseByUUID(w).name, w)).ToList

                _out.AddRange(_res)
            End If
        Next

        Return _out
    End Function

    ''' <summary>
    ''' вернет найденные образцы
    ''' </summary>
    ''' <param name="UUID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function FindGoodByUUID(UUID As String) As clsApplicationTypes.clsSampleNumber.strGoodInfo Implements iMoySkladDataProvider.FindGoodsByUUID
        Return oMoySkladManadger.GetGoodInfoByUUID(UUID)
    End Function


    ''' <summary>
    ''' вернет найденные образцы
    ''' </summary>
    ''' <param name="PartOfName">выражение поиска</param>
    ''' <param name="GoodShotCode">фильтр</param>
    ''' <param name="AllWord">все слова будут И</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function FindGoods(PartOfName As String, Optional GoodShotCode As String = "", Optional AllWord As Boolean = False) As List(Of clsApplicationTypes.clsSampleNumber.strGoodInfo) Implements iMoySkladDataProvider.FindGoods
        Dim _result As New List(Of clsApplicationTypes.clsSampleNumber.strGoodInfo)
        PartOfName.Trim()
        '-----------------------
        If Not GoodShotCode = "" Then
            _result = oMoySkladManadger.GetGoodInfo(GoodShotCode)
            If Not PartOfName = "" Then
                _result = (From c In _result Where c.Name.ToLower.Contains(PartOfName.ToLower) Select c).ToList
            End If
            Return _result
        End If
        '----------------------
        Dim _goods As New List(Of good)
        If oMoySkladManadger.FindGoods("", "", PartOfName, _goods) > 0 Then
            For Each g In _goods
                If Not g.code = "" Then
                    _result.AddRange(oMoySkladManadger.GetGoodInfo(g.code))
                End If
                If Not g.productCode = "" Then
                    _result.AddRange(oMoySkladManadger.GetGoodInfo(g.productCode))
                End If
            Next
            Return _result
        End If
        '----------------------
        Return _result
    End Function


    ''' <summary>
    ''' проверка наличия клиента в МС. В случает успеха получим (contains(FullName) OR Email OR CustomerCode)
    ''' </summary>
    ''' <param name="PartName"></param>
    ''' <param name="Email"></param>
    ''' <param name="CustomerCode"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function FindCustomer(PartName As String, Email As String, CustomerCode As String, Optional reload As Boolean = False) As iMoySkladDataProvider.clsClientInfo() Implements iMoySkladDataProvider.FindCustomer
        'тестирована
        Dim _result1 = (From c In oMoySkladManadger.CustomerList(reload) Where IIf(PartName = "", False, c.name.ToLower.Contains(PartName.ToLower)) Or IIf(CustomerCode = "", False, c.code.ToLower.Equals(CustomerCode.ToLower)) Select c).ToList

        Dim _result2 = (From c In oMoySkladManadger.CustomerList(reload) Where (Not c.contact Is Nothing) AndAlso IIf(Email = "", False, c.contact.email.ToLower.Equals(Email.ToLower)) Select c).ToList

        Dim _result = _result1.Union(_result2)

        _result.Distinct()

        If _result.Count = 0 Then Return New iMoySkladDataProvider.clsClientInfo() {}
        Dim _out As New List(Of iMoySkladDataProvider.clsClientInfo)
        For Each t As company In _result
            If (Not t.contact Is Nothing) Then
                _out.Add(t.GetClientInfo)
            End If
        Next
        _out.Sort()
        Return _out.ToArray
    End Function

    ''' <summary>
    ''' сохранить клиента
    ''' </summary>
    ''' <param name="customer"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SaveCustomer(customer As iMoySkladDataProvider.clsClientInfo) As iMoySkladDataProvider.clsClientInfo Implements iMoySkladDataProvider.SaveCustomer
        'ДОБАВЛЕНЫ НЕ ВСЕ ПОЛЯ ДЛЯ СОХРАНЕНИЯ

        Dim _com = oMoySkladManadger.GetCustomerByUUID(customer.UUID)
        Debug.Assert(Not _com Is Nothing)
        If _com Is Nothing Then Return Nothing
        With _com
            .name = customer.FullName
            .code = customer.MSCode
            If Not .contact Is Nothing Then
                .contact.email = customer.Email
            Else
                .contact = New contact With {.email = customer.Email}
            End If

            '.requisite = New requisite With {.actualAddress = AddressString}
            ''тип цен - розница
            '.priceTypeUuid = "b14b6444-489b-11e3-36cc-7054d21a8d1e"
            ''персональная скидка
            ''.discount
            '.description = description
            '.tags = ClientMCTags
        End With
        '=========
        'атрибуты
        Dim _metadata = ""
        Dim _Value As Object
        Dim _attrList As New List(Of agentAttributeValue)
        If Not _com.attribute Is Nothing Then
            _attrList.AddRange(_com.attribute)
        Else
            _com.attribute = New agentAttributeValue() {}
        End If
        '---функции работы с атрибутами
        Dim _deletefn = Sub(metadataUUID As String)
                            'ищем флаг в атрибутах товара
                            Dim _resAttrValue1 As agentAttributeValue
                            _resAttrValue1 = (From c In _com.attribute Where c.metadataUuid = metadataUUID Select c).FirstOrDefault
                            If Not _resAttrValue1 Is Nothing Then
                                'да - удалим
                                _attrList.Remove(_resAttrValue1)
                            End If
                        End Sub


        Dim _addfn = Sub(attributeValue As Object, metadataUUID As String, IsBooleanType As Boolean, IsStringType As Boolean, IsDecimalType As Boolean, IsTextType As Boolean, IsCustomEntityType As Boolean)
                         'ищем флаг в атрибутах товара
                         Dim _resAttrValue As agentAttributeValue
                         _resAttrValue = (From c In _com.attribute Where c.metadataUuid = metadataUUID Select c).FirstOrDefault
                         If Not _resAttrValue Is Nothing Then
                             'удалить атрибут
                             _deletefn(metadataUUID)
                         End If
                         'нет - создаем обьект атрибута и добавляем его в коллекцию
                         _resAttrValue = agentAttributeValue.CreateInstance(_com.uuid, metadataUUID, attributeValue, IsBooleanType, IsStringType, IsDecimalType, IsTextType, IsCustomEntityType)
                         _attrList.Add(_resAttrValue)
                     End Sub
        '-=============
        ''предпочтительный емайл для отправки
        ''определим значение атрибута
        _Value = customer.MainSourceEmail
        _metadata = "589dd945-4ac2-11e6-7a69-8f55001394f6"
        _addfn(_Value, _metadata, IsBooleanType:=False, IsStringType:=True, IsDecimalType:=False, IsTextType:=False, IsCustomEntityType:=False)

        ''почтовое имя
        ''определим значение атрибута
        '_Value = Address.Name
        '_metadata = "4d014991-865e-11e4-90a2-8ecb00181219"
        '_addfn(_Value, _metadata, IsBooleanType:=False, IsStringType:=True, IsDecimalType:=False, IsTextType:=False, IsCustomEntityType:=False)

        ''почта улица
        ''определим значение атрибута
        '_Value = Address.Street
        '_metadata = "c44b2721-865d-11e4-90a2-8ecb001810f5"
        '_addfn(_Value, _metadata, IsBooleanType:=False, IsStringType:=True, IsDecimalType:=False, IsTextType:=False, IsCustomEntityType:=False)

        ''почта город
        ''определим значение атрибута
        '_Value = Address.City
        '_metadata = "c44b28db-865d-11e4-90a2-8ecb001810f6"
        '_addfn(_Value, _metadata, IsBooleanType:=False, IsStringType:=True, IsDecimalType:=False, IsTextType:=False, IsCustomEntityType:=False)

        ''волость
        ''определим значение атрибута
        '_Value = Address.State
        '_metadata = "c44b2a2b-865d-11e4-90a2-8ecb001810f7"
        '_addfn(_Value, _metadata, IsBooleanType:=False, IsStringType:=True, IsDecimalType:=False, IsTextType:=False, IsCustomEntityType:=False)

        ''почта страна
        ''определим значение атрибута
        '_Value = Address.Country
        '_metadata = "d2d87f24-966a-11e4-90a2-8ecb00867134"
        '_addfn(_Value, _metadata, IsBooleanType:=False, IsStringType:=True, IsDecimalType:=False, IsTextType:=False, IsCustomEntityType:=False)

        ''почта индекс
        ''определим значение атрибута
        '_Value = Address.PostIndex
        '_metadata = "c44b2b78-865d-11e4-90a2-8ecb001810f8"
        '_addfn(_Value, _metadata, IsBooleanType:=False, IsStringType:=True, IsDecimalType:=False, IsTextType:=False, IsCustomEntityType:=False)


        ''--------------
        ''подробные интересы клиента
        '_Value = ClientInterestDetails
        '_metadata = "607af338-a004-11e3-df68-002590a28eca"
        '_addfn(_Value, _metadata, IsBooleanType:=False, IsStringType:=False, IsDecimalType:=False, IsTextType:=True, IsCustomEntityType:=False)

        ''---------------------
        ''--------------
        ''Где узнали клиента справочник
        '_Value = ClientGetPlaceUUID
        '_metadata = "bfdcbde0-a004-11e3-205b-002590a28eca"
        'If Not CType(_Value, String) = "" Then
        '    _addfn(_Value, _metadata, IsBooleanType:=False, IsStringType:=False, IsDecimalType:=False, IsTextType:=False, IsCustomEntityType:=True)
        'End If

        ''интересы клиента справочник
        '_Value = ClientInterestUUID
        '_metadata = "607af140-a004-11e3-1a62-002590a28eca"
        'If Not CType(_Value, String) = "" Then
        '    _addfn(_Value, _metadata, IsBooleanType:=False, IsStringType:=False, IsDecimalType:=False, IsTextType:=False, IsCustomEntityType:=True)
        'End If

        ''страна справочник
        '_Value = ClientCountryUUID
        '_metadata = "0de9c0d7-b28d-11e3-cc1a-002590a28eca"
        'If Not CType(_Value, String) = "" Then
        '    _addfn(_Value, _metadata, IsBooleanType:=False, IsStringType:=False, IsDecimalType:=False, IsTextType:=False, IsCustomEntityType:=True)
        'End If
        '--------------------------

        _com.attribute = _attrList.ToArray

        'сохранить
        Dim _respond = ""
        Dim _message = ""
        Select Case oMoySkladManadger.AddAnyToServer(clsMoyScladManager.emMoySkladObjectTypes.Company, _com, _respond, _message)
            Case Net.HttpStatusCode.OK
                Return clsMSObjectReader(Of company).CreatInstance(_respond).GetClientInfo
            Case Else
                MsgBox("Не удалось сохранить атрибуты клиента. Серверное сообщение: " & _message)
                Return Nothing
        End Select

    End Function



    ''' <summary>
    ''' создать клиента
    ''' </summary>
    ''' <param name="FullName"></param>
    ''' <param name="CustomerCode"></param>
    ''' <param name="Email"></param>
    ''' <param name="Address"></param>
    ''' <param name="AddressString"></param>
    ''' <param name="ClientGetPlaceUUID"></param>
    ''' <param name="ClientInterestUUID"></param>
    ''' <param name="ClientInterestDetails"></param>
    ''' <param name="ClientMCTags"></param>
    ''' <param name="ClientCountryUUID"></param>
    ''' <param name="description"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CreateCustomer(FullName As String, CustomerCode As String, Email As String, Address As iMoySkladDataProvider.clsAddress, AddressString As String, ClientGetPlaceUUID As String, ClientInterestUUID As String, ClientInterestDetails As String, ClientMCTags() As String, ClientCountryUUID As String, description As String) As String Implements iMoySkladDataProvider.CreateCustomer
        'тестирована
        Dim _new As New company
        With _new
            .name = FullName
            .code = CustomerCode
            .contact = New contact With {.email = Email, .phones = Address.Phone}
            .requisite = New requisite With {.actualAddress = AddressString}
            'тип цен - розница
            .priceTypeUuid = "b14b6444-489b-11e3-36cc-7054d21a8d1e"
            'персональная скидка
            '.discount
            .description = description
            .tags = ClientMCTags
        End With
        'создать агента и получить его UUID
        Dim _respond As String = ""
        Dim _message As String = ""
        Select Case oMoySkladManadger.AddAnyToServer(clsMoyScladManager.emMoySkladObjectTypes.Company, _new, _respond, _message)
            Case Net.HttpStatusCode.OK
                _new = clsMSObjectReader(Of company).CreatInstance(_respond)
                'продолжим добавлять атрибуты
            Case Else
                MsgBox("Не удалось создать клиента. Серверное сообщение: " & _message)
                Return ""
        End Select

        '=========
        'атрибуты
        Dim _metadata = ""
        Dim _Value As Object
        Dim _attrList As New List(Of agentAttributeValue)
        If Not _new.attribute Is Nothing Then
            _attrList.AddRange(_new.attribute)
        Else
            _new.attribute = New agentAttributeValue() {}
        End If
        '---функции работы с атрибутами
        Dim _deletefn = Sub(metadataUUID As String)
                            'ищем флаг в атрибутах товара
                            Dim _resAttrValue1 As agentAttributeValue
                            _resAttrValue1 = (From c In _new.attribute Where c.metadataUuid = metadataUUID Select c).FirstOrDefault
                            If Not _resAttrValue1 Is Nothing Then
                                'да - удалим
                                _attrList.Remove(_resAttrValue1)
                            End If
                        End Sub


        Dim _addfn = Sub(attributeValue As Object, metadataUUID As String, IsBooleanType As Boolean, IsStringType As Boolean, IsDecimalType As Boolean, IsTextType As Boolean, IsCustomEntityType As Boolean)
                         'ищем флаг в атрибутах товара
                         Dim _resAttrValue As agentAttributeValue
                         _resAttrValue = (From c In _new.attribute Where c.metadataUuid = metadataUUID Select c).FirstOrDefault
                         If Not _resAttrValue Is Nothing Then
                             'удалить атрибут
                             _deletefn(metadataUUID)
                         End If
                         'нет - создаем обьект атрибута и добавляем его в коллекцию
                         _resAttrValue = agentAttributeValue.CreateInstance(_new.uuid, metadataUUID, attributeValue, IsBooleanType, IsStringType, IsDecimalType, IsTextType, IsCustomEntityType)
                         _attrList.Add(_resAttrValue)
                     End Sub
        '-=============
        ' ''предпочтительный емайл для отправки
        ' ''определим значение атрибута
        '_Value = ""
        '_metadata = "589dd945-4ac2-11e6-7a69-8f55001394f6"
        '_addfn(_Value, _metadata, IsBooleanType:=False, IsStringType:=True, IsDecimalType:=False, IsTextType:=False, IsCustomEntityType:=False)

        'почтовое имя
        'определим значение атрибута
        _Value = Address.Name
        _metadata = "4d014991-865e-11e4-90a2-8ecb00181219"
        _addfn(_Value, _metadata, IsBooleanType:=False, IsStringType:=True, IsDecimalType:=False, IsTextType:=False, IsCustomEntityType:=False)

        'почта улица
        'определим значение атрибута
        _Value = Address.Street
        _metadata = "c44b2721-865d-11e4-90a2-8ecb001810f5"
        _addfn(_Value, _metadata, IsBooleanType:=False, IsStringType:=True, IsDecimalType:=False, IsTextType:=False, IsCustomEntityType:=False)

        'почта город
        'определим значение атрибута
        _Value = Address.City
        _metadata = "c44b28db-865d-11e4-90a2-8ecb001810f6"
        _addfn(_Value, _metadata, IsBooleanType:=False, IsStringType:=True, IsDecimalType:=False, IsTextType:=False, IsCustomEntityType:=False)

        'волость
        'определим значение атрибута
        _Value = Address.State
        _metadata = "c44b2a2b-865d-11e4-90a2-8ecb001810f7"
        _addfn(_Value, _metadata, IsBooleanType:=False, IsStringType:=True, IsDecimalType:=False, IsTextType:=False, IsCustomEntityType:=False)

        'почта страна
        'определим значение атрибута
        _Value = Address.Country
        _metadata = "d2d87f24-966a-11e4-90a2-8ecb00867134"
        _addfn(_Value, _metadata, IsBooleanType:=False, IsStringType:=True, IsDecimalType:=False, IsTextType:=False, IsCustomEntityType:=False)

        'почта индекс
        'определим значение атрибута
        _Value = Address.PostIndex
        _metadata = "c44b2b78-865d-11e4-90a2-8ecb001810f8"
        _addfn(_Value, _metadata, IsBooleanType:=False, IsStringType:=True, IsDecimalType:=False, IsTextType:=False, IsCustomEntityType:=False)


        '--------------
        'подробные интересы клиента
        _Value = ClientInterestDetails
        _metadata = "607af338-a004-11e3-df68-002590a28eca"
        _addfn(_Value, _metadata, IsBooleanType:=False, IsStringType:=False, IsDecimalType:=False, IsTextType:=True, IsCustomEntityType:=False)

        '---------------------
        '--------------
        'Где узнали клиента справочник
        _Value = ClientGetPlaceUUID
        _metadata = "bfdcbde0-a004-11e3-205b-002590a28eca"
        If Not CType(_Value, String) = "" Then
            _addfn(_Value, _metadata, IsBooleanType:=False, IsStringType:=False, IsDecimalType:=False, IsTextType:=False, IsCustomEntityType:=True)
        End If

        'интересы клиента справочник
        _Value = ClientInterestUUID
        _metadata = "607af140-a004-11e3-1a62-002590a28eca"
        If Not CType(_Value, String) = "" Then
            _addfn(_Value, _metadata, IsBooleanType:=False, IsStringType:=False, IsDecimalType:=False, IsTextType:=False, IsCustomEntityType:=True)
        End If

        'страна справочник
        _Value = ClientCountryUUID
        _metadata = "0de9c0d7-b28d-11e3-cc1a-002590a28eca"
        If Not CType(_Value, String) = "" Then
            _addfn(_Value, _metadata, IsBooleanType:=False, IsStringType:=False, IsDecimalType:=False, IsTextType:=False, IsCustomEntityType:=True)
        End If
        '--------------------------

        _new.attribute = _attrList.ToArray

        'сохранить
        _respond = ""
        _message = ""
        Select Case oMoySkladManadger.AddAnyToServer(clsMoyScladManager.emMoySkladObjectTypes.Company, _new, _respond, _message)
            Case Net.HttpStatusCode.OK
                'перезагрузка списка клиентов
                Dim A = oMoySkladManadger.CustomerList(True)
                Return _new.uuid
            Case Else
                MsgBox("Не удалось сохранить атрибуты клиента. Серверное сообщение: " & _message)
                Return ""
        End Select

    End Function

    ''' <summary>
    ''' вернет 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetDemandInfo(DemandName As String, Optional DemandUUID As String = "") As List(Of iMoySkladDataProvider.clsOperationInfo) Implements iMoySkladDataProvider.GetDemandInfo
        Dim _out = New List(Of iMoySkladDataProvider.clsOperationInfo)

        If String.IsNullOrEmpty(DemandName) Then
            If String.IsNullOrEmpty(DemandUUID) Then
                Return _out
            End If
            Dim _res = oMoySkladManadger.RequestDemandByUUID(DemandUUID)
            If _res Is Nothing Then Return _out
            _out.Add(_res.GetDemandTrilbone(oMoySkladManadger))
        Else
            Dim _demand = oMoySkladManadger.RequestDemandByName(DemandName)
            If _demand Is Nothing OrElse _demand.Count = 0 Then Return _out

            _out = _demand.Select(Function(x) x.GetDemandTrilbone(oMoySkladManadger)).ToList
        End If

        Return _out
    End Function

    ''' <summary>
    ''' входящие платежи
    ''' </summary>
    ''' <param name="PaymentInName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetPaymentInInfo(PaymentInName As String, Optional PaymentInNameUUID As String = "") As List(Of iMoySkladDataProvider.clsPaymentInfo) Implements iMoySkladDataProvider.GetPaymentInInfo
        Dim _out = New List(Of iMoySkladDataProvider.clsPaymentInfo)
        If String.IsNullOrEmpty(PaymentInName) Then
            If String.IsNullOrEmpty(PaymentInNameUUID) Then
                Return _out
            End If
            Dim _res = oMoySkladManadger.RequestFinanceInByUUID(PaymentInNameUUID)
            If _res Is Nothing Then Return _out
            _out.Add(_res)
            Return _out
        Else
            Return oMoySkladManadger.RequestFinanceInByName(PaymentInName)
        End If
    End Function

    ''' <summary>
    ''' исходящие платежи
    ''' </summary>
    ''' <param name="PaymentOutName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetPaymentOutInfo(PaymentOutName As String, Optional PaymentOutNameUUID As String = "") As List(Of iMoySkladDataProvider.clsPaymentInfo) Implements iMoySkladDataProvider.GetPaymentOutInfo
        Dim _out = New List(Of iMoySkladDataProvider.clsPaymentInfo)
        If String.IsNullOrEmpty(PaymentOutName) Then
            If String.IsNullOrEmpty(PaymentOutNameUUID) Then
                Return _out
            End If
            Dim _res = oMoySkladManadger.RequestFinanceOutByUUID(PaymentOutNameUUID)
            If _res Is Nothing Then Return _out
            _out.Add(_res)
            Return _out
        Else
            Return oMoySkladManadger.RequestFinanceOutByName(PaymentOutName)
        End If

    End Function

    ''' <summary>
    ''' OrderName если пусто,  то ищем по OrderUUID
    ''' </summary>
    ''' <param name="OrderName"></param>
    ''' <param name="OrderUUID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetOrderInfo(OrderName As String, Optional OrderUUID As String = "") As List(Of iMoySkladDataProvider.clsOperationInfo) Implements iMoySkladDataProvider.GetOrderInfo
        Dim _out = New List(Of iMoySkladDataProvider.clsOperationInfo)

        If String.IsNullOrEmpty(OrderName) Then
            If String.IsNullOrEmpty(OrderUUID) Then
                Return _out
            End If
            Dim _res = oMoySkladManadger.RequestCustomerOrderByUUID(OrderUUID)
            If _res Is Nothing Then Return _out
            _out.Add(_res.GetOrderTrilbone(oMoySkladManadger))
        Else
            Dim _order = oMoySkladManadger.RequestCustomerOrderByName(OrderName)
            If _order Is Nothing OrElse _order.Count = 0 Then Return _out

            _out = _order.Select(Function(x) x.GetOrderTrilbone(oMoySkladManadger)).ToList
        End If

        Return _out
    End Function


    ''' <summary>
    ''' Создаст заказ для аукциона. Вернет UUID созданного обьекта
    ''' </summary>
    ''' <param name="GoodsUUIDs">Список UUID добавляемых товаров</param>
    ''' <param name="ShippingInAmount">сумма, полученная за шиппинг</param>
    ''' <param name="GoodsAmounts">Список сумм, полученных за товары (в той же последовательности, что и кода товаров)</param>
    ''' <param name="MyCompanyUUID">UUID организации МС, на которую оформляется документ</param>
    ''' <param name="ProjectUUID">UUID проекта (будет указан в заказе)</param>
    ''' <param name="CustomerUUID">UUID клиента МС</param>
    ''' <param name="CurrencyUUID">UUID валюты заказа</param>
    ''' <param name="WokerUUID">UUID сотрудника, оформляющего заказ (из справочника)</param>
    ''' <param name="HandlingTime">время, отведенное на упаковку заказа (не импользуется)</param>
    ''' <param name="Orderstate1UUID">UUID статуса заказа, который надо установить (в работе)</param>
    ''' <param name="Description">Комментарий</param>
    ''' <param name="OrderDate">Дата заказа - при Nothing текущая дата </param>
    Public Function CreateCustomerOrder(GoodsUUIDs() As String, GoodsQtys As Decimal(), GoodsAmounts() As Decimal, ShippingInAmount As Decimal, ShippingInQty As Decimal, ShippingInGoodUUID As String, MyCompanyUUID As String, ProjectUUID As String, CustomerUUID As String, CurrencyUUID As String, WokerUUID As String, HandlingTime As Integer, Orderstate1UUID As String, Description As String, Optional OrderDate? As Date = Nothing) As iMoySkladDataProvider.clsOperationInfo Implements iMoySkladDataProvider.CreateCustomerOrder
        'ТЕСТИРОВАНО - Дата планируемой отгрузки НЕ РАБОТАЕТ ДУМАТЬ
        Dim _order As New customerOrder
        With _order
            'могут быть проблемы с форматом. Нужный формат = "yyyy-MM-ddTHH:mm:ssZ"

            If OrderDate Is Nothing Then
                .deliveryPlannedMoment = clsApplicationTypes.GetCurrentTime.AddDays(HandlingTime + 14).ToString("yyyy-MM-ddTHH:mm:ssZ")
            Else
                .deliveryPlannedMoment = OrderDate.Value.AddDays(HandlingTime + 14).ToString("yyyy-MM-ddTHH:mm:ssZ")
                .created = OrderDate.Value.ToString("yyyy-MM-ddTHH:mm:ssZ")
                .moment = OrderDate.Value.ToString("yyyy-MM-ddTHH:mm:ssZ")
                .momentSpecified = True
                .createdSpecified = True
            End If

            .deliveryPlannedMomentSpecified = True

            .stateUuid = Orderstate1UUID
            .targetAgentUuid = MyCompanyUUID
            .sourceAgentUuid = CustomerUUID
            .applicable = True
            .projectUuid = ProjectUUID
            .currencyUuid = CurrencyUUID
            'сегодняшний курс ЦБ +3%
            .rate = clsApplicationTypes.GetRateByCurrencyCB103(oMoySkladManadger.GetCurrencyByUUID(CurrencyUUID).name)
            .description = Description
            .vatIncluded = True

            'сотрудник МС
            '.employeeUuid = "b14d201d-489b-11e3-321c-7054d21a8d1e"
        End With


        'создать и получить UUID

        Dim _message As String = ""
        Dim _respond As String = ""
        Select Case oMoySkladManadger.AddAnyToServer(clsMoyScladManager.emMoySkladObjectTypes.CustomerOrder, _order, _respond, _message)
            Case Net.HttpStatusCode.OK
                _order = clsMSObjectReader(Of customerOrder).CreatInstance(_respond)
                If _order Is Nothing Then
                    MsgBox("Не удалось создать заказ. Серверное сообщение: " & _message)
                    Return Nothing
                End If
                'продолжим добавлять атрибуты
            Case Else
                MsgBox("Не удалось создать заказ. Серверное сообщение: " & _message)
                Return Nothing
        End Select


        'атрибуты
        Dim _metadata = ""
        Dim _Value As Object
        Dim _attrList As New List(Of operationAttributeValue)
        If Not _order.attribute Is Nothing Then
            _attrList.AddRange(_order.attribute)
        Else
            _order.attribute = New operationAttributeValue() {}
        End If
        '---функции работы с атрибутами
        Dim _deletefn = Sub(metadataUUID As String)
                            'ищем флаг в атрибутах товара
                            Dim _resAttrValue1 As operationAttributeValue
                            _resAttrValue1 = (From c In _order.attribute Where c.metadataUuid = metadataUUID Select c).FirstOrDefault
                            If Not _resAttrValue1 Is Nothing Then
                                'да - удалим
                                _attrList.Remove(_resAttrValue1)
                            End If
                        End Sub


        Dim _addfn = Sub(attributeValue As Object, metadataUUID As String, IsBooleanType As Boolean, IsStringType As Boolean, IsDecimalType As Boolean, IsTextType As Boolean, IsCustomEntityType As Boolean)
                         'ищем флаг в атрибутах товара
                         Dim _resAttrValue As operationAttributeValue
                         _resAttrValue = (From c In _order.attribute Where c.metadataUuid = metadataUUID Select c).FirstOrDefault
                         If Not _resAttrValue Is Nothing Then
                             'удалить атрибут
                             _deletefn(metadataUUID)
                         End If
                         'нет - создаем обьект атрибута и добавляем его в коллекцию
                         _resAttrValue = operationAttributeValue.CreateInstance(_order.uuid, metadataUUID, attributeValue, IsBooleanType, IsStringType, IsDecimalType, IsTextType, IsCustomEntityType)
                         _attrList.Add(_resAttrValue)
                     End Sub
        '-=============
        'добавить атрибут Ведет сотрудник Trilbone справочник
        'определим значение атрибута
        _Value = WokerUUID
        _metadata = "0e742186-db63-11e3-7bb0-002590a28eca"
        _addfn(_Value, _metadata, IsBooleanType:=False, IsStringType:=False, IsDecimalType:=False, IsTextType:=False, IsCustomEntityType:=True)

        'добавить атрибуты
        _order.attribute = _attrList.ToArray

        '== товары ===============
        'добавим шиппинг
        If ShippingInAmount > 0 Then
            Dim _tmp = GoodsUUIDs.ToList
            _tmp.Add(ShippingInGoodUUID)
            GoodsUUIDs = _tmp.ToArray

            Dim _tmp1 = GoodsAmounts.ToList
            _tmp1.Add(ShippingInAmount)
            GoodsAmounts = _tmp1.ToArray

            _tmp1 = GoodsQtys.ToList
            _tmp1.Add(ShippingInQty)
            GoodsQtys = _tmp1.ToArray
        End If

        ' Dim _result As List(Of good) = Nothing
        'Select Case oMoySkladManadger.SearchGoods(GoodUUIDs(i), "", "", _result)
        '    Case Is < 0
        '        MsgBox("Ошибка в запросе товара, Заказ будет создан, но товар " & GoodUUIDs(i) & " в заказ не будет добавлен!", vbCritical)
        '    Case 0
        '        MsgBox("Товар не найден, Заказ будет создан, но товар " & GoodUUIDs(i) & " в заказ не будет добавлен!", vbCritical)
        '    Case 1
        '        'ok добавляем
        '        .goodUuid = _result(0).uuid
        '    Case Is > 1
        '        'товаров найдено более одного
        '        MsgBox("Товаров по коду найдено несколько, Заказ будет создан, но товар " & GoodUUIDs(i) & " в заказ не будет добавлен! Добавте вручную", vbCritical)
        'End Select


        Dim _position As customerOrderPosition
        Dim _list As New List(Of customerOrderPosition)
        For i = 0 To GoodsUUIDs.Length - 1
            _position = New customerOrderPosition
            With _position
                .discount = 0
                .quantity = GoodsQtys(i)
                .basePrice = New moneyAmount With {.sumInCurrency = GoodsAmounts(i) * 100, .sum = GoodsAmounts(i) * _order.rate * 100, .sumInCurrencySpecified = True, .sumSpecified = True}
                .price = New moneyAmount With {.sumInCurrency = GoodsAmounts(i) * 100, .sum = GoodsAmounts(i) * _order.rate * 100, .sumInCurrencySpecified = True, .sumSpecified = True}
                .reserve = GoodsQtys(i)
                'товар
                'все операции проверки наличия и поиска товара лежат на вызывающей стороне
                .goodUuid = GoodsUUIDs(i)
            End With


            _list.Add(_position)
        Next
        'запонмнить позиции
        _order.customerOrderPosition = _list.ToArray
        '==================

        'сохранить
        _respond = ""
        _message = ""
        Select Case oMoySkladManadger.AddAnyToServer(clsMoyScladManager.emMoySkladObjectTypes.CustomerOrder, _order, _respond, _message)
            Case Net.HttpStatusCode.OK
                _order = clsMSObjectReader(Of customerOrder).CreatInstance(_respond)
                If _order Is Nothing Then
                    MsgBox("Не удалось добавить атрибуты в заказ. Серверное сообщение: " & _message)
                    Return Nothing
                End If
            Case Else
                MsgBox("Не удалось добавить атрибуты в заказ. Серверное сообщение: " & _message)
                Return Nothing
        End Select

        Return _order.GetOrderTrilbone(oMoySkladManadger)

    End Function
    ''' <summary>
    ''' создает инвентаризацию
    ''' </summary>
    ''' <param name="MyCompany">компания</param>
    ''' <param name="WarehouseName">склад для инвентаризации</param>
    ''' <param name="GoodsUUIDs">список товаров</param>
    ''' <param name="Description">описание</param>
    ''' <param name="WareCellName">номер инвентаризуемой ячейки (если нужен)</param>
    ''' <param name="StateUUID">статус инвентаризации (по умолчанию НЕТ)</param>
    ''' <param name="Applicable">проведено</param>
    ''' <param name="GoodsQtys">Количества товара в наличии (если надо)</param>
    ''' <returns></returns>
    Public Function CreateInventory(MyCompany As String, WarehouseName As String, GoodsUUIDs() As String, Description As String, Optional WareCellName As String = "", Optional StateUUID As String = "2fb659a6-d883-11e4-90a2-8ecb001c0a01", Optional Applicable As Boolean = True, Optional GoodsQtys As Decimal() = Nothing) As iMoySkladDataProvider.clsOperationInfo Implements iMoySkladDataProvider.CreateInventory
        Dim _out As New iMoySkladDataProvider.clsOperationInfo

        Dim _company = oMoySkladManadger.GetCompanyByName(MyCompany)
        If _company Is Nothing Then
            _out.HasError = True
            _out.ErrorMessage = String.Format("Юр лица с именем {0} нет в справочнике", MyCompany)
            Return _out
        End If

        Dim _ware = oMoySkladManadger.GetWarehousUUIDbyName(WarehouseName)
        If String.IsNullOrEmpty(WarehouseName) Then
            _out.HasError = True
            _out.ErrorMessage = String.Format("Склада с именем {0} нет в справочнике", WarehouseName)
        End If


        Return oMoySkladManadger.CreateInventory(_company.UUID, _ware, GoodsUUIDs, Description, WareCellName, StateUUID, Applicable, GoodsQtys)

    End Function


    ''' <summary>
    ''' Создаст отгрузку. Вернет UUID созданного обьекта. надо убедится, что отгружаемые позиции есть на складе!!! Иначе отгрузку нельзя будет модифицировать.
    ''' </summary>
    ''' <param name="MyCompanyUUID">UUID организации МС, на которую оформляется документ</param>
    ''' <param name="CustomerUUID">UUID клиента МС</param>
    ''' <param name="ProjectUUID">UUID проекта (будет указан в платеже)</param>
    ''' <param name="InvocePaymentTypeUUID">UUID типа оплаты инвойса (из справочника)</param>
    ''' <param name="CurrencyUUID">валюта отгрузки</param>
    ''' <param name="GoodsUUIDs">Список добавляемых товаров</param>
    ''' <param name="GoodsAmounts">Список сумм, полученных за товары (в той же последовательности, что и кода товаров)</param>
    ''' <param name="StateUUID">статус отгрузки =на отправку</param>
    ''' <param name="Description">Комментарий</param>
    Public Function CreateDemand(MyCompanyUUID As String, CustomerUUID As String, ProjectUUID As String, StateUUID As String, WarehouseUUID As String, InvocePaymentTypeUUID As String, CurrencyUUID As String, GoodsUUIDs() As String, GoodsAmounts() As Decimal, GoodsQtys As Decimal(), Description As String, Applicable As Boolean, Optional DemandDate? As Date = Nothing) As iMoySkladDataProvider.clsOperationInfo Implements iMoySkladDataProvider.CreateDemand
        'надо убедится, что отгружаемые позиции есть на складе!!!
        'ТЕСТИРОВАНО
        Dim _demand As New demand
        With _demand

            If DemandDate Is Nothing Then
                ' .deliveryPlannedMoment = clsApplicationTypes.GetCurrentTime.AddDays(HandlingTime + 14).ToString("yyyy-MM-ddTHH:mm:ssZ")
                'дата будет установлена текущая
            Else
                '    .deliveryPlannedMoment = OrderDate.Value.AddDays(HandlingTime + 14).ToString("yyyy-MM-ddTHH:mm:ssZ")
                .created = DemandDate.Value.ToString("yyyy-MM-ddTHH:mm:ssZ")
                .createdSpecified = True
                .moment = DemandDate.Value.ToString("yyyy-MM-ddTHH:mm:ssZ")
                .momentSpecified = True
            End If

            'статус Отгрузки 
            .stateUuid = StateUUID
            .targetAgentUuid = CustomerUUID
            .sourceAgentUuid = MyCompanyUUID
            'проведено
            .applicable = Applicable
            .projectUuid = ProjectUUID
            .payerVat = False
            .currencyUuid = CurrencyUUID
            'сегодняшний курс ЦБ +3%
            .rate = clsApplicationTypes.GetRateByCurrencyCB103(oMoySkladManadger.GetCurrencyByUUID(CurrencyUUID).name)
            .vatIncluded = True
            .description = Description

            'склад отгрузки
            .sourceStoreUuid = WarehouseUUID

        End With

        'создать и получить UUID
        Dim _message As String = ""
        Dim _respond As String = ""
        Select Case oMoySkladManadger.AddAnyToServer(clsMoyScladManager.emMoySkladObjectTypes.Demand, _demand, _respond, _message)
            Case Net.HttpStatusCode.OK
                _demand = clsMSObjectReader(Of demand).CreatInstance(_respond)
                If _demand Is Nothing Then
                    MsgBox("Не удалось создать отгрузку. Серверное сообщение: " & _message)
                    Return Nothing
                End If
                'продолжим добавлять атрибуты
            Case Else
                MsgBox("Не удалось создать отгрузку. Серверное сообщение: " & _message)
                Return Nothing
        End Select

        'атрибуты
        Dim _metadata = ""
        Dim _Value As Object
        Dim _attrList As New List(Of operationAttributeValue)
        If Not _demand.attribute Is Nothing Then
            _attrList.AddRange(_demand.attribute)
        Else
            _demand.attribute = New operationAttributeValue() {}
        End If
        '---функции работы с атрибутами
        Dim _deletefn = Sub(metadataUUID As String)
                            'ищем флаг в атрибутах товара
                            Dim _resAttrValue1 As operationAttributeValue
                            _resAttrValue1 = (From c In _demand.attribute Where c.metadataUuid = metadataUUID Select c).FirstOrDefault
                            If Not _resAttrValue1 Is Nothing Then
                                'да - удалим
                                _attrList.Remove(_resAttrValue1)
                            End If
                        End Sub


        Dim _addfn = Sub(attributeValue As Object, metadataUUID As String, IsBooleanType As Boolean, IsStringType As Boolean, IsDecimalType As Boolean, IsTextType As Boolean, IsCustomEntityType As Boolean)
                         'ищем флаг в атрибутах товара
                         Dim _resAttrValue As operationAttributeValue
                         _resAttrValue = (From c In _demand.attribute Where c.metadataUuid = metadataUUID Select c).FirstOrDefault
                         If Not _resAttrValue Is Nothing Then
                             'удалить атрибут
                             _deletefn(metadataUUID)
                         End If
                         'нет - создаем обьект атрибута и добавляем его в коллекцию
                         _resAttrValue = operationAttributeValue.CreateInstance(_demand.uuid, metadataUUID, attributeValue, IsBooleanType, IsStringType, IsDecimalType, IsTextType, IsCustomEntityType)
                         _attrList.Add(_resAttrValue)
                     End Sub
        '-=============
        'добавить атрибут Тип оплаты инвойса справочник
        'определим значение атрибута
        _Value = InvocePaymentTypeUUID
        _metadata = "942dcd23-8ebe-11e4-90a2-8ecb002d428a"
        _addfn(_Value, _metadata, IsBooleanType:=False, IsStringType:=False, IsDecimalType:=False, IsTextType:=False, IsCustomEntityType:=True)

        'На кого Инвойс = на контрагента (внутренний справочник Company) тип атрибута другой, с полем agentValueUuid
        _Value = _demand.targetAgentUuid
        _metadata = "8b8cc38e-7cf0-11e4-90a2-8ecb00003a8d"
        Dim _attr = operationAttributeValue.CreateInstance(_demand.uuid, _metadata, _Value, False, False, False, False, True)
        _attr.agentValueUuid = _Value
        _attrList.Add(_attr)

        _demand.attribute = _attrList.ToArray

        _respond = ""
        _message = ""
        Select Case oMoySkladManadger.AddAnyToServer(clsMoyScladManager.emMoySkladObjectTypes.Demand, _demand, _respond, _message)
            Case Net.HttpStatusCode.OK
                _demand = clsMSObjectReader(Of demand).CreatInstance(_respond)
                If _demand Is Nothing Then
                    MsgBox("Не удалось добавить атрибуты в отгрузку. Серверное сообщение: " & _message)
                    Return Nothing
                End If
            Case Else
                MsgBox("Не удалось добавить атрибуты в отгрузку. Серверное сообщение: " & _message)
                Return Nothing
        End Select

        ''-------------------------

        Dim _shipmentOut As shipmentOut
        Dim _list As New List(Of shipmentOut)
        For i = 0 To GoodsUUIDs.Length - 1
            _shipmentOut = New shipmentOut
            With _shipmentOut
                .discount = 0
                .quantity = GoodsQtys(i)
                .basePrice = New moneyAmount With {.sumInCurrency = GoodsAmounts(i) * 100, .sum = GoodsAmounts(i) * _demand.rate * 100, .sumInCurrencySpecified = True, .sumSpecified = True}
                .price = New moneyAmount With {.sumInCurrency = GoodsAmounts(i) * 100, .sum = GoodsAmounts(i) * _demand.rate * 100, .sumInCurrencySpecified = True, .sumSpecified = True}
                .vat = 0
                'товар
                'все операции проверки наличия и поиска товара лежат на вызывающей стороне
                .goodUuid = GoodsUUIDs(i)
            End With

            _list.Add(_shipmentOut)
        Next

        'запонмнить позиции
        _demand.shipmentOut = _list.ToArray
        '==================
        _respond = ""
        _message = ""
        Select Case oMoySkladManadger.AddAnyToServer(clsMoyScladManager.emMoySkladObjectTypes.Demand, _demand, _respond, _message)
            Case Net.HttpStatusCode.OK
                _demand = clsMSObjectReader(Of demand).CreatInstance(_respond)
                If _demand Is Nothing Then
                    MsgBox("Не удалось добавить позиции в отгрузку. Серверное сообщение: " & _message)
                    Return Nothing
                End If
            Case Else
                MsgBox("Не удалось добавить позиции в отгрузку. Серверное сообщение: " & _message)
                Return Nothing
        End Select

        Return _demand.GetDemandTrilbone(oMoySkladManadger)

    End Function
    ''' <summary>
    ''' создаст перемещение. Ячейка назначения указывается для каждого товара в поле NewSlotName. В передаваемой структуре товара может быть заполнено поле SlotUUID или SlotName (исходная ячейка), иначе будет перемещение со склада (т.е. не из ячейки!) 
    ''' </summary>
    ''' <param name="sourceStoreName"></param>
    ''' <param name="targetStoreName"></param>
    ''' <param name="goodList"></param>
    ''' <param name="MoveState"></param>
    ''' <returns></returns>
    Public Function CreateMove(sourceStoreName As String, targetStoreName As String, goodList As iMoySkladDataProvider.strGoodMapQty(), Optional MoveState As iMoySkladDataProvider.emMoveState = iMoySkladDataProvider.emMoveState.empty) As iMoySkladDataProvider.clsOperationInfo Implements iMoySkladDataProvider.CreateMove
        'проверки
        Dim _ssUUID = oMoySkladManadger.GetWarehousUUIDbyName(sourceStoreName)
        Dim _tsUUID = oMoySkladManadger.GetWarehousUUIDbyName(targetStoreName)

        Dim _out = New iMoySkladDataProvider.clsOperationInfo With {.HasError = True}

        If String.IsNullOrEmpty(_ssUUID) Or String.IsNullOrEmpty(_ssUUID) Then
            Debug.Fail("UUID склада не найден")
            Return _out
        End If



        Dim _res = oMoySkladManadger.CreateMove(_ssUUID, _tsUUID, goodList, MoveState)

        Return _res
    End Function


    Public Function CreateOutgoingPayment() As iMoySkladDataProvider.clsPaymentInfo
        'исходящий платеж
        Throw New NotImplementedException
    End Function


    ''' <summary>
    ''' Создаст входящий платеж. Вернет UUID созданного обьекта
    ''' </summary>
    ''' <param name="ProjectUUID">UUID проекта (будет указан в платеже)</param>
    ''' <param name="AccepterUUID">UUID сотрудника, получившего бабосы (из справочника)</param>
    ''' <param name="AccountUUID">UUID счета из справочника Счетов</param>
    ''' <param name="CustomerUUID">UUID клиента МС</param>
    ''' <param name="Amount">размер полученной суммы</param>
    ''' <param name="CurrencyUUID">UUID валюты заказа</param>
    ''' <param name="MyCompanyUUID">UUID организации МС, на которую оформляется документ</param>
    ''' <param name="NoFeeIncluded">Платеж грязный, без учета fee</param>
    ''' <param name="Description">Комментарий</param>
    ''' <param name="paymentPurpose">Назначение платежа</param>
    Public Function CreateIncomingPayment(ProjectUUID As String, AccepterUUID As String, AccountUUID As String, CustomerUUID As String, Amount As String, CurrencyUUID As String, MyCompanyUUID As String, NoFeeIncluded As Boolean, paymentPurpose As String, Description As String, Optional PaymentDate? As Date = Nothing) As iMoySkladDataProvider.clsPaymentInfo Implements iMoySkladDataProvider.CreateIncomingPayment
        'тестировано
        Dim _paymentIn As New paymentIn
        With _paymentIn

            If PaymentDate Is Nothing Then
                'платеж будет создан текущей датой
            Else
                .created = PaymentDate.Value.ToString("yyyy-MM-ddTHH:mm:ssZ")
                .createdSpecified = True
                .moment = PaymentDate.Value.ToString("yyyy-MM-ddTHH:mm:ssZ")
                .momentSpecified = True
            End If

            'привязанный заказ
            ' .customerOrderUuid = ""
            'Назначение платежа
            .paymentPurpose = paymentPurpose
            'Моя компания
            .targetAgentUuid = MyCompanyUUID
            'плательщик
            .sourceAgentUuid = CustomerUUID
            'проект
            .projectUuid = ProjectUUID
            'валюта документа
            .currencyUuid = CurrencyUUID
            'сегодняшний курс ЦБ +3%
            .rate = clsApplicationTypes.GetRateByCurrencyCB103(oMoySkladManadger.GetCurrencyByUUID(CurrencyUUID).name)
            .description = Description
            Dim _amount As New moneyAmount
            _amount.sum = Math.Round(Amount * 100 * .rate, 2)
            _amount.sumInCurrency = Amount * 100
            _amount.sumInCurrencySpecified = True
            _amount.sumSpecified = True
            .sum = _amount

            'проведен
            .applicable = True
        End With

        'создать и получить UUID
        Dim _respond As String = ""
        Dim _message As String = ""
        Select Case oMoySkladManadger.AddAnyToServer(clsMoyScladManager.emMoySkladObjectTypes.PaymentIn, _paymentIn, _respond, _message)
            Case Net.HttpStatusCode.OK
                _paymentIn = clsMSObjectReader(Of paymentIn).CreatInstance(_respond)
                If _paymentIn Is Nothing Then
                    MsgBox("Не удалось создать входящий платеж. Серверное сообщение: " & _message)
                    Return Nothing
                End If
                'продолжим добавлять атрибуты
            Case Else
                MsgBox("Не удалось создать входящий платеж. Серверное сообщение: " & _message)
                Return Nothing
        End Select

        '=========
        'атрибуты
        Dim _metadata = ""
        Dim _Value As Object
        Dim _attrList As New List(Of operationAttributeValue)
        If Not _paymentIn.attribute Is Nothing Then
            _attrList.AddRange(_paymentIn.attribute)
        Else
            _paymentIn.attribute = New operationAttributeValue() {}
        End If
        '---функции работы с атрибутами
        Dim _deletefn = Sub(metadataUUID As String)
                            'ищем флаг в атрибутах товара
                            Dim _resAttrValue1 As operationAttributeValue
                            _resAttrValue1 = (From c In _paymentIn.attribute Where c.metadataUuid = metadataUUID Select c).FirstOrDefault
                            If Not _resAttrValue1 Is Nothing Then
                                'да - удалим
                                _attrList.Remove(_resAttrValue1)
                            End If
                        End Sub


        Dim _addfn = Sub(attributeValue As Object, metadataUUID As String, IsBooleanType As Boolean, IsStringType As Boolean, IsDecimalType As Boolean, IsTextType As Boolean, IsCustomEntityType As Boolean)
                         'ищем флаг в атрибутах товара
                         Dim _resAttrValue As operationAttributeValue
                         _resAttrValue = (From c In _paymentIn.attribute Where c.metadataUuid = metadataUUID Select c).FirstOrDefault
                         If Not _resAttrValue Is Nothing Then
                             'удалить атрибут
                             _deletefn(metadataUUID)
                         End If
                         'нет - создаем обьект атрибута и добавляем его в коллекцию
                         _resAttrValue = operationAttributeValue.CreateInstance(_paymentIn.uuid, metadataUUID, attributeValue, IsBooleanType, IsStringType, IsDecimalType, IsTextType, IsCustomEntityType)
                         _attrList.Add(_resAttrValue)
                     End Sub
        '-=============
        '"Грязный платеж" (без учета fee)
        'определим значение атрибута
        _Value = NoFeeIncluded
        _metadata = "78908034-2807-11e4-18ea-002590a28eca"
        _addfn(_Value, _metadata, IsBooleanType:=True, IsStringType:=False, IsDecimalType:=False, IsTextType:=False, IsCustomEntityType:=False)

        'Кто получил бабос
        'определим значение атрибута
        _Value = AccepterUUID
        _metadata = "f7183229-e428-11e3-9562-002590a28eca"
        _addfn(_Value, _metadata, IsBooleanType:=False, IsStringType:=False, IsDecimalType:=False, IsTextType:=False, IsCustomEntityType:=True)

        'Куда поступил платеж
        'определим значение атрибута
        _Value = AccountUUID
        _metadata = "f7183508-e428-11e3-be57-002590a28eca"
        _addfn(_Value, _metadata, IsBooleanType:=False, IsStringType:=False, IsDecimalType:=False, IsTextType:=False, IsCustomEntityType:=True)

        ''Валюта получения - не задаем, по умолчанию такая же как в документе
        ''определим значение атрибута
        '_Value = Nothing
        '_metadata = "f7183423-e428-11e3-edb8-002590a28eca"
        '_addfn(_Value, _metadata, IsBooleanType:=False, IsStringType:=False, IsDecimalType:=False, IsTextType:=False, IsCustomEntityType:=True)
        '==============

        _paymentIn.attribute = _attrList.ToArray

        'сохранить
        _respond = ""
        _message = ""
        Select Case oMoySkladManadger.AddAnyToServer(clsMoyScladManager.emMoySkladObjectTypes.PaymentIn, _paymentIn, _respond, _message)
            Case Net.HttpStatusCode.OK
                If _paymentIn Is Nothing Then
                    MsgBox("Не удалось сохранить атрибуты входящего платежа. Серверное сообщение: " & _message)
                    Return Nothing
                End If
                Return _paymentIn.GetpaymentInTrilbone(oMoySkladManadger)
            Case Else
                MsgBox("Не удалось сохранить атрибуты входящего платежа. Серверное сообщение: " & _message)
                Return Nothing
        End Select

    End Function
    ''' <summary>
    ''' Снимет образец с аукциона. Вернет UUID снятого товара.
    ''' </summary>
    ''' <param name="GoodCode">Номер товара (код)</param>
    ''' <param name="ReservCustomerOrderUUID">Заказ, используемый для резервации образца</param>
    Public Function EndSampleOnAuction(GoodCode As String, ReservCustomerOrderUUID As String) As String Implements iMoySkladDataProvider.EndSampleOnAuction
        'тестировано
        Dim _order = oMoySkladManadger.RequestCustomerOrderByUUID(ReservCustomerOrderUUID)
        If _order Is Nothing Then Return ""

        Dim _goods As List(Of good) = Nothing
        Select Case oMoySkladManadger.FindGoods(GoodCode, "", "", _goods)
            Case Is < 0
                'ошибка
                MsgBox(String.Format("Ошибка сервера. По коду {0} .", GoodCode), vbCritical)
                Return ""
            Case 0
                'не найден
                MsgBox(String.Format("Ошибка остановки образца. По коду {0} не найдено товаров.", GoodCode), vbCritical)
                Return ""
            Case 1
                'ok
                If _order.customerOrderPosition Is Nothing Then _order.customerOrderPosition = New customerOrderPosition() {}
                Dim _result = From c In _order.customerOrderPosition Where c.goodUuid.Equals(_goods(0).uuid) Select c

                If _result.Count = 0 Then
                    'образец не найден в заказе
                    'MsgBox(String.Format("Ошибка остановки образца. Образец с номером {0} отсутствует в Заказе {1}", GoodCode, _order.name), vbCritical)
                    Return ""
                End If
                'ok
                Dim _new As New List(Of customerOrderPosition)
                For Each t In _order.customerOrderPosition
                    If Not t.goodUuid.Equals(_goods(0).uuid) Then
                        _new.Add(t)
                    End If
                Next

                _order.customerOrderPosition = _new.ToArray

                'сохранить
                Dim _message As String = ""
                Dim _respond As String = ""
                Select Case oMoySkladManadger.AddAnyToServer(clsMoyScladManager.emMoySkladObjectTypes.CustomerOrder, _order, _respond, _message)
                    Case Net.HttpStatusCode.OK
                        _order = clsMSObjectReader(Of customerOrder).CreatInstance(_respond)
                        If _order Is Nothing Then
                            MsgBox("Не удалось обновить заказ. Серверное сообщение: " & _message)
                            Return ""
                        End If
                        'продолжим добавлять атрибуты
                    Case Else
                        MsgBox("Не удалось обновить заказ. Серверное сообщение: " & _message)
                        Return ""
                End Select

                Return _goods(0).uuid
            Case Is > 1
                'найдено несколько
                MsgBox(String.Format("Ошибка остановки образца. По коду {0} найдено {1} товаров. Удалите дубликаты в Моем Складе.", GoodCode, _goods.Count), vbCritical)
                Return ""
        End Select

        Return ""


    End Function
    ''' <summary>
    ''' список складов с учетом ACL
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetWarehouseList() As List(Of iMoySkladDataProvider.clsEntity) Implements iMoySkladDataProvider.GetWarehouseList
        Return oMoySkladManadger.WarehouseList.Select(Function(x) x.GetTrilboneItem).ToList
    End Function

    Public Function GetSlotList(WarehouseUUID As String) As List(Of iMoySkladDataProvider.clsEntity) Implements iMoySkladDataProvider.GetSlotList
        Return oMoySkladManadger.SlotList(WarehouseUUID).Select(Function(x) x.GetTrilboneItem).ToList
    End Function


    ''' <summary>
    ''' список групп МС
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetGroupList() As List(Of Service.iMoySkladDataProvider.clsEntity) Implements iMoySkladDataProvider.GetGroupList
        Dim _out = oMoySkladManadger.GroupList.Select(Function(x) x.GetTrilboneItem).ToList
        _out.Sort()
        Return _out
    End Function
    ''' <summary>
    ''' список складов, где есть товар
    ''' </summary>
    ''' <param name="GoodUUID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetWarehouse(GoodUUID As String) As iMoySkladDataProvider.clsEntity Implements iMoySkladDataProvider.GetWarehouse
        Dim _result = oMoySkladManadger.FindLocationOfGood(New good With {.uuid = GoodUUID}, True)
        Dim _out = New iMoySkladDataProvider.clsEntity
        If _result.Count = 0 Then Return _out
        _out.Value = _result(0).WarehouseName
        _out.UUID = _result(0).WarehouseUUID
        Return _out
    End Function

    ''' <summary>
    ''' вернет список значений пользовательского справочника
    ''' </summary>
    ''' <param name="name"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetUserEntityListByName(name As String) As List(Of iMoySkladDataProvider.clsEntity) Implements iMoySkladDataProvider.GetUserEntityListByName
        'тестировано
        Return oMoySkladManadger.GetEntityOfUserListByNameAsTrilbone(name)
    End Function

    ''' <summary>
    ''' вернет список компаний
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetCompanyList() As List(Of iMoySkladDataProvider.clsEntity) Implements iMoySkladDataProvider.GetCompanyList
        Dim _res = From c As myCompany In oMoySkladManadger.CompanyList(False) Select New iMoySkladDataProvider.clsEntity With {.GetCustomValueDelegate = AddressOf oMoySkladManadger.GetCompanyByName, .Value = c.name, .UUID = c.uuid}
        Return _res.ToList
    End Function


    ''' <summary>
    ''' вернет список значений пользовательского справочника
    ''' </summary>
    ''' <param name="uuid"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetUserEntityListByMetadataUUID(uuid As String) As List(Of iMoySkladDataProvider.clsEntity)
        'тестировано
        Return oMoySkladManadger.GetEntityOfUserListByMetadataUUIDAsTrilbone(uuid)
    End Function

    ''' <summary>
    ''' Вернет сущность по пользовательского справочника по MetadataUUID и EntityUUID или пустую сущность
    ''' </summary>
    ''' <param name="MetadataUUID"></param>
    ''' <param name="EntityUUID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetUserEntityByUUID(MetadataUUID As String, EntityUUID As String) As iMoySkladDataProvider.clsEntity
        'тестировано
        Dim _list = oMoySkladManadger.GetEntityOfUserListByMetadataUUIDAsTrilbone(MetadataUUID)
        If _list.Count = 0 Then Return New iMoySkladDataProvider.clsEntity With {.MetaDataValue = "неопределено"}

        Dim _result = _list.Where(Function(x) x.UUID.Equals(EntityUUID)).FirstOrDefault

        If _result Is Nothing Then Return New iMoySkladDataProvider.clsEntity With {.Value = "неопределено", .MetaDataValue = _list(1).Value, .MetaDataUUID = _list(1).MetaDataUUID}

        Return _result
    End Function


    ''' <summary>
    ''' Вернет сущность по имени пользовательского справочника и имени значения или пустую сущность
    ''' </summary>
    ''' <param name="ListName"></param>
    ''' <param name="EntityName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetUserEntity(ListName As String, EntityName As String) As iMoySkladDataProvider.clsEntity
        'тестировано

        Return oMoySkladManadger.GetUserEntity(ListName, EntityName)

    End Function



    Public Function GetExpeditionList() As List(Of String) Implements iMoySkladDataProvider.GetExpeditionList
        Return oMoySkladManadger.ExpeditionsList.Select(Function(x) x.name).ToList
    End Function

    ''' <summary>
    ''' куда поступил платеж (справочник Счета)
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetPaymentDestinations() As List(Of iMoySkladDataProvider.clsEntity) Implements iMoySkladDataProvider.GetPaymentDestinations
        Return oMoySkladManadger.GetEntityOfUserListByNameAsTrilbone("Счета")
    End Function

    ''' <summary>
    ''' вернет список клиентов
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetClients(Optional reload As Boolean = False) As iMoySkladDataProvider.clsClientInfo() Implements iMoySkladDataProvider.GetClients
        'тестировано
        Dim _out As New List(Of iMoySkladDataProvider.clsClientInfo)
        Dim _result = oMoySkladManadger.CustomerList(reload)
        For Each t As company In _result
            If (Not t.contact Is Nothing) Then
                _out.Add(t.GetClientInfo)
            End If
        Next
        _out.Sort()
        Return _out.ToArray
    End Function

    ''' <summary>
    ''' вернет все проекты
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetProject() As List(Of iMoySkladDataProvider.clsEntity) Implements iMoySkladDataProvider.GetProject
        Dim _out As New List(Of iMoySkladDataProvider.clsEntity)
        _out.Add(iMoySkladDataProvider.clsEntity.Empty)
        _out.AddRange(From c In oMoySkladManadger.ProjectList(True) Select Function(x) New iMoySkladDataProvider.clsEntity With {.Value = c.name, .UUID = c.uuid})
        Return _out
    End Function

    ''' <summary>
    ''' группы клиентов
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetClientsTags() As String() Implements iMoySkladDataProvider.GetClientsTags
        'тестировано
        Dim _result = oMoySkladManadger.CustomerList(False)
        Dim _tags As New List(Of String)

        For Each _cl In _result
            If Not _cl.tags Is Nothing Then
                _tags.AddRange(_cl.tags)
            End If
        Next
        Return _tags.Distinct.ToArray
    End Function

    Public Sub ReloadEntities() Implements iMoySkladDataProvider.ReloadEntities
        oMoySkladManadger.LoadEntities()
    End Sub

    Public Function GetClientsInterest() As Dictionary(Of String, String) Implements iMoySkladDataProvider.GetClientsInterest
        'тестировано
        Dim _out As New Dictionary(Of String, String)
        For Each c In oMoySkladManadger.GetEntityOfUserListByNameAsTrilbone("Интересы клиентов")
            _out.Add(c.UUID, c.Value)
        Next
        Return _out
    End Function

    ''' <summary>
    ''' Получить данные по посылкам для отправке просматривая отгрузки со статусом НА ОТПРАВКУ Работает Только при существующем привязанном ЗАКАЗЕ!!!!
    ''' </summary>
    ''' <param name="WokerUUID">для сотрудника (может быть пусто)</param>
    Public Function GetParcelsInfoForShip(StateUUID As String, Optional ExcludeGoodsUUID As String() = Nothing, Optional WokerUUID As String = Nothing) As iMoySkladDataProvider.clsParcelInfo() Implements iMoySkladDataProvider.GetParcelsInfoForShip
        'Тестировано

        Dim _data As IEnumerable(Of Object) = Nothing
        Dim _message As String = ""
        Dim _fromdate = Date.Parse("01.01.2015")
        Dim _result = oMoySkladManadger.RequestAnyCollection(clsMoyScladManager.emMoySkladObjectTypes.Demand, _data, _fromdate.ToString, clsMoyScladManager.emMoySkladFilterTypes.createdLate, _message)
        Select Case _result
            Case Net.HttpStatusCode.OK
                'игнорить удаленные
                _data = From c As demand In _data Where c.stateUuid = StateUUID And c.deletedSpecified = False Select c
            Case Else
                MsgBox("Ошибка запроса Отгрузок. Сообщение сервера: " & _message, vbCritical)
                Return New iMoySkladDataProvider.clsParcelInfo() {}
        End Select


        If Not (WokerUUID Is Nothing OrElse WokerUUID = "") Then
            'фильтр по сотрудникам
            _data = From c As demand In _data Where c.GetAttributeValue("f3b6423f-db60-11e3-d44a-002590a28eca", False, False, False, False, True) = WokerUUID Select c
        End If

        Select Case _result
            Case Net.HttpStatusCode.OK
                Dim _out As New List(Of iMoySkladDataProvider.clsParcelInfo)
                Dim _parcelInfo As iMoySkladDataProvider.clsParcelInfo
                For Each t As demand In _data
                    Dim _customer = oMoySkladManadger.GetCustomerByUUID(t.targetAgentUuid)
                    _parcelInfo = New iMoySkladDataProvider.clsParcelInfo
                    With _parcelInfo
                        .ClientAddress = _customer.GetAddress
                        .DemandUUID = t.uuid
                        If (Not t.customerOrderUuid Is Nothing) OrElse (Not t.customerOrderUuid = "") Then
                            Dim _order = oMoySkladManadger.RequestCustomerOrderByUUID(t.customerOrderUuid)
                            .MaximumDateToSend = _order.deliveryPlannedMoment
                            'запрашиваем позиции из заказа
                            Dim _goodCodes As New List(Of String)
                            Dim _goodLocationCollection As New List(Of String)
                            Dim _good As good
                            For Each _sh In _order.customerOrderPosition
                                If (From c In ExcludeGoodsUUID Where c.Equals(_sh.goodUuid) Select c).Count < 1 Then
                                    'исключить товары указанные в  ExcludeGoodsUUID
                                    _good = oMoySkladManadger.RequestGoodByUUID(_sh.goodUuid)

                                    Dim _location As String = ""
                                    Dim _loc = oMoySkladManadger.FindLocationOfGood(_good, True)

                                    'добавить, только если есть местоположение товара
                                    If _loc.Count > 0 Then
                                        'добавить только товары с кодом, исключить артикульные
                                        If Not _good.code = "" Then
                                            _goodCodes.Add(_good.code)
                                            ' _goodCodes.Add(IIf(_good.code = "", _good.productCode, _good.code))
                                            For Each l In _loc
                                                _location += l.ToString & ChrW(13)
                                            Next
                                            _goodLocationCollection.Add(_location)
                                        End If

                                    End If
                                End If
                            Next

                            If _goodCodes.Count > 0 Then
                                .GoodCodesList = _goodCodes.ToArray
                                .GoodPlacesList = _goodLocationCollection.ToArray

                                'TODO сформировать обьект Декларация
                                '.Declaration = t.GetAttributeValue("2068064f-8cf8-11e4-90a2-8ecb000c9447", False, True, False, False, False)
                                'If .DeclarationText = "" Or .DeclarationText = "нет" Then
                                '    .MustDeclared = False
                                'Else
                                '    .MustDeclared = True
                                'End If

                                _out.Add(_parcelInfo)
                            End If
                        End If
                    End With

                Next
                Return _out.ToArray
            Case Else
                MsgBox("Запрос отправок вернул ошибку: " & _message, vbCritical)
                Return New iMoySkladDataProvider.clsParcelInfo() {}
        End Select
    End Function
    ''' <summary>
    ''' добавить товар в МС. Вернет clsPosition или nothing
    ''' </summary>
    ''' <param name="code"></param>
    ''' <param name="name"></param>
    ''' <param name="price"></param>
    ''' <param name="currency"></param>
    ''' <param name="IsArticul"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function AddGood(code As String, name As String, price As Decimal, currency As String, Optional IsArticul As Boolean = False) As iMoySkladDataProvider.clsPosition Implements iMoySkladDataProvider.AddGood
        'Do Until Me.Busy
        '    'занят другим запросом
        'Loop
        ''--------
        Dim _good As New good
        Dim _result As good = Nothing
        With _good
            If IsArticul Then
                .productCode = code
            Else
                .code = code
            End If
            .SetRetailPrice(oMoySkladManadger, price, currency)
            '.SetRetailPrice(price, oMoySkladManadger.GetCurrencyUUIDByName(currency))
            .name = name
        End With

        Select Case oMoySkladManadger.AddGoodToServer(_good, _result)
            Case Net.HttpStatusCode.OK
                Me.Busy = False
                Return _result.GetPositionTrilbone(oMoySkladManadger)
            Case Else
                Me.Busy = False
                Return Nothing
        End Select
    End Function


    ''' <summary>
    ''' Добавить в отгрузку данные для отправки посылки
    ''' </summary>
    ''' <param name="DemandUUID">Отгрузка</param>
    ''' <param name="WokerUUID">Сотрудник, кому поручена отправка</param>
    ''' <param name="ShippingCompanyUUID">UUID шиппинговой компании</param>
    ''' <param name="DeclarationContent">текст декларации CN22-CN23 или 'нет'</param>
    Public Function AddParcelInfoToDemand(DemandUUID As String, WokerUUID As String, ShippingCompanyUUID As String, DeclarationContent As iMoySkladDataProvider.clsDeclaration_CP71_CN23) As Boolean Implements iMoySkladDataProvider.AddParcelInfoToDemand
        'протестировано

        Dim _demand = oMoySkladManadger.RequestDemandByUUID(DemandUUID)
        If _demand Is Nothing Then Return False

        _demand.applicable = False

        'атрибуты
        Dim _metadata = ""
        Dim _Value As Object
        Dim _attrList As New List(Of operationAttributeValue)
        If Not _demand.attribute Is Nothing Then
            _attrList.AddRange(_demand.attribute)
        Else
            _demand.attribute = New operationAttributeValue() {}
        End If
        '---функции работы с атрибутами
        Dim _deletefn = Sub(metadataUUID As String)
                            'ищем флаг в атрибутах товара
                            Dim _resAttrValue1 As operationAttributeValue
                            _resAttrValue1 = (From c In _demand.attribute Where c.metadataUuid = metadataUUID Select c).FirstOrDefault
                            If Not _resAttrValue1 Is Nothing Then
                                'да - удалим
                                _attrList.Remove(_resAttrValue1)
                            End If
                        End Sub


        Dim _addfn = Sub(attributeValue As Object, metadataUUID As String, IsBooleanType As Boolean, IsStringType As Boolean, IsDecimalType As Boolean, IsTextType As Boolean, IsCustomEntityType As Boolean)
                         'ищем флаг в атрибутах товара
                         Dim _resAttrValue As operationAttributeValue
                         _resAttrValue = (From c In _demand.attribute Where c.metadataUuid = metadataUUID Select c).FirstOrDefault
                         If Not _resAttrValue Is Nothing Then
                             'удалить атрибут
                             _deletefn(metadataUUID)
                         End If
                         'нет - создаем обьект атрибута и добавляем его в коллекцию
                         _resAttrValue = operationAttributeValue.CreateInstance(_demand.uuid, metadataUUID, attributeValue, IsBooleanType, IsStringType, IsDecimalType, IsTextType, IsCustomEntityType)
                         _attrList.Add(_resAttrValue)
                     End Sub
        '-=============
        'добавить атрибут Шиппинговая компания
        'определим значение атрибута
        If Not ShippingCompanyUUID = "" Then
            _Value = ShippingCompanyUUID
            _metadata = "f3b6405c-db60-11e3-4185-002590a28eca"
            _addfn(_Value, _metadata, IsBooleanType:=False, IsStringType:=False, IsDecimalType:=False, IsTextType:=False, IsCustomEntityType:=True)

        End If

        'добавить атрибут Декларация
        'определим значение атрибута
        If Not DeclarationContent Is Nothing Then
            _Value = DeclarationContent.ToString
            _metadata = "2068064f-8cf8-11e4-90a2-8ecb000c9447"
            _addfn(_Value, _metadata, IsBooleanType:=False, IsStringType:=True, IsDecimalType:=False, IsTextType:=False, IsCustomEntityType:=False)
        End If

        'добавить атрибут Отправил посылку сотрудник
        'определим значение атрибута
        If Not WokerUUID = "" Then
            _Value = WokerUUID
            _metadata = "f3b6423f-db60-11e3-d44a-002590a28eca"
            _addfn(_Value, _metadata, IsBooleanType:=False, IsStringType:=False, IsDecimalType:=False, IsTextType:=False, IsCustomEntityType:=True)
        End If

        _demand.attribute = _attrList.ToArray

        Dim _respond = ""
        Dim _message = ""
        Select Case oMoySkladManadger.AddAnyToServer(clsMoyScladManager.emMoySkladObjectTypes.Demand, _demand, _respond, _message)
            Case Net.HttpStatusCode.OK
                _demand = clsMSObjectReader(Of demand).CreatInstance(_respond)
                If _demand Is Nothing Then
                    MsgBox("Не удалось добавить атрибуты в отгрузку. Серверное сообщение: " & _message)
                    Return False
                End If
            Case Else
                MsgBox("Не удалось добавить атрибуты в отгрузку. Серверное сообщение: " & _message)
                Return False
        End Select

        Return True

    End Function

    Public Function GetShippingCompanies() As Dictionary(Of String, String) Implements iMoySkladDataProvider.GetShippingCompanies
        'тестировано
        Dim _out As New Dictionary(Of String, String)
        For Each c In oMoySkladManadger.GetEntityOfUserListByNameAsTrilbone("Шиппинговая компания")
            _out.Add(c.UUID, c.Value)
        Next
        Return _out
    End Function

    Public Function GetTriboneWoker() As Dictionary(Of String, String) Implements iMoySkladDataProvider.GetTriboneWoker
        'тестировано
        Dim _out As New Dictionary(Of String, String)
        For Each _wr In oMoySkladManadger.TrilboneWokersList
            _out.Add(_wr.uuid, _wr.name)
        Next
        Return _out
    End Function

    ''' <summary>
    ''' Запишет данные о выставлении образца
    ''' </summary>
    ''' <param name="SampleNumber">Номер товара (код)</param>
    ''' <param name="ReservCustomerOrderUUID">Заказ, используемый для резервации образца</param>
    ''' <param name="ItemAmount">Сумма выставления в валюте заказа</param>
    Public Function SetSampleToAction(SampleNumber As clsApplicationTypes.clsSampleNumber, ReservCustomerOrderUUID As String, ItemAmount As Decimal, Reserving As Boolean) As Boolean Implements iMoySkladDataProvider.SetSampleToAction
        'тестировано
        Dim _order = oMoySkladManadger.RequestCustomerOrderByUUID(ReservCustomerOrderUUID)
        If _order Is Nothing Then Return False

        Dim _goods As List(Of good) = Nothing
        Select Case oMoySkladManadger.FindGoods(SampleNumber.ShotCode, "", "", _goods)
            Case Is < 0
                'ошибка
                MsgBox(String.Format("Ошибка сервера. По коду {0} .", SampleNumber.ShotCode), vbCritical)
                Return False
            Case 0
                'не найден
                MsgBox(String.Format("Ошибка выстановки образца. По коду {0} не найдено товаров в МС.", SampleNumber.ShotCode), vbCritical)
                Return False
            Case 1
                'ok
                If _order.customerOrderPosition Is Nothing Then _order.customerOrderPosition = New customerOrderPosition() {}
                Dim _result = From c In _order.customerOrderPosition Where c.goodUuid.Equals(_goods(0).uuid) Select c

                If _result.Count > 0 Then
                    'образец не найден в заказе
                    MsgBox(String.Format("Образец с номером {0} уже присутствует в Заказе {1}", SampleNumber.ShotCode, _order.name), vbInformation)
                    Return False
                End If
                'ok
                Dim _list As New List(Of customerOrderPosition)
                For Each t In _order.customerOrderPosition
                    _list.Add(t)
                Next
                'создать позицию
                Dim _position = New customerOrderPosition
                'кол-во товара (пока всегда 1)
                Dim _qty As Decimal = 1
                With _position
                    .discount = 0
                    .quantity = _qty
                    .basePrice = New moneyAmount With {.sumInCurrency = ItemAmount * 100, .sum = ItemAmount * _order.rate * 100, .sumInCurrencySpecified = True, .sumSpecified = True}
                    .price = New moneyAmount With {.sumInCurrency = ItemAmount * 100, .sum = ItemAmount * _order.rate * 100, .sumInCurrencySpecified = True, .sumSpecified = True}

                    If Reserving Then
                        .reserve = _qty
                    Else
                        .reserve = 0
                    End If

                    'товар
                    'все операции проверки наличия и поиска товара лежат на вызывающей стороне
                    .goodUuid = _goods(0).uuid
                End With

                _list.Add(_position)

                _order.customerOrderPosition = _list.ToArray

                'сохранить
                Dim _message As String = ""
                Dim _respond As String = ""
                Select Case oMoySkladManadger.AddAnyToServer(clsMoyScladManager.emMoySkladObjectTypes.CustomerOrder, _order, _respond, _message)
                    Case Net.HttpStatusCode.OK
                        _order = clsMSObjectReader(Of customerOrder).CreatInstance(_respond)
                        If _order Is Nothing Then
                            MsgBox("Не удалось обновить заказ. Серверное сообщение: " & _message)
                            Return False
                        End If
                        'продолжим добавлять атрибуты
                    Case Else
                        MsgBox("Не удалось обновить заказ. Серверное сообщение: " & _message)
                        Return False
                End Select

                Return True
            Case Is > 1
                'найдено несколько
                MsgBox(String.Format("Ошибка выстановки образца. По коду {0} найдено {1} товаров. Удалите дубликаты в Моем Складе.", SampleNumber.ShotCode, _goods.Count), vbCritical)
                Return False
        End Select

        Return False

    End Function

    Public Function GetCurrencyUUIDByName(currencyName As String) As String Implements iMoySkladDataProvider.GetCurrencyUUIDByName
        Return oMoySkladManadger.GetCurrencyUUIDByName(currencyName)
    End Function
    ''' <summary>
    ''' Окончательный рассчет по продаже
    ''' </summary>
    ''' <param name="DemandUUID"></param>
    ''' <param name="ExportFee">сумма за экспорт</param>
    ''' <param name="ExportGoodUUID">UUID товара Экспорт.</param>
    ''' <param name="NalogFee">сумма налогов к оплате</param>
    ''' <param name="NalogFeeUUID">UUID товара Налоги.  для каждой организации свой. Зависит от выбранного paypal аккаунта для входящего платежа.</param>
    ''' <param name="PayPalOutFeeGoodUUID">UUID товара PayPal вывод, коммиссия.  для каждого PAYPAL аккаунта свой. Зависит от выбранного paypal аккаунта для входящего платежа.</param>
    ''' <param name="EbayFeeStartGoodUUID">UUID товара EbayFee за выставление. для каждого аукциона свой</param>
    ''' <param name="PayPalOutFeeAmount">сумма за вывод денег</param>
    ''' <param name="EbayFeeStartAmount">сумма за выставление</param>
    ''' <param name="ShippingInGoodUUID">UUID товар Шиппинг (Получено от клиента)</param>
    ''' <param name="ShippingInAmount">сумма полученная за шиппинг от клиента</param>
    ''' <param name="PayPalStartFeeGoodUUID">UUID товара PayPalFee.  для каждого PAYPAL аккаунта свой. Зависит от выбранного paypal аккаунта для входящего платежа.</param>
    ''' <param name="EbayFeeEndGoodUUID">UUID товара EbayFee по окончании. для каждого аукциона свой</param>
    ''' <param name="PayPalStartFeeAmount">сумма за прием денег</param>
    ''' <param name="EbayFeeEndAmount">сумма по окончанию аукциона</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function UpdateDemandsAfterCalculate(DemandUUID As String, PayPalOutFeeAmount As Decimal, PayPalOutFeeGoodUUID As String, EbayFeeStartAmount As Decimal, EbayFeeStartGoodUUID As String, ExportFee As Decimal, ExportGoodUUID As String, exportQuantity As Decimal, NalogFee As Decimal, NalogFeeUUID As String, ShippingInGoodUUID As String, ShippingInAmount As Decimal, ShippingInQty As Decimal, PayPalStartFeeGoodUUID As String, EbayFeeEndGoodUUID As String, PayPalStartFeeAmount As Decimal, EbayFeeEndAmount As Decimal) As Boolean Implements iMoySkladDataProvider.UpdateDemandsAfterCalculate


        Dim _demand = oMoySkladManadger.RequestDemandByUUID(DemandUUID)
        If _demand Is Nothing Then Return False

        'добавить товар с реальной стоимостью шиппинга и товар со стоимостью упаковки

        '=======позиции
        'сохраним старые позиции 
        Dim _positions As New List(Of shipmentOut)
        If Not _demand.shipmentOut Is Nothing Then
            For Each t In _demand.shipmentOut
                _positions.Add(t)
            Next
        End If

        Dim _shipmentOut As shipmentOut

        Dim _fn = Function(qty As Decimal, Amount As Decimal, goodUUID As String)
                      _shipmentOut = New shipmentOut
                      With _shipmentOut
                          .discount = 0
                          .quantity = qty

                          If Amount > 0 Then
                              .basePrice = New moneyAmount With {.sumInCurrency = Amount * 100, .sum = Amount * _demand.rate * 100, .sumInCurrencySpecified = True, .sumSpecified = True}
                              .price = New moneyAmount With {.sumInCurrency = Amount * 100, .sum = Amount * _demand.rate * 100, .sumInCurrencySpecified = True, .sumSpecified = True}
                          End If

                          .vat = 0
                          'товар
                          'все операции проверки наличия и поиска товара лежат на вызывающей стороне
                          .goodUuid = goodUUID
                      End With
                      Return _shipmentOut
                  End Function

        '=======позиции
        'добавим ShippingInAmount + ShippingInGoodUUID
        If ShippingInAmount > 0 Then
            _positions.Add(_fn(ShippingInQty, ShippingInAmount, ShippingInGoodUUID))
        End If
        '--------------------
        'PayPalStartFeeAmount + PayPalStartFeeGoodUUID
        If Not PayPalStartFeeAmount = 0 Then
            _positions.Add(_fn(1, PayPalStartFeeAmount, PayPalStartFeeGoodUUID))
        End If
        '--------------------
        'EbayFeeEndAmount + EbayFeeEndGoodUUID
        If Not EbayFeeEndAmount = 0 Then
            _positions.Add(_fn(1, EbayFeeEndAmount, EbayFeeEndGoodUUID))
        End If
        '-------------------------


        'Стоимость вывода (PayPal)
        If Not PayPalOutFeeAmount = 0 Then
            _positions.Add(_fn(1, PayPalOutFeeAmount, PayPalOutFeeGoodUUID))
        End If

        '--------------------
        'Стоимость выставления на eBay
        If Not EbayFeeStartAmount = 0 Then
            _positions.Add(_fn(1, EbayFeeStartAmount, EbayFeeStartGoodUUID))
        End If

        '--------------------
        'Стоимость налогов
        If Not NalogFee = 0 Then
            _positions.Add(_fn(1, NalogFee, NalogFeeUUID))
        End If
        '--------------------
        'Стоимость экспорта
        If Not ExportFee = 0 Then
            _positions.Add(_fn(exportQuantity, ExportFee, ExportGoodUUID))
        End If


        'запомнить позиции
        _demand.shipmentOut = _positions.ToArray
        '==================
        Dim _respond = ""
        Dim _message = ""
        Select Case oMoySkladManadger.AddAnyToServer(clsMoyScladManager.emMoySkladObjectTypes.Demand, _demand, _respond, _message)
            Case Net.HttpStatusCode.OK
                _demand = clsMSObjectReader(Of demand).CreatInstance(_respond)
                If _demand Is Nothing Then
                    MsgBox("Не удалось добавить позиции в отгрузку. Серверное сообщение: " & _message)
                    Return False
                End If
            Case Else
                MsgBox("Не удалось добавить позиции в отгрузку. Серверное сообщение: " & _message)
                Return False
        End Select

        Return True
    End Function

    ''' <summary>
    ''' Обновит товар в складе
    ''' </summary>
    ''' <param name="goodCodeToUpdate">наш код короткий</param>
    ''' <param name="inbuyPrice"></param>
    ''' <param name="buyCurrencyName"></param>
    ''' <param name="insalePrice"></param>
    ''' <param name="saleCurrencyName"></param>
    ''' <param name="uomName"></param>
    ''' <param name="ingoodname"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function UpdateGoodPrice(goodCodeToUpdate As String, inbuyPrice As Decimal, buyCurrencyName As String, insalePrice As Decimal, saleCurrencyName As String, uomName As String, ingoodname As String, goodweight As Decimal, Optional Prices As List(Of iMoySkladDataProvider.strPrices) = Nothing) As String Implements iMoySkladDataProvider.UpdateGoodPrice
        Dim _found As New List(Of good)
        Select Case oMoySkladManadger.FindGoods(goodCodeToUpdate, "", "", _found) > 0
            Case 0
                Return ""
            Case 1
                Return oMoySkladManadger.UpdateGoodPrice(_found(0), inbuyPrice, buyCurrencyName, insalePrice, saleCurrencyName, uomName, ingoodname, goodweight, Prices)
            Case Is > 1
                Dim _tmp As String = ""
                For Each t In _found
                    If Not t.code = "" Then
                        _tmp += t.code & ", "
                    End If
                    If Not t.productCode = "" Then
                        _tmp += t.productCode & ", "
                    End If
                Next
                _tmp.TrimEnd(", ".ToCharArray)
                MsgBox("найдено несколько товаров для обновления. Уберите одинаковые кода через мой склад.Найденные кода: " & _tmp, vbCritical)
                Return ""
        End Select
        Return ""

    End Function


    ''' <summary>
    ''' Добавит данные в отгрузки после фактической отправки/ Поддерживается только одинаковые шиппинговые компании и сотрудники для массива входящих данных. Трек номера склеиваются в строку.
    ''' </summary>
    Public Function UpdateDemandsAfterShip(DemandUUID As String, ResultParcels() As iMoySkladDataProvider.clsResultParcelInfo, NewStateUUID As String) As Boolean Implements iMoySkladDataProvider.UpdateDemandsAfterShip
        'тестировано
        Dim _demand = oMoySkladManadger.RequestDemandByUUID(DemandUUID)
        If _demand Is Nothing Then Return False
        'атрибуты
        Dim _metadata = ""
        Dim _Value As Object
        Dim _attrList As New List(Of operationAttributeValue)
        If Not _demand.attribute Is Nothing Then
            _attrList.AddRange(_demand.attribute)
        Else
            _demand.attribute = New operationAttributeValue() {}
        End If
        '---функции работы с атрибутами
        Dim _deletefn = Sub(metadataUUID As String)
                            'ищем флаг в атрибутах товара
                            Dim _resAttrValue1 As operationAttributeValue
                            _resAttrValue1 = (From c In _demand.attribute Where c.metadataUuid = metadataUUID Select c).FirstOrDefault
                            If Not _resAttrValue1 Is Nothing Then
                                'да - удалим
                                _attrList.Remove(_resAttrValue1)
                            End If
                        End Sub


        Dim _addfn = Sub(attributeValue As Object, metadataUUID As String, IsBooleanType As Boolean, IsStringType As Boolean, IsDecimalType As Boolean, IsTextType As Boolean, IsCustomEntityType As Boolean)
                         'ищем флаг в атрибутах товара
                         Dim _resAttrValue As operationAttributeValue
                         _resAttrValue = (From c In _demand.attribute Where c.metadataUuid = metadataUUID Select c).FirstOrDefault
                         If Not _resAttrValue Is Nothing Then
                             'удалить атрибут
                             _deletefn(metadataUUID)
                         End If
                         'нет - создаем обьект атрибута и добавляем его в коллекцию
                         _resAttrValue = operationAttributeValue.CreateInstance(_demand.uuid, metadataUUID, attributeValue, IsBooleanType, IsStringType, IsDecimalType, IsTextType, IsCustomEntityType)
                         _attrList.Add(_resAttrValue)
                     End Sub
        '-=============
        'добавить атрибут Трек Номер
        'определим значение атрибута = склеим все треки в строку
        Dim _str = ""
        For Each t In ResultParcels
            _str += t.TrackNumber & " "
        Next
        _str.Trim()
        _metadata = "4c113dd1-db61-11e3-57d8-002590a28eca"
        _addfn(_str, _metadata, IsBooleanType:=False, IsStringType:=True, IsDecimalType:=False, IsTextType:=False, IsCustomEntityType:=False)

        'добавить атрибут Шиппинговая компания
        'определим значение атрибута
        _Value = ResultParcels(0).ShippingCompanyUUID
        _metadata = "f3b6405c-db60-11e3-4185-002590a28eca"
        _addfn(_Value, _metadata, IsBooleanType:=False, IsStringType:=False, IsDecimalType:=False, IsTextType:=False, IsCustomEntityType:=True)

        'добавить атрибут Отправил посылку сотрудник
        'определим значение атрибута
        _Value = ResultParcels(0).SenderUUID
        _metadata = "f3b6423f-db60-11e3-d44a-002590a28eca"
        _addfn(_Value, _metadata, IsBooleanType:=False, IsStringType:=False, IsDecimalType:=False, IsTextType:=False, IsCustomEntityType:=True)

        'записать в отгрузку
        _demand.attribute = _attrList.ToArray
        _demand.stateUuid = NewStateUUID
        _demand.applicable = True
        For Each rp In ResultParcels
            _demand.description += ChrW(13) & "Комментарий отправителя: " & rp.Comment
            _demand.description += ChrW(13) & String.Format("Посылка Вес: {0}кг Размеры:{1}x{2}x{3}м", rp.ParcelWeight, rp.ParcelSizeA, rp.ParcelSizeB, rp.ParcelSizeC)
            _demand.description += ChrW(13) & String.Format("Трек-номер: {0}", rp.TrackNumber)
        Next
        'сохранить
        Dim _respond = ""
        Dim _message = ""
        Select Case oMoySkladManadger.AddAnyToServer(clsMoyScladManager.emMoySkladObjectTypes.Demand, _demand, _respond, _message)
            Case Net.HttpStatusCode.OK
                _demand = clsMSObjectReader(Of demand).CreatInstance(_respond)
                If _demand Is Nothing Then
                    MsgBox("Не удалось добавить атрибуты в отгрузку. Серверное сообщение: " & _message)
                    Return False
                End If
            Case Else
                MsgBox("Не удалось добавить атрибуты в отгрузку. Серверное сообщение: " & _message)
                Return False
        End Select

        'добавить товар с реальной стоимостью шиппинга и товар со стоимостью упаковки
        '=======позиции
        'сохраним старые позиции 
        Dim _positions As New List(Of shipmentOut)
        If Not _demand.shipmentOut Is Nothing Then
            For Each t In _demand.shipmentOut
                _positions.Add(t)
            Next
        End If

        Dim _shipmentOut As shipmentOut

        Dim _fnCreateShipmentOut = Function(qty As Decimal, Amount As Decimal, goodUUID As String)
                                       _shipmentOut = New shipmentOut
                                       With _shipmentOut
                                           .discount = 0
                                           .quantity = qty
                                           'вынуть из ячейки
                                           '.slotUuid=""
                                           If Amount > 0 Then
                                               .basePrice = New moneyAmount With {.sumInCurrency = Amount * 100, .sum = Amount * _demand.rate * 100, .sumInCurrencySpecified = True, .sumSpecified = True}
                                               .price = New moneyAmount With {.sumInCurrency = Amount * 100, .sum = Amount * _demand.rate * 100, .sumInCurrencySpecified = True, .sumSpecified = True}
                                           End If

                                           .vat = 0
                                           'товар
                                           'все операции проверки наличия и поиска товара лежат на вызывающей стороне
                                           If String.IsNullOrEmpty(goodUUID) Then
                                               .goodUuid = Nothing
                                           Else
                                               .goodUuid = goodUUID
                                           End If

                                           .uuid = Nothing
                                       End With
                                       Return _shipmentOut
                                   End Function

        'позиции товаров обслуживания отправки
        For Each _pinfo In ResultParcels
            With _pinfo
                'если валюта не указана, то считаем по валюте Отгрузки
                If .ShippingAndHandlingCurrencyUUID = "" Then .ShippingAndHandlingCurrencyUUID = _demand.currencyUuid

                If .HandlingAmount > 0 Then
                    'добавим работу по упаковке и отправке
                    'пересчет валюты в валюту отгрузки
                    Dim _amount = oMoySkladManadger.CurrencyConvert(.HandlingAmount, .ShippingAndHandlingCurrencyUUID, _demand.currencyUuid)
                    _positions.Add(_fnCreateShipmentOut(1, _amount, .HandlingGoodUUID))
                End If

                If .ShippingAmount > 0 Then
                    'добавим товар фактической стоимости шиппинга
                    Dim _amount = oMoySkladManadger.CurrencyConvert(.ShippingAmount, .ShippingAndHandlingCurrencyUUID, _demand.currencyUuid)
                    _positions.Add(_fnCreateShipmentOut(1, _amount, .ShippingGoodUUID))
                End If

                If (Not .PackagingGoodsUUIDsAndQtys Is Nothing) AndAlso .PackagingGoodsUUIDsAndQtys.Count > 0 Then
                    'добавить товары, использованные при упаковке
                    For Each _pg In .PackagingGoodsUUIDsAndQtys
                        Dim _amount = oMoySkladManadger.CurrencyConvert(_pg.Amount, _pg.CurrencyUUID, _demand.currencyUuid)
                        _positions.Add(_fnCreateShipmentOut(_pg.Qty, _amount, _pg.GoodUUID))
                    Next
                End If
            End With
        Next


        'запомнить позиции
        _demand.shipmentOut = _positions.ToArray
        '==================
        _respond = ""
        _message = ""
        Select Case oMoySkladManadger.AddAnyToServer(clsMoyScladManager.emMoySkladObjectTypes.Demand, _demand, _respond, _message)
            Case Net.HttpStatusCode.OK
                _demand = clsMSObjectReader(Of demand).CreatInstance(_respond)
                If _demand Is Nothing Then
                    MsgBox("Не удалось добавить позиции в отгрузку. Серверное сообщение: " & _message)
                    Return False
                End If
            Case Else
                MsgBox("Не удалось добавить позиции в отгрузку. Серверное сообщение: " & _message)
                Return False
        End Select

        Return True

    End Function

    ''' <summary>
    ''' предоставит интерфейс в Service (как делегат)
    ''' </summary>
    ''' <param name="needInit"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetInterface(needInit As Boolean) As iMoySkladDataProvider
        'тестировано ранее
        'блокировано 15/11/2016
        Return New Service.clsdbMoySklad

        If oMoySkladManadger Is Nothing Then
            CreateManager("admin@trilbone", "illaenus2012")
            Return Nothing
        Else
            If needInit Then CreateManager("admin@trilbone", "illaenus2012")

            If Not oMoySkladManadger.IsBusy Then
                Return Me
            Else
                Return Nothing
            End If
        End If
    End Function
#End Region



End Class
