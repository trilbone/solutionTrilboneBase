Imports nopTypes.Nop.Plugin.Misc.panoRazziRestService
Public Class fm_langobjadd

    Private Sub New()

        ' Этот вызов является обязательным для конструктора.
        InitializeComponent()

        ' Добавьте все инициализирующие действия после вызова InitializeComponent().

    End Sub
    ''' <summary>
    ''' для редактирования обьекта
    ''' </summary>
    ''' <param name="obj"></param>
    ''' <remarks></remarks>
    Public Sub New(ByRef obj As LangObject, enabled As Boolean)
        Me.New()
        Uc_LangEntity1.lb_ObjectName.Text = obj._groupName
        Uc_LangEntity1.tb_Invariant.Text = obj.InvariantValue
        Uc_LangEntity1.tb_English.Text = obj.langValue(lng.enUS)
        Uc_LangEntity1.tb_Russian.Text = obj.langValue(lng.ruRU)
        _obj = obj
        If Not enabled Then
            Uc_LangEntity1.tb_Invariant.Enabled = False
            Uc_LangEntity1.tb_English.Enabled = False
            Uc_LangEntity1.tb_Russian.Enabled = False
        End If
    End Sub


    Public Sub New(objectName As String, invariantDefaultValue As String)
        Me.New()
        Uc_LangEntity1.lb_ObjectName.Text = objectName
        Uc_LangEntity1.tb_Invariant.Text = invariantDefaultValue
    End Sub

    Public ReadOnly Property obj As LangObject
        Get
            Return _obj
        End Get
    End Property

    Private _obj As LangObject

    Private Sub Uc_LangEntity1_Complete(sender As Object, e As uc_LangEntity.LangEntityCompleteEventArgs) Handles Uc_LangEntity1.Complete
        _obj = e.obj
        RaiseEvent complete(Me, e)
        Me.Hide()
    End Sub
    Public Event complete(sender As Object, e As uc_LangEntity.LangEntityCompleteEventArgs)
End Class