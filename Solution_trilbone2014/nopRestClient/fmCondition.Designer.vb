<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fmCondition
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
        Me.UserControlQality1 = New UserControlQality()
        Me.SuspendLayout()
        '
        'UserControlQality1
        '
        Me.UserControlQality1.Culture = New System.Globalization.CultureInfo("en-US")
        Me.UserControlQality1.Location = New System.Drawing.Point(0, 2)
        Me.UserControlQality1.Name = "UserControlQality1"
        Me.UserControlQality1.Clear()
        Me.UserControlQality1.Size = New System.Drawing.Size(406, 253)
        Me.UserControlQality1.TabIndex = 0
        '
        'fmCondition
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(408, 253)
        Me.Controls.Add(Me.UserControlQality1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "fmCondition"
        Me.Text = "Краткое описание"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UserControlQality1 As nopRestClient.UserControlQality
End Class
