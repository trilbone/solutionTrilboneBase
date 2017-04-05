Imports Service.clsApplicationTypes
Imports Service
Imports System.Linq
Imports Trilbone
Imports Service.Catalog

Public Class clsOrderService

    Public Shared ReadOnly Property GetDigiKey As Object
        Get
            Return Service.clsApplicationTypes.GetDigiKeyBoardForm
        End Get
    End Property

    Private Shared oDataManager As Data
    ''' <summary>
    ''' точка входа проекта
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub main()

    End Sub


    Public Class Data
        'datasets
        Private WithEvents dsOrder As New dsOrders
        Private WithEvents dsService As New dsService
        Private WithEvents dsSampleOnSale As New SampleOnSale
        Private WithEvents dsClient As New dsClients

        'adapters for order
        Private WithEvents TableAdapterOrder As New dsOrdersTableAdapters.OrdersTableAdapter
        Private WithEvents TableAdapterOrderAndSample As New dsOrdersTableAdapters.SamplesAndOrdersTableAdapter
        'adapters for SampleOnSale
        Private WithEvents TableAdapterAllSampleOnSale As New SampleOnSaleTableAdapters.Select_OnSale_tb_SamplesOnSaleTableAdapter
        Private WithEvents TableAdapterSampleOnSale As New SampleOnSaleTableAdapters.Select_tb_SamplesOnSaleTableAdapter
        'adapters for Client
        Private WithEvents TableAdapterClient As New dsClientsTableAdapters.ClientsTableAdapter
        'adapters for Service
        Private WithEvents TableAdapterAllOrders As New dsServiceTableAdapters.Select_AllOrders_tb_OrdersTableAdapter
        Private WithEvents TableAdapterAllSampleInOrder As New dsServiceTableAdapters.Select_AllSamplesInOrders_tb_SamplesAndOrdersTableAdapter
        Private WithEvents TableAdapterClientNames As New dsServiceTableAdapters.Select_Clients_tb_ClientsTableAdapter
        Private WithEvents TableAdapterOrderForClient As New dsServiceTableAdapters.Select_OrdersForClientTableAdapter
        Private WithEvents TableAdapterSampleInfo As New dsServiceTableAdapters.Select_SampleInfoTableAdapter

        Public Overloads ReadOnly Property GetDsOrder(ByVal OrderID As String) As dsOrders
            Get
                Static _flag As Boolean
                If _flag = False Then
                    Me.TableAdapterOrder.Fill(dsOrder.Select_tb_Orders, OrderID)

                    _flag = True
                End If
                'MsgBox(My.Settings.DBOPHOTO_MDFConnectionString)

                Return Me.dsOrder
            End Get
        End Property
        Public Overloads ReadOnly Property GetDsOrder(ByVal OrderID As String, ByVal SampleNumber As Decimal) As dsOrders
            Get
                Static _flag As Boolean
                If _flag = False Then
                    Me.TableAdapterOrderAndSample.Fill(dsOrder.SamplesAndOrders, SampleNumber, OrderID)

                    _flag = True
                End If

                Return Me.dsOrder
            End Get
        End Property
        Public Overloads ReadOnly Property GetDsSampleOnSale(ByVal SampleNumber As Decimal) As SampleOnSale
            Get
                Static _flag As Boolean
                If _flag = False Then
                    Me.TableAdapterSampleOnSale.Fill(dsSampleOnSale.Select_tb_SamplesOnSale, SampleNumber)

                    _flag = True
                End If

                Return dsSampleOnSale
            End Get
        End Property
        Public Overloads ReadOnly Property GetDsSampleOnSale() As SampleOnSale
            Get
                Static _flag As Boolean
                If _flag = False Then
                    Me.TableAdapterAllSampleOnSale.Fill(dsSampleOnSale.Select_OnSale_tb_SamplesOnSale)

                    _flag = True
                End If


                Return dsSampleOnSale
            End Get
        End Property
        Public ReadOnly Property GetDsClient() As dsClients
            Get
                Static _flag As Boolean
                If _flag = False Then
                    Me.TableAdapterClient.Fill(dsClient.Clients)
                    _flag = True
                End If

                Return dsClient
            End Get
        End Property
        Public Overloads ReadOnly Property GetDsServiceClient() As dsService
            Get
                Static _flag As Boolean
                If _flag = False Then
                    initDsService()
                    Return dsService
                    _flag = True
                End If
                Return dsService
            End Get
        End Property
        Public Overloads ReadOnly Property GetDsServiceClient(ByVal ClientID As Decimal) As dsService
            Get
                Static _flag As Boolean
                If _flag = False Then
                    Me.TableAdapterOrderForClient.Fill(dsService.Select_OrdersForClient, ClientID)
                    _flag = True
                End If
                Return dsService
            End Get
        End Property
        Public Overloads ReadOnly Property GetDsService(ByVal OrderID As String) As dsService
            Get
                Static _flag As Boolean
                If _flag = False Then
                    Me.TableAdapterAllSampleInOrder.Fill(dsService.Select_AllSamplesInOrders_tb_SamplesAndOrders, OrderID)
                    _flag = True
                End If
                Return dsService
            End Get
        End Property

        Public Overloads ReadOnly Property GetDsService(ByVal SampleNumber As Decimal) As dsService
            Get
                Static _flag As Boolean

                If _flag = False Then
                    Me.TableAdapterSampleInfo.Fill(dsService.Select_SampleInfo, SampleNumber)
                    _flag = True
                End If
                Return dsService
            End Get
        End Property

        Private Sub initDsService()
            Me.TableAdapterAllOrders.Fill(dsService.Select_AllOrders_tb_Orders)
            Me.TableAdapterClientNames.Fill(dsService.Select_Clients_tb_Clients)
        End Sub


        Public Sub New()
        End Sub




    End Class
    '=====================================================
    '=====================================================
    '=====================================================
    Public Shared ReadOnly Property DataManager As clsOrderService.Data
        Get
            Return oDataManager
        End Get
    End Property

    Shared Sub New()
        '--------обновление подключения к БД------------

        ''задать строку подключения к БД
        'My.Settings.Item("dbReadySampleConnectionString") = Service.clsApplicationTypes.dbReadySampleConnectionString

        'My.Settings.Item("dboPhotoConnectionString") = Service.clsApplicationTypes.dboPhotoConnectionString

        'My.Settings.Item("DBOPHOTO_MDFConnectionString") = Service.clsApplicationTypes.dboPhotoConnectionString

        'My.Settings.Item("DBREADYSAMPLE_MDFConnectionString") = Service.clsApplicationTypes.dbReadySampleConnectionString

        'My.Settings.Save()
    End Sub

    Public Sub New()
        'регистрируем предоставляемые сервисы

        '1. сервис формы fmOrders
        'привязываем делегат к функции
        'передаем делегат (регестрируем) и список в сервисном классе
        Global.Service.clsApplicationTypes.DelegateStoreApplicationForm(emFormsList.fmOrders) = _
 New ApplicationFormDelegateFunction(AddressOf GetOrderFormAsForm)
        '2. сервис формы fmClient
        'привязываем делегат к функции
        'передаем делегат (регестрируем) и список в сервисном классе
        Global.Service.clsApplicationTypes.DelegateStoreApplicationForm(emFormsList.fmClients) = _
 New ApplicationFormDelegateFunction(AddressOf GetfmClientAsForm)

        '3. сервис заказов OrderList
        'привязываем делегат к функции
        'передаем делегат (регестрируем) и список в сервисном классе
        Global.Service.clsApplicationTypes.DelegateStoreOrdersList() = _
 New OrdersListDelegateFunction(AddressOf GetOrders)

        '3a. сервис заказов OrderNonClosedList
        'привязываем делегат к функции
        'передаем делегат (регестрируем) и список в сервисном классе
        Global.Service.clsApplicationTypes.DelegateStoreOrdersNonClosedList = _
 New OrdersNonClosedListDelegateFunction(AddressOf GetOrdersNonClosed)

        '4. Сервис OnSaleSampleList
        Global.Service.clsApplicationTypes.DelegateStoreOnSaleSampleList = _
 New OnSaleSampleListDelegateFunction(AddressOf GetOnSaleSamples)

        '5. сервис формы fmSampleOnSale
        'привязываем делегат к функции
        'передаем делегат (регестрируем) и список в сервисном классе
        Global.Service.clsApplicationTypes.DelegateStoreApplicationForm _
            (emFormsList.fmSampleOnSale) = _
            New ApplicationFormDelegateFunction(AddressOf GetfmSampleOnSaleAsForm)

        '6. сервис AddSampleInOrder
        ''привязываем делегат к функции
        ''передаем делегат (регистрируем) в сервисном классе
        Global.Service.clsApplicationTypes.DelegateStoreAddSampleToOrder = _
            New AddSampleInOrderDelegateFunction(AddressOf AddSampleInOrder)
        'запускаем работу с БД
        oDataManager = New clsOrderService.Data

        '7 сервис формы fmSampleInfo
        Global.Service.clsApplicationTypes.DelegateStoreApplicationForm _
            (emFormsList.fmSampleInfo) = _
            New ApplicationFormDelegateFunction(AddressOf GetfmSampleInfo)
        '8 сервис GetSampleInfoText строки с данными образца
        Global.Service.clsApplicationTypes.DelegateStoreGetSampleInfoText = _
            New GetSampleInfoTextDelegateFunction(AddressOf clsTreeService.GetSampleInfoText)

        '9 сервис добавления данных SampleOnSale
        'AddSampleOnSale
        Global.Service.clsApplicationTypes.DelegateStoreAddSampleOnSaleIntoDB = _
           New AddSampleOnSaleIntoDBDelegateFunction(AddressOf AddSampleOnSale)


        '10 сервис формы fmDbInfo1
        Global.Service.clsApplicationTypes.DelegateStoreApplicationForm _
            (emFormsList.fmDBInfo1) = _
            New ApplicationFormDelegateFunction(AddressOf GetfmDbInfo)

        '10 сервис формы fmCatalog
        Global.Service.clsApplicationTypes.DelegateStoreApplicationForm _
            (emFormsList.fmCatalogSample) = _
            New ApplicationFormDelegateFunction(AddressOf GetfmCatalogSample)

        '11 сервис создания каталога
        'Global.Service.clsApplicationTypes.DelegateStoreGetCatalog = _
        '    New GetCatalogDelegateFunction(AddressOf GetCatalog)
        '12 сервис получения имен шаблонов
        Global.Service.clsApplicationTypes.DelegateStoreGetTemplatesList = _
            New GetTemplatesListDelegateFunction(AddressOf GetTemplateNames)
        '12 сервис получения имен шаблонов
        Global.Service.clsApplicationTypes.DelegateStoreGetSampleInfoTransformed = _
            New GetSampleInfoTransformedDelegateFunction(AddressOf GetSampleInfoTransformed)

    End Sub


