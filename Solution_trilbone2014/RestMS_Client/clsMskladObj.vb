Imports RestMS_Client.MoySkladAPI
Imports System.Runtime.CompilerServices
Imports System.Reflection
Imports RestSharp
Imports System.Text
Imports Service

''' <summary>
''' представляет краткое описание товара
''' </summary>
''' <remarks></remarks>
Public Class clsMSGood
    Implements IComparable

    Dim oSampleNumber As Service.clsApplicationTypes.clsSampleNumber


    Public Property Description As String
    ''' <summary>
    ''' вес в килограммах
    ''' </summary>
    ''' <remarks></remarks>
    Private oWeight As Decimal
    ''' <summary>
    ''' вес в килограммах
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Weight As Decimal
        Set(value As Decimal)
            If Not Me.Good Is Nothing Then
                Me.Good.weight = value
            End If
            Me.oWeight = value
        End Set

        Get
            Return Me.oWeight
        End Get
    End Property
    ''' <summary>
    ''' Производственный номер или EAN13
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property RawNumber As String

    ''' <summary>
    ''' вернет код или артикул
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property AnyCode As String
        Get
            If String.IsNullOrWhiteSpace(oCode) Then
                Return oArticul
            Else
                Return oCode
            End If
        End Get
    End Property


    Private oCode As String
    Public Property Code As String
        Get
            Return oCode
        End Get
        Set(value As String)
            oCode = value
            If Not Me.Good Is Nothing Then
                Me.Good.code = value
            End If
        End Set
    End Property
    Private oArticul As String
    Public Property Articul As String
        Get
            Return oArticul
        End Get
        Set(value As String)
            oArticul = value
            If Not Me.Good Is Nothing Then
                Me.Good.productCode = value
            End If
        End Set
    End Property
    ''' <summary>
    ''' показывает, артикул или номер у товара
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property CodeIsArticul As Boolean
        Get
            If String.IsNullOrWhiteSpace(Me.Code) Then
                Return True
            End If
            Return False
        End Get
    End Property


    Private oName As String
    Public Property Name As String
        Set(value As String)
            oName = value
            If Not Me.Good Is Nothing Then
                Me.Good.name = value
            End If
        End Set
        Get
            Return oName
        End Get
    End Property


    Private oPrices As Service.ucPriceCalc.clsPriceData

    Public Property AllPrices As Service.ucPriceCalc.clsPriceData
        Set(value As Service.ucPriceCalc.clsPriceData)
            oPrices = value
        End Set
        Get
            Return oPrices
        End Get
    End Property

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property SampleNumber As Service.clsApplicationTypes.clsSampleNumber
        Get
            If oSampleNumber Is Nothing Then
                oSampleNumber = Service.clsApplicationTypes.clsSampleNumber.CreateFromString(Me.AnyCode)
            End If
            Return oSampleNumber
        End Get
    End Property


    Private oBarcode As String
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Barcode As String
        Get
            Return oBarcode
        End Get
        Set(value As String)
            If String.IsNullOrEmpty(value) Then oBarcode = "" : Return

            Dim _sm = Service.clsApplicationTypes.clsSampleNumber.CreateFromString(value)

            If _sm.CodeIsCorrect = False Then oBarcode = "" : Return

            Me.oSampleNumber = _sm

            If Not Me.Good Is Nothing Then
                Dim _bar = New barcode
                With _bar
                    .barcode = _sm.EAN13
                    .barcodeType = barcodeType.EAN13
                    .barcodeTypeSpecified = True
                End With
                If Not Me.Good.barcode Is Nothing Then
                    If Me.Good.barcode.Count > 0 Then
                        Me.Good.barcode(0).barcode = _sm.EAN13
                        Me.Good.barcode(0).barcodeType = barcodeType.EAN13
                        Me.Good.barcode(0).barcodeTypeSpecified = True
                    Else
                        Me.Good.barcode = {_bar}
                    End If
                Else
                    Me.Good.barcode = {_bar}
                End If
            End If

            oBarcode = _sm.EAN13
        End Set
    End Property

    'Public Property Prices As Dictionary(Of String, Decimal)

    'Public Property RetailCurrency As String

    Private oGood As MoySkladAPI.good

    Private oLocation As List(Of clsGoodLocation)

    ''' <summary>
    ''' нахождение образцов()
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Locations As List(Of clsGoodLocation)
        Get
            Return oLocation
        End Get
    End Property
    ''' <summary>
    ''' общее кол-во по всем складам
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property TotalQTY As Decimal
        Get
            If Me.SlotList Is Nothing Then Return 0

            Dim _qty = (From c In Me.SlotList Select c.Qty).Sum

            Return _qty
        End Get
    End Property

    Public ReadOnly Property SlotList As List(Of clsGoodLocation.clsSlot)
        Get
            If Locations Is Nothing Then Return Nothing
            Dim _res = (From c In Locations, b In c.SlotGood Where b.Qty > 0 Select b).ToList

            Return _res

        End Get
    End Property

    ''' <summary>
    ''' размер камня?? в см
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property size As Decimal
    ' ''' <summary>
    ' ''' цена продажи
    ' ''' </summary>
    ' ''' <value></value>
    ' ''' <returns></returns>
    ' ''' <remarks></remarks>
    'Public Property SalePrice As Double
    ' ''' <summary>
    ' ''' цена закупки
    ' ''' </summary>
    ' ''' <value></value>
    ' ''' <returns></returns>
    ' ''' <remarks></remarks>
    'Public Property BuyPrice As Double

    ''' <summary>
    ''' Создаст новую коллекцию расположений образца. Для поиска в БД используйте Find()
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Function SetLocations(location As IEnumerable(Of clsGoodLocation)) As Boolean
        Me.oLocation = New List(Of clsGoodLocation)
        Me.oLocation.AddRange(location)
        Return True
    End Function
    ''' <summary>
    ''' расположение добавит в коллекцию расположений.
    ''' </summary>
    ''' <param name="location"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Function AddLocation(location As clsGoodLocation) As Boolean
        Me.oLocation.Add(location)
        Return True
    End Function

    ''' <summary>
    ''' заполнить обекты расположения на складах для образца/ FindAsEnters включит переборку оприходований(старая версия запросов)/заранее задать свойство Good
    ''' </summary>
    ''' <param name="manager"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Function FindLocations(manager As clsMoyScladManager, Optional IncludeReserved As Boolean = False) As Boolean
        If Me.Good Is Nothing Then Return False
        Me.oLocation = manager.FindLocationOfGood(Me.Good, IncludeReserved)
        Return Me.IsAllocated
    End Function


    ''' <summary>
    ''' если да, то значит образец проверен на размещение
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property IsAllocated As Boolean
        Get
            If oLocation Is Nothing Then
                'проверки небыло!
                Return False
            End If
            If oLocation.Count = 0 Then Return False
            Return True
        End Get
    End Property

    ''' <summary>
    ''' отсутствие фотографий 1=нет 0=есть -1=неизвестно
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property NotHasPhoto As Integer



    Public ReadOnly Property Good As MoySkladAPI.good
        Get
            Return oGood
        End Get
        'перенесено в updategood
        'Set(value As MoySkladAPI.good)
        '    With value
        '        Me.Code = .code
        '        Me.Name = .name
        '        Me.Articul = .productCode
        '        If Me.oWeight = 0 AndAlso value.weight > 0 Then
        '            Me.oWeight = value.weight
        '        Else
        '            value.weight = Me.oWeight
        '        End If
        '        If Not value.barcode Is Nothing Then
        '            Me.Barcode = (From c In value.barcode Select c.barcode).FirstOrDefault
        '        End If
        '        'TODO добавить другие распозновалки товара
        '    End With
        '    Me.oGood = value
        'End Set
    End Property

    ' ''' <summary>
    ' ''' вернет XML для запроса РЕСТ
    ' ''' </summary>
    ' ''' <returns></returns>
    ' ''' <remarks></remarks>
    'Public Function GetAsXML() As String

    'End Function
    ''' <summary>
    ''' вернет текст для всех ячеек расположений
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetAllocationString() As String
        Dim _out As String = ""

        For Each _l In Me.oLocation
            For Each _s In _l.SlotGood
                _out += _s.SlotString & ChrW(13)
            Next
        Next
        Return _out
    End Function


    ''' <summary>
    ''' используется для фильтрации при поиске по имени
    ''' </summary>
    ''' <param name="s"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function NameContains(s As String) As Boolean
        Return Me.Name.Trim.ToLower.Contains(s.Trim.ToLower)
    End Function
    ' ''' <summary>
    ' ''' запрашивает все приемки и оприходования. выделяет товары с переданным кодом. потом возможна асинхронная реализация.
    ' ''' </summary>
    ' ''' <returns></returns>
    ' ''' <remarks></remarks>
    'Private Function QueryServerForComingIN_old(LocGood As good, manager As clsMoyScladManager) As List(Of clsGoodLocation)
    '    Dim _data As IEnumerable(Of Object) = Nothing
    '    Dim _data_tmp As IEnumerable(Of Object) = Nothing
    '    Dim _message As String = ""
    '    Dim _allslotList As New List(Of clsGoodLocation.clsSlot)
    '    'ид склада
    '    Dim _storeUUID As String = ""
    '    'ид ячейки на складе
    '    Dim _slotUUID As String = ""
    '    '-------------------------
    '    If LocGood Is Nothing OrElse LocGood.uuid = "" Then
    '        Debug.Fail("Необходимо передать существующий в справочнике товар")
    '        Return Nothing
    '    End If
    '    'ид товара
    '    Dim _goodUUID As String = LocGood.uuid
    '    '-------------------


    '    '----------------------
    '    'запрос ВСЕХ оприходований
    '    Dim _result = manager.RequestAnyCollection(clsMoyScladManager.emMoySkladObjectTypes.Enter, _data, , , _message, "")
    '    If _result = Net.HttpStatusCode.OK Then
    '        'перебрать оприходования и найти goodUUD
    '        For Each _enter As enter In _data
    '            'перебрать коллекцию обьектов enterPosition (позиции в оприходовании)
    '            If Not _enter.enterPosition Is Nothing Then
    '                For Each _enterPosition In _enter.enterPosition
    '                    Dim _newEnterFlag As Boolean = True
    '                    If String.Equals(_enterPosition.goodUuid, _goodUUID) Then
    '                        'ид склада
    '                        _storeUUID = _enter.targetStoreUuid
    '                        'ид ячейки на складе
    '                        _slotUUID = _enterPosition.slotUuid
    '                        _allslotList.Add(New clsGoodLocation.clsSlot(_enterPosition.quantity, _storeUUID, _slotUUID))
    '                    End If
    '                Next
    '            End If

    '        Next
    '    Else
    '        'ответа нет от сервера
    '        MsgBox("Запрос оприходоваий неудачно " & _message, MsgBoxStyle.Critical)
    '    End If

    '    '----------------------------
    '    'запрос ВСЕХ приемок
    '    _result = manager.RequestAnyCollection(clsMoyScladManager.emMoySkladObjectTypes.Supply, _data, , , _message, "")
    '    If _result = Net.HttpStatusCode.OK Then
    '        'перебрать оприходования и найти goodUUD
    '        For Each _supply As supply In _data
    '            'перебрать коллекцию обьектов enterPosition (позиции в оприходовании)
    '            If Not _supply.shipmentIn Is Nothing Then
    '                For Each _shipmentIn In _supply.shipmentIn
    '                    Dim _newEnterFlag As Boolean = True
    '                    If String.Equals(_shipmentIn.goodUuid, _goodUUID) Then
    '                        'ид склада
    '                        _storeUUID = _supply.targetStoreUuid
    '                        'ид ячейки на складе
    '                        _slotUUID = _shipmentIn.slotUuid
    '                        _allslotList.Add(New clsGoodLocation.clsSlot(_shipmentIn.quantity, _storeUUID, _slotUUID))
    '                    End If
    '                Next
    '            End If

    '        Next
    '    Else
    '        'ответа нет от сервера
    '        MsgBox("Запрос приемок неудачно " & _message, MsgBoxStyle.Critical)
    '    End If

    '    'нет на складах
    '    If _allslotList.Count = 0 Then
    '        Return New List(Of clsGoodLocation)
    '    End If

    '    'теперь добавим слоты в класс
    '    'сгруппируем по складам
    '    Dim _res = (From c In _allslotList Let b = c.WarehoseUUID Group c By b Into Group Select New clsGoodLocation(LocGood, b) With {.SlotGood = Group.ToList}).ToList

    '    'подом надо вызвать LoadObject() для загрузки содержимого из базы
    '    'установить связь
    '    For Each t In _res
    '        For Each c In t.SlotGood
    '            c.Parent = t
    '        Next
    '        t.LoadObjects(manager)
    '    Next

    '    Return _res.ToList

    'End Function




    ' ''' <summary>
    ' ''' выведет строку артикул + имя
    ' ''' </summary>
    ' ''' <value></value>
    ' ''' <returns></returns>
    ' ''' <remarks></remarks>
    'Public ReadOnly Property GetArticulNameString() As String
    '    Get
    '        Dim _str As String = ""
    '        If Me.Code = "" Then
    '            _str = "art. " & Articul & " --> " & Name
    '        ElseIf Articul = "" Then
    '            _str = "(" & Code & ")" & " --> " & Name
    '        Else
    '            _str = "art. " & Articul & " (" & Code & ")" & " --> " & Name
    '        End If

    '        If Not Me.Good Is Nothing Then
    '            _str += " [" & Me.oGood.salePrice / 100 & "]"
    '        End If
    '        Return _str
    '    End Get
    'End Property
    ''' <summary>
    ''' создатст незаполненный обьект из товара
    ''' </summary>
    ''' <param name="good"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CreateInstance(good As good) As clsMSGood
        Dim _new As New clsMSGood
        _new.UpdateGood(good)
        Return _new
    End Function




    Public Function CompareTo(obj As Object) As Integer Implements System.IComparable.CompareTo
        'сортировка 1 по артикулу
        If obj Is Nothing Then Return 0
        If Not TypeOf obj Is clsMSGood Then Return 0

        Dim _cmp = CType(obj, clsMSGood)

        Dim _comAR = String.Compare(Me.Articul, _cmp.Articul, True)
        If _comAR = 0 Then
            _comAR = String.Compare(Me.Code, _cmp.Code, True)
        End If
        Return _comAR
    End Function




    Private ReadOnly Property Entity As MoySkladAPI.accountEntity
        Get
            If Good Is Nothing Then Return Nothing
            Return CType(Good, MoySkladAPI.accountEntity)
        End Get
    End Property

    ' ''' <summary>
    ' ''' хранит изображение кода товара
    ' ''' </summary>
    ' ''' <value></value>
    ' ''' <returns></returns>
    ' ''' <remarks></remarks>
    'Public Property EANLabel As Image



    Public ReadOnly Property UUID As String
        Get
            If Good Is Nothing Then Return ""
            Return Good.uuid
        End Get
    End Property
    ''' <summary>
    ''' основной код обмена
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property ExternalCode As String
        Get
            If Good Is Nothing Then Return ""
            Return Good.externalcode
        End Get
    End Property





    ' ''' <summary>
    ' ''' помечает товар для обновления
    ' ''' </summary>
    'Public Property HasChanges As Boolean
    '    Get
    '        Return False
    '    End Get
    '    Set(value As Boolean)

    '    End Set
    'End Property

    ''' <summary>
    ''' загружен товар с сервера
    ''' </summary>
    Public ReadOnly Property HasServerGood As Boolean
        Get
            If Me.Good Is Nothing Then Return False
            Return True
        End Get
    End Property
    ''' <summary>
    ''' дата последнего обновления
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property UpdatedDate As Date
        Get
            If HasServerGood Then
                Return Me.Good.updated
            End If
            Return Date.MinValue
        End Get
    End Property
    ''' <summary>
    ''' кто последний обновлял
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property UpdatedWoker As String
        Get
            If HasServerGood Then
                Return Me.Good.updatedBy
            End If
            Return ""
        End Get
    End Property
    ''' <summary>
    '''осноновная функция иниц. товара
    ''' </summary>
    ''' <param name="newgood"></param>
    ''' <remarks></remarks>
    Public Sub UpdateGood(newgood As good)
        Debug.Assert(Not newgood Is Nothing, "попытка обновить товар пустым обьектом")
        If newgood Is Nothing Then
            Return
        End If
        Me.oGood = newgood

        With Good
            Me.Code = .code
            Me.Name = .name
            Me.Articul = .productCode
            If Me.oWeight = 0 AndAlso .weight > 0 Then
                Me.oWeight = .weight
            Else
                .weight = Me.oWeight
            End If
            If Not .barcode Is Nothing Then
                Me.Barcode = (From c In .barcode Select c.barcode).FirstOrDefault
            End If



            'TODO добавить другие распозновалки товара
        End With
    End Sub


    Public Sub New()
        'инициализация good не производится!!!
    End Sub

    Public Overrides Function Equals(obj As Object) As Boolean
        If obj Is Nothing Then Return False
        If Not TypeOf (obj) Is clsMSGood Then Return False
        If CType(obj, clsMSGood).UUID = "" Then
            'UUID входящий не существует
            'сравнить номера
            If CType(obj, clsMSGood).Code = Me.Code Then Return True
            If CType(obj, clsMSGood).Articul = Me.Articul Then Return True
            Return False
        ElseIf Not Me.UUID = "" Then
            'оба UUID существуют
            If CType(obj, clsMSGood).UUID = Me.UUID Then Return True
            Return False
        ElseIf Me.UUID = "" Then
            'текущий UUID не существует
            'сравнить номера
            If CType(obj, clsMSGood).Code = Me.Code Then Return True
            If CType(obj, clsMSGood).Articul = Me.Articul Then Return True
            Return False
        End If

        Return False
    End Function

    Public Overrides Function GetHashCode() As Integer
        If Me.UUID = "" Then
            'UUID входящий не существует
            If Not Me.Code = "" Then Return Me.Code.GetHashCode
            If Not Me.Articul = "" Then Return Me.Articul.GetHashCode
            Return MyBase.GetHashCode
        End If
        Return Me.UUID.GetHashCode
    End Function



    Public Overrides Function ToString() As String
        Dim _out As String = ""
        If Not Me.Code = "" Then
            _out += "код " & Me.Code
        End If
        If Not Me.Articul = "" Then
            _out += " арт. " & Me.Articul
        End If
        Return _out & " " & Me.Name
    End Function
