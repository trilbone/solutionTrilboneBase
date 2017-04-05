
Imports System.Configuration
Imports eBay.Service.Call
Imports eBay.Service.Core.Sdk
Imports eBay.Service.Core.Soap
Imports eBay.Service.Util
Imports System.Xml
Imports System.Linq
Imports System.Xml.Linq
Imports eBayTrilbone.Trilbone
Public Class Form1
    Sub New()
        InitializeComponent()
    End Sub

    Private oAgents As Trilbone.AUCTIONAGENT
    Private oTransaction As clsTransactionRequest

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btReadAccounts.Click
        oAgents = AUCTIONAGENT.CreateInstance("g:\TEAMPROGECTS_vs13\SolutionTrilboneBase\eBayTrilbone\eBayTrilbone\Agents.xml")
        Me.cbAccount.DataSource = oAgents.AGENT
        Me.cbAccount.DisplayMember = "account"
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btGetTransaction.Click
        If Me.cbAccount.SelectedItem Is Nothing Then Return
        oTransaction = clsTransactionRequest.CreateInstance(Me.cbAccount.SelectedItem)
        If oTransaction.IsSuccess Then
            ' Me.ListBox1.Items.Clear()
            Me.lblTransactionList.DataSource = oTransaction.ItemIdList
            Me.lblTransactionList.DisplayMember = "ItemID"
        Else
            Me.lblTransactionList.DataSource = Nothing
            Me.lblTransactionList.Items.Add("Error in respond")
        End If


    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lblTransactionList.SelectedIndexChanged
        If lblTransactionList.SelectedItem Is Nothing Then Return
        If oTransaction Is Nothing Then Return

        Dim _tmp = oTransaction.GetTransaction(CType(lblTransactionList.SelectedItem, ItemType).ItemID)

        If _tmp Is Nothing Then
            MsgBox("Не удалось получить данные транзакции", vbCritical)
            Return
        End If

        If _tmp.Buyer Is Nothing Then
            MsgBox("Не удалось получить данные транзакции - компонент Buyer", vbCritical)
            Return

        End If

        If _tmp.Buyer.BuyerInfo Is Nothing Then
            '_tmp.Buyer.BuyerInfo.ShippingAddress
            MsgBox("Не удалось получить данные транзакции - компонент Buyer.BuyerInfo", vbCritical)
            Return
        End If

        If _tmp.Buyer.BuyerInfo.ShippingAddress Is Nothing Then
            '_tmp.Buyer.BuyerInfo.ShippingAddress
            MsgBox("Не удалось получить данные транзакции - компонент Buyer.BuyerInfo.ShippingAddress", vbCritical)
            Return
        End If


        Try
            Me.TransactionTypeBindingSource.DataSource = _tmp
        Catch ex As Exception
            MsgBox(ex.Message)
            Me.TransactionTypeBindingSource.DataSource = Nothing
        End Try


        ' PAYPALFEE
        Dim _et = _tmp.ExternalTransaction

        Dim _fee = (From c As ExternalTransactionType In _et Select c.FeeOrCreditAmount.Value).Sum
        Dim _curr = (From c As ExternalTransactionType In _et Select c.FeeOrCreditAmount.currencyID).FirstOrDefault

        Me.tbFeePayPalCurrency.Text = _curr.ToString
        Me.tbPayPalFeeAmount.Text = _fee

        ' Me.TransactionTypeBindingSource.ResetBindings(False)
    End Sub

    Private Sub btBuildAddress_Click(sender As Object, e As EventArgs) Handles btBuildAddress.Click
        Dim _address As String = ""
        '----name
        If Not Me.NameTextBox.Text = "нет" Then
            _address += Me.NameTextBox.Text + ChrW(13)
        End If
        If Not Me.FirstNameTextBox.Text = "нет" Then
            _address += Me.FirstNameTextBox.Text + " " + Me.LastNameTextBox.Text + ChrW(13)
        End If
        'street
        If Not Me.StreetTextBox.Text = "нет" Then
            _address += Me.StreetTextBox.Text + ChrW(13)
        End If
        If Not Me.Street1TextBox.Text = "нет" Then
            _address += Me.Street1TextBox.Text + ChrW(13)
        End If
        If Not Me.Street2TextBox.Text = "нет" Then
            _address += Me.Street2TextBox.Text + ChrW(13)
        End If
        'postal & city
        If Not Me.PostalCodeTextBox.Text = "нет" Then
            _address += Me.PostalCodeTextBox.Text + " " + Me.CityNameTextBox.Text + ChrW(13)
        End If
        'province
        If Not Me.StateOrProvinceTextBox.Text = "нет" Then
            _address += Me.StateOrProvinceTextBox.Text + ChrW(13)
        End If
        'country
        If Not Me.CountryNameTextBox.Text = "нет" Then
            _address += Me.CountryNameTextBox.Text + ChrW(13)
        End If
        'phone
        If Not Me.PhoneTextBox.Text = "нет" Then
            _address += Me.PhoneTextBox.Text + ChrW(13)
        End If
        If Not Me.Phone2TextBox.Text = "нет" Then
            _address += Me.Phone2TextBox.Text + ChrW(13)
        End If

        Me.RichTextBox1.Text = _address

    End Sub

   

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles btCreateDemand.Click
        'Dim a As TransactionType = Me.TransactionTypeBindingSource.Current
        'Dim b = 0

    End Sub

    Private Sub ValueLabel1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btFullName_Click(sender As Object, e As EventArgs) Handles btFullName.Click
        Me.tbFullName.Text = Me.UserFirstNameTextBox.Text & " " & Me.UserLastNameTextBox.Text
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        If Me.TransactionTypeBindingSource.Current Is Nothing Then Return
        If Me.oTransaction Is Nothing Then Return

        Dim _tr As TransactionType = Me.TransactionTypeBindingSource.Current
        Dim _count As Integer
        Dim _order = Me.oTransaction.GetOrder(_tr.Item.ItemID, _count)
        If _count <= 0 Then Return

        Dim b = 0

    End Sub
End Class
