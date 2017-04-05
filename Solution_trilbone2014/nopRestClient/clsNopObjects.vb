Imports nopTypes.Nop.Plugin.Misc.panoRazziRestService
Imports System.Globalization

<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"), _
   System.SerializableAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)> _
Public Class clsManufacturersObjectCollection
    Inherits clsLangObjectCollection

    Public Shadows Function GetXML() As String
        Dim _xml = New XElement("ProductManufacturers")
        For Each t In Me
            Dim _ProductManufacturer = New XElement("ProductManufacturer")
            With _ProductManufacturer
                .Add(New XElement("ProductManufacturerId", t.ProductObjectId))
                .Add(New XElement("ManufacturerId", t.ObjectId))
                .Add(New XElement("IsFeaturedProduct", t.IsFeaturedProduct.ToString.ToLower))
                .Add(New XElement("DisplayOrder", t.DisplayOrder))
                .Add(XElement.Parse(t.GetXML("ManufacturerName", "ManufacturerValue", True, False, "")))
            End With
            _xml.Add(_ProductManufacturer)
        Next
        Return _xml.ToString
    End Function


    Public Shared Shadows Function CreateInstance(Optional base As IEnumerable(Of LangObject) = Nothing) As clsManufacturersObjectCollection
        Dim _new = New clsManufacturersObjectCollection
        With _new
            .oCollectionName = "Localities"
            If Not base Is Nothing Then
                .AddRange(base)
            End If
        End With
        Return _new
    End Function
End Class

<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"), _
   System.SerializableAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)> _
Public Class clsCategoriesObjectCollection
    Inherits clsLangObjectCollection

    Public Shadows Function GetXML() As String
        Dim _xml = New XElement("ProductCategories")
        For Each t In Me
            Dim _Category = New XElement("ProductCategory")
            With _Category
                .Add(New XElement("ProductCategoryId", t.ProductObjectId))
                .Add(New XElement("CategoryId", t.ObjectId))
                .Add(New XElement("IsFeaturedProduct", t.IsFeaturedProduct.ToString.ToLower))
                .Add(New XElement("DisplayOrder", t.DisplayOrder))
                .Add(New XElement("CategoryName", t.InvariantValue))
                '' .Add(XElement.Parse(t.GetXML("ManufacturerName", "ManufacturerValue", True, False, "")))
            End With
            _xml.Add(_Category)
        Next
        Return _xml.ToString
    End Function


    Public Shared Shadows Function CreateInstance(Optional base As IEnumerable(Of LangObject) = Nothing) As clsCategoriesObjectCollection
        Dim _new = New clsCategoriesObjectCollection
        With _new
            .oCollectionName = "Categories"
            If Not base Is Nothing Then
                .AddRange(base)
            End If
        End With
        Return _new
    End Function
End Class


Public Class clsPictureObject
    Inherits LangObject
    ''
    ''' <summary>
    ''' в коллекции item содержаться PictureSeoName
    ''' </summary>
    ''' <param name="base"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Shadows Function CreateInstance(Optional base As LangObject = Nothing) As clsPictureObject
        Dim _new = New clsPictureObject
        With _new
            ._groupName = "Picture"
            .PicturePath = ""
            .PictureURI = ""
            If Not base Is Nothing Then
                With _new
                    .DisplayOrder = base.DisplayOrder
                    .InvariantValue = base.InvariantValue
                    .IsFeaturedProduct = base.IsFeaturedProduct
                    For Each t In base.ItemLangObj
                        .AddItem(t)
                    Next
                    .ObjectId = base.ObjectId
                    .ProductObjectId = base.ProductObjectId
                End With
            End If
        End With
        Return _new
    End Function


    Dim oPicturePath As String
    Dim oPictureURI As String

    <System.Xml.Serialization.XmlElementAttribute("PicturePath")> _
    Public Property PicturePath As String
        Get
            Return oPicturePath
        End Get
        Set(value As String)
            oPicturePath = value
            RaisePropertyChanged("PicturePath")
        End Set
    End Property

    <System.Xml.Serialization.XmlElementAttribute("PictureURI")> _
    Public Property PictureURI As String
        Get
            Return oPictureURI
        End Get
        Set(value As String)
            oPictureURI = value
            RaisePropertyChanged("PictureURI")
        End Set
    End Property

