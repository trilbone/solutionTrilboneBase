Imports Service
Imports System.Linq
Imports System.Xml.Linq
Imports Trilbone
Imports Service.clsApplicationTypes
Imports Service.Catalog

Public Class fmSampleInfo
    Implements iListSampleDataProvider
    Public Event SampleNumberAccepted(sender As Object, e As clsWriteSampleToListEventsArg) Implements iListSampleDataProvider.WriteSampleToList
    Private oSampleNumber As Service.clsApplicationTypes.clsSampleNumber
    Private Structure SampleStatus
        Private oSampleStatus As SampleInfo
        Private oOfferStatus As OfferInfo

        Enum SampleInfo
            sold = 0
            unsold = 1
            reserved = 2
            unknown = 3
        End Enum
        Enum OfferInfo
            accepted_CheckOut = 0
            accepted_StockOut = 1
            declined = 2
            activeNow = 3
            unknown = 4
        End Enum
        Sub New(ByVal SampleInfo As SampleInfo, ByVal OfferInfo As OfferInfo)
            oSampleStatus = SampleInfo
            oOfferStatus = OfferInfo
        End Sub

        Property Sample As SampleInfo
            Get
                Return oSampleStatus
            End Get
            Set(ByVal value As SampleInfo)
                oSampleStatus = value
                Select Case value
                    Case SampleInfo.unsold
                        Select Case oOfferStatus
                            Case OfferInfo.activeNow
                                'correct
                                oSampleStatus = SampleInfo.reserved
                            Case OfferInfo.declined
                                'ok
                            Case OfferInfo.accepted_StockOut
                                'ok
                                'oOfferStatus = OfferInfo.unknown
                                'oSampleStatus = SampleInfo.unknown
                            Case OfferInfo.accepted_CheckOut
                                'ok
                                'oOfferStatus = OfferInfo.unknown
                                'oSampleStatus = SampleInfo.unknown
                            Case OfferInfo.unknown
                                oSampleStatus = SampleInfo.unknown
                        End Select
                    Case SampleInfo.sold
                        Select Case oOfferStatus
                            Case OfferInfo.activeNow
                                'error
                                oOfferStatus = OfferInfo.unknown
                                oSampleStatus = SampleInfo.unknown
                            Case OfferInfo.declined
                                'error
                                oOfferStatus = OfferInfo.unknown
                                oSampleStatus = SampleInfo.unknown
                            Case OfferInfo.accepted_StockOut
                                'ok
                            Case OfferInfo.accepted_CheckOut
                                'ok
                            Case OfferInfo.unknown
                                oSampleStatus = SampleInfo.unknown
                        End Select
                    Case SampleInfo.reserved
                        Select Case oOfferStatus
                            Case OfferInfo.activeNow
                                'ok
                            Case OfferInfo.declined
                                'error
                            Case OfferInfo.accepted_StockOut
                                'ok
                            Case OfferInfo.accepted_CheckOut
                                'ok
                            Case OfferInfo.unknown
                                oSampleStatus = SampleInfo.unknown
                        End Select
                    Case SampleInfo.unknown
                        oOfferStatus = OfferInfo.unknown

                End Select
            End Set
        End Property
        '================
        Property Offer As OfferInfo
            Get
                Return oOfferStatus
            End Get
            Set(ByVal value As OfferInfo)
                oOfferStatus = value
                Select Case value
                    Case OfferInfo.declined
                        oSampleStatus = SampleInfo.unsold
                    Case OfferInfo.accepted_CheckOut
                        'oSampleStatus = SampleInfo.sold
                    Case OfferInfo.accepted_StockOut
                        'oSampleStatus = SampleInfo.reserved
                    Case OfferInfo.activeNow
                        oSampleStatus = SampleInfo.reserved
                    Case OfferInfo.unknown
                        oSampleStatus = SampleInfo.unknown

                End Select
            End Set
        End Property
        Property OrderID As String
    End Structure


    Public Sub New()

        ' Этот вызов является обязательным для конструктора.
        InitializeComponent()

        ' Добавьте все инициализирующие действия после вызова InitializeComponent().
        For Each _ctl As Control In Me.Controls
            _ctl.Enabled = False
        Next

        Me.tbSampleNumber.Enabled = True
        Me.btSearchInfo.Enabled = True
        Me.RTBSampleData.Enabled = True
        Me.btCreateByTemplate.Enabled = True
        Me.lbTemplates.Enabled = True
        Me.lbLinkedSources.Enabled = True
        Me.cbxRepalceImages.Enabled = True
        Me.btCopyByTemplate.Enabled = True
        Me.btAddTemplate.Enabled = True
        Me.tcSampleInfo.Enabled = True
        Me.Label10.Enabled = True
        LoadTemplates()
        LoadSources(False, True)
    End Sub
    Public Sub New(ByVal SampleNumber As Service.clsApplicationTypes.clsSampleNumber)
        InitializeComponent()

        If Not SampleNumber Is Nothing Then
            'установим свойство эу ввода номера
            Me.oSampleNumber = SampleNumber
            Me.tbSampleNumber.Text = oSampleNumber.EAN13
            Me.btSearchInfo_Click(Me, New System.EventArgs)
        End If
    End Sub

    Private Sub btSearchInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSearchInfo.Click
        If Me.tbSampleNumber.Text = "" Then
            Exit Sub
        End If
        Static _lockCtl As Boolean
        If Not _lockCtl Then
            For Each _ctl As Control In Me.Controls
                If _ctl.GetType.Name = "Button" Or _ctl.GetType.Name = "DataGridView" Or _ctl.GetType.Name = "TabControl" Or _ctl.GetType.Name = "CheckBox" Or _ctl.GetType.Name = "RadioButton" Then
                    _ctl.Enabled = True
                    _lockCtl = True
                End If
            Next
        End If

        'блок добавления по шаблону
        Me.btShowInBrowser.Text = "Браузер"
        Me.btShowInBrowser.Enabled = False
        Me.Label10.Enabled = True
        'константы статуса образца
        Const _cnsStatusPhoto As String = "Фотки"

        Const _cnsStatusSampleData As String = "Данные образца"
        'по проверке заполнения всех столбцов образца
        Const _cnsStatusSampleDataComplete As String = "Полнота данных образца"

        Const _cnsStatusFossilData As String = "Данные фоссилий"
        'по проверке заполнения всех столбцов фоссилий
        Const _cnsStatusFossilDataComplete As String = "Полнота данных фоссилий"

        Const _cnsOnSaleData As String = "Данные подготовки к продаже"
        'по проверке заполнения всех столбцов подготовки к продаже
        Const _cnsOnSaleDataComplete As String = "Полнота данных подготовки к продаже"

        Const _cnsWasIncludedInOffers As String = "Участие в предложениях"

        Const _cnsSampleReserved As String = "Находится в рассматриваемых предложениях"
        Const _cnsSampleSold As String = "Продан"

        Const _cnsSampleFreeToOffers As String = "Свободен для заказа"

        '=====================
        Dim _lastNumber As String = ""
        Dim _infoStatus As New Collections.Generic.Dictionary(Of String, Boolean)

        If Not Me.oSampleNumber Is Nothing Then
            _lastNumber = Me.oSampleNumber.EAN13
        End If
        Dim _number As Service.clsApplicationTypes.clsSampleNumber = Service.clsApplicationTypes.clsSampleNumber.CreateFromString(Me.tbSampleNumber.Text)
        If _number Is Nothing Then
            MsgBox("неверный код: " + Me.tbSampleNumber.Text, MsgBoxStyle.Critical)
            Me.tbSampleNumber.Text = _lastNumber
            Exit Sub
        End If


        Me.btSearchInfo.Focus()
        Me.lbSample.Text = _number.ShotCode
        Me.oSampleNumber = _number
        Me.tbSampleNumber.Text = _number.EAN13
        Me.cbSourcesList.DataSource = Nothing
        Me.pbMainImage.Image = Nothing
        '----------------------------
        'форма
        'все цвета - на место!
        For Each _control As Control In Me.Controls
            Select Case _control.GetType.Name
                Case "Button"
                    _control.ForeColor = SystemColors.ControlText
                    _control.BackColor = SystemColors.Control
            End Select
        Next
        'и кнопки тоже
        Me.cbOrders.Visible = False
        Me.btAddtoOrder.Visible = True
        Me.btAcceptOrder.Visible = False
        Me.RTBSampleData.Text = ""
        '----------------------------------------
        '-----------------------
        'заполняем адаптеры
        Dim _SampleMainName As String = ""
        '-------------sample data--------------
        'check dbConnection

        Try
            Me.Select_SampleInfoTableAdapter1.Fill(Me.DsService.Select_SampleInfo, _number.GetEan13)

        Catch ex As Exception
            MsgBox("Can't connect to DB. Connection string: " & Me.Select_SampleInfoTableAdapter1.Connection.ConnectionString)
            For Each _ctl As Control In Me.Controls
                If _ctl.GetType.Name = "Button" Or _ctl.GetType.Name = "DataGridView" Or _ctl.GetType.Name = "TabControl" Then
                    _ctl.Enabled = False
                    _lockCtl = True
                End If
            Next
            Exit Sub
        End Try


        If Me.SelectSampleInfoBindingSource.Count = 0 Then
            ''данных образца нет
            _infoStatus.Add(_cnsStatusSampleData, False)
        Else
            Me.btAddtoOrder.Enabled = True
            'проверка заполнения всех необходимых полей
            Dim _flagComplete As Boolean = True
            For Each _tmpRow As dsService.Select_SampleInfoRow In Me.DsService.Select_SampleInfo
                With _tmpRow
                    If .Sample_main_species = "" Then
                        _flagComplete = False
                    Else
                        _SampleMainName = .Sample_main_species
                    End If

                    If .Sample_length = 0 Then
                        _flagComplete = False
                    Else
                        '_SampleMainName += " " & .Sample_length.ToString & " x "
                    End If

                    If .Sample_width = 0 Then
                        _flagComplete = False
                    Else
                        '_SampleMainName += " " & .Sample_width.ToString & " cm"
                    End If

                    If .Sample_net_weight = 0 Then
                        _flagComplete = False
                    Else
                        '_SampleMainName += " " & .Sample_net_weight.ToString & "kg"
                    End If

                End With
            Next
            _infoStatus.Add(_cnsStatusSampleDataComplete, _flagComplete)
        End If
        '-------------------------------



        '---------------fossil data-------------
        Me.SelectFossilInfoTableAdapter.Fill(Me.DsService.SelectFossilInfo, _number.GetEan13)
        If Me.SelectFossilInfoBindingSource.Count = 0 Then
            ''данные о фоссилиях отсутствуют
            _infoStatus.Add(_cnsStatusFossilData, False)
        Else
            _infoStatus.Add(_cnsStatusFossilData, True)
            'проверка заполнения всех необходимых полей
            Dim _flagComplete As Boolean = True
            For Each _tmpRow As dsService.SelectFossilInfoRow In Me.DsService.SelectFossilInfo
                With _tmpRow
                    If .Fossil_full_name = "" Then _flagComplete = False
                    If .Fossil_length = 0 Then _flagComplete = False
                End With
            Next
            _infoStatus.Add(_cnsStatusFossilDataComplete, _flagComplete)

            If Me.DsService.SelectFossilInfo.Rows.Count > 0 Then
                Dim _tmp As dsService.SelectFossilInfoRow = Me.DsService.SelectFossilInfo.Rows(0)
                _SampleMainName += " " & _tmp.Fossil_dimension
            End If
        End If
        '------------------
        'заполним фотки
        'выбрать доступные устройства вывода
        Dim _sourceList = clsApplicationTypes.SamplePhotoObject.GetSourcesList(_number, Me.cbxRemoteConnections.Checked)
        If _sourceList.Count > 0 Then
            'в списке - доступные устройства!
            Me.cbSourcesList.DataSource = _sourceList

            Dim _ArhiveSource = (From c In _sourceList Where c.Source = clsFilesSources.emSources.Arhive Select c).FirstOrDefault
            'метод ShowPhoto вызывается из обработчика события selectedindex changed  Me.cbSourcesList
            If Not _ArhiveSource Is Nothing Then
                Me.cbSourcesList.SelectedItem = _ArhiveSource
            Else
                Me.cbSourcesList.SelectedItem = _sourceList(0)
            End If

            ''фотки есть
            _infoStatus.Add(_cnsStatusPhoto, True)
            'отобразим окно с большой первой фоткой
            If Me.cbShowPreview.Checked Then
                imgLwPhoto.Items(0).Selected = True
                If _SampleMainName = "" Then
                    _SampleMainName = "NO DATA!!"
                End If
                Call Me.ShowImageForm(_SampleMainName)
                Me.Timer1.Interval = CType(Me.tbPrevievTime.Text, Integer) * 1000
                If Me.Timer1.Interval > 0 Then
                    Me.Timer1.Start()
                End If
            End If
        Else
            ''изображений нет!!
            _infoStatus.Add(_cnsStatusPhoto, False)
        End If

        '----------------On Sale-----------
        Me.Select_tb_SamplesOnSaleTableAdapter.Fill(Me.SampleOnSale.Select_tb_SamplesOnSale, _number.GetEan13)

        If Me.Select_tb_SamplesOnSaleBindingSource.Count = 0 Then
            ''данные о подготовке к продаже отсутствуют
            _infoStatus.Add(_cnsOnSaleData, False)
        Else
            _infoStatus.Add(_cnsOnSaleData, True)
            'проверка заполнения всех необходимых полей
            Dim _flagComplete As Boolean = True
            For Each _tmpRow As SampleOnSale.Select_tb_SamplesOnSaleRow In Me.SampleOnSale.Select_tb_SamplesOnSale
                With _tmpRow
                    If .IsOnSaleFlagNull = True Then _flagComplete = False
                    If .BasePrice = 0 Then _flagComplete = False
                    If .Costs = 0 Then _flagComplete = False
                    If .CurrencyName = "" Then _flagComplete = False
                    If .RateOfExchange = 0 Then _flagComplete = False
                    If .Description = "" Then _flagComplete = False

                End With
            Next
            _infoStatus.Add(_cnsOnSaleDataComplete, _flagComplete)
        End If
        '--------------Offers ---------------
        Me.Select_SampleOrdersInfoTableAdapter.Fill(Me.DsOrders_new.Select_SampleOrdersInfo, _number.GetEan13)
        If Me.SelectSampleOrdersInfoBindingSource.Count = 0 Then
            ''образец в заказах не учавствовал
            _infoStatus.Add(_cnsWasIncludedInOffers, False)
        Else
            _infoStatus.Add(_cnsWasIncludedInOffers, True)
            'проверка текущего статуса в заказах
            Dim _status As SampleStatus
            Dim _statusCollection As New Collections.Generic.List(Of SampleStatus)
            For Each _tmpRow As dsOrders_new.Select_SampleOrdersInfoRow In Me.DsOrders_new.Select_SampleOrdersInfo
                'обнулить флаги
                _status = New SampleStatus(SampleStatus.SampleInfo.unknown, SampleStatus.OfferInfo.unknown)
                _status.OrderID = _tmpRow.OrderID

                With _tmpRow


                    ''проверка статусов предложения

                    ''-----------order status: Order_Cancellation_Status-----
                    'предложение отклонено полностью и закрыто
                    If Not (.Order_Cancellation_Status = False Or .IsOrder_Cancellation_StatusNull) Then
                        'предложение отклонено полностью и закрыто
                        Debug.Assert(.Order_Cancellation_Status = True)
                        _status.Offer = SampleStatus.OfferInfo.declined

                        ''-----------order status: Order_StockOut_Status-----
                        ''предложение выполнено, но НЕ закрыто
                    ElseIf Not (.Order_StockOut_Status = False Or .IsOrder_StockOut_StatusNull) Then
                        'предложение принято все или частично
                        Debug.Assert(.Order_StockOut_Status = True)
                        _status.Offer = SampleStatus.OfferInfo.accepted_StockOut

                    ElseIf Not (.Order_CheckOut_Status = False Or .IsOrder_CheckOut_StatusNull) Then
                        'предложение выполнено и закрыто
                        Debug.Assert(.Order_CheckOut_Status = True)
                        _status.Offer = SampleStatus.OfferInfo.accepted_CheckOut

                    Else
                        _status.Offer = SampleStatus.OfferInfo.activeNow
                    End If

                    '====================
                    'проверка статуса образца
                    If Not (.Sample_Confirm_Status = False Or .IsSample_Confirm_StatusNull) Then
                        'образец заказан из предложения но НЕ закрыт
                        Debug.Assert(.Sample_Confirm_Status = True)
                        _status.Sample = SampleStatus.SampleInfo.reserved
                    ElseIf Not (.Sample_CheckOut_Status = False Or .IsSample_CheckOut_StatusNull) Then
                        'образец продан (отправлен и закрыт)
                        Debug.Assert(.Sample_CheckOut_Status = True)
                        _status.Sample = SampleStatus.SampleInfo.sold
                    Else
                        _status.Sample = SampleStatus.SampleInfo.unsold
                    End If


                    'If Not (.ReservedFlag = False Or .IsReservedFlagNull) Then
                    '    Debug.Assert(.ReservedFlag = True)

                    'End If
                    '===================
                    'If Not (.SoldFlag = False Or .IsSoldFlagNull) Then

                    'End If
                    'окончание проверки образца

                End With
                _statusCollection.Add(_status)
                'для каждого заказа подсвечиваем строки
                'подсветить его в таблице
                'найдем соответствующую строку
                Dim _activeRowInGrid As DataGridViewRow = Nothing
                For Each _row As DataGridViewRow In Me.DataGridView2.Rows
                    If _row.Cells(0).Value.ToString = _tmpRow.OrderID Then
                        _activeRowInGrid = _row
                    End If
                Next
                If Not _activeRowInGrid Is Nothing Then
                    Select Case _status.Offer
                        Case SampleStatus.OfferInfo.unknown
                            'предложение не ясного статуса
                            'подсветить красным
                            _activeRowInGrid.DefaultCellStyle.BackColor = Color.Red
                    End Select

                    Select Case _status.Sample
                        Case SampleStatus.SampleInfo.unknown
                            'образец в предложении не ясного статуса
                            'подсветить оранжевым
                            _activeRowInGrid.DefaultCellStyle.BackColor = Color.Orange

                        Case SampleStatus.SampleInfo.sold
                            'продан
                            'подсветить зеленым
                            _activeRowInGrid.DefaultCellStyle.BackColor = Color.Green

                        Case SampleStatus.SampleInfo.reserved
                            'зарезервирован
                            'подсветить синим
                            _activeRowInGrid.DefaultCellStyle.BackColor = Color.Blue

                        Case SampleStatus.SampleInfo.unsold

                    End Select


                End If


            Next

            Dim _flOrdered As Boolean = False
            For Each _st As SampleStatus In _statusCollection
                Select Case _st.Sample

                    Case SampleStatus.SampleInfo.sold
                        'продан
                        _infoStatus.Add(_cnsSampleSold, True)
                        _flOrdered = True
                        Exit For
                    Case SampleStatus.SampleInfo.reserved
                        'зарезервирован
                        _infoStatus.Add(_cnsSampleReserved, True)
                        _flOrdered = True
                        Exit For
                End Select
            Next
            If _flOrdered = False Then
                _infoStatus.Add(_cnsSampleFreeToOffers, True)
            End If


            ''====END CHECK SAMPLE STATUS
        End If


        '----------------------------------
        'работа с интерфейсом
        ''здесь надо отформатировать элементы формы в соответствии с результатами запросов
        For Each _tmp As String In _infoStatus.Keys
            Select Case _tmp
                '-----------images----------------
                Case _cnsStatusPhoto
                    If _infoStatus(_tmp) = False Then
                        ''изображений нет!!
                        Me.lbSampleStatus.Text = "фоток нет"
                        Me.lbSampleStatus.ForeColor = Color.Red
                        Me.btAddImages.BackColor = Color.Red
                    Else
                        Me.lbSampleStatus.Text = "фотки есть"
                        Me.btAddImages.BackColor = Color.Green
                    End If
                    Me.lbSampleStatus.Text += " /// "
                    '-----------sample data----------
                Case _cnsStatusSampleData
                    If _infoStatus(_tmp) = False Then
                        ''данных образца нет
                        Me.lbSampleStatus.Text += "данные образца отсутствуют"
                        Me.lbSampleStatus.ForeColor = Color.Red
                        Me.btAddSampleData.BackColor = Color.Red
                        Me.btAddtoOrder.Enabled = False
                    Else
                        Me.lbSampleStatus.Text += "данные образца занесены"
                        If Not Me.btAddSampleData.BackColor = Color.Orange Then
                            Me.btAddSampleData.BackColor = Color.Green
                        End If

                        Me.btAddtoOrder.Enabled = True
                    End If
                    Me.lbSampleStatus.Text += " /// "

                Case _cnsStatusSampleDataComplete
                    If _infoStatus(_tmp) = False Then
                        ''основные данные образца неполные
                        Me.btAddSampleData.BackColor = Color.Orange
                        Me.lbSampleStatus.Text += "данные образца НЕ ПОЛНЫЕ"
                        Me.lbSampleStatus.Text += " /// "
                    End If

                    '-----------fossil data--------------
                Case _cnsStatusFossilData
                    If _infoStatus(_tmp) = False Then
                        ''данные о фоссилиях отсутствуют
                        Me.lbSampleStatus.Text += "данные фоссилий отсутствуют"
                        Me.lbSampleStatus.ForeColor = Color.Red
                        Me.btAddSampleData.BackColor = Color.Red
                        Me.btAddtoOrder.Enabled = False
                    Else
                        Me.lbSampleStatus.Text += "данные фоссилий занесены"
                        If Not Me.btAddSampleData.BackColor = Color.Orange Then
                            Me.btAddSampleData.BackColor = Color.Green
                        End If
                        Me.btAddtoOrder.Enabled = True
                    End If
                    Me.lbSampleStatus.Text += " /// "


                Case _cnsStatusFossilDataComplete
                    If _infoStatus(_tmp) = False Then
                        ''данные о фоссилиях неполные
                        Me.btAddSampleData.BackColor = Color.Orange
                        Me.lbSampleStatus.Text += "данные фоссилий НЕ ПОЛНЫЕ"
                        Me.lbSampleStatus.Text += " /// "
                    End If
                    '----------on sale---------------------
                Case _cnsOnSaleData
                    If _infoStatus(_tmp) = False Then
                        ''данные о подготовке к продаже отсутствуют
                        Me.lbSampleStatus.Text += "данные подготовки к продаже отсутствуют"
                        Me.lbSampleStatus.ForeColor = Color.Red
                        Me.btAddOnSale.BackColor = Color.Red
                        Me.btAddtoOrder.Enabled = False
                    Else
                        Me.lbSampleStatus.Text += "данные подготовки к продаже занесены"
                        If Not Me.btAddOnSale.BackColor = Color.Orange Then
                            Me.btAddOnSale.BackColor = Color.Green
                        End If
                        Me.btAddtoOrder.Enabled = True
                    End If
                    Me.lbSampleStatus.Text += " /// "
                Case _cnsOnSaleDataComplete
                    If _infoStatus(_tmp) = False Then
                        ''данные о подготовке к продаже неполные
                        Me.btAddOnSale.BackColor = Color.Orange
                        Me.lbSampleStatus.Text += "данные подготовки к продаже НЕ ПОЛНЫЕ"
                        Me.lbSampleStatus.Text += " /// "
                    End If

                    '----------offers------------------
                Case _cnsWasIncludedInOffers
                    If _infoStatus(_tmp) = False Then
                        ''образец в предложениях не учавствовал
                        Me.lbSampleStatus.Text += "в предложениях не участвовал"
                        Me.btAddtoOrder.BackColor = Color.Green
                    Else
                        Me.lbSampleStatus.Text += "был предложен"
                    End If
                    Me.lbSampleStatus.Text += " /// "
                Case _cnsSampleSold
                    If _infoStatus(_tmp) = True Then
                        'образец продан
                        Me.btAddtoOrder.BackColor = Color.Red
                        Me.btAddtoOrder.Enabled = False
                        Me.lbSampleStatus.Text += "ПРОДАН"
                        Me.lbSampleStatus.Text += " /// "
                    End If
                Case _cnsSampleReserved
                    If _infoStatus(_tmp) = True Then
                        'образец зарезервирован
                        Me.btAddtoOrder.BackColor = Color.Red
                        Me.btAddtoOrder.Enabled = False
                        Me.lbSampleStatus.Text += "ЗАРЕЗЕРВИРОВАН"
                        Me.lbSampleStatus.Text += " /// "
                    End If
                Case _cnsSampleFreeToOffers
                    If _infoStatus(_tmp) = True Then
                        'образец свободен для заказа
                        Me.btAddtoOrder.BackColor = Color.Green
                        Me.btAddtoOrder.Enabled = True
                        Me.lbSampleStatus.Text += "СВОБОДЕН ДЛЯ ЗАКАЗА"
                        Me.lbSampleStatus.Text += " /// "
                    End If

            End Select

        Next

        'отобразим данные в строке

        If Me.rbRussian.Checked Then
            Me.lbCurrentCulture.Text = "Текущий язык русский"
            Me.RTBSampleData.Text = GetDescriptionByCulture(clsApplicationTypes.RussianCulture)
        Else
            Me.lbCurrentCulture.Text = "Текущий язык английский"
            Me.RTBSampleData.Text = GetDescriptionByCulture(clsApplicationTypes.EnglishCulture)
        End If

        'проверка наличия XML файла образца
        Dim _sdo = clsApplicationTypes.SampleDataObject.GetSampleOnSale(oSampleNumber)

        If Not _sdo Is Nothing Then
            If Not _sdo.SampleXMLFile = "" Then
                Me.btShowInBrowser.Text = "Файл XML есть"
                Me.btShowInBrowser.Enabled = True
                Me.btCopyByTemplate.Enabled = True
            Else
                Me.btShowInBrowser.Text = "Нет XML"
                Me.btShowInBrowser.Enabled = False
            End If
        Else
            Me.btShowInBrowser.Text = "Браузер"
            Me.btShowInBrowser.Enabled = False
        End If

        'If Me.cbAutoList.Checked Then
        '    'включить автозаполнение
        '    Me.btAddInList_Click(Me, System.EventArgs.Empty)
        'End If


    End Sub
    Private Function GetDescriptionByCulture(culture As System.Globalization.CultureInfo) As String
        If Me.oSampleNumber Is Nothing Then Return ""
        Dim _status As Integer
        Dim _result = Service.clsApplicationTypes.DelegateStoreGetSampleInfoText.Invoke(Me.oSampleNumber, culture, _status)

        'add price
        If _status > 0 AndAlso Not (Me.SampleOnSale.Select_tb_SamplesOnSale.FindBySampleNumber(Me.oSampleNumber.GetEan13) Is Nothing) Then
            Dim _price = Me.SampleOnSale.Select_tb_SamplesOnSale(0).BasePrice.ToString
            Dim _currName = Me.SampleOnSale.Select_tb_SamplesOnSale(0).CurrencyName
            Debug.Assert(Not culture Is Nothing)
            _result += Chr(13)
            Select Case culture.Name
                Case clsApplicationTypes.RussianCulture.Name
                    Select Case _currName.ToLower
                        Case "rur"
                            _currName = "руб"
                    End Select
                    _result += "Цена: " & _price & " " & _currName
                Case clsApplicationTypes.EnglishCulture.Name
                    _result += "Price: " & _price & " " & _currName
                Case Else
                    Debug.Fail("operation for this culture name is missing")
                    _result += "Price: " & _price & " " & _currName
            End Select
            Return _result
        End If

        Return "нет данных"

    End Function


    ''' <summary>
    ''' заполняет имаджлист фотками и вернет результат наличия фото
    ''' </summary>
    ''' <param name="SampleNumber"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ShowPhotos(SampleNumber As Service.clsApplicationTypes.clsSampleNumber) As Boolean
        'заполним фотки
        Me.pbMainImage.Image = Nothing
        'Me.pbMainImage.Invalidate()
        Me.pbMainImage.Refresh()
        Me.Cursor = Cursors.WaitCursor
        Me.pbMainImage.Image = Nothing
        For Each t In Me.imgLwPhoto.Items
            t.Remove()
        Next
        Me.imgLwPhoto.Clear()
        Dim _ImageList As Service.SampleSourceImageList
        Dim _source As clsFilesSources = Nothing

        If Me.cbSourcesList.SelectedItem Is Nothing Then
            ''устройств с изображениями нет!!
            Me.Cursor = Cursors.Default
            Return False
        End If

        ''в этой точке есть хотя бы одно устройство с фото
        _ImageList = Service.clsApplicationTypes.SamplePhotoObject.GetSampleImageList(SampleNumber, Me.cbSourcesList.SelectedItem, New Size(320, 240), False)

        If _ImageList Is Nothing OrElse _ImageList.CountImages = 0 Then
            ''изображений нет, но функция GetSourcesList вернула устройство!!
            Debug.Fail("изображений нет, но функция GetSourcesList вернула устройство!!")
            Me.Cursor = Cursors.Default
            Return False
        Else
            Me.pbMainImage.Image = clsApplicationTypes.SamplePhotoObject.GetMainImage(Me.cbSourcesList.SelectedItem, SampleNumber)
            With Me.imgLwPhoto
                .BeginUpdate()
                .View = View.LargeIcon
                .Clear()
                For Each t In _ImageList.ListViewItems
                    t.Remove()
                Next
                .Items.AddRange(_ImageList.ListViewItems)
                .SmallImageList = _ImageList.ImageList
                .LargeImageList = _ImageList.ImageList
                .EndUpdate()
            End With
            Me.Cursor = Cursors.Default
            Return True
        End If
    End Function


    Private Sub tbSampleNumber_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbSampleNumber.Enter
        If sender.text.ToString.Length >= 13 Then
            sender.text = ""

        End If

    End Sub


    Private Sub tbSampleNumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbSampleNumber.KeyPress
        If Asc(e.KeyChar) = 13 Then

            btSearchInfo_Click(Me, New System.EventArgs)

        End If

    End Sub

    Private Sub imgLwPhoto_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles imgLwPhoto.DoubleClick


        'If imgLwPhoto.SelectedItems.Count = 0 Then Exit Sub
        'Call Me.ShowImageForm(imgLwPhoto.SelectedItems.Item(0).Name, True)
    End Sub
    Private oActiveFolder As String = ""

    Private oActiveImagePopUp As Form

    ''' <summary>
    ''' показать увеличенное изображение
    ''' </summary>
    ''' <param name="SampleMainName"></param>
    ''' <param name="ShowAllImages"></param>
    ''' <remarks></remarks>
    Private Sub ShowImageForm(Optional ByVal SampleMainName As String = "", Optional ByVal ShowAllImages As Boolean = False)
        Dim _source = clsFilesSources.CreateInstance(Service.clsFilesSources.emSources.Arhive)


        Dim _prm As Object

        If ShowAllImages Then
            _prm = Service.clsApplicationTypes.SamplePhotoObject.GetImageCollection(Me.oSampleNumber, _source, False)
        Else
            _prm = Service.clsApplicationTypes.SamplePhotoObject.GetImage(_source, Me.oSampleNumber, SampleMainName, False)
        End If

        'show image form
        'использование сервисов
        'по запросу выполняем вызов из сервиса

        Dim _param As Object
        If Not SampleMainName = "" Then
            _param = {_prm, SampleMainName}
        Else
            _param = {_prm}
        End If

        'если делегата нет, то сервис недоступен
        If Not Global.Service.clsApplicationTypes.DelegateStoreApplicationForm(Service.clsApplicationTypes.emFormsList.fmImage) Is Nothing Then
            'сервис зарегестрирован - вызываем
            oActiveImagePopUp = Global.Service.clsApplicationTypes.DelegateStoreApplicationForm(Service.clsApplicationTypes.emFormsList.fmImage).Invoke(_param)
            If Not oActiveImagePopUp Is Nothing Then
                'show form
                With oActiveImagePopUp
                    .Width = 640
                    .Height = 480

                    .Name = "ImageShowForm"
                    .StartPosition = FormStartPosition.CenterScreen
                    'привязка обработчика
                    'Me.cbSourcesList.SelectedItem
                    'Me.oSampleNumber
                    Service.clsApplicationTypes.DelegatStorefmImageDeleteDelegate = New Service.clsApplicationTypes.fmImageDeleteDelegat(AddressOf DelImage_eventHandler)
                    Service.clsApplicationTypes.DelegatStorefmImageCopyDelegate = New Service.clsApplicationTypes.fmImageCopyDelegat(AddressOf CopyImage_eventHandler)
                    oImageChangedFlag = False
                    .ShowDialog()
                    If oImageChangedFlag Then
                        Me.ShowPhotos(Me.oSampleNumber)
                    End If
                End With

            End If
        Else

        End If


    End Sub
    Private oImageChangedFlag As Boolean

    Private Sub CopyImage_eventHandler(ByVal sender As Object, ByVal e As Service.clsApplicationTypes.fmImageCopyEventArg)
        If e.ImageNames.Length = 0 Then Exit Sub

        'скопировать изображения, список имен в аргументе
        'Dim _tmpSample As Decimal = Me.Dgv_SamplesINOrders.CurrentRow.Cells(0).Value
        'Dim _filesrc = Me.cbSourcesList.SelectedItem
        Dim _sampleNumber = Me.oSampleNumber

        'задать устройство принимающее
        Dim _Tosource As clsFilesSources = Me.cbSourcesList.SelectedItem

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
                MsgBox(_count & " фото скопированы для образца" & _sampleNumber.GetEan13 & " на уст-во " & _Tosource.ToString, vbInformation)
                Me.oImageChangedFlag = True
            Case MsgBoxResult.No
                Exit Sub
        End Select



    End Sub


    Private Sub DelImage_eventHandler(ByVal sender As Object, ByVal e As Service.clsApplicationTypes.fmImageDelEventArg)
        If e.ImageNames.Count = 0 Then Exit Sub

        'удалить изображения, список имен в аргументе
        'Dim _tmpSample As Decimal = Me.Dgv_SamplesINOrders.CurrentRow.Cells(0).Value
        'Dim _filesrc = clsFilesSources.CreateInstance(Service.clsFilesSources.emSources.SpecificOrder, Me.oCurrentOrder)
        Dim _sampleNumber = Me.oSampleNumber
        Dim _coll(e.ImageNames.Count - 1) As String
        e.ImageNames.CopyTo(_coll, 0)
        Dim _count As Integer = Service.clsApplicationTypes.SamplePhotoObject.DeleteImagesFromSource(_sampleNumber, Me.cbSourcesList.SelectedItem, _coll, False, False)
        MsgBox("Удалено " & _count & " фото с устр-ва " & Me.cbSourcesList.SelectedItem.ToString, vbInformation)
        Me.oImageChangedFlag = True
        Service.clsApplicationTypes.DelegatStorefmImageDeleteDelegate = Nothing
    End Sub

    Private Sub btAddSampleData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btAddSampleData.Click
        Dim _param As Object = {Me.oSampleNumber.GetEan13}
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

        ''сохранить запись
        'Me.Select_tb_SamplesOnSaleBindingSource.EndEdit()
        'Me.TableAdapterManager1.UpdateAll(Me.SampleOnSale)
        ''открыть окно
        If Not _fmSampleData Is Nothing AndAlso _fmSampleData.IsDisposed = False Then
            _fmSampleData.MdiParent = Me.MdiParent
            _fmSampleData.Show()
            'Me.btSearchInfo.Focus()
        End If


    End Sub

    Private Sub btAddOnSale_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btAddOnSale.Click
        'по запросу выполняем вызов из сервиса
        'если делегата нет, то сервис недоступен
        Dim _fmSampleOnSale As Form
        Dim _param As Object = {Me.oSampleNumber.GetEan13}

        If Not Global.Service.clsApplicationTypes.DelegateStoreApplicationForm _
