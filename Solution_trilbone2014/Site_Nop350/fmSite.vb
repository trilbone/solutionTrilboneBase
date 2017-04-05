Imports Service
Imports System.Globalization
Imports OrdersAndClients
Imports Service.clsSampleDataManager
Public Class fmSite

#Region "определения"
    Dim oTotalMails As Integer

    ''' <summary>
    ''' интерфейс сайта
    ''' </summary>
    ''' <remarks></remarks>
    Private oSite As iNopDataProvider
    ''' <summary>
    ''' список ролей
    ''' </summary>
    ''' <remarks></remarks>
    Private oRoles As List(Of iNopDataProvider.clsNopRole)
    ''' <summary>
    ''' список магазинов
    ''' </summary>
    ''' <remarks></remarks>
    Private oStores As List(Of iNopDataProvider.clsNopStore)
    ''' <summary>
    ''' текущий язык
    ''' </summary>
    ''' <remarks></remarks>
    Private oCulture As System.Globalization.CultureInfo

#Region "индексы колонок"
    Private oPriceColumnIndexCollection As List(Of Integer)
    Private oShopAllowColumnIndexCollection As List(Of Integer)
    Private oRoleAllowColumnIndexCollection As List(Of Integer)
    Private oRoleMailColumnIndexCollection As List(Of Integer)
    Private oSKUColumnIndex As Integer
    Private oNameColumnIndex As Integer
    Private oPhotoColumnIndex As Integer
    Private oBasePriceColumnIndex As Integer
    Private oWareNameColumnIndex As Integer
    Private oDynamicColumnCountPerRole As Integer
    Private oRolePriceColumnRelativeIndex As Integer
    Private oRoleAllowColumnRelativeIndex As Integer
    Private oRoleMailColumnRelativeIndex As Integer

    'кол-во статичных колонок
    Private oStaticColumnCount As Integer = 0
#End Region
    ''' <summary>
    ''' в процессе инициализации
    ''' </summary>
    ''' <remarks></remarks>
    Private oIsInit As Boolean
    Private oIsSetPrice As Boolean
    Private oIsInputedPrice As Boolean



    ''' <summary>
    ''' текущая валюта
    ''' </summary>
    ''' <remarks></remarks>
    Private oCurrentCurrency As String

    Private oSplashscreen As Form = clsApplicationTypes.SplashScreen

    ''' <summary>
    ''' список товаров после применения фильтров ApplyFilters
    ''' </summary>
    ''' <remarks></remarks>
    Private oCurrentProductList As List(Of iNopDataProvider.clsNopProduct)
    ''' <summary>
    ''' полный список товаров с сайта (фильтр по категории включен)
    ''' </summary>
    ''' <remarks></remarks>
    Private oFullProductList As List(Of iNopDataProvider.clsNopProduct)
    ''' <summary>
    ''' список товаров из МС с учетом названия и склада
    ''' </summary>
    ''' <remarks></remarks>
    Private oMCProductList As List(Of iNopDataProvider.clsNopProduct)
    ''' <summary>
    ''' список товаров из мс, фильтрованных товарами на сайте
    ''' </summary>
    ''' <remarks></remarks>
    Private oExceptedMCProductList As List(Of iNopDataProvider.clsNopProduct)

#End Region

#Region "Конструкторы и инициализация"
    Dim oMSDoWork As Boolean

    Public Sub New()

        ' Этот вызов является обязательным для конструктора.
        InitializeComponent()
        'получить интерфейс
        oSite = clsApplicationTypes.NopInterface
        If oSite Is Nothing OrElse oSite.IsConnect = False Then
            MsgBox("Данные с сайта не удалось получить!", vbCritical)
            Return
        End If

        oRoles = oSite.GetRoles
        'откинуть не используемые роли
        oRoles = (From c In oRoles
                  Where Not c.Name.ToLower.Contains("не использовать")
                  Where Not c.Name.ToLower.Contains("администратор")).ToList


        oStores = oSite.GetStores
        Me.LoadEntities()
        Me.CreateColumns()
        Me.cbSiteCategories.SelectedItem = 0
        Me.oCulture = clsApplicationTypes.EnglishCulture
        Me.cbDiscount.SelectedIndex = 0
        Me.nop_DataGridView.EnableHeadersVisualStyles = False

    End Sub


#End Region

#Region "Открытые свойства и методы"
    ''' <summary>
    ''' ссылка на fmMain
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property fmMainLink As Object


#End Region


#Region "данные формы"
    ''' <summary>
    ''' создает колонки в грид виев  по данным сайта
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CreateColumns()
        'показат сплеш
        If oSplashscreen.Visible = False Then
            oSplashscreen.Show()
            Application.DoEvents()
        End If
        oPriceColumnIndexCollection = New List(Of Integer)
        oShopAllowColumnIndexCollection = New List(Of Integer)
        oRoleAllowColumnIndexCollection = New List(Of Integer)
        oRoleMailColumnIndexCollection = New List(Of Integer)
        oSKUColumnIndex = 0
        oNameColumnIndex = 0
        oPhotoColumnIndex = 0
        oBasePriceColumnIndex = 0
        oCurrentCurrency = "RUR"
        'формируем колонки
        With Me.nop_DataGridView
            .Rows.Clear()
            .Columns.Clear()
            Dim _column As New DataGridViewColumn
            Dim _names As Integer = 1
            '-0------------
            'колонка фото
            _column = New System.Windows.Forms.DataGridViewImageColumn
            With _column
                .Name = "photo"
                .HeaderText = "фото"
                .ValueType = GetType(Image)
                CType(_column, System.Windows.Forms.DataGridViewImageColumn).ImageLayout = DataGridViewImageCellLayout.Zoom
                .DefaultCellStyle = New DataGridViewCellStyle With {.Alignment = DataGridViewContentAlignment.MiddleCenter}
                .Width = 100
                .Frozen = True
            End With
            oPhotoColumnIndex = .Columns.Add(_column)
            oStaticColumnCount += 1
            '-1------------
            'колонка имени
            _column = New System.Windows.Forms.DataGridViewTextBoxColumn
            With _column
                .Name = "name"
                .HeaderText = "имя"
                .ValueType = GetType(String)
                .Width = 100
                .Frozen = True
                .DefaultCellStyle = New DataGridViewCellStyle With {.Alignment = DataGridViewContentAlignment.MiddleCenter, .WrapMode = DataGridViewTriState.True}
            End With
            oNameColumnIndex = .Columns.Add(_column)
            oStaticColumnCount += 1
            '-2---------------
            'колонка номера
            _column = New System.Windows.Forms.DataGridViewTextBoxColumn
            With _column
                .Name = "number"
                .HeaderText = "номер"
                .ValueType = GetType(String)
                .Width = 45
                .Frozen = True
            End With
            oSKUColumnIndex = .Columns.Add(_column)
            oStaticColumnCount += 1
            '-3---------------
            'колонка имени склада
            _column = New System.Windows.Forms.DataGridViewTextBoxColumn
            With _column
                .Name = "wareName"
                .HeaderText = "склад"
                .ValueType = GetType(String)
                .Width = 45
                .Frozen = True
            End With
            oWareNameColumnIndex = .Columns.Add(_column)
            oStaticColumnCount += 1


            If clsApplicationTypes.GetAccess("цены сайта") Then
                '-4-----------------
                'колонка базовой цены
                _column = New System.Windows.Forms.DataGridViewTextBoxColumn
                With _column
                    .Name = "baseprice"
                    .HeaderText = "цена"
                    .ValueType = GetType(Decimal)
                    .DefaultCellStyle = New DataGridViewCellStyle With {.Format = "C0", .FormatProvider = New CultureInfo("ru-RU")}
                    .Width = 75
                    .Frozen = True
                End With
                Dim _ind = .Columns.Add(_column)
                oBasePriceColumnIndex = _ind
                oPriceColumnIndexCollection.Add(_ind)
                'добавь oStaticColumnCount+=1 при добавлении статичной колонки!!!
                oStaticColumnCount += 1
            End If


            ''при наличии доступа установить пароль
            If Not clsApplicationTypes.GetAccess("Отправка eMail") Then
                Me.cbSenderMail.Enabled = False
                Me.btSendMails.Enabled = False
            Else
                Me.cbSenderMail.Items.AddRange(clsApplicationTypes.SendersMailList)
                Me.cbSenderMail.SelectedIndex = 0
            End If

            If Not clsApplicationTypes.GetAccess("цены сайта") Then oSplashscreen.Hide() : Return

            '==============динамичные колонки
            '-4 to * ---------------
            'колонки магазинов
            _names = 1
            For Each t In oStores
                _column = New System.Windows.Forms.DataGridViewCheckBoxColumn
                With _column
                    .Name = "store" & _names
                    _names += 1
                    .HeaderText = t.Name.Substring(0, 5)
                    .Tag = t.id
                    .ValueType = GetType(Boolean)
                    .Width = 45
                    .Frozen = True
                    .SortMode = DataGridViewColumnSortMode.Automatic
                End With
                oShopAllowColumnIndexCollection.Add(.Columns.Add(_column))
            Next

            '---------------
            'колонки ролей
            _names = 1
            'изменить при добавлении колонки
            oDynamicColumnCountPerRole = 3
            oRoles.Sort(Function(x, y) x.Name.CompareTo(y.Name))

            For Each t In oRoles
                _column = New System.Windows.Forms.DataGridViewCheckBoxColumn
                ''откинуть не используемые роли
                'If t.Name.ToLower.Contains("не использовать") Then
                '    GoTo nx
                'End If
                'If t.Name.ToLower.Contains("администратор") Then
                '    GoTo nx
                'End If
                '0 колонки доступа
                With _column
                    .Name = "role" & _names
                    _names += 1
                    .HeaderText = ""
                    .Tag = t.id
                    .ValueType = GetType(Boolean)
                    .Width = 20
                    .SortMode = DataGridViewColumnSortMode.Automatic
                End With
                oRoleAllowColumnRelativeIndex = 0
                oRoleAllowColumnIndexCollection.Add(.Columns.Add(_column))

                '1 колонка емайл
                _column = New System.Windows.Forms.DataGridViewCheckBoxColumn
                With _column
                    .Name = "mail" & _names
                    _names += 1
                    .HeaderText = "@"
                    .Tag = t.id
                    .ValueType = GetType(Boolean)
                    .Width = 20
                    .SortMode = DataGridViewColumnSortMode.Automatic
                End With
                oRoleMailColumnRelativeIndex = 1
                oRoleMailColumnIndexCollection.Add(.Columns.Add(_column))

                '2 колонки цен
                Dim _columnPrice As New System.Windows.Forms.DataGridViewTextBoxColumn
                With _columnPrice
                    .Name = "roleprice" & _names
                    _names += 1
                    .HeaderText = t.Name
                    .Tag = t.id
                    .ValueType = GetType(Decimal)
                    .DefaultCellStyle = New DataGridViewCellStyle With {.Format = "C0", .FormatProvider = New CultureInfo("ru-RU")}
                    .Width = 75
                End With
                oRolePriceColumnRelativeIndex = 2
                oPriceColumnIndexCollection.Add(.Columns.Add(_columnPrice))
