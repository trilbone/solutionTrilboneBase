Imports Service
Imports System.Linq
Imports System.Collections.Generic
Imports System.Windows.Forms
Imports System.ComponentModel
Imports System.Drawing
Imports System.Diagnostics
Imports System.Deployment.Application
''' <summary>
''' 
''' </summary>
''' <remarks></remarks>
Public Class fmWtime
#Region "Определения"
    '
    ' oUserActivity = -1  приложение не выключится
    ' oUserActivity => 0 сработает таймер через 10 циклов (минут) на выход

    ''' <summary>
    ''' счетчик активности пользователя // -1  приложение не выключится// oUserActivity => 0 сработает таймер через 10 циклов (минут) на выход
    ''' </summary>
    ''' <remarks></remarks>
    Private oUserActivity As Integer
    Private _splash As New SplashScreen1

    Public Shared ReadOnly Property GetDigiKey As Object
        Get
            Return Service.clsApplicationTypes.GetDigiKeyBoardForm
            'использование в событии mouseClick ЭУ
            'Dim _tb As TextBoxBase = sender
            '_tb.Text = ""
            'clsPhotoService.GetDigiKey.connect(_tb)
        End Get
    End Property

#End Region

#Region "ctor"
    Dim oNeedResetPrinters As Boolean

    Sub New()
        ' Этот вызов является обязательным для конструктора.
        InitializeComponent()

        ' Добавьте все инициализирующие действия после вызова InitializeComponent().
        init()

        Me.LockCtl()
        'интервал = минута
        Me.TimerClock.Start()
        oUserActivity = -1

        Me.tbPin.Focus()
    End Sub
    ''' <summary>
    ''' дополнительня инициализация ЭУ
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub init()
        _splash.Owner = Me
        Me.tbctlMain.TabPages.Clear()
        Me.tbctlMain.TabPages.Add(Me.tpTime)


        Me.lbCurrentTime.Text = Service.clsApplicationTypes.GetCurrentTimeString
        Me.lbCurrentTime.Refresh()

        If clsApplicationTypes.SampleDataObject.IsConnected Then
            lbConnectStatus.Text = "online"
        Else
            lbConnectStatus.Text = "offline"
        End If

        Me.TextBox10.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.IMoySkladDataProvider_ParcelInfoBindingSource, "ClientAddress.Name", True))
        Me.TextBox11.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.IMoySkladDataProvider_ParcelInfoBindingSource, "ClientAddress.Phone", True))
        Me.CityTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.IMoySkladDataProvider_ParcelInfoBindingSource, "ClientAddress.City", True))
        Me.CountryTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.IMoySkladDataProvider_ParcelInfoBindingSource, "ClientAddress.Country", True))
        Me.NameTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.IMoySkladDataProvider_ParcelInfoBindingSource, "ClientAddress.Name", True))
        Me.PhoneTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.IMoySkladDataProvider_ParcelInfoBindingSource, "ClientAddress.Phone", True))
        Me.PostIndexTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.IMoySkladDataProvider_ParcelInfoBindingSource, "ClientAddress.PostIndex", True))
        Me.StateTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.IMoySkladDataProvider_ParcelInfoBindingSource, "ClientAddress.State", True))
        Me.StreetTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.IMoySkladDataProvider_ParcelInfoBindingSource, "ClientAddress.Street", True))
    End Sub


#End Region

#Region "Таймер"




    ''' <summary>
    ''' ТАЙМЕР
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TimerClock_Tick(sender As Object, e As EventArgs) Handles TimerClock.Tick
        'раз в минуту
        If Me.Visible = True Then
            Me.lbCurrentTime.Text = Service.clsApplicationTypes.GetCurrentTimeString
            If Not clsApplicationTypes.CurrentUser Is Nothing Then
                'обновляет класс clsUser из БД
                clsApplicationTypes.CurrentUser.RequestStatus()
                ShowUserStatus()
            End If
            'выход, если счетчик >10
            If oUserActivity > 10 Then Me.btSingOut_Click(sender, e)
            'если -1, то заморозка
            If oUserActivity >= 0 Then
                oUserActivity += 1
            End If

            Me.Refresh()
        End If
    End Sub



#End Region

#Region "Мой Склад"

    Private Event MCLoadedEvent(sender As Object, e As EventArgs)

    ''' <summary>
    ''' ловит окончание загрузки МС
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MCLoaded_EventHandler(sender As Object, e As EventArgs)
        Me.lbMoySkladStatus.BackColor = Color.Green
    End Sub
    ''' <summary>
    ''' флаг уже работающего запроса МС
    ''' </summary>
    ''' <remarks></remarks>
    Private oMSDoWork As Boolean = False

    ''' <summary>
    ''' загрузка МС в фоне 
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub InitMC()
        'запрет повторного запуска
        If oMSDoWork Then Return

        Dim _result As Object

        AddHandler MCLoadedEvent, AddressOf MCLoaded_EventHandler

        Dim _RunWorkerCompleted = Sub(sender As Object, e As RunWorkerCompletedEventArgs)
                                      ' First, handle the case where an exception was thrown.
                                      oMSDoWork = False
                                      If (e.Error IsNot Nothing) Then
                                          MessageBox.Show("Ошибка асинхронной загрузки МС: " & e.Error.Message)
                                      ElseIf e.Cancelled Then
                                          ' Next, handle the case where the user canceled the 
                                          ' operation.
                                          ' Note that due to a race condition in 
                                          ' the DoWork event handler, the Cancelled
                                          ' flag may not have been set, even though
                                          ' CancelAsync was called.
                                          MsgBox("Операция прервана пользователем", vbInformation)

                                      Else
                                          ' Finally, handle the case where the operation succeeded.
                                          'отобразим результат операции
                                          _result = e.Result
                                          If _result Is Nothing Then
                                              clsApplicationTypes.BeepNOT()
                                          Else
                                              '_result=clsMoySkladManager
                                              Dim _i = clsApplicationTypes.DelegatStoreMCinterface.Invoke(False)
                                              clsApplicationTypes.MoySklad(False, False, False) = _i
                                              RaiseEvent MCLoadedEvent(_i, EventArgs.Empty)
                                          End If
                                      End If
                                  End Sub

        Dim _DoWork = Sub(sender As Object, e As DoWorkEventArgs)
                          ' Get the BackgroundWorker object that raised this event.
                          oMSDoWork = True
                          Dim worker As BackgroundWorker =
                                                        CType(sender, BackgroundWorker)
                          e.Result = e.Argument.Invoke(clsApplicationTypes.MoySkladUser, clsApplicationTypes.MoySkladPass)

                      End Sub

        Dim _BackgroundWorkerMC As New System.ComponentModel.BackgroundWorker

        AddHandler _BackgroundWorkerMC.DoWork, _DoWork
        AddHandler _BackgroundWorkerMC.RunWorkerCompleted, _RunWorkerCompleted

        If Not clsApplicationTypes.DelegatStoreMCCreateManager Is Nothing Then
            _BackgroundWorkerMC.RunWorkerAsync(clsApplicationTypes.DelegatStoreMCCreateManager)
        End If



    End Sub

#End Region

#Region "Пин и регистрация"

    ''' <summary>
    ''' Проверка ввода и вход вне ПИНа по пачке))
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tbPin_KeyPress(sender As Object, e As Windows.Forms.KeyPressEventArgs) Handles tbPin.KeyPress, Me.KeyPress
        Static _text As String = ""
        If Char.IsDigit(e.KeyChar) Then
            'цифра
            'очистить поле и начать ввод
            If _text.Length > 0 Then
                _text += e.KeyChar.ToString
            Else
                _text = e.KeyChar.ToString
            End If
        End If

        If Asc(e.KeyChar) = 13 Then
            If _text.Equals("46150769") Then
                'ждать второй код
                _text = ""
                tbPin.Text = ""
                clsApplicationTypes.BeepYES()
            ElseIf _text.Length = 13 Then
                Dim _sn = _text

                Me.tbctlMain.Enabled = True
                Me.btSingOut.Enabled = True
                Me.tbctlMain.TabPages.Clear()
                Me.tbctlMain.TabPages.Add(tpSampleInfo)
                Me.tbctlMain.SelectedTab = tpSampleInfo

                clsApplicationTypes.BeepYES()
                Me.Invalidate()
                Application.DoEvents()
                Me.Uc_trilbone_history1.SampleNumber = _sn
                Application.DoEvents()
                _text = ""
                tbPin.Text = ""
            ElseIf _text.Length = 4 Then
                Me.CheckPin(sender, e)
            End If
        End If


    End Sub

    ''' <summary>
    ''' проверка ПИН
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CheckPin(sender As Object, e As EventArgs)
        'проверка и установка лузера
        Dim _result = (From c As clsUser In Service.clsApplicationTypes.Users Where c.UserPermission.pin.ToLower = Me.tbPin.Text.ToLower Select c).FirstOrDefault

        If _result Is Nothing Then
            'ошибка ПИН
            Me.tbPin.Text = ""
            ' Me.LockCtl()
            MsgBox("Неверный ПИН. Попробуйте еще раз.", vbCritical, "Проверка ПИН")
            oUserActivity = -1
            Me.Focus()
            Return
        End If
        'запуск асинхронных модулей в clsApplicationTypes.new()

        'проверка прав
        If Not _result.UserPermission.GetAccess("Вход в систему") Then
            Me.tbPin.Text = ""
            'Me.LockCtl()
            MsgBox("У вас нет прав на запуск приложения с этого компьютера.", vbCritical, "Проверка доступа")
            oUserActivity = -1
            Me.Focus()
            Return
        End If

        oUserActivity = 1
        Me.TopMost = False

        'проверка загрузки МС
        If Service.clsApplicationTypes.MoySklad(False, False, True) Is Nothing Then
            Me.lbMoySkladStatus.BackColor = Color.Red
        Else
            Me.lbMoySkladStatus.BackColor = Color.Green
        End If

        'проверка сети
        Application.DoEvents()
        If clsApplicationTypes.NetworkStatus = False Then
            'повторный запрос
            Trilbone_load.initService()

            If clsApplicationTypes.NetworkStatus = False Then
                ' MsgBox("Подключение к сети ограничено или отсутствует! Работа приложения ограничена.", vbCritical)
                oUserActivity = 1
                'Me.tbPin.Text = ""
                Me.lbConnectStatus.Text = "offline"

                'тут ограниченно открыть кнопки запуска и остановки работы
                Me.btStartWork.Enabled = True
                Me.btSuspendWork.Enabled = True
                Me.btStopWork.Enabled = True

                'запрос статуса работы по локальным данным
                clsApplicationTypes.CurrentUser = _result
                clsApplicationTypes.CurrentUser.RequestStatus()

                _splash.Hide()
                ShowUserStatus()
                Me.Focus()
                Return
                'Else
                '    _result = (From c As clsUser In Service.clsApplicationTypes.Users Where c.UserPermission.pin.ToLower = Me.tbPin.Text.ToLower Select c).FirstOrDefault
                '    Me.lbConnectStatus.Text = "online"
            End If

        Else
            Me.lbConnectStatus.Text = "online"
        End If
        ''---------------------
        'тут точно есть подключение
#If Not DEBUG Then
 Me.TopMost = True
