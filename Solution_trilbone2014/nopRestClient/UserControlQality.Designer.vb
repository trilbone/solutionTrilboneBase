<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserControlQality
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.rtbConditionDescription = New System.Windows.Forms.RichTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbcItemSpecifics = New System.Windows.Forms.TabControl()
        Me.tpPrep = New System.Windows.Forms.TabPage()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.rbPrep_below = New System.Windows.Forms.RadioButton()
        Me.rbPrep_normal = New System.Windows.Forms.RadioButton()
        Me.rbPrep_good = New System.Windows.Forms.RadioButton()
        Me.rbPrep_nice = New System.Windows.Forms.RadioButton()
        Me.rbPrep_no = New System.Windows.Forms.RadioButton()
        Me.tpPreserv = New System.Windows.Forms.TabPage()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.rbPreserv_below = New System.Windows.Forms.RadioButton()
        Me.rbPreserv_normal = New System.Windows.Forms.RadioButton()
        Me.rbPreserv_good = New System.Windows.Forms.RadioButton()
        Me.rbPreserv_nice = New System.Windows.Forms.RadioButton()
        Me.tpReconstr = New System.Windows.Forms.TabPage()
        Me.RadioButton3 = New System.Windows.Forms.RadioButton()
        Me.rbReconstr_15 = New System.Windows.Forms.RadioButton()
        Me.rbReconstr_10 = New System.Windows.Forms.RadioButton()
        Me.rbReconstr_5 = New System.Windows.Forms.RadioButton()
        Me.rbReconstr_3 = New System.Windows.Forms.RadioButton()
        Me.rbReconstr_no = New System.Windows.Forms.RadioButton()
        Me.tpMatrix = New System.Windows.Forms.TabPage()
        Me.RadioButton4 = New System.Windows.Forms.RadioButton()
        Me.rbMatrix_removed = New System.Windows.Forms.RadioButton()
        Me.rbMatrix_crack = New System.Windows.Forms.RadioButton()
        Me.rbMatrix_no = New System.Windows.Forms.RadioButton()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.btAccept = New System.Windows.Forms.Button()
        Me.btClearCondition = New System.Windows.Forms.Button()
        Me.rbEnglish = New System.Windows.Forms.RadioButton()
        Me.rbRussian = New System.Windows.Forms.RadioButton()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.tbcItemSpecifics.SuspendLayout()
        Me.tpPrep.SuspendLayout()
        Me.tpPreserv.SuspendLayout()
        Me.tpReconstr.SuspendLayout()
        Me.tpMatrix.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.Controls.Add(Me.rtbConditionDescription, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.tbcItemSpecifics, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.FlowLayoutPanel1, 0, 3)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.363636!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48.18182!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 32.41107!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.43874!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(406, 253)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'rtbConditionDescription
        '
        Me.rtbConditionDescription.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rtbConditionDescription.Location = New System.Drawing.Point(3, 140)
        Me.rtbConditionDescription.Name = "rtbConditionDescription"
        Me.rtbConditionDescription.Size = New System.Drawing.Size(400, 75)
        Me.rtbConditionDescription.TabIndex = 24
        Me.rtbConditionDescription.Text = ""
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(400, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Condition description 1000 символов максимум. Только состояние обьекта!!!"
        '
        'tbcItemSpecifics
        '
        Me.tbcItemSpecifics.Controls.Add(Me.tpPrep)
        Me.tbcItemSpecifics.Controls.Add(Me.tpPreserv)
        Me.tbcItemSpecifics.Controls.Add(Me.tpReconstr)
        Me.tbcItemSpecifics.Controls.Add(Me.tpMatrix)
        Me.tbcItemSpecifics.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbcItemSpecifics.Location = New System.Drawing.Point(3, 19)
        Me.tbcItemSpecifics.Name = "tbcItemSpecifics"
        Me.tbcItemSpecifics.SelectedIndex = 0
        Me.tbcItemSpecifics.Size = New System.Drawing.Size(400, 115)
        Me.tbcItemSpecifics.TabIndex = 21
        '
        'tpPrep
        '
        Me.tpPrep.Controls.Add(Me.RadioButton1)
        Me.tpPrep.Controls.Add(Me.rbPrep_below)
        Me.tpPrep.Controls.Add(Me.rbPrep_normal)
        Me.tpPrep.Controls.Add(Me.rbPrep_good)
        Me.tpPrep.Controls.Add(Me.rbPrep_nice)
        Me.tpPrep.Controls.Add(Me.rbPrep_no)
        Me.tpPrep.Location = New System.Drawing.Point(4, 22)
        Me.tpPrep.Name = "tpPrep"
        Me.tpPrep.Padding = New System.Windows.Forms.Padding(3)
        Me.tpPrep.Size = New System.Drawing.Size(392, 89)
        Me.tpPrep.TabIndex = 0
        Me.tpPrep.Text = "Preparation quality"
        Me.tpPrep.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.RadioButton1.Location = New System.Drawing.Point(108, 53)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(85, 17)
        Me.RadioButton1.TabIndex = 5
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "не задано"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'rbPrep_below
        '
        Me.rbPrep_below.AutoSize = True
        Me.rbPrep_below.Location = New System.Drawing.Point(108, 30)
        Me.rbPrep_below.Name = "rbPrep_below"
        Me.rbPrep_below.Size = New System.Drawing.Size(95, 17)
        Me.rbPrep_below.TabIndex = 4
        Me.rbPrep_below.TabStop = True
        Me.rbPrep_below.Text = "below average"
        Me.rbPrep_below.UseVisualStyleBackColor = True
        '
        'rbPrep_normal
        '
        Me.rbPrep_normal.AutoSize = True
        Me.rbPrep_normal.Location = New System.Drawing.Point(108, 7)
        Me.rbPrep_normal.Name = "rbPrep_normal"
        Me.rbPrep_normal.Size = New System.Drawing.Size(56, 17)
        Me.rbPrep_normal.TabIndex = 3
        Me.rbPrep_normal.TabStop = True
        Me.rbPrep_normal.Text = "normal"
        Me.rbPrep_normal.UseVisualStyleBackColor = True
        '
        'rbPrep_good
        '
        Me.rbPrep_good.AutoSize = True
        Me.rbPrep_good.Location = New System.Drawing.Point(6, 51)
        Me.rbPrep_good.Name = "rbPrep_good"
        Me.rbPrep_good.Size = New System.Drawing.Size(49, 17)
        Me.rbPrep_good.TabIndex = 2
        Me.rbPrep_good.TabStop = True
        Me.rbPrep_good.Text = "good"
        Me.rbPrep_good.UseVisualStyleBackColor = True
        '
        'rbPrep_nice
        '
        Me.rbPrep_nice.AutoSize = True
        Me.rbPrep_nice.Location = New System.Drawing.Point(6, 29)
        Me.rbPrep_nice.Name = "rbPrep_nice"
        Me.rbPrep_nice.Size = New System.Drawing.Size(45, 17)
        Me.rbPrep_nice.TabIndex = 1
        Me.rbPrep_nice.TabStop = True
        Me.rbPrep_nice.Text = "nice"
        Me.rbPrep_nice.UseVisualStyleBackColor = True
        '
        'rbPrep_no
        '
        Me.rbPrep_no.AutoSize = True
        Me.rbPrep_no.Location = New System.Drawing.Point(6, 6)
        Me.rbPrep_no.Name = "rbPrep_no"
        Me.rbPrep_no.Size = New System.Drawing.Size(93, 17)
        Me.rbPrep_no.TabIndex = 0
        Me.rbPrep_no.TabStop = True
        Me.rbPrep_no.Text = "no preparation"
        Me.rbPrep_no.UseVisualStyleBackColor = True
        '
        'tpPreserv
        '
        Me.tpPreserv.Controls.Add(Me.RadioButton2)
        Me.tpPreserv.Controls.Add(Me.rbPreserv_below)
        Me.tpPreserv.Controls.Add(Me.rbPreserv_normal)
        Me.tpPreserv.Controls.Add(Me.rbPreserv_good)
        Me.tpPreserv.Controls.Add(Me.rbPreserv_nice)
        Me.tpPreserv.Location = New System.Drawing.Point(4, 22)
        Me.tpPreserv.Name = "tpPreserv"
        Me.tpPreserv.Padding = New System.Windows.Forms.Padding(3)
        Me.tpPreserv.Size = New System.Drawing.Size(392, 89)
        Me.tpPreserv.TabIndex = 1
        Me.tpPreserv.Text = "Preservation"
        Me.tpPreserv.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.RadioButton2.Location = New System.Drawing.Point(74, 54)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(85, 17)
        Me.RadioButton2.TabIndex = 6
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Text = "не задано"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'rbPreserv_below
        '
        Me.rbPreserv_below.AutoSize = True
        Me.rbPreserv_below.Location = New System.Drawing.Point(74, 31)
        Me.rbPreserv_below.Name = "rbPreserv_below"
        Me.rbPreserv_below.Size = New System.Drawing.Size(95, 17)
        Me.rbPreserv_below.TabIndex = 3
        Me.rbPreserv_below.TabStop = True
        Me.rbPreserv_below.Text = "below average"
        Me.rbPreserv_below.UseVisualStyleBackColor = True
        '
        'rbPreserv_normal
        '
        Me.rbPreserv_normal.AutoSize = True
        Me.rbPreserv_normal.Location = New System.Drawing.Point(74, 8)
        Me.rbPreserv_normal.Name = "rbPreserv_normal"
        Me.rbPreserv_normal.Size = New System.Drawing.Size(56, 17)
        Me.rbPreserv_normal.TabIndex = 2
        Me.rbPreserv_normal.TabStop = True
        Me.rbPreserv_normal.Text = "normal"
        Me.rbPreserv_normal.UseVisualStyleBackColor = True
        '
        'rbPreserv_good
        '
        Me.rbPreserv_good.AutoSize = True
        Me.rbPreserv_good.Location = New System.Drawing.Point(6, 31)
        Me.rbPreserv_good.Name = "rbPreserv_good"
        Me.rbPreserv_good.Size = New System.Drawing.Size(49, 17)
        Me.rbPreserv_good.TabIndex = 1
        Me.rbPreserv_good.TabStop = True
        Me.rbPreserv_good.Text = "good"
        Me.rbPreserv_good.UseVisualStyleBackColor = True
        '
        'rbPreserv_nice
        '
        Me.rbPreserv_nice.AutoSize = True
        Me.rbPreserv_nice.Location = New System.Drawing.Point(7, 8)
        Me.rbPreserv_nice.Name = "rbPreserv_nice"
        Me.rbPreserv_nice.Size = New System.Drawing.Size(45, 17)
        Me.rbPreserv_nice.TabIndex = 0
        Me.rbPreserv_nice.TabStop = True
        Me.rbPreserv_nice.Text = "nice"
        Me.rbPreserv_nice.UseVisualStyleBackColor = True
        '
        'tpReconstr
        '
        Me.tpReconstr.Controls.Add(Me.RadioButton3)
        Me.tpReconstr.Controls.Add(Me.rbReconstr_15)
        Me.tpReconstr.Controls.Add(Me.rbReconstr_10)
        Me.tpReconstr.Controls.Add(Me.rbReconstr_5)
        Me.tpReconstr.Controls.Add(Me.rbReconstr_3)
        Me.tpReconstr.Controls.Add(Me.rbReconstr_no)
        Me.tpReconstr.Location = New System.Drawing.Point(4, 22)
        Me.tpReconstr.Name = "tpReconstr"
        Me.tpReconstr.Padding = New System.Windows.Forms.Padding(3)
        Me.tpReconstr.Size = New System.Drawing.Size(392, 89)
        Me.tpReconstr.TabIndex = 2
        Me.tpReconstr.Text = "Reconstruction"
        Me.tpReconstr.UseVisualStyleBackColor = True
        '
        'RadioButton3
        '
        Me.RadioButton3.AutoSize = True
        Me.RadioButton3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.RadioButton3.Location = New System.Drawing.Point(139, 55)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(85, 17)
        Me.RadioButton3.TabIndex = 6
        Me.RadioButton3.TabStop = True
        Me.RadioButton3.Text = "не задано"
        Me.RadioButton3.UseVisualStyleBackColor = True
        '
        'rbReconstr_15
        '
        Me.rbReconstr_15.AutoSize = True
        Me.rbReconstr_15.Location = New System.Drawing.Point(139, 32)
        Me.rbReconstr_15.Name = "rbReconstr_15"
        Me.rbReconstr_15.Size = New System.Drawing.Size(90, 17)
        Me.rbReconstr_15.TabIndex = 4
        Me.rbReconstr_15.TabStop = True
        Me.rbReconstr_15.Text = "less then 15%"
        Me.rbReconstr_15.UseVisualStyleBackColor = True
        '
        'rbReconstr_10
        '
        Me.rbReconstr_10.AutoSize = True
        Me.rbReconstr_10.Location = New System.Drawing.Point(139, 9)
        Me.rbReconstr_10.Name = "rbReconstr_10"
        Me.rbReconstr_10.Size = New System.Drawing.Size(90, 17)
        Me.rbReconstr_10.TabIndex = 3
        Me.rbReconstr_10.TabStop = True
        Me.rbReconstr_10.Text = "less then 10%"
        Me.rbReconstr_10.UseVisualStyleBackColor = True
        '
        'rbReconstr_5
        '
        Me.rbReconstr_5.AutoSize = True
        Me.rbReconstr_5.Location = New System.Drawing.Point(6, 52)
        Me.rbReconstr_5.Name = "rbReconstr_5"
        Me.rbReconstr_5.Size = New System.Drawing.Size(84, 17)
        Me.rbReconstr_5.TabIndex = 2
        Me.rbReconstr_5.TabStop = True
        Me.rbReconstr_5.Text = "less then 5%"
        Me.rbReconstr_5.UseVisualStyleBackColor = True
        '
        'rbReconstr_3
        '
        Me.rbReconstr_3.AutoSize = True
        Me.rbReconstr_3.Location = New System.Drawing.Point(6, 29)
        Me.rbReconstr_3.Name = "rbReconstr_3"
        Me.rbReconstr_3.Size = New System.Drawing.Size(84, 17)
        Me.rbReconstr_3.TabIndex = 1
        Me.rbReconstr_3.TabStop = True
        Me.rbReconstr_3.Text = "less then 3%"
        Me.rbReconstr_3.UseVisualStyleBackColor = True
        '
        'rbReconstr_no
        '
        Me.rbReconstr_no.AutoSize = True
        Me.rbReconstr_no.Location = New System.Drawing.Point(6, 6)
        Me.rbReconstr_no.Name = "rbReconstr_no"
        Me.rbReconstr_no.Size = New System.Drawing.Size(107, 17)
        Me.rbReconstr_no.TabIndex = 0
        Me.rbReconstr_no.TabStop = True
        Me.rbReconstr_no.Text = "no reconstruction"
        Me.rbReconstr_no.UseVisualStyleBackColor = True
        '
        'tpMatrix
        '
        Me.tpMatrix.Controls.Add(Me.RadioButton4)
        Me.tpMatrix.Controls.Add(Me.rbMatrix_removed)
        Me.tpMatrix.Controls.Add(Me.rbMatrix_crack)
        Me.tpMatrix.Controls.Add(Me.rbMatrix_no)
        Me.tpMatrix.Location = New System.Drawing.Point(4, 22)
        Me.tpMatrix.Name = "tpMatrix"
        Me.tpMatrix.Padding = New System.Windows.Forms.Padding(3)
        Me.tpMatrix.Size = New System.Drawing.Size(392, 89)
        Me.tpMatrix.TabIndex = 3
        Me.tpMatrix.Text = "Matrix reconstruction"
        Me.tpMatrix.UseVisualStyleBackColor = True
        '
        'RadioButton4
        '
        Me.RadioButton4.AutoSize = True
        Me.RadioButton4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.RadioButton4.Location = New System.Drawing.Point(205, 32)
        Me.RadioButton4.Name = "RadioButton4"
        Me.RadioButton4.Size = New System.Drawing.Size(85, 17)
        Me.RadioButton4.TabIndex = 7
        Me.RadioButton4.TabStop = True
        Me.RadioButton4.Text = "не задано"
        Me.RadioButton4.UseVisualStyleBackColor = True
        '
        'rbMatrix_removed
        '
        Me.rbMatrix_removed.AutoSize = True
        Me.rbMatrix_removed.Location = New System.Drawing.Point(205, 9)
        Me.rbMatrix_removed.Name = "rbMatrix_removed"
        Me.rbMatrix_removed.Size = New System.Drawing.Size(138, 17)
        Me.rbMatrix_removed.TabIndex = 4
        Me.rbMatrix_removed.TabStop = True
        Me.rbMatrix_removed.Text = "removed on other matrix"
        Me.rbMatrix_removed.UseVisualStyleBackColor = True
        '
        'rbMatrix_crack
        '
        Me.rbMatrix_crack.AutoSize = True
        Me.rbMatrix_crack.Location = New System.Drawing.Point(6, 32)
        Me.rbMatrix_crack.Name = "rbMatrix_crack"
        Me.rbMatrix_crack.Size = New System.Drawing.Size(152, 17)
        Me.rbMatrix_crack.TabIndex = 3
        Me.rbMatrix_crack.TabStop = True
        Me.rbMatrix_crack.Text = "some crack (original matrix)"
        Me.rbMatrix_crack.UseVisualStyleBackColor = True
        '
        'rbMatrix_no
        '
        Me.rbMatrix_no.AutoSize = True
        Me.rbMatrix_no.Location = New System.Drawing.Point(6, 9)
        Me.rbMatrix_no.Name = "rbMatrix_no"
        Me.rbMatrix_no.Size = New System.Drawing.Size(179, 17)
        Me.rbMatrix_no.TabIndex = 0
        Me.rbMatrix_no.TabStop = True
        Me.rbMatrix_no.Text = "no reconstruction (original matrix)"
        Me.rbMatrix_no.UseVisualStyleBackColor = True
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.btAccept)
        Me.FlowLayoutPanel1.Controls.Add(Me.btClearCondition)
        Me.FlowLayoutPanel1.Controls.Add(Me.rbEnglish)
        Me.FlowLayoutPanel1.Controls.Add(Me.rbRussian)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(3, 221)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(400, 29)
        Me.FlowLayoutPanel1.TabIndex = 25
        '
        'btAccept
        '
        Me.btAccept.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btAccept.Location = New System.Drawing.Point(3, 3)
        Me.btAccept.Name = "btAccept"
        Me.btAccept.Size = New System.Drawing.Size(119, 21)
        Me.btAccept.TabIndex = 10
        Me.btAccept.Text = "Принять"
        Me.btAccept.UseVisualStyleBackColor = True
        '
        'btClearCondition
        '
        Me.btClearCondition.Location = New System.Drawing.Point(128, 3)
        Me.btClearCondition.Name = "btClearCondition"
        Me.btClearCondition.Size = New System.Drawing.Size(119, 21)
        Me.btClearCondition.TabIndex = 7
        Me.btClearCondition.Text = "Очистить"
        Me.btClearCondition.UseVisualStyleBackColor = True
        '
        'rbEnglish
        '
        Me.rbEnglish.AutoSize = True
        Me.rbEnglish.Checked = True
        Me.rbEnglish.Location = New System.Drawing.Point(253, 3)
        Me.rbEnglish.Name = "rbEnglish"
        Me.rbEnglish.Size = New System.Drawing.Size(59, 17)
        Me.rbEnglish.TabIndex = 8
        Me.rbEnglish.TabStop = True
        Me.rbEnglish.Text = "English"
        Me.rbEnglish.UseVisualStyleBackColor = True
        '
        'rbRussian
        '
        Me.rbRussian.AutoSize = True
        Me.rbRussian.Location = New System.Drawing.Point(318, 3)
        Me.rbRussian.Name = "rbRussian"
        Me.rbRussian.Size = New System.Drawing.Size(67, 17)
        Me.rbRussian.TabIndex = 9
        Me.rbRussian.Text = "Русский"
        Me.rbRussian.UseVisualStyleBackColor = True
        '
        'UserControlQality
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "UserControlQality"
        Me.Size = New System.Drawing.Size(406, 253)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.tbcItemSpecifics.ResumeLayout(False)
        Me.tpPrep.ResumeLayout(False)
        Me.tpPrep.PerformLayout()
        Me.tpPreserv.ResumeLayout(False)
        Me.tpPreserv.PerformLayout()
        Me.tpReconstr.ResumeLayout(False)
        Me.tpReconstr.PerformLayout()
        Me.tpMatrix.ResumeLayout(False)
        Me.tpMatrix.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tbcItemSpecifics As System.Windows.Forms.TabControl
    Friend WithEvents tpPrep As System.Windows.Forms.TabPage
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents rbPrep_below As System.Windows.Forms.RadioButton
    Friend WithEvents rbPrep_normal As System.Windows.Forms.RadioButton
    Friend WithEvents rbPrep_good As System.Windows.Forms.RadioButton
    Friend WithEvents rbPrep_nice As System.Windows.Forms.RadioButton
    Friend WithEvents rbPrep_no As System.Windows.Forms.RadioButton
    Friend WithEvents tpPreserv As System.Windows.Forms.TabPage
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents rbPreserv_below As System.Windows.Forms.RadioButton
    Friend WithEvents rbPreserv_normal As System.Windows.Forms.RadioButton
    Friend WithEvents rbPreserv_good As System.Windows.Forms.RadioButton
    Friend WithEvents rbPreserv_nice As System.Windows.Forms.RadioButton
    Friend WithEvents tpReconstr As System.Windows.Forms.TabPage
    Friend WithEvents RadioButton3 As System.Windows.Forms.RadioButton
    Friend WithEvents rbReconstr_15 As System.Windows.Forms.RadioButton
    Friend WithEvents rbReconstr_10 As System.Windows.Forms.RadioButton
    Friend WithEvents rbReconstr_5 As System.Windows.Forms.RadioButton
    Friend WithEvents rbReconstr_3 As System.Windows.Forms.RadioButton
    Friend WithEvents rbReconstr_no As System.Windows.Forms.RadioButton
    Friend WithEvents tpMatrix As System.Windows.Forms.TabPage
    Friend WithEvents RadioButton4 As System.Windows.Forms.RadioButton
    Friend WithEvents rbMatrix_removed As System.Windows.Forms.RadioButton
    Friend WithEvents rbMatrix_crack As System.Windows.Forms.RadioButton
    Friend WithEvents rbMatrix_no As System.Windows.Forms.RadioButton
    Friend WithEvents rtbConditionDescription As System.Windows.Forms.RichTextBox
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btClearCondition As System.Windows.Forms.Button
    Friend WithEvents rbEnglish As System.Windows.Forms.RadioButton
    Friend WithEvents rbRussian As System.Windows.Forms.RadioButton
    Friend WithEvents btAccept As System.Windows.Forms.Button

End Class