nx:

            Next
        End With
        oSplashscreen.Hide()
    End Sub

    ''' <summary>
    ''' фильтрует по параметрам, заданным в форме
    ''' </summary>
    ''' <param name="input"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ApplyFilters(input As List(Of iNopDataProvider.clsNopProduct)) As List(Of iNopDataProvider.clsNopProduct)
        Dim _out = input
        'фильтр по названию = главный
        If Not String.IsNullOrEmpty(Me.tbNameFilter.Text) Then
            _out = (From c In input Where c.Name.ToLower.Contains(Me.tbNameFilter.Text.ToLower) Select c).ToList
        End If

        '+отдельный фильтр по клиенту
        If Not String.IsNullOrEmpty(Me.tbClientName.Text) Then
            Dim _res = (From c In oRoles Where c.Name.ToLower.Contains(Me.tbClientName.Text.ToLower) Select c).FirstOrDefault
            If Not _res Is Nothing Then
                Me.tbClientName.Text = _res.Name
                _out = (From c In _out Where c.CustomerRolesIdList.Contains(_res.id) Select c).ToList
            Else
                Me.tbClientName.Text = "не найден"
            End If
        End If

        '+отдельный фильтр по пустым камням
        If Me.cbWithoutClients.Checked Then
            'минус роль администратора
            Dim _roleCount = NumericUpDownRole.Value
            _out = (From c In _out Where (c.CustomerRolesIdList Is Nothing) OrElse (c.CustomerRolesIdList.Count <= _roleCount) Select c).ToList
        End If

        '+отдельный фильтр номеру
        If Not String.IsNullOrEmpty(Me.tbSampleNumberFilter.Text) Then
            _out = (From c In input Where c.Sku.Contains(Me.tbSampleNumberFilter.Text) Select c).ToList
        End If

        '......

        Return _out
    End Function

    ''' <summary>
    ''' подгружает данные в грид виев
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadData(input As List(Of iNopDataProvider.clsNopProduct), ClearList As Boolean, ByRef sender As Button)
        'показат сплеш
        If oSplashscreen.Visible = False Then
            oSplashscreen.Show()
            Application.DoEvents()
        End If

        oTotalMails = 0
        oIsInit = True

        'отобразим в баксах
        Me.cbCurrency.SelectedIndex = 1

        If ClearList Then
            Me.nop_DataGridView.Rows.Clear()
            oCurrentCurrency = "USD"
        End If

        'заполняем данными
        Dim _loadedCount As Integer = 0
         For Each t In input
            Dim _index = Me.nop_DataGridView.Rows.Add()
            Me.LoadRow(t, _index)
            _loadedCount += 1
            sender.Text = String.Format("Осталось {0}", input.Count - _loadedCount)
            Application.DoEvents()
        Next

        oIsInit = False
        oSplashscreen.Hide()
        clsApplicationTypes.BeepYES()
    End Sub

    ''' <summary>
    ''' загружает строку
    ''' </summary>
    ''' <param name="productData"></param>
    ''' <remarks></remarks>
    Private Sub LoadRow(productData As iNopDataProvider.clsNopProduct, GridRowIndex As Integer)
        oIsInit = True

        'валюта преобразуем с текущей в выбранную
        Dim _ci As CultureInfo

        If Me.cbCurrency.SelectedIndex = -1 Then Me.cbCurrency.SelectedItem = "USD"

        Select Case Me.cbCurrency.SelectedItem
            Case "RUR"
                _ci = New CultureInfo("ru-RU")
            Case "USD"
                _ci = New CultureInfo("en-US")
            Case "EUR"
                _ci = New CultureInfo("de-DE")
            Case Else
                _ci = New CultureInfo("en-US")
        End Select

        Dim _row = Me.nop_DataGridView.Rows(GridRowIndex)
        With _row
            Dim _sm = clsApplicationTypes.clsSampleNumber.CreateFromString(productData.Sku)
            Dim _history = clsApplicationTypes.SampleDataObject.GetSampleHistoryInfo(_sm)
            .Tag = productData
            .DefaultCellStyle.ForeColor = Color.Black
            .HeaderCell.Value = (GridRowIndex + 1 + IIf(Me.oNextPageIndex - Me.NumericUpDownPage.Value < 0, 0, Me.oNextPageIndex - Me.NumericUpDownPage.Value)).ToString
            .Height = 100
            'статичные колонки

            '-----фото
            .Cells(oPhotoColumnIndex).Value = clsApplicationTypes.SamplePhotoObject.GetMainImage(clsFilesSources.Arhive, clsApplicationTypes.clsSampleNumber.CreateFromString(productData.Sku), True).GetThumbnailImage(160, 120, Function() False, System.IntPtr.Zero)

            '-----имя
            .Cells(oNameColumnIndex).Value = productData.Name
            'карта образца
            Dim _result As Integer
            Dim _sdo = clsApplicationTypes.SampleDataObject.GetSampleOnSale(_sm, _result, CreateIfNotExist:=True)
            If Not _sdo Is Nothing AndAlso _result > 0 Then
                If String.IsNullOrEmpty(_sdo.SampleXMLFile) Then
                    'карты нет
                    .Cells(oNameColumnIndex).Style.BackColor = Color.Red
                    .Cells(oNameColumnIndex).ToolTipText = "нет карты в БД"
                Else
                    .Cells(oNameColumnIndex).Style.BackColor = Color.White
                    .Cells(oNameColumnIndex).ToolTipText = ""
                End If
            End If

            '-----номер
            .Cells(oSKUColumnIndex).Value = productData.Sku.Trim
            .Cells(oSKUColumnIndex).Tag = _sm
            'из сайта / или из МС
            If productData.Id = 0 Then
                'значит из мой склад
                'форматируем
                .Cells(oSKUColumnIndex).Style.BackColor = Color.Red
                .Cells(oSKUColumnIndex).ToolTipText = "Нет на сайте"
            Else
                .Cells(oSKUColumnIndex).Style.BackColor = Color.White
                .Cells(oSKUColumnIndex).ToolTipText = "Выставлен"
            End If
            'размеры фоссилий
            Dim _text As String = ""
            If productData.fossilsSizes Is Nothing Then productData.fossilsSizes = New Decimal() {}
            For Each t1 In productData.fossilsSizes
                _text += String.Format("размер фоссилии {0}см{1}", t1, ChrW(13))
            Next
            .Cells(oSKUColumnIndex).ToolTipText = _text

            '----склад
            .Cells(oWareNameColumnIndex).Value = productData.warename
            '.Cells(oWareNameColumnIndex).ToolTipText = _sm.AskLocations
            'форматируем
            CellWareNarvaCheckFormat(.Cells(oWareNameColumnIndex))
            'номер склада
            .Cells(oWareNameColumnIndex).Tag = productData.WarehouseId

            '----------------
            'установка доступа
            If Not clsApplicationTypes.GetAccess("цены сайта") Then GoTo nx

            '--базовая цена

            .Cells(oBasePriceColumnIndex).Value = Me.ConvertPrice(input:=productData.Price, fromCurrency:=productData.Currency, toCurrency:=cbCurrency.SelectedItem)
            .DefaultCellStyle = New DataGridViewCellStyle With {.Format = "C0", .FormatProvider = _ci}

            CellPriceGreenFormat(.Cells(oBasePriceColumnIndex))
            'проверка продан ли
            If _history.ISsold Then
                .Cells(oBasePriceColumnIndex).Style.BackColor = Color.Red
                .Cells(oBasePriceColumnIndex).ToolTipText = "ПРОДАН"
            Else
                .Cells(oBasePriceColumnIndex).Style.BackColor = Color.White
                .Cells(oBasePriceColumnIndex).ToolTipText = ""
            End If

            '====динамичные колонки
            'запрос ACL по номеру
            Dim _acl = oSite.GetACL(productData.Sku)

            'магазины
            Dim _avstore = oSite.GetAviableStore(productData.Sku)
            For i = oStaticColumnCount To oStores.Count + oStaticColumnCount - 1
                Dim j = i
                .Cells(i).Value = (From c In _avstore Where c.id = Me.nop_DataGridView.Columns(j).Tag Select True).FirstOrDefault
                CellAllowShopFormat(.Cells(i))
            Next
            '==================
            'динамические колонки = роли цены емайлы
            For i = oStores.Count + oStaticColumnCount To Me.nop_DataGridView.Columns.Count - oDynamicColumnCountPerRole Step oDynamicColumnCountPerRole
                Dim j = i

                ''фильтр по клиентам
                'If oFilterClientID > 0 AndAlso Not Me.nop_DataGridView.Columns(j).Tag = oFilterClientID Then Continue For

                'ACL для текущей роли клиента
                ' Dim _clientAcl = (From c In _acl Where c.roleid = Me.nop_DataGridView.Columns(j).Tag Select c).FirstOrDefault
                'текущая роль клиента
                Dim _roleName = Me.nop_DataGridView.Columns(j + oRolePriceColumnRelativeIndex).HeaderText.Trim
                'если _clientAcl cуществует, то образец доступен для заказа

                .Cells(j).Value = (From c In _acl Where c.roleid = Me.nop_DataGridView.Columns(j).Tag Select True).FirstOrDefault
                If .Cells(j).Value Then
                    'сейчас предложен
                    CellAllowRoleFormat(.Cells(j))
                    'проверка емайл
                    If _history.EmailSended(_roleName) Then
                        'емайл уже выслан
                        CellMailAlreadySentFormat(.Cells(j + oRoleMailColumnRelativeIndex))
                    Else
                        'емайл видимо не высылался для последней записи
                        CellMAilFormat(.Cells(j + oRoleMailColumnRelativeIndex))
                        Me.oTotalMails += 1

                    End If
                    '-------------------
                Else
                    'сейчас не предложен
                    'проверка истории
                    If _history.HistoryRecords(_roleName).Count > 0 Then
                        'уже был предложен
                        CellAlreadyOfferRoleFormat(.Cells(j))
                    Else
                        'не был предложен
                    End If

                    '---------
                    'емайл
                    If _history.EmailSended(_roleName) Then
                        'емайл уже выслан
                        CellMailAlreadySentFormat(.Cells(j + oRoleMailColumnRelativeIndex))
                    Else
                        'емайл видимо не высылался для последней записи
                        Me.CellMailNopossibleFormat(.Cells(j + oRoleMailColumnRelativeIndex))
                    End If
                    '-------------------
                End If
                .Cells(j).ToolTipText = _history.OfferHistoryString(_roleName)
                .Cells(j + oRoleMailColumnRelativeIndex).ToolTipText = _history.EmailSendedHistoryString(_roleName)
                '======================
                'цена для роли - в рублях для роли??
                Dim _pr = (From c In _acl Where c.roleid = Me.nop_DataGridView.Columns(j + oRolePriceColumnRelativeIndex).Tag Select c.tierprice).FirstOrDefault
                .Cells(j + oRolePriceColumnRelativeIndex).Value = Me.ConvertPrice(input:=_pr, fromCurrency:="RUR", toCurrency:=cbCurrency.SelectedItem)
                .DefaultCellStyle = New DataGridViewCellStyle With {.Format = "C0", .FormatProvider = _ci}

                If .Cells(j + oRolePriceColumnRelativeIndex).Value > 0 Then
                    'цена на сайте установлена
                    CellPriceGreenFormat(.Cells(j + oRolePriceColumnRelativeIndex))
                Else
                    'проверка истории
                    If _history.HistoryRecords(_roleName).Count > 0 Then
                        'минимальная предложенная цена(кроме ноля)
                        Dim _HistoryPrices = _history.HistoryRecords(_roleName).Where(Function(x) x.CurrentRURAmount > 0)
                        If _HistoryPrices.Count > 0 Then
                            .Cells(j + oRolePriceColumnRelativeIndex).Value = Me.ConvertPrice(Decimal.Round(_HistoryPrices.Min(Function(x) x.CurrentRURAmount), 2), "RUR", cbCurrency.SelectedItem)
                            CellPriceAlreadyOfferFormat(.Cells(j + oRolePriceColumnRelativeIndex))
                        End If
                    End If
                End If
                .Cells(j + oRolePriceColumnRelativeIndex).ToolTipText = _history.OfferHistoryString(_roleName)
            Next
        End With
nx:
        oIsInit = False
    End Sub


    ''' <summary>
    ''' подгружает сущности с сайта в различные ЭУ
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadEntities()
        oIsInit = True
        'список категорий с сайта
        Dim _tc As New List(Of iNopDataProvider.clsNopCategory)
        _tc.Add(New iNopDataProvider.clsNopCategory With {.id = 0, .Name = "Все категории"})
        _tc.AddRange(oSite.GetCategories)

        Me.cbSiteCategories.DataSource = _tc
        Me.cbSiteCategories.DisplayMember = "Name"
        Me.cbSiteCategories.ValueMember = "id"
        Dim _msi = clsApplicationTypes.MoySklad(True)
        Dim _list As New List(Of iMoySkladDataProvider.clsEntity)
        If Not _msi Is Nothing Then
            'загрузка списка складов
            _list.Add(New iMoySkladDataProvider.clsEntity With {.Value = "Все склады"})
            _list.AddRange(_msi.GetWarehouseList)
            ' _list.Sort()
            Me.cbWarehouse.DataSource = _list
            'загрузка папок МС
            _list = New List(Of iMoySkladDataProvider.clsEntity)
            _list.Add(New iMoySkladDataProvider.clsEntity With {.Value = "Все группы"})
            _list.AddRange(_msi.GetGroupList)
            Me.cbMCFolder.DataSource = _list
        Else
            Me.cbWarehouse.Items.Add(New iMoySkladDataProvider.clsEntity With {.Value = "Все склады"})
            Me.cbMCFolder.Items.Add(New iMoySkladDataProvider.clsEntity With {.Value = "Все группы"})
        End If

        Me.cbWarehouse.SelectedIndex = 0
        Me.cbMCFolder.SelectedIndex = 0

        Me.btLoadData.Enabled = False
        Me.btApplyFilter.Enabled = False
        Me.btLoadFromMC.Enabled = False
        Me.btSearchWare.Enabled = False
        oIsInit = False
    End Sub

#End Region

#Region "Форматирование ячеек"
    ''' <summary>
    ''' цвет ячеек для разрешенных ролей
    ''' </summary>
    ''' <param name="cell"></param>
    ''' <remarks></remarks>
    Private Sub CellAllowRoleFormat(cell As DataGridViewCell)
        If cell.Value Then
            cell.Style.BackColor = Color.Green
        Else
            cell.Style.BackColor = TextBox.DefaultBackColor
        End If
    End Sub

    ''' <summary>
    ''' цвета ячеек для уже предложенных
    ''' </summary>
    ''' <param name="cell"></param>
    ''' <remarks></remarks>
    Private Sub CellAlreadyOfferRoleFormat(cell As DataGridViewCell)
        cell.Style.BackColor = Color.Purple
    End Sub

    ''' <summary>
    ''' цвета ячеек разрешенных магазинов
    ''' </summary>
    ''' <param name="cell"></param>
    ''' <remarks></remarks>
    Private Sub CellAllowShopFormat(cell As DataGridViewCell)
        If cell.Value Then
            cell.Style.BackColor = Color.YellowGreen
        Else
            cell.Style.BackColor = TextBox.DefaultBackColor
        End If
    End Sub

    ''' <summary>
    ''' цвета ячеек для незанессенных камней
    ''' </summary>
    ''' <param name="cell"></param>
    ''' <remarks></remarks>
    Private Sub CellOnlyMCFormat(cell As DataGridViewCell)
        cell.Style.BackColor = Color.Purple
    End Sub

    ''' <summary>
    ''' цвета ячеек для емайл
    ''' </summary>
    ''' <param name="cell"></param>
    ''' <remarks></remarks>
    Private Sub CellMAilFormat(cell As DataGridViewCell)
        cell.ReadOnly = False
        cell.Style.ForeColor = Color.FromName("0")
        CType(cell, DataGridViewCheckBoxCell).FlatStyle = FlatStyle.Standard
        If cell.Value = True Then
            cell.Style.BackColor = Color.Black
        Else
            cell.Style.BackColor = Color.Yellow
        End If
        Me.btSendMails.Text = String.Format("Отправить почту{0}", IIf(oTotalMails > 0, String.Format(" ({0})", oTotalMails), ""))
    End Sub
    ''' <summary>
    ''' цвета ячеек для неотправляемых майлов
    ''' </summary>
    ''' <param name="cell"></param>
    ''' <remarks></remarks>
    Private Sub CellMailAlreadySentFormat(cell As DataGridViewCell)
        With CType(cell, DataGridViewCheckBoxCell)
            .Style.BackColor = Color.Purple
            .Style.ForeColor = Color.DarkGray
            .ReadOnly = True
        End With

    End Sub

    Private Sub CellMailNopossibleFormat(cell As DataGridViewCell)
        With CType(cell, DataGridViewCheckBoxCell)
            .Style.BackColor = Color.White
            .FlatStyle = FlatStyle.Flat
            .Style.ForeColor = Color.DarkGray
            'изменено 14.01.2016 с целю разрешить отправку емайла для не выставленных на сайте камней
            '.ReadOnly = True
        End With

    End Sub


    ''' <summary>
    ''' цвета ячеек цен в зависимости от значения
    ''' </summary>
    ''' <param name="cell"></param>
    ''' <remarks></remarks>
    Private Sub CellPriceGreenFormat(cell As DataGridViewCell)
        If cell.Value > 0 Then
            cell.Style.ForeColor = Color.Green
            cell.Style.Font = New Font(TextBox.DefaultFont.FontFamily, TextBox.DefaultFont.Size + 1, FontStyle.Bold)
        Else
            cell.Style.ForeColor = TextBox.DefaultForeColor
            cell.Style.Font = TextBox.DefaultFont
        End If
    End Sub

    ''' <summary>
    ''' цвета ячеек цены уже предложенного 
    ''' </summary>
    ''' <param name="cell"></param>
    ''' <remarks></remarks>
    Private Sub CellPriceAlreadyOfferFormat(cell As DataGridViewCell)
        If cell.Value > 0 Then
            cell.Style.ForeColor = Color.Purple
            cell.Style.Font = TextBox.DefaultFont
        Else
            cell.Style.ForeColor = TextBox.DefaultForeColor
            cell.Style.Font = TextBox.DefaultFont
        End If
    End Sub

    ''' <summary>
    ''' цвета ячеек цены уже предложенного 
    ''' </summary>
    ''' <param name="cell"></param>
    ''' <remarks></remarks>
    Private Sub CellWareNarvaCheckFormat(cell As DataGridViewCell)
        If String.IsNullOrEmpty(cell.Value) Then
            cell.Style.BackColor = TextBox.DefaultBackColor
        ElseIf cell.Value.ToString.StartsWith("Внутренний Нарва") Then
            cell.Style.BackColor = Color.Green
        Else
            cell.Style.BackColor = Color.Purple
        End If
    End Sub

