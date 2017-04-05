Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Public Class uc_createSample
    Private oBuyToolTip As New ToolTip
    Dim oSplashScreen As Form = clsApplicationTypes.SplashScreen
    Private IsOffLine As Boolean = False
    Public Sub New()

        ' Этот вызов является обязательным для конструктора.
        InitializeComponent()

        ' Добавить код инициализации после вызова InitializeComponent().
        'список групп
        If Not clsApplicationTypes.SampleDataObject Is Nothing Then
            Me.cbGroups.Items.AddRange(clsApplicationTypes.SampleDataObject.GetMcOld_groupList.ToArray)
            Me.ToolStripButton1.Enabled = False
            Me.ToolStripButton2.Enabled = False
        End If


    End Sub

    Public Sub Init()
        Me.oSplashScreen.Show()
        'переключимся в офлайн режим
        clsApplicationTypes.SampleDataObject.MColdgoodmapOffLine = True
        IsOffLine = True
        Me.ToolStripButton1.Enabled = True
        Me.ToolStripButton2.Enabled = True
        For Each ctl As Control In Me.Controls
            If ctl.DataBindings.Count > 0 Then
                ctl.DataBindings(0).DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            End If
        Next
        oSplashScreen.Hide()
    End Sub

    ''' <summary>
    ''' получить текущий обьект Sample/ проверить на nothing!!!
    ''' </summary>
    ''' <returns></returns>
    Private ReadOnly Property GetSampleObj As clsApplicationTypes.clsSampleNumber
        Get
            If OldGoodMap_ResultBindingSource.Current Is Nothing Then Return Nothing

            Dim _curr As oldGoodMap_Result = OldGoodMap_ResultBindingSource.Current
            Return _curr.SampleNumberObj
        End Get
    End Property

    Private Sub btQuery_Click(sender As Object, e As EventArgs) Handles btQuery.Click
        'получить данные из БД
        OldGoodMap_ResultBindingSource.DataSource = clsApplicationTypes.SampleDataObject.GetMcOld_result(shotcode:=Me.КодTextBox.Text, partname:=Me.НаименованиеTextBox.Text, groupname:=IIf(Me.cbGroups.SelectedIndex > -1, Me.cbGroups.Text, ""))
        OldGoodMap_ResultBindingSource.Sort = "Код, Артикул"

    End Sub

    Public Event CurrentSampleChanged(sender As Object, e As CurrentSampleChangedEventArgs)

    Public Class CurrentSampleChangedEventArgs
        Inherits EventArgs
        Public Property CurrentSample As clsApplicationTypes.clsSampleNumber

        Public ReadOnly Property IsNothing As Boolean
            Get
                If CurrentSample Is Nothing Then Return True
                Return False
            End Get
        End Property
    End Class

    ''' <summary>
    ''' смена текущего образца
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub OldGoodMap_ResultBindingSource_CurrentItemChanged(sender As Object, e As EventArgs) Handles OldGoodMap_ResultBindingSource.CurrentItemChanged
        'отображение текущего номера
        If Not Me.OldGoodMap_ResultBindingSource.Current Is Nothing Then
            Dim _curr = CType(Me.OldGoodMap_ResultBindingSource.Current, oldGoodMap_Result)
            Me.ToolStripLabel1.Text = String.Format("Редактируем {0}", _curr.ActualCode)
            RaiseEvent CurrentSampleChanged(Me, New CurrentSampleChangedEventArgs With {.CurrentSample = _curr.SampleNumberObj})
            Dim _weight As Decimal
            'вес в кг!!
            If Decimal.TryParse(clsApplicationTypes.ReplaceDecimalSplitter(_curr.Вес), _weight) Then
                'вес в кг!!
                Me.cbWeightUser.SelectedIndex = 1
            End If
        End If

    End Sub

    Private Sub OldGoodMap_ResultBindingSource_AddingNew(sender As Object, e As AddingNewEventArgs) Handles OldGoodMap_ResultBindingSource.AddingNew
        e.NewObject = oldGoodMap_Result.CreateInstance
    End Sub

    Private Sub btGetNewCode_Click(sender As Object, e As EventArgs) Handles btGetNewCode.Click
        'новый код
        Dim _series As String = "802"

        If clsApplicationTypes.GetAccess("Изменение серии добавляемого номера") Then
            _series = InputBox("Введите серию", "Серия для нового номера", _series)
            If _series = "" Then
                MsgBox("Необходимо ввести серию", vbCritical)
                Return
            End If
        End If

        'показат сплеш
        Dim _sp As New SplashScreen1
        _sp.Show()
        Application.DoEvents()
