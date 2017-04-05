Imports System.Runtime.CompilerServices
Imports System.Reflection
Imports RestMS_Client.MoySkladAPI
Imports RestMS_Client.SerialObj
Imports RestSharp
Imports System.Text
Imports Service
Imports System.Threading
Imports System.ComponentModel


Namespace SerialObj

    Partial Class stockTO
        Public Function GetStokQuantity(Optional warehouseName As String = "", Optional warehouseUUID As String = "") As iMoySkladDataProvider.clsStokQuantity
            Dim _out = New iMoySkladDataProvider.clsStokQuantity
            Dim _str As New iMoySkladDataProvider.strGoodMapQty

            With _out
                .Code = Me.goodRef.code
                .ProductCode = Me.productCode
                .Name = Me.goodRef.name
                .goodUUID = Me.goodRef.uuid
                .IsArticul = If(String.IsNullOrEmpty(Me.goodRef.code), True, False)

                .Quantity = Me.quantity 'доступно (резерв не включается!!)
                .Reserve = Me.reserve 'в резерве
                .Stok = Me.stock 'полное доступное кол-во, включая резерв

                .SaleAmount = Me.saleAmount / 100
                .SalePrice = Me.salePrice / 100
                .SumTotal = Me.sumTotal / 100
                .Currency = "RUR"

                .UomName = Me.uomName
                .Category = Me.category

                .WareName = If(Me.storeRef Is Nothing, warehouseName, Me.storeRef.name)

                With _str
                    'порядок ВАЖЕН в случае наличия и кода, и артикула. Код главнее.
                    'сначала артикул
                    If Not String.IsNullOrWhiteSpace(Me.productCode) Then
                        .ProductCode = Me.productCode
                    End If
                    'потом код
                    If Not String.IsNullOrWhiteSpace(Me.goodRef.code) Then
                        .code = Me.goodRef.code
                    End If

                    .Name = Me.goodRef.name
                    .UUID = Me.goodRef.uuid

                    .Qty = Me.stock 'полное доступное кол-во, включая резерв
                    .UomName = Me.uomName

                    .SlotName = "" 'это здесь неприменимо
                    .SlotUUID = "" 'это здесь неприменимо

                    .WareName = If(Me.storeRef Is Nothing, warehouseName, Me.storeRef.name)
                    .WareUUID = If(Me.storeRef Is Nothing, warehouseUUID, Me.storeRef.uuid)
                End With
                .GoodMapQty = {_str}
            End With

            Return _out
        End Function
    End Class


    Partial Public Class slotStateReportTO
        ''' <summary>
        ''' вернет мой обьект описания кол-ва товара
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetGoodQty() As iMoySkladDataProvider.strGoodMapQty
            Dim _loc As New iMoySkladDataProvider.strGoodMapQty
            With _loc
                'порядок ВАЖЕН в случае наличия и кода, и артикула. Код главнее.
                'сначала артикул
                If Not String.IsNullOrWhiteSpace(Me.productCode) Then
                    .ProductCode = Me.productCode
                End If
                'потом код
                If Not String.IsNullOrWhiteSpace(Me.goodRef.code) Then
                    .code = Me.goodRef.code
                End If

                .Name = Me.goodRef.name
                .UUID = Me.goodRef.uuid

                .Qty = Me.quantity
                .UomName = Me.uomName

                .SlotName = Me.slotRef.name
                .SlotUUID = Me.slotRef.uuid

                .WareName = Me.warehouseRef.name
                .WareUUID = Me.warehouseRef.uuid
            End With
            Return _loc
        End Function
    End Class
End Namespace


