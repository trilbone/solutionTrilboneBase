Public Class fmSelectMaterial

    Public Sub New()

        ' ���� ����� �������� ������������ ��� ������������.
        InitializeComponent()

        ' �������� ��� ���������������� �������� ����� ������ InitializeComponent().
        btApply.Enabled = False
    End Sub
    Private Sub btApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btApply.Click
        Me.Close()
    End Sub

    Private Sub cbMaterial_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbMaterial.SelectedIndexChanged
        Me.btApply.Enabled = True
    End Sub


   
End Class