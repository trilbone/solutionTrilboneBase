Imports nopTypes.Nop.Plugin.Misc.panoRazziRestService

Public Class uc_ACL

    Dim oSelected As clsProductACL

    Public Sub New()

        ' Этот вызов является обязательным для конструктора.
        InitializeComponent()

        ' Добавьте все инициализирующие действия после вызова InitializeComponent().

    End Sub

    Private Property oDefaultLang As lng

    Public ReadOnly Property SelectedObjects As clsProductACL
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
    Public Event ObjectListChanged(sender As Object, e As EventArgs)
    Private ocustomerRoles As clsCustomerRolesCollection
    Private ostores As clsStoresCollection


    Public Function GetXML() As String
        If oSelected Is Nothing Then Return "no selected"
        Return oSelected.GetXML
    End Function

    Public Sub init(lang As lng, customerRoles As clsCustomerRolesCollection, stores As clsStoresCollection)
        oDefaultLang = lang
        ocustomerRoles = customerRoles
        ostores = stores
        Me.Uc_langObjectRoles.init(lang, customerRoles)

        'добавить предопределенные роли клиентов
        'по умолчанию добавляются: роли=Администраторы, Хранитель  магазины=Custodian
        Dim _adminRole = ocustomerRoles.FirstOrDefault(Function(x) x.InvariantValue.Contains("Администраторы"))
        Dim _custodianRole = ocustomerRoles.FirstOrDefault(Function(x) x.InvariantValue.Contains("Хранитель"))

        Me.Uc_langObjectStore.init(lang, stores)
        'Dim _dealerShop = stores.FirstOrDefault(Function(x) x.InvariantValue.Contains("Dealer"))
        Dim _custodianShop = stores.FirstOrDefault(Function(x) x.InvariantValue.Contains("Custodian"))

        oSelected = clsProductACL.CreateInstance

        'добавить роли
        If Not _adminRole Is Nothing Then
            Me.Uc_langObjectRoles.AddPreSelected({_adminRole})
            oSelected.CustomerRolesACL.AddRange({_adminRole})
        End If

        If Not _custodianRole Is Nothing Then
            Me.Uc_langObjectRoles.AddPreSelected({_custodianRole})
            oSelected.CustomerRolesACL.AddRange({_custodianRole})
        End If

        If Not _custodianShop Is Nothing Then
            Me.Uc_langObjectStore.AddPreSelected({_custodianShop})
            oSelected.StoresACL.AddRange({_custodianShop})
        End If

        RaiseEvent ObjectListChanged(Me, EventArgs.Empty)
    End Sub

    Private Sub Uc_langObjectRoles_ObjectListChanged(sender As Object, e As uc_langObject.ItemEventArgs) Handles Uc_langObjectRoles.ObjectListChanged
        If e.Added = True Then
            oSelected.CustomerRolesACL.AddRange({e.Item})
        End If
        If e.Deleted = True Then
            oSelected.CustomerRolesACL.Remove(e.Item)
        End If
        RaiseEvent ObjectListChanged(Me, EventArgs.Empty)
    End Sub

    Private Sub Uc_langObjectStore_ObjectListChanged(sender As Object, e As uc_langObject.ItemEventArgs) Handles Uc_langObjectStore.ObjectListChanged
        If e.Added = True Then
            oSelected.StoresACL.AddRange({e.Item})
        End If
        If e.Deleted = True Then
            oSelected.StoresACL.Remove(e.Item)
        End If
        ' oSelected.StoresACL.AddRange(Uc_langObjectStore.SelectedObjects)
        RaiseEvent ObjectListChanged(Me, EventArgs.Empty)
    End Sub

End Class
