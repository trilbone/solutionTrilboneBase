Imports System.Linq
Imports Service.clsSampleDataManager
Public Class clsUser
    Implements System.ComponentModel.INotifyPropertyChanged
    ''' <summary>
    ''' пауза для МС
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property MCpause As Integer
        Get
            Dim _res As Integer = 0

            Dim _Ask As New List(Of User.USERWOKEROFFICEACCESSACCESSCOMPUTER)
            For Each c In UserPermission.OFFICEACCESS
                If Not c.ACCESS Is Nothing Then
                    For Each d In c.ACCESS
                        If Not d.COMPUTER Is Nothing AndAlso d.COMPUTER.Count > 0 Then
                            _Ask.AddRange(d.COMPUTER)
                        End If
                    Next
                End If
            Next

            If _Ask.Count = 0 Then Return 0

            Dim _thiscomputer = (From c In _Ask Where c.name.ToLower = clsApplicationTypes.MachineName.ToLower Select c).ToList

            If Not _thiscomputer.Count = 0 Then
#If Not Debug Then
                Try
                    _res = Aggregate c In _thiscomputer Into Max(CType(c.MCpause, Integer))
                Catch ex As Exception
                    MsgBox("Не удалось определить задержку запросов МС для этого компьютера. Обратитесь к администратору.", vbCritical)
                    Return 0
                End Try
#End If
                _res = Aggregate c In _thiscomputer Into Max(CType(c.MCpause, Integer))

            Else

#If Not Debug Then
                Try
                    _res = Aggregate c In _Ask Where c.name = "ALL" Into Max(CType(c.MCpause, Integer))
                Catch ex As Exception
                    MsgBox("Не удалось определить задержку запросов МС для пользователя. Обратитесь к администратору.", vbCritical)
                    Return 0
                End Try
