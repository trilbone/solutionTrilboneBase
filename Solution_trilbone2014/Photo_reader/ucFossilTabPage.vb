Public Class ucFossilTabPage

    'Friend Shared oFossilNamesList As String()

    '-------------------------------------------------------
    Public Class FossilTab
        Inherits Windows.Forms.TabPage
        '--------------------------
        Friend WithEvents Fossil_full_nameComboBox As New System.Windows.Forms.ComboBox
        Friend WithEvents FossilNumberTextBox As New System.Windows.Forms.TextBox
        Friend WithEvents gbFossilParametrs As New System.Windows.Forms.GroupBox
        Friend WithEvents Fossil_heightTextBox As New System.Windows.Forms.TextBox
        Friend WithEvents Fossil_widthTextBox As New System.Windows.Forms.TextBox
        Friend WithEvents Fossil_lengthTextBox As New System.Windows.Forms.TextBox
        'labels
        Friend WithEvents Fossil_lengthLabel As System.Windows.Forms.Label
        Friend WithEvents Fossil_widthLabel As System.Windows.Forms.Label
        Friend WithEvents Fossil_heightLabel As System.Windows.Forms.Label
        Friend WithEvents FossilNumberLabel As System.Windows.Forms.Label

        Friend WithEvents tabctlFossils As System.Windows.Forms.TabControl
        ''data
        Friend WithEvents Fossil_binding As Windows.Forms.BindingSource

        Private Sub Fossil_heightTextBox_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles Fossil_heightTextBox.KeyPress
            'TODO событие окончания ввода
        End Sub

        Private Sub Fossil_lengthTextBox_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles Fossil_lengthTextBox.KeyPress
            If Asc(e.KeyChar) = 13 Then
                Fossil_widthTextBox.Focus()
            End If
        End Sub

        Private Sub Fossil_widthTextBox_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles Fossil_widthTextBox.KeyPress
            If Asc(e.KeyChar) = 13 Then
                Fossil_heightTextBox.Focus()
            End If
        End Sub


        ''' <summary>
        ''' замена точки на запятую
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Private Sub Sample_digit_TextBox_Validating(ByVal sender As Object, _
         ByVal e As System.ComponentModel.CancelEventArgs) Handles _
     Fossil_heightTextBox.Validating, Fossil_widthTextBox.Validating, _
     Fossil_lengthTextBox.Validating
            CType(sender, Windows.Forms.Control).Text = Service.clsApplicationTypes.ReplaceDecimalSplitter(CType(sender, Windows.Forms.Control).Text)
        End Sub
        ''' <summary>
        ''' удаление нуля
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Private Sub Sample_DataTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles Fossil_heightTextBox.GotFocus, Fossil_widthTextBox.GotFocus, _
     Fossil_lengthTextBox.GotFocus
            Dim _control As Control = CType(sender, Control)
            If _control.Text = "" Then Exit Sub
            Dim _result As Decimal
            If Decimal.TryParse(_control.Text, _result) = False Then
                _control.Text = ""
            ElseIf _result = 0 Then
                _control.Text = ""
            End If

        End Sub
        Public Sub New(ByRef FossilData As Service.tb_Samples_Fossils)
            Me.Fossil_binding = New Windows.Forms.BindingSource
            Me.Fossil_binding.DataSource = FossilData
            ''add component
            Me.InitializeComponent()
        End Sub
        Public Sub New(ByRef Bindings As Data.DataRow)
            ''data bindings
            Me.Fossil_binding = New Windows.Forms.BindingSource
            Me.Fossil_binding.DataSource = Bindings
            ''add component
            Me.InitializeComponent()
        End Sub

        Private Sub InitializeComponent()
            Dim Fossil_full_nameLabel As System.Windows.Forms.Label

            Me.FossilNumberTextBox = New System.Windows.Forms.TextBox()
            Me.gbFossilParametrs = New System.Windows.Forms.GroupBox()
            Me.Fossil_heightTextBox = New System.Windows.Forms.TextBox()
            Me.Fossil_widthTextBox = New System.Windows.Forms.TextBox()
            Me.Fossil_lengthTextBox = New System.Windows.Forms.TextBox()
            Me.tabctlFossils = New System.Windows.Forms.TabControl()
            Me.Fossil_lengthLabel = New System.Windows.Forms.Label()
            Me.Fossil_widthLabel = New System.Windows.Forms.Label()
            Me.Fossil_heightLabel = New System.Windows.Forms.Label()
            Me.FossilNumberLabel = New System.Windows.Forms.Label()
            Fossil_full_nameLabel = New System.Windows.Forms.Label()
            '
            'init controls
            'Fossil_lengthLabel
            '
            Fossil_lengthLabel.AutoSize = True
            Fossil_lengthLabel.Location = New System.Drawing.Point(6, 32)
            Fossil_lengthLabel.Name = "Fossil_lengthLabel"
            Fossil_lengthLabel.Size = New System.Drawing.Size(63, 13)
            Fossil_lengthLabel.TabIndex = 0
            Fossil_lengthLabel.Text = "Длина, см:"
            '
            'Fossil_widthLabel
            '
            Fossil_widthLabel.AutoSize = True
            Fossil_widthLabel.Location = New System.Drawing.Point(6, 66)
            Fossil_widthLabel.Name = "Fossil_widthLabel"
            Fossil_widthLabel.Size = New System.Drawing.Size(69, 13)
            Fossil_widthLabel.TabIndex = 2
            Fossil_widthLabel.Text = "Ширина, см:"
            '
            'Fossil_heightLabel
            '
            Fossil_heightLabel.AutoSize = True
            Fossil_heightLabel.Location = New System.Drawing.Point(6, 100)
            Fossil_heightLabel.Name = "Fossil_heightLabel"
            Fossil_heightLabel.Size = New System.Drawing.Size(68, 13)
            Fossil_heightLabel.TabIndex = 4
            Fossil_heightLabel.Text = "Высота, см:"
            '
            'FossilNumberLabel
            '
            FossilNumberLabel.AutoSize = True
            FossilNumberLabel.Location = New System.Drawing.Point(6, 0)
            FossilNumberLabel.Name = "FossilNumberLabel"
            'FossilNumberLabel.Size = New System.Drawing.Size(97, 13)
            FossilNumberLabel.TabIndex = 1
            FossilNumberLabel.Text = "Номер объекта на образце:"
            '
            'Fossil_full_nameLabel
            '
            Fossil_full_nameLabel.AutoSize = True
            Fossil_full_nameLabel.Location = New System.Drawing.Point(6, 52)
            Fossil_full_nameLabel.Name = "Fossil_full_nameLabel"
            Fossil_full_nameLabel.Size = New System.Drawing.Size(60, 13)
            Fossil_full_nameLabel.TabIndex = 21
            Fossil_full_nameLabel.Text = "Название:"

            'Fossil_full_nameComboBox
            '

            Me.Fossil_full_nameComboBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Fossil_binding, "Fossil_full_name", True))
            Me.Fossil_full_nameComboBox.FormattingEnabled = True
            Me.Fossil_full_nameComboBox.Location = New System.Drawing.Point(9, 73)
            Me.Fossil_full_nameComboBox.Name = "Fossil_full_nameComboBox"
            Me.Fossil_full_nameComboBox.Size = New System.Drawing.Size(227, 21)
            Me.Fossil_full_nameComboBox.TabIndex = 10


            '
            'FossilNumberTextBox
            '
            Me.FossilNumberTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Fossil_binding, "FossilNumber", True))
            Me.FossilNumberTextBox.Location = New System.Drawing.Point(9, 22)
            Me.FossilNumberTextBox.Name = "FossilNumberTextBox"
            Me.FossilNumberTextBox.Size = New System.Drawing.Size(120, 20)
            Me.FossilNumberTextBox.TabIndex = 21
            Me.FossilNumberTextBox.Enabled = True
            '
            'gbFossilParametrs
            '
            Me.gbFossilParametrs.Controls.Add(Fossil_heightLabel)
            Me.gbFossilParametrs.Controls.Add(Me.Fossil_heightTextBox)
            Me.gbFossilParametrs.Controls.Add(Fossil_widthLabel)
            Me.gbFossilParametrs.Controls.Add(Me.Fossil_widthTextBox)
            Me.gbFossilParametrs.Controls.Add(Fossil_lengthLabel)
            Me.gbFossilParametrs.Controls.Add(Me.Fossil_lengthTextBox)
            Me.gbFossilParametrs.Location = New System.Drawing.Point(9, 105)
            Me.gbFossilParametrs.Name = "gbFossilParametrs"
            Me.gbFossilParametrs.Size = New System.Drawing.Size(154, 131)
            Me.gbFossilParametrs.TabIndex = 21
            Me.gbFossilParametrs.TabStop = False
            Me.gbFossilParametrs.Text = "Параметры объекта"
            '
            'Fossil_heightTextBox
            '
            Me.Fossil_heightTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Fossil_binding, "Fossil_height", True))
            Me.Fossil_heightTextBox.Location = New System.Drawing.Point(75, 97)
            Me.Fossil_heightTextBox.Name = "Fossil_heightTextBox"
            Me.Fossil_heightTextBox.Size = New System.Drawing.Size(66, 20)
            Me.Fossil_heightTextBox.TabIndex = 9
            '
            'Fossil_widthTextBox
            '
            Me.Fossil_widthTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Fossil_binding, "Fossil_width", True))
            Me.Fossil_widthTextBox.Location = New System.Drawing.Point(75, 63)
            Me.Fossil_widthTextBox.Name = "Fossil_widthTextBox"
            Me.Fossil_widthTextBox.Size = New System.Drawing.Size(66, 20)
            Me.Fossil_widthTextBox.TabIndex = 8
            '
            'Fossil_lengthTextBox
            '
            Me.Fossil_lengthTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Fossil_binding, "Fossil_length", True))
            Me.Fossil_lengthTextBox.Location = New System.Drawing.Point(75, 29)
            Me.Fossil_lengthTextBox.Name = "Fossil_lengthTextBox"
            Me.Fossil_lengthTextBox.Size = New System.Drawing.Size(66, 20)
            Me.Fossil_lengthTextBox.TabIndex = 7
            '
            'me - FossilTabPage
            '
            Me.AutoScroll = True
            Me.Controls.Add(Fossil_full_nameLabel)
            Me.Controls.Add(Me.Fossil_full_nameComboBox)
            Me.Controls.Add(FossilNumberLabel)
            Me.Controls.Add(Me.FossilNumberTextBox)
            Me.Controls.Add(Me.gbFossilParametrs)
            Me.Location = New System.Drawing.Point(4, 22)

            Dim _number = Fossil_binding.Current.FossilNumber.ToString
            Dim _code = Global.Service.clsApplicationTypes.clsSampleNumber.CreateFromString(_number)
            If Not _code Is Nothing AndAlso _code.CodeIsCorrect Then
                Me.Name = "TabPage" & _code.ShotCode
                Me.Text = _code.ShotCode
            Else
                Me.Name = "TabPage" & Fossil_binding.Current.FossilNumber.ToString
                Me.Text = "No. " & Fossil_binding.Current.FossilNumber.ToString
            End If


            Me.Padding = New System.Windows.Forms.Padding(3)
            Me.Size = New System.Drawing.Size(247, 244)
            Me.TabIndex = 0
            Me.UseVisualStyleBackColor = True

            '
        End Sub
        ''' <summary>
        ''' значение поля номер фоссилии
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property FossilNumber As String
            Get
                Return Me.FossilNumberTextBox.Text
            End Get
            Set(value As String)
                Me.FossilNumberTextBox.Text = value
            End Set
        End Property


        ''' <summary>
        ''' заполнить список названий
        ''' </summary>
        ''' <value></value>
        ''' <remarks></remarks>
        Public WriteOnly Property FossilNamesList As String()
            Set(value As String())
                Me.Fossil_full_nameComboBox.Items.Clear()

                If Not value Is Nothing Then
                    With Me.Fossil_full_nameComboBox
                        .Items.AddRange(value)
                        .AutoCompleteMode = AutoCompleteMode.SuggestAppend
                        .AutoCompleteSource = AutoCompleteSource.ListItems
                    End With
                End If

            End Set
        End Property

        Private Sub FossilNumberTextBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles FossilNumberTextBox.KeyPress
            If Asc(e.KeyChar) = 13 Then
                Dim _code = Global.Service.clsApplicationTypes.clsSampleNumber.CreateFromString(FossilNumberTextBox.Text)
                If Not _code Is Nothing AndAlso _code.CodeIsCorrect Then
                    FossilNumberTextBox.Text = _code.EAN13
                End If
            End If

        End Sub

        Private Sub FossilNumberTextBox_leave(sender As Object, e As EventArgs) Handles FossilNumberTextBox.Leave
            Dim _code = Global.Service.clsApplicationTypes.clsSampleNumber.CreateFromString(FossilNumberTextBox.Text)
            If Not _code Is Nothing AndAlso _code.CodeIsCorrect Then
                FossilNumberTextBox.Text = _code.EAN13
            End If
        End Sub

        Private Sub FossilNumberLabel_MouseClick(sender As Object, e As MouseEventArgs) Handles FossilNumberLabel.MouseClick
            clsPhotoService.GetDigiKey.connect(Me.FossilNumberTextBox)
        End Sub

        Private Sub Fossil_heightLabel_MouseClick(sender As Object, e As MouseEventArgs) Handles Fossil_heightLabel.MouseClick
            Me.Fossil_heightTextBox.Text = ""
            clsPhotoService.GetDigiKey.connect(Me.Fossil_heightTextBox)
        End Sub

        Private Sub Fossil_widthLabel_MouseClick(sender As Object, e As MouseEventArgs) Handles Fossil_widthLabel.MouseClick
            Me.Fossil_widthTextBox.Text = ""
            clsPhotoService.GetDigiKey.connect(Me.Fossil_widthTextBox)
        End Sub

        Private Sub Fossil_lengthLabel_MouseClick(sender As Object, e As MouseEventArgs) Handles Fossil_lengthLabel.MouseClick
            Me.Fossil_lengthTextBox.Text = ""
            clsPhotoService.GetDigiKey.connect(Me.Fossil_lengthTextBox)
        End Sub

    End Class

    '----------------------------------------------------------------------
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub


    ''' <summary>
    ''' номер в выбранной вкладке
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property FossilSelectedNumber As String
        Get
            Return CType(Me.tabctlFossils.TabPages(FossilSelectedIndex), FossilTab).FossilNumber
        End Get
    End Property

    ''' <summary>
    ''' индекс выбранной вкладки
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property FossilSelectedIndex As Integer
        Get
            Return Me.tabctlFossils.SelectedIndex
        End Get
        Set(value As Integer)
            Me.tabctlFossils.SelectedIndex = value
        End Set
    End Property
    ''' <summary>
    ''' кол-во добавленных фоссилий
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property FossilCount As Integer
        Get
            Return Me.tabctlFossils.TabCount
        End Get
    End Property


    ''' <summary>
    ''' загрузка списка фоссилий - new version
    ''' </summary>
    ''' <param name="FossilDataCollection"></param>
    ''' <remarks></remarks>
    Public Overloads Sub LoadData(ByRef FossilDataCollection As List(Of Service.tb_Samples_Fossils))
        Dim _tab As FossilTab
        For Each _row In FossilDataCollection

            _tab = New FossilTab(_row)

            Me.tabctlFossils.TabPages.Add(_tab)
            Me.tabctlFossils.SelectedTab = _tab
        Next
    End Sub
    ''' <summary>
    ''' вернет размер первой (основной) объекта
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property GetFirstFossilLen As Decimal
        Get
            If Me.tabctlFossils.TabPages.Count = 0 Then Return 0

            Dim _p As FossilTab = Me.tabctlFossils.TabPages(0)

            If _p.Fossil_lengthTextBox.Text = "" Then Return 0

            Return Decimal.Parse(_p.Fossil_lengthTextBox.Text)
        End Get
    End Property
    ''' <summary>
    ''' вернет имя фоссилии с первой вкладки
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property GetFirstFossilName As String
        Get
            If Me.tabctlFossils.TabPages.Count = 0 Then Return ""
            Dim _p As FossilTab = Me.tabctlFossils.TabPages(0)
            Return _p.Fossil_full_nameComboBox.Text
        End Get
    End Property

    ''' <summary>
    ''' вернет номер фоссилии с первой вкладки
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property GetFirstFossilNumber As String
        Get
            If Me.tabctlFossils.TabPages.Count = 0 Then Return ""
            Dim _p As FossilTab = Me.tabctlFossils.TabPages(0)
            Return _p.FossilNumber
        End Get
    End Property

    ''' <summary>
    ''' вернет список названий фоссилий + длину первой объекта
    ''' </summary>
    ''' <param name="_firstFossilLen"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetFossilsList(ByRef _firstFossilLen As Decimal) As List(Of String)
        Dim _out As New List(Of String)
        If Me.tabctlFossils.TabPages.Count = 0 Then Return _out

        Dim _first As Boolean = False
        For Each t As FossilTab In Me.tabctlFossils.TabPages
            _out.Add(t.Fossil_full_nameComboBox.Text)
            If Not _first Then
                If Not t.Fossil_lengthTextBox.Text = "" Then
                    _firstFossilLen = Decimal.Parse(t.Fossil_lengthTextBox.Text)
                End If
            End If
            _first = True
        Next
        Return _out
    End Function

    ''' <summary>
    ''' загрузка списка фоссилий - old version
    ''' </summary>
    ''' <param name="DataRows"></param>
    ''' <remarks></remarks>
    Public Overloads Sub LoadData(ByVal DataRows As Data.DataRow())
        Dim _tab As FossilTab
        For Each _row As Data.DataRow In DataRows

            _tab = New FossilTab(_row)

            '_tab.FossilNamesSource = _fossilnamesList
            Me.tabctlFossils.TabPages.Add(_tab)
            Me.tabctlFossils.SelectedTab = _tab
        Next
    End Sub


    'Public ReadOnly Property TabFossilsCollection As Windows.Forms.TabControl.TabPageCollection
    '    Get
    '        Return Me.tabctlFossils.TabPages
    '    End Get
    'End Property

    Public Shadows ReadOnly Property TabCount As Integer
        Get
            Return Me.tabctlFossils.TabCount
        End Get
    End Property

    Public Sub Clear()
        Me.tabctlFossils.TabPages.Clear()
    End Sub

    ''' <summary>
    ''' источник списка названий фоссилий
    ''' </summary>
    Public WriteOnly Property FossilNamesSource As String()
        Set(ByVal value As String())
            'oFossilNamesList = value
            For Each t As FossilTab In Me.tabctlFossils.TabPages
                t.FossilNamesList = value
            Next
        End Set
    End Property
    ''' <summary>
    ''' перезаписывает имя объекта на первой вкладке
    ''' </summary>
    ''' <value></value>
    ''' <remarks></remarks>
    Public WriteOnly Property SetFossilNameInFirstTab As String
        Set(value As String)

            If Me.tabctlFossils.TabCount > 0 Then
                Dim _tab = CType(Me.tabctlFossils.TabPages(0), FossilTab)
                Dim obj = _tab.Fossil_full_nameComboBox.DataBindings(0).BindingManagerBase.Current
                _tab.Fossil_full_nameComboBox.Text = value
                obj.Fossil_full_name = value
            End If
        End Set
    End Property

    'Protected Overrides Sub Finalize()
    '    MyBase.Finalize()
    'End Sub
End Class
