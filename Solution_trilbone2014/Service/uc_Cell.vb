Imports System.Windows.Forms
Imports System.Linq
Public Class uc_Cell
#Region "Определения"
    Private oMsi As iMoySkladDataProvider
    Private oActiveWarehouse As iMoySkladDataProvider.clsEntity
    Private oSampleList As List(Of clsSampleList)
    Private oSplashscreen1 As SplashScreen1
    Private oTimer As New Timer
    Private oMCBusy As Boolean
    Dim oSampleNumberBindingSource As New BindingSource
#Region "Новые типы"
    Private Class clsSampleList
        Implements System.ComponentModel.INotifyPropertyChanged

        Implements IEquatable(Of clsApplicationTypes.clsSampleNumber)
        Implements IEqualityComparer(Of clsSampleList)
        Implements IComparable(Of clsSampleList)

        Private oIsCorrect As Boolean = False
        Private oMCDataReady As Boolean = False
        Dim oSampleNumber As clsApplicationTypes.clsSampleNumber
        Dim oGoodLocations As List(Of iMoySkladDataProvider.clsStokQuantity)
        Dim oSelectedGoodLocations As List(Of iMoySkladDataProvider.strGoodMapQty)

        Public Property SampleNumber As clsApplicationTypes.clsSampleNumber
            Get
                Return oSampleNumber
            End Get
            Set(value As clsApplicationTypes.clsSampleNumber)
                oSampleNumber = value
                RaisePropertyChanged("SampleNumber")
            End Set
        End Property


        ''' <summary>
        ''' остаток по складам. внутри 
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property GoodLocations As List(Of iMoySkladDataProvider.clsStokQuantity)
            Get
                Return oGoodLocations
            End Get
            Set(value As List(Of iMoySkladDataProvider.clsStokQuantity))
                oGoodLocations = value
                RaisePropertyChanged("GoodLocations")
            End Set
        End Property


        ''' <summary>
        ''' структура хранения для перемещения
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SelectedGoodLocations As List(Of iMoySkladDataProvider.strGoodMapQty)
            Get
                Return oSelectedGoodLocations
            End Get
            Set(value As List(Of iMoySkladDataProvider.strGoodMapQty))
                oSelectedGoodLocations = value
                RaisePropertyChanged("GoodLocations")
            End Set
        End Property

        ''' <summary>
        ''' готовность данных запроса
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property MCDataReady As Boolean
            Get
                Return oMCDataReady
            End Get
        End Property

        Public ReadOnly Property IsCorrect As Boolean
            Get
                Return oIsCorrect
            End Get
        End Property

        Public Overloads Shared Function CreateInstance(SampleNumber As String) As clsSampleList
            Dim _new = clsApplicationTypes.clsSampleNumber.CreateFromString(SampleNumber)
            Return CreateInstance(_new)
        End Function

        Public Overloads Shared Function CreateInstance(SampleNumber As clsApplicationTypes.clsSampleNumber) As clsSampleList
            If Not SampleNumber.CodeIsCorrect Then
                Return New clsSampleList With {.SampleNumber = SampleNumber, .oIsCorrect = False}
            End If
            Dim _nn As New clsSampleList
            _nn.oIsCorrect = True
            _nn.SampleNumber = SampleNumber
            Return _nn
        End Function

        Public Overrides Function ToString() As String
            If SampleNumber Is Nothing Then
                Return "неправильный"
            End If

            Dim _s As String = ""
            If Not Me.GoodLocations Is Nothing Then
                If Me.GoodLocations.Count = 0 Then
                    _s = "(o)"
                Else
                    If Me.GoodLocations.First.IsArticul Then
                        _s = String.Format("(+++)[{0}{1}]", (Aggregate c In Me.GoodLocations Into Sum(c.Stok)), Me.GoodLocations.First.UomName)
                    Else
                        _s = String.Format("(+)[{0}{1}]", (Aggregate c In Me.GoodLocations Into Sum(c.Stok)), Me.GoodLocations.First.UomName)
                    End If
                End If

            End If
            Dim _loc As String = String.Format("{0} {1} -> {2}", SampleNumber.ShotCode, _s, Me.GoodLocations.First.Name)
            Return _loc
        End Function

        Public Overrides Function GetHashCode() As Integer
            If SampleNumber Is Nothing OrElse SampleNumber.CodeIsCorrect = False Then
                Return MyBase.GetHashCode
            Else
                Return SampleNumber.GetHashCode
            End If
        End Function

        Public Overrides Function Equals(obj As Object) As Boolean
            If obj Is Nothing Then Return MyBase.Equals(obj)
            If Not TypeOf (obj) Is clsSampleList Then Return MyBase.Equals(obj)
            If CType(obj, clsSampleList).SampleNumber Is Nothing Then Return MyBase.Equals(obj)
            If Me.SampleNumber Is Nothing Then Return MyBase.Equals(obj)

            Return CType(obj, clsSampleList).SampleNumber.Equals(Me.SampleNumber)

        End Function

        Public Function Equals1(other As clsApplicationTypes.clsSampleNumber) As Boolean Implements IEquatable(Of clsApplicationTypes.clsSampleNumber).Equals
            If Me.SampleNumber Is Nothing Then Return False
            Return Me.SampleNumber.Equals(other)
        End Function

        Public Sub QueryMC()

            If Me.SampleNumber.CodeIsCorrect = False Then Return

            Dim _bg As New System.ComponentModel.BackgroundWorker
            AddHandler _bg.DoWork, AddressOf Me.StartQuery
            AddHandler _bg.RunWorkerCompleted, AddressOf Me.QueryComplete
            _bg.RunWorkerAsync()
        End Sub

        Private Sub StartQuery(sender As Object, e As System.ComponentModel.DoWorkEventArgs)
            Dim _msi = clsApplicationTypes.MoySklad(False)

            If _msi Is Nothing Then
                e.Result = Nothing
            Else
                oMCDataReady = False
                e.Result = _msi.FindStokQuantity("", SampleNumber.ShotCode, , True)
            End If

        End Sub

        Private Sub QueryComplete(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs)
            If e.Error Is Nothing Then
                Dim _res = CType(e.Result, List(Of iMoySkladDataProvider.clsStokQuantity))
                Me.GoodLocations = _res
                Dim _msi = clsApplicationTypes.MoySklad(False)
                For Each t In Me.GoodLocations
                    t.LoadCellInfo(_msi)
                Next
                oMCDataReady = True
                RaiseEvent MsInfoLoaded(Me, EventArgs.Empty)
                RaisePropertyChanged("GoodLocations")
            End If
        End Sub

        Public Event MsInfoLoaded(sender As Object, e As EventArgs)

        Public Function Equals3(x As clsSampleList, y As clsSampleList) As Boolean Implements IEqualityComparer(Of clsSampleList).Equals
            Return x.Equals(y)
        End Function

        Public Function GetHashCode2(obj As clsSampleList) As Integer Implements IEqualityComparer(Of clsSampleList).GetHashCode
            Return Me.GetHashCode
        End Function

        Public Function CompareTo(other As clsSampleList) As Integer Implements IComparable(Of clsSampleList).CompareTo
            If Me.SampleNumber Is Nothing Then Return 0
            If other.SampleNumber Is Nothing Then Return 0
            Return Me.SampleNumber.CompareTo(other.SampleNumber)
        End Function

        Public Event PropertyChanged(sender As Object, e As System.ComponentModel.PropertyChangedEventArgs) Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged

        Private Sub RaisePropertyChanged(propertyname As String)
            RaiseEvent PropertyChanged(Me, New System.ComponentModel.PropertyChangedEventArgs(propertyname))
        End Sub

    End Class

