Public Class fm_simleObj
    Public ReadOnly Property _uc As uc_SimpleObject
        Get
            Return Me.Uc_SimpleObject1
        End Get
    End Property

    Private Sub Uc_langObject1_ObjectListChanged(sender As Object, e As EventArgs) Handles Uc_SimpleObject1.ObjectListChanged
        Me.Refresh()
        MsgBox(String.Format("В списке {0} позиций", Me.Uc_SimpleObject1.SelectedObjects.Count))

    End Sub
    Private Sub Uc_SimpleObject1_Load(sender As Object, e As EventArgs) Handles Uc_SimpleObject1.Load

    End Sub
End Class