#Region "form provide"



    ''' <summary>
    '''  
    ''' </summary>
    ''' <param name="OrderID">если заказа с таким ID нет то он будет создан</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetfmOrder(ByVal OrderID As String) As fmOrders
        'Dim _param As Object = {OrderID}

        ''по запросу выполняем вызов из сервиса
        'Dim _fmtpy As MyFormsList = MyFormsList.fmOrders
        ''если делегата нет, то сервис недоступен
        'If Not Global.Service.clsApplicationTypes.ApplicationFormDelegateStore(_fmtpy) Is Nothing Then
        ''сервис зарегестрирован - вызываем
        'Return Global.Service.clsApplicationTypes.ApplicationFormDelegateStore(_fmtpy).Invoke(_fmtpy, _param)
        'Else
        'Return Nothing
        'End If

        Return New fmOrders(OrderID)
    End Function
    Public Overloads Shared Function GetfmSampleInfo(Optional ByVal SampleNumber As Service.clsApplicationTypes.clsSampleNumber = Nothing)


        If Not SampleNumber Is Nothing Then Return New fmSampleInfo(SampleNumber)
        Return New fmSampleInfo
    End Function
    Private Overloads Shared Function GetfmSampleInfo(ByVal SampleNumber As Object)
        Dim _number As clsSampleNumber = Nothing
        If SampleNumber.Length > 0 Then
            _number = TryCast(SampleNumber(0), clsSampleNumber)
        End If
        Return GetfmSampleInfo(_number)
    End Function

    ''' <summary>
    ''' delegat linked
    ''' </summary>
    ''' <param name="param"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function GetOrderFormAsForm(ByVal param As Object) As Form
        Dim _orderID As String = CType(param(0), String)
        Return GetfmOrder(_orderID)

    End Function


    Public Shared Function GetfmClient() As fmClients
        'Dim _param As Object = {}

        ''по запросу выполняем вызов из сервиса
        'Dim _fmtpy As MyFormsList = MyFormsList.fmClients
        ''если делегата нет, то сервис недоступен
        'If Not Global.Service.clsApplicationTypes.ApplicationFormDelegateStore(_fmtpy) Is Nothing Then
        ''сервис зарегестрирован - вызываем
        'Return Global.Service.clsApplicationTypes.ApplicationFormDelegateStore(_fmtpy).Invoke(_fmtpy, _param)
        'Else
        'Return Nothing
        'End If


        Return New fmClients
    End Function
    ''' <summary>
    ''' delegat linked
    ''' </summary>
    ''' <param name="param"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function GetfmClientAsForm(ByVal param As Object) As Form
        Return GetfmClient()
    End Function

    Public Shared Function GetfmSampleOnSale(ByVal SampleNumber As Decimal) As fmSampleOnSale
        'Dim _param As Object = {SampleNumber}

        ''по запросу выполняем вызов из сервиса
        'Dim _fmtpy As MyFormsList = MyFormsList.fmSampleOnSale
        ''если делегата нет, то сервис недоступен
        'If Not Global.Service.clsApplicationTypes.ApplicationFormDelegateStore(_fmtpy) Is Nothing Then
        ''сервис зарегестрирован - вызываем
        'Return Global.Service.clsApplicationTypes.ApplicationFormDelegateStore(_fmtpy).Invoke(_fmtpy, _param)
        'Else
        'Return Nothing
        'End If


        Return New fmSampleOnSale(SampleNumber, Global.Service.clsApplicationTypes.CurrencyList)
    End Function
    ''' <summary>
    ''' delegat linked
    ''' </summary>
    ''' <param name="param"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function GetfmSampleOnSaleAsForm(ByVal param As Object) As Form
        Dim _SampleNumber As Decimal = CType(param(0), Decimal)

        Return GetfmSampleOnSale(_SampleNumber)

    End Function
