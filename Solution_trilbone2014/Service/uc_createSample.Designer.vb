<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uc_createSample
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
        Dim АртикулLabel As System.Windows.Forms.Label
        Dim Буржуи_на_выставкеLabel As System.Windows.Forms.Label
        Dim Время_препарации_в_часах__общее_Label As System.Windows.Forms.Label
        Dim ГруппыLabel As System.Windows.Forms.Label
        Dim Единица_измеренияLabel As System.Windows.Forms.Label
        Dim Закупочная_ценаLabel As System.Windows.Forms.Label
        Dim ИнвойсLabel As System.Windows.Forms.Label
        Dim КодLabel As System.Windows.Forms.Label
        Dim НаименованиеLabel As System.Windows.Forms.Label
        Dim Ответственный_ПрепараторLabel As System.Windows.Forms.Label
        Dim Полная_стоимость_закупки_в_рубляхLabel As System.Windows.Forms.Label
        Dim Полная_стоимость_препарации_в_рубляхLabel As System.Windows.Forms.Label
        Dim Препараторы_и_времяLabel As System.Windows.Forms.Label
        Dim Производственный_номер_или_EAN13Label As System.Windows.Forms.Label
        Dim Розничная_в_офисеLabel As System.Windows.Forms.Label
        Dim Розничная_цена_в_магазинеLabel As System.Windows.Forms.Label
        Dim Экспедиционное_закупочное_примечаниеLabel As System.Windows.Forms.Label
        Dim Экспедиционный_закупочный_номерLabel As System.Windows.Forms.Label
        Dim Экспедиция__код_Label As System.Windows.Forms.Label
        Dim Label3 As System.Windows.Forms.Label
        Dim EBAYLabel As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(uc_createSample))
        Me.OldGoodMap_ResultBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorAddNewItem = New System.Windows.Forms.ToolStripButton()
        Me.OldGoodMap_ResultBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel()
        Me.BindingNavigatorDeleteItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox()
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.OldGoodMap_ResultBindingNavigatorSaveItem = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.АртикулTextBox = New System.Windows.Forms.TextBox()
        Me.Буржуи_на_выставкеTextBox = New System.Windows.Forms.TextBox()
        Me.Валюта__Буржуи_на_выставке_ComboBox = New System.Windows.Forms.ComboBox()
        Me.Валюта__Закупочная_цена_ComboBox = New System.Windows.Forms.ComboBox()
        Me.Валюта__Инвойс_ComboBox = New System.Windows.Forms.ComboBox()
        Me.Валюта__Розничная_в_офисе_ComboBox = New System.Windows.Forms.ComboBox()
        Me.Валюта__Розничная_цена_в_магазине_ComboBox = New System.Windows.Forms.ComboBox()
        Me.Время_препарации_в_часах__общее_TextBox = New System.Windows.Forms.TextBox()
        Me.Единица_измеренияTextBox = New System.Windows.Forms.TextBox()
        Me.Закупочная_ценаTextBox = New System.Windows.Forms.TextBox()
        Me.ИнвойсTextBox = New System.Windows.Forms.TextBox()
        Me.КодTextBox = New System.Windows.Forms.TextBox()
        Me.НаименованиеTextBox = New System.Windows.Forms.TextBox()
        Me.Ответственный_ПрепараторTextBox = New System.Windows.Forms.TextBox()
        Me.Полная_стоимость_закупки_в_рубляхTextBox = New System.Windows.Forms.TextBox()
        Me.Полная_стоимость_препарации_в_рубляхTextBox = New System.Windows.Forms.TextBox()
        Me.Препараторы_и_времяTextBox = New System.Windows.Forms.TextBox()
        Me.Производственный_номер_или_EAN13TextBox = New System.Windows.Forms.TextBox()
        Me.Розничная_в_офисеTextBox = New System.Windows.Forms.TextBox()
        Me.Розничная_цена_в_магазинеTextBox = New System.Windows.Forms.TextBox()
        Me.Экспедиционное_закупочное_примечаниеTextBox = New System.Windows.Forms.TextBox()
        Me.Экспедиционный_закупочный_номерTextBox = New System.Windows.Forms.TextBox()
        Me.Экспедиция__код_TextBox = New System.Windows.Forms.TextBox()
        Me.btGetNewCode = New System.Windows.Forms.Button()
        Me.cbUomUser = New System.Windows.Forms.ComboBox()
        Me.cbGroups = New System.Windows.Forms.ComboBox()
        Me.btGetNameFromDB = New System.Windows.Forms.Button()
        Me.tbctlMain = New System.Windows.Forms.TabControl()
        Me.tpОприходование = New System.Windows.Forms.TabPage()
        Me.gbExpedition = New System.Windows.Forms.GroupBox()
        Me.gbNumbers = New System.Windows.Forms.GroupBox()
        Me.ВесTextBox = New System.Windows.Forms.TextBox()
        Me.cbWeightUser = New System.Windows.Forms.ComboBox()
        Me.ВесLabel = New System.Windows.Forms.Label()
        Me.btClearAll = New System.Windows.Forms.Button()
        Me.btQuery = New System.Windows.Forms.Button()
        Me.btMoveToCode = New System.Windows.Forms.Button()
        Me.btMoveToArticul = New System.Windows.Forms.Button()
        Me.gbPreparator = New System.Windows.Forms.GroupBox()
        Me.tbctlPreparator = New System.Windows.Forms.TabControl()
        Me.tpPreparator_DB = New System.Windows.Forms.TabPage()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btCalculateSalary = New System.Windows.Forms.Button()
        Me.tpPreparator_Calculate = New System.Windows.Forms.TabPage()
        Me.tpPrices = New System.Windows.Forms.TabPage()
        Me.gbStorage = New System.Windows.Forms.GroupBox()
        Me.gbPricesEC = New System.Windows.Forms.GroupBox()
        Me.Валюта__EBAY_ComboBox = New System.Windows.Forms.ComboBox()
        Me.EBAYTextBox = New System.Windows.Forms.TextBox()
        Me.gbPricesRUS = New System.Windows.Forms.GroupBox()
        Me.gbBuying = New System.Windows.Forms.GroupBox()
        Me.tbctlBuying = New System.Windows.Forms.TabControl()
        Me.tpBuying_DB = New System.Windows.Forms.TabPage()
        Me.Расчет_розницыButton = New System.Windows.Forms.Button()
        Me.Расчитать_всеButton = New System.Windows.Forms.Button()
        Me.СтандартныеНакладныеButton = New System.Windows.Forms.Button()
        Me.СбросНакладныхButton = New System.Windows.Forms.Button()
        Me.СбросПеревозкиButton = New System.Windows.Forms.Button()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.ПеревозкаЗаКГTextBox = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Перевозка_рассчетButton = New System.Windows.Forms.Button()
        Me.НакладныеTextBox = New System.Windows.Forms.TextBox()
        Me.ПеревозкаВалютаComboBox = New System.Windows.Forms.ComboBox()
        Me.ПеревозкаTextBox = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Закупочная_цена_Button = New System.Windows.Forms.Button()
        Me.btCalculateValue = New System.Windows.Forms.Button()
        Me.tpBuying_Calculate = New System.Windows.Forms.TabPage()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.UC_preparator_calc1 = New Service.UC_preparator_calc()
        АртикулLabel = New System.Windows.Forms.Label()
        Буржуи_на_выставкеLabel = New System.Windows.Forms.Label()
        Время_препарации_в_часах__общее_Label = New System.Windows.Forms.Label()
        ГруппыLabel = New System.Windows.Forms.Label()
        Единица_измеренияLabel = New System.Windows.Forms.Label()
        Закупочная_ценаLabel = New System.Windows.Forms.Label()
        ИнвойсLabel = New System.Windows.Forms.Label()
        КодLabel = New System.Windows.Forms.Label()
        НаименованиеLabel = New System.Windows.Forms.Label()
        Ответственный_ПрепараторLabel = New System.Windows.Forms.Label()
        Полная_стоимость_закупки_в_рубляхLabel = New System.Windows.Forms.Label()
        Полная_стоимость_препарации_в_рубляхLabel = New System.Windows.Forms.Label()
        Препараторы_и_времяLabel = New System.Windows.Forms.Label()
        Производственный_номер_или_EAN13Label = New System.Windows.Forms.Label()
        Розничная_в_офисеLabel = New System.Windows.Forms.Label()
        Розничная_цена_в_магазинеLabel = New System.Windows.Forms.Label()
        Экспедиционное_закупочное_примечаниеLabel = New System.Windows.Forms.Label()
        Экспедиционный_закупочный_номерLabel = New System.Windows.Forms.Label()
        Экспедиция__код_Label = New System.Windows.Forms.Label()
        Label3 = New System.Windows.Forms.Label()
        EBAYLabel = New System.Windows.Forms.Label()
        CType(Me.OldGoodMap_ResultBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.OldGoodMap_ResultBindingNavigator.SuspendLayout()
        CType(Me.OldGoodMap_ResultBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbctlMain.SuspendLayout()
        Me.tpОприходование.SuspendLayout()
        Me.gbExpedition.SuspendLayout()
        Me.gbNumbers.SuspendLayout()
        Me.gbPreparator.SuspendLayout()
        Me.tbctlPreparator.SuspendLayout()
        Me.tpPreparator_DB.SuspendLayout()
        Me.tpPreparator_Calculate.SuspendLayout()
        Me.tpPrices.SuspendLayout()
        Me.gbPricesEC.SuspendLayout()
        Me.gbPricesRUS.SuspendLayout()
        Me.gbBuying.SuspendLayout()
        Me.tbctlBuying.SuspendLayout()
        Me.tpBuying_DB.SuspendLayout()
        Me.tpBuying_Calculate.SuspendLayout()
        Me.SuspendLayout()
        '
        'АртикулLabel
        '
        АртикулLabel.AutoSize = True
        АртикулLabel.Location = New System.Drawing.Point(213, 12)
        АртикулLabel.Name = "АртикулLabel"
        АртикулLabel.Size = New System.Drawing.Size(51, 13)
        АртикулLabel.TabIndex = 1
        АртикулLabel.Text = "Артикул:"
        AddHandler АртикулLabel.Click, AddressOf Me.АртикулLabel_Click
        '
        'Буржуи_на_выставкеLabel
        '
        Буржуи_на_выставкеLabel.AutoSize = True
        Буржуи_на_выставкеLabel.Location = New System.Drawing.Point(18, 25)
        Буржуи_на_выставкеLabel.Name = "Буржуи_на_выставкеLabel"
        Буржуи_на_выставкеLabel.Size = New System.Drawing.Size(114, 13)
        Буржуи_на_выставкеLabel.TabIndex = 3
        Буржуи_на_выставкеLabel.Text = "Буржуи на выставке:"
        AddHandler Буржуи_на_выставкеLabel.Click, AddressOf Me.Буржуи_на_выставкеLabel_Click
        '
        'Время_препарации_в_часах__общее_Label
        '
        Время_препарации_в_часах__общее_Label.AutoSize = True
        Время_препарации_в_часах__общее_Label.Location = New System.Drawing.Point(12, 167)
        Время_препарации_в_часах__общее_Label.Name = "Время_препарации_в_часах__общее_Label"
        Время_препарации_в_часах__общее_Label.Size = New System.Drawing.Size(185, 13)
        Время_препарации_в_часах__общее_Label.TabIndex = 17
        Время_препарации_в_часах__общее_Label.Text = "Время препарации в часах общее :"
        AddHandler Время_препарации_в_часах__общее_Label.Click, AddressOf Me.Время_препарации_в_часах__общее_Label_Click
        '
        'ГруппыLabel
        '
        ГруппыLabel.AutoSize = True
        ГруппыLabel.Location = New System.Drawing.Point(12, 60)
        ГруппыLabel.Name = "ГруппыLabel"
        ГруппыLabel.Size = New System.Drawing.Size(45, 13)
        ГруппыLabel.TabIndex = 19
        ГруппыLabel.Text = "Группа:"
        '
        'Единица_измеренияLabel
        '
        Единица_измеренияLabel.AutoSize = True
        Единица_измеренияLabel.Location = New System.Drawing.Point(9, 151)
        Единица_измеренияLabel.Name = "Единица_измеренияLabel"
        Единица_измеренияLabel.Size = New System.Drawing.Size(52, 13)
        Единица_измеренияLabel.TabIndex = 21
        Единица_измеренияLabel.Text = "Ед. изм.:"
        AddHandler Единица_измеренияLabel.Click, AddressOf Me.Единица_измеренияLabel_Click
        '
        'Закупочная_ценаLabel
        '
        Закупочная_ценаLabel.AutoSize = True
        Закупочная_ценаLabel.Location = New System.Drawing.Point(6, 68)
        Закупочная_ценаLabel.Name = "Закупочная_ценаLabel"
        Закупочная_ценаLabel.Size = New System.Drawing.Size(96, 13)
        Закупочная_ценаLabel.TabIndex = 23
        Закупочная_ценаLabel.Text = "Закупочная цена:"
        AddHandler Закупочная_ценаLabel.Click, AddressOf Me.Закупочная_ценаLabel_Click
        '
        'ИнвойсLabel
        '
        ИнвойсLabel.AutoSize = True
        ИнвойсLabel.Location = New System.Drawing.Point(6, 10)
        ИнвойсLabel.Name = "ИнвойсLabel"
        ИнвойсLabel.Size = New System.Drawing.Size(48, 13)
        ИнвойсLabel.TabIndex = 25
        ИнвойсLabel.Text = "Инвойс:"
        AddHandler ИнвойсLabel.Click, AddressOf Me.ИнвойсLabel_Click
        '
        'КодLabel
        '
        КодLabel.AutoSize = True
        КодLabel.Location = New System.Drawing.Point(89, 12)
        КодLabel.Name = "КодLabel"
        КодLabel.Size = New System.Drawing.Size(29, 13)
        КодLabel.TabIndex = 27
        КодLabel.Text = "Код:"
        AddHandler КодLabel.Click, AddressOf Me.КодLabel_Click
        '
        'НаименованиеLabel
        '
        НаименованиеLabel.AutoSize = True
        НаименованиеLabel.Location = New System.Drawing.Point(24, 84)
        НаименованиеLabel.Name = "НаименованиеLabel"
        НаименованиеLabel.Size = New System.Drawing.Size(60, 13)
        НаименованиеLabel.TabIndex = 29
        НаименованиеLabel.Text = "Название:"
        '
        'Ответственный_ПрепараторLabel
        '
        Ответственный_ПрепараторLabel.AutoSize = True
        Ответственный_ПрепараторLabel.Location = New System.Drawing.Point(7, 42)
        Ответственный_ПрепараторLabel.Name = "Ответственный_ПрепараторLabel"
        Ответственный_ПрепараторLabel.Size = New System.Drawing.Size(153, 13)
        Ответственный_ПрепараторLabel.TabIndex = 31
        Ответственный_ПрепараторLabel.Text = "Ответственный Препаратор:"
        '
        'Полная_стоимость_закупки_в_рубляхLabel
        '
        Полная_стоимость_закупки_в_рубляхLabel.Location = New System.Drawing.Point(4, 148)
        Полная_стоимость_закупки_в_рубляхLabel.Name = "Полная_стоимость_закупки_в_рубляхLabel"
        Полная_стоимость_закупки_в_рубляхLabel.Size = New System.Drawing.Size(195, 34)
        Полная_стоимость_закупки_в_рубляхLabel.TabIndex = 33
        Полная_стоимость_закупки_в_рубляхLabel.Text = "Полная стоимость закупки в рублях" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "в т.ч. препарация и перевозка"
        AddHandler Полная_стоимость_закупки_в_рубляхLabel.Click, AddressOf Me.Полная_стоимость_закупки_в_рубляхLabel_Click
        '
        'Полная_стоимость_препарации_в_рубляхLabel
        '
        Полная_стоимость_препарации_в_рубляхLabel.AutoSize = True
        Полная_стоимость_препарации_в_рубляхLabel.Location = New System.Drawing.Point(12, 195)
        Полная_стоимость_препарации_в_рубляхLabel.Name = "Полная_стоимость_препарации_в_рубляхLabel"
        Полная_стоимость_препарации_в_рубляхLabel.Size = New System.Drawing.Size(214, 13)
        Полная_стоимость_препарации_в_рубляхLabel.TabIndex = 35
        Полная_стоимость_препарации_в_рубляхLabel.Text = "Полная стоимость препарации в рублях:"
        AddHandler Полная_стоимость_препарации_в_рубляхLabel.Click, AddressOf Me.Полная_стоимость_препарации_в_рубляхLabel_Click
        '
        'Препараторы_и_времяLabel
        '
        Препараторы_и_времяLabel.AutoSize = True
        Препараторы_и_времяLabel.Location = New System.Drawing.Point(7, 64)
        Препараторы_и_времяLabel.Name = "Препараторы_и_времяLabel"
        Препараторы_и_времяLabel.Size = New System.Drawing.Size(123, 13)
        Препараторы_и_времяLabel.TabIndex = 37
        Препараторы_и_времяLabel.Text = "Препараторы и время:"
        '
        'Производственный_номер_или_EAN13Label
        '
        Производственный_номер_или_EAN13Label.AutoSize = True
        Производственный_номер_или_EAN13Label.Location = New System.Drawing.Point(5, 14)
        Производственный_номер_или_EAN13Label.Name = "Производственный_номер_или_EAN13Label"
        Производственный_номер_или_EAN13Label.Size = New System.Drawing.Size(144, 13)
        Производственный_номер_или_EAN13Label.TabIndex = 39
        Производственный_номер_или_EAN13Label.Text = "Производственный номер:"
        AddHandler Производственный_номер_или_EAN13Label.Click, AddressOf Me.Производственный_номер_или_EAN13Label_Click
        '
        'Розничная_в_офисеLabel
        '
        Розничная_в_офисеLabel.AutoSize = True
        Розничная_в_офисеLabel.Location = New System.Drawing.Point(47, 49)
        Розничная_в_офисеLabel.Name = "Розничная_в_офисеLabel"
        Розничная_в_офисеLabel.Size = New System.Drawing.Size(108, 13)
        Розничная_в_офисеLabel.TabIndex = 41
        Розничная_в_офисеLabel.Text = "Розничная в офисе:"
        AddHandler Розничная_в_офисеLabel.Click, AddressOf Me.Розничная_в_офисеLabel_Click
        '
        'Розничная_цена_в_магазинеLabel
        '
        Розничная_цена_в_магазинеLabel.AutoSize = True
        Розничная_цена_в_магазинеLabel.Location = New System.Drawing.Point(6, 22)
        Розничная_цена_в_магазинеLabel.Name = "Розничная_цена_в_магазинеLabel"
        Розничная_цена_в_магазинеLabel.Size = New System.Drawing.Size(152, 13)
        Розничная_цена_в_магазинеLabel.TabIndex = 43
        Розничная_цена_в_магазинеLabel.Text = "Розничная цена в магазине:"
        AddHandler Розничная_цена_в_магазинеLabel.Click, AddressOf Me.Розничная_цена_в_магазинеLabel_Click
        '
        'Экспедиционное_закупочное_примечаниеLabel
        '
        Экспедиционное_закупочное_примечаниеLabel.AutoSize = True
        Экспедиционное_закупочное_примечаниеLabel.Location = New System.Drawing.Point(6, 72)
        Экспедиционное_закупочное_примечаниеLabel.Name = "Экспедиционное_закупочное_примечаниеLabel"
        Экспедиционное_закупочное_примечаниеLabel.Size = New System.Drawing.Size(159, 13)
        Экспедиционное_закупочное_примечаниеLabel.TabIndex = 45
        Экспедиционное_закупочное_примечаниеLabel.Text = "Экспедиционное примечание:"
        '
        'Экспедиционный_закупочный_номерLabel
        '
        Экспедиционный_закупочный_номерLabel.AutoSize = True
        Экспедиционный_закупочный_номерLabel.Location = New System.Drawing.Point(7, 50)
        Экспедиционный_закупочный_номерLabel.Name = "Экспедиционный_закупочный_номерLabel"
        Экспедиционный_закупочный_номерLabel.Size = New System.Drawing.Size(132, 13)
        Экспедиционный_закупочный_номерLabel.TabIndex = 47
        Экспедиционный_закупочный_номерLabel.Text = "Экспедиционный номер:"
        AddHandler Экспедиционный_закупочный_номерLabel.Click, AddressOf Me.Экспедиционный_закупочный_номерLabel_Click
        '
        'Экспедиция__код_Label
        '
        Экспедиция__код_Label.AutoSize = True
        Экспедиция__код_Label.Location = New System.Drawing.Point(8, 22)
        Экспедиция__код_Label.Name = "Экспедиция__код_Label"
        Экспедиция__код_Label.Size = New System.Drawing.Size(95, 13)
        Экспедиция__код_Label.TabIndex = 49
        Экспедиция__код_Label.Text = "Экспедиция код :"
        '
        'Label3
        '
        Label3.AutoSize = True
        Label3.Location = New System.Drawing.Point(35, 98)
        Label3.Name = "Label3"
        Label3.Size = New System.Drawing.Size(66, 13)
        Label3.TabIndex = 60
        Label3.Text = "Перевозка:"
        AddHandler Label3.Click, AddressOf Me.Label3_Click
        '
        'EBAYLabel
        '
        EBAYLabel.AutoSize = True
        EBAYLabel.Location = New System.Drawing.Point(87, 47)
        EBAYLabel.Name = "EBAYLabel"
        EBAYLabel.Size = New System.Drawing.Size(38, 13)
        EBAYLabel.TabIndex = 6
        EBAYLabel.Text = "EBAY:"
        AddHandler EBAYLabel.Click, AddressOf Me.EBAYLabel_Click
        '
        'OldGoodMap_ResultBindingNavigator
        '
        Me.OldGoodMap_ResultBindingNavigator.AddNewItem = Me.BindingNavigatorAddNewItem
        Me.OldGoodMap_ResultBindingNavigator.BindingSource = Me.OldGoodMap_ResultBindingSource
        Me.OldGoodMap_ResultBindingNavigator.CountItem = Me.BindingNavigatorCountItem
        Me.OldGoodMap_ResultBindingNavigator.DeleteItem = Me.BindingNavigatorDeleteItem
        Me.OldGoodMap_ResultBindingNavigator.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.OldGoodMap_ResultBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem, Me.OldGoodMap_ResultBindingNavigatorSaveItem, Me.ToolStripSeparator1, Me.ToolStripLabel1, Me.ToolStripButton1, Me.ToolStripButton2})
        Me.OldGoodMap_ResultBindingNavigator.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
        Me.OldGoodMap_ResultBindingNavigator.Location = New System.Drawing.Point(0, 344)
        Me.OldGoodMap_ResultBindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.OldGoodMap_ResultBindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.OldGoodMap_ResultBindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.OldGoodMap_ResultBindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.OldGoodMap_ResultBindingNavigator.Name = "OldGoodMap_ResultBindingNavigator"
        Me.OldGoodMap_ResultBindingNavigator.PositionItem = Me.BindingNavigatorPositionItem
        Me.OldGoodMap_ResultBindingNavigator.Size = New System.Drawing.Size(755, 25)
        Me.OldGoodMap_ResultBindingNavigator.TabIndex = 0
        Me.OldGoodMap_ResultBindingNavigator.Text = "BindingNavigator1"
        '
        'BindingNavigatorAddNewItem
        '
        Me.BindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorAddNewItem.Image = CType(resources.GetObject("BindingNavigatorAddNewItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorAddNewItem.Name = "BindingNavigatorAddNewItem"
        Me.BindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorAddNewItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorAddNewItem.Text = "Добавить"
        '
        'OldGoodMap_ResultBindingSource
        '
        Me.OldGoodMap_ResultBindingSource.DataSource = GetType(Service.oldGoodMap_Result)
        '
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(43, 22)
        Me.BindingNavigatorCountItem.Text = "для {0}"
        Me.BindingNavigatorCountItem.ToolTipText = "Общее число элементов"
        '
        'BindingNavigatorDeleteItem
        '
        Me.BindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorDeleteItem.Image = CType(resources.GetObject("BindingNavigatorDeleteItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorDeleteItem.Name = "BindingNavigatorDeleteItem"
        Me.BindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorDeleteItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorDeleteItem.Text = "Удалить"
        '
        'BindingNavigatorMoveFirstItem
        '
        Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
        Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveFirstItem.Text = "Переместить в начало"
        '
        'BindingNavigatorMovePreviousItem
        '
        Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
        Me.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMovePreviousItem.Text = "Переместить назад"
        '
        'BindingNavigatorSeparator
        '
        Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorPositionItem
        '
        Me.BindingNavigatorPositionItem.AccessibleName = "Положение"
        Me.BindingNavigatorPositionItem.AutoSize = False
        Me.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem"
        Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(50, 23)
        Me.BindingNavigatorPositionItem.Text = "0"
        Me.BindingNavigatorPositionItem.ToolTipText = "Текущее положение"
        '
        'BindingNavigatorSeparator1
        '
        Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator1"
        Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorMoveNextItem
        '
        Me.BindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveNextItem.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
        Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveNextItem.Text = "Переместить вперед"
        '
        'BindingNavigatorMoveLastItem
        '
        Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
        Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveLastItem.Text = "Переместить в конец"
        '
        'BindingNavigatorSeparator2
        '
        Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2"
        Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'OldGoodMap_ResultBindingNavigatorSaveItem
        '
        Me.OldGoodMap_ResultBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.OldGoodMap_ResultBindingNavigatorSaveItem.Enabled = False
        Me.OldGoodMap_ResultBindingNavigatorSaveItem.Image = CType(resources.GetObject("OldGoodMap_ResultBindingNavigatorSaveItem.Image"), System.Drawing.Image)
        Me.OldGoodMap_ResultBindingNavigatorSaveItem.Name = "OldGoodMap_ResultBindingNavigatorSaveItem"
        Me.OldGoodMap_ResultBindingNavigatorSaveItem.Size = New System.Drawing.Size(23, 22)
        Me.OldGoodMap_ResultBindingNavigatorSaveItem.Text = "Сохранить данные"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(78, 22)
        Me.ToolStripLabel1.Text = "Редактируем"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(138, 22)
        Me.ToolStripButton1.Text = "Сохранить текущую"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(148, 22)
        Me.ToolStripButton2.Text = "Сохранить на сервере"
        '
        'АртикулTextBox
        '
        Me.АртикулTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.OldGoodMap_ResultBindingSource, "Артикул", True))
        Me.АртикулTextBox.Location = New System.Drawing.Point(216, 31)
        Me.АртикулTextBox.Name = "АртикулTextBox"
        Me.АртикулTextBox.Size = New System.Drawing.Size(48, 20)
        Me.АртикулTextBox.TabIndex = 2
        '
        'Буржуи_на_выставкеTextBox
        '
        Me.Буржуи_на_выставкеTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.OldGoodMap_ResultBindingSource, "Буржуи_на_выставке", True))
        Me.Буржуи_на_выставкеTextBox.Location = New System.Drawing.Point(134, 19)
        Me.Буржуи_на_выставкеTextBox.Name = "Буржуи_на_выставкеTextBox"
        Me.Буржуи_на_выставкеTextBox.Size = New System.Drawing.Size(57, 20)
        Me.Буржуи_на_выставкеTextBox.TabIndex = 4
        Me.Буржуи_на_выставкеTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Валюта__Буржуи_на_выставке_ComboBox
        '
        Me.Валюта__Буржуи_на_выставке_ComboBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.OldGoodMap_ResultBindingSource, "Валюта__Буржуи_на_выставке_", True))
        Me.Валюта__Буржуи_на_выставке_ComboBox.FormattingEnabled = True
        Me.Валюта__Буржуи_на_выставке_ComboBox.Items.AddRange(New Object() {"", "RUR", "EUR", "USD"})
        Me.Валюта__Буржуи_на_выставке_ComboBox.Location = New System.Drawing.Point(196, 19)
        Me.Валюта__Буржуи_на_выставке_ComboBox.Name = "Валюта__Буржуи_на_выставке_ComboBox"
        Me.Валюта__Буржуи_на_выставке_ComboBox.Size = New System.Drawing.Size(45, 21)
        Me.Валюта__Буржуи_на_выставке_ComboBox.TabIndex = 6
        '
        'Валюта__Закупочная_цена_ComboBox
        '
        Me.Валюта__Закупочная_цена_ComboBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.OldGoodMap_ResultBindingSource, "Валюта__Закупочная_цена_", True))
        Me.Валюта__Закупочная_цена_ComboBox.FormattingEnabled = True
        Me.Валюта__Закупочная_цена_ComboBox.Items.AddRange(New Object() {"", "RUR", "EUR", "USD"})
        Me.Валюта__Закупочная_цена_ComboBox.Location = New System.Drawing.Point(170, 64)
        Me.Валюта__Закупочная_цена_ComboBox.Name = "Валюта__Закупочная_цена_ComboBox"
        Me.Валюта__Закупочная_цена_ComboBox.Size = New System.Drawing.Size(45, 21)
        Me.Валюта__Закупочная_цена_ComboBox.TabIndex = 8
        '
        'Валюта__Инвойс_ComboBox
        '
        Me.Валюта__Инвойс_ComboBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.OldGoodMap_ResultBindingSource, "Валюта__Инвойс_", True))
        Me.Валюта__Инвойс_ComboBox.FormattingEnabled = True
        Me.Валюта__Инвойс_ComboBox.Items.AddRange(New Object() {"", "RUR", "EUR", "USD"})
        Me.Валюта__Инвойс_ComboBox.Location = New System.Drawing.Point(132, 6)
        Me.Валюта__Инвойс_ComboBox.Name = "Валюта__Инвойс_ComboBox"
        Me.Валюта__Инвойс_ComboBox.Size = New System.Drawing.Size(45, 21)
        Me.Валюта__Инвойс_ComboBox.TabIndex = 10
        '
        'Валюта__Розничная_в_офисе_ComboBox
        '
        Me.Валюта__Розничная_в_офисе_ComboBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.OldGoodMap_ResultBindingSource, "Валюта__Розничная_в_офисе_", True))
        Me.Валюта__Розничная_в_офисе_ComboBox.FormattingEnabled = True
        Me.Валюта__Розничная_в_офисе_ComboBox.Items.AddRange(New Object() {"", "RUR", "EUR", "USD"})
        Me.Валюта__Розничная_в_офисе_ComboBox.Location = New System.Drawing.Point(226, 45)
        Me.Валюта__Розничная_в_офисе_ComboBox.Name = "Валюта__Розничная_в_офисе_ComboBox"
        Me.Валюта__Розничная_в_офисе_ComboBox.Size = New System.Drawing.Size(45, 21)
        Me.Валюта__Розничная_в_офисе_ComboBox.TabIndex = 12
        '
        'Валюта__Розничная_цена_в_магазине_ComboBox
        '
        Me.Валюта__Розничная_цена_в_магазине_ComboBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.OldGoodMap_ResultBindingSource, "Валюта__Розничная_цена_в_магазине_", True))
        Me.Валюта__Розничная_цена_в_магазине_ComboBox.FormattingEnabled = True
        Me.Валюта__Розничная_цена_в_магазине_ComboBox.Items.AddRange(New Object() {"", "RUR", "EUR", "USD"})
        Me.Валюта__Розничная_цена_в_магазине_ComboBox.Location = New System.Drawing.Point(226, 19)
        Me.Валюта__Розничная_цена_в_магазине_ComboBox.Name = "Валюта__Розничная_цена_в_магазине_ComboBox"
        Me.Валюта__Розничная_цена_в_магазине_ComboBox.Size = New System.Drawing.Size(45, 21)
        Me.Валюта__Розничная_цена_в_магазине_ComboBox.TabIndex = 14
        '
        'Время_препарации_в_часах__общее_TextBox
        '
        Me.Время_препарации_в_часах__общее_TextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.OldGoodMap_ResultBindingSource, "Время_препарации_в_часах__общее_", True))
        Me.Время_препарации_в_часах__общее_TextBox.Location = New System.Drawing.Point(213, 164)
        Me.Время_препарации_в_часах__общее_TextBox.Name = "Время_препарации_в_часах__общее_TextBox"
        Me.Время_препарации_в_часах__общее_TextBox.Size = New System.Drawing.Size(39, 20)
        Me.Время_препарации_в_часах__общее_TextBox.TabIndex = 18
        '
        'Единица_измеренияTextBox
        '
        Me.Единица_измеренияTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.OldGoodMap_ResultBindingSource, "Единица_измерения", True))
        Me.Единица_измеренияTextBox.Location = New System.Drawing.Point(67, 149)
        Me.Единица_измеренияTextBox.Name = "Единица_измеренияTextBox"
        Me.Единица_измеренияTextBox.Size = New System.Drawing.Size(43, 20)
        Me.Единица_измеренияTextBox.TabIndex = 22
        '
        'Закупочная_ценаTextBox
        '
        Me.Закупочная_ценаTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.OldGoodMap_ResultBindingSource, "Закупочная_цена", True))
        Me.Закупочная_ценаTextBox.Location = New System.Drawing.Point(107, 65)
        Me.Закупочная_ценаTextBox.Name = "Закупочная_ценаTextBox"
        Me.Закупочная_ценаTextBox.Size = New System.Drawing.Size(57, 20)
        Me.Закупочная_ценаTextBox.TabIndex = 24
        Me.Закупочная_ценаTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ИнвойсTextBox
        '
        Me.ИнвойсTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.OldGoodMap_ResultBindingSource, "Инвойс", True))
        Me.ИнвойсTextBox.Location = New System.Drawing.Point(69, 6)
        Me.ИнвойсTextBox.Name = "ИнвойсTextBox"
        Me.ИнвойсTextBox.Size = New System.Drawing.Size(57, 20)
        Me.ИнвойсTextBox.TabIndex = 26
        Me.ИнвойсTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'КодTextBox
        '
        Me.КодTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.OldGoodMap_ResultBindingSource, "Код", True))
        Me.КодTextBox.Location = New System.Drawing.Point(90, 31)
        Me.КодTextBox.Name = "КодTextBox"
        Me.КодTextBox.Size = New System.Drawing.Size(49, 20)
        Me.КодTextBox.TabIndex = 28
        '
        'НаименованиеTextBox
        '
        Me.НаименованиеTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.OldGoodMap_ResultBindingSource, "Наименование", True))
        'Me.НаименованиеTextBox.DataBindings(0).DataSourceUpdateMode = Windows.Forms.DataSourceUpdateMode.OnPropertyChanged
        Me.НаименованиеTextBox.Location = New System.Drawing.Point(90, 84)
        Me.НаименованиеTextBox.Multiline = True
        Me.НаименованиеTextBox.Name = "НаименованиеTextBox"
        Me.НаименованиеTextBox.Size = New System.Drawing.Size(249, 52)
        Me.НаименованиеTextBox.TabIndex = 30
        '
        'Ответственный_ПрепараторTextBox
        '
        Me.Ответственный_ПрепараторTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.OldGoodMap_ResultBindingSource, "Ответственный_Препаратор", True))
        Me.Ответственный_ПрепараторTextBox.Location = New System.Drawing.Point(166, 37)
        Me.Ответственный_ПрепараторTextBox.Name = "Ответственный_ПрепараторTextBox"
        Me.Ответственный_ПрепараторTextBox.Size = New System.Drawing.Size(174, 20)
        Me.Ответственный_ПрепараторTextBox.TabIndex = 32
        '
        'Полная_стоимость_закупки_в_рубляхTextBox
        '
        Me.Полная_стоимость_закупки_в_рубляхTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.OldGoodMap_ResultBindingSource, "Полная_стоимость_закупки_в_рублях", True))
        Me.Полная_стоимость_закупки_в_рубляхTextBox.Location = New System.Drawing.Point(205, 154)
        Me.Полная_стоимость_закупки_в_рубляхTextBox.Name = "Полная_стоимость_закупки_в_рубляхTextBox"
        Me.Полная_стоимость_закупки_в_рубляхTextBox.Size = New System.Drawing.Size(47, 20)
        Me.Полная_стоимость_закупки_в_рубляхTextBox.TabIndex = 34
        Me.Полная_стоимость_закупки_в_рубляхTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Полная_стоимость_препарации_в_рубляхTextBox
        '
        Me.Полная_стоимость_препарации_в_рубляхTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.OldGoodMap_ResultBindingSource, "Полная_стоимость_препарации_в_рублях", True))
        Me.Полная_стоимость_препарации_в_рубляхTextBox.Location = New System.Drawing.Point(232, 192)
        Me.Полная_стоимость_препарации_в_рубляхTextBox.Name = "Полная_стоимость_препарации_в_рубляхTextBox"
        Me.Полная_стоимость_препарации_в_рубляхTextBox.Size = New System.Drawing.Size(59, 20)
        Me.Полная_стоимость_препарации_в_рубляхTextBox.TabIndex = 36
        '
        'Препараторы_и_времяTextBox
        '
        Me.Препараторы_и_времяTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.OldGoodMap_ResultBindingSource, "Препараторы_и_время", True))
        Me.Препараторы_и_времяTextBox.Location = New System.Drawing.Point(10, 80)
        Me.Препараторы_и_времяTextBox.Multiline = True
        Me.Препараторы_и_времяTextBox.Name = "Препараторы_и_времяTextBox"
        Me.Препараторы_и_времяTextBox.Size = New System.Drawing.Size(330, 78)
        Me.Препараторы_и_времяTextBox.TabIndex = 38
        '
        'Производственный_номер_или_EAN13TextBox
        '
        Me.Производственный_номер_или_EAN13TextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.OldGoodMap_ResultBindingSource, "Производственный_номер_или_EAN13", True))
        Me.Производственный_номер_или_EAN13TextBox.Location = New System.Drawing.Point(155, 11)
        Me.Производственный_номер_или_EAN13TextBox.Name = "Производственный_номер_или_EAN13TextBox"
        Me.Производственный_номер_или_EAN13TextBox.Size = New System.Drawing.Size(88, 20)
        Me.Производственный_номер_или_EAN13TextBox.TabIndex = 40
        '
        'Розничная_в_офисеTextBox
        '
        Me.Розничная_в_офисеTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.OldGoodMap_ResultBindingSource, "Розничная_в_офисе", True))
        Me.Розничная_в_офисеTextBox.Location = New System.Drawing.Point(164, 46)
        Me.Розничная_в_офисеTextBox.Name = "Розничная_в_офисеTextBox"
        Me.Розничная_в_офисеTextBox.Size = New System.Drawing.Size(57, 20)
        Me.Розничная_в_офисеTextBox.TabIndex = 42
        Me.Розничная_в_офисеTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Розничная_цена_в_магазинеTextBox
        '
        Me.Розничная_цена_в_магазинеTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.OldGoodMap_ResultBindingSource, "Розничная_цена_в_магазине", True))
        Me.Розничная_цена_в_магазинеTextBox.Location = New System.Drawing.Point(164, 19)
        Me.Розничная_цена_в_магазинеTextBox.Name = "Розничная_цена_в_магазинеTextBox"
        Me.Розничная_цена_в_магазинеTextBox.Size = New System.Drawing.Size(57, 20)
        Me.Розничная_цена_в_магазинеTextBox.TabIndex = 44
        Me.Розничная_цена_в_магазинеTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Экспедиционное_закупочное_примечаниеTextBox
        '
        Me.Экспедиционное_закупочное_примечаниеTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.OldGoodMap_ResultBindingSource, "Экспедиционное_закупочное_примечание", True))
        Me.Экспедиционное_закупочное_примечаниеTextBox.Location = New System.Drawing.Point(10, 90)
        Me.Экспедиционное_закупочное_примечаниеTextBox.Multiline = True
        Me.Экспедиционное_закупочное_примечаниеTextBox.Name = "Экспедиционное_закупочное_примечаниеTextBox"
        Me.Экспедиционное_закупочное_примечаниеTextBox.Size = New System.Drawing.Size(289, 27)
        Me.Экспедиционное_закупочное_примечаниеTextBox.TabIndex = 46
        '
        'Экспедиционный_закупочный_номерTextBox
        '
        Me.Экспедиционный_закупочный_номерTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.OldGoodMap_ResultBindingSource, "Экспедиционный_закупочный_номер", True))
        Me.Экспедиционный_закупочный_номерTextBox.Location = New System.Drawing.Point(178, 47)
        Me.Экспедиционный_закупочный_номерTextBox.Name = "Экспедиционный_закупочный_номерTextBox"
        Me.Экспедиционный_закупочный_номерTextBox.Size = New System.Drawing.Size(121, 20)
        Me.Экспедиционный_закупочный_номерTextBox.TabIndex = 48
        '
        'Экспедиция__код_TextBox
        '
        Me.Экспедиция__код_TextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.OldGoodMap_ResultBindingSource, "Экспедиция__код_", True))
        Me.Экспедиция__код_TextBox.Location = New System.Drawing.Point(109, 19)
        Me.Экспедиция__код_TextBox.Name = "Экспедиция__код_TextBox"
        Me.Экспедиция__код_TextBox.Size = New System.Drawing.Size(190, 20)
        Me.Экспедиция__код_TextBox.TabIndex = 50
        '
        'btGetNewCode
        '
        Me.btGetNewCode.Location = New System.Drawing.Point(8, 17)
        Me.btGetNewCode.Name = "btGetNewCode"
        Me.btGetNewCode.Size = New System.Drawing.Size(75, 23)
        Me.btGetNewCode.TabIndex = 51
        Me.btGetNewCode.Text = "Получить.."
        Me.btGetNewCode.UseVisualStyleBackColor = True
        '
        'cbUomUser
        '
        Me.cbUomUser.FormattingEnabled = True
        Me.cbUomUser.Items.AddRange(New Object() {"", "шт", "кг", "гр", "лот", "е"})
        Me.cbUomUser.Location = New System.Drawing.Point(115, 148)
        Me.cbUomUser.Name = "cbUomUser"
        Me.cbUomUser.Size = New System.Drawing.Size(48, 21)
        Me.cbUomUser.TabIndex = 52
        '
        'cbGroups
        '
        Me.cbGroups.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbGroups.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbGroups.DataBindings.Add(New System.Windows.Forms.Binding("SelectedItem", Me.OldGoodMap_ResultBindingSource, "Группы", True))
        Me.cbGroups.FormattingEnabled = True
        Me.cbGroups.Location = New System.Drawing.Point(63, 57)
        Me.cbGroups.Name = "cbGroups"
        Me.cbGroups.Size = New System.Drawing.Size(210, 21)
        Me.cbGroups.TabIndex = 53
        '
        'btGetNameFromDB
        '
        Me.btGetNameFromDB.Location = New System.Drawing.Point(6, 111)
        Me.btGetNameFromDB.Name = "btGetNameFromDB"
        Me.btGetNameFromDB.Size = New System.Drawing.Size(75, 23)
        Me.btGetNameFromDB.TabIndex = 54
        Me.btGetNameFromDB.Text = "Из БД.."
        Me.btGetNameFromDB.UseVisualStyleBackColor = True
        '
        'tbctlMain
        '
        Me.tbctlMain.Controls.Add(Me.tpОприходование)
        Me.tbctlMain.Controls.Add(Me.tpPrices)
        Me.tbctlMain.Location = New System.Drawing.Point(0, 3)
        Me.tbctlMain.Name = "tbctlMain"
        Me.tbctlMain.SelectedIndex = 0
        Me.tbctlMain.Size = New System.Drawing.Size(746, 341)
        Me.tbctlMain.TabIndex = 55
        '
        'tpОприходование
        '
        Me.tpОприходование.Controls.Add(Me.gbExpedition)
        Me.tpОприходование.Controls.Add(Me.gbNumbers)
        Me.tpОприходование.Controls.Add(Me.gbPreparator)
        Me.tpОприходование.Location = New System.Drawing.Point(4, 22)
        Me.tpОприходование.Name = "tpОприходование"
        Me.tpОприходование.Padding = New System.Windows.Forms.Padding(3)
        Me.tpОприходование.Size = New System.Drawing.Size(738, 315)
        Me.tpОприходование.TabIndex = 0
        Me.tpОприходование.Text = "Оформление"
        Me.tpОприходование.UseVisualStyleBackColor = True
        '
        'gbExpedition
        '
        Me.gbExpedition.Controls.Add(Me.Экспедиция__код_TextBox)
        Me.gbExpedition.Controls.Add(Me.Экспедиционное_закупочное_примечаниеTextBox)
        Me.gbExpedition.Controls.Add(Экспедиционный_закупочный_номерLabel)
        Me.gbExpedition.Controls.Add(Экспедиционное_закупочное_примечаниеLabel)
        Me.gbExpedition.Controls.Add(Экспедиция__код_Label)
        Me.gbExpedition.Controls.Add(Me.Экспедиционный_закупочный_номерTextBox)
        Me.gbExpedition.Location = New System.Drawing.Point(6, 192)
        Me.gbExpedition.Name = "gbExpedition"
        Me.gbExpedition.Size = New System.Drawing.Size(312, 121)
        Me.gbExpedition.TabIndex = 58
        Me.gbExpedition.TabStop = False
        Me.gbExpedition.Text = "Экспедиция или закупка"
        '
        'gbNumbers
        '
        Me.gbNumbers.Controls.Add(Me.ВесTextBox)
        Me.gbNumbers.Controls.Add(Me.cbWeightUser)
        Me.gbNumbers.Controls.Add(Me.ВесLabel)
        Me.gbNumbers.Controls.Add(Me.btClearAll)
        Me.gbNumbers.Controls.Add(Me.btQuery)
        Me.gbNumbers.Controls.Add(Me.btMoveToCode)
        Me.gbNumbers.Controls.Add(Me.btMoveToArticul)
        Me.gbNumbers.Controls.Add(Me.АртикулTextBox)
        Me.gbNumbers.Controls.Add(ГруппыLabel)
        Me.gbNumbers.Controls.Add(Me.НаименованиеTextBox)
        Me.gbNumbers.Controls.Add(Единица_измеренияLabel)
        Me.gbNumbers.Controls.Add(Me.btGetNameFromDB)
        Me.gbNumbers.Controls.Add(АртикулLabel)
        Me.gbNumbers.Controls.Add(НаименованиеLabel)
        Me.gbNumbers.Controls.Add(Me.Единица_измеренияTextBox)
        Me.gbNumbers.Controls.Add(Me.cbGroups)
        Me.gbNumbers.Controls.Add(Me.btGetNewCode)
        Me.gbNumbers.Controls.Add(Me.КодTextBox)
        Me.gbNumbers.Controls.Add(КодLabel)
        Me.gbNumbers.Controls.Add(Me.cbUomUser)
        Me.gbNumbers.Location = New System.Drawing.Point(6, 6)
        Me.gbNumbers.Name = "gbNumbers"
        Me.gbNumbers.Size = New System.Drawing.Size(352, 180)
        Me.gbNumbers.TabIndex = 57
        Me.gbNumbers.TabStop = False
        Me.gbNumbers.Text = "Оформление"
        '
        'ВесTextBox
        '
        Me.ВесTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.OldGoodMap_ResultBindingSource, "Вес", True))
        Me.ВесTextBox.Location = New System.Drawing.Point(237, 148)
        Me.ВесTextBox.Name = "ВесTextBox"
        Me.ВесTextBox.Size = New System.Drawing.Size(43, 20)
        Me.ВесTextBox.TabIndex = 62
        '
        'cbWeightUser
        '
        Me.cbWeightUser.FormattingEnabled = True
        Me.cbWeightUser.Items.AddRange(New Object() {"", "кг", "гр", "кар", "унц", "фунт"})
        Me.cbWeightUser.Location = New System.Drawing.Point(285, 148)
        Me.cbWeightUser.Name = "cbWeightUser"
        Me.cbWeightUser.Size = New System.Drawing.Size(48, 21)
        Me.cbWeightUser.TabIndex = 61
        '
        'ВесLabel
        '
        Me.ВесLabel.AutoSize = True
        Me.ВесLabel.Location = New System.Drawing.Point(205, 151)
        Me.ВесLabel.Name = "ВесLabel"
        Me.ВесLabel.Size = New System.Drawing.Size(26, 13)
        Me.ВесLabel.TabIndex = 60
        Me.ВесLabel.Text = "Вес"
        '
        'btClearAll
        '
        Me.btClearAll.Location = New System.Drawing.Point(279, 45)
        Me.btClearAll.Name = "btClearAll"
        Me.btClearAll.Size = New System.Drawing.Size(67, 28)
        Me.btClearAll.TabIndex = 59
        Me.btClearAll.Text = "Очистить"
        Me.btClearAll.UseVisualStyleBackColor = True
        '
        'btQuery
        '
        Me.btQuery.Location = New System.Drawing.Point(279, 12)
        Me.btQuery.Name = "btQuery"
        Me.btQuery.Size = New System.Drawing.Size(67, 28)
        Me.btQuery.TabIndex = 58
        Me.btQuery.Text = "Запрос"
        Me.btQuery.UseVisualStyleBackColor = True
        '
        'btMoveToCode
        '
        Me.btMoveToCode.Location = New System.Drawing.Point(183, 29)
        Me.btMoveToCode.Name = "btMoveToCode"
        Me.btMoveToCode.Size = New System.Drawing.Size(27, 23)
        Me.btMoveToCode.TabIndex = 56
        Me.btMoveToCode.Text = "<<"
        Me.btMoveToCode.UseVisualStyleBackColor = True
        '
        'btMoveToArticul
        '
        Me.btMoveToArticul.Location = New System.Drawing.Point(145, 29)
        Me.btMoveToArticul.Name = "btMoveToArticul"
        Me.btMoveToArticul.Size = New System.Drawing.Size(32, 23)
        Me.btMoveToArticul.TabIndex = 55
        Me.btMoveToArticul.Text = ">>"
        Me.btMoveToArticul.UseVisualStyleBackColor = True
        '
        'gbPreparator
        '
        Me.gbPreparator.Controls.Add(Me.tbctlPreparator)
        Me.gbPreparator.Location = New System.Drawing.Point(364, 7)
        Me.gbPreparator.Name = "gbPreparator"
        Me.gbPreparator.Size = New System.Drawing.Size(360, 295)
        Me.gbPreparator.TabIndex = 56
        Me.gbPreparator.TabStop = False
        Me.gbPreparator.Text = "Препарация/доделка"
        '
        'tbctlPreparator
        '
        Me.tbctlPreparator.Controls.Add(Me.tpPreparator_DB)
        Me.tbctlPreparator.Controls.Add(Me.tpPreparator_Calculate)
        Me.tbctlPreparator.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbctlPreparator.Location = New System.Drawing.Point(3, 16)
        Me.tbctlPreparator.Multiline = True
        Me.tbctlPreparator.Name = "tbctlPreparator"
        Me.tbctlPreparator.SelectedIndex = 0
        Me.tbctlPreparator.Size = New System.Drawing.Size(354, 276)
        Me.tbctlPreparator.TabIndex = 0
        '
        'tpPreparator_DB
        '
        Me.tpPreparator_DB.Controls.Add(Me.Label1)
        Me.tpPreparator_DB.Controls.Add(Me.btCalculateSalary)
        Me.tpPreparator_DB.Controls.Add(Me.Ответственный_ПрепараторTextBox)
        Me.tpPreparator_DB.Controls.Add(Ответственный_ПрепараторLabel)
        Me.tpPreparator_DB.Controls.Add(Полная_стоимость_препарации_в_рубляхLabel)
        Me.tpPreparator_DB.Controls.Add(Me.Полная_стоимость_препарации_в_рубляхTextBox)
        Me.tpPreparator_DB.Controls.Add(Препараторы_и_времяLabel)
        Me.tpPreparator_DB.Controls.Add(Me.Препараторы_и_времяTextBox)
        Me.tpPreparator_DB.Controls.Add(Производственный_номер_или_EAN13Label)
        Me.tpPreparator_DB.Controls.Add(Me.Производственный_номер_или_EAN13TextBox)
        Me.tpPreparator_DB.Controls.Add(Me.Время_препарации_в_часах__общее_TextBox)
        Me.tpPreparator_DB.Controls.Add(Время_препарации_в_часах__общее_Label)
        Me.tpPreparator_DB.Location = New System.Drawing.Point(4, 22)
        Me.tpPreparator_DB.Name = "tpPreparator_DB"
        Me.tpPreparator_DB.Padding = New System.Windows.Forms.Padding(3)
        Me.tpPreparator_DB.Size = New System.Drawing.Size(346, 250)
        Me.tpPreparator_DB.TabIndex = 0
        Me.tpPreparator_DB.Text = "Из БД"
        Me.tpPreparator_DB.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(23, 226)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(197, 13)
        Me.Label1.TabIndex = 56
        Me.Label1.Text = "*все значения могут быть заменены!"
        '
        'btCalculateSalary
        '
        Me.btCalculateSalary.Location = New System.Drawing.Point(232, 221)
        Me.btCalculateSalary.Name = "btCalculateSalary"
        Me.btCalculateSalary.Size = New System.Drawing.Size(108, 23)
        Me.btCalculateSalary.TabIndex = 55
        Me.btCalculateSalary.Text = "Рассчитать"
        Me.btCalculateSalary.UseVisualStyleBackColor = True
        '
        'tpPreparator_Calculate
        '
        Me.tpPreparator_Calculate.Controls.Add(Me.UC_preparator_calc1)
        Me.tpPreparator_Calculate.Location = New System.Drawing.Point(4, 22)
        Me.tpPreparator_Calculate.Name = "tpPreparator_Calculate"
        Me.tpPreparator_Calculate.Padding = New System.Windows.Forms.Padding(3)
        Me.tpPreparator_Calculate.Size = New System.Drawing.Size(346, 250)
        Me.tpPreparator_Calculate.TabIndex = 1
        Me.tpPreparator_Calculate.Text = "Рассчет"
        Me.tpPreparator_Calculate.UseVisualStyleBackColor = True
        '
        'tpPrices
        '
        Me.tpPrices.AutoScroll = True
        Me.tpPrices.Controls.Add(Me.gbStorage)
        Me.tpPrices.Controls.Add(Me.gbPricesEC)
        Me.tpPrices.Controls.Add(Me.gbPricesRUS)
        Me.tpPrices.Controls.Add(Me.gbBuying)
        Me.tpPrices.Location = New System.Drawing.Point(4, 22)
        Me.tpPrices.Name = "tpPrices"
        Me.tpPrices.Padding = New System.Windows.Forms.Padding(3)
        Me.tpPrices.Size = New System.Drawing.Size(738, 315)
        Me.tpPrices.TabIndex = 1
        Me.tpPrices.Text = "Цены и склад"
        Me.tpPrices.UseVisualStyleBackColor = True
        '
        'gbStorage
        '
        Me.gbStorage.Location = New System.Drawing.Point(394, 197)
        Me.gbStorage.Name = "gbStorage"
        Me.gbStorage.Size = New System.Drawing.Size(329, 68)
        Me.gbStorage.TabIndex = 38
        Me.gbStorage.TabStop = False
        Me.gbStorage.Text = "Склад"
        '
        'gbPricesEC
        '
        Me.gbPricesEC.Controls.Add(Me.Валюта__EBAY_ComboBox)
        Me.gbPricesEC.Controls.Add(EBAYLabel)
        Me.gbPricesEC.Controls.Add(Me.EBAYTextBox)
        Me.gbPricesEC.Controls.Add(Буржуи_на_выставкеLabel)
        Me.gbPricesEC.Controls.Add(Me.Буржуи_на_выставкеTextBox)
        Me.gbPricesEC.Controls.Add(Me.Валюта__Буржуи_на_выставке_ComboBox)
        Me.gbPricesEC.Location = New System.Drawing.Point(394, 108)
        Me.gbPricesEC.Name = "gbPricesEC"
        Me.gbPricesEC.Size = New System.Drawing.Size(329, 83)
        Me.gbPricesEC.TabIndex = 37
        Me.gbPricesEC.TabStop = False
        Me.gbPricesEC.Text = "Цены ЕС"
        '
        'Валюта__EBAY_ComboBox
        '
        Me.Валюта__EBAY_ComboBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.OldGoodMap_ResultBindingSource, "Валюта__EBAY_", True))
        Me.Валюта__EBAY_ComboBox.FormattingEnabled = True
        Me.Валюта__EBAY_ComboBox.Items.AddRange(New Object() {"", "RUR", "EUR", "USD"})
        Me.Валюта__EBAY_ComboBox.Location = New System.Drawing.Point(196, 44)
        Me.Валюта__EBAY_ComboBox.Name = "Валюта__EBAY_ComboBox"
        Me.Валюта__EBAY_ComboBox.Size = New System.Drawing.Size(45, 21)
        Me.Валюта__EBAY_ComboBox.TabIndex = 8
        '
        'EBAYTextBox
        '
        Me.EBAYTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.OldGoodMap_ResultBindingSource, "EBAY", True))
        Me.EBAYTextBox.Location = New System.Drawing.Point(134, 45)
        Me.EBAYTextBox.Name = "EBAYTextBox"
        Me.EBAYTextBox.Size = New System.Drawing.Size(57, 20)
        Me.EBAYTextBox.TabIndex = 7
        Me.EBAYTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'gbPricesRUS
        '
        Me.gbPricesRUS.Controls.Add(Розничная_цена_в_магазинеLabel)
        Me.gbPricesRUS.Controls.Add(Me.Розничная_цена_в_магазинеTextBox)
        Me.gbPricesRUS.Controls.Add(Me.Валюта__Розничная_цена_в_магазине_ComboBox)
        Me.gbPricesRUS.Controls.Add(Розничная_в_офисеLabel)
        Me.gbPricesRUS.Controls.Add(Me.Розничная_в_офисеTextBox)
        Me.gbPricesRUS.Controls.Add(Me.Валюта__Розничная_в_офисе_ComboBox)
        Me.gbPricesRUS.Location = New System.Drawing.Point(394, 9)
        Me.gbPricesRUS.Name = "gbPricesRUS"
        Me.gbPricesRUS.Size = New System.Drawing.Size(290, 84)
        Me.gbPricesRUS.TabIndex = 36
        Me.gbPricesRUS.TabStop = False
        Me.gbPricesRUS.Text = "Цены Россия"
        '
        'gbBuying
        '
        Me.gbBuying.Controls.Add(Me.tbctlBuying)
        Me.gbBuying.Location = New System.Drawing.Point(6, 6)
        Me.gbBuying.Name = "gbBuying"
        Me.gbBuying.Size = New System.Drawing.Size(377, 262)
        Me.gbBuying.TabIndex = 35
        Me.gbBuying.TabStop = False
        Me.gbBuying.Text = "Закупка"
        '
        'tbctlBuying
        '
        Me.tbctlBuying.Controls.Add(Me.tpBuying_DB)
        Me.tbctlBuying.Controls.Add(Me.tpBuying_Calculate)
        Me.tbctlBuying.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbctlBuying.Location = New System.Drawing.Point(3, 16)
        Me.tbctlBuying.Name = "tbctlBuying"
        Me.tbctlBuying.SelectedIndex = 0
        Me.tbctlBuying.Size = New System.Drawing.Size(371, 243)
        Me.tbctlBuying.TabIndex = 0
        '
        'tpBuying_DB
        '
        Me.tpBuying_DB.Controls.Add(Me.Расчет_розницыButton)
        Me.tpBuying_DB.Controls.Add(Me.Расчитать_всеButton)
        Me.tpBuying_DB.Controls.Add(Me.СтандартныеНакладныеButton)
        Me.tpBuying_DB.Controls.Add(Me.СбросНакладныхButton)
        Me.tpBuying_DB.Controls.Add(Me.СбросПеревозкиButton)
        Me.tpBuying_DB.Controls.Add(Me.ComboBox1)
        Me.tpBuying_DB.Controls.Add(Me.ПеревозкаЗаКГTextBox)
        Me.tpBuying_DB.Controls.Add(Me.Label4)
        Me.tpBuying_DB.Controls.Add(Me.Перевозка_рассчетButton)
        Me.tpBuying_DB.Controls.Add(Me.НакладныеTextBox)
        Me.tpBuying_DB.Controls.Add(Label3)
        Me.tpBuying_DB.Controls.Add(Me.ПеревозкаВалютаComboBox)
        Me.tpBuying_DB.Controls.Add(Me.ПеревозкаTextBox)
        Me.tpBuying_DB.Controls.Add(Me.Label2)
        Me.tpBuying_DB.Controls.Add(Me.Закупочная_цена_Button)
        Me.tpBuying_DB.Controls.Add(Me.btCalculateValue)
        Me.tpBuying_DB.Controls.Add(Me.Валюта__Инвойс_ComboBox)
        Me.tpBuying_DB.Controls.Add(Закупочная_ценаLabel)
        Me.tpBuying_DB.Controls.Add(Me.ИнвойсTextBox)
        Me.tpBuying_DB.Controls.Add(Полная_стоимость_закупки_в_рубляхLabel)
        Me.tpBuying_DB.Controls.Add(Me.Валюта__Закупочная_цена_ComboBox)
        Me.tpBuying_DB.Controls.Add(Me.Полная_стоимость_закупки_в_рубляхTextBox)
        Me.tpBuying_DB.Controls.Add(Me.Закупочная_ценаTextBox)
        Me.tpBuying_DB.Controls.Add(ИнвойсLabel)
        Me.tpBuying_DB.Location = New System.Drawing.Point(4, 22)
        Me.tpBuying_DB.Name = "tpBuying_DB"
        Me.tpBuying_DB.Padding = New System.Windows.Forms.Padding(3)
        Me.tpBuying_DB.Size = New System.Drawing.Size(363, 217)
        Me.tpBuying_DB.TabIndex = 0
        Me.tpBuying_DB.Text = "Из БД"
        Me.tpBuying_DB.UseVisualStyleBackColor = True
        '
        'Расчет_розницыButton
        '
        Me.Расчет_розницыButton.Location = New System.Drawing.Point(9, 188)
        Me.Расчет_розницыButton.Name = "Расчет_розницыButton"
        Me.Расчет_розницыButton.Size = New System.Drawing.Size(107, 23)
        Me.Расчет_розницыButton.TabIndex = 67
        Me.Расчет_розницыButton.Text = "Расчет розницы"
        Me.Расчет_розницыButton.UseVisualStyleBackColor = True
        '
        'Расчитать_всеButton
        '
        Me.Расчитать_всеButton.Location = New System.Drawing.Point(178, 188)
        Me.Расчитать_всеButton.Name = "Расчитать_всеButton"
        Me.Расчитать_всеButton.Size = New System.Drawing.Size(163, 23)
        Me.Расчитать_всеButton.TabIndex = 70
        Me.Расчитать_всеButton.Text = "Рассчитать все"
        Me.Расчитать_всеButton.UseVisualStyleBackColor = True
        '
        'СтандартныеНакладныеButton
        '
        Me.СтандартныеНакладныеButton.Location = New System.Drawing.Point(122, 33)
        Me.СтандартныеНакладныеButton.Name = "СтандартныеНакладныеButton"
        Me.СтандартныеНакладныеButton.Size = New System.Drawing.Size(50, 23)
        Me.СтандартныеНакладныеButton.TabIndex = 69
        Me.СтандартныеНакладныеButton.Text = "30%"
        Me.СтандартныеНакладныеButton.UseVisualStyleBackColor = True
        '
        'СбросНакладныхButton
        '
        Me.СбросНакладныхButton.Location = New System.Drawing.Point(178, 34)
        Me.СбросНакладныхButton.Name = "СбросНакладныхButton"
        Me.СбросНакладныхButton.Size = New System.Drawing.Size(50, 23)
        Me.СбросНакладныхButton.TabIndex = 68
        Me.СбросНакладныхButton.Text = "Сброс"
        Me.СбросНакладныхButton.UseVisualStyleBackColor = True
        '
        'СбросПеревозкиButton
        '
        Me.СбросПеревозкиButton.Location = New System.Drawing.Point(305, 93)
        Me.СбросПеревозкиButton.Name = "СбросПеревозкиButton"
        Me.СбросПеревозкиButton.Size = New System.Drawing.Size(50, 23)
        Me.СбросПеревозкиButton.TabIndex = 67
        Me.СбросПеревозкиButton.Text = "Сброс"
        Me.СбросПеревозкиButton.UseVisualStyleBackColor = True
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"", "RUR", "EUR", "USD"})
        Me.ComboBox1.Location = New System.Drawing.Point(151, 120)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(45, 21)
        Me.ComboBox1.TabIndex = 66
        Me.ComboBox1.Text = "EUR"
        '
        'ПеревозкаЗаКГTextBox
        '
        Me.ПеревозкаЗаКГTextBox.Location = New System.Drawing.Point(108, 120)
        Me.ПеревозкаЗаКГTextBox.Name = "ПеревозкаЗаКГTextBox"
        Me.ПеревозкаЗаКГTextBox.Size = New System.Drawing.Size(37, 20)
        Me.ПеревозкаЗаКГTextBox.TabIndex = 65
        Me.ПеревозкаЗаКГTextBox.Text = "8"
        Me.ПеревозкаЗаКГTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(60, 124)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 13)
        Me.Label4.TabIndex = 64
        Me.Label4.Text = "за 1 кг"
        '
        'Перевозка_рассчетButton
        '
        Me.Перевозка_рассчетButton.Location = New System.Drawing.Point(221, 93)
        Me.Перевозка_рассчетButton.Name = "Перевозка_рассчетButton"
        Me.Перевозка_рассчетButton.Size = New System.Drawing.Size(74, 23)
        Me.Перевозка_рассчетButton.TabIndex = 63
        Me.Перевозка_рассчетButton.Text = "Рассчитать"
        Me.Перевозка_рассчетButton.UseVisualStyleBackColor = True
        '
        'НакладныеTextBox
        '
        Me.НакладныеTextBox.Location = New System.Drawing.Point(91, 34)
        Me.НакладныеTextBox.Name = "НакладныеTextBox"
        Me.НакладныеTextBox.Size = New System.Drawing.Size(25, 20)
        Me.НакладныеTextBox.TabIndex = 62
        Me.НакладныеTextBox.Text = "30"
        Me.НакладныеTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ПеревозкаВалютаComboBox
        '
        Me.ПеревозкаВалютаComboBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.OldGoodMap_ResultBindingSource, "Валюта__Перевозка_", True))
        Me.ПеревозкаВалютаComboBox.FormattingEnabled = True
        Me.ПеревозкаВалютаComboBox.Items.AddRange(New Object() {"", "RUR", "EUR", "USD"})
        Me.ПеревозкаВалютаComboBox.Location = New System.Drawing.Point(170, 94)
        Me.ПеревозкаВалютаComboBox.Name = "ПеревозкаВалютаComboBox"
        Me.ПеревозкаВалютаComboBox.Size = New System.Drawing.Size(45, 21)
        Me.ПеревозкаВалютаComboBox.TabIndex = 59
        '
        'ПеревозкаTextBox
        '
        Me.ПеревозкаTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.OldGoodMap_ResultBindingSource, "Перевозка", True))
        Me.ПеревозкаTextBox.Location = New System.Drawing.Point(107, 94)
        Me.ПеревозкаTextBox.Name = "ПеревозкаTextBox"
        Me.ПеревозкаTextBox.Size = New System.Drawing.Size(57, 20)
        Me.ПеревозкаTextBox.TabIndex = 61
        Me.ПеревозкаTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 37)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 13)
        Me.Label2.TabIndex = 58
        Me.Label2.Text = "Накладные, %"
        '
        'Закупочная_цена_Button
        '
        Me.Закупочная_цена_Button.Location = New System.Drawing.Point(221, 64)
        Me.Закупочная_цена_Button.Name = "Закупочная_цена_Button"
        Me.Закупочная_цена_Button.Size = New System.Drawing.Size(74, 23)
        Me.Закупочная_цена_Button.TabIndex = 57
        Me.Закупочная_цена_Button.Text = "Рассчитать"
        Me.Закупочная_цена_Button.UseVisualStyleBackColor = True
        '
        'btCalculateValue
        '
        Me.btCalculateValue.Location = New System.Drawing.Point(259, 152)
        Me.btCalculateValue.Name = "btCalculateValue"
        Me.btCalculateValue.Size = New System.Drawing.Size(74, 23)
        Me.btCalculateValue.TabIndex = 56
        Me.btCalculateValue.Text = "Рассчитать"
        Me.btCalculateValue.UseVisualStyleBackColor = True
        '
        'tpBuying_Calculate
        '
        Me.tpBuying_Calculate.Controls.Add(Me.Button1)
        Me.tpBuying_Calculate.Controls.Add(Me.Button2)
        Me.tpBuying_Calculate.Location = New System.Drawing.Point(4, 22)
        Me.tpBuying_Calculate.Name = "tpBuying_Calculate"
        Me.tpBuying_Calculate.Padding = New System.Windows.Forms.Padding(3)
        Me.tpBuying_Calculate.Size = New System.Drawing.Size(363, 217)
        Me.tpBuying_Calculate.TabIndex = 1
        Me.tpBuying_Calculate.Text = "Расчет розницы"
        Me.tpBuying_Calculate.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(19, 50)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(101, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Выставка ЕС"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(19, 11)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 0
        Me.Button2.Text = "eBay"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'UC_preparator_calc1
        '
        Me.UC_preparator_calc1.Location = New System.Drawing.Point(3, 3)
        Me.UC_preparator_calc1.Name = "UC_preparator_calc1"
        Me.UC_preparator_calc1.Size = New System.Drawing.Size(335, 243)
        Me.UC_preparator_calc1.TabIndex = 0
        '
        'uc_createSample
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.tbctlMain)
        Me.Controls.Add(Me.OldGoodMap_ResultBindingNavigator)
        Me.Name = "uc_createSample"
        Me.Size = New System.Drawing.Size(755, 369)
        CType(Me.OldGoodMap_ResultBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.OldGoodMap_ResultBindingNavigator.ResumeLayout(False)
        Me.OldGoodMap_ResultBindingNavigator.PerformLayout()
        CType(Me.OldGoodMap_ResultBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbctlMain.ResumeLayout(False)
        Me.tpОприходование.ResumeLayout(False)
        Me.gbExpedition.ResumeLayout(False)
        Me.gbExpedition.PerformLayout()
        Me.gbNumbers.ResumeLayout(False)
        Me.gbNumbers.PerformLayout()
        Me.gbPreparator.ResumeLayout(False)
        Me.tbctlPreparator.ResumeLayout(False)
        Me.tpPreparator_DB.ResumeLayout(False)
        Me.tpPreparator_DB.PerformLayout()
        Me.tpPreparator_Calculate.ResumeLayout(False)
        Me.tpPrices.ResumeLayout(False)
        Me.gbPricesEC.ResumeLayout(False)
        Me.gbPricesEC.PerformLayout()
        Me.gbPricesRUS.ResumeLayout(False)
        Me.gbPricesRUS.PerformLayout()
        Me.gbBuying.ResumeLayout(False)
        Me.tbctlBuying.ResumeLayout(False)
        Me.tpBuying_DB.ResumeLayout(False)
        Me.tpBuying_DB.PerformLayout()
        Me.tpBuying_Calculate.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents OldGoodMap_ResultBindingSource As Windows.Forms.BindingSource
    Friend WithEvents OldGoodMap_ResultBindingNavigator As Windows.Forms.BindingNavigator
    Friend WithEvents BindingNavigatorAddNewItem As Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorCountItem As Windows.Forms.ToolStripLabel
    Friend WithEvents BindingNavigatorDeleteItem As Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveFirstItem As Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As Windows.Forms.ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As Windows.Forms.ToolStripSeparator
    Friend WithEvents OldGoodMap_ResultBindingNavigatorSaveItem As Windows.Forms.ToolStripButton
    Friend WithEvents АртикулTextBox As Windows.Forms.TextBox
    Friend WithEvents Буржуи_на_выставкеTextBox As Windows.Forms.TextBox
    Friend WithEvents Валюта__Буржуи_на_выставке_ComboBox As Windows.Forms.ComboBox
    Friend WithEvents Валюта__Закупочная_цена_ComboBox As Windows.Forms.ComboBox
    Friend WithEvents Валюта__Инвойс_ComboBox As Windows.Forms.ComboBox
    Friend WithEvents Валюта__Розничная_в_офисе_ComboBox As Windows.Forms.ComboBox
    Friend WithEvents Валюта__Розничная_цена_в_магазине_ComboBox As Windows.Forms.ComboBox
    Friend WithEvents Время_препарации_в_часах__общее_TextBox As Windows.Forms.TextBox
    Friend WithEvents Единица_измеренияTextBox As Windows.Forms.TextBox
    Friend WithEvents Закупочная_ценаTextBox As Windows.Forms.TextBox
    Friend WithEvents ИнвойсTextBox As Windows.Forms.TextBox
    Friend WithEvents КодTextBox As Windows.Forms.TextBox
    Friend WithEvents НаименованиеTextBox As Windows.Forms.TextBox
    Friend WithEvents Ответственный_ПрепараторTextBox As Windows.Forms.TextBox
    Friend WithEvents Полная_стоимость_закупки_в_рубляхTextBox As Windows.Forms.TextBox
    Friend WithEvents Полная_стоимость_препарации_в_рубляхTextBox As Windows.Forms.TextBox
    Friend WithEvents Препараторы_и_времяTextBox As Windows.Forms.TextBox
    Friend WithEvents Производственный_номер_или_EAN13TextBox As Windows.Forms.TextBox
    Friend WithEvents Розничная_в_офисеTextBox As Windows.Forms.TextBox
    Friend WithEvents Розничная_цена_в_магазинеTextBox As Windows.Forms.TextBox
    Friend WithEvents Экспедиционное_закупочное_примечаниеTextBox As Windows.Forms.TextBox
    Friend WithEvents Экспедиционный_закупочный_номерTextBox As Windows.Forms.TextBox
    Friend WithEvents Экспедиция__код_TextBox As Windows.Forms.TextBox
    Friend WithEvents btGetNewCode As Windows.Forms.Button
    Friend WithEvents cbUomUser As Windows.Forms.ComboBox
    Friend WithEvents cbGroups As Windows.Forms.ComboBox
    Friend WithEvents btGetNameFromDB As Windows.Forms.Button
    Friend WithEvents tbctlMain As Windows.Forms.TabControl
    Friend WithEvents tpОприходование As Windows.Forms.TabPage
    Friend WithEvents tpPrices As Windows.Forms.TabPage
    Friend WithEvents btCalculateSalary As Windows.Forms.Button
    Friend WithEvents gbPreparator As Windows.Forms.GroupBox
    Friend WithEvents tbctlPreparator As Windows.Forms.TabControl
    Friend WithEvents tpPreparator_DB As Windows.Forms.TabPage
    Friend WithEvents tpPreparator_Calculate As Windows.Forms.TabPage
    Friend WithEvents gbExpedition As Windows.Forms.GroupBox
    Friend WithEvents gbNumbers As Windows.Forms.GroupBox
    Friend WithEvents UC_preparator_calc1 As UC_preparator_calc
    Friend WithEvents gbStorage As Windows.Forms.GroupBox
    Friend WithEvents gbPricesEC As Windows.Forms.GroupBox
    Friend WithEvents gbPricesRUS As Windows.Forms.GroupBox
    Friend WithEvents gbBuying As Windows.Forms.GroupBox
    Friend WithEvents tbctlBuying As Windows.Forms.TabControl
    Friend WithEvents tpBuying_DB As Windows.Forms.TabPage
    Friend WithEvents tpBuying_Calculate As Windows.Forms.TabPage
    Friend WithEvents btCalculateValue As Windows.Forms.Button
    Friend WithEvents btQuery As Windows.Forms.Button
    Friend WithEvents btMoveToCode As Windows.Forms.Button
    Friend WithEvents btMoveToArticul As Windows.Forms.Button
    Friend WithEvents ToolStripSeparator1 As Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel1 As Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripButton1 As Windows.Forms.ToolStripButton
    Friend WithEvents btClearAll As Windows.Forms.Button
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents Закупочная_цена_Button As Windows.Forms.Button
    Friend WithEvents ВесTextBox As Windows.Forms.TextBox
    Friend WithEvents cbWeightUser As Windows.Forms.ComboBox
    Friend WithEvents ВесLabel As Windows.Forms.Label
    Friend WithEvents Перевозка_рассчетButton As Windows.Forms.Button
    Friend WithEvents НакладныеTextBox As Windows.Forms.TextBox
    Friend WithEvents ПеревозкаВалютаComboBox As Windows.Forms.ComboBox
    Friend WithEvents ПеревозкаTextBox As Windows.Forms.TextBox
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents Валюта__EBAY_ComboBox As Windows.Forms.ComboBox
    Friend WithEvents EBAYTextBox As Windows.Forms.TextBox
    Friend WithEvents ComboBox1 As Windows.Forms.ComboBox
    Friend WithEvents ПеревозкаЗаКГTextBox As Windows.Forms.TextBox
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents Расчет_розницыButton As Windows.Forms.Button
    Friend WithEvents Button2 As Windows.Forms.Button
    Friend WithEvents Button1 As Windows.Forms.Button
    Friend WithEvents СбросПеревозкиButton As Windows.Forms.Button
    Friend WithEvents СбросНакладныхButton As Windows.Forms.Button
    Friend WithEvents СтандартныеНакладныеButton As Windows.Forms.Button
    Friend WithEvents Расчитать_всеButton As Windows.Forms.Button
    Friend WithEvents ToolStripButton2 As Windows.Forms.ToolStripButton
End Class