nxnr:
        Dim _res = Service.clsApplicationTypes.DelegatStoreGetNewNumber.Invoke(_series)
        If _res.Length > 0 Then
            'проверка фото
            If Service.clsApplicationTypes.DelegatStoreCheckImages Is Nothing Then
                'проверить фото невозможно
                _sp.Hide()
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
                        _sp.Hide()
                        MsgBox("Номер неверен, внутренняя ошибка!", vbCritical)
                        Return
                    Case -2
                        'нет доступа к БД, внутренняя ошибка
                        _sp.Hide()
                        MsgBox("Нет доступа к БД, внутренняя ошибка!", vbCritical)
                        Return
                End Select
            End If
            _sp.Hide()
            'номер получен
            OldGoodMap_ResultBindingSource.CurrencyManager.AddNew()
            Me.КодTextBox.Focus()
            Me.КодTextBox.Text = _res

            My.Computer.Clipboard.SetText(_res)
            clsApplicationTypes.BeepYES()
            ' Me.btSearchInfo_Click(sender, e)
        Else
            _sp.Hide()
            MsgBox("Не удалось получить номер, внутренняя ошибка!", vbCritical)
        End If




    End Sub

    Private Sub btMoveToArticul_Click(sender As Object, e As EventArgs) Handles btMoveToArticul.Click
        Me.АртикулTextBox.Text = Me.КодTextBox.Text
        Me.КодTextBox.Text = ""
    End Sub

    Private Sub btMoveToCode_Click(sender As Object, e As EventArgs) Handles btMoveToCode.Click
        Me.КодTextBox.Text = Me.АртикулTextBox.Text
        Me.АртикулTextBox.Text = ""
    End Sub

    Private Sub btGetNameFromDB_Click(sender As Object, e As EventArgs) Handles btGetNameFromDB.Click
        Dim _obj = Me.GetSampleObj
        If _obj Is Nothing Then Exit Sub
        Me.НаименованиеTextBox.Text = _obj.AskName
    End Sub
    ''' <summary>
    ''' рассчитать ЗП
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btCalculateSalary_Click(sender As Object, e As EventArgs) Handles btCalculateSalary.Click
        Me.tbctlPreparator.SelectedTab = tpPreparator_Calculate
        Me.UC_preparator_calc1.SetData(RawNumber:=Me.Производственный_номер_или_EAN13TextBox.Text, PreparatorString:=Me.Препараторы_и_времяTextBox.Text, MainPreparator:=Ответственный_ПрепараторTextBox.Text)
    End Sub

    ''' <summary>
    ''' рассчет зарплаты окончен
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub PrepCalc_eventhandler(sender As Object, e As UC_preparator_calc.SalaryCalculatedEventArgs) Handles UC_preparator_calc1.SalaryCalculated
        Me.Полная_стоимость_препарации_в_рубляхTextBox.Text = e.Salary
        Me.Время_препарации_в_часах__общее_TextBox.Text = e.TotalHour
        Me.Производственный_номер_или_EAN13TextBox.Text = e.RawNumber
        Me.Ответственный_ПрепараторTextBox.Text = e.MainPrep
        Me.Препараторы_и_времяTextBox.Text = e.PrepTimeBox
        clsApplicationTypes.BeepYES()
    End Sub


    Private Sub btClearAll_Click(sender As Object, e As EventArgs) Handles btClearAll.Click
        Me.OldGoodMap_ResultBindingSource.Clear()
        Me.ToolStripLabel1.Text = "Запрос? Новый?"

        Me.cbGroups.SelectedIndex = -1
        Me.cbUomUser.SelectedIndex = -1
        Me.cbWeightUser.SelectedIndex = -1

        Me.КодTextBox.Focus()
    End Sub

    ''' <summary>
    ''' сохранить текущую запись
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click

        '---
        Me.btQuery.Focus()
        Dim _item As oldGoodMap_Result = Me.OldGoodMap_ResultBindingSource.Current

        If Me.IsOffLine Then
            Dim _res = clsApplicationTypes.SampleDataObject.SetMcOld_row(_item)
            If _res > 0 Then
                clsApplicationTypes.BeepYES()
            Else
                clsApplicationTypes.BeepNOT()
            End If
        Else
            clsApplicationTypes.BeepNOT()
        End If

    End Sub
    ''' <summary>
    ''' сохранить на сервере
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        If IsOffLine Then
            Dim _res = clsApplicationTypes.SampleDataObject.SaveMcOld_row
            If _res > 0 Then
                'отметить все текущие строки обновленными
                For Each t As oldGoodMap_Result In Me.OldGoodMap_ResultBindingSource
                    t.IsNew = False
                Next
                clsApplicationTypes.BeepYES()
            Else
                clsApplicationTypes.BeepNOT()
            End If
        Else
            clsApplicationTypes.BeepNOT()
        End If

    End Sub


