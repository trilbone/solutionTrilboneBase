Imports Service
Imports System.Linq
Imports System.ComponentModel

Public Class fmDbInfo1
    Private WithEvents oCurrentBindingList As New System.ComponentModel.BindingList(Of FindByWeight_Result)
    Private oCurrentItem As Object
    Dim oSplashScreen As Form = clsApplicationTypes.SplashScreen

    Private Sub fmDbInfo1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim _namesList = clsApplicationTypes.SampleDataObject.GetAllNamesList

        Me.lbNamesList.DataSource = _namesList
        Me.lbNamesList.DisplayMember = "fossil"
        Dim _f = (From c In _namesList Where c.count > 0 And (Not String.IsNullOrWhiteSpace(c.fossil)) Select CType(c.fossil, String)).ToArray
        Me.UcActiveWord1.init(_f)
        Me.dgv_SampleWeightResult.DataSource = oCurrentBindingList
    End Sub

    Private Sub oCurrentBindingList_ListChanged(sender As Object, e As ListChangedEventArgs) Handles oCurrentBindingList.ListChanged
        Me.lblWeightCount.Text = "записей: " & oCurrentBindingList.Count
    End Sub

    Private Sub dgv_SampleResultByName_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgv_SampleResultByName.CellMouseDoubleClick

    End Sub


    ''' <summary>
    ''' установка текущей строки
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub dgv_SampleResultByName_RowEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_SampleResultByName.RowEnter, dgv_SampleWeightResult.RowEnter

        oCurrentItem = sender.Rows(e.RowIndex).DataBoundItem
        If oCurrentItem Is Nothing Then Return
        Me.lbSampleNumber.Text = oCurrentItem.SampleNumberObj.ShotCode
    End Sub

    Private Sub Uc_oldMC1_SampleNumberChanged(sender As Object, e As uc_oldMC.SampleNumberChangedEventArgs) Handles Uc_oldMC1.SampleNumberChanged
        If Not e.SampleNumber Is Nothing Then
            Me.lbSampleNumber.Text = e.SampleNumber.ShotCode
        End If

    End Sub


    ''' <summary>
    ''' показать увеличенное изображение
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ShowImageForm()
        If oCurrentItem Is Nothing Then Return
        Dim _source = clsFilesSources.CreateInstance(Service.clsFilesSources.emSources.Arhive)
        Dim _prm As Object = Service.clsApplicationTypes.SamplePhotoObject.GetImageCollection(oCurrentItem.SampleNumberObj, _source, False)

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
                    'привязка обработчика

                    Service.clsApplicationTypes.DelegatStorefmImageDeleteDelegate = New Service.clsApplicationTypes.fmImageDeleteDelegat(AddressOf DelImage_eventHandler)
                    Service.clsApplicationTypes.DelegatStorefmImageCopyDelegate = New Service.clsApplicationTypes.fmImageCopyDelegat(AddressOf CopyImage_eventHandler)
                    .ShowDialog()
                    ' Me.ShowPhotos(Me.oSampleNumber)
                End With

            End If
        Else

        End If


    End Sub

    Private Sub CopyImage_eventHandler(ByVal sender As Object, ByVal e As Service.clsApplicationTypes.fmImageCopyEventArg)
        If e.ImageNames.Length = 0 Then Exit Sub
        'скопировать изображения, список имен в аргументе
        'задать устройство принимающее
        Dim _Tosource As clsFilesSources = clsFilesSources.CreateInstance(Service.clsFilesSources.emSources.Arhive)

        'задать устройство источник
        Dim _Fromsource As clsFilesSources = clsFilesSources.CreateInstance(Service.clsFilesSources.emSources.FreeFolder, , False, e.ImagesPath)
        'вычислить оптимизацию
        Dim _optimize As Integer = 1024
        Dim _message As String = "Копировать " & e.ImageNames.Length & " файлов "
        _message += "с оптимизацией по длинной стороне " & _optimize.ToString & "?"
        'задать вопрос
        Select Case MsgBox(_message, MsgBoxStyle.YesNo)
            Case MsgBoxResult.Yes
                'копировать
                Dim _count As Integer = Service.clsApplicationTypes.SamplePhotoObject.CopyImagesFromSourceToSource(oCurrentItem.SampleNumberObj, _Fromsource, _Tosource, False, e.ImageNames, _optimize)
                MsgBox(_count & " фото скопированы для образца" & oCurrentItem.SampleNumberObj.GetEan13 & " на уст-во " & _Tosource.ToString, vbInformation)
            Case MsgBoxResult.No
                Exit Sub
        End Select
    End Sub


    Private Sub DelImage_eventHandler(ByVal sender As Object, ByVal e As Service.clsApplicationTypes.fmImageDelEventArg)
        If e.ImageNames.Count = 0 Then Exit Sub

        'удалить изображения, список имен в аргументе
        Dim _source As Service.clsFilesSources = clsFilesSources.CreateInstance(Service.clsFilesSources.emSources.Arhive)

        Dim _coll(e.ImageNames.Count - 1) As String
        e.ImageNames.CopyTo(_coll, 0)
        Dim _count As Integer = Service.clsApplicationTypes.SamplePhotoObject.DeleteImagesFromSource(oCurrentItem.SampleNumberObj, _source, _coll, False, False)
        MsgBox("Удалено " & _count & " фото с устр-ва " & _source.ToString, vbInformation)
        Service.clsApplicationTypes.DelegatStorefmImageDeleteDelegate = Nothing
    End Sub



