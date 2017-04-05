<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fm_Description
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
        Me.Uc_nopDescription1 = New nopRestClient.uc_nopDescription()
        Me.SuspendLayout()
        '
        'Uc_nopDescription1
        '
        Me.Uc_nopDescription1.DataLangString = "1"
        Me.Uc_nopDescription1.DataLangCheckedStatus = False
        Me.Uc_nopDescription1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Uc_nopDescription1.Location = New System.Drawing.Point(0, 0)
        Me.Uc_nopDescription1.Name = "Uc_nopDescription1"
        Me.Uc_nopDescription1.Size = New System.Drawing.Size(1077, 578)
        Me.Uc_nopDescription1.TabIndex = 0
        '
        'fm_Description
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1077, 578)
        Me.Controls.Add(Me.Uc_nopDescription1)
        Me.Name = "fm_Description"
        Me.Text = "fm_Description"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Uc_nopDescription1 As nopRestClient.uc_nopDescription
End Class
