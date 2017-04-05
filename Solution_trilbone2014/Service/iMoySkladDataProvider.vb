Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports System.Linq
Imports Service

Public Interface iMoySkladDataProvider

    ''' <summary>
    ''' занята ли структура обработкой запроса
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Busy As Boolean

    ''' <summary>
    ''' найдет товары в ячейке/ status: -1 -2 -3 = ошибка // >=0 запрос свершен, кол-во позиций 
    ''' </summary>
    ''' <param name="WarehouseName"></param>
    ''' <param name="SlotName"></param>
    ''' <param name="_status"></param>
    ''' <param name="_message"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function FindGoodsByCell(WarehouseName As String, SlotName As String, ByRef _status As Integer, Optional ByRef _message As String = "") As List(Of strGoodMapQty)

    ''' <summary>
    ''' найдет товар по UUID
    ''' </summary>
    ''' <param name="UUID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function FindGoodsByUUID(UUID As String) As clsApplicationTypes.clsSampleNumber.strGoodInfo

    Function GetPaymentOutInfo(PaymentOutName As String, Optional PaymentOutNameUUID As String = "") As List(Of iMoySkladDataProvider.clsPaymentInfo)

    Function GetPaymentInInfo(PaymentInName As String, Optional PaymentInNameUUID As String = "") As List(Of iMoySkladDataProvider.clsPaymentInfo)

    Function GetProject() As List(Of iMoySkladDataProvider.clsEntity)

    Function GetPaymentDestinations() As List(Of iMoySkladDataProvider.clsEntity)

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Class clsEntity
        Implements IComparer(Of clsEntity)
        Implements IComparable(Of clsEntity)

        Private oEmpty As Boolean = False

        ''' <summary>
        ''' делегат получения значения для атрибутов
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property GetCustomValueDelegate As Func(Of String, iMoySkladDataProvider.clsEntity)

        ''' <summary>
        ''' получить значение (для атрибутов)
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function TryGetCustomValue() As iMoySkladDataProvider.clsEntity
            If GetCustomValueDelegate Is Nothing Then Return Nothing
            If String.IsNullOrEmpty(Me.Value) Then Return Nothing
            Dim _value = GetCustomValueDelegate.Invoke(Me.Value)
            If Not _value Is Nothing Then
                Me.Value = _value.Value
                Me.UUID = _value.UUID
                Me.MetaDataUUID = _value.MetaDataUUID
                Me.MetaDataValue = _value.MetaDataValue
            End If
            Return _value
        End Function

        Public WriteOnly Property SetValued As Boolean
            Set(value As Boolean)
                If value Then
                    oEmpty = False
                Else
                    oEmpty = True
                End If
            End Set
        End Property

        Public Sub New()
            Me.oEmpty = True
        End Sub
        ''' <summary>
        ''' показывает, что справочник с именем MetaDataName не существует
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property IsMetadataEmpty As Boolean
            Get
                If String.IsNullOrEmpty(MetaDataUUID) Then Return True
                Return False
            End Get
        End Property

        ''' <summary>
        ''' пустой обьект для пустого первого элемента списка
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared ReadOnly Property Empty() As clsEntity
            Get
                Return New clsEntity With {.oEmpty = True, .Value = "", .UUID = "", .MetaDataUUID = "", .MetaDataValue = ""}
            End Get
        End Property



        Public Property Value As String
        Public Property UUID As String
        Public Property MetaDataUUID As String
        Public Property MetaDataValue As String

        ''' <summary>
        ''' показывает, что обьект не соответствует сущности МС
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property IsEmpty As Boolean
            Get
                Return oEmpty
            End Get
        End Property

        Public Overrides Function ToString() As String
            If oEmpty Then
                Return "Пусто"
            Else
                Return Value
            End If
        End Function

        Public Function Compare(x As clsEntity, y As clsEntity) As Integer Implements IComparer(Of clsEntity).Compare
            Return x.Value.CompareTo(y.Value)
        End Function

        Public Function CompareTo(other As clsEntity) As Integer Implements IComparable(Of clsEntity).CompareTo
            Return Me.Value.CompareTo(other.Value)
        End Function
    End Class
    ''' <summary>
    ''' 'абстрагирует платеж МС
    ''' </summary>
    ''' <remarks></remarks>
    Class clsPaymentInfo
        Property IsIncomingPayment As Boolean

        Property sourceStoreUuid As String

        Property retailStoreUuid As String

        Property retailStoreName As String

        Property sourceStoreName As String

        Property attributes As List(Of clsEntity)



        Public Overloads Overrides Function ToString() As String
            Return String.Format("{0} {1} {3}{2}", Me.name, If(IsIncomingPayment, Me.sourceAgentName, Me.targetAgentName), Me.TotalAmountInCurrency, clsApplicationTypes.GetCurrencySymbol(Me.currency))
        End Function
        ''' <summary>
        ''' основание платежа
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property paymentPurpose As String

        ''' <summary>
        ''' проведено
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property Applicable As Boolean


        ''' <summary>
        ''' статус
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property stateUuid As String

        ''' <summary>
        ''' покупатель
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property targetAgentUuid As String

        ''' <summary>
        ''' продавец MyCompanyUUID
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property sourceAgentUuid As String

        ''' <summary>
        ''' продавец 
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property sourceAgentName As String

        ''' <summary>
        ''' покупатель
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property targetAgentName As String


        ''' <summary>
        ''' проект
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property projectUuid As String

        ''' <summary>
        ''' проект
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property projectName As String

        Property currencyUuid As String

        ''' <summary>
        ''' текст валюты
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property currency As String


        Property rate As Double

        ''' <summary>
        ''' название платежа
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property name As String

        ''' <summary>
        ''' дата создания
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property created As Date

        Property UUID As String

        ''' <summary>
        ''' общая сумма в валюте заказа
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property TotalAmountInCurrency As Decimal

        ''' <summary>
        ''' UUID связанной отгрузки
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property RefDemandUUID As String


        ''' <summary>
        ''' UUID связанной заказа
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property RefOrderUUID As String




        ''' <summary>
        ''' склад
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property TargetStoreUUID As String


        Property TargetStoreName As String

        Property description As String

    End Class

    ''' <summary>
    ''' описывает конкретный fee
    ''' </summary>
    Class clsFee
        ''' <summary>
        ''' выдает истина, если значение=0 или валюта пуста
        ''' </summary>
        ''' <returns></returns>
        ReadOnly Property NeedGetFromMC As Boolean
            Get
                If Me.Value = 0 Then
                    Return True
                End If
                If String.IsNullOrEmpty(Me.Currency) Then
                    Return True
                End If
                Return False
            End Get
        End Property

        ''' <summary>
        ''' валюта 
        ''' </summary>
        ''' <returns></returns>
        Property Currency As String
        ''' <summary>
        ''' значение
        ''' </summary>
        ''' <returns></returns>
        Property Value As Decimal
        ''' <summary>
        ''' код МС
        ''' </summary>
        ''' <returns></returns>
        Property UUID As String

        ''' <summary>
        ''' название-необязательно(берется из карточки товара МС)
        ''' </summary>
        ''' <returns></returns>
        Property Name As String
        ''' <summary>
        ''' артикул-необязательно(берется из карточки товара МС)
        ''' </summary>
        ''' <returns></returns>
        Property Articul As String
    End Class

    Class clsOperationInfo

        ''' <summary>
        ''' напрваление операции - из конторы
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property IsOutgoingOperation As Boolean

        Property sourceStoreUuid As String

        Property sourceStoreName As String

        Property retailStoreUuid As String

        Property retailStoreName As String

        Property attributes As List(Of clsEntity)

        Public Overrides Function ToString() As String
            If Me.HasError Then Return ""

            Return String.Format("{0} - {1} - {3}{2}", Me.name, If(IsOutgoingOperation, Me.targetAgentName, Me.sourceAgentName), Me.TotalAmountInCurrency, clsApplicationTypes.GetCurrencySymbol(Me.currency))
        End Function
        ''' <summary>
        ''' проведено
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property Applicable As Boolean

        ''' <summary>
        ''' сумма в резерве
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property reservedSum As Double
        ''' <summary>
        ''' статус
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property stateUuid As String

        ''' <summary>
        ''' покупатель
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property targetAgentUuid As String

        ''' <summary>
        ''' продавец MyCompanyUUID
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property sourceAgentUuid As String

        ''' <summary>
        ''' продавец 
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property sourceAgentName As String

        ''' <summary>
        ''' покупатель
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property targetAgentName As String


        ''' <summary>
        ''' проект
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property projectUuid As String

        ''' <summary>
        ''' проект
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property projectName As String

        Property currencyUuid As String

        ''' <summary>
        ''' текст валюты
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property currency As String


        Property rate As Double

        ''' <summary>
        ''' имя
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property name As String

        ''' <summary>
        ''' дата создания
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property created As Date

        Property UUID As String

        ''' <summary>
        ''' общая сумма в валюте заказа
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property TotalAmountInCurrency As Decimal

        ''' <summary>
        ''' UUID связанной отгрузки
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property RefDemandUUID As String


        ''' <summary>
        ''' UUID связанной заказа
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property RefOrderUUID As String

        ''' <summary>
        ''' UUID связанного платежа
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property RefFinanceUUID As String

        ''' <summary>
        ''' позиции
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property Position As List(Of clsPosition)

        ''' <summary>
        ''' склад
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property TargetStoreUUID As String

        Property TargetStoreName As String

        Property description As String

        ''' <summary>
        ''' показывает, что обьект недействителен и была ошибка
        ''' </summary>
        ''' <returns></returns>
        Property HasError As Boolean

        Property ErrorMessage As String



    End Class

    Class clsPosition
        Implements ComponentModel.INotifyPropertyChanged

        Dim oDiscount As Decimal
        Dim oCode As String
        Dim oArticul As String
        Dim ogoodUuid As String

        ''' <summary>
        ''' скидка
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property Discount As Decimal
            Get
                Return oDiscount
            End Get
            Set(value As Decimal)
                oDiscount = value
                RaisePropertyChanged("Discount")
            End Set
        End Property

        ''' <summary>
        ''' кол-во
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property quantity As Decimal

        Property currencyName As String

        Property goodUuid As String
            Get
                Return ogoodUuid
            End Get
            Set(value As String)
                ogoodUuid = value
                RaisePropertyChanged("goodUuid")
            End Set
        End Property

        Property uomName As String

        ''' <summary>
        ''' кол-во в резерве
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property ReserveQty As Decimal

        ''' <summary>
        ''' номер образца в системе
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property SampleNumber As clsApplicationTypes.clsSampleNumber

        ''' <summary>
        ''' цена со скидкой
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property PriceInCurrency As Decimal

        ''' <summary>
        ''' цена без скидки
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property BasePriceInCurrency As Decimal

        ''' <summary>
        ''' венет актуальную цену с учетом скидки
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property ActualPriceInCurrency As Decimal
            Get
                If Discount = 0 Then
                    If BasePriceInCurrency > PriceInCurrency Then Return BasePriceInCurrency
                    Return PriceInCurrency
                Else
                    If BasePriceInCurrency > PriceInCurrency Then Return clsApplicationTypes.RoundPrice(BasePriceInCurrency * (100 - Discount) / 100)
                    Return PriceInCurrency
                End If
            End Get
        End Property

        Public Function IsArticul() As Boolean
            If String.IsNullOrEmpty(Me.Articul) Then Return False
            If Not String.IsNullOrEmpty(Me.Code) Then Return False
            Return True
        End Function


        Property Code As String
            Get
                Return oCode
            End Get
            Set(value As String)
                oCode = value
                If Not String.IsNullOrEmpty(oCode) Then
                    Me.SampleNumber = clsApplicationTypes.clsSampleNumber.CreateFromString(oCode)
                End If
            End Set
        End Property

        Property Articul As String
            Get
                Return oArticul
            End Get
            Set(value As String)
                oArticul = value
                If SampleNumber Is Nothing AndAlso (Not String.IsNullOrEmpty(oArticul)) Then
                    Me.SampleNumber = clsApplicationTypes.clsSampleNumber.CreateFromString(oArticul)
                End If
            End Set
        End Property

        Property GoodName As String


        ReadOnly Property ActualCode As String
            Get
                If Not Me.SampleNumber Is Nothing Then
                    Return Me.SampleNumber.ShotCode
                End If

                If String.IsNullOrEmpty(Code) Then Return Articul
                Return Code
            End Get
        End Property

        ''' <summary>
        ''' внешний ID
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ExternalID As String

        Public Overrides Function ToString() As String
            Return String.Format("{0}-{1}-{2}{3}", Me.ActualCode, Me.GoodName, Me.ActualPriceInCurrency, clsApplicationTypes.GetCurrencySymbol(Me.currencyName))
        End Function


        Sub RaisePropertyChanged(ByVal propertyName As String)
            Dim propertyChanged As System.ComponentModel.PropertyChangedEventHandler = Me.PropertyChangedEvent
            If (Not (propertyChanged) Is Nothing) Then
                propertyChanged(Me, New System.ComponentModel.PropertyChangedEventArgs(propertyName))
            End If
        End Sub

        Public Event PropertyChanged(sender As Object, e As PropertyChangedEventArgs) Implements INotifyPropertyChanged.PropertyChanged
    End Class

    ''' <summary>
    ''' описывает расположение образца на складе
    ''' </summary>
    ''' <remarks></remarks>
    Class clsStokQuantity
        Property Code As String
        Property ProductCode As String
        Property Name As String
        ''' <summary>
        ''' доступно (резерв не включается!!)
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property Quantity As Double
        ''' <summary>
        ''' Кол-во в резерве
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property Reserve As Double
        ''' <summary>
        ''' полное доступное кол-во, включая резерв
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property Stok As Double
        Property UomName As String
        Property SaleAmount As Decimal
        Property SalePrice As Decimal
        Property Currency As String
        Property SumTotal As Decimal
        Property WareName As String
        Property Category As String

        ReadOnly Property ActualNumber As String
            Get
                If Not String.IsNullOrEmpty(Code) Then
                    Return Code
                End If
                Return ProductCode
            End Get
        End Property
        Private oMapQty As strGoodMapQty()
        ''' <summary>
        ''' описывает размещение по ячейкам. запрашивает МС 1 раз
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property GoodMapQty() As strGoodMapQty()
            Get
                'If oMapQty Is Nothing Then
                '    If obj Is Nothing Then Return New strGoodMapQty() {}
                '    If String.IsNullOrEmpty(Me.WareName) Then Return New strGoodMapQty() {}
                '    If String.IsNullOrEmpty(Me.goodUUID) Then
                '        Return obj.FindCellByGood(Me.ActualNumber, Me.WareName, True).ToArray
                '    Else
                '        Return obj.FindCellByGood("", Me.WareName, True, Me.goodUUID).ToArray
                '    End If
                'End If
                Return oMapQty
            End Get
            Set(value As strGoodMapQty())
                oMapQty = value
            End Set
        End Property

        Public Sub LoadCellInfo(obj As Service.iMoySkladDataProvider)
            If obj Is Nothing Then oMapQty = New strGoodMapQty() {}
            If String.IsNullOrEmpty(Me.WareName) Then oMapQty = New strGoodMapQty() {}
            If String.IsNullOrEmpty(Me.goodUUID) Then
                oMapQty = obj.FindCellByGood(Me.ActualNumber, Me.WareName, True).ToArray
            Else
                oMapQty = obj.FindCellByGood("", Me.WareName, True, Me.goodUUID).ToArray
            End If
        End Sub


        Property goodUUID As String

        Property IsArticul As Boolean

       


        Public Overrides Function ToString() As String
            'Внутренний нарва -> 1шт (резерв 1шт)
            Dim _reserv = If(Me.Reserve > 0, String.Format("(резерв {0}{1})", Me.Reserve, Me.UomName), "")
            Dim _out = String.Format("{0} -> {1}{3} {2}", Me.WareName, Me.Stok, _reserv, Me.UomName)
            Return _out
        End Function
    End Class


    Class clsClientInfo
        Implements IComparable
        Implements IComparer
        Implements INotifyPropertyChanged

        Private oFullName As String
        Dim oaddress As clsAddress

        ''' <summary>
        ''' полное имя для отправки email
        ''' </summary>
        Property FullName As String
            Get
                Return oFullName
            End Get
            Set(value As String)
                oFullName = value
                RaisePropertyChanged("FullName")
            End Set
        End Property



        Private oEmail As String

        Public Property Email As String
            Get
                Return oEmail
            End Get
            Set(value As String)
                oEmail = value
                RaisePropertyChanged("Email")
            End Set
        End Property

        Private oMSCode As String

        ''' <summary>
        ''' код из МС
        ''' </summary>
        Public Property MSCode As String
            Get
                Return oMSCode
            End Get
            Set(value As String)
                oMSCode = value
            End Set
        End Property

        Private oUUID As String
        ''' <summary>
        ''' UUID из МС
        ''' </summary>
        Public Property UUID As String
            Get
                Return oUUID
            End Get
            Set(value As String)
                oUUID = value
                RaisePropertyChanged("UUID")
            End Set
        End Property

        Private oMainSourceEmail As String
        ''' <summary>
        ''' основной адрес, откуда клиент получает письма
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property MainSourceEmail As String
            Get
                Return oMainSourceEmail
            End Get
            Set(value As String)
                oMainSourceEmail = value
                RaisePropertyChanged("MainSourceEmail")
            End Set
        End Property

        ''' <summary>
        ''' адрес клиента
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property address As clsAddress
            Get
                Return oaddress
            End Get
            Set(value As clsAddress)
                oaddress = value
                AddHandler oaddress.PropertyChanged, AddressOf AddressPropertyChangedEventHandler
                RaisePropertyChanged("address")
            End Set
        End Property


        Public Function CompareTo(obj As Object) As Integer Implements IComparable.CompareTo
            Return Me.Compare(Me, obj)
        End Function

        Public Function Compare(x As Object, y As Object) As Integer Implements IComparer.Compare
            If x Is Nothing Then Return 0
            If Not TypeOf x Is clsClientInfo Then Return 0
            If y Is Nothing Then Return 0
            If Not TypeOf y Is clsClientInfo Then Return 0
            Return String.Compare(x.FullName, y.FullName)
        End Function

        Public Overrides Function GetHashCode() As Integer
            Return FullName.ToLower.GetHashCode Xor Email.ToLower.GetHashCode
        End Function

        Public Overrides Function Equals(obj As Object) As Boolean
            If obj Is Nothing Then Return False
            If Not TypeOf obj Is clsClientInfo Then
                If TypeOf obj Is String Then
                    'тут сравниваем полное имя с переданной строкой
                    Dim _str = CType(obj, String)
                    Dim _nameArr = Me.FullName.Split(" ".ToCharArray, System.StringSplitOptions.RemoveEmptyEntries)
                    Dim _out = (From c In _nameArr Where c.ToLower.StartsWith(_str.ToLower) Select c).ToList
                    If _out.Count > 0 Then Return True
                    Return False
                Else
                    Return False
                End If
            End If
            Dim _cl = CType(obj, clsClientInfo)
            If Not Me.FullName.ToLower.Equals(_cl.FullName.ToLower) Then Return False
            If Not Me.Email.ToLower.Equals(_cl.Email.ToLower) Then Return False
            Return True
        End Function

        Public Overrides Function ToString() As String
            Dim _out As String = FullName
            _out += " -> "
            If Email Is Nothing OrElse Email = "" Then
                If Me.oEmpty Then
                    _out = "пусто"
                Else
                    _out += "<отсутствует email>"
                End If

            Else
                _out += Email
            End If
            Return _out
        End Function

        Public Event PropertyChanged(sender As Object, e As PropertyChangedEventArgs) Implements INotifyPropertyChanged.PropertyChanged

        Sub RaisePropertyChanged(ByVal propertyName As String)
            Dim propertyChanged As System.ComponentModel.PropertyChangedEventHandler = Me.PropertyChangedEvent
            If (Not (propertyChanged) Is Nothing) Then
                propertyChanged(Me, New System.ComponentModel.PropertyChangedEventArgs(propertyName))
            End If
        End Sub

        Private Sub AddressPropertyChangedEventHandler(sender As Object, e As PropertyChangedEventArgs)
            RaisePropertyChanged("address")
        End Sub

        Private oEmpty As Boolean

        Public ReadOnly Property IsEmpty As Boolean
            Get
                Return oEmpty
            End Get
        End Property

        Friend Shared Function Empty() As clsClientInfo

            Return New clsClientInfo With {.oEmpty = True, .FullName = "", .UUID = ""}

        End Function
    End Class


    ''' <remarks>данные после отправки посылки</remarks>
    Class clsResultParcelInfo
        Implements INotifyPropertyChanged

        ''' <summary>
        ''' описывает товар, использованный для упаковки
        ''' </summary>
        ''' <remarks></remarks>
        Structure PackagingGoodInfo
            Implements INotifyPropertyChanged

            Private oGoodUUID As String
            Property GoodUUID As String
                Get
                    Return oGoodUUID
                End Get
                Set(value As String)
                    oGoodUUID = value
                    RaisePropertyChanged("GoodUUID")
                End Set
            End Property


            Private oQty As Decimal
            Property Qty As Decimal
                Get
                    Return oQty
                End Get
                Set(value As Decimal)
                    oQty = value
                    RaisePropertyChanged("Qty")
                End Set
            End Property


            Private oAmount As Decimal
            Property Amount As Decimal
                Get
                    Return oAmount
                End Get
                Set(value As Decimal)
                    oAmount = value
                    RaisePropertyChanged("Amount")
                End Set
            End Property


            Private oCurrencyUUID As String
            Property CurrencyUUID As String
                Get
                    Return oCurrencyUUID
                End Get
                Set(value As String)
                    oCurrencyUUID = value
                    RaisePropertyChanged("CurrencyUUID")
                End Set
            End Property

            Sub RaisePropertyChanged(ByVal propertyName As String)
                Dim propertyChanged As System.ComponentModel.PropertyChangedEventHandler = Me.PropertyChangedEvent
                If (Not (propertyChanged) Is Nothing) Then
                    propertyChanged(Me, New System.ComponentModel.PropertyChangedEventArgs(propertyName))
                End If
            End Sub
            Public Event PropertyChanged(sender As Object, e As PropertyChangedEventArgs) Implements INotifyPropertyChanged.PropertyChanged
        End Structure



        Private oPackagingGoodsUUIDsAndQtys As PackagingGoodInfo()
        Dim oParcelWeight As Decimal
        Dim oParcelSizeA As Decimal
        Dim oParcelSizeB As Decimal
        Dim oParcelSizeC As Decimal
        Dim oParcelGroup As String
        Dim oParcelType As String
        Dim oComment As String

        ''' <summary>
        ''' список UUID товаров(key) и их количества(value), истраченных при упаковке/ цены должны быть в МС
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PackagingGoodsUUIDsAndQtys As PackagingGoodInfo()
            Get
                Return oPackagingGoodsUUIDsAndQtys
            End Get
            Set(value As PackagingGoodInfo())
                oPackagingGoodsUUIDsAndQtys = value
                RaisePropertyChanged("PackagingGoodsUUIDsAndQtys")
            End Set
        End Property


        Private oShippingAmount As Decimal
        ''' <summary>
        ''' стоимость отправки (чистая)
        ''' </summary>
        Public Property ShippingAmount As Decimal
            Get
                Return oShippingAmount
            End Get
            Set(value As Decimal)
                oShippingAmount = value
                RaisePropertyChanged("ShippingAmount")
            End Set
        End Property



        Private oShippingAndHandlingCurrencyUUID As String
        ''' <summary>
        ''' валюта, в которой заданы значения шиппинга и handling
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ShippingAndHandlingCurrencyUUID As String
            Get
                Return oShippingAndHandlingCurrencyUUID
            End Get
            Set(value As String)
                oShippingAndHandlingCurrencyUUID = value
                RaisePropertyChanged("ShippingAndHandlingCurrencyUUID")
            End Set
        End Property



        Private oShippingGoodUUID As String
        ''' <summary>
        ''' UUID товара потраченного шиппинга
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ShippingGoodUUID As String
            Get
                Return oShippingGoodUUID
            End Get
            Set(value As String)
                oShippingGoodUUID = value
                RaisePropertyChanged("ShippingGoodUUID")
            End Set
        End Property


        Private oHandlingAmount As Decimal
        ''' <summary>
        ''' стоимость обработки и отправки
        ''' </summary>
        Public Property HandlingAmount As Decimal
            Get
                Return oHandlingAmount
            End Get
            Set(value As Decimal)
                oHandlingAmount = value
                RaisePropertyChanged("HandlingAmount")
            End Set
        End Property



        Private oHandlingGoodUUID As String
        ''' <summary>
        ''' UUID товара обработки заказа
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property HandlingGoodUUID As String
            Get
                Return oHandlingGoodUUID
            End Get
            Set(value As String)
                oHandlingGoodUUID = value
                RaisePropertyChanged("HandlingGoodUUID As String")
            End Set
        End Property


        Private oTrackNumber As String
        ''' <summary>
        ''' трек номер
        ''' </summary>
        Public Property TrackNumber As String
            Get
                Return oTrackNumber
            End Get
            Set(value As String)
                oTrackNumber = value
                RaisePropertyChanged("TrackNumber")
            End Set
        End Property


        Private oSenderUUID As String
        ''' <summary>
        ''' UUID сотрудника, отправившего посылку
        ''' </summary>
        Public Property SenderUUID As String
            Get
                Return oSenderUUID
            End Get
            Set(value As String)
                oSenderUUID = value
                RaisePropertyChanged("SenderUUID")
            End Set
        End Property


        Private oShippingCompanyUUID As String

        ''' <summary>
        ''' UUID компании, через которую отправлена посылка
        ''' </summary>
        Public Property ShippingCompanyUUID As String
            Get
                Return oShippingCompanyUUID
            End Get
            Set(value As String)
                oShippingCompanyUUID = value
                RaisePropertyChanged("oShippingCompanyUUID")
            End Set
        End Property

        ''' <summary>
        ''' вес посылки в кг
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ParcelWeight As Decimal
            Get
                Return oParcelWeight
            End Get
            Set(value As Decimal)
                oParcelWeight = value
                RaisePropertyChanged("ParcelWeight")
            End Set
        End Property

        Public Property ParcelSizeA As Decimal
            Get
                Return oParcelSizeA
            End Get
            Set(value As Decimal)
                oParcelSizeA = value
                RaisePropertyChanged("ParcelSizeA")
            End Set
        End Property

        Public Property ParcelSizeB As Decimal
            Get
                Return oParcelSizeB
            End Get
            Set(value As Decimal)
                oParcelSizeB = value
                RaisePropertyChanged("ParcelSizeB")
            End Set
        End Property

        Public Property ParcelSizeC As Decimal
            Get
                Return oParcelSizeC
            End Get
            Set(value As Decimal)
                oParcelSizeC = value
                RaisePropertyChanged("ParcelSizeC")
            End Set
        End Property
        ''' <summary>
        ''' письмо или посылка
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ParcelGroup As String
            Get
                Return oParcelGroup
            End Get
            Set(value As String)
                oParcelGroup = value
                RaisePropertyChanged("ParcelGroup")
            End Set
        End Property

        ''' <summary>
        ''' тип отправления
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ParcelType As String
            Get
                Return oParcelType
            End Get
            Set(value As String)
                oParcelType = value
                RaisePropertyChanged("ParcelType")
            End Set
        End Property

        ''' <summary>
        ''' комментарий к посылке Omniva
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Comment As String
            Get
                Return oComment
            End Get
            Set(value As String)
                oComment = value
                RaisePropertyChanged("Comment")
            End Set
        End Property

        Sub RaisePropertyChanged(ByVal propertyName As String)
            Dim propertyChanged As System.ComponentModel.PropertyChangedEventHandler = Me.PropertyChangedEvent
            If (Not (propertyChanged) Is Nothing) Then
                propertyChanged(Me, New System.ComponentModel.PropertyChangedEventArgs(propertyName))
            End If
        End Sub

        Public Event PropertyChanged(sender As Object, e As PropertyChangedEventArgs) Implements INotifyPropertyChanged.PropertyChanged
    End Class

    ''' <summary>
    ''' находит ячейку(и), кол-во и прочее на складе товара
    ''' </summary>
    ''' <param name="ShotCode"></param>
    ''' <param name="WareHouseName"></param>
    ''' <param name="IncludeReserved"></param>
    ''' <returns></returns>
    Function FindCellByGood(ShotCode As String, WareHouseName As String, Optional IncludeReserved As Boolean = False, Optional GoodUUID As String = "") As List(Of strGoodMapQty)

    ''' <summary>
    ''' группа 
    ''' </summary>
    ''' <remarks></remarks>
    Enum emParcelGroup
        <Display(Name:="письма")>
        письма
        <Display(Name:="посылки")>
        посылки
    End Enum

    ''' <summary>
    ''' тип
    ''' </summary>
    ''' <remarks></remarks>
    Enum emParcelType
        <Display(Name:="Maksikiri taht")>
        Maksikiri_taht
        <Display(Name:="Standardpakk")>
        Standardpakk
    End Enum

    Class clsDeclarationItem
        Implements INotifyPropertyChanged

        Public Property descriptionofContents As String
        Public Property quantity As String
        Public Property netweight As String
        Public Property value As String
        Public Property countryoforigin As String

        Sub RaisePropertyChanged(ByVal propertyName As String)
            Dim propertyChanged As System.ComponentModel.PropertyChangedEventHandler = Me.PropertyChangedEvent
            If (Not (propertyChanged) Is Nothing) Then
                propertyChanged(Me, New System.ComponentModel.PropertyChangedEventArgs(propertyName))
            End If
        End Sub
        Public Event PropertyChanged(sender As Object, e As PropertyChangedEventArgs) Implements INotifyPropertyChanged.PropertyChanged
    End Class

    Class clsDeclaration_CP71_CN23
        Implements INotifyPropertyChanged

        Private oItems As clsDeclarationItem()

        Public Overrides Function ToString() As String
            Dim _out As String = ""
            If oItems Is Nothing OrElse oItems.Count = 0 Then Return _out
            For Each t In oItems
                _out += String.Format("{0} {1} {2}{3}", t.descriptionofContents, t.quantity, t.value, ChrW(13))
            Next
            Return _out
        End Function
        Public Sub AddItem(DescriptionofContents As String, quantity As String, value As String, Optional netweight As String = "", Optional countryoforigin As String = "Russia")

            'Public Property descriptionofContents As String
            'Public Property quantity As String
            'Public Property netweight As String
            'Public Property value As String
            'Public Property countryoforigin As String
            Dim _new As New clsDeclarationItem With {.descriptionofContents = DescriptionofContents, .quantity = quantity, .value = value, .netweight = netweight, .countryoforigin = countryoforigin}
            If oItems Is Nothing Then
                oItems = New clsDeclarationItem() {}
            End If
            Dim _list = oItems.ToList
            _list.Add(_new)
            oItems = _list.ToArray
        End Sub

        Public Property Items As clsDeclarationItem()
            Get
                Return oItems
            End Get
            Set(value As clsDeclarationItem())
                oItems = value
                RaisePropertyChanged("Items")
            End Set
        End Property

        Private odeclarationcurrency As String
        ''' <summary>
        ''' валюта, в которой указана стоимость товара (для заполняющего)
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property declarationcurrency As String
            Get
                Return odeclarationcurrency
            End Get
            Set(value As String)
                odeclarationcurrency = value
                RaisePropertyChanged("declarationcurrency")
            End Set
        End Property

        Private ocontent As emDeclaredContent
        Public Property content As emDeclaredContent
            Get
                Return ocontent
            End Get
            Set(value As emDeclaredContent)
                ocontent = value
                RaisePropertyChanged("content")
            End Set
        End Property


        Private oComments As String
        'в случае, если PACKET_CN23_OTHER
        Public Property Comments As String
            Get
                Return oComments
            End Get
            Set(value As String)
                oComments = value
                RaisePropertyChanged("Comments")
            End Set
        End Property


        Private oInstructionfornondelivery As emInstructionfornondelivery
        Public Property Instructionfornondelivery As emInstructionfornondelivery
            Get
                Return oInstructionfornondelivery
            End Get
            Set(value As emInstructionfornondelivery)
                oInstructionfornondelivery = value
                RaisePropertyChanged("Instructionfornondelivery")
            End Set
        End Property


        Private oReturnSpeed As emReturnSpeed
        Public Property ReturnSpeed As emReturnSpeed
            Get
                Return oReturnSpeed
            End Get
            Set(value As emReturnSpeed)
                oReturnSpeed = value
                RaisePropertyChanged("ReturnSpeed")
            End Set
        End Property


        Private oReturnAddress As clsAddress
        Public Property ReturnAddress As clsAddress
            Get
                Return oReturnAddress
            End Get
            Set(value As clsAddress)
                oReturnAddress = value
                RaisePropertyChanged("ReturnAddress")
            End Set
        End Property

        Sub RaisePropertyChanged(ByVal propertyName As String)
            Dim propertyChanged As System.ComponentModel.PropertyChangedEventHandler = Me.PropertyChangedEvent
            If (Not (propertyChanged) Is Nothing) Then
                propertyChanged(Me, New System.ComponentModel.PropertyChangedEventArgs(propertyName))
            End If
        End Sub
        Public Event PropertyChanged(sender As Object, e As PropertyChangedEventArgs) Implements INotifyPropertyChanged.PropertyChanged
    End Class

    Enum emReturnSpeed
        DELICERY_FAILURE_SPEED_BY_AIR
        DELICERY_FAILURE_SPEED_BY_LAND
    End Enum

    Enum emInstructionfornondelivery
        INSTRUCTION_CODE_REDIRECT
        INSTRUCTION_CODE_RETURN_TO_SENDER
        INSTRUCTION_CODE_DISCLAIMED
        INSTRUCTION_CODE_RETURN_TO_SENDER_NOW
    End Enum

    Enum emDeclaredContent
        PACKET_CN23_COMM_SAMPLE
        PACKET_CN23_GIFT
        PACKET_CN23_GOODS_RETURNING
        PACKET_CN23_OTHER
        PACKET_CN23_DOCUMENTS
    End Enum


    ''' <remarks>данные для отправки посылки</remarks>
    Class clsParcelInfo
        Implements INotifyPropertyChanged

        Dim oResultParcel As clsResultParcelInfo

        Public Property Agent As Service.Agents.AUCTIONDATAAGENT


        Private oClientAddress As clsAddress
        ''' <summary>
        ''' Адрес клиента
        ''' </summary>
        Public Property ClientAddress As clsAddress
            Get
                Return oClientAddress
            End Get
            Set(value As clsAddress)
                oClientAddress = value
                RaisePropertyChanged("ClientAddress")
            End Set
        End Property

        Private oGoodCodesList As String()
        ''' <summary>
        ''' Список номеров образцов
        ''' </summary>
        Public Property GoodCodesList As String()
            Get
                Return oGoodCodesList
            End Get
            Set(value As String())
                oGoodCodesList = value
                RaisePropertyChanged("GoodCodesList")
            End Set
        End Property


        Private oMaximumDateToSend As Date
        ''' <summary>
        ''' Крайняя дата отправки
        ''' </summary>
        Public Property MaximumDateToSend As Date
            Get
                Return oMaximumDateToSend
            End Get
            Set(value As Date)
                oMaximumDateToSend = value
                RaisePropertyChanged("MaximumDateToSend")
            End Set
        End Property


        ''' <summary>
        ''' состав посылки
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property GoodList As List(Of String)
            Get
                Dim _out As New List(Of String)

                For i = 0 To GoodCodesList.Length - 1
                    _out.Add(GoodCodesList(i) & ": " & GoodPlacesList(i))
                Next
                Return _out
            End Get
        End Property


        Private oDeclaration As clsDeclaration_CP71_CN23
        ''' <summary>
        ''' Текст, который надо указать в декларации CN22 или CN23
        ''' </summary>
        Public Property Declaration As clsDeclaration_CP71_CN23
            Get
                Return oDeclaration
            End Get
            Set(value As clsDeclaration_CP71_CN23)
                oDeclaration = value
                RaisePropertyChanged("Declaration")
            End Set
        End Property
        ''' <summary>
        ''' результаты отправки посылки
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ResultParcel As clsResultParcelInfo
            Get
                Return oResultParcel
            End Get
            Set(value As clsResultParcelInfo)
                oResultParcel = value
                RaisePropertyChanged("ResultParcel")
            End Set
        End Property


        Private oMustDeclared As Boolean

        ''' <summary>
        ''' Для посылки необходимо оформить декларацию
        ''' </summary>
        Public Property MustDeclared As Boolean
            Get
                Return oMustDeclared
            End Get
            Set(value As Boolean)
                oMustDeclared = value
                RaisePropertyChanged("MustDeclared")
            End Set
        End Property


        Private oGoodPlacesList As String()
        ''' <summary>
        ''' Места на складе для товаров
        ''' </summary>
        Public Property GoodPlacesList As String()
            Get
                Return oGoodPlacesList
            End Get
            Set(value As String())
                oGoodPlacesList = value
                RaisePropertyChanged("GoodPlacesList")
            End Set
        End Property

        Private oDemandUUID As String
        ''' <summary>
        ''' UUID отгрузки, инициировавшей отправку посылки
        ''' </summary>
        Public Property DemandUUID As String
            Get
                Return oDemandUUID
            End Get
            Set(value As String)
                oDemandUUID = value
                RaisePropertyChanged("DemandUUID")
            End Set
        End Property

        Public Overrides Function ToString() As String
            Dim _out As String = ""
            If Not Me.GoodCodesList Is Nothing Then
                For i = 0 To Me.GoodCodesList.Length - 1
                    If Me.GoodPlacesList.Length > i Then
                        If Not Me.GoodPlacesList(i) = "" Then
                            _out += Me.GoodCodesList(i) & " :" & Me.GoodPlacesList(i) & ChrW(13)
                        Else
                            _out += Me.GoodCodesList(i) & ChrW(13)
                        End If

                    Else
                        _out += " " & Me.GoodCodesList(i) & " : ??" & ChrW(13)
                    End If
                Next
            End If


            Return _out
        End Function
        Sub RaisePropertyChanged(ByVal propertyName As String)
            Dim propertyChanged As System.ComponentModel.PropertyChangedEventHandler = Me.PropertyChangedEvent
            If (Not (propertyChanged) Is Nothing) Then
                propertyChanged(Me, New System.ComponentModel.PropertyChangedEventArgs(propertyName))
            End If
        End Sub
        Public Event PropertyChanged(sender As Object, e As PropertyChangedEventArgs) Implements INotifyPropertyChanged.PropertyChanged
    End Class

    ''' <summary>
    ''' описывает адрес в формате для заполнения в почтовой программе
    ''' </summary>
    ''' <remarks></remarks>
    Class clsAddress
        Implements INotifyPropertyChanged





        Private oName As String
        ''' <summary>
        ''' Почтовое имя (кому)
        ''' </summary>
        Property Name As String
            Get
                Return oName
            End Get
            Set(value As String)
                oName = value
                RaisePropertyChanged("Name")
            End Set
        End Property

        Private oStreet As String
        ''' <summary>
        ''' Улица
        ''' </summary>
        Public Property Street As String
            Get
                Return oStreet
            End Get
            Set(value As String)
                oStreet = value
                RaisePropertyChanged("Street")
            End Set
        End Property

        Private oCity As String

        ''' <summary>
        ''' Город
        ''' </summary>
        Public Property City As String
            Get
                Return oCity
            End Get
            Set(value As String)
                oCity = value
                RaisePropertyChanged("City")
            End Set
        End Property

        Private oState As String
        ''' <summary>
        ''' Волость (Район, Штат)
        ''' </summary>
        Public Property State As String
            Get
                Return oState
            End Get
            Set(value As String)
                oState = value
                RaisePropertyChanged("State")
            End Set
        End Property


        Private oPostIndex As String
        ''' <summary>
        ''' Индекс
        ''' </summary>
        Public Property PostIndex As String
            Get
                Return oPostIndex
            End Get
            Set(value As String)
                oPostIndex = value
                RaisePropertyChanged("PostIndex")
            End Set
        End Property

        Private oCountry As String
        ''' <summary>
        ''' Страна
        ''' </summary>
        Public Property Country As String
            Get
                Return oCountry
            End Get
            Set(value As String)
                oCountry = value
                RaisePropertyChanged("Country")
            End Set
        End Property


        Private oPhone As String
        ''' <summary>
        ''' Телефон
        ''' </summary>
        Public Property Phone As String
            Get
                Return oPhone
            End Get
            Set(value As String)
                oPhone = value
                RaisePropertyChanged("Phone")
            End Set
        End Property

        Private oFullAddress As String = ""
        Private oemail As String

        ''' <summary>
        ''' полный адрес клиента
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property FullAddress As String
            Get
                Return oFullAddress
            End Get
            Set(value As String)
                oFullAddress = value
                RaisePropertyChanged("FullAddress")
            End Set
        End Property


        Public Property email As String
            Get
                Return oemail
            End Get
            Set(value As String)
                oemail = value
                RaisePropertyChanged("email")
            End Set
        End Property



        Public Overrides Function ToString() As String
            Dim _out As String = ""
            If Not Me.Name = "" Then
                _out += Me.Name & ChrW(13)
            End If
            If Not Me.Street = "" Then
                _out += Me.Street & ChrW(13)
            End If
            If Not Me.City = "" Then
                _out += Me.City & ChrW(13)
            End If
            If Not Me.PostIndex = "" Then
                _out += Me.PostIndex & ChrW(13)
            End If
            If Not Me.Country = "" Then
                _out += Me.Country & ChrW(13)
            End If
            If Not Me.Phone = "" Then
                _out += "tel." & Me.Phone & ChrW(13)
            End If

            Return _out
        End Function

        Sub RaisePropertyChanged(ByVal propertyName As String)
            Dim propertyChanged As System.ComponentModel.PropertyChangedEventHandler = Me.PropertyChangedEvent
            If (Not (propertyChanged) Is Nothing) Then
                propertyChanged(Me, New System.ComponentModel.PropertyChangedEventArgs(propertyName))
            End If
        End Sub

        Public Event PropertyChanged(sender As Object, e As PropertyChangedEventArgs) Implements INotifyPropertyChanged.PropertyChanged

        Public Sub New()

        End Sub
    End Class

    Function GetExpeditionList() As List(Of String)


    ''' <summary>
    ''' запрос остатков по части имени/ ShotCode может представлять категорию товара
    ''' </summary>
    ''' <param name="PartName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function FindStokQuantity(PartName As String, Optional ShotCode As String = "", Optional WareHouseName As String = "", Optional IncludeReserved As Boolean = False, Optional GroupUUID As String = "", Optional GoodUUID As String = "") As List(Of clsStokQuantity)

    ''' <summary>
    ''' найдет категорию (папку) для товара
    ''' </summary>
    ''' <param name="ShotCode"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function FindGoodCategory(ShotCode As String) As String

    ''' <summary>
    ''' Запишет данные о выставлении образца
    ''' </summary>
    ''' <param name="MyCompanyUUID">UUID организации, для которой ведется учет</param>
    ''' <param name="SampleShotNumber">Номер, принятый в МС</param>
    ''' <param name="GoodCode">Номер товара (код)</param>
    ''' <param name="ReservCustomerOrderUUID">Заказ, используемый для резервации образца</param>
    ''' <param name="ItemAmount">Сумма выставления</param>
    ''' <param name="CurrencyUUID">Валюта (будет пересчитано в валюту заказа)</param>
    Function SetSampleToAction(SampleNumber As clsApplicationTypes.clsSampleNumber, ReservCustomerOrderUUID As String, ItemAmount As Decimal, Reserving As Boolean) As Boolean

    ''' <summary>
    ''' Снимет образец с аукциона. Вернет UUID снятого товара.
    ''' </summary>
    ''' <param name="GoodCode">Номер товара (код)</param>
    ''' <param name="ReservCustomerOrderUUID">Заказ, используемый для резервации образца</param>
    Function EndSampleOnAuction(GoodCode As String, ReservCustomerOrderUUID As String) As String

    ''' <summary>
    ''' Создаст заказ для аукциона. Вернет UUID созданного обьекта
    ''' </summary>
    ''' <param name="GoodCodes">Список UUID добавляемых товаров</param>
    ''' <param name="GoodsUUIDs">UUID товаров к добавлению (кроме технических)</param>
    ''' <param name="GoodsQtys">Количества товаров</param>
    ''' <param name="GoodsAmounts">Стимости товаров</param>
    ''' <param name="ShippingInAmount">Получено за шиппинг от клиента</param>
    ''' <param name="ShippingInQty">количество полученного шиппинга (1шт)</param>
    ''' <param name="ShippingInGoodUUID">UUID товара шиппинга в МС</param>
    ''' <param name="ShippingInUUID">UUID товара, представляющего шиппинг (при пусто включен не будет)</param>
    ''' <param name="ShippingAmount">сумма, полученная за шиппинг</param>
    ''' <param name="GoodAmounts">Список сумм, полученных за товары (в той же последовательности, что и кода товаров)</param>
    ''' <param name="MyCompanyUUID">UUID организации МС, на которую оформляется документ</param>
    ''' <param name="ProjectUUID">UUID проекта (будет указан в заказе)</param>
    ''' <param name="CustomerUUID">UUID клиента МС</param>
    ''' <param name="CurrencyUUID">UUID валюты заказа</param>
    ''' <param name="WokerUUID">UUID сотрудника, оформляющего заказ (из справочника)</param>
    ''' <param name="HandlingTime">время, отведенное на упаковку заказа</param>
    ''' <param name="Orderstate1UUID">UUID статуса заказа, который надо установить (в работе)</param>
    ''' <param name="LinkedIncomingPayment">UUID привязанного входящего платежа</param>
    ''' <param name="Description">Комментарий</param>
    Function CreateCustomerOrder(GoodsUUIDs As String(), GoodsQtys As Decimal(), GoodsAmounts As Decimal(), ShippingInAmount As Decimal, ShippingInQty As Decimal, ShippingInGoodUUID As String, MyCompanyUUID As String, ProjectUUID As String, CustomerUUID As String, CurrencyUUID As String, WokerUUID As String, HandlingTime As Integer, Orderstate1UUID As String, Description As String, Optional OrderDate? As Date = Nothing) As iMoySkladDataProvider.clsOperationInfo


    ''' <summary>
    ''' вернет 
    ''' </summary>
    ''' <param name="OrderUUID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetOrderInfo(OrderName As String, Optional OrderUUID As String = "") As List(Of clsOperationInfo)


    ''' <summary>
    ''' вернет 
    ''' </summary>
    ''' <param name="OrderUUID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetDemandInfo(DemandName As String, Optional DemandUUID As String = "") As List(Of clsOperationInfo)

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="MyCompany"></param>
    ''' <param name="WarehouseName"></param>
    ''' <param name="GoodsUUIDs"></param>
    ''' <param name="Description"></param>
    ''' <param name="WareCellName"></param>
    ''' <param name="StateUUID"></param>
    ''' <param name="Applicable"></param>
    ''' <param name="GoodsQtys"></param>
    ''' <returns></returns>
    Function CreateInventory(MyCompany As String, WarehouseName As String, GoodsUUIDs() As String, Description As String, Optional WareCellName As String = "", Optional StateUUID As String = "2fb659a6-d883-11e4-90a2-8ecb001c0a01", Optional Applicable As Boolean = True, Optional GoodsQtys As Decimal() = Nothing) As iMoySkladDataProvider.clsOperationInfo


    ''' <summary>
    ''' Сохранить клиента. ПОКА СОХРАНЯЕТ ТОЛЬКО Имя, Код МС, емайл и предпочтительный емайл
    ''' </summary>
    ''' <param name="customer"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function SaveCustomer(customer As iMoySkladDataProvider.clsClientInfo) As iMoySkladDataProvider.clsClientInfo


    ''' <summary>
    ''' Создаст клиента МС. Вернет UUID созданного обьекта
    ''' </summary>
    ''' <param name="FullName">полное имя (как в письмах)</param>
    ''' <param name="CustomerCode">код клиента, для eBay - как имя eBay</param>
    ''' <param name="Address">адрес разобранный для omniva</param>
    ''' <param name="AddressString">строка адреса полностью</param>
    ''' <param name="ClientGetPlaceUUID">UUID из справочника Где узнали клиента для конкретного аукциона</param>
    ''' <param name="ClientInterestUUID">UUID из справочника Интересы клиента</param>
    ''' <param name="ClientInterestDetails">Интересы клиента детально</param>
    ''' <param name="ClientMCTags">Массив тегов для клиента = Группы</param>
    ''' <param name="ClientCountryUUID">UUID страны клиента из справочника Страны</param>
    ''' <param name="description">описание</param>
    ''' <param name="ClientMCGroupsUUID">Группы, куда нужно включить клиента</param>
    Function CreateCustomer(FullName As String, CustomerCode As String, Email As String, Address As clsAddress, AddressString As String, ClientGetPlaceUUID As String, ClientInterestUUID As String, ClientInterestDetails As String, ClientMCTags As String(), ClientCountryUUID As String, description As String) As String

    ''' <summary>
    ''' Данные из справочника Интересы Клиента (UUID,Value)
    ''' </summary>
    Function GetClientsInterest() As Dictionary(Of String, String)

    ''' <summary>
    ''' Данные из справочника Сотрудник Trilbone (UUID,Value)
    ''' </summary>
    Function GetTriboneWoker() As Dictionary(Of String, String)

    ''' <summary>
    ''' Данные по группам, куда можно включать клиентов
    ''' </summary>
    Function GetClientsTags() As String()

    ''' <summary>
    ''' Проверит существование клиента по любому параметру, вернет UUID или пусто
    ''' </summary>
    ''' <param name="Code">код клиента, для eBay - как имя eBay</param>
    ''' <param name="FullName">Имя клиента (совпадение)</param>
    ''' <param name="CustomerCode">код клиента, для eBay - как имя eBay</param>
    Function FindCustomer(PartName As String, Email As String, CustomerCode As String, Optional reload As Boolean = False) As iMoySkladDataProvider.clsClientInfo()

    ''' <summary>
    ''' Создаст отгрузку. Вернет UUID созданного обьекта
    ''' </summary>
    ''' <param name="MyCompanyUUID">UUID организации МС, на которую оформляется документ</param>
    ''' <param name="CustomerUUID">UUID клиента МС</param>
    ''' <param name="ProjectUUID">UUID проекта (будет указан в платеже)</param>
    ''' <param name="InvocePaymentTypeUUID">UUID типа оплаты инвойса (из справочника)</param>
    ''' <param name="ShippingInGoodUUID">UUID товара входящего шиппинга</param>
    ''' <param name="ShippingInUUID">UUID товар Шиппинг (Получено от клиента)</param>
    ''' <param name="ShippingInAmount">сумма полученная за шиппинг от клиента</param>
    ''' <param name="ShippingInQty">кол-во входящего шиппинга (1шт)</param>
    ''' <param name="ShippingAmount">сколько получено за шиппинг</param>
    ''' <param name="CurrencyUUID">валюта отгрузки</param>
    ''' <param name="GoodsUUIDs">UUID товаров для отгрузки, кроме технических</param>
    ''' <param name="GoodsAmounts">стоимости товаров для отгрузки</param>
    ''' <param name="GoodsQtys">количества товаров для отгрузки</param>
    ''' <param name="GoodCodes">Список добавляемых товаров</param>
    ''' <param name="GoodAmounts">Список сумм, полученных за товары (в той же последовательности, что и кода товаров)</param>
    ''' <param name="PayPalStartFeeGoodUUID">UUID товара PayPalFee.  для каждого PAYPAL аккаунта свой. Зависит от выбранного paypal аккаунта для входящего платежа.</param>
    ''' <param name="EbayFeeEndGoodUUID">UUID товара EbayFee по окончании. для каждого аукциона свой</param>
    ''' <param name="PayPalStartFeeAmount">сумма за прием денег</param>
    ''' <param name="EbayFeeEndAmount">сумма по окончанию аукциона</param>
    ''' <param name="StateUUID">статус отгрузки =на отправку</param>
    ''' <param name="WarehouseUUID">Склад Отгрузки</param>
    ''' <param name="Description">Комментарий</param>
    ''' <param name="ShippingCurrencyUUID">UUID валюты отгрузки</param>
    ''' <param name="GoodShippingUUID">UUID товара Шиппинг (Получено от клиента)</param>
    ''' <param name="Applicable">проведено</param>
    Function CreateDemand(MyCompanyUUID As String, CustomerUUID As String, ProjectUUID As String, StateUUID As String, WarehouseUUID As String, InvocePaymentTypeUUID As String, CurrencyUUID As String, GoodsUUIDs As String(), GoodsAmounts As Decimal(), GoodsQtys As Decimal(), Description As String, Applicable As Boolean, Optional DemandDate? As Date = Nothing) As iMoySkladDataProvider.clsOperationInfo






    ''' <summary>
    ''' Окончательный рассчет по продаже
    ''' </summary>
    ''' <param name="DemandUUID"></param>
    ''' <param name="ExportFee">сумма за экспорт</param>
    ''' <param name="ExportGoodUUID">UUID товара Экспорт.</param>
    ''' <param name="NalogFee">сумма налогов к оплате</param>
    ''' <param name="NalogFeeUUID">UUID товара Налоги.  для каждой организации свой. Зависит от выбранного paypal аккаунта для входящего платежа.</param>
    ''' <param name="PayPalOutFeeGoodUUID">UUID товара PayPal вывод, коммиссия.  для каждого PAYPAL аккаунта свой. Зависит от выбранного paypal аккаунта для входящего платежа.</param>
    ''' <param name="EbayFeeStartGoodUUID">UUID товара EbayFee за выставление. для каждого аукциона свой</param>
    ''' <param name="PayPalOutFeeAmount">сумма за вывод денег</param>
    ''' <param name="EbayFeeStartAmount">сумма за выставление</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function UpdateDemandsAfterCalculate(DemandUUID As String, PayPalOutFeeAmount As Decimal, PayPalOutFeeGoodUUID As String, EbayFeeStartAmount As Decimal, EbayFeeStartGoodUUID As String, ExportFee As Decimal, ExportGoodUUID As String, exportQuantity As Decimal, NalogFee As Decimal, NalogFeeUUID As String, ShippingInGoodUUID As String, ShippingInAmount As Decimal, ShippingInQty As Decimal, PayPalStartFeeGoodUUID As String, EbayFeeEndGoodUUID As String, PayPalStartFeeAmount As Decimal, EbayFeeEndAmount As Decimal) As Boolean

    ''' <summary>
    ''' Ищет товары по части имени. Если задан AllWord, то будут добавлены все товары, содержащие ЛЮБОЕ из слов запроса. Ограничить запрос можно кодом.
    ''' </summary>
    ''' <param name="PartOfName"></param>
    ''' <param name="GoodShotCode"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function FindGoods(PartOfName As String, Optional GoodShotCode As String = "", Optional AllWord As Boolean = False) As List(Of clsApplicationTypes.clsSampleNumber.strGoodInfo)



    ''' <summary>
    ''' Обновит карточку товара
    ''' </summary>
    ''' <param name="goodCodeToUpdate">Номер или артикул</param>
    ''' <param name="inbuyPrice">цена закупки</param>
    ''' <param name="buyCurrencyName">валюта закупки</param>
    ''' <param name="insalePrice">цена продажи</param>
    ''' <param name="saleCurrencyName">валюта продажи</param>
    ''' <param name="specificPrice">цена, название которой указано в specificPriceName</param>
    ''' <param name="specificPriceCurrencyName">валюта цены</param>
    ''' <param name="specificPriceName">название цены</param>
    ''' <param name="uomName">имя еденицы измерения</param>
    ''' <param name="ingoodname">новое название товара</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function UpdateGoodPrice(goodCodeToUpdate As String, inbuyPrice As Decimal, buyCurrencyName As String, insalePrice As Decimal, saleCurrencyName As String, uomName As String, ingoodname As String, goodweight As Decimal, Optional Prices As List(Of strPrices) = Nothing) As String

    Enum emPriceType
        BuyPrice
        MinimumPrice
        RusInOffice
        RusShop
        EuInOffice
        EuInShop
        EuPostBank
        EuPostPayPal
        Invoce
        Ebay
    End Enum

    Structure strPrices
        Property PriceType As iMoySkladDataProvider.emPriceType
        Property PriceTypeUUID As String

        Property BaseCurrency As String

        Property Description As String
        ''' <summary>
        ''' для передачи значений
        ''' </summary>
        ''' <remarks></remarks>
        Dim value As Decimal
    End Structure
    ''' <summary>
    '''создаст перемещение. Ячейка назначения указывается для каждого товара в поле NewSlotName. В передаваемой структуре товара может быть заполнено поле SlotUUID или SlotName (исходная ячейка), иначе будет перемещение со склада (т.е. не из ячейки!). Если не указать UUID товара, то будет осуществлен поиск товара!
    ''' </summary>
    ''' <param name="sourceStoreName"></param>
    ''' <param name="targetStoreName"></param>
    ''' <param name="goodList"></param>
    ''' <param name="TargetSlotName"></param>
    ''' <param name="MoveState"></param>
    ''' <returns></returns>
    Function CreateMove(sourceStoreName As String, targetStoreName As String, goodList() As strGoodMapQty, Optional MoveState As emMoveState = Nothing) As clsOperationInfo

    ''' <summary>
    ''' статусы перемещений
    ''' </summary>
    Enum emMoveState
        empty
        ''' <summary>
        ''' размещение по ячейкам
        ''' </summary>
        poYacheikam
        ''' <summary>
        ''' возврат найденных
        ''' </summary>
        VozvratNaydennyh
    End Enum


    ''' <summary>
    ''' структура размещения товара
    ''' </summary>
    ''' <remarks></remarks>
    Structure strGoodMapQty

        Public Property Empty As Boolean

        'название товара
        Public Name As String

        'UUID товара
        Public UUID As String

        'код
        Private oActualCode As Service.clsApplicationTypes.clsSampleNumber
    
        Public ReadOnly Property ActualCode As String
            Get
                If oActualCode Is Nothing Then Return ""
                Return oActualCode.ShotCode
            End Get
        End Property


        ''' <summary>
        ''' текущий код, задается свос-ми code и(или) ProductCode
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property ActualSampleNumber As clsApplicationTypes.clsSampleNumber
            Get
                If oActualCode Is Nothing Then Return Nothing
                Return clsApplicationTypes.clsSampleNumber.CreateFromString(oActualCode.EAN13)
            End Get
        End Property

        Public ReadOnly Property SlotString As String
            Get
                Return ToString()
            End Get
        End Property

        Private oCode As String
        Dim oProductCode As String
        Private oIsArticul As Boolean

        Public ReadOnly Property IsArticul As Boolean
            Get
                Return oIsArticul
            End Get
        End Property



        'код
        Public Property code As String
            Get
                Return oCode
            End Get
            Set(value As String)
                oCode = value
                oActualCode = clsApplicationTypes.clsSampleNumber.CreateFromString(value)
                oIsArticul = False
            End Set
        End Property
        'артикул
        Public Property ProductCode As String
            Get
                Return oProductCode
            End Get
            Set(value As String)
                oProductCode = value
                oActualCode = clsApplicationTypes.clsSampleNumber.CreateFromString(value)
                oIsArticul = True
            End Set
        End Property


        'кол-во
        Public Property Qty As Double

        'ед изм
        Public Property UomName As String

        'название целевой ячейки
        Public Property NewSlotName As String
        'UUID целевой ячейки
        Public Property NewSlotUUID As String

        'название ячейки хранения (текущей)
        Public Property SlotName As String
        'UUID ячейки
        Public Property SlotUUID As String
        'название склада
        Public Property WareName As String
        'UUID склада
        Public Property WareUUID As String


        Public Overrides Function ToString() As String
            'требуется получить код/артикул/кол-во  8-256(1шт) или ар.8-266-1(0,25кг)
            Dim _out As String = ""
            If Not Me.code = "" Then
                _out += String.Format("{0}", Me.code)
            End If
            If Not Me.ProductCode = "" Then
                _out += String.Format("ар.{0}", Me.ProductCode)
            End If

            _out += String.Format("({0}{1})", Me.Qty, Me.UomName)
            Return _out
        End Function
    End Structure



    ''' <summary>
    ''' описывает лот ОДИНАКОВЫХ товаров
    ''' </summary>
    Structure strLot
        Private oLotCurrency As String
        ''' <summary>
        ''' полная стоимость лота
        ''' </summary>
        ''' <returns></returns>
        Property LotPrice As Decimal

        ''' <summary>
        ''' валюта лота. при повторной установке идет конвертация лота
        ''' </summary>
        ''' <returns></returns>
        Property LotCurrency As String
            Get
                Return oLotCurrency
            End Get
            Set(value As String)
                If value.Equals(oLotCurrency) Then Return
                If String.IsNullOrEmpty(oLotCurrency) Then
                    'задаем впервые
                    Me.oLotCurrency = value
                Else
                    'меняем валюту лота
                    Me.ConvertLotToCurrency(value)
                End If
            End Set
        End Property

        ''' <summary>
        ''' кол-во единиц лота
        ''' </summary>
        ''' <returns></returns>
        Property LotQty As Decimal

        ''' <summary>
        ''' единица измерения лота
        ''' </summary>
        ''' <returns></returns>
        Property LotUomName As String

        ''' <summary>
        ''' цены позиции лота. Считаем, что лот состоит из одинаковых позиций
        ''' </summary>
        ''' <returns></returns>
        Property LotUnitPrices As List(Of strPrices)

        ''' <summary>
        ''' добавить цену
        ''' </summary>
        ''' <param name="value"></param>
        ''' <param name="pricetype"></param>
        Sub AddPrice(value As Decimal, pricetype As emPriceType)
            If Me.LotUnitPrices Is Nothing Then
                Me.LotUnitPrices = New List(Of strPrices)
            End If
            Me.LotUnitPrices.Add(New strPrices With {.BaseCurrency = Me.LotCurrency, .PriceType = pricetype, .value = value})
        End Sub


        ''' <summary>
        ''' категория качества лота 0=не задана: 1=самая плохая
        ''' </summary>
        ''' <returns></returns>
        Property LotCategory As Integer


        ReadOnly Property IsEmptyLot As Boolean
            Get
                If Me.LotQty = 0 Then Return True
                Return False
            End Get
        End Property

        Public Shared Function Empty() As strLot
            Return New strLot With {.LotQty = 0}
        End Function


        ''' <summary>
        ''' сравнивает ед. изм. лотов
        ''' </summary>
        ''' <param name="other"></param>
        ''' <returns></returns>
        Function IsDifferentUom(other As strLot) As Boolean
            Return Not Me.LotUomName.ToLower.Equals(other.LotUomName.ToLower)
        End Function

        ''' <summary>
        ''' посмотреть цену лота в валюте
        ''' </summary>
        ''' <param name="currency"></param>
        ''' <returns></returns>
        Function GetLotPriceInCurrency(Optional currency As String = "RUR") As Decimal
            Return clsApplicationTypes.CurrencyConvert(Me.LotPrice, Me.LotCurrency, currency)
        End Function

        ''' <summary>
        ''' посмотреть конкретную цену в валюте
        ''' </summary>
        ''' <param name="pricetype"></param>
        ''' <param name="currency"></param>
        ''' <returns></returns>
        Function GetUnitPriceInCurrency(pricetype As emPriceType, Optional currency As String = "RUR") As Decimal

            Dim _pr = From c In Me.LotUnitPrices Where c.PriceType = pricetype Select c
            If _pr.Count = 0 Then Return 0

            Return clsApplicationTypes.CurrencyConvert(_pr.FirstOrDefault.value, _pr.FirstOrDefault.BaseCurrency, currency)
        End Function

        ''' <summary>
        '''ПОЛНЫЙ конвертор лота в другую валюту
        ''' </summary>
        ''' <param name="currency"></param>
        Sub ConvertLotToCurrency(Optional currency As String = "RUR")
            'tested
            If Not Me.LotUnitPrices Is Nothing Then
                Dim _pr As New List(Of strPrices)
                For Each t In Me.LotUnitPrices
                    _pr.Add(New strPrices With {.value = clsApplicationTypes.CurrencyConvert(t.value, t.BaseCurrency, currency), .BaseCurrency = currency, .PriceType = t.PriceType})

                Next
                Me.LotUnitPrices = _pr
            End If
            Me.LotPrice = clsApplicationTypes.CurrencyConvert(Me.LotPrice, Me.oLotCurrency, currency)
            Me.oLotCurrency = currency
            Return
        End Sub

        ''' <summary>
        '''ОСНОВНАЯ конвертор лота в другую единицу измерения. Пересчитывает цены(если заданы). 
        ''' 10кг лот (по 50 за кг)=>50шт(по 10 за шт). вернет коефф. для ед. пересчета = 5(вход.ед/исходн.ед) (шт/кг)
        ''' </summary>
        ''' <param name="newuom">новая ед.изм.</param>
        ''' <param name="newqty">новое количество в лоте</param>
        Function ConverLotToUom(newuom As String, newqty As Decimal) As Decimal
            'tested
            If newqty = 0 Then Return 1
            If Me.LotQty = 0 Then Return 1
            If Me.LotUomName.ToLower.Equals(newuom.ToLower) Then Return 1
            Dim _k = newqty / Me.LotQty '(шт/кг)

            'пересчитать цены за единицу
            Dim _pr As New List(Of strPrices)
            If Not Me.LotUnitPrices Is Nothing Then
                For Each t In Me.LotUnitPrices
                    _pr.Add(New strPrices With {.value = Math.Round(t.value * 1 / _k, 2), .BaseCurrency = t.BaseCurrency, .PriceType = t.PriceType})
                Next
            End If
            Me.LotUomName = newuom.ToLower
            Me.LotQty = newqty
            Me.LotUnitPrices = _pr
            Return _k
        End Function

        ''' <summary>
        ''' рассчитывает и конвертирует лот в новую ед.изм по значению одной позиции, например шт-новая мера, 10кг лот (по 50 за кг),pieceValueInOldUom=0.2кг на 1шт, будет результат 50шт(по 10 за шт)
        ''' </summary>
        ''' <param name="pieceValueInOldUom">значение 1 новой единицы в старых</param>
        ''' <param name="newuom">новая ед измерен</param>
        Sub CalculatedConvertToUom(pieceValueInOldUom As Decimal, newuom As String)
            If pieceValueInOldUom = 0 Then Return
            If Me.LotUomName.ToLower.Equals(newuom.ToLower) Then Return

            Dim _newQty = Me.LotQty / pieceValueInOldUom
            Select Case newuom.ToLower
                Case "шт", "pcs"
                    _newQty = Math.Round(_newQty)
                Case "г", "g"
                    _newQty = Math.Round(_newQty)
                Case Else
                    _newQty = Math.Round(_newQty, 3)
            End Select
            'пересчитать цены за единицу
            Dim _pr As New List(Of strPrices)
            If Not Me.LotUnitPrices Is Nothing Then
                For Each t In Me.LotUnitPrices
                    _pr.Add(New strPrices With {.value = Math.Round(Me.LotQty / _newQty * t.value, 2), .BaseCurrency = t.BaseCurrency, .PriceType = t.PriceType})
                Next
            Else
                _pr.Add(New strPrices With {.value = Math.Round(Me.LotPrice / _newQty, 2), .BaseCurrency = Me.LotCurrency, .PriceType = emPriceType.BuyPrice})
            End If
            Me.LotUomName = newuom.ToLower
            Me.LotQty = _newQty
            Me.LotUnitPrices = _pr
        End Sub

        ''' <summary>
        ''' вынуть лот из текущего. вернет остаток.Рассчитывает цену остатка (вынули на сумму, если одного ТИПА цены заданы в двух слагаемых).
        ''' pieceValueInUom=0.2кг(me) на 1шт(target)(например). target=вынимаемый лот
        ''' </summary>
        ''' <param name="target">вычитаемый лот</param>
        ''' <returns></returns>
        Public Function MinusLot(target As strLot, pieceValueInUom As Decimal) As strLot
            If pieceValueInUom = 0 Then Return strLot.Empty

            target.CalculatedConvertToUom(pieceValueInUom, Me.LotUomName)

            If target.LotPrice = 0 Then
                'вычислить по среднему
                target.LotPrice = target.LotQty * Me.LotPrice / Me.LotQty
            End If
            Return (Me - target)
        End Function


        ''' <summary>
        ''' вычитает лот из другого. Вернет остаток. Рассчитывает цену остатка (вынули на сумму, если одного ТИПА цены заданы в двух слагаемых).
        ''' </summary>
        ''' <param name="left"></param>
        ''' <param name="right"></param>
        ''' <returns></returns>
        Public Overloads Shared Operator -(left As strLot, right As strLot) As strLot
            'left - из чего вычитаем
            'right - что вычитаем
            If left.IsDifferentUom(right) Then
                Throw New ArgumentException("Вычитание лотов с разными единицами измерения невозможно. Сначала приведи лоты к одной ед.изм.")
                Return strLot.Empty
            End If
            Dim _leftOldQty = left.LotQty
            left.LotQty = left.LotQty - right.LotQty

            If left.LotQty = 0 Then
                'вычли весь лот
                Return strLot.Empty
            End If

            'остаток по цене
            Dim _oldprice = left.LotPrice
            left.LotPrice = clsApplicationTypes.CurrencyConvert(clsApplicationTypes.CurrencyConvert(left.LotPrice, left.LotCurrency, "RUR") - clsApplicationTypes.CurrencyConvert(right.LotPrice, right.LotCurrency, "RUR"), "RUR", left.LotCurrency)

            'исправить цены
            If Not left.LotUnitPrices Is Nothing And Not right.LotUnitPrices Is Nothing Then
                Dim _pr As New List(Of strPrices)
                For Each t In left.LotUnitPrices
                    For Each tr In right.LotUnitPrices
                        If t.PriceType = tr.PriceType Then
                            Dim _lsum = _leftOldQty * clsApplicationTypes.CurrencyConvert(t.value, t.BaseCurrency, "RUR")
                            Dim _rsum = right.LotQty * clsApplicationTypes.CurrencyConvert(tr.value, tr.BaseCurrency, "RUR")
                            Dim _prs = clsApplicationTypes.CurrencyConvert((_lsum - _rsum), "RUR", t.BaseCurrency)
                            Dim _vl = Math.Round(_prs / left.LotQty, 2)
                            _pr.Add(New strPrices With {.value = _vl, .BaseCurrency = t.BaseCurrency, .PriceType = t.PriceType})
                        End If
                    Next
                Next
                left.LotUnitPrices = _pr
            End If
            Return left
        End Operator

        ''' <summary>
        ''' увеличить цены на фикс. значение
        ''' </summary>
        Sub increasePrices(addCost As Decimal, addcostCurrency As String)
            If Not Me.LotUnitPrices Is Nothing Then
                Dim _pr As New List(Of strPrices)
                For Each t In Me.LotUnitPrices
                    _pr.Add(New strPrices With {.value = t.value + clsApplicationTypes.CurrencyConvert(addCost, addcostCurrency, t.BaseCurrency), .BaseCurrency = t.BaseCurrency, .PriceType = t.PriceType})
                Next
                Me.LotUnitPrices = _pr
            End If
        End Sub

        ''' <summary>
        ''' буфер хранения UI
        ''' </summary>
        Private oExcelUI As Service.ucPriceCalc


        ''' <summary>
        ''' вернет ЭУ ценами. Цены будут также созданы в самой структуре.unitWeight = вес единицы лота в кг, для которой считаем
        ''' prepCostByUnit = затраты на препарацию в рублях(если есть)
        ''' pribil = чистые концы (50% чистой прибыли по умолчанию)
        ''' </summary>
        ''' <param name="unitWeight"></param>
        ''' <param name="prepCostByUnit"></param>
        ''' <param name="pribil"></param>
        ''' <returns></returns>

        Function getUI(unitWeight As Decimal, Optional prepCostByUnit As Decimal = 0, Optional pribil As Decimal = 0.5) As Service.ucPriceCalc
            If oExcelUI Is Nothing Then
                oExcelUI = New Service.ucPriceCalc
                oExcelUI.init(clsApplicationTypes.GetRateByCurrencyCB103("EUR"), clsApplicationTypes.GetRateByCurrencyCB103("EUR") / clsApplicationTypes.GetRateByCurrencyCB103("USD"), clsApplicationTypes.GetPriceFilePath)
            End If

            Dim _incoming As Decimal = clsApplicationTypes.CurrencyConvert(Me.LotPrice / Me.LotQty, Me.LotCurrency, "RUR")

            oExcelUI.SetData(Hunt_cost:=_incoming, Prep_cost:=prepCostByUnit, Weight:=unitWeight, ClearProfit:=pribil)

            Me.LotUnitPrices = Nothing
            'добавить входящую
            Me.AddPrice(Me.LotPrice / Me.LotQty, emPriceType.BuyPrice)
            Me.LotUnitPrices.AddRange(oExcelUI.GetPrices)

            Return oExcelUI
        End Function

    End Structure
    ''' <summary>
    ''' выдаст список ячеек склада
    ''' </summary>
    ''' <param name="WarehouseUUID"></param>
    ''' <returns></returns>
    Function GetSlotList(WarehouseUUID As String) As List(Of clsEntity)





    ''' <summary>
    ''' Создаст входящий платеж. Вернет UUID созданного обьекта
    ''' </summary>
    ''' <param name="ProjectUUID">UUID проекта (будет указан в платеже)</param>
    ''' <param name="AccepterUUID">UUID сотрудника, получившего бабосы (из справочника)</param>
    ''' <param name="AccountUUID">UUID счета из справочника Счетов</param>
    ''' <param name="CustomerUUID">UUID клиента МС</param>
    ''' <param name="Amount">размер полученной суммы</param>
    ''' <param name="CurrencyUUID">UUID валюты заказа</param>
    ''' <param name="MyCompanyUUID">UUID организации МС, на которую оформляется документ</param>
    ''' <param name="NoFeeIncluded">Платеж грязный, без учета fee</param>
    ''' <param name="Description">Комментарий</param>
    ''' <param name="paymentPurpose">Назначение платежа</param>
    Function CreateIncomingPayment(ProjectUUID As String, AccepterUUID As String, AccountUUID As String, CustomerUUID As String, Amount As String, CurrencyUUID As String, MyCompanyUUID As String, NoFeeIncluded As Boolean, paymentPurpose As String, Description As String, Optional PaymentDate? As Date = Nothing) As iMoySkladDataProvider.clsPaymentInfo


    Function GetCurrencyUUIDByName(currencyName As String) As String



    ''' <summary>
    ''' Добавит данные в отгрузки после фактической отправки
    ''' </summary>
    ''' <param name="DemandUUID">UUID обновляемой отгрузки</param>
    ''' <param name="ResultParcels">массив обьектов с данными отправки(ок) для одной отгрузки</param>
    ''' <param name="NewStateUUID">Новый статус отгрузки после выполнения функции</param>
    Function UpdateDemandsAfterShip(DemandUUID As String, ResultParcels As clsResultParcelInfo(), NewStateUUID As String) As Boolean

    ''' <summary>
    ''' Смена статуса выполнения заказа
    ''' </summary>
    Function ChangeStatusCustomerOrder(CustomerOrderUUID As String, NewStatusUUID As String) As Boolean

    ''' <summary>
    ''' Смена статуса отгрузки
    ''' </summary>
    Function ChangeStatusDemand(DemandUUID As String, NewStatusUUID As String) As Boolean

    ''' <summary>
    ''' Получить данные по посылкам для отправке просматривая отгрузки со статусом НА ОТПРАВКУ. Только если привязан заказ клиента. Товары беруться из заказа и исключаются указанные в ExcludeGoodsUUID
    ''' </summary>
    ''' <param name="StateUUID">UUID статуса отгрузок, которые будут запрошены</param>
    ''' <param name="ExcludeGoodsUUID">UUID товаров, для которых не будет добавлена информация (типа шиппинг от клиента)</param>
    ''' <param name="WokerUUID">для сотрудника (может быть пусто)</param>
    Function GetParcelsInfoForShip(StateUUID As String, Optional ExcludeGoodsUUID As String() = Nothing, Optional WokerUUID As String = Nothing) As clsParcelInfo()

    ''' <summary>
    ''' Данные из справочника Шиппинговые компании (UUID,Value)
    ''' </summary>
    Function GetShippingCompanies() As System.Collections.Generic.Dictionary(Of String, String)

    ''' <summary>
    ''' получит код склада для товара
    ''' </summary>
    ''' <param name="GoodUUID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetWarehouse(GoodUUID As String) As iMoySkladDataProvider.clsEntity

    ''' <summary>
    ''' получить список значений пользовательского справочника
    ''' </summary>
    ''' <param name="name"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetUserEntityListByName(name As String) As List(Of iMoySkladDataProvider.clsEntity)

    ''' <summary>
    ''' список компаний
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetCompanyList() As List(Of iMoySkladDataProvider.clsEntity)

    ''' <summary>
    ''' список названий складов с учетом ACL
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetWarehouseList() As List(Of Service.iMoySkladDataProvider.clsEntity)

    ''' <summary>
    ''' список групп товаров МС
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetGroupList() As List(Of Service.iMoySkladDataProvider.clsEntity)

    ''' <summary>
    ''' Получить клиентов (с емайл)
    ''' </summary>
    Function GetClients(Optional reload As Boolean = False) As Service.iMoySkladDataProvider.clsClientInfo()

    ''' <summary>
    ''' Свяжет документы вместе
    ''' </summary>
    ''' <param name="CustomerOrderUUID">заказ клиента</param>
    ''' <param name="DemandUUID">отгрузка</param>
    ''' <param name="PaymentInUUID">входящий платеж</param>
    Function LinkOrderDemandPaymentIn(CustomerOrderUUID As String, DemandUUID As String, PaymentInUUID As String) As Boolean

    ''' <summary>
    ''' Добавить в отгрузку данные для отправки посылки
    ''' </summary>
    ''' <param name="DemandUUID">Отгрузка</param>
    ''' <param name="WokerUUID">Сотрудник, кому поручена отправка</param>
    ''' <param name="ShippingCompanyUUID">UUID шиппинговой компании</param>
    ''' <param name="DeclarationContent">текст декларации CN22-CN23 или 'нет'</param>
    Function AddParcelInfoToDemand(DemandUUID As String, WokerUUID As String, ShippingCompanyUUID As String, DeclarationContent As clsDeclaration_CP71_CN23) As Boolean

    ''' <summary>
    ''' добавить товар в МС. Вернет clsPosition или nothing
    ''' </summary>
    ''' <param name="code"></param>
    ''' <param name="name"></param>
    ''' <param name="price"></param>
    ''' <param name="currency"></param>
    ''' <param name="IsArticul"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function AddGood(code As String, name As String, price As Decimal, currency As String, Optional IsArticul As Boolean = False) As iMoySkladDataProvider.clsPosition

    ''' <summary>
    ''' Перезагрузит сущности с сервера
    ''' </summary>
    Sub ReloadEntities()























End Interface
