<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class spDigitalBoard
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
        Me.UcBigDigit1 = New PriceCalculator.ucBigDigit()
        Me.SuspendLayout()
        '
        'UcBigDigit1
        '
        Me.UcBigDigit1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcBigDigit1.Location = New System.Drawing.Point(0, 0)
        Me.UcBigDigit1.Name = "UcBigDigit1"
        Me.UcBigDigit1.Size = New System.Drawing.Size(308, 248)
        Me.UcBigDigit1.TabIndex = 0
        '
        'SplashScreen1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(308, 248)
        Me.ControlBox = False
        Me.Controls.Add(Me.UcBigDigit1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SplashScreen1"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UcBigDigit1 As PriceCalculator.ucBigDigit

End Class
