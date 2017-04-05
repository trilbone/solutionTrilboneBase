Public Class fmTest
    Dim _sp As New spDigitalBoard

    Private Sub Label1_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Label1.MouseClick
        _sp.Connect(Me.TextBox1)
        Me.TextBox1.Focus()
    End Sub

   
    Private Sub Label2_Click(sender As System.Object, e As System.EventArgs) Handles Label2.Click

    End Sub

    Private Sub Label2_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Label2.MouseClick
        _sp.Connect(Me.NumericUpDown1.Controls(1), Me.NumericUpDown1.Maximum)
        Me.NumericUpDown1.Focus()
    End Sub
End Class