#Region "подсказки"
    Private Sub ИнвойсTextBox_MouseHover(sender As Object, e As EventArgs) Handles ИнвойсTextBox.MouseHover
        'пересчет по курсу
        Dim _currBox = Me.Валюта__Инвойс_ComboBox
        '-------------------
        Dim _visibleCurr As String = _currBox.SelectedItem

        If String.IsNullOrEmpty(_visibleCurr.Trim) Then
            Return
        End If

        Dim _out As String = ""

        Select Case _visibleCurr.Trim.ToUpper
            Case "RUR"
                _out += String.Format("<EUR> {0}{1}<USD> {2}", clsApplicationTypes.CurrencyConvert(clsApplicationTypes.ReplaceDecimalSplitter(sender), _visibleCurr, "EUR"), ChrW(13), clsApplicationTypes.CurrencyConvert(clsApplicationTypes.ReplaceDecimalSplitter(sender), _visibleCurr, "USD"))
            Case "EUR"
                _out += String.Format("<RUR> {0}{1}<USD> {2}", clsApplicationTypes.CurrencyConvert(clsApplicationTypes.ReplaceDecimalSplitter(sender), _visibleCurr, "RUR"), ChrW(13), clsApplicationTypes.CurrencyConvert(clsApplicationTypes.ReplaceDecimalSplitter(sender), _visibleCurr, "USD"))
            Case "USD"
                _out += String.Format("<RUR> {0}{1}<EUR> {2}", clsApplicationTypes.CurrencyConvert(clsApplicationTypes.ReplaceDecimalSplitter(sender), _visibleCurr, "RUR"), ChrW(13), clsApplicationTypes.CurrencyConvert(clsApplicationTypes.ReplaceDecimalSplitter(sender), _visibleCurr, "EUR"))
        End Select


        oBuyToolTip.ToolTipTitle = "по ЦБ"
        oBuyToolTip.Show(_out, sender)
    End Sub

    Private Sub ИнвойсTextBox_MouseLeave(sender As Object, e As EventArgs) Handles ИнвойсTextBox.MouseLeave
        oBuyToolTip.Hide(sender)
    End Sub



    Private Sub Закупочная_ценаTextBox_MouseHover(sender As Object, e As EventArgs) Handles Закупочная_ценаTextBox.MouseHover
        'пересчет по курсу
        Dim _currBox = Me.Валюта__Закупочная_цена_ComboBox
        '-------------------
        Dim _visibleCurr As String = _currBox.SelectedItem

        If String.IsNullOrEmpty(_visibleCurr.Trim) Then
            Return
        End If

        Dim _out As String = ""

        Select Case _visibleCurr.Trim.ToUpper
            Case "RUR"
                _out += String.Format("<EUR> {0}{1}<USD> {2}", clsApplicationTypes.CurrencyConvert(clsApplicationTypes.ReplaceDecimalSplitter(sender), _visibleCurr, "EUR"), ChrW(13), clsApplicationTypes.CurrencyConvert(clsApplicationTypes.ReplaceDecimalSplitter(sender), _visibleCurr, "USD"))
            Case "EUR"
                _out += String.Format("<RUR> {0}{1}<USD> {2}", clsApplicationTypes.CurrencyConvert(clsApplicationTypes.ReplaceDecimalSplitter(sender), _visibleCurr, "RUR"), ChrW(13), clsApplicationTypes.CurrencyConvert(clsApplicationTypes.ReplaceDecimalSplitter(sender), _visibleCurr, "USD"))
            Case "USD"
                _out += String.Format("<RUR> {0}{1}<EUR> {2}", clsApplicationTypes.CurrencyConvert(clsApplicationTypes.ReplaceDecimalSplitter(sender), _visibleCurr, "RUR"), ChrW(13), clsApplicationTypes.CurrencyConvert(clsApplicationTypes.ReplaceDecimalSplitter(sender), _visibleCurr, "EUR"))
        End Select


        oBuyToolTip.ToolTipTitle = "по ЦБ"
        oBuyToolTip.Show(_out, sender)
    End Sub

    Private Sub Закупочная_ценаTextBox_MouseLeave(sender As Object, e As EventArgs) Handles Закупочная_ценаTextBox.MouseLeave
        oBuyToolTip.Hide(sender)
    End Sub



    Private Sub Полная_стоимость_закупки_в_рубляхTextBox_MouseHover(sender As Object, e As EventArgs) Handles Полная_стоимость_закупки_в_рубляхTextBox.MouseHover
        'пересчет по курсу


        Dim _out As String = String.Format("<EUR> {0}{1}<USD> {2}", clsApplicationTypes.CurrencyConvert(clsApplicationTypes.ReplaceDecimalSplitter(sender), "RUR", "EUR"), ChrW(13), clsApplicationTypes.CurrencyConvert(clsApplicationTypes.ReplaceDecimalSplitter(sender), "RUR", "USD"))


        oBuyToolTip.ToolTipTitle = "по ЦБ"
        oBuyToolTip.Show(_out, sender)
    End Sub

    Private Sub Полная_стоимость_закупки_в_рубляхTextBox_MouseLeave(sender As Object, e As EventArgs) Handles Полная_стоимость_закупки_в_рубляхTextBox.MouseLeave
        oBuyToolTip.Hide(sender)
    End Sub



    Private Sub Розничная_цена_в_магазинеTextBox_MouseHover(sender As Object, e As EventArgs) Handles Розничная_цена_в_магазинеTextBox.MouseHover
        'пересчет по курсу
        Dim _currBox = Me.Валюта__Розничная_цена_в_магазине_ComboBox
        '-------------------
        Dim _visibleCurr As String = _currBox.SelectedItem

        If String.IsNullOrEmpty(_visibleCurr.Trim) Then
            Return
        End If

        Dim _out As String = ""

        Select Case _visibleCurr.Trim.ToUpper
            Case "RUR"
                _out += String.Format("<EUR> {0}{1}<USD> {2}", clsApplicationTypes.CurrencyConvert(clsApplicationTypes.ReplaceDecimalSplitter(sender), _visibleCurr, "EUR"), ChrW(13), clsApplicationTypes.CurrencyConvert(clsApplicationTypes.ReplaceDecimalSplitter(sender), _visibleCurr, "USD"))
            Case "EUR"
                _out += String.Format("<RUR> {0}{1}<USD> {2}", clsApplicationTypes.CurrencyConvert(clsApplicationTypes.ReplaceDecimalSplitter(sender), _visibleCurr, "RUR"), ChrW(13), clsApplicationTypes.CurrencyConvert(clsApplicationTypes.ReplaceDecimalSplitter(sender), _visibleCurr, "USD"))
            Case "USD"
                _out += String.Format("<RUR> {0}{1}<EUR> {2}", clsApplicationTypes.CurrencyConvert(clsApplicationTypes.ReplaceDecimalSplitter(sender), _visibleCurr, "RUR"), ChrW(13), clsApplicationTypes.CurrencyConvert(clsApplicationTypes.ReplaceDecimalSplitter(sender), _visibleCurr, "EUR"))
        End Select


        oBuyToolTip.ToolTipTitle = "по ЦБ"
        oBuyToolTip.Show(_out, sender)
    End Sub

    Private Sub Розничная_цена_в_магазинеTextBox_MouseLeave(sender As Object, e As EventArgs) Handles Розничная_цена_в_магазинеTextBox.MouseLeave
        oBuyToolTip.Hide(sender)
    End Sub



    Private Sub Розничная_в_офисеTextBox_MouseHover(sender As Object, e As EventArgs) Handles Розничная_в_офисеTextBox.MouseHover
        'пересчет по курсу
        Dim _currBox = Me.Валюта__Розничная_в_офисе_ComboBox
        '-------------------
        Dim _visibleCurr As String = _currBox.SelectedItem

        If String.IsNullOrEmpty(_visibleCurr.Trim) Then
            Return
        End If

        Dim _out As String = ""

        Select Case _visibleCurr.Trim.ToUpper
            Case "RUR"
                _out += String.Format("<EUR> {0}{1}<USD> {2}", clsApplicationTypes.CurrencyConvert(clsApplicationTypes.ReplaceDecimalSplitter(sender), _visibleCurr, "EUR"), ChrW(13), clsApplicationTypes.CurrencyConvert(clsApplicationTypes.ReplaceDecimalSplitter(sender), _visibleCurr, "USD"))
            Case "EUR"
                _out += String.Format("<RUR> {0}{1}<USD> {2}", clsApplicationTypes.CurrencyConvert(clsApplicationTypes.ReplaceDecimalSplitter(sender), _visibleCurr, "RUR"), ChrW(13), clsApplicationTypes.CurrencyConvert(clsApplicationTypes.ReplaceDecimalSplitter(sender), _visibleCurr, "USD"))
            Case "USD"
                _out += String.Format("<RUR> {0}{1}<EUR> {2}", clsApplicationTypes.CurrencyConvert(clsApplicationTypes.ReplaceDecimalSplitter(sender), _visibleCurr, "RUR"), ChrW(13), clsApplicationTypes.CurrencyConvert(clsApplicationTypes.ReplaceDecimalSplitter(sender), _visibleCurr, "EUR"))
        End Select


        oBuyToolTip.ToolTipTitle = "по ЦБ"
        oBuyToolTip.Show(_out, sender)
    End Sub

    Private Sub Розничная_в_офисеTextBox_MouseLeave(sender As Object, e As EventArgs) Handles Розничная_в_офисеTextBox.MouseLeave
        oBuyToolTip.Hide(sender)
    End Sub



    Private Sub Буржуи_на_выставкеTextBox_MouseHover(sender As Object, e As EventArgs) Handles Буржуи_на_выставкеTextBox.MouseHover
        'пересчет по курсу
        Dim _currBox = Me.Валюта__Буржуи_на_выставке_ComboBox
        '-------------------
        Dim _visibleCurr As String = _currBox.SelectedItem

        If String.IsNullOrEmpty(_visibleCurr.Trim) Then
            Return
        End If

        Dim _out As String = ""

        Select Case _visibleCurr.Trim.ToUpper
            Case "RUR"
                _out += String.Format("<EUR> {0}{1}<USD> {2}", clsApplicationTypes.CurrencyConvert(clsApplicationTypes.ReplaceDecimalSplitter(sender), _visibleCurr, "EUR"), ChrW(13), clsApplicationTypes.CurrencyConvert(clsApplicationTypes.ReplaceDecimalSplitter(sender), _visibleCurr, "USD"))
            Case "EUR"
                _out += String.Format("<RUR> {0}{1}<USD> {2}", clsApplicationTypes.CurrencyConvert(clsApplicationTypes.ReplaceDecimalSplitter(sender), _visibleCurr, "RUR"), ChrW(13), clsApplicationTypes.CurrencyConvert(clsApplicationTypes.ReplaceDecimalSplitter(sender), _visibleCurr, "USD"))
            Case "USD"
                _out += String.Format("<RUR> {0}{1}<EUR> {2}", clsApplicationTypes.CurrencyConvert(clsApplicationTypes.ReplaceDecimalSplitter(sender), _visibleCurr, "RUR"), ChrW(13), clsApplicationTypes.CurrencyConvert(clsApplicationTypes.ReplaceDecimalSplitter(sender), _visibleCurr, "EUR"))
        End Select


        oBuyToolTip.ToolTipTitle = "по ЦБ"
        oBuyToolTip.Show(_out, sender)
    End Sub

    Private Sub Буржуи_на_выставкеTextBox_MouseLeave(sender As Object, e As EventArgs) Handles Буржуи_на_выставкеTextBox.MouseLeave
        oBuyToolTip.Hide(sender)
    End Sub

    Private Sub ВесTextBox_TextChanged(sender As Object, e As EventArgs) Handles ВесTextBox.TextChanged

    End Sub
    ''' <summary>
    ''' пересчет веса
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub ВесTextBox_MouseHover(sender As Object, e As EventArgs) Handles ВесTextBox.MouseHover
        Dim _currBox = Me.cbWeightUser
        '-------------------
        Dim _visibleCurr As String = _currBox.SelectedItem

        If String.IsNullOrEmpty(_visibleCurr.Trim) Then
            Return
        End If

        Dim _out As String = String.Format("{0} кг", clsApplicationTypes.WeightConvert(sender.text, _visibleCurr))

        oBuyToolTip.ToolTipTitle = "вес в кг"
        oBuyToolTip.Show(_out, sender)
    End Sub

    Private Sub ВесTextBox_MouseLeave(sender As Object, e As EventArgs) Handles ВесTextBox.MouseLeave
        oBuyToolTip.Hide(sender)
    End Sub
    Private Sub ПеревозкаTextBox_MouseHover(sender As Object, e As EventArgs) Handles ПеревозкаTextBox.MouseHover
        'пересчет по курсу
        Dim _currBox = Me.ПеревозкаВалютаComboBox
        '-------------------
        Dim _visibleCurr As String = _currBox.SelectedItem

        If String.IsNullOrEmpty(_visibleCurr.Trim) Then
            Return
        End If

        Dim _out As String = ""

        Select Case _visibleCurr.Trim.ToUpper
            Case "RUR"
                _out += String.Format("<EUR> {0}{1}<USD> {2}", clsApplicationTypes.CurrencyConvert(clsApplicationTypes.ReplaceDecimalSplitter(sender), _visibleCurr, "EUR"), ChrW(13), clsApplicationTypes.CurrencyConvert(clsApplicationTypes.ReplaceDecimalSplitter(sender), _visibleCurr, "USD"))
            Case "EUR"
                _out += String.Format("<RUR> {0}{1}<USD> {2}", clsApplicationTypes.CurrencyConvert(clsApplicationTypes.ReplaceDecimalSplitter(sender), _visibleCurr, "RUR"), ChrW(13), clsApplicationTypes.CurrencyConvert(clsApplicationTypes.ReplaceDecimalSplitter(sender), _visibleCurr, "USD"))
            Case "USD"
                _out += String.Format("<RUR> {0}{1}<EUR> {2}", clsApplicationTypes.CurrencyConvert(clsApplicationTypes.ReplaceDecimalSplitter(sender), _visibleCurr, "RUR"), ChrW(13), clsApplicationTypes.CurrencyConvert(clsApplicationTypes.ReplaceDecimalSplitter(sender), _visibleCurr, "EUR"))
        End Select


        oBuyToolTip.ToolTipTitle = "по ЦБ"
        oBuyToolTip.Show(_out, sender)
    End Sub

    Private Sub ПеревозкаTextBox_MouseLeave(sender As Object, e As EventArgs) Handles ПеревозкаTextBox.MouseLeave
        oBuyToolTip.Hide(sender)
    End Sub


    Private Sub EBAYTextBox_MouseHover(sender As Object, e As EventArgs) Handles EBAYTextBox.MouseHover
        'пересчет по курсу
        Dim _currBox = Me.Валюта__EBAY_ComboBox
        '-------------------
        Dim _visibleCurr As String = _currBox.SelectedItem

        If String.IsNullOrEmpty(_visibleCurr.Trim) Then
            Return
        End If

        Dim _out As String = ""

        Select Case _visibleCurr.Trim.ToUpper
            Case "RUR"
                _out += String.Format("<EUR> {0}{1}<USD> {2}", clsApplicationTypes.CurrencyConvert(clsApplicationTypes.ReplaceDecimalSplitter(sender), _visibleCurr, "EUR"), ChrW(13), clsApplicationTypes.CurrencyConvert(clsApplicationTypes.ReplaceDecimalSplitter(sender), _visibleCurr, "USD"))
            Case "EUR"
                _out += String.Format("<RUR> {0}{1}<USD> {2}", clsApplicationTypes.CurrencyConvert(clsApplicationTypes.ReplaceDecimalSplitter(sender), _visibleCurr, "RUR"), ChrW(13), clsApplicationTypes.CurrencyConvert(clsApplicationTypes.ReplaceDecimalSplitter(sender), _visibleCurr, "USD"))
            Case "USD"
                _out += String.Format("<RUR> {0}{1}<EUR> {2}", clsApplicationTypes.CurrencyConvert(clsApplicationTypes.ReplaceDecimalSplitter(sender), _visibleCurr, "RUR"), ChrW(13), clsApplicationTypes.CurrencyConvert(clsApplicationTypes.ReplaceDecimalSplitter(sender), _visibleCurr, "EUR"))
        End Select


        oBuyToolTip.ToolTipTitle = "по ЦБ"
        oBuyToolTip.Show(_out, sender)
    End Sub

    Private Sub EBAYTextBox_MouseLeave(sender As Object, e As EventArgs) Handles EBAYTextBox.MouseLeave
        oBuyToolTip.Hide(sender)
    End Sub