#End Region

#Region "Вспомогательные функции"
    ''' <summary>
    ''' конвертор валют
    ''' </summary>
    ''' <param name="input"></param>
    ''' <param name="fromCurrency"></param>
    ''' <param name="toCurrency"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ConvertPrice(input As Decimal, fromCurrency As String, toCurrency As String) As Decimal
        Select Case toCurrency
            Case "RUR"
                Select Case fromCurrency
                    Case "RUR"
                        Return input
                    Case "USD"
                        Return input * clsApplicationTypes.GetRateByCurrencyCB103("USD")
                    Case "EUR"
                        Return input * clsApplicationTypes.GetRateByCurrencyCB103("EUR")
                End Select
            Case "USD"
                Select Case fromCurrency
                    Case "RUR"
                        Return input / clsApplicationTypes.GetRateByCurrencyCB103("USD")
                    Case "USD"
                        Return input
                    Case "EUR"
                        Return input * (clsApplicationTypes.GetRateByCurrencyCB103("EUR") / clsApplicationTypes.GetRateByCurrencyCB103("USD"))
                End Select
            Case "EUR"
                Select Case fromCurrency
                    Case "RUR"
                        Return input / clsApplicationTypes.GetRateByCurrencyCB103("EUR")
                    Case "USD"
                        Return input / (clsApplicationTypes.GetRateByCurrencyCB103("EUR") / clsApplicationTypes.GetRateByCurrencyCB103("USD"))
                    Case "EUR"
                        Return input
                End Select
            Case Else
        End Select
        Return input
    End Function

#End Region

