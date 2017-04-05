Imports RestMS_Client.MoySkladAPI
Imports System.Drawing.Printing
Imports Service
Imports System.Drawing.Imaging
Imports System.ComponentModel
Imports System.Linq
Imports Service.clsApplicationTypes

Public Class fmMoySklad

#Region "определения"
    Private oCurrentGood As clsMSGood
    Private oManager As clsMoyScladManager
    Private oLocations As List(Of clsGoodLocation)
    Private oCurrentCulture As Globalization.CultureInfo = clsApplicationTypes.EnglishCulture
    Private oCurrentLossGood As clsMSGood
    Private oNewGoodsCount As Integer = 0
    ''' <summary>
    ''' используется для отключения покраснения кнопки при новом товаре
    ''' </summary>
    ''' <remarks></remarks>
    Private oWillNewGoodFlag As Boolean = False
    Private oRedKeyOff As Boolean = False
    Private oSearchGoodDirectRequest As Boolean = False
    'Private oLocateGoodComplete As Boolean
    Private WithEvents oBackgroundWorkerMC As New System.ComponentModel.BackgroundWorker
    Private oLabelImageList As List(Of KeyValuePair(Of Image, SizeF))
    ''' <summary>
    ''' флаг успешного создания карточки товара
    ''' </summary>
    ''' <remarks></remarks>
    Private oCreateGoodMapComplete As Boolean
    ''' <summary>
    ''' при возникновении события смены текущего bs_Curr_slot_location будет добавлена 1 шт
    ''' </summary>
    ''' <remarks></remarks>
    Private oNeedAddPcs As Boolean
    Private oOldLocations As List(Of clsGoodLocation)
    Private oFixSeries As String
    Private oFixedStoreIndex As Integer
    Private oFixedCurrencyIndex As Integer
    Private oNeedResetPrinter As Boolean = False
    ''' <summary>
    ''' key=groupname  value=filepath
    ''' </summary>
    ''' <remarks></remarks>
    Private oTreeFilesList As New List(Of KeyValuePair(Of String, String))
    Dim oTreeBindingSource As New BindingSource
    Private oSplashscreen1 As SplashScreen1
    Private oBuyToolTip As New ToolTip
    Private oCurrentBuyCurrency As MoySkladAPI.currency
    Private oCurrentRetailCurrency As MoySkladAPI.currency
    Private oCurrentInvoceCurrency As MoySkladAPI.currency
    Private oCurrentBuyCostCurrecy As MoySkladAPI.currency
    Dim oSampleNumber As clsApplicationTypes.clsSampleNumber
    Dim oFixedSeries As String


    Private Property CheckImages As System.Func(Of String, Integer)
    ''' <summary>
    ''' хранит текущий список товаров на перемещение
    ''' </summary>
    ''' <remarks></remarks>
    Private oSlotMoveList As List(Of iMoySkladDataProvider.strGoodMapQty)
    Private oCurrentPrices As ucPriceCalc.clsPriceData
#End Region

