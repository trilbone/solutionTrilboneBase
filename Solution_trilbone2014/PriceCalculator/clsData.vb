Imports System.ComponentModel
Imports Microsoft.Office.Interop.Excel

Public Class clsLotCalculatorData
    Implements INotifyPropertyChanged
    Implements IDisposable


    Private oPosCount As Integer
    ''' <summary>
    ''' Кол-во в лоте
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property PosCount As Integer
        Set(value As Integer)
            oPosCount = value
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("PosCount"))

        End Set
        Get
            Return oPosCount
        End Get
    End Property
    Private oLotPriceEUR As Decimal
    ''' <summary>
    ''' Стоим.лота
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property LotPriceEUR As Decimal
        Get
            Return oLotPriceEUR
        End Get
        Set(value As Decimal)
            oLotPriceEUR = value
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("LotPriceEUR"))

        End Set
    End Property

    Private okat1BASEcount As Decimal
    ''' <summary>
    ''' кол-во (1)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property kat1BASEcount As Decimal
        Get
            Return okat1BASEcount
        End Get
        Set(value As Decimal)
            okat1BASEcount = value

            'рассчитать кол-во 5 категории
            If Me.oNormalizeKat1 = False Then
                If Me.kat5BASEcount = 1 Then
                    'установили кол-во говна, ост распределим равномерно
                    Me.kat5BASEcount = Decimal.Ceiling((Me.PosCount - okat1BASEcount) / 4)
                End If
            End If
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("kat1BASEcount"))
        End Set
    End Property

    Private okat5BASEcount As Integer
    ''' <summary>
    ''' кол-во(5)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property kat5BASEcount As Integer
        Get
            Return okat5BASEcount
        End Get
        Set(value As Integer)
            okat5BASEcount = value
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("kat5BASEcount"))
        End Set
    End Property
    Private oNormalizeKat1 As Boolean
    ''' <summary>
    ''' нормализовать категорию
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property NormalizeKat1 As Boolean
        Get
            Return oNormalizeKat1
        End Get
        Set(value As Boolean)
            If oNormalizeKat1 = value Then Return
            Select Case value
                Case True
                    If okat5BASEcount > 0 Then
                        'нормализация работает только при ненулевом кол-ве 5 категории
                        oNormalizeKat1 = True
                        ' okat1BASEcount = Math.Round(okat1BASEcount / okat5BASEcount, 0, MidpointRounding.AwayFromZero)
                        okat1BASEcount = okat1BASEcount / okat5BASEcount
                        okat5BASEcount = 1
                        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("NormalizeKat1"))
                    End If
                Case False
                    'снять нормализацию
                    oNormalizeKat1 = False
                    Dim _x1_5 = Decimal.Ceiling(Me.PosCount / (okat1BASEcount + 4))
                    Dim _x1 = okat1BASEcount * _x1_5

                    ' Me.kat5BASEcount = _x1_5
                    Me.kat1BASEcount = _x1
                    Me.kat5BASEcount = _x1_5
            End Select
        End Set
    End Property

    ''' <summary>
    ''' стоимость лота в руб
    ''' </summary>
    Public Property LotSumRUR As Decimal
    ''' <summary>
    ''' средняя по позиции в руб
    ''' </summary>
    Public Property PosAVGRUR As Decimal
    ''' <summary>
    ''' средняя по позиции в евро
    ''' </summary>
    Public Property PosAVGEUR As Decimal
    '----------------
    Private okat1Price As Decimal
    ''' <summary>
    ''' мин. цена(1)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property kat1Price As Decimal
        Get
            Return okat1Price
        End Get
        Set(value As Decimal)
            okat1Price = value
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("kat1Price"))
        End Set
    End Property
    Public Property kat2Price As Decimal
    Public Property kat3Price As Decimal
    Public Property kat4Price As Decimal
    Private okat5Price As Decimal
    ''' <summary>
    ''' макс. цена(5)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property kat5Price As Decimal
        Get
            Return okat5Price
        End Get
        Set(value As Decimal)
            okat5Price = value
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("kat5Price"))
        End Set
    End Property
    ''' <summary>
    ''' вычисленное кол-во кат 1
    ''' </summary>
    Public Property kat1count As Decimal
    ''' <summary>
    ''' вычисленное кол-во кат 2
    ''' </summary>
    Public Property kat2count As Decimal
    ''' <summary>
    ''' вычисленное кол-во кат 3
    ''' </summary>
    Public Property kat3count As Decimal
    ''' <summary>
    ''' вычисленное кол-во кат 4
    ''' </summary>
    Public Property kat4count As Decimal
    ''' <summary>
    ''' вычисленное кол-во кат 5
    ''' </summary>
    Public Property kat5count As Decimal

    ''' <summary>
    ''' концы
    ''' </summary>
    Public Property Koncy As Decimal

    ''' <summary>
    ''' концы
    ''' </summary>
    Public Property Koncy1 As Decimal

    ''' <summary>
    ''' суммарное кол-во вычесленных кол-в
    ''' </summary>
    Public ReadOnly Property KatTotalCount As Decimal
        Get
            Return kat1count + kat2count + kat3count + kat4count + kat5count
        End Get
    End Property

    ''' <summary>
    ''' показывает, что книга загружена
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property IsLoadedExcel As Boolean
        Get
            If Me.oCurrentApp Is Nothing Then Return False
            Return True
        End Get
    End Property

    ''' <summary>
    ''' прибыль по опту
    ''' </summary>
    Public Property WholePlus As Decimal
    ''' <summary>
    ''' прибыль сверху опта
    ''' </summary>
    Public Property RetailPlus As Decimal
    ''' <summary>
    ''' курс евро
    ''' </summary>
    ''' options parameters
    Friend Property EURCource As Decimal
    ''' <summary>
    ''' коэфф, на кот умножается средняя цена закупки
    ''' </summary>
    Friend Property Kat1PriceKoeff As Decimal

    Private Property kat1incomingPrice As Decimal
    Private Property kat2incomingPrice As Decimal
    Private Property kat3incomingPrice As Decimal
    Private Property kat4incomingPrice As Decimal
    Private Property kat5incomingPrice As Decimal


    ''' <summary>
    ''' check and open book
    ''' </summary>
    ''' <param name="path"></param>
    ''' <remarks></remarks>
    Private Function LoadWorkbook() As Boolean
        Dim _path = My.Settings.fullPath
        If String.IsNullOrEmpty(_path) OrElse (Not IO.File.Exists(_path)) Then
            _path = IO.Path.Combine(My.Computer.FileSystem.SpecialDirectories.MyDocuments, My.Settings.filename)
            If Not IO.File.Exists(_path) Then
                MsgBox("Книга excel не найдена. Неправильное имя книги в настройках? Нет книги в директории Мои Документы? Скопируй из GoogleDrive(Контора) в мои документы и выбери этот файл ИЛИ просто выбери файл в настройках.", vbCritical)
                Return False
            End If


        End If
        Try
            If oCurrentApp Is Nothing Then
                oCurrentApp = New Microsoft.Office.Interop.Excel.Application
                oCurrentApp.DisplayAlerts = False
            End If
            If oCurrentBook Is Nothing Then
                oCurrentBook = oCurrentApp.Workbooks.Open(_path)
                oCurrentBook.CheckCompatibility = False
                oCurrentSheet = (From c As Worksheet In oCurrentBook.Worksheets Where c.Name = My.Settings.sheetname Select c).FirstOrDefault
                If oCurrentSheet Is Nothing Then
                    MsgBox("В указанной книге " & _path & " нет требуемого листа " & My.Settings.sheetname, vbCritical)
                    oCurrentBook.Close()
                    oCurrentBook = Nothing
                Else
                    oCurrentSheet.Activate()
                End If
            End If
            My.Settings.fullPath = _path
            My.Settings.Save()
        Catch ex As Exception
            MsgBox("Невозможно открыть книгу excel из за ошибки в книге.", vbCritical)
            oCurrentApp.Quit()
            oCurrentBook = Nothing
            oCurrentApp = Nothing
            oCurrentSheet = Nothing
            Return False
        End Try
        Return True
    End Function


    Private oCurrentSheet As Worksheet
    Private oCurrentBook As Workbook
    Private oCurrentApp As Microsoft.Office.Interop.Excel.Application



    Public Sub Calculate(tuneprice As Boolean)
        If oCurrentBook Is Nothing Then Return
        If oCurrentApp.ActiveWorkbook Is Nothing Then
            'похоже, пользователь закрыл ексель
            oCurrentApp.Quit()
            If Not LoadWorkbook() Then
                Return
            End If
            If oCurrentBook Is Nothing Then Return
        End If

        '--------------
        'Dim _rng, rng1, rng2 As Range
        'заполнить ячейки
        Try
            oCurrentSheet.Range("B3").Value = Me.PosCount
        Catch ex As Exception
            MsgBox("Невозможно использовать книгу excel. Запустите приложение заново. Обязательно завершите процесс Excel.exe в диспетчере задач Windows!", vbCritical)
            oCurrentApp.Quit()
            oCurrentBook = Nothing
            oCurrentApp = Nothing
            oCurrentSheet = Nothing
            My.Application.ApplicationContext.MainForm.Close()
            Return
        End Try

        oCurrentSheet.Range("C3").Value = Me.LotPriceEUR
        oCurrentSheet.Range("D3").Value = Me.EURCource
        oCurrentSheet.Range("G3").Value = Me.kat1BASEcount
        oCurrentSheet.Range("H3").Value = Me.kat5BASEcount

        oCurrentApp.Calculate()

        Me.PosAVGEUR = Math.Round(oCurrentSheet.Range("C6").Value, 2)
        Me.PosAVGRUR = Math.Round(oCurrentSheet.Range("C7").Value, 2)


        If tuneprice Then
            'вычислить цены мин макс
            TunePrices()
            '----------
        Else
            oCurrentSheet.Range("E3").Value = Math.Round(Me.kat1Price)
            oCurrentSheet.Range("F3").Value = Math.Round(Me.kat5Price)
            oCurrentApp.Calculate()
            ShowResult()
        End If

    End Sub

    Private Sub ShowResult()
        'отобразить вычисления
        Me.LotSumRUR = Math.Round(oCurrentSheet.Range("C4").Value)

        Me.kat1count = Math.Round(oCurrentSheet.Range("C10").Value, System.MidpointRounding.ToEven)
        Me.kat2count = Math.Round(oCurrentSheet.Range("C11").Value, System.MidpointRounding.ToEven)
        Me.kat3count = Math.Round(oCurrentSheet.Range("C12").Value, System.MidpointRounding.ToEven)
        Me.kat4count = Math.Round(oCurrentSheet.Range("C13").Value, System.MidpointRounding.ToEven)
        Me.kat5count = Math.Round(oCurrentSheet.Range("C14").Value, System.MidpointRounding.ToEven)
        Me.kat1incomingPrice = Math.Round(oCurrentSheet.Range("E10").Value, System.MidpointRounding.ToEven)
        Me.kat2incomingPrice = Math.Round(oCurrentSheet.Range("E11").Value, System.MidpointRounding.ToEven)
        Me.kat3incomingPrice = Math.Round(oCurrentSheet.Range("E12").Value, System.MidpointRounding.ToEven)
        Me.kat4incomingPrice = Math.Round(oCurrentSheet.Range("E13").Value, System.MidpointRounding.ToEven)
        Me.kat5incomingPrice = Math.Round(oCurrentSheet.Range("E14").Value, System.MidpointRounding.ToEven)




        Me.kat2Price = Decimal.Ceiling(oCurrentSheet.Range("B11").Value)
        Me.kat3Price = Decimal.Ceiling(oCurrentSheet.Range("B12").Value)
        Me.kat4Price = Decimal.Ceiling(oCurrentSheet.Range("B13").Value)

        Me.Koncy = Math.Round(oCurrentSheet.Range("D21").Value, 1)
        Me.Koncy1 = Math.Round(oCurrentSheet.Range("D22").Value, 1)

        Me.WholePlus = Math.Round(oCurrentSheet.Range("C21").Value)
        Me.RetailPlus = Math.Round(oCurrentSheet.Range("C22").Value)
    End Sub

    Public Sub showexcel()
        If Me.oCurrentApp.Visible = True Then
            Me.oCurrentApp.Visible = False
        Else
            Me.oCurrentApp.Visible = True
        End If
    End Sub

    Public Sub TunePrices()
        If oCurrentBook Is Nothing Then Return
        '------------вычислить мин цену
        If Me.kat1Price = 0 Then
            If Me.kat1BASEcount = 1 Then
                Me.kat1Price = Me.PosAVGRUR * 4
            Else
                Me.kat1Price = Me.PosAVGRUR * Me.Kat1PriceKoeff
            End If
        End If
        oCurrentSheet.Range("E3").Value = Math.Round(Me.kat1Price)
        oCurrentApp.Calculate()
        '---------вычислить макс цену
        Me.kat5Price = Math.Round(Me.kat1Price * Me.kat1BASEcount / Me.kat5BASEcount)
        Me.Calculate(False)
        Do While oCurrentSheet.Range("D22").Value < 1
            Me.kat5Price += 100
            oCurrentSheet.Range("F3").Value = Math.Round(Me.kat5Price)
            oCurrentApp.Calculate()
        Loop
        '--------подобрать коэфф количества 5 категории
        Do While oCurrentSheet.Range("A15").Value > 0.1 Or oCurrentSheet.Range("A15").Value < -0.1
            If oCurrentSheet.Range("A15").Value < 0 Then
                oCurrentSheet.Range("U17").Value += 0.05
            Else
                oCurrentSheet.Range("U17").Value -= 0.05
            End If
            oCurrentApp.Calculate()
        Loop
        oCurrentApp.Calculate()
        ShowResult()
    End Sub

    Public Sub New(eurcource As Decimal, kat1pkoeff As Decimal)
        Me.EURCource = eurcource
        Me.Kat1PriceKoeff = kat1pkoeff
        Me.kat5BASEcount = 1
        LoadWorkbook()
    End Sub

    Public Event PropertyChanged(sender As Object, e As System.ComponentModel.PropertyChangedEventArgs) Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged

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
        ' Не изменяйте этот код. Разместите код очистки выше в Dispose(ByVal disposing As Boolean).
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

    Sub Clear()

        Me.okat1BASEcount = 0
        Me.okat1Price = 0
        Me.kat1count = 0
        Me.kat2count = 0
        Me.kat2Price = 0
        Me.kat3count = 0
        Me.kat3Price = 0
        Me.kat4count = 0
        Me.kat4Price = 0
        Me.kat5count = 0
        Me.okat5BASEcount = 1
        Me.okat5Price = 0
        Me.Koncy = 0
        Me.Koncy1 = 0
        Me.oLotPriceEUR = 0
        Me.LotSumRUR = 0
        Me.oNormalizeKat1 = False
        Me.PosAVGEUR = 0
        Me.PosAVGRUR = 0
        Me.oPosCount = 0
        Me.RetailPlus = 0
        Me.WholePlus = 0
    End Sub



    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub clsData_PropertyChanged(sender As Object, e As PropertyChangedEventArgs) Handles Me.PropertyChanged
        Select Case e.PropertyName
            Case "kat1BASEcount"

        End Select
    End Sub

    Private Sub kat1incoming(p1 As Object)
        Throw New NotImplementedException
    End Sub

End Class
