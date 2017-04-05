Imports System.Windows.Forms
Imports System.Drawing
Imports System.Linq
Public Class clsSellInfo
    Inherits List(Of clsSellInfoItem)
    Implements IEqualityComparer(Of clsSellInfoItem)


    Public Class clsSellInfoItem
        Implements IComparable

        Dim oCurrency As String

        Public Overrides Function Equals(obj As Object) As Boolean
            If Not TypeOf (obj) Is clsSellInfoItem Then Return False
            Dim _to = CType(obj, clsSellInfoItem)

            If Not Me.SampleNumber.Equals(_to.SampleNumber) Then Return False

            If Not Me.FossilSize = _to.FossilSize Then Return False

            If Not Me.IsSold = _to.IsSold Then Return False

            If Not Me.SellDate.ToShortDateString.Equals(_to.SellDate.ToShortDateString) Then Return False

            Return True

            '  Return MyBase.Equals(obj)
        End Function

        Public Overrides Function GetHashCode() As Integer
            Return Me.SampleNumber.GetHashCode Xor Me.FossilSize.GetHashCode Xor Me.IsSold.GetHashCode Xor Me.SellDate.ToShortDateString.GetHashCode ' Xor MyBase.GetHashCode()
        End Function

        Property ClientName As String

        Property SellDate As Date

        Property FossilSize As Decimal

        Property Price As Decimal

        Property Currency As String
            Get
                If oCurrency Is Nothing Then oCurrency = ""
                If String.IsNullOrEmpty(oCurrency.Trim) Then oCurrency = "USD"
                Return oCurrency.ToUpper
            End Get
            Set(value As String)
                oCurrency = value
            End Set
        End Property

        Property IsSold As Boolean

        Property SampleNumber As String

        ReadOnly Property ShotNumber As String
            Get
                Dim _code = clsApplicationTypes.clsSampleNumber.CreateFromString(Me.SampleNumber)
                If _code.CodeIsCorrect Then Return _code.ShotCode
                Return SampleNumber
            End Get
        End Property

        Private oAmountString As String
        ReadOnly Property AmountString As String
            Get
                If String.IsNullOrEmpty(oAmountString) Then
                    oAmountString = String.Format("{0}{1}", Decimal.Ceiling(Me.Price), clsApplicationTypes.GetCurrencySymbol(Me.Currency))
                End If
                Return oAmountString
            End Get
        End Property

        Public Sub SetAmountString(value As String)
            oAmountString = value
        End Sub



        Public ReadOnly Property DateString As String
            Get
                Return Me.SellDate.ToShortDateString
            End Get
        End Property

        Public ReadOnly Property SizeString As String
            Get
                If Me.FossilSize > 0 Then
                    Return Me.FossilSize.ToString & "см"
                Else
                    Return ""
                End If
            End Get
        End Property

        Public Overrides Function ToString() As String
            Dim _out As String = String.Format("{3}: {0}  {1}  {2}", Me.DateString, Me.SizeString, Me.AmountString, If(Me.IsSold, "да", "нет"))
            Return _out
        End Function

        Public Function CompareTo(obj As Object) As Integer Implements IComparable.CompareTo
            If Not TypeOf obj Is clsSellInfoItem Then Return 0
            Dim _to = CType(obj, clsSellInfoItem)


            Dim _fn = Function() As Integer
                          'If _to.Price = Me.Price Then
                          '    If _to.FossilSize = Me.FossilSize Then
                          '        Return _to.SellDate.ToShortDateString.CompareTo(Me.SellDate.ToShortDateString)
                          '    Else
                          '        Return Me.FossilSize.CompareTo(_to.FossilSize)
                          '    End If

                          'Else
                          '    Return _to.Price.CompareTo(Me.Price)
                          'End If
                          If _to.FossilSize = Me.FossilSize Then
                              Return _to.SellDate.ToShortDateString.CompareTo(Me.SellDate.ToShortDateString)
                          Else
                              Return Me.FossilSize.CompareTo(_to.FossilSize)
                          End If

                      End Function


            If Me.IsSold Then
                If _to.IsSold Then
                    'оба проданы
                    Return _fn()
                Else
                    Return -1
                End If
            End If


            If _to.IsSold Then Return 1


            'оба не проданы
            Return _fn()

        End Function
    End Class


    Public Function GetMenuItems() As System.Windows.Forms.ToolStripMenuItem()
        Dim _item As System.Windows.Forms.ToolStripMenuItem
        Dim _ili As New List(Of System.Windows.Forms.ToolStripMenuItem)
        _item = New System.Windows.Forms.ToolStripMenuItem
        With _item
            .Name = "caption"
            .Size = New Size(155, 22)
            .Text = String.Format("{0}: {1}{2}{3} найдено: {4}шт", Me.opartname, If(String.IsNullOrEmpty(Me.oclientName), "", " для " & Me.oclientName), If(Me.ominsize = 0, "", "c " & Me.ominsize & "см"), If(Me.ominsize = 0, "", "до " & Me.ominsize & "см"), Me.Count)
            .AutoSize = True
            .ForeColor = Color.YellowGreen
        End With
        _ili.Add(_item)

        For Each t In Me
            _item = New System.Windows.Forms.ToolStripMenuItem()
            With _item
                .Name = t.SampleNumber & t.SellDate.Day & t.SellDate.Year
                .Size = New Size(155, 22)
                .Text = t.ToString
                .AutoSize = True
                .Tag = t
                If t.IsSold Then
                    .ForeColor = Color.Green
                Else
                    .ForeColor = System.Drawing.Color.Red
                End If

                If t.SampleNumber.Contains("eBay") Then
                    .BackColor = Color.LightYellow
                End If

                Dim _nitm As New System.Windows.Forms.ToolStripMenuItem
                With _nitm
                    .Name = t.SampleNumber & t.SellDate.Day & t.SellDate.Year & "_1"
                    .AutoSize = True
                    .Size = New Size(155, 22)
                    .Text = String.Format("{0}{1}", t.ShotNumber, If(String.IsNullOrEmpty(t.ClientName), "", " " & t.ClientName))
                    .Tag = clsApplicationTypes.clsSampleNumber.CreateFromString(t.ShotNumber)
                    AddHandler .MouseEnter, AddressOf submenuItemMouseEnter
                    'вызов формы фото
                    AddHandler .MouseDown, AddressOf subImagemenuItemMouseDown
                End With
                .DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {_nitm})
            End With
            _ili.Add(_item)
        Next
        Return _ili.ToArray
    End Function

    Private opartname As String
    Private oclientName As String
    Private omaxsize As Decimal
    Private ominsize As Decimal
    Private oReadySampleDBContext As Service.DBREADYSAMPLEEntities

    Public Shared Function GetStatisticByEbay(partname As String) As clsSellInfo

        Dim _out As New clsSellInfo

        Dim _wordIds = (From c In _out.oReadySampleDBContext.tbActualWord
                     Where c.Word.Contains(partname)
                     Select c.Id).ToList

        Dim _result = (From c In _out.oReadySampleDBContext.tbWordHistory
                    From d In _wordIds
                    Where c.WordID = d
                    Select c).ToList
        Dim _rs = From c In _result Select c.GetAsTrilbone

        Dim _coll = From c In _rs Select New clsSellInfoItem With {.SampleNumber = "eBay " & c.itemId, .Price = c.currentPrice, .Currency = c.currencyId, .FossilSize = 0, .IsSold = c.IsSold, .SellDate = If(c.IsSold, c.TimeMark, c.startTime), .ClientName = "eBay"}

        _out.AddRange(_coll.ToList)
        Return Optimize(_out)
    End Function

    ''' <summary>
    ''' вернет пустую клетку
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetNullPattern() As ToolStripMenuItem
        Dim _nitm As New System.Windows.Forms.ToolStripMenuItem
        With _nitm
            .Name = "No_Pattern"
            .AutoSize = True
            .Size = New Size(155, 22)
            .Text = "Нет строки для поиска"
        End With
        Return _nitm
    End Function

    ''' <summary>
    ''' вернет пустую клетку
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetNullStatistic() As ToolStripMenuItem
        Dim _nitm As New System.Windows.Forms.ToolStripMenuItem
        With _nitm
            .Name = "No_Statistic"
            .AutoSize = True
            .Size = New Size(155, 22)
            .Text = "Нет статистики для запрошенной фразы"

        End With
        Return _nitm
    End Function
    ''' <summary>
    ''' получить статистику
    ''' </summary>
    ''' <param name="partname"></param>
    ''' <param name="clientName"></param>
    ''' <param name="Size"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Shared Function GetStatistic(partname As String, Optional clientName As String = "", Optional Size As Decimal = 0) As clsSellInfo

        Dim _out As New clsSellInfo
        Dim _maxsize As Decimal = 0
        Dim _minsize As Decimal = 0
        If Size > 0 Then
            _maxsize = Size + Decimal.Ceiling(Size * 0.1 * 10) / 10
            _minsize = Size - Decimal.Ceiling(Size * 0.1 * 10) / 10
            _out.AddRange((From c In GetStatistic(partname, clientName, _maxsize, _minsize) Where c.FossilSize <= _maxsize And c.FossilSize >= _minsize).Distinct)
        Else
            _out = GetStatistic(partname, clientName, 0, 0)
        End If

        With _out

            _out.Sort()
            .opartname = partname
            .omaxsize = _maxsize
            .ominsize = _minsize
            .oclientName = clientName
        End With


        Return Optimize(_out)

    End Function

    ''' <summary>
    ''' оптимизирует последовательность статистики
    ''' </summary>
    ''' <param name="inp"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function Optimize(inp As clsSellInfo) As clsSellInfo
        Dim _out As New clsSellInfo
        'теперь урезать диапазоны для одинаковых номеров
        Dim _res = From c In inp.Distinct(inp) Group gr = c By c.SampleNumber, c.IsSold Into Group
        For Each t In _res
            Dim _val = (From c In t.Group Where c.Price > 0)
            If Not _val.Count = 0 Then
                Dim _min = Aggregate c In _val Into Min(clsApplicationTypes.CurrencyConvert(c.Price, c.Currency, "USD"))
                Dim _max = Aggregate c In _val Into Max(clsApplicationTypes.CurrencyConvert(c.Price, c.Currency, "USD"))

                Dim _base = t.Group.FirstOrDefault
                _base.Currency = "USD"
                If _min = _max Then
                    _base.SetAmountString(String.Format("{2}{0}", _min, _max, clsApplicationTypes.GetCurrencySymbol("USD")))
                Else
                    _base.SetAmountString(String.Format("от {2}{0} до {2}{1} ", _min, _max, clsApplicationTypes.GetCurrencySymbol("USD")))
                End If
                _out.Add(_base)
            End If
        Next
        _out.Sort()
        Return _out
    End Function


    Public Overloads Shared Function GetStatistic(partname As String, Optional clientName As String = "", Optional AsSameSizeSampleNumber As String = Nothing) As clsSellInfo

        Dim _out As New clsSellInfo
        Dim _maxsize As Decimal = 0
        Dim _minsize As Decimal = 0
        'размер выбранной
        Dim _sm = clsApplicationTypes.clsSampleNumber.CreateFromString(AsSameSizeSampleNumber)
        Dim _smd = _sm.GetEan13
        If _sm.CodeIsCorrect Then
            Dim _sr = (From c In clsApplicationTypes.SampleDataObject.GetdbPhotoObjectContext.tb_Samples_Fossils
                                         Where c.ID_Sample_number = _smd
                                       Where c.Fossil_full_name.Contains(partname)
                                       Select c.Fossil_length, c.Fossil_width).ToList

            Dim _sizes = From c In _sr Select CType(IIf(c.Fossil_length.GetValueOrDefault > c.Fossil_width.GetValueOrDefault, c.Fossil_length.GetValueOrDefault, c.Fossil_width.GetValueOrDefault), Decimal)

            _maxsize = Aggregate c In _sizes Into Max(c)
            _minsize = Aggregate c In _sizes Into Min(c)

            _maxsize += Decimal.Ceiling(_maxsize * 0.1 * 10) / 10
            _minsize -= Decimal.Ceiling(_minsize * 0.1 * 10) / 10


            _out.AddRange((From c In GetStatistic(partname, clientName, _maxsize, _minsize) Where c.FossilSize <= _maxsize And c.FossilSize >= _minsize).Distinct)

        Else
            _out = GetStatistic(partname, clientName, 0, 0)
        End If

        With _out
            _out.Sort()
            .opartname = partname
            .omaxsize = _maxsize
            .ominsize = _minsize
            .oclientName = clientName
        End With

        Return Optimize(_out)
    End Function

    Public Overloads Shared Function GetStatistic(partname As String, Optional clientName As String = "", Optional maxsizecm As Decimal = 0, Optional minsizecm As Decimal = 0) As clsSellInfo
        Dim _out As New clsSellInfo
        Dim _clientID As Integer
        Dim _list As New List(Of clsSellInfoItem)
        Dim _list2 As New List(Of clsSellInfoItem)
        If Not String.IsNullOrEmpty(clientName) Then
            _clientID = (From c In _out.oReadySampleDBContext.Clients
                                                    Where (c.FirstName & " " & c.SecondName).Trim.ToLower.Equals(clientName)
                                                    Select c.ClientID).FirstOrDefault
        Else
            _clientID = 0
        End If



        If _clientID > 0 Then
            'запрос по клиенту
            'из новой части
            Dim _clres = (From c In _out.oReadySampleDBContext.tbSLSample
                         Where c.clientName.ToLower.Equals(clientName) And c.SLoperationID < 4
                         Select ean13 = c.SampleNumber, _
                         amount = c.amount, _
                         currency = c.currency, opdate = c.TimeMarker, sold = c.SLoperationID).ToList

            '2
            _list = (From c In _clres Select New clsSellInfo.clsSellInfoItem With {.Currency = c.currency, .IsSold = IIf(c.sold = 2, True, False), .Price = c.amount, .SampleNumber = c.ean13.GetValueOrDefault, .SellDate = c.opdate, .ClientName = clientName}).ToList
            '================
            'из каталогов
            Dim _clresOrd = (From c In _out.oReadySampleDBContext.Orders
                                             Join d In From c In _out.oReadySampleDBContext.SamplesAndOrders
                                                       On d.OrderID Equals c.OrderID
                                                       Where c.ClientID = _clientID
                                                       Select ean13 = d.SampleNumber, confamount = d.ConfirmPrice, price = d.Price, currency = d.CurrencyName, _
                                                       opdate = c.OrderDate, sold = d.ConfirmFlag, cltName = c.Clients.NickName).ToList


            _list2 = (From c In _clresOrd Select New clsSellInfo.clsSellInfoItem With {.Currency = c.currency, .IsSold = c.sold.GetValueOrDefault, .Price = IIf(c.confamount.GetValueOrDefault > 0, c.confamount.GetValueOrDefault, c.price), .SampleNumber = c.ean13, .SellDate = c.opdate, .ClientName = c.cltName}).ToList

            'из SampleOnSale
            Dim _sos = (From c In _out.oReadySampleDBContext.SamplesOnSale
                        Where (c.OnSaleFlag = False)
                        Select ean13 = c.SampleNumber, confamount = c.SoldPrice, price = c.BasePrice,
                                                       opdate = c.OnSaleDate, sold = True).ToList
            Dim _list3 = (From c In _sos Select New clsSellInfo.clsSellInfoItem With {.IsSold = True, .Price = IIf(c.confamount.GetValueOrDefault > 0, c.confamount.GetValueOrDefault, c.price), .SampleNumber = c.ean13, .SellDate = c.opdate.GetValueOrDefault, .ClientName = clientName}).ToList



            _list.AddRange(_list2)
            _list.AddRange(_list3)
        Else
            'запрос
            'из новой части
            Dim _clres = (From c In _out.oReadySampleDBContext.tbSLSample
                         Where c.SLoperationID < 4
                         Select ean13 = c.SampleNumber, _
                         amount = c.amount, _
                         currency = c.currency, opdate = c.TimeMarker, sold = c.SLoperationID, client = c.clientName).ToList

            '2
            _list = (From c In _clres Select New clsSellInfo.clsSellInfoItem With {.Currency = c.currency, .IsSold = IIf(c.sold = 2, True, False), .Price = c.amount, .SampleNumber = c.ean13.GetValueOrDefault, .SellDate = c.opdate, .ClientName = c.client}).ToList
            '================
            'из каталогов

            Dim _clresOrd = (From c In _out.oReadySampleDBContext.Orders
                            Join d In From c In _out.oReadySampleDBContext.SamplesAndOrders
                                      On d.OrderID Equals c.OrderID
                                      Select ean13 = d.SampleNumber, confamount = d.ConfirmPrice, price = d.Price, currency = d.CurrencyName, _
                                      opdate = c.OrderDate, sold = d.ConfirmFlag, cltName = c.Clients.NickName).ToList

            _list2 = (From c In _clresOrd Select New clsSellInfo.clsSellInfoItem With {.Currency = c.currency, .IsSold = c.sold.GetValueOrDefault, .Price = IIf(c.confamount.GetValueOrDefault > 0, c.confamount.GetValueOrDefault, c.price), .SampleNumber = c.ean13, .SellDate = c.opdate, .ClientName = c.cltName}).ToList

            'из SampleOnSale
            Dim _sos = (From c In _out.oReadySampleDBContext.SamplesOnSale
                        Where (c.OnSaleFlag = False)
                        Select ean13 = c.SampleNumber, confamount = c.SoldPrice, price = c.BasePrice,
                                                       opdate = c.OnSaleDate, sold = True).ToList
            Dim _list3 = (From c In _sos Select New clsSellInfo.clsSellInfoItem With {.IsSold = True, .Price = IIf(c.confamount.GetValueOrDefault > 0, c.confamount.GetValueOrDefault, c.price), .SampleNumber = c.ean13, .SellDate = c.opdate.GetValueOrDefault, .ClientName = clientName}).ToList



            _list.AddRange(_list2)
            _list.AddRange(_list3)
        End If


        '===========================

        'запрос из бд
        Dim _result = clsApplicationTypes.SampleDataObject.GetFossilByNameList(partname)

        'готово клиентские заказы
        'теперь по номеру фильтры
        Dim _res = From c In _result.DefaultIfEmpty
                Group Join d In _list On c.SampleNumber.ToString Equals d.SampleNumber Into cr = Group
                From s In cr
                Select New clsSellInfo.clsSellInfoItem With {.SampleNumber = c.SampleNumber, .Currency = s.Currency, _
                                                                                 .FossilSize = c.Fossil_length.GetValueOrDefault, .IsSold = s.IsSold, .Price = s.Price, .SellDate = s.SellDate}

        'теперь по размеру выбранной твари фильтр
        If Not maxsizecm = 0 Then
            If Not minsizecm = 0 Then
                _res = From c In _res Where c.FossilSize <= maxsizecm And c.FossilSize >= minsizecm
            Else
                'только макс размер
                _res = From c In _res Where c.FossilSize <= maxsizecm
            End If

        ElseIf Not minsizecm = 0 Then
            'только мин размер
            _res = From c In _res Where c.FossilSize >= minsizecm
        End If


        With _out
            _out.AddRange(_res.Distinct)
            _out.Sort()
            .opartname = partname
            .omaxsize = maxsizecm
            .ominsize = minsizecm
            .oclientName = clientName
        End With
        Return Optimize(_out)
    End Function

    Private Sub submenuItemMouseEnter(sender As Object, e As EventArgs)
        Dim _nitm As System.Windows.Forms.ToolStripMenuItem = sender
        'Dim myCallback As New Image.GetThumbnailImageAbort(Function()
        '                                                       Return True
        '                                                   End Function)
        If _nitm.DropDownItems.Count > 0 Then Return

        'показать имя и фотку
        Dim _sm = clsApplicationTypes.clsSampleNumber.CreateFromString(_nitm.Text)
        Dim _img = _sm.AskImage

        Dim _newwidth = clsIDcontent.constMainImageWidth / 2
        Dim _newhight = _img.Height / (_img.Width / _newwidth)
        Dim _tb As New Bitmap(_newwidth, _newhight, System.Drawing.Imaging.PixelFormat.Format24bppRgb)
        Dim _destrect = New Rectangle(0, 0, _newwidth, _newhight)

        Using _gr = Graphics.FromImage(_tb)
            _gr.DrawImage(_img, _destrect)
        End Using


        Dim _add As New System.Windows.Forms.ToolStripMenuItem
        With _add
            .Name = "addto" & _nitm.Text
            .AutoSize = False
            .Size = New Size(_newwidth + 2, _newhight + 2)
            .ForeColor = Color.Red
            .Text = _sm.AskName
            .Font = New Font("Arial", 6)
            .BackgroundImage = _tb
            .BackgroundImageLayout = ImageLayout.Center
            .ImageKey = _img.Tag
            .ImageScaling = ToolStripItemImageScaling.None
            .TextImageRelation = TextImageRelation.Overlay
            .DisplayStyle = ToolStripItemDisplayStyle.Image
            .Tag = _sm

            AddHandler .MouseDown, AddressOf subImagemenuItemMouseDown
        End With
        _nitm.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {_add})
    End Sub
    Private Sub subImagemenuItemMouseDown(sender As Object, e As MouseEventArgs)
        'call image form
        If sender.tag Is Nothing Then Return

        Dim _sm As clsApplicationTypes.clsSampleNumber = sender.tag

        Select Case e.Button
            Case MouseButtons.Right
                Dim _fm = New Windows.Forms.Form
                Dim _uc As New Service.Uc_trilbone_history
                _fm.Size = Size.Add(New Size(_uc.Width, _uc.Height), New Size(50, 100))
                _fm.Controls.Add(_uc)
                _uc.Dock = DockStyle.Fill
                _uc.SampleNumber(True) = _sm.EAN13
                _fm.ShowDialog()
            Case MouseButtons.Left
                If e.Clicks > 1 Then
                    Dim _imgs = clsApplicationTypes.SamplePhotoObject.GetImageCollection(_sm, clsFilesSources.Arhive, False)
                    Dim _fm = clsApplicationTypes.DelegateStoreApplicationForm(clsApplicationTypes.emFormsList.fmImage).Invoke({_imgs, _sm.ShotCode})
                    If Not _fm Is Nothing Then
                        _fm.ShowDialog()
                    End If
                End If
        End Select
    End Sub



    Private Sub subImagemenuItemMouseEnter(sender As Object, e As EventArgs)
        Dim _nitm As System.Windows.Forms.ToolStripMenuItem = sender

        If _nitm.DropDownItems.Count > 0 Then Return

        'показать имя и фотку
        Dim _out As New List(Of ToolStripMenuItem)
        Dim _add As System.Windows.Forms.ToolStripMenuItem

        For Each t In clsApplicationTypes.SamplePhotoObject.GetImageCollection(_nitm.Tag, clsFilesSources.Arhive, True)
            _add = New System.Windows.Forms.ToolStripMenuItem
            With _add
                .Name = "addto" & _nitm.Text
                .AutoSize = False
                .Size = New Size(clsIDcontent.constMainImageWidth / 2, 160)
                .ForeColor = Color.Black
                '.Text = _sm.AskName
                .BackgroundImage = t
                .BackgroundImageLayout = ImageLayout.Center
                .ImageScaling = ToolStripItemImageScaling.SizeToFit
                .TextImageRelation = TextImageRelation.Overlay
                .ImageKey = .BackgroundImage.Tag
                .DisplayStyle = ToolStripItemDisplayStyle.Image
            End With
            _out.Add(_add)
        Next

        _nitm.DropDownItems.AddRange(_out.ToArray)
    End Sub


   


    Private Sub New()
        oReadySampleDBContext = clsApplicationTypes.SampleDataObject.GetdbReadySampleObjectContext
    End Sub

    ''' <summary>
    ''' сравнивает итемы
    ''' </summary>
    ''' <param name="x"></param>
    ''' <param name="y"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Equals1(x As clsSellInfoItem, y As clsSellInfoItem) As Boolean Implements IEqualityComparer(Of clsSellInfoItem).Equals
        If Not x.SampleNumber.Equals(y.SampleNumber) Then Return False

        If Not x.Price.Equals(y.Price) Then Return False

        If Not x.SellDate.Equals(y.SellDate) Then Return False

        Return True
    End Function

    Public Function GetHashCode1(obj As clsSellInfoItem) As Integer Implements IEqualityComparer(Of clsSellInfoItem).GetHashCode
        Return obj.SampleNumber.GetHashCode Xor obj.Price.GetHashCode Xor obj.SellDate.GetHashCode
    End Function
End Class