#Region "конструкторы"
    Friend Sub New(manager As clsMoyScladManager)
        ' Этот вызов является обязательным для конструктора.
        InitializeComponent()
        Me.oManager = manager
        init()
    End Sub
    ''' <summary>
    ''' внешний инициализатор формы образцом
    ''' </summary>
    ''' <param name="SampleNumber"></param>
    ''' <param name="Articul"></param>
    ''' <param name="SampleName"></param>
    ''' <param name="Barcode"></param>
    ''' <param name="Prices"></param>
    ''' <param name="Currency"></param>
    ''' <remarks></remarks>
    Friend Sub New(manager As clsMoyScladManager, SampleNumber As String, SampleName As String, Optional Articul As String = "", Optional Barcode As String = "", Optional Prices As Dictionary(Of String, Decimal) = Nothing, Optional Currency As String = "")
        InitializeComponent()
        Me.oManager = manager
        Dim _new = New clsMSGood With {.Code = SampleNumber, .Articul = Articul, .Name = SampleName, .Barcode = Barcode}
        oCurrentGood = _new
        init()
        CurrentGoodRequest()
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="good"></param>
    ''' <remarks></remarks>
    Friend Sub New(manager As clsMoyScladManager, good As MoySkladAPI.good)
        InitializeComponent()
        Me.oManager = manager
        Dim _new = clsMSGood.CreateInstance(good)
        oCurrentGood = _new
        init()
        CurrentGoodRequest()
    End Sub

#End Region

#Region "Внешние функции и инициализация"
    ''' <summary>
    ''' загружает образец для поиска, directWeight = вес, directSizeInCm=размер, NotHasPhoto=флаг отсутствия фото
    ''' </summary>
    ''' <param name="SampleNumber"></param>
    ''' <param name="SampleName"></param>
    ''' <param name="Articul"></param>
    ''' <param name="Barcode"></param>
    ''' <param name="Prices"></param>
    ''' <param name="Currency"></param>
    ''' <remarks></remarks>
    Public Sub SetSample(SampleNumber As String, SampleName As String, Optional FirstFossilNumber As String = "", Optional Articul As String = "", Optional Barcode As String = "", Optional Prices As Dictionary(Of String, Decimal) = Nothing, Optional Currency As String = "", Optional directWeight As Decimal = 0, Optional directSizeInCm As Decimal = 0, Optional NotHasPhoto As Integer = -1)
        ClearAll()
        Me.ControlBox = False
        oCurrentGood = New clsMSGood With {.Code = SampleNumber, .Articul = Articul, .Name = SampleName, .Barcode = Barcode, .RawNumber = FirstFossilNumber}
        oCurrentGood.Weight = directWeight
        oCurrentGood.size = directSizeInCm
        oCurrentGood.NotHasPhoto = NotHasPhoto
        CurrentGoodRequest()
    End Sub
    ''' <summary>
    ''' установка разрешений
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub fmMoySklad_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        If oManager Is Nothing Then Me.Close() : Return
        Me.tbNumber.Focus()

        If clsApplicationTypes.GetAccess("служебные функции") Then
            Me.btServiceForm.Enabled = True
        End If

        If Not clsApplicationTypes.GetAccess("вкладки цен и аукционов") Then
            Me.tbCtlMain.TabPages.Remove(tpAuctions)
            Me.tbCtlMain.TabPages.Remove(tpPrices)
            Me.cbPrintCurrency.Enabled = False
        End If

        If Not clsApplicationTypes.GetAccess("Доступ к заказам") Then
            Me.tbCtlMain.TabPages.Remove(tpInfo)
        End If

        If Not clsApplicationTypes.GetAccess("препарация и детали") Then
            Me.tbCtlMain.TabPages.Remove(tpPreparation)
        End If
        If Not clsApplicationTypes.GetAccess("ячейки") Then
            Me.tbCtlMain.TabPages.Remove(Me.tpWareCells)
        End If
        If Not clsApplicationTypes.GetAccess("рассчет лота") Then
            Me.tbCtlMain.TabPages.Remove(Me.tpLotEnterTabPage)
        End If
        If Not clsApplicationTypes.GetAccess("настройки") Then
            Me.btOption.Enabled = False
            Me.btServiceForm.Enabled = False
            Me.btCheckCodes.Enabled = False
        End If
        '--------------------
        If Not clsApplicationTypes.GetAccess("блокировка изменения номера") Then
            Me.tbNumber.Enabled = True
            Me.btMoveToArticul.Enabled = False
            Me.btMoveToCode.Enabled = False
            Me.tbArticul.Enabled = False
            Me.tbBarCode.Enabled = False
        Else
            Me.btMoveToArticul.Enabled = True
            Me.btMoveToCode.Enabled = True
            Me.tbNumber.Enabled = True
            Me.tbArticul.Enabled = True
            Me.tbBarCode.Enabled = True
        End If
    End Sub


    Friend Sub init()
        'разрешение для пользователей ниже

        Me.oSplashscreen1 = New SplashScreen1
        Me.oSplashscreen1.StartPosition = FormStartPosition.CenterScreen

        'показат сплеш
        If oSplashscreen1.Visible = False Then
            oSplashscreen1.Show()
            Application.DoEvents()
        End If

        ' инициализирует основной обьект МС
        Me.oManager = clsRestMS_service.CreateManager("admin@trilbone", "illaenus2012")

        If Me.oManager Is Nothing Then
            Me.oSplashscreen1.Hide()
            Me.Close()
            MsgBox("Склад не подключен.", vbInformation)
            Return
        End If

        Me.rbRussian.Checked = True

        Me.oTreeBindingSource.DataSource = Me.oTreeFilesList
        Me.cbMaterial.DataSource = Me.oTreeBindingSource
        Me.cbMaterial.DisplayMember = "Key"

        With Me.cbDBNames
            .AutoCompleteMode = AutoCompleteMode.SuggestAppend
            .AutoCompleteSource = AutoCompleteSource.ListItems
            'добавть имена из списка/ потом данные из привязок
            .Items.AddRange(clsApplicationTypes.MyTreesSystematicaNames.ToArray)
        End With

        'делегаты
        Me.CheckImages = Service.clsApplicationTypes.DelegatStoreCheckImages
        If Not oCurrentGood Is Nothing Then
            Me.bsCurrentGood.DataSource = oCurrentGood
        End If

        'привязка сканера
        Me.Tag = Me.tbNumber
        AddHandler Me.KeyPress, AddressOf clsApplicationTypes.Control_KeyPress

        'Me.BuyPriceTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsCurrentGood, "Good.buyPrice", True))
        'Me.BuyCurrencyUuidTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsCurrentGood, "Good.buyCurrencyUuid", True))
        'Me.SalePriceTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsCurrentGood, "Good.salePrice", True))
        'Me.SaleCurrencyUuidTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsCurrentGood, "Good.saleCurrencyUuid", True))

        Me.cbTargetStores.DisplayMember = "Name"
        Me.ToolStripStatusLabel1.Text = ""

        'операции с товаром
        Me.btAddGoodToWare.Enabled = False
        Me.btCreateGood.Enabled = False

        Me.StartPosition = FormStartPosition.CenterScreen


        'валюты
        Dim _list(oManager.CurrencyList.Count - 1) As MoySkladAPI.currency
        oManager.CurrencyList.CopyTo(_list)
        Me.cbRetailTargetCurrency.DisplayMember = "name"
        Me.cbRetailTargetCurrency.ValueMember = "uuid"
        Me.cbRetailTargetCurrency.DataSource = _list.ToList
        Me.cbRetailTargetCurrency.SelectedIndex = -1

        'cbInvoceCurrency
        Dim _list4(oManager.CurrencyList.Count - 1) As MoySkladAPI.currency
        oManager.CurrencyList.CopyTo(_list4)
        Me.cbInvoceCurrency.DisplayMember = "name"
        Me.cbInvoceCurrency.ValueMember = "uuid"
        Me.cbInvoceCurrency.DataSource = _list4.ToList
        Me.cbInvoceCurrency.SelectedIndex = -1

        ''инвойс в списке цен
        'Dim _list41(oManager.CurrencyList.Count - 1) As MoySkladAPI.currency
        'oManager.CurrencyList.CopyTo(_list41)
        'Me.CR8cb.DisplayMember = "name"
        'Me.CR8cb.ValueMember = "uuid"
        'Me.CR8cb.DataSource = _list4.ToList
        'Me.CR8cb.SelectedIndex = -1

        Dim _list2(oManager.CurrencyList.Count - 1) As MoySkladAPI.currency
        oManager.CurrencyList.CopyTo(_list2)
        Me.cbBuyTargetCurrency.DisplayMember = "name"
        Me.cbBuyTargetCurrency.ValueMember = "uuid"
        Me.cbBuyTargetCurrency.DataSource = _list2.ToList
        Me.cbBuyTargetCurrency.SelectedIndex = -1

        ''валюта печати
        'Dim _list3(oManager.CurrencyList.Count - 1) As MoySkladAPI.currency
        'oManager.CurrencyList.CopyTo(_list3)
        'Me.cbPrintCurrency.DisplayMember = "name"
        'Me.cbPrintCurrency.ValueMember = "uuid"
        'Me.cbPrintCurrency.DataSource = _list2.ToList
        Me.cbPrintCurrency.SelectedIndex = 0


        'Dim _list3(oManager.CurrencyList.Count - 1) As MoySkladAPI.currency
        'oManager.CurrencyList.CopyTo(_list3)
        'Me.cbBuyCostCurrecy.DisplayMember = "name"
        'Me.cbBuyCostCurrecy.ValueMember = "uuid"
        'Me.cbBuyCostCurrecy.DataSource = _list.ToList
        'Me.cbBuyCostCurrecy.SelectedIndex = -1


        'список складов 
        Me.oLocations = oManager.LocationList
        Me.bs_Curr_stor_location.DataSource = Me.oLocations

        ''список аукционов
        'Me.lbAuctions.DataSource = oManager.AuctionList
        'Me.lbAuctions.DisplayMember = "name"
        'Me.lbAuctions.ValueMember = "metuuid"

        'Me.lbAuctions.Enabled = False
        'Me.btAuctionCompleted.Enabled = False
        'Me.btAuctionUncompleted.Enabled = False
        'Me.lbAuctionStatus.Text = "товар не выбран"


        ''вкладка(аукционов)
        ''Me.cbAuStoreList.DataSource = oManager.WarehouseList
        ''список(аукционов)
        ''Me.cbAuAuctionList.DataSource = oManager.AuctionList
        ''Me.cbAuAuctionList.DisplayMember = "name"
        ''Me.cbAuAuctionList.ValueMember = "metuuid"

        'еденицы измерения
        Me.cbUom.DataSource = oManager.UomList
        Me.cbUom.DisplayMember = "name"
        Me.cbUom.SelectedIndex = -1



        'загрузка препараторов
        With Me.cbMainPreparator
            .DataSource = oManager.TrilboneWokersList
            .ValueMember = "uuid"
            .DisplayMember = "name"
        End With
        With Me.cbPreparatorAdd
            .DataSource = oManager.TrilboneWokersList
            .ValueMember = "uuid"
            .DisplayMember = "name"
        End With

        'загрузка экспедиций
        With Me.cbExpedition
            .DataSource = oManager.ExpeditionsList
            .ValueMember = "uuid"
            .DisplayMember = "name"
        End With

        'загрузка списка схем
        With Me.cbSchemePrice
            .DataSource = oManager.SchemeList
            .ValueMember = "uuid"
            .DisplayMember = "name"
        End With

        'загрузка поставщиков
        With Me.cbSupplier
            .DataSource = oManager.CustomerList(False)
            .ValueMember = "uuid"
            .DisplayMember = "name"
        End With

        'загрузка деталей допрепарации
        With Me.cbRePrepDetails
            .DataSource = oManager.RePrepDetailsList
            .ValueMember = "uuid"
            .DisplayMember = "name"
        End With
        '=============================
        'разрешение для пользователей
        'пользователи
        If clsApplicationTypes.GetAccess("цена инвойса и закупки") Then
            Me.cbxSetBuy.Enabled = True
            Me.cbxInvoice.Enabled = True

            Me.tbBuyTargetValue.Enabled = True
            Me.tbBuyTargetValue.Visible = True

            Me.cbBuyTargetCurrency.Enabled = True
            Me.cbBuyTargetCurrency.Visible = True

            Me.cbInvoceCurrency.Enabled = True
            Me.cbInvoceCurrency.Visible = True

            Me.tbInvoice.Enabled = True
            Me.btIncomingCalculate.Enabled = True
            Me.tbInvoice.Visible = True
            Me.CR8cb.Enabled = True
            Me.tbPrice8.Enabled = True

            Me.cbxInCommission.Enabled = True
            Me.gbBuy.Visible = True
        Else
            Me.cbxSetBuy.Enabled = False
            Me.cbxInvoice.Enabled = False

            Me.tbBuyTargetValue.Enabled = False
            Me.tbBuyTargetValue.Visible = False

            Me.cbBuyTargetCurrency.Enabled = False
            Me.cbBuyTargetCurrency.Visible = False

            Me.cbInvoceCurrency.Enabled = False
            Me.cbInvoceCurrency.Visible = False

            Me.tbInvoice.Enabled = False
            Me.btIncomingCalculate.Enabled = False
            Me.tbInvoice.Visible = False

            Me.cbxInCommission.Enabled = False
            Me.gbBuy.Visible = False

            Me.CR8cb.Enabled = False
            Me.tbPrice8.Enabled = False
        End If

        'If clsApplicationTypes.GetAccess("конторские тарифы") Then

        '    Me.btCalculateIncomingCost.Enabled = True
        'Else

        '    Me.btCalculateIncomingCost.Enabled = False
        'End If

        '-------------
        Dim _bt As String() = {"уже есть",
                               "S_roll (сверток)",
                               "S_wb (деревянный бокс)",
                               "S2 коробочка во флет 25*25*12мм (кубики)",
                               "S3 коробочка во флет 30*30*15мм",
                               "S3x4 коробочка во флет 40*30*18мм",
                               "S4 коробочка во флет 40*40*18мм",
                               "S4x45 коробочка во флет 40*45*20мм",
                               "S4x5 коробочка во флет 40*50*19мм",
                               "S5x45 коробочка во флет 50*45*20мм",
                               "S5 коробочка во флет 50*53*25мм",
                               "S6 коробочка во флет 63*63*25мм",
                               "S6x75 коробочка во флет 63*75*25мм",
                               "S6x9 коробочка во флет 63*93*25мм",
                               "S9x125 коробочка во флет 93*125*32мм",
                               "S9x85 коробочка во флет 93*85*30мм",
                               "S125x75 коробочка во флет 125*75*32мм"}
        cbBoxTypes.Items.Clear()
        cbBoxTypes.Items.AddRange(_bt)

        '----------------------------
        oSlotMoveList = New List(Of iMoySkladDataProvider.strGoodMapQty)
        bs_currentMove.DataSource = oSlotMoveList

        Me.oSplashscreen1.Hide()

        If Not oCurrentGood Is Nothing AndAlso Not (oCurrentGood.Code = "") Then
            Me.tbNumber.Text = oCurrentGood.Code
            Me.btSearchInSklad_Click(Me, EventArgs.Empty)
        End If

        'инит ценовой вкладки - если стоит флажок в настройке
        If clsApplicationTypes.ExcelEnabled Then
            UcPriceCalc1.init(clsApplicationTypes.GetRateByCurrencyCB103("EUR"), clsApplicationTypes.GetRateByCurrencyCB103("EUR") / clsApplicationTypes.GetRateByCurrencyCB103("USD"), clsApplicationTypes.GetPriceFilePath)
        Else
            UcPriceCalc1.Enabled = False
        End If

    End Sub

#End Region

#Region "Вспомогательные методы"


    Private Sub FindArticul()
        'показат сплеш
        If oSplashscreen1.Visible = False Then
            oSplashscreen1.Show()
            Application.DoEvents()
        End If

        Me.lbArticuls.DataSource = Nothing
        Dim _result As IEnumerable(Of Object) = Nothing
        Dim _out As New List(Of clsMSGood)
        Dim _message As String = ""

        Dim _status As System.Net.HttpStatusCode
        'просмотр поля код
        If Not Me.tbNumber.Text = "" Then
            Dim _code = ShotCodeConverter_Net.clsCode.CreateInstance(Me.tbNumber.Text)
            Dim _fcode = _code.Series & "-" & _code.Number
            'запрос
            _status = oManager.RequestAnyCollection(clsMoyScladManager.emMoySkladObjectTypes.Good, _result, _fcode, clsMoyScladManager.emMoySkladFilterTypes.productCode, _message)
            If _status = Net.HttpStatusCode.OK Then
                If _result.Count > 0 Then
                    _out.AddRange(From c As good In _result Select clsMSGood.CreateInstance(c))
                End If
            ElseIf Not _status = Net.HttpStatusCode.NotFound Then
                oSplashscreen1.Hide()
                MsgBox(_message, vbCritical)

                Return
            End If
        End If
        'просмотр поля имя
        If Not Me.tbName.Text = "" Then
            _out.AddRange(From c In oManager.RequestGoodCollectionByName(Me.tbName.Text) Select c)
        End If
        'найден
        If _out.Count > 0 Then
            _out.Sort(Function(x, y)
                          If y.Articul = "" Then Return 1
                          If x.Articul = "" Then Return -1
                          Return String.Compare(x.Articul, y.Articul)
                      End Function)
            Me.lbArticuls.DataSource = _out
            Me.lbArticuls.DisplayMember = "GetArticulNameString"
            Me.lbArticuls.ValueMember = "Articul"
        End If
        Me.oSplashscreen1.Hide()
    End Sub
    ''' <summary>
    ''' проверка штрих-кода. Результат пишется в текстбокс!
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CheckBarcode()
        Dim _code As clsApplicationTypes.clsSampleNumber
        'проверка штрихкода
        If Me.tbBarCode.Text.Length = 13 Then
            _code = clsApplicationTypes.clsSampleNumber.CreateFromString(Me.tbBarCode.Text)
            If _code.CodeIsCorrect And _code.IsEAN13 Then
                Dim _bar = _code.EAN13
                If Me.tbNumber.Text.Trim.Length > 0 And Me.tbArticul.Text.Trim.Length = 0 Then
                    _code = clsApplicationTypes.clsSampleNumber.CreateFromString(Me.tbNumber.Text)
                ElseIf Me.tbNumber.Text.Trim.Length = 0 And Me.tbArticul.Text.Trim.Length > 0 Then
                    _code = clsApplicationTypes.clsSampleNumber.CreateFromString(Me.tbArticul.Text)
                Else
                    'код в двух полях
                    MsgBox("Обнаружен номер в двух полях: в коде и артикуле, что недопустимо. Удалите один из них и нажмите кнопку сохранить!", vbCritical)
                End If
                If Not Me.tbBarCode.Text = _code.EAN13 Then
                    Me.MarkAsNeedSaved()

                    Me.ToolStripStatusLabel1.Text = "Обновлен штрих-код! Необходимо нажать кнопку сохранить, иначе будет ошибка в МоемСкладе по штрих-коду"
                End If
            Else
                If Me.tbNumber.Text.Trim.Length > 0 And Me.tbArticul.Text.Trim.Length = 0 Then
                    _code = clsApplicationTypes.clsSampleNumber.CreateFromString(Me.tbNumber.Text)
                ElseIf Me.tbNumber.Text.Trim.Length = 0 And Me.tbArticul.Text.Trim.Length > 0 Then
                    _code = clsApplicationTypes.clsSampleNumber.CreateFromString(Me.tbArticul.Text)
                Else
                    'код в двух полях
                    MsgBox("Обнаружен номер в двух полях: в коде и артикуле, что недопустимо. Удалите один из них и нажмите кнопку сохранить!", vbCritical)
                    Return
                End If
                Me.tbBarCode.Text = _code.EAN13
                Me.MarkAsNeedSaved()
                Me.ToolStripStatusLabel1.Text = "Обновлен штрих-код! Необходимо нажать кнопку сохранить, иначе будет ошибка в МоемСкладе по штрих-коду"
            End If
        End If

    End Sub

    ''' <summary>
    ''' сравнивает изменения в имени и 
    ''' </summary>
    ''' <param name="OldName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CheckName(OldName As String) As Boolean
        If oCurrentGood.Name.Equals(OldName) Then Return False
        'проверка названия
        If oCurrentGood.Name.Contains("нет") Then
            oCurrentGood.Name = OldName
            Me.ToolStripStatusLabel1.Text = "Название изменено, сохраните карточку товара!"
            Me.MarkAsNeedSaved()
            Me.bsCurrentGood.ResetCurrentItem()
            Return True
        Else
            If Not oCurrentGood.Name.Contains(OldName) Then
                Select Case MsgBox(String.Format("Заменить имеющееся название {0} на переданное {1}?", oCurrentGood.Name, OldName), vbYesNo)
                    Case MsgBoxResult.Yes
                        oCurrentGood.Name = OldName
                        Me.ToolStripStatusLabel1.Text = "Название изменено, сохраните карточку товара!"
                        Me.MarkAsNeedSaved()
                        Me.bsCurrentGood.ResetCurrentItem()
                        Return True
                End Select
            End If
        End If
        Return False
    End Function


    ''' <summary>
    ''' запрос товара
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CurrentGoodRequest()

        If Me.oCurrentGood Is Nothing Then
            clsApplicationTypes.BeepNOT()
            Return
        End If

        Dim _foundGoodsCount As Integer
        'показат сплеш
        If oSplashscreen1.Visible = False AndAlso oSplashscreen1.IsHandleCreated Then
            oSplashscreen1.Show()
            Application.DoEvents()
        End If

        '--------------------------
        Me.Uc_trilbone_history1.SampleNumber(False) = Me.oCurrentGood.AnyCode

        Me.bsCurrentGood.DataSource = Me.oCurrentGood

        Dim _preserveName As String = oCurrentGood.Name

        oSearchGoodDirectRequest = True

        Dim _foundGoods As New List(Of good)
        _foundGoodsCount = oManager.FindGoods(Me.oCurrentGood.Code, Me.oCurrentGood.Articul, Me.oCurrentGood.Name, _foundGoods)

        'при ненулевом результате автоматом будет вызвано событие currentchanged bs_Goods_dgv_Goods там вся обработка см ниже
        Me.bs_Goods_dgv_Goods.DataSource = (From c In _foundGoods Select clsMSGood.CreateInstance(c)).ToList
        Me.dgv_Goods.DataSource = Me.bs_Goods_dgv_Goods
        Me.dgv_Goods.Refresh()

        Select Case _foundGoodsCount
            Case Is >= 1
                'товар нашли
                clsApplicationTypes.BeepYES()
                'проверка штрихкода
                CheckBarcode()
                'проверка названия
                Me.CheckName(_preserveName)

            Case 0
                'товар не нашли
                'автоматом будет вызвано событие currentchanged bs_Goods_dgv_Goods там вся обработка см ниже
                Me.bs_Goods_dgv_Goods.DataSource = oCurrentGood
                '
                clsApplicationTypes.BeepNOT()
            Case Is = -1
                'ошибка при поиске
                'сообщения отображаются в методе(пока)

                'операции с товаром
                Me.btAddGoodToWare.Enabled = False
                Me.btCreateGood.Enabled = False
                Me.cbxAddIfExists.Enabled = False

                Me.ToolStripStatusLabel1.Text = "Ошибка запроса!"
                clsApplicationTypes.BeepNOT()
                Me.oSplashscreen1.Hide()
                Return
            Case Is = -2
                'ошибка при поиске
                'операции с товаром
                Me.btAddGoodToWare.Enabled = False
                Me.btCreateGood.Enabled = False
                Me.cbxAddIfExists.Enabled = False

                MsgBox("Следует указать артикул или номер товара!", vbCritical)
                ClearAll()

                Me.ToolStripStatusLabel1.Text = "Выполни запрос"
                clsApplicationTypes.BeepNOT()
                Me.oSplashscreen1.Hide()
                Return
        End Select

        If Me.cbxFixStore.Checked AndAlso Me.cbTargetStores.Items.Count >= oFixedStoreIndex + 1 Then
            Me.cbTargetStores.SelectedIndex = oFixedStoreIndex
        End If

        If Me.cbxFixCurrency.Checked Then
            Me.cbRetailTargetCurrency.SelectedIndex = oFixedCurrencyIndex
            Me.cbBuyTargetCurrency.SelectedIndex = oFixedCurrencyIndex
        End If

        Me.oSplashscreen1.Hide()
        Me.Focus()
    End Sub

    ''' <summary>
    ''' установка текущего образца (вся обработка найденного образца)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub bs_Goods_CurrentItemChanged(sender As Object, e As System.EventArgs) Handles bs_Goods_dgv_Goods.CurrentItemChanged
        If bs_Goods_dgv_Goods.Current Is Nothing Then Return
        If Not oSearchGoodDirectRequest Then Return

        oSearchGoodDirectRequest = False
        Me.oCurrentGood = bs_Goods_dgv_Goods.Current
        '------------------
        'показат сплеш
        Dim _spclose As Boolean = False
        If oSplashscreen1.Visible = False Then
            oSplashscreen1.Show()
            _spclose = True
            oSplashscreen1.Refresh()
        End If

        oRedKeyOff = True
        oWillNewGoodFlag = False
        '--------------------------
        'для найденных товаров пропуск запросов
        If Not oCurrentGood.Locations Is Nothing Then GoTo ex

        '---------------------------
        If Me.oCurrentGood.Good Is Nothing Then
            'текущий товар - новый
            'добавить новый товар!
            Dim _good = New good
            With _good
                .code = Me.tbNumber.Text
                .productCode = Me.tbArticul.Text
                .name = Me.tbName.Text
                'установить штуки
                .uomUuid = My.Settings.PcsUOMUUID
            End With
            'разблокировать установку единицы измерения
            Me.cbUom.Enabled = True
            '-------------------------
            Me.oCurrentGood.UpdateGood(_good)
            ''фотки еще не знаем
            'Me.oCurrentGood.NotHasPhoto = -1

            oWillNewGoodFlag = True
            '-------------------------
            'операции с товаром
            Me.btCreateGood.Enabled = True
            Me.btCreateGood.BackColor = Color.Red
            Me.btAddGoodToWare.Enabled = False
            Me.cbxAddIfExists.Enabled = False

            Me.ToolStripStatusLabel1.Text = "Создать товар?"
            'для ввода 
            '------------data bindings
            Me.ChangeLocations(Nothing)
            Me.tbName.Focus()
        Else
            'текущий товар - уже есть карточка товара в МС
            'установка значений для товара
            Me.SetGoodFields()
            Me.cbxAddIfExists.Enabled = True
            'ищем товар по складам (включая зарезервированные)
            If Me.oCurrentGood.FindLocations(oManager, True) = False Then
                'на складах нет
                Me.ToolStripStatusLabel1.Text = "Добавить на склад?"

                'создать пустые положения
                Me.ChangeLocations(oManager.LocationList)

                'операции с товаром
                Me.btAddGoodToWare.Enabled = True
                Me.btAddGoodToWare.BackColor = Color.Red
                Me.btCreateGood.Enabled = False
                Me.cbxAddIfExists.Enabled = False
                Me.cbxWithoutSlot.Checked = True
                Me.tbQty.Enabled = True
                Me.tbQty.Text = ""
                Me.tbQty.BackColor = Color.Red
                Me.btOnePcs.Enabled = True

                If Me.cbxWithoutSlot.Checked = True Then
                    Me.cbSlot.SelectedIndex = -1
                End If
                SetUserPreferences()
                Me.tbQty.Focus()
            Else
                'нашли на складах
                Me.ToolStripStatusLabel1.Text = "Есть на складе"
                Select Case Me.oCurrentGood.Locations.Count
                    Case 0
                        'ошибка
                        MsgBox("Ошибка поиска", vbCritical)

                    Case 1
                        If Not (Me.oCurrentGood.Locations(0).SlotGood Is Nothing) AndAlso Me.oCurrentGood.Locations(0).SlotGood.Count > 0 AndAlso Me.oCurrentGood.Locations(0).SlotGood(0).SlotUUID <> "" Then
                            Me.ToolStripStatusLabel1.Text = "Есть на складе, лежит в ячейке"
                        Else
                            Me.ToolStripStatusLabel1.Text = "Есть на складе, без размещения"
                        End If
                    Case Is > 1
                        Me.ToolStripStatusLabel1.Text = "Есть на нескольких складах"
                End Select

                'операции с товаром
                Me.btAddGoodToWare.Enabled = False
                Me.btCreateGood.Enabled = False
                Me.cbxAddIfExists.Enabled = True

                '------------data bindings
                Me.ChangeLocations(Nothing)
            End If
        End If

ex:

        If oSampleNumber Is Nothing OrElse oSampleNumber.CodeIsCorrect = False Then
            oSampleNumber = clsApplicationTypes.clsSampleNumber.CreateFromString(oCurrentGood.AnyCode)
            If Not oSampleNumber.CodeIsCorrect Then
                'неправильный код
                MsgBox(String.Format("Введен неверный код товара: {0}", Me.tbNumber.Text), vbCritical)
                oRedKeyOff = False
                Return
            End If
        End If

        '--------------этикетки
        Me.UcGoodLabel1.NameForLabel = oCurrentGood.Name
        Me.UcGoodLabel1.Source = ucGoodLabel.emLabelSource.DrawAi

        'Rfid
        Me.UC_rfid1.SampleNumber = oCurrentGood.AnyCode

        'привязка цен
        'список цен
        Dim _pr = New Service.ucPriceCalc.clsPriceData
        With _pr
            .Rus_office = oCurrentGood.Good.GetPriceByType(oManager, iMoySkladDataProvider.emPriceType.RusInOffice).value / 100
            .Rus_show = oCurrentGood.Good.GetPriceByType(oManager, iMoySkladDataProvider.emPriceType.RusShop).value / 100
            .eBay = oCurrentGood.Good.GetPriceByType(oManager, iMoySkladDataProvider.emPriceType.Ebay).value / 100
            .Eu_office = oCurrentGood.Good.GetPriceByType(oManager, iMoySkladDataProvider.emPriceType.EuInOffice).value / 100
            .Eu_post_bank = oCurrentGood.Good.GetPriceByType(oManager, iMoySkladDataProvider.emPriceType.EuPostBank).value / 100
            .Eu_post_paypal = oCurrentGood.Good.GetPriceByType(oManager, iMoySkladDataProvider.emPriceType.EuPostPayPal).value / 100
            .Eu_show = oCurrentGood.Good.GetPriceByType(oManager, iMoySkladDataProvider.emPriceType.EuInShop).value / 100

            If Me.tbInvoice.Visible Then
                .Invoce = oCurrentGood.Good.GetPriceByType(oManager, iMoySkladDataProvider.emPriceType.Invoce).value / 100
                If Not Me.cbInvoceCurrency.SelectedItem Is Nothing Then
                    .InvoceCurrency = Me.cbInvoceCurrency.SelectedItem.name
                End If

            End If

        End With
        oCurrentGood.AllPrices = _pr
        Me.UcPriceCalc_clsPriceDataBindingSource.DataSource = oCurrentGood.AllPrices



        '---запрос фоток
        'аттрибут фоток
        oCurrentGood.NotHasPhoto = CType(oCurrentGood.Good.GetAttributeValue(My.Settings.NeedPhotosMetaUUID, False, False, False), Boolean)

        Me.pbImage.Image = oSampleNumber.AskImage
        'If Me.pbImage.Image Is Nothing Then
        '    'фоток нет - проверка установки атрибута
        '    If Not oCurrentGood.NotHasPhoto = 1 And Me.cbxNeedPhotos.Checked = False Then
        '        Me.cbxNeedPhotos.Checked = True
        '        MarkAsNeedSaved()
        '    End If
        '    'Else
        '    '    'фотки есть
        '    '    If Not oCurrentGood.NotHasPhoto = 0 Then
        '    '        Me.cbxNeedPhotos.Checked = False
        '    '    End If
        'End If

        ''-----printable--label type
        If Me.cbxWithoutPriceLabelType.Checked Then
            Me.ShowLabelWithoutPrice()
        Else
            Me.ShowLabelWithPrice()
        End If
        '-------------
        'slash screen close
        If _spclose Then
            Me.oSplashscreen1.Hide()
        End If
        oRedKeyOff = False
    End Sub


    ''' <summary>
    ''' установит значения полей товара и синхронизует их с ЭУ
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetGoodFields()
        '------------------------
        'установка значений для товара
        '------------------------
        'retail prices
        If Me.oCurrentGood.Good.salePriceSpecified = True Then
            'указать розницу
            Dim _price = Me.oCurrentGood.Good.salePrice / 100
            Dim _curr = (From c As MoySkladAPI.currency In Me.cbRetailTargetCurrency.Items Where c.uuid = Me.oCurrentGood.Good.saleCurrencyUuid Select c).FirstOrDefault
            Me.cbRetailTargetCurrency.SelectedItem = _curr
            Me.tbRetailTargetValue.Text = _price
            Me.cbRetailTargetCurrency.Refresh()
        End If
        Me.tbRetailTargetValue.Enabled = False

        'здесь указать закупку - только админу!!!
        If Me.oCurrentGood.Good.buyPriceSpecified = True And clsApplicationTypes.GetAccess("цена инвойса и закупки") Then
            Dim _price = Me.oCurrentGood.Good.buyPrice / 100
            Dim _curr = (From c As MoySkladAPI.currency In Me.cbBuyTargetCurrency.Items Where c.uuid = Me.oCurrentGood.Good.buyCurrencyUuid Select c).FirstOrDefault
            Me.cbBuyTargetCurrency.SelectedItem = _curr
            Me.tbBuyTargetValue.Text = _price
        End If

        If clsApplicationTypes.GetAccess("цена инвойса и закупки") Then
            Me.cbxSetBuy.Enabled = True
        Else
            Me.cbxSetBuy.Enabled = False
        End If

        Me.tbBuyTargetValue.Enabled = False

        'здесь указать инвойс - только админу!!! cbInvoceCurrency
        Dim _pr = Me.oCurrentGood.Good.GetPriceByType(oManager, iMoySkladDataProvider.emPriceType.Invoce)
        If Not _pr Is Nothing And clsApplicationTypes.GetAccess("цена инвойса и закупки") Then
            Dim _price = _pr.value / 100
            Dim _curr = (From c As MoySkladAPI.currency In Me.cbInvoceCurrency.Items Where c.uuid = _pr.currencyUuid Select c).FirstOrDefault
            Me.cbInvoceCurrency.SelectedItem = _curr
            Me.tbInvoice.Text = _price
        ElseIf Me.tbInvoice.Visible = True Then
            Me.cbInvoceCurrency.SelectedIndex = -1
            Me.tbInvoice.Text = ""
        End If
        '---------------------
        'цены
        Me.SalePricesBindingSource.DataSource = oCurrentGood.Good.salePrices

        'ед.изм.
        Me.cbUom.SelectedItem = oManager.GetUomByUUID(oCurrentGood.Good.uomUuid)
        '-------------------
        '-------------------
        '------------------
        ''поля товара
        Dim _resAttrValue As List(Of goodAttributeValue)
        Dim _resCustEntity As List(Of customEntity)

        If Me.oCurrentGood.Good.attribute Is Nothing Then Return

        'справочники
        'препаратор
        _resAttrValue = (From c In Me.oCurrentGood.Good.attribute Where c.metadataUuid = My.Settings.PreparatorMetaUUID Select c).ToList

        If _resAttrValue.Count > 0 Then
            _resCustEntity = (From c In oManager.TrilboneWokersList Where c.uuid = _resAttrValue(0).entityValueUuid Select c).ToList
            If _resCustEntity.Count > 0 Then
                Me.cbMainPreparator.SelectedItem = _resCustEntity(0)
            End If
            _resCustEntity.Clear()
        End If
        _resAttrValue.Clear()



        'экспедиция
        _resAttrValue = (From c In Me.oCurrentGood.Good.attribute Where c.metadataUuid = My.Settings.ExpeditionMetaUUID Select c).ToList

        If _resAttrValue.Count > 0 Then
            _resCustEntity = (From c In oManager.ExpeditionsList Where c.uuid = _resAttrValue(0).entityValueUuid Select c).ToList
            If _resCustEntity.Count > 0 Then
                Me.cbExpedition.SelectedItem = _resCustEntity(0)
                Me.cbInExpedition.Checked = True
            Else
                Me.cbInExpedition.Checked = False
            End If
            _resCustEntity.Clear()
        End If
        _resAttrValue.Clear()

        'поставщик
        If Not Me.oCurrentGood.Good.supplierUuid = "" Then
            Dim _res2 = (From c In Me.oManager.CustomerList(False) Where c.uuid = Me.oCurrentGood.Good.supplierUuid Select c).ToList
            If _res2.Count > 0 Then
                Me.cbSupplier.SelectedItem = _res2(0)
                ' Me.cbxInCommission.Checked = True
            Else
                'Me.cbxInCommission.Checked = False
            End If
        End If


        'Допрепарация подробно
        _resAttrValue = (From c In Me.oCurrentGood.Good.attribute Where c.metadataUuid = My.Settings.RePreparingDetailsMetaUUID Select c).ToList

        If _resAttrValue.Count > 0 Then
            _resCustEntity = (From c In oManager.RePrepDetailsList Where c.uuid = _resAttrValue(0).entityValueUuid Select c).ToList
            If _resCustEntity.Count > 0 Then
                Me.cbRePrepDetails.SelectedItem = _resCustEntity(0)
            End If
            _resCustEntity.Clear()
        End If
        _resAttrValue.Clear()

        'оформитель товара
        _resAttrValue = (From c In Me.oCurrentGood.Good.attribute Where c.metadataUuid = My.Settings.ThisGoodMakerMetaUUID Select c).ToList

        If _resAttrValue.Count > 0 Then
            _resCustEntity = (From c In oManager.TrilboneWokersList Where c.uuid = _resAttrValue(0).entityValueUuid Select c).ToList
            If _resCustEntity.Count > 0 Then
                ' Me.cbExpedition.SelectedItem = _resCustEntity(0)
                'сюда список сотрудников-оформителей
            End If
            _resCustEntity.Clear()

        End If
        _resAttrValue.Clear()


        ''справочник Схемы рассчетов выплат
        _resAttrValue = (From c In Me.oCurrentGood.Good.attribute Where c.metadataUuid = My.Settings.SchemeMetaUUID Select c).ToList

        If _resAttrValue.Count > 0 Then
            _resCustEntity = (From c In oManager.SchemeList Where c.uuid = _resAttrValue(0).entityValueUuid Select c).ToList
            If _resCustEntity.Count > 0 Then
                Me.cbSchemePrice.SelectedItem = _resCustEntity(0)
                'сюда список сотрудников-оформителей
            End If
            _resCustEntity.Clear()

        End If
        _resAttrValue.Clear()



        '------------------
        'поля значений

        'произв. номер
        _resAttrValue = (From c In Me.oCurrentGood.Good.attribute Where c.metadataUuid = My.Settings.RawNumberMetaUUID Select c).ToList

        If _resAttrValue.Count > 0 Then
            Me.oCurrentGood.RawNumber = _resAttrValue(0).valueString
        End If
        _resAttrValue.Clear()

        'список препараторов обязательно первый!!
        _resAttrValue = (From c In Me.oCurrentGood.Good.attribute Where c.metadataUuid = My.Settings.PrepListMetaUUID Select c).ToList

        If _resAttrValue.Count > 0 Then
            Me.tbPrepList.Text = _resAttrValue(0).valueString
        End If
        _resAttrValue.Clear()

        Application.DoEvents()



        ''записать прибыльность
        _resAttrValue = (From c In Me.oCurrentGood.Good.attribute Where c.metadataUuid = My.Settings.ClearProfitMetaUUID Select c).ToList

        If _resAttrValue.Count > 0 Then
            ' Me.tbPrepTime.Text = _resAttrValue(0).doubleValue
        End If
        _resAttrValue.Clear()

        ''записать поставку
        _resAttrValue = (From c In Me.oCurrentGood.Good.attribute Where c.metadataUuid = My.Settings.HuntFullMetaUUID Select c).ToList

        If _resAttrValue.Count > 0 Then
            Me.tbBuyCost.Text = _resAttrValue(0).doubleValue
        End If
        _resAttrValue.Clear()


        'время препарации
        _resAttrValue = (From c In Me.oCurrentGood.Good.attribute Where c.metadataUuid = My.Settings.PrepTimeMetaUUID Select c).ToList

        If _resAttrValue.Count > 0 Then
            Me.tbPrepTime.Text = _resAttrValue(0).doubleValue
        End If
        _resAttrValue.Clear()

        ''записать препарацию 
        _resAttrValue = (From c In Me.oCurrentGood.Good.attribute Where c.metadataUuid = My.Settings.PrepFullMetaUUID Select c).ToList

        If _resAttrValue.Count > 0 Then
            Me.tbFullPrepCost.Text = _resAttrValue(0).doubleValue
        End If
        _resAttrValue.Clear()


        'экспедиционный номер
        _resAttrValue = (From c In Me.oCurrentGood.Good.attribute Where c.metadataUuid = My.Settings.ExpNumberMetaUUID Select c).ToList

        If _resAttrValue.Count > 0 Then
            Me.tbExpedNumber.Text = _resAttrValue(0).valueString
        End If
        _resAttrValue.Clear()

        'тип упаковки
        _resAttrValue = (From c In Me.oCurrentGood.Good.attribute Where c.metadataUuid = My.Settings.BoxTypeNumberMetaUUID Select c).ToList

        If _resAttrValue.Count > 0 Then
            Me.tbBoxType.Text = _resAttrValue(0).valueText
        End If
        _resAttrValue.Clear()


        'примечание
        _resAttrValue = (From c In Me.oCurrentGood.Good.attribute Where c.metadataUuid = My.Settings.ExpBuyNotesMetaUUID Select c).ToList

        If _resAttrValue.Count > 0 Then
            Me.tbExpeditInfo.Text = _resAttrValue(0).valueText
        End If
        _resAttrValue.Clear()


        'Коды узлов дерева описаний
        _resAttrValue = (From c In Me.oCurrentGood.Good.attribute Where c.metadataUuid = My.Settings.MyTreeCodeMetaUUID Select c).ToList

        If _resAttrValue.Count > 0 Then
            Me.tbMyTreeCode.Text = _resAttrValue(0).valueString
        End If
        _resAttrValue.Clear()


        '------------------
        'флаги
        'комиссия
        _resAttrValue = (From c In Me.oCurrentGood.Good.attribute Where c.metadataUuid = My.Settings.ComissionMetaUUID Select c).ToList


        If _resAttrValue.Count > 0 Then
            Me.cbxInCommission.Checked = _resAttrValue(0).booleanValue
        End If
        _resAttrValue.Clear()

        'допрепарация
        _resAttrValue = (From c In Me.oCurrentGood.Good.attribute Where c.metadataUuid = My.Settings.NeedRePreparingMetaUUID Select c).ToList

        Me.cbRePrepDetails.Enabled = Me.cbxNeedRePrep.Checked
        If _resAttrValue.Count > 0 Then
            Me.cbxNeedRePrep.Checked = _resAttrValue(0).booleanValue

        End If
        _resAttrValue.Clear()

        'этикетка
        _resAttrValue = (From c In Me.oCurrentGood.Good.attribute Where c.metadataUuid = My.Settings.NeedLabelMetaUUID Select c).ToList

        If _resAttrValue.Count > 0 Then
            Me.cbxNeedMakeLabel.Checked = _resAttrValue(0).booleanValue
        End If
        _resAttrValue.Clear()

        ''Требуется сделать фото 
        '_resAttrValue = (From c In Me.oCurrentGood.Good.attribute Where c.metadataUuid = My.Settings.NeedPhotosMetaUUID Select c).ToList

        'If _resAttrValue.Count > 0 Then
        '    Me.cbxNeedPhotos.Checked = _resAttrValue(0).booleanValue
        '    If Me.cbxNeedPhotos.Checked Then
        '        Me.oCurrentGood.NotHasPhoto = 1
        '    Else
        '        Me.oCurrentGood.NotHasPhoto = 0
        '    End If
        'End If
        '_resAttrValue.Clear()

        'Требуется ремонт
        _resAttrValue = (From c In Me.oCurrentGood.Good.attribute Where c.metadataUuid = My.Settings.NeedRepairMetaUUID Select c).ToList

        If _resAttrValue.Count > 0 Then
            Me.cbxNeedRepair.Checked = _resAttrValue(0).booleanValue
        End If
        _resAttrValue.Clear()

        'Требуется упаковка (коробочка)
        _resAttrValue = (From c In Me.oCurrentGood.Good.attribute Where c.metadataUuid = My.Settings.NeedBoxingMetaUUID Select c).ToList

        If _resAttrValue.Count > 0 Then
            Me.cbxNeedPackaging.Checked = _resAttrValue(0).booleanValue
        End If
        _resAttrValue.Clear()

        ''Подготовлен в Ebay
        '_resAttrValue = (From c In Me.oCurrentGood.Good.attribute Where c.metadataUuid = My.Settings.ReadyToEbayMetaUUID Select c).ToList

        'If _resAttrValue.Count > 0 Then
        '    Me.cbxInEbay.Checked = _resAttrValue(0).booleanValue
        'End If
        '_resAttrValue.Clear()

        ''Подготовлен в Молоток
        '_resAttrValue = (From c In Me.oCurrentGood.Good.attribute Where c.metadataUuid = My.Settings.ReadyToMolotokMetaUUID Select c).ToList

        'If _resAttrValue.Count > 0 Then
        '    Me.cbxInMolotok.Checked = _resAttrValue(0).booleanValue
        'End If
        '_resAttrValue.Clear()

        ''Подготовлен на сайт Trilbone
        '_resAttrValue = (From c In Me.oCurrentGood.Good.attribute Where c.metadataUuid = My.Settings.ReadyToSiteTrilboneMetaUUID Select c).ToList

        'If _resAttrValue.Count > 0 Then
        '    Me.cbxInSiteTrilbone.Checked = _resAttrValue(0).booleanValue
        'End If
        '_resAttrValue.Clear()

    End Sub

    ''' <summary>
    ''' выбор товара в таблице
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgv_Goods_CurrentCellChanged(sender As Object, e As System.EventArgs)
        If dgv_Goods.CurrentCell Is Nothing Then Return
        Dim _selectedGood = CType(Me.dgv_Goods.Rows(dgv_Goods.CurrentCell.RowIndex).DataBoundItem, clsMSGood)
        If _selectedGood Is Nothing Then Return
        'получить данные товара
        If _selectedGood.IsAllocated = False Then
            'показат сплеш
            If oSplashscreen1.Visible = False Then
                oSplashscreen1.Show()
                Application.DoEvents()
            End If
            If _selectedGood.FindLocations(oManager, True) = False AndAlso Me.oWillNewGoodFlag = True Then
                'для нового товара загрузить список складов
                _selectedGood.SetLocations(oManager.LocationList)
            End If
            Me.oSplashscreen1.Hide()
            Application.DoEvents()
        End If
        'при списании
        If cbxLossEnable.Checked = True Then
            'установить товар для списания
            oCurrentLossGood = _selectedGood

            If Me.oWillNewGoodFlag Then
                'карточка товара не создана
                Dim _name As String = oCurrentLossGood.Name
                If _name.ToLower.Contains("(общий)".ToLower) Then
                    _name = _name.Replace("(общий)", "")
                End If

                If Not _name.Equals(tbName.Text) Then
                    Me.oCurrentGood.Name = _name
                    'Me.bsCurrentGood.ResetCurrentItem()
                End If
                'создать карточку
                btCreateGoodMap_click(Me.btCreateGood, EventArgs.Empty)
            End If

            Me.cbLossLocations.DataSource = oCurrentLossGood.SlotList
            Me.lbLossUom.Text = oManager.GetUomByUUID(oCurrentLossGood.Good.uomUuid).name
            Me.btLoss.Enabled = True
            If Me.lbLossUom.Text = Me.cbUom.SelectedItem.name Then
                Dim _sl = CType(Me.SlotGoodBindingSource.Current, clsGoodLocation.clsSlot)
                Me.tbLossQty.Text = _sl.Qty
            End If

            Me.tbLossQty.Focus()

            'поставить цены закупки
            If Not oCurrentLossGood.Good Is Nothing And clsApplicationTypes.GetAccess("цена инвойса и закупки") Then
                Me.tbBuyPriceGood.Enabled = False
                Me.tbBuyPriceGoodCurrency.Enabled = False
                Dim _pr = Me.oCurrentGood.Good.GetPriceByType(oManager, iMoySkladDataProvider.emPriceType.Invoce)
                If _pr Is Nothing Then
                    'такой цены нет в товаре, добавить
                    Me.oCurrentGood.Good.SetPriceByType(oManager, iMoySkladDataProvider.emPriceType.Invoce, 0)
                    _pr = Me.oCurrentGood.Good.GetPriceByType(oManager, iMoySkladDataProvider.emPriceType.Invoce)
                End If
                If Not _pr.currencyUuid = "" Then
                    Me.tbBuyPriceGood.Text = _pr.value / 100
                    Me.tbBuyPriceGoodCurrency.Text = (From c As MoySkladAPI.currency In Me.cbInvoceCurrency.Items Where c.uuid = _pr.currencyUuid Select c).FirstOrDefault.name
                End If
            Else
                Me.tbBuyPriceGood.Enabled = False
                Me.tbBuyPriceGoodCurrency.Enabled = False
            End If
            Select Case oCurrentLossGood.Good.uomUuid
                Case My.Settings.KgUOMUUID
                    Me.tbShippingPrice.Text = My.Settings.ShippingTariffPerKG
                Case My.Settings.PcsUOMUUID
                    Me.tbShippingPrice.Text = My.Settings.ShippingTariffPerPCS
                Case My.Settings.EUOMUUID
                    Me.tbShippingPrice.Text = My.Settings.ShippingTariffPerE
                Case My.Settings.gUomUUID
                    Me.tbShippingPrice.Text = Math.Round(My.Settings.ShippingTariffPerKG / 1000, 2)
                Case Else
                    Me.tbShippingPrice.Text = "0"
            End Select
        End If
    End Sub

    ' ''' <summary>
    ' ''' запрашивает все приемки и оприходования. выделяет товары с переданным кодом. потом возможна асинхронная реализация.
    ' ''' </summary>
    ' ''' <returns></returns>
    ' ''' <remarks></remarks>
    'Private Function QueryServerForComingIN(LocGood As good) As List(Of clsGoodLocation)
    '    Dim _data As IEnumerable(Of Object) = Nothing
    '    Dim _data_tmp As IEnumerable(Of Object) = Nothing
    '    Dim _message As String = ""
    '    Dim _allslotList As New List(Of clsGoodLocation.clsSlot)
    '    'ид склада
    '    Dim _storeUUID As String
    '    'ид ячейки на складе
    '    Dim _slotUUID As String
    '    '-------------------------
    '    If LocGood Is Nothing Then
    '        Return Nothing
    '    End If
    '    '-------------------
    '    'запрос ВСЕХ оприходований
    '    Dim _result = oManager.RequestAnyCollection(clsMoyScladManager.emMoySkladObjectTypes.Enter, _data, , , _message)
    '    If _result = Net.HttpStatusCode.OK Then
    '        'перебрать оприходования и найти goodUUD
    '        For Each _enter As enter In _data
    '            'перебрать коллекцию обьектов enterPosition (позиции в оприходовании)
    '            For Each _enterPosition In _enter.enterPosition
    '                Dim _newEnterFlag As Boolean = True
    '                If String.Equals(_enterPosition.goodUuid, LocGood.uuid) Then
    '                    'ид склада
    '                    _storeUUID = _enter.targetStoreUuid
    '                    'ид ячейки на складе
    '                    _slotUUID = _enterPosition.slotUuid
    '                    _allslotList.Add(New clsGoodLocation.clsSlot(_enterPosition.quantity, _storeUUID, _storeUUID))
    '                End If
    '            Next
    '        Next
    '    Else
    '        'ответа нет от сервера
    '        MsgBox("Запрос оприходоваий неудачно " & _message, MsgBoxStyle.Critical)
    '    End If

    '    '----------------------------
    '    'запрос ВСЕХ приемок
    '    _result = oManager.RequestAnyCollection(clsMoyScladManager.emMoySkladObjectTypes.Supply, _data, , , _message)
    '    If _result = Net.HttpStatusCode.OK Then
    '        'перебрать оприходования и найти goodUUD
    '        For Each _supply As supply In _data
    '            'перебрать коллекцию обьектов enterPosition (позиции в оприходовании)
    '            For Each _shipmentIn In _supply.shipmentIn
    '                Dim _newEnterFlag As Boolean = True
    '                If String.Equals(_shipmentIn.goodUuid, LocGood.uuid) Then
    '                    'ид склада
    '                    _storeUUID = _supply.targetStoreUuid
    '                    'ид ячейки на складе
    '                    _slotUUID = _shipmentIn.slotUuid
    '                    _allslotList.Add(New clsGoodLocation.clsSlot(_shipmentIn.quantity, _storeUUID, _storeUUID))
    '                End If
    '            Next
    '        Next
    '    Else
    '        'ответа нет от сервера
    '        MsgBox("Запрос приемок неудачно " & _message, MsgBoxStyle.Critical)
    '    End If

    '    'теперь добавим слоты в класс
    '    'сгруппируем по складам
    '    Dim _res = From c In _allslotList Let b = c.WarehoseUUID Group c By b Into Group Select New clsGoodLocation(LocGood, b) With {.SlotGood = Group.ToList}

    '    'подом надо вызвать LoadObject() для загрузки содержимого из базы
    '    For Each t In _res
    '        t.LoadObjects(oManager)
    '    Next

    '    Return _res

    'End Function
    ''' <summary>
    ''' создает карточку товара
    ''' </summary>
    ''' <param name="_good"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function SetGoodTable(ByRef _good As good) As String

        'ЗАДАТЬ ПАРАМЕТРЫ ТОВАРА
        Dim _answermsg As String = ""
        '--------------
        'артикул
        _good.productCode = Me.tbArticul.Text
        'номер
        _good.code = Me.tbNumber.Text
        'описание
        _good.description = rtbDescription.Text
        'штрих-код
        'new version
        If _good.barcode Is Nothing OrElse _good.barcode.Count = 0 Then
            Dim _nb = New barcode
            _nb.barcodeType = barcodeType.EAN13
            _nb.barcodeTypeSpecified = True
            Dim _arr As New List(Of barcode)
            _arr.Add(_nb)
            _good.barcode = _arr.ToArray
        End If
        If Not _good.productCode = "" And Not _good.code = "" Then
            MsgBox("Задано два номера - код и артикул, что недопустимо! Удалите один из них (Двойной клик по полю)")
        End If

        If Not _good.productCode = "" Then
            Dim _code = ShotCodeConverter_Net.clsCode.CreateInstance(_good.productCode)
            If _code.CodeType = ShotCodeConverter_Net.clsCode.emCodeType.EAN13 Then
                _good.barcode.First.barcode = _code.EAN13
                Me.tbBarCode.Text = _code.EAN13
            End If
        End If

        If Not _good.code = "" Then
            Dim _code = ShotCodeConverter_Net.clsCode.CreateInstance(_good.code)
            If _code.CodeType = ShotCodeConverter_Net.clsCode.emCodeType.EAN13 Then
                _good.barcode.First.barcode = _code.EAN13
                Me.tbBarCode.Text = _code.EAN13
            End If
        End If

        'еденица измерения шт, кг
        ' Debug.Assert(Not Me.cbUom.SelectedItem Is Nothing, "программно не задана еденица измерения")
        If Me.cbUom.SelectedItem Is Nothing Then
            Me.cbUom.SelectedIndex = 0
            Me.MarkAsNeedSaved()
            Me.ToolStripStatusLabel1.Text = "по умолчанию в ШТ! Необходимо нажать кнопку сохранить, иначе будет ошибка в МоемСкладе по еденице измерения"
        End If

        Me.bsCurrentGood.SuspendBinding()
        _good.uomUuid = Me.cbUom.SelectedItem.uuid
        Me.bsCurrentGood.ResumeBinding()

        '------------------------------
        'ЦЕНЫ
        'розница
        If cbxSetRetail.Checked = True AndAlso Not (Me.cbRetailTargetCurrency.SelectedItem Is Nothing) AndAlso Not Me.tbRetailTargetValue.Text = "" Then
            Dim _curr = CType(Me.cbRetailTargetCurrency.SelectedItem, MoySkladAPI.currency)
            _good.SetRetailPrice(oManager, clsApplicationTypes.ReplaceDecimalSplitter(Me.tbRetailTargetValue), _curr.name)
            _answermsg += "розничная цена установлена;" & ChrW(13)
        End If
        '------------------
        'закупка и минимальная цена - только админ (или программный расчет при списании - см кнопку списать)

        If clsApplicationTypes.GetAccess("цена инвойса и закупки") AndAlso cbxSetBuy.Checked = True AndAlso Not (Me.cbBuyTargetCurrency.SelectedItem Is Nothing) AndAlso Not Me.tbBuyTargetValue.Text = "" Then
            Dim _curr = CType(Me.cbBuyTargetCurrency.SelectedItem, MoySkladAPI.currency)
            'считаем курс
            Dim _kursBaseBuy = _curr.rate
            Dim _euro = oManager.GetCurrencyByUUID(_good.saleCurrencyUuid)
            Dim _kursBaseEur = _euro.rate

            ''минимальная цена устанавливается в 0 TODO
            _good.SetPriceByType(oManager, iMoySkladDataProvider.emPriceType.MinimumPrice, 0)
            '_answermsg += "минимальная цена установлена;" & ChrW(13)
            'закупочная
            _good.SetPriceByType(oManager, iMoySkladDataProvider.emPriceType.BuyPrice, clsApplicationTypes.ReplaceDecimalSplitter(Me.tbBuyTargetValue), _curr.name)
            _answermsg += "цена закупки установлена;" & ChrW(13)
        End If
        '--------------------------
        'инвойс - только админ
        If cbxInvoice.Checked = True AndAlso clsApplicationTypes.GetAccess("цена инвойса и закупки") AndAlso Not (Me.cbInvoceCurrency.SelectedItem Is Nothing) Then
            Dim _curr = CType(Me.cbInvoceCurrency.SelectedItem, MoySkladAPI.currency)
            _good.SetPriceByType(oManager, iMoySkladDataProvider.emPriceType.Invoce, clsApplicationTypes.ReplaceDecimalSplitter(Me.tbInvoice), _curr.name)
            _answermsg += "цена инвойса установлена;" & ChrW(13)
        End If

        '---------дополнительные параметры товара
        _good.attribute = Me.SetAttributesToGood(_good)


        '-------------------
        If Not _good.attribute Is Nothing AndAlso _good.attribute.Length > 0 Then
            _answermsg += "атрибуты установлены;" & ChrW(13)
        End If
        'параметры товара установлены
        Return _answermsg
    End Function

    ''' <summary>
    ''' проверяет и устанавливает атрибуты товару в соответствии с данными формы
    ''' </summary>
    ''' <param name="ToGood"></param>
    ''' <remarks></remarks>
    Private Function SetAttributesToGood(ToGood As good) As goodAttributeValue()

        If ToGood.uuid = "" Then Return Nothing

        Dim _good = ToGood

        Dim _new As New List(Of goodAttributeValue)


        If Not _good.attribute Is Nothing Then
            _new.AddRange(_good.attribute)
        End If

        Dim _metauuid As String
        Dim _Value As Object

        Dim _deletefn = Sub(metadataUUID As String)
                            'ищем флаг в атрибутах товара
                            Dim _resAttrValue1 As goodAttributeValue
                            _resAttrValue1 = (From c In _new Where c.metadataUuid = metadataUUID Select c).FirstOrDefault
                            If Not _resAttrValue1 Is Nothing Then
                                'да - удалим
                                _new.Remove(_resAttrValue1)
                            End If
                        End Sub



        Dim _addfn = Sub(attributeValue As Object, metadataUUID As String, IsBooleanType As Boolean, IsStringType As Boolean, IsDecimalType As Boolean, IsTextType As Boolean, IsCustomEntityType As Boolean)
                         'ищем флаг в атрибутах товара
                         Dim _resAttrValue As goodAttributeValue
                         _resAttrValue = (From c In _new Where c.metadataUuid = metadataUUID Select c).FirstOrDefault
                         If Not _resAttrValue Is Nothing Then
                             'удалить атрибут
                             _deletefn(metadataUUID)
                         End If
                         'нет - создаем обьект атрибута и добавляем его в коллекцию
                         _resAttrValue = goodAttributeValue.CreateInstance(_good.uuid, metadataUUID, attributeValue, IsBooleanType, IsStringType, IsDecimalType, IsTextType, IsCustomEntityType)
                         _new.Add(_resAttrValue)
                     End Sub


        ''=====================
        'найти _metauuid
        'можно в служебном окне, запросив товар с установленным аттрибутом:
        'attribute: 390d4c7d-7804-11e4-90a2-8eca0039f2a5 =(bool) False;   uuid: 00537f2e-0d56-11e5-7a07-673d0003a4b8
        'первое значение UUID нам и нужно
        'ИЛИ запросом https://online.moysklad.ru/exchange/rest/ms/xml/Metadata/list?filter=name%3DGoodFolder
        'где надо брать UUID соответствующего блока
        ''=====================
        '---------------------------
        'флаги

        'Требуется сделать фото
        'определим значение атрибута
        _Value = Me.cbxNeedPhotos.Checked
        _metauuid = My.Settings.NeedPhotosMetaUUID
        _addfn(_Value, _metauuid, True, False, False, False, False)



        'Требуется сделать этикетку
        'определим значение атрибута
        _Value = Me.cbxNeedMakeLabel.Checked
        _metauuid = My.Settings.NeedLabelMetaUUID
        _addfn(_Value, _metauuid, True, False, False, False, False)


        'комиссия
        'определим значение атрибута
        _Value = Me.cbxInCommission.Checked
        _metauuid = My.Settings.ComissionMetaUUID
        _addfn(_Value, _metauuid, True, False, False, False, False)

        'Требуется ремонт
        'определим значение атрибута
        _Value = Me.cbxNeedRepair.Checked
        _metauuid = My.Settings.NeedRepairMetaUUID
        _addfn(_Value, _metauuid, True, False, False, False, False)

        'Требуется упаковка (коробочка)
        'определим значение атрибута
        _Value = Me.cbxNeedPackaging.Checked
        _metauuid = My.Settings.NeedBoxingMetaUUID
        _addfn(_Value, _metauuid, True, False, False, False, False)

        'Требуется допрепарация
        'определим значение атрибута
        _Value = Me.cbxNeedRePrep.Checked
        _metauuid = My.Settings.NeedRePreparingMetaUUID
        _addfn(_Value, _metauuid, True, False, False, False, False)

        ' '' '' ''Подготовлен в Ebay
        ' '' '' ''определим значение атрибута
        '' '' ''_Value = Me.cbxInEbay.Checked
        '' '' ''_metauuid = My.Settings.ReadyToEbayMetaUUID
        '' '' ''_addfn(_Value, _metauuid, True, False, False, False, False)


        ' '' '' ''Подготовлен в Молоток
        ' '' '' ''определим значение атрибута
        '' '' ''_Value = Me.cbxInMolotok.Checked
        '' '' ''_metauuid = My.Settings.ReadyToMolotokMetaUUID
        '' '' ''_addfn(_Value, _metauuid, True, False, False, False, False)


        ' '' '' ''Подготовлен в на сайт Trilbone
        ' '' '' ''определим значение атрибута
        '' '' ''_Value = Me.cbxInSiteTrilbone.Checked
        '' '' ''_metauuid = My.Settings.ReadyToSiteTrilboneMetaUUID
        '' '' ''_addfn(_Value, _metauuid, True, False, False, False, False)

        '======
        'ПОЛЯ
        'Производственный номер или EAN13
        'определим значение атрибута
        _metauuid = My.Settings.RawNumberMetaUUID
        If Not Me.tbRawNumber.Text = "" Then
            _Value = Me.tbRawNumber.Text
            _addfn(_Value, _metauuid, False, True, False, False, False)
        Else
            _deletefn(_metauuid)
        End If

        'записать полную препарацию
        _metauuid = My.Settings.PrepFullMetaUUID
        _Value = clsApplicationTypes.ReplaceDecimalSplitter(Me.tbFullPrepCost)
        _addfn(_Value, _metauuid, False, False, True, False, False)

        'записать поставку
        _metauuid = My.Settings.HuntFullMetaUUID
        _Value = clsApplicationTypes.ReplaceDecimalSplitter(Me.tbBuyCost)
        _addfn(_Value, _metauuid, False, False, True, False, False)


        'записать схему
        'справочник Схемы рассчетов выплат
        If (Not Me.cbSchemePrice.SelectedItem Is Nothing) Then
            _metauuid = My.Settings.SchemeMetaUUID
            If CType(Me.cbSchemePrice.SelectedItem, customEntity).uuid = "" Then
                'удалить (не добавлять) атрибут
                _deletefn(_metauuid)
            Else
                _Value = CType(Me.cbSchemePrice.SelectedItem, customEntity).uuid
                _addfn(_Value, _metauuid, False, False, False, False, True)
            End If
        End If


        'Время препарации в часах (общее)
        _metauuid = My.Settings.PrepTimeMetaUUID

        If Not Me.tbPrepTime.Text = "" Then
            _Value = clsApplicationTypes.ReplaceDecimalSplitter(tbPrepTime)
            _addfn(_Value, _metauuid, False, False, True, False, False)
        Else
            _deletefn(_metauuid)
        End If


        'Экспедиционный/закупочный номер
        _metauuid = My.Settings.ExpNumberMetaUUID

        If Not Me.tbExpedNumber.Text = "" Then
            _Value = Me.tbExpedNumber.Text
            _addfn(_Value, _metauuid, False, True, False, False, False)
        Else
            _deletefn(_metauuid)
        End If


        'список препараторов
        _metauuid = My.Settings.PrepListMetaUUID

        If Not Me.tbPrepList.Text = "" Then
            _Value = Me.tbPrepList.Text
            _addfn(_Value, _metauuid, False, True, False, False, False)
        Else
            _deletefn(_metauuid)
        End If

        'Коды узлов дерева описаний
        _metauuid = My.Settings.MyTreeCodeMetaUUID

        If Not Me.tbMyTreeCode.Text = "" Then
            _Value = Me.tbMyTreeCode.Text
            _addfn(_Value, _metauuid, False, True, False, False, False)
        Else
            _deletefn(_metauuid)
        End If


        'Экспедиционное/закупочное примечание
        _metauuid = My.Settings.ExpBuyNotesMetaUUID

        If Not Me.tbExpeditInfo.Text = "" Then
            _Value = Me.tbExpeditInfo.Text
            _addfn(_Value, _metauuid, False, False, False, True, False)
        Else
            _deletefn(_metauuid)
        End If

        'Тип упаковки
        _metauuid = My.Settings.BoxTypeNumberMetaUUID

        If Not Me.tbBoxType.Text = "" Then
            _Value = Me.tbBoxType.Text
            _addfn(_Value, _metauuid, False, False, False, True, False)
        Else
            _deletefn(_metauuid)
        End If



        '===справочники
        'справочник Экспедиция
        If (Not Me.cbExpedition.SelectedItem Is Nothing) Then
            _metauuid = My.Settings.ExpeditionMetaUUID

            If CType(Me.cbExpedition.SelectedItem, customEntity).uuid = "" Then
                'удалить (не добавлять) атрибут
                _deletefn(_metauuid)
            Else
                _Value = CType(Me.cbExpedition.SelectedItem, customEntity).uuid
                _addfn(_Value, _metauuid, False, False, False, False, True)
            End If

        End If

        'справочник Препаратор (основной) 
        If (Not Me.cbMainPreparator.SelectedItem Is Nothing) Then
            _metauuid = My.Settings.PreparatorMetaUUID
            If CType(Me.cbMainPreparator.SelectedItem, customEntity).uuid = "" Then
                'удалить (не добавлять) атрибут
                _deletefn(_metauuid)
            Else
                _Value = CType(Me.cbMainPreparator.SelectedItem, customEntity).uuid
                _addfn(_Value, _metauuid, False, False, False, False, True)
            End If
        End If

        'справочник Допрепарация подробно
        If (Not Me.cbRePrepDetails.SelectedItem Is Nothing) Then
            _metauuid = My.Settings.RePreparingDetailsMetaUUID
            If CType(Me.cbRePrepDetails.SelectedItem, customEntity).uuid = "" Then
                'удалить (не добавлять) атрибут
                _deletefn(_metauuid)
            Else
                _Value = CType(Me.cbRePrepDetails.SelectedItem, customEntity).uuid
                _addfn(_Value, _metauuid, False, False, False, False, True)
            End If
        End If


        ''справочник поставщик
        If (Not Me.cbSupplier.SelectedItem Is Nothing) Then
            If CType(Me.cbSupplier.SelectedItem, company).uuid = "" Then
                ToGood.supplierUuid = Nothing
            Else

                ToGood.supplierUuid = CType(Me.cbSupplier.SelectedItem, company).uuid
            End If
        End If


        ' справочник Оформитель товара (сотрудник)
        'If (Not Me.___.SelectedItem Is Nothing) AndAlso Not (CType(Me._____.SelectedItem, customEntity).uuid = "") Then
        '    _Value = CType(Me._____.SelectedItem, customEntity).uuid
        ' _metauuid = My.Settings.ThisGoodMakerMetaUUID
        '_fn(_Value, _metauuid, False, False, False, False, True)
        'End If



        '======================
        Return _new.ToArray
    End Function

    ''' <summary>
    ''' добавляет этикетку в список печати
    ''' </summary>
    ''' <param name="item"></param>
    ''' <param name="copies"></param>
    ''' <remarks></remarks>
    Private Sub AddLabelToPrint(item As iMoySkladDataProvider.strGoodMapQty, Optional copies As Integer = 1)
        Dim _size As SizeF = Nothing
        If oLabelImageList Is Nothing Then
            oLabelImageList = New List(Of KeyValuePair(Of Image, SizeF))
        End If
        Dim _img = clsApplicationTypes.CreateEANLabel(SampleNumber:=item.ActualSampleNumber.ShotCode, SampleName:=item.Name, SamplePrice:=0, IsArticul:=item.IsArticul)

        For i = 1 To copies
            oLabelImageList.Add(clsApplicationTypes.CreatePrintableLabel(_img))
            clsApplicationTypes.BeepYES()
        Next

        Me.btPrintLabel.Text = "Печать этикеток (" & oLabelImageList.Count & ")"
    End Sub

    ' ''' <summary>
    ' ''' добавляет товар в список номеров
    ' ''' </summary>
    ' ''' <param name="goodQtyCollection"></param>
    ' ''' <remarks></remarks>
    'Private Sub AddGoodToList(goodQtyCollection As clsGoodLocation.strGoodQty())
    '    ''запрос имени на серваке
    '    'Dim _nGood = New clsMSGood
    '    '' _nGood.Code = code
    '    'Dim _result As New List(Of good)
    '    'Dim _foundstatus As Integer = oManager.FindGoods(number.ShotCode, "", "", _result)
    '    '' Dim _result = oManager.FindGoods(New good With {.code = code}, _foundstatus)

    '    'Select Case _foundstatus
    '    '    Case 0
    '    '        'не нашли
    '    '        _nGood.Name = ""
    '    '    Case 1
    '    '        'ок нашли
    '    '        _nGood = New clsMSGood(_result(0))

    '    '    Case Is > 1
    '    '        'несколько товаров с этим кодом
    '    '        Dim _res = From c In _result Where String.Equals(c.code, code) Select c

    '    '        If _res.Count = 0 Then
    '    '            'не нашли
    '    '            _nGood.Name = ""
    '    '        Else
    '    '            MsgBox("Найдено несколько товаров с этим кодом. Будет взято название первого.", vbInformation)
    '    '            _nGood = New clsMSGood(_result(0))
    '    '        End If

    '    '    Case Else
    '    '        _nGood.Name = ""
    '    'End Select



    '    'number.Tag = _nGood

    '    ''рисуем этикетку
    '    'If _nGood.EANLabel Is Nothing Then

    '    '    'рисуем на копии панели
    '    '    Dim _pngr = pnLabel.CreateGraphics
    '    '    Dim _koef = 8
    '    '    Dim _lblimg = New Bitmap(pnLabel.Width * _koef, pnLabel.Height * _koef, _pngr)
    '    '    Me.DrawLabel(Graphics.FromImage(_lblimg), Color.White, _koef)

    '    '    Dim _dx = 25 * _koef
    '    '    Dim _dy = 5 * _koef
    '    '    Dim _w = pnLabel.Width * _koef - _dx - 5 * _koef
    '    '    Dim _h = pnLabel.Height * _koef - _dy
    '    '    Dim _lblRect = New Rectangle(_dx, 0, _w + 2 * _koef, _h + 2 * _koef)

    '    '    'обрежем картинку
    '    '    Dim _outimg = New Bitmap(_w, _h)
    '    '    Dim _outRect = New Rectangle(0, 0, _w, _h)
    '    '    Dim _outgr = Graphics.FromImage(_outimg)
    '    '    _outgr.Clear(Color.White)
    '    '    _outgr.DrawImage(_lblimg, _outRect, _lblRect, GraphicsUnit.Pixel)
    '    '    _outgr.DrawRectangle(Pens.Black, _outRect)
    '    '    _nGood.EANLabel = _outimg
    '    'End If

    'End Sub


    ''' <summary>
    ''' _koeff = масштаб
    ''' </summary>
    ''' <param name="gr"></param>
    ''' <param name="Solidcolor"></param>
    ''' <param name="_koeff"></param>
    ''' <remarks></remarks>
    Private Sub DrawLabel(gr As Graphics, Solidcolor As Color, Optional _koeff As Integer = 1)
        gr.Clear(Solidcolor)
        Dim _item As iMoySkladDataProvider.strGoodMapQty
        If Me.lbxnumbers.SelectedItem Is Nothing Then
            If Me.lbxSelectedNumbers.SelectedItem Is Nothing Then
                Return
            Else
                _item = CType(Me.lbxSelectedNumbers.SelectedItem, iMoySkladDataProvider.strGoodMapQty)
            End If
        Else
            _item = CType(Me.lbxnumbers.SelectedItem, iMoySkladDataProvider.strGoodMapQty)
        End If

        Dim _img = clsApplicationTypes.CreateEANLabel(_item.ActualSampleNumber.EAN13.ToString, _item.Name, "")
        gr.DrawImage(_img, gr.VisibleClipBounds)
    End Sub


    Private Sub SetUserPreferences()
        Me.cbTargetStores.Refresh()
    End Sub

    ''' <summary>
    ''' treename = systematica, keyname=ammonites.tree
    ''' </summary>
    ''' <param name="treename"></param>
    ''' <param name="keyname"></param>
    ''' <param name="filepath"></param>
    ''' <remarks></remarks>
    Private Sub LoadNames(treename, keyname, filepath)
        'показат сплеш
        If oSplashscreen1.Visible = False Then
            oSplashscreen1.Show()
            Application.DoEvents()
        End If

        Dim _result As String() = Nothing
        'использование сервисов
        'выполняем вызов из сервиса
        ' dim _param as object={[parameters_list]}
        'если делегата нет, то сервис недоступен
        If Not Global.Service.clsApplicationTypes.DelegateStoreGetTreeLeafNodeNames Is Nothing Then
            'сервис зарегестрирован - вызываем 
            _result = Global.Service.clsApplicationTypes.DelegateStoreGetTreeLeafNodeNames.Invoke(filepath, treename, oCurrentCulture)
        Else
            'Return Nothing
        End If


        'загрузить имена в лист
        Me.cbDBNames.Items.Clear()
        If Not _result Is Nothing Then
            'занести в буфер и в список материала
            clsApplicationTypes.CurrentNamesList.Add(keyname, _result)
            Me.cbDBNames.Items.AddRange(clsApplicationTypes.CurrentNamesList.Item(keyname))
        End If
        Me.oSplashscreen1.Hide()
    End Sub

