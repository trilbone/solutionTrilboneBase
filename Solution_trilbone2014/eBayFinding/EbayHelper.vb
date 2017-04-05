    Friend Class EbayHelper



    Friend Shared APP_ID As String = "Nordstar-c137-4c85-a1e6-e94a5b674194"
    Friend Shared NS As XNamespace = "http://www.ebay.com/marketplace/search/v1/services"
    ' Private Shared orgQuery As String = ""

    Friend Shared Function GetWebQuery(criteria As EbaySearchCriteria, Optional PageNumber As Integer = 1) As List(Of eBayFindingServiceReference.SearchItem)
        If criteria Is Nothing Then
            Throw New ArgumentNullException("criteria")
        End If

        Return GetItems(criteria, BuildQuery(criteria), True).ToList
    End Function


    Private Shared Function BuildQuery(criteria As EbaySearchCriteria, Optional PageNumber As Integer = 1) As String
        If criteria Is Nothing Then
            Throw New ArgumentNullException("criteria")
        End If
        Dim endpoint As String = "http://svcs.ebay.com/services/search/FindingService/v1?"
        Dim CALLNAME As String = "findItemsAdvanced"

        Dim VERSION As String = "1.0.0"
        Dim _query = String.Format("{0}OPERATION-NAME={1}&SERVICE-VERSION={2}&SECURITY-APPNAME={3}&RESPONSE-DATA-FORMAT=XML&REST-PAYLOAD=true&paginationInput.pageNumber={4}{5}", endpoint, CALLNAME, VERSION, APP_ID, PageNumber.ToString, criteria.ToString())
        Return _query
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="itemID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Shared Function GetSingleItem(itemID As String) As XElement
        Dim itemendpoint As String = "http://open.api.ebay.com/shopping?"
        Dim itemquery As String = String.Format("{0}callname=GetSingleItem&responseencoding=XML&appid={1}&siteid=0&version=515&ItemID={2}&IncludeSelector=Description,ItemSpecifics", itemendpoint, APP_ID, itemID)
        Dim root As XElement = XElement.Load(itemquery)

        Dim errorsEl As IEnumerable(Of XElement)

        Dim index As Integer

        errorsEl = root.Descendants(NS + "error")

        If errorsEl.Count() > 0 Then
            index = 0

            For Each err As XElement In errorsEl
                index += 1
            Next

            'throw new EbayErrorException("Error", errors);
            Return XElement.Parse("<error><notfound/></error>")
        End If

        Return root

    End Function


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="criteria"></param>
    ''' <param name="query"></param>
    ''' <param name="firstTime"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function GetItems(criteria As EbaySearchCriteria, query As String, firstTime As Boolean) As IEnumerable(Of eBayFindingServiceReference.SearchItem)
        Dim root As XElement, itemArray As XElement
        Dim errorsEl As IEnumerable(Of XElement)
        Dim numItems As Integer
        Dim query2 As String
        Dim splitChar As Char() = New Char() {"|"c}

        root = XElement.Load(query)



        errorsEl = root.Descendants(NS + "error")

        If errorsEl.Count() > 0 Then
            ''запрос вернул ошибку
            Throw New ApplicationException
        End If



        If (InlineAssignHelper(numItems, Integer.Parse(root.Element(NS + "searchResult").Attribute("count").Value))) = 0 Then
            Return New eBayFindingServiceReference.SearchItem() {}
        End If

        'это массив элементов
        itemArray = root.Element(NS + "searchResult")



        'Dim items = From it In itemArray.Descendants(NS + "item") Select EbayItem.Parse(it)

        Dim items = From it In itemArray.Descendants(NS + "item") Select clsFindingService.clsMSObjectReader(Of eBayFindingServiceReference.SearchItem).CreatInstance(it.ToString)

        ' Dim _result = From c In _respond Select clsMSObjectReader(Of eBayFindingServiceReference.SearchItem).CreatInstance(c.XML)
        ' item.XML = root.ToString()



        If firstTime Then
            Dim _pages = Integer.Parse(root.Element(NS + "paginationOutput").Element(NS + "totalPages").Value)
            If _pages > 1 Then
                For i As Integer = 2 To _pages
                    query2 = BuildQuery(criteria, i)
                    items = items.Union(GetItems(criteria, query2, False))
                Next
            End If
        End If

        Return items
    End Function


    'Public Shared Function BuildQuery(criteria As EbaySearchCriteria) As String
    '    Return criteria.ToString()
    'End Function

    Private Shared Function InlineAssignHelper(Of T)(ByRef target As T, value As T) As T
        target = value
        Return value
    End Function
