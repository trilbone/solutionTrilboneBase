Imports nopTypes.Nop.Plugin.Misc.panoRazziRestService
Imports System.Globalization

''' <summary>
''' содержит коллекцию магазинов
''' </summary>
''' <remarks></remarks>
Public Class clsStoresCollection
    Inherits clsLangObjectCollection
    Public Shadows Function GetXML() As String
        Dim _xml = New XElement("Stores")
        For Each t In Me.Distinct
            _xml.Add(New XElement("StoreID", t.ObjectId))
        Next
        Return _xml.ToString
    End Function
    Public Shared Shadows Function CreateInstance(Optional base As IEnumerable(Of LangObject) = Nothing) As clsStoresCollection
        Dim _new = New clsStoresCollection
        With _new
            .oCollectionName = "Stores"
            If Not base Is Nothing Then
                .AddRange(base)
            End If
        End With
        Return _new
    End Function
    ''' <summary>
    ''' в коллекцию добавляются только однотипные обьекты по _groupName
    ''' </summary>
    ''' <remarks></remarks>
    Shadows Sub Add(StoreName As String, StoreID As Integer)
        Dim _new = LangObject.CreateInstance("Stores", StoreName, StoreName, StoreName)
        _new.ObjectId = StoreID
        MyBase.Add(_new)
    End Sub


End Class


''' <summary>
''' содержит коллекцию ролей
''' </summary>
''' <remarks></remarks>
Public Class clsCustomerRolesCollection
    Inherits clsLangObjectCollection
    Public Shadows Function GetXML() As String
        Dim _xml = New XElement("CustomerRoles")
        For Each t In Me.Distinct
            _xml.Add(New XElement("CustomerRoleID", t.ObjectId))
        Next
        Return _xml.ToString
    End Function
    Public Shared Shadows Function CreateInstance(Optional base As IEnumerable(Of LangObject) = Nothing) As clsCustomerRolesCollection
        Dim _new = New clsCustomerRolesCollection
        With _new
            .oCollectionName = "CustomerRoles"
            If Not base Is Nothing Then
                For Each t In base
                    t._groupName = .oCollectionName
                Next
                .AddRange(base)
            End If
        End With
        Return _new
    End Function
    ''' <summary>
    ''' в коллекцию добавляются только однотипные обьекты по _groupName
    ''' </summary>
    ''' <remarks></remarks>
    Shadows Sub Add(RoleName As String, RoleID As Integer)
        Dim _new = LangObject.CreateInstance("CustomerRoles", RoleName, RoleName, RoleName)
        _new.ObjectId = RoleID
        MyBase.Add(_new)
    End Sub

End Class


