Imports System.Globalization
'Imports nopRestClient.Nop.Plugin.Misc.panoRazziRestService
Imports nopTypes.Nop.Plugin.Misc.panoRazziRestService

Public Class clsDocumentService

    Dim oSpecificAttributes As clsSAObjectCollection


    Dim oProductCategories As clsCategoriesObjectCollection


    Dim oCustomerRoles As clsCustomerRolesCollection


    Dim oLocalities As clsLangObjectCollection


    Dim oPictures As clsPicturesObjectCollection


    Dim oStores As clsStoresCollection
    Dim oxsltTemplates As List(Of clsExternalData.clsxslTemplate)

    Dim oSiteBaseCurrency As clsTierPricesCollection.emCurrency

    Dim oProductTag As clsLangObjectCollection





    Public Sub New(Attributes As Dictionary(Of LangObject, IEnumerable(Of LangObject)), Categories As IEnumerable(Of LangObject), CustomerRoles As IEnumerable(Of LangObject), Localities As IEnumerable(Of LangObject), Stores As IEnumerable(Of LangObject), SiteBaseCurrency As clsTierPricesCollection.emCurrency, Optional _ProductTag As IEnumerable(Of LangObject) = Nothing)
        ' key=атрибут value =коллекция его значений
        oSpecificAttributes = clsSAObjectCollection.CreateInstance()
        If Not Attributes Is Nothing Then
            For Each t In Attributes
                Dim _attr = clsSAObject.CreateInstance(t.Key)
                oSpecificAttributes.Add(_attr)
                For Each tt In t.Value
                    oSpecificAttributes.AddValue(clsSAObjectValue.CreateInstance(_attr, tt))
                Next
            Next
        End If

        oProductCategories = clsCategoriesObjectCollection.CreateInstance(Categories)
        oCustomerRoles = clsCustomerRolesCollection.CreateInstance(CustomerRoles)
        oLocalities = clsManufacturersObjectCollection.CreateInstance(Localities)
        oStores = clsStoresCollection.CreateInstance(Stores)
        oSiteBaseCurrency = SiteBaseCurrency

        oxsltTemplates = New List(Of clsExternalData.clsxslTemplate)
        oPictures = New clsPicturesObjectCollection

        If _ProductTag Is Nothing Then _ProductTag = clsLangObjectCollection.CreateInstance("ProductTag")
        oProductTag = clsLangObjectCollection.CreateInstance("ProductTag", _ProductTag)

    End Sub


    'Public Shared Function CreateInstance(SiteBaseCurrency As clsTierPricesCollection.emCurrency, Attributes As Dictionary(Of LangObject, IEnumerable(Of LangObject)), Categories As IEnumerable(Of LangObject), CustomerRoles As IEnumerable(Of LangObject), Localities As IEnumerable(Of LangObject), Stores As IEnumerable(Of LangObject), FullDescription As LangObject) As clsDocumentService
    '    Dim _new As New clsDocumentService
    '    With _new
    '        ' key=атрибут value =коллекция его значений
    '        .oSpecificAttributes = clsSAObjectCollection.CreateInstance()
    '        For Each t In Attributes
    '            Dim _attr = clsSAObject.CreateInstance(t.Key)
    '            .oSpecificAttributes.Add(_attr)
    '            For Each tt In t.Value
    '                .oSpecificAttributes.AddValue(clsSAObjectValue.CreateInstance(_attr, tt))
    '            Next
    '        Next
    '        .oProductCategories = clsCategoriesObjectCollection.CreateInstance(Categories)
    '        .oCustomerRoles = clsCustomerRolesCollection.CreateInstance(CustomerRoles)
    '        .oLocalities = clsManufacturersObjectCollection.CreateInstance(Localities)
    '        .oStores = clsStoresCollection.CreateInstance(Stores)
    '        .oSiteBaseCurrency = SiteBaseCurrency
    '        .oFullDescription = FullDescription
    '    End With
    '    Return _new
    'End Function

    Public ReadOnly Property SiteBaseCurrency As clsTierPricesCollection.emCurrency
        Get
            Return oSiteBaseCurrency
        End Get
    End Property
    ''' <summary>
    ''' это все доступные с сайта
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SpecificAttributes As clsSAObjectCollection
        Get
            Return oSpecificAttributes
        End Get
        Set(value As clsSAObjectCollection)
            oSpecificAttributes = value
        End Set
    End Property

    Public ReadOnly Property ProductCategories As clsCategoriesObjectCollection
        Get
            Return oProductCategories
        End Get
    End Property

    Public ReadOnly Property ProductTag As clsLangObjectCollection
        Get

            Return oProductTag
        End Get
    End Property





    Public ReadOnly Property CustomerRoles As clsCustomerRolesCollection
        Get
            Return oCustomerRoles
        End Get
    End Property

    Public ReadOnly Property Localities As clsManufacturersObjectCollection
        Get
            Return oLocalities
        End Get
    End Property

    Public ReadOnly Property Stores As clsStoresCollection
        Get
            Return oStores
        End Get
    End Property




#Region "мои поля"

    Public Property Pictures As clsPicturesObjectCollection
        Get
            Return oPictures
        End Get
        Set(value As clsPicturesObjectCollection)
            oPictures = value
        End Set
    End Property

    'Public Sub SetPictures(Pictures As clsPicturesObjectCollection)
    '    oPictures = Pictures
    'End Sub

    ''' <summary>
    '''список шаблонов
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property xsltTemplates As List(Of clsExternalData.clsxslTemplate)
        Get
            Return oxsltTemplates
        End Get
        Set(value As List(Of clsExternalData.clsxslTemplate))
            oxsltTemplates = value
        End Set
    End Property

   

#End Region






End Class