#End Region


#End Region

#Region "Инициализация"
    Public Sub init(omsi As iMoySkladDataProvider)
        Me.oMsi = omsi

        'iMoySkladDataProvider.clsEntity

        Me.cbWarehouseList.DataSource = omsi.GetWarehouseList

        oSampleList = New List(Of clsSampleList)
        oSampleNumberBindingSource.DataSource = oSampleList

        Me.lbxSampleList.DataSource = oSampleNumberBindingSource
        Me.lbxSampleList.DisplayMember = "ShotCode"
        Me.lbxSampleList.SelectionMode = SelectionMode.MultiExtended


        Dim _lst As New List(Of iMoySkladDataProvider.clsClientInfo)
        _lst.Add(iMoySkladDataProvider.clsClientInfo.Empty)
        _lst(0).FullName = ""
        _lst.AddRange(omsi.GetClients)
        Me.cbConsumer.DataSource = _lst

        Dim _lst2 As New List(Of iMoySkladDataProvider.clsEntity)
        _lst2.Add(iMoySkladDataProvider.clsEntity.Empty)
        _lst2.AddRange(omsi.GetWarehouseList)
        Me.cbTargetWare.DataSource = _lst2

        Me.oSplashscreen1 = clsApplicationTypes.SplashScreen

        Me.oTimer.Interval = 300

        AddHandler oTimer.Tick, AddressOf TimerTickEventHandler
        oMCBusy = False
        Me.oTimer.Start()

    End Sub

    Private Sub Clear()
        Me.cbWarehouseList.SelectedIndex = -1
        oSampleList.Clear()
    End Sub

