Imports Service
Imports Service.clsApplicationTypes
Imports System.Linq
Imports Service.Agents
Public Class ucTrilboneRegister
    Private oSampleNumber As clsSampleNumber
    Private oGetMoneyFee As Decimal
    Private oAuctionFee As Decimal
    Private oClearPayment As Decimal
    Private oAgent As AUCTIONDATAAGENT
    Private oMsi As iMoySkladDataProvider
    Private oOutFeeGoodUUID As String
    Private oDemand As iMoySkladDataProvider.clsOperationInfo
    Private oReadySampleDBContext As DBREADYSAMPLEEntities
    Public Sub New()

        ' Этот вызов является обязательным для конструктора.
        InitializeComponent()

        ' Добавьте все инициализирующие действия после вызова InitializeComponent().

    End Sub

    Public Sub init(Agent As AUCTIONDATAAGENT, msi As iMoySkladDataProvider, SampleNumber As clsSampleNumber, ClearPayment As Decimal, Demand As iMoySkladDataProvider.clsOperationInfo, Optional OutFeeGoodUUID As String = "")
        oSampleNumber = SampleNumber
        oReadySampleDBContext = clsApplicationTypes.SampleDataObject.GetdbReadySampleObjectContext
        'нужен для записи в МС FEE за вывод денег
        oOutFeeGoodUUID = OutFeeGoodUUID

        'сколько получено грязных, там будет получено и за шиппинг НО!! Должно быть вычтено fee при поступлении на счет (как в PayPal). Если есть.
        oClearPayment = ClearPayment
        oMsi = msi
        oAgent = Agent

        oDemand = Demand
    End Sub


#Region "рассчеты трилбон"
    Private Sub btGetFullAmount_Click(sender As Object, e As EventArgs) Handles btGetFullAmount.Click
        Me.tbFullAmount.Text = oClearPayment
    End Sub
    Private Sub btGetResorceFee_Click(sender As Object, e As EventArgs) Handles btGetResorceFee.Click
        'получить fee за выставление pSLGetSampleInsectionFeeTotal
        Dim _result = (oReadySampleDBContext.pSLGetSampleInsectionFeeTotal(oSampleNumber.GetEan13)).ToList

        If _result.Count > 0 Then
            If _result(0).totalfee > 0 Then
                Me.tbInsectionFee.Text = _result(0).totalfee
            End If
        End If
    End Sub

    Private Sub btShipmentOutFee_Click(sender As Object, e As EventArgs) Handles btShipmentOutFee.Click
       

        Dim _result = (oReadySampleDBContext.pSLGetSampleLastSaleInfo(oSampleNumber.GetEan13)).ToList

        If _result.Count > 0 AndAlso _result(0).ShippingOutFee.HasValue = True Then
            Me.tbShipmentOutFee.Text = _result(0).ShippingOutFee.Value
            'это уже записанные значения на предыдущем шаге
            oGetMoneyFee = _result(0).getmoneyfee
            oAuctionFee = _result(0).actionfee
        Else
            Me.tbShipmentOutFee.Text = ""
            oGetMoneyFee = 0
            oAuctionFee = 0
        End If
    End Sub
    Private Sub btWeightQuery_Click(sender As Object, e As EventArgs) Handles btWeightQuery.Click
      
        Dim _result = (clsApplicationTypes.SampleDataObject.GetdbPhotoObjectContext.Select_SampleInfo(oSampleNumber.GetEan13)).ToList

        If _result.Count > 0 AndAlso _result(0).Sample_net_weight.HasValue = True Then
            tbWeight.Text = _result(0).Sample_net_weight.Value
        End If
    End Sub
    Private Sub btWeightCalculate_Click(sender As Object, e As EventArgs) Handles btWeightCalculate.Click
        Me.tbExportFee.Text = clsApplicationTypes.ReplaceDecimalSplitter(tbWeight) * clsApplicationTypes.ReplaceDecimalSplitter(tbWeightTax)
    End Sub
    Private Sub btMoneyOutCalculate_Click(sender As Object, e As EventArgs) Handles btMoneyOutCalculate.Click
        tbMoneyOutBase.Text = tbFullAmount.Text
        Me.tbMoneyOutFee.Text = clsApplicationTypes.ReplaceDecimalSplitter(tbMoneyOutTax) * clsApplicationTypes.ReplaceDecimalSplitter(tbMoneyOutBase) / 100
    End Sub
    Private Sub btNalogCalculate_Click(sender As Object, e As EventArgs) Handles btNalogCalculate.Click
        tbNalogBase.Text = tbFullAmount.Text
        Me.tbNalogFee.Text = clsApplicationTypes.ReplaceDecimalSplitter(tbNalogTax) * clsApplicationTypes.ReplaceDecimalSplitter(tbNalogBase) / 100
    End Sub
    Private Sub btSubTotal_Click(sender As Object, e As EventArgs) Handles btSubTotal.Click
        Me.tbSubTotal.Text = clsApplicationTypes.ReplaceDecimalSplitter(tbFullAmount) - (clsApplicationTypes.ReplaceDecimalSplitter(tbInsectionFee) + clsApplicationTypes.ReplaceDecimalSplitter(tbShipmentOutFee) + clsApplicationTypes.ReplaceDecimalSplitter(tbExportFee) + clsApplicationTypes.ReplaceDecimalSplitter(tbNalogFee) + oAuctionFee + oGetMoneyFee)
    End Sub
    Private Sub btTrilboneCalculate_Click(sender As Object, e As EventArgs) Handles btTrilboneCalculate.Click
        Me.tbTrilboneBase.Text = Me.tbSubTotal.Text
        Me.tbTrilboneFee.Text = clsApplicationTypes.ReplaceDecimalSplitter(tbTrilboneTax) * clsApplicationTypes.ReplaceDecimalSplitter(tbTrilboneBase) / 100
    End Sub
    Private Sub btTotal_Click(sender As Object, e As EventArgs) Handles btTotal.Click
        Me.tbCalcTotal.Text = clsApplicationTypes.ReplaceDecimalSplitter(tbSubTotal) - clsApplicationTypes.ReplaceDecimalSplitter(tbTrilboneFee)

    End Sub
    Private Sub btPersonCalc_Click(sender As Object, e As EventArgs) Handles btPersonCalc.Click
        Me.tbCalcTotalPerOne.Text = Math.Round(clsApplicationTypes.ReplaceDecimalSplitter(tbCalcTotal) / clsApplicationTypes.ReplaceDecimalSplitter(tbPersonCount), 2)
    End Sub