#End Region

    ''' <summary>
    ''' проверка ввода чисел
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub TextBox_Validating(sender As Object, e As CancelEventArgs) Handles ВесTextBox.Validating, Единица_измеренияTextBox.Validating, Время_препарации_в_часах__общее_TextBox.Validating, Полная_стоимость_закупки_в_рубляхTextBox.Validating, ИнвойсTextBox.Validating, Закупочная_ценаTextBox.Validating, Полная_стоимость_закупки_в_рубляхTextBox.Validating, Розничная_цена_в_магазинеTextBox.Validating, Розничная_в_офисеTextBox.Validating, Буржуи_на_выставкеTextBox.Validating, EBAYTextBox.Validating, ПеревозкаTextBox.Validating, НакладныеTextBox.Validating
        If sender.Text = "" Then sender.Text = "0" : Return
        If sender.Text = " " Then sender.Text = "0" : Return
        sender.text = clsApplicationTypes.ReplaceDecimalSplitter(sender.text)
        sender.backcolor = Color.FromKnownColor(KnownColor.Window)

        Select Case sender.name
            'Case "tbQty"
            '    If tbQty.Text = "" Or tbQty.Text = "" Or tbQty.Text = "0" Then Return
            '    If Not Me.cbxWithoutSlot.Checked Then
            '        'задаст кол-во в выбранной ячейке
            '        Dim _currSlot As clsGoodLocation.clsSlot = Me.SlotGoodBindingSource.Current
            '        If _currSlot Is Nothing Then Return
            '        If Not Decimal.TryParse(Me.tbQty.Text, _currSlot.Qty) Then
            '            MsgBox("Не удалось распознать количество", vbCritical)
            '            Return
            '        End If
            '    End If
            '    'Me.LocateGood(Me.oCurrentGood)
            Case "ВесTextBox"
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

