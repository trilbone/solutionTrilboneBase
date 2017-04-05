Imports System.Globalization

Public Class fmCondition

    Public Sub New()

        ' Этот вызов является обязательным для конструктора.
        InitializeComponent()

        ' Добавьте все инициализирующие действия после вызова InitializeComponent().

    End Sub

    Public Sub New(lang As CultureInfo)
        Me.New()
        UserControlQality1.Culture = lang
    End Sub

    Private Sub UserControlQality1_DescriptionCompleted(sender As Object, e As EventArgs) Handles UserControlQality1.DescriptionCompleted
        Me.Close()
    End Sub

    Private Sub UserControlQality1_QualityTextChanged(sender As Object, e As UserControlQality.QualityTextChangedEventArgs) Handles UserControlQality1.QualityTextChanged
        Me.Tag = e.text
        RaiseEvent TextDataChanged(Me, New TextDataChangedEventArgs With {.Text = e.text, .Culture = e.Culture, .GeneratedText = e.GeneratedText, .Values = e.Values, .GetText = e.GetText})
    End Sub

    Public Event TextDataChanged(sender As Object, e As TextDataChangedEventArgs)

    Public Class TextDataChangedEventArgs
        Inherits EventArgs
        Public Property Text As String
        Public Property Values As Integer()
        Public Property Culture As CultureInfo
        Public Property GeneratedText As String
        Public Property GetText As Func(Of Integer(), CultureInfo, String)
    End Class

   
End Class