<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fm_TierPrice
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
        Me.Uc_tierPrice1 = New nopRestClient.uc_tierPrice()
        Me.SuspendLayout()
        '
        'Uc_tierPrice1
        '
        Me.Uc_tierPrice1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Uc_tierPrice1.Location = New System.Drawing.Point(0, 0)
        Me.Uc_tierPrice1.Name = "Uc_tierPrice1"
        Me.Uc_tierPrice1.Size = New System.Drawing.Size(1105, 170)
        Me.Uc_tierPrice1.TabIndex = 0
        '
        'fm_TierPrice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1106, 170)
        Me.Controls.Add(Me.Uc_tierPrice1)
        Me.Name = "fm_TierPrice"
        Me.Text = "fm_TierPrice"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Uc_tierPrice1 As nopRestClient.uc_tierPrice
End Class
