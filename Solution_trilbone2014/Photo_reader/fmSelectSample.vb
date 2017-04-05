Public Class fmSelectSample
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Public Sub New(ByVal SampleNumbers As String(), ByVal caption As String)
        InitializeComponent()
        Me.StartPosition = FormStartPosition.CenterParent
        Me.lbSampleNumbers.DataSource = SampleNumbers
        Me.Text = caption


    End Sub
    Public ReadOnly Property SelectedNumber As String
        Get
            If Me.lbSampleNumbers.SelectedItem Is Nothing Then
                Return ""
            End If
            Return Me.lbSampleNumbers.SelectedItem.ToString
        End Get
    End Property


    Private Sub lbSampleNumbers_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbSampleNumbers.SelectedIndexChanged

        If lbSampleNumbers.SelectedItem Is Nothing Then
            Me.lbSelected.Text = "no selected"
            Me.btSelect.Enabled = False
        Else
            Me.lbSelected.Text = lbSampleNumbers.SelectedItem.ToString
            Me.btSelect.Enabled = True
        End If


    End Sub

    Private Sub btSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSelect.Click
        Me.Close()
    End Sub

    Private Sub fmSelectSample_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
        Me.KeyPress, lbSampleNumbers.KeyPress
        If Asc(e.KeyChar) = 27 Then
            Me.Close()
        End If
    End Sub
End Class