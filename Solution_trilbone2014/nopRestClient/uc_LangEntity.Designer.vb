<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uc_LangEntity
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
        Me.tlp_main = New System.Windows.Forms.TableLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lb_ObjectName = New System.Windows.Forms.Label()
        Me.tb_Invariant = New System.Windows.Forms.TextBox()
        Me.tb_Russian = New System.Windows.Forms.TextBox()
        Me.tb_English = New System.Windows.Forms.TextBox()
        Me.bt_Save = New System.Windows.Forms.Button()
        Me.tlp_main.SuspendLayout()
        Me.SuspendLayout()
        '
        'tlp_main
        '
        Me.tlp_main.ColumnCount = 2
        Me.tlp_main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tlp_main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80.0!))
        Me.tlp_main.Controls.Add(Me.Label1, 0, 1)
        Me.tlp_main.Controls.Add(Me.Label2, 0, 2)
        Me.tlp_main.Controls.Add(Me.Label3, 0, 3)
        Me.tlp_main.Controls.Add(Me.lb_ObjectName, 1, 0)
        Me.tlp_main.Controls.Add(Me.tb_Invariant, 1, 1)
        Me.tlp_main.Controls.Add(Me.tb_Russian, 1, 2)
        Me.tlp_main.Controls.Add(Me.tb_English, 1, 3)
        Me.tlp_main.Controls.Add(Me.bt_Save, 0, 0)
        Me.tlp_main.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlp_main.Location = New System.Drawing.Point(0, 0)
        Me.tlp_main.Name = "tlp_main"
        Me.tlp_main.RowCount = 4
        Me.tlp_main.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlp_main.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlp_main.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlp_main.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlp_main.Size = New System.Drawing.Size(315, 111)
        Me.tlp_main.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Invariant"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 61)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Русский"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(19, 89)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "English"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lb_ObjectName
        '
        Me.lb_ObjectName.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lb_ObjectName.AutoSize = True
        Me.lb_ObjectName.Location = New System.Drawing.Point(151, 7)
        Me.lb_ObjectName.Name = "lb_ObjectName"
        Me.lb_ObjectName.Size = New System.Drawing.Size(75, 13)
        Me.lb_ObjectName.TabIndex = 3
        Me.lb_ObjectName.Text = "Property name"
        Me.lb_ObjectName.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'tb_Invariant
        '
        Me.tb_Invariant.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tb_Invariant.Location = New System.Drawing.Point(66, 30)
        Me.tb_Invariant.Name = "tb_Invariant"
        Me.tb_Invariant.Size = New System.Drawing.Size(246, 20)
        Me.tb_Invariant.TabIndex = 4
        '
        'tb_Russian
        '
        Me.tb_Russian.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tb_Russian.Location = New System.Drawing.Point(66, 57)
        Me.tb_Russian.Name = "tb_Russian"
        Me.tb_Russian.Size = New System.Drawing.Size(246, 20)
        Me.tb_Russian.TabIndex = 5
        '
        'tb_English
        '
        Me.tb_English.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tb_English.Location = New System.Drawing.Point(66, 84)
        Me.tb_English.Name = "tb_English"
        Me.tb_English.Size = New System.Drawing.Size(246, 20)
        Me.tb_English.TabIndex = 6
        '
        'bt_Save
        '
        Me.bt_Save.Location = New System.Drawing.Point(3, 3)
        Me.bt_Save.Name = "bt_Save"
        Me.bt_Save.Size = New System.Drawing.Size(57, 21)
        Me.bt_Save.TabIndex = 7
        Me.bt_Save.Text = "Ok"
        Me.bt_Save.UseVisualStyleBackColor = True
        '
        'uc_LangEntity
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.tlp_main)
        Me.Name = "uc_LangEntity"
        Me.Size = New System.Drawing.Size(315, 111)
        Me.tlp_main.ResumeLayout(False)
        Me.tlp_main.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tlp_main As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lb_ObjectName As System.Windows.Forms.Label
    Friend WithEvents tb_Invariant As System.Windows.Forms.TextBox
    Friend WithEvents tb_Russian As System.Windows.Forms.TextBox
    Friend WithEvents tb_English As System.Windows.Forms.TextBox
    Friend WithEvents bt_Save As System.Windows.Forms.Button

End Class
