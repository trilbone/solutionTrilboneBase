Public Class fmClients
    Private oNewClientID As Decimal

    Private Sub ClientsBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClientsBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.ClientsBindingSource.EndEdit()
        Dim _chn As Data.DataTable = Me.DsClients.Clients.GetChanges

        If Not _chn Is Nothing Then
            For Each _row As Data.DataRow In _chn.Rows
                If _row.RowState = DataRowState.Added Then
                    oNewClientID = _row.Item("ClientID")
                End If
            Next
        End If

        MsgBox("Update " & Me.TableAdapterManager.UpdateAll(Me.DsClients) & " records in client table.")

    End Sub

    Private Sub fmClients_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'window position
        If Not Me.ParentForm Is Nothing Then
            Me.Location = New Point(Me.ParentForm.ClientRectangle.Left, Me.ParentForm.ClientRectangle.Top)
        Else
            Me.StartPosition = FormStartPosition.CenterScreen
        End If

        Me.ClientsTableAdapter.Fill(Me.DsClients.Clients)
        Me.DsClients.Clients.ClientIDColumn.AutoIncrement = True
        Dim _count As Integer = Me.DsClients.Clients.Rows.Count
        Dim _lastID As Decimal = Me.DsClients.Clients.Item(_count - 1).ClientID
        Me.DsClients.Clients.ClientIDColumn.AutoIncrementSeed = _lastID + 1
        Me.DsClients.Clients.ClientIDColumn.AutoIncrementStep = 1
    End Sub

    Public ReadOnly Property NewClientID As Decimal
        Get
            Return oNewClientID
        End Get
    End Property

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub ClientsBindingSource_CurrentChanged(sender As System.Object, e As System.EventArgs) Handles ClientsBindingSource.CurrentChanged

    End Sub
End Class
