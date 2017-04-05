Imports System.Xml.Linq
Imports System.Linq
Imports eBayFinding
Imports System.Windows.Forms
Imports eBayFinding.eBayFindingServiceReference
Imports System.ComponentModel

Public Class UserControlEbaySearch
    Private oCurrentResult As List(Of clseBayHistoryItem)
    Private oSplashScreen = clsApplicationTypes.SplashScreen
    Private oLastFiltered As List(Of clseBayHistoryItem)
    Private oToRemoveWords As New List(Of String)
    Private oTrackingRemoveWords As New List(Of String)
    Private oReadySampleDBContext As DBREADYSAMPLEEntities
#Region "публичные методы"
    Public Property SearchName As String
        Get
            Return Me.tbCriteria.Text
        End Get
        Set(value As String)
            Me.tbCriteria.Text = value
        End Set
    End Property

#End Region

    Public Sub New()

        ' Этот вызов является обязательным для конструктора.
        InitializeComponent()

        ' Добавьте все инициализирующие действия после вызова InitializeComponent().
        init()
    End Sub

    Private Sub init()
        oReadySampleDBContext = clsApplicationTypes.SampleDataObject.GetdbReadySampleObjectContext

        If clsApplicationTypes.EbayInvoker.IsBusy Then
            Me.btRunEbay.Enabled = False
        End If
    End Sub

    Public Sub SetSearchFrase(value As String)
        tbCriteria.Text = value
    End Sub

    Private Sub fmEbaySearch_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'загрузка категорий
        cdCategory.DataSource = clsApplicationTypes.AuctionAgent.GetAgentByNameAccount("ebay", "trilbone").GetFIELD("category").ITEM
        cdCategory.DisplayMember = "value"
        cdCategory.ValueMember = "agentID"
        cdCategory.SelectedIndex = 0

        'шумовые слова
        Me.lbBadWorld.Items.Clear()
        Me.lbBadWorld.Items.AddRange((From c In oReadySampleDBContext.tbNoiseWord Select c.Word).ToArray)
        Me.lbBadWorld.Sorted = True

        'актуальные слова
        Me.lbActualWord.Items.Clear()
        Me.lbActualWord.Items.AddRange((From c In oReadySampleDBContext.tbActualWord Select c.Word).ToArray)
        Me.lbActualWord.Sorted = True

        'отслеживаемые слова
        Me.lbTrackingWord.Items.Clear()
        Me.lbTrackingWord.Items.AddRange((From c In oReadySampleDBContext.tbActualWord Where c.Tracking = True Select c.Word).ToArray)
        Me.lbTrackingWord.Sorted = True
        Me.label4.Text = String.Format("Отслеживать ({0})", Me.lbTrackingWord.Items.Count)
    End Sub

    ''' <summary>
    ''' запрос фразы
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btQuery_Click(sender As Object, e As EventArgs) Handles btQuery.Click
        Me.oSplashScreen.Show()
        Application.DoEvents()

        Me.lbQueryCount.Text = "Count: ?"
        Me.tbCurrentWord.Text = ""
        Me.lbWorldSource.DataSource = Nothing
        Me.cbxRemoveNoiseWords.Checked = False

        If Me.tbCriteria.Text = "" And cdCategory.SelectedIndex < 1 Then
            Me.oSplashScreen.Hide()
            MsgBox("Необходимо одно из условий!", vbCritical)
            Return
        End If

        oCurrentResult = clsFindingService.Find(Me.tbCriteria.Text, cdCategory.SelectedValue).ConvertAll(Function(x) x.GetTrilbone)
        Me.tbFirstWord.Text = Me.tbCriteria.Text
        Me.SearchItemBindingSource.DataSource = oCurrentResult
        Me.lbQueryCount.Text = "Count: " & oCurrentResult.Count

        GetWords()


        Me.oSplashScreen.Hide()
        Service.clsApplicationTypes.BeepYES()
    End Sub

    ''' <summary>
    ''' запрос итема
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btSingleItemQuery_Click(sender As Object, e As EventArgs) Handles btSingleItemQuery.Click
        If String.IsNullOrEmpty(Me.tbItemID.Text) Then Return
        If Me.tbItemID.Text = "" Then Return
        Me.oSplashScreen.Show()
        Dim _res = clsFindingService.GetSingleItem(Me.tbItemID.Text)
        '  Application.DoEvents()
        Me.SimpleItemTypeBindingSource.DataSource = _res.GetTrilbone
        If _res Is Nothing Then
            Service.clsApplicationTypes.BeepNOT()
            Me.oSplashScreen.Hide()
            Return
        End If
        'отображение описания лиситинга
        Me.rtbDescription.Text = _res.Description

        Me.tbctlMain.SelectedTab = Me.tpSingleItem
        Me.oSplashScreen.Hide()
        Service.clsApplicationTypes.BeepYES()
        Me.WebBrowser1.ScriptErrorsSuppressed = True

        Me.WebBrowser1.Navigate(_res.ViewItemURLForNaturalSearch)
    End Sub



    ''' <summary>
    ''' форматирует строку цены
    ''' </summary>
    ''' <param name="amount"></param>
    ''' <param name="shipping"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetStringPrice(amount As eBayFindingServiceReference.Amount, shipping As eBayFindingServiceReference.Amount) As String
        If amount Is Nothing Then Return ""
        Dim _value As Decimal = 0

        If Decimal.TryParse(amount.Value, _value) Then
            If Not shipping Is Nothing Then
                Dim _dval As Decimal
                If Decimal.TryParse(shipping.Value, _dval) Then
                    _value += _dval
                End If
            End If
        End If
        Return _value.ToString & " " & amount.currencyId.ToLower
    End Function


    Private Sub lbWorldSource_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbWorldSource.SelectedIndexChanged
        Dim _obj As clsWord = Me.lbWorldSource.SelectedItem
        If _obj Is Nothing Then Return
        Me.tbCurrentWord.Text = _obj.Word
        Dim _res = (From c As clseBayHistoryItem In oCurrentResult Where _obj.LinkedItemsID.Any(Function(x)
                                                                                                    If c.itemId.Equals(x) Then Return True
                                                                                                    Return False
                                                                                                End Function) Select c).ToList
        If _res.Count > 0 Then
            Dim _index = Me.SearchItemBindingSource.IndexOf(_res.First)
            If _index >= 0 AndAlso Me.SearchItemBindingSource.Count >= _index Then
                Me.SearchItemBindingSource.Position = _index
            End If
        End If
    End Sub

    Private Sub btAddToSelected_Click(sender As Object, e As EventArgs) Handles btAddToSelected.Click
        If Me.tbCurrentWord.Text = "" Then Return

        Dim _word = (Me.tbFirstWord.Text.Trim & " " & Me.tbCurrentWord.Text.Trim).Trim.ToLower

        Dim _res = From c As String In Me.lbActualWord.Items Where c.ToLower.Equals(_word) Select c

        If _res.Count > 0 Then
            Service.clsApplicationTypes.BeepNOT()
            GoTo ex
        End If

        Me.lbActualWord.Items.Add(_word)
        Me.oToRemoveWords.Remove(_word)
ex:
        If Not Me.lbWorldSource.SelectedIndex >= Me.lbWorldSource.Items.Count - 1 Then
            Me.lbWorldSource.SelectedIndex += 1
        End If
    End Sub

    Private Sub btRemoveFromSelectted_Click(sender As Object, e As EventArgs) Handles btRemoveFromSelectted.Click, btRemove2.Click
        Dim _index = Me.lbActualWord.SelectedIndex
        If Not _index < 0 Then
            oToRemoveWords.Add(CType(Me.lbActualWord.Items(_index), String).ToLower)
            Me.lbActualWord.Items.RemoveAt(_index)
            'удалить из БД при синхронизации
        Else
            _index = Me.lbBadWorld.SelectedIndex
            If Not _index < 0 Then
                oToRemoveWords.Add(CType(Me.lbBadWorld.Items(_index), String).ToLower)
                Me.lbBadWorld.Items.RemoveAt(_index)
                'удалить из БД при синхронизации
            End If
        End If
        GetWords()
        Service.clsApplicationTypes.BeepYES()
    End Sub

    Private Sub btCopyToClipboard_Click(sender As Object, e As EventArgs) Handles btCopyToClipboard.Click
        '------------------
        Dim _data As String = Me.tbCurrentWord.Text
        Try
            My.Computer.Clipboard.Clear()
            My.Computer.Clipboard.SetText(_data)
        Catch ex As Exception
            MsgBox("Ошибка при помещении данных в буфер обмена.", vbCritical)
        End Try
        '-----------------
        Service.clsApplicationTypes.BeepYES()
    End Sub

    Private Sub btToBadWord_Click(sender As Object, e As EventArgs) Handles btToBadWord.Click
        If Me.tbCurrentWord.Text = "" Then Return
        Dim _res = From c As String In Me.lbBadWorld.Items Where c.ToLower.Equals(Me.tbCurrentWord.Text.ToLower) Select c
        If _res.Count > 0 Then
            Service.clsApplicationTypes.BeepNOT()
            GoTo ex
        End If
        Me.lbBadWorld.Items.Add(Me.tbCurrentWord.Text.ToLower)
        Me.oToRemoveWords.Remove(Me.tbCurrentWord.Text.ToLower)
        GetWords()
        Service.clsApplicationTypes.BeepYES()
ex:
        If Not Me.lbWorldSource.SelectedIndex >= Me.lbWorldSource.Items.Count - 1 Then
            Me.lbWorldSource.SelectedIndex += 1
        End If
    End Sub

    ''' <summary>
    ''' синхронизация с БД
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btSaveWorlds_Click(sender As Object, e As EventArgs) Handles btSaveWorlds.Click
        Dim _listBad As New List(Of String)
        Dim _listActual As New List(Of String)
        Dim _listTracking As New List(Of String)

        Dim _exists As List(Of String)

        Dim _res As List(Of String)

        _listBad.AddRange(Me.lbBadWorld.Items.Cast(Of String).Select(Function(x) x.ToLower()))
        _listActual.AddRange(Me.lbActualWord.Items.Cast(Of String).Select(Function(x) x.ToLower()))
        _listTracking.AddRange(Me.lbTrackingWord.Items.Cast(Of String).Select(Function(x) x.ToLower()))

        If _listBad.Count > 0 Then
            'плохие слова
            _exists = (From c In oReadySampleDBContext.tbNoiseWord Select c.Word.ToLower).ToList
            _res = (_listBad.Except(_exists)).ToList
            For i = 0 To _res.Count - 1
                oReadySampleDBContext.AddTotbNoiseWord(Service.tbNoiseWord.CreatetbNoiseWord(0, _res(i)))
            Next

            'удаление
            Dim _remove = (From c In oReadySampleDBContext.tbNoiseWord From d In Me.oToRemoveWords Where c.Word.ToLower.Equals(d) Select c).ToList
            For Each t In _remove
                oReadySampleDBContext.tbNoiseWord.DeleteObject(t)
            Next
        End If
        '======================
        If _listActual.Count > 0 Then
            'хорошие слова
            _exists = (From c In oReadySampleDBContext.tbActualWord Select c.Word.ToLower).ToList
            _res = (_listActual.Except(_exists)).ToList
            For i = 0 To _res.Count - 1
                oReadySampleDBContext.AddTotbActualWord(Service.tbActualWord.CreatetbActualWord(0, _res(i), False, False))
            Next

            'удаление
            Dim _remove = (From c In oReadySampleDBContext.tbActualWord From d In Me.oToRemoveWords Where c.Word.ToLower.Equals(d) Select c).ToList
            For Each t In _remove
                oReadySampleDBContext.tbActualWord.DeleteObject(t)
            Next
        End If
        '=====================
        If _listTracking.Count > 0 Then
            'отслеживаемые слова
            _exists = ((From c In oReadySampleDBContext.tbActualWord Where c.Tracking = True Select c.Word.ToLower)).ToList
            _res = (_listTracking.Except(_exists)).ToList
            For i = 0 To _res.Count - 1
                Dim j = _res(i)
                Dim _toChange = (From c In oReadySampleDBContext.tbActualWord Where c.Word.ToLower.Equals(j) Select c).FirstOrDefault
                If Not _toChange Is Nothing Then
                    _toChange.Tracking = True
                End If
            Next

            'удаление
            Dim _remove = (From c In oReadySampleDBContext.tbActualWord From d In Me.oTrackingRemoveWords Where c.Tracking = True And c.Word.ToLower.Equals(d) Select c).ToList
            For Each t In _remove
                t.Tracking = False
            Next
        End If
        '===================
        If clsApplicationTypes.SampleDataObject.SaveReadySampleContext() > 0 Then
            oTrackingRemoveWords.Clear()
            oToRemoveWords.Clear()

            Me.lbBadWorld.Items.Clear()
            Me.lbBadWorld.Items.AddRange((From c In oReadySampleDBContext.tbNoiseWord Select c.Word.ToLower).ToArray)

            Me.lbActualWord.Items.Clear()
            Me.lbActualWord.Items.AddRange((From c In oReadySampleDBContext.tbActualWord Select c.Word.ToLower).ToArray)

            Me.lbTrackingWord.Items.Clear()
            Me.lbTrackingWord.Items.AddRange((From c In oReadySampleDBContext.tbActualWord Where c.Tracking = True Select c.Word.ToLower).ToArray)

            GetWords()

            clsApplicationTypes.BeepYES()
        Else
            clsApplicationTypes.BeepNOT()
        End If
    End Sub



    Private Sub btFilter_Click(sender As Object, e As EventArgs) Handles btFilter.Click
        If oCurrentResult Is Nothing OrElse oCurrentResult.Count = 0 Then Return
        If Me.SearchItemBindingSource.DataSource Is Nothing Then Return
        If Me.tbCurrentWord.Text = "" Then Return
        oLastFiltered = Me.SearchItemBindingSource.DataSource
        'apply filter
        Dim _res = (From c In oLastFiltered Where c.title.ToLower.Contains(Me.tbCurrentWord.Text.ToLower) Select c).ToList
        ' _res.Sort()
        Me.SearchItemBindingSource.DataSource = _res
        Me.lbQueryCount.Text = "Count: " & _res.Count
        GetWords()
        Service.clsApplicationTypes.BeepYES()
    End Sub

    Private Sub btCancelFilter_Click(sender As Object, e As EventArgs) Handles btCancelFilter.Click
        If oLastFiltered Is Nothing Then
            Me.SearchItemBindingSource.DataSource = GetType(List(Of clseBayHistoryItem))
            Return
        End If

        Me.SearchItemBindingSource.DataSource = oLastFiltered
        Me.lbQueryCount.Text = "Count: " & oLastFiltered.Count
        GetWords()
        oLastFiltered = oCurrentResult
        Service.clsApplicationTypes.BeepYES()
    End Sub

    Private Sub btGetFromClipboard_Click(sender As Object, e As EventArgs) Handles btGetFromClipboard.Click
        Dim _value As String

        If My.Computer.Clipboard.ContainsText Then
            _value = My.Computer.Clipboard.GetText
            If _value.Length > 15 Then
                _value = _value.Substring(0, 15)
            End If
            Me.tbCriteria.Text = _value
        End If
    End Sub


    Private Sub GetWords()
        If Me.cbxRemoveNoiseWords.Checked Then
            Dim _w = clsFindingService.GetWords(Me.SearchItemBindingSource.DataSource, GetList(Me.lbBadWorld))
            _w.Sort()
            Me.lbWorldSource.DataSource = _w
        Else
            Dim _w = clsFindingService.GetWords(Me.SearchItemBindingSource.DataSource, Nothing)
            _w.Sort()
            Me.lbWorldSource.DataSource = _w
        End If
    End Sub


    Private Function GetList(lb As ListBox) As String()
        If lb.Items.Count = 0 Then Return {}
        Dim _out As New List(Of String)
        For Each t In lb.Items
            _out.Add(t.ToString.ToLower)
        Next
        Return _out.ToArray
    End Function

    Private Sub cbxRemoveNoiseWords_CheckedChanged(sender As Object, e As EventArgs) Handles cbxRemoveNoiseWords.CheckedChanged
        GetWords()
    End Sub

    Private Sub lbBadWorld_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbBadWorld.SelectedIndexChanged
        If lbBadWorld.SelectedItem Is Nothing Then Return
        If lbBadWorld.SelectedIndex >= 0 Then
            Me.tbCurrentWord.Text = lbBadWorld.SelectedItem.ToString
        End If
    End Sub

    Private Sub lbSelectedWord_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbActualWord.SelectedIndexChanged
        If lbActualWord.SelectedItem Is Nothing Then Return
        If lbActualWord.SelectedIndex >= 0 Then
            Dim _words = lbActualWord.SelectedItem.ToString.Split(" ").ToList
            If _words.Count > 1 Then
                Me.tbCurrentWord.Text = _words.Last
            Else
                Me.tbCurrentWord.Text = _words.FirstOrDefault
            End If
            If String.IsNullOrEmpty(Me.tbCriteria.Text) Then
                Me.tbCriteria.Text = lbActualWord.SelectedItem

            End If
        End If
    End Sub

    Private Sub SearchItemBindingSource_CurrentItemChanged(sender As Object, e As EventArgs) Handles SearchItemBindingSource.CurrentItemChanged
        If SearchItemBindingSource.Current Is Nothing Then Return
        Dim _obj As clseBayHistoryItem = SearchItemBindingSource.Current
        If _obj Is Nothing Then Return
        If Not _obj.galleryURL Is Nothing Then
            Me.PictureBox1.Load(_obj.galleryURL)
        Else
            Me.PictureBox1.Image = clsApplicationTypes.NoImage
        End If


        Me.tbFullPrice.Text = _obj.TotalPriceString
    End Sub

    Private Sub btTrackWord_Click(sender As Object, e As EventArgs) Handles btTrackWord.Click
        If Me.lbActualWord.SelectedItem Is Nothing Then Return

        Dim _res = From c As String In Me.lbTrackingWord.Items Where c.ToLower.Equals(Me.lbActualWord.SelectedItem) Select c

        If _res.Count > 0 Then
            Service.clsApplicationTypes.BeepNOT()
            GoTo ex
        End If

        Me.lbTrackingWord.Items.Add(Me.lbActualWord.SelectedItem)
        Me.oTrackingRemoveWords.Remove(Me.lbActualWord.SelectedItem)
        Me.label4.Text = String.Format("Отслеживать ({0})", Me.lbTrackingWord.Items.Count)
ex:
        If Not Me.lbWorldSource.SelectedIndex >= Me.lbWorldSource.Items.Count - 1 Then
            Me.lbWorldSource.SelectedIndex += 1
        End If
    End Sub

    ''' <summary>
    ''' удалить из отмлеживаемых
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btStopTracking_Click(sender As Object, e As EventArgs) Handles btStopTracking.Click
        Dim _index = Me.lbTrackingWord.SelectedIndex
        If _index < 0 Then clsApplicationTypes.BeepNOT() : Return
        oTrackingRemoveWords.Add(CType(Me.lbTrackingWord.Items(_index), String).ToLower)
        Me.lbTrackingWord.Items.RemoveAt(_index)
        Me.label4.Text = String.Format("Отслеживать ({0})", Me.lbTrackingWord.Items.Count)
        Service.clsApplicationTypes.BeepYES()
    End Sub

    Private Sub lbTrackingWord_DoubleClick(sender As Object, e As EventArgs) Handles lbTrackingWord.DoubleClick
        If lbTrackingWord.SelectedItem Is Nothing Then Return
        If lbTrackingWord.SelectedIndex >= 0 Then
             Me.tbCriteria.Text = lbTrackingWord.SelectedItem.ToString
        End If
    End Sub

    Private Sub lbTrackingWord_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbTrackingWord.SelectedIndexChanged
        If lbTrackingWord.SelectedItem Is Nothing Then Return
        If lbTrackingWord.SelectedIndex >= 0 Then
            If String.IsNullOrEmpty(Me.tbCriteria.Text) Then
                Me.tbCriteria.Text = lbTrackingWord.SelectedItem.ToString
            End If
        End If
    End Sub



    ''' <summary>
    ''' асинхронный запуск eBayTrackera
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btRunEbay_Click(sender As Object, e As EventArgs) Handles btRunEbay.Click

        If clsApplicationTypes.EbayInvoker.IsBusy Then
            MsgBox("Отслеживание eBay уже в работе.", vbInformation)
        Else
            clsApplicationTypes.EbayInvoker.RunWorkerAsync()
            MsgBox("Отслеживание eBay успешно запущено.", vbInformation)
        End If

        'If oEbayTrackWoker Is Nothing Then
        '    oEbayTrackWoker = New BackgroundWorker
        '    AddHandler oEbayTrackWoker.DoWork, AddressOf backgroundWorkerEbay_DoWork
        '    AddHandler oEbayTrackWoker.RunWorkerCompleted, AddressOf backgroundWorkereBAy_RunWorkerCompleted
        '    oEbayTrackWoker.RunWorkerAsync()
        '    MsgBox("Отслеживание eBay успешно запущено.", vbInformation)
        'Else
        '    If oEbayTrackWoker.IsBusy Then
        '        MsgBox("Отслеживание eBay уже в работе.", vbInformation)
        '    Else
        '        MsgBox("Сеанс отслеживания eBay завершен.", vbInformation)
        '    End If
        'End If
    End Sub

    '    Private Shared Sub backgroundWorkerEbay_DoWork(ByVal sender As System.Object, _
    ' ByVal e As DoWorkEventArgs)
    '#If DEBUG Then
    '        e.Result = clsFindingService.WordsProceessing(True)
    '#Else
    ' Try
    '            e.Result = clsFindingService.WordsProceessing()
    '        Catch ex As Exception
    '            'проблемы с подключением


    '        End Try
    '#End If


    '    End Sub

    '    Private Shared Sub backgroundWorkereBAy_RunWorkerCompleted(ByVal sender As System.Object, _
    '    ByVal e As RunWorkerCompletedEventArgs)
    '        If e.Error Is Nothing Then
    '            If e.Result > 0 Then
    '                clsApplicationTypes.BeepYES()
    '            End If
    '        Else
    '            clsApplicationTypes.BeepNOT()
    '#If DEBUG Then
    '            MsgBox("Возникла ошибка при запросе eBAY", vbInformation)
    '#End If
    '        End If
    '    End Sub

End Class
