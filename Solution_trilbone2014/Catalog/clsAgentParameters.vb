Imports Trilbone
Imports eBay.Service.Call
Imports eBay.Service.Core.Sdk
Imports eBay.Service.Core.Soap
Imports eBay.Service.EPS
Imports eBay.Service.Util
Imports System.Xml
Imports System.Linq
Imports System.Xml.Linq
Imports System.Configuration

''' <summary>
''' Класс управляет данными для работы с конкретным агентом
''' </summary>
<System.SerializableAttribute()> _
Public Class clsAgentEbayParameters
    ''' <summary>
    ''' Item.Title max leight
    ''' </summary>
    ''' <remarks></remarks>
    Private Const _cntMaxWorldInTitle As Integer = 80

    Private Const _cntMaxWordInSubTitle As Integer = 55

    Private Const _cntHandlingTime As Integer = 5

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

    Private oExtendedValuePack As Boolean
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
    Public Property ImageURIListForAgent As String()


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
        Dim apiCall As AddItemCall = New AddItemCall(apiContext)

        Dim fees As FeeTypeCollection

        Try
            fees = apiCall.AddItem(Item)
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

        Dim apiCall As VerifyAddItemCall = New VerifyAddItemCall(apiContext)

        Try
            Dim _fee = apiCall.VerifyAddItem(item)
            response = apiCall.ApiResponse

            ' Dim _fees As List(Of FeeType)
            Dim _errors As ErrorTypeCollection = response.Errors
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
    Private oAPIContext As ApiContext
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

        Dim item As ItemType = New ItemType()
        '---------------------------
        ' item title
        If Me.Title.Length < 5 Then
            MsgBox("Подозрительно мало символов в титуле. Должно быть от 5 до 80", vbCritical)
            _status = -1
            Return item
        ElseIf Me.Title.Length > _cntMaxWorldInTitle Then
            MsgBox("В титуле должно быть не более 80 символов!", vbCritical)
            ' Debug.Fail("В титуле должно быть не более 80 символов!")
            _status = -1
            Return item
        End If
        item.Title = Me.Title

        '-----------------------------

        ' item description тут мой html
        If Me.CurrentHTML.Length < 5 Then
            MsgBox("Подозрительно мало символов в описании. Не похоже на HTML", vbCritical)
            _status = -1
            Return item
        End If
        Dim _txt As String = " <![CDATA[" & Me.CurrentHTML & " ]]>"
        item.Description = _txt

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

        Dim _fixedPriceItem As Boolean = True

        If Me.ListingType Is Nothing Then
            MsgBox("006. Тип аукциона из файла не распознан!", vbCritical)
            _status = -1
            Return item
        End If

        Select Case Me.ListingType.value.ToLower
            Case "GTS".ToLower
                item.ListingDuration = "GTC"
                item.ListingType = ListingTypeCodeType.FixedPriceItem

            Case "Auction".ToLower
                Select Case Me.AuctionType.value.ToLower
                    Case "No Auction".ToLower
                        Debug.Fail("Ошибка логики - указано одновременно тип листинга = аукцион и тип аукциона = Нет аукциона!")
                        MsgBox("007. Тип аукциона из файла не распознан!", vbCritical)
                        _status = -1
                        Return item
                    Case "Auction 10 day".ToLower
                        item.ListingDuration = "Days_10"
                        item.ListingType = ListingTypeCodeType.Chinese
                        _fixedPriceItem = False
                    Case "Auction 7 day".ToLower
                        item.ListingDuration = "Days_7"
                        item.ListingType = ListingTypeCodeType.Chinese
                        _fixedPriceItem = False
                    Case "Auction 5 day".ToLower
                        item.ListingDuration = "Days_5"
                        item.ListingType = ListingTypeCodeType.Chinese
                        _fixedPriceItem = False
                    Case "Auction 3 day".ToLower
                        item.ListingDuration = "Days_3"
                        item.ListingType = ListingTypeCodeType.Chinese
                        _fixedPriceItem = False
                    Case "Auction 1 day".ToLower
                        'может не поставиться!!!
                        item.ListingDuration = "Days_1"
                        item.ListingType = ListingTypeCodeType.Chinese
                        _fixedPriceItem = False
                    Case Else
                        Debug.Fail("Тип аукциона из файла не распознан!")
                        MsgBox("008.Тип аукциона из файла не распознан!", vbCritical)
                        _status = -1
                        Return item
                End Select


            Case "30 day".ToLower
                item.ListingDuration = "Days_30"
                item.ListingType = ListingTypeCodeType.FixedPriceItem
            Case "10 day".ToLower
                item.ListingDuration = "Days_10"
                item.ListingType = ListingTypeCodeType.FixedPriceItem
            Case "7 day".ToLower
                item.ListingDuration = "Days_7"
                item.ListingType = ListingTypeCodeType.FixedPriceItem
            Case "5 day".ToLower
                item.ListingDuration = "Days_5"
                item.ListingType = ListingTypeCodeType.FixedPriceItem
            Case "3 day".ToLower
                item.ListingDuration = "Days_3"
                item.ListingType = ListingTypeCodeType.FixedPriceItem
            Case Else
                Debug.Fail("Тип листинга из файла не распознан!")
                MsgBox("009.Тип листинга из файла не распознан!", vbCritical)
                _status = -1
                Return item
        End Select

        '-----------------------------------------------------

        Dim _currency As CurrencyCodeType = CurrencyCodeType.USD
        'listing price
        item.Currency = _currency
        item.StartPrice = New AmountType()
        item.StartPrice.currencyID = _currency
        '------------
        If _fixedPriceItem Then
            'BUY It NOW TYPE
            Dim _result As Decimal
            If Not Decimal.TryParse(Me.PriceBuyItNow, _result) Then
                'текст не разобран
                MsgBox("Цена BuyItNow не распознается как число!!", vbCritical)
                _status = -1
                Return item
            End If

            item.StartPrice.Value = _result
            Me.oResutPrice = _result
            '----------
        Else
            'AUCTION TYPE
            Dim _result As Decimal
            If Not Decimal.TryParse(Me.PriceStart, _result) Then
                'текст не разобран
                Debug.Fail("Цена Start не распознается как число!")
                MsgBox("Цена Start не распознается как число!!", vbCritical)
                _status = -1
                Return item
            End If
            item.StartPrice.Value = _result
            Me.oResutPrice = _result
            '-----------
            If Me.PriceReserve.Length > 0 Then

                _result = 0
                If Not Decimal.TryParse(Me.PriceReserve, _result) Then
                    'текст не разобран
                    Debug.Fail("Цена Reserve не распознается как число!")
                    MsgBox("Цена Reserve не распознается как число!!", vbCritical)
                    _status = -1
                    Return item
                End If
                If _result > 0 Then
                    item.ReservePrice = New AmountType()
                    item.ReservePrice.currencyID = _currency
                    item.ReservePrice.Value = _result
                End If
            End If
            '------------
            If Me.IsBuyItNow Then
                If Me.PriceBuyItNow.Length > 0 Then

                    _result = 0
                    If Not Decimal.TryParse(Me.PriceBuyItNow, _result) Then
                        'текст не разобран
                        Debug.Fail("Цена BuyItNow не распознается как число!")
                        MsgBox("Цена BuyItNow не распознается как число!!", vbCritical)
                        _status = -1
                        Return item
                    End If
                    If _result > 0 Then
                        item.BuyItNowPrice = New AmountType()
                        item.BuyItNowPrice.currencyID = _currency
                        item.BuyItNowPrice.Value = _result
                        Me.oResutPrice = _result
                    End If
                End If
            End If
        End If

        '-------------------------------

        '*****Item.BestOfferDetails  ==  .BestOfferEnabled


        If Me.IsAcceptOffers Then
            item.BestOfferDetails = New BestOfferDetailsType With {.BestOfferEnabled = True}
        End If

        '----------------------------
        '*****Item.HitCounter = дополнительно отображает счетчик посещений
        'вижу только я
        item.HitCounter = HitCounterCodeType.HiddenStyle

        '-------------------------------------------
        ' item quality
        item.Quantity = 1

        '-----------------------------------------
        ' item location and country

        item.Location = "Narva, Ida-Virumaa"
        item.Country = CountryCodeType.EE
        '-----------------------------

        ' listing category1
        Dim category As CategoryType = New CategoryType()

        If Me.Category.agentID.Length = 0 Then
            MsgBox("Необходимо задать основную категорию eBay для листинга !!", vbCritical)
            _status = -2
            Return item
        End If

        category.CategoryID = Me.Category.agentID
        item.PrimaryCategory = category
        '-------------------------------
        ' listing category2
        category = New CategoryType()

        If (Not Me.Category2 Is Nothing) AndAlso (Not Me.Category2.agentID = "0") Then
            category.CategoryID = Me.Category.agentID
            item.SecondaryCategory = category
        End If
        '----------------------------
        ' payment methods
        item.PaymentMethods = New BuyerPaymentMethodCodeTypeCollection()
        item.PaymentMethods.Add(BuyerPaymentMethodCodeType.PayPal)
        ' email is required if paypal is used as payment method
        If Me.PayPalAccount.Length = 0 Then
            Debug.Fail("Не задан PAYPAL!")
            MsgBox("Не задан PAYPAL!", vbCritical)
            _status = -1
            Return item
        End If

        item.PayPalEmailAddress = Me.PayPalAccount

        '-----------------------------
        ' handling time is required
        '******Item.DispatchTimeMax  Specifies the maximum number of business days the seller commits to for preparing an item to be shipped after receiving a cleared payment. This time does not include the shipping time (the carrier's transit time). 

        item.DispatchTimeMax = _cntHandlingTime
        'переделать шаблон на 5 дней!!!!
        '---------------------
        'private listing
        If Me.PrivateListing Then
            item.PrivateListing = True
        Else
            item.PrivateListing = False
        End If

        '------------------------------
        '????? TODO
        ' return policy
        item.ReturnPolicy = New ReturnPolicyType()
        item.ReturnPolicy.ReturnsAcceptedOption = "ReturnsAccepted"

        '---------------------------------------------------

        '***** Item.ListingEnhancement = это за бабосы улучшения = bold и т.п.
        'Border -рамка вокруг листинга
        'Featured - full комплект
        'Highlight - подсвечен листинг
        'HomePageFeatured  = выяснить
        Dim _lecoll As New ListingEnhancementsCodeTypeCollection

        If Me.ExtendedBold Then
            _lecoll.Add(ListingEnhancementsCodeType.BoldTitle)
        End If
        If Me.ExtendedValuePack Then
            _lecoll.Add(ListingEnhancementsCodeType.ValuePackBundle)
        End If

        If _lecoll.Count > 0 Then
            item.ListingEnhancement = _lecoll
        End If

        '-------------------------------------

        '****Item.Storefront
        'Item.Storefront.StoreCategoryID() категория магазина
        Dim _st As New StorefrontType
        If (Not Me.StoreCategory Is Nothing) AndAlso (Not Me.StoreCategory.agentID = "0") Then
            _st.StoreCategoryID = Me.StoreCategory.agentID
            item.Storefront = _st
        End If
        If (Not Me.StoreCategory2 Is Nothing) AndAlso (Not Me.StoreCategory2.agentID = "0") Then
            _st.StoreCategory2ID = Me.StoreCategory.agentID
            item.Storefront = _st
        End If
        '------------------------------------

        'SubTitle
        If Me.ExtendedSubTitle Then
            If Me.SubTitle.Length > 0 Then
                item.SubTitle = Me.SubTitle
            End If
        End If
        '-----------------------
        ' item specifics
        'тут указываем страну находки, геологический возраст
        'добавить страну и возраст в формате
        'Origin country: Russia  cbCountry
        'Geological age: ordovician   cbGeologyAge
        Dim _is = BuildItemSpecifics()
        If Not (_is Is Nothing) AndAlso _is.Count > 0 Then
            item.ItemSpecifics = _is
        End If
        '------------------------------
        'Max length: 1000  Тут строим строку про препарацию и тп c rtbConditionDescription
        If Me.ConditionDescription.ToLower.Length > 0 And Me.ConditionDescription.Length < 1000 Then
            item.ConditionDescription = Me.ConditionDescription
            item.ConditionID = 0
            ' item.ConditionDisplayName = ""
        Else
            ' item condition, New   from 1000 to 1499 см ссылку в программирование// если его не указать, то локализованное имя не будет присутствовать
            item.ConditionID = 1000
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
            item.ShippingDetails = _ish
        Else
            Debug.Fail("Невовозможно задать шиппинг!")
            MsgBox("010. Невовозможно задать шиппинг!", vbCritical)
            _status = -1
            Return item
        End If
        Dim _shpkdet As New ShipPackageDetailsType
        With _shpkdet
            .MeasurementUnit = MeasurementSystemCodeType.Metric
            .WeightMajor = New MeasureType With {.measurementSystem = MeasurementSystemCodeType.English, .unit = "lbs", .Value = Me.ShippingWeightLBS}
            .WeightMinor = New MeasureType With {.measurementSystem = MeasurementSystemCodeType.English, .unit = "oz", .Value = Me.ShippingWeightOZ}
            '.ShippingPackage = ShippingPackageCodeType.Roll
        End With
        item.ShippingPackageDetails = _shpkdet

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

        If Me.ImageURIListForAgent Is Nothing OrElse Me.ImageURIListForAgent.Count = 0 Then
            'Debug.Fail("Массив путей (для Агента) фоток не задан!!")
            MsgBox("Загрузите фотографии!!! Массив путей фоток (для Агента) не задан!!", vbCritical)
            _status = -1
            Return item
        End If

        Dim _pd As New PictureDetailsType
        With _pd
            Dim _sc = New StringCollection
            _sc.AddRange(Me.ImageURIListForAgent)
            .PictureURL = _sc

            'TODO ПРОВЕРИТЬ!!!!
            .GalleryType = GalleryTypeCodeType.Plus

            .PhotoDisplay = PhotoDisplayCodeType.SuperSize
            .PhotoDisplaySpecified = True
            .PictureSource = PictureSourceCodeType.EPS
            .PictureSourceSpecified = True
        End With
        item.PictureDetails = _pd


        _status = 1
        Return item

    End Function
    ''' <summary>
    ''' Загрузит фотки. вернет список URI для привязки к листингу.
    ''' </summary>
    ''' <param name="FilePaths"></param>
    ''' <param name="pictureSetName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function UploadPictures(FilePaths As String(), pictureSetName As String) As String()
        Dim pictureService = New eBayPictureService(Me.oAPIContext)
        Dim request = New UploadSiteHostedPicturesRequestType()
        With request

            'после окончания хранить 1-30дней
            '.ExtensionInDays = 1

            'Supersize, 4-picture set. If you specify this value on input, and this value is returned in the response, then in AddItem or a related call, you must specify Item.PictureDetails.PhotoDisplay.Supersize or Item.PictureDetails.PhotoDisplay.PicturePack.
            'IMPORTANT To get the standard website image sizing with Zoom, set this field to Supersize
            ' .PictureSet = PictureSetCodeType.Standard
            '??????
            request.PictureSet = PictureSetCodeType.Large
            .PictureSetSpecified = True
            .PictureName = pictureSetName
            '.PictureUploadPolicy = PictureUploadPolicyCodeType.Add
            'водяной знак
            'Dim _w As New PictureWatermarkCodeTypeCollection
            '_w.Add(PictureWatermarkCodeType.Icon)
            '.PictureWatermark = _w

        End With

        'request.PictureName = "Deva_testimage_URL"
        '??????
        ' request.PictureSet = PictureSetCodeType.Large
        'request.PictureSetSpecified = True

        'Dim pictureList = {"C:\images\test1.jpg", "C:\images\test2.jpg", "C:\images\test3.jpg", "C:\images\test4.jpg"}
        Dim picturelist() As String = FilePaths


        'Dim _fm = New SplashScreen1
        '_fm.StartPosition = Windows.Forms.FormStartPosition.CenterParent
        '_fm.Show()
        'picturepack работает
        Dim picURLs = pictureService.UpLoadPictureFiles(PhotoDisplayCodeType.SuperSize, picturelist)

        '_fm.Hide()
        'For Each _pic In picURLs
        '    Console.WriteLine(_pic)
        'Next

        Return picURLs



    End Function


    ''' <summary>
    ''' Build sample shipping details
    ''' </summary>
    ''' <returns>ShippingDetailsType instance</returns>
    Private Function BuildShippingDetails() As ShippingDetailsType
        ' Shipping details
        Dim _shippingDetail As ShippingDetailsType = New ShippingDetailsType()

        ' sd.ApplyShippingDiscount = True
        Dim amount As AmountType = New AmountType()
        'amount.Value = 2.8
        'amount.currencyID = CurrencyCodeType.USD
        _shippingDetail.PaymentInstructions = "Will usually ship within " & _cntHandlingTime & " business days of receiving cleared payment"

        'ShippingServiceCodeType 
        'IE_StandardInternationalFlatRatePostage  Standard Int'l Flat Rate Postage
        'IE_OtherInternationalPostage   Other Int'l Postage (see description)
        'StandardInternational
        'OtherInternational

        'Item.ShippingDetails.ShippingType()
        ''*******sd.ShippingType = ShippingTypeCodeType.Free

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

        '--------------
        'http://developer.ebay.com/DevZone/guides/ebayfeatures/Development/Shipping-Services.html#SpecifyingFreeShipping
        'Тип шиппинга 
        _shippingDetail.ShippingType = ShippingTypeCodeType.Flat
        '---------------------------------
        '-----domestic
        Dim _domestic As ShippingServiceOptionsType = New ShippingServiceOptionsType()
        _domestic.ShippingService = ShippingServiceCodeType.ShippingMethodStandard.ToString
        '------Free shipping
        If Me.FreeShipping Then
            _domestic.FreeShipping = True
        End If
        amount = New AmountType()
        amount.Value = _DomesticResultCost
        amount.currencyID = CurrencyCodeType.USD
        _domestic.ShippingServiceCost = amount

        _shippingDetail.ShippingServiceOptions = New ShippingServiceOptionsTypeCollection()
        _shippingDetail.ShippingServiceOptions.Add(_domestic)
        '----------------------------------
        '----international
        Dim _international As InternationalShippingServiceOptionsType = New InternationalShippingServiceOptionsType()
        _international.ShippingService = ShippingServiceCodeType.StandardInternational.ToString
        amount = New AmountType()
        amount.Value = _InternationalResultCost
        amount.currencyID = CurrencyCodeType.USD
        _international.ShippingServiceCost = amount
        Dim _str As New StringCollection
        _str.Add("Worldwide")
        _international.ShipToLocation = _str

        _shippingDetail.InternationalShippingServiceOption = New InternationalShippingServiceOptionsTypeCollection
        _shippingDetail.InternationalShippingServiceOption.Add(_international)

        'amount = New AmountType()
        'amount.Value = 2.0
        'amount.currencyID = CurrencyCodeType.USD
        ''за каждую доп..еденицу товара
        'shippingOptions.ShippingServiceAdditionalCost = amount

        'shippingOptions.ShippingServicePriority = 1
        'amount = New AmountType()
        'amount.Value = 1.0
        'amount.currencyID = CurrencyCodeType.USD
        'shippingOptions.ShippingInsuranceCost = amount
        If (_DomesticResultCost = 0 And _InternationalResultCost = 0) Or Me.FreeShipping = True Then
            MsgBox("Шиппинг установлен как Free", vbOKOnly)
        Else
            MsgBox("Шиппинг установлен как Местный: " & _DomesticResultCost & ", Международный: " & _InternationalResultCost & " usd", vbOKOnly)
        End If

        Return _shippingDetail

    End Function


    ''' <summary>
    ''' Build sample item specifics
    ''' </summary>
    ''' <returns>ItemSpecifics object</returns>
    Private Function BuildItemSpecifics() As NameValueListTypeCollection
        ' create the content of item specifics
        Dim _input = Me.ItemSpecifics

        Dim _collSpec = _input.Split(";")

        If _collSpec.Count = 0 Then Return Nothing

        Dim nvCollection As NameValueListTypeCollection = New NameValueListTypeCollection()
        Dim nv1 As NameValueListType
        Dim nv1Col As StringCollection = New StringCollection()

        'разбить каждую
        Dim _collitem As String()

        For Each t In _collSpec
            _collitem = t.Split(":")
            If _collitem.Count > 1 Then
                nv1 = New NameValueListType()
                nv1.Name = _collitem(0)
                nv1Col = New StringCollection()
                Dim strArr1() As String = {_collitem(1)}
                nv1Col.AddRange(strArr1)
                nv1.Value = nv1Col
                nvCollection.Add(nv1)
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




    Private apiContext As ApiContext = Nothing

    ''' <summary>
    ''' Populate eBay SDK ApiContext instance with data from application configuration file
    ''' </summary>
    ''' <returns>ApiContext instance</returns>
    ''' <remarks></remarks>
    Private Function GetApiContext(agent As AUCTIONDATAAGENT) As ApiContext

        'apiContext is a singleton
        'to avoid duplicate configuration reading
        If (apiContext IsNot Nothing) Then
            Return apiContext
        Else
            apiContext = New ApiContext

            ''set Api Server Url  адрес доступа
            apiContext.SoapApiServerUrl = agent.requestURI

            'set Api Token to access eBay Api Server
            Dim apiCredential As ApiCredential = New ApiCredential

            'ключ, получаемый на eBay
            apiCredential.eBayToken = agent.token

            apiContext.ApiCredential = apiCredential
            'set eBay Site target to US
            apiContext.Site = SiteCodeType.US
            apiContext.EPSServerUrl = agent.AgentImageUploadURI
            'set Api logging
            apiContext.ApiLogManager = New ApiLogManager
            Dim fileLogger As FileLogger = New FileLogger("listing_log.txt", True, True, True)
            apiContext.ApiLogManager.ApiLoggerList.Add(fileLogger)
            Return apiContext

            'Select Case agent.account
            '    Case Is = "trilbone_test"
            '        'set Api Server Url  адрес доступа
            '        apiContext.SoapApiServerUrl = agent.requestURI
            '        'set Api Token to access eBay Api Server
            '        Dim apiCredential As ApiCredential = New ApiCredential
            '        'ключ, получаемый на eBay
            '        apiCredential.eBayToken = agent.token
            '        apiContext.ApiCredential = apiCredential
            '        'set eBay Site target to US
            '        apiContext.Site = SiteCodeType.US
            '        apiContext.EPSServerUrl = agent.AgentImageUploadURI

            '    Case Is = "trilbone"

            '        'set Api Server Url  адрес доступа
            '        apiContext.SoapApiServerUrl = My.Settings.ApiServerUrlProduction
            '        'set Api Token to access eBay Api Server
            '        Dim apiCredential As ApiCredential = New ApiCredential
            '        'ключ, получаемый на eBay
            '        apiCredential.eBayToken = My.Settings.TrilboneApiToken
            '        apiContext.ApiCredential = apiCredential
            '        'set eBay Site target to US
            '        apiContext.Site = SiteCodeType.US
            '        apiContext.EPSServerUrl = "https://api.ebay.com/ws/api.dll"



            '    Case Else
            '        Debug.Fail("Обработка аккаунта не задана")
            '        Return Nothing
            'End Select





           
        End If

    End Function






























End Class
