Imports System.Xml.Serialization
Imports System.Xml
Imports System.Windows.Forms

''' <summary>
''' класс обработки слов
''' </summary>
''' <remarks></remarks>
Public Class clsWord
    Implements IEquatable(Of clsWord)
    Implements IEqualityComparer(Of clsWord)
    Implements IComparable(Of clsWord)

    Public Property Word As String
    Public Property Count As Integer
    Public Property LinkedItemsID As List(Of String)

    Public Overrides Function ToString() As String
        Return Word.ToUpper & " --> " & Count.ToString
    End Function

    Public Overrides Function Equals(obj As Object) As Boolean
        If obj Is Nothing Then Return MyBase.Equals(obj)
        If Not TypeOf obj Is clsWord Then Return MyBase.Equals(obj)

        If Me.Word.Equals(obj.Word) And Me.Count = obj.count Then Return True

        Return False

    End Function

    Public Overrides Function GetHashCode() As Integer
        Return (Me.Word.GetHashCode Xor Me.Count.GetHashCode)
    End Function

    Public Function Equals1(other As clsWord) As Boolean Implements IEquatable(Of clsWord).Equals
        Return Me.Equals(other)
    End Function

    Public Function CompareTo(other As clsWord) As Integer Implements IComparable(Of clsWord).CompareTo
        Return Me.Word.CompareTo(other.Word)
        'If other.Count.CompareTo(Me.Count) = 0 Then

        'End If

        'Return other.Count.CompareTo(Me.Count)

        'If Me.Word.CompareTo(other.Word) = 0 Then
        '    Return Me.Count.CompareTo(other.Count)
        'End If

        'Return Me.Word.CompareTo(other.Word)
    End Function

    Public Function Equals2(x As clsWord, y As clsWord) As Boolean Implements IEqualityComparer(Of clsWord).Equals
        If x Is Nothing Then Return MyBase.Equals(x)
        If y Is Nothing Then Return MyBase.Equals(y)

        If x.Word.ToLower.Equals(y.Word.ToLower) Then Return True

        Return False
    End Function

    Public Function GetHashCode1(obj As clsWord) As Integer Implements IEqualityComparer(Of clsWord).GetHashCode
        Return obj.Word.ToLower.GetHashCode
    End Function
End Class
'============================
'============================
'============================