#Region "Кнопки правого меню"

    Private Sub btTrilboneHistory_Click(sender As Object, e As EventArgs) Handles btTrilboneHistory.Click
        Dim _fm As New Windows.Forms.Form
        Dim _uc As New Service.Uc_trilbone_history
        _uc.SampleNumber(True) = Me.lbSampleNumber.Text
        _uc.Height = _uc.Height + 250
        _fm.ClientSize = New Size(_uc.Width, _uc.Height)
        _fm.Controls.Add(_uc)

        Dim _p = New Point(Me.PointToScreen(btTrilboneHistory.Location))
        _p.Offset(-1 * _fm.Width, 0)


        _fm.Show()
        _fm.Location = _p

    End Sub

    Private Sub btShowCatalog_Click(sender As System.Object, e As System.EventArgs) Handles btShowCatalog.Click
        Me.oSplashScreen.Show()
        Dim _list As New List(Of clsApplicationTypes.clsSampleNumber)
        Dim _title As String = ""
        Dim _name As String = ""
        If Me.tbCtlMain.SelectedTab Is Me.tpByName Then
            For Each e1 In Me.dgv_SampleResultByName.Rows
                _list.Add(clsApplicationTypes.clsSampleNumber.CreateFromString(e1.DataBoundItem.SampleNumber))
            Next
            _name = "Name source catalog"
            _title = "каталог для строки поиска по имени " & Me.tbName.Text
        End If

        If Me.tbCtlMain.SelectedTab Is Me.tpByWeight Then
            For Each e1 In Me.dgv_SampleWeightResult.Rows
                Dim _sm = clsApplicationTypes.clsSampleNumber.CreateFromString(e1.Cells(0).value)
                If Not _sm Is Nothing AndAlso _sm.CodeIsCorrect = True Then
                    _list.Add(_sm)
                End If
            Next
            _name = "List source catalog"
            _title = "Каталог для списка образцов"
        End If

        If Me.tbCtlMain.SelectedTab Is Me.tpGoodMap Then
            For Each e1 In Me.Uc_oldMC1.RowList
                Dim _sm = clsApplicationTypes.clsSampleNumber.CreateFromString(IIf(e1.Артикул Is Nothing OrElse String.IsNullOrEmpty(e1.Артикул), e1.Код, e1.Артикул))
                If Not _sm Is Nothing AndAlso _sm.CodeIsCorrect = True Then
                    _list.Add(_sm)
                End If
            Next
            _name = "List source catalog"
            _title = "Каталог для списка образцов"
        End If

        Dim _catalog As Service.Catalog.CATALOG = clsOrderService.GetCatalog(_list, _name, _title, clsFilesSources.Arhive, clsApplicationTypes.RussianCulture, True, Service.clsApplicationTypes.emCatalogFolderType.shot)
        Me.oSplashScreen.Hide()

        If Not _catalog Is Nothing Then
            Dim _xml = _catalog.GetXML
            Dim fm As New fmBrowser(_catalog.GetHTML())
            fm.Show()
        End If

    End Sub


    Private Sub btSampleOnSale_Click(sender As System.Object, e As System.EventArgs) Handles btSampleOnSale.Click
        'по запросу выполняем вызов из сервиса
        'если делегата нет, то сервис недоступен
        Dim _fmSampleOnSale As Form
        Dim _param As Object = {oCurrentItem.SampleNumber.ToString}

        If Not clsApplicationTypes.DelegateStoreApplicationForm _
