Imports System.Globalization

Public Class clsWobject

    ''' <summary>
    ''' строка даты текущая
    ''' </summary>
    Public ReadOnly Property NowString As String
        Get
            Dim _date = Now
            Dim _cult = My.Application.Culture
            _cult.DateTimeFormat.Calendar = New GregorianCalendar
            Return _date.ToString(_cult)
        End Get
    End Property

    ''' <summary>
    ''' создает обьект сотрудника по ПИН
    ''' </summary>
    Public Shared Function CreateInstance(pin As String) As clsWobject

    End Function

End Class
