Imports nopTypes.Nop.Plugin.Misc.panoRazziRestService
Imports System.Globalization

Public Class uc_tierPrice

    Dim oSelected As clsTierPricesCollection
    Dim oSiteCurrency As clsTierPricesCollection.emCurrency

    Public Sub New()

        ' Этот вызов является обязательным для конструктора.
        InitializeComponent()

        ' Добавьте все инициализирующие действия после вызова InitializeComponent().
       
    End Sub

    Private Property oDefaultLang As lng

    Public ReadOnly Property SelectedObjects As clsTierPricesCollection
        Get
            Return oSelected
        End Get
    End Property

    ''' <summary>
    ''' Изменение списка выбранных значений
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Event ObjectListChanged(sender As Object, e As EventArgs)

    Private ocustomerRoles As clsCustomerRolesCollection
    Private ostores As clsStoresCollection

    Public Function GetBaseXML() As String
        If oSelected Is Nothing Then Return "no selected"
        Return oSelected.GetXML
    End Function

    Public Function GetStaticXML() As String
        If oSelected Is Nothing Then Return "no selected"
        Return oSelected.TierPriceStatic.GetXML
    End Function

    Private oPriceToolTip As New Windows.Forms.ToolTip

    ''' <summary>
    ''' делегат курсов валют
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property RateDelagate As Func(Of String, Decimal)

    Public Sub init(lang As lng, SiteCurrencyName As String, customerRoles As clsCustomerRolesCollection, stores As clsStoresCollection)
        oDefaultLang = lang
        ocustomerRoles = customerRoles
        ostores = stores

        Me.Uc_langObjectRoles.init(lang, customerRoles)
        Me.Uc_langObjectStore.init(lang, stores)

        Dim _curr As clsTierPricesCollection.emCurrency
        If Not [Enum].TryParse(Of clsTierPricesCollection.emCurrency)(SiteCurrencyName, _curr) Then
            MsgBox(String.Format("Переданое значение валюты {0} не может быть обработано. По умолчанию валютой сайта будут считаться Российские рубли (RUR)", SiteCurrencyName), vbInformation)
            _curr = clsTierPricesCollection.emCurrency.RUR
        End If
        oSiteCurrency = _curr
        Me.cbCurrency.Items.Clear()
        Me.cbCurrency.Items.AddRange([Enum].GetNames(GetType(clsTierPricesCollection.emCurrency)))
        Me.cbCurrency.SelectedItem = [Enum].GetName(GetType(clsTierPricesCollection.emCurrency), oSiteCurrency)
        Me.lbBaseCurrency.Text = [Enum].GetName(GetType(clsTierPricesCollection.emCurrency), oSiteCurrency)

        oSelected = clsTierPricesCollection.CreateInstance(oSiteCurrency)
        bs_tierPrice.DataSource = oSelected.TierPriceStatic
        AddHandler oSelected.TierPriceStatic.PropertyChanged, AddressOf oTierPriceStatic_PropertyChanged
        Me.ClsTierPricesCollectionBindingSource.DataSource = oSelected
        'добавлено 08.07.2015
        RaiseEvent ObjectListChanged(Me, EventArgs.Empty)
        Me.tbPrice.SelectAll()
    End Sub

    Private Sub oTierPriceStatic_PropertyChanged(sender As Object, e As ComponentModel.PropertyChangedEventArgs)
        RaiseEvent ObjectListChanged(Me, EventArgs.Empty)
    End Sub

    Private Sub btAddInList_Click(sender As Object, e As EventArgs) Handles btAddInList.Click
        'добавить цены
        Dim _acl = (From c In Uc_langObjectRoles.SelectedObjects From s In Uc_langObjectStore.SelectedObjects Select New With {.role = c, .store = s}).ToList
        'проверки
        If _acl.Count = 0 Then
            MsgBox(String.Format("Для добавления цены необходимо выбрать роли и/или магазины"))
            Return
        End If
        Dim _cult As CultureInfo = CultureInfo.CurrentCulture
        Dim _txt = Me.tbPrice.Text.Replace(".", _cult.NumberFormat.NumberDecimalSeparator).Replace(",", _cult.NumberFormat.NumberDecimalSeparator)
        Dim _price As Decimal = 0
        If Not Decimal.TryParse(_txt, _price) Then
            MsgBox(String.Format("Не удалось распознать цену {0}", _txt))
            Return
        End If
        If _price = 0 And cbx_DisableBuyButton.Checked = False Then
            MsgBox(String.Format("Цена должна быть отлична от нуля, либо сначала поставлена галочка не для продажи!"))
            Return
        End If
        Dim _curr As clsTierPricesCollection.emCurrency
        If cbCurrency.SelectedIndex < 0 And cbx_DisableBuyButton.Checked = False Then
            MsgBox(String.Format("Необходимо задать валюту"))
            Return
        End If

        If cbCurrency.SelectedIndex < 0 Then cbCurrency.SelectedItem = Me.lbBaseCurrency.Text

        _curr = [Enum].Parse(GetType(clsTierPricesCollection.emCurrency), cbCurrency.SelectedItem)
        Dim _tp As clsTierPrice

        For Each t In _acl
            _tp = clsTierPrice.CreateInstance(_price, _curr, t.role, t.store)
            If Not Me.ClsTierPricesCollectionBindingSource.Contains(_tp) Then
                Me.ClsTierPricesCollectionBindingSource.Add(_tp)
            Else
                MsgBox(String.Format("Цена для комбинации {0} + {1} уже задана ранее!", t.store, t.role), vbInformation)
                Return
            End If
        Next


        Me.Uc_langObjectRoles.ClearSelected()
        Me.Uc_langObjectStore.ClearSelected()
        Me.Refresh()
        RaiseEvent ObjectListChanged(Me, EventArgs.Empty)
    End Sub

    Private Sub lbTierPrices_MouseDoubleClick(sender As Object, e As Windows.Forms.MouseEventArgs) Handles lbTierPrices.MouseDoubleClick
        If lbTierPrices.SelectedItem Is Nothing Then Return
        'удалить из списка
        Me.ClsTierPricesCollectionBindingSource.Remove(lbTierPrices.SelectedItem)
    End Sub

    Private Sub cbx_DisableBuyButton_CheckedChanged(sender As Object, e As EventArgs) Handles cbx_DisableBuyButton.CheckedChanged
        If oSelected.Count = 0 Then
            MsgBox(String.Format("Задайте хотя бы одну цену. Можно нулевую."))
        End If
    End Sub

    Private Sub btRemovePrice_Click(sender As Object, e As EventArgs) Handles btRemovePrice.Click
        If Me.ClsTierPricesCollectionBindingSource.Current Is Nothing Then Return
        Me.ClsTierPricesCollectionBindingSource.RemoveCurrent()
        Me.Uc_langObjectRoles.ClearSelected()
        Me.Uc_langObjectStore.ClearSelected()
        Me.Refresh()
        RaiseEvent ObjectListChanged(Me, EventArgs.Empty)
    End Sub

    Private Sub tbPrice_MouseHover(sender As Object, e As EventArgs) Handles tbPrice.MouseHover
        'отобразить курс пересчета в баксы
        'пересчет по курсу
        'If Me.RateDelagate Is Nothing Then Return
        If Me.cbCurrency.SelectedItem Is Nothing Then Return
        If Me.tbPrice.Text = "" Then Return
        'oSiteCurrency = валюта сайта
        'выполнить пересчет с учетом последующего округления // (100 USD) =6000руб =102,3USD
        '(12500RUR) =13000RUR
        Dim _currentPrice As Decimal
        If Decimal.TryParse(Me.tbPrice.Text, _currentPrice) Then
            Dim _currency = [Enum].Parse(GetType(clsTierPricesCollection.emCurrency), Me.cbCurrency.SelectedItem)
            Dim _sitePrice = clsTierPricesCollection.CalculateSitePrice(_currentPrice, _currency)
            Dim _siteCurrencyString = [Enum].GetName(GetType(clsTierPricesCollection.emCurrency), clsTierPricesCollection.SiteBaseCurrency)
            Dim _resultPriceInCurrency As Decimal = Math.Round(_sitePrice * clsTierPricesCollection.Rates(_currency), 2)

            oPriceToolTip.ToolTipTitle = "Базовая для сайта " & _siteCurrencyString
            Dim _textValue = String.Format("({1}{2}) ={0}{3}; ={4}{2})", _sitePrice, _currentPrice, Me.cbCurrency.SelectedItem, _siteCurrencyString, _resultPriceInCurrency)
            oPriceToolTip.Show(_textValue, tbPrice)
        End If
    End Sub

    Private Sub tbPrice_MouseLeave(sender As Object, e As EventArgs) Handles tbPrice.MouseLeave
        oPriceToolTip.Hide(tbPrice)
    End Sub

   
   

   

    Private Sub Label1_MouseClick(sender As Object, e As Windows.Forms.MouseEventArgs) Handles Label1.MouseClick
        Dim _tb As Windows.Forms.TextBoxBase = Me.tbPrice
        _tb.Text = ""
        clsExternalData.GetDigiKey.connect(_tb)
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Label2_MouseClick(sender As Object, e As Windows.Forms.MouseEventArgs) Handles Label2.MouseClick
        Dim _tb As Windows.Forms.TextBoxBase = Me.TextBox1
        _tb.Text = ""
        clsExternalData.GetDigiKey.connect(_tb)
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub Label3_MouseClick(sender As Object, e As Windows.Forms.MouseEventArgs) Handles Label3.MouseClick
        Dim _tb As Windows.Forms.TextBoxBase = Me.TextBox2
        _tb.Text = ""
        clsExternalData.GetDigiKey.connect(_tb)
    End Sub
End Class
