<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fmSampleData
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
    '<System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim Sample_nicknameLabel As System.Windows.Forms.Label
        Dim Woker_full_nameLabel As System.Windows.Forms.Label
        Dim Fossil_countLabel As System.Windows.Forms.Label
        Me.Sample_net_weightLabel = New System.Windows.Forms.Label()
        Me.Sample_widthLabel = New System.Windows.Forms.Label()
        Me.Sample_lengthLabel = New System.Windows.Forms.Label()
        Me.Sample_heightLabel = New System.Windows.Forms.Label()
        Me.SampleNumberLabel = New System.Windows.Forms.Label()
        Me.SampleNumberTextBox = New System.Windows.Forms.TextBox()
        Me.Sample_net_weightTextBox = New System.Windows.Forms.TextBox()
        Me.Select_tb_Samples_photo_dataBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsPhotoData = New Photo_reader.dsPhotoData()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Sample_heightTextBox = New System.Windows.Forms.TextBox()
        Me.Sample_lengthTextBox = New System.Windows.Forms.TextBox()
        Me.Sample_widthTextBox = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btMainName = New System.Windows.Forms.Button()
        Me.cbxLoadAllNames = New System.Windows.Forms.CheckBox()
        Me.btFromMoySclad = New System.Windows.Forms.Button()
        Me.lbTreeName = New System.Windows.Forms.Label()
        Me.cbListOfTree = New System.Windows.Forms.ComboBox()
        Me.btLoadTree = New System.Windows.Forms.Button()
        Me.cbMaterial = New System.Windows.Forms.ComboBox()
        Me.btDescriptionForm = New System.Windows.Forms.Button()
        Me.Sample_main_speciesComboBox = New System.Windows.Forms.ComboBox()
        Me.Date_PhotoDateTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.Woker_full_nameComboBox = New System.Windows.Forms.ComboBox()
        Me.Sample_nicknameTextBox = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.UcFossilTabPage1 = New Photo_reader.ucFossilTabPage()
        Me.btAddFossil = New System.Windows.Forms.Button()
        Me.Fossil_countTextBox = New System.Windows.Forms.TextBox()
        Me.GetFossilsCountInSampleBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.btSaveAll = New System.Windows.Forms.Button()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.pbMainImage = New System.Windows.Forms.PictureBox()
        Me.btToSite = New System.Windows.Forms.Button()
        Me.btSearchInfo = New System.Windows.Forms.Button()
        Me.lbSampleStatus = New System.Windows.Forms.Label()
        Me.btClearAll = New System.Windows.Forms.Button()
        Me.rbEnglish = New System.Windows.Forms.RadioButton()
        Me.rbRussian = New System.Windows.Forms.RadioButton()
        Me.btGetDescriptionBuilder = New System.Windows.Forms.Button()
        Me.btCopyNumber = New System.Windows.Forms.Button()
        Me.btCopyArticul = New System.Windows.Forms.Button()
        Me.btToMoySklad = New System.Windows.Forms.Button()
        Me.tpctlMain = New System.Windows.Forms.TabControl()
        Me.tpndescription = New System.Windows.Forms.TabPage()
        Me.cbxLabelXML = New System.Windows.Forms.CheckBox()
        Me.cbxRawXMLView = New System.Windows.Forms.CheckBox()
        Me.DescriptionRichTextBox = New System.Windows.Forms.RichTextBox()
        Me.btRemoveFromList = New System.Windows.Forms.Button()
        Me.cbPrefixElement = New System.Windows.Forms.ComboBox()
        Me.cbTagOfElement = New System.Windows.Forms.ComboBox()
        Me.btAddInListOfFrase = New System.Windows.Forms.Button()
        Me.btDelElement = New System.Windows.Forms.Button()
        Me.btAddInElement = New System.Windows.Forms.Button()
        Me.btAddUserDescr = New System.Windows.Forms.Button()
        Me.btSaveElement = New System.Windows.Forms.Button()
        Me.lbFrase = New System.Windows.Forms.ListBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lbElements = New System.Windows.Forms.ListBox()
        Me.UserDescriptionRichTextBox = New System.Windows.Forms.RichTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.UcGoodLabel1 = New Service.ucGoodLabel()
        Me.tpPhoto = New System.Windows.Forms.TabPage()
        Me.UcPhotoManager1 = New Service.ucPhotoManager()
        Me.tpMoySklad = New System.Windows.Forms.TabPage()
        Me.UC_siteCheck1 = New Service.UC_siteCheck()
        Me.btNameToMC = New System.Windows.Forms.Button()
        Me.btAddWeightToMC = New System.Windows.Forms.Button()
        Me.UserControlMC1 = New Service.UserControlMC()
        Me.tpRFID = New System.Windows.Forms.TabPage()
        Me.UC_rfid1 = New Service.UC_rfid()
        Me.tpTrilboneInfo = New System.Windows.Forms.TabPage()
        Me.Uc_trilbone_history1 = New Service.Uc_trilbone_history()
        Me.tpPakage = New System.Windows.Forms.TabPage()
        Me.lbPackageType = New System.Windows.Forms.Label()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.RadioButton5 = New System.Windows.Forms.RadioButton()
        Me.RadioButton4 = New System.Windows.Forms.RadioButton()
        Me.RadioButton3 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.tbVolumeOffset = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.tbBoxes = New System.Windows.Forms.TabControl()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.tb_weightBox = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.tbReikaB = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.tbReikaA = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.tbReika_leight = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.tbFanera_percent = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.tb_Fanera_qty = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.tbCover = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.tbSideB = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.tbSideA = New System.Windows.Forms.TextBox()
        Me.tbReikaThin = New System.Windows.Forms.TextBox()
        Me.tbFaneraThin = New System.Windows.Forms.TextBox()
        Me.tbVolumeWeight = New System.Windows.Forms.TextBox()
        Me.tbVolume = New System.Windows.Forms.TextBox()
        Me.tbFullSize = New System.Windows.Forms.TextBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tpOldDescription = New System.Windows.Forms.TabPage()
        Me.gbDBLabel = New System.Windows.Forms.GroupBox()
        Me.btReadFromDescripElem = New System.Windows.Forms.Button()
        Me.btRecToDB = New System.Windows.Forms.Button()
        Me.cbxGetLabelInfoFromDB = New System.Windows.Forms.CheckBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.OrderDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ValueDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ClsLabelInfoBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.btSaveLabelToDB = New System.Windows.Forms.Button()
        Me.rtbLabel = New System.Windows.Forms.RichTextBox()
        Me.btCopyToLabelinfo = New System.Windows.Forms.Button()
        Me.btCopyToLabel = New System.Windows.Forms.Button()
        Me.BindingSource_BOXES = New System.Windows.Forms.BindingSource(Me.components)
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.ilNodePhoto = New System.Windows.Forms.ImageList(Me.components)
        Me.btSearchLabels = New System.Windows.Forms.Button()
        Me.cbSearchLabelsResult = New System.Windows.Forms.ComboBox()
        Me.btCreateDescription = New System.Windows.Forms.Button()
        Me.cmsLabelInfo = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.tsmiDown = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiUp = New System.Windows.Forms.ToolStripMenuItem()
        Me.btDrawLabel = New System.Windows.Forms.Button()
        Me.btGetNumber = New System.Windows.Forms.Button()
        Me.btQuickPrint = New System.Windows.Forms.Button()
        Me.cbxGetXMLFromDB = New System.Windows.Forms.CheckBox()
        Me.iSampleImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.btReadRFID = New System.Windows.Forms.Button()
        Me.cbReadyForSale = New System.Windows.Forms.CheckBox()
        Me.lblOnSaleCreator = New System.Windows.Forms.Label()
        Me.btShowMap = New System.Windows.Forms.Button()
        Me.cbPrintPrice = New System.Windows.Forms.CheckBox()
        Me.btSizeString = New System.Windows.Forms.Button()
        Me.Select_tb_Samples_photo_dataTableAdapter = New Photo_reader.dsPhotoDataTableAdapters.Select_tb_Samples_photo_dataTableAdapter()
        Me.TableAdapterManager = New Photo_reader.dsPhotoDataTableAdapters.TableAdapterManager()
        Me.Select_tb_Samples_FossilsTableAdapter = New Photo_reader.dsPhotoDataTableAdapters.Select_tb_Samples_FossilsTableAdapter()
        Me.Select_tb_Samples_FossilsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.GetFossilsCountInSampleTableAdapter = New Photo_reader.dsPhotoDataTableAdapters.GetFossilsCountInSampleTableAdapter()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.btCopyEAN = New System.Windows.Forms.Button()
        Me.btImportData = New System.Windows.Forms.Button()
        Sample_nicknameLabel = New System.Windows.Forms.Label()
        Woker_full_nameLabel = New System.Windows.Forms.Label()
        Fossil_countLabel = New System.Windows.Forms.Label()
        CType(Me.Select_tb_Samples_photo_dataBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsPhotoData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.GetFossilsCountInSampleBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbMainImage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpctlMain.SuspendLayout()
        Me.tpndescription.SuspendLayout()
        Me.tpPhoto.SuspendLayout()
        Me.tpMoySklad.SuspendLayout()
        Me.tpRFID.SuspendLayout()
        Me.tpTrilboneInfo.SuspendLayout()
        Me.tpPakage.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.tbBoxes.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.tpOldDescription.SuspendLayout()
        Me.gbDBLabel.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ClsLabelInfoBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingSource_BOXES, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsLabelInfo.SuspendLayout()
        CType(Me.Select_tb_Samples_FossilsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Sample_nicknameLabel
        '
        Sample_nicknameLabel.AutoSize = True
        Sample_nicknameLabel.Location = New System.Drawing.Point(6, 51)
        Sample_nicknameLabel.Name = "Sample_nicknameLabel"
        Sample_nicknameLabel.Size = New System.Drawing.Size(109, 13)
        Sample_nicknameLabel.TabIndex = 21
        Sample_nicknameLabel.Text = "Короткое название:"
        '
        'Woker_full_nameLabel
        '
        Woker_full_nameLabel.AutoSize = True
        Woker_full_nameLabel.Location = New System.Drawing.Point(6, 78)
        Woker_full_nameLabel.Name = "Woker_full_nameLabel"
        Woker_full_nameLabel.Size = New System.Drawing.Size(58, 13)
        Woker_full_nameLabel.TabIndex = 21
        Woker_full_nameLabel.Text = "Оформил:"
        '
        'Fossil_countLabel
        '
        Fossil_countLabel.AutoSize = True
        Fossil_countLabel.Location = New System.Drawing.Point(6, 16)
        Fossil_countLabel.Name = "Fossil_countLabel"
        Fossil_countLabel.Size = New System.Drawing.Size(69, 13)
        Fossil_countLabel.TabIndex = 21
        Fossil_countLabel.Text = "Количество:"
        '
        'Sample_net_weightLabel
        '
        Me.Sample_net_weightLabel.AutoSize = True
        Me.Sample_net_weightLabel.Location = New System.Drawing.Point(6, 25)
        Me.Sample_net_weightLabel.Name = "Sample_net_weightLabel"
        Me.Sample_net_weightLabel.Size = New System.Drawing.Size(56, 17)
        Me.Sample_net_weightLabel.TabIndex = 21
        Me.Sample_net_weightLabel.Text = "Вес, кг:"
        '
        'Sample_widthLabel
        '
        Me.Sample_widthLabel.AutoSize = True
        Me.Sample_widthLabel.Location = New System.Drawing.Point(6, 79)
        Me.Sample_widthLabel.Name = "Sample_widthLabel"
        Me.Sample_widthLabel.Size = New System.Drawing.Size(87, 17)
        Me.Sample_widthLabel.TabIndex = 21
        Me.Sample_widthLabel.Text = "Ширина, см:"
        '
        'Sample_lengthLabel
        '
        Me.Sample_lengthLabel.AutoSize = True
        Me.Sample_lengthLabel.Location = New System.Drawing.Point(6, 52)
        Me.Sample_lengthLabel.Name = "Sample_lengthLabel"
        Me.Sample_lengthLabel.Size = New System.Drawing.Size(79, 17)
        Me.Sample_lengthLabel.TabIndex = 21
        Me.Sample_lengthLabel.Text = "Длина, см:"
        '
        'Sample_heightLabel
        '
        Me.Sample_heightLabel.AutoSize = True
        Me.Sample_heightLabel.Location = New System.Drawing.Point(6, 105)
        Me.Sample_heightLabel.Name = "Sample_heightLabel"
        Me.Sample_heightLabel.Size = New System.Drawing.Size(85, 17)
        Me.Sample_heightLabel.TabIndex = 21
        Me.Sample_heightLabel.Text = "Высота, см:"
        '
        'SampleNumberLabel
        '
        Me.SampleNumberLabel.AutoSize = True
        Me.SampleNumberLabel.Location = New System.Drawing.Point(6, 46)
        Me.SampleNumberLabel.Name = "SampleNumberLabel"
        Me.SampleNumberLabel.Size = New System.Drawing.Size(44, 13)
        Me.SampleNumberLabel.TabIndex = 21
        Me.SampleNumberLabel.Text = "Номер:"
        '
        'SampleNumberTextBox
        '
        Me.SampleNumberTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.SampleNumberTextBox.Location = New System.Drawing.Point(52, 43)
        Me.SampleNumberTextBox.Name = "SampleNumberTextBox"
        Me.SampleNumberTextBox.Size = New System.Drawing.Size(111, 22)
        Me.SampleNumberTextBox.TabIndex = 0
        '
        'Sample_net_weightTextBox
        '
        Me.Sample_net_weightTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Select_tb_Samples_photo_dataBindingSource, "Sample_net_weight", True))
        Me.Sample_net_weightTextBox.Location = New System.Drawing.Point(99, 22)
        Me.Sample_net_weightTextBox.Name = "Sample_net_weightTextBox"
        Me.Sample_net_weightTextBox.Size = New System.Drawing.Size(59, 23)
        Me.Sample_net_weightTextBox.TabIndex = 1
        '
        'Select_tb_Samples_photo_dataBindingSource
        '
        Me.Select_tb_Samples_photo_dataBindingSource.DataMember = "Select_tb_Samples_photo_data"
        Me.Select_tb_Samples_photo_dataBindingSource.DataSource = Me.DsPhotoData
        '
        'DsPhotoData
        '
        Me.DsPhotoData.DataSetName = "dsPhotoData"
        Me.DsPhotoData.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Sample_heightTextBox)
        Me.GroupBox1.Controls.Add(Me.Sample_heightLabel)
        Me.GroupBox1.Controls.Add(Me.Sample_lengthLabel)
        Me.GroupBox1.Controls.Add(Me.Sample_net_weightTextBox)
        Me.GroupBox1.Controls.Add(Me.Sample_lengthTextBox)
        Me.GroupBox1.Controls.Add(Me.Sample_net_weightLabel)
        Me.GroupBox1.Controls.Add(Me.Sample_widthLabel)
        Me.GroupBox1.Controls.Add(Me.Sample_widthTextBox)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 211)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(180, 136)
        Me.GroupBox1.TabIndex = 21
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Параметры камня"
        '
        'Sample_heightTextBox
        '
        Me.Sample_heightTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Select_tb_Samples_photo_dataBindingSource, "Sample_height", True))
        Me.Sample_heightTextBox.Location = New System.Drawing.Point(99, 102)
        Me.Sample_heightTextBox.Name = "Sample_heightTextBox"
        Me.Sample_heightTextBox.Size = New System.Drawing.Size(59, 23)
        Me.Sample_heightTextBox.TabIndex = 4
        '
        'Sample_lengthTextBox
        '
        Me.Sample_lengthTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Select_tb_Samples_photo_dataBindingSource, "Sample_length", True))
        Me.Sample_lengthTextBox.Location = New System.Drawing.Point(99, 49)
        Me.Sample_lengthTextBox.Name = "Sample_lengthTextBox"
        Me.Sample_lengthTextBox.Size = New System.Drawing.Size(59, 23)
        Me.Sample_lengthTextBox.TabIndex = 2
        '
        'Sample_widthTextBox
        '
        Me.Sample_widthTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Select_tb_Samples_photo_dataBindingSource, "Sample_width", True))
        Me.Sample_widthTextBox.Location = New System.Drawing.Point(99, 76)
        Me.Sample_widthTextBox.Name = "Sample_widthTextBox"
        Me.Sample_widthTextBox.Size = New System.Drawing.Size(59, 23)
        Me.Sample_widthTextBox.TabIndex = 3
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label25)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.btMainName)
        Me.GroupBox2.Controls.Add(Me.cbxLoadAllNames)
        Me.GroupBox2.Controls.Add(Me.btFromMoySclad)
        Me.GroupBox2.Controls.Add(Me.lbTreeName)
        Me.GroupBox2.Controls.Add(Me.cbListOfTree)
        Me.GroupBox2.Controls.Add(Me.btLoadTree)
        Me.GroupBox2.Controls.Add(Me.cbMaterial)
        Me.GroupBox2.Controls.Add(Me.btDescriptionForm)
        Me.GroupBox2.Controls.Add(Me.Sample_main_speciesComboBox)
        Me.GroupBox2.Controls.Add(Me.Date_PhotoDateTimePicker)
        Me.GroupBox2.Controls.Add(Me.Woker_full_nameComboBox)
        Me.GroupBox2.Controls.Add(Woker_full_nameLabel)
        Me.GroupBox2.Controls.Add(Me.Sample_nicknameTextBox)
        Me.GroupBox2.Controls.Add(Sample_nicknameLabel)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 371)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(513, 144)
        Me.GroupBox2.TabIndex = 21
        Me.GroupBox2.TabStop = False
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(306, 93)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(43, 13)
        Me.Label25.TabIndex = 34
        Me.Label25.Text = "раздел"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(306, 69)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 33
        Me.Label1.Text = "дерево"
        '
        'btMainName
        '
        Me.btMainName.Location = New System.Drawing.Point(7, 15)
        Me.btMainName.Name = "btMainName"
        Me.btMainName.Size = New System.Drawing.Size(75, 23)
        Me.btMainName.TabIndex = 32
        Me.btMainName.Text = "Название:"
        Me.btMainName.UseVisualStyleBackColor = True
        '
        'cbxLoadAllNames
        '
        Me.cbxLoadAllNames.AutoSize = True
        Me.cbxLoadAllNames.Location = New System.Drawing.Point(270, 43)
        Me.cbxLoadAllNames.Name = "cbxLoadAllNames"
        Me.cbxLoadAllNames.Size = New System.Drawing.Size(96, 17)
        Me.cbxLoadAllNames.TabIndex = 31
        Me.cbxLoadAllNames.Text = "Все названия"
        Me.cbxLoadAllNames.UseVisualStyleBackColor = True
        '
        'btFromMoySclad
        '
        Me.btFromMoySclad.Location = New System.Drawing.Point(238, 116)
        Me.btFromMoySclad.Name = "btFromMoySclad"
        Me.btFromMoySclad.Size = New System.Drawing.Size(107, 25)
        Me.btFromMoySclad.TabIndex = 30
        Me.btFromMoySclad.Text = "название из МС"
        Me.btFromMoySclad.UseVisualStyleBackColor = True
        '
        'lbTreeName
        '
        Me.lbTreeName.AutoSize = True
        Me.lbTreeName.Location = New System.Drawing.Point(390, 44)
        Me.lbTreeName.Name = "lbTreeName"
        Me.lbTreeName.Size = New System.Drawing.Size(95, 13)
        Me.lbTreeName.TabIndex = 26
        Me.lbTreeName.Text = "Список названий"
        '
        'cbListOfTree
        '
        Me.cbListOfTree.FormattingEnabled = True
        Me.cbListOfTree.Location = New System.Drawing.Point(360, 90)
        Me.cbListOfTree.Name = "cbListOfTree"
        Me.cbListOfTree.Size = New System.Drawing.Size(147, 21)
        Me.cbListOfTree.TabIndex = 25
        Me.cbListOfTree.Visible = False
        '
        'btLoadTree
        '
        Me.btLoadTree.Location = New System.Drawing.Point(360, 116)
        Me.btLoadTree.Name = "btLoadTree"
        Me.btLoadTree.Size = New System.Drawing.Size(147, 25)
        Me.btLoadTree.TabIndex = 24
        Me.btLoadTree.Text = "Загрузить названия.."
        Me.btLoadTree.UseVisualStyleBackColor = True
        '
        'cbMaterial
        '
        Me.cbMaterial.FormattingEnabled = True
        Me.cbMaterial.Location = New System.Drawing.Point(360, 63)
        Me.cbMaterial.Name = "cbMaterial"
        Me.cbMaterial.Size = New System.Drawing.Size(147, 21)
        Me.cbMaterial.TabIndex = 22
        '
        'btDescriptionForm
        '
        Me.btDescriptionForm.Location = New System.Drawing.Point(97, 115)
        Me.btDescriptionForm.Name = "btDescriptionForm"
        Me.btDescriptionForm.Size = New System.Drawing.Size(89, 25)
        Me.btDescriptionForm.TabIndex = 28
        Me.btDescriptionForm.Text = "Описания.."
        Me.btDescriptionForm.UseVisualStyleBackColor = True
        '
        'Sample_main_speciesComboBox
        '
        Me.Sample_main_speciesComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Sample_main_speciesComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Sample_main_speciesComboBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Select_tb_Samples_photo_dataBindingSource, "Sample_main_species", True))
        Me.Sample_main_speciesComboBox.FormattingEnabled = True
        Me.Sample_main_speciesComboBox.Location = New System.Drawing.Point(87, 17)
        Me.Sample_main_speciesComboBox.Name = "Sample_main_speciesComboBox"
        Me.Sample_main_speciesComboBox.Size = New System.Drawing.Size(416, 21)
        Me.Sample_main_speciesComboBox.TabIndex = 5
        '
        'Date_PhotoDateTimePicker
        '
        Me.Date_PhotoDateTimePicker.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.Select_tb_Samples_photo_dataBindingSource, "Date_Photo", True))
        Me.Date_PhotoDateTimePicker.Enabled = False
        Me.Date_PhotoDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Date_PhotoDateTimePicker.Location = New System.Drawing.Point(10, 99)
        Me.Date_PhotoDateTimePicker.Name = "Date_PhotoDateTimePicker"
        Me.Date_PhotoDateTimePicker.Size = New System.Drawing.Size(80, 20)
        Me.Date_PhotoDateTimePicker.TabIndex = 21
        '
        'Woker_full_nameComboBox
        '
        Me.Woker_full_nameComboBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Select_tb_Samples_photo_dataBindingSource, "Woker_full_name", True))
        Me.Woker_full_nameComboBox.FormattingEnabled = True
        Me.Woker_full_nameComboBox.Location = New System.Drawing.Point(70, 76)
        Me.Woker_full_nameComboBox.Name = "Woker_full_nameComboBox"
        Me.Woker_full_nameComboBox.Size = New System.Drawing.Size(140, 21)
        Me.Woker_full_nameComboBox.TabIndex = 6
        '
        'Sample_nicknameTextBox
        '
        Me.Sample_nicknameTextBox.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.Sample_nicknameTextBox.Location = New System.Drawing.Point(116, 48)
        Me.Sample_nicknameTextBox.Name = "Sample_nicknameTextBox"
        Me.Sample_nicknameTextBox.Size = New System.Drawing.Size(148, 20)
        Me.Sample_nicknameTextBox.TabIndex = 21
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.UcFossilTabPage1)
        Me.GroupBox3.Controls.Add(Me.btAddFossil)
        Me.GroupBox3.Controls.Add(Fossil_countLabel)
        Me.GroupBox3.Controls.Add(Me.Fossil_countTextBox)
        Me.GroupBox3.Location = New System.Drawing.Point(250, 6)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(275, 318)
        Me.GroupBox3.TabIndex = 21
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Объекты на образце"
        '
        'UcFossilTabPage1
        '
        Me.UcFossilTabPage1.FossilSelectedIndex = -1
        Me.UcFossilTabPage1.Location = New System.Drawing.Point(6, 39)
        Me.UcFossilTabPage1.Margin = New System.Windows.Forms.Padding(4)
        Me.UcFossilTabPage1.Name = "UcFossilTabPage1"
        Me.UcFossilTabPage1.Size = New System.Drawing.Size(263, 273)
        Me.UcFossilTabPage1.TabIndex = 22
        '
        'btAddFossil
        '
        Me.btAddFossil.Location = New System.Drawing.Point(126, 11)
        Me.btAddFossil.Name = "btAddFossil"
        Me.btAddFossil.Size = New System.Drawing.Size(139, 23)
        Me.btAddFossil.TabIndex = 21
        Me.btAddFossil.Text = "Добавить объект.."
        Me.btAddFossil.UseVisualStyleBackColor = True
        '
        'Fossil_countTextBox
        '
        Me.Fossil_countTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.GetFossilsCountInSampleBindingSource, "FossilsCount", True))
        Me.Fossil_countTextBox.Enabled = False
        Me.Fossil_countTextBox.Location = New System.Drawing.Point(78, 13)
        Me.Fossil_countTextBox.Name = "Fossil_countTextBox"
        Me.Fossil_countTextBox.Size = New System.Drawing.Size(29, 20)
        Me.Fossil_countTextBox.TabIndex = 21
        '
        'GetFossilsCountInSampleBindingSource
        '
        Me.GetFossilsCountInSampleBindingSource.DataMember = "GetFossilsCountInSample"
        Me.GetFossilsCountInSampleBindingSource.DataSource = Me.DsPhotoData
        '
        'btSaveAll
        '
        Me.btSaveAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btSaveAll.Location = New System.Drawing.Point(109, 521)
        Me.btSaveAll.Name = "btSaveAll"
        Me.btSaveAll.Size = New System.Drawing.Size(135, 45)
        Me.btSaveAll.TabIndex = 12
        Me.btSaveAll.Text = "Сохранить"
        Me.btSaveAll.UseVisualStyleBackColor = True
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(442, 18)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(95, 21)
        Me.ComboBox1.TabIndex = 8
        '
        'pbMainImage
        '
        Me.pbMainImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbMainImage.Location = New System.Drawing.Point(9, 117)
        Me.pbMainImage.Name = "pbMainImage"
        Me.pbMainImage.Size = New System.Drawing.Size(108, 87)
        Me.pbMainImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbMainImage.TabIndex = 25
        Me.pbMainImage.TabStop = False
        '
        'btToSite
        '
        Me.btToSite.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btToSite.Location = New System.Drawing.Point(380, 544)
        Me.btToSite.Name = "btToSite"
        Me.btToSite.Size = New System.Drawing.Size(139, 25)
        Me.btToSite.TabIndex = 26
        Me.btToSite.Text = "Выставить образец"
        Me.btToSite.UseVisualStyleBackColor = True
        '
        'btSearchInfo
        '
        Me.btSearchInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btSearchInfo.Location = New System.Drawing.Point(174, 26)
        Me.btSearchInfo.Name = "btSearchInfo"
        Me.btSearchInfo.Size = New System.Drawing.Size(66, 45)
        Me.btSearchInfo.TabIndex = 28
        Me.btSearchInfo.Text = "Поиск"
        Me.btSearchInfo.UseVisualStyleBackColor = True
        '
        'lbSampleStatus
        '
        Me.lbSampleStatus.AutoSize = True
        Me.lbSampleStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbSampleStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lbSampleStatus.Location = New System.Drawing.Point(129, 3)
        Me.lbSampleStatus.Name = "lbSampleStatus"
        Me.lbSampleStatus.Size = New System.Drawing.Size(101, 17)
        Me.lbSampleStatus.TabIndex = 29
        Me.lbSampleStatus.Text = "Текущий статус:"
        '
        'btClearAll
        '
        Me.btClearAll.Location = New System.Drawing.Point(927, 544)
        Me.btClearAll.Name = "btClearAll"
        Me.btClearAll.Size = New System.Drawing.Size(151, 25)
        Me.btClearAll.TabIndex = 45
        Me.btClearAll.Text = "Очистить описание"
        Me.btClearAll.UseVisualStyleBackColor = True
        '
        'rbEnglish
        '
        Me.rbEnglish.AutoSize = True
        Me.rbEnglish.Checked = True
        Me.rbEnglish.Location = New System.Drawing.Point(46, 354)
        Me.rbEnglish.Name = "rbEnglish"
        Me.rbEnglish.Size = New System.Drawing.Size(59, 17)
        Me.rbEnglish.TabIndex = 43
        Me.rbEnglish.TabStop = True
        Me.rbEnglish.Text = "English"
        Me.rbEnglish.UseVisualStyleBackColor = True
        '
        'rbRussian
        '
        Me.rbRussian.AutoSize = True
        Me.rbRussian.Location = New System.Drawing.Point(111, 354)
        Me.rbRussian.Name = "rbRussian"
        Me.rbRussian.Size = New System.Drawing.Size(67, 17)
        Me.rbRussian.TabIndex = 42
        Me.rbRussian.Text = "Русский"
        Me.rbRussian.UseVisualStyleBackColor = True
        '
        'btGetDescriptionBuilder
        '
        Me.btGetDescriptionBuilder.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btGetDescriptionBuilder.Location = New System.Drawing.Point(717, 544)
        Me.btGetDescriptionBuilder.Name = "btGetDescriptionBuilder"
        Me.btGetDescriptionBuilder.Size = New System.Drawing.Size(202, 25)
        Me.btGetDescriptionBuilder.TabIndex = 39
        Me.btGetDescriptionBuilder.Text = "Создать/добавить описание"
        Me.btGetDescriptionBuilder.UseVisualStyleBackColor = True
        '
        'btCopyNumber
        '
        Me.btCopyNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btCopyNumber.Location = New System.Drawing.Point(182, 77)
        Me.btCopyNumber.Name = "btCopyNumber"
        Me.btCopyNumber.Size = New System.Drawing.Size(59, 23)
        Me.btCopyNumber.TabIndex = 35
        Me.btCopyNumber.Text = "EAN font"
        Me.btCopyNumber.UseVisualStyleBackColor = True
        '
        'btCopyArticul
        '
        Me.btCopyArticul.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btCopyArticul.Location = New System.Drawing.Point(120, 77)
        Me.btCopyArticul.Name = "btCopyArticul"
        Me.btCopyArticul.Size = New System.Drawing.Size(56, 23)
        Me.btCopyArticul.TabIndex = 43
        Me.btCopyArticul.Text = "Папка"
        Me.btCopyArticul.UseVisualStyleBackColor = True
        '
        'btToMoySklad
        '
        Me.btToMoySklad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btToMoySklad.Location = New System.Drawing.Point(10, 521)
        Me.btToMoySklad.Name = "btToMoySklad"
        Me.btToMoySklad.Size = New System.Drawing.Size(84, 45)
        Me.btToMoySklad.TabIndex = 45
        Me.btToMoySklad.Text = "В мой склад"
        Me.btToMoySklad.UseVisualStyleBackColor = True
        '
        'tpctlMain
        '
        Me.tpctlMain.Controls.Add(Me.tpndescription)
        Me.tpctlMain.Controls.Add(Me.tpPhoto)
        Me.tpctlMain.Controls.Add(Me.tpMoySklad)
        Me.tpctlMain.Controls.Add(Me.tpRFID)
        Me.tpctlMain.Controls.Add(Me.tpTrilboneInfo)
        Me.tpctlMain.Controls.Add(Me.tpPakage)
        Me.tpctlMain.Controls.Add(Me.tpOldDescription)
        Me.tpctlMain.Location = New System.Drawing.Point(525, 14)
        Me.tpctlMain.Name = "tpctlMain"
        Me.tpctlMain.SelectedIndex = 0
        Me.tpctlMain.Size = New System.Drawing.Size(558, 522)
        Me.tpctlMain.TabIndex = 46
        '
        'tpndescription
        '
        Me.tpndescription.Controls.Add(Me.cbxLabelXML)
        Me.tpndescription.Controls.Add(Me.cbxRawXMLView)
        Me.tpndescription.Controls.Add(Me.DescriptionRichTextBox)
        Me.tpndescription.Controls.Add(Me.btRemoveFromList)
        Me.tpndescription.Controls.Add(Me.cbPrefixElement)
        Me.tpndescription.Controls.Add(Me.cbTagOfElement)
        Me.tpndescription.Controls.Add(Me.btAddInListOfFrase)
        Me.tpndescription.Controls.Add(Me.btDelElement)
        Me.tpndescription.Controls.Add(Me.btAddInElement)
        Me.tpndescription.Controls.Add(Me.btAddUserDescr)
        Me.tpndescription.Controls.Add(Me.btSaveElement)
        Me.tpndescription.Controls.Add(Me.lbFrase)
        Me.tpndescription.Controls.Add(Me.Label6)
        Me.tpndescription.Controls.Add(Me.lbElements)
        Me.tpndescription.Controls.Add(Me.UserDescriptionRichTextBox)
        Me.tpndescription.Controls.Add(Me.Label2)
        Me.tpndescription.Controls.Add(Me.UcGoodLabel1)
        Me.tpndescription.Location = New System.Drawing.Point(4, 22)
        Me.tpndescription.Name = "tpndescription"
        Me.tpndescription.Padding = New System.Windows.Forms.Padding(3)
        Me.tpndescription.Size = New System.Drawing.Size(550, 496)
        Me.tpndescription.TabIndex = 0
        Me.tpndescription.Text = "Этикетка"
        Me.tpndescription.UseVisualStyleBackColor = True
        '
        'cbxLabelXML
        '
        Me.cbxLabelXML.AutoSize = True
        Me.cbxLabelXML.Location = New System.Drawing.Point(372, 105)
        Me.cbxLabelXML.Name = "cbxLabelXML"
        Me.cbxLabelXML.Size = New System.Drawing.Size(97, 17)
        Me.cbxLabelXML.TabIndex = 100
        Me.cbxLabelXML.Text = "этикетка XML"
        Me.cbxLabelXML.UseVisualStyleBackColor = True
        '
        'cbxRawXMLView
        '
        Me.cbxRawXMLView.AutoSize = True
        Me.cbxRawXMLView.Location = New System.Drawing.Point(494, 105)
        Me.cbxRawXMLView.Name = "cbxRawXMLView"
        Me.cbxRawXMLView.Size = New System.Drawing.Size(48, 17)
        Me.cbxRawXMLView.TabIndex = 99
        Me.cbxRawXMLView.Text = "XML"
        Me.cbxRawXMLView.UseVisualStyleBackColor = True
        '
        'DescriptionRichTextBox
        '
        Me.DescriptionRichTextBox.Location = New System.Drawing.Point(307, 128)
        Me.DescriptionRichTextBox.Name = "DescriptionRichTextBox"
        Me.DescriptionRichTextBox.Size = New System.Drawing.Size(238, 105)
        Me.DescriptionRichTextBox.TabIndex = 98
        Me.DescriptionRichTextBox.Text = ""
        '
        'btRemoveFromList
        '
        Me.btRemoveFromList.Location = New System.Drawing.Point(390, 70)
        Me.btRemoveFromList.Name = "btRemoveFromList"
        Me.btRemoveFromList.Size = New System.Drawing.Size(152, 23)
        Me.btRemoveFromList.TabIndex = 97
        Me.btRemoveFromList.Text = "Удалить фразу из списка"
        Me.btRemoveFromList.UseVisualStyleBackColor = True
        '
        'cbPrefixElement
        '
        Me.cbPrefixElement.FormattingEnabled = True
        Me.cbPrefixElement.Location = New System.Drawing.Point(180, 212)
        Me.cbPrefixElement.Name = "cbPrefixElement"
        Me.cbPrefixElement.Size = New System.Drawing.Size(106, 21)
        Me.cbPrefixElement.TabIndex = 96
        '
        'cbTagOfElement
        '
        Me.cbTagOfElement.FormattingEnabled = True
        Me.cbTagOfElement.Items.AddRange(New Object() {"USERDESCR", "ITEM", ""})
        Me.cbTagOfElement.Location = New System.Drawing.Point(179, 170)
        Me.cbTagOfElement.Name = "cbTagOfElement"
        Me.cbTagOfElement.Size = New System.Drawing.Size(110, 21)
        Me.cbTagOfElement.TabIndex = 95
        '
        'btAddInListOfFrase
        '
        Me.btAddInListOfFrase.Location = New System.Drawing.Point(179, 9)
        Me.btAddInListOfFrase.Name = "btAddInListOfFrase"
        Me.btAddInListOfFrase.Size = New System.Drawing.Size(117, 23)
        Me.btAddInListOfFrase.TabIndex = 94
        Me.btAddInListOfFrase.Text = "в список фраз >>"
        Me.btAddInListOfFrase.UseVisualStyleBackColor = True
        '
        'btDelElement
        '
        Me.btDelElement.Location = New System.Drawing.Point(179, 95)
        Me.btDelElement.Name = "btDelElement"
        Me.btDelElement.Size = New System.Drawing.Size(117, 23)
        Me.btDelElement.TabIndex = 91
        Me.btDelElement.Text = "Удалить элемент"
        Me.btDelElement.UseVisualStyleBackColor = True
        '
        'btAddInElement
        '
        Me.btAddInElement.Location = New System.Drawing.Point(179, 37)
        Me.btAddInElement.Name = "btAddInElement"
        Me.btAddInElement.Size = New System.Drawing.Size(117, 23)
        Me.btAddInElement.TabIndex = 93
        Me.btAddInElement.Text = "<< в элемент"
        Me.btAddInElement.UseVisualStyleBackColor = True
        '
        'btAddUserDescr
        '
        Me.btAddUserDescr.Location = New System.Drawing.Point(179, 141)
        Me.btAddUserDescr.Name = "btAddUserDescr"
        Me.btAddUserDescr.Size = New System.Drawing.Size(117, 23)
        Me.btAddUserDescr.TabIndex = 90
        Me.btAddUserDescr.Text = "Добавить элемент"
        Me.btAddUserDescr.UseVisualStyleBackColor = True
        '
        'btSaveElement
        '
        Me.btSaveElement.Location = New System.Drawing.Point(179, 66)
        Me.btSaveElement.Name = "btSaveElement"
        Me.btSaveElement.Size = New System.Drawing.Size(117, 23)
        Me.btSaveElement.TabIndex = 92
        Me.btSaveElement.Text = "Обновить элемент"
        Me.btSaveElement.UseVisualStyleBackColor = True
        '
        'lbFrase
        '
        Me.lbFrase.FormattingEnabled = True
        Me.lbFrase.Location = New System.Drawing.Point(307, 21)
        Me.lbFrase.Name = "lbFrase"
        Me.lbFrase.Size = New System.Drawing.Size(235, 43)
        Me.lbFrase.TabIndex = 89
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(386, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(83, 13)
        Me.Label6.TabIndex = 88
        Me.Label6.Text = "Частые фразы"
        '
        'lbElements
        '
        Me.lbElements.FormattingEnabled = True
        Me.lbElements.Location = New System.Drawing.Point(6, 90)
        Me.lbElements.Name = "lbElements"
        Me.lbElements.Size = New System.Drawing.Size(160, 134)
        Me.lbElements.TabIndex = 87
        '
        'UserDescriptionRichTextBox
        '
        Me.UserDescriptionRichTextBox.Location = New System.Drawing.Point(5, 25)
        Me.UserDescriptionRichTextBox.Name = "UserDescriptionRichTextBox"
        Me.UserDescriptionRichTextBox.Size = New System.Drawing.Size(161, 59)
        Me.UserDescriptionRichTextBox.TabIndex = 85
        Me.UserDescriptionRichTextBox.Text = ""
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(110, 13)
        Me.Label2.TabIndex = 86
        Me.Label2.Text = "Элементы описания"
        '
        'UcGoodLabel1
        '
        Me.UcGoodLabel1.Location = New System.Drawing.Point(5, 231)
        Me.UcGoodLabel1.Name = "UcGoodLabel1"
        Me.UcGoodLabel1.NameForLabel = Nothing
        Me.UcGoodLabel1.Size = New System.Drawing.Size(540, 262)
        Me.UcGoodLabel1.Source = Service.ucGoodLabel.emLabelSource.DrawAi
        Me.UcGoodLabel1.TabIndex = 84
        '
        'tpPhoto
        '
        Me.tpPhoto.Controls.Add(Me.UcPhotoManager1)
        Me.tpPhoto.Location = New System.Drawing.Point(4, 22)
        Me.tpPhoto.Name = "tpPhoto"
        Me.tpPhoto.Padding = New System.Windows.Forms.Padding(3)
        Me.tpPhoto.Size = New System.Drawing.Size(550, 496)
        Me.tpPhoto.TabIndex = 3
        Me.tpPhoto.Text = "Фотки"
        Me.tpPhoto.UseVisualStyleBackColor = True
        '
        'UcPhotoManager1
        '
        Me.UcPhotoManager1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcPhotoManager1.GetLayerTextNumberDelegate = Nothing
        Me.UcPhotoManager1.Location = New System.Drawing.Point(3, 3)
        Me.UcPhotoManager1.Margin = New System.Windows.Forms.Padding(4)
        Me.UcPhotoManager1.Name = "UcPhotoManager1"
        Me.UcPhotoManager1.Size = New System.Drawing.Size(544, 490)
        Me.UcPhotoManager1.TabIndex = 0
        '
        'tpMoySklad
        '
        Me.tpMoySklad.Controls.Add(Me.UC_siteCheck1)
        Me.tpMoySklad.Controls.Add(Me.btNameToMC)
        Me.tpMoySklad.Controls.Add(Me.btAddWeightToMC)
        Me.tpMoySklad.Controls.Add(Me.UserControlMC1)
        Me.tpMoySklad.Location = New System.Drawing.Point(4, 22)
        Me.tpMoySklad.Name = "tpMoySklad"
        Me.tpMoySklad.Size = New System.Drawing.Size(550, 496)
        Me.tpMoySklad.TabIndex = 4
        Me.tpMoySklad.Text = "Мой Склад"
        Me.tpMoySklad.UseVisualStyleBackColor = True
        '
        'UC_siteCheck1
        '
        Me.UC_siteCheck1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.UC_siteCheck1.Location = New System.Drawing.Point(5, 310)
        Me.UC_siteCheck1.Margin = New System.Windows.Forms.Padding(4)
        Me.UC_siteCheck1.Name = "UC_siteCheck1"
        Me.UC_siteCheck1.SampleNumber = ""
        Me.UC_siteCheck1.Size = New System.Drawing.Size(273, 89)
        Me.UC_siteCheck1.TabIndex = 52
        '
        'btNameToMC
        '
        Me.btNameToMC.Location = New System.Drawing.Point(159, 274)
        Me.btNameToMC.Name = "btNameToMC"
        Me.btNameToMC.Size = New System.Drawing.Size(143, 23)
        Me.btNameToMC.TabIndex = 49
        Me.btNameToMC.Text = "Название в Мой Склад"
        Me.btNameToMC.UseVisualStyleBackColor = True
        '
        'btAddWeightToMC
        '
        Me.btAddWeightToMC.Location = New System.Drawing.Point(319, 274)
        Me.btAddWeightToMC.Name = "btAddWeightToMC"
        Me.btAddWeightToMC.Size = New System.Drawing.Size(134, 23)
        Me.btAddWeightToMC.TabIndex = 48
        Me.btAddWeightToMC.Text = "Вес в Мой Склад"
        Me.btAddWeightToMC.UseVisualStyleBackColor = True
        '
        'UserControlMC1
        '
        Me.UserControlMC1.Location = New System.Drawing.Point(3, 3)
        Me.UserControlMC1.Margin = New System.Windows.Forms.Padding(4)
        Me.UserControlMC1.Name = "UserControlMC1"
        Me.UserControlMC1.SampleName = ""
        Me.UserControlMC1.SampleNumber = Nothing
        Me.UserControlMC1.SampleWeight = New Decimal(New Integer() {0, 0, 0, 0})
        Me.UserControlMC1.Size = New System.Drawing.Size(450, 260)
        Me.UserControlMC1.TabIndex = 0
        '
        'tpRFID
        '
        Me.tpRFID.Controls.Add(Me.UC_rfid1)
        Me.tpRFID.Location = New System.Drawing.Point(4, 22)
        Me.tpRFID.Name = "tpRFID"
        Me.tpRFID.Size = New System.Drawing.Size(550, 496)
        Me.tpRFID.TabIndex = 6
        Me.tpRFID.Text = "RFID"
        Me.tpRFID.UseVisualStyleBackColor = True
        '
        'UC_rfid1
        '
        Me.UC_rfid1.Location = New System.Drawing.Point(14, 10)
        Me.UC_rfid1.Margin = New System.Windows.Forms.Padding(4)
        Me.UC_rfid1.Name = "UC_rfid1"
        Me.UC_rfid1.SampleNumber = ""
        Me.UC_rfid1.Size = New System.Drawing.Size(273, 304)
        Me.UC_rfid1.TabIndex = 0
        '
        'tpTrilboneInfo
        '
        Me.tpTrilboneInfo.Controls.Add(Me.Uc_trilbone_history1)
        Me.tpTrilboneInfo.Location = New System.Drawing.Point(4, 22)
        Me.tpTrilboneInfo.Name = "tpTrilboneInfo"
        Me.tpTrilboneInfo.Padding = New System.Windows.Forms.Padding(3)
        Me.tpTrilboneInfo.Size = New System.Drawing.Size(550, 496)
        Me.tpTrilboneInfo.TabIndex = 5
        Me.tpTrilboneInfo.Text = "Info"
        Me.tpTrilboneInfo.UseVisualStyleBackColor = True
        '
        'Uc_trilbone_history1
        '
        Me.Uc_trilbone_history1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Uc_trilbone_history1.Location = New System.Drawing.Point(3, 3)
        Me.Uc_trilbone_history1.Margin = New System.Windows.Forms.Padding(4)
        Me.Uc_trilbone_history1.Name = "Uc_trilbone_history1"
        Me.Uc_trilbone_history1.Size = New System.Drawing.Size(544, 490)
        Me.Uc_trilbone_history1.TabIndex = 0
        '
        'tpPakage
        '
        Me.tpPakage.Controls.Add(Me.lbPackageType)
        Me.tpPakage.Controls.Add(Me.CheckBox2)
        Me.tpPakage.Controls.Add(Me.CheckBox1)
        Me.tpPakage.Controls.Add(Me.GroupBox5)
        Me.tpPakage.Controls.Add(Me.tbVolumeOffset)
        Me.tpPakage.Controls.Add(Me.Label9)
        Me.tpPakage.Controls.Add(Me.tbBoxes)
        Me.tpPakage.Controls.Add(Me.tbVolumeWeight)
        Me.tpPakage.Controls.Add(Me.tbVolume)
        Me.tpPakage.Controls.Add(Me.tbFullSize)
        Me.tpPakage.Controls.Add(Me.Button3)
        Me.tpPakage.Controls.Add(Me.Label10)
        Me.tpPakage.Controls.Add(Me.ListView1)
        Me.tpPakage.Controls.Add(Me.Label8)
        Me.tpPakage.Controls.Add(Me.Label7)
        Me.tpPakage.Controls.Add(Me.Label5)
        Me.tpPakage.Location = New System.Drawing.Point(4, 22)
        Me.tpPakage.Name = "tpPakage"
        Me.tpPakage.Padding = New System.Windows.Forms.Padding(3)
        Me.tpPakage.Size = New System.Drawing.Size(550, 496)
        Me.tpPakage.TabIndex = 2
        Me.tpPakage.Text = "Упаковка"
        Me.tpPakage.UseVisualStyleBackColor = True
        '
        'lbPackageType
        '
        Me.lbPackageType.AutoSize = True
        Me.lbPackageType.Location = New System.Drawing.Point(33, 162)
        Me.lbPackageType.Name = "lbPackageType"
        Me.lbPackageType.Size = New System.Drawing.Size(50, 13)
        Me.lbPackageType.TabIndex = 30
        Me.lbPackageType.Text = "Package"
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Location = New System.Drawing.Point(36, 467)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(79, 17)
        Me.CheckBox2.TabIndex = 29
        Me.CheckBox2.Text = "розничная"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(36, 441)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(89, 17)
        Me.CheckBox1.TabIndex = 28
        Me.CheckBox1.Text = "техническая"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.RadioButton5)
        Me.GroupBox5.Controls.Add(Me.RadioButton4)
        Me.GroupBox5.Controls.Add(Me.RadioButton3)
        Me.GroupBox5.Controls.Add(Me.RadioButton2)
        Me.GroupBox5.Controls.Add(Me.RadioButton1)
        Me.GroupBox5.Location = New System.Drawing.Point(184, 411)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(359, 79)
        Me.GroupBox5.TabIndex = 27
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "статус"
        '
        'RadioButton5
        '
        Me.RadioButton5.AutoSize = True
        Me.RadioButton5.Location = New System.Drawing.Point(186, 51)
        Me.RadioButton5.Name = "RadioButton5"
        Me.RadioButton5.Size = New System.Drawing.Size(111, 17)
        Me.RadioButton5.TabIndex = 4
        Me.RadioButton5.TabStop = True
        Me.RadioButton5.Text = "упакован в розн."
        Me.RadioButton5.UseVisualStyleBackColor = True
        '
        'RadioButton4
        '
        Me.RadioButton4.AutoSize = True
        Me.RadioButton4.Location = New System.Drawing.Point(65, 51)
        Me.RadioButton4.Name = "RadioButton4"
        Me.RadioButton4.Size = New System.Drawing.Size(103, 17)
        Me.RadioButton4.TabIndex = 3
        Me.RadioButton4.Text = "упакован в тех."
        Me.RadioButton4.UseVisualStyleBackColor = True
        '
        'RadioButton3
        '
        Me.RadioButton3.AutoSize = True
        Me.RadioButton3.Location = New System.Drawing.Point(244, 20)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(105, 17)
        Me.RadioButton3.TabIndex = 2
        Me.RadioButton3.Text = "упак. на складе"
        Me.RadioButton3.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(127, 20)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(102, 17)
        Me.RadioButton2.TabIndex = 1
        Me.RadioButton2.Text = "упак. заказана"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Location = New System.Drawing.Point(16, 20)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(93, 17)
        Me.RadioButton1.TabIndex = 0
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "без упаковки"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'tbVolumeOffset
        '
        Me.tbVolumeOffset.Location = New System.Drawing.Point(205, 54)
        Me.tbVolumeOffset.Name = "tbVolumeOffset"
        Me.tbVolumeOffset.Size = New System.Drawing.Size(34, 20)
        Me.tbVolumeOffset.TabIndex = 26
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(19, 57)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(179, 13)
        Me.Label9.TabIndex = 25
        Me.Label9.Text = "запас для рассчета упаковки, мм"
        '
        'tbBoxes
        '
        Me.tbBoxes.Controls.Add(Me.TabPage2)
        Me.tbBoxes.Location = New System.Drawing.Point(245, 8)
        Me.tbBoxes.Name = "tbBoxes"
        Me.tbBoxes.SelectedIndex = 0
        Me.tbBoxes.Size = New System.Drawing.Size(298, 206)
        Me.tbBoxes.TabIndex = 24
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.tb_weightBox)
        Me.TabPage2.Controls.Add(Me.Label22)
        Me.TabPage2.Controls.Add(Me.tbReikaB)
        Me.TabPage2.Controls.Add(Me.Label21)
        Me.TabPage2.Controls.Add(Me.tbReikaA)
        Me.TabPage2.Controls.Add(Me.Label20)
        Me.TabPage2.Controls.Add(Me.tbReika_leight)
        Me.TabPage2.Controls.Add(Me.Label19)
        Me.TabPage2.Controls.Add(Me.tbFanera_percent)
        Me.TabPage2.Controls.Add(Me.Label18)
        Me.TabPage2.Controls.Add(Me.Label17)
        Me.TabPage2.Controls.Add(Me.tb_Fanera_qty)
        Me.TabPage2.Controls.Add(Me.Label16)
        Me.TabPage2.Controls.Add(Me.Label11)
        Me.TabPage2.Controls.Add(Me.tbCover)
        Me.TabPage2.Controls.Add(Me.Label12)
        Me.TabPage2.Controls.Add(Me.Label13)
        Me.TabPage2.Controls.Add(Me.tbSideB)
        Me.TabPage2.Controls.Add(Me.Label14)
        Me.TabPage2.Controls.Add(Me.Label15)
        Me.TabPage2.Controls.Add(Me.tbSideA)
        Me.TabPage2.Controls.Add(Me.tbReikaThin)
        Me.TabPage2.Controls.Add(Me.tbFaneraThin)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(290, 180)
        Me.TabPage2.TabIndex = 0
        Me.TabPage2.Text = "Коробка типа флавио"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'tb_weightBox
        '
        Me.tb_weightBox.Location = New System.Drawing.Point(194, 153)
        Me.tb_weightBox.Name = "tb_weightBox"
        Me.tb_weightBox.Size = New System.Drawing.Size(67, 20)
        Me.tb_weightBox.TabIndex = 36
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(208, 137)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(42, 13)
        Me.Label22.TabIndex = 35
        Me.Label22.Text = "вес, кг"
        '
        'tbReikaB
        '
        Me.tbReikaB.Location = New System.Drawing.Point(87, 157)
        Me.tbReikaB.Name = "tbReikaB"
        Me.tbReikaB.Size = New System.Drawing.Size(43, 20)
        Me.tbReikaB.TabIndex = 34
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(5, 160)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(63, 13)
        Me.Label21.TabIndex = 33
        Me.Label21.Text = "Рейка B (4)"
        '
        'tbReikaA
        '
        Me.tbReikaA.Location = New System.Drawing.Point(87, 133)
        Me.tbReikaA.Name = "tbReikaA"
        Me.tbReikaA.Size = New System.Drawing.Size(43, 20)
        Me.tbReikaA.TabIndex = 32
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(5, 136)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(63, 13)
        Me.Label20.TabIndex = 31
        Me.Label20.Text = "Рейка A (4)"
        '
        'tbReika_leight
        '
        Me.tbReika_leight.Location = New System.Drawing.Point(194, 111)
        Me.tbReika_leight.Name = "tbReika_leight"
        Me.tbReika_leight.Size = New System.Drawing.Size(62, 20)
        Me.tbReika_leight.TabIndex = 30
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(185, 92)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(84, 13)
        Me.Label19.TabIndex = 29
        Me.Label19.Text = "длина рейки, м"
        '
        'tbFanera_percent
        '
        Me.tbFanera_percent.Location = New System.Drawing.Point(198, 65)
        Me.tbFanera_percent.Name = "tbFanera_percent"
        Me.tbFanera_percent.Size = New System.Drawing.Size(48, 20)
        Me.tbFanera_percent.TabIndex = 28
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(170, 48)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(114, 13)
        Me.Label18.TabIndex = 27
        Me.Label18.Text = "процент от стд листа"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(252, 25)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(21, 13)
        Me.Label17.TabIndex = 26
        Me.Label17.Text = "м2"
        '
        'tb_Fanera_qty
        '
        Me.tb_Fanera_qty.Location = New System.Drawing.Point(197, 22)
        Me.tb_Fanera_qty.Name = "tb_Fanera_qty"
        Me.tb_Fanera_qty.Size = New System.Drawing.Size(49, 20)
        Me.tb_Fanera_qty.TabIndex = 25
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(170, 6)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(95, 13)
        Me.Label16.TabIndex = 24
        Me.Label16.Text = "площадь фанеры"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(5, 64)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(81, 13)
        Me.Label11.TabIndex = 11
        Me.Label11.Text = "Боковина A (2)"
        '
        'tbCover
        '
        Me.tbCover.Location = New System.Drawing.Point(87, 107)
        Me.tbCover.Name = "tbCover"
        Me.tbCover.Size = New System.Drawing.Size(56, 20)
        Me.tbCover.TabIndex = 22
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(5, 87)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(81, 13)
        Me.Label12.TabIndex = 12
        Me.Label12.Text = "Боковина B (2)"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(5, 110)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(73, 13)
        Me.Label13.TabIndex = 13
        Me.Label13.Text = "Крышка C (2)"
        '
        'tbSideB
        '
        Me.tbSideB.Location = New System.Drawing.Point(87, 84)
        Me.tbSideB.Name = "tbSideB"
        Me.tbSideB.Size = New System.Drawing.Size(56, 20)
        Me.tbSideB.TabIndex = 20
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(20, 13)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(59, 13)
        Me.Label14.TabIndex = 14
        Me.Label14.Text = "рейка, мм"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(12, 38)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(67, 13)
        Me.Label15.TabIndex = 15
        Me.Label15.Text = "фанера, мм"
        '
        'tbSideA
        '
        Me.tbSideA.Location = New System.Drawing.Point(87, 61)
        Me.tbSideA.Name = "tbSideA"
        Me.tbSideA.Size = New System.Drawing.Size(56, 20)
        Me.tbSideA.TabIndex = 18
        '
        'tbReikaThin
        '
        Me.tbReikaThin.Location = New System.Drawing.Point(83, 10)
        Me.tbReikaThin.Name = "tbReikaThin"
        Me.tbReikaThin.Size = New System.Drawing.Size(34, 20)
        Me.tbReikaThin.TabIndex = 16
        '
        'tbFaneraThin
        '
        Me.tbFaneraThin.Location = New System.Drawing.Point(83, 36)
        Me.tbFaneraThin.Name = "tbFaneraThin"
        Me.tbFaneraThin.Size = New System.Drawing.Size(34, 20)
        Me.tbFaneraThin.TabIndex = 17
        '
        'tbVolumeWeight
        '
        Me.tbVolumeWeight.Location = New System.Drawing.Point(153, 117)
        Me.tbVolumeWeight.Name = "tbVolumeWeight"
        Me.tbVolumeWeight.Size = New System.Drawing.Size(48, 20)
        Me.tbVolumeWeight.TabIndex = 9
        '
        'tbVolume
        '
        Me.tbVolume.Location = New System.Drawing.Point(109, 91)
        Me.tbVolume.Name = "tbVolume"
        Me.tbVolume.Size = New System.Drawing.Size(53, 20)
        Me.tbVolume.TabIndex = 8
        '
        'tbFullSize
        '
        Me.tbFullSize.Location = New System.Drawing.Point(17, 28)
        Me.tbFullSize.Name = "tbFullSize"
        Me.tbFullSize.Size = New System.Drawing.Size(222, 20)
        Me.tbFullSize.TabIndex = 7
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(33, 408)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(145, 23)
        Me.Button3.TabIndex = 6
        Me.Button3.Text = "заказать/выбрать.."
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(33, 202)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(175, 13)
        Me.Label10.TabIndex = 5
        Me.Label10.Text = "Подходящая упаковка со склада"
        '
        'ListView1
        '
        Me.ListView1.Location = New System.Drawing.Point(33, 220)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(510, 181)
        Me.ListView1.TabIndex = 4
        Me.ListView1.UseCompatibleStateImageBehavior = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(22, 121)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(116, 13)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "обьемный вес, кг/м3"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(22, 94)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(65, 13)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "обьем, дм3"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(14, 11)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(218, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "необходимый внутр. размер коробки, мм"
        '
        'tpOldDescription
        '
        Me.tpOldDescription.Controls.Add(Me.gbDBLabel)
        Me.tpOldDescription.Location = New System.Drawing.Point(4, 22)
        Me.tpOldDescription.Name = "tpOldDescription"
        Me.tpOldDescription.Padding = New System.Windows.Forms.Padding(3)
        Me.tpOldDescription.Size = New System.Drawing.Size(550, 496)
        Me.tpOldDescription.TabIndex = 1
        Me.tpOldDescription.Text = "Подробно узлы"
        Me.tpOldDescription.UseVisualStyleBackColor = True
        '
        'gbDBLabel
        '
        Me.gbDBLabel.Controls.Add(Me.btReadFromDescripElem)
        Me.gbDBLabel.Controls.Add(Me.btRecToDB)
        Me.gbDBLabel.Controls.Add(Me.cbxGetLabelInfoFromDB)
        Me.gbDBLabel.Controls.Add(Me.DataGridView1)
        Me.gbDBLabel.Controls.Add(Me.btSaveLabelToDB)
        Me.gbDBLabel.Controls.Add(Me.rtbLabel)
        Me.gbDBLabel.Controls.Add(Me.btCopyToLabelinfo)
        Me.gbDBLabel.Controls.Add(Me.btCopyToLabel)
        Me.gbDBLabel.Location = New System.Drawing.Point(6, 10)
        Me.gbDBLabel.Name = "gbDBLabel"
        Me.gbDBLabel.Size = New System.Drawing.Size(538, 223)
        Me.gbDBLabel.TabIndex = 85
        Me.gbDBLabel.TabStop = False
        '
        'btReadFromDescripElem
        '
        Me.btReadFromDescripElem.Location = New System.Drawing.Point(456, 12)
        Me.btReadFromDescripElem.Name = "btReadFromDescripElem"
        Me.btReadFromDescripElem.Size = New System.Drawing.Size(75, 23)
        Me.btReadFromDescripElem.TabIndex = 64
        Me.btReadFromDescripElem.Text = "Обновить"
        Me.btReadFromDescripElem.UseVisualStyleBackColor = True
        '
        'btRecToDB
        '
        Me.btRecToDB.Location = New System.Drawing.Point(331, 12)
        Me.btRecToDB.Name = "btRecToDB"
        Me.btRecToDB.Size = New System.Drawing.Size(109, 23)
        Me.btRecToDB.TabIndex = 65
        Me.btRecToDB.Text = "записать в БД"
        Me.btRecToDB.UseVisualStyleBackColor = True
        '
        'cbxGetLabelInfoFromDB
        '
        Me.cbxGetLabelInfoFromDB.AutoSize = True
        Me.cbxGetLabelInfoFromDB.Location = New System.Drawing.Point(187, 16)
        Me.cbxGetLabelInfoFromDB.Name = "cbxGetLabelInfoFromDB"
        Me.cbxGetLabelInfoFromDB.Size = New System.Drawing.Size(107, 17)
        Me.cbxGetLabelInfoFromDB.TabIndex = 69
        Me.cbxGetLabelInfoFromDB.Text = "Получить из БД"
        Me.cbxGetLabelInfoFromDB.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.OrderDataGridViewTextBoxColumn, Me.ValueDataGridViewTextBoxColumn})
        Me.DataGridView1.DataSource = Me.ClsLabelInfoBindingSource
        Me.DataGridView1.Location = New System.Drawing.Point(2, 39)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(534, 99)
        Me.DataGridView1.TabIndex = 63
        '
        'OrderDataGridViewTextBoxColumn
        '
        Me.OrderDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        Me.OrderDataGridViewTextBoxColumn.DataPropertyName = "Order"
        Me.OrderDataGridViewTextBoxColumn.HeaderText = "O"
        Me.OrderDataGridViewTextBoxColumn.Name = "OrderDataGridViewTextBoxColumn"
        Me.OrderDataGridViewTextBoxColumn.Width = 5
        '
        'ValueDataGridViewTextBoxColumn
        '
        Me.ValueDataGridViewTextBoxColumn.DataPropertyName = "Value"
        Me.ValueDataGridViewTextBoxColumn.HeaderText = "Value"
        Me.ValueDataGridViewTextBoxColumn.Name = "ValueDataGridViewTextBoxColumn"
        Me.ValueDataGridViewTextBoxColumn.Width = 480
        '
        'ClsLabelInfoBindingSource
        '
        Me.ClsLabelInfoBindingSource.DataSource = GetType(Service.clsLabelInfo)
        '
        'btSaveLabelToDB
        '
        Me.btSaveLabelToDB.Location = New System.Drawing.Point(448, 182)
        Me.btSaveLabelToDB.Name = "btSaveLabelToDB"
        Me.btSaveLabelToDB.Size = New System.Drawing.Size(88, 40)
        Me.btSaveLabelToDB.TabIndex = 78
        Me.btSaveLabelToDB.Text = "запомнить этикетку"
        Me.btSaveLabelToDB.UseVisualStyleBackColor = True
        '
        'rtbLabel
        '
        Me.rtbLabel.AutoWordSelection = True
        Me.rtbLabel.DetectUrls = False
        Me.rtbLabel.EnableAutoDragDrop = True
        Me.rtbLabel.Font = New System.Drawing.Font("Calibri", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.rtbLabel.Location = New System.Drawing.Point(7, 144)
        Me.rtbLabel.Name = "rtbLabel"
        Me.rtbLabel.Size = New System.Drawing.Size(384, 73)
        Me.rtbLabel.TabIndex = 54
        Me.rtbLabel.Text = ""
        Me.rtbLabel.WordWrap = False
        '
        'btCopyToLabelinfo
        '
        Me.btCopyToLabelinfo.Location = New System.Drawing.Point(395, 197)
        Me.btCopyToLabelinfo.Name = "btCopyToLabelinfo"
        Me.btCopyToLabelinfo.Size = New System.Drawing.Size(40, 25)
        Me.btCopyToLabelinfo.TabIndex = 67
        Me.btCopyToLabelinfo.Text = ">>"
        Me.btCopyToLabelinfo.UseVisualStyleBackColor = True
        '
        'btCopyToLabel
        '
        Me.btCopyToLabel.Location = New System.Drawing.Point(395, 164)
        Me.btCopyToLabel.Name = "btCopyToLabel"
        Me.btCopyToLabel.Size = New System.Drawing.Size(40, 27)
        Me.btCopyToLabel.TabIndex = 68
        Me.btCopyToLabel.Text = "<<"
        Me.btCopyToLabel.UseVisualStyleBackColor = True
        '
        'BindingSource_BOXES
        '
        Me.BindingSource_BOXES.DataSource = GetType(Service.clsBoxes.FlavioBox)
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'ilNodePhoto
        '
        Me.ilNodePhoto.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.ilNodePhoto.ImageSize = New System.Drawing.Size(228, 171)
        Me.ilNodePhoto.TransparentColor = System.Drawing.Color.Transparent
        '
        'btSearchLabels
        '
        Me.btSearchLabels.Location = New System.Drawing.Point(237, 351)
        Me.btSearchLabels.Name = "btSearchLabels"
        Me.btSearchLabels.Size = New System.Drawing.Size(134, 23)
        Me.btSearchLabels.TabIndex = 47
        Me.btSearchLabels.Text = "Искать этикетку в БД"
        Me.btSearchLabels.UseVisualStyleBackColor = True
        '
        'cbSearchLabelsResult
        '
        Me.cbSearchLabelsResult.FormattingEnabled = True
        Me.cbSearchLabelsResult.Location = New System.Drawing.Point(203, 326)
        Me.cbSearchLabelsResult.Name = "cbSearchLabelsResult"
        Me.cbSearchLabelsResult.Size = New System.Drawing.Size(316, 21)
        Me.cbSearchLabelsResult.TabIndex = 48
        '
        'btCreateDescription
        '
        Me.btCreateDescription.Location = New System.Drawing.Point(386, 351)
        Me.btCreateDescription.Name = "btCreateDescription"
        Me.btCreateDescription.Size = New System.Drawing.Size(133, 23)
        Me.btCreateDescription.TabIndex = 49
        Me.btCreateDescription.Text = "создать описание >>"
        Me.btCreateDescription.UseVisualStyleBackColor = True
        '
        'cmsLabelInfo
        '
        Me.cmsLabelInfo.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.cmsLabelInfo.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiDown, Me.tsmiUp})
        Me.cmsLabelInfo.Name = "cmsLabelInfo"
        Me.cmsLabelInfo.Size = New System.Drawing.Size(105, 48)
        '
        'tsmiDown
        '
        Me.tsmiDown.Name = "tsmiDown"
        Me.tsmiDown.Size = New System.Drawing.Size(104, 22)
        Me.tsmiDown.Text = "вверх"
        '
        'tsmiUp
        '
        Me.tsmiUp.Name = "tsmiUp"
        Me.tsmiUp.Size = New System.Drawing.Size(104, 22)
        Me.tsmiUp.Text = "вниз"
        '
        'btDrawLabel
        '
        Me.btDrawLabel.Location = New System.Drawing.Point(135, 144)
        Me.btDrawLabel.Name = "btDrawLabel"
        Me.btDrawLabel.Size = New System.Drawing.Size(48, 23)
        Me.btDrawLabel.TabIndex = 51
        Me.btDrawLabel.Text = "+EAN"
        Me.btDrawLabel.UseVisualStyleBackColor = True
        '
        'btGetNumber
        '
        Me.btGetNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btGetNumber.Location = New System.Drawing.Point(8, 71)
        Me.btGetNumber.Name = "btGetNumber"
        Me.btGetNumber.Size = New System.Drawing.Size(98, 40)
        Me.btGetNumber.TabIndex = 52
        Me.btGetNumber.Text = "получить номер"
        Me.btGetNumber.UseVisualStyleBackColor = True
        '
        'btQuickPrint
        '
        Me.btQuickPrint.Enabled = False
        Me.btQuickPrint.Location = New System.Drawing.Point(135, 173)
        Me.btQuickPrint.Name = "btQuickPrint"
        Me.btQuickPrint.Size = New System.Drawing.Size(105, 23)
        Me.btQuickPrint.TabIndex = 53
        Me.btQuickPrint.Text = "Печать EAN"
        Me.btQuickPrint.UseVisualStyleBackColor = True
        '
        'cbxGetXMLFromDB
        '
        Me.cbxGetXMLFromDB.AutoSize = True
        Me.cbxGetXMLFromDB.Location = New System.Drawing.Point(386, 524)
        Me.cbxGetXMLFromDB.Name = "cbxGetXMLFromDB"
        Me.cbxGetXMLFromDB.Size = New System.Drawing.Size(89, 17)
        Me.cbxGetXMLFromDB.TabIndex = 54
        Me.cbxGetXMLFromDB.Text = "взять из БД"
        Me.cbxGetXMLFromDB.UseVisualStyleBackColor = True
        '
        'iSampleImageList
        '
        Me.iSampleImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.iSampleImageList.ImageSize = New System.Drawing.Size(228, 171)
        Me.iSampleImageList.TransparentColor = System.Drawing.Color.Transparent
        '
        'btReadRFID
        '
        Me.btReadRFID.Location = New System.Drawing.Point(9, 6)
        Me.btReadRFID.Name = "btReadRFID"
        Me.btReadRFID.Size = New System.Drawing.Size(107, 27)
        Me.btReadRFID.TabIndex = 55
        Me.btReadRFID.Text = "Читать RF"
        Me.btReadRFID.UseVisualStyleBackColor = True
        '
        'cbReadyForSale
        '
        Me.cbReadyForSale.AutoSize = True
        Me.cbReadyForSale.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.cbReadyForSale.Location = New System.Drawing.Point(274, 524)
        Me.cbReadyForSale.Name = "cbReadyForSale"
        Me.cbReadyForSale.Size = New System.Drawing.Size(97, 20)
        Me.cbReadyForSale.TabIndex = 57
        Me.cbReadyForSale.Text = "Оформлен"
        Me.cbReadyForSale.UseVisualStyleBackColor = True
        '
        'lblOnSaleCreator
        '
        Me.lblOnSaleCreator.Location = New System.Drawing.Point(274, 551)
        Me.lblOnSaleCreator.Name = "lblOnSaleCreator"
        Me.lblOnSaleCreator.Size = New System.Drawing.Size(90, 13)
        Me.lblOnSaleCreator.TabIndex = 58
        Me.lblOnSaleCreator.Text = "подтвердил"
        '
        'btShowMap
        '
        Me.btShowMap.Location = New System.Drawing.Point(534, 544)
        Me.btShowMap.Name = "btShowMap"
        Me.btShowMap.Size = New System.Drawing.Size(165, 25)
        Me.btShowMap.TabIndex = 59
        Me.btShowMap.Text = "Посмотреть карту из БД"
        Me.btShowMap.UseVisualStyleBackColor = True
        '
        'cbPrintPrice
        '
        Me.cbPrintPrice.AutoSize = True
        Me.cbPrintPrice.Location = New System.Drawing.Point(189, 147)
        Me.cbPrintPrice.Name = "cbPrintPrice"
        Me.cbPrintPrice.Size = New System.Drawing.Size(50, 17)
        Me.cbPrintPrice.TabIndex = 60
        Me.cbPrintPrice.Text = "цена"
        Me.cbPrintPrice.UseVisualStyleBackColor = True
        '
        'btSizeString
        '
        Me.btSizeString.Location = New System.Drawing.Point(194, 220)
        Me.btSizeString.Name = "btSizeString"
        Me.btSizeString.Size = New System.Drawing.Size(55, 36)
        Me.btSizeString.TabIndex = 61
        Me.btSizeString.Text = "размер в буфер"
        Me.btSizeString.UseVisualStyleBackColor = True
        '
        'Select_tb_Samples_photo_dataTableAdapter
        '
        Me.Select_tb_Samples_photo_dataTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.Select_tb_Samples_FossilsTableAdapter = Me.Select_tb_Samples_FossilsTableAdapter
        Me.TableAdapterManager.Select_tb_Samples_photo_dataTableAdapter = Me.Select_tb_Samples_photo_dataTableAdapter
        Me.TableAdapterManager.tb_Samples_photo_dataTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = Photo_reader.dsPhotoDataTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'Select_tb_Samples_FossilsTableAdapter
        '
        Me.Select_tb_Samples_FossilsTableAdapter.ClearBeforeFill = True
        '
        'Select_tb_Samples_FossilsBindingSource
        '
        Me.Select_tb_Samples_FossilsBindingSource.DataMember = "Select_tb_Samples_Fossils"
        Me.Select_tb_Samples_FossilsBindingSource.DataSource = Me.DsPhotoData
        '
        'GetFossilsCountInSampleTableAdapter
        '
        Me.GetFossilsCountInSampleTableAdapter.ClearBeforeFill = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(61, 4)
        '
        'btCopyEAN
        '
        Me.btCopyEAN.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btCopyEAN.Location = New System.Drawing.Point(182, 106)
        Me.btCopyEAN.Name = "btCopyEAN"
        Me.btCopyEAN.Size = New System.Drawing.Size(59, 23)
        Me.btCopyEAN.TabIndex = 62
        Me.btCopyEAN.Text = "EAN 13"
        Me.btCopyEAN.UseVisualStyleBackColor = True
        '
        'btImportData
        '
        Me.btImportData.Location = New System.Drawing.Point(194, 267)
        Me.btImportData.Name = "btImportData"
        Me.btImportData.Size = New System.Drawing.Size(55, 23)
        Me.btImportData.TabIndex = 63
        Me.btImportData.Text = "Импорт"
        Me.btImportData.UseVisualStyleBackColor = True
        '
        'fmSampleData
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1084, 573)
        Me.Controls.Add(Me.btImportData)
        Me.Controls.Add(Me.btCopyEAN)
        Me.Controls.Add(Me.btSizeString)
        Me.Controls.Add(Me.cbPrintPrice)
        Me.Controls.Add(Me.btShowMap)
        Me.Controls.Add(Me.lblOnSaleCreator)
        Me.Controls.Add(Me.cbReadyForSale)
        Me.Controls.Add(Me.btReadRFID)
        Me.Controls.Add(Me.cbxGetXMLFromDB)
        Me.Controls.Add(Me.btQuickPrint)
        Me.Controls.Add(Me.btGetNumber)
        Me.Controls.Add(Me.btDrawLabel)
        Me.Controls.Add(Me.btCreateDescription)
        Me.Controls.Add(Me.cbSearchLabelsResult)
        Me.Controls.Add(Me.btSearchLabels)
        Me.Controls.Add(Me.btClearAll)
        Me.Controls.Add(Me.tpctlMain)
        Me.Controls.Add(Me.btGetDescriptionBuilder)
        Me.Controls.Add(Me.btToMoySklad)
        Me.Controls.Add(Me.btCopyArticul)
        Me.Controls.Add(Me.btCopyNumber)
        Me.Controls.Add(Me.lbSampleStatus)
        Me.Controls.Add(Me.btSearchInfo)
        Me.Controls.Add(Me.rbEnglish)
        Me.Controls.Add(Me.rbRussian)
        Me.Controls.Add(Me.pbMainImage)
        Me.Controls.Add(Me.btToSite)
        Me.Controls.Add(Me.btSaveAll)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.SampleNumberLabel)
        Me.Controls.Add(Me.SampleNumberTextBox)
        Me.Name = "fmSampleData"
        Me.Text = "Оформление образца"
        CType(Me.Select_tb_Samples_photo_dataBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsPhotoData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.GetFossilsCountInSampleBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbMainImage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpctlMain.ResumeLayout(False)
        Me.tpndescription.ResumeLayout(False)
        Me.tpndescription.PerformLayout()
        Me.tpPhoto.ResumeLayout(False)
        Me.tpMoySklad.ResumeLayout(False)
        Me.tpRFID.ResumeLayout(False)
        Me.tpTrilboneInfo.ResumeLayout(False)
        Me.tpPakage.ResumeLayout(False)
        Me.tpPakage.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.tbBoxes.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.tpOldDescription.ResumeLayout(False)
        Me.gbDBLabel.ResumeLayout(False)
        Me.gbDBLabel.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ClsLabelInfoBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingSource_BOXES, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsLabelInfo.ResumeLayout(False)
        CType(Me.Select_tb_Samples_FossilsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents SampleNumberTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Sample_net_weightTextBox As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Sample_heightTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Sample_lengthTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Sample_widthTextBox As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Sample_main_speciesComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents Date_PhotoDateTimePicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents Woker_full_nameComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents Sample_nicknameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btAddFossil As System.Windows.Forms.Button
    Friend WithEvents Fossil_countTextBox As System.Windows.Forms.TextBox
    'Friend WithEvents UcFossilTabPage1 As Photo_reader.ucFossilTabPage
    Friend WithEvents btSaveAll As System.Windows.Forms.Button
    Friend WithEvents DsPhotoData As Photo_reader.dsPhotoData
    Friend WithEvents Select_tb_Samples_photo_dataBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Select_tb_Samples_photo_dataTableAdapter As Photo_reader.dsPhotoDataTableAdapters.Select_tb_Samples_photo_dataTableAdapter
    Friend WithEvents TableAdapterManager As Photo_reader.dsPhotoDataTableAdapters.TableAdapterManager
    Friend WithEvents Select_tb_Samples_FossilsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Select_tb_Samples_FossilsTableAdapter As Photo_reader.dsPhotoDataTableAdapters.Select_tb_Samples_FossilsTableAdapter
    Friend WithEvents GetFossilsCountInSampleBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents GetFossilsCountInSampleTableAdapter As Photo_reader.dsPhotoDataTableAdapters.GetFossilsCountInSampleTableAdapter
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents cbMaterial As System.Windows.Forms.ComboBox
    Friend WithEvents btLoadTree As System.Windows.Forms.Button
    Friend WithEvents cbListOfTree As System.Windows.Forms.ComboBox
    Friend WithEvents lbTreeName As System.Windows.Forms.Label
    Friend WithEvents pbMainImage As System.Windows.Forms.PictureBox
    Friend WithEvents btToSite As System.Windows.Forms.Button
    Friend WithEvents UcFossilTabPage1 As Photo_reader.ucFossilTabPage
    Friend WithEvents btSearchInfo As System.Windows.Forms.Button
    Friend WithEvents lbSampleStatus As System.Windows.Forms.Label
    Friend WithEvents btClearAll As System.Windows.Forms.Button
    Friend WithEvents rbEnglish As System.Windows.Forms.RadioButton
    Friend WithEvents rbRussian As System.Windows.Forms.RadioButton
    Friend WithEvents btGetDescriptionBuilder As System.Windows.Forms.Button
    Friend WithEvents btCopyNumber As System.Windows.Forms.Button
    Friend WithEvents btCopyArticul As System.Windows.Forms.Button
    Friend WithEvents btDescriptionForm As System.Windows.Forms.Button
    Friend WithEvents btToMoySklad As System.Windows.Forms.Button
    Friend WithEvents tpctlMain As System.Windows.Forms.TabControl
    Friend WithEvents tpndescription As System.Windows.Forms.TabPage
    Friend WithEvents tpOldDescription As System.Windows.Forms.TabPage
    Friend WithEvents ClsLabelInfoBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents ilNodePhoto As System.Windows.Forms.ImageList
    Friend WithEvents btSearchLabels As System.Windows.Forms.Button
    Friend WithEvents cbSearchLabelsResult As System.Windows.Forms.ComboBox
    Friend WithEvents btCreateDescription As System.Windows.Forms.Button
    Friend WithEvents cmsLabelInfo As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents tsmiUp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiDown As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tpPakage As System.Windows.Forms.TabPage
    Friend WithEvents tbVolumeWeight As System.Windows.Forms.TextBox
    Friend WithEvents tbVolume As System.Windows.Forms.TextBox
    Friend WithEvents tbFullSize As System.Windows.Forms.TextBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButton4 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton3 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents tbVolumeOffset As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents tbBoxes As System.Windows.Forms.TabControl
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents tbReika_leight As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents tbFanera_percent As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents tb_Fanera_qty As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents tbCover As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents tbSideB As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents tbSideA As System.Windows.Forms.TextBox
    Friend WithEvents tbReikaThin As System.Windows.Forms.TextBox
    Friend WithEvents tbFaneraThin As System.Windows.Forms.TextBox
    Friend WithEvents RadioButton5 As System.Windows.Forms.RadioButton
    Friend WithEvents BindingSource_BOXES As System.Windows.Forms.BindingSource
    Friend WithEvents tbReikaB As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents tbReikaA As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents tb_weightBox As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents btDrawLabel As System.Windows.Forms.Button
    Friend WithEvents btGetNumber As System.Windows.Forms.Button
    Friend WithEvents btQuickPrint As System.Windows.Forms.Button
    Friend WithEvents cbxGetXMLFromDB As System.Windows.Forms.CheckBox
    Friend WithEvents SampleNumberLabel As System.Windows.Forms.Label
    Friend WithEvents Sample_net_weightLabel As System.Windows.Forms.Label
    Friend WithEvents Sample_widthLabel As System.Windows.Forms.Label
    Friend WithEvents Sample_lengthLabel As System.Windows.Forms.Label
    Friend WithEvents Sample_heightLabel As System.Windows.Forms.Label
    Friend WithEvents btFromMoySclad As System.Windows.Forms.Button
    Friend WithEvents tpPhoto As System.Windows.Forms.TabPage
    Friend WithEvents iSampleImageList As System.Windows.Forms.ImageList
    Friend WithEvents cbxLoadAllNames As System.Windows.Forms.CheckBox
    Friend WithEvents btMainName As System.Windows.Forms.Button
    Friend WithEvents UcPhotoManager1 As Service.ucPhotoManager
    Friend WithEvents tpMoySklad As System.Windows.Forms.TabPage
    Friend WithEvents UserControlMC1 As Service.UserControlMC
    Friend WithEvents btAddWeightToMC As System.Windows.Forms.Button
    Friend WithEvents btNameToMC As System.Windows.Forms.Button
    Friend WithEvents tpTrilboneInfo As System.Windows.Forms.TabPage
    Friend WithEvents Uc_trilbone_history1 As Service.Uc_trilbone_history
    Friend WithEvents btReadRFID As System.Windows.Forms.Button
    Friend WithEvents tpRFID As System.Windows.Forms.TabPage
    Friend WithEvents UC_rfid1 As Service.UC_rfid
    Friend WithEvents lbPackageType As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbReadyForSale As System.Windows.Forms.CheckBox
    Friend WithEvents lblOnSaleCreator As System.Windows.Forms.Label
    Friend WithEvents btShowMap As System.Windows.Forms.Button
    Friend WithEvents UcGoodLabel1 As Service.ucGoodLabel
    Friend WithEvents cbxLabelXML As System.Windows.Forms.CheckBox
    Friend WithEvents cbxRawXMLView As System.Windows.Forms.CheckBox
    Friend WithEvents DescriptionRichTextBox As System.Windows.Forms.RichTextBox
    Friend WithEvents btRemoveFromList As System.Windows.Forms.Button
    Friend WithEvents cbPrefixElement As System.Windows.Forms.ComboBox
    Friend WithEvents cbTagOfElement As System.Windows.Forms.ComboBox
    Friend WithEvents btAddInListOfFrase As System.Windows.Forms.Button
    Friend WithEvents btDelElement As System.Windows.Forms.Button
    Friend WithEvents btAddInElement As System.Windows.Forms.Button
    Friend WithEvents btAddUserDescr As System.Windows.Forms.Button
    Friend WithEvents btSaveElement As System.Windows.Forms.Button
    Friend WithEvents lbFrase As System.Windows.Forms.ListBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lbElements As System.Windows.Forms.ListBox
    Friend WithEvents UserDescriptionRichTextBox As System.Windows.Forms.RichTextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents gbDBLabel As System.Windows.Forms.GroupBox
    Friend WithEvents btReadFromDescripElem As System.Windows.Forms.Button
    Friend WithEvents btRecToDB As System.Windows.Forms.Button
    Friend WithEvents cbxGetLabelInfoFromDB As System.Windows.Forms.CheckBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents OrderDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ValueDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btSaveLabelToDB As System.Windows.Forms.Button
    Friend WithEvents rtbLabel As System.Windows.Forms.RichTextBox
    Friend WithEvents btCopyToLabelinfo As System.Windows.Forms.Button
    Friend WithEvents btCopyToLabel As System.Windows.Forms.Button
    Friend WithEvents UC_siteCheck1 As Service.UC_siteCheck
    Friend WithEvents cbPrintPrice As System.Windows.Forms.CheckBox
    Friend WithEvents btSizeString As Button
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents btCopyEAN As Button
    Friend WithEvents btImportData As Button
End Class
