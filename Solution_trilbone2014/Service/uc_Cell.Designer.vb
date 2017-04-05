<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class uc_Cell
    Inherits System.Windows.Forms.UserControl

    'Пользовательский элемент управления (UserControl) переопределяет метод Dispose для очистки списка компонентов.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.lbxSampleList = New System.Windows.Forms.ListBox()
        Me.tbSampleNumber = New System.Windows.Forms.TextBox()
        Me.btAddNumber = New System.Windows.Forms.Button()
        Me.btMoveTo = New System.Windows.Forms.Button()
        Me.btPlaceToCell = New System.Windows.Forms.Button()
        Me.btCreateDemand = New System.Windows.Forms.Button()
        Me.cbTargetCell = New System.Windows.Forms.ComboBox()
        Me.cbWarehouseList = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.rbAllList = New System.Windows.Forms.RadioButton()
        Me.rbSelectedOnly = New System.Windows.Forms.RadioButton()
        Me.cbTargetWare = New System.Windows.Forms.ComboBox()
        Me.cbTargetCellInWare = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbConsumer = New System.Windows.Forms.ComboBox()
        Me.btRemoveFromList = New System.Windows.Forms.Button()
        Me.btRemoveFromCells = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cbCellList = New System.Windows.Forms.ComboBox()
        Me.btGetFromCell = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btClearPrintJob = New System.Windows.Forms.Button()
        Me.btPrintLabel = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btAddLabel = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lbSlotInfo = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btClear = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbxSampleList
        '
        Me.lbxSampleList.FormattingEnabled = True
        Me.lbxSampleList.Location = New System.Drawing.Point(9, 111)
        Me.lbxSampleList.Name = "lbxSampleList"
        Me.lbxSampleList.Size = New System.Drawing.Size(302, 212)
        Me.lbxSampleList.TabIndex = 1
        '
        'tbSampleNumber
        '
        Me.tbSampleNumber.Location = New System.Drawing.Point(9, 83)
        Me.tbSampleNumber.Name = "tbSampleNumber"
        Me.tbSampleNumber.Size = New System.Drawing.Size(108, 20)
        Me.tbSampleNumber.TabIndex = 2
        '
        'btAddNumber
        '
        Me.btAddNumber.Location = New System.Drawing.Point(123, 82)
        Me.btAddNumber.Name = "btAddNumber"
        Me.btAddNumber.Size = New System.Drawing.Size(67, 23)
        Me.btAddNumber.TabIndex = 3
        Me.btAddNumber.Text = "добавить"
        Me.btAddNumber.UseVisualStyleBackColor = True
        '
        'btMoveTo
        '
        Me.btMoveTo.Location = New System.Drawing.Point(356, 150)
        Me.btMoveTo.Name = "btMoveTo"
        Me.btMoveTo.Size = New System.Drawing.Size(177, 23)
        Me.btMoveTo.TabIndex = 5
        Me.btMoveTo.Text = "Переместить на склад (2 док.)"
        Me.btMoveTo.UseVisualStyleBackColor = True
        '
        'btPlaceToCell
        '
        Me.btPlaceToCell.Location = New System.Drawing.Point(205, 110)
        Me.btPlaceToCell.Name = "btPlaceToCell"
        Me.btPlaceToCell.Size = New System.Drawing.Size(145, 23)
        Me.btPlaceToCell.TabIndex = 6
        Me.btPlaceToCell.Text = "Переложить в ячейку"
        Me.btPlaceToCell.UseVisualStyleBackColor = True
        '
        'btCreateDemand
        '
        Me.btCreateDemand.Enabled = False
        Me.btCreateDemand.Location = New System.Drawing.Point(356, 194)
        Me.btCreateDemand.Name = "btCreateDemand"
        Me.btCreateDemand.Size = New System.Drawing.Size(177, 23)
        Me.btCreateDemand.TabIndex = 7
        Me.btCreateDemand.Text = "Отгрузить со склада (1 док.)"
        Me.btCreateDemand.UseVisualStyleBackColor = True
        '
        'cbTargetCell
        '
        Me.cbTargetCell.FormattingEnabled = True
        Me.cbTargetCell.Location = New System.Drawing.Point(84, 110)
        Me.cbTargetCell.Name = "cbTargetCell"
        Me.cbTargetCell.Size = New System.Drawing.Size(101, 21)
        Me.cbTargetCell.TabIndex = 9
        '
        'cbWarehouseList
        '
        Me.cbWarehouseList.FormattingEnabled = True
        Me.cbWarehouseList.Location = New System.Drawing.Point(121, 6)
        Me.cbWarehouseList.Name = "cbWarehouseList"
        Me.cbWarehouseList.Size = New System.Drawing.Size(212, 21)
        Me.cbWarehouseList.TabIndex = 10
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(4, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(111, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Работаем на складе"
        '
        'rbAllList
        '
        Me.rbAllList.AutoSize = True
        Me.rbAllList.Checked = True
        Me.rbAllList.Location = New System.Drawing.Point(7, 22)
        Me.rbAllList.Name = "rbAllList"
        Me.rbAllList.Size = New System.Drawing.Size(98, 17)
        Me.rbAllList.TabIndex = 12
        Me.rbAllList.TabStop = True
        Me.rbAllList.Text = "Все из списка"
        Me.rbAllList.UseVisualStyleBackColor = True
        '
        'rbSelectedOnly
        '
        Me.rbSelectedOnly.AutoSize = True
        Me.rbSelectedOnly.Location = New System.Drawing.Point(112, 22)
        Me.rbSelectedOnly.Name = "rbSelectedOnly"
        Me.rbSelectedOnly.Size = New System.Drawing.Size(129, 17)
        Me.rbSelectedOnly.TabIndex = 13
        Me.rbSelectedOnly.Text = "Только выделенные"
        Me.rbSelectedOnly.UseVisualStyleBackColor = True
        '
        'cbTargetWare
        '
        Me.cbTargetWare.FormattingEnabled = True
        Me.cbTargetWare.Location = New System.Drawing.Point(84, 152)
        Me.cbTargetWare.Name = "cbTargetWare"
        Me.cbTargetWare.Size = New System.Drawing.Size(152, 21)
        Me.cbTargetWare.TabIndex = 14
        '
        'cbTargetCellInWare
        '
        Me.cbTargetCellInWare.FormattingEnabled = True
        Me.cbTargetCellInWare.Location = New System.Drawing.Point(241, 152)
        Me.cbTargetCellInWare.Name = "cbTargetCellInWare"
        Me.cbTargetCellInWare.Size = New System.Drawing.Size(109, 21)
        Me.cbTargetCellInWare.TabIndex = 15
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(84, 93)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 13)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Целевая ячейка"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(84, 136)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(84, 13)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "Целевой склад"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(244, 136)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(89, 13)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "Целевая ячейка"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(84, 180)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 13)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "Контрагент"
        '
        'cbConsumer
        '
        Me.cbConsumer.Enabled = False
        Me.cbConsumer.FormattingEnabled = True
        Me.cbConsumer.Location = New System.Drawing.Point(84, 196)
        Me.cbConsumer.Name = "cbConsumer"
        Me.cbConsumer.Size = New System.Drawing.Size(267, 21)
        Me.cbConsumer.TabIndex = 19
        '
        'btRemoveFromList
        '
        Me.btRemoveFromList.Location = New System.Drawing.Point(193, 329)
        Me.btRemoveFromList.Name = "btRemoveFromList"
        Me.btRemoveFromList.Size = New System.Drawing.Size(118, 23)
        Me.btRemoveFromList.TabIndex = 21
        Me.btRemoveFromList.Text = "Удалить из списка"
        Me.btRemoveFromList.UseVisualStyleBackColor = True
        '
        'btRemoveFromCells
        '
        Me.btRemoveFromCells.Location = New System.Drawing.Point(97, 54)
        Me.btRemoveFromCells.Name = "btRemoveFromCells"
        Me.btRemoveFromCells.Size = New System.Drawing.Size(144, 23)
        Me.btRemoveFromCells.TabIndex = 4
        Me.btRemoveFromCells.Text = "Убрать из ячеек"
        Me.btRemoveFromCells.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(14, 37)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(91, 13)
        Me.Label7.TabIndex = 22
        Me.Label7.Text = "ячейка-источник"
        '
        'cbCellList
        '
        Me.cbCellList.FormattingEnabled = True
        Me.cbCellList.Location = New System.Drawing.Point(9, 53)
        Me.cbCellList.Name = "cbCellList"
        Me.cbCellList.Size = New System.Drawing.Size(101, 21)
        Me.cbCellList.TabIndex = 23
        '
        'btGetFromCell
        '
        Me.btGetFromCell.Location = New System.Drawing.Point(119, 38)
        Me.btGetFromCell.Name = "btGetFromCell"
        Me.btGetFromCell.Size = New System.Drawing.Size(71, 36)
        Me.btGetFromCell.TabIndex = 24
        Me.btGetFromCell.Text = "Получить"
        Me.btGetFromCell.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btClearPrintJob)
        Me.GroupBox1.Controls.Add(Me.PictureBox1)
        Me.GroupBox1.Controls.Add(Me.btPrintLabel)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.btMoveTo)
        Me.GroupBox1.Controls.Add(Me.cbTargetWare)
        Me.GroupBox1.Controls.Add(Me.cbTargetCellInWare)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.rbSelectedOnly)
        Me.GroupBox1.Controls.Add(Me.rbAllList)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.btCreateDemand)
        Me.GroupBox1.Controls.Add(Me.cbConsumer)
        Me.GroupBox1.Controls.Add(Me.btPlaceToCell)
        Me.GroupBox1.Controls.Add(Me.btRemoveFromCells)
        Me.GroupBox1.Controls.Add(Me.cbTargetCell)
        Me.GroupBox1.Location = New System.Drawing.Point(317, 82)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(548, 270)
        Me.GroupBox1.TabIndex = 25
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Работа со списком"
        '
        'btClearPrintJob
        '
        Me.btClearPrintJob.Location = New System.Drawing.Point(216, 239)
        Me.btClearPrintJob.Name = "btClearPrintJob"
        Me.btClearPrintJob.Size = New System.Drawing.Size(147, 23)
        Me.btClearPrintJob.TabIndex = 46
        Me.btClearPrintJob.TabStop = False
        Me.btClearPrintJob.Text = "Очистить очередь печати"
        Me.btClearPrintJob.UseVisualStyleBackColor = True
        '
        'btPrintLabel
        '
        Me.btPrintLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btPrintLabel.Location = New System.Drawing.Point(386, 233)
        Me.btPrintLabel.Name = "btPrintLabel"
        Me.btPrintLabel.Size = New System.Drawing.Size(147, 34)
        Me.btPrintLabel.TabIndex = 45
        Me.btPrintLabel.TabStop = False
        Me.btPrintLabel.Text = "Печать этикеток"
        Me.btPrintLabel.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(4, 199)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(59, 13)
        Me.Label10.TabIndex = 24
        Me.Label10.Text = "Отгрузить"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(4, 157)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(75, 13)
        Me.Label9.TabIndex = 23
        Me.Label9.Text = "Переместить"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(4, 115)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(70, 13)
        Me.Label8.TabIndex = 22
        Me.Label8.Text = "Переложить"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(2, 58)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 13)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "Убрать из ячеек"
        '
        'btAddLabel
        '
        Me.btAddLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btAddLabel.Location = New System.Drawing.Point(6, 19)
        Me.btAddLabel.Name = "btAddLabel"
        Me.btAddLabel.Size = New System.Drawing.Size(147, 44)
        Me.btAddLabel.TabIndex = 34
        Me.btAddLabel.TabStop = False
        Me.btAddLabel.Text = "Добавить этикетку в список печати"
        Me.btAddLabel.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lbSlotInfo)
        Me.GroupBox2.Controls.Add(Me.btAddLabel)
        Me.GroupBox2.Location = New System.Drawing.Point(348, 6)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(517, 68)
        Me.GroupBox2.TabIndex = 26
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Текущий образец"
        '
        'lbSlotInfo
        '
        Me.lbSlotInfo.AutoSize = True
        Me.lbSlotInfo.Location = New System.Drawing.Point(173, 16)
        Me.lbSlotInfo.Name = "lbSlotInfo"
        Me.lbSlotInfo.Size = New System.Drawing.Size(24, 13)
        Me.lbSlotInfo.TabIndex = 61
        Me.lbSlotInfo.Text = "info"
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(419, 14)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(120, 100)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 35
        Me.PictureBox1.TabStop = False
        '
        'btClear
        '
        Me.btClear.Location = New System.Drawing.Point(9, 329)
        Me.btClear.Name = "btClear"
        Me.btClear.Size = New System.Drawing.Size(118, 23)
        Me.btClear.TabIndex = 27
        Me.btClear.Text = "Очистить"
        Me.btClear.UseVisualStyleBackColor = True
        '
        'uc_Cell
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btClear)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btGetFromCell)
        Me.Controls.Add(Me.cbCellList)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.btRemoveFromList)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cbWarehouseList)
        Me.Controls.Add(Me.btAddNumber)
        Me.Controls.Add(Me.tbSampleNumber)
        Me.Controls.Add(Me.lbxSampleList)
        Me.Name = "uc_Cell"
        Me.Size = New System.Drawing.Size(874, 360)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lbxSampleList As Windows.Forms.ListBox
    Friend WithEvents tbSampleNumber As Windows.Forms.TextBox
    Friend WithEvents btAddNumber As Windows.Forms.Button
    Friend WithEvents btMoveTo As Windows.Forms.Button
    Friend WithEvents btPlaceToCell As Windows.Forms.Button
    Friend WithEvents btCreateDemand As Windows.Forms.Button
    Friend WithEvents cbTargetCell As Windows.Forms.ComboBox
    Friend WithEvents cbWarehouseList As Windows.Forms.ComboBox
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents rbAllList As Windows.Forms.RadioButton
    Friend WithEvents rbSelectedOnly As Windows.Forms.RadioButton
    Friend WithEvents cbTargetWare As Windows.Forms.ComboBox
    Friend WithEvents cbTargetCellInWare As Windows.Forms.ComboBox
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents Label5 As Windows.Forms.Label
    Friend WithEvents Label6 As Windows.Forms.Label
    Friend WithEvents cbConsumer As Windows.Forms.ComboBox
    Friend WithEvents btRemoveFromList As Windows.Forms.Button
    Friend WithEvents btRemoveFromCells As Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cbCellList As System.Windows.Forms.ComboBox
    Friend WithEvents btGetFromCell As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btAddLabel As System.Windows.Forms.Button
    Friend WithEvents btPrintLabel As System.Windows.Forms.Button
    Friend WithEvents btClearPrintJob As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lbSlotInfo As System.Windows.Forms.Label
    Friend WithEvents btClear As System.Windows.Forms.Button
End Class
