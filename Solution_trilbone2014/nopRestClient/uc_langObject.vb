Imports nopTypes.Nop.Plugin.Misc.panoRazziRestService
Imports System.ComponentModel

Public Class uc_langObject

    Private oCaption As String
    Private oDataLang As lng = lng.enUS
    Private oGroupName As String
    Private oSelected As clsLangObjectCollection
    Private oData As clsLangObjectCollection
    ''' <summary>
    ''' для работы одной кнопки в двух направлениях
    ''' </summary>
    ''' <remarks></remarks>
    Private oSourceSelected As Boolean = True

#Region "Enabled for visual constructor"
    Public Property UcCaption As String
        Get
            Return Me.lb_Caption.Text
        End Get
        Set(value As String)
            Me.lb_Caption.Text = value
            oCaption = value
            Me.lbl_Source.Text = String.Format("Доступны({0})", Me.LangObjBindingSource.Count)
        End Set
    End Property

    Private oEnabledNew As Boolean = True

    Public Property EnabledNew As Boolean
        Get
            Return oEnabledNew
        End Get
        Set(value As Boolean)
            oEnabledNew = value
            If Not oEnabledNew Then
                Me.bt_createNew.Enabled = False
                Me.tb_NewText.Enabled = False
            Else
                Me.bt_createNew.Enabled = True
                Me.tb_NewText.Enabled = True
            End If
        End Set
    End Property

    Private oSingleSelect As Boolean = False
    ''' <summary>
    ''' если установлено, то нельзя выбирать более одного пункта
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SingleSelect As Boolean
        Get
            Return oSingleSelect
        End Get
        Set(value As Boolean)
            oSingleSelect = value
        End Set
    End Property

#End Region

    Public Sub New()

        ' Этот вызов является обязательным для конструктора.
        InitializeComponent()

        ' Добавьте все инициализирующие действия после вызова InitializeComponent().
        oData = clsLangObjectCollection.CreateInstance("LangObjects")
        oSelected = clsLangObjectCollection.CreateInstance("LangObjects")
    End Sub

