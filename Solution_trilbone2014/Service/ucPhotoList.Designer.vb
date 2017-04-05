<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucPhotoList
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
        Me.cbxShowImages = New System.Windows.Forms.CheckBox()
        Me.cbxPopUp = New System.Windows.Forms.CheckBox()
        Me.pbTitle = New System.Windows.Forms.PictureBox()
        Me.lbSource = New System.Windows.Forms.Label()
        Me.lbSampleNumber = New System.Windows.Forms.Label()
        Me.rbDb = New System.Windows.Forms.RadioButton()
        Me.RbOuter = New System.Windows.Forms.RadioButton()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.tbPrevievTime = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lvBox = New System.Windows.Forms.ListView()
        CType(Me.pbTitle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cbxShowImages
        '
        Me.cbxShowImages.AutoSize = True
        Me.cbxShowImages.Location = New System.Drawing.Point(37, 78)
        Me.cbxShowImages.Name = "cbxShowImages"
        Me.cbxShowImages.Size = New System.Drawing.Size(101, 17)
        Me.cbxShowImages.TabIndex = 2
        Me.cbxShowImages.Text = "показать фото"
        Me.cbxShowImages.UseVisualStyleBackColor = True
        '
        'cbxPopUp
        '
        Me.cbxPopUp.AutoSize = True
        Me.cbxPopUp.Location = New System.Drawing.Point(204, 5)
        Me.cbxPopUp.Name = "cbxPopUp"
        Me.cbxPopUp.Size = New System.Drawing.Size(101, 17)
        Me.cbxPopUp.TabIndex = 3
        Me.cbxPopUp.Text = "Предпросмотр"
        Me.cbxPopUp.UseVisualStyleBackColor = True
        '
        'pbTitle
        '
        Me.pbTitle.Location = New System.Drawing.Point(305, 4)
        Me.pbTitle.Name = "pbTitle"
        Me.pbTitle.Size = New System.Drawing.Size(120, 90)
        Me.pbTitle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbTitle.TabIndex = 4
        Me.pbTitle.TabStop = False
        '
        'lbSource
        '
        Me.lbSource.AutoSize = True
        Me.lbSource.Location = New System.Drawing.Point(3, 31)
        Me.lbSource.Name = "lbSource"
        Me.lbSource.Size = New System.Drawing.Size(65, 13)
        Me.lbSource.TabIndex = 5
        Me.lbSource.Text = "[источники]"
        '
        'lbSampleNumber
        '
        Me.lbSampleNumber.AutoSize = True
        Me.lbSampleNumber.Location = New System.Drawing.Point(3, 5)
        Me.lbSampleNumber.Name = "lbSampleNumber"
        Me.lbSampleNumber.Size = New System.Drawing.Size(45, 13)
        Me.lbSampleNumber.TabIndex = 6
        Me.lbSampleNumber.Text = "[номер]"
        '
        'rbDb
        '
        Me.rbDb.AutoSize = True
        Me.rbDb.Location = New System.Drawing.Point(173, 78)
        Me.rbDb.Name = "rbDb"
        Me.rbDb.Size = New System.Drawing.Size(41, 17)
        Me.rbDb.TabIndex = 7
        Me.rbDb.TabStop = True
        Me.rbDb.Text = "БД"
        Me.rbDb.UseVisualStyleBackColor = True
        '
        'RbOuter
        '
        Me.RbOuter.AutoSize = True
        Me.RbOuter.Location = New System.Drawing.Point(225, 79)
        Me.RbOuter.Name = "RbOuter"
        Me.RbOuter.Size = New System.Drawing.Size(70, 17)
        Me.RbOuter.TabIndex = 8
        Me.RbOuter.TabStop = True
        Me.RbOuter.Text = "Внешний"
        Me.RbOuter.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        '
        'tbPrevievTime
        '
        Me.tbPrevievTime.Location = New System.Drawing.Point(173, 2)
        Me.tbPrevievTime.Name = "tbPrevievTime"
        Me.tbPrevievTime.Size = New System.Drawing.Size(23, 20)
        Me.tbPrevievTime.TabIndex = 36
        Me.tbPrevievTime.Text = "1"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(234, 13)
        Me.Label2.TabIndex = 37
        Me.Label2.Text = "Задать главное фото - выделить и нажать M"
        '
        'lvBox
        '
        Me.lvBox.CheckBoxes = True
        Me.lvBox.Location = New System.Drawing.Point(1, 99)
        Me.lvBox.Name = "lvBox"
        Me.lvBox.Size = New System.Drawing.Size(426, 329)
        Me.lvBox.TabIndex = 0
        Me.lvBox.UseCompatibleStateImageBehavior = False
        '
        'ucPhotoList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lvBox)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tbPrevievTime)
        Me.Controls.Add(Me.RbOuter)
        Me.Controls.Add(Me.rbDb)
        Me.Controls.Add(Me.lbSampleNumber)
        Me.Controls.Add(Me.lbSource)
        Me.Controls.Add(Me.pbTitle)
        Me.Controls.Add(Me.cbxPopUp)
        Me.Controls.Add(Me.cbxShowImages)
        Me.Name = "ucPhotoList"
        Me.Size = New System.Drawing.Size(428, 430)
        CType(Me.pbTitle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cbxShowImages As System.Windows.Forms.CheckBox
    Friend WithEvents cbxPopUp As System.Windows.Forms.CheckBox
    Friend WithEvents pbTitle As System.Windows.Forms.PictureBox
    Friend WithEvents lbSource As System.Windows.Forms.Label
    Friend WithEvents lbSampleNumber As System.Windows.Forms.Label
    Friend WithEvents rbDb As System.Windows.Forms.RadioButton
    Friend WithEvents RbOuter As System.Windows.Forms.RadioButton
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents tbPrevievTime As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lvBox As System.Windows.Forms.ListView

End Class
