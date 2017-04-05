
Public Structure strSample
    Private oDescription As String
    Private oGroup As String
    Private oName As String
    Private oPrice As String
    Private oSize As String
    Private oParsedPrice As Short
    Private oParsedSize As List(Of Single)
    Private oImages As clsImageCatalog
    Private oNumber As String
    Private oImageList As List(Of String)

    Private Sub New(path As String)

    End Sub




    Public ReadOnly Property GROUP As String
        Get
            Return oGroup
        End Get
        
    End Property

    Public ReadOnly Property NAME As String
        Get
            Return oName
        End Get
        
    End Property

    Public ReadOnly Property SIZE As String
        Get
            Return oSize
        End Get
       
    End Property

    Public ReadOnly Property parsedSIZE As List(Of Single)
        Get
            'Debug.Fail("не реализовано!")
            Return Me.oParsedSize

        End Get

    End Property

    Public ReadOnly Property DESCRIPTION As String
        Get
            Return oDescription
        End Get
        
    End Property

    Public ReadOnly Property PRICE As String
        Get
            Return oPrice
        End Get
        
    End Property

    Public ReadOnly Property parcedPRICE As Short
        Get
            Debug.Fail("не реализовано!")
            Return 0
        End Get
        
    End Property




    Public ReadOnly Property NUMBER As String
        Get
            Return oNumber
        End Get
       
    End Property

    Public ReadOnly Property IMAGELIST As List(Of String)
        Get
            Return oImageList
        End Get
        
    End Property

    ''' <summary>
    ''' разбирает файл, возвращает статус
    ''' </summary>
    ''' <param name="path">путь к файлу</param>
    Private Function parse(path As String) As Boolean
        'Try
        'разберем xml файл
        Dim dc As XElement = XElement.Load(path)

        'NUMBER
        Dim c = From s In dc.Attributes Where s.Name = "bar" Select s.Value
        oNumber = c.First

        'NAME
        Dim c1 = From s In dc...<NAME> Select s.Value
        oName = c1.First

        'GROUP
        Dim c8 = From s In dc...<GROUP> Select s.Value
        oGroup = c8.First

        'SIZE
        Dim c2 = From s In dc...<SIZE> Select s.Value
        oSize = c2.First
        'parced size
        oParsedSize = Me.GetWidtLendt(oSize)

        'DESCR
        Dim c3 = From s In dc...<DESCR> Select s.Value
        oDescription = c3.First

        'PRICE
        Dim c4 = From s In dc...<PRICE> Select s.Value
        oPrice = c4.First

        'Image list
        Dim c5 = From s In dc...<IMAGE> Select s.@src
        oImageList = c5.ToList

        'Catch ex As Exception
        '    Return False
        'End Try

        Return True
    End Function

    ''' <summary>
    ''' разделяет значение (ахв) возвращает массив строк (0) = длина, (1) = ширина. Точка заменена. Доступные разделители хХ(рус) и хХ(англ)
    ''' </summary>
    ''' <param name="value"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Private Function GetWidtLendt(ByVal value As String) As List(Of Single)
        Dim _val = New List(Of Single)({0, 0})


        If value = "" Then Return _val
        Const sepA As Char = "x"
        Const sepB As Char = "х"
        Const sepC As Char = "X"
        Const sepD As Char = "Х"

        'разделим по пробелам
        Dim _value = value.Trim.Split(" ")


        Dim _out() As String


        'берем первую часть 
        With _value(0)
            If .Contains(sepA) = True Then
                'строка содержит символ-разделитель
                'разбить на две
                _out = .Split(sepA)
            ElseIf .Contains(sepB) = True Then
                _out = .Split(sepB)
            ElseIf .Contains(sepC) = True Then
                _out = .Split(sepC)
            ElseIf .Contains(sepD) = True Then
                _out = .Split(sepD)
            Else
                'строка не содержит разделителей
                Return _val

            End If

            Dim _result As Single = 0

            Select Case _out.Length
                Case 0
                    Return New List(Of Single)({0, 0})
                Case 1
                    _out(0) = ReplacePoint(_out(0))
                    Single.TryParse(_out(0), _val(0))

                Case 2
                    _out(0) = ReplacePoint(_out(0))
                    _out(1) = ReplacePoint(_out(1))
                    Single.TryParse(_out(0), _val(0))
                    Single.TryParse(_out(1), _val(1))

                Case 3
                    _out(0) = ReplacePoint(_out(0))
                    _out(1) = ReplacePoint(_out(1))
                    '_out(2) = ReplacePoint(_out(2))
                    Single.TryParse(_out(0), _val(0))
                    Single.TryParse(_out(1), _val(1))

                Case Else
                    Return New List(Of Single)({0, 0})
            End Select

            Return _val


            ''Return (From t In _out Where t.Length > 0
            '      Let res As Single = 0, _info = Single.TryParse(t, res)
            '                              Select res).ToList



        End With
    End Function
    Private Function ReplacePoint(ByVal value As String) As String
        If value = "" Then Return ""
        'строка не содержит его
        'проверить точку
        If value.Contains(",") Then
            'заменить на точку
            'value.Replace(",", ".")
            Return value.Replace(",", ".")
        End If
        Return value
    End Function



    Public Shared Function CreateInstanse(path As String) As strSample
        Debug.Assert(IO.File.Exists(path), "файл не существует")
        If Not IO.File.Exists(path) Then Return Nothing
        Dim t As New strSample(path)
        If t.parse(path) Then Return t
        Return Nothing
    End Function

    Public Overrides Function ToString() As String
        Return oNumber
    End Function

End Structure
