Imports nopTypes.Nop.Plugin.Misc.panoRazziRestService

''' <summary>
''' обьект значения
''' </summary>
Public Class clsSAObjectValue
    Inherits LangObject

    Dim oParent As clsSAObject


    Public ReadOnly Property Parent As clsSAObject
        Get
            Return oParent
        End Get
    End Property


    Public Shadows ReadOnly Property _groupName As String
        Get
            Return MyBase._groupName
        End Get
    End Property

    Public Shared Shadows Function CreateInstance(Parent As clsSAObject, base As LangObject) As clsSAObjectValue
        'полю _groupName соответствует invarian value соотв. аттрибута
        Dim _new As New clsSAObjectValue

        With _new
            .oParent = Parent
            .oNameGroupField = Parent.InvariantValue

            .DisplayOrder = base.DisplayOrder
            .InvariantValue = base.InvariantValue
            .IsFeaturedProduct = base.IsFeaturedProduct
            .ItemLangObj = base.ItemLangObj
            .ObjectId = base.ObjectId
            .ProductObjectId = base.ProductObjectId
        End With
        Return _new
    End Function

    ''' <summary>
    ''' генерирует группу AttributeName
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shadows Function GetXML() As String
        Return MyBase.GetXML(TagName:="AttributeName", ItemTagName:="AttribueValue", includeGroupNameAttribute:=True, includeInvariantValueAttribute:=True, TypeAttributeValue:=[Enum].GetName(GetType(clsSAObject.emAttributeType), Parent.ValueType))
    End Function

End Class


''' <summary>
''' обьект особенности (атрибут)
''' </summary>
Public Class clsSAObject
    Inherits LangObject

    Public Enum emAttributeType
        [Option]
        CustomText
        Hyperlink
        CustomHtmlText
    End Enum
    Private oAllowFiltering As Boolean


    Dim oCustomValue As String


    Dim oDisplayOrder As Integer


    Dim oShowOnProductPage As Boolean


    Dim oValueType As emAttributeType
    Dim oValue As clsSAObjectValue
    Dim oValuesCollection As clsSAObjectValueCollection

    ''' <summary>
    ''' филтровать
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.Xml.Serialization.XmlElementAttribute("AllowFiltering")> _
    Public Property AllowFiltering As Boolean
        Get
            Return oAllowFiltering
        End Get
        Set(value As Boolean)
            oAllowFiltering = value
            RaisePropertyChanged("AllowFiltering")
        End Set
    End Property

    ''' <summary>
    ''' перекрывающее значение
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.Xml.Serialization.XmlElementAttribute("CustomValue")> _
    Public Property CustomValue As String
        Get
            Return oCustomValue
        End Get
        Set(value As String)
            oCustomValue = value.Trim
            If String.IsNullOrEmpty(oCustomValue) Then
                Me.ValueType = emAttributeType.Option
            ElseIf Me.ValueType = emAttributeType.Option Then
                Me.ValueType = emAttributeType.CustomText
            End If
            RaisePropertyChanged("CustomValue")
        End Set
    End Property



    ''' <summary>
    ''' показать на странице
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.Xml.Serialization.XmlElementAttribute("ShowOnProductPage")> _
    Public Property ShowOnProductPage As Boolean
        Get
            Return oShowOnProductPage
        End Get
        Set(value As Boolean)
            oShowOnProductPage = value
            RaisePropertyChanged("ShowOnProductPage")
        End Set
    End Property

    ''' <summary>
    ''' значение аттрибута
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Value As clsSAObjectValue
        Get
            Return oValue
        End Get
        Set(value As clsSAObjectValue)
            oValue = value
        End Set
    End Property

    ''' <summary>
    ''' тип атрибута
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.Xml.Serialization.XmlElementAttribute("AttributeType")> _
    Public Property ValueType As emAttributeType
        Get
            ' MsgBox("get:" & oValueType & Me._groupName)
            Return oValueType
        End Get
        Set(value As emAttributeType)
            oValueType = value
            'MsgBox("set:" & value & Me._groupName)
            If oValueType = emAttributeType.Option Then
                Me.AllowFiltering = True
            Else
                Me.AllowFiltering = False
            End If
            RaisePropertyChanged("AttributeType")
        End Set
    End Property

    Public Property ValuesCollection As clsSAObjectValueCollection
        Get
            Return oValuesCollection
        End Get
        Set(value As clsSAObjectValueCollection)
            oValuesCollection = value
        End Set
    End Property

    ''' <summary>
    ''' group не используется, для всех атрибутов равен (Attributes). Именем атрибута является значение invariantValue
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shadows ReadOnly Property _groupName As String
        Get
            Return oNameGroupField
        End Get
    End Property

    Public Overloads Sub SelectValue(value As LangObject)
        Dim _target = Me.ValuesCollection.FirstOrDefault(Function(x) x.Equals(value))
        If _target Is Nothing Then
            MsgBox(String.Format("значение {0} не найдено для атрибута {1}", value.ToString, Me.ToString), vbCritical)
            Return
        End If
        Me.Value = _target
    End Sub

    Public Overloads Sub SelectValue(invariantvalue As String)
        Dim _target = Me.ValuesCollection.FirstOrDefault(Function(x) x.InvariantValue.ToLower.Equals(invariantvalue.ToLower))
        If _target Is Nothing Then
            MsgBox(String.Format("значение {0} не найдено для атрибута {1}", invariantvalue, Me.ToString), vbCritical)
            Return
        End If
        Me.Value = _target
    End Sub

    Public Overloads Sub SelectValue(index As Integer)

        If Me.ValuesCollection Is Nothing Then
            MsgBox(String.Format("список значений отсутствует для атрибута {0}", Me.ToString), vbCritical)
            Return
        End If
        If Me.ValuesCollection.Count < index + 1 Then
            MsgBox(String.Format("значение по индексу {0} не существует для атрибута {1}", index, Me.ToString), vbCritical)
            Return
        End If

        Dim _target = Me.ValuesCollection(index)

        Me.Value = _target
    End Sub


    Public Overloads Sub AddValue(value As clsSAObjectValue)
        Me.ValuesCollection.Add(value)
    End Sub

    Public Overloads Function AddValue(value As LangObject) As clsSAObjectValue
        Dim _v = clsSAObjectValue.CreateInstance(Me, value)
        Me.ValuesCollection.Add(_v)
        Return _v
    End Function

    Public Shared Shadows Function CreateInstance(base As LangObject, Optional collectionName As String = "Attributes") As clsSAObject
        If Not base.Contains(lng.invariant) Then
            MsgBox("Задать поле invariant для аттрибута необходимо!", vbCritical)
            Return Nothing
        End If
        Dim _new As New clsSAObject
        With _new
            .ItemLangObj = base.ItemLangObj
            .oNameGroupField = collectionName
            .AllowFiltering = False
            .CustomValue = ""
            .ShowOnProductPage = True
            .ValueType = emAttributeType.Option
            .Value = Nothing
            .InvariantValue = base.InvariantValue
            .ValuesCollection = clsSAObjectValueCollection.CreateInstance(_new)
        End With
        Return _new
    End Function


   


    ''' <summary>
    ''' значение ProductSpecificationAttribute
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shadows Function GetXML() As String
        Dim _ProductSpecAttr = New XElement("ProductSpecificationAttribute")
        With _ProductSpecAttr
            If Me.Value Is Nothing Then
                Return _ProductSpecAttr.ToString
            End If
            If Not Me.ValueType = emAttributeType.Option Then
                .Add(New XComment("Установлено значение CustomText"))
            Else
                .Add(New XComment(String.Format("{0}, как поисковое имя, должно совпадать со значением для инвариантного языка", Me.Value.InvariantValue)))
            End If
            .Add(New XElement("ProductSpecificationAttributeId", Me.ProductObjectId))
            .Add(New XElement("SpecificationAttributeOptionId", Me.Value.ObjectId))
            .Add(New XElement("CustomValue", CustomValue))
            .Add(New XElement("AllowFiltering", AllowFiltering.ToString.ToLower))
            .Add(New XElement("ShowOnProductPage", ShowOnProductPage.ToString.ToLower))
            .Add(New XElement("DisplayOrder", DisplayOrder.ToString.ToLower))

            .Add(XElement.Parse(Me.Value.GetXML))
           

        End With
        Return _ProductSpecAttr.ToString
    End Function
