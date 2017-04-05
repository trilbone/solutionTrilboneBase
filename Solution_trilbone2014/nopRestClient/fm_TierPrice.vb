Public Class fm_TierPrice
    Public ReadOnly Property _uc As uc_tierPrice
        Get
            Return Me.Uc_tierPrice1
        End Get
    End Property

    Private Sub Uc_attributes1_ObjectListChanged(sender As Object, e As EventArgs) Handles Uc_tierPrice1.ObjectListChanged
        'MsgBox("список изменен")
    End Sub
End Class