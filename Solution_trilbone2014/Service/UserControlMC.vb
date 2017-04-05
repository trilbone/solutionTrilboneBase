Imports Service.clsApplicationTypes
Imports Service
Imports System.Linq
Imports System.Windows.Forms
Public Class UserControlMC
    Private oSampleNumber As clsApplicationTypes.clsSampleNumber
    Private oUSDRate As Decimal
    Private oEURRate As Decimal
    Private oSelectedLocationString As String
    Private oReatilToolTip As New Windows.Forms.ToolTip

    Private Class SplashScreen1
        Inherits System.Windows.Forms.Form
        'Является обязательной для конструктора форм Windows Forms
        Private components As System.ComponentModel.IContainer
        Public Sub New()
            InitializeComponent()
        End Sub
        'Примечание: следующая процедура является обязательной для конструктора форм Windows Forms
        'Для ее изменения используйте конструктор форм Windows Form.  
        'Не изменяйте ее в редакторе исходного кода.
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.SuspendLayout()
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(47, 39)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(160, 13)
            Me.Label1.TabIndex = 0
            Me.Label1.Text = "Загрузка данных. Подождите."
            '
            'SplashScreen1
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BackColor = System.Drawing.SystemColors.Highlight
            Me.ClientSize = New System.Drawing.Size(251, 89)
            Me.ControlBox = False
            Me.Controls.Add(Me.Label1)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "SplashScreen1"
            Me.ShowInTaskbar = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.ResumeLayout(False)
            Me.PerformLayout()
        End Sub
        Friend WithEvents Label1 As System.Windows.Forms.Label

    End Class

    Public Sub New()

        ' Этот вызов является обязательным для конструктора.
        InitializeComponent()

        ' Добавьте все инициализирующие действия после вызова InitializeComponent().
        Me.btOpenMoySklad.Enabled = False
        Me.btSaveInMoySklad.Enabled = False
        'курсы валют
        oUSDRate = clsApplicationTypes.GetRateByCurrencyCB103("USD")
        oEURRate = clsApplicationTypes.GetRateByCurrencyCB103("EUR")

        Me.tbRateUSD.Text = clsApplicationTypes.GetRateByCurrencyCB103("USD")
        Me.tbRateEUR.Text = clsApplicationTypes.GetRateByCurrencyCB103("EUR")

        oSelectedLocationString = "Требуется запрос"

        'разрешения
        If clsApplicationTypes.GetAccess("цена инвойса и закупки") Then
            Me.tbIncomingPrice.Visible = True
            Me.cbCurrencyIncoming.Visible = True
            Me.Label32.Visible = True
            Me.tbRetailCalc.Visible = True
            Me.tbWholesaleCalc.Visible = True
            Me.Label36.Visible = True
        Else
            Me.tbIncomingPrice.Visible = False
            Me.cbCurrencyIncoming.Visible = False
            Me.Label32.Visible = False
            Me.tbRetailCalc.Visible = False
            Me.tbWholesaleCalc.Visible = False
            Me.Label36.Visible = False
        End If
    End Sub