#Region "события ЭУ"

    Private Sub btApplyFilter_Click(sender As Object, e As EventArgs) Handles btApplyFilter.Click
        oNextPageIndex = 0
        Me.lblPage.Text = ""
        oCurrentProductList = Me.ApplyFilters(oFullProductList)
        Me.btApplyFilter.Text = String.Format("Фильтр ({0})", oCurrentProductList.Count)
        Me.btLoadData.Text = String.Format("Загрузить ({0})", oCurrentProductList.Count)
        Me.btLoadData.Enabled = True
    End Sub

    ''' <summary>
    ''' запуск импорта данных с сайта
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btGetData_Click(sender As Object, e As EventArgs) Handles btGetData.Click
        If Me.cbSiteCategories.SelectedItem Is Nothing Then
            MsgBox("Выберете категорию сайта", vbCritical)
            Return
        End If
        Me.oSplashscreen.Show()
        Application.DoEvents()
        If oCurrentProductList Is Nothing Then
            oCurrentProductList = New List(Of iNopDataProvider.clsNopProduct)
        End If
        oCurrentProductList.Clear()
        oFullProductList = oSite.GetProduct(Me.cbSiteCategories.SelectedValue)

        If oFullProductList.Count > 0 Then
            clsApplicationTypes.BeepYES()
        End If


        Me.btGetData.Text = String.Format("Получено ({0})", oFullProductList.Count)
        oCurrentProductList.AddRange(oFullProductList)
        Me.oSplashscreen.Hide()
        Me.btApplyFilter.Text = String.Format("Фильтр ({0})", oCurrentProductList.Count)
        Me.btApplyFilter.Enabled = True
        Me.btLoadData.Text = String.Format("Загрузить ({0})", oCurrentProductList.Count)
        Me.btLoadData.Enabled = True
        Me.tbMailCaption.Text = "New offer from Trilbone"
    End Sub
    ''' <summary>
    ''' смена валюты отображаемой и пересчет значений в грид виев
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cbCurrency_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbCurrency.SelectedIndexChanged

        If cbCurrency.SelectedItem Is Nothing Then Return
        If oIsInit Then Return

        oIsInit = True

        'перевести в валюту
        Dim _ci As CultureInfo

        Select Case cbCurrency.SelectedItem
            Case "RUR"
                _ci = New CultureInfo("ru-RU")
            Case "USD"
                _ci = New CultureInfo("en-US")
            Case "EUR"
                _ci = New CultureInfo("de-DE")
            Case Else
                _ci = New CultureInfo("ru-RU")
        End Select

        'пересчитать столбцы
        For Each t In Me.oPriceColumnIndexCollection
            Dim _column = Me.nop_DataGridView.Columns(t)
            With _column
                .DefaultCellStyle = New DataGridViewCellStyle With {.Format = "C0", .FormatProvider = _ci}
            End With
            For Each _row As DataGridViewRow In Me.nop_DataGridView.Rows
                _row.Cells(t).Value = Me.ConvertPrice(input:=_row.Cells(t).Value, fromCurrency:=oCurrentCurrency, toCurrency:=cbCurrency.SelectedItem)
            Next
        Next
        'запомнить валюту
        oCurrentCurrency = cbCurrency.SelectedItem
        oIsInit = False
    End Sub
    ''' <summary>
    ''' фильтр по категории
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cbSiteCategories_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbSiteCategories.SelectedIndexChanged
        If oIsInit Then Return
        If Me.cbSiteCategories.SelectedItem Is Nothing Then Return
        For Each t In Me.oPriceColumnIndexCollection
            Dim _column = Me.nop_DataGridView.Columns(t)
            With _column
                .DefaultCellStyle = New DataGridViewCellStyle With {.Format = "C0", .FormatProvider = New CultureInfo("ru-RU")}
            End With
        Next

        '  Me.LoadData(Me.cbSiteCategories.SelectedValue)
    End Sub

    ''' <summary>
    ''' показ лога журнала выставлений с сайта
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btSeeLog_Click(sender As Object, e As EventArgs) Handles btSeeLog.Click
        Dim _log = clsApplicationTypes.SampleDataObject.GetActivityByNumberFromSite(Me.tbShotNumber.Text, Not clsApplicationTypes.GetAccess("лог образца за все время"))
        If _log.Count > 0 Then
            Me.lbLog.DataSource = _log
        Else
            Me.lbLog.DataSource = {"Нет записей"}
        End If
    End Sub

    Private oNextPageIndex As Integer = 0

    ''' <summary>
    ''' подгружает страницу данных
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <remarks></remarks>
    Private Sub LoadNextPage(sender As Button)
        Dim _currentPage As List(Of iNopDataProvider.clsNopProduct)

        If oCurrentProductList.Count > Me.NumericUpDownPage.Value Then
            'постраничная загрузка
            Dim _count As Integer

            If oNextPageIndex + Me.NumericUpDownPage.Value > oCurrentProductList.Count Then
                _count = oCurrentProductList.Count - oNextPageIndex
            Else
                _count = Me.NumericUpDownPage.Value
            End If

            Me.lblPage.Text = String.Format("с {0} по {1} (из {2})", oNextPageIndex + 1, oNextPageIndex + _count, oCurrentProductList.Count)
            sender.Text = String.Format("загрузка ({0})", (Decimal.Ceiling(oNextPageIndex / Me.NumericUpDownPage.Value) + 1))

            _currentPage = oCurrentProductList.GetRange(oNextPageIndex, _count)

            oNextPageIndex += Me.NumericUpDownPage.Value

            If oNextPageIndex >= oCurrentProductList.Count - 1 Then
                oNextPageIndex = 0
            End If

            Application.DoEvents()
            Me.LoadData(_currentPage, True, sender)

            sender.Text = String.Format("стр. {0} из {1}", Decimal.Ceiling(oNextPageIndex / Me.NumericUpDownPage.Value), Decimal.Truncate(oCurrentProductList.Count / Me.NumericUpDownPage.Value) + 1)
        Else
            Me.lblPage.Text = ""
            sender.Text = "загрузка (1)"
            Application.DoEvents()
            Me.LoadData(oCurrentProductList, True, sender)
            sender.Text = "стр. 1 из 1"
        End If
    End Sub


    ''' <summary>
    ''' кнопка загрузки с сайта
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btLoadFromSite_Click(sender As Object, e As EventArgs) Handles btLoadData.Click
        Me.LoadNextPage(sender)
    End Sub

    ''' <summary>
    ''' МС получение карточек товара по части имени
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btGetDataFromMC_Click(sender As Object, e As EventArgs) Handles btGetDataFromMC.Click
        Dim _msi = clsApplicationTypes.MoySklad(True)
        If _msi Is Nothing Then
            Return
        End If

        'найти карточки по имени
        If String.IsNullOrEmpty(Me.tbNameFilter.Text) And Me.cbWarehouse.SelectedIndex = 0 Then
            MsgBox("Для загрузки из Мой склад необходимо задать часть названия образца или выбрать склад.", vbInformation)
            Return
        End If

        oSplashscreen.Show()
        Application.DoEvents()
        'фильтр по складу
        Dim _wareName As String = ""
        If Me.cbWarehouse.SelectedIndex > 0 Then
            _wareName = Me.cbWarehouse.SelectedItem.Value
        End If
        'фильтр по имени
        Dim _namepart = Me.tbNameFilter.Text.Trim

        'запрос
        Dim _result = _msi.FindStokQuantity(_namepart, , _wareName)

        'подгрузить товары из группы - если выбрана
        If Me.cbMCFolder.SelectedIndex > 0 Then
            Dim _res2 = _msi.FindStokQuantity(PartName:="", ShotCode:="", WareHouseName:=_wareName, GroupUUID:=Me.cbMCFolder.SelectedItem.UUID)
            If String.IsNullOrEmpty(_namepart) Then
                _result = _res2
            Else
                _result.AddRange(_res2)
            End If
        End If


        oMCProductList = (From c In _result Select New iNopDataProvider.clsNopProduct With {.HasTierPrices = False, .Id = 0, .LimitedToStores = False, .Name = c.Name, .Price = c.SalePrice, .Currency = c.Currency, .Published = False, .ShowOnHomePage = False, .Sku = c.ActualNumber, .StockQuantity = c.Stok, .WarehouseId = 0, .warename = c.WareName}).ToList

        Me.btGetDataFromMC.Text = String.Format("Из Мой Склад ({0})", _result.Count)
        Me.btSearchWare.Enabled = True
        oSplashscreen.Hide()
    End Sub

    ''' <summary>
    '''МС получение остатков по складам
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btSearchWare_Click(sender As Object, e As EventArgs) Handles btSearchWare.Click
        Dim _comparer = New iNopDataProvider.clsNopProduct
        If oFullProductList Is Nothing Then
            oCurrentProductList = New List(Of iNopDataProvider.clsNopProduct)
            oFullProductList = New List(Of iNopDataProvider.clsNopProduct)
            oExceptedMCProductList = New List(Of iNopDataProvider.clsNopProduct)

            'oCurrentProductList.AddRange(oMCProductList)
            oFullProductList.AddRange(oMCProductList)
            oExceptedMCProductList.AddRange(oMCProductList)

            'Me.btGetData.Text = String.Format("Получено ({0})", oFullProductList.Count)
        Else
            oExceptedMCProductList = oMCProductList.Except(oFullProductList, _comparer).ToList
        End If
        Me.btSearchWare.Text = String.Format("Не выставлено ({0})", oExceptedMCProductList.Count)
        Me.btLoadFromMC.Text = String.Format("Загрузить ({0})", oExceptedMCProductList.Count)
        Me.btLoadFromMC.Enabled = True
    End Sub



    ''' <summary>
    '''МС подгрузить найденные в таблицу
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btLoadFromMC_Click(sender As Object, e As EventArgs) Handles btLoadFromMC.Click
        If oExceptedMCProductList Is Nothing Then Return
        If oExceptedMCProductList.Count = 0 Then Return

        If oNextPageIndex = 0 Then
            Dim _res = oExceptedMCProductList
            If Me.cbxOnlyWithImages.Checked Then
                _res = oExceptedMCProductList.Where(Function(x)
                                                        Dim _sm = clsApplicationTypes.clsSampleNumber.CreateFromString(x.Sku)
                                                        If Not _sm.CodeIsCorrect Then Return False
                                                        Return clsApplicationTypes.SamplePhotoObject.HasImages(_sm, clsFilesSources.Arhive)
                                                    End Function).ToList


            End If

            Me.oCurrentProductList.AddRange(_res)

            'сортиовка по названию
            Me.oCurrentProductList.Sort()

            Me.btLoadFromMC.Text = String.Format("Добавлено ({0})", _res.Count)
            oExceptedMCProductList.Clear()
            clsApplicationTypes.BeepYES()
        Else
            MsgBox("Сначала заверши перелистывание страниц", vbCritical)
        End If

        Me.btLoadData.Text = String.Format("Загрузить ({0})", oCurrentProductList.Count)
        Me.btLoadData.Enabled = True
        ' Me.LoadNextPage(sender)
    End Sub

    ''' <summary>
    ''' вызвать форму данных образца
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btShowSampleData_Click(sender As Object, e As EventArgs) Handles btShowSampleData.Click
        Me.WindowState = FormWindowState.Minimized
        Application.DoEvents()
        If String.IsNullOrEmpty(Me.tbShotNumber.Text) Then Return
        clsApplicationTypes.ExternalLoadSample(Me.tbShotNumber.Text)
    End Sub

    ''' <summary>
    ''' каталог из текущей таблицы
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btCreateCatalog_Click(sender As Object, e As EventArgs) Handles btCreateCatalog.Click
        Dim _list As New List(Of clsApplicationTypes.clsSampleNumber)
        Dim _currency As String = Me.cbCurrency.SelectedItem
        Dim _dicount As Decimal = Decimal.Parse(Me.cbDiscount.SelectedItem)

        Select Case MsgBox("Загрузить все текущие образцы(фильтр)? Нет - только с текущей странице.", vbYesNo + vbQuestion)
            Case MsgBoxResult.Yes
                For Each t In oCurrentProductList
                    Dim _num = clsApplicationTypes.clsSampleNumber.CreateFromString(t.Sku)
                    If Not _num Is Nothing AndAlso _num.CodeIsCorrect Then
                        _list.Add(_num)
                        'запись цены
                        If _dicount < 0 Then
                            'наценка
                            _num.CurrentPrice = New clsApplicationTypes.clsSampleNumber.strPrices With {.BasePrice = Me.ConvertPrice(t.Price - Decimal.Ceiling(t.Price * _dicount / 100), "RUR", oCurrentCurrency), .Currency = oCurrentCurrency, .PriceWithDiscount = Me.ConvertPrice(t.Price - Decimal.Ceiling(t.Price * _dicount / 100), "RUR", oCurrentCurrency), .Discount = 0}
                        Else
                            'скидка
                            _num.CurrentPrice = New clsApplicationTypes.clsSampleNumber.strPrices With {.BasePrice = Me.ConvertPrice(t.Price, "RUR", oCurrentCurrency), .Currency = oCurrentCurrency, .PriceWithDiscount = Me.ConvertPrice(t.Price - Decimal.Ceiling(t.Price * _dicount / 100), "RUR", oCurrentCurrency), .Discount = _dicount}
                        End If

                    End If
                Next
            Case MsgBoxResult.No
                Dim _onlyMail As Boolean = If(Me.oTotalMails > 0, True, False)
                Dim _include As Boolean = False
                For Each t As DataGridViewRow In Me.nop_DataGridView.Rows
                    Dim _num = clsApplicationTypes.clsSampleNumber.CreateFromString(t.Cells(oSKUColumnIndex).Value)
                    If Not _num Is Nothing AndAlso _num.CodeIsCorrect Then
                        'запись клиентской цены

                        For Each k As DataGridViewCell In t.Cells
                            If oRoleAllowColumnIndexCollection.Contains(k.ColumnIndex) Then
                                Dim _role = nop_DataGridView.Columns(k.ColumnIndex + oRolePriceColumnRelativeIndex - oRoleAllowColumnRelativeIndex).HeaderText
                                If _role.Equals(Me.tbClientName.Text) Then
                                    If _onlyMail Then
                                        If t.Cells(k.ColumnIndex + oRolePriceColumnRelativeIndex - oRoleAllowColumnRelativeIndex - 1).Value = True Then
                                            _include = True
                                        Else
                                            _include = False
                                        End If
                                    Else
                                        _include = True
                                    End If
                                    Dim _price = Decimal.Ceiling(t.Cells(k.ColumnIndex + oRolePriceColumnRelativeIndex - oRoleAllowColumnRelativeIndex).Value)
                                    If _dicount < 0 Then
                                        'наценка
                                        _num.CurrentPrice = New clsApplicationTypes.clsSampleNumber.strPrices With {.BasePrice = _price - Decimal.Ceiling(_price * _dicount / 100), .Currency = _currency, .PriceWithDiscount = _price - Decimal.Ceiling(_price * _dicount / 100), .Discount = 0}
                                    Else
                                        'скидка
                                        _num.CurrentPrice = New clsApplicationTypes.clsSampleNumber.strPrices With {.BasePrice = _price, .Currency = _currency, .PriceWithDiscount = _price - Decimal.Ceiling(_price * _dicount / 100), .Discount = _dicount}

                                    End If
                                End If
                            End If
                        Next
                        If _include Then
                            _list.Add(_num)
                        End If

                    End If
                Next
        End Select

        Dim _catNum As Integer = InputBox("Номер каталога сегодня", "Параметры каталога", "1")
        Dim _catName As String = (Now.ToString("ddmmyy") & "-" & _catNum).Replace(".", "")
        Dim _catTitle As String = tbMailCaption.Text


        Dim _catalog = Service.Catalog.CATALOG.CreateInstance(SampleList:=_list, name:=_catName, title:=_catTitle, [date]:=Now.ToShortDateString, culture:=oCulture, folfertype:=clsApplicationTypes.emCatalogFolderType.hash, GetFromDB:=True, ShowPrices:=True, numberstring:="nr.: ")

        If Not _catalog Is Nothing Then
            Dim _xml = _catalog.GetXML
            Dim fm As New fmBrowser(_catalog.GetHTML(), _catName, _catTitle)
            fm.Show()
        End If
    End Sub

    ''' <summary>
    ''' проверка наличия номера в таблице
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btCheckNumber_Click(sender As Object, e As EventArgs) Handles btCheckNumber.Click
        Dim _origin = clsApplicationTypes.clsSampleNumber.CreateFromString(Me.tbCheckNumber.Text)
        If _origin Is Nothing Then GoTo no
        If _origin.CodeIsCorrect = False Then GoTo no

        Dim _res = Me.oCurrentProductList.Where(Function(x) x.Sku.Equals(_origin.ShotCode)).FirstOrDefault

        If _res Is Nothing Then GoTo no
        GoTo yes