#End Region

#Region "Работа со списком номеров"

    Private Sub TimerTickEventHandler(sender As Object, e As EventArgs)
        If oSampleList Is Nothing Then Return
        'запрос в процессе - ждем
        If oMCBusy Then Return

        'проверка запуска опроса МС
        For Each t In oSampleList
            If Not t.MCDataReady Then
                t.QueryMC()
                oMCBusy = True
                Exit For
            End If
        Next
    End Sub


    ''' <summary>
    ''' добавить в список БЕЗ ПРОВЕРКИ???
    ''' </summary>
    ''' <param name="samplenumber"></param>
    ''' <remarks></remarks>
    Private Overloads Sub AddSampleInList(samplenumber As String)
        Dim _sm = clsApplicationTypes.clsSampleNumber.CreateFromString(samplenumber)
        If _sm.CodeIsCorrect Then
            Me.AddSampleInList(_sm)
        End If
    End Sub

    Private Overloads Sub AddSampleInList(samplenumber As clsApplicationTypes.clsSampleNumber)
        Dim _sm = clsSampleList.CreateInstance(samplenumber)
        If Not oSampleList.Contains(_sm) Then
            AddHandler _sm.MsInfoLoaded, AddressOf Me.MsInfoLoadedEventHandler
            oSampleList.Add(_sm)
            oSampleList.Sort()

            Me.oSampleNumberBindingSource.ResetBindings(False)
            Me.lbxSampleList.Refresh()
            tbSampleNumber.Text = ""
            clsApplicationTypes.BeepYES()
        End If
    End Sub
    Private Sub RemoveSampleInList(samplenumber As String)
        Dim _sm = clsSampleList.CreateInstance(samplenumber)
        oSampleList.Remove(_sm)
        Me.oSampleNumberBindingSource.ResetBindings(False)
    End Sub
    Private Sub btAddNumber_Click(sender As Object, e As EventArgs) Handles btAddNumber.Click
        Me.AddSampleInList(Me.tbSampleNumber.Text)
    End Sub
    ''' <summary>
    ''' ввод кода
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub lbxSampleList_KeyPress(sender As Object, e As KeyPressEventArgs) Handles lbxSampleList.KeyPress
        Static _buff As String
        Select Case Asc(e.KeyChar)
            Case 13
                Me.AddSampleInList(_buff)
                _buff = ""
                e.Handled = True
            Case Else
                _buff = _buff & e.KeyChar.ToString
                Me.tbSampleNumber.Text = _buff
                e.Handled = True
        End Select
    End Sub
    Private Sub btRemoveFromList_Click(sender As Object, e As EventArgs) Handles btRemoveFromList.Click
        If Me.lbxSampleList.SelectedItem Is Nothing Then Return
        Me.RemoveSampleInList(CType(Me.lbxSampleList.SelectedItem, clsSampleList).SampleNumber.ShotCode)
    End Sub
    Private Sub tbSampleNumber_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbSampleNumber.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Me.btAddNumber_Click(Me.btAddNumber, EventArgs.Empty)
        End If
    End Sub
    ''' <summary>
    ''' добавить из ячейки
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btGetFromCell_Click(sender As Object, e As EventArgs) Handles btGetFromCell.Click
        Dim _cell As iMoySkladDataProvider.clsEntity = Me.cbCellList.SelectedItem
        If _cell Is Nothing Then
            MsgBox("Надо выбрать ячейку-источник", vbCritical)
            Return
        End If

        Select Case MsgBox(String.Format("Поместить все образцы из ячейки {0} в список?", _cell.Value, oActiveWarehouse.Value), vbYesNo)
            Case MsgBoxResult.Yes
                Dim _message As String = ""
                Dim _status As Integer = -1
                Dim _result = oMsi.FindGoodsByCell(WarehouseName:=oActiveWarehouse.Value, SlotName:=_cell.Value, _status:=_status, _message:=_message)
                If Not _result.Count > 0 Then
                    MsgBox(String.Format("Ячейка {0} пуста", _cell.Value))
                Else
                    For Each t In _result
                        Me.AddSampleInList(t.ActualSampleNumber)
                        Application.DoEvents()
                    Next
                End If

        End Select

    End Sub

#End Region

#Region "Управление складами и ячейками"
    ''' <summary>
    ''' смена основного склада
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cbWarehouseList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbWarehouseList.SelectedIndexChanged
        oActiveWarehouse = cbWarehouseList.SelectedItem
        'список ячеек склада
        Dim _lst2 As New List(Of iMoySkladDataProvider.clsEntity)
        _lst2.Add(iMoySkladDataProvider.clsEntity.Empty)
        _lst2(0).Value = "без размещения"
        _lst2.AddRange(oMsi.GetSlotList(oActiveWarehouse.UUID))
        Me.cbTargetCell.DataSource = _lst2
        Me.cbCellList.DataSource = _lst2
    End Sub

    ''' <summary>
    ''' смена целевого склада
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cbTargetWare_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbTargetWare.SelectedIndexChanged
        If cbTargetWare.SelectedItem Is Nothing Then Return
        Dim _item As iMoySkladDataProvider.clsEntity = cbTargetWare.SelectedItem

        Dim _lst2 As New List(Of iMoySkladDataProvider.clsEntity)
        _lst2.Add(iMoySkladDataProvider.clsEntity.Empty)
        _lst2(0).Value = "без размещения"
        _lst2.AddRange(oMsi.GetSlotList(_item.UUID))
        'ячейки выбранного склада
        Me.cbTargetCellInWare.DataSource = _lst2

    End Sub

#End Region


#Region "движок создания доков"

    Private Structure strOperations

        ''' <summary>
        ''' Ошибки аргументов структуры
        ''' </summary>
        ''' <remarks></remarks>
        Public ArgumentError As Boolean

        ''' <summary>
        ''' нет карточки товара
        ''' </summary>
        ''' <remarks></remarks>
        Public MSGoodError As Boolean
        ''' <summary>
        ''' карточек товара по коду более одной
        ''' </summary>
        ''' <remarks></remarks>
        Public MSGoodTwice As Boolean

        ''' <summary>
        ''' остатка для операций нет
        ''' </summary>
        ''' <remarks></remarks>
        Public MSZeroQTY As Boolean

        Public Message As String

        Public GoodNumber As clsApplicationTypes.clsSampleNumber

        ''' <summary>
        ''' ИД перемещаемого товара
        ''' </summary>
        ''' <remarks></remarks>
        Public GoodUUID As String


        ''' <summary>
        ''' перемещаемое количество
        ''' </summary>
        ''' <remarks></remarks>
        Public OperationQTY As Decimal

        ''' <summary>
        ''' если есть возможность, то передать этот обьект = сократим запросы
        ''' </summary>
        ''' <remarks></remarks>
        Public GoodRef As iMoySkladDataProvider.strGoodMapQty

        ''' <summary>
        ''' склад-источник
        ''' </summary>
        ''' <remarks></remarks>
        Public SourceWare As String

        ''' <summary>
        ''' ячейка-источник
        ''' </summary>
        ''' <remarks></remarks>
        Public SourceSlot As String

        ''' <summary>
        ''' склад-получатель
        ''' </summary>
        ''' <remarks></remarks>
        Public TargetWare As String

        ''' <summary>
        ''' ячейка-получатель
        ''' </summary>
        ''' <remarks></remarks>
        Public TargetSlot As String


        Public oMsi As iMoySkladDataProvider

        Public OperationType

    End Structure

    Private Enum emOperationType
        move

    End Enum


    Private Shared Function OperationProccess(oplist As List(Of strOperations)) As Integer
        If oplist.Count = 0 Then Return 0

        'проверяем кол-во и наличие товаров
        For Each t In oplist
            If String.IsNullOrEmpty(t.SourceWare) Then
                t.ArgumentError = True
                t.Message = "не указан склад-источник"
                Continue For
            End If

            If t.GoodNumber Is Nothing OrElse t.GoodNumber.CodeIsCorrect = False Then
                t.ArgumentError = True
                t.Message = "номер товара не задан или задан неверно"
                Continue For
            End If

            If t.GoodRef.Empty = True Then
                'формируем структуру t.GoodRef
                Do Until t.oMsi.Busy
                    'занят другим запросом
                Loop
                t.oMsi.Busy = True
                'проверка в МС
                Dim _result = t.oMsi.FindGoods("", t.GoodNumber.ShotCode)

                Select Case _result.Count
                    Case 0
                        t.MSGoodError = True
                        t.Message = "карточка товара отсутствует"
                    Case 1
                        'ок
                        'остаток по складу-источнику
                        If String.IsNullOrEmpty(t.SourceWare) Then
                            'остаток с конкретного склада

                        End If
                        Dim _slinfo = t.oMsi.FindStokQuantity(PartName:="", ShotCode:="", GoodUUID:=_result(0).UUID, IncludeReserved:=True, WareHouseName:=t.SourceWare)
                        Select Case _slinfo.Count
                            Case 0
                                'нет остатка
                                t.MSZeroQTY = True
                                t.Message = "нет остатка по складу"
                            Case Else
                                Dim _qty = Aggregate c In _slinfo Into Sum(c.Quantity)
                                If _qty = 0 Then
                                    t.MSZeroQTY = True
                                    t.Message = "нет остатка по складу"
                                ElseIf t.OperationQTY = 0 Then
                                    'кол-во для операции не задано
                                    t.MSZeroQTY = True
                                    t.Message = "кол-во для операции не задано"
                                ElseIf t.OperationQTY > _qty Then
                                    t.MSZeroQTY = True
                                    t.Message = "остаток по складу МЕНЬШЕ кол-ва для операции"
                                Else
                                    'NB! кол-во товара для операции задается при формировании структуры
                                    t.GoodRef = New iMoySkladDataProvider.strGoodMapQty
                                    With t.GoodRef
                                        .code = _result(0).Code
                                        .ProductCode = _result(0).Articul
                                        .UUID = _result(0).UUID
                                        .UomName = _result(0).UomName
                                        .Qty = t.OperationQTY
                                    End With

                                End If
                        End Select
                    Case Else
                        t.MSGoodTwice = True
                        t.Message = "повторение карточки товара"
                End Select
            End If
        Next

        'запись документов



        'группируем по складам - источникам
        'будут созданы отдельные документы
        Dim _group1 = From c In oplist Where Not (c.MSGoodError Or c.MSGoodTwice Or c.MSZeroQTY Or c.ArgumentError) Group opl = c By ware = c.SourceWare Into oplistss = Group

        Dim _index As Integer = 0

        For Each _wr In _group1
            'Dim _source = _wr.ware
            'группируем по складам - получателям
            Dim _group2 = From c In _wr.oplistss Group c By c.TargetWare Into oplisttt = Group
            For Each _wtr In _group2
                'собираем позиции в документ
                'Dim _target = _wtr.TargetWare
                Dim _copl = _wtr.oplisttt.ToList
                For Each _op In _copl
                    'добавляем инфу о перемещении
                    With _op.GoodRef
                        .WareName = _wtr.TargetWare
                        .SlotName = _op.SourceSlot
                        .NewSlotName = _op.TargetSlot
                    End With
                Next

                Dim _opgroup = From c In _wtr.oplisttt Group c By c.OperationType Into opop = Group

                'группа по операциям
                For Each t In _opgroup
                    Select Case t.OperationType
                        Case emOperationType.move
                            'создать документ перемещения
                            Dim _result = oplist(0).oMsi.CreateMove(sourceStoreName:=_wr.ware, targetStoreName:=_wtr.TargetWare, goodList:=(From c In t.opop Select c.GoodRef).ToArray, MoveState:=iMoySkladDataProvider.emMoveState.poYacheikam)
                            If Not _result.HasError Then
                                _index += 1
                            End If
                        Case Else
                            'TODO
                    End Select
                Next
            Next
        Next

        ' _index показывает кол-во успешных документов

        Return _index

    End Function

#End Region

#Region "Операции со списком образцов"



#End Region

    Private Sub btRemoveFromCells_Click(sender As Object, e As EventArgs) Handles btRemoveFromCells.Click
        Dim _a = From c In oSampleList Select New strOperations With {.GoodNumber = c.SampleNumber, .oMsi = oMsi, .OperationQTY = 0, .SourceWare = "", .SourceSlot = "", .TargetWare = "", .TargetSlot = ""}


    End Sub
    ''' <summary>
    ''' событие окончания запроса
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MsInfoLoadedEventHandler(sender As Object, e As EventArgs)
        oSampleNumberBindingSource.ResetBindings(False)
        'мс освободился
        oMCBusy = False
    End Sub
    ''' <summary>
    ''' отображение окна с количеством
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub lbxSampleList_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lbxSampleList.MouseDoubleClick
        If lbxSampleList.SelectedItem Is Nothing Then Return

        Dim _item = CType(Me.lbxSampleList.SelectedItem, clsSampleList)
        'Dim _i = lbxSampleList.GetChildAtPoint(lbxSampleList.PointToScreen(e.Location))


        If e.Button = Windows.Forms.MouseButtons.Left Then
            If _item.GoodLocations Is Nothing Then Return
            If _item.GoodLocations.Count = 0 Then Return
            Dim _fm = New Windows.Forms.Form
            Dim _uc As New Service.ucLocationInfo

            ''поиск данных о ячейках
            'Dim _data As New List(Of iMoySkladDataProvider.strGoodMapQty)
            'For Each t In _item.GoodLocations
            '    't.LoadCellInfo(oMsi)
            '    _data.AddRange(t.GoodMapQty)
            'Next
            Dim _t = _item.GoodLocations.SelectMany(Function(x) (x.GoodMapQty)).ToList
            _uc.Init(_t)
            _fm.Width = _uc.Width + 10
            _fm.Height = _uc.Height + 10
            _fm.Controls.Add(_uc)
            _fm.StartPosition = FormStartPosition.CenterParent
            _fm.Text = "Размещение по ячейкам"
            _uc.Dock = DockStyle.Fill
            _fm.ShowDialog(Me)
        End If
    End Sub

   

    ''' <summary>
    ''' показывает картинки
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub lbxSampleList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbxSampleList.SelectedIndexChanged
        If Me.lbxSampleList.SelectedItem Is Nothing Then Me.PictureBox1.Image = Nothing : Return
        Dim _item = CType(Me.lbxSampleList.SelectedItem, clsSampleList)
        Dim _picture = clsApplicationTypes.SamplePhotoObject.GetMainImage(clsFilesSources.Arhive, _item.SampleNumber, True)

        Me.PictureBox1.Image = _picture
    End Sub

    Private Sub btClear_Click(sender As Object, e As EventArgs) Handles btClear.Click
        oSampleList.Clear()
        Me.oSampleNumberBindingSource.ResetBindings(False)
    End Sub
End Class
