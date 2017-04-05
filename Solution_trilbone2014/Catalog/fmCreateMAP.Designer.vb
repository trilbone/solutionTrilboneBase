Imports Service.Catalog

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fmCreateMAP
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
        Me.components = New System.ComponentModel.Container()
        Dim HrefLabel As System.Windows.Forms.Label
        Dim IdLabel As System.Windows.Forms.Label
        Dim TextLabel As System.Windows.Forms.Label
        Dim AltLabel As System.Windows.Forms.Label
        Dim PositionLabel As System.Windows.Forms.Label
        Dim TextLabel1 As System.Windows.Forms.Label
        Dim HrefLabel1 As System.Windows.Forms.Label
        Dim TypeLabel1 As System.Windows.Forms.Label
        Dim Label5 As System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btAddToElement = New System.Windows.Forms.Button()
        Me.bs_Description = New System.Windows.Forms.BindingSource(Me.components)
        Me.lbDescriptionElement = New System.Windows.Forms.ListBox()
        Me.btSetPoint = New System.Windows.Forms.Button()
        Me.bs_MAP = New System.Windows.Forms.BindingSource(Me.components)
        Me.dgvMAP = New System.Windows.Forms.DataGridView()
        Me.IdDataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TextDataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvOverlay = New System.Windows.Forms.DataGridView()
        Me.gvisible = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.gopacity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdDataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TextDataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Position = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gSize = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.type = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.filename = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bs_overlay = New System.Windows.Forms.BindingSource(Me.components)
        Me.bs_selectedOverlay = New System.Windows.Forms.BindingSource(Me.components)
        Me.bs_SelectedMap = New System.Windows.Forms.BindingSource(Me.components)
        Me.EmOverlayTypeBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.btDelSelectedMap = New System.Windows.Forms.Button()
        Me.btDelOverlay = New System.Windows.Forms.Button()
        Me.btSetSize = New System.Windows.Forms.Button()
        Me.rbBlock = New System.Windows.Forms.RadioButton()
        Me.rbArrow = New System.Windows.Forms.RadioButton()
        Me.btReady = New System.Windows.Forms.Button()
        Me.btSaveMaps = New System.Windows.Forms.Button()
        Me.tbctlMain = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.btAddMap = New System.Windows.Forms.Button()
        Me.btCreateOverlay = New System.Windows.Forms.Button()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.btCreateOverlaySelected = New System.Windows.Forms.Button()
        Me.HrefTextBox = New System.Windows.Forms.TextBox()
        Me.IdTextBox = New System.Windows.Forms.TextBox()
        Me.TextTextBox = New System.Windows.Forms.TextBox()
        Me.dgvSelectedOverlay = New System.Windows.Forms.DataGridView()
        Me.g2Visible = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.g2Opacity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TextDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.g1Size = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btSetPointLayer = New System.Windows.Forms.Button()
        Me.btSetSizeLayer = New System.Windows.Forms.Button()
        Me.btSaveLayerToMaps = New System.Windows.Forms.Button()
        Me.btDeleteLayerFromMaps = New System.Windows.Forms.Button()
        Me.btDeleteMapFromElement = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tbpCurrentElement = New System.Windows.Forms.TabPage()
        Me.dgvImaged = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IMAGEBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.btDeleteAdd = New System.Windows.Forms.Button()
        Me.btCreateAdd = New System.Windows.Forms.Button()
        Me.cbResourceType = New System.Windows.Forms.ComboBox()
        Me.BindingSourceEnvirType = New System.Windows.Forms.BindingSource(Me.components)
        Me.tbHrefAdditional = New System.Windows.Forms.TextBox()
        Me.TextRichTextBox = New System.Windows.Forms.RichTextBox()
        Me.PositionComboBox = New System.Windows.Forms.ComboBox()
        Me.BindingSourcePosition = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label3 = New System.Windows.Forms.Label()
        Me.nudElementPosition = New System.Windows.Forms.NumericUpDown()
        Me.cbElementBorder = New System.Windows.Forms.CheckBox()
        Me.BorderSpecifiedCheckBox = New System.Windows.Forms.CheckBox()
        Me.AltTextBox = New System.Windows.Forms.TextBox()
        Me.rtbElementText = New System.Windows.Forms.RichTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbAltTag = New System.Windows.Forms.TextBox()
        Me.cbSowAllOverlays = New System.Windows.Forms.CheckBox()
        Me.btRefreshBrowser = New System.Windows.Forms.Button()
        Me.btAddElement = New System.Windows.Forms.Button()
        Me.btDeleteElement = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btPreView = New System.Windows.Forms.Button()
        Me.cbTemplates = New System.Windows.Forms.ComboBox()
        HrefLabel = New System.Windows.Forms.Label()
        IdLabel = New System.Windows.Forms.Label()
        TextLabel = New System.Windows.Forms.Label()
        AltLabel = New System.Windows.Forms.Label()
        PositionLabel = New System.Windows.Forms.Label()
        TextLabel1 = New System.Windows.Forms.Label()
        HrefLabel1 = New System.Windows.Forms.Label()
        TypeLabel1 = New System.Windows.Forms.Label()
        Label5 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.bs_Description, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bs_MAP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvMAP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvOverlay, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bs_overlay, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bs_selectedOverlay, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bs_SelectedMap, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmOverlayTypeBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbctlMain.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.dgvSelectedOverlay, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbpCurrentElement.SuspendLayout()
        CType(Me.dgvImaged, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IMAGEBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingSourceEnvirType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingSourcePosition, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudElementPosition, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'HrefLabel
        '
        HrefLabel.AutoSize = True
        HrefLabel.Location = New System.Drawing.Point(33, 67)
        HrefLabel.Name = "HrefLabel"
        HrefLabel.Size = New System.Drawing.Size(28, 13)
        HrefLabel.TabIndex = 34
        HrefLabel.Text = "href:"
        '
        'IdLabel
        '
        IdLabel.AutoSize = True
        IdLabel.Location = New System.Drawing.Point(43, 41)
        IdLabel.Name = "IdLabel"
        IdLabel.Size = New System.Drawing.Size(18, 13)
        IdLabel.TabIndex = 36
        IdLabel.Text = "id:"
        '
        'TextLabel
        '
        TextLabel.AutoSize = True
        TextLabel.Location = New System.Drawing.Point(18, 102)
        TextLabel.Name = "TextLabel"
        TextLabel.Size = New System.Drawing.Size(64, 13)
        TextLabel.TabIndex = 38
        TextLabel.Text = "Заголовок:"
        '
        'AltLabel
        '
        AltLabel.AutoSize = True
        AltLabel.Location = New System.Drawing.Point(5, 16)
        AltLabel.Name = "AltLabel"
        AltLabel.Size = New System.Drawing.Size(64, 13)
        AltLabel.TabIndex = 0
        AltLabel.Text = "Заголовок:"
        '
        'PositionLabel
        '
        PositionLabel.AutoSize = True
        PositionLabel.Location = New System.Drawing.Point(584, 95)
        PositionLabel.Name = "PositionLabel"
        PositionLabel.Size = New System.Drawing.Size(52, 13)
        PositionLabel.TabIndex = 8
        PositionLabel.Text = "позиция:"
        '
        'TextLabel1
        '
        TextLabel1.AutoSize = True
        TextLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        TextLabel1.Location = New System.Drawing.Point(8, 45)
        TextLabel1.Name = "TextLabel1"
        TextLabel1.Size = New System.Drawing.Size(43, 15)
        TextLabel1.TabIndex = 9
        TextLabel1.Text = "Текст:"
        '
        'HrefLabel1
        '
        HrefLabel1.AutoSize = True
        HrefLabel1.Location = New System.Drawing.Point(9, 186)
        HrefLabel1.Name = "HrefLabel1"
        HrefLabel1.Size = New System.Drawing.Size(111, 13)
        HrefLabel1.TabIndex = 10
        HrefLabel1.Text = "ссылка дополнения:"
        '
        'TypeLabel1
        '
        TypeLabel1.AutoSize = True
        TypeLabel1.Location = New System.Drawing.Point(39, 218)
        TypeLabel1.Name = "TypeLabel1"
        TypeLabel1.Size = New System.Drawing.Size(71, 13)
        TypeLabel1.TabIndex = 13
        TypeLabel1.Text = "тип ресурса:"
        '
        'Label5
        '
        Label5.AutoSize = True
        Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Label5.Location = New System.Drawing.Point(82, 9)
        Label5.Name = "Label5"
        Label5.Size = New System.Drawing.Size(570, 16)
        Label5.TabIndex = 41
        Label5.Text = "Слои выбранной карты, которые будут применены к образцу(для текущего элемента)"
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.Controls.Add(Me.WebBrowser1)
        Me.Panel1.Location = New System.Drawing.Point(707, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(532, 633)
        Me.Panel1.TabIndex = 1
        '
        'WebBrowser1
        '
        Me.WebBrowser1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WebBrowser1.Location = New System.Drawing.Point(0, 0)
        Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.Size = New System.Drawing.Size(532, 633)
        Me.WebBrowser1.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 239)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(143, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "доступные слои для карты"
        '
        'btAddToElement
        '
        Me.btAddToElement.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btAddToElement.Location = New System.Drawing.Point(210, 492)
        Me.btAddToElement.Name = "btAddToElement"
        Me.btAddToElement.Size = New System.Drawing.Size(188, 23)
        Me.btAddToElement.TabIndex = 9
        Me.btAddToElement.Text = "добавить карту к элементу"
        Me.btAddToElement.UseVisualStyleBackColor = True
        '
        'bs_Description
        '
        Me.bs_Description.DataSource = GetType(CATALOGSAMPLEELEMENT)
        '
        'lbDescriptionElement
        '
        Me.lbDescriptionElement.DataSource = Me.bs_Description
        Me.lbDescriptionElement.DisplayMember = "name"
        Me.lbDescriptionElement.FormattingEnabled = True
        Me.lbDescriptionElement.Location = New System.Drawing.Point(8, 487)
        Me.lbDescriptionElement.Name = "lbDescriptionElement"
        Me.lbDescriptionElement.Size = New System.Drawing.Size(171, 121)
        Me.lbDescriptionElement.TabIndex = 0
        '
        'btSetPoint
        '
        Me.btSetPoint.Location = New System.Drawing.Point(233, 425)
        Me.btSetPoint.Name = "btSetPoint"
        Me.btSetPoint.Size = New System.Drawing.Size(143, 23)
        Me.btSetPoint.TabIndex = 14
        Me.btSetPoint.Text = "заменить координаты"
        Me.btSetPoint.UseVisualStyleBackColor = True
        '
        'bs_MAP
        '
        Me.bs_MAP.DataSource = GetType(CATALOGELEMENTMAP)
        '
        'dgvMAP
        '
        Me.dgvMAP.AllowUserToAddRows = False
        Me.dgvMAP.AllowUserToDeleteRows = False
        Me.dgvMAP.AllowUserToResizeRows = False
        Me.dgvMAP.AutoGenerateColumns = False
        Me.dgvMAP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMAP.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdDataGridViewTextBoxColumn3, Me.TextDataGridViewTextBoxColumn3, Me.Column1})
        Me.dgvMAP.DataSource = Me.bs_MAP
        Me.dgvMAP.Location = New System.Drawing.Point(8, 37)
        Me.dgvMAP.Name = "dgvMAP"
        Me.dgvMAP.Size = New System.Drawing.Size(674, 189)
        Me.dgvMAP.TabIndex = 16
        '
        'IdDataGridViewTextBoxColumn3
        '
        Me.IdDataGridViewTextBoxColumn3.DataPropertyName = "id"
        Me.IdDataGridViewTextBoxColumn3.HeaderText = "id"
        Me.IdDataGridViewTextBoxColumn3.Name = "IdDataGridViewTextBoxColumn3"
        Me.IdDataGridViewTextBoxColumn3.Width = 80
        '
        'TextDataGridViewTextBoxColumn3
        '
        Me.TextDataGridViewTextBoxColumn3.DataPropertyName = "Text"
        Me.TextDataGridViewTextBoxColumn3.HeaderText = "Заголовок на странице"
        Me.TextDataGridViewTextBoxColumn3.Name = "TextDataGridViewTextBoxColumn3"
        Me.TextDataGridViewTextBoxColumn3.Width = 350
        '
        'Column1
        '
        Me.Column1.DataPropertyName = "FileName"
        Me.Column1.HeaderText = "Файл"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'dgvOverlay
        '
        Me.dgvOverlay.AllowUserToAddRows = False
        Me.dgvOverlay.AllowUserToDeleteRows = False
        Me.dgvOverlay.AllowUserToResizeRows = False
        Me.dgvOverlay.AutoGenerateColumns = False
        Me.dgvOverlay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvOverlay.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.gvisible, Me.gopacity, Me.IdDataGridViewTextBoxColumn2, Me.TextDataGridViewTextBoxColumn2, Me.Position, Me.gSize, Me.type, Me.filename})
        Me.dgvOverlay.DataSource = Me.bs_overlay
        Me.dgvOverlay.Location = New System.Drawing.Point(6, 255)
        Me.dgvOverlay.Name = "dgvOverlay"
        Me.dgvOverlay.Size = New System.Drawing.Size(679, 165)
        Me.dgvOverlay.TabIndex = 16
        '
        'gvisible
        '
        Me.gvisible.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.gvisible.DataPropertyName = "visible"
        Me.gvisible.HeaderText = "visible"
        Me.gvisible.Name = "gvisible"
        Me.gvisible.Width = 42
        '
        'gopacity
        '
        Me.gopacity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
        Me.gopacity.DataPropertyName = "opacity"
        Me.gopacity.HeaderText = "яркость"
        Me.gopacity.Name = "gopacity"
        Me.gopacity.Width = 5
        '
        'IdDataGridViewTextBoxColumn2
        '
        Me.IdDataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.IdDataGridViewTextBoxColumn2.DataPropertyName = "id"
        Me.IdDataGridViewTextBoxColumn2.HeaderText = "id"
        Me.IdDataGridViewTextBoxColumn2.Name = "IdDataGridViewTextBoxColumn2"
        Me.IdDataGridViewTextBoxColumn2.Width = 40
        '
        'TextDataGridViewTextBoxColumn2
        '
        Me.TextDataGridViewTextBoxColumn2.DataPropertyName = "Text"
        Me.TextDataGridViewTextBoxColumn2.HeaderText = "Text"
        Me.TextDataGridViewTextBoxColumn2.Name = "TextDataGridViewTextBoxColumn2"
        Me.TextDataGridViewTextBoxColumn2.Width = 70
        '
        'Position
        '
        Me.Position.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
        Me.Position.DataPropertyName = "Position"
        Me.Position.HeaderText = "Position"
        Me.Position.Name = "Position"
        Me.Position.ReadOnly = True
        Me.Position.Width = 5
        '
        'gSize
        '
        Me.gSize.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
        Me.gSize.DataPropertyName = "Size"
        Me.gSize.HeaderText = "Size"
        Me.gSize.Name = "gSize"
        Me.gSize.ReadOnly = True
        Me.gSize.Width = 5
        '
        'type
        '
        Me.type.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.type.DataPropertyName = "type"
        Me.type.HeaderText = "Тип"
        Me.type.Name = "type"
        Me.type.Width = 51
        '
        'filename
        '
        Me.filename.DataPropertyName = "filename"
        Me.filename.HeaderText = "filename"
        Me.filename.Name = "filename"
        Me.filename.ReadOnly = True
        '
        'bs_overlay
        '
        Me.bs_overlay.DataMember = "LAYERS"
        Me.bs_overlay.DataSource = Me.bs_MAP
        '
        'bs_selectedOverlay
        '
        Me.bs_selectedOverlay.DataMember = "LAYERS"
        Me.bs_selectedOverlay.DataSource = Me.bs_SelectedMap
        '
        'bs_SelectedMap
        '
        Me.bs_SelectedMap.DataSource = GetType(CATALOGELEMENTMAP)
        '
        'btDelSelectedMap
        '
        Me.btDelSelectedMap.Location = New System.Drawing.Point(140, 8)
        Me.btDelSelectedMap.Name = "btDelSelectedMap"
        Me.btDelSelectedMap.Size = New System.Drawing.Size(101, 23)
        Me.btDelSelectedMap.TabIndex = 17
        Me.btDelSelectedMap.Text = "удалить карту"
        Me.btDelSelectedMap.UseVisualStyleBackColor = True
        '
        'btDelOverlay
        '
        Me.btDelOverlay.Location = New System.Drawing.Point(444, 424)
        Me.btDelOverlay.Name = "btDelOverlay"
        Me.btDelOverlay.Size = New System.Drawing.Size(90, 23)
        Me.btDelOverlay.TabIndex = 18
        Me.btDelOverlay.Text = "удалить слой"
        Me.btDelOverlay.UseVisualStyleBackColor = True
        '
        'btSetSize
        '
        Me.btSetSize.Enabled = False
        Me.btSetSize.Location = New System.Drawing.Point(544, 424)
        Me.btSetSize.Name = "btSetSize"
        Me.btSetSize.Size = New System.Drawing.Size(143, 23)
        Me.btSetSize.TabIndex = 20
        Me.btSetSize.Text = "задать размер"
        Me.btSetSize.UseVisualStyleBackColor = True
        '
        'rbBlock
        '
        Me.rbBlock.AutoSize = True
        Me.rbBlock.Location = New System.Drawing.Point(858, 648)
        Me.rbBlock.Name = "rbBlock"
        Me.rbBlock.Size = New System.Drawing.Size(49, 17)
        Me.rbBlock.TabIndex = 1
        Me.rbBlock.TabStop = True
        Me.rbBlock.Text = "блок"
        Me.rbBlock.UseVisualStyleBackColor = True
        '
        'rbArrow
        '
        Me.rbArrow.AutoSize = True
        Me.rbArrow.Location = New System.Drawing.Point(777, 648)
        Me.rbArrow.Name = "rbArrow"
        Me.rbArrow.Size = New System.Drawing.Size(66, 17)
        Me.rbArrow.TabIndex = 0
        Me.rbArrow.TabStop = True
        Me.rbArrow.Text = "стрелка"
        Me.rbArrow.UseVisualStyleBackColor = True
        '
        'btReady
        '
        Me.btReady.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btReady.Location = New System.Drawing.Point(12, 643)
        Me.btReady.Name = "btReady"
        Me.btReady.Size = New System.Drawing.Size(318, 26)
        Me.btReady.TabIndex = 22
        Me.btReady.Text = "готово!"
        Me.btReady.UseVisualStyleBackColor = True
        '
        'btSaveMaps
        '
        Me.btSaveMaps.Location = New System.Drawing.Point(275, 8)
        Me.btSaveMaps.Name = "btSaveMaps"
        Me.btSaveMaps.Size = New System.Drawing.Size(101, 23)
        Me.btSaveMaps.TabIndex = 24
        Me.btSaveMaps.Text = "сохранить"
        Me.btSaveMaps.UseVisualStyleBackColor = True
        '
        'tbctlMain
        '
        Me.tbctlMain.Controls.Add(Me.TabPage1)
        Me.tbctlMain.Controls.Add(Me.TabPage2)
        Me.tbctlMain.Controls.Add(Me.tbpCurrentElement)
        Me.tbctlMain.Location = New System.Drawing.Point(0, 6)
        Me.tbctlMain.Name = "tbctlMain"
        Me.tbctlMain.SelectedIndex = 0
        Me.tbctlMain.Size = New System.Drawing.Size(701, 479)
        Me.tbctlMain.TabIndex = 25
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.btAddMap)
        Me.TabPage1.Controls.Add(Me.btCreateOverlay)
        Me.TabPage1.Controls.Add(Me.dgvOverlay)
        Me.TabPage1.Controls.Add(Me.btSaveMaps)
        Me.TabPage1.Controls.Add(Me.btSetPoint)
        Me.TabPage1.Controls.Add(Me.btSetSize)
        Me.TabPage1.Controls.Add(Me.btDelOverlay)
        Me.TabPage1.Controls.Add(Me.btDelSelectedMap)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.dgvMAP)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(693, 453)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Доступные карты"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'btAddMap
        '
        Me.btAddMap.Location = New System.Drawing.Point(8, 8)
        Me.btAddMap.Name = "btAddMap"
        Me.btAddMap.Size = New System.Drawing.Size(101, 23)
        Me.btAddMap.TabIndex = 26
        Me.btAddMap.Text = "добавить карту"
        Me.btAddMap.UseVisualStyleBackColor = True
        '
        'btCreateOverlay
        '
        Me.btCreateOverlay.Location = New System.Drawing.Point(14, 426)
        Me.btCreateOverlay.Name = "btCreateOverlay"
        Me.btCreateOverlay.Size = New System.Drawing.Size(197, 23)
        Me.btCreateOverlay.TabIndex = 25
        Me.btCreateOverlay.Text = "новый слой из текущей позиции"
        Me.btCreateOverlay.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.AutoScroll = True
        Me.TabPage2.BackColor = System.Drawing.Color.PeachPuff
        Me.TabPage2.Controls.Add(Label5)
        Me.TabPage2.Controls.Add(Me.btCreateOverlaySelected)
        Me.TabPage2.Controls.Add(HrefLabel)
        Me.TabPage2.Controls.Add(Me.HrefTextBox)
        Me.TabPage2.Controls.Add(IdLabel)
        Me.TabPage2.Controls.Add(Me.IdTextBox)
        Me.TabPage2.Controls.Add(TextLabel)
        Me.TabPage2.Controls.Add(Me.TextTextBox)
        Me.TabPage2.Controls.Add(Me.dgvSelectedOverlay)
        Me.TabPage2.Controls.Add(Me.btSetPointLayer)
        Me.TabPage2.Controls.Add(Me.btSetSizeLayer)
        Me.TabPage2.Controls.Add(Me.btSaveLayerToMaps)
        Me.TabPage2.Controls.Add(Me.btDeleteLayerFromMaps)
        Me.TabPage2.Controls.Add(Me.btDeleteMapFromElement)
        Me.TabPage2.Controls.Add(Me.Label6)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(693, 453)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Выбранные карты (для текущего элемента)"
        '
        'btCreateOverlaySelected
        '
        Me.btCreateOverlaySelected.Location = New System.Drawing.Point(24, 395)
        Me.btCreateOverlaySelected.Name = "btCreateOverlaySelected"
        Me.btCreateOverlaySelected.Size = New System.Drawing.Size(197, 23)
        Me.btCreateOverlaySelected.TabIndex = 40
        Me.btCreateOverlaySelected.Text = "новый слой из текущей позиции"
        Me.btCreateOverlaySelected.UseVisualStyleBackColor = True
        '
        'HrefTextBox
        '
        Me.HrefTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bs_SelectedMap, "href", True))
        Me.HrefTextBox.Location = New System.Drawing.Point(70, 64)
        Me.HrefTextBox.Name = "HrefTextBox"
        Me.HrefTextBox.Size = New System.Drawing.Size(607, 20)
        Me.HrefTextBox.TabIndex = 35
        '
        'IdTextBox
        '
        Me.IdTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bs_SelectedMap, "id", True))
        Me.IdTextBox.Location = New System.Drawing.Point(70, 38)
        Me.IdTextBox.Name = "IdTextBox"
        Me.IdTextBox.Size = New System.Drawing.Size(178, 20)
        Me.IdTextBox.TabIndex = 37
        '
        'TextTextBox
        '
        Me.TextTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bs_SelectedMap, "Text", True))
        Me.TextTextBox.Location = New System.Drawing.Point(88, 99)
        Me.TextTextBox.Name = "TextTextBox"
        Me.TextTextBox.Size = New System.Drawing.Size(589, 20)
        Me.TextTextBox.TabIndex = 39
        '
        'dgvSelectedOverlay
        '
        Me.dgvSelectedOverlay.AllowUserToAddRows = False
        Me.dgvSelectedOverlay.AllowUserToDeleteRows = False
        Me.dgvSelectedOverlay.AllowUserToResizeRows = False
        Me.dgvSelectedOverlay.AutoGenerateColumns = False
        Me.dgvSelectedOverlay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSelectedOverlay.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.g2Visible, Me.g2Opacity, Me.IdDataGridViewTextBoxColumn, Me.TextDataGridViewTextBoxColumn, Me.DataGridViewTextBoxColumn3, Me.g1Size, Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2})
        Me.dgvSelectedOverlay.DataSource = Me.bs_selectedOverlay
        Me.dgvSelectedOverlay.Location = New System.Drawing.Point(24, 170)
        Me.dgvSelectedOverlay.Name = "dgvSelectedOverlay"
        Me.dgvSelectedOverlay.Size = New System.Drawing.Size(653, 219)
        Me.dgvSelectedOverlay.TabIndex = 30
        '
        'g2Visible
        '
        Me.g2Visible.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.g2Visible.DataPropertyName = "visible"
        Me.g2Visible.HeaderText = "visible"
        Me.g2Visible.Name = "g2Visible"
        Me.g2Visible.Width = 42
        '
        'g2Opacity
        '
        Me.g2Opacity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.g2Opacity.DataPropertyName = "opacity"
        Me.g2Opacity.HeaderText = "яркость"
        Me.g2Opacity.Name = "g2Opacity"
        Me.g2Opacity.Width = 73
        '
        'IdDataGridViewTextBoxColumn
        '
        Me.IdDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.IdDataGridViewTextBoxColumn.DataPropertyName = "id"
        Me.IdDataGridViewTextBoxColumn.HeaderText = "id"
        Me.IdDataGridViewTextBoxColumn.Name = "IdDataGridViewTextBoxColumn"
        Me.IdDataGridViewTextBoxColumn.Width = 40
        '
        'TextDataGridViewTextBoxColumn
        '
        Me.TextDataGridViewTextBoxColumn.DataPropertyName = "Text"
        Me.TextDataGridViewTextBoxColumn.HeaderText = "Text"
        Me.TextDataGridViewTextBoxColumn.Name = "TextDataGridViewTextBoxColumn"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "Position"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Position"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 69
        '
        'g1Size
        '
        Me.g1Size.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.g1Size.DataPropertyName = "Size"
        Me.g1Size.HeaderText = "Size"
        Me.g1Size.Name = "g1Size"
        Me.g1Size.ReadOnly = True
        Me.g1Size.Width = 52
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "type"
        Me.DataGridViewTextBoxColumn1.HeaderText = "type"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Width = 52
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "filename"
        Me.DataGridViewTextBoxColumn2.HeaderText = "filename"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'btSetPointLayer
        '
        Me.btSetPointLayer.Location = New System.Drawing.Point(402, 395)
        Me.btSetPointLayer.Name = "btSetPointLayer"
        Me.btSetPointLayer.Size = New System.Drawing.Size(143, 23)
        Me.btSetPointLayer.TabIndex = 28
        Me.btSetPointLayer.Text = "заменить координаты"
        Me.btSetPointLayer.UseVisualStyleBackColor = True
        '
        'btSetSizeLayer
        '
        Me.btSetSizeLayer.Enabled = False
        Me.btSetSizeLayer.Location = New System.Drawing.Point(573, 424)
        Me.btSetSizeLayer.Name = "btSetSizeLayer"
        Me.btSetSizeLayer.Size = New System.Drawing.Size(104, 23)
        Me.btSetSizeLayer.TabIndex = 34
        Me.btSetSizeLayer.Text = "задать размер"
        Me.btSetSizeLayer.UseVisualStyleBackColor = True
        '
        'btSaveLayerToMaps
        '
        Me.btSaveLayerToMaps.Location = New System.Drawing.Point(236, 395)
        Me.btSaveLayerToMaps.Name = "btSaveLayerToMaps"
        Me.btSaveLayerToMaps.Size = New System.Drawing.Size(145, 23)
        Me.btSaveLayerToMaps.TabIndex = 27
        Me.btSaveLayerToMaps.Text = "сохранить слой в карту"
        Me.btSaveLayerToMaps.UseVisualStyleBackColor = True
        '
        'btDeleteLayerFromMaps
        '
        Me.btDeleteLayerFromMaps.Location = New System.Drawing.Point(587, 395)
        Me.btDeleteLayerFromMaps.Name = "btDeleteLayerFromMaps"
        Me.btDeleteLayerFromMaps.Size = New System.Drawing.Size(90, 23)
        Me.btDeleteLayerFromMaps.TabIndex = 32
        Me.btDeleteLayerFromMaps.Text = "удалить слой"
        Me.btDeleteLayerFromMaps.UseVisualStyleBackColor = True
        '
        'btDeleteMapFromElement
        '
        Me.btDeleteMapFromElement.Location = New System.Drawing.Point(521, 31)
        Me.btDeleteMapFromElement.Name = "btDeleteMapFromElement"
        Me.btDeleteMapFromElement.Size = New System.Drawing.Size(156, 23)
        Me.btDeleteMapFromElement.TabIndex = 31
        Me.btDeleteMapFromElement.Text = "удалить карту из элемента"
        Me.btDeleteMapFromElement.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(27, 151)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(305, 13)
        Me.Label6.TabIndex = 26
        Me.Label6.Text = "доступные слои для выбранной карты текущего элемента"
        '
        'tbpCurrentElement
        '
        Me.tbpCurrentElement.AutoScroll = True
        Me.tbpCurrentElement.BackColor = System.Drawing.Color.MintCream
        Me.tbpCurrentElement.Controls.Add(Me.dgvImaged)
        Me.tbpCurrentElement.Controls.Add(Me.btDeleteAdd)
        Me.tbpCurrentElement.Controls.Add(Me.btCreateAdd)
        Me.tbpCurrentElement.Controls.Add(TypeLabel1)
        Me.tbpCurrentElement.Controls.Add(Me.cbResourceType)
        Me.tbpCurrentElement.Controls.Add(HrefLabel1)
        Me.tbpCurrentElement.Controls.Add(Me.tbHrefAdditional)
        Me.tbpCurrentElement.Controls.Add(Me.TextRichTextBox)
        Me.tbpCurrentElement.Controls.Add(TextLabel1)
        Me.tbpCurrentElement.Controls.Add(PositionLabel)
        Me.tbpCurrentElement.Controls.Add(Me.PositionComboBox)
        Me.tbpCurrentElement.Controls.Add(Me.Label3)
        Me.tbpCurrentElement.Controls.Add(Me.nudElementPosition)
        Me.tbpCurrentElement.Controls.Add(Me.cbElementBorder)
        Me.tbpCurrentElement.Controls.Add(Me.BorderSpecifiedCheckBox)
        Me.tbpCurrentElement.Controls.Add(AltLabel)
        Me.tbpCurrentElement.Controls.Add(Me.AltTextBox)
        Me.tbpCurrentElement.Location = New System.Drawing.Point(4, 22)
        Me.tbpCurrentElement.Name = "tbpCurrentElement"
        Me.tbpCurrentElement.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpCurrentElement.Size = New System.Drawing.Size(693, 453)
        Me.tbpCurrentElement.TabIndex = 2
        Me.tbpCurrentElement.Text = "Элемент"
        '
        'dgvImaged
        '
        Me.dgvImaged.AutoGenerateColumns = False
        Me.dgvImaged.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvImaged.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn8})
        Me.dgvImaged.DataSource = Me.IMAGEBindingSource
        Me.dgvImaged.Enabled = False
        Me.dgvImaged.Location = New System.Drawing.Point(6, 255)
        Me.dgvImaged.Name = "dgvImaged"
        Me.dgvImaged.Size = New System.Drawing.Size(556, 192)
        Me.dgvImaged.TabIndex = 16
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "src"
        Me.DataGridViewTextBoxColumn4.HeaderText = "src"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "from"
        Me.DataGridViewTextBoxColumn5.HeaderText = "from"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "layout"
        Me.DataGridViewTextBoxColumn6.HeaderText = "layout"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "alt"
        Me.DataGridViewTextBoxColumn7.HeaderText = "alt"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "position"
        Me.DataGridViewTextBoxColumn8.HeaderText = "position"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        '
        'IMAGEBindingSource
        '
        Me.IMAGEBindingSource.DataSource = GetType(CATALOGSAMPLEELEMENTENVIRONMENTIMAGE)
        '
        'btDeleteAdd
        '
        Me.btDeleteAdd.Enabled = False
        Me.btDeleteAdd.Location = New System.Drawing.Point(165, 148)
        Me.btDeleteAdd.Name = "btDeleteAdd"
        Me.btDeleteAdd.Size = New System.Drawing.Size(137, 23)
        Me.btDeleteAdd.TabIndex = 16
        Me.btDeleteAdd.Text = "удалить дополнение"
        Me.btDeleteAdd.UseVisualStyleBackColor = True
        '
        'btCreateAdd
        '
        Me.btCreateAdd.Enabled = False
        Me.btCreateAdd.Location = New System.Drawing.Point(12, 148)
        Me.btCreateAdd.Name = "btCreateAdd"
        Me.btCreateAdd.Size = New System.Drawing.Size(137, 23)
        Me.btCreateAdd.TabIndex = 15
        Me.btCreateAdd.Text = "создать дополнение"
        Me.btCreateAdd.UseVisualStyleBackColor = True
        '
        'cbResourceType
        '
        Me.cbResourceType.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bs_Description, "ENVIRONMENT.type", True))
        Me.cbResourceType.DataSource = Me.BindingSourceEnvirType
        Me.cbResourceType.Enabled = False
        Me.cbResourceType.FormattingEnabled = True
        Me.cbResourceType.Location = New System.Drawing.Point(117, 218)
        Me.cbResourceType.Name = "cbResourceType"
        Me.cbResourceType.Size = New System.Drawing.Size(121, 21)
        Me.cbResourceType.TabIndex = 14
        '
        'BindingSourceEnvirType
        '
        Me.BindingSourceEnvirType.DataSource = GetType(CATALOGSAMPLEELEMENTENVIRONMENT.emEnviropmentType)
        '
        'tbHrefAdditional
        '
        Me.tbHrefAdditional.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bs_Description, "ENVIRONMENT.href", True))
        Me.tbHrefAdditional.Enabled = False
        Me.tbHrefAdditional.Location = New System.Drawing.Point(126, 186)
        Me.tbHrefAdditional.Name = "tbHrefAdditional"
        Me.tbHrefAdditional.Size = New System.Drawing.Size(453, 20)
        Me.tbHrefAdditional.TabIndex = 11
        '
        'TextRichTextBox
        '
        Me.TextRichTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bs_Description, "Text", True))
        Me.TextRichTextBox.Location = New System.Drawing.Point(75, 41)
        Me.TextRichTextBox.Name = "TextRichTextBox"
        Me.TextRichTextBox.Size = New System.Drawing.Size(382, 96)
        Me.TextRichTextBox.TabIndex = 10
        Me.TextRichTextBox.Text = ""
        '
        'PositionComboBox
        '
        Me.PositionComboBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bs_Description, "position", True))
        Me.PositionComboBox.DataSource = Me.BindingSourcePosition
        Me.PositionComboBox.FormattingEnabled = True
        Me.PositionComboBox.Location = New System.Drawing.Point(480, 92)
        Me.PositionComboBox.Name = "PositionComboBox"
        Me.PositionComboBox.Size = New System.Drawing.Size(98, 21)
        Me.PositionComboBox.TabIndex = 9
        '
        'BindingSourcePosition
        '
        Me.BindingSourcePosition.DataSource = GetType(CATALOGSAMPLEELEMENT.emPosition)
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(522, 70)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(33, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Order"
        '
        'nudElementPosition
        '
        Me.nudElementPosition.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.bs_Description, "order", True))
        Me.nudElementPosition.Location = New System.Drawing.Point(480, 66)
        Me.nudElementPosition.Name = "nudElementPosition"
        Me.nudElementPosition.Size = New System.Drawing.Size(32, 20)
        Me.nudElementPosition.TabIndex = 7
        '
        'cbElementBorder
        '
        Me.cbElementBorder.AutoSize = True
        Me.cbElementBorder.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Me.bs_Description, "border", True))
        Me.cbElementBorder.Location = New System.Drawing.Point(480, 13)
        Me.cbElementBorder.Name = "cbElementBorder"
        Me.cbElementBorder.Size = New System.Drawing.Size(195, 17)
        Me.cbElementBorder.TabIndex = 6
        Me.cbElementBorder.Text = "Очертить ганицу блока элемента"
        Me.cbElementBorder.UseVisualStyleBackColor = True
        '
        'BorderSpecifiedCheckBox
        '
        Me.BorderSpecifiedCheckBox.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.bs_Description, "underline", True))
        Me.BorderSpecifiedCheckBox.Location = New System.Drawing.Point(481, 36)
        Me.BorderSpecifiedCheckBox.Name = "BorderSpecifiedCheckBox"
        Me.BorderSpecifiedCheckBox.Size = New System.Drawing.Size(178, 24)
        Me.BorderSpecifiedCheckBox.TabIndex = 5
        Me.BorderSpecifiedCheckBox.Text = "подчеркивение строки"
        Me.BorderSpecifiedCheckBox.UseVisualStyleBackColor = True
        '
        'AltTextBox
        '
        Me.AltTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bs_Description, "alt", True))
        Me.AltTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.AltTextBox.Location = New System.Drawing.Point(75, 13)
        Me.AltTextBox.Name = "AltTextBox"
        Me.AltTextBox.Size = New System.Drawing.Size(194, 22)
        Me.AltTextBox.TabIndex = 1
        '
        'rtbElementText
        '
        Me.rtbElementText.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bs_Description, "Text", True))
        Me.rtbElementText.Location = New System.Drawing.Point(196, 551)
        Me.rtbElementText.Name = "rtbElementText"
        Me.rtbElementText.Size = New System.Drawing.Size(501, 65)
        Me.rtbElementText.TabIndex = 26
        Me.rtbElementText.Text = ""
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(195, 522)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(113, 13)
        Me.Label1.TabIndex = 27
        Me.Label1.Text = "Заголовок элемента"
        '
        'tbAltTag
        '
        Me.tbAltTag.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bs_Description, "alt", True))
        Me.tbAltTag.Location = New System.Drawing.Point(320, 521)
        Me.tbAltTag.Name = "tbAltTag"
        Me.tbAltTag.Size = New System.Drawing.Size(377, 20)
        Me.tbAltTag.TabIndex = 28
        '
        'cbSowAllOverlays
        '
        Me.cbSowAllOverlays.AutoSize = True
        Me.cbSowAllOverlays.Location = New System.Drawing.Point(417, 496)
        Me.cbSowAllOverlays.Name = "cbSowAllOverlays"
        Me.cbSowAllOverlays.Size = New System.Drawing.Size(121, 17)
        Me.cbSowAllOverlays.TabIndex = 29
        Me.cbSowAllOverlays.Text = "показать все слои"
        Me.cbSowAllOverlays.UseVisualStyleBackColor = True
        '
        'btRefreshBrowser
        '
        Me.btRefreshBrowser.Location = New System.Drawing.Point(544, 492)
        Me.btRefreshBrowser.Name = "btRefreshBrowser"
        Me.btRefreshBrowser.Size = New System.Drawing.Size(153, 23)
        Me.btRefreshBrowser.TabIndex = 30
        Me.btRefreshBrowser.Text = "обновить HTML"
        Me.btRefreshBrowser.UseVisualStyleBackColor = True
        '
        'btAddElement
        '
        Me.btAddElement.Location = New System.Drawing.Point(8, 614)
        Me.btAddElement.Name = "btAddElement"
        Me.btAddElement.Size = New System.Drawing.Size(69, 23)
        Me.btAddElement.TabIndex = 31
        Me.btAddElement.Text = "Добавить"
        Me.btAddElement.UseVisualStyleBackColor = True
        '
        'btDeleteElement
        '
        Me.btDeleteElement.Location = New System.Drawing.Point(110, 614)
        Me.btDeleteElement.Name = "btDeleteElement"
        Me.btDeleteElement.Size = New System.Drawing.Size(69, 23)
        Me.btDeleteElement.TabIndex = 32
        Me.btDeleteElement.Text = "Удалить"
        Me.btDeleteElement.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(199, 623)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(318, 13)
        Me.Label4.TabIndex = 33
        Me.Label4.Text = "*для обновления окна с описанием нажмите обновить HTML"
        '
        'btPreView
        '
        Me.btPreView.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btPreView.Location = New System.Drawing.Point(535, 643)
        Me.btPreView.Name = "btPreView"
        Me.btPreView.Size = New System.Drawing.Size(166, 26)
        Me.btPreView.TabIndex = 34
        Me.btPreView.Text = "просмотр"
        Me.btPreView.UseVisualStyleBackColor = True
        '
        'cbTemplates
        '
        Me.cbTemplates.FormattingEnabled = True
        Me.cbTemplates.Location = New System.Drawing.Point(378, 646)
        Me.cbTemplates.Name = "cbTemplates"
        Me.cbTemplates.Size = New System.Drawing.Size(149, 21)
        Me.cbTemplates.TabIndex = 35
        '
        'fmCreateMAP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1240, 671)
        Me.Controls.Add(Me.cbTemplates)
        Me.Controls.Add(Me.btPreView)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.rbBlock)
        Me.Controls.Add(Me.btDeleteElement)
        Me.Controls.Add(Me.rbArrow)
        Me.Controls.Add(Me.btAddElement)
        Me.Controls.Add(Me.btRefreshBrowser)
        Me.Controls.Add(Me.cbSowAllOverlays)
        Me.Controls.Add(Me.tbAltTag)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.rtbElementText)
        Me.Controls.Add(Me.btReady)
        Me.Controls.Add(Me.btAddToElement)
        Me.Controls.Add(Me.tbctlMain)
        Me.Controls.Add(Me.lbDescriptionElement)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "fmCreateMAP"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Управление картами 1.0"
        Me.Panel1.ResumeLayout(False)
        CType(Me.bs_Description, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bs_MAP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvMAP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvOverlay, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bs_overlay, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bs_selectedOverlay, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bs_SelectedMap, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmOverlayTypeBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbctlMain.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.dgvSelectedOverlay, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbpCurrentElement.ResumeLayout(False)
        Me.tbpCurrentElement.PerformLayout()
        CType(Me.dgvImaged, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IMAGEBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingSourceEnvirType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingSourcePosition, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudElementPosition, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btAddToElement As System.Windows.Forms.Button
    Friend WithEvents lbDescriptionElement As System.Windows.Forms.ListBox
    Friend WithEvents btSetPoint As System.Windows.Forms.Button
    Friend WithEvents bs_MAP As System.Windows.Forms.BindingSource
    Friend WithEvents dgvMAP As System.Windows.Forms.DataGridView
    Friend WithEvents dgvOverlay As System.Windows.Forms.DataGridView
    Friend WithEvents EmOverlayTypeBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents btDelSelectedMap As System.Windows.Forms.Button
    Friend WithEvents btDelOverlay As System.Windows.Forms.Button
    Friend WithEvents btSetSize As System.Windows.Forms.Button
    Friend WithEvents rbBlock As System.Windows.Forms.RadioButton
    Friend WithEvents rbArrow As System.Windows.Forms.RadioButton
    Friend WithEvents btReady As System.Windows.Forms.Button
    Friend WithEvents btSaveMaps As System.Windows.Forms.Button
    Friend WithEvents bs_Description As System.Windows.Forms.BindingSource
    Friend WithEvents bs_overlay As System.Windows.Forms.BindingSource
    Friend WithEvents tbctlMain As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents dgvSelectedOverlay As System.Windows.Forms.DataGridView
    Friend WithEvents btSetPointLayer As System.Windows.Forms.Button
    Friend WithEvents btSetSizeLayer As System.Windows.Forms.Button
    Friend WithEvents btSaveLayerToMaps As System.Windows.Forms.Button
    Friend WithEvents btDeleteLayerFromMaps As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents bs_selectedOverlay As System.Windows.Forms.BindingSource
    Friend WithEvents bs_SelectedMap As System.Windows.Forms.BindingSource

    Private Sub bs_Description_CurrentChanged(sender As Object, e As System.EventArgs) Handles bs_Description.CurrentChanged

        Me.bs_SelectedMap.DataSource = {CType(Me.bs_Description.Current, CATALOGSAMPLEELEMENT).MAP}
    End Sub
    Friend WithEvents rtbElementText As System.Windows.Forms.RichTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tbAltTag As System.Windows.Forms.TextBox
    Friend WithEvents HrefTextBox As System.Windows.Forms.TextBox
    Friend WithEvents IdTextBox As System.Windows.Forms.TextBox
    Friend WithEvents TextTextBox As System.Windows.Forms.TextBox
    Friend WithEvents btDeleteMapFromElement As System.Windows.Forms.Button
    Friend WithEvents cbSowAllOverlays As System.Windows.Forms.CheckBox
    Friend WithEvents btRefreshBrowser As System.Windows.Forms.Button
    Friend WithEvents btCreateOverlay As System.Windows.Forms.Button
    Friend WithEvents btCreateOverlaySelected As System.Windows.Forms.Button
    Friend WithEvents tbpCurrentElement As System.Windows.Forms.TabPage
    Friend WithEvents BorderSpecifiedCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents AltTextBox As System.Windows.Forms.TextBox
    Friend WithEvents cbElementBorder As System.Windows.Forms.CheckBox
    Friend WithEvents PositionComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents nudElementPosition As System.Windows.Forms.NumericUpDown
    Friend WithEvents tbHrefAdditional As System.Windows.Forms.TextBox
    Friend WithEvents TextRichTextBox As System.Windows.Forms.RichTextBox
    Friend WithEvents dgvImaged As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IMAGEBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents btDeleteAdd As System.Windows.Forms.Button
    Friend WithEvents btCreateAdd As System.Windows.Forms.Button
    Friend WithEvents cbResourceType As System.Windows.Forms.ComboBox
    Friend WithEvents BindingSourcePosition As System.Windows.Forms.BindingSource
    Friend WithEvents BindingSourceEnvirType As System.Windows.Forms.BindingSource
    Friend WithEvents WebBrowser1 As System.Windows.Forms.WebBrowser
    Friend WithEvents btAddElement As System.Windows.Forms.Button
    Friend WithEvents btDeleteElement As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btAddMap As System.Windows.Forms.Button
    Friend WithEvents gvisible As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents gopacity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IdDataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TextDataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Position As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gSize As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents type As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents filename As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents g2Visible As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents g2Opacity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IdDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TextDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents g1Size As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IdDataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TextDataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btPreView As System.Windows.Forms.Button
    Friend WithEvents cbTemplates As System.Windows.Forms.ComboBox
End Class
