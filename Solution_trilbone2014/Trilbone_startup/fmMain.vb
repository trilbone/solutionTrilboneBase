Imports System.Windows.Forms
Imports Service.clsApplicationTypes
Imports System.Linq

Imports Service
Public Class fmMain

    Private m_ChildFormNumber As Integer
    Dim oBindingOrder As Windows.Forms.BindingSource
    Dim o_orders As Collections.Generic.List(Of clsOrder)

#Region "ctor"
    ''' <summary>
    ''' connectTo - текст появиться в строке статуса формы
    ''' </summary>
    ''' <param name="connectTo"></param>
    ''' <remarks></remarks>
    Public Sub New(connectTo As String)
        Me.New()
        Me.ToolStripStatusLabel.Text = connectTo
    End Sub
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        'заблокировать кнопки для лузеров
        Select Case Global.Service.clsApplicationTypes.GetAccess("Доступ к заказам")
            Case True
                ЗаказыToolStripMenuItem.Enabled = True
                'получить список заказов
                'по запросу выполняем вызов из сервиса
                'если делегата нет, то сервис недоступен
                If Not Global.Service.clsApplicationTypes.DelegateStoreOrdersList Is Nothing Then
                    'сервис зарегестрирован - вызываем
                    oBindingOrder = New Windows.Forms.BindingSource
                    o_orders = Global.Service.clsApplicationTypes.DelegateStoreOrdersList.Invoke()
                    o_orders.Sort()
                    oBindingOrder.DataSource = o_orders
                    Me.ToolStripComboBox1.ComboBox.DataSource = oBindingOrder
                    Me.ToolStripComboBox1.ComboBox.DisplayMember = "OrderID"
                End If

                Me.DbInfo1ToolStripMenuItem.Enabled = True
                Me.tsb_DBinfo.Enabled = True

            Case False

                Me.OptionsToolStripMenuItem.Enabled = True

                If Not Global.Service.clsApplicationTypes.GetAccess("Доступ к списку фоток") Then
                    'просмотр списка фоток по базе
                    Me.PhotoViewToolStripMenuItem.Enabled = False
                End If

                ЗаказыToolStripMenuItem.Enabled = False
                Me.ToolStrip.Enabled = False
                Me.FileMenu.Enabled = False
                Me.ToolStripMenuItem2.Enabled = False
                Me.ExcelConnectToolStripMenuItem1.Enabled = False
                Me.SampleInfoToolStripMenuItem.Enabled = False
                Me.ReadyForSaleToolStripMenuItem.Enabled = False
                Me.SynchronizationToolStripMenuItem1.Enabled = False
                Me.EbayToolStripMenuItem.Enabled = False
                Me.SiteToolStripMenuItem.Enabled = False

                Me.DbInfo1ToolStripMenuItem.Enabled = False
                Me.tsb_DBinfo.Enabled = False
        End Select

        If Not Global.Service.clsApplicationTypes.GetAccess("настройки Trilbone") Then
            Me.OptionsToolStripMenuItem.Enabled = False
            Me.СлужебныеToolStripMenuItem.Enabled = False
        End If
    End Sub
#End Region

#Region "Utilites"

    Private Sub ShowOrderForm(ByVal orderID As String)
        Dim _param As Object = {orderID}
        Me.CallAnyForm(emFormsList.fmOrders, _param)

        For Each _tmp As clsOrder In oBindingOrder.List
            If _tmp.OrderID = Trim(orderID) Then
                Me.ToolStripComboBox1.ComboBox.SelectedItem = _tmp
            End If
        Next
        clsMainOrderService.ActiveOrder = CType(Me.oBindingOrder.Current, clsOrder)
    End Sub

    ''' <summary>
    ''' проверяет код, если код не верный, возвращает 0
    ''' </summary>
    ''' <param name="_number"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetNumberFromString(ByVal _number As String, Optional ByRef _numberObj As clsSampleNumber = Nothing) As Decimal
        Dim _n As Service.clsApplicationTypes.clsSampleNumber = Service.clsApplicationTypes.clsSampleNumber.CreateFromString(_number)
        If Not _n Is Nothing Then
            _numberObj = _n
            Return _n.GetEan13
        End If

        _numberObj = Nothing
        Return 0
    End Function

    Private Sub CallfmSampleInfo(Optional ByVal SampleNumber As Service.clsApplicationTypes.clsSampleNumber = Nothing)


        Dim _param As Object

        If SampleNumber Is Nothing Then
            _param = {}
        Else
            _param = {SampleNumber}
        End If

        Me.CallAnyForm(emFormsList.fmSampleInfo, _param)
    End Sub

    ''' <summary>
    ''' вернет форму работы с образцом
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property SampleData As Form
        Get
            Dim _SampleNumber As Decimal = 0
            Dim _param As Object = {_SampleNumber}
            Dim _fm = CallAnyForm(emFormsList.fmSampleData, _param)
            Application.DoEvents()
            Return _fm
        End Get
    End Property




    ''' <summary>
    ''' вызовет любую дочернюю форму
    ''' </summary>
    ''' <param name="formName"></param>
    ''' <param name="Parameter"></param>
    ''' <param name="isMDIchildren"></param>
    ''' <remarks></remarks>
    Public Function CallAnyForm(ByVal formName As emFormsList, ByVal Parameter As Object, Optional isMDIchildren As Boolean = True) As Form

        Dim _fm = clsApplicationTypes.CallAnyForm(formName, Parameter)
        If _fm Is Nothing Then Return Nothing

        Static _horiz As Integer = -10

        If isMDIchildren Then
            _fm.MdiParent = Me
            _fm.StartPosition = FormStartPosition.Manual
            Dim _active = Me.ActiveMdiChild
            If _active Is Nothing Then
                _fm.SetDesktopLocation(0, 0)
            Else
                Dim _loc = _active.Location
                _loc.Offset(30, 0)
                _fm.Location = _loc
            End If
        Else
            _fm.StartPosition = FormStartPosition.CenterScreen
        End If


        Try
            _fm.Show()
            If formName = emFormsList.fmMoySklad Then
                If TypeOf Parameter Is Array AndAlso CType(Parameter, Array).Length > 0 Then
                    CType(_fm, Object).SetSample(Parameter(0), "")
                End If
            End If
            Return _fm
        Catch ex As Exception
            Return Nothing
        End Try
        Return Nothing
    End Function