''' <summary>
''' разрешения для товара
''' </summary>
''' <remarks></remarks>
Public Class clsProductACL
    Implements System.ComponentModel.INotifyPropertyChanged

    Dim WithEvents oCustomerRolesACL As clsCustomerRolesCollection
    Dim WithEvents oStoresACL As clsStoresCollection
    Dim oPublished As Boolean

    Public Shared Function CreateInstance() As clsProductACL
        Dim _new As New clsProductACL
        _new.StoresACL = clsStoresCollection.CreateInstance
        _new.CustomerRolesACL = clsCustomerRolesCollection.CreateInstance
        _new.Published = False
        Return _new
    End Function

    Public Property CustomerRolesACL As clsCustomerRolesCollection
        Get
            Return oCustomerRolesACL
        End Get
        Set(value As clsCustomerRolesCollection)
            oCustomerRolesACL = value
            RaisePropertyChanged("CustomerRolesACL")
        End Set
    End Property

    Public Property StoresACL As clsStoresCollection
        Get
            Return oStoresACL
        End Get
        Set(value As clsStoresCollection)
            oStoresACL = value
            RaisePropertyChanged("StoresACL")
        End Set
    End Property

    ''' <summary>
    ''' Продукт опубликован
    ''' </summary>
    Public Property Published As Boolean
        Get
            Return oPublished
        End Get
        Set(value As Boolean)
            oPublished = value
            RaisePropertyChanged("Published")
        End Set
    End Property


    Public Function GetXML() As String
        Dim _xml = New XElement("ProductAcl")
        If oCustomerRolesACL.Count > 0 Then
            _xml.Add(XElement.Parse(CustomerRolesACL.GetXML))
        End If
        If oStoresACL.Count > 0 Then
            _xml.Add(XElement.Parse(StoresACL.GetXML))
        End If

        If oCustomerRolesACL.Count = 0 And oStoresACL.Count = 0 Then
            MsgBox("Внимание! Роли клиентов не установлены!", vbInformation)
        End If

        Return _xml.ToString
    End Function


    Protected Sub RaisePropertyChanged(ByVal propertyName As String)
        Dim propertyChanged As System.ComponentModel.PropertyChangedEventHandler = Me.PropertyChangedEvent
        If (Not (propertyChanged) Is Nothing) Then
            propertyChanged(Me, New System.ComponentModel.PropertyChangedEventArgs(propertyName))
        End If
    End Sub

    Public Event PropertyChanged(sender As Object, e As ComponentModel.PropertyChangedEventArgs) Implements ComponentModel.INotifyPropertyChanged.PropertyChanged


    Private Sub oStoresACL_PropertyChanged(sender As Object, e As ComponentModel.PropertyChangedEventArgs) Handles oStoresACL.PropertyChanged
        If e.PropertyName = "Count" Then
            RaisePropertyChanged("StoresACL")
        End If
    End Sub

    Private Sub oCustomerRolesACL_PropertyChanged(sender As Object, e As ComponentModel.PropertyChangedEventArgs) Handles oCustomerRolesACL.PropertyChanged
        If e.PropertyName = "Count" Then
            RaisePropertyChanged("CustomerRolesACL")
        End If
    End Sub
End Class

Public Class clsTierPriceStatic
    Implements System.ComponentModel.INotifyPropertyChanged


    Dim oCallForPrice As Boolean


    Dim oCustomerEntersPrice As Boolean


    Dim oMaximumCustomerEnteredPrice As Decimal


    Dim oMinimumCustomerEnteredPrice As Decimal
    Dim oDisableBuyButton As Boolean

    ''' <summary>
    ''' Звонок о цене
    ''' </summary>
    Public Property CallForPrice As Boolean
        Get
            Return oCallForPrice
        End Get
        Set(value As Boolean)
            oCallForPrice = value
            RaisePropertyChanged("CallForPrice")
        End Set
    End Property

    ''' <summary>
    ''' Покупатель вводит цену
    ''' </summary>
    Public Property CustomerEntersPrice As Boolean
        Get
            Return oCustomerEntersPrice
        End Get
        Set(value As Boolean)
            oCustomerEntersPrice = value
            RaisePropertyChanged("CustomerEntersPrice")
        End Set
    End Property

    ''' <summary>
    ''' макс цена ввода
    ''' </summary>
    Public Property MaximumCustomerEnteredPrice As Decimal
        Get
            Return oMaximumCustomerEnteredPrice
        End Get
        Set(value As Decimal)
            oMaximumCustomerEnteredPrice = value
            RaisePropertyChanged("MaximumCustomerEnteredPrice")
        End Set
    End Property

    ''' <summary>
    ''' мин цена ввода
    ''' </summary>
    Public Property MinimumCustomerEnteredPrice As Decimal
        Get
            Return oMinimumCustomerEnteredPrice
        End Get
        Set(value As Decimal)
            oMinimumCustomerEnteredPrice = value
            RaisePropertyChanged("MinimumCustomerEnteredPrice")
        End Set
    End Property

    ''' <summary>
    ''' Не для продажи
    ''' </summary>
    Public Property DisableBuyButton As Boolean
        Get
            Return oDisableBuyButton
        End Get
        Set(value As Boolean)
            oDisableBuyButton = value
            RaisePropertyChanged("DisableBuyButton")
        End Set
    End Property


    Protected Sub RaisePropertyChanged(ByVal propertyName As String)
        Dim propertyChanged As System.ComponentModel.PropertyChangedEventHandler = Me.PropertyChangedEvent
        If (Not (propertyChanged) Is Nothing) Then
            propertyChanged(Me, New System.ComponentModel.PropertyChangedEventArgs(propertyName))
        End If
    End Sub


    Public Function GetXML() As String
        Dim _xml = New XElement("TierPricesStatic")
        With _xml
            .Add(New XElement("CallForPrice", Me.CallForPrice.ToString.ToLower))
            .Add(New XElement("CustomerEntersPrice", Me.CustomerEntersPrice.ToString.ToLower))
            .Add(New XElement("MinimumCustomerEnteredPrice", MinimumCustomerEnteredPrice.ToString.Replace(",", ".")))
            .Add(New XElement("MaximumCustomerEnteredPrice", Me.MaximumCustomerEnteredPrice.ToString.Replace(",", ".")))
        End With
        Return _xml.ToString
    End Function

    Public Event PropertyChanged(sender As Object, e As ComponentModel.PropertyChangedEventArgs) Implements ComponentModel.INotifyPropertyChanged.PropertyChanged
