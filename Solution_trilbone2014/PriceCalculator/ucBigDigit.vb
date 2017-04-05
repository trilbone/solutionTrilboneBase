''' <summary>
''' 
''' </summary>
''' <remarks></remarks>
Public Class ucBigDigit
    Private WithEvents oCurrentControl As Windows.Forms.TextBoxBase
    Private oCurrentValue As Decimal
    Private oMaximumValue As Decimal
    ''' <summary>
    ''' необходимо вызвать connect
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()

        ' Этот вызов является обязательным для конструктора.
        InitializeComponent()

        ' Добавьте все инициализирующие действия после вызова InitializeComponent().
        Me.btDecimal.Text = My.Computer.Info.InstalledUICulture.NumberFormat.NumberDecimalSeparator
    End Sub
    ''' <summary>
    ''' если задано maximumValue, то при достижении этого значения, в случае числого значения, ввод сбрасывается
    ''' ctl - ссылка на эу куда вводить данные
    ''' </summary>
    ''' <param name="ctl"></param>
    ''' <param name="maximumValue"></param>
    ''' <remarks></remarks>
    Public Sub Connect(ctl As Windows.Forms.TextBoxBase, Optional maximumValue As Decimal = 0, Optional OkKey As String = "Close")
        oCurrentControl = ctl
        oCurrentValue = 0
        oMaximumValue = maximumValue
        Me.btClose.Text = OkKey
    End Sub

  
    ''' <summary>
    ''' срабатывает, когда меняется текст
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Shadows Event TextChanged(sender As Object, e As EventArgs)


    Private Sub ButtonsCalc_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click, Button2.Click, Button3.Click, Button4.Click, Button5.Click, Button6.Click, Button7.Click, Button8.Click, Button9.Click, Button0.Click, btSplitter.Click, btDecimal.Click
        If oCurrentControl Is Nothing Then Return
        Dim _v = sender.text

        If oCurrentControl.SelectionLength > 0 Then
            'выделен текст, убрать
            oCurrentControl.Text = oCurrentControl.Text.Replace(oCurrentControl.SelectedText, _v)
            RaiseEvent TextChanged(Me, EventArgs.Empty)
        Else
            oCurrentControl.Text += _v
            RaiseEvent TextChanged(Me, EventArgs.Empty)
        End If
        'если задано макс. значение и в вводе только цифры, то по достижении максимума ввод сбрасывается
        If oMaximumValue > 0 AndAlso oIsDigitValue = True AndAlso (oCurrentValue > oMaximumValue) Then
            oCurrentControl.Text = _v
            RaiseEvent TextChanged(Me, EventArgs.Empty)
        End If
        oCurrentControl.Focus()
        oCurrentControl.Select(oCurrentControl.Text.Length, 0)
    End Sub

    Private Sub ButtonCorrect_Click(sender As System.Object, e As System.EventArgs) Handles btCorrect.Click
        If oCurrentControl Is Nothing Then Return
        If oCurrentControl.Text.Length < 1 Then Return
        oCurrentControl.Text = oCurrentControl.Text.Substring(0, oCurrentControl.Text.Length - 1)
        RaiseEvent TextChanged(Me, EventArgs.Empty)
        oCurrentControl.Focus()
        oCurrentControl.Select(oCurrentControl.Text.Length, 0)
    End Sub
    ''' <summary>
    ''' возникает, если пользователь нажмет close
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Event StopEnter_Close(sender As Object, e As StopEnter_CloseEventArgs)

    Public Class StopEnter_CloseEventArgs
        Inherits EventArgs
        ''' <summary>
        ''' связанный ЭУ
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CurrentControl As Windows.Forms.TextBoxBase
    End Class

    Private Sub ButtonClose_Click(sender As System.Object, e As System.EventArgs) Handles btClose.Click
        If oCurrentControl Is Nothing Then Return
        'закрыть форму и передать фокус
        oCurrentControl.Focus()
        oCurrentControl.Select(oCurrentControl.Text.Length, 0)
        RaiseEvent StopEnter_Close(Me, New StopEnter_CloseEventArgs With {.CurrentControl = oCurrentControl})


        'Select Case oCurrentControlIndex
        '    Case 0
        '        Me.NumericUpDown1.Focus()
        '    Case 1
        '        Me.NumericUpDown2.Focus()
        '    Case 2
        '        Me.NumericUpDown3.Focus()
        '    Case 3
        '        Me.NumericUpDown4.Focus()
        '    Case 4
        '        Me.NumericUpDown5.Focus()
        '    Case 5
        '        Me.NumericUpDown6.Focus()
        '    Case 6
        '        'last index
        '        Me.btClear.Focus()
        '        oCurrentControlIndex = 0
        'End Select
    End Sub

    Private oIsDigitValue As Boolean
    ''' <summary>
    ''' показывает, что вводим цифровое значение
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property IsDigitValue As Boolean
        Get
            Return oIsDigitValue
        End Get
    End Property
    ''' <summary>
    ''' текущее числовое значение текста связанного ЭУ
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property CurrentDigitValue As Decimal
        Get
            Return oCurrentValue
        End Get
    End Property
    ''' <summary>
    ''' текущее текстовое значение текста связанного ЭУ
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property CurrentTextValue As String
        Get
            Return oCurrentControl.Text
        End Get
    End Property
    ''' <summary>
    ''' связанный ЭУ
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property LinkedControl As Windows.Forms.TextBoxBase
        Get
            Return oCurrentControl
        End Get
    End Property

    Private Sub TextChanged_eventhandler(sender As Object, e As EventArgs) Handles Me.TextChanged
        If oCurrentControl Is Nothing Then Return

        Dim _result As Decimal
        Dim _test = Decimal.TryParse(oCurrentControl.Text, _result)
        If _test Then
            oIsDigitValue = True
            oCurrentValue = _result
        Else
            oIsDigitValue = False
            oCurrentValue = 0
        End If
        RaiseEvent TextValueChanged(Me, New TextValueChangedEventArgs(oCurrentControl.Text))
    End Sub
    ''' <summary>
    ''' возникает при изменении текста в связанном ЭУ. Возникает позже других событий обновления
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Event TextValueChanged(sender As Object, e As TextValueChangedEventArgs)

    Public Class TextValueChangedEventArgs
        Inherits EventArgs
        Public Property Value As String
        Public Sub New(vl As String)
            Value = vl
        End Sub
    End Class

  

    'Public Event KeyPressed(sender As Object, e As KeyPressedEventArgs)

    'Public Enum Key
    '    key1 = 1
    '    key2 = 2
    '    key3 = 3
    '    key4 = 4
    '    key5 = 5
    '    key6 = 6
    '    key7 = 7
    '    key8 = 8
    '    key9 = 9
    '    key0 = 0
    '    keysplitter = 10
    '    keycorrect = 20
    '    keyclose = 30
    '    keydecimal = 40
    'End Enum

    'Public Class KeyPressedEventArgs
    '    Inherits EventArgs
    '    Public ReadOnly Property KeyValue As Integer
    '        Get
    '            Return Keys
    '        End Get
    '    End Property
    '    Public Property Keys As Key
    '    Public Sub New(vl As Key)
    '        Keys = vl
    '    End Sub
    'End Class

    
    Private Sub btClearAll_Click(sender As System.Object, e As System.EventArgs) Handles btClearAll.Click
        If oCurrentControl Is Nothing Then Return
        If oCurrentControl.Text.Length < 1 Then Return
        oCurrentControl.Text = ""
        RaiseEvent TextChanged(Me, EventArgs.Empty)
        oCurrentControl.Focus()
        oCurrentControl.Select(oCurrentControl.Text.Length, 0)
    End Sub
End Class
