<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uc_tierPrice
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
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbCurrency = New System.Windows.Forms.ComboBox()
        Me.tbPrice = New System.Windows.Forms.TextBox()
        Me.btAddInList = New System.Windows.Forms.Button()
        Me.lbTierPrices = New System.Windows.Forms.ListBox()
        Me.ClsTierPricesCollectionBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.lbBaseCurrency = New System.Windows.Forms.Label()
        Me.btRemovePrice = New System.Windows.Forms.Button()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.bs_tierPrice = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.cbx_callforprice = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.cbx_DisableBuyButton = New System.Windows.Forms.CheckBox()
        Me.Uc_langObjectRoles = New nopRestClient.uc_langObject()
        Me.Uc_langObjectStore = New nopRestClient.uc_langObject()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.ClsTierPricesCollectionBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.bs_tierPrice, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.TableLayoutPanel1)
        Me.FlowLayoutPanel1.Controls.Add(Me.TableLayoutPanel2)
        Me.FlowLayoutPanel1.Controls.Add(Me.Uc_langObjectRoles)
        Me.FlowLayoutPanel1.Controls.Add(Me.Uc_langObjectStore)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(1105, 169)
        Me.FlowLayoutPanel1.TabIndex = 0
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36.5!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 63.5!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 86.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cbCurrency, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.tbPrice, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btAddInList, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lbTierPrices, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lbBaseCurrency, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.btRemovePrice, 2, 1)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(200, 163)
        Me.TableLayoutPanel1.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(5, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Цена"
        '
        'cbCurrency
        '
        Me.cbCurrency.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cbCurrency.FormattingEnabled = True
        Me.cbCurrency.Location = New System.Drawing.Point(116, 3)
        Me.cbCurrency.Name = "cbCurrency"
        Me.cbCurrency.Size = New System.Drawing.Size(81, 21)
        Me.cbCurrency.TabIndex = 1
        '
        'tbPrice
        '
        Me.tbPrice.Location = New System.Drawing.Point(44, 3)
        Me.tbPrice.Name = "tbPrice"
        Me.tbPrice.Size = New System.Drawing.Size(66, 20)
        Me.tbPrice.TabIndex = 2
        Me.tbPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btAddInList
        '
        Me.btAddInList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btAddInList.Location = New System.Drawing.Point(44, 28)
        Me.btAddInList.Name = "btAddInList"
        Me.btAddInList.Size = New System.Drawing.Size(66, 19)
        Me.btAddInList.TabIndex = 6
        Me.btAddInList.Text = "Добавить"
        Me.btAddInList.UseVisualStyleBackColor = True
        '
        'lbTierPrices
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.lbTierPrices, 3)
        Me.lbTierPrices.DataSource = Me.ClsTierPricesCollectionBindingSource
        Me.lbTierPrices.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbTierPrices.FormattingEnabled = True
        Me.lbTierPrices.Location = New System.Drawing.Point(3, 53)
        Me.lbTierPrices.Name = "lbTierPrices"
        Me.lbTierPrices.Size = New System.Drawing.Size(194, 107)
        Me.lbTierPrices.TabIndex = 7
        '
        'ClsTierPricesCollectionBindingSource
        '
        Me.ClsTierPricesCollectionBindingSource.DataSource = GetType(nopRestClient.clsTierPricesCollection)
        '
        'lbBaseCurrency
        '
        Me.lbBaseCurrency.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lbBaseCurrency.AutoSize = True
        Me.lbBaseCurrency.Location = New System.Drawing.Point(5, 31)
        Me.lbBaseCurrency.Name = "lbBaseCurrency"
        Me.lbBaseCurrency.Size = New System.Drawing.Size(31, 13)
        Me.lbBaseCurrency.TabIndex = 8
        Me.lbBaseCurrency.Text = "curr?"
        '
        'btRemovePrice
        '
        Me.btRemovePrice.Location = New System.Drawing.Point(116, 28)
        Me.btRemovePrice.Name = "btRemovePrice"
        Me.btRemovePrice.Size = New System.Drawing.Size(71, 19)
        Me.btRemovePrice.TabIndex = 9
        Me.btRemovePrice.Text = "Удалить"
        Me.btRemovePrice.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 4
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.CheckBox1, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label2, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.TextBox1, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.cbx_callforprice, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.Label3, 2, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.TextBox2, 3, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.cbx_DisableBuyButton, 0, 3)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(209, 3)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 4
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 78.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(200, 160)
        Me.TableLayoutPanel2.TabIndex = 3
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.TableLayoutPanel2.SetColumnSpan(Me.CheckBox1, 4)
        Me.CheckBox1.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.bs_tierPrice, "CustomerEntersPrice", True))
        Me.CheckBox1.Location = New System.Drawing.Point(3, 3)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(192, 17)
        Me.CheckBox1.TabIndex = 0
        Me.CheckBox1.Text = "Покупатель вводит цену (общее)"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'bs_tierPrice
        '
        Me.bs_tierPrice.DataSource = GetType(nopRestClient.clsTierPriceStatic)
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(4, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(18, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "от"
        '
        'TextBox1
        '
        Me.TextBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bs_tierPrice, "MinimumCustomerEnteredPrice", True))
        Me.TextBox1.Location = New System.Drawing.Point(28, 33)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(69, 20)
        Me.TextBox1.TabIndex = 2
        '
        'cbx_callforprice
        '
        Me.cbx_callforprice.AutoSize = True
        Me.TableLayoutPanel2.SetColumnSpan(Me.cbx_callforprice, 4)
        Me.cbx_callforprice.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.bs_tierPrice, "CallForPrice", True))
        Me.cbx_callforprice.Location = New System.Drawing.Point(3, 59)
        Me.cbx_callforprice.Name = "cbx_callforprice"
        Me.cbx_callforprice.Size = New System.Drawing.Size(126, 17)
        Me.cbx_callforprice.TabIndex = 4
        Me.cbx_callforprice.Text = "Call for price (общее)"
        Me.cbx_callforprice.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(103, 36)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(19, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "до"
        '
        'TextBox2
        '
        Me.TextBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox2.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bs_tierPrice, "MaximumCustomerEnteredPrice", True))
        Me.TextBox2.Location = New System.Drawing.Point(128, 33)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(69, 20)
        Me.TextBox2.TabIndex = 4
        '
        'cbx_DisableBuyButton
        '
        Me.cbx_DisableBuyButton.AutoSize = True
        Me.TableLayoutPanel2.SetColumnSpan(Me.cbx_DisableBuyButton, 3)
        Me.cbx_DisableBuyButton.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.bs_tierPrice, "DisableBuyButton", True))
        Me.cbx_DisableBuyButton.Location = New System.Drawing.Point(3, 85)
        Me.cbx_DisableBuyButton.Name = "cbx_DisableBuyButton"
        Me.cbx_DisableBuyButton.Size = New System.Drawing.Size(108, 17)
        Me.cbx_DisableBuyButton.TabIndex = 5
        Me.cbx_DisableBuyButton.Text = "Не для продажи"
        Me.cbx_DisableBuyButton.UseVisualStyleBackColor = True
        '
        'Uc_langObjectRoles
        '
        Me.Uc_langObjectRoles.EnabledNew = False
        Me.Uc_langObjectRoles.Location = New System.Drawing.Point(415, 3)
        Me.Uc_langObjectRoles.Name = "Uc_langObjectRoles"
        Me.Uc_langObjectRoles.SingleSelect = False
        Me.Uc_langObjectRoles.Size = New System.Drawing.Size(366, 160)
        Me.Uc_langObjectRoles.TabIndex = 4
        Me.Uc_langObjectRoles.UcCaption = "Роли"
        '
        'Uc_langObjectStore
        '
        Me.Uc_langObjectStore.EnabledNew = False
        Me.Uc_langObjectStore.Location = New System.Drawing.Point(787, 3)
        Me.Uc_langObjectStore.Name = "Uc_langObjectStore"
        Me.Uc_langObjectStore.SingleSelect = False
        Me.Uc_langObjectStore.Size = New System.Drawing.Size(238, 160)
        Me.Uc_langObjectStore.TabIndex = 5
        Me.Uc_langObjectStore.UcCaption = "Store"
        '
        'uc_tierPrice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Name = "uc_tierPrice"
        Me.Size = New System.Drawing.Size(1105, 169)
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.ClsTierPricesCollectionBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        CType(Me.bs_tierPrice, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbCurrency As System.Windows.Forms.ComboBox
    Friend WithEvents tbPrice As System.Windows.Forms.TextBox
    Friend WithEvents cbx_callforprice As System.Windows.Forms.CheckBox
    Friend WithEvents btAddInList As System.Windows.Forms.Button
    Friend WithEvents lbTierPrices As System.Windows.Forms.ListBox
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Uc_langObjectRoles As nopRestClient.uc_langObject
    Friend WithEvents Uc_langObjectStore As nopRestClient.uc_langObject
    Friend WithEvents lbBaseCurrency As System.Windows.Forms.Label
    Friend WithEvents bs_tierPrice As System.Windows.Forms.BindingSource
    Friend WithEvents ClsTierPricesCollectionBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents cbx_DisableBuyButton As System.Windows.Forms.CheckBox
    Friend WithEvents btRemovePrice As System.Windows.Forms.Button

End Class