#End If
        If _result.Employee Is Nothing Then
            ''подгрузим данные лузера из БД
            clsApplicationTypes.LoadUser(_result.UserPermission.id, True)
        End If

        If _result.Employee Is Nothing Then
            MsgBox("Обьект связи с бд не загружен для пользователя: " & _result.UserShotName, vbCritical)
            Return
        End If

        'пользователь найден, разблокировка
        clsApplicationTypes.CurrentUser = _result
        'порядок важен!!
        UnLockCtl()
        _splash.Show()
        _splash.Refresh()

        ClsUserBindingSource.DataSource = clsApplicationTypes.CurrentUser

        'запрос статуса работы
        clsApplicationTypes.CurrentUser.RequestStatus()

        Dim _res = ShowUserStatus()
        If _res = clsSampleDataManager.emWTimeOperation.NoStatus Or _res = clsSampleDataManager.emWTimeOperation.NotConnected Then
            clsApplicationTypes.BeepNOT()
        Else
            clsApplicationTypes.BeepYES()
            'загрузка обьектов БД
            Me.LoadUom()
            Me.LoadWorkOperation()
            Me.LoadTariff()
            Me.LoadEmployee()

            'загрузка операций из БД - получить список активных (в работе, приостановленных) операций из таблицы tbSMTime (используя SMOperationID)
            'обновить отображаемый список лотов
            Me.RefreshLotList()
        End If

        'РАЗРЕШЕНИЯ 
        '--------------------
        Me.CheckPermissions()
        'асинхронный запуск мойсклад перенесен в событие нажатия кнопки входа
        _splash.Hide()
        Me.Focus()
    End Sub

    ''' <summary>
    ''' установка разрешений. вызывается в процедуре btCheckPin_Click
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CheckPermissions()
        'РАЗРЕШЕНИЯ
        'для всех
        Me.tbctlMain.TabPages.Add(Me.tpMyTime)

        '--------------------
        If clsApplicationTypes.GetAccess("Кто в офисе") Then
            Me.tbctlMain.TabPages.Add(Me.tpHwoInOffice)
        End If
        Me.lbConnectStatus.DataBindings(0).ReadValue()
        If clsApplicationTypes.GetAccess("Приемка образцов") Then
            Me.tbctlMain.TabPages.Add(Me.tpAccepting)
            Me.tbctlMain.TabPages.Add(Me.tpSampleInfo)
            Me.tbctlMain.TabPages.Add(Me.tpОформление)
        End If

        If clsApplicationTypes.GetAccess("выставление на eBay") Then
            Me.tbctlMain.TabPages.Add(Me.tpOnSale)
        End If
        '---------------------------
        If clsApplicationTypes.GetAccess("Информация об операциях сотрудников") Then
            Me.gbSelectEmployee.Visible = True
        Else
            Me.gbSelectEmployee.Visible = False
        End If
        '---------------------------
        If clsApplicationTypes.GetAccess("Управление сотрудниками") Then
            Me.tbctlMain.TabPages.Add(Me.tpEmployee)
            Me.tbctlMain.TabPages.Add(Me.tpSellRegister)
            Me.tbctlMain.TabPages.Add(Me.tpeBayInfo)
        End If
        '--------------------------------
        'на настольных разрешить перемещение формы
        'событие MOVE 
        If clsApplicationTypes.GetAccess("Вход в trilbone") Then
            Me.TopMost = False
            RemoveHandler Me.Move, AddressOf fmWtime_Move
            Me.MinimizeBox = True
            Me.btLoadTrilboneForm.Enabled = True
            Me.tbctlMain.TabPages.Add(Me.tpRfid)
            '--------------------------------

        Else
            Me.btLoadTrilboneForm.Enabled = False
            Me.lbMoySkladStatus.BackColor = Color.Black
        End If
        '---------------------------
        If clsApplicationTypes.GetAccess("Просмотр своих отправлений") Then
            Me.tbctlMain.TabPages.Add(Me.tpParcels)
        End If

        'не забудь заблокировать в LockCtl стр 332 !!!
    End Sub

    ''' <summary>
    ''' Загрузка большого приложения
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btLoadTrilboneForm_Click(sender As Object, e As EventArgs) Handles btLoadTrilboneForm.Click

        If Not clsApplicationTypes.CurrentUser.UserPermission.GetAccess("Вход в trilbone") Then
            MsgBox("У вас нет прав на вход в Trilbone", vbCritical, "Проверка доступа")
            Return
        End If

        'асинхронный запуск мойсклад
        Me.lbMoySkladStatus.BackColor = Color.Yellow
        InitMC()

        '=====main form==========
        'запуск формы

        Dim _fm = New Trilbone_startup.fmMain(lbConnectStatus.Text)
        Dim _version = "(debuger version)"
#If Not Debug Then
      _version= ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString
#End If
        _fm.Text = "Trilbone " & _version

        Service.clsApplicationTypes.FormMain = _fm
        Me.Hide()
        oUserActivity = -1



        Dim _num = clsApplicationTypes.clsSampleNumber.CreateFromString(Me.Uc_trilbone_history1.SampleNumber)
        If Not _num.CodeIsCorrect Then
            _num = clsApplicationTypes.clsSampleNumber.CreateFromString(Me.UcReadySamples1.SampleNumber)
        End If

        If Not _num Is Nothing AndAlso _num.CodeIsCorrect Then
            Dim _SampleNumber As Decimal
            _SampleNumber = _num.GetEan13
            Dim _param As Object = {_SampleNumber}

            _fm.CallAnyForm(clsApplicationTypes.emFormsList.fmSampleData, _param)
        End If

        Service.clsApplicationTypes.FormMain.ShowDialog()
        '================

        Me.lbCurrentTime.Text = Service.clsApplicationTypes.GetCurrentTimeString
        Me.Show()
        oUserActivity = 1
    End Sub

#Region "Utilites"
    Private Sub LoadTariff()
        Dim _res = (clsApplicationTypes.SampleDataObject.GetdbPhotoObjectContext.tbSMTariff).ToList
        Me.TbSMTariffBindingSource.DataSource = _res
    End Sub

    Private Sub LoadEmployee()
        Dim _res = (clsApplicationTypes.SampleDataObject.GetdbPhotoObjectContext.tbEmployee).ToList
        Me.TbEmployeeBindingSource.DataSource = _res
    End Sub

    ''' <summary>
    ''' загрузка списка типов операций
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadWorkOperation()
        Dim _res = (clsApplicationTypes.SampleDataObject.GetdbPhotoObjectContext.tbSMWorkOperation).ToList
        Me.TbSMWorkOperationBindingSource.DataSource = _res
    End Sub

    Private Sub LoadUom()
        Dim _res = (clsApplicationTypes.SampleDataObject.GetdbPhotoObjectContext.tbUom).ToList
        Me.TbUomBindingSource.DataSource = _res
    End Sub


#End Region

#End Region

#Region "Обслуживание формы"
    ''' <summary>
    ''' Нажатие кнопки ПИН
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btPin_Click(sender As Object, e As EventArgs) Handles btPin.Click
        If Me.tbPin.Text.Length = 4 Then
            Dim _pin = Me.tbPin.Text
            'пинкод введен
            LockCtl()
            Me.tbPin.Text = _pin
            Me.CheckPin(sender, e)
            Return
        End If

        Me.tbPin.Text = ""
        Me.TopMost = False
        CType(clsApplicationTypes.GetDigiKeyBoardForm, Object).connect(Me.tbPin, 0, "Ok")
        Me.Refresh()
        Me.CheckPin(sender, e)
        'добавление вкладок в CheckPermissions() стр 24
    End Sub


    ''' <summary>
    ''' статус подключения - отображение
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub lbConnectStatus_TextChanged(sender As Object, e As EventArgs) Handles lbConnectStatus.TextChanged
        Select Case lbConnectStatus.Text
            Case "offline"
                lbConnectStatus.BackColor = Drawing.Color.Red
                Me.tbctlMain.Enabled = False
            Case "online"
                lbConnectStatus.BackColor = Drawing.Color.Green
                Me.tbctlMain.Enabled = True
        End Select
    End Sub

    Private Sub LockCtl()
        clsApplicationTypes.CurrentUser = Nothing
        ClsUserBindingSource.DataSource = GetType(clsUser)
        ClsUserBindingSource.ResetBindings(False)
        Me.oUserActivity = 0

        For Each _clt As Windows.Forms.Control In Me.Controls
            _clt.Enabled = False
            _clt.Refresh()
        Next
        Me.WTimeSummary_ResultBindingSource.DataSource = Nothing
        Me.WSalaryInfo_ResultBindingSource.DataSource = Nothing
        Me.WInOffice_ResultBindingSource.DataSource = Nothing
        Me.tbPin.Enabled = True
        Me.gbSelectEmployee.Visible = False
        Me.tbEmployeeSum.Text = ""
        Me.lbWokername.Text = "Введите ПИН"
        Me.lbConnectStatus.Enabled = True
        Me.lbCurrentTime.Enabled = True
        Me.tbPin.Text = ""
        Me.btPin.Enabled = True
        Me.gbCorrectionwTime.Enabled = False
        Me.rbCorrectEndwtime.Checked = False
        Me.rbCorrectBeginwTime.Enabled = True
        Me.btUserCorrect.Enabled = False
        Me.btAddWRecord.Enabled = False
        Me.btRemoveWRecord.Enabled = False
        Me.btPaySalary.Enabled = False
        Me.DateTimePicker_salary.Enabled = False
        Me.DateTimePicker_salary.Value = Now

        Me.tbctlMain.TabPages.Clear()
        Me.tbctlMain.TabPages.Add(Me.tpTime)
        Me.btPin.Focus()
        Me.lbxCurrentUserOperation.DataSource = Nothing

        Me.Uc_trilbone_history1.clear()

        'Me.btScannerON.Enabled = False
        'Me.btRestartRFID.Enabled = False

        Me.TopMost = True

#If DEBUG Then
#Else
   AddHandler Me.Move, AddressOf fmWtime_Move
#End If

        Me.MinimizeBox = False
        Me.Location = New Drawing.Point(0, 0)
        Me.Focus()
    End Sub

    Private Sub UnLockCtl()
        For Each ctl As Windows.Forms.Control In Me.Controls
            ctl.Enabled = True
        Next
        Me.btScannerON.Enabled = True
        Me.btRestartRFID.Enabled = True
        Me.btStartSampleOperation.Enabled = True

        Me.btSuspendSampleOperation.Enabled = False
        Me.btStopSampleOperation.Enabled = False
        Me.btAddNewInCurrentLot.Enabled = False
        Me.btPhotoSample.Enabled = False
    End Sub

    ''' <summary>
    ''' выход регистратора
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btSingOut_Click(sender As Object, e As EventArgs) Handles btSingOut.Click
        LockCtl()
    End Sub

    ''' <summary>
    ''' отображает статус пользователя
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ShowUserStatus() As clsSampleDataManager.emWTimeOperation
        '_splash.Show()
        '_splash.Refresh()
        Select Case clsApplicationTypes.CurrentUser.CurrentStatus
            Case clsSampleDataManager.emWTimeOperation.BeginOnWork
                'на работе
                Me.btStartWork.Enabled = False
                Me.btSuspendWork.Enabled = True
                Me.btStopWork.Enabled = True
                Me.TableLayoutPanel_operations.Enabled = True
            Case clsSampleDataManager.emWTimeOperation.EndWork
                Me.btStartWork.Enabled = True
                Me.btSuspendWork.Enabled = False
                Me.btStopWork.Enabled = False
                Me.TableLayoutPanel_operations.Enabled = False
            Case clsSampleDataManager.emWTimeOperation.SuspendWork
                Me.btStartWork.Enabled = True
                Me.btSuspendWork.Enabled = False
                Me.btStopWork.Enabled = False
                Me.TableLayoutPanel_operations.Enabled = False
            Case clsSampleDataManager.emWTimeOperation.NoStatus
                Me.btStartWork.Enabled = True
                Me.btSuspendWork.Enabled = True
                Me.btStopWork.Enabled = True
                Me.TableLayoutPanel_operations.Enabled = True
        End Select
        '_splash.Hide()
        Return clsApplicationTypes.CurrentUser.CurrentStatus
    End Function

    ''' <summary>
    ''' запрет движения формы
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub fmWtime_Move(sender As Object, e As EventArgs)
        Me.Location = New Drawing.Point(0, 0)
    End Sub

#End Region

