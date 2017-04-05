Public Class fm_attributes

    Public ReadOnly Property _uc As uc_attributes
        Get
            Return Me.Uc_attributes1
        End Get
    End Property

    Private Sub Uc_attributes1_ObjectListChanged(sender As Object, e As EventArgs) Handles Uc_attributes1.ObjectListChanged
        'Me.Refresh()
        'MsgBox("список изменен")
        'Me.Refresh()
    End Sub
End Class