no:
        clsApplicationTypes.BeepNOT()
        Me.tbCheckNumber.BackColor = Color.Red

        tbCheckNumber.Focus()
        Return

yes:
        clsApplicationTypes.BeepYES()
        Me.tbCheckNumber.BackColor = Color.Green

        tbCheckNumber.Focus()
        Return

    End Sub



    Private Sub tbCheckNumber_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbCheckNumber.KeyPress
        Me.tbCheckNumber.BackColor = Windows.Forms.TextBox.DefaultBackColor

        If Asc(e.KeyChar) = 13 Then
            btCheckNumber_Click(sender, e)
        End If
    End Sub
#End Region

#Region "События сетки"
    ''' <summary>
    ''' двойной счелчек
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub nop_DataGridView_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles nop_DataGridView.CellDoubleClick
        If Not (e.ColumnIndex > -1 AndAlso e.RowIndex > -1) Then Return
        Select Case e.ColumnIndex
            '=====фотки
            Case oPhotoColumnIndex
                Dim _code = clsApplicationTypes.clsSampleNumber.CreateFromString(Me.nop_DataGridView.Rows(e.RowIndex).Cells(oSKUColumnIndex).Value)
                If _code Is Nothing Then Return
                If Me.nop_DataGridView.Rows(e.RowIndex).Cells(oPhotoColumnIndex).Value Is Nothing Then Return
                Dim _prm = Service.clsApplicationTypes.SamplePhotoObject.GetImageCollection(_code, clsFilesSources.Arhive, False)
                If _prm Is Nothing Then
                    MsgBox("невозможно показать форму с изображениями", vbCritical)
                End If
                Dim _fmImage As Form
                'show image form
                Dim _param As Object = {_prm, ""}
                'если делегата нет, то сервис недоступен
                If Not Global.Service.clsApplicationTypes.DelegateStoreApplicationForm(Service.clsApplicationTypes.emFormsList.fmImage) Is Nothing Then
                    'сервис зарегестрирован - вызываем
                    _fmImage = Global.Service.clsApplicationTypes.DelegateStoreApplicationForm(Service.clsApplicationTypes.emFormsList.fmImage).Invoke(_param)
                    If Not _fmImage Is Nothing Then
                        'show form
                        _fmImage.Width = 640
                        _fmImage.Height = 480
                        _fmImage.StartPosition = FormStartPosition.CenterScreen
                        'привязка обработчика
                        'Service.clsApplicationTypes.DelegatStorefmImageDeleteDelegate = New Service.clsApplicationTypes.fmImageDeleteDelegat(AddressOf DelImage_eventHandler)
                        'Service.clsApplicationTypes.DelegatStorefmImageCopyDelegate = New Service.clsApplicationTypes.fmImageCopyDelegat(AddressOf CopyImage_eventHandler)
                        _fmImage.ShowDialog()
                    End If
                End If
                '======= 'инфо по номеру
            Case Me.oSKUColumnIndex
                'инфо по номеру
                Me.oSplashscreen.Show()
                Application.DoEvents()
                Dim _sampleNumber = clsApplicationTypes.clsSampleNumber.CreateFromString(nop_DataGridView.Rows(e.RowIndex).Cells(e.ColumnIndex).Value)
                If Not _sampleNumber.CodeIsCorrect Then Return
                Me.tbShotNumber.Text = _sampleNumber.ShotCode
                Me.UserControlMC1.SampleNumber = _sampleNumber
                Me.Uc_trilbone_history1.SampleNumber = _sampleNumber.ShotCode
                'Me.UserControlEbaySearch1.SearchName = clsApplicationTypes.RejectSkobki(nop_DataGridView.Rows(e.RowIndex).Cells(oNameColumnIndex).Value)
                Me.tbCtlMain.SelectedTab = Me.tpStatus
                Me.btSeeLog_Click(sender, e)
                Me.oSplashscreen.Hide()

                '===вызвать форму оформления
            Case Me.oNameColumnIndex
                Me.WindowState = FormWindowState.Minimized
                Application.DoEvents()
                Dim _num = Me.nop_DataGridView.Rows(e.RowIndex).Cells(Me.oSKUColumnIndex).Value
                If String.IsNullOrEmpty(_num) Then Return
                clsApplicationTypes.ExternalLoadSample(_num)
                clsApplicationTypes.BeepYES()
        End Select
    End Sub
    ''' <summary>
    ''' одинарный правый счелчек
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub nop_DataGridView_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles nop_DataGridView.CellMouseClick
        Select Case e.Button

            Case Windows.Forms.MouseButtons.Right
                Select Case e.ColumnIndex
                    '=====удалить с сайта
                    Case Me.oSKUColumnIndex
                        'удалить с сайта
                        Dim _sm As clsApplicationTypes.clsSampleNumber = nop_DataGridView.Rows(e.RowIndex).Cells(oSKUColumnIndex).Tag
                        Select Case MsgBox(String.Format("Удалить {0} с сайта?", _sm.ShotCode), vbYesNo, "Удаление образца")
                            Case MsgBoxResult.Yes
                                If clsApplicationTypes.DelegateStoreRemoveSampleOnSite Is Nothing Then
                                    MsgBox("Отсутствует делегат. Запрос с сайта не возможен.", vbCritical)
                                    Return
                                End If
                                nop_DataGridView.Rows.Remove(nop_DataGridView.Rows(e.RowIndex))
                                Dim serverMessage As String = ""
                                Dim _res = clsApplicationTypes.DelegateStoreRemoveSampleOnSite.Invoke(_sm.ShotCode, "trilbone", "DeleteProduct", serverMessage)
                                If _res = Net.HttpStatusCode.OK Then
                                    MsgBox(serverMessage, vbInformation)
                                    'добавить в бд Trilbone
                                    If clsApplicationTypes.SampleDataObject.RegisterDeleteSampleOnSiteTrilbone(_sm) Then
                                        MsgBox("Действие записано в БД Trilbone", vbInformation)
                                    Else
                                        MsgBox("Не удалось зарегестрировать действие в БД Trilbone", vbInformation)
                                    End If
                                Else
                                    MsgBox(serverMessage, vbCritical)
                                End If
                                Return
                        End Select
                        '=====информация о статистике цен по имени
                    Case Me.oBasePriceColumnIndex
                        Dim _result As clsSellInfo
                        Dim _namePart As String

                        'берем часть имени из заголовка
                        If Not String.IsNullOrEmpty(Me.tbNameFilter.Text) Then
                            _namePart = Me.tbNameFilter.Text.Trim
                        Else
                            'или из значения ячейки
                            _namePart = nop_DataGridView.Rows(If(e.RowIndex < 0, 0, e.RowIndex)).Cells(Me.oNameColumnIndex).Value.ToString.Split(" ").FirstOrDefault
                        End If

                        _namePart = nop_DataGridView.Rows(If(e.RowIndex < 0, 0, e.RowIndex)).Cells(Me.oNameColumnIndex).Value.ToString.Split(" ").FirstOrDefault

                        If String.IsNullOrEmpty(_namePart) Then Return

                        _namePart = _namePart.ToLower()
                        Me.oSplashscreen.Show()
                        'получить обьект-источник данных
                        _result = clsSellInfo.GetStatistic(_namePart, "", 0)
                        Me.oSplashscreen.Hide()
                        Me.ContextMenuStrip1.Items.Clear()

                        If _result.Count > 0 Then
                            Me.ContextMenuStrip1.Items.AddRange(_result.GetMenuItems)
                            Me.ContextMenuStrip1.Show(nop_DataGridView.PointToScreen(e.Location))
                        Else
                            MsgBox("По подобным образца данных нет", vbInformation)
                        End If
                        '=====информация по наличию
                    Case Me.oWareNameColumnIndex
                        'Dim _result As clsSellInfo
                        'Dim _namePart As String
                        Dim _sm As clsApplicationTypes.clsSampleNumber = If(e.RowIndex >= 0, nop_DataGridView.Rows(e.RowIndex).Cells(oSKUColumnIndex).Tag, Nothing)

                        Dim _r = _sm.AskLocations
                        Dim _cell = nop_DataGridView.Rows(e.RowIndex).Cells(Me.oWareNameColumnIndex)
                        _cell.ToolTipText = _r
                        _cell.Value = _r
                        CellWareNarvaCheckFormat(_cell)
                        clsApplicationTypes.BeepYES()

                        '===информация о статистике цен по имени + клиент = счелк по клиентской цене
                    Case Is > (oStaticColumnCount - 1)
                        Dim _result As clsSellInfo
                        Dim _namePart As String
                        Dim _sm As clsApplicationTypes.clsSampleNumber = If(e.RowIndex >= 0, nop_DataGridView.Rows(e.RowIndex).Cells(oSKUColumnIndex).Tag, Nothing)
                        'клиент 
                        Dim _client = nop_DataGridView.Columns(e.ColumnIndex).HeaderText.Trim.ToLower
                        'берем часть имени из заголовка
                        If Not String.IsNullOrEmpty(Me.tbNameFilter.Text) Then
                            _namePart = Me.tbNameFilter.Text.Trim
                        Else
                            'или из значения ячейки
                            _namePart = nop_DataGridView.Rows(If(e.RowIndex < 0, 0, e.RowIndex)).Cells(Me.oNameColumnIndex).Value.ToString.Split(" ").FirstOrDefault
                        End If

                        If String.IsNullOrEmpty(_namePart) Then Return

                        _namePart = _namePart.ToLower()

                        'счелчек по колонке цены клиента
                        If oPriceColumnIndexCollection.Contains(e.ColumnIndex) Then
                            'счелк по цене для клиента
                            Me.oSplashscreen.Show()
                            'получить обьект-источник данных
                            _result = clsSellInfo.GetStatistic(_namePart, _client, 0)
                            Me.oSplashscreen.Hide()
                            Me.ContextMenuStrip1.Items.Clear()

                            If _result.Count > 0 Then
                                Me.ContextMenuStrip1.Items.AddRange(_result.GetMenuItems)
                                Me.ContextMenuStrip1.Show(nop_DataGridView.PointToScreen(e.Location))
                            Else
                                MsgBox("По подобным образца данных нет", vbInformation)
                            End If
                        End If

                        '===обновить форматирование строки
                    Case Me.oNameColumnIndex
                        Dim _nop As iNopDataProvider.clsNopProduct = Me.nop_DataGridView.Rows(e.RowIndex).Tag
                        Me.LoadRow(_nop, e.RowIndex)
                        clsApplicationTypes.BeepYES()

                        '===посмотреть HTML карту из БД используем шаблон сайта-майла = Site_mail_template
                    Case Me.oPhotoColumnIndex
                        Dim _sm As clsApplicationTypes.clsSampleNumber = If(e.RowIndex >= 0, nop_DataGridView.Rows(e.RowIndex).Cells(oSKUColumnIndex).Tag, Nothing)

                        Dim _result As Integer
                        Dim _sdo = clsApplicationTypes.SampleDataObject.GetSampleOnSale(_sm, _result, CreateIfNotExist:=True)

                        If _result < 1 OrElse _sdo Is Nothing Then
                            MsgBox("Невозможно извлечь карту образца из БД. Неудачная попытка запросить обьект с сервера.", vbCritical)
                            Return
                        End If

                        Dim _xml As String = _sdo.SampleXMLFile
                        Dim _template = clsApplicationTypes.emTemplateType.Site_mail_template
                        If Me.cbxRussian.Checked Then
                            _xml = _sdo.SampleXMLFileRU
                        End If

                        If Not _xml = "" Then
                            'в БД есть сохраненная карта XML
                            Dim _html = clsApplicationTypes.DelegateStoreGetTransform.Invoke(_xml, _template, "")
                            Dim _caption = nop_DataGridView.Rows(e.RowIndex).Cells(oNameColumnIndex).Value
                            Dim _catname = String.Format("{0} {1}", clsApplicationTypes.RejectSkobki(_caption), _sm.ShotCode)
                            Dim _fm = clsApplicationTypes.Browser(_html, _caption, _catname)
                            _fm.ShowDialog()
                        Else
                            MsgBox("Карты образца в БД нет", vbInformation)
                        End If
                End Select


        End Select
    End Sub

    ''' <summary>
    ''' основная процедура сохранения значений
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub nop_DataGridView_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles nop_DataGridView.CellValueChanged
        If oIsInit Then Return
        If Not (e.ColumnIndex > -1 AndAlso e.RowIndex > -1) Then Return

        Dim _isShopAllow As Boolean = oShopAllowColumnIndexCollection.Contains(e.ColumnIndex)
        Dim _isRoleAllow As Boolean = oRoleAllowColumnIndexCollection.Contains(e.ColumnIndex)
        Dim _isPriceRole As Boolean = oPriceColumnIndexCollection.Contains(e.ColumnIndex)
        Dim _isMail As Boolean = oRoleMailColumnIndexCollection.Contains(e.ColumnIndex)

        Dim _isBasePrice As Boolean = False
        If e.ColumnIndex = oBasePriceColumnIndex Then
            _isPriceRole = False
            _isBasePrice = True
        End If

        Dim _currentCellValue = Me.nop_DataGridView.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
        Dim _currentCell = Me.nop_DataGridView.Rows(e.RowIndex).Cells(e.ColumnIndex)
        Dim _sku As String = nop_DataGridView.Rows(e.RowIndex).Cells(oSKUColumnIndex).Value
        Dim _roleAllow As Boolean
        Dim _shopAllow As Boolean
        Dim _price As Decimal
        '=====================================
        'внесение изменений в магазин
        If _isShopAllow Then
            Dim _shopId As Integer = nop_DataGridView.Columns(e.ColumnIndex).Tag
            _shopAllow = _currentCellValue
            If oSite.AllowShop(_sku, _shopId, _shopAllow) Then
                CellAllowRoleFormat(_currentCell)
                clsApplicationTypes.BeepYES()
                Return
            End If
            MsgBox("Изменения по магазинам в БД не сохранены!", vbInformation)
            Return
        End If
        '=====================================
        'определение доступа для роли
        If _isRoleAllow Then
            Dim _roleId As Integer = nop_DataGridView.Columns(e.ColumnIndex).Tag
            _roleAllow = _currentCellValue
            If oSite.AllowRole(_sku, _roleId, _roleAllow) Then
                'Успешно записан доступ
                CellAllowRoleFormat(_currentCell)
                'проверить историю цен
                Dim _history = clsApplicationTypes.SampleDataObject.GetSampleHistoryInfo(_sku)
                Dim _historestring As String = ""
                Dim _historyPrice As Decimal
                Dim _rolename = oRoles.Find(Function(x) x.id = _roleId).Name
                If _history.HistoryRecords(_rolename).Count > 0 Then
                    'уже был предложен
                    'минимальная предложенная цена в рублях
                    Dim _minpr = _history.HistoryRecords(_rolename).Where(Function(x) x.CurrentRURAmount = _history.HistoryRecords(_rolename).Min(Function(y) y.CurrentRURAmount)).FirstOrDefault
                    If Not _minpr Is Nothing Then
                        _historyPrice = Me.ConvertPrice(_minpr.CurrentRURAmount, "RUR", oCurrentCurrency)
                        _historestring = String.Format("(минимальная цена {1}{2} была предложена {0})", _minpr.DateRecord.ToShortDateString, _historyPrice, oCurrentCurrency)
                    End If
                End If

                If _roleAllow Then
                    'доступ разрешен
                    'установить цену 
                    'ввести цену
                    Dim _newprice As String
