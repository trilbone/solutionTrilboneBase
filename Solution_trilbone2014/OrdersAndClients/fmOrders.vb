Imports Service
Imports System.Linq
Imports Trilbone
Imports Service.Catalog

Public Class fmOrders
    'вызов загрузки нужных данных работает из соответствующего свойства

    Private oCurrentOrder As Service.clsApplicationTypes.clsOrder
    Private oCurrentSample As Service.clsApplicationTypes.clsSampleNumber
    Private oCurrentClientID As Decimal
    Private oCurrentOrderRow As dsOrders.Select_tb_OrdersRow
    Private oCurrentSampleRow As dsOrders.SamplesAndOrdersRow


#Region "Data properties"
    ' проверяем входное значение и вызываем процедуру загрузки данных

    ''' <summary>
    ''' проверяем входное значение и вызываем процедуру загрузки данных
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property CurrentOrderID As String
        Get
            Return oCurrentOrder.OrderID
        End Get
        Set(ByVal value As String)
            If Not (value = "" And value.Length > 10) Then
                If oCurrentOrder Is Nothing Then
                    oCurrentOrder = New clsApplicationTypes.clsOrder(value)
                Else
                    oCurrentOrder.OrderID = value

                End If
                Me.LoadOrderData()
            Else
                oCurrentOrder = Nothing
            End If
        End Set
    End Property
    ''' <summary>
    ''' проверяем входное значение и вызываем процедуру загрузки данных
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property CurrentSample As Decimal
        Get
            If Me.oCurrentSample Is Nothing Then Return 0
            Return oCurrentSample.GetEan13
        End Get
        Set(ByVal value As Decimal)

            Me.oCurrentSample = Service.clsApplicationTypes.clsSampleNumber.CreateFromString(value.ToString)
            LoadSampleData()
        End Set
    End Property
    ''' <summary>
    ''' проверяем входное значение и вызываем процедуру загрузки данных
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property CurrentClientID As Decimal
        Get
            Return oCurrentClientID
        End Get
        Set(ByVal value As Decimal)


            If Not (IsDBNull(value) Or value = 0) Then
                oCurrentClientID = value
                Me.LoadClientData()
            Else
                oCurrentClientID = 0
            End If
        End Set
    End Property

