Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Linq
Public Class UC_preparator_calc

    Public Event SalaryCalculated(sender As Object, e As SalaryCalculatedEventArgs)

    Public Class SalaryCalculatedEventArgs
        Inherits EventArgs
        Public Property Salary As Decimal
        Public Property IsFriendPrice As Boolean

        Public Property TotalHour As Decimal

        Public Property PrepTimeBox As String

        Public Property MainPrep As String

        Public Property RawNumber As String

    End Class


    Private oBuyToolTip As New ToolTip

    Public Sub Clear()
        tbFullPrepCost.BackColor = Color.White

        Me.tbPrepList.Text = ""
        Me.tbFullPrepCost.Text = ""
        Me.tbPrepCost.Text = ""
        Me.tbPrepTime.Text = ""
        Me.tbPrepTimeAdd.Text = ""
        Me.cbPreparatorAdd.SelectedIndex = -1

    End Sub

    Public Sub New()

        ' Этот вызов является обязательным для конструктора.
        InitializeComponent()

        ' Добавить код инициализации после вызова InitializeComponent().
        'загрузить препараторов
        Me.cbMainPreparator.DataSource = (clsApplicationTypes.Users)
        Me.cbMainPreparator.DisplayMember = "UserShotName"
        Me.cbMainPreparator.SelectedIndex = -1

        Me.cbPreparatorAdd.DataSource = (clsApplicationTypes.Users)
        Me.cbPreparatorAdd.DisplayMember = "UserShotName"
        Me.cbPreparatorAdd.SelectedIndex = -1
    End Sub
    ''' <summary>
    ''' записать данные. Результат событием передасться.
    ''' </summary>
    ''' <param name="RawNumber"></param>
    ''' <param name="PreparatorString"></param>
    Public Sub SetData(RawNumber As String, PreparatorString As String, Optional MainPreparator As String = "")
        Me.Clear()
        Me.tbRawNumber.Text = RawNumber
        Me.tbPrepList.Text = PreparatorString
        'найти основного препаратора
        If Not String.IsNullOrEmpty(MainPreparator) Then
            Dim _list As List(Of clsUser) = Me.cbMainPreparator.DataSource

            Dim _item = (From c In _list Where c.UserShotName.Contains(MainPreparator)).FirstOrDefault

            If Not _item Is Nothing Then
                Me.cbMainPreparator.SelectedItem = _item
            End If
        End If
    End Sub

    Private Shared ReadOnly Property GetDigiKey As Object
        Get
            Return Service.clsApplicationTypes.GetDigiKeyBoardForm
        End Get
    End Property

    Private Sub RawNumberLabel_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles RawNumberLabel.MouseClick
        If Not GetDigiKey Is Nothing Then
            GetDigiKey.connect(Me.tbRawNumber)
        End If
    End Sub

    Private Sub tbRawNumber_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbRawNumber.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Dim _code = ShotCodeConverter_Net.clsCode.CreateInstance(tbRawNumber.Text)
            If Not _code.CodeType = ShotCodeConverter_Net.clsCode.emCodeType.Incorrect Then
                tbRawNumber.Text = _code.EAN13
            End If

            If Not Me.cbMainPreparator.DroppedDown Then
                Me.cbMainPreparator.DroppedDown = True
            End If
            Me.cbMainPreparator.Focus()
            Me.cbMainPreparator.SelectedIndex = 0
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

    Private Sub tbPrepList_TextChanged(sender As Object, e As EventArgs) Handles tbPrepList.TextChanged
        Dim _totalHour As Decimal = 0
        Dim _totalPay As Decimal = 0
        Dim _mess As String = ""
        If ParsePrepString(tbPrepList.Text, _totalHour, _totalPay) Then
            Me.tbPrepCost.Text = _totalPay
            Me.tbPrepTime.Text = _totalHour
        End If
    End Sub

    ''' <summary>
    ''' разберет cтроку препараторов
    ''' </summary>
    ''' <param name="PrepString"></param>
    ''' <param name="TotalHour"></param>
    ''' <param name="TotalSalary"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ParsePrepString(PrepString As String, ByRef TotalHour As Decimal, ByRef TotalSalary As Decimal) As Boolean
        If String.IsNullOrEmpty(PrepString) Then Return False
        Dim _preps = PrepString.Split(";".ToCharArray, System.StringSplitOptions.RemoveEmptyEntries)
        If _preps.Length = 0 Then Return False
        Dim _totalHours As Decimal = 0
        Dim _totalSalary As Decimal = 0

        For Each p In _preps
            Dim _ps = p.Split("(")
            If _ps.Length < 2 Then Return False
            If Not _ps(1).Contains("*") Then Return False

            Dim _name = _ps(0)
            If Not String.IsNullOrEmpty(_name) Then
                Dim _hour As Decimal
                Dim _salary As Decimal
                Dim _out As New KeyValuePair(Of String, KeyValuePair(Of Decimal, Decimal))

                If Decimal.TryParse(_ps(1).Split("*")(0), _hour) Then
                    If Decimal.TryParse(_ps(1).TrimEnd(")").Split("*")(1), _salary) Then
                        _out = New KeyValuePair(Of String, KeyValuePair(Of Decimal, Decimal))(_name, New KeyValuePair(Of Decimal, Decimal)(_hour, _salary))

                        _totalHours += _hour
                        _totalSalary += _salary * _hour
                    End If
                End If
            End If
        Next
        TotalHour = _totalHours
        TotalSalary = _totalSalary
        Return True

    End Function
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
        Nalogi = _out * 0.529 'My.Settings.NLcost / 100
        _out += Nalogi

        '+наш бабос с часа = +100%(в настройках) с брутто
        OurProfit = PayByCash * 1 ' (My.Settings.TRsalary / 100)
        _out += OurProfit

        'френд цена на препарацию = фактические затраты +50%
        FriendPrepPrice = PayByCash * 1.5 + Nalogi

        Return clsApplicationTypes.RoundPrice(_out)
    End Function

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

        Dim _user As clsUser = Me.cbPreparatorAdd.SelectedItem
        Dim _salary = _user.GetRURSalary ' (From c In clsApplicationTypes.Users Where c.Employee.UUID IsNot Nothing AndAlso c.Employee.UUID.Trim.Equals(_user.uuid) Select c.GetRURSalary).FirstOrDefault

        Dim _out = String.Format("{0}({2}*{1})", _user.UserShotName, _salary, _time)
        If Not String.IsNullOrEmpty(tbPrepList.Text) Then
            tbPrepList.Text += ";"
        End If
        tbPrepList.Text += _out

        Me.cbPreparatorAdd.SelectedIndex = -1
        Me.tbPrepTimeAdd.Text = ""

        clsApplicationTypes.BeepYES()
        Me.cbPreparatorAdd.Focus()
    End Sub

    Private Sub btToPrepTime_Click(sender As Object, e As EventArgs) Handles btToPrepTime.Click
        Me.tbPrepTimeAdd.Text = Me.tbPrepTime.Text
        Me.btAddPrep.Focus()
    End Sub


    Private Sub tbPrepCost_Validating(sender As Object, e As CancelEventArgs) Handles tbPrepCost.Validating, tbPrepCost.Validating, tbFullPrepCost.Validating, tbPrepTimeAdd.Validating
        If sender.Text = "" Then sender.Text = "0" : Return
        If sender.Text = " " Then sender.Text = "0" : Return
        sender.text = clsApplicationTypes.ReplaceDecimalSplitter(sender.text)
        sender.backcolor = Color.FromKnownColor(KnownColor.Window)
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

        If ParsePrepString(tbPrepList.Text, _totalHour, _totalPay) Then
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

    Private Sub MarkAsNeedSaved()

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
    ''' подсветить желтым, если для ребят
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tbFullPrepCost_TextChanged(sender As Object, e As EventArgs) Handles tbFullPrepCost.TextChanged
        Dim _totalHour As Decimal = 0
        Dim _totalPay As Decimal = 0
        Dim _mess As String = ""
        Dim _friend As Decimal = 0

        If Not ParsePrepString(tbPrepList.Text, _totalHour, _totalPay) Then
            'неразборчивая строка
            _totalPay = clsApplicationTypes.ReplaceDecimalSplitter(tbPrepCost)
        End If

        Dim _fp = PrepCalculate(_totalPay, , , _friend)
        Dim _sto = clsApplicationTypes.ReplaceDecimalSplitter(Me.tbFullPrepCost)
        Dim _isFriend As Boolean = False
        If _sto > (_friend - _friend * 0.05) And _sto < (_friend + _friend * 0.05) Then
            'задана цена для ребят
            tbFullPrepCost.BackColor = Color.Yellow
            _isFriend = True
        Else
            tbFullPrepCost.BackColor = Color.White
            _isFriend = False
        End If
        RaiseEvent SalaryCalculated(Me, New SalaryCalculatedEventArgs With {.Salary = _sto, .IsFriendPrice = _isFriend, .TotalHour = _totalHour, .RawNumber = Me.tbRawNumber.Text, .MainPrep = Me.cbMainPreparator.Text, .PrepTimeBox = Me.tbPrepList.Text})
        '_mess = String.Format("Налик {0} руб.; Стоимость для ребят {2} руб.; к рассчету {1} руб.", _totalPay, _fp, _friend)
    End Sub

    Private Sub tbFullPrepCost_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbFullPrepCost.KeyPress
        MarkAsNeedSaved()
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
        If ParsePrepString(tbPrepList.Text, _totalHour, _totalPay) Then

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

    Private Sub tbPrepTimeAdd_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbPrepTimeAdd.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Me.btAddPrep_Click(sender, e)
        End If
    End Sub

    Private Sub Label40_Click(sender As Object, e As EventArgs) Handles Label40.Click
        GetDigiKey.connect(tbPrepTimeAdd)
    End Sub

    Private Sub RawNumberLabel_Click(sender As Object, e As EventArgs) Handles RawNumberLabel.Click
        GetDigiKey.connect(Me.tbRawNumber)
    End Sub

    Private Sub Label36_Click(sender As Object, e As EventArgs) Handles Label36.Click
        GetDigiKey.connect(Me.tbPrepTime)
    End Sub

    Private Sub Label45_Click(sender As Object, e As EventArgs) Handles Label45.Click
        GetDigiKey.connect(Me.tbPrepCost)
    End Sub

    Private Sub Label48_Click(sender As Object, e As EventArgs) Handles Label48.Click
        GetDigiKey.connect(Me.tbFullPrepCost)
    End Sub



End Class