rpr:
                    _newprice = InputBox(String.Format("Цена образца для роли {0} {1} в {2}", oRoles.Find(Function(x) x.id = _roleId).Name, _historestring, oCurrentCurrency), "Цена образца", Decimal.Round(nop_DataGridView.Rows(e.RowIndex).Cells(oBasePriceColumnIndex).Value))
                    If clsApplicationTypes.ReplaceDecimalSplitter(_newprice) = 0 Then GoTo rpr

                    oIsInputedPrice = True

                    nop_DataGridView.Rows(e.RowIndex).Cells(e.ColumnIndex + oRolePriceColumnRelativeIndex).Value = clsApplicationTypes.ReplaceDecimalSplitter(_newprice)

                    Dim _mailCell = nop_DataGridView.Rows(e.RowIndex).Cells(e.ColumnIndex + 1)

                    'проверка истории
                    If _history.EmailSended(_rolename) Then
                        'уже отослан
                        _currentCellValue = False
                        Me.CellMailAlreadySentFormat(_mailCell)
                    Else
                        Me.CellMAilFormat(_mailCell)
                    End If

                Else
                    'снят с предложения, сбросить цену
                    nop_DataGridView.Rows(e.RowIndex).Cells(e.ColumnIndex + oRolePriceColumnRelativeIndex).Value = 0
                    ''проверка истории
                    If _history.HistoryRecords(oRoles.Find(Function(x) x.id = _roleId).Name).Count > 0 Then
                        'уже был предложен - установка исторической цены далее 
                        CellAlreadyOfferRoleFormat(_currentCell)
                    End If
                End If
                clsApplicationTypes.BeepYES()
                Return
            End If
            MsgBox("Изменения по ролям в БД не сохранены!", vbInformation)
            Return
        End If
        '=====================================
        'внесение изменений в цену роли
        If _isPriceRole Then
            'не обрабатывать изменение цены в ячейке
            If oIsSetPrice Then oIsSetPrice = False : Return
            Dim _roleId As Integer = nop_DataGridView.Columns(e.ColumnIndex - 1).Tag
            _price = _currentCellValue
            Dim _message As String
            'проверка истории
            Dim _history = clsApplicationTypes.SampleDataObject.GetSampleHistoryInfo(_sku)
            'текущая роль клиента
            Dim _roleName = Me.nop_DataGridView.Columns(e.ColumnIndex).HeaderText.Trim
            If _price > 0 Then
                'Цена ПОЛОЖИТЕЛЬНАЯ
                If Not oIsInputedPrice Then
                    If _history.HistoryRecords(_roleName).Count > 0 Then
                        'уже был предложен
                        'минимальная предложенная цена в рублях
                        Dim _minpr = _history.HistoryRecords(_roleName).Where(Function(x) x.CurrentRURAmount = _history.HistoryRecords(_roleName).Min(Function(y) y.CurrentRURAmount)).FirstOrDefault
                        If Not _minpr Is Nothing Then
                            Select Case MsgBox(String.Format("Образец предлагался ранее ({0}) по цене {1}{2}. Поставить старую цену (Да) или предложить по новой цене {3}{2} (Нет)?", _minpr.DateRecord.ToShortDateString, Me.ConvertPrice(_minpr.CurrentRURAmount, "RUR", oCurrentCurrency), oCurrentCurrency, Decimal.Round(_price, 0)), MsgBoxStyle.YesNo)
                                Case MsgBoxResult.Yes
                                    _price = Me.ConvertPrice(_minpr.CurrentRURAmount, "RUR", oCurrentCurrency)
                                Case MsgBoxResult.No
                                    _price = _price
                            End Select
                        End If
                    End If
                Else
                    oIsInputedPrice = False
                End If
                Dim _role = oRoles.Find(Function(x) x.id = _roleId).Name
                _message = String.Format("Установить цену к {1} = {3}{4} ({2}руб) для роли {0}?", _role, _sku, clsApplicationTypes.RoundPrice(Me.ConvertPrice(_price, oCurrentCurrency, "RUR")), _price, oCurrentCurrency)

                Select Case MsgBox(_message, vbYesNo)
                    Case MsgBoxResult.Yes
                        'учесть округление
                        Dim _rurPrice = clsApplicationTypes.RoundPrice(Me.ConvertPrice(_price, oCurrentCurrency, "RUR"))
                        If oSite.SetPrice(_sku, _roleId, _rurPrice) Then
                            CellPriceGreenFormat(_currentCell)
                            'запись в бд изменений
                            Dim _trres = clsApplicationTypes.SampleDataObject.RegisterSampleToSiteTrilbone(SampleNumber:=clsApplicationTypes.clsSampleNumber.CreateFromString(_sku), ResourceName:=_role.Trim & "- all shops", clientName:=_role.Trim, currency:=oCurrentCurrency, InsectionFee:=0, itemamount:=Me.ConvertPrice(_rurPrice, "RUR", oCurrentCurrency), itemcondition:=Nothing, itemtitle:=nop_DataGridView.Rows(e.RowIndex).Cells(oNameColumnIndex).Value.ToString, ResourceID:=clsSampleDataManager.emSLResource.SiteTrilbone)
                            If _trres Then
                                clsApplicationTypes.BeepYES()
                                ' MsgBox("Предложение внесено в БД Trilbone.", vbInformation)
                            End If
                        End If
                        Return
                End Select
                MsgBox("Изменения по ценам в БД не сохранены", vbInformation)
                Return
            Else
                'стереть цену
                If oSite.SetPrice(_sku, _roleId, 0) Then
                    'проверка истории
                    If _history.HistoryRecords(_roleName).Count > 0 Then
                        'минимальная предложенная цена
                        oIsSetPrice = True
                        Me.nop_DataGridView.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = Decimal.Round(_history.HistoryRecords(_roleName).Min(Function(x) Me.ConvertPrice(x.CurrentRURAmount, "RUR", oCurrentCurrency)), 2)
                        CellPriceAlreadyOfferFormat(_currentCell)
                    Else
                        CellPriceGreenFormat(_currentCell)
                    End If
                    ''запись в бд изменений
                    Return
                Else
                    MsgBox("Изменения по ценам в БД не сохранены", vbInformation)
                    Return
                End If
            End If
        End If
        '=====================================
        'внесение изменений в базовую цену
        If _isBasePrice Then
            _price = Me.ConvertPrice(_currentCellValue, oCurrentCurrency, "RUR")
            Dim _convertPrice = clsApplicationTypes.RoundPrice(_price)
            Select Case MsgBox(String.Format("Новое значение базовой цены (в руб) = {0} (в валюте {1}{2})", _convertPrice, _currentCellValue, oCurrentCurrency), vbYesNo)
                Case MsgBoxResult.Yes
                    If oSite.SetPrice(nop_DataGridView.Rows(e.RowIndex).Cells(oSKUColumnIndex).Value, 0, _convertPrice) Then
                        CellPriceGreenFormat(_currentCell)
                        'запомнить цену в мс
                        Dim _msi = clsApplicationTypes.MoySklad(False)
                        If _msi Is Nothing Then
                            MsgBox("Не удалость записать цену в МС", vbCritical)
                            Return
                        Else

                            MsgBox(_msi.UpdateGoodPrice(nop_DataGridView.Rows(e.RowIndex).Cells(oSKUColumnIndex).Value, 0, "", _currentCellValue, oCurrentCurrency, "шт", "", 0), vbInformation)
                            Return
                        End If
                    End If
                    Return
            End Select
            MsgBox("Изменения базовой цены в БД не сохранены", vbInformation)
            Return
        End If
        '============
        'email
        If _isMail Then
            If _currentCellValue = True Then
                'проверка истории отсылки писем
                Dim _history = clsApplicationTypes.SampleDataObject.GetSampleHistoryInfo(_sku)
                Dim _roleName = Me.nop_DataGridView.Columns(e.ColumnIndex + oRolePriceColumnRelativeIndex - oRoleMailColumnRelativeIndex).HeaderText.Trim
                If _history.EmailSended(_roleName) Then
                    'уже отослан - выход
                    _currentCellValue = False
                    Me.CellMailAlreadySentFormat(_currentCell)
                    Return
                End If
                If Me.tbClientName.Text.Trim = "" Then
                    Me.tbClientName.Text = _roleName
                End If
                Me.oTotalMails += 1
            Else
                Me.oTotalMails -= 1
                If Me.oTotalMails < 0 Then Me.oTotalMails = 0
            End If

            'форматирование
            Me.CellMAilFormat(_currentCell)

        End If
    End Sub
    Private Sub nop_DataGridView_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles nop_DataGridView.DataError
        MsgBox(String.Format("Ошибка значения в строке {0}, столбец {1}. Сообщение: {2}", e.RowIndex + 1, e.ColumnIndex + 1, e.Exception.Message))
    End Sub

