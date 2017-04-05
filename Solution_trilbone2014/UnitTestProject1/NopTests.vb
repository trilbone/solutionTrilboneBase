Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Service
Imports nopRestClient
Imports nopTypes.Nop.Plugin.Misc.panoRazziRestService

Imports System.Windows.Forms
Imports System.Xml.Serialization
Imports System.IO

<TestClass()> Public Class NopTests
    <TestMethod()> Public Sub TestMethod_xml()
        Dim _ru As String = ""
        Dim _en As String = ""
        'Dim _ruelem As XElement
        'Dim _enelem As XElement
        Dim _elem As IEnumerable(Of XElement)

        ' _ru = _elem.Where(Function(x) x.@lang = "ru-RU").Select(Function(x) ParseNodeXML(x, ",", False)).FirstOrDefault.Trim
        ' _en = _elem.Where(Function(x) x.@lang = "en-US").Select(Function(x) ParseNodeXML(x, ",", False)).FirstOrDefault.Trim


        _elem = TrilboneXML.XMLmap...<ELEMENT>.Where(Function(x) x.@name = "WEIGHT")
        If Not _elem Is Nothing Then
            _ru = _elem.FirstOrDefault.FirstNode.ToString
        End If
        _elem = TrilboneXML.XMLmap...<ELEMENT>.Where(Function(x) x.@name = "WEIGHT")
        If Not _elem Is Nothing Then
            _en = _elem.FirstOrDefault.FirstNode.ToString
        End If


        '_ru = _elem.Where(Function(x) x.@lang = "ru-RU").Select(Function(x) ParseNodeXML(x, "->", False)).FirstOrDefault
        '_en = _elem.Where(Function(x) x.@lang = "en-US").Select(Function(x) ParseNodeXML(x, "->", False)).FirstOrDefault


        Dim _v = checkarr({_ru, _en})

        MsgBox(String.Format("RUS: {0}   ENG: {1}", _v(0), _v(1)))

    End Sub

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

    Private Shared Function ContainsWord(frase As String, word() As String) As Boolean
        Dim _wrarr = frase.Split(" ")
        Dim _result As New List(Of String)
        For Each t In word
            _result.AddRange(_wrarr.Where(Function(x) x.ToLower.Trim.Equals(t.ToLower.Trim) Or x.ToLower.Trim.StartsWith(t.ToLower.Trim)))
        Next
        If _result.Count > 0 Then Return True
        Return False
    End Function

    Public Shared Function ReplaceXMLSym(frase As String) As String
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

    Public Shared Function ParseNodeXML(xml As XElement, Optional separator As String = " -> ", Optional includeRootName As Boolean = True) As String
        If xml Is Nothing Then Return ""

        Dim _out As New List(Of String)
        For Each nd In xml...<NODE>
            Dim _str = ReplaceXMLSym(nd.FirstNode.ToString(SaveOptions.DisableFormatting).Trim)
            _out.Add(_str)
        Next
        If includeRootName Then
            'добавит имя дерева в строку узла описания
            Return xml.Attribute("root").Value & ": " & String.Join(separator, _out)
        Else
            Return String.Join(separator, _out)
        End If

    End Function

    <TestMethod()> Public Sub TestMethod_externalObj()
        Dim _obj As New clsExternalData("8-4002")

        With _obj
            .initREST("test", "http://localhost:15536/Api/", "9b050043-df42-dd25-e6bc-f54967eb4278", True)
            .Init(True)
            .TrilboneParcer(TrilboneXML.XMLmap, TrilboneXML.XMLDescription, {TrilboneXML.HTML_RU.ToString, TrilboneXML.HTML_EN.ToString})
            .ApplyValues()

            .Clear()
            .TrilboneParcer(TrilboneXML.XMLmap, TrilboneXML.XMLDescription, {TrilboneXML.HTML_RU.ToString, TrilboneXML.HTML_EN.ToString})
            .ApplyValues()
        End With
        '------------------
        Dim _data As String = _obj.GetXML
        Try
            My.Computer.Clipboard.Clear()
            My.Computer.Clipboard.SetText(_data, TextDataFormat.Text)
        Catch ex As Exception
            MsgBox("Ошибка при помещении данных в буфер обмена.", vbCritical)
        End Try
        '-----------------

    End Sub


    <TestMethod()> Public Sub TestMethod_goodFM()
        Dim _fm As New fmGood


        Dim _obj As New clsExternalData("8-4002")

        With _obj
            '.CultureCollection = {clsApplicationTypes.RussianCulture, clsApplicationTypes.EnglishCulture}
            '.Pictures = {"12345\img1.jpg", "12345\img2.jpg"}
            '.FullDescription = {"русское полное описание", "english full description"}
            '.ShotDescription = {"русское короткое описание", "english shot description"}
            '.Locality = {"вильповицы", "vilpovitsy"}
            '.Name = {"название камня", "name of stone"}
            '.ResourceCulture = clsApplicationTypes.RussianCulture
            '.AddXsltTemplate("шаблон1", "<p>тело шаблона</p>", clsApplicationTypes.RussianCulture)
            '.AddXsltTemplate("template1", "<p>template body</p>", clsApplicationTypes.EnglishCulture)
            ''оставить оригинал для выбора
            '.AddXsltTemplate("оригинал", "русское полное описание", clsApplicationTypes.RussianCulture)
            '.AddXsltTemplate("оригинал", "english full description", clsApplicationTypes.EnglishCulture)

            '.AddProductSpecificAttribute("атрибут", {"значение атрибута", "attribute value"})

            .initREST("test", "http://localhost:15536/Api/", "9b050043-df42-dd25-e6bc-f54967eb4278", True)
            .Init(True)
            .TrilboneParcer(TrilboneXML.XMLmap, TrilboneXML.XMLDescription, {TrilboneXML.HTML_RU.ToString, TrilboneXML.HTML_EN.ToString})
            .ApplyValues()
        End With

        _fm._uc.init(_obj, clsApplicationTypes.RussianCulture)

        _fm.ShowDialog()

        My.Computer.Clipboard.SetText(_fm._uc.GetXML)

        Dim _soap = New XmlSerializer(GetType(nopTypes.Nop.Plugin.Misc.panoRazziRestService.Products))
        Dim _reader As New StringReader(_fm._uc.GetXML)

        Dim _out = _soap.Deserialize(_reader)
        '  MsgBox(_fm._uc.GetXML)
        If Not _out Is Nothing Then
            _obj.PutProduct()
            'MsgBox("OK!!!!")
        End If
    End Sub


    <TestMethod()> Public Sub TestMethod_tierPricesFM()
        Dim _obj = clsTierPricesCollection.CreateInstance(clsTierPricesCollection.emCurrency.USD)
        'или так clsTierPricesCollection.BaseCurrency = clsTierPricesCollection.emCurrency.RUR
        With _obj.TierPriceStatic
            .CallForPrice = False
            .CustomerEntersPrice = False
            .MaximumCustomerEnteredPrice = 150
            .MinimumCustomerEnteredPrice = 50
        End With
        Dim _clients = clsCustomerRolesCollection.CreateInstance()
        _clients.Add("Litvinov", 1)
        _clients.Add("Pakhomov", 3)

        Dim _shops = clsStoresCollection.CreateInstance()
        _shops.Add("Site", 0)
        _shops.Add("Dealer", 4)
        Dim _fm As New fm_TierPrice
        _fm._uc.init(lng.ruRU, "RUR", _clients, _shops)
        _fm.ShowDialog()

        MsgBox(_fm._uc.GetBaseXML)
        MsgBox(_fm._uc.GetStaticXML)
    End Sub
    <TestMethod()> Public Sub TestMethod_tierPrices()
        Dim _obj = clsTierPricesCollection.CreateInstance(clsTierPricesCollection.emCurrency.USD)
        'или так clsTierPricesCollection.BaseCurrency = clsTierPricesCollection.emCurrency.RUR
        With _obj.TierPriceStatic
            .CallForPrice = False
            .CustomerEntersPrice = False
            .MaximumCustomerEnteredPrice = 150
            .MinimumCustomerEnteredPrice = 50
        End With
        Dim _clients = clsCustomerRolesCollection.CreateInstance()
        _clients.Add("Litvinov", 1)
        _clients.Add("Pakhomov", 3)

        Dim _shops = clsStoresCollection.CreateInstance()
        _shops.Add("Site", 0)
        _shops.Add("Dealer", 4)

        Dim _tier = clsTierPrice.CreateInstance(100, clsTierPricesCollection.emCurrency.RUR, _clients(0), _shops(1))
        _obj.Add(_tier)
        MsgBox(_tier.ToString)

        _tier = clsTierPrice.CreateInstance(100, clsTierPricesCollection.emCurrency.EUR, _clients(1), _shops(0))
        _obj.Add(_tier)
        MsgBox(_tier.ToString)

        MsgBox(_obj.GetXML)

    End Sub
    <TestMethod()> Public Sub TestMethod_ACLfm()
        Dim _fm As New fmACL

        Dim _clients = clsCustomerRolesCollection.CreateInstance()
        _clients.Add("Litvinov", 1)
        _clients.Add("Pakhomov", 3)

        Dim _shops = clsStoresCollection.CreateInstance()
        _shops.Add("Site", 0)
        _shops.Add("Dealer", 4)

        _fm._uc.init(lng.enUS, _clients, _shops)

        _fm.ShowDialog()

        MsgBox(_fm._uc.GetXML)
    End Sub


    <TestMethod()> Public Sub TestMethod_attributesfm()
        'еще отлаживать
        Dim _fm As New fm_attributes
        Dim _coll = Me.GetAttr("specises")
        Dim attrname = "цвет"
        Dim _attr = clsSAObject.CreateInstance(LangObject.CreateInstance(groupName:="Attributes", invariantValue:=attrname, EnValue:="color", ruValue:="цвет"))
        With _attr
            .AllowFiltering = True
            .ValueType = clsSAObject.emAttributeType.Option
            .CustomValue = ""
            .DisplayOrder = 1
            .ShowOnProductPage = True
        End With

        _coll.Add(_attr)

        _coll.AddValue(clsSAObjectValue.CreateInstance(_attr, LangObject.CreateInstance(groupName:=attrname, invariantValue:="red", EnValue:="red", ruValue:="красный")))
        _coll.AddValue(clsSAObjectValue.CreateInstance(_attr, LangObject.CreateInstance(groupName:=attrname, invariantValue:="blue", EnValue:="blue", ruValue:="синий")))

        _fm._uc.init(lng.ruRU, _coll)

        _fm.ShowDialog()

        MsgBox(_fm._uc.GetXML)
    End Sub

    Private Function GetLangObjectsatt(GroupName As String) As clsLangObjectCollection
        Dim _list = clsLangObjectCollection.CreateInstance(GroupName)

        Dim _itemlst As New List(Of LangObjItem)
        _itemlst.Add(New LangObjItem With {.lang = lng.invariant, .Value = "Вид"})
        _itemlst.Add(New LangObjItem With {.lang = lng.ruRU, .Value = "Вид"})
        _itemlst.Add(New LangObjItem With {.lang = lng.enUS, .Value = "species"})
        _list.Add(New LangObject With {.InvariantValue = "Вид", ._groupName = GroupName, .ItemLangObj = _itemlst.ToArray})

        _itemlst = New List(Of LangObjItem)
        _itemlst.Add(New LangObjItem With {.lang = lng.invariant, .Value = "Возраст"})
        _itemlst.Add(New LangObjItem With {.lang = lng.ruRU, .Value = "Возраст"})
        _itemlst.Add(New LangObjItem With {.lang = lng.enUS, .Value = "age"})
        _list.Add(New LangObject With {.InvariantValue = "Возраст", ._groupName = GroupName, .ItemLangObj = _itemlst.ToArray})
        Return _list
    End Function


    <TestMethod()> Public Sub TestMethod_mainObj()
        'Dim _data As New clsDocumentService


        'Dim _obj = clsDocumentObject.CreateInstance(_data)
        'Dim _dic = _obj.GetDescriptionObject(lng.ruRU)
        'With _dic
        '    .Names = "имя"
        '    .ShortDescriptions = "ShortDescriptions"
        '    .FullDescriptions = "FullDescriptions"
        '    .MetaDescription = "MetaDescription"
        '    .MetaTitle = "MetaTitle"
        'End With

        'MsgBox(_obj.GetXML)

    End Sub

    <TestMethod()> Public Sub TestMethod_uc_descr()
        Dim _data As New clsDocumentService(Attributes:=Nothing, Categories:=Nothing, CustomerRoles:=Nothing, Localities:=Nothing, SiteBaseCurrency:=clsTierPricesCollection.emCurrency.RUR, Stores:=Nothing, _ProductTag:=GetLangObjects("ProductTag"))
        Dim _fm As New fm_Description
        Dim _obj = clsDocumentObject.CreateInstance(_data)



        '_data.LoadTags(GetLangObjects("ProductTag"))
        '_data.LoadMetaWord(GetLangObjects("MetaKeywords"))

        _fm._uc.init(_obj.GetDescriptionObject(lng.enUS))

        '  _data.LoadxsltTemplatesToDescriptionObject(lng.ruRU, New String() {"template1", "template2"}.ToList)

        _fm.ShowDialog()

        MsgBox(_fm._uc.GetXML)

    End Sub

    Private Function GetLangObjects(GroupName As String) As clsLangObjectCollection
        Dim _list = clsLangObjectCollection.CreateInstance(GroupName)

        Dim _itemlst As New List(Of LangObjItem)
        _itemlst.Add(New LangObjItem With {.lang = lng.invariant, .Value = "asaphus"})
        _itemlst.Add(New LangObjItem With {.lang = lng.ruRU, .Value = "азафус"})
        _itemlst.Add(New LangObjItem With {.lang = lng.enUS, .Value = "asaphus"})
        _list.Add(New LangObject With {.InvariantValue = "asaphus", ._groupName = GroupName, .ItemLangObj = _itemlst.ToArray})

        _itemlst = New List(Of LangObjItem)
        _itemlst.Add(New LangObjItem With {.lang = lng.invariant, .Value = "illaenus"})
        _itemlst.Add(New LangObjItem With {.lang = lng.ruRU, .Value = "илленус"})
        _itemlst.Add(New LangObjItem With {.lang = lng.enUS, .Value = "illaenus"})
        _list.Add(New LangObject With {.InvariantValue = "illaenus", ._groupName = GroupName, .ItemLangObj = _itemlst.ToArray})
        Return _list
    End Function

    Private Function GetAttr(attrname As String) As clsSAObjectCollection
        'правильная инициализация атрибута!!!!
        Dim _obj = clsSAObjectCollection.CreateInstance()
        Dim _attr = clsSAObject.CreateInstance(LangObject.CreateInstance(groupName:="Attributes", invariantValue:=attrname, EnValue:="test attribute en", ruValue:="тестовы атрибут"))
        With _attr
            .AllowFiltering = True
            .ValueType = clsSAObject.emAttributeType.Option
            .CustomValue = ""
            .DisplayOrder = 1
            .ShowOnProductPage = True
        End With

        _obj.Add(_attr)

        _obj.AddValue(clsSAObjectValue.CreateInstance(_attr, LangObject.CreateInstance(groupName:=attrname, invariantValue:="asaphus", EnValue:="asaphus", ruValue:="азафус")))
        _obj.AddValue(clsSAObjectValue.CreateInstance(_attr, LangObject.CreateInstance(groupName:=attrname, invariantValue:="illaenus", EnValue:="illaenus", ruValue:="илленус")))

        Return _obj
    End Function

    <TestMethod()> Public Sub TestMethod_uc_lang_Attributesxml()

        Dim _coll = Me.GetAttr("specises")
        Dim attrname = "цвет"
        Dim _attr = clsSAObject.CreateInstance(LangObject.CreateInstance(groupName:="Attributes", invariantValue:=attrname, EnValue:="color", ruValue:="цвет"))
        With _attr
            .AllowFiltering = True
            .ValueType = clsSAObject.emAttributeType.Hyperlink
            .CustomValue = "илилоилотл"
            .DisplayOrder = 15
            .ShowOnProductPage = False
        End With

        _coll.Add(_attr)

        _coll.AddValue(clsSAObjectValue.CreateInstance(_attr, LangObject.CreateInstance(groupName:=attrname, invariantValue:="red", EnValue:="red", ruValue:="красный")))
        _coll.AddValue(clsSAObjectValue.CreateInstance(_attr, LangObject.CreateInstance(groupName:=attrname, invariantValue:="blue", EnValue:="blue", ruValue:="синий")))

        _coll.SelectValue(_coll(0), 0)
        _coll.SelectValue(_coll(1), 1)

        MsgBox(_coll.GetXML)
    End Sub

    <TestMethod()> Public Sub TestMethod_uc_lang_Manufacturerxml()
        Dim _list = New clsCategoriesObjectCollection

        Dim _itemlst As New List(Of LangObjItem)
        _itemlst.Add(New LangObjItem With {.lang = lng.invariant, .Value = "asaphus"})
        _itemlst.Add(New LangObjItem With {.lang = lng.ruRU, .Value = "азафус"})
        _itemlst.Add(New LangObjItem With {.lang = lng.enUS, .Value = "asaphus"})
        _list.Add(New LangObject With {.InvariantValue = "asaphus", ._groupName = "species", .ItemLangObj = _itemlst.ToArray})

        _itemlst = New List(Of LangObjItem)
        _itemlst.Add(New LangObjItem With {.lang = lng.invariant, .Value = "illaenus"})
        _itemlst.Add(New LangObjItem With {.lang = lng.ruRU, .Value = "илленус"})
        _itemlst.Add(New LangObjItem With {.lang = lng.enUS, .Value = "illaenus"})
        _list.Add(New LangObject With {.InvariantValue = "illaenus", ._groupName = "species", .ItemLangObj = _itemlst.ToArray})

        MsgBox(_list.GetXML())
    End Sub

    <TestMethod()> Public Sub TestMethod_uc_lang_objxml()
        Dim _list = clsLangObjectCollection.CreateInstance("species")

        Dim _itemlst As New List(Of LangObjItem)
        _itemlst.Add(New LangObjItem With {.lang = lng.invariant, .Value = "asaphus inv"})
        _itemlst.Add(New LangObjItem With {.lang = lng.ruRU, .Value = "азафус"})
        _itemlst.Add(New LangObjItem With {.lang = lng.enUS, .Value = "asaphus"})
        _list.Add(New LangObject With {.InvariantValue = "asaphus", ._groupName = "species", .ItemLangObj = _itemlst.ToArray})

        _itemlst = New List(Of LangObjItem)
        _itemlst.Add(New LangObjItem With {.lang = lng.invariant, .Value = "illaenus inv"})
        _itemlst.Add(New LangObjItem With {.lang = lng.ruRU, .Value = "илленус"})
        _itemlst.Add(New LangObjItem With {.lang = lng.enUS, .Value = "illaenus"})
        _list.Add(New LangObject With {.InvariantValue = "illaenus", ._groupName = "species", .ItemLangObj = _itemlst.ToArray})

        'Dim _res = _list.GetValues(lng.ruRU)
        'MsgBox(String.Format("{0} {1}", _res(0), _res(1)))
        ' MsgBox(_list.GetLangXML("word", "MetaKeywordsValue"))
        ' MsgBox(_list.GetLangXML("word", "MetaKeywordsValue"))
        ' MsgBox(_list.GetXML("ProductCategories", "AttributeName", "AttribueValue", True, True, "Option"))
    End Sub


    <TestMethod()> Public Sub TestMethod_uc_lang_objItem()
        Dim _obj As New LangObjItem
        With _obj
            .lang = lng.enUS
            .Value = "тестовое значение"
        End With

        MsgBox(_obj.GetXML("MetaTitleValue"))

    End Sub

    <TestMethod()> Public Sub TestMethod_fm_langobj()
        Dim _fm As New fm_langObj
        _fm.ShowMessages = False
        Dim _list = clsLangObjectCollection.CreateInstance("species")

        Dim _item As New List(Of LangObjItem)

        _item.Add(New LangObjItem With {.lang = lng.invariant, .Value = "asaphus"})
        _item.Add(New LangObjItem With {.lang = lng.ruRU, .Value = "азафус"})
        _item.Add(New LangObjItem With {.lang = lng.enUS, .Value = "asaphus"})
        _list.Add(New LangObject With {.InvariantValue = "asaphus", ._groupName = "species", .ItemLangObj = _item.ToArray})

        _item = New List(Of LangObjItem)
        _item.Add(New LangObjItem With {.lang = lng.invariant, .Value = "illaenus"})
        _item.Add(New LangObjItem With {.lang = lng.ruRU, .Value = "илленус"})
        _item.Add(New LangObjItem With {.lang = lng.enUS, .Value = "illaenus"})

        _list.Add(New LangObject With {.InvariantValue = "illaenus", ._groupName = "species", .ItemLangObj = _item.ToArray})

        _fm._uc.UcCaption = "Виды трилов"
        _fm._uc.init(lng.ruRU, _list)

        _fm.ShowDialog()
        MsgBox(_fm._uc.SelectedObjects.GetXML("Root", "MetaKeywordsValue", "word"))
    End Sub


    <TestMethod()> Public Sub TestMethod_uc_simple_objFM()
        Dim _fm As New fm_simleObj
        Dim _list = clsLangObjectCollection.CreateInstance("species")

        Dim _item As New List(Of LangObjItem)

        _item.Add(New LangObjItem With {.lang = lng.invariant, .Value = "asaphus"})
        _item.Add(New LangObjItem With {.lang = lng.ruRU, .Value = "азафус"})
        _item.Add(New LangObjItem With {.lang = lng.enUS, .Value = "asaphus"})
        _list.Add(New LangObject With {.InvariantValue = "asaphus", ._groupName = "species", .ItemLangObj = _item.ToArray})

        _item = New List(Of LangObjItem)
        _item.Add(New LangObjItem With {.lang = lng.invariant, .Value = "illaenus"})
        _item.Add(New LangObjItem With {.lang = lng.ruRU, .Value = "илленус"})
        _item.Add(New LangObjItem With {.lang = lng.enUS, .Value = "illaenus"})

        _list.Add(New LangObject With {.InvariantValue = "illaenus", ._groupName = "species", .ItemLangObj = _item.ToArray})

        _fm._uc.UcCaption = "Виды трилов"
        _fm._uc.Init(lng.ruRU, "species", {"знач1", "знач2"})
        ' _fm._uc.DS = _list

        _fm.ShowDialog()

        MsgBox(_fm._uc.GetXML("MetaKeywordsValue", "word"))
        MsgBox(_fm._uc.SelectedObjects.GetXML("Data", "word", "MetaKeywordsValue"))

        'If _fm._uc.SelectedObjects.Count = 0 Then Return


        'MsgBox(String.Format("кол-во {0}: первый: {1}  {2} {3}", _fm._uc.SelectedObjects.Count, _fm._uc.SelectedObjects(0).InvariantGroupName, _fm._uc.SelectedObjects(0).invariantvalue, _fm._uc.SelectedObjects(0).Item.Count))
    End Sub


    <TestMethod()> Public Sub TestMethod1()
        '        Dim _new = New clsRestMS_service
        '        Dim _in As iMoySkladDataProvider
        '        Dim _result As String = ""
        'nx:
        '        With _new
        '            _in = .GetInterface(True)
        '            If _in Is Nothing Then
        '                Threading.Thread.Sleep(10000)
        '                GoTo nx
        '            End If
        'qw:
        '            _result = ""
        '            With _in


        '_result = .SetSampleToAction("8-3919", "3915d00d-b774-11e4-7a40-e897003d709a", 599)
        '_result = .EndSampleOnAuction("8-3919", "3915d00d-b774-11e4-7a40-e897003d709a")

        '_result = .ChangeStatusCustomerOrder(CustomerOrderUUID:="641daaac-966e-11e4-90a2-8ecb00869e03", NewStatusUUID:="3ab42d81-7bd6-11e4-90a2-8ecb0016aa95")

        '----------------
        'Dim _res = clsRestMS_service.Manager.FindLocationOfGood(New MoySkladAPI.good With {.name = "Eogaudryceras duvali"}, True)

        'MsgBox(_res.Count)

        ''-------их поиск
        'Dim _message As String = ""
        'Dim _obj As IEnumerable(Of Object) = Nothing

        'Dim _res = clsRestMS_service.Manager.RequestAnyCollection(TOobjectType:=emTOMoySkladTypes.stockTO, GoodNamePart:="", StockMode:=emStockMode.POSITIVE_INCLUDING_RESERVE_ONLY, ServerMessage:=_message, goodUUID:={"805490e9-9b3a-11e3-d048-002590a28eca"}, WarehouseUUID:="", _data:=_obj, _requestbody:="")


        'If _res = Net.HttpStatusCode.OK Then

        '    Dim _list = _obj.ToList

        '    MsgBox(_list.Count)
        'Else
        '    MsgBox(_message, vbCritical)
        'End If
        '------------------
        ''со статусом
        'Dim _arr = .GetParcelsInfoForShip(StateUUID:="67ae8aa0-85f9-11e4-90a2-8ecb0010ed01", ExcludeGoodsUUID:={"93961544-968e-11e4-90a2-8ecb00887e5e"}, WokerUUID:="")

        'For Each t In _arr
        '    _result += t.ToString
        'Next

        ' _result = .ChangeStatusDemand("e4bfcaad-b9e4-11e4-7a07-673d00198709", "84e8067d-7bda-11e4-90a2-8ecb0016fb1b")

        '_result = .CreateDemand(MyCompanyUUID:="5a4ba7b2-4993-11e3-ce8c-7054d21a8d1e", CurrencyUUID:="a487d989-4c83-11e3-ce68-7054d21a8d1e", CustomerUUID:="b3bd9069-966a-11e4-90a2-8ecb00866fde", ProjectUUID:="3d8a69e9-f25d-11e3-6d72-002590a28eca", StateUUID:="67ae8aa0-85f9-11e4-90a2-8ecb0010ed01", WarehouseUUID:="82664e7f-4aea-11e3-c3f0-7054d21a8d1e", ShippingInGoodUUID:="93961544-968e-11e4-90a2-8ecb00887e5e", ShippingInAmount:=1, ShippingInQty:=1, GoodsUUIDs:={"5a5f89c1-9f0e-11e4-7a07-673d00459e98"}, GoodsAmounts:={600}, GoodsQtys:={1}, InvocePaymentTypeUUID:="b3e57635-8ebe-11e4-90a2-8ecb002d43fd", Description:="тестовое описание", PayPalStartFeeGoodUUID:="5c7004af-862a-11e4-90a2-8ecb00172e70", PayPalStartFeeAmount:=4, PayPalOutFeeGoodUUID:="cdec5275-862a-11e4-90a2-8ecb00173413", PayPalOutFeeAmount:=5, EbayFeeStartGoodUUID:="2903e205-968c-11e4-90a2-8ecb0088631c", EbayFeeStartAmount:=3, EbayFeeEndGoodUUID:="65b29f2c-862a-11e4-90a2-8ecb00172eb7", EbayFeeEndAmount:=33)
        '-----------------

        '_result = .AddParcelInfoToDemand(DemandUUID:="e4bfcaad-b9e4-11e4-7a07-673d00198709", DeclarationContent:="тестовая декларация", WokerUUID:="97c20675-db61-11e3-a884-002590a28eca", ShippingCompanyUUID:="d81e1771-db72-11e3-add2-002590a28eca")


        ''--------------
        'Dim _parcel As New iMoySkladDataProvider.ResultParcelInfo
        '_parcel.TrackNumber = "fsdnvewnee"
        '_parcel.ShippingCompanyUUID = "d81e1771-db72-11e3-add2-002590a28eca"
        '_parcel.SenderUUID = "97c20675-db61-11e3-a884-002590a28eca"
        '_parcel.HandlingAmount = 5
        '_parcel.HandlingGoodUUID = "095e1e33-8a03-11e4-90a2-8ecb00197aa6"
        '_parcel.ShippingAmount = 17
        '_parcel.ShippingGoodUUID = "16841c4b-1f0e-11e4-beb8-002590a28eca"
        ''464ceb8a-489e-11e3-c722-7054d21a8d1e = eur
        ''a487d989-4c83-11e3-ce68-7054d21a8d1e = usd
        '_parcel.ShippingAndHandlingCurrencyUUID = "464ceb8a-489e-11e3-c722-7054d21a8d1e"
        '_parcel.PackagingGoodsUUIDsAndQtys = {New iMoySkladDataProvider.ResultParcelInfo.PackagingGoodInfo With {.Amount = 1, .CurrencyUUID = "464ceb8a-489e-11e3-c722-7054d21a8d1e", .GoodUUID = "5a163be4-8646-11e4-90a2-8ecb0017e01c", .Qty = 1}}


        '_result = .UpdateDemandsAfterShip(DemandUUID:="e4bfcaad-b9e4-11e4-7a07-673d00198709", ResultParcels:={_parcel}, NewStateUUID:="84e80822-7bda-11e4-90a2-8ecb0016fb1c")


        '--------------------------



        '_result = .CreateCustomerOrder(GoodsUUIDs:={"5a5f89c1-9f0e-11e4-7a07-673d00459e98"}, GoodsAmounts:={600}, CurrencyUUID:="a487d989-4c83-11e3-ce68-7054d21a8d1e", CustomerUUID:="b3bd9069-966a-11e4-90a2-8ecb00866fde", MyCompanyUUID:="5a4ba7b2-4993-11e3-ce8c-7054d21a8d1e", Orderstate1UUID:="3ab42ff2-7bd6-11e4-90a2-8ecb0016aa97", ProjectUUID:="3d8a69e9-f25d-11e3-6d72-002590a28eca", WokerUUID:="97c20675-db61-11e3-a884-002590a28eca", HandlingTime:=5, Description:="тестовое описание", ShippingInAmount:=9, ShippingInGoodUUID:="93961544-968e-11e4-90a2-8ecb00887e5e", GoodsQtys:={1}, ShippingInQty:=1)

        '_result = .CreateCustomer("Тестовый клиент", "Тестовый код", "test@test.com", New iMoySkladDataProvider.Address With {.Name = "Тестовое имя", .City = "city", .Country = "country", .FullAddress = "fulladdress", .Phone = "phone", .PostIndex = "postindex", .State = "state", .Street = "street"}, "address string", "833c63d4-a006-11e3-0a04-002590a28eca", "f2d47ec1-a00a-11e3-25ff-002590a28eca", "Детали интереса", {"поставщики"}, "002defac-b51b-11e3-36b4-002590a28eca", "описание")
        '======CreateIncomingPayment====
        '_result = .CreateIncomingPayment(ProjectUUID:="3d8a69e9-f25d-11e3-6d72-002590a28eca", AccepterUUID:="97c20675-db61-11e3-a884-002590a28eca", AccountUUID:="17436604-f7cc-11e3-65e6-002590a28eca", Amount:=99, CurrencyUUID:="a487d989-4c83-11e3-ce68-7054d21a8d1e", CustomerUUID:="b3bd9069-966a-11e4-90a2-8ecb00866fde", MyCompanyUUID:="5a4ba7b2-4993-11e3-ce8c-7054d21a8d1e", NoFeeIncluded:=True, Description:="Тестовый платеж", paymentPurpose:="тестовое основание")
        '==========
        ' _result = _in.CheckCustomer("Donna", "", "")
        '_result += "// " & _in.CheckCustomer("", "test@test.com", "Тестовый код")
        '_result += "// " & _in.CheckCustomer("Тестовый клиент", "", "Тестовый код")
        '_result += "// " & _in.CheckCustomer("Тестовый клиент", "test@test.com", "Тестовый код")
        '    _result += "// " & _in.CheckCustomer("", "", "Тестовый код")
        '==============
        'Dim _res = .GetTriboneWoker
        'For Each t In _res
        '    _result += t.Key & " --> " & t.Value & ChrW(13)
        'Next
        '    End With

        'Select Case MsgBox(_result, MsgBoxStyle.YesNo)
        '    Case MsgBoxResult.No
        '        GoTo qw
        'End Select
        'End With

    End Sub

End Class