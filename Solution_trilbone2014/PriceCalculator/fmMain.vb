Public Class fmMain

    Private oDataClass As clsLotCalculatorData

    Private Sub fmMain_Disposed(sender As Object, e As System.EventArgs) Handles Me.Disposed
        oDataClass.Dispose()
    End Sub
    Private Sub fmMain_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        oDataClass = New clsLotCalculatorData(My.Settings.eurCource, My.Settings.koeffkat1)
        If Not oDataClass.IsLoadedExcel Then
            Me.btShowOptions_Click(sender, e)
        End If
        Me.ClsDataBindingSource.DataSource = oDataClass
        ' Me.btNakladnye.Text = "+накладные " & My.Settings.Nakladnye & "%"
        Me.NumericUpDown1.Focus()
    End Sub

    Private Sub btCalculate_Click(sender As System.Object, e As System.EventArgs) Handles btCalculate.Click
        If (Me.NumericUpDown3.Value + Me.NumericUpDown4.Value) > Me.NumericUpDown1.Value Then
            MsgBox("Общее количество 1 и 5 позиции не может быть больше общего количества в лоте!", vbCritical)
            Me.NumericUpDown1.Value = Me.NumericUpDown3.Value + Me.NumericUpDown4.Value
            Me.btCalculate.Focus()
            Return
        End If

        If Me.NumericUpDown4.Value > 1 Then
            If Me.CheckBox1.Checked Then
                Me.CheckBox1.Checked = False
            End If
            Me.CheckBox1.Checked = True
        End If

        Me.NumericUpDown5.Value = 0
        oDataClass.Calculate(True)
        Me.ClsDataBindingSource.ResetCurrentItem()
        Me.NumericUpDown5.Select(0, Me.NumericUpDown5.Value.ToString.Length - 1)

        Me.NumericUpDown5.Focus()
    End Sub

    Private Sub btTunePrice_Click(sender As System.Object, e As System.EventArgs) Handles btTunePrice.Click
        oDataClass.TunePrices()
        Me.ClsDataBindingSource.ResetCurrentItem()
        oCurrentControlIndex = 4
        Me.NumericUpDown5.Focus()
    End Sub

    Private Sub btShowOptions_Click(sender As System.Object, e As System.EventArgs) Handles btShowOptions.Click
        Dim _fm As New fmOptions
        _fm.ShowDialog()
        oDataClass = New clsLotCalculatorData(My.Settings.eurCource, My.Settings.koeffkat1)
        Me.ClsDataBindingSource.DataSource = oDataClass
    End Sub

    Private oCurrentControl As Windows.Forms.NumericUpDown

    Private Sub NumericUpDown1_Enter(sender As Object, e As System.EventArgs) Handles NumericUpDown1.Enter, NumericUpDown2.Enter, NumericUpDown3.Enter, NumericUpDown4.Enter, NumericUpDown5.Enter, NumericUpDown6.Enter
        oCurrentControl = sender
        Dim otbb As TextBoxBase = CType(sender, Control).Controls(1)
        otbb.SelectAll()
        'CType(sender, Control).Refresh()
    End Sub

    Private Sub ButtonsCalc_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click, Button2.Click, Button3.Click, Button4.Click, Button5.Click, Button6.Click, Button7.Click, Button8.Click, Button9.Click, Button0.Click
        If oCurrentControl Is Nothing Then Return
        Dim _v = sender.text

        Dim _otbb As TextBoxBase = CType(oCurrentControl, Control).Controls(1)
        If _otbb.SelectionLength > 0 Then
            'выделен текст, убрать
            oCurrentControl.Text = _otbb.Text.Replace(_otbb.SelectedText, _v)

        Else
            oCurrentControl.Text += _v
        End If

        If oCurrentControl.Value > oCurrentControl.Maximum Then
            oCurrentControl.Text = _v
        End If
        '_otbb = CType(oCurrentControl, Control).Controls(1)
        '_otbb.DeselectAll()
        '_otbb.SelectionLength = 0
        oCurrentControl.Focus()
        oCurrentControl.Select(oCurrentControl.Text.Length, 0)
    End Sub

  
    
    Private Sub ButtonClear_Click(sender As System.Object, e As System.EventArgs) Handles ButtonCorrect.Click
        If oCurrentControl Is Nothing Then Return
        If oCurrentControl.Text.Length < 1 Then Return
        oCurrentControl.Text = oCurrentControl.Text.Substring(0, oCurrentControl.Text.Length - 1)
        oCurrentControl.Focus()
        oCurrentControl.Select(oCurrentControl.Text.Length, 0)
        '  Me.ActiveControl.Focus()
    End Sub

    Private Sub ButtonCorrect_Click(sender As System.Object, e As System.EventArgs) Handles ButtonNext.Click
        Select Case oCurrentControlIndex
            Case 0
                Me.NumericUpDown1.Focus()
            Case 1
                Me.NumericUpDown2.Focus()
            Case 2
                Me.NumericUpDown3.Focus()
            Case 3
                Me.NumericUpDown4.Focus()
            Case 4
                Me.NumericUpDown5.Focus()
            Case 5
                Me.NumericUpDown6.Focus()
            Case 6
                'last index
                Me.btClear.Focus()
                oCurrentControlIndex = 0
        End Select


    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox1.CheckedChanged
        Select Case CheckBox1.Checked
            Case True
                Me.lblKat1.Text = "Норм. кол-во(1)"
                Me.NumericUpDown4.ReadOnly = True
                Me.NumericUpDown5.Focus()
            Case Else
                Me.lblKat1.Text = "кол-во(1)"
                Me.NumericUpDown4.ReadOnly = False
                Me.NumericUpDown4.Focus()
        End Select

    End Sub

   
    Private Sub btCalculate_GotFocus(sender As Object, e As System.EventArgs) Handles btCalculate.GotFocus
        Me.oCurrentControl = Nothing
    End Sub

    Private Sub btShowExcel_Click(sender As System.Object, e As System.EventArgs) Handles btShowExcel.Click
        oDataClass.showexcel()
    End Sub

    'Private Sub NumericUpDown6_Validated(sender As Object, e As System.EventArgs) Handles NumericUpDown6.Validated, NumericUpDown5.Validated
    '    If oDataClass Is Nothing Then Return
    '    oDataClass.Calculate(False)
    '    Me.ClsDataBindingSource.ResetCurrentItem()
    'End Sub

    
    Private Sub btClear_Click(sender As System.Object, e As System.EventArgs) Handles btClear.Click
        Me.oDataClass.Clear()
        Me.NumericUpDown1.Focus()
        oCurrentControlIndex = 1
        Me.ClsDataBindingSource.ResetCurrentItem()
        Me.NumericUpDown1.Focus()
    End Sub

    Private Sub btRefresh_Click(sender As System.Object, e As System.EventArgs) Handles btRefresh.Click
        oDataClass.Calculate(False)
        Me.ClsDataBindingSource.ResetCurrentItem()
    End Sub

    Private oCurrentControlIndex As Integer = 0

    Private Sub NumericUpDown1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles NumericUpDown1.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Me.NumericUpDown2.Focus()
        End If
    End Sub

    Private Sub NumericUpDown1_ValueChanged(sender As System.Object, e As System.EventArgs) Handles NumericUpDown1.ValueChanged
        oCurrentControlIndex = 1
    End Sub

    Private Sub NumericUpDown2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles NumericUpDown2.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Me.NumericUpDown3.Focus()
        End If
    End Sub

    Private Sub NumericUpDown2_ValueChanged(sender As System.Object, e As System.EventArgs) Handles NumericUpDown2.ValueChanged
        oCurrentControlIndex = 2

    End Sub

    Private Sub NumericUpDown3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles NumericUpDown3.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Me.NumericUpDown4.Focus()
        End If
    End Sub

    Private Sub NumericUpDown3_ValueChanged(sender As System.Object, e As System.EventArgs) Handles NumericUpDown3.ValueChanged
        oCurrentControlIndex = 3

    End Sub

    Private Sub NumericUpDown4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles NumericUpDown4.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Me.btCalculate_Click(sender, e)
        End If
    End Sub

    Private Sub NumericUpDown4_ValueChanged(sender As System.Object, e As System.EventArgs) Handles NumericUpDown4.ValueChanged
        oCurrentControlIndex = 4

    End Sub

    Private Sub NumericUpDown5_KeyPress(sender As Object, e As KeyPressEventArgs) Handles NumericUpDown5.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Me.btTunePrice_Click(sender, e)
        End If
    End Sub

    Private Sub NumericUpDown5_ValueChanged(sender As System.Object, e As System.EventArgs) Handles NumericUpDown5.ValueChanged
        oCurrentControlIndex = 5

    End Sub

    Private Sub NumericUpDown6_ValueChanged(sender As System.Object, e As System.EventArgs) Handles NumericUpDown6.ValueChanged
        oCurrentControlIndex = 6

    End Sub

    Private Sub btNakladnye_Click(sender As Object, e As EventArgs)
        Me.NumericUpDown2.Value += Me.NumericUpDown2.Value * My.Settings.Nakladnye / 100
        Me.NumericUpDown3.Focus()
    End Sub

    Public Sub New()

        ' Этот вызов является обязательным для конструктора.
        InitializeComponent()

        ' Добавьте все инициализирующие действия после вызова InitializeComponent().

    End Sub
End Class