Public Module mdMoySkladExtentions
    Private oCurrentSchema As Xml.Schema.XmlSchemaSet
    Sub New()
        Dim _sh As New Xml.Schema.XmlSchemaSet
        Dim s As String = My.Resources.MOYsklad
        Dim _sr As New IO.StringReader(s)

        Dim _s = Xml.Schema.XmlSchema.Read(_sr, Sub(sender As Object, e As System.Xml.Schema.ValidationEventArgs)
                                                    MsgBox(e.Message)
                                                    Return
                                                End Sub)
        _sh.Add(_s)
        oCurrentSchema = _sh
    End Sub




    ''' <summary>
    ''' xmlString = строка РЕСТ ответа. Читает хмл и инициализует обьект а 
    ''' </summary>
    ''' <param name="a"></param>
    ''' <param name="xmlString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Extension()>
    Function ReadFromXML(ByRef a As MoySkladAPI.collectionContainer, xmlString As String) As Boolean
        Static _xml As Xml.Serialization.XmlSerializer
        If _xml Is Nothing Then
            _xml = New Xml.Serialization.XmlSerializer(GetType(MoySkladAPI.collectionContainer))
        End If

        Dim _txt As New System.IO.StringReader(xmlString)
        Dim _xmlsettings As New Xml.XmlReaderSettings

        Try
            Dim _xd = XElement.Parse(xmlString)
            Dim _obj = _xml.Deserialize(_xd.CreateReader())
            Dim _container = CType(_obj, MoySkladAPI.collectionContainer)
            a = _container
            Return True
        Catch ex As Exception
            a = Nothing
            Return False
        End Try



        'With _xmlsettings
        '    .CheckCharacters = True
        '    .ConformanceLevel = Xml.ConformanceLevel.Auto
        '    .DtdProcessing = Xml.DtdProcessing.Ignore
        '    .IgnoreComments = True
        '    .IgnoreProcessingInstructions = True
        '    .Schemas = oCurrentSchema
        'End With

        'Dim _xreader = Xml.XmlReader.Create(_txt, _xmlsettings)
        'Dim _obj = _xml.Deserialize(_xreader, "http://schemas.xmlsoap.org/soap/encoding/")
        ''""http://www.w3.org/2001/12/soap-encoding""

    End Function
    ' ''' <summary>
    ' ''' пробует получить обьект из контейнера а. Тип Т - наследник accountEntity
    ' ''' </summary>
    ' ''' <typeparam name="T"></typeparam>
    ' ''' <param name="a"></param>
    ' ''' <param name="index"></param>
    ' ''' <param name="_result"></param>
    ' ''' <returns></returns>
    ' ''' <remarks></remarks>
    '<Extension()>
    'Private Function TryGetObject(Of T As accountEntity)(ByVal a As MoySkladAPI.collectionContainer, index As Integer, ByRef _result As T) As Boolean
    '    Dim _xelem As Xml.XmlElement = a.Any(index)
    '    Dim _out = clsMSObjectReader(Of T).CreatInstance(_xelem.OuterXml)
    '    _result = _out
    '    Return True
    'End Function
    ''' <summary>
    ''' пробует получить коллекцию обьектов из контейнера а. Тип Т - наследник accountEntity
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="a"></param>
    ''' <param name="_result"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Extension()>
    Function TryGetObjectCollection(Of T As accountEntity)(ByVal a As MoySkladAPI.collectionContainer, ByRef _result As List(Of T)) As Boolean
        Dim _tmp As T
        Dim _out As New List(Of T)
        If a.Any Is Nothing Then _result = _out : Return False
        For Each t In a.Any
            _tmp = clsMSObjectReader(Of T).CreatInstance(t.OuterXml)
            If Not _tmp Is Nothing Then
                _out.Add(_tmp)
            End If
        Next
        _result = _out
        Return True
    End Function
    ''' <summary>
    '''  пробует получить коллекцию обьектов из контейнера а. Тип Т - один из типов мойсклад
    ''' </summary>
    ''' <param name="a"></param>
    ''' <param name="_result"></param>
    ''' <param name="T"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Extension()>
    Function TryGetObjectCollection(ByVal a As MoySkladAPI.collectionContainer, ByRef _result As List(Of Object), T As Type) As Boolean
        Dim _tmp As Object
        Dim _out As New List(Of Object)
        If a.Any Is Nothing Then _result = _out : Return False
        For Each e In a.Any
            _tmp = ReadXML(e.OuterXml, T)
            If Not _tmp Is Nothing Then
                _out.Add(_tmp)
            End If
        Next
        _result = _out
        Return True
    End Function
    ''' <summary>
    ''' служебная ф чтения хмл. заменяет clsMSObjectReader(Of Т)
    ''' </summary>
    ''' <param name="xmlString"></param>
    ''' <param name="_type"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ReadXML(xmlString As String, _type As Type) As Object
        'кешируем сериализаторы
        Static _cash As Collections.Generic.Dictionary(Of Type, Xml.Serialization.XmlSerializer)
        If _cash Is Nothing Then
            _cash = New Collections.Generic.Dictionary(Of Type, Xml.Serialization.XmlSerializer)
        End If
        Dim _xml As Xml.Serialization.XmlSerializer
        If _cash.ContainsKey(_type) Then
            _xml = _cash(_type)
        Else
            _xml = New Xml.Serialization.XmlSerializer(_type)
            _cash.Add(_type, _xml)
        End If



        Dim _txt As New System.IO.StringReader(xmlString)

        Dim _xmlsettings As New Xml.XmlReaderSettings
        With _xmlsettings
            .CheckCharacters = True
        End With

        Dim _xreader = Xml.XmlReader.Create(_txt, _xmlsettings)
        Try
            Dim _obj = _xml.Deserialize(_xreader)
            Return _obj
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try

    End Function



    ''' <summary>
    ''' служебный класс десериализации обьектов-наследников abstractPositionReport
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <remarks></remarks>
    Friend Class clsMSObjectTOReader(Of T As abstractPositionReport)
        '<Serializable()>
        '        Public Class TOCollection(Of T1)
        '    Public Property collection As List(Of T1)
        'End Class

        ''' <summary>
        ''' создает обьект
        ''' </summary>
        ''' <param name="xmlString"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Shared Function CreatInstance(xmlString As String) As List(Of T)

            'кешируем сериализаторы
            Static _cash As Collections.Generic.Dictionary(Of Type, Xml.Serialization.XmlSerializer)
            If _cash Is Nothing Then
                _cash = New Collections.Generic.Dictionary(Of Type, Xml.Serialization.XmlSerializer)
            End If

            Dim _typ = GetType(T)
            Dim _xml As Xml.Serialization.XmlSerializer

            If _cash.ContainsKey(_typ) Then
                _xml = _cash.Item(_typ)
            Else
                _xml = New Xml.Serialization.XmlSerializer(_typ)
                _cash.Add(_typ, _xml)
            End If

            Dim _out = New List(Of T)

            Dim _xmlstr As XElement = XElement.Parse(xmlString)

            Dim _name = GetType(T).Name

            For Each c In _xmlstr.Descendants(_name)
                Dim _obj = _xml.Deserialize(c.CreateReader())
                Dim _result = TryCast(_obj, T)
                _out.Add(_result)
            Next
            Return _out
        End Function

    End Class




    ''' <summary>
    ''' служебный класс десериализации обьектов-наследников accountEntity
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <remarks></remarks>
    Friend Class clsMSObjectReader(Of T As accountEntity)

        Private Shared _cash As Collections.Generic.Dictionary(Of Type, Xml.Serialization.XmlSerializer)


        Private Shared Function GetSerilizer() As Xml.Serialization.XmlSerializer
            If _cash Is Nothing Then
                _cash = New Collections.Generic.Dictionary(Of Type, Xml.Serialization.XmlSerializer)
            End If
            Dim _typ = GetType(T)
            Dim _xml As Xml.Serialization.XmlSerializer

            If _cash.ContainsKey(_typ) Then
                _xml = _cash.Item(_typ)
            Else
                _xml = New Xml.Serialization.XmlSerializer(_typ)
                _cash.Add(_typ, _xml)
            End If
            Return _xml
        End Function


        ''' <summary>
        ''' создает обьект
        ''' </summary>
        ''' <param name="xmlString"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Shared Function CreatInstance(xmlString As String) As T
            'кешируем сериализаторы
            'Static _cash As Collections.Generic.Dictionary(Of Type, Xml.Serialization.XmlSerializer)
            'If _cash Is Nothing Then
            '    _cash = New Collections.Generic.Dictionary(Of Type, Xml.Serialization.XmlSerializer)
            'End If

            'Dim _typ = GetType(T)
            'Dim _xml As Xml.Serialization.XmlSerializer

            'If _cash.ContainsKey(_typ) Then
            '    _xml = _cash.Item(_typ)
            'Else
            '    _xml = New Xml.Serialization.XmlSerializer(_typ)
            '    _cash.Add(_typ, _xml)
            'End If

            Dim _xml = GetSerilizer()

            Dim _txt As New System.IO.StringReader(xmlString)

            Dim _xmlsettings As New Xml.XmlReaderSettings
            With _xmlsettings
                .CheckCharacters = True
            End With

            Dim _xreader = Xml.XmlReader.Create(_txt, _xmlsettings)
            Try
                Dim _obj = _xml.Deserialize(_xreader)

                Dim _result = TryCast(_obj, T)
                Return _result
            Catch ex As Exception
                MsgBox("Ошибка десериализации " & ex.Message, vbCritical)
                Return Nothing
            End Try

        End Function

        ''' <summary>
        ''' сериализует обьект
        ''' </summary>
        ''' <param name="value"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Shared Function GetXML(value As T) As String

            Dim _xmlSerializer = GetSerilizer()

            Dim _wrsett As New Xml.XmlWriterSettings
            Dim _xmlwriter As Xml.XmlWriter
            Dim _strBuilt As New System.Text.StringBuilder

            With _wrsett
                .Encoding = System.Text.Encoding.GetEncoding("windows-1251")
                .Indent = True
            End With

            _xmlwriter = Xml.XmlWriter.Create(_strBuilt, _wrsett)
            _xmlSerializer.Serialize(_xmlwriter, value)
            _xmlwriter.Flush()
            _xmlwriter.Close()

            Return _strBuilt.ToString
        End Function


    End Class
    ''' <summary>
    ''' менеджер управления сервисом
    ''' </summary>
    ''' <remarks></remarks>
    Public Class clsMoyScladManager
        ''' <summary>
        ''' класс хранения записей
        ''' </summary>
        ''' <remarks></remarks>
        <Serializable>
        Public Class clsWareList
            Property Version As String
            Property WareList As List(Of clsWare)
            <Serializable>
            Public Class clsLoss
                Property Name As String
                Property UUID As String
            End Class
            <Serializable>
            Public Class clsEnter
                Property Name As String
                Property UUID As String
            End Class
            <Serializable>
            Public Class clsWare
                Property Name As String
                Property UUID As String
                Property Loss As clsLoss
                Property Enter As clsEnter
            End Class
        End Class



        ''' <summary>
        ''' описывает ед.изм мойсклад
        ''' </summary>
        ''' <remarks></remarks>
        Public Structure strUom
            Public name As String
            Public uuid As String
            Public Overrides Function ToString() As String
                Return name
            End Function
        End Structure

        ''' <summary>
        ''' описывает доступные сервисы получения обьектов МС
        ''' </summary>
        ''' <remarks></remarks>
        Public Enum emMoySkladObjectTypes
            Empty
            'именуем как В МОЕМ СКЛАДЕ REST!!!!!!
            ComingIn
            Warehouse
            RetailStore
            Enterposition
            Good
            GoodFolder

            'контрагенты
            Company
            'наши организации
            MyCompany

            Employee
            Country
            Currency
            Consignment
            Project
            EnterReason
            CustomEntity
            Enter
            Supply
            Loss
            Move
            Inventory
            Store
            Operation
            CustomerOrder
            Agent
            Uom
            CustomEntityMetadata
            Attribute
            GoodAttributeValue
            'справочник цены
            PriceType
            Demand
            PaymentIn
            PaymentOut
            '{name}
            RetailCashIn
            RetailDemand
            CashIn
            CashOut
        End Enum
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks></remarks>
        Public Enum emMoySkladFilterTypes
            'именуем как В МОЕМ СКЛАДЕ REST!!!!!!
            empty
            description
            type
            code
            externalCode
            name
            id
            productCode
            uuid
            entityMetadataUuid
            ''' <summary>
            ''' передать Date.Tostring Обновлен позже, чем (с 1:00 указаного дня)
            ''' </summary>
            ''' <remarks></remarks>
            updatedLate
            ''' <summary>
            ''' передать Date.Tostring Обновлен раньше, чем (с 1:00 указаного дня)
            ''' </summary>
            ''' <remarks></remarks>
            updatedEarly

            ''' <summary>
            ''' передать Date.Tostring Создан позже, чем (с 1:00 указаного дня)
            ''' </summary>
            ''' <remarks></remarks>
            createdLate
        End Enum






        Private oUomList As List(Of strUom)
        Private oAuntific As RestSharp.IAuthenticator
        Private oRestClient As RestSharp.RestClient
        Private oWarehouseList As New List(Of warehouse)
        Dim oCurrentMSUserName As String
        Private oPricesList As List(Of iMoySkladDataProvider.strPrices)

        Private Sub New()
            init()
            Me.IsBusy = False
        End Sub


        Private Sub init()
            Me.IsBusy = True
            oUomList = New List(Of strUom)
            oUomList.Add(New strUom With {.name = "шт", .uuid = My.Settings.PcsUOMUUID})
            oUomList.Add(New strUom With {.name = "кг", .uuid = My.Settings.KgUOMUUID})
            oUomList.Add(New strUom With {.name = "е", .uuid = My.Settings.EUOMUUID})
            oUomList.Add(New strUom With {.name = "гр", .uuid = My.Settings.gUomUUID})
            '----------
            'список цен - см xml типы цен (запрос обьектов PriceType)
            oPricesList = New List(Of iMoySkladDataProvider.strPrices)
            With oPricesList
                .Add(New iMoySkladDataProvider.strPrices With {.PriceType = iMoySkladDataProvider.emPriceType.BuyPrice, .PriceTypeUUID = "", .Description = "Закупочная", .BaseCurrency = "RUR"})
                .Add(New iMoySkladDataProvider.strPrices With {.PriceType = iMoySkladDataProvider.emPriceType.MinimumPrice, .PriceTypeUUID = "", .Description = "Минимальная", .BaseCurrency = "RUR"})
                .Add(New iMoySkladDataProvider.strPrices With {.PriceType = iMoySkladDataProvider.emPriceType.EuPostPayPal, .PriceTypeUUID = "2d6c826c-7367-11e5-7a40-e8970074da9a", .Description = "Почтовая(PayPal)", .BaseCurrency = "USD"})
                .Add(New iMoySkladDataProvider.strPrices With {.PriceType = iMoySkladDataProvider.emPriceType.EuInShop, .PriceTypeUUID = "2d6c838b-7367-11e5-7a40-e8970074da9b", .Description = "Буржуи на выставке", .BaseCurrency = "EUR"})
                .Add(New iMoySkladDataProvider.strPrices With {.PriceType = iMoySkladDataProvider.emPriceType.Ebay, .PriceTypeUUID = "2d6c8412-7367-11e5-7a40-e8970074da9c", .Description = "EBAY", .BaseCurrency = "USD"})
                .Add(New iMoySkladDataProvider.strPrices With {.PriceType = iMoySkladDataProvider.emPriceType.Invoce, .PriceTypeUUID = "372ae149-6d67-11e3-bbb4-7054d21a8d1e", .Description = "Инвойс", .BaseCurrency = "EUR"})
                .Add(New iMoySkladDataProvider.strPrices With {.PriceType = iMoySkladDataProvider.emPriceType.EuPostBank, .PriceTypeUUID = "5059049d-7f30-11e4-90a2-8ecb00196e51", .Description = "Почтовая(банк)", .BaseCurrency = "USD"})
                .Add(New iMoySkladDataProvider.strPrices With {.PriceType = iMoySkladDataProvider.emPriceType.EuInOffice, .PriceTypeUUID = "99d007d3-7bdc-11e4-90a2-8ecb00172326", .Description = "Буржуи в офисе", .BaseCurrency = "EUR"})
                .Add(New iMoySkladDataProvider.strPrices With {.PriceType = iMoySkladDataProvider.emPriceType.RusInOffice, .PriceTypeUUID = "a56b78f5-4af6-11e3-12e9-7054d21a8d1e", .Description = "Розничная в офисе", .BaseCurrency = "RUR"})
                .Add(New iMoySkladDataProvider.strPrices With {.PriceType = iMoySkladDataProvider.emPriceType.RusShop, .PriceTypeUUID = "b14b6444-489b-11e3-36cc-7054d21a8d1e", .Description = "Розничная цена в магазине", .BaseCurrency = "RUR"})
            End With
        End Sub

        Private Sub New(serverURL As String, username As String, password As String)
            init()
            'тут подгружаем файл данных по serverURL


            oAuntific = New HttpBasicAuthenticator(username, password)
            oRestClient = New RestClient(serverURL)
            oRestClient.Authenticator = oAuntific
            Me.IsBusy = False
        End Sub

        ''' <summary>
        ''' список цен
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property PricesList As List(Of iMoySkladDataProvider.strPrices)
            Get
                Return oPricesList
            End Get
        End Property



        ''' <summary>
        ''' список доступных едениц измерения
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property UomList As List(Of strUom)
            Get
                Dim _list = New List(Of strUom)
                _list.AddRange(oUomList)
                Return _list
            End Get
        End Property

        Private oCurrencyList As New List(Of MoySkladAPI.currency)

        Public ReadOnly Property CurrencyList As List(Of MoySkladAPI.currency)
            Get
                Dim _list = New List(Of MoySkladAPI.currency)
                _list.AddRange(oCurrencyList)
                Return _list
            End Get
        End Property
        ''' <summary>
        ''' выдает да при  инициализации
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property IsBusy As Boolean
        ''' <summary>
        ''' вернет имя текущего пользователя (из учетных записей МС)
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property CurrentMSUserName As String
            Get
                Return oCurrentMSUserName
            End Get
        End Property

        ''' <summary>
        ''' создает обьект с учетными данными в МойСклад.грузит склады
        ''' </summary>
        ''' <param name="username"></param>
        ''' <param name="password"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Friend Shared Function CreateInstance(username As String, password As String) As clsMoyScladManager
            'управление загрузкой со стороны внешних функций происходит в clsRestMS_service CreateManager(...)
            Dim _serverURL = "https://online.moysklad.ru/exchange/rest"
            Dim _new As New clsMoyScladManager(_serverURL, username, password)
            With _new
                .oCurrentMSUserName = username
                If .LoadEntities() = False Then Return Nothing
            End With
            Return _new
        End Function

        ''' <summary>
        ''' создает инвентаризацию
        ''' </summary>
        ''' <param name="MyCompanyUUID">компания</param>
        ''' <param name="WarehouseUUID">склад для инвентаризации</param>
        ''' <param name="GoodsUUIDs">список товаров</param>
        ''' <param name="Description">описание</param>
        ''' <param name="WareCellName">номер инвентаризуемой ячейки (если нужен)</param>
        ''' <param name="StateUUID">статус инвентаризации (по умолчанию НЕТ)</param>
        ''' <param name="Applicable">проведено</param>
        ''' <param name="GoodsQtys">Количества товара в наличии (если надо)</param>
        ''' <returns></returns>
        Friend Function CreateInventory(MyCompanyUUID As String, WarehouseUUID As String, GoodsUUIDs() As String, Description As String, Optional WareCellName As String = "", Optional StateUUID As String = "2fb659a6-d883-11e4-90a2-8ecb001c0a01", Optional Applicable As Boolean = True, Optional GoodsQtys As Decimal() = Nothing) As iMoySkladDataProvider.clsOperationInfo
            Dim _inventory = New inventory
            With _inventory
                'статус  
                .stateUuid = StateUUID
                '.targetAgentUuid = CustomerUUID
                .sourceAgentUuid = MyCompanyUUID
                'проведено
                .applicable = Applicable
                '.projectUuid = ProjectUUID
                .payerVat = False
                '.currencyUuid = CurrencyUUID
                'сегодняшний курс ЦБ +3%
                '.rate = clsApplicationTypes.GetRateByCurrencyCB103(oMoySkladManadger.GetCurrencyByUUID(CurrencyUUID).name)
                .vatIncluded = True
                .description = Description

                'склад отгрузки
                .sourceStoreUuid = WarehouseUUID

            End With

            'создать и получить UUID
            Dim _message As String = ""
            Dim _respond As String = ""
            Select Case Me.AddAnyToServer(clsMoyScladManager.emMoySkladObjectTypes.Inventory, _inventory, _respond, _message)
                Case Net.HttpStatusCode.OK
                    _inventory = clsMSObjectReader(Of inventory).CreatInstance(_respond)
                    If _inventory Is Nothing Then
                        MsgBox("Не удалось создать инвентаризацию. Серверное сообщение: " & _message)
                        Return Nothing
                    End If
                    'продолжим добавлять атрибуты
                Case Else
                    MsgBox("Не удалось создать инвентаризацию. Серверное сообщение: " & _message)
                    Return Nothing
            End Select

            'атрибуты
            Dim _metadata = ""
            Dim _Value As Object
            Dim _attrList As New List(Of operationAttributeValue)
            If Not _inventory.attribute Is Nothing Then
                _attrList.AddRange(_inventory.attribute)
            Else
                _inventory.attribute = New operationAttributeValue() {}
            End If
            '---функции работы с атрибутами
            Dim _deletefn = Sub(metadataUUID As String)
                                'ищем флаг в атрибутах товара
                                Dim _resAttrValue1 As operationAttributeValue
                                _resAttrValue1 = (From c In _inventory.attribute Where c.metadataUuid = metadataUUID Select c).FirstOrDefault
                                If Not _resAttrValue1 Is Nothing Then
                                    'да - удалим
                                    _attrList.Remove(_resAttrValue1)
                                End If
                            End Sub


            Dim _addfn = Sub(attributeValue As Object, metadataUUID As String, IsBooleanType As Boolean, IsStringType As Boolean, IsDecimalType As Boolean, IsTextType As Boolean, IsCustomEntityType As Boolean)
                             'ищем флаг в атрибутах товара
                             Dim _resAttrValue As operationAttributeValue
                             _resAttrValue = (From c In _inventory.attribute Where c.metadataUuid = metadataUUID Select c).FirstOrDefault
                             If Not _resAttrValue Is Nothing Then
                                 'удалить атрибут
                                 _deletefn(metadataUUID)
                             End If
                             'нет - создаем обьект атрибута и добавляем его в коллекцию
                             _resAttrValue = operationAttributeValue.CreateInstance(_inventory.uuid, metadataUUID, attributeValue, IsBooleanType, IsStringType, IsDecimalType, IsTextType, IsCustomEntityType)
                             _attrList.Add(_resAttrValue)
                         End Sub
            '-=============
            'добавить атрибут Ячейка
            'определим значение атрибута
            _Value = WareCellName
            _metadata = "95da9d2d-f84d-11e5-7a69-970d0000013d"
            _addfn(_Value, _metadata, IsBooleanType:=False, IsStringType:=True, IsDecimalType:=False, IsTextType:=False, IsCustomEntityType:=False)

            ''добавить атрибут Тип оплаты инвойса справочник
            ''определим значение атрибута
            '_Value = InvocePaymentTypeUUID
            '_metadata = "942dcd23-8ebe-11e4-90a2-8ecb002d428a"
            '_addfn(_Value, _metadata, IsBooleanType:=False, IsStringType:=tr, IsDecimalType:=False, IsTextType:=False, IsCustomEntityType:=True)

            ''На кого Инвойс = на контрагента (внутренний справочник Company) тип атрибута другой, с полем agentValueUuid
            '_Value = _inventory.targetAgentUuid
            '_metadata = "8b8cc38e-7cf0-11e4-90a2-8ecb00003a8d"
            'Dim _attr = operationAttributeValue.CreateInstance(_inventory.uuid, _metadata, _Value, False, False, False, False, True)
            '_attr.agentValueUuid = _Value
            '_attrList.Add(_attr)

            _inventory.attribute = _attrList.ToArray

            _respond = ""
            _message = ""
            Select Case Me.AddAnyToServer(clsMoyScladManager.emMoySkladObjectTypes.Inventory, _inventory, _respond, _message)
                Case Net.HttpStatusCode.OK
                    _inventory = clsMSObjectReader(Of inventory).CreatInstance(_respond)
                    If _inventory Is Nothing Then
                        MsgBox("Не удалось добавить атрибуты в инвентаризацию. Серверное сообщение: " & _message)
                        Return Nothing
                    End If
                Case Else
                    MsgBox("Не удалось добавить атрибуты в инвентаризацию. Серверное сообщение: " & _message)
                    Return Nothing
            End Select

            ''-------------------------
            ''-------------------------

            Dim inventoryPosition As inventoryPosition
            Dim _list As New List(Of inventoryPosition)
            For i = 0 To GoodsUUIDs.Length - 1
                inventoryPosition = New inventoryPosition
                With inventoryPosition
                    .correctionAmount = -1
                    .discount = 0
                    If GoodsQtys Is Nothing Then
                        .quantity = 0
                    Else
                        .quantity = GoodsQtys(i)
                    End If
                    '.basePrice = New moneyAmount With {.sumInCurrency = GoodsAmounts(i) * 100, .sum = GoodsAmounts(i) * _demand.rate * 100, .sumInCurrencySpecified = True, .sumSpecified = True}
                    '.price = New moneyAmount With {.sumInCurrency = GoodsAmounts(i) * 100, .sum = GoodsAmounts(i) * _demand.rate * 100, .sumInCurrencySpecified = True, .sumSpecified = True}
                    .vat = 0
                    'товар
                    'все операции проверки наличия и поиска товара лежат на вызывающей стороне
                    .goodUuid = GoodsUUIDs(i)
                End With

                _list.Add(inventoryPosition)
            Next

            'запонмнить позиции
            _inventory.inventoryPosition = _list.ToArray
            '==================
            _respond = ""
            _message = ""
            Select Case Me.AddAnyToServer(clsMoyScladManager.emMoySkladObjectTypes.Inventory, _inventory, _respond, _message)
                Case Net.HttpStatusCode.OK
                    _inventory = clsMSObjectReader(Of inventory).CreatInstance(_respond)
                    If _inventory Is Nothing Then
                        MsgBox("Не удалось добавить позиции в отгрузку. Серверное сообщение: " & _message)
                        Return Nothing
                    End If
                Case Else
                    MsgBox("Не удалось добавить позиции в отгрузку. Серверное сообщение: " & _message)
                    Return Nothing
            End Select

            Return _inventory.GetInventoryTrilbone(Me)
        End Function


        ''' <summary>
        ''' загружает комплект сущностей с сервера для работы в нужной последовательности
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Friend Function LoadEntities(Optional onlyBase As Boolean = False) As Boolean
            With Me
                'основные
                'пробуем файл
                If Not Me.ReadWareFile Then
                    If .LoadWarehouses() = False Then Return False
                    .LoadEnters()
                    .LoadLosses()
                End If

                'использует два предыдущих
                .LoadLocantions()
                If onlyBase Then Return True
                '----------------------
                'дополнительные
                .LoadCurrency()
                .LoadClients()
                .LoadCustomEntitiesList()

                'справочники пользователя
                '"Экспедиции"
                Me.GetEntityOfUserListByNameAsTrilbone("Экспедиции")

                '"Допрепарация" 
                Me.GetEntityOfUserListByNameAsTrilbone("Допрепарация")

                '"Сотрудник Trilbone"
                Me.GetEntityOfUserListByNameAsTrilbone("Сотрудник Trilbone")

                '"Сотрудник Trilbone"
                Me.GetEntityOfUserListByNameAsTrilbone("Схемы расчетов выплат")

            End With
            Return True
        End Function

        ''' <summary>
        ''' справочник Схемы расчетов выплат
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property SchemeList As List(Of customEntity)
            Get
                If Not oUserEntityList.ContainsKey("Схемы расчетов выплат") Then Me.GetEntityOfUserListByNameAsTrilbone("Схемы расчетов выплат")
                Return oUserEntityList.Item("Схемы расчетов выплат")
            End Get
        End Property


        ''' <summary>
        ''' справочник Экспедиции
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property ExpeditionsList As List(Of customEntity)
            Get
                If Not oUserEntityList.ContainsKey("Экспедиции") Then Me.GetEntityOfUserListByNameAsTrilbone("Экспедиции")
                Return oUserEntityList.Item("Экспедиции")
            End Get
        End Property

        ' Private oTrilboneWokers As List(Of customEntity)

        'Private Sub LoadTrilboneWokers()
        '    Me.oTrilboneWokers = New List(Of customEntity)
        '    'добавить пустого работника
        '    Dim _em = New customEntity
        '    With _em
        '        .uuid = ""
        '        .name = ""
        '    End With
        '    Me.oTrilboneWokers.Add(_em)
        '    Me.oTrilboneWokers.AddRange(oUserEntityList.Item("сотрудник trilbone"))

        '    'Dim _data As IEnumerable(Of Object) = Nothing
        '    'Dim _message As String = ""
        '    ''загрузим об 
        '    'Dim _result = Me.RequestAnyCollection(clsMoyScladManager.emMoySkladObjectTypes.CustomEntity, _data, My.Settings.DirTrilboneWokersUUID, emMoySkladFilterTypes.entityMetadataUuid, _message, "")
        '    'If _result = Net.HttpStatusCode.OK Then
        '    '    Select Case _data.Count
        '    '        Case 0
        '    '            'пользовательского справочника не найден
        '    '            MsgBox("пользовательского справочника Сотрудник Trilbone нет! Неправильный запрос?" & ChrW(13) & _message, vbCritical)
        '    '        Case Is > 1
        '    '            Me.oTrilboneWokers.AddRange(_data.Cast(Of customEntity).ToList)
        '    '    End Select

        '    'Else
        '    '    'запрос вернул ошибку
        '    '    MsgBox("запрос пользовательского справочника Сотрудник Trilbone вернул ошибку. Неправильный запрос?" & ChrW(13) & _message, vbCritical)
        '    'End If
        'End Sub
        ''' <summary>
        ''' справочник сотрудники Trilbone
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property TrilboneWokersList As List(Of customEntity)
            Get
                If Not Me.oUserEntityList.ContainsKey("Сотрудник Trilbone") Then Me.GetEntityOfUserListByNameAsTrilbone("Сотрудник Trilbone")
                Return Me.oUserEntityList.Item("Сотрудник Trilbone")
            End Get
        End Property

        Private oClients As List(Of company)

        Private Sub LoadClients()
            Me.oClients = New List(Of company)
            'добавить пустого работника
            Dim _em = New company
            With _em
                .uuid = ""
                .name = ""
            End With
            Me.oClients.Add(_em)
            Dim _data As IEnumerable(Of Object) = Nothing
            Dim _message As String = ""
            'загрузим об 
            Dim _result = Me.RequestAnyCollection(clsMoyScladManager.emMoySkladObjectTypes.Company, _data, , , _message, "")
            If _result = Net.HttpStatusCode.OK Then
                Select Case _data.Count
                    Case 0
                        'пользовательского справочника не найден
                        MsgBox("Клиентов нет! Неправильный запрос?" & ChrW(13) & _message, vbCritical)
                    Case Is > 1
                        Me.oClients = (_data.Cast(Of company).ToList)
                End Select

            Else
                'запрос вернул ошибку
                MsgBox("запрос Клиентов вернул ошибку. Неправильный запрос?" & ChrW(13) & _message, vbCritical)
            End If
        End Sub

        Private oProjects As List(Of project)

        Private Sub LoadProject()
            Me.oProjects = New List(Of project)
            'добавить пустой проект
            Dim _em = New project
            With _em
                .uuid = ""
                .name = ""
            End With
            Me.oProjects.Add(_em)
            Dim _message As String = ""
            'Dim _data As IEnumerable(Of company) = Nothing
            If Not Me.RequestAnyCollection(Of project)(Me.oProjects, "", emMoySkladFilterTypes.empty, _message) Then
                MsgBox(_message, vbCritical)
            End If
        End Sub

        Private oCompanies As List(Of myCompany)

        Private Sub LoadCompanies()
            Me.oCompanies = New List(Of myCompany)
            'добавить пустой проект
            Dim _em = New myCompany
            With _em
                .uuid = ""
                .name = ""
            End With
            Me.oCompanies.Add(_em)
            Dim _message As String = ""

            If Not Me.RequestAnyCollection(Of myCompany)(Me.oCompanies, "", emMoySkladFilterTypes.empty, _message) Then
                MsgBox(_message, vbCritical)
            End If
        End Sub

        ''' <summary>
        ''' справочник Контрагенты
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property CustomerList(reload As Boolean) As List(Of company)
            Get
                If (Me.oClients Is Nothing) Or reload Then
                    LoadClients()
                End If
                Return oClients
            End Get
        End Property


        ''' <summary>
        ''' справочник Проекты
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property ProjectList(reload As Boolean) As List(Of project)
            Get
                If (Me.oProjects Is Nothing) Or reload Then
                    LoadProject()
                End If
                Return oProjects
            End Get
        End Property

        ''' <summary>
        ''' справочник Компания
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Friend ReadOnly Property CompanyList(reload As Boolean) As List(Of myCompany)
            Get
                If (Me.oCompanies Is Nothing) Or reload Then
                    LoadCompanies()
                End If
                Return oCompanies
            End Get
        End Property


        'Private oRePrepDetails As List(Of customEntity)

        'Private Sub LoadRePrepDetails()
        '    Me.oRePrepDetails = New List(Of customEntity)
        '    'добавить пустого работника
        '    Dim _em = New customEntity
        '    With _em
        '        .uuid = ""
        '        .name = ""
        '    End With
        '    Me.oRePrepDetails.Add(_em)
        '    Dim _data As IEnumerable(Of Object) = Nothing
        '    Dim _message As String = ""
        '    'загрузим об 
        '    Dim _result = Me.RequestAnyCollection(clsMoyScladManager.emMoySkladObjectTypes.CustomEntity, _data, My.Settings.DirRePreparingUUID, emMoySkladFilterTypes.entityMetadataUuid, _message, "")
        '    If _result = Net.HttpStatusCode.OK Then
        '        Select Case _data.Count
        '            Case 0
        '                'пользовательского справочника не найден
        '                MsgBox("Допрепараций нет! Неправильный запрос?" & ChrW(13) & _message, vbCritical)
        '            Case Is > 1
        '                Me.oRePrepDetails.AddRange(_data.Cast(Of customEntity).ToList)
        '        End Select

        '    Else
        '        'запрос вернул ошибку
        '        MsgBox("запрос Допрепараций вернул ошибку. Неправильный запрос?" & ChrW(13) & _message, vbCritical)
        '    End If
        'End Sub
        ''' <summary>
        '''справочник Допрепарация подробно
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property RePrepDetailsList As List(Of customEntity)
            Get
                If Not Me.oUserEntityList.ContainsKey("Допрепарация") Then Me.GetEntityOfUserListByNameAsTrilbone("Допрепарация")
                Return Me.oUserEntityList.Item("Допрепарация")
            End Get
        End Property

        ''' <summary>
        ''' вернет списание для данного склада
        ''' </summary>
        ''' <param name="WareUUID"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetLossByWarehouseUUID(WareUUID As String) As loss

            Dim _res = (From c In oWorkLosses Where c.sourceStoreUuid = WareUUID Select c).ToList

            If _res.Count > 0 Then Return _res(0)

            MsgBox("Внутренняя ошибка! Не найдено списание для склада " & Me.GetWarehouseByUUID(WareUUID).name, vbCritical)
            Return Nothing


            'For i = 0 To Me.oWarehouseList.Count - 1
            '    If Me.oWarehouseList(i).uuid = WareUUID Then
            '        If oWorkLosses.Count >= i + 1 Then
            '            Return oWorkLosses(i)
            '        End If
            '    End If
            'Next
            'Return Nothing
        End Function

        Private oGroupList As List(Of goodFolder)

        ''' <summary>
        ''' список групп товаров МС
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property GroupList As List(Of goodFolder)
            Get
                If oGroupList Is Nothing OrElse oGroupList.Count = 0 Then
                    'запрос
                    Me.oGroupList = New List(Of goodFolder)
                    'добавить пустой проект
                    Dim _em = New goodFolder
                    With _em
                        .uuid = ""
                        .name = ""
                    End With
                    Me.oGroupList.Add(_em)
                    Dim _message As String = ""

                    If Not Me.RequestAnyCollection(Of goodFolder)(Me.oGroupList, "", emMoySkladFilterTypes.empty, _message) Then
                        MsgBox(_message, vbCritical)
                    End If
                End If
                Return oGroupList
            End Get
        End Property

        ''' <summary>
        ''' вернет список складов (ACL включено)
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property WarehouseList As List(Of warehouse)
            Get
                Dim _accessNames As New List(Of String)

                If Not Service.clsApplicationTypes.CurrentUser Is Nothing Then
                    _accessNames = Service.clsApplicationTypes.CurrentUser.UserPermission.GetAccessListByProductName("moysklad.warehouse")
                Else
                    _accessNames.Add("Внутренний Питер")
                    _accessNames.Add("Внутренний Нарва")
                End If

                'фильтр по доступу
                oWarehouseList = oWarehouseList.Where(Function(x) _accessNames.Contains(x.name)).ToList

                Return oWarehouseList
            End Get
        End Property

        ''' <summary>
        ''' список ячеек склада
        ''' </summary>
        ''' <param name="WarehouseUUID"></param>
        ''' <returns></returns>
        Public ReadOnly Property SlotList(WarehouseUUID As String) As List(Of slot)
            Get
                Dim _ware = Me.GetWarehouseByUUID(WarehouseUUID)
                If Not _ware Is Nothing Then
                    Return _ware.slots.ToList
                End If
                Return New List(Of slot)
            End Get
        End Property



        ' ''' <summary>
        ' ''' вернет список ид складов
        ' ''' </summary>
        ' ''' <value></value>
        ' ''' <returns></returns>
        ' ''' <remarks></remarks>
        'Public ReadOnly Property WarehouseUUIDlist As List(Of String)
        '    Get
        '        Dim _res = From c In oWarehouseList Select c.uuid

        '        Return _res.ToList
        '    End Get
        'End Property


        Public ReadOnly Property AuctionList As Object
            Get
                'список аукционов
                Dim _tmp() = {New With {.name = "eBay", .uuid = "2bf72248-e5f8-11e3-09b2-002590a28eca", .metuuid = "27bbe108-e5f1-11e3-4185-002590a28eca"}, New With {.name = "Молоток", .uuid = "2bf71877-e5f8-11e3-497f-002590a28eca", .metuuid = "a0df7210-e5f1-11e3-daf7-002590a28eca"}, New With {.name = "сайт", .uuid = "2bf713c4-e5f8-11e3-4671-002590a28eca", .metuuid = "a0df74e7-e5f1-11e3-a6d4-002590a28eca"}}
                Return _tmp
            End Get
        End Property

        Private oWorkEnters As New List(Of enter)

        ''' <summary>
        ''' доступные приложению оприходования
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property EnterList As List(Of enter)
            Get
                Return oWorkEnters
            End Get
        End Property

        ''' <summary>
        ''' доступные списания
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property LossList As List(Of loss)
            Get
                Return oWorkLosses
            End Get
        End Property

        ''' <summary>
        ''' ищем местоположения товар их сервисом. good должен хоть что-то)) (ACL включено)
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function FindLocationOfGood(ByVal good As good, Optional IncludeReserved As Boolean = False) As List(Of clsGoodLocation)
            If (good Is Nothing OrElse good.uuid = "") And good.code = "" And good.productCode = "" And good.name = "" Then
                Return New List(Of clsGoodLocation)
            End If
            Dim _foundgoods As New List(Of good)
            If good Is Nothing OrElse good.uuid = "" Then
                'найти UUID
                Select Case Me.FindGoods(good.code, good.productCode, good.name, _foundgoods)
                    Case Is < 0
                        'ошибка
                        Return New List(Of clsGoodLocation)
                    Case 0
                        'товар не найден
                        Return New List(Of clsGoodLocation)
                End Select
            Else
                _foundgoods.Add(good)
            End If

            Dim _foundresult As New List(Of clsGoodLocation)

            For Each _findGood In _foundgoods
                Dim findGood = _findGood
                Dim _dataStokTO As IEnumerable(Of Object) = Nothing
                Dim _data As IEnumerable(Of Object) = Nothing
                Dim _ServerMessage As String = ""
                Dim _stokMode As emStockMode
                If IncludeReserved Then
                    _stokMode = emStockMode.POSITIVE_INCLUDING_RESERVE_ONLY
                Else
                    _stokMode = emStockMode.POSITIVE_ONLY
                End If
                '----------------------------
                Dim _respond As String = ""
                '1 найдем склад
                Dim _requestStatus = Me.RequestAnyCollection(TOobjectType:=emTOMoySkladTypes.stockTO, _data:=_dataStokTO, goodUUID:={findGood.uuid}, ServerMessage:=_ServerMessage, GoodNamePart:="", StockMode:=_stokMode, WarehouseUUID:="", _requestbody:="")
                Select Case _requestStatus
                    Case Net.HttpStatusCode.OK
                        'изменено 31.03.2015 = добавлено условие And (c.quantity > 0 Or c.reserve > 0)
                        Dim _stokTOcollection = (From c As SerialObj.stockTO In _dataStokTO Where c.goodRef.uuid = (findGood.uuid) And (c.quantity > 0 Or c.reserve > 0) Select c).ToList
                        If _stokTOcollection.Count = 0 Then
                            'не найден
                            Return _foundresult
                        End If
                        '=========================
                        'если мы сдесь, то товар найден, пересмотрим все склады
                        'тут тонкое место 14 запросов!!! - надо сделать запрос по складам
                        Dim _reqCount As Integer = 0
                        For Each _wr In Me.WarehouseList
                            Dim _wareUUID As String = _wr.uuid
                            '2 найдем ячейки
                            _reqCount += 1
                            _dataStokTO = Nothing
                            _ServerMessage = ""
                            _requestStatus = Me.RequestAnyCollection(clsMoyScladManager.emTOMoySkladTypes.slotStateReportTO, _dataStokTO, _wareUUID, {findGood.uuid}, , , _ServerMessage, "")
                            Select Case _requestStatus
                                Case Net.HttpStatusCode.OK
                                    If _dataStokTO.Count = 0 Then GoTo nx
                                    'теперь добавим слоты в класс
                                    'тут проблема - этот запрос дает не всегда верные результаты, или проблема в запросе на сервер??
                                    'фильтр Where b = _wareUUID отсекает повтор склада
                                    'c.quantity > 0 отсекает положения с нулевым кол-вом
                                    Dim _slotToCollection = (From c As SerialObj.slotStateReportTO In _dataStokTO Where (Not c.goodRef.uuid Is Nothing) AndAlso c.goodRef.uuid = (findGood.uuid) AndAlso c.warehouseRef.uuid = _wareUUID AndAlso c.quantity > 0 Select c).ToList

                                    If _slotToCollection.Count > 0 Then
                                        'сгруппируем по складам
                                        Dim _tmpslotToCollection = _slotToCollection
                                        'получим обьекты
                                        Dim _goodLocationCollection = (From c As SerialObj.slotStateReportTO In _tmpslotToCollection Let b = c.warehouseRef.uuid Let ab As clsGoodLocation = Nothing Group c By b Into Group Select ab = New clsGoodLocation(findGood, b) _
                                       With {.SlotGood = (Group.Select(Function(x)
                                                                           Dim _new = New clsGoodLocation.clsSlot(x.quantity, _wareUUID, x.slotRef.uuid)
                                                                           _new.UomName = x.uomName
                                                                           Return _new
                                                                       End Function)).ToList}).ToList

                                        'добавим в выход
                                        If _goodLocationCollection.Count > 0 Then
                                            'установить связь и флаг возможной резервации
                                            For Each _goodLocation In _goodLocationCollection
                                                For Each c In _goodLocation.SlotGood
                                                    c.Parent = _goodLocation
                                                    'для запросов, включающих резервы
                                                    If _stokMode = emStockMode.POSITIVE_INCLUDING_RESERVE_ONLY Then
                                                        'правильно ли запрашиваем первый результат???
                                                        Dim _askitem = _stokTOcollection(0)
                                                        If _askitem.reserveSpecified And _askitem.reserve > 0 Then
                                                            'есть резервация
                                                            c.ReserveIncluding = True
                                                            c.ReservedQty = _askitem.reserve
                                                        Else
                                                            'резерва нет
                                                            c.ReserveIncluding = False
                                                            c.ReservedQty = 0
                                                        End If
                                                        'Dim _dataStokTO2 As IEnumerable(Of Object) = Nothing
                                                        ''повторный запрос БЕЗ запроса резерва для КОНКРЕТНОГО склада
                                                        'Dim _request2Status = Me.RequestAnyCollection(TOobjectType:=emTOMoySkladTypes.stockTO, _data:=_dataStokTO2, goodUUID:={findGood.uuid}, ServerMessage:=_ServerMessage, GoodNamePart:="", StockMode:=emStockMode.POSITIVE_ONLY, WarehouseUUID:=_goodLocation.WarehouseUUID, _requestbody:="")
                                                        'Select Case _request2Status
                                                        '    Case Net.HttpStatusCode.OK
                                                        '        Dim _stokToCollection2 = (From d As SerialObj.stockTO In _dataStokTO2 Where d.goodRef.uuid = (findGood.uuid) Select d).ToList
                                                        '        If Not _stokToCollection2.Count = _stokTOcollection.Count Then
                                                        '            'кол-ва отличаются в запросе БЕЗ резерва, значит часть зарезервирована
                                                        '            c.ReserveIncluding = True
                                                        '            c.ReservedQty = _stokTOcollection.Count - _stokToCollection2.Count
                                                        '        Else
                                                        '            'кол-ва равны, значит резерва нет
                                                        '            c.ReserveIncluding = False
                                                        '            c.ReservedQty = 0
                                                        '        End If
                                                        'End Select
                                                    End If
                                                Next
                                            Next
                                            _foundresult.AddRange(_goodLocationCollection)
                                        End If
                                    End If
                            End Select
