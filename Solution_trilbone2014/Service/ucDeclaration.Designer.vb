<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucDeclaration
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
        Dim ReturnSpeedLabel As System.Windows.Forms.Label
        Dim InstructionfornondeliveryLabel As System.Windows.Forms.Label
        Dim ContentLabel As System.Windows.Forms.Label
        Dim DeclarationcurrencyLabel As System.Windows.Forms.Label
        Me.IMoySkladDataProvider_DeclarationItemBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.btRemoveDeclaredGood = New System.Windows.Forms.Button()
        Me.btAddDeclaredGood = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.IMoySkladDataProvider_DeclarationItemDataGridView = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IMoySkladDataProvider_Declaration_CP71_CN23BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.EmReturnSpeedBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.EmDeclaredContentBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.EmCurrencyListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.EmInstructionfornondeliveryBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ReturnSpeedComboBox = New System.Windows.Forms.ComboBox()
        Me.InstructionfornondeliveryComboBox = New System.Windows.Forms.ComboBox()
        Me.ContentComboBox = New System.Windows.Forms.ComboBox()
        Me.DeclarationcurrencyComboBox = New System.Windows.Forms.ComboBox()
        Me.IMoySkladDataProvider_AddressBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cbReturnAddress = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        ReturnSpeedLabel = New System.Windows.Forms.Label()
        InstructionfornondeliveryLabel = New System.Windows.Forms.Label()
        ContentLabel = New System.Windows.Forms.Label()
        DeclarationcurrencyLabel = New System.Windows.Forms.Label()
        CType(Me.IMoySkladDataProvider_DeclarationItemBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IMoySkladDataProvider_DeclarationItemDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IMoySkladDataProvider_Declaration_CP71_CN23BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmReturnSpeedBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmDeclaredContentBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmCurrencyListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmInstructionfornondeliveryBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IMoySkladDataProvider_AddressBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReturnSpeedLabel
        '
        ReturnSpeedLabel.AutoSize = True
        ReturnSpeedLabel.Location = New System.Drawing.Point(322, 72)
        ReturnSpeedLabel.Name = "ReturnSpeedLabel"
        ReturnSpeedLabel.Size = New System.Drawing.Size(108, 13)
        ReturnSpeedLabel.TabIndex = 53
        ReturnSpeedLabel.Text = "Скорость возврата:"
        '
        'InstructionfornondeliveryLabel
        '
        InstructionfornondeliveryLabel.AutoSize = True
        InstructionfornondeliveryLabel.Location = New System.Drawing.Point(331, 44)
        InstructionfornondeliveryLabel.Name = "InstructionfornondeliveryLabel"
        InstructionfornondeliveryLabel.Size = New System.Drawing.Size(99, 13)
        InstructionfornondeliveryLabel.TabIndex = 52
        InstructionfornondeliveryLabel.Text = "Возврат посылки:"
        '
        'ContentLabel
        '
        ContentLabel.AutoSize = True
        ContentLabel.Location = New System.Drawing.Point(355, 16)
        ContentLabel.Name = "ContentLabel"
        ContentLabel.Size = New System.Drawing.Size(75, 13)
        ContentLabel.TabIndex = 50
        ContentLabel.Text = "Содержимое:"
        '
        'DeclarationcurrencyLabel
        '
        DeclarationcurrencyLabel.AutoSize = True
        DeclarationcurrencyLabel.Location = New System.Drawing.Point(491, 151)
        DeclarationcurrencyLabel.Name = "DeclarationcurrencyLabel"
        DeclarationcurrencyLabel.Size = New System.Drawing.Size(111, 13)
        DeclarationcurrencyLabel.TabIndex = 58
        DeclarationcurrencyLabel.Text = "Валюта декларации:"
        '
        'IMoySkladDataProvider_DeclarationItemBindingSource
        '
        Me.IMoySkladDataProvider_DeclarationItemBindingSource.DataSource = GetType(Service.iMoySkladDataProvider.clsDeclarationItem)
        '
        'btRemoveDeclaredGood
        '
        Me.btRemoveDeclaredGood.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btRemoveDeclaredGood.Location = New System.Drawing.Point(80, 134)
        Me.btRemoveDeclaredGood.Name = "btRemoveDeclaredGood"
        Me.btRemoveDeclaredGood.Size = New System.Drawing.Size(45, 40)
        Me.btRemoveDeclaredGood.TabIndex = 47
        Me.btRemoveDeclaredGood.Text = "-"
        Me.btRemoveDeclaredGood.UseVisualStyleBackColor = True
        '
        'btAddDeclaredGood
        '
        Me.btAddDeclaredGood.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btAddDeclaredGood.Location = New System.Drawing.Point(21, 134)
        Me.btAddDeclaredGood.Name = "btAddDeclaredGood"
        Me.btAddDeclaredGood.Size = New System.Drawing.Size(45, 40)
        Me.btAddDeclaredGood.TabIndex = 46
        Me.btAddDeclaredGood.Text = "+"
        Me.btAddDeclaredGood.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(261, 157)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(131, 13)
        Me.Label13.TabIndex = 49
        Me.Label13.Text = "Декларируемые товары"
        '
        'IMoySkladDataProvider_DeclarationItemDataGridView
        '
        Me.IMoySkladDataProvider_DeclarationItemDataGridView.AutoGenerateColumns = False
        Me.IMoySkladDataProvider_DeclarationItemDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.IMoySkladDataProvider_DeclarationItemDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn8, Me.DataGridViewTextBoxColumn9, Me.DataGridViewTextBoxColumn11})
        Me.IMoySkladDataProvider_DeclarationItemDataGridView.DataSource = Me.IMoySkladDataProvider_DeclarationItemBindingSource
        Me.IMoySkladDataProvider_DeclarationItemDataGridView.Location = New System.Drawing.Point(12, 180)
        Me.IMoySkladDataProvider_DeclarationItemDataGridView.Name = "IMoySkladDataProvider_DeclarationItemDataGridView"
        Me.IMoySkladDataProvider_DeclarationItemDataGridView.Size = New System.Drawing.Size(653, 132)
        Me.IMoySkladDataProvider_DeclarationItemDataGridView.TabIndex = 48
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "descriptionofContents"
        Me.DataGridViewTextBoxColumn6.HeaderText = "товар"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "quantity"
        Me.DataGridViewTextBoxColumn7.HeaderText = "кол-во"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "netweight"
        Me.DataGridViewTextBoxColumn8.HeaderText = "нетто(кг)"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "value"
        Me.DataGridViewTextBoxColumn9.HeaderText = "стоимость"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "countryoforigin"
        Me.DataGridViewTextBoxColumn11.HeaderText = "страна"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        '
        'IMoySkladDataProvider_Declaration_CP71_CN23BindingSource
        '
        Me.IMoySkladDataProvider_Declaration_CP71_CN23BindingSource.DataSource = GetType(Service.iMoySkladDataProvider.clsDeclaration_CP71_CN23)
        '
        'EmReturnSpeedBindingSource
        '
        Me.EmReturnSpeedBindingSource.DataSource = GetType(Service.iMoySkladDataProvider.emReturnSpeed)
        '
        'EmDeclaredContentBindingSource
        '
        Me.EmDeclaredContentBindingSource.DataSource = GetType(Service.iMoySkladDataProvider.emDeclaredContent)
        '
        'EmCurrencyListBindingSource
        '
        Me.EmCurrencyListBindingSource.DataSource = GetType(Service.clsApplicationTypes.emCurrencyList)
        '
        'EmInstructionfornondeliveryBindingSource
        '
        Me.EmInstructionfornondeliveryBindingSource.DataSource = GetType(Service.iMoySkladDataProvider.emInstructionfornondelivery)
        '
        'ReturnSpeedComboBox
        '
        Me.ReturnSpeedComboBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.IMoySkladDataProvider_Declaration_CP71_CN23BindingSource, "ReturnSpeed", True))
        Me.ReturnSpeedComboBox.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.IMoySkladDataProvider_Declaration_CP71_CN23BindingSource, "ReturnSpeed", True))
        Me.ReturnSpeedComboBox.DataSource = Me.EmReturnSpeedBindingSource
        Me.ReturnSpeedComboBox.FormattingEnabled = True
        Me.ReturnSpeedComboBox.Location = New System.Drawing.Point(435, 69)
        Me.ReturnSpeedComboBox.Name = "ReturnSpeedComboBox"
        Me.ReturnSpeedComboBox.Size = New System.Drawing.Size(230, 21)
        Me.ReturnSpeedComboBox.TabIndex = 55
        '
        'InstructionfornondeliveryComboBox
        '
        Me.InstructionfornondeliveryComboBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.IMoySkladDataProvider_Declaration_CP71_CN23BindingSource, "Instructionfornondelivery", True))
        Me.InstructionfornondeliveryComboBox.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.IMoySkladDataProvider_Declaration_CP71_CN23BindingSource, "Instructionfornondelivery", True))
        Me.InstructionfornondeliveryComboBox.DataSource = Me.EmInstructionfornondeliveryBindingSource
        Me.InstructionfornondeliveryComboBox.FormattingEnabled = True
        Me.InstructionfornondeliveryComboBox.Location = New System.Drawing.Point(435, 41)
        Me.InstructionfornondeliveryComboBox.Name = "InstructionfornondeliveryComboBox"
        Me.InstructionfornondeliveryComboBox.Size = New System.Drawing.Size(230, 21)
        Me.InstructionfornondeliveryComboBox.TabIndex = 54
        '
        'ContentComboBox
        '
        Me.ContentComboBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.IMoySkladDataProvider_Declaration_CP71_CN23BindingSource, "content", True))
        Me.ContentComboBox.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.IMoySkladDataProvider_Declaration_CP71_CN23BindingSource, "content", True))
        Me.ContentComboBox.DataSource = Me.EmDeclaredContentBindingSource
        Me.ContentComboBox.FormattingEnabled = True
        Me.ContentComboBox.Location = New System.Drawing.Point(435, 13)
        Me.ContentComboBox.Name = "ContentComboBox"
        Me.ContentComboBox.Size = New System.Drawing.Size(230, 21)
        Me.ContentComboBox.TabIndex = 51
        '
        'DeclarationcurrencyComboBox
        '
        Me.DeclarationcurrencyComboBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.IMoySkladDataProvider_Declaration_CP71_CN23BindingSource, "declarationcurrency", True))
        Me.DeclarationcurrencyComboBox.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.IMoySkladDataProvider_Declaration_CP71_CN23BindingSource, "declarationcurrency", True))
        Me.DeclarationcurrencyComboBox.DataSource = Me.EmCurrencyListBindingSource
        Me.DeclarationcurrencyComboBox.FormattingEnabled = True
        Me.DeclarationcurrencyComboBox.Location = New System.Drawing.Point(608, 147)
        Me.DeclarationcurrencyComboBox.Name = "DeclarationcurrencyComboBox"
        Me.DeclarationcurrencyComboBox.Size = New System.Drawing.Size(54, 21)
        Me.DeclarationcurrencyComboBox.TabIndex = 59
        '
        'IMoySkladDataProvider_AddressBindingSource
        '
        Me.IMoySkladDataProvider_AddressBindingSource.DataSource = GetType(Service.iMoySkladDataProvider.clsAddress)
        '
        'cbReturnAddress
        '
        Me.cbReturnAddress.FormattingEnabled = True
        Me.cbReturnAddress.Items.AddRange(New Object() {"Нарва офис", "Литвинов домашний", "Пахомов домашний", "Баракшин"})
        Me.cbReturnAddress.Location = New System.Drawing.Point(435, 97)
        Me.cbReturnAddress.Name = "cbReturnAddress"
        Me.cbReturnAddress.Size = New System.Drawing.Size(230, 21)
        Me.cbReturnAddress.TabIndex = 61
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(338, 100)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(91, 13)
        Me.Label11.TabIndex = 60
        Me.Label11.Text = "Адрес возврата:"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(21, 78)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(220, 46)
        Me.Button1.TabIndex = 62
        Me.Button1.Text = "Отправить посылку"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(12, 24)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(229, 21)
        Me.ComboBox1.TabIndex = 63
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(124, 13)
        Me.Label1.TabIndex = 64
        Me.Label1.Text = "Сотрудник на отправку"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(18, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 13)
        Me.Label2.TabIndex = 65
        Me.Label2.Text = "Отправить до"
        '
        'ucDeclaration
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.cbReturnAddress)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(DeclarationcurrencyLabel)
        Me.Controls.Add(Me.DeclarationcurrencyComboBox)
        Me.Controls.Add(ReturnSpeedLabel)
        Me.Controls.Add(Me.ReturnSpeedComboBox)
        Me.Controls.Add(InstructionfornondeliveryLabel)
        Me.Controls.Add(Me.InstructionfornondeliveryComboBox)
        Me.Controls.Add(ContentLabel)
        Me.Controls.Add(Me.ContentComboBox)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.IMoySkladDataProvider_DeclarationItemDataGridView)
        Me.Controls.Add(Me.btRemoveDeclaredGood)
        Me.Controls.Add(Me.btAddDeclaredGood)
        Me.Name = "ucDeclaration"
        Me.Size = New System.Drawing.Size(672, 321)
        CType(Me.IMoySkladDataProvider_DeclarationItemBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IMoySkladDataProvider_DeclarationItemDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IMoySkladDataProvider_Declaration_CP71_CN23BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmReturnSpeedBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmDeclaredContentBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmCurrencyListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmInstructionfornondeliveryBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IMoySkladDataProvider_AddressBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents IMoySkladDataProvider_DeclarationItemBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents btRemoveDeclaredGood As System.Windows.Forms.Button
    Friend WithEvents btAddDeclaredGood As System.Windows.Forms.Button
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents IMoySkladDataProvider_DeclarationItemDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IMoySkladDataProvider_Declaration_CP71_CN23BindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents EmReturnSpeedBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents EmDeclaredContentBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents EmCurrencyListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents EmInstructionfornondeliveryBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ReturnSpeedComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents InstructionfornondeliveryComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents ContentComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents DeclarationcurrencyComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents IMoySkladDataProvider_AddressBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents cbReturnAddress As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label

End Class
