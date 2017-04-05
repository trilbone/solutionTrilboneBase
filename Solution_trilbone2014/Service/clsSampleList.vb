Imports Service.clsApplicationTypes
Imports System.Xml.Linq
Imports System.Linq

<Serializable()>
Public Class clsSampleListItem
    ''' <summary>
    ''' имя образца
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Name As String = ""
    ''' <summary>
    ''' имя образца
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property NickName As String = ""
    ''' <summary>
    ''' shot number
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property ShotNumber As String
        Get
            If SampleNumber Is Nothing Then Return ""
            Return SampleNumber.ShotCode
        End Get
    End Property
    ''' <summary>
    ''' ean13 number
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property SampleNumberEAN13 As String
        Get
            If SampleNumber Is Nothing Then Return ""
            Return SampleNumber.EAN13
        End Get
    End Property
    ''' <summary>
    ''' полное описание образца
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property DescriptionTXT As String
        Get
            If SampleNumber Is Nothing Then Return ""
            Return SampleNumber.GetExtendedInfo.DescriptionString
        End Get
    End Property
    ''' <summary>
    ''' ссылка на страницу описания имени в инете
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property LinkToName As String
    ''' <summary>
    ''' цена в валютных еденицах
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Price As Decimal

    Public Sub New()
        oDateOfCreate = Now
    End Sub
    Private oDateOfCreate As Date
    Public ReadOnly Property DateOfCreate As Date
        Get
            Return oDateOfCreate
        End Get
    End Property

    ''' <summary>
    ''' валюта цены
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Currency As String

    ''' <summary>
    ''' вернет xml для элемента списка
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetNodeXML() As XElement
        Dim _xml As XElement = <SAMPLE shot=<%= Me.ShotNumber %> shotname=<%= Me.NickName %> date=<%= Me.DateOfCreate.ToShortDateString %>>
                                   <%= If(Me.Name = Me.SampleNumberEAN13, Nothing, <FULLNAME><%= Me.Name %></FULLNAME>) %>
                                   <%= If(Me.LinkToName = "", Nothing, <LINK href=<%= Me.LinkToName %>></LINK>) %>
                               </SAMPLE>
        Return _xml
    End Function


    ''' <summary>
    ''' генерирует строку для вставки в файл CSV
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetCSVLine(Comma As String, Optional GoodType As String = "", Optional Currency As String = "USD") As String
        If Comma = "" Then Comma = ";"
        If Me.Currency = "" Then Me.Currency = Currency
        'надо выяснить знак валюты
        Dim a As String = ""
        a += Me.SampleNumber.EAN13 + Comma
        a += Me.SampleNumber.ShotCode + Comma
        a += Me.Name + Comma
        a += Me.NickName + Comma
        a += Me.Price.ToString + Comma
        a += Me.Currency
        If Not GoodType = "" Then
            a += Comma + GoodType
        End If
        'в дальнейшем сделать комбинатор символа и валюты, а также конверсию
        'a += Me.StringPrice + comma
        a += ChrW(13)
        Return a
    End Function

    Private oSampleNumber As clsApplicationTypes.clsSampleNumber

    Public Property SampleNumber As clsApplicationTypes.clsSampleNumber
        Get
            Return oSampleNumber
        End Get
        Set(value As clsApplicationTypes.clsSampleNumber)
            oSampleNumber = value
        End Set
    End Property


    Public Overrides Function Equals(obj As Object) As Boolean
        If Not obj.GetType = GetType(clsSampleListItem) Then Return False
        Dim _in = CType(obj, clsSampleListItem)
        If Not String.Compare(_in.SampleNumberEAN13, Me.SampleNumberEAN13, True) = 0 Then Return False
        If Not String.Compare(_in.Name, Me.Name, True) = 0 Then Return False
        Return True
    End Function
    ''' <summary>
    ''' обновляет поля из БД
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Refresh()
        If Not Me.SampleNumber Is Nothing Then
            With Me.SampleNumber.GetExtendedInfo(True)
                Me.Currency = .Prices.Currency
                Me.Name = .SampleName
                Me.NickName = .SampleNickName
                Me.Price = .Prices.BasePrice
            End With
        End If
    End Sub


    Public Overrides Function GetHashCode() As Integer
        If Me.SampleNumberEAN13 Is Nothing Or Me.Name Is Nothing Then Return 0
        Return Me.SampleNumberEAN13.GetHashCode Xor Me.Name.GetHashCode
    End Function

    Public Overrides Function ToString() As String
        Return Me.ShotNumber
    End Function
