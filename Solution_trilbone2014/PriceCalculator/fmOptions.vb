Public Class fmOptions

    Public Sub New()

        ' Этот вызов является обязательным для конструктора.
        InitializeComponent()

        ' Добавьте все инициализирующие действия после вызова InitializeComponent().
        Me.MySettingsBindingSource.DataSource = My.Settings
    End Sub
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        My.Settings.Save()
        MsgBox("Настройки сохранены", vbInformation)
    End Sub

    'Private Sub fmOptions_Load(sender As Object, e As EventArgs) Handles Me.Load
    '    Me.MySettingsBindingSource.DataSource = My.Settings
    'End Sub

    Private Sub btSelectFile_Click(sender As Object, e As EventArgs) Handles btSelectFile.Click
        OpenFileDialog1.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        OpenFileDialog1.FileName = My.Settings.filename
        Select Case Me.OpenFileDialog1.ShowDialog
            Case Windows.Forms.DialogResult.OK
                My.Settings.filename = IO.Path.GetFileName(Me.OpenFileDialog1.FileName)
                My.Settings.fullPath = Me.OpenFileDialog1.FileName
        End Select
    End Sub
End Class