#Region "Регистрация времени"
    ''' <summary>
    ''' Начать работу
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btStartWork_Click(sender As Object, e As EventArgs) Handles btStartWork.Click
        btStartWork.Enabled = False
        If clsApplicationTypes.GetAccess("напомнить о уборке") Then
            'проверить статус уборки
            Select Case clsApplicationTypes.CurrentUser.GetClearStatus
                Case <= 0
                    'все хорошо, не оповещать
                Case 1
                    'есть косяк
                    MsgBox("Просьба убрать рабочее место, а также свой мусор и предметы с общественных мест!", vbInformation, "повторное напоминание")
                Case Else
                    'халатное напоминание
                    MsgBox("Убери свое рабочее место, а также свой мусор и предметы с общественных мест!", vbInformation, "повторное напоминание")
            End Select

        End If
        If clsApplicationTypes.CurrentUser.StartWork() Then
            clsApplicationTypes.BeepYES()
        Else
            clsApplicationTypes.BeepNOT()
            btStartWork.Enabled = True
        End If
        ShowUserStatus()
    End Sub

    ''' <summary>
    ''' приостанавливает все запищенные операции
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SuspendAllOperation()
        For Each t As tbSMOperation.clsSMoperation In Me.lbxCurrentUserOperation.Items
            If t.ID > 0 Then
                If clsApplicationTypes.CurrentUser.GetOperationStatus(t.ID) = clsSampleDataManager.emWTimeOperation.BeginOnWork Then
                    clsApplicationTypes.CurrentUser.SuspendOperation(t.ID)
                End If
            End If
        Next
        RefreshLotList()
    End Sub


    ''' <summary>
    ''' окончить работу
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btStopWork_Click(sender As Object, e As EventArgs) Handles btStopWork.Click
        'предупреждение об уборке
        If clsApplicationTypes.GetAccess("напомнить о уборке") Then
            Select Case MsgBox("Рабочее место убрано. Свой мусор и предметы убраны с общественных мест. Верно?", vbYesNo, "Вопрос-напоминание")
                Case vbYes
                    'хорошо
                Case vbNo
                    'нет
                    MsgBox("Просим убрать места не позднее завтрашнего дня.", vbOKOnly, "напоминание")
                    'запись в БД о косяке - отказе от уборки
                    clsApplicationTypes.CurrentUser.ClearOff()
            End Select
        End If

        btStopWork.Enabled = False
        If clsApplicationTypes.CurrentUser.StopWork() Then
            SuspendAllOperation()
            clsApplicationTypes.BeepYES()
        Else
            clsApplicationTypes.BeepNOT()
            btStopWork.Enabled = True
        End If
        ShowUserStatus()
    End Sub

    ''' <summary>
    ''' Приостановить работу
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btSuspendWork_Click(sender As Object, e As EventArgs) Handles btSuspendWork.Click
        btSuspendWork.Enabled = False
        If clsApplicationTypes.CurrentUser.SuspendWork() Then
            SuspendAllOperation()
            clsApplicationTypes.BeepYES()
        Else
            clsApplicationTypes.BeepNOT()
            btSuspendWork.Enabled = True
        End If
        ShowUserStatus()
    End Sub

    ''' <summary>
    ''' кто в офисе
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btHwoInOffice_Click(sender As Object, e As EventArgs) Handles btHwoInOffice.Click
        Dim _res = (clsApplicationTypes.SampleDataObject.GetdbPhotoObjectContext.wInOffice(clsApplicationTypes.GetCurrentTime)).ToList

        If Not _res Is Nothing AndAlso _res.Count > 0 Then
            WInOffice_ResultBindingSource.DataSource = _res
            clsApplicationTypes.BeepYES()
        Else
            WInOffice_ResultBindingSource.DataSource = Nothing
            clsApplicationTypes.BeepNOT()
        End If
        Me.WInOffice_ResultDataGridView.Refresh()

    End Sub

    ''' <summary>
    ''' Мое время
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btGetMyTime_Click(sender As Object, e As EventArgs) Handles btGetMyTime.Click
        If Me.gbSelectEmployee.Visible = True Then
            If Not Me.cbEmployee.SelectedValue = clsApplicationTypes.CurrentUser.Employee.ID Then
                Me.cbEmployee.SelectedValue = clsApplicationTypes.CurrentUser.Employee.ID
                Return
            End If
        End If
        ReadSalary(clsApplicationTypes.CurrentUser.Employee.ID)
    End Sub
#End Region

#Region "Регистрация лотов и образцов"

    ''' <summary>
    ''' обновит визуальный список операций работника
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RefreshLotList()
        Dim _list As New List(Of tbSMOperation.clsSMoperation)
        _list.Add(tbSMOperation.clsSMoperation.Empty)
        _list.AddRange(clsApplicationTypes.CurrentUser.OperationOnWork.Select(Function(x) x.GetShotClass).ToList)
        Me.lbxCurrentUserOperation.DataSource = _list
    End Sub


    ''' <summary>
    ''' получить рабочий номер
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btCreateSchema_Click(sender As Object, e As EventArgs) Handles btCreateSchema.Click
        'получить рабочий номер
        Dim _res = clsApplicationTypes.SampleDataObject.GetNewNumberBySeries("901")
        Dim _num = clsApplicationTypes.clsSampleNumber.CreateFromString(_res)
        If Not _num.CodeIsCorrect Then
            MsgBox("Не удалось получить рабочий номер, повторите.", vbCritical)
            Return
        End If

        Me.TbSMLotBindingSource.DataSource = Me.CreateSchema(GetNumberType:=2, SchemeNumber:=_num)

    End Sub

    ''' <summary>
    ''' зарегить готовую схему
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btRegisterSchema_Click(sender As Object, e As EventArgs) Handles btRegisterSchema.Click
        If String.IsNullOrEmpty(Me.tbSchemeNumber.Text) Then
            MsgBox("Надо ввести номер", vbCritical)
            Return
        End If
        'зарегить готовую схему
        Dim _num = clsApplicationTypes.clsSampleNumber.CreateFromString(Me.tbSchemeNumber.Text)
        If (_num Is Nothing) OrElse Not _num.CodeIsCorrect Then
            clsApplicationTypes.BeepNOT()
            Me.tbSchemeNumber.Focus()
        End If

        Me.TbSMLotBindingSource.DataSource = Me.CreateSchema(GetNumberType:=3, SchemeNumber:=_num)

    End Sub

    ''' <summary>
    ''' есть номер (не схема)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btRegisterNumber_Click(sender As Object, e As EventArgs) Handles btClear.Click
        Me.Clear_forNewSample()
    End Sub


    Private Sub btWithoutNumber_Click(sender As Object, e As EventArgs) Handles btWithoutNumber.Click
        Me.TbSMLotBindingSource.DataSource = CreateSchema(GetNumberType:=4, SchemeNumber:=Nothing)
    End Sub


    ''' <summary>
    ''' создает обьект лот и привязывает к контексту. Изменяет текущий биндинг для лота.
    ''' </summary>
    ''' <param name="GetNumberType"></param>
    ''' <param name="SchemeNumber"></param>
    ''' <remarks></remarks>
    Private Function CreateSchema(GetNumberType As Integer, SchemeNumber As clsApplicationTypes.clsSampleNumber) As tbSMLot
        'создать обьект Лота tbSMLot (по умолчанию - одиночный камень)
        If SchemeNumber Is Nothing OrElse Not SchemeNumber.CodeIsCorrect Then
            GoTo newobj
        End If
        'запрос - получить схему по номеру из БД
        Dim _exist = clsApplicationTypes.SampleDataObject.GetdbPhotoObjectContext.tbSMLot.Where(Function(x) x.LotNumber = SchemeNumber.ShotCode).FirstOrDefault


        If Not _exist Is Nothing Then
            If _exist.AccountingComplete Then
                MsgBox(String.Format("Учет номера {0} завершен. Возмите другую схему.", SchemeNumber.ShotCode), vbCritical)
                Return Nothing
            End If
            clsApplicationTypes.BeepYES()
            Return _exist
        End If