End Class
''' <summary>
''' технический класс
''' </summary>
''' <remarks></remarks>
Public Class clsGoodLocation
    Implements IComparable
    Implements System.ComponentModel.INotifyPropertyChanged
    Implements ICloneable

    'Implements ICloneable
    '===================================================

    '===================================================
    Public Class clsSlot
        Implements System.ComponentModel.INotifyPropertyChanged
        Implements ICloneable

        Dim oQty As Double
        Dim oReservedQty As Decimal
        Dim oReserveIncluding As Boolean
        Dim oUomName As String
        Dim oWarehoseUUID As String
        Dim oParent As clsGoodLocation
        Dim oSlotUUID As String
        Dim oSlotName As String

        Public Property Qty As Double
            Get
                Return oQty
            End Get
            Set(value As Double)
                If Not oQty = value Then
                    oQty = value
                    RaisePropertyChanged("Qty")
                End If

            End Set
        End Property

        Private oSlot As slot
        ''' <summary>
        ''' строковое представление с указанием склада, ячеек и кол-ва
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property SlotString As String
            Get
                Return Me.ToString
            End Get
        End Property

        Public Property ESlot As slot
            Get

                Return oSlot
            End Get
            Set(value As slot)
                If Not value Is Nothing Then
                    Me.oSlotUUID = value.uuid
                    Me.oSlotName = value.name
                Else
                    Me.oSlotUUID = ""
                    Me.oSlotName = ""
                End If
                Me.oSlot = value
                RaisePropertyChanged("ESlot")
                RaisePropertyChanged("SlotUUID")
                RaisePropertyChanged("SlotName")
            End Set
        End Property

        Public ReadOnly Property SlotName As String
            Get
                Return oSlotName
            End Get
        End Property

        Public ReadOnly Property SlotUUID As String
            Get
                Return oSlotUUID
            End Get
        End Property

        Public Property UomName As String
            Get
                Return oUomName
            End Get
            Set(value As String)
                oUomName = value
                RaisePropertyChanged("UomName")
            End Set
        End Property

        Public Property WarehouseUUID As String
            Get
                Return oWarehoseUUID
            End Get
            Set(value As String)
                oWarehoseUUID = value
                RaisePropertyChanged("WarehouseUUID")
            End Set
        End Property

        Private oWarehouse As warehouse
        Public Property EWarehouse As warehouse
            Get
                Return oWarehouse
            End Get
            Set(value As warehouse)
                If Not value Is Nothing Then
                    Me.WarehouseUUID = value.uuid
                End If
                Me.oWarehouse = value
                RaisePropertyChanged("EWarehouse")
            End Set
        End Property
        Private Sub New()

        End Sub

        'Public Sub New(Eposition As comingIn, EWarehouse As warehouse, Eslot As slot)
        '    Me.EPosition = Eposition
        '    Me.ESlot = Eslot
        'End Sub

        ''' <summary>
        ''' предварительно заполненный обьект
        ''' </summary>
        ''' <param name="inQty"></param>
        ''' <param name="WhouseUUID"></param>
        ''' <param name="SlUUID"></param>
        ''' <remarks></remarks>
        Public Sub New(inQty As Double, WhouseUUID As String, SlUUID As String)
            Me.Qty = inQty
            Me.oSlotUUID = SlUUID
            Me.WarehouseUUID = WhouseUUID
        End Sub
        ''' <summary>
        ''' означает, что товар может быть в резерве
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ReserveIncluding As Boolean
            Get
                Return oReserveIncluding
            End Get
            Set(value As Boolean)
                oReserveIncluding = value
                RaisePropertyChanged("ReserveIncluding")
            End Set
        End Property

        ''' <summary>
        ''' кол-во в резерве
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ReservedQty As Decimal
            Get
                Return oReservedQty
            End Get
            Set(value As Decimal)
                oReservedQty = value
                RaisePropertyChanged("ReservedQty")
            End Set
        End Property

        Public Property Parent As clsGoodLocation
            Get
                Return oParent
            End Get
            Set(value As clsGoodLocation)
                oParent = value
                AddHandler Me.PropertyChanged, AddressOf oParent.SlotPropertyChanged_EventHandler
            End Set
        End Property

        Public Overrides Function ToString() As String
            Dim _out As String = ""
            Dim _flag As Boolean = False

            If Not oWarehouse Is Nothing Then
                _out += String.Format("{0}", oWarehouse.name)
                _flag = True
            End If

            If Not oSlot Is Nothing Then
                _out += String.Format("->{0}", oSlot.name)
                _flag = True
            End If

            If _flag Then
                _out += String.Format("->{0}{1}", Me.Qty.ToString, Me.UomName)
            End If

            If Me.ReserveIncluding Then
                _out += String.Format(" (резерв {0}{1})", Me.ReservedQty, Me.UomName)
            End If

            Return _out
        End Function

        Public Event PropertyChanged(sender As Object, e As System.ComponentModel.PropertyChangedEventArgs) Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged


        Protected Sub RaisePropertyChanged(ByVal propertyName As String)
            Dim propertyChanged As System.ComponentModel.PropertyChangedEventHandler = Me.PropertyChangedEvent
            If (Not (propertyChanged) Is Nothing) Then
                propertyChanged(Me, New System.ComponentModel.PropertyChangedEventArgs(propertyName))
            End If
        End Sub

        Public Function Clone() As Object Implements ICloneable.Clone
            Dim _new As New clsSlot
            With _new
                .oSlotUUID = oSlotUUID
                .oSlotName = oSlotName
                .ESlot = ESlot
                .EWarehouse = EWarehouse
                .Parent = Parent
                .Qty = Qty
                .ReservedQty = ReservedQty
                .ReserveIncluding = ReserveIncluding
                .UomName = UomName
                .WarehouseUUID = WarehouseUUID
                .oWarehoseUUID = oWarehoseUUID
            End With
            Return _new
        End Function
    End Class

    Dim oGood As MoySkladAPI.good

    '========================================================
    Public Property WarehouseUUID As String

    Private oWarehouseName As String
    Public Property WarehouseName As String
        Get
            If Not oWarehouse Is Nothing Then
                oWarehouseName = oWarehouse.name
            End If
            Return oWarehouseName
        End Get
        Set(value As String)
            oWarehouseName = value
            RaisePropertyChanged("WarehouseName")
        End Set
    End Property
    ''' <summary>
    ''' привязанное к складу списание
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property LinkedLoss As loss


    Private oLinkedEnter As enter
    ''' <summary>
    ''' привязанное к складу оприходование
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property LinkedEnter As enter
        Get
            Return oLinkedEnter
        End Get
        Set(value As enter)
            ' Debug.Assert(Not value Is Nothing, "Попытка усановить пустое оприходование")
            oLinkedEnter = value
            RaisePropertyChanged("LinkedEnter")
        End Set
    End Property
    ''' <summary>
    ''' флаг возможности размещения на складе по этому расположению
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property HasEnter As Boolean
        Get
            If LinkedEnter Is Nothing Then Return False
            Return True
        End Get
    End Property

    Private Sub New()

    End Sub

    Public Sub New(WarehouseUUID As String)
        Me.WarehouseUUID = WarehouseUUID

    End Sub

    Public Sub New(Good As good, WarehouseUUID As String)
        Me.WarehouseUUID = WarehouseUUID
        Me.Good = Good
    End Sub

    ''' <summary>
    ''' вернет список ячеек для текущего склада или пусто, если склада нет
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetAllSlotUIID() As List(Of String)
        If Me.oWarehouse Is Nothing Then Return New List(Of String)
        Dim _res = From c In Me.oWarehouse.slots Select c.uuid
        Return _res.ToList
    End Function


    ' ''' <summary>
    ' ''' находит товар на складах 
    ' ''' </summary>
    ' ''' <returns></returns>
    ' ''' <remarks></remarks>
    'Friend Shared Function CreateListForGood(manager As clsMoyScladManager, good As clsMSGood, Optional ByRef foundStatus As Integer = 0, Optional ByRef ServerMessage As String = "") As List(Of clsGoodLocation)
    '    'запрос принципиальный
    '    Dim _new As New List(Of clsGoodLocation)
    '    Dim _result As IEnumerable(Of Object) = Nothing
    '    Dim _respond As String = ""
    '    ' Dim _req = manager.requestData(clsMoyScladManager.emMoySkladTObulkTypes.stockTO, _respond, good.UUID, , ServerMessage)
    '    Dim _req = manager.GetObjectCollection(clsMoyScladManager.emTOMoySkladTypes.stockTO, _result, "", good.UUID, , , ServerMessage)

    '    Select Case _req
    '        Case Net.HttpStatusCode.OK

    '        Case Else
    '            foundStatus = -1
    '            Return _new
    '    End Select

    '    Return _new

    'End Function


    ''' <summary>
    ''' загружает обьекты складов и ячеек
    ''' </summary>
    ''' <remarks></remarks>
    Friend Sub LoadObjects(manager As clsMoyScladManager)
        If Me.WarehouseUUID = "" Then
            Debug.Fail("Передан пустой UUID")
            Return
        End If

        Me.Ewarehouse = manager.GetWarehouseByUUID(Me.WarehouseUUID)


