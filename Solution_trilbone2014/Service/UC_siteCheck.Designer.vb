<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UC_siteCheck
    Inherits System.Windows.Forms.UserControl

    'Пользовательский элемент управления (UserControl) переопределяет метод Dispose для очистки списка компонентов.
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbSampleNumber = New System.Windows.Forms.TextBox()
        Me.btQuery = New System.Windows.Forms.Button()
        Me.lbResult = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Номер"
        '
        'tbSampleNumber
        '
        Me.tbSampleNumber.Location = New System.Drawing.Point(70, 29)
        Me.tbSampleNumber.Name = "tbSampleNumber"
        Me.tbSampleNumber.Size = New System.Drawing.Size(100, 20)
        Me.tbSampleNumber.TabIndex = 1
        '
        'btQuery
        '
        Me.btQuery.Location = New System.Drawing.Point(185, 29)
        Me.btQuery.Name = "btQuery"
        Me.btQuery.Size = New System.Drawing.Size(75, 23)
        Me.btQuery.TabIndex = 2
        Me.btQuery.Text = "запрос"
        Me.btQuery.UseVisualStyleBackColor = True
        '
        'lbResult
        '
        Me.lbResult.AutoSize = True
        Me.lbResult.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lbResult.Location = New System.Drawing.Point(70, 65)
        Me.lbResult.Name = "lbResult"
        Me.lbResult.Size = New System.Drawing.Size(77, 16)
        Me.lbResult.TabIndex = 3
        Me.lbResult.Text = "результат"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 4)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Проверка на сайте"
        '
        'UC_siteCheck
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lbResult)
        Me.Controls.Add(Me.btQuery)
        Me.Controls.Add(Me.tbSampleNumber)
        Me.Controls.Add(Me.Label1)
        Me.Name = "UC_siteCheck"
        Me.Size = New System.Drawing.Size(261, 89)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tbSampleNumber As System.Windows.Forms.TextBox
    Friend WithEvents btQuery As System.Windows.Forms.Button
    Friend WithEvents lbResult As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label

End Class