newobj:  'GetNumberType = метод выдачи номера ID
        Dim _newobj = Service.tbSMLot.CreatetbSMLot(0, GetNumberType, 1)
        With _newobj
            'Учет завершен
            .AccountingComplete = False

            'номер лота
            If SchemeNumber Is Nothing OrElse SchemeNumber.CodeIsCorrect = False Then
                .LotNumber = "без номера"
            Else
                .LotNumber = SchemeNumber.ShotCode
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
        '--------
        clsApplicationTypes.BeepYES()
        Return _newobj
    End Function


    ''' <summary>
    ''' создает операцию, привязывает ее к текущему лоту и добавляет в контекст
    ''' </summary>
    ''' <param name="WorkOperation"></param>
    ''' <param name="PaymentType"></param>
    ''' <remarks></remarks>
    Private Sub CreateOperation(WorkOperation As Integer, PaymentType As Integer)
        Dim _lot As Service.tbSMLot = Me.TbSMLotBindingSource.Current
        If _lot Is Nothing Then
            MsgBox("Обьект Лот пуст. Невозможно создать операцию. Обратитесь к разработчику", vbCritical)
            Return
        End If


        'WorkOperation рабочая операция ID
        'PaymentType тип оплаты ID

        Dim _res = (From c As tbSMOperation In Me.TbSMOperationBindingSource Where c.SMWorkOperationID = WorkOperation).Count

        If _res > 0 And Not WorkOperation = 1 Then
            'запретить добавление одинаковых операций, кроме описываемых в примечании
            MsgBox("Добавляемая операция уже существует для данного номера", vbCritical)
            Return
        End If

        Dim _newobj = tbSMOperation.CreatetbSMOperation(WorkOperation, PaymentType, 0)
        With _newobj
            'учетное кол-во ОПЕРАЦИЙ
            .AccuntingQty = 1

            'сумма назначена
            .amountsetbyadmin = clsApplicationTypes.CurrentUser.Employee.Tariff

            'сумма запрошена
            .amountsetbywoker = 0

            .Currency = clsApplicationTypes.CurrentUser.Employee.Currency

            'оплата изменена на запрошенную
            .getwokeramount = False

            'есть сообщения флаг
            .HasMessages = False

            'оплачено
            .paid = False

            'примечание
            .Remark = ""

            'время назначено (часы)
            .timesetbyadmin = 0

            'время запрошено (часы)
            .timesetbywoker = 0

            'ед измерения ID ОПЕРАЦИЙ
            'штуки - ВСЕГДА (штук операций)
            .uomID = 2

            '.paiddate
            '.QualityID
        End With

        'создать запись в tbSMLotOperation
        Dim _newobj2 = tbSMLotOperation.CreatetbSMLotOperation(0, 0, 0)

        'привязка к лоту
        _lot.tbSMLotOperation.Add(_newobj2)

        'привязка к операции
        _newobj.tbSMLotOperation.Add(_newobj2)

        'привязать к контексту
        clsApplicationTypes.SampleDataObject.GetdbPhotoObjectContext.AddTotbSMOperation(_newobj)
        GetOperationForCurrentLot()
        lbxOperations.SelectedIndex = lbxOperations.Items.Count - 1

        If WorkOperation = 1 Then
            Me.rtbOperationComment.Focus()
        End If
        clsApplicationTypes.BeepYES()
    End Sub

    ''' <summary>
    ''' прочтет все операции для текущего лота
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub GetOperationForCurrentLot()
        Dim _lot As Service.tbSMLot = Me.TbSMLotBindingSource.Current
        If _lot Is Nothing Then Return
        'загрузка операций для данного лота
        Dim _list As New List(Of Service.tbSMOperation)
        'запрос
        If Not (_lot.EntityState = Data.EntityState.Detached Or _lot.EntityState = Data.EntityState.Added) Then
            _lot.tbSMLotOperation.Load(Data.Objects.MergeOption.AppendOnly)
        End If
        For Each t In _lot.tbSMLotOperation
            'проверить резерв операции в рабочем цикле
            'TODO запрос к таблице tbSMTime
            'по ID операции - если есть в таблице, то не включать в список
            _list.Add(t.tbSMOperation)
        Next

        If _list.Count > 0 Then
            'есть операции доступные для взятия в работу
            'включить в список
            Me.TbSMOperationBindingSource.DataSource = _list
            Me.lbOperationWarning.Text = "Всего операций: " & _list.Count & "  (dblclick прим.)"
            Me.btStartOperation.Enabled = True

            '--------------
            Me.tcSampleParam.Enabled = True
            If Not Me.tcSampleParam.TabPages.Contains(Me.tpOperationParam) Then
                Me.tcSampleParam.TabPages.Add(Me.tpOperationParam)
            End If
            If Not Me.tcSampleParam.TabPages.Contains(Me.tpExpeditionParam) Then
                Me.tcSampleParam.TabPages.Add(Me.tpExpeditionParam)
            End If


            'запрос разрешений
            If clsApplicationTypes.GetAccess("Установка размера оплаты за образец") Then
                If Not Me.tcSampleParam.TabPages.Contains(Me.tpOperationPayment) Then
                    Me.tcSampleParam.TabPages.Add(Me.tpOperationPayment)
                End If
            End If
            '---------------

        Else
            'операций нет
            Me.lbOperationWarning.Text = "Нет операций. <создать>"
            Me.btStartOperation.Enabled = False
            Me.lbOperationPayment.Text = ""
            Me.tcSampleParam.Enabled = True
            Me.btCreateOperation.Enabled = True

        End If


    End Sub

    ''' <summary>
    ''' смена лота
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TbSMLotBindingSource_CurrentItemChanged(sender As Object, e As EventArgs) Handles TbSMLotBindingSource.CurrentItemChanged
        If Me.TbSMLotBindingSource.DataSource Is Nothing Then
            Me.TbSMLotBindingSource.DataSource = GetType(tbSMLot)
        End If
        Dim _lot As Service.tbSMLot = Me.TbSMLotBindingSource.Current

        If _lot Is Nothing Then
            Me.btSaveLot.Enabled = False
            Me.btPrintNumberLabel2.Enabled = False
            Me.btResetPrinter2.Enabled = False
            Me.btWithoutNumber.Enabled = True
            Me.btCreateSchema.Enabled = True
            Me.btRegisterSchema.Enabled = True
            Return
        End If


        Me.btSaveLot.Enabled = True
        Me.btPrintNumberLabel2.Enabled = True
        Me.btResetPrinter2.Enabled = True

        Me.btRegisterSchema.Enabled = False
        Me.btWithoutNumber.Enabled = False
        Me.btCreateSchema.Enabled = False

        If _lot.SMLotTypeID = 1 Then
            Me.rbSingleSample.Checked = True
        End If

        If _lot.SMLotTypeID = 2 Then
            Me.rbLotSample.Checked = True
        End If

        GetOperationForCurrentLot()

    End Sub


    ''' <summary>
    ''' изменения в текущем Operation
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TbSMOperationBindingSource_CurrentChanged(sender As Object, e As EventArgs) Handles TbSMOperationBindingSource.CurrentChanged
        Dim _op As tbSMOperation = lbxOperations.SelectedItem
        If _op Is Nothing Then
            Me.lbOperationPayment.Text = ""
            Return
        End If

        'метка оплаты
        Dim _message As String = "Оплата: "
        _message += _op.tbSMPaymentType.Name
        If _op.amountsetbyadmin > 0 Then
            _message += " - " & _op.amountsetbyadmin & " " & _op.Currency
        End If
        'тип оплаты
        Select Case _op.SMPaymentTypeID
            Case 1
                'почасовая
                rbPerHour.Checked = True
                If _op.amountsetbyadmin > 0 Then
                    _message += " (в час)"
                End If
            Case 2
                'сделка
                Me.rbSumma.Checked = True
                If _op.amountsetbyadmin > 0 Then
                    _message += " (всего)"
                End If
            Case 3
                'тариф
                Me.rbTariff.Checked = True
                If _op.amountsetbyadmin > 0 Then
                    _message += " (по тарифу " & _op.tbSMTariff.Amount & " за 1 " & _op.tbSMTariff.AccountingUnit & ")"

                End If
            Case Else
                MsgBox("Обработка типа оплаты >3 не задана", vbCritical)
                Return
        End Select

        Me.lbOperationPayment.Text = _message
    End Sub


    ''' <summary>
    ''' переключить на ввод примечания
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub lbxOperations_MouseDoubleClick(sender As Object, e As Windows.Forms.MouseEventArgs) Handles lbxOperations.MouseDoubleClick
        Me.tcSampleParam.SelectedTab = Me.tpOperationParam
        Me.rtbOperationComment.Focus()
    End Sub

    ''' <summary>
    ''' удалить операцию
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub lbxOperations_MouseDown(sender As Object, e As Windows.Forms.MouseEventArgs) Handles lbxOperations.MouseDown
        Dim _op As tbSMOperation = lbxOperations.SelectedItem
        Dim _lot As tbSMLot = TbSMLotBindingSource.Current
        If _op Is Nothing Then Return
        If _lot Is Nothing Then Return

        If e.Button = Windows.Forms.MouseButtons.Right Then
            'удалить операцию
            If _op.EntityState = Data.EntityState.Added Then
                _lot.tbSMLotOperation.Remove(_op.tbSMLotOperation(0))
                _op.tbSMLotOperation.Clear()
                Me.TbSMOperationBindingSource.Remove(_op)
                GetOperationForCurrentLot()
            Else
                MsgBox("Удалить операцию невозможно - есть регистрация в БД", vbCritical)
            End If

        End If
    End Sub


    ''' <summary>
    ''' выбор имеющейся операции из списка
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub lbxOperations_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbxOperations.SelectedIndexChanged
        Dim _op As tbSMOperation = lbxOperations.SelectedItem
        If _op Is Nothing Then
            Me.lbOperationPayment.Text = ""
            Return
        End If

        Me.btStartOperation.Enabled = True

        If Not Me.tcSampleParam.TabPages.Contains(tpOperationParam) Then
            Me.tcSampleParam.TabPages.Add(tpOperationParam)
        End If

        'управление ЭУ
        'разрешить редактирование для админов.
        'метка оплаты
        Dim _message As String = ""
        _message += _op.tbSMPaymentType.Name
        If _op.amountsetbyadmin > 0 Then
            _message += " - " & _op.amountsetbyadmin & " " & _op.Currency
        End If
        'тип оплаты
        Select Case _op.SMPaymentTypeID
            Case 1
                'почасовая
                rbPerHour.Checked = True
                If _op.amountsetbyadmin > 0 Then
                    _message += " (в час)"
                    If Not Me.tbAdminHourPay.Text = "" AndAlso CType(Me.tbAdminHourPay.Text, Decimal) > 0 Then
                        _message += " надо уложиться в " & Me.tbAdminHourPay.Text & " час."
                    End If
                End If
            Case 2
                'сделка
                Me.rbSumma.Checked = True
                If _op.amountsetbyadmin > 0 Then
                    _message += " (всего)"
                End If
            Case 3
                'тариф
                Me.rbTariff.Checked = True
                If _op.amountsetbyadmin > 0 Then
                    If Not _op.tbSMTariff Is Nothing Then
                        _message += " (по тарифу " & _op.tbSMTariff.Amount & " за 1 " & _op.tbSMTariff.AccountingUnit & ")"
                    Else
                        _message = "невозможно посчитать тариф"
                    End If

                End If
            Case Else
                MsgBox("Обработка типа оплаты >3 не задана", vbCritical)
                Return
        End Select

        Me.lbOperationPayment.Text = _message
    End Sub

    ''' <summary>
    ''' создать операцию
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btCreateOperation_Click(sender As Object, e As EventArgs) Handles btCreateOperation.Click
        ClearNewOperation()
        'почасовая препарация полностью
        Me.CreateOperation(WorkOperation:=1, PaymentType:=1)
    End Sub


    ''' <summary>
    ''' очистка ресурсов перед новым образцом
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Clear_forNewSample()
        Me.TbSMOperationBindingSource.DataSource = GetType(tbSMOperation)
        Me.TbSMLotBindingSource.DataSource = GetType(tbSMLot)
        Me.btRegisterSchema.Enabled = False
        Me.btWithoutNumber.Enabled = True
        Me.btCreateSchema.Enabled = True

        '--------------
        Me.btSaveLot.Enabled = False
        Me.btPrintNumberLabel2.Enabled = False
        Me.btResetPrinter2.Enabled = False
        '------------------------------
        Me.tcSampleParam.Enabled = False
        If Me.tcSampleParam.TabPages.Contains(Me.tpExpeditionParam) Then
            Me.tcSampleParam.TabPages.Remove(Me.tpExpeditionParam)
        End If
        If Me.tcSampleParam.TabPages.Contains(Me.tpOperationParam) Then
            Me.tcSampleParam.TabPages.Remove(Me.tpOperationParam)
        End If
        If Me.tcSampleParam.TabPages.Contains(Me.tpOperationPayment) Then
            Me.tcSampleParam.TabPages.Remove(Me.tpOperationPayment)
        End If
        '--------------------
        Me.tbSumByWoker.Enabled = False
        Me.tbHourByWorker.Enabled = False
        Me.lbOperationWarning.Text = "Нет операций"
    End Sub

    ''' <summary>
    ''' очистка ресурсов перед новой операцией
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ClearNewOperation()
        Me.tbSumByWoker.Enabled = False
        Me.tbHourByWorker.Enabled = False
        If Not Me.tcSampleParam.TabPages.Contains(tpOperationParam) Then
            Me.tcSampleParam.TabPages.Add(tpOperationParam)
            tpOperationParam.Focus()
        End If
    End Sub

    ''' <summary>
    ''' запустить время на операцию
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btStartSample_Click(sender As Object, e As EventArgs) Handles btStartOperation.Click
        Dim _op As tbSMOperation = Me.TbSMOperationBindingSource.Current
        If _op Is Nothing Then Return
        'запустить время на камень
        'сохранить операцию
        Dim _oldID = _op.ID
        clsApplicationTypes.SampleDataObject.SavePhotoObjectContext()


        'если тут помяняется ID значит все ок
        If _oldID = 0 AndAlso _op.ID = _oldID Then
            MsgBox("ID " & _oldID & " операции не изменился! Не прошло обновление БД?", vbCritical)
            Return
        End If

        'регистрация операции
        clsApplicationTypes.CurrentUser.StartOperation(_op.ID)


        'обновить список операций
        Me.RefreshLotList()
        Dim _res = (From c In Me.lbxCurrentUserOperation.Items Where c.ID = _op.ID Select c).FirstOrDefault
        If Not _res Is Nothing Then
            Me.lbxCurrentUserOperation.SelectedItem = _res
        Else
            MsgBox("Операция ID " & _oldID & " не появилась после запроса! Не прошло обновление БД?", vbCritical)
            Return
        End If


        'рассмотреть вариант переключения вкладок пользователем

        Clear_forNewSample()

        If Me.tbctlMain.TabPages.Contains(Me.tpNewSample) Then
            Me.tbctlMain.TabPages.Remove(Me.tpNewSample)
        End If
        Me.tbctlMain.SelectTab(Me.tpTime)
        Me.lbxCurrentUserOperation.Focus()
    End Sub


    ''' <summary>
    ''' тип лота - одиночный камень
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub rbSingleSample_CheckedChanged(sender As Object, e As EventArgs) Handles rbSingleSample.CheckedChanged
        Dim _lot As Service.tbSMLot = Me.TbSMLotBindingSource.Current
        If _lot Is Nothing Then Return

        If rbSingleSample.Checked Then
            Me.tbQtyInLot.Enabled = False
            Me.cbUom.Enabled = False
            _lot.SMLotTypeID = 1
        End If

    End Sub


    ''' <summary>
    ''' тип лота - лот из образцов
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub rbLotSample_CheckedChanged(sender As Object, e As EventArgs) Handles rbLotSample.CheckedChanged
        Dim _lot As Service.tbSMLot = Me.TbSMLotBindingSource.Current
        If _lot Is Nothing Then Return
        If rbLotSample.Checked Then
            Me.tbQtyInLot.Enabled = True
            Me.cbUom.Enabled = True
            _lot.SMLotTypeID = 2
            _lot.qty = Me.tbQtyInLot.Text
            If Not Me.cbUom.SelectedIndex < 0 Then
                _lot.uomID = Me.cbUom.SelectedValue
            End If
        End If

    End Sub
    ''' <summary>
    ''' (создать новый)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btAddNewSample_Click(sender As Object, e As EventArgs) Handles btAddNewSample.Click
        Me.oUserActivity = -1
        'новый камень
        If Not Me.tbctlMain.TabPages.Contains(Me.tpNewSample) Then
            Me.tbctlMain.TabPages.Add(Me.tpNewSample)
        End If
        Me.tbctlMain.SelectTab(Me.tpNewSample)

        'работа с вкладкой Новый
        Clear_forNewSample()
        Me.btCreateSchema.Focus()
    End Sub
    ''' <summary>
    ''' запустить время на образец 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btGetNewSample_Click(sender As Object, e As EventArgs) Handles btStartSampleOperation.Click
        If Me.lbConnectStatus.Text = "offline" Then Return
        If Me.lbxCurrentUserOperation.SelectedIndex < 1 Then Return

        Me.oUserActivity = -1
        'включить время на камень по номеру
        Dim _opId = Me.lbxCurrentUserOperation.SelectedItem.ID
        clsApplicationTypes.CurrentUser.StartOperation(_opId)
        RefreshLotList()
        Dim _res = (From c In Me.lbxCurrentUserOperation.Items Where c.ID = _opId Select c).FirstOrDefault
        Me.lbxCurrentUserOperation.SelectedItem = _res
    End Sub


    ''' <summary>
    ''' смена ед. изм. лота
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cbUom_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbUom.SelectedIndexChanged
        If Me.TbSMLotBindingSource.Current Is Nothing Then Return
        Dim _lot As Service.tbSMLot = Me.TbSMLotBindingSource.Current
        If cbUom.SelectedIndex < 0 Then Return
        _lot.uomID = cbUom.SelectedValue
    End Sub


    ''' <summary>
    ''' выбор камня лузером
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub lbxWokerSamples_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbxCurrentUserOperation.SelectedIndexChanged
        If clsApplicationTypes.CurrentUser Is Nothing Then Return
        If clsApplicationTypes.CurrentUser.CurrentStatus = clsSampleDataManager.emWTimeOperation.NoStatus Or clsApplicationTypes.CurrentUser.CurrentStatus = clsSampleDataManager.emWTimeOperation.NotConnected Then
            Return
        End If
        If lbxCurrentUserOperation.SelectedIndex < 0 Then Return

        If lbxCurrentUserOperation.SelectedIndex = 0 Then
            'выбран новый камень
            Me.btAddNewSample.Enabled = True
            Me.btStartSampleOperation.Enabled = False
            Me.btSuspendSampleOperation.Enabled = False
            Me.btStopSampleOperation.Enabled = False
            Me.btAddNewInCurrentLot.Enabled = False
            Me.btPhotoSample.Enabled = False
            Me.btEditOperation.Enabled = False
            'и все))
            Return
        End If

        Me.btAddNewSample.Enabled = False
        Me.btEditOperation.Enabled = True
        'проверка статуса образца (как время)  и управление кнопками
        Me.btPhotoSample.Enabled = True
        Dim _SMOperationID As Integer = lbxCurrentUserOperation.SelectedItem.ID
        Select Case clsApplicationTypes.CurrentUser.GetOperationStatus(_SMOperationID)
            Case clsSampleDataManager.emWTimeOperation.BeginOnWork
                'образец в работе
                Me.btStartSampleOperation.Enabled = False
                Me.btSuspendSampleOperation.Enabled = True
                Me.btStopSampleOperation.Enabled = True
                Me.btAddNewInCurrentLot.Enabled = True
            Case clsSampleDataManager.emWTimeOperation.EndWork, clsSampleDataManager.emWTimeOperation.SalaryStopLine
                'образец закончен
                'повтор???
                Me.btStartSampleOperation.Enabled = False
                Me.btSuspendSampleOperation.Enabled = False
                Me.btStopSampleOperation.Enabled = False
                Me.btAddNewInCurrentLot.Enabled = False
            Case clsSampleDataManager.emWTimeOperation.NoStatus, clsSampleDataManager.emWTimeOperation.NotConnected
                'видимо нет подключения
                Me.btStartSampleOperation.Enabled = False
                Me.btSuspendSampleOperation.Enabled = False
                Me.btStopSampleOperation.Enabled = False
                Me.btAddNewInCurrentLot.Enabled = False
            Case clsSampleDataManager.emWTimeOperation.SuspendWork
                'образец приостановлен
                Me.btStartSampleOperation.Enabled = True
                Me.btSuspendSampleOperation.Enabled = False
                Me.btStopSampleOperation.Enabled = True
                Me.btAddNewInCurrentLot.Enabled = False
        End Select
    End Sub

    ''' <summary>
    ''' сохранить лот и продалжить оформление лотов
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btSaveLot_Click(sender As Object, e As EventArgs) Handles btSaveLot.Click
        'сохранить в БД и продолжить оформление
        If clsApplicationTypes.SampleDataObject.SavePhotoObjectContext() > 0 Then
            clsApplicationTypes.BeepYES()
        End If
        ' Clear_forNewSample()
    End Sub



    ''' <summary>
    ''' оплата - повременная, установить требуемое время (админ)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub rbPerHour_CheckedChanged(sender As Object, e As EventArgs) Handles rbPerHour.CheckedChanged
        Dim _op As tbSMOperation = lbxOperations.SelectedItem
        If _op Is Nothing Then Return
        If rbPerHour.Checked Then
            _op.SMPaymentTypeID = 1
            _op.amountsetbyadmin = clsApplicationTypes.CurrentUser.Employee.Tariff
            cbCurrencyOperation.SelectedItem = clsApplicationTypes.CurrentUser.Employee.Currency
            Me.tbAdminHourPay.Enabled = True
            Me.cbTariff.Enabled = False
            _op.tbSMTariff = Nothing
            Me.tbAdminHourPay.Focus()
        End If

    End Sub
    ''' <summary>
    ''' оплата - сделка, установить сумму (админ)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub rbSumma_CheckedChanged(sender As Object, e As EventArgs) Handles rbSumma.CheckedChanged
        Dim _op As tbSMOperation = lbxOperations.SelectedItem
        If _op Is Nothing Then Return
        If rbSumma.Checked Then
            _op.SMPaymentTypeID = 2
            cbCurrencyOperation.SelectedItem = clsApplicationTypes.CurrentUser.Employee.Currency
            Me.tbAdminHourPay.Enabled = False
            Me.cbTariff.Enabled = False

            _op.timesetbyadmin = 0
            _op.tbSMTariff = Nothing
            Me.tbAdminSumPay.Focus()
        End If

    End Sub



    ''' <summary>
    ''' оплата - тариф, выбрать тариф (админ)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub rbTariff_CheckedChanged(sender As Object, e As EventArgs) Handles rbTariff.CheckedChanged
        Dim _op As tbSMOperation = lbxOperations.SelectedItem
        If _op Is Nothing Then Return
        If rbTariff.Checked Then
            _op.SMPaymentTypeID = 3
            Me.tbAdminHourPay.Enabled = False
            Me.cbTariff.Enabled = True
            _op.timesetbyadmin = 0
            Me.cbTariff.Focus()
        End If
    End Sub

    ''' <summary>
    ''' выбор тарифа
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cbTariff_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbTariff.SelectedIndexChanged
        Dim _op As tbSMOperation = lbxOperations.SelectedItem
        Dim _tar As tbSMTariff = cbTariff.SelectedItem
        If _op Is Nothing Then Return
        If _tar Is Nothing Then Return
        If rbTariff.Checked Then
            _op.amountsetbyadmin = _tar.Amount
            _op.Currency = _tar.Currency
            _op.tbSMTariff = _tar
        End If
    End Sub


    ''' <summary>
    ''' оплата - повременная (работник)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub rbWokerPerHour_CheckedChanged(sender As Object, e As EventArgs) Handles rbWokerPerHour.CheckedChanged
        Dim _op As tbSMOperation = lbxOperations.SelectedItem
        If _op Is Nothing Then Return
        If rbWokerPerHour.Checked Then
            Me.tbSumByWoker.Enabled = False
            Me.tbHourByWorker.Enabled = True

        End If
    End Sub

    ''' <summary>
    ''' оплата - сделка (работник)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub rbWokerPerSumma_CheckedChanged(sender As Object, e As EventArgs) Handles rbWokerPerSumma.CheckedChanged
        Dim _op As tbSMOperation = lbxOperations.SelectedItem
        If _op Is Nothing Then Return
        If rbWokerPerSumma.Checked Then
            '  _op.SMPaymentTypeID = 1
            '_op.amountsetbyadmin = clsApplicationTypes.CurrentUser.Employee.Tariff
            'cbCurrencyOperation.SelectedItem = clsApplicationTypes.CurrentUser.Employee.Currency
            Me.tbSumByWoker.Enabled = True
            Me.tbHourByWorker.Enabled = False
        End If
    End Sub



    ''' <summary>
    ''' именение типа текущей операции
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub lbxWorkOperation_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbxWorkOperation.SelectedIndexChanged
        Dim _wop As tbSMWorkOperation = lbxWorkOperation.SelectedItem
        If _wop Is Nothing Then Return

        Dim _res = (From c As tbSMOperation In Me.TbSMOperationBindingSource Where c.SMWorkOperationID = _wop.ID Select c).Count
        If _res > 0 And Not _wop.ID = 1 And tcSampleParam.SelectedIndex = 1 Then
            'запретить добавление одинаковых операций, кроме описываемых в примечании
            MsgBox("Добавляемая операция уже существует для данного номера", vbCritical)
            lbxWorkOperation.SelectedIndex = 0
            Return
        End If
    End Sub

    ''' <summary>
    ''' приостановить образец
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btSuspendSampleOperation_Click(sender As Object, e As EventArgs) Handles btSuspendSampleOperation.Click
        If Me.lbConnectStatus.Text = "offline" Then Return
        If Me.lbxCurrentUserOperation.SelectedIndex < 0 Then Return

        Dim _opId = Me.lbxCurrentUserOperation.SelectedItem.ID
        clsApplicationTypes.CurrentUser.SuspendOperation(_opId)
        RefreshLotList()
        Dim _res = (From c In Me.lbxCurrentUserOperation.Items Where c.ID = _opId Select c).FirstOrDefault
        Me.lbxCurrentUserOperation.SelectedItem = _res
    End Sub





    ''' <summary>
    ''' добавить камень в лот
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btAddNewInCurrentLot_Click(sender As Object, e As EventArgs) Handles btAddNewInCurrentLot.Click
        If Me.lbConnectStatus.Text = "offline" Then Return
        If Me.lbxCurrentUserOperation.SelectedIndex < 0 Then Return
        Dim _opId = Me.lbxCurrentUserOperation.SelectedItem.ID


        Dim _clsnum = clsApplicationTypes.clsSampleNumber.CreateFromString(InputBox("Номер для добавления", "К лоту", ""))
        If _clsnum Is Nothing OrElse _clsnum.CodeIsCorrect = False Then
            Return
        End If

        If Not clsApplicationTypes.CurrentUser.AddInLot(Number:=_clsnum, SMOperationID:=_opId) Then
            MsgBox("Не удалось добавить в лот", vbCritical)
        Else
            MsgBox(String.Format("Образец {0} успешно добавлен к лоту {1}", _clsnum.ShotCode, Me.lbxCurrentUserOperation.SelectedItem.ToString))
        End If
    End Sub

    ''' <summary>
    ''' Сдать образец
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btStopSampleOperation_Click(sender As Object, e As EventArgs) Handles btStopSampleOperation.Click
        If Me.lbConnectStatus.Text = "offline" Then Return
        If Me.lbxCurrentUserOperation.SelectedIndex < 0 Then Return

        Dim _opId As Integer = Me.lbxCurrentUserOperation.SelectedItem.ID
        clsApplicationTypes.CurrentUser.StopOperation(_opId)
        RefreshLotList()
        Dim _res = (From c In Me.lbxCurrentUserOperation.Items Where c.ID = _opId Select c).FirstOrDefault
        Me.lbxCurrentUserOperation.SelectedItem = _res
    End Sub


