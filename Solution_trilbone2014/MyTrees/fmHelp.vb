Public Class fmHelp

    Private Sub fmHelp_Deactivate(sender As Object, e As System.EventArgs) Handles Me.Deactivate
        My.Settings.Help = Me.RichTextBox1.Text
        My.Settings.Save()
    End Sub


    Private Sub fmHelp_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.RichTextBox1.Text = My.Settings.Help
    End Sub
End Class