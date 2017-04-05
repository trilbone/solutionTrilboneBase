Public Class FmCodeConverter
    Dim oConverter As clsCode

    Public Sub New()

        ' Этот вызов является обязательным для конструктора.
        InitializeComponent()

        ' Добавьте все инициализирующие действия после вызова InitializeComponent().
        For Each clt As Windows.Forms.Control In Me.Controls
            clt.Enabled = False
        Next
        Me.tbSampleNumber.Enabled = True
    End Sub

    Private Sub btSearchInfo_Click(sender As System.Object, e As System.EventArgs) Handles btSearchInfo.Click
        If Me.tbSampleNumber.Text = "" Then
            Exit Sub
        End If


        Dim _lastnumber As String = ""
        If Not Me.oConverter Is Nothing Then
            _lastnumber = Me.oConverter.EAN13.ToString
        End If
        Dim _number As clsCode = clsCode.CreateInstance(Me.tbSampleNumber.Text)
        If _number Is Nothing OrElse _number.CodeType = clsCode.emCodeType.Incorrect Then
            MsgBox("неверный код: " + Me.tbSampleNumber.Text, MsgBoxStyle.Critical)
            Me.tbSampleNumber.Text = _lastnumber
            Exit Sub
        End If
        For Each clt As Windows.Forms.Control In Me.Controls
            clt.Enabled = True
        Next
        oConverter = _number

        If oConverter.CodeType = clsCode.emCodeType.EAN13 Then
            Me.tbSampleNumber.Text = oConverter.EAN13.ToString
        Else
            Me.tbSampleNumber.Text = oConverter.ShotCode
        End If

        lbSample.Text = oConverter.ShotCode
    End Sub

    Private Sub tbSampleNumber_Enter(sender As Object, e As System.EventArgs) Handles tbSampleNumber.Enter
        If tbSampleNumber.Text.ToString.Length >= 13 Then
            tbSampleNumber.Text = ""
        End If
    End Sub

    Private Sub tbSampleNumber_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tbSampleNumber.KeyPress
        If Asc(e.KeyChar) = 13 Then

            btSearchInfo_Click(Me, New System.EventArgs)

        End If
    End Sub

    Private Sub tbSampleNumber_TextChanged(sender As System.Object, e As System.EventArgs) Handles tbSampleNumber.TextChanged

    End Sub

    Private Sub FmCodeConverter_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            'цифра
            'очистить поле и начать ввод
            Me.tbSampleNumber.Text = e.KeyChar.ToString
            Me.tbSampleNumber.Focus()
        End If
    End Sub

    Private Sub FmCodeConverter_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub FmCodeConverter_MenuStart(sender As Object, e As System.EventArgs) Handles Me.MenuStart

    End Sub

    Private Sub btCopyNumber_Click(sender As System.Object, e As System.EventArgs) Handles btCopyNumber.Click
        If Not Me.oConverter Is Nothing Then
            '------------------
            Dim _data As String = Me.oConverter.EAN13p36TT
            Try
                My.Computer.Clipboard.Clear()
                My.Computer.Clipboard.SetText(Me.oConverter.EAN13p36TT)
            Catch ex As Exception
                MsgBox("Ошибка при помещении данных в буфер обмена.", vbCritical)
            End Try
            '-----------------
        Else
            MsgBox("Не задан номер!", vbCritical)
        End If
    End Sub

    Private Sub btCopyArticul_Click(sender As System.Object, e As System.EventArgs) Handles btCopyArticul.Click

        If Not Me.oConverter Is Nothing Then
            '------------------
            Dim _data As String = Me.oConverter.ShotCode
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

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        If Not Me.oConverter Is Nothing Then
            '------------------
            Dim _data As String = Me.oConverter.EAN13.ToString
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
End Class