#End Region

#Region "Корректировка времени"

    Private Sub WTimeSummary_ResultBindingSource_CurrentItemChanged(sender As Object, e As EventArgs) Handles WTimeSummary_ResultBindingSource.CurrentItemChanged
        'обработка эу корректировки
        If Not TypeOf WTimeSummary_ResultBindingSource.Current Is wTimeSummary_Result Then
            Return
        End If
        Dim _obj As wTimeSummary_Result = WTimeSummary_ResultBindingSource.Current
        If _obj Is Nothing Then Return

        Select Case clsApplicationTypes.GetAccess("Информация об операциях сотрудников")
            Case True
                Me.gbCorrectionwTime.Enabled = True
                Me.btUserCorrect.Enabled = True
                Me.btAddWRecord.Enabled = True
                Me.btRemoveWRecord.Enabled = True
                ''если отсутствует время окончанния (для текущих записей)
                'If _obj.EndTime Is Nothing Then
                '    Me.btUserCorrect.Enabled = False
                'Else
                '    Me.btUserCorrect.Enabled = True
                'End If
                Me.btUserCorrect.Enabled = True

                If rbCorrectBeginwTime.Checked Then
                    rbCorrectBeginwTime_CheckedChanged(sender, e)
                Else
                    rbCorrectBeginwTime.Checked = True
                End If
            Case Else
                Dim _current = Now
                Me.btAddWRecord.Enabled = False
                Me.btRemoveWRecord.Enabled = False
                If _obj.CalculateDay.Value.Month = _current.Month AndAlso (_obj.CalculateDay.Value.Day = _current.Day Or _obj.CalculateDay.Value.Day = _current.Day - 1) Then
                    'разрешить редактировать сегодня и вчера, но только окончание
                    Me.gbCorrectionwTime.Enabled = True
                    'если отсутствует время окончанния (для текущих записей)
                    If _obj.EndTime Is Nothing Then
                        Me.rbCorrectEndwtime.Enabled = False
                    Else
                        Me.rbCorrectEndwtime.Enabled = True
                        Me.rbCorrectEndwtime.Checked = True
                    End If

                    Me.rbCorrectBeginwTime.Enabled = False
                    Me.btUserCorrect.Enabled = True
                Else
                    Me.gbCorrectionwTime.Enabled = False
                    Me.btUserCorrect.Enabled = False
                End If
        End Select

    End Sub

    Private Sub rbCorrectBeginwTime_CheckedChanged(sender As Object, e As EventArgs) Handles rbCorrectBeginwTime.CheckedChanged
        Dim _obj As wTimeSummary_Result = WTimeSummary_ResultBindingSource.Current
        If _obj Is Nothing Then Return
        If _obj.CalculateDay Is Nothing Then
            _obj.CalculateDay = Now
        End If
        If _obj.StartTime Is Nothing Then
            _obj.StartTime = New TimeSpan(Now.Hour, Now.Minute, 0)
        End If



        If rbCorrectBeginwTime.Checked Then
            Dim _d = New Date(_obj.CalculateDay.Value.Year, _obj.CalculateDay.Value.Month, _obj.CalculateDay.Value.Day, _obj.StartTime.Value.Hours, _obj.StartTime.Value.Minutes, _obj.StartTime.Value.Seconds)
            Me.DateTimePicker_correctwTime.Value = _d
        End If

    End Sub

    Private Sub rbCorrectEndwtime_CheckedChanged(sender As Object, e As EventArgs) Handles rbCorrectEndwtime.CheckedChanged
        Dim _obj As wTimeSummary_Result = WTimeSummary_ResultBindingSource.Current
        If _obj Is Nothing Then Return
        If rbCorrectEndwtime.Checked Then
            If _obj.EndTime Is Nothing Then
                Me.btUserCorrect.Enabled = False
                _obj.EndTime = New TimeSpan(Now.Hour, Now.Minute, 0)
            Else
                Me.btUserCorrect.Enabled = True
            End If

            Dim _d = New Date(_obj.CalculateDay.Value.Year, _obj.CalculateDay.Value.Month, _obj.CalculateDay.Value.Day, _obj.EndTime.Value.Hours, _obj.EndTime.Value.Minutes, _obj.EndTime.Value.Seconds)
            Me.DateTimePicker_correctwTime.Value = _d

        End If

    End Sub

    ''' <summary>
    ''' Запрос корректировки
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btUserCorrect_Click(sender As Object, e As EventArgs) Handles btUserCorrect.Click
        Dim _corrcetobj As wTimeSummary_Result = WTimeSummary_ResultBindingSource.Current
        If _corrcetobj Is Nothing Then Return
        If _corrcetobj.EndTime.HasValue = False Then
            MsgBox("Корректировать возможно только закрытые записи!", vbCritical)
            Return
        End If

        Dim _day = _corrcetobj.CalculateDay.Value
        Dim _start = _corrcetobj.StartTime.Value
        Dim _end = _corrcetobj.EndTime.Value
        Dim _startDate = New Date(_day.Year, _day.Month, _day.Day, _start.Hours, _start.Minutes, _start.Seconds, 0)
        Dim _endDate = New Date(_day.Year, _day.Month, _day.Day, _end.Hours, _end.Minutes, _end.Seconds, 0)

        Dim _minusDay As Boolean = False
        Dim _deltaDay As Integer = 0
        If _corrcetobj.StartTime > _corrcetobj.EndTime Then
            'дело имеем с прыжком через ночь - забытая запись
            _minusDay = True
            _deltaDay += 1
        End If

        Dim _newDate = Me.DateTimePicker_correctwTime.Value

        Dim _oldDate As Date
        'проверка введенной даты
        If rbCorrectBeginwTime.Checked And _newDate > _endDate Then
            'начало не может быть позже окончания
            MsgBox("начало работы не может быть позже ее окончания!", vbCritical)
            Return
        End If

        If rbCorrectEndwtime.Checked And _newDate < _startDate Then
            'окончание не может быть раньше начала
            MsgBox("окончание работы не может быть раньше ее начала!", vbCritical)
            Return
        End If
