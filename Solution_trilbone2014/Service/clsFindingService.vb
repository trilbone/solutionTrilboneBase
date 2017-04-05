Imports System.Xml.Serialization
Imports System.Xml
Imports Service
Imports Service.clsApplicationTypes
Imports System.Windows.Forms
Imports System.Xml.Linq
Imports System.Linq
Imports eBayFinding
Imports eBayFinding.eBayFindingServiceReference
Imports System.Drawing
Imports System.Text.RegularExpressions

''' <summary>
''' класс обработки слов
''' </summary>
''' <remarks></remarks>
Public Class clsWord
    Implements IEquatable(Of clsWord)
    Implements IEqualityComparer(Of clsWord)
    Implements IComparable(Of clsWord)

    Public Property Word As String
    Public Property Count As Integer
    Public Property LinkedItemsID As List(Of String)

    Public Overrides Function ToString() As String
        Return Word.ToUpper & " --> " & Count.ToString
    End Function

    Public Overrides Function Equals(obj As Object) As Boolean
        If obj Is Nothing Then Return MyBase.Equals(obj)
        If Not TypeOf obj Is clsWord Then Return MyBase.Equals(obj)

        If Me.Word.Equals(obj.Word) And Me.Count = obj.count Then Return True

        Return False

    End Function

    Public Overrides Function GetHashCode() As Integer
        Return (Me.Word.GetHashCode Xor Me.Count.GetHashCode)
    End Function

    Public Function Equals1(other As clsWord) As Boolean Implements IEquatable(Of clsWord).Equals
        Return Me.Equals(other)
    End Function

    Public Function CompareTo(other As clsWord) As Integer Implements IComparable(Of clsWord).CompareTo
        Return Me.Word.CompareTo(other.Word)
    End Function

    Public Function Equals2(x As clsWord, y As clsWord) As Boolean Implements IEqualityComparer(Of clsWord).Equals
        If x Is Nothing Then Return MyBase.Equals(x)
        If y Is Nothing Then Return MyBase.Equals(y)

        If x.Word.ToLower.Equals(y.Word.ToLower) Then Return True

        Return False
    End Function

    Public Function GetHashCode1(obj As clsWord) As Integer Implements IEqualityComparer(Of clsWord).GetHashCode
        Return obj.Word.ToLower.GetHashCode
    End Function
End Class




