Imports System.ComponentModel
Imports System.Windows.Forms
Imports Service
Imports System.Linq
Public Class uc_oldMC
    Dim oSplashScreen As Form = clsApplicationTypes.SplashScreen
    Private WithEvents oCurrentList As List(Of oldGoodMap_Result)
    Public Event SampleNumberChanged(sender As Object, e As SampleNumberChangedEventArgs)

    Public Class SampleNumberChangedEventArgs
        Inherits EventArgs
        Public Property SampleNumber As clsApplicationTypes.clsSampleNumber
    End Class


    Public Sub New()

        ' Этот вызов является обязательным для конструктора.
        InitializeComponent()

        ' Добав   ить код инициализации после вызова InitializeComponent().
        ' Me.dgv_OldGoodMap.DataSource = oCurrentBindingList
        oCurrentList = New List(Of oldGoodMap_Result)
        OldGoodMap_ResultBindingSource.DataSource = oCurrentList
    End Sub

#Region "Public Properties"
    ''' <summary>
    ''' строки для формирования каталога
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property RowList As List(Of oldGoodMap_Result)
        Get
            Dim _out = (From c As DataGridViewRow In Me.dgv_OldGoodMap.Rows Select CType(c.DataBoundItem, oldGoodMap_Result)).ToList
            Return _out
            '  Return Me.dgv_OldGoodMap.Rows
        End Get
    End Property

#End Region
#Region "Inner functions"
    ''' <summary>
    ''' загрузка и подгрузка из буфера реализация
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetFromBuffer() As List(Of Service.oldGoodMap_Result)
        Dim _list As New List(Of Service.oldGoodMap_Result)
        'get from buffer
        If Not My.Computer.Clipboard.ContainsText Then
            MsgBox("В буфере обмена нет текста!", vbIgnore)
            Return _list
        End If

        'и убирает повторяющиеся номера
        Dim _buff = clsApplicationTypes.ParseNumberList(My.Computer.Clipboard.GetText()).Distinct

        If _buff.Count = 0 Then
            MsgBox("Не удалось распознать ни одного номера из буфера!", vbIgnore)
            Return _list
        End If

        Me.oSplashScreen.Show()

        For Each t In _buff
            Dim _rs = clsApplicationTypes.SampleDataObject.GetMcOld_result(t.ShotCode, "", "")
            If Not _rs Is Nothing Then
                _list.AddRange(_rs)
            End If
        Next

        Me.oSplashScreen.Hide()
        Return _list
    End Function

    ''' <summary>
    ''' показать увеличенное изображение
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ShowImageForm(SampleNumer As String)
        Dim _sm = clsApplicationTypes.clsSampleNumber.CreateFromString(SampleNumer)
        If _sm Is Nothing OrElse _sm.CodeIsCorrect = False Then Return
        Dim _source = clsFilesSources.CreateInstance(Service.clsFilesSources.emSources.Arhive)
        Dim _prm As Object = Service.clsApplicationTypes.SamplePhotoObject.GetImageCollection(_sm, _source, False)

        'show image form
        'использование сервисов
        'по запросу выполняем вызов из сервиса

        Dim _param As Object = {_prm, [Enum].GetName(GetType(clsFilesSources.emSources), _source.Source)}
        'переделать на параметр, который берет обьект

        'если делегата нет, то сервис недоступен
        If Not Global.Service.clsApplicationTypes.DelegateStoreApplicationForm(Service.clsApplicationTypes.emFormsList.fmImage) Is Nothing Then
            'сервис зарегестрирован - вызываем
            Dim _fm = Global.Service.clsApplicationTypes.DelegateStoreApplicationForm(Service.clsApplicationTypes.emFormsList.fmImage).Invoke(_param)
            If Not _fm Is Nothing Then
                'show form
                With _fm
                    .Width = 640
                    .Height = 480
                    '.Name = "ImageShowForm"
                    .StartPosition = FormStartPosition.CenterScreen
                    ''привязка обработчика

                    'Service.clsApplicationTypes.DelegatStorefmImageDeleteDelegate = New Service.clsApplicationTypes.fmImageDeleteDelegat(AddressOf DelImage_eventHandler)
                    'Service.clsApplicationTypes.DelegatStorefmImageCopyDelegate = New Service.clsApplicationTypes.fmImageCopyDelegat(AddressOf CopyImage_eventHandler)
                    .ShowDialog()
                    ' Me.ShowPhotos(Me.oSampleNumber)
                End With

            End If
        Else

        End If


    End Sub
    ''' <summary>
    ''' включить работу кнопок по Enter
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tb_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbNamePart.KeyPress, tbCodePartSearch.KeyPress, tbGroupName.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Me.btQuery_Click(sender, e)
        End If
    End Sub

