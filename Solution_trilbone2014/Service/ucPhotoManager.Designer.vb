<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucPhotoManager
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ucPhotoManager))
        Me.btClearLines = New System.Windows.Forms.Button()
        Me.cbLineColor = New System.Windows.Forms.ComboBox()
        Me.rbArrow = New System.Windows.Forms.RadioButton()
        Me.rbLine = New System.Windows.Forms.RadioButton()
        Me.nudFontSize = New System.Windows.Forms.NumericUpDown()
        Me.tbTextPanel = New System.Windows.Forms.TextBox()
        Me.rbText = New System.Windows.Forms.RadioButton()
        Me.rbRectangle = New System.Windows.Forms.RadioButton()
        Me.btSaveMaps = New System.Windows.Forms.Button()
        Me.btRefreshLayer = New System.Windows.Forms.Button()
        Me.bs_images = New System.Windows.Forms.BindingSource(Me.components)
        Me.BindingNavigator1 = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel()
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox()
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorAddNewItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorDeleteItem = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonAddOneImage = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButtonUploadToFtp = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripComboBoxFtp = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.tsbDeleteFtp = New System.Windows.Forms.ToolStripButton()
        Me.btMainImage = New System.Windows.Forms.Button()
        Me.ToolStripButtonOpenFolder = New System.Windows.Forms.ToolStripButton()
        CType(Me.nudFontSize, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bs_images, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingNavigator1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BindingNavigator1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btClearLines
        '
        Me.btClearLines.Location = New System.Drawing.Point(251, 429)
        Me.btClearLines.Name = "btClearLines"
        Me.btClearLines.Size = New System.Drawing.Size(28, 23)
        Me.btClearLines.TabIndex = 22
        Me.btClearLines.Text = "X"
        Me.btClearLines.UseVisualStyleBackColor = True
        '
        'cbLineColor
        '
        Me.cbLineColor.FormattingEnabled = True
        Me.cbLineColor.Location = New System.Drawing.Point(337, 398)
        Me.cbLineColor.Name = "cbLineColor"
        Me.cbLineColor.Size = New System.Drawing.Size(110, 21)
        Me.cbLineColor.TabIndex = 21
        '
        'rbArrow
        '
        Me.rbArrow.AutoSize = True
        Me.rbArrow.Location = New System.Drawing.Point(95, 429)
        Me.rbArrow.Name = "rbArrow"
        Me.rbArrow.Size = New System.Drawing.Size(87, 17)
        Me.rbArrow.TabIndex = 20
        Me.rbArrow.TabStop = True
        Me.rbArrow.Text = "Стрелка (№)"
        Me.rbArrow.UseVisualStyleBackColor = True
        '
        'rbLine
        '
        Me.rbLine.AutoSize = True
        Me.rbLine.Location = New System.Drawing.Point(188, 431)
        Me.rbLine.Name = "rbLine"
        Me.rbLine.Size = New System.Drawing.Size(57, 17)
        Me.rbLine.TabIndex = 19
        Me.rbLine.TabStop = True
        Me.rbLine.Text = "Линия"
        Me.rbLine.UseVisualStyleBackColor = True
        '
        'nudFontSize
        '
        Me.nudFontSize.Location = New System.Drawing.Point(407, 431)
        Me.nudFontSize.Minimum = New Decimal(New Integer() {4, 0, 0, 0})
        Me.nudFontSize.Name = "nudFontSize"
        Me.nudFontSize.Size = New System.Drawing.Size(40, 20)
        Me.nudFontSize.TabIndex = 18
        Me.nudFontSize.Value = New Decimal(New Integer() {4, 0, 0, 0})
        '
        'tbTextPanel
        '
        Me.tbTextPanel.Location = New System.Drawing.Point(337, 431)
        Me.tbTextPanel.Name = "tbTextPanel"
        Me.tbTextPanel.Size = New System.Drawing.Size(56, 20)
        Me.tbTextPanel.TabIndex = 17
        '
        'rbText
        '
        Me.rbText.AutoSize = True
        Me.rbText.Location = New System.Drawing.Point(188, 399)
        Me.rbText.Name = "rbText"
        Me.rbText.Size = New System.Drawing.Size(67, 17)
        Me.rbText.TabIndex = 16
        Me.rbText.Text = "Квадрат"
        Me.rbText.UseVisualStyleBackColor = True
        '
        'rbRectangle
        '
        Me.rbRectangle.AutoSize = True
        Me.rbRectangle.Checked = True
        Me.rbRectangle.Location = New System.Drawing.Point(95, 399)
        Me.rbRectangle.Name = "rbRectangle"
        Me.rbRectangle.Size = New System.Drawing.Size(87, 17)
        Me.rbRectangle.TabIndex = 15
        Me.rbRectangle.TabStop = True
        Me.rbRectangle.Text = "Квадрат (№)"
        Me.rbRectangle.UseVisualStyleBackColor = True
        '
        'btSaveMaps
        '
        Me.btSaveMaps.Location = New System.Drawing.Point(461, 408)
        Me.btSaveMaps.Name = "btSaveMaps"
        Me.btSaveMaps.Size = New System.Drawing.Size(75, 47)
        Me.btSaveMaps.TabIndex = 14
        Me.btSaveMaps.Text = "Сохранить"
        Me.btSaveMaps.UseVisualStyleBackColor = True
        '
        'btRefreshLayer
        '
        Me.btRefreshLayer.Location = New System.Drawing.Point(2, 408)
        Me.btRefreshLayer.Name = "btRefreshLayer"
        Me.btRefreshLayer.Size = New System.Drawing.Size(66, 47)
        Me.btRefreshLayer.TabIndex = 13
        Me.btRefreshLayer.Text = "Очистить"
        Me.btRefreshLayer.UseVisualStyleBackColor = True
        '
        'bs_images
        '
        '
        'BindingNavigator1
        '
        Me.BindingNavigator1.AddNewItem = Nothing
        Me.BindingNavigator1.BindingSource = Me.bs_images
        Me.BindingNavigator1.CountItem = Me.BindingNavigatorCountItem
        Me.BindingNavigator1.DeleteItem = Nothing
        Me.BindingNavigator1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BindingNavigator1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem, Me.ToolStripButtonAddOneImage, Me.ToolStripSeparator2, Me.ToolStripButtonUploadToFtp, Me.ToolStripComboBoxFtp, Me.ToolStripLabel1, Me.tsbDeleteFtp, Me.ToolStripButtonOpenFolder})
        Me.BindingNavigator1.Location = New System.Drawing.Point(0, 462)
        Me.BindingNavigator1.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.BindingNavigator1.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.BindingNavigator1.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.BindingNavigator1.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.BindingNavigator1.Name = "BindingNavigator1"
        Me.BindingNavigator1.PositionItem = Me.BindingNavigatorPositionItem
        Me.BindingNavigator1.Size = New System.Drawing.Size(542, 25)
        Me.BindingNavigator1.TabIndex = 23
        Me.BindingNavigator1.Text = "BindingNavigator1"
        '
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(43, 22)
        Me.BindingNavigatorCountItem.Text = "для {0}"
        Me.BindingNavigatorCountItem.ToolTipText = "Общее число элементов"
        '
        'BindingNavigatorMoveFirstItem
        '
        Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
        Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveFirstItem.Text = "Переместить в начало"
        '
        'BindingNavigatorMovePreviousItem
        '
        Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
        Me.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMovePreviousItem.Text = "Переместить назад"
        '
        'BindingNavigatorSeparator
        '
        Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorPositionItem
        '
        Me.BindingNavigatorPositionItem.AccessibleName = "Положение"
        Me.BindingNavigatorPositionItem.AutoSize = False
        Me.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem"
        Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(50, 23)
        Me.BindingNavigatorPositionItem.Text = "0"
        Me.BindingNavigatorPositionItem.ToolTipText = "Текущее положение"
        '
        'BindingNavigatorSeparator1
        '
        Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator1"
        Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorMoveNextItem
        '
        Me.BindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveNextItem.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
        Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveNextItem.Text = "Переместить вперед"
        '
        'BindingNavigatorMoveLastItem
        '
        Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
        Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveLastItem.Text = "Переместить в конец"
        '
        'BindingNavigatorSeparator2
        '
        Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2"
        Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorAddNewItem
        '
        Me.BindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorAddNewItem.Image = CType(resources.GetObject("BindingNavigatorAddNewItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorAddNewItem.Name = "BindingNavigatorAddNewItem"
        Me.BindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorAddNewItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorAddNewItem.Text = "Добавить"
        '
        'BindingNavigatorDeleteItem
        '
        Me.BindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorDeleteItem.Image = CType(resources.GetObject("BindingNavigatorDeleteItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorDeleteItem.Name = "BindingNavigatorDeleteItem"
        Me.BindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorDeleteItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorDeleteItem.Text = "Удалить"
        '
        'ToolStripButtonAddOneImage
        '
        Me.ToolStripButtonAddOneImage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButtonAddOneImage.Image = CType(resources.GetObject("ToolStripButtonAddOneImage.Image"), System.Drawing.Image)
        Me.ToolStripButtonAddOneImage.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonAddOneImage.Name = "ToolStripButtonAddOneImage"
        Me.ToolStripButtonAddOneImage.Size = New System.Drawing.Size(47, 22)
        Me.ToolStripButtonAddOneImage.Text = "+фото"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButtonUploadToFtp
        '
        Me.ToolStripButtonUploadToFtp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButtonUploadToFtp.Image = CType(resources.GetObject("ToolStripButtonUploadToFtp.Image"), System.Drawing.Image)
        Me.ToolStripButtonUploadToFtp.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonUploadToFtp.Name = "ToolStripButtonUploadToFtp"
        Me.ToolStripButtonUploadToFtp.Size = New System.Drawing.Size(42, 22)
        Me.ToolStripButtonUploadToFtp.Text = "на ftp"
        '
        'ToolStripComboBoxFtp
        '
        Me.ToolStripComboBoxFtp.Name = "ToolStripComboBoxFtp"
        Me.ToolStripComboBoxFtp.Size = New System.Drawing.Size(75, 25)
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(0, 22)
        '
        'tsbDeleteFtp
        '
        Me.tsbDeleteFtp.Image = CType(resources.GetObject("tsbDeleteFtp.Image"), System.Drawing.Image)
        Me.tsbDeleteFtp.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbDeleteFtp.Name = "tsbDeleteFtp"
        Me.tsbDeleteFtp.Size = New System.Drawing.Size(42, 22)
        Me.tsbDeleteFtp.Text = "ftp"
        '
        'btMainImage
        '
        Me.btMainImage.Location = New System.Drawing.Point(251, 399)
        Me.btMainImage.Name = "btMainImage"
        Me.btMainImage.Size = New System.Drawing.Size(28, 23)
        Me.btMainImage.TabIndex = 24
        Me.btMainImage.Text = "M"
        Me.btMainImage.UseVisualStyleBackColor = True
        '
        'ToolStripButtonOpenFolder
        '
        Me.ToolStripButtonOpenFolder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonOpenFolder.Image = CType(resources.GetObject("ToolStripButtonOpenFolder.Image"), System.Drawing.Image)
        Me.ToolStripButtonOpenFolder.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonOpenFolder.Name = "ToolStripButtonOpenFolder"
        Me.ToolStripButtonOpenFolder.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButtonOpenFolder.Text = "ToolStripButton1"
        '
        'ucPhotoManager
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btMainImage)
        Me.Controls.Add(Me.BindingNavigator1)
        Me.Controls.Add(Me.btClearLines)
        Me.Controls.Add(Me.cbLineColor)
        Me.Controls.Add(Me.rbArrow)
        Me.Controls.Add(Me.rbLine)
        Me.Controls.Add(Me.nudFontSize)
        Me.Controls.Add(Me.tbTextPanel)
        Me.Controls.Add(Me.rbText)
        Me.Controls.Add(Me.rbRectangle)
        Me.Controls.Add(Me.btSaveMaps)
        Me.Controls.Add(Me.btRefreshLayer)
        Me.Name = "ucPhotoManager"
        Me.Size = New System.Drawing.Size(542, 487)
        CType(Me.nudFontSize, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bs_images, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingNavigator1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BindingNavigator1.ResumeLayout(False)
        Me.BindingNavigator1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btClearLines As System.Windows.Forms.Button
    Friend WithEvents cbLineColor As System.Windows.Forms.ComboBox
    Friend WithEvents rbArrow As System.Windows.Forms.RadioButton
    Friend WithEvents rbLine As System.Windows.Forms.RadioButton
    Friend WithEvents nudFontSize As System.Windows.Forms.NumericUpDown
    Friend WithEvents tbTextPanel As System.Windows.Forms.TextBox
    Friend WithEvents rbText As System.Windows.Forms.RadioButton
    Friend WithEvents rbRectangle As System.Windows.Forms.RadioButton
    Friend WithEvents btSaveMaps As System.Windows.Forms.Button
    Friend WithEvents btRefreshLayer As System.Windows.Forms.Button
    Friend WithEvents bs_images As System.Windows.Forms.BindingSource
    Friend WithEvents BindingNavigator1 As System.Windows.Forms.BindingNavigator
    Friend WithEvents BindingNavigatorAddNewItem As System.Windows.Forms.ToolStripButton
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
    Friend WithEvents ToolStripButtonAddOneImage As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButtonUploadToFtp As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripComboBoxFtp As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents btMainImage As System.Windows.Forms.Button
    Friend WithEvents tsbDeleteFtp As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButtonOpenFolder As Windows.Forms.ToolStripButton
End Class
