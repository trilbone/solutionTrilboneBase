Public Class fmGood
    Public ReadOnly Property _uc As uc_nopGood
        Get
            Return Me.Uc_nopGood1
        End Get
    End Property

    Private Sub Uc_attributes1_ObjectListChanged(sender As Object, e As EventArgs) Handles Uc_nopGood1.ObjectListChanged
        'MsgBox("список изменен")
    End Sub

    Private Sub Uc_nopGood1_Load(sender As Object, e As EventArgs) Handles Uc_nopGood1.Load

    End Sub
End Class