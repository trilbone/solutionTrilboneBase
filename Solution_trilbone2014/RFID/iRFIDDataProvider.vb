''' <summary>
''' Предоставляет связь с устройством RFID
''' </summary>
''' <remarks></remarks>
Public Interface iRFIDDataProvider

    Class clsCardInfo
        Implements IComparable(Of Byte)

        Dim oSector0Block1(16) As Byte
        Dim oSector0Block2(16) As Byte

        Public Property CardID As Byte

        Public Property Sector0Block1 As Byte()
            Get
                Return oSector0Block1
            End Get
            Set(value As Byte())
                oSector0Block1 = value
            End Set
        End Property

        Public Property Sector0Block2 As Byte()
            Get
                Return oSector0Block2
            End Get
            Set(value As Byte())
                oSector0Block2 = value
            End Set
        End Property

        Public Function GetDataByBlockID(BlockID As Integer) As Byte()
            If BlockID = 1 Then Return oSector0Block1
            If BlockID = 2 Then Return oSector0Block2
            Debug.Fail("BlockID необходимо обработать!!")
            Return New Byte() {}
        End Function

        Public Function CompareTo(other As Byte) As Integer Implements System.IComparable(Of Byte).CompareTo
            If other = CardID Then Return 0
            Return other.CompareTo(CardID)
        End Function

        Public Overrides Function ToString() As String
            Return "cardID: " & CardID & "  Data: " & Sector0Block1STR
        End Function


        Public Function EncryptData(value As Byte) As Byte
            If value > 0 And value < 255 Then
                value += CType(7, Byte)
            End If
            Return value
        End Function

        Public Function DecryptData(value As Byte) As Byte
            If value > 0 And value < 255 Then
                value -= CType(7, Byte)
            End If
            Return value
        End Function

        ''' <summary>
        ''' читает/пишет данные карты (с шифром)
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Sector0Block1STR As String
            Get
                Dim _out As String = ""
                For i = 0 To oSector0Block1.Length - 1
                    Dim _sym As Byte = DecryptData(oSector0Block1(i))

                    Dim _char As Char = Chr(_sym)
                    If Char.IsDigit(_char) Or Char.IsPunctuation(_char) Then
                        _out += _char
                    End If
                Next
                Return _out
            End Get
            Set(value As String)
                value = Trim(value)

                If value.Length > 16 Then
                    value = value.Substring(0, 16)
                End If

                If value.Length < 16 Then
                    For i = 1 To 16 - value.Length
                        value += " "
                    Next
                End If

                For i = 0 To 15
                    Dim _sym As Byte = CType(Asc(Mid(value, i + 1, 1)), Byte)
                    oSector0Block1(i) = EncryptData(_sym)
                Next i
            End Set
        End Property

        Public Property Sector0Block2STR As String
            Get
                Dim _out As String = ""
                For i = 0 To oSector0Block2.Length - 1
                    _out += Chr(Sector0Block2(i))
                Next
                Return _out
            End Get
            Set(value As String)
                value = Trim(value)
                If value.Length > 16 Then
                    value = value.Substring(0, 16)
                End If
                If value.Length < 16 Then
                    For i = 1 To 16 - value.Length
                        value += " "
                    Next
                End If
                For i = 0 To 15
                    oSector0Block2(i) = CType(Asc(Mid(value, i + 1, 1)), Byte)
                Next i
            End Set
        End Property
    End Class


    ''' <summary>
    ''' создаст экземпляр устройства
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function CreateReader() As iRFIDDataProvider

    ''' <summary>
    ''' статус устройства
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property ReaderOpenStatus As Boolean
    ''' <summary>
    ''' выключить все диоды на девайсе
    ''' </summary>
    ''' <remarks></remarks>
    Sub LEDAllOff()

    ''' <summary>
    ''' мигнет светодиод чтения
    ''' </summary>
    ''' <param name="onTimeSec"></param>
    ''' <param name="cycles"></param>
    ''' <remarks></remarks>
    Sub LEDGreenON(Optional onTimeSec As Decimal = 0.1D, Optional cycles As Integer = 1)

    ''' <summary>
    ''' запрос меток
    ''' </summary>
    ''' <param name="status"></param>
    ''' <param name="count"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function ReadData(ByRef status As Boolean, ByRef count As Integer) As List(Of clsCardInfo)

    ''' <summary>
    ''' выключить устройство
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function CloseReader() As Boolean

    ''' <summary>
    ''' запись данных
    ''' </summary>
    ''' <param name="CardID"></param>
    ''' <param name="BlockID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function WriteData(CardID As clsCardInfo, BlockID As Integer) As Integer


End Interface