''' <summary>
''' 
''' </summary>
''' <remarks></remarks>
Public Class clsFindingService

    Public Sub New()
        ''. сервис формы fmMoySklad
        ''привязываем делегат к функции
        ''передаем делегат (регестрируем) и список в сервисном классе
        'clsApplicationTypes.DelegateStoreApplicationForm _
        '    (emFormsList.fmEbaySearch) = _
        '    New ApplicationFormDelegateFunction(AddressOf GetTrilboneEbayFormAsForm)
    End Sub

    Private Function GetTrilboneEbayFormAsForm(param As Object) As Form
        Dim _new = New fmEbaySearch

        If param Is Nothing Then
            Return _new
        End If

        If TypeOf param Is String Then

            Dim _value As String = param
            _new.SetSearchFrase(_value)
        End If
        Return _new
    End Function


    ''' <summary>
    ''' вернет список слов (от 3х символов) из листингов (с частотой?)
    ''' </summary>
    ''' <param name="list"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetWords(list As List(Of eBayFindingServiceReference.SearchItem), Optional removeNoiseWords As Boolean = False) As List(Of clsWord)
        If list Is Nothing Then Return New List(Of clsWord)
        Dim _res = From c In list Let words = c.title.Split(" ".ToCharArray, StringSplitOptions.RemoveEmptyEntries) From word In words Let a = c Let lword = word.ToLower Group word, a By lword Into mygr = Group Let corrword = String.Concat(From wch In lword Where Char.IsLetter(wch) Select wch) Where corrword.Length > 2 Select New clsWord With {.Count = mygr.Count, .Word = corrword, .LinkedItemsID = (From c In mygr Select c.a.itemId).ToList}


        Dim _list = _res.ToList

        'If removeNoiseWords Then
        '    'remove Noise
        '    Dim _exlist = (From c In Service.clsApplicationTypes.SampleDataObject.GetdbReadySampleObjectContext.tbNoiseWord Select New clsWord With {.Word = c.Word.ToLower, .Count = -1}).AsEnumerable

        '    _list = (_list.Except(_exlist, New clsWord)).ToList

        'End If


        _list.Sort()

        Return _list

    End Function







    ''' <summary>
    ''' вернет список обьектов итемов из WDSL ebay
    ''' </summary>
    ''' <param name="keywords"></param>
    ''' <param name="CategoryID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Find(keywords As String, CategoryID As String) As List(Of eBayFindingServiceReference.SearchItem)

        Dim _criteria As New EbaySearchCriteria
        With _criteria
            .Keywords = keywords
            .Categories = CategoryID
        End With

        Return EbayHelper.GetWebQuery(_criteria)
        'Dim _result = From c In _respond Select clsMSObjectReader(Of eBayFindingServiceReference.SearchItem).CreatInstance(c.XML)


        'Static _query As EbayQuery(Of EbayItem)

        'If _query Is Nothing Then
        '    _query = New EbayQuery(Of EbayItem)
        'End If

        'Dim _result = (From c In _query Where c.Description = keywords And c.Categories = CategoryID Group By c.ItemID Into Group Select clsMSObjectReader(Of eBayFindingServiceReference.SearchItem).CreatInstance(Group.First.XML))
        ' Return _result.ToList

    End Function

    Public Shared Function GetSingleItem(ItemID As String) As eBayShopping.SimpleItemType

        Dim _result = EbayHelper.GetSingleItem(ItemID)

        Dim _xres = _result

        If _xres...<error>.Count > 0 Then
            'error
            Return Nothing
        End If
        Dim _ns = XName.Get("Item", "urn:ebay:apis:eBLBaseComponents")
        Dim _str = _xres.Element(_ns).ToString

        Dim _obj = GetSimpleItemResponse(_str)

        Return _obj
    End Function

    Private Shared Function GetSimpleItemResponse(xmlstring As String) As eBayShopping.SimpleItemType

        Static _xmlsettings As Xml.XmlReaderSettings
        Static _xml As Xml.Serialization.XmlSerializer
        If _xml Is Nothing Then
            _xml = New Xml.Serialization.XmlSerializer(GetType(eBayShopping.SimpleItemType), "urn:ebay:apis:eBLBaseComponents")
            _xmlsettings = New Xml.XmlReaderSettings
            With _xmlsettings
                .CheckCharacters = True
                .ValidationType = Xml.ValidationType.None
                .ConformanceLevel = Xml.ConformanceLevel.Fragment
            End With
        End If

        Dim _txt As New System.IO.StringReader(xmlstring)



        Dim _xreader = Xml.XmlReader.Create(_txt, _xmlsettings)

        Try
            Dim _obj = _xml.Deserialize(_xreader)

            Dim _result = TryCast(_obj, eBayShopping.SimpleItemType)
            Return _result
        Catch ex As Exception
            MsgBox("Ошибка десериализации " & ex.Message, vbCritical)
            Return Nothing
        End Try

    End Function


    ''' <summary>
    ''' служебный класс десериализации обьектов-наследников accountEntity
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <remarks></remarks>
    Friend Class clsMSObjectReader(Of T As eBayFindingServiceReference.SearchItem)
        ''' <summary>
        ''' создает обьект
        ''' </summary>
        ''' <param name="xmlString"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Shared Function CreatInstance(xmlString As String) As T
            Static _xmlsettings As Xml.XmlReaderSettings
            Static _xml As Xml.Serialization.XmlSerializer
            If _xml Is Nothing Then
                _xml = New Xml.Serialization.XmlSerializer(GetType(T), "http://www.ebay.com/marketplace/search/v1/services")
                _xmlsettings = New Xml.XmlReaderSettings
                With _xmlsettings
                    .CheckCharacters = True
                    .ValidationType = Xml.ValidationType.None
                    .ConformanceLevel = Xml.ConformanceLevel.Fragment
                End With
            End If

            Dim _txt As New System.IO.StringReader(xmlString)



            Dim _xreader = Xml.XmlReader.Create(_txt, _xmlsettings)

            Try
                Dim _obj = _xml.Deserialize(_xreader)

                Dim _result = TryCast(_obj, T)
                Return _result
            Catch ex As Exception
                MsgBox("Ошибка десериализации " & ex.Message, vbCritical)
                Return Nothing
            End Try

        End Function

    End Class

End Class
