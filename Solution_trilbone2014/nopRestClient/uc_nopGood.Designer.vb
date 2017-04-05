<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uc_nopGood
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
        Dim SKULabel As System.Windows.Forms.Label
        Me.tlp_main = New System.Windows.Forms.TableLayoutPanel()
        Me.tbctl_LangPages = New System.Windows.Forms.TabControl()
        Me.tpDescrFirst = New System.Windows.Forms.TabPage()
        Me.Uc_nopDescriptionFirst = New nopRestClient.uc_nopDescription()
        Me.tpDescrSecond = New System.Windows.Forms.TabPage()
        Me.Uc_nopDescriptionSecond = New nopRestClient.uc_nopDescription()
        Me.TabControl2 = New System.Windows.Forms.TabControl()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.FlowLayoutPanel3 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Uc_langObjectCategory = New nopRestClient.uc_langObject()
        Me.Uc_langObjectLocatlity = New nopRestClient.uc_langObject()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.Uc_attributes1 = New nopRestClient.uc_attributes()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.Uc_ACL1 = New nopRestClient.uc_ACL()
        Me.TabPage7 = New System.Windows.Forms.TabPage()
        Me.Uc_tierPrice1 = New nopRestClient.uc_tierPrice()
        Me.TabPage6 = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.rtbAdminComment = New System.Windows.Forms.RichTextBox()
        Me.ClsDocumentSimpleBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.FlowLayoutPanel5 = New System.Windows.Forms.FlowLayoutPanel()
        Me.tbSeName = New System.Windows.Forms.TextBox()
        Me.cbx_showOnHomePage = New System.Windows.Forms.CheckBox()
        Me.SKUTextBox = New System.Windows.Forms.TextBox()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.btSendData = New System.Windows.Forms.Button()
        Me.cbPublic = New System.Windows.Forms.CheckBox()
        Me.btAskStore = New System.Windows.Forms.Button()
        Me.tbWarehouseName = New System.Windows.Forms.TextBox()
        SKULabel = New System.Windows.Forms.Label()
        Me.tlp_main.SuspendLayout()
        Me.tbctl_LangPages.SuspendLayout()
        Me.tpDescrFirst.SuspendLayout()
        Me.tpDescrSecond.SuspendLayout()
        Me.TabControl2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.FlowLayoutPanel3.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.TabPage5.SuspendLayout()
        Me.TabPage7.SuspendLayout()
        Me.TabPage6.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.ClsDocumentSimpleBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlowLayoutPanel5.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'SKULabel
        '
        SKULabel.Anchor = System.Windows.Forms.AnchorStyles.Right
        SKULabel.AutoSize = True
        SKULabel.Location = New System.Drawing.Point(180, 54)
        SKULabel.Name = "SKULabel"
        SKULabel.Size = New System.Drawing.Size(32, 13)
        SKULabel.TabIndex = 3
        SKULabel.Text = "SKU:"
        '
        'tlp_main
        '
        Me.tlp_main.ColumnCount = 1
        Me.tlp_main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlp_main.Controls.Add(Me.tbctl_LangPages, 0, 0)
        Me.tlp_main.Controls.Add(Me.TabControl2, 0, 1)
        Me.tlp_main.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlp_main.Location = New System.Drawing.Point(0, 0)
        Me.tlp_main.Name = "tlp_main"
        Me.tlp_main.RowCount = 2
        Me.tlp_main.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 72.0!))
        Me.tlp_main.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 28.0!))
        Me.tlp_main.Size = New System.Drawing.Size(1092, 710)
        Me.tlp_main.TabIndex = 0
        '
        'tbctl_LangPages
        '
        Me.tbctl_LangPages.Controls.Add(Me.tpDescrFirst)
        Me.tbctl_LangPages.Controls.Add(Me.tpDescrSecond)
        Me.tbctl_LangPages.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbctl_LangPages.Location = New System.Drawing.Point(3, 3)
        Me.tbctl_LangPages.Name = "tbctl_LangPages"
        Me.tbctl_LangPages.SelectedIndex = 0
        Me.tbctl_LangPages.Size = New System.Drawing.Size(1086, 505)
        Me.tbctl_LangPages.TabIndex = 0
        '
        'tpDescrFirst
        '
        Me.tpDescrFirst.Controls.Add(Me.Uc_nopDescriptionFirst)
        Me.tpDescrFirst.Location = New System.Drawing.Point(4, 22)
        Me.tpDescrFirst.Name = "tpDescrFirst"
        Me.tpDescrFirst.Padding = New System.Windows.Forms.Padding(3)
        Me.tpDescrFirst.Size = New System.Drawing.Size(1078, 479)
        Me.tpDescrFirst.TabIndex = 0
        Me.tpDescrFirst.Text = "Английский"
        Me.tpDescrFirst.UseVisualStyleBackColor = True
        '
        'Uc_nopDescriptionFirst
        '
        Me.Uc_nopDescriptionFirst.DataLangCheckedStatus = True
        Me.Uc_nopDescriptionFirst.DataLangString = "EN"
        Me.Uc_nopDescriptionFirst.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Uc_nopDescriptionFirst.Location = New System.Drawing.Point(3, 3)
        Me.Uc_nopDescriptionFirst.Name = "Uc_nopDescriptionFirst"
        Me.Uc_nopDescriptionFirst.Size = New System.Drawing.Size(1072, 473)
        Me.Uc_nopDescriptionFirst.TabIndex = 0
        '
        'tpDescrSecond
        '
        Me.tpDescrSecond.Controls.Add(Me.Uc_nopDescriptionSecond)
        Me.tpDescrSecond.Location = New System.Drawing.Point(4, 22)
        Me.tpDescrSecond.Name = "tpDescrSecond"
        Me.tpDescrSecond.Padding = New System.Windows.Forms.Padding(3)
        Me.tpDescrSecond.Size = New System.Drawing.Size(1078, 479)
        Me.tpDescrSecond.TabIndex = 1
        Me.tpDescrSecond.Text = "Русский"
        Me.tpDescrSecond.UseVisualStyleBackColor = True
        '
        'Uc_nopDescriptionSecond
        '
        Me.Uc_nopDescriptionSecond.DataLangCheckedStatus = False
        Me.Uc_nopDescriptionSecond.DataLangString = "RU"
        Me.Uc_nopDescriptionSecond.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Uc_nopDescriptionSecond.Location = New System.Drawing.Point(3, 3)
        Me.Uc_nopDescriptionSecond.Name = "Uc_nopDescriptionSecond"
        Me.Uc_nopDescriptionSecond.Size = New System.Drawing.Size(1072, 473)
        Me.Uc_nopDescriptionSecond.TabIndex = 0
        '
        'TabControl2
        '
        Me.TabControl2.Controls.Add(Me.TabPage3)
        Me.TabControl2.Controls.Add(Me.TabPage4)
        Me.TabControl2.Controls.Add(Me.TabPage5)
        Me.TabControl2.Controls.Add(Me.TabPage7)
        Me.TabControl2.Controls.Add(Me.TabPage6)
        Me.TabControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl2.Location = New System.Drawing.Point(3, 514)
        Me.TabControl2.Name = "TabControl2"
        Me.TabControl2.SelectedIndex = 0
        Me.TabControl2.Size = New System.Drawing.Size(1086, 193)
        Me.TabControl2.TabIndex = 1
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.FlowLayoutPanel3)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(1078, 167)
        Me.TabPage3.TabIndex = 0
        Me.TabPage3.Text = "Категории"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'FlowLayoutPanel3
        '
        Me.FlowLayoutPanel3.Controls.Add(Me.Uc_langObjectCategory)
        Me.FlowLayoutPanel3.Controls.Add(Me.Uc_langObjectLocatlity)
        Me.FlowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel3.Location = New System.Drawing.Point(3, 3)
        Me.FlowLayoutPanel3.Name = "FlowLayoutPanel3"
        Me.FlowLayoutPanel3.Size = New System.Drawing.Size(1072, 161)
        Me.FlowLayoutPanel3.TabIndex = 0
        '
        'Uc_langObjectCategory
        '
        Me.Uc_langObjectCategory.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Uc_langObjectCategory.EnabledNew = False
        Me.Uc_langObjectCategory.Location = New System.Drawing.Point(3, 3)
        Me.Uc_langObjectCategory.Name = "Uc_langObjectCategory"
        Me.Uc_langObjectCategory.SingleSelect = False
        Me.Uc_langObjectCategory.Size = New System.Drawing.Size(430, 163)
        Me.Uc_langObjectCategory.TabIndex = 0
        Me.Uc_langObjectCategory.UcCaption = "Категории"
        '
        'Uc_langObjectLocatlity
        '
        Me.Uc_langObjectLocatlity.EnabledNew = True
        Me.Uc_langObjectLocatlity.Location = New System.Drawing.Point(439, 3)
        Me.Uc_langObjectLocatlity.Name = "Uc_langObjectLocatlity"
        Me.Uc_langObjectLocatlity.SingleSelect = True
        Me.Uc_langObjectLocatlity.Size = New System.Drawing.Size(430, 163)
        Me.Uc_langObjectLocatlity.TabIndex = 1
        Me.Uc_langObjectLocatlity.UcCaption = "Локалити"
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.Uc_attributes1)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(1078, 167)
        Me.TabPage4.TabIndex = 1
        Me.TabPage4.Text = "Характеристики"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'Uc_attributes1
        '
        Me.Uc_attributes1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Uc_attributes1.Location = New System.Drawing.Point(3, 3)
        Me.Uc_attributes1.Name = "Uc_attributes1"
        Me.Uc_attributes1.Size = New System.Drawing.Size(1072, 161)
        Me.Uc_attributes1.TabIndex = 0
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.Uc_ACL1)
        Me.TabPage5.Location = New System.Drawing.Point(4, 22)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage5.Size = New System.Drawing.Size(1078, 167)
        Me.TabPage5.TabIndex = 2
        Me.TabPage5.Text = "Доступ"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'Uc_ACL1
        '
        Me.Uc_ACL1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Uc_ACL1.Location = New System.Drawing.Point(3, 3)
        Me.Uc_ACL1.Name = "Uc_ACL1"
        Me.Uc_ACL1.Size = New System.Drawing.Size(1072, 161)
        Me.Uc_ACL1.TabIndex = 0
        '
        'TabPage7
        '
        Me.TabPage7.Controls.Add(Me.Uc_tierPrice1)
        Me.TabPage7.Location = New System.Drawing.Point(4, 22)
        Me.TabPage7.Name = "TabPage7"
        Me.TabPage7.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage7.Size = New System.Drawing.Size(1078, 167)
        Me.TabPage7.TabIndex = 4
        Me.TabPage7.Text = "Цены по клиентам"
        Me.TabPage7.UseVisualStyleBackColor = True
        '
        'Uc_tierPrice1
        '
        Me.Uc_tierPrice1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Uc_tierPrice1.Location = New System.Drawing.Point(3, 3)
        Me.Uc_tierPrice1.Name = "Uc_tierPrice1"
        Me.Uc_tierPrice1.RateDelagate = Nothing
        Me.Uc_tierPrice1.Size = New System.Drawing.Size(1072, 161)
        Me.Uc_tierPrice1.TabIndex = 0
        '
        'TabPage6
        '
        Me.TabPage6.Controls.Add(Me.TableLayoutPanel1)
        Me.TabPage6.Location = New System.Drawing.Point(4, 22)
        Me.TabPage6.Name = "TabPage6"
        Me.TabPage6.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage6.Size = New System.Drawing.Size(1078, 167)
        Me.TabPage6.TabIndex = 3
        Me.TabPage6.Text = "Разное и подтверждение"
        Me.TabPage6.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.AutoScroll = True
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Label3, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label4, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.rtbAdminComment, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.FlowLayoutPanel5, 1, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1072, 161)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label3.Location = New System.Drawing.Point(3, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(422, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Комментарий Админа"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label4.Location = New System.Drawing.Point(431, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(638, 13)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Прямая ссылка на страницу камня"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'rtbAdminComment
        '
        Me.rtbAdminComment.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ClsDocumentSimpleBindingSource, "AdminComment", True))
        Me.rtbAdminComment.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rtbAdminComment.Location = New System.Drawing.Point(3, 35)
        Me.rtbAdminComment.Name = "rtbAdminComment"
        Me.rtbAdminComment.Size = New System.Drawing.Size(422, 123)
        Me.rtbAdminComment.TabIndex = 2
        Me.rtbAdminComment.Text = ""
        '
        'ClsDocumentSimpleBindingSource
        '
        Me.ClsDocumentSimpleBindingSource.DataSource = GetType(nopRestClient.clsDocumentSimple)
        '
        'FlowLayoutPanel5
        '
        Me.FlowLayoutPanel5.Controls.Add(Me.tbSeName)
        Me.FlowLayoutPanel5.Controls.Add(Me.cbx_showOnHomePage)
        Me.FlowLayoutPanel5.Controls.Add(SKULabel)
        Me.FlowLayoutPanel5.Controls.Add(Me.SKUTextBox)
        Me.FlowLayoutPanel5.Controls.Add(Me.TableLayoutPanel2)
        Me.FlowLayoutPanel5.Controls.Add(Me.btSendData)
        Me.FlowLayoutPanel5.Controls.Add(Me.cbPublic)
        Me.FlowLayoutPanel5.Controls.Add(Me.btAskStore)
        Me.FlowLayoutPanel5.Controls.Add(Me.tbWarehouseName)
        Me.FlowLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel5.Location = New System.Drawing.Point(431, 35)
        Me.FlowLayoutPanel5.Name = "FlowLayoutPanel5"
        Me.FlowLayoutPanel5.Size = New System.Drawing.Size(638, 123)
        Me.FlowLayoutPanel5.TabIndex = 3
        '
        'tbSeName
        '
        Me.tbSeName.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ClsDocumentSimpleBindingSource, "SeName", True))
        Me.tbSeName.Location = New System.Drawing.Point(3, 3)
        Me.tbSeName.Name = "tbSeName"
        Me.tbSeName.Size = New System.Drawing.Size(573, 20)
        Me.tbSeName.TabIndex = 0
        '
        'cbx_showOnHomePage
        '
        Me.cbx_showOnHomePage.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbx_showOnHomePage.AutoSize = True
        Me.cbx_showOnHomePage.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.ClsDocumentSimpleBindingSource, "ShowOnHomePage", True))
        Me.cbx_showOnHomePage.Location = New System.Drawing.Point(3, 52)
        Me.cbx_showOnHomePage.Name = "cbx_showOnHomePage"
        Me.cbx_showOnHomePage.Size = New System.Drawing.Size(171, 17)
        Me.cbx_showOnHomePage.TabIndex = 2
        Me.cbx_showOnHomePage.Text = "Добавить в рекомендуемые"
        Me.cbx_showOnHomePage.UseVisualStyleBackColor = True
        '
        'SKUTextBox
        '
        Me.SKUTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.SKUTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ClsDocumentSimpleBindingSource, "SKU", True))
        Me.SKUTextBox.Location = New System.Drawing.Point(218, 50)
        Me.SKUTextBox.Name = "SKUTextBox"
        Me.SKUTextBox.Size = New System.Drawing.Size(100, 20)
        Me.SKUTextBox.TabIndex = 4
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 4
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 63.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 54.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 67.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label2, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.TextBox1, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label5, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label6, 2, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.TextBox2, 3, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.TextBox3, 3, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.TextBox4, 1, 1)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(324, 29)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(251, 63)
        Me.TableLayoutPanel2.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Вес, кг"
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Длина, м"
        '
        'TextBox1
        '
        Me.TextBox1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ClsDocumentSimpleBindingSource, "Weight", True))
        Me.TextBox1.Location = New System.Drawing.Point(66, 3)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(48, 20)
        Me.TextBox1.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(121, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(60, 13)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Ширина, м"
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(122, 40)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(59, 13)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "Высота, м"
        '
        'TextBox2
        '
        Me.TextBox2.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ClsDocumentSimpleBindingSource, "Width", True))
        Me.TextBox2.Location = New System.Drawing.Point(187, 3)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(61, 20)
        Me.TextBox2.TabIndex = 5
        '
        'TextBox3
        '
        Me.TextBox3.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ClsDocumentSimpleBindingSource, "Height", True))
        Me.TextBox3.Location = New System.Drawing.Point(187, 34)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(61, 20)
        Me.TextBox3.TabIndex = 6
        '
        'TextBox4
        '
        Me.TextBox4.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ClsDocumentSimpleBindingSource, "Length", True))
        Me.TextBox4.Location = New System.Drawing.Point(66, 34)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(48, 20)
        Me.TextBox4.TabIndex = 7
        '
        'btSendData
        '
        Me.btSendData.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btSendData.Location = New System.Drawing.Point(3, 98)
        Me.btSendData.Name = "btSendData"
        Me.btSendData.Size = New System.Drawing.Size(198, 23)
        Me.btSendData.TabIndex = 1
        Me.btSendData.Text = "На Сайт!!"
        Me.btSendData.UseVisualStyleBackColor = True
        '
        'cbPublic
        '
        Me.cbPublic.AutoSize = True
        Me.cbPublic.Checked = True
        Me.cbPublic.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbPublic.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.ClsDocumentSimpleBindingSource, "Published", True))
        Me.cbPublic.Location = New System.Drawing.Point(207, 98)
        Me.cbPublic.Name = "cbPublic"
        Me.cbPublic.Size = New System.Drawing.Size(98, 17)
        Me.cbPublic.TabIndex = 6
        Me.cbPublic.Text = "Опубликовать"
        Me.cbPublic.UseVisualStyleBackColor = True
        '
        'btAskStore
        '
        Me.btAskStore.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btAskStore.Location = New System.Drawing.Point(311, 98)
        Me.btAskStore.Name = "btAskStore"
        Me.btAskStore.Size = New System.Drawing.Size(75, 23)
        Me.btAskStore.TabIndex = 8
        Me.btAskStore.Text = "склад.."
        Me.btAskStore.UseVisualStyleBackColor = True
        '
        'tbWarehouseName
        '
        Me.tbWarehouseName.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ClsDocumentSimpleBindingSource, "WarehouseID", True))
        Me.tbWarehouseName.Location = New System.Drawing.Point(392, 98)
        Me.tbWarehouseName.Name = "tbWarehouseName"
        Me.tbWarehouseName.Size = New System.Drawing.Size(22, 20)
        Me.tbWarehouseName.TabIndex = 7
        '
        'uc_nopGood
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.tlp_main)
        Me.Name = "uc_nopGood"
        Me.Size = New System.Drawing.Size(1092, 710)
        Me.tlp_main.ResumeLayout(False)
        Me.tbctl_LangPages.ResumeLayout(False)
        Me.tpDescrFirst.ResumeLayout(False)
        Me.tpDescrSecond.ResumeLayout(False)
        Me.TabControl2.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.FlowLayoutPanel3.ResumeLayout(False)
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage5.ResumeLayout(False)
        Me.TabPage7.ResumeLayout(False)
        Me.TabPage6.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.ClsDocumentSimpleBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlowLayoutPanel5.ResumeLayout(False)
        Me.FlowLayoutPanel5.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tlp_main As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tbctl_LangPages As System.Windows.Forms.TabControl
    Friend WithEvents tpDescrFirst As System.Windows.Forms.TabPage
    Friend WithEvents tpDescrSecond As System.Windows.Forms.TabPage
    Friend WithEvents Uc_nopDescriptionFirst As nopRestClient.uc_nopDescription
    Friend WithEvents TabControl2 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents FlowLayoutPanel3 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Uc_langObjectCategory As nopRestClient.uc_langObject
    Friend WithEvents Uc_langObjectLocatlity As nopRestClient.uc_langObject
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage6 As System.Windows.Forms.TabPage
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents rtbAdminComment As System.Windows.Forms.RichTextBox
    Friend WithEvents FlowLayoutPanel5 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents tbSeName As System.Windows.Forms.TextBox
    Friend WithEvents btSendData As System.Windows.Forms.Button
    Friend WithEvents Uc_nopDescriptionSecond As nopRestClient.uc_nopDescription
    Friend WithEvents TabPage7 As System.Windows.Forms.TabPage
    Friend WithEvents cbx_showOnHomePage As System.Windows.Forms.CheckBox
    Friend WithEvents SKUTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Uc_attributes1 As nopRestClient.uc_attributes
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    Friend WithEvents Uc_ACL1 As nopRestClient.uc_ACL
    Friend WithEvents Uc_tierPrice1 As nopRestClient.uc_tierPrice
    Friend WithEvents ClsDocumentSimpleBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents cbPublic As System.Windows.Forms.CheckBox
    Friend WithEvents tbWarehouseName As System.Windows.Forms.TextBox
    Friend WithEvents btAskStore As System.Windows.Forms.Button

End Class
