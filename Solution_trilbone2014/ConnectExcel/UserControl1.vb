Imports Service
Public Class uc_Sample_data
    Private oData As String()
    Private oColumnCount As Integer
    Public Event NeedNext(ByVal sender As Object, ByVal e As System.EventArgs)
    Public Event RefreshData(ByVal sender As Object, ByVal e As System.EventArgs)
    Public Event DataSavedToDB(ByVal result As Integer)

    Private oConfirmOrder As New ConfirmOrder

#Region "добавление нового nud_"

    Private Sub nupChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles nud_date.ValueChanged, nud_fossil_leight.ValueChanged, nud_fossil_name.ValueChanged, nud_stone_Name.ValueChanged, nud_stone_Number.ValueChanged, nud_stone_width.ValueChanged, nud_stone_weight.ValueChanged, nud_fossil_width.ValueChanged, nud_stone_leight.ValueChanged, nud_description.ValueChanged, nud_start_price.ValueChanged, nud_sold_price.ValueChanged, nud_stone_height.ValueChanged
        Me.refresh_controls()
    End Sub
    Public Sub New()

        ' Этот вызов является обязательным для конструктора.
        InitializeComponent()

        ' Добавьте все инициализирующие действия после вызова InitializeComponent().
        nud_date.Value = 0
        nud_fossil_leight.Value = 0
        nud_fossil_name.Value = 0
        nud_stone_Name.Value = 0
        nud_stone_Number.Value = 0
        nud_stone_width.Value = 0
        nud_stone_height.Value = 0
        nud_stone_weight.Value = 0
        nud_fossil_width.Value = 0
        nud_stone_leight.Value = 0
        nud_description.Value = 0
        nud_start_price.Value = 0
        nud_sold_price.Value = 0

    End Sub

    ''' <summary>
    ''' занесение данных 
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub refresh_controls()
        Dim _upbound As Integer = oData.Length
        Me.lbDBResult.Text = "результат?"
        'заполнить элементы
        '-----start price----
        With Me.nud_start_price
            If .Value > _upbound Then
                .BackColor = Drawing.Color.Red
            ElseIf .Value = 0 Then
                .BackColor = Drawing.Color.Blue
            Else
                Try
                    Me.tb_start_price.Text = oData(.Value - 1).ToString
                    .BackColor = Color.FromKnownColor(KnownColor.Window)
                Catch ex As Exception
                    Me.tb_start_price.Text = ""
                    .BackColor = Drawing.Color.Red
                End Try
            End If
        End With

        '-----sold price----
        With Me.nud_sold_price
            If .Value > _upbound Then
                .BackColor = Drawing.Color.Red
            ElseIf .Value = 0 Then
                .BackColor = Drawing.Color.Blue
            Else
                Try
                    Me.tb_sold_price.Text = oData(.Value - 1).ToString
                    .BackColor = Color.FromKnownColor(KnownColor.Window)
                Catch ex As Exception
                    Me.tb_sold_price.Text = ""
                    .BackColor = Drawing.Color.Red
                End Try
            End If
        End With

        '-----description----
        With Me.nud_description
            If .Value > _upbound Then
                .BackColor = Drawing.Color.Red
            ElseIf .Value = 0 Then
                .BackColor = Drawing.Color.Blue
            Else
                Try
                    Me.rtb_description.Text = oData(.Value - 1).ToString
                    .BackColor = Color.FromKnownColor(KnownColor.Window)
                Catch ex As Exception
                    Me.rtb_description.Text = ""
                    .BackColor = Drawing.Color.Red
                End Try
            End If
        End With



        '------number-------------
        With Me.nud_stone_Number
            If .Value > _upbound Then
                .BackColor = Drawing.Color.Red
            ElseIf .Value = 0 Then
                .BackColor = Drawing.Color.Blue
            Else
                Try
                    'преобразовать номер
                    'clsApplicationTypes.clsSampleNumber.GetFullCodeByShot(oData(.Value - 1).ToString)
                    Me.tb_stone_Number.Text = clsApplicationTypes.clsSampleNumber.GetFullCodeByShot(oData(.Value - 1).ToString)
                    .BackColor = Drawing.Color.FromKnownColor(KnownColor.Window)
                Catch ex As Exception
                    Me.tb_stone_Number.Text = ""
                    .BackColor = Drawing.Color.Red
                End Try


            End If
        End With


        '-----stone name-----
        With Me.nud_stone_Name
            If .Value > _upbound Then
                .BackColor = Drawing.Color.Red
            ElseIf .Value = 0 Then
                .BackColor = Drawing.Color.Blue

            Else
                Me.tb_stone_Name.Text = oData(.Value - 1).ToString
                .BackColor = Drawing.Color.White
            End If
        End With

        '----------date--------
        With Me.nud_date
            If .Value > _upbound Then
                .BackColor = Drawing.Color.Red
            ElseIf .Value = 0 Then
                .BackColor = Drawing.Color.Blue

            Else
                Try
                    Me.tb_date.Text = oData(.Value - 1).ToString
                    .BackColor = Color.FromKnownColor(KnownColor.Window)

                Catch ex As Exception
                    Me.tb_date.Text = ""
                    .BackColor = Drawing.Color.Red
                End Try


            End If
        End With
        '---------fossil name---------

        With Me.nud_fossil_name
            If .Value > _upbound Then
                .BackColor = Drawing.Color.Red
            ElseIf .Value = 0 Then
                .BackColor = Drawing.Color.Blue

            Else
                .BackColor = Color.FromKnownColor(KnownColor.Window)
                Me.tb_fossil_name.Text = oData(.Value - 1).ToString
            End If
        End With
        '----------fossil--leight------
        With Me.nud_fossil_leight
            If .Value > _upbound Then
                .BackColor = Drawing.Color.Red
            ElseIf .Value = 0 Then
                .BackColor = Drawing.Color.Blue

            Else
                .BackColor = Color.FromKnownColor(KnownColor.Window)
                Me.tb_fossil_leight.Text = GetWidtLendt(oData(.Value - 1).ToString)(0)
            End If
        End With

        '-------width fossil-----------
        With Me.nud_fossil_width
            If .Value > _upbound Then
                .BackColor = Drawing.Color.Red
            ElseIf .Value = 0 Then
                .BackColor = Drawing.Color.Blue

            Else
                .BackColor = Color.FromKnownColor(KnownColor.Window)
                Me.tb_fossil_width.Text = GetWidtLendt(oData(.Value - 1).ToString)(1)
            End If
        End With

        '-----leight stone-------------
        With Me.nud_stone_leight
            If .Value > _upbound Then
                .BackColor = Drawing.Color.Red
            ElseIf .Value = 0 Then
                .BackColor = Drawing.Color.Blue

            Else
                .BackColor = Color.FromKnownColor(KnownColor.Window)
                Me.tb_stone_leight.Text = GetWidtLendt(oData(.Value - 1).ToString)(0)
            End If
        End With
        '------stone------width------
        With Me.nud_stone_width
            If .Value > _upbound Then
                .BackColor = Drawing.Color.Red
            ElseIf .Value = 0 Then
                .BackColor = Drawing.Color.Blue

            Else
                .BackColor = Color.FromKnownColor(KnownColor.Window)
                Me.tb_stone_width.Text = GetWidtLendt(oData(.Value - 1).ToString)(1)
            End If
        End With
        '------stone------height------
        With Me.nud_stone_height
            If .Value > _upbound Then
                .BackColor = Drawing.Color.Red
            ElseIf .Value = 0 Then
                .BackColor = Drawing.Color.Blue

            Else
                .BackColor = Color.FromKnownColor(KnownColor.Window)
                Me.tbStone_height.Text = GetWidtLendt(oData(.Value - 1).ToString)(0)
            End If
        End With

        '--------stone---weight-------
        With Me.nud_stone_weight
            If .Value > _upbound Then
                .BackColor = Drawing.Color.Red
            ElseIf .Value = 0 Then
                .BackColor = Drawing.Color.Blue

            Else
                .BackColor = Color.FromKnownColor(KnownColor.Window)
                Me.tb_stone_weight.Text = GetWidtLendt(oData(.Value - 1).ToString)(0)
            End If
        End With





        '-------проверка образца в БД-----------

        If CheckNumberInDB() = 0 Then
            'ошибки нет и данных об образце тоже
            Me.btSave.Enabled = True
            'проверить АВТОМАТ
            If cbxAutoSave.Checked Then
                Call Me.btSave_Click(cbxAutoSave, EventArgs.Empty)
                Me.btSave.Enabled = False
            End If


        Else
            Me.btSave.Enabled = False
        End If




    End Sub

    Public Property ColumnsCount As Integer
        Set(ByVal value As Integer)
            If value = 0 Then Exit Property
            oColumnCount = value
            Me.nud_date.Maximum = value
            Me.nud_fossil_leight.Maximum = value
            Me.nud_fossil_name.Maximum = value
            Me.nud_stone_Name.Maximum = value
            Me.nud_stone_Number.Maximum = value
            Me.nud_stone_width.Maximum = value
            Me.nud_stone_weight.Maximum = value
            Me.nud_fossil_width.Maximum = value
            Me.nud_stone_leight.Maximum = value
            Me.nud_description.Maximum = value
            Me.nud_start_price.Maximum = value
            Me.nud_sold_price.Maximum = value
            Me.nud_stone_height.Maximum = value
        End Set
        Get
            Return oColumnCount
        End Get
    End Property
