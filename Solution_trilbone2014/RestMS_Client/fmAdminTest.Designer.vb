<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fmAdminTest
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
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.cbObjects = New System.Windows.Forms.ComboBox()
        Me.cbFilters = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.RichTextBox2 = New System.Windows.Forms.RichTextBox()
        Me.RichTextBox3 = New System.Windows.Forms.RichTextBox()
        Me.tbManualFilter = New System.Windows.Forms.TextBox()
        Me.tbManualObject = New System.Windows.Forms.TextBox()
        Me.btDirectRequest = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Location = New System.Drawing.Point(314, 3)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(574, 128)
        Me.RichTextBox1.TabIndex = 1
        Me.RichTextBox1.Text = ""
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(12, 12)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(148, 41)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "запрос"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(12, 111)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(296, 20)
        Me.TextBox1.TabIndex = 3
        '
        'cbObjects
        '
        Me.cbObjects.FormattingEnabled = True
        Me.cbObjects.Location = New System.Drawing.Point(12, 159)
        Me.cbObjects.Name = "cbObjects"
        Me.cbObjects.Size = New System.Drawing.Size(163, 21)
        Me.cbObjects.TabIndex = 4
        '
        'cbFilters
        '
        Me.cbFilters.FormattingEnabled = True
        Me.cbFilters.Location = New System.Drawing.Point(12, 246)
        Me.cbFilters.Name = "cbFilters"
        Me.cbFilters.Size = New System.Drawing.Size(163, 21)
        Me.cbFilters.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 140)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Обьекты"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 230)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Фильтры"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 92)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(102, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "параметр фильтра"
        '
        'RichTextBox2
        '
        Me.RichTextBox2.Location = New System.Drawing.Point(314, 230)
        Me.RichTextBox2.Name = "RichTextBox2"
        Me.RichTextBox2.Size = New System.Drawing.Size(574, 245)
        Me.RichTextBox2.TabIndex = 9
        Me.RichTextBox2.Text = ""
        '
        'RichTextBox3
        '
        Me.RichTextBox3.Location = New System.Drawing.Point(314, 140)
        Me.RichTextBox3.Name = "RichTextBox3"
        Me.RichTextBox3.Size = New System.Drawing.Size(574, 49)
        Me.RichTextBox3.TabIndex = 10
        Me.RichTextBox3.Text = ""
        '
        'tbManualFilter
        '
        Me.tbManualFilter.Location = New System.Drawing.Point(12, 273)
        Me.tbManualFilter.Name = "tbManualFilter"
        Me.tbManualFilter.Size = New System.Drawing.Size(163, 20)
        Me.tbManualFilter.TabIndex = 11
        '
        'tbManualObject
        '
        Me.tbManualObject.Location = New System.Drawing.Point(12, 186)
        Me.tbManualObject.Name = "tbManualObject"
        Me.tbManualObject.Size = New System.Drawing.Size(163, 20)
        Me.tbManualObject.TabIndex = 12
        '
        'btDirectRequest
        '
        Me.btDirectRequest.Location = New System.Drawing.Point(730, 195)
        Me.btDirectRequest.Name = "btDirectRequest"
        Me.btDirectRequest.Size = New System.Drawing.Size(75, 23)
        Me.btDirectRequest.TabIndex = 13
        Me.btDirectRequest.Text = "Выполнить"
        Me.btDirectRequest.UseVisualStyleBackColor = True
        '
        'fmAdminTest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(900, 487)
        Me.Controls.Add(Me.btDirectRequest)
        Me.Controls.Add(Me.tbManualObject)
        Me.Controls.Add(Me.tbManualFilter)
        Me.Controls.Add(Me.RichTextBox3)
        Me.Controls.Add(Me.RichTextBox2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cbFilters)
        Me.Controls.Add(Me.cbObjects)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.RichTextBox1)
        Me.Name = "fmAdminTest"
        Me.Text = "Запрос к Складу"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents cbObjects As System.Windows.Forms.ComboBox
    Friend WithEvents cbFilters As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents RichTextBox2 As System.Windows.Forms.RichTextBox
    Friend WithEvents RichTextBox3 As System.Windows.Forms.RichTextBox
    Friend WithEvents tbManualFilter As TextBox
    Friend WithEvents tbManualObject As TextBox
    Friend WithEvents btDirectRequest As System.Windows.Forms.Button
End Class
