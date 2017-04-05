Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Service
Imports System.Windows.Forms
<TestClass()> Public Class Service_test

    ''' <summary>
    ''' округлитель цены до конечных нулей (zerous) --> 151.23=150 при zerous=1
    ''' </summary>
    ''' <param name="price"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function RoundPrice(price As Decimal, Optional zerous As Integer = -1) As Decimal
        Dim _tmp As Decimal
        If zerous = -1 Then
            'включаем умное округление
            If price < 10 Then
                'типа 5,23
                Return Decimal.Round(price, 1)

            ElseIf price < 100 Then
                'типа 89,23 = 90 // 81.35=85
                _tmp = price / (10 ^ 1)
                Dim _bg = Decimal.Truncate(_tmp) * 10
                If (price - _bg) > 5 Then
                    Return _bg + 10
                Else
                    Return _bg + 5
                End If
            ElseIf price < 1000 Then
                'типа 123,45=125
                _tmp = price / (10 ^ 1)
                Dim _bg = Decimal.Truncate(_tmp) * 10
                If (price - _bg) > 5 Then
                    Return _bg + 10
                Else
                    Return _bg + 10
                End If
            ElseIf price < 10000 Then
                'типа 5624,25 = 5650
                _tmp = price / (10 ^ 2)
                Dim _bg = Decimal.Truncate(_tmp) * 100
                If (price - _bg) > 50 Then
                    Return _bg + 100
                Else
                    Return _bg + 50
                End If
            ElseIf price < 100000 Then
                'типа 45625.25 = 45600
                zerous = 2
            Else
                'типа 456254.25 = 456000
                zerous = 3
            End If
        End If

        If price < 10 ^ zerous Then
            Return RoundPrice(price, (zerous - 1))
        End If
        _tmp = Decimal.Ceiling(price) / (10 ^ zerous)
        _tmp = Decimal.Ceiling(_tmp)
        Return _tmp * (10 ^ zerous)
    End Function

    Private Shared Function ParsePrepString(PrepString As String, ByRef TotalHour As Decimal, ByRef TotalSalary As Decimal) As Boolean
        If String.IsNullOrEmpty(PrepString) Then Return False
        Dim _preps = PrepString.Split(";".ToCharArray, System.StringSplitOptions.RemoveEmptyEntries)
        If _preps.Count = 0 Then Return False
        Dim _totalHours As Decimal = 0
        Dim _totalSalary As Decimal = 0

        For Each p In _preps
            Dim _ps = p.Split("(")
            If _ps.Length < 2 Then Return False
            If Not _ps(1).Contains("*") Then Return False

            Dim _name = _ps(0)
            If Not String.IsNullOrEmpty(_name) Then
                Dim _hour As Decimal
                Dim _salary As Decimal
                Dim _out As New KeyValuePair(Of String, KeyValuePair(Of Decimal, Decimal))

                If Decimal.TryParse(_ps(1).Split("*")(0), _hour) Then
                    If Decimal.TryParse(_ps(1).TrimEnd(")").Split("*")(1), _salary) Then
                        _out = New KeyValuePair(Of String, KeyValuePair(Of Decimal, Decimal))(_name, New KeyValuePair(Of Decimal, Decimal)(_hour, _salary))

                        _totalHours += _hour
                        _totalSalary += _salary
                    End If
                End If
            End If
        Next
        TotalHour = _totalHours
        TotalSalary = _totalSalary
        Return True

    End Function

    <TestMethod()> Public Sub RoundPrice()
        'Dim _pr As Decimal = 2.334112233
        '_pr = 7.689765
        'Dim _out As String = ""

        'For d = -1 To 5
        '    For i = 0 To 5
        '        Dim _t = _pr * (10 ^ i)
        '        _out += String.Format("{0}(digits {1}) = {2}{3}", _t, d, RoundPrice(_t, d), ChrW(13))
        '    Next
        'Next

        Dim _th As Decimal
        Dim _ts As Decimal
        Dim _res = ParsePrepString("sad(2*150;hs(1*300);", _th, _ts)
        Dim _out = String.Format("{0} = {1} hours  {2} pay", _res, _th, _ts)
        MsgBox(_out)

    End Sub
    <TestMethod()> Public Sub execDB()
        'Trilbone_load.ModuleMain.initService()
        'Dim _db = clsApplicationTypes.SampleDataObject

        'Dim _res = _db.FindInSampleRecordsByTitlePart("claw")

        ''MsgBox(_res.title)
        ''перебрать строки из ответа
        'For Each t In _res
        '    '  MsgBox(String.Format("строка {2}: поле {0} = {1}", k.Key, k.Value.ToString, _index))
        'Next
    End Sub
    <TestMethod()> Public Sub resourceReader()
        Dim _list = clsApplicationTypes.dbQweryList

        Dim _val = clsApplicationTypes.GetSqlByResourceName(_list.FirstOrDefault)

        MsgBox(_val)
    End Sub

    <TestMethod()> Public Sub ucDbReader()
        Trilbone_load.ModuleMain.initService()
        Dim _uc = New uc_DataQwery
        _uc.init()

        Dim _fm As New Form
        _fm.Size = _uc.Size
        _fm.Controls.Add(_uc)
        _fm.Show()
        Application.Run(_fm)
    End Sub


    <TestMethod()> Public Sub SampleNumberAskLocation()
        Trilbone_load.ModuleMain.initService()
        Do While clsApplicationTypes.MoySklad(False) Is Nothing
            Threading.Thread.Sleep(1000)
        Loop
        Dim _num As String
        '8-5250 остаток 0
        '8-2446 остаток 1 в резерве
        '8-3903 остаток 1
        '8-2035 на двух складах
