Imports eBayFinding

Partial Public Class tbWordHistory

    Public Function GetAsTrilbone() As clseBayHistoryItem
        Dim _new As New clseBayHistoryItem
        Dim Input = Me
        With _new
            .title = Me.title
            .quantitySold = Input.QtySold
            .seller = Input.Seller
            .WordID = Input.WordID
            .WatchCount = Input.WatchCount
            .WatchCountSpecified = Input.WatchCountSpecified
            .TimeMark = Input.TimeMarker.GetValueOrDefault
            .bestOfferEnabled = Input.bestOfferEnabled.GetValueOrDefault
            .buyItNowAvailable = Input.buyItNowAvailable.GetValueOrDefault
            .endTime = Input.endTime.GetValueOrDefault
            .endTimeSpecified = Input.endTimeSpecified.GetValueOrDefault
            .listingType = Input.listingType
            .startTime = Input.startTime.GetValueOrDefault
            .startTimeSpecified = Input.startTimeSpecified.GetValueOrDefault

            .bidCount = Input.bidCount.GetValueOrDefault
            .bidCountSpecified = Input.bidCountSpecified.GetValueOrDefault
            .currencyId = Input.currencyId
            .currentPrice = Input.currentPrice.GetValueOrDefault
            .sellingStatus = Input.sellingStatus
            .timeLeft = TimeSpan.FromTicks(Input.timeLeft.GetValueOrDefault) 'P17DT22H57M1S

            .ShippingCurrencyId = Input.ShippingCurrencyId
            .shippingServiceCost = Input.shippingServiceCost.GetValueOrDefault

            .primaryCategory = Input.primaryCategory
            .galleryURL = Input.galleryURL
            .itemId = Input.itemId
            .location = Input.location
            .viewItemURL = Input.viewItemURL
            .ListingStatus = Input.ListingStatus
        End With

        Return _new
    End Function

End Class


Partial Public Class GetEbayInfo_Result
    Public Function GetTrilbone() As clseBayHistoryItem
        Dim _new As New clseBayHistoryItem

        With _new
            .title = Me.title
            .WordID = Me.wordID
            .bidCount = Me.bidCount.GetValueOrDefault

            .endTime = Me.endTime.GetValueOrDefault.ToShortDateString

            .galleryURL = Me.galleryURL

            .itemId = Me.itemId()
            .ListingStatus = Me.ListingStatus()
            .listingType = Me.listingType()
            .location = Me.location()
            .primaryCategory = Me.primaryCategory()
            .quantitySold = Me.QtySold.GetValueOrDefault
            .seller = Me.Seller
            .timeLeft = TimeSpan.FromTicks(Me.timeLeft.GetValueOrDefault)

            .viewItemURL = Me.viewItemURL
            .Word = Me.Word

            .currentPrice = Me.TotalPrice.GetValueOrDefault
            .currencyId = Me.currencyId

            .shippingServiceCost = 0
            .ShippingCurrencyId = Me.currencyId
        End With
        Return _new
    End Function


End Class