End Class


<Serializable()>
Public Class clsSampleList
    Inherits List(Of clsSampleListItem)

    ''' <summary>
    ''' name of list
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Xml.Serialization.XmlElement("LISTNAME")>
    Public Property NameOfList As String
    Public Property Parent As clsSampleListManager
    ''' <summary>
    ''' обновить все образцы
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub RefreshAll()
        For Each t In Me
            t.Refresh()
        Next
    End Sub

    Public Overloads Function Contains(SampleNumber As clsApplicationTypes.clsSampleNumber) As Boolean
        Dim _item = Me.Find(Function(x) (x.SampleNumberEAN13.Equals(SampleNumber.EAN13)))
        If _item Is Nothing Then
            Return False
        Else
            Return True
        End If
    End Function

    ''' <summary>
    ''' 1 = ok // -1 = error  // 0 = уже есть в списке
    ''' </summary>
    ''' <param name="SampleNumber"></param>
    ''' <param name="Name"></param>
    ''' <param name="Price"></param>
    ''' <param name="Currency"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function Add(SampleNumber As clsApplicationTypes.clsSampleNumber, ByVal Name As String, Optional ShotName As String = "", Optional ByVal Price As Decimal = 0, Optional ByVal Currency As String = "USD") As Integer
        'check in list
        If Not Me.Find(Function(x) (x.SampleNumberEAN13.Equals(SampleNumber.GetEan13))) Is Nothing Then
            'уже есть в списке
            Return 0
        End If
        Dim _new = New clsSampleListItem
        '_new.SampleNumberEAN13 = SampleNumber.GetEan13 -- from extended
        '_new.ShotNumber = SampleNumber.ShotCode -- from extended
        _new.Name = Name
        _new.Price = Price
        _new.Currency = Currency
        _new.NickName = ShotName
        '_new.DescriptionTXT = SampleNumber.GetExtendedInfo.DescriptionString -- from extended
        _new.SampleNumber = SampleNumber
        Me.Add(_new)
        Return 1
    End Function
    Public Overloads Function Remove(SampleNumber As clsApplicationTypes.clsSampleNumber) As Boolean
        Dim _tmp = Me.Find(Function(x) (x.SampleNumberEAN13 = SampleNumber.EAN13))
        If Not _tmp Is Nothing Then
            'уже есть в списке
            Me.Remove(_tmp)
            Return True
        End If
        Return False
    End Function

    ''' <summary>
    ''' description of list
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Xml.Serialization.XmlElement("DESCR")>
    Public Property Description As String
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetListXML() As XElement
        Dim _xml As XElement = <LIST name=<%= Me.NameOfList %>>
                                   <%= From c As clsSampleListItem In Me Select c.GetNodeXML %>
                                   <%= If(Me.Description = "", Nothing, <INFO><%= Me.Description %></INFO>) %>
                               </LIST>
        Return _xml
    End Function


    ''' <summary>
    ''' вернет csv файл для коллекции
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetCSV(comma As String, Optional GoodType As String = "", Optional Currency As String = "USD") As String
        Dim a As String = ""
        For Each t In Me
            a += t.GetCSVLine(comma, GoodType, Currency)
        Next
        Return a
    End Function

    Public Overrides Function Equals(obj As Object) As Boolean
        If Not obj.GetType = GetType(clsSampleList) Then Return False
        Dim _in = CType(obj, clsSampleList)
        If Not String.Compare(_in.NameOfList, Me.NameOfList, True) = 0 Then Return False
        Return True
    End Function

    Public Overrides Function GetHashCode() As Integer
        Return NameOfList.GetHashCode
    End Function

    Public Overrides Function ToString() As String
        Return NameOfList + "  contains " + Me.Count + "pcs."
    End Function
End Class

Public Interface iListSampleDataProvider
    Event WriteSampleToList(sender As Object, e As clsWriteSampleToListEventsArg)
End Interface

Public Class clsWriteSampleToListEventsArg
    Inherits EventArgs
    Public Property SampleNumber As clsSampleNumber
    ''' <summary>
    ''' по умолчанию, будет авто нажата кнопка добавить номер
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property AutoWrite As Boolean = True
End Class

