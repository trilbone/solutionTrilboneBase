Imports RFID
Imports System.Linq
Imports System.Windows.Forms

Public Class clsRfidManager
    Implements IDisposable
    Implements System.ComponentModel.INotifyPropertyChanged

    'интервал таймера (в мс)
    Private Const cntTimerInterval As Integer = 1500
    'задержка после успешного чтения в интервалах таймера
    Private Const cntReadyDelayStep As Integer = 2

    Private oReader As RFID.iRFIDDataProvider
    Private WithEvents oCardInfo As clsCardInfo
    Private oTimer As Timers.Timer
    Private oIsConnected As Boolean
    Private oReaderStatusString As String

    ''' <summary>
    ''' сервисный класс
    ''' </summary>
    ''' <remarks></remarks>
    Public Class clsCardInfo
        Implements System.ComponentModel.INotifyPropertyChanged

        Dim oInfo As List(Of iRFIDDataProvider.clsCardInfo)
        Dim oMessage As String



        ''' <summary>
        ''' кол-во тегов
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property CardCount As Integer
            Get
                If CardCollection Is Nothing Then Return 0
                Return CardCollection.Count
            End Get
        End Property

        ''' <summary>
        ''' коллекция тегов
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property TagStringCollection As List(Of String)
            Get
                If CardCollection Is Nothing Then Return New List(Of String)
                Return CardCollection.Select(Function(x) x.Sector0Block1STR.Trim).ToList
            End Get
        End Property

        ''' <summary>
        ''' коллекция меток
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CardCollection As List(Of iRFIDDataProvider.clsCardInfo)
            Get
                Return oInfo
            End Get
            Set(value As List(Of iRFIDDataProvider.clsCardInfo))
                oInfo = value
                RaisePropertyChanged("CardCollection")
            End Set
        End Property

        ''' <summary>
        ''' сообщение для пользователя
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Message As String
            Get
                Return oMessage
            End Get
            Set(value As String)
                oMessage = value
                RaisePropertyChanged("Message")
            End Set
        End Property
        Sub New()
            CardCollection = Nothing
            Message = "нет меток"
        End Sub

        Protected Sub RaisePropertyChanged(ByVal propertyName As String)
            Dim propertyChanged As System.ComponentModel.PropertyChangedEventHandler = Me.PropertyChangedEvent
            If (Not (propertyChanged) Is Nothing) Then
                propertyChanged(Me, New System.ComponentModel.PropertyChangedEventArgs(propertyName))
            End If
        End Sub

        Public Event PropertyChanged(sender As Object, e As System.ComponentModel.PropertyChangedEventArgs) Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged
    End Class
    Dim oScannerStatus As Boolean


    ''' <summary>
    ''' подключаем реадер
    ''' </summary>
    ''' <param name="_status"></param>
    ''' <param name="_message"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function Reader_connect(Optional ByRef _status As String = "", Optional ByRef _message As String = "") As Boolean
        oIsConnected = False
        oReader = Nothing
        oReaderStatusString = "нет подключения"
        RaisePropertyChanged("ReaderStatusString")
        Try
            oReader = cls_SDTAPI.CreateInstance()
            If oReader Is Nothing Then
                _message = "Невозможно подключится к ридеру"
                _status = "Ошибка dll"
                oIsConnected = False
            ElseIf oReader.ReaderOpenStatus = False Then
                _message = "Невозможно подключится к ридеру"
                _status = "Ошибка подключения"
                oIsConnected = False
            Else
                _message = "Подключено"
                _status = "Подключено"
                oIsConnected = True
                oReader.LEDAllOff()
            End If
        Catch ex As Exception
            _message = "Невозможно подключится к ридеру"
            _status = "Ошибка dll"
            oIsConnected = False
        End Try

        Return oIsConnected
    End Function

    ''' <summary>
    ''' проверяет подключение
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function Test_connection() As Boolean
        If oReader Is Nothing OrElse oReader.ReaderOpenStatus = False Then
            Dim _message As String = ""
            Dim _result = Reader_connect(oReaderStatusString, _message)
            Return _result
        End If
        Return True
    End Function

    Private Sub ReadCards()
        Try
            Dim _status As Boolean
            Dim _count As Integer
            Dim _res = oReader.ReadData(_status, _count)
            If _status Then
                oCardInfo.Message = "Прочитано " & _count & " метка(ок)"
                oCardInfo.CardCollection = _res
                oReader.LEDGreenON(0.1, _res.Count)
                If Not oScannerStatus Then
                    RaiseEvent TagStringCollectionChanged(Me, New TagsStringCollectionChangedEventArgs With {.TagCollection = oCardInfo.TagStringCollection.ToArray})
                End If
            Else
                oCardInfo.Message = "Нет карты"
                oCardInfo.CardCollection = Nothing
            End If

        Catch ex As Exception
            oCardInfo.Message = "Ошибка"
            oCardInfo.CardCollection = Nothing
        End Try
        RaisePropertyChanged("CardInfo")
        RaisePropertyChanged("FirstCardData")
        RaisePropertyChanged("HasCards")
    End Sub

#Region "timer"
    Private Sub tick(sender As Object, e As EventArgs)
        Static _pause As Integer
        If oCardInfo.CardCollection Is Nothing Then _pause = 0
        If _pause > 0 Then
            _pause -= 1
            Return
        End If
        ReadCards()
        Application.DoEvents()
        If Not oCardInfo.CardCollection Is Nothing Then
            'посылаю клавиши
            Dim _resultString = oCardInfo.CardCollection.FirstOrDefault.Sector0Block1STR.Trim
            If _resultString = "131313" Then
                SendKeys.SendWait("{Backspace}{Backspace}{Backspace}{Backspace}{Backspace}{Backspace}{Backspace}{Backspace}{Backspace}")
            Else
                SendKeys.SendWait(_resultString & ChrW(13))
            End If
            'блокирую чтение на 20 запроса
            _pause = cntReadyDelayStep
        End If
    End Sub
#End Region

    Public Sub New()
        Test_connection()
        oCardInfo = New clsCardInfo
        oTimer = New Timers.Timer(cntTimerInterval)
        AddHandler oTimer.Elapsed, AddressOf Me.tick
        If oIsConnected Then
            ReadCards()
        End If
    End Sub

#Region "методы для взаимодействия"

    Public Class ScannerStatusChangedEventArgs
        Inherits EventArgs
        Public Property IsScannerStatus As Boolean
    End Class
    ''' <summary>
    ''' происходит при смене режима работы (сканер или форма)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Event ScannerStatusChanged(sender As Object, e As ScannerStatusChangedEventArgs)

    Public Class TagsStringCollectionChangedEventArgs
        Inherits EventArgs
        Public ReadOnly Property FirstTag As String
            Get
                If TagCollection Is Nothing Then Return ""
                If TagCollection.Count = 0 Then Return ""
                Return TagCollection(0)
            End Get
        End Property
        Public Property TagCollection As String()
        Public ReadOnly Property Count As Integer
            Get
                If TagCollection Is Nothing Then Return 0
                Return TagCollection.Count
            End Get
        End Property
    End Class
    ''' <summary>
    ''' происходит при прочтении меток
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Event TagStringCollectionChanged(sender As Object, e As TagsStringCollectionChangedEventArgs)


    Public Event TagWrited(sender As Object, e As EventArgs)

    ''' <summary>
    ''' есть ли прочитанные метки
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property HasCards As Boolean
        Get
            If oCardInfo Is Nothing OrElse oCardInfo.CardCollection Is Nothing Then
                Return False
            End If
            Return True
        End Get
    End Property

    ''' <summary>
    ''' вернет данные первой прочитанной карты
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property FirstCardData As String
        Get
            If oCardInfo.CardCollection Is Nothing Then Return ""
            If oCardInfo.CardCollection.Count = 0 Then Return ""
            Return oCardInfo.CardCollection.FirstOrDefault.Sector0Block1STR.Trim
        End Get
    End Property

    ''' <summary>
    ''' читает метки
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Read()
        If oScannerStatus Then Return
        ReadCards()
    End Sub

    ''' <summary>
    ''' строка состояния подключения
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property ReaderStatusString As String
        Get
            Return oReaderStatusString
        End Get
    End Property

    ''' <summary>
    ''' информация о текущих тегах
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property CardInfo As clsCardInfo
        Get
            Return oCardInfo
        End Get
    End Property

    ''' <summary>
    ''' записывает данные на метку
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Write(cardIndex As Integer, data As String) As Boolean
        'запись в режиме сканер невозможна
        If oScannerStatus Then Return False
        If cardIndex < 0 Then Return False
        If cardIndex > oCardInfo.CardCollection.Count - 1 Then Return False
        Dim _card = oCardInfo.CardCollection.Item(cardIndex)
        _card.Sector0Block1STR = data.Trim
        Dim _result = Me.oReader.WriteData(_card, 1)
        If _result <= 0 Then Return False
        RaiseEvent TagWrited(Me, EventArgs.Empty)
        Return True
    End Function

    ''' <summary>
    ''' включает автономную работу
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub StartScanner()
        If oScannerStatus Then Return
        ReadCards()
        oTimer.Start()
        oScannerStatus = True
        RaiseEvent ScannerStatusChanged(Me, New ScannerStatusChangedEventArgs With {.IsScannerStatus = True})
        oReaderStatusString = "сканер"
        RaisePropertyChanged("IsScannerMode")
        RaisePropertyChanged("ReaderStatusString")
    End Sub
    ''' <summary>
    ''' выключает автономную работу
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub StopScanner()
        If Not oScannerStatus Then Return
        oTimer.Stop()
        oReaderStatusString = "подключено"
        oScannerStatus = False
        RaiseEvent ScannerStatusChanged(Me, New ScannerStatusChangedEventArgs With {.IsScannerStatus = True})
        RaisePropertyChanged("IsScannerMode")
        RaisePropertyChanged("ReaderStatusString")
    End Sub

    ''' <summary>
    ''' находится ли в режиме сканера
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property IsScannerMode As Boolean
        Get
            Return oScannerStatus
        End Get
    End Property

#End Region

    Protected Sub RaisePropertyChanged(ByVal propertyName As String)
        Dim propertyChanged As System.ComponentModel.PropertyChangedEventHandler = Me.PropertyChangedEvent
        If (Not (propertyChanged) Is Nothing) Then
            propertyChanged(Me, New System.ComponentModel.PropertyChangedEventArgs(propertyName))
        End If
    End Sub

#Region "IDisposable Support"
    Private disposedValue As Boolean ' Чтобы обнаружить избыточные вызовы

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' освободить управляемое состояние (управляемые объекты).
                If Not oReader Is Nothing Then
                    If oScannerStatus Then
                        oTimer.Stop()
                    End If
                    oReader.CloseReader()
                End If
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

    Public Event PropertyChanged(sender As Object, e As System.ComponentModel.PropertyChangedEventArgs) Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged

    Private Sub oCardInfo_PropertyChanged(sender As Object, e As System.ComponentModel.PropertyChangedEventArgs) Handles oCardInfo.PropertyChanged
        RaisePropertyChanged("CardInfo")
        RaisePropertyChanged("CardCollection")
        RaisePropertyChanged("Message")
    End Sub
End Class
