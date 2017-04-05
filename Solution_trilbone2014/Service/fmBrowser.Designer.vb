<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fmBrowser
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
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.btSaveFile = New System.Windows.Forms.Button()
        Me.btOpenBrowser = New System.Windows.Forms.Button()
        Me.tbLink = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btToSite = New System.Windows.Forms.Button()
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser()
        Me.SuspendLayout()
        '
        'btSaveFile
        '
        Me.btSaveFile.Location = New System.Drawing.Point(0, 532)
        Me.btSaveFile.Name = "btSaveFile"
        Me.btSaveFile.Size = New System.Drawing.Size(144, 23)
        Me.btSaveFile.TabIndex = 1
        Me.btSaveFile.Text = "Сохранить локально"
        Me.btSaveFile.UseVisualStyleBackColor = True
        '
        'btOpenBrowser
        '
        Me.btOpenBrowser.Location = New System.Drawing.Point(160, 532)
        Me.btOpenBrowser.Name = "btOpenBrowser"
        Me.btOpenBrowser.Size = New System.Drawing.Size(136, 23)
        Me.btOpenBrowser.TabIndex = 2
        Me.btOpenBrowser.Text = "в браузере.."
        Me.btOpenBrowser.UseVisualStyleBackColor = True
        '
        'tbLink
        '
        Me.tbLink.Location = New System.Drawing.Point(372, 534)
        Me.tbLink.Name = "tbLink"
        Me.tbLink.Size = New System.Drawing.Size(397, 20)
        Me.tbLink.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(320, 537)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Ссылка"
        '
        'btToSite
        '
        Me.btToSite.Location = New System.Drawing.Point(784, 532)
        Me.btToSite.Name = "btToSite"
        Me.btToSite.Size = New System.Drawing.Size(75, 23)
        Me.btToSite.TabIndex = 5
        Me.btToSite.Text = "Trilbone"
        Me.btToSite.UseVisualStyleBackColor = True
        '
        'WebBrowser1
        '
        Me.WebBrowser1.Dock = System.Windows.Forms.DockStyle.Top
        Me.WebBrowser1.Location = New System.Drawing.Point(0, 0)
        Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.Size = New System.Drawing.Size(871, 526)
        Me.WebBrowser1.TabIndex = 0
        '
        'fmBrowser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(871, 558)
        Me.Controls.Add(Me.btToSite)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tbLink)
        Me.Controls.Add(Me.btOpenBrowser)
        Me.Controls.Add(Me.btSaveFile)
        Me.Controls.Add(Me.WebBrowser1)
        Me.Name = "fmBrowser"
        Me.Text = "fmBrowser"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents WebBrowser1 As System.Windows.Forms.WebBrowser
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents btSaveFile As System.Windows.Forms.Button
    Friend WithEvents btOpenBrowser As System.Windows.Forms.Button
    Friend WithEvents tbLink As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btToSite As System.Windows.Forms.Button
End Class
