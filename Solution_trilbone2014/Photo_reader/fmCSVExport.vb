Imports Service
Public Class fmCSVExport
    Private oSampleList As clsSampleList
    ' Private oGoodList As Collections.Specialized.StringCollection
    Private Sub New()
        ' Этот вызов является обязательным для конструктора.
        InitializeComponent()
        ' Добавьте все инициализирующие действия после вызова InitializeComponent().
    End Sub

    Public Sub New(SampleList As clsSampleList)
        InitializeComponent()
        Me.oSampleList = SampleList
        Me.ClsSampleListBindingSource.DataSource = Me.oSampleList
        init()
    End Sub
    Private myArr As New List(Of String)
    Private Sub init()
        For Each t In My.Settings.GoodsGroup
            Me.lbGoods.Items.Add(t)
        Next

        Me.CSVpathTextBox.Text = My.Settings.CSVpath
        Me.CSVCommaTextBox.Text = My.Settings.CSVComma
        Me.cbConvertToCurr.SelectedIndex = 0
    End Sub

    Private Sub btRemoveGoodGroup_Click(sender As Object, e As EventArgs) Handles btRemoveGoodGroup.Click
        If Me.lbGoods.Items.Contains(tbCurrentGood.Text) Then
            Me.lbGoods.Items.Remove(tbCurrentGood.Text)
        End If
        Me.lbGoods.SelectedIndex = 0
    End Sub

    Private Sub btAddGoodGroup_Click(sender As Object, e As EventArgs) Handles btAddGoodGroup.Click
        If lbGoods.SelectedIndex < 0 Then Exit Sub
        'Dim _valueInList = lbGoods.SelectedItem
        Dim _valueInTB = Me.tbCurrentGood.Text
        If Me.lbGoods.Items.Contains(_valueInTB) Then Exit Sub
        Me.lbGoods.Items.Add(_valueInTB)
        Me.lbGoods.SelectedItem = _valueInTB
    End Sub

    Private Sub lbSamples_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbSamples.SelectedIndexChanged
        'Me.ClsSampleListBindingSource.DataSource = Me.lbSamples.SelectedItem
    End Sub
    ''' <summary>
    ''' запрашивает список образцов OnSale из PhotoReader
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetOnSaleSamplesList() As String()
        'по запросу выполняем вызов из сервиса
        'если делегата нет, то сервис недоступен
        If Not Global.Service.clsApplicationTypes.DelegateStoreOnSaleSampleList Is Nothing Then
            'сервис зарегестрирован - вызываем
            Return Global.Service.clsApplicationTypes.DelegateStoreOnSaleSampleList.Invoke()
        Else
            Return Nothing
        End If
    End Function
    Private Sub btAddSample_Click(sender As Object, e As EventArgs) Handles btAddSample.Click, BindingNavigatorAddNewItem.Click
        Dim _obj = CType(Me.ClsSampleListBindingSource.DataSource, clsSampleList)
        Dim _result = InputBox("Короткий номер образца для добавления", "Добавить образец", "")
        Dim _number = clsApplicationTypes.clsSampleNumber.CreateFromString(_result)
        If Not (_number Is Nothing) AndAlso _number.CodeIsCorrect Then
            If Not _obj.Contains(_number) Then
                _obj.Add(_number, _number.GetExtendedInfo.AnyName)
            Else
                MsgBox("Образец уже есть в списке", MsgBoxStyle.Critical)
            End If

        End If
        'Dim _fm = New fmSelectSample(GetOnSaleSamplesList, "образцы для продажи")
    End Sub

    Private Sub btRemoveSample_Click(sender As Object, e As EventArgs) Handles btRemoveSample.Click, BindingNavigatorDeleteItem.Click
        If Me.lbSamples.SelectedIndex < 0 Then Exit Sub
        Dim _result = Me.oSampleList.Find(Function(x) (x.SampleNumberEAN13 = Me.lbSamples.SelectedItem.ToString))
        If Not _result Is Nothing Then
            Me.ClsSampleListBindingSource.Remove(_result)
            'Me.oSampleList.Remove(_result.SampleNumber)
        End If
    End Sub

    Private Sub btClose_Click(sender As Object, e As EventArgs) Handles btClose.Click
        Me.SaveParameter()
        Me.Close()
    End Sub

    Private Sub btWriteCSV_Click(sender As Object, e As EventArgs) Handles btWriteCSV.Click, СохранитьToolStripButton.Click
        'replace * in good
        Dim _good = Me.tbCurrentGood.Text.Replace("*", "/")

        Dim _csv = Me.oSampleList.GetCSV(Me.CSVCommaTextBox.Text, _good)
        Try
            Dim _path = Me.CSVpathTextBox.Text
            IO.File.WriteAllText(_path, _csv, System.Text.Encoding.ASCII)
            ' My.Computer.FileSystem.WriteAllText(Me.CSVpathTextBox.Text, _csv, False)
            MsgBox("TXT файл записан " & Me.CSVpathTextBox.Text)
        Catch ex As Exception
            MsgBox("Не удалось записать файл. Закройте программу печати меток и попробуйте еще раз", vbCritical)
        End Try
        'Public Sub SaveListToCSV(ListName As String)
        '    Dim _path = IO.Path.GetFullPath(Service.clsApplicationTypes.DataFolderPath)
        '    _path = IO.Path.Combine(_path, "List_" & ListName & ".txt")
        '    Dim _result = Me.Find(Function(x) (x.NameOfList = ListName))
        '    If _result Is Nothing Then
        '        MsgBox("Списка с таким именем не существует", MsgBoxStyle.Critical)
        '        Exit Sub
        '    End If


        '    Try
        '        My.Computer.FileSystem.WriteAllText(_path, _result.GetCSV, False)
        '        MsgBox("TXT файл записан " & _path)
        '    Catch ex As Exception
        '        MsgBox("Не удалось записать файл. Закройте программу печати меток и попробуйте еще раз", vbCritical)
        '    End Try
        'End Sub
    End Sub

    Private Sub btCSVpath_Click(sender As Object, e As EventArgs) Handles btCSVpath.Click
        With Me.SaveFileDialog1
            .InitialDirectory = Me.CSVpathTextBox.Text
            .Filter = "Text files (*.txt)|*.txt|CSV files (*.csv)|*.csv"
            .AddExtension = True
            .CreatePrompt = True
            .DefaultExt = "csv"
            .OverwritePrompt = True
            .RestoreDirectory = True

        End With
        Select Case Me.SaveFileDialog1.ShowDialog
            Case Windows.Forms.DialogResult.OK
                Me.CSVpathTextBox.Text = Me.SaveFileDialog1.FileName
                'My.Computer.FileSystem.WriteAllText(_path, _result.GetCSV, False)
            Case Else

        End Select
    End Sub

    Private Sub btSaveDataSource_Click(sender As Object, e As EventArgs) Handles btSaveDataSource.Click
        Me.SaveParameter()
    End Sub

    Private Sub fmCSVExport_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub lbGoods_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbGoods.SelectedIndexChanged
        Me.tbCurrentGood.Text = Me.lbGoods.SelectedItem
    End Sub

    Private Sub btChangeGood_Click(sender As Object, e As EventArgs) Handles btChangeGood.Click
        If lbGoods.SelectedIndex < 0 Then Exit Sub
        Dim _valueInList = lbGoods.SelectedItem
        Dim _valueInTB = Me.tbCurrentGood.Text
        If _valueInList = _valueInTB Then Exit Sub
        Me.lbGoods.Items.Remove(_valueInList)
        Me.lbGoods.Items.Add(_valueInTB)
        Me.lbGoods.SelectedItem = _valueInTB
    End Sub

    Private Sub SaveParameter()

        My.Settings.CSVpath = Me.CSVpathTextBox.Text
        My.Settings.CSVComma = Me.CSVCommaTextBox.Text
        Dim _coll = My.Settings.GoodsGroup
        _coll.Clear()
        For Each t In Me.lbGoods.Items
            _coll.Add(t)
        Next
        My.Settings.Save()
        Me.oSampleList.Parent.Save()
    End Sub


    Private Sub btConversion_Click(sender As Object, e As EventArgs) Handles btConversion.Click
        Dim _cursUSD As Decimal = 33
        Dim _cursEUR As Decimal = 44
        Dim _cursUSDEUR As Decimal = 44 / 33
        Dim _price As Decimal
        If Not Decimal.TryParse(Me.PriceTextBox.Text, _price) Then
            MsgBox("Укажите правильно значение цены!", vbCritical)
        End If
        Select Case Me.cbConvertToCurr.SelectedItem
            Case "RUR"
                Select Case Me.CurrencyTextBox.Text
                    Case "RUR"
                    Case "USD"
                        Me.CurrencyTextBox.Text = "USD"
                        Me.PriceTextBox.Text = _price / _cursUSD
                    Case "EUR"
                        Me.CurrencyTextBox.Text = "EUR"
                        Me.PriceTextBox.Text = _price / _cursEUR
                End Select
            Case "USD"
                Select Case Me.CurrencyTextBox.Text
                    Case "RUR"
                        Me.CurrencyTextBox.Text = "RUR"
                        Me.PriceTextBox.Text = _price * _cursUSD
                    Case "USD"

                    Case "EUR"
                        Me.CurrencyTextBox.Text = "EUR"
                        Me.PriceTextBox.Text = _price / _cursUSDEUR
                End Select
            Case "EUR"
                Select Case Me.CurrencyTextBox.Text
                    Case "RUR"
                        Me.CurrencyTextBox.Text = "RUR"
                        Me.PriceTextBox.Text = _price * _cursEUR
                    Case "USD"
                        Me.CurrencyTextBox.Text = "USD"
                        Me.PriceTextBox.Text = _price * _cursUSDEUR
                    Case "EUR"

                End Select
        End Select
    End Sub

    Private Sub btRefresh_Click(sender As Object, e As EventArgs) Handles btRefresh.Click
        btRefresh.Enabled = False
        CType(Me.ClsSampleListBindingSource.Current, clsSampleListItem).Refresh()
        Me.ClsSampleListBindingSource.ResetBindings(False)
        btRefresh.Enabled = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Button1.Enabled = False
        Dim i = 0
        For Each t As clsSampleListItem In Me.ClsSampleListBindingSource.DataSource
            t.Refresh()
            Button1.Text = i
            i += 1
        Next
        Me.ClsSampleListBindingSource.ResetBindings(False)
        Button1.Text = "обновить все"
        Button1.Enabled = True
        Me.SaveParameter()
    End Sub
End Class