#End Region


    ''' <summary>
    ''' отправить почту
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btSendMails_Click(sender As Object, e As EventArgs) Handles btSendMails.Click
        If Me.cbSenderMail.SelectedItem Is Nothing Then Return
        'список отправки
        'номер + адресат
        Dim _cr As clsApplicationTypes.clsMail = Me.cbSenderMail.SelectedItem
        Dim _maillist As New clsApplicationTypes.clsMailList(_cr.Mail, _cr.Password)

        Dim _msi = clsApplicationTypes.MoySklad(True)
        'собрать емайлы которые хотим отправить
        Dim _client = _msi.GetClients.Where(Function(x) x.FullName.Equals(Me.tbClientName.Text.Trim)).FirstOrDefault
        If _client Is Nothing Then
            MsgBox(String.Format("Не могу найти клиента {0} в Моем Складе. Напишите точное имя.", Me.tbClientName.Text), vbCritical)
            Return
        End If
        Me.oSplashscreen.Show()
        For Each t As DataGridViewRow In nop_DataGridView.Rows
            For Each k As DataGridViewCell In t.Cells
                If oRoleMailColumnIndexCollection.Contains(k.ColumnIndex) AndAlso k.Value = True Then
                    Dim _sm = clsApplicationTypes.clsSampleNumber.CreateFromString(t.Cells(oSKUColumnIndex).Value.ToString)
                    Dim _price = Decimal.Ceiling(t.Cells(k.ColumnIndex + oRolePriceColumnRelativeIndex - oRoleMailColumnRelativeIndex).Value)
                    _maillist.Add(New clsApplicationTypes.clsMailListItem With {.SKU = _sm, .client = _client, .Price = _price, .Currency = oCurrentCurrency})
                End If
            Next
        Next

        Me.oSplashscreen.Hide()
        If Not oTotalMails = _maillist.Count Then
            'где-то закралась ошибка в подсчете кол-ва писем
            MsgBox("Количество отмеченных к пересылке писем и успешно созданных заданий на отправку не совпадают! В следующем диалоге отмените отправку и проверте внимательно еще раз все отмеченные еМайлы.", vbInformation)
        End If

        'запрос подтверждения
        Select Case MsgBox(String.Format("Отправить {1} писем с ящика {0} клиенту {3} ({4}) с темой: {2}?", _cr.Mail, _maillist.Count, Me.tbMailCaption.Text, _client.FullName, _client.Email), vbYesNo, "Отправка eMail")
            Case MsgBoxResult.No
                Return
        End Select

        Dim _sended = _maillist.SendMailList(MailCaption:=Me.tbMailCaption.Text, culture:=oCulture, sendAscatalog:=Me.cbxSendCatalogAsMail.Checked)
        If _sended > 0 Then
            MsgBox(String.Format("Отправлено {0} писем с темой: {1}", _sended, Me.tbMailCaption.Text), vbInformation)
        Else
            MsgBox(String.Format("Ошибки при формировании писем. Письма НЕ ОТПРАВЛЕНЫ."), vbCritical)
        End If

        For Each t In _maillist.SendedParams.Where(Function(x) x.Ok = False)
            MsgBox(t.error, vbInformation)
        Next

        Dim _success = _maillist.SendedParams.Where(Function(x) x.Ok = True).ToList

        'записать в БД
        For Each t In _success
            For Each sm In t.SampleNumber
                Dim _xy = Me.GetRoleCellBaseLocation(sm.ShotCode, t.Client.FullName)
                If _xy.X = 0 Or _xy.Y = 0 Then
                    'проблема- не найден клиент
                    MsgBox(String.Format("Проблема в поучении ячейки роли клиента {1} для образца {0}. Отправленный емайл учтен в БД но не отмечен на листе.", sm.ShotCode, t.Client.FullName), vbCritical)
                Else
                    'ячейка емайл
                    Dim _cell = nop_DataGridView.Rows(_xy.X).Cells(_xy.Y + Me.oRoleMailColumnRelativeIndex - oRoleAllowColumnRelativeIndex)
                    'отметить формат
                    _cell.Value = False
                    Me.CellMailAlreadySentFormat(_cell)
                End If
                'отправка отмечается регистрацией отсылки емайла

                'If clsApplicationTypes.SampleDataObject.RegisterSendedMail(SampleNumber:=sm, clientName:=t.Client.FullName, ResourceID:=emSLResource.SiteTrilbone) Then
                '    Dim _xy = Me.GetRoleCellBaseLocation(sm.ShotCode, t.Client.FullName)
                '    If _xy.X = 0 Or _xy.Y = 0 Then
                '        'проблема- не найден клиент
                '        MsgBox(String.Format("Проблема в поучении ячейки роли клиента {1} для образца {0}. Отправленный емайл учтен в БД но не отмечен на листе.", sm.ShotCode, t.Client.FullName), vbCritical)
                '    Else
                '        'ячейка емайл
                '        Dim _cell = nop_DataGridView.Rows(_xy.X).Cells(_xy.Y + Me.oRoleMailColumnRelativeIndex - oRoleAllowColumnRelativeIndex)
                '        'отметить формат
                '        _cell.Value = False
                '        Me.CellMailAlreadySentFormat(_cell)
                '    End If
                'Else
                '    MsgBox(String.Format("Не удалось отметить отправку eMail для роли клиента {1} для образца {0}. Отправленный емайл не будет учтен в БД.", sm.ShotCode, t.Client.FullName), vbCritical)
                'End If
            Next
        Next

        Me.btSendMails.Text = "Отправить почту"

    End Sub


    ''' <summary>
    ''' вернет координаты нулевой ячейки для роли: _rowindex, _columnindex
    ''' </summary>
    ''' <param name="sku"></param>
    ''' <param name="RoleName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetRoleCellBaseLocation(sku As String, RoleName As String) As Point
        Dim _rowindex = (From c As DataGridViewRow In nop_DataGridView.Rows
                         Where c.Cells(oSKUColumnIndex).Value.ToString.Equals(sku)
                         Select c.Index).FirstOrDefault

        Dim _columnindex = (From c As DataGridViewColumn In nop_DataGridView.Columns
                            Where c.HeaderText.ToLower.Equals(RoleName.ToLower)
                            Select c.Index).FirstOrDefault

        Return New Point(_rowindex, _columnindex - oRolePriceColumnRelativeIndex)
    End Function

    ''' <summary>
    ''' изменение скрываемых ролей
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub NumericUpDownRole_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDownRole.ValueChanged
        If oFullProductList Is Nothing Then Return
        btApplyFilter_Click(Me.btApplyFilter, EventArgs.Empty)
    End Sub

    ''' <summary>
    ''' смена языка
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cbxRussian_CheckedChanged(sender As Object, e As EventArgs) Handles cbxRussian.CheckedChanged
        If cbxRussian.Checked Then
            'перевод на русский
            Me.oCulture = clsApplicationTypes.RussianCulture
            Me.tbMailCaption.Text = "Новое предложение"
        Else
            Me.oCulture = clsApplicationTypes.EnglishCulture
            Me.tbMailCaption.Text = "New offer from Trilbone"
        End If
    End Sub

    Private Sub btClearList_Click(sender As Object, e As EventArgs) Handles btClearList.Click
        Me.nop_DataGridView.Rows.Clear()
        oNextPageIndex = 0
        If Not oExceptedMCProductList Is Nothing Then
            oExceptedMCProductList.Clear()
        End If

        oCurrentProductList.Clear()
        Me.btLoadData.Text = String.Format("Загрузить ({0})", oCurrentProductList.Count)
        Me.btLoadFromMC.Text = "Добавить из МС"
        Me.btSearchWare.Text = "Не выставлено"
        Me.btGetDataFromMC.Text = "Из Мой Склад"
        Me.btApplyFilter.Text = "Фильтр"
    End Sub
    ''' <summary>
    ''' проверка наличия на складах товара с сайта и повторов
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btCheckSamples_Click(sender As Object, e As EventArgs) Handles btCheckSamples.Click
        Dim _BackgroundWorkerMC As New System.ComponentModel.BackgroundWorker

        AddHandler _BackgroundWorkerMC.DoWork, AddressOf Me._DoWork
        AddHandler _BackgroundWorkerMC.RunWorkerCompleted, AddressOf _RunWorkerCompleted

        _BackgroundWorkerMC.RunWorkerAsync(oFullProductList)
        'кнопка инфо
        clsApplicationTypes.BeepYES()
        Me.btCheckSamples.Enabled = False
    End Sub

    Private Function CheckSite(productList As List(Of iNopDataProvider.clsNopProduct)) As String
        Dim _message As String = ""
        Dim _list(productList.Count - 1) As iNopDataProvider.clsNopProduct
        productList.CopyTo(_list)
        For Each g In _list
            _message += String.Format("------{1}Обработка {0}:", g.Sku, ChrW(13))
            Dim _sm As clsApplicationTypes.clsSampleNumber = Nothing
            If g.TryGetSampleNumber(_sm) Then
                Dim _gi = _sm.GetExtendedInfo.GoodInfo
                Select Case _gi.Count
                    Case 0
                        'в мс не зарегистрирован
                        _message += String.Format("Карточка {0} отсутствует в МС.{1}", g.Sku, ChrW(13))
                    Case 1
                        'все ок - один товар
                        Dim _location = _gi(0).goodLocationInfo.Invoke(_gi(0))
                        If _location.Count = 1 AndAlso _location(0) = "Нет на складах" Then
                            'нет на складах
                            _message += String.Format("Карточка {0} НЕТ НА СКЛАДАХ. Действие:{1}", g.Sku, ChrW(13))
                            'остановить?
                            Select Case MsgBox(String.Format("{0} нет на складах. Удалить=ДА, Остановить=НЕТ Оставить=Отмена?", g.Sku), vbYesNoCancel)
                                Case MsgBoxResult.No
                                    'StopProduct останавливаем
                                    If Not clsApplicationTypes.DelegateStoreRemoveSampleOnSite Is Nothing Then
                                        Dim _serviceName = "StopProduct"
                                        Dim serverMessage As String = ""
                                        Dim _res = clsApplicationTypes.DelegateStoreRemoveSampleOnSite.Invoke(_sm.ShotCode, "trilbone", _serviceName, serverMessage)
                                        If _res = Net.HttpStatusCode.OK Then
                                            _message += String.Format("{0} ОСТАНОВЛЕН на сайте (не видим). {2} {1}", g.Sku, ChrW(13), serverMessage)
                                            'добавить в бд Trilbone
                                            If clsApplicationTypes.SampleDataObject.RegisterDeleteSampleOnSiteTrilbone(_sm) Then
                                                _message += String.Format("Действие записано в БД Trilbone{1}", g.Sku, ChrW(13))
                                            Else
                                                _message += String.Format("Не удалось зарегестрировать действие в БД Trilbone{1}", g.Sku, ChrW(13))
                                            End If
                                        Else
                                            _message += String.Format("Ошибка при остановке: {0} {1}", serverMessage, ChrW(13))
                                        End If
                                    Else
                                        _message += String.Format("Отсутствует делегат. Запрос остановки с сайта не возможен. {1}", g.Sku, ChrW(13))
                                    End If
                                Case MsgBoxResult.Yes, MsgBoxResult.Ok
                                    'DeleteProduct удаляем
                                    If Not clsApplicationTypes.DelegateStoreRemoveSampleOnSite Is Nothing Then
                                        Dim _serviceName = "DeleteProduct"
                                        Dim serverMessage As String = ""
                                        Dim _res = clsApplicationTypes.DelegateStoreRemoveSampleOnSite.Invoke(_sm.ShotCode, "trilbone", _serviceName, serverMessage)
                                        If _res = Net.HttpStatusCode.OK Then
                                            _message += String.Format("{0} УДАЛЕН с сайта. {2} {1}", g.Sku, ChrW(13), serverMessage)
                                            'добавить в бд Trilbone
                                            If clsApplicationTypes.SampleDataObject.RegisterDeleteSampleOnSiteTrilbone(_sm) Then
                                                _message += String.Format("Действие записано в БД Trilbone{1}", g.Sku, ChrW(13))
                                            Else
                                                _message += String.Format("Не удалось зарегестрировать действие в БД Trilbone{1}", g.Sku, ChrW(13))
                                            End If
                                        Else
                                            _message += String.Format("Ошибка при удалении: {0} {1}", serverMessage, ChrW(13))
                                        End If

                                    Else
                                        _message += String.Format("Отсутствует делегат. Запрос удаления с сайта не возможен. {1}", g.Sku, ChrW(13))
                                    End If

                                Case Else
                                    _message += String.Format("{0} отмена действий - ПРОВЕРИТЬ вручную!!! {1}", g.Sku, ChrW(13))
                            End Select

                        Else
                            'перечисляем нахождения
                            For Each _l In _location
                                _message += String.Format("{0}{1}", _l, ChrW(13))
                            Next
                        End If
                    Case Else
                        'несколько регистраций в МС
                        _message += String.Format("Карточка {0} присутствует в {2} экземплярах в МС. Устраните двойственность.{1}", g.Sku, ChrW(13))
                End Select
            Else
                _message += String.Format("Не удалось распознать sku {0}. Товар не будет проверен.{1}", g.Sku, ChrW(13))
            End If
        Next
        Return _message
    End Function

    Private Sub _DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs)
        ' Get the BackgroundWorker object that raised this event.
        oMSDoWork = True
        'Dim worker As System.ComponentModel.BackgroundWorker =
        '                              CType(sender, System.ComponentModel.BackgroundWorker)
        e.Result = CheckSite(e.Argument)
    End Sub

    Private Sub _RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs)
        ' First, handle the case where an exception was thrown.
        oMSDoWork = False
        If (e.Error IsNot Nothing) Then
            MessageBox.Show("Ошибка асинхронной проверки образцов: " & e.Error.Message)
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
            Dim _message = e.Result
            If _message Is Nothing Then
                clsApplicationTypes.BeepNOT()
            Else
                'отобразим сообщение
                'запишем лог
                If IO.Directory.Exists("Z:\") Then
                    System.IO.File.WriteAllText("Z:\siteCheckLog.txt", _message.ToString)
                    MsgBox("Лог проверки сайта записан как Z:\siteCheckLog.txt", vbOKOnly)
                Else
                    My.Computer.Clipboard.SetText(_message.ToString)
                    MsgBox("Z:\ не существует, лог сохранен в буфер обмена", vbOKOnly)
                End If

            End If
        End If
        Me.btCheckSamples.Enabled = True
    End Sub

End Class