nx:
                        Next
                        ''
                    Case Net.HttpStatusCode.NotFound
                        Return _foundresult
                    Case Else
                        'ошибка
                        MsgBox("Сервер выдал ошибку при поиске на складе: " & _ServerMessage, vbCritical)
                        Return _foundresult
                End Select
            Next

            ''загрузим обьекты
            For Each t In _foundresult
                t.LoadObjects(Me)
            Next
            Return _foundresult
        End Function


        ''' <summary>
        ''' вернет ид склада по части имени или ничего
        ''' </summary>
        ''' <param name="name"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetWarehousUUIDbyName(name As String) As String
            Dim _res = From c In oWarehouseList Where c.name.ToLower.Contains(name.ToLower) Select c.uuid
            Return _res.FirstOrDefault
        End Function
        ''' <summary>
        ''' вернет имя ед.изм. 
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetUomByUUID(UUID As String) As strUom
            Dim _res = From c In Me.UomList Where c.uuid.Equals(UUID) Select c
            Return _res.FirstOrDefault
        End Function
        ''' <summary>
        ''' вернет UUID ед.измерения или Nothing
        ''' </summary>
        ''' <param name="Name"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetUomUUIDByName(Name As String) As String
            Dim _res = From c In Me.UomList Where c.name.ToLower.Equals(Name.ToLower) Select c.uuid
            Return _res.FirstOrDefault
        End Function


        ''' <summary>
        ''' вернет список ячеек на складе
        ''' </summary>
        ''' <param name="WarehouseUUID"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetSlotListByWarehouseUUID(WarehouseUUID As String) As List(Of slot)
            Dim _new As New List(Of slot)
            Dim _res = From c In oWarehouseList Where String.Equals(c.uuid, WarehouseUUID) Select c
            If _res.Count = 0 Then Return _new
            _new.AddRange(_res(0).slots)
            Return _new
        End Function

        ''' <summary>
        ''' вернет ячейку склада
        ''' </summary>
        ''' <param name="WarehouseUUID"></param>
        ''' <param name="slotUUID"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetSlotByUUID(WarehouseUUID As String, slotUUID As String) As slot
            Dim _sl = GetSlotListByWarehouseUUID(WarehouseUUID)
            Dim _res = From c In _sl Where String.Equals(c.uuid, slotUUID) Select c
            Return _res.FirstOrDefault
        End Function

        Public Function GetSlotUUIDByName(WarehouseUUID As String, slotName As String) As String
            If String.IsNullOrWhiteSpace(slotName) Then Return ""
            Dim _sl = GetSlotListByWarehouseUUID(WarehouseUUID)
            Dim _res = From c In _sl Where String.Equals(c.name, slotName) Select c.uuid
            Return _res.FirstOrDefault
        End Function

        Friend Function GetCustomerByUUID(UUID As String) As company
            Dim _res = From c In Me.CustomerList(False) Where c.uuid.Equals(UUID) Select c
            Return _res.FirstOrDefault
        End Function

        Friend Function GetProjectByUUID(UUID As String) As project
            Dim _res = From c In Me.ProjectList(False) Where c.uuid.Equals(UUID) Select c
            Return _res.FirstOrDefault
        End Function

        Friend Function GetCompanyByUUID(UUID As String) As myCompany
            Dim _res = From c In Me.CompanyList(False) Where c.uuid.Equals(UUID) Select c
            Return _res.FirstOrDefault
        End Function
        Friend Function GetCompanyByName(Name As String) As iMoySkladDataProvider.clsEntity
            Dim _res = From c In Me.CompanyList(False) Where c.name.ToLower.Equals(Name.ToLower) Select c
            Return _res.FirstOrDefault.GetTrilboneItem
        End Function


        Friend Function GetProjectByName(name As String) As project
            Dim _res = From c In Me.ProjectList(False) Where c.name.ToLower.Equals(name.ToLower) Select c
            Return _res.FirstOrDefault
        End Function

        Public Function GetCurrencyByUUID(CurrencyUUID As String) As MoySkladAPI.currency
            If CurrencyUUID Is Nothing Then Return New MoySkladAPI.currency
            Dim _res = (From c In Me.CurrencyList Where String.Equals(c.uuid, CurrencyUUID) Select c).FirstOrDefault
            Return _res
        End Function

        Public Function GetCurrencyUUIDByName(currencyName As String) As String
            If currencyName Is Nothing Then Return Nothing
            Dim _res = From c In Me.CurrencyList Where String.Equals(c.name.ToLower, currencyName.ToLower) Select c.uuid
            Return _res.FirstOrDefault
        End Function

        ''' <summary>
        ''' вернет список обектов по части названия. слова запрашиваются с И
        ''' </summary>
        ''' <param name="Name"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function RequestGoodCollectionByName(Name As String) As List(Of good)
            'Dim _return = New List(Of clsMSGood)
            'Dim _arr = Name.Split(" ")
            'If _arr.Count = 0 Then Return _return

            'Dim _search2 As String = ""
            'Dim _search = _arr(0)
            'If _arr.Count > 1 Then
            '    _search2 = _arr(1)
            'End If
            Dim _message As String = ""
            Dim _status As Integer = 0

            Dim _goodColl = Me.RequestAllGoods(Name, _message, _status)

            If _status < 0 Then
                MsgBox(_message, vbCritical)
                Return New List(Of good)
            End If

            Return _goodColl

            'If _goodColl.Count = 0 Then Return New List(Of good)
            ''выдает только 1000 запросов - поддержка!!!
            'For Each t As good In _goodColl
            '    Dim _new = New clsMSGood With {.Good = t}
            '    _return.Add(_new)

            '    ''встроенная фильтрация
            '    'If _new.NameContains(_search) Then
            '    '    _return.Add(_new)
            '    'ElseIf Not _search2 = "" Then
            '    '    If _new.NameContains(_search2) Then
            '    '        _return.Add(_new)
            '    '    End If
            '    'End If
            'Next
            'Return _return
        End Function

        ''' <summary>
        ''' вернет структуру с описанием образа.
        ''' </summary>
        ''' <param name="uuid"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Friend Function GetGoodInfoByUUID(uuid As String) As clsApplicationTypes.clsSampleNumber.strGoodInfo
            Dim _out As New List(Of clsMSGood)
            Dim _status As System.Net.HttpStatusCode
            Dim _result As IEnumerable(Of Object) = Nothing
            Dim _message As String = ""
            _status = Me.RequestAnyCollection(clsMoyScladManager.emMoySkladObjectTypes.Good, _result, uuid, clsMoyScladManager.emMoySkladFilterTypes.uuid, _message)
            If _status = Net.HttpStatusCode.OK Then
                'найден
                For Each t As good In _result
                    _out.Add(clsMSGood.CreateInstance(t))
                Next
                Return Me.GetGoodInfo(_out.FirstOrDefault)
            ElseIf _status = Net.HttpStatusCode.NotFound Then
                'не найден
                Return Nothing
            Else
                'ошибка
                Return Nothing
            End If

        End Function

        ''' <summary>
        ''' вернет структуру с описанием образа. Code - код, артикул
        ''' </summary>
        ''' <param name="code"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Friend Function GetGoodInfo(code As String) As List(Of Service.clsApplicationTypes.clsSampleNumber.strGoodInfo)
            Dim _outstr = New List(Of Service.clsApplicationTypes.clsSampleNumber.strGoodInfo) ' With {.LoadStatus = 0}

            If code = "" Then Return _outstr

            Dim _result As IEnumerable(Of Object) = Nothing
            Dim _message As String = ""
            Dim _out As New List(Of clsMSGood)
            Dim _status As System.Net.HttpStatusCode
            Dim _foundFlag As Boolean = False

            _status = Me.RequestAnyCollection(clsMoyScladManager.emMoySkladObjectTypes.Good, _result, code, clsMoyScladManager.emMoySkladFilterTypes.code, _message)
            If _status = Net.HttpStatusCode.OK Then
                'найден
                For Each t As good In _result
                    _out.Add(clsMSGood.CreateInstance(t))
                Next
                _foundFlag = True
            ElseIf _status = Net.HttpStatusCode.NotFound Then
                'не найден
                _foundFlag = False
            Else
                'ошибка
                Return _outstr
            End If



            ' ищем по артикулу
            _status = Me.RequestAnyCollection(clsMoyScladManager.emMoySkladObjectTypes.Good, _result, code, clsMoyScladManager.emMoySkladFilterTypes.productCode, _message)
            If _status = Net.HttpStatusCode.OK Then

                'найден
                For Each t As good In _result
                    _out.Add(clsMSGood.CreateInstance(t))
                Next
                _foundFlag = True
            ElseIf _status = Net.HttpStatusCode.NotFound Then
                'не найден
                _foundFlag = False
            Else
                'ошибка
                Return _outstr
            End If
            If _out.Count = 0 Then Return _outstr
            'тут надо заполнить поля
            For Each _good In _out
                _outstr.Add(GetGoodInfo(_good))
            Next
            Return _outstr
        End Function

        ''' <summary>
        ''' формирует описатель
        ''' </summary>
        ''' <param name="_good"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function GetGoodInfo(_good As clsMSGood) As clsApplicationTypes.clsSampleNumber.strGoodInfo
            Dim _goodstr = New Service.clsApplicationTypes.clsSampleNumber.strGoodInfo
            If _good Is Nothing Then Return Nothing
            With _goodstr
                '-------------------------
                'функция обновления
                Dim _fnUpdate = Function(inbuyPrice As Decimal, buyCurrencyName As String, insalePrice As Decimal, saleCurrencyName As String, specificPrice As Decimal, specificPriceCurrencyName As String, specificPriceName As String, uomName As String, ingoodname As String, goodweight As Decimal) As String
                                    Return Me.UpdateGoodPrice(_good.Good, inbuyPrice, buyCurrencyName, insalePrice, saleCurrencyName, uomName, ingoodname, goodweight)
                                End Function
                'функция обновления
                .updateGoodDelegate = _fnUpdate

                '-------------------
                'функция запроса расположения
                'переменная для хранения ячеек складов
                Dim _slotName As New List(Of String())
                Dim _wareName As New List(Of String)
                Dim _fnLocate = Function(emp As Service.clsApplicationTypes.clsSampleNumber.strGoodInfo) As String()
                                    'включая зарезервированные
                                    _good.FindLocations(Me, True)
                                    If _good.Locations.Count > 0 Then
                                        Dim _slotString As New List(Of String)
                                        For Each t In _good.Locations
                                            For Each t1 In t.SlotGood
                                                'запись в массиве расположений
                                                _slotString.Add(t1.SlotString)
                                                'соответствует записи в массиве ячеек
                                                Dim _sl = GetSlotListByWarehouseUUID(t1.WarehouseUUID).Select(Function(x) x.name).ToArray
                                                _slotName.Add(_sl)
                                                'соответствует записи в массиве складов
                                                _wareName.Add(t1.EWarehouse.name)
                                            Next
                                        Next
                                        emp.goodSlotInfo = _slotName
                                        emp.goodWareInfo = _wareName
                                        Return _slotString.ToArray
                                    Else
                                        Return {"Нет на складах"}
                                    End If
                                End Function
                'функция запроса расположения
                .goodLocationInfo = _fnLocate
                '---------------------
                'функция размещения в ячейку
                Dim _fnPlaceToSlot = Function(targetSlotName As String, TargetWareName As String) As String
                                         Dim _targetWareUUID = Me.GetWarehousUUIDbyName(TargetWareName)
                                         Dim _targetslotUUID = Me.GetSlotUUIDByName(_targetWareUUID, targetSlotName)
                                         Dim _res = _good.Locations.SelectMany(Function(x) x.GetGoodQty)

                                         Dim _take = _res.Where(Function(x) x.WareUUID = _targetWareUUID And x.Qty > 0)
                                         If _take.Count = 0 Then
                                             Return "Не удалось найти склад-источник товара с ненулевым количеством"
                                         End If
                                         'взять первое расположение товара
                                         Dim _goo = _take(0)
                                         _goo.NewSlotName = _targetslotUUID
                                         Dim _rout = Me.CreateMove(_take(0).WareUUID, _targetWareUUID, {_goo}).name
                                         Return _rout
                                     End Function
                .goodToSlot = _fnPlaceToSlot
                '---------------------

                .goodXML = mdMoySkladExtentions.clsMSObjectReader(Of good).GetXML(_good.Good)
                .AsPosition = _good.Good.GetPositionTrilbone(Me)
                .Articul = _good.Articul
                .UUID = _good.UUID
                .Code = _good.Code
                .Name = _good.Name
                .Updated = _good.UpdatedDate
                .UpdatedBy = _good.UpdatedWoker
                .UomName = Me.GetUomByUUID(_good.Good.uomUuid).name
                .Weight = _good.Weight
                'retail prices
                If _good.Good.salePriceSpecified = True Then
                    'указать розницу
                    .RetailPrice = _good.Good.salePrice / 100
                    .RetailCurrency = Me.GetCurrencyByUUID(_good.Good.saleCurrencyUuid).name
                End If
                'закупка
                If _good.Good.buyPriceSpecified = True Then
                    .BuyPrice = _good.Good.buyPrice / 100
                    .BuyCurrency = Me.GetCurrencyByUUID(_good.Good.buyCurrencyUuid).name
                End If



                'инвойс
                Dim _pr = _good.Good.GetPriceByType(Me, iMoySkladDataProvider.emPriceType.Invoce)
                If Not _pr Is Nothing Then
                    .InvocePrice = _pr.value / 100
                    .InvoceCurrency = Me.GetCurrencyByUUID(_pr.currencyUuid).name
                End If
                'цена ебай
                _pr = _good.Good.GetPriceByType(Me, iMoySkladDataProvider.emPriceType.Ebay)
                If Not _pr Is Nothing Then
                    .eBayPrice = _pr.value / 100
                    .eBayCurrecy = Me.GetCurrencyByUUID(_pr.currencyUuid).name
                End If
                .LoadStatus = 1
            End With
            Return _goodstr
        End Function

        ''' <summary>
        ''' ищет товары в справочнике по коду, артикулу или части имени. Переставляет код/артикул. / Вернет -1=error * 0=not found * 1 and more=found
        ''' </summary>
        ''' <param name="ShotCode"></param>
        ''' <param name="FoundGoods"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overloads Function FindGoods(ShotCode As String, ShotArticul As String, PartOfName As String, ByRef FoundGoods As List(Of good)) As Integer
            Dim _status As Integer
            Dim _result = Me.FindGoods(New good With {.code = ShotCode, .productCode = ShotArticul, .name = PartOfName}, _status)

            'защита от ошибок
            If (_result Is Nothing OrElse _result.Count = 0) AndAlso _status >= 0 Then _status = 0

            FoundGoods = _result
            Return _status
        End Function

        ''' <summary>
        '''ищет товары в справочнике, используя поля Code (код), ProductCode (артикул) или Name (как часть имени, если не указан код или артикул) переданного обьекта. Другие поля обьекта можно не указывать.  / SearchStatus -1=error * 0=not found * 1 and more=found
        ''' </summary>
        ''' <param name="good"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Overloads Function FindGoods(good As good, ByRef SearchStatus As Integer) As List(Of good)
            Dim _result As IEnumerable(Of Object) = Nothing
            Dim _message As String = ""
            Dim _out As New List(Of good)
            Dim _status As System.Net.HttpStatusCode
            '--------------------
            Dim _foundFlag As Boolean = False
            '-------------------------
