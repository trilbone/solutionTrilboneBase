
Imports System.Configuration
'Imports eBay.Service.Call
'Imports eBay.Service.Core.Sdk
'Imports eBay.Service.Core.Soap
'Imports eBay.Service.Util
Imports System.Xml
Imports System.Linq
Imports System.Xml.Linq
Imports Service
Imports Service.Agents
Imports Service.clsSampleDataManager
Imports ClsTrilboneEbayService
Imports Service.com.ebay.developer

Public Class fmTrilboneEbay
    ''' <summary>
    ''' содержит инфу по мере заполнения полей
    ''' </summary>
    ''' <remarks></remarks>
    Private oErrorStatus As Integer
    Private oSplash As SplashScreen1
    Private oAgents As AUCTIONAGENT
    Private oCurrentAgent As AUCTIONDATAAGENT
    Private oTransaction As clsTransactionRequest
    ' ''' <summary>
    ' ''' текущий item, выбранный в списке lblItemsList
    ' ''' </summary>
    ' ''' <remarks></remarks>
    'Private oCurrentItem As ItemType

    Private oMCinterface As Service.iMoySkladDataProvider
    Private oGetMoneyFee As Decimal
    Private oAuctionFee As Decimal


#Region "конструктор и инициализация"
    Sub New()
        InitializeComponent()
        oReadySampleDBContext = clsApplicationTypes.SampleDataObject.GetdbReadySampleObjectContext
        oSplash = New SplashScreen1
        LoadMC()
        init()
    End Sub

    Private oReadySampleDBContext As DBREADYSAMPLEEntities

    Private Sub init()
        If oMCinterface Is Nothing Then Return
        Me.lbClientInterest.DataSource = New BindingSource(oMCinterface.GetClientsInterest, Nothing)
        Me.lbClientInterest.DisplayMember = "Value"
        Me.lbClientInterest.ValueMember = "Key"

        Me.lbClientTags.DataSource = New BindingSource(oMCinterface.GetClientsTags, Nothing)

        Me.lbWokers.DataSource = New BindingSource(oMCinterface.GetTriboneWoker, Nothing)
        Me.lbWokers.DisplayMember = "Value"
        Me.lbWokers.ValueMember = "Key"

        Me.btReadAccounts_Click(Me.btReadAccounts, EventArgs.Empty)
    End Sub


#End Region

#Region "утилиты"
    Private Sub LoadMC()
        Me.oMCinterface = clsApplicationTypes.MoySklad(True)
        If oMCinterface Is Nothing Then
            Me.btLoadMC.Text = "Загрузить МС"
            Me.btLoadMC.BackColor = Color.Red
        Else
            Me.btLoadMC.Text = "МС загружен"
            Me.btLoadMC.BackColor = Button.DefaultBackColor
        End If
    End Sub

    Private Sub Clear()
        'clear
        Me.NameTextBox1.Text = ""
        Me.StreetTextBox1.Text = ""
        Me.StateTextBox.Text = ""
        Me.CityTextBox.Text = ""
        Me.PostIndexTextBox.Text = ""
        Me.CountryTextBox.Text = ""
        Me.PhoneTextBox1.Text = ""
        Me.RichTextBox1.Text = ""
        Me.tbPayPalFeeAmount.Text = ""
        Me.tbFeePayPalCurrency.Text = ""
        Me.tbTotal.Text = ""
        Me.lbClientInterest.SelectedIndex = -1
        Me.rtbClientInterestDetails.Text = ""
        Me.rtbClientComment.Text = ""
        Me.lbClientTags.SelectedIndex = -1
        Me.lbCustomers.DataSource = Nothing
        Me.lbUserSearchStatus.Text = ""
        Me.rtbPaymentComment.Text = ""
        Me.rtbPaymentPurpose.Text = ""

        Me.lbWokers.SelectedIndex = -1
        Me.btLeaveFeedback.BackColor = Button.DefaultBackColor
        Me.btLeaveFeedback.Enabled = False
        Me.tbfeedback.Text = ""

        Me.lbPaymentUUID.Text = ""
        Me.lbGoodUUID.Text = ""
        Me.lbOrderUUID.Text = ""
        Me.lbDemandUUID.Text = ""
        Me.lbShipWokerUUID.Text = ""

        Me.lbPaymentUUID.Tag = Nothing
        Me.lbGoodUUID.Tag = Nothing
        Me.lbOrderUUID.Tag = Nothing
        Me.lbDemandUUID.Tag = Nothing
        Me.lbShipWokerUUID.Tag = Nothing

        Me.tbFullAmount.Text = ""
        Me.tbInsectionFee.Text = ""
        Me.tbShipmentOutFee.Text = ""
        Me.tbExportFee.Text = ""
        Me.tbWeight.Text = ""
        Me.tbWeightTax.Text = "8"
        Me.tbMoneyOutFee.Text = ""
        Me.tbMoneyOutTax.Text = "5"
        Me.tbMoneyOutBase.Text = ""
        Me.tbNalogFee.Text = ""
        Me.tbNalogBase.Text = ""
        Me.tbNalogTax.Text = "0"
        Me.tbSubTotal.Text = ""
        Me.tbTrilboneFee.Text = ""
        Me.tbTrilboneTax.Text = "30"
        Me.tbTrilboneBase.Text = ""
        Me.tbCalcTotal.Text = ""
        Me.tbPersonCount.Text = "1"
        Me.tbCalcTotalPerOne.Text = ""
    End Sub
#End Region

