Imports System.Windows.Forms

Public NotInheritable Class SplashScreen1

    Private Sub SplashScreen1_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated
        Application.DoEvents()
        Me.StartPosition = FormStartPosition.CenterParent
    End Sub


End Class