#End Region

#Region "grid and data works"
    ''' <summary>
    ''' раскрасить ячейки
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgv_OldGoodMap_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgv_OldGoodMap.CellFormatting
        If e.Value Is Nothing Then Return
        Select Case e.ColumnIndex
            Case 2, 3
                If String.IsNullOrEmpty(CType(e.Value, String).Trim) Then
                    e.CellStyle.BackColor = Drawing.Color.LightGray
                End If
            Case 6, 8, 10, 12, 14
                Dim _vv = dgv_OldGoodMap.Rows(e.RowIndex).Cells(e.ColumnIndex - 1)
                Select Case CType(e.Value, String).Trim
                    Case "EUR"
                        e.CellStyle.ForeColor = Drawing.Color.White
                        e.CellStyle.BackColor = Drawing.Color.LightCoral
                        _vv.Style.BackColor = Drawing.Color.LightCoral
                        _vv.Style.ForeColor = Drawing.Color.White
                        _vv.ToolTipText = clsApplicationTypes.CurrencyConvert(_vv.Value, e.Value, "RUR", 0).ToString & " RUR"
                        _vv.Style.Alignment = DataGridViewContentAlignment.MiddleRight
                    Case "USD"
                        e.CellStyle.ForeColor = Drawing.Color.White
                        e.CellStyle.BackColor = Drawing.Color.LightGreen
                        _vv.Style.BackColor = Drawing.Color.LightGreen
                        _vv.Style.ForeColor = Drawing.Color.White
                        _vv.ToolTipText = clsApplicationTypes.CurrencyConvert(_vv.Value, e.Value, "RUR", 0).ToString & " RUR"
                        _vv.Style.Alignment = DataGridViewContentAlignment.MiddleRight
                    Case "RUR"
                        e.CellStyle.ForeColor = Control.DefaultForeColor
                        e.CellStyle.BackColor = Control.DefaultBackColor
                        _vv.Style.ForeColor = Control.DefaultForeColor
                        _vv.Style.BackColor = Control.DefaultBackColor
                        _vv.ToolTipText = clsApplicationTypes.CurrencyConvert(_vv.Value, e.Value, "EUR", 0).ToString & " EUR" & ChrW(13) & clsApplicationTypes.CurrencyConvert(_vv.Value, e.Value, "USD", 0).ToString & " USD"

                        If Not String.IsNullOrEmpty(CType(_vv.Value, String)) Then
                            _vv.Style.Alignment = DataGridViewContentAlignment.MiddleRight
                        End If

                    Case Else
                        e.CellStyle.ForeColor = Control.DefaultForeColor
                        e.CellStyle.BackColor = Control.DefaultBackColor
                        _vv.Style.ForeColor = Control.DefaultForeColor
                        _vv.Style.BackColor = Control.DefaultBackColor
                        _vv.ToolTipText = ""
                        If Not String.IsNullOrEmpty(CType(_vv.Value, String)) Then
                            _vv.Style.Alignment = DataGridViewContentAlignment.MiddleRight
                        End If
                End Select
                If e.ColumnIndex >= 8 Then
                    'подсчет концов
                    Dim _zakup = clsApplicationTypes.CurrencyConvert(IIf(String.IsNullOrEmpty(dgv_OldGoodMap.Rows(e.RowIndex).Cells(5).Value), 0, dgv_OldGoodMap.Rows(e.RowIndex).Cells(5).Value), dgv_OldGoodMap.Rows(e.RowIndex).Cells(6).Value, "RUR")
                    Dim _price = clsApplicationTypes.CurrencyConvert(IIf(String.IsNullOrEmpty(_vv.Value), 0, _vv.Value), e.Value, "RUR")
                    If _zakup > 0 And _price > 0 Then
                        If Not String.IsNullOrEmpty(_vv.ToolTipText) Then
                            _vv.ToolTipText += ChrW(13)
                        End If

                        Dim _konc = Math.Round(_price / _zakup, 1)

                        _vv.ToolTipText += "концы: " & _konc.ToString
                    End If
                End If
                'округление значений цен
                _vv.Style.Format = "#.##"


        End Select
    End Sub
    ''' <summary>
    ''' добавить новую строку в биндинг
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub OldGoodMap_ResultBindingSource_AddingNew(sender As Object, e As AddingNewEventArgs) Handles OldGoodMap_ResultBindingSource.AddingNew
        ' инициализатор пустых значений полей для Datagridview/ при изменении запроса добавить новые поля!!!
        e.NewObject = oldGoodMap_Result.CreateInstance
    End Sub
    Private Sub OldGoodMap_ResultBindingSource_ListChanged(sender As Object, e As ListChangedEventArgs) Handles OldGoodMap_ResultBindingSource.ListChanged
        Me.lbRecordCount.Text = "Записей: " & OldGoodMap_ResultBindingSource.Count
    End Sub
    ''' <summary>
    ''' получение фокуса ячейкой
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgv_OldGoodMap_RowEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_OldGoodMap.RowEnter
        Dim e1 As oldGoodMap_Result = Me.dgv_OldGoodMap.Rows(e.RowIndex).DataBoundItem
        If e1 Is Nothing Then Return
        Dim _currNum As String = IIf(e1.Артикул Is Nothing OrElse String.IsNullOrEmpty(e1.Артикул), e1.Код, e1.Артикул)
        Dim _sm = clsApplicationTypes.clsSampleNumber.CreateFromString(_currNum)
        RaiseEvent SampleNumberChanged(Me, New SampleNumberChangedEventArgs With {.SampleNumber = _sm})
    End Sub
    Private Sub dgv_OldGoodMap_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_OldGoodMap.CellDoubleClick
        If Not (e.ColumnIndex > -1 AndAlso e.RowIndex > -1) Then Return
        Dim e1 As oldGoodMap_Result = Me.dgv_OldGoodMap.Rows(e.RowIndex).DataBoundItem
        If e1 Is Nothing Then Return
        Dim _currNum As String = IIf(e1.Артикул Is Nothing OrElse String.IsNullOrEmpty(e1.Артикул), e1.Код, e1.Артикул)
        Select Case e.ColumnIndex
            Case 0
                Call Me.ShowImageForm(_currNum)
                'TODO в классе данных сделаны доп.поля - обновить источник данных и добавить столбец с фото
                '=======
            Case 2, 3
                ''инфо по номеру
                clsApplicationTypes.ExternalLoadSample(_currNum)
        End Select
    End Sub
    ''' <summary>
    ''' новая строка в датагриде
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgv_OldGoodMap_DefaultValuesNeeded(sender As Object, e As DataGridViewRowEventArgs) Handles dgv_OldGoodMap.DefaultValuesNeeded


    End Sub

    Private Sub dgv_OldGoodMap_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgv_OldGoodMap.DataError

    End Sub


    Private Sub dgv_OldGoodMap_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgv_OldGoodMap.CellMouseClick
        If Not e.Button = Windows.Forms.MouseButtons.Right Then Exit Sub
        If e.ColumnIndex = 1 Then
            'названия
            'Dim _result = clsApplicationTypes.MyTreesSystematicaNames
            'Me.ContextMenuStrip1.Items.Clear()
            'If _result.Count > 0 Then
            '    Me.ContextMenuStrip1.Items.AddRange()
            '    Me.ContextMenuStrip1.Show(dgv_OldGoodMap.PointToScreen(e.Location))
            'End If
        End If
    End Sub

