Imports System.Xml.Linq
Imports System.Windows.Forms

'Imports Service


Public Class fmEbaySearch
    Sub New()

        ' Этот вызов является обязательным для конструктора.
        InitializeComponent()

    End Sub

    Private Function CategoryXML() As XElement
        Dim _xe = <FIELD name="category" datatype="string" requered="true" agentIDDataType="integer">
                      <ITEM value="Not specifed" agentID="" order="0"></ITEM>
                      <ITEM value="Fossils > Arthropods > Trilobites" agentID="165707" order="0"></ITEM>
                      <ITEM value="Fossils > Arthropods > Crustaceans" agentID="165706" order="1"></ITEM>
                      <ITEM value="Fossils > Arthropods > Insects,Hexapods" agentID="3218" order="2"></ITEM>
                      <ITEM value="Fossils > Arthropods > Other" agentID="165708" order="3"></ITEM>
                      <ITEM value="Fossils > Echinoderms > Echinoids" agentID="122561" order="4"></ITEM>
                      <ITEM value="Fossils > Echinoderms > Crinoids" agentID="165717" order="5"></ITEM>
                      <ITEM value="Fossils > Echinoderms > Other" agentID="165718" order="6"></ITEM>
                      <ITEM value="Fossils > Molluscs > Ammonites" agentID="3217" order="7"></ITEM>
                      <ITEM value="Fossils > Molluscs > Bivalves" agentID="165711" order="8"></ITEM>
                      <ITEM value="Fossils > Molluscs > Gastropods" agentID="165712" order="9"></ITEM>
                      <ITEM value="Fossils > Molluscs > Nautiloids" agentID="165713" order="10"></ITEM>
                      <ITEM value="Fossils > Molluscs > Other" agentID="165714" order="11"></ITEM>
                      <ITEM value="Fossils > Vegetation > Other" agentID="165721" order="12"></ITEM>
                      <ITEM value="Fossils > Vegetation > Petrified Wood" agentID="165721" order="13"></ITEM>
                      <ITEM value="Fossils > Vegetation > Plants" agentID="165721" order="14"></ITEM>
                      <ITEM value="Fossils > Verberates > Other" agentID="165724" order="15"></ITEM>
                      <ITEM value="Fossils > Verberates > Amphibian_reptile_Dinosaur" agentID="15915" order="16"></ITEM>
                      <ITEM value="Fossils > Verberates > Birds" agentID="165723" order="17"></ITEM>
                      <ITEM value="Fossils > Verberates > Bony Fish" agentID="15916" order="18"></ITEM>
                      <ITEM value="Fossils > Verberates > Mammals" agentID="3216" order="19"></ITEM>
                      <ITEM value="Fossils > Verberates > Shark Teeth" agentID="15917" order="20"></ITEM>
                      <ITEM value="Fossils > Brachiopods" agentID="165709" order="21"></ITEM>
                      <ITEM value="Fossils > Coral" agentID="165715" order="22"></ITEM>
                      <ITEM value="Fossils > Other" agentID="3214" order="23"></ITEM>
                      <ITEM value="Fossils > Unknown" agentID="165725" order="24"></ITEM>
                      <ITEM value="Fossils > Tools_Supplies" agentID="165726" order="25"></ITEM>
                      <ITEM value="Fossils > Reproduction" agentID="155295" order="26"></ITEM>
                      <ITEM value="Crystals_mineral specimens > Other" agentID="3220" order="27"></ITEM>
                      <ITEM value="Crystals_mineral specimens > Crystals" agentID="3226" order="28"></ITEM>
                      <ITEM value="Crystals_mineral specimens > Decorator Pieces" agentID="3227" order="29"></ITEM>
                      <ITEM value="Crystals_mineral specimens > Dysplay Specimens" agentID="3225" order="30"></ITEM>
                      <ITEM value="Crystals_mineral specimens > Fluorescent Minerals" agentID="3223" order="31"></ITEM>
                      <ITEM value="Crystals_mineral specimens > Precious Metals" agentID="3229" order="32"></ITEM>
                      <ITEM value="Crystals_mineral specimens > Rare Specimens" agentID="3224" order="33"></ITEM>
                      <ITEM value="Rock_fossil_mineral > Other" agentID="415" order="34"></ITEM>
                      <ITEM value="Rock_fossil_mineral > Stone Carvings(резьба по камню)" agentID="12525" order="35"></ITEM>
                      <ITEM value="Rock_fossil_mineral > Publications" agentID="4259" order="36"></ITEM>
                      <ITEM value="Rock_fossil_mineral > Meteorites_tektites" agentID="3239" order="37"></ITEM>
                  </FIELD>


        Return _xe

    End Function

    Public Sub SetSearchFrase(value As String)
        tbCriteria.Text = value
    End Sub


    Private Sub fmEbaySearch_Load(sender As Object, e As EventArgs) Handles Me.Load

        Dim _res = (From c In CategoryXML...<ITEM> Select New With {.key = c.@agentID, .value = c.@value}).ToList

        cdCategory.DataSource = _res
        cdCategory.DisplayMember = "value"
        cdCategory.ValueMember = "key"
        cdCategory.SelectedIndex = 0
    End Sub

    Private oCurrentResult As List(Of eBayFindingServiceReference.SearchItem)


    Private Sub btQuery_Click(sender As Object, e As EventArgs) Handles btQuery.Click
        Me.lblCount.Text = "Word count: ?"
        Me.lbQueryCount.Text = "Count: ?"
        Me.tbCurrentWord.Text = ""
        Me.lbWorldSource.DataSource = Nothing
        Me.cbxRemoveNoiseWords.Checked = False
        ' Me.cbxShowPreview.Checked = False
        Application.DoEvents()

        If Me.tbCriteria.Text = "" And cdCategory.SelectedIndex < 1 Then
            MsgBox("Необходимо одно из условий!", vbCritical)
            Return
        End If

        oCurrentResult = clsFindingService.Find(Me.tbCriteria.Text, cdCategory.SelectedValue)
        'oCurrentResult.Sort()
        Application.DoEvents()
        Me.SearchItemBindingSource.DataSource = oCurrentResult
        Me.lbQueryCount.Text = "Count: " & oCurrentResult.Count
        Dim _w = clsFindingService.GetWords(Me.SearchItemBindingSource.DataSource)
        _w.Sort()
        Me.lbWorldSource.DataSource = _w
        Me.lblCount.Text = "Word count: " & _w.Count
        Me.lbBadWorld.Items.Clear()

        'Me.lbBadWorld.Items.AddRange((From c In clsApplicationTypes.SampleDataObject.GetdbReadySampleObjectContext.tbNoiseWord Select c.Word).ToArray)

        'Service.clsApplicationTypes.BeepYES()
    End Sub


    Private Sub btSingleItemQuery_Click(sender As Object, e As EventArgs) Handles btSingleItemQuery.Click
        If Me.tbItemID.Text = "" Then Return

        Dim _res = clsFindingService.GetSingleItem(Me.tbItemID.Text)
        Application.DoEvents()
        Me.SimpleItemTypeBindingSource.DataSource = _res
        If _res Is Nothing Then
            'Service.clsApplicationTypes.BeepNOT()
            Return
        End If
        'отображение описания лиситинга
        Me.rtbDescription.Text = _res.Description

        Me.tbctlMain.SelectedTab = Me.tpSingleItem
        ' Service.clsApplicationTypes.BeepYES()
        Me.WebBrowser1.ScriptErrorsSuppressed = True
        Me.WebBrowser1.Navigate(_res.ViewItemURLForNaturalSearch)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'исключить имеющиеся в БД
        'Dim mergeQueryA As IEnumerable(Of String) = From name In fileA
        '                 Let n = name.Split(New Char() {","})
        '                 Where n(0) = nameToSearch
        '                 Select name

        'Dim mergeQueryB = From name In fileB
        '                  Let n = name.Split(New Char() {","})
        '                  Where n(0) = nameToSearch
        '                  Select name
        'Dim mergeSortQuery = mergeQueryA.Union(mergeQueryB)


    End Sub

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





        Dim _res = (From c As eBayFindingServiceReference.SearchItem In oCurrentResult Where _obj.LinkedItemsID.Any(Function(x)
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

        Dim _res = From c As String In Me.lbSelectedWord.Items Where c.ToLower.Equals(Me.tbCurrentWord.Text.ToLower) Select c

        If _res.Count > 0 Then
            '  Service.clsApplicationTypes.BeepNOT()
            GoTo ex
        End If

        Me.lbSelectedWord.Items.Add(Me.tbCurrentWord.Text.ToLower)
ex:
        If Not Me.lbWorldSource.SelectedIndex >= Me.lbWorldSource.Items.Count - 1 Then
            Me.lbWorldSource.SelectedIndex += 1
        End If
    End Sub

    Private Sub btRemoveFromSelectted_Click(sender As Object, e As EventArgs) Handles btRemoveFromSelectted.Click
        Dim _index = Me.lbSelectedWord.SelectedIndex
        If Not _index < 0 Then
            Me.lbSelectedWord.Items.RemoveAt(_index)
        Else
            _index = Me.lbBadWorld.SelectedIndex
            If Not _index < 0 Then
                Me.lbBadWorld.Items.RemoveAt(_index)
            End If
        End If
    End Sub

    Private Sub btCopyToClipboard_Click(sender As Object, e As EventArgs) Handles btCopyToClipboard.Click
        My.Computer.Clipboard.SetText(Me.tbCurrentWord.Text)
        '  Service.clsApplicationTypes.BeepYES()
    End Sub

    Private Sub btToBadWord_Click(sender As Object, e As EventArgs) Handles btToBadWord.Click
        '        If Me.tbCurrentWord.Text = "" Then Return

        '        Dim _res = From c As String In Me.lbBadWorld.Items Where c.ToLower.Equals(Me.tbCurrentWord.Text.ToLower) Select c

        '        If _res.Count > 0 Then
        '            Service.clsApplicationTypes.BeepNOT()
        '            GoTo ex
        '        End If

        '        Me.lbBadWorld.Items.Add(Me.tbCurrentWord.Text.ToLower)
        '        Service.clsApplicationTypes.BeepYES()
        'ex:
        '        If Not Me.lbWorldSource.SelectedIndex >= Me.lbWorldSource.Items.Count - 1 Then
        '            Me.lbWorldSource.SelectedIndex += 1
        '        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btSaveBadWorlds.Click

        'Dim _list As New List(Of String)
        '_list.AddRange(Me.lbBadWorld.Items.Cast(Of String).Select(Function(x)
        '                                                              Return x.ToLower()
        '                                                          End Function))
        'If _list.Count = 0 Then
        '    clsApplicationTypes.BeepNOT()
        '    Return
        'End If

        'Dim _context = clsApplicationTypes.SampleDataObject.GetdbReadySampleObjectContext

        'Dim _exists = (From c In _context.tbNoiseWord Select c.Word.ToLower).ToList



        'Dim _res = (_list.Except(_exists)).ToList



        'For i = 0 To _res.Count - 1
        '    _context.AddTotbNoiseWord(Service.tbNoiseWord.CreatetbNoiseWord(0, _res(i)))
        'Next

        'If clsApplicationTypes.SampleDataObject.SaveReadySampleContext() > 0 Then
        '    Me.lbBadWorld.Items.Clear()
        '    Me.lbBadWorld.Items.AddRange((From c In _context.tbNoiseWord Select c.Word).ToArray)
        '    Dim _w = clsFindingService.GetWords(oCurrentResult, Me.cbxRemoveNoiseWords.Checked)
        '    _w.Sort()
        '    Me.lbWorldSource.DataSource = _w
        '    Me.lblCount.Text = "Word count: " & _w.Count
        '    clsApplicationTypes.BeepYES()
        'End If



    End Sub



    Private Sub SearchItemBindingSource_CurrentItemChanged(sender As Object, e As EventArgs) Handles SearchItemBindingSource.CurrentItemChanged
        Dim _obj As eBayFindingServiceReference.SearchItem = SearchItemBindingSource.Current
        If _obj Is Nothing Then Return
        Me.PictureBox1.Load(_obj.galleryURL)

        Me.tbFullPrice.Text = GetStringPrice(_obj.sellingStatus.currentPrice, _obj.shippingInfo.shippingServiceCost)


        ' Application.DoEvents()

    End Sub

    Private oLastFiltered As List(Of eBayFindingServiceReference.SearchItem)

    Private Sub btFilter_Click(sender As Object, e As EventArgs) Handles btFilter.Click
        If oCurrentResult Is Nothing OrElse oCurrentResult.Count = 0 Then Return
        If Me.tbCurrentWord.Text = "" Then Return
        oLastFiltered = Me.SearchItemBindingSource.DataSource
        'oLastFiltered.Sort()
        'apply filter
        Dim _res = (From c In oLastFiltered Where c.title.ToLower.Contains(Me.tbCurrentWord.Text.ToLower) Select c).ToList
        ' _res.Sort()
        Me.SearchItemBindingSource.DataSource = _res
        Me.lbQueryCount.Text = "Count: " & _res.Count
        Dim _w = clsFindingService.GetWords(_res, Me.cbxRemoveNoiseWords.Checked)
        _w.Sort()
        Me.lbWorldSource.DataSource = _w
        Me.lblCount.Text = "Word count: " & _w.Count
        ' Service.clsApplicationTypes.BeepYES()

    End Sub

    Private Sub btCancelFilter_Click(sender As Object, e As EventArgs) Handles btCancelFilter.Click
        Me.SearchItemBindingSource.DataSource = oLastFiltered
        Me.lbQueryCount.Text = "Count: " & oLastFiltered.Count
        Dim _w = clsFindingService.GetWords(oLastFiltered, Me.cbxRemoveNoiseWords.Checked)
        _w.Sort()
        Me.lbWorldSource.DataSource = _w
        Me.lblCount.Text = "Word count: " & _w.Count
        'oCurrentResult.Sort()
        oLastFiltered = oCurrentResult
        ' Service.clsApplicationTypes.BeepYES()
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

    Private Sub cbxRemoveNoiseWords_CheckedChanged(sender As Object, e As EventArgs) Handles cbxRemoveNoiseWords.CheckedChanged
        If cbxRemoveNoiseWords.Checked Then
            Dim _w = clsFindingService.GetWords(Me.SearchItemBindingSource.DataSource, True)
            _w.Sort()
            Me.lbWorldSource.DataSource = _w
            Me.lblCount.Text = "Word count: " & _w.Count
            '  Service.clsApplicationTypes.BeepYES()
        Else
            Dim _w = clsFindingService.GetWords(Me.SearchItemBindingSource.DataSource, False)
            _w.Sort()
            Me.lbWorldSource.DataSource = _w
            Me.lblCount.Text = "Word count: " & _w.Count
            ' Service.clsApplicationTypes.BeepYES()
        End If
    End Sub

    Private Sub lbBadWorld_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbBadWorld.SelectedIndexChanged
        If lbBadWorld.SelectedIndex >= 0 Then
            Me.tbCurrentWord.Text = lbBadWorld.SelectedItem.ToString
        End If

    End Sub

    Private Sub lbSelectedWord_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbSelectedWord.SelectedIndexChanged
        If lbSelectedWord.SelectedIndex >= 0 Then
            Me.tbCurrentWord.Text = lbSelectedWord.SelectedItem.ToString
        End If
    End Sub

    Private Sub SearchItemDataGridView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles SearchItemDataGridView.CellContentClick

    End Sub


    Private Sub SimpleItemTypeBindingSource_CurrentChanged(sender As Object, e As EventArgs) Handles SimpleItemTypeBindingSource.CurrentChanged

    End Sub

    Private Sub SearchItemBindingSource_CurrentChanged(sender As Object, e As EventArgs) Handles SearchItemBindingSource.CurrentChanged

    End Sub
End Class
