<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uc_ACL
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
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Uc_langObjectRoles = New nopRestClient.uc_langObject()
        Me.Uc_langObjectStore = New nopRestClient.uc_langObject()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.Uc_langObjectRoles)
        Me.FlowLayoutPanel1.Controls.Add(Me.Uc_langObjectStore)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(1105, 169)
        Me.FlowLayoutPanel1.TabIndex = 0
        '
        'Uc_langObjectRoles
        '
        Me.Uc_langObjectRoles.EnabledNew = False
        Me.Uc_langObjectRoles.Location = New System.Drawing.Point(3, 3)
        Me.Uc_langObjectRoles.Name = "Uc_langObjectRoles"
        Me.Uc_langObjectRoles.SingleSelect = False
        Me.Uc_langObjectRoles.Size = New System.Drawing.Size(430, 163)
        Me.Uc_langObjectRoles.TabIndex = 0
        Me.Uc_langObjectRoles.UcCaption = "Роли"
        '
        'Uc_langObjectStore
        '
        Me.Uc_langObjectStore.EnabledNew = False
        Me.Uc_langObjectStore.Location = New System.Drawing.Point(439, 3)
        Me.Uc_langObjectStore.Name = "Uc_langObjectStore"
        Me.Uc_langObjectStore.SingleSelect = False
        Me.Uc_langObjectStore.Size = New System.Drawing.Size(430, 166)
        Me.Uc_langObjectStore.TabIndex = 1
        Me.Uc_langObjectStore.UcCaption = "Магазины"
        '
        'uc_ACL
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Name = "uc_ACL"
        Me.Size = New System.Drawing.Size(1105, 169)
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Uc_langObjectRoles As nopRestClient.uc_langObject
    Friend WithEvents Uc_langObjectStore As nopRestClient.uc_langObject

End Class