End Class



Friend Class EbaySearchCriteria
    Friend Sub New()
        BidCountMax = -1
        BidCountMin = -1
        FeedbackScoreMax = -1
        FeedbackScoreMin = -1
        BuyItNowPriceMax = -1
        BuyItNowPriceMin = -1
        PriceMax = -1
        PriceMin = -1
        Condition = Condition.Empty
        Description = ""
        Title = ""
        Categories = ""
        Keywords = ""
        StartTimeMax = DateTime.MaxValue
        StartTimeMin = DateTime.MinValue
        EndTimeMax = DateTime.MaxValue
        EndTimeMin = DateTime.MinValue
    End Sub

    ' query

    Public Property BidCountMax() As Integer
        Get
            Return m_BidCountMax
        End Get
        Set(value As Integer)
            m_BidCountMax = Value
        End Set
    End Property
    Private m_BidCountMax As Integer
    Public Property BidCountMin() As Integer
        Get
            Return m_BidCountMin
        End Get
        Set(value As Integer)
            m_BidCountMin = Value
        End Set
    End Property
    Private m_BidCountMin As Integer
    Public Property PriceMax() As Double
        Get
            Return m_PriceMax
        End Get
        Set(value As Double)
            m_PriceMax = Value
        End Set
    End Property
    Private m_PriceMax As Double
    Public Property PriceMin() As Double
        Get
            Return m_PriceMin
        End Get
        Set(value As Double)
            m_PriceMin = Value
        End Set
    End Property
    Private m_PriceMin As Double
    Public Property Condition() As Condition
        Get
            Return m_Condition
        End Get
        Set(value As Condition)
            m_Condition = Value
        End Set
    End Property
    Private m_Condition As Condition
    Public Property FeedbackScoreMax() As Integer
        Get
            Return m_FeedbackScoreMax
        End Get
        Set(value As Integer)
            m_FeedbackScoreMax = Value
        End Set
    End Property
    Private m_FeedbackScoreMax As Integer
    ' da gestire
    Public Property FeedbackScoreMin() As Integer
        Get
            Return m_FeedbackScoreMin
        End Get
        Set(value As Integer)
            m_FeedbackScoreMin = Value
        End Set
    End Property
    Private m_FeedbackScoreMin As Integer
    ' da gestire
    Public Property Keywords() As String
        Get
            Return m_Keywords
        End Get
        Set(value As String)
            m_Keywords = Value
        End Set
    End Property
    Private m_Keywords As String

    ' gestisco io

    Public Property BuyItNowPriceMax() As Double
        Get
            Return m_BuyItNowPriceMax
        End Get
        Set(value As Double)
            m_BuyItNowPriceMax = Value
        End Set
    End Property
    Private m_BuyItNowPriceMax As Double
    Public Property BuyItNowPriceMin() As Double
        Get
            Return m_BuyItNowPriceMin
        End Get
        Set(value As Double)
            m_BuyItNowPriceMin = Value
        End Set
    End Property
    Private m_BuyItNowPriceMin As Double
    Public Property Categories() As String
        Get
            Return m_Categories
        End Get
        Set(value As String)
            m_Categories = Value
        End Set
    End Property
    Private m_Categories As String
    Public Property Description() As String
        Get
            Return m_Description
        End Get
        Set(value As String)
            m_Description = Value
        End Set
    End Property
    Private m_Description As String
    Public Property EndTimeMax() As DateTime
        Get
            Return m_EndTimeMax
        End Get
        Set(value As DateTime)
            m_EndTimeMax = Value
        End Set
    End Property
    Private m_EndTimeMax As DateTime
    Public Property EndTimeMin() As DateTime
        Get
            Return m_EndTimeMin
        End Get
        Set(value As DateTime)
            m_EndTimeMin = Value
        End Set
    End Property
    Private m_EndTimeMin As DateTime
    'public ListingStatusCodeType ListingStatus { get; set; } // vedi IncludeSelecotr
    'public ShippingCostSummaryType ShippingCostSummary { get; set; } // vedi IncludeSelector 
    Public Property StartTimeMax() As DateTime
        Get
            Return m_StartTimeMax
        End Get
        Set(value As DateTime)
            m_StartTimeMax = Value
        End Set
    End Property
    Private m_StartTimeMax As DateTime
    Public Property StartTimeMin() As DateTime
        Get
            Return m_StartTimeMin
        End Get
        Set(value As DateTime)
            m_StartTimeMin = Value
        End Set
    End Property
    Private m_StartTimeMin As DateTime
    'public string TimeLeftMax { get; set; }
    'public string TimeLeftMin { get; set; }
    Public Property Title() As String
        Get
            Return m_Title
        End Get
        Set(value As String)
            m_Title = Value
        End Set
    End Property
    Private m_Title As String
    'public CountryCodeType Country { get; set; }
    'public string Location { get; set; }

    'public bool GetItFast { get; set; }
    'public BuyerPaymentMethodCodeType PaymentMethods { get; set; }


    ' IncludeSelector=Details --> Country
    ' IncludeSelector=SearchDetails --> Location

    Public Overrides Function ToString() As String
        Dim ret As String = ""
        Dim queryKeywords As String = ""
        'string includeSelector = "";
        Dim keys As String()

        If Keywords <> "" Then
            keys = Keywords.Split(New Char() {" "}, StringSplitOptions.RemoveEmptyEntries)

            For Each key As String In keys
                queryKeywords += key & Convert.ToString("%20")
            Next

            queryKeywords = queryKeywords.Remove(queryKeywords.Length - 3, 3)

            ret += String.Format("&keywords={0}", queryKeywords)
        End If
        If BidCountMin <> -1 Then
            ret += String.Format("&BidCountMin={0}", BidCountMin)
        End If
        If BidCountMax <> -1 Then
            ret += String.Format("&BidCountMax={0}", BidCountMax)
        End If
        If PriceMin <> -1 Then
            ret += String.Format("&PriceMin.Value={0}", PriceMin)
        End If
        If PriceMax <> -1 Then
            ret += String.Format("&PriceMax.Value={0}", PriceMax)
        End If
        If FeedbackScoreMin <> -1 Then
            ret += String.Format("&FeedbackScoreMin={0}", FeedbackScoreMin)
        End If
        If FeedbackScoreMax <> -1 Then
            ret += String.Format("&FeedbackScoreMax={0}", FeedbackScoreMax)
        End If
        If Condition <> Condition.Empty Then
            ret += String.Format("&Condition={0}", Condition.ToString())
        End If
        If Categories <> "" Then
            ret += String.Format("&categoryId={0}", Categories)
        End If

        ' IncludeSelector

        'if (Country != CountryCodeType.CustomCode)
        '                includeSelector += "Details,";
        '            if (Location != "")
        '                includeSelector += "SearchDetails";
        '
        '            if (includeSelector != "" && includeSelector[includeSelector.Length - 1] == ',')
        '                includeSelector = includeSelector.Remove(includeSelector.Length - 2, 1);
        '
        '            if (includeSelector != "")
        '                ret += string.Format("&IncludeSelector={0}", includeSelector);


        Return ret
    End Function
