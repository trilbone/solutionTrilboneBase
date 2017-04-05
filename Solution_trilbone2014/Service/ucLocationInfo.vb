Public Class ucLocationInfo

    Public Sub Init(data As List(Of iMoySkladDataProvider.strGoodMapQty))
        Me.StrGoodMapQtyBindingSource.DataSource = data
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        RaiseEvent NeedClosed(Me, EventArgs.Empty)
    End Sub

    Public Event NeedClosed(sender As Object, e As EventArgs)

End Class
