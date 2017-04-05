<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fmSelectMaterial
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btApply = New System.Windows.Forms.Button()
        Me.cbMaterial = New System.Windows.Forms.ListBox()
        Me.tbCode = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'btApply
        '
        Me.btApply.Enabled = False
        Me.btApply.Location = New System.Drawing.Point(302, 81)
        Me.btApply.Name = "btApply"
        Me.btApply.Size = New System.Drawing.Size(99, 26)
        Me.btApply.TabIndex = 1
        Me.btApply.Text = "Принять"
        Me.btApply.UseVisualStyleBackColor = True
        '
        'cbMaterial
        '
        Me.cbMaterial.FormattingEnabled = True
        Me.cbMaterial.Location = New System.Drawing.Point(22, 12)
        Me.cbMaterial.Name = "cbMaterial"
        Me.cbMaterial.Size = New System.Drawing.Size(252, 95)
        Me.cbMaterial.TabIndex = 2
        '
        'tbCode
        '
        Me.tbCode.Location = New System.Drawing.Point(301, 21)
        Me.tbCode.Name = "tbCode"
        Me.tbCode.Size = New System.Drawing.Size(100, 20)
        Me.tbCode.TabIndex = 3
        '
        'fmSelectMaterial
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(413, 126)
        Me.Controls.Add(Me.tbCode)
        Me.Controls.Add(Me.cbMaterial)
        Me.Controls.Add(Me.btApply)
        Me.Name = "fmSelectMaterial"
        Me.Text = "восстановить код"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btApply As System.Windows.Forms.Button
    Friend WithEvents cbMaterial As System.Windows.Forms.ListBox
    Friend WithEvents tbCode As System.Windows.Forms.TextBox
End Class