''' <summary>
''' 
''' </summary>
''' <remarks></remarks>
Public Class clsFindingService
    Private Shared oReadySampleDBContext As DBREADYSAMPLEEntities
    Public Sub New()
        '. сервис формы fmMoySklad
        'привязываем делегат к функции
        'передаем делегат (регестрируем) и список в сервисном классе
        clsApplicationTypes.DelegateStoreApplicationForm _
            (emFormsList.fmEbaySearch) = _
            New ApplicationFormDelegateFunction(AddressOf GetTrilboneEbayFormAsForm)
        oReadySampleDBContext = clsApplicationTypes.SampleDataObject.GetdbReadySampleObjectContext
    End Sub

    Private Function GetTrilboneEbayFormAsForm(param As Object) As Form
        Dim _fm As New Form
        _fm.Size = New Drawing.Size(1198, 653)
        Dim _new = New UserControlEbaySearch
        _new.Dock = DockStyle.Fill
        If TypeOf param Is String Then
            Dim _value As String = param
            _new.SetSearchFrase(_value)
        End If
        _fm.Controls.Add(_new)
        Return _fm
    End Function


    ''' <summary>
    ''' вернет список слов (от 3х символов) из листингов (с частотой?)
    ''' </summary>
    ''' <param name="list"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetWords(itemlist As List(Of clseBayHistoryItem), Optional removeNoiseWords As String() = Nothing) As List(Of clsWord)
        If itemlist Is Nothing Then Return New List(Of clsWord)
        Dim _res = (From c In itemlist Let words = c.title.Split(" ".ToCharArray, StringSplitOptions.RemoveEmptyEntries) From word In words Let a = c Let lword = word.ToLower Group word, a By lword Into mygr = Group Let corrword = String.Concat(From wch In lword Where Char.IsLetter(wch) Select wch) Where corrword.Length > 2 Select New clsWord With {.Count = mygr.Count, .Word = corrword, .LinkedItemsID = (From c In mygr Select c.a.itemId).ToList}).ToList

        Dim _list = _res
        If Not removeNoiseWords Is Nothing Then
            'remove Noise
            Dim _a = From c In removeNoiseWords Select New clsWord With {.Word = c, .Count = 1}
            _list = (_list.Except(_a, New clsWord)).ToList
        End If
        _list.Sort()
        Return _list
    End Function
    ''' <summary>
    ''' обновление данных ебай = 2 часа
    ''' </summary>
    ''' <remarks></remarks>
    Const _timeInterval As Integer = 24

    ''' <summary>
    ''' основная функция обработки eBAY
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function InnerWordProcessing() As Integer
        'создать запись для блокировки параллельных обработок
        Dim _rec = New tbWordQuryHistory() With {.Id = -1, .TimeMarker = Date.UtcNow, .Message = "Starting"}
        oReadySampleDBContext.tbWordQuryHistory.AddObject(_rec)
        oReadySampleDBContext.SaveChanges()
        'получить коллекцию отслеживаемых слов
        Dim _wl = (From c In oReadySampleDBContext.tbActualWord Where c.Tracking = True Select c.Word.ToLower).ToList

        Dim _activeListingIDCollection As New List(Of String)
        Dim _queryCount As Integer = _wl.Count
        Dim _trackItemCount As Integer = 0
        Dim _endItemCount As Integer = 0
        Dim _soldItemCount As Integer = 0
        For Each _word In _wl
            'получит активные листинги на слово
            Dim _activeItemsList = FindByWord(_word)

            'фильтр по исключенным продавцам и категориям
            _activeItemsList = FilterBySellerCategory(_activeItemsList)

            'TODO фильтр по "плохим" словам

            _activeListingIDCollection.AddRange(_activeItemsList.Select(Function(x) x.itemId))

            For Each _activeitem In _activeItemsList
                ' ''запрос для WatchCount - не работает
                ' ''System.Threading.Thread.Sleep(2000)
                ''Dim _res2 = FindByItemID(it.itemId)
                ''it.Merge(_res2)

                Select Case ItemToDb(_activeitem)
                    Case clseBayHistoryItem.emSoldStatus.empty
                        'ошибка
#If DEBUG Then
                        Debug.Fail("ошибка еБай")
#End If

                    Case clseBayHistoryItem.emSoldStatus.active
                        _trackItemCount += 1
                    Case clseBayHistoryItem.emSoldStatus.endedNotsold
                        _endItemCount += 1
                    Case clseBayHistoryItem.emSoldStatus.endedSold
                        _soldItemCount += 1
                End Select
            Next

            'задержка на 2 секунд
            System.Threading.Thread.Sleep(2000)
        Next

        'сохранить изменения за один раз - ItemToDb не сохраняет!!!
        oReadySampleDBContext.SaveChanges()

        'теперь получить открытые отслеживаемые листинги
        Dim _openList = (From c In oReadySampleDBContext.tbWordHistory Where c.IsClosed = False Select c.itemId).ToList
        'найдем потерянные
        Dim _toClose = _openList.Except(_activeListingIDCollection).ToList
        'закроем их
        For Each t In _toClose
            'запросим в eBay по ID
            Dim _res = New clseBayHistoryItem With {.itemId = t} ' запрос будет в  ItemToDb 
            'закроем их (запишем что есть)
            Select Case ItemToDb(_res)
                Case clseBayHistoryItem.emSoldStatus.empty
                    'ошибка
#If DEBUG Then
                    Debug.Fail("ошибка трекинга еБай при запросе в БД: clseBayHistoryItem.emSoldStatus.empty")