#End Region

#Region "фоновые операции в другом потоке"
    Private Sub backgroundWorker1_RunWorkerCompleted(
       ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs) _
       Handles oBackgroundWorkerMC.RunWorkerCompleted

        ' First, handle the case where an exception was thrown.
        If (e.Error IsNot Nothing) Then
            MessageBox.Show("Ошибка асинхронной операции: " & e.Error.Message)
            Me.ToolStripStatusLabel1.Text = ""
        ElseIf e.Cancelled Then
            ' Next, handle the case where the user canceled the 
            ' operation.
            ' Note that due to a race condition in 
            ' the DoWork event handler, the Cancelled
            ' flag may not have been set, even though
            ' CancelAsync was called.
            MsgBox("Операция прервана пользователем", vbInformation)
            Me.ToolStripStatusLabel1.Text = ""
        Else
            ' Finally, handle the case where the operation succeeded.
            'отобразим результат операции
            Me.ToolStripStatusLabel1.Text = e.Result.ToString() & " Проверь кол-во запросом."
        End If

    End Sub 'backgroundWorker1_RunWorkerCompleted

    ' This event handler updates the progress bar.
    Private Sub backgroundWorker1_ProgressChanged(
    ByVal sender As Object, ByVal e As ProgressChangedEventArgs) _
    Handles oBackgroundWorkerMC.ProgressChanged
        Me.ProgressBar1.Value = e.ProgressPercentage
    End Sub

    ' This event handler is where the actual work is done.
    Private Sub backgroundWorker1_DoWork(
    ByVal sender As Object,
    ByVal e As DoWorkEventArgs) _
    Handles oBackgroundWorkerMC.DoWork
        Dim _answermsg As String = ""
        ' Get the BackgroundWorker object that raised this event.
        Dim worker As BackgroundWorker =
            CType(sender, BackgroundWorker)

        e.Result = e.Argument.Invoke()

    End Sub 'backgroundWorker1_DoWork

#End Region

#Region "Печать"
    Private Sub pnLabel_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles pnLabel.Paint
        DrawLabel(e.Graphics, Control.DefaultBackColor)
    End Sub

    ''' <summary>
    ''' добавить к печати
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btAddLabel_Click(sender As System.Object, e As System.EventArgs) Handles btAddLabel.Click
        If Me.lbxnumbers.SelectedItem Is Nothing Then Exit Sub
        Me.AddLabelToPrint(CType(Me.lbxnumbers.SelectedItem, iMoySkladDataProvider.strGoodMapQty), Me.nudLabelsCountCopy.Value)
    End Sub

    Private Sub btPrintLabel_Click(sender As System.Object, e As System.EventArgs) Handles btPrintLabel.Click
        If oLabelImageList Is Nothing Then Exit Sub
        Dim _unit = GraphicsUnit.Millimeter

        Dim _pd As New Printing.PrintDocument
        Dim _LabelPages As New List(Of clsPage)
        _pd.DocumentName = "Этикетки"

        'тут надо добавить настройку принтера
        Select Case Me.PrintDialog1.ShowDialog()
            Case Windows.Forms.DialogResult.OK
                _pd.PrinterSettings = Me.PrintDialog1.PrinterSettings
                '_pd.DefaultPageSettings.Margins = New Margins(50, 50, 50, 50)

                Dim _printbounds = _pd.PrinterSettings.CreateMeasurementGraphics
                _printbounds.PageUnit = _unit
                'теперь класс размещения этикеток
                Dim _page = New clsPage(_printbounds.VisibleClipBounds)
                _LabelPages.Add(_page)

                'тут формируем обьект для печати
                For Each _str In Me.oLabelImageList

                    'добавить в существующий незаполненный
                    Dim _result = (From c In _LabelPages Where c.IsFull = False Select c).FirstOrDefault

                    If _result Is Nothing Then
                        'все полны
                        'создать новую страницу
                        'GoTo cr
                        _page = New clsPage(_printbounds.VisibleClipBounds)
                        _LabelPages.Add(_page)
                        _page.AddLabel(_str)
                    Else
                        'пробуем
                        If _result.AddLabel(_str) = False Then
                            'не влазит
                            'создать новую страницу
                            'GoTo cr
                            _page = New clsPage(_printbounds.VisibleClipBounds)
                            _LabelPages.Add(_page)
                            _page.AddLabel(_str)
                        End If
                    End If
                Next

                Dim _index As Integer = 0

                AddHandler _pd.PrintPage, Sub(senderv As Object, ev As PrintPageEventArgs)

                                              Dim _pagecount = _LabelPages.Count
                                              If _pagecount = 0 Then Exit Sub

                                              'print page
                                              _LabelPages(_index).DrawLabels(ev.Graphics, _unit)
                                              _index += 1
                                              If (_index + 1) > _pagecount Then ev.HasMorePages = False : _index = 0 : Exit Sub

                                              ev.HasMorePages = True
                                          End Sub

                Me.PrintPreviewDialog1.Document = _pd

                Select Case PrintPreviewDialog1.ShowDialog()
                    Case Windows.Forms.DialogResult.OK

                End Select
                ' PrintPreviewDialog1.Close()
        End Select

    End Sub

    Private Sub btClearPrintJob_Click(sender As System.Object, e As System.EventArgs) Handles btClearPrintJob.Click
        If oLabelImageList Is Nothing Then Exit Sub

        oLabelImageList.Clear()

        Me.btPrintLabel.Text = "Печать этикеток"
    End Sub

    Private Sub btAddAllNumbers_Click(sender As System.Object, e As System.EventArgs) Handles btAddAllNumbers.Click
        If Me.lbxnumbers.DataSource Is Nothing Then Return
        For Each _item In Me.lbxnumbers.DataSource
            Me.AddLabelToPrint(_item)
        Next
    End Sub

    Private Sub btShowLabelAny_Click(sender As Object, e As EventArgs) Handles btShowLabelAny.Click, btShowLabelAny2.Click
        If Not Me.tbCtlMain.SelectedTab Is tpMain Then
            Me.tbCtlMain.SelectedTab = tpMain
        End If
        ShowLabelWithPrice()
    End Sub

    Private Sub btLabel_Click(sender As System.Object, e As System.EventArgs) Handles btLabel.Click
        ShowLabelWithoutPrice()
        PrintLabel(sender, e)
    End Sub
    ''' <summary>
    ''' печать этикетки
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub PrintLabel(sender As System.Object, e As System.EventArgs)
        If Me.pbLabel.Image Is Nothing Then Return
        Dim _lbl = clsApplicationTypes.CreatePrintableLabel(pbLabel.Image)
        Dim _pd = Service.clsApplicationTypes.PrintLabel({_lbl}.ToList, oNeedResetPrinter)
        If Not _pd Is Nothing Then
            _pd.Print()
            oNeedResetPrinter = False
        Else
            MsgBox("Не удалось напечатать документ", vbCritical)
        End If
        Me.btNewNumber.Focus()
    End Sub
    ''' <summary>
    ''' показать этикетку без цены
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ShowLabelWithoutPrice()
        If oCurrentGood Is Nothing Then Me.pbLabel.Image = Nothing : Me.pbLabel2.Image = Nothing : Return

        Dim _img = clsApplicationTypes.CreateEANLabel(oCurrentGood.AnyCode, oCurrentGood.Name, "", Me.oCurrentGood.CodeIsArticul)
        Me.pbLabel.Image = _img
        Me.pbLabel2.Image = _img
    End Sub

    ''' <summary>
    ''' показать этикетку с ценами
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ShowLabelWithPrice()
        If oCurrentGood Is Nothing Then Me.pbLabel.Image = Nothing : Me.pbLabel2.Image = Nothing : Return
        Dim _isInvoice As Boolean = False
        Dim _price = Me.GetCurrentPriceString(_isInvoice)

        Dim _img = clsApplicationTypes.CreateEANLabel(Me.oCurrentGood.AnyCode, oCurrentGood.Name, _price, Me.oCurrentGood.CodeIsArticul, _isInvoice)
        Me.pbLabel.Image = _img
        Me.pbLabel2.Image = _img
    End Sub

    ''' <summary>
    ''' вернет строку цены для этикетки
    ''' </summary>
    ''' <param name="IsInvoice"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetCurrentPriceString(Optional ByRef IsInvoice As Boolean = False) As String
        If oCurrentGood Is Nothing Then Return ""
        IsInvoice = False
        Dim _price As String = ""
        Select Case Me.cbPrintCurrency.SelectedIndex
            Case 0
                If Me.oCurrentGood.AllPrices.Rus_show = 0 Then Return ""
                _price = Me.oCurrentGood.AllPrices.Rus_show.ToString & "RUR"
            Case 1
                If Me.oCurrentGood.AllPrices.Eu_show = 0 Then Return ""
                _price = Me.oCurrentGood.AllPrices.Eu_show.ToString & "EUR"
            Case 2
                If Me.oCurrentGood.AllPrices.eBay = 0 Then Return ""
                _price = Me.oCurrentGood.AllPrices.eBay.ToString & "USD"
            Case 3
                If Me.oCurrentGood.AllPrices.Invoce = 0 Then Return ""
                _price = Me.oCurrentGood.AllPrices.Invoce.ToString & Me.oCurrentGood.AllPrices.InvoceCurrency
                IsInvoice = True
            Case 4
                If clsApplicationTypes.ReplaceDecimalSplitter(Me.tbBuyTargetValue) = 0 Then Return ""
                _price = Me.tbBuyTargetValue.Text & Me.cbBuyTargetCurrency.Text
            Case Else
                Debug.Fail("Добавь обработку!")
                _price = ""
        End Select
        ''печатаем входящую
        'If cbxIncomingPrice.Checked Then
        '    _price = Me.tbBuyTargetValue.Text & Me.cbBuyTargetCurrency.Text
        '    If Me.tbBuyTargetValue.Text = "" OrElse Me.tbBuyTargetValue.Text = "0" Then _price = ""
        'End If

        ''печатаем инвойсную
        'If cbxInvoiceLabel.Checked Then
        '    _price = Me.tbInvoice.Text & Me.cbInvoceCurrency.Text
        '    If Me.tbInvoice.Text = "" OrElse Me.tbInvoice.Text = "0" Then _price = ""
        'End If
        Return _price
    End Function



    Private Sub btLabelWithPrice_Click(sender As System.Object, e As System.EventArgs) Handles btLabelWithPrice.Click
        ShowLabelWithPrice()
        PrintLabel(sender, e)
    End Sub

    Private Sub btPrinterClear_Click(sender As System.Object, e As System.EventArgs) Handles btPrinterClear.Click
        Me.oNeedResetPrinter = True
    End Sub


#End Region

#Region "события ЭУ с малой логикой"
    Private Sub fmAnyForBarcode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            'цифра
            'очистить поле и начать ввод
            Me.tbNumber.Text = e.KeyChar.ToString
            Me.tbNumber.Focus()
        End If
    End Sub

    Private Sub btGetArticulList_Click(sender As System.Object, e As System.EventArgs) Handles btGetArticulList.Click
        FindArticul()
    End Sub
    Private Sub dgv_Goods_DefaultValuesNeeded(sender As Object, e As System.Windows.Forms.DataGridViewRowEventArgs) Handles dgv_Goods.DefaultValuesNeeded
        With e.Row
            .Cells(0).Value = oCurrentGood.Code
            .Cells(1).Value = oCurrentGood.Articul
            .Cells(2).Value = oCurrentGood.Name
        End With
    End Sub

    Private Sub lbArticuls_DoubleClick(sender As Object, e As System.EventArgs) Handles lbArticuls.DoubleClick
        Dim _curr = Me.dgv_Goods.CurrentRow
        _curr.Cells(1).Value = lbArticuls.SelectedValue
    End Sub

    Private Sub lbArticuls_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lbArticuls.SelectedIndexChanged
        If lbArticuls.SelectedItem Is Nothing Then Return
        If Me.cbxLossEnable.Checked Then
            Dim _good As clsMSGood = Me.lbArticuls.SelectedItem
            Me.tbLossSourceArticul.Text = _good.Articul
        End If
    End Sub

    Private Sub dgv_Goods_UserAddedRow(sender As Object, e As System.Windows.Forms.DataGridViewRowEventArgs) Handles dgv_Goods.UserAddedRow
        oNewGoodsCount += 1
    End Sub

    Private Sub dgv_Goods_UserDeletedRow(sender As Object, e As System.Windows.Forms.DataGridViewRowEventArgs) Handles dgv_Goods.UserDeletedRow
        oNewGoodsCount -= 1
    End Sub



    Private Sub lbxSlots_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lbxnumbers.SelectedIndexChanged
        If Me.lbxnumbers.SelectedItem Is Nothing Then Return
        Me.pnLabel.Invalidate()
        ''а тут мы можем увидеть фото и прочее))
        'If lbxnumbers.SelectedItem.tag Is Nothing Then Return
        'Me.PictureBox1.Image = lbxnumbers.SelectedItem.tag.eanlabel
        Dim _item As iMoySkladDataProvider.strGoodMapQty = Me.lbxnumbers.SelectedItem
        Me.PictureBox1.Image = clsApplicationTypes.SamplePhotoObject.GetMainImage(clsFilesSources.Arhive, _item.ActualSampleNumber, True)
    End Sub




    Private Sub btHide_Click(sender As System.Object, e As System.EventArgs) Handles btHide.Click
        ClearAll()
        Me.Hide()
    End Sub

    Private Sub btServiceForm_Click(sender As System.Object, e As System.EventArgs) Handles btServiceForm.Click
        Dim _fm As New fmAdminTest
        _fm.Show()
    End Sub

    Private Sub Label1_Click(sender As System.Object, e As System.EventArgs) Handles Label1.MouseClick
        If Not clsRestMS_service.GetDigiKey Is Nothing Then
            clsRestMS_service.GetDigiKey.connect(Me.tbNumber)
        End If
    End Sub


    Private Sub Label51_Click(sender As System.Object, e As System.EventArgs) Handles Label51.MouseClick
        If Not clsRestMS_service.GetDigiKey Is Nothing Then
            clsRestMS_service.GetDigiKey.connect(Me.tbPRICE1)
        End If
    End Sub
    Private Sub Label52_Click(sender As System.Object, e As System.EventArgs) Handles Label52.MouseClick
        If Not clsRestMS_service.GetDigiKey Is Nothing Then
            clsRestMS_service.GetDigiKey.connect(Me.tbPRICE2)
        End If
    End Sub

    Private Sub Label53_Click(sender As System.Object, e As System.EventArgs) Handles Label53.MouseClick
        If Not clsRestMS_service.GetDigiKey Is Nothing Then
            clsRestMS_service.GetDigiKey.connect(Me.tbPRICE3)
        End If
    End Sub

    Private Sub Label54_Click(sender As System.Object, e As System.EventArgs) Handles Label54.MouseClick
        If Not clsRestMS_service.GetDigiKey Is Nothing Then
            clsRestMS_service.GetDigiKey.connect(Me.tbPRICE4)
        End If
    End Sub
    Private Sub Label55_Click(sender As System.Object, e As System.EventArgs) Handles Label55.MouseClick
        If Not clsRestMS_service.GetDigiKey Is Nothing Then
            clsRestMS_service.GetDigiKey.connect(Me.tbPRICE5)
        End If
    End Sub

    Private Sub Label56_Click(sender As System.Object, e As System.EventArgs) Handles Label56.MouseClick
        If Not clsRestMS_service.GetDigiKey Is Nothing Then
            clsRestMS_service.GetDigiKey.connect(Me.tbPRICE6)
        End If
    End Sub

    Private Sub Label57_Click(sender As System.Object, e As System.EventArgs) Handles Label57.MouseClick
        If Not clsRestMS_service.GetDigiKey Is Nothing Then
            clsRestMS_service.GetDigiKey.connect(Me.tbPRICE7)
        End If
    End Sub
    Private Sub Label2_Click(sender As System.Object, e As System.EventArgs) Handles Label2.MouseClick
        If Not clsRestMS_service.GetDigiKey Is Nothing Then
            clsRestMS_service.GetDigiKey.connect(Me.tbArticul)
        End If
    End Sub

    Private Sub Label18_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Label18.MouseClick
        If Not clsRestMS_service.GetDigiKey Is Nothing Then
            clsRestMS_service.GetDigiKey.connect(Me.tbLossSourceArticul)
        End If
    End Sub

    Private Sub tbShippingPrice_MouseDoubleClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles tbShippingPrice.MouseDoubleClick
        If Not clsRestMS_service.GetDigiKey Is Nothing Then
            clsRestMS_service.GetDigiKey.connect(Me.tbShippingPrice)
        End If
    End Sub

    Private Sub Label21_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Label21.MouseClick
        If Not clsRestMS_service.GetDigiKey Is Nothing Then
            clsRestMS_service.GetDigiKey.connect(Me.tbLossQty)
        End If
    End Sub

    Private Sub btOption_Click(sender As System.Object, e As System.EventArgs) Handles btOption.Click
        Dim _fm As New fmOptions(oManager)
        _fm.ShowDialog()
    End Sub

    Private Sub Label36_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Label36.MouseClick
        If Not clsRestMS_service.GetDigiKey Is Nothing Then
            clsRestMS_service.GetDigiKey.connect(Me.tbPrepTime)
        End If
    End Sub

    Private Sub Label38_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Label38.MouseClick
        If Not clsRestMS_service.GetDigiKey Is Nothing Then
            clsRestMS_service.GetDigiKey.connect(Me.tbExpedNumber)
        End If
    End Sub

    Private Sub Label42_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Label42.MouseClick
        If Not clsRestMS_service.GetDigiKey Is Nothing Then
            clsRestMS_service.GetDigiKey.connect(Me.tbBuyCost)
        End If
    End Sub
    Private Sub Label48_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Label48.MouseClick
        If Not clsRestMS_service.GetDigiKey Is Nothing Then
            clsRestMS_service.GetDigiKey.connect(Me.tbFullPrepCost)
        End If
    End Sub
    Private Sub Label45_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Label45.MouseClick
        If Not clsRestMS_service.GetDigiKey Is Nothing Then
            clsRestMS_service.GetDigiKey.connect(Me.tbPrepCost)
        End If
    End Sub

    Private Sub Label40_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Label40.MouseClick
        If Not clsRestMS_service.GetDigiKey Is Nothing Then
            clsRestMS_service.GetDigiKey.connect(Me.tbPrepTimeAdd)
        End If
    End Sub

    Private Sub WeightLabel_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles WeightLabel.MouseClick
        If Not clsRestMS_service.GetDigiKey Is Nothing Then
            clsRestMS_service.GetDigiKey.connect(Me.tbWeight)
        End If
    End Sub

    Private Sub RawNumberLabel_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles RawNumberLabel.MouseClick
        If Not clsRestMS_service.GetDigiKey Is Nothing Then
            clsRestMS_service.GetDigiKey.connect(Me.tbRawNumber)
        End If
    End Sub


    ''' <summary>
    ''' покажет предрассчет ЗП
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tbFullPrepCost_MouseEnter(sender As Object, e As EventArgs) Handles tbFullPrepCost.MouseEnter
        Dim _totalHour As Decimal = 0
        Dim _totalPay As Decimal = 0
        Dim _mess As String = ""
        If clsMoyScladManager.ParsePrepString(tbPrepList.Text, _totalHour, _totalPay) Then

            Dim _friend As Decimal = 0
            Dim _fp = PrepCalculate(_totalPay, , , _friend)

            oBuyToolTip.ToolTipTitle = "Рассчет по препарации"
            _mess = String.Format("Налик {0} руб.; Для ребят {2} руб.; к рассчету {1} руб.", _totalPay, _fp, _friend)
        Else
            'неразборчивая строка
            _totalPay = clsApplicationTypes.ReplaceDecimalSplitter(tbPrepCost)
            Dim _friend As Decimal = 0
            Dim _fp = PrepCalculate(_totalPay, , , _friend)

            oBuyToolTip.ToolTipTitle = "Рассчет по препарации"
            _mess = String.Format("Налик {0} руб.; Стоимость для ребят {2} руб.; к рассчету {1} руб.", _totalPay, _fp, _friend)
        End If
        oBuyToolTip.Show(_mess, tbFullPrepCost)
    End Sub

    Private Sub tbPrepTime_MouseLeave(sender As Object, e As EventArgs) Handles tbFullPrepCost.MouseLeave
        oBuyToolTip.Hide(tbFullPrepCost)
    End Sub

    ''' <summary>
    ''' сохранить при измениении
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>

    Private Sub Element_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbExpedition.SelectedIndexChanged, cbSupplier.SelectedIndexChanged, cbRePrepDetails.SelectedIndexChanged, cbxNeedMakeLabel.CheckedChanged, cbxInCommission.CheckedChanged, cbxNeedPackaging.CheckedChanged, cbxNeedRepair.CheckedChanged, tbExpedNumber.KeyPress, tbExpeditInfo.KeyPress, tbMyTreeCode.TextChanged
        If Not oRedKeyOff Then
            Me.MarkAsNeedSaved()
        End If
    End Sub


    Private Sub btAddNameFromTree_Click(sender As System.Object, e As System.EventArgs) Handles btAddNameFromTree.Click
        Me.oCurrentGood.Name = Me.oCurrentGood.Name & ", " & Me.cbDBNames.Text
        Me.bsCurrentGood.ResetCurrentItem()
        Me.MarkAsNeedSaved()
    End Sub

    Private Sub tbNumber_MouseDoubleClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles tbNumber.MouseDoubleClick
        If Not tbArticul.Text = "" Then
            Me.tbNumber.Text = ""
        End If
    End Sub

    Private Sub tbArticul_MouseDoubleClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles tbArticul.MouseDoubleClick
        If Not tbNumber.Text = "" Then
            Me.tbArticul.Text = ""
        End If
    End Sub


    Private Sub cbxWriteAdditionalPrices_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles cbxWriteAdditionalPrices.CheckedChanged
        If cbxWriteAdditionalPrices.Checked = True Then
            Me.tbShippingPrice.Enabled = True
        End If
    End Sub

    Private Sub tbQty_MouseDoubleClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles tbQty.MouseDoubleClick
        If Not clsRestMS_service.GetDigiKey Is Nothing Then
            clsRestMS_service.GetDigiKey.connect(Me.tbQty)
        End If
    End Sub


    Private Sub tbLossSourceArticul_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tbLossSourceArticul.KeyPress, tbLossSourceName.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Dim _code = ShotCodeConverter_Net.clsCode.CreateInstance(tbLossSourceArticul.Text)
            If Not _code.CodeType = ShotCodeConverter_Net.clsCode.emCodeType.Incorrect Then
                tbLossSourceArticul.Text = _code.ShotCode
                Me.btGetLossSource_Click(sender, e)
            Else
                MsgBox("Неправильный код товара! Не удалось распознать.", vbCritical)
            End If
        End If
    End Sub
#End Region