End Class

Public Class clsTierPricesCollection
    Inherits List(Of clsTierPrice)
    Implements System.ComponentModel.INotifyPropertyChanged

    Public Enum emCurrency
        USD
        RUR
        EUR
    End Enum

    Shared oRates As Dictionary(Of emCurrency, Decimal)
    Private Shared oBaseCurrency As emCurrency
    Dim WithEvents oTierPriceStatic As clsTierPriceStatic

















    ''' <summary>
    ''' Базовая валюта, курс которой на сайте равен 1. От нее считаются курсы по ЦБ.
    ''' </summary>
    Public Shared Property SiteBaseCurrency As clsTierPricesCollection.emCurrency
        Get
            Return oBaseCurrency
        End Get
        Set(value As clsTierPricesCollection.emCurrency)
            oBaseCurrency = value
        End Set
    End Property


    ''' <summary>
    ''' Записывает курсы валют
    ''' </summary>
    Public Shared Property Rates As System.Collections.Generic.Dictionary(Of clsTierPricesCollection.emCurrency, Decimal)
        Get
            If oRates Is Nothing Then
                'значения по умолчанию на 13.03.2015
                oRates = New System.Collections.Generic.Dictionary(Of clsTierPricesCollection.emCurrency, Decimal)
                oRates.Add(emCurrency.RUR, 1)
                oRates.Add(emCurrency.USD, 0.0163)
                oRates.Add(emCurrency.EUR, 0.0154)
            End If
            Return oRates
        End Get
        Set(value As System.Collections.Generic.Dictionary(Of clsTierPricesCollection.emCurrency, Decimal))
            oRates = value
        End Set
    End Property

    ''' <summary>
    ''' Общие свойства
    ''' </summary>
    Public Property TierPriceStatic As clsTierPriceStatic
        Get
            Return oTierPriceStatic
        End Get
        Set(value As clsTierPriceStatic)
            oTierPriceStatic = value
            RaisePropertyChanged("TierPriceStatic")
        End Set
    End Property

    Public Function GetXML() As String
        Dim _xml = New XElement("TierPrices")
        For Each t In Me
            _xml.Add(XElement.Parse(t.GetXML))
        Next
        Return _xml.ToString
    End Function
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="siteBaseCurrency"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CreateInstance(siteBaseCurrency As emCurrency) As clsTierPricesCollection
        Dim _new = New clsTierPricesCollection
        clsTierPricesCollection.SiteBaseCurrency = siteBaseCurrency
        _new.TierPriceStatic = New clsTierPriceStatic
        _new.TierPriceStatic.CallForPrice = False
        _new.TierPriceStatic.CustomerEntersPrice = False
        Return _new
    End Function

    ''' <summary>
    ''' форматированная строка цены
    ''' </summary>
    ''' <param name="Price">цена</param>
    ''' <param name="Currency">валюта</param>
    Public Shared Function GetPriceString(Price As Decimal, Currency As clsTierPricesCollection.emCurrency) As String
        Dim _cult As CultureInfo = CultureInfo.CurrentCulture
        Select Case Currency
            Case emCurrency.USD
                _cult = New CultureInfo("en-US")
            Case emCurrency.RUR
                _cult = New CultureInfo("ru-RU", False)
            Case emCurrency.EUR
                _cult = New CultureInfo("fr-FR")
        End Select
        'C - формат валюты, 2 кол-во знаков дробной части
        Return Price.ToString("C2", _cult)
    End Function

    Public Shadows Sub Add(item As clsTierPrice)
        MyBase.Add(item)
    End Sub

    ''' <summary>
    ''' Пересчитывает переданную стоимость в валюту сайта. Возвращает округленное значение.
    ''' </summary>
    Public Shared Function CalculateSitePrice(price As Decimal, currency As emCurrency) As Decimal
        'перевод в рубли
        Dim _convertRate = Rates.FirstOrDefault(Function(x) x.Key = currency).Value
        If _convertRate = 0 Then Return price
        Dim _rurRate = Rates.FirstOrDefault(Function(x) x.Key = emCurrency.RUR).Value
        Dim _rur = price * _rurRate / _convertRate

        'перевод в валюту сайта
        Dim _baseRate = Rates.FirstOrDefault(Function(x) x.Key = SiteBaseCurrency).Value
        Dim _out = Math.Round(_rur * _baseRate, 0)
        If _convertRate = 0 Then Return price

        'округление
        Select Case _out
            Case Is <= 10
                _out = Math.Round(_out, 0)
            Case 10 To 100
                'до 10 ок
                _out = _out - (_out Mod 10) + 10
            Case 100 To 1000
                _out = _out - (_out Mod 100) + 100
            Case Is > 1000
                _out = _out - (_out Mod 1000) + 1000
        End Select
        Return _out
    End Function


    Protected Sub RaisePropertyChanged(ByVal propertyName As String)
        Dim propertyChanged As System.ComponentModel.PropertyChangedEventHandler = Me.PropertyChangedEvent
        If (Not (propertyChanged) Is Nothing) Then
            propertyChanged(Me, New System.ComponentModel.PropertyChangedEventArgs(propertyName))
        End If
    End Sub

    Public Event PropertyChanged(sender As Object, e As ComponentModel.PropertyChangedEventArgs) Implements ComponentModel.INotifyPropertyChanged.PropertyChanged

    Private Sub oTierPriceStatic_PropertyChanged(sender As Object, e As ComponentModel.PropertyChangedEventArgs) Handles oTierPriceStatic.PropertyChanged
        RaisePropertyChanged("TierPriceStatic")
    End Sub
End Class




''' <summary>
''' цена
''' </summary>
''' <remarks></remarks>
Public Class clsTierPrice
    Implements System.ComponentModel.INotifyPropertyChanged

    Dim oCustomerRolesACL As LangObject
    Dim oStoresACL As LangObject
    Dim oPrice As Decimal
    Dim oQty As Integer


    Public Property CustomerRolesACL As LangObject
        Get
            Return oCustomerRolesACL
        End Get
        Set(value As LangObject)
            oCustomerRolesACL = value
            RaisePropertyChanged("CustomerRolesACL")
        End Set
    End Property

    Public Property StoresACL As LangObject
        Get
            Return oStoresACL
        End Get
        Set(value As LangObject)
            oStoresACL = value
            RaisePropertyChanged("StoresACL")
        End Set
    End Property

    ''' <summary>
    ''' цена на сайт (в валюте сайта)
    ''' </summary>
    Public Property Price As Decimal
        Get
            Return oPrice
        End Get
        Set(value As Decimal)
            oPrice = value
            RaisePropertyChanged("Price")
        End Set
    End Property

    ''' <summary>
    ''' кол-во на сайт
    ''' </summary>
    Public Property Qty As Integer
        Get
            Return oQty
        End Get
        Set(value As Integer)
            oQty = value
            RaisePropertyChanged("Qty")
        End Set
    End Property

    ''' <summary>
    ''' цена в валюте
    ''' </summary>
    Public Property PriceInCurrency As Decimal

    ''' <summary>
    ''' валюта
    ''' </summary>
    Public Property Currency As clsTierPricesCollection.emCurrency


    Public ReadOnly Property CurrencyString As String
        Get
            Return [Enum].GetName(GetType(clsTierPricesCollection.emCurrency), Currency)
        End Get
    End Property

    Public Function GetXML() As String
        Dim _xml = New XElement("TierPrice")
        _xml.Add(New XElement("TierPriceId", "0"))
        _xml.Add(New XElement("StoreId", oStoresACL.ObjectId))
        _xml.Add(New XElement("CustomerRoleId", oCustomerRolesACL.ObjectId))
        _xml.Add(New XElement("Quantity", Me.oQty.ToString.Replace(",", ".")))
        _xml.Add(New XElement("Price", Me.Price.ToString.Replace(",", ".")))
        Return _xml.ToString
    End Function

    Protected Sub RaisePropertyChanged(ByVal propertyName As String)
        Dim propertyChanged As System.ComponentModel.PropertyChangedEventHandler = Me.PropertyChangedEvent
        If (Not (propertyChanged) Is Nothing) Then
            propertyChanged(Me, New System.ComponentModel.PropertyChangedEventArgs(propertyName))
        End If
    End Sub
    ''' <summary>
    ''' вернет форматированную строку
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overrides Function ToString() As String
        Dim _out As String = ""
        If StoresACL Is Nothing Then Return MyBase.ToString
        If CustomerRolesACL Is Nothing Then Return MyBase.ToString

        _out = String.Format("({0}) {1} {2}", StoresACL.ToString.Substring(0, 4), clsTierPricesCollection.GetPriceString(Me.PriceInCurrency, Me.Currency), CustomerRolesACL.ToString)
        Return _out
    End Function


    ''' <param name="price">цена в валюте</param>
    ''' <param name="currency">валюта цены</param>
    ''' <param name="role">разрешение</param>
    ''' <param name="store">разрешение</param>
    Public Shared Function CreateInstance(price As Decimal, currency As nopRestClient.clsTierPricesCollection.emCurrency, role As LangObject, store As LangObject, Optional qty As Integer = 1) As clsTierPrice
        Dim _new As New clsTierPrice
        With _new
            .PriceInCurrency = price
            .Currency = currency

            ' пересчитывает цену в валюте в цену сайта используя установленные курсы
            .Price = clsTierPricesCollection.CalculateSitePrice(price, currency)

            .CustomerRolesACL = role
            .StoresACL = store
            .Qty = qty
        End With
        Return _new
    End Function
    ''' <summary>
    ''' цены и количество в рассчет не принимаем!!!
    ''' </summary>
    ''' <param name="obj"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overrides Function Equals(obj As Object) As Boolean
        If obj Is Nothing Then Return False
        If Not TypeOf obj Is clsTierPrice Then Return False
        Dim _obj = CType(obj, clsTierPrice)
        If Me.CustomerRolesACL Is Nothing Then Return False
        If Me.StoresACL Is Nothing Then Return False
        If _obj.CustomerRolesACL Is Nothing Then Return False
        If _obj.StoresACL Is Nothing Then Return False

        If Not Me.CustomerRolesACL.Equals(_obj.CustomerRolesACL) Then Return False
        If Not Me.StoresACL.Equals(_obj.StoresACL) Then Return False

        'If Not Me.Price = _obj.Price Then Return False
        'If Not Me.Qty = _obj.Qty Then Return False
        Return True
    End Function
    ''' <summary>
    ''' цены и количество в рассчет не принимаем!!!
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overrides Function GetHashCode() As Integer
        If Me.CustomerRolesACL Is Nothing Then Return MyBase.GetHashCode()
        If Me.StoresACL Is Nothing Then Return MyBase.GetHashCode()
        Return Me.CustomerRolesACL.GetHashCode Xor Me.StoresACL.GetHashCode
    End Function

    Public Event PropertyChanged(sender As Object, e As ComponentModel.PropertyChangedEventArgs) Implements ComponentModel.INotifyPropertyChanged.PropertyChanged
End Class

