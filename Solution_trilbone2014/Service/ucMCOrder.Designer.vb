<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucMCOrder
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
        Me.tbCreateOrder = New System.Windows.Forms.Button()
        Me.btImportOrder = New System.Windows.Forms.Button()
        Me.tbOrderName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbCurrency = New System.Windows.Forms.ComboBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.lbShipWokerUUID = New System.Windows.Forms.Label()
        Me.cbxDeclarationInclude = New System.Windows.Forms.CheckBox()
        Me.btSendParcel = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lbWokers = New System.Windows.Forms.ListBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btDemand = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'tbCreateOrder
        '
        Me.tbCreateOrder.Location = New System.Drawing.Point(3, 83)
        Me.tbCreateOrder.Name = "tbCreateOrder"
        Me.tbCreateOrder.Size = New System.Drawing.Size(128, 23)
        Me.tbCreateOrder.TabIndex = 9
        Me.tbCreateOrder.Text = "Создать заказ"
        Me.tbCreateOrder.UseVisualStyleBackColor = True
        '
        'btImportOrder
        '
        Me.btImportOrder.Location = New System.Drawing.Point(3, 54)
        Me.btImportOrder.Name = "btImportOrder"
        Me.btImportOrder.Size = New System.Drawing.Size(128, 23)
        Me.btImportOrder.TabIndex = 7
        Me.btImportOrder.Text = "Импорт заказа"
        Me.btImportOrder.UseVisualStyleBackColor = True
        '
        'tbOrderName
        '
        Me.tbOrderName.Location = New System.Drawing.Point(3, 32)
        Me.tbOrderName.Name = "tbOrderName"
        Me.tbOrderName.Size = New System.Drawing.Size(128, 20)
        Me.tbOrderName.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(0, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 13)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Валюта заказа"
        '
        'cbCurrency
        '
        Me.cbCurrency.FormattingEnabled = True
        Me.cbCurrency.Items.AddRange(New Object() {"RUR", "USD", "EUR"})
        Me.cbCurrency.Location = New System.Drawing.Point(90, 5)
        Me.cbCurrency.Name = "cbCurrency"
        Me.cbCurrency.Size = New System.Drawing.Size(54, 21)
        Me.cbCurrency.TabIndex = 10
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(77, 234)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(128, 23)
        Me.Button1.TabIndex = 70
        Me.Button1.Text = "Импорт отгрузки"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(77, 212)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(128, 20)
        Me.TextBox1.TabIndex = 71
        '
        'lbShipWokerUUID
        '
        Me.lbShipWokerUUID.AutoSize = True
        Me.lbShipWokerUUID.Location = New System.Drawing.Point(388, 233)
        Me.lbShipWokerUUID.Name = "lbShipWokerUUID"
        Me.lbShipWokerUUID.Size = New System.Drawing.Size(71, 13)
        Me.lbShipWokerUUID.TabIndex = 69
        Me.lbShipWokerUUID.Text = "отправитель"
        '
        'cbxDeclarationInclude
        '
        Me.cbxDeclarationInclude.AutoSize = True
        Me.cbxDeclarationInclude.Location = New System.Drawing.Point(426, 191)
        Me.cbxDeclarationInclude.Name = "cbxDeclarationInclude"
        Me.cbxDeclarationInclude.Size = New System.Drawing.Size(89, 17)
        Me.cbxDeclarationInclude.TabIndex = 68
        Me.cbxDeclarationInclude.Text = "Декларация"
        Me.cbxDeclarationInclude.UseVisualStyleBackColor = True
        '
        'btSendParcel
        '
        Me.btSendParcel.Location = New System.Drawing.Point(381, 280)
        Me.btSendParcel.Name = "btSendParcel"
        Me.btSendParcel.Size = New System.Drawing.Size(134, 39)
        Me.btSendParcel.TabIndex = 67
        Me.btSendParcel.Text = "Отправить посылку"
        Me.btSendParcel.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(238, 192)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(130, 13)
        Me.Label12.TabIndex = 66
        Me.Label12.Text = "Сотрудники на отправку"
        '
        'lbWokers
        '
        Me.lbWokers.FormattingEnabled = True
        Me.lbWokers.Location = New System.Drawing.Point(241, 211)
        Me.lbWokers.Name = "lbWokers"
        Me.lbWokers.Size = New System.Drawing.Size(120, 108)
        Me.lbWokers.TabIndex = 65
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(46, 192)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(186, 13)
        Me.Label4.TabIndex = 64
        Me.Label4.Text = "отгрузка ТОЛЬКО с одного склада"
        '
        'btDemand
        '
        Me.btDemand.Location = New System.Drawing.Point(77, 268)
        Me.btDemand.Name = "btDemand"
        Me.btDemand.Size = New System.Drawing.Size(128, 33)
        Me.btDemand.TabIndex = 63
        Me.btDemand.Text = "создать отгрузку"
        Me.btDemand.UseVisualStyleBackColor = True
        '
        'ucMCOrder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.lbShipWokerUUID)
        Me.Controls.Add(Me.cbxDeclarationInclude)
        Me.Controls.Add(Me.btSendParcel)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.lbWokers)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btDemand)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cbCurrency)
        Me.Controls.Add(Me.tbCreateOrder)
        Me.Controls.Add(Me.btImportOrder)
        Me.Controls.Add(Me.tbOrderName)
        Me.Name = "ucMCOrder"
        Me.Size = New System.Drawing.Size(647, 352)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tbCreateOrder As System.Windows.Forms.Button
    Friend WithEvents btImportOrder As System.Windows.Forms.Button
    Friend WithEvents tbOrderName As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbCurrency As System.Windows.Forms.ComboBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents lbShipWokerUUID As System.Windows.Forms.Label
    Friend WithEvents cbxDeclarationInclude As System.Windows.Forms.CheckBox
    Friend WithEvents btSendParcel As System.Windows.Forms.Button
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lbWokers As System.Windows.Forms.ListBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btDemand As System.Windows.Forms.Button

End Class