#End Region

#Region "button works"
    Private Sub btQuery_Click(sender As Object, e As EventArgs) Handles btQuery.Click
        oCurrentList = clsApplicationTypes.SampleDataObject.GetMcOld_result(Me.tbCodePartSearch.Text.Trim, Me.tbNamePart.Text.Trim, Me.tbGroupName.Text.Trim)
        OldGoodMap_ResultBindingSource.DataSource = Nothing
        OldGoodMap_ResultBindingSource.DataSource = oCurrentList
        clsApplicationTypes.BeepYES()
    End Sub

    Private Sub btClearParam_Click(sender As Object, e As EventArgs) Handles btClearParam.Click
        Me.tbGroupName.Text = ""
        Me.tbNamePart.Text = ""
        Me.tbCodePartSearch.Text = ""
    End Sub

    Private Sub btSortByName_Click(sender As Object, e As EventArgs) Handles btSortByName.Click
        Dim _lst As List(Of Service.oldGoodMap_Result) = OldGoodMap_ResultBindingSource.DataSource
        _lst.Sort(Function(x, y) (x.Наименование.CompareTo(y.Наименование)))
        dgv_OldGoodMap.Refresh()
    End Sub
    Private Sub btSortByGroup_Click(sender As Object, e As EventArgs) Handles btSortByGroup.Click
        Dim _lst As List(Of Service.oldGoodMap_Result) = OldGoodMap_ResultBindingSource.DataSource
        _lst.Sort(Function(x, y) (x.Группы.CompareTo(y.Группы)))
        dgv_OldGoodMap.Refresh()
    End Sub
    Private Sub btNameFilter_Click(sender As Object, e As EventArgs) Handles btNameFilter.Click
        If Not String.IsNullOrEmpty(Me.tbFiltered.Text) Then

            Dim _lst As New List(Of Service.oldGoodMap_Result)
            _lst.AddRange(OldGoodMap_ResultBindingSource.DataSource)
            If _lst.Count = 0 Then _lst.AddRange(oCurrentList)

            Dim _list = (From c In _lst Where ((Not String.IsNullOrEmpty(c.Наименование)) AndAlso c.Наименование.ToLower.Contains(Me.tbFiltered.Text.Trim.ToLower))).ToList
            '!!! 
            OldGoodMap_ResultBindingSource.DataSource = _list
            clsApplicationTypes.BeepYES()
        Else
            OldGoodMap_ResultBindingSource.DataSource = oCurrentList
        End If

    End Sub
    Private Sub btCodeFilter_Click(sender As Object, e As EventArgs) Handles btCodeFilter.Click
        If Not String.IsNullOrEmpty(Me.tbCodePartFilter.Text) Then

            Dim _lst As New List(Of Service.oldGoodMap_Result)
            _lst.AddRange(OldGoodMap_ResultBindingSource.DataSource)
            If _lst.Count = 0 Then _lst.AddRange(oCurrentList)

            Dim _list = (From c In _lst Where ((Not String.IsNullOrEmpty(c.ActualCode)) AndAlso c.ActualCode.ToLower.Contains(Me.tbCodePartFilter.Text.Trim.ToLower))).ToList
            '!!! 
            OldGoodMap_ResultBindingSource.DataSource = _list
            clsApplicationTypes.BeepYES()
        Else
            OldGoodMap_ResultBindingSource.DataSource = oCurrentList
        End If
    End Sub
    Private Sub btCancelFilter_Click(sender As Object, e As EventArgs) Handles btCancelFilter.Click
        OldGoodMap_ResultBindingSource.DataSource = oCurrentList
    End Sub
    Private Sub btSortByNumber_Click(sender As Object, e As EventArgs) Handles btSortByNumber.Click
        Dim _lst As List(Of Service.oldGoodMap_Result) = OldGoodMap_ResultBindingSource.DataSource
        _lst.Sort(Function(x, y) (x.ActualCode.CompareTo(y.ActualCode)))
        dgv_OldGoodMap.Refresh()
    End Sub
    ''' <summary>
    ''' сохранение строки в датасете офлайн
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btUpdateRow_Click(sender As Object, e As EventArgs) Handles btUpdateRow.Click
        Dim _item As oldGoodMap_Result = Me.dgv_OldGoodMap.CurrentRow.DataBoundItem

        If Me.cbxOfflineOldMap.Checked Then
            Dim _res = clsApplicationTypes.SampleDataObject.SetMcOld_row(_item)
            If _res > 0 Then
                clsApplicationTypes.BeepYES()
            Else
                clsApplicationTypes.BeepNOT()
            End If
            'MsgBox(String.Format("Изменено {0} строк", _res))
        End If

    End Sub
    ''' <summary>
    ''' загрузка из буфера
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub bt_fromClip_Click(sender As Object, e As EventArgs) Handles bt_fromClip.Click
        oCurrentList.Clear()
        oCurrentList.AddRange(Me.GetFromBuffer)
        OldGoodMap_ResultBindingSource.DataSource = Nothing
        OldGoodMap_ResultBindingSource.DataSource = oCurrentList
        'Me.oCurrentBindingList.Clear()
        'For Each t In Me.GetFromBuffer
        '    Me.oCurrentBindingList.Add(t)
        'Next
    End Sub

    ''' <summary>
    ''' добавить к списку из буфера
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btAddToList_Click(sender As Object, e As EventArgs) Handles btAddToList.Click
        oCurrentList.AddRange(Me.GetFromBuffer)
        OldGoodMap_ResultBindingSource.DataSource = Nothing
        OldGoodMap_ResultBindingSource.DataSource = oCurrentList
    End Sub
    ''' <summary>
    ''' сохранение в БД - только офлайн
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btSaveToDb_Click(sender As Object, e As EventArgs) Handles btSaveToDb.Click
        If Me.cbxOfflineOldMap.Checked Then
            Dim _res = clsApplicationTypes.SampleDataObject.SaveMcOld_row
            If _res > 0 Then
                'отметить все текущие строки обновленными
                For Each t As oldGoodMap_Result In Me.OldGoodMap_ResultBindingSource
                    t.IsNew = False
                Next
                clsApplicationTypes.BeepYES()
            Else
                clsApplicationTypes.BeepNOT()
            End If
            'MsgBox(String.Format("Сохранены изменения в {0} строках", _res))
        End If

    End Sub

#End Region

#Region "textbox and other elements works"
    Private Sub tbCodePartFilter_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbCodePartFilter.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Me.btCodeFilter_Click(sender, e)
        End If
    End Sub

    Private Sub tbFiltered_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbFiltered.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Me.btNameFilter_Click(sender, e)
        End If
    End Sub
    ''' <summary>
    ''' офлайн режим
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cbxOfflineOldMap_CheckedChanged(sender As Object, e As EventArgs) Handles cbxOfflineOldMap.CheckedChanged
        If cbxOfflineOldMap.Checked = True Then
            Me.oSplashScreen.Show()
        End If
        clsApplicationTypes.SampleDataObject.MColdgoodmapOffLine = cbxOfflineOldMap.Checked
        oSplashScreen.Hide()
    End Sub

#End Region

End Class
