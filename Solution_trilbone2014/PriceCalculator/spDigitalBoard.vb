Public Class spDigitalBoard
    Private WithEvents oControl As TextBoxBase
    Public Sub New()

        ' Этот вызов является обязательным для конструктора.
        InitializeComponent()

        ' Добавьте все инициализирующие действия после вызова InitializeComponent().
        vspace = 2
    End Sub
    ''' <summary>
    ''' задает пробел от целевого элемента управления
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property vspace As Integer
    ''' <summary>
    ''' присоединит форму к целевому ЭУ.вызовите focus() для установки фокуса на эу после ввода((
    ''' </summary>
    ''' <param name="ctl"></param>
    ''' <param name="maximumvalue"></param>
    ''' <remarks></remarks>
    Public Sub Connect(ctl As TextBoxBase, Optional maximumvalue As Decimal = 0, Optional OkKey As String = "Close")
        'координаты отображения
        Me.StartPosition = FormStartPosition.Manual
        Dim _Basepoint = ctl.PointToScreen(New Point(0, 0))
        Dim _point = _Basepoint
        _point.Offset(0, ctl.Size.Height + vspace)
        'считаем, влезит ли на экран
        Dim _rect As New Rectangle(_point, Me.Size)

        Dim _result = (From c In Screen.AllScreens Let d = c.Bounds.Contains(_rect) Where d = True Select d).FirstOrDefault


        If Not _result Then
            'не лезит,пытаемся воткнуть сверху
            _point = _Basepoint
            _point.Offset(0, -1 * (Me.Size.Height + vspace))
            _rect = New Rectangle(_point, Me.Size)
            _result = (From c In Screen.AllScreens Let d = c.Bounds.Contains(_rect) Where d = True Select d).FirstOrDefault
            If Not _result Then
                'не лезит,пытаемся воткнуть слева
                _point = _Basepoint
                _point.Offset(-1 * (Me.Size.Width + vspace), 0)
            End If
        End If

        If OkKey = "Close" Then
            oOkKayTextNotStandart = False
        Else
            oOkKayTextNotStandart = True
        End If

        Me.Location = _point
        oControl = ctl
        Me.UcBigDigit1.Connect(ctl, maximumvalue, OkKey)

        Me.ShowDialog()
    End Sub

    Private oOkKayTextNotStandart As Boolean = True
    ''' <summary>
    '''в экземпляре надпись изменена
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property OkKayTextNotStandart As Boolean
        Get
            Return oOkKayTextNotStandart
        End Get
    End Property

    Private Sub UcBigDigit1_StopEnter_Close(sender As Object, e As ucBigDigit.StopEnter_CloseEventArgs) Handles UcBigDigit1.StopEnter_Close
        Me.Close()
    End Sub
End Class
