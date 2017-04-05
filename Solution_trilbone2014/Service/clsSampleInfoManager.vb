Imports System.Linq
'Imports System.Data.Objects
'Imports System.Data.Objects.DataClasses
Imports System.Runtime.Serialization
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.IO

Public Class clsSampleDataManager
#Region "определения"
    Private odbPhotoObjectContext As DBOPHOTOEntities
    Private oReadySampleObjectContext As DBREADYSAMPLEEntities
    Private odbModelNop350ObjectContext As Service.ModelNop350Container
    Private oNopObject As clsNopDataBuilder
    Public Const cntConnectTimeOut As Integer = 30
    Private oPhotoDBBuilder As EntityClient.EntityConnectionStringBuilder
    Private oReadySampleDBBuilder As EntityClient.EntityConnectionStringBuilder
    Private oNopDBBuilder As EntityClient.EntityConnectionStringBuilder

#End Region


    Public Event connected(ByVal message As String)
    ''' <summary>
    ''' статус подключения
    ''' </summary>
    Public ReadOnly Property IsConnected As Boolean
        Get
            If Me.odbPhotoObjectContext Is Nothing AndAlso oReadySampleObjectContext Is Nothing Then Return False
            Return True
        End Get

    End Property



    ''' <summary>
    ''' вернет интерфейс работы с сайтом
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property GetNopInterface As iNopDataProvider
        Get
            If oNopObject Is Nothing Then
                oNopObject = New clsNopDataBuilder(odbModelNop350ObjectContext)
            End If
            If oNopObject.IsConnect = False Then
                oNopObject = New clsNopDataBuilder(odbModelNop350ObjectContext)
            End If
            Return oNopObject
        End Get
    End Property




    ''' <summary>
    ''' возвращает обьект БД Poto
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property GetdbPhotoObjectContext As DBOPHOTOEntities
        Get
            Return odbPhotoObjectContext
        End Get
    End Property

    ''' <summary>
    ''' возвращает обьект БД ReadySample
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property GetdbReadySampleObjectContext As DBREADYSAMPLEEntities
        Get
            '!!! новый обьект!!!
            Return New DBREADYSAMPLEEntities(oReadySampleDBBuilder.ToString)
            'Return odbReadySampleObjectContext
        End Get
    End Property


    ''' <summary>
    ''' устанавливает соединение с хранилищем. Инициализует обьекты-контексты.
    ''' </summary>
    Public Function Connect(Optional ByRef ConnectMessage As String = "") As Boolean
        If Not Me.IsConnected Then
            '-----------Photo DB-----------
            'в строке указываются имена файлов соответствующих моделей EDMX
            Dim _SqlBuilder = New SqlClient.SqlConnectionStringBuilder(clsApplicationTypes.dboPhotoConnectionString)
            _SqlBuilder.ConnectTimeout = cntConnectTimeOut
            Me.oPhotoDBBuilder = New EntityClient.EntityConnectionStringBuilder

            With oPhotoDBBuilder
                .Provider = "System.Data.SqlClient"
                .ProviderConnectionString = _SqlBuilder.ToString
                .Metadata = "res://*/dbPhoto.csdl|" & _
                                  "res://*/dbPhoto.ssdl|" & _
                                  "res://*/dbPhoto.msl"
            End With

            Try
                odbPhotoObjectContext = New DBOPHOTOEntities(oPhotoDBBuilder.ToString)
            Catch ex As Exception
                ConnectMessage += " dbPhoto НЕ ПОДКЛЮЧЕНА."
            End Try

            ConnectMessage += " dbPhoto подключена."

            '----------ReadySampleDB--------------
            _SqlBuilder = New SqlClient.SqlConnectionStringBuilder(clsApplicationTypes.dbReadySampleConnectionString)
            _SqlBuilder.ConnectTimeout = cntConnectTimeOut
            Me.oReadySampleDBBuilder = New EntityClient.EntityConnectionStringBuilder
            With oReadySampleDBBuilder
                .Provider = "System.Data.SqlClient"
                .ProviderConnectionString = _SqlBuilder.ToString
                .Metadata = "res://*/dbReadySample.csdl|" & _
                                  "res://*/dbReadySample.ssdl|" & _
                                  "res://*/dbReadySample.msl"

            End With

            Try
                oReadySampleObjectContext = New DBREADYSAMPLEEntities(oReadySampleDBBuilder.ToString)
            Catch ex As Exception
                ConnectMessage += " dbReadySample НЕ ПОДКЛЮЧЕНА."
            End Try

            ConnectMessage += " dbReadySample подключена."

            '----------nopDB--------------
            _SqlBuilder = New SqlClient.SqlConnectionStringBuilder(clsApplicationTypes.dbNopConnectionString)
            _SqlBuilder.ConnectTimeout = cntConnectTimeOut
            Me.oNopDBBuilder = New EntityClient.EntityConnectionStringBuilder
            With oNopDBBuilder
                .Provider = "System.Data.SqlClient"
                .ProviderConnectionString = _SqlBuilder.ToString
                .Metadata = "res://*/ModelNop350.csdl|" & _
                                  "res://*/ModelNop350.ssdl|" & _
                                  "res://*/ModelNop350.msl"
            End With

            Try
                odbModelNop350ObjectContext = New ModelNop350Container(oNopDBBuilder.ToString)
            Catch ex As Exception
                ConnectMessage += " Nop350 НЕ ПОДКЛЮЧЕНА."
            End Try

            ConnectMessage += " Nop350 подключена."


        End If




        Return Me.IsConnected
    End Function


    Public Function AddDemandUUID(sampleNumber As Decimal, DemandUuid As String) As Integer
        Return oReadySampleObjectContext.pSLAddDemandUUID(sampleNumber, DemandUuid)
    End Function


    Public Function GetReadySamplesInfo(FilterDate As Date) As List(Of clsReadySamplesItem)
        Dim _out As New List(Of clsReadySamplesItem)


        'Dim _sdo = (From c In oReadySampleObjectContext.SamplesOnSale
        '            Where c.OnSaleFlag And Not c.SoldFlag
        '                          Where c.OnSaleDate >= FilterDate
        '                             Select New clsReadySamplesItem With {.ShotCode = c.SampleNumber}).ToList

        'For Each t In _sdo
        '    Dim _sm = clsApplicationTypes.clsSampleNumber.CreateFromString(t.ShotCode)
        '    Dim _ean13 = _sm.GetEan13

        '    'фильтр по проданным и выставленным
        '    Dim _res = From c In oReadySampleObjectContext.tbSLSample
        '             Where c.SampleNumber = _ean13
        '             Where c.SLoperationID = 2 Or c.SLoperationID = 1
        '             Where c.SLResourceID = 5

        '    If Not _res.Count > 0 Then
        '        With t
        '            .MainName = (From c In clsApplicationTypes.SampleDataObject.GetdbPhotoObjectContext.tb_Samples_photo_data
        '                         Where c.SampleNumber = _ean13
        '                         Select c.Sample_main_species).FirstOrDefault

        '            .TitleImage = clsApplicationTypes.SamplePhotoObject.GetMainImage(clsFilesSources.Arhive, _sm, True)
        '        End With
        '        _out.Add(t)
        '    End If
        'Next
        Return _out
    End Function



    Public Function AddOutParcelFee(demandUUID As String, totalInShippingFee As Decimal, parcelWeight As Decimal, parcelSizeA As Decimal, parcelSizeB As Decimal, parcelSizeC As Decimal) As Integer
        Return oReadySampleObjectContext.pSLAddOutShippingFee(demandUUID:=demandUUID, totalInShippingFee:=totalInShippingFee, parcelWeight:=parcelWeight, parcelSizeA:=parcelSizeA, parcelSizeB:=parcelSizeB, parcelSizeC:=parcelSizeC)
    End Function
    ''' <summary>
    ''' данные о образце
    ''' </summary>
    ''' <param name="EAN13"></param>
    ''' <returns></returns>
    Public Function GetSampleInfo(SampleNumber As clsApplicationTypes.clsSampleNumber) As Service.Select_SampleInfo_Result
        'TODO перевести часть вызовов GetSampleData сюда
        Dim _result = Me.odbPhotoObjectContext.Select_SampleInfo(SampleNumber.GetEan13).ToList
        Select Case _result.Count
            Case 0
                Return Nothing
            Case 1
                Return _result.First
            Case Else
                MsgBox("Повтор номера в БД!!", vbCritical)
                Return _result.First
        End Select
    End Function

    Private oMCoffline As Boolean
    Private oMColdGoodMapOffline As DataSet_oldGoodMap
    Private oMColdGoodMapOffline_tableadapter As DataSet_oldGoodMapTableAdapters.goodmapsTableAdapter
    ''' <summary>
    ''' переключает оффлайн и онлайн для таблицы oldgoodmap
    ''' </summary>
    ''' <param name="reload"></param>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property MColdgoodmapOffLine(Optional reload As Boolean = False) As Boolean
        Get
            Return oMCoffline
        End Get
        Set(value As Boolean)
            oMCoffline = value
            If oMCoffline Then
                If reload Or (oMColdGoodMapOffline Is Nothing) Then
                    oMColdGoodMapOffline = New DataSet_oldGoodMap
                    oMColdGoodMapOffline_tableadapter = New DataSet_oldGoodMapTableAdapters.goodmapsTableAdapter
                    oMColdGoodMapOffline_tableadapter.Fill(oMColdGoodMapOffline.goodmaps)
                End If
            Else

            End If
        End Set
    End Property
    ''' <summary>
    ''' запрос данных
    ''' </summary>
    ''' <param name="shotcode"></param>
    ''' <param name="partname"></param>
    ''' <param name="groupname"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetMcOld_result(shotcode As String, partname As String, groupname As String) As List(Of oldGoodMap_Result)
        If Me.oMCoffline Then
            Return Me.oMColdGoodMapOffline.GetMcOld_result(shotcode, partname, groupname)
        Else
            Return Me.odbPhotoObjectContext.oldGoodMap(shotcode, partname, groupname).ToList
        End If

    End Function

    Private oGroupListOldMC As New List(Of String)


    ''' <summary>
    ''' запрос списка групп
    ''' </summary>
    ''' <returns></returns>
    Public Function GetMcOld_groupList() As List(Of String)
        If oGroupListOldMC.Count = 0 Then
            oGroupListOldMC = Me.odbPhotoObjectContext.oldGoodMapGroups.ToList
        End If
        Return oGroupListOldMC
    End Function

    ''' <summary>
    ''' записывает в БД
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SaveMcOld_row() As Integer
#If Not Debug Then
 Try
         oMColdGoodMapOffline_tableadapter.InitUpdateCommand()
            Return oMColdGoodMapOffline_tableadapter.Update(oMColdGoodMapOffline)
        Catch ex As Exception
            Return -1
        End Try
#End If
        oMColdGoodMapOffline_tableadapter.InitUpdateCommand()
        Return oMColdGoodMapOffline_tableadapter.Update(oMColdGoodMapOffline)

    End Function
    ''' <summary>
    ''' записывает изменения в Датасет
    ''' </summary>
    ''' <param name="row"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SetMcOld_row(row As oldGoodMap_Result, Optional save As Boolean = False) As Integer
        If Me.oMCoffline Then
            Dim _res = Me.oMColdGoodMapOffline.UpdateMcOld(row)
            If _res > 0 And save Then
                _res = Me.SaveMcOld_row
            End If
            Return _res
        End If
        'онлайн не реализован
        Return -1
    End Function



    ''' <summary>
    ''' возвращает заполненный обьект с инфо об образце по номеру. _result = 0 - образца нет в БД, -1 - ошибка, 1 - образец есть, можно читать данные
    ''' </summary>
    ''' <param name="SampleNumber"></param>
    ''' <param name="_result"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetSampleData(SampleNumber As clsApplicationTypes.clsSampleNumber, Optional ByRef _result As Integer = 0) As Service.tb_Samples_photo_data

        Dim _num As Decimal = SampleNumber.GetEan13

        Dim e = (From c In Me.odbPhotoObjectContext.tb_Samples_photo_data Where c.SampleNumber = _num).ToList

        Select Case e.Count
            Case 0
                'образца с этим номером нет
                _result = 0
                Return Nothing
            Case 1
                'образец есть
                _result = 1
                If e.Item(0).tb_Samples_Fossils.IsLoaded Then
                    Me.odbPhotoObjectContext.Refresh(Objects.RefreshMode.StoreWins, e.Item(0))
                Else
                    e.Item(0).tb_Samples_Fossils.Load()
                End If

                Return e.Item(0)
            Case Is > 1
                'образцов несколько с одним номером - ошибка!
                Debug.Fail("в БД два или более образца с одним номером!", "class clsSampleDataManager, function GetSampleData")
                _result = -1
                e.Item(0).tb_Samples_Fossils.Load()
                Return e.Item(0)
            Case Else
                _result = -1
                Return Nothing
        End Select



    End Function
    ''' <summary>
    ''' вернет обьект с данными по заказу конкретного образца
    ''' </summary>
    ''' <param name="SampleNumber"></param>
    ''' <param name="OrderID"></param>
    ''' <param name="_result"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetSampleFinanceByOrder(SampleNumber As clsApplicationTypes.clsSampleNumber, OrderID As clsApplicationTypes.clsOrder, Optional ByRef _result As Integer = 0) As Service.SamplesAndOrders
        Dim _num As Decimal = SampleNumber.GetEan13
        Dim e = (From c In Me.oReadySampleObjectContext.SamplesAndOrders Where c.SampleNumber = _num And c.OrderID = OrderID.OrderID).ToList

        Select Case e.Count
            Case 0
                'образца с этим номером нет
                _result = 0
                Return Nothing
            Case 1
                'образец есть
                _result = 1
                Return e.Item(0)
            Case Is > 1
                'образцов несколько с одним номером - ошибка!
                Debug.Fail("в БД два или более образца с одним номером или номером заказа!", "class clsSampleDataManager, function GetSampleFinanceByOrder")
                _result = -1
                Return e.Item(0)
            Case Else
                _result = -1
                Return Nothing
        End Select
    End Function
    ''' <summary>
    ''' вернет обьект SampleOnSale для образца с номером. Result -1 error; 0 not exist; 1 ok
    ''' </summary>
    ''' <param name="SampleNumber"></param>
    ''' <param name="_result"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetSampleOnSale(SampleNumber As clsApplicationTypes.clsSampleNumber, Optional ByRef _result As Integer = 0, Optional CreateIfNotExist As Boolean = False) As Service.SamplesOnSale
        Dim _num As Decimal = SampleNumber.GetEan13

        Dim e = (From c In Me.oReadySampleObjectContext.SamplesOnSale Where c.SampleNumber = _num Select c).FirstOrDefault

        If e Is Nothing Then
            'образца с этим номером нет
            If CreateIfNotExist Then
                _result = 1
                Return CreateNewSampleFinance(SampleNumber)
            End If
            _result = 0
            Return Nothing
        Else
            'образец есть
            _result = 1
            Return e
        End If

        'Select Case e
        '    Case Is  Nothing

        '    Case 1

        '    Case Is > 1
        '        'образцов несколько с одним номером - ошибка!
        '        Debug.Fail("в БД два или более образца с одним номером!", "class clsSampleDataManager, function GetSampleFinance")
        '        _result = -1
        '        Return e.Item(0)
        '    Case Else
        '        _result = -1
        '        Return Nothing
        'End Select

    End Function
    ''' <summary>
    ''' создает новый обьект (новую запись)
    ''' </summary>
    ''' <param name="SampleNumber"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CreateNewSampleFinance(SampleNumber As clsApplicationTypes.clsSampleNumber) As Service.SamplesOnSale
        Dim _new = Service.SamplesOnSale.CreateSamplesOnSale(SampleNumber.GetEan13)
        With _new
            .BasePrice = 0
            .Costs = 0
            '  .CurrencyName = "USD"
            .Description = ""
            ' .FreeShippingPossibleFlag = False
            .OnSaleFlag = False
            '   .RateOfExchange = 0
            '  .ReservedFlag = False
            .SampleXMLDescription = ""
            '   .SoldFlag = False
            .SoldPrice = 0
        End With

        Me.oReadySampleObjectContext.SamplesOnSale.AddObject(_new)
        Me.oReadySampleObjectContext.SaveChanges()
        Return _new
    End Function

#Region "SL операции"
    ''' <summary>
    ''' описывает таблицу tbSLoperation
    ''' </summary>
    ''' <remarks></remarks>
    Private Enum emSLOperation
        SetToSale = 1
        Sold = 2
        Unsold = 3
        Lost = 4
    End Enum
    ''' <summary>
    ''' описывает таблицу tbSLResource
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum emSLResource
        DirectOffer = 1
        CatalogOffer = 2
        eBayTrilbone = 3
        eBayNordstar = 4
        SiteTrilbone = 5
        DealerSiteTrilbone = 6
    End Enum



#End Region

#Region "перечисления для time операций"
    ''' <summary>
    ''' значения соответствуют ID в БД tbWTimeOperation а также tbSMtimeoperation
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum emWTimeOperation As Integer
        NotConnected = -1
        NoStatus = 0
        BeginOnWork = 1
        EndWork = 2
        SuspendWork = 3
        SalaryStopLine = 4
        ClearOff = 5
    End Enum

    ''' <summary>
    '''  значения соответствуют ID в БД tbWTimeRecordType
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum emWTimeRecordType As Integer
        User = 1
        Computer = 2
        CorrectByUser = 3
        CorrectByAdmin = 4
    End Enum

#End Region

#Region "Wtime"
    ''' <summary>
    ''' запишет время прихода/ухода для текущего сотрудника EmployeeId
    ''' </summary>
    ''' <param name="WokerID"></param>
    ''' <param name="TimeOperation"></param>
    ''' <param name="RecordType"></param>
    ''' <param name="CorrectedID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function RegisterTime(EmployeeId As Integer, TimeOperation As emWTimeOperation, RecordType As emWTimeRecordType, Optional CorrectedID As Integer? = Nothing) As wGetLastOperation_Result

        Dim _result = (clsApplicationTypes.SampleDataObject.GetdbPhotoObjectContext.wRegisterTimeOperation(EmployeeId, clsApplicationTypes.GetCurrentTime, TimeOperation, RecordType, CorrectedID)).ToList

        If _result.Count = 0 Then Return Nothing
        If _result.Count > 1 Then
            'что-то пошло не так
            ' MsgBox("Регистрация времени вернула ", vbCritical)
        End If

        Return _result.First
    End Function
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="EmployeeId"></param>
    ''' <returns></returns>
    Public Function GetClearStatus(EmployeeId As Integer) As wGetLastClearOffOperation_Result
        Dim _result = (clsApplicationTypes.SampleDataObject.GetdbPhotoObjectContext.wGetLastClearOffOperation(EmployeeId)).ToList
        Return _result.FirstOrDefault
    End Function


#End Region

#Region "SMtime"


    ''' <summary>
    ''' запишет время образца SMOperationID для текущего сотрудника CurrentUser
    ''' </summary>
    ''' <param name="TimeOperation"></param>
    ''' <param name="RecordType"></param>
    ''' <param name="SMOperationID"></param>
    ''' <param name="CorrectedID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function RegisterOperation(TimeOperation As emWTimeOperation, RecordType As emWTimeRecordType, SMOperationID As Integer, Optional CorrectedID As Integer? = Nothing) As Boolean
        Dim _new = Service.tbSMTime.CreatetbSMTime(0, clsApplicationTypes.CurrentUser.Employee.ID, TimeOperation, RecordType, SMOperationID)
        With _new
            .TimeAccounting = clsApplicationTypes.GetCurrentTime
            .TimeMarker = clsApplicationTypes.GetCurrentTime
            .CorrectedID = CorrectedID
        End With

        Me.odbPhotoObjectContext.tbSMTime.AddObject(_new)

        If Me.IsConnected Then
            If Me.SavePhotoObjectContext() > 0 Then clsApplicationTypes.BeepYES() : Return True
        End If
        'не удалось вернуть данные в БД
        MsgBox("Не удалось записать операцию", vbCritical)
        Return False
    End Function


