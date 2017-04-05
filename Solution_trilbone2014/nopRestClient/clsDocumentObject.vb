Imports System.Globalization
Imports nopTypes.Nop.Plugin.Misc.panoRazziRestService

Public Class clsDocumentObject
    Implements System.ComponentModel.INotifyPropertyChanged

    Private oFullDescriptions As LangObject
    Private oMetaDescription As LangObject
    Private oMetaTitle As LangObject
    Private oNames As LangObject
    Private oShortDescriptions As LangObject
    Private oProductMetaWord As clsLangObjectCollection
    Private oProductTag As clsLangObjectCollection
    Private oSelectedProductMetaWord As clsLangObjectCollection
    Private oSelectedProductCategories As clsCategoriesObjectCollection
    Private oSelectedLocalities As clsManufacturersObjectCollection
    Private oProductACL As clsProductACL
    Private oTierPrices As clsTierPricesCollection
    Private oSelectedSpecificAttributes As clsSAObjectCollection
    Private oDefaultLang As lng
    Private WithEvents oSimpleObjects As clsDocumentSimple
    Private oDocumentService As clsDocumentService


    Public Property SelectedSpecificAttributes As clsSAObjectCollection
        Get
            Return oSelectedSpecificAttributes
        End Get
        Set(value As clsSAObjectCollection)
            oSelectedSpecificAttributes = value
            RaisePropertyChanged("SelectedSpecificAttributes")
        End Set
    End Property

    ''' <summary>
    ''' проверяет все значения
    ''' </summary>
    ''' <remarks></remarks>
    Public Function Validate() As Boolean
        'РАСКОММЕНТИРОВАТЬ!!!!
        If (Not ValidateLangObject(Me.oNames)) Or (Me.oNames.Count <= 0) Then
            'проверка не пройдена или значения не добавлены
            MsgBox(String.Format("Необходимо добавить Название образца, хотя бы на одном из языков"), vbCritical)
            Return False
        End If
        If (Not ValidateLangObject(Me.oMetaTitle)) Then
            'проверка не пройдена или значения не добавлены
            MsgBox(String.Format("Ошибки в подписи Meta title"), vbCritical)
            Return False
        End If
        If (Not ValidateLangObject(Me.oShortDescriptions)) Then
            'проверка не пройдена или значения не добавлены
            MsgBox(String.Format("Ошибки в Коротком описании"), vbCritical)
            Return False
        End If
        If (Not ValidateLangObject(Me.oMetaDescription)) Then
            'проверка не пройдена или значения не добавлены
            MsgBox(String.Format("Ошибки в Короткое описание Meta <description>"), vbCritical)
            Return False
        End If
        If (Not ValidateLangObject(Me.oFullDescriptions)) Then
            'проверка не пройдена или значения не добавлены
            MsgBox(String.Format("Ошибки в Полном описании"), vbCritical)
            Return False
        End If

        'проверка списков???
        If Me.oSelectedProductTag Is Nothing Then Return False

        'установка ивариантного значения требуемого языка
        Dim _res = Me.oDescriptionObjectList.Where(Function(x) x.SetAsInvariant = True)

        Select Case _res.Count
            Case 0
                MsgBox(String.Format("Необходимо отметить галочкой основной язык"), vbCritical)
                Return False
            Case 1
                'преобразование
                Me.DefaultLang = _res(0).DataLang
            Case Else
                MsgBox(String.Format("Отмечено более одного языка, снимите лишние галочки"), vbCritical)
                Return False
        End Select
        'РАСКОММЕНТИРОВАТЬ!!!!
        If CreatedTierPrices.Count = 0 Then
            MsgBox(String.Format("Необходимо создать хотя бы одну цену"), vbCritical)
            Return False
        End If

        Return True
    End Function

    Private Function ValidateLangObject(obj As LangObject) As Boolean
        'у обьекта нет значений
        If obj.Count <= 0 Then Return True
        'ошибка
        If obj.InvariantValue = "" Then Debug.Fail(String.Format("Попытка использовать обьект с пустым атрибутом invariantvalue: {0}", obj.ToString)) : Return False
        'должен содержать invariant значения
        Dim _inv = obj.ItemLangObj.FirstOrDefault(Function(x) x.lang = lng.invariant)
        If Not _inv Is Nothing Then
            If Not obj.InvariantValue = _inv.Value Then
                Debug.Fail(String.Format("Значения invariant не совпадают {0}", obj.ToString))
                obj.InvariantValue = _inv.Value
            End If
            Return True
        Else
            'взяли первый язык со значением и установили как инваиант
            For Each t In [Enum].GetValues(GetType(lng))
                If obj.Contains(t) Then
                    obj.SetAsInvariant(t)
                    Exit For
                End If
            Next
        End If
        Return True
    End Function

    ''' <summary>
    ''' делегат курсов валют
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property RateDelagate As Func(Of String, Decimal)



   

    Public Event PropertyChanged(sender As Object, e As ComponentModel.PropertyChangedEventArgs) Implements ComponentModel.INotifyPropertyChanged.PropertyChanged

    Public Property FullDescriptions(lang As lng) As String
        Get
            Return oFullDescriptions.langValue(lang)
        End Get
        Set(value As String)
            oFullDescriptions.langValue(lang) = value
            RaisePropertyChanged("FullDescriptions")
        End Set
    End Property

    Public Property MetaDescription(lang As lng) As String
        Get
            Return oMetaDescription.langValue(lang)
        End Get
        Set(value As String)
            oMetaDescription.langValue(lang) = value
            RaisePropertyChanged("MetaDescription")
        End Set
    End Property

    Public Property MetaTitle(lang As lng) As String
        Get
            Return oMetaTitle.langValue(lang)
        End Get
        Set(value As String)
            oMetaTitle.langValue(lang) = value
            RaisePropertyChanged("MetaTitle")
        End Set
    End Property

    Public Property Names(lang As lng) As String
        Get
            Return oNames.langValue(lang)
        End Get
        Set(value As String)
            oNames.langValue(lang) = value
            RaisePropertyChanged("Names")
        End Set

    End Property





    Public Property ProductMetaWord As clsLangObjectCollection
        Get
            Return oProductMetaWord
        End Get
        Set(value As clsLangObjectCollection)
            oProductMetaWord = value
            RaisePropertyChanged("ProductMetaWord")
        End Set
    End Property

    Public ReadOnly Property Stores As clsStoresCollection
        Get
            Return oDocumentService.Stores
        End Get
    End Property

    Public ReadOnly Property Customers As clsCustomerRolesCollection
        Get
            Return oDocumentService.CustomerRoles
        End Get
    End Property

    Public ReadOnly Property ProductTag As clsLangObjectCollection
        Get
            Return oProductTag
        End Get
    End Property

    Public ReadOnly Property ProductCategories As clsCategoriesObjectCollection
        Get
            Return oDocumentService.ProductCategories
        End Get
    End Property

    Public ReadOnly Property Localities As clsManufacturersObjectCollection
        Get
            Return oDocumentService.Localities
        End Get
    End Property

    Public Property ShortDescriptions(lang As lng) As String
        Get
            Return oShortDescriptions.langValue(lang)
        End Get
        Set(value As String)
            oShortDescriptions.langValue(lang) = value
            RaisePropertyChanged("ShortDescriptions")
        End Set
    End Property

    Public Function GetXML() As String
        Dim _err As XElement = <error>Исправте ошибки</error>
        If Not Me.Validate() Then Return _err.ToString
        '-----------------
        Dim _xml = New XElement("Products")
        With _xml
            .Add(New XAttribute("Version", "3.50"))
        End With

        Dim _product = New XElement("Product")
        With _product
            .Add(New XElement("ProductId", "0"))
            .Add(New XElement("ProductTypeId", "5"))
            .Add(New XElement("ParentGroupedProductId", "0"))
            '???
            .Add(New XElement("VisibleIndividually", "true"))

            'names
            .Add(XElement.Parse(Me.oNames.GetXML("Names", "NameValue")))

            'ShortDescriptions
            .Add(XElement.Parse(Me.oShortDescriptions.GetXML("ShortDescriptions", "ShortDescriptionValue")))

            'FullDescriptions
            .Add(XElement.Parse(Me.oFullDescriptions.GetXML("FullDescriptions", "FullDescriptionValue")))

            'AdminComment
            .Add(New XElement("AdminComment", Me.SimpleObjects.AdminComment))

            .Add(New XElement("VendorId", "0"))
            .Add(New XElement("ProductTemplateId", "1"))

            'ShowOnHomePage
            .Add(New XElement("ShowOnHomePage", Me.SimpleObjects.ShowOnHomePage.ToString.ToLower))

            'MetaKeywords
            Dim _words = New XElement("MetaKeywords")

            If oSelectedProductMetaWord.Count > 0 Then
                For Each t In [Enum].GetValues(GetType(lng))
                    _words.Add(XElement.Parse(oSelectedProductMetaWord.GetLangXML(t, "MetaKeywordsValue", "word")))
                Next
            End If

            .Add(_words)

            'MetaDescription
            .Add(XElement.Parse(Me.oMetaDescription.GetXML("MetaDescription", "MetaDescriptionValue")))

            'MetaTitle
            .Add(XElement.Parse(Me.oMetaTitle.GetXML("MetaTitle", "MetaTitleValue")))

            'SEName это имя для ссылок на фото и прочие ресурые внутренние
            .Add(New XElement("SEName", Me.SimpleObjects.SeName))

            .Add(New XElement("AllowCustomerReviews", "true"))

            'SKU
            .Add(New XElement("SKU", Me.SimpleObjects.SKU))

            .Add(New XElement("ManufacturerPartNumber", ""))
            .Add(New XElement("Gtin", ""))
            .Add(New XElement("IsGiftCard", "false"))
            .Add(New XElement("GiftCardType", "Virtual"))
            .Add(New XElement("RequireOtherProducts", "false"))
            .Add(New XElement("RequiredProductIds", ""))
            .Add(New XElement("AutomaticallyAddRequiredProducts", "false"))

            'IsDownload скачиваемый продукт
            .Add(New XElement("IsDownload", "false"))
            .Add(New XElement("DownloadId", "0"))
            .Add(New XElement("UnlimitedDownloads", "true"))
            .Add(New XElement("MaxNumberOfDownloads", "10"))
            .Add(New XElement("DownloadExpirationDays", ""))
            .Add(New XElement("DownloadActivationType", "WhenOrderIsPaid"))
            .Add(New XElement("HasSampleDownload", "false"))
            .Add(New XElement("SampleDownloadId", "0"))
            .Add(New XElement("HasUserAgreement", "false"))
            .Add(New XElement("UserAgreementText", ""))

            'IsRecurring с периодическими платежами
            .Add(New XElement("IsRecurring", "false"))
            .Add(New XElement("RecurringCycleLength", "100"))
            .Add(New XElement("RecurringCyclePeriodId", "0"))
            .Add(New XElement("RecurringTotalCycles", "10"))

            'IsRental аренда
            .Add(New XElement("IsRental", "false"))
            .Add(New XElement("RentalPriceLength", "1"))
            .Add(New XElement("RentalPricePeriodId", "0"))

            'shipping Шиппинг
            .Add(New XElement("IsShipEnabled", "true"))
            .Add(New XElement("IsFreeShipping", "false"))
            .Add(New XElement("ShipSeparately", "false"))
            .Add(New XElement("AdditionalShippingCharge", "0.0000"))
            .Add(New XElement("DeliveryDateId", "0"))

            'Taxes Налоги
            .Add(New XElement("IsTaxExempt", "false"))
            .Add(New XElement("TaxCategoryId", "0"))

            .Add(New XElement("IsTelecommunicationsOrBroadcastingOrElectronicServices", "false"))

            'inventory Складской учет
            '-----------------
            'код склада 1=внутренний питер 2=внутренний Нарва 3=Лавка
            If Me.SimpleObjects.WarehouseID = 0 Then
                'НЕ отслеживать запасы
                .Add(New XElement("ManageInventoryMethodId", "0"))
                .Add(New XElement("UseMultipleWarehouses", "false"))
                MsgBox("Склад не будет указан при размещении образца на сайте. Измени склад для образца в админке сайта.", vbInformation)
            Else
                'отслеживать запасы
                .Add(New XElement("ManageInventoryMethodId", "1"))
                .Add(New XElement("UseMultipleWarehouses", "true"))
            End If
            .Add(New XElement("WarehouseId", Me.SimpleObjects.WarehouseID.ToString))
            '------------
            'количество на складе =1шт
            .Add(New XElement("StockQuantity", "1"))
            '---------------------
            .Add(New XElement("DisplayStockAvailability", "false"))
            .Add(New XElement("DisplayStockQuantity", "false"))
            .Add(New XElement("MinStockQuantity", "0"))
            'скрывать товар
            .Add(New XElement("LowStockActivityId", "2"))
            .Add(New XElement("NotifyAdminForQuantityBelow", "0"))
            '
            .Add(New XElement("BackorderModeId", "0"))
            .Add(New XElement("AllowBackInStockSubscriptions", "false"))

            'order qty
            .Add(New XElement("OrderMinimumQuantity", "1"))
            .Add(New XElement("OrderMaximumQuantity", "1"))
            .Add(New XElement("AllowedQuantities", "1"))
            .Add(New XElement("AllowAddingOnlyExistingAttributeCombinations", "false"))


            .Add(New XElement("DisableBuyButton", Me.CreatedTierPrices.TierPriceStatic.DisableBuyButton.ToString.ToLower))
            'TODO?
            .Add(New XElement("DisableWishlistButton", "false"))
            .Add(New XElement("AvailableForPreOrder", "false"))
            .Add(New XElement("PreOrderAvailabilityStartDateTimeUtc", ""))

            'prices TODO
            .Add(New XElement("CallForPrice", Me.CreatedTierPrices.TierPriceStatic.CallForPrice.ToString.ToLower))

            If Me.CreatedTierPrices.Count > 0 Then
                .Add(New XElement("Price", Me.CreatedTierPrices.Max(Function(x) x.Price)))
            Else
                .Add(New XElement("Price", 0))
            End If

            .Add(New XElement("OldPrice", 0))
            .Add(New XElement("ProductCost", 0))

            .Add(New XElement("SpecialPrice", Nothing))
            .Add(New XElement("SpecialPriceStartDateTimeUtc", ""))
            .Add(New XElement("SpecialPriceEndDateTimeUtc", ""))

            .Add(New XElement("CustomerEntersPrice", Me.CreatedTierPrices.TierPriceStatic.CustomerEntersPrice.ToString.ToLower))
            .Add(New XElement("MinimumCustomerEnteredPrice", Me.CreatedTierPrices.TierPriceStatic.MinimumCustomerEnteredPrice.ToString))
            .Add(New XElement("MaximumCustomerEnteredPrice", Me.CreatedTierPrices.TierPriceStatic.MaximumCustomerEnteredPrice.ToString))

            'параметры товара
            .Add(New XElement("Weight", Me.SimpleObjects.Weight.ToString.Replace(",", ".")))
            .Add(New XElement("Length", Me.SimpleObjects.Length.ToString.Replace(",", ".")))
            .Add(New XElement("Width", Me.SimpleObjects.Width.ToString.Replace(",", ".")))
            .Add(New XElement("Height", Me.SimpleObjects.Height.ToString.Replace(",", ".")))

            .Add(New XElement("Published", Me.SimpleObjects.Published.ToString.ToLower))
            .Add(New XElement("CreatedOnUtc", "3/3/2015 1:58:31 PM"))
            .Add(New XElement("UpdatedOnUtc", "3/7/2015 2:20:04 PM"))

            .Add(New XElement("ProductDiscounts", ""))

            'TierPrices
            .Add(XElement.Parse(Me.CreatedTierPrices.GetXML()))
            '-------------
            'не используем
            .Add(New XElement("ProductAttributes", ""))

            'ProductPictures
            .Add(XElement.Parse(Me.DocumentService.Pictures.GetXML()))

            'ProductCategories
            .Add(XElement.Parse(Me.oSelectedProductCategories.GetXML()))

            'ProductManufacturers
            .Add(XElement.Parse(Me.oSelectedLocalities.GetXML()))

            'ProductSpecificationAttributes
            .Add(XElement.Parse(Me.SelectedSpecificAttributes.GetXML()))

            'ProductTags
            .Add(XElement.Parse(oSelectedProductTag.GetXML("ProductTags", "ProductTag", "TagValue", True)))

            'ProductAcl
            .Add(XElement.Parse(Me.CreatedProductACL.GetXML()))

            ' <!--end product-->
        End With
        _xml.Add(_product)
        Return _xml.ToString
    End Function
    ''' <summary>
    '''требует обьект внешних данных
    ''' </summary>
    ''' <param name="DocumentService"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CreateInstance(DocumentService As clsDocumentService) As clsDocumentObject
        Dim _new As New clsDocumentObject
        With _new
            .oSimpleObjects = clsDocumentSimple.CreateInstance
            .oDocumentService = DocumentService
            .oDescriptionObjectList = New List(Of clsDescriptionObject)

            'языковые
            .oNames = LangObject.CreateInstance("Names")
            .oShortDescriptions = LangObject.CreateInstance("ShortDescriptions")
            .oFullDescriptions = LangObject.CreateInstance("FullDescription", "Description")

            .oMetaDescription = LangObject.CreateInstance("MetaDescription")
            .oMetaTitle = LangObject.CreateInstance("MetaTitle")

            .oProductTag = clsLangObjectCollection.CreateInstance("ProductTag", DocumentService.ProductTag)
            .oSelectedProductTag = clsLangObjectCollection.CreateInstance("ProductTag")

            .oProductMetaWord = clsLangObjectCollection.CreateInstance("MetaKeywordsValue")
            .oSelectedProductMetaWord = clsLangObjectCollection.CreateInstance("MetaKeywordsValue")

            'внеязыковые
            .oSelectedSpecificAttributes = clsSAObjectCollection.CreateInstance("Attributes")
            .oSelectedProductCategories = clsCategoriesObjectCollection.CreateInstance()
            .oSelectedLocalities = clsManufacturersObjectCollection.CreateInstance()
            .oProductACL = clsProductACL.CreateInstance()
            .oTierPrices = clsTierPricesCollection.CreateInstance(DocumentService.SiteBaseCurrency)

        End With
        Return _new
    End Function


    Public Sub AddFullDescription(value As LangObject)
        oFullDescriptions = value
        RaisePropertyChanged("FullDescriptions")
    End Sub

    Public Sub AddShotDescription(value As LangObject)
        oShortDescriptions = value
        RaisePropertyChanged("ShortDescriptions")
    End Sub

    ''' <summary>
    ''' хранит языковые страницы
    ''' </summary>
    ''' <remarks></remarks>
    Private oDescriptionObjectList As List(Of clsDescriptionObject)

    ''' <summary>
    ''' вернет языковую страницу
    ''' </summary>
    ''' <param name="DataLang"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetDescriptionObject(DataLang As lng) As clsDescriptionObject

        Dim _res = Me.oDescriptionObjectList.FirstOrDefault(Function(x) x.DataLang = DataLang)
        If Not _res Is Nothing Then Return _res

        Dim _new = clsDescriptionObject.CreateInstance(DataLang, Me)
        AddHandler _new.PropertyChanged, AddressOf DescriptionObjectsPropertyChanged_Handler

        ' загрузка шаблонов в языковую вкладку
        Select Case DataLang
            Case lng.enUS
                _new.xsltTemplates = (oDocumentService.xsltTemplates.Where(Function(x) x.Culture.Name = "en-US")).ToList
            Case lng.ruRU
                _new.xsltTemplates = (oDocumentService.xsltTemplates.Where(Function(x) x.Culture.Name = "ru-RU")).ToList
        End Select
        oDescriptionObjectList.Add(_new)

        If DataLang = Me.DefaultLang Then
            'отметим галочкой основной язык
            _new.SetAsInvariant = True
        End If
        Return _new
    End Function


    Protected Sub RaisePropertyChanged(ByVal propertyName As String)
        Dim propertyChanged As System.ComponentModel.PropertyChangedEventHandler = Me.PropertyChangedEvent
        If (Not (propertyChanged) Is Nothing) Then
            propertyChanged(Me, New System.ComponentModel.PropertyChangedEventArgs(propertyName))
        End If
    End Sub

    ''' <summary>
    ''' создаст все описания для всех языков
    ''' </summary>
    ''' <param name="DataArray"></param>
    ''' <param name="GetTextDelegate"></param>
    ''' <remarks></remarks>
    Friend Sub ChangeAllDescription(DataArray As Integer(), GetTextDelegate As Func(Of Integer(), CultureInfo, String), except As clsDescriptionObject)
        If GetTextDelegate Is Nothing Then Return
        For Each t In Me.oDescriptionObjectList
            If Not t Is except Then
                t.ShortDescriptions = GetTextDelegate.Invoke(DataArray, t.Culture)
            End If
        Next
    End Sub


    ''' <summary>
    ''' перехват событий для сложных ЭУ обьекта страницы языка
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub DescriptionObjectsPropertyChanged_Handler(sender As Object, e As ComponentModel.PropertyChangedEventArgs)
        Dim _sender As clsDescriptionObject = sender
        Select Case e.PropertyName
            Case "SelectedProductTag"
                Dim _tags = _sender.SelectedProductTag
                Me.SelectedProductTag.Clear()
                If Not _tags Is Nothing Then
                    Me.SelectedProductTag.AddRange(Me.SelectedProductTag.Union(_tags).Distinct)
                End If
            Case "SelectedProductMetaWord"
                Dim _words = _sender.SelectedProductMetaWord
                Me.SelectedProductMetaWord.Clear()
                Me.SelectedProductMetaWord.AddRange(Me.SelectedProductMetaWord.Union(_words).Distinct)
            Case "SetAsInvariant"
                'установлен язык в вкладке
                'sender = вкладка
                Dim _do As clsDescriptionObject = sender
                ' MsgBox(String.Format("язык {1} {0}", _do.ToString, _do.SetAsInvariant.ToString))
                If _do.SetAsInvariant = True Then
                    ' MsgBox(String.Format("язык установлен: {0} ", _do.ToString))
                    'сбросить остальные вкладки
                    For Each t In Me.oDescriptionObjectList
                        If Not t.Equals(_do) Then
                            ' MsgBox(String.Format("язык сброшен:{0} ", t.ToString))
                            If t.SetAsInvariant Then
                                t.SetAsInvariant = False
                            End If
                        End If
                    Next
                    'изменить инвариант
                    Me.DefaultLang = _do.DataLang
                End If

        End Select
    End Sub

    Public Property SelectedLocalities As clsManufacturersObjectCollection
        Get
            Return oSelectedLocalities
        End Get
        Set(value As clsManufacturersObjectCollection)
            oSelectedLocalities = value
            RaisePropertyChanged("SelectedLocalities")
        End Set
    End Property

    Public Property SelectedProductCategories As clsCategoriesObjectCollection
        Get
            Return oSelectedProductCategories
        End Get
        Set(value As clsCategoriesObjectCollection)
            oSelectedProductCategories = value
            RaisePropertyChanged("SelectedProductCategories")
        End Set
    End Property

    Public Property SelectedProductTag As clsLangObjectCollection
        Get
            Return oSelectedProductTag
        End Get
        Set(value As clsLangObjectCollection)
            oSelectedProductTag = value
            RaisePropertyChanged("SelectedProductTag")
        End Set
    End Property


    Dim oSelectedProductTag As clsLangObjectCollection


    Public Property SelectedProductMetaWord As clsLangObjectCollection
        Get
            Return oSelectedProductMetaWord
        End Get
        Set(value As clsLangObjectCollection)
            oSelectedProductMetaWord = value
            RaisePropertyChanged("SelectedProductMetaWord")
        End Set
    End Property

   

    ''' <summary>
    ''' атрибуты
    ''' </summary>
    Public ReadOnly Property SpecificAttributes As clsSAObjectCollection
        Get
            Return oDocumentService.SpecificAttributes
        End Get
    End Property

    ''' <summary>
    ''' Цены по ролям
    ''' </summary>
    Public Property CreatedTierPrices As clsTierPricesCollection
        Get
            Return oTierPrices
        End Get
        Set(value As clsTierPricesCollection)
            oTierPrices = value
            RaisePropertyChanged("CreatedTierPrices")
        End Set
    End Property

    ''' <summary>
    ''' выбранные роли клиентов и магазины
    ''' </summary>
    Public Property CreatedProductACL As clsProductACL
        Get
            Return oProductACL
        End Get
        Set(value As clsProductACL)
            oProductACL = value
            RaisePropertyChanged("CreatedProductACL")
        End Set
    End Property

    ''' <summary>
    ''' язык для формирования XML invariant значений
    ''' </summary>
    Public Property DefaultLang As lng
        Get
            Return oDefaultLang
        End Get
        Set(value As lng)
            oDefaultLang = value
            'переделка ВСЕХ полей
            Me.oFullDescriptions.SetAsInvariant(value)
            Me.oMetaDescription.SetAsInvariant(value)
            Me.oMetaTitle.SetAsInvariant(value)
            Me.oNames.SetAsInvariant(value)
            Me.oProductMetaWord.SetAsInvariant(value)
            Me.oProductTag.SetAsInvariant(value)
            Me.oSelectedLocalities.SetAsInvariant(value)
            Me.SelectedProductCategories.SetAsInvariant(value)
            Me.SelectedProductMetaWord.SetAsInvariant(value)
            Me.SelectedProductTag.SetAsInvariant(value)
            Me.SelectedSpecificAttributes.SetAsInvariant(value)
            Me.oShortDescriptions.SetAsInvariant(value)
        End Set
    End Property

    Public Property SimpleObjects As clsDocumentSimple
        Get
            Return oSimpleObjects
        End Get
        Set(value As clsDocumentSimple)
            oSimpleObjects = value
            RaisePropertyChanged("SimpleObjects")
        End Set
    End Property

    Private Sub oSimpleObjects_PropertyChanged(sender As Object, e As ComponentModel.PropertyChangedEventArgs) Handles oSimpleObjects.PropertyChanged
        RaisePropertyChanged("SimpleObjects")
    End Sub

    ''' <summary>
    ''' обьект внешних данных
    ''' </summary>
    Friend ReadOnly Property DocumentService As clsDocumentService
        Get
            Return oDocumentService
        End Get
    End Property
End Class
