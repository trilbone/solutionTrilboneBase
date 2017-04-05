Imports System.Data.Objects
Imports trilbone
'Imports System.Web.UI.WebControls
Imports System.Data.Objects.DataClasses


Public Class fmSampleList
    Private WithEvents _sampleContext As ModelSampleListContainer
    Private oActiveListLine As ListLine
    Private oActiveListType As ListType
    Private WithEvents oActiveSampleList As SampleList



    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        _sampleContext = New ModelSampleListContainer

        Me.cbListLine.DataSource = _sampleContext.LocalAsList(_sampleContext.ListLineCollection)
        Me.cbListLine.DisplayMember = "ListLineName"

        Me.cbCurrentListLine.DataSource = _sampleContext.LocalAsList(_sampleContext.ListLineCollection)
        Me.cbCurrentListLine.DisplayMember = "ListLineName"

        Me.cbListType.DataSource = _sampleContext.LocalAsList(_sampleContext.ListTypeCollection)
        Me.cbListType.DisplayMember = "ListTypeName"

        Me.cbCurrentListType.DataSource = _sampleContext.LocalAsList(_sampleContext.ListTypeCollection)
        Me.cbCurrentListType.DisplayMember = "ListTypeName"

        Me.lbSampleList.SelectionMode = SelectionMode.MultiExtended
    End Sub
    Private WithEvents oActiveSample As SampleInList

    Public Property ActiveSample As SampleInList
        Get
            Return oActiveSample
        End Get
        Set(value As SampleInList)
            'установить активный образец
            oActiveSample = value
            If value Is Nothing Then
                Me.SampleInListBindingSource.Clear()
            Else
                Me.SampleInListBindingSource.DataSource = value
            End If

        End Set
    End Property



    ''' <summary>
    ''' свойство для доступа к активному списку
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ActiveSampleList As SampleList
        Get
            Return oActiveSampleList
        End Get
        Set(value As SampleList)
            If value Is Nothing Then
                'очищаем все для пустого списка
                Me.oActiveSampleList = Nothing
                For Each ctl As Control In gbSelectedList.Controls
                    ctl.Enabled = False
                Next
            Else
                'активировать ЭУ
                For Each ctl As Control In gbSelectedList.Controls
                    ctl.Enabled = True
                Next
                Me.CloseDateTextBox.Enabled = False

                'меняем привязку данных
                Me.oActiveSampleList = value
                Me.SampleListBindingSource.DataSource = value

                'установить привязку для образцов
                Dim _sl = From c In oActiveSampleList.SampleAndList Select c.SampleInList
                Dim _countSample = _sl.Count
                If _countSample = 0 Then
                    'нет образцов
                    Me.gbSample.Text = "Образцы в списке - нет образцов"
                    For Each ctl As Control In Me.gbSample.Controls
                        ctl.Enabled = False
                    Next
                    Me.btAddSample.Enabled = True
                    Me.tbSampleNumber.Enabled = True
                    Me.lbSampleList.DataSource = Nothing
                    Me.ActiveSample = Nothing
                Else
                    Me.gbSample.Text = "Образцы в списке"
                    For Each ctl As Control In Me.gbSample.Controls
                        ctl.Enabled = True
                    Next
                    Me.lbSampleList.DataSource = _sl.ToList
                    Me.lbSampleList.DisplayMember = "SampleNumber"
                    ''установить активный образец
                    'If Not Me.ActiveSample Is Nothing Then
                    '    If Me.lbSampleList.Items.Contains(Me.ActiveSample) Then
                    '        Me.lbSampleList.SelectedItem = Me.ActiveSample
                    '    End If
                    'End If
                End If

                Me.lbListCount.Text = "Всего в списке " & _countSample & " образцов"

                'действия для закрытых списков
                If cbxIsActive.Checked = False Then
                    For Each ctl As Control In Me.gbSample.Controls
                        ctl.Enabled = False
                    Next
                    Me.lbSampleList.Enabled = True
                End If


            End If
        End Set
    End Property

    ''' <summary>
    ''' проверка необходимости изменений на сервере
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CheckNeedSaving()
        If _sampleContext.ObjectStateManager.GetObjectStateEntries(EntityState.Added Or EntityState.Deleted Or EntityState.Modified).Count > 0 Then
            Me.btSaveDb.ForeColor = Color.Red
        End If
    End Sub
