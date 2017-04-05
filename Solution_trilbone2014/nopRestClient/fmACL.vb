Public Class fmACL

    Public ReadOnly Property _uc As uc_ACL
        Get
            Return Me.Uc_ACL1
        End Get
    End Property

    Private Sub Uc_attributes1_ObjectListChanged(sender As Object, e As EventArgs) Handles Uc_ACL1.ObjectListChanged
        MsgBox("список изменен")
    End Sub
End Class