End Class


<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"), _
   System.SerializableAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)> _
Public Class clsPicturesObjectCollection
    Inherits List(Of clsPictureObject)

    Public Shadows Sub Add(item As clsPictureObject)
        item.DisplayOrder = Me.Count
        MyBase.Add(item)
    End Sub

    Public Shadows Sub AddRange(collection As IEnumerable(Of clsPictureObject))
        For Each t In collection
            Me.Add(t)
        Next
    End Sub


    Public Shared Shadows Function CreateInstance() As clsPicturesObjectCollection
        Dim _new = New clsPicturesObjectCollection
        'With _new
        '    If Not base Is Nothing Then
        '        .AddRange(base)
        '    End If
        'End With
        Return _new
    End Function

    Public Shadows Function GetXML() As String
        Dim _xml = New XElement("ProductPictures")
        For Each t In Me
            Dim _picture = New XElement("ProductPicture")
            With _picture
                .Add(New XElement("ProductPictureId", t.ProductObjectId))
                .Add(New XElement("PictureId", t.ObjectId))
                .Add(New XElement("DisplayOrder", t.DisplayOrder))
                .Add(New XElement("PicturePath", t.PicturePath))
                .Add(New XElement("PictureURI", t.PictureURI))
                .Add(New XElement("PictureSeoName", t.InvariantValue))
            End With

            _xml.Add(_picture)
        Next
        Return _xml.ToString
    End Function
End Class


''<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"), _
''   System.SerializableAttribute(), _
''   System.ComponentModel.DesignerCategoryAttribute("code"), _
''   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)> _
''Public Class clsSpecificAttributesCollection
''    Inherits clsLangObjectCollection
''    Private oAttribute As LangObject
''    Dim oCustomValue As String
''    Dim oShowOnProductPage As Boolean
''    Dim oAttributeType As emAttributeType
''    Dim oDisplayOrder As Integer


''    <System.Xml.Serialization.XmlIgnore()>
''    Public Property Attribute As LangObject
''        Get
''            Return oAttribute
''        End Get
''        Set(value As LangObject)
''            oAttribute = value
''            RaisePropertyChanged("Attribute")
''        End Set
''    End Property


''    ''' <summary>
''    ''' перекрывающее значение
''    ''' </summary>
''    ''' <value></value>
''    ''' <returns></returns>
''    ''' <remarks></remarks>
''    <System.Xml.Serialization.XmlElementAttribute("CustomValue")> _
''    Public Property CustomValue As String
''        Get
''            Return oCustomValue
''        End Get
''        Set(value As String)
''            oCustomValue = value
''            If oCustomValue = "" Then
''                Me.AttributeType = emAttributeType.Option
''            End If
''            If (Not oCustomValue = "") And Me.AttributeType = emAttributeType.Option Then
''                Me.AttributeType = emAttributeType.CustomText
''            End If
''            RaisePropertyChanged("CustomValue")
''        End Set
''    End Property

