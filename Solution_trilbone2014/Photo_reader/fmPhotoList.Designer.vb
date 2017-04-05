Imports Service.clsApplicationTypes
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fmPhotoList
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
        Me.components = New System.ComponentModel.Container()
        Me.ImageListMain = New System.Windows.Forms.ImageList(Me.components)
        Me.ListViewMain = New System.Windows.Forms.ListView()
        Me.cbSeriesSelect = New System.Windows.Forms.ComboBox()
        Me.lbNumbers = New System.Windows.Forms.ListBox()
        Me.ClsSampleNumberBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.btShowImages = New System.Windows.Forms.Button()
        Me.lbLoadFile = New System.Windows.Forms.Label()
        Me.btSelectAll = New System.Windows.Forms.Button()
        Me.btUnSelectAll = New System.Windows.Forms.Button()
        Me.tbFindNumber = New System.Windows.Forms.TextBox()
        Me.btRunFind = New System.Windows.Forms.Button()
        Me.cbxOptimization = New System.Windows.Forms.CheckBox()
        Me.btShowSampleData = New System.Windows.Forms.Button()
        Me.CbOnlyReadyForSale = New System.Windows.Forms.CheckBox()
        Me.CbFolderSelect = New System.Windows.Forms.ComboBox()
        Me.btReadyForSale = New System.Windows.Forms.Button()
        Me.btImageManager = New System.Windows.Forms.Button()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.cbOnlyArhiveAbsent = New System.Windows.Forms.CheckBox()
        Me.cbOnlyAzureAbsent = New System.Windows.Forms.CheckBox()
        Me.btCopyToSource = New System.Windows.Forms.Button()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.btAutoImages = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btShowAllMainImages = New System.Windows.Forms.Button()
        Me.btCopyToAZURE = New System.Windows.Forms.Button()
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        CType(Me.ClsSampleNumberBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ImageListMain
        '
        Me.ImageListMain.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
        Me.ImageListMain.ImageSize = New System.Drawing.Size(80, 60)
        Me.ImageListMain.TransparentColor = System.Drawing.Color.Transparent
        '
        'ListViewMain
        '
        Me.ListViewMain.CheckBoxes = True
        Me.ListViewMain.GridLines = True
        Me.ListViewMain.Location = New System.Drawing.Point(254, 39)
        Me.ListViewMain.Name = "ListViewMain"
        Me.ListViewMain.Size = New System.Drawing.Size(660, 468)
        Me.ListViewMain.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.ListViewMain.TabIndex = 0
        Me.ListViewMain.UseCompatibleStateImageBehavior = False
        '
        'cbSeriesSelect
        '
        Me.cbSeriesSelect.FormattingEnabled = True
        Me.cbSeriesSelect.Location = New System.Drawing.Point(12, 81)
        Me.cbSeriesSelect.Name = "cbSeriesSelect"
        Me.cbSeriesSelect.Size = New System.Drawing.Size(91, 21)
        Me.cbSeriesSelect.TabIndex = 1
        '
        'lbNumbers
        '
        Me.lbNumbers.DataSource = Me.ClsSampleNumberBindingSource
        Me.lbNumbers.DisplayMember = "code"
        Me.lbNumbers.FormattingEnabled = True
        Me.lbNumbers.Location = New System.Drawing.Point(12, 182)
        Me.lbNumbers.Name = "lbNumbers"
        Me.lbNumbers.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lbNumbers.Size = New System.Drawing.Size(199, 225)
        Me.lbNumbers.Sorted = True
        Me.lbNumbers.TabIndex = 2
        Me.lbNumbers.ValueMember = "code"
        '
        'ClsSampleNumberBindingSource
        '
        Me.ClsSampleNumberBindingSource.DataSource = GetType(Service.clsApplicationTypes.clsSampleNumber)
        '
        'btShowImages
        '
        Me.btShowImages.Location = New System.Drawing.Point(12, 455)
        Me.btShowImages.Name = "btShowImages"
        Me.btShowImages.Size = New System.Drawing.Size(236, 23)
        Me.btShowImages.TabIndex = 4
        Me.btShowImages.Text = "Показать все фото для текущего образца"
        Me.btShowImages.UseVisualStyleBackColor = True
        '
        'lbLoadFile
        '
        Me.lbLoadFile.AutoSize = True
        Me.lbLoadFile.Location = New System.Drawing.Point(12, 410)
        Me.lbLoadFile.Name = "lbLoadFile"
        Me.lbLoadFile.Size = New System.Drawing.Size(29, 13)
        Me.lbLoadFile.TabIndex = 6
        Me.lbLoadFile.Text = "label"
        '
        'btSelectAll
        '
        Me.btSelectAll.Location = New System.Drawing.Point(281, 8)
        Me.btSelectAll.Name = "btSelectAll"
        Me.btSelectAll.Size = New System.Drawing.Size(75, 23)
        Me.btSelectAll.TabIndex = 8
        Me.btSelectAll.Text = "Select all"
        Me.btSelectAll.UseVisualStyleBackColor = True
        '
        'btUnSelectAll
        '
        Me.btUnSelectAll.Location = New System.Drawing.Point(362, 8)
        Me.btUnSelectAll.Name = "btUnSelectAll"
        Me.btUnSelectAll.Size = New System.Drawing.Size(75, 23)
        Me.btUnSelectAll.TabIndex = 9
        Me.btUnSelectAll.Text = "Unselect all"
        Me.btUnSelectAll.UseVisualStyleBackColor = True
        '
        'tbFindNumber
        '
        Me.tbFindNumber.Location = New System.Drawing.Point(143, 8)
        Me.tbFindNumber.Name = "tbFindNumber"
        Me.tbFindNumber.Size = New System.Drawing.Size(91, 20)
        Me.tbFindNumber.TabIndex = 10
        '
        'btRunFind
        '
        Me.btRunFind.Location = New System.Drawing.Point(143, 34)
        Me.btRunFind.Name = "btRunFind"
        Me.btRunFind.Size = New System.Drawing.Size(91, 20)
        Me.btRunFind.TabIndex = 11
        Me.btRunFind.Text = "Find.."
        Me.btRunFind.UseVisualStyleBackColor = True
        '
        'cbxOptimization
        '
        Me.cbxOptimization.AutoSize = True
        Me.cbxOptimization.Checked = True
        Me.cbxOptimization.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbxOptimization.Location = New System.Drawing.Point(271, 561)
        Me.cbxOptimization.Name = "cbxOptimization"
        Me.cbxOptimization.Size = New System.Drawing.Size(117, 17)
        Me.cbxOptimization.TabIndex = 12
        Me.cbxOptimization.Text = "Enable optimization"
        Me.cbxOptimization.UseVisualStyleBackColor = True
        '
        'btShowSampleData
        '
        Me.btShowSampleData.Location = New System.Drawing.Point(447, 528)
        Me.btShowSampleData.Name = "btShowSampleData"
        Me.btShowSampleData.Size = New System.Drawing.Size(127, 23)
        Me.btShowSampleData.TabIndex = 13
        Me.btShowSampleData.Text = "Данные образца.."
        Me.btShowSampleData.UseVisualStyleBackColor = True
        '
        'CbOnlyReadyForSale
        '
        Me.CbOnlyReadyForSale.AutoSize = True
        Me.CbOnlyReadyForSale.Location = New System.Drawing.Point(12, 115)
        Me.CbOnlyReadyForSale.Name = "CbOnlyReadyForSale"
        Me.CbOnlyReadyForSale.Size = New System.Drawing.Size(169, 17)
        Me.CbOnlyReadyForSale.TabIndex = 14
        Me.CbOnlyReadyForSale.Text = "Только готовые на продажу"
        Me.CbOnlyReadyForSale.UseVisualStyleBackColor = True
        '
        'CbFolderSelect
        '
        Me.CbFolderSelect.FormattingEnabled = True
        Me.CbFolderSelect.Location = New System.Drawing.Point(15, 30)
        Me.CbFolderSelect.Name = "CbFolderSelect"
        Me.CbFolderSelect.Size = New System.Drawing.Size(91, 21)
        Me.CbFolderSelect.TabIndex = 15
        '
        'btReadyForSale
        '
        Me.btReadyForSale.Location = New System.Drawing.Point(593, 528)
        Me.btReadyForSale.Name = "btReadyForSale"
        Me.btReadyForSale.Size = New System.Drawing.Size(170, 23)
        Me.btReadyForSale.TabIndex = 16
        Me.btReadyForSale.Text = "Подготовить к продаже.."
        Me.btReadyForSale.UseVisualStyleBackColor = True
        '
        'btImageManager
        '
        Me.btImageManager.Location = New System.Drawing.Point(256, 528)
        Me.btImageManager.Name = "btImageManager"
        Me.btImageManager.Size = New System.Drawing.Size(173, 23)
        Me.btImageManager.TabIndex = 17
        Me.btImageManager.Text = "Менеджер фото"
        Me.btImageManager.UseVisualStyleBackColor = True
        '
        'cbOnlyArhiveAbsent
        '
        Me.cbOnlyArhiveAbsent.AutoSize = True
        Me.cbOnlyArhiveAbsent.Location = New System.Drawing.Point(12, 138)
        Me.cbOnlyArhiveAbsent.Name = "cbOnlyArhiveAbsent"
        Me.cbOnlyArhiveAbsent.Size = New System.Drawing.Size(188, 17)
        Me.cbOnlyArhiveAbsent.TabIndex = 18
        Me.cbOnlyArhiveAbsent.Text = "Только не занесенные  в Arhive"
        Me.cbOnlyArhiveAbsent.UseVisualStyleBackColor = True
        '
        'cbOnlyAzureAbsent
        '
        Me.cbOnlyAzureAbsent.AutoSize = True
        Me.cbOnlyAzureAbsent.Location = New System.Drawing.Point(12, 159)
        Me.cbOnlyAzureAbsent.Name = "cbOnlyAzureAbsent"
        Me.cbOnlyAzureAbsent.Size = New System.Drawing.Size(182, 17)
        Me.cbOnlyAzureAbsent.TabIndex = 19
        Me.cbOnlyAzureAbsent.Text = "Только не занесенные в Azure"
        Me.cbOnlyAzureAbsent.UseVisualStyleBackColor = True
        '
        'btCopyToSource
        '
        Me.btCopyToSource.Location = New System.Drawing.Point(394, 557)
        Me.btCopyToSource.Name = "btCopyToSource"
        Me.btCopyToSource.Size = New System.Drawing.Size(258, 23)
        Me.btCopyToSource.TabIndex = 20
        Me.btCopyToSource.Text = "Скопировать отмеченные на устройство Arhive"
        Me.btCopyToSource.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 593)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(928, 22)
        Me.StatusStrip1.TabIndex = 21
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(121, 17)
        Me.ToolStripStatusLabel1.Text = "ToolStripStatusLabel1"
        '
        'btAutoImages
        '
        Me.btAutoImages.Enabled = False
        Me.btAutoImages.Location = New System.Drawing.Point(12, 513)
        Me.btAutoImages.Name = "btAutoImages"
        Me.btAutoImages.Size = New System.Drawing.Size(199, 23)
        Me.btAutoImages.TabIndex = 31
        Me.btAutoImages.Text = "Автозанесение выделеных.."
        Me.btAutoImages.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 13)
        Me.Label1.TabIndex = 32
        Me.Label1.Text = "Источник фото"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 63)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 33
        Me.Label2.Text = "Серия"
        '
        'btShowAllMainImages
        '
        Me.btShowAllMainImages.Location = New System.Drawing.Point(12, 484)
        Me.btShowAllMainImages.Name = "btShowAllMainImages"
        Me.btShowAllMainImages.Size = New System.Drawing.Size(199, 23)
        Me.btShowAllMainImages.TabIndex = 34
        Me.btShowAllMainImages.Text = "Показать все выделенные"
        Me.btShowAllMainImages.UseVisualStyleBackColor = True
        '
        'btCopyToAZURE
        '
        Me.btCopyToAZURE.Location = New System.Drawing.Point(658, 557)
        Me.btCopyToAZURE.Name = "btCopyToAZURE"
        Me.btCopyToAZURE.Size = New System.Drawing.Size(258, 23)
        Me.btCopyToAZURE.TabIndex = 35
        Me.btCopyToAZURE.Text = "Скопировать отмеченные на устройство Azure"
        Me.btCopyToAZURE.UseVisualStyleBackColor = True
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.Location = New System.Drawing.Point(165, 429)
        Me.NumericUpDown1.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(46, 20)
        Me.NumericUpDown1.TabIndex = 36
        Me.NumericUpDown1.Value = New Decimal(New Integer() {4, 0, 0, 0})
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(61, 433)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 13)
        Me.Label3.TabIndex = 37
        Me.Label3.Text = "+- от выделенного"
        '
        'fmPhotoList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(928, 615)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.NumericUpDown1)
        Me.Controls.Add(Me.btCopyToAZURE)
        Me.Controls.Add(Me.btShowAllMainImages)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btAutoImages)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.btCopyToSource)
        Me.Controls.Add(Me.cbOnlyAzureAbsent)
        Me.Controls.Add(Me.cbOnlyArhiveAbsent)
        Me.Controls.Add(Me.btImageManager)
        Me.Controls.Add(Me.btReadyForSale)
        Me.Controls.Add(Me.CbFolderSelect)
        Me.Controls.Add(Me.CbOnlyReadyForSale)
        Me.Controls.Add(Me.btShowSampleData)
        Me.Controls.Add(Me.cbxOptimization)
        Me.Controls.Add(Me.btRunFind)
        Me.Controls.Add(Me.tbFindNumber)
        Me.Controls.Add(Me.btUnSelectAll)
        Me.Controls.Add(Me.btSelectAll)
        Me.Controls.Add(Me.lbLoadFile)
        Me.Controls.Add(Me.btShowImages)
        Me.Controls.Add(Me.lbNumbers)
        Me.Controls.Add(Me.cbSeriesSelect)
        Me.Controls.Add(Me.ListViewMain)
        Me.Name = "fmPhotoList"
        Me.Text = "Списки фото"
        CType(Me.ClsSampleNumberBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ImageListMain As System.Windows.Forms.ImageList
    Friend WithEvents ListViewMain As System.Windows.Forms.ListView
    Friend WithEvents cbSeriesSelect As System.Windows.Forms.ComboBox
    Friend WithEvents lbNumbers As System.Windows.Forms.ListBox
    Friend WithEvents btShowImages As System.Windows.Forms.Button
    Friend WithEvents lbLoadFile As System.Windows.Forms.Label
    Friend WithEvents btSelectAll As System.Windows.Forms.Button
    Friend WithEvents btUnSelectAll As System.Windows.Forms.Button
    Friend WithEvents tbFindNumber As System.Windows.Forms.TextBox
    Friend WithEvents btRunFind As System.Windows.Forms.Button
    Friend WithEvents cbxOptimization As System.Windows.Forms.CheckBox
    Friend WithEvents btShowSampleData As System.Windows.Forms.Button
    Friend WithEvents CbOnlyReadyForSale As System.Windows.Forms.CheckBox
    Friend WithEvents CbFolderSelect As System.Windows.Forms.ComboBox
    Friend WithEvents btReadyForSale As System.Windows.Forms.Button
    Friend WithEvents ClsSampleNumberBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents btImageManager As System.Windows.Forms.Button
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents cbOnlyArhiveAbsent As System.Windows.Forms.CheckBox
    Friend WithEvents cbOnlyAzureAbsent As System.Windows.Forms.CheckBox
    Friend WithEvents btCopyToSource As System.Windows.Forms.Button
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents btAutoImages As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btShowAllMainImages As System.Windows.Forms.Button
    Friend WithEvents btCopyToAZURE As System.Windows.Forms.Button
    Friend WithEvents NumericUpDown1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label3 As System.Windows.Forms.Label

End Class