#Region "регион Фильтр Списков"

    ''' <summary>
    ''' добавление нового значения по нажатию ENTER
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cbListLine_KeyPress(sender As System.Object, e As KeyPressEventArgs) Handles cbListLine.KeyPress
        Select Case AscW(e.KeyChar)
            Case 13
                If cbListLine.SelectedIndex = -1 Then
                    'add new value
                    Dim _new = cbListLine.Text
                    Select Case MsgBox("Добавить новое значение '" & _new & "' в линии списков?", MsgBoxStyle.YesNo, "Линии списков")
                        Case MsgBoxResult.Yes
                            Dim _newObj = ListLine.CreateListLine(0, _new)
                            _sampleContext.ListLineCollection.AddObject(_newObj)
                            Me.cbListLine.DataSource = _sampleContext.LocalAsList(_sampleContext.ListLineCollection)
                            cbListLine.SelectedItem = _newObj
                        Case Else

                    End Select
                    CheckNeedSaving()
                End If

        End Select

    End Sub
    ''' <summary>
    ''' добавление нового значения по нажатию ENTER
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cbListType_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cbListType.KeyPress
        Select Case AscW(e.KeyChar)
            Case 13
                If cbListType.SelectedIndex = -1 Then
                    'add new value
                    Dim _new = cbListType.Text
                    Select Case MsgBox("Добавить новое значение '" & _new & "' в типы списков?", MsgBoxStyle.YesNo, "Типы списков")
                        Case MsgBoxResult.Yes
                            Dim _newObj = ListType.CreateListType(0, _new)
                            _sampleContext.ListTypeCollection.AddObject(_newObj)

                            Me.cbListType.DataSource = _sampleContext.LocalAsList(_sampleContext.ListTypeCollection)
                            cbListType.SelectedItem = _newObj
                        Case Else

                    End Select
                    CheckNeedSaving()
                End If

        End Select
    End Sub




    ''' <summary>
    ''' заполняет список списков по фильтрам (обслуживает регион Фильтр Списков)
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub FillLbLists()
        'запомнить активный списов
        Dim _tmpActiveList As Object = Me.oActiveSampleList

        'на основании выбранных значений линии и типа списков отобразить доступные списки или получить возможность создать новые
        If cbListType.SelectedItem Is Nothing Then
            GoTo queryNotPossible
        Else
            oActiveListType = cbListType.SelectedItem
        End If

        If cbListLine.SelectedItem Is Nothing Then
            GoTo queryNotPossible
        Else
            oActiveListLine = cbListLine.SelectedItem
        End If

        'запрос в соответствии с выбранными значениями
        Dim _result As IEnumerable(Of SampleList)
        Dim _sourseForQuery = _sampleContext.LocalAsList(_sampleContext.SampleListCollection)
        If oActiveListLine.IDListLine = 1 Then
            If oActiveListType.IDListType = 1 Then
                'показать все списки (без фильтров)
                _result = From c In _sourseForQuery Select c

                Me.lbShowLists.Text = "все списки (без фильтров)"
            Else
                'фильтр по ListType
                _result = From c In _sourseForQuery Where c.ListType.IDListType = oActiveListType.IDListType Select c

                Me.lbShowLists.Text = "фильтр по ListType"
            End If
        Else
            If oActiveListType.IDListType = 1 Then
                'фильтр по ListLine
                _result = From c In _sourseForQuery Where c.ListLine.IDListLine = oActiveListLine.IDListLine Select c

                Me.lbShowLists.Text = "фильтр по ListLine"
            Else
                'оба фильтра
                _result = From c In _sourseForQuery Where c.ListLine.IDListLine = oActiveListLine.IDListLine And c.ListType.IDListType = oActiveListType.IDListType Select c

                Me.lbShowLists.Text = "фильтр по ListLine и ListType"
            End If

        End If

        If cbxOnlyActiveLists.Checked Then
            _result = From c In _result Where c.IsActiveFlag = True Select c

            Me.lbShowLists.Text += " - только активные"
        End If



        If _result.Count > 0 Then
            Me.lbLists.DataSource = (_result).ToList
            Me.lbLists.DisplayMember = "ListName"
            If Not _tmpActiveList Is Nothing Then
                If Me.lbLists.Items.Contains(_tmpActiveList) Then
                    Me.lbLists.SelectedItem = _tmpActiveList
                End If
            End If

        Else
            lbLists.DataSource = Nothing
            lbLists.Items.Clear()
            lbLists.Items.Add("нет списков")
            Me.ActiveSampleList = Nothing
        End If



        Exit Sub
queryNotPossible:
        lbLists.DataSource = Nothing
        lbLists.Items.Clear()
        lbLists.Items.Add("еобходимо выбрать линию и тип списка")
    End Sub

    Private Sub cbListType_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbListType.SelectedIndexChanged
        FillLbLists()
    End Sub
    Private Sub cbListLine_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbListLine.SelectedIndexChanged
        FillLbLists()
    End Sub
    Private Sub cbxOnlyActiveLists_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles cbxOnlyActiveLists.CheckedChanged
        FillLbLists()
    End Sub

    ''' <summary>
    ''' работа с изменением свойств в активном списке
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub oActiveSammpleList_PropertyChanged(sender As Object, e As System.ComponentModel.PropertyChangedEventArgs) Handles oActiveSampleList.PropertyChanged
        Me.CheckNeedSaving()
        Select Case e.PropertyName
            Case "ListName"
                'обновить список списков
                Me.FillLbLists()
        End Select
    End Sub

    ''' <summary>
    ''' сохранение данных на сервере
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btSaveDb_Click(sender As System.Object, e As System.EventArgs) Handles btSaveDb.Click
        _sampleContext.SaveChanges()
        MsgBox("Изменения сохранены", MsgBoxStyle.OkOnly)
        Me.btSaveDb.ForeColor = Control.DefaultForeColor
        Me.FillLbLists()
    End Sub


    ''' <summary>
    ''' создание нового списка
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btCreateList_Click(sender As System.Object, e As System.EventArgs) Handles btCreateList.Click
        If oActiveListLine Is Nothing Then Exit Sub
        If oActiveListType Is Nothing Then Exit Sub

        Me.tbNameList.Text = "Новый список"

        Dim _newObj = SampleList.CreateSampleList(0, Me.tbNameList.Text, Date.Now)
        _sampleContext.SampleListCollection.AddObject(_newObj)
        With _newObj
            .ListLineReference.Value = oActiveListLine
            .ListTypeReference.Value = oActiveListType
            .IsActiveFlag = True
        End With
        CheckNeedSaving()
        Me.FillLbLists()
        Me.ActiveSampleList = _newObj

    End Sub

    ''' <summary>
    ''' выбор активного списка в ЭУ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub lbLists_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lbLists.SelectedIndexChanged
        If Me.lbLists.SelectedItem Is Nothing Then Exit Sub
        If Not Me.lbLists.SelectedItem.GetType = GetType(SampleList) Then Exit Sub

        Me.ActiveSampleList = (Me.lbLists.SelectedItem)

    End Sub
