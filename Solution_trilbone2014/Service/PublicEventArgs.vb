
Public Class CultureChangedEventArgs
    Public Sub New(newculture As Globalization.CultureInfo)
        Culture = newculture
    End Sub

    Property Culture As Globalization.CultureInfo
End Class
