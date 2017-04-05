Namespace Catalog

    ''' <summary>
    ''' описывает наложения на графическую карту образца
    ''' </summary>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.21006.1"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code"), _
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)> _
    Partial Public Class CATALOGSAMPLEMAPOVERLAY
        Inherits Object
        Implements System.ComponentModel.INotifyPropertyChanged
        Implements ICloneable
        Implements IComparable


        Dim visibleField As Boolean
        Dim dxField As Integer
        Dim dyField As Integer
        Dim iDField As String
        Dim overlayhrefField As String
        Private textField As String

        Dim typeField As emOverlayType
        Dim widthField As Integer
        Dim heightField As Integer
        Dim opacityField As Decimal

        ''' <summary>
        ''' отображать или нет
        ''' </summary>
        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property visible() As Boolean
            Get
                Return Me.visibleField
            End Get
            Set(ByVal value As Boolean)
                Me.visibleField = value
                Me.RaisePropertyChanged("visible")
            End Set
        End Property

        ''' <summary>
        ''' ширина оверлея
        ''' </summary>
        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property width() As Integer
            Get
                Return Me.widthField
            End Get
            Set(ByVal value As Integer)
                Me.widthField = value
                Me.RaisePropertyChanged("width")
            End Set
        End Property

        ''' <summary>
        ''' высота оверлея
        ''' </summary>
        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property height() As Integer
            Get
                Return Me.heightField
            End Get
            Set(ByVal value As Integer)
                Me.heightField = value
                Me.RaisePropertyChanged("height")
            End Set
        End Property

        ''' <summary>
        ''' прозрачность 0..1
        ''' </summary>
        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property opacity() As Decimal
            Get
                Return Me.opacityField
            End Get
            Set(ByVal value As Decimal)
                Me.opacityField = value
                Me.RaisePropertyChanged("opacity")
            End Set
        End Property
        <System.Xml.Serialization.XmlIgnore()> _
        Public ReadOnly Property Position As System.Drawing.Point
            Get
                Return New System.Drawing.Point(Me.dx, Me.dy)
            End Get
        End Property
        <System.Xml.Serialization.XmlIgnore()> _
        Public ReadOnly Property Size As System.Drawing.Size
            Get
                Return New System.Drawing.Size(Me.width, Me.height)
            End Get
        End Property

        ''' <summary>
        ''' смещение по Y относит. лев.верх. угла карты
        ''' </summary>
        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property dx() As Integer
            Get
                Return Me.dxField
            End Get
            Set(ByVal value As Integer)
                Me.dxField = value
                Me.RaisePropertyChanged("dx")
            End Set
        End Property


        ''' <summary>
        ''' смещение по Y относит. лев.верх. угла карты
        ''' </summary>
        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property dy() As Integer
            Get
                Return Me.dyField
            End Get
            Set(ByVal value As Integer)
                Me.dyField = value
                Me.RaisePropertyChanged("dy")
            End Set
        End Property

        ''' <summary>
        ''' имя элемента
        ''' </summary>
        ''' <remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property id() As String
            Get
                If Me.iDField = "" Then Return "noId"
                Return Me.iDField
            End Get
            Set(ByVal value As String)
                Me.iDField = value
                Me.RaisePropertyChanged("id")
            End Set
        End Property

        ''' <summary>
        ''' тип оверлея
        ''' </summary>
        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property type() As emOverlayType
            Get
                Return Me.typeField
            End Get
            Set(ByVal value As emOverlayType)
                Me.typeField = value
                Me.RaisePropertyChanged("type")
            End Set
        End Property

        <System.Xml.Serialization.XmlIgnore> _
        Public ReadOnly Property filename As String
            Get
                Return IO.Path.GetFileName(Me.overlayhref)
            End Get
        End Property

        ''' <summary>
        ''' источник картинки оверлея
        ''' </summary>
        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property overlayhref() As String
            Get
                Return Me.overlayhrefField
            End Get
            Set(ByVal value As String)
                Me.overlayhrefField = value
                Me.RaisePropertyChanged("overlayhref")
            End Set
        End Property

        ''' <summary>
        ''' содержание элемента (сами данные)
        ''' </summary>
        ''' <remarks/>
        <System.Xml.Serialization.XmlTextAttribute()> _
        Public Property Text() As String
            Get
                Return Me.textField
            End Get
            Set(ByVal value As String)
                Me.textField = value
                Me.RaisePropertyChanged("Text")
            End Set
        End Property

        ''' <param name="id">артикул/ИД</param>
        ''' <param name="overlayhref">ссылка на графический файл картинки наложения</param>
        ''' <param name="type">тип наложения (стрелка, блок и тп)</param>
        ''' <param name="visible">показать/скрыть наложение</param>
        ''' <param name="opacity">прозрачность 0..1</param>
        ''' <param name="position">положение наложения относительно графической карты (верх.лев. угол)</param>
        ''' <param name="overlaysize">отображаемый размер наложения</param>
        ''' <param name="overlaytext">текст, отображаемый в наложении</param>
        Public Shared Function CreateInstance(id As String, overlayhref As String, type As emOverlayType, visible As Boolean, opacity As Single, position As Drawing.Point, overlaysize As Drawing.Size, overlaytext As String) As CATALOGSAMPLEMAPOVERLAY
            Dim _ov As New CATALOGSAMPLEMAPOVERLAY
            With _ov
                .id = id
                .overlayhref = overlayhref
                .type = type
                .visible = visible
                .opacity = opacity
                .dx = position.X
                .dy = position.Y
                .height = overlaysize.Height
                .width = overlaysize.Width
                .Text = overlaytext
            End With
            Return _ov
        End Function





        Protected Sub RaisePropertyChanged(ByVal propertyName As String)
            Dim propertyChanged As System.ComponentModel.PropertyChangedEventHandler = Me.PropertyChangedEvent
            If (Not (propertyChanged) Is Nothing) Then
                propertyChanged(Me, New System.ComponentModel.PropertyChangedEventArgs(propertyName))
            End If
        End Sub
        ''' <summary>
        ''' вернет id/name
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overrides Function ToString() As String
            Return id
        End Function


        Public Event PropertyChanged(sender As Object, e As System.ComponentModel.PropertyChangedEventArgs) Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged

        Public Enum emOverlayType
            arrow
            block
        End Enum
        Public Function Clone() As CATALOGSAMPLEMAPOVERLAY
            Return xClone()
        End Function

        Private Function xClone() As Object Implements System.ICloneable.Clone
            Dim _clon As New CATALOGSAMPLEMAPOVERLAY
            With _clon
                .dx = Me.dx
                .dy = Me.dy
                .height = Me.height
                .id = Me.id
                .opacity = Me.opacity
                .overlayhref = Me.overlayhref
                .Text = Me.Text
                .type = Me.type
                .visible = Me.visible
                .width = Me.width
            End With
            Return _clon
        End Function

        Public Overrides Function Equals(obj As Object) As Boolean
            If obj Is Nothing Then Return False
            If Not TypeOf (obj) Is CATALOGSAMPLEMAPOVERLAY Then Return False
            If Not Me.GetHashCode = obj.GetHashCode Then Return False
            Return True
        End Function

        Public Overrides Function GetHashCode() As Integer
            Return Me.id.GetHashCode Xor Me.Position.GetHashCode Xor Me.Size.GetHashCode Xor Me.type.GetHashCode
        End Function

        Public Function CompareTo(obj As Object) As Integer Implements System.IComparable.CompareTo
            If obj Is Nothing Then Return 0
            If Not TypeOf (obj) Is CATALOGSAMPLEMAPOVERLAY Then Return 0
            'сортировка по id
            If Me.id.CompareTo(obj.id) = 0 Then
                Return Me.type.CompareTo(obj.type)
            Else
                Return Me.id.CompareTo(obj.id)
            End If

        End Function
    End Class
End Namespace