#Region "События ЭУ"
    ''' <summary>
    ''' получить аккаунты
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btReadAccounts_Click(sender As Object, e As EventArgs) Handles btReadAccounts.Click
        oAgents = clsApplicationTypes.AuctionAgent
        If oAgents Is Nothing Then
            MsgBox("Не удалось загрузить файл описаний аккаунтов eBay", vbCritical)
        End If
        Me.cbAccount.DataSource = oAgents.AGENT.Where(Function(x) x.name.Equals("ebay")).ToList
        Me.cbAccount.DisplayMember = "account"
    End Sub




    ''' <summary>
    ''' получить инво по транзакциям
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btGetTransaction_Click(sender As Object, e As EventArgs) Handles btGetTransaction.Click
        If Me.cbAccount.SelectedItem Is Nothing Then Return

        If oSplash.Visible = False Then
            oSplash.Show()
            Application.DoEvents()
        End If



        Me.TransactionTypeBindingSource.DataSource = GetType(clsTransactionItem)

        oTransaction = clsTransactionRequest.CreateInstance(Me.cbAccount.SelectedItem)
        If (Not oTransaction Is Nothing) AndAlso oTransaction.IsSuccess Then
            If oTransaction.Count = 0 Then
                MsgBox("Текущих транзакций нет", vbInformation)
                oSplash.Hide()
                Return
            End If
        Else
            MsgBox("Запрос к eBay выдал ошибку", vbCritical)

            oSplash.Hide()
            Return
        End If

        ''get transactions list
        Dim _transactionList As New List(Of clsTransactionItem)

        'For Each t In oTransaction.ItemIdList

        '    Dim _tmp = clsTransactionBinding.CreateInstance(oTransaction, t.ItemID)
        '    If _tmp.RequestStatus Then
        '        _transactionList.Add(_tmp)
        '    Else
        '        MsgBox(_tmp.RequestMessage, vbCritical)
        '    End If
        'Next
        oSplash.Hide()
        Application.DoEvents()
        Me.TransactionTypeBindingSource.DataSource = _transactionList

    End Sub

    ''' <summary>
    ''' построение адреса
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btBuildAddress_Click(sender As Object, e As EventArgs) Handles btBuildAddress.Click
        Me.IMoySkladDataProvider_AddressBindingSource.DataSource = New Service.iMoySkladDataProvider.clsAddress

        Dim _mcaddr As Service.iMoySkladDataProvider.clsAddress = Me.IMoySkladDataProvider_AddressBindingSource.Current

        Dim _address As String = ""
        '----name
        If Not Me.NameTextBox.Text = "нет" Then
            _address += Me.NameTextBox.Text + ChrW(13)
            _mcaddr.Name = Me.NameTextBox.Text
        End If
        If Not Me.FirstNameTextBox.Text = "нет" Then
            _address += Me.FirstNameTextBox.Text + " " + Me.LastNameTextBox.Text + ChrW(13)
            _mcaddr.Name = Me.FirstNameTextBox.Text + " " + Me.LastNameTextBox.Text
        End If
        'street
        Dim _street As String = ""
        If Not Me.StreetTextBox.Text = "нет" Then
            _address += Me.StreetTextBox.Text + ChrW(13)
            _street += Me.StreetTextBox.Text
        End If
        If Not Me.Street1TextBox.Text = "нет" Then
            _address += Me.Street1TextBox.Text + ChrW(13)
            _street += Me.Street1TextBox.Text
        End If
        If Not Me.Street2TextBox.Text = "нет" Then
            _address += Me.Street2TextBox.Text + ChrW(13)
            _street += Me.Street2TextBox.Text
        End If
        _mcaddr.Street = _street
        'postal & city
        If Not Me.PostalCodeTextBox.Text = "нет" Then
            _address += Me.PostalCodeTextBox.Text + " " + Me.CityNameTextBox.Text + ChrW(13)
            _mcaddr.PostIndex = Me.PostalCodeTextBox.Text
            _mcaddr.City = Me.CityNameTextBox.Text
        End If
        'province
        If Not Me.StateOrProvinceTextBox.Text = "нет" Then
            _address += Me.StateOrProvinceTextBox.Text + ChrW(13)
            _mcaddr.State = Me.StateOrProvinceTextBox.Text
        End If


        'country
        If Not Me.CountryNameTextBox.Text = "нет" Then
            _address += Me.CountryNameTextBox.Text + ChrW(13)
            _mcaddr.Country = Me.CountryNameTextBox.Text
        End If
        'phone
        If Not Me.PhoneTextBox.Text = "нет" Then
            _address += Me.PhoneTextBox.Text + ChrW(13)
            _mcaddr.Phone = Me.PhoneTextBox.Text
        End If
        If Not Me.Phone2TextBox.Text = "нет" Then
            _address += Me.Phone2TextBox.Text + ChrW(13)
            If _mcaddr.Phone = "" Then
                _mcaddr.Phone = Me.Phone2TextBox.Text
            End If
        End If

        _mcaddr.FullAddress = _address

        Me.cbAddressIsCorrect.Checked = False

    End Sub

    ''' <summary>
    ''' загрузка МС
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btLoadMC_Click(sender As Object, e As EventArgs) Handles btLoadMC.Click
        If Me.oMCinterface Is Nothing Then
            LoadMC()
        Else
            If oSplash.Visible = False Then
                oSplash.Show()
                Application.DoEvents()
            End If
            oMCinterface.ReloadEntities()
            oSplash.Hide()
            Application.DoEvents()
        End If
        init()
    End Sub
    ''' <summary>
    ''' резерв/отгрузка/заказ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btCreateMCBulk_Click(sender As Object, e As EventArgs) Handles btCreateMCBulk.Click

        If Me.lbCustomers.SelectedItem Is Nothing Then
            MsgBox("Необходимо задать клиента!!!", vbCritical)
            Return
        End If

        If SKUTextBox.Text.Length = 0 Then
            MsgBox("Впишите короткий номер образца в поле Custom(SKU) label !!", vbCritical)
            Return
        End If

        Dim _samplenumber = clsApplicationTypes.clsSampleNumber.CreateFromString(SKUTextBox.Text.Trim)
        If _samplenumber Is Nothing OrElse _samplenumber.CodeIsCorrect = False Then
            MsgBox("Не могу распознать код, записанный в SKU", vbCritical)
            Return
        End If

        If oMCinterface Is Nothing Then LoadMC()
        If oMCinterface Is Nothing Then Return

        If oSplash.Visible = False Then
            oSplash.Show()
            Application.DoEvents()
        End If

        Static _EndSampleOnAuction As Boolean
        Static _CreateCustomerOrder As Boolean
        Static _CreateDemand As Boolean
        Static _LinkOrderDemandPaymentIn As Boolean
        Static _RegisterInDb As Boolean

        If Not _EndSampleOnAuction Then
            If Not EndSampleOnAuction() Then
                MsgBox("Не удалось снять образец из резервации аукциона!", vbCritical)
                oSplash.Hide()
                Return
            End If
            _EndSampleOnAuction = True
        End If

        If Not _CreateCustomerOrder Then
            If Not CreateCustomerOrder() Then
                MsgBox("Не удалось сформировать заказ!", vbCritical)
                oSplash.Hide()
                Return
            End If
            _CreateCustomerOrder = True
        End If

        If Not _CreateDemand Then
            'где???
            Dim _Warehouse = oMCinterface.GetWarehouse(lbGoodUUID.Tag)
            If _Warehouse.IsEmpty Then
                oSplash.Hide()
                MsgBox("Не удалось найти склад для товара!!", vbCritical)
                Return
            End If
            If Not CreateDemand() Then
                MsgBox("Не удалось сформировать отгрузку!", vbCritical)
                oSplash.Hide()
                Return
            End If
            _CreateDemand = True
        End If

        If Not _LinkOrderDemandPaymentIn Then
            If Not LinkOrderDemandPaymentIn() Then
                MsgBox("Не удалось связать документы!", vbCritical)
                oSplash.Hide()
                Return
            End If
            _LinkOrderDemandPaymentIn = True
        End If

        If Not _RegisterInDb Then
            If Not RegisterInDb() Then
                MsgBox("Не удалось отметить продажу в БД Trilbone!", vbCritical)
                oSplash.Hide()
                Return
            End If
            _RegisterInDb = True
        End If

        oSplash.Hide()

        If _EndSampleOnAuction And _CreateCustomerOrder And _CreateDemand And _LinkOrderDemandPaymentIn And _RegisterInDb Then
            MsgBox("Документы сформированы", vbInformation)
            _EndSampleOnAuction = False
            _CreateCustomerOrder = False
            _CreateDemand = False
            _LinkOrderDemandPaymentIn = False
            _RegisterInDb = False
            oErrorStatus = 3
        Else
            oErrorStatus = -3
        End If

    End Sub

    ''' <summary>
    ''' сотрудник на отправку
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub lbWokers_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbWokers.SelectedIndexChanged
        If lbWokers.SelectedItem Is Nothing Then Return
        Me.lbShipWokerUUID.Tag = lbWokers.SelectedItem.key
        Me.lbShipWokerUUID.Text = lbWokers.SelectedItem.value
    End Sub

    ''' <summary>
    ''' послать посылку
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btSendParcels_Click(sender As Object, e As EventArgs) Handles btSendParcel.Click
        Dim _ShippingCompanyUUID = CType(Me.cbAccount.SelectedItem, AUCTIONDATAAGENT).GetAgentID("moysklad.shippingcompany", "Eesti post")
        Dim _WokerUUID = Me.lbShipWokerUUID.Tag ' выбрать работника для отправки посылки
        If oMCinterface Is Nothing Then LoadMC()
        If oMCinterface Is Nothing Then Return
        If oSplash.Visible = False Then
            oSplash.Show()
            Application.DoEvents()
        End If


        Dim _declaration As iMoySkladDataProvider.clsDeclaration_CP71_CN23 = Nothing
        _declaration = New iMoySkladDataProvider.clsDeclaration_CP71_CN23
        _declaration.content = iMoySkladDataProvider.emDeclaredContent.PACKET_CN23_GIFT
        _declaration.declarationcurrency = "EUR"
        _declaration.Instructionfornondelivery = iMoySkladDataProvider.emInstructionfornondelivery.INSTRUCTION_CODE_RETURN_TO_SENDER
        _declaration.ReturnSpeed = iMoySkladDataProvider.emReturnSpeed.DELICERY_FAILURE_SPEED_BY_AIR
        _declaration.AddItem("fossil", "1pcs", "10euro")
        ' _declaration.ReturnAddress


        'TODO построить декларацию
        If oMCinterface.AddParcelInfoToDemand(DemandUUID:=lbDemandUUID.Tag, WokerUUID:=_WokerUUID, ShippingCompanyUUID:=_ShippingCompanyUUID, DeclarationContent:=_declaration) Then
            oSplash.Hide()
            MsgBox("Посылка поставлена на отправку", vbInformation)
            'обновить в БД строку, дописав UUID отгрузки
            Dim _samplenumber = clsApplicationTypes.clsSampleNumber.CreateFromString(SKUTextBox.Text.Trim)
            If _samplenumber Is Nothing OrElse _samplenumber.CodeIsCorrect = False Then
                MsgBox("Не могу распознать код, записанный в SKU", vbCritical)
                Return
            End If
            Dim _result = Me.oReadySampleDBContext.pSLAddDemandUUID(_samplenumber.GetEan13, lbDemandUUID.Tag)
            If _result > 0 Then
                MsgBox("UUID Отгрузки записан в БД", vbInformation)
            End If
        Else
            oSplash.Hide()
            MsgBox("Не удалось поставить посылку на отправку!", vbCritical)
        End If
    End Sub

    ''' <summary>
    ''' смена аккаунта ебай
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cbAccount_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbAccount.SelectedIndexChanged
        If Me.cbAccount.SelectedItem Is Nothing Then btGetTransaction.Enabled = False : oCurrentAgent = Nothing : Return
        oCurrentAgent = Me.cbAccount.SelectedItem
        Me.btGetTransaction.Enabled = True
    End Sub

    ''' <summary>
    ''' сохранить продажу в БД
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btSaveInDb_Click(sender As Object, e As EventArgs) Handles btSaveInDb.Click
        Dim _samplenumber = clsApplicationTypes.clsSampleNumber.CreateFromString(SKUTextBox.Text.Trim)
        If _samplenumber Is Nothing OrElse _samplenumber.CodeIsCorrect = False Then
            MsgBox("Не могу распознать код, записанный в SKU", vbCritical)
            Return
        End If
        If oMCinterface Is Nothing Then LoadMC()
        If oMCinterface Is Nothing Then Return
        Dim _result = (oReadySampleDBContext.pSLGetSampleLastSaleInfo(_samplenumber.GetEan13)).ToList
        Dim _demandUUID As String = ""
        If _result.Count > 0 Then
            _demandUUID = _result(0).demandUUID.Trim
        End If
        If _demandUUID = "" Then
            MsgBox("Не могу получить номер отгрузки! Отмена сохраниения!", vbCritical)
            Return
        End If

        'UUID товара PayPal вывод, коммиссия.  для каждого PAYPAL аккаунта свой. Зависит от выбранного paypal аккаунта для входящего платежа.
        Dim _PayPalOutFeeAmount As Decimal = clsApplicationTypes.ReplaceDecimalSplitter(tbMoneyOutFee)
        Dim _PayPalOutFeeGoodUUID = CType(Me.cbAccount.SelectedItem, AUCTIONDATAAGENT).GetAgentID("moysklad.PayPal", "PayPalOutFee " & PayPalEmailAddressTextBox.Text.Trim)

        'UUID товара EbayFee за выставление. для каждого аукциона свой
        ''(это значение надо взять из запроса последней записи выставления)
        Dim _EbayFeeStartAmount As Decimal = clsApplicationTypes.ReplaceDecimalSplitter(tbInsectionFee)
        Dim _EbayFeeStartGoodUUID = CType(Me.cbAccount.SelectedItem, AUCTIONDATAAGENT).GetAgentID("moysklad.fee", "EbayFeeStart")

        'стоимость экспорта Импорт в Эстонию (по весу) 8-3490
        Dim _itemexportfee As Decimal = clsApplicationTypes.ReplaceDecimalSplitter(tbExportFee)
        Dim _ExportGoodUUID As String = CType(Me.cbAccount.SelectedItem, AUCTIONDATAAGENT).GetAgentID("moysklad.fee", "ExportGood")
        'кол-во экспорта в кг
        Dim _exportQuantity As Decimal = clsApplicationTypes.ReplaceDecimalSplitter(tbWeight)

        'налоги Налоги при экспортных продажах (общий) 8-3489-1
        Dim _itemnalogifee As Decimal = clsApplicationTypes.ReplaceDecimalSplitter(tbNalogFee)
        Dim _NalogFeeUUID As String = CType(Me.cbAccount.SelectedItem, AUCTIONDATAAGENT).GetAgentID("moysklad.fee", "ExportTax")

        'это нам))
        Dim _itemtrilbonefee As Decimal = clsApplicationTypes.ReplaceDecimalSplitter(tbTrilboneFee)

        'это налик
        Dim _subTotal = clsApplicationTypes.ReplaceDecimalSplitter(tbSubTotal)

        Dim _EbayFeeEndGoodUUID = CType(Me.cbAccount.SelectedItem, AUCTIONDATAAGENT).GetAgentID("moysklad.fee", "EbayFeeEnd")
        Dim _ShippingInGoodUUID = CType(Me.cbAccount.SelectedItem, AUCTIONDATAAGENT).GetAgentID("moysklad", "ShippingIn")
        Dim _ShippingInAmount As Decimal = clsApplicationTypes.ReplaceDecimalSplitter(ValueTextBox2)
        Dim _PayPalStartFeeGoodUUID = CType(Me.cbAccount.SelectedItem, AUCTIONDATAAGENT).GetAgentID("moysklad.PayPal", "PayPalStrartFee " & PayPalEmailAddressTextBox.Text.Trim)
        Dim _EbayFeeEndAmount = clsApplicationTypes.ReplaceDecimalSplitter(ValueTextBox4)
        Dim _PayPalStartFeeAmount = clsApplicationTypes.ReplaceDecimalSplitter(tbPayPalFeeAmount)

        'обновить данные в МС
        Dim _res1 = oMCinterface.UpdateDemandsAfterCalculate(DemandUUID:=_demandUUID, PayPalOutFeeAmount:=_PayPalOutFeeAmount, PayPalOutFeeGoodUUID:=_PayPalOutFeeGoodUUID, EbayFeeStartAmount:=_EbayFeeStartAmount, EbayFeeStartGoodUUID:=_EbayFeeStartGoodUUID, ExportFee:=_itemexportfee, ExportGoodUUID:=_ExportGoodUUID, NalogFee:=_itemnalogifee, NalogFeeUUID:=_NalogFeeUUID, exportQuantity:=_exportQuantity, EbayFeeEndAmount:=_EbayFeeEndAmount, EbayFeeEndGoodUUID:=_EbayFeeEndGoodUUID, PayPalStartFeeAmount:=_PayPalStartFeeAmount, PayPalStartFeeGoodUUID:=_PayPalStartFeeGoodUUID, ShippingInAmount:=_ShippingInAmount, ShippingInGoodUUID:=_ShippingInGoodUUID, ShippingInQty:=1)
        If _res1 Then
            MsgBox("Данные записаны в МС", vbInformation)
        End If
        'обновит данные в БД  Валюта должна быть идеинтичной уже имеющейся записи!!!!
        Dim _res = clsApplicationTypes.SampleDataObject.UpdateSampleToSoldViaEbay(demandUUID:=_demandUUID, itemauctionfee:=_EbayFeeStartAmount, itemexportfee:=_itemexportfee, itemgetmoneyfee:=_PayPalOutFeeAmount, itemnalogifee:=_itemnalogifee, itemtrilbonefee:=_itemtrilbonefee, subTotal:=_subTotal)
        'TODO а потом сюда записать дольщиков
        If _res Then
            MsgBox("Данные записаны в БД", vbInformation)
        End If
    End Sub

    ''' <summary>
    ''' оставить фидбек
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btLeaveFeedback_Click(sender As Object, e As EventArgs)
        Dim _tmp As com.ebay.developer.TransactionType = Me.TransactionTypeBindingSource.Current
        If _tmp Is Nothing Then Return

        MsgBox("Функция не реализована. Оставь фидбек вручную.", vbInformation)
        'TODO оставить фидбек в ебай
    End Sub
    ''' <summary>
    ''' смена вкладки
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tbctlMain_TabIndexChanged(sender As Object, e As EventArgs) Handles tbctlMain.TabIndexChanged
        Select Case oErrorStatus
            Case Is > 0
                Return
            Case -1
                MsgBox("Ошибка на предыдущей странице: не выбран клиент, необходимо выбрать клиента. Продолжение без исправления может привести к ошибке записей в МС.", vbCritical)
                Return
            Case -2
                MsgBox("Ошибка на предыдущей странице: не создан входящий платеж, необходимо создать платеж. Продолжение без исправления может привести к ошибке записей в МС.", vbCritical)

            Case -3
                MsgBox("Ошибка на предыдущей странице: не оформлена снятие с резерва/заказ/отгрузка, необходимо это создать. Продолжение без исправления может привести к ошибке записей в МС.", vbCritical)

        End Select
    End Sub


    ''' <summary>
    ''' выбор образца
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TransactionTypeBindingSource_CurrentChanged(sender As Object, e As EventArgs) Handles TransactionTypeBindingSource.CurrentChanged
        If Me.TransactionTypeBindingSource.Current Is Nothing Then Return


        Dim _transaction As com.ebay.developer.TransactionType = Me.TransactionTypeBindingSource.Current.Transaction

        Clear()

        ' PAYPALFEE
        Dim _exteernalTransaction = _transaction.ExternalTransaction

        Dim _fee = (From c As ExternalTransactionType In _exteernalTransaction Select c.FeeOrCreditAmount.Value).Sum
        Dim _curr = (From c As ExternalTransactionType In _exteernalTransaction Select c.FeeOrCreditAmount.currencyID).FirstOrDefault


        Dim _num As String = ""
        For Each t As ExternalTransactionType In _exteernalTransaction
            _num += t.ExternalTransactionID & ", "
        Next
        _num.TrimEnd(", ")


        rtbPaymentPurpose.Text = String.Format("Оплата за eBay item {0}. Номер(а) PAYPAL {1}", _transaction.Item.ItemID, _num)

        rtbPaymentComment.Text = "Поступило на " & _transaction.PayPalEmailAddress


        Me.tbFeePayPalCurrency.Text = _curr.ToString
        Me.tbPayPalFeeAmount.Text = _fee

        If ValueTextBox3.Text = "" Then ValueTextBox3.Text = "0"
        If ValueTextBox.Text = "" Then ValueTextBox.Text = "0"
        If ValueTextBox4.Text = "" Then ValueTextBox4.Text = "0"

        Me.tbTotal.Text = (Decimal.Parse(ValueTextBox.Text) - Decimal.Parse(ValueTextBox3.Text) - Decimal.Parse(ValueTextBox4.Text) - Decimal.Parse(Me.tbPayPalFeeAmount.Text)).ToString

        If _exteernalTransaction.Count = 0 Then
            'оплаты не поступило
            Me.tbFeePayPalCurrency.Text = ""
            Me.tbPayPalFeeAmount.Text = "0"
            Me.tbTotal.Text = Decimal.Parse(ValueTextBox1.Text) * -1
        End If

        'FULL NAME
        Me.tbFullName.Text = _transaction.Buyer.UserFirstName & " " & _transaction.Buyer.UserLastName

        'FEEDBACK
        If Not _transaction.FeedbackLeft Is Nothing Then
            If Not String.IsNullOrEmpty(_transaction.FeedbackLeft.CommentText) Then
                Me.tbfeedback.Text = _transaction.FeedbackLeft.CommentText
                Me.tbfeedback.Enabled = False
                Me.btLeaveFeedback.BackColor = Button.DefaultBackColor
                Me.btLeaveFeedback.Enabled = False
            Else
                Me.tbfeedback.Text = "Nice buyer. Quick payment. Recommend."
                Me.tbfeedback.Enabled = True
                Me.btLeaveFeedback.BackColor = Color.Red
                Me.btLeaveFeedback.Enabled = True
            End If
        Else
            Me.tbfeedback.Text = "Nice buyer. Quick payment. Recommend."
            Me.tbfeedback.Enabled = True
            Me.btLeaveFeedback.BackColor = Color.Red
            Me.btLeaveFeedback.Enabled = True
        End If
        'оплата
        If lbPaid.Enabled Then
            lbPaid.BackColor = Color.Green
            lbPaid.Text = "Оплачено"
        Else
            lbPaid.BackColor = Color.Red
            lbPaid.Text = "НЕ ОПЛАЧЕНО"
        End If
        'отправка
        If lbShipped.Enabled Then
            lbShipped.BackColor = Color.Green
            lbShipped.Text = "Отправлено"
        Else
            If lbPaid.Enabled Then
                lbShipped.BackColor = Color.Red
                lbShipped.Text = "НА ОТПРАВКУ"
            Else
                lbShipped.BackColor = Color.Red
                lbShipped.Text = "Ждать оплату"
            End If

        End If

    End Sub