#End Region

    ''' <summary>
    ''' new
    ''' </summary>
    ''' <param name="OrderID"></param>
    ''' <remarks>вызов процедуры загрузки осущ из свойства</remarks>
    Public Sub New(ByVal OrderID As String)
        InitializeComponent()
        'задать обработчик изменения строки в таблице с образцами
        AddHandler Me.DsSampleInOrder.SamplesINOrders.SamplesINOrdersRowChanged, AddressOf SampleInOrderTable_rowchanged
        AddHandler Me.DsSampleInOrder.SamplesINOrders.SamplesINOrdersRowDeleted, AddressOf SampleInOrder_deleteRow

        Me.cbTypeOfCatalog.SelectedIndex = 0

        If Me.TestOrderID(OrderID) Then
            Me.CurrentOrderID = OrderID

        Else
            If Not (OrderID Is Nothing) AndAlso OrderID.Length = 8 Then
                Me.CreateNewOrder(OrderID)
            Else
                Me.CurrentOrderID = ""
            End If

        End If
        oFlagDataLoaded = False
    End Sub
#Region "Handlers"
    Private Sub SampleInOrderTable_rowchanged(ByVal sender As Object, ByVal e As dsSampleInOrder.SamplesINOrdersRowChangeEvent)
        If Me.DsSampleInOrder.HasChanges = True Then
            Me.btSaveChanges.BackColor = Color.Red
        Else
            Me.btSaveChanges.BackColor = Color.FromKnownColor(KnownColor.Control)
        End If

    End Sub

    'Private Sub SampleInOrder_addnewrow(ByVal sender As Object, ByVal e As System.Data.DataTableNewRowEventArgs)

    '    'If DsSampleInOrder.HasChanges(System.Data.DataRowState.Added) = True Then
    '    '    Me.lbCountNewRowInSample.Tag += 1

    '    '    Me.lbCountNewRowInSample.Text = "to saving " & " new rows."
    '    'End If

    'End Sub

    Private Sub SampleInOrder_deleteRow(ByVal sender As Object, ByVal e As OrdersAndClients.dsSampleInOrder.SamplesINOrdersRowChangeEvent)
        If Me.DsSampleInOrder.HasChanges(Data.DataRowState.Deleted) = True Then
            Me.btSaveChanges.BackColor = Color.Red
        End If
    End Sub
#End Region

    Private Function CreateNewOrder(ByVal NewOrderID As String) As Boolean
        Me.DsOrders.Select_tb_Orders.AddSelect_tb_OrdersRow(NewOrderID, 0, New DateTime, "", _
                0, False, New DateTime, 0, "", 0, False, New DateTime, 0, 0, False, New DateTime, _
                False, New DateTime)
        Me.Select_tb_OrdersBindingSource.EndEdit()

        MsgBox("Added: " & Me.Select_tb_OrdersTableAdapter.Update(Me.DsOrders.Select_tb_Orders) & " records")

        Me.CurrentOrderID = NewOrderID

        Return True
    End Function
    ''' <summary>
    ''' возвращает кол-во записей в БД с этим OrderID
    ''' </summary>
    ''' <param name="OrderID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function TestOrderID(ByVal OrderID As String) As Boolean

        Try
            Me.Select_tb_OrdersTableAdapter.Fill(DsOrders.Select_tb_Orders, OrderID)

        Catch ex As Exception
            MsgBox("Can't connect to DB. Connection string: " & Me.Select_tb_OrdersTableAdapter.Connection.ConnectionString)
            Return False
        End Try


        Select Case Me.DsOrders.Select_tb_Orders.Count
            Case 0
                Return False
            Case 1
                Return True
            Case Else
                MsgBox("Заказов с этим ID больше одного!", MsgBoxStyle.Critical)
                Return True
        End Select
    End Function


    Private Sub LoadOrderData()
        'receive data from DB


        Me.Select_tb_OrdersTableAdapter.Fill(DsOrders.Select_tb_Orders, Me.CurrentOrderID)
        Me.Select_Clients_tb_ClientsTableAdapter.Fill(DsService.Select_Clients_tb_Clients)
        Me.Select_AllSamplesInOrders_tb_SamplesAndOrdersTableAdapter.Fill _
            (DsService.Select_AllSamplesInOrders_tb_SamplesAndOrders, Me.CurrentOrderID)
        'загрузка списка образцов
        Me.SamplesINOrdersTableAdapter.Fill(Me.DsSampleInOrder.SamplesINOrders, Me.tbOrderID.Text)

        Me.lbCountNewRowInSample.Tag = 0
        Me.lbCountNewRowInSample.Text = ""


        'result
        If Me.DsOrders.Select_tb_Orders.Count = 0 Then
            MsgBox("заказа с этим ID нет", MsgBoxStyle.Critical)
            Me.oCurrentOrder.OrderID = ""
            Me.oCurrentOrderRow = Nothing
            Exit Sub
        Else
            Me.oCurrentOrderRow = DsOrders.Select_tb_Orders.FindByOrderID(Me.oCurrentOrder.OrderID)
        End If



        'work with controls
        Me.tbOrderID.Text = Me.CurrentOrderID

        If Me.Select_AllSamplesInOrders_tb_SamplesAndOrdersBindingSource.Count = 0 Then
            'образцов для показа нет
            For Each _ctl As Control In Me.TabPage_SamplesInOrder.Controls
                _ctl.Enabled = False
            Next
            Me.btAddSampleToOrder.Enabled = True
        Else
            'отобразить все эу
            For Each _ctl As Control In Me.TabPage_SamplesInOrder.Controls
                _ctl.Enabled = True
            Next
            'пересчитать все поля
            Me.CalculateOrderField()
        End If

        Me.CurrentClientID = DsOrders.Select_tb_Orders.Rows(0).Item("ClientID")

        oFlagDataLoaded = True
    End Sub

    Private oFlagDataLoaded As Boolean

    ''' <summary>
    ''' пересчитывает финансовые поля заказа
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CalculateOrderField()
        'Exit Sub
        Dim _tmpOrderPrice As Decimal
        Dim _tmpConfirmPrice As Decimal
        Dim _tmpShippingPrice As Decimal


        ''перебрать все образцы в заказе
        For Each _tmp As dsService.Select_AllSamplesInOrders_tb_SamplesAndOrdersRow In DsService.Select_AllSamplesInOrders_tb_SamplesAndOrders

            '_tmp.SampleNumber

        Next


        With Me.oCurrentOrderRow
            'заявленная цена = цена * скидку
            For Each _tmpSampleRow As dsOrders.SamplesAndOrdersRow In Me.DsOrders.SamplesAndOrders
                'прибавить тотал
                _tmpOrderPrice += _tmpSampleRow.Price * (_tmpSampleRow.Discount * 0.01)
                'прибавить тотал
                _tmpConfirmPrice += _tmpSampleRow.ConfirmPrice
                'прибавить тотал
                _tmpShippingPrice += _tmpSampleRow.ConfirmShippingPrice

                'проверить валюту
                If Not .CurrencyName = _tmpSampleRow.CurrencyName Then
                    'пересчитать валюту все курсы - к рублю
                    If .RateOfExchange = 0 Then
                        MsgBox("Необходимо задать курс! Пересчет невозможен!")
                        Exit Sub
                    End If
                    Dim _curr As Single = (_tmpSampleRow.RateOfExchange / .RateOfExchange)
                    _tmpOrderPrice = _tmpOrderPrice * _curr
                    _tmpConfirmPrice = _tmpConfirmPrice * _curr
                    _tmpShippingPrice = _tmpShippingPrice * _curr
                Else
                End If
            Next
            'перенести значения в заказ
            .OrderTotalPrice = _tmpOrderPrice
            .ConfirmTotalOrderPrice = _tmpConfirmPrice
            .ShippingPrice = _tmpShippingPrice
        End With

        'сохранить изменения
        Me.Select_tb_OrdersBindingSource.ResetCurrentItem()

    End Sub

    ''' <summary>
    ''' load sample data
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadSampleData()
        '
        If Me.CurrentSample = 0 Then
            Exit Sub
        End If

        Me.SamplesAndOrdersTableAdapter.Fill(DsOrders.SamplesAndOrders, Me.CurrentSample, Me.CurrentOrderID)
        Me.Select_SampleInfoTableAdapter.Fill(DsService.Select_SampleInfo, Me.CurrentSample)

        'work with controls
        For Each _ctl As Control In Me.TabPage_SamplesInOrder.Controls
            _ctl.Enabled = True
        Next
    End Sub


    ''' <summary>
    ''' load client data
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadClientData()
        Me.Select_OrdersForClientTableAdapter.Fill(DsService.Select_OrdersForClient, Me.CurrentClientID)
    End Sub


    ''' <summary>
    ''' load form
    ''' 1.  загрузка списка валют
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub fmOrders_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'window position
        If Not Me.ParentForm Is Nothing Then
            Me.Location = New Point(Me.ParentForm.ClientRectangle.Left, Me.ParentForm.ClientRectangle.Top)
        Else
            Me.StartPosition = FormStartPosition.CenterScreen
        End If
        '
        Me.OrderCurrencyNameComboBoxOrder.DataSource = Global.Service.clsApplicationTypes.CurrencyList
        Me.OrderCurrencyNameComboBoxOrder.SelectedIndex = 0
        Me.SampleCurrencyNameComboBox.DataSource = Global.Service.clsApplicationTypes.CurrencyList
        Me.SampleCurrencyNameComboBox.SelectedIndex = 0

    End Sub

    ''' <summary>
    ''' отобразить список заказов для выбранного клиента
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ClientIDComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClientIDComboBox.SelectedIndexChanged
        '
        Me.CurrentClientID = Me.ClientIDComboBox.SelectedValue
    End Sub
    ''' <summary>
    ''' change currency labels
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CurrencyNameComboBoxOrder_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OrderCurrencyNameComboBoxOrder.SelectedIndexChanged
        '
        Me.LabelUSD1.Text = Me.OrderCurrencyNameComboBoxOrder.SelectedItem
        Me.LabelUSD2.Text = Me.OrderCurrencyNameComboBoxOrder.SelectedItem
        Me.LabelUSD3.Text = Me.OrderCurrencyNameComboBoxOrder.SelectedItem
        Me.LabelUSD4.Text = Me.OrderCurrencyNameComboBoxOrder.SelectedItem

        'проверка наличия курса в буфере
        If Not Me.OrderCurrencyNameComboBoxOrder.SelectedItem Is Nothing Then
            'курс в буфере
            Me.OrderRateOfExchangeTextBox.Text = Service.clsApplicationTypes.CurrencyRateNow _
                (Me.OrderCurrencyNameComboBoxOrder.SelectedItem)
        End If

        OrderRateOfExchangeTextBox.Focus()

    End Sub
    ''' <summary>
    ''' change currency labels
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CurrencyNameComboBoxSample_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SampleCurrencyNameComboBox.SelectedIndexChanged
        '
        Me.LabelUSDspl1.Text = Me.SampleCurrencyNameComboBox.SelectedItem
        Me.LabelUSDspl2.Text = Me.SampleCurrencyNameComboBox.SelectedItem
        Me.LabelUSDspl3.Text = Me.SampleCurrencyNameComboBox.SelectedItem
        'проверка наличия курса в буфере
        If Not Me.SampleCurrencyNameComboBox.SelectedItem Is Nothing Then
            'курс в буфере
            Me.SampleRateOfExchangeTextBox.Text = Service.clsApplicationTypes.CurrencyRateNow _
                (Me.SampleCurrencyNameComboBox.SelectedItem)
        End If

        Me.SampleRateOfExchangeTextBox.Focus()

    End Sub
    ''' <summary>
    ''' add new client
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btNewClient_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btNewClient.Click
        Dim _fm As New fmClients
        _fm.ShowDialog()

        'перечитать источник
        Me.Select_Clients_tb_ClientsTableAdapter.Fill(DsService.Select_Clients_tb_Clients)

        'выбрать нового клиента
        Me.ClientIDComboBox.SelectedValue = _fm.NewClientID

    End Sub
    ''' <summary>
    ''' загружаем выбранный образец
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub SampleNumberListBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SampleNumberListBox.SelectedIndexChanged
        If Not Me.CurrentSample = Me.SampleNumberListBox.SelectedValue Then
            Me.CurrentSample = Me.SampleNumberListBox.SelectedValue
        End If
        Me.ListViewSampleImages.Clear()
    End Sub
    ''' <summary>
    ''' добавить образец в заказ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btAddSample_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btAddSampleToOrder.Click

        Me.Cursor = Cursors.WaitCursor
        Dim _list As String() = clsOrderService.GetOnSaleSamplesList

        Dim _param As Object = {_list, "Samples On Sale"}
        Dim _fm As Object = Service.clsApplicationTypes.DelegateStoreApplicationForm(clsApplicationTypes.emFormsList.fmSampleList).Invoke(_param)
        If _fm Is Nothing Then
            Exit Sub
        End If
        Me.Cursor = Cursors.Default
        _fm.ShowDialog(Me)
        If _fm.SelectedNumber = "" Then
            Exit Sub
        End If

        Dim _samplenumber As Decimal = Decimal.Parse(_fm.SelectedNumber)
        'проверить наличие номера в списке
        For Each _item As System.Data.DataRowView In Me.SampleNumberListBox.Items
            If _item.Item("SampleNUmber") = _samplenumber Then
                MsgBox("Sample already contains in order!", MsgBoxStyle.Critical)
                Exit Sub
            End If
        Next


        ''add selected sample
        If clsOrderService.AddSampleInOrder(Me.oCurrentOrder.OrderID, _samplenumber) Then
            'sample added

        Else
            'error

        End If


        Me.Select_AllSamplesInOrders_tb_SamplesAndOrdersTableAdapter.Fill _
            (DsService.Select_AllSamplesInOrders_tb_SamplesAndOrders, Me.CurrentOrderID)


        For Each _indx As Data.DataRowView In Me.SampleNumberListBox.Items
            If CType(_indx.Row, dsService.Select_AllSamplesInOrders_tb_SamplesAndOrdersRow).SampleNumber _
                = _samplenumber Then

                Me.SampleNumberListBox.SelectedItem = _indx
                Exit For
            End If
        Next

        'work with controls
        For Each _ctl As Control In Me.TabPage_SamplesInOrder.Controls
            _ctl.Enabled = True
        Next
    End Sub