backsearch:
            _foundFlag = False
            '----------------
            'поиск по штрих-коду - перенесен в вызывающую процедуру
            '-----------------------------
            'функция поиска
            'вернет -1 = ошибка, 0= не найден, >1 кол-во найденого
            Dim _fnSearch = Function(_number As String, filterType As clsMoyScladManager.emMoySkladFilterTypes, ByRef usermessage As String) As Integer

                                _status = Me.RequestAnyCollection(clsMoyScladManager.emMoySkladObjectTypes.Good, _result, _number, filterType, usermessage)
                                If _status = Net.HttpStatusCode.OK Then
                                    'найден
                                    Dim _obj = _result.Cast(Of good)().ToList
                                    If _obj.Count = 0 Then Return 0
                                    _out.AddRange(_obj)
                                    Return _result.Count
                                ElseIf _status = Net.HttpStatusCode.NotFound Then
                                    Return 0
                                Else
                                    Return -1
                                End If
                            End Function
            '---------------------
            'поиск по коду
            _foundFlag = False
            If Not good.code = "" Then
                Select Case _fnSearch.Invoke(good.code, clsMoyScladManager.emMoySkladFilterTypes.code, _message)
                    Case -1
                        MsgBox("Ошибка запроса товара: " & _message, vbCritical)
                    Case 0
                        'не найден
                        'не найден - перенесем код в артикул
                        If good.productCode = "" Then
                            good.productCode = good.code
                            good.code = ""
                        End If

                        If Not good.productCode = "" Then
                            Select Case _fnSearch.Invoke(good.productCode, clsMoyScladManager.emMoySkladFilterTypes.productCode, _message)
                                Case -1
                                    MsgBox("Ошибка запроса товара: " & _message, vbCritical)
                                Case 0
                                    'не найден
                                Case Is > 0
                                    'найден
                                    _foundFlag = True
                            End Select
                        Else
                            'по коду не найден, поле артикула пустое. Ошибка? Код должен был быть перенесен в артикул
                            Debug.Fail("по коду не найден, поле артикула пустое. Ошибка? Код должен был быть перенесен в артикул")
                        End If

                    Case Is > 0
                        'найден
                        _foundFlag = True
                End Select
            Else
                'поле кода пустое - ищем по артикулу
                If Not good.productCode = "" Then
                    Select Case _fnSearch.Invoke(good.productCode, clsMoyScladManager.emMoySkladFilterTypes.productCode, _message)
                        Case -1
                            MsgBox("Ошибка запроса товара: " & _message, vbCritical)
                            SearchStatus = -2
                            Return _out
                        Case 0
                            'не найден
                            'не найден - перенесем  артикул в код
                            If good.code = "" Then
                                good.code = good.productCode
                                good.productCode = ""
                            End If
                            If Not good.code = "" Then
                                Select Case _fnSearch.Invoke(good.code, clsMoyScladManager.emMoySkladFilterTypes.code, _message)
                                    Case -1
                                        MsgBox("Ошибка запроса товара: " & _message, vbCritical)
                                        SearchStatus = -2
                                        Return _out
                                    Case 0
                                        'не найден
                                    Case Is > 0
                                        'найден
                                        _foundFlag = True
                                End Select
                            End If
                        Case Is > 0
                            'найден
                            _foundFlag = True
                    End Select
                Else
                    'два пустых поля - код и артикул. Ищем по имени.
                    ' Debug.Fail("в запрашиваемом товаре два пустых поля - код и артикул. Ошибка логики. Нажмите Пропустить.")
                    'MsgBox("Следует указать артикул или номер товара!", vbCritical)
                    'SearchStatus = -2
                    'Return _out
                End If
            End If

            '---------------------
            'поиск по имени
            If (Not good.name = "") And (good.code = "") And (good.productCode = "") Then
                'Поле имя-не пустое=ищем по части имени
                Select Case _foundFlag
                    Case False
                        '
                        Dim _res = Me.RequestGoodCollectionByName(good.name)
                        If _res.Count > 0 Then
                            _out.AddRange(_res)
                            _foundFlag = True
                        End If
                    Case Else
                        'внутренний фильтр
                        _out = (From c In _out Where c.name.Contains(good.name) = True Select c).ToList
                End Select
            Else
                'три пустых поля - код и артикул и имя.
                If (good.code = "") And (good.productCode = "") Then
                    Debug.Fail("в запрашиваемом товаре три пустых поля - код, артикул и имя. Ошибка логики. Нажмите Пропустить.")
                    'MsgBox("Следует указать артикул или номер товара!", vbCritical)
                    SearchStatus = -2
                    Return _out
                End If
            End If


            ''--------------

            If Not _foundFlag Then
                SearchStatus = 0
                Return _out
            End If

            If _foundFlag And (_out.Count > 0) Then
                'товар найден
                SearchStatus = _out.Count
                Return _out
            Else
                'ошибка - товар типа найден, но в коллекцию Не добавлен
                Debug.Fail("ошибка - товар типа найден, но в коллекцию Не добавлен")
                MsgBox("Ошибка - возможно, товар есть в базе. Повторите запрос по коду и(или) артикулу", vbCritical)
                SearchStatus = -1
                Return _out
            End If


            Return _out

        End Function


        ''' <summary>
        ''' Найти размещение товара на определенном складе
        ''' </summary>
        ''' <param name="gooduuid"></param>
        ''' <param name="warehouseUUID"></param>
        ''' <returns></returns>
        Public Function FindCellsForGood(gooduuid As String, warehouseUUID As String, Optional IncludeReserved As Boolean = False) As List(Of iMoySkladDataProvider.strGoodMapQty)

            Dim _ServerMessage As String = ""
            Dim _dataOut As IEnumerable(Of Object) = Nothing

            Dim _req = Me.RequestAnyCollection(TOobjectType:=emTOMoySkladTypes.slotStateReportTO, _data:=_dataOut, WarehouseUUID:=warehouseUUID, goodUUID:={gooduuid}, GoodNamePart:="", StockMode:=If(IncludeReserved, emStockMode.POSITIVE_INCLUDING_RESERVE_ONLY, emStockMode.POSITIVE_ONLY), ServerMessage:="", _requestbody:="")

            Select Case _req
                Case Net.HttpStatusCode.OK
                    Dim _slotCollection = (From c As SerialObj.slotStateReportTO In _dataOut Where c.quantity > 0 Select c.GetGoodQty).ToList
                    Return _slotCollection
            End Select

            Return New List(Of iMoySkladDataProvider.strGoodMapQty)
        End Function



        ''' <summary>
        ''' вернет все товары POSITIVE_INCLUDING_RESERVE_ONLY. status -1 = ошибка, иначе кол-во товаров
        ''' </summary>
        ''' <param name="message"></param>
        ''' <param name="status"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function RequestAllGoods(NamePart As String, ByRef message As String, ByRef status As Integer) As List(Of good)
            Dim _out = New List(Of good)
            Dim _result As IEnumerable(Of Object) = Nothing

            Dim _status = Me.RequestAnyCollection(TOobjectType:=emTOMoySkladTypes.stockTO, GoodNamePart:=NamePart, _data:=_result, _requestbody:="", ServerMessage:=message, WarehouseUUID:="", StockMode:=emStockMode.POSITIVE_INCLUDING_RESERVE_ONLY, goodUUID:={})
            If _status = Net.HttpStatusCode.OK Then
                status = _result.Count
                If _result.Count = 0 Then Return _out
                Dim _stok = _result.Cast(Of stockTO)().ToList

                For Each t In _stok
                    _out.Add(Me.RequestGoodByUUID(t.goodRef.uuid))
                Next

                Return _out
            ElseIf Not _status = Net.HttpStatusCode.NotFound Then
                status = -1
                Return _out
            Else
                status = -1
                Return _out
            End If
        End Function
        ''' <summary>
        ''' обновляет цену, название и ед.изм. товара
        ''' </summary>
        ''' <param name="goodToUpdate"></param>
        ''' <param name="inbuyPrice"></param>
        ''' <param name="buyCurrencyName"></param>
        ''' <param name="insalePrice"></param>
        ''' <param name="saleCurrencyName"></param>
        ''' <param name="uomName"></param>
        ''' <param name="ingoodname"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Friend Function UpdateGoodPrice(goodToUpdate As good, inbuyPrice As Decimal, buyCurrencyName As String, insalePrice As Decimal, saleCurrencyName As String, uomName As String, ingoodname As String, goodweight As Decimal, Optional Prices As List(Of iMoySkladDataProvider.strPrices) = Nothing) As String

            With goodToUpdate
                'название
                If ingoodname Is Nothing Then ingoodname = ""
                If Not ingoodname = "" Then
                    .name = ingoodname
                End If

                'цена закупки
                If (Not inbuyPrice = 0) And (Not buyCurrencyName = "") Then
                    .SetPriceByType(Me, iMoySkladDataProvider.emPriceType.BuyPrice, inbuyPrice, buyCurrencyName)
                End If

                'цена продажи (розница)
                If (Not insalePrice = 0) And (Not saleCurrencyName = "") Then
                    .SetRetailPrice(Me, insalePrice, saleCurrencyName)
                End If

                'ед.изм.
                If Not uomName = "" Then
                    Dim _uomuuid = Me.GetUomUUIDByName(uomName)
                    If Not _uomuuid Is Nothing Then
                        .uomUuid = _uomuuid
                    End If
                End If

                'по умолчанию поставим шт
                If .uomUuid Is Nothing OrElse .uomUuid = "" Then
                    .uomUuid = Me.GetUomUUIDByName("шт")
                End If

                'вес в кг
                If Not goodweight = 0 Then
                    .weight = goodweight
                End If

                'цены
                If Not Prices Is Nothing Then
                    For Each inpr In Prices
                        goodToUpdate.SetPriceByType(Me, inpr.PriceType, inpr.value, inpr.BaseCurrency)
                    Next
                End If

            End With

            Dim _new As RestMS_Client.MoySkladAPI.good = Nothing
            Dim _smessage As String = ""
            Select Case Me.AddGoodToServer(goodToUpdate, _new, _smessage)
                Case Net.HttpStatusCode.OK
                    If Not _new Is Nothing Then
                        Return ("Товар успешно обновлен! Проверить можно повторным запросом.")

                    End If
            End Select
            Return ("При обновлении товара возникла ошибка: " & _smessage)
        End Function


        Public Function ServiceSheckBarCodes() As String
            Dim _message As String = ""
            Dim _status As Integer = 0
            Dim _goodColl = Me.RequestAllGoods("", _message, _status)
            If _goodColl.Count = 0 Then Return _message
            If _status < 0 Then
                MsgBox(_message, vbCritical)
                Return _message
            End If

            _message += ChrW(13)
            Dim _bar As barcode
            Dim _cd As ShotCodeConverter_Net.clsCode
            Dim _changed As Boolean = False
            For Each _g In _goodColl
                _bar = New barcode
                _bar.barcodeType = barcodeType.EAN13
                _bar.barcodeTypeSpecified = True

                If _g.barcode Is Nothing OrElse _g.barcode.Count = 0 Then
                    If Not _g.code = "" Then
                        _cd = ShotCodeConverter_Net.clsCode.CreateInstance(_g.code)
                        If _cd.CodeType = ShotCodeConverter_Net.clsCode.emCodeType.EAN13 Then
                            _bar.barcode = _cd.EAN13
                            _g.barcode = {_bar}
                            _changed = True
                        End If
                    Else
                        If Not _g.productCode = "" Then
                            _cd = ShotCodeConverter_Net.clsCode.CreateInstance(_g.productCode)
                            If _cd.CodeType = ShotCodeConverter_Net.clsCode.emCodeType.EAN13 Then
                                _bar.barcode = _cd.EAN13
                                _g.barcode = {_bar}
                                _changed = True
                            End If
                        End If
                    End If
                Else
                    If Not _g.barcode(0).barcodeType = barcodeType.EAN13 Then
                        _g.barcode(0).barcodeType = barcodeType.EAN13
                        _changed = True
                    End If
                    If Not _g.barcode(0).barcodeTypeSpecified = True Then
                        _g.barcode(0).barcodeTypeSpecified = True
                        _changed = True
                    End If
                    _cd = ShotCodeConverter_Net.clsCode.CreateInstance(_g.code)
                    If _cd.CodeType = ShotCodeConverter_Net.clsCode.emCodeType.EAN13 Then
                        If Not _g.barcode(0).barcode = _cd.EAN13.ToString Then
                            _bar.barcode = _cd.EAN13
                            _g.barcode = {_bar}
                            _changed = True
                        End If
                    Else
                        _cd = ShotCodeConverter_Net.clsCode.CreateInstance(_g.productCode)
                        If Not _g.barcode(0).barcode = _cd.EAN13.ToString Then
                            _bar.barcode = _cd.EAN13
                            _g.barcode = {_bar}
                            _changed = True
                        End If
                    End If


                End If
                If _changed Then
                    Dim _out As String = ""
                    Dim _sm As String = ""
                    Me.AddAnyToServer(emMoySkladObjectTypes.Good, _g, _out, _sm)
                    _message += _sm + ChrW(13)
                    _changed = False
                Else

                End If
            Next

            'refresh
            Return _message

        End Function
        ''' <summary>
        '''Поместить товар в списание (списать) lossgoodUUID = UUID списываемого товара,  LossQty = кол-во списываемого, SlotUUID = ячейка списываемого, 
        ''' </summary>
        ''' <param name="WarehoseUUID"></param>
        ''' <param name="lossgoodUUID"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Friend Function AddLossToServer(WarehoseUUID As String, lossgoodUUID As String, LossQty As Single, SlotUUID As String, oCurrentGood As clsMSGood, ByRef LinkedLoss As loss, ByRef servermessage As String) As Integer
            'списать из этого товара
            Dim _response As String = ""



            'списать со склада выбранной ячейки
            Dim _requuid = GetLossByWarehouseUUID(WarehoseUUID).uuid

            Dim _data As IEnumerable(Of Object) = Nothing
            '------------
            'получить обьект списание
            Dim _q = RequestAnyCollection(clsMoyScladManager.emMoySkladObjectTypes.Loss, _data, _requuid, clsMoyScladManager.emMoySkladFilterTypes.uuid, servermessage)
            Select Case _q
                Case Net.HttpStatusCode.OK
                    If _data.Count = 0 Then
                        ' Global.Service.clsApplicationTypes.BeepNOT()
                        'MsgBox("Ошибка при получении списания с сервера!" & ChrW(13) & servermessage, vbCritical)
                        Return -1
                    End If
                    'ok
                    LinkedLoss = CType(_data(0), loss)

                Case Else
                    'Global.Service.clsApplicationTypes.BeepNOT()
                    'MsgBox("Ошибка при получении списания с сервера! " & ChrW(13) & servermessage, vbCritical)
                    Return -1
            End Select
            '----------------
            'добавить новую позицию в списание 
            Dim _ItemToLoss As New lossPosition
            With _ItemToLoss
                .goodUuid = lossgoodUUID
                .quantity = LossQty

                If Not String.IsNullOrEmpty(.slotUuid) Then
                    .slotUuid = SlotUUID
                End If
                If oCurrentGood.Code = "" Then
                    .tags = {oCurrentGood.TotalQTY & GetUomByUUID(oCurrentGood.Good.uomUuid).name & " .артикул " & oCurrentGood.Articul & " оприходовано " & Now.ToShortDateString}
                Else
                    .tags = {oCurrentGood.TotalQTY & GetUomByUUID(oCurrentGood.Good.uomUuid).name & " .код " & oCurrentGood.Code & " оприходовано " & Now.ToShortDateString}
                End If
            End With
            'изменить списание
            LinkedLoss.moment = Date.Now
            If LinkedLoss.lossPosition Is Nothing Then
                LinkedLoss.lossPosition = {_ItemToLoss}
            Else
                Dim _list = LinkedLoss.lossPosition.ToList
                _list.Add(_ItemToLoss)
                LinkedLoss.lossPosition = _list.ToArray
            End If
            '-------------------
            'списание создать
            Dim _res = AddAnyToServer(clsMoyScladManager.emMoySkladObjectTypes.Loss, LinkedLoss, _response, servermessage)

            Select Case _res
                Case Net.HttpStatusCode.OK
                    Return 1
                Case Else
                    Return -1
            End Select

        End Function


        ''' <summary>
        ''' поместить товар в оприходование (PriceByPosition цена за 1 еденицу товара), вернет кол-во размещенных ед. товара или -1 если ошибка
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Friend Function AddEnterToServer(ByVal enterUUID As String, slotList As List(Of clsGoodLocation.clsSlot), goodUUID As String, ByVal PriceByPosition As Decimal, buyCurrencyUUID As String) As Integer

            If slotList Is Nothing Then
                MsgBox("Ошибка. Не задано место размещения товара = ячейка", vbCritical)
                Return -1
            End If

            'Debug.Assert(Not ToLocation Is Nothing, "необходимо передать непустой обьект назначения")
            'Debug.Assert(Not ToLocation.LinkedEnter Is Nothing, "незагружено привязанное к складу списание")

            '---------------------
            'оприходование 
            'заменить
            Dim _enter As enter = Me.RequestEnterByUUID(enterUUID)
            If _enter Is Nothing Then
                MsgBox("Серьезная ошибка. Не задано целевое оприходование к выбранному складу. Товар не будет оприходован.", vbCritical)
                Return -1
            End If
            '-----------------
            Dim _new As enterPosition
            'валюта оприходования
            Dim _entercurrencyUUID As String = _enter.currencyUuid
            'курс к валюте оприходования
            Dim _enterRate As Decimal = _enter.rate
            'пересчитать в валюту оприходования
            Dim _cur = Me.GetCurrencyByUUID(buyCurrencyUUID)

            If Not _cur Is Nothing Then
                If _entercurrencyUUID = "" Then
                    If Not buyCurrencyUUID = _entercurrencyUUID Then
                        'валюта оприходования не задана - цену надо пересчитать в рубли
                        'считаем курс
                        If Not _cur.name = "RUR" Then
                            PriceByPosition = Math.Round(PriceByPosition * _cur.rate, 2)
                        End If
                    End If
                Else
                    If Not buyCurrencyUUID = _entercurrencyUUID Then
                        'цена передана в валюте, отличной от валюты оприходования, пересчитать в валюту оприходования
                        Dim _rateenter = Me.GetCurrencyByUUID(_entercurrencyUUID).rate
                        Dim _rategood = _cur.rate
                        If Not _rateenter = 0 Then
                            PriceByPosition = Math.Round(_rategood / _rateenter * PriceByPosition, 2)
                        End If

                    End If
                End If
            Else
                'buyCurrencyUUID пуст или некорректен
                PriceByPosition = 0
            End If


            '----------------

            Dim _pos As New List(Of enterPosition)

            If _enter.enterPosition Is Nothing Then
                _enter.enterPosition = _pos.ToArray
            End If

            'сохраним старые позиции в оприходовании
            For Each t In _enter.enterPosition
                _pos.Add(t)
            Next


            'добавим новые позиции
            'найдем ячейку
            'перебираются ячейки, и в каждую добавляем требуемое кол-во
            Dim _count As Decimal = 0

            For Each t In slotList
                If t.Qty > 0 Then
                    _new = New enterPosition
                    With _new
                        'товар
                        .goodUuid = goodUUID
                        'количество
                        .quantity = t.Qty
                        'ячейка
                        If t.SlotUUID = "" Then
                            .slotUuid = Nothing
                        Else
                            .slotUuid = t.SlotUUID
                        End If

                        '---------------
                        Dim _price As New RestMS_Client.MoySkladAPI.moneyAmount
                        If Not _entercurrencyUUID = "" Then
                            _price.sumInCurrency = Math.Round(PriceByPosition, 2)
                            _price.sumInCurrencySpecified = True
                        End If
                        _price.sum = Math.Round(PriceByPosition * _enterRate, 2)
                        _price.sumSpecified = True
                        '-----
                        .price = _price
                        .basePrice = _price
                        .tags = {clsApplicationTypes.CurrentUser.UserShotName & "  " & clsApplicationTypes.GetCurrentTime.ToShortDateString}
                    End With

                    'изменено 24.11.2014, чтобы можно было добавлять позиции по разным ценам закупки
                    'добавим в оприходование
                    _pos.Add(_new)
                    ''если позиция есть, увеличим кол-во
                    'Dim _rq = (From c In _pos Where c.goodUuid = goodUUID Select c).ToList

                    'If _rq.Count > 0 Then
                    '    _rq(0).quantity += t.Qty
                    'Else
                    '    'если ее нет, то добавим в оприходование
                    '    _pos.Add(_new)
                    'End If
                    _count += t.Qty
                End If
            Next
            '------------------------
            'обновит оприходование
            _enter.enterPosition = _pos.ToArray
            'теперь вызовем обновление базы
            Dim _out As String = ""
            Dim _serverMessage As String = ""

            Dim _res2 = Me.AddAnyToServer(emMoySkladObjectTypes.Enter, _enter, _out, _serverMessage)
            Select Case _res2
                Case Net.HttpStatusCode.OK
                    Return _count
                Case Else
                    MsgBox("Не удалось поместить товар в оприходование на сервер", vbCritical)
                    Return -1
            End Select
        End Function
        ''' <summary>
        ''' вернет перечисление по типу
        ''' </summary>
        ''' <typeparam name="T"></typeparam>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function CastToEnumByType(Of T As accountEntity)() As emMoySkladObjectTypes
            Dim _result As emMoySkladObjectTypes
            Dim _name = GetType(T).Name.Split(".").LastOrDefault
            If [Enum].TryParse(Of emMoySkladObjectTypes)(_name, _result) Then
                Return _result
            End If
            MsgBox(String.Format("Не удалось распознать тип {0} перечисления emMoySkladObjectTypes. Полное имя типа {1}", _name, GetType(T).Name), vbCritical)
            Return emMoySkladObjectTypes.Good
        End Function

        Private Overloads Function CastTypeByEnum(ObjectType As emMoySkladObjectTypes) As Type
            Dim _name = "RestMS_Client.MoySkladAPI." & [Enum].GetName(GetType(emMoySkladObjectTypes), ObjectType)
            Dim _out = Type.GetType(_name, False, True)
            If _out Is Nothing Then
                'в перечислении задано имя типа, отсутствующее в сборке
                MsgBox("Ошибка! В перечислении задано имя типа, отсутствующее в сборке, либо изменены пространства имен или имя класса: " & _name, MsgBoxStyle.Critical)
            End If
            Return _out
        End Function


        Private Overloads Function CastTypeByEnum(ObjectType As emTOMoySkladTypes) As Type
            Dim _name = "RestMS_Client.SerialObj." & [Enum].GetName(GetType(emTOMoySkladTypes), ObjectType)
            Dim _out = Type.GetType(_name, False, True)
            If _out Is Nothing Then
                'в перечислении задано имя типа, отсутствующее в сборке
                MsgBox("Ошибка! В перечислении задано имя типа, отсутствующее в сборке, либо изменены пространства имен или имя класса: " & _name, MsgBoxStyle.Critical)
            End If
            Return _out
        End Function

        ''' <summary>
        ''' формирует задержку при запросе МС
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Shared Function RequestIsBusy() As Boolean
            'пока функция просто останавливает поток
            Dim _pause As Integer = clsApplicationTypes.MCpause
            Thread.Sleep(_pause)
            Return True
        End Function


        ''' <summary>
        ''' запросит коллекцию сервисом поиска МС, например /stock/xml
        ''' </summary>
        ''' <param name="TOobjectType">тип поиска</param>
        ''' <param name="_data">найденные обьекты</param>
        ''' <param name="WarehouseUUID">склад</param>
        ''' <param name="goodUUID">массив товаров в stokTO используется первый элемент, в slot используется весь массив</param>
        ''' <param name="GoodNamePart">часть имени товара</param>
        ''' <param name="StockMode">режим поиска в зависимости от остатка</param>
        ''' <param name="ServerMessage">сообщение сервера</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overloads Function RequestAnyCollection(TOobjectType As emTOMoySkladTypes, ByRef _data As IEnumerable(Of Object), WarehouseUUID As String, Optional goodUUID As String() = Nothing, Optional GoodNamePart As String = "", Optional StockMode As emStockMode = emStockMode.POSITIVE_ONLY, Optional ByRef ServerMessage As String = "", Optional ByRef _requestbody As String = "") As System.Net.HttpStatusCode
            Dim _XMLRespond As String = ""

            'преобразователь типов
            Dim T As Type = Me.CastTypeByEnum(TOobjectType)
            If T Is Nothing Then
                'не удалось распознать тип
                ServerMessage = "не удалось распознать тип в перечислении"
                Return Net.HttpStatusCode.BadRequest
            End If

            Dim _out As New List(Of Object)

            Dim _request = RequestAnyCollection(objectType:=TOobjectType, _XMLResponse:=_XMLRespond, storeUUID:=WarehouseUUID, goodUUID:=goodUUID, _statusMessage:=ServerMessage, _requestbody:=_requestbody, GoodNamePart:=GoodNamePart, StockMode:=StockMode)

            Select Case _request
                Case Net.HttpStatusCode.NotFound
                    ServerMessage = "Обьект не найден"
                    '------------------------
                Case Net.HttpStatusCode.OK
                    Dim _status As Integer
                    Dim _cont = CastToContainer(_XMLRespond, _status)
                    If _status > 0 Then
                        'запрос обьекта
                        If _cont.TryGetObjectCollection(_out, T) Then
                            _data = _out
                            RequestIsBusy()
                            Return _request
                        Else
                            'не найден?
                            ServerMessage = "Обьект не найден"
                            RequestIsBusy()
                            Return Net.HttpStatusCode.NotFound
                        End If
                    Else
                        'это не контейнер
                        _out.Clear()
                        Dim _cont1 = ReadXML(_XMLRespond, T)
                        If Not _cont1 Is Nothing Then
                            _out.Add(_cont1)
                            _data = _out
                            RequestIsBusy()
                            Return _request
                        Else
                            'невозможно распознать ответ сервера
                            'ServerMessage = "невозможно распознать ответ сервера"
                            RequestIsBusy()
                            Return Net.HttpStatusCode.BadRequest
                        End If
                    End If


            End Select
            Return _request
        End Function


        ''' <summary>
        ''' НОВАЯ функция запроса
        ''' </summary>
        ''' <typeparam name="T"></typeparam>
        ''' <param name="_data"></param>
        ''' <param name="filterParam"></param>
        ''' <param name="filterType"></param>
        ''' <param name="_message"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overloads Function RequestAnyCollection(Of T As accountEntity)(ByRef _data As IEnumerable(Of T), Optional filterParam As String = "", Optional filterType As emMoySkladFilterTypes = Nothing, Optional ByRef _message As String = "") As Boolean

            Dim _result = Me.RequestAnyCollection(Of T)(_data, filterParam, filterType, _message, "", "")

            Select Case _result
                Case Net.HttpStatusCode.OK
                    If _data.Count > 0 Then
                        'оприходование есть
                        _message = "Ok"
                        Return True
                    Else
                        _message = String.Format("Коллекция {0} пуста", GetType(T).Name.Split(".").FirstOrDefault)
                        Return True
                    End If
                Case Else
                    _message = String.Format("Ошибка при запросе коллекции {0}", GetType(T).Name.Split(".").FirstOrDefault)
                    Return False
            End Select
        End Function


        ''' <summary>
        '''НОВАЯ типизированная версия RequestAnyCollection
        ''' </summary>
        ''' <typeparam name="T"></typeparam>
        ''' <param name="filterParam"></param>
        ''' <param name="filterType"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Overloads Function RequestAnyCollection(Of T As accountEntity)(ByRef _data As IEnumerable(Of T), Optional filterParam As String = "", Optional filterType As emMoySkladFilterTypes = emMoySkladFilterTypes.empty, Optional ByRef _ServerMessage As String = "", Optional ByRef RawResponse As String = "", Optional ByRef _requestbody As String = "") As System.Net.HttpStatusCode
            Dim _XMLResponse As String = ""

            Dim _out As List(Of T)
            Dim _result As New List(Of T)
            Dim _request As System.Net.HttpStatusCode
            Dim _objCount As Integer = 0
            Dim _start As Integer = 0
            Dim _total As Integer = 0
            Dim _count As Integer = 0
