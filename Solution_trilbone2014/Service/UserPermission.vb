﻿'------------------------------------------------------------------------------
' <auto-generated>
'     Этот код создан программой.
'     Исполняемая версия:4.0.30319.34014
'
'     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
'     повторной генерации кода.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On

Imports System.Xml.Serialization
Imports System.Linq
'
'Этот исходный код был создан с помощью xsd, версия=4.0.30319.33440.
'
Namespace User

    '''<remarks/>

    <System.SerializableAttribute(), _
    System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True), _
     System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=False)> _
    Partial Public Class USER
        Inherits Object
        Implements System.ComponentModel.INotifyPropertyChanged

        Private wOKERField() As USERWOKER

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute("WOKER")> _
        Public Property WOKER() As USERWOKER()
            Get
                Return Me.wOKERField
            End Get
            Set(value As USERWOKER())
                Me.wOKERField = value
                Me.RaisePropertyChanged("WOKER")
            End Set
        End Property

        Public Event PropertyChanged As System.ComponentModel.PropertyChangedEventHandler Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged

        Protected Sub RaisePropertyChanged(ByVal propertyName As String)
            Dim propertyChanged As System.ComponentModel.PropertyChangedEventHandler = Me.PropertyChangedEvent
            If (Not (propertyChanged) Is Nothing) Then
                propertyChanged(Me, New System.ComponentModel.PropertyChangedEventArgs(propertyName))
            End If
        End Sub

        ''' <summary>
        ''' читает файл настроек пользователей
        ''' </summary>
        ''' <param name="manager"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function CreateInstance() As USER
            Dim _path = IO.Path.Combine(Service.clsApplicationTypes.TemplateFolderPath, My.Settings.UserFileName)
            Dim _out As New USER()
            If IO.File.Exists(_path) Then
                'read template file
                Dim _s = IO.File.ReadAllText(_path)
                _out = USER.ParseFile(_s)
            Else
                Service.clsApplicationTypes.TemplateFolderPath = ""
                Return Nothing
            End If
            Return _out
        End Function

        ''' <summary>
        ''' создает пользователя
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function CreateUser(id As Integer, name As String, pin As String) As clsUser
            '<WOKER id="14" name="Иван Гусев" pin="1234" pass="" role="employee" roletype="preparator">
            '  <OFFICEACCESS officename="petrogradka" role="employee" roletype="preparator">
            '    <ACCESS product="trilbone" resource="Вход в систему">
            '      <COMPUTER name="ALL"></COMPUTER>
            '    </ACCESS>
            '  <ACCESS product="trilbone" resource="Вход в trilbone">
            '      <COMPUTER name="ALL"></COMPUTER>
            '    </ACCESS>
            '  </OFFICEACCESS>
            '</WOKER>
            Dim _user = New USERWOKER
            With _user
                .id = id
                .name = name
                .pin = pin
                '.role = ""
                '.roletype = ""
            End With
            Dim _tmp = Me.wOKERField.ToList
            _tmp.Add(_user)
            Me.wOKERField = _tmp.ToArray
            Return New clsUser With {.UserPermission = _user, .UserShotName = _user.name}
        End Function

        ''' <summary>
        ''' сосхранить файл 
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub SaveFile()
            'save file
            Dim _path = IO.Path.Combine(Service.clsApplicationTypes.TemplateFolderPath, My.Settings.UserFileName)
            IO.File.WriteAllText(_path, Me.GetXML)
        End Sub

        ''' <summary>
        ''' читает (разбирает) из строки
        ''' </summary>
        Private Shared Function ParseFile(ByVal xmlString As String) As USER
            If xmlString.Length = 0 Then
                MsgBox("в ParseFile передана пустая строка")
                Return Nothing
            End If


            Dim _USER As USER

            Dim _rdsett As New Xml.XmlReaderSettings
            Dim _xmlSerializer As Xml.Serialization.XmlSerializer = New Xml.Serialization.XmlSerializer(GetType(USER))
            Dim _xmlreader As Xml.XmlReader
            Dim _strBuilt As IO.StringReader


            'schema
            Dim _sh As New Xml.Schema.XmlSchema
            _strBuilt = New IO.StringReader(My.Resources.Resource.UserPermission)
            Dim _xmlsh = New Xml.Schema.XmlSchemaSet()
            _xmlsh.Add(Xml.Schema.XmlSchema.Read(_strBuilt, AddressOf ValidationEventHandler))

            'catalog
            _strBuilt = New IO.StringReader(xmlString)

            With _rdsett
                .CloseInput = True
                .IgnoreComments = True
                .Schemas = _xmlsh
            End With

            _xmlreader = Xml.XmlReader.Create(_strBuilt, _rdsett)
            _USER = _xmlSerializer.Deserialize(_xmlreader)
            _xmlreader.Close()
            Try


            Catch ex As Exception
                MsgBox("Can't read xml: " & ex.Message)

                Return Nothing

            End Try


            Return _USER

        End Function
        Protected Shared Sub ValidationEventHandler(ByVal sender As Object, ByVal e As System.Xml.Schema.ValidationEventArgs)
            MsgBox("Schema incorrect: " & e.Message)

        End Sub
        ''' <summary>
        ''' вернет всех пользователей из файла
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetUsers() As List(Of clsUser)
            Dim _result = (From c In Me.WOKER Select New clsUser With {.UserPermission = c, .UserShotName = c.name}).ToList
            Return _result
        End Function

        Public ReadOnly Property UserCount As Integer
            Get
                If WOKER Is Nothing Then Return 0
                Return WOKER.Length
            End Get
        End Property


        ''' <summary>
        ''' возвращает строку xml
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function GetXML() As String

            Dim _wrsett As New Xml.XmlWriterSettings
            Dim _xmlSerializer As Xml.Serialization.XmlSerializer
            Dim _xmlwriter As Xml.XmlWriter
            Dim _strBuilt As New System.Text.StringBuilder

            _xmlSerializer = New Xml.Serialization.XmlSerializer(GetType(USER))
            With _wrsett
                .Encoding = System.Text.Encoding.GetEncoding("windows-1251")
                .Indent = True
            End With

            _xmlwriter = Xml.XmlWriter.Create(_strBuilt, _wrsett)
            _xmlSerializer.Serialize(_xmlwriter, Me)
            _xmlwriter.Flush()
            _xmlwriter.Close()


            Return _strBuilt.ToString

        End Function


    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"), _
     System.SerializableAttribute(), _
        System.ComponentModel.DesignerCategoryAttribute("code"), _
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)> _
    Partial Public Class USERWOKER
        Inherits Object
        Implements System.ComponentModel.INotifyPropertyChanged

        Private oFFICEACCESSField() As USERWOKEROFFICEACCESS

        Private idField As String

        Private nameField As String

        Private pinField As String

        Private passField As String

        Private roleField As String

        Private mcuuidField As String

        Private roletypeField As String

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute("OFFICEACCESS")> _
        Public Property OFFICEACCESS() As USERWOKEROFFICEACCESS()
            Get
                Return Me.oFFICEACCESSField
            End Get
            Set(value As USERWOKEROFFICEACCESS())
                Me.oFFICEACCESSField = value
                Me.RaisePropertyChanged("OFFICEACCESS")
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property id() As String
            Get
                Return Me.idField
            End Get
            Set(value As String)
                Me.idField = value
                Me.RaisePropertyChanged("id")
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property name() As String
            Get
                Return Me.nameField
            End Get
            Set(value As String)
                Me.nameField = value
                Me.RaisePropertyChanged("name")
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property pin() As String
            Get
                Return Me.pinField
            End Get
            Set(value As String)
                Me.pinField = value
                Me.RaisePropertyChanged("pin")
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property pass() As String
            Get
                Return Me.passField
            End Get
            Set(value As String)
                Me.passField = value
                Me.RaisePropertyChanged("pass")
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property role() As String
            Get
                Return Me.roleField
            End Get
            Set(value As String)
                Me.roleField = value
                Me.RaisePropertyChanged("role")
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property mcuuid() As String
            Get
                Return Me.mcuuidField
            End Get
            Set(value As String)
                Me.mcuuidField = value
                Me.RaisePropertyChanged("mcuuid")
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property roletype() As String
            Get
                Return Me.roletypeField
            End Get
            Set(value As String)
                Me.roletypeField = value
                Me.RaisePropertyChanged("roletype")
            End Set
        End Property

        Public Event PropertyChanged As System.ComponentModel.PropertyChangedEventHandler Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged

        Protected Sub RaisePropertyChanged(ByVal propertyName As String)
            Dim propertyChanged As System.ComponentModel.PropertyChangedEventHandler = Me.PropertyChangedEvent
            If (Not (propertyChanged) Is Nothing) Then
                propertyChanged(Me, New System.ComponentModel.PropertyChangedEventArgs(propertyName))
            End If
        End Sub

        Public Function GetAccess(resource As String) As Boolean
            'проверка доступа к ресурсу
            If Me.OFFICEACCESS Is Nothing Then Return False

            Dim _result = (From c In Me.OFFICEACCESS Where Not (c.ACCESS Is Nothing) From c1 In c.ACCESS Where String.Equals(c1.resource.ToLower, resource.ToLower, StringComparison.CurrentCultureIgnoreCase) Select c1).ToList


            If _result.Count = 0 Then Return False

            'проверка имени компьютера
            Dim _res = (From c In _result Where Not (c.COMPUTER Is Nothing) From c1 In c.COMPUTER Where (String.Equals(c1.name.ToLower, clsApplicationTypes.MachineName.ToLower, StringComparison.CurrentCultureIgnoreCase) Or String.Equals(c1.name, "ALL", StringComparison.CurrentCultureIgnoreCase)) Select c).FirstOrDefault

            If _res Is Nothing Then Return False

            Return True

        End Function
        ''' <summary>
        ''' список ресурсов по продукту
        ''' </summary>
        ''' <param name="product"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetAccessListByProductName(product As String) As List(Of String)
            'проверка доступа к ресурсу
            Dim _out = New List(Of String)
            If Me.OFFICEACCESS Is Nothing Then Return _out

            Dim _result = (From c In Me.OFFICEACCESS Where Not (c.ACCESS Is Nothing) From c1 In c.ACCESS Where String.Equals(c1.product.ToLower, product.ToLower, StringComparison.CurrentCultureIgnoreCase) Select c1).ToList


            If _result.Count = 0 Then Return _out

            'проверка имени компьютера
            Dim _res = (From c In _result Where Not (c.COMPUTER Is Nothing) From c1 In c.COMPUTER Where (String.Equals(c1.name.ToLower, clsApplicationTypes.MachineName.ToLower, StringComparison.CurrentCultureIgnoreCase) Or String.Equals(c1.name, "ALL", StringComparison.CurrentCultureIgnoreCase)) Select c).FirstOrDefault

            If _res Is Nothing Then Return _out

            _out = (From c In _result Select c.resource).ToList

            Return _out
        End Function

    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code"), _
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)> _
    Partial Public Class USERWOKEROFFICEACCESS
        Inherits Object
        Implements System.ComponentModel.INotifyPropertyChanged

        Private aCCESSField() As USERWOKEROFFICEACCESSACCESS

        Private pHISYCALACCESSField() As USERWOKEROFFICEACCESSPHISYCALACCESS

        Private officenameField As String

        Private roleField As String

        Private roletypeField As String

        Private sidkeyField As String

        Private MCPauseField As String

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute("ACCESS")> _
        Public Property ACCESS() As USERWOKEROFFICEACCESSACCESS()
            Get
                Return Me.aCCESSField
            End Get
            Set(value As USERWOKEROFFICEACCESSACCESS())
                Me.aCCESSField = Value
                Me.RaisePropertyChanged("ACCESS")
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute("PHISYCALACCESS")> _
        Public Property PHISYCALACCESS() As USERWOKEROFFICEACCESSPHISYCALACCESS()
            Get
                Return Me.pHISYCALACCESSField
            End Get
            Set(value As USERWOKEROFFICEACCESSPHISYCALACCESS())
                Me.pHISYCALACCESSField = Value
                Me.RaisePropertyChanged("PHISYCALACCESS")
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property officename() As String
            Get
                Return Me.officenameField
            End Get
            Set(value As String)
                Me.officenameField = Value
                Me.RaisePropertyChanged("officename")
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property role() As String
            Get
                Return Me.roleField
            End Get
            Set(value As String)
                Me.roleField = Value
                Me.RaisePropertyChanged("role")
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property roletype() As String
            Get
                Return Me.roletypeField
            End Get
            Set(value As String)
                Me.roletypeField = Value
                Me.RaisePropertyChanged("roletype")
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property sidkey() As String
            Get
                Return Me.sidkeyField
            End Get
            Set(value As String)
                Me.sidkeyField = Value
                Me.RaisePropertyChanged("sidkey")
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property MCpause() As String
            Get
                Return Me.MCPauseField
            End Get
            Set(value As String)
                Me.MCPauseField = value
                Me.RaisePropertyChanged("MCpause")
            End Set
        End Property

        Public Event PropertyChanged As System.ComponentModel.PropertyChangedEventHandler Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged

        Protected Sub RaisePropertyChanged(ByVal propertyName As String)
            Dim propertyChanged As System.ComponentModel.PropertyChangedEventHandler = Me.PropertyChangedEvent
            If (Not (propertyChanged) Is Nothing) Then
                propertyChanged(Me, New System.ComponentModel.PropertyChangedEventArgs(propertyName))
            End If
        End Sub
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code"), _
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)> _
    Partial Public Class USERWOKEROFFICEACCESSACCESS
        Inherits Object
        Implements System.ComponentModel.INotifyPropertyChanged

        Private cOMPUTERField() As USERWOKEROFFICEACCESSACCESSCOMPUTER

        Private productField As String

        Private resourceField As String

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute("COMPUTER")> _
        Public Property COMPUTER() As USERWOKEROFFICEACCESSACCESSCOMPUTER()
            Get
                Return Me.cOMPUTERField
            End Get
            Set(value As USERWOKEROFFICEACCESSACCESSCOMPUTER())
                Me.cOMPUTERField = value
                Me.RaisePropertyChanged("COMPUTER")
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property product() As String
            Get
                Return Me.productField
            End Get
            Set(value As String)
                Me.productField = Value
                Me.RaisePropertyChanged("product")
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property resource() As String
            Get
                Return Me.resourceField
            End Get
            Set(value As String)
                Me.resourceField = Value
                Me.RaisePropertyChanged("resource")
            End Set
        End Property

        Public Event PropertyChanged As System.ComponentModel.PropertyChangedEventHandler Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged

        Protected Sub RaisePropertyChanged(ByVal propertyName As String)
            Dim propertyChanged As System.ComponentModel.PropertyChangedEventHandler = Me.PropertyChangedEvent
            If (Not (propertyChanged) Is Nothing) Then
                propertyChanged(Me, New System.ComponentModel.PropertyChangedEventArgs(propertyName))
            End If
        End Sub
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code"), _
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)> _
    Partial Public Class USERWOKEROFFICEACCESSACCESSCOMPUTER
        Inherits Object
        Implements System.ComponentModel.INotifyPropertyChanged

        Private nameField As String
        Private MCPauseField As String

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property name() As String
            Get
                Return Me.nameField
            End Get
            Set(value As String)
                Me.nameField = Value
                Me.RaisePropertyChanged("name")
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property MCpause() As String

            Get
                If String.IsNullOrEmpty(Me.MCPauseField) Then
                    Me.MCPauseField = "0"
                End If
                Return Me.MCPauseField
            End Get
            Set(value As String)
                Me.MCPauseField = value
                Me.RaisePropertyChanged("MCpause")
            End Set
        End Property

        Public Event PropertyChanged As System.ComponentModel.PropertyChangedEventHandler Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged

        Protected Sub RaisePropertyChanged(ByVal propertyName As String)
            Dim propertyChanged As System.ComponentModel.PropertyChangedEventHandler = Me.PropertyChangedEvent
            If (Not (propertyChanged) Is Nothing) Then
                propertyChanged(Me, New System.ComponentModel.PropertyChangedEventArgs(propertyName))
            End If
        End Sub
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code"), _
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)> _
    Partial Public Class USERWOKEROFFICEACCESSPHISYCALACCESS
        Inherits Object
        Implements System.ComponentModel.INotifyPropertyChanged

        Private roomField As String

        Private roomidField As Byte

        Private timelimitfromField As Date

        Private timelimitfromFieldSpecified As Boolean

        Private timelimittoField As Date

        Private timelimittoFieldSpecified As Boolean

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property room() As String
            Get
                Return Me.roomField
            End Get
            Set(value As String)
                Me.roomField = Value
                Me.RaisePropertyChanged("room")
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property roomid() As Byte
            Get
                Return Me.roomidField
            End Get
            Set(value As Byte)
                Me.roomidField = Value
                Me.RaisePropertyChanged("roomid")
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute(DataType:="time")> _
        Public Property timelimitfrom() As Date
            Get
                Return Me.timelimitfromField
            End Get
            Set(value As Date)
                Me.timelimitfromField = Value
                Me.RaisePropertyChanged("timelimitfrom")
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()> _
        Public Property timelimitfromSpecified() As Boolean
            Get
                Return Me.timelimitfromFieldSpecified
            End Get
            Set(value As Boolean)
                Me.timelimitfromFieldSpecified = Value
                Me.RaisePropertyChanged("timelimitfromSpecified")
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute(DataType:="time")> _
        Public Property timelimitto() As Date
            Get
                Return Me.timelimittoField
            End Get
            Set(value As Date)
                Me.timelimittoField = Value
                Me.RaisePropertyChanged("timelimitto")
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()> _
        Public Property timelimittoSpecified() As Boolean
            Get
                Return Me.timelimittoFieldSpecified
            End Get
            Set(value As Boolean)
                Me.timelimittoFieldSpecified = Value
                Me.RaisePropertyChanged("timelimittoSpecified")
            End Set
        End Property

        Public Event PropertyChanged As System.ComponentModel.PropertyChangedEventHandler Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged

        Protected Sub RaisePropertyChanged(ByVal propertyName As String)
            Dim propertyChanged As System.ComponentModel.PropertyChangedEventHandler = Me.PropertyChangedEvent
            If (Not (propertyChanged) Is Nothing) Then
                propertyChanged(Me, New System.ComponentModel.PropertyChangedEventArgs(propertyName))
            End If
        End Sub
    End Class
End Namespace