#End Region

#Region "Service use"
    ''' <summary>
    ''' запрашивает список образцов OnSale из PhotoReader
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetOnSaleSamplesList() As String()
        'по запросу выполняем вызов из сервиса
        'если делегата нет, то сервис недоступен
        If Not Global.Service.clsApplicationTypes.DelegateStoreOnSaleSampleList Is Nothing Then
            'сервис зарегестрирован - вызываем
            Return Global.Service.clsApplicationTypes.DelegateStoreOnSaleSampleList.Invoke()
        Else
            Return Nothing
        End If


    End Function


    '''' <summary>
    '''' Запрашивает список изображений из Photo_reader
    '''' </summary>
    '''' <param name="CurrentSample"></param>
    '''' <param name="ImageInListViewSize"></param>
    '''' <param name="LoadOnlyOnePhoto"></param>
    '''' <param name="Source"></param>
    '''' <returns></returns>
    '''' <remarks></remarks>
    'Public Shared Function GetImagesFromSource(ByVal CurrentSample As Decimal, _
    'ByVal ImageInListViewSize As Size, _
    'ByVal LoadOnlyOnePhoto As Boolean, ByVal Source As emSources) As SampleSourceImageList

    ' ''по запросу выполняем вызов из сервиса
    ' ''если делегата нет, то сервис недоступен
    ''If Not Global.Service.clsApplicationTypes.ImageServiceDelegatStore Is Nothing Then
    ' ''сервис зарегестрирован - вызываем
    ''Return Global.Service.clsApplicationTypes.ImageServiceDelegatStore.Invoke _
    ''(CurrentSample, ImageInListViewSize, LoadOnlyOnePhoto, Source)
    ''Else
    ''Return Nothing
    ''End If

    '' Return Service.clsApplicationTypes.SampleInfoObject.GetSampleSourceImageList(CurrentSample, ImageInListViewSize, LoadOnlyOnePhoto, Source)

    'End Function

#End Region


#Region "Service provide"



    ''' <summary>
    ''' сервис получения преобразованной строки описания образца по заданному шаблону с ссылками на заданное устройство. При задании TemplateName="" вернется чистый xml 
    ''' </summary>
    ''' <param name="SampleNumber"></param>
    ''' <param name="TemplateName"></param>
    ''' <param name="_status"></param>
    ''' <param name="ImagesSource"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function GetSampleInfoTransformed(SampleNumber As clsSampleNumber, TemplateName As String, ByRef _status As Integer, Optional ImagesSource As clsFilesSources = Nothing, Optional ImageNamesFilter As String() = Nothing, Optional culture As System.Globalization.CultureInfo = Nothing, Optional NeedMapping As Boolean = False) As String
        Dim _CatalogSample = CATALOG.CreateCatalogSample(SampleNumber, emCatalogFolderType.shot, False, ImagesSource, ImageNamesFilter, culture, , NeedMapping)
        If _CatalogSample Is Nothing Then Return ""
        'получить шаблон
        Dim _result As String
        _status = 1
        If TemplateName = "" Then
            _result = _CatalogSample.GetXML
        Else
            _result = _CatalogSample.GetTransform(emTemplateType.ByName, TemplateName)
        End If

        Return _result
    End Function


    ''' <summary>
    ''' сервис получения имен шаблонов
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function GetTemplateNames() As String()
        Dim _tmp = New clsTemplateManager
        Return _tmp.TemplateNamesList.ToArray
    End Function


    ''' <summary>
    ''' записывает в БД инфо об образце, принимая строгую структуру данных
    ''' </summary>
    ''' <param name="parameters">номер(decimal), начальная цена(decimal)</param>
    ''' <returns>-3: ошибка в переданной структуре, -2: образец уже есть в базе, -1: переданных данных недостаточно для записи в БД, 0: некорректный номер, 1 и более: успешно добавлено </returns>
    ''' <remarks></remarks>
    Public Shared Function AddSampleOnSale(parameters As Object) As Integer
        Dim _Sample_number As Decimal = 0
        Dim _basePrice As Decimal = 0

        Try
            Select Case CType(parameters, Array).Length

                Case 1
                    'received number only

                    _Sample_number = Decimal.Parse(parameters(0))


                Case 2
                    _Sample_number = Decimal.Parse(parameters(0))
                    _basePrice = Decimal.Parse(parameters(1))

                Case Else
                    Return -3

            End Select
        Catch ex As FormatException
            Return -3
        Catch ex As InvalidCastException
            Return -3
        Catch ex As IndexOutOfRangeException
            Return -3

        End Try



        'здесь все параметры верны
        'проверить наличие образца в бд
        Dim _ds As New SampleOnSale
        Dim _adapt As New SampleOnSaleTableAdapters.Select_tb_SamplesOnSaleTableAdapter
        '---------------------------------
        'создать или обновить запись образца
        Dim _count As Integer
        Try
            _count = _adapt.Fill(_ds.Select_tb_SamplesOnSale, _Sample_number)
        Catch ex As Exception
            MsgBox("Can't connect to DB. Connection string: " & _adapt.Connection.ConnectionString)
            Return -1
        End Try

        Dim _sample_row As SampleOnSale.Select_tb_SamplesOnSaleRow
        If _count > 0 Then
            'образец существует в БД
            _sample_row = _ds.Select_tb_SamplesOnSale(0)
        Else
            'create new sample row
            _sample_row = _ds.Select_tb_SamplesOnSale.AddSelect_tb_SamplesOnSaleRow(SampleNumber:=Decimal.Parse(_Sample_number), OnSaleFlag:=False, SoldFlag:=False, Costs:=0, FreeShippingPossibleFlag:=False, CurrencyName:="USD", RateOfExchange:=0, Version:={0}, BasePrice:=0, ConfirmOrderID:=0, Description:="", ReservedFlag:=False, SampleXMLDescription:="", SoldPrice:=0)
        End If

        'update  sample fields
        With _sample_row
            .BasePrice = _basePrice
        End With

        Return _adapt.Update(_ds.Select_tb_SamplesOnSale)


    End Function




    Public Shadows Function GetOrdersNonClosed() As Collections.Generic.List(Of clsOrder)
        Dim _orderCollection As New Collections.Generic.List(Of clsOrder)

        Dim _adapter As New dsServiceTableAdapters.Select_AllActiveOrders_tb_OrdersTableAdapter
        Dim _result As dsService.Select_AllActiveOrders_tb_OrdersDataTable = _adapter.GetData
        For Each _row As dsService.Select_AllActiveOrders_tb_OrdersRow In _result.Rows
            Dim _item As New clsOrder(Trim(_row.OrderID))
            '_item.OrderID = Trim(_row.OrderID)
            _item.ClientID = _row.ClientID
            _item.ClientFullName = _row.FullName
            _orderCollection.Add(_item)
        Next

        Return _orderCollection
    End Function




    Public Shared Function GetOrders() As Collections.Generic.List(Of clsOrder)
        '
        Dim _orderCollection As New Collections.Generic.List(Of clsOrder)

        Dim _adapter As New dsServiceTableAdapters.Select_AllOrders_tb_OrdersTableAdapter




        Dim _result As dsService.Select_AllOrders_tb_OrdersDataTable
        Try
            _result = _adapter.GetData
        Catch ex As Exception
            MsgBox("Can't connect to DB. Connection string: " & _adapter.Connection.ConnectionString)
            Return _orderCollection
        End Try

        For Each _row As dsService.Select_AllOrders_tb_OrdersRow In _result.Rows
            Dim _item As New clsOrder(Trim(_row.OrderID))
            '_item.OrderID = Trim(_row.OrderID)
            _item.ClientID = _row.ClientID
            _item.ClientFullName = _row.FullName
            _orderCollection.Add(_item)
        Next

        Return _orderCollection

    End Function
    ''' <summary>
    ''' return OnSale sample numbers
    ''' </summary>
    Public Shared Function GetOnSaleSamples() As String()
        'фильтруем образцы с флагом OnSale
        Dim _stringcoll As New Specialized.StringCollection


        Dim _adapter As New SampleOnSaleTableAdapters.Select_OnSale_tb_SamplesOnSaleTableAdapter
        Dim _result As SampleOnSale.Select_OnSale_tb_SamplesOnSaleDataTable = _adapter.GetData()
        Dim _collection As New Collections.ArrayList
        For Each _row As SampleOnSale.Select_OnSale_tb_SamplesOnSaleRow In _result.Rows

            _stringcoll.Add(_row.SampleNumber.ToString)

        Next
        Dim _tmp(_stringcoll.Count - 1) As String

        _stringcoll.CopyTo(_tmp, 0)
        Return _tmp


    End Function
    ''' <summary>
    ''' копирует фото в заказ. возвращает число скопированных фото.
    ''' </summary>
    ''' <param name="Order"></param>
    ''' <param name="SampleNumber"></param>
    ''' <returns>число скопированных фото</returns>
    ''' <remarks></remarks>
    Public Shared Function AddSampleImagesInOrder(ByVal Order As Service.clsApplicationTypes.clsOrder, ByVal SampleNumber As Service.clsApplicationTypes.clsSampleNumber, Optional ByVal ImageNames As String() = Nothing, Optional ByVal OptimizeImageWight As Integer = 0) As Integer

        'копируем изображения

        'из устройства
        Dim _fromSource = clsFilesSources.CreateInstance(clsFilesSources.emSources.Arhive)
        'в устройство

        Dim _ToSource = clsFilesSources.CreateInstance(clsFilesSources.emSources.SpecificOrder, Order)

        'копируем 
        Return clsApplicationTypes.SamplePhotoObject.CopyImagesFromSourceToSource(SampleNumber, _fromSource, _ToSource, False, ImageNames, OptimizeImageWight)

    End Function
    ''' <summary>
    ''' удаляет фото из заказа. Возвращает кол-во удаленных фото.
    ''' </summary>
    ''' <param name="Order"></param>
    ''' <param name="SampleNumber"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function DeleteSampleImagesFromOrder(ByVal Order As Service.clsApplicationTypes.clsOrder, ByVal SampleNumber As Service.clsApplicationTypes.clsSampleNumber) As Integer
        'удалить фото

        Dim _source = clsFilesSources.CreateInstance(Service.clsFilesSources.emSources.SpecificOrder, Order)

        Return Service.clsApplicationTypes.SamplePhotoObject.DeleteImagesFromSource(SampleNumber, _source, Nothing, True, True)


    End Function

    ''' <summary>
    ''' полная версия. добавляет образец в заказ. Модифицирует БД и копирует фото.
    ''' </summary>
    ''' <param name="OrderID"></param>
    ''' <param name="SampleNumber"></param>
    ''' <param name="FileNames"></param>
    ''' <param name="OptimizeImageWight"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function AddSampleInOrder(ByVal OrderID As String, ByVal SampleNumber As Decimal, Optional ByVal FileNames As String() = Nothing, Optional ByVal OptimizeImageWight As Integer = 0) As Boolean
        Dim _ds As New dsOrders
        Dim _SampleAndOrder_adapter As New dsOrdersTableAdapters.SamplesAndOrdersTableAdapter
        Dim _Order_adapter As New dsOrdersTableAdapters.OrdersTableAdapter

        _Order_adapter.Fill(_ds.Select_tb_Orders, OrderID)
        _SampleAndOrder_adapter.Fill(_ds.SamplesAndOrders, SampleNumber, OrderID)

        Dim _OrderRow As dsOrders.Select_tb_OrdersRow

        'проверка наличия заказа в БД
        Select Case _ds.Select_tb_Orders.Rows.Count
            Case 0
                'заказа с таким номером нет
                Return False
            Case 1
                'заказ есть
            Case Else
                'таких заказов более 1
                MsgBox("Заказу с ID " & OrderID & " соответствуют " & _ds.Select_tb_Orders.Rows.Count _
                        & " записей. Будет использована первая.", MsgBoxStyle.Critical)
        End Select
        'берем первую строку
        _OrderRow = _ds.Select_tb_Orders.Rows(0)

        'проверим образцы в заказе
        Select Case _ds.SamplesAndOrders.Rows.Count
            Case 0
                'образца в заказе нет
                'добавить
                Dim _currSample = clsApplicationTypes.clsSampleNumber.CreateFromString(SampleNumber.ToString)
                _ds.SamplesAndOrders.AddSamplesAndOrdersRow _
                    (SampleNumber, _OrderRow, 0, 0, False, 0, 0, False, "", 0, False, New DateTime)
                _SampleAndOrder_adapter.Update(_ds.SamplesAndOrders)
                MsgBox("Образец номер " & _currSample.ShotCode & " добавлен в заказ # " & OrderID) ' & ": "  & _SampleAndOrder_adapter.Update(_ds.SamplesAndOrders) & " записей.")


                Dim _CurrentOrder = New clsApplicationTypes.clsOrder(OrderID)


                _CurrentOrder.OrderID = OrderID

                'копируем изображения
                Dim _countCopies As Integer = AddSampleImagesInOrder(_CurrentOrder, _currSample, FileNames, OptimizeImageWight)

                Dim _mss As String = "Скопировано " + _countCopies.ToString + " фото в заказ # " + OrderID + ChrW(13)

                If Not OptimizeImageWight = 0 Then
                    _mss += "Размер фото был оптимизирован до ширины " + OptimizeImageWight.ToString
                End If

                MsgBox(_mss, MsgBoxStyle.Information)

            Case 1
                'образец есть
                Return False

            Case Else
                'таких образцов более 1
                MsgBox("В заказе с ID " & OrderID & " включены " & _ds.SamplesAndOrders.Rows.Count _
                       & " образцов " & SampleNumber, MsgBoxStyle.Critical)
                Return False

        End Select
        'обновить форму

        Return True


    End Function

