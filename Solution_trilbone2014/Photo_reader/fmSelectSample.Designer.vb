<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fmSelectSample
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.lbSampleNumbers = New System.Windows.Forms.ListBox()
        Me.lbSelected = New System.Windows.Forms.Label()
        Me.btSelect = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lbSampleNumbers
        '
        Me.lbSampleNumbers.FormattingEnabled = True
        Me.lbSampleNumbers.Location = New System.Drawing.Point(2, 3)
        Me.lbSampleNumbers.Name = "lbSampleNumbers"
        Me.lbSampleNumbers.Size = New System.Drawing.Size(122, 212)
        Me.lbSampleNumbers.TabIndex = 0
        '
        'lbSelected
        '
        Me.lbSelected.AutoSize = True
        Me.lbSelected.Location = New System.Drawing.Point(6, 229)
        Me.lbSelected.Name = "lbSelected"
        Me.lbSelected.Size = New System.Drawing.Size(39, 13)
        Me.lbSelected.TabIndex = 1
        Me.lbSelected.Text = "Label1"
        '
        'btSelect
        '
        Me.btSelect.Location = New System.Drawing.Point(3, 254)
        Me.btSelect.Name = "btSelect"
        Me.btSelect.Size = New System.Drawing.Size(121, 24)
        Me.btSelect.TabIndex = 2
        Me.btSelect.Text = "Select.."
        Me.btSelect.UseVisualStyleBackColor = True
        '
        'fmSelectSample
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(124, 283)
        Me.ControlBox = False
        Me.Controls.Add(Me.btSelect)
        Me.Controls.Add(Me.lbSelected)
        Me.Controls.Add(Me.lbSampleNumbers)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "fmSelectSample"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbSampleNumbers As System.Windows.Forms.ListBox
    Friend WithEvents lbSelected As System.Windows.Forms.Label
    Friend WithEvents btSelect As System.Windows.Forms.Button
End Class
