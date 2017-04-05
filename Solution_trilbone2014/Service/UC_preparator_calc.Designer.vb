<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UC_preparator_calc
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
        Dim Label35 As System.Windows.Forms.Label
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.btToPrepTime = New System.Windows.Forms.Button()
        Me.btClearPrep = New System.Windows.Forms.Button()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.tbFullPrepCost = New System.Windows.Forms.TextBox()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.tbPrepCost = New System.Windows.Forms.TextBox()
        Me.btAddPrep = New System.Windows.Forms.Button()
        Me.tbPrepTimeAdd = New System.Windows.Forms.TextBox()
        Me.cbPreparatorAdd = New System.Windows.Forms.ComboBox()
        Me.tbPrepList = New System.Windows.Forms.TextBox()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.tbPrepTime = New System.Windows.Forms.TextBox()
        Me.cbMainPreparator = New System.Windows.Forms.ComboBox()
        Me.RawNumberLabel = New System.Windows.Forms.Label()
        Me.tbRawNumber = New System.Windows.Forms.TextBox()
        Me.btGetNewNumber = New System.Windows.Forms.Button()
        Label35 = New System.Windows.Forms.Label()
        Me.GroupBox6.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label35
        '
        Label35.AutoSize = True
        Label35.Location = New System.Drawing.Point(5, 47)
        Label35.Name = "Label35"
        Label35.Size = New System.Drawing.Size(148, 13)
        Label35.TabIndex = 102
        Label35.Text = "Ответственный препаратор"
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.btGetNewNumber)
        Me.GroupBox6.Controls.Add(Me.btToPrepTime)
        Me.GroupBox6.Controls.Add(Me.btClearPrep)
        Me.GroupBox6.Controls.Add(Me.Label47)
        Me.GroupBox6.Controls.Add(Me.Label48)
        Me.GroupBox6.Controls.Add(Me.tbFullPrepCost)
        Me.GroupBox6.Controls.Add(Me.Label44)
        Me.GroupBox6.Controls.Add(Me.Label45)
        Me.GroupBox6.Controls.Add(Me.tbPrepCost)
        Me.GroupBox6.Controls.Add(Me.btAddPrep)
        Me.GroupBox6.Controls.Add(Me.tbPrepTimeAdd)
        Me.GroupBox6.Controls.Add(Me.cbPreparatorAdd)
        Me.GroupBox6.Controls.Add(Me.tbPrepList)
        Me.GroupBox6.Controls.Add(Me.Label40)
        Me.GroupBox6.Controls.Add(Me.Label43)
        Me.GroupBox6.Controls.Add(Me.Label36)
        Me.GroupBox6.Controls.Add(Me.tbPrepTime)
        Me.GroupBox6.Controls.Add(Me.cbMainPreparator)
        Me.GroupBox6.Controls.Add(Label35)
        Me.GroupBox6.Controls.Add(Me.RawNumberLabel)
        Me.GroupBox6.Controls.Add(Me.tbRawNumber)
        Me.GroupBox6.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(335, 243)
        Me.GroupBox6.TabIndex = 117
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Стоимость препарации/доделки"
        '
        'btToPrepTime
        '
        Me.btToPrepTime.Location = New System.Drawing.Point(235, 163)
        Me.btToPrepTime.Name = "btToPrepTime"
        Me.btToPrepTime.Size = New System.Drawing.Size(65, 23)
        Me.btToPrepTime.TabIndex = 127
        Me.btToPrepTime.Text = "к преп."
        Me.btToPrepTime.UseVisualStyleBackColor = True
        '
        'btClearPrep
        '
        Me.btClearPrep.Location = New System.Drawing.Point(267, 189)
        Me.btClearPrep.Name = "btClearPrep"
        Me.btClearPrep.Size = New System.Drawing.Size(65, 23)
        Me.btClearPrep.TabIndex = 126
        Me.btClearPrep.Text = "Очистить"
        Me.btClearPrep.UseVisualStyleBackColor = True
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.Location = New System.Drawing.Point(304, 220)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(24, 13)
        Me.Label47.TabIndex = 125
        Me.Label47.Text = "руб"
        '
        'Label48
        '
        Me.Label48.AutoSize = True
        Me.Label48.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label48.Location = New System.Drawing.Point(6, 220)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(228, 13)
        Me.Label48.TabIndex = 123
        Me.Label48.Text = "3. Стоимость препарации к рассчету"
        '
        'tbFullPrepCost
        '
        Me.tbFullPrepCost.Location = New System.Drawing.Point(239, 217)
        Me.tbFullPrepCost.Name = "tbFullPrepCost"
        Me.tbFullPrepCost.Size = New System.Drawing.Size(60, 20)
        Me.tbFullPrepCost.TabIndex = 124
        Me.tbFullPrepCost.TabStop = False
        Me.tbFullPrepCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Location = New System.Drawing.Point(227, 195)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(24, 13)
        Me.Label44.TabIndex = 122
        Me.Label44.Text = "руб"
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Location = New System.Drawing.Point(9, 195)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(148, 13)
        Me.Label45.TabIndex = 120
        Me.Label45.Text = "К оплате препараторам (вх)"
        '
        'tbPrepCost
        '
        Me.tbPrepCost.Location = New System.Drawing.Point(162, 192)
        Me.tbPrepCost.Name = "tbPrepCost"
        Me.tbPrepCost.Size = New System.Drawing.Size(60, 20)
        Me.tbPrepCost.TabIndex = 121
        Me.tbPrepCost.TabStop = False
        Me.tbPrepCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btAddPrep
        '
        Me.btAddPrep.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btAddPrep.Location = New System.Drawing.Point(9, 106)
        Me.btAddPrep.Name = "btAddPrep"
        Me.btAddPrep.Size = New System.Drawing.Size(76, 23)
        Me.btAddPrep.TabIndex = 119
        Me.btAddPrep.Text = "Добавить"
        Me.btAddPrep.UseVisualStyleBackColor = True
        '
        'tbPrepTimeAdd
        '
        Me.tbPrepTimeAdd.Location = New System.Drawing.Point(284, 135)
        Me.tbPrepTimeAdd.Name = "tbPrepTimeAdd"
        Me.tbPrepTimeAdd.Size = New System.Drawing.Size(45, 20)
        Me.tbPrepTimeAdd.TabIndex = 118
        '
        'cbPreparatorAdd
        '
        Me.cbPreparatorAdd.FormattingEnabled = True
        Me.cbPreparatorAdd.Location = New System.Drawing.Point(8, 135)
        Me.cbPreparatorAdd.Name = "cbPreparatorAdd"
        Me.cbPreparatorAdd.Size = New System.Drawing.Size(270, 21)
        Me.cbPreparatorAdd.TabIndex = 117
        Me.cbPreparatorAdd.TabStop = False
        '
        'tbPrepList
        '
        Me.tbPrepList.Location = New System.Drawing.Point(88, 70)
        Me.tbPrepList.Multiline = True
        Me.tbPrepList.Name = "tbPrepList"
        Me.tbPrepList.Size = New System.Drawing.Size(241, 59)
        Me.tbPrepList.TabIndex = 115
        '
        'Label40
        '
        Me.Label40.Location = New System.Drawing.Point(6, 73)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(76, 27)
        Me.Label40.TabIndex = 114
        Me.Label40.Text = "Препараторы и время"
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Location = New System.Drawing.Point(206, 167)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(24, 13)
        Me.Label43.TabIndex = 113
        Me.Label43.Text = "час"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(13, 168)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(140, 13)
        Me.Label36.TabIndex = 111
        Me.Label36.Text = "Общее время препарации"
        '
        'tbPrepTime
        '
        Me.tbPrepTime.Location = New System.Drawing.Point(162, 164)
        Me.tbPrepTime.Name = "tbPrepTime"
        Me.tbPrepTime.Size = New System.Drawing.Size(38, 20)
        Me.tbPrepTime.TabIndex = 112
        Me.tbPrepTime.TabStop = False
        Me.tbPrepTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cbMainPreparator
        '
        Me.cbMainPreparator.FormattingEnabled = True
        Me.cbMainPreparator.Location = New System.Drawing.Point(159, 43)
        Me.cbMainPreparator.Name = "cbMainPreparator"
        Me.cbMainPreparator.Size = New System.Drawing.Size(170, 21)
        Me.cbMainPreparator.TabIndex = 103
        Me.cbMainPreparator.TabStop = False
        '
        'RawNumberLabel
        '
        Me.RawNumberLabel.AutoSize = True
        Me.RawNumberLabel.Location = New System.Drawing.Point(7, 20)
        Me.RawNumberLabel.Name = "RawNumberLabel"
        Me.RawNumberLabel.Size = New System.Drawing.Size(130, 13)
        Me.RawNumberLabel.TabIndex = 100
        Me.RawNumberLabel.Text = "Препарационный номер"
        Me.RawNumberLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tbRawNumber
        '
        Me.tbRawNumber.Location = New System.Drawing.Point(140, 17)
        Me.tbRawNumber.Name = "tbRawNumber"
        Me.tbRawNumber.Size = New System.Drawing.Size(128, 20)
        Me.tbRawNumber.TabIndex = 101
        Me.tbRawNumber.TabStop = False
        '
        'btGetNewNumber
        '
        Me.btGetNewNumber.Location = New System.Drawing.Point(274, 15)
        Me.btGetNewNumber.Name = "btGetNewNumber"
        Me.btGetNewNumber.Size = New System.Drawing.Size(54, 23)
        Me.btGetNewNumber.TabIndex = 128
        Me.btGetNewNumber.Text = "Новый"
        Me.btGetNewNumber.UseVisualStyleBackColor = True
        '
        'UC_preparator_calc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GroupBox6)
        Me.Name = "UC_preparator_calc"
        Me.Size = New System.Drawing.Size(335, 243)
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox6 As Windows.Forms.GroupBox
    Friend WithEvents btToPrepTime As Windows.Forms.Button
    Friend WithEvents btClearPrep As Windows.Forms.Button
    Friend WithEvents Label47 As Windows.Forms.Label
    Friend WithEvents Label48 As Windows.Forms.Label
    Friend WithEvents tbFullPrepCost As Windows.Forms.TextBox
    Friend WithEvents Label44 As Windows.Forms.Label
    Friend WithEvents Label45 As Windows.Forms.Label
    Friend WithEvents tbPrepCost As Windows.Forms.TextBox
    Friend WithEvents btAddPrep As Windows.Forms.Button
    Friend WithEvents tbPrepTimeAdd As Windows.Forms.TextBox
    Friend WithEvents cbPreparatorAdd As Windows.Forms.ComboBox
    Friend WithEvents tbPrepList As Windows.Forms.TextBox
    Friend WithEvents Label40 As Windows.Forms.Label
    Friend WithEvents Label43 As Windows.Forms.Label
    Friend WithEvents Label36 As Windows.Forms.Label
    Friend WithEvents tbPrepTime As Windows.Forms.TextBox
    Friend WithEvents cbMainPreparator As Windows.Forms.ComboBox
    Friend WithEvents RawNumberLabel As Windows.Forms.Label
    Friend WithEvents tbRawNumber As Windows.Forms.TextBox
    Friend WithEvents btGetNewNumber As Windows.Forms.Button
End Class
