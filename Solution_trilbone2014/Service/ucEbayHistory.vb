Imports System.Linq
Imports eBayFinding
Imports System.Windows.Forms
Public Class ucEbayHistory
    Private oWordList As List(Of String)
    Private oFullSource As List(Of clseBayHistoryItem)
    Private oCurrentSource As List(Of clseBayHistoryItem)
    Private oSplashScreen As Windows.Forms.Form = clsApplicationTypes.SplashScreen
    Private oReadySampleDBContext As DBREADYSAMPLEEntities
    Private Class clsInfoContainer
        Property minPrice As Decimal

        Property maxPrice As Decimal

        Property Currency As String

        Property word As String

        Property count As Integer

        ReadOnly Property wordString As String
            Get
                Select Case count
                    Case 0
                        Return String.Format("{0} [{1}]", word, count, Currency, minPrice, maxPrice)
                    Case 1
                        Return String.Format("{0} [{1}] {3}{2}", word, count, Currency, minPrice.ToString("#"), maxPrice.ToString("#"))
                    Case Else
                        Return String.Format("{0} [{1}] {3}{2}-{4}{2}", word, count, Currency, minPrice.ToString("#"), maxPrice.ToString("#"))
                End Select

                ' Return String.Format("{0} [{1}] {3}{2}-{4}{2}", word, count, Currency, minPrice.ToString("N"), maxPrice)
            End Get
        End Property

        Property list As List(Of clseBayHistoryItem)
    End Class


    Private Sub init()
        If Not clsApplicationTypes.SampleDataObject Is Nothing AndAlso Not clsApplicationTypes.NetworkStatus = False Then
            oReadySampleDBContext = clsApplicationTypes.SampleDataObject.GetdbReadySampleObjectContext
        End If
    End Sub

    Private Sub btQuery_Click(sender As Object, e As EventArgs) Handles btQuery.Click
        Me.oSplashScreen.Show()
        Application.DoEvents()
        Me.DataGridView1.RowTemplate.Height = 100

        Dim _req = (From c In oReadySampleDBContext.GetEbayInfo(onlySold:=cbOnlySold.Checked, onlyUnSold:=cbOnlyUnsold.Checked) Select c.GetTrilbone).ToList

        oFullSource = clsFindingService.FilterBySellerCategory(_req)
      
        Me.oSplashScreen.Hide()
        Application.DoEvents()
        'списки
        'активные
        Dim _activerange = (From c In oFullSource Where c.IsEnded = False Group By c.Word Into gr = Count(), ss = Group, mp = Min(c.currentPrice), mxp = Max(c.currentPrice)
                   Select New clsInfoContainer With {.count = gr, .word = Word, .list = ss.ToList, .maxPrice = mxp, .minPrice = mp, .Currency = clsApplicationTypes.GetCurrencySymbol(ss.FirstOrDefault.currencyId)}).ToList
        oWordList = New List(Of String)
        oWordList.Add(String.Format("все фразы [{0}]", oFullSource.Count))
        oWordList.AddRange(_activerange.ConvertAll(Function(x) x.wordString))

        Me.lbPresent.DataSource = _activerange
        Me.lbPresent.DisplayMember = "wordString"
        '---не выставленные
        Dim _nopresentRange = (From c In oReadySampleDBContext.tbActualWord Where c.Tracking = True Select c.Word).ToList
        'исключим выставленные
        _nopresentRange = _nopresentRange.Except(_activerange.ConvertAll(Function(x) x.word)).ToList
        _nopresentRange.Sort()
        Me.lbNOTpresent.DataSource = _nopresentRange
        '----проданные
        Dim _soldRange = (From c In oFullSource Where c.IsSold = True Group By c.Word Into gr = Count(), ss = Group, mp = Min(c.currentPrice), mxp = Max(c.currentPrice)
                   Select New clsInfoContainer With {.count = gr, .word = Word, .list = ss.ToList, .maxPrice = mxp, .minPrice = mp, .Currency = clsApplicationTypes.GetCurrencySymbol(ss.FirstOrDefault.currencyId)}).ToList
        Me.lbSold.DataSource = _soldRange
        Me.lbSold.DisplayMember = "wordString"
        '----не проданные
        Dim _UNsoldRange = (From c In oFullSource Where c.IsSold = False And c.IsEnded = True Group By c.Word Into gr = Count(), ss = Group, mp = Min(c.currentPrice), mxp = Max(c.currentPrice)
                   Select New clsInfoContainer With {.count = gr, .word = Word, .list = ss.ToList, .maxPrice = mxp, .minPrice = mp, .Currency = clsApplicationTypes.GetCurrencySymbol(ss.FirstOrDefault.currencyId)}).ToList
        Me.lbNotSold.DataSource = _UNsoldRange
        Me.lbNotSold.DisplayMember = "wordString"

        Me.cbWords.DataSource = oWordList
        Me.cbWords.SelectedIndex = 0
    End Sub

    Private Sub cbWords_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbWords.SelectedIndexChanged
        If cbWords.SelectedIndex < 0 Then Return
        Me.DataGridView1.SuspendLayout()
        Select Case cbWords.SelectedIndex
            Case 0
                Me.ClseBayHistoryItemBindingSource.DataSource = oFullSource
            Case Else
                Dim _selected = cbWords.SelectedItem.ToString.Split("[").FirstOrDefault
                Me.oCurrentSource = (From c In oFullSource Where c.Word.Equals(_selected.Trim) Select c).ToList
                Me.ClseBayHistoryItemBindingSource.DataSource = oCurrentSource
        End Select
        Me.DataGridView1.ResumeLayout()
    End Sub

    Private Sub btLockSeller_Click(sender As Object, e As EventArgs) Handles btLockSeller.Click
        Dim _curr As eBayFinding.clseBayHistoryItem = Me.ClseBayHistoryItemBindingSource.Current
        If _curr Is Nothing Then Return
        Dim _new = tbNoiseSellerCategory.CreatetbNoiseSellerCategory(-1, _curr.WordID)
        _new.SellerID = _curr.seller.Trim
        _new.CategoryID = ""
        oReadySampleDBContext.tbNoiseSellerCategory.AddObject(_new)
        If oReadySampleDBContext.SaveChanges > 0 Then
            clsApplicationTypes.BeepYES()
        End If
    End Sub

    Private Sub btLockCategory_Click(sender As Object, e As EventArgs) Handles btLockCategory.Click
        Dim _curr As eBayFinding.clseBayHistoryItem = Me.ClseBayHistoryItemBindingSource.Current
        If _curr Is Nothing Then Return
        Dim _new = tbNoiseSellerCategory.CreatetbNoiseSellerCategory(-1, _curr.wordID)
        _new.CategoryID = _curr.primaryCategory.Trim
        _new.SellerID = ""

        oReadySampleDBContext.tbNoiseSellerCategory.AddObject(_new)
        If oReadySampleDBContext.SaveChanges > 0 Then
            clsApplicationTypes.BeepYES()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.oFullSource = clsFindingService.FilterBySellerCategory(oFullSource)
        If Me.cbWords.SelectedIndex = 0 Then
            'прямо вызовем
            Me.cbWords_SelectedIndexChanged(Me.cbWords, EventArgs.Empty)
        Else
            Me.cbWords.SelectedIndex = 0
        End If
    End Sub


    Private Sub DataGridView1_CellContentDoubleClick(sender As Object, e As Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentDoubleClick
        Dim _curr As eBayFinding.clseBayHistoryItem = Me.ClseBayHistoryItemBindingSource.Current
        If _curr Is Nothing Then Return
        System.Diagnostics.Process.Start(_curr.viewItemURL)
    End Sub

    Private Sub lbNotSold_MouseClick(sender As Object, e As MouseEventArgs) Handles lbNotSold.MouseClick, lbSold.MouseClick, lbPresent.MouseClick

        If e.Button = Windows.Forms.MouseButtons.Right Then
            If sender.ContextMenuStrip Is Nothing Then Return
            sender.ContextMenuStrip.Show()
        End If
    End Sub

   
 
    Private Sub lbSold_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbSold.SelectedIndexChanged, lbNotSold.SelectedIndexChanged, lbPresent.SelectedIndexChanged
        Dim _selected As clsInfoContainer = sender.SelectedItem
        If _selected Is Nothing Then Return
        Me.ContextMenuStrip1.Items.Clear()
        For Each t In _selected.list
            Me.ContextMenuStrip1.Items.Add(t.GetMenuItem)
        Next
       
        sender.ContextMenuStrip = Me.ContextMenuStrip1

    End Sub

    Public Sub New()

        ' Этот вызов является обязательным для конструктора.
        InitializeComponent()

        ' Добавьте все инициализирующие действия после вызова InitializeComponent().
        init()
    End Sub

End Class