#Region "Data bindings"
    ''' <summary>
    ''' dataLang = какая часть langobject отображается
    ''' </summary>
    ''' <param name="dataLang"></param>
    ''' <param name="DataSource"></param>
    ''' <remarks></remarks>
    Public Sub init(dataLang As lng, DataSource As clsLangObjectCollection)
        oDataLang = dataLang
        Me.lb_Caption.Text = oCaption & String.Format("({0})", [Enum].GetName(GetType(lng), oDataLang).Substring(0, 2))
        If DataSource Is Nothing Then
            Debug.Fail("нельзя передавать пустое значение")
            Me.LangObjBindingSource.DataSource = clsLangObjectCollection.CreateInstance("Default")
            Me.lb_Caption.Text = "ошибка"
            Return
        End If

        oData = DataSource
        'oData.Sort()
        oGroupName = DataSource._collectionName
        Me.LangObjBindingSource.DataSource = oData
        AddHandler oData.PropertyChanged, AddressOf oData_PropertyChanged

        oSelected = clsLangObjectCollection.CreateInstance(oGroupName)
        Me.LangObjBindingSourceSelected.DataSource = oSelected
        AddHandler oSelected.PropertyChanged, AddressOf oSelected_PropertyChanged


        Me.lbl_Source.Text = String.Format("Доступны({0})", Me.LangObjBindingSource.Count)
        Me.Refresh()
        Me.lb_exists.Focus()
        oSourceSelected = True
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="value"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ContainsInvariantValue(value As String) As Boolean
        If Me.LangObjBindingSourceSelected.DataSource Is Nothing Then Return False
        If String.IsNullOrEmpty(value) Then Return False
        If value.Length > 50 Then
            MsgBox("Вставляемая строка слишком велика (более 50 символов)", vbCritical)
            Return False
        End If
        If Me.LangObjBindingSourceSelected.Count = 0 Then Return False

        Dim _res = CType(Me.LangObjBindingSourceSelected.DataSource, clsLangObjectCollection).Where(Function(x) x.InvariantValue.Trim.ToLower.Equals(value.Trim.ToLower))

        If _res.Count = 0 Then Return False

        Return True
    End Function

    ''' <summary>
    ''' добавляет значение
    ''' </summary>
    ''' <param name="value"></param>
    ''' <remarks></remarks>
    Public Sub Insert(value As String)
        If Me.LangObjBindingSource.DataSource Is Nothing Then Return
        If String.IsNullOrEmpty(value) Then Return
        If value.Length > 50 Then
            MsgBox("Вставляемая строка слишком велика (более 50 символов)", vbCritical)
            Return
        End If

        Dim _new = LangObject.CreateInstance(oGroupName, value)
        Dim _res = CType(Me.LangObjBindingSource.DataSource, clsLangObjectCollection).Where(Function(x) x.InvariantValue.ToLower.Equals(_new.InvariantValue.ToLower))
        If _res.Count = 0 Then
            'значение отсутствует в источнике данных, добавим
            '  MsgBox("after LINQ В источнике " & Me.LangObjBindingSource.Count)
            Me.LangObjBindingSource.Add(_new)
            '  MsgBox("after ADD В источнике " & Me.LangObjBindingSource.Count)
            '  MsgBox(String.Format("Добавлен в {1} источник ({2}) : {0} ({3})", t.InvariantValue, Me.LangObjBindingSource.Count, CType(Me.LangObjBindingSource.DataSource, clsLangObjectCollection)._collectionName, t._groupName))
        End If
        'существующие в правом списке
        If Not CType(Me.LangObjBindingSourceSelected.DataSource, clsLangObjectCollection).Contains(_new) Then
            'и отсутствующие в левом
            Me.LangObjBindingSourceSelected.Add(_new)
        End If
        RefreshCaptions()
    End Sub


    ''' <summary>
    ''' добавит значения в выбранные (список выбранных содержится только внутри класса)
    ''' </summary>
    ''' <param name="collection"></param>
    ''' <remarks></remarks>
    Public Sub AddPreSelected(collection As IEnumerable(Of LangObject))
        If Me.LangObjBindingSource.DataSource Is Nothing Then Return
        For Each t In collection
            Dim _res = CType(Me.LangObjBindingSource.DataSource, clsLangObjectCollection).Where(Function(x) x.InvariantValue.ToLower.Equals(t.InvariantValue.ToLower))
            If _res.Count = 0 Then
                'значение отсутствует в источнике данных, добавим
                '  MsgBox("after LINQ В источнике " & Me.LangObjBindingSource.Count)
                Me.LangObjBindingSource.Add(t)
                '  MsgBox("after ADD В источнике " & Me.LangObjBindingSource.Count)
                '  MsgBox(String.Format("Добавлен в {1} источник ({2}) : {0} ({3})", t.InvariantValue, Me.LangObjBindingSource.Count, CType(Me.LangObjBindingSource.DataSource, clsLangObjectCollection)._collectionName, t._groupName))
            End If
            'существующие в правом списке
            If Not CType(Me.LangObjBindingSourceSelected.DataSource, clsLangObjectCollection).Contains(t) Then
                'и отсутствующие в левом
                Me.LangObjBindingSourceSelected.Add(t)
            End If
        Next

        RefreshCaptions()
    End Sub

    Public Sub RefreshSource()
        Me.LangObjBindingSource.ResetBindings(False)
        RefreshCaptions()
    End Sub

    Public Sub RefreshSelected()
        Me.LangObjBindingSourceSelected.ResetBindings(False)
        RefreshCaptions()
    End Sub

    Public ReadOnly Property DataSourceCount As Integer
        Get
            Return Me.LangObjBindingSource.Count
        End Get
    End Property


    ''' <summary>
    ''' очистит список выбранных обьектов
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ClearSelected()
        Me.LangObjBindingSourceSelected.Clear()
        Me.Refresh()
        RefreshCaptions()
    End Sub

    ''' <summary>
    ''' выбранные значения (изменить можно при помощи соотв. функций снаружи)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property SelectedObjects As clsLangObjectCollection
        Get
            Return oSelected
        End Get
    End Property
    ''' <summary>
    ''' Изменение списка выбранных значений
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Event ObjectListChanged(sender As Object, e As ItemEventArgs)

    ''' <summary>
    ''' изменение элемента в списке выбранных
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Event SelectedItemChanged(sender As Object, e As ItemEventArgs)
    Public Event SourceItemChanged(sender As Object, e As ItemEventArgs)

    Public Class ItemEventArgs
        Inherits EventArgs
        Public Property Item As LangObject = Nothing
        Public Property Added As Boolean = False
        Public Property Deleted As Boolean = False
    End Class

#End Region

