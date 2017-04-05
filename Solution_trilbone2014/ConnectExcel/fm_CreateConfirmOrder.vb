Public Class fm_CreateConfirmOrder
    Public Event OnOrderSelected(ByVal sender As Object, ByVal value As uc_Sample_data.ConfirmOrder)
    'Dim _out As String = InputBox("Новый заказ", "Введите: Имя_клиента|Валюта|Дата|Общая_ сумма. При пустых значениях ввести пробел! Разделители оставить!", " | | | ")
    'Dim _values() As String = _out.Split("|")
    'If _values Is Nothing OrElse _values.Length = 0 OrElse _values.Length <> 4 Then
    '    'введено не верно
    '    MsgBox("Заказ не принят!", vbCritical)
    '    Exit Sub
    'Else
    '    Dim _order As New ConfirmOrder
    '    Try
    '        With _order
    '            .ClientName = _values(0)
    '            .Currency = _values(1)
    '            .OrderDate = CType(_values(2), Date)
    '            .TotalAmount = CType(_values(3), Decimal)
    '            .ConfirmOrderID = 0
    '            .NeedCall = True
    '        End With
    '    Catch ex As InvalidCastException
    '        'введено не верно
    '        MsgBox("Заказ не принят!", vbCritical)
    '        Exit Sub
    '    End Try

    '    'all ok
    '    Me.Order = _order

    'End If


    Private Sub btCreate_Order_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCreate_Order.Click
        Dim _order As New uc_Sample_data.ConfirmOrder
        Try
            With _order
                .ClientName = Me.cb_clients.Text
                .Currency = Me.cb_Currency.Text
                .OrderDate = Me.dtp_OrderDate.Value
                .TotalAmount = CType(Me.tb_Order_total.Text, Decimal)
                .ConfirmOrderID = 0
                .NeedCall = True
            End With

        Catch ex As InvalidCastException
            'введено не верно
            MsgBox("Заказ не принят!", vbCritical)
            Exit Sub
        End Try

        'all ok
        Me.ToolStripStatusLabel1.Text = "OrderCreated"
        RaiseEvent OnOrderSelected(Me, _order)

    End Sub

    Private Sub bt_newClient_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_newClient.Click
        'TODO GetClientsForm

    End Sub

    Private Sub btSelect_Order_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSelect_Order.Click
        'TODO SelectOrderFromTable

    End Sub
End Class