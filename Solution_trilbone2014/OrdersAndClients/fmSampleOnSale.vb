Public Class fmSampleOnSale
    Private oCurrentsampleNumber As Decimal
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.LockedAll()
    End Sub
    Public Sub New(ByVal SampleNumber As Decimal, ByVal CurrencyList As String())
        InitializeComponent()

        oCurrentsampleNumber = SampleNumber
        Me.LockedAll()

        'загрузка списка валют
        Me.CurrencyNameComboBox.DataSource = CurrencyList
        Me.CurrencyNameComboBox.SelectedIndex = 0

        If oCurrentsampleNumber > 0 Then
            Me.SampleNumberTextBox.Text = oCurrentsampleNumber.ToString
            Me.LoadSample()
        End If

    End Sub
    Private Sub LoadSample()
        Me.LockedAll()
        'fill from table

        Try
            Me.Select_tb_SamplesOnSaleTableAdapter.Fill(Me.dsSampleOnSale.Select_tb_SamplesOnSale, Me.oCurrentsampleNumber)

        Catch ex As Exception
            MsgBox("Can't connect to DB. Connection string: " & Me.Select_tb_SamplesOnSaleTableAdapter.Connection.ConnectionString)
            Exit Sub
        End Try
        'check data existing
        If Me.Select_tb_SamplesOnSaleBindingSource.Count = 0 Then
            Dim _version() As Byte = {0}
            Me.dsSampleOnSale.Select_tb_SamplesOnSale.AddSelect_tb_SamplesOnSaleRow(oCurrentsampleNumber, True, False, 0, False, "", 0, _version, "", False, 0, 0, 0, "")
        End If
        Me.UnlockedAll()
        '-----------------------------
        'проверить наличие данных для образца
        Dim _tmpAdapter As New dsServiceTableAdapters.Select_SampleInfoTableAdapter
        Select Case _tmpAdapter.GetData(oCurrentsampleNumber).Rows.Count
            Case 0
                'данных нет
                ' Me.lbIsSampleData.Text = "данных для образца нет!"
                Me.BtSampleData.Text = "Создать данные образца.."
            Case Is > 0
                'данные есть
                'Me.lbIsSampleData.Text = "данные для образца есть"
                Me.BtSampleData.Text = "Посмотреть данные образца.."
        End Select
        '----------------------------
        '' описание
        'Dim _status As Integer
        'Dim _result = Trilbone.clsTreeService.ParseTextToXElement(Me.Select_tb_SamplesOnSaleBindingSource.Current.row.Description, _status)
        'If _status > 0 Then
        '    Me.oCurrentXMLDescription = _result
        'Else
        '    Me.oCurrentXMLDescription = Nothing
        'End If

        ''If rbRussian.Checked Then
        ''    oCurrentCulture = Service.clsApplicationTypes.RussianCulture
        ''Else
        ''    oCurrentCulture = Service.clsApplicationTypes.EnglishCulture
        ''End If
        'Me.oIndexlbElements = -1
        'Me.BuildDescription()
    End Sub
    Private Sub LockedAll()
        For Each _ctl As Control In Me.Controls
            _ctl.Enabled = False
        Next
        Me.SampleNumberTextBox.Enabled = True
    End Sub
    Private Sub UnlockedAll()
        For Each _ctl As Control In Me.Controls
            _ctl.Enabled = True
        Next
        Me.SampleNumberTextBox.Enabled = False
    End Sub

    Private Sub fmSampleOnSale_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Me.Select_tb_SamplesOnSaleBindingSource.CancelEdit()
    End Sub

    Private Sub SampleNumberTextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles SampleNumberTextBox.KeyPress
        Select Case Char.IsControl(e.KeyChar)
            Case True
                If Asc(e.KeyChar) = 13 Then
                    'получить код
                    Dim _code As String = Global.Service.clsApplicationTypes.clsSampleNumber.GetFullCodeByShot(SampleNumberTextBox.Text)
                    If _code.Length = 13 Then
                        SampleNumberTextBox.Text = _code
                        oCurrentsampleNumber = New System.Nullable(Of Decimal)(CType(_code, Decimal))
                        Me.LoadSample()
                    End If
                End If
        End Select
    End Sub


    Private Sub BtSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtSave.Click
        Me.Validate()
        Dim _row As SampleOnSale.Select_tb_SamplesOnSaleRow
        _row = Me.Select_tb_SamplesOnSaleBindingSource.Current.row
        'If Not oCurrentXMLDescription Is Nothing Then
        '    _row.Description = oCurrentXMLDescription.ToString
        'Else
        '    _row.Description = ""
        'End If

        Me.Select_tb_SamplesOnSaleBindingSource.EndEdit()

        MsgBox("SampleOnSale: Обновлено " & Me.TableAdapterManager.UpdateAll(Me.dsSampleOnSale).ToString & " записей")
    End Sub

    Private Sub BtCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtCancel.Click
        Me.Select_tb_SamplesOnSaleBindingSource.CancelEdit()
        Me.LoadSample()
    End Sub

    Private Sub BtSampleData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtSampleData.Click
        Dim _param As Object = {oCurrentsampleNumber}
        Dim _fmSampleData As Form

        'по запросу выполняем вызов из сервиса
        'если делегата нет, то сервис недоступен
        If Not Global.Service.clsApplicationTypes.DelegateStoreApplicationForm _
            (Service.clsApplicationTypes.emFormsList.fmSampleData) Is Nothing Then
            'сервис зарегестрирован - вызываем
            _fmSampleData = Global.Service.clsApplicationTypes.DelegateStoreApplicationForm _
                (Service.clsApplicationTypes.emFormsList.fmSampleData).Invoke(_param)
        Else
            Exit Sub
        End If

        'сохранить запись
        Me.Select_tb_SamplesOnSaleBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.dsSampleOnSale)
        'открыть окно
        _fmSampleData.ShowDialog()
        'перезагрузить образуц
        Me.LoadSample()
    End Sub

    Private Sub CurrencyNameComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CurrencyNameComboBox.SelectedIndexChanged
        'Me.lbCurrencyName1.Text = Me.CurrencyNameComboBox.SelectedItem
        'Me.lbCurrencyName2.Text = Me.CurrencyNameComboBox.SelectedItem

        'проверка наличия курса в буфере
        If Not Me.CurrencyNameComboBox.SelectedItem Is Nothing Then
            'курс в буфере
            Me.RateOfExchangeTextBox.Text = Service.clsApplicationTypes.CurrencyRateNow _
                (Me.CurrencyNameComboBox.SelectedItem)
        End If

        Me.RateOfExchangeTextBox.Focus()


    End Sub

    Private Sub btClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btClose.Click
        Me.Close()
    End Sub

    Private Sub fmSampleOnSale_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'window position
        If Not Me.ParentForm Is Nothing Then
            Me.Location = New Point(Me.ParentForm.ClientRectangle.Left, Me.ParentForm.ClientRectangle.Top)
        Else
            Me.StartPosition = FormStartPosition.CenterScreen
        End If

    End Sub

    ''' <summary>
    ''' замена . на ,
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub RateOfExchangeTextBox_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) _
        Handles RateOfExchangeTextBox.Validating, CostsTextBox.Validating
        Dim _ctl As Control = CType(sender, Control)
        _ctl.Text = Service.clsApplicationTypes.ReplaceDecimalSplitter(_ctl.Text)

        If Not Me.CurrencyNameComboBox.SelectedItem Is Nothing Then
            'запись курса валют
            If sender Is Me.RateOfExchangeTextBox Then
                If Service.clsApplicationTypes.CurrencyRateNow _
         (Me.CurrencyNameComboBox.SelectedItem) = 0 Then
                    Service.clsApplicationTypes.CurrencyRateNow _
           (Me.CurrencyNameComboBox.SelectedItem) = Decimal.Parse(Me.RateOfExchangeTextBox.Text)
                End If

            End If

        End If

    End Sub

    'Private Sub DescriptionChangedEventHandler(sender As Object)
    '    Dim _status As Integer

    '    Dim _result = Trilbone.clsTreeService.JoinDescription(Me.oCurrentXMLDescription, sender.XMLDescription, _status)
    '    If _status > 0 Then
    '        Me.oCurrentXMLDescription = _result
    '    Else
    '        MsgBox("Не удалось присоединить описание")
    '    End If
    '    Me.BuildDescription()
    'End Sub

    'Private Sub btGetDescriptionBuilder_Click(sender As System.Object, e As System.EventArgs)

    '    Dim _param = {Me.lbElements.SelectedItem}
    '    Dim _fm As Form
    '    'по запросу выполняем вызов из сервиса
    '    'если делегата нет, то сервис недоступен
    '    If Not Global.Service.clsApplicationTypes.DelegateStoreApplicationForm _
    '        (Service.clsApplicationTypes.emFormsList.fmDescriptionTreeBuilder) Is Nothing Then
    '        'сервис зарегестрирован - вызываем
    '        _fm = Global.Service.clsApplicationTypes.DelegateStoreApplicationForm _
    '            (Service.clsApplicationTypes.emFormsList.fmDescriptionTreeBuilder).Invoke(_param)
    '        If Not _fm Is Nothing Then
    '            'AddHandler _fm.descriptionChanged, AddressOf Me.DescriptionChangedEventHandler
    '            _fm.Visible = False
    '            _fm.ShowDialog(Me)
    '            Call DescriptionChangedEventHandler(_fm)
    '        End If
    '    End If
    'End Sub
    'Private oCurrentElementsCollection As New List(Of Trilbone.clsTreeService.clsDescriptionElement)


    'Private Sub BuildDescription()

    '    If oCurrentXMLDescription Is Nothing Then
    '        'если описание не xml, то покажем исходник
    '        If Not Me.Select_tb_SamplesOnSaleBindingSource.Current Is Nothing Then
    '            Me.DescriptionRichTextBox.Text = Me.Select_tb_SamplesOnSaleBindingSource.Current.row.Description
    '            Me.DescriptionRichTextBox.ForeColor = Color.Red
    '        End If
    '        Exit Sub
    '    End If
    '    'описание есть xml
    '    Me.DescriptionRichTextBox.ForeColor = ForeColor

    '    'заполним список элементов
    '    oCurrentElementsCollection = Trilbone.clsTreeService.GetElementsCollection(oCurrentXMLDescription)
    '    'привяжем listbox
    '    Me.lbElements.DataSource = oCurrentElementsCollection
    '    If oIndexlbElements >= 0 Then
    '        'установим запомненный после обновления индекс
    '        Me.lbElements.SelectedIndex = oIndexlbElements
    '    End If
    '    'заполним префиксы
    '    Select Case oCurrentCulture.Name
    '        Case Trilbone.clsTreeService.EnglishCulture.Name
    '            Me.tbPrefixElement.Text = "Additional info"
    '        Case Trilbone.clsTreeService.RussianCulture.Name
    '            Me.tbPrefixElement.Text = "Доп.инфо"
    '        Case Else
    '            Me.tbPrefixElement.Text = "Additional info"
    '    End Select

    '    Me.tbTagOfElement.Text = "USERDESCR"

    '    'покажем описание
    '    If cbxRawXMLView.Checked Then
    '        'покажем сырой xml
    '        Me.DescriptionRichTextBox.Text = oCurrentXMLDescription.ToString
    '        'и разрешим редактировать..
    '        Me.DescriptionRichTextBox.ReadOnly = False
    '        Exit Sub
    '    End If

    '    'иначе покажем разобранное описание
    '    Dim _status As Integer
    '    Dim _result = Trilbone.clsTreeService.ParseDescriptionXML(oCurrentCulture, oCurrentXMLDescription.ToString, _status)
    '    If _status > 0 Then
    '        Me.DescriptionRichTextBox.Text = _result
    '    Else
    '        Me.DescriptionRichTextBox.Text = "Не удалось разобрать описание"
    '    End If
    '    ' и запретим редактировать
    '    Me.DescriptionRichTextBox.ReadOnly = True
    'End Sub

    'Private Sub btAddUserDescr_Click(sender As System.Object, e As System.EventArgs)
    '    If Me.UserDescriptionRichTextBox.Text = "" Then Exit Sub

    '    Dim _tag = tbTagOfElement.Text
    '    If _tag = "" Then
    '        _tag = "USERDESCR"
    '        tbTagOfElement.Text = "USERDESCR"
    '    End If

    '    Dim _n = Trilbone.clsTreeService.clsDescriptionElement.CreateInstance(0, "notfile", _tag, Me.tbPrefixElement.Text, oCurrentCulture, Me.UserDescriptionRichTextBox.Text)

    '    Me.oCurrentXMLDescription = Trilbone.clsTreeService.AddElementToDescription(Me.oCurrentXMLDescription, {_n})
    '    Me.oIndexlbElements = Me.lbElements.Items.Count
    '    Me.BuildDescription()
    'End Sub


    'Private oCurrentCulture As System.Globalization.CultureInfo = Service.clsApplicationTypes.EnglishCulture
    'Private Sub rbEnglish_CheckedChanged(sender As System.Object, e As System.EventArgs)
    '    oCurrentCulture = Service.clsApplicationTypes.EnglishCulture
    '    Me.BuildDescription()
    'End Sub

    'Private Sub rbRussian_CheckedChanged(sender As System.Object, e As System.EventArgs)
    '    oCurrentCulture = Service.clsApplicationTypes.RussianCulture
    '    Me.BuildDescription()
    'End Sub


    'Private oCurrentXMLDescription As Xml.Linq.XElement

    'Private Sub cbxRawXMLView_CheckedChanged(sender As System.Object, e As System.EventArgs)
    '    Me.BuildDescription()
    'End Sub

    'Private Sub DescriptionRichTextBox_TextChanged(sender As Object, e As System.EventArgs)
    '    If Me.oCurrentXMLDescription Is Nothing Then Exit Sub
    '    'был изменен текст
    '    If cbxRawXMLView.Checked Then
    '        'в окне-сырой xml
    '        'пробуем преобразовать в xml
    '        Dim _status As Integer
    '        Dim _result = Trilbone.clsTreeService.ParseTextToXElement(Me.DescriptionRichTextBox.Text, _status)
    '        If _status <= 0 Then
    '            'неудачно изменен
    '            MsgBox("Неправильно форматированный xml!", vbCritical)
    '            Me.DescriptionRichTextBox.Text = Me.oCurrentXMLDescription.ToString
    '        Else
    '            Me.oCurrentXMLDescription = _result
    '            Me.DescriptionRichTextBox.Text = _result.ToString
    '            Me.BuildDescription()
    '        End If
    '    End If

    'End Sub


    'Private Sub btClearAll_Click(sender As System.Object, e As System.EventArgs)
    '    Me.oCurrentXMLDescription = Nothing
    '    Me.DescriptionRichTextBox.Text = ""
    '    Me.UserDescriptionRichTextBox.Text = ""

    '    'Me.lbElements.BindingContext.Item(Me.oCurrentElementsCollection).SuspendBinding()
    '    If Not Me.oCurrentElementsCollection Is Nothing Then
    '        Me.oCurrentElementsCollection.Clear()
    '    End If
    '    Me.lbElements.DataSource = Nothing
    '    'Me.lbElements.BindingContext.Item(Me.oCurrentElementsCollection).ResumeBinding()
    'End Sub
    'Private oIndexlbElements As Integer
   

    'Private Sub lbElements_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)
    '    If lbElements.SelectedItem Is Nothing Then Exit Sub
    '    Dim _curr = CType(lbElements.SelectedItem, Trilbone.clsTreeService.clsDescriptionElement)
    '    Me.UserDescriptionRichTextBox.Text = _curr.Value
    '    Me.UserDescriptionRichTextBox.Tag = _curr
    '    Me.btSaveElement.ForeColor = Control.DefaultForeColor
    '    'oIndexlbElements = -1
    'End Sub

    'Private Sub btSaveElement_Click(sender As System.Object, e As System.EventArgs)
    '    If lbElements.SelectedItem Is Nothing Then Exit Sub
    '    Dim _curr = CType(lbElements.SelectedItem, Trilbone.clsTreeService.clsDescriptionElement)
    '    If _curr.Equals(Me.UserDescriptionRichTextBox.Tag) Then
    '        'все ок текст относится к нужному элементу
    '        _curr.Value = Me.UserDescriptionRichTextBox.Text
    '        Me.oIndexlbElements = Me.lbElements.SelectedIndex
    '    End If

    '    btSaveElement.ForeColor = Control.DefaultForeColor
    '    Me.BuildDescription()
    'End Sub

    'Private Sub btDelElement_Click(sender As System.Object, e As System.EventArgs)
    '    If lbElements.SelectedItem Is Nothing Then Exit Sub
    '    Dim _curr = CType(lbElements.SelectedItem, Trilbone.clsTreeService.clsDescriptionElement)
    '    Me.oCurrentElementsCollection.Remove(_curr)
    '    Me.oCurrentXMLDescription = Trilbone.clsTreeService.GetDescriptionFromElementCollection(Me.oCurrentElementsCollection)
    '    Me.oIndexlbElements = -1
    '    Me.BuildDescription()
    'End Sub

    
    'Private Sub UserDescriptionRichTextBox_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs)
    '    If lbElements.SelectedItem Is Nothing Then Exit Sub
    '    Dim _curr = CType(lbElements.SelectedItem, Trilbone.clsTreeService.clsDescriptionElement)
    '    If _curr.Equals(Me.UserDescriptionRichTextBox.Tag) Then
    '        If Not _curr.Value = Me.UserDescriptionRichTextBox.Text Then
    '            'текст узла изменен
    '            btSaveElement.ForeColor = Color.Red
    '        End If
    '    End If
    'End Sub

  
End Class