End Class



''' <summary>
''' Коллекция доступных особенностей
''' </summary>
Public Class clsSAObjectCollection
    Inherits clsLangObjectCollection

    Public Overrides Sub SetAsInvariant(lang As lng)
        'для значений атрибутов
        Me.ForEach(Sub(x) CType(x, clsSAObject).ValuesCollection.ForEach(Sub(y) y.SetAsInvariant(lang)))
        'для самих атрибутов
        MyBase.SetAsInvariant(lang)
    End Sub

    ''' <summary>
    ''' group не используется
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overrides ReadOnly Property _collectionName As String
        Get
            Return oCollectionName
        End Get
    End Property


    Shared Shadows Function CreateInstance(Optional collectionName As String = "Attributes") As clsSAObjectCollection
        Dim _new = New clsSAObjectCollection
        _new.oCollectionName = collectionName
        Return _new
    End Function

    Public Shadows Function GetXML() As String
        Dim _xml = New XElement("ProductSpecificationAttributes")
        For Each t As clsSAObject In Me
            _xml.Add(XElement.Parse(t.GetXML))
        Next
        Return _xml.ToString
    End Function

    ''' <summary>
    ''' добавить атрибут в список
    ''' </summary>
    Public Shadows Sub Add(item As clsSAObject)
        If Not item._groupName = Me._collectionName Then
            MsgBox(String.Format("Обьект {2} c groupname {0} не подходит для этой коллекции. Задайте groupname обекта равным {1}", item._groupName, Me._collectionName, item.ToString))
            Return
        End If
        MyBase.Add(item)
        'If Not Me.Contains(item) Then

        'End If
    End Sub

    ''' <summary>
    ''' Вернет по значению Invariant!!!
    ''' </summary>
    ''' <param name="item"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetItem(item As LangObject) As clsSAObject
        Dim _result As clsSAObject = Me.FirstOrDefault(Function(x) x.InvariantValue.Equals(item.InvariantValue))
        Return _result
    End Function

    ''' <summary>
    ''' добавить значение к списку значений атрибута
    ''' </summary>
    ''' <param name="value">значение</param>
    Public Sub AddValue(value As clsSAObjectValue)
        ' MsgBox("AddValu: " & Me._collectionName)
        Dim _target As clsSAObject = Me.FirstOrDefault(Function(x) x.Equals(value.Parent))
        If _target Is Nothing Then
            MsgBox(String.Format("AddValue: Атрибут {0} не найден", value.Parent.ToString))
            Return
        End If
        _target.ValuesCollection.Add(value)
    End Sub

    Public Overloads Sub SelectValue(item As clsSAObject, value As LangObject)
        Dim _target As clsSAObject = Me.FirstOrDefault(Function(x) x.Equals(item))
        If _target Is Nothing Then
            MsgBox(String.Format("SelectValue by obj: Атрибут {0} не найден", item.ToString))
            Return
        End If
        _target.SelectValue(value)
    End Sub

    Public Overloads Sub SelectValue(item As LangObject, invariantvalue As String)
        Dim _target As clsSAObject = Me.FirstOrDefault(Function(x) x.Equals(item))
        If _target Is Nothing Then
            MsgBox(String.Format("SelectValue by string: Атрибут {0} не найден", item.ToString))
            Return
        End If
        _target.SelectValue(invariantvalue)
    End Sub

    Public Overloads Sub SelectValue(item As LangObject, index As Integer)
        Dim _target As clsSAObject = Me.FirstOrDefault(Function(x) x.Equals(item))
        If _target Is Nothing Then
            MsgBox(String.Format("SelectValue by index: Атрибут {0} не найден", item.ToString))
            Return
        End If
        _target.SelectValue(index)
    End Sub

    ''' <summary>
    ''' создать атрибут и добавить его в список
    ''' </summary>
    ''' <param name="base"></param>
    ''' <remarks></remarks>
    Public Sub CreateAttribute(base As LangObject)
        Dim _new = clsSAObject.CreateInstance(base)
        Me.Add(_new)
    End Sub

End Class

''' <summary>
''' Коллекция доступных значений особенностей
''' </summary>
Public Class clsSAObjectValueCollection
    Inherits clsLangObjectCollection
    Dim oParent As clsSAObject
    ''' <summary>
    ''' group используется, для всех значений атрибута равен invariant значению атрибута-родителя
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overrides ReadOnly Property _collectionName As String
        Get
            Return oCollectionName
        End Get
    End Property

    Public Shadows Function GetXML() As String
        Dim _xml = New XElement("ProductSpecificationOptions")
        For Each t As clsSAObject In Me
            _xml.Add(XElement.Parse(t.GetXML))
        Next
        Return _xml.ToString
    End Function

    Public ReadOnly Property parent As clsSAObject
        Get
            Return oParent
        End Get
    End Property

    Shared Shadows Function CreateInstance(parent As clsSAObject) As clsSAObjectValueCollection
        Dim _new As New clsSAObjectValueCollection
        _new.oParent = parent
        _new.oCollectionName = parent.InvariantValue
        Return _new
    End Function

    ''' <param name="item">значение атрибута</param>
    Public Shadows Sub Add(item As clsSAObjectValue)
        'добавлять можно значения из одной группы
        If item._groupName = Me._collectionName Then
            If Not Me.Contains(item) Then
                MyBase.Add(item)
                RaisePropertyChanged("Count")
            Else
                'MsgBox(String.Format("Значение {0} уже присутствует", item.InvariantValue), vbCritical)
            End If
        Else
            MsgBox(String.Format("Невозможно добавить значения для атрибута {0} к атрибуту {1}", item._groupName, Me._collectionName), vbCritical)
        End If
        'MyBase.Add(item)
    End Sub

    Public Shadows Sub Remove(item As clsSAObjectValue)
        MyBase.Remove(item)
    End Sub

    ''' <summary>
    ''' создать новое значение для атрибута и добавит его в коллекцию значений
    ''' </summary>
    Public Sub CreateValue(base As LangObject)
        Dim _new = clsSAObjectValue.CreateInstance(Me.parent, base)
        parent.ValuesCollection.Add(_new)
    End Sub

    ''' <summary>
    ''' скрывает базовый метод
    ''' </summary>
    ''' <param name="collection"></param>
    ''' <remarks></remarks>
    Shadows Sub AddRange(collection As IEnumerable(Of LangObject))
        For Each t In collection
            If Not Me.Contains(t) Then
                Me.Add(t)
            End If
        Next
    End Sub

End Class
