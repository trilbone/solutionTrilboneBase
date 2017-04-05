<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucGoodLabel
    Inherits System.Windows.Forms.UserControl

    'Пользовательский элемент управления (UserControl) переопределяет метод Dispose для очистки списка компонентов.
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ucGoodLabel))
        Me.gbSearchLabel = New System.Windows.Forms.GroupBox()
        Me.cbxOnlyFolder = New System.Windows.Forms.CheckBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.tbPatternSearch = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.nudWorldCount = New System.Windows.Forms.NumericUpDown()
        Me.rbImagesFromDrawAndDescrFolder = New System.Windows.Forms.RadioButton()
        Me.rbDrawAndDescrFolder = New System.Windows.Forms.RadioButton()
        Me.rbLabelFromTrees = New System.Windows.Forms.RadioButton()
        Me.rbFromDB_Text = New System.Windows.Forms.RadioButton()
        Me.BindingNavigatorImages = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.ImageBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel()
        Me.BindingNavigatorDeleteItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox()
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorAddNewItem = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.btRequestLabelsts = New System.Windows.Forms.ToolStripButton()
        Me.lbxLabelsTypes = New System.Windows.Forms.ListBox()
        Me.cbxZoomToPage2 = New System.Windows.Forms.CheckBox()
        Me.btPrinterClear = New System.Windows.Forms.Button()
        Me.lbLabelType = New System.Windows.Forms.Label()
        Me.btClearPrintJob = New System.Windows.Forms.Button()
        Me.btPrintLabel = New System.Windows.Forms.Button()
        Me.btAddLabel = New System.Windows.Forms.Button()
        Me.lbLabelName = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
        Me.gbSearchLabel.SuspendLayout
        CType(Me.nudWorldCount,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.BindingNavigatorImages,System.ComponentModel.ISupportInitialize).BeginInit
        Me.BindingNavigatorImages.SuspendLayout
        CType(Me.ImageBindingSource,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.PictureBox1,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'gbSearchLabel
        '
        Me.gbSearchLabel.Controls.Add(Me.cbxOnlyFolder)
        Me.gbSearchLabel.Controls.Add(Me.Label24)
        Me.gbSearchLabel.Controls.Add(Me.tbPatternSearch)
        Me.gbSearchLabel.Controls.Add(Me.Label23)
        Me.gbSearchLabel.Controls.Add(Me.nudWorldCount)
        Me.gbSearchLabel.Controls.Add(Me.rbImagesFromDrawAndDescrFolder)
        Me.gbSearchLabel.Controls.Add(Me.rbDrawAndDescrFolder)
        Me.gbSearchLabel.Controls.Add(Me.rbLabelFromTrees)
        Me.gbSearchLabel.Controls.Add(Me.rbFromDB_Text)
        Me.gbSearchLabel.Location = New System.Drawing.Point(3, 3)
        Me.gbSearchLabel.Name = "gbSearchLabel"
        Me.gbSearchLabel.Size = New System.Drawing.Size(534, 61)
        Me.gbSearchLabel.TabIndex = 72
        Me.gbSearchLabel.TabStop = false
        Me.gbSearchLabel.Text = "Поиск этикеток"
        '
        'cbxOnlyFolder
        '
        Me.cbxOnlyFolder.AutoSize = true
        Me.cbxOnlyFolder.Checked = true
        Me.cbxOnlyFolder.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbxOnlyFolder.Location = New System.Drawing.Point(386, 14)
        Me.cbxOnlyFolder.Name = "cbxOnlyFolder"
        Me.cbxOnlyFolder.Size = New System.Drawing.Size(100, 17)
        Me.cbxOnlyFolder.TabIndex = 9
        Me.cbxOnlyFolder.Text = "в имени папки"
        Me.cbxOnlyFolder.UseVisualStyleBackColor = true
        '
        'Label24
        '
        Me.Label24.AutoSize = true
        Me.Label24.Location = New System.Drawing.Point(254, 41)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(84, 13)
        Me.Label24.TabIndex = 8
        Me.Label24.Text = "шаблон поиска"
        '
        'tbPatternSearch
        '
        Me.tbPatternSearch.Location = New System.Drawing.Point(344, 37)
        Me.tbPatternSearch.Name = "tbPatternSearch"
        Me.tbPatternSearch.Size = New System.Drawing.Size(169, 20)
        Me.tbPatternSearch.TabIndex = 7
        '
        'Label23
        '
        Me.Label23.AutoSize = true
        Me.Label23.Location = New System.Drawing.Point(246, 15)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(92, 13)
        Me.Label23.TabIndex = 6
        Me.Label23.Text = "Слов для поиска"
        '
        'nudWorldCount
        '
        Me.nudWorldCount.Location = New System.Drawing.Point(344, 11)
        Me.nudWorldCount.Maximum = New Decimal(New Integer() {2, 0, 0, 0})
        Me.nudWorldCount.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudWorldCount.Name = "nudWorldCount"
        Me.nudWorldCount.Size = New System.Drawing.Size(35, 20)
        Me.nudWorldCount.TabIndex = 5
        Me.nudWorldCount.Value = New Decimal(New Integer() {2, 0, 0, 0})
        '
        'rbImagesFromDrawAndDescrFolder
        '
        Me.rbImagesFromDrawAndDescrFolder.AutoSize = true
        Me.rbImagesFromDrawAndDescrFolder.Location = New System.Drawing.Point(116, 40)
        Me.rbImagesFromDrawAndDescrFolder.Name = "rbImagesFromDrawAndDescrFolder"
        Me.rbImagesFromDrawAndDescrFolder.Size = New System.Drawing.Size(126, 17)
        Me.rbImagesFromDrawAndDescrFolder.TabIndex = 4
        Me.rbImagesFromDrawAndDescrFolder.TabStop = true
        Me.rbImagesFromDrawAndDescrFolder.Text = "фото из папки Draw"
        Me.rbImagesFromDrawAndDescrFolder.UseVisualStyleBackColor = true
        '
        'rbDrawAndDescrFolder
        '
        Me.rbDrawAndDescrFolder.AutoSize = true
        Me.rbDrawAndDescrFolder.Location = New System.Drawing.Point(116, 17)
        Me.rbDrawAndDescrFolder.Name = "rbDrawAndDescrFolder"
        Me.rbDrawAndDescrFolder.Size = New System.Drawing.Size(112, 17)
        Me.rbDrawAndDescrFolder.TabIndex = 3
        Me.rbDrawAndDescrFolder.TabStop = true
        Me.rbDrawAndDescrFolder.Text = ".ai из папки Draw"
        Me.rbDrawAndDescrFolder.UseVisualStyleBackColor = true
        '
        'rbLabelFromTrees
        '
        Me.rbLabelFromTrees.AutoSize = true
        Me.rbLabelFromTrees.Location = New System.Drawing.Point(10, 17)
        Me.rbLabelFromTrees.Name = "rbLabelFromTrees"
        Me.rbLabelFromTrees.Size = New System.Drawing.Size(88, 17)
        Me.rbLabelFromTrees.TabIndex = 2
        Me.rbLabelFromTrees.TabStop = true
        Me.rbLabelFromTrees.Text = "из описаний"
        Me.rbLabelFromTrees.UseVisualStyleBackColor = true
        '
        'rbFromDB_Text
        '
        Me.rbFromDB_Text.AutoSize = true
        Me.rbFromDB_Text.Location = New System.Drawing.Point(10, 40)
        Me.rbFromDB_Text.Name = "rbFromDB_Text"
        Me.rbFromDB_Text.Size = New System.Drawing.Size(90, 17)
        Me.rbFromDB_Text.TabIndex = 0
        Me.rbFromDB_Text.TabStop = true
        Me.rbFromDB_Text.Text = "из БД(текст)"
        Me.rbFromDB_Text.UseVisualStyleBackColor = true
        '
        'BindingNavigatorImages
        '
        Me.BindingNavigatorImages.AddNewItem = Nothing
        Me.BindingNavigatorImages.BindingSource = Me.ImageBindingSource
        Me.BindingNavigatorImages.CountItem = Me.BindingNavigatorCountItem
        Me.BindingNavigatorImages.DeleteItem = Me.BindingNavigatorDeleteItem
        Me.BindingNavigatorImages.Dock = System.Windows.Forms.DockStyle.None
        Me.BindingNavigatorImages.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.BindingNavigatorImages.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.ToolStripSeparator4, Me.ToolStripButton2, Me.btRequestLabelsts, Me.BindingNavigatorDeleteItem})
        Me.BindingNavigatorImages.Location = New System.Drawing.Point(3, 67)
        Me.BindingNavigatorImages.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.BindingNavigatorImages.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.BindingNavigatorImages.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.BindingNavigatorImages.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.BindingNavigatorImages.Name = "BindingNavigatorImages"
        Me.BindingNavigatorImages.PositionItem = Me.BindingNavigatorPositionItem
        Me.BindingNavigatorImages.Size = New System.Drawing.Size(517, 27)
        Me.BindingNavigatorImages.TabIndex = 75
        Me.BindingNavigatorImages.Text = "BindingNavigator1"
        '
        'ImageBindingSource
        '
        Me.ImageBindingSource.AllowNew = True
        Me.ImageBindingSource.DataMember = "image"
        '
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(43, 24)
        Me.BindingNavigatorCountItem.Text = "для {0}"
        Me.BindingNavigatorCountItem.ToolTipText = "Общее число элементов"
        '
        'BindingNavigatorDeleteItem
        '
        Me.BindingNavigatorDeleteItem.CheckOnClick = True
        Me.BindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorDeleteItem.Image = CType(resources.GetObject("BindingNavigatorDeleteItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorDeleteItem.Name = "BindingNavigatorDeleteItem"
        Me.BindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorDeleteItem.Size = New System.Drawing.Size(24, 24)
        Me.BindingNavigatorDeleteItem.Text = "поиск"
        '
        'BindingNavigatorMoveFirstItem
        '
        Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
        Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(24, 24)
        Me.BindingNavigatorMoveFirstItem.Text = "Переместить в начало"
        '
        'BindingNavigatorMovePreviousItem
        '
        Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
        Me.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(24, 24)
        Me.BindingNavigatorMovePreviousItem.Text = "Переместить назад"
        '
        'BindingNavigatorSeparator
        '
        Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 27)
        '
        'BindingNavigatorPositionItem
        '
        Me.BindingNavigatorPositionItem.AccessibleName = "Положение"
        Me.BindingNavigatorPositionItem.AutoSize = False
        Me.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem"
        Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(50, 21)
        Me.BindingNavigatorPositionItem.Text = "0"
        Me.BindingNavigatorPositionItem.ToolTipText = "Текущее положение"
        '
        'BindingNavigatorSeparator1
        '
        Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator1"
        Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 27)
        '
        'BindingNavigatorMoveNextItem
        '
        Me.BindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveNextItem.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
        Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(24, 24)
        Me.BindingNavigatorMoveNextItem.Text = "Переместить вперед"
        '
        'BindingNavigatorMoveLastItem
        '
        Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
        Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(24, 24)
        Me.BindingNavigatorMoveLastItem.Text = "Переместить в конец"
        '
        'BindingNavigatorSeparator2
        '
        Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2"
        Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 27)
        '
        'BindingNavigatorAddNewItem
        '
        Me.BindingNavigatorAddNewItem.Image = CType(resources.GetObject("BindingNavigatorAddNewItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorAddNewItem.Name = "BindingNavigatorAddNewItem"
        Me.BindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorAddNewItem.Size = New System.Drawing.Size(73, 24)
        Me.BindingNavigatorAddNewItem.Text = "Этик-ка"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 27)
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(96, 24)
        Me.ToolStripButton2.Text = "Откр. папку"
        '
        'btRequestLabelsts
        '
        Me.btRequestLabelsts.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btRequestLabelsts.Image = CType(resources.GetObject("btRequestLabelsts.Image"), System.Drawing.Image)
        Me.btRequestLabelsts.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btRequestLabelsts.Name = "btRequestLabelsts"
        Me.btRequestLabelsts.Size = New System.Drawing.Size(97, 24)
        Me.btRequestLabelsts.Text = "Поиск этикеток"
        '
        'lbxLabelsTypes
        '
        Me.lbxLabelsTypes.FormattingEnabled = True
        Me.lbxLabelsTypes.Location = New System.Drawing.Point(257, 117)
        Me.lbxLabelsTypes.Name = "lbxLabelsTypes"
        Me.lbxLabelsTypes.Size = New System.Drawing.Size(120, 108)
        Me.lbxLabelsTypes.TabIndex = 91
        '
        'cbxZoomToPage2
        '
        Me.cbxZoomToPage2.Location = New System.Drawing.Point(387, 146)
        Me.cbxZoomToPage2.Name = "cbxZoomToPage2"
        Me.cbxZoomToPage2.Size = New System.Drawing.Size(146, 20)
        Me.cbxZoomToPage2.TabIndex = 90
        Me.cbxZoomToPage2.Text = "растянуть на страницу"
        Me.cbxZoomToPage2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbxZoomToPage2.UseVisualStyleBackColor = true
        '
        'btPrinterClear
        '
        Me.btPrinterClear.Location = New System.Drawing.Point(301, 233)
        Me.btPrinterClear.Name = "btPrinterClear"
        Me.btPrinterClear.Size = New System.Drawing.Size(114, 23)
        Me.btPrinterClear.TabIndex = 89
        Me.btPrinterClear.Text = "Сброс принтеров"
        '
        'lbLabelType
        '
        Me.lbLabelType.AutoSize = true
        Me.lbLabelType.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204,Byte))
        Me.lbLabelType.Location = New System.Drawing.Point(391, 115)
        Me.lbLabelType.Name = "lbLabelType"
        Me.lbLabelType.Size = New System.Drawing.Size(45, 24)
        Me.lbLabelType.TabIndex = 88
        Me.lbLabelType.Text = "тип"
        '
        'btClearPrintJob
        '
        Me.btClearPrintJob.Location = New System.Drawing.Point(423, 233)
        Me.btClearPrintJob.Name = "btClearPrintJob"
        Me.btClearPrintJob.Size = New System.Drawing.Size(114, 23)
        Me.btClearPrintJob.TabIndex = 87
        Me.btClearPrintJob.Text = "Очистить очередь"
        Me.btClearPrintJob.UseVisualStyleBackColor = true
        '
        'btPrintLabel
        '
        Me.btPrintLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204,Byte))
        Me.btPrintLabel.Location = New System.Drawing.Point(389, 204)
        Me.btPrintLabel.Name = "btPrintLabel"
        Me.btPrintLabel.Size = New System.Drawing.Size(148, 23)
        Me.btPrintLabel.TabIndex = 86
        Me.btPrintLabel.Text = "Печать"
        Me.btPrintLabel.UseVisualStyleBackColor = true
        '
        'btAddLabel
        '
        Me.btAddLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204,Byte))
        Me.btAddLabel.Location = New System.Drawing.Point(389, 170)
        Me.btAddLabel.Name = "btAddLabel"
        Me.btAddLabel.Size = New System.Drawing.Size(148, 25)
        Me.btAddLabel.TabIndex = 85
        Me.btAddLabel.Text = "В список печати"
        Me.btAddLabel.UseVisualStyleBackColor = true
        '
        'lbLabelName
        '
        Me.lbLabelName.Location = New System.Drawing.Point(255, 95)
        Me.lbLabelName.Name = "lbLabelName"
        Me.lbLabelName.Size = New System.Drawing.Size(285, 13)
        Me.lbLabelName.TabIndex = 84
        Me.lbLabelName.Text = "имя файла"
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.ErrorImage = Nothing
        Me.PictureBox1.Location = New System.Drawing.Point(3, 95)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(246, 164)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 83
        Me.PictureBox1.TabStop = false
        '
        'PrintPreviewDialog1
        '
        Me.PrintPreviewDialog1.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.ClientSize = New System.Drawing.Size(400, 300)
        Me.PrintPreviewDialog1.Enabled = true
        Me.PrintPreviewDialog1.Icon = CType(resources.GetObject("PrintPreviewDialog1.Icon"),System.Drawing.Icon)
        Me.PrintPreviewDialog1.Name = "PrintPreviewDialog1"
        Me.PrintPreviewDialog1.Visible = false
        '
        'ucGoodLabel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lbxLabelsTypes)
        Me.Controls.Add(Me.cbxZoomToPage2)
        Me.Controls.Add(Me.btPrinterClear)
        Me.Controls.Add(Me.lbLabelType)
        Me.Controls.Add(Me.btClearPrintJob)
        Me.Controls.Add(Me.btPrintLabel)
        Me.Controls.Add(Me.btAddLabel)
        Me.Controls.Add(Me.lbLabelName)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.BindingNavigatorImages)
        Me.Controls.Add(Me.gbSearchLabel)
        Me.Name = "ucGoodLabel"
        Me.Size = New System.Drawing.Size(540, 262)
        Me.gbSearchLabel.ResumeLayout(false)
        Me.gbSearchLabel.PerformLayout
        CType(Me.nudWorldCount,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.BindingNavigatorImages,System.ComponentModel.ISupportInitialize).EndInit
        Me.BindingNavigatorImages.ResumeLayout(false)
        Me.BindingNavigatorImages.PerformLayout
        CType(Me.ImageBindingSource,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.PictureBox1,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents gbSearchLabel As System.Windows.Forms.GroupBox
    Friend WithEvents cbxOnlyFolder As System.Windows.Forms.CheckBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents tbPatternSearch As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents nudWorldCount As System.Windows.Forms.NumericUpDown
    Friend WithEvents rbImagesFromDrawAndDescrFolder As System.Windows.Forms.RadioButton
    Friend WithEvents rbDrawAndDescrFolder As System.Windows.Forms.RadioButton
    Friend WithEvents rbLabelFromTrees As System.Windows.Forms.RadioButton
    Friend WithEvents rbFromDB_Text As System.Windows.Forms.RadioButton
    Friend WithEvents BindingNavigatorImages As System.Windows.Forms.BindingNavigator
    Friend WithEvents BindingNavigatorCountItem As System.Windows.Forms.ToolStripLabel
    Friend WithEvents BindingNavigatorDeleteItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveFirstItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorAddNewItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents btRequestLabelsts As System.Windows.Forms.ToolStripButton
    Friend WithEvents lbxLabelsTypes As System.Windows.Forms.ListBox
    Friend WithEvents cbxZoomToPage2 As System.Windows.Forms.CheckBox
    Friend WithEvents btPrinterClear As System.Windows.Forms.Button
    Friend WithEvents lbLabelType As System.Windows.Forms.Label
    Friend WithEvents btClearPrintJob As System.Windows.Forms.Button
    Friend WithEvents btPrintLabel As System.Windows.Forms.Button
    Friend WithEvents btAddLabel As System.Windows.Forms.Button
    Friend WithEvents lbLabelName As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents ImageBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PrintPreviewDialog1 As System.Windows.Forms.PrintPreviewDialog

End Class