#End Region

    Public Structure ConfirmOrder
        Dim ClientName As String
        Dim Currency As String
        Dim OrderDate As Date
        Dim TotalAmount As Decimal
        Dim ConfirmOrderID As Integer
        'структура создана и необходимо получить ID
        Dim NeedCall As Boolean
    End Structure

    Public Sub ClearValues()
        oData = {}
        Me.refresh_controls()
    End Sub


    Public Property Data() As String()
        Set(ByVal value As String())
            If value Is Nothing Then Exit Property
            If value.Length = 0 Then Exit Property
            oData = value
            Me.refresh_controls()
        End Set
        Get
            Dim _out() As String = {}
            If oData Is Nothing Then Return {""}
            oData.CopyTo(_out, 0)
            Return _out
        End Get
    End Property
    ''' <summary>
    ''' разделяет значение (ахв) возвращает массив строк (0) = длина, (1) = ширина. Точка заменена. Доступные разделители хХ(рус) и хХ(англ)
    ''' </summary>
    ''' <param name="value"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Private Function GetWidtLendt(ByVal value As String) As String()
        If value = "" Then Return {"0", "0"}
        Const sepA As Char = "x"
        Const sepB As Char = "х"
        Const sepC As Char = "X"
        Const sepD As Char = "Х"

        Dim _out() As String

        With value
            If .Contains(sepA) = True Then
                'строка содержит символ-разделитель
                'разбить на две
                _out = .Split(sepA)
            ElseIf .Contains(sepB) = True Then
                _out = .Split(sepB)
            ElseIf .Contains(sepC) = True Then
                _out = .Split(sepC)
            ElseIf .Contains(sepD) = True Then
                _out = .Split(sepD)
            Else
                'строка не содержит разделителей
                Return {ReplacePoint(value), ReplacePoint(value)}

            End If
            Select Case _out.Length
                Case 0
                    Return {"0", "0"}
                Case 1
                    Return {ReplacePoint(_out(0)), "0"}
                Case 2
                    Return {ReplacePoint(_out(0)), ReplacePoint(_out(1))}
                Case 3
                    Return {ReplacePoint(_out(0)), ReplacePoint(_out(1))}
                Case Else
                    Return {"0", "0"}
            End Select

        End With
    End Function
    Private Function ReplacePoint(ByVal value As String) As String
        If value = "" Then Return ""
        'строка не содержит его
        'проверить точку
        If value.Contains(".") Then
            'заменить на запятую
            value.Replace(".", ",")
            Return value
        End If
        Return value
    End Function


    Private Sub btSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSave.Click
        Me.lbDBResult.Text = "результат?"
        If Not Me.ValidateChildren Then
            MsgBox("Исправте ошибки в полях!", MsgBoxStyle.Critical)
            Exit Sub
        End If

        Dim _number As Decimal
        Dim _name As String
        Dim _leight As Decimal
        Dim _wight As Decimal
        Dim _height As Decimal
        Dim _weight As Decimal
        Dim _date As Date

        Dim _main_fossil_name As String
        Dim _main_fossil_leight As Decimal
        Dim _main_fossil_width As Decimal



        Dim _code As clsApplicationTypes.clsSampleNumber = clsApplicationTypes.clsSampleNumber.CreateFromString(Me.tb_stone_Number.Text)
        If _code Is Nothing OrElse _code.GetEan13 = 0 Then Exit Sub

        'Me.lbResult.Text = "результат?"

        'чтение значений из ЭУ
        'to SampleDB
        _number = _code.GetEan13
        _name = tb_stone_Name.Text
        _leight = CType(tb_stone_leight.Text, Decimal)
        _wight = CType(tb_stone_width.Text, Decimal)
        _height = CType(tbStone_height.Text, Decimal)
        _weight = CType(tb_stone_weight.Text, Decimal)
        _date = Date.Parse(tb_date.Text)
        _main_fossil_name = tb_fossil_name.Text
        _main_fossil_width = CType(tb_fossil_width.Text, Decimal)
        _main_fossil_leight = CType(tb_fossil_leight.Text, Decimal)

        'call SampleDB
        Dim _Sample_param As Object = {_number, _name, _leight, _wight, _height, _weight, _date}
        Dim _fossil_param As Object = {{_main_fossil_name}, {_main_fossil_leight}, {_main_fossil_width}}

        Call AddToSampleDB(_Sample_param, _fossil_param)
        '===========================


    End Sub
    Private Sub AddToSampleDB(ByVal Sample_param As Object, ByVal Fossil_param As Object)
        'connect to db
        'использование сервисов
        'по запросу выполняем вызов из сервиса
        'Function AddSampleInfo(ByVal Sample_parameter As Object, ByVal fossil_parameter As Object) As Integer
        '<param name="Sample_parameter">номер,основное название, длина, ширина, ВЫСОТА, вес в кг, исходная дата записи</param>
        '<param name="fossil_parameter">имена(), длины(), ширины()</param>
        '<returns>-3: ошибка в переданной структуре, -2: образец уже есть в базе, -1: переданных данных недостаточно для записи в БД, 0: некорректный номер, 1 и более: успешно добавлено </returns>
        Dim _result As Integer

        'если делегата нет, то сервис недоступен
        If Not clsApplicationTypes.DelegateStoreAddSampleDataIntoDB Is Nothing Then
            'сервис зарегестрирован - вызываем 
            _result = clsApplicationTypes.DelegateStoreAddSampleDataIntoDB.Invoke(Sample_param, Fossil_param)
        Else
            'Return Nothing
        End If
        Select Case _result
            Case -3
                lbDBResult.Text = "ошибка в переданной структуре"
            Case -2
                lbDBResult.Text = "образец уже есть в базе"
            Case -1
                lbDBResult.Text = "переданных данных недостаточно для записи в БД"
            Case 0
                lbDBResult.Text = "некорректный номер"
            Case Is >= 1
                lbDBResult.Text = "данные успешно занесены"
            Case Else
                lbDBResult.Text = "неизвестная ошибка"
        End Select
        RaiseEvent DataSavedToDB(_result)
    End Sub
