Imports Service.clsApplicationTypes
Imports Service
Imports System.Linq

Public Class fmListManager

    Dim oSampleListManager As Service.clsSampleListManager

    

    Private Sub btCreateList_Click(sender As System.Object, e As System.EventArgs) Handles btCreateList.Click
        Dim _inp = InputBox("Имя списка?", "", "defaultList")
        Me.oSampleListManager.CreateSampleList(_inp)
        lbSamplesList.DataSource = oSampleListManager.GetNames
    End Sub

    Private Sub btAddInList_Click(sender As System.Object, e As System.EventArgs) Handles btAddInList.Click
        Me.Label1.BackColor = Control.DefaultBackColor
        If Me.lbSamplesList.SelectedItem Is Nothing Then
            'выбрать список
            If Me.lbSamplesList.Items.Count = 0 Then
                'create new list
                btCreateList_Click(Me, EventArgs.Empty)
                Me.lbSamplesList.SelectedIndex = 0
            End If
        End If

        If Me.oActiveSample Is Nothing Then
            Me.oActiveSample = clsApplicationTypes.clsSampleNumber.CreateFromString(InputBox("Добавить номер ", "Добавление номера"))
        End If

ret:
        Select Case Me.oSampleListManager.AddSampleInList(Me.oActiveList, Me.oActiveSample)
            Case 0
                Select Case MsgBox("Не удалось добавить образец, он уже есть в списке, ввести номер вручную?", MsgBoxStyle.YesNo)
                    Case MsgBoxResult.Yes
                        Me.oActiveSample = clsApplicationTypes.clsSampleNumber.CreateFromString(InputBox("Добавить номер ", "Добавление номера"))
                        GoTo ret
                End Select
            Case 1
                'работа с листбоксом образцов
                Dim t = oSampleListManager.GetSampleItemFromList(oActiveList, oActiveSample)
                Me.lbSamplesInList.Items.Add(t.ShotNumber + cntSeparator + t.DateOfCreate.ToShortDateString)
                Me.btSaveLists.ForeColor = Color.Red
                MsgBox("Образец добавлен", MsgBoxStyle.Information)
            Case -1
                MsgBox("Не удалось добавить образец, ошибка", MsgBoxStyle.Critical)
        End Select


    End Sub

    Private Const cntSeparator As String = " --> "

    Private Sub btRemoveFromList_Click(sender As Object, e As EventArgs) Handles btRemoveFromList.Click
        Dim _name As String = Me.oActiveList
        If _name = "" Then Exit Sub
        If Me.lbSamplesInList.SelectedItems.Count <= 0 Then
            MsgBox("Необходимо выбрать образцы для удаления из списка!", vbCritical)
            Exit Sub
        End If

        Dim _selectedShot = (From c As String In Me.lbSamplesInList.SelectedItems Select c.Split(" ".ToCharArray, System.StringSplitOptions.RemoveEmptyEntries).First).ToList

        Select MsgBox("Удалить " & _selectedShot.Count & " образцов. " & String.Join(", ", _selectedShot), vbYesNo)
            Case MsgBoxResult.Yes
                For Each t In _selectedShot
                    Me.oSampleListManager.RemoveSampleFromList(_name, clsSampleNumber.CreateFromString(t))
                Next
                'установить в листбокс образцы
                Me.lbSamplesInList.Items.Clear()
                For Each t In oSampleListManager.GetListByName(oActiveList)
                    Me.lbSamplesInList.Items.Add(t.ShotNumber + cntSeparator + t.DateOfCreate.ToShortDateString)
                Next
                Me.btSaveLists.ForeColor = Color.Red
                Me.ActiveSample = Nothing

        End Select



    End Sub

    Private Sub btSaveSelectedListToCSV_Click(sender As Object, e As EventArgs) Handles btSaveSelectedListToCSV.Click
        'If Me.lbSamplesList.SelectedItem Is Nothing Then Exit Sub
        If Me.ActiveList = "" Then Exit Sub
        Dim _fm = New fmCSVExport(Me.oSampleListManager.GetListByName(Me.ActiveList))
        _fm.Show()
    End Sub
    Private Sub btSaveLists_Click(sender As Object, e As EventArgs) Handles btSaveLists.Click
        Me.oSampleListManager.Save()
        Me.btSaveLists.ForeColor = Control.DefaultForeColor
    End Sub

    Private Sub btClearListCollection_Click(sender As Object, e As EventArgs) Handles btClearListCollection.Click
        Me.oSampleListManager.ClearListCollection()
        Me.ActiveList = ""
        Me.ActiveSample = Nothing
        Me.lbSamplesList.DataSource = Me.oSampleListManager.GetNames
    End Sub
    ''' <summary>
    ''' будет загружен файл из settings
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()

        ' Этот вызов является обязательным для конструктора.
        InitializeComponent()
        ' Добавьте все инициализирующие действия после вызова InitializeComponent().
        oFileName = ""
        init()
    End Sub
    ''' <summary>
    ''' FileName - файл списков
    ''' </summary>
    ''' <param name="FileName"></param>
    ''' <remarks></remarks>
    Public Sub New(FileName As String)
        ' Этот вызов является обязательным для конструктора.
        InitializeComponent()
        ' Добавьте все инициализирующие действия после вызова InitializeComponent().
        oFileName = FileName
        init()
        Me.ControlBox = True
    End Sub
    ''' <summary>
    ''' регистрирует вызвавшую форму на события
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub init()
        If lbSamplesList.Items.Count = 0 Then
            'load list
            If Not oFileName = "" Then
                oSampleListManager = Service.clsSampleListManager.CreateInstance(oFileName)
            Else
                oSampleListManager = Service.clsSampleListManager.CreateInstance()
            End If

            If oSampleListManager Is Nothing Then
                MsgBox("Не удалось загрузить/создать файл списков!", MsgBoxStyle.Critical)
                Exit Sub
            End If
            lbSamplesList.DataSource = oSampleListManager.GetNames
            Me.btCreateList.Enabled = True
            Me.btAddInList.Enabled = True
            Me.btRemoveFromList.Enabled = True
            Me.btSaveSelectedListToCSV.Enabled = True
        End If
        ' ''ограничить работников
        'Select Case clsApplicationTypes.ActiveUser
        '    Case emUsers.PhotoWoker, emUsers.PetrogradkaWoker, emUsers.NarvaWoker
        '        Me.btSaveSelectedListToCSV.Enabled = False
        '        Me.ControlBox = False
        'End Select
    End Sub

    Private oFileName As String

    ''' <summary>
    ''' добавить образец, который подтвердила другая форма
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub AddSample(sender As Object, e As Service.clsWriteSampleToListEventsArg)
        Me.ActiveSample = e.SampleNumber
        If e.AutoWrite Then
            btAddInList_Click(sender, EventArgs.Empty)
            Me.Label1.BackColor = Control.DefaultBackColor
        End If
    End Sub
    Private oActiveSample As clsSampleNumber
    Private oActiveList As String

    Private Property ActiveList As String
        Get
            Return oActiveList
        End Get
        Set(value As String)
            oActiveList = value
            Me.Label2.Text = value
            'установить в листбокс образцы
            Me.lbSamplesInList.Items.Clear()
            Dim _lists = oSampleListManager.GetListByName(oActiveList)
            If _lists Is Nothing OrElse _lists.Count = 0 Then
                'Debug.Fail("попытка усановить активным несуществующий список!")
            Else
                For Each t In _lists
                    Me.lbSamplesInList.Items.Add(t.ShotNumber + " --> " + t.DateOfCreate.ToShortDateString)
                Next
            End If
        End Set
    End Property

    Private Property ActiveSample As clsSampleNumber
        Get
            Return oActiveSample
        End Get
        Set(value As clsSampleNumber)
            oActiveSample = value
            If oActiveSample Is Nothing Then
                Me.Label1.Text = ""
                Me.Label3.Text = ""
            Else
                Me.Label1.Text = oActiveSample.ShotCode
                If Me.oSampleListManager.ContainsInList(Me.ActiveList, Me.ActiveSample) Then
                    Me.Label1.BackColor = Color.Green
                    Dim _result = Me.oSampleListManager.GetSampleItemFromList(Me.oActiveList, Me.oActiveSample)
                    If Not _result Is Nothing Then
                        If Not _result.Name Is Nothing AndAlso _result.Name.Length > 0 Then
                            Me.Label3.Text = _result.Name
                        ElseIf Not _result.NickName Is Nothing AndAlso _result.NickName.ToString.Length > 0 Then
                            Me.Label3.Text = _result.NickName
                        Else
                            Me.Label3.Text = ""
                        End If
                    Else
                        Me.Label3.Text = ""
                    End If

                Else
                    Me.Label1.BackColor = Color.Red
                    Me.Label3.Text = ""
                End If




            End If

        End Set
    End Property

    ''' <summary>
    ''' процедура регистрации формы-источника
    ''' </summary>
    ''' <param name="fm"></param>
    ''' <remarks></remarks>
    Public Sub RegisterForm(fm As Windows.Forms.Form)
        If TypeOf fm Is Service.iListSampleDataProvider Then
            Dim _fm = CType(fm, Service.iListSampleDataProvider)
            'проверка повторной регистрации
            If EventHandlerList.Contains(fm.GetHashCode) Then Exit Sub
            AddHandler _fm.WriteSampleToList, AddressOf AddSample

            EventHandlerList.Add(fm.GetHashCode)
        End If
    End Sub
    ''' <summary>
    ''' процедура отмены регистрации формы-источника
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub UnRegisterAnyForm()
        EventHandlerList.Clear()

        'If TypeOf fm Is Service.iListSampleDataProvider Then
        '    Dim _fm = CType(fm, Service.iListSampleDataProvider)
        '    'проверка  регистрации
        '    If Not EventHandlerList.Contains(fm.GetHashCode) Then Exit Sub
        '    RemoveHandler _fm.WriteSampleToList, AddressOf AddSample
        '    EventHandlerList.Remove(fm.GetHashCode)
        'End If
    End Sub
    ''' <summary>
    ''' список форм, зарегестрированных как источники номеров
    ''' </summary>
    ''' <remarks></remarks>
    Private EventHandlerList As New List(Of Integer)

    Private Sub lbSamplesList_DoubleClick(sender As Object, e As EventArgs) Handles lbSamplesList.DoubleClick
        ' If Me.lbSamplesList.SelectedItem Is Nothing Then Exit Sub
        'If Me.ActiveList = "" Then Exit Sub
        'Dim _name As String = Me.ActiveList
        'Dim _param As Object = {Me.oSampleListManager.GetEAN13Collection(_name), "Образцы списка " & _name}
        'Dim _fm As Object = Service.clsApplicationTypes.DelegateStoreApplicationForm(clsApplicationTypes.emFormsList.fmSampleList).Invoke(_param)
        'If _fm Is Nothing Then
        '    Exit Sub
        'End If
        '_fm.ShowDialog(Me)
        'Dim _result = _fm.SelectedNumber
        'If Not _result = "" Then
        '    Me.ActiveSample = clsSampleNumber.CreateFromString(_result)

        'End If
    End Sub


    Private Sub lbSamplesList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbSamplesList.SelectedIndexChanged
        Me.ActiveList = lbSamplesList.SelectedItem
        Me.ActiveSample = Me.oActiveSample
    End Sub

    Private Sub btClearActiveList_Click(sender As Object, e As EventArgs) Handles btClearActiveList.Click
        Me.oSampleListManager.ClearList(Me.ActiveList)
        Me.ActiveSample = Nothing
    End Sub
    Private Sub fmListManager_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Me.btSaveLists.ForeColor = Color.Red Then
            Me.btSaveLists_Click(Me, EventArgs.Empty)
        End If
    End Sub

    Private Sub lbSamplesInList_DoubleClick(sender As Object, e As EventArgs) Handles lbSamplesInList.DoubleClick
        'покажем инфо по номеру
        Dim _item = lbSamplesInList.SelectedItem.ToString.Split(" ")

        If _item.Length > 0 Then
            Dim _number = clsApplicationTypes.clsSampleNumber.CreateFromString(_item(0))
            If Not _number Is Nothing Then
                Dim _info = _number.GetExtendedInfo
                MsgBox(_info.AnyName & ChrW(13) & _info.DescriptionString, MsgBoxStyle.Information)
            End If
        End If

    End Sub

    Private Sub lbSamplesInList_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lbSamplesInList.SelectedIndexChanged
        'покажем инфо по номеру
        Dim _item = lbSamplesInList.SelectedItem.ToString.Split(" ")

        If _item.Length > 0 Then
            Dim _number = clsApplicationTypes.clsSampleNumber.CreateFromString(_item(0))
            If Not _number Is Nothing Then
                Me.ActiveSample = _number
            End If
        End If
    End Sub
End Class