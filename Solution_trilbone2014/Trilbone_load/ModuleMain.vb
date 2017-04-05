Imports System.Windows.Forms
Imports Service
Imports System.ComponentModel
Imports System.Deployment.Application

Public Module ModuleMain
    Private oUserForm As fmWtime
    Private _service As Service.clsApplicationTypes
    Dim oNetworkStatus As Boolean


    <STAThreadAttribute>
    Public Sub main()
        '<STAThread>
        initService()
        'запуск фоновых процессов
        'MC запускается в fmWTime стр 277 (CheckPin)
        'ebay запрос работает только в realise или надо вручную запускать см. clsApplicationTypes.TimerTickEventHandler line 2913
        clsApplicationTypes.RunTimer()
        'форма входа
        oUserForm = New fmWtime
        With oUserForm
            Dim _version = "debugger"
#If Not Debug Then
            _version = ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString
#End If
            .Text = "Trilbone на компьютере " & clsApplicationTypes.MachineName & "  версия: " & _version
            'в левый угол
            .Location = New Drawing.Point(0, 0)

#If DEBUG Then
            .TopMost = False
#Else
            'сверху всех
            .TopMost = True
#End If
        End With

        'запуск приложения
        Application.Run(oUserForm)
    End Sub

    Public ReadOnly Property NetworkStatus As Boolean
        Get
            Return oNetworkStatus
        End Get
    End Property

    ''' <summary>
    ''' проверка путей приложения
    ''' </summary>
    Private Sub CheckPaths()
        If Not IO.Directory.Exists(clsApplicationTypes.GDriveFolderPath) Then
            'запросим путь к папке с шаблонами
            Dim _template = clsApplicationTypes.TemplateFolderPath
            If Not _template = "" Then
                clsApplicationTypes.GDriveFolderPath = IO.Directory.GetParent(_template).FullName
                'установим другие пути
                clsApplicationTypes.ArhiveContainerPath = IO.Path.Combine(clsApplicationTypes.GDriveFolderPath, "arhive_photo")
                clsApplicationTypes.LabelDrawDescriptionPath = IO.Path.Combine(clsApplicationTypes.GDriveFolderPath, "Labels and draws and description")
                clsApplicationTypes.TreeFolderPath = IO.Path.Combine(clsApplicationTypes.GDriveFolderPath, "My Trees")

                clsApplicationTypes.xmldboPhotoStorePath = IO.Path.Combine(clsApplicationTypes.GDriveFolderPath, "SolutionData")
                clsApplicationTypes.LocalDataFilePath = IO.Path.Combine(clsApplicationTypes.GDriveFolderPath, "SolutionData")
                'запросим путь к папке ОБРАБОТАННЫЕ
                Dim _rp = clsApplicationTypes.PhotoManagerStarUpFolder
            End If
        End If

    End Sub

    ''' <summary>
    ''' загрузка сервисов
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub initService()
        Dim _splash = clsApplicationTypes.SplashScreen
        _splash.Show()
        Application.DoEvents()
        _service = New Service.clsApplicationTypes()
        'загружаем локальный файл UserPermission
        If Service.clsApplicationTypes.LoadUsers Then
            ''проверка доступа к online БД
            Dim _message As String = ""
            If Not ConnectToDB(_message) Then
                oNetworkStatus = False
                clsApplicationTypes.NetworkStatus = False
                MsgBox("Подключение к сети ограничено или отсутствует. Причина: " & _message, vbCritical)
            Else
                oNetworkStatus = True
                clsApplicationTypes.NetworkStatus = True
                ''загрузить и проверить (сооответствие локального userpermission данным с сервера) пользователей из on-line БД
                'If Not clsApplicationTypes.LoadUsers(True) Then
                '    clsApplicationTypes.NetworkStatus = False
                '    MsgBox("Подключение к сети ограничено или отсутствует. Причина: БД не отвечает на запрос загрузки пользователей.", vbCritical)
                'End If
            End If

            ''инициализация сервисов
            Dim _PhotoService = New Photo_reader.clsPhotoService
            Dim _OrderService = New OrdersAndClients.clsOrderService

            'названия
            Dim _treeService = New Trilbone.clsTreeService
            clsApplicationTypes.MyTrees = _treeService

            CheckPaths()

            Dim _bgSys As New BackgroundWorker()
            AddHandler _bgSys.DoWork, AddressOf MyTreesDataLoad
            AddHandler _bgSys.RunWorkerCompleted, AddressOf MyTreesNamesComplete
            _bgSys.RunWorkerAsync("Sys")

            Dim _bgLocality As New BackgroundWorker()
            AddHandler _bgLocality.DoWork, AddressOf MyTreesDataLoad
            AddHandler _bgLocality.RunWorkerCompleted, AddressOf MyTreesLocalityComplete
            _bgLocality.RunWorkerAsync("Loc")

            Dim _bgTime As New BackgroundWorker()
            AddHandler _bgTime.DoWork, AddressOf MyTreesDataLoad
            AddHandler _bgTime.RunWorkerCompleted, AddressOf MyTreesTimescaleComplete
            _bgTime.RunWorkerAsync("time")
            Dim _catalog As New clsCatalogService

            Dim _MainOrderService = New Trilbone_startup.clsMainOrderService
            Dim _excelConnService = New ConnectExcel.clsExcelService

            _splash.Close()

            If oNetworkStatus Then
                'сетевые сервисы
                Dim _RestMSService = New RestMS_Client.clsRestMS_service
                Dim _ebayTrilboneService = New ClsTrilboneEbayService
                'ebay запускается в Private Shared Sub TimerTickEventHandler(sender As Object, e As EventArgs) от таймера приложения
                Dim _ebaySearch = New Service.clsFindingService
                Dim _siteService = New Site_Nop350.clsSiteService
                Return
            End If
        Else
            _splash.Close()
            'локальный файл поврежден и не открывается
            Service.clsApplicationTypes.TemplateFolderPath = ""
            MsgBox("Невозможно загрузить данные пользователей. Приложение не будет работать.", vbCritical, "Trilbone")
        End If
    End Sub

    ''' <summary>
    ''' подключение к азуре
    ''' </summary>
    ''' <param name="_message"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Function ConnectToDB(Optional ByRef _message As String = "") As Boolean
        Dim _out As Boolean
        Dim _azurePhotoCONSTR = "Server=tcp:v0ecxr50yd.database.windows.net,1433;Database=DBOPHOTO;User ID=foto@v0ecxr50yd;Password=Asaphus2009;Trusted_Connection=false;TrustServerCertificate=True;Encrypt=True;Connection Timeout=30;"
        Dim _azureSampleCONSTR = "Server=tcp:v0ecxr50yd.database.windows.net,1433;Database=DBREADYSAMPLE;User ID=foto@v0ecxr50yd;Password=Asaphus2009;Trusted_Connection=false;TrustServerCertificate=True;Encrypt=True;Connection Timeout=30;"
        _out = _service.InitDbConnection(_message, True, _azurePhotoCONSTR, _azureSampleCONSTR)
        Return _out
    End Function
    <STAThread>
    Private Sub MyTreesDataLoad(sender As Object, e As DoWorkEventArgs)
        e.Result = clsApplicationTypes.MyTrees.GetAllNamesByVolume(e.Argument)
    End Sub

    Private Sub MyTreesNamesComplete(sender As Object, e As RunWorkerCompletedEventArgs)
        If e.Error Is Nothing Then
            clsApplicationTypes.MyTreesSystematicaNames = e.Result
        End If
    End Sub

    Private Sub MyTreesLocalityComplete(sender As Object, e As RunWorkerCompletedEventArgs)
        If e.Error Is Nothing Then
            clsApplicationTypes.MyTreesLocalityNames = e.Result
        End If
    End Sub
    Private Sub MyTreesTimescaleComplete(sender As Object, e As RunWorkerCompletedEventArgs)
        If e.Error Is Nothing Then
            clsApplicationTypes.MyTreesTimeScaleNames = e.Result
        End If
    End Sub

End Module