''    Private oAllowFiltering As Boolean
''    ''' <summary>
''    ''' филтровать
''    ''' </summary>
''    ''' <value></value>
''    ''' <returns></returns>
''    ''' <remarks></remarks>
''    <System.Xml.Serialization.XmlElementAttribute("AllowFiltering")> _
''    Public Property AllowFiltering As Boolean
''        Get
''            Return oAllowFiltering
''        End Get
''        Set(value As Boolean)
''            oAllowFiltering = value
''            RaisePropertyChanged("AllowFiltering")
''        End Set
''    End Property
''    ''' <summary>
''    ''' показать на странице
''    ''' </summary>
''    ''' <value></value>
''    ''' <returns></returns>
''    ''' <remarks></remarks>
''    <System.Xml.Serialization.XmlElementAttribute("ShowOnProductPage")> _
''    Public Property ShowOnProductPage As Boolean
''        Get
''            Return oShowOnProductPage
''        End Get
''        Set(value As Boolean)
''            oShowOnProductPage = value
''            RaisePropertyChanged("ShowOnProductPage")
''        End Set
''    End Property

''    ''' <summary>
''    ''' тип атрибута
''    ''' </summary>
''    ''' <value></value>
''    ''' <returns></returns>
''    ''' <remarks></remarks>
''    <System.Xml.Serialization.XmlElementAttribute("AttributeType")> _
''    Public Property AttributeType As emAttributeType
''        Get
''            Return oAttributeType
''        End Get
''        Set(value As emAttributeType)
''            oAttributeType = value
''            If oAttributeType = emAttributeType.Option Then
''                Me.AllowFiltering = True
''            Else
''                Me.AllowFiltering = False
''            End If
''            RaisePropertyChanged("AttributeType")
''        End Set
''    End Property

''    ''' <summary>
''    ''' порядок показа на странице камня
''    ''' </summary>
''    ''' <value></value>
''    ''' <returns></returns>
''    ''' <remarks></remarks>
''    <System.Xml.Serialization.XmlElementAttribute("DisplayOrder")> _
''    Public Property DisplayOrder As Integer
''        Get
''            Return oDisplayOrder
''        End Get
''        Set(value As Integer)
''            oDisplayOrder = value
''            RaisePropertyChanged("DisplayOrder")
''        End Set
''    End Property






''    'Private oSelectedIndex As Integer = -1
''    ' ''' <summary>
''    ' ''' выбранное значение. Сам класс содержит список возможных значений атрибута
''    ' ''' </summary>
''    ' ''' <value></value>
''    ' ''' <returns></returns>
''    ' ''' <remarks></remarks>
''    '<System.Xml.Serialization.XmlIgnore()>
''    'Public Property SelectedIndex As Integer
''    '    Get
''    '        Return oSelectedIndex
''    '    End Get
''    '    Set(value As Integer)
''    '        If Me.Count = 0 Then
''    '            MsgBox(String.Format("в обьекте {0} нет значений", Me.ToString), vbCritical)
''    '            Return
''    '        End If
''    '        If value > Me.Count - 1 Then
''    '            MsgBox(String.Format("по индексу {0} нет элементов", value), vbCritical)
''    '            Return
''    '        End If
''    '        oSelectedIndex = value
''    '        RaisePropertyChanged("SelectedIndex")
''    '    End Set
''    'End Property
''    ''' <summary>
''    ''' скрывает базовый метод
''    ''' </summary>
''    ''' <param name="item"></param>
''    ''' <remarks></remarks>
''    Shadows Sub Add(item As LangObject)
''        If Me.Attribute Is Nothing Then
''            MsgBox(String.Format("Обьект {0}, содержащий значения атрибута не инициализован соответствующим атрибутом", Me.ToString), vbCritical)
''        End If
''        If item._groupName = Me.Attribute.InvariantValue Then
''            If Not Me.Contains(item) Then
''                MyBase.Add(item)
''                RaisePropertyChanged("Count")
''            Else
''                MsgBox(String.Format("Значение {0} уже присутствует", item.InvariantValue), vbCritical)
''            End If
''        Else
''            MsgBox(String.Format("Невозможно добавить значения для группы {0} в группу {1}", item._groupName, Me.Attribute.InvariantValue), vbCritical)
''        End If
''    End Sub
''    ''' <summary>
''    ''' скрывает базовый метод
''    ''' </summary>
''    ''' <param name="collection"></param>
''    ''' <remarks></remarks>
''    Shadows Sub AddRange(collection As IEnumerable(Of LangObject))
''        For Each t In collection
''            If Not Me.Contains(t) Then
''                Me.Add(t)
''            End If
''        Next
''    End Sub