#End If

                _res = Aggregate c In _Ask Where c.name = "ALL" Into Max(CType(c.MCpause, Integer))

            End If

            Return _res
        End Get
    End Property

    Public Overrides Function ToString() As String
        If Me.oUserShotName = "" Then
            Return MyBase.ToString()
        End If
        Return Me.oUserShotName
    End Function



    ''' <summary>
    ''' класс с разрешениями для пользователя
    ''' </summary>
    Public Property UserPermission As User.USERWOKER

    ''' <summary>
    ''' класс БД
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Employee As tbEmployee


    Private oIsConnected As Boolean
    ''' <summary>
    ''' отобразит состояние подключения
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property IsConnected As String
        Get
            If oIsConnected Then Return "online"
            Return "offline"
        End Get
        Set(value As String)
            oIsConnected = Boolean.Parse(value)
        End Set

    End Property

    Private oCurrentStatus As Service.clsSampleDataManager.emWTimeOperation
    ''' <summary>
    ''' статус текущего в clsApplicationTypes пользователя
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property CurrentStatus As Service.clsSampleDataManager.emWTimeOperation
        Get
            Return oCurrentStatus
        End Get
        Set(value As Service.clsSampleDataManager.emWTimeOperation)
            Me.oCurrentStatus = value
            Me.RaisePropertyChanged("CurrentStatus")
        End Set
    End Property
    ''' <summary>
    ''' запрос в БД за данными
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub RequestStatus(Optional _result As wGetLastOperation_Result = Nothing)
        If CheckConnection() Then
            Try
                Dim _res = (clsApplicationTypes.SampleDataObject.GetdbPhotoObjectContext.wGetLastOperation(Me.UserPermission.id, emWTimeRecordType.User)).ToList

                If _res.Count = 0 Then
                    'нет записи в БД
                    Me.CurrentStatus = emWTimeOperation.NoStatus
                    Return
                End If

                If _res.Count > 1 Then
                    'что-то не так
                    Me.CurrentStatus = emWTimeOperation.NoStatus
                    Return
                End If
                Dim _st = _res.First
                SetUserStatus(_st.TimeAccounting.Value,_st.WTimeOperationID.Value)
            Catch ex As Exception
                'соединение сброшено
                Me.CurrentStatus = emWTimeOperation.NotConnected
                Me.IsConnected = "False"
            End Try
        Else
            'нет сети
            'проверить статус по локальным записям
            'если записей нет, то считатем, что нет на работе
            'SetUserStatus(timeacc:=clsApplicationTypes.GetCurrentTime, WTimeOperationID:=emWTimeOperation.EndWork)
            'иначе установим статус из локального файла
            SetUserStatus(timeacc:=clsApplicationTypes.GetCurrentTime, WTimeOperationID:=emWTimeOperation.NotConnected)
        End If
    End Sub
    ''' <summary>
    ''' установить статус для лузера (вызов только при наличии сети?)
    ''' </summary>
    ''' <param name="_result"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Sub SetUserStatus(timeacc As Date, WTimeOperationID As Integer)
        If Not CheckConnection() Then
            Me.CurrentStatus = emWTimeOperation.NotConnected
            Return
        End If

        'установить статусы
        Me.CurrentTime = clsApplicationTypes.GetCurrentTime - timeacc
        Me.CurrentStatus = WTimeOperationID
    End Sub


    Protected Sub RaisePropertyChanged(ByVal propertyName As String)
        Dim propertyChanged As System.ComponentModel.PropertyChangedEventHandler = Me.PropertyChangedEvent
        If (Not (propertyChanged) Is Nothing) Then
            propertyChanged(Me, New System.ComponentModel.PropertyChangedEventArgs(propertyName))
        End If
    End Sub

    Private Function CheckConnection() As Boolean
        If clsApplicationTypes.SampleDataObject.GetdbPhotoObjectContext Is Nothing Then
            Me.IsConnected = "False"
            Return False
        End If
        Me.IsConnected = "True"
        Return True
    End Function

    Private oCurrentStatusString As String
    ''' <summary>
    ''' текущий статус (на работе, нет в мастерской, на обеде)
    ''' </summary>
    Public ReadOnly Property CurrentStatusString As String
        Get
            Select Case CurrentStatus
                Case -1
                    oCurrentStatusString = "Нет подключения"
                Case 0
                    oCurrentStatusString = "Нет данных"
                Case 1
                    oCurrentStatusString = "На работе"
                Case 2
                    oCurrentStatusString = "Нет в мастерской"
                Case 3
                    oCurrentStatusString = "На обеде"
                Case 4
                    oCurrentStatusString = "После зарплаты"
                Case Else
                    oCurrentStatusString = "Неизвестно"
            End Select
            Me.RaisePropertyChanged("CurrentStatusString")
            Return oCurrentStatusString
        End Get
    End Property
    Private oCurrentTime As TimeSpan
    ''' <summary>
    ''' время между сейчас и последним статусом
    ''' </summary>
    Public Property CurrentTime As TimeSpan
        Get
            If Not CheckConnection() Then
                oCurrentTime = TimeSpan.Zero
                Me.RaisePropertyChanged("CurrentTime")
                Return oCurrentTime
            End If
            ''запрос
            Dim a = CurrentStatus
            Me.RaisePropertyChanged("CurrentTime")
            Return oCurrentTime
        End Get
        Set(value As TimeSpan)
            oCurrentTime = value
            Me.RaisePropertyChanged("CurrentTime")
        End Set
    End Property

    ''' <summary>
    ''' список образцов в работе
    ''' </summary>
    Public ReadOnly Property OperationOnWork As List(Of tbSMOperation)
        Get
            Return Me.GetCurrentLotList
        End Get
    End Property

    Private oUserShotName As String

    ''' <summary>
    ''' короткое имя пользователя
    ''' </summary>
    Public Property UserShotName As String
        Get
            Return oUserShotName
        End Get
        Set(value As String)
            oUserShotName = value
            Me.RaisePropertyChanged("UserShotName")
        End Set
    End Property

    ''' <summary>
    ''' тариф сотрудника в час в рублях
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property GetRURSalary As Decimal
        Get
            If Not Me.Employee Is Nothing Then
                Return clsApplicationTypes.CurrencyConvert(Me.Employee.Tariff.GetValueOrDefault, Me.Employee.Currency, "RUR")
            End If
            Return 0
        End Get
    End Property
    ''' <summary>
    ''' проверит, не висит ли у лузера уборка. >0 = висит, ругать!
    ''' </summary>
    ''' <returns></returns>
    Public Function GetClearStatus() As Integer
        Dim _result = clsApplicationTypes.SampleDataObject.GetClearStatus(Me.Employee.ID)
        If _result Is Nothing Then Return 0
        Return 1
    End Function

    ''' <summary>
    ''' Начинает рабочее время
    ''' </summary>
    Public Function StartWork() As Boolean
        If CheckConnection() Then
            Dim _result = clsApplicationTypes.SampleDataObject.RegisterTime(Me.Employee.ID, clsSampleDataManager.emWTimeOperation.BeginOnWork, clsSampleDataManager.emWTimeRecordType.User)
            If Not _result Is Nothing Then
                SetUserStatus(_result.TimeAccounting.Value, _result.WTimeOperationID.Value)
                'записать в базу и стереть все локальные записи пользователя
                'записать локально статус "работа начата"
                'clsApplicationTypes.LocalRegisterTime(Me.Employee.ID, clsSampleDataManager.emWTimeOperation.BeginOnWork, clsSampleDataManager.emWTimeRecordType.User)
                Return True
            Else
                Return False
            End If
        Else
            'записать  локально статус "работа начата"
            ' Dim _result = clsApplicationTypes.LocalRegisterTime(Me.Employee.ID, clsSampleDataManager.emWTimeOperation.BeginOnWork, clsSampleDataManager.emWTimeRecordType.User)
            'Return True
            Return False
        End If

    End Function

    ''' <summary>
    ''' Приостанавливает время (обед)
    ''' </summary>
    Public Function SuspendWork() As Boolean
        If CheckConnection() Then
            Dim _result = clsApplicationTypes.SampleDataObject.RegisterTime(Me.Employee.ID, clsSampleDataManager.emWTimeOperation.SuspendWork, clsSampleDataManager.emWTimeRecordType.User)
            If Not _result Is Nothing Then
                SetUserStatus(_result.TimeAccounting.Value, _result.WTimeOperationID.Value)
                'записать в базу и стереть все локальные записи пользователя
                'записать локально статус "обед"
                'clsApplicationTypes.LocalRegisterTime(Me.Employee.ID, clsSampleDataManager.emWTimeOperation.SuspendWork, clsSampleDataManager.emWTimeRecordType.User)
                Return True
            Else
                Return False
            End If
        Else
            'если есть хоть одна локальная запись о начале работы, то записать локально статус "обед"
            'Dim _result = clsApplicationTypes.LocalRegisterTime(Me.Employee.ID, clsSampleDataManager.emWTimeOperation.SuspendWork, clsSampleDataManager.emWTimeRecordType.User)
            'Return True
            Return False
        End If

    End Function
    ''' <summary>
    ''' отказ от уборки в конце дня
    ''' </summary>
    ''' <returns></returns>
    Public Function ClearOff() As Boolean
        If CheckConnection() Then
            Dim _result = clsApplicationTypes.SampleDataObject.RegisterTime(Me.Employee.ID, clsSampleDataManager.emWTimeOperation.ClearOff, clsSampleDataManager.emWTimeRecordType.User)
            If Not _result Is Nothing Then
                'SetUserStatus(_result.TimeAccounting.Value, _result.WTimeOperationID.Value)
                'записать в базу и стереть все локальные записи пользователя
                'статус "Окончание работы" НЕ ЗАПИСЫВАЕТСЯ (считать статусом по умолчанию - при отсутствии локальных записей)
                Return True
            Else
                Return False
            End If
        Else
            'если есть хоть одна локальная запись о начале работы, то записать локально статус "Отказ от уборки"
            'Dim _result = clsApplicationTypes.LocalRegisterTime(Me.Employee.ID, clsSampleDataManager.emWTimeOperation.ClearOff, clsSampleDataManager.emWTimeRecordType.User)
            'Return True
            Return False
        End If
    End Function


    ''' <summary>
    ''' Заканчивает работу
    ''' </summary>
    Public Function StopWork() As Boolean
        If CheckConnection() Then
            Dim _result = clsApplicationTypes.SampleDataObject.RegisterTime(Me.Employee.ID, clsSampleDataManager.emWTimeOperation.EndWork, clsSampleDataManager.emWTimeRecordType.User)
            If Not _result Is Nothing Then
                SetUserStatus(_result.TimeAccounting.Value, _result.WTimeOperationID.Value)
                'записать в базу и стереть все локальные записи пользователя
                'статус "Окончание работы" НЕ ЗАПИСЫВАЕТСЯ (считать статусом по умолчанию - при отсутствии локальных записей)
                Return True
            Else
                Return False
            End If
        Else
            'если есть хоть одна локальная запись о начале работы, то записать локально статус "Окончание работы"
            'Dim _result = clsApplicationTypes.LocalRegisterTime(Me.Employee.ID, clsSampleDataManager.emWTimeOperation.EndWork, clsSampleDataManager.emWTimeRecordType.User)
            'Return True
            Return False
        End If
    End Function
    ''' <summary>
    ''' запускает лот в работу
    ''' </summary>
    ''' <param name="number"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function StartOperation(SMOperationID As Integer) As Boolean
        Return clsApplicationTypes.SampleDataObject.RegisterOperation(clsSampleDataManager.emWTimeOperation.BeginOnWork, clsSampleDataManager.emWTimeRecordType.User, SMOperationID)
    End Function

    ''' <summary>
    ''' приостанавливает работу над лотом
    ''' </summary>
    ''' <param name="number"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SuspendOperation(SMOperationID As Integer) As Boolean
        Return clsApplicationTypes.SampleDataObject.RegisterOperation(clsSampleDataManager.emWTimeOperation.SuspendWork, clsSampleDataManager.emWTimeRecordType.User, SMOperationID)
    End Function



    ''' <summary>
    ''' закончить работу над лотом
    ''' </summary>
    ''' <param name="number"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function StopOperation(SMOperationID As Integer) As Boolean
        Return clsApplicationTypes.SampleDataObject.RegisterOperation(clsSampleDataManager.emWTimeOperation.EndWork, clsSampleDataManager.emWTimeRecordType.User, SMOperationID)
    End Function

    ''' <summary>
    ''' добавить камень в лот
    ''' </summary>
    ''' <param name="number"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function AddInLot(Number As clsApplicationTypes.clsSampleNumber, SMOperationID As Integer) As Boolean
        'проверить лот по операции - одиночный или лотовый
        Dim _res = (From c In clsApplicationTypes.SampleDataObject.GetdbPhotoObjectContext.tbSMLotOperation
                   Where c.SMOperationID = SMOperationID
                   Select c.tbSMLot).ToList

        If _res.Count = 0 Then
            'нет такой опесраци
            Return False
        End If


        If (From c In _res Where c.LotNumber.Equals(Number.ShotCode)).Count > 0 Then
            'лот уже есть в операции
            Return False
        End If

        Dim _lres = (From c In clsApplicationTypes.SampleDataObject.GetdbPhotoObjectContext.tbSMLot
                  Where c.LotNumber.Equals(Number.ShotCode) Select c).ToList

        Dim _targetLotID As Integer
        Select Case _lres.Count
            Case 0
                'образца нет - создать
                Dim _newobj = Service.tbSMLot.CreatetbSMLot(0, 0, 1)
                With _newobj
                    'Учет завершен
                    .AccountingComplete = False

                    'номер лота
                    If Number Is Nothing Then
                        .LotNumber = "без номера"
                    Else
                        .LotNumber = Number.ShotCode
                    End If

                    'предварительное название
                    .PreName = "образец"

                    'кол-во в лоте
                    .qty = 1

                    'Экспедиция
                    .Expedition = ""

                    'Экспедиционный номер
                    .ExpeditionNumber = ""

                    'текст со свертка
                    .RollText = ""

                    'Тип лота ID
                    'по умолчанию - одиночный образец
                    .SMLotTypeID = 1

                    'ед измерения ID
                    'штуки
                    .uomID = 2

                    'есть сообщения флаг
                    .HasMessages = False
                End With
                'привязать к контексту
                clsApplicationTypes.SampleDataObject.GetdbPhotoObjectContext.AddTotbSMLot(_newobj)
                If clsApplicationTypes.SampleDataObject.SavePhotoObjectContext() = 0 Then
                    'не сохранился
                    Return False
                End If
                _targetLotID = _newobj.ID
                If _targetLotID = 0 Then
                    'не обновился id
                    Return False
                End If
            Case 1
                'есть
                _targetLotID = _lres(0).ID
            Case Else
                'повтор записи
                _targetLotID = _lres(0).ID
        End Select

        'создать запись
        Dim _newobj2 = Service.tbSMLotOperation.CreatetbSMLotOperation(0, _targetLotID, SMOperationID)
        clsApplicationTypes.SampleDataObject.GetdbPhotoObjectContext.AddTotbSMLotOperation(_newobj2)
        If clsApplicationTypes.SampleDataObject.SavePhotoObjectContext() > 0 Then
            clsApplicationTypes.BeepYES()
            Return True
        End If
        '--------
        Return False
    End Function
    ''' <summary>
    ''' узнать статус операции SMOperation
    ''' </summary>
    ''' <param name="SMOperationID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetOperationStatus(SMOperationID As Integer) As emWTimeOperation
        If Not Me.oIsConnected Then Return emWTimeOperation.NotConnected

        Dim _result = (From c In clsApplicationTypes.SampleDataObject.GetdbPhotoObjectContext.tbSMTime
                       Where c.SMOperationID = SMOperationID
                       Where c.TimeMarker = Aggregate d In clsApplicationTypes.SampleDataObject.GetdbPhotoObjectContext.tbSMTime
                                            Where d.SMOperationID = SMOperationID
                                            Into Max(d.TimeMarker)
                                            Select c.tbSMtimeoperation.ID).FirstOrDefault

        Return _result
    End Function

    ''' <summary>
    ''' вернет список активных (в работе, приостановленных) операций для текущего сотрудника CurrentUser
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetCurrentLotList() As List(Of tbSMOperation)
        'загрузка операций из БД - получить список активных (в работе, приостановленных) операций из таблицы tbSMTime (используя SMOperationID)
        Dim _source = clsApplicationTypes.SampleDataObject.GetdbPhotoObjectContext.tbSMTime
        Dim _rt = From c In _source
                  Where c.EmployeeID = Me.Employee.ID
                Group By c.SMOperationID Into cr = Group
                Aggregate e In cr Into mt = Max(e.TimeAccounting)
                From k In cr
                Where k.TimeAccounting = mt And (k.SMTimeOperationID = emWTimeOperation.BeginOnWork Or k.SMTimeOperationID = emWTimeOperation.SuspendWork)
                Select k.tbSMOperation

        Return _rt.ToList





        ''начала работы
        'Dim _resultStart = From c In _source
        '              Where c.EmployeeID = clsApplicationTypes.CurrentUser.Employee.ID And (c.SMTimeOperationID = emWTimeOperation.BeginOnWork Or c.SMTimeOperationID = emWTimeOperation.SuspendWork)
        '              Where c.TimeAccounting =
        '                  Aggregate d In _source
        '                  Where d.SMOperationID = c.SMOperationID And (d.SMTimeOperationID = emWTimeOperation.BeginOnWork Or d.SMTimeOperationID = emWTimeOperation.SuspendWork)
        '                  Into Max(d.TimeAccounting)

        ''окончания работы
        'Dim _resultEnd = From c In _source
        '              Where c.EmployeeID = clsApplicationTypes.CurrentUser.Employee.ID And (c.SMTimeOperationID = emWTimeOperation.EndWork)
        '              Where c.TimeAccounting =
        '                    Aggregate d In _source
        '                    Where d.SMOperationID = c.SMOperationID And (d.SMTimeOperationID = emWTimeOperation.EndWork)
        '                    Into Max(d.TimeAccounting)


        ' ''left Joined by SMOperationID = все начала
        ''Dim _result4 = From c In _result
        ''               Group Join b In _result2
        ''               On c.SMOperationID Equals b.SMOperationID Into sr = Group
        ''               From e In sr.DefaultIfEmpty
        ''               Where (e.TimeAccounting.HasValue = False) Or (c.TimeAccounting > e.TimeAccounting)
        ''               Select c.tbSMOperation

        ''альтернатива
        ''отобрали завершенных, у кого есть запись окончания
        'Dim _res2 = From c In _resultStart, b In _resultEnd
        '            Where c.SMOperationID = b.SMOperationID And c.TimeAccounting < b.TimeAccounting
        '            Select c

        ''разность множеств
        'Dim _res3 = _resultStart.Except(_res2)

        ''Dim _out = _result4.ToList
        'Dim _out1 = _res3.Select(Function(x) x.tbSMOperation).ToList

        ''If _out.Count = _out1.Count Then
        ''    Debug.Fail("Что-то с логикой запроса")
        ''End If

        'Return _out1
    End Function

    ''' <summary>
    ''' сброс принтера
    ''' </summary>
    Public Sub PrinterReset()

    End Sub

    ''' <summary>
    ''' получить фото со встроенной камеры
    ''' </summary>
    Public Shared Function GetPhotoFromCamera() As Drawing.Image
        Return Nothing
    End Function

    Public Class clsSchema

        ''' <summary>
        ''' имадж схемы
        ''' </summary>
        Public Property ShemeLabel As Drawing.Image


        ''' <summary>
        ''' надпись с экспедиционного свертка
        ''' </summary>
        Public Property InfoFromRawRoll As String


        ''' <summary>
        ''' название камня
        ''' </summary>
        Public Property InfoSampleName As String


        ''' <summary>
        ''' экспедиционный номер
        ''' </summary>
        Public Property InfoExpeditionNumber As String


        ''' <summary>
        ''' экспедиция
        ''' </summary>
        Public Property InfoExpedition As String


        ''' <summary>
        ''' источник имен образцов
        ''' </summary>
        Public Property SampleNameRowSource As String()


        ''' <summary>
        ''' источник экспедиций
        ''' </summary>
        Public Property ExpeditionRowSource As String()


        ''' <summary>
        ''' печатать схему
        ''' </summary>
        Public Sub PrintScheme()

        End Sub

    End Class


    'Public Class clsUserSample
    '    ''' <summary>
    '    ''' из БД
    '    ''' </summary>
    '    Public Property ID As Integer
    '    ''' <summary>
    '    ''' короткий номер
    '    ''' </summary>
    '    Public Property ShotNumber As Integer
    '    Public Property EAN13 As Decimal

    '    ''' <summary>
    '    ''' статус образца: в работе, отложен, готов, разжалован в запчасти
    '    ''' </summary>
    '    Public Property SampleStatus As String
    '        Get

    '        End Get
    '        Set(value As String)

    '        End Set
    '    End Property

    '    ''' <summary>
    '    ''' имадж номера
    '    ''' </summary>
    '    Public Property NumberLabel As Drawing.Image
    '        Get

    '        End Get
    '        Set(value As Drawing.Image)

    '        End Set
    '    End Property

    '    ''' <summary>
    '    ''' сдать образец
    '    ''' </summary>
    '    Public Function ReadySample() As Boolean

    '    End Function

    '    ''' <summary>
    '    ''' приостановить работу над образцом (отложить)
    '    ''' </summary>
    '    Public Function PauseSample() As Boolean

    '    End Function

    '    ''' <summary>
    '    ''' разжаловать в запчасти
    '    ''' </summary>
    '    Public Function ToPartSample() As Boolean

    '    End Function

    '    ''' <summary>
    '    ''' печать номера
    '    ''' </summary>
    '    Public Sub PrintNumberLabel()

    '    End Sub

    '    ''' <summary>
    '    ''' задать название камню
    '    ''' </summary>
    '    Public Function SetSpecies() As Boolean

    '    End Function


    '    ''' <summary>
    '    ''' взять новый камень
    '    ''' </summary>
    '    Public Shared Function CreateInstance() As clsUserSample

    '    End Function

    '    ''' <summary>
    '    ''' получить новый номер из БД
    '    ''' </summary>
    '    Public Function GetNewNumber() As clsApplicationTypes.clsSampleNumber

    '    End Function

    '    ''' <summary>
    '    ''' зарегить схему в БД
    '    ''' </summary>
    '    Public Function RegisterSchema() As clsApplicationTypes.clsSampleNumber

    '    End Function

    '    ''' <summary>
    '    ''' создать новую схему
    '    ''' </summary>
    '    Public Sub GetNewChema()

    '    End Sub

    '    ''' <summary>
    '    ''' записать фото готового
    '    ''' </summary>
    '    Public Sub SetPhotoReadySample()

    '    End Sub

    '    ''' <summary>
    '    ''' записать фото при регистрации
    '    ''' </summary>
    '    Public Sub SetPhotoRawSample()

    '    End Sub

    '    ''' <summary>
    '    ''' записать фото схемы
    '    ''' </summary>
    '    Public Sub SetPhotoSchema()

    '    End Sub

    '    ''' <summary>
    '    ''' приостановить работу над камнем
    '    ''' </summary>
    '    Public Function SuspendSample() As Boolean

    '    End Function



    'End Class

    Public Event PropertyChanged(sender As Object, e As ComponentModel.PropertyChangedEventArgs) Implements ComponentModel.INotifyPropertyChanged.PropertyChanged
End Class