#End Region


#Region "Клиент МС"
    ''' <summary>
    ''' поиск клиента в МС
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btSearchClientByFullName_Click(sender As Object, e As EventArgs) Handles btSearchClientByFullName.Click
        If Me.oMCinterface Is Nothing Then LoadMC()
        If oMCinterface Is Nothing Then Return
        Me.lbUserSearchStatus.Text = "поиск клиента.."
        Application.DoEvents()
        lbCustomers.DataSource = Nothing
        Dim _result As New List(Of iMoySkladDataProvider.clsClientInfo)

        _result.AddRange(oMCinterface.FindCustomer("", EmailTextBox.Text, "", True))

        _result.AddRange(oMCinterface.FindCustomer("", "", UserIDTextBox.Text))

        _result.AddRange(oMCinterface.FindCustomer(UserFirstNameTextBox.Text, "", ""))

        _result.AddRange(oMCinterface.FindCustomer(UserLastNameTextBox.Text, "", ""))

        _result.AddRange(oMCinterface.FindCustomer(tbFullName.Text, "", ""))

        If _result.Count = 0 Then
            Me.lbUserSearchStatus.Text = "этого клиента нет в базе"
        Else
            Me.lbUserSearchStatus.Text = "выбери клиента"
        End If
        lbCustomers.DataSource = _result.Distinct.ToList
    End Sub

    ''' <summary>
    ''' смена клиента
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub lbCustomers_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbCustomers.SelectedIndexChanged
        If lbCustomers.SelectedItem Is Nothing Then
            'Me.lbUserSearchStatus.Tag = Nothing
            oErrorStatus = -1
            Return
        End If
        Me.lbUserSearchStatus.Text = lbCustomers.SelectedItem.ToString
        'используется lbCustomers.SelectedItem
        'Me.lbUserSearchStatus.Tag = lbCustomers.SelectedItem
        oErrorStatus = 1
    End Sub

    ''' <summary>
    ''' создание клиента
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btCreateClient_Click(sender As Object, e As EventArgs) Handles btCreateClient.Click
        If IMoySkladDataProvider_AddressBindingSource.Current Is Nothing Then
            MsgBox("Необходимо задать адрес!", vbCritical)
            Return
        End If
        If oMCinterface Is Nothing Then LoadMC()
        If oMCinterface Is Nothing Then Return
        If oSplash.Visible = False Then
            oSplash.Show()
            Application.DoEvents()
        End If

        Dim _address As Service.iMoySkladDataProvider.clsAddress = IMoySkladDataProvider_AddressBindingSource.Current
        '----------
        Dim _clientiterest As String = ""
        If Not Me.lbClientInterest.SelectedItem Is Nothing Then
            _clientiterest = Me.lbClientInterest.SelectedItem.key
        End If
        '------------
        Dim _clientTags As New List(Of String)
        For Each t As String In lbClientTags.SelectedItems
            _clientTags.Add(t)
        Next

        Dim _getPlace = CType(Me.cbAccount.SelectedItem, AUCTIONDATAAGENT).GetAgentID("moysklad", "ClientGetPlace")

        'страну пока пропустили
        Dim _ClientCountryUUID As String = ""

        Dim _result = oMCinterface.CreateCustomer(FullName:=Me.tbFullName.Text, Email:=EmailTextBox.Text, Address:=_address, AddressString:=_address.FullAddress, CustomerCode:=UserIDTextBox.Text, ClientInterestUUID:=_clientiterest, ClientInterestDetails:=Me.rtbClientInterestDetails.Text, description:=rtbClientComment.Text, ClientMCTags:=_clientTags.ToArray, ClientCountryUUID:=_ClientCountryUUID, ClientGetPlaceUUID:=_getPlace)

        oSplash.Hide()
        Application.DoEvents()

        If _result = "" Then
            Me.lbUserSearchStatus.Text = "Не удалось создать клиента"
        Else
            Dim _str As New Service.iMoySkladDataProvider.clsClientInfo
            With _str
                .Email = EmailTextBox.Text
                .FullName = tbFullName.Text
                .MSCode = UserIDTextBox.Text
                .UUID = _result
            End With
            Me.lbCustomers.DataSource = {_str}.ToList
            Me.lbUserSearchStatus.Text = "Клиент создан"
            Me.lbCustomers.SelectedIndex = 0

            If Me.lbCustomers.Items.Count = 1 Then
                lbCustomers_SelectedIndexChanged(Me, EventArgs.Empty)
            End If
        End If
        oSplash.Hide()
    End Sub