#Region "Save data to source"


    Private Sub btSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSaveOrder.Click

        Me.Select_tb_OrdersBindingSource.EndEdit()
        MsgBox("Update " & Me.Select_tb_OrdersTableAdapter.Update(Me.DsOrders.Select_tb_Orders) & " records in Order table")
    End Sub



    Private Sub btCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCancelOrder.Click

        Me.Select_tb_OrdersBindingSource.CancelEdit()

    End Sub

    Private Sub btSaveSample_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSaveSample.Click
        Me.SamplesAndOrdersBindingSource.EndEdit()
        MsgBox("Update " & Me.SamplesAndOrdersTableAdapter.Update(Me.DsOrders.SamplesAndOrders) & " records in Samples (for order) table")

    End Sub

    Private Sub BtCancelSample_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtCancelSample.Click
        Me.SamplesAndOrdersBindingSource.CancelEdit()
    End Sub
#End Region
    ' ''' <summary>
    ' ''' убрать образец из заказа
    ' ''' </summary>
    ' ''' <param name="sender"></param>
    ' ''' <param name="e"></param>
    ' ''' <remarks></remarks>
    'Private Sub btRemoveSample_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    'найти в таблице запись с нужным номером образца
    '    'Me.SamplesAndOrdersTableAdapter.Fill(Me.DsOrders.SamplesAndOrders, Me.CurrentSample, Me.CurrentOrderID)
    '    If Me.oCurrentSample Is Nothing Then Exit Sub
    '    Dim _row As dsOrders.SamplesAndOrdersRow = Me.DsOrders.SamplesAndOrders.FindBySampleNumberOrderID(Me.CurrentSample, Me.CurrentOrderID)
    '    If _row Is Nothing Then
    '        MsgBox("Записи об образце нет!", MsgBoxStyle.Critical)
    '        Exit Sub
    '    End If

    '    _row.Delete()

    '    Me.SamplesAndOrdersBindingSource.EndEdit()
    '    Dim _mss As String = "Remove: " & Me.SamplesAndOrdersTableAdapter.Update(Me.DsOrders.SamplesAndOrders) & " records."

    '    'удалить фото

    '    'Me.Cursor = Cursors.WaitCursor
    '    Dim _source = clsFilesSources.CreateInstance(Service.clsFilesSources.emSources.SpecificOrder, Me.oCurrentOrder)

    '    Dim _status As Integer = Service.clsApplicationTypes.SampleInfoObject.DeleteImagesFromSource(Me.oCurrentSample, _source, Nothing, True, True)

    '    _mss += "Result of remove photo is: " & _status.ToString

    '    'end of delete
    '    MsgBox(_mss)

    '    If Not Me.Select_AllSamplesInOrders_tb_SamplesAndOrdersTableAdapter.Fill _
    '        (DsService.Select_AllSamplesInOrders_tb_SamplesAndOrders, Me.CurrentOrderID) = 0 Then
    '        Me.SampleNumberListBox.SelectedIndex = 0
    '    Else
    '        'все образцы удалены
    '        'образцов для показа нет
    '        For Each _ctl As Control In Me.TabPage_SamplesInOrder.Controls
    '            _ctl.Enabled = False
    '        Next
    '        Me.btAddSampleToOrder.Enabled = True
    '    End If



    'End Sub



    Private Sub CheckoutDateTextBox_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles SampleCheckoutDateTextBox.Validating
        If SampleCheckoutDateTextBox.Text = "" Then
            MsgBox("В этом поле необхомимо значение даты")
        End If
    End Sub
    Private Function GetCatalog(Order As Service.clsApplicationTypes.clsOrder, CatalogType As emCatalogType) As CATALOG

        Dim _smpList As New List(Of Service.clsApplicationTypes.clsSampleNumber)
        'добавить данные образцов
        Dim _adap As New dsServiceTableAdapters.Select_AllSamplesInOrders_tb_SamplesAndOrdersTableAdapter
        Dim _SampleAndOrders_adapter As dsOrdersTableAdapters.SamplesAndOrdersTableAdapter = New dsOrdersTableAdapters.SamplesAndOrdersTableAdapter
        Dim _SampleAndOrder_Row As dsOrders.SamplesAndOrdersRow

        'перебрать все образцы в заказе
        For Each _rowSample As dsService.Select_AllSamplesInOrders_tb_SamplesAndOrdersRow In _adap.GetData(oCurrentOrder.OrderID)
            _SampleAndOrder_Row = _SampleAndOrders_adapter.GetData(_rowSample.SampleNumber, oCurrentOrder.OrderID).Item(0)
            '------------------------------------------------------------------------
            'проверка флагов запроса типа каталога
            Select Case CatalogType
                Case emCatalogType.AllSamplesInOrder
                    'все образцы
                Case emCatalogType.OrderedSamplesInOrder
                    If Not _SampleAndOrder_Row.ConfirmFlag Then
                        'пропустить образец
                        GoTo nextsample1
                    End If
                Case emCatalogType.CancelledSamplesInOrder
                    If (_SampleAndOrder_Row.ConfirmFlag) Then
                        'пропустить образец
                        GoTo nextsample1
                    Else
                        If Not _SampleAndOrder_Row.CheckoutFlag Then
                            'пропустить образец
                            GoTo nextsample1
                        End If
                    End If
            End Select

            _smpList.Add(Service.clsApplicationTypes.clsSampleNumber.CreateFromString(_SampleAndOrder_Row.SampleNumber))

