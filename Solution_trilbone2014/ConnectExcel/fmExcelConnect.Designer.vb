<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fmExcelConnect
    Inherits System.Windows.Forms.Form

  

    'Является обязательной для конструктора форм Windows Forms
    Private components As System.ComponentModel.IContainer

    'Примечание: следующая процедура является обязательной для конструктора форм Windows Forms
    'Для ее изменения используйте конструктор форм Windows Form.  
    'Не изменяйте ее в редакторе исходного кода.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fmExcelConnect))
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.btOpenFile = New System.Windows.Forms.Button()
        Me.btReloadData = New System.Windows.Forms.Button()
        Me.Uc_Sample_data1 = New ConnectExcel.uc_Sample_data()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btCloseBook = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(290, 71)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(721, 767)
        Me.DataGridView1.TabIndex = 0
        '
        'btOpenFile
        '
        Me.btOpenFile.Location = New System.Drawing.Point(290, 13)
        Me.btOpenFile.Name = "btOpenFile"
        Me.btOpenFile.Size = New System.Drawing.Size(127, 23)
        Me.btOpenFile.TabIndex = 3
        Me.btOpenFile.Text = "открыть книгу.."
        Me.btOpenFile.UseVisualStyleBackColor = True
        '
        'btReloadData
        '
        Me.btReloadData.Location = New System.Drawing.Point(0, 0)
        Me.btReloadData.Name = "btReloadData"
        Me.btReloadData.Size = New System.Drawing.Size(75, 23)
        Me.btReloadData.TabIndex = 0
        '
        'Uc_Sample_data1
        '
        Me.Uc_Sample_data1.ColumnsCount = 0
        Me.Uc_Sample_data1.Data = New String() {""}
        Me.Uc_Sample_data1.Location = New System.Drawing.Point(1, 12)
        Me.Uc_Sample_data1.Name = "Uc_Sample_data1"
        Me.Uc_Sample_data1.Size = New System.Drawing.Size(283, 826)
        Me.Uc_Sample_data1.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoEllipsis = True
        Me.Label1.Location = New System.Drawing.Point(423, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(588, 59)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = resources.GetString("Label1.Text")
        '
        'btCloseBook
        '
        Me.btCloseBook.Location = New System.Drawing.Point(290, 45)
        Me.btCloseBook.Name = "btCloseBook"
        Me.btCloseBook.Size = New System.Drawing.Size(127, 23)
        Me.btCloseBook.TabIndex = 7
        Me.btCloseBook.Text = "закрыть книгу.."
        Me.btCloseBook.UseVisualStyleBackColor = True
        '
        'fmExcelConnect
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1023, 850)
        Me.Controls.Add(Me.btCloseBook)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Uc_Sample_data1)
        Me.Controls.Add(Me.btOpenFile)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "fmExcelConnect"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form_trilobites_info"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents btOpenFile As System.Windows.Forms.Button
    Friend WithEvents Uc_Sample_data1 As uc_Sample_data
    Friend WithEvents btReloadData As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btCloseBook As System.Windows.Forms.Button
End Class
