Imports System.Linq

Namespace Catalog

    ''' <summary>
    ''' описывает тег описания к типу образца(например, About trilobites)
    ''' </summary>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.21006.1"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code"), _
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)> _
    Partial Public Class CATALOGSAMPLEROOTINFO
        Inherits Object
        Implements System.ComponentModel.INotifyPropertyChanged
        Implements IComparable

        Dim textField As String
        Dim idField As String
        Dim captionField As String



        Public Event PropertyChanged(sender As Object, e As System.ComponentModel.PropertyChangedEventArgs) Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged
        ''' <summary>
        ''' сам текст
        ''' </summary>
        <System.Xml.Serialization.XmlTextAttribute()> _
        Public Property Text As String
            Get
                Return Me.textField
            End Get
            Set(ByVal value As String)
                Me.textField = value
                Me.RaisePropertyChanged("Text")
            End Set
        End Property

        ''' <summary>
        ''' ИД элемента
        ''' </summary>
        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property id() As String
            Get
                Return Me.idField
            End Get
            Set(ByVal value As String)
                Me.idField = value
                Me.RaisePropertyChanged("name")
            End Set
        End Property

        ''' <summary>
        ''' заголовок
        ''' </summary>
        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property caption() As String
            Get
                Return Me.captionField
            End Get
            Set(ByVal value As String)
                Me.captionField = value
                Me.RaisePropertyChanged("caption")
            End Set
        End Property

        Public Shared Function CreateInstance(id As String, caption As String, textfield As String) As CATALOGSAMPLEROOTINFO
            Dim _root As New CATALOGSAMPLEROOTINFO
            With _root
                .id = id
                .caption = caption
                .Text = textfield
            End With

            Return _root
        End Function

        Protected Sub RaisePropertyChanged(ByVal propertyName As String)
            Dim propertyChanged As System.ComponentModel.PropertyChangedEventHandler = Me.PropertyChangedEvent
            If (Not (propertyChanged) Is Nothing) Then
                propertyChanged(Me, New System.ComponentModel.PropertyChangedEventArgs(propertyName))
            End If
        End Sub

        Public Overrides Function Equals(obj As Object) As Boolean
            If obj Is Nothing Then Return False
            If Not TypeOf (obj) Is CATALOGSAMPLEROOTINFO Then Return False
            If Not Me.GetHashCode = obj.GetHashCode Then Return False
            Return True
        End Function

        Public Overrides Function GetHashCode() As Integer
            Return id.GetHashCode Xor caption.GetHashCode
        End Function

        Public Overrides Function ToString() As String
            Return caption
        End Function

        Public Function CompareTo(obj As Object) As Integer Implements System.IComparable.CompareTo
            If obj Is Nothing Then Return 0
            If Not TypeOf (obj) Is CATALOGSAMPLEROOTINFO Then Return 0
            Return Me.id.CompareTo(obj.id)
        End Function
    End Class



    ''' <summary>
    ''' Описывает графическую карту образца
    ''' </summary>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.21006.1"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code"), _
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)> _
    <System.Xml.Serialization.XmlRoot("MAP")>
    Partial Public Class CATALOGELEMENTMAP
        Inherits Object
        Implements System.ComponentModel.INotifyPropertyChanged
        Implements ICloneable
        Implements IComparable



        Dim hrefField As String


        Dim idField As String


        Private textField As String
        Dim oVERLAYField As CATALOGSAMPLEMAPOVERLAY()




        ''' <summary>
        ''' вернуть xml конкретного образца (тег SAMPLE с содержимым)
        ''' </summary>
        Public Function GetXML() As String
            Dim _wrsett As New Xml.XmlWriterSettings
            Dim _xmlSerializer As Xml.Serialization.XmlSerializer
            Dim _xmlwriter As Xml.XmlWriter
            Dim _strBuilt As New System.Text.StringBuilder

            _xmlSerializer = New Xml.Serialization.XmlSerializer(GetType(CATALOGELEMENTMAP))
            With _wrsett
                .Encoding = System.Text.Encoding.GetEncoding("windows-1251")
                .Indent = True
                .NamespaceHandling = Xml.NamespaceHandling.OmitDuplicates
                .OmitXmlDeclaration = False
            End With

            _xmlwriter = Xml.XmlWriter.Create(_strBuilt, _wrsett)
            _xmlSerializer.Serialize(_xmlwriter, Me)
            _xmlwriter.Flush()
            _xmlwriter.Close()


            Return _strBuilt.ToString

        End Function

        <System.Xml.Serialization.XmlIgnore> _
        Public ReadOnly Property FileName As String
            Get
                Return IO.Path.GetFileName(Me.hrefField)
            End Get
        End Property


        ''' <summary>
        ''' ссылка на источник графической карты
        ''' </summary>
        ''' <remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property href() As String
            Get
                Return Me.hrefField
            End Get
            Set(ByVal value As String)
                Me.hrefField = value
                Me.RaisePropertyChanged("href")
            End Set
        End Property




        ''' <summary>
        ''' имя файла деревьев (тип материала)
        ''' </summary>
        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property id() As String
            Get
                Return Me.idField
            End Get
            Set(ByVal value As String)
                Me.idField = value
                Me.RaisePropertyChanged("id")
            End Set
        End Property






        ''' <summary>
        ''' набор покрывающих элементов (стрелка и тп)
        ''' </summary>
        <System.Xml.Serialization.XmlArrayItemAttribute("OVERLAY", IsNullable:=False)> _
        Public Property LAYERS() As CATALOGSAMPLEMAPOVERLAY()
            Get
                Return oVERLAYField
            End Get
            Set(value As CATALOGSAMPLEMAPOVERLAY())
                oVERLAYField = value
                Me.RaisePropertyChanged("LAYERS")
            End Set
        End Property




        ''' <summary>
        ''' заголовок графической карты
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


        Public Shared Function CreateInstance(id As String, href As String, textfield As String) As CATALOGELEMENTMAP
            Dim _map As New CATALOGELEMENTMAP
            With _map
                .id = id
                .href = href
                .Text = textfield
            End With
            Return _map
        End Function

        Protected Sub RaisePropertyChanged(ByVal propertyName As String)
            Dim propertyChanged As System.ComponentModel.PropertyChangedEventHandler = Me.PropertyChangedEvent
            If (Not (propertyChanged) Is Nothing) Then
                propertyChanged(Me, New System.ComponentModel.PropertyChangedEventArgs(propertyName))
            End If
        End Sub

        Public Function RemoveOverlay(overlay As CATALOGSAMPLEMAPOVERLAY) As Boolean
            Dim _result = From c In Me.oVERLAYField Where (Not c.Equals(overlay)) Select c
            If _result.Count = oVERLAYField.Count Then Return False
            Me.LAYERS = _result.ToArray
            Return True
        End Function


        Public Overloads Function AddOverlay(id As String, overlayhref As String, type As CATALOGSAMPLEMAPOVERLAY.emOverlayType, visible As Boolean, opacity As Single, position As Drawing.Point, overlaysize As Drawing.Size, overlaytext As String) As CATALOGSAMPLEMAPOVERLAY
            Dim _data = CATALOGSAMPLEMAPOVERLAY.CreateInstance(id, overlayhref, type, visible, opacity, position, overlaysize, overlaytext)
            Me.AddOverlay(_data)
            Return _data
        End Function
        Public Overloads Function AddOverlay(ByVal DataElement As CATALOGSAMPLEMAPOVERLAY) As Integer
            If Me.oVERLAYField Is Nothing Then
                Me.LAYERS = {DataElement}
                Return 0
            Else
                Dim _index As Integer = Me.oVERLAYField.Length
                ReDim Preserve Me.oVERLAYField(_index)

                Me.LAYERS(_index) = DataElement
                Return _index
            End If
        End Function

        ''' <summary>
        ''' читает (разбирает) из строки
        ''' </summary>
        Public Shared Function ParseMapCollection(ByVal xmlString As String) As List(Of CATALOGELEMENTMAP)
            If xmlString.Length = 0 Then
                MsgBox("004. в ParseMapCollection передана пустая строка")
                Return Nothing
            End If


            Dim _maps As List(Of CATALOGELEMENTMAP)

            Dim _rdsett As New Xml.XmlReaderSettings
            Dim _xmlSerializer As Xml.Serialization.XmlSerializer = New Xml.Serialization.XmlSerializer(GetType(List(Of CATALOGELEMENTMAP)))
            Dim _xmlreader As Xml.XmlReader
            Dim _strBuilt As IO.StringReader


            ''schema
            'Dim _sh As New Xml.Schema.XmlSchema
            '_strBuilt = New IO.StringReader(My.Resources.XMLVisualCatalog)
            'Dim _xmlsh = New Xml.Schema.XmlSchemaSet()
            '_xmlsh.Add(Xml.Schema.XmlSchema.Read(_strBuilt, AddressOf ValidationEventHandler))

            'catalog
            _strBuilt = New IO.StringReader(xmlString)

            With _rdsett
                .CloseInput = True
                .IgnoreComments = True
                '.Schemas = _xmlsh
            End With


            Try

                _xmlreader = Xml.XmlReader.Create(_strBuilt, _rdsett)
                _maps = _xmlSerializer.Deserialize(_xmlreader)
                _xmlreader.Close()
            Catch ex As Exception
                MsgBox("005. Can't read xml: " & ex.Message)

                Return Nothing

            End Try


            Return _maps

        End Function

        ''' <summary>
        ''' возвращает строку xml
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function GetXMLOfCollection(maps As List(Of CATALOGELEMENTMAP)) As String

            Dim _wrsett As New Xml.XmlWriterSettings
            Dim _xmlSerializer As Xml.Serialization.XmlSerializer
            Dim _xmlwriter As Xml.XmlWriter
            Dim _strBuilt As New System.Text.StringBuilder

            _xmlSerializer = New Xml.Serialization.XmlSerializer(GetType(List(Of CATALOGELEMENTMAP)))
            With _wrsett
                .Encoding = System.Text.Encoding.GetEncoding("windows-1251")
                .Indent = True
            End With

            _xmlwriter = Xml.XmlWriter.Create(_strBuilt, _wrsett)
            _xmlSerializer.Serialize(_xmlwriter, maps)
            _xmlwriter.Flush()
            _xmlwriter.Close()

            Return _strBuilt.ToString

        End Function
        ''' <summary>
        ''' вернет text
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overrides Function ToString() As String
            Return id
        End Function


        Public Event PropertyChanged(sender As Object, e As System.ComponentModel.PropertyChangedEventArgs) Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged

        Public Function Clone(Optional withoutOverlay As Boolean = False) As CATALOGELEMENTMAP
            Dim _new As CATALOGELEMENTMAP = Me.xClone
            If withoutOverlay Then
                _new.LAYERS = Nothing
            End If
            Return _new
        End Function


        Private Function xClone() As Object Implements System.ICloneable.Clone
            Dim _new As New CATALOGELEMENTMAP
            With _new
                .href = Me.href
                .id = Me.id
                .Text = Me.Text
                If Not Me.LAYERS Is Nothing Then
                    Dim _list As New List(Of CATALOGSAMPLEMAPOVERLAY)
                    For Each _ov As CATALOGSAMPLEMAPOVERLAY In Me.LAYERS
                        _list.Add(_ov.Clone)
                    Next
                    .LAYERS = _list.ToArray
                End If

            End With
            Return _new
        End Function

        Public Overrides Function Equals(obj As Object) As Boolean
            If obj Is Nothing Then Return False
            If Not TypeOf (obj) Is CATALOGELEMENTMAP Then Return False
            If Not Me.GetHashCode = obj.GetHashCode Then Return False
            Return True

        End Function

        Public Overrides Function GetHashCode() As Integer
            Return id.GetHashCode Xor href.GetHashCode
        End Function

        Public Function CompareTo(obj As Object) As Integer Implements System.IComparable.CompareTo
            If obj Is Nothing Then Return 0
            If Not TypeOf (obj) Is CATALOGELEMENTMAP Then Return 0
            Return Me.id.CompareTo(obj.id)
        End Function
    End Class
End Namespace
