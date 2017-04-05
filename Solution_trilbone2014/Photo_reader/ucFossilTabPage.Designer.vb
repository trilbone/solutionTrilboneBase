<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucFossilTabPage
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.tabctlFossils = New System.Windows.Forms.TabControl()
        Me.tabctlFossils.SuspendLayout()
        Me.SuspendLayout()
        '

        Me.tabctlFossils.Location = New System.Drawing.Point(3, 3)
        Me.tabctlFossils.Name = "tabctlFossils"
        Me.tabctlFossils.SelectedIndex = 0
        Me.tabctlFossils.Size = New System.Drawing.Size(255, 270)
        Me.tabctlFossils.TabIndex = 0
        '
        'ucFossilTabPage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.tabctlFossils)
        Me.Name = "ucFossilTabPage"
        Me.Size = New System.Drawing.Size(263, 277)
        Me.tabctlFossils.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tabctlFossils As System.Windows.Forms.TabControl

    
End Class
