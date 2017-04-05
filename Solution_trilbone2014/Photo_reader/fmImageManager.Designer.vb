<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fmImageManager
    Inherits System.Windows.Forms.Form

    'Форма переопределяет dispose для очистки списка компонентов.
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

    'Является обязательной для конструктора форм Windows Forms
    Private components As System.ComponentModel.IContainer

    'Примечание: следующая процедура является обязательной для конструктора форм Windows Forms
    'Для ее изменения используйте конструктор форм Windows Form.  
    'Не изменяйте ее в редакторе исходного кода.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.tbSampleNumber = New System.Windows.Forms.TextBox()
        Me.btCheckNumber = New System.Windows.Forms.Button()
        Me.btSelectFolder = New System.Windows.Forms.Button()
        Me.btDeleteFromSource = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lbCountImages = New System.Windows.Forms.Label()
        Me.cbSelectSource_Left = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btSourceShow_Left = New System.Windows.Forms.Button()
        Me.cbOptimization = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btDeleteFromSource2 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbSelectSource2_Right = New System.Windows.Forms.ComboBox()
        Me.lbActivePath = New System.Windows.Forms.Label()
        Me.btSourceShow_Right = New System.Windows.Forms.Button()
        Me.btSourceSelectAll = New System.Windows.Forms.Button()
        Me.btSourceDeselectAll = New System.Windows.Forms.Button()
        Me.lbSourceList = New System.Windows.Forms.Label()
        Me.lbxSourcesList = New System.Windows.Forms.ListBox()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.lvSource = New System.Windows.Forms.ListView()
        Me.lvFolder = New System.Windows.Forms.ListView()
        Me.btCopyToSource = New System.Windows.Forms.Button()
        Me.btFolderDeselectAll = New System.Windows.Forms.Button()
        Me.btFolderSelectAll = New System.Windows.Forms.Button()
        Me.lbSampleInfoText = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pbMainImage = New System.Windows.Forms.PictureBox()
        Me.pbMainImage2 = New System.Windows.Forms.PictureBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.btCopyToRight = New System.Windows.Forms.Button()
        Me.LbImageWidth = New System.Windows.Forms.Label()
        Me.cbxRemoteConnections = New System.Windows.Forms.CheckBox()
        Me.btRename = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.pbMainImage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbMainImage2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tbSampleNumber
        '
        Me.tbSampleNumber.Location = New System.Drawing.Point(12, 10)
        Me.tbSampleNumber.Name = "tbSampleNumber"
        Me.tbSampleNumber.Size = New System.Drawing.Size(120, 20)
        Me.tbSampleNumber.TabIndex = 0
        '
        'btCheckNumber
        '
        Me.btCheckNumber.Location = New System.Drawing.Point(142, 8)
        Me.btCheckNumber.Name = "btCheckNumber"
        Me.btCheckNumber.Size = New System.Drawing.Size(126, 45)
        Me.btCheckNumber.TabIndex = 2
        Me.btCheckNumber.Text = "Проверить номер"
        Me.btCheckNumber.UseVisualStyleBackColor = True
        '
        'btSelectFolder
        '
        Me.btSelectFolder.Location = New System.Drawing.Point(13, 49)
        Me.btSelectFolder.Name = "btSelectFolder"
        Me.btSelectFolder.Size = New System.Drawing.Size(148, 23)
        Me.btSelectFolder.TabIndex = 5
        Me.btSelectFolder.Text = "Фото из папки.."
        Me.btSelectFolder.UseVisualStyleBackColor = True
        '
        'btDeleteFromSource
        '
        Me.btDeleteFromSource.Location = New System.Drawing.Point(136, 117)
        Me.btDeleteFromSource.Name = "btDeleteFromSource"
        Me.btDeleteFromSource.Size = New System.Drawing.Size(195, 23)
        Me.btDeleteFromSource.TabIndex = 9
        Me.btDeleteFromSource.Text = "Удалить выбранное с устройства"
        Me.btDeleteFromSource.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btRename)
        Me.GroupBox1.Controls.Add(Me.lbCountImages)
        Me.GroupBox1.Controls.Add(Me.cbSelectSource_Left)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.btDeleteFromSource)
        Me.GroupBox1.Controls.Add(Me.btSourceShow_Left)
        Me.GroupBox1.Location = New System.Drawing.Point(15, 68)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(337, 146)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Работа с базой"
        '
        'lbCountImages
        '
        Me.lbCountImages.AutoSize = True
        Me.lbCountImages.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lbCountImages.Location = New System.Drawing.Point(22, 67)
        Me.lbCountImages.Name = "lbCountImages"
        Me.lbCountImages.Size = New System.Drawing.Size(49, 20)
        Me.lbCountImages.TabIndex = 18
        Me.lbCountImages.Text = "count"
        '
        'cbSelectSource_Left
        '
        Me.cbSelectSource_Left.FormattingEnabled = True
        Me.cbSelectSource_Left.Location = New System.Drawing.Point(127, 19)
        Me.cbSelectSource_Left.Name = "cbSelectSource_Left"
        Me.cbSelectSource_Left.Size = New System.Drawing.Size(204, 21)
        Me.cbSelectSource_Left.TabIndex = 11
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 22)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Выбор устройства"
        '
        'btSourceShow_Left
        '
        Me.btSourceShow_Left.Location = New System.Drawing.Point(256, 54)
        Me.btSourceShow_Left.Name = "btSourceShow_Left"
        Me.btSourceShow_Left.Size = New System.Drawing.Size(75, 23)
        Me.btSourceShow_Left.TabIndex = 17
        Me.btSourceShow_Left.Text = "Показать.."
        Me.btSourceShow_Left.UseVisualStyleBackColor = True
        '
        'cbOptimization
        '
        Me.cbOptimization.FormattingEnabled = True
        Me.cbOptimization.Location = New System.Drawing.Point(453, 292)
        Me.cbOptimization.Name = "cbOptimization"
        Me.cbOptimization.Size = New System.Drawing.Size(96, 21)
        Me.cbOptimization.TabIndex = 13
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(450, 248)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(104, 31)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Оптимизация при копировании"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btDeleteFromSource2)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.cbSelectSource2_Right)
        Me.GroupBox2.Controls.Add(Me.lbActivePath)
        Me.GroupBox2.Controls.Add(Me.btSelectFolder)
        Me.GroupBox2.Controls.Add(Me.btSourceShow_Right)
        Me.GroupBox2.Location = New System.Drawing.Point(558, 47)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(346, 167)
        Me.GroupBox2.TabIndex = 12
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Работа с папками"
        '
        'btDeleteFromSource2
        '
        Me.btDeleteFromSource2.Location = New System.Drawing.Point(145, 138)
        Me.btDeleteFromSource2.Name = "btDeleteFromSource2"
        Me.btDeleteFromSource2.Size = New System.Drawing.Size(195, 23)
        Me.btDeleteFromSource2.TabIndex = 21
        Me.btDeleteFromSource2.Text = "Удалить выбранное с устройства"
        Me.btDeleteFromSource2.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 13)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "Выбор устройства"
        '
        'cbSelectSource2_Right
        '
        Me.cbSelectSource2_Right.FormattingEnabled = True
        Me.cbSelectSource2_Right.Location = New System.Drawing.Point(115, 19)
        Me.cbSelectSource2_Right.Name = "cbSelectSource2_Right"
        Me.cbSelectSource2_Right.Size = New System.Drawing.Size(225, 21)
        Me.cbSelectSource2_Right.TabIndex = 19
        '
        'lbActivePath
        '
        Me.lbActivePath.Location = New System.Drawing.Point(6, 75)
        Me.lbActivePath.Name = "lbActivePath"
        Me.lbActivePath.Size = New System.Drawing.Size(334, 60)
        Me.lbActivePath.TabIndex = 12
        Me.lbActivePath.Text = "путь:"
        '
        'btSourceShow_Right
        '
        Me.btSourceShow_Right.Location = New System.Drawing.Point(265, 49)
        Me.btSourceShow_Right.Name = "btSourceShow_Right"
        Me.btSourceShow_Right.Size = New System.Drawing.Size(75, 23)
        Me.btSourceShow_Right.TabIndex = 18
        Me.btSourceShow_Right.Text = "Показать.."
        Me.btSourceShow_Right.UseVisualStyleBackColor = True
        '
        'btSourceSelectAll
        '
        Me.btSourceSelectAll.Location = New System.Drawing.Point(15, 217)
        Me.btSourceSelectAll.Name = "btSourceSelectAll"
        Me.btSourceSelectAll.Size = New System.Drawing.Size(120, 23)
        Me.btSourceSelectAll.TabIndex = 13
        Me.btSourceSelectAll.Text = "Выбрать все"
        Me.btSourceSelectAll.UseVisualStyleBackColor = True
        '
        'btSourceDeselectAll
        '
        Me.btSourceDeselectAll.Location = New System.Drawing.Point(142, 217)
        Me.btSourceDeselectAll.Name = "btSourceDeselectAll"
        Me.btSourceDeselectAll.Size = New System.Drawing.Size(75, 23)
        Me.btSourceDeselectAll.TabIndex = 14
        Me.btSourceDeselectAll.Text = "Снять все"
        Me.btSourceDeselectAll.UseVisualStyleBackColor = True
        '
        'lbSourceList
        '
        Me.lbSourceList.AutoSize = True
        Me.lbSourceList.Location = New System.Drawing.Point(375, 53)
        Me.lbSourceList.Name = "lbSourceList"
        Me.lbSourceList.Size = New System.Drawing.Size(144, 13)
        Me.lbSourceList.TabIndex = 15
        Me.lbSourceList.Text = "Фото есть на устройствах:"
        '
        'lbxSourcesList
        '
        Me.lbxSourcesList.FormattingEnabled = True
        Me.lbxSourcesList.Location = New System.Drawing.Point(358, 69)
        Me.lbxSourcesList.Name = "lbxSourcesList"
        Me.lbxSourcesList.Size = New System.Drawing.Size(194, 56)
        Me.lbxSourcesList.TabIndex = 16
        '
        'FolderBrowserDialog1
        '
        Me.FolderBrowserDialog1.ShowNewFolderButton = False
        '
        'lvSource
        '
        Me.lvSource.AllowDrop = True
        Me.lvSource.CheckBoxes = True
        Me.lvSource.Location = New System.Drawing.Point(12, 246)
        Me.lvSource.Name = "lvSource"
        Me.lvSource.Size = New System.Drawing.Size(426, 329)
        Me.lvSource.TabIndex = 3
        Me.lvSource.UseCompatibleStateImageBehavior = False
        '
        'lvFolder
        '
        Me.lvFolder.CheckBoxes = True
        Me.lvFolder.Location = New System.Drawing.Point(564, 246)
        Me.lvFolder.Name = "lvFolder"
        Me.lvFolder.Size = New System.Drawing.Size(426, 329)
        Me.lvFolder.TabIndex = 19
        Me.lvFolder.UseCompatibleStateImageBehavior = False
        '
        'btCopyToSource
        '
        Me.btCopyToSource.Location = New System.Drawing.Point(453, 319)
        Me.btCopyToSource.Name = "btCopyToSource"
        Me.btCopyToSource.Size = New System.Drawing.Size(96, 23)
        Me.btCopyToSource.TabIndex = 6
        Me.btCopyToSource.Text = "<< copy"
        Me.btCopyToSource.UseVisualStyleBackColor = True
        '
        'btFolderDeselectAll
        '
        Me.btFolderDeselectAll.Location = New System.Drawing.Point(692, 217)
        Me.btFolderDeselectAll.Name = "btFolderDeselectAll"
        Me.btFolderDeselectAll.Size = New System.Drawing.Size(75, 23)
        Me.btFolderDeselectAll.TabIndex = 21
        Me.btFolderDeselectAll.Text = "Снять все"
        Me.btFolderDeselectAll.UseVisualStyleBackColor = True
        '
        'btFolderSelectAll
        '
        Me.btFolderSelectAll.Location = New System.Drawing.Point(565, 217)
        Me.btFolderSelectAll.Name = "btFolderSelectAll"
        Me.btFolderSelectAll.Size = New System.Drawing.Size(120, 23)
        Me.btFolderSelectAll.TabIndex = 20
        Me.btFolderSelectAll.Text = "Выбрать все"
        Me.btFolderSelectAll.UseVisualStyleBackColor = True
        '
        'lbSampleInfoText
        '
        Me.lbSampleInfoText.Location = New System.Drawing.Point(290, 5)
        Me.lbSampleInfoText.Name = "lbSampleInfoText"
        Me.lbSampleInfoText.Size = New System.Drawing.Size(700, 39)
        Me.lbSampleInfoText.TabIndex = 22
        Me.lbSampleInfoText.Text = "инфо"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(355, 142)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(164, 35)
        Me.Label2.TabIndex = 23
        Me.Label2.Text = "Задать главное фото - выделить и нажать M"
        '
        'pbMainImage
        '
        Me.pbMainImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbMainImage.Location = New System.Drawing.Point(358, 180)
        Me.pbMainImage.Name = "pbMainImage"
        Me.pbMainImage.Size = New System.Drawing.Size(80, 60)
        Me.pbMainImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbMainImage.TabIndex = 24
        Me.pbMainImage.TabStop = False
        '
        'pbMainImage2
        '
        Me.pbMainImage2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbMainImage2.Location = New System.Drawing.Point(910, 180)
        Me.pbMainImage2.Name = "pbMainImage2"
        Me.pbMainImage2.Size = New System.Drawing.Size(80, 60)
        Me.pbMainImage2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbMainImage2.TabIndex = 25
        Me.pbMainImage2.TabStop = False
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 579)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(997, 22)
        Me.StatusStrip1.TabIndex = 26
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(111, 17)
        Me.ToolStripStatusLabel1.Text = "ToolStripStatusLabel1"
        '
        'btCopyToRight
        '
        Me.btCopyToRight.Location = New System.Drawing.Point(453, 348)
        Me.btCopyToRight.Name = "btCopyToRight"
        Me.btCopyToRight.Size = New System.Drawing.Size(96, 23)
        Me.btCopyToRight.TabIndex = 27
        Me.btCopyToRight.Text = "copy>>"
        Me.btCopyToRight.UseVisualStyleBackColor = True
        '
        'LbImageWidth
        '
        Me.LbImageWidth.Location = New System.Drawing.Point(446, 533)
        Me.LbImageWidth.Name = "LbImageWidth"
        Me.LbImageWidth.Size = New System.Drawing.Size(112, 42)
        Me.LbImageWidth.TabIndex = 28
        Me.LbImageWidth.Text = "Ширина MAX"
        '
        'cbxRemoteConnections
        '
        Me.cbxRemoteConnections.AutoSize = True
        Me.cbxRemoteConnections.Location = New System.Drawing.Point(25, 36)
        Me.cbxRemoteConnections.Name = "cbxRemoteConnections"
        Me.cbxRemoteConnections.Size = New System.Drawing.Size(93, 17)
        Me.cbxRemoteConnections.TabIndex = 29
        Me.cbxRemoteConnections.Text = "+ Удаленные"
        Me.cbxRemoteConnections.UseVisualStyleBackColor = True
        '
        'btRename
        '
        Me.btRename.Location = New System.Drawing.Point(136, 86)
        Me.btRename.Name = "btRename"
        Me.btRename.Size = New System.Drawing.Size(195, 23)
        Me.btRename.TabIndex = 19
        Me.btRename.Text = "Упорядочить и переименовать"
        Me.btRename.UseVisualStyleBackColor = True
        '
        'fmImageManager
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(997, 601)
        Me.Controls.Add(Me.cbxRemoteConnections)
        Me.Controls.Add(Me.LbImageWidth)
        Me.Controls.Add(Me.btCopyToRight)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.pbMainImage2)
        Me.Controls.Add(Me.pbMainImage)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lbSampleInfoText)
        Me.Controls.Add(Me.btFolderDeselectAll)
        Me.Controls.Add(Me.btFolderSelectAll)
        Me.Controls.Add(Me.cbOptimization)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.btCopyToSource)
        Me.Controls.Add(Me.lvFolder)
        Me.Controls.Add(Me.lbxSourcesList)
        Me.Controls.Add(Me.lbSourceList)
        Me.Controls.Add(Me.btSourceDeselectAll)
        Me.Controls.Add(Me.btSourceSelectAll)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lvSource)
        Me.Controls.Add(Me.btCheckNumber)
        Me.Controls.Add(Me.tbSampleNumber)
        Me.Name = "fmImageManager"
        Me.Text = "Image Manager 2.0"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.pbMainImage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbMainImage2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tbSampleNumber As System.Windows.Forms.TextBox
    Friend WithEvents btCheckNumber As System.Windows.Forms.Button
    Friend WithEvents btSelectFolder As System.Windows.Forms.Button
    Friend WithEvents btDeleteFromSource As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cbSelectSource_Left As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btSourceSelectAll As System.Windows.Forms.Button
    Friend WithEvents cbOptimization As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btSourceDeselectAll As System.Windows.Forms.Button
    Friend WithEvents lbSourceList As System.Windows.Forms.Label
    Friend WithEvents lbActivePath As System.Windows.Forms.Label
    Friend WithEvents lbxSourcesList As System.Windows.Forms.ListBox
    Friend WithEvents btSourceShow_Left As System.Windows.Forms.Button
    Friend WithEvents btSourceShow_Right As System.Windows.Forms.Button
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents lvSource As System.Windows.Forms.ListView
    Friend WithEvents lvFolder As System.Windows.Forms.ListView
    Friend WithEvents btCopyToSource As System.Windows.Forms.Button
    Friend WithEvents btFolderDeselectAll As System.Windows.Forms.Button
    Friend WithEvents btFolderSelectAll As System.Windows.Forms.Button
    Friend WithEvents lbSampleInfoText As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents pbMainImage As System.Windows.Forms.PictureBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cbSelectSource2_Right As System.Windows.Forms.ComboBox
    Friend WithEvents pbMainImage2 As System.Windows.Forms.PictureBox
    Friend WithEvents btDeleteFromSource2 As System.Windows.Forms.Button
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents btCopyToRight As System.Windows.Forms.Button
    Friend WithEvents LbImageWidth As System.Windows.Forms.Label
    Friend WithEvents cbxRemoteConnections As System.Windows.Forms.CheckBox
    Friend WithEvents lbCountImages As System.Windows.Forms.Label
    Friend WithEvents btRename As System.Windows.Forms.Button
End Class