''    Public Overrides Function ToString() As String
''        If Me.Attribute Is Nothing Then Return "атрибут не инициализирован"
''        Return Me.Attribute.InvariantValue
''    End Function



''    Public Shadows Function GetXML(ValueIndex As Integer) As String
''        Dim _ProductSpecAttr = New XElement("ProductSpecificationAttribute")

''        If Me.Count = 0 Then
''            _ProductSpecAttr.Add(New XElement("Error", (String.Format("в обьекте {0} нет значений", Me.ToString))))
''            Return _ProductSpecAttr.ToString
''        End If
''        If ValueIndex > Me.Count - 1 Then

''            _ProductSpecAttr.Add(New XElement("Error", (String.Format("по индексу {0} нет элементов", ValueIndex))))
''            Return _ProductSpecAttr.ToString
''        End If

''        With _ProductSpecAttr
''            If Me.Count = 0 Then
''                Return _ProductSpecAttr.ToString
''            End If
''            .Add(New XElement("ProductSpecificationAttributeId", Me.Item(ValueIndex).ProductObjectId))
''            .Add(New XElement("ShowOnProductPage", ShowOnProductPage.ToString.ToLower))
''            .Add(New XElement("DisplayOrder", DisplayOrder.ToString.ToLower))
''            .Add(New XElement("CustomValue", CustomValue))
''            .Add(New XElement("AllowFiltering", AllowFiltering.ToString.ToLower))
''            .Add(New XElement("SpecificationAttributeOptionId", Me.Item(ValueIndex).ObjectId))
''            .Add(XElement.Parse(Me.Item(ValueIndex).GetXML("AttributeName", "AttribueValue", True, True, [Enum].GetName(GetType(emAttributeType), AttributeType))))
''        End With
''        Return _ProductSpecAttr.ToString
''    End Function

''    Public Enum emAttributeType
''        [Option]
''        CustomText
''        Hyperlink
''        CustomHtmlText
''    End Enum


''    Shared Shadows Function CreateInstance(GroupName As String) As clsSpecificAttributesCollection
''        If String.IsNullOrEmpty(GroupName) Then
''            Debug.Fail("Необходимо указать имя группы")
''            Return Nothing
''        End If
''        Dim _new = New clsSpecificAttributesCollection
''        _new.oGroupName = GroupName
''        Return _new
''    End Function
''End Class

'' ''' <summary>
'' ''' содержит список возможных атрибутов
'' ''' </summary>
'' ''' <remarks></remarks>
''Public Class clsSpecificAttributesObjectCollection
''    Inherits List(Of clsSpecificAttributesCollection)

''    Public Sub AddAtributeValue(attribute As LangObject, attributeValue As LangObject)
''        Dim _result = (From c In Me Where c.Equals(attribute) Select c).FirstOrDefault
''        If _result Is Nothing Then
''            MsgBox(String.Format("Атрибута {0} нет в списке", attribute.InvariantValue), vbCritical)
''        End If
''        _result.Add(attributeValue)
''    End Sub

''    Public Sub AddAttributeInList(attribute As LangObject, attributeValues As clsLangObjectCollection)
''        Dim _new As clsSpecificAttributesCollection = clsSpecificAttributesCollection.CreateInstance(attribute._groupName)
''        With _new
''            .Attribute = attribute
''            If Not attributeValues Is Nothing Then
''                .AddRange(attributeValues)
''            End If
''        End With
''        Me.Add(_new)
''    End Sub

''    Public Function GetAttributesAsLangCollection() As clsLangObjectCollection
''        Dim _out = Me.Select(Function(x) x.Attribute).ToList
''        If _out.Count = 0 Then
''            Return Nothing
''        End If
''        Dim _coll = clsLangObjectCollection.CreateInstance(_out.First._groupName)
''        _coll.AddRange(_out)
''        Return _coll
''    End Function

