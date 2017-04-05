<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uc_langObject
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
        Me.tpl_Tags = New System.Windows.Forms.TableLayoutPanel()
        Me.lbl_Selected = New System.Windows.Forms.Label()
        Me.lbl_Source = New System.Windows.Forms.Label()
        Me.lb_Selected = New System.Windows.Forms.ListBox()
        Me.lb_exists = New System.Windows.Forms.ListBox()
        Me.btAddRemove = New System.Windows.Forms.Button()
        Me.lb_Caption = New System.Windows.Forms.Label()
        Me.bt_createNew = New System.Windows.Forms.Button()
        Me.tb_NewText = New System.Windows.Forms.TextBox()
        Me.LangObjBindingSourceSelected = New System.Windows.Forms.BindingSource(Me.components)
        Me.LangObjBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.tpl_Tags.SuspendLayout()
        CType(Me.LangObjBindingSourceSelected, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LangObjBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tpl_Tags
        '
        Me.tpl_Tags.ColumnCount = 3
        Me.tpl_Tags.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.tpl_Tags.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tpl_Tags.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.tpl_Tags.Controls.Add(Me.lbl_Selected, 0, 0)
        Me.tpl_Tags.Controls.Add(Me.lbl_Source, 2, 0)
        Me.tpl_Tags.Controls.Add(Me.lb_Selected, 0, 1)
        Me.tpl_Tags.Controls.Add(Me.lb_exists, 2, 1)
        Me.tpl_Tags.Controls.Add(Me.btAddRemove, 1, 1)
        Me.tpl_Tags.Controls.Add(Me.lb_Caption, 1, 0)
        Me.tpl_Tags.Controls.Add(Me.bt_createNew, 1, 4)
        Me.tpl_Tags.Controls.Add(Me.tb_NewText, 1, 3)
        Me.tpl_Tags.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tpl_Tags.Location = New System.Drawing.Point(0, 0)
        Me.tpl_Tags.Name = "tpl_Tags"
        Me.tpl_Tags.RowCount = 5
        Me.tpl_Tags.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.0!))
        Me.tpl_Tags.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.0!))
        Me.tpl_Tags.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tpl_Tags.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tpl_Tags.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tpl_Tags.Size = New System.Drawing.Size(430, 152)
        Me.tpl_Tags.TabIndex = 12
        '
        'lbl_Selected
        '
        Me.lbl_Selected.AutoSize = True
        Me.lbl_Selected.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbl_Selected.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lbl_Selected.ForeColor = System.Drawing.Color.ForestGreen
        Me.lbl_Selected.Location = New System.Drawing.Point(3, 0)
        Me.lbl_Selected.Name = "lbl_Selected"
        Me.lbl_Selected.Size = New System.Drawing.Size(166, 19)
        Me.lbl_Selected.TabIndex = 0
        Me.lbl_Selected.Text = "Выбраны"
        Me.lbl_Selected.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_Source
        '
        Me.lbl_Source.AutoSize = True
        Me.lbl_Source.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbl_Source.ForeColor = System.Drawing.Color.Red
        Me.lbl_Source.Location = New System.Drawing.Point(261, 0)
        Me.lbl_Source.Name = "lbl_Source"
        Me.lbl_Source.Size = New System.Drawing.Size(166, 19)
        Me.lbl_Source.TabIndex = 1
        Me.lbl_Source.Text = "Доступны"
        Me.lbl_Source.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lb_Selected
        '
        Me.lb_Selected.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lb_Selected.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lb_Selected.ForeColor = System.Drawing.Color.ForestGreen
        Me.lb_Selected.FormattingEnabled = True
        Me.lb_Selected.Location = New System.Drawing.Point(3, 22)
        Me.lb_Selected.Name = "lb_Selected"
        Me.tpl_Tags.SetRowSpan(Me.lb_Selected, 4)
        Me.lb_Selected.Size = New System.Drawing.Size(166, 127)
        Me.lb_Selected.TabIndex = 2
        '
        'lb_exists
        '
        Me.lb_exists.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lb_exists.ForeColor = System.Drawing.Color.Red
        Me.lb_exists.FormattingEnabled = True
        Me.lb_exists.Location = New System.Drawing.Point(261, 22)
        Me.lb_exists.Name = "lb_exists"
        Me.tpl_Tags.SetRowSpan(Me.lb_exists, 4)
        Me.lb_exists.Size = New System.Drawing.Size(166, 127)
        Me.lb_exists.TabIndex = 3
        '
        'btAddRemove
        '
        Me.btAddRemove.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btAddRemove.Location = New System.Drawing.Point(175, 22)
        Me.btAddRemove.Name = "btAddRemove"
        Me.tpl_Tags.SetRowSpan(Me.btAddRemove, 2)
        Me.btAddRemove.Size = New System.Drawing.Size(80, 57)
        Me.btAddRemove.TabIndex = 4
        Me.btAddRemove.Text = "<< >>"
        Me.btAddRemove.UseVisualStyleBackColor = True
        '
        'lb_Caption
        '
        Me.lb_Caption.AutoSize = True
        Me.lb_Caption.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.lb_Caption.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lb_Caption.Location = New System.Drawing.Point(175, 0)
        Me.lb_Caption.Name = "lb_Caption"
        Me.lb_Caption.Size = New System.Drawing.Size(80, 19)
        Me.lb_Caption.TabIndex = 7
        Me.lb_Caption.Text = "Name"
        Me.lb_Caption.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'bt_createNew
        '
        Me.bt_createNew.Dock = System.Windows.Forms.DockStyle.Fill
        Me.bt_createNew.Location = New System.Drawing.Point(175, 115)
        Me.bt_createNew.Name = "bt_createNew"
        Me.bt_createNew.Size = New System.Drawing.Size(80, 34)
        Me.bt_createNew.TabIndex = 5
        Me.bt_createNew.Text = "+ новый"
        Me.bt_createNew.UseVisualStyleBackColor = True
        '
        'tb_NewText
        '
        Me.tb_NewText.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.tb_NewText.Location = New System.Drawing.Point(175, 89)
        Me.tb_NewText.Name = "tb_NewText"
        Me.tb_NewText.Size = New System.Drawing.Size(80, 20)
        Me.tb_NewText.TabIndex = 6
        '
        'LangObjBindingSourceSelected
        '
        Me.LangObjBindingSourceSelected.DataSource = GetType(nopTypes.Nop.Plugin.Misc.panoRazziRestService.LangObject)
        '
        'LangObjBindingSource
        '
        Me.LangObjBindingSource.DataSource = GetType(nopTypes.Nop.Plugin.Misc.panoRazziRestService.LangObject)
        '
        'uc_langObject
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.tpl_Tags)
        Me.Name = "uc_langObject"
        Me.Size = New System.Drawing.Size(430, 152)
        Me.tpl_Tags.ResumeLayout(False)
        Me.tpl_Tags.PerformLayout()
        CType(Me.LangObjBindingSourceSelected, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LangObjBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tpl_Tags As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lbl_Selected As System.Windows.Forms.Label
    Friend WithEvents lbl_Source As System.Windows.Forms.Label
    Friend WithEvents lb_Selected As System.Windows.Forms.ListBox
    Friend WithEvents lb_exists As System.Windows.Forms.ListBox
    Friend WithEvents bt_createNew As System.Windows.Forms.Button
    Friend WithEvents btAddRemove As System.Windows.Forms.Button
    Friend WithEvents tb_NewText As System.Windows.Forms.TextBox
    Friend WithEvents lb_Caption As System.Windows.Forms.Label
    Friend WithEvents LangObjBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents LangObjBindingSourceSelected As System.Windows.Forms.BindingSource

End Class
