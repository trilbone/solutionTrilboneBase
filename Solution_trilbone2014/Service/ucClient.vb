Imports System.Windows.Forms
Imports System.Drawing
Imports System.Linq

Public Class ucClient
    Private oMCinterface As Service.iMoySkladDataProvider
    Private oSplash As Form = clsApplicationTypes.SplashScreen

    Public Event CustomerSelected(sender As Object, e As CustomerSelectedEventArgs)
    Public Class CustomerSelectedEventArgs
        Inherits EventArgs

        Public Property Customer As iMoySkladDataProvider.clsClientInfo

        Public ReadOnly Property CustomerUUID As String
            Get
                Return Customer.UUID
            End Get
        End Property
    End Class

    ' ''' <summary>
    ' ''' установка адреса извне
    ' ''' </summary>
    ' ''' <value></value>
    ' ''' <returns></returns>
    ' ''' <remarks></remarks>
    Public Property ClientAddress As iMoySkladDataProvider.clsAddress
        Get
            Return CType(Me.IMoySkladDataProvider_AddressBindingSource.DataSource, iMoySkladDataProvider.clsAddress)
        End Get
        Set(value As iMoySkladDataProvider.clsAddress)
            Me.IMoySkladDataProvider_AddressBindingSource.DataSource = value
        End Set
    End Property
    Public Property UserID As String
        Get
            Return Me.UserIDTextBox.Text
        End Get
        Set(value As String)
            Me.UserIDTextBox.Text = value
        End Set
    End Property

    Public Sub New()

        ' Этот вызов является обязательным для конструктора.
        InitializeComponent()

        ' Добавьте все инициализирующие действия после вызова InitializeComponent().

    End Sub

    Public Sub init(msi As iMoySkladDataProvider)
        oMCinterface = msi
        Me.lbClientInterest.DataSource = New BindingSource(oMCinterface.GetClientsInterest, Nothing)
        Me.lbClientInterest.DisplayMember = "Value"
        Me.lbClientInterest.ValueMember = "Key"

        Me.lbClientTags.DataSource = New BindingSource(oMCinterface.GetClientsTags, Nothing)
        clear()
    End Sub


    Private Sub clear()
        Me.btSelectClient.Enabled = False
        Me.btCreateClient.Enabled = False
        Me.lbUserSearchStatus.Text = "найди клиента в МС"
    End Sub


    ''' <summary>
    ''' поиск клиента МС
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btSearchClientByFullName_Click(sender As Object, e As EventArgs) Handles btSearchClientByFullName.Click
        Me.lbUserSearchStatus.Text = "поиск клиента.."
        Application.DoEvents()
        lbCustomers.DataSource = Nothing
        Dim _result As New List(Of iMoySkladDataProvider.clsClientInfo)

        _result.AddRange(oMCinterface.FindCustomer("", EmailTextBox.Text.Trim, "", True))

        _result.AddRange(oMCinterface.FindCustomer("", "", UserIDTextBox.Text.Trim))

        _result.AddRange(oMCinterface.FindCustomer(tbFullName.Text.Trim, "", ""))

        If _result.Count = 0 Then
            Me.lbUserSearchStatus.Text = "этого клиента нет в базе"
            Me.btSelectClient.Enabled = False
            Me.btCreateClient.Enabled = True
            '  Me.IMoySkladDataProvider_AddressBindingSource.DataSource = New iMoySkladDataProvider.clsAddress
        Else
            Me.lbUserSearchStatus.Text = "выбери клиента"
            Me.btCreateClient.Enabled = False
            lbCustomers.DataSource = _result.Distinct.ToList
        End If


    End Sub

    ''' <summary>
    ''' смена клиента
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub lbCustomers_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbCustomers.SelectedIndexChanged
        If lbCustomers.SelectedItem Is Nothing Then
            Me.lbUserSearchStatus.Text = "выбери клиента"
            Me.btSelectClient.Enabled = False
            Return
        End If
        Me.btCreateClient.Enabled = False
        Me.btSelectClient.Enabled = True
        Me.lbUserSearchStatus.Text = lbCustomers.SelectedItem.ToString
        IMoySkladDataProvider_AddressBindingSource.DataSource = CType(lbCustomers.SelectedItem, iMoySkladDataProvider.clsClientInfo).address
    End Sub


    ''' <summary>
    ''' создание клиента
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btCreateClient_Click(sender As Object, e As EventArgs) Handles btCreateClient.Click
       
        If oSplash.Visible = False Then
            oSplash.Show()
            Application.DoEvents()
        End If

        Dim _address As Service.iMoySkladDataProvider.clsAddress

        If Not IMoySkladDataProvider_AddressBindingSource.Current Is Nothing Then
            IMoySkladDataProvider_AddressBindingSource.EndEdit()
            _address = IMoySkladDataProvider_AddressBindingSource.Current
        Else
            _address = New Service.iMoySkladDataProvider.clsAddress
        End If

        '----------
        Dim _clientiterest As String = ""
        If Not Me.lbClientInterest.SelectedItem Is Nothing Then
            _clientiterest = Me.lbClientInterest.SelectedItem.key
        End If
        '------------
        Dim _clientTags As New List(Of String)
        For Each t As String In lbClientTags.SelectedItems
            _clientTags.Add(t)
        Next

        'страну и место знакомства пока пропустили
        Dim _getPlace As String = "" ' clsApplicationTypes.DefaultAgent.GetAgentID("moysklad", "ClientGetPlace")
        Dim _ClientCountryUUID As String = ""

        Dim _result = oMCinterface.CreateCustomer(FullName:=Me.tbFullName.Text, Email:=EmailTextBox.Text, Address:=_address, AddressString:=_address.FullAddress, CustomerCode:=UserIDTextBox.Text, ClientInterestUUID:=_clientiterest, ClientInterestDetails:=Me.rtbClientInterestDetails.Text, description:=rtbClientComment.Text, ClientMCTags:=_clientTags.ToArray, ClientCountryUUID:=_ClientCountryUUID, ClientGetPlaceUUID:=_getPlace)

        oSplash.Hide()
        Application.DoEvents()

        If _result = "" Then
            Me.lbUserSearchStatus.Text = "Не удалось создать клиента"
        Else
            'Dim _str As New Service.iMoySkladDataProvider.clsClientInfo
            'With _str
            '    .Email = EmailTextBox.Text
            '    .FullName = tbFullName.Text
            '    .MSCode = UserIDTextBox.Text
            '    .UUID = _result
            'End With
            'Me.lbCustomers.DataSource = {_str}.ToList
            'Me.lbUserSearchStatus.Text = "Клиент создан"
            'Me.lbCustomers.SelectedIndex = 0

            'If Me.lbCustomers.Items.Count = 1 Then
            '    lbCustomers_SelectedIndexChanged(Me, EventArgs.Empty)
            'End If
            Me.btSearchClientByFullName_Click(Me.btSearchClientByFullName, EventArgs.Empty)
        End If
        oSplash.Hide()
    End Sub

    
    Private Sub btSelectClient_Click(sender As Object, e As EventArgs) Handles btSelectClient.Click
        If lbCustomers.SelectedItem Is Nothing Then

        End If
        RaiseEvent CustomerSelected(Me, New CustomerSelectedEventArgs With {.Customer = CType(lbCustomers.SelectedItem, iMoySkladDataProvider.clsClientInfo)})
    End Sub

    Private Sub btCreateAddress_Click(sender As Object, e As EventArgs) Handles btCreateAddress.Click
        Me.TabControl1.SelectedTab = TabPage2
    End Sub
End Class