changeDay:

        'вычислим корректируюемую дату
        'коррекция начала
        If rbCorrectBeginwTime.Checked Then
            _oldDate = New Date(_day.Year, _day.Month, _day.Day, _start.Hours, _start.Minutes, _start.Seconds, 0)
        End If

        'коррекция окончания
        If rbCorrectEndwtime.Checked Then
            If _minusDay Then
                _day = _day.AddDays(_deltaDay)
            End If
            _oldDate = New Date(_day.Year, _day.Month, _day.Day, _end.Hours, _end.Minutes, _end.Seconds, 0)
        End If

        'проверка равенства дат
        If _oldDate = _newDate Then
            MsgBox("Задайте время корректировки!", vbCritical)
            Return
        End If

        'подтверждение
        Select Case MsgBox(String.Format("Скорректировать запись {2} от {0} на новое значение {1}? Внимание! Отмена действия невозможна!", _oldDate.ToString("dd MMM HH:mm"), _newDate.ToString("dd MMM HH:mm"), If(rbCorrectBeginwTime.Checked = True, "НАЧАЛА работы", "ОКОНЧАНИЯ работы")), vbYesNo)
            Case MsgBoxResult.No
                Return
        End Select

        'корректировка
        '-------------
        Dim _userID As Integer
        If clsApplicationTypes.GetAccess("Информация об операциях сотрудников") Then
            _userID = Me.cbEmployee.SelectedValue
        Else
            _userID = clsApplicationTypes.CurrentUser.Employee.ID
        End If

        Dim _res = (clsApplicationTypes.SampleDataObject.GetdbPhotoObjectContext.wTimeCorrect(_userID, _oldDate, _newDate, clsApplicationTypes.GetCurrentTime))


        If _res = -1 Then
            Select Case MsgBox("Корректировка отметки " & _oldDate.ToShortDateString & " " & _oldDate.ToShortTimeString & " не прошла. Возможно, запись уже была скорректирована ранее или время записи относится к сегодняшнему дню. Увеличить дату поиска записи для корректировки на один день (Нет - уменьшить на один день) (Отмена - отмена корректировки)?", vbYesNoCancel)
                Case MsgBoxResult.Yes
                    _day = _corrcetobj.CalculateDay.Value
                    _deltaDay += 1
                    _minusDay = True
                    GoTo changeDay
                Case vbNo
                    _day = _corrcetobj.CalculateDay.Value
                    _deltaDay -= 1
                    _minusDay = True
                    GoTo changeDay
                Case MsgBoxResult.Cancel
                    Return
            End Select
        End If

        MsgBox("Скорректирована " & _res & " запись от " & _newDate.ToShortDateString & "  c " & _oldDate.ToShortTimeString & " на " & _newDate.ToShortTimeString, vbOKOnly)

        'обновить

        Me.WTimeSummary_ResultBindingSource.ResetBindings(False)

        If Me.gbSelectEmployee.Visible = True Then
            cbEmployee_SelectedIndexChanged(sender, e)
        Else
            Me.btGetMyTime_Click(sender, e)
        End If
    End Sub

    Private Sub DateTimePicker_correctwTime_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker_correctwTime.ValueChanged
        Me.DateTimePicker_CorrectWDate.Value = DateTimePicker_correctwTime.Value
    End Sub

    Private Sub DateTimePicker_CorrectWDate_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker_CorrectWDate.ValueChanged
        Me.DateTimePicker_correctwTime.Value = DateTimePicker_CorrectWDate.Value
    End Sub

    ''' <summary>
    ''' добавит запись в таблицу WTime
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btAddWRecord_Click(sender As Object, e As EventArgs) Handles btAddWRecord.Click
        'Dim _obj As wTimeSummary_Result = WTimeSummary_ResultBindingSource.Current
        'If _obj Is Nothing Then Return

        Dim _operation As Integer
        Dim _message As String = ""

        'вычислим добавляемую дату
        Dim _addDate As Date = Me.DateTimePicker_correctwTime.Value

        If _addDate > Service.clsApplicationTypes.GetCurrentTime Then
            MsgBox("Попытка добавить запись будующим числом, что недопустимо!", vbCritical)
            Return
        End If

        If rbCorrectBeginwTime.Checked Then
            _operation = 1
            _message = "Приход на работу (регистрация)"
        End If

        If rbCorrectEndwtime.Checked Then
            _operation = 2
            _message = "Уход с работы (регистрация)"
        End If
        Select Case MsgBox("Добавить запись " & _message & " дата: " & _addDate, vbYesNo)
            Case MsgBoxResult.Ok, MsgBoxResult.Yes
                '-------------
                Dim _userID As Integer
                If clsApplicationTypes.GetAccess("Информация об операциях сотрудников") Then
                    _userID = Me.cbEmployee.SelectedValue
                Else
                    _userID = clsApplicationTypes.CurrentUser.Employee.ID
                End If
                Dim _res = (clsApplicationTypes.SampleDataObject.GetdbPhotoObjectContext.wRegisterTimeOperation(_userID, _addDate, _operation, 1, Nothing)).ToList

                'обновить

                Me.WTimeSummary_ResultBindingSource.ResetBindings(False)

                If Me.gbSelectEmployee.Visible = True Then
                    cbEmployee_SelectedIndexChanged(sender, e)
                Else
                    Me.btGetMyTime_Click(sender, e)
                End If
        End Select

    End Sub

    ''' <summary>
    ''' удалит запись из таблицы wTime
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btRemoveWRecord_Click(sender As Object, e As EventArgs) Handles btRemoveWRecord.Click
        Dim _obj As wTimeSummary_Result = WTimeSummary_ResultBindingSource.Current
        If _obj Is Nothing Then Return

        Dim _operation As Integer

        'вычислим удаляемую дату
        Dim _deleteDate As Date = Me.DateTimePicker_correctwTime.Value

        If rbCorrectBeginwTime.Checked Then
            _operation = 1
        End If

        If rbCorrectEndwtime.Checked Then
            _operation = 2
        End If

        '-------------
        Dim _userID As Integer
        If clsApplicationTypes.GetAccess("Информация об операциях сотрудников") Then
            _userID = Me.cbEmployee.SelectedValue
        Else
            _userID = clsApplicationTypes.CurrentUser.Employee.ID
        End If
        Dim _res = (clsApplicationTypes.SampleDataObject.GetdbPhotoObjectContext.wTimeDeleteRecord(_userID, _deleteDate, _operation))


        If _res = -1 Then
            If _operation > 1 Then
                MsgBox("Удаление не прошло. Возможно, запись окончания работы имеет другую дату. Скорректируйте на день значение даты.", vbCritical)
            Else
                MsgBox("Удаление не прошло.", vbCritical)
            End If
            Return
        End If

        MsgBox("Удалена " & _res & " запись от " & _deleteDate.ToShortDateString & "  " & _deleteDate.ToShortTimeString, vbOKOnly)

        'обновить

        Me.WTimeSummary_ResultBindingSource.ResetBindings(False)

        If Me.gbSelectEmployee.Visible = True Then
            cbEmployee_SelectedIndexChanged(sender, e)
        Else
            Me.btGetMyTime_Click(sender, e)
        End If



    End Sub
#End Region