#End Region

#Region "События самой формы"

    Private Sub fmMain_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        If clsApplicationTypes.RFIDmanager.IsScannerMode Then
            btScannerON.BackColor = Color.Red
            'btScannerON.Enabled = False
        Else
            btScannerON.BackColor = Color.FromKnownColor(KnownColor.Control)
            'btScannerON.Enabled = True
        End If
    End Sub


    Private Sub fmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Me.MdiChildren.Length = 0 Then
            Call SampleDataToolStripMenuItem_Click(Me, New System.EventArgs)
        End If
    End Sub


#End Region


#Region "Строка меню"
    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub
    Private Sub ToolBarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ToolBarToolStripMenuItem.Click
        Me.ToolStrip.Visible = Me.ToolBarToolStripMenuItem.Checked
    End Sub
    Private Sub StatusBarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles StatusBarToolStripMenuItem.Click
        Me.StatusStrip.Visible = Me.StatusBarToolStripMenuItem.Checked
    End Sub
    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CascadeToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub
    Private Sub TileVerticalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TileVerticalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub
    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TileHorizontalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub
    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ArrangeIconsToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub
    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CloseAllToolStripMenuItem.Click
        ' Close all child forms of the parent.
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub
    Private Sub OptionsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptionsToolStripMenuItem.Click
        ' Create a new instance of the child form.
        Dim ChildForm As New fmOptions
        ' Make it a child of this MDI form before showing it.
        ChildForm.MdiParent = Me
        m_ChildFormNumber += 1
        ChildForm.Text = "Options"
        ChildForm.Show()
    End Sub
    Private Sub ToolStriptbOrderName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'oBindingOrder.DataSource.sort()
    End Sub

    Private Sub ToolStripButtonNewOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'new order
        Dim _newOrderID As String = InputBox("New orderID: max 8 chars")
        If _newOrderID.Length = 0 Or _newOrderID.Length > 8 Then

            MsgBox("Неправильное имя заказа", MsgBoxStyle.Critical)
            Exit Sub

        End If

        Me.ShowOrderForm(_newOrderID)

        'получить список заказов
        Dim _orders As Collections.Generic.List(Of clsOrder)

        'по запросу выполняем вызов из сервиса
        'если делегата нет, то сервис недоступен
        If Not Global.Service.clsApplicationTypes.DelegateStoreOrdersList Is Nothing Then
            'сервис зарегестрирован - вызываем
            _orders = Global.Service.clsApplicationTypes.DelegateStoreOrdersList.Invoke()
            _orders.Sort()
            oBindingOrder.DataSource = _orders
        End If

    End Sub


    Private Sub SampleDataToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SampleDataToolStripMenuItem2.Click
        'синхронизация SampleData
        Select Case Global.Service.clsApplicationTypes.DataStoreSource
            Case emStoreSourses.dbo
                'работаем с БД
                Dim _xml As String
                Dim _result As Boolean
                Dim _sourse As String
                'задать файл
                Dim _file As New Windows.Forms.OpenFileDialog
                _file.Filter = "XML |*.xml"
                _file.Multiselect = False
                _file.CheckFileExists = True

                Select Case _file.ShowDialog
                    Case Windows.Forms.DialogResult.OK
                        Dim _reader As New IO.StreamReader(_file.OpenFile)

                        _xml = _reader.ReadToEnd

                        If Not _xml = "" Then
                            'по запросу выполняем вызов из сервиса
                            'Dim _param As Object = {_xml}
                            'если делегата нет, то сервис недоступен
                            If Not Global.Service.clsApplicationTypes.DelegatStoreSynchroSampleDataDbo Is Nothing Then
                                'сервис зарегестрирован - вызываем
                                _result = Global.Service.clsApplicationTypes.DelegatStoreSynchroSampleDataDbo.Invoke(_xml)
                            Else
                                _result = False
                            End If
                        Else
                            _result = False
                        End If

                        _reader.Close()
                End Select

                If _result = False Then
                    MsgBox("Синхронизация невозможна. Сбой при работе.", MsgBoxStyle.Critical)
                Else

                    _sourse = _file.FileName
                    _file.Dispose()
                    'копируем в Базу синхронизаций
                    Dim _root As String = My.Application.Info.DirectoryPath
                    _root = IO.Path.Combine(_root, "SynchroSampleDataBase")
                    If Not My.Computer.FileSystem.DirectoryExists(_root) Then
                        My.Computer.FileSystem.CreateDirectory(_root)
                    End If
                    My.Computer.FileSystem.CopyFile(_sourse, IO.Path.Combine(_root, Date.Now.ToShortDateString & "_synchro.xml"), False, FileIO.UICancelOption.DoNothing)

                    My.Computer.FileSystem.DeleteFile(_sourse, FileIO.UIOption.AllDialogs, FileIO.RecycleOption.SendToRecycleBin)

                    'IO.File.Delete(_sourse)

                    MsgBox("Синхронизация прошла успешно. Файл удален.", MsgBoxStyle.Information)

                End If



            Case emStoreSourses.xml
                MsgBox("Синхронизация невозможна. Нет прав доступа.", MsgBoxStyle.Critical)

        End Select

    End Sub


