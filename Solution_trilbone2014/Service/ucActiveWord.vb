Imports System.Linq
Public Class ucActiveWord
    Private _random As New Random
    Private oReadySampleDBContext As DBREADYSAMPLEEntities
    Public Sub init(sourcelist As String())
        oReadySampleDBContext = clsApplicationTypes.SampleDataObject.GetdbReadySampleObjectContext
        Dim _list = (From c In oReadySampleDBContext.tbActualWord Select c).ToList
        _list.Sort()
        Me.TbActualWordBindingSource.DataSource = _list
        Dim _exc = (From c In _list Select c.Word.ToLower)

        Dim _bs = (From c In sourcelist Select clsApplicationTypes.RejectSkobki(c).ToLower)

        Dim _res = _bs.Except(_exc).Distinct.ToList
        _res.Sort()
        Me.BindingSourceSourceWords.DataSource = _res
    End Sub

    Private Sub btAdd_Click(sender As Object, e As EventArgs) Handles btAdd.Click
        If Me.lbSourceWords.SelectedIndex < 0 Then Return

        Dim _word As String = Me.lbSourceWords.SelectedItem

        Dim _res = (From c In CType(Me.TbActualWordBindingSource.DataSource, List(Of tbActualWord)) Where c.Word.ToLower.StartsWith(_word)).Count

        If _res > 0 Then
            clsApplicationTypes.BeepNOT()
            Return
        End If

        Dim _new = tbActualWord.CreatetbActualWord(_random.Next(64500), _word, True, False)
        oReadySampleDBContext.tbActualWord.AddObject(_new)
        CType(Me.TbActualWordBindingSource.DataSource, List(Of tbActualWord)).Add(_new)

        CType(Me.BindingSourceSourceWords.DataSource, List(Of String)).Remove(_word)
        Me.TbActualWordBindingSource.ResetBindings(False)
        Me.BindingSourceSourceWords.ResetBindings(False)
        Me.lbDbWords.SelectedItem = _new
        clsApplicationTypes.BeepYES()
        Me.lbSourceWords.Focus()
    End Sub

    Private Sub btRemove_Click(sender As Object, e As EventArgs) Handles btRemove.Click
        If Me.TbActualWordBindingSource.Current Is Nothing Then Return
        Dim _item As tbActualWord = Me.TbActualWordBindingSource.Current
        CType(Me.TbActualWordBindingSource.DataSource, List(Of tbActualWord)).Remove(_item)
        oReadySampleDBContext.tbActualWord.DeleteObject(_item)
        CType(Me.BindingSourceSourceWords.DataSource, List(Of String)).Add(_item.Word)

        Me.TbActualWordBindingSource.ResetBindings(False)
        Me.BindingSourceSourceWords.ResetBindings(False)
        clsApplicationTypes.BeepYES()
    End Sub

    Private Sub btSave_Click(sender As Object, e As EventArgs) Handles btSave.Click
        If oReadySampleDBContext.SaveChanges() > 0 Then
            clsApplicationTypes.BeepYES()
            Me.TbActualWordBindingSource.DataSource = (From c In oReadySampleDBContext.tbActualWord Select c).ToList
        Else
            clsApplicationTypes.BeepNOT()
        End If
    End Sub

    Private Sub btCancel_Click(sender As Object, e As EventArgs) Handles btCancel.Click
        oReadySampleDBContext.Refresh(Objects.RefreshMode.StoreWins, oReadySampleDBContext.tbActualWord)
        Me.TbActualWordBindingSource.DataSource = (From c In oReadySampleDBContext.tbActualWord Select c).ToList
        clsApplicationTypes.BeepYES()
    End Sub

    Private Sub TbActualWordBindingSource_CurrentChanged(sender As Object, e As EventArgs) Handles TbActualWordBindingSource.CurrentChanged
        'ищем такойже
        Dim _list As List(Of tbActualWord) = TbActualWordBindingSource.DataSource
        Dim _item As tbActualWord = TbActualWordBindingSource.Current
        If (From c In _list Where c.Equals(_item)).Count > 1 Then
            'уже есть убрать повтор
            TbActualWordBindingSource.DataSource = _list.Distinct
            clsApplicationTypes.BeepNOT()
        End If
    End Sub

    Private Sub TbActualWordBindingSource_CurrentItemChanged(sender As Object, e As EventArgs) Handles TbActualWordBindingSource.CurrentItemChanged
        Me.Label1.Text = Me.TbActualWordBindingSource.DataSource.count
    End Sub

    Private Sub tbCurrentWord_TextChanged(sender As Object, e As EventArgs) Handles tbCurrentWord.TextChanged

    End Sub
End Class