#Region "Проверка данных в ЭУ"
    ''' <summary>
    ''' проверка номера образца
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tbNumber_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tb_stone_Number.Validating
        Dim _code As clsApplicationTypes.clsSampleNumber = clsApplicationTypes.clsSampleNumber.CreateFromString(sender.Text)

        If _code Is Nothing OrElse _code.GetEan13 = 0 Then
            Validating_false(sender)
            e.Cancel = True
        Else
            Validating_true(sender)

            'проверить наличие номера в БД
            'TODO
        End If
    End Sub
    ''' <summary>
    ''' проверка десятичных полей
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tb_leight_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tb_stone_leight.Validating, tb_stone_weight.Validating, tb_stone_width.Validating, tb_fossil_leight.Validating, tb_fossil_width.Validating, tb_AddFossil_leight.Validating, tb_AddFossil_Width.Validating, tb_sold_price.Validating, tb_start_price.Validating
        Dim a As Decimal
        If sender.text = "" Then sender.text = "0"
        Try
            a = CType(sender.Text, Decimal)
        Catch ex As InvalidCastException
            Validating_false(sender)
            e.Cancel = True

            Exit Sub
        End Try

        e.Cancel = False
        Validating_true(sender)
    End Sub
    ''' <summary>
    ''' проверка имен
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tb_names_validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tb_fossil_name.Validating, tb_stone_Name.Validating
        'If CType(sender.Text, String).Length > 50 Or CType(sender.Text, String).Length < 5 Then
        '    Validating_false(sender)
        '    e.Cancel = True

        '    Exit Sub
        'End If
        'e.Cancel = False
        'Validating_true(sender)
    End Sub
    ''' <summary>
    ''' проверка полей дат
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' 
    Private Sub tb_date_validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tb_date.Validating
        Dim a As Date
        If tb_date.Text = "" Then tb_date.Text = Now()
        Try
            a = CType(sender.text, Date)
        Catch ex As InvalidCastException


            Validating_false(sender)

            e.Cancel = True

            Exit Sub

        End Try
        e.Cancel = False

        Validating_true(sender)
    End Sub
    ''' <summary>
    ''' работа с эу при полож. проверке
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <remarks></remarks>
    Private Sub Validating_true(ByVal sender As Object)
        sender.BackColor = Color.FromKnownColor(KnownColor.Window)
        btSave.Enabled = True
        btAddFossil.Enabled = True
        Me.bt_Show_images.Enabled = True
    End Sub
    ''' <summary>
    ''' работа с эу при отриц. проверке
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <remarks></remarks>
    Private Sub Validating_false(ByVal sender As Object)
        sender.BackColor = Drawing.Color.Red
        btSave.Enabled = False
        btAddFossil.Enabled = False
        Me.bt_Show_images.Enabled = False
    End Sub