#Region "Поиск, очистка, добавление, карточка товара"
    ''' <summary>
    ''' найти товар в справочнике
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btSearchInSklad_Click(sender As System.Object, e As System.EventArgs) Handles btSearchInSklad.Click
        '------------очистка перед запросом--
        Dim _currNum = Me.tbNumber.Text
        Dim _currArt = Me.tbArticul.Text
        Dim _currName = Me.tbName.Text
        Dim _currFossNum = Me.tbRawNumber.Text

        ClearAll()

        Me.tbNumber.Text = _currNum
        Me.tbArticul.Text = _currArt
        Me.tbName.Text = _currName
        Me.tbRawNumber.Text = _currFossNum

        Dim _stringcode As String = ""

        'Если ввели штрих-код
        '--------------------
        If Me.tbNumber.Text.Length = 13 Then
            oSampleNumber = clsApplicationTypes.clsSampleNumber.CreateFromString(Me.tbNumber.Text)
            If oSampleNumber.CodeIsCorrect Then
                Me.tbNumber.Text = oSampleNumber.ShotCode
            End If
        End If

        If Me.tbArticul.Text.Length = 13 Then
            oSampleNumber = clsApplicationTypes.clsSampleNumber.CreateFromString(Me.tbArticul.Text)
            If oSampleNumber.CodeIsCorrect Then
                Me.tbArticul.Text = oSampleNumber.ShotCode
            End If
        End If

        If Me.tbBarCode.Text.Length = 13 Then
            oSampleNumber = clsApplicationTypes.clsSampleNumber.CreateFromString(Me.tbBarCode.Text)
            If oSampleNumber.CodeIsCorrect Then
                Me.tbBarCode.Text = oSampleNumber.EAN13
                If Me.tbNumber.Text.Length = 0 And Me.tbArticul.Text.Length = 0 Then
                    'поиск по штриху
                    Me.tbNumber.Text = oSampleNumber.ShotCode
                End If
            Else
                Me.tbBarCode.Text = ""
            End If
        End If
        '----------------------------

        Me.oCurrentGood.Code = Me.tbNumber.Text
        Me.oCurrentGood.Articul = Me.tbArticul.Text
        Me.oCurrentGood.Barcode = Me.tbBarCode.Text
        Me.oCurrentGood.Name = Me.tbName.Text
        '-------------------------
        CurrentGoodRequest()

    End Sub


    Private Sub ClearAll()
        oSampleNumber = Nothing
        bs_Goods_dgv_Goods.Clear()
        Me.UcPriceCalc_clsPriceDataBindingSource.Clear()
        oCurrentGood = Nothing
        bsCurrentGood.Clear()
        oCurrentLossGood = Nothing
        Me.pbImage.Image = Nothing
        oCurrentPrices = New ucPriceCalc.clsPriceData
        '-------------data
        lbArticuls.DataSource = Nothing
        dgv_Goods.DataSource = Nothing
        bs_Curr_slot_location.Clear()
        bs_Curr_stor_location.Clear()
        cbLossLocations.DataSource = Nothing
        bs_GoodLocation.Clear()
        Me.SlotGoodBindingSource.Clear()

        If Me.UcPriceCalc1.Enabled Then
            Me.UcPriceCalc1.ClearAll()
        End If

        '--------indexes
        cbRetailTargetCurrency.SelectedIndex = -1
        cbInvoceCurrency.SelectedIndex = -1
        cbBuyTargetCurrency.SelectedIndex = -1
        '----------enabled
        'выбор вкладки по умолчанию
        SelectFixTabs()


        If Not ToolStripStatusLabel1.Text = "Фоновая работа..." Then
            ToolStripStatusLabel1.Text = ""
        End If
        cbUom.SelectedIndex = -1
        cbxAddIfExists.Enabled = False
        btSearchInSklad.Enabled = True
        btAuctionUncompleted.Enabled = False
        btAuctionCompleted.Enabled = False
        Me.UcGoodLabel1.Clear()

        'операции с товаром
        btAddGoodToWare.Enabled = False
        Me.btAddGoodToWare.BackColor = Color.FromKnownColor(KnownColor.Control)
        btCreateGood.Enabled = False
        Me.btCreateGood.BackColor = Color.FromKnownColor(KnownColor.Control)
        tbFullPrepCost.BackColor = Color.White
        Me.tbQty.Enabled = False
        Me.cbUom.Enabled = False
        Me.btOnePcs.Enabled = False
        Me.tbShippingPrice.Enabled = False

        oCurrentBuyCostCurrecy = Nothing
        oCurrentBuyCurrency = Nothing
        oCurrentInvoceCurrency = Nothing
        oCurrentRetailCurrency = Nothing

        btSearchInSklad.Enabled = True
        cbTargetStores.Enabled = True
        cbSlot.Enabled = True
        For Each ctl In Me.GroupBox3.Controls
            ctl.enabled = False
        Next
        Me.tbBuyPriceGoodCurrency.Enabled = False
        Me.tbBuyPriceGood.Enabled = False
        Me.tbBuyPriceGood.Text = ""
        'If Not clsApplicationTypes.GetAccess("цена инвойса и закупки") Then
        '    Me.cbxIncomingPrice.Checked = False
        '    Me.cbxInvoiceLabel.Checked = False
        'End If


        '------text
        Me.lbBuildDescription.Text = ""
        Me.lbLossUom.Text = "ед."
        rtbDescription.Text = ""
        tbRetailTargetValue.Text = ""
        tbBuyTargetValue.Text = ""

        tbLossSourceName.Text = ""
        tbLossSourceArticul.Text = ""
        tbLossQty.Text = ""
        lbAuctionStatus.Text = ""

        Me.cbBoxTypes.SelectedIndex = -1
        Me.tbBoxType.Text = ""
        Me.tbPrepList.Text = ""
        Me.tbBuyCost.Text = ""
        Me.tbFullPrepCost.Text = ""
        Me.tbPrepCost.Text = ""
        Me.tbPrepTime.Text = ""
        Me.tbPrepTimeAdd.Text = ""
        Me.cbPreparatorAdd.SelectedIndex = -1
        Me.cbSchemePrice.SelectedIndex = -1

        '-----image
        Me.tbQty.BackColor = Color.White
        Me.btAddGoodToWare.BackColor = Control.DefaultBackColor
        pbLabel.Image = Nothing
        pbLabel2.Image = Nothing
        '-----checked
        cbxSetRetail.Checked = False
        cbxSetBuy.Checked = False
        cbxAddIfExists.Checked = False
        cbxLossEnable.Checked = False
        cbxWithoutSlot.Checked = False
        '----other
        oWillNewGoodFlag = False
        '----------------------

        '----------------------

        Me.cbxNeedMakeLabel.Checked = False
        Me.cbxInCommission.Checked = False

        Me.tbBuyPriceGoodCurrency.Text = ""
        Me.tbInvoice.Text = ""
        Me.cbxInvoice.Checked = False
        Me.cbInvoceCurrency.SelectedIndex = -1
        Me.tbRetailTargetValue.Enabled = False
        Me.cbRetailTargetCurrency.Enabled = False
        Me.tbBuyTargetValue.Enabled = False
        Me.cbBuyTargetCurrency.Enabled = False
        Me.tbInvoice.Enabled = False
        Me.btIncomingCalculate.Enabled = False
        Me.cbInvoceCurrency.Enabled = False
        '--------------
        Me.tbRawNumber.Text = ""
        Me.cbMainPreparator.SelectedIndex = -1
        Me.cbPreparatorAdd.SelectedIndex = -1
        Me.cbExpedition.SelectedIndex = -1
        Me.cbInExpedition.Checked = False
        Me.tbExpedNumber.Text = ""
        Me.tbExpeditInfo.Text = ""
        Me.cbxInCommission.Checked = False
        Me.tbBuyCost.Text = ""
        Me.cbSupplier.SelectedIndex = -1


        oCurrentRetailCurrency = Nothing
        Me.cbxNeedPhotos.Checked = False
        Me.cbxNeedPackaging.Checked = False
        Me.cbxNeedRepair.Checked = False
        Me.cbxNeedRePrep.Checked = False
        Me.cbRePrepDetails.SelectedIndex = -1


        ' Me.cbxIncomingPrice.Checked = False
        oWillNewGoodFlag = False
        Me.btSaveChanges.Enabled = True
        Me.btSaveChanges.BackColor = Control.DefaultBackColor
        Me.btSaveChanges.Tag = False

        Me.cbxAddIfExists.Checked = False
        Me.cbxAddIfExists.Enabled = False
        Me.cbxSetRetail.Enabled = True

        Me.rtbDescription.Enabled = False
        Me.lbWarning.Text = ""

        'заполнит коллекцию oCurrentQueredGoods
        Me.bs_GoodLocation.ResetBindings(False)

        Me.oCurrentGood = New clsMSGood



        'показать тариф
        If clsApplicationTypes.GetAccess("цена инвойса и закупки") Then
            Me.tbWeightTariff.Enabled = True
            cbWeightTariff.Enabled = True
            cbWeightTariff.SelectedIndex = 0
            Me.cbWeightTariff_SelectedIndexChanged(Me.cbWeightTariff, EventArgs.Empty)
        Else
            Me.tbWeightTariff.Enabled = False
            cbWeightTariff.SelectedIndex = -1
            cbWeightTariff.Enabled = False
        End If

        If Not oManager Is Nothing Then
            oLocations = oManager.LocationList
            bs_Curr_stor_location.DataSource = oLocations
        End If

        If Me.gbBuy.Visible Then
            Me.gbBuy.Enabled = True
        End If

        tbNumber.Focus()
    End Sub


    ''' <summary>
    ''' кнопка Очистить Все
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btClear_Click(sender As System.Object, e As System.EventArgs) Handles btClear.Click, btClear2.Click
        ClearAll()
    End Sub



    ''' <summary>
    ''' кнопка Карточка Товара
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btCreateGoodMap_click(sender As System.Object, e As System.EventArgs) Handles btCreateGood.Click
        If Me.oCurrentGood Is Nothing Then Return
        If Me.oCurrentGood.Good Is Nothing Then Return

        oCreateGoodMapComplete = False
        'показат сплеш
        If oSplashscreen1.Visible = False Then
            oSplashscreen1.Show()
            oSplashscreen1.Refresh()
        End If
        Application.DoEvents()
        '----------
        If Not oWillNewGoodFlag Then
            If tbRetailTargetValue.Text = "" Then tbRetailTargetValue.Text = 0
            If tbRetailTargetValue.Text = "0" Then
                Select Case MsgBox("Вы не задали розничную цену. Продолжить добавление товара?", vbQuestion + vbYesNo)
                    Case MsgBoxResult.No
                        oSplashscreen1.Hide()
                        Return
                End Select
            End If
        End If

        '------------------
        If Not Me.tbNumber.Text = "" And Not Me.tbArticul.Text = "" Then
            MsgBox("Указан и код товара, и артикул совместно, что недопустимо! Удалите одно из значений.", vbCritical)
            oSplashscreen1.Hide()
            Return
        End If
        '--------------------
        If Me.cbUom.SelectedIndex = -1 Then
            MsgBox("Не задана еденица измерения товара! Это значение необходимо задать.", vbCritical)
            oSplashscreen1.Hide()
            Return
        End If



        If String.IsNullOrEmpty(oCurrentGood.Name) Then MsgBox("Название товара отсутствует! Следует написать название.", vbCritical) : Me.oSplashscreen1.Hide() : Return
        '-------
        'установить параметры
        bsCurrentGood.ResetCurrentItem()
        Dim _answerstring = Me.SetGoodTable(Me.oCurrentGood.Good)

        Dim _needResetAttributes As Boolean = False
        If Me.oCurrentGood.Good.uuid = "" Then
            _needResetAttributes = True
        End If

        'создать карточку
        If oWillNewGoodFlag = True Then
            Dim _new As good = Nothing
            Dim _message As String = ""
            Dim _result = oManager.AddGoodToServer(Me.oCurrentGood.Good, _new, _message)

            'создадим карточку товара
            Select Case _result
                Case Net.HttpStatusCode.OK
                    'все ок
                    Me.oCurrentGood.UpdateGood(_new)
                    oCreateGoodMapComplete = True
                    _answerstring += "карточка товара " & Me.oCurrentGood.Good.name & " создана."
                    Me.oWillNewGoodFlag = False

                    clsApplicationTypes.BeepYES()
                    '------------------------------------
                    If _needResetAttributes Then
                        'установим атрибуты
                        Me.MarkAsNeedSaved()
                        Me.btSaveChanges_Click(sender, e)
                    End If
                    oSplashscreen1.Hide()
                    '---------печать этикеток------------
                    If Not Me.tbRetailTargetValue.Text = "" OrElse Not Me.tbRetailTargetValue.Text = "0" Then
                        If Me.cbxWithoutPriceLabelType.Checked Then
                            Me.ShowLabelWithoutPrice()
                        Else
                            Me.ShowLabelWithPrice()
                        End If
                    Else
                        Me.ShowLabelWithoutPrice()
                    End If

                    'на складах нет
                    Me.ToolStripStatusLabel1.Text = "Добавить на склад?"
                    Me.btCreateGood.BackColor = Color.FromKnownColor(KnownColor.Control)

                    'создать пустые положения
                    Me.ChangeLocations(oManager.LocationList)
                    'oCurrentGood.SetLocations(oManager.LocationList)
                    'Me.bsCurrentGood.DataSource = oCurrentGood
                    'Me.bs_GoodLocation.ResetBindings(False)
                    'Me.SlotGoodBindingSource.ResetBindings(False)
                    ' CType(Me.bsCurrentGood.Current, clsMSGood).SetLocations(oManager.LocationList)
                    'Me.bs_GoodLocation.DataSource = CType(Me.bsCurrentGood.Current, clsMSGood).Locations

                    'операции с товаром
                    Me.btAddGoodToWare.Enabled = True
                    Me.btAddGoodToWare.BackColor = Color.Red
                    Me.btCreateGood.Enabled = False
                    Me.cbxAddIfExists.Enabled = False
                    Me.cbxWithoutSlot.Checked = True

                    Me.tbQty.Enabled = True
                    Me.tbQty.Text = ""
                    Me.tbQty.BackColor = Color.Red

                    Me.btOnePcs.Enabled = True

                    If Me.cbxWithoutSlot.Checked = True Then
                        Me.cbSlot.SelectedIndex = -1
                    End If
                    SetUserPreferences()
                    Me.tbQty.Focus()
                    '--------------
                    'Select Case MsgBox("Создать запись учета себестоимости?", vbYesNo, "Мой Склад")
                    '    Case MsgBoxResult.Yes
                    '        Me.btAddGoodToWare.BackColor = Color.OrangeRed
                    '        tbCtlMain.SelectedTab = Me.tpPreparation
                    '        tbRawNumber.Focus()
                    '        Return
                    'End Select
                    '--------------
                    Return
                Case Else
                    '---ошибка
                    Me.oSplashscreen1.Hide()
                    Me.ToolStripStatusLabel1.Text = "Ошибка сервера при создании карточки товара! Проверь через Мой Склад. Сообщение сервера: " & _message
                    _answerstring += "Ошибка сервера при создании карточки товара! Проверь через Мой Склад. Сообщение сервера: " & _message
                    clsApplicationTypes.BeepNOT()
            End Select
        Else
            'если надо, сохоаним изменения
            Me.btSaveChanges_Click(sender, e)
            oCreateGoodMapComplete = True
            Me.btAddGoodToWare.Enabled = True
            Me.btAddGoodToWare.Focus()
            Return
        End If

        'сообщение в случае ошибки
        If Not oCreateGoodMapComplete Then
            MsgBox(_answerstring, vbInformation)
        End If
    End Sub

    ''' <summary>
    ''' Красная кнопка сохранения
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btSaveChanges_Click(sender As System.Object, e As System.EventArgs) Handles btSaveChanges.Click
        ' Application.DoEvents()
        'If Me.btSaveChanges.Tag = False Then Return
        If Me.oCurrentGood Is Nothing Then Me.ToolStripStatusLabel1.Text = "Ошибка обновления 01 - товар не обновлен" : Return
        If Me.oCurrentGood.Good Is Nothing Then Me.ToolStripStatusLabel1.Text = "Ошибка обновления 02 - товар не обновлен" : Return

        'запрос на изменение в БД
        bsCurrentGood.ResetCurrentItem()
        Dim _good = Me.oCurrentGood.Good
        'параметры товара
        Me.SetGoodTable(_good)
        'показат сплеш
        If oSplashscreen1.Visible = False Then
            oSplashscreen1.Show()
            Application.DoEvents()
        End If
        Dim _newGood As good = Nothing
        Dim _message As String = ""

        Select Case Me.oManager.AddGoodToServer(_good, _newGood, _message)
            Case Net.HttpStatusCode.OK
                btSaveChanges.BackColor = Control.DefaultBackColor

                If Me.btAddGoodToWare.BackColor = Color.OrangeRed Then
                    Me.btAddGoodToWare.BackColor = Color.Red
                End If

                Me.oSplashscreen1.Hide()

                If _newGood Is Nothing Then
                    Me.ToolStripStatusLabel1.Text = "Ошибка обновления 03 - товар не обновлен"
                    'MsgBox("Сервер не вернул обьект товара! Не удалось обновить товар!", vbCritical)
                    Return
                End If
                Me.oCurrentGood.UpdateGood(_newGood)

                Me.cbxSetRetail.Checked = False
                If Me.cbxWithoutPriceLabelType.Checked Then
                    Me.ShowLabelWithoutPrice()
                Else
                    Me.ShowLabelWithPrice()
                End If

                Me.btSaveChanges.Tag = False
                clsApplicationTypes.BeepYES()
                Me.ToolStripStatusLabel1.Text = "Товар успешно обновлен"


            Case Else
                Me.oSplashscreen1.Hide()
                Me.ToolStripStatusLabel1.Text = "Ошибка обновления 03 - товар не обновлен. Сообщение сервера MC:  " & _message
                _message = "Ошибка обновления 03 - товар не обновлен. Сообщение сервера MC:  " & _message
                MsgBox(_message, vbCritical)
        End Select
        '--------------------------
    End Sub


#End Region

#Region "Номера товара"
    Private Sub tbNumber_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tbNumber.KeyPress, tbArticul.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Me.btSearchInSklad_Click(sender, e)
        ElseIf (Char.IsLetterOrDigit(e.KeyChar) Or Asc(e.KeyChar) = 8) And Not Me.bsCurrentGood.Current Is Nothing Then
            'изменение номера у карточки товара - запретить
            e.Handled = True
            'Me.MarkAsNeedSaved()
        End If
    End Sub

    ''' <summary>
    ''' новый номер - запрос
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btNewNumber_Click(sender As System.Object, e As System.EventArgs) Handles btNewNumber.Click
        Dim _series As String = "802"

        If clsApplicationTypes.GetAccess("Изменение серии добавляемого номера") Then
            If String.IsNullOrEmpty(oFixedSeries) Then
                _series = InputBox("Введите серию", "Серия для нового номера", _series)
                If _series = "" Then
                    MsgBox("Необходимо ввести серию", vbCritical)
                    Return
                End If
            Else
                _series = oFixedSeries
            End If
        End If

        'показат сплеш
        If oSplashscreen1.Visible = False Then
            oSplashscreen1.Show()
            Application.DoEvents()
        End If
nxnr:
        Dim _res = Service.clsApplicationTypes.DelegatStoreGetNewNumber.Invoke(_series)
        If _res.Length > 0 Then
            'проверка фото
            If Service.clsApplicationTypes.DelegatStoreCheckImages Is Nothing Then
                'проверить фото невозможно
                oSplashscreen1.Hide()
                MsgBox("Невозможно проверить фото для номера " & _res & "!", vbCritical)
                Return
            Else
                Dim _result = Service.clsApplicationTypes.DelegatStoreCheckImages.Invoke(_res)
                Select Case _result
                    Case 1
                        'фотки есть - получить следующий номер
                        MsgBox("Для номера " & _res & " есть фото, будет выдан следующий номер.", vbInformation)
                        GoTo nxnr
                    Case 0
                        'фоток нет, все ок
                    Case -1
                        'номер неверен, внутренняя ошибка
                        oSplashscreen1.Hide()
                        MsgBox("Номер неверен, внутренняя ошибка!", vbCritical)
                        Return
                    Case -2
                        'нет доступа к БД, внутренняя ошибка
                        oSplashscreen1.Hide()
                        MsgBox("Нет доступа к БД, внутренняя ошибка!", vbCritical)
                        Return
                End Select
            End If
            oSplashscreen1.Hide()
            ClearAll()
            oCurrentGood = New clsMSGood With {.Code = _res}
            ' Me.ChangeLocations(Nothing)
            CurrentGoodRequest()
            Me.cbDBNames.Focus()
        Else
            oSplashscreen1.Hide()
            MsgBox("Не удалось получить номер, внутренняя ошибка БД!", vbCritical)
        End If

    End Sub

    Private Sub tbBarCode_Enter(sender As Object, e As KeyPressEventArgs) Handles tbBarCode.KeyPress
        If Asc(e.KeyChar) = 13 And Not Me.oCurrentGood Is Nothing Then
            'TODO
            'проверить код?
        ElseIf Asc(e.KeyChar) = 13 And Me.oCurrentGood Is Nothing Then
            Me.btSearchInSklad_Click(sender, e)
        ElseIf (Char.IsLetterOrDigit(e.KeyChar) Or Asc(e.KeyChar) = 8) And Not Me.oCurrentGood Is Nothing Then
            If tbBarCode.Text.Length < 13 Then
                Dim _num As ShotCodeConverter_Net.clsCode
                If Not Me.tbNumber.Text = "" Then
                    _num = ShotCodeConverter_Net.clsCode.CreateInstance(Me.tbNumber.Text)
                    If _num.CodeType = ShotCodeConverter_Net.clsCode.emCodeType.EAN13 Then
                        Me.tbBarCode.Text = _num.EAN13
                        Me.MarkAsNeedSaved()
                    End If
                ElseIf Not Me.tbArticul.Text = "" Then
                    _num = ShotCodeConverter_Net.clsCode.CreateInstance(Me.tbArticul.Text)
                    If _num.CodeType = ShotCodeConverter_Net.clsCode.emCodeType.EAN13 Then
                        Me.tbBarCode.Text = _num.EAN13
                        Me.MarkAsNeedSaved()
                    End If
                End If
            ElseIf tbBarCode.Text.Length = 13 Then
                Me.MarkAsNeedSaved()
            End If
        End If
    End Sub

    Private Sub btSubNumber_plus_Click(sender As System.Object, e As System.EventArgs) Handles btSubNumberPlus.Click
        If Me.tbArticul.Text = "" Then Return
        If oSampleNumber Is Nothing Then Return
        Me.tbArticul.Text = oSampleNumber.IncreaceSubNumber

        Dim _count As Integer = 0
        Dim _newName = clsApplicationTypes.ReplaceInSkobki(Me.tbName.Text, "кат." & oSampleNumber.SubNumber, , , _count)

        Me.tbName.Text = ""
        Me.btSearchInSklad_Click(sender, e)

        If Me.oWillNewGoodFlag Then
            'замена только в новом товаре
            If _count > 1 Then
                Me.oCurrentGood.Name = _newName
                Me.bsCurrentGood.ResetCurrentItem()
            End If
        End If
    End Sub

    Private Sub btSubNumberMinus_Click(sender As System.Object, e As System.EventArgs) Handles btSubNumberMinus.Click
        If Me.tbArticul.Text = "" Then Return
        If oSampleNumber Is Nothing Then Return
        Me.tbArticul.Text = oSampleNumber.DecreaceSubNumber

        Dim _count As Integer = 0
        Dim _newName = clsApplicationTypes.ReplaceInSkobki(Me.tbName.Text, "кат." & oSampleNumber.SubNumber, , , _count)

        Me.tbName.Text = ""
        Me.btSearchInSklad_Click(sender, e)
        If Me.oWillNewGoodFlag Then
            'замена только в новом товаре
            If _count > 1 Then
                Me.oCurrentGood.Name = _newName
                Me.bsCurrentGood.ResetCurrentItem()
            End If
        End If

    End Sub

    Private Sub btMoveToArticul_Click(sender As System.Object, e As System.EventArgs) Handles btMoveToArticul.Click

        If oCurrentGood Is Nothing Then
            'просто перекинем для запроса
            Me.tbArticul.Text = Me.tbNumber.Text
            Me.tbNumber.Text = ""
            Return
        End If


        If Me.tbNumber.Text = "" Then Return

        Dim _ar = Me.tbNumber.Text
        'Me.tbBarCode.Text = ""

        Me.oCurrentGood.Code = ""
        Me.oCurrentGood.Articul = _ar

        Me.bs_Goods_dgv_Goods.ResetCurrentItem()
        Me.bsCurrentGood.ResetCurrentItem()
        If Not oCurrentGood.Good Is Nothing Then
            Me.MarkAsNeedSaved()
        End If
    End Sub

    Private Sub btMoveToCode_Click(sender As Object, e As EventArgs) Handles btMoveToCode.Click
        If oCurrentGood Is Nothing Then
            'просто перекинем для запроса
            Me.tbNumber.Text = Me.tbArticul.Text
            Me.tbArticul.Text = ""
            Return
        End If
        If Me.tbArticul.Text = "" Then Return

        Dim _code = Me.tbArticul.Text

        Me.oCurrentGood.Articul = ""
        Me.oCurrentGood.Code = _code

        Me.bs_Goods_dgv_Goods.ResetCurrentItem()
        Me.bsCurrentGood.ResetCurrentItem()
        If oWillNewGoodFlag = False And Not oCurrentGood.Good Is Nothing Then
            Me.MarkAsNeedSaved()

        End If
    End Sub

#End Region

