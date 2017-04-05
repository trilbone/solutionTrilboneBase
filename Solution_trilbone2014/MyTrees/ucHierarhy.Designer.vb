<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Friend Class ucHierarhy
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
        Dim DescrRUSLabel As System.Windows.Forms.Label
        Dim DescrLabel As System.Windows.Forms.Label
        Dim NameRUSLabel As System.Windows.Forms.Label
        Dim NameLabel As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ucHierarhy))
        Me.btAddDescr = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btCopyNodeValue = New System.Windows.Forms.Button()
        Me.nudLabelsCountCopy = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btCopyNameInBuffer = New System.Windows.Forms.Button()
        Me.lbLabelName = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.btNodeImport = New System.Windows.Forms.Button()
        Me.lbFullPath = New System.Windows.Forms.Label()
        Me.btAddLabel = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.rbExternalLabel = New System.Windows.Forms.RadioButton()
        Me.rbInnerImg = New System.Windows.Forms.RadioButton()
        Me.rbExternalImage = New System.Windows.Forms.RadioButton()
        Me.btCopyDescr = New System.Windows.Forms.Button()
        Me.btCopyName = New System.Windows.Forms.Button()
        Me.BindingNavigatorImages = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorAddNewItem = New System.Windows.Forms.ToolStripButton()
        Me.ImageBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.BindingSourceNodeObject = New System.Windows.Forms.BindingSource(Me.components)
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
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.cmsStandart = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.InsertToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopyToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DescrRUSRichTextBox = New System.Windows.Forms.RichTextBox()
        Me.DescrRichTextBox = New System.Windows.Forms.RichTextBox()
        Me.NameRUSTextBox = New System.Windows.Forms.TextBox()
        Me.NameTextBox = New System.Windows.Forms.TextBox()
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.rtbReadyDescription = New System.Windows.Forms.RichTextBox()
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btRefreshTree = New System.Windows.Forms.Button()
        Me.cmsAddItem = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ДобавитьПослеУзлаToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ДобавитьДоУзлаToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ДобавитьПредкаToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.КопироватьУзелToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.СоздатьСвязьToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.КопироватьПоддеревоToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ВырезатьToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ВставитьToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.УдалитьУзелToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.СлужебныеToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ПрисвоитьНовыйIDToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.УдалитьIDToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.КоррекцияПереместитьНаМеньшийУровеньToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.КоррекцияУзловСОдинаковымHierIDилиПереместитьНаБольшийУровеньToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.ilNodePhoto = New System.Windows.Forms.ImageList(Me.components)
        Me.tbSearch = New System.Windows.Forms.TextBox()
        Me.btSearch = New System.Windows.Forms.Button()
        Me.cbxShowLeaf = New System.Windows.Forms.CheckBox()
        Me.btShowAll = New System.Windows.Forms.Button()
        Me.lbSearchResult = New System.Windows.Forms.Label()
        Me.btAddDescrMUI = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.nudSearchResult = New System.Windows.Forms.NumericUpDown()
        Me.lbArticul = New System.Windows.Forms.Label()
        DescrRUSLabel = New System.Windows.Forms.Label()
        DescrLabel = New System.Windows.Forms.Label()
        NameRUSLabel = New System.Windows.Forms.Label()
        NameLabel = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        CType(Me.nudLabelsCountCopy, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.BindingNavigatorImages, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BindingNavigatorImages.SuspendLayout()
        CType(Me.ImageBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingSourceNodeObject, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsStandart.SuspendLayout()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsAddItem.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.nudSearchResult, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DescrRUSLabel
        '
        DescrRUSLabel.AutoSize = True
        DescrRUSLabel.Location = New System.Drawing.Point(446, 62)
        DescrRUSLabel.Name = "DescrRUSLabel"
        DescrRUSLabel.Size = New System.Drawing.Size(128, 13)
        DescrRUSLabel.TabIndex = 6
        DescrRUSLabel.Text = "Описание на РУССКОМ"
        '
        'DescrLabel
        '
        DescrLabel.AutoSize = True
        DescrLabel.Location = New System.Drawing.Point(145, 64)
        DescrLabel.Name = "DescrLabel"
        DescrLabel.Size = New System.Drawing.Size(151, 13)
        DescrLabel.TabIndex = 4
        DescrLabel.Text = "Описание на АНГЛИЙСКОМ"
        '
        'NameRUSLabel
        '
        NameRUSLabel.AutoSize = True
        NameRUSLabel.Location = New System.Drawing.Point(367, 20)
        NameRUSLabel.Name = "NameRUSLabel"
        NameRUSLabel.Size = New System.Drawing.Size(104, 13)
        NameRUSLabel.TabIndex = 2
        NameRUSLabel.Text = "Узел на РУССКОМ"
        '
        'NameLabel
        '
        NameLabel.AutoSize = True
        NameLabel.Location = New System.Drawing.Point(7, 19)
        NameLabel.Name = "NameLabel"
        NameLabel.Size = New System.Drawing.Size(127, 13)
        NameLabel.TabIndex = 0
        NameLabel.Text = "Узел на АНГЛИЙСКОМ"
        '
        'btAddDescr
        '
        Me.btAddDescr.Location = New System.Drawing.Point(186, 447)
        Me.btAddDescr.Name = "btAddDescr"
        Me.btAddDescr.Size = New System.Drawing.Size(117, 44)
        Me.btAddDescr.TabIndex = 7
        Me.btAddDescr.Text = "добавить в описание"
        Me.btAddDescr.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btCopyNodeValue)
        Me.GroupBox1.Controls.Add(Me.nudLabelsCountCopy)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.btCopyNameInBuffer)
        Me.GroupBox1.Controls.Add(Me.lbLabelName)
        Me.GroupBox1.Controls.Add(Me.GroupBox4)
        Me.GroupBox1.Controls.Add(Me.btAddLabel)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.btCopyDescr)
        Me.GroupBox1.Controls.Add(Me.btCopyName)
        Me.GroupBox1.Controls.Add(Me.BindingNavigatorImages)
        Me.GroupBox1.Controls.Add(Me.PictureBox1)
        Me.GroupBox1.Controls.Add(Me.RichTextBox1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(DescrRUSLabel)
        Me.GroupBox1.Controls.Add(Me.DescrRUSRichTextBox)
        Me.GroupBox1.Controls.Add(DescrLabel)
        Me.GroupBox1.Controls.Add(Me.DescrRichTextBox)
        Me.GroupBox1.Controls.Add(NameRUSLabel)
        Me.GroupBox1.Controls.Add(Me.NameRUSTextBox)
        Me.GroupBox1.Controls.Add(NameLabel)
        Me.GroupBox1.Controls.Add(Me.NameTextBox)
        Me.GroupBox1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BindingSourceNodeObject, "DataFolder", True))
        Me.GroupBox1.Location = New System.Drawing.Point(503, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(652, 533)
        Me.GroupBox1.TabIndex = 17
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Поля данных"
        '
        'btCopyNodeValue
        '
        Me.btCopyNodeValue.AutoSize = True
        Me.btCopyNodeValue.Location = New System.Drawing.Point(90, 37)
        Me.btCopyNodeValue.Name = "btCopyNodeValue"
        Me.btCopyNodeValue.Size = New System.Drawing.Size(101, 23)
        Me.btCopyNodeValue.TabIndex = 37
        Me.btCopyNodeValue.Text = "Копир. значение"
        Me.btCopyNodeValue.UseVisualStyleBackColor = True
        '
        'nudLabelsCountCopy
        '
        Me.nudLabelsCountCopy.Location = New System.Drawing.Point(564, 401)
        Me.nudLabelsCountCopy.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudLabelsCountCopy.Name = "nudLabelsCountCopy"
        Me.nudLabelsCountCopy.Size = New System.Drawing.Size(50, 20)
        Me.nudLabelsCountCopy.TabIndex = 36
        Me.nudLabelsCountCopy.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(471, 405)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(87, 13)
        Me.Label3.TabIndex = 35
        Me.Label3.Text = "добавить копий"
        '
        'btCopyNameInBuffer
        '
        Me.btCopyNameInBuffer.AutoSize = True
        Me.btCopyNameInBuffer.Location = New System.Drawing.Point(10, 37)
        Me.btCopyNameInBuffer.Name = "btCopyNameInBuffer"
        Me.btCopyNameInBuffer.Size = New System.Drawing.Size(74, 23)
        Me.btCopyNameInBuffer.TabIndex = 31
        Me.btCopyNameInBuffer.Text = "Копир. имя"
        Me.btCopyNameInBuffer.UseVisualStyleBackColor = True
        '
        'lbLabelName
        '
        Me.lbLabelName.AutoSize = True
        Me.lbLabelName.Location = New System.Drawing.Point(380, 329)
        Me.lbLabelName.Name = "lbLabelName"
        Me.lbLabelName.Size = New System.Drawing.Size(29, 13)
        Me.lbLabelName.TabIndex = 34
        Me.lbLabelName.Text = "label"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.btNodeImport)
        Me.GroupBox4.Controls.Add(Me.lbFullPath)
        Me.GroupBox4.Location = New System.Drawing.Point(471, 439)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(176, 67)
        Me.GroupBox4.TabIndex = 33
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Служебные функции"
        '
        'btNodeImport
        '
        Me.btNodeImport.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btNodeImport.Location = New System.Drawing.Point(7, 17)
        Me.btNodeImport.Name = "btNodeImport"
        Me.btNodeImport.Size = New System.Drawing.Size(161, 23)
        Me.btNodeImport.TabIndex = 31
        Me.btNodeImport.Text = "Импорт к выбранному узлу"
        Me.btNodeImport.UseVisualStyleBackColor = True
        '
        'lbFullPath
        '
        Me.lbFullPath.AutoSize = True
        Me.lbFullPath.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lbFullPath.Location = New System.Drawing.Point(15, 47)
        Me.lbFullPath.Name = "lbFullPath"
        Me.lbFullPath.Size = New System.Drawing.Size(44, 13)
        Me.lbFullPath.TabIndex = 22
        Me.lbFullPath.Text = "full path"
        '
        'btAddLabel
        '
        Me.btAddLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btAddLabel.Location = New System.Drawing.Point(377, 354)
        Me.btAddLabel.Name = "btAddLabel"
        Me.btAddLabel.Size = New System.Drawing.Size(241, 42)
        Me.btAddLabel.TabIndex = 32
        Me.btAddLabel.Text = "Добавить этикетку в список печати"
        Me.btAddLabel.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.rbExternalLabel)
        Me.GroupBox3.Controls.Add(Me.rbInnerImg)
        Me.GroupBox3.Controls.Add(Me.rbExternalImage)
        Me.GroupBox3.Location = New System.Drawing.Point(351, 280)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(288, 46)
        Me.GroupBox3.TabIndex = 16
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Что показываем"
        '
        'rbExternalLabel
        '
        Me.rbExternalLabel.AutoSize = True
        Me.rbExternalLabel.Location = New System.Drawing.Point(195, 18)
        Me.rbExternalLabel.Name = "rbExternalLabel"
        Me.rbExternalLabel.Size = New System.Drawing.Size(71, 17)
        Me.rbExternalLabel.TabIndex = 2
        Me.rbExternalLabel.TabStop = True
        Me.rbExternalLabel.Text = "этикетки"
        Me.rbExternalLabel.UseVisualStyleBackColor = True
        '
        'rbInnerImg
        '
        Me.rbInnerImg.AutoSize = True
        Me.rbInnerImg.Location = New System.Drawing.Point(6, 18)
        Me.rbInnerImg.Name = "rbInnerImg"
        Me.rbInnerImg.Size = New System.Drawing.Size(92, 17)
        Me.rbInnerImg.TabIndex = 0
        Me.rbInnerImg.TabStop = True
        Me.rbInnerImg.Text = "сохраненные"
        Me.rbInnerImg.UseVisualStyleBackColor = True
        '
        'rbExternalImage
        '
        Me.rbExternalImage.AutoSize = True
        Me.rbExternalImage.Location = New System.Drawing.Point(113, 18)
        Me.rbExternalImage.Name = "rbExternalImage"
        Me.rbExternalImage.Size = New System.Drawing.Size(55, 17)
        Me.rbExternalImage.TabIndex = 1
        Me.rbExternalImage.TabStop = True
        Me.rbExternalImage.Text = "папка"
        Me.rbExternalImage.UseVisualStyleBackColor = True
        '
        'btCopyDescr
        '
        Me.btCopyDescr.Location = New System.Drawing.Point(300, 57)
        Me.btCopyDescr.Name = "btCopyDescr"
        Me.btCopyDescr.Size = New System.Drawing.Size(23, 23)
        Me.btCopyDescr.TabIndex = 15
        Me.btCopyDescr.Text = ">"
        Me.btCopyDescr.UseVisualStyleBackColor = True
        '
        'btCopyName
        '
        Me.btCopyName.Location = New System.Drawing.Point(342, 13)
        Me.btCopyName.Name = "btCopyName"
        Me.btCopyName.Size = New System.Drawing.Size(21, 23)
        Me.btCopyName.TabIndex = 14
        Me.btCopyName.Text = ">"
        Me.btCopyName.UseVisualStyleBackColor = True
        '
        'BindingNavigatorImages
        '
        Me.BindingNavigatorImages.AddNewItem = Me.BindingNavigatorAddNewItem
        Me.BindingNavigatorImages.BindingSource = Me.ImageBindingSource
        Me.BindingNavigatorImages.CountItem = Me.BindingNavigatorCountItem
        Me.BindingNavigatorImages.DeleteItem = Me.BindingNavigatorDeleteItem
        Me.BindingNavigatorImages.Dock = System.Windows.Forms.DockStyle.None
        Me.BindingNavigatorImages.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem, Me.ToolStripSeparator4, Me.ToolStripButton1, Me.ToolStripButton2})
        Me.BindingNavigatorImages.Location = New System.Drawing.Point(14, 249)
        Me.BindingNavigatorImages.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.BindingNavigatorImages.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.BindingNavigatorImages.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.BindingNavigatorImages.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.BindingNavigatorImages.Name = "BindingNavigatorImages"
        Me.BindingNavigatorImages.PositionItem = Me.BindingNavigatorPositionItem
        Me.BindingNavigatorImages.Size = New System.Drawing.Size(569, 25)
        Me.BindingNavigatorImages.TabIndex = 13
        Me.BindingNavigatorImages.Text = "BindingNavigator1"
        '
        'BindingNavigatorAddNewItem
        '
        Me.BindingNavigatorAddNewItem.Image = CType(resources.GetObject("BindingNavigatorAddNewItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorAddNewItem.Name = "BindingNavigatorAddNewItem"
        Me.BindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorAddNewItem.Size = New System.Drawing.Size(77, 22)
        Me.BindingNavigatorAddNewItem.Text = "Доб.фото"
        '
        'ImageBindingSource
        '
        Me.ImageBindingSource.AllowNew = True
        Me.ImageBindingSource.DataMember = "image"
        Me.ImageBindingSource.DataSource = Me.BindingSourceNodeObject
        '
        'BindingSourceNodeObject
        '
        Me.BindingSourceNodeObject.DataSource = GetType(Trilbone.NodeObject)
        '
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(45, 22)
        Me.BindingNavigatorCountItem.Text = "для {0}"
        Me.BindingNavigatorCountItem.ToolTipText = "Общее число элементов"
        '
        'BindingNavigatorDeleteItem
        '
        Me.BindingNavigatorDeleteItem.CheckOnClick = True
        Me.BindingNavigatorDeleteItem.Image = CType(resources.GetObject("BindingNavigatorDeleteItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorDeleteItem.Name = "BindingNavigatorDeleteItem"
        Me.BindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorDeleteItem.Size = New System.Drawing.Size(100, 22)
        Me.BindingNavigatorDeleteItem.Text = "Удалить фото"
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
        Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(50, 21)
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
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(79, 22)
        Me.ToolStripButton1.Text = "доб. файл"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(90, 22)
        Me.ToolStripButton2.Text = "Откр. папку"
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.ContextMenuStrip = Me.cmsStandart
        Me.PictureBox1.ErrorImage = Nothing
        Me.PictureBox1.Location = New System.Drawing.Point(11, 277)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(334, 250)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 10
        Me.PictureBox1.TabStop = False
        '
        'RichTextBox1
        '
        Me.RichTextBox1.AutoWordSelection = True
        Me.RichTextBox1.ContextMenuStrip = Me.cmsStandart
        Me.RichTextBox1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BindingSourceNodeObject, "info", True))
        Me.RichTextBox1.EnableAutoDragDrop = True
        Me.RichTextBox1.Location = New System.Drawing.Point(11, 177)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(636, 65)
        Me.RichTextBox1.TabIndex = 5
        Me.RichTextBox1.Text = ""
        '
        'cmsStandart
        '
        Me.cmsStandart.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.InsertToolStripMenuItem, Me.CopyToolStripMenuItem1})
        Me.cmsStandart.Name = "cmsStandart"
        Me.cmsStandart.Size = New System.Drawing.Size(153, 70)
        '
        'InsertToolStripMenuItem
        '
        Me.InsertToolStripMenuItem.Name = "InsertToolStripMenuItem"
        Me.InsertToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.InsertToolStripMenuItem.Text = "вставить.."
        '
        'CopyToolStripMenuItem1
        '
        Me.CopyToolStripMenuItem1.Name = "CopyToolStripMenuItem1"
        Me.CopyToolStripMenuItem1.Size = New System.Drawing.Size(152, 22)
        Me.CopyToolStripMenuItem1.Text = "копировать.."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(8, 161)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(216, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Справочник - в описание не добавляется"
        '
        'DescrRUSRichTextBox
        '
        Me.DescrRUSRichTextBox.AutoWordSelection = True
        Me.DescrRUSRichTextBox.ContextMenuStrip = Me.cmsStandart
        Me.DescrRUSRichTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BindingSourceNodeObject, "DescrRUS", True))
        Me.DescrRUSRichTextBox.EnableAutoDragDrop = True
        Me.DescrRUSRichTextBox.Location = New System.Drawing.Point(329, 81)
        Me.DescrRUSRichTextBox.Name = "DescrRUSRichTextBox"
        Me.DescrRUSRichTextBox.Size = New System.Drawing.Size(317, 74)
        Me.DescrRUSRichTextBox.TabIndex = 4
        Me.DescrRUSRichTextBox.Text = ""
        '
        'DescrRichTextBox
        '
        Me.DescrRichTextBox.AutoWordSelection = True
        Me.DescrRichTextBox.ContextMenuStrip = Me.cmsStandart
        Me.DescrRichTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BindingSourceNodeObject, "Descr", True))
        Me.DescrRichTextBox.EnableAutoDragDrop = True
        Me.DescrRichTextBox.Location = New System.Drawing.Point(10, 81)
        Me.DescrRichTextBox.Name = "DescrRichTextBox"
        Me.DescrRichTextBox.Size = New System.Drawing.Size(313, 74)
        Me.DescrRichTextBox.TabIndex = 3
        Me.DescrRichTextBox.Text = ""
        '
        'NameRUSTextBox
        '
        Me.NameRUSTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BindingSourceNodeObject, "NameRUS", True))
        Me.NameRUSTextBox.Location = New System.Drawing.Point(475, 17)
        Me.NameRUSTextBox.Name = "NameRUSTextBox"
        Me.NameRUSTextBox.Size = New System.Drawing.Size(172, 20)
        Me.NameRUSTextBox.TabIndex = 2
        '
        'NameTextBox
        '
        Me.NameTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BindingSourceNodeObject, "Name", True))
        Me.NameTextBox.Location = New System.Drawing.Point(141, 15)
        Me.NameTextBox.Name = "NameTextBox"
        Me.NameTextBox.Size = New System.Drawing.Size(198, 20)
        Me.NameTextBox.TabIndex = 1
        '
        'TreeView1
        '
        Me.TreeView1.Location = New System.Drawing.Point(0, 4)
        Me.TreeView1.Name = "TreeView1"
        Me.TreeView1.Size = New System.Drawing.Size(497, 357)
        Me.TreeView1.TabIndex = 0
        '
        'rtbReadyDescription
        '
        Me.rtbReadyDescription.EnableAutoDragDrop = True
        Me.rtbReadyDescription.Location = New System.Drawing.Point(3, 495)
        Me.rtbReadyDescription.Name = "rtbReadyDescription"
        Me.rtbReadyDescription.Size = New System.Drawing.Size(477, 47)
        Me.rtbReadyDescription.TabIndex = 8
        Me.rtbReadyDescription.Text = ""
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.BackColor = System.Drawing.SystemColors.Window
        Me.NumericUpDown1.Location = New System.Drawing.Point(446, 471)
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(34, 20)
        Me.NumericUpDown1.TabIndex = 6
        Me.NumericUpDown1.Value = New Decimal(New Integer() {9, 0, 0, 0})
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(432, 369)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(67, 17)
        Me.RadioButton2.TabIndex = 1
        Me.RadioButton2.Text = "Русский"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Location = New System.Drawing.Point(341, 369)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(85, 17)
        Me.RadioButton1.TabIndex = 0
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Английский"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(326, 473)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(101, 13)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "добавлены уровни"
        '
        'btRefreshTree
        '
        Me.btRefreshTree.AutoSize = True
        Me.btRefreshTree.Location = New System.Drawing.Point(190, 367)
        Me.btRefreshTree.Name = "btRefreshTree"
        Me.btRefreshTree.Size = New System.Drawing.Size(64, 23)
        Me.btRefreshTree.TabIndex = 9
        Me.btRefreshTree.Text = "обновить"
        Me.btRefreshTree.UseVisualStyleBackColor = True
        '
        'cmsAddItem
        '
        Me.cmsAddItem.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ДобавитьПослеУзлаToolStripMenuItem, Me.ДобавитьДоУзлаToolStripMenuItem, Me.ДобавитьПредкаToolStripMenuItem, Me.КопироватьУзелToolStripMenuItem, Me.ToolStripSeparator2, Me.СоздатьСвязьToolStripMenuItem, Me.ToolStripSeparator3, Me.КопироватьПоддеревоToolStripMenuItem, Me.ВырезатьToolStripMenuItem, Me.ВставитьToolStripMenuItem, Me.УдалитьУзелToolStripMenuItem, Me.ToolStripSeparator1, Me.СлужебныеToolStripMenuItem})
        Me.cmsAddItem.Name = "cmsAddItem"
        Me.cmsAddItem.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.cmsAddItem.Size = New System.Drawing.Size(217, 242)
        '
        'ДобавитьПослеУзлаToolStripMenuItem
        '
        Me.ДобавитьПослеУзлаToolStripMenuItem.Name = "ДобавитьПослеУзлаToolStripMenuItem"
        Me.ДобавитьПослеУзлаToolStripMenuItem.Size = New System.Drawing.Size(216, 22)
        Me.ДобавитьПослеУзлаToolStripMenuItem.Text = "Добавить в тот же уровень"
        '
        'ДобавитьДоУзлаToolStripMenuItem
        '
        Me.ДобавитьДоУзлаToolStripMenuItem.Name = "ДобавитьДоУзлаToolStripMenuItem"
        Me.ДобавитьДоУзлаToolStripMenuItem.Size = New System.Drawing.Size(216, 22)
        Me.ДобавитьДоУзлаToolStripMenuItem.Text = "Добавить потомка"
        '
        'ДобавитьПредкаToolStripMenuItem
        '
        Me.ДобавитьПредкаToolStripMenuItem.Name = "ДобавитьПредкаToolStripMenuItem"
        Me.ДобавитьПредкаToolStripMenuItem.Size = New System.Drawing.Size(216, 22)
        Me.ДобавитьПредкаToolStripMenuItem.Text = "Добавить предка"
        '
        'КопироватьУзелToolStripMenuItem
        '
        Me.КопироватьУзелToolStripMenuItem.Name = "КопироватьУзелToolStripMenuItem"
        Me.КопироватьУзелToolStripMenuItem.Size = New System.Drawing.Size(216, 22)
        Me.КопироватьУзелToolStripMenuItem.Text = "Копировать узел"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(213, 6)
        '
        'СоздатьСвязьToolStripMenuItem
        '
        Me.СоздатьСвязьToolStripMenuItem.Name = "СоздатьСвязьToolStripMenuItem"
        Me.СоздатьСвязьToolStripMenuItem.Size = New System.Drawing.Size(216, 22)
        Me.СоздатьСвязьToolStripMenuItem.Text = "Управление связями"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(213, 6)
        '
        'КопироватьПоддеревоToolStripMenuItem
        '
        Me.КопироватьПоддеревоToolStripMenuItem.Name = "КопироватьПоддеревоToolStripMenuItem"
        Me.КопироватьПоддеревоToolStripMenuItem.Size = New System.Drawing.Size(216, 22)
        Me.КопироватьПоддеревоToolStripMenuItem.Text = "Копировать поддерево"
        '
        'ВырезатьToolStripMenuItem
        '
        Me.ВырезатьToolStripMenuItem.Name = "ВырезатьToolStripMenuItem"
        Me.ВырезатьToolStripMenuItem.Size = New System.Drawing.Size(216, 22)
        Me.ВырезатьToolStripMenuItem.Text = "Вырезать"
        '
        'ВставитьToolStripMenuItem
        '
        Me.ВставитьToolStripMenuItem.Name = "ВставитьToolStripMenuItem"
        Me.ВставитьToolStripMenuItem.Size = New System.Drawing.Size(216, 22)
        Me.ВставитьToolStripMenuItem.Text = "Вставить"
        '
        'УдалитьУзелToolStripMenuItem
        '
        Me.УдалитьУзелToolStripMenuItem.Name = "УдалитьУзелToolStripMenuItem"
        Me.УдалитьУзелToolStripMenuItem.Size = New System.Drawing.Size(216, 22)
        Me.УдалитьУзелToolStripMenuItem.Text = "Удалить узел"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(213, 6)
        '
        'СлужебныеToolStripMenuItem
        '
        Me.СлужебныеToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem2, Me.ПрисвоитьНовыйIDToolStripMenuItem, Me.УдалитьIDToolStripMenuItem1, Me.КоррекцияПереместитьНаМеньшийУровеньToolStripMenuItem1, Me.КоррекцияУзловСОдинаковымHierIDилиПереместитьНаБольшийУровеньToolStripMenuItem})
        Me.СлужебныеToolStripMenuItem.Name = "СлужебныеToolStripMenuItem"
        Me.СлужебныеToolStripMenuItem.Size = New System.Drawing.Size(216, 22)
        Me.СлужебныеToolStripMenuItem.Text = "Служебные"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(471, 22)
        Me.ToolStripMenuItem2.Text = "Удалить потомков"
        '
        'ПрисвоитьНовыйIDToolStripMenuItem
        '
        Me.ПрисвоитьНовыйIDToolStripMenuItem.Name = "ПрисвоитьНовыйIDToolStripMenuItem"
        Me.ПрисвоитьНовыйIDToolStripMenuItem.Size = New System.Drawing.Size(471, 22)
        Me.ПрисвоитьНовыйIDToolStripMenuItem.Text = "Присвоить новый ID"
        '
        'УдалитьIDToolStripMenuItem1
        '
        Me.УдалитьIDToolStripMenuItem1.Name = "УдалитьIDToolStripMenuItem1"
        Me.УдалитьIDToolStripMenuItem1.Size = New System.Drawing.Size(471, 22)
        Me.УдалитьIDToolStripMenuItem1.Text = "Удалить ID"
        '
        'КоррекцияПереместитьНаМеньшийУровеньToolStripMenuItem1
        '
        Me.КоррекцияПереместитьНаМеньшийУровеньToolStripMenuItem1.Name = "КоррекцияПереместитьНаМеньшийУровеньToolStripMenuItem1"
        Me.КоррекцияПереместитьНаМеньшийУровеньToolStripMenuItem1.Size = New System.Drawing.Size(471, 22)
        Me.КоррекцияПереместитьНаМеньшийУровеньToolStripMenuItem1.Text = "коррекция - переместить на меньший уровень"
        '
        'КоррекцияУзловСОдинаковымHierIDилиПереместитьНаБольшийУровеньToolStripMenuItem
        '
        Me.КоррекцияУзловСОдинаковымHierIDилиПереместитьНаБольшийУровеньToolStripMenuItem.Name = "КоррекцияУзловСОдинаковымHierIDилиПереместитьНаБольшийУровеньToolStripMenuItem"
        Me.КоррекцияУзловСОдинаковымHierIDилиПереместитьНаБольшийУровеньToolStripMenuItem.Size = New System.Drawing.Size(471, 22)
        Me.КоррекцияУзловСОдинаковымHierIDилиПереместитьНаБольшийУровеньToolStripMenuItem.Text = "коррекция узлов с одинаковым HierID (или переместить на больший уровень)"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        Me.OpenFileDialog1.Title = "Загрузка изображения для узла"
        '
        'ilNodePhoto
        '
        Me.ilNodePhoto.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.ilNodePhoto.ImageSize = New System.Drawing.Size(228, 171)
        Me.ilNodePhoto.TransparentColor = System.Drawing.Color.Transparent
        '
        'tbSearch
        '
        Me.tbSearch.Location = New System.Drawing.Point(6, 18)
        Me.tbSearch.Name = "tbSearch"
        Me.tbSearch.Size = New System.Drawing.Size(114, 20)
        Me.tbSearch.TabIndex = 24
        '
        'btSearch
        '
        Me.btSearch.Location = New System.Drawing.Point(141, 15)
        Me.btSearch.Name = "btSearch"
        Me.btSearch.Size = New System.Drawing.Size(75, 23)
        Me.btSearch.TabIndex = 25
        Me.btSearch.Text = "Найти"
        Me.btSearch.UseVisualStyleBackColor = True
        '
        'cbxShowLeaf
        '
        Me.cbxShowLeaf.AutoSize = True
        Me.cbxShowLeaf.Location = New System.Drawing.Point(16, 367)
        Me.cbxShowLeaf.Name = "cbxShowLeaf"
        Me.cbxShowLeaf.Size = New System.Drawing.Size(90, 17)
        Me.cbxShowLeaf.TabIndex = 26
        Me.cbxShowLeaf.Text = "С артикулом"
        Me.cbxShowLeaf.UseVisualStyleBackColor = True
        '
        'btShowAll
        '
        Me.btShowAll.Location = New System.Drawing.Point(108, 367)
        Me.btShowAll.Name = "btShowAll"
        Me.btShowAll.Size = New System.Drawing.Size(75, 23)
        Me.btShowAll.TabIndex = 27
        Me.btShowAll.Text = "развернуть"
        Me.btShowAll.UseVisualStyleBackColor = True
        '
        'lbSearchResult
        '
        Me.lbSearchResult.AutoSize = True
        Me.lbSearchResult.Location = New System.Drawing.Point(232, 21)
        Me.lbSearchResult.Name = "lbSearchResult"
        Me.lbSearchResult.Size = New System.Drawing.Size(97, 13)
        Me.lbSearchResult.TabIndex = 28
        Me.lbSearchResult.Text = "результат поиска"
        '
        'btAddDescrMUI
        '
        Me.btAddDescrMUI.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btAddDescrMUI.Location = New System.Drawing.Point(8, 447)
        Me.btAddDescrMUI.Name = "btAddDescrMUI"
        Me.btAddDescrMUI.Size = New System.Drawing.Size(156, 44)
        Me.btAddDescrMUI.TabIndex = 29
        Me.btAddDescrMUI.Text = "добавить в описание (MUI)"
        Me.btAddDescrMUI.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.nudSearchResult)
        Me.GroupBox2.Controls.Add(Me.tbSearch)
        Me.GroupBox2.Controls.Add(Me.btSearch)
        Me.GroupBox2.Controls.Add(Me.lbSearchResult)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 396)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(427, 45)
        Me.GroupBox2.TabIndex = 30
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Поиск узла по части имени"
        '
        'nudSearchResult
        '
        Me.nudSearchResult.Location = New System.Drawing.Point(384, 15)
        Me.nudSearchResult.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudSearchResult.Name = "nudSearchResult"
        Me.nudSearchResult.Size = New System.Drawing.Size(37, 20)
        Me.nudSearchResult.TabIndex = 29
        Me.nudSearchResult.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'lbArticul
        '
        Me.lbArticul.AutoSize = True
        Me.lbArticul.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BindingSourceNodeObject, "DataFolder", True))
        Me.lbArticul.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lbArticul.Location = New System.Drawing.Point(358, 447)
        Me.lbArticul.Name = "lbArticul"
        Me.lbArticul.Size = New System.Drawing.Size(122, 20)
        Me.lbArticul.TabIndex = 38
        Me.lbArticul.Text = "нет артикула"
        '
        'ucHierarhy
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lbArticul)
        Me.Controls.Add(Me.RadioButton2)
        Me.Controls.Add(Me.RadioButton1)
        Me.Controls.Add(Me.TreeView1)
        Me.Controls.Add(Me.btShowAll)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btAddDescrMUI)
        Me.Controls.Add(Me.cbxShowLeaf)
        Me.Controls.Add(Me.NumericUpDown1)
        Me.Controls.Add(Me.btRefreshTree)
        Me.Controls.Add(Me.rtbReadyDescription)
        Me.Controls.Add(Me.btAddDescr)
        Me.Name = "ucHierarhy"
        Me.Size = New System.Drawing.Size(1160, 543)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.nudLabelsCountCopy, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.BindingNavigatorImages, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BindingNavigatorImages.ResumeLayout(False)
        Me.BindingNavigatorImages.PerformLayout()
        CType(Me.ImageBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingSourceNodeObject, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsStandart.ResumeLayout(False)
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsAddItem.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.nudSearchResult, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btAddDescr As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents DescrRUSRichTextBox As System.Windows.Forms.RichTextBox
    Friend WithEvents DescrRichTextBox As System.Windows.Forms.RichTextBox
    Friend WithEvents NameRUSTextBox As System.Windows.Forms.TextBox
    Friend WithEvents NameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents TreeView1 As System.Windows.Forms.TreeView
    Friend WithEvents rtbReadyDescription As System.Windows.Forms.RichTextBox
    Friend WithEvents NumericUpDown1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btRefreshTree As System.Windows.Forms.Button
    Friend WithEvents cmsAddItem As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ДобавитьДоУзлаToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ДобавитьПослеУзлаToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents УдалитьУзелToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ilNodePhoto As System.Windows.Forms.ImageList
    Friend WithEvents BindingNavigatorImages As System.Windows.Forms.BindingNavigator
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
    Friend WithEvents BindingSourceNodeObject As System.Windows.Forms.BindingSource
    Friend WithEvents ImageBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents btCopyDescr As System.Windows.Forms.Button
    Friend WithEvents btCopyName As System.Windows.Forms.Button
    Friend WithEvents cmsStandart As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents InsertToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CopyToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents СоздатьСвязьToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ДобавитьПредкаToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ВырезатьToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ВставитьToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lbFullPath As System.Windows.Forms.Label
    Friend WithEvents tbSearch As System.Windows.Forms.TextBox
    Friend WithEvents btSearch As System.Windows.Forms.Button
    Friend WithEvents cbxShowLeaf As System.Windows.Forms.CheckBox
    Friend WithEvents btShowAll As System.Windows.Forms.Button
    Friend WithEvents lbSearchResult As System.Windows.Forms.Label
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents КопироватьПоддеревоToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btAddDescrMUI As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btNodeImport As System.Windows.Forms.Button
    Friend WithEvents nudSearchResult As System.Windows.Forms.NumericUpDown
    Friend WithEvents КопироватьУзелToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents rbInnerImg As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents rbExternalLabel As System.Windows.Forms.RadioButton
    Friend WithEvents rbExternalImage As System.Windows.Forms.RadioButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents btAddLabel As System.Windows.Forms.Button
    Friend WithEvents lbLabelName As System.Windows.Forms.Label
    Friend WithEvents СлужебныеToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents УдалитьIDToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents КоррекцияПереместитьНаМеньшийУровеньToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents КоррекцияУзловСОдинаковымHierIDилиПереместитьНаБольшийУровеньToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents nudLabelsCountCopy As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btCopyNameInBuffer As System.Windows.Forms.Button
    Friend WithEvents btCopyNodeValue As System.Windows.Forms.Button
    Friend WithEvents ПрисвоитьНовыйIDToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lbArticul As System.Windows.Forms.Label

End Class
