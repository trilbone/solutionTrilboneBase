<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucLocationInfo
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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.StrGoodMapQtyBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.IsArticulDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ActualCodeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.QtyDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UomNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WareNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SlotNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StrGoodMapQtyBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IsArticulDataGridViewCheckBoxColumn, Me.ActualCodeDataGridViewTextBoxColumn, Me.QtyDataGridViewTextBoxColumn, Me.UomNameDataGridViewTextBoxColumn, Me.WareNameDataGridViewTextBoxColumn, Me.SlotNameDataGridViewTextBoxColumn})
        Me.DataGridView1.DataSource = Me.StrGoodMapQtyBindingSource
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Top
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(436, 120)
        Me.DataGridView1.TabIndex = 0
        '
        'StrGoodMapQtyBindingSource
        '
        Me.StrGoodMapQtyBindingSource.DataSource = GetType(Service.iMoySkladDataProvider.strGoodMapQty)
        '
        'IsArticulDataGridViewCheckBoxColumn
        '
        Me.IsArticulDataGridViewCheckBoxColumn.DataPropertyName = "IsArticul"
        Me.IsArticulDataGridViewCheckBoxColumn.HeaderText = "Артикул"
        Me.IsArticulDataGridViewCheckBoxColumn.Name = "IsArticulDataGridViewCheckBoxColumn"
        Me.IsArticulDataGridViewCheckBoxColumn.ReadOnly = True
        Me.IsArticulDataGridViewCheckBoxColumn.Width = 50
        '
        'ActualCodeDataGridViewTextBoxColumn
        '
        Me.ActualCodeDataGridViewTextBoxColumn.DataPropertyName = "ActualCode"
        Me.ActualCodeDataGridViewTextBoxColumn.HeaderText = ""
        Me.ActualCodeDataGridViewTextBoxColumn.Name = "ActualCodeDataGridViewTextBoxColumn"
        Me.ActualCodeDataGridViewTextBoxColumn.ReadOnly = True
        Me.ActualCodeDataGridViewTextBoxColumn.Width = 50
        '
        'QtyDataGridViewTextBoxColumn
        '
        Me.QtyDataGridViewTextBoxColumn.DataPropertyName = "Qty"
        Me.QtyDataGridViewTextBoxColumn.HeaderText = "Qty"
        Me.QtyDataGridViewTextBoxColumn.Name = "QtyDataGridViewTextBoxColumn"
        Me.QtyDataGridViewTextBoxColumn.Width = 50
        '
        'UomNameDataGridViewTextBoxColumn
        '
        Me.UomNameDataGridViewTextBoxColumn.DataPropertyName = "UomName"
        Me.UomNameDataGridViewTextBoxColumn.HeaderText = ""
        Me.UomNameDataGridViewTextBoxColumn.Name = "UomNameDataGridViewTextBoxColumn"
        Me.UomNameDataGridViewTextBoxColumn.Width = 30
        '
        'WareNameDataGridViewTextBoxColumn
        '
        Me.WareNameDataGridViewTextBoxColumn.DataPropertyName = "WareName"
        Me.WareNameDataGridViewTextBoxColumn.HeaderText = "склад"
        Me.WareNameDataGridViewTextBoxColumn.Name = "WareNameDataGridViewTextBoxColumn"
        Me.WareNameDataGridViewTextBoxColumn.Width = 140
        '
        'SlotNameDataGridViewTextBoxColumn
        '
        Me.SlotNameDataGridViewTextBoxColumn.DataPropertyName = "SlotName"
        Me.SlotNameDataGridViewTextBoxColumn.HeaderText = "Ячейка"
        Me.SlotNameDataGridViewTextBoxColumn.Name = "SlotNameDataGridViewTextBoxColumn"
        Me.SlotNameDataGridViewTextBoxColumn.Width = 70
        '
        'ucLocationInfo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "ucLocationInfo"
        Me.Size = New System.Drawing.Size(436, 154)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StrGoodMapQtyBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents StrGoodMapQtyBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents IsArticulDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ActualCodeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QtyDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UomNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WareNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SlotNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