#Region "количество и размещение товара"

    ''' <summary>
    ''' кнопка На Склад
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btAddGood_Click(sender As System.Object, e As System.EventArgs) Handles btAddGoodToWare.Click
        If oBackgroundWorkerMC.IsBusy Then
            Me.ToolStripStatusLabel1.Text = String.Format("Фоновое размещение ...")
            MsgBox("Необходимо дождаться завершения запущенной операции размещения!", vbCritical)
            Me.ToolStripStatusLabel1.Text = ""
            Return
        End If

        ''создать/проверить карточку ТОВАРА
        If Me.btCreateGood.Enabled = True Then
            Me.btCreateGoodMap_click(Me, EventArgs.Empty)
            If Not oCreateGoodMapComplete Then
                Me.oSplashscreen1.Hide()
                Return
            End If
        End If

        'сохранить изменения в карточке товара
        If Me.btSaveChanges.BackColor = Color.Red Then
            Me.btSaveChanges_Click(Me.btSaveChanges, EventArgs.Empty)
        End If

        '--------размещение товара------------------
        Dim _answermsg As String = ""
        If Not Me.LocateGood(Me.oCurrentGood, _answermsg) Then
            Me.ChangeLocations(oManager.LocationList)
            MsgBox(_answermsg, MsgBoxStyle.Critical)
            Me.oSplashscreen1.Hide()
            Return
        End If

        If Me.oCurrentGood.TotalQTY = 0 Then
            MsgBox("Размещение сброшено, заново задайте склад!", vbCritical)
            'обновить отображение
            'создать пустые положения
            Me.ChangeLocations(oManager.LocationList)
            Me.ToolStripStatusLabel1.Text = "Добавить на склад"

            Me.tbQty.Text = "0"
            Me.tbQty.BackColor = Color.Red

            If Me.cbxWithoutSlot.Checked = True Then
                Me.cbSlot.SelectedIndex = -1
            End If

            Me.oSplashscreen1.Hide()
            Me.cbTargetStores.Focus()
            Return
        End If

        'показат сплеш
        If oSplashscreen1.Visible = False Then
            oSplashscreen1.Show()
            oSplashscreen1.Refresh()
        End If
        Application.DoEvents()

        'ОПРИХОДОВАНИЕ тут товар размещен. Можно писать в МойСклад
        ' bs_GoodLocation.ResetBindings(False)

        If Me.oCurrentGood.Locations Is Nothing OrElse Me.oCurrentGood.Locations.Count = 0 Then
            MsgBox("Размещение товара не задано! Задайте склад!", vbCritical)
            oSplashscreen1.Hide()
            Return
        End If

        Select Case MsgBox(String.Format("Приходуем на склад {0} {1}{2} товара?", Me.oCurrentGood.Locations.First.ToString, Me.oCurrentGood.TotalQTY, Me.cbUom.Text), vbYesNo)
            Case MsgBoxResult.Yes
                Me.btAddGoodToWare.BackColor = Control.DefaultBackColor
            Case MsgBoxResult.No
                'создать пустые положения
                Me.ChangeLocations(oManager.LocationList)
                oSplashscreen1.Hide()
                Return
        End Select

        Dim _toLocation = Me.oCurrentGood.Locations.First
        Debug.Assert(Not _toLocation Is Nothing, "Текущий обьект Location пуст!")
        Debug.Assert(Not Me.oCurrentGood.Locations.First.LinkedEnter Is Nothing, "Ошибка!!! Оприходование не загружено!!! ")
        Dim _enterUUID As String = _toLocation.LinkedEnter.uuid
        Dim _slotGood = New List(Of clsGoodLocation.clsSlot)
        For Each _sl In _toLocation.SlotGood
            _slotGood.Add(_sl.Clone)
        Next
        Dim _name = Me.oCurrentGood.Name
        Dim _uomName = oManager.GetUomByUUID(Me.oCurrentGood.Good.uomUuid).name
        Dim _goodCode As String = oCurrentGood.AnyCode
        Dim _goodUUID As String = oCurrentGood.UUID
        Dim _goodBuyPrice As Double = Me.oCurrentGood.Good.buyPrice
        Dim _goodBuyCurrencyUUID As String = Me.oCurrentGood.Good.buyCurrencyUuid
        Dim _wareName = CType(Me.bs_GoodLocation.Current, clsGoodLocation).WarehouseName
        'для асинхронного выызова необходимы копии обьектов!!!!

        'делегат функции оприходования
        Dim _enterSub = Function() As String
                            Debug.Assert(Me.oCurrentGood.Locations.Count > 0, "Текущий обьект Location пуст!")
                            If Me.oCurrentGood.Locations.Count = 0 Then
                                Return String.Format("Ошибка! Товар {1} ({0}) НЕ ОПРИХОДОВАН!", Me.oCurrentGood.Name, oCurrentGood.AnyCode)
                            End If

                            Dim _res = oManager.AddEnterToServer(_enterUUID, _slotGood, _goodUUID, _goodBuyPrice, _goodBuyCurrencyUUID)
                            If _res > 0 Then
                                _answermsg = String.Format("Товар {1} ({0}) в количестве {2}{3} оприходован на склад {4}", _name, _goodCode, _res, _uomName, _wareName)
                                clsApplicationTypes.BeepYES()
                            Else
                                _answermsg = String.Format("Товар {1} ({0}) НЕ ОПРИХОДОВАН!", _name, _goodCode)
                                clsApplicationTypes.BeepNOT()
                            End If

                            Return _answermsg
                        End Function
        '----------------------
        'делегат функции Приемка образцов TODO


        '---------------------
        ''оприходуем асинхронно
        Me.tbQty.Enabled = False
        Me.cbUom.Enabled = False
        Me.btOnePcs.Enabled = False


        oBackgroundWorkerMC.RunWorkerAsync(_enterSub)

        oSplashscreen1.Hide()

        Me.cbxAddIfExists.Checked = False
        Me.btAddGoodToWare.Enabled = False
        Me.ToolStripStatusLabel1.Text = String.Format("Фоновое размещение {0} ...", oCurrentGood.AnyCode)
        Me.btAddGoodToWare.BackColor = Color.FromKnownColor(KnownColor.Control)

        'выбор вкладки по умолчанию
        SelectFixTabs()

        'автопечать
        If Me.cbAutoprint.Checked Then
            Me.PrintLabel(Me, EventArgs.Empty)
        End If
    End Sub

    ''' <summary>
    ''' выбор вкладки по умолчанию
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SelectFixTabs()
        If cbFixPrepTab.Checked Then
            Me.tbCtlMain.SelectedTab = tpPreparation
        ElseIf cbFixPriceTab.Checked Then
            Me.tbCtlMain.SelectedTab = tpPrices
        ElseIf cbFixTabRfid.Checked Then
            Me.tbCtlMain.SelectedTab = tpRfid
        Else
            Me.tbCtlMain.SelectedTab = tpMain
        End If
    End Sub


    ''' <summary>
    ''' разместит товар по ячейкам
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function LocateGood(ByRef _MsGood As clsMSGood, ByRef _message As String) As Boolean
        Debug.Assert(Not _MsGood Is Nothing)

        If _MsGood Is Nothing Then _message = "Внутреняя ошибка!" : Return False
        'If _MsGood.TotalQTY = 0 Then _message = "Внутреняя ошибка! Попытка приходовать 0 товара!" : Return False
        '----------------
        If Me.cbTargetStores.SelectedItem Is Nothing Then
            Me.oSplashscreen1.Hide() : _message = "Необходимо выбрать склад!" : Return False
        End If

        'выбранный склад
        Dim _wareUUID = Me.cbTargetStores.SelectedItem.WarehouseUUID
        Dim _newgoodLocation = New clsGoodLocation(_wareUUID)
        _newgoodLocation.WarehouseName = oManager.GetWarehouseByUUID(_wareUUID).name
        'задать оприходование
        _newgoodLocation.LinkedEnter = oManager.GetEnterByWarehouseUUID(_wareUUID)
        Dim _goodQty As Decimal = _MsGood.TotalQTY
        'ячейки
        Dim _selectedSlot As clsGoodLocation.clsSlot
        If cbxWithoutSlot.Checked Then
            'пустая ячейка без UUID

            If _goodQty = 0 Then
                'склад без ячеек
                _goodQty = Me.SlotGoodBindingSource.Current.qty 'clsApplicationTypes.ReplaceDecimalSplitter(Me.tbQty)
            End If

            If _goodQty = 0 Then _message = "Внутреняя ошибка! Попытка приходовать 0 товара!" : Return False

            _selectedSlot = New clsGoodLocation.clsSlot(_goodQty, _wareUUID, Nothing)
            _newgoodLocation.SlotGood = {_selectedSlot}.ToList
            _message = String.Format("Товар в кол-ве {0}{1} размещен без ячейки", _MsGood.TotalQTY, Me.cbUom.Text)
        Else
            'ячейки с количеством более 0
            If _goodQty = 0 Then _message = "Внутреняя ошибка! Попытка приходовать 0 товара!" : Return False
            _newgoodLocation.SlotGood = (From c As clsGoodLocation.clsSlot In CType(bs_GoodLocation.Current, clsGoodLocation).SlotGood Where c.Qty > 0 Select c).ToList
            _message = String.Format("В ячейки {0} размещено {1}{2} товара", String.Join(", ", _newgoodLocation.SlotGood.Select(Function(x) x.SlotName).ToArray), _MsGood.TotalQTY, Me.cbUom.Text)
        End If
        _newgoodLocation.LoadObjects(oManager)
        'создать размещение для товара
        _MsGood.SetLocations({_newgoodLocation})
        Return True

    End Function


    ''' <summary>
    ''' изменение количества
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tbQty_TextChanged(sender As Object, e As EventArgs) Handles tbQty.TextChanged

    End Sub




    ''' <summary>
    ''' изменение ячейки
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cbSlot_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbSlot.SelectedIndexChanged

    End Sub


    ''' <summary>
    ''' ввод номера склада сканером в комбо ячеек
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cbSlot_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cbSlot.KeyPress
        Static _keys As String
        If Char.IsDigit(e.KeyChar) Then
            _keys += e.KeyChar
        End If

        If Asc(e.KeyChar) = 13 Then
            'введен код
            Dim _res = From c As clsGoodLocation.clsSlot In SlotGoodBindingSource.List Where c.ESlot.name.Contains(cbSlot.Text) Select c

            If _res.Count > 0 Then
                Me.cbSlot.SelectedItem = _res.FirstOrDefault
                _keys = ""
                SlotGoodBindingSource.ResetCurrentItem()
                Me.tbQty.Focus()
            Else
                cbSlot.Text = ""
                MsgBox(String.Format("Ячейка {0} не найдена на складе", _keys), vbCritical)
            End If
        End If
    End Sub


    ''' <summary>
    ''' добавить 1 штуку в количество
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btOnePcs_Click(sender As System.Object, e As System.EventArgs) Handles btOnePcs.Click
        'If Me.bsCurrentGood.Current Is Nothing Or Me.bs_GoodLocation.Current Is Nothing Then

        'End If

        If Me.SlotGoodBindingSource.Current Is Nothing Then
            'на складе нет ячеек
            Dim _wareUUID = Me.cbTargetStores.SelectedItem.WarehouseUUID
            Me.SlotGoodBindingSource.DataSource = New clsGoodLocation.clsSlot(0, _wareUUID, Nothing)
        End If

        Dim _slot = CType(Me.SlotGoodBindingSource.Current, clsGoodLocation.clsSlot)
        'добавляет +1 к товару
        _slot.Qty += 1
        Me.tbQty.BackColor = Color.White
        Me.bs_GoodLocation.ResetCurrentItem()
        If cbxWithoutSlot.Checked Then
            Me.cbSlot.SelectedIndex = -1
        End If
    End Sub


    ''' <summary>
    ''' флажок БЕЗ РАЗМЕЩЕНИЯ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cbWithoutSlot_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles cbxWithoutSlot.CheckedChanged
        If Me.bsCurrentGood.Current Is Nothing Then Return
        If Me.SlotGoodBindingSource.Count = 0 Then cbxWithoutSlot.Checked = True : Return
        Select Case cbxWithoutSlot.Checked
            Case True
                'БЕЗ РАЗМЕЩЕНИЯ
                Me.cbSlot.SelectedIndex = -1
                Me.tbQty.Focus()
            Case False
                'С РАЗМЕЩЕНИЕМ
                ''подгрузить ВСЕ ячейки для склада (для последующего выбора размещения)
                'Dim _currwareUUID As String = cbTargetStores.SelectedValue
                'Dim _location = oManager.LocationList.Where(Function(x) x.WarehouseUUID = _currwareUUID)
                'CType(Me.bsCurrentGood.Current, clsMSGood).SetLocations(_location)
                Me.cbSlot.SelectedIndex = 0
                Me.cbSlot.Focus()
        End Select
    End Sub


    ''' <summary>
    ''' флажок Добавить к имеющимся остаткам
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cbxAddIfExists_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles cbxAddIfExists.CheckedChanged
        If oCurrentGood Is Nothing Then Return
        Static _originalLocations As List(Of clsGoodLocation)
        If _originalLocations Is Nothing Then
            'запомнить кол-во для оприходования
            _originalLocations = oCurrentGood.Locations
        End If

        Select Case cbxAddIfExists.Checked
            Case True
                'создать пустые положения
                Me.ChangeLocations(oManager.LocationList)
                'oCurrentGood.SetLocations(oManager.LocationList)
                'Me.bsCurrentGood.DataSource = oCurrentGood
                'Me.bs_GoodLocation.ResetBindings(True)
                'Me.SlotGoodBindingSource.ResetBindings(True)
                ' Me.bsCurrentGood.ResetCurrentItem()
                ' Me.bs_GoodLocation.DataSource = CType(Me.bsCurrentGood.Current, clsMSGood).Locations

                Me.ToolStripStatusLabel1.Text = "Добавить на склад"
                'операции с товаром
                Me.btAddGoodToWare.Enabled = True
                Me.btAddGoodToWare.BackColor = Color.Red
                Me.btCreateGood.Enabled = False

                Me.tbQty.Enabled = True
                Me.tbQty.Text = ""
                Me.tbQty.BackColor = Color.Red

                Me.btOnePcs.Enabled = True

                If Me.cbxWithoutSlot.Checked = True Then
                    Me.cbSlot.SelectedIndex = -1
                End If

                Me.cbTargetStores.Focus()
            Case Else
                Me.ChangeLocations(_originalLocations)
                'oCurrentGood.SetLocations(_originalLocations)
                'Me.bsCurrentGood.DataSource = oCurrentGood
                'Me.bs_GoodLocation.ResetBindings(False)
                'Me.SlotGoodBindingSource.ResetBindings(False)
                'Me.SlotListBindingSource.ResetBindings(False)
                'Me.bs_GoodLocation.DataSource = CType(Me.bsCurrentGood.Current, clsMSGood).Locations
                _originalLocations = Nothing
                'операции с товаром
                Me.btAddGoodToWare.Enabled = False
                Me.btCreateGood.Enabled = False

                Me.cbxLossEnable.Checked = False

                Me.tbQty.BackColor = Color.White
        End Select

        'SetUserPreferences()
    End Sub

    ''' <summary>
    ''' изменит расположения для камня
    ''' </summary>
    ''' <param name="locations"></param>
    ''' <remarks></remarks>
    Private Sub ChangeLocations(locations As List(Of clsGoodLocation))

        If oCurrentGood.Locations Is Nothing Then
            locations = oManager.LocationList
        End If


        If Not locations Is Nothing Then
            oCurrentGood.SetLocations(locations)
        End If


        Me.bsCurrentGood.DataSource = oCurrentGood
        Me.bsCurrentGood.ResetCurrentItem()
        Me.bs_GoodLocation.ResetBindings(True)
        Me.SlotGoodBindingSource.DataSource = CType(Me.bs_GoodLocation.Current, clsGoodLocation).SlotGood
        Me.SlotGoodBindingSource.ResetBindings(True)
        Me.SlotListBindingSource.ResetBindings(True)


        'If oCurrentGood.Locations Is Nothing Then
        '    Me.bs_GoodLocation.Clear()
        '    Me.bs_GoodLocation.ResetBindings(False)
        '    Me.SlotGoodBindingSource.ResetBindings(False)
        '    Me.SlotListBindingSource.ResetBindings(False)
        'Else
        '    Me.bs_GoodLocation.DataSource = oCurrentGood.Locations
        '    Me.SlotGoodBindingSource.ResetBindings(False)
        '    Me.SlotListBindingSource.ResetBindings(False)
        'End If


        'Me.bsCurrentGood.MoveFirst()
        'Me.bs_GoodLocation.MoveFirst()
    End Sub


    ''' <summary>
    ''' изменение склада
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cbTargetStores_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbTargetStores.SelectedIndexChanged
        'запрет межскладового размещения - обнулить все количества товара ранее заданные
        For Each _loc As clsGoodLocation In bs_GoodLocation.CurrencyManager.List
            If Not _loc.WarehouseUUID = cbTargetStores.SelectedValue Then
                For Each t In _loc.SlotGood
                    If t.Qty > 0 Then
                        t.Qty = 0
                    End If
                Next
            End If
        Next
        'If Me.cbxWithoutSlot.Checked Then
        '    Me.cbSlot.SelectedIndex = -1
        'End If
    End Sub

    ''' <summary>
    ''' срабатывает при изменении склада. 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub bs_GoodLocation_CurrentItemChanged(sender As Object, e As System.EventArgs) Handles bs_GoodLocation.CurrentItemChanged
        If bs_GoodLocation.Current Is Nothing Then Return

        'при размещении БЕЗ ячейки отобразить это на ЭУ
        If SlotGoodBindingSource.Current Is Nothing OrElse CType(SlotGoodBindingSource.Current, clsGoodLocation.clsSlot).SlotUUID = Nothing Then
            Me.cbxWithoutSlot.Checked = True
            Me.cbSlot.SelectedIndex = -1
        End If

        ''при выборе нового склада общее кол-во будет ноль, и по умолчанию расположить без ячейки
        'If Me.oCurrentGood.TotalQTY = 0 Then
        '    Me.cbxWithoutSlot.Checked = True
        '    Me.cbSlot.SelectedIndex = -1
        'End If
        'If Me.cbxWithoutSlot.Checked Then
        '    Me.cbSlot.SelectedIndex = -1
        'End If
    End Sub
#End Region

    ''' <summary>
    ''' выбор товара в таблице
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub bs_Goods_dgv_Goods_PositionChanged(sender As Object, e As System.EventArgs) Handles bs_Goods_dgv_Goods.PositionChanged
        If oCurrentGood Is Nothing Then Return
        If oCurrentGood.Good Is Nothing Then Return
        If oCurrentGood.Good.uomUuid = "" Then Return
        'ед.изм.
        Me.cbUom.SelectedItem = oManager.GetUomByUUID(oCurrentGood.Good.uomUuid)
    End Sub



#Region "Списание товара"

    Private Sub cbxLossEnable_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles cbxLossEnable.CheckedChanged
        Select Case cbxLossEnable.Checked
            Case True
                For Each ctl In Me.GroupBox3.Controls
                    ctl.enabled = True
                Next

                Me.tbLossSourceArticul.BackColor = Color.Red

                Me.tbLossQty.Enabled = True
                Me.tbLossSourceArticul.Text = ""
                Me.tbLossSourceArticul.Enabled = True
                Me.tbLossSourceName.Text = ""
                Me.tbLossSourceName.Enabled = True
                Me.btGetLossSource.Enabled = True
                Me.cbLossLocations.Enabled = True

                Me.cbxIncomingPrices.Enabled = True
                Me.cbxWriteAdditionalPrices.Enabled = True
                Me.cbxIncomingPrices.Checked = True
                ' Me.cbxWriteAdditionalPrices.Checked = True
                Me.tbShippingPrice.Enabled = True

                Me.tbBuyPriceGood.Text = ""
                Me.tbBuyPriceGoodCurrency.Text = ""
                Me.cbxSetRetail.Enabled = True

                ''покажем разделитель, кот надо использовать
                'Me.lbSeparator.Text = Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator
                'угадаем артикул
                If tbArticul.Text = "" AndAlso Not tbName.Text = "" Then

                Else
                    'поставим базовый артикул
                    Dim _num = ShotCodeConverter_Net.clsCode.CreateInstance(tbArticul.Text).ConvertToBaseCode

                    If _num.CodeType = ShotCodeConverter_Net.clsCode.emCodeType.EAN13 Then
                        tbLossSourceArticul.Text = _num.ShotCode
                    End If
                End If

                tbLossSourceArticul.Focus()


                '-------------
                Me.dgv_Goods.DataSource = Nothing
                Me.cbLossLocations.DataSource = Nothing

            Case False
                For Each ctl In GroupBox3.Controls
                    ctl.Enabled = False
                Next

                Me.tbLossSourceArticul.BackColor = Color.FromKnownColor(KnownColor.Window)
                Me.tbLossQty.Enabled = False
                Me.tbLossQty.Text = ""
                Me.tbLossSourceArticul.Text = ""
                Me.tbLossSourceArticul.Enabled = False
                Me.tbLossSourceName.Text = ""
                Me.tbLossSourceName.Enabled = False
                Me.cbLossLocations.Enabled = False
                Me.btGetLossSource.Enabled = False
                Me.cbxIncomingPrices.Enabled = False
                Me.cbxWriteAdditionalPrices.Enabled = False
                Me.tbShippingPrice.Enabled = False
                Me.cbRetailTargetCurrency.Enabled = False
                Me.tbBuyPriceGood.Text = ""
                Me.tbBuyPriceGoodCurrency.Text = ""
        End Select

    End Sub

    Private Sub btGetLossSource_Click(sender As System.Object, e As System.EventArgs) Handles btGetLossSource.Click
        Dim _result As IEnumerable(Of Object) = Nothing
        Dim _message As String = ""
        Dim _out As New List(Of clsMSGood)
        Dim _status As System.Net.HttpStatusCode

        ' Me.tbLossSourceArticul.BackColor = Color.White
        oCurrentLossGood = Nothing
        Me.dgv_Goods.DataSource = Nothing
        Me.cbLossLocations.DataSource = Nothing



        'запросить по имени
        If tbLossSourceArticul.Text = "" Then
            If tbLossSourceName.Text = "" Then
                MsgBox("Необходимо задать артикул или часть названия для запроса!", MsgBoxStyle.Critical)
                Return
            End If

            'показат сплеш
            If oSplashscreen1.Visible = False Then
                oSplashscreen1.Show()
                Application.DoEvents()
            End If

            'ищем по имени
            _result = oManager.RequestGoodCollectionByName(Me.tbLossSourceName.Text)
            'For Each t In oManager.RequestGoodCollectionByName(Me.tbLossSourceName.Text)
            '    _out.Add(New clsMSGood With {.Good = t})
            'Next

            If _result.Count = 0 Then
                'не найдено
                Me.oSplashscreen1.Hide()
                MsgBox("Товаров с именем " & tbLossSourceName.Text & " не найдено!", MsgBoxStyle.Critical)
                Me.tbLossSourceName.Focus()
                Me.tbLossSourceName.SelectAll()
                Return
            End If
            GoTo ex
        Else
            'ищем по артикулу
            _status = oManager.RequestAnyCollection(clsMoyScladManager.emMoySkladObjectTypes.Good, _result, tbLossSourceArticul.Text, clsMoyScladManager.emMoySkladFilterTypes.productCode, _message)
            Select Case _status
                Case Net.HttpStatusCode.OK
                    If _result.Count = 0 Then
                        'не найдено
                        'ищем по коду
                        _status = oManager.RequestAnyCollection(clsMoyScladManager.emMoySkladObjectTypes.Good, _result, tbLossSourceArticul.Text, clsMoyScladManager.emMoySkladFilterTypes.code, _message)
                        Select Case _status
                            Case Net.HttpStatusCode.OK
                                If _result.Count = 0 Then
                                    'не найдено
                                    GoTo notfound
                                Else
                                    clsApplicationTypes.BeepYES()
                                    GoTo ex
                                End If
                            Case Net.HttpStatusCode.NotFound
                                GoTo notfound
                            Case Else
                                'ошибка запроса
                                Me.oSplashscreen1.Hide()
                                MsgBox("Ошибка запроса товара по коду " & tbLossSourceArticul.Text & " !" & ChrW(13) & _message, MsgBoxStyle.Critical)
                                Return
                        End Select
                    Else
                        clsApplicationTypes.BeepYES()
                        GoTo ex
                    End If

                Case Net.HttpStatusCode.NotFound
                    'ищем по коду
                    _status = oManager.RequestAnyCollection(clsMoyScladManager.emMoySkladObjectTypes.Good, _result, tbLossSourceArticul.Text, clsMoyScladManager.emMoySkladFilterTypes.code, _message)
                    Select Case _status
                        Case Net.HttpStatusCode.OK
                            If _result.Count = 0 Then
                                'не найдено
                                GoTo notfound
                            Else
                                clsApplicationTypes.BeepYES()
                                GoTo ex
                            End If
                        Case Net.HttpStatusCode.NotFound
                            GoTo notfound
                        Case Else
                            'ошибка запроса
                            Me.oSplashscreen1.Hide()
                            MsgBox("Ошибка запроса товара по коду " & tbLossSourceArticul.Text & " !" & ChrW(13) & _message, MsgBoxStyle.Critical)
                            Return
                    End Select
                Case Else
                    'ошибка запроса
                    Me.oSplashscreen1.Hide()
                    MsgBox("Ошибка запроса товара по артикулу " & tbLossSourceArticul.Text & " !" & ChrW(13) & _message, MsgBoxStyle.Critical)
                    Return
            End Select
        End If
ex:
        'нашли - обработка текущего значения в проц  
        Me.tbLossSourceArticul.BackColor = Color.FromKnownColor(KnownColor.Window)
        Me.oSplashscreen1.Hide()
        'выбор товара списания в процедуре обраотки события
        RemoveHandler Me.dgv_Goods.CurrentCellChanged, AddressOf dgv_Goods_CurrentCellChanged
        AddHandler Me.dgv_Goods.CurrentCellChanged, AddressOf dgv_Goods_CurrentCellChanged
        Me.dgv_Goods.DataSource = (From c As good In _result Select clsMSGood.CreateInstance(c)).ToList
        Return

notfound:
        Me.oSplashscreen1.Hide()
        MsgBox("Товаров с кодом/артикулом " & tbLossSourceArticul.Text & " не найдено!", MsgBoxStyle.Information)
        Me.tbLossSourceArticul.Focus()
        Me.tbLossSourceArticul.SelectAll()
    End Sub

    Private Sub tbLossQty_GotFocus(sender As Object, e As System.EventArgs) Handles tbLossQty.GotFocus
        Dim _control As Control = CType(sender, Control)
        _control.BackColor = Color.Red

        If _control.Text = "" Then Exit Sub
        Dim _result As Decimal
        If Decimal.TryParse(_control.Text, _result) = False Then
            _control.Text = ""
        End If
    End Sub

    Private Sub tbLossQty_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tbLossQty.KeyPress
        Select Case Asc(e.KeyChar)
            Case 225
                'б
                e.Handled = True
                tbLossQty.Text += ","
                tbLossQty.Select(tbLossQty.Text.Length, 1)
            Case 254
                'ю
                e.Handled = True
                tbLossQty.Text += ","
                tbLossQty.Select(tbLossQty.Text.Length, 1)
            Case 13
                'преобразование гр в кг
                'замена гр на кг
                Dim _result As Decimal
                If Decimal.TryParse(tbLossQty.Text, _result) Then
                    'проверить, есть ли точка
                    For Each s In tbLossQty.Text
                        If Char.IsPunctuation(s) Then
                            'есть точка, выход
                            Return
                        End If
                    Next
                    'точки нет
                    _result = _result / 1000
                    tbLossQty.Text = _result.ToString
                    tbLossQty.Select(tbLossQty.Text.Length, 1)
                    e.Handled = True
                End If
        End Select
    End Sub

    Private Sub tbLossQty_LostFocus(sender As Object, e As System.EventArgs) Handles tbLossQty.LostFocus, tbLossQty.TextChanged
        CType(sender, Control).BackColor = Color.White
    End Sub

    Private Sub tbLossQty_Enter(sender As Object, e As System.EventArgs) Handles tbLossQty.Enter
        Dim _result As Decimal
        If Decimal.TryParse(sender.text, _result) Then
            If _result = 0 Then
                sender.text = ""
            End If
        End If
    End Sub

    ''' <summary>
    ''' спишет товар со склада
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btLoss_Click(sender As System.Object, e As System.EventArgs) Handles btLoss.Click
        Dim _lossqty As Decimal = 0
        Dim _enterQty As Decimal = 0
        Dim _message As String = ""

        'проверка условий
        If oCurrentLossGood Is Nothing Then
            MsgBox("Внутренняя ошибка! Товар для списания oCurrentLossGood НЕ создан!", vbCritical)
            Return
        End If

        If cbxLossEnable.Checked = False Then Return
        'проверим, задано ли кол-во нового товара перед списанием
        If Me.SlotGoodBindingSource.Current Is Nothing Then
            MsgBox("Перед списанием необходимо указать кол-во создаваемого товара!", vbCritical)
            Me.oSplashscreen1.Hide()
            Return
        End If
        'кол-во к оприходованию
        _enterQty = CType(Me.SlotGoodBindingSource.Current, clsGoodLocation.clsSlot).Qty
        If Not _enterQty > 0 Then
            MsgBox("Перед списанием необходимо указать кол-во создаваемого товара!", vbCritical)
            Me.oSplashscreen1.Hide()
            Return
        End If


        'остатки
        If Me.cbLossLocations.SelectedItem Is Nothing Then
            MsgBox("Необходимо выбрать остатки для списания товара!", vbCritical)
            Return
        End If
        Dim _slot As clsGoodLocation.clsSlot = Me.cbLossLocations.SelectedItem

        'кол-во к списанию
        _lossqty = clsApplicationTypes.ReplaceDecimalSplitter(Me.tbLossQty)
        If _lossqty = 0 Then
            MsgBox("Задайте ненулевое кол-во товара к списанию!", vbCritical)
            Me.oSplashscreen1.Hide()
            Return
        End If
        '---------------------
        'проверка еденицы списывания
        If Me.cbUom.SelectedIndex = -1 Then
            MsgBox("Задайте единицу измерения приходуемого товара!", vbCritical)
            Me.oSplashscreen1.Hide()
            Return
        End If
        '----------------------------
        'проверка ед. измерения
        Dim _differentUom As Boolean = True
        If oManager.GetUomByUUID(oCurrentLossGood.Good.uomUuid).name = oManager.GetUomByUUID(Me.cbUom.SelectedItem.uuid).name Then
            'списываем и зачисляем одиноковые еденицы измерения
            If Not _lossqty = clsApplicationTypes.ReplaceDecimalSplitter(Me.tbQty) Then
                If MsgBox("Количества списываемого и приходуемого товара различаются, хотя единица измерения одинакова! Все равно продолжить списание?", vbYesNo) = MsgBoxResult.No Then
                    Me.oSplashscreen1.Hide()
                    Return
                End If
            End If
        Else
            _differentUom = False
        End If

        'списать товар определенного артикула
        If _slot Is Nothing Then
            MsgBox("Внутренняя ошибка - обьект clsSlot не задан! ", vbCritical)
            Me.oSplashscreen1.Hide()
            Return
        End If

        Dim _lossgood = oCurrentLossGood
        If _lossgood Is Nothing Then
            MsgBox("Внутренняя ошибка - обьект oCurrentLossGood не задан (товар, с которого списываем)! ", vbCritical)
            Me.oSplashscreen1.Hide()
            Return
        End If
        Dim _location As clsGoodLocation = (From c In _lossgood.Locations Where c.WarehouseUUID = _slot.WarehouseUUID Select c).FirstOrDefault
        If _location Is Nothing Then
            MsgBox("Внутренняя ошибка - обьект  _good.Location не задан! ", vbCritical)
            Me.oSplashscreen1.Hide()
            Return
        End If
        If _location.LinkedLoss Is Nothing Then
            _location.LinkedLoss = oManager.GetLossByWarehouseUUID(_location.WarehouseUUID)
            If _location.LinkedLoss Is Nothing Then
                MsgBox("Ошибка - документ списание для запрашиваемого склада отсутствует (обьект LinkedLoss не задан)! ", vbCritical)
                Me.oSplashscreen1.Hide()
                Return
            End If
        End If
        If _lossqty > _slot.Qty Then
            MsgBox("Нельзя списывать товара больше (" & _lossqty & "), чем имеющееся кол-во(" & _slot.Qty & ")! Проверте остаток по складу.", vbCritical)
            Me.oSplashscreen1.Hide()
            Return
        End If

        Dim _LossGoodBuyPrice = _lossgood.Good.buyPrice / 100
        Dim _lossUomName = oManager.GetUomByUUID(_lossgood.Good.uomUuid).name
        Dim _lossCurrencyName = oManager.GetCurrencyByUUID(_lossgood.Good.buyCurrencyUuid).name
        Dim _TargetBuyPrice As Decimal = 0
        Dim _shippingAdd As Decimal = 0

        '------------шиппинг
        If Me.cbxWriteAdditionalPrices.Checked Then
            'проверка шиппинга
            If Not Decimal.TryParse(Me.tbShippingPrice.Text, _shippingAdd) Then
                MsgBox("Задайте стоимость доставки для расчета вхдящей стоимости!", vbCritical)
                Me.oSplashscreen1.Hide()
                Return
            End If
        End If
        '-------------
        'проверить указание кол-ва в оприходовании для расчета себестоимости

        If Me.cbxIncomingPrices.Checked Then

            _TargetBuyPrice = ((_LossGoodBuyPrice) * _lossqty) / _enterQty

            If _LossGoodBuyPrice = 0 Then
                MsgBox(String.Format("Не задана закупочная цена списываемого товара {0}! Отмените рассчет входящей или откройте карточку товара в МС и задайте закупочную цену!", oCurrentLossGood.AnyCode), vbCritical)
                Me.cbxIncomingPrices.BackColor = Color.Red
                Me.oSplashscreen1.Hide()
                Return
            Else
                'проверка указания валюты списываемого товара
                If oCurrentLossGood.Good.buyCurrencyUuid Is Nothing Then
                    MsgBox(String.Format("Не задана валюта входящей цены списываемого товара {0}! Отмените рассчет входящей или откройте карточку товара в МС и задайте валюту!", oCurrentLossGood.AnyCode), vbCritical)
                    Me.cbxIncomingPrices.BackColor = Color.Red
                    Me.oSplashscreen1.Hide()
                    Return
                End If
            End If
        End If

        '=====================
        'провеки пройдены
        '-----------------------
        _message = String.Format("Списываем {0}{1} товара {2} со склада: {3};{4}{4}", _lossqty, oManager.GetUomByUUID(oCurrentLossGood.Good.uomUuid).name, oCurrentLossGood.Name, _slot.SlotString, ChrW(13))
        _message += String.Format("для приходования {0}{1} нового товара;{2}", _enterQty, oManager.GetUomByUUID(Me.cbUom.SelectedItem.uuid).name, ChrW(13))
        '----Рассчет цен
        If Me.cbxIncomingPrices.Checked Then
            Dim _fullIncomingprice As Double = Math.Round(_TargetBuyPrice, 2)
            If clsApplicationTypes.GetAccess("цена инвойса и закупки") Then
                _message += String.Format("себестоимость списываемого кол-ва: {0} {1}; {2}", Math.Round(_LossGoodBuyPrice * _lossqty, 2), _lossCurrencyName, ChrW(13))
                _message += String.Format("себестоимость приходуемой еденицы: {0} {1}; {2}", _TargetBuyPrice, _lossCurrencyName, ChrW(13))
                If cbxNakladnye.Checked Then
                    _message += String.Format("накладные {0}%(+{1}{2}) включены; {3}", (My.Settings.Nakladnye - 1) * 100, Math.Round((My.Settings.Nakladnye - 1) * _TargetBuyPrice, 2), _lossCurrencyName, ChrW(13))
                    _fullIncomingprice += (My.Settings.Nakladnye - 1) * _TargetBuyPrice
                End If
                If Me.cbxWriteAdditionalPrices.Checked Then
                    _message += String.Format("шиппинг в размере +{0}{1} на приходуемую еденицу включен; {2}", Math.Round((_lossqty * _shippingAdd / _enterQty), 2), _lossCurrencyName, ChrW(13))
                    _fullIncomingprice += (_lossqty * _shippingAdd / _enterQty)
                End If

                _message += String.Format("полная входящая стоимость приходуемой еденицы: {0} {1}; {2}", Math.Round(_fullIncomingprice, 2), _lossCurrencyName, ChrW(13))

            End If
        End If

        _message += ChrW(13) & "НЕ забудте задать розницу!"

        'вопрос
        Dim _answermsg As String = ""
        Select Case MsgBox(_message, vbQuestion + vbYesNo, "Подтвердить списание")
            Case MsgBoxResult.Yes
                'показат сплеш
                If oSplashscreen1.Visible = False Then
                    oSplashscreen1.Show()
                    oSplashscreen1.Refresh()
                End If

                Dim servermessage As String = ""

                '====создать списание
                Dim _result = oManager.AddLossToServer(_slot.WarehouseUUID, _lossgood.UUID, _lossqty, _slot.SlotUUID, oCurrentGood, _location.LinkedLoss, servermessage)

                Select Case _result
                    Case Is > 0
                        ''артикул списания

                        _answermsg += String.Format("списано {0} {1} товара; {2}", _lossqty, _lossUomName, ChrW(13))

                        'проставить массу в целевой карточке товара
                        If _lossUomName = "kg" Or _lossUomName = "кг" Then
                            oCurrentGood.Weight = Decimal.Round(_lossqty / _enterQty, 3)
                            Me.MarkAsNeedSaved()
                        ElseIf _lossUomName = "g" Or _lossUomName = "г" Then
                            oCurrentGood.Weight = Decimal.Round(_lossqty / 1000 / _enterQty)
                            Me.MarkAsNeedSaved()
                        End If

                        'расчет цен себестоимости
                        '============================

                        If cbxIncomingPrices.Checked = True Then
                            '--------Грязная себестоимость без накладных и доставки------------------

                            'считаем курс списания
                            Dim _LossCurrency = oManager.GetCurrencyByUUID(_lossgood.Good.buyCurrencyUuid)
                            'курс  валюты списания к базовой валюте (рублю)
                            Dim _rateToBaseLoss = _LossCurrency.rate

                            If _rateToBaseLoss = 0 Then
                                _rateToBaseLoss = 1
                            End If


                            'цена закупки списанного кол-ва, деленное на требуемое кол-во
                            'проверка ненулевого кол-ва выполняется при включении флажка списания
                            'грязная закупка одной ед товара к оприходованию
                            '_enterQty это кол-во приходуемого товара
                            '_newlossitem.quantity это кол-во списываемого товара
                            'денег за еденицу товара
                            Dim _RawBuyPrice = _TargetBuyPrice

                            If cbxNakladnye.Checked Then
                                'добавить накладные
                                _TargetBuyPrice = Math.Round(_TargetBuyPrice * My.Settings.Nakladnye, 2)
                            End If

                            '-------------------------------
                            'розница
                            'ретайл списываемого в базовой валюте (в рублях)
                            Dim _retailToBase = Math.Round(_lossgood.Good.salePrice / 100 * _rateToBaseLoss, 2)
                            'цена еденицы = 
                            Dim _retailTargetPrice = Math.Round((_lossqty * _retailToBase) / _enterQty, 2)
                            If Me.cbRetailTargetCurrency.SelectedItem Is Nothing Then
                                'установим валюту розницы
                                Me.cbRetailTargetCurrency.SelectedItem = (From c As MoySkladAPI.currency In Me.cbRetailTargetCurrency.Items Where c.uuid = _lossgood.Good.buyCurrencyUuid Select c).FirstOrDefault
                            Else
                                'приведем к выбранной пользователем валюте по курсу
                                Dim _retailRate = CType(Me.cbRetailTargetCurrency.SelectedItem, MoySkladAPI.currency).rate
                                If Not (_retailRate * _retailToBase) = 0 Then
                                    Me.tbRetailTargetValue.Text = Math.Round(_retailRate * _retailToBase, 2)
                                Else
                                    _answermsg += ChrW(13) & "Невозможно посчитать накладные и розницу, т.к. "
                                    Me.tbRetailTargetValue.Text = "0"
                                End If
                            End If
                            '----------------------------------
                            'шиппинг
                            Dim _shipTotaltopcs As Double
                            If Me.cbxWriteAdditionalPrices.Checked Then
                                'задать шиппинг
                                Dim _euro = (From c In oManager.CurrencyList Where c.name = "EUR" Select c).FirstOrDefault
                                Dim _kursBaseEur = _euro.rate
                                '_shippingAdd это стоимость доставки еденицы товара
                                '_newlossitem.quantity это кол-во списываемого товара
                                '_enterQty это кол-во приходуемого товара
                                _shipTotaltopcs = Math.Round((_lossqty * _shippingAdd * (_kursBaseEur / _rateToBaseLoss) / _enterQty), 2)
                                _TargetBuyPrice = _TargetBuyPrice + _shipTotaltopcs
                            End If
                            '------------------------
                            'закупка
                            If Me.oCurrentGood.Good.buyPriceSpecified = True AndAlso Me.oCurrentGood.Good.buyPrice > 0 AndAlso Me.oCurrentGood.Good.buyPrice <> _TargetBuyPrice * 100 Then

                                Dim _msg As String = ""
                                'в рублях и в формате МС
                                Dim _existBuyPrice = clsApplicationTypes.GetRateByCurrencyCB103(oManager.GetCurrencyByUUID(Me.oCurrentGood.Good.buyCurrencyUuid).name) * Me.oCurrentGood.Good.buyPrice
                                Dim _newBuyPrice = clsApplicationTypes.GetRateByCurrencyCB103(oManager.GetCurrencyByUUID(_lossgood.Good.buyCurrencyUuid).name) * _TargetBuyPrice * 100
                                'остатки * входящую
                                'кол-во по всем складам
                                Dim _existQTY = Aggregate c In oCurrentGood.Locations Into Sum(c.TotalQty)

                                'усредняем по кол-ву 
                                Dim _outBuyPrice = (_existQTY * _existBuyPrice + _enterQty * _newBuyPrice) / (_existQTY + _enterQty) / clsApplicationTypes.GetRateByCurrencyCB103(oManager.GetCurrencyByUUID(Me.oCurrentGood.Good.buyCurrencyUuid).name)


                                If Not clsApplicationTypes.GetAccess("цена инвойса и закупки") Then
                                    'ставлю усредненную по количеству
                                    Me.oCurrentGood.Good.buyPrice = _outBuyPrice
                                Else
                                    _msg = String.Format("Цена закупки существует: {0} {1}. Да/yes - заменить на взвешенную усредненную рассчитанную: {2} {1}. нет/no - оставить старую. отмена/cancel - заменить на рассчитанную (новую) {3} {1}.{4} Рассчет: Грязная(лот)={5}; накладные(лот)={6};шиппинг(лот)={7}", Me.oCurrentGood.Good.buyPrice / 100, oManager.GetCurrencyByUUID(Me.oCurrentGood.Good.buyCurrencyUuid).name, _outBuyPrice / 100, _newBuyPrice / 100 / clsApplicationTypes.GetRateByCurrencyCB103(oManager.GetCurrencyByUUID(Me.oCurrentGood.Good.buyCurrencyUuid).name), ChrW(13), _RawBuyPrice, _RawBuyPrice * My.Settings.Nakladnye, _shipTotaltopcs)

                                    'заменить цену товара??'валюту НЕ МЕНЯЕМ
                                    Select Case MsgBox(_msg, vbYesNoCancel)
                                        Case MsgBoxResult.Yes
                                            Me.oCurrentGood.Good.buyPrice = _outBuyPrice
                                        Case MsgBoxResult.No
                                            'ничего не делаем
                                        Case MsgBoxResult.Cancel
                                            'переведем в валюту и сохраним новую
                                            Me.oCurrentGood.Good.buyPrice = _TargetBuyPrice * 100 / clsApplicationTypes.GetRateByCurrencyCB103(oManager.GetCurrencyByUUID(Me.oCurrentGood.Good.buyCurrencyUuid).name)
                                    End Select
                                End If
                            Else
                                'цены закупки нет- установить
                                Me.oCurrentGood.Good.SetPriceByType(oManager, iMoySkladDataProvider.emPriceType.BuyPrice, _TargetBuyPrice, oManager.GetCurrencyByUUID(_lossgood.Good.buyCurrencyUuid).name)
                            End If

                            'установить полную стоимость закупки в рублях для рассчета таблицы цен
                            If Me.cbxBuyCalc.Checked Then
                                If clsApplicationTypes.ReplaceDecimalSplitter(Me.tbBuyCost) = 0 Then
                                    Dim _curr = (From c As MoySkladAPI.currency In Me.cbBuyTargetCurrency.Items Where c.uuid = Me.oCurrentGood.Good.buyCurrencyUuid Select c).FirstOrDefault
                                    Me.tbBuyCost.Text = clsApplicationTypes.CurrencyConvert(Me.oCurrentGood.Good.buyPrice / 100, _curr.name, "RUR")
                                End If
                            End If

                            'показать админу
                            If clsApplicationTypes.GetAccess("цена инвойса и закупки") Then
                                'отобразить рассчет
                                Me.cbBuyTargetCurrency.SelectedItem = (From c As MoySkladAPI.currency In Me.cbBuyTargetCurrency.Items Where c.uuid = Me.oCurrentGood.Good.buyCurrencyUuid Select c).FirstOrDefault
                                Me.tbBuyTargetValue.Text = Me.oCurrentGood.Good.buyPrice / 100
                                Me.cbxSetBuy.Checked = True
                            End If

                            Me.MarkAsNeedSaved()
                        End If
                        '==== конец рассчета цен закупки



                        '--------------
                        If Me.tbName.Text = "" Then
                            Me.BtCopyName_Click(Me, EventArgs.Empty)
                        Else
                            If Me.tbName.Text.ToLower.Contains("(общий)".ToLower) Then
                                Me.oCurrentGood.Name = Me.tbName.Text.Replace("(общий)", "")
                                Me.bsCurrentGood.ResetCurrentItem()
                            End If
                        End If
                        '--------------
                        Me.ToolStripStatusLabel1.Text = _answermsg
                        clsApplicationTypes.BeepYES()
                    Case Is <= 0
                        MsgBox("Ошибка при создании списания на сервере! " & servermessage, vbCritical)
                        Me.oSplashscreen1.Hide()
                        Return
                End Select


                '--установка ЭУ--------
                Me.oSplashscreen1.Hide()

                If oWillNewGoodFlag = True Then
                    'добавляемый товар - сначала создать карточку
                    Me.btCreateGood.Enabled = True
                    Me.btCreateGood.BackColor = Color.Red
                    oRedKeyOff = True
                Else
                    'уже созданный товар - добавить на склад
                    Me.btAddGoodToWare.Enabled = True
                    Me.btAddGoodToWare.BackColor = Color.Red
                End If

                'установка цен
                Me.cbxSetRetail.Checked = True
                If Me.tbRetailTargetValue.Text = "NaN" Then
                    Me.tbRetailTargetValue.Text = "0"
                End If

                If Me.tbInvoice.Text = "NaN" Then
                    Me.tbInvoice.Text = "0"
                End If
                oRedKeyOff = False
                Me.tbRetailTargetValue.Focus()
            Case MsgBoxResult.No
                Return
        End Select
    End Sub

#End Region

#Region "Подсказка цены"
    Private Sub cbBuyTargetCurrency_MouseHover(sender As Object, e As System.EventArgs) Handles tbBuyTargetValue.MouseEnter
        'отобразить курс пересчета в рубли
        'пересчет по курсу
        If Me.cbBuyTargetCurrency.SelectedItem Is Nothing Then Return
        Dim _currBuy = CType(Me.cbBuyTargetCurrency.SelectedItem, MoySkladAPI.currency)
        Dim _kursBaseBuy = _currBuy.rate
        Dim _currSale As MoySkladAPI.currency
        If Me.cbRetailTargetCurrency.SelectedIndex = -1 Then
            _currSale = (From c In oManager.CurrencyList Where c.name = "RUR" Select c).FirstOrDefault
        Else
            _currSale = CType(Me.cbRetailTargetCurrency.SelectedItem, MoySkladAPI.currency)
        End If
        Dim _kursBaseSale = _currSale.rate
        If Me.tbBuyTargetValue.Text = "" Then Me.tbBuyTargetValue.Text = "0"
        Dim _ratedValue = Math.Round((clsApplicationTypes.ReplaceDecimalSplitter(Me.tbBuyTargetValue) * (_kursBaseBuy / _kursBaseSale)), 2)
        oBuyToolTip.ToolTipTitle = "Пересчет в " & _currSale.name
        oBuyToolTip.Show(_ratedValue, tbBuyTargetValue)

    End Sub

    Private Sub cbBuyTargetCurrency_MouseLeave(sender As Object, e As System.EventArgs) Handles tbBuyTargetValue.MouseLeave
        oBuyToolTip.Hide(tbBuyTargetValue)
    End Sub

    ''' <summary>
    ''' рассчитывает стоимость препарации в зависимости от прописанного в опциях
    ''' </summary>
    ''' <param name="Nalogi">сумма налогов</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function PrepCalculate(PayByCash As Decimal, Optional ByRef Nalogi As Decimal = 0, Optional ByRef OurProfit As Decimal = 0, Optional ByRef FriendPrepPrice As Decimal = 0) As Decimal

        Dim _out As Decimal = 0
        'грязная зп (выплаченный налик)
        _out += PayByCash

        '+налоги на ЗП (50.29% в России в 2015г)
        Nalogi = _out * My.Settings.NLcost / 100
        _out += Nalogi

        '+наш бабос с часа = +100%(в настройках) с брутто
        OurProfit = PayByCash * (My.Settings.TRsalary / 100)
        _out += OurProfit

        'френд цена на препарацию = фактические затраты +50%
        FriendPrepPrice = PayByCash * 1.5 + Nalogi

        Return clsApplicationTypes.RoundPrice(_out)
    End Function

    ''' <summary>
    ''' предрассчет розницы Россия
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cbRetailTargetCurrency_MouseEnter(sender As Object, e As System.EventArgs) Handles tbRetailTargetValue.MouseEnter
        If Me.cbBuyTargetCurrency.SelectedItem Is Nothing OrElse Me.cbRetailTargetCurrency.SelectedItem Is Nothing Then
            Return
        End If

        'валюта покупки
        Dim _currBuy = CType(Me.cbBuyTargetCurrency.SelectedItem, MoySkladAPI.currency)
        'сумма покупки в рублях
        Dim _Buy = clsApplicationTypes.CurrencyConvert(clsApplicationTypes.ReplaceDecimalSplitter(Me.tbBuyTargetValue), _currBuy.name, "RUR")

        'валюта продажи
        Dim _currSale = CType(Me.cbRetailTargetCurrency.SelectedItem, MoySkladAPI.currency)
        'сумма продажи в валюте продажи
        Dim _sale = clsApplicationTypes.CurrencyConvert(_Buy * 4, "RUR", _currSale.name)
        _sale = clsApplicationTypes.RoundPrice(_sale)

        '=========================
        'покажем в валюте розницы (или закупки) цену*4
        Dim _descr = "закупка, умноженная на 4"
        Dim _titlestring = String.Format("{0} {1}", _sale, _currSale.name)
        ''стоимость препарации в рублях - с учетом дохода конторы и налогов
        'Dim _BruttoSalary As Decimal = 0
        'Dim _FriendPrepCost As Decimal = 0
        'Dim _Nalogi As Decimal = 0
        'Dim _Oursalary As Decimal = 0
        'Dim _OursalaryForFriend As Decimal = 0
        'Dim _preparation = PrepCalculate(HourValue:=clsApplicationTypes.ReplaceDecimalSplitter(tbPrepTime.Text), user:=Me.cbMainPreparator.SelectedItem, BruttoSalary:=_BruttoSalary, FriendPrepCost:=_FriendPrepCost, Nalogi:=_Nalogi, Oursalary:=_Oursalary, OurProfitIfSalaryForFriend:=_OursalaryForFriend)

        ''===============================
        ''стоимость перевозки в рублях
        'Dim _shippingTariff = clsApplicationTypes.ReplaceDecimalSplitter(tbWeightTariff)
        'If Me.tbWeightTariff.Text = "" Then
        '    'автоустановка тарифа
        '    Select Case Me.cbWeightTariff.SelectedIndex
        '        Case Is <= 0
        '            _shippingTariff = My.Settings.ShippingTariffPerKG
        '        Case 1
        '            _shippingTariff = My.Settings.ShippingTariffPerPCS
        '        Case Else
        '            _shippingTariff = My.Settings.ShippingTariffPerE
        '    End Select
        'End If
        'Dim _shipping = clsApplicationTypes.CurrencyConvert(clsApplicationTypes.ReplaceDecimalSplitter(tbWeight) * _shippingTariff, "EUR", "RUR")

        ''=========================
        ''рассчет 2015 выяснить чистую закупку = инвойс
        'Dim _clearBuy As Decimal
        'Select Case cbIncomingPriceType.SelectedIndex
        '    Case Is < 0
        '        'не выбран
        '        _clearBuy = _buy
        '    Case 0
        '        'чистый инвойс
        '        _clearBuy = _buy
        '    Case 1
        '        'накладные включены
        '        _clearBuy = _buy / My.Settings.Nakladnye
        '    Case 2
        '        'накладные включены + шиппинг
        '        _clearBuy = (_buy - _shipping) / My.Settings.Nakladnye
        '    Case 3
        '        'накладные включены + препарация
        '        _clearBuy = (_buy - _preparation) / My.Settings.Nakladnye
        '    Case 4
        '        'накладные включены + шиппинг+преп.
        '        _clearBuy = (_buy - _preparation - _shipping) / My.Settings.Nakladnye
        'End Select
        'If _clearBuy < 0 Then
        '    'неверно выбран тип входящей цены
        '    'рассчет приводит к отрицательной закупке (например, сумма препарации и шиппинга меньше входящей стоимости). Вероятно не учтены накладные расходы. Требуется увеличить входящую или выбрать другой тип входящей цены
        '    Do Until _clearBuy > 0
        '        _buy += 1
        '        _clearBuy = (_buy - _preparation - _shipping) / My.Settings.Nakladnye
        '    Loop
        'End If
        ''===========================
        ''рассчет 2015 == ((инвойс*коэфф. прибыли) + накладные + препарация + шиппинг)*[1.24=кредитн.ставка]
        'Dim _calculatedValue = (_clearBuy * My.Settings.ProfitSTD) + _clearBuy * (1 - My.Settings.Nakladnye) + _preparation + _shipping
        ''добавить кредитную ставку на год 24%
        '_calculatedValue = clsApplicationTypes.RoundPrice(_calculatedValue * (1 + My.Settings.Credit / 100))

        ''препарация для ребят
        'Dim _calculatedFriendValue = (_clearBuy * My.Settings.ProfitSTD) + _clearBuy * (1 - My.Settings.Nakladnye) + _FriendPrepCost + _shipping
        ''добавить кредитную ставку на год 24%
        '_calculatedFriendValue = clsApplicationTypes.RoundPrice(_calculatedFriendValue * (1 + My.Settings.Credit / 100))

        'Dim _salaryString = String.Format("препар. оплачено: {2}{1}, к рассчету: {0}{1} [в т.ч. своим: {3}{1}, налоги/обнал: {4}{1}(должно быть {5}{1})] ", clsApplicationTypes.CurrencyConvert(_preparation, "RUR", _currSale.name), clsApplicationTypes.GetCurrencySymbol(_currSale.name), clsApplicationTypes.CurrencyConvert(_BruttoSalary, "RUR", _currSale.name), clsApplicationTypes.CurrencyConvert(_FriendPrepCost, "RUR", _currSale.name), clsApplicationTypes.CurrencyConvert(_Nalogi, "RUR", _currSale.name), Math.Round(46.7 / My.Settings.NLcost * _Nalogi, 0))

        'Dim _shippingString = String.Format("шиппинг: {0}{1}", clsApplicationTypes.CurrencyConvert(_shipping, "RUR", _currSale.name), clsApplicationTypes.GetCurrencySymbol(_currSale.name))

        'Dim _for30 = clsApplicationTypes.RoundPrice(_calculatedValue / 0.7)

        'Dim _titleString = String.Format("{5}{6}Можно: {3}{1} c макс.скид.:{4}% // Своим:{2}{1} // Мин.:{0}{1}  ", clsApplicationTypes.CurrencyConvert(_clearBuy * My.Settings.Nakladnye + _BruttoSalary + _Nalogi + _shipping, "RUR", _currSale.name), clsApplicationTypes.GetCurrencySymbol(_currSale.name), clsApplicationTypes.CurrencyConvert(_calculatedFriendValue, "RUR", _currSale.name), clsApplicationTypes.CurrencyConvert(_calculatedValue, "RUR", _currSale.name), Decimal.Round((1 - _calculatedFriendValue / _calculatedValue) * 100), If(_clearBuy = 0, "Вход материала=0 (не учтен)! ", ""), If(((1 - _calculatedFriendValue / _calculatedValue) * 100 - 30) < 0, String.Format("Розница {0}{1} // ", clsApplicationTypes.CurrencyConvert(_for30, "RUR", _currSale.name), clsApplicationTypes.GetCurrencySymbol(_currSale.name)), ""), Environment.NewLine)
        ''clsApplicationTypes.CurrencyConvert(_calculatedValue * 0.7, "RUR", _currSale.name)


        'Dim _descr = String.Format("Рекоменд. розница:   {0}{1}(при коэфф.{2}, и -30% оптовой цены){6}Закуп. с накл. оплач. {5}{1}{6}{3} {6}{4}", clsApplicationTypes.CurrencyConvert(If(_calculatedValue > _for30, clsApplicationTypes.RoundPrice(_calculatedValue), _for30), "RUR", _currSale.name), clsApplicationTypes.GetCurrencySymbol(_currSale.name), My.Settings.ProfitSTD, If(_preparation = 0, "препарация не задана", _salaryString), If(_shipping = 0, "шиппинг не задан", _shippingString), clsApplicationTypes.CurrencyConvert(Math.Round(_clearBuy * My.Settings.Nakladnye), "RUR", _currSale.name), Environment.NewLine)
        'If Not clsApplicationTypes.GetAccess("конторские тарифы") Then
        '    _descr = "подробности скрыты"
        'End If
        oBuyToolTip.ToolTipTitle = _titlestring
        oBuyToolTip.Show(_descr, tbRetailTargetValue, 120000)

    End Sub

    Private Sub cbRetailTargetCurrency_MouseLeave(sender As Object, e As System.EventArgs) Handles tbRetailTargetValue.MouseLeave
        oBuyToolTip.Hide(tbRetailTargetValue)
    End Sub
    Private Sub tbInvoice_MouseHover(sender As Object, e As System.EventArgs) Handles tbInvoice.MouseHover
        'отобразить курс пересчета в рубли
        'пересчет по курсу
        If Me.cbInvoceCurrency.SelectedItem Is Nothing Then Return
        Dim _currBuy = CType(Me.cbInvoceCurrency.SelectedItem, MoySkladAPI.currency)
        Dim _kursBaseBuy = _currBuy.rate
        Dim _currSale As MoySkladAPI.currency
        If Me.cbInvoceCurrency.SelectedIndex = -1 Then
            _currSale = (From c In oManager.CurrencyList Where c.name = "RUR" Select c).FirstOrDefault
        Else
            If Me.cbRetailTargetCurrency.SelectedItem Is Nothing Then
                _currSale = (From c In oManager.CurrencyList Where c.name = "RUR" Select c).FirstOrDefault
            Else
                _currSale = CType(Me.cbRetailTargetCurrency.SelectedItem, MoySkladAPI.currency)
            End If

        End If
        Dim _kursBaseSale = _currSale.rate
        If Me.tbInvoice.Text = "" Then Me.tbInvoice.Text = "0"
        Dim _ratedValue = Math.Round((Decimal.Parse(Me.tbInvoice.Text) * (_kursBaseBuy / _kursBaseSale)), 2)
        oBuyToolTip.ToolTipTitle = "Пересчет в " & _currSale.name
        oBuyToolTip.Show(_ratedValue, tbInvoice)


    End Sub

    Private Sub tbInvoice_MouseLeave(sender As Object, e As System.EventArgs) Handles tbInvoice.MouseLeave
        oBuyToolTip.Hide(tbInvoice)
    End Sub

#End Region

#Region "Цены карточки товара и рассчета по списанию"
    Private Sub tbRetailTargetValue_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tbRetailTargetValue.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            Me.cbxSetRetail.Checked = True
        ElseIf Asc(e.KeyChar) = 13 Then
            If Me.cbRetailTargetCurrency.SelectedIndex = -1 Then
                Me.cbRetailTargetCurrency.SelectedIndex = 1
            End If
            Me.cbRetailTargetCurrency.Focus()
        End If
    End Sub

    Private Sub cbRetailTargetCurrency_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cbRetailTargetCurrency.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Me.btAddGoodToWare.Focus()
        End If
    End Sub

    Private Sub cbxSetRetail_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles cbxSetRetail.CheckedChanged
        If cbxSetRetail.Checked Then
            Me.MarkAsNeedSaved()

            Me.tbRetailTargetValue.Enabled = True
            Me.cbRetailTargetCurrency.Enabled = True
            Me.tbRetailTargetValue.Focus()
        Else
            Me.tbRetailTargetValue.Enabled = False
            Me.cbRetailTargetCurrency.Enabled = False
        End If
    End Sub

    Private Sub tbBuyTargetValue_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tbBuyTargetValue.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            Me.cbxSetBuy.Checked = True
        ElseIf Asc(e.KeyChar) = 13 Then
            If Me.cbBuyTargetCurrency.SelectedIndex = -1 Then
                Me.cbBuyTargetCurrency.SelectedIndex = 1
            End If
            Me.cbBuyTargetCurrency.Focus()
        End If
    End Sub

    Private Sub cbBuyTargetCurrency_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cbBuyTargetCurrency.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            Me.cbxSetBuy.Checked = True
        ElseIf Asc(e.KeyChar) = 13 Then
            If Me.cbBuyTargetCurrency.SelectedIndex = -1 Then
                Me.cbBuyTargetCurrency.SelectedIndex = 1
            End If
            Me.cbBuyTargetCurrency.Focus()
        End If
    End Sub

    Private Sub cbxSetBuy_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles cbxSetBuy.CheckedChanged
        If cbxSetBuy.Checked Then
            If oWillNewGoodFlag = False And oRedKeyOff = False Then
                Me.MarkAsNeedSaved()

            End If

            Me.tbBuyTargetValue.Enabled = True
            Me.cbBuyTargetCurrency.Enabled = True
            Me.tbBuyTargetValue.Focus()
        Else

            Me.tbBuyTargetValue.Enabled = False
            Me.cbBuyTargetCurrency.Enabled = False
        End If
    End Sub

    Private Sub tbRetailTargetValue_MouseDoubleClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles tbRetailTargetValue.MouseDoubleClick
        If Not clsRestMS_service.GetDigiKey Is Nothing Then
            clsRestMS_service.GetDigiKey.connect(Me.tbRetailTargetValue)
        End If
    End Sub
    Private Sub tbBuyTargetValue_MouseDoubleClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles tbBuyTargetValue.MouseDoubleClick
        If Not clsRestMS_service.GetDigiKey Is Nothing Then
            clsRestMS_service.GetDigiKey.connect(Me.tbBuyTargetValue)
        End If
    End Sub

    Private Sub cbBuyTargetCurrency_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbBuyTargetCurrency.SelectedIndexChanged

        If Me.cbBuyTargetCurrency.SelectedItem Is Nothing Then Return

        'удалено 22/06/2016 Me.cbInvoceCurrency.SelectedIndex = cbBuyTargetCurrency.SelectedIndex

        If oCurrentBuyCurrency Is Nothing Then
            oCurrentBuyCurrency = Me.cbBuyTargetCurrency.SelectedItem
        End If
        'пересчет суммы в курс
        If Me.tbBuyTargetValue.Text = "" Then Me.tbBuyTargetValue.Text = "0"
        Dim _retail = Decimal.Parse(Me.tbBuyTargetValue.Text)
        'приведем к выбранному курсу
        Dim _retailNewRate = CType(Me.cbBuyTargetCurrency.SelectedItem, MoySkladAPI.currency).rate
        Dim _retailOldRate = CType(oCurrentBuyCurrency, MoySkladAPI.currency).rate

        Me.tbBuyTargetValue.Text = Math.Round(_retail * _retailOldRate / _retailNewRate, 2)

        If _retail > 0 Then
            If oWillNewGoodFlag = False And Not Me.oCurrentGood Is Nothing And oRedKeyOff = False Then
                Me.MarkAsNeedSaved()
            End If
        End If
    End Sub

    Private Sub tbInvoice_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tbInvoice.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            Me.cbxInvoice.Checked = True
        ElseIf Asc(e.KeyChar) = 13 Then
            If Me.cbInvoceCurrency.SelectedIndex = -1 Then
                Me.cbInvoceCurrency.SelectedIndex = 1
            End If
            Me.cbInvoceCurrency.Focus()
        End If
    End Sub

    Private Sub cbxInvoice_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles cbxInvoice.CheckedChanged
        If cbxInvoice.Checked Then
            If oWillNewGoodFlag = False And oRedKeyOff = False Then
                Me.MarkAsNeedSaved()
            End If
            Me.btIncomingCalculate.Enabled = True
            Me.tbInvoice.Enabled = True
            Me.cbInvoceCurrency.Enabled = True
            Me.tbInvoice.Focus()
        Else
            Me.btIncomingCalculate.Enabled = False
            Me.tbInvoice.Enabled = False
            Me.cbInvoceCurrency.Enabled = False
        End If
    End Sub



    ''' <summary>
    ''' добавляет сумму к входящей в зависимости от выбранной валюты
    ''' </summary>
    ''' <param name="rurCost"></param>
    ''' <remarks></remarks>
    Private Sub AddIncomingCost(rurCost As Decimal, Optional ClearOldValue As Boolean = False)
        'добавить во входящие, учитывая валюту
        'определить валюту, по умолчанию поставить рубль
        If cbBuyTargetCurrency.SelectedItem Is Nothing Then cbBuyTargetCurrency.SelectedIndex = 1
        Dim _curr = CType(cbBuyTargetCurrency.SelectedItem, MoySkladAPI.currency)
        Dim _addcostInCurrcency = clsApplicationTypes.CurrencyConvert(rurCost, "RUR", _curr.name)
        Dim _oldValue = clsApplicationTypes.ReplaceDecimalSplitter(Me.tbBuyTargetValue)
        If ClearOldValue Then
            Me.tbBuyTargetValue.Text = _addcostInCurrcency
        Else
            Me.tbBuyTargetValue.Text = _oldValue + _addcostInCurrcency
        End If

        Me.cbxSetBuy.Checked = True
        MarkAsNeedSaved()
    End Sub


    ''' <summary>
    ''' добавляет сумму к входящей в зависимости от выбранной валюты
    ''' </summary>
    ''' <param name="rurCost"></param>
    ''' <remarks></remarks>
    Private Sub AddInvoiceCost(rurCost As Decimal, Optional ClearOldValue As Boolean = False)
        'добавить во входящие, учитывая валюту
        'определить валюту, по умолчанию поставить рубль
        If cbInvoceCurrency.SelectedItem Is Nothing Then cbInvoceCurrency.SelectedIndex = 1
        Dim _curr = CType(cbInvoceCurrency.SelectedItem, MoySkladAPI.currency)
        Dim _addcostInCurrcency = clsApplicationTypes.CurrencyConvert(rurCost, "RUR", _curr.name)
        Dim _oldValue = clsApplicationTypes.ReplaceDecimalSplitter(Me.tbInvoice)
        If ClearOldValue Then
            Me.tbInvoice.Text = _addcostInCurrcency
        Else
            Me.tbInvoice.Text = _oldValue + _addcostInCurrcency
        End If
        Me.cbxInvoice.Checked = True
        MarkAsNeedSaved()
    End Sub




    ''' <summary>
    ''' проверка эу на ввод
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub prices_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles tbBuyTargetValue.Validating, tbRetailTargetValue.Validating, tbQty.Validating, tbBuyPriceGood.Validating, tbShippingPrice.Validating, tbLossQty.Validating, tbBuyCost.Validating, tbWeight.Validating, tbWeightTariff.Validating, tbPrepTimeAdd.Validating, tbPrepTime.Validating, tbPrepCost.Validating, tbFullPrepCost.Validating, tbInvoice.Validating, tbPRICE1.Validating, tbPRICE2.Validating, tbPRICE3.Validating, tbPRICE4.Validating, tbPRICE5.Validating, tbPRICE6.Validating, tbPRICE7.Validating

        If sender.Text = "" Then sender.Text = "0" : Return
        If sender.Text = " " Then sender.Text = "0" : Return
        sender.text = clsApplicationTypes.ReplaceDecimalSplitter(sender.text)
        sender.backcolor = Color.FromKnownColor(KnownColor.Window)

        Select Case sender.name
            Case "tbQty"
                If tbQty.Text = "" Or tbQty.Text = "" Or tbQty.Text = "0" Then Return
                If Not Me.cbxWithoutSlot.Checked Then
                    'задаст кол-во в выбранной ячейке
                    Dim _currSlot As clsGoodLocation.clsSlot = Me.SlotGoodBindingSource.Current
                    If _currSlot Is Nothing Then Return
                    If Not Decimal.TryParse(Me.tbQty.Text, _currSlot.Qty) Then
                        MsgBox("Не удалось распознать количество", vbCritical)
                        Return
                    End If
                End If
                'Me.LocateGood(Me.oCurrentGood)
            Case "tbWeight"
                'замена гр на кг
                Dim _control As Control = CType(sender, Windows.Forms.Control)
                Dim _result As Decimal
                If Decimal.TryParse(_control.Text, _result) Then
                    'проверить, есть ли точка
                    For Each s In _control.Text
                        If Char.IsPunctuation(s) Then
                            'есть точка, выход
                            Return
                        End If
                    Next
                    'точки нет, и значение больше 10
                    If _result > 10 Then
                        _result = _result / 1000
                        _control.Text = _result.ToString
                    End If
                End If
        End Select
    End Sub
    Private Sub cbRetailTargetCurrency_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbRetailTargetCurrency.SelectedIndexChanged



        If Me.cbRetailTargetCurrency.SelectedItem Is Nothing Then Return

        If oCurrentRetailCurrency Is Nothing Then
            oCurrentRetailCurrency = Me.cbRetailTargetCurrency.SelectedItem
        End If

        'пересчет суммы в курс
        If Me.tbRetailTargetValue.Text = "" Then Me.tbRetailTargetValue.Text = "0"
        Dim _retail = clsApplicationTypes.ReplaceDecimalSplitter(Me.tbRetailTargetValue)
        'приведем к выбранному курсу
        Dim _retailNewRate = CType(Me.cbRetailTargetCurrency.SelectedItem, MoySkladAPI.currency).rate
        Dim _retailOldRate = CType(oCurrentRetailCurrency, MoySkladAPI.currency).rate

        Me.tbRetailTargetValue.Text = Math.Round(_retail * _retailOldRate / _retailNewRate, 2)

        If _retail > 0 Then
            Me.MarkAsNeedSaved()

        End If
    End Sub
    Private Sub cbInvoceCurrency_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbInvoceCurrency.SelectedIndexChanged

        If Me.cbInvoceCurrency.SelectedItem Is Nothing Then Return
        If oCurrentInvoceCurrency Is Nothing Then
            oCurrentInvoceCurrency = Me.cbInvoceCurrency.SelectedItem
        End If
        'пересчет суммы в курс
        If Me.tbInvoice.Text = "" Then Me.tbInvoice.Text = "0"
        Dim _retail = clsApplicationTypes.ReplaceDecimalSplitter(Me.tbInvoice)

        'приведем к выбранному курсу
        Dim _retailNewRate = CType(Me.cbInvoceCurrency.SelectedItem, MoySkladAPI.currency).rate
        Dim _retailOldRate = CType(oCurrentInvoceCurrency, MoySkladAPI.currency).rate

        Me.tbInvoice.Text = Math.Round(_retail * _retailOldRate / _retailNewRate, 2)
        If _retail > 0 Then
            Me.MarkAsNeedSaved()
        End If

    End Sub



#End Region

#Region "фиксируемые значения"

    Private Sub cbxFixSeries_CheckedChanged(sender As Object, e As EventArgs) Handles cbxFixSeries.CheckedChanged
        Select Case Me.cbxFixSeries.Checked
            Case True
                If oCurrentGood Is Nothing Then
                    Me.cbxFixSeries.Checked = False
                    oFixedSeries = ""
                    clsApplicationTypes.BeepNOT()
                    Return
                End If
                oFixedSeries = oCurrentGood.SampleNumber.Series
                clsApplicationTypes.BeepYES()
            Case Else
                oFixedSeries = ""
        End Select
    End Sub

    Private Sub cbxFixStore_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles cbxFixStore.CheckedChanged
        Select Case Me.cbxFixStore.Checked
            Case True
                If Me.cbTargetStores.SelectedItem Is Nothing Then
                    Me.cbxFixStore.Checked = False
                    clsApplicationTypes.BeepNOT()
                    Return
                End If
                oFixedStoreIndex = Me.cbTargetStores.SelectedIndex
                clsApplicationTypes.BeepYES()
            Case Else
                oFixedStoreIndex = 0
        End Select
    End Sub

    Private Sub cbxFixCurrency_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles cbxFixCurrency.CheckedChanged
        Select Case Me.cbxFixCurrency.Checked
            Case True
                If Me.cbRetailTargetCurrency.SelectedItem Is Nothing Then
                    Me.cbxFixCurrency.Checked = False
                    clsApplicationTypes.BeepNOT()
                    Return
                End If
                Me.oFixedCurrencyIndex = Me.cbRetailTargetCurrency.SelectedIndex
                clsApplicationTypes.BeepYES()
            Case Else
                Me.oFixedCurrencyIndex = 0
        End Select
    End Sub

#End Region


#Region "Описания"
    Private Sub btLoadTree_Click(sender As System.Object, e As System.EventArgs) Handles btLoadTree.Click
        'показат сплеш
        If oSplashscreen1.Visible = False Then
            oSplashscreen1.Show()
            Application.DoEvents()
        End If


        'В cbMaterial заносится название файла.
        Dim _fm As Form
        ''выполняем вызов из сервиса
        Dim _param As Object = Nothing
        'если делегата нет, то сервис недоступен
        If Not Global.Service.clsApplicationTypes.DelegateStoreApplicationForm(clsApplicationTypes.emFormsList.fmDescriptionTreeBuilder) Is Nothing Then
            'сервис зарегестрирован - вызываем 
            _fm = Global.Service.clsApplicationTypes.DelegateStoreApplicationForm(clsApplicationTypes.emFormsList.fmDescriptionTreeBuilder).Invoke(_param)
            _fm.StartPosition = FormStartPosition.CenterScreen
            _fm.ShowDialog(Me.MdiParent)
        Else
            Return
        End If


        'форма закрыта
        'занести файл в список
        Dim _result As String()


        'выполняем вызов из сервиса
        _param = Nothing
        'если делегата нет, то сервис недоступен
        If Not Global.Service.clsApplicationTypes.DelegateStoreGetTreesListFromFile Is Nothing Then
            'сервис зарегестрирован - вызываем 
            _result = Global.Service.clsApplicationTypes.DelegateStoreGetTreesListFromFile.Invoke(_param)
            If _result Is Nothing Then Return
        Else
            Return
        End If

        Dim _currKeyName = Trilbone.clsTreeService.CurrentGroupName
        Dim _currFilePath = Trilbone.clsTreeService.CurrentFilePath


        Dim _res = (From c In Me.oTreeFilesList Where c.Key = _currKeyName Select c.Key).FirstOrDefault


        If _res Is Nothing Then
            'нет файла в списке

            'записать в текучку
            Me.oTreeFilesList.Add(New KeyValuePair(Of String, String)(_currKeyName, _currFilePath))
            Me.oTreeBindingSource.ResetBindings(False)

            'записать список имен деревьев в этом файле
            Dim _item = (From c As String In _result Where c.ToLower.StartsWith("syst", StringComparison.OrdinalIgnoreCase) Select c).FirstOrDefault
            With Me.cbListOfTree
                .Visible = True
                .Items.Clear()
                .Items.AddRange(_result)
            End With
            If Not _item Is Nothing Then
                '!!!! jump но не пройдет
                Me.cbMaterial.SelectedItem = Nothing
                Me.cbListOfTree.SelectedItem = _item
            End If
            '!!!!! jump теперь пройдет
            Me.cbMaterial.SelectedIndex = Me.oTreeFilesList.Count - 1
        Else
            Me.cbListOfTree.SelectedIndex = 0
        End If




        Me.oSplashscreen1.Hide()

    End Sub

    Private Sub cbMaterial_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbMaterial.SelectedIndexChanged
        If Me.cbMaterial.SelectedItem Is Nothing Then Exit Sub
        If Me.cbListOfTree.SelectedItem Is Nothing Then Exit Sub

        Dim _list As String() = {""}
        Dim _keyname As String = Me.cbMaterial.SelectedItem.key

        'проверка буфера
        If Not clsApplicationTypes.CurrentNamesList.ContainsKey(_keyname) Then
            'из базы
            Dim _name = Me.cbListOfTree.SelectedItem.ToString
            Dim _treeFileName As String = Me.cbMaterial.SelectedItem.value
            Me.LoadNames(_name, _keyname, _treeFileName)
        Else
            'загрузить из буфера
            'тут список деревьев уже недоступен
            Dim _curr = Me.cbListOfTree.SelectedItem
            With Me.cbListOfTree
                .Items.Clear()
                .Items.Add(_curr)
                '!!! jump
                .SelectedItem = _curr
            End With
        End If

        'загрузить из буфера
        _list = clsApplicationTypes.CurrentNamesList.Item(_keyname)

        'загрузка списка имен
        Me.cbDBNames.Items.Clear()
        With Me.cbDBNames
            .Items.AddRange(_list)
        End With

    End Sub

    Private Sub cbListOfTree_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbListOfTree.SelectedIndexChanged
        If cbListOfTree.SelectedItem Is Nothing Then Exit Sub
        If cbMaterial.SelectedItem Is Nothing Then Exit Sub

        'загрузим список из выбранного дерева
        Dim _name = Me.cbListOfTree.SelectedItem.ToString
        Dim _treeFileName As String = Me.cbMaterial.SelectedItem.value
        Dim _KeyName = Me.cbMaterial.SelectedItem.key

        If clsApplicationTypes.CurrentNamesList.ContainsKey(_KeyName) Then
            'заменить названия
            clsApplicationTypes.CurrentNamesList.Remove(_KeyName)
            Me.LoadNames(_name, _KeyName, _treeFileName)
        Else
            Me.LoadNames(_name, _KeyName, _treeFileName)
        End If

    End Sub

    Private Sub rbRussian_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbRussian.CheckedChanged
        Dim _old = oCurrentCulture

        If rbRussian.Checked Then
            oCurrentCulture = Service.clsApplicationTypes.RussianCulture
        Else
            oCurrentCulture = Service.clsApplicationTypes.EnglishCulture
        End If
        If Not _old.Name = oCurrentCulture.Name Then
            Dim _ind = Me.cbDBNames.SelectedIndex
            cbListOfTree_SelectedIndexChanged(sender, e)
            Me.cbDBNames.SelectedIndex = _ind
        End If
    End Sub

    Private Sub rbEnglish_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbEnglish.CheckedChanged
        Dim _old = oCurrentCulture
        If rbEnglish.Checked Then
            oCurrentCulture = Service.clsApplicationTypes.EnglishCulture
        Else
            oCurrentCulture = Service.clsApplicationTypes.RussianCulture
        End If
        If Not _old.Name = oCurrentCulture.Name Then
            Dim _ind = Me.cbDBNames.SelectedIndex
            cbListOfTree_SelectedIndexChanged(sender, e)
            Me.cbDBNames.SelectedIndex = _ind
        End If

    End Sub

    Private Sub btCopyNameFromTrees_Click(sender As System.Object, e As System.EventArgs) Handles btCopyNameFromTrees.Click
        If Me.tbName.Text = Me.cbDBNames.Text Then
            Return
        End If
        If Me.oCurrentGood Is Nothing Then Return
        Me.oCurrentGood.Name = Me.cbDBNames.Text
        Me.bsCurrentGood.ResetCurrentItem()
        Me.MarkAsNeedSaved()
    End Sub


#End Region

#Region "вкладка учета себестоимости"
    Private Sub cbxInCommission_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles cbxInCommission.CheckedChanged
        ''Me.gbBuy.Enabled = cbxInCommission.Checked
    End Sub

    Private Sub cbInExpedition_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles cbInExpedition.CheckedChanged
        Me.gbExpedition.Enabled = cbInExpedition.Checked
    End Sub


    Private Sub cbxNeedRePrep_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles cbxNeedRePrep.CheckedChanged
        Me.MarkAsNeedSaved()

        If cbxNeedRePrep.Checked = True Then
            Me.cbRePrepDetails.Enabled = True
        Else
            Me.cbRePrepDetails.SelectedIndex = 0
            Me.cbRePrepDetails.Enabled = False

        End If
    End Sub
#End Region

#Region "вкладка ячеек"
    Private Sub btFromSlot_Click(sender As System.Object, e As System.EventArgs) Handles btFromSlot.Click
        'запрос принципиальный
        'показат сплеш
        If oSplashscreen1.Visible = False Then
            oSplashscreen1.Show()
            Application.DoEvents()
        End If

        Dim _ServerMessage As String = ""
        Dim _data As IEnumerable(Of Object) = Nothing

        Dim _req = oManager.RequestAnyCollection(clsMoyScladManager.emTOMoySkladTypes.slotStateReportTO, _data, CType(Me.bs_Curr_stor_location.Current, clsGoodLocation).WarehouseUUID, , , , _ServerMessage, "")


        Select Case _req
            Case Net.HttpStatusCode.OK
                Dim _slotCollection = (From c As SerialObj.slotStateReportTO In _data Where (c.slotRef.name = CType(bs_Curr_slot_location.Current, clsGoodLocation.clsSlot).ESlot.name) And c.quantity > 0 Select c).ToList
                'отобранные по имени ячейки с товарами
                Me.lbxnumbers.DataSource = _slotCollection.Select(Function(x) x.GetGoodQty).ToList
        End Select
        Me.oSplashscreen1.Hide()
        Me.lbSlotNumbers.Text = String.Format("ячейка {1} ({0} поз.)", Me.lbxnumbers.Items.Count, lbCurrentSlot.Text)
    End Sub

#End Region


#Region "Drag этикетки"

    Private odragBoxFromMouseDown As Rectangle

    Private Sub pbLabel_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles pbLabel.MouseDown

        ' Remember the point where the mouse down occurred. The DragSize indicates
        ' the size that the mouse can move before a drag event should be started.                
        Dim dragSize As Size = SystemInformation.DragSize

        ' Create a rectangle using the DragSize, with the mouse position being
        ' at the center of the rectangle.
        odragBoxFromMouseDown = New Rectangle(New Point(e.X - (dragSize.Width / 2),
                                                        e.Y - (dragSize.Height / 2)), dragSize)

    End Sub

    Private Sub pbLabel_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles pbLabel.MouseMove
        If ((e.Button And MouseButtons.Left) = MouseButtons.Left) Then

            ' If the mouse moves outside the rectangle, start the drag.
            If (Rectangle.op_Inequality(odragBoxFromMouseDown, Rectangle.Empty) And
                Not odragBoxFromMouseDown.Contains(e.X, e.Y)) Then

                'variant 1
                'Dim _obg As New DataObject
                '_obg.SetData(DataFormats.Dib, True, pbLabel.Image)
                'pbLabel.DoDragDrop(_obg, DragDropEffects.Copy)

                'variant 2 --OK!!
                'ужать фото
                'Dim _img = pbLabel.Image
                'Dim _x = _img.Width
                'Dim _y = _img.Height
                'Dim _x1 As Integer = 0
                'Dim _y1 As Integer
                '_y1 = 300
                'Dim _prop = (_y / _y1)
                '_x1 = Math.Round(_x / _prop)
                'Dim _rimg = New Bitmap(_img, New Drawing.Size(_x1, _y1))
                '_rimg.SetResolution(400, 400)



                Dim ms As New IO.MemoryStream
                Dim ms2 As New IO.MemoryStream
                clsApplicationTypes.ResizeLabelForClipboard(pbLabel.Image).Save(ms, ImageFormat.Bmp)
                Dim bytes() As Byte = ms.GetBuffer
                ms2.Write(bytes, 14, CInt(ms.Length - 14))
                ms.Position = 0
                Dim obj As New DataObject
                obj.SetData("DeviceIndependentBitmap", ms2)
                pbLabel.DoDragDrop(obj, DragDropEffects.Copy)
                ms.Close()
                ms2.Close()

                'variant 3
                '                // declarations
                '[DllImport("user32.dll")]
                'static extern IntPtr SetClipboardData(uint uFormat, IntPtr hMem);

                '[DllImport("user32.dll")]
                'static extern bool OpenClipboard(IntPtr hWndNewOwner);

                '[DllImport("user32.dll")]
                'static extern bool EmptyClipboard();

                '[DllImport("user32.dll")]
                'static extern bool CloseClipboard();

                'public static uint CF_ENHMETAFILE = 14;

                '...

                'Bitmap img = (Bitmap)Bitmap.FromFile(@"c:\TestImage.jpg",true);
                '// create graphics object for metafile
                'Graphics g = CreateGraphics();
                'IntPtr hdc = g.GetHdc();
                'Metafile meta = new Metafile(@"SampleMetafilegdiplus.emf", hdc );
                'g.ReleaseHdc(hdc);
                'g.Dispose();
                '// create a metafile image from the jpeg image
                'g = Graphics.FromImage(meta);
                'g.DrawImage(img, new Point(0,0));
                'g.Dispose();
                '// get a handle to the metafile
                'IntPtr hEmf = meta.GetHenhmetafile();
                'meta.Dispose();
                '// open the clipboard
                'OpenClipboard(this.Handle); // your Form's Window handle
                'EmptyClipboard();
                '// place the handle to the metafile on to the clipboard
                'SetClipboardData(CF_ENHMETAFILE, hEmf);
                'CloseClipboard();
            End If
        End If
    End Sub


    Private Sub pbLabel_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles pbLabel.MouseUp
        ' Reset the drag rectangle when the mouse button is raised.
        odragBoxFromMouseDown = Rectangle.Empty
    End Sub

#End Region

#Region "разное"

    Private Sub rtbDescription_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles rtbDescription.KeyPress, tbName.KeyPress
        If Asc(e.KeyChar) = 13 And Not Me.oCurrentGood Is Nothing Then
            If Me.cbxFixStore.Checked Then
                Me.btCreateGood.Focus()
            Else
                Me.cbTargetStores.Focus()
            End If
        ElseIf Asc(e.KeyChar) = 13 And Me.oCurrentGood Is Nothing Then
            Me.btSearchInSklad_Click(sender, e)
        Else
            Me.MarkAsNeedSaved()
        End If
    End Sub

    Private Sub tbAuGetSampleList_Click(sender As System.Object, e As System.EventArgs) Handles tbAuGetSampleList.Click
        Dim _data As Generic.IEnumerable(Of Object) = Nothing
        Dim _message As String = ""
        Dim _wr As String = CType(Me.cbAuStoreList.SelectedItem, warehouse).uuid

        'показат сплеш
        If oSplashscreen1.Visible = False Then
            oSplashscreen1.Show()
            Application.DoEvents()
        End If


        Select Case Me.oManager.RequestAnyCollection(clsMoyScladManager.emTOMoySkladTypes.stockTO, _data, _wr, , , , _message, "")
            Case Net.HttpStatusCode.OK
                'список укороченных обьектов товаров
                Dim _result = (From c As SerialObj.stockTO In _data Select c.goodRef).ToList
                Me.RefTODataGridView.DataSource = _result

            Case Else
                MsgBox(_message, vbCritical)
        End Select
        Me.oSplashscreen1.Hide()
    End Sub


    ''' <summary>
    ''' копирует имя + кол-во + ед.изм в поле ИМЯ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtCopyName_Click(sender As System.Object, e As System.EventArgs) Handles BtCopyName.Click, btSetName.Click
        Dim _lossgood As clsMSGood = Nothing
        If Not Me.dgv_Goods.CurrentCell Is Nothing Then
            _lossgood = Me.dgv_Goods.Rows(Me.dgv_Goods.CurrentCell.RowIndex).DataBoundItem
        ElseIf Not lbArticuls.SelectedItem Is Nothing Then
            _lossgood = Me.lbArticuls.SelectedItem
        Else
            clsApplicationTypes.BeepNOT() : Return
        End If

        If oCurrentGood Is Nothing Then clsApplicationTypes.BeepNOT() : Return
        If _lossgood Is Nothing Then clsApplicationTypes.BeepNOT() : Return

        Dim _name As String = _lossgood.Name
        If _name.ToLower.Contains("(общий)".ToLower) Then
            _name = _name.Replace("(общий)", "")
        End If

        If Not _name.Equals(tbName.Text) Then
            Me.MarkAsNeedSaved()
            Me.oCurrentGood.Name = _name
            Me.bsCurrentGood.ResetCurrentItem()
            Me.tbName.Focus()
        End If

    End Sub

    Private Sub btSetArticul_Click(sender As System.Object, e As System.EventArgs) Handles btSetArticul.Click
        If lbArticuls.SelectedItem Is Nothing Then Return
        Dim _good As clsMSGood = Me.lbArticuls.SelectedItem
        Me.oCurrentGood.Articul = _good.Articul
        If Me.oCurrentGood.Good Is Nothing Then
            MsgBox("Нет текущего товара. Нажми кнопку запрос!", vbCritical)
            Return
        End If
        Me.oCurrentGood.Good.productCode = _good.Articul
        Me.bsCurrentGood.ResetCurrentItem()
    End Sub

    Private Sub btCheckCodes_Click(sender As System.Object, e As System.EventArgs) Handles btCheckCodes.Click
        Me.oSplashscreen1.Show()
        Application.DoEvents()
        Dim _ms = Me.oManager.ServiceSheckBarCodes()
        Me.oSplashscreen1.Hide()
        MsgBox(_ms)
    End Sub

    Private Sub btLotEnter_Click(sender As System.Object, e As System.EventArgs)
        'сформировать строки с субномерами от 1 до 5
        'запросить в мс все артикулы
    End Sub

#End Region


    Private Sub btToSlot_Click(sender As Object, e As EventArgs) Handles btToSlot.Click
        'создать перемещение
        'проверка одинаковости склада - источника
        If oSlotMoveList Is Nothing Then Return
        If oSlotMoveList.Count = 0 Then Return
        Dim _sourceWareUUID = oSlotMoveList(0).WareUUID
        If Not oSlotMoveList.All(Function(x)
                                     If x.WareUUID = _sourceWareUUID Then Return True
                                     Return False
                                 End Function) Then
            'не все склады источники одинаковы
            MsgBox("Не все товары к перемещению имеют один и тот же склад источник. Перемещены будут не все товары. Проверте результат перемещения и сообщите админу об ошибке.", vbInformation)
            oSlotMoveList = oSlotMoveList.Where(Function(x) x.WareUUID = _sourceWareUUID).ToList
        End If

        'определить склад-получатель и ячейку назначения
        If Me.cbStoreForPlacing.SelectedItem Is Nothing Then Return
        If Me.lbSlotForPlacing.SelectedItem Is Nothing Then Return
        Dim _targetWareUUID As String = CType(Me.cbStoreForPlacing.SelectedItem, clsGoodLocation).WarehouseUUID
        ' Dim _targetSlotUUID As String = CType(lbSlotForPlacing.SelectedItem, clsGoodLocation.clsSlot).ESlot.uuid
        For Each s In oSlotMoveList
            s.NewSlotUUID = CType(lbSlotForPlacing.SelectedItem, clsGoodLocation.clsSlot).ESlot.uuid
            s.SlotName = CType(lbSlotForPlacing.SelectedItem, clsGoodLocation.clsSlot).ESlot.name
        Next

        'переместить
        Dim _result = oManager.CreateMove(sourceStoreUuid:=_sourceWareUUID, targetStoreUuid:=_targetWareUUID, goodList:=oSlotMoveList.ToArray)
        If _result.HasError Then
            MsgBox(_result.ErrorMessage, vbCritical)
        Else
            MsgBox(String.Format("Перемещение {0} создано. Проверте перемещение в МС на наличие подсвеченным красным позиций количества, это будут перемещенные/отгруженные позиции без указания ячеек. По возможности их надо исправить.", _result), vbInformation)
            oSlotMoveList = New List(Of iMoySkladDataProvider.strGoodMapQty)
            Me.bs_currentMove.DataSource = oSlotMoveList
            Me.lbxSelectedNumbers.Invalidate()

            Me.lbSelectedSlotNumbers.Text = String.Format("в ячейку {0}({1})", CType(Me.lbSlotForPlacing.SelectedItem, clsGoodLocation.clsSlot).ESlot.name, Me.bs_currentMove.Count)
        End If
    End Sub


    Private Sub btToFreeLocation_Click(sender As Object, e As EventArgs) Handles btToFreeLocation.Click
        If Me.cbStoreForPlacing.SelectedItem Is Nothing Then Return
        If Me.lbxnumbers.DataSource Is Nothing Then Return

        Dim _goodList As List(Of iMoySkladDataProvider.strGoodMapQty) = Me.lbxnumbers.DataSource
        Dim _ware As clsGoodLocation = Me.cbStoreForPlacing.SelectedItem



        Dim _result = oManager.CreateMove(sourceStoreUuid:=_ware.WarehouseUUID, targetStoreUuid:=_ware.WarehouseUUID, goodList:=_goodList.ToArray)
        If _result.HasError Then
            MsgBox(_result.ErrorMessage, vbCritical)
        Else
            MsgBox(String.Format("Перемещение {0} создано. Проверте перемещение в МС на наличие подсвеченным красным позиций количества, это будут перемещенные/отгруженные позиции без указания ячеек. По возможности их надо исправить.", _result), vbInformation)
        End If
    End Sub

    Private Sub lbSlotForPlacing_KeyPress(sender As Object, e As KeyPressEventArgs) Handles lbSlotForPlacing.KeyPress
        Static _keys As String
        If Char.IsDigit(e.KeyChar) Then
            _keys += e.KeyChar
        End If

        If Asc(e.KeyChar) = 13 Then
            'введен код
            Dim _res = From c As clsGoodLocation.clsSlot In lbSlotForPlacing.Items Where c.ESlot.name.Contains(_keys) Select c

            If _res.Count > 0 Then
                lbSlotForPlacing.SelectedItem = _res.FirstOrDefault
                _keys = ""
            End If
        End If
    End Sub

    Private Sub lbSlotForPlacing_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbSlotForPlacing.SelectedIndexChanged
        '  Me.lbSlotNumbers.Text = "В ячейке"
        If Not Me.lbSlotForPlacing.SelectedItem Is Nothing Then
            Me.lbSelectedSlotNumbers.Text = String.Format("в ячейку {0}({1})", CType(Me.lbSlotForPlacing.SelectedItem, clsGoodLocation.clsSlot).ESlot.name, Me.bs_currentMove.Count)
        Else
            Me.lbSelectedSlotNumbers.Text = String.Format("выбери целевую ячейку")
        End If
    End Sub

    Private Sub btAddToSelected_Click(sender As Object, e As EventArgs) Handles btAddToSelected.Click
        If Me.lbxnumbers.SelectedItem Is Nothing Then Return

        Dim _item As iMoySkladDataProvider.strGoodMapQty = Me.lbxnumbers.SelectedItem
        Dim _exist = From c As iMoySkladDataProvider.strGoodMapQty In oSlotMoveList Where c.ActualSampleNumber.EAN13 = _item.ActualSampleNumber.EAN13
        If _exist.Count > 0 Then
            MsgBox("Товар уже есть в списке", vbCritical)
            Return
        End If

        'проверка на одинаковость склада
        If oSlotMoveList.Count > 0 Then
            If Not oSlotMoveList(0).WareUUID = _item.WareUUID Then
                MsgBox("вместе перемещать можно образцы, находящиеся на одном складе. Завершите текущее перемещение и начните новое для требуемого перемещения", vbCritical)
                Return
            End If
        End If
        oSlotMoveList.Add(Me.lbxnumbers.SelectedItem)
        Me.bs_currentMove.ResetBindings(False)
        Me.lbSelectedSlotNumbers.Text = String.Format("в ячейку {0}({1})", CType(Me.lbSlotForPlacing.SelectedItem, clsGoodLocation.clsSlot).ESlot.name, Me.bs_currentMove.Count)
    End Sub

    Private Sub btDeleteNumber_Click(sender As Object, e As EventArgs) Handles btDeleteNumber.Click
        If Me.lbxSelectedNumbers.SelectedItem Is Nothing Then Return

        oSlotMoveList.Remove(Me.lbxSelectedNumbers.SelectedItem)
        Me.bs_currentMove.ResetBindings(False)
        Me.lbSelectedSlotNumbers.Text = String.Format("в ячейку {0}({1})", CType(Me.lbSlotForPlacing.SelectedItem, clsGoodLocation.clsSlot).ESlot.name, Me.bs_currentMove.Count)
    End Sub
    Private Sub btAddToPlacing_Click(sender As System.Object, e As System.EventArgs) Handles btAddToPlacing.Click
        Dim _number = ShotCodeConverter_Net.clsCode.CreateInstance(Me.tbNumberForPlacing.Text)
        If Not _number.CodeType = ShotCodeConverter_Net.clsCode.emCodeType.EAN13 Then Return
        Dim _exist = From c As iMoySkladDataProvider.strGoodMapQty In oSlotMoveList Where c.ActualSampleNumber.EAN13 = _number.EAN13
        If _exist.Count > 0 Then
            MsgBox("Товар уже есть в списке", vbCritical)
            Return
        End If
        'показат сплеш
        If oSplashscreen1.Visible = False Then
            oSplashscreen1.Show()
            Application.DoEvents()
        End If
        'проверить наличие введенного номера на складе
        Dim _found As New List(Of good)
        Dim _result = oManager.FindGoods(_number.ShotCode, _number.ShotCode, "", _found)
        Select Case _result
            Case Is < 0
            Case 0
                'товара нет в картотеке
                oSplashscreen1.Hide()
                MsgBox("Запрошенный номер отсутствует справочнике товаров. Проверте справочник товаров в МС.")
                Return
            Case 1
                'ok товар найден
                'получить склад для списка
                Dim _wareUUID As String = ""
                Dim _loc = oManager.FindLocationOfGood(_found(0), True)
                If oSlotMoveList.Count > 0 Then
                    _wareUUID = oSlotMoveList(0).WareUUID
                    'фильтр по нужному складу
                    _loc = _loc.Where(Function(x) x.WarehouseUUID = _wareUUID And x.TotalQty > 0).ToList
                    If _loc.Count = 0 Then
                        oSplashscreen1.Hide()
                        MsgBox(String.Format("Нет товара {1} на складе {0} для перемещения. Склад-источник задается при добавлении первого образца в список. Для решения проблемы очистите список и добавте этот образец первым.", oSlotMoveList(0).WareName, _found(0).name))
                        Return
                    End If
                Else
                    Dim _w = _loc.Where(Function(x) x.TotalQty > 0).FirstOrDefault
                    If _w Is Nothing Then
                        oSplashscreen1.Hide()
                        MsgBox(String.Format("Нет доступного количества товара {0} на складах для перемещения. Скорее всего общее кол-во товаров на складах - ноль", _found(0).name))
                        Return
                    End If
                    _wareUUID = _w.WarehouseUUID
                End If
                'тут товар найден и готов к перемещению
                'добавить в список
                oSlotMoveList.AddRange(_loc.SelectMany(Function(x) x.GetGoodQty))
                Me.bs_currentMove.ResetBindings(False)
                Me.lbSelectedSlotNumbers.Text = String.Format("в ячейку {0}({1})", CType(Me.lbSlotForPlacing.SelectedItem, clsGoodLocation.clsSlot).ESlot.name, Me.bs_currentMove.Count)
                oSplashscreen1.Hide()
                Service.clsApplicationTypes.BeepYES()
                Me.tbNumberForPlacing.Text = ""
                Me.tbNumberForPlacing.Focus()
            Case Is > 1
                'товар неоднозначен
                oSplashscreen1.Hide()
                MsgBox("Запрошенный номер имеет повторы в справочнике товаров. Проверте справочник товаров в МС.")
                Return
        End Select

    End Sub

    Private Sub btAddCurrent_Click(sender As Object, e As EventArgs) Handles btAddCurrent.Click
        'добавить текущий товар
        If oCurrentGood Is Nothing Then Return
        Me.tbNumberForPlacing.Text = oCurrentGood.AnyCode
        Application.DoEvents()
        Me.btAddToPlacing_Click(sender, e)
    End Sub

    Private Sub lbxSelectedNumbers_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbxSelectedNumbers.SelectedIndexChanged
        If Me.lbxSelectedNumbers.SelectedItem Is Nothing Then Return
        Dim _item As iMoySkladDataProvider.strGoodMapQty = Me.lbxSelectedNumbers.SelectedItem
        Me.lbSlotInfo.Text = String.Format("на {0} {1}, {2}{3}", _item.WareName, IIf(String.IsNullOrWhiteSpace(_item.SlotName), "без размещения", "в ячейке " & _item.SlotName), _item.Qty, _item.UomName)
        Me.PictureBox1.Image = clsApplicationTypes.SamplePhotoObject.GetMainImage(clsFilesSources.Arhive, _item.ActualSampleNumber, True)

    End Sub

#Region "количество на размещение"

#End Region








    ''' <summary>
    ''' добавит вес к названию
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btAddWeightToName_Click(sender As Object, e As EventArgs) Handles btAddWeightToName.Click

        If String.IsNullOrEmpty(tbWeight.Text) Then Return

        Dim _info = Me.GetInfoString(Me.oCurrentGood.Name, Me.oCurrentGood.Name)

        Me.oCurrentGood.Name = Me.BuildName(Me.oCurrentGood.Name, Me.GetConditionString(_info), Me.GetBoxString(_info), tbWeight.Text)

        ''проверить есть ли уже вес
        'Dim _wr = Me.tbName.Text.Split("[".ToArray, StringSplitOptions.RemoveEmptyEntries)
        'Select Case _wr.Count
        '    Case Is <= 1
        '        'нет веса
        '        Me.oCurrentGood.Name = Me.oCurrentGood.Name.TrimEnd & " [" & tbWeight.Text & "kg]"
        '    Case Is > 1
        '        'есть вес, заменить
        '        Me.oCurrentGood.Name = _wr(0).TrimEnd & " [" & tbWeight.Text & "kg]"
        'End Select

        Me.MarkAsNeedSaved()

        Me.bsCurrentGood.ResetCurrentItem()
    End Sub



    Private Sub btCondition_Click_1(sender As Object, e As EventArgs) Handles btCondition.Click
        If String.IsNullOrEmpty(Me.lbBuildDescription.Text) Then Return
        '{<S3*4> RARE, препарация(5-2), сохран(5-2), реконструкция=%, матрикс=родной,склейка,пересад}
        Dim _result = GetInfoString(Me.oCurrentGood.Name, Me.oCurrentGood.Name)
        Me.oCurrentGood.Name = Me.BuildName(Me.oCurrentGood.Name, Me.lbBuildDescription.Text, Me.GetBoxString(_result))
        Me.MarkAsNeedSaved()
        Me.bsCurrentGood.ResetCurrentItem()
    End Sub

    Private Sub btBuildCondition_Click(sender As Object, e As EventArgs) Handles btBuildCondition.Click
        Dim _fn = New fmCondition
        AddHandler _fn.QualityTextChanged, AddressOf QualityTextChanged_EventHandler
        _fn.Show()
    End Sub

    Private Sub QualityTextChanged_EventHandler(sender As Object, e As Service.UserControlQality.QualityTextChangedEventArgs)
        'RARE, препарация(б/п 5-3), сохран(5-2), реконструкция=%, матрикс=родной,склейка,пересад
        Me.lbBuildDescription.Text = e.text
    End Sub

    ''' <summary>
    ''' отмечает красным кнопку сохранения
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub MarkAsNeedSaved()
        If (oWillNewGoodFlag = False) And (Not Me.oCurrentGood Is Nothing) And (oRedKeyOff = False) Then
            Me.btSaveChanges.BackColor = Color.Red
            Me.btSaveChanges.Tag = True
            If Me.btAddGoodToWare.BackColor = Color.Red Then
                Me.btAddGoodToWare.BackColor = Color.OrangeRed
            End If
        End If
    End Sub


    ''' <summary>
    ''' строит строку названия
    ''' </summary>
    ''' <param name="ClearName"></param>
    ''' <param name="ConditionString"></param>
    ''' <param name="BoxString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function BuildName(ClearName As String, Optional ConditionString As String = "", Optional BoxString As String = "", Optional Weight As String = "") As String
        Dim _out As String = ClearName

        If String.IsNullOrEmpty(ConditionString) And String.IsNullOrEmpty(BoxString) Then
            If String.IsNullOrEmpty(Weight) Then Return _out
            _out += "[" & Weight & "kg]"
            Return _out
        End If

        If Not String.IsNullOrEmpty(Weight) Then
            _out += "[" & Weight & "kg]"
        End If

        _out += " {"
        If Not String.IsNullOrEmpty(BoxString) Then
            Dim _shotBox = BoxString.Split.FirstOrDefault
            If Not _shotBox Is Nothing Then
                _out += "<" & _shotBox & ">"
            End If
        End If
        If Not String.IsNullOrEmpty(ConditionString) Then
            _out += " " & ConditionString.Trim
        End If
        _out += "}"
        Return _out
    End Function


    ''' <summary>
    ''' вернет строку размера коробочки без символов
    ''' </summary>
    ''' <param name="InfoString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetBoxString(InfoString As String) As String
        If String.IsNullOrEmpty(InfoString) Then Return ""
        Dim _result = InfoString.Split("<S".ToArray, StringSplitOptions.RemoveEmptyEntries)
        Select Case _result.Count
            Case 0
                Return ""
            Case Else
                Dim _s = _result(0).Split(">".ToArray).FirstOrDefault
                If _s Is Nothing Then Return ""
                Return "S" & _s
        End Select
    End Function

    ''' <summary>
    ''' вернет чисто строку condition без других полей 
    ''' </summary>
    ''' <param name="InfoString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetConditionString(InfoString As String) As String
        If String.IsNullOrEmpty(InfoString) Then Return ""
        Dim _result = InfoString.Split(">".ToArray, StringSplitOptions.RemoveEmptyEntries)
        Select Case _result.Count
            Case 0
                Return ""
            Case 1
                Return InfoString
            Case Else
                Return _result(_result.Count - 1)
        End Select
    End Function


    ''' <summary>
    ''' вернет доп строку без символов {}
    ''' </summary>
    ''' <param name="Name"></param>
    ''' <param name="ClearName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetInfoString(Name As String, Optional ByRef ClearName As String = "") As String
        If String.IsNullOrEmpty(Name) Then
            ClearName = ""
            Return ""
        End If
        Dim _infotmp = Me.oCurrentGood.Name.Split("{".ToArray, StringSplitOptions.RemoveEmptyEntries)
        Select Case _infotmp.Count
            Case 1
                'нет доп инфо
                ClearName = Name
                Return ""
            Case 2
                'есть доп инфо
                ClearName = _infotmp(0).Trim
                Return _infotmp(1).Trim.TrimEnd("}")
            Case Else
                '{ повторяется более одного раза
                MsgBox("Между символами {} заключается дополнительное инфо об образце, которое не выводится на печать. Символ { повторяется в строке названия более одного раза, что недопустимо. Удалите лишний символ и повторите операцию.", vbCritical)
                ClearName = Name
                Return ""
        End Select
    End Function