End Class


Public Enum Condition
    [New]
    Used
    Empty
End Enum

'Public Class EbayItem
'    Public Property BuyItNowAvailable() As Boolean
'        Get
'            Return m_BuyItNowAvailable
'        End Get
'        Set(value As Boolean)
'            m_BuyItNowAvailable = Value
'        End Set
'    End Property
'    Private m_BuyItNowAvailable As Boolean
'    Public Property BuyItNowPrice() As Double
'        Get
'            Return m_BuyItNowPrice
'        End Get
'        Set(value As Double)
'            m_BuyItNowPrice = Value
'        End Set
'    End Property
'    Private m_BuyItNowPrice As Double
'    Public Property BidCount() As Integer
'        Get
'            Return m_BidCount
'        End Get
'        Set(value As Integer)
'            m_BidCount = Value
'        End Set
'    End Property
'    Private m_BidCount As Integer
'    Public Property Categories() As String
'        Get
'            Return m_Categories
'        End Get
'        Set(value As String)
'            m_Categories = Value
'        End Set
'    End Property
'    Private m_Categories As String
'    Public Property Condition() As Condition
'        Get
'            Return m_Condition
'        End Get
'        Set(value As Condition)
'            m_Condition = Value
'        End Set
'    End Property
'    Private m_Condition As Condition
'    Public Property CurrentPrice() As Double
'        Get
'            Return m_CurrentPrice
'        End Get
'        Set(value As Double)
'            m_CurrentPrice = Value
'        End Set
'    End Property
'    Private m_CurrentPrice As Double
'    Public Property Description() As String
'        Get
'            Return m_Description
'        End Get
'        Set(value As String)
'            m_Description = Value
'        End Set
'    End Property
'    Private m_Description As String
'    Public Property EndTime() As DateTime
'        Get
'            Return m_EndTime
'        End Get
'        Set(value As DateTime)
'            m_EndTime = Value
'        End Set
'    End Property
'    Private m_EndTime As DateTime
'    Public Property ItemID() As String
'        Get
'            Return m_ItemID
'        End Get
'        Set(value As String)
'            m_ItemID = Value
'        End Set
'    End Property
'    Private m_ItemID As String
'    Public Property ListingStatus() As ListingStatusCodeType
'        Get
'            Return m_ListingStatus
'        End Get
'        Set(value As ListingStatusCodeType)
'            m_ListingStatus = Value
'        End Set
'    End Property
'    Private m_ListingStatus As ListingStatusCodeType
'    Public Property ListingType() As ListingTypeCodeType
'        Get
'            Return m_ListingType
'        End Get
'        Set(value As ListingTypeCodeType)
'            m_ListingType = Value
'        End Set
'    End Property
'    Private m_ListingType As ListingTypeCodeType
'    Public Property Location() As String
'        Get
'            Return m_Location
'        End Get
'        Set(value As String)
'            m_Location = Value
'        End Set
'    End Property
'    Private m_Location As String
'    Public Property PictureExists() As Boolean
'        Get
'            Return m_PictureExists
'        End Get
'        Set(value As Boolean)
'            m_PictureExists = Value
'        End Set
'    End Property
'    Private m_PictureExists As Boolean
'    Public Property PictureURL() As String()
'        Get
'            Return m_PictureURL
'        End Get
'        Set(value As String())
'            m_PictureURL = Value
'        End Set
'    End Property
'    Private m_PictureURL As String()
'    Public Property StartTime() As DateTime
'        Get
'            Return m_StartTime
'        End Get
'        Set(value As DateTime)
'            m_StartTime = Value
'        End Set
'    End Property
'    Private m_StartTime As DateTime
'    Public Property TimeLeft() As String
'        Get
'            Return m_TimeLeft
'        End Get
'        Set(value As String)
'            m_TimeLeft = Value
'        End Set
'    End Property
'    Private m_TimeLeft As String
'    Public Property Title() As String
'        Get
'            Return m_Title
'        End Get
'        Set(value As String)
'            m_Title = Value
'        End Set
'    End Property
'    Private m_Title As String
'    Public Property XML() As String
'        Get
'            Return m_XML
'        End Get
'        Set(value As String)
'            m_XML = Value
'        End Set
'    End Property
'    Private m_XML As String
'    Public Property Country() As CountryCodeType
'        Get
'            Return m_Country
'        End Get
'        Set(value As CountryCodeType)
'            m_Country = Value
'        End Set
'    End Property
'    Private m_Country As CountryCodeType

