<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucActiveWord
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
        Me.components = New System.ComponentModel.Container()
        Me.lbDbWords = New System.Windows.Forms.ListBox()
        Me.TbActualWordBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.lbSourceWords = New System.Windows.Forms.ListBox()
        Me.BindingSourceSourceWords = New System.Windows.Forms.BindingSource(Me.components)
        Me.tbCurrentWord = New System.Windows.Forms.TextBox()
        Me.btSave = New System.Windows.Forms.Button()
        Me.btCancel = New System.Windows.Forms.Button()
        Me.btAdd = New System.Windows.Forms.Button()
        Me.btRemove = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.TbActualWordBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingSourceSourceWords, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbDbWords
        '
        Me.lbDbWords.DataSource = Me.TbActualWordBindingSource
        Me.lbDbWords.DisplayMember = "Word"
        Me.lbDbWords.FormattingEnabled = True
        Me.lbDbWords.Location = New System.Drawing.Point(262, 57)
        Me.lbDbWords.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.lbDbWords.Name = "lbDbWords"
        Me.lbDbWords.Size = New System.Drawing.Size(174, 277)
        Me.lbDbWords.TabIndex = 0
        Me.lbDbWords.ValueMember = "Id"
        '
        'TbActualWordBindingSource
        '
        Me.TbActualWordBindingSource.DataSource = GetType(Service.tbActualWord)
        '
        'lbSourceWords
        '
        Me.lbSourceWords.DataSource = Me.BindingSourceSourceWords
        Me.lbSourceWords.FormattingEnabled = True
        Me.lbSourceWords.Location = New System.Drawing.Point(19, 18)
        Me.lbSourceWords.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.lbSourceWords.Name = "lbSourceWords"
        Me.lbSourceWords.Size = New System.Drawing.Size(179, 342)
        Me.lbSourceWords.TabIndex = 1
        '
        'tbCurrentWord
        '
        Me.tbCurrentWord.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TbActualWordBindingSource, "Word", True))
        Me.tbCurrentWord.Location = New System.Drawing.Point(262, 18)
        Me.tbCurrentWord.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.tbCurrentWord.Name = "tbCurrentWord"
        Me.tbCurrentWord.Size = New System.Drawing.Size(174, 20)
        Me.tbCurrentWord.TabIndex = 2
        '
        'btSave
        '
        Me.btSave.Location = New System.Drawing.Point(262, 349)
        Me.btSave.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btSave.Name = "btSave"
        Me.btSave.Size = New System.Drawing.Size(78, 30)
        Me.btSave.TabIndex = 3
        Me.btSave.Text = "Сохранить"
        Me.btSave.UseVisualStyleBackColor = True
        '
        'btCancel
        '
        Me.btCancel.Location = New System.Drawing.Point(357, 349)
        Me.btCancel.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btCancel.Name = "btCancel"
        Me.btCancel.Size = New System.Drawing.Size(78, 30)
        Me.btCancel.TabIndex = 4
        Me.btCancel.Text = "Отменить"
        Me.btCancel.UseVisualStyleBackColor = True
        '
        'btAdd
        '
        Me.btAdd.Location = New System.Drawing.Point(207, 94)
        Me.btAdd.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btAdd.Name = "btAdd"
        Me.btAdd.Size = New System.Drawing.Size(43, 49)
        Me.btAdd.TabIndex = 5
        Me.btAdd.Text = ">>"
        Me.btAdd.UseVisualStyleBackColor = True
        '
        'btRemove
        '
        Me.btRemove.Location = New System.Drawing.Point(209, 167)
        Me.btRemove.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btRemove.Name = "btRemove"
        Me.btRemove.Size = New System.Drawing.Size(43, 49)
        Me.btRemove.TabIndex = 6
        Me.btRemove.Text = "<<"
        Me.btRemove.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(207, 280)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Label1"
        '
        'ucActiveWord
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btRemove)
        Me.Controls.Add(Me.btAdd)
        Me.Controls.Add(Me.btCancel)
        Me.Controls.Add(Me.btSave)
        Me.Controls.Add(Me.tbCurrentWord)
        Me.Controls.Add(Me.lbSourceWords)
        Me.Controls.Add(Me.lbDbWords)
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Name = "ucActiveWord"
        Me.Size = New System.Drawing.Size(461, 382)
        CType(Me.TbActualWordBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingSourceSourceWords, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbDbWords As System.Windows.Forms.ListBox
    Friend WithEvents lbSourceWords As System.Windows.Forms.ListBox
    Friend WithEvents tbCurrentWord As System.Windows.Forms.TextBox
    Friend WithEvents btSave As System.Windows.Forms.Button
    Friend WithEvents btCancel As System.Windows.Forms.Button
    Friend WithEvents TbActualWordBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents btAdd As System.Windows.Forms.Button
    Friend WithEvents btRemove As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BindingSourceSourceWords As System.Windows.Forms.BindingSource

End Class