(Service.clsApplicationTypes.emFormsList.fmSampleOnSale) Is Nothing Then
            'сервис зарегестрирован - вызываем
            _fmSampleOnSale = Global.Service.clsApplicationTypes.DelegateStoreApplicationForm(Service.clsApplicationTypes.emFormsList.fmSampleOnSale).Invoke(_param)
        Else
            Exit Sub
        End If

        _fmSampleOnSale.ShowDialog()

        Me.btSearchInfo.Focus()
    End Sub

    Private Sub btAddImages_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btAddImages.Click
        'call service function
        ''call service function   fmPhotoList

        Dim _param As Object = {Me.oSampleNumber.EAN13}
        Dim _fm As Form
        'по запросу выполняем вызов из сервиса
        'если делегата нет, то сервис недоступен
        If Not Global.Service.clsApplicationTypes.DelegateStoreApplicationForm _
            (Service.clsApplicationTypes.emFormsList.fmImageManager) Is Nothing Then
            'сервис зарегестрирован - вызываем
            _fm = Global.Service.clsApplicationTypes.DelegateStoreApplicationForm _
                (Service.clsApplicationTypes.emFormsList.fmImageManager).Invoke(_param)
            If Not _fm Is Nothing Then
                _fm.MdiParent = Me.MdiParent
                AddHandler _fm.FormClosed, AddressOf Me._fmImgCloseHandler
                _fm.Show()

            End If

        End If


    End Sub
    Private Sub _fmImgCloseHandler(ByVal sender As Object, ByVal e As System.EventArgs)
        'форма изображений закрыта
        'отобразить фото в Me
        If Not IsNothing(oSampleNumber) Then
            Me.ShowPhotos(Me.oSampleNumber)
        End If
        Me.btSearchInfo.Focus()
    End Sub

    Private Sub btAddtoOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btAddtoOrder.Click
        Me.cbOrders.Visible = True
        Me.cbOrders.Enabled = True
        'получить список заказов
        Dim _orders As Collections.Generic.List(Of Service.clsApplicationTypes.clsOrder) = Nothing

        'по запросу выполняем вызов из сервиса
        'если делегата нет, то сервис недоступен
        If Not Global.Service.clsApplicationTypes.DelegateStoreOrdersNonClosedList Is Nothing Then
            'сервис зарегестрирован - вызываем
            _orders = Global.Service.clsApplicationTypes.DelegateStoreOrdersNonClosedList.Invoke()
            If _orders Is Nothing OrElse _orders.Count = 0 Then Exit Sub
        End If
        Dim _list As New Collections.Specialized.StringCollection
        For Each _tmp As Service.clsApplicationTypes.clsOrder In _orders
            _list.Add(_tmp.ClientFullName + ">" + _tmp.OrderID)

        Next
        'найти последний активный заказ (если есть)
        Dim _lastOrder As String = "last offer" + ">"
        Dim _adapter As New dsServiceTableAdapters.QueriesTableAdapter
        _lastOrder += _adapter.Select_LastOrderNonClosed
        _list.Add(_lastOrder)

        Me.cbOrders.DataBindings.Clear()
        With Me.cbOrders
            .DataSource = _list
            .DisplayMember = "item"
            '.Sorted = True
            Me.cbOrders.Visible = True
            Me.btAddtoOrder.Visible = False
            Me.btAcceptOrder.Visible = True
            .SelectedItem = _lastOrder
        End With
        Me.cbOrders.Focus()
    End Sub

    Private Sub btAcceptOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btAcceptOrder.Click
        Dim _orderId As String = ""

        Dim _str As String = Me.cbOrders.SelectedItem
        _orderId = Trim(_str.Split(">".ToCharArray)(1))

        'создать список отмеченных изображений
        Dim _SelectedPhotoNames() As String = {}
        Dim _coll As New Collections.Specialized.StringCollection

        For Each _tmp As ListViewItem In Me.imgLwPhoto.CheckedItems
            _coll.Add(_tmp.Name)
        Next
        If _coll.Count > 0 Then
            ReDim _SelectedPhotoNames(_coll.Count - 1)
            _coll.CopyTo(_SelectedPhotoNames, 0)
        Else
            'будут скопированы все фото
            Select Case MsgBox("Поместить все фото в заказ? Не выделено ни одной фото.", MsgBoxStyle.YesNo)
                Case MsgBoxResult.Yes
                    _SelectedPhotoNames = Nothing
                Case MsgBoxResult.No
                    'откат
                    'все по местам!
                    Me.cbOrders.Visible = False
                    Me.btAddtoOrder.Visible = True
                    Me.btAcceptOrder.Visible = False
                    Me.btSearchInfo.Focus()
                    Exit Sub
            End Select

        End If


        'вычислить оптимизацию
        Dim _optimize As Integer = 0

        If Me.rb1024Optimize.Checked Then _optimize = 1024
        If Me.rb2048Optimize.Checked Then _optimize = 2048


        'поместить в заказ
        If Me.ShowDialogfmOrder(_orderId, True, _SelectedPhotoNames, _optimize) Then
            'все по местам!
            Me.cbOrders.Visible = False
            Me.btAddtoOrder.Visible = True
            Me.btAcceptOrder.Visible = False
            Me.btSearchInfo.Focus()
        End If
    End Sub
    Private Function ShowDialogfmOrder(ByVal OrderID As String, Optional ByVal AddInOrder As Boolean = False, Optional FileNames As String() = Nothing, Optional OptimizeImageWidth As Integer = 0) As Boolean
        'добавить образец к заказу
        Debug.Assert(Not OrderID = "")
        Debug.Assert(OrderID.Length = 8)

        If AddInOrder Then
            'если делегата нет, то сервис недоступен
            If Not Global.Service.clsApplicationTypes.DelegateStoreAddSampleToOrder Is Nothing Then
                'сервис зарегестрирован - вызываем
                If Global.Service.clsApplicationTypes.DelegateStoreAddSampleToOrder.Invoke(OrderID, Me.oSampleNumber.GetEan13, FileNames, OptimizeImageWidth) Then
                    'образец добавлен. показать форму.

                Else
                    MsgBox("Невозможно добавить образец к предложению " + OrderID + ". Возможно образец уже есть в этом предложении.", MsgBoxStyle.Critical)

                End If

            End If
        End If

        Dim _param As Object = {OrderID}
        Dim _fm As Form
        'по запросу выполняем вызов из сервиса
        'если делегата нет, то сервис недоступен
        If Not Global.Service.clsApplicationTypes.DelegateStoreApplicationForm(Service.clsApplicationTypes.emFormsList.fmOrders) Is Nothing Then
            'сервис зарегестрирован - вызываем
            _fm = Global.Service.clsApplicationTypes.DelegateStoreApplicationForm(Service.clsApplicationTypes.emFormsList.fmOrders).Invoke(_param)
            If _fm Is Nothing Then
                MsgBox("форма заказа " & OrderID & " не может быть показана.", MsgBoxStyle.Critical)
            Else
                'показать форму
                _fm.ShowDialog()
                Return True

            End If
        Else
            MsgBox("форма заказа " & OrderID & " не может быть показана. Нет прав доступа.", MsgBoxStyle.Critical)
        End If

        Return False



    End Function
    Private Sub btSearchInfo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles btSearchInfo.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            'цифра
            'очистить поле и начать ввод
            Me.tbSampleNumber.Text = e.KeyChar.ToString
            Me.tbSampleNumber.Focus()
            Me.tbSampleNumber.SelectionStart = 1
        End If
    End Sub



    Private Sub fmSampleInfo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            'цифра
            'очистить поле и начать ввод
            Me.tbSampleNumber.Text = e.KeyChar.ToString
            Me.tbSampleNumber.Focus()
        End If
    End Sub


    Private Sub DataGridView2_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView2.CellContentDoubleClick
        'запустить форму заказа
        Dim _orderID As String
        Select Case Me.DataGridView2.Columns(e.ColumnIndex).DataPropertyName
            Case "OrderID"
                _orderID = Trim(Me.DataGridView2.Item(e.ColumnIndex, e.RowIndex).Value.ToString())
                'вызвать форму заказа
                Me.ShowDialogfmOrder(_orderID, False)
        End Select

    End Sub

    Private Sub btCopyNumber_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCopyNumber.Click

        If Not Me.oSampleNumber Is Nothing Then
            '------------------
            Dim _data As String = Me.oSampleNumber.EAN13p36TT
            Try
                My.Computer.Clipboard.Clear()
                My.Computer.Clipboard.SetText(_data)
            Catch ex As Exception
                MsgBox("Ошибка при помещении данных в буфер обмена.", vbCritical)
            End Try
            '-----------------
        Else
            MsgBox("Не задан номер!", vbCritical)
        End If

    End Sub
    ''' <summary>
    ''' закрыть popup форму после срабатывания таймера
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If Not oActiveImagePopUp Is Nothing Then
            oActiveImagePopUp.Close()
        End If

        Timer1.Stop()
    End Sub





    Private Sub RTBSampleData_Enter(sender As Object, e As System.EventArgs) Handles RTBSampleData.Enter
        If Me.RTBSampleData.Text.Length > 0 Then
            '------------------
            Dim _data As String = Me.RTBSampleData.Text
            Try
                My.Computer.Clipboard.Clear()
                My.Computer.Clipboard.SetText(_data)
            Catch ex As Exception
                MsgBox("Ошибка при помещении данных в буфер обмена.", vbCritical)
            End Try
            '-----------------
            MsgBox("Данные скопированы", vbInformation)
        End If
    End Sub
    ''' <summary>
    ''' вернет
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetSelectedPhotos() As List(Of String)
        '-----фото
        'получить коллекцию имен отмеченных файлов
        'создать список отмеченных изображений
        Dim _SelectedImgColl As New List(Of String)

        'здесь посмотрим выделенные фото
        For Each _tmp As ListViewItem In Me.imgLwPhoto.CheckedItems
            _SelectedImgColl.Add(_tmp.Name)
        Next

        If _SelectedImgColl.Count = 0 Then
            'будут скопированы все фото
            Select Case MsgBox("Не выделено ни одной фото. Выделить все?", MsgBoxStyle.YesNo)
                Case MsgBoxResult.Yes
                    For Each _tmp As ListViewItem In Me.imgLwPhoto.Items
                        _tmp.Checked = True
                        _SelectedImgColl.Add(_tmp.Name)
                    Next
                    Me.imgLwPhoto.Refresh()
                Case MsgBoxResult.No
                    'откат
                    Return Nothing
            End Select
        End If
        Return _SelectedImgColl
    End Function



    Private Sub btCopyToFolder_Click(sender As System.Object, e As System.EventArgs) Handles btCopyToFolder.Click
        Dim _linkedsource = Me.lbLinkedSources.SelectedItem
        'Dim _templateName As String = Me.lbTemplates.SelectedItem

        If _linkedsource Is Nothing Then
            MsgBox("Следует выбрать устройство привязки фото!", vbCritical)
            Return
        End If

        Dim _selPhoto = GetSelectedPhotos()
        If _selPhoto Is Nothing Then Return

        Dim _sp As New SplashScreen1
        _sp.Show()
        _sp.Refresh()

        clsApplicationTypes.CreateFolderForSampleWithImages(Me.oSampleNumber, _linkedsource, _selPhoto, , Me.cbxRepalceImages.Checked)
        _sp.Close()
    End Sub


    Private Sub cbxRemoteConnections_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles cbxRemoteConnections.CheckedChanged
        Call btSearchInfo_Click(sender, e)
    End Sub

    Private Sub cbSourcesList_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbSourcesList.SelectedIndexChanged
        Me.ShowPhotos(Me.oSampleNumber)
    End Sub
    Private ocurrentculture As Globalization.CultureInfo
    Private Sub RbEnglish_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RbEnglish.CheckedChanged
        RTBSampleData.Text = Me.GetDescriptionByCulture(clsApplicationTypes.EnglishCulture)
        Me.lbCurrentCulture.Text = "Текущий язык английский"
        ocurrentculture = clsApplicationTypes.EnglishCulture
    End Sub

    Private Sub rbRussian_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbRussian.CheckedChanged
        RTBSampleData.Text = Me.GetDescriptionByCulture(clsApplicationTypes.RussianCulture)
        Me.lbCurrentCulture.Text = "Текущий язык русский"
        ocurrentculture = clsApplicationTypes.RussianCulture

    End Sub

    Private Sub btSelectAll_Click(sender As System.Object, e As System.EventArgs) Handles btSelectAll.Click
        For Each _tmp As Windows.Forms.ListViewItem In Me.imgLwPhoto.Items
            _tmp.Checked = True
        Next
    End Sub
    ''' <summary>
    ''' создает устройство для записи файлов.Запоминает последнюю выбранную папку
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CreateFreeFolderSource() As clsFilesSources

        'выбрать папку для сохранения
        Static _pathTo As String
        'Dim _ToSource As clsFilesSources
        Dim _fd As New Windows.Forms.FolderBrowserDialog
        With _fd
            If _pathTo = "" Then
                If My.Settings.FreeFolderPath = "" Then
                    .RootFolder = Environment.SpecialFolder.MyComputer
                ElseIf Not IO.Directory.Exists(My.Settings.FreeFolderPath) Then
                    .RootFolder = Environment.SpecialFolder.MyComputer
                Else
                    .SelectedPath = My.Settings.FreeFolderPath
                End If
            Else
                .SelectedPath = _pathTo
            End If
            .Description = "Укажите путь, куда копировать инфо. Папка с номером будет создана."
            .ShowNewFolderButton = True
        End With
        Select Case _fd.ShowDialog(Me)
            Case Windows.Forms.DialogResult.OK
                _pathTo = _fd.SelectedPath
                If Not _pathTo = My.Settings.FreeFolderPath Then
                    My.Settings.FreeFolderPath = _pathTo
                    My.Settings.Save()
                End If
            Case Windows.Forms.DialogResult.Cancel
                Return Nothing
            Case Else
                Return Nothing
        End Select
        Dim _numberedfolder As String = ""
        If Me.oSampleNumber Is Nothing Then
            _numberedfolder = _pathTo
        Else
            _numberedfolder = IO.Path.Combine(_pathTo, Me.oSampleNumber.ShotCode)
        End If

        Return clsFilesSources.CreateInstance(clsFilesSources.emSources.FreeFolder, , , _numberedfolder, True)
    End Function

    ''' <summary>
    ''' подготовка к записи файла образца по шаблону
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btCreateByTemplate_Click(sender As System.Object, e As System.EventArgs) Handles btCreateByTemplate.Click
        Me.btCopyToFolder_Click(sender, e)
        Me.btCopyByTemplate_Click(sender, e)
    End Sub

    Private oLinkedBinding As New List(Of clsFilesSources)

    ''' <summary>
    '''createFree запросит путь к файловому устройстве
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadSources(AddFree As Boolean, Optional ClearAll As Boolean = False)
        'If Not Me.oSampleNumber Is Nothing Then
        '    'заменить на доступные
        '    'load sources list
        '    Me.lbLinkedSources.Items.Clear()
        '    Me.lbLinkedSources.Items.AddRange(Service.clsApplicationTypes.SamplePhotoObject.GetSourcesList(Me.oSampleNumber, Me.cbxRemoteConnections.Checked).ToArray)
        'End If
        If ClearAll Then
            Me.lbLinkedSources.DataSource = Nothing
            oLinkedBinding.Clear()
        End If
        Dim _index As Integer = 0
        If AddFree Then
            'добавит free folder
            Dim _free = Me.CreateFreeFolderSource
            ' _free.ToString()
            oLinkedBinding.Add(_free)
            _index = oLinkedBinding.Count - 1
        Else
            Me.lbLinkedSources.DataSource = Nothing
            oLinkedBinding.Clear()
            oLinkedBinding.Add(Service.clsFilesSources.Arhive)
            oLinkedBinding.Add(Service.clsFilesSources.AZURE)
        End If
        Me.lbLinkedSources.DataSource = Nothing
        Me.lbLinkedSources.DataSource = oLinkedBinding
        Me.lbLinkedSources.DisplayMember = "GetStringForUser"
        '     Me.lbLinkedSources.SelectedIndex = _index - 1
    End Sub


    Private Sub LoadTemplates()
        Me.lbTemplates.Items.Clear()
        Dim _tlist As String()
        If Not clsApplicationTypes.DelegateStoreGetTemplatesList Is Nothing Then
            'сервис зарегестрирован - вызываем
            _tlist = clsApplicationTypes.DelegateStoreGetTemplatesList().Invoke()
        Else
            Exit Sub
        End If
        Me.lbTemplates.Items.AddRange(_tlist)
        If Not _tlist.Count > 3 Then
            Me.lbTemplates.Focus()
            Me.lbTemplates.SelectedIndex = 3
        End If
    End Sub



    Private Sub btCopyByTemplate_Click(sender As System.Object, e As System.EventArgs) Handles btCopyByTemplate.Click
        Dim _LinkedSource As clsFilesSources = Me.lbLinkedSources.SelectedItem
        Dim _templateName As String = Me.lbTemplates.SelectedItem
        Dim _exendedMapLink As String = ""
        If _LinkedSource Is Nothing Then
            MsgBox("Следует выбрать устройство привязки фото!", vbCritical)
            Return
        End If

        '---------------язык
        Dim _culture As System.Globalization.CultureInfo = clsApplicationTypes.EnglishCulture
        If Me.rbRussian.Checked Then
            _culture = clsApplicationTypes.RussianCulture
        End If
        '-----------------XML
        If Me.cbxExtendedOutput.Checked Then
            'загрузить форму с данными xml из БД
            'проверка наличия XML файла образца
            Dim _result As Integer = -1
            Dim _sdo = clsApplicationTypes.SampleDataObject.GetSampleOnSale(oSampleNumber, _result)
            Dim _param As String = ""
            If Me.cbxRewritefile.Checked = False And (Not _sdo Is Nothing) AndAlso Not (_sdo.SampleXMLFile = "") Then
                'передать в форму уже имеющийся файл
                _param = _sdo.SampleXMLFile

            Else
                'сгенерить начальное описание
                Dim _selPhoto = GetSelectedPhotos()
                If _selPhoto Is Nothing Then Return

                If Not clsApplicationTypes.SamplePhotoObject.HasImages(Me.oSampleNumber, _LinkedSource) Then
                    Select Case MsgBox("На выбранном устройстве нет фото, скопировать?", vbQuestion)
                        Case MsgBoxResult.Yes
                            Me.btCopyToFolder_Click(sender, e)
                    End Select
                End If

                If clsApplicationTypes.CreateFolderForSampleWithDataFile(Me.oSampleNumber, _LinkedSource, _selPhoto, , _culture, False, _exendedMapLink) Then
                    _param = _exendedMapLink
                Else
                    MsgBox("Не удалось сгенерировать XML для образца", vbCritical)
                    Return
                End If

            End If
            Me.cbxRewritefile.Checked = False
            'покажем форму
            Dim _fm = clsApplicationTypes.DelegateStoreApplicationForm(clsApplicationTypes.emFormsList.fmCatalogSample).Invoke({_param})
            If Not _fm Is Nothing Then
                _fm.StartPosition = FormStartPosition.CenterScreen
                _fm.ShowDialog()
                Dim _currsm = CType(_fm, fmcatalog).CurrentSample
                'тут необходимо сохранить XML в БД
                _result = -1
                _sdo = clsApplicationTypes.SampleDataObject.GetSampleOnSale(Me.oSampleNumber, _result, CreateIfNotExist:=True)
                If _result > 0 Then
                    _sdo.SampleXMLFile = _currsm.GetXML
                    If clsApplicationTypes.SampleDataObject.SaveReadySampleContext() > 0 Then
                        MsgBox("Файл описания сохранен в БД", vbInformation)
                    Else
                        MsgBox("Невозможно сохранить XML в БД. Неудачная попытка вернуть обьект серверу.", vbCritical)
                        Return
                    End If
                Else
                    MsgBox("Невозможно сохранить XML в БД. Неудачная попытка запросить обьект с сервера.", vbCritical)
                    Return
                End If
            Else
                MsgBox("Не удалось передать форме fmCatalogSample параметр.", vbCritical)
                Return
            End If

        Else
            'пишем HTML
            Dim _selPhoto = GetSelectedPhotos()
            If _selPhoto Is Nothing Then Return

            If Not clsApplicationTypes.SamplePhotoObject.HasImages(Me.oSampleNumber, _LinkedSource) Then
                Select Case MsgBox("На выбранном устройстве нет фото, скопировать?", vbQuestion)
                    Case MsgBoxResult.Yes
                        Me.btCopyToFolder_Click(sender, e)
                End Select
            End If
            If clsApplicationTypes.CreateFolderForSampleWithDataFile(Me.oSampleNumber, _LinkedSource, _selPhoto, _templateName, _culture) Then
                MsgBox("Файлы скопированы без настройки вывода (в БД не записано)", MsgBoxStyle.Information)
            End If
        End If


    End Sub

    'Private oTemplateManager As clsTemplateManager

    Private Sub btAddTemplate_Click(sender As System.Object, e As System.EventArgs) Handles btAddTemplate.Click
        'Dim _fm = New Windows.Forms.OpenFileDialog
        'With _fm
        '    .DefaultExt = "xslt"
        '    .Multiselect = False
        '    .Title = "выбрать файл шаблона"
        'End With

        'Select Case _fm.ShowDialog
        '    Case Windows.Forms.DialogResult.OK
        '        'If oTemplateManager Is Nothing Then
        '        '    oTemplateManager = New clsTemplateManager
        '        'End If
        '        'Dim _obj = New Trilbone.clsTemplateManager
        '        Dim _name = InputBox("введите имя шаблона ", , IO.Path.GetFileName(_fm.FileName))
        '        AddTemplate(_name, True, _fm.FileName)
        '        lbTemplates.Items.Add(_name)
        'End Select

    End Sub



    Private Sub btUnselectAll_Click(sender As System.Object, e As System.EventArgs) Handles btUnselectAll.Click
        For Each _tmp As Windows.Forms.ListViewItem In Me.imgLwPhoto.Items
            _tmp.Checked = False
        Next
    End Sub
    Private oSampleListManager As Service.clsSampleListManager

    Private oRegisterFlag As Boolean
    Private Sub btAddInList_Click(sender As System.Object, e As System.EventArgs)
        If Not oRegisterFlag Then
            If Not clsApplicationTypes.RegisterFormToFormSampleList(Me) Then
                MsgBox("Не могу показать форму списков!", MsgBoxStyle.Critical)
            Else
                oRegisterFlag = True
            End If
        End If

        ' RaiseEvent SampleNumberAccepted(Me, New clsWriteSampleToListEventsArg With {.SampleNumber = oSampleNumber, .AutoWrite = cbAutoList.Checked})
    End Sub



    Private Sub btCopyName_Click(sender As Object, e As EventArgs) Handles btCopyName.Click
        If Not Me.tbName.Text = "" Then
            Dim _tmpNum As String = Trim(Me.tbName.Text)
            '------------------
            Dim _data As String = _tmpNum
            Try
                My.Computer.Clipboard.Clear()
                My.Computer.Clipboard.SetText(_data)
            Catch ex As Exception
                MsgBox("Ошибка при помещении данных в буфер обмена.", vbCritical)
            End Try
            '-----------------
        End If

    End Sub



    'Private Sub cbAutoList_CheckedChanged(sender As Object, e As EventArgs)
    '    If cbAutoList.Checked Then
    '        btAddInList_Click(sender, e)
    '    End If
    'End Sub


    Private Sub tbSampleNumber_TextChanged(sender As Object, e As EventArgs) Handles tbSampleNumber.TextChanged

    End Sub

    Private Sub btCopyArticul_Click(sender As System.Object, e As System.EventArgs) Handles btCopyArticul.Click

        If Not Me.oSampleNumber Is Nothing Then
            '------------------
            Dim _data As String = Me.oSampleNumber.ShotCode
            Try
                My.Computer.Clipboard.Clear()
                My.Computer.Clipboard.SetText(_data)
            Catch ex As Exception
                MsgBox("Ошибка при помещении данных в буфер обмена.", vbCritical)
            End Try
            '-----------------
        Else
            MsgBox("Не задан номер!", vbCritical)
        End If

    End Sub

    Private Sub fmSampleInfo_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'заполнить шаблоны
        ' btCreateByTemplate_Click(sender, e)
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        If Not Me.oSampleNumber Is Nothing Then
            '------------------
            Dim _data As String = Me.oSampleNumber.EAN13
            Try
                My.Computer.Clipboard.Clear()
                My.Computer.Clipboard.SetText(_data)
            Catch ex As Exception
                MsgBox("Ошибка при помещении данных в буфер обмена.", vbCritical)
            End Try
            '-----------------
        Else
            MsgBox("Не задан номер!", vbCritical)
        End If
    End Sub



    Private Sub imgLwPhoto_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles imgLwPhoto.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim _item = sender.GetItemAt(e.X, e.Y)
            If Not _item Is Nothing Then
                Call Me.ShowImageForm(_item.Name, True)
            End If
        End If
    End Sub

    Private odragBoxFromMouseDown As Rectangle

    Private Sub imgLwPhoto_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles imgLwPhoto.MouseDown
        ' Remember the point where the mouse down occurred. The DragSize indicates
        ' the size that the mouse can move before a drag event should be started.                
        Dim dragSize As Size = SystemInformation.DragSize
        Dim _add As New Size(0, 0)
        dragSize = Size.Add(dragSize, _add)
        ' Create a rectangle using the DragSize, with the mouse position being
        ' at the center of the rectangle.
        odragBoxFromMouseDown = New Rectangle(New Point(e.X - (dragSize.Width / 2), _
                                                        e.Y - (dragSize.Height / 2)), dragSize)
    End Sub
    Private oIndex As Integer = 0

    Private Sub imgLwPhoto_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles imgLwPhoto.MouseMove
        If ((e.Button And MouseButtons.Left) = MouseButtons.Left) Then
            If (Rectangle.op_Inequality(odragBoxFromMouseDown, Rectangle.Empty) And _
       Not odragBoxFromMouseDown.Contains(e.X, e.Y)) Then
                'мыша вышла за пределы прямоугольника
                'если ведем по вертикали, тогда прокрутка, если по горизонту, тогда драгдроп
                Dim dx = Math.Abs(e.X - odragBoxFromMouseDown.X)
                Dim dy = Math.Abs(e.Y - odragBoxFromMouseDown.Y)
                If dx > dy Then
                    'перемещение горизонт
                    Dim _item = sender.GetItemAt(e.X, e.Y)

                    If Not _item Is Nothing Then
                        'найдем путь к обьекту
                        Dim _source = clsFilesSources.CreateInstance(Service.clsFilesSources.emSources.Arhive)
                        Dim _uri = Service.clsApplicationTypes.SamplePhotoObject.GetImagesURI(Me.oSampleNumber, _source, {_item.Name})
                        If _uri.Length > 0 Then
                            Dim _obg As New DataObject
                            Dim _coll As New Collections.Specialized.StringCollection
                            _coll.Add(_uri(0).LocalPath)
                            With _obg
                                .SetFileDropList(_coll)
                            End With

                            ' Proceed with the drag-and-drop, passing in the list item.                    
                            Dim dropEffect As DragDropEffects = sender.DoDragDrop(_obg, DragDropEffects.Copy)

                        End If
                    End If

                Else
                    'прокрутка
                    If e.Y > odragBoxFromMouseDown.Y Then
                        'точку ведем вниз
                        'определим верхний видимый индекс

                        Dim _upindex = oIndex
                        If _upindex > 1 Then
                            _upindex = _upindex - 4
                            If _upindex < 0 Then _upindex = 0
                            oIndex = _upindex
                            imgLwPhoto.EnsureVisible(_upindex)
                        End If
                        odragBoxFromMouseDown = Rectangle.Empty
                    Else
                        'точку ведем вверх
                        Dim _upindex = oIndex
                        _upindex += 4
                        If _upindex > imgLwPhoto.Items.Count - 1 Then _upindex = imgLwPhoto.Items.Count - 2
                        oIndex = _upindex
                        imgLwPhoto.EnsureVisible(_upindex)
                        odragBoxFromMouseDown = Rectangle.Empty
                    End If
                End If



            End If

            '     If (Rectangle.op_Inequality(odragBoxFromMouseDown, Rectangle.Empty) And _
            '         Not sender.ClientRectangle.Contains(e.X, e.Y)) Then
            '         Dim _item = sender.GetItemAt(e.X, e.Y)

            '         If Not _item Is Nothing Then
            '             'найдем путь к обьекту
            '             Dim _source = clsFilesSources.CreateInstance(Service.clsFilesSources.emSources.Arhive)
            '             Dim _uri = Service.clsApplicationTypes.SamplePhotoObject.GetImagesURI(Me.oSampleNumber, _source, {_item.Name})
            '             If _uri.Length > 0 Then
            '                 Dim _obg As New DataObject
            '                 Dim _coll As New Collections.Specialized.StringCollection
            '                 _coll.Add(_uri(0).LocalPath)
            '                 With _obg
            '                     .SetFileDropList(_coll)
            '                 End With

            '                 ' Proceed with the drag-and-drop, passing in the list item.                    
            '                 Dim dropEffect As DragDropEffects = sender.DoDragDrop(_obg, DragDropEffects.Copy)

            '             End If
            '         End If
            '     ElseIf (Rectangle.op_Inequality(odragBoxFromMouseDown, Rectangle.Empty) And _
            'Not odragBoxFromMouseDown.Contains(e.X, e.Y)) Then
            '         If e.Y > odragBoxFromMouseDown.Y Then
            '             'точку ведем вниз
            '             'определим верхний видимый индекс

            '             Dim _upindex = oIndex
            '             If _upindex > 1 Then
            '                 _upindex = _upindex - 2
            '                 If _upindex < 0 Then _upindex = 0
            '                 oIndex = _upindex
            '                 imgLwPhoto.EnsureVisible(_upindex)
            '             End If
            '             odragBoxFromMouseDown = Rectangle.Empty
            '         Else
            '             'точку ведем вверх
            '             Dim _upindex = oIndex
            '             _upindex += 2
            '             If _upindex > imgLwPhoto.Items.Count - 1 Then _upindex = imgLwPhoto.Items.Count - 1
            '             oIndex = _upindex
            '             imgLwPhoto.EnsureVisible(_upindex)
            '             odragBoxFromMouseDown = Rectangle.Empty
            '         End If
            '     End If

        End If
    End Sub

    Private Sub imgLwPhoto_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles imgLwPhoto.MouseUp
        ' Reset the drag rectangle when the mouse button is raised.
        odragBoxFromMouseDown = Rectangle.Empty
    End Sub


    Private Sub btGetMScatalog_Click(sender As System.Object, e As System.EventArgs) Handles btGetMScatalog.Click
        If Me.tbMSnumber.Text = "" Then Return
        Dim _sp As New SplashScreen1
        _sp.Show()
        _sp.Refresh()

        Me.lblMsOrder.Text = ""
        Me.lbSampleInMCOrder.DataSource = Nothing
        Dim _list As List(Of clsApplicationTypes.clsSampleNumber)
        Dim _customerName As String = ""
        'по запросу выполняем вызов из сервиса
        'если делегата нет, то сервис недоступен
        If Not clsApplicationTypes.DelegateStoreGetSampleListFromMS Is Nothing Then
            'сервис зарегестрирован - вызываем
            'надо добавить, если на требуемом устройстве нет фото, то скопировать из архива
            'надо добавить выбор шаблона для каталога
            _list = clsApplicationTypes.DelegateStoreGetSampleListFromMS().Invoke(Me.tbMSnumber.Text, _customerName)
        Else
            _sp.Close()
            MsgBox("Сервис MC недоступен", vbCritical) : Return
        End If
        _sp.Close()
        If Not _list.Count = 0 Then
            Me.lbSampleInMCOrder.DataSource = _list
            Me.lbSampleInMCOrder.DisplayMember = "ShotCode"
            Me.lblMsOrder.Text = _customerName
        Else
            MsgBox("Нет такого заказа или он пуст", vbCritical)
        End If

    End Sub

    Private Sub imgLwPhoto_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles imgLwPhoto.SelectedIndexChanged

    End Sub

    Private Sub lbSampleInMCOrder_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lbSampleInMCOrder.SelectedIndexChanged
        If Me.lbSampleInMCOrder.SelectedItem Is Nothing Then Return

        Dim _sn As clsApplicationTypes.clsSampleNumber = Me.lbSampleInMCOrder.SelectedItem

        'показать инфо об образце
        Me.tbSampleNumber.Text = _sn.ShotCode
        btSearchInfo_Click(sender, e)

    End Sub

    Private Sub btCreateCatalog_Click(sender As System.Object, e As System.EventArgs) Handles btCreateCatalog.Click
        If Me.lbSampleInMCOrder.Items.Count = 0 Then Return

        Dim _templateName As String = ""
        If Me.lbTemplates.SelectedIndex > -1 Then
            _templateName = Me.lbTemplates.SelectedItem
        End If

        Dim _LinkedSource As clsFilesSources = clsFilesSources.Arhive
        If Not Me.lbLinkedSources.SelectedItem Is Nothing Then
            _LinkedSource = Me.lbLinkedSources.SelectedItem
        End If

        Select Case MsgBox("Генерируем HTML для " & _LinkedSource.ToString() & ", используя шаблон " & _templateName & "?", vbYesNo)
            Case MsgBoxResult.No
                Return
        End Select


        'параметры каталога
        'создать обьект каталога
        Dim _titlestring As String = "Offer to " & Me.lblMsOrder.Text
        Select Case ocurrentculture.Name
            Case clsApplicationTypes.EnglishCulture.Name
                _titlestring = "Offer to " & Me.lblMsOrder.Text
            Case clsApplicationTypes.RussianCulture.Name
                _titlestring = "Предложение для: " & Me.lblMsOrder.Text
        End Select

        Dim _catalog As Service.Catalog.CATALOG = Service.Catalog.CATALOG.CreateInstance(Now(), Me.tbMSnumber.Text, _titlestring)


        '------------------------------------------------------------------------
        'добавить данные образцов
        For Each t As clsApplicationTypes.clsSampleNumber In Me.lbSampleInMCOrder.Items
            'проверка наличия XML файла образца
            Dim _result As Integer = -1
            Dim _sdo = clsApplicationTypes.SampleDataObject.GetSampleOnSale(t, _result)
            Dim _param As String = ""
            If (Not _sdo Is Nothing) AndAlso Not (_sdo.SampleXMLFile = "") Then
                'проверка устройства
                'Select Case _LinkedSource.Source
                '    Case Service.clsFilesSources.emSources.AZURE

                '    Case Else

                'End Select
                Dim _status As Integer = 0
                Dim _cs = CATALOGSAMPLE.ParseSample(_sdo.SampleXMLFile, _status)
                If _status > 0 Then
                    _catalog.AddSample(_cs)
                Else
                    'надо сделать образец
                    MsgBox("XML образца" & t.ShotCode & " не читается, надо сделать заново", vbCritical)
                    Me.lbSampleInMCOrder.SelectedItem = t
                    Return
                End If

            Else
                'надо сделать образец
                MsgBox("У образца" & t.ShotCode & "  нет XML. Надо сделать.", vbCritical)
                Me.lbSampleInMCOrder.SelectedItem = t
                Return
            End If
        Next
        'все ок в этой точке - показать каталог
        If Not _catalog Is Nothing Then
            Dim fm As New fmBrowser(_catalog.GetHTML(_templateName), _catalog.name, _catalog.title, ocurrentculture)
            fm.Show()
        End If
    End Sub

    Private Sub btAddSource_Click(sender As System.Object, e As System.EventArgs) Handles btAddSource.Click
        Me.LoadSources(True)
    End Sub

    Private Sub tbMSnumber_Enter(sender As Object, e As System.EventArgs) Handles tbMSnumber.Enter
        If sender.text.ToString.Length >= 3 Then
            sender.text = ""
        End If
    End Sub

    Private Sub tbMSnumber_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tbMSnumber.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Me.btGetMScatalog_Click(sender, e)
        End If

    End Sub

    Private Sub tbMSnumber_TextChanged(sender As System.Object, e As System.EventArgs) Handles tbMSnumber.TextChanged

    End Sub

    Private Sub btShowInBrowser_Click(sender As System.Object, e As System.EventArgs) Handles btShowInBrowser.Click
        Debug.Assert(Not Me.oSampleNumber Is Nothing, "Образец должен быть задан!!")
        If Me.lbTemplates.SelectedItem Is Nothing Then
            MsgBox("Следует выбрать шаблон!", vbCritical)
            Return
        End If

        'проверка наличия XML файла образца
        Dim _result As Integer = -1
        Dim _sdo = clsApplicationTypes.SampleDataObject.GetSampleOnSale(Me.oSampleNumber, _result)
        Dim _param As String = ""
        If (Not _sdo Is Nothing) AndAlso Not (_sdo.SampleXMLFile = "") Then
            Dim _status As Integer = 0
            Dim _cs = CATALOGSAMPLE.ParseSample(_sdo.SampleXMLFile, _status)
            If _status > 0 Then
                Dim _fm As New fmBrowser(_cs.GetTransform(emTemplateType.ByName, Me.lbTemplates.SelectedItem), Me.tbMSnumber.Text, Me.lblMsOrder.Text, ocurrentculture)
                _fm.Show()
            End If

        End If


    End Sub

    Private Sub lbSample_Click(sender As System.Object, e As System.EventArgs) Handles Label10.MouseClick
        clsOrderService.GetDigiKey.connect(Me.tbSampleNumber)
    End Sub



End Class