#Region "вызов дочерних форм"

    ''' <summary>
    ''' форма fmSampleData
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub SampleDataToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SampleDataToolStripMenuItem.Click
        Dim _SampleNumber As Decimal = 0
        Dim _param As Object = {_SampleNumber}
        CallAnyForm(emFormsList.fmSampleData, _param)
    End Sub


    Private Sub SampleInfoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SampleInfoToolStripMenuItem.Click
        Me.CallfmSampleInfo()
    End Sub

    Private Sub ToolStripButtonShowOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'show order
        Me.ShowOrderForm(CType(Me.oBindingOrder.Current, clsOrder).OrderID)
    End Sub

    Private Sub PhotoViewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PhotoViewToolStripMenuItem.Click
        Dim _param As Object = {}
        CallAnyForm(emFormsList.fmPhotoList, _param)
    End Sub


    Private Sub OpenFile(ByVal sender As Object, ByVal e As EventArgs) Handles OpenToolStripMenuItem.Click, OpenToolStripButton.Click
        ''open photo view
        Me.CallAnyForm(emFormsList.fmCatalogSample, Nothing)
    End Sub


    Private Sub ReadyForSaleToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReadyForSaleToolStripMenuItem.Click
        Dim _SampleNumber As Decimal = 0
        'по запросу выполняем вызов из сервиса
        'если делегата нет, то сервис недоступен

        Dim _param As Object = {_SampleNumber}
        Me.CallAnyForm(emFormsList.fmSampleOnSale, _param)
    End Sub

    Private Sub ImageManagerToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ImageManagerToolStripMenuItem.Click
        Dim _param As Object = {}
        CallAnyForm(emFormsList.fmImageManager, _param)
    End Sub
    Private Sub DbInfo1ToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DbInfo1ToolStripMenuItem.Click, tsb_DBinfo.Click
        Dim _param As Object = {}
        CallAnyForm(emFormsList.fmDBInfo1, _param, False)
    End Sub

    Private Sub TreesToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles TreesToolStripMenuItem.Click
        Dim _param As Object = Nothing
        CallAnyForm(emFormsList.fmDescriptionTreeBuilder, _param, False)
    End Sub

    Private Sub СпискиToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles СпискиToolStripMenuItem.Click
        Dim _fileName = "имя_файла"
        'в дальнейшем можно задать имя файла списка для просмотра
        Dim _param As Object = {""}
        CallAnyForm(emFormsList.fmListManager, _param)
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripMenuItem2.Click
        Dim _param As Object = {}
        CallAnyForm(emFormsList.fmCatalogConnect, _param)
    End Sub

    Private Sub ExcelConnectToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles ExcelConnectToolStripMenuItem1.Click
        'call form
        Me.CallAnyForm(emFormsList.fmExcelConnection, {})
    End Sub


    Private Sub УправлениеXMLОбразцаToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles УправлениеXMLОбразцаToolStripMenuItem.Click
        Me.CallAnyForm(emFormsList.fmCatalogSample, Nothing, False)
    End Sub



    Private Sub МойСкладToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles МойСкладToolStripMenuItem.Click
        Dim _param As Object = ""
        CallAnyForm(emFormsList.fmMoySklad, _param, False)
    End Sub

    Private Sub КалькуляторЛотовToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles КалькуляторЛотовToolStripMenuItem.Click
        Dim _param As Object = ""
        CallAnyForm(emFormsList.fmCalculator, _param, False)
    End Sub

    Private Sub TrilboneEbayToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TrilboneEbayToolStripMenuItem.Click
        Dim _param As Object = ""
        CallAnyForm(emFormsList.fmTrilboneEbay, _param, False)
    End Sub

    Private Sub EBaySearchToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EBaySearchToolStripMenuItem.Click
        Dim _param As Object = ""
        CallAnyForm(emFormsList.fmEbaySearch, _param, False)
    End Sub