#Region "Открытые методы"

    ''' <summary>
    ''' вернет предварительно выбранную строку склада
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property SelectedLocationString As String
        Get
            Return oSelectedLocationString
        End Get
    End Property


    ''' <summary>
    ''' запросит наличие на складах. В случае, если склад один, то вернет строку из clsSlot.tostring(1), содержащую название склада
    ''' в случае многих складов(-2) или отсутствия(0) вернет Требуется выбор. (-1) если запрос не прошел.
    ''' </summary>
    ''' <param name="SampleNumber"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetWarehouseName(SampleNumber As clsApplicationTypes.clsSampleNumber, ByRef _result As Integer) As String
        'запрос инфо
        Me.SampleNumber = SampleNumber
        btMoySkladAsk_Click(Me.btMoySkladAsk, EventArgs.Empty)
        'запрос складов
        btSearchSklad_Click(Me.btSearchSklad, EventArgs.Empty)
        'проверить строки ответа
        Dim _value As String
        Select Case lbPlaceGood.Items.Count
            Case 0
                Return ("Требуется запрос")
                _result = -1
            Case 1
                lbPlaceGood.SelectedIndex = 0
                _value = lbPlaceGood.SelectedItem
                If Not _value.Contains("Нет на складах") Then
                    'есть на единственном складе - установить по умолчанию
                    Me.btSetWare_Click(Me.btSetWare, EventArgs.Empty)
                    _result = 1
                    Return oSelectedLocationString
                Else
                    Return ("Нет на складе")
                    _result = 0
                End If
            Case Else
                Return ("Требуется выбор")
                _result = -2
        End Select
    End Function


    ''' <summary>
    ''' установит/вернет образец для запроса
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SampleNumber As clsApplicationTypes.clsSampleNumber
        Get
            Return oSampleNumber
        End Get
        Set(value As clsApplicationTypes.clsSampleNumber)
            oSampleNumber = value
            Me.lbPlaceGood.DataSource = Nothing
            Me.lbxSlotCollection.DataSource = Nothing
            Me.btOpenMoySklad.Enabled = False
            Me.btSaveInMoySklad.Enabled = False
            Me.btSearchSklad.Enabled = False
            Me.tbRetailCalc.Text = ""
            Me.tbWholesaleCalc.Text = ""
            Me.ClsApplicationTypes_clsSampleNumber_strGoodInfoBindingSource.DataSource = New List(Of clsApplicationTypes.clsSampleNumber.strGoodInfo)
            Me.ActualNumberTextBox.Refresh()
            Application.DoEvents()
        End Set
    End Property

    ''' <summary>
    ''' название
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SampleName As String
        Get
            Return Me.tbNameFromMoySklad.Text
        End Get
        Set(value As String)
            If Not String.Equals(value, Me.tbNameFromMoySklad.Text) Then
                Me.tbNameFromMoySklad.Text = value
                Me.btSaveInMoySklad.BackColor = Drawing.Color.Red
            End If
        End Set
    End Property

    ''' <summary>
    ''' вес образца
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SampleWeight As Decimal
        Get
            Return clsApplicationTypes.ReplaceDecimalSplitter(Me.tbWeight)
        End Get
        Set(value As Decimal)
            If Not clsApplicationTypes.ReplaceDecimalSplitter(Me.tbWeight) = value Then
                Me.tbWeight.Text = value
                Me.btSaveInMoySklad.BackColor = Drawing.Color.Red
            End If
        End Set
    End Property


    ''' <summary>
    ''' возникает при нажатии кнопки Запомнить цену. Содержит выбранную цену, валюту, курс
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Event PriceSet(sender As Object, e As PriceSetEventArgs)

    ''' <summary>
    ''' возникает, когда образец найден и загружен
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Event SampleLoaded(sender As Object, e As EventArgs)

    ''' <summary>
    ''' возникнет при выборе склада
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Event WarehouseSelected(sender As Object, e As EventArgs)


    Public Class PriceSetEventArgs
        Inherits EventArgs
        Public Property Price As Decimal
        Public Property Currency As String
        Public Property CBRateAtToday As Decimal
        Public Property IncomingPrice As Decimal
    End Class

#End Region

    Private oCurrentGoodInfo As clsApplicationTypes.clsSampleNumber.strGoodInfo



    Private Sub btMoySkladAsk_Click(sender As Object, e As EventArgs) Handles btMoySkladAsk.Click
        If Me.oSampleNumber Is Nothing OrElse Me.oSampleNumber.CodeIsCorrect = False Then
            MsgBox("Необходимо задать правильный номер образца перед запросом", vbCritical)
            Return
        End If

        If clsApplicationTypes.FormMOYSKLAD Is Nothing Then
            Return
        End If

        oSplashscreen.Show()
        Windows.Forms.Application.DoEvents()

        Dim _info = Me.oSampleNumber.GetExtendedInfo(False)
        If _info Is Nothing Then Return
        Dim _msinfo = _info.GoodInfo

        Select Case _msinfo.Count
            Case 0
                oSplashscreen.Hide()
                MsgBox("Информация по образцу не найдена. Номер: " & Me.oSampleNumber.ShotCode, vbCritical)
                Me.ClsApplicationTypes_clsSampleNumber_strGoodInfoBindingSource.DataSource = New List(Of clsApplicationTypes.clsSampleNumber.strGoodInfo)
                Return

            Case Is > 0
                'более одного камня
                Me.ClsApplicationTypes_clsSampleNumber_strGoodInfoBindingSource.DataSource = _msinfo
                Me.btOpenMoySklad.Enabled = True
                Me.btSaveInMoySklad.Enabled = True
                Me.btSearchSklad.Enabled = True
                Me.btOpenMoySklad.Enabled = True
                BeepYES()
                oSplashscreen.Hide()
                RaiseEvent SampleLoaded(Me, EventArgs.Empty)
        End Select
        oSplashscreen.Hide()
        calcwholesale()
    End Sub


    ''' <summary>
    ''' расчеты по ценам
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub calcwholesale()
        Dim _retail As Decimal
        'Dim _whole As Decimal
        'If Decimal.TryParse(clsApplicationTypes.ReplaceDecimalSplitter(Me.tbRetail.Text), _retail) Then
        '    If _retail > 0 Then
        '        _whole = Math.Round(_retail - _retail * 0.3, 2)
        '        Me.tbWholesale.Text = _whole
        '    End If
        'End If

        Dim _incoming As Decimal
        If Decimal.TryParse(ReplaceDecimalSplitter(Me.tbIncomingPrice.Text), _incoming) Then
            If _incoming > 0 Then
                Dim _cin As Decimal = Math.Round((clsApplicationTypes.GetRateByCurrencyCB103(Me.cbCurrency.SelectedItem) * _retail - clsApplicationTypes.GetRateByCurrencyCB103(Me.cbCurrencyIncoming.SelectedItem) * _incoming) / clsApplicationTypes.GetRateByCurrencyCB103(Me.cbCurrency.SelectedItem), 2)
                Me.tbRetailCalc.Text = _cin
                Me.tbWholesaleCalc.Text = Math.Round(_cin - _cin * 0.3, 2)
            End If
        End If

    End Sub

    Private Sub btSetPrice_Click(sender As Object, e As EventArgs) Handles btSetPrice.Click
        Dim _price As Decimal = 0
        Dim _curency As String = ""
        Dim _rate As Decimal = 0

        If rbRetail.Checked Then
            _price = ReplaceDecimalSplitter(Me.tbRetail)
        End If

        If rbeBay.Checked Then
            _price = ReplaceDecimalSplitter(Me.tbeBay)
        End If

        _curency = Me.cbCurrency.Text
        Select Case _curency
            Case "EUR"
                _rate = ReplaceDecimalSplitter(Me.tbRateEUR)
            Case "USD"
                _rate = ReplaceDecimalSplitter(Me.tbRateUSD)
        End Select

        RaiseEvent PriceSet(Me, New PriceSetEventArgs With {.Price = _price, .Currency = _curency, .CBRateAtToday = _rate})
    End Sub
    ''' <summary>
    ''' покажет форму МС. Требует наличия подключенного менеджера
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btOpenMoySklad_Click(sender As Object, e As EventArgs) Handles btOpenMoySklad.Click
        Dim _ask = clsApplicationTypes.DelegateStoreApplicationForm(emFormsList.fmMoySklad)
        If Not _ask Is Nothing Then
            Dim _fm = _ask.Invoke({oSampleNumber.ShotCode})
            If Not _fm Is Nothing Then
                _fm.Show()
            End If
        End If
    End Sub
    ''' <summary>
    ''' сохранить изменение цены в МС
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btCorrectInMoySklad_Click(sender As Object, e As EventArgs) Handles btSaveInMoySklad.Click
        If ClsApplicationTypes_clsSampleNumber_strGoodInfoBindingSource.Current Is Nothing Then Return
        Dim _goodInfo = CType(ClsApplicationTypes_clsSampleNumber_strGoodInfoBindingSource.Current, clsApplicationTypes.clsSampleNumber.strGoodInfo)
        If Not _goodInfo.goodLocationInfo Is Nothing Then
            ' Function(buyPrice As Decimal, buyCurrencyName As String, salePrice As Decimal, saleCurrencyName As String, specificPrice As Decimal, specificPriceCurrencyName As String, specificPriceName As String, uomName As String, goodname As String)
            'Func(Of Decimal, String, Decimal, String, Decimal, String, String, String, String,string)
            Dim _result = _goodInfo.updateGoodDelegate.Invoke(ReplaceDecimalSplitter(Me.tbIncomingPrice), cbCurrencyIncoming.Text, ReplaceDecimalSplitter(Me.tbRetail), cbCurrency.Text, ReplaceDecimalSplitter(Me.tbeBay), cbCurrency.Text, "wholesale", Me.UomNameTextBox.Text, Me.tbNameFromMoySklad.Text, clsApplicationTypes.ReplaceDecimalSplitter(Me.tbWeight))
            Me.btSaveInMoySklad.BackColor = Windows.Forms.TextBox.DefaultBackColor
            MsgBox(_result, vbInformation)

        Else
            MsgBox("Обновление образца невозможно. Отсутствует обьект", vbCritical)
        End If

    End Sub

    Private Sub ClsApplicationTypes_clsSampleNumber_strGoodInfoBindingSource_CurrentChanged(sender As Object, e As EventArgs) Handles ClsApplicationTypes_clsSampleNumber_strGoodInfoBindingSource.CurrentChanged
        Me.calcwholesale()
    End Sub

    Private oGoodInfo As clsApplicationTypes.clsSampleNumber.strGoodInfo
    Private oSplashscreen As Windows.Forms.Form = clsApplicationTypes.SplashScreen

    Private Sub btSearchSklad_Click(sender As Object, e As EventArgs) Handles btSearchSklad.Click
        If ClsApplicationTypes_clsSampleNumber_strGoodInfoBindingSource.Current Is Nothing Then Return
        oSplashscreen.Show()
        Windows.Forms.Application.DoEvents()

        oGoodInfo = CType(ClsApplicationTypes_clsSampleNumber_strGoodInfoBindingSource.Current, clsApplicationTypes.clsSampleNumber.strGoodInfo)

        If Not oGoodInfo.goodLocationInfo Is Nothing Then

            Dim _result = oGoodInfo.goodLocationInfo.Invoke(oGoodInfo)
            Me.lbPlaceGood.DataSource = _result

            If Not _result Is Nothing AndAlso _result.Length > 0 Then
                BeepYES()
            Else
                BeepNOT()
            End If
        Else
            oSplashscreen.Hide()
            MsgBox("Информация об расположении не доступна", vbCritical)
        End If
        oSplashscreen.Hide()
    End Sub


    ''' <summary>
    ''' загрузка списка ячеек
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub lbPlaceGood_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbPlaceGood.SelectedIndexChanged
        If lbPlaceGood.SelectedIndex < 0 Then Return
        If oGoodInfo.goodSlotInfo Is Nothing Then
            Return
        End If
        Me.lbxSlotCollection.DataSource = oGoodInfo.goodSlotInfo(lbPlaceGood.SelectedIndex)
    End Sub

    Private Sub lbxSlotCollection_KeyPress(sender As Object, e As Windows.Forms.KeyPressEventArgs) Handles lbxSlotCollection.KeyPress
        Static _keys As String
        If Char.IsDigit(e.KeyChar) Then
            _keys += e.KeyChar
        End If

        If Asc(e.KeyChar) = 13 Then
            'введен код
            Dim _res = From c As String In lbxSlotCollection.Items Where c.Contains(_keys) Select c

            If _res.Count > 0 Then
                lbxSlotCollection.SelectedItem = _res.FirstOrDefault
                _keys = ""
            End If
        End If
    End Sub
    ''' <summary>
    ''' отображение активной ячейки
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub lbxSlotCollection_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbxSlotCollection.SelectedIndexChanged
        If lbxSlotCollection.SelectedItem Is Nothing Then
            Me.lbActiveSlot.Text = "не выбрана"
            Return
        End If
        Me.lbActiveSlot.Text = lbxSlotCollection.SelectedItem
    End Sub
    ''' <summary>
    ''' запрос размещения
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btPlaceToSlot_Click(sender As Object, e As EventArgs) Handles btPlaceToSlot.Click
        If lbxSlotCollection.SelectedItem Is Nothing Then Return
        If lbPlaceGood.SelectedIndex < 0 Then Return
        If oGoodInfo.goodSlotInfo Is Nothing Then Return
        If oGoodInfo.goodWareInfo Is Nothing Then Return
        'Function(targetSlotName As String, TargetWareName As String) As String
        Dim _index = lbPlaceGood.SelectedIndex
        Dim _result = oGoodInfo.goodToSlot.Invoke(Me.lbActiveSlot.Text, oGoodInfo.goodWareInfo(_index))
        If String.IsNullOrWhiteSpace(_result) Then
            MsgBox("Не удалось создать перемещение", vbCritical)
        Else
            MsgBox(String.Format("Перемещение {0} создано. Проверте перемещение в МС на наличие подсвеченным красным позиций количества, это будут перемещенные/отгруженные позиции без указания ячеек. По возможности их надо исправить.", _result), vbInformation)
        End If
    End Sub

    Private Sub cbIncomingCurrency_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbCurrencyIncoming.SelectedIndexChanged
        If cbCurrencyIncoming.SelectedItem Is Nothing Then Return
        Dim _obj As clsApplicationTypes.clsSampleNumber.strGoodInfo = Me.ClsApplicationTypes_clsSampleNumber_strGoodInfoBindingSource.Current
        If tbRateUSD.Text = "" Then Return
        Dim _rateUSD = Decimal.Parse(ReplaceDecimalSplitter(tbRateUSD.Text))
        Dim _rateEUR = Decimal.Parse(ReplaceDecimalSplitter(tbRateEUR.Text))
        Select Case cbCurrencyIncoming.SelectedItem.ToString
            Case "USD"
                Select Case _obj.BuyCurrency
                    Case "USD"
                        'none
                    Case "EUR"
                        Me.tbIncomingPrice.Text = Math.Round(_obj.BuyPrice * _rateUSD / _rateEUR, 2)
                    Case "RUR"
                        Me.tbIncomingPrice.Text = Math.Round(_obj.BuyPrice / _rateUSD, 2)
                End Select
            Case "EUR"
                Select Case _obj.BuyCurrency
                    Case "USD"
                        Me.tbIncomingPrice.Text = Math.Round(_obj.BuyPrice * _rateEUR / _rateUSD, 2)
                    Case "EUR"
                        'none

                    Case "RUR"
                        Me.tbIncomingPrice.Text = Math.Round(_obj.BuyPrice / _rateEUR, 2)
                End Select

            Case "RUR"
                Select Case _obj.BuyCurrency
                    Case "USD"
                        Me.tbIncomingPrice.Text = Math.Round(_obj.BuyPrice * _rateUSD, 2)
                    Case "EUR"
                        Me.tbIncomingPrice.Text = Math.Round(_obj.BuyPrice * _rateEUR, 2)
                    Case "RUR"
                        'none
                End Select

        End Select
        calcwholesale()
    End Sub
    Private Sub cbCurrencyRetail_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbCurrency.SelectedIndexChanged
        If cbCurrency.SelectedItem Is Nothing Then Return
        Dim _obj As clsApplicationTypes.clsSampleNumber.strGoodInfo = Me.ClsApplicationTypes_clsSampleNumber_strGoodInfoBindingSource.Current
        If tbRateUSD.Text = "" Then Return
        Dim _rateUSD = Decimal.Parse(ReplaceDecimalSplitter(tbRateUSD.Text))
        Dim _rateEUR = Decimal.Parse(ReplaceDecimalSplitter(tbRateEUR.Text))
        Select Case cbCurrency.SelectedItem.ToString
            Case "USD"
                Select Case _obj.RetailCurrency
                    Case "USD"
                        'none
                    Case "EUR"
                        Me.tbRetail.Text = Math.Round(_obj.RetailPrice * _rateUSD / _rateEUR, 2)
                    Case "RUR"
                        Me.tbRetail.Text = Math.Round(_obj.RetailPrice / _rateUSD, 2)
                End Select
            Case "EUR"
                Select Case _obj.RetailCurrency
                    Case "USD"
                        Me.tbRetail.Text = Math.Round(_obj.RetailPrice * _rateEUR / _rateUSD, 2)
                    Case "EUR"
                        'none

                    Case "RUR"
                        Me.tbRetail.Text = Math.Round(_obj.RetailPrice / _rateEUR, 2)
                End Select

            Case "RUR"
                Select Case _obj.RetailCurrency
                    Case "USD"
                        Me.tbRetail.Text = Math.Round(_obj.RetailPrice * _rateUSD, 2)
                    Case "EUR"
                        Me.tbRetail.Text = Math.Round(_obj.RetailPrice * _rateEUR, 2)
                    Case "RUR"
                        'none
                End Select

        End Select
        calcwholesale()
    End Sub

    ''' <summary>
    ''' установить значение выбранного склада
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btSetWare_Click(sender As Object, e As EventArgs) Handles btSetWare.Click
        If Me.lbPlaceGood.SelectedIndex < 0 Then Return
        oSelectedLocationString = lbPlaceGood.SelectedItem
        RaiseEvent WarehouseSelected(Me, EventArgs.Empty)
    End Sub

    ''' <summary>
    ''' перемещение на склад без ячейки
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btPlaceToWare_Click(sender As Object, e As EventArgs) Handles btPlaceToWare.Click
        If lbxSlotCollection.SelectedItem Is Nothing Then Return
        If lbPlaceGood.SelectedIndex < 0 Then Return
        If oGoodInfo.goodSlotInfo Is Nothing Then Return
        If oGoodInfo.goodWareInfo Is Nothing Then Return
        'Function(targetSlotName As String, TargetWareName As String) As String
        Dim _index = lbPlaceGood.SelectedIndex
        Dim _result = oGoodInfo.goodToSlot.Invoke("", oGoodInfo.goodWareInfo(_index))
        If String.IsNullOrWhiteSpace(_result) Then
            MsgBox("Не удалось создать перемещение", vbCritical)
        Else
            MsgBox(String.Format("Перемещение {0} создано. Проверте перемещение в МС на наличие подсвеченным красным позиций количества, это будут перемещенные/отгруженные позиции без указания ячеек. По возможности их надо исправить.", _result), vbInformation)
        End If
    End Sub

    Private Sub tbRetail_MouseEnter(sender As Object, e As EventArgs) Handles tbRetail.MouseEnter
        'отобразить рекомендованную рублевую цену в 4 конца
        If Me.cbCurrency.SelectedItem Is Nothing Then Return
        Dim _currRetail = CType(Me.cbCurrency.SelectedItem, String)
        Dim _rateRetail = clsApplicationTypes.GetRateByCurrencyCB103(_currRetail)
        Dim _retail = clsApplicationTypes.ReplaceDecimalSplitter(tbRetail)

        Dim _out As String = ""

        _out += String.Format("для 30% {0}{1}{2}", Math.Round(_retail / 0.7), clsApplicationTypes.GetCurrencySymbol(_currRetail), ChrW(13))
        _out += String.Format("+30% {0}{1}{2}", Math.Round(_retail * 1.3), clsApplicationTypes.GetCurrencySymbol(_currRetail), ChrW(13))
        _out += String.Format("-30% {0}{1}{2}", Math.Round(_retail * 0.7), clsApplicationTypes.GetCurrencySymbol(_currRetail), ChrW(13))


        If Not _currRetail.ToLower = "rur" Then
            _out += "---рубли-----" & ChrW(13)
            _out += String.Format("цена {0}{1}{2}", Math.Round(_retail * _rateRetail), clsApplicationTypes.GetCurrencySymbol("RUR"), ChrW(13))
            _out += String.Format("для 30% {0}{1}{2}", Math.Round(_retail / 0.7 * _rateRetail), clsApplicationTypes.GetCurrencySymbol("RUR"), ChrW(13))
            _out += String.Format("+30% {0}{1}{2}", Math.Round(_retail * 1.3 * _rateRetail), clsApplicationTypes.GetCurrencySymbol("RUR"), ChrW(13))
            _out += String.Format("-30% {0}{1}{2}", Math.Round(_retail * 0.7 * _rateRetail), clsApplicationTypes.GetCurrencySymbol("RUR"), ChrW(13))
        End If

        Me.oReatilToolTip.ToolTipTitle = "цены:"
        oReatilToolTip.Show(_out, tbRetail)
    End Sub

    Private Sub tbRetail_MouseLeave(sender As Object, e As EventArgs) Handles tbRetail.MouseLeave
        oReatilToolTip.Hide(tbRetail)
    End Sub

    Private Sub tbRetail_TextChanged(sender As Object, e As EventArgs) Handles tbRetail.TextChanged

    End Sub
    ''' <summary>
    ''' статистика для выделенной фразы
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tbNameFromMoySklad_MouseDown(sender As Object, e As MouseEventArgs) Handles tbNameFromMoySklad.MouseDown
        If Not e.Button = Windows.Forms.MouseButtons.Right Then Return
        If Not e.Clicks = 1 Then Return
        If String.IsNullOrEmpty(Me.tbNameFromMoySklad.SelectedText) Then Return
        tbNameFromMoySklad.ContextMenuStrip = Me.ContextMenuStrip1

        Dim _pattern = Me.tbNameFromMoySklad.SelectedText
        Me.ContextMenuStrip1.Items.Clear()

        If String.IsNullOrEmpty(_pattern) Then
            Me.ContextMenuStrip1.Items.Add(clsSellInfo.GetNullPattern)
        Else
            Me.oSplashscreen.Show()
            'получить обьект-источник данных
            Dim _result = clsSellInfo.GetStatistic(_pattern, "", 0)
            Me.oSplashscreen.Hide()
            If _result.Count > 0 Then
                Me.ContextMenuStrip1.Items.AddRange(_result.GetMenuItems)
            Else
                Me.ContextMenuStrip1.Items.Add(clsSellInfo.GetNullStatistic)
            End If
        End If

        '  Me.ContextMenuStrip1.Show(tbNameFromMoySklad.PointToScreen(e.Location))

    End Sub

  
    Private Sub tbNameFromMoySklad_TextChanged(sender As Object, e As EventArgs) Handles tbNameFromMoySklad.TextChanged

    End Sub
End Class