#Region "Зарплата"
    ''' <summary>
    ''' обновляет данные о зарплате и времени
    ''' </summary>
    ''' <param name="EmployeeID"></param>
    ''' <remarks></remarks>
    Private Sub ReadSalary(EmployeeID As Integer)
        If clsApplicationTypes.CurrentUser Is Nothing Then Return

        Dim _res = (clsApplicationTypes.SampleDataObject.GetdbPhotoObjectContext.wTimeSummary(EmployeeID, clsApplicationTypes.GetCurrentTime)).ToList

        Dim _salary = (clsApplicationTypes.SampleDataObject.GetdbPhotoObjectContext.wSalaryInfo(EmployeeID, clsApplicationTypes.GetCurrentTime)).ToList

        If Not _res Is Nothing Then
            Me.WTimeSummary_ResultBindingSource.DataSource = _res
            Me.WSalaryInfo_ResultBindingSource.DataSource = _salary
            clsApplicationTypes.BeepYES()
        Else
            Me.WTimeSummary_ResultBindingSource.DataSource = Nothing
            Me.WSalaryInfo_ResultBindingSource.DataSource = Nothing
            clsApplicationTypes.BeepNOT()
        End If

        Me.WTimeSummary_ResultDataGridView.Refresh()

        'отобразить общее
        Me.tbctlSalary_SelectedIndexChanged(Me, EventArgs.Empty)
    End Sub
    ''' <summary>
    ''' показать подробно о сотрудниках
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cbEmployee_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbEmployee.SelectedIndexChanged
        'выбор на вкладке Мое Время
        If clsApplicationTypes.CurrentUser Is Nothing Then Return
        ReadSalary(cbEmployee.SelectedValue)
    End Sub

    ''' <summary>
    ''' смена выбора зарплаты
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub WSalaryInfo_ResultBindingSource_CurrentItemChanged(sender As Object, e As EventArgs) Handles WSalaryInfo_ResultBindingSource.CurrentItemChanged
        Dim _obj As wSalaryInfo_Result = WSalaryInfo_ResultBindingSource.Current
        If _obj Is Nothing Then Return
        If _obj.DateToInclude Is Nothing Then Return
        Me.DateTimePicker_salary.Value = _obj.DateToInclude

        Select Case clsApplicationTypes.GetAccess("Информация об операциях сотрудников")
            Case True
                If _obj.Paid = False Then
                    Me.btPaySalary.Enabled = True
                    Me.DateTimePicker_salary.Enabled = True
                Else
                    Me.DateTimePicker_salary.Enabled = False
                    Me.btPaySalary.Enabled = False
                End If
            Case False
                Me.DateTimePicker_salary.Enabled = False
                Me.btPaySalary.Enabled = False
        End Select

    End Sub
    ''' <summary>
    ''' фиксация ЗП
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btPaySalary_Click(sender As Object, e As EventArgs) Handles btPaySalary.Click
        Dim _obj As wSalaryInfo_Result = WSalaryInfo_ResultBindingSource.Current
        If _obj Is Nothing Then Return
        '_obj содержит запись на оплату
        'записать ЗП
        If _obj.Paid = True Then
            MsgBox("Оплатить возможно только неоплаченную ЗП!", vbCritical)
            Return
        End If

        '-------------
        Dim _userID As Integer

        If clsApplicationTypes.GetAccess("Информация об операциях сотрудников") Then
            _userID = Me.cbEmployee.SelectedValue
        Else
            _userID = clsApplicationTypes.CurrentUser.Employee.ID
        End If

        ''заплатить зарплату
        Dim _res = (clsApplicationTypes.SampleDataObject.GetdbPhotoObjectContext.wTimeSummaryTotal(_userID, Me.DateTimePicker_salary.Value, clsApplicationTypes.GetCurrentTime, 1)).ToList

        '''
        If _res.Count = 0 Then
            MsgBox("Зарплата не зафиксирована!", vbCritical)
        Else

        End If

        'обновить
        '''
        If Me.gbSelectEmployee.Visible = True Then
            ReadSalary(cbEmployee.SelectedValue)
        Else
            ReadSalary(clsApplicationTypes.CurrentUser.Employee.ID)
        End If

        '''
        'MsgBox("Зарплата в сумме " & _res(0).totalCost & " " & _res(0).currency & " с " & _res(0).DateFromInclude.ToShortDateString & " по " & _res(0).DateToInclude.ToShortDateString & " зафиксирована", vbOKOnly)
    End Sub
    ''' <summary>
    ''' запись общего в Всего по Таблице
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tbctlSalary_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tbctlSalary.SelectedIndexChanged
        If Me.WTimeSummary_ResultBindingSource.DataSource Is Nothing Then Return
        If Me.WSalaryInfo_ResultBindingSource.DataSource Is Nothing Then Return
        Dim _summ As Decimal = 0

        Select Case tbctlSalary.SelectedIndex
            Case 0
                'вкладка Неоплачено
                With Me.WTimeSummary_ResultDataGridView
                    For Each _r As DataGridViewRow In .Rows
                        _summ += _r.Cells(4).Value
                    Next
                End With

            Case 1
                'вкладка Все зарплаты
                With Me.WSalaryInfo_ResultDataGridView
                    For Each _r As DataGridViewRow In .Rows
                        _summ += _r.Cells(6).Value
                    Next
                End With
        End Select

        Me.tbEmployeeSum.Text = _summ
    End Sub

#End Region

#Region "Посылки"

    ''' <summary>
    ''' Запрос посылок
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btRequestParcels_Click(sender As Object, e As EventArgs) Handles btRequestParcels.Click
        'получить обьект интерфейса и загрузить прочие данные
        Dim _McInterfeis = clsApplicationTypes.MoySklad(True, False)
        If _McInterfeis Is Nothing Then Return
        '---------------------
        Me.oUserActivity = -1
        btRequestParcels.Enabled = False
        btRequestParcels.Text = "Думаю.."
        Application.DoEvents()

        Dim _wokers = _McInterfeis.GetTriboneWoker()
        If clsApplicationTypes.GetAccess("Просмотр всех отправлений") Then
            'загрузить всех сотрудников
            Me.cbShippingWoker.DataSource = New BindingSource(_wokers, Nothing)
            Me.cbShippingWoker.ValueMember = "key"
            Me.cbShippingWoker.DisplayMember = "value"
        Else
            Me.cbShippingWoker.DataSource = {New KeyValuePair(Of String, String)(clsApplicationTypes.CurrentUser.UserPermission.mcuuid, clsApplicationTypes.CurrentUser.UserShotName)}
        End If

        'TODO отфильтровать
        Dim _shipCompanies = _McInterfeis.GetShippingCompanies
        Me.cbShippingCompany.DataSource = New BindingSource(_shipCompanies, Nothing)
        Me.cbShippingCompany.ValueMember = "key"
        Me.cbShippingCompany.DisplayMember = "value"
        Dim _curr = New KeyValuePair(Of String, String)(_McInterfeis.GetCurrencyUUIDByName("EUR"), "EUR")
        Me.cbShippingCurrency.DataSource = {_curr}
        Me.cbShippingCurrency.ValueMember = "key"
        Me.cbShippingCurrency.DisplayMember = "value"

        'выбрать агента
        'пока времмено оформляем все на агента ebay trilbone
        'проблема в том, что UUID Demandstate1, ShippingIn,GoodHandling и ShippingOut могут быть разные
        'но агента для которого отправка в этом месте МЫ НЕ ЗНАЕМ
        Dim _parcelInfoCollection As New List(Of Service.iMoySkladDataProvider.clsParcelInfo)

        Dim _agent = clsApplicationTypes.AuctionAgent.AGENT.Where(Function(x) x.name = "ebay" And x.account = "trilbone").FirstOrDefault
        Dim _StateUUID = _agent.GetAgentID("moysklad", "Demandstate1")
        Dim _ExcludeGoodsUUID = {_agent.GetAgentID("moysklad", "ShippingIn")}
        Dim _WokerUUID As String
        If clsApplicationTypes.GetAccess("Просмотр всех отправлений") Then
            _WokerUUID = ""
        Else
            _WokerUUID = clsApplicationTypes.CurrentUser.UserPermission.mcuuid
        End If
        Dim _result = _McInterfeis.GetParcelsInfoForShip(StateUUID:=_StateUUID, ExcludeGoodsUUID:=_ExcludeGoodsUUID, WokerUUID:=_WokerUUID)
        For Each t In _result
            t.Agent = _agent
        Next
        _parcelInfoCollection.AddRange(_result)


        'Dim _agentList As New List(Of Service.Agents.AUCTIONDATAAGENT)
        'For Each _a In clsApplicationTypes.AuctionAgent.AGENT
        '    Dim _acc = clsApplicationTypes.GetAccess(_a.account)
        '    If _acc Then
        '        _agentList.Add(_a)
        '    End If
        'Next


        'For Each _agent In _agentList
        '    Dim _StateUUID = _agent.GetValue("moysklad", "Demandstate1")
        '    Dim _ExcludeGoodsUUID = {_agent.GetValue("moysklad", "ShippingIn")}
        '    Dim _WokerUUID As String
        '    If clsApplicationTypes.GetAccess("Просмотр всех отправлений") Then
        '        _WokerUUID = ""
        '    Else
        '        _WokerUUID = clsApplicationTypes.CurrentUser.UserPermission.mcuuid
        '    End If
        '    Dim _result = _McInterfeis.GetParcelsInfoForShip(StateUUID:=_StateUUID, ExcludeGoodsUUID:=_ExcludeGoodsUUID, WokerUUID:=_WokerUUID)
        '    If Not _result Is Nothing Then
        '        For Each t In _result
        '            t.Agent = _agent
        '        Next
        '        _parcelInfoCollection.AddRange(_result)
        '    End If
        'Next

        'загружены
        Me.IMoySkladDataProvider_ParcelInfoBindingSource.DataSource = _parcelInfoCollection
        Me.cbCurrentItemList.Items.Clear()
        If _parcelInfoCollection.Count > 0 Then
            'работа с ЭУ
            IMoySkladDataProvider_ParcelInfoBindingSource_CurrentItemChanged(IMoySkladDataProvider_ParcelInfoBindingSource, EventArgs.Empty)
            MsgBox("Найдено " & _parcelInfoCollection.Count & " отправлений", vbInformation)
        Else
            Me.cbCurrentItemList.Items.Clear()
            Me.tbSKU.Text = ""
            Me.gbParcelCount.Text = "Всего посылок: 0"
            Me.lblItemsInParcel.Text = "(раскрой список) Надо упаковать в эту посылку:"
            MsgBox("Нет отправлений. Если должны быть, проверте соответствующую Отгрузку, она НЕ ДОЛЖНА быть проведена!!", vbCritical)
        End If

        btRequestParcels.Enabled = True
        btRequestParcels.Text = "Получить"
    End Sub

    ''' <summary>
    ''' перебор отправлений лузером
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub IMoySkladDataProvider_ParcelInfoBindingSource_CurrentItemChanged(sender As Object, e As EventArgs) Handles IMoySkladDataProvider_ParcelInfoBindingSource.CurrentItemChanged
        'loaditems
        If Me.IMoySkladDataProvider_ParcelInfoBindingSource.Current Is Nothing Then Return
        '---------------------
        Dim _parcelInfo As iMoySkladDataProvider.clsParcelInfo = Me.IMoySkladDataProvider_ParcelInfoBindingSource.Current
        'привязка результата
        If _parcelInfo.ResultParcel Is Nothing Then
            _parcelInfo.ResultParcel = New iMoySkladDataProvider.clsResultParcelInfo
        End If
        Me.IMoySkladDataProvider_ResultParcelInfoBindingSource.DataSource = _parcelInfo.ResultParcel

        Me.cbCurrentItemList.Items.Clear()
        Me.cbCurrentItemList.Items.AddRange(_parcelInfo.GoodList.ToArray)
        Me.cbCurrentItemList.SelectedIndex = 0
        Me.lblItemsInParcel.Text = "(раскрой список) Надо упаковать в эту посылку: " & _parcelInfo.GoodCodesList.Count & " камней"

        Dim _tmp As String = ""
        For Each t In _parcelInfo.GoodCodesList
            _tmp += t & " "
        Next
        _tmp.Trim()
        _parcelInfo.ResultParcel.Comment = _tmp
        ' Me.tbSKU.Text = _tmp
    End Sub
    ''' <summary>
    ''' сохранить посылку в базах
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btSaveShipping_Click(sender As Object, e As EventArgs) Handles btSaveShipping.Click

        If Me.IMoySkladDataProvider_ParcelInfoBindingSource.Current Is Nothing Then
            Return
        End If

        If Me.ShippingAmountTextBox.Text = "" Then
            Return
        End If

        If Me.HandlingAmountTextBox.Text = "" Then
            Return
        End If

        Dim _McInterfeis = clsApplicationTypes.MoySklad(True, False)
        If _McInterfeis Is Nothing Then Return
        '---------------------
        Dim _info As iMoySkladDataProvider.clsParcelInfo = Me.IMoySkladDataProvider_ParcelInfoBindingSource.Current
        Dim _resultInfo = _info.ResultParcel
        Dim _DemandUUID As String = _info.DemandUUID
        Dim _ResultParcels As iMoySkladDataProvider.clsResultParcelInfo() = {_resultInfo}
        Dim _NewStateUUID As String = _info.Agent.GetAgentID("moysklad", "Demandstate2")
        _resultInfo.HandlingGoodUUID = _info.Agent.GetAgentID("moysklad", "HandlingOut")
        _resultInfo.ShippingGoodUUID = _info.Agent.GetAgentID("moysklad", "ShippingOut")

        Dim _result = _McInterfeis.UpdateDemandsAfterShip(DemandUUID:=_DemandUUID, ResultParcels:=_ResultParcels, NewStateUUID:=_NewStateUUID)
        If _result Then
            MsgBox("Посылка успешно оформлена", vbInformation)
            'запомнить вес, стоимость и размер отправления
            Dim _totalInShippingInHandlingFee As Decimal = clsApplicationTypes.ReplaceDecimalSplitter(ShippingAmountTextBox) + clsApplicationTypes.ReplaceDecimalSplitter(HandlingAmountTextBox)
            Dim _res = clsApplicationTypes.SampleDataObject.AddOutParcelFee(demandUUID:=_DemandUUID, totalInShippingFee:=_totalInShippingInHandlingFee, parcelWeight:=_resultInfo.ParcelWeight, parcelSizeA:=_resultInfo.ParcelSizeA, parcelSizeB:=_resultInfo.ParcelSizeB, parcelSizeC:=_resultInfo.ParcelSizeC)
            If _res > 0 Then
                MsgBox("Стоимость посылки успешно записана", vbInformation)
                'удалим из списка оформленный
                Me.IMoySkladDataProvider_ParcelInfoBindingSource.RemoveCurrent()
                Me.IMoySkladDataProvider_ParcelInfoBindingSource.ResetBindings(False)
            End If
        Else
            MsgBox("Посылку не удалось оформить! Проверте заполнение всех полей и попробуйте еще раз!", vbCritical)
        End If
    End Sub



    ''' <summary>
    ''' начало оформления посылки
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btParcelResult_Click(sender As Object, e As EventArgs) Handles btParcelResult.Click
        '    'сюда добавить генерацию данных для omniva
        Me.tbctlParcels.SelectedIndex = 2
    End Sub
    ''' <summary>
    ''' проверка числовых значений
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tbParcelSizeA_Validating(sender As Object, e As CancelEventArgs) Handles tbParcelSizeA.Validating, tbParcelSizeB.Validating, tbParcelSizeC.Validating, ShippingAmountTextBox.Validating, HandlingAmountTextBox.Validating, tbParcelWeight.Validating
        Dim _sender As TextBoxBase = sender
        Dim _pi As iMoySkladDataProvider.clsResultParcelInfo = IMoySkladDataProvider_ResultParcelInfoBindingSource.Current

        _sender.Text = clsApplicationTypes.ReplaceDecimalSplitter(sender).ToString

        Dim _a = clsApplicationTypes.ReplaceDecimalSplitter(tbParcelSizeA)
        Dim _b = clsApplicationTypes.ReplaceDecimalSplitter(tbParcelSizeB)
        Dim _c = clsApplicationTypes.ReplaceDecimalSplitter(tbParcelSizeC)

        'проверка на метры
        If _a >= 10 Or _b >= 10 Or _c >= 10 Then
            If _a >= 10 Then
                _a = _a / 100
                _pi.ParcelSizeA = _a
            End If
            If _b >= 10 Then
                _b = _b / 100
                _pi.ParcelSizeB = _b
            End If
            If _c >= 10 Then
                _c = _c / 100
                _pi.ParcelSizeC = _c
            End If
        ElseIf _a >= 1 Or _b >= 1 Or _c >= 1 Then
            Select Case MsgBox("Один из размеров посылки более одного метра! Вы уверены? *размеры указываются в МЕТРАХ", vbYesNo)
                Case MsgBoxResult.No
                    If _a >= 1 Then
                        _a = _a / 100
                        _pi.ParcelSizeA = _a
                    End If
                    If _b >= 1 Then
                        _b = _b / 100
                        _pi.ParcelSizeB = _b
                    End If
                    If _c >= 1 Then
                        _c = _c / 100
                        _pi.ParcelSizeC = _c
                    End If
            End Select

        End If
        'If _a > 1 Or _b > 1 Or _c > 1 Then

        'End If

        'сумма трех измерений
        Dim _v = _a + _b + _c
        If _v > 0.9 Then
            Me.cbParcelGroup.SelectedIndex = 1
            Me.cbParcelType.SelectedIndex = 1
        Else
            Me.cbParcelGroup.SelectedIndex = 0
            Me.cbParcelType.SelectedIndex = 0

            If clsApplicationTypes.ReplaceDecimalSplitter(tbParcelWeight) > 2 Then
                Me.cbParcelGroup.SelectedIndex = 1
                Me.cbParcelType.SelectedIndex = 1
            Else
                Me.cbParcelGroup.SelectedIndex = 0
                Me.cbParcelType.SelectedIndex = 0
            End If
        End If
    End Sub
    ''' <summary>
    ''' проверка веса посылки
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tbParcelWeight_Validated(sender As Object, e As EventArgs) Handles tbParcelWeight.Validated
        Dim _sender As TextBoxBase = sender
        Dim _pi As iMoySkladDataProvider.clsResultParcelInfo = IMoySkladDataProvider_ResultParcelInfoBindingSource.Current
        Dim _weight As Decimal = clsApplicationTypes.ReplaceDecimalSplitter(_sender)
        If _weight > 50 Then
            _weight = _weight / 1000
            _pi.ParcelWeight = _weight
        ElseIf _weight >= 10 Then
            Select Case MsgBox("Вес посылки превышает 10 кг! Вы уверены? *вес указывается в КИЛОГРАММАХ", vbYesNo)
                Case MsgBoxResult.No
                    _weight = _weight / 1000
                    _pi.ParcelWeight = _weight
            End Select
        End If

        'тип посылки
        If _weight > 2 Then
            Me.cbParcelGroup.SelectedIndex = 1
            Me.cbParcelType.SelectedIndex = 1
        Else
            Me.cbParcelGroup.SelectedIndex = 0
            Me.cbParcelType.SelectedIndex = 0
            'проверка геометрии
            Dim _a = clsApplicationTypes.ReplaceDecimalSplitter(tbParcelSizeA)
            Dim _b = clsApplicationTypes.ReplaceDecimalSplitter(tbParcelSizeB)
            Dim _c = clsApplicationTypes.ReplaceDecimalSplitter(tbParcelSizeC)

            'сумма трех измерений
            Dim _v = _a + _b + _c
            'выбор типа: посылка или бандероль
            'ограничение 90см
            If _v > 0.9 Then
                Me.cbParcelGroup.SelectedIndex = 1
                Me.cbParcelType.SelectedIndex = 1
            Else
                Me.cbParcelGroup.SelectedIndex = 0
                Me.cbParcelType.SelectedIndex = 0
            End If
        End If
    End Sub

    ''' <summary>
    ''' покажем фото для выбраного образца
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cbCurrentItemList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbCurrentItemList.SelectedIndexChanged
        If cbCurrentItemList.SelectedIndex < 0 Then Return
        Dim _str As String = cbCurrentItemList.SelectedItem

        Dim _num = _str.Split(":")(0).Trim

        Dim _sn = clsApplicationTypes.clsSampleNumber.CreateFromString(_num)

        If Not _sn Is Nothing AndAlso _sn.CodeIsCorrect = True Then
            Me.PictureBox1.Image = _sn.AskImage
        End If
    End Sub


