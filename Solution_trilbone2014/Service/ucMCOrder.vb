Imports Service.Agents
Imports Service.ucGoodList
Imports System.Linq
Imports System.Windows.Forms

Public Class ucMCOrder
    Private oAgent As AUCTIONDATAAGENT
    Private oMsi As iMoySkladDataProvider
    Private oCustomer As iMoySkladDataProvider.clsClientInfo
    Private oGoodList As List(Of iMoySkladDataProvider.clsPosition)
    Private oOrder As iMoySkladDataProvider.clsOperationInfo
    Private oDemand As iMoySkladDataProvider.clsOperationInfo
    Public Event OrderCreated(sender As Object, e As OrderCreatedEventArgs)
    Public Class OrderCreatedEventArgs
        Inherits EventArgs
        Property Demand As iMoySkladDataProvider.clsOperationInfo
        Property Order As iMoySkladDataProvider.clsOperationInfo
        Property OrderCurrency As String
        Property OrderAmount As Decimal
        Property GoodList As List(Of iMoySkladDataProvider.clsPosition)
    End Class

    Public Sub init(Agent As AUCTIONDATAAGENT, msi As iMoySkladDataProvider, Customer As iMoySkladDataProvider.clsClientInfo)
        oMsi = msi
        oAgent = Agent
        oCustomer = Customer

        Me.lbWokers.DataSource = New BindingSource(oMsi.GetTriboneWoker, Nothing)
        Me.lbWokers.DisplayMember = "Value"
        Me.lbWokers.ValueMember = "Key"

    End Sub

    ''' <summary>
    ''' снимает образец с аукциона в МС
    ''' </summary>
    ''' <remarks></remarks>
    Private Function EndSampleOnAuction(shotCode As String) As Boolean
        Dim _ReservCustomerOrderUUID = oAgent.GetAgentID("moysklad", "ReservCustomerOrderUUID")
        Dim _good = oMsi.EndSampleOnAuction(GoodCode:=shotCode, ReservCustomerOrderUUID:=_ReservCustomerOrderUUID)

        If String.IsNullOrEmpty(_good) Then
            'lbGoodUUID.Text = "Образец не снят с аукциона"
            Return False
        End If
        'lbGoodUUID.Text = "Образец снят с аукциона"
        Return True
    End Function

    Private Sub tbCreateOrder_Click(sender As Object, e As EventArgs) Handles tbCreateOrder.Click
        'заказ
        Dim _CurrencyUUID = oMsi.GetCurrencyUUIDByName(cbCurrency.SelectedItem)
        Dim _MyCompanyUUID = oAgent.GetAgentID("moysklad", "MyCompanyUUID")
        Dim _ProjectUUID = oAgent.GetAgentID("moysklad", "ProjectUUID")
        Dim _Orderstate1UUID = oAgent.GetAgentID("moysklad", "Orderstate1")
        Dim _ShippingInGoodUUID = oAgent.GetAgentID("moysklad", "ShippingIn")
        Dim _WokerUUID = clsApplicationTypes.CurrentUser.UserPermission.mcuuid 'связать текущего пользователя приложения с его UUID в МС

        Dim _GoodsAmounts As Decimal() = (From c In oGoodList Select c.BasePriceInCurrency).ToArray
        Dim _GoodsUUIDs As String() = (From c In oGoodList Select c.goodUuid).ToArray
        Dim _GoodsQtys As Decimal() = (From c In oGoodList Select c.quantity).ToArray


        Dim _ShippingInAmount As Decimal = 0
        Dim _HandlingTime As Integer = oAgent.GetAgentID("moysklad", "HandlingTime")
        Dim _Description As String = "Запись продажи из формы МС: " ' & cbPlace.Text

        Dim _amount As Decimal = Aggregate c In Me.oGoodList Into Sum(c.BasePriceInCurrency)

        oOrder = oMsi.CreateCustomerOrder(GoodsUUIDs:=_GoodsUUIDs, GoodsQtys:=_GoodsQtys, GoodsAmounts:=_GoodsAmounts, CurrencyUUID:=_CurrencyUUID, CustomerUUID:=oCustomer.UUID, MyCompanyUUID:=_MyCompanyUUID, WokerUUID:=_WokerUUID, ProjectUUID:=_ProjectUUID, Orderstate1UUID:=_Orderstate1UUID, ShippingInGoodUUID:=_ShippingInGoodUUID, ShippingInAmount:=_ShippingInAmount, ShippingInQty:=1, HandlingTime:=_HandlingTime, Description:=_Description)

        If Not oOrder Is Nothing Then
            clsApplicationTypes.BeepYES()

        End If
    End Sub

    Private Sub btDemand_Click(sender As Object, e As EventArgs) Handles btDemand.Click
        Dim _StateUUID = oAgent.GetAgentID("moysklad", "Demandstate1")
        Dim _InvocePaymentTypeUUID = oAgent.GetAgentID("moysklad", "InvocePaymentType")
        ' Dim _EbayFeeEndGoodUUID = oAgent.GetValue("moysklad", "EbayFeeEnd")
        Dim _MyCompanyUUID = oAgent.GetAgentID("moysklad", "MyCompanyUUID")
        Dim _CurrencyUUID = oMsi.GetCurrencyUUIDByName(cbCurrency.SelectedItem)
        Dim _ProjectUUID = oAgent.GetAgentID("moysklad", "ProjectUUID")

        ' Dim _ShippingInGoodUUID = oAgent.GetValue("moysklad", "ShippingIn")

        'где???по первому товару
        Dim _Warehouse = oMsi.GetWarehouse(Me.oGoodList.First.goodUuid)

        'доп платежи
        'Dim _EbayFeeEndAmount = clsApplicationTypes.ReplaceDecimalSplitter(tbEbayFeeAmount)
        'Dim _tbPayPalFeeAmount = clsApplicationTypes.ReplaceDecimalSplitter(tbPayPalFeeAmount)
        'Dim _ShippingInAmount As Decimal = clsApplicationTypes.ReplaceDecimalSplitter(ValueTextBox2)
        'Dim _PayPalStartFeeGoodUUID = oAgent.GetValue("moysklad.PayPal", "PayPalStrartFee " & oPayPalEmailAddress)
        'отгрузка

        Dim _GoodsAmounts As Decimal() = (From c In oGoodList Select c.BasePriceInCurrency).ToArray
        Dim _GoodsUUIDs As String() = (From c In oGoodList Select c.goodUuid).ToArray
        Dim _GoodsQtys As Decimal() = (From c In oGoodList Select c.quantity).ToArray
        Dim _Description = "Запись продажи из формы МС: " ' & cbPlace.Text

        For Each t In oGoodList
            'снять с резервации (?? это только ебай)
            EndSampleOnAuction(t.ActualCode)
        Next

        oDemand = oMsi.CreateDemand(MyCompanyUUID:=_MyCompanyUUID, CurrencyUUID:=_CurrencyUUID, CustomerUUID:=oCustomer.UUID, ProjectUUID:=_ProjectUUID, StateUUID:=_StateUUID, WarehouseUUID:=_Warehouse.UUID, GoodsUUIDs:=_GoodsUUIDs, GoodsQtys:=_GoodsQtys, GoodsAmounts:=_GoodsAmounts, InvocePaymentTypeUUID:=_InvocePaymentTypeUUID, Description:=_Description, Applicable:=False)

        If Not oDemand Is Nothing Then
            clsApplicationTypes.BeepYES()
            RaiseEvent OrderCreated(Me, New OrderCreatedEventArgs With {.Order = oOrder, .OrderAmount = 0, .OrderCurrency = Me.cbCurrency.SelectedItem, .GoodList = oGoodList, .Demand = oDemand})

        End If
    End Sub

    Private Sub lbWokers_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbWokers.SelectedIndexChanged
        If lbWokers.SelectedItem Is Nothing Then Return
        Me.lbShipWokerUUID.Tag = lbWokers.SelectedItem.key
        Me.lbShipWokerUUID.Text = lbWokers.SelectedItem.value
    End Sub

    Private Sub btSendParcel_Click(sender As Object, e As EventArgs) Handles btSendParcel.Click
        If lbWokers.SelectedItem Is Nothing Then
            MsgBox("Выбери сотрудника для отправки", vbCritical)
            Return
        End If
        Dim _ShippingCompanyUUID = oAgent.GetAgentID("moysklad.shippingcompany", "Eesti post")
        Dim _WokerUUID = Me.lbShipWokerUUID.Tag ' выбрать работника для отправки посылки

        Dim _declaration As iMoySkladDataProvider.clsDeclaration_CP71_CN23 = Nothing
        If Me.cbxDeclarationInclude.Checked = True Then
            _declaration = New iMoySkladDataProvider.clsDeclaration_CP71_CN23
            'TODO построить декларацию

        End If

        If oMsi.AddParcelInfoToDemand(DemandUUID:=oDemand.UUID, WokerUUID:=_WokerUUID, ShippingCompanyUUID:=_ShippingCompanyUUID, DeclarationContent:=_declaration) Then
            MsgBox("Посылка поставлена на отправку", vbInformation)
            'обновить в БД строку, дописав UUID отгрузки
            For Each t In Me.oGoodList

                Dim _result = clsApplicationTypes.SampleDataObject.AddDemandUUID(t.SampleNumber.GetEan13, oDemand.UUID)
                If _result > 0 Then
                    ' MsgBox("UUID Отгрузки записан в БД", vbInformation)
                End If
            Next
        Else
            MsgBox("Не удалось поставить посылку на отправку!", vbCritical)
        End If
    End Sub
End Class
