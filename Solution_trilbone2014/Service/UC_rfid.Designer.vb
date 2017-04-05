<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UC_rfid
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
        Me.lbReaderStatus = New System.Windows.Forms.Label()
        Me.lbxCards = New System.Windows.Forms.ListBox()
        Me.lbCardStatus = New System.Windows.Forms.Label()
        Me.btWrite = New System.Windows.Forms.Button()
        Me.tbWriteData = New System.Windows.Forms.TextBox()
        Me.btRead = New System.Windows.Forms.Button()
        Me.tbResult = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btSendKeys = New System.Windows.Forms.Button()
        Me.cbxClearIfNew = New System.Windows.Forms.CheckBox()
        Me.BindingSource1 = New System.Windows.Forms.BindingSource()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbReaderStatus
        '
        Me.lbReaderStatus.AutoSize = True
        Me.lbReaderStatus.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BindingSource1, "ReaderStatusString", True))
        Me.lbReaderStatus.Location = New System.Drawing.Point(12, 7)
        Me.lbReaderStatus.Name = "lbReaderStatus"
        Me.lbReaderStatus.Size = New System.Drawing.Size(68, 13)
        Me.lbReaderStatus.TabIndex = 0
        Me.lbReaderStatus.Text = "reader status"
        '
        'lbxCards
        '
        Me.lbxCards.FormattingEnabled = True
        Me.lbxCards.Location = New System.Drawing.Point(9, 98)
        Me.lbxCards.Name = "lbxCards"
        Me.lbxCards.Size = New System.Drawing.Size(227, 56)
        Me.lbxCards.TabIndex = 2
        '
        'lbCardStatus
        '
        Me.lbCardStatus.AutoSize = True
        Me.lbCardStatus.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BindingSource1, "CardInfo.Message", True))
        Me.lbCardStatus.Location = New System.Drawing.Point(9, 79)
        Me.lbCardStatus.Name = "lbCardStatus"
        Me.lbCardStatus.Size = New System.Drawing.Size(59, 13)
        Me.lbCardStatus.TabIndex = 3
        Me.lbCardStatus.Text = "прочитано"
        '
        'btWrite
        '
        Me.btWrite.Location = New System.Drawing.Point(174, 192)
        Me.btWrite.Name = "btWrite"
        Me.btWrite.Size = New System.Drawing.Size(82, 46)
        Me.btWrite.TabIndex = 4
        Me.btWrite.Text = "Запись"
        Me.btWrite.UseVisualStyleBackColor = True
        '
        'tbWriteData
        '
        Me.tbWriteData.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.tbWriteData.Location = New System.Drawing.Point(9, 212)
        Me.tbWriteData.Name = "tbWriteData"
        Me.tbWriteData.Size = New System.Drawing.Size(150, 26)
        Me.tbWriteData.TabIndex = 5
        '
        'btRead
        '
        Me.btRead.Location = New System.Drawing.Point(12, 31)
        Me.btRead.Name = "btRead"
        Me.btRead.Size = New System.Drawing.Size(163, 45)
        Me.btRead.TabIndex = 6
        Me.btRead.Text = "Читать"
        Me.btRead.UseVisualStyleBackColor = True
        '
        'tbResult
        '
        Me.tbResult.Enabled = False
        Me.tbResult.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.tbResult.Location = New System.Drawing.Point(112, 160)
        Me.tbResult.Name = "tbResult"
        Me.tbResult.Size = New System.Drawing.Size(124, 26)
        Me.tbResult.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 195)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(105, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Записать значение"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 167)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "активный номер"
        '
        'btSendKeys
        '
        Me.btSendKeys.Location = New System.Drawing.Point(181, 31)
        Me.btSendKeys.Name = "btSendKeys"
        Me.btSendKeys.Size = New System.Drawing.Size(89, 45)
        Me.btSendKeys.TabIndex = 10
        Me.btSendKeys.Text = "Набрать номер"
        Me.btSendKeys.UseVisualStyleBackColor = True
        '
        'cbxClearIfNew
        '
        Me.cbxClearIfNew.AutoSize = True
        Me.cbxClearIfNew.Location = New System.Drawing.Point(9, 245)
        Me.cbxClearIfNew.Name = "cbxClearIfNew"
        Me.cbxClearIfNew.Size = New System.Drawing.Size(163, 17)
        Me.cbxClearIfNew.TabIndex = 11
        Me.cbxClearIfNew.Text = "Очищать при чтении метки"
        Me.cbxClearIfNew.UseVisualStyleBackColor = True
        '
        'BindingSource1
        '
        Me.BindingSource1.DataSource = GetType(Service.clsRfidManager)
        '
        'UC_rfid
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.cbxClearIfNew)
        Me.Controls.Add(Me.btSendKeys)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tbResult)
        Me.Controls.Add(Me.btRead)
        Me.Controls.Add(Me.tbWriteData)
        Me.Controls.Add(Me.btWrite)
        Me.Controls.Add(Me.lbCardStatus)
        Me.Controls.Add(Me.lbxCards)
        Me.Controls.Add(Me.lbReaderStatus)
        Me.Name = "UC_rfid"
        Me.Size = New System.Drawing.Size(273, 274)
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbReaderStatus As System.Windows.Forms.Label
    Friend WithEvents lbxCards As System.Windows.Forms.ListBox
    Friend WithEvents lbCardStatus As System.Windows.Forms.Label
    Friend WithEvents btWrite As System.Windows.Forms.Button
    Friend WithEvents tbWriteData As System.Windows.Forms.TextBox
    Friend WithEvents btRead As System.Windows.Forms.Button
    Friend WithEvents BindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents tbResult As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btSendKeys As System.Windows.Forms.Button
    Friend WithEvents cbxClearIfNew As System.Windows.Forms.CheckBox

End Class