#Region "обработка событий и бизнес логика"
    Private Sub bt_createNew_Click(sender As Object, e As EventArgs) Handles bt_createNew.Click
        'create new object
        If Me.LangObjBindingSource.DataSource Is Nothing Then Return

        Dim _fm = New fm_langobjadd(oGroupName, Me.tb_NewText.Text)
        _fm.StartPosition = Windows.Forms.FormStartPosition.CenterParent
        _fm.Location = Me.Location
        _fm.Location.Offset(Me.Width / 2, Me.Height / 2)
        _fm.ShowDialog()
        Dim _obj = _fm.obj
        If _obj Is Nothing Then Return

        If Me.LangObjBindingSourceSelected.Contains(_obj) Then MsgBox("Уже присутствует в списке выбранных", vbInformation) : Return
        If Me.LangObjBindingSource.Contains(_obj) Then MsgBox("Уже присутствует в списке доступных", vbInformation) : Return

        Me.LangObjBindingSource.Add(_obj)

        If (Me.SingleSelect = True) And (Me.LangObjBindingSourceSelected.Count = 1) Then
            'Выбрать можно только одно значение
        Else
            Me.LangObjBindingSourceSelected.Add(_obj)
            Me.lb_Selected.SelectedIndex = Me.lb_Selected.Items.Count - 1
            Me.lb_Selected.Focus()
            RaiseEvent ObjectListChanged(Me, New ItemEventArgs With {.Item = _obj, .Added = True})
        End If

        RefreshCaptions()
    End Sub

    Private Sub btAddRemove_Click(sender As Object, e As EventArgs) Handles btAddRemove.Click
        Select Case oSourceSelected
            Case True
                'from right listbox (доступные)
                If Me.lb_exists.SelectedIndex < 0 Then Return
                Dim _current = Me.LangObjBindingSource.Current
                If Me.LangObjBindingSourceSelected.Contains(_current) Then MsgBox("Уже присутствует в списке выбранных", vbInformation) : Return
                If oSingleSelect Then
                    If Me.LangObjBindingSourceSelected.Count = 1 Then
                        MsgBox(String.Format("Выбрать можно только одно значение"), vbCritical)
                        Return
                    End If
                End If
                Me.LangObjBindingSourceSelected.Add(_current)
                '  oSelected.Sort()
                ' Me.LangObjBindingSourceSelected.ResetBindings(False)

                If Not Me.lb_exists.SelectedIndex + 1 >= Me.lb_exists.Items.Count Then
                    Me.lb_exists.SelectedIndex += 1
                Else
                    'дошли до конца списка
                    Me.lb_exists.SelectedIndex = -1
                End If
                Me.lb_exists.Focus()
                RaiseEvent ObjectListChanged(Me, New ItemEventArgs With {.Item = _current, .Added = True})
            Case Else
                'from left listbox (выбранные)
                If Me.lb_Selected.SelectedIndex < 0 Then Return
                If Not Me.LangObjBindingSourceSelected.Contains(Me.LangObjBindingSourceSelected.Current) Then Return
                Dim _current = Me.LangObjBindingSourceSelected.Current

                Me.LangObjBindingSourceSelected.RemoveCurrent()

                If Me.lb_Selected.Items.Count = 0 Then
                    Me.lb_exists.SelectedIndex = 0
                    Me.lb_exists.Focus()
                Else
                    Me.lb_Selected.Focus()
                End If
                RaiseEvent ObjectListChanged(Me, New ItemEventArgs With {.Item = _current, .Deleted = True})
        End Select
        Me.lbl_Selected.Text = String.Format("Выбраны({0})", Me.LangObjBindingSourceSelected.Count)
    End Sub


    Private Sub lb_exists_LostFocus(sender As Object, e As EventArgs) Handles lb_exists.LostFocus
        oSourceSelected = True
    End Sub
    Private Sub lb_Selecteded_LostFocus(sender As Object, e As EventArgs) Handles lb_Selected.LostFocus
        oSourceSelected = False
    End Sub

    Private Sub lb_Selected_MouseDoubleClick(sender As Object, e As Windows.Forms.MouseEventArgs) Handles lb_Selected.MouseDoubleClick
        Dim _current As LangObject = Me.LangObjBindingSourceSelected.Current
        If _current Is Nothing Then Return

        Dim _fm = New fm_langobjadd(_current, True)
        _fm.StartPosition = Windows.Forms.FormStartPosition.CenterParent
        _fm.Location = Me.Location
        _fm.Location.Offset(Me.Width / 2, Me.Height / 2)
        _fm.ShowDialog()
        Dim _obj = _fm.obj
        If _obj Is Nothing Then Return
        With CType(Me.LangObjBindingSourceSelected.Current, LangObject)
            .InvariantValue = _obj.InvariantValue
            .langValue(lng.invariant) = _obj.langValue(lng.invariant)
            .langValue(lng.enUS) = _obj.langValue(lng.enUS)
            .langValue(lng.ruRU) = _obj.langValue(lng.ruRU)
        End With
        LangObjBindingSource_ListChanged(Me, New ListChangedEventArgs(ListChangedType.Reset, 0))
        LangObjBindingSourceSelected_ListChanged(Me, New ListChangedEventArgs(ListChangedType.Reset, 0))
    End Sub



    ''' <summary>
    ''' просмотреть текущий обьект
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub lb_exists_MouseDoubleClick(sender As Object, e As Windows.Forms.MouseEventArgs) Handles lb_exists.MouseDoubleClick
        Dim _current As LangObject = Me.LangObjBindingSource.Current
        If _current Is Nothing Then Return

        Dim _fm = New fm_langobjadd(_current, False)
        _fm.StartPosition = Windows.Forms.FormStartPosition.CenterParent
        _fm.Location = Me.Location
        _fm.Location.Offset(Me.Width / 2, Me.Height / 2)
        _fm.ShowDialog()
    End Sub

    ''' <summary>
    ''' выбрано значение в левом списке
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub lb_Selecteded_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lb_Selected.SelectedIndexChanged
        'задать current в привязке
        Me.LangObjBindingSourceSelected.CurrencyManager.Position = lb_Selected.SelectedIndex
        If Me.lb_Selected.SelectedIndex < 0 Then Return

        oSourceSelected = False
        Me.lb_exists.SelectedIndex = -1
        RaiseEvent SelectedItemChanged(Me, New ItemEventArgs With {.Item = CType(Me.LangObjBindingSourceSelected.Current, LangObject)})
    End Sub

    ''' <summary>
    ''' выбрано значение в правом списке
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub lb_exists_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lb_exists.SelectedIndexChanged
        'задать current в привязке
        Me.LangObjBindingSource.CurrencyManager.Position = lb_exists.SelectedIndex
        If lb_exists.SelectedIndex < 0 Then Return
        oSourceSelected = True
        Me.lb_Selected.SelectedIndex = -1
        RaiseEvent SourceItemChanged(Me, New ItemEventArgs With {.Item = CType(Me.LangObjBindingSource.Current, LangObject)})
    End Sub

    Public Sub RefreshCaptions()
        Me.lbl_Source.Text = String.Format("Доступны({0})", Me.LangObjBindingSource.Count)
        Me.lbl_Selected.Text = String.Format("Выбраны({0})", Me.LangObjBindingSourceSelected.Count)
    End Sub

    Private Sub oData_PropertyChanged(sender As Object, e As ComponentModel.PropertyChangedEventArgs)
        If e.PropertyName = "Count" Then
            Me.lbl_Source.Text = String.Format("Доступны({0})", Me.LangObjBindingSource.Count)
        End If
    End Sub

    Private Sub oSelected_PropertyChanged(sender As Object, e As ComponentModel.PropertyChangedEventArgs)
        If e.PropertyName = "Count" Then
            Me.lbl_Selected.Text = String.Format("Выбраны({0})", Me.LangObjBindingSourceSelected.Count)
        End If
    End Sub


    Private Sub LangObjBindingSource_ListChanged(sender As Object, e As ComponentModel.ListChangedEventArgs) Handles LangObjBindingSource.ListChanged
        If LangObjBindingSourceSelected.DataSource Is Nothing Then Return
        'отобразить список в листбокс
        Me.lb_exists.Items.Clear()
        For Each t As LangObject In LangObjBindingSource
            Dim _value = t.langValue(oDataLang)
            ' MsgBox(_value)
            Me.lb_exists.Items.Add(_value)
        Next
    End Sub

    Private Sub LangObjBindingSourceSelected_ListChanged(sender As Object, e As ComponentModel.ListChangedEventArgs) Handles LangObjBindingSourceSelected.ListChanged
        If LangObjBindingSourceSelected.DataSource Is Nothing Then Return
        'отобразить список в листбокс
        Me.lb_Selected.Items.Clear()
        For Each t As LangObject In LangObjBindingSourceSelected
            Me.lb_Selected.Items.Add(t.langValue(oDataLang))
        Next
    End Sub
#End Region

End Class
