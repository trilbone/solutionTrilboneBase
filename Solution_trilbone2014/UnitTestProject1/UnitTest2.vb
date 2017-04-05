Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Service
<TestClass()> Public Class UnitTest_parceNumbers

    <TestMethod()> Public Sub TestMethod_parceBuffer()
        'get from buffer
        If Not My.Computer.Clipboard.ContainsText Then
            MsgBox("В буфере обмена нет текста!", vbIgnore)
            Return
        End If

        Dim _buff = Me.ParceClip(My.Computer.Clipboard.GetText()).Distinct

        MsgBox(_buff.Count)

    End Sub

    ''' <summary>
    ''' разпознает список номеров в буфере
    ''' </summary>
    ''' <param name="data"></param>
    ''' <returns></returns>
    Private Function ParceClip(data As String) As List(Of Service.clsApplicationTypes.clsSampleNumber)
        Dim _out As New List(Of clsApplicationTypes.clsSampleNumber)
        Dim _pattern = {ChrW(13), ChrW(10)}
        Dim _result = data.Split(_pattern, StringSplitOptions.RemoveEmptyEntries)
        For Each t In _result
            If t.Length <= 13 Then
                Dim _num = clsApplicationTypes.clsSampleNumber.CreateFromString(t)
                If _num.CodeIsCorrect Then
                    _out.Add(_num)
                End If
            End If
        Next
        Return _out
    End Function
End Class