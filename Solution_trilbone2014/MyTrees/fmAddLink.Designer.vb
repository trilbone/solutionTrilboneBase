<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Friend Class fmAddLink
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
        Me.components = New System.ComponentModel.Container()
        Me.lbIncomingNode = New System.Windows.Forms.Label()
        Me.lbTrees = New System.Windows.Forms.ListBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.lbSelectedNode = New System.Windows.Forms.Label()
        Me.btCreateLink = New System.Windows.Forms.Button()
        Me.btCreateDualLink = New System.Windows.Forms.Button()
        Me.btCancel = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ImageBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.lbLinks = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btRemoveLink = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btMakeLink = New System.Windows.Forms.Button()
        Me.cbxShowLeaf = New System.Windows.Forms.CheckBox()
        Me.btShowAll = New System.Windows.Forms.Button()
        Me.btRefreshTree = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lbArticul = New System.Windows.Forms.Label()
        Me.btDelArticul = New System.Windows.Forms.Button()
        Me.btCreateArticul = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImageBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbIncomingNode
        '
        Me.lbIncomingNode.AutoSize = True
        Me.lbIncomingNode.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lbIncomingNode.Location = New System.Drawing.Point(12, 9)
        Me.lbIncomingNode.Name = "lbIncomingNode"
        Me.lbIncomingNode.Size = New System.Drawing.Size(107, 18)
        Me.lbIncomingNode.TabIndex = 0
        Me.lbIncomingNode.Text = "Текущий узел:"
        '
        'lbTrees
        '
        Me.lbTrees.FormattingEnabled = True
        Me.lbTrees.Location = New System.Drawing.Point(15, 103)
        Me.lbTrees.Name = "lbTrees"
        Me.lbTrees.Size = New System.Drawing.Size(120, 186)
        Me.lbTrees.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 84)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Доступные деревья:"
        '
        'TreeView1
        '
        Me.TreeView1.Location = New System.Drawing.Point(158, 84)
        Me.TreeView1.Name = "TreeView1"
        Me.TreeView1.Size = New System.Drawing.Size(310, 386)
        Me.TreeView1.TabIndex = 3
        '
        'lbSelectedNode
        '
        Me.lbSelectedNode.AutoSize = True
        Me.lbSelectedNode.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lbSelectedNode.Location = New System.Drawing.Point(12, 42)
        Me.lbSelectedNode.Name = "lbSelectedNode"
        Me.lbSelectedNode.Size = New System.Drawing.Size(121, 18)
        Me.lbSelectedNode.TabIndex = 4
        Me.lbSelectedNode.Text = "Узел для связи:"
        '
        'btCreateLink
        '
        Me.btCreateLink.Enabled = False
        Me.btCreateLink.Location = New System.Drawing.Point(259, 12)
        Me.btCreateLink.Name = "btCreateLink"
        Me.btCreateLink.Size = New System.Drawing.Size(124, 23)
        Me.btCreateLink.TabIndex = 5
        Me.btCreateLink.Text = "Создать исходящую.."
        Me.btCreateLink.UseVisualStyleBackColor = True
        '
        'btCreateDualLink
        '
        Me.btCreateDualLink.Enabled = False
        Me.btCreateDualLink.Location = New System.Drawing.Point(389, 12)
        Me.btCreateDualLink.Name = "btCreateDualLink"
        Me.btCreateDualLink.Size = New System.Drawing.Size(134, 23)
        Me.btCreateDualLink.TabIndex = 6
        Me.btCreateDualLink.Text = "Создать входящую.."
        Me.btCreateDualLink.UseVisualStyleBackColor = True
        '
        'btCancel
        '
        Me.btCancel.Location = New System.Drawing.Point(655, 488)
        Me.btCancel.Name = "btCancel"
        Me.btCancel.Size = New System.Drawing.Size(75, 23)
        Me.btCancel.TabIndex = 7
        Me.btCancel.Text = "Закрыть"
        Me.btCancel.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.ErrorImage = Nothing
        Me.PictureBox1.Location = New System.Drawing.Point(485, 83)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(228, 171)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 14
        Me.PictureBox1.TabStop = False
        '
        'ImageBindingSource
        '
        '
        'lbLinks
        '
        Me.lbLinks.Enabled = False
        Me.lbLinks.FormattingEnabled = True
        Me.lbLinks.Location = New System.Drawing.Point(485, 284)
        Me.lbLinks.Name = "lbLinks"
        Me.lbLinks.Size = New System.Drawing.Size(228, 186)
        Me.lbLinks.TabIndex = 16
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(485, 265)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(201, 13)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "существующие связи с этим деревом"
        '
        'btRemoveLink
        '
        Me.btRemoveLink.Location = New System.Drawing.Point(529, 12)
        Me.btRemoveLink.Name = "btRemoveLink"
        Me.btRemoveLink.Size = New System.Drawing.Size(70, 23)
        Me.btRemoveLink.TabIndex = 18
        Me.btRemoveLink.Text = "Удалить"
        Me.btRemoveLink.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btMakeLink)
        Me.GroupBox1.Controls.Add(Me.btCreateLink)
        Me.GroupBox1.Controls.Add(Me.btRemoveLink)
        Me.GroupBox1.Controls.Add(Me.btCreateDualLink)
        Me.GroupBox1.Location = New System.Drawing.Point(19, 476)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(605, 41)
        Me.GroupBox1.TabIndex = 19
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "связи"
        '
        'btMakeLink
        '
        Me.btMakeLink.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btMakeLink.Location = New System.Drawing.Point(70, 12)
        Me.btMakeLink.Name = "btMakeLink"
        Me.btMakeLink.Size = New System.Drawing.Size(117, 23)
        Me.btMakeLink.TabIndex = 19
        Me.btMakeLink.Text = "Создать связь.."
        Me.btMakeLink.UseVisualStyleBackColor = True
        '
        'cbxShowLeaf
        '
        Me.cbxShowLeaf.AutoSize = True
        Me.cbxShowLeaf.Location = New System.Drawing.Point(31, 295)
        Me.cbxShowLeaf.Name = "cbxShowLeaf"
        Me.cbxShowLeaf.Size = New System.Drawing.Size(90, 17)
        Me.cbxShowLeaf.TabIndex = 27
        Me.cbxShowLeaf.Text = "С артикулом"
        Me.cbxShowLeaf.UseVisualStyleBackColor = True
        '
        'btShowAll
        '
        Me.btShowAll.Location = New System.Drawing.Point(31, 318)
        Me.btShowAll.Name = "btShowAll"
        Me.btShowAll.Size = New System.Drawing.Size(75, 23)
        Me.btShowAll.TabIndex = 29
        Me.btShowAll.Text = "развернуть"
        Me.btShowAll.UseVisualStyleBackColor = True
        '
        'btRefreshTree
        '
        Me.btRefreshTree.AutoSize = True
        Me.btRefreshTree.Location = New System.Drawing.Point(31, 347)
        Me.btRefreshTree.Name = "btRefreshTree"
        Me.btRefreshTree.Size = New System.Drawing.Size(75, 23)
        Me.btRefreshTree.TabIndex = 28
        Me.btRefreshTree.Text = "обновить"
        Me.btRefreshTree.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(418, 10)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(125, 13)
        Me.Label3.TabIndex = 30
        Me.Label3.Text = "Артикул текущего узла"
        '
        'lbArticul
        '
        Me.lbArticul.AutoSize = True
        Me.lbArticul.Location = New System.Drawing.Point(565, 10)
        Me.lbArticul.Name = "lbArticul"
        Me.lbArticul.Size = New System.Drawing.Size(48, 13)
        Me.lbArticul.TabIndex = 31
        Me.lbArticul.Text = "Артикул"
        '
        'btDelArticul
        '
        Me.btDelArticul.Location = New System.Drawing.Point(655, 29)
        Me.btDelArticul.Name = "btDelArticul"
        Me.btDelArticul.Size = New System.Drawing.Size(75, 23)
        Me.btDelArticul.TabIndex = 32
        Me.btDelArticul.Text = "Удалить"
        Me.btDelArticul.UseVisualStyleBackColor = True
        '
        'btCreateArticul
        '
        Me.btCreateArticul.Location = New System.Drawing.Point(528, 29)
        Me.btCreateArticul.Name = "btCreateArticul"
        Me.btCreateArticul.Size = New System.Drawing.Size(114, 23)
        Me.btCreateArticul.TabIndex = 33
        Me.btCreateArticul.Text = "Создать артикул"
        Me.btCreateArticul.UseVisualStyleBackColor = True
        '
        'fmAddLink
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(742, 530)
        Me.Controls.Add(Me.btCreateArticul)
        Me.Controls.Add(Me.btDelArticul)
        Me.Controls.Add(Me.lbArticul)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btShowAll)
        Me.Controls.Add(Me.btRefreshTree)
        Me.Controls.Add(Me.cbxShowLeaf)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lbLinks)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.btCancel)
        Me.Controls.Add(Me.lbSelectedNode)
        Me.Controls.Add(Me.TreeView1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lbTrees)
        Me.Controls.Add(Me.lbIncomingNode)
        Me.Name = "fmAddLink"
        Me.Text = "Добавить связь"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImageBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbIncomingNode As System.Windows.Forms.Label
    Friend WithEvents lbTrees As System.Windows.Forms.ListBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TreeView1 As System.Windows.Forms.TreeView
    Friend WithEvents lbSelectedNode As System.Windows.Forms.Label
    Friend WithEvents btCreateLink As System.Windows.Forms.Button
    Friend WithEvents btCreateDualLink As System.Windows.Forms.Button
    Friend WithEvents btCancel As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents ImageBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents lbLinks As System.Windows.Forms.ListBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btRemoveLink As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btMakeLink As System.Windows.Forms.Button
    Friend WithEvents cbxShowLeaf As System.Windows.Forms.CheckBox
    Friend WithEvents btShowAll As System.Windows.Forms.Button
    Friend WithEvents btRefreshTree As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lbArticul As System.Windows.Forms.Label
    Friend WithEvents btDelArticul As System.Windows.Forms.Button
    Friend WithEvents btCreateArticul As System.Windows.Forms.Button
End Class
