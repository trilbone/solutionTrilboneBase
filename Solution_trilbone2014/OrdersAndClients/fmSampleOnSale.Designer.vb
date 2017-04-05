<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fmSampleOnSale
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim SampleNumberLabel As System.Windows.Forms.Label
        Dim CostsLabel As System.Windows.Forms.Label
        Dim CurrencyNameLabel As System.Windows.Forms.Label
        Dim RateOfExchangeLabel As System.Windows.Forms.Label
        Dim BasePriceLabel As System.Windows.Forms.Label
        Dim Label15 As System.Windows.Forms.Label
        Me.SampleNumberTextBox = New System.Windows.Forms.TextBox()
        Me.Select_tb_SamplesOnSaleBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dsSampleOnSale = New OrdersAndClients.SampleOnSale()
        Me.CostsTextBox = New System.Windows.Forms.TextBox()
        Me.CurrencyNameComboBox = New System.Windows.Forms.ComboBox()
        Me.RateOfExchangeTextBox = New System.Windows.Forms.TextBox()
        Me.gbFinance = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.SoldPriceTextBox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.FreeShippingPossibleFlagCheckBox = New System.Windows.Forms.CheckBox()
        Me.BasePriceTextBox = New System.Windows.Forms.TextBox()
        Me.BtSave = New System.Windows.Forms.Button()
        Me.BtCancel = New System.Windows.Forms.Button()
        Me.BtSampleData = New System.Windows.Forms.Button()
        Me.btClose = New System.Windows.Forms.Button()
        Me.Select_tb_SamplesOnSaleTableAdapter = New OrdersAndClients.SampleOnSaleTableAdapters.Select_tb_SamplesOnSaleTableAdapter()
        Me.TableAdapterManager = New OrdersAndClients.SampleOnSaleTableAdapters.TableAdapterManager()
        SampleNumberLabel = New System.Windows.Forms.Label()
        CostsLabel = New System.Windows.Forms.Label()
        CurrencyNameLabel = New System.Windows.Forms.Label()
        RateOfExchangeLabel = New System.Windows.Forms.Label()
        BasePriceLabel = New System.Windows.Forms.Label()
        Label15 = New System.Windows.Forms.Label()
        CType(Me.Select_tb_SamplesOnSaleBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsSampleOnSale, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbFinance.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SampleNumberLabel
        '
        SampleNumberLabel.AutoSize = True
        SampleNumberLabel.Location = New System.Drawing.Point(12, 9)
        SampleNumberLabel.Name = "SampleNumberLabel"
        SampleNumberLabel.Size = New System.Drawing.Size(89, 13)
        SampleNumberLabel.TabIndex = 2
        SampleNumberLabel.Text = "Номер образца:"
        '
        'CostsLabel
        '
        CostsLabel.AutoSize = True
        CostsLabel.Location = New System.Drawing.Point(3, 0)
        CostsLabel.Name = "CostsLabel"
        CostsLabel.Size = New System.Drawing.Size(89, 13)
        CostsLabel.TabIndex = 5
        CostsLabel.Text = "Себестоимость:"
        '
        'CurrencyNameLabel
        '
        CurrencyNameLabel.AutoSize = True
        CurrencyNameLabel.Location = New System.Drawing.Point(11, 22)
        CurrencyNameLabel.Name = "CurrencyNameLabel"
        CurrencyNameLabel.Size = New System.Drawing.Size(48, 13)
        CurrencyNameLabel.TabIndex = 8
        CurrencyNameLabel.Text = "Валюта:"
        '
        'RateOfExchangeLabel
        '
        RateOfExchangeLabel.AutoSize = True
        RateOfExchangeLabel.Location = New System.Drawing.Point(10, 47)
        RateOfExchangeLabel.Name = "RateOfExchangeLabel"
        RateOfExchangeLabel.Size = New System.Drawing.Size(75, 13)
        RateOfExchangeLabel.TabIndex = 10
        RateOfExchangeLabel.Text = "Курс обмена:"
        '
        'BasePriceLabel
        '
        BasePriceLabel.AutoSize = True
        BasePriceLabel.Location = New System.Drawing.Point(3, 56)
        BasePriceLabel.Name = "BasePriceLabel"
        BasePriceLabel.Size = New System.Drawing.Size(54, 13)
        BasePriceLabel.TabIndex = 15
        BasePriceLabel.Text = "Продано:"
        '
        'Label15
        '
        Label15.AutoSize = True
        Label15.Location = New System.Drawing.Point(3, 28)
        Label15.Name = "Label15"
        Label15.Size = New System.Drawing.Size(53, 13)
        Label15.TabIndex = 18
        Label15.Text = "Розница:"
        '
        'SampleNumberTextBox
        '
        Me.SampleNumberTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Select_tb_SamplesOnSaleBindingSource, "SampleNumber", True))
        Me.SampleNumberTextBox.Location = New System.Drawing.Point(103, 6)
        Me.SampleNumberTextBox.Name = "SampleNumberTextBox"
        Me.SampleNumberTextBox.Size = New System.Drawing.Size(146, 20)
        Me.SampleNumberTextBox.TabIndex = 3
        '
        'Select_tb_SamplesOnSaleBindingSource
        '
        Me.Select_tb_SamplesOnSaleBindingSource.DataMember = "Select_tb_SamplesOnSale"
        Me.Select_tb_SamplesOnSaleBindingSource.DataSource = Me.dsSampleOnSale
        '
        'dsSampleOnSale
        '
        Me.dsSampleOnSale.DataSetName = "SampleOnSale"
        Me.dsSampleOnSale.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'CostsTextBox
        '
        Me.CostsTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Select_tb_SamplesOnSaleBindingSource, "Costs", True))
        Me.CostsTextBox.Location = New System.Drawing.Point(103, 3)
        Me.CostsTextBox.Name = "CostsTextBox"
        Me.CostsTextBox.Size = New System.Drawing.Size(80, 20)
        Me.CostsTextBox.TabIndex = 6
        '
        'CurrencyNameComboBox
        '
        Me.CurrencyNameComboBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Select_tb_SamplesOnSaleBindingSource, "CurrencyName", True))
        Me.CurrencyNameComboBox.FormattingEnabled = True
        Me.CurrencyNameComboBox.Location = New System.Drawing.Point(91, 18)
        Me.CurrencyNameComboBox.Name = "CurrencyNameComboBox"
        Me.CurrencyNameComboBox.Size = New System.Drawing.Size(57, 21)
        Me.CurrencyNameComboBox.TabIndex = 9
        '
        'RateOfExchangeTextBox
        '
        Me.RateOfExchangeTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Select_tb_SamplesOnSaleBindingSource, "RateOfExchange", True))
        Me.RateOfExchangeTextBox.Location = New System.Drawing.Point(91, 42)
        Me.RateOfExchangeTextBox.Name = "RateOfExchangeTextBox"
        Me.RateOfExchangeTextBox.Size = New System.Drawing.Size(57, 20)
        Me.RateOfExchangeTextBox.TabIndex = 11
        '
        'gbFinance
        '
        Me.gbFinance.Controls.Add(Me.TableLayoutPanel1)
        Me.gbFinance.Controls.Add(RateOfExchangeLabel)
        Me.gbFinance.Controls.Add(Me.RateOfExchangeTextBox)
        Me.gbFinance.Controls.Add(CurrencyNameLabel)
        Me.gbFinance.Controls.Add(Me.CurrencyNameComboBox)
        Me.gbFinance.Location = New System.Drawing.Point(15, 32)
        Me.gbFinance.Name = "gbFinance"
        Me.gbFinance.Size = New System.Drawing.Size(369, 137)
        Me.gbFinance.TabIndex = 12
        Me.gbFinance.TabStop = False
        Me.gbFinance.Text = "Финансы"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(CostsLabel, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.SoldPriceTextBox, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.CostsTextBox, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(BasePriceLabel, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Label15, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.FreeShippingPossibleFlagCheckBox, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.BasePriceTextBox, 1, 1)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(163, 18)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(200, 114)
        Me.TableLayoutPanel1.TabIndex = 15
        '
        'SoldPriceTextBox
        '
        Me.SoldPriceTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Select_tb_SamplesOnSaleBindingSource, "SoldPrice", True))
        Me.SoldPriceTextBox.Location = New System.Drawing.Point(103, 59)
        Me.SoldPriceTextBox.Name = "SoldPriceTextBox"
        Me.SoldPriceTextBox.Size = New System.Drawing.Size(80, 20)
        Me.SoldPriceTextBox.TabIndex = 16
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 84)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 13)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Free Shipping"
        '
        'FreeShippingPossibleFlagCheckBox
        '
        Me.FreeShippingPossibleFlagCheckBox.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.Select_tb_SamplesOnSaleBindingSource, "FreeShippingPossibleFlag", True))
        Me.FreeShippingPossibleFlagCheckBox.Location = New System.Drawing.Point(103, 87)
        Me.FreeShippingPossibleFlagCheckBox.Name = "FreeShippingPossibleFlagCheckBox"
        Me.FreeShippingPossibleFlagCheckBox.Size = New System.Drawing.Size(37, 22)
        Me.FreeShippingPossibleFlagCheckBox.TabIndex = 14
        Me.FreeShippingPossibleFlagCheckBox.UseVisualStyleBackColor = True
        '
        'BasePriceTextBox
        '
        Me.BasePriceTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Select_tb_SamplesOnSaleBindingSource, "BasePrice", True))
        Me.BasePriceTextBox.Location = New System.Drawing.Point(103, 31)
        Me.BasePriceTextBox.Name = "BasePriceTextBox"
        Me.BasePriceTextBox.Size = New System.Drawing.Size(80, 20)
        Me.BasePriceTextBox.TabIndex = 16
        '
        'BtSave
        '
        Me.BtSave.Location = New System.Drawing.Point(33, 188)
        Me.BtSave.Name = "BtSave"
        Me.BtSave.Size = New System.Drawing.Size(98, 23)
        Me.BtSave.TabIndex = 14
        Me.BtSave.Text = "Сохранить"
        Me.BtSave.UseVisualStyleBackColor = True
        '
        'BtCancel
        '
        Me.BtCancel.Location = New System.Drawing.Point(150, 188)
        Me.BtCancel.Name = "BtCancel"
        Me.BtCancel.Size = New System.Drawing.Size(98, 23)
        Me.BtCancel.TabIndex = 15
        Me.BtCancel.Text = "Отменить"
        Me.BtCancel.UseVisualStyleBackColor = True
        '
        'BtSampleData
        '
        Me.BtSampleData.Location = New System.Drawing.Point(270, 6)
        Me.BtSampleData.Name = "BtSampleData"
        Me.BtSampleData.Size = New System.Drawing.Size(114, 23)
        Me.BtSampleData.TabIndex = 16
        Me.BtSampleData.Text = "Данные образца.."
        Me.BtSampleData.UseVisualStyleBackColor = True
        '
        'btClose
        '
        Me.btClose.Location = New System.Drawing.Point(263, 188)
        Me.btClose.Name = "btClose"
        Me.btClose.Size = New System.Drawing.Size(98, 23)
        Me.btClose.TabIndex = 17
        Me.btClose.Text = "Закрыть"
        Me.btClose.UseVisualStyleBackColor = True
        '
        'Select_tb_SamplesOnSaleTableAdapter
        '
        Me.Select_tb_SamplesOnSaleTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.Select_tb_SamplesOnSaleTableAdapter = Me.Select_tb_SamplesOnSaleTableAdapter
        Me.TableAdapterManager.UpdateOrder = OrdersAndClients.SampleOnSaleTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'fmSampleOnSale
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(412, 221)
        Me.Controls.Add(Me.btClose)
        Me.Controls.Add(Me.BtSampleData)
        Me.Controls.Add(Me.BtCancel)
        Me.Controls.Add(Me.BtSave)
        Me.Controls.Add(Me.gbFinance)
        Me.Controls.Add(SampleNumberLabel)
        Me.Controls.Add(Me.SampleNumberTextBox)
        Me.Name = "fmSampleOnSale"
        Me.Text = "Готовность к продаже"
        CType(Me.Select_tb_SamplesOnSaleBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsSampleOnSale, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbFinance.ResumeLayout(False)
        Me.gbFinance.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dsSampleOnSale As SampleOnSale
    Friend WithEvents Select_tb_SamplesOnSaleBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Select_tb_SamplesOnSaleTableAdapter As SampleOnSaleTableAdapters.Select_tb_SamplesOnSaleTableAdapter
    Friend WithEvents TableAdapterManager As SampleOnSaleTableAdapters.TableAdapterManager
    Friend WithEvents SampleNumberTextBox As System.Windows.Forms.TextBox
    Friend WithEvents CostsTextBox As System.Windows.Forms.TextBox
    Friend WithEvents CurrencyNameComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents RateOfExchangeTextBox As System.Windows.Forms.TextBox
    Friend WithEvents gbFinance As System.Windows.Forms.GroupBox
    Friend WithEvents BtSave As System.Windows.Forms.Button
    Friend WithEvents BtCancel As System.Windows.Forms.Button
    Friend WithEvents BtSampleData As System.Windows.Forms.Button
    Friend WithEvents FreeShippingPossibleFlagCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents btClose As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents BasePriceTextBox As System.Windows.Forms.TextBox
    Friend WithEvents SoldPriceTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
