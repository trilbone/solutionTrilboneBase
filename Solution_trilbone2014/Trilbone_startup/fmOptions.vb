Imports Service.clsApplicationTypes
Public Class fmOptions

    Private Sub fmOptions_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With Me
            .tbArhivePhotoPath.Text = ArhiveContainerPath
            .tbPhotoManagerFolder.Text = PhotoManagerStarUpFolder
            .tbDrawDescrFolder.Text = LabelDrawDescriptionPath
            .cbxeBayEnabled.Checked = EbayBackgroundQueryEnabled
            .cbxExcelEnabled.Checked = ExcelEnabled
            .cbFtpModeActive.Checked = FtpModeActive
            .tbTreeFolder.Text = TreeFolderPath

            If GetAccess("Доступ к заказам") Then
                .tbOrdersPath.Text = OrdersPath
                .tbOptimizeImageSize.Text = OptimizeImageWight.ToString
                .cbxeBayEnabled.Enabled = True
            Else
                .tbOrdersPath.Text = ""
                .tbOrdersPath.Enabled = False
                .tbOptimizeImageSize.Enabled = False
                .cbxeBayEnabled.Enabled = False
            End If

            'файлы!!!
            '.tbFossilFilePath.Text = LocalDataFilePath
            '.tbSampleXmlDataFile.Text = xmldboPhotoStorePath
            '.tbExcelPath.Text = ExcelBookPath
        End With

    End Sub



    Private Sub btSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSave.Click
        With Me
            ArhiveContainerPath = .tbArhivePhotoPath.Text
            PhotoManagerStarUpFolder = .tbPhotoManagerFolder.Text
            LabelDrawDescriptionPath = .tbDrawDescrFolder.Text
            ExcelEnabled = .cbxExcelEnabled.Checked
            FtpModeActive = .cbFtpModeActive.Checked
            TreeFolderPath = .tbTreeFolder.Text
            If GetAccess("Доступ к заказам") Then
                OrdersPath = .tbOrdersPath.Text
                OptimizeImageWight = CType(.tbOptimizeImageSize.Text, Integer)
                EbayBackgroundQueryEnabled = .cbxeBayEnabled.Checked
            End If

            'LocalDataFilePath = .tbFossilFilePath.Text
            'xmldboPhotoStorePath = .tbSampleXmlDataFile.Text
            'ExcelBookPath = .tbExcelPath.Text
        End With
        MsgBox("Опции записаны", vbInformation)
        Me.Close()
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub cbxeBayEnabled_CheckedChanged(sender As Object, e As EventArgs) Handles cbxeBayEnabled.CheckedChanged

    End Sub
End Class