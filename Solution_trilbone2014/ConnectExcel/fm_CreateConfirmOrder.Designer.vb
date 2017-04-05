<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fm_CreateConfirmOrder
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
        Me.cb_clients = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.bt_newClient = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtp_OrderDate = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cb_Currency = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tb_Order_total = New System.Windows.Forms.TextBox()
        Me.btCreate_Order = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.btSelect_Order = New System.Windows.Forms.Button()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cb_clients
        '
        Me.cb_clients.FormattingEnabled = True
        Me.cb_clients.Location = New System.Drawing.Point(89, 22)
        Me.cb_clients.Name = "cb_clients"
        Me.cb_clients.Size = New System.Drawing.Size(121, 21)
        Me.cb_clients.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Клиент"
        '
        'bt_newClient
        '
        Me.bt_newClient.Location = New System.Drawing.Point(226, 19)
        Me.bt_newClient.Name = "bt_newClient"
        Me.bt_newClient.Size = New System.Drawing.Size(75, 23)
        Me.bt_newClient.TabIndex = 2
        Me.bt_newClient.Text = "новый.."
        Me.bt_newClient.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "дата"
        '
        'dtp_OrderDate
        '
        Me.dtp_OrderDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_OrderDate.Location = New System.Drawing.Point(89, 49)
        Me.dtp_OrderDate.Name = "dtp_OrderDate"
        Me.dtp_OrderDate.Size = New System.Drawing.Size(88, 20)
        Me.dtp_OrderDate.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 78)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "валюта"
        '
        'cb_Currency
        '
        Me.cb_Currency.FormattingEnabled = True
        Me.cb_Currency.Items.AddRange(New Object() {"USD", "EUR", "RUR", "DM"})
        Me.cb_Currency.Location = New System.Drawing.Point(89, 75)
        Me.cb_Currency.Name = "cb_Currency"
        Me.cb_Currency.Size = New System.Drawing.Size(55, 21)
        Me.cb_Currency.TabIndex = 6
        Me.cb_Currency.Text = "USD"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 102)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "сумма"
        '
        'tb_Order_total
        '
        Me.tb_Order_total.Location = New System.Drawing.Point(89, 102)
        Me.tb_Order_total.Name = "tb_Order_total"
        Me.tb_Order_total.Size = New System.Drawing.Size(68, 20)
        Me.tb_Order_total.TabIndex = 8
        '
        'btCreate_Order
        '
        Me.btCreate_Order.Location = New System.Drawing.Point(15, 144)
        Me.btCreate_Order.Name = "btCreate_Order"
        Me.btCreate_Order.Size = New System.Drawing.Size(75, 23)
        Me.btCreate_Order.TabIndex = 9
        Me.btCreate_Order.Text = "Создать.."
        Me.btCreate_Order.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cb_Currency)
        Me.GroupBox1.Controls.Add(Me.cb_clients)
        Me.GroupBox1.Controls.Add(Me.bt_newClient)
        Me.GroupBox1.Controls.Add(Me.btCreate_Order)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.tb_Order_total)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.dtp_OrderDate)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(273, 7)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(307, 182)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "новая продажа"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4})
        Me.DataGridView1.Location = New System.Drawing.Point(12, 12)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(240, 177)
        Me.DataGridView1.TabIndex = 12
        '
        'btSelect_Order
        '
        Me.btSelect_Order.Location = New System.Drawing.Point(12, 197)
        Me.btSelect_Order.Name = "btSelect_Order"
        Me.btSelect_Order.Size = New System.Drawing.Size(75, 23)
        Me.btSelect_Order.TabIndex = 13
        Me.btSelect_Order.Text = "выбрать.."
        Me.btSelect_Order.UseVisualStyleBackColor = True
        '
        'Column1
        '
        Me.Column1.HeaderText = "Client"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.HeaderText = "Date"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column3
        '
        Me.Column3.HeaderText = "curr"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column4
        '
        Me.Column4.HeaderText = "sum"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 225)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(587, 22)
        Me.StatusStrip1.TabIndex = 14
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(41, 17)
        Me.ToolStripStatusLabel1.Text = "статус"
        '
        'fm_CreateConfirmOrder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(587, 247)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.btSelect_Order)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "fm_CreateConfirmOrder"
        Me.Text = "fm_CreateConfirmOrder"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cb_clients As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents bt_newClient As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtp_OrderDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cb_Currency As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tb_Order_total As System.Windows.Forms.TextBox
    Friend WithEvents btCreate_Order As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btSelect_Order As System.Windows.Forms.Button
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
End Class