nextsample1:

        Next

        'параметры каталога
        Dim _orderdata As dsOrders.Select_tb_OrdersRow = DsOrders.Select_tb_Orders.FindByOrderID(Order.OrderID)



        'сформировать заголовок
        Dim catalogTitle As String = ""
        Select Case CatalogType
            Case emCatalogType.AllSamplesInOrder
                catalogTitle = "Offer to " & DsService.Select_Clients_tb_Clients.FindByClientID(_orderdata.ClientID).FullName
            Case emCatalogType.OrderedSamplesInOrder
                catalogTitle = "Ordered samples: " & DsService.Select_Clients_tb_Clients.FindByClientID(_orderdata.ClientID).FullName
            Case emCatalogType.CancelledSamplesInOrder
                catalogTitle = "Cancelled samples: " & DsService.Select_Clients_tb_Clients.FindByClientID(_orderdata.ClientID).FullName
        End Select

        'create catalog 
        Dim _catalog As CATALOG = clsOrderService.GetCatalog(_smpList, _orderdata.OrderID, catalogTitle, clsFilesSources.CreateInstance(Service.clsFilesSources.emSources.SpecificOrder, Order), Nothing, False, Service.clsApplicationTypes.emCatalogFolderType.shot)
        _catalog.date = _orderdata.OrderDate
        Return _catalog

    End Function
    Private Const prOrderedPrefics As String = "Ordered_"
    Private Const prCancelledPrefics As String = "Cancelled_"
    Public oHtmlPath As String

    ''' <summary>
    ''' create xml file for current order
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btCreateXML_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCreateXML.Click
        '=====save files================================
        'путь к папке заказа
        Dim _orderPath As String = IO.Path.Combine(Global.Service.clsApplicationTypes.OrdersPath, Me.oCurrentOrder.OrderID)
        If Not IO.Directory.Exists(_orderPath) Then
            IO.Directory.CreateDirectory(_orderPath)
        End If
        Dim _sp = New SplashScreen1
        Dim _xmlPath As String = IO.Path.Combine(_orderPath, Me.oCurrentOrder.OrderID & ".xml")
        Dim _xmlOrderedPath As String = IO.Path.Combine(_orderPath, prOrderedPrefics & Me.oCurrentOrder.OrderID & ".xml")
        Dim _xmlCancelledPath As String = IO.Path.Combine(_orderPath, prCancelledPrefics & Me.oCurrentOrder.OrderID & ".xml")
        Dim _catalog As CATALOG

        _sp.StartPosition = FormStartPosition.CenterScreen
        _sp.Show(Me)
        Application.DoEvents()

        _catalog = Me.GetCatalog(Me.oCurrentOrder, emCatalogType.AllSamplesInOrder)

        '----------------
        If Me.cbxRefreshImages.Checked Then
            'проверить фотки
            Dim _result As Boolean = False
            Dim _sample As clsApplicationTypes.clsSampleNumber
            Dim _source As clsFilesSources = clsFilesSources.CreateInstance(clsFilesSources.emSources.SpecificOrder, Me.oCurrentOrder)
            Dim _archive = clsFilesSources.CreateInstance(clsFilesSources.emSources.Arhive)

            For Each t In _catalog.SAMPLE
                _sample = clsApplicationTypes.clsSampleNumber.CreateFromString(t.bar.ToString)
                If Not _sample Is Nothing Then
                    'обновить фотки
                    If Me.cbxDelExists.Checked Then
                        clsApplicationTypes.SamplePhotoObject.DeleteImagesFromSource(_sample, _source, {}, True, False)
                    End If

                    clsApplicationTypes.SamplePhotoObject.CopyImagesFromSourceToSource(_sample, _archive, _source, False)
                    _result = True

                End If
            Next
            If _result Then
                'заново записать каталог
                _catalog = Me.GetCatalog(Me.oCurrentOrder, emCatalogType.AllSamplesInOrder)
            End If
        End If
        '-----------------

        'сохранить xml файл каталога
        Dim oHtmlPath = IO.Path.ChangeExtension(_xmlPath, "xml")

        Using _fileWr As New IO.StreamWriter(_xmlPath, False, System.Text.Encoding.GetEncoding("windows-1251"))
            _fileWr.Write(_catalog.GetXML)
            _fileWr.Flush()
            '_fileWr.Close()
        End Using
        'сохранить html файл каталога
        oHtmlPath = IO.Path.ChangeExtension(_xmlPath, "html")
        Using _fileWr As New IO.StreamWriter(oHtmlPath, False, System.Text.Encoding.GetEncoding("windows-1251"))
            _fileWr.Write(_catalog.GetHTML)
            _fileWr.Flush()
            ' _fileWr.Close()
        End Using

        'сохранить txt файл каталога
        oHtmlPath = IO.Path.ChangeExtension(_xmlPath, "txt")
        Using _fileWr As New IO.StreamWriter(oHtmlPath, False, System.Text.Encoding.GetEncoding("windows-1251"))
            _fileWr.Write(_catalog.GetTEXT)
            _fileWr.Flush()
            ' _fileWr.Close()
        End Using


        'показать содержимое
        TabPage_XMLOrder_Enter(btCreateXML, e)
        If Not _sp Is Nothing Then
            _sp.Close()
        End If
    End Sub



    Private Sub btPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCopyText.Click
        Me.OrderText_RichTextBox.SelectAll()
        Me.OrderText_RichTextBox.Copy()
        Me.OrderText_RichTextBox.SelectionStart = 0
        MsgBox("Text copied", MsgBoxStyle.Information)
    End Sub


    Private Sub btShowImages_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btShowImages.Click
        'work with images
        If Me.oCurrentSample Is Nothing Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        Me.ListViewSampleImages.Clear()

        Dim _ImageList As Global.Service.SampleSourceImageList

        Dim _source = clsFilesSources.CreateInstance(Service.clsFilesSources.emSources.SpecificOrder, Me.oCurrentOrder)


        _ImageList = Service.clsApplicationTypes.SamplePhotoObject.GetSampleImageList(Me.oCurrentSample, _source, New Size(160, 120), False)

        If Not (_ImageList Is Nothing OrElse _ImageList.CountImages = 0) Then
            Me.ListViewSampleImages.Items.AddRange(_ImageList.ListViewItems)
            Me.ListViewSampleImages.SmallImageList = _ImageList.ImageList
            Me.ListViewSampleImages.LargeImageList = _ImageList.ImageList
        Else

        End If
        Me.Cursor = Cursors.Default

    End Sub


    ''' <summary>
    ''' показ большой картинки
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ListViewSampleImages_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListViewSampleImages.DoubleClick
        Dim _index As Integer = Me.ListViewSampleImages.SelectedItems(0).ImageIndex
        Dim _path As String = Me.ListViewSampleImages.LargeImageList.Images.Keys(_index)
        Dim _source = clsFilesSources.CreateInstance(Service.clsFilesSources.emSources.SpecificOrder, Me.oCurrentOrder)


        Dim _image As Image = Service.clsApplicationTypes.SamplePhotoObject.GetImage(_source, Me.oCurrentSample, Me.ListViewSampleImages.SelectedItems(0).Name, True)

        Dim _fmImage As Form
        'show image form
        'использование сервисов
        'по запросу выполняем вызов из сервиса
        Dim _param As Object = {_image, _path}
        'если делегата нет, то сервис недоступен
        If Not Global.Service.clsApplicationTypes.DelegateStoreApplicationForm(Service.clsApplicationTypes.emFormsList.fmImage) Is Nothing Then
            'сервис зарегестрирован - вызываем
            _fmImage = Global.Service.clsApplicationTypes.DelegateStoreApplicationForm(Service.clsApplicationTypes.emFormsList.fmImage).Invoke(_param)
            If Not _fmImage Is Nothing Then
                'show form
                _fmImage.ShowDialog()

            End If
        Else

        End If

        ' _image.Dispose()

    End Sub
    Private Sub FreeShippingFlagCheckBox_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OrderFreeShippingFlagCheckBox.CheckedChanged
        If Me.OrderFreeShippingFlagCheckBox.Checked Then
            With Me.oCurrentOrderRow
                .ShippingPrice = 0
                .ConfirmShippingPrice = 0
            End With
        End If
    End Sub
    Private Sub btCalculateOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCalculateOrder.Click
        Me.CalculateOrderField()
    End Sub


    ''' <summary>
    ''' замена . на ,
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub NumericTextBox_Validating(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles OrderTotalPriceTextBox.Validating, OrderShippingPriceTextBox.Validating, _
        OrderConfirmTotalOrderPriceTextBox.Validating, OrderConfirmShippingPriceTextBox.Validating, _
        OrderRateOfExchangeTextBox.Validating, SampleConfirmPriceTextBox.Validating, _
        SampleConfirmShippingPriceTextBox.Validating, SampleDiscountTextBox.Validating, _
        SamplePriceTextBox.Validating, SampleRateOfExchangeTextBox.Validating

        sender.text = Service.clsApplicationTypes.ReplaceDecimalSplitter(sender.text)
        'запись курса валют
        If sender Is Me.OrderRateOfExchangeTextBox Then
            If Service.clsApplicationTypes.CurrencyRateNow _
     (Me.OrderCurrencyNameComboBoxOrder.SelectedItem) = 0 Then
                Service.clsApplicationTypes.CurrencyRateNow _
       (Me.OrderCurrencyNameComboBoxOrder.SelectedItem) = Decimal.Parse(Me.OrderRateOfExchangeTextBox.Text)
            End If

        End If

        If sender Is Me.SampleRateOfExchangeTextBox Then
            If Service.clsApplicationTypes.CurrencyRateNow _
     (Me.SampleCurrencyNameComboBox.SelectedItem) = 0 Then
                Service.clsApplicationTypes.CurrencyRateNow _
       (Me.SampleCurrencyNameComboBox.SelectedItem) = Decimal.Parse(Me.SampleRateOfExchangeTextBox.Text)
            End If

        End If
    End Sub


    ''' <summary>
    ''' показывает содержимое файлов
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TabPage_XMLOrder_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage_XMLOrder.Enter
        Select Case cbTypeOfCatalog.SelectedIndex
            Case 0
                'все образцы
                ShowCatalogFiles()
            Case 1
                'заказанные
                ShowCatalogFiles(prOrderedPrefics)
            Case 2
                'отмененные
                ShowCatalogFiles(prCancelledPrefics)
        End Select
    End Sub
    ''' <summary>
    ''' показывает содержимое файлов во вкладках. Source имеет значения префиксов для файлов каталога: ничего, Ordered_, Cancelled_
    ''' </summary>
    ''' <param name="Source">префиксов для файлов каталога: ничего, Ordered_, Cancelled_</param>
    ''' <remarks></remarks>
    Private Sub ShowCatalogFiles(Optional Source As String = "")
        If Me.oCurrentOrder Is Nothing Then Exit Sub
        If Me.oCurrentOrder.OrderID = "" Then Exit Sub
        Dim _orderPath As String = IO.Path.Combine(Global.Service.clsApplicationTypes.OrdersPath, Me.oCurrentOrder.OrderID)
        _orderPath = IO.Path.Combine(_orderPath, Source & Me.oCurrentOrder.OrderID)

        If IO.File.Exists(_orderPath & ".html") Then
            oHtmlPath = _orderPath & ".html"
            Me.OrderHTML_WebBrowser.Navigate(_orderPath & ".html")
        Else
            ' Me.OrderHTML_WebBrowser.Text = "нет файла html"
        End If

        If IO.File.Exists(_orderPath & ".txt") Then
            Me.OrderText_RichTextBox.Text = IO.File.ReadAllText(_orderPath & ".txt")
            ' Me.OrderText_RichTextBox.LoadFile(_orderPath & ".txt", RichTextBoxStreamType.PlainText)
            Me.OrderText_RichTextBox.Refresh()
        Else
            Me.OrderText_RichTextBox.Text = "нет файла txt"
        End If

        If IO.File.Exists(_orderPath & ".xml") Then
            Me.OrderInfoPaperRichTextBox.Text = IO.File.ReadAllText(_orderPath & ".xml")
            'Me.OrderInfoPaperRichTextBox.LoadFile(_orderPath & ".xml", RichTextBoxStreamType.PlainText)
            'Me.OrderInfoPaperRichTextBox.Refresh()
        Else
            Me.OrderInfoPaperRichTextBox.Text = "нет файла xml"
        End If
    End Sub


    Private Sub btRefreshOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btRefreshOrder.Click
        LoadOrderData()
    End Sub

    Private Sub btCopyToAnotherOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btMoveToAnotherOrder.Click
        'получить список заказов
        Dim _orders As Collections.Generic.List(Of Service.clsApplicationTypes.clsOrder)
        Dim oBindingOrder As Windows.Forms.BindingSource
        'по запросу выполняем вызов из сервиса
        'если делегата нет, то сервис недоступен
        If Not Global.Service.clsApplicationTypes.DelegateStoreOrdersList Is Nothing Then
            'сервис зарегестрирован - вызываем
            oBindingOrder = New Windows.Forms.BindingSource
            _orders = Service.clsApplicationTypes.DelegateStoreOrdersList.Invoke()

            oBindingOrder.DataSource = _orders
            'отобразить его в форме
            Dim _fmSelectOrder As New Windows.Forms.Form
            'create listbox with order list
            Dim _lbSelectOrder As New Windows.Forms.ListBox
            'link to datasourse
            _lbSelectOrder.DataSource = oBindingOrder
            _lbSelectOrder.DisplayMember = "OrderID"
            _lbSelectOrder.ValueMember = "OrderID"
            _lbSelectOrder.Size = New Drawing.Size(80, 200)
            _fmSelectOrder.ClientSize = _lbSelectOrder.Size
            _fmSelectOrder.Controls.Add(_lbSelectOrder)

            _fmSelectOrder.AutoSize = True
            _fmSelectOrder.AutoSizeMode = Windows.Forms.AutoSizeMode.GrowOnly
            _fmSelectOrder.ControlBox = False
            _fmSelectOrder.Text = "select order"
            _fmSelectOrder.StartPosition = FormStartPosition.CenterScreen
            _fmSelectOrder.Location = Control.MousePosition
            _fmSelectOrder.Location.Offset(50, 0)

            AddHandler _lbSelectOrder.KeyPress, AddressOf Me._fmSelectOrderKeyPress
            AddHandler _lbSelectOrder.MouseDoubleClick, AddressOf Me._fmSelectOrderListBoxDoubleClick

            _fmSelectOrder.ShowDialog()

        End If



    End Sub

    Private Sub _fmSelectOrderKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Char.IsControl(e.KeyChar) Then
            Select Case Asc(e.KeyChar)
                Case 27
                    'esc
                    sender.parent.close()
                Case 13
                    'enter
                    Dim _e As New Windows.Forms.MouseEventArgs(Windows.Forms.MouseButtons.Right, 2, 0, 0, 0)

            End Select

            If Asc(e.KeyChar) = 27 Then
                sender.parent.close()
            End If
        End If
    End Sub
    Private Sub _fmSelectOrderListBoxDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Dim _destOrderID As String = sender.selectedValue
        If e.Clicks = 2 Then
            sender.parent.close()
            Select Case MsgBox("sample " & Me.oCurrentSample.EAN13 & " will be copied from " & Me.oCurrentOrder.OrderID & " to " & _destOrderID, MsgBoxStyle.YesNo)
                Case MsgBoxResult.Yes
                    'moved code
                    'add sample to destination order
                    ''add selected sample
                    If Me.oCurrentSample Is Nothing Then
                        MsgBox("Sample not selected!", MsgBoxStyle.Critical)
                        Exit Sub
                    End If

                    If clsOrderService.AddSampleInOrder(_destOrderID, Me.oCurrentSample.GetEan13) Then
                        'sample added
                        ''remove sample from order
                        'Me.btRemoveSample_Click(sender, e)
                        Dim _source = clsFilesSources.CreateInstance(Service.clsFilesSources.emSources.SpecificOrder, Me.oCurrentOrder)
                        Dim _destination = clsFilesSources.CreateInstance(Service.clsFilesSources.emSources.SpecificOrder, New Service.clsApplicationTypes.clsOrder(_destOrderID))
                        'переписать изображения
                        If Service.clsApplicationTypes.SamplePhotoObject.CopyImagesFromSourceToSource(Me.oCurrentSample, _source, _destination, False) > 0 Then
                            MsgBox("Sample added success", MsgBoxStyle.Information)
                        End If

                    Else
                        'error
                        MsgBox("Copy uncomplete! Sample added error.", MsgBoxStyle.Critical)
                    End If

                Case MsgBoxResult.No

            End Select

        End If

    End Sub


    Private Sub Select_OrdersForClientBindingSource_CurrentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Select_OrdersForClientBindingSource.CurrentChanged

    End Sub

    Private Sub SampleDiscountTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SampleDiscountTextBox.TextChanged
        Dim _discount As Decimal
        Dim _price As Decimal
        Try
            _discount = CType(sender.Text, Decimal)
            _price = CType(Me.SamplePriceTextBox.Text, Decimal)
        Catch ex As InvalidCastException

            _discount = 0
            _price = 0
        End Try

        Me.SampleConfirmPriceTextBox.Text = (_price - (_price * _discount * 0.01)).ToString
    End Sub

    Private Sub Dgv_SamplesINOrders_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles Dgv_SamplesINOrders.CellClick
        If e.RowIndex < 0 Or e.ColumnIndex < 0 Then Exit Sub
        Dim t1 = Dgv_SamplesINOrders.Rows(e.RowIndex).Cells(e.ColumnIndex)
        If Not t1 Is Nothing AndAlso t1.ValueType Is GetType(Decimal) Then

            'My.Computer.Clipboard.SetText(t1.Value.ToString & ChrW(13))
        End If
        ''Dim t = Dgv_SamplesINOrders.SelectedCells(0)
        'MsgBox(t1.ValueType.ToString)

    End Sub

    'форматирование ячеек
    Private Sub Dgv_SamplesINOrders_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles Dgv_SamplesINOrders.CellFormatting
        If e.Value Is Nothing Or e.Value Is DBNull.Value Then Exit Sub

        'изменить цвет подтвержденных образцов
        If (e.ColumnIndex = 4) AndAlso (Boolean.Parse(e.Value) = True) Then
            If Not Me.Dgv_SamplesINOrders.Rows(e.RowIndex).IsNewRow Then
                Me.Dgv_SamplesINOrders.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.LawnGreen
            End If
        End If
    End Sub
    'сохранить изменения

    Private Sub btSaveChanges_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSaveChanges.Click
        Me.SamplesINOrdersBindingSource.EndEdit()
        Me.Cursor = Cursors.WaitCursor
        ' проверить изменения
        Dim _dt As dsSampleInOrder.SamplesINOrdersDataTable = Me.DsSampleInOrder.SamplesINOrders.GetChanges()
        'изменений нет
        If _dt Is Nothing Then Exit Sub


        Dim _statAdd, _statDel, _statMody As Integer

        For Each _r As Data.DataRow In _dt.Rows
            Select Case _r.RowState
                Case Data.DataRowState.Added
                    'добавить картинки в заказ
                    Dim _tmpS = Service.clsApplicationTypes.clsSampleNumber.CreateFromString(_r.Item(0).ToString)
                    clsOrderService.AddSampleImagesInOrder(Me.oCurrentOrder, _tmpS)
                    _statAdd += 1
                Case Data.DataRowState.Modified
                    _statMody += 1
                Case Data.DataRowState.Detached
            End Select
        Next
        'delete images
        For Each _sn In Me.oDeletedSamples
            Dim _tmpS = Service.clsApplicationTypes.clsSampleNumber.CreateFromString(_sn)
            'Me.pbSampleImage.Image.Dispose()
            Me.pbSampleImage.Image = Nothing
            clsOrderService.DeleteSampleImagesFromOrder(Me.oCurrentOrder, _tmpS)
            _statDel += 1
        Next
        Me.oDeletedSamples.Clear()
        Me.Cursor = Cursors.Default

        Dim _result As Integer
        Try
            _result = Me.SamplesINOrdersTableAdapter.Update(_dt)
            MsgBox("В БД принято " & _result & " изменений. " & _statAdd & " образцов добавлено, " & _statDel & " удалено и " & _statMody & " изменено в заказе.", vbOKOnly)
            Me.DsSampleInOrder.AcceptChanges()
        Catch ex As Exception
            _result = -1
            MsgBox("Ошибка при обновлении в БД: " & ex.Message)
        End Try





    End Sub
    'отмена изменений
    Private Sub btCancelChanges_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCancelChanges.Click
        Me.DsSampleInOrder.RejectChanges()
        Me.oDeletedSamples.Clear()
        MsgBox("Изменения отменены!", vbOKOnly)

    End Sub

    'переход со строки на строку
    Private Sub Dgv_SamplesINOrders_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv_SamplesINOrders.RowEnter
        'очистить эу
        Me.pbSampleImage.Image = Nothing
        Me.tbMainFossilName.Text = ""
        Me.tbMainFossilSize.Text = ""
        'смотрим текущий образец
        If Me.Dgv_SamplesINOrders.Rows(e.RowIndex).Cells(0).Value Is System.DBNull.Value Then Exit Sub
        Dim _tmpSample As Decimal = Me.Dgv_SamplesINOrders.Rows(e.RowIndex).Cells(0).Value
        oCurrentSample = Service.clsApplicationTypes.clsSampleNumber.CreateFromString(_tmpSample.ToString)
        If oCurrentSample Is Nothing Then Exit Sub



        Dim _filesource = clsFilesSources.CreateInstance(Service.clsFilesSources.emSources.SpecificOrder, Me.oCurrentOrder)
        If Not Service.clsApplicationTypes.SamplePhotoObject.HasImages(oCurrentSample, _filesource) Then
            _filesource = clsFilesSources.CreateInstance(Service.clsFilesSources.emSources.Arhive)
        End If



        'отобразить изображение
        Dim _img As Image = Service.clsApplicationTypes.SamplePhotoObject.GetMainImage(_filesource, oCurrentSample, True)
        If Not _img Is Nothing Then
            Dim _gr = Graphics.FromImage(_img)
            'проверить фото в заказе
            If _filesource.Source = clsFilesSources.emSources.SpecificOrder Then
                _gr.DrawString("Из заказа", New System.Drawing.Font("Tahoma", 20, FontStyle.Regular), Brushes.White, 10, 10)
                btImagesForm.Enabled = True
            Else
                _gr.DrawString("Из архива", New System.Drawing.Font("Tahoma", 20, FontStyle.Regular), Brushes.White, 10, 10)
                btImagesForm.Enabled = False
            End If

            Me.pbSampleImage.Image = _img
        Else
            Me.pbSampleImage.Image = Nothing
            Dim _gr = Me.pbSampleImage.CreateGraphics
            _gr.DrawString("Нет фото", New System.Drawing.Font("Tahoma", 8, FontStyle.Regular), Brushes.White, 10, 10)
        End If
        'загрузить данные образца

        Me.DataTable_SampleInfoTableAdapter.Fill(DsSampleInOrder.DataTable_SampleInfo, Me.oCurrentSample.GetEan13)
        If DsSampleInOrder.DataTable_SampleInfo.Count > 0 Then
            'данные есть
            Me.tbMainFossilName.Text = DsSampleInOrder.DataTable_SampleInfo(0).name
            Me.tbMainFossilSize.Text = DsSampleInOrder.DataTable_SampleInfo(0).len & "см"
            Me.btSampleInfo.Enabled = True
            'заполнить поля
            'fill data field
            Dim _c = clsApplicationTypes.SampleDataObject.GetSampleOnSale(Me.oCurrentSample)
            Dim _tmp = Me.Dgv_SamplesINOrders.Rows(e.RowIndex).Cells(1)
            ''name
            'If _tmp.Value.ToString.Trim = "" Then
            '    _tmp.Value = DsSampleInOrder.DataTable_SampleInfo(0).name
            'End If
            _tmp = Me.Dgv_SamplesINOrders.Rows(e.RowIndex).Cells(1)
            'currName
            'If _tmp.Value.ToString.Trim = "" Then
            '    _tmp.Value = _c.CurrencyName
            '    If _tmp.Value Is Nothing OrElse _tmp.Value = "" Then
            '        _tmp.Value = "USD"
            '    End If
            'End If
            _tmp = Me.Dgv_SamplesINOrders.Rows(e.RowIndex).Cells(2)
            'price
            If _tmp.Value = 0 Then
                _tmp.Value = _c.BasePrice
                If _tmp.Value Is Nothing OrElse _tmp.Value = 0 Then
                    _tmp.Value = 0
                End If
            End If


        Else
            'данных нет
            Me.btSampleInfo.Enabled = False
            Me.tbMainFossilName.Text = "Данных образца нет. Счелкните для добавления."
        End If
    End Sub
    'показать форму  увеличенное изображение
    Private Sub btImagesForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btImagesForm.Click
        'call service function
        Dim _tmpSample As Decimal = Me.Dgv_SamplesINOrders.CurrentRow.Cells(0).Value
        Dim _filesrc = clsFilesSources.CreateInstance(Service.clsFilesSources.emSources.SpecificOrder, Me.oCurrentOrder)
        Dim _sampleNumber = Service.clsApplicationTypes.clsSampleNumber.CreateFromString(_tmpSample.ToString)
        Dim _prm As Object = Service.clsApplicationTypes.SamplePhotoObject.GetSampleImageList(_sampleNumber, _filesrc, New Size(160, 120), False)
        Dim _param As Object = {_prm}

        'если делегата нет, то сервис недоступен
        If Not Global.Service.clsApplicationTypes.DelegateStoreApplicationForm(Service.clsApplicationTypes.emFormsList.fmImage) Is Nothing Then
            'сервис зарегестрирован - вызываем
            Dim _fmImage As Form
            _fmImage = Global.Service.clsApplicationTypes.DelegateStoreApplicationForm(Service.clsApplicationTypes.emFormsList.fmImage).Invoke(_param)
            If Not _fmImage Is Nothing Then
                'show form
                _fmImage.Width = 640
                _fmImage.Height = 480

                _fmImage.Name = "ImageShowForm"
                _fmImage.StartPosition = FormStartPosition.CenterScreen

                'привязка обработчика
                Service.clsApplicationTypes.DelegatStorefmImageDeleteDelegate = New Service.clsApplicationTypes.fmImageDeleteDelegat(AddressOf DelImage_eventHandler)
                Service.clsApplicationTypes.DelegatStorefmImageCopyDelegate = New Service.clsApplicationTypes.fmImageCopyDelegat(AddressOf CopyImage_eventHandler)

                _fmImage.Show()

            End If
        Else

        End If
    End Sub

    Private Sub CopyImage_eventHandler(ByVal sender As Object, ByVal e As Service.clsApplicationTypes.fmImageCopyEventArg)
        If e.ImageNames.Length = 0 Then Exit Sub

        'скопировать изображения, список имен в аргументе
        Dim _tmpSample As Decimal = Me.Dgv_SamplesINOrders.CurrentRow.Cells(0).Value
        Dim _filesrc = clsFilesSources.CreateInstance(Service.clsFilesSources.emSources.SpecificOrder, Me.oCurrentOrder)
        Dim _sampleNumber = Service.clsApplicationTypes.clsSampleNumber.CreateFromString(_tmpSample.ToString)

        'задать устройство принимающее
        Dim _Tosource As clsFilesSources = clsFilesSources.CreateInstance(Service.clsFilesSources.emSources.SpecificOrder, Me.oCurrentOrder, False, "")

        'задать устройство источник
        Dim _Fromsource As clsFilesSources = clsFilesSources.CreateInstance(Service.clsFilesSources.emSources.FreeFolder, , False, e.ImagesPath)


        'вычислить оптимизацию
        Dim _optimize As Integer = 1024
        Dim _message As String = "Копировать " & e.ImageNames.Length & " файлов "
        _message += "с оптимизацией по длинной стороне " & _optimize.ToString & "?"
        'задать вопрос
        Select Case MsgBox(_message, MsgBoxStyle.YesNo)
            Case MsgBoxResult.Yes
                'копировать
                Dim _count As Integer = Service.clsApplicationTypes.SamplePhotoObject.CopyImagesFromSourceToSource(_sampleNumber, _Fromsource, _Tosource, False, e.ImageNames, _optimize)
                MsgBox(_count & " фото скопированы для образца" & _sampleNumber.GetEan13 & " в заказ " & Me.oCurrentOrder.OrderID, vbInformation)
            Case MsgBoxResult.No
                Exit Sub
        End Select



    End Sub


    Private Sub DelImage_eventHandler(ByVal sender As Object, ByVal e As Service.clsApplicationTypes.fmImageDelEventArg)
        If e.ImageNames.Count = 0 Then Exit Sub

        'удалить изображения, список имен в аргументе
        Dim _tmpSample As Decimal = Me.Dgv_SamplesINOrders.CurrentRow.Cells(0).Value
        Dim _filesrc = clsFilesSources.CreateInstance(Service.clsFilesSources.emSources.SpecificOrder, Me.oCurrentOrder)
        Dim _sampleNumber = Service.clsApplicationTypes.clsSampleNumber.CreateFromString(_tmpSample.ToString)
        Dim _coll(e.ImageNames.Count - 1) As String
        e.ImageNames.CopyTo(_coll, 0)
        Dim _count As Integer = Service.clsApplicationTypes.SamplePhotoObject.DeleteImagesFromSource(_sampleNumber, _filesrc, _coll, False, False)
        MsgBox("Удалено " & _count & " фото из заказа " & _filesrc.Order.OrderID, vbInformation)
        Service.clsApplicationTypes.DelegatStorefmImageDeleteDelegate = Nothing
    End Sub


    Private Sub btSampleInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSampleInfo.Click

        Dim _param As Object = {Me.Dgv_SamplesINOrders.CurrentRow.Cells(0).Value.ToString}
        Dim _fmSampleData As Form

        'по запросу выполняем вызов из сервиса
        'если делегата нет, то сервис недоступен
        If Not Global.Service.clsApplicationTypes.DelegateStoreApplicationForm _
            (Service.clsApplicationTypes.emFormsList.fmSampleData) Is Nothing Then
            'сервис зарегестрирован - вызываем
            _fmSampleData = Global.Service.clsApplicationTypes.DelegateStoreApplicationForm _
                (Service.clsApplicationTypes.emFormsList.fmSampleData).Invoke(_param)
        Else
            Exit Sub
        End If

        ''открыть окно
        If Not _fmSampleData Is Nothing Then
            'данные есть
            If _fmSampleData.IsDisposed = False Then
                _fmSampleData.ShowDialog()

            End If
        Else
            'данных нет
            'TODO запустить форму данных?

        End If

    End Sub


    'добавление новой строки
    Private Sub Dgv_SamplesINOrders_DefaultValuesNeeded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles Dgv_SamplesINOrders.DefaultValuesNeeded

        'Me.Dgv_SamplesINOrders.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2
        'записать в новую строку
        e.Row.Cells("OrderID").Value = Trim(Me.tbOrderID.Text)
        e.Row.Cells(0).Value = System.DBNull.Value
        e.Row.Cells(1).Value = "usd"
        e.Row.Cells(2).Value = 0
        e.Row.Cells(3).Value = 0
        e.Row.Cells(4).Value = False
        e.Row.Cells(5).Value = 0
        e.Row.Cells(6).Value = 0
        e.Row.Cells(7).Value = False
        e.Row.Cells(8).Value = 0
        e.Row.Cells(9).Value = False
    End Sub
    Private oDeletedSamples As New Collections.Specialized.StringCollection
    Private Sub btDeleteSample_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btDeleteSample.Click
        Dim _tmpNum As String = Me.Dgv_SamplesINOrders.CurrentRow.Cells(0).Value.ToString

        Select Case MsgBox("удалить образец " & _tmpNum & " из заказа?", vbYesNo, "подтверждение")
            Case vbYes
                oDeletedSamples.Add(Me.Dgv_SamplesINOrders.CurrentRow.Cells(0).Value.ToString)

                Me.Dgv_SamplesINOrders.Rows.Remove(Me.Dgv_SamplesINOrders.CurrentRow)
            Case vbNo

        End Select


    End Sub

    ''' <summary>
    ''' выбор типа каталога для показа
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cbTypeOfCatalog_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbTypeOfCatalog.SelectedIndexChanged
        TabPage_XMLOrder_Enter(sender, e)
    End Sub


    ' ''' <summary>
    ' ''' выбран другой образец
    ' ''' </summary>
    ' ''' <param name="sender"></param>
    ' ''' <param name="e"></param>
    ' ''' <remarks></remarks>
    'Private Sub SamplesAndOrdersBindingSource_CurrentChanged(sender As Object, e As System.EventArgs) Handles SamplesINOrdersBindingSource.CurrentChanged
    '    'If SamplesINOrdersBindingSource.Current.isnew = True Then Exit Sub

    '    Dim _curr = TryCast(SamplesINOrdersBindingSource.Current.row, dsSampleInOrder.SamplesINOrdersRow)
    '    If _curr Is Nothing Then Exit Sub
    '    If _curr.Item("SampleNumber") Is System.DBNull.Value Then
    '        Exit Sub
    '    End If

    '    Dim _str As String = _curr.SampleNumber.ToString

    '    Dim _number = Service.clsApplicationTypes.clsSampleNumber.CreateFromString(_str)

    '    If _number Is Nothing Then
    '        Debug.Fail("Номер образца " & _str & " не распознан классом номеров образцов")
    '        Exit Sub
    '    End If

    '    Me.oCurrentSample = _number


    'End Sub

    Private Sub Dgv_SamplesINOrders_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles Dgv_SamplesINOrders.CellValidating

        Select Case e.ColumnIndex
            'колонка номера 
            Case 0
                Dim _number = Service.clsApplicationTypes.clsSampleNumber.CreateFromString(e.FormattedValue)
                If _number Is Nothing Then
                    Select Case e.FormattedValue
                        Case Nothing
                            MsgBox("Введите номер образца!", vbCritical)
                        Case Else
                            MsgBox("Номер " & e.FormattedValue & " не зарегистрирован в системе или не верен. Введите корректный номер образца!", vbCritical)
                    End Select

                    e.Cancel = True
                Else
                    'проверка номера на наличие в списке
                    If Dgv_SamplesINOrders.Rows(e.RowIndex).IsNewRow Then


                        Dim _exist As Boolean = False

                        For Each _row As DataGridViewRow In Dgv_SamplesINOrders.Rows
                            If CType(_row.Cells(0).Value, Decimal) = _number.GetEan13 Then
                                _exist = True
                            End If
                        Next

                        If _exist Then
                            MsgBox("Номер " & e.FormattedValue & " уже есть в заказе!", vbCritical)
                            e.Cancel = True
                        End If
                    End If
                End If

        End Select

    End Sub

    Private Sub CallSampleOnSaleForm()


    End Sub




    Private Sub Dgv_SamplesINOrders_CellParsing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellParsingEventArgs) Handles Dgv_SamplesINOrders.CellParsing
        Select Case e.ColumnIndex
            Case 0
                'первый столбец=номер
                Dim _number As String = e.Value
                Dim _num = Service.clsApplicationTypes.clsSampleNumber.CreateFromString(_number)

                If Not _num Is Nothing Then
                    'номер правильный
                    e.Value = _num.GetEan13
                    e.ParsingApplied = True


                Else
                    'номер не правильный. остаться в строке.
                    Debug.Fail("неправильная работа перехвата события cellvalidating")
                    'MsgBox("Номер " & _number & " не зарегистрирован в системе или не верен. Введите корректный номер образца!", vbCritical)
                    '  e.ParsingApplied = False
                    ' e.Value = 0
                    e.ParsingApplied = False
                    'e.Value = 0
                    'Dgv_SamplesINOrders.Item(e.ColumnIndex,e.RowIndex).
                    'Dgv_SamplesINOrders.CurrentCell = Dgv_SamplesINOrders.Item(e.ColumnIndex, e.RowIndex)

                End If


        End Select

    End Sub

    Private Sub Dgv_SamplesINOrders_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv_SamplesINOrders.CellContentClick

    End Sub
    ''' <summary>
    ''' показать в браузере
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btShowInBrowser_Click(sender As System.Object, e As System.EventArgs) Handles btShowInBrowser.Click
        Dim c = New SHDocVw.InternetExplorer
        c.Visible = True
        c.Navigate(Me.oHtmlPath)
    End Sub

    Private Sub PreviewXML_TabPage_Click(sender As System.Object, e As System.EventArgs) Handles PreviewXML_TabPage.Click
        Me.OrderInfoPaperRichTextBox.Refresh()
    End Sub

    Private Sub btSampleOnSale_Click(sender As System.Object, e As System.EventArgs) Handles btSampleOnSale.Click
        'по запросу выполняем вызов из сервиса
        'если делегата нет, то сервис недоступен
        Dim _fmSampleOnSale As Form
        Dim _number As Object = {Me.Dgv_SamplesINOrders.CurrentRow.Cells(0).Value.ToString}

        If Not Global.Service.clsApplicationTypes.DelegateStoreApplicationForm _
