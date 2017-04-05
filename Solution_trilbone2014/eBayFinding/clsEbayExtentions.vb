Imports System.Text.RegularExpressions
Imports eBayFinding.eBayFindingServiceReference
Imports System.Drawing
Imports System.Windows.Forms

Public Class clseBayHistoryItem

    Public Function GetMenuItem() As System.Windows.Forms.ToolStripMenuItem
        Dim _item = New System.Windows.Forms.ToolStripMenuItem
        With _item
            .Name = "caption" & Me.itemId
            '.Size = New Size(155, 22)
            .Text = String.Format("{0}{1} = {2} {3}", ChrW(13), If(String.IsNullOrEmpty(Me.title), "", Me.title.Substring(0, 10)), Me.TotalPriceString, Me.seller)
            '.AutoSize = True
            '.Tag = Me
            .AutoSize = False
            .Size = New Size(160, 160)
            .ForeColor = Color.Red
            .Font = New Font("Arial", 9, FontStyle.Bold)
            '.Text = ""
            .BackgroundImage = Me.galleryImage
            .BackgroundImageLayout = ImageLayout.Zoom
            .ImageKey = Me.itemId
            .ImageScaling = ToolStripItemImageScaling.SizeToFit
            .TextImageRelation = TextImageRelation.TextBeforeImage
            .DisplayStyle = ToolStripItemDisplayStyle.ImageAndText
            .Tag = Me.viewItemURL
            AddHandler .Click, AddressOf subitemdoubleclick


            ' AddHandler .MouseEnter, AddressOf submenuItemMouseEnter
        End With
        Return _item
    End Function

    Private Sub submenuItemMouseEnter(sender As Object, e As EventArgs)
        Dim _nitm As System.Windows.Forms.ToolStripMenuItem = sender

        If _nitm.DropDownItems.Count > 0 Then Return

        'показать имя и фотку
        Dim _add As New System.Windows.Forms.ToolStripMenuItem
        With _add
            .Name = "addto" & _nitm.Text
            .AutoSize = False
            .Size = New Size(160, 160)
            .ForeColor = Color.Black
            .Text = ""
            .BackgroundImage = Me.galleryImage
            .BackgroundImageLayout = ImageLayout.Center
            .ImageKey = Me.itemId
            .ImageScaling = ToolStripItemImageScaling.None
            .TextImageRelation = TextImageRelation.Overlay
            .DisplayStyle = ToolStripItemDisplayStyle.ImageAndText
            .Tag = Me.viewItemURL
            AddHandler .DoubleClick, AddressOf subitemdoubleclick
        End With
        _nitm.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {_add})
    End Sub

    Private Sub subitemdoubleclick(sender As Object, e As EventArgs)
        If sender.tag Is Nothing Then Return
        If String.IsNullOrEmpty(sender.tag) Then Return
        Process.Start(sender.tag)
    End Sub

    Property title As String

    Property seller As String

    Property quantitySold As Integer

    ''' <summary>
    ''' обединяет значения (при запросе по ID не все значения доступны)
    ''' </summary>
    ''' <param name="other"></param>
    ''' <remarks></remarks>
    Public Sub Merge(ByRef other As clseBayHistoryItem)
        'эти не используются при запросе по ID
        '.sellingStatus = "Completed"
        '.timeLeft = TimeSpan.Zero
        '.ShippingCurrencyId = "USD"
        '.shippingServiceCost = 0
        '.viewItemURL = ""
        If other Is Nothing Then Return
        With other
            If String.IsNullOrEmpty(Me.viewItemURL) Then
                'other = ItemType  Me=SingleItemType
                Me.sellingStatus = .sellingStatus
                Me.timeLeft = .timeLeft
                Me.ShippingCurrencyId = .ShippingCurrencyId
                Me.shippingServiceCost = .shippingServiceCost
                Me.viewItemURL = .viewItemURL

                'запрашивается в ItemType
                Me.WordID = .WordID
                Me.Word = .Word
                'запрашивается в SingleItemType
                .WatchCount = Me.WatchCount
                .WatchCountSpecified = Me.WatchCountSpecified
                .quantitySold = Me.quantitySold
            Else
                'other=SingleItemType Me=ItemType
                .sellingStatus = Me.sellingStatus
                .timeLeft = Me.timeLeft
                .shippingServiceCost = Me.shippingServiceCost
                .ShippingCurrencyId = Me.ShippingCurrencyId
                .viewItemURL = Me.viewItemURL

                'запрашивается в SingleItemType
                Me.WatchCount = .WatchCount
                Me.WatchCountSpecified = .WatchCountSpecified
                Me.quantitySold = .quantitySold
                'запрашивается в ItemType
                .WordID = Me.WordID
                .Word = Me.Word
            End If
        End With
    End Sub


    Public Enum emSoldStatus
        empty = -1
        active = 0
        endedNotsold = 1
        endedSold = 2
    End Enum

    ''' <summary>
    ''' листинг закончился
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property IsEnded As Boolean
        Get
            If Me.ListingStatus.ToLower.Equals("active") Then
                Return False
            Else
                Return True
            End If
            'If Me.startTimeSpecified = False Then
            '    If Me.timeLeft = TimeSpan.Zero Then
            '        Return True
            '        'If Me.ListingStatus = "Completed" Then
            '        '    Return True
            '        'End If
            '    End If
            'End If
            'Return False
        End Get
    End Property

    Public ReadOnly Property IsSold As Boolean
        Get
            If Me.quantitySold > 0 Then
                Return True
            Else
                Return False
            End If
        End Get
    End Property


    Public Function GetStatus() As emSoldStatus
        If Me.IsEnded Then
            If Me.IsSold Then
                Return emSoldStatus.endedSold
            Else
                Return emSoldStatus.endedNotsold
            End If
        Else
            Return emSoldStatus.active
        End If
    End Function


    Property Word As String

    Property WordID As Integer

    ''метка времени UTC
    Property TimeMark As Date

    ReadOnly Property TimeMarkString As String
        Get
            Return TimeMark.ToShortDateString
        End Get
    End Property


    Property itemId As String  '"321600967453" 12
    Property location As String '"Finland"

    ''' <summary>
    ''' ссылка на картинку или в моей БД или в ебай
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property galleryURL As String  '200


    ReadOnly Property galleryImage As System.Drawing.Image
        Get
            Return GetImage(galleryURL)
        End Get
    End Property

    Private Function GetImage(galleryURL As String) As Image
        If String.IsNullOrEmpty(galleryURL) Then Return Nothing
        Dim _pb As New Windows.Forms.PictureBox

        Try
            _pb.Load(galleryURL)
        Catch ex As Exception

        End Try
        If _pb.Image Is Nothing Then Return Nothing
        Return _pb.Image
    End Function

    ''' <summary>
    ''' ссылка на страницу с листингом
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property viewItemURL As String '200

    Property primaryCategory As String '{165707 -> Trilobites}
    Property sellingStatus As String 'Active

    Property bidCountSpecified As Boolean
    Property bidCount As Integer

    Property currentPrice As Decimal
    Property currencyId As String 'USD

    ReadOnly Property TotalPriceString As String
        Get
            Return String.Format("{0} {1}", currentPrice + shippingServiceCost, currencyId)
        End Get
    End Property

    Property shippingServiceCost As Decimal
    Property ShippingCurrencyId As String 'USD

    Property startTime As Date

    ReadOnly Property startTimeString As String
        Get
            Return startTime.ToShortTimeString
        End Get
    End Property

    Property startTimeSpecified As Boolean
    Property endTime As Date

    ReadOnly Property endTimeString As String
        Get
            If startTimeSpecified Then
                Return endTime.ToShortTimeString
            End If
            Return ""
        End Get
    End Property

    Property endTimeSpecified As Boolean
    Property timeLeft As TimeSpan  '"P17DT22H57M1S"

    ReadOnly Property timeLeftString As String
        Get
            If timeLeft = TimeSpan.Zero Then Return "ended"
            Return String.Format("{0}дн {1}ч {2}мин", timeLeft.Days, timeLeft.Hours, timeLeft.Minutes)
        End Get
    End Property

    Property listingType As String 'FixedPrice FixedPriceItem

    Property buyItNowAvailable As Boolean

    Property bestOfferEnabled As Boolean

    'только для SingleItem
    Property WatchCount As Integer
    Property WatchCountSpecified As Boolean
    Property ListingStatus As String 'Active Completed

    ''' <summary>
    ''' преобразует время ebay P17DT22H57M1S (0=PT0S)
    ''' </summary>
    ''' <param name="input"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetTimeSpan(input As String) As TimeSpan

        If input = "PT0S" Then
            Return TimeSpan.Zero
        End If

        Dim a = New Regex("\d*")
        Dim _d As Integer
        Dim _h As Integer
        Dim _m As Integer
        Dim _s As Integer
        Dim f = a.Matches(input)
        Select Case f.Count
            Case Is > 9
                _d = f(1).Value
                _h = f(4).Value
                _m = f(6).Value
                _s = f(8).Value
            Case Else
                Return TimeSpan.Zero
        End Select


        Return New TimeSpan(_d, _h, _m, _s)
    End Function

End Class



Namespace eBayFindingServiceReference

    Partial Public Class SellerInfo
        Public Overrides Function ToString() As String
            Return Me.sellerUserName
        End Function
    End Class

    Partial Public Class SearchItem
        Public Function GetTrilbone() As clseBayHistoryItem
            Dim _new As New clseBayHistoryItem
            With _new
                .title = Me.title
                .TimeMark = Date.UtcNow
                If Not Me.listingInfo Is Nothing Then
                    .bestOfferEnabled = Me.listingInfo.bestOfferEnabled
                    .buyItNowAvailable = Me.listingInfo.buyItNowAvailable
                    .endTime = Me.listingInfo.endTime
                    .endTimeSpecified = Me.listingInfo.endTimeSpecified
                    .listingType = Me.listingInfo.listingType
                    .startTime = Me.listingInfo.startTime
                    .startTimeSpecified = Me.listingInfo.startTimeSpecified
                End If

                If Not Me.sellingStatus Is Nothing Then
                    .bidCount = Me.sellingStatus.bidCount
                    .bidCountSpecified = Me.sellingStatus.bidCountSpecified
                    .sellingStatus = Me.sellingStatus.sellingState
                    .timeLeft = clseBayHistoryItem.GetTimeSpan(Me.sellingStatus.timeLeft)  'P17DT22H57M1S  P5DT0H3M19S
                    'ConvertedCurrentPrice в баксах
                    If Not Me.sellingStatus.convertedCurrentPrice Is Nothing Then
                        .currencyId = Me.sellingStatus.convertedCurrentPrice.currencyId
                        .currentPrice = Me.sellingStatus.convertedCurrentPrice.Value
                    End If
                End If

                If Not Me.shippingInfo Is Nothing Then
                    If Not Me.shippingInfo.shippingServiceCost Is Nothing Then
                        .ShippingCurrencyId = Me.shippingInfo.shippingServiceCost.currencyId
                        .shippingServiceCost = Me.shippingInfo.shippingServiceCost.Value
                    End If
                End If

                If Not Me.sellerInfo Is Nothing Then
                    .seller = Me.sellerInfo.sellerUserName
                End If

                .primaryCategory = Me.primaryCategory.ToString
                .galleryURL = Me.galleryURL
                .itemId = Me.itemId
                .location = Me.location
                .viewItemURL = Me.viewItemURL
                .ListingStatus = "active"
            End With
            Return _new
        End Function

    End Class



End Namespace
Namespace eBayShopping
    Partial Public Class SimpleItemType
        Public Function GetTrilbone() As clseBayHistoryItem
            Dim _new As New clseBayHistoryItem
            With _new
                .title = Me.Title
                .quantitySold = Me.QuantitySold
                .WatchCount = Me.WatchCount
                .WatchCountSpecified = Me.WatchCountSpecified
                .TimeMark = Date.UtcNow
                .bestOfferEnabled = Me.BestOfferEnabled
                .buyItNowAvailable = Me.BuyItNowAvailable
                .endTime = Me.EndTime
                .endTimeSpecified = Me.EndTimeSpecified
                .listingType = [Enum].GetName(GetType(ListingTypeCodeType), Me.ListingType)
                .startTime = Me.StartTime
                .startTimeSpecified = Me.StartTimeSpecified

                .bidCount = Me.BidCount
                .bidCountSpecified = Me.BidCountSpecified

                If Not Me.ConvertedCurrentPrice Is Nothing Then
                    .currencyId = [Enum].GetName(GetType(CurrencyCodeType), Me.ConvertedCurrentPrice.currencyID)
                    .currentPrice = Me.ConvertedCurrentPrice.Value
                End If


                .primaryCategory = Me.PrimaryCategoryName
                .galleryURL = Me.GalleryURL
                .itemId = Me.ItemID
                .location = Me.Location

                If Not Me.Seller Is Nothing Then
                    .seller = Me.Seller.UserID
                End If

                'эти не используются
                '.sellingStatus = "Completed"
                '.timeLeft = TimeSpan.Zero
                '.ShippingCurrencyId = "USD"
                '.shippingServiceCost = 0
                '.viewItemURL = ""

                .ListingStatus = [Enum].GetName(GetType(ListingStatusCodeType), Me.ListingStatus)
            End With
            Return _new
        End Function


    End Class

End Namespace


