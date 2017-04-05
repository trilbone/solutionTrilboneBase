
Public Class clsCalculatorService
    Public Function GetCalculator() As Form
        Dim _fm = New fmMain
        Return _fm
    End Function

    ''' <summary>
    ''' вернет преобразованное значение текста в число. Если ошибка, вернет 0.
    ''' </summary>
    ''' <param name="text"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Shared Function ReplaceDecimalSplitter(ByVal textcontrol As TextBoxBase) As Decimal
        Dim _out As Decimal = 0
        If Decimal.TryParse(ReplaceDecimalSplitter(textcontrol.Text), _out) Then
            Return _out
        End If
        Return 0
    End Function

    ''' <summary>
    ''' замена . на ,
    ''' </summary>
    ''' <param name="text"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Shared Function ReplaceDecimalSplitter(ByVal text As String) As String
        Dim _needsep = Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator
        If String.IsNullOrEmpty(text) Then Return "0"
        text = text.Replace(",", _needsep)
        text = text.Replace(".", _needsep)
        Return text
    End Function
End Class
