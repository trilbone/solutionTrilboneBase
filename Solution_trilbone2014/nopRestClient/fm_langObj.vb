Public Class fm_langObj

    Public ReadOnly Property _uc As uc_langObject
        Get
            Return Me.Uc_langObject1
        End Get
    End Property

    Public Property ShowMessages As Boolean

    Private Sub Uc_langObject1_ObjectListChanged(sender As Object, e As uc_langObject.ItemEventArgs) Handles Uc_langObject1.ObjectListChanged
        If ShowMessages Then
            MsgBox("список изменен")
        End If
    End Sub

   
End Class