(clsApplicationTypes.emFormsList.fmSampleOnSale) Is Nothing Then
            'сервис зарегестрирован - вызываем
            _fmSampleOnSale = clsApplicationTypes.DelegateStoreApplicationForm(clsApplicationTypes.emFormsList.fmSampleOnSale).Invoke(_param)
        Else
            Exit Sub
        End If

        _fmSampleOnSale.ShowDialog()

    End Sub
#End Region



#Region "вкладка по имени"
    Private Sub btShowInfo_Click(sender As Object, e As EventArgs) Handles btShowInfo.Click
        Dim _namePart As String = ""
        'берем часть имени из заголовка
        If Not String.IsNullOrEmpty(Me.tbName.Text) Then
            _namePart = clsApplicationTypes.RejectSkobki(Me.tbName.Text.Trim)
        End If

        If String.IsNullOrEmpty(_namePart) Then Return

        _namePart = _namePart.ToLower()

        Me.oSplashScreen.Show()
        'получить обьект-источник данных
        Dim _result = clsSellInfo.GetStatistic(_namePart, "", 0)
        Dim _resEbay = clsSellInfo.GetStatisticByEbay(_namePart)
        _result.AddRange(_resEbay)



        Me.oSplashScreen.Hide()
        If _result.Count = 0 Then
            clsApplicationTypes.BeepNOT()
            Return
        End If

        Me.ContextMenuStrip1.Items.Clear()

        If _result.Count > 0 Then
            Me.ContextMenuStrip1.Items.AddRange(_result.GetMenuItems)
            Me.ContextMenuStrip1.Show(dgv_SampleResultByName.PointToScreen(New Point(10, 10)))
        Else
            MsgBox(String.Format("По образцам {0} данных нет", _namePart), vbInformation)
        End If
    End Sub


    Private Sub dgv_SampleResultByName_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgv_SampleResultByName.CellMouseClick
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim _namePart As String
            'берем часть имени из заголовка
            If Not String.IsNullOrEmpty(Me.tbName.Text) Then
                _namePart = Me.tbName.Text.Trim
            Else
                'или из значения ячейки
                _namePart = dgv_SampleResultByName.Rows(If(e.RowIndex < 0, 0, e.RowIndex)).Cells(2).Value.ToString.Split(" ").FirstOrDefault
            End If

            If String.IsNullOrEmpty(_namePart) Then Return

            _namePart = _namePart.ToLower()

            Dim _size As Decimal = Decimal.Parse(dgv_SampleResultByName.Rows(If(e.RowIndex < 0, 0, e.RowIndex)).Cells(4).Value)
            Me.oSplashScreen.Show()
            'получить обьект-источник данных

            Dim _result = clsSellInfo.GetStatistic(_namePart, "", _size)
            Me.oSplashScreen.Hide()


            Me.ContextMenuStrip1.Items.Clear()

            If _result.Count > 0 Then
                Me.ContextMenuStrip1.Items.AddRange(_result.GetMenuItems)
                Me.ContextMenuStrip1.Show(dgv_SampleResultByName.PointToScreen(e.Location))
            Else
                MsgBox(String.Format("По образцам {0} размером около {1} данных нет", _namePart, _size), vbInformation)
            End If

        End If
    End Sub

    Private Sub btQuery_Click(sender As System.Object, e As System.EventArgs) Handles btQuery.Click
        Me.btQuery.ForeColor = Control.DefaultForeColor
        Dim _result = clsApplicationTypes.SampleDataObject.GetFossilByNameList(Me.tbName.Text.Trim)
        Me.dgv_SampleResultByName.DataSource = _result
        Me.lbNameCount.Text = "записей: " & _result.Count
    End Sub

    Private Sub lbNamesList_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lbNamesList.SelectedIndexChanged
        Dim _count As Integer = lbNamesList.SelectedItem.count
        Me.lbNameCount.Text = "записей: " & _count
        Me.tbName.Text = lbNamesList.SelectedItem.fossil
        If _count < 11 Then
            'автоматом нажать запрос
            Me.btQuery.ForeColor = Control.DefaultForeColor
            btQuery_Click(sender, e)
        Else
            Me.btQuery.ForeColor = Color.Red
        End If
    End Sub

    Private Sub dgv_SampleResultByName_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_SampleResultByName.CellDoubleClick
        If Not (e.ColumnIndex > -1 AndAlso e.RowIndex > -1) Then Return
        Select Case e.ColumnIndex
            Case 0
                Call Me.ShowImageForm()
                '=======
            Case 1
                ''инфо по номеру
                clsApplicationTypes.ExternalLoadSample(dgv_SampleResultByName.Rows(e.RowIndex).DataBoundItem.SampleNumber.ToString)
        End Select
    End Sub
