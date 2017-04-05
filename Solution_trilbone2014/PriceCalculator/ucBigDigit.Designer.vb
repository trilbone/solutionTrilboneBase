<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucBigDigit
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
        Me.btCorrect = New System.Windows.Forms.Button()
        Me.btClearAll = New System.Windows.Forms.Button()
        Me.btClose = New System.Windows.Forms.Button()
        Me.btDecimal = New System.Windows.Forms.Button()
        Me.Button0 = New System.Windows.Forms.Button()
        Me.btSplitter = New System.Windows.Forms.Button()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.SystemColors.Control
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33332!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334!))
        Me.TableLayoutPanel1.Controls.Add(Me.btCorrect, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.btClearAll, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.btClose, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.btDecimal, 2, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Button0, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.btSplitter, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Button9, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Button8, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Button7, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Button6, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Button5, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Button4, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Button3, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Button2, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Button1, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 5
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.83333!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.83333!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.83333!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.83333!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(404, 391)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'btCorrect
        '
        Me.btCorrect.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btCorrect.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btCorrect.Location = New System.Drawing.Point(3, 327)
        Me.btCorrect.Name = "btCorrect"
        Me.btCorrect.Size = New System.Drawing.Size(128, 61)
        Me.btCorrect.TabIndex = 14
        Me.btCorrect.TabStop = False
        Me.btCorrect.Text = "правка"
        Me.btCorrect.UseVisualStyleBackColor = True
        '
        'btClearAll
        '
        Me.btClearAll.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btClearAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btClearAll.Location = New System.Drawing.Point(137, 327)
        Me.btClearAll.Name = "btClearAll"
        Me.btClearAll.Size = New System.Drawing.Size(128, 61)
        Me.btClearAll.TabIndex = 13
        Me.btClearAll.TabStop = False
        Me.btClearAll.Text = "очистить"
        Me.btClearAll.UseVisualStyleBackColor = True
        '
        'btClose
        '
        Me.btClose.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btClose.Location = New System.Drawing.Point(271, 327)
        Me.btClose.Name = "btClose"
        Me.btClose.Size = New System.Drawing.Size(130, 61)
        Me.btClose.TabIndex = 12
        Me.btClose.TabStop = False
        Me.btClose.Text = "закрыть"
        Me.btClose.UseVisualStyleBackColor = True
        '
        'btDecimal
        '
        Me.btDecimal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btDecimal.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btDecimal.Location = New System.Drawing.Point(271, 246)
        Me.btDecimal.Name = "btDecimal"
        Me.btDecimal.Size = New System.Drawing.Size(130, 75)
        Me.btDecimal.TabIndex = 11
        Me.btDecimal.TabStop = False
        Me.btDecimal.Text = ","
        Me.btDecimal.UseVisualStyleBackColor = True
        '
        'Button0
        '
        Me.Button0.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button0.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Button0.Location = New System.Drawing.Point(137, 246)
        Me.Button0.Name = "Button0"
        Me.Button0.Size = New System.Drawing.Size(128, 75)
        Me.Button0.TabIndex = 10
        Me.Button0.TabStop = False
        Me.Button0.Text = "0"
        Me.Button0.UseVisualStyleBackColor = True
        '
        'btSplitter
        '
        Me.btSplitter.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btSplitter.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btSplitter.Location = New System.Drawing.Point(3, 246)
        Me.btSplitter.Name = "btSplitter"
        Me.btSplitter.Size = New System.Drawing.Size(128, 75)
        Me.btSplitter.TabIndex = 9
        Me.btSplitter.TabStop = False
        Me.btSplitter.Text = "-"
        Me.btSplitter.UseVisualStyleBackColor = True
        '
        'Button9
        '
        Me.Button9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button9.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Button9.Location = New System.Drawing.Point(271, 165)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(130, 75)
        Me.Button9.TabIndex = 8
        Me.Button9.TabStop = False
        Me.Button9.Text = "9"
        Me.Button9.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button8.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Button8.Location = New System.Drawing.Point(137, 165)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(128, 75)
        Me.Button8.TabIndex = 7
        Me.Button8.TabStop = False
        Me.Button8.Text = "8"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button7.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Button7.Location = New System.Drawing.Point(3, 165)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(128, 75)
        Me.Button7.TabIndex = 6
        Me.Button7.TabStop = False
        Me.Button7.Text = "7"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button6.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Button6.Location = New System.Drawing.Point(271, 84)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(130, 75)
        Me.Button6.TabIndex = 5
        Me.Button6.TabStop = False
        Me.Button6.Text = "6"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button5.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Button5.Location = New System.Drawing.Point(137, 84)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(128, 75)
        Me.Button5.TabIndex = 4
        Me.Button5.TabStop = False
        Me.Button5.Text = "5"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button4.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Button4.Location = New System.Drawing.Point(3, 84)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(128, 75)
        Me.Button4.TabIndex = 3
        Me.Button4.TabStop = False
        Me.Button4.Text = "4"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Button3.Location = New System.Drawing.Point(271, 3)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(130, 75)
        Me.Button3.TabIndex = 2
        Me.Button3.TabStop = False
        Me.Button3.Text = "3"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Button2.Location = New System.Drawing.Point(137, 3)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(128, 75)
        Me.Button2.TabIndex = 1
        Me.Button2.TabStop = False
        Me.Button2.Text = "2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Button1.Location = New System.Drawing.Point(3, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(128, 75)
        Me.Button1.TabIndex = 0
        Me.Button1.TabStop = False
        Me.Button1.Text = "1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ucBigDigit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "ucBigDigit"
        Me.Size = New System.Drawing.Size(404, 391)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btDecimal As System.Windows.Forms.Button
    Friend WithEvents Button0 As System.Windows.Forms.Button
    Friend WithEvents btSplitter As System.Windows.Forms.Button
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents btCorrect As System.Windows.Forms.Button
    Friend WithEvents btClearAll As System.Windows.Forms.Button
    Friend WithEvents btClose As System.Windows.Forms.Button

End Class
