Imports System.ComponentModel
Imports Microsoft.Office.Interop.Excel

Public Class clsPriceCalculatorData
    Implements INotifyPropertyChanged
    Implements IDisposable

#Region "Определения"
    Private oActiveSheet As Worksheet
    Private oCurrentBook As Workbook
    Private oCurrentApp As Microsoft.Office.Interop.Excel.Application
    Private oPrices As clsPrices


#End Region

#Region "PropertyChange"
    Dim opath As String

    Private Sub RaisePropertyChanged(propertyname As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyname))
    End Sub

    Public Event PropertyChanged(sender As Object, e As PropertyChangedEventArgs) Implements INotifyPropertyChanged.PropertyChanged
#End Region


#Region "IDisposable Support"
    Private disposedValue As Boolean ' Чтобы обнаружить избыточные вызовы

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: освободить управляемое состояние (управляемые объекты).
                If Not oCurrentBook Is Nothing Then
                    oCurrentBook.Save()
                    oCurrentBook.Close()
                End If
                If Not oCurrentApp Is Nothing Then
                    oCurrentApp.Quit()
                End If

                oCurrentBook = Nothing
                oCurrentApp = Nothing
            End If

            ' TODO: освободить неуправляемые ресурсы (неуправляемые объекты) и переопределить ниже Finalize().
            ' TODO: задать большие поля как null.
        End If
        Me.disposedValue = True
    End Sub

    ' TODO: переопределить Finalize(), только если Dispose(ByVal disposing As Boolean) выше имеет код для освобождения неуправляемых ресурсов.
    'Protected Overrides Sub Finalize()
    '    ' Не изменяйте этот код.  Поместите код очистки в расположенную выше команду Удалить(ByVal удаление как булево).
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' Этот код добавлен редактором Visual Basic для правильной реализации шаблона высвобождаемого класса.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Не изменяйте этот код.  Разместите код очистки выше в методе Dispose(disposing As Boolean).
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