#Region "DIGIKEY"
    Private ReadOnly Property GetDigiKey As Object
        Get
            Return Service.clsApplicationTypes.GetDigiKeyBoardForm
        End Get
    End Property

    Private Sub КодLabel_Click(sender As Object, e As EventArgs)
        If Not GetDigiKey Is Nothing Then
            GetDigiKey.connect(Me.КодTextBox)
        End If
    End Sub

    Private Sub АртикулLabel_Click(sender As Object, e As EventArgs)
        If Not GetDigiKey Is Nothing Then
            GetDigiKey.connect(Me.АртикулTextBox)
        End If
    End Sub

    Private Sub Единица_измеренияLabel_Click(sender As Object, e As EventArgs)
        If Not GetDigiKey Is Nothing Then
            GetDigiKey.connect(Me.Единица_измеренияTextBox)
        End If
    End Sub

    Private Sub ВесLabel_Click(sender As Object, e As EventArgs) Handles ВесLabel.Click
        If Not GetDigiKey Is Nothing Then
            GetDigiKey.connect(Me.ВесTextBox)
        End If
    End Sub

    Private Sub Экспедиционный_закупочный_номерLabel_Click(sender As Object, e As EventArgs)
        If Not GetDigiKey Is Nothing Then
            GetDigiKey.connect(Me.Экспедиционный_закупочный_номерTextBox)
        End If
    End Sub

    Private Sub Производственный_номер_или_EAN13Label_Click(sender As Object, e As EventArgs)
        If Not GetDigiKey Is Nothing Then
            GetDigiKey.connect(Me.Производственный_номер_или_EAN13TextBox)
        End If
    End Sub

    Private Sub Время_препарации_в_часах__общее_Label_Click(sender As Object, e As EventArgs)
        If Not GetDigiKey Is Nothing Then
            GetDigiKey.connect(Me.Время_препарации_в_часах__общее_TextBox)
        End If
    End Sub

    Private Sub Полная_стоимость_препарации_в_рубляхLabel_Click(sender As Object, e As EventArgs)
        If Not GetDigiKey Is Nothing Then
            GetDigiKey.connect(Me.Полная_стоимость_препарации_в_рубляхTextBox)
        End If
    End Sub

    Private Sub ИнвойсLabel_Click(sender As Object, e As EventArgs)
        If Not GetDigiKey Is Nothing Then
            GetDigiKey.connect(Me.ИнвойсTextBox)
        End If
    End Sub

    Private Sub Закупочная_ценаLabel_Click(sender As Object, e As EventArgs)
        If Not GetDigiKey Is Nothing Then
            GetDigiKey.connect(Me.Закупочная_ценаTextBox)
        End If
    End Sub

    Private Sub Полная_стоимость_закупки_в_рубляхLabel_Click(sender As Object, e As EventArgs)
        If Not GetDigiKey Is Nothing Then
            GetDigiKey.connect(Me.Полная_стоимость_закупки_в_рубляхTextBox)
        End If
    End Sub

    Private Sub Розничная_цена_в_магазинеLabel_Click(sender As Object, e As EventArgs)
        If Not GetDigiKey Is Nothing Then
            GetDigiKey.connect(Me.Розничная_цена_в_магазинеTextBox)
        End If
    End Sub

    Private Sub Розничная_в_офисеLabel_Click(sender As Object, e As EventArgs)
        If Not GetDigiKey Is Nothing Then
            GetDigiKey.connect(Me.Розничная_в_офисеTextBox)
        End If
    End Sub

    Private Sub Буржуи_на_выставкеLabel_Click(sender As Object, e As EventArgs)
        If Not GetDigiKey Is Nothing Then
            GetDigiKey.connect(Me.Буржуи_на_выставкеTextBox)
        End If
    End Sub
    Private Sub Label3_Click(sender As Object, e As EventArgs)
        If Not GetDigiKey Is Nothing Then
            GetDigiKey.connect(Me.ПеревозкаTextBox)
        End If
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        If Not GetDigiKey Is Nothing Then
            GetDigiKey.connect(Me.ПеревозкаЗаКГTextBox)
        End If
    End Sub

    Private Sub EBAYLabel_Click(sender As Object, e As EventArgs)
        If Not GetDigiKey Is Nothing Then
            GetDigiKey.connect(Me.EBAYTextBox)
        End If
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        If Not GetDigiKey Is Nothing Then
            GetDigiKey.connect(Me.НакладныеTextBox)
        End If
    End Sub
