<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Friend Class fmLinks
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
        Me.lbLinks = New System.Windows.Forms.ListBox()
        Me.btAccept = New System.Windows.Forms.Button()
        Me.btClose = New System.Windows.Forms.Button()
        Me.tbDescription = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown()
        Me.btAcceptMUI = New System.Windows.Forms.Button()
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.cbxShowLeaf = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tbNodeNameRUS = New System.Windows.Forms.TextBox()
        Me.lbArticul = New System.Windows.Forms.Label()
        Me.tbNodeName = New System.Windows.Forms.TextBox()
        Me.btCreateNode = New System.Windows.Forms.Button()
        Me.btClear = New System.Windows.Forms.Button()
        Me.btAddToArticul = New System.Windows.Forms.Button()
        Me.lbArticulThis = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btCreateArticul = New System.Windows.Forms.Button()
        Me.btDelArticul = New System.Windows.Forms.Button()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.btCopyName = New System.Windows.Forms.Button()
        Me.btCopyNodeValue = New System.Windows.Forms.Button()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbLinks
        '
        Me.lbLinks.FormattingEnabled = True
        Me.lbLinks.Location = New System.Drawing.Point(5, 352)
        Me.lbLinks.Name = "lbLinks"
        Me.lbLinks.Size = New System.Drawing.Size(160, 199)
        Me.lbLinks.TabIndex = 0
        '
        'btAccept
        '
        Me.btAccept.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btAccept.Location = New System.Drawing.Point(49, 274)
        Me.btAccept.Name = "btAccept"
        Me.btAccept.Size = New System.Drawing.Size(153, 27)
        Me.btAccept.TabIndex = 1
        Me.btAccept.Text = "Добавить к описанию"
        Me.btAccept.UseVisualStyleBackColor = True
        '
        'btClose
        '
        Me.btClose.Location = New System.Drawing.Point(438, 532)
        Me.btClose.Name = "btClose"
        Me.btClose.Size = New System.Drawing.Size(75, 23)
        Me.btClose.TabIndex = 2
        Me.btClose.Text = "Закрыть"
        Me.btClose.UseVisualStyleBackColor = True
        '
        'tbDescription
        '
        Me.tbDescription.Location = New System.Drawing.Point(174, 455)
        Me.tbDescription.Multiline = True
        Me.tbDescription.Name = "tbDescription"
        Me.tbDescription.Size = New System.Drawing.Size(339, 44)
        Me.tbDescription.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(179, 508)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 13)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "уровень"
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.BackColor = System.Drawing.SystemColors.Window
        Me.NumericUpDown1.Location = New System.Drawing.Point(239, 506)
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(34, 20)
        Me.NumericUpDown1.TabIndex = 20
        Me.NumericUpDown1.Value = New Decimal(New Integer() {9, 0, 0, 0})
        '
        'btAcceptMUI
        '
        Me.btAcceptMUI.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btAcceptMUI.Location = New System.Drawing.Point(49, 206)
        Me.btAcceptMUI.Name = "btAcceptMUI"
        Me.btAcceptMUI.Size = New System.Drawing.Size(153, 49)
        Me.btAcceptMUI.TabIndex = 22
        Me.btAcceptMUI.Text = "Добавить к описанию (MUI)"
        Me.btAcceptMUI.UseVisualStyleBackColor = True
        '
        'TreeView1
        '
        Me.TreeView1.Location = New System.Drawing.Point(223, 145)
        Me.TreeView1.Name = "TreeView1"
        Me.TreeView1.Size = New System.Drawing.Size(290, 279)
        Me.TreeView1.TabIndex = 23
        '
        'cbxShowLeaf
        '
        Me.cbxShowLeaf.AutoSize = True
        Me.cbxShowLeaf.Location = New System.Drawing.Point(223, 430)
        Me.cbxShowLeaf.Name = "cbxShowLeaf"
        Me.cbxShowLeaf.Size = New System.Drawing.Size(89, 17)
        Me.cbxShowLeaf.TabIndex = 28
        Me.cbxShowLeaf.Text = "с артикулом"
        Me.cbxShowLeaf.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.tbNodeNameRUS)
        Me.GroupBox1.Controls.Add(Me.lbArticul)
        Me.GroupBox1.Controls.Add(Me.tbNodeName)
        Me.GroupBox1.Controls.Add(Me.btCreateNode)
        Me.GroupBox1.Controls.Add(Me.btClear)
        Me.GroupBox1.Controls.Add(Me.btAddToArticul)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(508, 105)
        Me.GroupBox1.TabIndex = 29
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Создать артикульный дочерний узел"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(111, 48)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(30, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "RUS"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(111, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(30, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "ENG"
        '
        'tbNodeNameRUS
        '
        Me.tbNodeNameRUS.Location = New System.Drawing.Point(147, 45)
        Me.tbNodeNameRUS.Name = "tbNodeNameRUS"
        Me.tbNodeNameRUS.Size = New System.Drawing.Size(355, 20)
        Me.tbNodeNameRUS.TabIndex = 5
        '
        'lbArticul
        '
        Me.lbArticul.AutoSize = True
        Me.lbArticul.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lbArticul.Location = New System.Drawing.Point(18, 25)
        Me.lbArticul.Name = "lbArticul"
        Me.lbArticul.Size = New System.Drawing.Size(54, 13)
        Me.lbArticul.TabIndex = 4
        Me.lbArticul.Text = "артикул"
        '
        'tbNodeName
        '
        Me.tbNodeName.Location = New System.Drawing.Point(147, 19)
        Me.tbNodeName.Name = "tbNodeName"
        Me.tbNodeName.Size = New System.Drawing.Size(355, 20)
        Me.tbNodeName.TabIndex = 3
        '
        'btCreateNode
        '
        Me.btCreateNode.Enabled = False
        Me.btCreateNode.Location = New System.Drawing.Point(7, 76)
        Me.btCreateNode.Name = "btCreateNode"
        Me.btCreateNode.Size = New System.Drawing.Size(97, 23)
        Me.btCreateNode.TabIndex = 2
        Me.btCreateNode.Text = "Создать узел.."
        Me.btCreateNode.UseVisualStyleBackColor = True
        '
        'btClear
        '
        Me.btClear.Location = New System.Drawing.Point(147, 76)
        Me.btClear.Name = "btClear"
        Me.btClear.Size = New System.Drawing.Size(75, 23)
        Me.btClear.TabIndex = 1
        Me.btClear.Text = "Очистить"
        Me.btClear.UseVisualStyleBackColor = True
        '
        'btAddToArticul
        '
        Me.btAddToArticul.Location = New System.Drawing.Point(283, 76)
        Me.btAddToArticul.Name = "btAddToArticul"
        Me.btAddToArticul.Size = New System.Drawing.Size(177, 23)
        Me.btAddToArticul.TabIndex = 0
        Me.btAddToArticul.Text = "<<Добавить узел к артикулу"
        Me.btAddToArticul.UseVisualStyleBackColor = True
        '
        'lbArticulThis
        '
        Me.lbArticulThis.AutoSize = True
        Me.lbArticulThis.Location = New System.Drawing.Point(149, 122)
        Me.lbArticulThis.Name = "lbArticulThis"
        Me.lbArticulThis.Size = New System.Drawing.Size(47, 13)
        Me.lbArticulThis.TabIndex = 30
        Me.lbArticulThis.Text = "артикул"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 122)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(125, 13)
        Me.Label2.TabIndex = 31
        Me.Label2.Text = "Артикул текущего узла"
        '
        'btCreateArticul
        '
        Me.btCreateArticul.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btCreateArticul.Location = New System.Drawing.Point(12, 145)
        Me.btCreateArticul.Name = "btCreateArticul"
        Me.btCreateArticul.Size = New System.Drawing.Size(109, 23)
        Me.btCreateArticul.TabIndex = 35
        Me.btCreateArticul.Text = "Создать артикул"
        Me.btCreateArticul.UseVisualStyleBackColor = True
        '
        'btDelArticul
        '
        Me.btDelArticul.Location = New System.Drawing.Point(132, 145)
        Me.btDelArticul.Name = "btDelArticul"
        Me.btDelArticul.Size = New System.Drawing.Size(75, 23)
        Me.btDelArticul.TabIndex = 34
        Me.btDelArticul.Text = "Удалить"
        Me.btDelArticul.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(127, 177)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(67, 17)
        Me.RadioButton2.TabIndex = 37
        Me.RadioButton2.Text = "Русский"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Location = New System.Drawing.Point(36, 177)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(85, 17)
        Me.RadioButton1.TabIndex = 36
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Английский"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'btCopyName
        '
        Me.btCopyName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btCopyName.Location = New System.Drawing.Point(122, 319)
        Me.btCopyName.Name = "btCopyName"
        Me.btCopyName.Size = New System.Drawing.Size(75, 23)
        Me.btCopyName.TabIndex = 38
        Me.btCopyName.Text = "Копир. имя"
        Me.btCopyName.UseVisualStyleBackColor = True
        '
        'btCopyNodeValue
        '
        Me.btCopyNodeValue.AutoSize = True
        Me.btCopyNodeValue.Location = New System.Drawing.Point(7, 319)
        Me.btCopyNodeValue.Name = "btCopyNodeValue"
        Me.btCopyNodeValue.Size = New System.Drawing.Size(101, 23)
        Me.btCopyNodeValue.TabIndex = 39
        Me.btCopyNodeValue.Text = "Копир. значение"
        Me.btCopyNodeValue.UseVisualStyleBackColor = True
        '
        'fmLinks
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(525, 561)
        Me.Controls.Add(Me.btCopyNodeValue)
        Me.Controls.Add(Me.btCopyName)
        Me.Controls.Add(Me.RadioButton2)
        Me.Controls.Add(Me.RadioButton1)
        Me.Controls.Add(Me.btCreateArticul)
        Me.Controls.Add(Me.btDelArticul)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lbArticulThis)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cbxShowLeaf)
        Me.Controls.Add(Me.TreeView1)
        Me.Controls.Add(Me.btAcceptMUI)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.NumericUpDown1)
        Me.Controls.Add(Me.tbDescription)
        Me.Controls.Add(Me.btClose)
        Me.Controls.Add(Me.btAccept)
        Me.Controls.Add(Me.lbLinks)
        Me.Name = "fmLinks"
        Me.Text = "Просмотр связей"
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbLinks As System.Windows.Forms.ListBox
    Friend WithEvents btAccept As System.Windows.Forms.Button
    Friend WithEvents btClose As System.Windows.Forms.Button
    Friend WithEvents tbDescription As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents NumericUpDown1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents btAcceptMUI As System.Windows.Forms.Button
    Friend WithEvents TreeView1 As System.Windows.Forms.TreeView
    Friend WithEvents cbxShowLeaf As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tbNodeNameRUS As System.Windows.Forms.TextBox
    Friend WithEvents lbArticul As System.Windows.Forms.Label
    Friend WithEvents tbNodeName As System.Windows.Forms.TextBox
    Friend WithEvents btCreateNode As System.Windows.Forms.Button
    Friend WithEvents btClear As System.Windows.Forms.Button
    Friend WithEvents btAddToArticul As System.Windows.Forms.Button
    Friend WithEvents lbArticulThis As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btCreateArticul As System.Windows.Forms.Button
    Friend WithEvents btDelArticul As System.Windows.Forms.Button
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents btCopyName As System.Windows.Forms.Button
    Friend WithEvents btCopyNodeValue As System.Windows.Forms.Button
End Class