nx:
        If Me.SlotGood Is Nothing Then Return

        'загрузим об ячеек
        For Each t In Me.SlotGood
            t.Parent = Me
            Dim _uuid = t.SlotUUID
            t.EWarehouse = manager.GetWarehouseByUUID(Me.WarehouseUUID)
            t.ESlot = manager.GetSlotByUUID(Me.WarehouseUUID, t.SlotUUID)
        Next
    End Sub


    Public Property Good As good
        Get
            Return oGood
        End Get
        Set(value As good)
            oGood = value
            Me.RaisePropertyChanged("Good")
            If Not value Is Nothing Then
                AddHandler oGood.PropertyChanged, AddressOf GoodPropertyChanged_EventHandler
            End If
        End Set
    End Property


    ''' <summary>
    ''' общее кол-во по складу со всех ячеек
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property TotalQty As Decimal
        Get
            Dim _res = SlotGood.Select(Function(x) x.Qty).Sum
            Return _res
        End Get
    End Property

    Public ReadOnly Property BuyPrice As Decimal
        Get
            If Good Is Nothing Then Return 0
            Return Math.Round(Good.buyPrice / 100, 2)
        End Get
    End Property

    Friend ReadOnly Property BuyPriceCurrency(manager As clsMoyScladManager) As String
        Get
            If Good Is Nothing Then Return ""
            Return manager.GetCurrencyByUUID(Good.buyCurrencyUuid).name
        End Get
    End Property

    Private oWarehouse As warehouse
    Public Property Ewarehouse As warehouse
        Get
            Return oWarehouse
        End Get
        Set(value As warehouse)
            Me.WarehouseUUID = value.uuid
            Me.oWarehouse = value
            Me.RaisePropertyChanged("Ewarehouse")
        End Set
    End Property
    Private oSlotGood As New List(Of clsSlot)

    Public Property SlotGood As List(Of clsSlot)
        Get
            Return oSlotGood
        End Get
        Set(value As List(Of clsSlot))
            oSlotGood = value
            For Each t In oSlotGood
                t.Parent = Me
            Next
            RaisePropertyChanged("SlotGood")
        End Set
    End Property

    Public Overrides Function Equals(obj As Object) As Boolean
        If obj Is Nothing Then Return False
        If Not TypeOf obj Is clsGoodLocation Then Return False
        If Not Me.Good Is Nothing AndAlso (Not obj.good Is Nothing) Then
            If Not Me.Good.uuid = obj.Good.uuid Then Return False
        End If
        Return Me.WarehouseUUID.Equals(obj.WarehouseUUID)
    End Function

    Public Overrides Function GetHashCode() As Integer
        If Me.Good Is Nothing Then
            Return Me.WarehouseUUID.GetHashCode
        End If
        If Me.Ewarehouse Is Nothing Then
            Return Me.Good.uuid.GetHashCode
        End If
        Return Me.Good.uuid.GetHashCode Xor Me.WarehouseUUID.GetHashCode
    End Function

    Public Function CompareTo(obj As Object) As Integer Implements System.IComparable.CompareTo
        If obj Is Nothing Then Return 0
        If Not TypeOf obj Is clsGoodLocation Then Return 0
        If obj.Ewarehouse Is Nothing Then Return 0
        If Me.Ewarehouse Is Nothing Then Return 0
        If Not Me.Good Is Nothing Then
            If Not Me.Good.uuid.Equals(obj.Good.uuid) Then Return 0
        End If

        Return Me.WarehouseUUID.CompareTo(obj.WarehouseUUID)
    End Function

    Public Overrides Function ToString() As String

        Dim _out As String = "no info"
        If Not oWarehouse Is Nothing Then
            _out += "->"
            _out = oWarehouse.name
        Else
            _out = "no ware"
        End If

        'Dim _uomName As String = ""
        'If Not Good Is Nothing Then
        '    _uomName = Good.uomUuid
        'End If

        'If Not Good Is Nothing Then
        '    _out += "-->"
        '    _out += Good.name
        '    '-----------
        '    'If Not (Good.code Is Nothing Or Good.code = "") Then
        '    '    _out += "-->"
        '    '    _out += Good.code
        '    'End If
        '    '------------
        '    If Not (Good.productCode Is Nothing Or Good.productCode = "") Then
        '        _out += "-->"
        '        _out += Good.productCode
        '    End If
        'End If

        If Not SlotGood Is Nothing Then
            Dim _res = From c In SlotGood Where c.Qty > 0 Select c
            If _res.Count > 0 Then
                _out += "/"
                For Each t In _res
                    If Not t.ESlot Is Nothing Then
                        _out += t.ESlot.name
                        _out += "("
                        _out += t.Qty.ToString
                        _out += ")"
                        _out += "/"
                    End If
                Next
                _out = _out.TrimEnd("/")
            End If
        Else
            _out += "-->no slot"
        End If

        Return _out

    End Function

    ''' <summary>
    ''' вернет мой обьект описания кол-ва товара
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetGoodQty() As List(Of iMoySkladDataProvider.strGoodMapQty)
        Dim _out As New List(Of iMoySkladDataProvider.strGoodMapQty)
        For Each _slot In Me.SlotGood
            Dim _loc As New iMoySkladDataProvider.strGoodMapQty
            With _loc
                'порядок ВАЖЕН в случае наличия и кода, и артикула. Код главнее.
                'сначала артикул
                If Not String.IsNullOrWhiteSpace(Me.Good.productCode) Then
                    .ProductCode = Me.Good.productCode
                End If
                'потом код
                If Not String.IsNullOrWhiteSpace(Me.Good.code) Then
                    .code = Me.Good.code
                End If

                .Name = Me.Good.name
                .UUID = Me.Good.uuid

                .Qty = _slot.Qty
                .UomName = _slot.UomName

                If Not _slot.ESlot Is Nothing Then
                    .SlotName = _slot.ESlot.name
                    .SlotUUID = _slot.ESlot.uuid
                End If

                .WareName = _slot.EWarehouse.name
                .WareUUID = _slot.EWarehouse.uuid
            End With
            _out.Add(_loc)
        Next
        Return _out
    End Function

    Public Event PropertyChanged(sender As Object, e As System.ComponentModel.PropertyChangedEventArgs) Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged

    Protected Sub RaisePropertyChanged(ByVal propertyName As String)
        Dim propertyChanged As System.ComponentModel.PropertyChangedEventHandler = Me.PropertyChangedEvent
        If (Not (propertyChanged) Is Nothing) Then
            propertyChanged(Me, New System.ComponentModel.PropertyChangedEventArgs(propertyName))
        End If
    End Sub

    Sub SlotPropertyChanged_EventHandler(sender As Object, e As System.ComponentModel.PropertyChangedEventArgs)
        Select Case e.PropertyName
            Case "Qty"
                RaisePropertyChanged("TotalQty")
        End Select
    End Sub

    Private Sub GoodPropertyChanged_EventHandler(sender As Object, e As System.ComponentModel.PropertyChangedEventArgs)
        Select Case e.PropertyName
            Case "buyPrice"
                RaisePropertyChanged("BuyPrice")
            Case "buyCurrencyUuid"
                RaisePropertyChanged("BuyPriceCurrency")
        End Select
    End Sub

    Public Function Clone() As Object Implements ICloneable.Clone
        Dim _new As New clsGoodLocation
        With _new
            .Good = oGood
            .Ewarehouse = Ewarehouse
            .LinkedEnter = LinkedEnter
            .LinkedLoss = LinkedLoss
            .SlotGood = SlotGood.Select(Function(x) CType(x.Clone, clsSlot)).ToList
            For Each t In .SlotGood
                t.Parent = _new
            Next
            .WarehouseName = WarehouseName
            .WarehouseUUID = WarehouseUUID

        End With
        Return _new
    End Function
End Class