#End If
                Case clseBayHistoryItem.emSoldStatus.active
                    'слово поиска удалено или листинг попал в фильтры и теперь остался висящий
                    'будет закрыт при продаже или снятии

                Case clseBayHistoryItem.emSoldStatus.endedNotsold
                    _endItemCount += 1
                Case clseBayHistoryItem.emSoldStatus.endedSold
                    _soldItemCount += 1
            End Select
        Next
        '===========
        'запись действия
        With _rec
            .Success = True
            .QueryCount = _queryCount
            .TrackItemsCount = _trackItemCount
            .EndItemsCount = _endItemCount
            .SoldItemsCount = _soldItemCount
            .Message = "ok"
        End With
        'сохранение контекста
        If oReadySampleDBContext.SaveChanges() > 0 Then
            Return 1
        Else
            Return -1
        End If
    End Function


    ''' <summary>
    ''' операция по записи слов. 0=запрос не ко времени; 1=запрос удачно; -1=запрос не сохранил данные; -2=ошибка при запросе; -3=обьект БД не инициализован
    ''' </summary>
    ''' <param name="wordList"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function WordsProceessing(Optional IgnoreTime As Boolean = False) As Integer
        If IgnoreTime Then GoTo fst
        Dim _last As Date

#If DEBUG Then
        ''при пустой таблице tbWordQuryHistory!!! Первый запуск нового приложения
        If (From c In oReadySampleDBContext.tbWordQuryHistory Select c).Count = 0 Then
            GoTo fst
        Else
            _last = Aggregate c In oReadySampleDBContext.tbWordQuryHistory Into Max(c.TimeMarker)
        End If
#Else
        'после появления первой записи
        _last = Aggregate c In oReadySampleDBContext.tbWordQuryHistory Where c.Success = True Into Max(c.TimeMarker)
#End If
        'время запроса
        Dim _diff = Date.UtcNow - _last
        If _diff.TotalHours < _timeInterval Then Return 0
fst:

#If Not Debug Then
        Try
            Return InnerWordProcessing()
        Catch ex As Exception
            If oReadySampleDBContext Is Nothing Then Return -3
            If oReadySampleDBContext.tbWordQuryHistory Is Nothing Then Return -3
            oReadySampleDBContext.tbWordQuryHistory.AddObject(New tbWordQuryHistory() With {.Id = 0, .TimeMarker = Date.UtcNow, .Success = False, .Message = ex.Message})
            oReadySampleDBContext.SaveChanges()
            Return -2
        End Try
#Else
        Return InnerWordProcessing()