'    Public Overrides Function ToString() As String
'        Dim price As Double = (If(BuyItNowAvailable, BuyItNowPrice, CurrentPrice))

'        Return String.Format("Title={0}" & vbLf & vbCr & "ItemID={1}" & vbLf & vbCr & "Price={2}" & vbLf & vbCr & "EndTime={3}" & vbLf & vbCr, Title, ItemID, price, EndTime)
'    End Function

'    Public Shared Function Parse(root As XElement) As EbayItem
'        Dim el As XElement
'        Dim buyItNow As Boolean

'        If root Is Nothing Then
'            Throw New ArgumentNullException("root")
'        End If

'        Dim ns As XNamespace = "http://www.ebay.com/marketplace/search/v1/services"
'        Dim item As New EbayItem()

'        item.Title = ""
'        item.Description = ""
'        item.CurrentPrice = -1
'        item.BuyItNowPrice = -1
'        item.BidCount = -1

'        buyItNow = (If(root.Element(ns + "listingInfo").Element(ns + "buyItNowAvailable") IsNot Nothing, Boolean.Parse(root.Element(ns + "listingInfo").Element(ns + "buyItNowAvailable").Value), False))

'        If buyItNow Then
'            If (InlineAssignHelper(el, root.Element(ns + "buyItNowPrice"))) IsNot Nothing Then
'                item.BuyItNowPrice = Double.Parse(el.Element(ns + "value").Value)
'            ElseIf (InlineAssignHelper(el, root.Element(ns + "convertedBuyItNowPrice"))) IsNot Nothing Then
'                item.BuyItNowPrice = Double.Parse(el.Value)
'            End If
'        End If