#End Region

#Region "inner function"

#End Region

    Private Function GetfmDbInfo(ByVal param As Object) As Form


        Return New fmDbInfo1()


    End Function


    'Основные функции, выполняющие вывод информации из БД в текст
#Region "MainSampleInfoFunction"





    ''' <summary>
    ''' создает каталог из списка образцов Title выводится в заголовке
    ''' </summary>
    ''' <param name="Samples"></param>
    ''' <param name="CatalogName"></param>
    ''' <param name="TitleString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetCatalog(Samples As List(Of clsSampleNumber), CatalogName As String, TitleString As String, ImageSource As Service.clsFilesSources, culture As System.Globalization.CultureInfo, absolutePath As Boolean, foldertype As emCatalogFolderType) As CATALOG

        For Each t In Samples
            If t Is Nothing Then Debug.Fail("Передан Nothing код образца") : Return Nothing
        Next

        'параметры каталога

        'создать обьект каталога
        If culture Is Nothing Then culture = clsApplicationTypes.EnglishCulture
        Select Case culture.Name
            Case clsApplicationTypes.EnglishCulture.Name
                TitleString = "Offer to " & TitleString
            Case clsApplicationTypes.RussianCulture.Name
                TitleString = "Предложение для: " & TitleString
        End Select


        Dim _catalog As CATALOG = CATALOG.CreateInstance([date]:=Now, name:=CatalogName, title:=TitleString)
        '------------------------------------------------------------------------
        'добавить данные образцов
        For Each _sample In Samples
            Dim _cs As CATALOGSAMPLE = CATALOG.CreateCatalogSample(_sample, foldertype, False, ImageSource, , culture, , , absolutePath)
            If Not _cs Is Nothing Then
                _catalog.AddSample(_cs)
            End If
        Next
        '------------------------------------------------------------------------
        Return _catalog
    End Function
    ''' <summary>
    ''' форма управления XML
    ''' </summary>
    ''' <param name="param"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetfmCatalogSample(param As Object) As Windows.Forms.Form
        Return clsCatalogService.GetFmCatalogSample(param) '  clsTemplateManager.GetFmCatalogSample(param)
    End Function

#End Region






End Class
