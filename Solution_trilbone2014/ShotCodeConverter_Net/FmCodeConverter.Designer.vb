<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FmCodeConverter
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
        Me.btCopyArticul = New System.Windows.Forms.Button()
        Me.btCopyNumber = New System.Windows.Forms.Button()
        Me.tbSampleNumber = New System.Windows.Forms.TextBox()
        Me.btSearchInfo = New System.Windows.Forms.Button()
        Me.lbSample = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btCopyArticul
        '
        Me.btCopyArticul.Location = New System.Drawing.Point(163, 72)
        Me.btCopyArticul.Name = "btCopyArticul"
        Me.btCopyArticul.Size = New System.Drawing.Size(98, 23)
        Me.btCopyArticul.TabIndex = 44
        Me.btCopyArticul.Text = "Копир. артикул"
        Me.btCopyArticul.UseVisualStyleBackColor = True
        '
        'btCopyNumber
        '
        Me.btCopyNumber.Location = New System.Drawing.Point(12, 72)
        Me.btCopyNumber.Name = "btCopyNumber"
        Me.btCopyNumber.Size = New System.Drawing.Size(137, 23)
        Me.btCopyNumber.TabIndex = 43
        Me.btCopyNumber.Text = "Копировать EAN font"
        Me.btCopyNumber.UseVisualStyleBackColor = True
        '
        'tbSampleNumber
        '
        Me.tbSampleNumber.Location = New System.Drawing.Point(12, 12)
        Me.tbSampleNumber.Name = "tbSampleNumber"
        Me.tbSampleNumber.Size = New System.Drawing.Size(159, 20)
        Me.tbSampleNumber.TabIndex = 45
        '
        'btSearchInfo
        '
        Me.btSearchInfo.Location = New System.Drawing.Point(187, 11)
        Me.btSearchInfo.Name = "btSearchInfo"
        Me.btSearchInfo.Size = New System.Drawing.Size(64, 23)
        Me.btSearchInfo.TabIndex = 46
        Me.btSearchInfo.Text = "поиск.."
        Me.btSearchInfo.UseVisualStyleBackColor = True
        '
        'lbSample
        '
        Me.lbSample.AutoSize = True
        Me.lbSample.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbSample.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lbSample.Location = New System.Drawing.Point(12, 43)
        Me.lbSample.Name = "lbSample"
        Me.lbSample.Size = New System.Drawing.Size(119, 19)
        Me.lbSample.TabIndex = 47
        Me.lbSample.Text = "Текущий статус:"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(163, 43)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(98, 23)
        Me.Button1.TabIndex = 48
        Me.Button1.Text = "Копир. код"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'FmCodeConverter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(268, 109)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.lbSample)
        Me.Controls.Add(Me.btSearchInfo)
        Me.Controls.Add(Me.tbSampleNumber)
        Me.Controls.Add(Me.btCopyArticul)
        Me.Controls.Add(Me.btCopyNumber)
        Me.Name = "FmCodeConverter"
        Me.Text = "Преобразователь кодов"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btCopyArticul As System.Windows.Forms.Button
    Friend WithEvents btCopyNumber As System.Windows.Forms.Button
    Friend WithEvents tbSampleNumber As System.Windows.Forms.TextBox
    Friend WithEvents btSearchInfo As System.Windows.Forms.Button
    Friend WithEvents lbSample As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
