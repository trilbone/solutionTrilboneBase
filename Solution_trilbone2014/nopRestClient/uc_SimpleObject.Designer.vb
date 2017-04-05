<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uc_SimpleObject
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
        Me.tlp_words = New System.Windows.Forms.TableLayoutPanel()
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel()
        Me.tb_newText = New System.Windows.Forms.TextBox()
        Me.bt_Add = New System.Windows.Forms.Button()
        Me.bt_remove = New System.Windows.Forms.Button()
        Me.lb_selected = New System.Windows.Forms.ListBox()
        Me.lbl_Selected = New System.Windows.Forms.Label()
        Me.lb_objectName = New System.Windows.Forms.Label()
        Me.LangObjBindingSourceSelected = New System.Windows.Forms.BindingSource(Me.components)
        Me.tlp_words.SuspendLayout()
        Me.FlowLayoutPanel2.SuspendLayout()
        CType(Me.LangObjBindingSourceSelected, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tlp_words
        '
        Me.tlp_words.ColumnCount = 2
        Me.tlp_words.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.16913!))
        Me.tlp_words.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 59.83087!))
        Me.tlp_words.Controls.Add(Me.FlowLayoutPanel2, 1, 1)
        Me.tlp_words.Controls.Add(Me.lb_selected, 0, 1)
        Me.tlp_words.Controls.Add(Me.lbl_Selected, 0, 0)
        Me.tlp_words.Controls.Add(Me.lb_objectName, 1, 0)
        Me.tlp_words.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlp_words.Location = New System.Drawing.Point(0, 0)
        Me.tlp_words.Name = "tlp_words"
        Me.tlp_words.RowCount = 2
        Me.tlp_words.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.tlp_words.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85.0!))
        Me.tlp_words.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlp_words.Size = New System.Drawing.Size(417, 151)
        Me.tlp_words.TabIndex = 14
        '
        'FlowLayoutPanel2
        '
        Me.FlowLayoutPanel2.Controls.Add(Me.tb_newText)
        Me.FlowLayoutPanel2.Controls.Add(Me.bt_Add)
        Me.FlowLayoutPanel2.Controls.Add(Me.bt_remove)
        Me.FlowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(170, 25)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(244, 123)
        Me.FlowLayoutPanel2.TabIndex = 0
        '
        'tb_newText
        '
        Me.tb_newText.Dock = System.Windows.Forms.DockStyle.Top
        Me.tb_newText.Location = New System.Drawing.Point(3, 3)
        Me.tb_newText.Name = "tb_newText"
        Me.tb_newText.Size = New System.Drawing.Size(239, 20)
        Me.tb_newText.TabIndex = 0
        '
        'bt_Add
        '
        Me.bt_Add.AutoSize = True
        Me.bt_Add.Dock = System.Windows.Forms.DockStyle.Left
        Me.bt_Add.Location = New System.Drawing.Point(3, 29)
        Me.bt_Add.Name = "bt_Add"
        Me.bt_Add.Size = New System.Drawing.Size(184, 23)
        Me.bt_Add.TabIndex = 1
        Me.bt_Add.Text = "добавить"
        Me.bt_Add.UseVisualStyleBackColor = True
        '
        'bt_remove
        '
        Me.bt_remove.Location = New System.Drawing.Point(3, 58)
        Me.bt_remove.Name = "bt_remove"
        Me.bt_remove.Size = New System.Drawing.Size(75, 23)
        Me.bt_remove.TabIndex = 2
        Me.bt_remove.Text = "удалить"
        Me.bt_remove.UseVisualStyleBackColor = True
        '
        'lb_selected
        '
        Me.lb_selected.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lb_selected.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lb_selected.ForeColor = System.Drawing.Color.ForestGreen
        Me.lb_selected.FormattingEnabled = True
        Me.lb_selected.Location = New System.Drawing.Point(3, 25)
        Me.lb_selected.Name = "lb_selected"
        Me.lb_selected.Size = New System.Drawing.Size(161, 123)
        Me.lb_selected.TabIndex = 1
        '
        'lbl_Selected
        '
        Me.lbl_Selected.AutoSize = True
        Me.lbl_Selected.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbl_Selected.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lbl_Selected.ForeColor = System.Drawing.Color.ForestGreen
        Me.lbl_Selected.Location = New System.Drawing.Point(3, 0)
        Me.lbl_Selected.Name = "lbl_Selected"
        Me.lbl_Selected.Size = New System.Drawing.Size(161, 22)
        Me.lbl_Selected.TabIndex = 2
        Me.lbl_Selected.Text = "Выбраны"
        Me.lbl_Selected.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'lb_objectName
        '
        Me.lb_objectName.AutoSize = True
        Me.lb_objectName.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.lb_objectName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lb_objectName.Location = New System.Drawing.Point(170, 0)
        Me.lb_objectName.Name = "lb_objectName"
        Me.lb_objectName.Size = New System.Drawing.Size(244, 22)
        Me.lb_objectName.TabIndex = 3
        Me.lb_objectName.Text = "Property Name"
        Me.lb_objectName.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'LangObjBindingSourceSelected
        '
        Me.LangObjBindingSourceSelected.DataSource = GetType(nopTypes.Nop.Plugin.Misc.panoRazziRestService.LangObject)
        '
        'uc_SimpleObject
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.tlp_words)
        Me.Name = "uc_SimpleObject"
        Me.Size = New System.Drawing.Size(417, 151)
        Me.tlp_words.ResumeLayout(False)
        Me.tlp_words.PerformLayout()
        Me.FlowLayoutPanel2.ResumeLayout(False)
        Me.FlowLayoutPanel2.PerformLayout()
        CType(Me.LangObjBindingSourceSelected, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tlp_words As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents FlowLayoutPanel2 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents tb_newText As System.Windows.Forms.TextBox
    Friend WithEvents bt_Add As System.Windows.Forms.Button
    Friend WithEvents bt_remove As System.Windows.Forms.Button
    Friend WithEvents lb_selected As System.Windows.Forms.ListBox
    Friend WithEvents lbl_Selected As System.Windows.Forms.Label
    Friend WithEvents lb_objectName As System.Windows.Forms.Label
    Friend WithEvents LangObjBindingSourceSelected As System.Windows.Forms.BindingSource

End Class
