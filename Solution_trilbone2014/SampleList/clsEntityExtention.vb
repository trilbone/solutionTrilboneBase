Imports System.Runtime.CompilerServices
Imports System.Data.Objects

Module ModelSampleListExtention
    ''' <summary>
    ''' эта функция выполнит локальный запрос к контексту. Если он вернет 0, то выполнит запрос к БД. вернет IEnumerable(of T)
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="a"></param>
    ''' <param name="objectSet"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Extension()>
    Public Function Local(Of T As Class)(a As ModelSampleListContainer, objectSet As ObjectSet(Of T)) As IEnumerable(Of T)
        Dim _result = From stateEntry In objectSet.Context.ObjectStateManager.GetObjectStateEntries(EntityState.Added Or EntityState.Modified Or EntityState.Unchanged)
                      Where (stateEntry.Entity IsNot Nothing) And (stateEntry.EntitySet.Equals(objectSet.EntitySet)) Select stateEntry.Entity

        If _result.Count = 0 Then
            'выполним запрос к БД
            Return CType(objectSet.Execute(MergeOption.AppendOnly), IEnumerable(Of T))
        Else
            'локальный вызов
            Return _result.Cast(Of T)()
        End If
    End Function
    ''' <summary>
    ''' эта функция выполнит локальный запрос к контексту. Если он вернет 0, то выполнит запрос к БД. вернет List(of T)
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="a"></param>
    ''' <param name="objectSet"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Extension()>
    Public Function LocalAsList(Of T As Class)(a As ModelSampleListContainer, objectSet As ObjectSet(Of T)) As IList(Of T)
        Return Local(Of T)(a, objectSet).ToList
    End Function

End Module

Partial Public Class SampleList
    Implements IComparable
    Implements IComparer
    Implements IComparable(Of SampleList)
    Implements IComparer(Of SampleList)
#Region "перегрузки Object и реализации интерфейсов"


    Public Overrides Function Equals(obj As Object) As Boolean
        If obj Is Nothing Then Return False
        If Not obj.GetType.Equals(GetType(SampleList)) Then Return False

        'compare
        Dim _compareobj = CType(obj, SampleList)

        If Not _compareobj.IDList = Me.IDList Then Return False
        If Not String.Equals(_compareobj.ListName, Me.ListName, StringComparison.InvariantCultureIgnoreCase) Then Return False

        Return True
    End Function

    Public Overrides Function GetHashCode() As Integer
        Return Me.IDList.GetHashCode Xor Me.ListName.GetHashCode
    End Function

    Public Overrides Function ToString() As String
        Return Me.ListName
    End Function

    Public Overloads Function CompareTo(obj As Object) As Integer Implements System.IComparable.CompareTo
        If Not obj.GetType.Equals(GetType(SampleList)) Then Return 1
        Return String.Compare(Me.ListName, CType(obj, SampleList).ListName)
    End Function

    Public Overloads Function Compare(x As Object, y As Object) As Integer Implements System.Collections.IComparer.Compare
        Return CompareTo(y)
    End Function

    Public Overloads Function CompareTo(other As SampleList) As Integer Implements System.IComparable(Of SampleList).CompareTo
        Return CompareTo(other)
    End Function

    Public Overloads Function Compare(x As SampleList, y As SampleList) As Integer Implements System.Collections.Generic.IComparer(Of SampleList).Compare
        Return CompareTo(y)
    End Function
#End Region
End Class

Partial Public Class ModelSampleListContainer
   

End Class
Partial Public Class SampleInList
    Implements IComparable
    Implements IComparable(Of SampleAndList)
    Implements IComparer
    Implements IComparer(Of SampleAndList)
#Region "перегрузки Object и реализации интерфейсов"
    Public Overrides Function Equals(obj As Object) As Boolean
        If obj Is Nothing Then Return False
        If Not obj.GetType.Equals(GetType(SampleInList)) Then Return False

        'compare
        Dim _compareobj = CType(obj, SampleInList)

        If Not _compareobj.IDSample = Me.IDSample Then Return False
        If Not String.Equals(_compareobj.SampleNumber, Me.SampleNumber, StringComparison.InvariantCultureIgnoreCase) Then Return False

        Return True
    End Function

    Public Overrides Function GetHashCode() As Integer
        Return Me.IDSample.GetHashCode Xor Me.SampleNumber.GetHashCode
    End Function

    Public Overrides Function ToString() As String
        Return Me.SampleNumber
    End Function

    Public Overloads Function CompareTo(obj As Object) As Integer Implements System.IComparable.CompareTo
        If Not obj.GetType.Equals(GetType(SampleInList)) Then Return 1
        Return String.Compare(Me.SampleNumber, CType(obj, SampleInList).SampleNumber)
    End Function

    Public Overloads Function CompareTo(other As SampleAndList) As Integer Implements System.IComparable(Of SampleAndList).CompareTo
        Return CompareTo(other)
    End Function

    Public Overloads Function Compare(x As Object, y As Object) As Integer Implements System.Collections.IComparer.Compare
        Return Me.CompareTo(y)
    End Function

    Public Overloads Function Compare(x As SampleAndList, y As SampleAndList) As Integer Implements System.Collections.Generic.IComparer(Of SampleAndList).Compare
        Return Me.CompareTo(y)
    End Function
#End Region



End Class

'Public Class SampleListService
'    Public Function TryGetEAN13(value As String) As SampleAndList

'    End Function



'    Public Function GetSampleInfoAsText() As String

'    End Function
'End Class