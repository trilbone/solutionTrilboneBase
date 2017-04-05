Imports Service.clsApplicationTypes
Public Class Access
    Private oPassword As String

    Public Sub New()

        ' Этот вызов является обязательным для конструктора.
        InitializeComponent()

        ' Добавьте все инициализирующие действия после вызова InitializeComponent().

        lbConnect.Text = "password?"

    End Sub

    'Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

    '    'Select Case Me.MaskedTextBox1.Text.ToLower
    '    '    Case "2157579".ToLower
    '    '        _user = Service.clsApplicationTypes.emUsers.Admin
    '    '    Case "nn2014".ToLower
    '    '        _user = Service.clsApplicationTypes.emUsers.NarvaWoker
    '    '    Case "tr2014".ToLower
    '    '        _user = Service.clsApplicationTypes.emUsers.PetrogradkaWoker
    '    '    Case Else
    '    '        MsgBox("Неправильный пароль!", vbCritical)
    '    '        Me.MaskedTextBox1.SelectAll()
    '    '        Return
    '    'End Select

    '    '=====end user select=========
    '    Me.MaskedTextBox1.Enabled = False
    '    Me.Button1.Enabled = False
    '    MaskedTextBox1.Text = ""
    '    lbConnect.Text = "Connecting to DB..."
    '    Me.Invalidate()
    '    '=======service============
    '    'при публикации сервиса его надо запустить в этом модуле
    '    'инициализуем экземпляр сервисного класса
    '    'Dim _excelConnService As ConnectExcel.ExcelService
    '    ' и запускаем его
    '    '_excelConnService = New ConnectExcel.ExcelService
    '    'в конструкторе каждого сервисного класса должны быть определены методы привязки сервисов         'к соответствующим делегатам класса Service.clsApplicationTypes

    '    ''инициализация сервисов
    '    Dim _service As Service.clsApplicationTypes
    '    Dim _PhotoService As Photo_reader.clsPhotoService
    '    Dim _OrderService As OrdersAndClients.OrderService
    '    Dim _MainOrderService As Trilbone_startup.clsMainOrderService
    '    Dim _excelConnService As ConnectExcel.clsExcelService
    '    Dim _RestMSService As RestMS_Client.clsRestMS_service
    '    Dim _treeService As Trilbone.clsTreeService

    '    'основной обслуживающий объект
    '    _service = New Service.clsApplicationTypes()

    '    Dim message As String = ""
    '    System.Windows.Forms.Application.DoEvents()
    '    'проверка подключения к бд
    '    lbConnect.Text += "try connect ..."

    '    Dim _out As Boolean
    '    Select Case cbxAzure.Checked
    '        Case True
    '            Dim _azurePhotoCONSTR = "Server=tcp:v0ecxr50yd.database.windows.net,1433;Database=DBOPHOTO;User ID=foto@v0ecxr50yd;Password=Asaphus2009;Trusted_Connection=false;TrustServerCertificate=True;Encrypt=True;Connection Timeout=30;"
    '            Dim _azureSampleCONSTR = "Server=tcp:v0ecxr50yd.database.windows.net,1433;Database=DBREADYSAMPLE;User ID=foto@v0ecxr50yd;Password=Asaphus2009;Trusted_Connection=false;TrustServerCertificate=True;Encrypt=True;Connection Timeout=30;"
    '            _out = _service.InitDbConnection(message, True, _azurePhotoCONSTR, _azureSampleCONSTR)
    '        Case Else
    '            _out = _service.InitDbConnection(message, False)
    '    End Select

    '    Select Case _out
    '        Case True
    '            'соединение есть
    '            'MsgBox(message)
    '            lbConnect.Text += message
    '        Case False
    '            'соединения нет
    '            If _user = Service.clsApplicationTypes.emUsers.Admin Then
    '                'админ может добавить сервер
    '                Me.Hide()
    '                Select Case MsgBox(message + ". Do you want add new server?", vbYesNo)
    '                    Case vbYes
    '                        Dim _input As String = InputBox("Введите имя нового сервера", DefaultResponse:="none")

    '                        If Not _input = "none" Then
    '                            _service.AddServerName(_input)
    '                            message = "Запустите программу заново.."
    '                        End If
    '                    Case vbNo
    '                        Select Case MsgBox("Do you want remove server?", vbYesNo)
    '                            Case vbYes
    '                                Dim _input As String = InputBox("Введите имя сервера для удаления", DefaultResponse:="none")

    '                                If Not _input = "none" Then
    '                                    If _service.RemoveServerName(_input) Then
    '                                        message = "Имя сервера удалено. Запустите программу заново.."

    '                                    Else
    '                                        message = "Запустите программу заново.."
    '                                    End If

    '                                Else
    '                                    message = "Неправильный ввод. Запустите программу заново.."
    '                                End If

    '                            Case vbNo
    '                                message = "Запустите программу заново.."

    '                        End Select


    '                End Select

    '            Else

    '                message += ". Подсоедините БД. Завершение работы приложения."
    '            End If

    '            MsgBox(message, vbOKOnly)
    '            'точка ВЫХОДА
    '            Me.Close()
    '            Exit Sub
    '    End Select
    '    '================================
    '    'подключение к БД ок
    '    Me.Invalidate()
    '    System.Windows.Forms.Application.DoEvents()

    '    lbConnect.Text = "Service initialisation to " & [Enum].GetName(_user.GetType, _user)

    '    'запуск сервисов для пользователей
    '    'для всех 
    '    _PhotoService = New Photo_reader.clsPhotoService
    '    _RestMSService = New RestMS_Client.clsRestMS_service
    '    _OrderService = New OrdersAndClients.OrderService
    '    _treeService = New Trilbone.clsTreeService


    '    Select Case _user
    '        Case Service.clsApplicationTypes.emUsers.Admin
    '            _MainOrderService = New Trilbone_startup.clsMainOrderService
    '            _excelConnService = New ConnectExcel.clsExcelService

    '    End Select

    '    '==========end service=======

    '    '=====main form==========
    '    'запуск формы
    '    Service.clsApplicationTypes.FormMain = New Trilbone_startup.fmMain(message)
    '    'Dim _startFmMain As New Trilbone_startup.fmMain(message)
    '    Me.Hide()
    '    Service.clsApplicationTypes.FormMain.ShowDialog()
    '    Me.Close()
    '    'Application.Run(_startFm)
    '    '==================
    '    'Me.Close()
    'End Sub
    Public ReadOnly Property Password As String
        Get
            Return oPassword
        End Get
    End Property


    Private Sub MaskedTextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MaskedTextBox1.KeyPress
        If Asc(e.KeyChar) = 13 Then
            'Button1_Click(sender, e)
        End If
    End Sub

   

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Me.MaskedTextBox1.Text = "tr2014"
        ' Me.Button1_Click(sender, e)
        
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Me.MaskedTextBox1.Text = "nn2014"
        ' Me.Button1_Click(sender, e)

    End Sub

    Private Sub Access_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class