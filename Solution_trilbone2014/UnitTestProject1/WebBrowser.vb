Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()> Public Class UnitTestWebBrowser

    <TestMethod()> Public Sub TestMethodZoom()
        Dim _fm As New Windows.Forms.Form
        Dim _wb As New Windows.Forms.WebBrowser
        _wb.Dock = Windows.Forms.DockStyle.Fill
        AddHandler _wb.DocumentCompleted, AddressOf browser_LoadCompleted
        With _fm
            .Size = New Drawing.Size(500, 500)
            .Controls.Add(_wb)
        End With
        _fm.Show()
        _wb.Navigate("https://www.google.ru/search?q=ExecWB&oq=ExecWB&aqs=chrome..69i57j69i60j69i61&sourceid=chrome&es_sm=122&ie=UTF-8")

        Windows.Forms.Application.Run(_fm)
    End Sub

    Private Sub browser_LoadCompleted(sender As Object, e As Windows.Forms.WebBrowserDocumentCompletedEventArgs)
        CType(sender, Windows.Forms.WebBrowser).Zoom(70)
    End Sub


End Class