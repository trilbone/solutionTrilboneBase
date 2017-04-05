Imports System.Runtime.InteropServices


Public Class cls_SDTAPI
    Implements iRFIDDataProvider

    Friend Const SEARCHMODE_14443A = &H41
    Friend Const SEARCHMODE_14443B = &H42
    Friend Const SEARCHMODE_15693 = &H31
    Friend Const SEARCHMODE_ST = &H53
    Friend Const SEARCHMODE_AT88RF020 = &H52

    Friend Const REQUESTMODE_ALL = &H52
    Friend Const REQUESTMODE_ACTIVE = &H26

    Friend Const SAM_BOUND_9600 = 0
    Friend Const SAM_BOUND_38400 = 1

    Friend Const PASSWORD_A = &H60
    Friend Const PASSWORD_B = &H61

    Friend Const ENCRYPT = 0
    Friend Const DECRYPT = 1
    Friend Const cntKey = "FFFFFFFFFFFF"

    '/*    FunctionЈє YW_GetDLLVersion
    ' *    NameЈє Get the version of DLL
    ' *    ParamЈєNone
    ' *  ReturnЈєversion Number is success, else is fail.
    '*/ 
    Friend Declare Function YW_GetDLLVersion Lib "SDT.dll" () As Long

    '
    '/*    FunctionЈє DES
    'prototype:int stdcall DES(unsigned char cModel, unsigned char *pkey, unsigned char *in, unsigned char *out);
    'Param:
    'Param   Type
    'cModel  unsigned char   Direction:
    '0 EncryptionЈ¬1 Decryption
    'pkey    unsigned char*  Key , 8 Bytees
    'in  unsigned char*  Data ,8 bytes
    'out unsigned char*  Data after Des, 8bytes
    '
    'Return:0
    '
    '*/

    Friend Declare Function DES Lib "SDT.dll" (ByVal cModel As Byte, ByRef pkey As Byte, ByRef InData As Byte, ByRef OutData As Byte) As Long



    '/*    FunctionЈє DES3
    '3.  3DES
    'prototype:int stdcall DES3(unsigned char cModel, unsigned char *pKey, unsigned char *In, unsigned char *Out);
    'Param:
    'Param   Type
    'cModel  unsigned char   Direction:
    '0 EncryptionЈ¬1 Decryption
    'pkey    unsigned char*  Key, 16Bytes
    'in  unsigned char*  Data ,8 bytes
    'out unsigned char*  Data after Des, 8bytes
    '
    'Return:0
    Friend Declare Function DES3 Lib "SDT.dll" (ByVal cModel As Byte, ByRef pkey As Byte, ByRef InData As Byte, ByRef OutData As Byte) As Long


    '/*    FunctionЈє DES3_CBC
    '4.  3DES with vector
    'prototype:int stdcall DES3_CBC(unsigned char cModel,  unsigned char *pKey,unsigned char *In, unsigned char *Out, unsigned char *pIV);
    'Param:
    'Param   Type
    'cModel  unsigned char   Direction:
    '0 EncryptionЈ¬1 Decryption
    'pkey    unsigned char*  Key, 16Bytes
    'in  unsigned char*  Data ,8 bytes
    'out unsigned char*  Data after Des, 8bytes
    'pIV unsigned char*  Vector , 8Bytes
    'Return:0
    '
    '*/

    Friend Declare Function DES3_CBC Lib "SDT.dll" (ByVal cModel As Byte, ByRef pkey As Byte, ByRef InData As Byte, ByRef OutData As Byte, ByRef pIV As Byte) As Long


    '//*******************************************¶БРґЖчПа№ШєЇКэ ************************/



    '/*    FunctionЈє YW_USBHIDInitial
    '7.  Initial HID Port
    'prototype:int stdcall YW_USBHIDInitial(void);
    'Param:
    'Return:1 successЈ¬0 fail
    '
    '*/
    Friend Declare Function YW_USBHIDInitial Lib "SDT.dll" () As Long


    Private oReaderIsOpen As Boolean

    Public ReadOnly Property ReaderOpenStatus As Boolean Implements iRFIDDataProvider.ReaderOpenStatus
        Get
            Return oReaderIsOpen
        End Get
    End Property

    ''' <summary>
    ''' для интерфейса
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CreateReader() As iRFIDDataProvider Implements iRFIDDataProvider.CreateReader
        Return CreateInstance()
    End Function

    ''' <summary>
    ''' вернет пусто если ридер открыть невозможно
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CreateInstance() As iRFIDDataProvider
        Dim _new As New cls_SDTAPI
        If _new.OpenReader Then
            Return _new
        End If
        Return Nothing
    End Function

    ''' <summary>
    ''' вернет true при удачном открытии ридера
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function OpenReader() As Boolean
        Dim i = YW_USBHIDInitial()
        If i > 0 Then
            oReaderIsOpen = True
            Return True
        Else
            oReaderIsOpen = False
            Return False
        End If
    End Function


    '/*    FunctionЈє YW_USBHIDInitial
    '8.  Free HID Port
    'prototype:int stdcall YW_USBHIDFree(void);
    'Param:
    'Return:1 successЈ¬0 fail
    '*/
    Friend Declare Function YW_USBHIDFree Lib "SDT.dll" () As Long
    ''' <summary>
    ''' закрывает читатель
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CloseReader() As Boolean Implements iRFIDDataProvider.CloseReader
        YW_USBHIDFree()
        Dim i = YW_USBHIDFree
        If i > 0 Then
            oReaderIsOpen = False
            Return True
        End If
        Return False
    End Function


    '/*    FunctionЈє YW_SetReaderID
    '10. Set Reader ID
    'prototype:int stdcall YW_SetReaderID(int OldID, int NewID);
    'Param:
    'Param   Type
    'OldID   int Old Reader ID
    'NewID   int New Read ID
    'Return:1 successЈ¬0 fail
    '
    '*/
    Friend Declare Function YW_SetReaderID Lib "SDT.dll" (ByVal OldID As Integer, ByVal NewID As Integer) As Long

    '/*    FunctionЈє YW_GetReaderID
    '11. Get Reader ID
    'prototype:int stdcall YW_GetReaderID(int ReaderID);
    'Param:
    'Param   Type
    'ReaderID    int ReaderID=0
    'Return:>=0 success and is Reader ID, other is fail
    '
    '*/
    Friend Declare Function YW_GetReaderID Lib "SDT.dll" (ByVal ReaderID As Integer) As Long

    '/*    FunctionЈє YW_GetReaderVersion
    '12. Get Reader Fireware version
    'prototype:int stdcall YW_GetReaderVersion(int ReaderID);
    'Param:
    'Param   Type
    'ReaderID    int Reader ID
    'Return:>=0 success and is version, other is fail
    '
    '
    '*/
    Friend Declare Function YW_GetReaderVersion Lib "SDT.dll" (ByVal ReaderID As Integer) As Long

    '/*    FunctionЈє YW_GetReaderSerial
    '13. Get Reader serial No.
    'prototype:int stdcall YW_GetReaderSerial(int ReaderID, char *ReaderSerial);
    'Param:
    'Param   Type
    'ReaderID    int Reader ID
    'ReaderSerial    Char *  Reader Serial, 8 Bytes
    'Return:1 successЈ¬0 fail
    '
    '*/
    Friend Declare Function YW_GetReaderSerial Lib "SDT.dll" (ByVal ReaderID As Integer, ByRef ReaderSerial As Byte) As Long

    '/*    FunctionЈє YW_GetReaderNo
    '
    '
    '*/
    Friend Declare Function YW_GetReaderNo Lib "SDT.dll" (ByVal ReaderID As Integer, ByRef ReadeNo As Byte) As Long

    '/*    FunctionЈє YW_Buzzer
    '14. Beep control
    'prototype:int stdcall YW_Buzzer(int ReaderID,int Time_ON, int Time_OFF, int Cycle);
    'Param:
    'Param   Type
    'ReaderID    int Reader ID
    'Time_ON int Beep on time, unit:100ms
    'Time_OFF    int Beep off time, unit:100ms
    'Cycle   int The weeks of the beep on and off
    'Return:1 successЈ¬0 fail
    '
    '*/
    Friend Declare Function YW_Buzzer Lib "SDT.dll" (ByVal ReaderID As Integer, ByVal Time_ON As Integer, ByVal Time_OFF As Integer, ByVal Cycle As Integer) As Long


    '/*    FunctionЈє YW_Led
    '15. LED control
    'prototype:int stdcall YW_Led(int ReaderID,int LEDIndex, int Time_ON, int Time_OFF, int Cycle, int LedIndexOn);
    'Param:
    'Param   Type
    'ReaderID    int Reader ID
    'LEDIndex    int LED index
    '1: Read
    '2: Green
    '4: Yellow
    'Time_ON int LED On Time, unit:100ms
    'Time_OFF    int LED Off Time, unit:100ms
    'Cycle   int The weeks of the Led on and off
    'LedIndexOn  int The index of Led on last:
    '0: All off
    '1: Read
    '2: Green
    '4: Yellow
    'Return:1 successЈ¬0 fail
    '*/
    Friend Declare Function YW_Led Lib "SDT.dll" (ByVal ReaderID As Integer, ByVal LEDIndex As Integer, ByVal Time_ON As Integer, ByVal Time_OFF As Integer, ByVal Cycle As Integer, ByVal LedIndexOn As Integer) As Long

    Private Enum emLEDid
        AllOff = 0
        Read = 1
        Green = 2
        Yellow = 3
    End Enum

    Public Sub LEDGreenON(Optional onTimeSec As Decimal = 0.1D, Optional cycles As Integer = 1) Implements iRFIDDataProvider.LEDGreenON
        Dim ReaderID As Integer = 0
        Dim OnTime = onTimeSec * 10
        YW_Led(ReaderID, emLEDid.Green, CType(OnTime, Integer), 1, cycles, emLEDid.AllOff)
    End Sub

    Public Sub LEDAllOff() Implements iRFIDDataProvider.LEDAllOff
        Dim ReaderID As Integer = 0
        YW_Led(ReaderID, emLEDid.Green, 0, 0, 0, emLEDid.AllOff)
    End Sub

    '/*    FunctionЈє YW_AntennaStatus
    '17. Set the Status of Antenna
    'prototype:int stdcall YW_AntennaStatus(int ReaderID,bool Status);
    'Param:
    'Param   Type
    'ReaderID    int Reader ID
    'Status  bool    True: Open RF Antenna
    'False:Close RF Antanna
    'Return:1 successЈ¬0 fail
    '
    '
    '*/
    Friend Declare Function YW_AntennaStatus Lib "SDT.dll" (ByVal ReaderID As Integer, ByVal Status As Boolean) As Long



    '//*******************************************ISO14443AїЁЖ¬ІЩЧчєЇКэ ************************/


    '/*    FunctionЈє YW_RequestCard
    '19. Request card of ISO14443A
    'prototype:int stdcall YW_RequestCard(int ReaderID,char RequestMode , unsigned short *CardType);
    'Param:
    'Param   Type
    'ReaderID    int Reader ID
    'RequestMode char    Request Mode
    '0x52----- All Card
    '0x26----- Active Card
    'CardType    unsigned short *    Return Card Type
    '0x4400 = Ultralight/UltraLight C  /MifarePlus(7Byte UID)
    '0x0400 = Mifare Mini/Mifare 1K (S50) /MifarePlus(4Byte UID)
    '0x0200 = Mifare_4K(S70)/ MifarePlus(4Byte UID)
    '0 x0800 = Mifare_Pro
    '0 x0403 = Mifare_ProX
    '0x4403 ->Mifare_DESFire
    '0x4200 -> MifarePlus(7Byte UID)
    '
    '
    'Return:1 successЈ¬0 fail
    '
    '*/
    Friend Declare Function YW_RequestCard Lib "SDT.dll" (ByVal ReaderID As Integer, ByVal RequestMode As Byte, ByRef CardType As Integer) As Long

    Private Sub New()
        'закрыли конструктор
    End Sub


    ''' <summary>
    ''' запрашивает карты из ридера. Вернет список серийников к картам.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function RequestCards(ByRef status As Boolean, ByRef count As Integer) As List(Of iRFIDDataProvider.clsCardInfo) Implements iRFIDDataProvider.ReadData
        Dim ReaderID As Integer = 0
        Dim CardType As Integer = 0
        Dim MultiCardMode As Integer = 1
        Dim CardMem As Byte = 0
        'длина серийного номера карты
        Dim CardNoLen As Long

        Dim BlockID As Integer = 1
        Dim KeyAB As Byte = PASSWORD_A
        Dim _blockDataArr(16) As Byte
        Dim Key(6) As Byte
        For i = 0 To 5
            Key(i) = CType("&H" & Mid(cntKey, i * 2 + 1, 2), Byte)
        Next i


        Dim _outcards As New List(Of iRFIDDataProvider.clsCardInfo)
        Dim _card As Byte = 0
        Dim _Notchanged As Integer = 0
        count = 0
        status = False
        Try
            If (YW_AntennaStatus(ReaderID, True) > 0) Then
                Dim _new As iRFIDDataProvider.clsCardInfo
                Dim _status As Long = YW_RequestCard(ReaderID, REQUESTMODE_ALL, CardType)
                Do While (_status > 0) And (_Notchanged < 3)
                    If (YW_AntiCollideAndSelect(ReaderID, CType(MultiCardMode, Byte), CardMem, CardNoLen, _card) > 0) Then
                        Dim _res = (From c In _outcards Where c.CardID = _card Select c).FirstOrDefault
                        If _res Is Nothing Then
                            'выход не содержит карту
                            _new = New iRFIDDataProvider.clsCardInfo With {.CardID = _card}
                            If (YW_KeyAuthorization(ReaderID, KeyAB, BlockID, Key(0)) > 0) Then
                                If (YW_ReadaBlock(ReaderID, BlockID, 16, _blockDataArr(0)) > 0) Then
                                    '_str = ""
                                    'For i = 0 To 15
                                    '    _strstr = "00" & Hex(_blockDataArr(i))
                                    '    _str = _str & (_strstr).Substring(_strstr.Length - 2)
                                    'Next i

                                    _blockDataArr.CopyTo(_new.Sector0Block1, 0)
                                    Array.Clear(_blockDataArr, 0, 16)
                                    Dim d = YW_Buzzer(ReaderID, 1, 1, 1)
                                    count += 1
                                    status = True
                                    'request second sector
                                    If (YW_KeyAuthorization(ReaderID, KeyAB, 2, Key(0)) > 0) Then
                                        If (YW_ReadaBlock(ReaderID, 2, 16, _blockDataArr(0)) > 0) Then
                                            '_str = ""
                                            'For i = 0 To 15
                                            '    _strstr = "00" & Hex(_blockDataArr(i))
                                            '    _str = _str & (_strstr).Substring(_strstr.Length - 2)
                                            'Next i
                                            _blockDataArr.CopyTo(_new.Sector0Block2, 0)
                                            Array.Clear(_blockDataArr, 0, 16)
                                        Else
                                            _outcards.Add(_new)
                                        End If
                                    Else
                                        _outcards.Add(_new)
                                    End If
                                    'тут добавляем полну раскладку
                                    _outcards.Add(_new)
                                Else
                                    _outcards.Add(_new)
                                End If
                            Else
                                _outcards.Add(_new)
                            End If
                        Else
                            _Notchanged += 1
                        End If
                        'request
                        _status = YW_RequestCard(ReaderID, REQUESTMODE_ALL, CardType)
                        _card = 0
                    Else
                        Exit Do
                    End If
                Loop
            End If
        Catch ex As Exception
            Return New List(Of iRFIDDataProvider.clsCardInfo)
        End Try

        Return _outcards
    End Function


    Public Function WriteData(CardID As iRFIDDataProvider.clsCardInfo, BlockID As Integer) As Integer Implements iRFIDDataProvider.WriteData
        Dim KeyAB As Byte = PASSWORD_A
        Dim ReaderID As Integer = 0
        Dim CardType As Integer = 0
        Dim CardMem As Byte = 0
        'длина серийного номера карты
        Dim CardNoLen As Long
        Dim Key(6) As Byte
        For i = 0 To 5
            Key(i) = CType("&H" & Mid(cntKey, i * 2 + 1, 2), Byte)
        Next i

        Dim _card As Byte
        Dim _Notchanged As Integer = 0

        If (YW_AntennaStatus(ReaderID, True) > 0) Then

            Dim _status As Long = YW_RequestCard(ReaderID, REQUESTMODE_ALL, CardType)
            Dim _requests As Integer = 0
            Do While (_status > 0) And (_Notchanged < 10)
                If (YW_AntiCollideAndSelect(ReaderID, 1, CardMem, CardNoLen, _card) > 0) Then
                    If _card = CardID.CardID Then
                        'WRITE
                        If (YW_KeyAuthorization(ReaderID, KeyAB, BlockID, Key(0)) > 0) Then
                            If (YW_WriteaBlock(ReaderID, BlockID, 16, CardID.GetDataByBlockID(BlockID)(0)) > 0) Then
                                'success
                                Dim d = YW_Buzzer(ReaderID, 1, 1, 2)
                                Return 1
                            End If
                        End If
                    Else
                        'запрос
                        'request
                        _status = YW_RequestCard(ReaderID, REQUESTMODE_ALL, CardType)
                        _card = 0
                        _Notchanged += 1
                    End If
                End If
                _requests += 1
                If _requests > 200 Then
                    Return -1
                End If
            Loop
            Return 0
        End If
        Return -1
    End Function

    '/*    FunctionЈє YW_AntiCollide
    '20. AntiCollide of ISO14443A Tags
    'prototype:int stdcall YW_AntiCollide(int ReaderID,unsigned char *LenSNO, unsigned char *SNO)
    'Param:
    'Param   Type
    'ReaderID    int Reader ID
    'LenSNO  unsigned char*  Length of card No
    'SNO unsigned char * The card No of card requested
    'Return:1 successЈ¬0 fail
    '
    '*/
    Friend Declare Function YW_AntiCollide Lib "SDT.dll" (ByVal ReaderID As Integer, ByRef LenSNO As Byte, ByRef SNO As Byte) As Long

    '/*    FunctionЈє YW_CardSelect
    '21. Select Card of ISO14443A
    'prototype:int stdcall YW_CardSelect(int ReaderID,char LenSNO, unsigned char *SNO)
    'Param:
    'Param   Type
    'ReaderID    int Reader ID
    'LenSNO  unsigned char   Length of SNO
    'SNO unsigned char * Card No. of selected
    'Return:1 successЈ¬0 fail
    '
    '
    '
    '*/
    ''}
    Friend Declare Function YW_CardSelect Lib "SDT.dll" (ByVal ReaderID As Integer, ByRef LenSNO As Byte, ByRef SNO As Byte) As Long

    '/*    FunctionЈє YW_KeyAuthorization
    '28. Authrize Key with  Key
    'prototype:int stdcall YW_KeyAuthorization (int ReaderID,char KeyMode,int BlockAddr, unsigned char *Key);
    'Param:
    'Param   Type
    'ReaderID    int Reader ID
    'KeyMode char    KeyMode=0x60 Key A
    'KeyMode=0x61 Key B
    'BlockAddr   int Block ID of Authrized
    'Key unsigned char * Key(6 Byes)
    'Return: 1 successЈ¬0 fail
    '
    '
    '*/
    Friend Declare Function YW_KeyAuthorization Lib "SDT.dll" (ByVal ReaderID As Integer, ByVal KeyMode As Byte, ByVal BlockAddr As Integer, ByRef Key As Byte) As Long

    '/*    FunctionЈє YW_ReadaBlock
    '29. Read a Block
    'prototype:int stdcall YW_ReadaBlock (int ReaderID,int BlockAddr,int LenData, unsigned char *Data);
    'Param:
    'Param   Type
    'ReaderID    int Reader ID
    'BlockAddr   int Block ID
    'LenData int Length of data
    'Data    unsigned char * Data of read
    'Return: 1 successЈ¬0 fail
    '
    '
    '*/
    Friend Declare Function YW_ReadaBlock Lib "SDT.dll" (ByVal ReaderID As Integer, ByVal BlockAddr As Integer, ByVal LenData As Integer, ByRef Data As Byte) As Long

    '/*    FunctionЈє YW_WriteaBlock
    '30. Write a Block
    'prototype:int stdcall YW_WriteaBlock (int ReaderID,int BlockAddr,int LenData, unsigned char *Data);
    'Param:
    'Param   Type
    'ReaderID    int Reader ID
    'BlockAddr   int Block ID
    'LenData int Length of Data
    'Data    unsigned char * Data will be written
    'Return: 1 successЈ¬0 fail
    '
    '*/
    Friend Declare Function YW_WriteaBlock Lib "SDT.dll" (ByVal ReaderID As Integer, ByVal BlockAddr As Integer, ByVal LenData As Integer, ByRef Data As Byte) As Long
    '/*    FunctionЈє YW_Purse_Initial
    '31. Initial e-purse of block
    'prototype:int stdcall YW_Purse_Initial (int ReaderID,int BlockAddr,int IniMoney);
    'Param:
    'Param   Type
    'ReaderID    int Reader ID
    'BlockAddr   int Block ID
    'IniMoney    int The initial value of e-purse
    'Return: 1 successЈ¬0 fail
    '
    '
    '*/
    Friend Declare Function YW_Purse_Initial Lib "SDT.dll" (ByVal ReaderID As Integer, ByVal BlockAddr As Integer, ByVal IniValue As Integer) As Long
    '/*    FunctionЈє YW_Purse_Read
    '32. Read value of e-purse
    'prototype:int stdcall YW_Purse_Read (int ReaderID,int BlockAddr,int *Money);
    'Param:
    'Param   Type
    'ReaderID    int Reader ID
    'BlockAddr   int Block ID
    'Money   Int *   The value read
    'Return: 1 successЈ¬0 fail
    '
    '*/
    Friend Declare Function YW_Purse_Read Lib "SDT.dll" (ByVal ReaderID As Integer, ByVal BlockAddr As Integer, ByRef Value As Integer) As Long

    '/*    FunctionЈє YW_Purse_Decrease
    '33. Decrease value of e-purse
    'prototype:int stdcall YW_Purse_Decrease (int ReaderID,int BlockAddr,int Decrement);
    'Param:
    'Param   Type
    'ReaderID    int Reader ID
    'BlockAddr   int Block ID
    'Decrement   Int The value will be decreased
    'Return: 1 successЈ¬0 fail
    '
    '*/
    Friend Declare Function YW_Purse_Decrease Lib "SDT.dll" (ByVal ReaderID As Integer, ByVal BlockAddr As Integer, ByVal Decrement As Integer) As Long

    '/*    FunctionЈє YW_Purse_Decrease
    '34. Increase value of e-purse
    'prototype:int stdcall YW_Purse_Charge (int ReaderID,int BlockAddr,int Charge);
    'Param:
    'Param   Type
    'ReaderID    int Reader ID
    'BlockAddr   int Block ID
    'Charge  Int The value will be increased
    'Return: 1 successЈ¬0 fail
    '
    '*/
    Friend Declare Function YW_Purse_Charge Lib "SDT.dll" (ByVal ReaderID As Integer, ByVal BlockAddr As Integer, ByVal Charge As Integer) As Long

    '/*    FunctionЈє YW_Purse_Decrease
    '35. Restore
    'prototype:int stdcall YW_Restore (int ReaderID,int BlockAddr);
    'Param:
    'Param   Type
    'ReaderID    int Reader ID
    'BlockAddr   int Block ID
    'Return: 1 successЈ¬0 fail
    '
    '*/
    Friend Declare Function YW_Restore Lib "SDT.dll" (ByVal ReaderID As Integer, ByVal BlockAddr As Integer) As Long

    '/*    FunctionЈє YW_Purse_Decrease
    '36. Transfer
    'prototype:int stdcall YW_Transfer (int ReaderID,int BlockAddr);
    'Param:
    'Param   Type
    'ReaderID    int Reader ID
    'BlockAddr   int Block ID
    'Return: 1 successЈ¬0 fail
    '
    '*/
    Friend Declare Function YW_Transfer Lib "SDT.dll" (ByVal ReaderID As Integer, ByVal BlockAddr As Integer) As Long


    '/*    FunctionЈє YW_CardHalt
    ' *    NameЈє ¶ФM1їЁЅшРРHaltІЩЧч
    ' *    ParamЈє  ReaderIDЈє  ¶БРґЖчIDєЕЈ¬0ОЄ№гІҐµШЦ·
    ' *  ReturnЈє>=0ОЄіЙ№¦Ј¬ЖдЛьК§°Ь
    '*/
    Friend Declare Function YW_CardHalt Lib "SDT.dll" (ReaderID As Integer) As Long

    '/*    FunctionЈє YW_AntiCollide_Level
    '24. AntiCollide  Card with level of ISO14443A
    'prototype:int stdcall YW_AntiCollide_Level(int ReaderID,int Leveln,char *LenSNO, unsigned char *SNO);
    'Param:
    'Param   Type
    'ReaderID    int Reader ID
    'Leveln  int Level of AntiCollide, <=3
    'LenSNO  unsigned char*  Length of SNO
    'SNO unsigned char * Card No. antiCollided
    'Return:1 successЈ¬0 fail
    '
    '*/
    Friend Declare Function YW_AntiCollide_Level Lib "SDT.dll" (ByVal ReaderID As Integer, ByVal Leveln As Integer, ByRef LenSNO As Byte, ByRef SNO As Byte) As Long

    '
    '/*    FunctionЈє YW_SelectCard_Level
    '25. Select Card with level of ISO14443A
    'prototype:int stdcall YW_SelectCard_Level(int ReaderID,int Leveln,unsigned char *SAK)
    'Param:
    'Param   Type
    'ReaderID    int Reader ID
    'Leveln  int Level of Select card, <=3
    'SAK unsigned char*  SAK
    'Return:1 successЈ¬0 fail
    '*/
    Friend Declare Function YW_SelectCard_Level Lib "SDT.dll" (ByVal ReaderID As Integer, ByVal Leveln As Integer, ByRef SAK As Byte) As Long

    '/*    FunctionЈє YW_AntiCollideAndSelect
    '22. AntiCollide and Select a Card of ISO14443A
    'prototype:int stdcall  YW_AntiCollideAndSelect(int ReaderID, unsigned char MultiCardMode, unsigned char *CardMem, int *SNLen, unsigned char *SN);
    'Param:
    'Param   Type
    'ReaderID    int Reader ID
    'MultiCardMode   unsigned char   Return mode of Multi Card
    '0: return error
    '1:return a Card
    'CardMem unsigned char * Card Memory
    'SNLen   int *   Length of SN
    'SN  unsigned char * Card No.
    'Return:1 successЈ¬0 fail
    '
    '*/
    Friend Declare Function YW_AntiCollideAndSelect Lib "SDT.dll" (ByVal ReaderID As Integer, ByVal MultiCardMode As Byte, ByRef CardMem As Byte, ByRef SNOLen As Long, ByRef SNO As Byte) As Long

    '/*    FunctionЈє YW_RequestAntiandSelect
    ' 23.    Request AntiCollide and Select a card of ISO14443A
    'prototype:int stdcall  YW_RequestAntiandSelect(int ReaderID,int SearchMode,int MultiCardMode,unsigned short *ATQA,unsigned char *SAK,unsigned char *LenSNO,unsigned char *SNO);
    'Param:
    'Param   Type
    'ReaderID    int Reader ID
    'RequestMode unsigned char   Request Mode
    '0x52----- All Card
    '0x26----- Active Card
    'MultiCardMode   unsigned char   Return mode of Multi Card
    '0: return error
    '1:return a Card
    'ATQA    unsigned short *    ATQA
    'SAK unsigned char * SAK
    'SNLen   int *   Length of SN
    'SN  unsigned char * Card No. selected.
    'Return:1 successЈ¬0 fail
    '*/
    Friend Declare Function YW_RequestAntiandSelect Lib "SDT.dll" (ByVal ReaderID As Integer, ByVal MultiCardMode As Byte, ByRef ATQA As Integer, ByRef SAK As Byte, ByRef LenSNO As Byte, ByRef SNO As Byte) As Long

    '/*    FunctionЈє YW_WriteM1MultiBlock
    '38. Write Multi Blocks
    'prototype:int stdcall YW_WriteM1MultiBlock(int ReaderID, int StartBlock, int BlockNums, int LenData, char *pData);
    'Param:
    'Param   Type
    'ReaderID    int Reader ID
    'StartBlock  int Block  begin
    'BlockNums   int Number of block
    'LenData int Length of data
    'Data    unsigned char * Data will be written
    'Return: 1 successЈ¬0 fail
    '
    '*/
    Friend Declare Function YW_WriteM1MultiBlock Lib "SDT.dll" (ByVal ReaderID As Integer, ByVal StartBlock As Integer, ByVal BlockNums As Integer, ByVal LenData As Integer, ByRef PData As Byte) As Long

    '/*    FunctionЈє YW_ReadM1MultiBlock
    '
    '37. Read multi blocks
    'prototype:int stdcall YW_ReadM1MultiBlock(int ReaderID, int StartBlock, int BlockNums, int *LenData, char *pData);
    'Param:
    'Param   Type
    'ReaderID    int Reader ID
    'StartBlock  int Block  begin
    'BlockNums   int Number of block
    'LenData Int*    Length of data
    'Data    unsigned char * Data read
    'Return: 1 successЈ¬0 fail
    '
    '*/
    Friend Declare Function YW_ReadM1MultiBlock Lib "SDT.dll" (ByVal ReaderID As Integer, StartBlock As Integer, BlockNums As Integer, ByRef LenData As Integer, ByRef PData As Byte) As Long


    '//*******************************************UltraLightїЁЖ¬ІЩЧчєЇКэ ************************/

    '/*    FunctionЈє YW_UltraLightRead
    '39. read Block of UltraLight Tags
    'prototype:int stdcall YW_UltraLightRead(int ReaderID, int BlockID, unsigned char *pData);
    'Param:
    'Param   Type
    'ReaderID    int Reader ID
    'BlockID int Block ID
    'pData   unsigned char * Data read(4 Bytes)
    'Return: 1 successЈ¬0 fail
    '
    '*/
    Friend Declare Function YW_UltraLightRead Lib "SDT.dll" (ByVal ReaderID As Integer, ByVal BlockID As Integer, ByRef PData As Byte) As Long

    '/*    FunctionЈє YW_UltraLightWrite
    '40. Write Block of UltraLight
    'prototype:int stdcall YW_UltraLightWrite(int ReaderID, int BlockID, unsigned char *pData);
    'Param:
    'Param   Type
    'ReaderID    int Reader ID
    'BlockID int Block ID
    'pData   unsigned char * Data will be written(4 bytes)
    'Return: 1 successЈ¬0 fail
    '
    '*/
    Friend Declare Function YW_UltraLightWrite Lib "SDT.dll" (ByVal ReaderID As Integer, ByVal BlockID As Integer, ByRef PData As Byte) As Long


    '//*******************************************Type A CPU їЁЖ¬ІЩЧчєЇКэ ************************/

    '/*    FunctionЈє YW_TypeA_Reset
    '41. Reset CPU Card  of ISO14443A
    'prototype:int stdcall YW_TypeA_Reset(int ReaderID, unsigned char Mode, unsigned char MultiMode, int *rtLen, unsigned char *pData);
    'Param:
    'Param   Type
    'ReaderID    int Reader ID
    'Mode    unsigned char   Request Mode
    '0x52----- All Card
    '0x26----- Active Card
    'MultiMode   unsigned char   Return mode of Multi Card
    '0: return error
    '1:return a Card
    'rtLen   int *   Length of pData
    'pData   unsigned char * Data of reset infomation
    'Return: 1 successЈ¬0 fail
    '
    '*/
    Friend Declare Function YW_TypeA_Reset Lib "SDT.dll" (ByVal ReaderID As Integer, ByVal RequestMode As Byte, ByVal MultiCardMode As Byte, ByRef rtLen As Integer, ByRef PData As Byte) As Long

    '/*    FunctionЈє YW_TypeA_COS
    '42. Excute COS Command of ISO14443A CPU Card
    'prototype:int stdcall YW_TypeA_COS(int ReaderID, int LenCOS, unsigned char *Com_COS, int *rtLen, unsigned char *pData);
    'Param:
    'Param   Type
    'ReaderID    int Reader ID
    'LenCOS  unsigned char*  Length of COS
    'Com_COS unsigned char*  COS Command
    'rtLen   int *   Length of pData
    'pData   unsigned char * Data returned after excute COS command
    'Return: 1 successЈ¬0 fail
    '
    '*/
    Friend Declare Function YW_TypeA_COS Lib "SDT.dll" (ByVal ReaderID As Integer, ByVal LenCOS As Integer, ByVal Com_COS As Byte, ByRef DataLen As Integer, ByRef PData As Byte) As Long



    '/*    FunctionЈє YW_SAM_ResetBaud
    '33. SAM Baud
    'prototypeЈєint __stdcall YW_SAM_ResetBaud(int ReaderID,int SAMIndex, int BaudIndex);
    'Param:
    'Param   Type
    'ReaderID    int Reader ID
    'SAMIndex    int SAM Index
    'BaudIndex   int 0x00->9600 (Default)
    '0x01->19200
    '0x02->38400
    '0x03->55800
    '0x04->57600
    '0x05->115200
    '
    'ReturnЈє1 successЈ¬0 fail
    '
    '*/
    Friend Declare Function YW_SAM_ResetBaud Lib "SDT.dll" (ByVal ReaderID As Integer, ByVal SAMIndex As Integer, ByVal BoundIndex As Integer) As Long

    '/*    FunctionЈє YW_SAM_Reset
    '34. SAM Reset
    'prototypeЈєint __stdcall YW_SAM_Reset(int ReaderID,int SAMIndex, int *rtLen, unsigned char *pData);
    'Param:
    'Param   Type
    'ReaderID    int Reader ID
    'SAMIndex    int SAM Index
    'rtLen   int *   Length of PData
    'pData   unsigned char * Data return of Sam Reset
    '
    'ReturnЈє1 successЈ¬0 fail
    '
    '*/
    Friend Declare Function YW_SAM_Reset Lib "SDT.dll" (ByVal ReaderID As Integer, ByVal SAMIndex As Integer, ByRef DataLen As Integer, ByRef PData As Byte) As Long

    '/*    FunctionЈє YW_SAM_Reset
    '35. Excute COS Command of SAM
    'prototypeЈєint __stdcall YW_SAM_COS(int ReaderID,int SAMIndex, int LenCOS, unsigned char *Com_COS, int *rtLen, unsigned char *pData);
    'Param:
    'Param   Type
    'ReaderID    int Reader ID
    'SAMIndex    int SAM Index
    'LenCOS  int Length of COS Command
    'Com_COS unsigned char * COS Command
    'rtLen   unsigned char * Length of pData
    'pData   unsigned char * Data return after excution of COS Command
    '
    'ReturnЈє1 successЈ¬0 fail
    '
    '*/
    Friend Declare Function YW_SAM_COS Lib "SDT.dll" (ByVal ReaderID As Integer, ByVal ByValSAMIndex As Integer, ByVal LenCOS As Integer, ByRef Com_COS As Byte, ByRef DataLen As Integer, ByRef PData As Byte) As Long

    '/*    FunctionЈє YW_SAM_PPSBaud
    '36. SAM PPS Baud
    'prototypeЈєint __stdcall YW_SAM_PPSBaud(int ReaderID,int SAMIndex, int BaudIndex);
    'Param:
    'Param   Type
    'ReaderID    int Reader ID
    'SAMIndex    int SAM Index
    'BaudIndex   int 0x00->9600 (Default)
    '0x01->19200
    '0x02->38400
    '0x03->55800
    '0x04->57600
    '0x05->115200
    '
    'ReturnЈє1 successЈ¬0 fail
    '
    '*/
    Friend Declare Function YW_SAM_PPSBaud Lib "SDT.dll" (ByVal ReaderID As Integer, ByValSAMIndex As Integer, ByVal BaudIndex As Integer) As Long




End Class
