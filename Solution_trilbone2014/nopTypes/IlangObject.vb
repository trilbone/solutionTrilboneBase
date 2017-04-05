Namespace Nop.Plugin.Misc.panoRazziRestService
    Public Interface IlangObject

        Event PropertyChanged As System.ComponentModel.PropertyChangedEventHandler

        ''' <summary>
        ''' имя группы, к которой принадлежит обьект
        ''' </summary>
        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Property _groupName As String

        <System.Xml.Serialization.XmlIgnore()> _
        Property DisplayOrder As Integer

        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Property InvariantValue As String

        <System.Xml.Serialization.XmlIgnore()> _
        Property IsFeaturedProduct As Boolean

        ''' <summary>
        ''' получит/установит значение для языка.
        ''' </summary>
        <System.Xml.Serialization.XmlIgnore()> _
        Property langValue(lang As Nop.Plugin.Misc.panoRazziRestService.lng) As String

        ''' <summary>
        ''' ID обьекта в БД NopComm
        ''' </summary>
        <System.Xml.Serialization.XmlIgnore()> _
        Property ObjectId As Integer

        ''' <summary>
        ''' ID привязки продукта к обьекту в БД NopComm
        ''' </summary>
        <System.Xml.Serialization.XmlIgnore()> _
        Property ProductObjectId As Integer




        <System.Xml.Serialization.XmlElementAttribute("Item")> _
        Property ItemLangObj As IlangObjItem()


        Sub AddItem(obj As IlangObjItem)

        Overloads Function Contains(obj As IlangObjItem) As Boolean

        ''' <summary>
        ''' есть ли запись для языка -1=пустой массив
        ''' </summary>
        Overloads Function Contains(lang As Nop.Plugin.Misc.panoRazziRestService.lng) As Boolean

        ''' <summary>
        ''' число языковых записей
        ''' </summary>
        Overloads Function Count() As Integer

        ''' <summary>
        ''' число языковых записей конкретного языка
        ''' </summary>
        Overloads Function Count(lang As Nop.Plugin.Misc.panoRazziRestService.lng) As Integer

        ''' <summary>
        ''' создает обьект, инициализируя все необходимые поля
        ''' </summary>
        Overloads Function CreateInstance(groupName As String, Optional invariantValue As String = "") As IlangObject

        Overloads Function CreateInstance(groupName As String, invariantValue As String, Optional EnValue As String = "", Optional ruValue As String = "") As IlangObject

        Function Equals(obj As Object) As Boolean

        Function GetHashCode() As Integer

        ''' <summary>
        ''' вспомогательная функция
        ''' </summary>
        Function GetInvariantItem() As IlangObjItem


        ''' <summary>
        ''' вернет хмл с переданным именет тега
        ''' </summary>
        ''' <param name="TagName">имя тега</param>
        Function GetXML(TagName As String, ItemTagName As String, Optional includeInvariantValueAttribute As Boolean = False, Optional includeGroupNameAttribute As Boolean = False, Optional TypeAttributeValue As String = "") As String

        Sub RaisePropertyChanged(propertyName As String)

        Function RemoveItem(obj As IlangObjItem) As Boolean

        ''' <summary>
        ''' установит значение выбранного языка как инвариантное
        ''' </summary>
        Sub SetAsInvariant(lang As Nop.Plugin.Misc.panoRazziRestService.lng)

        ''' <summary>
        ''' выводит значения элемента инвариант, либо атрибута инвариант, либо base.tostring
        ''' </summary>
        Function ToString() As String


    End Interface

    Public Interface IlangObjItem

        Event PropertyChanged As System.ComponentModel.PropertyChangedEventHandler

        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Property lang As Nop.Plugin.Misc.panoRazziRestService.lng

        Property Value As String

        Function Equals(obj As Object) As Boolean

        Function GetHashCode() As Integer

        ''' <summary>
        ''' Вернет XML с переданным тегом
        ''' </summary>
        ''' <param name="TagName">имя тега</param>
        Function GetXML(TagName As String) As String

        Sub RaisePropertyChanged(propertyName As String)

        Function ToString() As String

    End Interface

End Namespace
