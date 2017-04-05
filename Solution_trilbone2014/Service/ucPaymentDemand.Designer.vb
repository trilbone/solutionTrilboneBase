<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucPaymentDemand
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
        Dim PaidTimeLabel As System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label()
        Me.rtbPaymentComment = New System.Windows.Forms.RichTextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.rtbPaymentPurpose = New System.Windows.Forms.RichTextBox()
        Me.PaidTimeDateTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.tbCreatePayment = New System.Windows.Forms.Button()
        Me.btImportPayment = New System.Windows.Forms.Button()
        Me.tbPaymentName = New System.Windows.Forms.TextBox()
        Me.cbGoPayment = New System.Windows.Forms.ComboBox()
        Me.ClsEntityBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbAmount = New System.Windows.Forms.TextBox()
        Me.cbCurrency = New System.Windows.Forms.ComboBox()
        Me.btLinkDocuments = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        PaidTimeLabel = New System.Windows.Forms.Label()
        CType(Me.ClsEntityBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PaidTimeLabel
        '
        PaidTimeLabel.AutoSize = True
        PaidTimeLabel.Location = New System.Drawing.Point(8, 40)
        PaidTimeLabel.Name = "PaidTimeLabel"
        PaidTimeLabel.Size = New System.Drawing.Size(36, 13)
        PaidTimeLabel.TabIndex = 30
        PaidTimeLabel.Text = "Дата:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(288, 62)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(77, 13)
        Me.Label10.TabIndex = 36
        Me.Label10.Text = "Комментарий"
        '
        'rtbPaymentComment
        '
        Me.rtbPaymentComment.Location = New System.Drawing.Point(291, 81)
        Me.rtbPaymentComment.Name = "rtbPaymentComment"
        Me.rtbPaymentComment.Size = New System.Drawing.Size(233, 61)
        Me.rtbPaymentComment.TabIndex = 35
        Me.rtbPaymentComment.Text = ""
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(10, 62)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(109, 13)
        Me.Label9.TabIndex = 34
        Me.Label9.Text = "Основание платежа"
        '
        'rtbPaymentPurpose
        '
        Me.rtbPaymentPurpose.Location = New System.Drawing.Point(13, 81)
        Me.rtbPaymentPurpose.Name = "rtbPaymentPurpose"
        Me.rtbPaymentPurpose.Size = New System.Drawing.Size(248, 61)
        Me.rtbPaymentPurpose.TabIndex = 33
        Me.rtbPaymentPurpose.Text = ""
        '
        'PaidTimeDateTimePicker
        '
        Me.PaidTimeDateTimePicker.Location = New System.Drawing.Point(59, 35)
        Me.PaidTimeDateTimePicker.Name = "PaidTimeDateTimePicker"
        Me.PaidTimeDateTimePicker.Size = New System.Drawing.Size(118, 20)
        Me.PaidTimeDateTimePicker.TabIndex = 32
        '
        'tbCreatePayment
        '
        Me.tbCreatePayment.Location = New System.Drawing.Point(13, 148)
        Me.tbCreatePayment.Name = "tbCreatePayment"
        Me.tbCreatePayment.Size = New System.Drawing.Size(262, 34)
        Me.tbCreatePayment.TabIndex = 39
        Me.tbCreatePayment.Text = "1. Создать платеж"
        Me.tbCreatePayment.UseVisualStyleBackColor = True
        '
        'btImportPayment
        '
        Me.btImportPayment.Location = New System.Drawing.Point(147, 203)
        Me.btImportPayment.Name = "btImportPayment"
        Me.btImportPayment.Size = New System.Drawing.Size(128, 23)
        Me.btImportPayment.TabIndex = 37
        Me.btImportPayment.Text = "Импорт платежа"
        Me.btImportPayment.UseVisualStyleBackColor = True
        '
        'tbPaymentName
        '
        Me.tbPaymentName.Location = New System.Drawing.Point(13, 206)
        Me.tbPaymentName.Name = "tbPaymentName"
        Me.tbPaymentName.Size = New System.Drawing.Size(128, 20)
        Me.tbPaymentName.TabIndex = 38
        '
        'cbGoPayment
        '
        Me.cbGoPayment.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.ClsEntityBindingSource, "UUID", True))
        Me.cbGoPayment.DataSource = Me.ClsEntityBindingSource
        Me.cbGoPayment.DisplayMember = "Name"
        Me.cbGoPayment.FormattingEnabled = True
        Me.cbGoPayment.Location = New System.Drawing.Point(323, 6)
        Me.cbGoPayment.Name = "cbGoPayment"
        Me.cbGoPayment.Size = New System.Drawing.Size(168, 21)
        Me.cbGoPayment.TabIndex = 40
        Me.cbGoPayment.ValueMember = "UUID"
        '
        'ClsEntityBindingSource
        '
        Me.ClsEntityBindingSource.DataSource = GetType(Service.iMoySkladDataProvider.clsEntity)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(194, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(120, 13)
        Me.Label1.TabIndex = 41
        Me.Label1.Text = "Куда поступил платеж"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 13)
        Me.Label2.TabIndex = 43
        Me.Label2.Text = "Сумма"
        '
        'tbAmount
        '
        Me.tbAmount.Location = New System.Drawing.Point(59, 8)
        Me.tbAmount.Name = "tbAmount"
        Me.tbAmount.Size = New System.Drawing.Size(58, 20)
        Me.tbAmount.TabIndex = 42
        '
        'cbCurrency
        '
        Me.cbCurrency.FormattingEnabled = True
        Me.cbCurrency.Items.AddRange(New Object() {"RUR", "USD", "EUR"})
        Me.cbCurrency.Location = New System.Drawing.Point(123, 8)
        Me.cbCurrency.Name = "cbCurrency"
        Me.cbCurrency.Size = New System.Drawing.Size(54, 21)
        Me.cbCurrency.TabIndex = 44
        '
        'btLinkDocuments
        '
        Me.btLinkDocuments.Location = New System.Drawing.Point(13, 263)
        Me.btLinkDocuments.Name = "btLinkDocuments"
        Me.btLinkDocuments.Size = New System.Drawing.Size(262, 36)
        Me.btLinkDocuments.TabIndex = 45
        Me.btLinkDocuments.Text = "2. Связать документы"
        Me.btLinkDocuments.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(125, 186)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(25, 13)
        Me.Label3.TabIndex = 46
        Me.Label3.Text = "или"
        '
        'ucPaymentDemand
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btLinkDocuments)
        Me.Controls.Add(Me.cbCurrency)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tbAmount)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cbGoPayment)
        Me.Controls.Add(Me.tbCreatePayment)
        Me.Controls.Add(Me.btImportPayment)
        Me.Controls.Add(Me.tbPaymentName)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.rtbPaymentComment)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.rtbPaymentPurpose)
        Me.Controls.Add(PaidTimeLabel)
        Me.Controls.Add(Me.PaidTimeDateTimePicker)
        Me.Name = "ucPaymentDemand"
        Me.Size = New System.Drawing.Size(651, 317)
        CType(Me.ClsEntityBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents rtbPaymentComment As System.Windows.Forms.RichTextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents rtbPaymentPurpose As System.Windows.Forms.RichTextBox
    Friend WithEvents PaidTimeDateTimePicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents tbCreatePayment As System.Windows.Forms.Button
    Friend WithEvents btImportPayment As System.Windows.Forms.Button
    Friend WithEvents tbPaymentName As System.Windows.Forms.TextBox
    Friend WithEvents cbGoPayment As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tbAmount As System.Windows.Forms.TextBox
    Friend WithEvents cbCurrency As System.Windows.Forms.ComboBox
    Friend WithEvents btLinkDocuments As System.Windows.Forms.Button
    Friend WithEvents ClsEntityBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