#End Region



    ''' <summary>
    ''' снимет образец с сайта
    ''' </summary>
    ''' <param name="SampleNumber"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function RegisterDeleteSampleOnSiteTrilbone(SampleNumber As clsApplicationTypes.clsSampleNumber) As Boolean
        Dim _user As String = ""
        If clsApplicationTypes.CurrentUser Is Nothing Then
            _user = "без регистрации"
        Else
            _user = clsApplicationTypes.CurrentUser.UserShotName
        End If

        Dim _result = oReadySampleObjectContext.pSLSampleEnd(sampleNumber:=SampleNumber.GetEan13, sLResourceID:=emSLResource.SiteTrilbone, sLResourceName:=_user, timeMarker:=Date.Now)
        If _result > 0 Then Return True
        Return False
    End Function



    ''' <summary>
    ''' Резерв камня на Сайте/ ACL=роль клиента сайта (магазин указать в Site) / цена и валюта для этой комбинации
    ''' </summary>
    ''' <param name="SampleNumber"></param>
    ''' <param name="Site">тип сайта</param>
    '''  <param name="clientName">имя клиента или РОЛИ на сайте</param>
    ''' <param name="ACL">роль клиента(магазин указан в Site)</param>
    ''' <param name="itemtitle">короткое описание</param>
    ''' <param name="itemcondition">????? TODO</param>
    ''' <param name="itemamount">значение цены в валюте</param>
    ''' <param name="InsectionFee">?????стоимость выставления</param>
    ''' <param name="currency">валюта</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function RegisterSampleToSiteTrilbone(SampleNumber As clsApplicationTypes.clsSampleNumber, ResourceID As emSLResource, ResourceName As String, clientName As String, itemtitle As String, itemcondition As String, itemamount As Decimal, InsectionFee As Decimal, Optional currency As String = "USD") As Boolean

        Dim _result = oReadySampleObjectContext.pSLSampleInsert(sampleNumber:=SampleNumber.GetEan13, sLResourceID:=ResourceID, sLResourceName:=ResourceName, title:=itemtitle, condition:=itemcondition, amount:=itemamount, currency:=currency, rate:=clsApplicationTypes.GetRateByCurrencyCB103(currency), clientEmail:="", clientMCID:="", clientName:=clientName, timeMarker:=clsApplicationTypes.GetCurrentTime, resourceFee:=InsectionFee, emailSended:=False)

        If _result > 0 Then Return True
        Return False
    End Function


    ''' <summary>
    ''' регистрация отсылки емайл
    ''' </summary>
    ''' <param name="SampleNumber"></param>
    ''' <param name="clientName"></param>
    ''' <param name="ResourceID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function RegisterSendedMail(SampleNumber As clsApplicationTypes.clsSampleNumber, clientName As String, ResourceID As emSLResource) As Boolean
        Me.oReadySampleObjectContext.Refresh(Objects.RefreshMode.StoreWins, Me.oReadySampleObjectContext.tbSLSample)
        'берем последнее предложение(!) по времени
        Dim _num = SampleNumber.GetEan13
        Dim _result = (From c In Me.oReadySampleObjectContext.tbSLSample
                    Where c.SampleNumber = _num And _
                    c.clientName = clientName And _
                    c.SLResourceID = ResourceID And _
                    c.SLoperationID = 1 And _
                    (c.emailSended = False Or c.emailSended Is Nothing)
                    Order By c.TimeMarker Descending).ToList

        If _result.Count = 0 Then
            ''записи об образце нет - создать??
            'Dim _new = tbSLSample.CreatetbSLSample(id:=0, timeMarker:=Now, sLoperationID:=1)
            '_new.SampleNumber = _num
            '_new.clientName = clientName
            '_new.SLResourceID = ResourceID
            '_new.emailSended = True
            'Me.oReadySampleObjectContext.tbSLSample.AddObject(_new)
        Else
            'и помечаем как отослан емайл
            _result.FirstOrDefault.emailSended = True
        End If

        If Me.SaveReadySampleContext() > 0 Then Return True
        Return False


    End Function



    Public Class clsSampleHistory

        Public Class clsSampleHistoryRecord

            Dim oClientName As String

            Property OperationID As Integer

            Property EmailSended As Boolean
            Property DateRecord As Date
            Property Operation As String
            Property Resource As String
            ''' <summary>
            ''' полная строка ресурса
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Property FullResourceName As String
            Property ClientName As String
                Get
                    If oClientName Is Nothing Then oClientName = ""
                    Return oClientName
                End Get
                Set(value As String)
                    oClientName = value
                End Set
            End Property
            Property ClientEmail As String
            ''' <summary>
            ''' сумма в валюте опрерации
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Property Amount As Decimal
            ''' <summary>
            ''' валюта операции
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Property Currency As String
            ''' <summary>
            ''' цена, пересчитанная по текущему рублевому курсу
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Property CurrentRURAmount As Decimal
            ''' <summary>
            ''' это запись продажи
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Property IsSoldRecord As Boolean
            ''' <summary>
            ''' чистые с продажи
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Property ClearSoldAmount As Decimal
        End Class

        Private oHistoryRecordsFull As List(Of clsSampleHistoryRecord)

        Private Sub New()

        End Sub

        Public Sub New(Records As List(Of clsSampleHistoryRecord))
            If Records Is Nothing Then
                Records = New List(Of clsSampleHistoryRecord)
            End If
            oHistoryRecordsFull = Records
            HistoryRecords = oHistoryRecordsFull
        End Sub

        ''' <summary>
        ''' форматированная строка истории предложений
        ''' </summary>
        ''' <param name="clientName"></param>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property OfferHistoryString(clientName As String) As String
            Get
                Dim _res = Me.HistoryRecords(clientName)
                If _res.Count = 0 Then Return "не был предложен"
                Dim _out As String = "Был предложен:" & ChrW(13)
                For Each t In _res
                    _out += String.Format("{0} за {2}{1}{3}", t.DateRecord.ToShortDateString, t.Amount, clsApplicationTypes.GetCurrencySymbol(t.Currency), ChrW(13))
                Next
                Return _out
            End Get
        End Property

        ' ''' <summary>
        ' ''' фильтрует по клиентам
        ' ''' </summary>
        ' ''' <param name="clientName"></param>
        ' ''' <remarks></remarks>
        'Public Sub ApplyHistoryFilter(clientName As String)
        '    HistoryRecords = oHistoryRecordsFull.Where(Function(x) x.ClienName.ToLower.Equals(clientName.ToLower))
        'End Sub

        Overloads ReadOnly Property HistoryRecords(clientName As String) As List(Of clsSampleHistoryRecord)
            Get
                If oHistoryRecordsFull.Count = 0 Then Return oHistoryRecordsFull
                Return oHistoryRecordsFull.Where(Function(x) IIf(String.IsNullOrEmpty(x.ClientName), False, x.ClientName.ToLower.Equals(clientName.ToLower))).ToList
            End Get
        End Property


        Friend Overloads Property HistoryRecords As List(Of clsSampleHistoryRecord)
            Get
                Return oHistoryRecordsFull
            End Get
            Set(value As List(Of clsSampleHistoryRecord))
                oHistoryRecordsFull = value
            End Set
        End Property


        ''' <summary>
        ''' образец продан
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ReadOnly Property ISsold As Boolean
            Get
                Dim _result = oHistoryRecordsFull.Where(Function(x) x.IsSoldRecord = True).Count
                If _result = 0 Then Return False
                Return True
            End Get
        End Property

        ''' <summary>
        ''' дата высланого емайл
        ''' </summary>
        ''' <param name="clientName"></param>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ReadOnly Property EmailSendedHistoryString(clientName As String) As String
            Get
                If Me.ISsold Then Return "продан"
                If Me.HistoryRecords(clientName).Count = 0 Then Return "не предлагался"
                Dim _date = From c In Me.HistoryRecords(clientName)
                         Where c.EmailSended = True
                         Where c.IsSoldRecord = False
                         Order By c.DateRecord Descending
                         Select c.DateRecord

                If _date.Count = 0 Then Return "емайл не высылался"

                Dim _res = (From d In Me.HistoryRecords(clientName).DefaultIfEmpty
                          Where d.DateRecord = _date.FirstOrDefault).ToList
                If _res.Count = 0 Then Return "емайл не высылался"
                Dim _out As String = "емайл высылался:" & ChrW(13)
                For Each t In _res
                    _out += String.Format("{0} за {2}{1}{3}", t.DateRecord.ToShortDateString, t.Amount, clsApplicationTypes.GetCurrencySymbol(t.Currency), ChrW(13))
                Next

                Return _out
            End Get
        End Property


        ''' <summary>
        ''' если есть хоть одна запись без отправки email, то считаем, что последнее предложение небыло отослано
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ReadOnly Property EmailSended(clientName As String) As Boolean
            Get
                'если есть хоть одна запись выставления без отправки email, то считаем, что последнее предложение небыло отослано
                If Me.ISsold Then Return True

                Dim _result = (From c In Me.HistoryRecords(clientName)
                         Where c.EmailSended = False
                         Where c.IsSoldRecord = False
                         Where c.OperationID = 1
                         Order By c.DateRecord Descending
                            Select c).ToList

                Dim _res = (From c In Me.HistoryRecords(clientName)
                         Where c.EmailSended = True
                         Where c.IsSoldRecord = False
                         Where c.OperationID = 1
                         Order By c.DateRecord Descending
                            Select c).ToList
                'запись об отправке емайл отсутствует
                If _res.Count = 0 Then Return False

                'запись об отправке присутствует
                Select Case _result.Count
                    Case 0
                        'записей без отправки емайл нет
                        Return True
                    Case 1
                        'есть запись без емай отправки
                        Return True
                    Case Else
                        'есть несколько записей без отправки емайл
                        Return True
                End Select

            End Get
        End Property

        ''' <summary>
        ''' грязная цена продажи
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ReadOnly Property SoldAmount As Decimal
            Get
                If Not ISsold Then Return 0
                Dim _result = oHistoryRecordsFull.Where(Function(x) x.IsSoldRecord = True).FirstOrDefault
                Return _result.Amount
            End Get
        End Property
        ''' <summary>
        ''' чистые, за вычетом фии ресурсов бабосы
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ReadOnly Property ClearSoldAmount As Decimal
            Get
                If Not ISsold Then Return 0
                Dim _result = oHistoryRecordsFull.Where(Function(x) x.IsSoldRecord = True).FirstOrDefault
                Return _result.ClearSoldAmount
            End Get
        End Property
        ''' <summary>
        ''' валюта
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ReadOnly Property SoldCurrency As String
            Get
                If Not ISsold Then Return ""
                Dim _result = oHistoryRecordsFull.Where(Function(x) x.IsSoldRecord = True).FirstOrDefault
                Return _result.Currency
            End Get
        End Property


    End Class

    Public Overloads Function GetActivityByNumberFromSite(SampleNumber As clsApplicationTypes.clsSampleNumber, Optional OnlyToday As Boolean = True) As List(Of String)
        Return GetActivityByNumberFromSite(SampleNumber.ShotCode, OnlyToday)
    End Function

    ''' <summary>
    ''' вернет лог с сайта для конкретного номера
    ''' </summary>
    ''' <param name="shotNumber"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function GetActivityByNumberFromSite(shotNumber As String, Optional OnlyToday As Boolean = True) As List(Of String)

        Dim _result = odbModelNop350ObjectContext.GetActivityByNumber(shotNumber:=shotNumber)

        Dim _out As List(Of String)

        If OnlyToday Then
            _out = (From c In _result Where c.CreatedOnUtc.ToLocalTime.Day = Date.Now.Day Select String.Format("{1}: {0}", c.Comment, c.CreatedOnUtc.ToLocalTime.ToString())).ToList
        Else
            _out = (From c In _result Select String.Format("{1}: {0}", c.Comment, c.CreatedOnUtc.ToLocalTime.ToString())).ToList
        End If

        Return _out
    End Function

    ''' <summary>
    ''' перегрузка функции
    ''' </summary>
    ''' <param name="ShotNumber"></param>
    ''' <param name="ClientName"></param>
    ''' <param name="includeCatalogHistory"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function GetSampleHistoryInfo(ShotNumber As String, Optional ClientName As String = "", Optional includeCatalogHistory As Boolean = True) As clsSampleHistory
        Dim _sm = clsApplicationTypes.clsSampleNumber.CreateFromString(ShotNumber)
        If _sm.CodeIsCorrect = False Then Return New clsSampleHistory(Nothing)
        Return GetSampleHistoryInfo(_sm, ClientName, includeCatalogHistory)
    End Function

    ''' <summary>
    ''' обьект описания истории. пока только из БД Trilbone.
    ''' </summary>
    ''' <param name="SampleNumber"></param>
    ''' <param name="ClientName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function GetSampleHistoryInfo(SampleNumber As clsApplicationTypes.clsSampleNumber, Optional ClientName As String = "", Optional includeCatalogHistory As Boolean = True) As clsSampleHistory
        If SampleNumber.CodeIsCorrect = False Then Return New clsSampleHistory(Nothing)

        Dim _result = oReadySampleObjectContext.pSLGetSampleHistoryInfo(sampleNumber:=SampleNumber.GetEan13)

        'фильтры
        If Not String.IsNullOrEmpty(ClientName) Then
            _result = _result.Where(Function(x) x.clientName.ToLower.Equals(ClientName.ToLower))
        End If

        'история из БД Trilbone
        Dim _records As List(Of clsSampleHistory.clsSampleHistoryRecord) = (From c In _result.ToList Select New clsSampleHistory.clsSampleHistoryRecord With {.Amount = IIf(c.startPrice.HasValue, c.startPrice, 0), .ClientName = c.clientName, .ClientEmail = c.clientEmail, .Currency = c.currency, .DateRecord = c.Date, .FullResourceName = c.ResourceInnerType, .Operation = c.Operation, .OperationID = c.SLoperationID, .Resource = c.Resource, .CurrentRURAmount = IIf(c.startPrice.HasValue, clsApplicationTypes.GetRateByCurrencyCB103(c.currency) * c.startPrice, 0), .IsSoldRecord = IIf(c.SLoperationID = 2, True, False), .ClearSoldAmount = IIf(c.TotalMoney.HasValue, c.TotalMoney, 0), .EmailSended = c.emailSended.GetValueOrDefault}).ToList

        If _records Is Nothing Then _records = New List(Of clsSampleHistory.clsSampleHistoryRecord)
        '==========================
        If includeCatalogHistory Then
            '+история из каталогов
            Dim _orderinfo = (oReadySampleObjectContext.OrderInfo(SampleNumber.GetEan13)).ToList 'New List(Of OrderInfo_Result) '
            If Not _orderinfo.Count = 0 Then
                For Each k In _orderinfo
                    Dim _offerPrice = Math.Round((k.Offer_Price.GetValueOrDefault - (k.Offer_Price.GetValueOrDefault * k.Offer_Discount.GetValueOrDefault / 100)), 2)
                    Dim _currency As String = IIf(String.IsNullOrEmpty(k.Currency), "USD", k.Currency).ToString.ToUpper.Trim

                    Dim _newrec = New clsSampleHistory.clsSampleHistoryRecord
                    With _newrec
                        .Amount = _offerPrice
                        .ClientName = k.Client_full_name.Trim
                        .ClientEmail = ""
                        .Currency = IIf(String.IsNullOrEmpty(_currency) Or _currency = " ", "USD", _currency)
                        .DateRecord = k.OrderDate.ToShortDateString
                        .FullResourceName = "Catalog " & k.OrderID
                        .Resource = "Предложение каталогом"
                        .CurrentRURAmount = clsApplicationTypes.GetRateByCurrencyCB103(.Currency) * _offerPrice
                        .IsSoldRecord = False
                        If .Amount = .CurrentRURAmount AndAlso .Amount > 0 Then
                            ''MsgBox("oops")
                        End If
                    End With

                    If k.Sample_Confirm_Status Then
                        'продан
                        _newrec.Operation = "Продан"
                        _newrec.OperationID = 2
                        _newrec.IsSoldRecord = True
                        _newrec.ClearSoldAmount = k.Sample_Confirm_Price.GetValueOrDefault
                    ElseIf k.Order_Cancellation_Status = False And k.Order_CheckOut_Status = False And k.Order_StockOut_Status = False Then
                        'каталог активен
                        _newrec.Operation = "Поставлен на продажу"
                        _newrec.OperationID = 1
                    ElseIf k.Order_Cancellation_Status = True Then
                        'каталог отменен
                        _newrec.Operation = "Снят с продажи" & "отменено все предложение"
                        _newrec.OperationID = 3
                    ElseIf k.Order_CheckOut_Status Or k.Order_StockOut_Status Then
                        'был предложен, но не куплен
                        _newrec.Operation = "Снят с продажи" & "отменено все предложение"
                        _newrec.OperationID = 3
                    End If
                    _records.Add(_newrec)
                Next
            End If
        End If

        '=============
        'TODO +история из Мой Склад
        'проверка наличия на складе
        'список отгрузок, в которых есть товар - оттуда список клиентов, которым был предложен

        '==============
        'вывод
        Dim _out As New clsSampleHistory(_records)
        Return _out
    End Function


    ''' <summary>
    ''' Резерв камня на eBay
    ''' </summary>
    ''' <param name="SampleNumber"></param>
    ''' <param name="EbayAccount"></param>
    ''' <param name="AuctionTypeName">тип аукциона BuyItNow и проч.</param>
    ''' <param name="itemtitle"></param>
    ''' <param name="itemcondition"></param>
    ''' <param name="itemamount">сумма выставления</param>
    ''' <param name="currency"></param>
    ''' <param name="InsectionFee">стоимость выставления</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function RegisterSampleToEbaySale(SampleNumber As clsApplicationTypes.clsSampleNumber, EbayAccount As emSLResource, AuctionTypeName As String, itemtitle As String, itemcondition As String, itemamount As Decimal, InsectionFee As Decimal, receivedMoneyPayPal As String, Optional currency As String = "USD") As Boolean

        Dim _result = oReadySampleObjectContext.pSLSampleInsert(sampleNumber:=SampleNumber.GetEan13, sLResourceID:=EbayAccount, sLResourceName:=AuctionTypeName, title:=itemtitle, condition:=itemcondition, amount:=itemamount, currency:=currency, rate:=clsApplicationTypes.GetRateByCurrencyCB103(currency), clientEmail:=receivedMoneyPayPal, clientMCID:="", clientName:="", timeMarker:=clsApplicationTypes.GetCurrentTime, resourceFee:=InsectionFee, emailSended:=False)

        If _result > 0 Then Return True
        Return False
    End Function

    ''' <summary>
    ''' образец продан через eBay
    ''' </summary>
    ''' <param name="SampleNumber"></param>
    ''' <param name="EbayAccount"></param>
    ''' <param name="EbayItemID">внутренний ID eBay</param>
    ''' <param name="clientName"></param>
    ''' <param name="clientEmail"></param>
    ''' <param name="clientMoySkladCode">код из МС = eBay ник</param>
    ''' <param name="itemAmount">за сколько продан (грязная сумма eBay)</param>
    ''' <param name="itemShippingAmount">сколько получено на шиппинг</param>
    ''' <param name="itemShippingOutFee">сколько потрачено на шиппинг</param>
    ''' <param name="itemexportfee">сколько потрачено на экспорт</param>
    ''' <param name="itemauctionfee">потрачено на eBayFee по окончании аукциона (сумма за выставление будет добавлена в БД на основании записи о выставлении на продажу</param>
    ''' <param name="itemgetmoneyfee">потрачено на PayPal Fee за прием платежа и % или сумма за вывод в наличные</param>
    ''' <param name="itemnalogifee">потрачено налогов</param>
    ''' <param name="itemtrilbonefee">сумма, которую мы списываем за услугу продажи</param>
    ''' <param name="currency"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function RegisterSampleToSoldViaEbay(SampleNumber As clsApplicationTypes.clsSampleNumber, EbayAccount As emSLResource, EbayItemID As String, clientName As String, clientEmail As String, clientMoySkladCode As String, itemAmount As Decimal, itemShippingAmount As Decimal, itemauctionfee As Decimal, itemgetmoneyfee As Decimal, Optional currency As String = "USD") As Boolean
        Dim _result = oReadySampleObjectContext.pSLSampleSingleSold(samplenumber:=SampleNumber.GetEan13, sLResourceID:=EbayAccount, sLResourceName:=EbayItemID, clientName:=clientName, clientEmail:=clientEmail, clientMCID:=clientMoySkladCode, amount:=itemAmount, shippinginamount:=itemShippingAmount, auctionfee:=itemauctionfee, exportfee:=0, getmoneyfee:=itemgetmoneyfee, nalogifee:=0, shippingoutfee:=0, trilbonefee:=0, timeMarker:=clsApplicationTypes.GetCurrentTime, currency:=currency)
        If _result > 0 Then Return True
        Return False
    End Function



    ''' <summary>
    ''' Резерв камня для почтового предложения
    ''' </summary>
    ''' <param name="SampleNumber"></param>
    ''' <param name="clientName">Кому</param>
    ''' <param name="clientEmail">Кому</param>
    ''' <param name="clientMoySkladCode">Кому (код из МС)</param>
    ''' <param name="mailtitle"></param>
    ''' <param name="itemcondition"></param>
    ''' <param name="itemamount">за сколько выставлен (грязная сумма)</param>
    ''' <param name="currency"></param>
    ''' <param name="InsectionFee">стоимость размещения предложения (стоимость почтовой рассылки??)</param>
    ''' <param name="SendFromMail">с какого ящика отправили</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function RegisterSampleToMailOffer(SampleNumber As clsApplicationTypes.clsSampleNumber, SendFromMail As String, clientName As String, clientEmail As String, clientMoySkladCode As String, mailtitle As String, itemcondition As String, itemamount As Decimal, Optional currency As String = "USD", Optional InsectionFee As Decimal = 0) As Boolean
        Dim _result = oReadySampleObjectContext.pSLSampleInsert(sampleNumber:=SampleNumber.GetEan13, sLResourceID:=emSLResource.DirectOffer, sLResourceName:=SendFromMail, title:=mailtitle, condition:=itemcondition, amount:=itemamount, currency:=currency, rate:=clsApplicationTypes.GetRateByCurrencyCB103(currency), clientEmail:=clientEmail, clientMCID:=clientMoySkladCode, clientName:=clientName, timeMarker:=clsApplicationTypes.GetCurrentTime, resourceFee:=InsectionFee, emailSended:=True)

        If _result > 0 Then Return True
        Return False
    End Function
    ''' <summary>
    '''  образец продан через почту
    ''' </summary>
    ''' <param name="SampleNumber"></param>
    ''' <param name="clientName"></param>
    ''' <param name="clientEmail"></param>
    ''' <param name="clientMoySkladCode"></param>
    ''' <param name="itemAmount">за сколько продан (грязная сумма)</param>
    ''' <param name="itemShippingAmount">сколько получим за шиппинг</param>
    ''' <param name="itemShippingOutFee">сколько потрачено на шиппинг</param>
    ''' <param name="itemexportfee">сколько потрачено на экспорт</param>
    ''' <param name="itemgetmoneyfee">потрачено на прием платежа и % или сумма за вывод в наличные</param>
    ''' <param name="itemnalogifee">потрачено налогов</param>
    ''' <param name="itemtrilbonefee">сумма, которую мы списываем за услугу продажи</param>
    ''' <param name="currency"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function RegisterSampleToSoldViaEmail(SampleNumber As clsApplicationTypes.clsSampleNumber, clientName As String, clientEmail As String, clientMoySkladCode As String, itemAmount As Decimal, itemShippingAmount As Decimal, itemShippingOutFee As Decimal, itemexportfee As Decimal, itemgetmoneyfee As Decimal, itemnalogifee As Decimal, itemtrilbonefee As Decimal, Optional currency As String = "USD") As Boolean
        Dim _result = oReadySampleObjectContext.pSLSampleSingleSold(samplenumber:=SampleNumber.GetEan13, sLResourceID:=emSLResource.DirectOffer, sLResourceName:="mail", clientName:=clientName, clientEmail:=clientEmail, clientMCID:=clientMoySkladCode, amount:=itemAmount, shippinginamount:=itemShippingAmount, auctionfee:=0, exportfee:=itemexportfee, getmoneyfee:=itemgetmoneyfee, nalogifee:=itemnalogifee, shippingoutfee:=itemShippingOutFee, trilbonefee:=itemtrilbonefee, timeMarker:=clsApplicationTypes.GetCurrentTime, currency:=currency)

        If _result > 0 Then Return True
        Return False
    End Function

    ''' <summary>
    ''' регистрация продажи в общем
    ''' </summary>
    ''' <param name="SampleNumber"></param>
    ''' <param name="clientName"></param>
    ''' <param name="clientEmail"></param>
    ''' <param name="clientMoySkladCode"></param>
    ''' <param name="itemAmount">за сколько продан (грязная сумма)</param>
    ''' <param name="itemShippingAmount">сколько получим за шиппинг</param>
    ''' <param name="itemShippingOutFee">сколько потрачено на шиппинг</param>
    ''' <param name="itemexportfee">сколько потрачено на экспорт</param>
    ''' <param name="itemgetmoneyfee">потрачено на прием платежа и % или сумма за вывод в наличные</param>
    ''' <param name="itemnalogifee">потрачено налогов</param>
    ''' <param name="itemtrilbonefee">сумма, которую мы списываем за услугу продажи</param>
    ''' <param name="currency"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function RegisterSampleToSold(SampleNumber As clsApplicationTypes.clsSampleNumber, clientName As String, clientEmail As String, clientMoySkladCode As String, sLResourceName As String, itemAmount As Decimal, itemShippingAmount As Decimal, itemShippingOutFee As Decimal, itemexportfee As Decimal, itemgetmoneyfee As Decimal, itemnalogifee As Decimal, itemtrilbonefee As Decimal, Optional currency As String = "USD") As Boolean

        Dim _result = oReadySampleObjectContext.pSLSampleSingleSold(samplenumber:=SampleNumber.GetEan13, sLResourceID:=emSLResource.DirectOffer, sLResourceName:=sLResourceName, clientName:=clientName, clientEmail:=clientEmail, clientMCID:=clientMoySkladCode, amount:=itemAmount, shippinginamount:=itemShippingAmount, auctionfee:=0, exportfee:=itemexportfee, getmoneyfee:=itemgetmoneyfee, nalogifee:=itemnalogifee, shippingoutfee:=itemShippingOutFee, trilbonefee:=itemtrilbonefee, timeMarker:=clsApplicationTypes.GetCurrentTime, currency:=currency)

        If _result > 0 Then Return True
        Return False
    End Function

    ''' <summary>
    ''' снять с продажи образец
    ''' </summary>
    ''' <param name="SampleNumber"></param>
    ''' <param name="ResourceID">тип ресурса, с которого снят камень</param>
    ''' <param name="ResourceName">для eBay - ItemID, для почты - ничего, и т.д.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function RegisterSampleUnsold(SampleNumber As clsApplicationTypes.clsSampleNumber, ResourceID As emSLResource, ResourceName As String) As Boolean
        Dim _result = oReadySampleObjectContext.pSLSampleEnd(sampleNumber:=SampleNumber.GetEan13, sLResourceID:=ResourceID, sLResourceName:=ResourceName, timeMarker:=clsApplicationTypes.GetCurrentTime)
        If _result > 0 Then Return True
        Return False
    End Function


    ''' <summary>
    ''' образец потерялся
    ''' </summary>
    ''' <param name="SampleNumber"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function RegisterSampleAsLost(SampleNumber As clsApplicationTypes.clsSampleNumber) As Boolean
        Dim _result = oReadySampleObjectContext.pSLSampleLost(sampleNumber:=SampleNumber.GetEan13, timeMarker:=clsApplicationTypes.GetCurrentTime)
        If _result > 0 Then Return True
        Return False
    End Function





    ''' <summary>
    ''' возвращает список всех упомянутых в БД имен
    ''' </summary>
    Public Function GetAllNamesList() As ArrayList

        Dim _arr As New ArrayList

        For Each c In Me.odbPhotoObjectContext.GetNamesList()

            _arr.Add(New With {.fossil = c.Fossil_full_name, .count = c.NameCount})
        Next
        Return _arr
    End Function
    ''' <summary>
    ''' записывает в таблицу использованных номеров код. Проверит наличие в БД.
    ''' </summary>
    ''' <param name="EAN13"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function RegisterEan13ToDB(EAN13 As String) As Boolean
        Dim _number = clsApplicationTypes.clsSampleNumber.CreateFromString(EAN13)
        If Not _number.CodeIsCorrect Then Return False
        Dim _result = Me.odbPhotoObjectContext.WriteAsEAN13(EAN13)
        If _result.Count = 0 Then Return False
        If _result.First = 0 Then Return False
        Return True
    End Function


    ''' <summary>
    ''' вернет новый код по серии или ничего
    ''' </summary>
    ''' <param name="Series"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetNewNumberBySeries(Series As String) As String
        If Series = "" Then Return ""
        Select Case Series.Length
            Case 1
                'запрос сначала серии
                Dim _res1 = (From c In Me.odbPhotoObjectContext.pGetSeriesByShot(Series) Select c).ToList
                Select Case _res1.Count
                    Case 0
                        'нет такой серии
                        Return ""
                    Case 1
                        'серия однозначна
                        Series = _res1(0).Series
                    Case Else
                        'несколько серий
                        MsgBox("Несколько серий. Нет реализации", vbCritical)
                        Return ""
                End Select

            Case 2
                'что-то не так
                Return ""
            Case 3
                'ok - три символа в серии
            Case Else

        End Select
        Try
            Dim _res = (From c In Me.odbPhotoObjectContext.GetNewCodeBySeries(Series) Select c).ToList
            If _res.Count > 0 Then
                Dim _new = clsApplicationTypes.clsSampleNumber.CreateFromString(_res(0))
                If Not _new Is Nothing Then
                    Return _new.ShotCode
                End If
            End If
        Catch ex As Exception
            MsgBox("Проблемы с подключением к БД", vbCritical)
            Return ""
        End Try


        Return ""
    End Function

    ''' <summary>
    ''' возвращает список обьектов по запросу части имени
    ''' </summary>
    ''' <param name="NamePart">часть имени</param>
    Public Function GetFossilByNameList(NamePart As String) As List(Of Select_tb_Fossils_byname_Result)

        Dim e = (From c In Me.odbPhotoObjectContext.Select_tb_Fossils_byname(NamePart) Select c).ToList

        Return e
    End Function


    Public Function GetSampleByWeight(fromWeight As Decimal, toWeight As Decimal) As List(Of FindByWeight_Result)
        Return Me.odbPhotoObjectContext.FindByWeight(fromWeight, toWeight).ToList
    End Function

    ''' <summary>
    ''' отменяет изменения и заменяет данные клиента на данные БД
    ''' </summary>
    ''' <param name="entity"></param>
    ''' <remarks></remarks>
    Public Sub CancelSampleData(entity As Service.tb_Samples_photo_data)
        Me.oReadySampleObjectContext.Refresh(Objects.RefreshMode.StoreWins, entity)
    End Sub


    ''' <summary>
    ''' отменяет изменения и заменяет данные клиента на данные БД
    ''' </summary>
    ''' <param name="entity"></param>
    ''' <remarks></remarks>
    Public Sub CancelSampleFinance(entity As Service.SamplesOnSale)
        Me.oReadySampleObjectContext.Refresh(Objects.RefreshMode.StoreWins, entity)
    End Sub

    ''' <summary>
    ''' сохраняет изменения в БД и возвращает их кол-во
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SaveReadySampleContext() As Integer

        'посчитаем кол-во изменений
        Dim _countChanges As Integer = 0
        _countChanges += Me.oReadySampleObjectContext.ObjectStateManager.GetObjectStateEntries(EntityState.Modified).Count
        _countChanges += Me.oReadySampleObjectContext.ObjectStateManager.GetObjectStateEntries(EntityState.Added).Count
        _countChanges += Me.oReadySampleObjectContext.ObjectStateManager.GetObjectStateEntries(EntityState.Deleted).Count

        If _countChanges = 0 Then Return 0

        Dim _result As Integer
        Try
            _result = Me.oReadySampleObjectContext.SaveChanges(Objects.SaveOptions.AcceptAllChangesAfterSave)

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
            oNeedSaveContextFlag = True
            Return -1
        End Try
        If Not _result = _countChanges Then
            'сохранены не все изменения
            oNeedSaveContextFlag = True
            MsgBox("Сохранены не все изменения в БД", vbCritical)
            Return _result
        End If

        oNeedSaveContextFlag = False
        Return _result

    End Function

    Private oNeedSaveContextFlag As Boolean

    ''' <summary>
    ''' установлен, если изменения в бд не удалось сохранить. Вызывает процедуры сохранения контекстов. В случае true необходимо сохранить обьекты на диск, вызвав SaveContextToDisk.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property NeedSaveContextFlag As Boolean
        Get
            If oNeedSaveContextFlag = False Then
                'сохраним контексты
                Me.SavePhotoObjectContext()
                Me.SaveReadySampleContext()
            End If
            Return oNeedSaveContextFlag
        End Get
    End Property

    ' ''' <summary>
    ' ''' сохраняет контексты локально (в GDRIVE???)
    ' ''' </summary>
    ' ''' <returns></returns>
    ' ''' <remarks></remarks>
    'Public Function SaveContextToDisk() As Boolean
    '    Dim _path = clsApplicationTypes.LocalDataFilePath
    '    Dim _filename = clsApplicationTypes.GetCurrentTime.GetHashCode.ToString & "_dbPHOTOtrilbone.bin"
    '    Dim _fullname = IO.Path.Combine(_path, _filename)
    '    Dim _formatter As New BinaryFormatter()

    '    Try
    '        Using _stream As New FileStream(_fullname, FileMode.Create)
    '            _formatter.Serialize(_stream, Me.odbPhotoObjectContext)
    '            _stream.Flush()
    '            _stream.Close()
    '        End Using

    '        _filename = clsApplicationTypes.GetCurrentTime.GetHashCode.ToString & "_dbReadySampletrilbone.bin"
    '        _fullname = IO.Path.Combine(_path, _filename)
    '        _formatter = New BinaryFormatter()
    '        Using _stream As New FileStream(_fullname, FileMode.Create)
    '            _formatter.Serialize(_stream, Me.odbReadySampleObjectContext)
    '            _stream.Flush()
    '            _stream.Close()
    '        End Using
    '    Catch ex As IOException
    '        MsgBox("Не удалось сохранить данные БД на диск", vbCritical)
    '        Return False
    '    End Try
    '    Return True
    'End Function

    ''' <summary>
    ''' сохраняет изменения в БД и возвращает их кол-во
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SavePhotoObjectContext() As Integer
        'посчитаем кол-во изменений
        Dim _countChanges As Integer = 0
        _countChanges += Me.odbPhotoObjectContext.ObjectStateManager.GetObjectStateEntries(EntityState.Modified).Count
        _countChanges += Me.odbPhotoObjectContext.ObjectStateManager.GetObjectStateEntries(EntityState.Added).Count
        _countChanges += Me.odbPhotoObjectContext.ObjectStateManager.GetObjectStateEntries(EntityState.Deleted).Count

        If _countChanges = 0 Then Return 0

        Dim _result As Integer
        Try
            _result = Me.odbPhotoObjectContext.SaveChanges(Objects.SaveOptions.AcceptAllChangesAfterSave)
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
            oNeedSaveContextFlag = True
            Return -1
        End Try

        If Not _result = _countChanges Then
            'сохранены не все изменения
            oNeedSaveContextFlag = True
            MsgBox("Сохранены не все изменения в БД", vbCritical)
            Return _result
        End If

        oNeedSaveContextFlag = False
        Return _result
    End Function



    ''' <summary>
    ''' 
    ''' </summary>
    Public Sub New()
    End Sub
    ''' <summary>
    ''' обновляет данные в БД
    ''' </summary>
    ''' <param name="SampleNumber"></param>
    ''' <param name="itemShippingOutFee"></param>
    ''' <param name="itemauctionfee"></param>
    ''' <param name="itemexportfee"></param>
    ''' <param name="itemgetmoneyfee"></param>
    ''' <param name="itemnalogifee"></param>
    ''' <param name="itemtrilbonefee"></param>
    ''' <param name="currency"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function UpdateSampleToSoldViaEbay(demandUUID As String, itemauctionfee As Decimal, itemexportfee As Decimal, itemgetmoneyfee As Decimal, itemnalogifee As Decimal, itemtrilbonefee As Decimal, subTotal As Decimal) As Boolean
        Dim _result = oReadySampleObjectContext.pSLAddInfoToSaleByDemandUUID(demandUUID:=demandUUID, auctionfee:=itemauctionfee, exportfee:=itemexportfee, getmoneyfee:=itemgetmoneyfee, nalogifee:=itemnalogifee, trilbonefee:=itemtrilbonefee, subTotal:=subTotal)
        If _result > 0 Then Return True
        Return False
    End Function

    ' ''' <summary>
    ' ''' найти записи о выставлении по части названия листинга на аукционе
    ' ''' </summary>
    ' ''' <param name="partoftitle"></param>
    ' ''' <returns></returns>
    ' ''' <remarks></remarks>
    'Public Function FindInSampleRecordsByTitlePart(partoftitle As String) As List(Of clsFindSamleTable_Result)
    '    'берем sql из ресурса
    '    Dim _sql = My.Resources.Resource_sql.SQLQuery_поиск_выставленных
    '    Return clsDataQweryHelper(Of clsFindSamleTable_Result).GetResult(partoftitle, Me.oReadySampleObjectContext, _sql)
    'End Function
    ' ''' <summary>
    ' ''' класс результатов запроса
    ' ''' </summary>
    ' ''' <remarks></remarks>
    'Public Class clsFindSamleTable_Result
    '    'tr.Name as resource,sm.TimeMarker as date,sm.SampleNumber,sm.Title,sm.amount,sm.currency
    '    Property resource As String
    '    Property [date] As Date
    '    Property SampleNumber As Decimal
    '    Property Title As String
    '    Property amount As Decimal
    '    Property currency As String
    'End Class

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <remarks></remarks>
    Public Class clsDataQweryHelper(Of T)
        ''' <summary>
        ''' param - подстановочный параметр запроса, sql - сам запрос, где место вставки помечено #n или другим placemarker, context - то, куда выполняем запрос
        ''' T - класс, содержащий открытые свойства идиентичные запросу (включая типы данных)
        ''' </summary>
        ''' <param name="param"></param>
        ''' <param name="context"></param>
        ''' <param name="sql"></param>
        ''' <param name="placemarker"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function GetResult(param As String, context As Objects.ObjectContext, sql As String, Optional placemarker As String = "#n") As List(Of T)
            'надо создать класс, содержащий поля идиентичные запросу
            sql = sql.Replace(placemarker, param)
            Dim _result = context.ExecuteStoreQuery(Of T)(sql, Nothing)
            Return _result.ToList
        End Function
    End Class



    

End Class

Partial Public Class Select_tb_Fossils_byname_Result

    ' Dim oTitleImage As Drawing.Image


    Private ReadOnly Property TitleImage As Drawing.Image
        Get
            Static _img As Drawing.Image

            If _img Is Nothing Then
                _img = clsApplicationTypes.SamplePhotoObject.GetMainImage(clsFilesSources.CreateInstance(clsFilesSources.emSources.Arhive), SampleNumberObj, True)
                _img = Service.clsIDcontent.GetResizedImage(_img, 150)
            End If
            'Me.oTitleImage = _img

            Return _img
        End Get

    End Property

    Public ReadOnly Property SampleNumberObj As clsApplicationTypes.clsSampleNumber
        Get
            Static _num As clsApplicationTypes.clsSampleNumber
            If _num Is Nothing Then
                _num = clsApplicationTypes.clsSampleNumber.CreateFromString(Me.SampleNumber)
                Debug.Assert(Not _num Is Nothing, "неверно используется свойство")
            End If
            Return _num
        End Get
    End Property

    ''' <summary>
    ''' изображение для отображения
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Image As Drawing.Image
        Get
            Return Me.TitleImage
        End Get
    End Property



End Class

Partial Class FindByWeight_Result
    ' Dim oTitleImage As Drawing.Image
    Public ReadOnly Property SampleDimension As String
        Get
            Return String.Format("{0}x{1}x{2}", Me.Sample_length, Me.Sample_width, Me.Sample_height)
        End Get
    End Property

    Private ReadOnly Property TitleImage As Drawing.Image
        Get
            Static _img As Drawing.Image
            If _img Is Nothing Then
                _img = clsApplicationTypes.SamplePhotoObject.GetMainImage(clsFilesSources.CreateInstance(clsFilesSources.emSources.Arhive), SampleNumberObj, True)
                _img = Service.clsIDcontent.GetResizedImage(_img, 150)
            End If
            ' Me.oTitleImage = _img
            Return _img
        End Get

    End Property
    Public ReadOnly Property SampleNumberObj As clsApplicationTypes.clsSampleNumber
        Get
            Static _num As clsApplicationTypes.clsSampleNumber
            If _num Is Nothing Then
                _num = clsApplicationTypes.clsSampleNumber.CreateFromString(Me.SampleNumber)
                Debug.Assert(Not _num Is Nothing, "неверно используется свойство")
            End If
            Return _num
        End Get
    End Property

    ''' <summary>
    ''' изображение для отображения
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Image As Drawing.Image
        Get
            Return Me.TitleImage
        End Get
    End Property

    Public ReadOnly Property ShotNumber As String
        Get
            Return SampleNumberObj.ShotCode
        End Get
    End Property
End Class

Partial Class Select_SampleInfo_Result

    Public Shared Widening Operator CType(ByVal d As Select_SampleInfo_Result) As FindByWeight_Result
        Dim _new As New FindByWeight_Result

        With _new
            .Date_Photo = d.Date_Photo
            .Fossil_count = d.Fossil_count
            .SampleNumber = d.SampleNumber
            .Sample_height = d.Sample_height
            .Sample_length = d.Sample_length
            .Sample_main_species = d.Sample_main_species
            .Sample_net_weight = d.Sample_net_weight
            .Sample_nickname = d.Sample_nickname
            .Sample_width = d.Sample_width
            .Version = {0}
            .Woker_full_name = d.Woker_full_name
            .Fossil_list = clsApplicationTypes.RejectSkobki(d.Fossil_list)
        End With
        Return _new
    End Operator

    ' Dim oTitleImage As Drawing.Image

    Public Function GetAsFindByWeight_Result()
        Return CType(Me, FindByWeight_Result)
    End Function


    Private ReadOnly Property TitleImage As Drawing.Image
        Get
            Static _img As Drawing.Image
            If _img Is Nothing Then
                _img = clsApplicationTypes.SamplePhotoObject.GetMainImage(clsFilesSources.CreateInstance(clsFilesSources.emSources.Arhive), SampleNumberObj, True)
                _img = Service.clsIDcontent.GetResizedImage(_img, 150)
            End If
            'Me.oTitleImage = _img
            Return _img
        End Get

    End Property
    Public ReadOnly Property SampleNumberObj As clsApplicationTypes.clsSampleNumber
        Get
            Static _num As clsApplicationTypes.clsSampleNumber
            If _num Is Nothing Then
                _num = clsApplicationTypes.clsSampleNumber.CreateFromString(Me.SampleNumber)
                Debug.Assert(Not _num Is Nothing, "неверно используется свойство")
            End If
            Return _num
        End Get
    End Property

    ''' <summary>
    ''' изображение для отображения
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Image As Drawing.Image
        Get
            Return Me.TitleImage
        End Get
    End Property

End Class

Partial Class oldGoodMap_Result
    ''' <summary>
    ''' инициализатор пустых значений полей для Datagridview
    ''' </summary>
    ''' <returns></returns>
    Public Shared Function CreateInstance() As oldGoodMap_Result
        Dim _new = New oldGoodMap_Result
        With _new
            .Группы = ""
            .Наименование = "<название>"
            .IsNew = True
            .Артикул = ""
            .Буржуи_на_выставке = ""

            .Валюта__Закупочная_цена_ = ""
            .Валюта__Инвойс_ = ""
            .Валюта__Розничная_в_офисе_ = ""
            .Валюта__Розничная_цена_в_магазине_ = ""
            .Валюта__Буржуи_на_выставке_ = ""
            .Внешний_код = ""
            .Группы = ""
            .Единица_измерения = ""
            .Закупочная_цена = ""
            .Инвойс = ""
            .Код = ""
            .Розничная_в_офисе = ""
            .Розничная_цена_в_магазине = ""
            .Время_препарации_в_часах__общее_ = ""
            .Ответственный_Препаратор = ""
            .Полная_стоимость_закупки_в_рублях = ""
            .Полная_стоимость_препарации_в_рублях = ""
            .Препараторы_и_время = ""
            .Производственный_номер_или_EAN13 = ""
            .Экспедиционное_закупочное_примечание = ""
            .Экспедиционный_закупочный_номер = ""
            .Экспедиция__код_ = ""
            .Вес = ""
            .Перевозка = ""
            .Валюта__Перевозка_ = ""
            .EBAY = ""
            .Валюта__EBAY_ = ""
        End With
        Return _new
    End Function


    Friend Property oldАртикул As String
    Friend Property oldКод As String

    ''' <summary>
    ''' смена артикула
    ''' </summary>
    ''' <param name="value"></param>
    ''' <remarks></remarks>
    Private Sub OnАртикулChanging(value As Global.System.String)
        Me.oldАртикул = Me.Артикул
    End Sub
    Private Sub OnКодChanging(value As String)
        Me.oldКод = Me.Код
    End Sub

    ''' <summary>
    ''' указывает, является ли строка новой (для Insert)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property IsNew As Boolean
    ''' <summary>
    ''' указывает, был ли изменен код или артикул
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property CodeChanged As Boolean
        Get
            If String.IsNullOrEmpty(Me.Артикул) Then
                If String.IsNullOrEmpty(Me.oldКод) Then
                    'номер определен как Код
                    Return False
                ElseIf Me.oldКод.Equals(Me.Код) Then
                    'Код не менялся
                    Return False
                Else
                    'изменили Код
                    Return True
                End If
            End If
            If String.IsNullOrEmpty(Me.oldАртикул) Then
                'номер определен как Артикул
                Return False
            ElseIf Me.oldАртикул.Equals(Me.Артикул) Then
                'Артикул не менялся
                Return False
            Else
                'изменили Артикул
                Return True
            End If
        End Get
    End Property
    ''' <summary>
    ''' показывает, артикульный ли номер или нет
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property IsArticul As Boolean
        Get
            If String.IsNullOrEmpty(Me.Артикул) Then
                Return False
            End If
            Return True
        End Get
    End Property
    ''' <summary>
    ''' получает старый номер до изменения
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property oldActualCode As String
        Get
            If String.IsNullOrEmpty(Me.oldАртикул) Then
                Return Me.oldКод
            End If
            Return Me.oldАртикул
        End Get
    End Property
    ''' <summary>
    ''' текущий номер
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property ActualCode As String
        Get
            If String.IsNullOrEmpty(Me.Артикул) Then
                Return Me.Код
            End If
            Return Me.Артикул
        End Get
    End Property

    Public ReadOnly Property SampleNumberObj As clsApplicationTypes.clsSampleNumber
        Get
            Static _num As clsApplicationTypes.clsSampleNumber
            If _num Is Nothing Then
                Dim _code = Me.ActualCode
                If Not String.IsNullOrEmpty(_code) Then
                    _num = clsApplicationTypes.clsSampleNumber.CreateFromString(Me.ActualCode)
                    Debug.Assert(Not _num Is Nothing, "неверно используется свойство")
                End If
            End If
            Return _num
        End Get
    End Property

    Private ReadOnly Property TitleImage As Drawing.Image
        Get
            Static _img As Drawing.Image
            If _img Is Nothing AndAlso Not Me.SampleNumberObj Is Nothing Then
                _img = clsApplicationTypes.SamplePhotoObject.GetMainImage(clsFilesSources.CreateInstance(clsFilesSources.emSources.Arhive), Me.SampleNumberObj, True)
                _img = Service.clsIDcontent.GetResizedImage(_img, 150)
            End If
            'Me.oTitleImage = _img
            Return _img
        End Get

    End Property
    ''' <summary>
    ''' изображение для отображения
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Image As Drawing.Image
        Get
            Return Me.TitleImage
        End Get
    End Property
End Class