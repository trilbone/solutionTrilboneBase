<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fmOptions
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tbPhotoView = New System.Windows.Forms.TabPage()
        Me.tbTreeFolder = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cbxExcelEnabled = New System.Windows.Forms.CheckBox()
        Me.cbxeBayEnabled = New System.Windows.Forms.CheckBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.tbDrawDescrFolder = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbPhotoManagerFolder = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.tbOrdersPath = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tbArhivePhotoPath = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btSave = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tbOptimizeImageSize = New System.Windows.Forms.TextBox()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.tbExcelPath = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.tbFossilFilePath = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tbSampleXmlDataFile = New System.Windows.Forms.TextBox()
        Me.cbFtpModeActive = New System.Windows.Forms.CheckBox()
        Me.TabControl1.SuspendLayout()
        Me.tbPhotoView.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tbPhotoView)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Location = New System.Drawing.Point(12, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(550, 529)
        Me.TabControl1.TabIndex = 0
        '
        'tbPhotoView
        '
        Me.tbPhotoView.Controls.Add(Me.cbFtpModeActive)
        Me.tbPhotoView.Controls.Add(Me.tbTreeFolder)
        Me.tbPhotoView.Controls.Add(Me.Label9)
        Me.tbPhotoView.Controls.Add(Me.cbxExcelEnabled)
        Me.tbPhotoView.Controls.Add(Me.cbxeBayEnabled)
        Me.tbPhotoView.Controls.Add(Me.Button1)
        Me.tbPhotoView.Controls.Add(Me.tbDrawDescrFolder)
        Me.tbPhotoView.Controls.Add(Me.Label1)
        Me.tbPhotoView.Controls.Add(Me.tbPhotoManagerFolder)
        Me.tbPhotoView.Controls.Add(Me.Label7)
        Me.tbPhotoView.Controls.Add(Me.tbOrdersPath)
        Me.tbPhotoView.Controls.Add(Me.Label6)
        Me.tbPhotoView.Controls.Add(Me.tbArhivePhotoPath)
        Me.tbPhotoView.Controls.Add(Me.Label2)
        Me.tbPhotoView.Controls.Add(Me.btSave)
        Me.tbPhotoView.Controls.Add(Me.Label3)
        Me.tbPhotoView.Controls.Add(Me.tbOptimizeImageSize)
        Me.tbPhotoView.Location = New System.Drawing.Point(4, 22)
        Me.tbPhotoView.Name = "tbPhotoView"
        Me.tbPhotoView.Padding = New System.Windows.Forms.Padding(3)
        Me.tbPhotoView.Size = New System.Drawing.Size(542, 503)
        Me.tbPhotoView.TabIndex = 0
        Me.tbPhotoView.Text = "Основные"
        Me.tbPhotoView.UseVisualStyleBackColor = True
        '
        'tbTreeFolder
        '
        Me.tbTreeFolder.Location = New System.Drawing.Point(14, 186)
        Me.tbTreeFolder.Name = "tbTreeFolder"
        Me.tbTreeFolder.Size = New System.Drawing.Size(523, 20)
        Me.tbTreeFolder.TabIndex = 35
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(14, 170)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(212, 13)
        Me.Label9.TabIndex = 34
        Me.Label9.Text = "Путь к папке с описаниями (деревьями)"
        '
        'cbxExcelEnabled
        '
        Me.cbxExcelEnabled.AutoSize = True
        Me.cbxExcelEnabled.Location = New System.Drawing.Point(13, 426)
        Me.cbxExcelEnabled.Name = "cbxExcelEnabled"
        Me.cbxExcelEnabled.Size = New System.Drawing.Size(334, 17)
        Me.cbxExcelEnabled.TabIndex = 33
        Me.cbxExcelEnabled.Text = "Офис установлен, использовать файлы Excel для рассчетов"
        Me.cbxExcelEnabled.UseVisualStyleBackColor = True
        '
        'cbxeBayEnabled
        '
        Me.cbxeBayEnabled.AutoSize = True
        Me.cbxeBayEnabled.Location = New System.Drawing.Point(13, 391)
        Me.cbxeBayEnabled.Name = "cbxeBayEnabled"
        Me.cbxeBayEnabled.Size = New System.Drawing.Size(188, 17)
        Me.cbxeBayEnabled.TabIndex = 32
        Me.cbxeBayEnabled.Text = "Запускать фоновый опрос eBay"
        Me.cbxeBayEnabled.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(458, 476)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(78, 21)
        Me.Button1.TabIndex = 24
        Me.Button1.Text = "Cancel"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'tbDrawDescrFolder
        '
        Me.tbDrawDescrFolder.Location = New System.Drawing.Point(13, 86)
        Me.tbDrawDescrFolder.Name = "tbDrawDescrFolder"
        Me.tbDrawDescrFolder.Size = New System.Drawing.Size(523, 20)
        Me.tbDrawDescrFolder.TabIndex = 23
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 70)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(145, 13)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "Путь к папке с этикетками"
        '
        'tbPhotoManagerFolder
        '
        Me.tbPhotoManagerFolder.Location = New System.Drawing.Point(13, 136)
        Me.tbPhotoManagerFolder.Name = "tbPhotoManagerFolder"
        Me.tbPhotoManagerFolder.Size = New System.Drawing.Size(523, 20)
        Me.tbPhotoManagerFolder.TabIndex = 19
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(13, 120)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(204, 13)
        Me.Label7.TabIndex = 18
        Me.Label7.Text = "Путь к папке с фото ОБРАБОТАННЫЕ"
        '
        'tbOrdersPath
        '
        Me.tbOrdersPath.Location = New System.Drawing.Point(13, 286)
        Me.tbOrdersPath.Name = "tbOrdersPath"
        Me.tbOrdersPath.Size = New System.Drawing.Size(523, 20)
        Me.tbOrdersPath.TabIndex = 17
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(13, 270)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(116, 13)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "путь к папке заказов"
        '
        'tbArhivePhotoPath
        '
        Me.tbArhivePhotoPath.Location = New System.Drawing.Point(13, 40)
        Me.tbArhivePhotoPath.Name = "tbArhivePhotoPath"
        Me.tbArhivePhotoPath.Size = New System.Drawing.Size(523, 20)
        Me.tbArhivePhotoPath.TabIndex = 13
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(177, 13)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Путь к контейнеру (папке) с фото"
        '
        'btSave
        '
        Me.btSave.Location = New System.Drawing.Point(363, 476)
        Me.btSave.Name = "btSave"
        Me.btSave.Size = New System.Drawing.Size(78, 21)
        Me.btSave.TabIndex = 8
        Me.btSave.Text = "Save"
        Me.btSave.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 338)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(332, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Размер длинной стороны для оптимизации изображения, пикс."
        '
        'tbOptimizeImageSize
        '
        Me.tbOptimizeImageSize.Location = New System.Drawing.Point(359, 337)
        Me.tbOptimizeImageSize.Name = "tbOptimizeImageSize"
        Me.tbOptimizeImageSize.Size = New System.Drawing.Size(55, 20)
        Me.tbOptimizeImageSize.TabIndex = 6
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.tbExcelPath)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.tbFossilFilePath)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.tbSampleXmlDataFile)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(542, 503)
        Me.TabPage1.TabIndex = 1
        Me.TabPage1.Text = "Дополнительно"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'tbExcelPath
        '
        Me.tbExcelPath.Location = New System.Drawing.Point(6, 140)
        Me.tbExcelPath.Name = "tbExcelPath"
        Me.tbExcelPath.Size = New System.Drawing.Size(523, 20)
        Me.tbExcelPath.TabIndex = 27
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(4, 124)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(227, 13)
        Me.Label8.TabIndex = 26
        Me.Label8.Text = "Путь к папке с файлами Excel для импорта"
        '
        'tbFossilFilePath
        '
        Me.tbFossilFilePath.Location = New System.Drawing.Point(6, 82)
        Me.tbFossilFilePath.Name = "tbFossilFilePath"
        Me.tbFossilFilePath.Size = New System.Drawing.Size(520, 20)
        Me.tbFossilFilePath.TabIndex = 25
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(4, 66)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(259, 13)
        Me.Label5.TabIndex = 24
        Me.Label5.Text = "Путь к файлу с данными локального приложения"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 14)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(222, 13)
        Me.Label4.TabIndex = 23
        Me.Label4.Text = "путь к xml файлу с параметрами образцов"
        '
        'tbSampleXmlDataFile
        '
        Me.tbSampleXmlDataFile.Location = New System.Drawing.Point(8, 33)
        Me.tbSampleXmlDataFile.Name = "tbSampleXmlDataFile"
        Me.tbSampleXmlDataFile.Size = New System.Drawing.Size(523, 20)
        Me.tbSampleXmlDataFile.TabIndex = 22
        '
        'cbFtpModeActive
        '
        Me.cbFtpModeActive.AutoSize = True
        Me.cbFtpModeActive.Location = New System.Drawing.Point(13, 459)
        Me.cbFtpModeActive.Name = "cbFtpModeActive"
        Me.cbFtpModeActive.Size = New System.Drawing.Size(327, 17)
        Me.cbFtpModeActive.TabIndex = 36
        Me.cbFtpModeActive.Text = "Активный режим обмена по ftp (разрешить в брандмауэре)"
        Me.cbFtpModeActive.UseVisualStyleBackColor = True
        '
        'fmOptions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(584, 553)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "fmOptions"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Options"
        Me.TabControl1.ResumeLayout(False)
        Me.tbPhotoView.ResumeLayout(False)
        Me.tbPhotoView.PerformLayout()
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tbPhotoView As System.Windows.Forms.TabPage
    Friend WithEvents btSave As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tbOptimizeImageSize As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tbArhivePhotoPath As System.Windows.Forms.TextBox
    Friend WithEvents tbOrdersPath As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents tbPhotoManagerFolder As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents tbDrawDescrFolder As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents tbExcelPath As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents tbFossilFilePath As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tbSampleXmlDataFile As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents cbxeBayEnabled As System.Windows.Forms.CheckBox
    Friend WithEvents cbxExcelEnabled As System.Windows.Forms.CheckBox
    Friend WithEvents tbTreeFolder As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents cbFtpModeActive As CheckBox
End Class
