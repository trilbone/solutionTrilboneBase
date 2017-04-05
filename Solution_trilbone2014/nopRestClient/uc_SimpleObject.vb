Imports nopTypes.Nop.Plugin.Misc.panoRazziRestService
Imports System.ComponentModel

Public Class uc_SimpleObject
    Private oCaption As String
    Private oDataLang As lng = lng.enUS
    Private oSelected As clsLangObjectCollection
    Private oGroupName As String

    Public Sub New()

        ' Этот вызов является обязательным для конструктора.
        InitializeComponent()

        ' Добавьте все инициализирующие действия после вызова InitializeComponent().
        oSelected = clsLangObjectCollection.CreateInstance("LangObjects")
    End Sub


#Region "Enabled for visual constructor"
    Public Property UcCaption As String
        Get
            Return Me.lb_objectName.Text
        End Get
        Set(value As String)
            Me.lb_objectName.Text = value
            oCaption = value
        End Set
    End Property
#End Region

#Region "Data bindings"
    ''' <summary>
    '''
    ''' </summary>
    ''' <param name="lang"></param>
    ''' <param name="GroupName"></param>
    ''' <param name="PresetValues"></param>
    ''' <remarks></remarks>
    Public Sub Init(lang As lng, GroupName As String, Optional PresetValues() As String = Nothing)
        oDataLang = lang
        Me.lb_objectName.Text = oCaption & String.Format("({0})", [Enum].GetName(GetType(lng), oDataLang).Substring(0, 2))
        oGroupName = GroupName
        oSelected = clsLangObjectCollection.CreateInstance(oGroupName)
        Me.LangObjBindingSourceSelected.DataSource = oSelected
        AddHandler oSelected.PropertyChanged, AddressOf oSelected_PropertyChanged

        If Not PresetValues Is Nothing Then
            Me.LangObjBindingSourceSelected.SuspendBinding()
            For Each t In PresetValues
                'create new object with specific lang value
                Dim _obj = LangObject.CreateInstance(oGroupName, t)
                _obj.AddItem(New LangObjItem With {.lang = oDataLang, .Value = t})
                'проверка наличия в списке
                If Me.LangObjBindingSourceSelected.Contains(_obj) Then Continue For
                'добавить в выбранные
                Me.LangObjBindingSourceSelected.Add(_obj)
            Next
            Me.LangObjBindingSourceSelected.ResumeBinding()
        End If

        If Not PresetValues Is Nothing Then
            ' Me.LangObjBindingSourceSelected.ResetBindings(False)
            RaiseEvent ObjectListChanged(Me, EventArgs.Empty)
        End If

    End Sub
#End Region

#Region "Выбранные данные"
    ''' <summary>
    ''' выбранные значения
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
        If Me.LangObjBindingSourceSelected.DataSource Is Nothing Then Return
        If String.IsNullOrEmpty(value) Then Return
        If value.Length > 50 Then
            MsgBox("Вставляемая строка слишком велика (более 50 символов)", vbCritical)
            Return
        End If
        Dim _new = LangObject.CreateInstance(oGroupName, value)
        If Not CType(Me.LangObjBindingSourceSelected.DataSource, clsLangObjectCollection).Contains(_new) Then
            'и отсутствующие в левом
            Me.LangObjBindingSourceSelected.Add(_new)
        End If
        Me.lbl_Selected.Text = String.Format("Выбраны({0})", Me.LangObjBindingSourceSelected.Count)
    End Sub



    ''' <summary>
    ''' добавит значения в выбранные (список выбранных содержится только внутри класса)
    ''' </summary>
    ''' <param name="collection"></param>
    ''' <remarks></remarks>
    Public Sub AddPreSelected(collection As IEnumerable(Of LangObject))
        If Me.LangObjBindingSourceSelected.DataSource Is Nothing Then Return
        For Each t In collection
            If Not CType(Me.LangObjBindingSourceSelected.DataSource, clsLangObjectCollection).Contains(t) Then
                'и отсутствующие в списке
                Me.LangObjBindingSourceSelected.Add(t)
            End If
        Next
        '  Me.LangObjBindingSourceSelected.ResetBindings(False)
    End Sub

    ''' <summary>
    ''' вернет XML
    ''' </summary>
    ''' <param name="rootTagName"></param>
    ''' <param name="TagName"></param>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property GetXML(rootTagName As String, TagName As String) As String
        Get
            Return oSelected.GetLangXML(oDataLang, rootTagName, TagName)
        End Get
    End Property

    ''' <summary>
    ''' Изменение списка выбранных значений
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Event ObjectListChanged(sender As Object, e As EventArgs)

    ''' <summary>
    ''' изменение элемента в списке выбранных
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Event SelectedItemChanged(sender As Object, e As SelectedItemEventArgs)

    Public Class SelectedItemEventArgs
        Inherits EventArgs
        Public Property Item As LangObject
    End Class


#End Region

#Region "обработка событий и бизнес логика"
    Private Sub bt_Add_Click(sender As Object, e As EventArgs) Handles bt_Add.Click
        If Me.LangObjBindingSourceSelected Is Nothing Then
            MsgBox("Необходима инициализация ЭУ (init)!!!", vbCritical)
            Return
        End If
        'create new object with specific lang value
        Dim _value = Me.tb_newText.Text
        If _value = "" Then Return
        Dim _obj = LangObject.CreateInstance(oGroupName, _value)
        _obj.AddItem(New LangObjItem With {.lang = oDataLang, .Value = _value})
        'проверка наличия в списке
        If Me.LangObjBindingSourceSelected.Contains(_obj) Then MsgBox("Уже присутствует в списке", MsgBoxStyle.OkOnly, "Добавление ключевого слова") : Return
        'добавить в выбранные
        Me.LangObjBindingSourceSelected.Add(_obj)
        'Me.LangObjBindingSourceSelected.ResetBindings(False)
        Me.lb_selected.SelectedIndex = -1
        Me.tb_newText.Text = ""
        Me.tb_newText.Focus()
        RaiseEvent ObjectListChanged(Me, EventArgs.Empty)
        Me.lbl_Selected.Text = String.Format("Выбраны({0})", Me.LangObjBindingSourceSelected.Count)
    End Sub

    Private Sub lb_Selected_MouseDoubleClick(sender As Object, e As Windows.Forms.MouseEventArgs) Handles lb_selected.MouseDoubleClick
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
        LangObjBindingSourceSelected_ListChanged(Me, New ListChangedEventArgs(ListChangedType.Reset, 0))
    End Sub

    Private Sub bt_remove_Click(sender As Object, e As EventArgs) Handles bt_remove.Click
        If Me.lb_selected.SelectedItem Is Nothing Then Return
        Me.LangObjBindingSourceSelected.Remove(Me.LangObjBindingSourceSelected.Current)
        RaiseEvent ObjectListChanged(Me, EventArgs.Empty)
        Me.lbl_Selected.Text = String.Format("Выбраны({0})", Me.LangObjBindingSourceSelected.Count)
    End Sub

    Private Sub oSelected_PropertyChanged(sender As Object, e As ComponentModel.PropertyChangedEventArgs)
        If e.PropertyName = "Count" Then
            Me.lbl_Selected.Text = String.Format("Выбраны({0})", Me.LangObjBindingSourceSelected.Count)
        End If
    End Sub

    Private Sub uc_langObject_KeyUp(sender As Object, e As Windows.Forms.KeyEventArgs) Handles Me.KeyUp, lb_selected.KeyUp, tb_newText.KeyUp
        If e.Control Then
            If e.KeyCode = Windows.Forms.Keys.V Then
                If My.Computer.Clipboard.ContainsText Then
                    Me.tb_newText.Text = My.Computer.Clipboard.GetText
                    bt_Add_Click(Me, e)
                End If
            End If
        End If
    End Sub


    Private Sub LangObjBindingSourceSelected_ListChanged(sender As Object, e As ComponentModel.ListChangedEventArgs) Handles LangObjBindingSourceSelected.ListChanged
        If LangObjBindingSourceSelected.DataSource Is Nothing Then Return
        'отобразить список в листбокс
        Me.lb_selected.Items.Clear()
        For Each t As LangObject In LangObjBindingSourceSelected
            Me.lb_selected.Items.Add(t.langValue(oDataLang))
        Next
    End Sub

    Private Sub lb_Selecteded_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lb_selected.SelectedIndexChanged
        'задать current в привязке
        Me.LangObjBindingSourceSelected.CurrencyManager.Position = lb_selected.SelectedIndex

        If lb_selected.SelectedIndex < 0 Then Return

        RaiseEvent SelectedItemChanged(Me, New SelectedItemEventArgs With {.Item = CType(lb_selected.SelectedItem, LangObject)})
    End Sub
#End Region
End Class