#End Region

    Private Sub btSaveInDb_Click(sender As Object, e As EventArgs) Handles btSaveInDb.Click

        'UUID товара PayPal вывод, коммиссия.  для каждого PAYPAL аккаунта свой. Зависит от выбранного paypal аккаунта для входящего платежа.
        Dim _PayPalOutFeeAmount As Decimal = clsApplicationTypes.ReplaceDecimalSplitter(tbMoneyOutFee)
        

        ''UUID товара EbayFee за выставление. для каждого аукциона свой
        ' ''(это значение надо взять из запроса последней записи выставления)
        Dim _EbayFeeStartAmount As Decimal = clsApplicationTypes.ReplaceDecimalSplitter(tbInsectionFee)
        Dim _EbayFeeStartGoodUUID = oAgent.GetAgentID("moysklad.fee", "EbayFeeStart")

        'стоимость экспорта Импорт в Эстонию (по весу) 8-3490
        Dim _itemexportfee As Decimal = clsApplicationTypes.ReplaceDecimalSplitter(tbExportFee)
        Dim _ExportGoodUUID As String = oAgent.GetAgentID("moysklad.fee", "ExportGood")
        'кол-во экспорта в кг
        Dim _exportQuantity As Decimal = clsApplicationTypes.ReplaceDecimalSplitter(tbWeight)

        'налоги Налоги при экспортных продажах (общий) 8-3489-1
        Dim _itemnalogifee As Decimal = clsApplicationTypes.ReplaceDecimalSplitter(tbNalogFee)
        Dim _NalogFeeUUID As String = oAgent.GetAgentID("moysklad.fee", "ExportTax")

        'это нам))
        Dim _itemtrilbonefee As Decimal = clsApplicationTypes.ReplaceDecimalSplitter(tbTrilboneFee)

        'это налик
        Dim _subTotal = clsApplicationTypes.ReplaceDecimalSplitter(tbSubTotal)

        'это заполнено при отгрузке
        'Me.oMsi.UpdateDemandsAfterCalculate(DemandUUID:=oDemandUUID, PayPalOutFeeAmount:=0, PayPalOutFeeGoodUUID:="", EbayFeeStartAmount:=0, EbayFeeStartGoodUUID:="", ExportFee:=0, ExportGoodUUID:="", NalogFee:=0, NalogFeeUUID:="", exportQuantity:=0, EbayFeeEndAmount:=_EbayFeeEndAmount, EbayFeeEndGoodUUID:=_EbayFeeEndGoodUUID, PayPalStartFeeAmount:=_PayPalStartFeeAmount, PayPalStartFeeGoodUUID:=_PayPalStartFeeGoodUUID, ShippingInAmount:=_ShippingInAmount, ShippingInGoodUUID:=_ShippingInGoodUUID, ShippingInQty:=1)

        'обновить данные в МС
        Dim _res1 = oMsi.UpdateDemandsAfterCalculate(DemandUUID:=oDemand.UUID, PayPalOutFeeAmount:=_PayPalOutFeeAmount, PayPalOutFeeGoodUUID:=oOutFeeGoodUUID, EbayFeeStartAmount:=_EbayFeeStartAmount, EbayFeeStartGoodUUID:=_EbayFeeStartGoodUUID, ExportFee:=_itemexportfee, ExportGoodUUID:=_ExportGoodUUID, NalogFee:=_itemnalogifee, NalogFeeUUID:=_NalogFeeUUID, exportQuantity:=_exportQuantity, EbayFeeEndAmount:=0, EbayFeeEndGoodUUID:="", PayPalStartFeeAmount:=0, PayPalStartFeeGoodUUID:="", ShippingInAmount:=0, ShippingInGoodUUID:="", ShippingInQty:=0)

        If _res1 Then
            MsgBox("Данные записаны в МС", vbInformation)
        End If
        'обновит данные в БД  Валюта должна быть идеинтичной уже имеющейся записи!!!!
        Dim _res = clsApplicationTypes.SampleDataObject.UpdateSampleToSoldViaEbay(demandUUID:=oDemand.UUID, itemauctionfee:=_EbayFeeStartAmount, itemexportfee:=_itemexportfee, itemgetmoneyfee:=_PayPalOutFeeAmount, itemnalogifee:=_itemnalogifee, itemtrilbonefee:=_itemtrilbonefee, subTotal:=_subTotal)
        'TODO а потом сюда записать дольщиков
        If _res Then
            MsgBox("Данные записаны в БД", vbInformation)
        End If
    End Sub

    Private Sub btCreatePayment_Click(sender As Object, e As EventArgs) Handles btCreatePayment.Click
        'создать непроведенный расход для выбранного дольщика

    End Sub
End Class
