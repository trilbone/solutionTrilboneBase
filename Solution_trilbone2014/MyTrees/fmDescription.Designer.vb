<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Friend Class fmDescription
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fmDescription))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.btSaveFile = New System.Windows.Forms.Button()
        Me.ClsHierManagerBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.btClearDescription = New System.Windows.Forms.Button()
        Me.rtbDescription = New System.Windows.Forms.RichTextBox()
        Me.btCreateTree = New System.Windows.Forms.Button()
        Me.btSaveXML = New System.Windows.Forms.Button()
        Me.cbxImageInclude = New System.Windows.Forms.CheckBox()
        Me.btReadXML = New System.Windows.Forms.Button()
        Me.btOpenFile = New System.Windows.Forms.Button()
        Me.btShowHtml = New System.Windows.Forms.Button()
        Me.btAccept = New System.Windows.Forms.Button()
        Me.btCloseFile = New System.Windows.Forms.Button()
        Me.bRenameTree = New System.Windows.Forms.Button()
        Me.btClose = New System.Windows.Forms.Button()
        Me.btOpenTree = New System.Windows.Forms.Button()
        Me.rtbDescription_parced = New System.Windows.Forms.RichTextBox()
        Me.rbEngland = New System.Windows.Forms.RadioButton()
        Me.rbRussian = New System.Windows.Forms.RadioButton()
        Me.btCorrectID = New System.Windows.Forms.Button()
        Me.btPrintLabel = New System.Windows.Forms.Button()
        Me.btClearPrintJob = New System.Windows.Forms.Button()
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbxFilterNode = New System.Windows.Forms.CheckBox()
        Me.cbFiles = New System.Windows.Forms.ComboBox()
        Me.cbxInternet = New System.Windows.Forms.CheckBox()
        CType(Me.ClsHierManagerBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Location = New System.Drawing.Point(12, 48)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1170, 565)
        Me.TabControl1.TabIndex = 0
        '
        'btSaveFile
        '
        Me.btSaveFile.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btSaveFile.Location = New System.Drawing.Point(374, 2)
        Me.btSaveFile.Name = "btSaveFile"
        Me.btSaveFile.Size = New System.Drawing.Size(94, 23)
        Me.btSaveFile.TabIndex = 17
        Me.btSaveFile.Text = "Сохранить"
        Me.btSaveFile.UseVisualStyleBackColor = True
        '
        'ClsHierManagerBindingSource
        '
        Me.ClsHierManagerBindingSource.DataSource = GetType(Trilbone.clsTreeManager)
        '
        'btClearDescription
        '
        Me.btClearDescription.Location = New System.Drawing.Point(153, 616)
        Me.btClearDescription.Name = "btClearDescription"
        Me.btClearDescription.Size = New System.Drawing.Size(92, 23)
        Me.btClearDescription.TabIndex = 22
        Me.btClearDescription.Text = "Очистить"
        Me.btClearDescription.UseVisualStyleBackColor = True
        '
        'rtbDescription
        '
        Me.rtbDescription.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ClsHierManagerBindingSource, "XMLDescriptionElement", True))
        Me.rtbDescription.Location = New System.Drawing.Point(923, 644)
        Me.rtbDescription.Name = "rtbDescription"
        Me.rtbDescription.ReadOnly = True
        Me.rtbDescription.Size = New System.Drawing.Size(172, 57)
        Me.rtbDescription.TabIndex = 21
        Me.rtbDescription.Text = ""
        '
        'btCreateTree
        '
        Me.btCreateTree.Location = New System.Drawing.Point(753, 1)
        Me.btCreateTree.Name = "btCreateTree"
        Me.btCreateTree.Size = New System.Drawing.Size(115, 23)
        Me.btCreateTree.TabIndex = 23
        Me.btCreateTree.Text = "создать дерево.."
        Me.btCreateTree.UseVisualStyleBackColor = True
        '
        'btSaveXML
        '
        Me.btSaveXML.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btSaveXML.Location = New System.Drawing.Point(481, 2)
        Me.btSaveXML.Name = "btSaveXML"
        Me.btSaveXML.Size = New System.Drawing.Size(112, 23)
        Me.btSaveXML.TabIndex = 24
        Me.btSaveXML.Text = "Сохранить XML"
        Me.btSaveXML.UseVisualStyleBackColor = True
        '
        'cbxImageInclude
        '
        Me.cbxImageInclude.AutoSize = True
        Me.cbxImageInclude.Checked = True
        Me.cbxImageInclude.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbxImageInclude.Location = New System.Drawing.Point(497, 29)
        Me.cbxImageInclude.Name = "cbxImageInclude"
        Me.cbxImageInclude.Size = New System.Drawing.Size(96, 17)
        Me.cbxImageInclude.TabIndex = 25
        Me.cbxImageInclude.Text = "с картинками"
        Me.cbxImageInclude.UseVisualStyleBackColor = True
        '
        'btReadXML
        '
        Me.btReadXML.Location = New System.Drawing.Point(874, 1)
        Me.btReadXML.Name = "btReadXML"
        Me.btReadXML.Size = New System.Drawing.Size(182, 23)
        Me.btReadXML.TabIndex = 26
        Me.btReadXML.Text = "добавить дерево из XML файла"
        Me.btReadXML.UseVisualStyleBackColor = True
        '
        'btOpenFile
        '
        Me.btOpenFile.CausesValidation = False
        Me.btOpenFile.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btOpenFile.Location = New System.Drawing.Point(67, 1)
        Me.btOpenFile.Name = "btOpenFile"
        Me.btOpenFile.Size = New System.Drawing.Size(77, 23)
        Me.btOpenFile.TabIndex = 27
        Me.btOpenFile.Text = "Открыть"
        Me.btOpenFile.UseVisualStyleBackColor = True
        '
        'btShowHtml
        '
        Me.btShowHtml.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btShowHtml.Location = New System.Drawing.Point(599, 2)
        Me.btShowHtml.Name = "btShowHtml"
        Me.btShowHtml.Size = New System.Drawing.Size(51, 23)
        Me.btShowHtml.TabIndex = 28
        Me.btShowHtml.Text = "html"
        Me.btShowHtml.UseVisualStyleBackColor = True
        '
        'btAccept
        '
        Me.btAccept.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btAccept.Location = New System.Drawing.Point(12, 616)
        Me.btAccept.Name = "btAccept"
        Me.btAccept.Size = New System.Drawing.Size(132, 23)
        Me.btAccept.TabIndex = 29
        Me.btAccept.Text = "Описание готово"
        Me.btAccept.UseVisualStyleBackColor = True
        '
        'btCloseFile
        '
        Me.btCloseFile.Location = New System.Drawing.Point(0, 1)
        Me.btCloseFile.Name = "btCloseFile"
        Me.btCloseFile.Size = New System.Drawing.Size(61, 23)
        Me.btCloseFile.TabIndex = 30
        Me.btCloseFile.Text = "Закрыть"
        Me.btCloseFile.UseVisualStyleBackColor = True
        '
        'bRenameTree
        '
        Me.bRenameTree.Enabled = False
        Me.bRenameTree.Location = New System.Drawing.Point(1062, 1)
        Me.bRenameTree.Name = "bRenameTree"
        Me.bRenameTree.Size = New System.Drawing.Size(121, 23)
        Me.bRenameTree.TabIndex = 32
        Me.bRenameTree.Text = "Переименовать.."
        Me.bRenameTree.UseVisualStyleBackColor = True
        '
        'btClose
        '
        Me.btClose.Location = New System.Drawing.Point(251, 616)
        Me.btClose.Name = "btClose"
        Me.btClose.Size = New System.Drawing.Size(130, 23)
        Me.btClose.TabIndex = 33
        Me.btClose.Text = "Закрыть окно"
        Me.btClose.UseVisualStyleBackColor = True
        '
        'btOpenTree
        '
        Me.btOpenTree.Location = New System.Drawing.Point(660, 615)
        Me.btOpenTree.Name = "btOpenTree"
        Me.btOpenTree.Size = New System.Drawing.Size(158, 23)
        Me.btOpenTree.TabIndex = 34
        Me.btOpenTree.Text = "Открыть другое дерево.."
        Me.btOpenTree.UseVisualStyleBackColor = True
        '
        'rtbDescription_parced
        '
        Me.rtbDescription_parced.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.rtbDescription_parced.Location = New System.Drawing.Point(12, 644)
        Me.rtbDescription_parced.Name = "rtbDescription_parced"
        Me.rtbDescription_parced.ReadOnly = True
        Me.rtbDescription_parced.Size = New System.Drawing.Size(882, 57)
        Me.rtbDescription_parced.TabIndex = 35
        Me.rtbDescription_parced.Text = ""
        '
        'rbEngland
        '
        Me.rbEngland.AutoSize = True
        Me.rbEngland.Checked = True
        Me.rbEngland.Location = New System.Drawing.Point(435, 615)
        Me.rbEngland.Name = "rbEngland"
        Me.rbEngland.Size = New System.Drawing.Size(85, 17)
        Me.rbEngland.TabIndex = 37
        Me.rbEngland.TabStop = True
        Me.rbEngland.Text = "Английский"
        Me.rbEngland.UseVisualStyleBackColor = True
        '
        'rbRussian
        '
        Me.rbRussian.AutoSize = True
        Me.rbRussian.Location = New System.Drawing.Point(526, 616)
        Me.rbRussian.Name = "rbRussian"
        Me.rbRussian.Size = New System.Drawing.Size(67, 17)
        Me.rbRussian.TabIndex = 38
        Me.rbRussian.Text = "Русский"
        Me.rbRussian.UseVisualStyleBackColor = True
        '
        'btCorrectID
        '
        Me.btCorrectID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btCorrectID.Location = New System.Drawing.Point(1101, 657)
        Me.btCorrectID.Name = "btCorrectID"
        Me.btCorrectID.Size = New System.Drawing.Size(75, 23)
        Me.btCorrectID.TabIndex = 39
        Me.btCorrectID.Text = "Correct ID"
        Me.btCorrectID.UseVisualStyleBackColor = True
        '
        'btPrintLabel
        '
        Me.btPrintLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btPrintLabel.Location = New System.Drawing.Point(860, 615)
        Me.btPrintLabel.Name = "btPrintLabel"
        Me.btPrintLabel.Size = New System.Drawing.Size(179, 23)
        Me.btPrintLabel.TabIndex = 41
        Me.btPrintLabel.Text = "Печать этикеток"
        Me.btPrintLabel.UseVisualStyleBackColor = True
        '
        'btClearPrintJob
        '
        Me.btClearPrintJob.Location = New System.Drawing.Point(1056, 615)
        Me.btClearPrintJob.Name = "btClearPrintJob"
        Me.btClearPrintJob.Size = New System.Drawing.Size(120, 23)
        Me.btClearPrintJob.TabIndex = 42
        Me.btClearPrintJob.Text = "Очистить очередь"
        Me.btClearPrintJob.UseVisualStyleBackColor = True
        '
        'PrintPreviewDialog1
        '
        Me.PrintPreviewDialog1.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.ClientSize = New System.Drawing.Size(400, 300)
        Me.PrintPreviewDialog1.Enabled = True
        Me.PrintPreviewDialog1.Icon = CType(resources.GetObject("PrintPreviewDialog1.Icon"), System.Drawing.Icon)
        Me.PrintPreviewDialog1.Name = "PrintPreviewDialog1"
        Me.PrintPreviewDialog1.Visible = False
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(1104, 640)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 13)
        Me.Label3.TabIndex = 43
        Me.Label3.Text = "служебная"
        '
        'cbxFilterNode
        '
        Me.cbxFilterNode.AutoSize = True
        Me.cbxFilterNode.Location = New System.Drawing.Point(16, 31)
        Me.cbxFilterNode.Name = "cbxFilterNode"
        Me.cbxFilterNode.Size = New System.Drawing.Size(63, 17)
        Me.cbxFilterNode.TabIndex = 44
        Me.cbxFilterNode.Text = "фильтр"
        Me.cbxFilterNode.UseVisualStyleBackColor = True
        '
        'cbFiles
        '
        Me.cbFiles.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.cbFiles.FormattingEnabled = True
        Me.cbFiles.Location = New System.Drawing.Point(190, 2)
        Me.cbFiles.Name = "cbFiles"
        Me.cbFiles.Size = New System.Drawing.Size(178, 24)
        Me.cbFiles.TabIndex = 46
        '
        'cbxInternet
        '
        Me.cbxInternet.AutoSize = True
        Me.cbxInternet.Location = New System.Drawing.Point(657, 6)
        Me.cbxInternet.Name = "cbxInternet"
        Me.cbxInternet.Size = New System.Drawing.Size(61, 17)
        Me.cbxInternet.TabIndex = 47
        Me.cbxInternet.Text = "internet"
        Me.cbxInternet.UseVisualStyleBackColor = True
        '
        'fmDescription
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1188, 704)
        Me.Controls.Add(Me.cbxInternet)
        Me.Controls.Add(Me.cbFiles)
        Me.Controls.Add(Me.cbxFilterNode)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btClearPrintJob)
        Me.Controls.Add(Me.btPrintLabel)
        Me.Controls.Add(Me.btCorrectID)
        Me.Controls.Add(Me.rbRussian)
        Me.Controls.Add(Me.rbEngland)
        Me.Controls.Add(Me.rtbDescription_parced)
        Me.Controls.Add(Me.btOpenTree)
        Me.Controls.Add(Me.btClose)
        Me.Controls.Add(Me.bRenameTree)
        Me.Controls.Add(Me.btCloseFile)
        Me.Controls.Add(Me.btAccept)
        Me.Controls.Add(Me.btShowHtml)
        Me.Controls.Add(Me.btOpenFile)
        Me.Controls.Add(Me.btReadXML)
        Me.Controls.Add(Me.cbxImageInclude)
        Me.Controls.Add(Me.btSaveXML)
        Me.Controls.Add(Me.btCreateTree)
        Me.Controls.Add(Me.btClearDescription)
        Me.Controls.Add(Me.rtbDescription)
        Me.Controls.Add(Me.btSaveFile)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "fmDescription"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Описание 2.5"
        CType(Me.ClsHierManagerBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    <NonSerializedAttribute> _
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl

    <NonSerializedAttribute> _
    Friend WithEvents btSaveFile As System.Windows.Forms.Button


    <NonSerializedAttribute> _
    Friend WithEvents btClearDescription As System.Windows.Forms.Button
    <NonSerializedAttribute> _
    Friend WithEvents rtbDescription As System.Windows.Forms.RichTextBox
    <NonSerializedAttribute> _
    Friend WithEvents ClsHierManagerBindingSource As System.Windows.Forms.BindingSource
    <NonSerializedAttribute> _
    Friend WithEvents btCreateTree As System.Windows.Forms.Button
    <NonSerializedAttribute> _
    Friend WithEvents btSaveXML As System.Windows.Forms.Button
    <NonSerializedAttribute> _
    Friend WithEvents cbxImageInclude As System.Windows.Forms.CheckBox
    <NonSerializedAttribute> _
    Friend WithEvents btReadXML As System.Windows.Forms.Button
    <NonSerializedAttribute> _
    Friend WithEvents btOpenFile As System.Windows.Forms.Button
    <NonSerializedAttribute> _
    Friend WithEvents btShowHtml As System.Windows.Forms.Button
    <NonSerializedAttribute> _
    Friend WithEvents btAccept As System.Windows.Forms.Button
    <NonSerializedAttribute> _
    Friend WithEvents btCloseFile As System.Windows.Forms.Button
    <NonSerializedAttribute> _
    Friend WithEvents bRenameTree As System.Windows.Forms.Button
    <NonSerializedAttribute> _
    Friend WithEvents btClose As System.Windows.Forms.Button
    <NonSerializedAttribute> _
    Friend WithEvents btOpenTree As System.Windows.Forms.Button
    <NonSerializedAttribute> _
    Friend WithEvents rtbDescription_parced As System.Windows.Forms.RichTextBox
    <NonSerializedAttribute> _
    Friend WithEvents rbEngland As System.Windows.Forms.RadioButton
    <NonSerializedAttribute> _
    Friend WithEvents rbRussian As System.Windows.Forms.RadioButton
    <NonSerializedAttribute> _
    Friend WithEvents btCorrectID As System.Windows.Forms.Button
    <NonSerializedAttribute> _
    Friend WithEvents btPrintLabel As System.Windows.Forms.Button
    <NonSerializedAttribute> _
    Friend WithEvents btClearPrintJob As System.Windows.Forms.Button
    <NonSerializedAttribute> _
    Friend WithEvents PrintPreviewDialog1 As System.Windows.Forms.PrintPreviewDialog
    <NonSerializedAttribute> _
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    <NonSerializedAttribute> _
    Friend WithEvents Label3 As System.Windows.Forms.Label
    <NonSerializedAttribute> _
    Friend WithEvents cbxFilterNode As System.Windows.Forms.CheckBox


    Private Sub fmDescription_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        If oManager Is Nothing Then Me.rtbDescription_parced.Text = "" : Return
        If oManager.XMLDescriptionElement Is Nothing Then Me.rtbDescription_parced.Text = "" : Return
    End Sub
    Friend WithEvents cbFiles As System.Windows.Forms.ComboBox
    Friend WithEvents cbxInternet As System.Windows.Forms.CheckBox

    'Private Sub fmDescription_Deactivate(sender As Object, e As EventArgs) Handles Me.Deactivate
    '    Me.rtbDescription_parced.Text = ""
    '    If oManager Is Nothing Then Return
    '    oManager.ClearDescription()
    'End Sub
End Class
