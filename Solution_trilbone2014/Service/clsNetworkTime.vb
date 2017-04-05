Imports System.Net
Imports System.Net.Sockets

Public Class clsNetworkTime
    Const ntpServer As String = "ntp1.stratum2.ru"
    ''Offset to get to the "Transmit Timestamp" field (time at which the reply 
    ''departed the server for the client, in 64-bit timestamp format."
    Const serverReplyTime As Byte = 40
    ''' <summary>
    ''' при отсутствии подключения к сети вернет дату/время компа, иначе - сетевую
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetTime() As Date
        Dim _out As Date
        Try
            _out = GetNetworkTime()
        Catch ex As Exception
            _out = My.Computer.Clock.LocalTime
        End Try
        Return _out
    End Function


    Private Shared Function GetNetworkTime() As Date



        '' NTP message size - 16 bytes of the digest (RFC 2030)
        Dim ntpData(47) As Byte
        ''Setting the Leap Indicator, Version Number and Mode values
        ''LI = 0 (no warning), VN = 3 (IPv4 only), Mode = 3 (Client Mode)
        ntpData(0) = 27
        Dim addresses = Dns.GetHostEntry(ntpServer).AddressList
        ''The UDP port number assigned to NTP is 123
        Dim ipEndPoint = New IPEndPoint(addresses(0), 123)
        ''NTP uses UDP
        Dim socket = New Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp)
        socket.Connect(ipEndPoint)
        ''Stops code hang if NTP is blocked
        socket.ReceiveTimeout = 3000
        Dim i = socket.Send(ntpData)


        Do While socket.Receive(ntpData) < i

        Loop

        socket.Close()

        ''Get the seconds part
        Dim intPart As ULong = BitConverter.ToUInt32(ntpData, serverReplyTime)
        '' Get the seconds fraction
        Dim fractPart As ULong = BitConverter.ToUInt32(ntpData, serverReplyTime + 4)

        ''Convert From big-endian to little-endian
        intPart = SwapEndianness(intPart)
        fractPart = SwapEndianness(fractPart)

        Dim milliseconds As Long = (intPart * 1000) + ((fractPart * 1000) / &H100000000L)

        ''**UTC** time
        Dim networkDateTime = (New DateTime(1900, 1, 1, 0, 0, 0, DateTimeKind.Utc)).AddMilliseconds(milliseconds)

        Return networkDateTime.ToLocalTime

    End Function


    '' stackoverflow.com/a/3294698/162671
    Private Shared Function SwapEndianness(x As ULong) As UInteger

        Dim a = (x And &HFF) << 24
        Dim b = (x And &HFF00) << 8
        Dim c = (x And &HFF0000) >> 8
        Dim d = (x And &HFF000000) >> 24

        Dim _res = a + b + c + d

        Dim _out As UInteger = _res



        Return _res
    End Function
End Class