ex:
        _num = "8-2407-7"
        Dim _sm = clsApplicationTypes.clsSampleNumber.CreateFromString(_num)
        If _sm.CodeIsCorrect Then
            MsgBox(_sm.AskLocations())
        End If
        GoTo ex


    End Sub

    ''' <summary>
    ''' заменяет текст в последних скобках
    ''' </summary>
    ''' <param name="value"></param>
    ''' <param name="replaceText"></param>
    ''' <returns></returns>
    Private Function ReplaceInSkobki(value As String, replaceText As String, Optional startchar As Char = "(", Optional endchar As Char = ")") As String
        Dim _splitter = New Char() {startchar, endchar}

        Dim _arr = value.Split(_splitter, StringSplitOptions.RemoveEmptyEntries)

        Dim _out As String = ""

        Select Case _arr.Count
            Case 1
                'нет скобок
                _out = value
            Case 2
                'есть одна скобка
                _out = String.Format("{0} {2}{1}{3}", _arr(0), replaceText, startchar.ToString, endchar.ToString)

            Case Else
                'более одной скобки
                For i = 0 To _arr.Count - 2
                    If ((i + 1) Mod 2) = 0 Then
                        'четные - добавить открывающую скобку
                        _out += " " & startchar.ToString
                    End If

                    _out += _arr(i).Trim

                    If ((i + 1) Mod 2) = 0 Then
                        'нечетные - добавить закрывающую скобку
                        _out += endchar.ToString & " "
                    End If
                Next
                'изменяем последние
                _out += String.Format(" {1}{0}{2}", replaceText, startchar.ToString, endchar.ToString)
        End Select
        Return _out
    End Function

    <TestMethod()> Public Sub SkobkiNameTest()
        Dim _ans = ReplaceInSkobki(value:="Авантюрин зелёный (Бразилия) галтовка ML (10-15 г)", replaceText:="150-200 гр")
        MsgBox(_ans)
    End Sub

    <TestMethod()> Public Sub RejectSkobki()
        Dim _qw = "abc(wer)"

        Dim _an = ""

        Dim _out As String = ""
        Dim _split = _qw.Split({","}, StringSplitOptions.RemoveEmptyEntries)
        For Each t In _split
            If t.Contains("(") And t.Contains(")") Then
                Dim _index1 = t.IndexOf("(")
                Dim _index2 = t.IndexOf(")")
                Dim _er = t.Substring(_index1, _index2 - _index1 + 1)
                _out += t.Replace(_er, "").Trim
                _out += ","
            Else
                _out += t
                _out += ","
            End If
        Next
        If String.IsNullOrEmpty(_out) Then _out = _qw
        _out = _out.TrimEnd(",")


        MsgBox(_out)
    End Sub

End Class