Partial Public Class tbSMOperation

    Public Overrides Function ToString() As String

        Dim _out As String = ""

        Select Case Me.SMWorkOperationID
            Case 1
                If Me.Remark.Length > 0 Then
                    _out = "<" & Me.Remark & ">"
                Else
                    _out = "<обязательно опишите операцию>"
                End If
            Case Else
                _out = Me.tbSMWorkOperation.Name
        End Select


        Return _out
    End Function

End Class

Partial Public Class tbActualWord
    Implements IComparable

    Public Function CompareTo(obj As Object) As Integer Implements IComparable.CompareTo
        If Not TypeOf obj Is tbActualWord Then Return 0
        Return CType(obj, tbActualWord).Word.CompareTo(Me.Word)
    End Function
End Class

