Imports System.Net
Imports System.IO


Public Class fmBrowser

    Private otmpFileUri As String

    Private Sub New()

        ' Этот вызов является обязательным для конструктора.
        InitializeComponent()

        ' Добавьте все инициализирующие действия после вызова InitializeComponent().

    End Sub
    Private oCatalogName As String
    Private oCulture As Globalization.CultureInfo

    Public Sub New(html As String, Optional CatalogName As String = "NoName", Optional Title As String = "Catalog", Optional culture As Globalization.CultureInfo = Nothing)
        Me.New()
        Me.Text = Title
        Me.oCatalogName = CatalogName
        Me.oCulture = culture

        Me.WebBrowser1.DocumentText = html

    End Sub

    Private Sub btOpenBrowser_Click(sender As System.Object, e As System.EventArgs) Handles btOpenBrowser.Click
        Dim c = New SHDocVw.InternetExplorer
        c.Visible = True
        c.Navigate(Me.tbLink.Text)
    End Sub

    Private Sub btSaveFile_Click(sender As System.Object, e As System.EventArgs) Handles btSaveFile.Click
        Me.SaveFileDialog1.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        Me.SaveFileDialog1.Filter = "веб-страница (*.htm)|*.htm"

        Dim _filename As String = "tmp1.htm"
        If Not Me.oCatalogName = "" Then
            If Not Me.oCulture Is Nothing Then
                _filename = Math.Abs(oCatalogName.GetHashCode Xor oCulture.Name.GetHashCode) & ".htm"
            Else
                _filename = Math.Abs(Me.oCatalogName.GetHashCode) & ".htm"
            End If
        End If

        Me.oFileName = _filename

        Me.SaveFileDialog1.FileName = _filename
        If Me.SaveFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            My.Computer.FileSystem.WriteAllText(SaveFileDialog1.FileName, WebBrowser1.DocumentText, False)
            Me.tbLink.Text = SaveFileDialog1.FileName
            MsgBox("Файл записан", vbInformation)
        End If
    End Sub
    Private oFileName As String

    Private Sub btToSite_Click(sender As System.Object, e As System.EventArgs) Handles btToSite.Click

        Dim _filename As String = oFileName


        If String.IsNullOrEmpty(oFileName) Then
            _filename = oCatalogName & ".htm"
        End If

        Dim _id = clsIDcontent.CreateInstance("test", _filename, clsIDcontent.emContentType.text, False)

        If clsApplicationTypes.SamplePhotoObject.WriteFileToContainer(clsFilesSources.ClientPagesOnTRILBONE, _id, Me.WebBrowser1.DocumentText) > 0 Then
            Dim _uri = clsApplicationTypes.SamplePhotoObject.GetContentURI(_id, clsFilesSources.ClientPagesOnTRILBONE)
            Me.tbLink.Text = _uri.AbsoluteUri
            MsgBox(String.Format("Файл доступен по адресу {0}", _uri.AbsoluteUri, vbInformation))
        Else
            MsgBox("Не удалось записать файл", vbCritical)
        End If

        'Dim _f = New Ftp
        'Dim _onSite As String = "site/wwwroot/Clients/" & oFileName
        'With _f
        '    .Connect("waws-prod-db3-001.ftp.azurewebsites.windows.net")
        '    .Login("plshop\trilboneftp", "Hasmops2009")
        '    .Upload(_onSite, )
        'End With
        '_f.Close()


    End Sub

    Private Sub tbLink_Enter(sender As Object, e As System.EventArgs) Handles tbLink.Enter
        If Me.tbLink.Text = "" Then Return
        '------------------
        Dim _data As String = Me.tbLink.Text
        Try
            My.Computer.Clipboard.Clear()
            My.Computer.Clipboard.SetText(_data)
        Catch ex As Exception
            MsgBox("Ошибка при помещении данных в буфер обмена.", vbCritical)
        End Try
        '-----------------
        MsgBox("Ссылка скопирована", vbInformation)
    End Sub

    Private Sub tbLink_TextChanged(sender As System.Object, e As System.EventArgs) Handles tbLink.TextChanged

    End Sub
End Class