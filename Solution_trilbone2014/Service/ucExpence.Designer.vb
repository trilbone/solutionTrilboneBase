<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucExpence
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
        Dim PaidTimeLabel As System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbOrganization = New System.Windows.Forms.ComboBox()
        Me.cbReceiver = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lbPayer = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lbxAccount = New System.Windows.Forms.ListBox()
        Me.lbxPurpose = New System.Windows.Forms.ListBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cbCurrency = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tbAmount = New System.Windows.Forms.TextBox()
        Me.PaidTimeDateTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.rtbPaymentPurpose = New System.Windows.Forms.RichTextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.rtbPaymentComment = New System.Windows.Forms.RichTextBox()
        Me.tbCreatePayment = New System.Windows.Forms.Button()
        Me.btClear = New System.Windows.Forms.Button()
        Me.cbStatus = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        PaidTimeLabel = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Организация"
        '
        'cbOrganization
        '
        Me.cbOrganization.FormattingEnabled = True
        Me.cbOrganization.Location = New System.Drawing.Point(98, 23)
        Me.cbOrganization.Name = "cbOrganization"
        Me.cbOrganization.Size = New System.Drawing.Size(167, 21)
        Me.cbOrganization.TabIndex = 1
        '
        'cbReceiver
        '
        Me.cbReceiver.FormattingEnabled = True
        Me.cbReceiver.Location = New System.Drawing.Point(98, 50)
        Me.cbReceiver.Name = "cbReceiver"
        Me.cbReceiver.Size = New System.Drawing.Size(209, 21)
        Me.cbReceiver.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(18, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Получатель"
        '
        'lbPayer
        '
        Me.lbPayer.AutoSize = True
        Me.lbPayer.Location = New System.Drawing.Point(20, 4)
        Me.lbPayer.Name = "lbPayer"
        Me.lbPayer.Size = New System.Drawing.Size(71, 13)
        Me.lbPayer.TabIndex = 4
        Me.lbPayer.Text = "Плательщик"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(21, 84)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Счет оплаты"
        '
        'lbxAccount
        '
        Me.lbxAccount.FormattingEnabled = True
        Me.lbxAccount.Location = New System.Drawing.Point(21, 100)
        Me.lbxAccount.Name = "lbxAccount"
        Me.lbxAccount.Size = New System.Drawing.Size(149, 199)
        Me.lbxAccount.TabIndex = 6
        '
        'lbxPurpose
        '
        Me.lbxPurpose.FormattingEnabled = True
        Me.lbxPurpose.Location = New System.Drawing.Point(204, 100)
        Me.lbxPurpose.Name = "lbxPurpose"
        Me.lbxPurpose.Size = New System.Drawing.Size(149, 199)
        Me.lbxPurpose.TabIndex = 8
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(204, 84)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(86, 13)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Статья расхода"
        '
        'cbCurrency
        '
        Me.cbCurrency.FormattingEnabled = True
        Me.cbCurrency.Items.AddRange(New Object() {"RUR", "USD", "EUR"})
        Me.cbCurrency.Location = New System.Drawing.Point(567, 45)
        Me.cbCurrency.Name = "cbCurrency"
        Me.cbCurrency.Size = New System.Drawing.Size(54, 21)
        Me.cbCurrency.TabIndex = 47
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(452, 47)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(41, 13)
        Me.Label6.TabIndex = 46
        Me.Label6.Text = "Сумма"
        '
        'tbAmount
        '
        Me.tbAmount.Location = New System.Drawing.Point(503, 45)
        Me.tbAmount.Name = "tbAmount"
        Me.tbAmount.Size = New System.Drawing.Size(58, 20)
        Me.tbAmount.TabIndex = 45
        '
        'PaidTimeLabel
        '
        PaidTimeLabel.AutoSize = True
        PaidTimeLabel.Location = New System.Drawing.Point(399, 19)
        PaidTimeLabel.Name = "PaidTimeLabel"
        PaidTimeLabel.Size = New System.Drawing.Size(82, 13)
        PaidTimeLabel.TabIndex = 48
        PaidTimeLabel.Text = "Дата платежа:"
        '
        'PaidTimeDateTimePicker
        '
        Me.PaidTimeDateTimePicker.Location = New System.Drawing.Point(487, 15)
        Me.PaidTimeDateTimePicker.Name = "PaidTimeDateTimePicker"
        Me.PaidTimeDateTimePicker.Size = New System.Drawing.Size(134, 20)
        Me.PaidTimeDateTimePicker.TabIndex = 49
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(372, 81)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(109, 13)
        Me.Label9.TabIndex = 51
        Me.Label9.Text = "Основание платежа"
        '
        'rtbPaymentPurpose
        '
        Me.rtbPaymentPurpose.Location = New System.Drawing.Point(375, 100)
        Me.rtbPaymentPurpose.Name = "rtbPaymentPurpose"
        Me.rtbPaymentPurpose.Size = New System.Drawing.Size(252, 46)
        Me.rtbPaymentPurpose.TabIndex = 50
        Me.rtbPaymentPurpose.Text = ""
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(376, 152)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(77, 13)
        Me.Label10.TabIndex = 53
        Me.Label10.Text = "Комментарий"
        '
        'rtbPaymentComment
        '
        Me.rtbPaymentComment.Location = New System.Drawing.Point(379, 171)
        Me.rtbPaymentComment.Name = "rtbPaymentComment"
        Me.rtbPaymentComment.Size = New System.Drawing.Size(248, 47)
        Me.rtbPaymentComment.TabIndex = 52
        Me.rtbPaymentComment.Text = ""
        '
        'tbCreatePayment
        '
        Me.tbCreatePayment.Location = New System.Drawing.Point(379, 272)
        Me.tbCreatePayment.Name = "tbCreatePayment"
        Me.tbCreatePayment.Size = New System.Drawing.Size(128, 35)
        Me.tbCreatePayment.TabIndex = 54
        Me.tbCreatePayment.Text = "1. Создать платеж"
        Me.tbCreatePayment.UseVisualStyleBackColor = True
        '
        'btClear
        '
        Me.btClear.Location = New System.Drawing.Point(529, 272)
        Me.btClear.Name = "btClear"
        Me.btClear.Size = New System.Drawing.Size(92, 35)
        Me.btClear.TabIndex = 55
        Me.btClear.Text = "Очистить"
        Me.btClear.UseVisualStyleBackColor = True
        '
        'cbStatus
        '
        Me.cbStatus.FormattingEnabled = True
        Me.cbStatus.Location = New System.Drawing.Point(460, 236)
        Me.cbStatus.Name = "cbStatus"
        Me.cbStatus.Size = New System.Drawing.Size(167, 21)
        Me.cbStatus.TabIndex = 57
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(412, 239)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(41, 13)
        Me.Label7.TabIndex = 56
        Me.Label7.Text = "Статус"
        '
        'ucExpence
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.cbStatus)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.btClear)
        Me.Controls.Add(Me.tbCreatePayment)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.rtbPaymentComment)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.rtbPaymentPurpose)
        Me.Controls.Add(PaidTimeLabel)
        Me.Controls.Add(Me.PaidTimeDateTimePicker)
        Me.Controls.Add(Me.cbCurrency)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.tbAmount)
        Me.Controls.Add(Me.lbxPurpose)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lbxAccount)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lbPayer)
        Me.Controls.Add(Me.cbReceiver)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cbOrganization)
        Me.Controls.Add(Me.Label1)
        Me.Name = "ucExpence"
        Me.Size = New System.Drawing.Size(651, 317)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbOrganization As System.Windows.Forms.ComboBox
    Friend WithEvents cbReceiver As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lbPayer As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lbxAccount As System.Windows.Forms.ListBox
    Friend WithEvents lbxPurpose As System.Windows.Forms.ListBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cbCurrency As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents tbAmount As System.Windows.Forms.TextBox
    Friend WithEvents PaidTimeDateTimePicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents rtbPaymentPurpose As System.Windows.Forms.RichTextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents rtbPaymentComment As System.Windows.Forms.RichTextBox
    Friend WithEvents tbCreatePayment As System.Windows.Forms.Button
    Friend WithEvents btClear As System.Windows.Forms.Button
    Friend WithEvents cbStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label

End Class