#Region "Boxes"
    Private Sub btBoxTypeSelect_Click(sender As Object, e As EventArgs) Handles btBoxTypeSelect.Click
        If cbBoxTypes.SelectedItem Is Nothing Then Return
        If String.Equals(tbBoxType.Text.ToLower, cbBoxTypes.SelectedItem.ToString.ToLower) Then Return

        If cbBoxTypes.SelectedItem = "нет" Then
            tbBoxType.Text = ""
        Else
            tbBoxType.Text = cbBoxTypes.SelectedItem

        End If
        Dim _info = Me.GetInfoString(Me.oCurrentGood.Name, Me.oCurrentGood.Name)
        Me.oCurrentGood.Name = Me.BuildName(Me.oCurrentGood.Name, Me.GetConditionString(_info), Me.tbBoxType.Text)
        Me.MarkAsNeedSaved()
        Me.bsCurrentGood.ResetCurrentItem()
    End Sub



    Private Sub btBoxTypeFromName_Click(sender As Object, e As EventArgs) Handles btBoxTypeFromName.Click
        Dim _info = Me.GetInfoString(Me.oCurrentGood.Name, Me.oCurrentGood.Name)
        Me.oCurrentGood.Name = Me.BuildName(Me.oCurrentGood.Name, Me.GetConditionString(_info))
        Me.MarkAsNeedSaved()
        Me.bsCurrentGood.ResetCurrentItem()
    End Sub

    Private Sub cbBoxTypes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbBoxTypes.SelectedIndexChanged
        If cbBoxTypes.SelectedItem Is Nothing Then Return

        If String.IsNullOrEmpty(Me.tbBoxType.Text) Then
            btBoxTypeSelect_Click(sender, e)
        End If
    End Sub

    Private Sub tbBoxType_TextChanged(sender As Object, e As EventArgs) Handles tbBoxType.TextChanged

    End Sub
