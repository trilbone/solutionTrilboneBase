Imports RestMS_Client.MoySkladAPI
Imports RestMS_Client.mdMoySkladExtentions.clsMoyScladManager

Public Class fmOptions
    Private oManager As clsMoyScladManager
    Friend Sub New(manager As clsMoyScladManager)
        InitializeComponent()
        oManager = manager
        Init()
    End Sub

    Private Sub Init()

        Me.btAcceptNewWare.Enabled = False
        Me.tbNewLoss.Enabled = False
        Me.btAddLoss.Enabled = False
        Me.tbNewEnter.Enabled = False
        Me.btAddEnter.Enabled = False
        Me.btAddWarehouse.Enabled = False
        Me.tbNewWare.Text = ""

        With oManager
            Me.lbWareList.Items.Clear()
            '(ACL включено)
            For Each t In .WarehouseList
                Me.lbWareList.Items.Add(t.name)
            Next
            Me.lbWareList.Refresh()

            Me.lbEnters.Items.Clear()
            For Each t In .EnterList
                Me.lbEnters.Items.Add(t.uuid)
            Next
            Me.lbEnters.Refresh()

            Me.lbLoss.Items.Clear()
            For Each t In .LossList
                Me.lbLoss.Items.Add(t.uuid)
            Next
        End With

        Me.lbLoss.Refresh()

        Me.MySettingsBindingSource.DataSource = {My.Settings}

        Me.Refresh()
    End Sub


    Private Sub New()

        ' Этот вызов является обязательным для конструктора.
        InitializeComponent()

        ' Добавьте все инициализирующие действия после вызова InitializeComponent().

    End Sub



    'Private Sub btAddNewWare_Click(sender As System.Object, e As System.EventArgs)
    '    If Me.tbNewWare.Text = "" Then Return
    '    If Me.tbNewEnter.Text = "" Then Return
    '    If Me.tbNewLoss.Text = "" Then Return
    '    ' Dim _wareUUID As String
    '    'склад
    '    Dim _name = Me.tbNewWare.Text
    '    Dim _data As IEnumerable(Of Object) = Nothing
    '    Dim _message As String = ""
    '    Dim _result = oManager.RequestAnyCollection(clsMoyScladManager.emMoySkladObjectTypes.Warehouse, _data, _name, emMoySkladFilterTypes.name, _message)

    '    Select Case _result
    '        Case Net.HttpStatusCode.OK
    '            Select Case _data.Count
    '                Case 0
    '                    'склад не найден
    '                    MsgBox("Cклада " & _name & " нет! Неправильный запрос?" & ChrW(13) & _message, vbCritical)
    '                Case Is > 0
    '                    Dim _d = _data.Cast(Of warehouse).ToList
    '                    Debug.Assert(_d.Count = 1, "Запрос по имени склада вернул более одного результата!!!")
    '                    Me.tbNewWare.Text = _d(0).name
    '            End Select
    '        Case Net.HttpStatusCode.NotFound
    '            'склад не найден
    '            MsgBox("Cклада " & _name & " нет! Неправильный запрос?" & ChrW(13) & _message, vbCritical)
    '            Return
    '        Case Else
    '            'запрос вернул ошибку
    '            MsgBox("запрос складов вернул ошибку. Неправильный запрос?" & ChrW(13) & _message, vbCritical)
    '            Return
    '    End Select

    '    'оприходование
    '    Dim _enterUUID As String = ""
    '    _data = Nothing
    '    _message = ""
    '    _result = oManager.RequestAnyCollection(clsMoyScladManager.emMoySkladObjectTypes.Enter, _data, Me.tbNewEnter.Text, clsMoyScladManager.emMoySkladFilterTypes.name, _message)

    '    Select Case _result
    '        Case Net.HttpStatusCode.OK
    '            If _data.Count = 0 Then
    '                MsgBox("Оприходования с этим номером не существует", vbCritical)
    '                Return
    '            End If
    '            'ok
    '            _enterUUID = CType(_data(0), RestMS_Client.MoySkladAPI.enter).uuid
    '            If _enterUUID = "" Then Return
    '        Case Else
    '            MsgBox("Запрос оприходований вернул ошибку: " & _message, vbCritical)
    '            Return
    '    End Select

    '    'списание
    '    Dim _lossUUID As String = ""
    '    _message = ""
    '    _data = Nothing
    '    _result = oManager.RequestAnyCollection(clsMoyScladManager.emMoySkladObjectTypes.Loss, _data, Me.tbNewLoss.Text, clsMoyScladManager.emMoySkladFilterTypes.name, _message)
    '    Select Case _result
    '        Case Net.HttpStatusCode.OK
    '            If _data.Count = 0 Then
    '                MsgBox("Списания с этим номером не существует", vbCritical)
    '                Return
    '            End If
    '            'ok
    '            _lossUUID = CType(_data(0), RestMS_Client.MoySkladAPI.loss).uuid
    '            If _lossUUID = "" Then Return
    '        Case Else
    '            MsgBox("Запрос списаний вернул ошибку: " & _message, vbCritical)
    '            Return
    '    End Select

    '    My.Settings.WorkWareList.Add(Me.tbNewWare.Text)
    '    Me.lbWareList.Items.Add(Me.tbNewWare.Text)
    '    Me.tbNewWare.Text = ""

    '    My.Settings.WorkEnterList.Add(_enterUUID)
    '    Me.lbEnters.Items.Add(_enterUUID)
    '    Me.tbNewEnter.Text = ""

    '    My.Settings.WorkLossList.Add(_lossUUID)
    '    Me.lbLoss.Items.Add(_lossUUID)
    '    Me.tbNewLoss.Text = ""

    '    MsgBox("Склад добавлен. Нажмите сохранить!!", vbInformation)

    'End Sub

    Private Sub btSave_Click(sender As System.Object, e As System.EventArgs) Handles btSave.Click
        My.Settings.Save()
        MsgBox("Изменения сохранены.", vbInformation)
    End Sub

    Private Sub btClose_Click(sender As System.Object, e As System.EventArgs) Handles btClose.Click
        Me.Close()
    End Sub




    Private Sub btAddWarehouse_Click(sender As Object, e As EventArgs) Handles btAddWarehouse.Click
        If Me.tbNewWare.Text = "" Then Return
        'склад
        Dim _name = Me.tbNewWare.Text
        Dim _data As IEnumerable(Of Object) = Nothing
        Dim _message As String = ""
        Dim _result = oManager.RequestAnyCollection(clsMoyScladManager.emMoySkladObjectTypes.Warehouse, _data, _name, emMoySkladFilterTypes.name, _message)

        Select Case _result
            Case Net.HttpStatusCode.OK
                Select Case _data.Count
                    Case 0
                        'склад не найден
                        MsgBox("Cклада " & _name & " нет! Неправильный запрос?" & ChrW(13) & _message, vbCritical)
                    Case Is > 0
                        Dim _d = _data.Cast(Of warehouse).ToList
                        Debug.Assert(_d.Count = 1, "Запрос по имени склада вернул более одного результата!!!")
                        Me.tbNewWare.Text = _d(0).name
                End Select
            Case Net.HttpStatusCode.NotFound
                'склад не найден
                MsgBox("Cклада " & _name & " нет! Неправильный запрос?" & ChrW(13) & _message, vbCritical)
                Return
            Case Else
                'запрос вернул ошибку
                MsgBox("запрос складов вернул ошибку. Неправильный запрос?" & ChrW(13) & _message, vbCritical)
                Return
        End Select


        Me.MySettingsBindingSource.Current.WorkWareList.Add(Me.tbNewWare.Text)
        'My.Settings.WorkWareList.Add(Me.tbNewWare.Text)
        Me.lbWareList.Items.Add(Me.tbNewWare.Text)
        Me.tbNewWare.Text = ""
        Me.tbNewEnter.Enabled = True

        MsgBox("Склад добавлен", vbInformation)

    End Sub

    Private Sub btAddEnter_Click(sender As Object, e As EventArgs) Handles btAddEnter.Click
        If Me.tbNewEnter.Text = "" Then Return

        'оприходование
        Dim _enterUUID As String = ""
        Dim _data = Nothing
        Dim _message = ""
        Dim _result = oManager.RequestAnyCollection(clsMoyScladManager.emMoySkladObjectTypes.Enter, _data, Me.tbNewEnter.Text, clsMoyScladManager.emMoySkladFilterTypes.name, _message)

        Select Case _result
            Case Net.HttpStatusCode.OK
                If _data.Count = 0 Then
                    MsgBox("Оприходования с этим номером не существует", vbCritical)
                    Return
                End If
                'ok
                _enterUUID = CType(_data(0), RestMS_Client.MoySkladAPI.enter).uuid
                If _enterUUID = "" Then Return
            Case Else
                MsgBox("Запрос оприходований вернул ошибку: " & _message, vbCritical)
                Return
        End Select

        Me.MySettingsBindingSource.Current.WorkEnterList.Add(_enterUUID)
        'My.Settings.WorkEnterList.Add(_enterUUID)
        Me.lbEnters.Items.Add(_enterUUID)
        Me.tbNewEnter.Text = ""
        Me.tbNewLoss.Enabled = True

        MsgBox("Оприходование добавлено", vbInformation)

    End Sub

    Private Sub btAddLoss_Click(sender As Object, e As EventArgs) Handles btAddLoss.Click
        If Me.tbNewLoss.Text = "" Then Return

        'списание
        Dim _lossUUID As String = ""
        Dim _message = ""
        Dim _data = Nothing
        Dim _result = oManager.RequestAnyCollection(clsMoyScladManager.emMoySkladObjectTypes.Loss, _data, Me.tbNewLoss.Text, clsMoyScladManager.emMoySkladFilterTypes.name, _message)
        Select Case _result
            Case Net.HttpStatusCode.OK
                If _data.Count = 0 Then
                    MsgBox("Списания с этим номером не существует", vbCritical)
                    Return
                End If
                'ok
                _lossUUID = CType(_data(0), RestMS_Client.MoySkladAPI.loss).uuid
                If _lossUUID = "" Then Return
            Case Else
                MsgBox("Запрос списаний вернул ошибку: " & _message, vbCritical)
                Return
        End Select

        Me.MySettingsBindingSource.Current.WorkLossList.Add(_lossUUID)
        ' My.Settings.WorkLossList.Add(_lossUUID)
        Me.lbLoss.Items.Add(_lossUUID)
        Me.tbNewLoss.Text = ""
        Me.btAcceptNewWare.Enabled = True

        MsgBox("Списание добавлено", vbInformation)

    End Sub
    ''' <summary>
    ''' применяет изменения
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btAcceptNewWare_Click(sender As Object, e As EventArgs) Handles btAcceptNewWare.Click
        If Not (lbWareList.Items.Count = lbEnters.Items.Count Or lbWareList.Items.Count = lbLoss.Items.Count Or lbEnters.Items.Count = lbLoss.Items.Count) Then
            MsgBox("Склады, оприходования и списания должны соответствовать по количеству", vbCritical)
            Return
        End If

        Dim _fm As New SplashScreen1
        _fm.Show()
        Application.DoEvents()
        My.Settings.Save()
        oManager.LoadEntities(onlyBase:=True)
        _fm.Hide()
        Init()
    End Sub

    Private Sub tbNewWare_TextChanged(sender As Object, e As EventArgs) Handles tbNewWare.TextChanged
        If tbNewWare.Text.Length > 0 Then
            Me.btAddWarehouse.Enabled = True
        Else
            Me.btAddWarehouse.Enabled = False
        End If
    End Sub

    Private Sub tbNewEnter_TextChanged(sender As Object, e As EventArgs) Handles tbNewEnter.TextChanged
        If tbNewEnter.Text.Length > 0 Then
            Me.btAddEnter.Enabled = True
        Else
            Me.btAddEnter.Enabled = False
        End If
    End Sub

    Private Sub tbNewLoss_TextChanged(sender As Object, e As EventArgs) Handles tbNewLoss.TextChanged
        If tbNewLoss.Text.Length > 0 Then
            Me.btAddLoss.Enabled = True
        Else
            Me.btAddLoss.Enabled = False
        End If
    End Sub

    Private Sub btDelWare_Click(sender As Object, e As EventArgs) Handles btDelWare.Click
        If Me.lbWareList.SelectedIndex < 0 Then Return
        Dim _item As String = Me.lbWareList.SelectedItem
        Me.lbWareList.Items.Remove(_item)
        Me.MySettingsBindingSource.Current.WorkWareList.Remove(_item)
        Me.btAcceptNewWare.Enabled = True
        'My.Settings.WorkWareList.Remove(_item)
    End Sub

    Private Sub btDelEnter_Click(sender As Object, e As EventArgs) Handles btDelEnter.Click
        If Me.lbEnters.SelectedIndex < 0 Then Return
        Dim _item As String = Me.lbEnters.SelectedItem
        Me.lbEnters.Items.Remove(_item)
        Me.MySettingsBindingSource.Current.WorkEnterList.Remove(_item)
        Me.btAcceptNewWare.Enabled = True
        'My.Settings.WorkEnterList.Remove(_item)
    End Sub

    Private Sub btDelLoss_Click(sender As Object, e As EventArgs) Handles btDelLoss.Click
        If Me.lbLoss.SelectedIndex < 0 Then Return
        Dim _item As String = Me.lbLoss.SelectedItem
        Me.lbLoss.Items.Remove(_item)
        Me.MySettingsBindingSource.Current.WorkLossList.Remove(_item)
        Me.btAcceptNewWare.Enabled = True
        'My.Settings.WorkLossList.Remove(_item)
    End Sub

    Private Sub btSaveWare_Click(sender As Object, e As EventArgs) Handles btSaveWare.Click
        Select Case MsgBox("Перезаписать файл складов? Не уверен - не пиши!!!", vbYesNo)
            Case MsgBoxResult.No
                Return
        End Select

        If oManager.SaveWareFile() Then
            MsgBox("Файл складов записан", vbInformation)
        Else
            MsgBox("Файл складов НЕ ЗАПИСАН", vbCritical)
        End If
    End Sub

    Private Sub btReadWare_Click(sender As Object, e As EventArgs) Handles btReadWare.Click
        If oManager.ReadWareFile() Then
            MsgBox("Файл складов прочитан", vbInformation)
        Else
            MsgBox("Файл складов НЕ ПРОЧИТАН", vbCritical)
        End If
    End Sub
End Class