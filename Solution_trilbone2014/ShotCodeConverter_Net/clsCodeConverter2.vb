
Public Class clsCode
    ''' <summary>
    ''' увеличит подномер на 1 (или заданную величину)
    ''' </summary>
    ''' <param name="steps"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function IncreaceSubnumber(Optional steps As Integer = 1) As clsCode
        If Me.oSeries = "101" Then Return Me
        If Not oSubNumber = 9 Then
            oSubNumber += steps
        Else
            oSubNumber = 0
        End If
        Return Me
    End Function

    ''' <summary>
    ''' уменьшит подномер на 1 (или заданную величину)
    ''' </summary>
    ''' <param name="steps"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function DecreaceSubnumber(Optional steps As Integer = 1) As clsCode
        If Me.oSeries = "101" Then Return Me
        oSubNumber -= steps
        If oSubNumber < 0 Then
            oSubNumber = 9
        End If
        Return Me
    End Function

    ''' <summary>
    ''' увеличит номер на 1 (или заданную величину)
    ''' </summary>
    ''' <param name="steps"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function IncreaceNumber(Optional steps As Integer = 1) As clsCode
        oNumber += steps
        Return Me
    End Function

    ''' <summary>
    '''  уменьшит номер на 1 (или заданную величину)
    ''' </summary>
    ''' <param name="steps"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function DecreaceNumber(Optional steps As Integer = 1) As clsCode
        oNumber -= steps
        If oNumber < 0 Then oNumber = 0
        Return Me
    End Function


    ''' <summary>
    ''' серия кода 1,3,4 знака
    ''' </summary>
    Public ReadOnly Property Series As String
        Get
            Return oSeries
        End Get

    End Property

    ''' <summary>
    ''' номер кода (5 знаков)
    ''' </summary>
    Public ReadOnly Property Number As Decimal
        Get
            Return oNumber
        End Get

    End Property

    ''' <summary>
    ''' храним что нибудь
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Tag As Object


    ''' <summary>
    ''' артикул(доп номер) 1 знак
    ''' </summary>
    Public ReadOnly Property SubNumber As Integer
        Get
            Return oSubNumber
        End Get

    End Property




    ''' <summary>
    ''' короткий код
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property ShotCode(Optional GetFullSeries As Boolean = False) As String
        Get
            Dim _result As String = ""
            If Me.CodeType = emCodeType.Incorrect Then
                Return "без номера"
            End If
            If oSubNumber = 0 Then
                If GetFullSeries Then
                    Return Me.oSeries & My.Settings.CodeSplitter & oNumber
                End If
                Select Case Me.Owner
                    Case "1", "2", "9"
                        _result += Me.oSeries
                    Case Else
                        _result += Me.Owner
                End Select
                _result += My.Settings.CodeSplitter & oNumber
                Return _result
            Else
                If GetFullSeries Then
                    Return Me.oSeries & My.Settings.CodeSplitter & oNumber & My.Settings.CodeSplitter & oSubNumber
                End If
                Select Case Me.Owner
                    Case "1", "2", "9"
                        _result += Me.oSeries
                    Case Else
                        _result += Me.Owner
                End Select
                _result += My.Settings.CodeSplitter & oNumber & My.Settings.CodeSplitter & oSubNumber
                Return _result
            End If
        End Get
    End Property
    ''' <summary>
    ''' вернет короткий код
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overrides Function ToString() As String
        Return Me.ShotCode
    End Function

    ''' <summary>
    ''' штрих-код EAN13
    ''' </summary>
    Public ReadOnly Property EAN13 As Decimal
        Get
            If Not Me.CodeType = emCodeType.EAN13 Then Return 0

            Dim ofmSelectMaterial As New fmSelectMaterial

            'генерация ean
            Dim _ean As String = ""
            Dim i As Integer
            Select Case oSeries.Length
                Case 1
                    'восстановить серию до полной = 3 знака
                    Select Case Owner
                        '====================1====================
                        Case "1"
                            ofmSelectMaterial.cbMaterial.Items.Clear()
                            ofmSelectMaterial.cbMaterial.Items.Add("о5 венд")
                            ofmSelectMaterial.cbMaterial.Items.Add("Devexus о3")
                            ofmSelectMaterial.tbCode.Text = Me.ShotCode
                            ofmSelectMaterial.ShowDialog()
                            i = ofmSelectMaterial.cbMaterial.SelectedIndex
                            Select Case i
                                Case 0
                                    oSeries = "101"
                                Case 1
                                    oSeries = "122"
                                Case Else
                                    Return 0
                            End Select
                            '=============================2
                        Case "2"
                            ofmSelectMaterial.cbMaterial.Items.Clear()
                            ofmSelectMaterial.cbMaterial.Items.Add("трилобиты о4")
                            ofmSelectMaterial.cbMaterial.Items.Add("венд о4")
                            ofmSelectMaterial.cbMaterial.Items.Add("кембрий о4")
                            ofmSelectMaterial.cbMaterial.Items.Add("кембрий сдача")
                            ofmSelectMaterial.cbMaterial.Items.Add("раники для плиты(временно)")
                            ofmSelectMaterial.tbCode.Text = Me.ShotCode
                            ofmSelectMaterial.ShowDialog()
                            i = ofmSelectMaterial.cbMaterial.SelectedIndex
                            Select Case i
                                Case 0
                                    oSeries = "202"
                                Case 1
                                    oSeries = "220"
                                Case 2
                                    oSeries = "201"
                                Case 3
                                    oSeries = "200"
                                Case 4
                                    oSeries = "272"
                                Case Else
                                    Return 0
                            End Select
                        Case "3"
                            oSeries = "312"
                        Case "4"
                            oSeries = "402"
                        Case "5"
                            Select Case oNumber
                                Case Is > 65
                                    'ВНИМАНИЕ !!! заменен код после номера 65 на новую основу 502
                                    oSeries = "502"
                                Case Else
                                    'номера равно или менее 65 по старой основе 512
                                    oSeries = "512"
                            End Select
                        Case "6"
                            oSeries = "602"
                        Case "7"
                            oSeries = "702"
                        Case "8"
                            oSeries = "802"
                        Case "9"
                            ofmSelectMaterial.cbMaterial.Items.Clear()
                            ofmSelectMaterial.cbMaterial.Items.Add("сырые литвинов")
                            ofmSelectMaterial.cbMaterial.Items.Add("сырые о2")
                            ofmSelectMaterial.tbCode.Text = Me.ShotCode
                            ofmSelectMaterial.ShowDialog()
                            i = ofmSelectMaterial.cbMaterial.SelectedIndex
                            Select Case i
                                Case 0
                                    oSeries = "902"
                                Case 1
                                    oSeries = "982"
                                Case Else
                                    Return 0
                            End Select
                        Case Else
                            Return 0
                    End Select
                Case 2
                    'невозможно
                    Debug.Fail("logic error!!")
                    Return 0
                Case 3
                    'все ок
                Case 4
                    'не ean13
                    Return 0
            End Select
            'восстановление серии
            Dim _firspart As String = ""
            For Each t As String In My.Settings.OldSeriesColl
                If t.StartsWith(oSeries) Then
                    _firspart = t
                End If
            Next
            If _firspart = "" Then
                _firspart = oSeries & "00"
            End If
            'номер
            Dim _num As String = ""
            'If oNumber.ToString.Length > 5 Then Return Nothing
            Select Case oNumber.ToString.Length
                Case 1
                    _num = "0000" & oNumber.ToString
                Case 2
                    _num = "000" & oNumber.ToString
                Case 3
                    _num = "00" & oNumber.ToString
                Case 4
                    _num = "0" & oNumber.ToString
                Case 5
                    _num = oNumber.ToString
                Case Else
                    Debug.Fail("номер более 5ти знаков!")
                    Return 0
            End Select
            'субномер
            Dim _subnum As String = ""
            Select Case oSubNumber.ToString.Length
                Case 1
                    _subnum = "0" & oSubNumber.ToString
                Case 2
                    _subnum = oSubNumber.ToString
                Case Else
                    Debug.Fail("Суб номер более 2х знаков!")
                    Return 0
            End Select

            'совместимость с кодами 10120, 98290, 90290
            Select Case _firspart
                Case "10120"
                    _ean = EAN13CheckSumGenerate(_firspart & "21" & _num)
                Case "98290"
                    _ean = EAN13CheckSumGenerate(_firspart & "20" & _num)
                Case "90290"
                    _ean = EAN13CheckSumGenerate(_firspart & "20" & _num)
                Case Else
                    _ean = EAN13CheckSumGenerate(_firspart & _subnum & _num)
            End Select

            'If oSeries = "101" Then
            '    _ean = EAN13CheckSumGenerate(_firspart & "1" & _num)
            'Else
            '    _ean = EAN13CheckSumGenerate(_firspart & _subnum & _num)
            'End If

            If _ean.Length = 13 Then
                Return Decimal.Parse(_ean)
            End If

            Return 0
        End Get
    End Property

    Private oSeries As String

    Private oNumber As Integer

    Private oSubNumber As Integer

    ''' <summary>
    ''' владелец (первая цифра кода для EAN13), для других кодов совпадает с серией
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Owner As String
        Get
            If Me.oCodeType = emCodeType.EAN13 Then
                Return oSeries.Substring(0, 1)
            End If
            Return oSeries
        End Get
    End Property
    ''' <summary>
    ''' проверка строки на наличие букв
    ''' </summary>
    ''' <param name="str"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function OnlyDigit(str As String) As Boolean
        Dim _out As Boolean = True
        For Each t As Char In str.ToCharArray
            If Char.IsDigit(t) Then
                _out = True
            Else
                Return False
            End If
        Next
        Return _out
    End Function
    ''' <summary>
    ''' разделитель кода
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property CodeSplitter As Char
        Get
            Dim _sp As Char() = My.Settings.CodeSplitter.ToCharArray
            Return _sp(0)
        End Get
    End Property

    ''' <summary>
    ''' принимает 2-134; 502-238; EAN13; abc-254; 8-48-1; 8021-48
    ''' </summary>
    ''' <remarks>
    ''' разделитель "-"
    ''' первый блок = хозяин или тип материала 3 знака для ean13 или 4 знака
    ''' второй блок = номер (5 знаков)
    ''' третий блок (опционально 1 знак) = артикул
    ''' </remarks>
    ''' <param name="code">строка кода</param>
    Public Shared Function CreateInstance(code As String, Optional ByRef _status As Integer = 0) As clsCode
        Dim _converter As New clsCode

        If code Is Nothing Then _status = -1 : _converter.oCodeType = emCodeType.Incorrect : Return _converter
        If code = "" Then _status = -1 : _converter.oCodeType = emCodeType.Incorrect : Return _converter
        If code.Length < 3 Then _status = -1 : _converter.oCodeType = emCodeType.Incorrect : Return _converter

        Dim _arr As String() = code.Split(My.Settings.CodeSplitter.ToCharArray, System.StringSplitOptions.RemoveEmptyEntries)

        Select Case _arr.Length
            Case 0
                'невозможно))
                _status = -1
                _converter.oCodeType = emCodeType.Incorrect
                Return _converter

            Case 1
                'разделителя нет в коде. может EAN13?
                If Not code.Length = 13 Then _status = -1 : _converter.oCodeType = emCodeType.Incorrect : Return _converter
                If OnlyDigit(code) = False Then _status = -1 : _converter.oCodeType = emCodeType.Incorrect : Return _converter

                'проверка контрольной
                Dim _controlDigit As String = (code.Substring(12, 1))
                If Not EAN13CheckSumGenerate(code.Substring(0, 12)).Equals(code) Then
                    'ошибка контрольной суммы
                    _status = -2 : _converter.oCodeType = emCodeType.Incorrect : Return _converter
                End If

                'разбор ean13: 1-3 цифры = серия - задается нормативами
                'Префикс национальной организации GS1 или  (префиксы с 200 по 299) для внутреннего использования ==> 213
                _converter.oSeries = code.Substring(0, 3)

                'подсерия 4-5 цифры (типа 802/21-4555-1) (макс. 99)
                'нет реализации

                'доп. номер 6-7 цифры (макс. 99)
                Dim _subnumber As String = code.Substring(5, 2)
                _converter.oSubNumber = Integer.Parse(_subnumber)
                'совместимость с кодом 1012021
                If _converter.oSeries = "101" Then
                    _converter.oSubNumber = 0
                End If

                'номер 8-12 цифры, 5 знаков (макс. 99 999)
                Dim _number As String = code.Substring(7, 5)
                _converter.oNumber = Integer.Parse(_number)
                _converter.oCodeType = emCodeType.EAN13



                Return _converter
            Case 2
                'стд код 2-201 или 202-46 или 8021-204 или abcd-204
                'макс первого значения = 4
                If _arr(0).Length > 4 Or _arr(0).Length = 2 Then _status = -1 : _converter.oCodeType = emCodeType.Incorrect : Return _converter
                If _arr(1).Length > 5 Then _status = -1 : _converter.oCodeType = emCodeType.Incorrect : Return _converter

                Select Case _arr(0).Length
                    Case 1, 2, 3, 4
                        _converter.oSeries = _arr(0)
                    Case Else
                        _status = -1 : _converter.oCodeType = emCodeType.Incorrect : Return _converter
                End Select


                'проверка номера - только цифры
                If Not _arr(1).Length > 0 OrElse (Not OnlyDigit(_arr(1))) Then _status = -1 : _converter.oCodeType = emCodeType.Incorrect : Return _converter
                _converter.oNumber = Integer.Parse(_arr(1))
                _converter.oSubNumber = 0
                If OnlyDigit(_converter.oSeries) And _arr(0).Length < 4 Then
                    _converter.oCodeType = emCodeType.EAN13
                Else
                    _converter.oCodeType = emCodeType.LetterDigit
                End If

                Return _converter
            Case 3
                'код с артикулом типа 8-204-1 или 802-204-1 или abc-204 или abc-204-1. Но нет = 8021-204-1
                If _arr(0).Length > 3 Or _arr(0).Length = 2 Then _status = -1 : _converter.oCodeType = emCodeType.Incorrect : Return _converter
                If _arr(1).Length > 5 Then _status = -1 : _converter.oCodeType = emCodeType.Incorrect : Return _converter

                Select Case _arr(0).Length
                    Case 1, 2, 3
                        _converter.oSeries = _arr(0)
                    Case Else
                        _status = -1 : _converter.oCodeType = emCodeType.Incorrect : Return _converter
                End Select
                'проверка номера - только цифры
                If _arr(1).Length = 0 Then _status = -1 : _converter.oCodeType = emCodeType.Incorrect : Return _converter
                If OnlyDigit(_arr(1)) = False Then _status = -1 : _converter.oCodeType = emCodeType.Incorrect : Return _converter
                _converter.oNumber = Integer.Parse(_arr(1))
                'проверка доп. номера
                If _arr(2).Length > 1 Then _status = -1 : _converter.oCodeType = emCodeType.Incorrect : Return _converter
                Dim _ch As Char() = _arr(2).ToCharArray
                If Char.IsDigit(_ch(0)) = False Then _status = -1 : _converter.oCodeType = emCodeType.Incorrect : Return _converter
                _converter.oSubNumber = Integer.Parse(_ch(0))

                'совместимость с кодом 1012021
                If _converter.oSeries = "101" Then
                    _converter.oSubNumber = 0
                End If

                If OnlyDigit(_converter.oSeries) Then
                    _converter.oCodeType = emCodeType.EAN13
                Else
                    _converter.oCodeType = emCodeType.LetterDigit
                End If
                _status = 1
                Return _converter
            Case Else
                'непонятный код
                _status = -1
                _converter.oCodeType = emCodeType.Incorrect : Return _converter

        End Select


    End Function
    ''' <summary>
    ''' вернет набор символов шрифта EAN13p36TT
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property EAN13p36TT As String
        Get
            Const a As Integer = 48
            Const b As Integer = 65
            Const c As Integer = 97
            'Const d As Integer = 35
            Dim i As Integer
            Dim Cod(13, 2) As Integer
            Dim f(6, 10) As Integer
            Dim strEAN13 As String

            'если код не EAN13 венуть пусто!
            If Not Me.CodeType = emCodeType.EAN13 Then Return ""


            f(1, 0) = a : f(1, 1) = a : f(1, 2) = a : f(1, 3) = a : f(1, 4) = a
            f(1, 5) = a : f(1, 6) = a : f(1, 7) = a : f(1, 8) = a : f(1, 9) = a

            f(2, 0) = a : f(2, 1) = a : f(2, 2) = a : f(2, 3) = a : f(2, 4) = b
            f(2, 5) = b : f(2, 6) = b : f(2, 7) = b : f(2, 8) = b : f(2, 9) = b

            f(3, 0) = a : f(3, 1) = b : f(3, 2) = b : f(3, 3) = b : f(3, 4) = a
            f(3, 5) = b : f(3, 6) = b : f(3, 7) = a : f(3, 8) = a : f(3, 9) = b

            f(4, 0) = a : f(4, 1) = a : f(4, 2) = b : f(4, 3) = b : f(4, 4) = a
            f(4, 5) = a : f(4, 6) = b : f(4, 7) = b : f(4, 8) = b : f(4, 9) = a

            f(5, 0) = a : f(5, 1) = b : f(5, 2) = a : f(5, 3) = b : f(5, 4) = b
            f(5, 5) = a : f(5, 6) = a : f(5, 7) = a : f(5, 8) = b : f(5, 9) = b

            f(6, 0) = a : f(6, 1) = b : f(6, 2) = b : f(6, 3) = a : f(6, 4) = b
            f(6, 5) = b : f(6, 6) = a : f(6, 7) = b : f(6, 8) = a : f(6, 9) = a
            Dim _code As String = Me.EAN13.ToString

            For i = 1 To 13
                Cod(i, 1) = Integer.Parse(Mid(_code, i, 1))
            Next

            For i = 2 To 7
                Cod(i, 2) = f(i - 1, Cod(1, 1))
            Next
            strEAN13 = Chr(Cod(1, 1) + 35)
            strEAN13 = strEAN13 + Chr(33)
            For i = 2 To 7
                strEAN13 = strEAN13 + Chr(Cod(i, 1) + Cod(i, 2))
            Next
            strEAN13 = strEAN13 + Chr(45)
            For i = 8 To 13
                strEAN13 = strEAN13 + Chr(Cod(i, 1) + c)
            Next
            strEAN13 = strEAN13 + Chr(33)
            Return strEAN13
        End Get
    End Property

    Private oCodeType As emCodeType
    ''' <summary>
    ''' тип кода
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property CodeType As emCodeType
        Get
            Return oCodeType
        End Get
    End Property
    ''' <summary>
    ''' тип кода
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum emCodeType
        EAN13 = 0
        LetterDigit = 1
        Incorrect = 2
    End Enum

    ''' <summary>
    ''' генерирует контрольную 13 цифру кода. Возвращает полный код.
    ''' </summary>
    ''' <param name="BarCode12Digit">12-ти значный код</param>
    Private Shared Function EAN13CheckSumGenerate(ByVal BarCode12Digit As String) As String
        'Выcчитывает контрольную сумму штрих-кода EAN-13.
        'Использует первые 12 символов передаваемой строки. Возвращает полный код.
        Debug.Assert(BarCode12Digit.Length = 12)
        If Not BarCode12Digit.Length = 12 Then Return ""

        Dim c As Long
        Dim s As Long
        Dim i As Integer
        Dim _code As String = BarCode12Digit.Trim()

        s = 0
        For i = 1 To 12

            c = CType(Mid(_code, i, 1), Long)
            s = s + CType(IIf(i Mod 2 = 0, c * 3, c), Long)
        Next
        s = s Mod 10

        Dim _result As String = _code & Right(Trim(Str(10 - s)), 1)

        Return _result

    End Function


    Private Sub New()
        Me.oCodeType = emCodeType.Incorrect
    End Sub

    Public Overrides Function Equals(obj As Object) As Boolean
        If obj Is Nothing Then Return False
        If Not TypeOf obj Is clsCode Then Return False
        Select Case Me.CodeType
            Case emCodeType.EAN13
                If Not Me.EAN13 = CType(obj, clsCode).EAN13 Then Return False
            Case emCodeType.Incorrect
                Return MyBase.Equals(obj)
            Case emCodeType.LetterDigit
                If Not Me.GetHashCode = obj.GetHashCode Then Return False
            Case Else
                Return MyBase.Equals(obj)
        End Select
        Return True
    End Function

    Public Overrides Function GetHashCode() As Integer
        Select Case Me.CodeType
            Case emCodeType.EAN13
                Return Me.EAN13.GetHashCode
            Case emCodeType.Incorrect
                Return MyBase.GetHashCode
            Case emCodeType.LetterDigit
                Return Me.Series.GetHashCode Xor Me.Number.GetHashCode Xor Me.SubNumber.GetHashCode
        End Select
        Return MyBase.GetHashCode()
    End Function

    ''' <summary>
    ''' конвертирует код в базовый c Subnumber=0
    ''' </summary>
    Public Function ConvertToBaseCode() As clsCode
        Me.oSubNumber = 0
        Return Me
    End Function
End Class
