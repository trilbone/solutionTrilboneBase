<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucClient
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
        Dim UserIDLabel As System.Windows.Forms.Label
        Dim EmailLabel As System.Windows.Forms.Label
        Dim Label1 As System.Windows.Forms.Label
        Dim PhoneLabel1 As System.Windows.Forms.Label
        Dim CountryLabel As System.Windows.Forms.Label
        Dim CityLabel As System.Windows.Forms.Label
        Dim NameLabel1 As System.Windows.Forms.Label
        Dim PostIndexLabel As System.Windows.Forms.Label
        Dim StreetLabel1 As System.Windows.Forms.Label
        Dim StateLabel As System.Windows.Forms.Label
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.btSelectClient = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btCreateAddress = New System.Windows.Forms.Button()
        Me.lbClientInterest = New System.Windows.Forms.ListBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.rtbClientComment = New System.Windows.Forms.RichTextBox()
        Me.rtbClientInterestDetails = New System.Windows.Forms.RichTextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btCreateClient = New System.Windows.Forms.Button()
        Me.lbClientTags = New System.Windows.Forms.ListBox()
        Me.lbUserSearchStatus = New System.Windows.Forms.Label()
        Me.lbCustomers = New System.Windows.Forms.ListBox()
        Me.btSearchClientByFullName = New System.Windows.Forms.Button()
        Me.tbFullName = New System.Windows.Forms.TextBox()
        Me.UserIDTextBox = New System.Windows.Forms.TextBox()
        Me.EmailTextBox = New System.Windows.Forms.TextBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.IMoySkladDataProvider_AddressBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.NameTextBox1 = New System.Windows.Forms.TextBox()
        Me.PhoneTextBox1 = New System.Windows.Forms.TextBox()
        Me.CountryTextBox = New System.Windows.Forms.TextBox()
        Me.CityTextBox = New System.Windows.Forms.TextBox()
        Me.StreetTextBox1 = New System.Windows.Forms.TextBox()
        Me.PostIndexTextBox = New System.Windows.Forms.TextBox()
        Me.StateTextBox = New System.Windows.Forms.TextBox()
        UserIDLabel = New System.Windows.Forms.Label()
        EmailLabel = New System.Windows.Forms.Label()
        Label1 = New System.Windows.Forms.Label()
        PhoneLabel1 = New System.Windows.Forms.Label()
        CountryLabel = New System.Windows.Forms.Label()
        CityLabel = New System.Windows.Forms.Label()
        NameLabel1 = New System.Windows.Forms.Label()
        PostIndexLabel = New System.Windows.Forms.Label()
        StreetLabel1 = New System.Windows.Forms.Label()
        StateLabel = New System.Windows.Forms.Label()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.IMoySkladDataProvider_AddressBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'UserIDLabel
        '
        UserIDLabel.AutoSize = True
        UserIDLabel.Location = New System.Drawing.Point(148, 38)
        UserIDLabel.Name = "UserIDLabel"
        UserIDLabel.Size = New System.Drawing.Size(46, 13)
        UserIDLabel.TabIndex = 21
        UserIDLabel.Text = "User ID:"
        '
        'EmailLabel
        '
        EmailLabel.AutoSize = True
        EmailLabel.Location = New System.Drawing.Point(11, 64)
        EmailLabel.Name = "EmailLabel"
        EmailLabel.Size = New System.Drawing.Size(35, 13)
        EmailLabel.TabIndex = 19
        EmailLabel.Text = "Email:"
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.Location = New System.Drawing.Point(11, 9)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(38, 13)
        Label1.TabIndex = 29
        Label1.Text = "Name:"
        '
        'PhoneLabel1
        '
        PhoneLabel1.AutoSize = True
        PhoneLabel1.Location = New System.Drawing.Point(11, 191)
        PhoneLabel1.Name = "PhoneLabel1"
        PhoneLabel1.Size = New System.Drawing.Size(41, 13)
        PhoneLabel1.TabIndex = 33
        PhoneLabel1.Text = "Phone:"
        '
        'CountryLabel
        '
        CountryLabel.AutoSize = True
        CountryLabel.Location = New System.Drawing.Point(6, 163)
        CountryLabel.Name = "CountryLabel"
        CountryLabel.Size = New System.Drawing.Size(46, 13)
        CountryLabel.TabIndex = 27
        CountryLabel.Text = "Страна:"
        '
        'CityLabel
        '
        CityLabel.AutoSize = True
        CityLabel.Location = New System.Drawing.Point(12, 107)
        CityLabel.Name = "CityLabel"
        CityLabel.Size = New System.Drawing.Size(40, 13)
        CityLabel.TabIndex = 25
        CityLabel.Text = "Город:"
        '
        'NameLabel1
        '
        NameLabel1.AutoSize = True
        NameLabel1.Location = New System.Drawing.Point(20, 23)
        NameLabel1.Name = "NameLabel1"
        NameLabel1.Size = New System.Drawing.Size(32, 13)
        NameLabel1.TabIndex = 31
        NameLabel1.Text = "Имя:"
        '
        'PostIndexLabel
        '
        PostIndexLabel.AutoSize = True
        PostIndexLabel.Location = New System.Drawing.Point(4, 135)
        PostIndexLabel.Name = "PostIndexLabel"
        PostIndexLabel.Size = New System.Drawing.Size(48, 13)
        PostIndexLabel.TabIndex = 35
        PostIndexLabel.Text = "Индекс:"
        '
        'StreetLabel1
        '
        StreetLabel1.AutoSize = True
        StreetLabel1.Location = New System.Drawing.Point(10, 51)
        StreetLabel1.Name = "StreetLabel1"
        StreetLabel1.Size = New System.Drawing.Size(42, 13)
        StreetLabel1.TabIndex = 39
        StreetLabel1.Text = "Улица:"
        '
        'StateLabel
        '
        StateLabel.AutoSize = True
        StateLabel.Location = New System.Drawing.Point(7, 79)
        StateLabel.Name = "StateLabel"
        StateLabel.Size = New System.Drawing.Size(52, 13)
        StateLabel.TabIndex = 37
        StateLabel.Text = "Волость:"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(662, 400)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.btSelectClient)
        Me.TabPage1.Controls.Add(Me.GroupBox3)
        Me.TabPage1.Controls.Add(Me.lbUserSearchStatus)
        Me.TabPage1.Controls.Add(Me.lbCustomers)
        Me.TabPage1.Controls.Add(Me.btSearchClientByFullName)
        Me.TabPage1.Controls.Add(Label1)
        Me.TabPage1.Controls.Add(Me.tbFullName)
        Me.TabPage1.Controls.Add(UserIDLabel)
        Me.TabPage1.Controls.Add(Me.UserIDTextBox)
        Me.TabPage1.Controls.Add(EmailLabel)
        Me.TabPage1.Controls.Add(Me.EmailTextBox)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(654, 374)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "В МС"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'btSelectClient
        '
        Me.btSelectClient.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btSelectClient.Location = New System.Drawing.Point(350, 73)
        Me.btSelectClient.Name = "btSelectClient"
        Me.btSelectClient.Size = New System.Drawing.Size(111, 41)
        Me.btSelectClient.TabIndex = 34
        Me.btSelectClient.Text = "Выбрать"
        Me.btSelectClient.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.btCreateAddress)
        Me.GroupBox3.Controls.Add(Me.lbClientInterest)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.rtbClientComment)
        Me.GroupBox3.Controls.Add(Me.rtbClientInterestDetails)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.btCreateClient)
        Me.GroupBox3.Controls.Add(Me.lbClientTags)
        Me.GroupBox3.Location = New System.Drawing.Point(14, 120)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(627, 235)
        Me.GroupBox3.TabIndex = 33
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Новый клиент"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(433, 185)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 13)
        Me.Label2.TabIndex = 32
        Me.Label2.Text = "Проверь адрес"
        '
        'btCreateAddress
        '
        Me.btCreateAddress.Location = New System.Drawing.Point(436, 139)
        Me.btCreateAddress.Name = "btCreateAddress"
        Me.btCreateAddress.Size = New System.Drawing.Size(165, 43)
        Me.btCreateAddress.TabIndex = 31
        Me.btCreateAddress.Text = "Адрес клиента"
        Me.btCreateAddress.UseVisualStyleBackColor = True
        '
        'lbClientInterest
        '
        Me.lbClientInterest.FormattingEnabled = True
        Me.lbClientInterest.Location = New System.Drawing.Point(19, 41)
        Me.lbClientInterest.Name = "lbClientInterest"
        Me.lbClientInterest.Size = New System.Drawing.Size(160, 95)
        Me.lbClientInterest.TabIndex = 23
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(214, 139)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(77, 13)
        Me.Label7.TabIndex = 30
        Me.Label7.Text = "Комментарий"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(19, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(102, 13)
        Me.Label3.TabIndex = 24
        Me.Label3.Text = "Интересы клиента"
        '
        'rtbClientComment
        '
        Me.rtbClientComment.Location = New System.Drawing.Point(217, 155)
        Me.rtbClientComment.Name = "rtbClientComment"
        Me.rtbClientComment.Size = New System.Drawing.Size(162, 74)
        Me.rtbClientComment.TabIndex = 29
        Me.rtbClientComment.Text = ""
        '
        'rtbClientInterestDetails
        '
        Me.rtbClientInterestDetails.Location = New System.Drawing.Point(22, 155)
        Me.rtbClientInterestDetails.Name = "rtbClientInterestDetails"
        Me.rtbClientInterestDetails.Size = New System.Drawing.Size(158, 74)
        Me.rtbClientInterestDetails.TabIndex = 25
        Me.rtbClientInterestDetails.Text = ""
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(214, 22)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(88, 13)
        Me.Label6.TabIndex = 28
        Me.Label6.Text = "Группы клиента"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(19, 139)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(153, 13)
        Me.Label5.TabIndex = 26
        Me.Label5.Text = "Интересы клиента подробно"
        '
        'btCreateClient
        '
        Me.btCreateClient.Location = New System.Drawing.Point(436, 19)
        Me.btCreateClient.Name = "btCreateClient"
        Me.btCreateClient.Size = New System.Drawing.Size(165, 75)
        Me.btCreateClient.TabIndex = 13
        Me.btCreateClient.Text = "Создать клиента в МС.."
        Me.btCreateClient.UseVisualStyleBackColor = True
        '
        'lbClientTags
        '
        Me.lbClientTags.FormattingEnabled = True
        Me.lbClientTags.Location = New System.Drawing.Point(214, 41)
        Me.lbClientTags.Name = "lbClientTags"
        Me.lbClientTags.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lbClientTags.Size = New System.Drawing.Size(165, 95)
        Me.lbClientTags.TabIndex = 27
        '
        'lbUserSearchStatus
        '
        Me.lbUserSearchStatus.AutoSize = True
        Me.lbUserSearchStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lbUserSearchStatus.Location = New System.Drawing.Point(18, 91)
        Me.lbUserSearchStatus.Name = "lbUserSearchStatus"
        Me.lbUserSearchStatus.Size = New System.Drawing.Size(102, 16)
        Me.lbUserSearchStatus.TabIndex = 32
        Me.lbUserSearchStatus.Text = "Search status"
        '
        'lbCustomers
        '
        Me.lbCustomers.FormattingEnabled = True
        Me.lbCustomers.Location = New System.Drawing.Point(472, 6)
        Me.lbCustomers.Name = "lbCustomers"
        Me.lbCustomers.Size = New System.Drawing.Size(169, 108)
        Me.lbCustomers.TabIndex = 31
        '
        'btSearchClientByFullName
        '
        Me.btSearchClientByFullName.Location = New System.Drawing.Point(350, 11)
        Me.btSearchClientByFullName.Name = "btSearchClientByFullName"
        Me.btSearchClientByFullName.Size = New System.Drawing.Size(111, 44)
        Me.btSearchClientByFullName.TabIndex = 30
        Me.btSearchClientByFullName.Text = "Найти в клиента в Мой склад"
        Me.btSearchClientByFullName.UseVisualStyleBackColor = True
        '
        'tbFullName
        '
        Me.tbFullName.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.IMoySkladDataProvider_AddressBindingSource, "Name", True))
        Me.tbFullName.Location = New System.Drawing.Point(60, 6)
        Me.tbFullName.Name = "tbFullName"
        Me.tbFullName.Size = New System.Drawing.Size(276, 20)
        Me.tbFullName.TabIndex = 27
        '
        'UserIDTextBox
        '
        Me.UserIDTextBox.Location = New System.Drawing.Point(200, 35)
        Me.UserIDTextBox.Name = "UserIDTextBox"
        Me.UserIDTextBox.Size = New System.Drawing.Size(136, 20)
        Me.UserIDTextBox.TabIndex = 22
        '
        'EmailTextBox
        '
        Me.EmailTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.IMoySkladDataProvider_AddressBindingSource, "email", True))
        Me.EmailTextBox.Location = New System.Drawing.Point(52, 61)
        Me.EmailTextBox.Name = "EmailTextBox"
        Me.EmailTextBox.Size = New System.Drawing.Size(284, 20)
        Me.EmailTextBox.TabIndex = 20
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.RichTextBox1)
        Me.TabPage2.Controls.Add(Me.GroupBox2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(654, 374)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Адрес"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'RichTextBox1
        '
        Me.RichTextBox1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.IMoySkladDataProvider_AddressBindingSource, "FullAddress", True))
        Me.RichTextBox1.Location = New System.Drawing.Point(6, 231)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(466, 124)
        Me.RichTextBox1.TabIndex = 43
        Me.RichTextBox1.Text = ""
        '
        'IMoySkladDataProvider_AddressBindingSource
        '
        Me.IMoySkladDataProvider_AddressBindingSource.DataSource = GetType(Service.iMoySkladDataProvider.clsAddress)
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.NameTextBox1)
        Me.GroupBox2.Controls.Add(Me.PhoneTextBox1)
        Me.GroupBox2.Controls.Add(PhoneLabel1)
        Me.GroupBox2.Controls.Add(Me.CountryTextBox)
        Me.GroupBox2.Controls.Add(CountryLabel)
        Me.GroupBox2.Controls.Add(Me.CityTextBox)
        Me.GroupBox2.Controls.Add(CityLabel)
        Me.GroupBox2.Controls.Add(NameLabel1)
        Me.GroupBox2.Controls.Add(Me.StreetTextBox1)
        Me.GroupBox2.Controls.Add(Me.PostIndexTextBox)
        Me.GroupBox2.Controls.Add(PostIndexLabel)
        Me.GroupBox2.Controls.Add(StreetLabel1)
        Me.GroupBox2.Controls.Add(Me.StateTextBox)
        Me.GroupBox2.Controls.Add(StateLabel)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(466, 219)
        Me.GroupBox2.TabIndex = 42
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "В мой склад"
        '
        'NameTextBox1
        '
        Me.NameTextBox1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.IMoySkladDataProvider_AddressBindingSource, "Name", True))
        Me.NameTextBox1.Location = New System.Drawing.Point(60, 20)
        Me.NameTextBox1.Name = "NameTextBox1"
        Me.NameTextBox1.Size = New System.Drawing.Size(400, 20)
        Me.NameTextBox1.TabIndex = 32
        '
        'PhoneTextBox1
        '
        Me.PhoneTextBox1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.IMoySkladDataProvider_AddressBindingSource, "Phone", True))
        Me.PhoneTextBox1.Location = New System.Drawing.Point(60, 188)
        Me.PhoneTextBox1.Name = "PhoneTextBox1"
        Me.PhoneTextBox1.Size = New System.Drawing.Size(274, 20)
        Me.PhoneTextBox1.TabIndex = 34
        '
        'CountryTextBox
        '
        Me.CountryTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.IMoySkladDataProvider_AddressBindingSource, "Country", True))
        Me.CountryTextBox.Location = New System.Drawing.Point(60, 160)
        Me.CountryTextBox.Name = "CountryTextBox"
        Me.CountryTextBox.Size = New System.Drawing.Size(249, 20)
        Me.CountryTextBox.TabIndex = 28
        '
        'CityTextBox
        '
        Me.CityTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.IMoySkladDataProvider_AddressBindingSource, "City", True))
        Me.CityTextBox.Location = New System.Drawing.Point(60, 104)
        Me.CityTextBox.Name = "CityTextBox"
        Me.CityTextBox.Size = New System.Drawing.Size(304, 20)
        Me.CityTextBox.TabIndex = 26
        '
        'StreetTextBox1
        '
        Me.StreetTextBox1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.IMoySkladDataProvider_AddressBindingSource, "Street", True))
        Me.StreetTextBox1.Location = New System.Drawing.Point(60, 48)
        Me.StreetTextBox1.Name = "StreetTextBox1"
        Me.StreetTextBox1.Size = New System.Drawing.Size(400, 20)
        Me.StreetTextBox1.TabIndex = 40
        '
        'PostIndexTextBox
        '
        Me.PostIndexTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.IMoySkladDataProvider_AddressBindingSource, "PostIndex", True))
        Me.PostIndexTextBox.Location = New System.Drawing.Point(60, 132)
        Me.PostIndexTextBox.Name = "PostIndexTextBox"
        Me.PostIndexTextBox.Size = New System.Drawing.Size(100, 20)
        Me.PostIndexTextBox.TabIndex = 36
        '
        'StateTextBox
        '
        Me.StateTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.IMoySkladDataProvider_AddressBindingSource, "State", True))
        Me.StateTextBox.Location = New System.Drawing.Point(72, 76)
        Me.StateTextBox.Name = "StateTextBox"
        Me.StateTextBox.Size = New System.Drawing.Size(292, 20)
        Me.StateTextBox.TabIndex = 38
        '
        'ucClient
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "ucClient"
        Me.Size = New System.Drawing.Size(662, 400)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.IMoySkladDataProvider_AddressBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents tbFullName As System.Windows.Forms.TextBox
    Friend WithEvents UserIDTextBox As System.Windows.Forms.TextBox
    Friend WithEvents EmailTextBox As System.Windows.Forms.TextBox
    Friend WithEvents btSearchClientByFullName As System.Windows.Forms.Button
    Friend WithEvents lbCustomers As System.Windows.Forms.ListBox
    Friend WithEvents lbUserSearchStatus As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents lbClientInterest As System.Windows.Forms.ListBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents rtbClientComment As System.Windows.Forms.RichTextBox
    Friend WithEvents rtbClientInterestDetails As System.Windows.Forms.RichTextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btCreateClient As System.Windows.Forms.Button
    Friend WithEvents lbClientTags As System.Windows.Forms.ListBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents NameTextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents PhoneTextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents CountryTextBox As System.Windows.Forms.TextBox
    Friend WithEvents CityTextBox As System.Windows.Forms.TextBox
    Friend WithEvents StreetTextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents PostIndexTextBox As System.Windows.Forms.TextBox
    Friend WithEvents StateTextBox As System.Windows.Forms.TextBox
    Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
    Friend WithEvents IMoySkladDataProvider_AddressBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents btCreateAddress As System.Windows.Forms.Button
    Friend WithEvents btSelectClient As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label

End Class