''    ''' <summary>
''    ''' потом добавляем атрибуты с помощью AddAttributeInList. Значение к атрибуту можно добавить при помощи AddAtributeValue
''    ''' </summary>
''    ''' <param name="attribute"></param>
''    ''' <param name="attributeValues"></param>
''    ''' <returns></returns>
''    ''' <remarks></remarks>
''    Public Shared Function CreateInstance(attribute As LangObject, attributeValues As clsLangObjectCollection) As clsSpecificAttributesObjectCollection
''        Dim _new = New clsSpecificAttributesObjectCollection
''        _new.AddAttributeInList(attribute, attributeValues)
''        Return _new
''    End Function

''    Public Shadows Function GetXML() As String
''        Dim _xml = New XElement("ProductSpecificationAttributes")
''        For Each t In Me
''            'выбрать первое из списка значений
''            _xml.Add(XElement.Parse(t.GetXML(0)))
''        Next
''        Return _xml.ToString
''    End Function

''End Class


Public Class clsDescriptionObject
    Implements System.ComponentModel.INotifyPropertyChanged

    Private oLang As lng = lng.enUS
    Private oSetAsInvariant As Boolean = False

    Dim oParent As clsDocumentObject
    Dim oSelectedProductTag As clsLangObjectCollection
    Dim oSelectedProductMetaWord As clsLangObjectCollection



    ''' <summary>
    ''' инициализует обьект
    ''' </summary>
    ''' <param name="dataLang"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CreateInstance(dataLang As lng, parent As clsDocumentObject) As clsDescriptionObject
        Dim _new As New clsDescriptionObject
        With _new
            .Parent = parent
            .oSelectedProductTag = parent.SelectedProductTag
            .oSelectedProductMetaWord = parent.SelectedProductMetaWord
            .oxslTemplateCollection = New List(Of clsExternalData.clsxslTemplate)
            .oLang = dataLang
            .RaisePropertyChanged("langName")
        End With
        Return _new
    End Function

    Public Property Parent As clsDocumentObject
        Get
            Return oParent
        End Get
        Set(value As clsDocumentObject)
            oParent = value
            RaisePropertyChanged("Parent")
        End Set
    End Property

    Protected Sub RaisePropertyChanged(ByVal propertyName As String)
        Dim propertyChanged As System.ComponentModel.PropertyChangedEventHandler = Me.PropertyChangedEvent
        If (Not (propertyChanged) Is Nothing) Then
            propertyChanged(Me, New System.ComponentModel.PropertyChangedEventArgs(propertyName))
        End If
    End Sub

    Public ReadOnly Property ProductMetaWord As String()
        Get
            Return Parent.ProductMetaWord.GetLangValues(oLang).ToArray
        End Get
    End Property
    Public Property SelectedProductMetaWord As clsLangObjectCollection
        Get
            Return oSelectedProductMetaWord
        End Get
        Set(value As clsLangObjectCollection)
            oSelectedProductMetaWord = value
            RaisePropertyChanged("SelectedProductMetaWord")
        End Set
    End Property


    Public ReadOnly Property ProductTag As clsLangObjectCollection
        Get
            Return Parent.ProductTag
        End Get
        'Set(value As clsLangObjectCollection)
        '    Parent.ProductTag = value
        '    RaisePropertyChanged("ProductTag")
        'End Set
    End Property

    Public Property SelectedProductTag As clsLangObjectCollection
        Get
            Return oSelectedProductTag
        End Get
        Set(value As clsLangObjectCollection)
            oSelectedProductTag = value
            RaisePropertyChanged("SelectedProductTag")
        End Set
    End Property

    Public ReadOnly Property DataLang As lng
        Get
            Return oLang
        End Get
    End Property

    Public ReadOnly Property Culture As Globalization.CultureInfo
        Get
            Select Case Me.DataLang
                Case lng.enUS
                    Return CultureInfo.CreateSpecificCulture("en-US")
                Case lng.ruRU
                    Return CultureInfo.CreateSpecificCulture("ru-RU")
                Case Else
                    Return CultureInfo.CreateSpecificCulture("en-US")
            End Select
        End Get
    End Property

    Public ReadOnly Property LangString As String
        Get
            Return [Enum].GetName(GetType(lng), oLang).Substring(0, 2)
        End Get
    End Property

    Public Property MetaTitle As String
        Get
            Return Parent.MetaTitle(oLang)
        End Get
        Set(value As String)
            Parent.MetaTitle(oLang) = value
            RaisePropertyChanged("MetaTitle")
        End Set
    End Property

    Public Property MetaDescription As String
        Get
            Return Parent.MetaDescription(oLang)
        End Get
        Set(value As String)
            Parent.MetaDescription(oLang) = value
            RaisePropertyChanged("MetaDescription")
        End Set
    End Property

    Public Property xsltTemplates As List(Of clsExternalData.clsxslTemplate)
        Get
            Return Me.oxslTemplateCollection
        End Get
        Set(value As List(Of clsExternalData.clsxslTemplate))
            oxslTemplateCollection = value
            RaisePropertyChanged("xsltTemplates")
        End Set
    End Property


    ''' <summary>
    ''' вернет тело шаблона по имени
    ''' </summary>
    ''' <param name="name"></param>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property xsltTemplateBody(name As String) As String
        Get
            Dim _tmpl = oxslTemplateCollection.FirstOrDefault(Function(x) x.Name = name)
            If Not _tmpl Is Nothing Then
                Return _tmpl.Body
            End If
            Return ""
        End Get
    End Property
    ' ''' <summary>
    ' ''' вернет список имен имеющихся шаблонов 
    ' ''' </summary>
    ' ''' <value></value>
    ' ''' <returns></returns>
    ' ''' <remarks></remarks>
    'Public ReadOnly Property xsltTemplatesList As List(Of String)
    '    Get
    '        Return oxslTemplateCollection.Select(Function(x) x.Name)
    '    End Get
    'End Property


    Public Property FullDescriptions As String
        Get
            Return Parent.FullDescriptions(oLang)
        End Get
        Set(value As String)
            Parent.FullDescriptions(oLang) = value
            RaisePropertyChanged("FullDescriptions")
        End Set
    End Property

    Public Property ShortDescriptions As String
        Get
            Return Parent.ShortDescriptions(oLang)
        End Get
        Set(value As String)
            Parent.ShortDescriptions(oLang) = value
            RaisePropertyChanged("ShortDescriptions")
        End Set
    End Property
    Public Property Names As String
        Get
            Return Parent.Names(oLang)
        End Get
        Set(value As String)
            Parent.Names(oLang) = value
            RaisePropertyChanged("Names")
        End Set
    End Property

    ''' <summary>
    ''' устанавливает язык вкладки основным
    ''' </summary>
    Public Property SetAsInvariant As Boolean
        Get
            Return oSetAsInvariant
        End Get
        Set(value As Boolean)
            Dim _old = oSetAsInvariant
            oSetAsInvariant = value
            If _old = oSetAsInvariant Then Return
            RaisePropertyChanged("SetAsInvariant")
        End Set
    End Property

    Public Event PropertyChanged(sender As Object, e As ComponentModel.PropertyChangedEventArgs) Implements ComponentModel.INotifyPropertyChanged.PropertyChanged

    Public Overrides Function ToString() As String
        Return String.Format("вкладка: {0}", LangString)
    End Function


    Private oxslTemplateCollection As List(Of clsExternalData.clsxslTemplate)
End Class

Public Class clsDocumentSimple
    Implements System.ComponentModel.INotifyPropertyChanged

    Dim oAdminComment As String


    Dim oSeName As String


    Dim oSKU As String


    Dim oShowOnHomePage As Boolean
    Dim oWeight As Decimal
    Dim oLength As Decimal
    Dim oWidth As Decimal
    Dim oHeight As Decimal
    Dim oPublished As Boolean


    Dim oWarehouseID As Integer
    ''' <summary>
    ''' Комментарий админа
    ''' </summary>
    Public Property AdminComment As String
        Get
            Return oAdminComment
        End Get
        Set(value As String)
            oAdminComment = value
            RaisePropertyChanged("AdminComment")
        End Set
    End Property

    ''' <summary>
    ''' Это будет прямя ссылка на образец
    ''' </summary>
    Public Property SeName As String
        Get
            Return oSeName
        End Get
        Set(value As String)
            oSeName = value
            RaisePropertyChanged("SeName")
        End Set
    End Property

    ''' <summary>
    ''' Наш номер
    ''' </summary>
    Public Property SKU As String
        Get
            Return oSKU
        End Get
        Set(value As String)
            oSKU = value
            RaisePropertyChanged("SKU")
        End Set
    End Property
    ''' <summary>
    ''' Опубликовано
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Published As Boolean
        Get
            Return oPublished
        End Get
        Set(value As Boolean)
            oPublished = value
            RaisePropertyChanged("Published")
        End Set
    End Property


    ''' <summary>
    ''' Показать на центральной странице??
    ''' </summary>
    Public Property ShowOnHomePage As Boolean
        Get
            Return oShowOnHomePage
        End Get
        Set(value As Boolean)
            oShowOnHomePage = value
            RaisePropertyChanged("ShowOnHomePage")
        End Set
    End Property

    ''' <summary>
    ''' вес отправочный, кг
    ''' </summary>
    Public Property Weight As Decimal
        Get
            Return oWeight
        End Get
        Set(value As Decimal)
            oWeight = value
            RaisePropertyChanged("Weight")
        End Set
    End Property

    ''' <summary>
    ''' длина упаковки, м
    ''' </summary>
    Public Property Length As Decimal
        Get
            Return oLength
        End Get
        Set(value As Decimal)
            oLength = value
            RaisePropertyChanged("Length")
        End Set
    End Property

    ''' <summary>
    ''' ширина упаковки, м
    ''' </summary>
    Public Property Width As Decimal
        Get
            Return oWidth
        End Get
        Set(value As Decimal)
            oWidth = value
            RaisePropertyChanged("Width")
        End Set
    End Property

    ''' <summary>
    ''' высота упаковки, м
    ''' </summary>
    Public Property Height As Decimal
        Get
            Return oHeight
        End Get
        Set(value As Decimal)
            oHeight = value
            RaisePropertyChanged("Height")
        End Set
    End Property


    Public Property WarehouseID As Integer
        Get
            Return oWarehouseID
        End Get
        Set(value As Integer)
            oWarehouseID = value
            RaisePropertyChanged("WarehouseID")
        End Set
    End Property

    Public Shared Function CreateInstance() As clsDocumentSimple
        Dim _new = New clsDocumentSimple
        With _new
            .AdminComment = ""
            .SeName = ""
            .ShowOnHomePage = False
            .Published = True
            .SKU = ""
        End With
        Return _new
    End Function


    Protected Sub RaisePropertyChanged(ByVal propertyName As String)
        Dim propertyChanged As System.ComponentModel.PropertyChangedEventHandler = Me.PropertyChangedEvent
        If (Not (propertyChanged) Is Nothing) Then
            propertyChanged(Me, New System.ComponentModel.PropertyChangedEventArgs(propertyName))
        End If
    End Sub



    Public Event PropertyChanged(sender As Object, e As ComponentModel.PropertyChangedEventArgs) Implements ComponentModel.INotifyPropertyChanged.PropertyChanged
End Class