#End Region

#Region "по списку или весу"
    Private Sub btCancelFilter_Click(sender As Object, e As EventArgs) Handles btCancelFilter.Click
        dgv_SampleWeightResult.DataSource = oCurrentBindingList
        Me.lblWeightCount.Text = "записей: " & dgv_SampleWeightResult.DataSource.Count
    End Sub

    Private Sub btNameFilter_Click(sender As Object, e As EventArgs) Handles btNameFilter.Click
        If Not String.IsNullOrEmpty(Me.tbFiltered.Text) Then

            Dim _lst As New List(Of Service.FindByWeight_Result)
            _lst.AddRange(dgv_SampleWeightResult.DataSource)
            If _lst.Count = 0 Then _lst.AddRange(oCurrentBindingList)

            Dim _list = (From c In _lst Where ((Not String.IsNullOrEmpty(c.Sample_main_species)) AndAlso c.Sample_main_species.ToLower.Contains(Me.tbFiltered.Text.Trim.ToLower)) Or ((Not String.IsNullOrEmpty(c.Fossil_list)) AndAlso c.Fossil_list.ToLower.Contains(Me.tbFiltered.Text.Trim.ToLower))).ToList
            '!!! 
            dgv_SampleWeightResult.DataSource = _list
            clsApplicationTypes.BeepYES()
        Else
            dgv_SampleWeightResult.DataSource = oCurrentBindingList
        End If

        Me.lblWeightCount.Text = "записей: " & dgv_SampleWeightResult.DataSource.Count
    End Sub

    Private Sub btSortByName_Click(sender As Object, e As EventArgs) Handles btSortByName.Click
        If TypeOf dgv_SampleWeightResult.DataSource Is BindingList(Of FindByWeight_Result) Then
            Me.dgv_SampleWeightResult.SuspendLayout()

            Dim _lst As New List(Of Service.FindByWeight_Result)
            _lst.AddRange(oCurrentBindingList)
            _lst.Sort(Function(x, y) (x.Sample_main_species.CompareTo(y.Sample_main_species)))


            oCurrentBindingList.Clear()
            For Each t In _lst
                oCurrentBindingList.Add(t)
            Next

            Me.dgv_SampleWeightResult.ResumeLayout()

        ElseIf TypeOf dgv_SampleWeightResult.DataSource Is List(Of Service.FindByWeight_Result) Then
            Dim _lst As List(Of Service.FindByWeight_Result) = dgv_SampleWeightResult.DataSource
            _lst.Sort(Function(x, y) (x.Sample_main_species.CompareTo(y.Sample_main_species)))
            dgv_SampleWeightResult.Refresh()
        End If
    End Sub

    Private Sub dgv_SampleWeightResult_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgv_SampleWeightResult.CellMouseClick
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim _namePart As String
            'берем часть имени 
            _namePart = dgv_SampleWeightResult.Rows(If(e.RowIndex < 0, 0, e.RowIndex)).Cells(1).Value.ToString.Split(" ").FirstOrDefault

            If String.IsNullOrEmpty(_namePart) Then Return

            _namePart = _namePart.ToLower()

            'Dim _size As Decimal = Decimal.Parse(dgv_SampleWeightResult.Rows(If(e.RowIndex < 0, 0, e.RowIndex)).Cells(4).Value)
            Me.oSplashScreen.Show()
            'получить обьект-источник данных

            Dim _result = clsSellInfo.GetStatistic(_namePart, "", 0)
            Me.oSplashScreen.Hide()


            Me.ContextMenuStrip1.Items.Clear()

            If _result.Count > 0 Then
                Me.ContextMenuStrip1.Items.AddRange(_result.GetMenuItems)
                Me.ContextMenuStrip1.Show(dgv_SampleWeightResult.PointToScreen(e.Location))
            Else
                MsgBox(String.Format("По образцам {0} данных нет", _namePart), vbInformation)
            End If

        End If
    End Sub



    Private Sub bt_fromClip_Click(sender As Object, e As EventArgs) Handles bt_fromClip.Click
        Me.oCurrentBindingList.Clear()
        For Each t In Me.GetFromBuffer
            Me.oCurrentBindingList.Add(t)
        Next


    End Sub

    Private Sub btAddToList_Click(sender As Object, e As EventArgs) Handles btAddToList.Click
        For Each t In Me.GetFromBuffer
            Me.oCurrentBindingList.Add(t)
        Next



    End Sub

    Private Function GetFromBuffer() As List(Of Service.FindByWeight_Result)
        Dim _list As New List(Of Service.FindByWeight_Result)
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
            Dim _rs = clsApplicationTypes.SampleDataObject.GetSampleInfo(t)
            If Not _rs Is Nothing Then
                _list.Add(_rs)
            End If
        Next

        Me.oSplashScreen.Hide()
        Return _list
    End Function

    Private Sub btClear_Click(sender As Object, e As EventArgs) Handles btClear.Click
        Me.dgv_SampleWeightResult.SuspendLayout()
        Me.oCurrentBindingList.Clear()
        Me.dgv_SampleWeightResult.ResumeLayout()
        Me.lblWeightCount.Text = "записей: "
        Me.tbWeightFrom.Text = ""
        Me.tbWeightTo.Text = ""

    End Sub

    Private Sub tbWeightFrom_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbWeightFrom.KeyPress
        If Asc(e.KeyChar) = 13 Then
            tbWeightTo.Focus()
        End If
    End Sub


    Private Sub tbWeightTo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbWeightTo.KeyPress
        If Asc(e.KeyChar) = 13 Then
            btWeightQuery_Click(sender, e)
        End If
    End Sub

    Private Sub btWeightQuery_Click(sender As Object, e As EventArgs) Handles btWeightQuery.Click
        Dim _from = clsApplicationTypes.ReplaceDecimalSplitter(Me.tbWeightFrom)
        Dim _to = clsApplicationTypes.ReplaceDecimalSplitter(Me.tbWeightTo)
        If _from = 0 Or _to = 0 Then Return

        Me.oCurrentBindingList.Clear()

        For Each t In clsApplicationTypes.SampleDataObject.GetSampleByWeight(_from, _to)
            Me.oCurrentBindingList.Add(t)
        Next


        Me.lblWeightCount.Text = "записей: " & oCurrentBindingList.Count

    End Sub

    Private Sub dgv_SampleWeightResult_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_SampleWeightResult.CellDoubleClick
        If Not (e.ColumnIndex > -1 AndAlso e.RowIndex > -1) Then Return
        Select Case e.ColumnIndex
            Case 2
                Call Me.ShowImageForm()
                '=======
            Case 0
                ''инфо по номеру
                clsApplicationTypes.ExternalLoadSample(dgv_SampleWeightResult.Rows(e.RowIndex).DataBoundItem.SampleNumber.ToString)
        End Select
    End Sub

    Private Sub Uc_oldMC1_Load(sender As Object, e As EventArgs) Handles Uc_oldMC1.Load

    End Sub

    Private Sub dgv_SampleWeightResult_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_SampleWeightResult.CellContentClick

    End Sub











#End Region





End Class