req:
            _request = RequestAny(Of T)(_XMLResponse, _start, filterParam, filterType, _ServerMessage, _requestbody)
            _out = New List(Of T)

            Select Case _request
                Case Net.HttpStatusCode.NotFound
                    _ServerMessage = "Обьект не найден. Статус запроса: " & ChrW(13) & _ServerMessage
                    '------------------------
                Case Net.HttpStatusCode.OK
                    RawResponse = _XMLResponse
                    Dim _status As Integer
                    Dim _cont = CastToContainer(_XMLResponse, _status)

                    If _status > 0 Then
                        'запрос обьекта
                        If _cont.TryGetObjectCollection(Of T)(_out) Then
                            _result.AddRange(_out)
                            'тут надо узнать ко-во обьектов и полученное кол-во обьектов
                            Dim _xe = XElement.Parse(_XMLResponse)
                            _total = _xe.@total
                            _count = _xe.@count
                            _start = _xe.@start
                            If _total > _count AndAlso _result.Count < _total Then
                                'тогда выдали не все, запросить остальное
                                _objCount += _count
                                'начать с элемента
                                _start = _objCount
                                GoTo req
                            End If
                            _data = _result
                            Return _request
                        Else
                            'не найден?
                            _ServerMessage = "Обьект на найден"
                            Return Net.HttpStatusCode.NotFound
                        End If
                    Else
                        'это не контейнер
                        _out.Clear()
                        Dim _cont1 = clsMSObjectReader(Of T).CreatInstance(_XMLResponse) ' ReadXML(_XMLResponse, GetType(T))
                        If Not _cont1 Is Nothing Then
                            _out.Add(_cont1)
                            _data = _out
                            Return _request
                        Else
                            'невозможно распознать ответ сервера
                            _ServerMessage = "невозможно распознать ответ сервера. Статус запроса:" & ChrW(13) & _ServerMessage
                            Return Net.HttpStatusCode.BadRequest
                        End If
                    End If

            End Select
            Return _request
        End Function



        ''' <summary>
        '''СТАРАЯ -используй типизированную версию! вернет коллекцию обьектов требуемого типа
        ''' </summary>
        ''' <param name="objectType"></param>
        ''' <param name="_data"></param>
        ''' <param name="filterParam"></param>
        ''' <param name="filterType"></param>
        ''' <param name="_ServerMessage"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overloads Function RequestAnyCollection(objectType As emMoySkladObjectTypes, ByRef _data As IEnumerable(Of Object), Optional filterParam As String = "", Optional filterType As emMoySkladFilterTypes = Nothing, Optional ByRef _ServerMessage As String = "", Optional ByRef RawResponse As String = "", Optional ByRef _requestbody As String = "") As System.Net.HttpStatusCode
            Dim _XMLResponse As String = ""

            'преобразователь типов
            Dim T As Type = Me.CastTypeByEnum(objectType)
            If T Is Nothing Then
                'не удалось распознать тип
                _ServerMessage = "не удалось распознать тип в перечислении"
                Return Net.HttpStatusCode.BadRequest
            End If

            Dim _out As List(Of Object)
            Dim _result As New List(Of Object)
            Dim _request As System.Net.HttpStatusCode
            Dim _objCount As Integer = 0
            Dim _start As Integer = 0
            Dim _total As Integer = 0
            Dim _count As Integer = 0
req:
            _request = RequestAny(objectType, _XMLResponse, _start, filterParam, filterType, _ServerMessage, _requestbody)
            _out = New List(Of Object)

            Select Case _request
                Case Net.HttpStatusCode.NotFound
                    _ServerMessage = "Обьект не найден. Статус запроса: " & ChrW(13) & _ServerMessage
                    '------------------------
                Case Net.HttpStatusCode.OK
                    RawResponse = _XMLResponse
                    Dim _status As Integer
                    Dim _cont = CastToContainer(_XMLResponse, _status)

                    If _status > 0 Then
                        'запрос обьекта
                        If _cont.TryGetObjectCollection(_out, T) Then
                            _result.AddRange(_out)
                            'тут надо узнать ко-во обьектов и полученное кол-во обьектов
                            Dim _xe = XElement.Parse(_XMLResponse)
                            _total = _xe.@total
                            _count = _xe.@count
                            _start = _xe.@start
                            If _total > _count AndAlso _result.Count < _total Then
                                'тогда выдали не все, запросить остальное
                                _objCount += _count
                                'начать с элемента
                                _start = _objCount
                                GoTo req
                            End If
                            _data = _result
                            Return _request
                        Else
                            'не найден?
                            _ServerMessage = "Обьект на найден"
                            Return Net.HttpStatusCode.NotFound
                        End If
                    Else
                        'это не контейнер
                        _out.Clear()
                        Dim _cont1 = ReadXML(_XMLResponse, T)
                        If Not _cont1 Is Nothing Then
                            _out.Add(_cont1)
                            _data = _out
                            Return _request
                        Else
                            'невозможно распознать ответ сервера
                            _ServerMessage = "невозможно распознать ответ сервера. Статус запроса:" & ChrW(13) & _ServerMessage
                            Return Net.HttpStatusCode.BadRequest
                        End If
                    End If
            End Select
            Return _request
        End Function

       



        ''' <summary>
        ''' типизированная функция запроса. Служебная функция.Для нормального запроса использовать RequestAnyCollection. Превращать в обьект методом CastToContainer!!!
        ''' </summary>
        ''' <typeparam name="T"></typeparam>
        ''' <param name="_respondXML"></param>
        ''' <param name="StartObjectIndex"></param>
        ''' <param name="filterParam"></param>
        ''' <param name="filterType"></param>
        ''' <param name="_statusMessage"></param>
        ''' <param name="_requestbody"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Overloads Function RequestAny(Of T As accountEntity)(ByRef _respondXML As String, StartObjectIndex As Integer, Optional filterParam As String = "", Optional filterType As emMoySkladFilterTypes = emMoySkladFilterTypes.empty, Optional ByRef _statusMessage As String = "", Optional ByRef _requestbody As String = "") As System.Net.HttpStatusCode
            '!!!Служебная функция. Для нормального запроса использовать RequestAnyCollection
            Dim _reqcount As Integer = 0
            Dim _reqstr As String
            Dim _paramstr As String = ""
            Dim _objectName = GetType(T).Name.Split(".").LastOrDefault

            'перевод первой буквы типа в верхний регистр
            _objectName = Char.ToUpper(_objectName.Substring(0, 1)) & _objectName.Substring(1, _objectName.Length - 1)

            '-------------------