#End Region

    Private Sub tbctlMain_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tbctlMain.SelectedIndexChanged
        If tbctlMain.SelectedTab Is tpSampleInfo Then
            Uc_trilbone_history1.KeyPressRaise(New Char)
        End If
        If tbctlMain.SelectedTab Is tpSellRegister Then
            UcSellGood1.init()
        End If
        If tbctlMain.SelectedTab Is tpОформление Then
            Uc_createSample1.Init()
        End If
    End Sub


    Private Sub fmWtime_Load(sender As Object, e As EventArgs) Handles Me.Load
        If clsApplicationTypes.RFIDmanager.IsScannerMode Then
            btScannerON.FlatAppearance.BorderSize = 5
            ' btScannerON.Enabled = False
        Else
            btScannerON.FlatAppearance.BorderSize = 0
            ' btScannerON.Enabled = True
        End If
    End Sub

    Private Sub btScannerON_Click(sender As Object, e As EventArgs) Handles btScannerON.Click
        If btScannerON.FlatAppearance.BorderSize = 5 Then
            clsApplicationTypes.RFIDmanager.StopScanner()
            btScannerON.FlatAppearance.BorderSize = 0
            ' btScannerON.BackColor = Color.FromKnownColor(KnownColor.Control)

        Else
            clsApplicationTypes.RFIDmanager.StartScanner()
            btScannerON.FlatAppearance.BorderSize = 5
            'btScannerON.BackColor = Color.Red
        End If
        btScannerON.Refresh()
    End Sub

    Private Sub btRestartRFID_Click(sender As Object, e As EventArgs) Handles btRestartRFID.Click
        Dim _m = clsApplicationTypes.RFIDmanager(True)
    End Sub

    Private Sub UC_rfid1_TagReaded(sender As Object, e As UC_rfid.TagReadedEventArgs) Handles UC_rfid1.TagReaded
        If cbxMoySkladAsk.Checked = False Then Return
        'пробуем прочитать интерфейс МС
        Me.lbLocationInfo.Text = "выполняю запрос.."
        Application.DoEvents()
        Dim _mc = clsApplicationTypes.MoySklad(False)
        If _mc Is Nothing Then clsApplicationTypes.BeepNOT() : Me.lbLocationInfo.Text = "Склад не готов" : Return
        Application.DoEvents()
        Me.oUserActivity = -1
        'первый тег
        Dim _res = _mc.FindGoods("", e.TagCollection.FirstOrDefault)

        If Not _res Is Nothing AndAlso _res.Count > 0 Then
            Dim _gi = _res(0)
            Dim _sn = clsApplicationTypes.clsSampleNumber.CreateFromString(_gi.ActualNumber)
            If Not _sn.CodeIsCorrect Then Return
            Me.pbEANLabel.Image = clsApplicationTypes.CreateEANLabel(_sn, _gi.Name, _gi.RetailPrice & _gi.RetailCurrencySymbol)
            Dim _loc = _gi.goodLocationInfo.Invoke(_gi)
            If Not _loc Is Nothing AndAlso _loc.Count > 0 Then
                Me.lbLocationInfo.Text = String.Concat(_loc.Select(Function(x) x & "; ").ToArray)
            End If
            clsApplicationTypes.BeepYES()
        Else
            Me.lbLocationInfo.Text = "нет данных"
        End If
    End Sub



    Private Sub btPrintLabel_Click(sender As Object, e As EventArgs) Handles btPrintLabel.Click
        If Me.pbEANLabel.Image Is Nothing Then Return
        Dim _lbl = clsApplicationTypes.CreatePrintableLabel(Me.pbEANLabel.Image)
        Dim _pd = Service.clsApplicationTypes.PrintLabel({_lbl}.ToList, oNeedResetPrinters, False)
        If Not _pd Is Nothing Then
            Try
                _pd.Print()
                oNeedResetPrinters = False
                Return
            Catch ex As Exception

            End Try
        End If
        MsgBox("Не удалось напечатать документ", vbCritical)
    End Sub

    Private Sub btPrinterClear_Click(sender As Object, e As EventArgs) Handles btPrinterClear.Click
        Me.oNeedResetPrinters = True
    End Sub

    Private Sub cbxMoySkladAsk_CheckedChanged(sender As Object, e As EventArgs) Handles cbxMoySkladAsk.CheckedChanged
        Me.pbEANLabel.Image = My.Resources.City_No_Camera_icon
        Me.lbLocationInfo.Text = ""
    End Sub




    Private Sub tbSchemeNumber_TextChanged(sender As Object, e As EventArgs) Handles tbSchemeNumber.TextChanged
        If tbSchemeNumber.Text.Length > 0 Then
            btRegisterSchema.Enabled = True
        End If
    End Sub

    Private Sub btLoadExpeditionFromMC_Click(sender As Object, e As EventArgs) Handles btLoadExpeditionFromMC.Click
        Dim _msi = clsApplicationTypes.MoySklad(True)
        If _msi Is Nothing Then Return
        Me.cbExpedition.Items.Clear()
        Me.cbExpedition.Items.AddRange(_msi.GetExpeditionList.ToArray)
    End Sub

    Private Sub btEditOperation_Click(sender As Object, e As EventArgs) Handles btEditOperation.Click
        Me.oUserActivity = -1
        If Not Me.tbctlMain.TabPages.Contains(Me.tpNewSample) Then
            Me.tbctlMain.TabPages.Add(Me.tpNewSample)
        End If
        'работа с вкладкой Новый
        Clear_forNewSample()

        'добыть обьект лота
        Dim _curr As tbSMOperation.clsSMoperation = Me.lbxCurrentUserOperation.SelectedItem
        Dim _op = _curr.Parent
        _op.tbSMLotOperation.Load()
        Dim _lot = _op.tbSMLotOperation.Select(Function(x) x.tbSMLot).ToList
        Me.TbSMLotBindingSource.DataSource = _lot.FirstOrDefault

        Me.tbctlMain.SelectTab(Me.tpNewSample)
        Me.btCreateSchema.Focus()
    End Sub

    Private Sub tbPin_TextChanged(sender As Object, e As EventArgs) Handles tbPin.TextChanged

    End Sub

    Private Sub lbMoySkladStatus_Click(sender As Object, e As EventArgs) Handles lbMoySkladStatus.Click
        'асинхронный запуск мойсклад
        Me.lbMoySkladStatus.BackColor = Color.Yellow
        InitMC()
    End Sub

    Private Sub ОприходованиеEventHandler(sender As Object, e As uc_createSample.CurrentSampleChangedEventArgs) Handles Uc_createSample1.CurrentSampleChanged
        If Not e.IsNothing Then
            Me.PictureBox2.Image = e.CurrentSample.AskImage
        End If
    End Sub

End Class