#End Region



    ''' <summary>
    ''' добавить фоссилию в БД для этого номера образца
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btAddFossil_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btAddFossil.Click
        Me.lbDBResult.Text = "результат?"
        Dim _fossil_name As String
        Dim _fossil_leight As String
        Dim _fossil_width As String
        'check name
        If Me.tb_AddFossilName.Text = "" Then
            MsgBox("Необходимо ввести имя объекта!", vbCritical)
            Exit Sub
        End If

        'check digit fields
        If Not Me.ValidateChildren Then
            MsgBox("Исправте ошибки в полях!", MsgBoxStyle.Critical)
            Exit Sub
        End If

        'check number of sample
        Dim _code As clsApplicationTypes.clsSampleNumber = clsApplicationTypes.clsSampleNumber.CreateFromString(Me.tb_stone_Number.Text)
        If _code Is Nothing OrElse _code.GetEan13 = 0 Then
            MsgBox("Для добавления объекта необходимо ввести правильный номер!", vbCritical)
            Exit Sub
        End If

        'тут все проверено
        _fossil_name = tb_AddFossilName.Text
        _fossil_leight = CType(tb_AddFossil_leight.Text, Decimal)
        _fossil_width = CType(tb_AddFossil_Width.Text, Decimal)

        'add to db
        Dim _Sample_param As Object = {_code.GetEan13}
        Dim _fossil_param As Object = {{_fossil_name}, {_fossil_leight}, {_fossil_width}}

        Call AddToSampleDB(_Sample_param, _fossil_param)

    End Sub


    Private Sub bt_Show_images_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_Show_images.Click
        'проверить номер
        'check number of sample
        Dim _code As clsApplicationTypes.clsSampleNumber = clsApplicationTypes.clsSampleNumber.CreateFromString(Me.tb_stone_Number.Text)
        If _code Is Nothing OrElse _code.GetEan13 = 0 Then
            MsgBox("Для просмотра фоток необходимо ввести правильный номер!", vbCritical)
            Exit Sub
        End If

        'получить список фото
        Dim _filesource = clsFilesSources.CreateInstance(clsFilesSources.emSources.Arhive)

        Dim _list As Service.SampleSourceImageList = clsApplicationTypes.SamplePhotoObject.GetSampleImageList(_code, _filesource, New Size(640, 480), False)

        If _list Is Nothing Then
            MsgBox("для этого образца нет фото", vbCritical)
            Exit Sub
        End If


        If _list.CountImages = 0 Then
            MsgBox("для этого образца нет фото", vbCritical)
        End If

        Dim _fm As Form = Nothing
        Dim _param As Object = {_list}
        'использование сервисов
        'выполняем вызов из сервиса
        ' dim _param as object={[parameters_list]}
        'если делегата нет, то сервис недоступен
        If Not clsApplicationTypes.DelegateStoreApplicationForm(clsApplicationTypes.emFormsList.fmImage) Is Nothing Then
            'сервис зарегестрирован - вызываем 
            _fm = clsApplicationTypes.DelegateStoreApplicationForm(clsApplicationTypes.emFormsList.fmImage).Invoke(_param)

        End If

        If Not _fm Is Nothing Then
            _fm.Show()
        End If

    End Sub

    Private Sub btAddSold_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btAddSold.Click
        Me.lbDBResult.Text = "результат?"
        If Not Me.ValidateChildren Then
            MsgBox("Исправте ошибки в полях!", MsgBoxStyle.Critical)
            Exit Sub
        End If
        'to OnSale DB

        Dim _description As String
        Dim _start_price As Decimal
        Dim _sold_price As Decimal
        Dim _onSale As Boolean
        Dim _sold As Boolean
        Dim _reserved As Boolean

        _description = CType(rtb_description.Text, String)
        _start_price = CType(tb_start_price.Text, String)
        _sold_price = CType(tb_sold_price.Text, String)
        _onSale = cb_OnSale_flag.Checked
        _sold = cb_sold_flag.Checked
        _reserved = cb_reserv_flag.Checked

        'call OnSaleDB
        With Me.oConfirmOrder
            If .NeedCall Then
                'нужно вызвать сервис создания/получения ID заказа
                Dim _orderParam As Object = {.ClientName, .OrderDate, .Currency, .TotalAmount}
                'значение, кот. будет установлено при вызове сервиса создания продажи

                'TODO Call service: Me.oConfirmOrder.ConfirmOrderID=[call service]
                .NeedCall = False
            End If

            'вызвать сервис добавления OnSale
            'параметры соответствуют таблице БД
            Dim _param As Object = {_onSale, _reserved, _sold, .ConfirmOrderID, _start_price, _sold_price, 0, 0, "USD", 30, _description, ""}
            'TODO call service

        End With

    End Sub

    Private Sub btCreateOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCreateOrder.Click
        Dim _fm As New fm_CreateConfirmOrder
        AddHandler _fm.OnOrderSelected, AddressOf OrderSelectedEventHandler
        _fm.Show()

    End Sub
    Private Sub OrderSelectedEventHandler(ByVal sender As Object, ByVal value As ConfirmOrder)
        Me.Order = value
        sender.close()

    End Sub


    Private Property Order As ConfirmOrder
        Get
            Return oConfirmOrder
        End Get
        Set(ByVal value As ConfirmOrder)
            oConfirmOrder = value
            Me.lbDBResult.Text = "active order: " & value.ClientName & "  " & value.OrderDate.ToShortDateString.ToString

        End Set
    End Property

    Private Sub ЗаписатьВсеToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        btSave_Click(sender, e)
        btAddSold_Click(sender, e)
    End Sub


    ''' <summary>
    ''' (-1) - ошибка, (0) - данных нет, (1) - данные есть, (2) - данные есть и полные
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CheckNumberInDB() As Integer
        '///////////////////////
        'использование сервисов
        'выполняем вызов из сервиса
        Dim _out As String
        Dim _status As Integer = -1
        Dim _number = clsApplicationTypes.clsSampleNumber.CreateFromString(Me.tb_stone_Number.Text)
        If _number Is Nothing Then
            _out = "Некорректный номер образца"
            _status = -1
            GoTo exiting
        End If



        'если делегата нет, то сервис недоступен
        If Not clsApplicationTypes.DelegateStoreGetSampleInfoText Is Nothing Then
            'сервис зарегестрирован - вызываем 
            _out = clsApplicationTypes.DelegateStoreGetSampleInfoText.Invoke(_number, Globalization.CultureInfo.CreateSpecificCulture("en-US"), _status)
            If _status = 2 Then _out = "ПОЛНЫЕ ДАННЫЕ: " + _out
        Else
            _out = "сервис не доступен"
            _status = -1
        End If


        GoTo exiting
        '///////////////////////

exiting:
        Me.lbDBResult.Text = _out
        Return _status

    End Function

    Private Sub lbResult_Click(sender As System.Object, e As System.EventArgs)

    End Sub
End Class