#End Region


    ''' <summary>
    ''' вернет сумму затрат для продажи на eBay (все фии до получения бабоса в банкомате эстонии)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property GetFullEbayChannelFee
        Get
            Me.ActivateSheet(emSheetType.tariff)
            Dim _c As Decimal = oActiveSheet.Range("N39").Value
            Return Decimal.Round(_c, 2)
        End Get
    End Property

    ''' <summary>
    ''' вернет сумму затрат при получении денег на PayPal (все фии до получения бабоса в банкомате эстонии)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property GetPayPalChannelFee
        Get
            Me.ActivateSheet(emSheetType.tariff)
            Dim _c As Decimal = oActiveSheet.Range("N38").Value
            Return Decimal.Round(_c, 2)
        End Get
    End Property


    Public Sub Clear()
        oPrices = Nothing
    End Sub


    Private Enum emSheetType
        tariff
        price
        payout
    End Enum

    Public Sub showexcel()
        If Me.oCurrentApp.Visible = True Then
            Me.oCurrentApp.Visible = False
        Else
            Me.oCurrentApp.Visible = True
        End If
    End Sub

    Private Sub ActivateSheet(sheettype As emSheetType)

        Select Case sheettype
            Case emSheetType.tariff
                oActiveSheet = (From c As Worksheet In oCurrentBook.Worksheets Where c.Name = My.Settings.sheetnamePrice_tariff Select c).FirstOrDefault
                If oActiveSheet Is Nothing Then
                    MsgBox("В книге " & oCurrentBook.Name & " нет требуемого листа " & My.Settings.sheetnamePrice_tariff, vbCritical)
                    oCurrentBook.Close()
                    oCurrentBook = Nothing
                Else
                    oActiveSheet.Activate()
                End If

            Case emSheetType.price
                oActiveSheet = (From c As Worksheet In oCurrentBook.Worksheets Where c.Name = My.Settings.sheetnamePrice_Prices Select c).FirstOrDefault
                If oActiveSheet Is Nothing Then
                    MsgBox("В книге " & oCurrentBook.Name & " нет требуемого листа " & My.Settings.sheetnamePrice_Prices, vbCritical)
                    oCurrentBook.Close()
                    oCurrentBook = Nothing
                Else
                    oActiveSheet.Activate()
                End If

            Case emSheetType.payout
                oActiveSheet = (From c As Worksheet In oCurrentBook.Worksheets Where c.Name = My.Settings.sheetnamePrice_Pays Select c).FirstOrDefault
                If oActiveSheet Is Nothing Then
                    MsgBox("В книге " & oCurrentBook.Name & " нет требуемого листа " & My.Settings.sheetnamePrice_Pays, vbCritical)
                    oCurrentBook.Close()
                    oCurrentBook = Nothing
                Else
                    oActiveSheet.Activate()
                End If

            Case Else
                Debug.Fail("Задай действие для элемента перечисления")
        End Select

    End Sub


    ''' <summary>
    ''' check and open book Рассчет продажи 2015.xlsx
    ''' </summary>
    ''' <param name="path"></param>
    ''' <remarks></remarks>
    Private Function LoadWorkbook() As Boolean
        Dim _path As String = opath
        If String.IsNullOrEmpty(_path) OrElse (Not IO.File.Exists(_path)) Then
            _path = My.Settings.fullPathPrice
            If String.IsNullOrEmpty(_path) OrElse (Not IO.File.Exists(_path)) Then
                _path = IO.Path.Combine(My.Computer.FileSystem.SpecialDirectories.MyDocuments, My.Settings.filenamePrice)
                If Not IO.File.Exists(_path) Then
                    MsgBox("Книга excel не найдена. Неправильное имя книги в настройках? Нет книги в директории Мои Документы? Скопируй из GoogleDrive(Контора) в мои документы и выбери этот файл ИЛИ просто выбери файл в настройках. (Рассчет продажи 2015.xlsx)", vbCritical)
                    Return False
                End If
            End If
        End If



        If oCurrentApp Is Nothing Then
            oCurrentApp = New Microsoft.Office.Interop.Excel.Application
            oCurrentApp.DisplayAlerts = False
        End If
        If oCurrentBook Is Nothing Then
            'создать временный файл
            Dim _tmpp = My.Computer.FileSystem.GetTempFileName
            IO.Path.ChangeExtension(_tmpp, "xlsx")
            IO.File.Copy(_path, _tmpp, True)
            oCurrentBook = oCurrentApp.Workbooks.Open(_tmpp)
            oCurrentBook.CheckCompatibility = False
        End If
        My.Settings.fullPathPrice = _path
        My.Settings.Save()

#If Not DEBUG Then
        Try

            If oCurrentApp Is Nothing Then
                oCurrentApp = New Microsoft.Office.Interop.Excel.Application
                oCurrentApp.DisplayAlerts = False
            End If
            If oCurrentBook Is Nothing Then
                'создать временный файл
                Dim _tmpp = My.Computer.FileSystem.GetTempFileName
                IO.File.Copy(_path, _tmpp)
                oCurrentBook = oCurrentApp.Workbooks.Open(_tmpp)
                oCurrentBook.CheckCompatibility = False
            End If
            My.Settings.fullPathPrice = _path
            My.Settings.Save()
        Catch ex As Exception
            MsgBox("Невозможно открыть книгу excel из за ошибки в книге.", vbCritical)
            oCurrentApp.Quit()
            oCurrentBook = Nothing
            oCurrentApp = Nothing
            oActiveSheet = Nothing
            Return False
        End Try
#End If


        Return True
    End Function

    ''' <summary>
    ''' задать курсы валют. bookpath если пуст, то берется из settings
    ''' </summary>
    ''' <param name="eurRate"></param>
    ''' <param name="UsdEuroRate"></param>
    ''' <remarks></remarks>
    Sub New(eurRate As Decimal, UsdEuroRate As Decimal, bookpath As String)
        opath = bookpath
        LoadWorkbook()
        ActivateSheet(emSheetType.tariff)
        oActiveSheet.Range("rate").Value = eurRate
        oActiveSheet.Range("rate_EUR").Value = UsdEuroRate
    End Sub

  


    ''' <summary>
    '''Установить входные значения для образца. Weight в кг, RawCost и PrepCost в рублях,  100% прибыль по умолчанию
    ''' </summary>
    ''' <param name="Weight"></param>
    ''' <param name="RawCost"></param>
    ''' <param name="PrepCost"></param>
    ''' <param name="pribil"></param>
    ''' <remarks></remarks>
    Public Sub SetValues(Weight As Decimal, RawCost As Decimal, PrepCost As Decimal, Optional pribil As Decimal = 1)
        ActivateSheet(emSheetType.tariff)
        oActiveSheet.Range("weight").Value = Weight
        oActiveSheet.Range("hunt_amount").Value = RawCost
        oActiveSheet.Range("prep_amount").Value = PrepCost
        ActivateSheet(emSheetType.price)
        oActiveSheet.Range("pribil").Value = pribil
        Calculate()
    End Sub


    ''' <summary>
    ''' соответствие диапазонов листа и типов цен
    ''' </summary>
    ''' <param name="priceType"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetRangeByPriceType(priceType As emOutPriceType) As Microsoft.Office.Interop.Excel.Range

        Dim _range As String = ""
        Select Case priceType

            'базовые цены  Россия в офисе 
            Case emOutPriceType.mainRusInOffice
                _range = "In_russ"
            Case emOutPriceType.mainRusInOffice_w
                _range = "In_rus_w"

                'Россия на выставке(лавке)
            Case emOutPriceType.RusShop
                _range = "In_rusExe"
            Case emOutPriceType.RusShop_w
                _range = "In_rusExe_w"
                'Буржуи в офисе
            Case emOutPriceType.EUinOffice
                _range = "In_eu"
            Case emOutPriceType.EUinOffice_w
                _range = "In_eu_w"
                'Буржуи через почту оплата на банк
            Case emOutPriceType.EUbyPostBank
                _range = "In_post"
            Case emOutPriceType.EUbyPostBank_w
                _range = "In_post_w"
                'Буржуи через почту оплата PAYPAL
            Case emOutPriceType.EUbyPostPayPal
                _range = "In_postPayPal"
            Case emOutPriceType.EUbyPostPayPal_w
                _range = "In_postPayPal_w"
                'Буржуи на выставке
            Case emOutPriceType.EUShop
                _range = "In_EUExe"
            Case emOutPriceType.EUShop_w
                _range = "In_EUExe_w"
                'Ebay
            Case emOutPriceType.Ebay
                _range = "In_Ebay"

        End Select

        Return oActiveSheet.Range(_range)

    End Function

    Private Function GetValueDecimal(input As emOutPriceType, Optional digits As Integer = 0) As Decimal
        Return Decimal.Round(CType(GetRangeByPriceType(input).Value, Decimal), digits)
    End Function


    ''' <summary>
    ''' формирует выходной массив цен в свойстве prices
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Calculate()
        If oCurrentBook Is Nothing Then Return
        If oCurrentApp.ActiveWorkbook Is Nothing Then
            'похоже, пользователь закрыл ексель
            oCurrentApp.Quit()
            If Not LoadWorkbook() Then
                Return
            End If
            If oCurrentBook Is Nothing Then Return
        End If

        Me.ActivateSheet(emSheetType.price)

        Dim _pr As New clsPrices
        'базовые цены  Россия в офисе 
        Dim _prItem As New KeyValuePair(Of String, Decimal)("RUR", GetValueDecimal(emOutPriceType.mainRusInOffice))
        _pr.Add(emOutPriceType.mainRusInOffice, _prItem)
        _prItem = New KeyValuePair(Of String, Decimal)("RUR", GetValueDecimal(emOutPriceType.mainRusInOffice_w))
        _pr.Add(emOutPriceType.mainRusInOffice_w, _prItem)
        'Россия на выставке(лавке)
        _prItem = New KeyValuePair(Of String, Decimal)("RUR", GetValueDecimal(emOutPriceType.RusShop))
        _pr.Add(emOutPriceType.RusShop, _prItem)
        _prItem = New KeyValuePair(Of String, Decimal)("RUR", GetValueDecimal(emOutPriceType.RusShop_w))
        _pr.Add(emOutPriceType.RusShop_w, _prItem)
        'Буржуи в офисе
        _prItem = New KeyValuePair(Of String, Decimal)("EUR", GetValueDecimal(emOutPriceType.EUinOffice, 1))
        _pr.Add(emOutPriceType.EUinOffice, _prItem)
        _prItem = New KeyValuePair(Of String, Decimal)("EUR", GetValueDecimal(emOutPriceType.EUinOffice_w, 1))
        _pr.Add(emOutPriceType.EUinOffice_w, _prItem)
        'Буржуи через почту оплата на банк
        _prItem = New KeyValuePair(Of String, Decimal)("USD", GetValueDecimal(emOutPriceType.EUbyPostBank, 1))
        _pr.Add(emOutPriceType.EUbyPostBank, _prItem)
        _prItem = New KeyValuePair(Of String, Decimal)("USD", GetValueDecimal(emOutPriceType.EUbyPostBank_w, 1))
        _pr.Add(emOutPriceType.EUbyPostBank_w, _prItem)
        'Буржуи через почту оплата PAYPAL
        _prItem = New KeyValuePair(Of String, Decimal)("USD", GetValueDecimal(emOutPriceType.EUbyPostPayPal, 1))
        _pr.Add(emOutPriceType.EUbyPostPayPal, _prItem)
        _prItem = New KeyValuePair(Of String, Decimal)("USD", GetValueDecimal(emOutPriceType.EUbyPostPayPal_w, 1))
        _pr.Add(emOutPriceType.EUbyPostPayPal_w, _prItem)
        'Буржуи на выставке
        _prItem = New KeyValuePair(Of String, Decimal)("EUR", GetValueDecimal(emOutPriceType.EUShop, 1))
        _pr.Add(emOutPriceType.EUShop, _prItem)
        _prItem = New KeyValuePair(Of String, Decimal)("EUR", GetValueDecimal(emOutPriceType.EUShop_w, 1))
        _pr.Add(emOutPriceType.EUShop_w, _prItem)
        'Ebay
        _prItem = New KeyValuePair(Of String, Decimal)("USD", GetValueDecimal(emOutPriceType.Ebay))
        _pr.Add(emOutPriceType.Ebay, _prItem)
        Me.Prices = _pr
    End Sub

    ''' <summary>
    ''' выкуп от Российской оптовой цены/rawDoly = доля дольщика в сыром материале, проценты (0,2)
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetOwnersPrices(scheme As emScheme, rawDoly As Decimal) As clsPayOut
        Me.ActivateSheet(emSheetType.tariff)
        oActiveSheet.Range("doly_raw").Value = rawDoly
        Calculate()

        If Me.Prices Is Nothing OrElse Me.Prices.Count = 0 Then Return New clsPayOut
        Me.ActivateSheet(emSheetType.price)

        Dim _po As New clsPayOut
        Dim _pokey As strType
        Dim _poitem As KeyValuePair(Of String, Decimal)
        Select Case scheme
            Case emScheme.allflat

                _pokey = New strType(role:=emRole.Hunter, priceType:=emPriceType.Owner, sceme:=scheme)
                _poitem = New KeyValuePair(Of String, Decimal)("RUR", Decimal.Round(oActiveSheet.Range("ow1_1").Value, 0))
                _po.Add(_pokey, _poitem)

                _pokey = New strType(role:=emRole.Preparator, priceType:=emPriceType.Owner, sceme:=scheme)
                _poitem = New KeyValuePair(Of String, Decimal)("RUR", Decimal.Round(oActiveSheet.Range("ow1_2").Value, 0))
                _po.Add(_pokey, _poitem)

                _pokey = New strType(role:=emRole.Saler, priceType:=emPriceType.Owner, sceme:=scheme)
                _poitem = New KeyValuePair(Of String, Decimal)("RUR", Decimal.Round(oActiveSheet.Range("ow1_3").Value, 0))
                _po.Add(_pokey, _poitem)


            Case emScheme.resale

                '_pokey = New strType(role:=emRole.Hunter, priceType:=emPriceType.Retail, sceme:=scheme)
                '_poitem = New KeyValuePair(Of String, Decimal)("RUR", oActiveSheet.Range("ch2_1_out").Value)
                '_po.Add(_pokey, _poitem)

                '_pokey = New strType(role:=emRole.Preparator, priceType:=emPriceType.Retail, sceme:=scheme)
                '_poitem = New KeyValuePair(Of String, Decimal)("RUR", oActiveSheet.Range("ch1_2_out").Value)
                '_po.Add(_pokey, _poitem)

                _pokey = New strType(role:=emRole.Saler, priceType:=emPriceType.Owner, sceme:=scheme)
                _poitem = New KeyValuePair(Of String, Decimal)("RUR", Decimal.Round(oActiveSheet.Range("ow2_3").Value, 0))
                _po.Add(_pokey, _poitem)


            Case emScheme.orderprep
                _pokey = New strType(role:=emRole.Hunter, priceType:=emPriceType.Owner, sceme:=scheme)
                _poitem = New KeyValuePair(Of String, Decimal)("RUR", Decimal.Round(oActiveSheet.Range("ow3_1").Value, 0))
                _po.Add(_pokey, _poitem)

                '_pokey = New strType(role:=emRole.Preparator, priceType:=emPriceType.Retail, sceme:=scheme)
                '_poitem = New KeyValuePair(Of String, Decimal)("RUR", oActiveSheet.Range("ch3_2_out").Value)
                '_po.Add(_pokey, _poitem)

                _pokey = New strType(role:=emRole.Saler, priceType:=emPriceType.Owner, sceme:=scheme)
                _poitem = New KeyValuePair(Of String, Decimal)("RUR", Decimal.Round(oActiveSheet.Range("ow3_3").Value, 0))
                _po.Add(_pokey, _poitem)
        End Select
        Return _po
    End Function


    ''' <summary>
    ''' рассчитанные суммы выплат для запрошенной схемы. Даются суммы ретайл и опта, выбираем сами нужную
    ''' </summary>
    ''' <param name="scheme">схема рассчетов(из МС???)</param>
    ''' <param name="memBasePrice"> Запомненная Россия в офисе (из МС) </param>
    ''' <param name="memResPrice">Запомненная цена продажи на ресурсе (из МС)</param>
    ''' <param name="RealPrice">Цена продажи итоговая</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetPayOut(scheme As emScheme, memBasePrice As Decimal, memResPrice As Decimal, RealPrice As Decimal) As clsPayOut
        If memBasePrice = 0 Or memResPrice = 0 Or RealPrice = 0 Then Return New clsPayOut

        Me.ActivateSheet(emSheetType.payout)
        'оптовая Россия
        Dim memWPrice As Decimal = memBasePrice * (1 - oActiveSheet.Range("opt_dic").Value)

        Me.ActivateSheet(emSheetType.payout)
        oActiveSheet.Range("base_price_mem").Value = memBasePrice
        oActiveSheet.Range("w_price_mem").Value = memWPrice
        oActiveSheet.Range("res_price_mem").Value = memResPrice
        oActiveSheet.Range("res_price_out").Value = RealPrice

        Dim _po As New clsPayOut
        Dim _pokey As strType
        Dim _poitem As KeyValuePair(Of String, Decimal)

        Select Case scheme
            Case emScheme.allflat
                '========retail
                _pokey = New strType(role:=emRole.Hunter, priceType:=emPriceType.Retail, sceme:=scheme)
                _poitem = New KeyValuePair(Of String, Decimal)("RUR", oActiveSheet.Range("ch1_1_out").Value)
                _po.Add(_pokey, _poitem)

                _pokey = New strType(role:=emRole.Preparator, priceType:=emPriceType.Retail, sceme:=scheme)
                _poitem = New KeyValuePair(Of String, Decimal)("RUR", oActiveSheet.Range("ch1_2_out").Value)
                _po.Add(_pokey, _poitem)

                _pokey = New strType(role:=emRole.Saler, priceType:=emPriceType.Retail, sceme:=scheme)
                _poitem = New KeyValuePair(Of String, Decimal)("RUR", oActiveSheet.Range("ch1_3_out").Value)
                _po.Add(_pokey, _poitem)
                '==============whole
                _pokey = New strType(role:=emRole.Hunter, priceType:=emPriceType.Whole, sceme:=scheme)
                _poitem = New KeyValuePair(Of String, Decimal)("RUR", oActiveSheet.Range("ch1_1_out_w").Value)
                _po.Add(_pokey, _poitem)

                _pokey = New strType(role:=emRole.Preparator, priceType:=emPriceType.Whole, sceme:=scheme)
                _poitem = New KeyValuePair(Of String, Decimal)("RUR", oActiveSheet.Range("ch1_2_out_w").Value)
                _po.Add(_pokey, _poitem)

                _pokey = New strType(role:=emRole.Saler, priceType:=emPriceType.Whole, sceme:=scheme)
                _poitem = New KeyValuePair(Of String, Decimal)("RUR", oActiveSheet.Range("ch1_3_out_w").Value)
                _po.Add(_pokey, _poitem)

            Case emScheme.resale

                '========retail
                _pokey = New strType(role:=emRole.Hunter, priceType:=emPriceType.Retail, sceme:=scheme)
                _poitem = New KeyValuePair(Of String, Decimal)("RUR", oActiveSheet.Range("ch2_1_out").Value)
                _po.Add(_pokey, _poitem)

                '_pokey = New strType(role:=emRole.Preparator, priceType:=emPriceType.Retail, sceme:=scheme)
                '_poitem = New KeyValuePair(Of String, Decimal)("RUR", oActiveSheet.Range("ch1_2_out").Value)
                '_po.Add(_pokey, _poitem)

                _pokey = New strType(role:=emRole.Saler, priceType:=emPriceType.Retail, sceme:=scheme)
                _poitem = New KeyValuePair(Of String, Decimal)("RUR", oActiveSheet.Range("ch2_3_out").Value)
                _po.Add(_pokey, _poitem)
                '==============whole
                _pokey = New strType(role:=emRole.Hunter, priceType:=emPriceType.Whole, sceme:=scheme)
                _poitem = New KeyValuePair(Of String, Decimal)("RUR", oActiveSheet.Range("ch2_1_out_w").Value)
                _po.Add(_pokey, _poitem)

                '_pokey = New strType(role:=emRole.Preparator, priceType:=emPriceType.Whole, sceme:=scheme)
                '_poitem = New KeyValuePair(Of String, Decimal)("RUR", oActiveSheet.Range("ch1_2_out_w").Value)
                '_po.Add(_pokey, _poitem)

                _pokey = New strType(role:=emRole.Saler, priceType:=emPriceType.Whole, sceme:=scheme)
                _poitem = New KeyValuePair(Of String, Decimal)("RUR", oActiveSheet.Range("ch2_3_out_w").Value)
                _po.Add(_pokey, _poitem)

            Case emScheme.orderprep
                '========retail
                _pokey = New strType(role:=emRole.Hunter, priceType:=emPriceType.Retail, sceme:=scheme)
                _poitem = New KeyValuePair(Of String, Decimal)("RUR", oActiveSheet.Range("ch3_1_out").Value)
                _po.Add(_pokey, _poitem)

                _pokey = New strType(role:=emRole.Preparator, priceType:=emPriceType.Retail, sceme:=scheme)
                _poitem = New KeyValuePair(Of String, Decimal)("RUR", oActiveSheet.Range("ch3_2_out").Value)
                _po.Add(_pokey, _poitem)

                _pokey = New strType(role:=emRole.Saler, priceType:=emPriceType.Retail, sceme:=scheme)
                _poitem = New KeyValuePair(Of String, Decimal)("RUR", oActiveSheet.Range("ch3_3_out").Value)
                _po.Add(_pokey, _poitem)
                '==============whole
                _pokey = New strType(role:=emRole.Hunter, priceType:=emPriceType.Whole, sceme:=scheme)
                _poitem = New KeyValuePair(Of String, Decimal)("RUR", oActiveSheet.Range("ch3_1_out_w").Value)
                _po.Add(_pokey, _poitem)

                _pokey = New strType(role:=emRole.Preparator, priceType:=emPriceType.Whole, sceme:=scheme)
                _poitem = New KeyValuePair(Of String, Decimal)("RUR", oActiveSheet.Range("ch3_2_out_w").Value)
                _po.Add(_pokey, _poitem)

                _pokey = New strType(role:=emRole.Saler, priceType:=emPriceType.Whole, sceme:=scheme)
                _poitem = New KeyValuePair(Of String, Decimal)("RUR", oActiveSheet.Range("ch3_3_out_w").Value)
                _po.Add(_pokey, _poitem)
        End Select

        Return _po

    End Function


    ''' <summary>
    '''вернет процент прибыли. подбор процента прибыли для получения определенной цены tunePrice/ accuracy=точность в деньгах/ вернет процент прибыли / setZeroIfMinus - если прибыль вылетела в минус при попытке установки цены, то принять ее 0 (но цена будет больше запрошенной)
    ''' </summary>
    ''' <param name="tunePrice"></param>
    ''' <param name="priceType"></param>
    ''' <remarks></remarks>
    Public Function TunePrices(tunePrice As Decimal, priceType As emOutPriceType, Optional accuracy As Decimal = 0.1, Optional setZeroIfMinus As Boolean = True) As Decimal

        'шаг настройки 5%
        Dim _tunestep As Decimal = 0.01

        'цена, которую побираем
        Dim _range = Me.GetRangeByPriceType(priceType)

        'настраиваемая прибыль в %
        Me.ActivateSheet(emSheetType.price)
        Dim _tuneRange = oActiveSheet.Range("pribil")
        Dim _op As Integer = 0
        If (_range.Value - tunePrice) > 0 Then
            'цену надо уменьшить
            _op = -1
        Else
            'цену надо увеличить
            _op = 1
        End If


        'подбираем значение _range к значению tunePrice с точностью accuracy
        Do While _op * (_range.Value - tunePrice) < (accuracy)
            _tuneRange.Value = _tuneRange.Value + _op * _tunestep
        Loop

        ''если прибыль получается отрицательной, то установить нулевую прибыль
        If _tuneRange.Value < 0 Then
            If setZeroIfMinus Then
                _tuneRange.Value = 0
            End If
        End If



        Calculate()

        Return Math.Round(oActiveSheet.Range("pribil").Value, 2)
    End Function



    ''' <summary>
    ''' схемы рассчетов
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum emScheme
        ''' <summary>
        ''' схема равные доли
        ''' </summary>
        ''' <remarks></remarks>
        allflat = 1

        ''' <summary>
        ''' схема продажа готового
        ''' </summary>
        ''' <remarks></remarks>
        resale = 2

        ''' <summary>
        ''' схема Препарация на заказ
        ''' </summary>
        ''' <remarks></remarks>
        orderprep = 3

    End Enum

    ''' <summary>
    ''' роли дольщиков
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum emRole
        Hunter = 1
        Preparator = 2
        Saler = 3
    End Enum

    ''' <summary>
    ''' тип цены
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum emPriceType
        Retail = 1
        Whole = 2
        ''' <summary>
        ''' цена выкупа
        ''' </summary>
        ''' <remarks></remarks>
        Owner = 3
    End Enum

    ''' <summary>
    ''' определяет тип платежа
    ''' </summary>
    ''' <remarks></remarks>
    Public Structure strType
        Property Role As emRole
        Property PriceType As emPriceType
        Property Sceme As emScheme

        Sub New(role As emRole, priceType As emPriceType, sceme As emScheme)
            Me.Role = role
            Me.PriceType = priceType
            Me.Sceme = sceme
        End Sub

    End Structure


    ''' <summary>
    ''' выплачиваемые суммы КомуПоСхемеКакуюЦену== валюта,значение
    ''' </summary>
    ''' <remarks></remarks>
    Public Class clsPayOut
        Inherits Dictionary(Of strType, KeyValuePair(Of String, Decimal))
        Shadows Sub Add(key As strType, value As KeyValuePair(Of String, Decimal))
            Dim _rv As New KeyValuePair(Of String, Decimal)(value.Key, Decimal.Round(value.Value, 0))
            MyBase.Add(key, _rv)
        End Sub

    End Class

    ''' <summary>
    ''' цены
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum emOutPriceType
        ''' <summary>
        '''  Россия в офисе  = основная для рассчетов
        ''' </summary>
        ''' <remarks></remarks>
        mainRusInOffice
        mainRusInOffice_w
        ''' <summary>
        ''' Россия на выставке(лавке)
        ''' </summary>
        ''' <remarks></remarks>
        RusShop
        RusShop_w
        ''' <summary>
        ''' Буржуи в офисе
        ''' </summary>
        ''' <remarks></remarks>
        EUinOffice
        EUinOffice_w
        ''' <summary>
        ''' Буржуи через почту оплата на банк
        ''' </summary>
        ''' <remarks></remarks>
        EUbyPostBank
        EUbyPostBank_w
        ''' <summary>
        '''  Буржуи через почту оплата PAYPAL
        ''' </summary>
        ''' <remarks></remarks>
        EUbyPostPayPal
        EUbyPostPayPal_w
        ''' <summary>
        ''' Буржуи на выставке
        ''' </summary>
        ''' <remarks></remarks>
        EUShop
        EUShop_w
        ''' <summary>
        ''' Ebay
        ''' </summary>
        ''' <remarks></remarks>
        Ebay

    End Enum

    ''' <summary>
    ''' тип цены == key=валюта, value=значение
    ''' </summary>
    ''' <remarks></remarks>
    Public Class clsPrices
        Inherits Dictionary(Of emOutPriceType, KeyValuePair(Of String, Decimal))

    End Class

#Region "свойства с листа Цены"
    ''' <summary>
    ''' Цены
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Prices As clsPrices
        Get
            Return oPrices
        End Get
        Set(value As clsPrices)
            oPrices = value
            RaisePropertyChanged("Prices")
        End Set
    End Property

#End Region



End Class