#End Region


#Region "документы МС и БД трилбон"
    ''' <summary>
    ''' входящий платеж
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btCreateIncomingPayment_Click(sender As Object, e As EventArgs) Handles btCreateIncomingPayment.Click
        If Me.lbCustomers.SelectedItem Is Nothing Then
            MsgBox("Необходимо задать клиента!!!", vbCritical)
            Return
        End If
        If oMCinterface Is Nothing Then LoadMC()
        If oMCinterface Is Nothing Then Return
        If oSplash.Visible = False Then
            oSplash.Show()
            Application.DoEvents()
        End If

        Dim _CustomerUUID = CType(Me.lbCustomers.SelectedItem, Service.iMoySkladDataProvider.clsClientInfo).UUID
        Dim _MyCompanyUUID = CType(Me.cbAccount.SelectedItem, AUCTIONDATAAGENT).GetAgentID("moysklad", "MyCompanyUUID")
        Dim _ProjectUUID = CType(Me.cbAccount.SelectedItem, AUCTIONDATAAGENT).GetAgentID("moysklad", "ProjectUUID")
        Dim _AccountUUID = CType(Me.cbAccount.SelectedItem, AUCTIONDATAAGENT).GetAgentID("moysklad.account", PayPalEmailAddressTextBox.Text.Trim)
        Dim _AccepterUUID = CType(Me.cbAccount.SelectedItem, AUCTIONDATAAGENT).GetAgentID("moysklad.accepter", PayPalEmailAddressTextBox.Text.Trim)
        Dim _CurrencyUUID = oMCinterface.GetCurrencyUUIDByName(CurrencyIDTextBox.Text.ToUpper.Trim)
        Dim _amount As Decimal = clsApplicationTypes.ReplaceDecimalSplitter(ValueTextBox)

        Dim _result = Me.oMCinterface.CreateIncomingPayment(AccepterUUID:=_AccepterUUID, AccountUUID:=_AccountUUID, CurrencyUUID:=_CurrencyUUID, Amount:=_amount, CustomerUUID:=_CustomerUUID, MyCompanyUUID:=_MyCompanyUUID, ProjectUUID:=_ProjectUUID, NoFeeIncluded:=True, paymentPurpose:=rtbPaymentPurpose.Text, Description:=rtbPaymentComment.Text)
        oSplash.Hide()
        If _result Is Nothing Then
            lbPaymentUUID.Text = "Не удалось создать платеж!!!"
            lbPaymentUUID.Tag = Nothing
            oErrorStatus = -2
        Else
            lbPaymentUUID.Text = "Платеж создан"
            lbPaymentUUID.Tag = _result.UUID
        End If

    End Sub
    ''' <summary>
    ''' снимает образец с аукциона в МС
    ''' </summary>
    ''' <remarks></remarks>
    Private Function EndSampleOnAuction() As Boolean
        Dim _ReservCustomerOrderUUID = CType(Me.cbAccount.SelectedItem, AUCTIONDATAAGENT).GetAgentID("moysklad", "ReservCustomerOrderUUID")
        lbGoodUUID.Tag = oMCinterface.EndSampleOnAuction(GoodCode:=SKUTextBox.Text, ReservCustomerOrderUUID:=_ReservCustomerOrderUUID)

        If lbGoodUUID.Tag.ToString.Length = 0 Then
            lbGoodUUID.Text = "Образец не снят с аукциона"
            Return False
        End If
        lbGoodUUID.Text = "Образец снят с аукциона"
        Return True
    End Function

    ''' <summary>
    ''' создает заказ в МС
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CreateCustomerOrder() As Boolean
        Dim _CustomerUUID = CType(Me.lbCustomers.SelectedItem, Service.iMoySkladDataProvider.clsClientInfo).UUID
        Dim _MyCompanyUUID = CType(Me.cbAccount.SelectedItem, AUCTIONDATAAGENT).GetAgentID("moysklad", "MyCompanyUUID")
        Dim _ProjectUUID = CType(Me.cbAccount.SelectedItem, AUCTIONDATAAGENT).GetAgentID("moysklad", "ProjectUUID")
        Dim _CurrencyUUID = oMCinterface.GetCurrencyUUIDByName(CurrencyIDTextBox.Text.ToUpper.Trim)
        Dim _Orderstate1UUID = CType(Me.cbAccount.SelectedItem, AUCTIONDATAAGENT).GetAgentID("moysklad", "Orderstate1")
        Dim _ShippingInGoodUUID = CType(Me.cbAccount.SelectedItem, AUCTIONDATAAGENT).GetAgentID("moysklad", "ShippingIn")
        Dim _ShippingInAmount As Decimal = clsApplicationTypes.ReplaceDecimalSplitter(ValueTextBox2)

        Dim _WokerUUID = clsApplicationTypes.CurrentUser.UserPermission.mcuuid 'связать текущего пользователя приложения с его UUID в МС

        Dim _GoodsAmounts As Decimal() = {clsApplicationTypes.ReplaceDecimalSplitter(ValueTextBox1)}
        Dim _GoodsUUIDs As String() = {lbGoodUUID.Tag}
        Dim _GoodsQtys As Decimal() = {1}

        Dim _HandlingTime As Integer = CType(Me.cbAccount.SelectedItem, AUCTIONDATAAGENT).GetAgentID("moysklad", "HandlingTime")
        Dim _Description As String = "Заказ для eBay itemID " & Me.TransactionTypeBindingSource.Current.Item.ItemID


        lbOrderUUID.Tag = oMCinterface.CreateCustomerOrder(GoodsUUIDs:=_GoodsUUIDs, GoodsQtys:=_GoodsQtys, GoodsAmounts:=_GoodsAmounts, CurrencyUUID:=_CurrencyUUID, CustomerUUID:=_CustomerUUID, MyCompanyUUID:=_MyCompanyUUID, WokerUUID:=_WokerUUID, ProjectUUID:=_ProjectUUID, Orderstate1UUID:=_Orderstate1UUID, ShippingInGoodUUID:=_ShippingInGoodUUID, ShippingInAmount:=_ShippingInAmount, ShippingInQty:=1, HandlingTime:=_HandlingTime, Description:=_Description).UUID

        If lbOrderUUID.Tag.ToString.Length = 0 Then
            Me.lbOrderUUID.Text = "Заказ НЕ создан!"
            Return False
        End If
        Me.lbOrderUUID.Text = "Заказ создан"
        Return True
    End Function

    ''' <summary>
    ''' сформирует отгрузку
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CreateDemand() As Boolean
        '------------------
        Dim _StateUUID = CType(Me.cbAccount.SelectedItem, AUCTIONDATAAGENT).GetAgentID("moysklad", "Demandstate1")
        Dim _InvocePaymentTypeUUID = CType(Me.cbAccount.SelectedItem, AUCTIONDATAAGENT).GetAgentID("moysklad", "InvocePaymentType")
        Dim _MyCompanyUUID = CType(Me.cbAccount.SelectedItem, AUCTIONDATAAGENT).GetAgentID("moysklad", "MyCompanyUUID")
        Dim _CurrencyUUID = oMCinterface.GetCurrencyUUIDByName(CurrencyIDTextBox.Text.ToUpper.Trim)
        Dim _CustomerUUID = CType(Me.lbCustomers.SelectedItem, Service.iMoySkladDataProvider.clsClientInfo).UUID
        Dim _ProjectUUID = CType(Me.cbAccount.SelectedItem, AUCTIONDATAAGENT).GetAgentID("moysklad", "ProjectUUID")
        Dim _GoodsUUIDs As String() = {lbGoodUUID.Tag}
        Dim _GoodsQtys As Decimal() = {1}
        Dim _GoodsAmounts As Decimal() = {clsApplicationTypes.ReplaceDecimalSplitter(ValueTextBox1)}

        'где???
        Dim _Warehouse = oMCinterface.GetWarehouse(lbGoodUUID.Tag)
        Dim _Description = ""


        lbDemandUUID.Tag = oMCinterface.CreateDemand(MyCompanyUUID:=_MyCompanyUUID, CurrencyUUID:=_CurrencyUUID, CustomerUUID:=_CustomerUUID, ProjectUUID:=_ProjectUUID, StateUUID:=_StateUUID, WarehouseUUID:=_Warehouse.UUID, GoodsUUIDs:=_GoodsUUIDs, GoodsQtys:=_GoodsQtys, GoodsAmounts:=_GoodsAmounts, InvocePaymentTypeUUID:=_InvocePaymentTypeUUID, Description:=_Description, Applicable:=False).UUID

        If lbDemandUUID.Tag.Length = 0 Then
            lbDemandUUID.Text = "Отгрузка НЕ создана!"
            Return False
        End If
        lbDemandUUID.Text = "Отгрузка создана"
        Return True
    End Function

    ''' <summary>
    ''' свяжет документы в МС
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function LinkOrderDemandPaymentIn() As Boolean
        Return oMCinterface.LinkOrderDemandPaymentIn(lbOrderUUID.Tag, lbDemandUUID.Tag, lbPaymentUUID.Tag)
    End Function


    ''' <summary>
    ''' добавить продажу в БД
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function RegisterInDb() As Boolean
        '==========================
        'добавить продажу в БД
        Dim _samplenumber = clsApplicationTypes.clsSampleNumber.CreateFromString(SKUTextBox.Text.Trim)

        Dim _ShippingInAmount As Decimal = clsApplicationTypes.ReplaceDecimalSplitter(ValueTextBox2)
        Dim _EbayFeeEndAmount = clsApplicationTypes.ReplaceDecimalSplitter(ValueTextBox4)
        Dim _tbPayPalFeeAmount = clsApplicationTypes.ReplaceDecimalSplitter(tbPayPalFeeAmount)

        Dim _client As Service.iMoySkladDataProvider.clsClientInfo = Me.lbCustomers.SelectedItem
        Dim _GoodAmount As Decimal = clsApplicationTypes.ReplaceDecimalSplitter(ValueTextBox1)
        Dim EbayAccount As emSLResource
        Select Case oCurrentAgent.account
            Case "trilbone"
                EbayAccount = emSLResource.eBayTrilbone
            Case "nordstarfossils"
                EbayAccount = emSLResource.eBayNordstar
            Case "trilbone_test"
                oSplash.Hide()
                Return False
            Case Else
                MsgBox(String.Format("Обработка аккаунта {0} из файла агента не задана. Внесите изменения в fmTrilboneEbay.vb строка 598", oCurrentAgent.account), vbCritical)
                oSplash.Hide()
                Return False
        End Select
        'первоначальная регистрация продажи камня
        Return clsApplicationTypes.SampleDataObject.RegisterSampleToSoldViaEbay(SampleNumber:=_samplenumber, clientName:=_client.FullName, clientEmail:=_client.Email, clientMoySkladCode:=_client.MSCode, EbayItemID:=Me.TransactionTypeBindingSource.Current.Item.ItemID, EbayAccount:=EbayAccount, itemAmount:=_GoodAmount, itemShippingAmount:=_ShippingInAmount, itemauctionfee:=_EbayFeeEndAmount, itemgetmoneyfee:=_tbPayPalFeeAmount, currency:=CurrencyIDTextBox.Text.ToUpper.Trim)

    End Function