'        Dim en As New System.Globalization.CultureInfo("en-US")
'        If (InlineAssignHelper(el, root.Element(ns + "sellingStatus").Element(ns + "currentPrice"))) IsNot Nothing Then
'            item.CurrentPrice = Double.Parse(el.Value, en.NumberFormat)
'        ElseIf (InlineAssignHelper(el, root.Element(ns + "sellingStatus").Element(ns + "convertedCurrentPrice"))) IsNot Nothing Then

'            item.CurrentPrice = Double.Parse(el.Value, en.NumberFormat)
'        End If

'        item.Categories = root.Element(ns + "primaryCategory").Element(ns + "categoryId").Value
'        item.ItemID = root.Element(ns + "itemId").Value
'        item.EndTime = DateTime.Parse(root.Element(ns + "listingInfo").Element(ns + "endTime").Value)
'        item.ListingType = DirectCast([Enum].Parse(GetType(ListingTypeCodeType), root.Element(ns + "listingInfo").Element(ns + "listingType").Value), ListingTypeCodeType)
'        item.ListingStatus = DirectCast([Enum].Parse(GetType(ListingStatusCodeType), root.Element(ns + "sellingStatus").Element(ns + "sellingState").Value), ListingStatusCodeType)
'        item.TimeLeft = root.Element(ns + "sellingStatus").Element(ns + "timeLeft").Value
'        item.Title = root.Element(ns + "title").Value

'        If (item.ListingType = ListingTypeCodeType.Auction) Or (item.ListingType = ListingTypeCodeType.AuctionWithBIN) Then
'            item.BidCount = Integer.Parse(root.Element(ns + "sellingStatus").Element(ns + "bidCount").Value)
'        End If

'        If (InlineAssignHelper(el, root.Element(ns + "primaryCategoryName"))) IsNot Nothing Then
'            item.Categories = el.Value
'        End If

'        ' ShippingCostSummary

'        item.XML = root.ToString()

'        Return item
'    End Function
'    Private Shared Function InlineAssignHelper(Of T)(ByRef target As T, value As T) As T
'        target = value
'        Return value
'    End Function
'End Class