#End Region

    Private Sub tbNumberForPlacing_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbNumberForPlacing.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Me.btAddToPlacing_Click(sender, e)
        End If
    End Sub

    Private Sub lbRetail_MouseClick(sender As Object, e As MouseEventArgs) Handles lbRetail.MouseClick
        If Not clsRestMS_service.GetDigiKey Is Nothing Then
            clsRestMS_service.GetDigiKey.connect(Me.tbRetailTargetValue)
        End If
    End Sub

    Private Sub lbIncoming_MouseClick(sender As Object, e As MouseEventArgs) Handles lbIncoming.MouseClick
        If Not clsRestMS_service.GetDigiKey Is Nothing Then
            clsRestMS_service.GetDigiKey.connect(Me.tbBuyTargetValue)
        End If
    End Sub

    Private Sub Label46_MouseClick(sender As Object, e As MouseEventArgs) Handles Label46.MouseClick
        If Not clsRestMS_service.GetDigiKey Is Nothing Then
            clsRestMS_service.GetDigiKey.connect(Me.tbQty)
        End If
    End Sub

    Private Sub btNumberPlus_Click(sender As Object, e As EventArgs) Handles btNumberPlus.Click
        If Me.tbNumber.Text = "" Then Return
        If oSampleNumber Is Nothing Then Return
        Me.tbNumber.Text = oSampleNumber.IncreaceNumber
        Me.tbName.Text = ""

        Me.btSearchInSklad_Click(sender, e)
    End Sub

    Private Sub btNumberMinus_Click(sender As Object, e As EventArgs) Handles btNumberMinus.Click
        If Me.tbNumber.Text = "" Then Return
        If oSampleNumber Is Nothing Then Return
        Me.tbNumber.Text = oSampleNumber.DecreaceNumber
        Me.tbName.Text = ""

        Me.btSearchInSklad_Click(sender, e)
    End Sub

    ''' <summary>
    ''' округлить цену
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btRoundRetailPrice_Click(sender As Object, e As EventArgs) Handles btRoundRetailPrice.Click
        Dim _price = clsApplicationTypes.ReplaceDecimalSplitter(Me.tbRetailTargetValue)
        Select Case CType(Me.cbRetailTargetCurrency.SelectedItem, MoySkladAPI.currency).name
            Case "USD", "EUR"
                _price = Decimal.Ceiling(_price)
            Case "RUR"
                Dim _ind As Integer = 2
                If _price < 100 Then _ind = 1
                Dim _tmp = Decimal.Ceiling(_price)
                _tmp = _tmp / 10 ^ _ind
                _price = Decimal.Ceiling(_tmp) * 10 ^ _ind
        End Select
        Me.tbRetailTargetValue.Text = _price
    End Sub





    Private Sub Label31_MouseClick(sender As Object, e As MouseEventArgs) Handles Label31.MouseClick
        If Not clsRestMS_service.GetDigiKey Is Nothing Then
            clsRestMS_service.GetDigiKey.connect(Me.tbBuyPriceGood)
        End If
    End Sub




    Private Sub pbImage_DoubleClick(sender As Object, e As EventArgs) Handles pbImage.DoubleClick
        If oSampleNumber Is Nothing Then Return
        If oSampleNumber.CodeIsCorrect = False Then Return
        Dim _prm = Service.clsApplicationTypes.SamplePhotoObject.GetImageCollection(oSampleNumber, clsFilesSources.Arhive, False)
        If _prm Is Nothing Then
            MsgBox("невозможно показать форму с изображениями", vbCritical)
        End If
        Dim _fmImage As Form
        'show image form
        Dim _param As Object = {_prm, ""}
        'если делегата нет, то сервис недоступен
        If Not Global.Service.clsApplicationTypes.DelegateStoreApplicationForm(Service.clsApplicationTypes.emFormsList.fmImage) Is Nothing Then
            'сервис зарегестрирован - вызываем
            _fmImage = Global.Service.clsApplicationTypes.DelegateStoreApplicationForm(Service.clsApplicationTypes.emFormsList.fmImage).Invoke(_param)
            If Not _fmImage Is Nothing Then
                'show form
                _fmImage.Width = 640
                _fmImage.Height = 480
                _fmImage.StartPosition = FormStartPosition.CenterScreen
                'привязка обработчика
                'Service.clsApplicationTypes.DelegatStorefmImageDeleteDelegate = New Service.clsApplicationTypes.fmImageDeleteDelegat(AddressOf DelImage_eventHandler)
                'Service.clsApplicationTypes.DelegatStorefmImageCopyDelegate = New Service.clsApplicationTypes.fmImageCopyDelegat(AddressOf CopyImage_eventHandler)
                _fmImage.ShowDialog()
            End If
        End If
    End Sub

    Private Sub CopyImage_eventHandler(ByVal sender As Object, ByVal e As Service.clsApplicationTypes.fmImageCopyEventArg)
        If e.ImageNames.Length = 0 Then Exit Sub

        'скопировать изображения, список имен в аргументе
        'Dim _tmpSample As Decimal = Me.Dgv_SamplesINOrders.CurrentRow.Cells(0).Value
        'Dim _filesrc = Me.cbSourcesList.SelectedItem
        Dim _sampleNumber = Me.oSampleNumber

        'задать устройство принимающее
        Dim _Tosource As Service.clsFilesSources = clsFilesSources.Arhive

        'задать устройство источник
        Dim _Fromsource As Service.clsFilesSources = Service.clsFilesSources.CreateInstance(Service.clsFilesSources.emSources.FreeFolder, , False, e.ImagesPath)


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
            Case MsgBoxResult.No
                Exit Sub
        End Select



    End Sub
    Private Sub DelImage_eventHandler(ByVal sender As Object, ByVal e As Service.clsApplicationTypes.fmImageDelEventArg)
        If e.ImageNames.Count = 0 Then Exit Sub

        'удалить изображения, список имен в аргументе
        Dim _sampleNumber = Me.oSampleNumber
        Dim _coll(e.ImageNames.Count - 1) As String
        e.ImageNames.CopyTo(_coll, 0)

        Dim _count As Integer = Service.clsApplicationTypes.SamplePhotoObject.DeleteImagesFromSource(_sampleNumber, clsFilesSources.Arhive, _coll, False, False)



        MsgBox("Удалено " & _count & " фото с устр-ва " & clsFilesSources.Arhive.GetStringForUser, vbInformation)
    End Sub

    Private Sub cbxIncomingPrices_CheckedChanged(sender As Object, e As EventArgs) Handles cbxIncomingPrices.CheckedChanged
        Me.cbxIncomingPrices.BackColor = Windows.Forms.CheckBox.DefaultBackColor
    End Sub

    ''' <summary>
    ''' изменение тарифа на перевозку
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cbWeightTariff_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbWeightTariff.SelectedIndexChanged
        Select Case Me.cbWeightTariff.SelectedIndex
            Case Is <= 0
                Me.tbWeightTariff.Text = My.Settings.ShippingTariffPerKG
            Case 1
                Me.tbWeightTariff.Text = My.Settings.ShippingTariffPerPCS
            Case Else
                Me.tbWeightTariff.Text = My.Settings.ShippingTariffPerE
        End Select
    End Sub

    Private Sub tbRawNumber_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbRawNumber.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Dim _code = ShotCodeConverter_Net.clsCode.CreateInstance(tbLossSourceArticul.Text)
            If Not _code.CodeType = ShotCodeConverter_Net.clsCode.emCodeType.Incorrect Then
                tbRawNumber.Text = _code.EAN13
            End If

            If Not Me.cbMainPreparator.DroppedDown Then
                Me.cbMainPreparator.DroppedDown = True
            End If
            Me.cbMainPreparator.Focus()
            Me.cbMainPreparator.SelectedIndex = 0
        Else
            Me.MarkAsNeedSaved()
        End If
    End Sub

    ''' <summary>
    ''' установить главного препаратора
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cbPreparator_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbMainPreparator.SelectedIndexChanged
        If cbMainPreparator.SelectedIndex > 0 Then
            Me.cbPreparatorAdd.SelectedIndex = Me.cbMainPreparator.SelectedIndex
            Me.tbPrepTimeAdd.Focus()
        End If
    End Sub

    Private Sub tbCtlMain_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tbCtlMain.SelectedIndexChanged
        If tbCtlMain.SelectedTab Is Me.tpPreparation Then
            tbRawNumber.Focus()
        End If
        If tbCtlMain.SelectedTab Is tpPreparation Then
            If String.IsNullOrEmpty(Me.tbWeight.Text) Then
                Me.tbWeight.Focus()
            ElseIf String.IsNullOrEmpty(Me.tbBuyCost.Text) Then
                Me.tbBuyCost.Focus()
            ElseIf String.IsNullOrEmpty(Me.tbRawNumber.Text) Then
                Me.tbRawNumber.Focus()
            ElseIf String.IsNullOrEmpty(Me.tbFullPrepCost.Text) Then
                Me.cbPreparatorAdd.Focus()
            Else
                Me.btGetPrices.Focus()
            End If
        End If
        If tbCtlMain.SelectedTab Is tpPrices Then
            Me.UcPriceCalc1.Focus()
        End If
    End Sub

    ''' <summary>
    ''' расчет цен
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btGetPrices_Click(sender As Object, e As EventArgs) Handles btGetPrices.Click
        Dim _weight = oCurrentGood.Weight
        If _weight = 0 Then
            MsgBox("Не задан вес образца - рассчет цен невозможен", vbCritical)
            Return
        End If

        'входящая стоимость в РУБ
        Dim _buyprice As Decimal = 0
        Dim _curr = (From c As MoySkladAPI.currency In Me.cbBuyTargetCurrency.Items Where c.uuid = Me.oCurrentGood.Good.buyCurrencyUuid Select c).FirstOrDefault
        If Not _curr Is Nothing Then
            _buyprice = clsApplicationTypes.CurrencyConvert(clsApplicationTypes.ReplaceDecimalSplitter(Me.tbBuyTargetValue), _curr.name, "RUR")
        End If

        'стоимсотсь закупки (инвойс)
        Dim _hunt_cost = clsApplicationTypes.ReplaceDecimalSplitter(Me.tbBuyCost)

        'стоимость препарации с наценкой
        Dim _prep_cost = clsApplicationTypes.ReplaceDecimalSplitter(Me.tbFullPrepCost)
        If Me.cbxIncomingIncludePrep.Checked Then
            _prep_cost = 0
        End If
        'оплаченная стоимость препарации
        Dim _prep_cost_clear = clsApplicationTypes.ReplaceDecimalSplitter(Me.tbPrepCost)
        If Me.cbxIncomingIncludePrep.Checked Then
            _prep_cost_clear = 0
        End If
        '---рассчеты
        If _hunt_cost = 0 Then
            MsgBox("Следует задать цену инвойса или закупки - рассчет цен невозможен", vbCritical)
            Return
        End If

        'вывоз/ввоз
        Dim _exportCost As Decimal = 0

retexp:
        'добавить ли перевозку
        Select Case Me.cbxSetExport.Checked
            Case True
                'прибавить перевозку к входящей
                Dim _tariff = clsApplicationTypes.ReplaceDecimalSplitter(tbWeightTariff)
                If Me.tbWeightTariff.Text = "" Then
                    Select Case Me.cbWeightTariff.SelectedIndex
                        Case Is <= 0
                            _tariff = My.Settings.ShippingTariffPerKG
                        Case 1
                            _tariff = My.Settings.ShippingTariffPerPCS
                        Case Else
                            _tariff = My.Settings.ShippingTariffPerE
                    End Select
                End If
                _exportCost = (oCurrentGood.Weight * clsApplicationTypes.CurrencyConvert(_tariff, "EUR", "RUR"))
            Case False
                Select Case MsgBox("Перевозка не будет включена в рассчет. Продолжить? (Нет - превозка будет включена в рассчет)", vbYesNo)
                    Case MsgBoxResult.No
                        Me.cbxSetExport.Checked = True
                        GoTo retexp
                End Select
        End Select

        '--проверки значений
        If _buyprice = 0 Then
            'входящая не установлена
            If Me.cbxCalculateBuy.Checked = False Then
                'нет запроса рассчета входящей
                Select Case MsgBox("Входящая цена в карточке не установлена и флажок рассчета входящей снят. Будем рассчитывать входящую для карточки товара?", vbYesNo)
                    Case vbNo
                        GoTo prcl
                End Select
            Else
                'запрошен рассчет входящей
                'рассчитаем
            End If
        Else
            'входящая цена установлена
            If Me.cbxCalculateBuy.Checked = False Then
                'нет запроса рассчета входящей
                'рассчет не запрашиваем - оставить как есть
                GoTo prcl
            Else
                'запрошен рассчет входящей
                Select Case MsgBox("Входящая цена в карточке уже установлена. Рассчитать входящую для карточки товара заново?", vbYesNo)
                    Case vbNo
                        GoTo prcl
                End Select
            End If
        End If


        '--рассчет инвойс-цены
        'запись инвойса
        'добавить оплату препарации
        Me.AddInvoiceCost(_hunt_cost + _prep_cost_clear, True)

        '---заново рассчитаем входящую
        _buyprice = _hunt_cost

        If Not Me.cbxIncomingIncludeExport.Checked Then
            'закупка НЕ учитывает перевозку
            If Me.cbxSetExport.Checked Then
                _buyprice += _exportCost
            End If
        End If

        If Not Me.cbxIncomingIncludePrep.Checked Then
            'закупка НЕ учитывает препарацию
            _buyprice += _prep_cost
        End If


        'запись входящей
        Me.AddIncomingCost(_buyprice, True)