#End Region
#End Region

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btScannerON_Click(sender As Object, e As EventArgs) Handles btScannerON.Click
        If btScannerON.BackColor = Color.Red Then
            clsApplicationTypes.RFIDmanager.StopScanner()
            btScannerON.BackColor = Color.FromKnownColor(KnownColor.Control)
        Else
            clsApplicationTypes.RFIDmanager.StartScanner()
            btScannerON.BackColor = Color.Red
        End If

    End Sub

    Private Sub btRestartRFID_Click(sender As Object, e As EventArgs) Handles btRestartRFID.Click
        Dim _m = clsApplicationTypes.RFIDmanager(True)
    End Sub

    Private Sub SiteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SiteToolStripMenuItem.Click
        Dim _param As Object = Me
        CallAnyForm(emFormsList.fmSite, _param, False)
    End Sub

    Private Sub МойСкладToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles МойСкладToolStripMenuItem1.Click
        Dim _sm = clsApplicationTypes.clsSampleNumber.CreateFromString(Me.tbMCNumber.Text)
        Dim _param As Object = ""
        If _sm.CodeIsCorrect Then
            _param = {_sm.ShotCode}
        End If
        Me.tbMCNumber.Text = ""
        Dim _result = CallAnyForm(emFormsList.fmMoySklad, _param, False)

    End Sub

    Private Sub tbMCNumber_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbMCNumber.KeyPress
        If Asc(e.KeyChar) = 13 Then
            МойСкладToolStripMenuItem1_Click(МойСкладToolStripMenuItem1, EventArgs.Empty)
        End If
    End Sub


    Private Sub ПоказатьToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ПоказатьToolStripMenuItem.Click
        Me.ShowOrderForm(CType(Me.oBindingOrder.Current, clsOrder).OrderID)
    End Sub

    Private Sub ToolStripLabel1_Click(sender As Object, e As EventArgs) Handles ToolStripLabel1.Click
        Dim _param As Object = Nothing
        CallAnyForm(emFormsList.fmDescriptionTreeBuilder, _param, False)
    End Sub

    Private Sub ToolStripComboBox1_Click(sender As Object, e As EventArgs) Handles ToolStripComboBox1.Click
        Me.ToolStripTextBox1.Text = CType(sender.selecteditem, clsOrder).ClientFullName
        clsMainOrderService.ActiveOrder = CType(sender.selecteditem, clsOrder)
    End Sub


End Class