#End Region

#Region "Выбранный список"
    ''' <summary>
    ''' работа с закрытием списков
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cbxIsActive_Validated(sender As Object, e As System.EventArgs) Handles cbxIsActive.Validated
        If cbxIsActive.Checked = True Then
            'checked true
            If (Not oActiveSampleList Is Nothing) AndAlso oActiveSampleList.CloseDate.HasValue = True Then
                Dim _new As Nullable(Of Global.System.DateTime)
                oActiveSampleList.CloseDate = _new
            End If
        End If

        If cbxIsActive.Checked = False Then
            If oActiveSampleList.CloseDate.HasValue = False Then
                oActiveSampleList.CloseDate = Date.Now
            End If
        End If
    End Sub

#End Region

#Region "Образцы в списке"

#End Region

    ''' <summary>
    ''' добавление образца
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btAddSample_Click(sender As System.Object, e As System.EventArgs) Handles btAddSample.Click
        'TODO тут встроить проверку номера
        Dim _samplenumber As String = Trim(Me.tbSampleNumber.Text)

        'проверить наличие в списке
        For Each c As SampleInList In lbSampleList.Items
            If String.Compare(c.SampleNumber, _samplenumber, True) = 0 Then
                'найден в списке
                MsgBox("Образец номер '" & _samplenumber & "' уже есть в списке!", MsgBoxStyle.Critical)
                Exit Sub
            End If
        Next

        'создать обьект SampleAndList
        'привязать его к SampleList
        'создать обьект SampleInList
        'привязать его к SampleAndList

        'создать по возможности уникальный SampleID
        Dim _newsample = SampleInList.CreateSampleInList(_samplenumber.GetHashCode Xor Date.Now.GetHashCode)
        With _newsample
            .SampleNumber = _samplenumber
        End With
        'добавить его к локальной копии
        '_sampleContext.SampleInListCollection.AddObject(_newsample)
        'создать связку SampleAndLists
        Dim _newSAL = SampleAndList.CreateSampleAndList(0, _newsample.IDSample, Me.oActiveSampleList.IDList)
        'добавить связку в контекст
        Me.oActiveSampleList.SampleAndList.Add(_newSAL)
        _newSAL.SampleInList = _newsample

        'образец добавлен
        Me.ActiveSample = _newsample
        tbSampleNumber.Text = ""
        oActiveSample_PropertyChanged(Me, New System.ComponentModel.PropertyChangedEventArgs("Add"))
        tbSampleNumber.Focus()

    End Sub

    Private Sub lbSampleList_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lbSampleList.SelectedIndexChanged
        If lbSampleList.SelectedItem Is Nothing Then Exit Sub
        Me.ActiveSample = lbSampleList.SelectedItem
    End Sub
    ''' <summary>
    ''' изменено св-во образца
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub oActiveSample_PropertyChanged(sender As Object, e As System.ComponentModel.PropertyChangedEventArgs) Handles oActiveSample.PropertyChanged
        CheckNeedSaving()
        Dim _tmp As Object = oActiveSample

        Me.lbSampleList.DataSource = (From c In oActiveSampleList.SampleAndList Select c.SampleInList).ToList

        If Not _tmp Is Nothing Then
            If Me.lbSampleList.Items.Contains(_tmp) Then
                lbSampleList.SelectedItems.Clear()
                lbSampleList.SelectedItem = _tmp
            End If
        End If
        'If Not Me.ActiveSample Is Nothing Then
        '    lbSampleList.SelectedItems.Clear()
        '    lbSampleList.SelectedItem = Me.ActiveSample
        'Else

        'End If


    End Sub

    Private Sub tbSampleNumber_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tbSampleNumber.KeyPress
        Select Case AscW(e.KeyChar)
            Case 13
                btAddSample_Click(sender, e)

        End Select
    End Sub

    
End Class
