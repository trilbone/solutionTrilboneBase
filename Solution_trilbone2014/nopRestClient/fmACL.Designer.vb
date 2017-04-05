<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fmACL
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
        Me.Uc_ACL1 = New nopRestClient.uc_ACL()
        Me.SuspendLayout()
        '
        'Uc_ACL1
        '
        Me.Uc_ACL1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Uc_ACL1.Location = New System.Drawing.Point(0, 0)
        Me.Uc_ACL1.Name = "Uc_ACL1"
        Me.Uc_ACL1.Size = New System.Drawing.Size(984, 175)
        Me.Uc_ACL1.TabIndex = 0
        '
        'fmACL
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 175)
        Me.Controls.Add(Me.Uc_ACL1)
        Me.Name = "fmACL"
        Me.Text = "fmACL"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Uc_ACL1 As nopRestClient.uc_ACL
End Class
