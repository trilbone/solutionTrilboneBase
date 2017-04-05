Imports Service
Imports Service.Agents
Imports Service.clsApplicationTypes
Imports System.Linq
Imports System.Windows.Forms
Imports Service.clsSampleDataManager
Imports System.ComponentModel
''' <summary>
''' снимает с резервации, создает заказ и отгрузку в минимальной версии-только указанные товары + шиппинг, который оплатил клиент
''' </summary>
Public Class ucGoodList

    Private oMsi As iMoySkladDataProvider
    Private oAgent As AUCTIONDATAAGENT
    Private oGoodList As List(Of iMoySkladDataProvider.clsPosition)
    Private oCustomer As Service.iMoySkladDataProvider.clsClientInfo
    Private oOrder As Service.iMoySkladDataProvider.clsOperationInfo
    Private oDemand As Service.iMoySkladDataProvider.clsOperationInfo
    Private oExternalItem As ieBayDataProvider.ieBayTransactionItem
    Dim oDemandApplicable As Boolean

    Public Event GoodListCreated(sender As Object, e As GoodListCreatedEventArgs)
    Private oDocumentDate? As Date

    Public Class GoodListCreatedEventArgs
        Inherits EventArgs
        Property ListCurrency As String
        Property ListAmount As Decimal
        Property GoodList As List(Of iMoySkladDataProvider.clsPosition)
        Property Order As Service.iMoySkladDataProvider.clsOperationInfo
        Property Demand As Service.iMoySkladDataProvider.clsOperationInfo

        ReadOnly Property HasOrder As Boolean
            Get
                If Order Is Nothing Then Return False
                Return True
            End Get
        End Property

        ReadOnly Property HasDemand As Boolean
            Get
                If Demand Is Nothing Then Return False
                Return True
            End Get
        End Property

        ReadOnly Property HasGoods As Boolean
            Get
                If GoodList Is Nothing Then Return False
                If GoodList.Count = 0 Then Return False
                Return True
            End Get
        End Property
    End Class


    Public Sub New()
        ' Добавьте все инициализирующие действия после вызова InitializeComponent().
        InitializeComponent()
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="Agent"></param>
    ''' <param name="msi"></param>
    ''' <param name="Customer"></param>
    ''' <param name="PaymentUUID"></param>
    ''' <param name="PayPalEmailAddress"></param>
    ''' <remarks></remarks>
    Public Sub init(Optional msi As iMoySkladDataProvider = Nothing, Optional agent As AUCTIONDATAAGENT = Nothing, Optional customer As Service.iMoySkladDataProvider.clsClientInfo = Nothing, Optional DocumentDate? As Date = Nothing)
        oMsi = msi
        oAgent = agent
        oCustomer = customer
        oDocumentDate = DocumentDate

        Clear()

        If Not oMsi Is Nothing Then
            Me.cbxCheckInMC.Checked = True
            Me.cbxCheckInMC.Enabled = True
            Me.cbxCreateIfNotExist.Enabled = True
            Me.cbWareList.DataSource = oMsi.GetWarehouseList
            Me.cbWareList.DisplayMember = "Value"
            Me.cbWareList.ValueMember = "UUID"
        Else
            Me.cbWareList.Enabled = False
            Me.btCreateDemand.Enabled = False
            Me.btCreateOrder.Enabled = False
        End If
        'загрузка списка названий
        Me.cbGoodName.DataSource = clsApplicationTypes.MyTreesSystematicaNames
        Me.cbGoodName.SelectedIndex = -1


        'дата отгрузки (план)
        Dim _HandlingTime As Integer = clsApplicationTypes.ReplaceDecimalSplitter(oAgent.GetAgentID("moysklad", "HandlingTime"))

        'прибавить к дате документов планируемое время упаковки
        If DocumentDate Is Nothing Then
            Debug.Fail("дата продажи должна быть задана")
            Me.DemandDate.Value = clsApplicationTypes.GetCurrentTime
        Else
            Me.DemandDate.Value = DocumentDate.Value.AddDays(_HandlingTime)
        End If
        Me.lbToShip.Text = "на ОТГРУЗКУ"
        Me.lbToShip.ForeColor = Drawing.Color.Purple
        Me.oDemandApplicable = False
    End Sub

    ''' <summary>
    ''' выбрать товар из списка в таблицу выбранных. Может добавлять повторяющиеся товары!
    ''' </summary>
    ''' <param name="SampleNumber"></param>
    ''' <remarks></remarks>
    Public Sub SelectGood(SampleNumber As String)
        Dim _res = From c As iMoySkladDataProvider.clsPosition In CType(Me.cbGoodName.DataSource, Array) Where c.ActualCode.ToLower.Equals(SampleNumber.ToLower) Select c

        For Each c In _res
            Me.oGoodList.Add(c)
        Next

        Me.ClsGoodListItemBindingSource.ResetBindings(False)
        Me.btListReady.Focus()
    End Sub

    Public Sub SetFeeGoods(item As ieBayDataProvider.ieBayTransactionItem)
        Me.tbShippingInAmount.Text = clsApplicationTypes.CurrencyConvert(item.ShippingServiceCost.Value, item.ShippingServiceCost.Currency, Me.cbCurrency.Text)
        Me.tbHandlingInAmount.Text = clsApplicationTypes.CurrencyConvert(item.HandlingCost.Value, item.HandlingCost.Currency, Me.cbCurrency.Text)
        Me.oExternalItem = item
    End Sub




    ''' <summary>
    ''' добавить товар в список для заказа по UUID
    ''' </summary>
    ''' <param name="UUID"></param>
    ''' <param name="GoodName"></param>
    ''' <param name="GoodAmount"></param>
    ''' <param name="AmountCurrency"></param>
    ''' <param name="ExternalID"></param>
    ''' <remarks></remarks>
    Public Sub SetAndSelectGoodByUUID(UUID As String, Optional GoodName As String = "", Optional GoodAmount As String = "0", Optional AmountCurrency As String = "RUR", Optional ExternalID As String = "")

        'проверка по МС
        Dim _good = oMsi.FindGoodsByUUID(UUID)

        If _good Is Nothing Then Return

        If Not String.IsNullOrEmpty(GoodName) Then
            _good.AsPosition.GoodName = GoodName
        End If

        If Not String.IsNullOrEmpty(GoodName) Then
            Dim _amount = clsApplicationTypes.ReplaceDecimalSplitter(GoodAmount)
            If _amount > 0 Then
                _good.AsPosition.BasePriceInCurrency = _amount
                _good.AsPosition.currencyName = AmountCurrency
                _good.AsPosition.ExternalID = ExternalID
            End If
        End If
        Me.oGoodList.Add(_good.AsPosition)
        Me.ClsGoodListItemBindingSource.ResetBindings(False)
        Me.btListReady.Focus()
    End Sub


    ''' <summary>
    ''' добавить товар в список для выбора. Потом надо вызвать SelectGood для автодобавления в список заказа. Вернет -1=товар невозможно выбрать, 0=товар найден, но отсутствует в МС, 1=товар найден в МС
    ''' </summary>
    ''' <param name="SampleNumber"></param>
    ''' <param name="CheckingMC"></param>
    ''' <remarks></remarks>
    Public Function ExternalSetGood(SampleNumber As String, CheckingMC As Boolean, MCCreateIfNotExist As Boolean, Optional GoodName As String = "", Optional GoodAmount As String = "0", Optional AmountCurrency As String = "RUR", Optional ExternalID As String = "", Optional ShippingDate? As Date = Nothing) As Integer

        Me.tbSampleNumber.Text = SampleNumber
        Me.cbGoodName.Text = GoodName
        Me.tbGoodAmount.Text = GoodAmount
        Me.cbCurrency.SelectedItem = AmountCurrency


        If Not ShippingDate Is Nothing Then
            'установить дату уже случившейся отгрузки и проставить флаг проведения отгрузки
            Me.DemandDate.Value = ShippingDate.Value
            Me.oDemandApplicable = True
            Me.lbToShip.Text = "ОТГРУЖЕНО"
            Me.lbToShip.ForeColor = Drawing.Color.Orange
        Else
            'предположить дату отгрузки (+handlingTime) и не проводить??? Но тогда при запросе неоформленных нет возможности проверить оформление в МС!!!
            'Решение - ориентироваться по статусу отгрузки НА ОТПРАВКУ, а все отгрузки ПРОВОДИТЬ 
            'т.е. после оформления образец исчезает со склада, но фактически он не отправлен!!!
            'значит надо оставлять в резерве: при оформлении заказа в нем РЕЗЕРВИРУЮТСЯ позиции
            'т.е. при запросе неоформленных надо ловить те, которые стоят не в резерве
            'НО резерв также существует при выставлении на eBay, а значит снятие с этого резерва должно проходить при запросе неоформленных
            'тогда оставшиеся в резерве ждут отправку, а без резерва - подлежат оформлению!
            '21.04.2016

            'предположить дату отгрузки (текущая) И НЕ СТАВИТЬ ПРОВЕДЕНИЯ
            Me.DemandDate.Value = clsApplicationTypes.GetCurrentTime
            Me.oDemandApplicable = False
            Me.lbToShip.Text = "на ОТПРАВКУ"
            Me.lbToShip.ForeColor = Drawing.Color.Purple
        End If

        'проверка кода
        Dim _sm = clsApplicationTypes.clsSampleNumber.CreateFromString(Me.tbSampleNumber.Text)
        If _sm Is Nothing OrElse Not _sm.CodeIsCorrect Then
            clsApplicationTypes.BeepNOT()
            Return -1
        End If
        'код ок
        Dim _result As iMoySkladDataProvider.clsPosition
        Select Case CheckingMC
            Case True
                'проверка по МС
                Dim _good = oMsi.FindGoods("", _sm.ShotCode)

                If _good.Count = 0 Then
                    'товар отсутствует в МС
                    If MCCreateIfNotExist Then
                        'автодобавление
                        'создать товар в МС
                        If String.IsNullOrEmpty(Me.cbGoodName.Text) Then
                            MsgBox("Название отсутствует, введите!", vbCritical, "Добавление карточки в МС")
                            Me.cbGoodName.Focus()
                            Return -1
                        End If
                        If Not clsApplicationTypes.ReplaceDecimalSplitter(Me.tbGoodAmount) > 0 Then
                            MsgBox("Стоимость отсутствует, введите!", vbCritical, "Добавление карточки в МС")
                            Me.tbGoodAmount.Focus()
                            Return -1
                        End If

                        _result = oMsi.AddGood(code:=_sm.ShotCode, name:=Me.cbGoodName.Text, currency:=Me.cbCurrency.Text, IsArticul:=False, price:=clsApplicationTypes.ReplaceDecimalSplitter(Me.tbGoodAmount))
                        _result.ExternalID = ExternalID

                        If _result Is Nothing Then
                            MsgBox("Не удалось создать товар в МС!", vbCritical, "Добавление карточки в МС")
                            Return -1
                        End If
                        Me.cbGoodName.DataSource = {_result}
                        Me.cbGoodName.SelectedIndex = 0
                        'товар теперь есть в МС
                        Return 1
                    Else
                        MsgBox(String.Format("Товара {0} нет в Мой Склад", _sm.ShotCode, "Запрос в МС"), vbInformation)
                        'переход к оформлению отсутствующего в МС
                        GoTo nx
                    End If
                Else
                    'товар присутствует в МС
                    For Each p In _good
                        '''выбор из нескольких, если нашлись
                        ''' пересчет цен в валюту списка
                        ''' 
                        If GoodAmount = "" Then GoodAmount = "0"

                        If GoodAmount > 0 Then
                            'установить переданную цену для ВСЕХ товаров из списка
                            'пересчет позиции
                            p.AsPosition.BasePriceInCurrency = GoodAmount
                        Else
                            'цена не была передана, используем цену МС
                            'пересчитать стоимости в валюту списка
                            If Not p.AsPosition.currencyName Is Nothing AndAlso Not p.AsPosition.currencyName.Equals(Me.cbCurrency.Text) Then
                                'пересчет позиции
                                p.AsPosition.BasePriceInCurrency = clsApplicationTypes.CurrencyConvert(p.AsPosition.BasePriceInCurrency, p.AsPosition.currencyName, Me.cbCurrency.Text)
                            End If
                        End If
                        '--
                        p.AsPosition.ExternalID = ExternalID
                        p.AsPosition.currencyName = Me.cbCurrency.Text
                    Next

                    '---
                    Me.cbGoodName.DataSource = (From c In _good Select c.AsPosition).ToArray
                    '---
                    If _good.Count > 1 Then
                        'товаров по номеру более одного!
                        Me.cbGoodName.BackColor = Drawing.Color.GreenYellow
                    Else
                        Me.cbGoodName.BackColor = Drawing.Color.White
                    End If
                End If
                Me.cbGoodName.SelectedIndex = 0
                'товар найден в МС
                Return 1
            Case Else
                'товар не ищем в МС

nx:
                'позиция без МС
                If String.IsNullOrEmpty(Me.cbGoodName.Text) Then
                    Me.cbGoodName.Text = _sm.AskName
                End If

                If String.IsNullOrEmpty(Me.cbGoodName.Text) Then
                    MsgBox("Название отсутствует, введите!", vbCritical, "Запрос в Trilbone")
                    Me.cbGoodName.Focus()
                    Return -1
                End If
                If Not clsApplicationTypes.ReplaceDecimalSplitter(Me.tbGoodAmount) > 0 Then
                    MsgBox("Стоимость отсутствует, введите!", vbCritical, "Запрос в Trilbone")
                    Me.tbGoodAmount.Focus()
                    Return -1
                End If
                _result = New iMoySkladDataProvider.clsPosition
                With _result
                    .Code = _sm.ShotCode
                    .GoodName = Me.cbGoodName.Text
                    .currencyName = Me.cbCurrency.Text
                    .BasePriceInCurrency = clsApplicationTypes.ReplaceDecimalSplitter(Me.tbGoodAmount)
                    .Discount = 0
                    .ExternalID = ExternalID
                    'НЕТ В МС
                    .goodUuid = ""
                End With
                'по запросу о автосоздании товара в МС
                If MCCreateIfNotExist Then
                    Select Case MsgBox(String.Format("Создать товар с номером {0} в МойСклад вашему по запросу?", _result.Code), vbYesNo)
                        Case MsgBoxResult.Yes
                            'создать товар в МС
                            If Not oMsi.AddGood(code:=_result.Code, name:=_result.GoodName, price:=_result.BasePriceInCurrency, currency:=_result.currencyName, IsArticul:=False) Is Nothing Then
                                Me.cbGoodName.DataSource = {_result}
                                Me.cbGoodName.SelectedIndex = 0
                                'товар присутствует в МС
                                Return 1
                            End If
                    End Select
                End If
                'товар все равно будет оформлятся без МС
                Me.cbGoodName.DataSource = {_result}
                Me.cbGoodName.SelectedIndex = 0
                'товар отсутствует в МС
                Return 0
        End Select


    End Function

    Private Sub Clear()
        oGoodList = New List(Of iMoySkladDataProvider.clsPosition)
        Me.ClsGoodListItemBindingSource.DataSource = oGoodList
        Me.cbxCheckInMC.Checked = False
        Me.cbxCheckInMC.Enabled = False
        Me.cbxCreateIfNotExist.Checked = False
        Me.cbxCreateIfNotExist.Enabled = False
        Me.cbCurrency.SelectedIndex = 1
        Me.tbListAmount.Text = ""
        Me.tbListCount.Text = ""
        Me.DemandDate.Value = Now
        oOrder = Nothing

        If Me.cbWareList.Enabled Then
            Me.cbWareList.SelectedIndex = -1
        End If

    End Sub

    ''' <summary>
    ''' добавить товар в список
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btAddGood_Click(sender As Object, e As EventArgs) Handles btAddGood.Click
        If Me.cbGoodName.SelectedItem Is Nothing Then Return
        If Not TypeOf Me.cbGoodName.SelectedItem Is iMoySkladDataProvider.clsPosition Then Return

        If Not Me.oGoodList.Contains(Me.cbGoodName.SelectedItem) Then
            Me.oGoodList.Add(Me.cbGoodName.SelectedItem)
            Me.ClsGoodListItemBindingSource.ResetBindings(False)
            Me.tbSampleNumber.Focus()
        Else
            MsgBox("Позиция списка уже добавлена", vbInformation)
        End If
    End Sub

    ''' <summary>
    ''' удалить товар из списка
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btRemoveGood_Click(sender As Object, e As EventArgs) Handles btRemoveGood.Click
        Me.oGoodList.Remove(Me.ClsGoodListItemBindingSource.Current)
        Me.ClsGoodListItemBindingSource.ResetBindings(False)
    End Sub

    ''' <summary>
    ''' готово
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btListReady_Click(sender As Object, e As EventArgs) Handles btListReady.Click
        'заказ может быть создан
        'отгрузка может быть создана


        RaiseEvent GoodListCreated(Me, New GoodListCreatedEventArgs With {.GoodList = oGoodList, .ListAmount = clsApplicationTypes.ReplaceDecimalSplitter(Me.tbListAmount), .ListCurrency = Me.cbCurrency.Text, .Order = oOrder, .Demand = oDemand})
    End Sub




    Private Sub btQuery_Click(sender As Object, e As EventArgs) Handles btQuery.Click
        If Me.cbGoodName.SelectedIndex > -1 Then Return

        Select Case Me.ExternalSetGood(Me.tbSampleNumber.Text, Me.cbxCheckInMC.Checked, Me.cbxCreateIfNotExist.Checked, Me.cbGoodName.Text, Me.tbGoodAmount.Text, Me.cbCurrency.Text)
            Case Is < 0
                'товар не добавлен
                clsApplicationTypes.BeepNOT()
            Case 0
                'товар отсутствует в МС
                'блокировать кнопки отгрузки???
                'в обекте будет goodUUID=""
                'форматировать цвет строки??
            Case Is >= 1
                'товар есть в МС
                'TODO запрос списка документов, в которых присутствует товар

        End Select

    End Sub

    Private Sub cbGoodName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbGoodName.SelectedIndexChanged
        If Me.cbGoodName.SelectedItem Is Nothing Then Return
        If Not TypeOf Me.cbGoodName.SelectedItem Is iMoySkladDataProvider.clsPosition Then Return

        Dim _pos As iMoySkladDataProvider.clsPosition = Me.cbGoodName.SelectedItem
        Me.tbSampleNumber.Text = _pos.ActualCode
        Me.tbGoodAmount.Text = _pos.BasePriceInCurrency
    End Sub

    Private Sub tbSampleNumber_GotFocus(sender As Object, e As EventArgs) Handles tbSampleNumber.GotFocus
        ''подгрузить имена из деревьев
        'Me.cbGoodName.DataSource = clsApplicationTypes.MyTreesSystematicaNames

        Me.cbGoodName.SelectedIndex = -1
        Me.tbGoodAmount.Text = ""
        Me.tbSampleNumber.Text = ""
    End Sub

    Private Sub tbGoodAmount_LostFocus(sender As Object, e As EventArgs) Handles tbGoodAmount.LostFocus
        If Not TypeOf Me.cbGoodName.SelectedItem Is iMoySkladDataProvider.clsPosition Then Return

        Dim _amount = clsApplicationTypes.ReplaceDecimalSplitter(Me.tbGoodAmount)
        Dim _pos As iMoySkladDataProvider.clsPosition = Me.cbGoodName.SelectedItem

        If _pos Is Nothing Then Return
        If _pos.BasePriceInCurrency = _amount Then Return

        _pos.BasePriceInCurrency = _amount
        _pos.Discount = 0

    End Sub

    Private Sub tbSampleNumber_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbSampleNumber.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Me.btQuery.Focus()
            Me.btQuery_Click(Me.btQuery, EventArgs.Empty)
        End If
    End Sub




    Private Sub ClsGoodListItemBindingSource_ListChanged(sender As Object, e As ListChangedEventArgs) Handles ClsGoodListItemBindingSource.ListChanged
        If oGoodList Is Nothing Then Return

        Me.tbListAmount.Text = Aggregate c In oGoodList Into Sum(c.ActualPriceInCurrency)
        Me.tbListCount.Text = Me.oGoodList.Count
    End Sub


    Private Sub DataGridView_goods_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView_goods.CellDoubleClick
        Dim _pos As iMoySkladDataProvider.clsPosition = Me.DataGridView_goods.Rows(e.RowIndex).DataBoundItem

        If String.IsNullOrEmpty(_pos.goodUuid) Then
            Select Case MsgBox(String.Format("Создать карточку для {0} в МС?", _pos.ActualCode), vbYesNo, "Добавление в мой склад")
                Case MsgBoxResult.Yes
                    Dim _result = oMsi.AddGood(code:=_pos.ActualCode, name:=_pos.GoodName, currency:=_pos.currencyName, IsArticul:=_pos.IsArticul, price:=_pos.ActualPriceInCurrency)
                    If _result Is Nothing Then
                        MsgBox("Не удалось создать товар в МС!", vbCritical, "Добавление карточки в МС")
                        Return
                    End If
                    Me.oGoodList.Item(e.RowIndex).goodUuid = _result.goodUuid
                    ' Me.ClsGoodListItemBindingSource.ResetBindings(False)
                    BeepYES()
            End Select
        End If
    End Sub


    ''' <summary>
    ''' создать заказ в МС
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btCreateOrder_Click(sender As Object, e As EventArgs) Handles btCreateOrder.Click

        Select Case MsgBox(String.Format("Будет создан новый заказ из {0} позиций", Me.oGoodList.Count), vbYesNo)
            Case MsgBoxResult.No
                Return
        End Select


        Select Case Me.CreateCustomerOrder()
            Case -4
                MsgBox("Список товаров пуст. Заказ не создан.", vbCritical)
            Case -3
                MsgBox("Агент продажи не установлен. Заказ не создан.", vbCritical)
            Case -2
                MsgBox("Мой склад не доступен. Заказ не создан.", vbCritical)
            Case -1
                MsgBox("Клиент-получатель не установлен. Заказ не создан.", vbCritical)
            Case 0
                MsgBox("Внутренняя ошибка Мой Склад. Заказ не создан. Можно попробовать еще раз.", vbCritical)
            Case Is > 0
                If oOrder Is Nothing Then
                    MsgBox("Внутренняя ошибка Мой Склад. Заказ не создан. Можно попробовать еще раз.", vbCritical)
                    Return
                End If
                'заказ создан и в нем поставлен резерв товара
                'снять общий резерв
                For Each g In oGoodList
                    Dim _ReservCustomerOrderUUID = oAgent.GetAgentID("moysklad", "ReservCustomerOrderUUID")
                    If Not _ReservCustomerOrderUUID = "" Then
                        oMsi.EndSampleOnAuction(GoodCode:=g.ActualCode, ReservCustomerOrderUUID:=_ReservCustomerOrderUUID)
                    End If
                Next
                'Select Case MsgBox(String.Format("Заказ {0} успешно создан. Снять образцы с резервации? (Если неуверен - ДА)", oOrder.name, vbInformation), vbYesNo)
                '    Case MsgBoxResult.Yes
                '        'снять резерв
                '        For Each g In oGoodList
                '            Dim _result = Me.EndSampleOnAuction(g.ActualCode)
                '            If String.IsNullOrEmpty(_result) Then
                '                If Not _result.Equals(oAgent.GetAgentID("moysklad", "ShippingIn")) Then
                '                    'с резерва не снят
                '                    MsgBox(String.Format("Образец {0} не снят с резерва. Резервации нет? Или удали из заказа резервации вручную.", g.ActualCode), vbCritical)
                '                End If
                '            Else
                '                MsgBox(String.Format("Образец {0} {1} снят с общей резервации и зарезервирован в заказе", g.ActualCode, g.GoodName), vbInformation)
                '            End If
                '        Next
                'End Select
        End Select
    End Sub

    ''' <summary>
    ''' создает заказ в МС
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CreateCustomerOrder() As Integer
        If oMsi Is Nothing Then Return -2
        If oAgent Is Nothing Then Return -3
        If oCustomer Is Nothing Then Return -1
        If oGoodList.Count = 0 Then Return -4

        Dim _CustomerUUID = oCustomer.UUID
        Dim _MyCompanyUUID = oAgent.GetAgentID("moysklad", "MyCompanyUUID")
        Dim _ProjectUUID = oAgent.GetAgentID("moysklad", "ProjectUUID")
        Dim _CurrencyUUID = oMsi.GetCurrencyUUIDByName(cbCurrency.Text.ToUpper.Trim)
        Dim _Orderstate1UUID = oAgent.GetAgentID("moysklad", "Orderstate1")
        Dim _ShippingInGoodUUID = oAgent.GetAgentID("moysklad", "ShippingIn")
        Dim _ShippingInAmount As Decimal = clsApplicationTypes.ReplaceDecimalSplitter(tbShippingInAmount)
        'добавить товар хендлинга!! - видимо переделать..

        Dim _WokerUUID = clsApplicationTypes.CurrentUser.UserPermission.mcuuid 'связать текущего пользователя приложения с его UUID в МС

        Dim _GoodsAmounts As New List(Of Decimal)
        Dim _GoodsUUIDs As New List(Of String)
        Dim _GoodsQtys As New List(Of Decimal)

        Dim _Description As String = "Заказ для:  "
        For Each g In oGoodList
            If g.goodUuid.Length > 3 Then
                _GoodsUUIDs.Add(g.goodUuid)
                _GoodsAmounts.Add(g.BasePriceInCurrency)
                _GoodsQtys.Add(g.quantity)
                If Not String.IsNullOrEmpty(g.ExternalID) AndAlso g.ExternalID.Length > 0 Then
                    _Description += "eBayID:" & g.ExternalID & ";  "
                Else
                    _Description += g.ActualCode & ";  "
                End If
            Else
                Select Case MsgBox((String.Format("Добавить товар {0} в Мой склад? Его там нет((", g.ActualCode)), vbYesNo)
                    Case MsgBoxResult.Yes
                        Dim _new = oMsi.AddGood(code:=g.Code, name:=g.GoodName, price:=g.BasePriceInCurrency, currency:=g.currencyName, IsArticul:=False)
                        If Not _new Is Nothing Then
                            _GoodsUUIDs.Add(_new.goodUuid)
                            _GoodsAmounts.Add(_new.BasePriceInCurrency)
                            _GoodsQtys.Add(_new.quantity)
                            If _new.ExternalID.Length > 0 Then
                                _Description += "eBayID:" & _new.ExternalID & ";  "
                            Else
                                _Description += _new.ActualCode & ";  "
                            End If
                        Else
                            MsgBox(String.Format("Товар с номером {0} не добавлен в заказ, поскольку мы не смогли создать его в МС", g.ActualCode), vbCritical)
                        End If

                    Case Else
                        MsgBox(String.Format("Товар с номером {0} не добавлен в заказ, поскольку отсутствует в МС", g.ActualCode), vbCritical)
                End Select
            End If

        Next

        Dim _HandlingTime As Integer = clsApplicationTypes.ReplaceDecimalSplitter(oAgent.GetAgentID("moysklad", "HandlingTime"))

        oOrder = oMsi.CreateCustomerOrder(GoodsUUIDs:=_GoodsUUIDs.ToArray, GoodsQtys:=_GoodsQtys.ToArray, GoodsAmounts:=_GoodsAmounts.ToArray, CurrencyUUID:=_CurrencyUUID, CustomerUUID:=_CustomerUUID, MyCompanyUUID:=_MyCompanyUUID, WokerUUID:=_WokerUUID, ProjectUUID:=_ProjectUUID, Orderstate1UUID:=IIf(_Orderstate1UUID = "", Nothing, _Orderstate1UUID), ShippingInGoodUUID:=IIf(_ShippingInGoodUUID = "", Nothing, _ShippingInGoodUUID), ShippingInAmount:=_ShippingInAmount, ShippingInQty:=1, HandlingTime:=_HandlingTime, Description:=_Description, OrderDate:=oDocumentDate)

        If Not oOrder Is Nothing Then
            Return 1
        End If
        Return 0

    End Function

    Private Sub btCreateDemand_Click(sender As Object, e As EventArgs) Handles btCreateDemand.Click
        'убедиться в выборе склада
        If Me.cbWareList.SelectedIndex < 0 Then
            MsgBox("Выбери склад для отгрузки!", vbCritical)
        End If

        Select Case MsgBox(String.Format("Создать отгрузку со склада {0}?", Me.cbWareList.SelectedItem.Value), vbYesNo)
            Case MsgBoxResult.Yes
                Dim _DemandUUID As String = ""
                Select Case Me.CreateDemand(Me.cbWareList.SelectedItem)
                    Case -4
                        MsgBox("Список товаров пуст. Отгрузка не создана.", vbCritical)
                    Case -3
                        MsgBox("Агент продажи не установлен. Отгрузка не созданан.", vbCritical)
                    Case -2
                        MsgBox("Мой склад не доступен. Отгрузка не создана.", vbCritical)
                    Case -1
                        MsgBox("Клиент-получатель не установлен. Отгрузка не создана.", vbCritical)
                    Case 0
                        MsgBox("Внутренняя ошибка Мой Склад. Отгрузка не создана. Можно попробовать еще раз.", vbCritical)
                    Case Is > 0
                        If oDemand Is Nothing Then
                            MsgBox("Внутренняя ошибка Мой Склад. Отгрузка не создана. Можно попробовать еще раз.", vbCritical)
                            Return
                        End If
                        MsgBox(String.Format("Отгрузка {0} успешно создана.", oDemand.name, vbInformation), vbInformation)
                End Select
        End Select
    End Sub

    ''' <summary>
    ''' сформирует отгрузку
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CreateDemand(ware As iMoySkladDataProvider.clsEntity) As Integer
        Dim _CurrencyUUID = oMsi.GetCurrencyUUIDByName(cbCurrency.Text.ToUpper.Trim)
        Dim _GoodsAmounts As New List(Of Decimal)
        Dim _GoodsUUIDs As New List(Of String)
        Dim _GoodsQtys As New List(Of Decimal)

        Dim _Description As String = "Отгрузка для заказа:  "
        If Not oOrder Is Nothing Then
            _Description = "Отгрузка для заказа:  " & oOrder.name & " "
        End If
        For Each g In oGoodList
            If g.goodUuid.Length > 3 Then
                _GoodsUUIDs.Add(g.goodUuid)
                _GoodsAmounts.Add(g.BasePriceInCurrency)
                _GoodsQtys.Add(g.quantity)
                If Not String.IsNullOrEmpty(g.ExternalID) AndAlso g.ExternalID.Length > 0 Then
                    _Description += "; eBayID:" & g.ExternalID & "=" & g.ActualCode & ";  "
                Else
                    '  _Description += "; " & g.ActualCode & ";  "
                End If
            Else
                Select Case MsgBox((String.Format("Добавить товар {0} в Мой склад? Его там нет((", g.ActualCode)), vbYesNo)
                    Case MsgBoxResult.Yes
                        Dim _new = oMsi.AddGood(code:=g.Code, name:=g.GoodName, price:=g.BasePriceInCurrency, currency:=g.currencyName, IsArticul:=False)
                        If Not _new Is Nothing Then
                            _GoodsUUIDs.Add(_new.goodUuid)
                            _GoodsAmounts.Add(_new.BasePriceInCurrency)
                            _GoodsQtys.Add(_new.quantity)
                            If Not String.IsNullOrEmpty(g.ExternalID) AndAlso g.ExternalID.Length > 0 Then
                                _Description += "; eBayID:" & g.ExternalID & "=" & g.ActualCode & ";  "
                            Else
                                '_Description += _new.ActualCode & ";  "
                            End If
                        Else
                            MsgBox(String.Format("Товар с номером {0} не добавлен в отгрузку, поскольку мы не смогли создать его в МС", g.ActualCode), vbCritical)
                        End If

                    Case Else
                        MsgBox(String.Format("Товар с номером {0} не добавлен в отгрузку, поскольку отсутствует в МС", g.ActualCode), vbCritical)
                End Select

                MsgBox(String.Format("Товар с номером {0} не добавлен в отгрузку, поскольку отсутствует в МС", g.ActualCode), vbCritical)
            End If

        Next
        '------------------
        '!!!Надо добавить товар шиппинга и хендлинга
        '------------------
        Dim _HandlingTime As Integer = clsApplicationTypes.ReplaceDecimalSplitter(oAgent.GetAgentID("moysklad", "HandlingTime"))

        Dim _CustomerUUID = oCustomer.UUID
        Dim _StateUUID = oAgent.GetAgentID("moysklad", "Demandstate1")
        If Me.oDemandApplicable Then
            _StateUUID = oAgent.GetAgentID("moysklad", "Demandstate2")
        End If
        Dim _InvocePaymentTypeUUID = oAgent.GetAgentID("moysklad", "InvocePaymentType")
        Dim _MyCompanyUUID = oAgent.GetAgentID("moysklad", "MyCompanyUUID")
        Dim _ProjectUUID = oAgent.GetAgentID("moysklad", "ProjectUUID")

        'создать отгрузку
        oDemand = oMsi.CreateDemand(MyCompanyUUID:=_MyCompanyUUID, CurrencyUUID:=_CurrencyUUID, CustomerUUID:=_CustomerUUID, ProjectUUID:=_ProjectUUID, StateUUID:=IIf(_StateUUID = "", Nothing, _StateUUID), WarehouseUUID:=ware.UUID, GoodsUUIDs:=_GoodsUUIDs.ToArray, GoodsQtys:=_GoodsQtys.ToArray, GoodsAmounts:=_GoodsAmounts.ToArray, InvocePaymentTypeUUID:=IIf(_InvocePaymentTypeUUID = "", Nothing, _InvocePaymentTypeUUID), Description:=_Description, Applicable:=Me.oDemandApplicable, DemandDate:=Me.DemandDate.Value)

        If Not oDemand Is Nothing Then
            Return 1
        End If
        Return 0

    End Function


    ''' <summary>
    ''' снимает образец с аукциона в МС.  Вернет UUID снятого товара.
    ''' </summary>
    ''' <remarks></remarks>
    Private Function EndSampleOnAuction(Code As String) As String
        Dim _ReservCustomerOrderUUID = oAgent.GetAgentID("moysklad", "ReservCustomerOrderUUID")
        Return oMsi.EndSampleOnAuction(GoodCode:=Code, ReservCustomerOrderUUID:=_ReservCustomerOrderUUID)
    End Function
    ''' <summary>
    ''' импорт имеющегося заказа
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btImportOrder_Click(sender As Object, e As EventArgs) Handles btImportOrder.Click

        'загрузить позиции
        If String.IsNullOrEmpty(Me.cbOrderNumber.Text) Then
            Return
        End If

        If Me.cbOrderNumber.DataSource Is Nothing Then
            'ищем заказ по тексту
            Dim _result = oMsi.GetOrderInfo(OrderName:=Me.cbOrderNumber.Text)
            Select Case _result.Count
                Case 0
                    Me.cbOrderNumber.Text = String.Format("Не найден", _result.Count)

                    Me.cbOrderNumber.DataSource = Nothing
                Case Else
                    'Me.cbOrderNumber.Text = String.Format("Заказ({0})", _result.Count)

                    Me.cbOrderNumber.DataSource = _result
                    Me.cbOrderNumber.SelectedIndex = 0
                    MsgBox("Выбери заказ и нажми еще раз на кнопку импорта", vbOKOnly)
                    Return
            End Select
        Else
            'загружаем заказ
            If Me.oGoodList.Count > 0 Then
                Select Case MsgBox(String.Format("В список уже были добавлены товары, сохранить их?"), vbYesNo)
                    Case MsgBoxResult.Yes
                        Me.oGoodList.AddRange(CType(Me.cbOrderNumber.SelectedItem, iMoySkladDataProvider.clsOperationInfo).Position)
                    Case Else
                        Me.oGoodList = (CType(Me.cbOrderNumber.SelectedItem, iMoySkladDataProvider.clsOperationInfo).Position)
                End Select
            End If
            Me.ClsGoodListItemBindingSource.ResetBindings(False)

        End If


    End Sub
    ''' <summary>
    ''' импорт отгрузки
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btImportDemand_Click(sender As Object, e As EventArgs) Handles btImportDemand.Click
        'загрузить позиции
        If String.IsNullOrEmpty(Me.cbDemandNumber.Text) Then
            Return
        End If

        If Me.cbDemandNumber.DataSource Is Nothing Then
            'ищем заказ по тексту
            Dim _result = oMsi.GetDemandInfo(DemandName:=Me.cbDemandNumber.Text)
            Select Case _result.Count
                Case 0
                    Me.cbDemandNumber.Text = String.Format("Не найден", _result.Count)
                    Me.cbDemandNumber.DataSource = Nothing
                Case Else
                    ' Me.cbDemandNumber.Text = String.Format("Отгрузка({0})", _result.Count)
                    Me.cbDemandNumber.DataSource = _result
                    Me.cbDemandNumber.SelectedIndex = 0
                    MsgBox("Выбери отгрузку и нажми еще раз на кнопку импорта", vbOKOnly)
                    Return
            End Select
        Else
            'загружаем отгрузку
            If Me.oGoodList.Count > 0 Then
                Select Case MsgBox(String.Format("В список уже были добавлены товары, сохранить их?"), vbYesNo)
                    Case MsgBoxResult.Yes
                        Me.oGoodList.AddRange(CType(Me.cbDemandNumber.SelectedItem, iMoySkladDataProvider.clsOperationInfo).Position)
                    Case Else
                        Me.oGoodList = (CType(Me.cbDemandNumber.SelectedItem, iMoySkladDataProvider.clsOperationInfo).Position)
                End Select
            End If
            Me.ClsGoodListItemBindingSource.ResetBindings(False)

        End If
    End Sub
    ''' <summary>
    ''' добавит fee в список товаров
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btAddFee_Click(sender As Object, e As EventArgs) Handles btAddFee.Click
        Dim _g As iMoySkladDataProvider.clsPosition
        If Not oExternalItem Is Nothing Then
            'на основании данных агента и переданной структуры добавить fee товары к списку
            For Each _fee In oExternalItem.FeeList
                _g = oMsi.FindGoodsByUUID(_fee.UUID).AsPosition
                With _g
                    If Not _fee.NeedGetFromMC Then
                        .BasePriceInCurrency = _fee.Value
                        .currencyName = _fee.Currency
                    End If
                End With
                Me.oGoodList.Add(_g)
            Next
        Else
            'если доп товары не установлены извне
            If Me.cbCurrency.SelectedItem Is Nothing Then clsApplicationTypes.BeepNOT() : Return

            Dim _shippingINAmount As Decimal = clsApplicationTypes.ReplaceDecimalSplitter(Me.tbShippingInAmount)
            Dim _shippingInUUID As String = oAgent.GetAgentID("moysklad", "ShippingIn")
            Dim _handlingINAmount As Decimal = clsApplicationTypes.ReplaceDecimalSplitter(Me.tbHandlingInAmount)
            Dim _handlingInUUID As String = oAgent.GetAgentID("moysklad", "HandlingIn")
            Dim _currency As String = Me.cbCurrency.SelectedItem

            _g = oMsi.FindGoodsByUUID(_shippingInUUID).AsPosition
            _g.BasePriceInCurrency = clsApplicationTypes.ReplaceDecimalSplitter(Me.tbShippingInAmount)
            _g.currencyName = _currency

            If _g.BasePriceInCurrency > 0 Then
                Me.oGoodList.Add(_g)
            End If

            _g = oMsi.FindGoodsByUUID(_handlingInUUID).AsPosition
            _g.BasePriceInCurrency = clsApplicationTypes.ReplaceDecimalSplitter(Me.tbShippingInAmount)
            _g.currencyName = _currency

            If _g.BasePriceInCurrency > 0 Then
                Me.oGoodList.Add(_g)
            End If

        End If

        Me.ClsGoodListItemBindingSource.ResetBindings(False)

        'обновить список выбора товарами шиппинг по почте и хендлинг
        Dim _glist As New List(Of iMoySkladDataProvider.clsPosition)
        Dim _shippingOutUUID As String = oAgent.GetAgentID("moysklad", "ShippingOut")
        Dim _handlingOutUUID As String = oAgent.GetAgentID("moysklad", "HandlingOut")
        If Not _shippingOutUUID = "" Then
            _g = oMsi.FindGoodsByUUID(_shippingOutUUID).AsPosition
            _glist.Add(_g)
        End If
        If Not _handlingOutUUID = "" Then
            _g = oMsi.FindGoodsByUUID(_handlingOutUUID).AsPosition
            _glist.Add(_g)
        End If
        Me.cbGoodName.DataSource = _glist.ToArray
        Me.cbGoodName.SelectedIndex = 0

        clsApplicationTypes.BeepYES()
    End Sub

    Private Sub lbToShip_Click(sender As Object, e As EventArgs) Handles lbToShip.Click
        If Me.oDemandApplicable Then
            Me.lbToShip.Text = "на Отправку"
            Me.lbToShip.ForeColor = Drawing.Color.Purple
            Me.oDemandApplicable = False
        Else
            Me.lbToShip.Text = "ОТГРУЖЕНО"
            Me.lbToShip.ForeColor = Drawing.Color.Orange
            Me.oDemandApplicable = True
        End If
    End Sub

    ''' <summary>
    ''' отправка посылки
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btSendParcel_Click(sender As Object, e As EventArgs) Handles btSendParcel.Click
        If oDemand Is Nothing Then
            MsgBox("Сначала надо создать отгрузку!", vbCritical)
            Return
        End If

        Dim _ShippingCompanyUUID = oAgent.GetAgentID("moysklad.shippingcompany", "Eesti post")

        Dim _declaration As iMoySkladDataProvider.clsDeclaration_CP71_CN23 = Nothing
        If Me.cbxDeclaration.Checked Then
            'декларация пока автомат
            _declaration = New iMoySkladDataProvider.clsDeclaration_CP71_CN23
            _declaration.content = iMoySkladDataProvider.emDeclaredContent.PACKET_CN23_GIFT
            _declaration.declarationcurrency = "EUR"
            _declaration.Instructionfornondelivery = iMoySkladDataProvider.emInstructionfornondelivery.INSTRUCTION_CODE_RETURN_TO_SENDER
            _declaration.ReturnSpeed = iMoySkladDataProvider.emReturnSpeed.DELICERY_FAILURE_SPEED_BY_AIR
            Dim _qty As String = oOrder.Position.Count
            _qty += "pcs"
            Dim _price As String = oOrder.Position.Count * 9
            _price += "euro"
            _declaration.AddItem("fossils", _qty, "10euro")
        End If

        'пока нет выбора сотрудника - все для Наташи 10371875-86e3-11e4-90a2-8ecb0030abac 
        'отправка eMail об отправке - TODO

        oMsi.AddParcelInfoToDemand(DemandUUID:=oDemand.UUID, WokerUUID:="10371875-86e3-11e4-90a2-8ecb0030abac", ShippingCompanyUUID:=_ShippingCompanyUUID, DeclarationContent:=_declaration)
        Dim _message = String.Format("Посылка поставлена на отправку. {0}", If(cbxDeclaration.Checked, _declaration.ToString, "без декларации"))
        MsgBox(_message, vbInformation)

        Me.lbToShip.Text = "на Отправку"
        Me.lbToShip.ForeColor = Drawing.Color.Purple

        Me.oDemandApplicable = False

        'регистрация в трилбон
        'Dim _result = Me.oReadySampleDBContext.pSLAddDemandUUID(_samplenumber.GetEan13, lbDemandUUID.Tag)
        'If _result > 0 Then
        '    MsgBox("UUID Отгрузки записан в БД", vbInformation)
        'End If
    End Sub
End Class
