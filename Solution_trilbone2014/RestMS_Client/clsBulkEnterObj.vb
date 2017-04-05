
Friend Class clsBulkEnterObj
    Private oActive As Boolean
    Private oAddQTY As Double
    Private oArticul As String
    Private oExistQTY As Double
    Private Shared oLotLossAfterCalculate As Boolean
    Private oRetaiPrice As Decimal
    Private oLossQTY As Double
    Private Shared oLotArticulBase As String
    Private Shared oLotCource As Decimal
    Private Shared oLotCurrency As MoySkladAPI.currency
    Private Shared oLotMaxRetailPrice5 As Decimal
    Private Shared oLotMinRetailPrice1 As Decimal
    Private Shared oLotNormalizeQty1 As Boolean
    Private Shared oLotQQYmax5 As Decimal
    Private Shared oLotQTYmin1 As Decimal
    Private Shared oLotRetailCurrency As RestMS_Client.MoySkladAPI.currency
    Private Shared oLotTotalAmount As Decimal
    Private Shared oLotUomForRetail As RestMS_Client.MoySkladAPI.uom
    Private Shared oLotTotalQTY As Decimal
    Private Shared oLotUomForLot As RestMS_Client.MoySkladAPI.uom


    ''' <summary>
    ''' принять участие в оприходовании
    ''' </summary>
    Public Property Active As Boolean
        Get
            Return oActive
        End Get
        Set(value As Boolean)
            oActive = value
        End Set
    End Property

    ''' <summary>
    ''' артикул
    ''' </summary>
    Public ReadOnly Property Articul As String
        Get
            Return oArticul
        End Get

    End Property

    ''' <summary>
    ''' имеющеяся количество товара на складе
    ''' </summary>
    Public Property ExistQTY As Double
        Get
            Return oExistQTY
        End Get
        Set(value As Double)
            oExistQTY = value
        End Set
    End Property

    ''' <summary>
    ''' добавляемое кол-во товара
    ''' </summary>
    Public Property AddQTY As Double
        Get
            Return oAddQTY
        End Get
        Set(value As Double)
            oAddQTY = value
        End Set
    End Property

    ''' <summary>
    ''' розничная цена
    ''' </summary>
    Public Property RetailPrice As Decimal
        Get
            Return oRetaiPrice
        End Get
        Set(value As Decimal)
            oRetaiPrice = value
        End Set
    End Property

    ''' <summary>
    ''' количество товара к списанию
    ''' </summary>
    Public Property LossQTY As Double
        Get
            Return oLossQTY
        End Get
        Set(value As Double)
            oLossQTY = value
        End Set
    End Property

    ''' <summary>
    ''' цена закупки лота
    ''' </summary>
    Public Shared Property LotTotalAmount As Decimal
        Get
            Return oLotTotalAmount
        End Get
        Set(value As Decimal)
            oLotTotalAmount = value
        End Set
    End Property

    ''' <summary>
    ''' валюта закупки лота
    ''' </summary>
    Public Shared Property LotCurrency As MoySkladAPI.currency
        Get
            Return oLotCurrency
        End Get
        Set(value As MoySkladAPI.currency)
            oLotCurrency = value
        End Set
    End Property

    ''' <summary>
    ''' курс к валюте розницы
    ''' </summary>
    Public Shared Property LotCource As Decimal
        Get
            Return oLotCource
        End Get
        Set(value As Decimal)
            oLotCource = value
        End Set
    End Property

    ''' <summary>
    ''' мин цена категории 1
    ''' </summary>
    Public Shared Property LotMinRetailPrice1 As Decimal
        Get
            Return oLotMinRetailPrice1
        End Get
        Set(value As Decimal)
            oLotMinRetailPrice1 = value
        End Set
    End Property

    ''' <summary>
    ''' валюта розницы
    ''' </summary>
    Public Shared Property LotRetailCurrency As MoySkladAPI.currency
        Get
            Return oLotRetailCurrency
        End Get
        Set(value As MoySkladAPI.currency)
            oLotRetailCurrency = value
        End Set
    End Property

    ''' <summary>
    ''' макс цена категории 5
    ''' </summary>
    Public Shared Property LotMaxRetailPrice5 As Decimal
        Get
            Return oLotMaxRetailPrice5
        End Get
        Set(value As Decimal)
            oLotMaxRetailPrice5 = value
        End Set
    End Property

    ''' <summary>
    ''' кол-во в категории 1
    ''' </summary>
    Public Shared Property LotQTYmin1 As Decimal
        Get
            Return oLotQTYmin1
        End Get
        Set(value As Decimal)
            oLotQTYmin1 = value
        End Set
    End Property

    ''' <summary>
    ''' кол-во в категории 5
    ''' </summary>
    Public Shared Property LotQQYmax5 As Decimal
        Get
            Return oLotQQYmax5
        End Get
        Set(value As Decimal)
            oLotQQYmax5 = value
        End Set
    End Property

    ''' <summary>
    ''' списать остаток с базового артикула после оприходования
    ''' </summary>
    Public Shared Property LotLossAfterCalculate As Boolean
        Get
            Return oLotLossAfterCalculate
        End Get
        Set(value As Boolean)
            oLotLossAfterCalculate = value
        End Set
    End Property




    ''' <summary>
    ''' ед измерения категорий
    ''' </summary>
    Public Shared Property LotUomForRetail As MoySkladAPI.uom
        Get
            Return oLotUomForRetail
        End Get
        Set(value As MoySkladAPI.uom)
            oLotUomForRetail = value
        End Set
    End Property

    ''' <summary>
    ''' базовый артикул (артикул лота)
    ''' </summary>
    Public Shared ReadOnly Property LotArticulBase As String
        Get
            Return oLotArticulBase
        End Get

    End Property

    ''' <summary>
    ''' кол-во в категории 1 нормализовано к 5 категории (5=1позиция)
    ''' </summary>
    Public Shared Property LotNormalizeQty1 As Boolean
        Get
            Return oLotNormalizeQty1
        End Get
        Set(value As Boolean)
            oLotNormalizeQty1 = value
        End Set
    End Property

    ''' <summary>
    ''' общее кол-во в лоте
    ''' </summary>
    Public Shared Property LotTotalQTY As Decimal
        Get
            Return oLotTotalQTY
        End Get
        Set(value As Decimal)
            oLotTotalQTY = value
        End Set
    End Property

    ''' <summary>
    ''' ед. изм лота
    ''' </summary>
    Public Shared Property LotUomForLot As RestMS_Client.MoySkladAPI.uom
        Get
            Return oLotUomForLot
        End Get
        Set(value As RestMS_Client.MoySkladAPI.uom)
            oLotUomForLot = value
        End Set
    End Property

    ''' <summary>
    ''' рассчитать прогноз по лоту
    ''' </summary>
    ''' <param name="excelfilepath">путь к файлу для рассчета прогноза</param>
    Public Shared Function GetLotInfo(excelfilepath As String) As Boolean
        Throw New NotImplementedException
    End Function

    ''' <summary>
    ''' запрос к МС для получения данных по артикулам
    ''' </summary>
    Public Function RequestDataFromMS(manager As clsMoyScladManager) As Boolean
        Throw New NotImplementedException
    End Function




    ''' <summary>
    ''' иниц обьект для  категории
    ''' </summary>
    ''' <param name="articulbase">базовый артикул</param>
    ''' <param name="subnumber">категория</param>
    Public Shared Function CreateCategory(articulbase As String, subnumber As Integer) As clsBulkEnterObj
        Throw New NotImplementedException
    End Function

    ''' <summary>
    ''' приходует лот
    ''' </summary>
    ''' <param name="lossRemains">списать остатки после приходования</param>
    ''' <param name="printLabelForAllLot">печатать этикетки для всех категорий</param>
    Public Shared Function EnteringLot(manager As clsMoyScladManager, lossRemains As Boolean, printLabelForAllLot As Boolean) As List(Of clsBulkEnterObj)
        Throw New NotImplementedException
    End Function

    ''' <summary>
    ''' добавит следующую категорию в список
    ''' </summary>
    ''' <param name="BulkList">список для добавления. если пуст, то будет создан новый по базовому артикулу от 1 до 5 категории</param>
    ''' <param name="BaseArticul">базовый артикул - указать, когда список пуст или nothing</param>
    Public Shared Function AddCategory(BulkList As List(Of clsBulkEnterObj), Optional BaseArticul As String = "") As List(Of clsBulkEnterObj)
        Throw New NotImplementedException
    End Function

    ''' <summary>
    ''' Печатает комплект этикеток для категории
    ''' </summary>
    Public Sub PrintLabels()

    End Sub

End Class
