<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uc_nopDescription
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
        Me.tlp_main = New System.Windows.Forms.TableLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.wb_FullDescriptionEn = New System.Windows.Forms.WebBrowser()
        Me.tb_NameEng = New System.Windows.Forms.TextBox()
        Me.ContextMenuStripTags = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripTextBoxWord = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItemToTags = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemToWords = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItemCopyWord = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemCopyAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItemInsertWord = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemInsertAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.bs_description = New System.Windows.Forms.BindingSource(Me.components)
        Me.tb_MetaNameEng = New System.Windows.Forms.TextBox()
        Me.rtb_ShotDescrEng = New System.Windows.Forms.RichTextBox()
        Me.rtb_ShotMetaEng = New System.Windows.Forms.RichTextBox()
        Me.cbx_dataLang = New System.Windows.Forms.CheckBox()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lb_Templates = New System.Windows.Forms.ListBox()
        Me.TemplatesListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.bt_acceptTemplate = New System.Windows.Forms.Button()
        Me.bt_showHTML = New System.Windows.Forms.Button()
        Me.Uc_langObjectTag = New nopRestClient.uc_langObject()
        Me.Uc_SimpleObjectWords = New nopRestClient.uc_SimpleObject()
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btCondition = New System.Windows.Forms.Button()
        Me.tlp_main.SuspendLayout()
        Me.ContextMenuStripTags.SuspendLayout()
        CType(Me.bs_description, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlowLayoutPanel1.SuspendLayout()
        CType(Me.TemplatesListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlowLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'tlp_main
        '
        Me.tlp_main.ColumnCount = 4
        Me.tlp_main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.tlp_main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.tlp_main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlp_main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlp_main.Controls.Add(Me.Label1, 1, 0)
        Me.tlp_main.Controls.Add(Me.Label2, 0, 1)
        Me.tlp_main.Controls.Add(Me.Label4, 0, 3)
        Me.tlp_main.Controls.Add(Me.wb_FullDescriptionEn, 2, 4)
        Me.tlp_main.Controls.Add(Me.tb_NameEng, 2, 0)
        Me.tlp_main.Controls.Add(Me.tb_MetaNameEng, 2, 1)
        Me.tlp_main.Controls.Add(Me.rtb_ShotDescrEng, 2, 2)
        Me.tlp_main.Controls.Add(Me.rtb_ShotMetaEng, 2, 3)
        Me.tlp_main.Controls.Add(Me.cbx_dataLang, 0, 0)
        Me.tlp_main.Controls.Add(Me.FlowLayoutPanel1, 0, 4)
        Me.tlp_main.Controls.Add(Me.Uc_langObjectTag, 3, 2)
        Me.tlp_main.Controls.Add(Me.Uc_SimpleObjectWords, 3, 3)
        Me.tlp_main.Controls.Add(Me.FlowLayoutPanel2, 0, 2)
        Me.tlp_main.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlp_main.Location = New System.Drawing.Point(0, 0)
        Me.tlp_main.Name = "tlp_main"
        Me.tlp_main.RowCount = 5
        Me.tlp_main.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.5!))
        Me.tlp_main.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.5!))
        Me.tlp_main.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.5!))
        Me.tlp_main.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.5!))
        Me.tlp_main.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.tlp_main.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlp_main.Size = New System.Drawing.Size(1108, 649)
        Me.tlp_main.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Location = New System.Drawing.Point(53, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(94, 48)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Название(Name)"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.tlp_main.SetColumnSpan(Me.Label2, 2)
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Location = New System.Drawing.Point(3, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(144, 48)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "подпись Meta title"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.tlp_main.SetColumnSpan(Me.Label4, 2)
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label4.Location = New System.Drawing.Point(3, 242)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(144, 146)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Короткое описание Meta <description>"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'wb_FullDescriptionEn
        '
        Me.tlp_main.SetColumnSpan(Me.wb_FullDescriptionEn, 2)
        Me.wb_FullDescriptionEn.Dock = System.Windows.Forms.DockStyle.Fill
        Me.wb_FullDescriptionEn.Location = New System.Drawing.Point(153, 391)
        Me.wb_FullDescriptionEn.MinimumSize = New System.Drawing.Size(20, 20)
        Me.wb_FullDescriptionEn.Name = "wb_FullDescriptionEn"
        Me.wb_FullDescriptionEn.Size = New System.Drawing.Size(952, 255)
        Me.wb_FullDescriptionEn.TabIndex = 5
        '
        'tb_NameEng
        '
        Me.tlp_main.SetColumnSpan(Me.tb_NameEng, 2)
        Me.tb_NameEng.ContextMenuStrip = Me.ContextMenuStripTags
        Me.tb_NameEng.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bs_description, "Names", True))
        Me.tb_NameEng.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tb_NameEng.Location = New System.Drawing.Point(153, 3)
        Me.tb_NameEng.Name = "tb_NameEng"
        Me.tb_NameEng.Size = New System.Drawing.Size(952, 20)
        Me.tb_NameEng.TabIndex = 6
        '
        'ContextMenuStripTags
        '
        Me.ContextMenuStripTags.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripTextBoxWord, Me.ToolStripSeparator1, Me.ToolStripMenuItemToTags, Me.ToolStripMenuItemToWords, Me.ToolStripSeparator2, Me.ToolStripMenuItemCopyWord, Me.ToolStripMenuItemCopyAll, Me.ToolStripSeparator3, Me.ToolStripMenuItemInsertWord, Me.ToolStripMenuItemInsertAll})
        Me.ContextMenuStripTags.Name = "ContextMenuStripTags"
        Me.ContextMenuStripTags.Size = New System.Drawing.Size(176, 181)
        '
        'ToolStripTextBoxWord
        '
        Me.ToolStripTextBoxWord.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ToolStripTextBoxWord.ForeColor = System.Drawing.Color.ForestGreen
        Me.ToolStripTextBoxWord.Name = "ToolStripTextBoxWord"
        Me.ToolStripTextBoxWord.Size = New System.Drawing.Size(100, 25)
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(172, 6)
        '
        'ToolStripMenuItemToTags
        '
        Me.ToolStripMenuItemToTags.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ToolStripMenuItemToTags.Name = "ToolStripMenuItemToTags"
        Me.ToolStripMenuItemToTags.Size = New System.Drawing.Size(175, 22)
        Me.ToolStripMenuItemToTags.Text = "В теги"
        '
        'ToolStripMenuItemToWords
        '
        Me.ToolStripMenuItemToWords.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ToolStripMenuItemToWords.Name = "ToolStripMenuItemToWords"
        Me.ToolStripMenuItemToWords.Size = New System.Drawing.Size(175, 22)
        Me.ToolStripMenuItemToWords.Text = "В слова"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(172, 6)
        '
        'ToolStripMenuItemCopyWord
        '
        Me.ToolStripMenuItemCopyWord.Name = "ToolStripMenuItemCopyWord"
        Me.ToolStripMenuItemCopyWord.Size = New System.Drawing.Size(175, 22)
        Me.ToolStripMenuItemCopyWord.Text = "Копировать слово"
        '
        'ToolStripMenuItemCopyAll
        '
        Me.ToolStripMenuItemCopyAll.Name = "ToolStripMenuItemCopyAll"
        Me.ToolStripMenuItemCopyAll.Size = New System.Drawing.Size(175, 22)
        Me.ToolStripMenuItemCopyAll.Text = "Копировать все"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(172, 6)
        '
        'ToolStripMenuItemInsertWord
        '
        Me.ToolStripMenuItemInsertWord.Name = "ToolStripMenuItemInsertWord"
        Me.ToolStripMenuItemInsertWord.Size = New System.Drawing.Size(175, 22)
        Me.ToolStripMenuItemInsertWord.Text = "Вставить слово"
        '
        'ToolStripMenuItemInsertAll
        '
        Me.ToolStripMenuItemInsertAll.Name = "ToolStripMenuItemInsertAll"
        Me.ToolStripMenuItemInsertAll.Size = New System.Drawing.Size(175, 22)
        Me.ToolStripMenuItemInsertAll.Text = "Вставить все"
        '
        'bs_description
        '
        Me.bs_description.DataSource = GetType(nopRestClient.clsDescriptionObject)
        '
        'tb_MetaNameEng
        '
        Me.tlp_main.SetColumnSpan(Me.tb_MetaNameEng, 2)
        Me.tb_MetaNameEng.ContextMenuStrip = Me.ContextMenuStripTags
        Me.tb_MetaNameEng.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bs_description, "MetaTitle", True))
        Me.tb_MetaNameEng.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tb_MetaNameEng.Location = New System.Drawing.Point(153, 51)
        Me.tb_MetaNameEng.Name = "tb_MetaNameEng"
        Me.tb_MetaNameEng.Size = New System.Drawing.Size(952, 20)
        Me.tb_MetaNameEng.TabIndex = 7
        '
        'rtb_ShotDescrEng
        '
        Me.rtb_ShotDescrEng.ContextMenuStrip = Me.ContextMenuStripTags
        Me.rtb_ShotDescrEng.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bs_description, "ShortDescriptions", True))
        Me.rtb_ShotDescrEng.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rtb_ShotDescrEng.Location = New System.Drawing.Point(153, 99)
        Me.rtb_ShotDescrEng.Name = "rtb_ShotDescrEng"
        Me.rtb_ShotDescrEng.Size = New System.Drawing.Size(473, 140)
        Me.rtb_ShotDescrEng.TabIndex = 8
        Me.rtb_ShotDescrEng.Text = ""
        '
        'rtb_ShotMetaEng
        '
        Me.rtb_ShotMetaEng.ContextMenuStrip = Me.ContextMenuStripTags
        Me.rtb_ShotMetaEng.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rtb_ShotMetaEng.Location = New System.Drawing.Point(153, 245)
        Me.rtb_ShotMetaEng.Name = "rtb_ShotMetaEng"
        Me.rtb_ShotMetaEng.Size = New System.Drawing.Size(473, 140)
        Me.rtb_ShotMetaEng.TabIndex = 9
        Me.rtb_ShotMetaEng.Text = ""
        '
        'cbx_dataLang
        '
        Me.cbx_dataLang.AutoSize = True
        Me.cbx_dataLang.Checked = True
        Me.cbx_dataLang.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbx_dataLang.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.bs_description, "SetAsInvariant", True))
        Me.cbx_dataLang.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bs_description, "LangString", True))
        Me.cbx_dataLang.Location = New System.Drawing.Point(3, 3)
        Me.cbx_dataLang.Name = "cbx_dataLang"
        Me.cbx_dataLang.Size = New System.Drawing.Size(41, 17)
        Me.cbx_dataLang.TabIndex = 10
        Me.cbx_dataLang.Text = "EN"
        Me.cbx_dataLang.UseVisualStyleBackColor = True
        '
        'FlowLayoutPanel1
        '
        Me.tlp_main.SetColumnSpan(Me.FlowLayoutPanel1, 2)
        Me.FlowLayoutPanel1.Controls.Add(Me.Label5)
        Me.FlowLayoutPanel1.Controls.Add(Me.lb_Templates)
        Me.FlowLayoutPanel1.Controls.Add(Me.bt_acceptTemplate)
        Me.FlowLayoutPanel1.Controls.Add(Me.bt_showHTML)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(3, 391)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(144, 255)
        Me.FlowLayoutPanel1.TabIndex = 12
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(3, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(141, 27)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Полное описание"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lb_Templates
        '
        Me.lb_Templates.DataSource = Me.TemplatesListBindingSource
        Me.lb_Templates.DisplayMember = "Name"
        Me.lb_Templates.FormattingEnabled = True
        Me.lb_Templates.Location = New System.Drawing.Point(3, 30)
        Me.lb_Templates.Name = "lb_Templates"
        Me.lb_Templates.Size = New System.Drawing.Size(141, 56)
        Me.lb_Templates.TabIndex = 3
        Me.lb_Templates.ValueMember = "Body"
        '
        'TemplatesListBindingSource
        '
        Me.TemplatesListBindingSource.DataMember = "xsltTemplates"
        Me.TemplatesListBindingSource.DataSource = Me.bs_description
        '
        'bt_acceptTemplate
        '
        Me.bt_acceptTemplate.AutoSize = True
        Me.bt_acceptTemplate.Location = New System.Drawing.Point(3, 92)
        Me.bt_acceptTemplate.Name = "bt_acceptTemplate"
        Me.bt_acceptTemplate.Size = New System.Drawing.Size(141, 23)
        Me.bt_acceptTemplate.TabIndex = 2
        Me.bt_acceptTemplate.Text = "Применить шаблон"
        Me.bt_acceptTemplate.UseVisualStyleBackColor = True
        '
        'bt_showHTML
        '
        Me.bt_showHTML.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.bt_showHTML.Location = New System.Drawing.Point(3, 121)
        Me.bt_showHTML.Name = "bt_showHTML"
        Me.bt_showHTML.Size = New System.Drawing.Size(93, 61)
        Me.bt_showHTML.TabIndex = 4
        Me.bt_showHTML.Text = "посмотреть HTML описание"
        Me.bt_showHTML.UseVisualStyleBackColor = True
        '
        'Uc_langObjectTag
        '
        Me.Uc_langObjectTag.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Uc_langObjectTag.EnabledNew = True
        Me.Uc_langObjectTag.Location = New System.Drawing.Point(632, 99)
        Me.Uc_langObjectTag.Name = "Uc_langObjectTag"
        Me.Uc_langObjectTag.SingleSelect = False
        Me.Uc_langObjectTag.Size = New System.Drawing.Size(473, 140)
        Me.Uc_langObjectTag.TabIndex = 14
        Me.Uc_langObjectTag.UcCaption = "Теги"
        '
        'Uc_SimpleObjectWords
        '
        Me.Uc_SimpleObjectWords.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Uc_SimpleObjectWords.Location = New System.Drawing.Point(632, 245)
        Me.Uc_SimpleObjectWords.Name = "Uc_SimpleObjectWords"
        Me.Uc_SimpleObjectWords.Size = New System.Drawing.Size(473, 140)
        Me.Uc_SimpleObjectWords.TabIndex = 15
        Me.Uc_SimpleObjectWords.UcCaption = "Ключевые слова"
        '
        'FlowLayoutPanel2
        '
        Me.tlp_main.SetColumnSpan(Me.FlowLayoutPanel2, 2)
        Me.FlowLayoutPanel2.Controls.Add(Me.Label3)
        Me.FlowLayoutPanel2.Controls.Add(Me.btCondition)
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(3, 99)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(144, 100)
        Me.FlowLayoutPanel2.TabIndex = 16
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.Location = New System.Drawing.Point(3, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(141, 26)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Короткое описание на сайт"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btCondition
        '
        Me.btCondition.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btCondition.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btCondition.Location = New System.Drawing.Point(3, 29)
        Me.btCondition.Name = "btCondition"
        Me.btCondition.Size = New System.Drawing.Size(141, 23)
        Me.btCondition.TabIndex = 1
        Me.btCondition.Text = "Построить.."
        Me.btCondition.UseVisualStyleBackColor = True
        '
        'uc_nopDescription
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.tlp_main)
        Me.Name = "uc_nopDescription"
        Me.Size = New System.Drawing.Size(1108, 649)
        Me.tlp_main.ResumeLayout(False)
        Me.tlp_main.PerformLayout()
        Me.ContextMenuStripTags.ResumeLayout(False)
        Me.ContextMenuStripTags.PerformLayout()
        CType(Me.bs_description, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        CType(Me.TemplatesListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlowLayoutPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tlp_main As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents wb_FullDescriptionEn As System.Windows.Forms.WebBrowser
    Friend WithEvents tb_NameEng As System.Windows.Forms.TextBox
    Friend WithEvents tb_MetaNameEng As System.Windows.Forms.TextBox
    Friend WithEvents rtb_ShotDescrEng As System.Windows.Forms.RichTextBox
    Friend WithEvents rtb_ShotMetaEng As System.Windows.Forms.RichTextBox
    Friend WithEvents cbx_dataLang As System.Windows.Forms.CheckBox
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents bt_acceptTemplate As System.Windows.Forms.Button
    Friend WithEvents Uc_langObjectTag As nopRestClient.uc_langObject
    Friend WithEvents Uc_SimpleObjectWords As nopRestClient.uc_SimpleObject
    Friend WithEvents lb_Templates As System.Windows.Forms.ListBox
    Friend WithEvents bt_showHTML As System.Windows.Forms.Button
    Friend WithEvents bs_description As System.Windows.Forms.BindingSource
    Friend WithEvents TemplatesListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ContextMenuStripTags As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripTextBoxWord As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItemToTags As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemToWords As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemCopyWord As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemCopyAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemInsertWord As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemInsertAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents FlowLayoutPanel2 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btCondition As System.Windows.Forms.Button

End Class