Public Enum ListingTypeCodeType

    ''' ok<remarks/>
    Unknown
    AdFormat
    Auction
    AuctionWithBIN
    Classified
    FixedPrice
    StoreInventory
    All
End Enum

Public Enum ListingStatusCodeType

    ''' <remarks/>
    Active

    ''' <remarks/>
    Ended

    ''' <remarks/>
    Completed

    ''' <remarks/>
    CustomCode
End Enum


Public Enum CountryCodeType

    ''' <remarks/>
    AF

    ''' <remarks/>
    AL

    ''' <remarks/>
    DZ

    ''' <remarks/>
    [AS]

    ''' <remarks/>
    AD

    ''' <remarks/>
    AO

    ''' <remarks/>
    AI

    ''' <remarks/>
    AQ

    ''' <remarks/>
    AG

    ''' <remarks/>
    AR

    ''' <remarks/>
    AM

    ''' <remarks/>
    AW

    ''' <remarks/>
    AU

    ''' <remarks/>
    AT

    ''' <remarks/>
    AZ

    ''' <remarks/>
    BS

    ''' <remarks/>
    BH

    ''' <remarks/>
    BD

    ''' <remarks/>
    BB

    ''' <remarks/>
    BY

    ''' <remarks/>
    BE

    ''' <remarks/>
    BZ

    ''' <remarks/>
    BJ

    ''' <remarks/>
    BM

    ''' <remarks/>
    BT

    ''' <remarks/>
    BO

    ''' <remarks/>
    BA

    ''' <remarks/>
    BW

    ''' <remarks/>
    BV

    ''' <remarks/>
    BR

    ''' <remarks/>
    IO

    ''' <remarks/>
    BN

    ''' <remarks/>
    BG

    ''' <remarks/>
    BF

    ''' <remarks/>
    BI

    ''' <remarks/>
    KH

    ''' <remarks/>
    CM

    ''' <remarks/>
    CA

    ''' <remarks/>
    CV

    ''' <remarks/>
    KY

    ''' <remarks/>
    CF

    ''' <remarks/>
    TD

    ''' <remarks/>
    CL

    ''' <remarks/>
    CN

    ''' <remarks/>
    CX

    ''' <remarks/>
    CC

    ''' <remarks/>
    CO

    ''' <remarks/>
    KM

    ''' <remarks/>
    CG

    ''' <remarks/>
    CD

    ''' <remarks/>
    CK

    ''' <remarks/>
    CR

    ''' <remarks/>
    CI

    ''' <remarks/>
    HR

    ''' <remarks/>
    CU

    ''' <remarks/>
    CY

    ''' <remarks/>
    CZ

    ''' <remarks/>
    DK

    ''' <remarks/>
    DJ

    ''' <remarks/>
    DM

    ''' <remarks/>
    [DO]

    ''' <remarks/>
    TP

    ''' <remarks/>
    EC

    ''' <remarks/>
    EG

    ''' <remarks/>
    SV

    ''' <remarks/>
    GQ

    ''' <remarks/>
    ER

    ''' <remarks/>
    EE

    ''' <remarks/>
    ET

    ''' <remarks/>
    FK

    ''' <remarks/>
    FO

    ''' <remarks/>
    FJ

    ''' <remarks/>
    FI

    ''' <remarks/>
    FR

    ''' <remarks/>
    GF

    ''' <remarks/>
    PF

    ''' <remarks/>
    TF

    ''' <remarks/>
    GA

    ''' <remarks/>
    GM

    ''' <remarks/>
    GE

    ''' <remarks/>
    DE

    ''' <remarks/>
    GH

    ''' <remarks/>
    GI

    ''' <remarks/>
    GR

    ''' <remarks/>
    GL

    ''' <remarks/>
    GD

    ''' <remarks/>
    GP

    ''' <remarks/>
    GU

    ''' <remarks/>
    GT

    ''' <remarks/>
    GN

    ''' <remarks/>
    GW

    ''' <remarks/>
    GY

    ''' <remarks/>
    HT

    ''' <remarks/>
    HM

    ''' <remarks/>
    VA

    ''' <remarks/>
    HN

    ''' <remarks/>
    HK

    ''' <remarks/>
    HU

    ''' <remarks/>
    [IS]

    ''' <remarks/>
    [IN]

    ''' <remarks/>
    ID

    ''' <remarks/>
    IR

    ''' <remarks/>
    IQ

    ''' <remarks/>
    IE

    ''' <remarks/>
    IL

    ''' <remarks/>
    IT

    ''' <remarks/>
    JM

    ''' <remarks/>
    JP

    ''' <remarks/>
    JO

    ''' <remarks/>
    KZ

    ''' <remarks/>
    KE

    ''' <remarks/>
    KI

    ''' <remarks/>
    KP

    ''' <remarks/>
    KR

    ''' <remarks/>
    KW

    ''' <remarks/>
    KG

    ''' <remarks/>
    LA

    ''' <remarks/>
    LV

    ''' <remarks/>
    LB

    ''' <remarks/>
    LS

    ''' <remarks/>
    LR

    ''' <remarks/>
    LY

    ''' <remarks/>
    LI

    ''' <remarks/>
    LT

    ''' <remarks/>
    LU

    ''' <remarks/>
    MO

    ''' <remarks/>
    MK

    ''' <remarks/>
    MG

    ''' <remarks/>
    MW

    ''' <remarks/>
    MY

    ''' <remarks/>
    MV

    ''' <remarks/>
    ML

    ''' <remarks/>
    MT

    ''' <remarks/>
    MH

    ''' <remarks/>
    MQ

    ''' <remarks/>
    MR

    ''' <remarks/>
    MU

    ''' <remarks/>
    YT

    ''' <remarks/>
    MX

    ''' <remarks/>
    FM

    ''' <remarks/>
    MD

    ''' <remarks/>
    MC

    ''' <remarks/>
    MN

    ''' <remarks/>
    MS

    ''' <remarks/>
    MA

    ''' <remarks/>
    MZ

    ''' <remarks/>
    MM

    ''' <remarks/>
    NA

    ''' <remarks/>
    NR

    ''' <remarks/>
    NP

    ''' <remarks/>
    NL

    ''' <remarks/>
    AN

    ''' <remarks/>
    NC

    ''' <remarks/>
    NZ

    ''' <remarks/>
    NI

    ''' <remarks/>
    NE

    ''' <remarks/>
    NG

    ''' <remarks/>
    NU

    ''' <remarks/>
    NF

    ''' <remarks/>
    MP

    ''' <remarks/>
    NO

    ''' <remarks/>
    OM

    ''' <remarks/>
    PK

    ''' <remarks/>
    PW

    ''' <remarks/>
    PS

    ''' <remarks/>
    PA

    ''' <remarks/>
    PG

    ''' <remarks/>
    PY

    ''' <remarks/>
    PE

    ''' <remarks/>
    PH

    ''' <remarks/>
    PN

    ''' <remarks/>
    PL

    ''' <remarks/>
    PT

    ''' <remarks/>
    PR

    ''' <remarks/>
    QA

    ''' <remarks/>
    RE

    ''' <remarks/>
    RO

    ''' <remarks/>
    RU

    ''' <remarks/>
    RW

    ''' <remarks/>
    SH

    ''' <remarks/>
    KN

    ''' <remarks/>
    LC

    ''' <remarks/>
    PM

    ''' <remarks/>
    VC

    ''' <remarks/>
    WS

    ''' <remarks/>
    SM

    ''' <remarks/>
    ST

    ''' <remarks/>
    SA

    ''' <remarks/>
    SN

    ''' <remarks/>
    SC

    ''' <remarks/>
    SL

    ''' <remarks/>
    SG

    ''' <remarks/>
    SK

    ''' <remarks/>
    SI

    ''' <remarks/>
    SB

    ''' <remarks/>
    SO

    ''' <remarks/>
    ZA

    ''' <remarks/>
    GS

    ''' <remarks/>
    ES

    ''' <remarks/>
    LK

    ''' <remarks/>
    SD

    ''' <remarks/>
    SR

    ''' <remarks/>
    SJ

    ''' <remarks/>
    SZ

    ''' <remarks/>
    SE

    ''' <remarks/>
    CH

    ''' <remarks/>
    SY

    ''' <remarks/>
    TW

    ''' <remarks/>
    TJ

    ''' <remarks/>
    TZ

    ''' <remarks/>
    TH

    ''' <remarks/>
    TG

    ''' <remarks/>
    TK

    ''' <remarks/>
    [TO]

    ''' <remarks/>
    TT

    ''' <remarks/>
    TN

    ''' <remarks/>
    TR

    ''' <remarks/>
    TM

    ''' <remarks/>
    TC

    ''' <remarks/>
    TV

    ''' <remarks/>
    UG

    ''' <remarks/>
    UA

    ''' <remarks/>
    AE

    ''' <remarks/>
    GB

    ''' <remarks/>
    US

    ''' <remarks/>
    UM

    ''' <remarks/>
    UY

    ''' <remarks/>
    UZ

    ''' <remarks/>
    VU

    ''' <remarks/>
    VE

    ''' <remarks/>
    VN

    ''' <remarks/>
    VG

    ''' <remarks/>
    VI

    ''' <remarks/>
    WF

    ''' <remarks/>
    EH

    ''' <remarks/>
    YE

    ''' <remarks/>
    YU

    ''' <remarks/>
    ZM

    ''' <remarks/>
    ZW

    ''' <remarks/>
    AA

    ''' <remarks/>
    QM

    ''' <remarks/>
    QN

    ''' <remarks/>
    QO

    ''' <remarks/>
    QP

    ''' <remarks/>
    CustomCode
End Enum

'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Twitter: @telerik
'Facebook: facebook.com/telerik
'=======================================================


'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Twitter: @telerik
'Facebook: facebook.com/telerik
'=======================================================
