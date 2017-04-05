<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucGoodList
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
        Me.ClsGoodListItemBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cbCurrency = New System.Windows.Forms.ComboBox()
        Me.tbSampleNumber = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btAddGood = New System.Windows.Forms.Button()
        Me.tbGoodAmount = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btRemoveGood = New System.Windows.Forms.Button()
        Me.DataGridView_goods = New System.Windows.Forms.DataGridView()
        Me.ActualCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GoodNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BasePriceInCurrency = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.quantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.uomName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.goodUuid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tbListAmount = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cbxCheckInMC = New System.Windows.Forms.CheckBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cbxCreateIfNotExist = New System.Windows.Forms.CheckBox()
        Me.btListReady = New System.Windows.Forms.Button()
        Me.cbGoodName = New System.Windows.Forms.ComboBox()
        Me.btQuery = New System.Windows.Forms.Button()
        Me.tbListCount = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btCreateOrder = New System.Windows.Forms.Button()
        Me.cbWareList = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btCreateDemand = New System.Windows.Forms.Button()
        Me.tbShippingInAmount = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btImportOrder = New System.Windows.Forms.Button()
        Me.btImportDemand = New System.Windows.Forms.Button()
        Me.cbOrderNumber = New System.Windows.Forms.ComboBox()
        Me.cbDemandNumber = New System.Windows.Forms.ComboBox()
        Me.gbGoods = New System.Windows.Forms.GroupBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.DemandDate = New System.Windows.Forms.DateTimePicker()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.tbHandlingInAmount = New System.Windows.Forms.TextBox()
        Me.btAddFee = New System.Windows.Forms.Button()
        Me.lbToShip = New System.Windows.Forms.Label()
        Me.btSendParcel = New System.Windows.Forms.Button()
        Me.cbxDeclaration = New System.Windows.Forms.CheckBox()
        CType(Me.ClsGoodListItemBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView_goods, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbGoods.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ClsGoodListItemBindingSource
        '
        Me.ClsGoodListItemBindingSource.DataSource = GetType(Service.iMoySkladDataProvider.clsPosition)
        '
        'cbCurrency
        '
        Me.cbCurrency.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.cbCurrency.FormattingEnabled = True
        Me.cbCurrency.Items.AddRange(New Object() {"RUR", "USD", "EUR"})
        Me.cbCurrency.Location = New System.Drawing.Point(106, 12)
        Me.cbCurrency.Name = "cbCurrency"
        Me.cbCurrency.Size = New System.Drawing.Size(54, 20)
        Me.cbCurrency.TabIndex = 4
        '
        'tbSampleNumber
        '
        Me.tbSampleNumber.Location = New System.Drawing.Point(64, 40)
        Me.tbSampleNumber.Name = "tbSampleNumber"
        Me.tbSampleNumber.Size = New System.Drawing.Size(74, 20)
        Me.tbSampleNumber.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Валюта списка"
        '
        'btAddGood
        '
        Me.btAddGood.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btAddGood.Location = New System.Drawing.Point(290, 116)
        Me.btAddGood.Name = "btAddGood"
        Me.btAddGood.Size = New System.Drawing.Size(199, 28)
        Me.btAddGood.TabIndex = 2
        Me.btAddGood.Text = "1. Добавить товар в список"
        Me.btAddGood.UseVisualStyleBackColor = True
        '
        'tbGoodAmount
        '
        Me.tbGoodAmount.Location = New System.Drawing.Point(78, 63)
        Me.tbGoodAmount.Name = "tbGoodAmount"
        Me.tbGoodAmount.Size = New System.Drawing.Size(60, 20)
        Me.tbGoodAmount.TabIndex = 8
        Me.tbGoodAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 67)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Стоимость"
        '
        'btRemoveGood
        '
        Me.btRemoveGood.Location = New System.Drawing.Point(576, 119)
        Me.btRemoveGood.Name = "btRemoveGood"
        Me.btRemoveGood.Size = New System.Drawing.Size(143, 28)
        Me.btRemoveGood.TabIndex = 10
        Me.btRemoveGood.Text = "удалить товар из списка"
        Me.btRemoveGood.UseVisualStyleBackColor = True
        '
        'DataGridView_goods
        '
        Me.DataGridView_goods.AllowUserToAddRows = False
        Me.DataGridView_goods.AllowUserToDeleteRows = False
        Me.DataGridView_goods.AutoGenerateColumns = False
        Me.DataGridView_goods.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView_goods.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ActualCode, Me.GoodNameDataGridViewTextBoxColumn, Me.BasePriceInCurrency, Me.quantity, Me.uomName, Me.goodUuid})
        Me.DataGridView_goods.DataSource = Me.ClsGoodListItemBindingSource
        Me.DataGridView_goods.Location = New System.Drawing.Point(11, 150)
        Me.DataGridView_goods.Name = "DataGridView_goods"
        Me.DataGridView_goods.Size = New System.Drawing.Size(708, 154)
        Me.DataGridView_goods.TabIndex = 11
        '
        'ActualCode
        '
        Me.ActualCode.DataPropertyName = "ActualCode"
        Me.ActualCode.HeaderText = "Код"
        Me.ActualCode.Name = "ActualCode"
        Me.ActualCode.ReadOnly = True
        Me.ActualCode.Width = 50
        '
        'GoodNameDataGridViewTextBoxColumn
        '
        Me.GoodNameDataGridViewTextBoxColumn.DataPropertyName = "GoodName"
        Me.GoodNameDataGridViewTextBoxColumn.HeaderText = "Название"
        Me.GoodNameDataGridViewTextBoxColumn.Name = "GoodNameDataGridViewTextBoxColumn"
        Me.GoodNameDataGridViewTextBoxColumn.Width = 300
        '
        'BasePriceInCurrency
        '
        Me.BasePriceInCurrency.DataPropertyName = "BasePriceInCurrency"
        Me.BasePriceInCurrency.HeaderText = "Цена"
        Me.BasePriceInCurrency.Name = "BasePriceInCurrency"
        Me.BasePriceInCurrency.Width = 70
        '
        'quantity
        '
        Me.quantity.DataPropertyName = "quantity"
        Me.quantity.HeaderText = "QTY"
        Me.quantity.Name = "quantity"
        Me.quantity.Width = 30
        '
        'uomName
        '
        Me.uomName.DataPropertyName = "uomName"
        Me.uomName.HeaderText = "UOM"
        Me.uomName.Name = "uomName"
        Me.uomName.Width = 30
        '
        'goodUuid
        '
        Me.goodUuid.DataPropertyName = "goodUuid"
        Me.goodUuid.HeaderText = "Uuid"
        Me.goodUuid.Name = "goodUuid"
        Me.goodUuid.Width = 150
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label3.Location = New System.Drawing.Point(16, 43)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 13)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Номер"
        '
        'tbListAmount
        '
        Me.tbListAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.tbListAmount.Location = New System.Drawing.Point(106, 54)
        Me.tbListAmount.Name = "tbListAmount"
        Me.tbListAmount.Size = New System.Drawing.Size(54, 18)
        Me.tbListAmount.TabIndex = 13
        Me.tbListAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 55)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(94, 13)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Сумма по списку"
        '
        'cbxCheckInMC
        '
        Me.cbxCheckInMC.AutoSize = True
        Me.cbxCheckInMC.Location = New System.Drawing.Point(19, 17)
        Me.cbxCheckInMC.Name = "cbxCheckInMC"
        Me.cbxCheckInMC.Size = New System.Drawing.Size(109, 17)
        Me.cbxCheckInMC.TabIndex = 15
        Me.cbxCheckInMC.Text = "Проверять в МС"
        Me.cbxCheckInMC.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(13, 92)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(73, 13)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "Назв./выбор"
        '
        'cbxCreateIfNotExist
        '
        Me.cbxCreateIfNotExist.AutoSize = True
        Me.cbxCreateIfNotExist.Location = New System.Drawing.Point(133, 16)
        Me.cbxCreateIfNotExist.Name = "cbxCreateIfNotExist"
        Me.cbxCreateIfNotExist.Size = New System.Drawing.Size(189, 17)
        Me.cbxCreateIfNotExist.TabIndex = 18
        Me.cbxCreateIfNotExist.Text = "Создавать отсутствующий в МС"
        Me.cbxCreateIfNotExist.UseVisualStyleBackColor = True
        '
        'btListReady
        '
        Me.btListReady.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btListReady.Location = New System.Drawing.Point(626, 335)
        Me.btListReady.Name = "btListReady"
        Me.btListReady.Size = New System.Drawing.Size(92, 54)
        Me.btListReady.TabIndex = 19
        Me.btListReady.Text = "6, Готово"
        Me.btListReady.UseVisualStyleBackColor = True
        '
        'cbGoodName
        '
        Me.cbGoodName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbGoodName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbGoodName.FormattingEnabled = True
        Me.cbGoodName.Location = New System.Drawing.Point(92, 89)
        Me.cbGoodName.Name = "cbGoodName"
        Me.cbGoodName.Size = New System.Drawing.Size(627, 21)
        Me.cbGoodName.TabIndex = 20
        '
        'btQuery
        '
        Me.btQuery.Location = New System.Drawing.Point(153, 40)
        Me.btQuery.Name = "btQuery"
        Me.btQuery.Size = New System.Drawing.Size(102, 43)
        Me.btQuery.TabIndex = 21
        Me.btQuery.Text = "Запрос по номеру товара"
        Me.btQuery.UseVisualStyleBackColor = True
        '
        'tbListCount
        '
        Me.tbListCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.tbListCount.Location = New System.Drawing.Point(134, 34)
        Me.tbListCount.Name = "tbListCount"
        Me.tbListCount.Size = New System.Drawing.Size(26, 18)
        Me.tbListCount.TabIndex = 22
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 34)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(99, 13)
        Me.Label6.TabIndex = 23
        Me.Label6.Text = "Позиций в списке"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 134)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(213, 13)
        Me.Label7.TabIndex = 24
        Me.Label7.Text = "*dblclick в таблице = создать товар в МС"
        '
        'btCreateOrder
        '
        Me.btCreateOrder.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btCreateOrder.Location = New System.Drawing.Point(16, 350)
        Me.btCreateOrder.Name = "btCreateOrder"
        Me.btCreateOrder.Size = New System.Drawing.Size(285, 43)
        Me.btCreateOrder.TabIndex = 25
        Me.btCreateOrder.Text = "2. Создать заказ в МС по списку"
        Me.btCreateOrder.UseVisualStyleBackColor = True
        '
        'cbWareList
        '
        Me.cbWareList.FormattingEnabled = True
        Me.cbWareList.Location = New System.Drawing.Point(590, 308)
        Me.cbWareList.Name = "cbWareList"
        Me.cbWareList.Size = New System.Drawing.Size(126, 21)
        Me.cbWareList.TabIndex = 26
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(546, 311)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(38, 13)
        Me.Label8.TabIndex = 27
        Me.Label8.Text = "Склад"
        '
        'btCreateDemand
        '
        Me.btCreateDemand.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btCreateDemand.Location = New System.Drawing.Point(422, 349)
        Me.btCreateDemand.Name = "btCreateDemand"
        Me.btCreateDemand.Size = New System.Drawing.Size(113, 40)
        Me.btCreateDemand.TabIndex = 28
        Me.btCreateDemand.Text = "4. Создать отгрузку в МС"
        Me.btCreateDemand.UseVisualStyleBackColor = True
        '
        'tbShippingInAmount
        '
        Me.tbShippingInAmount.Location = New System.Drawing.Point(250, 305)
        Me.tbShippingInAmount.Name = "tbShippingInAmount"
        Me.tbShippingInAmount.Size = New System.Drawing.Size(50, 20)
        Me.tbShippingInAmount.TabIndex = 29
        Me.tbShippingInAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(14, 308)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(231, 13)
        Me.Label9.TabIndex = 30
        Me.Label9.Text = "Стоимость шиппинга, оплаченная клиентом"
        '
        'btImportOrder
        '
        Me.btImportOrder.Location = New System.Drawing.Point(387, 37)
        Me.btImportOrder.Name = "btImportOrder"
        Me.btImportOrder.Size = New System.Drawing.Size(122, 23)
        Me.btImportOrder.TabIndex = 32
        Me.btImportOrder.Text = "Импорт заказа МС"
        Me.btImportOrder.UseVisualStyleBackColor = True
        '
        'btImportDemand
        '
        Me.btImportDemand.Location = New System.Drawing.Point(387, 61)
        Me.btImportDemand.Name = "btImportDemand"
        Me.btImportDemand.Size = New System.Drawing.Size(122, 23)
        Me.btImportDemand.TabIndex = 33
        Me.btImportDemand.Text = "Импорт отгрузки МС"
        Me.btImportDemand.UseVisualStyleBackColor = True
        '
        'cbOrderNumber
        '
        Me.cbOrderNumber.FormattingEnabled = True
        Me.cbOrderNumber.Location = New System.Drawing.Point(280, 39)
        Me.cbOrderNumber.Name = "cbOrderNumber"
        Me.cbOrderNumber.Size = New System.Drawing.Size(101, 21)
        Me.cbOrderNumber.TabIndex = 34
        '
        'cbDemandNumber
        '
        Me.cbDemandNumber.FormattingEnabled = True
        Me.cbDemandNumber.Location = New System.Drawing.Point(280, 61)
        Me.cbDemandNumber.Name = "cbDemandNumber"
        Me.cbDemandNumber.Size = New System.Drawing.Size(101, 21)
        Me.cbDemandNumber.TabIndex = 35
        '
        'gbGoods
        '
        Me.gbGoods.Controls.Add(Me.cbxDeclaration)
        Me.gbGoods.Controls.Add(Me.btSendParcel)
        Me.gbGoods.Controls.Add(Me.lbToShip)
        Me.gbGoods.Controls.Add(Me.GroupBox1)
        Me.gbGoods.Controls.Add(Me.Label11)
        Me.gbGoods.Controls.Add(Me.DemandDate)
        Me.gbGoods.Controls.Add(Me.Label10)
        Me.gbGoods.Controls.Add(Me.tbHandlingInAmount)
        Me.gbGoods.Controls.Add(Me.btAddFee)
        Me.gbGoods.Controls.Add(Me.cbDemandNumber)
        Me.gbGoods.Controls.Add(Me.cbOrderNumber)
        Me.gbGoods.Controls.Add(Me.btImportDemand)
        Me.gbGoods.Controls.Add(Me.btImportOrder)
        Me.gbGoods.Controls.Add(Me.Label9)
        Me.gbGoods.Controls.Add(Me.tbShippingInAmount)
        Me.gbGoods.Controls.Add(Me.btCreateDemand)
        Me.gbGoods.Controls.Add(Me.Label8)
        Me.gbGoods.Controls.Add(Me.cbWareList)
        Me.gbGoods.Controls.Add(Me.btCreateOrder)
        Me.gbGoods.Controls.Add(Me.Label7)
        Me.gbGoods.Controls.Add(Me.btQuery)
        Me.gbGoods.Controls.Add(Me.cbGoodName)
        Me.gbGoods.Controls.Add(Me.btListReady)
        Me.gbGoods.Controls.Add(Me.cbxCreateIfNotExist)
        Me.gbGoods.Controls.Add(Me.Label5)
        Me.gbGoods.Controls.Add(Me.cbxCheckInMC)
        Me.gbGoods.Controls.Add(Me.Label3)
        Me.gbGoods.Controls.Add(Me.DataGridView_goods)
        Me.gbGoods.Controls.Add(Me.btRemoveGood)
        Me.gbGoods.Controls.Add(Me.Label2)
        Me.gbGoods.Controls.Add(Me.tbGoodAmount)
        Me.gbGoods.Controls.Add(Me.btAddGood)
        Me.gbGoods.Controls.Add(Me.tbSampleNumber)
        Me.gbGoods.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbGoods.Location = New System.Drawing.Point(0, 0)
        Me.gbGoods.Name = "gbGoods"
        Me.gbGoods.Size = New System.Drawing.Size(725, 396)
        Me.gbGoods.TabIndex = 13
        Me.gbGoods.TabStop = False
        Me.gbGoods.Text = "Товары"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.tbListAmount)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.tbListCount)
        Me.GroupBox1.Controls.Add(Me.cbCurrency)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(515, 10)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(204, 74)
        Me.GroupBox1.TabIndex = 41
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Заказ"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(330, 311)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(86, 13)
        Me.Label11.TabIndex = 40
        Me.Label11.Text = "Отгрузка: Дата"
        '
        'DemandDate
        '
        Me.DemandDate.Location = New System.Drawing.Point(422, 308)
        Me.DemandDate.Name = "DemandDate"
        Me.DemandDate.Size = New System.Drawing.Size(118, 20)
        Me.DemandDate.TabIndex = 39
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(14, 327)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(222, 13)
        Me.Label10.TabIndex = 38
        Me.Label10.Text = "Стоимость handling, оплаченная клиентом"
        '
        'tbHandlingInAmount
        '
        Me.tbHandlingInAmount.Location = New System.Drawing.Point(250, 324)
        Me.tbHandlingInAmount.Name = "tbHandlingInAmount"
        Me.tbHandlingInAmount.Size = New System.Drawing.Size(50, 20)
        Me.tbHandlingInAmount.TabIndex = 37
        Me.tbHandlingInAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btAddFee
        '
        Me.btAddFee.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btAddFee.Location = New System.Drawing.Point(307, 336)
        Me.btAddFee.Name = "btAddFee"
        Me.btAddFee.Size = New System.Drawing.Size(109, 54)
        Me.btAddFee.TabIndex = 36
        Me.btAddFee.Text = "3, Добавить fee в отгрузку"
        Me.btAddFee.UseVisualStyleBackColor = True
        '
        'lbToShip
        '
        Me.lbToShip.AutoSize = True
        Me.lbToShip.Location = New System.Drawing.Point(446, 332)
        Me.lbToShip.Name = "lbToShip"
        Me.lbToShip.Size = New System.Drawing.Size(72, 13)
        Me.lbToShip.TabIndex = 42
        Me.lbToShip.Text = "На Отправку"
        '
        'btSendParcel
        '
        Me.btSendParcel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btSendParcel.Location = New System.Drawing.Point(542, 355)
        Me.btSendParcel.Name = "btSendParcel"
        Me.btSendParcel.Size = New System.Drawing.Size(78, 34)
        Me.btSendParcel.TabIndex = 43
        Me.btSendParcel.Text = "5,Задание на посылку"
        Me.btSendParcel.UseVisualStyleBackColor = True
        '
        'cbxDeclaration
        '
        Me.cbxDeclaration.AutoSize = True
        Me.cbxDeclaration.Location = New System.Drawing.Point(542, 334)
        Me.cbxDeclaration.Name = "cbxDeclaration"
        Me.cbxDeclaration.Size = New System.Drawing.Size(77, 17)
        Me.cbxDeclaration.TabIndex = 44
        Me.cbxDeclaration.Text = "декларац."
        Me.cbxDeclaration.UseVisualStyleBackColor = True
        '
        'ucGoodList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.gbGoods)
        Me.Name = "ucGoodList"
        Me.Size = New System.Drawing.Size(725, 396)
        CType(Me.ClsGoodListItemBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView_goods, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbGoods.ResumeLayout(False)
        Me.gbGoods.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ShotCodeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QtyDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UomNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AmountDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UUIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SmDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ClsGoodListItemBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents cbCurrency As Windows.Forms.ComboBox
    Friend WithEvents tbSampleNumber As Windows.Forms.TextBox
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents btAddGood As Windows.Forms.Button
    Friend WithEvents tbGoodAmount As Windows.Forms.TextBox
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents btRemoveGood As Windows.Forms.Button
    Friend WithEvents DataGridView_goods As Windows.Forms.DataGridView
    Friend WithEvents ActualCode As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GoodNameDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BasePriceInCurrency As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents quantity As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents uomName As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents goodUuid As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents tbListAmount As Windows.Forms.TextBox
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents cbxCheckInMC As Windows.Forms.CheckBox
    Friend WithEvents Label5 As Windows.Forms.Label
    Friend WithEvents cbxCreateIfNotExist As Windows.Forms.CheckBox
    Friend WithEvents btListReady As Windows.Forms.Button
    Friend WithEvents cbGoodName As Windows.Forms.ComboBox
    Friend WithEvents btQuery As Windows.Forms.Button
    Friend WithEvents tbListCount As Windows.Forms.TextBox
    Friend WithEvents Label6 As Windows.Forms.Label
    Friend WithEvents Label7 As Windows.Forms.Label
    Friend WithEvents btCreateOrder As Windows.Forms.Button
    Friend WithEvents cbWareList As Windows.Forms.ComboBox
    Friend WithEvents Label8 As Windows.Forms.Label
    Friend WithEvents btCreateDemand As Windows.Forms.Button
    Friend WithEvents tbShippingInAmount As Windows.Forms.TextBox
    Friend WithEvents Label9 As Windows.Forms.Label
    Friend WithEvents btImportOrder As Windows.Forms.Button
    Friend WithEvents btImportDemand As Windows.Forms.Button
    Friend WithEvents cbOrderNumber As Windows.Forms.ComboBox
    Friend WithEvents cbDemandNumber As Windows.Forms.ComboBox
    Friend WithEvents gbGoods As Windows.Forms.GroupBox
    Friend WithEvents btAddFee As Windows.Forms.Button
    Friend WithEvents Label10 As Windows.Forms.Label
    Friend WithEvents tbHandlingInAmount As Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents DemandDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lbToShip As System.Windows.Forms.Label
    Friend WithEvents btSendParcel As System.Windows.Forms.Button
    Friend WithEvents cbxDeclaration As System.Windows.Forms.CheckBox
End Class
