Imports System.Globalization
Imports nopTypes.Nop.Plugin.Misc.panoRazziRestService
Imports System.Xml.Serialization
Imports System.Net
Imports System.IO
Imports System.Drawing

Public Class clsExternalData
    Private oName As LangObject
    Private oLocality As LangObject
    Private oShotDescription As LangObject
    Private oFullDescription As LangObject
    Private oPreselectedAttributes As clsSAObjectCollection
    Private oxslTemplateCollection As List(Of clsxslTemplate)
    Private oResourceCulture As CultureInfo


    ''' <summary>
    ''' вернет цифровую клавиатуру
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property GetDigiKey As Object
        Get
            Static _fm As PriceCalculator.spDigitalBoard
            'формат вызова GetDigiKeyBoardForm.connect(Me.tbPin(TextBoxBase), 0, "Ok")
            '"Ok"- надпись на кнопке
            If _fm Is Nothing Then
                _fm = New PriceCalculator.spDigitalBoard
            End If
            If _fm.OkKayTextNotStandart Then
                _fm = New PriceCalculator.spDigitalBoard
            End If
            Return _fm
            'использование в событии mouseClick ЭУ
            'Dim _tb As TextBoxBase = Me.mycontrol
            '_tb.Text = ""
            'GetDigiKey.connect(_tb)
        End Get
    End Property

    Public Class SendParameters
        Public Property ClientRole As String
        Public Property ShopName As String
        Public Property Amount As Decimal
        Public Property Currency As String
        Public Property ItemTitle As String
        Public Property ItemCondition As String
    End Class

    Public Class clsxslTemplate
        Public Property Culture As CultureInfo
        Public Property Name As String
        Public Property Body As String

        Public Overrides Function ToString() As String
            Return Name
        End Function
    End Class
    Dim oStatus As List(Of RequestStatus)
    Dim oSendParameter As SendParameters()
    Dim ofolderAsShotCode As Boolean
    Dim oserverAgentName As String
    Dim oRateDelegate As Func(Of String, Decimal)

    ''' <summary>
    ''' задаст расположение образца
    ''' </summary>
    ''' <value></value>
    ''' <remarks></remarks>
    Public WriteOnly Property WarehouseString As String
        Set(value As String)
            'установить ID склада
            Dim _wareName = value.Split("->").FirstOrDefault
            Dim _wareID As Integer = 0
            If String.IsNullOrEmpty(_wareName) Then
                _wareID = 0
            End If
            If _wareName.ToLower.Contains("внутренний питер") Then
                _wareID = 1
            End If
            If _wareName.Contains("внутренний нарва") Then
                _wareID = 2
            End If
            If _wareName.Contains("лавка") Then
                _wareID = 3
            End If
            oDocument.SimpleObjects.WarehouseID = _wareID
        End Set
    End Property
    ''' <summary>
    ''' проверка, установлен ли склад
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property WarehouseIsSet As Boolean
        Get
            If oDocument.SimpleObjects.WarehouseID > 0 Then Return True
            Return False
        End Get
    End Property

    ''' <summary>
    ''' название товара в порядке культуры
    ''' </summary>
    ''' <value></value>
    ''' <remarks></remarks>
    Public WriteOnly Property Name As String()
        Set(value As String())
            If value Is Nothing Then Return
            If value.Count = 0 Then Return
            If String.IsNullOrEmpty(value(0)) Then Return

            For i = 0 To value.Length - 1
                oName.AddItem(oLangMapList(i), value(i))
            Next
        End Set
    End Property
    ''' <summary>
    ''' местонахождения в порядке культуры
    ''' </summary>
    ''' <value></value>
    ''' <remarks></remarks>
    Public WriteOnly Property Locality As String()
        Set(value As String())
            If value Is Nothing Then Return
            If value.Count = 0 Then Return
            If String.IsNullOrEmpty(value(0)) Then Return

            For i = 0 To value.Length - 1
                oLocality.AddItem(oLangMapList(i), value(i))
            Next
        End Set
    End Property




    ''' <summary>
    ''' короткое описание в порядке культуры
    ''' </summary>
    ''' <value></value>
    ''' <remarks></remarks>
    Public WriteOnly Property ShotDescription As String()
        Set(value As String())
            If value Is Nothing Then Return
            If value.Count = 0 Then Return
            If String.IsNullOrEmpty(value(0)) Then Return
            For i = 0 To value.Length - 1
                oShotDescription.AddItem(oLangMapList(i), value(i))
            Next
        End Set
    End Property
    ''' <summary>
    ''' длинное описание в порядке культуры
    ''' </summary>
    ''' <value></value>
    ''' <remarks></remarks>
    Public WriteOnly Property FullDescription As String()
        Set(value As String())

            If value Is Nothing Then Return
            If value.Count = 0 Then Return
            If String.IsNullOrEmpty(value(0)) Then Return


            For i = 0 To value.Length - 1
                oFullDescription.AddItem(oLangMapList(i), value(i))
            Next
        End Set
    End Property

    Public Sub New(ShotCode As String)
        oShotCode = ShotCode
        oxslTemplateCollection = New List(Of clsxslTemplate)
        oLangMapList = {lng.enUS, lng.ruRU}
        oInterLang = lng.enUS
        oPreselectedAttributes = clsSAObjectCollection.CreateInstance("Attributes")
        oFullDescription = LangObject.CreateInstance("FullDescription")
        oLocality = LangObject.CreateInstance("Localities")
        oName = LangObject.CreateInstance("Names")
        oShotDescription = LangObject.CreateInstance("ShortDescriptions")
        oStatus = New List(Of RequestStatus)
    End Sub
    ''' <summary>
    ''' очистить список шаблонов
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ClearXsltTemplates()
        oxslTemplateCollection.Clear()
        oService.xsltTemplates = oxslTemplateCollection
    End Sub
    ''' <summary>
    ''' добавить шаблон
    ''' </summary>
    ''' <param name="name"></param>
    ''' <param name="body"></param>
    ''' <param name="culture"></param>
    ''' <remarks></remarks>
    Public Sub AddXsltTemplate(name As String, body As String, culture As CultureInfo)
        Dim _new = New clsxslTemplate With {.Name = name, .Body = body, .Culture = culture}
        oxslTemplateCollection.Add(_new)
        oService.xsltTemplates = oxslTemplateCollection
    End Sub






    ''' <summary>
    ''' одно значение(мультиязычное) атрибута AttributeName(invariant название) , языковые значения Value указать в порядке культуры
    ''' </summary>
    ''' <param name="AttributeName"></param>
    ''' <remarks></remarks>
    Public Sub AddProductSpecificAttribute(AttributeName As String, Value As String(), Optional CustomText As String = "")
        'в атрибуты
        If Value Is Nothing Then Return
        If Value.Count = 0 Then Return
        If String.IsNullOrEmpty(Value(0)) Then Return

        Dim _attrName = LangObject.CreateInstance("Attributes", AttributeName)

        Dim _attribute As clsSAObject
        _attribute = clsSAObject.CreateInstance(_attrName)
        If CustomText = "" Then
            With _attribute
                .AllowFiltering = True
                .ShowOnProductPage = True
                .ValueType = clsSAObject.emAttributeType.Option
                .CustomValue = ""
            End With
        Else
            With _attribute
                .AllowFiltering = False
                .ShowOnProductPage = True
                .ValueType = clsSAObject.emAttributeType.CustomText
                .CustomValue = CustomText
            End With
        End If
        'If oPreselectedAttributes.Contains(_attrName) Then
        '    _attribute = oPreselectedAttributes.GetItem(_attrName)
        'Else

        'End If

        Dim _base = LangObject.CreateInstance("AttributeValue")
        For i = 0 To Value.Length - 1
            _base.AddItem(oLangMapList(i), Value(i))
        Next
        Dim _value = _attribute.AddValue(_base)
        _attribute.Value = _value
        'надо найти значения по всем добавленым
        Dim _found As Boolean = False
        For Each t As clsSAObject In oPreselectedAttributes
            If t.Value.Equals(_attribute.Value) Then
                _found = True
            End If
        Next
        If Not _found Then
            oPreselectedAttributes.Add(_attribute)
        End If

        'пример
        ' ''' <summary>
        ' ''' значение атрибута "Геологический возраст (период)" в порядке культуры
        ' ''' </summary>
        ' ''' <value></value>
        ' ''' <remarks></remarks>
        'Public WriteOnly Property TimeScale() As String()
        '    Set(value As String())
        '        AddProductSpecificAttribute("Геологический возраст (период)", value)
        '    End Set
        'End Property

    End Sub





    ''' <summary>
    ''' В очередности как будут добавлятся значения, по умолчанию  {en-US, ru-RU}
    ''' </summary>
    ''' <value></value>
    ''' <remarks></remarks>
    Public WriteOnly Property CultureCollection As CultureInfo()
        Set(value As CultureInfo())
            If value Is Nothing Then Return
            oLangMapList = (value.Select(Function(x) LangObject.GetLangByCulture(x))).ToArray
        End Set
    End Property

    Private oInterLang As lng
    Private oLangMapList As lng()

    ''' <summary>
    ''' Основная культура сайта
    ''' </summary>
    ''' <value></value>
    ''' <remarks></remarks>
    Public WriteOnly Property ResourceCulture As CultureInfo
        Set(value As CultureInfo)
            oResourceCulture = value
            oInterLang = LangObject.GetLangByCulture(value)
        End Set
    End Property

    ''' <summary>
    ''' версия обработчика
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property Version As String
        Get
            Return "1.00"
        End Get
    End Property

    ''' <summary>
    ''' номер образца
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property ShotCode As String
        Get
            Return oShotCode
        End Get
    End Property


    Private oShotCode As String

   

    Private Sub New()
    End Sub

    Private oDocument As clsDocumentObject
    Private oService As clsDocumentService

    Friend ReadOnly Property Document As clsDocumentObject
        Get
            Return oDocument
        End Get
    End Property

    ''' <summary>
    ''' очистка обьектов до состояния полученных данных
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Clear()
        oDocument = clsDocumentObject.CreateInstance(oService)

        oxslTemplateCollection = New List(Of clsxslTemplate)
        oLangMapList = {lng.enUS, lng.ruRU}
        oInterLang = lng.enUS
        oPreselectedAttributes = clsSAObjectCollection.CreateInstance("Attributes")
        oFullDescription = LangObject.CreateInstance("FullDescription")
        oLocality = LangObject.CreateInstance("Localities")
        oName = LangObject.CreateInstance("Names")
        oShotDescription = LangObject.CreateInstance("ShortDescriptions")
        oStatus = New List(Of RequestStatus)

        ClearXsltTemplates()
        oService.Pictures = New clsPicturesObjectCollection
    End Sub


    ''' <summary>
    '''1. инициализует обьект 2. dataRequest=true = запрашивает списки данных с сервера
    ''' </summary>
    ''' <param name="datarequest"></param>
    ''' <remarks></remarks>
    Public Sub Init(dataRequest As Boolean)
        oService = CreateService(dataRequest)
        'очистка автоматом
        oDocument = clsDocumentObject.CreateInstance(oService)
    End Sub




    ''' <summary>
    ''' 3. Применить записанные в свойства значения значения
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ApplyValues()

        With oDocument
            '----names
            For Each n In oName.ItemLangObj
                .Names(n.lang) = n.Value
            Next
            '----full description---
            .AddFullDescription(oFullDescription)
            '---shot description
            .AddShotDescription(oShotDescription)
            '---locality
            If Not String.IsNullOrEmpty(oLocality.InvariantValue) Then
                .SelectedLocalities.Add(oLocality)
            End If

            '---выбранные атрибуты
            .SelectedSpecificAttributes = oPreselectedAttributes
            '---основной язык---
            .DefaultLang = LangObject.GetLangByCulture(oResourceCulture)

            'обьекты языковых вкладок
            For Each ln In oLangMapList
                .GetDescriptionObject(ln)
            Next
        End With

    End Sub

    Private Function GetLangFromString(lang As String) As lng
        Select Case lang
            Case "ru-RU"
                Return lng.ruRU
            Case "en-US"
                Return lng.enUS
            Case Else
                MsgBox(String.Format("Язык {0} не определен в приложении, будет использован en-US", lang), vbInformation)
                Return lng.enUS
        End Select
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="value"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function SplitSizeString(value As String) As Decimal()
        Dim _v = value.Replace("см", "").Replace("cm", "").Replace(",", Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator).Replace(".", Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator)
        Dim _arr = _v.Split("x")
        Dim _d = _arr.Select(Function(x) Decimal.Parse(x))
        Return _d.ToArray
    End Function

    ''' <summary>
    ''' меняет текущее описание
    ''' </summary>
    ''' <param name="enVersion"></param>
    ''' <param name="ruVersion"></param>
    ''' <remarks></remarks>
    Public Sub ChangeFullDescription(enVersion As String, ruVersion As String)
        Me.oDocument.FullDescriptions(lng.ruRU) = ruVersion
        Me.oDocument.FullDescriptions(lng.enUS) = enVersion
    End Sub


    ''' <summary>
    ''' XMLmap() содержит карту xml образца {ru,en} FullHtml {ru,en}
    ''' </summary>
    ''' <param name="XMLmap"></param>
    ''' <param name="XMLdescription"></param>
    ''' <remarks></remarks>
    Public Sub TrilboneParcer(XMLmap() As XDocument, XMLdescription As XElement, FullHtml() As String)

        '===================================
        'предопределенные роли клиентов  и магазинов задаются в uc_ACL.vb процедура init, строка 46

        'правило добавления шаблонов
        '.AddXsltTemplate("шаблон1", "<p>тело шаблона</p>", clsApplicationTypes.RussianCulture)
        '.AddXsltTemplate("template1", "<p>template body</p>", clsApplicationTypes.EnglishCulture)

        'правило добавления атрибута
        '.AddProductSpecificAttribute("атрибут", {"значение атрибута", "attribute value"})

        'курсы сайта устанавливаются вручную в свойстве clsTierPriceCollection.Rates
        '====================================



        Me.CultureCollection = {CultureInfo.CreateSpecificCulture("ru-RU"), CultureInfo.CreateSpecificCulture("en-US")}
        Me.ResourceCulture = CultureInfo.CreateSpecificCulture("ru-RU")

        Dim _ru As String = ""
        Dim _en As String = ""
        Dim _RUelem As XElement
        Dim _ENelem As XElement
        Dim _elem As IEnumerable(Of XElement)

        'Вес образца
        _ru = ""
        _en = ""
        _elem = XMLmap(0)...<ELEMENT>.Where(Function(x) x.@name = "WEIGHT")
        If Not _elem Is Nothing Then
            If _elem.Count = 0 Then
                MsgBox("Забыли указать вес. Запустите форму заново после исправления или проигнорируйте это сообщение", vbInformation)
                GoTo nx1
            Else
                _ru = _elem.FirstOrDefault.FirstNode.ToString
            End If
        End If
        _elem = XMLmap(1)...<ELEMENT>.Where(Function(x) x.@name = "WEIGHT")
        If _elem.Count = 0 Then
            MsgBox("Забыли указать вес. Запустите форму заново после исправления или проигнорируйте это сообщение", vbInformation)
        Else
            _en = _elem.FirstOrDefault.FirstNode.ToString
        End If
        If Not (String.IsNullOrEmpty(_ru) Or String.IsNullOrEmpty(_en)) Then
            Dim _v = checkarr({_ru, _en})
            Me.AddProductSpecificAttribute("Вес образца", _v, _en)
            Me.Document.SimpleObjects.Weight = Decimal.Parse(_v(0).Replace("kg", "").Replace("кг", "").Replace(",", Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator).Replace(".", Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator).Trim)
        End If

nx1:
        'Размеры образца
        _ru = ""
        _en = ""
        _elem = XMLmap(0)...<ELEMENT>.Where(Function(x) x.@name = "MATRIXSIZE")
        If Not _elem Is Nothing AndAlso Not _elem.FirstOrDefault Is Nothing Then
            _ru = _elem.FirstOrDefault.FirstNode.ToString
        End If
        _elem = XMLmap(1)...<ELEMENT>.Where(Function(x) x.@name = "MATRIXSIZE")
        If Not _elem Is Nothing AndAlso Not _elem.FirstOrDefault Is Nothing Then
            _en = _elem.FirstOrDefault.FirstNode.ToString
        End If
        If Not (String.IsNullOrEmpty(_ru) Or String.IsNullOrEmpty(_en)) Then
            Me.AddProductSpecificAttribute("Размеры образца", checkarr({_ru, _en}), _en)
            Dim _arr = Me.SplitSizeString(_en)
            Select Case _arr.Length
                Case 1
                    Me.Document.SimpleObjects.Length = _arr(0) / 100
                Case 2
                    Me.Document.SimpleObjects.Length = _arr(0) / 100
                    Me.Document.SimpleObjects.Width = _arr(1) / 100
                Case 3
                    Me.Document.SimpleObjects.Length = _arr(0) / 100
                    Me.Document.SimpleObjects.Width = _arr(1) / 100
                    Me.Document.SimpleObjects.Height = _arr(2) / 100
            End Select
        End If


        'размеры фоссилии
        _ru = ""
        _en = ""
        _elem = XMLmap(0)...<ELEMENT>.Where(Function(x) x.@name = "FOSSILSIZE")
        If Not _elem Is Nothing AndAlso Not _elem.FirstOrDefault Is Nothing Then
            _ru = _elem.FirstOrDefault.FirstNode.ToString
        End If
        _elem = XMLmap(1)...<ELEMENT>.Where(Function(x) x.@name = "FOSSILSIZE")
        If Not _elem Is Nothing AndAlso Not _elem.FirstOrDefault Is Nothing Then
            _en = _elem.FirstOrDefault.FirstNode.ToString
        End If
        If Not (String.IsNullOrEmpty(_ru) Or String.IsNullOrEmpty(_en)) Then
            Me.AddProductSpecificAttribute("Размеры", checkarr({_ru, _en}), _en)
        End If

        'основное название
        _ru = ""
        _en = ""
        _elem = XMLmap(0)...<ELEMENT>.Where(Function(x) x.@name = "NAME")
        If Not _elem Is Nothing AndAlso Not _elem.FirstOrDefault Is Nothing Then
            _ru = _elem.FirstOrDefault.FirstNode.ToString
        End If
        _elem = XMLmap(1)...<ELEMENT>.Where(Function(x) x.@name = "NAME")
        If Not _elem Is Nothing AndAlso Not _elem.FirstOrDefault Is Nothing Then
            _en = _elem.FirstOrDefault.FirstNode.ToString
        End If
        If Not (String.IsNullOrEmpty(_ru) Or String.IsNullOrEmpty(_en)) Then
            Me.Name = checkarr({_ru, _en})
        Else
            'берем названия из систематики
            _ru = ""
            _en = ""
            _elem = XMLdescription...<ELEMENT>.Where(Function(x) x.@name.ToLower = "systematica")
            If _elem.Count > 0 Then
                _ru = _elem.FirstOrDefault(Function(x) x.@lang = "ru-RU")...<NODE>.Last.FirstNode.ToString.Trim
                _en = _elem.FirstOrDefault(Function(x) x.@lang = "en-US")...<NODE>.Last.FirstNode.ToString.Trim
                Me.Name = checkarr({_ru, _en})
            End If
        End If

        'shot descriptions - из описаний!!!
        _ru = ""
        _en = ""
        _elem = XMLdescription...<ELEMENT>.Where(Function(x) x.@name.ToLower = "systematica")
        If _elem.Count > 0 Then
            _ru = _elem.FirstOrDefault(Function(x) x.@lang = "ru-RU")...<DESCRIPTION>.Value
            _en = _elem.FirstOrDefault(Function(x) x.@lang = "en-US")...<DESCRIPTION>.Value
            If Not (String.IsNullOrEmpty(_ru) Or String.IsNullOrEmpty(_en)) Then
                Me.ShotDescription = {_ru, _en}
            End If
        End If

        '.FullDescription
        Me.FullDescription = checkarr(FullHtml)

        'шаблоны xslt
        If oService.xsltTemplates.Count = 0 Then
            ''оставить оригинал для выбора
            Me.AddXsltTemplate("оригиналRU", Me.oFullDescription.langValue(lng.ruRU), CultureInfo.CreateSpecificCulture("ru-RU"))
            Me.AddXsltTemplate("оригиналEN", Me.oFullDescription.langValue(lng.enUS), CultureInfo.CreateSpecificCulture("en-US"))
            'карты образцов для шаблонов
            Me.AddXsltTemplate("оригиналXML", XMLmap(0).ToString, CultureInfo.CreateSpecificCulture("ru-RU"))
            Me.AddXsltTemplate("оригиналXML", XMLmap(1).ToString, CultureInfo.CreateSpecificCulture("en-US"))
        End If

        'картинки, вынутые с карты XML
        ''ЗАМЕНА HASH в функциях GetURIRootByIdContent и containsDir класса clsFtpConnection
        'основана на стандартной хеш функции clsSampleNumber.EAN13.GetHashCode
        'производится в свойстве Pictures
        _elem = XMLmap(0)...<ELEMENT>.Where(Function(x) x.@name = "NUMBER")
        Dim _ean = XMLmap(0).Element("CATALOGSAMPLE").@bar
        Dim _shot = _elem.FirstOrDefault.FirstNode.ToString
        Dim _image = (XMLmap(0)...<IMAGE>.Select(Function(x) x.@src)).ToArray
        Me.Pictures(_ean, _shot) = _image

        'Номер SKU
        Me.Document.SimpleObjects.SKU = _shot.Trim


        '================
        'АТРИБУТЫ

        'Классификация
        _ru = ""
        _en = ""
        _elem = XMLdescription...<ELEMENT>.Where(Function(x) x.@name.ToLower = "systematica")
        If _elem.Count > 0 Then
            _ru = _elem.Where(Function(x) x.@lang = "ru-RU").Select(Function(x) ParseNodeXML(x, "->", False)).FirstOrDefault
            _en = _elem.Where(Function(x) x.@lang = "en-US").Select(Function(x) ParseNodeXML(x, "->", False)).FirstOrDefault
            Me.AddProductSpecificAttribute("Классификация", checkarr({_ru, _en}), _en)
        End If

        ''Геологический возраст (период)
        '_ru = ""
        '_en = ""
        '_elem = XMLdescription...<ELEMENT>.Where(Function(x) x.@name = "TimeScale")
        'If _elem.Count > 0 Then
        '    _RUelem = _elem.FirstOrDefault(Function(x) x.@lang = "ru-RU")
        '    _ENelem = _elem.FirstOrDefault(Function(x) x.@lang = "en-US")
        '    If Not _RUelem Is Nothing Then
        '        _ru = _RUelem...<NODE>.FirstOrDefault.FirstNode.ToString
        '    End If
        '    If Not _ENelem Is Nothing Then
        '        _en = _ENelem...<NODE>.FirstOrDefault.FirstNode.ToString
        '    End If
        '    If Not (_RUelem Is Nothing Or _ENelem Is Nothing) Then
        '        Me.AddProductSpecificAttribute("Геологический возраст (период)", checkarr({_ru, _en}))
        '    End If
        'End If


        'Геологический ярус (ICS)
        _ru = ""
        _en = ""
        _elem = XMLdescription...<ELEMENT>.Where(Function(x) x.@name.ToLower = "stratigraphy" Or x.@name.ToLower = "timescale")
        If _elem.Count > 0 Then
            _RUelem = _elem.FirstOrDefault(Function(x) x.@lang = "ru-RU")...<NODE>.Where(Function(x) ContainsWord(x.FirstNode.ToString, {"stage", "ярус", "век"})).FirstOrDefault
            _ENelem = _elem.FirstOrDefault(Function(x) x.@lang = "en-US")...<NODE>.Where(Function(x) ContainsWord(x.FirstNode.ToString, {"stage", "ярус", "век"})).FirstOrDefault
            If Not _RUelem Is Nothing Then
                _ru = RemoveWord(_RUelem.FirstNode.ToString, {"stage", "ярус", "век"})
            End If
            If Not _ENelem Is Nothing Then
                _en = RemoveWord(_ENelem.FirstNode.ToString, {"stage", "ярус", "век"})
            End If
            Me.AddProductSpecificAttribute("Геологический ярус (ICS)", checkarr({_ru, _en}))

            'Биостратиграфическая зона (местная)
            _ru = ""
            _en = ""
            _RUelem = _elem.FirstOrDefault(Function(x) x.@lang = "ru-RU")...<NODE>.Where(Function(x) ContainsWord(x.FirstNode.ToString, {"zone", "зона"})).FirstOrDefault
            _ENelem = _elem.FirstOrDefault(Function(x) x.@lang = "en-US")...<NODE>.Where(Function(x) ContainsWord(x.FirstNode.ToString, {"zone", "зона"})).FirstOrDefault
            If Not _RUelem Is Nothing Then
                _ru = RemoveWord(_RUelem.FirstNode.ToString, {"zone", "зона"})
            End If
            If Not _ENelem Is Nothing Then
                _en = RemoveWord(_ENelem.FirstNode.ToString, {"zone", "зона"})
            End If
            If Not (String.IsNullOrEmpty(_ru) Or String.IsNullOrEmpty(_en)) Then
                Me.AddProductSpecificAttribute("Биостратиграфическая зона (местная)", checkarr({_ru, _en}))
            Else
                'зон нет, пробуем горизонт "lade", "горизонт", "horizone"
                _ru = ""
                _en = ""
                _RUelem = _elem.FirstOrDefault(Function(x) x.@lang = "ru-RU")...<NODE>.Where(Function(x) ContainsWord(x.FirstNode.ToString, {"lade", "горизонт", "horizone"})).FirstOrDefault
                _ENelem = _elem.FirstOrDefault(Function(x) x.@lang = "en-US")...<NODE>.Where(Function(x) ContainsWord(x.FirstNode.ToString, {"lade", "горизонт", "horizone"})).FirstOrDefault
                If Not _RUelem Is Nothing Then
                    _ru = RemoveWord(_RUelem.FirstNode.ToString, {"lade", "горизонт", "horizone"})
                End If
                If Not _ENelem Is Nothing Then
                    _en = RemoveWord(_ENelem.FirstNode.ToString, {"lade", "горизонт", "horizone"})
                End If
                Me.AddProductSpecificAttribute("Биостратиграфическая зона (местная)", checkarr({_ru, _en}))
            End If
        End If




        'свита (формация)
        _ru = ""
        _en = ""
        _elem = XMLdescription...<ELEMENT>.Where(Function(x) x.@name.ToLower = "formations" Or x.@name.ToLower = "geology" Or x.@name.ToLower = "litology")
        If _elem.Count > 0 Then
            _RUelem = _elem.FirstOrDefault(Function(x) x.@lang = "ru-RU")...<NODE>.Where(Function(x) ContainsWord(x.FirstNode.ToString, {"fm.", "свита", "формация", "form."})).FirstOrDefault
            _ENelem = _elem.FirstOrDefault(Function(x) x.@lang = "en-US")...<NODE>.Where(Function(x) ContainsWord(x.FirstNode.ToString, {"fm.", "свита", "формация", "form."})).FirstOrDefault
            If Not _RUelem Is Nothing Then
                _ru = RemoveWord(_RUelem.FirstNode.ToString, {"fm.", "свита", "формация", "form."})
            End If
            If Not _ENelem Is Nothing Then
                _en = RemoveWord(_ENelem.FirstNode.ToString, {"fm.", "свита", "формация", "form."})
            End If
            Me.AddProductSpecificAttribute("Свита (формация)", checkarr({_ru, _en}))
        End If


        'Семейство (палеонтологич.) и другие классификации
        _ru = ""
        _en = ""
        _elem = XMLdescription...<ELEMENT>.Where(Function(x) x.@name.ToLower = "systematica")
      
        Dim _ruLocalElem As XElement
        _RUelem = Nothing
        'фильтр элементов для исключения двойного количества
        'для всех указанных животных добавляем атрибуты
        For Each em In _elem.Where(Function(x) x.@lang = "en-US")
            _ruLocalElem = _elem.FirstOrDefault(Function(x) x.@lang = "ru-RU" And x.@id = em.@id)
            If Not _ruLocalElem Is Nothing Then
                _RUelem = _ruLocalElem...<NODE>.Where(Function(x) ContainsWord(x.FirstNode.ToString, {"family", "семейство"})).FirstOrDefault
            End If
            _ENelem = em...<NODE>.Where(Function(x) ContainsWord(x.FirstNode.ToString, {"family", "семейство"})).FirstOrDefault
            If Not _RUelem Is Nothing Then
                _ru = RemoveWord(_RUelem.FirstNode.ToString, {"family", "семейство"})
            End If
            If Not _ENelem Is Nothing Then
                _en = RemoveWord(_ENelem.FirstNode.ToString, {"family", "семейство"})
            End If
            If Not (String.IsNullOrEmpty(_ru) Or String.IsNullOrEmpty(_en)) Then
                Me.AddProductSpecificAttribute("Семейство (палеонтологич.)", checkarr({_ru, _en}))
            Else
                'пробуем отряд
                If Not _ruLocalElem Is Nothing Then
                    _RUelem = _ruLocalElem...<NODE>.Where(Function(x) ContainsWord(x.FirstNode.ToString, {"Order", "отряд"})).FirstOrDefault
                End If
                _ENelem = em...<NODE>.Where(Function(x) ContainsWord(x.FirstNode.ToString, {"Order", "отряд"})).FirstOrDefault
                If Not _RUelem Is Nothing Then
                    _ru = RemoveWord(_RUelem.FirstNode.ToString, {"Order", "отряд"})
                End If
                If Not _ENelem Is Nothing Then
                    _en = RemoveWord(_ENelem.FirstNode.ToString, {"Order", "отряд"})
                End If
                If Not (String.IsNullOrEmpty(_ru) Or String.IsNullOrEmpty(_en)) Then
                    Me.AddProductSpecificAttribute("Отряд (палеонтологич.)", checkarr({_ru, _en}))
                Else
                    'пробуем класс
                    If Not _ruLocalElem Is Nothing Then
                        _RUelem = _ruLocalElem...<NODE>.Where(Function(x) ContainsWord(x.FirstNode.ToString, {"Class", "класс"})).FirstOrDefault
                    End If
                    _ENelem = em...<NODE>.Where(Function(x) ContainsWord(x.FirstNode.ToString, {"Class", "класс"})).FirstOrDefault
                    If Not _RUelem Is Nothing Then
                        _ru = RemoveWord(_RUelem.FirstNode.ToString, {"Class", "класс"})
                    End If
                    If Not _ENelem Is Nothing Then
                        _en = RemoveWord(_ENelem.FirstNode.ToString, {"Class", "класс"})
                    End If
                    If Not (String.IsNullOrEmpty(_ru) Or String.IsNullOrEmpty(_en)) Then
                        Me.AddProductSpecificAttribute("Класс (палеонтологич.)", checkarr({_ru, _en}))
                    Else
                        'пробуем группу
                        If Not _ruLocalElem Is Nothing Then
                            _RUelem = _ruLocalElem...<NODE>.Where(Function(x) ContainsWord(x.FirstNode.ToString, {"Group", "группа"})).FirstOrDefault
                        End If
                        _ENelem = em...<NODE>.Where(Function(x) ContainsWord(x.FirstNode.ToString, {"Group", "группа"})).FirstOrDefault
                        If Not _RUelem Is Nothing Then
                            _ru = RemoveWord(_RUelem.FirstNode.ToString, {"Group", "группа"})
                        End If
                        If Not _ENelem Is Nothing Then
                            _en = RemoveWord(_ENelem.FirstNode.ToString, {"Group", "группа"})
                        End If
                        If Not (String.IsNullOrEmpty(_ru) Or String.IsNullOrEmpty(_en)) Then
                            Me.AddProductSpecificAttribute("Группа", checkarr({_ru, _en}))
                        Else
                            'пробует тип
                            If Not _ruLocalElem Is Nothing Then
                                _RUelem = _ruLocalElem...<NODE>.Where(Function(x) ContainsWord(x.FirstNode.ToString, {"phylum", "тип"})).FirstOrDefault
                            End If
                            _ENelem = em...<NODE>.Where(Function(x) ContainsWord(x.FirstNode.ToString, {"phylum", "тип"})).FirstOrDefault
                            If Not _RUelem Is Nothing Then
                                _ru = RemoveWord(_RUelem.FirstNode.ToString, {"phylum", "тип"})
                            End If
                            If Not _ENelem Is Nothing Then
                                _en = RemoveWord(_ENelem.FirstNode.ToString, {"phylum", "тип"})
                            End If
                            If Not (String.IsNullOrEmpty(_ru) Or String.IsNullOrEmpty(_en)) Then
                                Me.AddProductSpecificAttribute("Тип (палеонтологич.)", checkarr({_ru, _en}))
                            End If
                        End If
                    End If
                End If
            End If
        Next

        'locality
        _ru = ""
        _en = ""
        _elem = XMLdescription...<ELEMENT>.Where(Function(x) x.@name.ToLower = "locality" Or x.@name.ToLower = "localities")
        If _elem.Count = 0 Then
            MsgBox("Местонахождение отсутствует в описании, не забудте добавить на сайте или исправте данные образца!", vbInformation)
        Else
            _RUelem = _elem.Where(Function(x) x.@lang = "ru-RU").FirstOrDefault
            _ENelem = _elem.Where(Function(x) x.@lang = "en-US").FirstOrDefault
            If Not _RUelem Is Nothing Then
                _ru = ParseNodeXML(_RUelem, ",", False).Trim
            End If
            If Not _ENelem Is Nothing Then
                _en = ParseNodeXML(_ENelem, ",", False).Trim
            End If

            ' _en = _elem.Where(Function(x) x.@lang = "en-US").Select(Function(x) ParseNodeXML(x, ",", False)).FirstOrDefault.Trim
            Me.Locality = checkarr({_ru, _en})
        End If



    End Sub

    Private Shared Function ReplaceXMLSym(frase As String) As String
        If String.IsNullOrEmpty(frase) Then Return ""
        'ищем спец символы и удаляем их
        Dim _sym = {"&amp;", "&lt;", "&gt;", "&nbsp;", "&sect;", "&copy;", "&reg;", "&deg;", "&laquo;", "&raquo;", "&middot;", "&trade;", "&plusmn;"}
        Dim _replace = {"&", "<", ">", " ", " ", " ", " ", " ", "<<", ">>", ".", " ", " "}
        For i = 0 To _sym.Length - 1
            If frase.Contains(_sym(i)) Then
                frase = frase.Replace(_sym(i), _replace(i))
            End If
        Next
        Return frase
    End Function

    Private Function checkarr(arr As String()) As String()
        If String.IsNullOrEmpty(arr(0)) Then
            arr(0) = arr(1)
        End If
        If String.IsNullOrEmpty(arr(1)) Then
            arr(1) = arr(0)
        End If
        arr(0) = ReplaceXMLSym(arr(0))
        arr(1) = ReplaceXMLSym(arr(1))
        Return arr
    End Function

    Private Shared Function RemoveWord(frase As String, word() As String) As String
        If String.IsNullOrEmpty(frase) Then Return frase
        If word Is Nothing Then Return frase
        If word.Length = 0 Then Return frase

        For Each w In word
            frase = frase.Replace(w.ToLower, "")
            frase = frase.Replace(w, "")
        Next

        Return frase.Trim
    End Function

    Private Shared Function ContainsWord(frase As String, word() As String) As Boolean
        If String.IsNullOrEmpty(frase) Then Return False
        If word Is Nothing Then Return False
        If word.Length = 0 Then Return False

        Dim _wrarr = frase.Split(" ")
        Dim _result As New List(Of String)
        For Each t In word
            _result.AddRange(_wrarr.Where(Function(x) x.ToLower.Trim.Equals(t.ToLower.Trim)))
        Next
        If _result.Count > 0 Then Return True
        Return False
    End Function

    Private Shared Function ParseNodeXML(xml As XElement, Optional separator As String = " -> ", Optional includeRootName As Boolean = True) As String
        If xml Is Nothing Then Return ""
        Dim _out As New List(Of String)
        For Each nd In xml...<NODE>
            If Not nd.FirstNode Is Nothing Then
                _out.Add(nd.FirstNode.ToString)
            End If
        Next
        If includeRootName Then
            'добавит имя дерева в строку узла описания
            Return xml.Attribute("root").Value & ": " & String.Join(separator, _out)
        Else
            Return String.Join(separator, _out)
        End If

    End Function

    ''' <summary>
    ''' вернет новый ЭУ
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetUserControl() As uc_nopGood
        Dim _uc = New uc_nopGood()
        _uc.init(Me, Me.oResourceCulture)
        Return _uc
    End Function

    ''' <summary>
    ''' xml товара
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetXML() As String
        Return oDocument.GetXML
    End Function

    Private obaseURL As String
    Private oapiToken As String
    ''' <summary>
    ''' показывает текущий сервер
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property ServerURI As String
        Get
            Return obaseURL
        End Get
    End Property
    ''' <summary>
    ''' имя текущего сервера как в файле агента
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property ServerAgentName As String
        Get
            Return oserverAgentName
        End Get
    End Property

    ''' <summary>
    ''' 0. Сначала надо задать адрес сервера
    ''' </summary>
    ''' <param name="baseURL"></param>
    ''' <param name="apiToken"></param>
    ''' <remarks></remarks>
    Public Sub initREST(serverAgentName As String, baseURL As String, apiToken As String, FolderAsShotCode As Boolean)
        'http://localhost:15536/Api/
        oserverAgentName = serverAgentName
        obaseURL = baseURL
        '9b050043-df42-dd25-e6bc-f54967eb4278
        oapiToken = apiToken
        RequestStatus.ApiToken = apiToken
        RequestStatus.BaseURI = baseURL
        Me.ofolderAsShotCode = FolderAsShotCode
    End Sub

    Private Function RequestValues(serviceName As String, Optional ParamName As String = "", Optional ParamValue As String = "") As clsLangObjectCollection
        Try
            Dim mySerializer As XmlSerializer = New XmlSerializer(GetType(clsLangObjectCollection))
            Dim _obj As clsLangObjectCollection = Nothing
            Dim _baseURL = obaseURL & serviceName & "?apiToken=" & oapiToken

            If Not ParamName = "" Then
                _baseURL = String.Format("{0}&{1}={2}", _baseURL, ParamName, ParamValue)
            End If

            Dim wrGETURL As WebRequest
            wrGETURL = WebRequest.Create(_baseURL)
            Dim objStream As Stream
            Dim _response = wrGETURL.GetResponse()


            objStream = _response.GetResponseStream()
            Dim objReader As New StreamReader(objStream)
            Dim sLine As String = objReader.ReadToEnd

            Dim _answer = XElement.Parse(sLine)
            Dim _reader = _answer.CreateReader
            Try
                _obj = mySerializer.Deserialize(_reader)
                _obj.SetCollectionNameByFirstItem()
                oCurrentRequest.RequestStatus = WebExceptionStatus.Success
                oCurrentRequest.ResponseMessage = "Success"
                Return _obj
            Catch ex As System.InvalidOperationException
                oCurrentRequest.RequestStatus = WebExceptionStatus.ReceiveFailure
                oCurrentRequest.ResponseMessage = "We're sorry, an internal error occurred. От сервера не получен обьект, а получено сообщение о ошибке"
                Return clsLangObjectCollection.CreateInstance("Empty")
            End Try


        Catch ex As WebException
            oCurrentRequest.ResponseMessage = ex.Message
            oCurrentRequest.RequestStatus = ex.Status
            Return clsLangObjectCollection.CreateInstance(serviceName)
        End Try
    End Function
    ''' <summary>
    ''' статус веб запросов
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property WebStatus As List(Of RequestStatus)
        Get
            Return oStatus
        End Get
    End Property


    Public Class RequestStatus
        Public Shared Property BaseURI As String
        Public Shared Property ApiToken As String



        ''' <summary>
        ''' имя запрашиваемого ресурса
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ServiceName As String
        ''' <summary>
        ''' статус запроса
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property RequestStatus As System.Net.WebExceptionStatus
        ''' <summary>
        ''' Сообщение сервера
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ResponseMessage As String
        ''' <summary>
        ''' данные в ответе
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property AnswerXMLData As String
        ''' <summary>
        ''' кол-во обьектов, принятых с сервера
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ObjectCount As Integer

        ''' <summary>
        ''' коллекция возвращенных сервером инвариантных значений обьектов
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property InvariantValuesCollection As List(Of String)

        Public Overrides Function ToString() As String
            Return String.Format("{0}: {1} ({2})", ServiceName, ResponseMessage, ObjectCount)
            Return MyBase.ToString()
        End Function
    End Class

    Private oCurrentRequest As RequestStatus

    ''' <summary>
    ''' создает сервисный обьект, либо с пустыми полями, либо запрашивая данные с сервера
    ''' </summary>
    ''' <param name="dataRequest"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CreateService(dataRequest As Boolean) As clsDocumentService

        If Not dataRequest Then

            If oService Is Nothing Then
                MsgBox("Данные с сервера не запрошены по требованию", vbInformation)
                Return New clsDocumentService(Attributes:=Nothing, Categories:=Nothing, CustomerRoles:=Nothing, Localities:=Nothing, SiteBaseCurrency:=Nothing, Stores:=Nothing, _ProductTag:=Nothing)
            Else
                'MsgBox("Используются кешированные данные", vbInformation)
                Return oService
            End If

        End If

        If Me.oapiToken = "" Or Me.obaseURL = "" Then
            MsgBox("Для запроса данных c сервера необходимо вызвать метод initREST перед вызовом init", vbCritical)
            Return New clsDocumentService(Attributes:=Nothing, Categories:=Nothing, CustomerRoles:=Nothing, Localities:=Nothing, SiteBaseCurrency:=Nothing, Stores:=Nothing, _ProductTag:=Nothing)
        End If

        'тут запрос к сервису
        '=======================
        Dim _serviceName As String
        Dim _obj As clsLangObjectCollection

        _serviceName = "GetStores"
        oCurrentRequest = New RequestStatus
        oCurrentRequest.ServiceName = _serviceName
        _obj = RequestValues(_serviceName)
        Dim _shops As clsStoresCollection = clsStoresCollection.CreateInstance(_obj)
        _shops.Sort()
        oCurrentRequest.AnswerXMLData = _obj.GetXML("Stores", "Store", "StoreValue", True)
        oCurrentRequest.ObjectCount = _obj.Count
        oCurrentRequest.InvariantValuesCollection = _obj.GetLangValues(lng.invariant)
        Me.oStatus.Add(oCurrentRequest)

        _serviceName = "GetRoles"
        oCurrentRequest = New RequestStatus
        oCurrentRequest.ServiceName = _serviceName
        _obj = RequestValues(_serviceName)
        Dim _clients = clsCustomerRolesCollection.CreateInstance(_obj)
        _clients.Sort()
        oCurrentRequest.AnswerXMLData = _obj.GetXML("Roles", "Role", "RoleValue", True)
        oCurrentRequest.ObjectCount = _obj.Count
        oCurrentRequest.InvariantValuesCollection = _obj.GetLangValues(lng.invariant)
        Me.oStatus.Add(oCurrentRequest)

        _serviceName = "GetCategories"
        oCurrentRequest = New RequestStatus
        oCurrentRequest.ServiceName = _serviceName
        _obj = RequestValues(_serviceName)
        Dim _categories = clsCategoriesObjectCollection.CreateInstance(_obj)
        _categories.Sort()
        oCurrentRequest.AnswerXMLData = _obj.GetXML("Categories", "Category", "CategoryValue", True)
        oCurrentRequest.ObjectCount = _obj.Count
        oCurrentRequest.InvariantValuesCollection = _obj.GetLangValues(lng.invariant)
        Me.oStatus.Add(oCurrentRequest)

        _serviceName = "GetManufacturers"
        oCurrentRequest = New RequestStatus
        oCurrentRequest.ServiceName = _serviceName
        _obj = RequestValues(_serviceName)
        Dim _localities = clsManufacturersObjectCollection.CreateInstance(_obj)
        _localities.Sort()
        oCurrentRequest.AnswerXMLData = _obj.GetXML("Localities", "Locality", "LocalityValue", True)
        oCurrentRequest.ObjectCount = _obj.Count
        oCurrentRequest.InvariantValuesCollection = _obj.GetLangValues(lng.invariant)
        Me.oStatus.Add(oCurrentRequest)

        _serviceName = "GetProductTags"
        oCurrentRequest = New RequestStatus
        oCurrentRequest.ServiceName = _serviceName
        _obj = RequestValues(_serviceName)
        Dim _tags = clsLangObjectCollection.CreateInstance("ProductTag")
        _tags.AddRange(_obj)
        _tags.Sort()
        oCurrentRequest.AnswerXMLData = _obj.GetXML("ProductTags", "ProductTag", "TagValue", True)
        oCurrentRequest.ObjectCount = _obj.Count
        oCurrentRequest.InvariantValuesCollection = _obj.GetLangValues(lng.invariant)
        Me.oStatus.Add(oCurrentRequest)


        'атрибуты
        Dim _AttrValColl As New Dictionary(Of LangObject, IEnumerable(Of LangObject))
        _serviceName = "GetSpecificAttributes"
        oCurrentRequest = New RequestStatus
        oCurrentRequest.ServiceName = _serviceName
        _obj = RequestValues(_serviceName)
        Dim _attributes = clsLangObjectCollection.CreateInstance("Attributes")
        _attributes.AddRange(_obj)
        _attributes.Sort()
        oCurrentRequest.AnswerXMLData = _obj.GetXML("ProductSpecificationAttributes", "ProductSpecificationAttribute", "AttributeValue", True)
        oCurrentRequest.ObjectCount = _obj.Count
        oCurrentRequest.InvariantValuesCollection = _obj.GetLangValues(lng.invariant)
        Me.oStatus.Add(oCurrentRequest)

        'значения атрибутов
        _serviceName = "GetSpecificAttributeOptions"
        If _attributes.Count = 0 Then
            oCurrentRequest = New RequestStatus
            oCurrentRequest.ServiceName = _serviceName
            oCurrentRequest.ResponseMessage = "attributes count is 0"
            oCurrentRequest.RequestStatus = WebExceptionStatus.SendFailure
            oCurrentRequest.AnswerXMLData = ""
            oCurrentRequest.ObjectCount = 0
        End If
        For Each t In _attributes
            oCurrentRequest = New RequestStatus
            oCurrentRequest.ServiceName = _serviceName
            _obj = RequestValues(_serviceName, "SpecifAttributeID", t.ObjectId)
            If Not _obj Is Nothing Then
                _obj.Sort()
                _AttrValColl.Add(t, _obj)
            End If
            oCurrentRequest.AnswerXMLData = _obj.GetXML("ProductSpecificationAttributeOptions", "ProductSpecificationAttributeOption", "OptionValue", True)
            oCurrentRequest.ObjectCount = _obj.Count
            oCurrentRequest.InvariantValuesCollection = _obj.GetLangValues(lng.invariant)
            Me.oStatus.Add(oCurrentRequest)
        Next


        '-----------------------
        '========================
        Dim _SiteBaseCurrency As clsTierPricesCollection.emCurrency = clsTierPricesCollection.emCurrency.RUR
        '================

        Dim _service As New clsDocumentService(Attributes:=_AttrValColl, Categories:=_categories, CustomerRoles:=_clients, Localities:=_localities, SiteBaseCurrency:=_SiteBaseCurrency, Stores:=_shops, _ProductTag:=_tags)

        Return _service
    End Function


    ''' <summary>
    ''' картинки в формате {имя файла}
    ''' </summary>
    ''' <value></value>
    ''' <remarks></remarks>
    Public WriteOnly Property Pictures(EAN13 As String, ShotCode As String) As String()
        Set(value As String())
            If value Is Nothing Then Return
            If value.Count = 0 Then Return
            If String.IsNullOrEmpty(value(0)) Then Return
            'определить папку
            Dim _folder As String = Math.Abs(EAN13.GetHashCode)
            If ofolderAsShotCode Then
                _folder = ShotCode
            End If
            '----pictures---------------
            Dim _pc = clsPicturesObjectCollection.CreateInstance
            Dim _index As Integer = 0
            For Each p In value
                Dim _seoName = "Picture" & (New Random("63")).Next.ToString
                Dim _base = LangObject.CreateInstance("Picture", _seoName)
                'это seo названия картинок???
                _base.AddItem(lng.ruRU, _seoName)
                _base.AddItem(lng.enUS, _seoName)
                _base.DisplayOrder = _index
                _index += 1
                Dim _pi As clsPictureObject = clsPictureObject.CreateInstance(_base)
                With _pi
                    'определить путь
                    .PicturePath = IO.Path.Combine(_folder.Trim, p)
                    .PictureURI = ""
                End With
                _pc.Add(_pi)
            Next
            '---------------
            oService.Pictures = _pc
        End Set
    End Property
    ''' <summary>
    ''' снимает с продажи (отменяет публикацию или удаляет)
    ''' </summary>
    ''' <param name="SKU"></param>
    ''' <param name="serviceName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function RemoveProduct(RequestURI As String, apiToken As String, SKU As String, Optional serviceName As String = "DeleteProduct", Optional ByRef serverMessage As String = "") As HttpStatusCode
        'StopProduct(string apiToken, string SKU)
        Dim _baseURL = RequestURI & serviceName & "?apiToken=" & apiToken & "&SKU=" & SKU
        Dim request As HttpWebRequest = DirectCast(HttpWebRequest.Create(_baseURL), HttpWebRequest)
        request.Method = "PUT"
        request.ContentType = "text/xml"
        request.ContentLength = 0
        'добавить ошибку подключения
        Dim _reqst As New RequestStatus
        _reqst.ServiceName = serviceName
        Dim response As HttpWebResponse
        Try
            response = DirectCast(request.GetResponse(), HttpWebResponse)
            _reqst.ResponseMessage = response.StatusDescription
            _reqst.RequestStatus = WebExceptionStatus.Success
        Catch ex As WebException
            _reqst.ResponseMessage = ex.Message
            _reqst.RequestStatus = ex.Status
            serverMessage = ex.Message
            Return ex.Status
        End Try
        Select Case response.StatusCode
            Case HttpStatusCode.OK
                serverMessage = response.StatusDescription '' "Образец удален с сайта"
            Case Else
                Dim returnString As String = response.StatusCode.ToString()
                serverMessage = "Проблема при передаче данных на сервер: " & returnString

        End Select
        Return response.StatusCode

    End Function


    ''' <summary>
    ''' поместит на сервер
    ''' </summary>
    ''' <param name="serviceName"></param>
    ''' <remarks></remarks>
    Public Function PutProduct(Optional serviceName As String = "PutProduct", Optional ByRef serverMessage As String = "") As HttpStatusCode
        oStatus.Clear()
        'тут проходит валидация
        Dim xml As String = oDocument.GetXML
        If xml.Contains("error") Then
            'ошибки в листинге
            oStatus.Add(New RequestStatus With {.ResponseMessage = "", .RequestStatus = WebExceptionStatus.SendFailure, .AnswerXMLData = xml})
            serverMessage = "Ошибка проверки листинга. Исправте ошибки и выставите заново."
            Return HttpStatusCode.Forbidden
        End If

        Try
            My.Computer.Clipboard.Clear()
            My.Computer.Clipboard.SetText(xml)
        Catch ex As Exception
            MsgBox("Ошибка при помещении данных в буфер обмена.", vbCritical)
        End Try

        Select Case MsgBox("Послать данные на сервер?", vbYesNo)
            Case MsgBoxResult.No
                oStatus.Add(New RequestStatus With {.ResponseMessage = "", .RequestStatus = WebExceptionStatus.SendFailure, .AnswerXMLData = xml})
                serverMessage = "Отмена выставления пользователем."
                Return HttpStatusCode.Forbidden
        End Select



        Dim arr As Byte() = System.Text.Encoding.UTF8.GetBytes(xml)

        Dim _baseURL = obaseURL & serviceName & "?apiToken=" & oapiToken

        Dim request As HttpWebRequest = DirectCast(HttpWebRequest.Create(_baseURL), HttpWebRequest)
        request.Method = "PUT"
        request.ContentType = "text/xml"
        request.ContentLength = arr.Length
        'добавить ошибку подключения
        Dim _st As New RequestStatus
        _st.ServiceName = serviceName
        Dim response As HttpWebResponse
        Try
            Dim dataStream As Stream = request.GetRequestStream()
            dataStream.Write(arr, 0, arr.Length)
            dataStream.Close()
            response = DirectCast(request.GetResponse(), HttpWebResponse)
            _st.ResponseMessage = response.StatusDescription
            _st.RequestStatus = WebExceptionStatus.Success
            oStatus.Add(_st)
        Catch ex As WebException
            Dim _response = DirectCast(ex.Response, HttpWebResponse)
            If Not _response Is Nothing Then
                _st.ResponseMessage = _response.StatusDescription
                _st.RequestStatus = _response.StatusCode
                serverMessage = _response.StatusDescription
                oStatus.Add(_st)
            Else
                _st.ResponseMessage = ex.Message
                _st.RequestStatus = ex.Status
                serverMessage = ex.Message
                oStatus.Add(_st)
            End If

            Return ex.Status
        End Try

        Select Case response.StatusCode
            Case HttpStatusCode.OK
                serverMessage = "Образец помещен на сервер"
                'тут наполним обьект параметров выставления
                Dim _list As New List(Of SendParameters)
                For Each t In oDocument.CreatedTierPrices
                    Dim _to = t.CustomerRolesACL.InvariantValue
                    Dim _shop = t.StoresACL.InvariantValue
                    Dim _amount = t.PriceInCurrency
                    'Не правильно записывается валюта???
                    Dim _currency = t.CurrencyString
                    _list.Add(New SendParameters With {.ClientRole = _to, .ShopName = _shop, .Amount = _amount, .Currency = _currency, .ItemTitle = oDocument.Names(lng.invariant), .ItemCondition = oDocument.ShortDescriptions(lng.invariant)})
                Next
                oSendParameter = _list.ToArray
            Case Else
                Dim returnString As String = response.StatusCode.ToString()
                serverMessage = "Проблема при передаче данных на сервер: " & returnString

        End Select
        Return response.StatusCode
    End Function

    ''' <summary>
    ''' поле с данными выставления
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property SendParameterCollection As SendParameters()
        Get
            Return oSendParameter
        End Get
    End Property

    ''' <summary>
    ''' делегат курсов валют
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property RateDelagate As Func(Of String, Decimal)
        Get
            Return oRateDelegate
        End Get
        Set(value As Func(Of String, Decimal))
            'курсы сайта устанавливаются вручную в свойстве clsTierPriceCollection.Rates
            oRateDelegate = value
            If Not Me.oDocument Is Nothing Then
                Me.oDocument.RateDelagate = oRateDelegate
            End If
        End Set
    End Property
End Class