(Service.clsApplicationTypes.emFormsList.fmSampleOnSale) Is Nothing Then
            'сервис зарегестрирован - вызываем
            _fmSampleOnSale = Global.Service.clsApplicationTypes.DelegateStoreApplicationForm(Service.clsApplicationTypes.emFormsList.fmSampleOnSale).Invoke(_number)
        Else
            Exit Sub
        End If
        If Not _fmSampleOnSale Is Nothing Then
            _fmSampleOnSale.ShowDialog()

        End If

        'Me.btSearchInfo.Focus()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim _filesource = clsFilesSources.CreateInstance(Service.clsFilesSources.emSources.SpecificOrder, Me.oCurrentOrder)
        'Dim _path = _filesource.ContainerPath
        'Dim _param As Object = {Me.Dgv_SamplesINOrders.CurrentRow.Cells(0).Value.ToString}
        Dim _num = clsApplicationTypes.clsSampleNumber.CreateFromString(Me.Dgv_SamplesINOrders.CurrentRow.Cells(0).Value.ToString)
        If _num Is Nothing Then
            MsgBox("Не удалось получить номер из строки " & Me.Dgv_SamplesINOrders.CurrentRow.Cells(0).Value.ToString, vbCritical)
            Return
        End If
        Dim _param As Object = {_filesource, _num}

        Dim _fm As Form
        'по запросу выполняем вызов из сервиса
        'если делегата нет, то сервис недоступен
        If Not Global.Service.clsApplicationTypes.DelegateStoreApplicationForm _
            (Service.clsApplicationTypes.emFormsList.fmImageManager) Is Nothing Then
            'сервис зарегестрирован - вызываем
            _fm = Global.Service.clsApplicationTypes.DelegateStoreApplicationForm _
                (Service.clsApplicationTypes.emFormsList.fmImageManager).Invoke(_param)
            If Not _fm Is Nothing Then
                _fm.ShowDialog()
            End If

        End If
    End Sub

    Private Sub pbSampleImage_Click(sender As System.Object, e As System.EventArgs) Handles pbSampleImage.Click
        btImagesForm_Click(sender, e)
    End Sub


    Private Sub main_TabControl_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles main_TabControl.SelectedIndexChanged
        If main_TabControl.SelectedIndex = 1 AndAlso oFlagDataLoaded = False Then
            LoadOrderData()
        End If
    End Sub
End Class