Public Class fmSelectMaterial

    Public Sub New()

        ' Этот вызов является обязательным для конструктора.
        InitializeComponent()

        ' Добавьте все инициализирующие действия после вызова InitializeComponent().
        btApply.Enabled = False
    End Sub
    Private Sub btApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btApply.Click
        Me.Close()
    End Sub

    Private Sub cbMaterial_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbMaterial.SelectedIndexChanged
        Me.btApply.Enabled = True
    End Sub


   
End Class