prcl:
        'принудительная запись инвойса
        If clsApplicationTypes.ReplaceDecimalSplitter(tbInvoice) = 0 Then
            Me.AddInvoiceCost(_hunt_cost + _prep_cost_clear, True)
        End If

        'подготовка цен к рассчету таблицы цен
        If Not Me.cbxIncomingIncludeExport.Checked Then
            'закупка НЕ учитывает перевозку
            If Me.cbxSetExport.Checked Then
                _hunt_cost += _exportCost
            End If
        End If

        If Me.cbxIncomingIncludePrep.Checked Then
            'закупка учитывает препарацию
            _prep_cost = 0
        End If

        If Me.UcPriceCalc1.Enabled Then
            Me.UcPriceCalc1.SetData(Hunt_cost:=_hunt_cost, Prep_cost:=_prep_cost, Weight:=_weight, ClearProfit:=0.1)
            Me.tbCtlMain.SelectedTab = tpPrices
        End If

    End Sub



    ''' <summary>
    ''' заменить на конвертированную входящую
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btFromBuy_Click(sender As Object, e As EventArgs) Handles btFromBuy.Click
        Dim _curr = (From c As MoySkladAPI.currency In Me.cbBuyTargetCurrency.Items Where c.uuid = Me.oCurrentGood.Good.buyCurrencyUuid Select c).FirstOrDefault
        If Not _curr Is Nothing Then
            Me.tbBuyCost.Text = clsApplicationTypes.CurrencyConvert(oCurrentGood.Good.buyPrice / 100, _curr.name, "RUR")
            MarkAsNeedSaved()
        End If
        Me.cbxIncomingIncludeExport.Checked = True
        Me.cbxIncomingIncludePrep.Checked = True
    End Sub
    ''' <summary>
    ''' заменить на конвертированную инвойс
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btFromInvoice_Click(sender As Object, e As EventArgs) Handles btFromInvoice.Click
        Dim _curr As MoySkladAPI.currency = Me.cbInvoceCurrency.SelectedItem
        'Dim _curr = (From c As MoySkladAPI.currency In Me.cbInvoceCurrency.Items Where c.uuid = Me.oCurrentGood.Good.buyCurrencyUuid Select c).FirstOrDefault
        If Not _curr Is Nothing Then
            Dim _inv = oCurrentGood.Good.GetPriceByType(oManager, iMoySkladDataProvider.emPriceType.Invoce).value / 100
            If _inv > 0 Then
                Me.tbBuyCost.Text = clsApplicationTypes.CurrencyConvert(_inv, _curr.name, "RUR")
                MarkAsNeedSaved()
            Else
                _inv = clsApplicationTypes.ReplaceDecimalSplitter(Me.tbInvoice)
                If _inv > 0 Then
                    Me.tbBuyCost.Text = clsApplicationTypes.CurrencyConvert(_inv, _curr.name, "RUR")
                    MarkAsNeedSaved()
                End If
            End If
        End If
    End Sub


    ''' <summary>
    ''' добавить препаратора в список
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btAddPrep_Click(sender As Object, e As EventArgs) Handles btAddPrep.Click
        Dim _time = clsApplicationTypes.ReplaceDecimalSplitter(Me.tbPrepTimeAdd)
        If _time = 0 AndAlso Me.cbPreparatorAdd.SelectedItem Is Nothing Then
            clsApplicationTypes.BeepNOT()
            Return
        End If

        Dim _user As customEntity = Me.cbPreparatorAdd.SelectedItem
        Dim _salary = (From c In clsApplicationTypes.Users Where c.Employee.UUID IsNot Nothing AndAlso c.Employee.UUID.Trim.Equals(_user.uuid) Select c.GetRURSalary).FirstOrDefault

        Dim _out = String.Format("{0}({2}*{1})", _user.name, _salary, _time)
        If Not String.IsNullOrEmpty(tbPrepList.Text) Then
            tbPrepList.Text += ";"
        End If
        tbPrepList.Text += _out

        Me.cbPreparatorAdd.SelectedIndex = -1
        Me.tbPrepTimeAdd.Text = ""

        clsApplicationTypes.BeepYES()
        Me.MarkAsNeedSaved()
        Me.cbPreparatorAdd.Focus()
    End Sub
    ''' <summary>
    ''' ввод выплаченного налика
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tbPrepCost_TextChanged(sender As Object, e As EventArgs) Handles tbPrepCost.TextChanged
        Dim _totalHour As Decimal = 0
        Dim _totalPay As Decimal = 0

        If clsMoyScladManager.ParsePrepString(tbPrepList.Text, _totalHour, _totalPay) Then
            If Not clsApplicationTypes.ReplaceDecimalSplitter(tbPrepCost) = 0 Then
                'для блокирования изменения во время чтения с сервера
                Me.tbFullPrepCost.Text = PrepCalculate(_totalPay)
                MarkAsNeedSaved()
            End If
        Else
            'неразборчивая строка
            If Not clsApplicationTypes.ReplaceDecimalSplitter(tbPrepCost) = 0 Then
                Me.tbFullPrepCost.Text = PrepCalculate(clsApplicationTypes.ReplaceDecimalSplitter(tbPrepCost))
                MarkAsNeedSaved()
            End If
        End If
    End Sub



    Private Sub tbPrepTimeAdd_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbPrepTimeAdd.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Me.btAddPrep_Click(sender, e)
        End If
    End Sub

    ''' <summary>
    ''' очистить препараторов
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btClearPrep_Click(sender As Object, e As EventArgs) Handles btClearPrep.Click
        Me.tbPrepTime.Text = ""
        Me.tbPrepCost.Text = ""
        Me.tbFullPrepCost.Text = ""
        MarkAsNeedSaved()
    End Sub



    ''' <summary>
    ''' завершен рассчет цены - покажем
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub UcPriceCalc1_CalcComplete(sender As Object, e As ucPriceCalc.CalcCompleteEventArgs) Handles UcPriceCalc1.CalcComplete
        Dim _pr = e.PriceData

        'умное округление
        Dim _digits As Integer = -1

        If Not Me.cbRoundPrices.Checked Then
            _digits = -2
        End If

        _pr.Rus_office = clsApplicationTypes.RoundPrice(_pr.Rus_office, _digits)
        _pr.Rus_show = clsApplicationTypes.RoundPrice(_pr.Rus_show, _digits)
        _pr.Eu_office = clsApplicationTypes.RoundPrice(_pr.Eu_office, _digits)
        _pr.Eu_show = clsApplicationTypes.RoundPrice(_pr.Eu_show, _digits)
        _pr.Eu_post_bank = clsApplicationTypes.RoundPrice(_pr.Eu_post_bank, _digits)
        _pr.Eu_post_paypal = clsApplicationTypes.RoundPrice(_pr.Eu_post_paypal, _digits)
        _pr.eBay = clsApplicationTypes.RoundPrice(_pr.eBay, _digits)
        _pr.Rus_office_w = clsApplicationTypes.RoundPrice(_pr.Rus_office_w, _digits)

        'инвойс
        If Me.tbInvoice.Visible Then
            _pr.Invoce = clsApplicationTypes.ReplaceDecimalSplitter(Me.tbInvoice)
            If Me.cbInvoceCurrency.SelectedIndex > -1 And Not Me.cbInvoceCurrency.SelectedItem Is Nothing Then
                _pr.InvoceCurrency = Me.cbInvoceCurrency.SelectedItem.name
            End If
        End If


        'буфер цен
        oCurrentPrices = _pr
        clsApplicationTypes.BeepYES()
    End Sub

    ''' <summary>
    ''' перенести цены в карточку
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btSetPrices_Click(sender As Object, e As EventArgs) Handles btSetPrices.Click
        Me.UcPriceCalc_clsPriceDataBindingSource.DataSource = oCurrentPrices
        Me.btWritePrices.BackColor = Color.Red
        Me.btWritePrices.Focus()
    End Sub


    ''' <summary>
    ''' записать цены в карточку товара
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btWritePrices_Click(sender As Object, e As EventArgs) Handles btWritePrices.Click
        If oCurrentGood Is Nothing Then Return
        Me.btWritePrices.BackColor = Button.DefaultBackColor

        Dim _pr As ucPriceCalc.clsPriceData = Me.UcPriceCalc_clsPriceDataBindingSource.DataSource
        'розничная цена
        oCurrentGood.Good.SetPriceByType(oManager, iMoySkladDataProvider.emPriceType.RusShop, _pr.Rus_show, "RUR")
        oCurrentGood.Good.SetRetailPrice(oManager, _pr.Rus_show, "RUR")

        Me.cbRetailTargetCurrency.SelectedItem = (From c As MoySkladAPI.currency In CType(Me.cbRetailTargetCurrency.DataSource, List(Of MoySkladAPI.currency)) Where c.name = "RUR").FirstOrDefault
        Me.tbRetailTargetValue.Text = _pr.Rus_show
        'другие цены
        oCurrentGood.Good.SetPriceByType(oManager, iMoySkladDataProvider.emPriceType.RusInOffice, _pr.Rus_office, "RUR")
        oCurrentGood.Good.SetPriceByType(oManager, iMoySkladDataProvider.emPriceType.EuInOffice, _pr.Eu_office, "EUR")
        oCurrentGood.Good.SetPriceByType(oManager, iMoySkladDataProvider.emPriceType.EuInShop, _pr.Eu_show, "EUR")
        oCurrentGood.Good.SetPriceByType(oManager, iMoySkladDataProvider.emPriceType.EuPostBank, _pr.Eu_post_bank, "USD")
        oCurrentGood.Good.SetPriceByType(oManager, iMoySkladDataProvider.emPriceType.EuPostPayPal, _pr.Eu_post_paypal, "USD")
        oCurrentGood.Good.SetPriceByType(oManager, iMoySkladDataProvider.emPriceType.Ebay, _pr.eBay, "USD")

        'минимальная цена
        oCurrentGood.Good.SetPriceByType(oManager, iMoySkladDataProvider.emPriceType.MinimumPrice, _pr.Rus_office_w, "RUR")

        'инвойс
        If _pr.Invoce > 0 And Not String.IsNullOrEmpty(_pr.InvoceCurrency) Then
            oCurrentGood.Good.SetPriceByType(oManager, iMoySkladDataProvider.emPriceType.Invoce, _pr.Invoce, _pr.InvoceCurrency)
            Me.tbInvoice.Text = _pr.Invoce
            Me.cbInvoceCurrency.SelectedItem = (From c As MoySkladAPI.currency In oManager.CurrencyList Where c.name = _pr.InvoceCurrency).FirstOrDefault
        End If

        oCurrentGood.AllPrices = _pr
        Me.UcPriceCalc_clsPriceDataBindingSource.DataSource = oCurrentGood.AllPrices

        Dim _new As New List(Of goodAttributeValue)
        If Not oCurrentGood.Good.attribute Is Nothing Then
            _new.AddRange(oCurrentGood.Good.attribute)
        End If

        Dim _metauuid As String
        Dim _Value As Object

        Dim _deletefn = Sub(metadataUUID As String)
                            'ищем флаг в атрибутах товара
                            Dim _resAttrValue1 As goodAttributeValue
                            _resAttrValue1 = (From c In _new Where c.metadataUuid = metadataUUID Select c).FirstOrDefault
                            If Not _resAttrValue1 Is Nothing Then
                                'да - удалим
                                _new.Remove(_resAttrValue1)
                            End If
                        End Sub
        Dim _addfn = Sub(attributeValue As Object, metadataUUID As String, IsBooleanType As Boolean, IsStringType As Boolean, IsDecimalType As Boolean, IsTextType As Boolean, IsCustomEntityType As Boolean)
                         'ищем флаг в атрибутах товара
                         Dim _resAttrValue As goodAttributeValue
                         _resAttrValue = (From c In _new Where c.metadataUuid = metadataUUID Select c).FirstOrDefault
                         If Not _resAttrValue Is Nothing Then
                             'удалить атрибут
                             _deletefn(metadataUUID)
                         End If
                         'нет - создаем обьект атрибута и добавляем его в коллекцию
                         _resAttrValue = goodAttributeValue.CreateInstance(oCurrentGood.Good.uuid, metadataUUID, attributeValue, IsBooleanType, IsStringType, IsDecimalType, IsTextType, IsCustomEntityType)
                         _new.Add(_resAttrValue)
                     End Sub


        'записать прибыльность
        _metauuid = My.Settings.ClearProfitMetaUUID
        _Value = _pr.Clear_Profit
        _addfn(_Value, _metauuid, False, False, True, False, False)

        'записать препарацию
        _metauuid = My.Settings.PrepFullMetaUUID
        _Value = _pr.Prep_cost
        _addfn(_Value, _metauuid, False, False, True, False, False)

        'записать поставку
        _metauuid = My.Settings.HuntFullMetaUUID
        _Value = _pr.Hunt_cost
        _addfn(_Value, _metauuid, False, False, True, False, False)


        'записать схему
        'справочник Схемы рассчетов выплат
        If (Not Me.cbSchemePrice.SelectedItem Is Nothing) Then
            _metauuid = My.Settings.SchemeMetaUUID
            If CType(Me.cbSchemePrice.SelectedItem, customEntity).uuid = "" Then
                'удалить (не добавлять) атрибут
                _deletefn(_metauuid)
            Else
                _Value = CType(Me.cbSchemePrice.SelectedItem, customEntity).uuid
                _addfn(_Value, _metauuid, False, False, False, False, True)
            End If
        End If

        oCurrentGood.Good.attribute = _new.ToArray
        ShowLabelWithPrice()
        clsApplicationTypes.BeepYES()
        MarkAsNeedSaved()
    End Sub

    Private Sub btMinusFullPrep_Click(sender As Object, e As EventArgs)
        Me.tbBuyCost.Text = (clsApplicationTypes.ReplaceDecimalSplitter(Me.tbBuyCost) - clsApplicationTypes.ReplaceDecimalSplitter(Me.tbFullPrepCost))
        MarkAsNeedSaved()
    End Sub

    Private Sub btToPrepTime_Click(sender As Object, e As EventArgs) Handles btToPrepTime.Click
        Me.tbPrepTimeAdd.Text = Me.tbPrepTime.Text
        Me.btAddPrep.Focus()
    End Sub

    Private Sub tbPrepList_TextChanged(sender As Object, e As EventArgs) Handles tbPrepList.TextChanged
        Dim _totalHour As Decimal = 0
        Dim _totalPay As Decimal = 0
        Dim _mess As String = ""
        If clsMoyScladManager.ParsePrepString(tbPrepList.Text, _totalHour, _totalPay) Then
            Me.tbPrepCost.Text = _totalPay
            Me.tbPrepTime.Text = _totalHour
        End If
    End Sub
    ''' <summary>
    ''' подсветить желтым, если для ребят
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tbFullPrepCost_TextChanged(sender As Object, e As EventArgs) Handles tbFullPrepCost.TextChanged
        Dim _totalHour As Decimal = 0
        Dim _totalPay As Decimal = 0
        Dim _mess As String = ""
        If clsMoyScladManager.ParsePrepString(tbPrepList.Text, _totalHour, _totalPay) Then

            Dim _friend As Decimal = 0
            Dim _fp = PrepCalculate(_totalPay, , , _friend)

            Dim _sto = clsApplicationTypes.ReplaceDecimalSplitter(Me.tbFullPrepCost)

            If _sto > (_friend - _friend * 0.05) And _sto < (_friend + _friend * 0.05) Then
                'задана цена для ребят
                tbFullPrepCost.BackColor = Color.Yellow
            Else
                tbFullPrepCost.BackColor = Color.White
            End If

            '_mess = String.Format("Налик {0} руб.; Для ребят {2} руб.; к рассчету {1} руб.", _totalPay, _fp, _friend)
        Else
            'неразборчивая строка
            _totalPay = clsApplicationTypes.ReplaceDecimalSplitter(tbPrepCost)
            Dim _friend As Decimal = 0
            Dim _fp = PrepCalculate(_totalPay, , , _friend)
            Dim _sto = clsApplicationTypes.ReplaceDecimalSplitter(Me.tbFullPrepCost)

            If _sto > (_friend - _friend * 0.05) And _sto < (_friend + _friend * 0.05) Then
                'задана цена для ребят
                tbFullPrepCost.BackColor = Color.Yellow
            Else
                tbFullPrepCost.BackColor = Color.White
            End If
            '_mess = String.Format("Налик {0} руб.; Стоимость для ребят {2} руб.; к рассчету {1} руб.", _totalPay, _fp, _friend)
        End If
    End Sub

    Private Sub tbWeight_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbWeight.KeyPress, tbBuyCost.KeyPress, tbFullPrepCost.KeyPress
        Me.MarkAsNeedSaved()

    End Sub


    Private Sub bt_UCRequest_Click(sender As Object, e As EventArgs) Handles bt_UCRequest.Click
        Dim _sm = UC_rfid1.SampleNumber
        ' ClearAll()
        If Not Me.tbNumber.Text.Equals(_sm) Then
            ClearAll()
            Me.tbNumber.Text = _sm
            Me.btSearchInSklad_Click(sender, e)

            If Me.cbx_UCAutoprintWithPrice.Checked Then
                If String.IsNullOrEmpty(Me.GetCurrentPriceString) Then
                    Select Case MsgBox("Запрошенная цена не задана для образца. Этикетка будет без цены. Печатать этикетку?", vbYesNo)
                        Case MsgBoxResult.No
                            Return
                    End Select
                End If
                ShowLabelWithPrice()
                PrintLabel(sender, e)
            End If
        Else
            clsApplicationTypes.BeepNOT()
        End If

    End Sub

    ''' <summary>
    ''' передать имя в этикетку
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btSearchLabel_Click(sender As Object, e As EventArgs) Handles btSearchLabel.Click
        Dim _value = Me.tbName.SelectedText
        If String.IsNullOrEmpty(_value) Then
            _value = Me.tbName.Text
        End If
        Me.UcGoodLabel1.NameForLabel = _value
        Me.tbCtlMain.SelectedTab = Me.tpRfid
    End Sub

    Private Sub cbxNeedPhotos_CheckedChanged(sender As Object, e As EventArgs) Handles cbxNeedPhotos.CheckedChanged
        If oCurrentGood Is Nothing Then Return
        If Not oRedKeyOff Then
            Me.MarkAsNeedSaved()
        End If
    End Sub

    Private Sub Label57_Click(sender As Object, e As MouseEventArgs) Handles Label57.MouseClick

    End Sub

    Private Sub UcPriceCalc_clsPriceDataBindingSource_CurrentChanged(sender As Object, e As EventArgs) Handles UcPriceCalc_clsPriceDataBindingSource.CurrentChanged
        If UcPriceCalc_clsPriceDataBindingSource.DataSource Is Nothing Then Return

        ' Dim _pr As ucPriceCalc.clsPriceData = oCurrentPrices  ' UcPriceCalc_clsPriceDataBindingSource.DataSource
        If oCurrentPrices Is Nothing Then Me.tbCoeff.Text = "" : Return
        If Not oCurrentPrices.Buy_cost = 0 Then
            Me.tbCoeff.Text = Decimal.Round(oCurrentPrices.Rus_office / oCurrentPrices.Buy_cost, 1)
        Else
            Me.tbCoeff.Text = ""
        End If

    End Sub
    Private Sub btCallCalculator_Click_1(sender As Object, e As EventArgs) Handles btCallCalculator.Click

        Dim _param As Object = ""
        Dim _fm = clsApplicationTypes.CallAnyForm(emFormsList.fmCalculator, _param)
        If Not _fm Is Nothing Then
            Try
                _fm.Show()
            Catch ex As Exception
                MsgBox("Не могу отобразить форму")
            End Try

        End If

    End Sub
    ''' <summary>
    ''' Розница из опта RUS
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btPlus30_Click(sender As Object, e As EventArgs) Handles btRusPlus30.Click
        If UcPriceCalc_clsPriceDataBindingSource.DataSource Is Nothing Then Return
        Dim _data As ucPriceCalc.clsPriceData = UcPriceCalc_clsPriceDataBindingSource.DataSource
        _data.Rus_show = clsApplicationTypes.RoundPrice(_data.Rus_office / 0.7, 1)
        '        UcPriceCalc_clsPriceDataBindingSource.ResetBindings(False)
    End Sub
    ''' <summary>
    ''' опт из розницы RUS
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btMinus30_Click(sender As Object, e As EventArgs) Handles btRusMinus30.Click
        If UcPriceCalc_clsPriceDataBindingSource.DataSource Is Nothing Then Return
        Dim _data As ucPriceCalc.clsPriceData = UcPriceCalc_clsPriceDataBindingSource.DataSource
        _data.Rus_office = clsApplicationTypes.RoundPrice(_data.Rus_show * 0.7, 1)

        'Dim _value = clsApplicationTypes.ReplaceDecimalSplitter(Me.tbPRICE2)

        'Me.tbPRICE1.Text = clsApplicationTypes.RoundPrice(_value * 0.7, 1)
    End Sub
    ''' <summary>
    ''' считает цены в соответствии с коэфициентом от ПОЛНОЙ ЗАКУПКИ
    ''' </summary>
    ''' <param name="koeff"></param>
    ''' <remarks></remarks>
    Private Sub PriceReduce(koeff As Decimal)
        If UcPriceCalc_clsPriceDataBindingSource.DataSource Is Nothing Then Return
        Dim _data As ucPriceCalc.clsPriceData = UcPriceCalc_clsPriceDataBindingSource.DataSource
        If _data.Buy_cost = 0 Then
            Dim _curr As MoySkladAPI.currency = Me.cbBuyTargetCurrency.SelectedItem
            If Not _curr Is Nothing Then
                _data.Buy_cost = clsApplicationTypes.CurrencyConvert(oCurrentGood.Good.buyPrice / 100, _curr.name, "RUR")
            Else
                MsgBox("Задайте закупочные цены!", vbCritical)
                Return
            End If

        End If

        'россия (накладные на выставку или лавку 30%)
        _data.Rus_show = clsApplicationTypes.RoundPrice(clsApplicationTypes.CurrencyConvert(_data.Buy_cost * koeff, "RUR", "RUR"), 1)
        _data.Rus_office = clsApplicationTypes.RoundPrice(_data.Rus_show * 0.7, 1)

        'европа (накладные на выставку 30%)
        _data.Eu_show = clsApplicationTypes.RoundPrice(clsApplicationTypes.CurrencyConvert(_data.Buy_cost * koeff, "RUR", "EUR"), -1)
        _data.Eu_office = clsApplicationTypes.RoundPrice(_data.Eu_show * 0.7, -1)

        'eBay PayPal и почта
        _data.eBay = clsApplicationTypes.RoundPrice(clsApplicationTypes.CurrencyConvert(_data.Buy_cost * koeff, "RUR", "USD"), -1)
        'меньше на 12% (средние ebay fee)
        _data.Eu_post_paypal = clsApplicationTypes.RoundPrice(_data.eBay * 0.88, -1)
        'меньше на 10% обналички
        _data.Eu_post_bank = clsApplicationTypes.RoundPrice(_data.eBay * 0.9, -1)

        If Not _data.Buy_cost = 0 Then
            Me.tbCoeff.Text = Decimal.Round(_data.Rus_office / _data.Buy_cost, 1)
        Else
            Me.tbCoeff.Text = ""
        End If
    End Sub

    ''' <summary>
    ''' два конца
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btRet2_Click(sender As Object, e As EventArgs) Handles btRet2.Click
        Me.PriceReduce(2)
        'If UcPriceCalc_clsPriceDataBindingSource.DataSource Is Nothing Then Return
        'Dim _data As ucPriceCalc.clsPriceData = UcPriceCalc_clsPriceDataBindingSource.DataSource
        'If _data.Invoce = 0 Then Return
        'If String.IsNullOrEmpty(_data.InvoceCurrency) Then
        '    MsgBox("Задайте валюту инвойса!", vbCritical)
        '    Return
        'End If
        '_data.Rus_show = clsApplicationTypes.RoundPrice(clsApplicationTypes.CurrencyConvert(_data.Invoce * 2, _data.InvoceCurrency, "RUR"), 1)
        'btMinus30_Click(sender, e)
    End Sub
    ''' <summary>
    ''' рассчетные 3,2 конца
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btRet32_Click(sender As Object, e As EventArgs) Handles btRet32.Click
        Me.PriceReduce(3.2)
        'If UcPriceCalc_clsPriceDataBindingSource.DataSource Is Nothing Then Return
        'Dim _data As ucPriceCalc.clsPriceData = UcPriceCalc_clsPriceDataBindingSource.DataSource
        'If _data.Invoce = 0 Then Return
        'If String.IsNullOrEmpty(_data.InvoceCurrency) Then
        '    MsgBox("Задайте валюту инвойса!", vbCritical)
        '    Return
        'End If
        '_data.Rus_show = clsApplicationTypes.RoundPrice(clsApplicationTypes.CurrencyConvert(_data.Invoce * 3.2, _data.InvoceCurrency, "RUR"), 1)
        'btMinus30_Click(sender, e)
    End Sub
    ''' <summary>
    ''' 4 конца
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btRet4_Click(sender As Object, e As EventArgs) Handles btRet4.Click
        Me.PriceReduce(4)
        'If UcPriceCalc_clsPriceDataBindingSource.DataSource Is Nothing Then Return
        'Dim _data As ucPriceCalc.clsPriceData = UcPriceCalc_clsPriceDataBindingSource.DataSource
        'If _data.Invoce = 0 Then Return
        'If String.IsNullOrEmpty(_data.InvoceCurrency) Then
        '    MsgBox("Задайте валюту инвойса!", vbCritical)
        '    Return
        'End If
        '_data.Rus_show = clsApplicationTypes.RoundPrice(clsApplicationTypes.CurrencyConvert(_data.Invoce * 4, _data.InvoceCurrency, "RUR"), 1)
        'btMinus30_Click(sender, e)
    End Sub

    ''' <summary>
    ''' проверка розницы
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tbPRICE2_TextChanged(sender As Object, e As EventArgs) Handles tbPRICE2.TextChanged
        'Dim _valueInvoice = clsApplicationTypes.ReplaceDecimalSplitter(Me.tbPrice8)
        'If _valueInvoice = 0 Then GoTo ex
        'If Me.CR8cb.SelectedItem Is Nothing Then
        '    GoTo ex
        'End If

        If UcPriceCalc_clsPriceDataBindingSource.DataSource Is Nothing Then GoTo ex
        Dim _data As ucPriceCalc.clsPriceData = UcPriceCalc_clsPriceDataBindingSource.DataSource
        If _data.Buy_cost = 0 Then
            Dim _curr As MoySkladAPI.currency = Me.cbBuyTargetCurrency.SelectedItem
            If Not _curr Is Nothing Then
                _data.Buy_cost = clsApplicationTypes.CurrencyConvert(oCurrentGood.Good.buyPrice / 100, _curr.name, "RUR")
            Else
                GoTo ex
            End If
        End If

        Dim _value = clsApplicationTypes.ReplaceDecimalSplitter(Me.tbPRICE2)
        If _value = 0 Then GoTo ex

        If _value < _data.Buy_cost * 2 Then
            'розница в россии меньше чем два конца!!
            tbPRICE2.BackColor = Color.Red
        ElseIf _value < _data.Buy_cost * 3.2 Then
            'розница в россии меньше чем 3.2 конца!!
            tbPRICE2.BackColor = Color.Yellow
        Else
            'от 3,2 конца и выше - ок
            tbPRICE2.BackColor = Color.White
        End If
        'посчитать офис
        'btMinus30_Click(sender, e)
        Me.tbPRICE1.Text = clsApplicationTypes.RoundPrice(_value * 0.7, 1)

        'If Not _data.Buy_cost = 0 Then
        '    Me.tbCoeff.Text = Decimal.Round(clsApplicationTypes.RoundPrice(_value * 0.7, 1) / _data.Buy_cost, 1)
        'Else
        '    Me.tbCoeff.Text = ""
        'End If
        Return
ex:
        tbPRICE2.BackColor = Color.White
       
    End Sub
    Private Sub tbPRICE1_TextChanged(sender As Object, e As EventArgs) Handles tbPRICE1.TextChanged
        If UcPriceCalc_clsPriceDataBindingSource.DataSource Is Nothing Then Return
        Dim _data As ucPriceCalc.clsPriceData = UcPriceCalc_clsPriceDataBindingSource.DataSource
        If _data.Buy_cost = 0 Then
            Dim _curr As MoySkladAPI.currency = Me.cbBuyTargetCurrency.SelectedItem
            If Not _curr Is Nothing Then
                _data.Buy_cost = clsApplicationTypes.CurrencyConvert(oCurrentGood.Good.buyPrice / 100, _curr.name, "RUR")
            Else
                Return
            End If
        End If
        If Not _data.Buy_cost = 0 Then
            Me.tbCoeff.Text = Decimal.Round(clsApplicationTypes.ReplaceDecimalSplitter(Me.tbPRICE1) / _data.Buy_cost, 1)
        Else
            Me.tbCoeff.Text = ""
        End If
    End Sub

    ''' <summary>
    ''' Розница из опта IMP
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btImpPlus30_Click(sender As Object, e As EventArgs) Handles btImpPlus30.Click

        If UcPriceCalc_clsPriceDataBindingSource.DataSource Is Nothing Then Return
        Dim _data As ucPriceCalc.clsPriceData = UcPriceCalc_clsPriceDataBindingSource.DataSource
        _data.Eu_show = clsApplicationTypes.RoundPrice(_data.Eu_office / 0.7, -1)

        'Dim _value = clsApplicationTypes.ReplaceDecimalSplitter(Me.tbPRICE3)
        'Me.tbPRICE6.Text = clsApplicationTypes.RoundPrice(_value / 0.7)
    End Sub
    ''' <summary>
    ''' опт из розницы IMP
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btImpMinus30_Click(sender As Object, e As EventArgs) Handles btImpMinus30.Click

        If UcPriceCalc_clsPriceDataBindingSource.DataSource Is Nothing Then Return
        Dim _data As ucPriceCalc.clsPriceData = UcPriceCalc_clsPriceDataBindingSource.DataSource
        _data.Eu_office = clsApplicationTypes.RoundPrice(_data.Eu_show * 0.7, -1)

    End Sub


    Private Sub cbFixPriceTab_CheckedChanged(sender As Object, e As EventArgs) Handles cbFixPriceTab.CheckedChanged
        If cbFixPriceTab.Checked Then
            cbFixPrepTab.Checked = False
            cbFixTabRfid.Checked = False
        End If
    End Sub

    Private Sub cbFixPrepTab_CheckedChanged(sender As Object, e As EventArgs) Handles cbFixPrepTab.CheckedChanged
        If cbFixPrepTab.Checked Then
            cbFixPriceTab.Checked = False
            cbFixTabRfid.Checked = False
        End If
    End Sub

    Private Sub cbFixTabRfid_CheckedChanged(sender As Object, e As EventArgs) Handles cbFixTabRfid.CheckedChanged
        If cbFixTabRfid.Checked Then
            cbFixPriceTab.Checked = False
            cbFixPrepTab.Checked = False
        End If
    End Sub

    Private Sub cbStoreForPlacing_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbStoreForPlacing.SelectedIndexChanged

    End Sub

    Private Sub btCreateInventory_Click(sender As Object, e As EventArgs) Handles btCreateInventory.Click
        If Me.cbStoreForPlacing.SelectedItem Is Nothing Then
            MsgBox("Задайте склад назначения инвентаризации", vbCritical)
            Return
        End If

        If Me.bs_Curr_slot_location.Current Is Nothing Then
            MsgBox("Не выбрана ячейка для инвентаризации", vbCritical)
            Return
        End If
        If Me.lbxnumbers.Items.Count = 0 Then
            MsgBox("Нет образцов для инвентаризации", vbCritical)
            Return
        End If



        'склад
        Dim _targetPlace As clsGoodLocation = CType(Me.cbStoreForPlacing.SelectedItem, clsGoodLocation)

        'выбор компании по имени склада (для которой создается инвентаризация)
        Dim _companyName As String = "paleotravel"
        Select Case _targetPlace.WarehouseName.ToLower
            Case "внутренний нарва"
                _companyName = "NordStar Service OU"
            Case "внутренний питер"
                _companyName = "paleotravel"
            Case Else
                _companyName = "paleotravel"
        End Select
        Dim _cm = oManager.GetCompanyByName(_companyName)

        'образцы
        Dim _items = (From c As iMoySkladDataProvider.strGoodMapQty In Me.lbxnumbers.Items Select c.UUID).ToArray
        'ячейка
        Dim _slot As clsGoodLocation.clsSlot = Me.bs_Curr_slot_location.Current
        'описание
        Dim _description As String = "флеты " & _slot.ESlot.name
        'статус
        'Dim _StateUUID = oAgent.GetAgentID("moysklad", "Demandstate1")

        Select Case MsgBox(String.Format("Создать инветаризацию для ячейки {1} склада {0}?", _targetPlace.WarehouseName, _slot.ESlot.name), vbYesNo)
            Case vbNo
                Return
        End Select

        'показат сплеш
        If oSplashscreen1.Visible = False Then
            oSplashscreen1.Show()
            Application.DoEvents()
        End If

        Dim _res = oManager.CreateInventory(MyCompanyUUID:=_cm.UUID, WarehouseUUID:=_targetPlace.WarehouseUUID, GoodsUUIDs:=_items, Description:=_description, WareCellName:=_slot.ESlot.name, Applicable:=True, GoodsQtys:=Nothing)

        Me.oSplashscreen1.Hide()

        If _res.HasError Then
            MsgBox("При создании инвентаризации произошла ошибка: " & _res.ErrorMessage, vbCritical)
            Return
        Else
            MsgBox(String.Format("Инвентаризация {0} создана.", _res.name), vbInformation)
        End If

    End Sub



    Private Sub PictureBox1_DoubleClick(sender As Object, e As EventArgs) Handles PictureBox1.DoubleClick
        If Me.lbxnumbers.SelectedItem Is Nothing Then Return

        Dim _item As iMoySkladDataProvider.strGoodMapQty = Me.lbxnumbers.SelectedItem
        Dim _prm = Service.clsApplicationTypes.SamplePhotoObject.GetImageCollection(_item.ActualSampleNumber, clsFilesSources.Arhive, False)
        If _prm Is Nothing Then
            MsgBox("невозможно показать форму с изображениями", vbCritical)
        End If
        Dim _fmImage As Form
        'show image form
        Dim _param As Object = {_prm, ""}
        'если делегата нет, то сервис недоступен
        If Not Global.Service.clsApplicationTypes.DelegateStoreApplicationForm(Service.clsApplicationTypes.emFormsList.fmImage) Is Nothing Then
            'сервис зарегестрирован - вызываем
            _fmImage = Global.Service.clsApplicationTypes.DelegateStoreApplicationForm(Service.clsApplicationTypes.emFormsList.fmImage).Invoke(_param)
            If Not _fmImage Is Nothing Then
                'show form
                _fmImage.Width = 640
                _fmImage.Height = 480
                _fmImage.StartPosition = FormStartPosition.CenterScreen
                'привязка обработчика
                'Service.clsApplicationTypes.DelegatStorefmImageDeleteDelegate = New Service.clsApplicationTypes.fmImageDeleteDelegat(AddressOf DelImage_eventHandler)
                'Service.clsApplicationTypes.DelegatStorefmImageCopyDelegate = New Service.clsApplicationTypes.fmImageCopyDelegat(AddressOf CopyImage_eventHandler)
                _fmImage.ShowDialog()
            End If
        End If
    End Sub

    Private Sub cbSetExport_CheckedChanged(sender As Object, e As EventArgs) Handles cbxSetExport.CheckedChanged

    End Sub


    Private Sub cbxIncomingIncludePrep_CheckedChanged(sender As Object, e As EventArgs) Handles cbxIncomingIncludePrep.CheckedChanged

    End Sub

    Private Sub cbRoundPrices_CheckedChanged(sender As Object, e As EventArgs) Handles cbRoundPrices.CheckedChanged
        Me.UcPriceCalc1.Calculate()
    End Sub
    ''' <summary>
    ''' рассчет входящей
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btIncomingCalculate_Click(sender As Object, e As EventArgs) Handles btIncomingCalculate.Click
        If cbUom.SelectedItem Is Nothing Then
            'надо знать ед измерения
            MsgBox("Необходимо задать ед. измерения товара для расчета входящей", vbCritical)
            Return
        End If
        Dim _message As String = "Входящая цена = "
        Dim _incomingprice As Decimal
        _incomingprice = clsApplicationTypes.ReplaceDecimalSplitter(Me.tbInvoice)

        If _incomingprice = 0 Then
            MsgBox("Необходимо задать цену инвойса для рассчета входящей", vbCritical)
            Return
        End If

        If Not clsApplicationTypes.ReplaceDecimalSplitter(Me.tbBuyTargetValue) = 0 Then
            Select Case MsgBox("Заменить входящую цену?", vbYesNo)
                Case vbNo
                    Return
            End Select
        End If

        Dim _incur = If(Me.cbInvoceCurrency.SelectedItem Is Nothing, "RUR", Me.cbInvoceCurrency.SelectedItem.name)
        _incomingprice = clsApplicationTypes.CurrencyConvert(_incomingprice, _incur, "RUR")
        _message += Decimal.Round(_incomingprice, 2) & " RUR "
        Select Case DirectCast(cbUom.SelectedItem, RestMS_Client.mdMoySkladExtentions.clsMoyScladManager.strUom).name.ToLower
            Case "кг"
                'рассчитать за 1 кг
                _incomingprice = _incomingprice * (My.Settings.Nakladnye) + clsApplicationTypes.CurrencyConvert(My.Settings.ShippingTariffPerKG, "EUR", "RUR")
                _message += "*" & My.Settings.Nakladnye & " + " & clsApplicationTypes.CurrencyConvert(My.Settings.ShippingTariffPerKG, "EUR", "RUR") & "(шиппинг 1кг) = " & Decimal.Round(_incomingprice, 2) & " RUR"
            Case "шт"
                'нет веса рассчитать за 1шт
                _incomingprice = _incomingprice * (My.Settings.Nakladnye) + clsApplicationTypes.CurrencyConvert(My.Settings.ShippingTariffPerPCS, "EUR", "RUR")
                _message += "*" & My.Settings.Nakladnye & " + " & clsApplicationTypes.CurrencyConvert(My.Settings.ShippingTariffPerPCS, "EUR", "RUR") & "(шиппинг 1шт) = " & Decimal.Round(_incomingprice, 2) & " RUR"
            Case "е"
                'нет веса рассчитать за 1е
                _incomingprice = _incomingprice * (My.Settings.Nakladnye) + clsApplicationTypes.CurrencyConvert(My.Settings.ShippingTariffPerE, "EUR", "RUR")
                _message += "*" & My.Settings.Nakladnye & " + " & clsApplicationTypes.CurrencyConvert(My.Settings.ShippingTariffPerE, "EUR", "RUR") & "(шиппинг 1е) = " & Decimal.Round(_incomingprice, 2) & " RUR"
            Case "гр"
                'рассчитать за 1 грамм
                _incomingprice = _incomingprice * (My.Settings.Nakladnye) + clsApplicationTypes.CurrencyConvert(My.Settings.ShippingTariffPerKG, "EUR", "RUR") / 1000
                _message += "*" & My.Settings.Nakladnye & " + " & clsApplicationTypes.CurrencyConvert(My.Settings.ShippingTariffPerKG, "EUR", "RUR") / 1000 & "(шиппинг 1гр) = " & Decimal.Round(_incomingprice, 2) & " RUR"
            Case Else
                'если добавлена новая ед.измерения
                _incomingprice = _incomingprice * (My.Settings.Nakladnye)
                _message += "*" & My.Settings.Nakladnye & " = " & Decimal.Round(_incomingprice, 2) & " RUR"
        End Select
        Me.cbxSetBuy.Checked = True
        Me.tbBuyTargetValue.Text = Decimal.Round(_incomingprice, 2)
        'цена в рублях
        Me.cbBuyTargetCurrency.SelectedIndex = 1
        MsgBox(_message & ChrW(13) & "*Параметры рассчета задаются в настройках", vbOKOnly)
        'If oWillNewGoodFlag Then
        'End If
    End Sub

    Private Sub tbInvoice_TextChanged(sender As Object, e As EventArgs) Handles tbInvoice.TextChanged

    End Sub

    Private Sub Label1_Click_1(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub tbNumber_TextChanged(sender As Object, e As EventArgs) Handles tbNumber.TextChanged

    End Sub
End Class