#End Region


#Region "рассчеты трилбон"
    Private Sub btGetFullAmount_Click(sender As Object, e As EventArgs) Handles btGetFullAmount.Click
        Me.tbFullAmount.Text = Me.ValueTextBox.Text
    End Sub
    Private Sub btGetResorceFee_Click(sender As Object, e As EventArgs) Handles btGetResorceFee.Click
        'получить fee за выставление pSLGetSampleInsectionFeeTotal
        Dim _samplenumber = clsApplicationTypes.clsSampleNumber.CreateFromString(SKUTextBox.Text.Trim)
        If _samplenumber Is Nothing OrElse _samplenumber.CodeIsCorrect = False Then
            MsgBox("Не могу распознать код, записанный в SKU", vbCritical)
            Return
        End If
        Dim _result = (oReadySampleDBContext.pSLGetSampleInsectionFeeTotal(_samplenumber.GetEan13)).ToList

        If _result.Count > 0 Then
            If _result(0).totalfee > 0 Then
                Me.tbInsectionFee.Text = _result(0).totalfee
            End If
        End If
    End Sub

    Private Sub btShipmentOutFee_Click(sender As Object, e As EventArgs) Handles btShipmentOutFee.Click
        Dim _samplenumber = clsApplicationTypes.clsSampleNumber.CreateFromString(SKUTextBox.Text.Trim)
        If _samplenumber Is Nothing OrElse _samplenumber.CodeIsCorrect = False Then
            MsgBox("Не могу распознать код, записанный в SKU", vbCritical)
            Return
        End If

        Dim _result = (oReadySampleDBContext.pSLGetSampleLastSaleInfo(_samplenumber.GetEan13)).ToList

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
        Dim _samplenumber = clsApplicationTypes.clsSampleNumber.CreateFromString(SKUTextBox.Text.Trim)
        If _samplenumber Is Nothing OrElse _samplenumber.CodeIsCorrect = False Then
            MsgBox("Не могу распознать код, записанный в SKU", vbCritical)
            Return
        End If
        Dim _result = (clsApplicationTypes.SampleDataObject.GetdbPhotoObjectContext.Select_SampleInfo(_samplenumber.GetEan13)).ToList

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
        Me.tbSubTotal.Text = clsApplicationTypes.ReplaceDecimalSplitter(tbFullAmount) - (clsApplicationTypes.ReplaceDecimalSplitter(tbInsectionFee) + clsApplicationTypes.ReplaceDecimalSplitter(tbShipmentOutFee) + clsApplicationTypes.ReplaceDecimalSplitter(tbExportFee) + clsApplicationTypes.ReplaceDecimalSplitter(tbPayPalFeeAmount) + clsApplicationTypes.ReplaceDecimalSplitter(tbNalogFee) + oAuctionFee + oGetMoneyFee)
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




    Private Sub IMoySkladDataProvider_AddressBindingSource_CurrentChanged(sender As Object, e As EventArgs) Handles IMoySkladDataProvider_AddressBindingSource.CurrentChanged

    End Sub
End Class