#End Region

#Region "ENTER KEY"
    Private Sub КодTextBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles КодTextBox.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Me.btQuery_Click(sender, e)
            'ElseIf (Char.IsLetterOrDigit(e.KeyChar) Or Asc(e.KeyChar) = 8) And Not Me.bsCurrentGood.Current Is Nothing Then
            '    'изменение номера у карточки товара - запретить
            '    e.Handled = True
            '    'Me.MarkAsNeedSaved()
        End If
    End Sub



    Private Sub АртикулTextBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles АртикулTextBox.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Me.btQuery_Click(sender, e)
            'ElseIf (Char.IsLetterOrDigit(e.KeyChar) Or Asc(e.KeyChar) = 8) And Not Me.bsCurrentGood.Current Is Nothing Then
            '    'изменение номера у карточки товара - запретить
            '    e.Handled = True
            '    'Me.MarkAsNeedSaved()
        End If
    End Sub



    Private Sub НаименованиеTextBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles НаименованиеTextBox.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Me.btQuery_Click(sender, e)

        End If
    End Sub



    Private Sub cbGroups_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbGroups.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Me.btQuery_Click(sender, e)

        End If
    End Sub




#End Region

    ''' <summary>
    ''' замена ед измерения
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub cbUomUser_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbUomUser.SelectedIndexChanged
        Me.Единица_измеренияTextBox.Text = cbUomUser.SelectedItem
    End Sub

    ''' <summary>
    ''' пересчет веса в кг
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub cbWeightUser_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbWeightUser.SelectedIndexChanged
        If cbWeightUser.SelectedIndex <= 1 Then Return
        'пересчет в кг
        Me.ВесTextBox.Text = clsApplicationTypes.WeightConvert(Me.ВесTextBox.Text, cbWeightUser.SelectedItem)
        cbWeightUser.SelectedIndex = 1
        clsApplicationTypes.BeepYES()
    End Sub

    Private Sub Перевозка_рассчетButton_Click(sender As Object, e As EventArgs) Handles Перевозка_рассчетButton.Click
        If ComboBox1.SelectedIndex <= 0 Then
            MsgBox("для рассчета перевозки задай валюту ее стоимости за 1 кг", vbCritical)
            Return
        End If

        Dim _res = clsApplicationTypes.ReplaceDecimalSplitter(ВесTextBox)
        If _res = 0 Then clsApplicationTypes.BeepNOT() : Return
        'стоимость перевозки в рублях
        Dim _calcRUR = clsApplicationTypes.CurrencyConvert(clsApplicationTypes.ReplaceDecimalSplitter(ПеревозкаЗаКГTextBox) * _res, ComboBox1.SelectedItem, "RUR", 6)

        If Валюта__Инвойс_ComboBox.SelectedIndex <= 0 Then
            ПеревозкаTextBox.Text = _calcRUR
            ПеревозкаВалютаComboBox.SelectedItem = "RUR"
        Else
            ПеревозкаTextBox.Text = clsApplicationTypes.CurrencyConvert(_calcRUR, "RUR", Валюта__Инвойс_ComboBox.SelectedItem)
            ПеревозкаВалютаComboBox.SelectedItem = Валюта__Инвойс_ComboBox.SelectedItem
        End If

    End Sub

    Private Sub Закупочная_цена_Button_Click(sender As Object, e As EventArgs) Handles Закупочная_цена_Button.Click
        Dim _invRUR As Decimal
        'инвойс
        If Not Валюта__Инвойс_ComboBox.SelectedIndex <= 0 Then
            _invRUR += clsApplicationTypes.CurrencyConvert(clsApplicationTypes.ReplaceDecimalSplitter(ИнвойсTextBox), Валюта__Инвойс_ComboBox.SelectedItem, "RUR", 6)
        End If

        'накладные
        _invRUR += (clsApplicationTypes.ReplaceDecimalSplitter(НакладныеTextBox) / 100) * _invRUR

        'перевозка
        'If Not ПеревозкаВалютаComboBox.SelectedIndex <= 0 Then
        '    _invRUR += clsApplicationTypes.CurrencyConvert(clsApplicationTypes.ReplaceDecimalSplitter(ПеревозкаTextBox), ПеревозкаВалютаComboBox.SelectedItem, "RUR", 6)
        'End If


        If Not Валюта__Инвойс_ComboBox.SelectedIndex <= 0 Then
            Закупочная_ценаTextBox.Text = clsApplicationTypes.CurrencyConvert(_invRUR, "RUR", Валюта__Инвойс_ComboBox.SelectedItem)
            Валюта__Закупочная_цена_ComboBox.SelectedItem = Валюта__Инвойс_ComboBox.SelectedItem
        Else
            Закупочная_ценаTextBox.Text = _invRUR
            Валюта__Закупочная_цена_ComboBox.SelectedItem = "RUR"
        End If

    End Sub

    Private Sub btCalculateValue_Click(sender As Object, e As EventArgs) Handles btCalculateValue.Click
        If Not Валюта__Закупочная_цена_ComboBox.SelectedIndex <= 0 Then
            Dim _calcRUR As Decimal
            'закупочная цена
            _calcRUR += clsApplicationTypes.CurrencyConvert(clsApplicationTypes.ReplaceDecimalSplitter(Закупочная_ценаTextBox), Валюта__Закупочная_цена_ComboBox.SelectedItem, "RUR")

            'препарация
            _calcRUR += clsApplicationTypes.ReplaceDecimalSplitter(Полная_стоимость_препарации_в_рубляхTextBox)

            'перевозка
            If Not ПеревозкаВалютаComboBox.SelectedIndex <= 0 Then
                _calcRUR += clsApplicationTypes.CurrencyConvert(clsApplicationTypes.ReplaceDecimalSplitter(ПеревозкаTextBox), ПеревозкаВалютаComboBox.SelectedItem, "RUR", 6)
            End If

            Полная_стоимость_закупки_в_рубляхTextBox.Text = _calcRUR
        Else
            MsgBox("Не задана валюта закупочной цены!", vbCritical)
        End If
    End Sub

    Private Sub Расчет_розницыButton_Click(sender As Object, e As EventArgs) Handles Расчет_розницыButton.Click
        Me.tbctlBuying.SelectedTab = Me.tpBuying_Calculate
    End Sub

    Private Sub СбросПеревозкиButton_Click(sender As Object, e As EventArgs) Handles СбросПеревозкиButton.Click
        ПеревозкаВалютаComboBox.SelectedIndex = 0
        ПеревозкаTextBox.Text = ""
    End Sub

    Private Sub СбросНакладныхButton_Click(sender As Object, e As EventArgs) Handles СбросНакладныхButton.Click
        НакладныеTextBox.Text = ""
    End Sub

    Private Sub СтандартныеНакладныеButton_Click(sender As Object, e As EventArgs) Handles СтандартныеНакладныеButton.Click
        НакладныеTextBox.Text = "30"
    End Sub

    Private Sub Расчитать_всеButton_Click(sender As Object, e As EventArgs) Handles Расчитать_всеButton.Click
        Закупочная_цена_Button_Click(sender, e)
        Перевозка_рассчетButton_Click(sender, e)
        btCalculateValue_Click(sender, e)
    End Sub


End Class
