<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fmSampleList
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
        Me.components = New System.ComponentModel.Container()
        Me.btCreateList = New System.Windows.Forms.Button()
        Me.tbSampleNumber = New System.Windows.Forms.TextBox()
        Me.SampleInListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btAddSample = New System.Windows.Forms.Button()
        Me.btRemoveSample = New System.Windows.Forms.Button()
        Me.btCreateSubList = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tbNameList = New System.Windows.Forms.TextBox()
        Me.SampleListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtpOpenList = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cbxIsActive = New System.Windows.Forms.CheckBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbxLockSample = New System.Windows.Forms.CheckBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.gbSample = New System.Windows.Forms.GroupBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lbSampleList = New System.Windows.Forms.ListBox()
        Me.gbFromDB = New System.Windows.Forms.GroupBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.dgvSampleParameters = New System.Windows.Forms.DataGridView()
        Me.IDSParameter = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ParameterName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ParameterValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ParameterType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ParameterNETtype = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IDSParameterDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ParameterNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ParameterValueDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ParameterTypeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ParameterNETtypeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IDSampleDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SampleInListDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SampleParameterBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.lbSelectedCount = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lbListCount = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cbListLine = New System.Windows.Forms.ComboBox()
        Me.cbListType = New System.Windows.Forms.ComboBox()
        Me.lbLists = New System.Windows.Forms.ListBox()
        Me.Списки = New System.Windows.Forms.GroupBox()
        Me.cbxOnlyActiveLists = New System.Windows.Forms.CheckBox()
        Me.lbShowLists = New System.Windows.Forms.Label()
        Me.btSaveDb = New System.Windows.Forms.Button()
        Me.SampleListParameterBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DgvSampleListParameter = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gbSelectedList = New System.Windows.Forms.GroupBox()
        Me.CloseDateTextBox = New System.Windows.Forms.TextBox()
        Me.cbCurrentListType = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cbCurrentListLine = New System.Windows.Forms.ComboBox()
        CType(Me.SampleInListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SampleListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbSample.SuspendLayout()
        Me.gbFromDB.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvSampleParameters, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SampleParameterBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Списки.SuspendLayout()
        CType(Me.SampleListParameterBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DgvSampleListParameter, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbSelectedList.SuspendLayout()
        Me.SuspendLayout()
        '
        'btCreateList
        '
        Me.btCreateList.Location = New System.Drawing.Point(101, 195)
        Me.btCreateList.Name = "btCreateList"
        Me.btCreateList.Size = New System.Drawing.Size(117, 23)
        Me.btCreateList.TabIndex = 0
        Me.btCreateList.Text = "Новый список"
        Me.btCreateList.UseVisualStyleBackColor = True
        '
        'tbSampleNumber
        '
        Me.tbSampleNumber.Location = New System.Drawing.Point(200, 330)
        Me.tbSampleNumber.Name = "tbSampleNumber"
        Me.tbSampleNumber.Size = New System.Drawing.Size(156, 20)
        Me.tbSampleNumber.TabIndex = 4
        '
        'SampleInListBindingSource
        '
        Me.SampleInListBindingSource.DataSource = GetType(trilbone.SampleInList)
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(200, 311)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "образец номер"
        '
        'btAddSample
        '
        Me.btAddSample.Location = New System.Drawing.Point(200, 356)
        Me.btAddSample.Name = "btAddSample"
        Me.btAddSample.Size = New System.Drawing.Size(75, 23)
        Me.btAddSample.TabIndex = 6
        Me.btAddSample.Text = "Добавить"
        Me.btAddSample.UseVisualStyleBackColor = True
        '
        'btRemoveSample
        '
        Me.btRemoveSample.Location = New System.Drawing.Point(281, 356)
        Me.btRemoveSample.Name = "btRemoveSample"
        Me.btRemoveSample.Size = New System.Drawing.Size(75, 23)
        Me.btRemoveSample.TabIndex = 7
        Me.btRemoveSample.Text = "Удалить"
        Me.btRemoveSample.UseVisualStyleBackColor = True
        '
        'btCreateSubList
        '
        Me.btCreateSubList.Location = New System.Drawing.Point(19, 358)
        Me.btCreateSubList.Name = "btCreateSubList"
        Me.btCreateSubList.Size = New System.Drawing.Size(150, 23)
        Me.btCreateSubList.TabIndex = 8
        Me.btCreateSubList.Text = "Создать подсписок"
        Me.btCreateSubList.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Имя списка"
        '
        'tbNameList
        '
        Me.tbNameList.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.SampleListBindingSource, "ListName", True))
        Me.tbNameList.Location = New System.Drawing.Point(92, 17)
        Me.tbNameList.Name = "tbNameList"
        Me.tbNameList.Size = New System.Drawing.Size(613, 20)
        Me.tbNameList.TabIndex = 10
        '
        'SampleListBindingSource
        '
        Me.SampleListBindingSource.DataSource = GetType(trilbone.SampleList)
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 73)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(84, 13)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Дата открытия"
        '
        'dtpOpenList
        '
        Me.dtpOpenList.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.SampleListBindingSource, "OpenDate", True))
        Me.dtpOpenList.Location = New System.Drawing.Point(111, 66)
        Me.dtpOpenList.Name = "dtpOpenList"
        Me.dtpOpenList.Size = New System.Drawing.Size(129, 20)
        Me.dtpOpenList.TabIndex = 12
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 99)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(85, 13)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Дата закрытия"
        '
        'cbxIsActive
        '
        Me.cbxIsActive.AutoSize = True
        Me.cbxIsActive.Checked = True
        Me.cbxIsActive.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbxIsActive.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Me.SampleListBindingSource, "IsActiveFlag", True))
        Me.cbxIsActive.Location = New System.Drawing.Point(16, 46)
        Me.cbxIsActive.Name = "cbxIsActive"
        Me.cbxIsActive.Size = New System.Drawing.Size(74, 17)
        Me.cbxIsActive.TabIndex = 16
        Me.cbxIsActive.Text = "Активен?"
        Me.cbxIsActive.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(10, 26)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(78, 13)
        Me.Label6.TabIndex = 17
        Me.Label6.Text = "Линия списка"
        '
        'cbxLockSample
        '
        Me.cbxLockSample.AutoSize = True
        Me.cbxLockSample.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Me.SampleInListBindingSource, "IsLockedFlag", True))
        Me.cbxLockSample.Location = New System.Drawing.Point(212, 101)
        Me.cbxLockSample.Name = "cbxLockSample"
        Me.cbxLockSample.Size = New System.Drawing.Size(164, 17)
        Me.cbxLockSample.TabIndex = 19
        Me.cbxLockSample.Text = "Блокировать для запросов"
        Me.cbxLockSample.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(8, 51)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(65, 13)
        Me.Label7.TabIndex = 20
        Me.Label7.Text = "Тип списка"
        '
        'gbSample
        '
        Me.gbSample.Controls.Add(Me.Label13)
        Me.gbSample.Controls.Add(Me.Label1)
        Me.gbSample.Controls.Add(Me.lbSampleList)
        Me.gbSample.Controls.Add(Me.gbFromDB)
        Me.gbSample.Controls.Add(Me.Label12)
        Me.gbSample.Controls.Add(Me.dgvSampleParameters)
        Me.gbSample.Controls.Add(Me.lbSelectedCount)
        Me.gbSample.Controls.Add(Me.Label9)
        Me.gbSample.Controls.Add(Me.lbListCount)
        Me.gbSample.Controls.Add(Me.btRemoveSample)
        Me.gbSample.Controls.Add(Me.tbSampleNumber)
        Me.gbSample.Controls.Add(Me.btCreateSubList)
        Me.gbSample.Controls.Add(Me.Label2)
        Me.gbSample.Controls.Add(Me.cbxLockSample)
        Me.gbSample.Controls.Add(Me.btAddSample)
        Me.gbSample.Location = New System.Drawing.Point(5, 255)
        Me.gbSample.Name = "gbSample"
        Me.gbSample.Size = New System.Drawing.Size(1133, 388)
        Me.gbSample.TabIndex = 22
        Me.gbSample.TabStop = False
        Me.gbSample.Text = "Образцы в списке"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(212, 19)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(46, 13)
        Me.Label13.TabIndex = 31
        Me.Label13.Text = "Выбран"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.SampleInListBindingSource, "SampleNumber", True))
        Me.Label1.Location = New System.Drawing.Point(209, 74)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 13)
        Me.Label1.TabIndex = 30
        Me.Label1.Text = "Номер образца"
        '
        'lbSampleList
        '
        Me.lbSampleList.FormattingEnabled = True
        Me.lbSampleList.Location = New System.Drawing.Point(7, 19)
        Me.lbSampleList.Name = "lbSampleList"
        Me.lbSampleList.Size = New System.Drawing.Size(173, 277)
        Me.lbSampleList.Sorted = True
        Me.lbSampleList.TabIndex = 29
        '
        'gbFromDB
        '
        Me.gbFromDB.Controls.Add(Me.Button4)
        Me.gbFromDB.Controls.Add(Me.Button3)
        Me.gbFromDB.Controls.Add(Me.Button2)
        Me.gbFromDB.Controls.Add(Me.Button1)
        Me.gbFromDB.Controls.Add(Me.PictureBox1)
        Me.gbFromDB.Controls.Add(Me.RichTextBox1)
        Me.gbFromDB.Location = New System.Drawing.Point(379, 228)
        Me.gbFromDB.Name = "gbFromDB"
        Me.gbFromDB.Size = New System.Drawing.Size(745, 153)
        Me.gbFromDB.TabIndex = 28
        Me.gbFromDB.TabStop = False
        Me.gbFromDB.Text = "Из основной базы"
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(114, 115)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(75, 23)
        Me.Button4.TabIndex = 5
        Me.Button4.Text = "данные"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(207, 115)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 4
        Me.Button3.Text = "на продажу"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(616, 124)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(117, 23)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "Фото менеджер"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(15, 115)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Оформить"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(616, 15)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(117, 101)
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Location = New System.Drawing.Point(15, 19)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(553, 90)
        Me.RichTextBox1.TabIndex = 0
        Me.RichTextBox1.Text = ""
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.SampleInListBindingSource, "IDSample", True))
        Me.Label12.Location = New System.Drawing.Point(209, 52)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(56, 13)
        Me.Label12.TabIndex = 27
        Me.Label12.Text = "Sample ID"
        '
        'dgvSampleParameters
        '
        Me.dgvSampleParameters.AutoGenerateColumns = False
        Me.dgvSampleParameters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSampleParameters.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IDSParameter, Me.ParameterName, Me.ParameterValue, Me.ParameterType, Me.ParameterNETtype, Me.IDSParameterDataGridViewTextBoxColumn, Me.ParameterNameDataGridViewTextBoxColumn, Me.ParameterValueDataGridViewTextBoxColumn, Me.ParameterTypeDataGridViewTextBoxColumn, Me.ParameterNETtypeDataGridViewTextBoxColumn, Me.IDSampleDataGridViewTextBoxColumn, Me.SampleInListDataGridViewTextBoxColumn})
        Me.dgvSampleParameters.DataSource = Me.SampleParameterBindingSource
        Me.dgvSampleParameters.Location = New System.Drawing.Point(407, 52)
        Me.dgvSampleParameters.Name = "dgvSampleParameters"
        Me.dgvSampleParameters.Size = New System.Drawing.Size(549, 160)
        Me.dgvSampleParameters.TabIndex = 26
        '
        'IDSParameter
        '
        Me.IDSParameter.DataPropertyName = "IDSParameter"
        Me.IDSParameter.HeaderText = "IDSParameter"
        Me.IDSParameter.Name = "IDSParameter"
        '
        'ParameterName
        '
        Me.ParameterName.DataPropertyName = "ParameterName"
        Me.ParameterName.HeaderText = "ParameterName"
        Me.ParameterName.Name = "ParameterName"
        '
        'ParameterValue
        '
        Me.ParameterValue.DataPropertyName = "ParameterValue"
        Me.ParameterValue.HeaderText = "ParameterValue"
        Me.ParameterValue.Name = "ParameterValue"
        '
        'ParameterType
        '
        Me.ParameterType.DataPropertyName = "ParameterType"
        Me.ParameterType.HeaderText = "ParameterType"
        Me.ParameterType.Name = "ParameterType"
        '
        'ParameterNETtype
        '
        Me.ParameterNETtype.DataPropertyName = "ParameterNETtype"
        Me.ParameterNETtype.HeaderText = "ParameterNETtype"
        Me.ParameterNETtype.Name = "ParameterNETtype"
        '
        'IDSParameterDataGridViewTextBoxColumn
        '
        Me.IDSParameterDataGridViewTextBoxColumn.DataPropertyName = "IDSParameter"
        Me.IDSParameterDataGridViewTextBoxColumn.HeaderText = "IDSParameter"
        Me.IDSParameterDataGridViewTextBoxColumn.Name = "IDSParameterDataGridViewTextBoxColumn"
        '
        'ParameterNameDataGridViewTextBoxColumn
        '
        Me.ParameterNameDataGridViewTextBoxColumn.DataPropertyName = "ParameterName"
        Me.ParameterNameDataGridViewTextBoxColumn.HeaderText = "ParameterName"
        Me.ParameterNameDataGridViewTextBoxColumn.Name = "ParameterNameDataGridViewTextBoxColumn"
        '
        'ParameterValueDataGridViewTextBoxColumn
        '
        Me.ParameterValueDataGridViewTextBoxColumn.DataPropertyName = "ParameterValue"
        Me.ParameterValueDataGridViewTextBoxColumn.HeaderText = "ParameterValue"
        Me.ParameterValueDataGridViewTextBoxColumn.Name = "ParameterValueDataGridViewTextBoxColumn"
        '
        'ParameterTypeDataGridViewTextBoxColumn
        '
        Me.ParameterTypeDataGridViewTextBoxColumn.DataPropertyName = "ParameterType"
        Me.ParameterTypeDataGridViewTextBoxColumn.HeaderText = "ParameterType"
        Me.ParameterTypeDataGridViewTextBoxColumn.Name = "ParameterTypeDataGridViewTextBoxColumn"
        '
        'ParameterNETtypeDataGridViewTextBoxColumn
        '
        Me.ParameterNETtypeDataGridViewTextBoxColumn.DataPropertyName = "ParameterNETtype"
        Me.ParameterNETtypeDataGridViewTextBoxColumn.HeaderText = "ParameterNETtype"
        Me.ParameterNETtypeDataGridViewTextBoxColumn.Name = "ParameterNETtypeDataGridViewTextBoxColumn"
        '
        'IDSampleDataGridViewTextBoxColumn
        '
        Me.IDSampleDataGridViewTextBoxColumn.DataPropertyName = "IDSample"
        Me.IDSampleDataGridViewTextBoxColumn.HeaderText = "IDSample"
        Me.IDSampleDataGridViewTextBoxColumn.Name = "IDSampleDataGridViewTextBoxColumn"
        '
        'SampleInListDataGridViewTextBoxColumn
        '
        Me.SampleInListDataGridViewTextBoxColumn.DataPropertyName = "SampleInList"
        Me.SampleInListDataGridViewTextBoxColumn.HeaderText = "SampleInList"
        Me.SampleInListDataGridViewTextBoxColumn.Name = "SampleInListDataGridViewTextBoxColumn"
        '
        'SampleParameterBindingSource
        '
        Me.SampleParameterBindingSource.DataMember = "SampleParameter"
        Me.SampleParameterBindingSource.DataSource = Me.SampleInListBindingSource
        '
        'lbSelectedCount
        '
        Me.lbSelectedCount.AutoSize = True
        Me.lbSelectedCount.Location = New System.Drawing.Point(19, 330)
        Me.lbSelectedCount.Name = "lbSelectedCount"
        Me.lbSelectedCount.Size = New System.Drawing.Size(109, 13)
        Me.lbSelectedCount.TabIndex = 26
        Me.lbSelectedCount.Text = "выбрано элементов"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(404, 26)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(159, 13)
        Me.Label9.TabIndex = 25
        Me.Label9.Text = "Таблица параметров образца"
        '
        'lbListCount
        '
        Me.lbListCount.AutoSize = True
        Me.lbListCount.Location = New System.Drawing.Point(19, 307)
        Me.lbListCount.Name = "lbListCount"
        Me.lbListCount.Size = New System.Drawing.Size(84, 13)
        Me.lbListCount.TabIndex = 25
        Me.lbListCount.Text = "всего в списке"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(552, 46)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(153, 13)
        Me.Label8.TabIndex = 23
        Me.Label8.Text = "Таблица параметров списка"
        '
        'cbListLine
        '
        Me.cbListLine.DisplayMember = "IDListLine"
        Me.cbListLine.FormattingEnabled = True
        Me.cbListLine.Location = New System.Drawing.Point(102, 23)
        Me.cbListLine.Name = "cbListLine"
        Me.cbListLine.Size = New System.Drawing.Size(121, 21)
        Me.cbListLine.TabIndex = 27
        Me.cbListLine.ValueMember = "IDListLine"
        '
        'cbListType
        '
        Me.cbListType.FormattingEnabled = True
        Me.cbListType.Location = New System.Drawing.Point(101, 50)
        Me.cbListType.Name = "cbListType"
        Me.cbListType.Size = New System.Drawing.Size(121, 21)
        Me.cbListType.TabIndex = 28
        '
        'lbLists
        '
        Me.lbLists.FormattingEnabled = True
        Me.lbLists.Location = New System.Drawing.Point(237, 19)
        Me.lbLists.Name = "lbLists"
        Me.lbLists.Size = New System.Drawing.Size(168, 199)
        Me.lbLists.TabIndex = 30
        '
        'Списки
        '
        Me.Списки.Controls.Add(Me.cbxOnlyActiveLists)
        Me.Списки.Controls.Add(Me.lbShowLists)
        Me.Списки.Controls.Add(Me.cbListType)
        Me.Списки.Controls.Add(Me.lbLists)
        Me.Списки.Controls.Add(Me.Label6)
        Me.Списки.Controls.Add(Me.Label7)
        Me.Списки.Controls.Add(Me.cbListLine)
        Me.Списки.Controls.Add(Me.btCreateList)
        Me.Списки.Location = New System.Drawing.Point(5, 5)
        Me.Списки.Name = "Списки"
        Me.Списки.Size = New System.Drawing.Size(411, 230)
        Me.Списки.TabIndex = 31
        Me.Списки.TabStop = False
        Me.Списки.Text = "Фильтр Списков"
        '
        'cbxOnlyActiveLists
        '
        Me.cbxOnlyActiveLists.AutoSize = True
        Me.cbxOnlyActiveLists.Location = New System.Drawing.Point(57, 84)
        Me.cbxOnlyActiveLists.Name = "cbxOnlyActiveLists"
        Me.cbxOnlyActiveLists.Size = New System.Drawing.Size(165, 17)
        Me.cbxOnlyActiveLists.TabIndex = 32
        Me.cbxOnlyActiveLists.Text = "Показать только активные"
        Me.cbxOnlyActiveLists.UseVisualStyleBackColor = True
        '
        'lbShowLists
        '
        Me.lbShowLists.Location = New System.Drawing.Point(6, 109)
        Me.lbShowLists.Name = "lbShowLists"
        Me.lbShowLists.Size = New System.Drawing.Size(213, 44)
        Me.lbShowLists.TabIndex = 31
        Me.lbShowLists.Text = "фильтры"
        '
        'btSaveDb
        '
        Me.btSaveDb.Location = New System.Drawing.Point(970, 658)
        Me.btSaveDb.Name = "btSaveDb"
        Me.btSaveDb.Size = New System.Drawing.Size(168, 23)
        Me.btSaveDb.TabIndex = 32
        Me.btSaveDb.Text = "Сохранить изменения в БД"
        Me.btSaveDb.UseVisualStyleBackColor = True
        '
        'SampleListParameterBindingSource
        '
        Me.SampleListParameterBindingSource.DataMember = "SampleListParameter"
        Me.SampleListParameterBindingSource.DataSource = Me.SampleListBindingSource
        '
        'DgvSampleListParameter
        '
        Me.DgvSampleListParameter.AutoGenerateColumns = False
        Me.DgvSampleListParameter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvSampleListParameter.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn8})
        Me.DgvSampleListParameter.DataSource = Me.SampleListParameterBindingSource
        Me.DgvSampleListParameter.Location = New System.Drawing.Point(262, 66)
        Me.DgvSampleListParameter.Name = "DgvSampleListParameter"
        Me.DgvSampleListParameter.Size = New System.Drawing.Size(446, 157)
        Me.DgvSampleListParameter.TabIndex = 32
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "ParameterName"
        Me.DataGridViewTextBoxColumn5.HeaderText = "Name"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "ParameterValue"
        Me.DataGridViewTextBoxColumn6.HeaderText = "Value"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "ParameterType"
        Me.DataGridViewTextBoxColumn7.HeaderText = "Type"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "ParameterNETtype"
        Me.DataGridViewTextBoxColumn8.HeaderText = "NETtype"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        '
        'gbSelectedList
        '
        Me.gbSelectedList.Controls.Add(Me.CloseDateTextBox)
        Me.gbSelectedList.Controls.Add(Me.cbCurrentListType)
        Me.gbSelectedList.Controls.Add(Me.Label10)
        Me.gbSelectedList.Controls.Add(Me.Label11)
        Me.gbSelectedList.Controls.Add(Me.cbCurrentListLine)
        Me.gbSelectedList.Controls.Add(Me.cbxIsActive)
        Me.gbSelectedList.Controls.Add(Me.DgvSampleListParameter)
        Me.gbSelectedList.Controls.Add(Me.Label3)
        Me.gbSelectedList.Controls.Add(Me.tbNameList)
        Me.gbSelectedList.Controls.Add(Me.Label8)
        Me.gbSelectedList.Controls.Add(Me.dtpOpenList)
        Me.gbSelectedList.Controls.Add(Me.Label4)
        Me.gbSelectedList.Controls.Add(Me.Label5)
        Me.gbSelectedList.Location = New System.Drawing.Point(424, 6)
        Me.gbSelectedList.Name = "gbSelectedList"
        Me.gbSelectedList.Size = New System.Drawing.Size(728, 243)
        Me.gbSelectedList.TabIndex = 33
        Me.gbSelectedList.TabStop = False
        Me.gbSelectedList.Text = "Выбранный список"
        '
        'CloseDateTextBox
        '
        Me.CloseDateTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.SampleListBindingSource, "CloseDate", True))
        Me.CloseDateTextBox.Location = New System.Drawing.Point(111, 94)
        Me.CloseDateTextBox.Name = "CloseDateTextBox"
        Me.CloseDateTextBox.Size = New System.Drawing.Size(129, 20)
        Me.CloseDateTextBox.TabIndex = 38
        '
        'cbCurrentListType
        '
        Me.cbCurrentListType.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.SampleListBindingSource, "IDListType", True))
        Me.cbCurrentListType.DataSource = Me.SampleListBindingSource
        Me.cbCurrentListType.DisplayMember = "ListType.ListTypeName"
        Me.cbCurrentListType.FormattingEnabled = True
        Me.cbCurrentListType.Location = New System.Drawing.Point(119, 147)
        Me.cbCurrentListType.Name = "cbCurrentListType"
        Me.cbCurrentListType.Size = New System.Drawing.Size(121, 21)
        Me.cbCurrentListType.TabIndex = 36
        Me.cbCurrentListType.ValueMember = "ListType.IDListType"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(28, 123)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(78, 13)
        Me.Label10.TabIndex = 33
        Me.Label10.Text = "Линия списка"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(32, 148)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(65, 13)
        Me.Label11.TabIndex = 34
        Me.Label11.Text = "Тип списка"
        '
        'cbCurrentListLine
        '
        Me.cbCurrentListLine.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.SampleListBindingSource, "IDListLine", True))
        Me.cbCurrentListLine.DataSource = Me.SampleListBindingSource
        Me.cbCurrentListLine.DisplayMember = "ListLine.ListLineName"
        Me.cbCurrentListLine.FormattingEnabled = True
        Me.cbCurrentListLine.Location = New System.Drawing.Point(120, 120)
        Me.cbCurrentListLine.Name = "cbCurrentListLine"
        Me.cbCurrentListLine.Size = New System.Drawing.Size(121, 21)
        Me.cbCurrentListLine.TabIndex = 35
        Me.cbCurrentListLine.ValueMember = "ListLine.IDListLine"
        '
        'fmSampleList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1172, 717)
        Me.Controls.Add(Me.gbSelectedList)
        Me.Controls.Add(Me.btSaveDb)
        Me.Controls.Add(Me.Списки)
        Me.Controls.Add(Me.gbSample)
        Me.Name = "fmSampleList"
        Me.Text = "Списки 1.0"
        CType(Me.SampleInListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SampleListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbSample.ResumeLayout(False)
        Me.gbSample.PerformLayout()
        Me.gbFromDB.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvSampleParameters, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SampleParameterBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Списки.ResumeLayout(False)
        Me.Списки.PerformLayout()
        CType(Me.SampleListParameterBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DgvSampleListParameter, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbSelectedList.ResumeLayout(False)
        Me.gbSelectedList.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btCreateList As System.Windows.Forms.Button
    Friend WithEvents tbSampleNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btAddSample As System.Windows.Forms.Button
    Friend WithEvents btRemoveSample As System.Windows.Forms.Button
    Friend WithEvents btCreateSubList As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tbNameList As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtpOpenList As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cbxIsActive As System.Windows.Forms.CheckBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cbxLockSample As System.Windows.Forms.CheckBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents gbSample As System.Windows.Forms.GroupBox
    Friend WithEvents dgvSampleParameters As System.Windows.Forms.DataGridView
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lbListCount As System.Windows.Forms.Label
    Friend WithEvents lbSelectedCount As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cbListLine As System.Windows.Forms.ComboBox
    Friend WithEvents cbListType As System.Windows.Forms.ComboBox
    Friend WithEvents gbFromDB As System.Windows.Forms.GroupBox
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
    Friend WithEvents lbLists As System.Windows.Forms.ListBox
    Friend WithEvents Списки As System.Windows.Forms.GroupBox
    Friend WithEvents btSaveDb As System.Windows.Forms.Button
    Friend WithEvents lbShowLists As System.Windows.Forms.Label
    Friend WithEvents SampleListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SampleListParameterBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DgvSampleListParameter As System.Windows.Forms.DataGridView
    Friend WithEvents cbxOnlyActiveLists As System.Windows.Forms.CheckBox
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gbSelectedList As System.Windows.Forms.GroupBox
    Friend WithEvents cbCurrentListType As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cbCurrentListLine As System.Windows.Forms.ComboBox
    Friend WithEvents CloseDateTextBox As System.Windows.Forms.TextBox
    Friend WithEvents lbSampleList As System.Windows.Forms.ListBox
    Friend WithEvents SampleInListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SampleParameterBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents IDSParameter As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ParameterName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ParameterValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ParameterType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ParameterNETtype As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IDSParameterDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ParameterNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ParameterValueDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ParameterTypeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ParameterNETtypeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IDSampleDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SampleInListDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class
