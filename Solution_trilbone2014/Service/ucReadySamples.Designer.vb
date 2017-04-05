<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucReadySamples
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.tbRequest = New System.Windows.Forms.Button()
        Me.cbxTimeFilter = New System.Windows.Forms.ComboBox()
        Me.OnSale_DataGridView = New System.Windows.Forms.DataGridView()
        Me.ClsReadySamplesItemBindingSource = New System.Windows.Forms.BindingSource()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip()
        Me.УечеToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GhToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TitleImageDataGridViewImageColumn = New System.Windows.Forms.DataGridViewImageColumn()
        Me.MainNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ShotCodeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WarehouseDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BasePriceDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.OnSale_DataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ClsReadySamplesItemBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tbRequest
        '
        Me.tbRequest.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.tbRequest.Location = New System.Drawing.Point(147, 6)
        Me.tbRequest.Name = "tbRequest"
        Me.tbRequest.Size = New System.Drawing.Size(106, 28)
        Me.tbRequest.TabIndex = 0
        Me.tbRequest.Text = "Запрос"
        Me.tbRequest.UseVisualStyleBackColor = True
        '
        'cbxTimeFilter
        '
        Me.cbxTimeFilter.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbxTimeFilter.FormattingEnabled = True
        Me.cbxTimeFilter.Location = New System.Drawing.Point(3, 9)
        Me.cbxTimeFilter.Name = "cbxTimeFilter"
        Me.cbxTimeFilter.Size = New System.Drawing.Size(138, 21)
        Me.cbxTimeFilter.TabIndex = 1
        '
        'OnSale_DataGridView
        '
        Me.OnSale_DataGridView.AllowUserToAddRows = False
        Me.OnSale_DataGridView.AllowUserToDeleteRows = False
        Me.OnSale_DataGridView.AutoGenerateColumns = False
        Me.OnSale_DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.OnSale_DataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TitleImageDataGridViewImageColumn, Me.MainNameDataGridViewTextBoxColumn, Me.ShotCodeDataGridViewTextBoxColumn, Me.WarehouseDataGridViewTextBoxColumn, Me.BasePriceDataGridViewTextBoxColumn})
        Me.TableLayoutPanel1.SetColumnSpan(Me.OnSale_DataGridView, 2)
        Me.OnSale_DataGridView.DataSource = Me.ClsReadySamplesItemBindingSource
        Me.OnSale_DataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.OnSale_DataGridView.Location = New System.Drawing.Point(3, 43)
        Me.OnSale_DataGridView.Name = "OnSale_DataGridView"
        Me.OnSale_DataGridView.RowHeadersWidth = 20
        Me.OnSale_DataGridView.RowTemplate.Height = 100
        Me.OnSale_DataGridView.Size = New System.Drawing.Size(549, 241)
        Me.OnSale_DataGridView.TabIndex = 2
        '
        'ClsReadySamplesItemBindingSource
        '
        Me.ClsReadySamplesItemBindingSource.DataSource = GetType(Service.clsReadySamplesItem)
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 74.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.cbxTimeFilter, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.OnSale_DataGridView, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.tbRequest, 1, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(555, 287)
        Me.TableLayoutPanel1.TabIndex = 3
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.УечеToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(100, 26)
        '
        'УечеToolStripMenuItem
        '
        Me.УечеToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GhToolStripMenuItem})
        Me.УечеToolStripMenuItem.ForeColor = System.Drawing.Color.Red
        Me.УечеToolStripMenuItem.Name = "УечеToolStripMenuItem"
        Me.УечеToolStripMenuItem.Size = New System.Drawing.Size(99, 22)
        Me.УечеToolStripMenuItem.Text = "уече"
        '
        'GhToolStripMenuItem
        '
        Me.GhToolStripMenuItem.Name = "GhToolStripMenuItem"
        Me.GhToolStripMenuItem.Size = New System.Drawing.Size(88, 22)
        Me.GhToolStripMenuItem.Text = "gh"
        '
        'TitleImageDataGridViewImageColumn
        '
        Me.TitleImageDataGridViewImageColumn.DataPropertyName = "TitleImage"
        Me.TitleImageDataGridViewImageColumn.Frozen = True
        Me.TitleImageDataGridViewImageColumn.HeaderText = "Фото"
        Me.TitleImageDataGridViewImageColumn.Image = Global.Service.My.Resources.Resource.noimage
        Me.TitleImageDataGridViewImageColumn.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom
        Me.TitleImageDataGridViewImageColumn.Name = "TitleImageDataGridViewImageColumn"
        '
        'MainNameDataGridViewTextBoxColumn
        '
        Me.MainNameDataGridViewTextBoxColumn.DataPropertyName = "MainName"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.MainNameDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle1
        Me.MainNameDataGridViewTextBoxColumn.Frozen = True
        Me.MainNameDataGridViewTextBoxColumn.HeaderText = "Название"
        Me.MainNameDataGridViewTextBoxColumn.Name = "MainNameDataGridViewTextBoxColumn"
        Me.MainNameDataGridViewTextBoxColumn.Width = 200
        '
        'ShotCodeDataGridViewTextBoxColumn
        '
        Me.ShotCodeDataGridViewTextBoxColumn.DataPropertyName = "ShotCode"
        Me.ShotCodeDataGridViewTextBoxColumn.Frozen = True
        Me.ShotCodeDataGridViewTextBoxColumn.HeaderText = "Код"
        Me.ShotCodeDataGridViewTextBoxColumn.Name = "ShotCodeDataGridViewTextBoxColumn"
        Me.ShotCodeDataGridViewTextBoxColumn.Width = 110
        '
        'WarehouseDataGridViewTextBoxColumn
        '
        Me.WarehouseDataGridViewTextBoxColumn.DataPropertyName = "Warehouse"
        Me.WarehouseDataGridViewTextBoxColumn.HeaderText = "Склад"
        Me.WarehouseDataGridViewTextBoxColumn.Name = "WarehouseDataGridViewTextBoxColumn"
        Me.WarehouseDataGridViewTextBoxColumn.Width = 75
        '
        'BasePriceDataGridViewTextBoxColumn
        '
        Me.BasePriceDataGridViewTextBoxColumn.DataPropertyName = "BasePrice"
        Me.BasePriceDataGridViewTextBoxColumn.HeaderText = "Розница"
        Me.BasePriceDataGridViewTextBoxColumn.Name = "BasePriceDataGridViewTextBoxColumn"
        Me.BasePriceDataGridViewTextBoxColumn.Width = 95
        '
        'ucReadySamples
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "ucReadySamples"
        Me.Size = New System.Drawing.Size(555, 287)
        CType(Me.OnSale_DataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ClsReadySamplesItemBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tbRequest As System.Windows.Forms.Button
    Friend WithEvents cbxTimeFilter As System.Windows.Forms.ComboBox
    Friend WithEvents OnSale_DataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents ClsReadySamplesItemBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents УечеToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GhToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TitleImageDataGridViewImageColumn As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents MainNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShotCodeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WarehouseDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BasePriceDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