#End If


    End Function


    ''' <summary>
    ''' вернет список обьектов итемов из WDSL ebay
    ''' </summary>
    ''' <param name="keywords"></param>
    ''' <param name="CategoryID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Find(keywords As String, CategoryID As String) As List(Of SearchItem)

        Dim _criteria As New EbaySearchCriteria
        With _criteria
            .Keywords = keywords
            .Categories = If(CategoryID = "0", "", CategoryID)
            .OutputSelector = {OutputSelectorType.SellerInfo}
        End With

        Return EbayHelper.GetWebQuery(_criteria)
    End Function

    ''' <summary>
    ''' фильтруем по запрещеннм продавцам и категориям
    ''' </summary>
    ''' <param name="input"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function FilterBySellerCategory(input As List(Of clseBayHistoryItem)) As List(Of clseBayHistoryItem)
        Dim _sellerList = (From c In oReadySampleDBContext.tbNoiseSellerCategory Where Not String.IsNullOrEmpty(c.SellerID) Select c.SellerID).ToList
        Dim _categoryList = (From c In oReadySampleDBContext.tbNoiseSellerCategory Where Not String.IsNullOrEmpty(c.CategoryID) Select c.CategoryID).ToList
        Dim _out = (From c In input Let Catc = (From d In _categoryList Where d.Trim.ToLower.Equals(If(String.IsNullOrEmpty(c.primaryCategory), "", c.primaryCategory.ToLower))).Count Let sc = (From d In _sellerList Where d.Trim.ToLower.Equals(If(String.IsNullOrEmpty(c.seller), "", c.seller.ToLower))).Count Where (Catc = 0 And sc = 0) Select c).ToList

        Return _out
    End Function


    ''' <summary>
    ''' поиск по слову
    ''' </summary>
    ''' <param name="criteria"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function FindByWord(word As String) As List(Of clseBayHistoryItem)
        'найти все со словом criteria
        Dim _request = clsFindingService.Find(word, "0")
        If _request Is Nothing OrElse _request.Count = 0 Then
            Return New List(Of clseBayHistoryItem)
        End If
        Dim _result = (From c In _request Select c.GetTrilbone).ToList

        Dim _dbr = (From c In oReadySampleDBContext.tbActualWord Where c.Word.ToLower.Equals(word.ToLower)).FirstOrDefault
        If _dbr Is Nothing Then
            'слова нет в БД
            For Each t In _result
                t.WordID = -1
                t.Word = word
            Next
        Else
            _dbr.HasTracked = True
            For Each t In _result
                t.WordID = _dbr.Id
                t.Word = _dbr.Word
            Next
        End If

        Return _result
    End Function

    ''' <summary>
    ''' поиск по ITEMID
    ''' </summary>
    ''' <param name="criteria"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function FindByItemID(ItemID As String) As clseBayHistoryItem
        Dim _result = GetSingleItem(ItemID)
        If _result Is Nothing Then Return Nothing
        Return _result.GetTrilbone
    End Function

    ''' <summary>
    ''' вернуть сохраненную историю
    ''' </summary>
    ''' <param name="onlyActive"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GeteBayHistory(Optional onlyActive As Boolean = False) As List(Of clseBayHistoryItem)
        Dim _result As List(Of tbWordHistory)
        Dim _words = (From c In oReadySampleDBContext.tbActualWord Select New With {.id = c.Id, .word = c.Word}).ToList
        If onlyActive Then
            _result = (From c In oReadySampleDBContext.tbWordHistory
                       Where c.IsClosed = False Select c).ToList
        Else
            _result = (From c In oReadySampleDBContext.tbWordHistory Select c).ToList
        End If

        Dim _out = (From c In _result Select c.GetAsTrilbone).ToList

        For Each t In _out
            t.Word = _words.Where(Function(x) x.id = t.WordID).Select(Function(x) x.word).FirstOrDefault
        Next

        Return _out
    End Function



    ''' <summary>
    ''' конверсия между БД и внутренним классом
    ''' </summary>
    ''' <param name="input"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' <summary>
    ''' загрузит фото на ftp
    ''' </summary>
    ''' <param name="galleryURL"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function eBayItemPhoto(galleryURL As String) As String
        'проверка наличия фото по имени файла у нас в архиве
        If String.IsNullOrEmpty(galleryURL) Then Return galleryURL
        Dim _fname = "tr" & galleryURL.GetHashCode & ".jpg"
        Dim _pb As New System.Windows.Forms.PictureBox
        Try
            _pb.Load(galleryURL)
        Catch ex As Exception
            Return galleryURL
        End Try
        Dim _content = clsIDcontent.CreateInstance("", _fname, clsIDcontent.emContentType.image, False)
        If clsApplicationTypes.SamplePhotoObject.ContainsImage(clsFilesSources.EbayPhotoArhiveOnTRILBONE, _content) Then
            Return clsApplicationTypes.SamplePhotoObject.GetContentURI(_content, clsFilesSources.EbayPhotoArhiveOnTRILBONE).AbsoluteUri
        Else
            'записать фото
            If clsApplicationTypes.SamplePhotoObject.WriteFileToContainer(clsFilesSources.EbayPhotoArhiveOnTRILBONE, _content, _pb.Image) > 0 Then
                Return clsApplicationTypes.SamplePhotoObject.GetContentURI(_content, clsFilesSources.EbayPhotoArhiveOnTRILBONE).AbsoluteUri
            End If
        End If
        Return galleryURL
    End Function

    ''' <summary>
    ''' сохраняет или обновляет итем в контексте. Контекст НЕ сохраняется
    ''' </summary>
    ''' <param name="ItemID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ItemToDb(Item As clseBayHistoryItem) As clseBayHistoryItem.emSoldStatus

        Dim _outStatus As clseBayHistoryItem.emSoldStatus = clseBayHistoryItem.emSoldStatus.empty

        'проверка наличия в базе
        Dim _dbitem = (From c In oReadySampleDBContext.tbWordHistory Where c.itemId.Equals(Item.itemId) Select c).ToList

        Select Case _dbitem.Count
            Case 0
                'нет в базе - добавить
                'создать новую запись из итема
                Dim _newRecord As tbWordHistory = tbWordHistory.CreatetbWordHistory(0, Item.itemId)
                With _newRecord
                    .title = Item.title
                    .TimeMarker = Date.UtcNow
                    .WordID = Item.WordID
                    .bestOfferEnabled = Item.bestOfferEnabled
                    .bidCount = Item.bidCount
                    .bidCountSpecified = Item.bidCountSpecified
                    .buyItNowAvailable = Item.buyItNowAvailable
                    .currencyId = Item.currencyId
                    .currentPrice = Item.currentPrice
                    .endTime = Item.endTime
                    .endTimeSpecified = Item.endTimeSpecified

                    'фото из нашей базы
                    .galleryURL = eBayItemPhoto(Item.galleryURL)

                    .itemId = Item.itemId
                    .ListingStatus = Item.ListingStatus
                    .listingType = Item.listingType
                    .location = Item.location
                    .primaryCategory = Item.primaryCategory
                    .sellingStatus = Item.sellingStatus
                    .ShippingCurrencyId = Item.ShippingCurrencyId
                    .shippingServiceCost = Item.shippingServiceCost
                    .startTime = Item.startTime
                    .startTimeSpecified = Item.startTimeSpecified

                    .timeLeft = Item.timeLeft.Ticks

                    .viewItemURL = Item.viewItemURL
                    .WatchCount = Item.WatchCount
                    .WatchCountSpecified = Item.WatchCountSpecified
                    .Seller = Item.seller
                    .QtySold = Item.quantitySold
                    .IsClosed = False
                End With
                oReadySampleDBContext.tbWordHistory.AddObject(_newRecord)
                _outStatus = clseBayHistoryItem.emSoldStatus.active
            Case 1
                'есть в базе = запросить по ID
                'запросим в eBay по ID
                Dim _detailItem = FindByItemID(_dbitem(0).itemId)
                _detailItem.Merge(Item)
                'обновить - одна запись на ID
                Dim _oldRecord = _dbitem(0)
                Select Case _detailItem.GetStatus
                    Case clseBayHistoryItem.emSoldStatus.active
                        'обновить как активную
                        With _oldRecord
                            .title = Item.title
                            .TimeMarker = Date.UtcNow
                            .bestOfferEnabled = _detailItem.bestOfferEnabled
                            .bidCount = _detailItem.bidCount
                            .bidCountSpecified = _detailItem.bidCountSpecified
                            .buyItNowAvailable = _detailItem.buyItNowAvailable
                            .currencyId = _detailItem.currencyId
                            .currentPrice = _detailItem.currentPrice
                            .endTime = _detailItem.endTime
                            .endTimeSpecified = _detailItem.endTimeSpecified
                            'фото из нашей базы
                            '.galleryURL = eBayItemPhoto(Item.galleryURL)

                            '.itemId = _detailItem.itemId
                            .ListingStatus = _detailItem.ListingStatus
                            .listingType = _detailItem.listingType
                            '.location = _detailItem.location
                            '.primaryCategory = _detailItem.primaryCategory
                            .sellingStatus = _detailItem.sellingStatus
                            .ShippingCurrencyId = _detailItem.ShippingCurrencyId
                            .shippingServiceCost = _detailItem.shippingServiceCost
                            .startTime = _detailItem.startTime
                            .startTimeSpecified = _detailItem.startTimeSpecified
                            .timeLeft = _detailItem.timeLeft.Ticks
                            '.viewItemURL = _detailItem.viewItemURL
                            .WatchCount = _detailItem.WatchCount
                            .WatchCountSpecified = _detailItem.WatchCountSpecified
                            '.Seller = _detailItem.seller
                            .QtySold = _detailItem.quantitySold
                            .IsClosed = False
                        End With
                        _outStatus = clseBayHistoryItem.emSoldStatus.active
                    Case clseBayHistoryItem.emSoldStatus.endedNotsold, clseBayHistoryItem.emSoldStatus.endedSold
                        'обновить как оконченную
                        With _oldRecord
                            .TimeMarker = Date.UtcNow
                            .QtySold = _detailItem.quantitySold
                            .IsClosed = True
                            If _detailItem.bidCountSpecified Then
                                .bidCount = _detailItem.bidCount
                            End If
                            .currencyId = _detailItem.currencyId
                            .currentPrice = _detailItem.currentPrice
                            .startTime = _detailItem.startTime
                            .startTimeSpecified = _detailItem.startTimeSpecified
                            .endTime = _detailItem.endTime
                            .endTimeSpecified = _detailItem.endTimeSpecified
                            .ListingStatus = _detailItem.ListingStatus
                            .listingType = _detailItem.listingType
                            .sellingStatus = _detailItem.sellingStatus
                            .timeLeft = _detailItem.timeLeft.Ticks
                        End With
                        If _detailItem.IsSold Then
                            _outStatus = clseBayHistoryItem.emSoldStatus.endedSold
                        Else
                            _outStatus = clseBayHistoryItem.emSoldStatus.endedNotsold
                        End If
                End Select
            Case Else
                'больше одной записи на ID!!!!
                'есть в базе = запросить по ID
                'запросим в eBay по ID
                Dim _detailItem = FindByItemID(_dbitem(0).itemId)
                If _detailItem Is Nothing Then Return _outStatus
                'обновить - одна запись на ID
                Dim _oldRecord = _dbitem(0)

                Select Case _detailItem.GetStatus
                    Case clseBayHistoryItem.emSoldStatus.active
                        'обновить как активную
                        With _oldRecord
                            .TimeMarker = Date.UtcNow
                            .bestOfferEnabled = _detailItem.bestOfferEnabled
                            .bidCount = _detailItem.bidCount
                            .bidCountSpecified = _detailItem.bidCountSpecified
                            .buyItNowAvailable = _detailItem.buyItNowAvailable
                            .currencyId = _detailItem.currencyId
                            .currentPrice = _detailItem.currentPrice
                            .endTime = _detailItem.endTime
                            .endTimeSpecified = _detailItem.endTimeSpecified
                            .galleryURL = _detailItem.galleryURL
                            .itemId = _detailItem.itemId
                            .ListingStatus = _detailItem.ListingStatus
                            .listingType = _detailItem.listingType
                            .location = _detailItem.location
                            .primaryCategory = _detailItem.primaryCategory
                            .sellingStatus = _detailItem.sellingStatus
                            .ShippingCurrencyId = _detailItem.ShippingCurrencyId
                            .shippingServiceCost = _detailItem.shippingServiceCost
                            .startTime = _detailItem.startTime
                            .startTimeSpecified = _detailItem.startTimeSpecified
                            .timeLeft = _detailItem.timeLeft.Ticks
                            .viewItemURL = _detailItem.viewItemURL
                            .WatchCount = _detailItem.WatchCount
                            .WatchCountSpecified = _detailItem.WatchCountSpecified
                            .Seller = _detailItem.seller
                            .QtySold = _detailItem.quantitySold
                            .IsClosed = False
                        End With
                        _outStatus = clseBayHistoryItem.emSoldStatus.active
                    Case clseBayHistoryItem.emSoldStatus.endedNotsold, clseBayHistoryItem.emSoldStatus.endedSold
                        'обновить как оконченную
                        With _oldRecord
                            .TimeMarker = Date.UtcNow
                            .QtySold = _detailItem.quantitySold
                            .IsClosed = True
                            If _detailItem.bidCountSpecified Then
                                .bidCount = _detailItem.bidCount
                            End If
                            .currencyId = _detailItem.currencyId
                            .currentPrice = _detailItem.currentPrice
                            .startTime = _detailItem.startTime
                            .startTimeSpecified = _detailItem.startTimeSpecified
                            .endTime = _detailItem.endTime
                            .endTimeSpecified = _detailItem.endTimeSpecified
                            .ListingStatus = _detailItem.ListingStatus
                            .listingType = _detailItem.listingType
                            .sellingStatus = _detailItem.sellingStatus
                            .timeLeft = _detailItem.timeLeft.Ticks
                        End With
                        If _detailItem.IsSold Then
                            _outStatus = clseBayHistoryItem.emSoldStatus.endedSold
                        Else
                            _outStatus = clseBayHistoryItem.emSoldStatus.endedNotsold
                        End If
                End Select

        End Select

        Return _outStatus
    End Function




    Public Shared Function GetSingleItem(ItemID As String) As eBayShopping.SimpleItemType

        Dim _result = EbayHelper.GetSingleItem(ItemID)

        Dim _xres = _result

        If _xres...<error>.Count > 0 Then
            'error
            Return Nothing
        End If
        Dim _ns = XName.Get("Item", "urn:ebay:apis:eBLBaseComponents")
        Dim _str = _xres.Element(_ns)
        If _str Is Nothing Then Return Nothing
        Dim _obj = GetSimpleItemResponse(_str.ToString)

        Return _obj
    End Function

    Private Shared Function GetSimpleItemResponse(xmlstring As String) As eBayShopping.SimpleItemType

        Static _xmlsettings As Xml.XmlReaderSettings
        Static _xml As Xml.Serialization.XmlSerializer
        If _xml Is Nothing Then
            _xml = New Xml.Serialization.XmlSerializer(GetType(eBayShopping.SimpleItemType), "urn:ebay:apis:eBLBaseComponents")
            _xmlsettings = New Xml.XmlReaderSettings
            With _xmlsettings
                .CheckCharacters = True
                .ValidationType = Xml.ValidationType.None
                .ConformanceLevel = Xml.ConformanceLevel.Fragment
            End With
        End If

        Dim _txt As New System.IO.StringReader(xmlstring)



        Dim _xreader = Xml.XmlReader.Create(_txt, _xmlsettings)

        Try
            Dim _obj = _xml.Deserialize(_xreader)

            Dim _result = TryCast(_obj, eBayShopping.SimpleItemType)
            Return _result
        Catch ex As Exception
            MsgBox("Ошибка десериализации " & ex.Message, vbCritical)
            Return Nothing
        End Try

    End Function


    ''' <summary>
    ''' служебный класс десериализации обьектов-наследников accountEntity
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <remarks></remarks>
    Friend Class clsMSObjectReader(Of T As SearchItem)
        ''' <summary>
        ''' создает обьект
        ''' </summary>
        ''' <param name="xmlString"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Shared Function CreatInstance(xmlString As String) As T
            Static _xmlsettings As Xml.XmlReaderSettings
            Static _xml As Xml.Serialization.XmlSerializer
            If _xml Is Nothing Then
                _xml = New Xml.Serialization.XmlSerializer(GetType(T), "http://www.ebay.com/marketplace/search/v1/services")
                _xmlsettings = New Xml.XmlReaderSettings
                With _xmlsettings
                    .CheckCharacters = True
                    .ValidationType = Xml.ValidationType.None
                    .ConformanceLevel = Xml.ConformanceLevel.Fragment
                End With
            End If

            Dim _txt As New System.IO.StringReader(xmlString)



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

    End Class

End Class
