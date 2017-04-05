'Imports eBay.Service.Call
'Imports eBay.Service.Core.Sdk
'Imports eBay.Service.Core.Soap
'Imports eBay.Service.EPS
'Imports eBay.Service.Util

Imports System.Xml
Imports System.Linq
Imports System.Xml.Linq
Imports System.Configuration
Imports Service.com.ebay.developer
Imports Service.com.ebay


Namespace Agents
    ''' <summary>
    ''' Класс управляет данными для работы с конкретным агентом
    ''' </summary>
    <System.SerializableAttribute()>
    Public Class clsAgentEbayParameters
        ''' <summary>
        ''' Item.Title max leight
        ''' </summary>
        ''' <remarks></remarks>
        Private Const _cntMaxWorldInTitle As Integer = 80

        Private Const _cntMaxWordInSubTitle As Integer = 55

        Private Const _cntHandlingTime As Integer = 5

        Private oExtendedValuePack As Boolean

        Public ReadOnly Property CntMaxWorldCount As Integer
            Get
                Return _cntMaxWorldInTitle
            End Get
        End Property

        Public ReadOnly Property CntMaxWorldSubTitleCount As Integer
            Get
                Return _cntMaxWordInSubTitle
            End Get
        End Property

        Public Sub Clear()
            oExtendedValuePack = False
            ExtendedBold = False
            eBayUK = False
            Me.AuctionType = Nothing
            Me.Category = Nothing
            Me.Category2 = Nothing
            Me.ConditionDescription = ""
            Me.CurrentHTML = ""
            Me.ShippingDomesticCostUSD = ""
            Me.ShippingInternationalCostUSD = ""
            Me.ShippingWeightKG = ""
            Me.ShippingWeightLBS = ""
            Me.ShippingWeightOZ = ""
            Me.ShotNumber = ""
            Me.StoreCategory = Nothing
            Me.StoreCategory2 = Nothing
            Me.SubTitle = ""
        End Sub

        Public Property ExtendedValuePack As Boolean
            Get
                Return oExtendedValuePack
            End Get
            Set(value As Boolean)
                oExtendedValuePack = value
                Me.ExtendedGalleryPlus = False
                Me.SubTitle = True
                Me.ExtendedBold = False
                Me.ExtendedPicturePack = False
            End Set
        End Property


        ''' <summary>
        ''' заказать удорожитель
        ''' </summary>
        Public Property ExtendedBold As Boolean

        ''' <summary>
        ''' показать на UK за 0,5$
        ''' </summary>
        ''' <returns></returns>
        Public Property eBayUK As Boolean

        ''' <summary>
        ''' заказать удорожитель
        ''' </summary>
        Public Property ExtendedGalleryPlus As Boolean


        ''' <summary>
        ''' заказать удорожитель
        ''' </summary>
        Public Property ExtendedPicturePack As Boolean


        ''' <summary>
        ''' заказать удорожитель
        ''' </summary>
        Public Property ExtendedSubTitle As Boolean





        ''' <summary>
        ''' указывает, что листинг ставится FreeShipping
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property FreeShipping As Boolean


        ''' <summary>
        ''' указывает, что листинг ставится по типу листинга ListingType, либо задает отображение BuyItNow при аукционе
        ''' </summary>
        Public Property IsBuyItNow As Boolean

        ''' <summary>
        ''' указывает, что камень выставлен как товар с фиксированной ценой(не аукцион)
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property IsFixedPriceItem As Boolean


        ''' <summary>
        ''' может принимать предложения
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property IsAcceptOffers As Boolean


        ''' <summary>
        ''' Пары имя/значение для подробностей
        ''' </summary>
        Public Property ItemSpecifics As String


        ''' <summary>
        ''' куда получать бабос
        ''' </summary>
        Public Property PayPalAccount As String


        ''' <summary>
        ''' Цена BuyItNow
        ''' </summary>
        Public Property PriceBuyItNow As String

        ''' <summary>
        ''' вернет установленную начальную цену образца (в зависимости от листинга)(для сторонних применений)
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property ItemAmount As Decimal
            Get
                If IsFixedPriceItem Then Return Decimal.Parse(clsApplicationTypes.ReplaceDecimalSplitter(PriceBuyItNow))
                Return Decimal.Parse(clsApplicationTypes.ReplaceDecimalSplitter(PriceStart))
            End Get
        End Property

        ''' <summary>
        ''' тип листинга в виде строки (для сторонних применений)
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ItemListingTypeString As String


        ''' <summary>
        ''' Резервная цена аукциона
        ''' </summary>
        Public Property PriceReserve As String


        ''' <summary>
        ''' стартовая цена аукциона
        ''' </summary>
        Public Property PriceStart As String

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks></remarks>
        Private oResutPrice As Decimal

        ''' <summary>
        ''' это цена, установленная в процессе анализа данных шипинга. Заносится в МС.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property ResultPrice As Decimal
            Get
                Return oResutPrice
            End Get
        End Property


        ''' <summary>
        ''' Листинг будет невидим после продажи
        ''' </summary>
        Public Property PrivateListing As Boolean


        ''' <summary>
        ''' заявлено
        ''' </summary>
        Public Property ShippingDomesticCostUSD As String


        ''' <summary>
        ''' заявлено
        ''' </summary>
        Public Property ShippingInternationalCostUSD As String


        ''' <summary>
        ''' вес к рассчету шипинга в кг
        ''' </summary>
        Public Property ShippingWeightKG As String


        ''' <summary>
        ''' часть веса к рассчету шиппинга в LBS
        ''' </summary>
        Public Property ShippingWeightLBS As String


        ''' <summary>
        ''' часть веса к рассчету шиппинга  в OZ
        ''' </summary>
        Public Property ShippingWeightOZ As String


        ''' <summary>
        ''' наш короткий номер
        ''' </summary>
        Public Property ShotNumber As String


        ''' <summary>
        ''' платный SubTitle
        ''' </summary>
        Public Property SubTitle As String


        ''' <summary>
        ''' Title (как в листинге, 80 символов)
        ''' </summary>
        Public Property Title As String

        ''' <summary>
        ''' само описание
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CurrentHTML As String


        ''' <summary>
        ''' Condition description 1000max. Только состояние обьекта!!! rtbConditionDescription
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ConditionDescription As String


        ''' <summary>
        ''' Категория магазина
        ''' </summary>
        Public Property StoreCategory As AUCTIONDATAAGENTFIELDITEM


        ''' <summary>
        ''' Категория магазина 2
        ''' </summary>
        Public Property StoreCategory2 As AUCTIONDATAAGENTFIELDITEM


        ''' <summary>
        ''' тип листинга - аукцион, GTC, 30 дней и т.п.
        ''' </summary>
        Public Property ListingType As AUCTIONDATAAGENTFIELDITEM


        ' ''' <summary>
        ' ''' выбранный источник фоток для листинга (со стороны Агента)
        ' ''' </summary>
        'Public Property ImageSource As AUCTIONDATAAGENTFIELDITEM


        ' ''' <summary>
        ' ''' список путей (локальных, откуда копируем) включаемых в листинг изображений. Порядок отображения такой же, как лежать в списке.
        ' ''' </summary>
        'Public Property ImageURIList As String()

        ''' <summary>
        ''' список сетевых путей, которые предоставляются агенту как источник фото
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ImageURIList As String()


        ''' <summary>
        ''' источник фото для листинга
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ImageSource As emImageSources


        Public Enum emImageSources
            EPS = 0
            FTP = 1
        End Enum

        ''' <summary>
        ''' URI главной фотки из списка ImageURIList, иначе будет взята первая фото
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ImageMainURI As String


        ''' <summary>
        ''' Категория ebay ID  и описание
        ''' </summary>
        Public Property Category As AUCTIONDATAAGENTFIELDITEM

        ''' <summary>
        ''' Категория ebay 2 ID  и описание
        ''' </summary>
        Public Property Category2 As AUCTIONDATAAGENTFIELDITEM

        ''' <summary>
        ''' тип (время аукциона) 10дней, 7дней и т.п.
        ''' </summary>
        Public Property AuctionType As AUCTIONDATAAGENTFIELDITEM

        ''' <summary>
        ''' обьект eBAy
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property ApiContext As eBayAPIInterfaceService
            Get
                Return oAPIContext
            End Get
        End Property


        ''' <summary>
        ''' связь с агентом
        ''' </summary>
        Private ReadOnly Property Parent As AUCTIONDATAAGENT
            Get
                Return oAgent
            End Get

        End Property








        ' ''' <summary>
        ' ''' проверяет наличие фото на устройстве. Вернет список фоток, которые есть
        ' ''' </summary>
        ' ''' <param name="ImageSourceString">устройство</param>
        ' ''' <param name="ImageNamesList">проверяемый список</param>
        'Public Function CheckImages(ImageSourceString As String, ImageNamesList As String) As List(Of String)

        'End Function

        ' ''' <summary>
        ' ''' скопирует фото из архива на целевое устройство
        ' ''' </summary>
        'Public Function CopyImagesToSourceFromArhive(ImageSource As String) As Integer

        'End Function








        ''' <summary>
        ''' выставит на ebay. Прлучить итем через проверку в функции VerifyAnItem
        ''' </summary>
        ''' <param name="_fee">запрошенное fee за листинг</param>
        Public Function SendToeBay(Item As ItemType, ByRef _fee As Decimal) As Boolean
            'Dim _status As Boolean = False

            'Dim _statusBuildItem As Integer

            'Dim item As ItemType = BuildItem(_statusBuildItem)

            'If _statusBuildItem < 0 Then Return False


            'If item Is Nothing Then
            '    MsgBox("Обьект описания не построен", vbCritical)
            '    Return False
            'End If

            '[Step 3] Create Call object and execute the Call
            ' Dim apiCall As AddItemCall = New AddItemCall(oAPIContext)

            Dim apiCall As AddItemRequestType = New AddItemRequestType()
            apiCall.Version = "983"

            Dim fees As FeeType()

            Try
                '    ' Make the call to GeteBayOfficialTime
                '    Dim request As New GeteBayOfficialTimeRequestType()
                '    request.Version = "405"
                '    Dim response As GeteBayOfficialTimeResponseType = service.GeteBayOfficialTime(request)


                apiCall.Item = Item
                Dim _res = oAPIContext.AddItem(apiCall)
                fees = _res.Fees

            Catch ex As Exception
                MsgBox("При выставлении листинга eBay выдал ошибку: " & ex.Message, vbCritical)
                Return False
            End Try

            'Console.WriteLine("End to call eBay API, show call result ...")
            'Console.WriteLine()

            '[Step 4] Handle the result returned
            ' Console.WriteLine("The item was listed successfully!")
            Dim listingFee As Double = 0.0
            Dim fee As FeeType
            For Each fee In fees
                If (fee.Name = "ListingFee") Then
                    _fee = fee.Fee.Value
                End If
            Next
            'Console.WriteLine(String.Format("Listing fee is: {0}", listingFee))
            'Console.WriteLine(String.Format("Listed Item ID: {0}", item.ItemID))
            Return True


        End Function
        ''' <summary>
        ''' проверка построения итема. Проверка реакции eBAy. При нормальном листинге будет возвращен обьект и можно ставить.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function VerifyAnItem(ByRef response As VerifyAddItemResponseType, ByRef fees As List(Of FeeType)) As ItemType
            'проверка построения итема
            Dim _statusBuildItem As Integer

            Dim item As ItemType = BuildItem(_statusBuildItem)

            If _statusBuildItem < 0 OrElse item Is Nothing Then
                MsgBox("При построении листинга (Item) возникли ошибки. Проверте поля листинга", vbCritical)
                Return Nothing
            End If

            'вызов veryfi item
            'Dim _exid As New ExternalProductIDType
            '_exid.TypeSpecified = False

            ' Dim apiCall As VerifyAddItemCall = New VerifyAddItemCall(oAPIContext)
            Dim apiCall As VerifyAddItemRequestType = New VerifyAddItemRequestType()

            Try
                apiCall.Item = item

                '    ' Make the call to GeteBayOfficialTime
                '    Dim request As New GeteBayOfficialTimeRequestType()
                '    request.Version = "405"
                '    Dim response As GeteBayOfficialTimeResponseType = service.GeteBayOfficialTime(request)

                response = oAPIContext.VerifyAddItem(apiCall)

                Dim _fee = response.Fees

                ' Dim _fees As List(Of FeeType)
                Dim _errors As ErrorType() = response.Errors
                Dim _htmlmessage = response.Message


                'проверка ответа
                Select Case response.Ack
                    Case AckCodeType.Success
                        fees = (From c As FeeType In response.Fees Where (Not c.Fee Is Nothing) AndAlso c.Fee.Value > 0 Select c).ToList
                        Service.clsApplicationTypes.BeepYES()
                        Return item
                    Case AckCodeType.Warning
                        Dim _msg As String = ""
                        If Not response.Message Is Nothing Then
                            _msg += "Сообщение еБай: " & response.Message & ChrW(13)
                        End If
                        If (Not response.Errors Is Nothing) AndAlso (Not response.Errors.Count = 0) Then
                            _msg += "Получены предупреждения: " & ChrW(13)
                            For Each _err As ErrorType In response.Errors
                                _msg += "Предупреждение: " & _err.LongMessage & ChrW(13)
                            Next
                        End If
                        If (Not response.DiscountReason Is Nothing) AndAlso (Not response.DiscountReason.Count = 0) Then
                            _msg += "Получены сообщения о скидках на листинг: " & ChrW(13)
                            For Each _err As DiscountReasonCodeType In response.DiscountReason
                                _msg += "Скидка: " & _err.ToString & ChrW(13)
                            Next
                        End If

                        MsgBox("Листинг получил следующее предупреждения: " & ChrW(13) & _msg, vbInformation)
                        Return item
                    Case Else
                        MsgBox("Выставление невозможно! При проверке листинга eBay выдал ошибку: " & response.Message, vbCritical)
                        Return Nothing
                End Select
            Catch ex As Exception
                MsgBox("Выставление невозможно! При проверке листинга eBay выдал ошибку: " & ex.Message, vbCritical)
                Return Nothing
            End Try
        End Function


        Private oAgent As AUCTIONDATAAGENT
        Private oAPIContext As eBayAPIInterfaceService
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function CreateInstance(agent As AUCTIONDATAAGENT) As clsAgentEbayParameters
            Dim _new As New clsAgentEbayParameters
            _new.oAgent = agent
            'вход в аакаунт
            '[Step 1] Initialize eBay ApiContext object
            _new.oAPIContext = _new.GetApiContext(agent)
            Return _new
        End Function





        ''' <summary>
        ''' Build a sample item
        ''' </summary>
        ''' <returns>ItemType instance</returns>
        Private Function BuildItem(ByRef _status As Integer) As ItemType

            '------------------улучшения на будущее
            'Item.CrossBorderTrade  string() делает листинг доступным на других сайтах. supported by the US, UK, eBay Canada, and eBay Ireland sites
            '
            ' Item.DiscountPriceInfo = выяснить

            'Item.BuyerRequirementDetails == Item.BuyerRequirementDetails.LinkedPayPalAccount()


            'value of 0 indicates same day handling for an item

            'Item.eBayNowEligible = выяснить

            'Item.GetItFast =выяснить

            'Item.GiftIcon =выяснить



            ''Item.ListingDetails = много деталей листинга
            'Dim _ldt As New ListingDetailsType
            ''
            '_ldt.BuyItNowAvailable = True
            '_ldt.BuyItNowAvailableSpecified = True

            ''конвертация валюты на др сайтах по BuyItNow  .Value = цена для конвертации
            '_ldt.ConvertedBuyItNowPrice = New AmountType With {.Value = 1, .currencyID = CurrencyCodeType.USD}
            ''ConvertedReservePrice
            ''ConvertedStartPrice
            '_ldt.BestOfferAutoAcceptPrice = New AmountType With {.Value = 1, .currencyID = CurrencyCodeType.USD}
            ''а также можно усановить время начала листинга и др.
            'item.ListingDetails = _ldt


            'Item.ListingSubtype2.LocalMarketBestOfferOnly = General LocalMarketBestOfferOnly listing subtype



            'Item.ReturnPolicy.ReturnsAcceptedOption()


            'Item.SkypeEnabled
            '------------------

            Dim _item As ItemType = New ItemType()
            '---------------------------
            ' item title
            If Me.Title.Length < 5 Then
                MsgBox("Подозрительно мало символов в титуле. Должно быть от 5 до 80", vbCritical)
                _status = -1
                Return _item
            ElseIf Me.Title.Length > _cntMaxWorldInTitle Then
                MsgBox("В титуле должно быть не более 80 символов!", vbCritical)
                ' Debug.Fail("В титуле должно быть не более 80 символов!")
                _status = -1
                Return _item
            End If
            _item.Title = Me.Title

            '-----------------------------
            _item.SKU = Me.ShotNumber

            '----------------------------

            ' item description тут мой html
            If Me.CurrentHTML.Length < 5 Then
                MsgBox("Подозрительно мало символов в описании. Не похоже на HTML", vbCritical)
                _status = -1
                Return _item
            End If
            Dim _txt As String = " <![CDATA[" & Me.CurrentHTML & " ]]>"
            _item.Description = _txt

            '-----------------------------

            'listing type
            'FixedPriceItem = BuyItNow
            'Chinese = обычный аукцион
            'Half = выставляем книги на HALF.com
            'LeadGeneration
            'AdType - рекламный формат, eBay только сводит покупателя и продавца путем отправки формы

            'Item.LiveAuction - как обычный аукцион в режиме он-лайн. Требует регистрации участников.

            'listing duration
            'можно установить для любого листинга
            'Days_1  - имеет окраничение по категории. Надо вызвать  GetCategoryFeatures with ListingDurations included as a FeatureID value in the call request to see if the one-day listing duration is available
            'Days_3, Days_5, Days_7, Days_10 - для всех
            'Days_14, Days_60, Days_90 в основном для AdType
            'Days_21 для eBay Motors
            'Days_30, GTC Для BuyItNow

            _item.ListingSubtype2 = ListingSubtypeCodeType.LocalMarketBestOfferOnly

            IsFixedPriceItem = True
            Dim _fixedListing As Integer = ListingTypeCodeType.FixedPrice


            'если есть магазин, то надо:   eBay.Service.Core.Soap.ListingTypeCodeType.StoresFixedPrice
            'https://developer.ebay.com/DevZone/flash/docs/Reference/com/ebay/shoppingservice/ListingTypeCodeType.html#FixedPriceItem
            If Me.Parent.account = "trilbone" Then
                _fixedListing = ListingTypeCodeType.StoreInventory
            End If

            If Me.ListingType Is Nothing Then
                MsgBox("006. Тип аукциона из файла не распознан!", vbCritical)
                _status = -1
                ItemListingTypeString = "unknown"
                Return _item
            End If

            Select Case Me.ListingType.value.ToLower
                Case "GTS".ToLower
                    _item.ListingDuration = "GTC"
                    _item.ListingType = _fixedListing

                    ItemListingTypeString = "BuyItNow GTC"
                Case "Auction".ToLower
                    If Me.AuctionType Is Nothing Then
                        MsgBox("Не задана продолжительность аукциона!", vbCritical)
                        _status = -1
                        Return Nothing
                    End If

                    Select Case Me.AuctionType.value.ToLower
                        Case "No Auction".ToLower
                            Debug.Fail("Ошибка логики - указано одновременно тип листинга = аукцион и тип аукциона = Нет аукциона!")
                            MsgBox("007. Тип аукциона из файла не распознан!", vbCritical)
                            _status = -1
                            ItemListingTypeString = "unknown"
                            Return _item
                        Case "Auction 10 day".ToLower
                            _item.ListingDuration = "Days_10"
                            _item.ListingType = ListingTypeCodeType.Auction
                            IsFixedPriceItem = False
                            ItemListingTypeString = "auction 10 days"
                        Case "Auction 7 day".ToLower
                            _item.ListingDuration = "Days_7"
                            _item.ListingType = ListingTypeCodeType.Auction
                            IsFixedPriceItem = False
                            ItemListingTypeString = "auction 7 days"
                        Case "Auction 5 day".ToLower
                            _item.ListingDuration = "Days_5"
                            _item.ListingType = ListingTypeCodeType.Auction
                            IsFixedPriceItem = False
                            ItemListingTypeString = "auction 5 days"
                        Case "Auction 3 day".ToLower
                            _item.ListingDuration = "Days_3"
                            _item.ListingType = ListingTypeCodeType.Auction
                            IsFixedPriceItem = False
                            ItemListingTypeString = "auction 3 days"
                        Case "Auction 1 day".ToLower
                            'может не поставиться!!!
                            _item.ListingDuration = "Days_1"
                            _item.ListingType = ListingTypeCodeType.Auction
                            IsFixedPriceItem = False
                            ItemListingTypeString = "auction 1 days"
                        Case Else
                            Debug.Fail("Тип аукциона из файла не распознан!")
                            MsgBox("008.Тип аукциона из файла не распознан!", vbCritical)
                            ItemListingTypeString = "unknown"
                            _status = -1
                            Return _item
                    End Select


                Case "30 day".ToLower
                    _item.ListingDuration = "Days_30"
                    _item.ListingType = _fixedListing
                    ItemListingTypeString = "BuyItNow 30 days"
                Case "10 day".ToLower
                    _item.ListingDuration = "Days_10"
                    _item.ListingType = _fixedListing
                    ItemListingTypeString = "BuyItNow 10 days"
                Case "7 day".ToLower
                    _item.ListingDuration = "Days_7"
                    _item.ListingType = _fixedListing
                    ItemListingTypeString = "BuyItNow 7 days"
                Case "5 day".ToLower
                    _item.ListingDuration = "Days_5"
                    _item.ListingType = _fixedListing
                    ItemListingTypeString = "BuyItNow 5 days"
                Case "3 day".ToLower
                    _item.ListingDuration = "Days_3"
                    _item.ListingType = _fixedListing
                    ItemListingTypeString = "BuyItNow 3 days"
                Case Else
                    Debug.Fail("Тип листинга из файла не распознан!")
                    MsgBox("009.Тип листинга из файла не распознан!", vbCritical)
                    ItemListingTypeString = "unknown"
                    _status = -1
                    Return _item
            End Select

            '-----------------------------------------------------

            Dim _currency As CurrencyCodeType = CurrencyCodeType.USD
            'listing price
            _item.Currency = _currency
            _item.StartPrice = New AmountType()
            _item.StartPrice.currencyID = _currency
            '------------
            If IsFixedPriceItem Then
                'BUY It NOW TYPE
                Dim _result As Decimal
                If Not Decimal.TryParse(clsApplicationTypes.ReplaceDecimalSplitter(Me.PriceBuyItNow), _result) Then
                    'текст не разобран
                    MsgBox("Цена BuyItNow не распознается как число!!", vbCritical)
                    _status = -1
                    Return _item
                End If

                _item.StartPrice.Value = _result
                Me.oResutPrice = _result
                '----------
            Else
                'AUCTION TYPE
                Dim _result As Decimal
                If Not Decimal.TryParse(clsApplicationTypes.ReplaceDecimalSplitter(Me.PriceStart), _result) Then
                    'текст не разобран
                    Debug.Fail("Цена Start не распознается как число!")
                    MsgBox("Цена Start не распознается как число!!", vbCritical)
                    _status = -1
                    Return _item
                End If
                _item.StartPrice.Value = _result
                Me.oResutPrice = _result
                '-----------
                If Me.PriceReserve.Length > 0 Then

                    _result = 0
                    If Not Decimal.TryParse(clsApplicationTypes.ReplaceDecimalSplitter(Me.PriceReserve), _result) Then
                        'текст не разобран
                        Debug.Fail("Цена Reserve не распознается как число!")
                        MsgBox("Цена Reserve не распознается как число!!", vbCritical)
                        _status = -1
                        Return _item
                    End If
                    If _result > 0 Then
                        _item.ReservePrice = New AmountType()
                        _item.ReservePrice.currencyID = _currency
                        _item.ReservePrice.Value = _result
                    End If
                End If
                '------------
                If Me.IsBuyItNow Then
                    If Me.PriceBuyItNow.Length > 0 Then

                        _result = 0
                        If Not Decimal.TryParse(clsApplicationTypes.ReplaceDecimalSplitter(Me.PriceBuyItNow), _result) Then
                            'текст не разобран
                            Debug.Fail("Цена BuyItNow не распознается как число!")
                            MsgBox("Цена BuyItNow не распознается как число!!", vbCritical)
                            _status = -1
                            Return _item
                        End If
                        If _result > 0 Then
                            _item.BuyItNowPrice = New AmountType()
                            _item.BuyItNowPrice.currencyID = _currency
                            _item.BuyItNowPrice.Value = _result
                            Me.oResutPrice = _result
                        End If
                    End If
                End If
            End If

            '-------------------------------

            '*****Item.BestOfferDetails  ==  .BestOfferEnabled


            If Me.IsAcceptOffers Then
                _item.BestOfferDetails = New BestOfferDetailsType With {.BestOfferEnabled = True}
            End If

            '----------------------------
            '*****Item.HitCounter = дополнительно отображает счетчик посещений
            'вижу только я
            _item.HitCounter = HitCounterCodeType.HiddenStyle

            '-------------------------------------------
            ' item quality
            _item.Quantity = 1

            '-----------------------------------------
            ' item location and country

            _item.Location = "Narva, Ida-Virumaa"
            _item.Country = CountryCodeType.EE
            '-----------------------------

            ' listing category1
            Dim category As CategoryType = New CategoryType()

            If Me.Category.agentID.Length = 0 Then
                MsgBox("Необходимо задать основную категорию eBay для листинга !!", vbCritical)
                _status = -2
                Return _item
            End If

            category.CategoryID = Me.Category.agentID
            _item.PrimaryCategory = category
            '-------------------------------
            ' listing category2
            category = New CategoryType()

            If (Not Me.Category2 Is Nothing) AndAlso (Not Me.Category2.agentID = "0") Then
                category.CategoryID = Me.Category.agentID
                _item.SecondaryCategory = category
            End If
            '----------------------------
            ' payment methods
            _item.PaymentMethods = {BuyerPaymentMethodCodeType.PayPal}
            ' email is required if paypal is used as payment method
            If Me.PayPalAccount.Length = 0 Then
                Debug.Fail("Не задан PAYPAL!")
                MsgBox("Не задан PAYPAL!", vbCritical)
                _status = -1
                Return _item
            End If

            _item.PayPalEmailAddress = Me.PayPalAccount

            '-----------------------------
            ' handling time is required
            '******Item.DispatchTimeMax  Specifies the maximum number of business days the seller commits to for preparing an item to be shipped after receiving a cleared payment. This time does not include the shipping time (the carrier's transit time). 

            _item.DispatchTimeMax = _cntHandlingTime
            'переделать шаблон на 5 дней!!!!
            '---------------------
            'private listing
            If Me.PrivateListing Then
                _item.PrivateListing = True
            Else
                _item.PrivateListing = False
            End If

            '------------------------------
            '????? TODO
            '         <ReturnPolicy> ReturnPolicyType
            '  <Description> string </Description>
            '  <EAN> string </EAN>
            '  <ExtendedHolidayReturns> boolean </ExtendedHolidayReturns>
            '  <RefundOption> token </RefundOption>
            '  <RestockingFeeValueOption> token </RestockingFeeValueOption>
            '  <ReturnsAcceptedOption> token </ReturnsAcceptedOption>
            '  <ReturnsWithinOption> token </ReturnsWithinOption>
            '  <ShippingCostPaidByOption> token </ShippingCostPaidByOption>
            '  <WarrantyDurationOption> token </WarrantyDurationOption>
            '  <WarrantyOfferedOption> token </WarrantyOfferedOption>
            '  <WarrantyTypeOption> token </WarrantyTypeOption>
            '</ReturnPolicy>
            ' return policy

            _item.ReturnPolicy = New ReturnPolicyType()
            With _item.ReturnPolicy
                .ReturnsAcceptedOption = "ReturnsAccepted"
                .Description = "We accept returns within 10 days. Buyer must pay return shipping cost."
                .RefundOption = "MoneyBackOrExchange"
                .RestockingFeeValueOption = "Percent_10"
                .ReturnsWithinOption = "Days_10"
                .ShippingCostPaidByOption = "Buyer"
                '.WarrantyOfferedOption = ""
                '.WarrantyDurationOption = ""
                '.WarrantyTypeOption = ""
            End With

            '---------------------------------------------------
            '**********Cross-Border
            If Me.eBayUK Then
                ' <CrossBorderTrade>UK</CrossBorderTrade>
                '_item.CrossBorderTrade = New StringCollection
                '_item.CrossBorderTrade.Add("UK")
                _item.CrossBorderTrade = {"UK"}
            End If


            '***** Item.ListingEnhancement = это за бабосы улучшения = bold и т.п.
            'Border -рамка вокруг листинга
            'Featured - full комплект
            'Highlight - подсвечен листинг
            'HomePageFeatured  = выяснить
            Dim _lecoll As New List(Of ListingEnhancementsCodeType)

            If Me.ExtendedBold Then

                _lecoll.Add(ListingEnhancementsCodeType.BoldTitle)
            End If
            If Me.ExtendedValuePack Then
                _lecoll.Add(ListingEnhancementsCodeType.ValuePackBundle)
            End If



            If _lecoll.Count > 0 Then
                _item.ListingEnhancement = _lecoll.ToArray
            End If

            '-------------------------------------

            '****Item.Storefront
            'Item.Storefront.StoreCategoryID() категория магазина
            Dim _st As New StorefrontType
            If (Not Me.StoreCategory Is Nothing) AndAlso (Not Me.StoreCategory.agentID = "0") Then
                _st.StoreCategoryID = Me.StoreCategory.agentID
                _item.Storefront = _st
            End If
            If (Not Me.StoreCategory2 Is Nothing) AndAlso (Not Me.StoreCategory2.agentID = "0") Then
                _st.StoreCategory2ID = Me.StoreCategory.agentID
                _item.Storefront = _st
            End If
            '------------------------------------

            'SubTitle
            If Me.ExtendedSubTitle Then
                If Me.SubTitle.Length > 0 Then
                    _item.SubTitle = Me.SubTitle
                End If
            End If
            '-----------------------
            ' item specifics
            'тут указываем страну находки, геологический возраст
            'добавить страну и возраст в формате
            'Origin country: Russia  cbCountry
            'Geological age: ordovician   cbGeologyAge
            Dim _is = BuildItemSpecifics()
            If Not (_is Is Nothing) AndAlso _is.Value.Count > 0 Then
                _item.ItemSpecifics = {_is}
            End If
            '------------------------------
            'Max length: 1000  Тут строим строку про препарацию и тп c rtbConditionDescription
            If Me.ConditionDescription.ToLower.Length > 0 And Me.ConditionDescription.Length < 1000 Then
                _item.ConditionDescription = Me.ConditionDescription
                _item.ConditionID = 0
                ' item.ConditionDisplayName = ""
            Else
                ' item condition, New   from 1000 to 1499 см ссылку в программирование// если его не указать, то локализованное имя не будет присутствовать
                _item.ConditionID = 1000
            End If

            'локализовано автоматом при указании ConditionID
            'item.ConditionDisplayName = ""

            'Max length: 1000  Тут строим строку про препарацию и тп c rtbConditionDescription
            ' item.ConditionDescription = "" 'rtbConditionDescription.text

            'not use yet
            'item.ConditionDefinition = ""
            '--------------------------

            '***Item.ShippingTermsInDescription() = условия шиппинга в листинге
            ' shipping details
            Dim _ish = BuildShippingDetails()
            If Not (_ish Is Nothing) Then
                _item.ShippingDetails = _ish
                'Dim _str As New StringCollection
                '_str.Add("Worldwide")
                _item.ShipToLocations = {"Worldwide"}
                _item.ShippingTermsInDescription = True
            Else
                Debug.Fail("Невовозможно задать шиппинг!")
                MsgBox("010. Невовозможно задать шиппинг!", vbCritical)
                _status = -1
                Return _item
            End If
            Dim _shpkdet As New ShipPackageDetailsType
            With _shpkdet
                .MeasurementUnit = MeasurementSystemCodeType.Metric
                .WeightMajor = New MeasureType With {.measurementSystem = MeasurementSystemCodeType.English, .unit = "lbs", .Value = Me.ShippingWeightLBS}
                .WeightMinor = New MeasureType With {.measurementSystem = MeasurementSystemCodeType.English, .unit = "oz", .Value = Me.ShippingWeightOZ}
                '.ShippingPackage = ShippingPackageCodeType.Roll
            End With
            _item.ShippingPackageDetails = _shpkdet

            '-------------------------------

            'фотки

            'Item.PictureDetails = задаем картинки
            '.GalleryDuration= можно ограничить до 7 дней
            '.GalleryType = устанавливает тип галереи plus и т.д.  use Featured, you get all the features of Gallery and Plus
            'Do not use the GalleryURL field to specify the Gallery image.
            '****если фото на их сайте, можно установить ProductListingDetails.UseStockPhotoURLAsGallery=true

            'Dim _imgURI As String() = Nothing

            'If Me.ImageSource Is Nothing Then
            '    'Debug.Fail("Обработка " & Me.ImageSource.value & " типа устройств вывода фото не задана!")
            '    MsgBox("Не выбрано устройство - источник фото для листинга!", vbCritical)
            '    _status = -1
            '    Return item
            'End If

            If Me.ImageURIList Is Nothing OrElse Me.ImageURIList.Count = 0 Then
                'Debug.Fail("Массив путей (для Агента) фоток не задан!!")
                MsgBox("Загрузите фотографии!!! Массив путей фоток (для Агента) не задан!!", vbCritical)
                _status = -1
                Return _item
            End If

            'Dim _pdld As New ProductListingDetailsType
            'With _pdld
            '    .UseStockPhotoURLAsGallery = True
            '    .UseStockPhotoURLAsGallerySpecified = True

            'End With

            '<PictureDetails> PictureDetailsType
            '  <GalleryDuration> token </GalleryDuration>
            '  <GalleryType> GalleryTypeCodeType </GalleryType>
            '  <GalleryURL> anyURI </GalleryURL>
            '  <PhotoDisplay> PhotoDisplayCodeType </PhotoDisplay>
            '  <PictureURL> anyURI </PictureURL>
            '  <!-- ... more PictureURL values allowed here ... -->
            '</PictureDetails>
            Dim _pd As New PictureDetailsType
            With _pd

                '<GalleryURL> anyURI </GalleryURL>
                'обозначить основную фотку из списка URI
                _pd.GalleryURL = Me.ImageMainURI
                '-------------------
                'Dim _sc = New StringCollection
                '_sc.AddRange(Me.ImageURIList)
                .PictureURL = Me.ImageURIList.ToArray
                '-------------------
                'TODO ПРОВЕРИТЬ!!!!
                '  <GalleryType> GalleryTypeCodeType </GalleryType>
                '                (in/out) Adds a Gallery Plus icon to the listing. 

                'When Plus is selected in a request that specifies at least two eBay Picture Services (EPS) hosted images (using ItemType.PictureDetailsType.PictureURL), the Gallery Plus feature automatically includes a Gallery Showcase of all the listing's images. 

                'The Gallery Showcase displays when hovering over or clicking on the listing's Gallery Plus icon in the search results. The Showcase window displays a large (400px x 400px) preview image which is usually the first specified PictureURL, as well as up to 11 (64 px x 64 px) selectable thumbnails for the remaining EPS images. Clicking on the preview image displays the item's listing page. 

                'If Plus is selected and the request includes only one EPS image or any self-hosted images, the listing includes a Gallery Plus icon that, when hovered over or clicked, displays a large (400px x 400px) preview image of the item. Clicking the image displays the View Item page for that listing. 

                'When using RelistItem or ReviseItem (item has no bids and more than 12 hours before the listing's end), Plus can be unselected in the request. However, the Plus fee will still apply if a previous request selected Plus. There is at most one Plus fee per listing. 

                'When "Plus" is included in an item listing, the listing also automatically gets the Gallery functionality at no extra cost. "Gallery" does not need to be specified separately in the listing. 

                'Listing images that are originally smaller than 400px x 400px are centered in the preview frame. Images that are originally larger than 400px x 400px are scaled down to 400px on their longest side (maintaining their original aspect ratio). 

                'Not applicable to eBay Stores Inventory listings.
                .GalleryType = GalleryTypeCodeType.Plus

                '(in/out) This feature, which is free on all sites, adds a Gallery image in the search results. A Gallery image is an image that was uploaded and copied to EPS (eBay Picture Service). This copy is stored for a finite period (usually 30 days) until the image is associated with a listing. Once the image is associated with a listing, the period is extended to 90 days after the item's sale_end date and is extended again if the item is relisted or used in subsequent listings. As part of storing a copy, EPS also makes additional sizes available (thumbnail, main image, zoom layer, supersize popup, etc.), which are used by the various Gallery enhancements. 
                '''.GalleryType = GalleryTypeCodeType.Gallery
                '--------------------

                '<PhotoDisplay> PhotoDisplayCodeType </PhotoDisplay>
                '(in/out) Increase the size of each image and allow buyers to enlarge images further. Only available for site-hosted (EPS) images. Not valid for US Motors listings. For all sites that do not automatically upgrade SuperSize to PicturePack (see note below), specifying no SuperSize-qualified images is now accepted in the request. 
                .PhotoDisplay = PhotoDisplayCodeType.SuperSize
                .PhotoDisplaySpecified = True

                '.PhotoDisplay = PhotoDisplayCodeType.PicturePack
                '(in/out) Increase the number of images displayed. This is only available for images hosted with eBay. See GetCategoryFeatures and the online Help (on the eBay site) for additional information. 
                'Picture Pack applies to all sites (including US Motors), except for NL (site ID 146). You can specify a minimum of one EPS picture, or no SuperSize-qualified EPS pictures in the request. For the NL site, PicturePack is replaced with SuperSize.

                '------------------------
                Select Case Me.ImageSource
                    Case emImageSources.EPS
                        .PictureSource = PictureSourceCodeType.EPS
                    Case emImageSources.FTP
                        .PictureSource = PictureSourceCodeType.Vendor
                    Case Else
                        MsgBox("Задайте обработку члена перечисления")
                        .PictureSource = PictureSourceCodeType.EPS
                End Select

                .PictureSourceSpecified = True
                '-----------------------
            End With
            _item.PictureDetails = _pd

            _status = 1
            Return _item

        End Function
        ''' <summary>
        ''' Загрузит фотки. вернет список URI для привязки к листингу.
        ''' </summary>
        ''' <param name="FilePaths"></param>
        ''' <param name="pictureSetName"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function UploadPictures(LocalFilePaths As String(), pictureSetName As String) As String()
            'Dim pictureService = New eBayPictureService(Me.oAPIContext)
            Dim request = New UploadSiteHostedPicturesRequestType()
            With request
                '??????
                request.PictureSet = PictureSetCodeType.Large
                ' request.PictureSet = PictureSetCodeType.Supersize
                .PictureSetSpecified = True
                .PictureName = pictureSetName
                '.PictureUploadPolicy = PictureUploadPolicyCodeType.Add
                'водяной знак
                'Dim _w As New PictureWatermarkCodeTypeCollection
                '_w.Add(PictureWatermarkCodeType.Icon)
                '.PictureWatermark = _w

            End With
            Debug.Fail("Нет ")
            'UploadSiteHostedPicturesRequestType
            'пример https://developer.ebay.com/Devzone/xml/docs/Reference/ebay/types/UploadSiteHostedPicturesRequestType.html
            'https://developer.ebay.com/Devzone/xml/docs/Reference/ebay/UploadSiteHostedPictures.html
            Dim picturelist() As String = LocalFilePaths
            Dim _request = New UploadSiteHostedPicturesRequestType
            Dim _bin As New Base64BinaryType
            _bin.contentType = "JPG"
            _bin.Value = {} ' byte i
            Dim _response = oAPIContext.UploadSiteHostedPictures(_request)
            Return {_response.SiteHostedPictureDetails.ExternalPictureURL}

            'picturepack работает

            'Dim picURLs = pictureService.UpLoadPictureFiles(PhotoDisplayCodeType.SuperSize, picturelist)
            ' '' для внешних фото  Me.ImageSource = PictureSourceCodeType.Vendor
            ''
            'Me.ImageSource = PictureSourceCodeType.EPS
            'Me.ImageMainURI = picturelist(0)

            'Return picURLs
        End Function


        ''' <summary>
        ''' Build sample shipping details
        ''' </summary>
        ''' <returns>ShippingDetailsType instance</returns>
        Private Function BuildShippingDetails() As ShippingDetailsType
            ' Shipping details
            Dim _shippingDetail As ShippingDetailsType = New ShippingDetailsType()
            Dim amount As AmountType = New AmountType()

            '-----------------------
            '--проверка значений Домашний
            Dim _DomesticResultCost As Decimal
            If Not Decimal.TryParse(Me.ShippingDomesticCostUSD, _DomesticResultCost) Then
                'текст не разобран
                Debug.Fail("Цена ShippingDomesticCostUSD не распознается как число!")
                MsgBox("Цена ShippingDomesticCostUSD не распознается как число!!", vbCritical)
                Return Nothing
            End If
            '--проверка значений Интернациональный
            Dim _InternationalResultCost As Decimal
            If Not Decimal.TryParse(Me.ShippingInternationalCostUSD, _InternationalResultCost) Then
                'текст не разобран
                Debug.Fail("Цена ShippingInternationalCostUSD не распознается как число!")
                MsgBox("Цена ShippingInternationalCostUSD не распознается как число!!", vbCritical)
                Return Nothing
            End If
            'обмен значениями и корректировка стоимости
            If _DomesticResultCost = 0 Then
                _DomesticResultCost = _InternationalResultCost
            ElseIf _InternationalResultCost = 0 Then
                _InternationalResultCost = _DomesticResultCost
            End If
            '===================================
            'ShippingServiceCodeType 
            'IE_StandardInternationalFlatRatePostage  Standard Int'l Flat Rate Postage
            'IE_OtherInternationalPostage   Other Int'l Postage (see description)
            'StandardInternational
            'OtherInternational

            'Item.ShippingDetails.ShippingType()
            ''*******sd.ShippingType = ShippingTypeCodeType.Free
            '------Основные поля--------
            'http://developer.ebay.com/DevZone/guides/ebayfeatures/Development/Shipping-Services.html#SpecifyingFreeShipping

            _shippingDetail.PaymentInstructions = "Will usually ship within " & _cntHandlingTime & " business days of receiving cleared payment"
            'Тип шиппинга 
            '<ShippingType> ShippingTypeCodeType </ShippingType>
            _shippingDetail.ShippingType = ShippingTypeCodeType.Flat

            ''?????? - точно нет, вызывает ОШИБКУ!!!!
            'If Me.FreeShipping Then
            '    _shippingDetail.ShippingType = ShippingTypeCodeType.Free
            'End If

            '---------------------------------
            '---=============================--domestic
            '<ShippingServiceOptions> ShippingServiceOptionsType
            '  <FreeShipping> boolean </FreeShipping>
            '  <ShippingService> token </ShippingService>
            '  <ShippingServiceAdditionalCost currencyID="CurrencyCodeType"> AmountType (double) </ShippingServiceAdditionalCost>
            '  <ShippingServiceCost currencyID="CurrencyCodeType"> AmountType (double) </ShippingServiceCost>
            '  <ShippingServicePriority> int </ShippingServicePriority>
            '  <ShippingSurcharge currencyID="CurrencyCodeType"> AmountType (double) </ShippingSurcharge>
            '</ShippingServiceOptions>


            'https://developer.ebay.com/DevZone/flash/docs/Reference/com/ebay/shoppingservice/ShippingServiceOptionType.html
            Dim _domestic As ShippingServiceOptionsType = New ShippingServiceOptionsType()
            '  <ShippingService> token </ShippingService>
            _domestic.ShippingService = ShippingServiceCodeType.ShippingMethodStandard.ToString
            ' '' ''ShippingServiceCodeType.Other()
            ' '' ''ShippingServiceCodeType.OtherInternational()
            ' '' ''ShippingServiceCodeType.StandardInternational()
            ' '' ''ShippingServiceCodeType.StandardShippingFromOutsideUS()


            _domestic.LocalPickup = False

            '------Free shipping
            If Me.FreeShipping Then
                '  <FreeShipping> boolean </FreeShipping>
                _domestic.FreeShipping = True
            End If

            amount = New AmountType()
            amount.Value = _DomesticResultCost
            amount.currencyID = CurrencyCodeType.USD
            '  <ShippingServiceCost currencyID="CurrencyCodeType"> AmountType (double) </ShippingServiceCost>
            _domestic.ShippingServiceCost = amount

            ' _shippingDetail.ShippingServiceOptions = New ShippingServiceOptionsTypeCollection()
            _shippingDetail.ShippingServiceOptions = {_domestic}
            '----=====================================------------------------------
            '----international
            '       <InternationalShippingServiceOption> InternationalShippingServiceOptionsType
            '  <ShippingService> token </ShippingService>
            '  <ShippingServiceAdditionalCost currencyID="CurrencyCodeType"> AmountType (double) </ShippingServiceAdditionalCost>
            '  <ShippingServiceCost currencyID="CurrencyCodeType"> AmountType (double) </ShippingServiceCost>
            '  <ShippingServicePriority> int </ShippingServicePriority>
            '  <ShipToLocation> string </ShipToLocation>
            '  <!-- ... more ShipToLocation values allowed here ... -->
            '</InternationalShippingServiceOption>
            Dim _international As InternationalShippingServiceOptionsType = New InternationalShippingServiceOptionsType()

            '  <ShippingService> token </ShippingService>
            _international.ShippingService = ShippingServiceCodeType.StandardInternational.ToString

            amount = New AmountType()
            amount.Value = _InternationalResultCost
            amount.currencyID = CurrencyCodeType.USD
            ' <ShippingServiceCost currencyID="CurrencyCodeType"> AmountType (double) </ShippingServiceCost>
            _international.ShippingServiceCost = amount

            'Dim _str As New StringCollection
            '_str.Add("Worldwide")
            '  <ShipToLocation> string </ShipToLocation>
            _international.ShipToLocation = {"Worldwide"}

            '_shippingDetail.InternationalShippingServiceOption = New InternationalShippingServiceOptionsTypeCollection
            _shippingDetail.InternationalShippingServiceOption = {_international}


            If (_DomesticResultCost = 0 And _InternationalResultCost = 0) Or Me.FreeShipping = True Then
                MsgBox("Шиппинг установлен как Free", vbOKOnly)
            Else
                MsgBox("Шиппинг установлен как Местный: " & _DomesticResultCost & ", Международный: " & _InternationalResultCost & " usd", vbOKOnly)
            End If


            'страховка
            '         <InsuranceDetails> InsuranceDetailsType
            '  <InsuranceFee currencyID="CurrencyCodeType"> AmountType (double) </InsuranceFee>
            '  <InsuranceOption> InsuranceOptionCodeType </InsuranceOption>
            '</InsuranceDetails>
            '<InsuranceFee currencyID="CurrencyCodeType"> AmountType (double) </InsuranceFee>
            '<InsuranceOption> InsuranceOptionCodeType </InsuranceOption>
            '<InternationalInsuranceDetails> InsuranceDetailsType
            '  <InsuranceFee currencyID="CurrencyCodeType"> AmountType (double) </InsuranceFee>
            '  <InsuranceOption> InsuranceOptionCodeType </InsuranceOption>
            '</InternationalInsuranceDetails>

            '      'Налог с продаж
            '       <SalesTax> SalesTaxType
            '  <SalesTaxPercent> float </SalesTaxPercent>
            '  <SalesTaxState> string </SalesTaxState>
            '  <ShippingIncludedInTax> boolean </ShippingIncludedInTax>
            '</SalesTax>

            'упаковка
            '           <ShippingPackageDetails> ShipPackageDetailsType
            '  <MeasurementUnit> MeasurementSystemCodeType </MeasurementUnit>
            '  <PackageDepth unit="token" measurementSystem="MeasurementSystemCodeType"> MeasureType (decimal) </PackageDepth>
            '  <PackageLength unit="token" measurementSystem="MeasurementSystemCodeType"> MeasureType (decimal) </PackageLength>
            '  <PackageWidth unit="token" measurementSystem="MeasurementSystemCodeType"> MeasureType (decimal) </PackageWidth>
            '  <ShippingIrregular> boolean </ShippingIrregular>
            '  <ShippingPackage> ShippingPackageCodeType </ShippingPackage>
            '  <WeightMajor unit="token" measurementSystem="MeasurementSystemCodeType"> MeasureType (decimal) </WeightMajor>
            '  <WeightMinor unit="token" measurementSystem="MeasurementSystemCodeType"> MeasureType (decimal) </WeightMinor>
            '</ShippingPackageDetails>


            Return _shippingDetail

        End Function


        ''' <summary>
        ''' Build sample item specifics
        ''' </summary>
        ''' <returns>ItemSpecifics object</returns>
        Private Function BuildItemSpecifics() As NameValueListType
            ' create the content of item specifics
            Dim _input = Me.ItemSpecifics

            Dim _collSpec = _input.Split(";")

            If _collSpec.Count = 0 Then Return Nothing

            Dim nvCollection As NameValueListType = New NameValueListType
            Dim nv1 As NameValueListType
            Dim nv1Col = New List(Of String)

            'разбить каждую
            Dim _collitem As String()

            For Each t In _collSpec
                _collitem = t.Split(":")
                If _collitem.Count > 1 Then
                    nv1 = New NameValueListType()
                    nv1.Name = _collitem(0)
                    nv1Col = New List(Of String)
                    Dim strArr1() As String = {_collitem(1)}
                    nv1Col.AddRange(strArr1)
                    nv1.Value = nv1Col.ToArray
                    nvCollection.Value = nv1.Value
                    ' nvCollection.Add(nv1)
                End If
            Next

            Return nvCollection

            ''это в соотв разделе строки

            'nv1.Name = "Media"


            ''Dim strArr1() As String = {"DVD"}
            'nv1Col.AddRange(strArr1)
            'nv1.Value = nv1Col
            'nvCollection.Add(nv1)

            'Dim nv2 As NameValueListType = New NameValueListType()
            'nv2.Name = "OS"
            'Dim nv2Col As StringCollection = New StringCollection()
            'Dim strArr2() As String = {"Windows"}
            'nv2Col.AddRange(strArr2)
            'nv2.Value = nv2Col

            'nvCollection.Add(nv2)
            'Return nvCollection
        End Function




        '  Private apiContext As ApiContext = Nothing

        ''' <summary>
        ''' Populate eBay SDK ApiContext instance with data from application configuration file
        ''' </summary>
        ''' <returns>ApiContext instance</returns>
        ''' <remarks></remarks>
        Private Function GetApiContext(agent As AUCTIONDATAAGENT) As eBayAPIInterfaceService
            'http://developer.ebay.com/DevZone/XML/docs/HowTo/FirstCall/MakingCallCSharp.html
            '   Private Shared Sub Main(args As String())
            '    Dim endpoint As String = "https://api.sandbox.ebay.com/wsapi"
            '    Dim callName As String = "GeteBayOfficialTime"
            '    Dim siteId As String = "0"
            '    Dim appId As String = "yourAppId" App ID	Nordstar-c137-4c85-a1e6-e94a5b674194
            '    ' use your app ID
            '    Dim devId As String = "yourDevId" Dev ID	a4a84287-0d3c-4647-966c-53143a664c73
            '    ' use your dev ID
            '    Dim certId As String = "yourCertId" Cert ID	d34580f9-841d-4a46-bedb-f2788689b697
            '    ' use your cert ID
            '    Dim version As String = "983"
            '    ' Build the request URL
            '    Dim requestURL As String = (Convert.ToString((Convert.ToString((Convert.ToString((Convert.ToString(endpoint & Convert.ToString("?callname=")) & callName) + "&siteid=") & siteId) + "&appid=") & appId) + "&version=") & version) + "&routing=default"

            '    ' Create the service
            '    Dim service As New eBayAPIInterfaceService()
            '    ' Assign the request URL to the service locator.
            '    service.Url = requestURL
            '    ' Set credentials
            '    service.RequesterCredentials = New CustomSecurityHeaderType()
            '    service.RequesterCredentials.eBayAuthToken = "yourToken"
            '    ' use your token
            '    service.RequesterCredentials.Credentials = New UserIdPasswordType()
            '    service.RequesterCredentials.Credentials.AppId = appId
            '    service.RequesterCredentials.Credentials.DevId = devId
            '    service.RequesterCredentials.Credentials.AuthCert = certId

            '    ' Make the call to GeteBayOfficialTime
            '    Dim request As New GeteBayOfficialTimeRequestType()
            '    request.Version = "405"
            '    Dim response As GeteBayOfficialTimeResponseType = service.GeteBayOfficialTime(request)

            '    Console.WriteLine("The time at eBay headquarters in San Jose, California, USA, is:")
            '    Console.WriteLine(response.Timestamp)
            'End Sub

            Dim endpoint As String = agent.requestURI
            Dim callName As String = "GeteBayOfficialTime"
            Dim siteId As String = "0"
            Dim appId As String = "Nordstar-c137-4c85-a1e6-e94a5b674194"
            ' use your app ID
            Dim devId As String = "a4a84287-0d3c-4647-966c-53143a664c73"
            ' use your dev ID
            Dim certId As String = "d34580f9-841d-4a46-bedb-f2788689b697"
            ' use your cert ID
            Dim version As String = "983"
            ' Build the request URL
            Dim requestURL As String = (Convert.ToString((Convert.ToString((Convert.ToString((Convert.ToString(endpoint & Convert.ToString("?callname=")) & callName) + "&siteid=") & siteId) + "&appid=") & appId) + "&version=") & version) + "&routing=default"

            ' Create the service
            Dim service As New eBayAPIInterfaceService()
            ' Assign the request URL to the service locator.
            service.Url = requestURL
            ' Set credentials
            service.RequesterCredentials = New CustomSecurityHeaderType()
            service.RequesterCredentials.eBayAuthToken = agent.token
            ' use your token
            service.RequesterCredentials.Credentials = New UserIdPasswordType()
            service.RequesterCredentials.Credentials.AppId = appId
            service.RequesterCredentials.Credentials.DevId = devId
            service.RequesterCredentials.Credentials.AuthCert = certId
            Return service

            '' Make the call to GeteBayOfficialTime
            'Dim request As New GeteBayOfficialTimeRequestType()
            'request.Version = "983"
            'Dim response As GeteBayOfficialTimeResponseType = service.GeteBayOfficialTime(request)

            ''apiContext is a singleton
            ''to avoid duplicate configuration reading
            'If (oAPIContext IsNot Nothing) Then
            '    Return oAPIContext
            'Else
            '    oAPIContext = New eBayAPIInterfaceService

            '    ''set Api Server Url  адрес доступа
            '    oAPIContext.SoapApiServerUrl = agent.requestURI

            '    'set Api Token to access eBay Api Server
            '    Dim apiCredential As ApiCredential = New ApiCredential

            '    'ключ, получаемый на eBay
            '    apiCredential.eBayToken = agent.token

            '    oAPIContext.ApiCredential = apiCredential
            '    'set eBay Site target to US
            '    oAPIContext.Site = SiteCodeType.US
            '    oAPIContext.EPSServerUrl = agent.AgentImageUploadURI
            '    'set Api logging
            '    'oAPIContext.ApiLogManager = New ApiLogManager
            '    'Dim fileLogger As FileLogger = New FileLogger("listing_log.txt", True, True, True)
            '    'oAPIContext.ApiLogManager.ApiLoggerList.Add(fileLogger)
            '    Return oAPIContext
            'End If

        End Function






























    End Class

End Namespace
