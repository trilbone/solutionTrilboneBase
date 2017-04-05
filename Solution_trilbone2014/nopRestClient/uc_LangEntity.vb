Imports nopTypes.Nop.Plugin.Misc.panoRazziRestService

Public Class uc_LangEntity
    Public Property ObjectName As String
        Get
            Return Me.lb_ObjectName.Text
        End Get
        Set(value As String)
            Me.lb_ObjectName.Text = value
        End Set
    End Property

    Private Sub bt_Save_Click(sender As Object, e As EventArgs) Handles bt_Save.Click
        If Me.tb_Invariant.Text = "" Then
            MsgBox("Необходимо заполнить поле Invariant", vbCritical)
            Return
        End If
        Dim _out = New LangObject
        _out.AddItem(New LangObjItem With {.lang = lng.invariant, .Value = Me.tb_Invariant.Text})
        _out.InvariantValue = Me.tb_Invariant.Text
        _out._groupName = Me.lb_ObjectName.Text
        If Not Me.tb_Russian.Text = "" Then
            _out.AddItem(New LangObjItem With {.lang = lng.ruRU, .Value = Me.tb_Russian.Text})
        End If
        If Not Me.tb_English.Text = "" Then
            _out.AddItem(New LangObjItem With {.lang = lng.enUS, .Value = Me.tb_English.Text})
        End If
        RaiseEvent Complete(Me, New LangEntityCompleteEventArgs With {.obj = _out})
    End Sub

    Public Event Complete(sender As Object, e As EventArgs)

    Public Class LangEntityCompleteEventArgs
        Inherits EventArgs
        Public Property obj As LangObject
    End Class
End Class