st:
            Select Case filterType
                Case emMoySkladFilterTypes.uuid
                    _reqstr = String.Format("{0}{1}{2}{3}", "/ms/xml/", _objectName, "/", filterParam)
                Case emMoySkladFilterTypes.updatedLate
                    _reqstr = String.Format("{0}{1}{2}", "/ms/xml/", _objectName, "/list")

                    Dim _ds As Date
                    If Date.TryParse(filterParam, _ds) Then
                        '2011 01 01 010000  = 
                        Dim _fs As String = _ds.ToString("yyyyMMdd") & "010000"
                        _paramstr = "updated" & ">" & _fs
                    End If

                Case emMoySkladFilterTypes.updatedEarly
                    _reqstr = String.Format("{0}{1}{2}", "/ms/xml/", _objectName, "/list")
                    ' _reqstr = "/ms/xml/" & [Enum].GetName(GetType(emMoySkladObjectTypes), objectType) & "/list"

                    Dim _ds As Date
                    If Date.TryParse(filterParam, _ds) Then
                        '2011 01 01 010000  = 
                        Dim _fs As String = _ds.ToString("yyyyMMdd") & "010000"
                        _paramstr = "updated" & "<" & _fs
                    End If
                Case emMoySkladFilterTypes.createdLate
                    _reqstr = String.Format("{0}{1}{2}", "/ms/xml/", _objectName, "/list")
                    '  _reqstr = "/ms/xml/" & [Enum].GetName(GetType(emMoySkladObjectTypes), objectType) & "/list"

                    Dim _ds As Date
                    If Date.TryParse(filterParam, _ds) Then
                        '2011 01 01 010000  = 
                        Dim _fs As String = _ds.ToString("yyyyMMdd") & "010000"
                        _paramstr = "created" & ">" & _fs
                    End If

                Case Else
                    _reqstr = String.Format("{0}{1}{2}", "/ms/xml/", _objectName, "/list")
                    '_reqstr = "/ms/xml/" & [Enum].GetName(GetType(emMoySkladObjectTypes), objectType) & "/list"
                    _paramstr = [Enum].GetName(GetType(emMoySkladFilterTypes), filterType) & "=" & filterParam
            End Select
            Dim _request = New RestRequest(_reqstr, Method.GET)
            _request.AddParameter("start", StartObjectIndex)
            If (Not filterParam = "") AndAlso (Not IsNothing(filterType)) AndAlso (Not _paramstr = "") Then
                _request.AddParameter("filter", _paramstr)
            End If

            Dim _response As IRestResponse = Me.oRestClient.Execute(_request)

            'сам запрос
            Dim _req = _response.ResponseUri

            If _req Is Nothing Then
                RequestIsBusy()
                Return Net.HttpStatusCode.InternalServerError
            End If

            _requestbody = _response.ResponseUri.ToString

            _respondXML = _response.Content

            If Not _response.StatusCode = Net.HttpStatusCode.OK Then
                If _response.StatusCode = Net.HttpStatusCode.Unauthorized Then
                    For i = 0 To 50000
                        _reqcount += 1
                        If _reqcount < 20 Then GoTo st
                    Next
                    RequestIsBusy()
                    Return _response.StatusCode
                End If
                'формируем сообщение для клиента
                _statusMessage = "StatusCode: " & _response.StatusCode.ToString() & ChrW(13)
                _statusMessage += "Description: " & _response.StatusDescription & ChrW(13)
                _statusMessage += "Error message: " & _response.ErrorMessage & ChrW(13)
                If Not _response.ResponseUri Is Nothing Then
                    _statusMessage += "ResponseURI: " & _response.ResponseUri.ToString & ChrW(13)

                End If
                _statusMessage += "Server: " & _response.Server & ChrW(13)
            Else
                _statusMessage = "Ok"
            End If

            RequestIsBusy()
            Return _response.StatusCode

        End Function


        ''' <summary>
        '''СТАРАЯ -используй типизированную версию! Служебная функция.Для нормального запроса использовать RequestAnyCollection. Превращать в обьект методом CastToContainer!!!
        ''' </summary>
        ''' <param name="objectType"></param>
        ''' <param name="_respondXML">тело XML ответа обьектМС, можно превратить в обьект</param>
        ''' <param name="filterParam"></param>
        ''' <param name="filterType"></param>
        ''' <param name="_statusMessage"></param>
        ''' <param name="_requestbody">тело сформированного запроса</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Overloads Function RequestAny(objectType As emMoySkladObjectTypes, ByRef _respondXML As String, StartObjectIndex As Integer, Optional filterParam As String = "", Optional filterType As emMoySkladFilterTypes = Nothing, Optional ByRef _statusMessage As String = "", Optional ByRef _requestbody As String = "") As System.Net.HttpStatusCode
            '!!!Служебная функция. Для нормального запроса использовать RequestAnyCollection
            Dim _reqcount As Integer = 0
            Dim _reqstr As String
            Dim _paramstr As String = ""
            '-------------------
st:
            Select Case filterType
                Case emMoySkladFilterTypes.uuid
                    _reqstr = "/ms/xml/" & [Enum].GetName(GetType(emMoySkladObjectTypes), objectType) & "/" & filterParam
                Case emMoySkladFilterTypes.updatedLate
                    _reqstr = "/ms/xml/" & [Enum].GetName(GetType(emMoySkladObjectTypes), objectType) & "/list"

                    Dim _ds As Date
                    If Date.TryParse(filterParam, _ds) Then
                        '2011 01 01 010000  = 
                        Dim _fs As String = _ds.ToString("yyyyMMdd") & "010000"
                        _paramstr = "updated" & ">" & _fs
                    End If

                Case emMoySkladFilterTypes.updatedEarly
                    _reqstr = "/ms/xml/" & [Enum].GetName(GetType(emMoySkladObjectTypes), objectType) & "/list"

                    Dim _ds As Date
                    If Date.TryParse(filterParam, _ds) Then
                        '2011 01 01 010000  = 
                        Dim _fs As String = _ds.ToString("yyyyMMdd") & "010000"
                        _paramstr = "updated" & "<" & _fs
                    End If
                Case emMoySkladFilterTypes.createdLate
                    _reqstr = "/ms/xml/" & [Enum].GetName(GetType(emMoySkladObjectTypes), objectType) & "/list"

                    Dim _ds As Date
                    If Date.TryParse(filterParam, _ds) Then
                        '2011 01 01 010000  = 
                        Dim _fs As String = _ds.ToString("yyyyMMdd") & "010000"
                        _paramstr = "created" & ">" & _fs
                    End If

                Case Else
                    _reqstr = "/ms/xml/" & [Enum].GetName(GetType(emMoySkladObjectTypes), objectType) & "/list"
                    _paramstr = [Enum].GetName(GetType(emMoySkladFilterTypes), filterType) & "=" & filterParam
            End Select
            Dim _request = New RestRequest(_reqstr, Method.GET)
            _request.AddParameter("start", StartObjectIndex)
            If (Not filterParam = "") AndAlso (Not IsNothing(filterType)) AndAlso (Not _paramstr = "") Then
                _request.AddParameter("filter", _paramstr)
            End If

            Dim _response As IRestResponse = Me.oRestClient.Execute(_request)

            'сам запрос
            Dim _req = _response.ResponseUri

            If _req Is Nothing Then
                RequestIsBusy()
                Return Net.HttpStatusCode.InternalServerError
            End If

            _requestbody = _response.ResponseUri.ToString

            _respondXML = _response.Content

            If Not _response.StatusCode = Net.HttpStatusCode.OK Then
                If _response.StatusCode = Net.HttpStatusCode.Unauthorized Then
                    For i = 0 To 50000
                        _reqcount += 1
                        If _reqcount < 20 Then GoTo st
                    Next
                    RequestIsBusy()
                    Return _response.StatusCode
                End If
                'формируем сообщение для клиента
                _statusMessage = "StatusCode: " & _response.StatusCode.ToString() & ChrW(13)
                _statusMessage += "Description: " & _response.StatusDescription & ChrW(13)
                _statusMessage += "Error message: " & _response.ErrorMessage & ChrW(13)
                If Not _response.ResponseUri Is Nothing Then
                    _statusMessage += "ResponseURI: " & _response.ResponseUri.ToString & ChrW(13)

                End If
                _statusMessage += "Server: " & _response.Server & ChrW(13)
            Else
                _statusMessage = "Ok"
            End If

            RequestIsBusy()
            Return _response.StatusCode
        End Function
        ''' <summary>
        ''' запрашивает остатки по складам для товара
        ''' </summary>
        ''' <param name="objectType"></param>
        ''' <param name="_XMLResponse"></param>
        ''' <param name="goodUUID"></param>
        ''' <param name="storeUUID"></param>
        ''' <param name="_statusMessage"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Overloads Function RequestAnyCollection(objectType As emTOMoySkladTypes, ByRef _XMLResponse As String, storeUUID As String, Optional goodUUID As String() = Nothing, Optional GoodNamePart As String = "", Optional StockMode As emStockMode = emStockMode.POSITIVE_ONLY, Optional ByRef _statusMessage As String = "", Optional ByRef _requestbody As String = "") As System.Net.HttpStatusCode
            Dim _reqstr As String
            Dim _request As RestSharp.RestRequest = Nothing
            Dim _reqcount As Integer = 1
st:
            Select Case objectType
                Case emTOMoySkladTypes.stockTO
                    _reqstr = "/stock/xml"
                    _request = New RestRequest(_reqstr, Method.GET)
                    If Not goodUUID Is Nothing AndAlso goodUUID.Length > 0 Then
                        _request.AddParameter("goodUuid", goodUUID(0))
                    End If
                    If Not storeUUID = "" Then
                        _request.AddParameter("storeUuid", storeUUID)
                    End If
                    If Not GoodNamePart = "" Then
                        _request.AddParameter("goodName", GoodNamePart)
                    End If

                    _request.AddParameter("stockMode", [Enum].GetName(GetType(emStockMode), StockMode))

                    'gooduuid uuid товара или папки товаров, по которым необходимо получить остатки
                    'goodName string  название товара или часть названия товаров, по которым необходимо получить остатки
                    'stockMode emstockMode - тип остатка (положит, и прочее)


                    'includeAboardOperations boolearn - определяет - должны ли быть включены в подсчет остатков непроведенные документы, по умолчанию непроведенные документы в подсчет остатков не включены.
                    'moment - строка в формате yyyyMMddHHmmss - момент времени, на который необходимо получить остатки
                    'showConsignments boolearn - определяет группировку результатов - если true, то группировка осуществляется по сериям (что позволяет отображать характеристики), если false, то группировка результатов осуществляется по товарам


                    'Case emTOMoySkladTypes.stockGoodTO
                    '    'НЕ работает на сервере, почему - неизвестно
                    '    _reqstr = "/stock-for-good/xml"
                    '    _request = New RestRequest(_reqstr, Method.GET)
                    '    If Not goodUUID Is Nothing AndAlso goodUUID.Length > 0 Then
                    '        _request.AddParameter("goodUuid", goodUUID(0))
                    '    End If

                    '    If Not storeUUID = "" Then
                    '        _request.AddParameter("storeUuid", storeUUID)
                    '    End If
                    '    'это возможные параметры
                    '    '_request.AddParameter("moment", "")


                Case emTOMoySkladTypes.slotStateReportTO
                    _reqstr = "/slot/xml"
                    _request = New RestRequest(_reqstr, Method.GET)
                    _request.AddParameter("storeUuid", storeUUID)

                    Debug.Assert(Not storeUUID = "", "Указание склада обязательно для запросов slot")
                    If Not goodUUID Is Nothing Then
                        For Each t In goodUUID
                            _request.AddParameter("goodId", t)
                        Next
                    End If



                    '*поддерживает запросы коллекций обьектов
                    'goodIds Формат - массив строк
                    'Назначение - uuid товаров, по которым запрошена детализация остатков. Массив задается так: goodId=<UUID1>&goodId=<UUID2>&...&goodId=<UUID50>

                Case Else
                    Throw New Exception("Необходимо задать обработку члена перечисления")
            End Select

            Dim _response As IRestResponse = Me.oRestClient.Execute(_request)
            _XMLResponse = _response.Content
            _requestbody = _response.ResponseUri.ToString
            '--------------
            'обработка ошибок запроса
            Select Case _response.StatusCode
                Case Net.HttpStatusCode.Unauthorized
                    For i = 0 To 50000
                        'delay for request
                    Next
                    _reqcount += 1
                    If _reqcount < 20 Then GoTo st
                Case Net.HttpStatusCode.BadRequest
                    'пробуем заменить параметр stockMode
                    Select Case _reqcount
                        Case 0
                            StockMode = emStockMode.ALL_STOCK
                            _reqcount += 1
                            GoTo st
                        Case 1
                            StockMode = emStockMode.POSITIVE_ONLY
                            _reqcount += 1
                            GoTo st
                    End Select
                Case Else
            End Select
            'формируем сообщение для клиента
            Select Case _response.StatusCode
                Case Net.HttpStatusCode.OK
                    _statusMessage = "Ok. "
                    If _reqcount > 1 Then
                        _statusMessage += ChrW(13) & "Request count: " & _reqcount.ToString
                    End If
                Case Else
                    _statusMessage = "StatusCode: " & _response.StatusCode.ToString() & ChrW(13)
                    _statusMessage += "Description: " & _response.StatusDescription & ChrW(13)
                    _statusMessage += "Error message: " & _response.ErrorMessage & ChrW(13)
                    _statusMessage += "ResponseURI: " & _response.ResponseUri.ToString & ChrW(13)
                    _statusMessage += "Server: " & _response.Server & ChrW(13)
            End Select
            '--------------
            RequestIsBusy()
            Return _response.StatusCode

        End Function

        ''' <summary>
        ''' описывает характер получение остатков
        ''' </summary>
        ''' <remarks></remarks>
        Public Enum emStockMode
            ''' <summary>
            ''' все товары
            ''' </summary>
            ''' <remarks></remarks>
            ALL_STOCK
            ''' <summary>
            ''' только положительные остатки
            ''' </summary>
            ''' <remarks></remarks>
            POSITIVE_ONLY

            ''' <summary>
            ''' только положительные остатки, с учетом резерва
            ''' </summary>
            ''' <remarks></remarks>
            POSITIVE_INCLUDING_RESERVE_ONLY
            ''' <summary>
            ''' только отрицательные значения
            ''' </summary>
            ''' <remarks></remarks>
            NEGATIVE_ONLY

            ''' <summary>
            ''' отрицательные и положительные значения
            ''' </summary>
            ''' <remarks></remarks>
            NON_EMPTY

            ''' <summary>
            ''' ниже неснижаемого остатка
            ''' </summary>
            ''' <remarks></remarks>
            UNDER_MINIMUM_BALANCE_ONLY

            ''' <summary>
            ''' с учетом резерва
            ''' </summary>
            ''' <remarks></remarks>
            USE_RESERVES

        End Enum


        ''' <summary>
        ''' описывает доступные сервисы получения остатков
        ''' </summary>
        ''' <remarks></remarks>
        Public Enum emTOMoySkladTypes
            '!!! имена членов связаны с именами классов в SerialObj
            ''' <summary>
            ''' остатки по товарам /stock/xml поддерживает все параметры
            ''' </summary>
            ''' <remarks></remarks>
            stockTO

            ' ''' <summary>
            ' ''' остатки по складам /stock-for-good/xml
            ' ''' </summary>
            ' ''' <remarks></remarks>
            'stockGoodTO

            ''' <summary>
            ''' остатки по ячейкам /slot/xml  поддерживает массив UUID товаров и UUID склада
            ''' </summary>
            ''' <remarks></remarks>
            slotStateReportTO
        End Enum

        ''' <summary>
        ''' записывает данные в МойСклад
        ''' </summary>
        ''' <param name="objectType"></param>
        ''' <param name="obj"></param>
        ''' <param name="_respondXML">XML ответа как обновленный обьект МС, можно превратить в обьект</param>
        ''' <param name="_statusMessage"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Friend Function AddAnyToServer(objectType As emMoySkladObjectTypes, obj As Object, ByRef _respondXML As String, Optional ByRef _statusMessage As String = "") As System.Net.HttpStatusCode
            Dim _client = New RestClient("https://online.moysklad.ru/exchange/rest")
            _client.Authenticator = New HttpBasicAuthenticator("admin@trilbone", "illaenus2012")
            Dim _reqstr As String = "/ms/xml/" & [Enum].GetName(GetType(emMoySkladObjectTypes), objectType)
            ''строка запроса https://online.moysklad.ru/exchange/rest/ms/xml/{type}
            '' тело - обьект 
            Dim _request = New RestRequest(_reqstr, Method.PUT)
            _request.RequestFormat = DataFormat.Xml

            Dim _sr As New RestSharp.Serializers.DotNetXmlSerializer()
            _sr.ContentType = "application/xml"
            _sr.DateFormat = "yyyy-MM-ddTHH:mm:ssZ"
            _sr.Encoding = Encoding.UTF8
            'изменено 12.01.2016 - вопрос будет ли работать - но явно косяк
            ' _sr.RootElement = "Good"

            _request.XmlSerializer = _sr
            _request.AddBody(obj)
            Dim _response As IRestResponse = _client.Execute(_request)
            _respondXML = _response.Content
            _statusMessage = _response.StatusDescription
            Dim _status = _response.StatusCode

            If _status = Net.HttpStatusCode.OK Then
                'обновление буферных обьектов по результатам запроса
                Select Case objectType
                    Case emMoySkladObjectTypes.Enter
                        'обновим оприходование в буфере
                        Dim _obj As enter = clsMSObjectReader(Of enter).CreatInstance(_respondXML)
                        If Not _obj Is Nothing Then
                            Dim _index As Integer = -1
                            For i = 0 To Me.EnterList.Count - 1
                                If Me.EnterList(i).uuid = _obj.uuid Then
                                    _index = i
                                    Exit For
                                End If
                            Next
                            If _index > -1 Then
                                Me.EnterList(_index) = _obj
                            End If
                        End If

                End Select
                Dim _cont = XElement.Parse(_response.Content)
                If _cont.Name = "error" Then
                    'запрос вернул ошибку
                    'MsgBox("сервер вернул ошибку на запрос: " & _cont...<message>.Value, vbCritical)
                    _statusMessage = _cont...<message>.Value
                    Return Net.HttpStatusCode.InternalServerError
                End If

            End If
            Return _status
        End Function

        ' ''' <summary>
        ' ''' обновляет данные в МойСклад
        ' ''' </summary>
        ' ''' <param name="objectType"></param>
        ' ''' <param name="obj">обьект для обновления</param>
        ' ''' <param name="_respondXML">XML ответа как обновленный обьект МС, можно превратить в обьект</param>
        ' ''' <param name="_statusMessage">ответ сервера (статус)</param>
        ' ''' <returns></returns>
        ' ''' <remarks></remarks>
        'Private Function writeData(objectType As emMoySkladObjectTypes, obj As Object, ByRef _respondXML As String, Optional ByRef _statusMessage As String = "") As System.Net.HttpStatusCode
        '    Dim _client = New RestClient("https://online.moysklad.ru/exchange/rest")
        '    _client.Authenticator = New HttpBasicAuthenticator("admin@trilbone", "illaenus2012")
        '    '/ms/xml/{type}/list/update
        '    Dim _reqstr As String = "/ms/xml/" & [Enum].GetName(GetType(emMoySkladObjectTypes), objectType) & "/list/update"

        '    Dim _request = New RestRequest(_reqstr, Method.PUT)
        '    _request.RequestFormat = DataFormat.Xml

        '    Dim _sr As New RestSharp.Serializers.DotNetXmlSerializer()
        '    _sr.ContentType = "application/xml"
        '    _sr.DateFormat = "yyyy-MM-ddTHH:mm:ssZ"
        '    _sr.Encoding = Encoding.UTF8
        '    _sr.RootElement = "Good"


        '    _request.XmlSerializer = _sr
        '    _request.AddBody(obj)
        '    Dim _response As IRestResponse = _client.Execute(_request)
        '    _respondXML = _response.Content
        '    _statusMessage = _response.StatusDescription
        '    Return _response.StatusCode

        'End Function





        ''' <summary>
        ''' запись товара в справочник мой склад. NewGood - получившийся товар
        ''' </summary>
        ''' <param name="goodTO"></param>
        ''' <param name="ServerMessage"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Friend Function AddGoodToServer(ByVal goodTO As good, ByRef NewGood As good, Optional ByRef ServerMessage As String = "") As System.Net.HttpStatusCode
            Dim _response As String = ""

            Dim _res = AddAnyToServer(emMoySkladObjectTypes.Good, goodTO, _response, ServerMessage)

            Select Case _res
                Case Net.HttpStatusCode.OK
                    NewGood = clsMSObjectReader(Of good).CreatInstance(_response)
            End Select
            Return _res
        End Function

        ''' <summary>
        ''' получит контейнер обьектов (status 0, 1 = ok , -1 = error)
        ''' </summary>
        ''' <param name="XMLString"></param>
        ''' <param name="_status"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Friend Function CastToContainer(XMLString As String, ByRef _status As Integer) As collectionContainer
            Dim _new As New collectionContainer
            If _new.ReadFromXML(XMLString) Then
                _status = 1

                Return _new
            End If
            _status = -1
            Return Nothing
        End Function



        Private oLocations As List(Of clsGoodLocation)

        ''' <summary>
        ''' создаст расположение и добавит его в коллекцию расположений. Загрузит ячейки. Список складов прописан в установках. будет вызван вызыван конструктором. Привяжет оприходования и списания. 
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub LoadLocantions()
            Me.oLocations = New List(Of clsGoodLocation)

            Dim _new As clsGoodLocation

            For Each _ware In oWarehouseList
                _new = New clsGoodLocation(_ware.uuid)
                _new.WarehouseName = _ware.name
                _new.LoadObjects(Me)

                'собрать все доступные ячейки
                For Each _slotUUID In _new.GetAllSlotUIID
                    _new.SlotGood.Add(New clsGoodLocation.clsSlot(0, _ware.uuid, _slotUUID))
                Next

                _new.LoadObjects(Me)
                '---------------
                _new.LinkedEnter = Me.GetEnterByWarehouseUUID(_ware.uuid)
                _new.LinkedLoss = Me.GetLossByWarehouseUUID(_ware.uuid)
                '--------------
                Me.oLocations.Add(_new)
                ''фильтр по предпочтительному складу

            Next
        End Sub
        ' ''' <summary>
        ' ''' старая!! используй EntityOfUserListByNameAsTrilbone
        ' ''' </summary>
        ' ''' <param name="Name"></param>
        ' ''' <value></value>
        ' ''' <returns></returns>
        ' ''' <remarks></remarks>
        'Friend ReadOnly Property EntityOfUserListByName(Name As String) As List(Of customEntity)
        '    Get



        '        If Not oUserEntityList.ContainsKey(Name) Then Me.LoadUserEntityByName(Name)
        '        Return oUserEntityList.Item(Name)
        '    End Get
        'End Property

        ''' <summary>
        ''' НОВАЯ вернет список по имени справочника
        ''' </summary>
        ''' <param name="Name"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Friend Function GetEntityOfUserListByNameAsTrilbone(Name As String) As List(Of iMoySkladDataProvider.clsEntity)
            Dim _cel = oCustomEntitiesList.Where(Function(x) x.name.ToLower.Equals(Name.ToLower)).FirstOrDefault
            If _cel Is Nothing Then
                MsgBox("Справочника " & Name & " не существует в Мой Склад", vbCritical)
                Return New List(Of iMoySkladDataProvider.clsEntity)
            End If

            If Not oUserEntityList.ContainsKey(_cel.name) Then Me.LoadUserEntityByName(_cel)
            If Not oUserEntityList.ContainsKey(_cel.name) Then Return New List(Of iMoySkladDataProvider.clsEntity)

            Return oUserEntityList.Item(_cel.name).Select(Function(x) x.GetTrilboneItem(_cel.name)).ToList
        End Function

        Public Function GetUserListNameByUUID(uuid As String) As String
            Dim _cel = oCustomEntitiesList.Where(Function(x) x.uuid.Equals(uuid)).FirstOrDefault
            If _cel Is Nothing Then
                Return ""
            End If
            Return _cel.name
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
            Dim _list = Me.GetEntityOfUserListByNameAsTrilbone(ListName)
            If _list.Count = 0 Then Return New iMoySkladDataProvider.clsEntity With {.MetaDataValue = ListName}

            Dim _result = _list.Where(Function(x) x.Value.ToLower.Equals(EntityName.ToLower)).FirstOrDefault


            If _result Is Nothing Then Return New iMoySkladDataProvider.clsEntity With {.Value = EntityName, .MetaDataValue = _list(1).Value, .MetaDataUUID = _list(1).MetaDataUUID}

            Return _result
        End Function

        ''' <summary>
        ''' НОВАЯ вернет список по UUID справочника
        ''' </summary>
        ''' <param name="MetaUUID"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Friend Function GetEntityOfUserListByMetadataUUIDAsTrilbone(MetaUUID As String) As List(Of iMoySkladDataProvider.clsEntity)
            Dim _cel = oCustomEntitiesList.Where(Function(x) x.uuid.Equals(MetaUUID)).FirstOrDefault
            If _cel Is Nothing Then
                MsgBox("Сущности с MetadataUUID " & MetaUUID & " не существует в Мой Склад", vbCritical)
                Return New List(Of iMoySkladDataProvider.clsEntity)
            End If

            If Not oUserEntityList.ContainsKey(_cel.name) Then Me.LoadUserEntityByName(_cel)
            If Not oUserEntityList.ContainsKey(_cel.name) Then Return New List(Of iMoySkladDataProvider.clsEntity)

            Return oUserEntityList.Item(_cel.name).Select(Function(x) x.GetTrilboneItem(_cel.name)).ToList
        End Function




        ''' <summary>
        ''' key = название справочника  value=список значений
        ''' </summary>
        ''' <remarks></remarks>
        Private oUserEntityList As New Dictionary(Of String, List(Of customEntity))
        ''0 бразилия,1 Интересы клиентов,2 Допрепарация,3 Оборудование и материалы,4 Тип оплаты,5 Направления расходов,6 Места захвата клиентов,7 Сотрудник Trilbone,8 Валюты,9 Шиппинговая компания,10 Счета,11 Экспедиции,12 Страна
        'Private oUserEntityNameList As String() = {"бразилия", "Интересы клиентов", "Допрепарация", "Оборудование и материалы", "Тип оплаты", "Направления расходов", "Места захвата клиентов", "Сотрудник Trilbone", "Валюты", "Шиппинговая компания", "Счета", "Экспедиции", " Страна"}
        'Private oUserMetadataUUIDList As String() = {"1d15d4bd-f4a7-11e3-8489-002590a28eca", "2e477c0c-a004-11e3-ddf5-002590a28eca", "529cb8aa-cd50-11e3-e636-002590a28eca", "6a0f10ca-a888-11e4-90a2-8ecb0011a91d", "79c88aac-8ebe-11e4-90a2-8ecb002d4161", ">8ab3c392-f4a3-11e3-aecf-002590a28eca", "bc1300bc-a004-11e3-1a91-002590a28eca", "c232c8fc-db60-11e3-a4c7-002590a28eca", "cdcd13c0-e428-11e3-0526-002590a28eca", "d0a770a7-db60-11e3-c16b-002590a28eca", "eff32c15-e428-11e3-d0f4-002590a28eca", "f90c172d-52e2-11e3-928b-7054d21a8d1e", "fd163b9e-b28c-11e3-346c-002590a28eca"}

        Private oCustomEntitiesList As List(Of customEntityMetadata)


        ''' <summary>
        ''' загружает список пользовательских справочников
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub LoadCustomEntitiesList()
            Dim _result As New List(Of customEntityMetadata)
            Dim _message As String = ""
            If Me.RequestAnyCollection(Of customEntityMetadata)(oCustomEntitiesList, "", emMoySkladFilterTypes.empty, _message) Then
                'ok
            Else
                oCustomEntitiesList = New List(Of customEntityMetadata)
                MsgBox(_message, vbCritical)
            End If
        End Sub

        ''' <summary>
        ''' ищет в загруженных сущностях
        ''' </summary>
        ''' <param name="uuid"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Friend Function GetCustomEntityByUUID(uuid As String) As customEntity
            If String.IsNullOrEmpty(uuid) Then Return Nothing
            Dim _res = oUserEntityList.SelectMany(Function(x) x.Value).Where(Function(x) x.uuid.Equals(uuid)).FirstOrDefault

            Return _res

        End Function

        ''' <summary>
        '''загрузить и получить сущность по UUID
        ''' </summary>
        ''' <param name="uuid"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetLoadCustomEntityByUUID(uuid As String) As iMoySkladDataProvider.clsEntity
            Dim _t = GetCustomEntityByUUID(uuid)
            If Not _t Is Nothing Then Return _t.GetTrilboneItem(Me.GetUserListNameByUUID(_t.entityMetadataUuid))
            Dim _out As New List(Of customEntity)
            If Me.RequestAnyCollection(Of customEntity)(_out, uuid, emMoySkladFilterTypes.uuid, "") Then
                _t = _out.FirstOrDefault
                If Not _t Is Nothing Then Return _t.GetTrilboneItem(Me.GetUserListNameByUUID(_t.entityMetadataUuid))
            End If
            Return Nothing
        End Function


        ''' <summary>
        ''' загрузка элементов пользовательских справочников из МС
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub LoadUserEntityByName(CEM As customEntityMetadata)
            'проверка доступности в вызывающих функциях
            'Dim _cel = oCustomEntitiesList.Where(Function(x) x.name.ToLower.Equals(Name.ToLower)).FirstOrDefault
            'If _cel Is Nothing Then
            '    MsgBox("Сущность с именем " & Name & " не существует в Мой Склад", vbCritical)
            '    Return
            'End If

            'Dim _qw = From c In oUserEntityNameList Where c.Equals(Name) Select c
            'If _qw.Count = 0 Then
            '    MsgBox("Сущность с именем " & Name & " не зарегистрирована для загрузки в классе clsMoySkladManager, процедура LoadUserEntityByName", vbCritical)
            '    Return
            'End If

            ' Dim _eindex = oUserEntityNameList.ToList.IndexOf(CEM.name)
            If oUserEntityList.ContainsKey(CEM.name) Then Return

            Dim _data As IEnumerable(Of Object) = Nothing
            Dim _ent As List(Of customEntity) = Nothing
            Dim _message As String = ""
            Dim _metaUUID = CEM.uuid
            'загрузим об 
            Dim _result = Me.RequestAnyCollection(clsMoyScladManager.emMoySkladObjectTypes.CustomEntity, _data, _metaUUID, emMoySkladFilterTypes.entityMetadataUuid, _message, "")

            If _result = Net.HttpStatusCode.OK Then
                Select Case _data.Count
                    Case 0
                        'пользовательского справочника не найден
                        MsgBox("пользовательского справочника " & CEM.name & " нет!" & ChrW(13) & _message, vbCritical)
                    Case Is > 1
                        _ent = (_data.Cast(Of customEntity).ToList)
                        Dim _toadd As New List(Of customEntity)
                        'добавить пустое значение
                        Dim _em = New customEntity
                        With _em
                            .uuid = ""
                            .name = ""
                        End With
                        _toadd.Add(_em)
                        _toadd.AddRange(_ent)
                        oUserEntityList.Add(CEM.name, _toadd)
                End Select
            Else
                'запрос вернул ошибку
                MsgBox("запрос пользовательского справочника " & CEM.name & " вернул ошибку. Неправильный запрос?" & ChrW(13) & _message, vbCritical)
            End If
        End Sub


        ''' <summary>
        ''' исправляет курсы валют
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub LoadCurrency()
            'валюты
            Dim _data As IEnumerable(Of Object) = Nothing
            Dim _res = Me.RequestAnyCollection(clsMoyScladManager.emMoySkladObjectTypes.Currency, _data)
            Select Case _res
                Case Net.HttpStatusCode.OK
                    Me.oCurrencyList = _data.Cast(Of MoySkladAPI.currency)().ToList
            End Select
            Dim _status As Boolean
            clsApplicationTypes.GetRateByCurrencyCB103("USD", _status)
            If _status Then
                'корректировка курса
                Dim _corr = From c In oCurrencyList Select New MoySkladAPI.currency With {.code = c.code, .name = c.name, .uuid = c.uuid, .rate = clsApplicationTypes.GetRateByCurrencyCB103(.name), .enteredRate = .rate, .invertRate = False}
                Me.oCurrencyList = _corr.ToList
            End If
        End Sub


        ''' <summary>
        ''' запросит товар
        ''' </summary>
        ''' <param name="uuid"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Friend Function RequestGoodByUUID(uuid As String) As good
            Dim _data As IEnumerable(Of Object) = Nothing
            Dim _message As String = ""
            Dim _result = Me.RequestAnyCollection(emMoySkladObjectTypes.Good, _data, uuid, emMoySkladFilterTypes.uuid, _message, "")
            Select Case _result
                Case Net.HttpStatusCode.OK
                    If _data.Count > 0 Then
                        'товар есть
                        Return DirectCast(_data(0), good)
                    Else
                        MsgBox("Не удалось получить товар " & uuid & " с сервера", vbCritical)
                    End If
                Case Else
                    MsgBox("Не удалось получить товар " & uuid & " с сервера", vbCritical)
            End Select
            Return Nothing
        End Function

        ''' <summary>
        ''' запросит отгрузку
        ''' </summary>
        ''' <param name="uuid"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Friend Function RequestDemandByUUID(uuid As String) As demand
            Dim _data As IEnumerable(Of Object) = Nothing
            Dim _message As String = ""
            Dim _result = Me.RequestAnyCollection(emMoySkladObjectTypes.Demand, _data, uuid, emMoySkladFilterTypes.uuid, _message, "")
            Select Case _result
                Case Net.HttpStatusCode.OK
                    If _data.Count > 0 Then
                        'оприходование есть
                        Return DirectCast(_data(0), demand)
                    Else
                        MsgBox("Не удалось получить отгрузку " & uuid & " с сервера", vbCritical)
                    End If
                Case Else
                    MsgBox("Не удалось получить отгрузку " & uuid & " с сервера", vbCritical)
            End Select
            Return Nothing
        End Function

        ''' <summary>
        ''' запросит отгрузку
        ''' </summary>
        ''' <param name="name"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Friend Function RequestDemandByName(name As String) As List(Of demand)
            Dim _data As IEnumerable(Of Object) = Nothing
            Dim _message As String = ""
            Dim _result = Me.RequestAnyCollection(emMoySkladObjectTypes.Demand, _data, name, emMoySkladFilterTypes.name, _message, "")
            Select Case _result
                Case Net.HttpStatusCode.OK
                    If _data.Count > 0 Then
                        'оприходование есть
                        Return _data.Cast(Of demand).ToList
                        'Else
                        '    MsgBox("Не удалось получить отгрузку " & name & " с сервера", vbCritical)
                    End If
                Case Else
                    MsgBox("Не удалось получить отгрузку " & name & " с сервера", vbCritical)
            End Select
            Return Nothing
        End Function

        ''' <summary>
        ''' запросит входящие платежи (два типа)
        ''' </summary>
        ''' <param name="name"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Friend Function RequestFinanceInByName(name As String) As List(Of iMoySkladDataProvider.clsPaymentInfo)
            Dim _resultCash As New List(Of cashIn)
            Dim _resultPay As New List(Of paymentIn)
            Dim _Out As New List(Of iMoySkladDataProvider.clsPaymentInfo)
            Dim _mess As String = ""
            If Me.RequestAnyCollection(Of cashIn)(_resultCash, name, emMoySkladFilterTypes.name, _mess) Then
                _Out.AddRange(_resultCash.Select(Function(x) x.GetpaymentInTrilbone(Me)))
            End If
            If Me.RequestAnyCollection(Of paymentIn)(_resultPay, name, emMoySkladFilterTypes.name, _mess) Then
                _Out.AddRange(_resultPay.Select(Function(x) x.GetpaymentInTrilbone(Me)))
            End If

            Return _Out
        End Function

        ''' <summary>
        ''' запросит исходящие платежи (два типа)
        ''' </summary>
        ''' <param name="name"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Friend Function RequestFinanceOutByName(name As String) As List(Of iMoySkladDataProvider.clsPaymentInfo)

            Dim _resultCash As New List(Of cashOut)
            Dim _resultPay As New List(Of paymentOut)
            Dim _Out As New List(Of iMoySkladDataProvider.clsPaymentInfo)
            Dim _mess As String = ""
            If Me.RequestAnyCollection(Of cashOut)(_resultCash, name, emMoySkladFilterTypes.name, _mess) Then
                _Out.AddRange(_resultCash.Select(Function(x) x.GetpaymentInTrilbone(Me)))
            End If
            If Me.RequestAnyCollection(Of paymentOut)(_resultPay, name, emMoySkladFilterTypes.name, _mess) Then
                _Out.AddRange(_resultPay.Select(Function(x) x.GetpaymentInTrilbone(Me)))
            End If

            Return _Out

        End Function


        ''' <summary>
        ''' запросит заказ
        ''' </summary>
        ''' <param name="name"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Friend Function RequestCustomerOrderByName(name As String) As List(Of customerOrder)
            Dim _data As IEnumerable(Of Object) = Nothing
            Dim _message As String = ""
            Dim _result = Me.RequestAnyCollection(emMoySkladObjectTypes.CustomerOrder, _data, name, emMoySkladFilterTypes.name, _message, "")
            Select Case _result
                Case Net.HttpStatusCode.OK
                    If _data.Count > 0 Then
                        'оприходование есть
                        Return _data.Cast(Of customerOrder).ToList
                    Else
                        MsgBox("Не удалось получить заказ " & name & " с сервера", vbCritical)
                    End If
                Case Else
                    MsgBox("Не удалось получить заказ " & name & " с сервера", vbCritical)
            End Select
            Return Nothing
        End Function

        ''' <summary>
        ''' запросит заказ
        ''' </summary>
        ''' <param name="uuid"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Friend Function RequestCustomerOrderByUUID(uuid As String) As customerOrder
            Dim _data As IEnumerable(Of Object) = Nothing
            Dim _message As String = ""
            Dim _result = Me.RequestAnyCollection(emMoySkladObjectTypes.CustomerOrder, _data, uuid, emMoySkladFilterTypes.uuid, _message, "")
            Select Case _result
                Case Net.HttpStatusCode.OK
                    If _data.Count > 0 Then
                        'оприходование есть
                        Return DirectCast(_data(0), customerOrder)
                    Else
                        MsgBox("Не удалось получить заказ " & uuid & " с сервера", vbCritical)
                    End If
                Case Else
                    MsgBox("Не удалось получить заказ " & uuid & " с сервера", vbCritical)
            End Select
            Return Nothing
        End Function
        ''' <summary>
        ''' запрос оприходования
        ''' </summary>
        ''' <param name="uuid"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function RequestEnterByUUID(uuid As String) As enter
            Dim _data As IEnumerable(Of Object) = Nothing
            Dim _message As String = ""
            Dim _result = Me.RequestAnyCollection(emMoySkladObjectTypes.Enter, _data, uuid, emMoySkladFilterTypes.uuid, _message, "")
            Select Case _result
                Case Net.HttpStatusCode.OK
                    If _data.Count > 0 Then
                        'оприходование есть
                        Return DirectCast(_data(0), enter)
                    Else
                        MsgBox("Не удалось получить оприходование " & uuid & " с сервера", vbCritical)
                    End If
                Case Else
                    MsgBox("Не удалось получить оприходование " & uuid & " с сервера", vbCritical)
            End Select
            Return Nothing
        End Function

        ''' <summary>
        ''' получить список рабочих оприходований
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub LoadEnters()
            Me.oWorkEnters = New List(Of enter)
            Dim _data As IEnumerable(Of Object) = Nothing
            Dim _message As String = ""
            'получить оприходование
            For Each _enteruuid In My.Settings.WorkEnterList
                Dim _new = Me.RequestEnterByUUID(_enteruuid)
                If Not _new Is Nothing Then
                    'изменено для прав доступа!
                    Dim _result = (From c In oWarehouseList Where c.uuid = _new.targetStoreUuid Select c).ToList
                    If _result.Count > 0 Then
                        Me.oWorkEnters.Add(_new)
                    End If
                End If
            Next
        End Sub

        Private oWorkLosses As List(Of loss)

        Private Sub LoadLosses()
            Me.oWorkLosses = New List(Of loss)
            Dim _data As IEnumerable(Of Object) = Nothing
            Dim _message As String = ""
            'получить оприходование
            For Each _lossuuid In My.Settings.WorkLossList
                Dim _result = Me.RequestAnyCollection(emMoySkladObjectTypes.Loss, _data, _lossuuid, emMoySkladFilterTypes.uuid, _message, "")
                Select Case _result
                    Case Net.HttpStatusCode.OK
                        If _data.Count > 0 Then
                            'оприходование есть
                            'изменено для прав доступа!
                            Dim _res = (From c In oWarehouseList Where c.uuid = CType(_data(0), loss).sourceStoreUuid Select c).ToList
                            If _res.Count > 0 Then
                                Me.oWorkLosses.Add(_data(0))
                            End If
                        Else
                            MsgBox("Не удалось получить списание " & _lossuuid & " с сервера", vbCritical)
                        End If
                    Case Else
                        MsgBox("Не удалось получить списание " & _lossuuid & " с сервера", vbCritical)
                End Select
            Next
        End Sub

        Friend Function SaveWareFile() As Boolean
            Dim _path = IO.Path.Combine(clsApplicationTypes.TemplateFolderPath, "ware.xml")
            Dim _new As New clsWareList
            _new.WareList = (From c In oWarehouseList Select New clsWareList.clsWare With {.Name = c.name, .UUID = c.uuid, .Enter = New clsWareList.clsEnter With {.Name = Me.GetEnterByWarehouseUUID(c.uuid).name, .UUID = Me.GetEnterByWarehouseUUID(c.uuid).uuid}, .Loss = New clsWareList.clsLoss With {.Name = Me.GetLossByWarehouseUUID(c.uuid).name, .UUID = Me.GetLossByWarehouseUUID(c.uuid).uuid}}).ToList

            _new.Version = "1"

            Dim _xml As Xml.Serialization.XmlSerializer = New Xml.Serialization.XmlSerializer(GetType(clsWareList))
            Dim _wrsett As New Xml.XmlWriterSettings
            Dim _xmlwriter As Xml.XmlWriter
            Dim _strBuilt As New System.Text.StringBuilder

            With _wrsett
                .Encoding = System.Text.Encoding.GetEncoding("windows-1251")
                .Indent = True
            End With

            _xmlwriter = Xml.XmlWriter.Create(_path, _wrsett)
            _xml.Serialize(_xmlwriter, _new)
            _xmlwriter.Flush()
            _xmlwriter.Close()
            Return True
        End Function

        ''' <summary>
        ''' разберет троку препараторов
        ''' </summary>
        ''' <param name="PrepString"></param>
        ''' <param name="TotalHour"></param>
        ''' <param name="TotalSalary"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function ParsePrepString(PrepString As String, ByRef TotalHour As Decimal, ByRef TotalSalary As Decimal) As Boolean
            If String.IsNullOrEmpty(PrepString) Then Return False
            Dim _preps = PrepString.Split(";".ToCharArray, System.StringSplitOptions.RemoveEmptyEntries)
            If _preps.Count = 0 Then Return False
            Dim _totalHours As Decimal = 0
            Dim _totalSalary As Decimal = 0

            For Each p In _preps
                Dim _ps = p.Split("(")
                If _ps.Length < 2 Then Return False
                If Not _ps(1).Contains("*") Then Return False

                Dim _name = _ps(0)
                If Not String.IsNullOrEmpty(_name) Then
                    Dim _hour As Decimal
                    Dim _salary As Decimal
                    Dim _out As New KeyValuePair(Of String, KeyValuePair(Of Decimal, Decimal))

                    If Decimal.TryParse(_ps(1).Split("*")(0), _hour) Then
                        If Decimal.TryParse(_ps(1).TrimEnd(")").Split("*")(1), _salary) Then
                            _out = New KeyValuePair(Of String, KeyValuePair(Of Decimal, Decimal))(_name, New KeyValuePair(Of Decimal, Decimal)(_hour, _salary))

                            _totalHours += _hour
                            _totalSalary += _salary * _hour
                        End If
                    End If
                End If
            Next
            TotalHour = _totalHours
            TotalSalary = _totalSalary
            Return True

        End Function



        ''' <summary>
        ''' чтение файла с настройками
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Friend Function ReadWareFile() As Boolean
            Dim _path = IO.Path.Combine(clsApplicationTypes.TemplateFolderPath, "ware.xml")
            If Not IO.File.Exists(_path) Then Return False


            Dim _wareList As clsWareList
            Dim xmlString As String = IO.File.ReadAllText(_path, System.Text.Encoding.GetEncoding("windows-1251"))

            Dim _xml As Xml.Serialization.XmlSerializer = New Xml.Serialization.XmlSerializer(GetType(clsWareList))
            Dim _strBuilt As IO.StringReader = New IO.StringReader(xmlString)
            Dim _xmlsettings As New Xml.XmlReaderSettings
            With _xmlsettings
                .CloseInput = True
                .IgnoreComments = True
            End With

            Dim _xreader = Xml.XmlReader.Create(_strBuilt, _xmlsettings)

            Try
                Dim _obj = _xml.Deserialize(_xreader)
                _wareList = TryCast(_obj, clsWareList)
            Catch ex As Exception
                MsgBox("Ошибка десериализации файла ware.xml: " & ex.Message, vbCritical)
                Return False
            End Try

            'разбор файла
            Me.oWorkLosses = New List(Of loss)
            Me.oWarehouseList = New List(Of warehouse)
            Me.oWorkEnters = New List(Of enter)

            Dim _dataW As IEnumerable(Of Object) = Nothing
            Dim _message As String = ""

            For Each t In _wareList.WareList
                System.Threading.Thread.Sleep(50)

                Dim _result = Me.RequestAnyCollection(clsMoyScladManager.emMoySkladObjectTypes.Warehouse, _dataW, t.Name, emMoySkladFilterTypes.name, _message)
                Select Case _result
                    Case Net.HttpStatusCode.OK
                        Select Case _dataW.Count
                            Case 0
                                'склад не найден
                                MsgBox("Cклада " & t.Name & " нет! Неправильный запрос?" & ChrW(13) & _message, vbCritical)
                            Case Is > 0
                                Dim _resW = _dataW.Cast(Of warehouse).ToList
                                If _resW.Count > 1 Then
                                    MsgBox("Запрос по имени склада вернул более одного результата!!!Повтор номера в МС, проверте номера складов и удалите дубликаты! Номер склада: " & t.Name, vbCritical)
                                    Return False
                                End If
                                Me.oWarehouseList.Add(_resW(0))
                                '========LOSS
                                'пауза
                                System.Threading.Thread.Sleep(50)
                                Dim _dataL As IEnumerable(Of Object) = Nothing
                                _result = Me.RequestAnyCollection(emMoySkladObjectTypes.Loss, _dataL, t.Loss.Name, emMoySkladFilterTypes.name, _message, "")
                                Select Case _result
                                    Case Net.HttpStatusCode.OK
                                        Dim _resL = _dataL.Cast(Of loss).ToList
                                        If _dataL.Count > 0 Then
                                            'оприходование есть
                                            If _resL.Count > 1 Then
                                                MsgBox("Запрос по имени списания вернул более одного результата!!! Повтор номера в МС, проверте номера списаний и удалите дубликаты! Номер списания: " & t.Loss.Name, vbCritical)
                                                Return False
                                            End If
                                            Me.oWorkLosses.Add(_resL(0))
                                        Else
                                            MsgBox("Не удалось получить списание " & t.Loss.Name & " с сервера", vbCritical)
                                        End If
                                    Case Else
                                        MsgBox("Не удалось получить списание " & t.Loss.Name & " с сервера", vbCritical)
                                End Select
                                '============ENTER
                                'пауза
                                System.Threading.Thread.Sleep(50)
                                Dim _dataE As IEnumerable(Of Object) = Nothing
                                _result = Me.RequestAnyCollection(emMoySkladObjectTypes.Enter, _dataE, t.Enter.Name, emMoySkladFilterTypes.name, _message, "")
                                Select Case _result
                                    Case Net.HttpStatusCode.OK
                                        If _dataE.Count > 0 Then
                                            Dim _resE = _dataE.Cast(Of enter).ToList
                                            'оприходование есть
                                            If _resE.Count > 1 Then
                                                MsgBox("Запрос по имени списания вернул более одного результата!!! Повтор номера в МС, проверте номера списаний и удалите дубликаты! Номер списания: " & t.Loss.Name, vbCritical)
                                                Return False
                                            End If
                                            Me.oWorkEnters.Add(_resE(0))
                                        Else
                                            MsgBox("Не удалось получить оприходование " & t.Enter.Name & " с сервера", vbCritical)
                                        End If
                                    Case Else
                                        MsgBox("Не удалось получить оприходование " & t.Enter.Name & " с сервера", vbCritical)
                                End Select
                        End Select
                    Case Net.HttpStatusCode.NotFound
                        'склад не найден
                        MsgBox("Cклада " & t.Name & " нет! Неправильный запрос?" & ChrW(13) & _message, vbCritical)
                        Return False
                    Case 429
                        MsgBox("Сервер перегружен запросами. Сообщите администратору и перезагрузите полностью приложение." & ChrW(13) & _message, vbCritical)
                        Return False
                    Case Else
                        'запрос вернул ошибку
                        MsgBox("запрос складов вернул ошибку. Неправильный запрос?" & ChrW(13) & _message, vbCritical)
                        Return False
                End Select
                'приостанавливает запросы - изменить в большую сторону, если появляется ошибка 429
                Thread.Sleep(100)
            Next
            Return True
        End Function

        ''' <summary>
        ''' закрузит список складов
        ''' </summary>
        ''' <remarks></remarks>
        Private Function LoadWarehouses() As Boolean
            Me.oWarehouseList = New List(Of warehouse)
            Dim _data As IEnumerable(Of Object) = Nothing
            Dim _message As String = ""
            'используем ВСЕ прописанные в сеттинге склады
            Dim _accessNames = (From c As String In My.Settings.WorkWareList Select c).ToList

            'запрос по складам
            For Each _name In _accessNames
                Dim _result = Me.RequestAnyCollection(clsMoyScladManager.emMoySkladObjectTypes.Warehouse, _data, _name, emMoySkladFilterTypes.name, _message)

                Select Case _result
                    Case Net.HttpStatusCode.OK
                        Select Case _data.Count
                            Case 0
                                'склад не найден
                                MsgBox("Cклада " & _name & " нет! Неправильный запрос?" & ChrW(13) & _message, vbCritical)
                            Case Is > 0
                                Dim _d = _data.Cast(Of warehouse).ToList
                                Debug.Assert(_d.Count = 1, "Запрос по имени склада вернул более одного результата!!!")
                                Me.oWarehouseList.Add(_d(0))
                        End Select
                    Case Net.HttpStatusCode.NotFound
                        'склад не найден
                        MsgBox("Cклада " & _name & " нет! Неправильный запрос?" & ChrW(13) & _message, vbCritical)
                    Case Else
                        'запрос вернул ошибку
                        MsgBox("запрос складов вернул ошибку. Неправильный запрос?" & ChrW(13) & _message, vbCritical)
                        Return False
                End Select
            Next
            Return True
        End Function



        ''' <summary>
        ''' список рабочих расположений (ACL включено)
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property LocationList As List(Of clsGoodLocation)
            Get
                For Each t In oLocations
                    For Each t1 In t.SlotGood
                        t1.Qty = 0
                    Next
                Next
                Dim _accessNames As New List(Of String)
                If Not Service.clsApplicationTypes.CurrentUser Is Nothing Then
                    _accessNames = Service.clsApplicationTypes.CurrentUser.UserPermission.GetAccessListByProductName("moysklad.warehouse")
                Else
                    _accessNames.Add("Внутренний Питер")
                    _accessNames.Add("Внутренний Нарва")
                End If

                Dim _new As New List(Of clsGoodLocation)
                _new.AddRange(oLocations.Where(Function(x) _accessNames.Contains(x.WarehouseName)).Select(Function(x) CType(x.Clone, clsGoodLocation)))
                For Each t In _new
                    t.LoadObjects(Me)
                Next

                Return _new
            End Get
        End Property
        ''' <summary>
        ''' вернет обьект склада
        ''' </summary>
        ''' <param name="UUID"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function GetWarehouseByUUID(UUID As String) As warehouse
            Dim _res = From c In oWarehouseList Where c.uuid.Equals(UUID) Select c
            Return _res.FirstOrDefault
        End Function

        Public Function GetEnterByWarehouseUUID(WareUUID As String) As enter
            Dim _res = (From c In oWorkEnters Where c.targetStoreUuid = WareUUID Select c).ToList

            If _res.Count > 0 Then Return _res(0)

            MsgBox("Внутренняя ошибка! Не найдено оприходование для склада " & Me.GetWarehouseByUUID(WareUUID).name, vbCritical)
            Return Nothing

        End Function

        ''' <summary>
        ''' функция конвертации суммы из валюты в валюту
        ''' </summary>
        ''' <param name="InCurrencyUUID">из валюты</param>
        ''' <param name="OutCurrencyUUID">в валюту</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function CurrencyConvert(InAmount As Decimal, InCurrencyUUID As String, OutCurrencyUUID As String) As Decimal
            Dim _in = Me.GetCurrencyByUUID(InCurrencyUUID)
            Dim _out = Me.GetCurrencyByUUID(OutCurrencyUUID)
            'в рубли по ЦБ

            Dim _inrate = clsApplicationTypes.GetRateByCurrencyCB103(_in.name)
            Dim _outrate = clsApplicationTypes.GetRateByCurrencyCB103(_out.name)
            Dim _inrur = _inrate * InAmount
            'защита
            If _outrate = 0 Then
                MsgBox("Курс " & _out.name & " установлен неверно. Проверте результат конвертации из " & _in.name & " вручную.", vbCritical)
                _outrate = 1
            End If

            Return Math.Round(_inrur / _outrate, 2)

        End Function

        ''' <summary>
        ''' создаст перемещение. sourceStoreUuid и targetStoreUuid. Ячейка назначения указывается для каждого товара в поле NewSlotName. В передаваемой структуре товара может быть заполнено поле SlotUUID или SlotName (исходная ячейка), иначе будет перемещение со склада (т.е. не из ячейки!) 
        ''' </summary>
        ''' <param name="sourceStoreUuid">источник</param>
        ''' <param name="targetStoreUuid">получатель</param>
        ''' <param name="goodList">список товаров</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function CreateMove(sourceStoreUuid As String, targetStoreUuid As String, goodList As iMoySkladDataProvider.strGoodMapQty(), Optional MoveState As iMoySkladDataProvider.emMoveState = iMoySkladDataProvider.emMoveState.empty) As iMoySkladDataProvider.clsOperationInfo
            Dim _agent = clsApplicationTypes.AuctionAgent.AGENT.Where(Function(x) x.name = "default").FirstOrDefault
            Dim _MyCompanyUUID = _agent.GetAgentID("moysklad", "MyCompanyUUID")
            Dim _moveStateUUID As String = ""
            Select Case MoveState
                Case iMoySkladDataProvider.emMoveState.empty
                    _moveStateUUID = ""
                Case iMoySkladDataProvider.emMoveState.poYacheikam
                    _moveStateUUID = _agent.GetAgentID("moysklad", "MoveState1")
                Case iMoySkladDataProvider.emMoveState.VozvratNaydennyh
                    _moveStateUUID = _agent.GetAgentID("moysklad", "MoveState2")
                    'чтобы дописать новый статус надо его занести в файл агентов, выяснить UUID по примеру документа, потом создать члена перечисления, а потом только прописать тут
            End Select

            Dim _move As New move
            Dim _moveposition As New List(Of movePosition)
            With _move
                .sourceAgentUuid = _MyCompanyUUID
                .applicable = True

                Dim _ts = From c In goodList Where Not String.IsNullOrEmpty(c.NewSlotName) Group c By c.NewSlotName Into Group
                Dim _slotname As String = ""
                If _ts.Count = 0 Then
                    _slotname = "(без размещения)"
                Else
                    For Each t In _ts
                        _slotname += String.Format("в ячейку {0}={1}поз.; ", t.NewSlotName, t.Group.Count)
                    Next
                End If

                .description = String.Format("прогр. перемещение из {0} в {1};{2}", Me.GetWarehouseByUUID(sourceStoreUuid).name, Me.GetWarehouseByUUID(targetStoreUuid).name, _slotname)
                'источник
                .sourceStoreUuid = sourceStoreUuid
                'получатель
                .targetStoreUuid = targetStoreUuid
                'статус
                .stateUuid = _moveStateUUID
            End With
            'позиции
            Dim _position As movePosition
            For Each g In goodList

                If String.IsNullOrEmpty(g.SlotUUID) AndAlso (Not String.IsNullOrEmpty(g.SlotName)) Then
                    g.SlotUUID = Me.GetSlotUUIDByName(sourceStoreUuid, g.SlotName)
                    If String.IsNullOrEmpty(g.SlotUUID) Then
                        Debug.Fail("произошла ошибка, ячейка-источник не найдена по имени")
                        g.SlotName = ""
                    End If
                End If

                If String.IsNullOrEmpty(g.NewSlotUUID) AndAlso (Not String.IsNullOrEmpty(g.NewSlotName)) Then
                    g.NewSlotUUID = Me.GetSlotUUIDByName(sourceStoreUuid, g.NewSlotName)
                    If String.IsNullOrEmpty(g.SlotUUID) Then
                        Debug.Fail("произошла ошибка, ячейка-получатель не найдена по имени")
                        g.NewSlotName = ""
                    End If
                End If

                If String.IsNullOrEmpty(g.UUID) Then
                    Dim _found As List(Of good) = Nothing
                    Dim _res = Me.FindGoods(g.code, g.ProductCode, "", _found)
                    If _res = 0 Then
                        'ошибка - не могу найти товар
                        Debug.Fail("произошла ошибка, добавляемый товар не найден по коду")
                    Else
                        g.UUID = _found(0).uuid
                    End If
                End If

                If Not String.IsNullOrEmpty(g.UUID) Then
                    _position = New movePosition
                    With _position
                        .goodUuid = g.UUID
                        .quantity = g.Qty
                        .slotUuid = IIf(String.IsNullOrEmpty(g.NewSlotUUID), Nothing, g.NewSlotUUID)
                        .sourceSlotUuid = IIf(String.IsNullOrEmpty(g.SlotUUID), Nothing, g.SlotUUID)
                    End With
                    _moveposition.Add(_position)
                End If

            Next
            _move.movePosition = _moveposition.ToArray

            'сохранить
            Dim _message As String = ""
            Dim _respond As String = ""
            Select Case Me.AddAnyToServer(clsMoyScladManager.emMoySkladObjectTypes.Move, _move, _respond, _message)
                Case Net.HttpStatusCode.OK
                    _move = clsMSObjectReader(Of move).CreatInstance(_respond)
                    If _move Is Nothing Then
                        ' MsgBox("Не удалось создать перемещение. Серверное сообщение: " & _message)
                        Return New iMoySkladDataProvider.clsOperationInfo With {.HasError = True, .ErrorMessage = "Не удалось создать перемещение. Серверное сообщение: " & _message}
                    End If
                'продолжим добавлять атрибуты
                Case Else
                    ' MsgBox("Не удалось создать перемещение. Серверное сообщение: " & _message)
                    Return New iMoySkladDataProvider.clsOperationInfo With {.HasError = True, .ErrorMessage = "Не удалось создать перемещение. Серверное сообщение: " & _message}
            End Select
            Return _move.GetMoveTrilbone(Me)
        End Function

        Function RequestFinanceInByUUID(PaymentInNameUUID As String) As iMoySkladDataProvider.clsPaymentInfo
            Dim _resultCash As New List(Of cashIn)
            Dim _resultPay As New List(Of paymentIn)
            Dim _Out As New List(Of iMoySkladDataProvider.clsPaymentInfo)
            Dim _mess As String = ""
            If Me.RequestAnyCollection(Of cashIn)(_resultCash, PaymentInNameUUID, emMoySkladFilterTypes.uuid, _mess) Then
                _Out.AddRange(_resultCash.Select(Function(x) x.GetpaymentInTrilbone(Me)))
            End If
            If Me.RequestAnyCollection(Of paymentIn)(_resultPay, PaymentInNameUUID, emMoySkladFilterTypes.uuid, _mess) Then
                _Out.AddRange(_resultPay.Select(Function(x) x.GetpaymentInTrilbone(Me)))
            End If

            Return _Out.FirstOrDefault
        End Function

        Function RequestFinanceOutByUUID(PaymentOutNameUUID As String) As iMoySkladDataProvider.clsPaymentInfo
            Dim _resultCash As New List(Of cashOut)
            Dim _resultPay As New List(Of paymentOut)
            Dim _Out As New List(Of iMoySkladDataProvider.clsPaymentInfo)
            Dim _mess As String = ""
            If Me.RequestAnyCollection(Of cashOut)(_resultCash, PaymentOutNameUUID, emMoySkladFilterTypes.uuid, _mess) Then
                _Out.AddRange(_resultCash.Select(Function(x) x.GetpaymentInTrilbone(Me)))
            End If
            If Me.RequestAnyCollection(Of paymentOut)(_resultPay, PaymentOutNameUUID, emMoySkladFilterTypes.uuid, _mess) Then
                _Out.AddRange(_resultPay.Select(Function(x) x.GetpaymentInTrilbone(Me)))
            End If
            Return _Out.FirstOrDefault
        End Function

    End Class


End Module


