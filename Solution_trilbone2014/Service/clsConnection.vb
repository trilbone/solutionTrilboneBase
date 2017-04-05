Imports Service.clsApplicationTypes
Imports System.Runtime.Remoting.Messaging
Imports System.Linq
Imports System.IO.MemoryMappedFiles
Imports System.IO
Imports System.Drawing
Imports System.Threading
Imports System.Runtime.InteropServices
Imports Service
Imports System.Text.RegularExpressions
Imports System.Reflection
Imports System.Net

''' <summary>
''' однозначно определяет единицу контента на устройстве хранения. Экземпляры содержат уникальный ключ ID. ToString вернет ID. 
''' </summary>
''' <remarks>переопределен equals и gethashcode. основаны на ID</remarks>
Public Class clsIDcontent
    Private oContainerName As String
    Private oKey As String
    Private oContentType As emContentType


    ''' <summary>
    ''' определяет тип контента
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum emContentType
        ''' <summary>
        ''' фото образца (jpg)
        ''' </summary>
        ''' <remarks></remarks>
        image = 0
        ''' <summary>
        ''' главное фото образца (jpg)
        ''' </summary>
        ''' <remarks></remarks>
        mainImage = 3

        ''' <summary>
        ''' текст - html, xml, txt
        ''' </summary>
        ''' <remarks></remarks>
        text = 1
        ''' <summary>
        ''' illustrator
        ''' </summary>
        ''' <remarks></remarks>
        ai = 2
        ''' <summary>
        ''' бинарный файл - или неопределенный здесь обьект
        ''' </summary>
        ''' <remarks></remarks>
        stream = 100
        ''' <summary>
        ''' пустой контент (если установлен, то где-то ошибка)
        ''' </summary>
        ''' <remarks></remarks>
        null = 1000

    End Enum

    ''' <summary>
    ''' список зарегестрированных типов изображений
    ''' </summary>
    ''' <remarks></remarks>
    Friend Enum emImageExtention
        jpg = 0
        jpeg = 1
        bmp = 2
        tiff = 3
        png = 4
    End Enum
    ''' <summary>
    ''' список зарегестрированных типов текстовых файлов
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum emTextExtention
        txt
        htm
        html
        xml
    End Enum

    Public Enum emJpegQuality
        Fine = 100&
        High = 85&
        Normal = 75&
        Low = 50&
        VeryLow = 0&
    End Enum

    ''' <summary>
    ''' список зарегестрированных типов двоичных файлов
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum emBinaryExtention
        bin
        tree
    End Enum
    ''' <summary>
    ''' определяется при создании обьекта
    ''' </summary>
    ''' <remarks></remarks>
    Private oID As Integer
    Private oKeyIsNull As Boolean
    ''' <summary>
    ''' устанавливается при пустом ключе Key, а значит речь идет о любом файле контента
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property KeyIsNull As Boolean
        Get
            Return oKeyIsNull
        End Get
    End Property


    ''' <summary>
    ''' ключ контента (имя файла с расширением). !!! Может быть пустым "", а значит речь идет о любом файле контента
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property ObjectKey As String
        Get
            Return oKey
        End Get
        'Set(value As String)
        '    'Debug.Assert(value.Length > 0, "ключ не может быть пустым")
        '    If value.Length = 0 Then
        '        oKey = "unknown.file"
        '        oKeyIsNull = True
        '    Else
        '        oKey = value
        '        oKeyIsNull = False
        '    End If
        'End Set
    End Property
    ''' <summary>
    ''' тип контента
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property ContentType As emContentType
        Get
            Return oContentType
        End Get
        'Set(value As emContentType)
        '    oContentType = value
        'End Set
    End Property
    Private oIsLoppedObject As Boolean = False
    ''' <summary>
    ''' установить в true, если надо получить урезанный обьект
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property IsLoppedObject As Boolean
        Get
            Return oIsLoppedObject
        End Get
        Private Set(value As Boolean)
            oIsLoppedObject = value
        End Set
    End Property

    ''' <summary>
    ''' если работаем в корне
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property IsNullContainer As Boolean
        Get
            If String.IsNullOrEmpty(Me.oContainerName) Then Return True
            Return False
        End Get
    End Property

    ''' <summary>
    ''' Хеш код, если папка для образца
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property ContainerSampleNumberHash As String
        Get
            Static _random As Integer
            Dim _sample = clsSampleNumber.CreateFromString(Me.oContainerName)
            If _sample Is Nothing OrElse _sample.CodeIsCorrect = False Then
                'номер не верный
                If Not String.IsNullOrEmpty(Me.oContainerName) Then
                    ' Debug.Fail("Неверный номер образца. В этой точке он должен быть корректный")
                    Return Math.Abs(Me.oContainerName.GetHashCode).ToString
                Else
                    If _random = 0 Then
                        Dim r = New Random
                        _random = r.Next()
                    End If
                    Return Math.Abs(_random).ToString
                End If

            End If
            ''ЗАМЕНА HASH в функциях GetURIRootByIdContent и containsDir класса clsFtpConnection
            'основана на стандартной хеш функции clsSampleNumber.EAN13.GetHashCode
            Return Math.Abs(_sample.GetHashCode).ToString
        End Get
    End Property



    ''' <summary>
    ''' имя контейнера (папки) = номер образца в случае с фотками, и вмещающая папка для других файлов.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ContainerName() As String
        Get
            Return Me.oContainerName
        End Get
        Set(ByVal value As String)
            'Debug.Assert(Not IsNothing(value), "номер образца не должен быть nothing")
            If String.IsNullOrEmpty(value) Then
                Me.oContainerName = ""
            Else
                Me.oContainerName = value.ToLower
            End If
        End Set
    End Property
    ''' <summary>
    ''' установить LoppedObject если надо получить урезанную версию обьекта
    ''' </summary>
    ''' <param name="ContainerName"></param>
    ''' <param name="key"></param>
    ''' <param name="contentType"></param>
    ''' <param name="LoppedObject"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CreateInstance(ContainerName As String, key As String, contentType As emContentType, LoppedObject As Boolean) As clsIDcontent
        Dim _out = New clsIDcontent(ContainerName, key, contentType)
        _out.IsLoppedObject = LoppedObject
        Return _out
    End Function

    ''' <summary>
    ''' путь к контенту или пусто (Random)//имя файла с расширением или пусто (Random)
    ''' </summary>
    ''' <param name="ContainerName">путь к контенту или пусто (Random)</param>
    ''' <param name="key">имя файла с расширением или пусто (Random)</param>
    ''' <param name="contentType"></param>
    ''' <remarks></remarks>
    Private Sub New(ContainerName As String, key As String, contentType As emContentType)
        ' пустой key допустим. тогда кей устанавливается в случайное значение
        Me.ContainerName = ContainerName
        If String.IsNullOrEmpty(key) Then
            Dim _r = New Random
            oKey = (_r.Next.ToString & ".file")
            oKeyIsNull = True
        Else
            oKey = key
            oKeyIsNull = False
        End If
        Me.oContentType = contentType

        'генерим ID - он очень важен!!
        If String.IsNullOrEmpty(Me.oContainerName) Then
            Dim _r = New Random
            Me.oID = (_r.Next.ToString & key.Trim & contentType.ToString.Trim).GetHashCode
        Else
            Me.oID = (Me.oContainerName & key.Trim & contentType.ToString.Trim).GetHashCode
        End If
    End Sub
    ' ''' <summary>
    ' ''' показывает, что при первой же операции сущность контента надо переименовать
    ' ''' </summary>
    ' ''' <remarks></remarks>
    'Private oNeedRenameKey As Boolean


    ' ''' <summary>
    ' ''' Переименует на устройстве определенную сущность (файл) и вернет результат запроса операции да/нет. О самой операции прочитай ReNameKeyStatus
    ' ''' Потом надо вызвать метод DeleteContainer, передав ему 
    ' ''' </summary>
    ' ''' <param name="newKeyName"></param>
    ' ''' <returns></returns>
    ' ''' <remarks></remarks>
    'Public Function RequestForReNameKey(newKeyName As String) As Boolean
    '    If Me.KeyIsNull Then Return False
    '    If Me.ContentType = emContentType.null Then Return False
    '    If newKeyName = "" Then Return False
    '    oNeedRenameKey = True
    '    oRenameKeyStatus = 0
    '    Return True
    'End Function
    ' ''' <summary>
    ' ''' статус преименования сущности -2 = ошибка, -1 = запроса нет или он аннулирован, 0 - ожидание (запрос получен), 1 - упешно переименован
    ' ''' </summary>
    ' ''' <remarks></remarks>
    'Private oRenameKeyStatus As Integer

    ' ''' <summary>
    ' ''' Вернет статус преименования сущности -2 = ошибка, -1 = запроса нет или он аннулирован, 0 - ожидание (запрос получен), 1 - упешно переименован
    ' ''' </summary>
    ' ''' <value></value>
    ' ''' <returns></returns>
    ' ''' <remarks></remarks>
    'Public Property ReNameKeyStatus As Integer
    '    Get
    '        Return oRenameKeyStatus
    '    End Get
    '    Friend Set(value As Integer)
    '        oRenameKeyStatus = value
    '        oNeedRenameKey = False
    '    End Set
    'End Property


    ''' <summary>
    ''' операция с расширением файла
    ''' </summary>
    ''' <param name="imageName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ConvertMainKeyFromImageKey(imageName As String) As String
        Dim _base As String = IO.Path.GetFileNameWithoutExtension(imageName)
        Return _base & "." & GetExtentionListByContentType(emContentType.mainImage)(0)
    End Function
    ''' <summary>
    ''' преобразует тип контента маленький в большой. Для данных необходимо вызвать ConvertToLoppedStream
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property GetAsBig As clsIDcontent
        Get
            If Not Me.IsLoppedObject Then Return Me
            Dim _new = clsIDcontent.CreateInstance(Me.oContainerName, Me.ObjectKey, Me.ContentType, False)
            Return _new
        End Get
    End Property


    ''' <summary>
    ''' преобразует большой тип контента в маленький. Для данных необходимо вызвать ConvertToLoppedStream
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property GetAsLopped As clsIDcontent
        Get
            If Me.IsLoppedObject Then Return Me
            Dim _new = clsIDcontent.CreateInstance(Me.oContainerName, Me.ObjectKey, Me.ContentType, True)

            Select Case Me.ContentType
                Case emContentType.image, emContentType.mainImage
                    'только для фото
                    Return _new
                Case Else
                    'для других типов не реализовано
                    Throw New NotSupportedException
            End Select
        End Get
    End Property

   


    ''' <summary>
    ''' разбирает имя файла, вынимая расширение, а по нему определяет тип контента
    ''' </summary>
    ''' <param name="key"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetContentTypeByKeyValue(key As String) As emContentType
        Debug.Assert(key.Length > 0, "ключ не должен быть пустым")
        If key.Length = 0 Then Return emContentType.null

        ' вынуть расширение
        Dim _ext = IO.Path.GetExtension(key.ToLower)
        If _ext.Length = 0 Then Return emContentType.null
        'ищем совпадение расширения в перечислениях
        For Each t As emContentType In [Enum].GetValues(GetType(emContentType))
            Dim _result = (From c In GetExtentionListByContentType(t) Where c = _ext Select c).Count
            If _result > 0 Then Return t
        Next

        'совпадений не найдено
        Return emContentType.null
    End Function
    ''' <summary>
    ''' вернет строку фильтра для использования в системных функциях как FileDialog и т.п. для зарегестрированных расширений файлов для данного типа контента
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetSystemFilterStringByExtentionsByContentType(contentType As emContentType) As String
        'Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF
        Dim _list = GetExtentionListByContentType(contentType)
        If _list.Count = 0 Then
            Return "All files (*.*)|*.*"
        End If

        Dim _patt = (From c In _list Select "*." & c).ToList

        Dim _out As String = "Image Files ("
        For i = 0 To _patt.Count - 1
            _out += _patt(i) & ";"
        Next
        _out.TrimEnd(";")
        _out += ")|"
        For i = 0 To _patt.Count - 1
            _out += _patt(i) & ";"
        Next
        _out.TrimEnd(";")

        Return _out

    End Function


    ''' <summary>
    ''' вернет список зарегестрированных расширений файлов для данного типа контента
    ''' </summary>
    Public Shared Function GetExtentionListByContentType(contentType As emContentType) As String()

        Dim _list = [Enum].GetNames(GetType(emImageExtention))
        'этот метод используется для поиска кол-ва файлов в папке
        Select Case contentType
            Case emContentType.image
                Return [Enum].GetNames(GetType(emImageExtention))
            Case emContentType.mainImage
                Return {"main"}
            Case emContentType.text
                Return [Enum].GetNames(GetType(emTextExtention))
            Case emContentType.ai
                Return {"ai"}
            Case emContentType.stream
                Return [Enum].GetNames(GetType(emBinaryExtention))
            Case emContentType.null
                Return {""}
            Case Else
                Debug.Fail("Для элемента перечисления действие не задано")
        End Select
        Return {""}
    End Function

    ''' <summary>
    ''' принимает (поток?) и конвертирует его в обьект нужного типа
    ''' </summary>
    Friend Shared Function ConvertToObject(Content As clsIDcontent, ByRef data As Stream) As Object
        'обязательно закрыть поток!!!
        If data Is Nothing Then Return Nothing
        If data.Length = 0 Then Return Nothing

        Select Case Content.ContentType
            Case emContentType.image, emContentType.mainImage
                'выдать обьект Image
                Try
                    Dim _imgI = Image.FromStream((data))
                    Dim _out = _imgI.Clone

                    data.Flush()
                    'data.Dispose()
                    'data = Nothing
                    ' CType(_out, Image).Save("z:\1234.jpg")
                    If Content.IsLoppedObject Then
                        'урежем имадж до constMainImageWidth
                        _imgI = GetResizedImage(_imgI, constMainImageWidth)
                    End If
                    _imgI.Tag = Content.ObjectKey
                    Return _imgI

                    'Dim _tmp As Object
                    'Using _img = Image.FromStream((data))
                    '    data.Flush()
                    '    data.Dispose()
                    '    data = Nothing
                    '    If Content.IsLoppedObject Then
                    '        'урежем имадж до constMainImageWidth
                    '        _tmp = GetResizedImage(_img, constMainImageWidth)
                    '    Else
                    '        _tmp = _img
                    '    End If
                    '    _tmp.Tag = Content.ObjectKey
                    '    Return _tmp
                    'End Using
                Catch ex As OutOfMemoryException
                    Debug.Fail(ex.Message)
                    Return Nothing
                End Try

                'Внимание если сделать усечение обьекта, то в форме ImageManadger будет отображаться размер ЗАГРУЖЕННОГО обьекта и в процедуре записи будет записан именно ЗАГУЖЕННЫЙ обьект!!!
                'If _tmp.Width > 800 Then
                '    ''изменить размер изображения в памяти до ширины 800
                '    _image = GetResizedImage(_tmp, 800).Clone
                'Else
                '    _image = _tmp.Clone
                'End If


                'Using _mmf As MemoryMappedFile = MemoryMappedFile.CreateNew(Content.Key, data.LongLength)
                '    Dim _Stream As MemoryMappedViewStream = _mmf.CreateViewStream()
                '    Dim _writer As IO.BinaryWriter = New BinaryWriter(_Stream)
                '    _writer.Write(data)
                '    _writer.Flush()
                '    _Stream.Flush()
                '    _tmp = Image.FromStream(_Stream)

                '    If _tmp.Width > 800 Then
                '        ''изменить размер изображения в памяти до ширины 800
                '        _image = GetResizedImage(_tmp, 800).Clone
                '    Else
                '        _image = _tmp.Clone
                '    End If

                '    _tmp = Nothing
                '    _writer.Close()
                '    _Stream.Close()
                'End Using


            Case emContentType.text
                'выдать обьект string
                Throw New NotImplementedException("ошибка - конвертер text не определен")

            Case emContentType.ai
                'ошибка - конвертер не определен
                Throw New NotImplementedException("ошибка - конвертер ai не определен")

            Case emContentType.stream
                'венем поток в чистом виде
                Return data

            Case Else
                'ошибка - конвертер не определен("")
                Throw New NotImplementedException("ошибка - конвертер для типа не определен")

        End Select
        Return Nothing
    End Function
    ''' <summary>
    ''' преобразует в главное изображение использует Public Const constMainImageWidth As Integer = 160 по умолчанию
    ''' </summary>
    ''' <param name="Image"></param>
    ''' <param name="OptimizeImageWight"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ResizeToMainImage(ByRef Image As Image, Optional OptimizeImageWight As Integer = constMainImageWidth) As Image
        Return GetResizedImage(Image, OptimizeImageWight)
    End Function

    ''' <summary>
    ''' ширина главного изображения
    ''' </summary>
    Public Const constMainImageWidth As Integer = 320

    ''' <summary>
    ''' это количество должно превышать количество фото на один образец, иначе будет ошибка
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared cntBufferSize As Integer = 50

    ''' <summary>
    ''' преобразует изображение в нужный размер
    ''' </summary>
    ''' <param name="Image"></param>
    ''' <param name="OptimizeImageWight"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetResizedImage(ByRef Image As Image, OptimizeImageWight As Integer) As Image
        'Dim _JpegQuatly As emJpegQuality = emJpegQuality.High
        'Dim jpgEncoder As System.Drawing.Imaging.ImageCodecInfo = GetEncoder(Imaging.ImageFormat.Jpeg)
        'Dim MyEncoder As System.Drawing.Imaging.Encoder = System.Drawing.Imaging.Encoder.Quality
        'Dim MyEncoderParameters As New System.Drawing.Imaging.EncoderParameters(1)
        'Dim MyEncoderParameter As New System.Drawing.Imaging.EncoderParameter(MyEncoder, _JpegQuatly)
        'MyEncoderParameters.Param(0) = MyEncoderParameter
        '   Return Image
        'resize image if request

        If Image Is Nothing Then Return Nothing

        Try
            'ошибка чтения фото
            Dim _d = Image.Width
        Catch ex As Exception
            Return NoImage
        End Try


        If OptimizeImageWight > 0 Then

            If Image.Width < OptimizeImageWight Then
                Return Image
            End If
            Dim _optimizeImageHeight As Integer = CType(OptimizeImageWight / Image.Size.Width * Image.Size.Height, Integer)
            Try
                Dim _lImg As Image = New Bitmap(Image, New Size(OptimizeImageWight, _optimizeImageHeight))
                Return _lImg
            Catch ex As Exception
                Return Image
            End Try

            'Try
            '    ' Dim _image As Image = Image
            '    ' Dim _resizedImage As Bitmap


            '    '_optimizeImageHeight = CType(OptimizeImageWight / Image.Size.Width * Image.Size.Height, Integer)
            '    ' _resizedImage = New Bitmap(Image, New Size(OptimizeImageWight, _optimizeImageHeight))
            '    'Dim _newImage = CType(_resizedImage, Image)

            'Catch ex As Exception
            '    Return Nothing
            'End Try
        End If
        Return Nothing
    End Function


    ''' <summary>
    ''' принимает поток и преобразует его в обрезанный поток
    ''' </summary>
    ''' <param name="Content"></param>
    ''' <param name="Data"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Shared Function ConvertToLoppedStream(Content As clsIDcontent, ByRef Data As Stream) As Stream
        Dim _obj = clsIDcontent.ConvertToObject(Content, Data)
        Return ConvertToLoppedStream(Content, _obj)
    End Function
    ''' <summary>
    ''' принимает обьект и преобразует его в обрезанный поток
    ''' </summary>
    ''' <param name="Content"></param>
    ''' <param name="Data"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Shared Function ConvertToLoppedStream(Content As clsIDcontent, ByRef Data As Object) As Stream
        Debug.Assert(Not Data Is Nothing, "Not nothing obj accept!")
        If Data Is Nothing Then Return Nothing
        Select Case Content.ContentType
            'IMAGE
            Case emContentType.image, emContentType.mainImage
                'в зависимости от типа изображения
                Dim _emselector As emImageExtention
                If Not [Enum].TryParse(Of emImageExtention)(Content.ObjectKey.Split(".").Last.ToLower, _emselector) Then
                    'use selector by default
                    _emselector = emImageExtention.jpeg
                    'проверим, не главное ли фото?
                    If Not Content.ObjectKey.Split(".").Last = GetExtentionListByContentType(emContentType.mainImage)(0) Then
                        Debug.Fail("Невозможно разобрать член перечисления. Видимо, надо добавить.")
                    End If
                End If
                '------при сохранении формат фото остается без изменений
                Dim _format As System.Drawing.Imaging.ImageFormat
                Select Case _emselector
                    Case emImageExtention.bmp
                        _format = System.Drawing.Imaging.ImageFormat.Bmp
                    Case emImageExtention.jpeg, emImageExtention.jpg
                        _format = System.Drawing.Imaging.ImageFormat.Jpeg
                    Case emImageExtention.png
                        _format = System.Drawing.Imaging.ImageFormat.Png
                    Case emImageExtention.tiff
                        _format = System.Drawing.Imaging.ImageFormat.Tiff
                    Case Else
                        _format = System.Drawing.Imaging.ImageFormat.Png
                        Debug.Fail("добавте обработку формата изображения! Будет сохранено в PNG")
                End Select
                Dim _stream As IO.MemoryStream = New IO.MemoryStream
                Dim _lopped = clsIDcontent.GetResizedImage(CType(Data, Image), constMainImageWidth)
                Try
                    _lopped.Save(_stream, _format)
                    _stream.Flush()
                    _stream.Position = 0
                Catch ex As Exception
                    Return Nothing
                End Try


                If _stream.CanRead = False Then
                    MsgBox("Ошибка в преобразовании потока файла. Функция ConvertToStream.", vbCritical)
                    Return Nothing
                End If
                Return _stream

            Case Else
                'ошибка - конвертер не определен
                Throw New NotImplementedException

        End Select

        'Return _out
    End Function

    ''' <summary>
    ''' принимает обьект и преобразует его в поток
    ''' </summary>
    ''' <param name="Content"></param>
    ''' <param name="Data"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ConvertToStream(Content As clsIDcontent, ByRef Data As Object) As Stream
        Debug.Assert(Not Data Is Nothing, "Not nothing obj accept!")
        If Data Is Nothing Then Return Nothing
        Select Case Content.ContentType
            'IMAGE
            Case emContentType.image, emContentType.mainImage
                'в зависимости от типа изображения
                Dim _emselector As emImageExtention
                If Not [Enum].TryParse(Of emImageExtention)(Content.ObjectKey.Split(".").Last.ToLower, _emselector) Then
                    'use selector by default
                    _emselector = emImageExtention.jpeg
                    'проверим, не главное ли фото?
                    If Not Content.ObjectKey.Split(".").Last = GetExtentionListByContentType(emContentType.mainImage)(0) Then
                        Debug.Fail("Невозможно разобрать член перечисления. Видимо, надо добавить.")
                    End If
                End If
                '------при сохранении формат фото остается без изменений
                Dim _format As System.Drawing.Imaging.ImageFormat
                Select Case _emselector
                    Case emImageExtention.bmp
                        _format = System.Drawing.Imaging.ImageFormat.Bmp
                    Case emImageExtention.jpeg, emImageExtention.jpg
                        _format = System.Drawing.Imaging.ImageFormat.Jpeg
                    Case emImageExtention.png
                        _format = System.Drawing.Imaging.ImageFormat.Png
                    Case emImageExtention.tiff
                        _format = System.Drawing.Imaging.ImageFormat.Tiff
                    Case Else
                        _format = System.Drawing.Imaging.ImageFormat.Png
                        Debug.Fail("добавте обработку формата изображения! Будет сохранено в PNG")
                End Select
                Dim _stream As IO.MemoryStream = New IO.MemoryStream
                Try
                    CType(Data, Image).Save(_stream, _format)
                    _stream.Flush()
                    _stream.Position = 0
                Catch ex As Exception
                    Return Nothing
                End Try


                If _stream.CanRead = False Then
                    MsgBox("Ошибка в преобразовании потока файла. Функция ConvertToStream.", vbCritical)
                    Return Nothing
                End If
                Return _stream

                '----------------рабочий код, проверено
                ''при сохранении  фото преобразуются!!! в jpeg, но РАСШИРЕНИЕ файла (в key) надо изменить. это не сделано.
                'Dim _JpegQuatly As emJpegQuality = emJpegQuality.High
                'Dim jpgEncoder As System.Drawing.Imaging.ImageCodecInfo = GetEncoder(Imaging.ImageFormat.Jpeg)
                'Dim MyEncoder As System.Drawing.Imaging.Encoder = System.Drawing.Imaging.Encoder.Quality
                'Dim MyEncoderParameters As New System.Drawing.Imaging.EncoderParameters(1)
                'Dim MyEncoderParameter As New System.Drawing.Imaging.EncoderParameter(MyEncoder, _JpegQuatly)
                'MyEncoderParameters.Param(0) = MyEncoderParameter
                'Using _stream As IO.MemoryStream = New IO.MemoryStream
                '    _image.Save(_stream, jpgEncoder, MyEncoderParameters)
                '    Return _stream.ToArray
                'End Using
                '--------------------
                'TEXT = HTML, XML, TXT
            Case emContentType.text
                'преобразовать обьект string
                Dim _stream As IO.MemoryStream = New IO.MemoryStream
                Dim _obj As String = CType(Data, String)
                Dim _en As New System.Text.ASCIIEncoding()
                'Dim _en As New System.Text.Encoding.GetEncoding("windows-1251")
                'Dim _buff = _en.GetBytes(_obj)
                Dim _buff = System.Text.Encoding.GetEncoding("windows-1251").GetBytes(_obj)
                _stream.Write(_buff, 0, _buff.Length)
                _stream.Flush()
                Return _stream


            Case emContentType.stream
                'копия потока
                Return Data

            Case Else
                'ошибка - конвертер не определен
                Throw New NotImplementedException

        End Select

        'Return _out
    End Function


    ''' <summary>
    ''' вернет УНИКАЛЬНОЕ имя объекта. Используется для индиентификации потоков в буфере!!!
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetID() As Integer
        Return oID
    End Function
    ''' <summary>
    ''' equals by ID
    ''' </summary>
    ''' <param name="obj"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overrides Function Equals(obj As Object) As Boolean
        If obj Is Nothing Then Return False
        If Not Me.GetType.Equals(obj.GetType) Then Return False
        If Not Me.oID = (CType(obj, clsIDcontent).oID) Then Return False
        Return True
    End Function

    Public Overrides Function GetHashCode() As Integer
        Return Me.oID
    End Function

    Public Overrides Function ToString() As String
        Return Me.oID
    End Function

    ''' <summary>
    ''' служебная процедура для ресайза изображений
    ''' </summary>
    ''' <param name="format"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetEncoder(ByVal format As System.Drawing.Imaging.ImageFormat) As System.Drawing.Imaging.ImageCodecInfo

        Dim codecs As System.Drawing.Imaging.ImageCodecInfo() = System.Drawing.Imaging.ImageCodecInfo.GetImageDecoders()

        Dim codec As System.Drawing.Imaging.ImageCodecInfo
        For Each codec In codecs
            If codec.FormatID = format.Guid Then
                Return codec
            End If
        Next codec
        Return Nothing

    End Function

    'Private Shared Function GetEncoder(format As System.Drawing.Imaging.ImageFormat) As System.Drawing.Imaging.ImageCodecInfo

    'End Function

End Class


''' <summary>
''' аргумент события о окончании записи контента
''' </summary>
''' <remarks></remarks>
Public Class ContentWritedEventArgs
    Inherits EventArgs
    Public Status As Integer
End Class

''' <summary>
''' аргумент события о готовности обьекта для чтения
''' </summary>
''' <remarks></remarks>
Public Class ContentReadyEventArgs
    Inherits EventArgs
    Public data As Stream
    Public content As clsIDcontent
End Class

''' <summary>
''' описывает поведение обьекта соединения
''' </summary>
''' <remarks>все возвращаемые обьекты должны быть ииметь пустые значения в случае неуспеха запроса</remarks>
Public Interface iSource

    ''' <summary>
    ''' возникает, когда окончена запись контента на устройство
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Event ContentWrited(sender As Object, e As ContentWritedEventArgs)


    ''' <summary>
    ''' возникает, когда запрошенный обьект помещен в буфер и готов для чтения
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Event ContentReadyForRead(sender As Object, e As ContentReadyEventArgs)


    ''' <summary>
    ''' возникает, когда запрашиваемое хранилище недоступно
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="message"></param>
    ''' <remarks></remarks>
    Event RepositoryNotConnected(sender As Object, message As String)

    ''' <summary>
    ''' возникает, когда запрашиваемое хранилище подключилось
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="message"></param>
    ''' <remarks></remarks>
    Event RepositoryConnected(sender As Object, message As String)



    ''' <summary>
    ''' вернет привязанное внутреннее устройство хранения
    ''' </summary>
    ReadOnly Property DestinationFileSource As clsFilesSources

    ''' <summary>
    ''' читает контент. прочитанные данные = поток передается в событие ContentReadyForRead
    ''' </summary>
    ''' <param name="Idcontent"></param>
    ''' <param name="_status"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Sub ReadKeyObj(ByVal idcontent As clsIDcontent, ByRef _status As Integer, Optional ByVal asynhronCall As Boolean = False, Optional ByRef asynhResult As IAsyncResult = Nothing, Optional ByVal IgnoreBuffer As Boolean = False)
    ''' <summary>
    ''' записывает данные data на устройство. Вернет -1 при ошибке, 1 если записано
    ''' </summary>
    ''' <param name="Idcontent"></param>
    ''' <param name="data"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function WriteKeyObj(ByVal idcontent As clsIDcontent, ByRef data As IO.Stream, Optional ByVal asynhronCall As Boolean = False, Optional ByRef asynhResult As IAsyncResult = Nothing) As Integer
    ''' <summary>
    ''' Вернет -2 (серьезная, не отловленная) или -1 - ошибка (нет скорее всего), 0 - данных нет, 1 и более - ок
    ''' </summary>
    ''' <param name="Idcontent"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function DeleteKey(idcontent As clsIDcontent) As Integer

    ''' <summary>
    ''' Переименовать сущность Вернет -2 (серьезная, не отловленная) -1 - ошибка, 0 - сущность не найдена, 1 и более - ок
    ''' </summary>
    ''' <param name="Idcontent"></param>
    ''' <param name="newKeyName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function RenameKey(idcontent As clsIDcontent, newKeyName As String) As Integer



    ''' <summary>
    ''' Удалить блок, т.е. единицу с номером образца(папку и т.п.). key задать любым - но не пустым!!.  Вернет -2 (серьезная, не отловленная) -1 - ошибка, 0 - данных нет, 1 и более (кол-во удаленных файлов) - ок
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function DeleteContainer(idcontent As clsIDcontent) As Integer






    ''' <summary>
    ''' вернет список ключей. Filter задаст фильтр. сортировка задается как в файловой системе
    ''' </summary>
    ''' <param name="Idcontent"></param>
    ''' <returns></returns>
    ''' <remarks>реализовать проверку наличия запрошенных ключей</remarks>
    Function GetListKeys(idcontent As clsIDcontent, Optional filter As String() = Nothing) As List(Of String)
    ''' <summary>
    ''' вернет число единиц контента
    ''' </summary>
    ''' <param name="Idcontent"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function CountContent(idcontent As clsIDcontent) As Integer
    ''' <summary>
    ''' вернет флаг наличия контента
    ''' </summary>
    ''' <param name="Idcontent"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function ContainsContent(idcontent As clsIDcontent) As Boolean
    ''' <summary>
    ''' проверка соединения. Есть ли смысл запрашивать действия.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function CheckConnection() As Boolean

    ''' <summary>
    ''' возвращает URI контента для прямой ссылки. Вернет -1 - ошибка, 0 - данных нет, 1 и более - ок
    ''' </summary>
    ''' <param name="Idcontent"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetContentURI(idcontent As clsIDcontent, ByRef status As Integer) As Uri

    ''' <summary>
    ''' возвращает список образцов на устройстве. фильтр задает строку поиска в номерах, как то серия и прочее
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetSampleList(Optional filter As String = "") As List(Of clsSampleNumber)

    ''' <summary>
    ''' возвращает список серий ххх на устройстве
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetSeriesList() As List(Of String)

    ''' <summary>
    ''' вернет делегат для вызова сервисной функции хранилища нормализации данных. Проверка файлов, очистка пустых блоков и прочее. вернет тип object, содержащий сервисные данные (какие, см описание сервиса соотв. класса)
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function CallService(name As String) As Func(Of Object, MethodInfo)

End Interface


Public MustInherit Class clsConnectionBase
    Implements iSource

    Protected Const _constLoppedObjectFolderName As String = "small"
    Protected Const _constMainImagePrephics As String = "main_"


    Protected Sub New(DestinationFileSource As clsFilesSources)
        oDestinationFileSource = DestinationFileSource
    End Sub


    Private oDestinationFileSource As clsFilesSources

    Public Overridable Function CallService(name As String) As Func(Of Object, MethodInfo) Implements iSource.CallService

        Dim _callfunction As MethodInfo = Me.GetType.GetMethod(name)
        'если такого метода нет, вернуть пусто
        If _callfunction Is Nothing Then
            Return Nothing
        End If
        Dim _fn = Function(param As Object) _callfunction
        Return _fn

    End Function
    ''' <summary>
    ''' результат -1=ошибка  0=преобразование не требуется  >1=переименовано (кол-во файлов)
    ''' </summary>
    ''' <param name="Idcontent"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SortAndRenameContent(Idcontent As clsIDcontent) As Integer
        Dim _list = Me.GetListKeys(Idcontent)
        If _list.Count <= 1 Then Return 0
        'сортировка
        Dim _status As Boolean
        Dim _newSortedList As List(Of KeyValuePair(Of String, Integer)) = Nothing
        Dim _res = CompareKeyNames(_list, _status, _newSortedList)
        If _status Then Return 0

        'переделать имена файлов
        'в _newSortedList лежат имена для обновления
        'находить старые файлы надо по KEY, а переименовывать в {value} & _cntSplitter & {key}
        If Not _list.Count = _res.Count Then
            Debug.Assert(_list.Count = _res.Count, "кол-во отсортированых позиций не совпадает с переданными на сортировку! Проверь функцию CompareKeyNames")
            Return -1
        End If

        If _newSortedList Is Nothing Then
            Debug.Assert(Not _newSortedList Is Nothing, "кол-во ресортированых позиций на обновление не совпадает с переданными на сортировку! Проверь функцию CompareKeyNames")
            Return -1
        End If


        'переименовать файлы на устройстве
        For i = 0 To _list.Count - 1
            Dim j = i
            Dim _result = (From c In _newSortedList Where _list(j).Contains(c.Key) Select c)
            If _result.Count = 0 Then
                Debug.Fail("Порядок ресортированных позиций отличается от порядка исходного списка")
                Return False
            End If
            Dim _old = _list(i)
            Dim _new = _result(0).Value.ToString & _cntSplitter & _result(0).Key
            Me.RenameKey(clsIDcontent.CreateInstance(Idcontent.ContainerName, _old, Idcontent.ContentType, False), _new)
        Next

        Return _list.Count


    End Function


    'Private Function ServiceFunction() As Object
    '    Return {"Сервисная функция для хранилищ " & Me.GetType.Name & " не задана"}
    'End Function


    Public MustOverride Function CheckConnection() As Boolean Implements iSource.CheckConnection


    Public MustOverride Function ContainsContent(Idcontent As clsIDcontent) As Boolean Implements iSource.ContainsContent


    Public MustOverride Function CountContent(Idcontent As clsIDcontent) As Integer Implements iSource.CountContent


    Public MustOverride Function DeleteBlock(Idcontent As clsIDcontent) As Integer Implements iSource.DeleteContainer


    Public MustOverride Function DeleteKey(Idcontent As clsIDcontent) As Integer Implements iSource.DeleteKey


    Public MustOverride Function RenameKey(Idcontent As clsIDcontent, newKeyName As String) As Integer Implements iSource.RenameKey

    ''' <summary>
    ''' вернет список ЗАРАНЕЕ ОПРЕДЕЛЕННЫХ соединений, в которых найден номер
    ''' </summary>
    ''' <param name="IdContent"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetExistConnectionList(IdContent As clsIDcontent, enableRemote As Boolean) As List(Of clsFilesSources)
        Dim _list As New List(Of clsFilesSources)
        Dim _conn As iSource
        'arhive
        Dim _str = clsFilesSources.CreateInstance(clsFilesSources.emSources.Arhive)
        _conn = CreateConnection(_str)
        If Not _conn Is Nothing AndAlso _conn.CountContent(IdContent) > 0 Then
            _list.Add(_conn.DestinationFileSource)
        End If

        'запретить удаленные соединения
        If enableRemote = False Then Return _list

        'azure
        _str = clsFilesSources.CreateInstance(clsFilesSources.emSources.AZURE)
        _conn = CreateConnection(_str)
        If Not _conn Is Nothing AndAlso _conn.CountContent(IdContent) > 0 Then
            _list.Add(_conn.DestinationFileSource)
        End If


        Return _list
    End Function
    ''' <summary>
    ''' пробуем найти соединение для контента. в случае успеха в _connection будет соединение
    ''' </summary>
    ''' <param name="IdContent"></param>
    ''' <param name="FileSource"></param>
    ''' <param name="_connection"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Shared Function FindConnection(IdContent As clsIDcontent, FileSource As clsFilesSources, ByRef _connection As iSource) As Boolean
        Dim _tryconn As iSource = Nothing
        Select Case FileSource.Source
            Case clsFilesSources.emSources.FreeFolder
                _tryconn = CreateConnection(FileSource)

            Case clsFilesSources.emSources.SpecificOrder
                _tryconn = CreateConnection(FileSource)

            Case clsFilesSources.emSources.AllSources
                'ищет ТОЛЬКО в стандартных устройствах
                'TODO добавить просмотр папки заказов?
                Dim _list = GetExistConnectionList(IdContent, True)
                If _list.Count = 0 Then Return False
                For Each t In _list
                    Dim _conn = CreateConnection(t)
                    If Not _conn Is Nothing Then
                        _connection = _conn
                        Return True
                    End If
                Next

            Case clsFilesSources.emSources.FolderForTrees
                _tryconn = CreateConnection(FileSource)
            Case Else
                _tryconn = CreateConnection(FileSource)
        End Select

        If Not _tryconn Is Nothing Then
            _connection = _tryconn
            Return True
        End If


        _connection = Nothing
        Return False
    End Function
    ''' <summary>
    ''' пробуем найти соединение. в случае успеха в _connection будет соединение
    ''' </summary>
    ''' <param name="FileSource"></param>
    ''' <param name="_connection"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ConnectToSource(FileSource As clsFilesSources, ByRef _connection As iSource) As Boolean
        Dim _conn = CreateConnection(FileSource)
        If Not _conn Is Nothing Then
            _connection = _conn
            Return True
        End If
        _connection = Nothing
        Return False
    End Function


    ''' <summary>
    ''' содержит буфер подключений
    ''' </summary>
    ''' <remarks></remarks>
    Private Shared oConnectionBuffer As New Dictionary(Of String, iSource)


    ''' <summary>
    ''' вернет соответствующий потомок в зависимости от запрошенного устройства хранения
    ''' </summary>
    ''' <param name="DestinationFileSource"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Shared Function CreateConnection(DestinationFileSource As clsFilesSources) As iSource
        ''  вернуть соответствующий потомок в зависимости от запрошенного устройства хранения
        If oConnectionBuffer.ContainsKey(DestinationFileSource.GetID) Then Return oConnectionBuffer.Item(DestinationFileSource.GetID)

        If oConnectionBuffer.Count > 25 Then
            Debug.Fail("Это не ошибка, а предупреждение. Превышен лимит буфера подключений")
            oConnectionBuffer.Clear()
        End If


        Select Case DestinationFileSource.Source
            Case clsFilesSources.emSources.Arhive
                'place to buffer
                Dim _tmp = clsFSlocal.InitConnection(DestinationFileSource)
                If _tmp.CheckConnection Then
                    _tmp.OnRepositoryConnected("Подключено к " & _tmp.ToString)
                    oConnectionBuffer.Add(DestinationFileSource.GetID, _tmp)
                    Return _tmp
                Else
                    _tmp.OnRepositoryNotConnected("Неудалось подключится к файловому хранилищу на диске")
                End If

            Case clsFilesSources.emSources.AZURE
                'AZURE CONNECTION
                Dim _key = "FFGGSdfxvpmyPH7MsWn/p4AjxeK/nhpzZ50FjSAdpEqeZYll90+vXmLTlMKMYEFly7QNsyytwvsqcn3EdYPlPQ=="
                Dim _accountName = "trilbone"
                Dim _tmp = clsAzureConnection.InitConnection(DestinationFileSource, _accountName, _key)
                If _tmp.CheckConnection Then
                    _tmp.OnRepositoryConnected("Подключено к " & _tmp.ToString)
                    oConnectionBuffer.Add(DestinationFileSource.GetID, _tmp)
                    Return _tmp
                Else
                    _tmp.OnRepositoryNotConnected("Не удалось подключится к AZURE хранилищу " & _accountName)
                End If

            Case clsFilesSources.emSources.FtpInfoTrilbone
                ''ftp://info.trilbone.com/, рабочий каталог /img/arhive
                'user trilbone_arhive
                'pass asaphus2009
                Dim _tmp = clsFtpConnection.InitConnection(DestinationFileSource, "info.trilbone.com", "trilbone_arhive", "asaphus2009", "", "http://info.trilbone.com/img/arhive")

                If _tmp.CheckConnection Then
                    _tmp.OnRepositoryConnected("Подключено к " & _tmp.ToString)
                    oConnectionBuffer.Add(DestinationFileSource.GetID, _tmp)
                    Return _tmp
                Else
                    _tmp.OnRepositoryNotConnected("Не удалось подключится к FTP хранилищу " & "ftp://info.trilbone.com/")
                End If

            Case clsFilesSources.emSources.FtpMapTrilbone
                ''карты образцов
                ''ftp://info.trilbone.com/, рабочий каталог /img/arhive
                'user trilbone_arhive
                'pass asaphus2009
                'Dim _tmp = clsFtpConnection.InitConnection(DestinationFileSource, "info.trilbone.com", "trilbone_arhive", "asaphus2009", "", "/img/arhive")
                Dim _tmp = clsFtpConnection.InitConnection(DestinationFileSource, "info.trilbone.com", "trilbone_map", "asaphus2009", "", "http://info.trilbone.com/img/map")

                If _tmp.CheckConnection Then
                    _tmp.OnRepositoryConnected("Подключено к " & _tmp.ToString)
                    oConnectionBuffer.Add(DestinationFileSource.GetID, _tmp)
                    Return _tmp
                Else
                    _tmp.OnRepositoryNotConnected("Не удалось подключится к FTP хранилищу " & "ftp://info.trilbone.com/")
                End If


            '''ftp://waws-prod-db3-001.ftp.azurewebsites.windows.net/  рабочий каталог /map
            ''user plshop\trilboneftp
            ''pass asaphus2009
            'Dim _tmp = clsFreeFtpConnection.InitConnection(DestinationFileSource, "waws-prod-db3-001.ftp.azurewebsites.windows.net", "plshop\trilboneftp", "Hasmops2009", "site/wwwroot/Maps", "http://www.trilbone.com/Maps/")
            'If _tmp.CheckConnection Then
            '    _tmp.OnRepositoryConnected("Подключено к " & _tmp.ToString)
            '    oConnectionBuffer.Add(DestinationFileSource.GetID, _tmp)
            '    Return _tmp
            'Else
            '    _tmp.OnRepositoryNotConnected("Не удалось подключится к FTP хранилищу " & "http://www.trilbone.com/Maps/")
            'End If

            Case clsFilesSources.emSources.FtpEbayPhotoArhive

                ''ftp://info.trilbone.com/, рабочий каталог /img/arhive
                'user trilbone_arhive
                'pass asaphus2009
                Dim _tmp = clsFtpConnection.InitConnection(DestinationFileSource, "info.trilbone.com", "trilbone_arhive", "asaphus2009", "", "http://info.trilbone.com/img/arhive")

                If _tmp.CheckConnection Then
                    _tmp.OnRepositoryConnected("Подключено к " & _tmp.ToString)
                    oConnectionBuffer.Add(DestinationFileSource.GetID, _tmp)
                    Return _tmp
                Else
                    _tmp.OnRepositoryNotConnected("Не удалось подключится к FTP хранилищу " & "ftp://info.trilbone.com/")
                End If

            ''
            '''ftp://waws-prod-db3-001.ftp.azurewebsites.windows.net/  рабочий каталог /map
            ''user plshop\trilboneftp
            ''pass asaphus2009
            'Dim _tmp = clsFreeFtpConnection.InitConnection(DestinationFileSource, "waws-prod-db3-001.ftp.azurewebsites.windows.net", "plshop\trilboneftp", "Hasmops2009", "site/wwwroot/eBayImages", "http://www.trilbone.com/eBayImages/")
            'If _tmp.CheckConnection Then
            '    _tmp.OnRepositoryConnected("Подключено к " & _tmp.ToString)
            '    oConnectionBuffer.Add(DestinationFileSource.GetID, _tmp)
            '    Return _tmp
            'Else
            '    _tmp.OnRepositoryNotConnected("Не удалось подключится к FTP хранилищу " & "http://www.trilbone.com/eBayImages/")
            'End If

            Case clsFilesSources.emSources.FtpClientFolderTrilbone
                ''клиентские станицы
                ''ftp://info.trilbone.com/, рабочий каталог /img/arhive
                'user trilbone_arhive
                'pass asaphus2009
                'Dim _tmp = clsFtpConnection.InitConnection(DestinationFileSource, "info.trilbone.com", "trilbone_arhive", "asaphus2009", "", "/img/arhive")
                Dim _tmp = clsFtpConnection.InitConnection(DestinationFileSource, "info.trilbone.com", "trilbone_client", "asaphus2009", "", "http://info.trilbone.com/clientcatalogpages")

                If _tmp.CheckConnection Then
                    _tmp.OnRepositoryConnected("Подключено к " & _tmp.ToString)
                    oConnectionBuffer.Add(DestinationFileSource.GetID, _tmp)
                    Return _tmp
                Else
                    _tmp.OnRepositoryNotConnected("Не удалось подключится к FTP хранилищу " & "ftp://info.trilbone.com/")
                End If

            '''ftp://waws-prod-db3-001.ftp.azurewebsites.windows.net/  рабочий каталог /map
            ''user plshop\trilboneftp
            ''pass asaphus2009
            'Dim _tmp = clsFreeFtpConnection.InitConnection(DestinationFileSource, "waws-prod-db3-001.ftp.azurewebsites.windows.net", "plshop\trilboneftp", "Hasmops2009", "site/wwwroot/Clients", "http://www.trilbone.com/Clients/")
            'If _tmp.CheckConnection Then
            '    _tmp.OnRepositoryConnected("Подключено к " & _tmp.ToString)
            '    oConnectionBuffer.Add(DestinationFileSource.GetID, _tmp)
            '    Return _tmp
            'Else
            '    _tmp.OnRepositoryNotConnected("Не удалось подключится к FTP хранилищу " & "http://www.trilbone.com/Clients/")
            'End If

            Case clsFilesSources.emSources.SpecificOrder
                If DestinationFileSource.Order = Nothing OrElse DestinationFileSource.Order.IsValidOrder = False Then
                    Debug.Fail("Передан запрос, не содержащий необходимые данные о заказе")
                    Return Nothing
                End If
                Dim _tmp = clsFSOrder.InitConnection(DestinationFileSource)
                If _tmp.CheckConnection Then
                    _tmp.OnRepositoryConnected("Подключено к " & _tmp.ToString)
                    oConnectionBuffer.Add(DestinationFileSource.GetID, _tmp)
                    Return _tmp
                Else
                    _tmp.OnRepositoryNotConnected("Неудалось подключится к файловому хранилищу на диске")
                End If

                Return _tmp
            Case clsFilesSources.emSources.FreeFolder
                If DestinationFileSource.ContainerPath = "" Then Return Nothing
                Dim _tmp = clsFSFreePath.InitConnection(DestinationFileSource)
                If Not _tmp Is Nothing AndAlso _tmp.CheckConnection Then
                    _tmp.OnRepositoryConnected("Подключено к " & _tmp.ToString)
                    oConnectionBuffer.Add(DestinationFileSource.GetID, _tmp)
                    Return _tmp
                Else
                    If Not _tmp Is Nothing Then
                        _tmp.OnRepositoryNotConnected("Неудалось подключится к файловому хранилищу на диске")

                    End If
                End If

            Case clsFilesSources.emSources.FolderForTrees
                Throw New ObjectNotFoundException
                'TODO сюда поместить код вызова класса для деревьев


            Case clsFilesSources.emSources.AllSources
                Debug.Fail("параметр AllSources нельзя использовать для функции GetConnection, надо использовать FindConnection")

            Case clsFilesSources.emSources.SystemVolume
                If DestinationFileSource.ContainerPath = "" Then Return Nothing
                Dim _tmp = clsFSSystemVolume.InitConnection(DestinationFileSource)
                If Not _tmp Is Nothing AndAlso _tmp.CheckConnection Then
                    _tmp.OnRepositoryConnected("Подключено к " & _tmp.ToString)
                    oConnectionBuffer.Add(DestinationFileSource.GetID, _tmp)
                    Return _tmp
                Else
                    ' _tmp.OnRepositoryNotConnected("Неудалось подключится к файловому хранилищу на диске")
                    'ошибка в подключении
                    Return Nothing
                End If


            Case Else
                Debug.Fail("добавте обработку для нового элемента перечисления")



        End Select

        'ошибка в подключении
        Return Nothing

    End Function
    'Private Sub New()
    'End Sub
    ' ''' <summary>
    ' ''' create new object for specific filesource
    ' ''' </summary>
    ' ''' <param name="DestinationFileSource"></param>
    ' ''' <remarks></remarks>
    'Protected Sub New(DestinationFileSource As clsFilesSources)
    '    Me.oDestinationFileSource = DestinationFileSource
    'End Sub

    Public ReadOnly Property DestinationFileSource As clsFilesSources Implements iSource.DestinationFileSource
        Get
            Return oDestinationFileSource
        End Get
    End Property

    Public MustOverride Function GetContentURI(Idcontent As clsIDcontent, ByRef _status As Integer) As System.Uri Implements iSource.GetContentURI

    ''' <summary>
    ''' обязательно в наследниках вызов функции SortKeys !!!!
    ''' </summary>
    ''' <param name="Idcontent"></param>
    ''' <param name="Filter"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public MustOverride Function GetListKeys(Idcontent As clsIDcontent, Optional Filter() As String = Nothing) As System.Collections.Generic.List(Of String) Implements iSource.GetListKeys
    ''' <summary>
    ''' сортирует одинаково все названия сущностей
    ''' </summary>
    ''' <param name="_list"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Function SortKeys(_list As List(Of String)) As List(Of String)
        If _list.Count <= 1 Then Return _list
        'сортировка
        Dim _status As Boolean
        Dim _newSortedList As List(Of KeyValuePair(Of String, Integer)) = Nothing
        Dim _res = CompareKeyNames(_list, _status, _newSortedList)
        If _status Then Return _res

        Return _list


    End Function



    Public MustOverride Function GetSampleList(Optional Filter As String = "") As System.Collections.Generic.List(Of clsApplicationTypes.clsSampleNumber) Implements iSource.GetSampleList


    Public MustOverride Function GetSeriesList() As System.Collections.Generic.List(Of String) Implements iSource.GetSeriesList

    ''' <summary>
    ''' по умолчанию выдает поток из буфера
    ''' </summary>
    ''' <param name="Idcontent"></param>
    ''' <param name="_status"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public MustOverride Sub ReadKeyObj(ByVal Idcontent As clsIDcontent, ByRef status As Integer, Optional ByVal asynhronCall As Boolean = False, Optional ByRef asynhResult As IAsyncResult = Nothing, Optional ByVal IgnoreBuffer As Boolean = False) Implements iSource.ReadKeyObj

    Public Event RepositoryNotConnected(sender As Object, Message As String) Implements iSource.RepositoryNotConnected

    Private Sub OnRepositoryNotConnected(Message As String)
        RaiseEvent RepositoryNotConnected(Me, Message)
    End Sub

    Public MustOverride Function WriteKeyObj(ByVal Idcontent As clsIDcontent, ByRef data As Stream, Optional ByVal _asynhronCall As Boolean = False, Optional ByRef _asynhResult As IAsyncResult = Nothing) As Integer Implements iSource.WriteKeyObj

    Public Event RepositoryConnected(sender As Object, message As String) Implements iSource.RepositoryConnected

    Private Sub OnRepositoryConnected(message As String)
        RaiseEvent RepositoryConnected(Me, message)
    End Sub




    ''' <summary>
    ''' хранит поток в памяти. key - имя потока = ID из strId_content.
    ''' </summary>
    ''' <remarks></remarks>
    Private Shared oStreamInMemBuffer As New Collections.Generic.Dictionary(Of Integer, IO.Stream)

    Protected Sub OnContentWrited(status As Integer)
        RaiseEvent ContentWrited(Me, New ContentWritedEventArgs With {.Status = status})
    End Sub

    Protected Sub OnContentReadyForRead(ByRef data As IO.Stream, content As clsIDcontent)
        Dim _data = data
        RaiseEvent ContentReadyForRead(Me, New ContentReadyEventArgs With {.data = _data, .content = content})
    End Sub

    Public Event ContentReadyForRead(sender As Object, e As ContentReadyEventArgs) Implements iSource.ContentReadyForRead
    ''' <summary>
    '''  удалит обьект из буфера
    ''' </summary>
    ''' <param name="data"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Overloads Shared Function DeleteFromBuffer(data As IO.Stream) As Boolean
        Dim _result = (From c In oStreamInMemBuffer Where IO.Stream.Equals(c.Value, data) Select c).FirstOrDefault

        If Not _result.Value Is Nothing Then
            _result.Value.Close()
            oStreamInMemBuffer.Remove(_result.Key)
            Return True
        End If

        Return False
    End Function


    ''' <summary>
    ''' удалит обьект из буфера
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Overloads Shared Function DeleteFromBuffer(content As clsIDcontent) As Boolean
        If oStreamInMemBuffer.ContainsKey(content.GetID) Then
            oStreamInMemBuffer(content.GetID).Close()
            oStreamInMemBuffer.Remove(content.GetID)
            Return True
        End If
        Return False
    End Function
    ''' <summary>
    ''' проверит обьект в буфере
    ''' </summary>
    ''' <param name="data"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Overloads Shared Function CheckInBuffer(data As IO.Stream) As Boolean
        Dim _result = (From c In oStreamInMemBuffer Where IO.Stream.Equals(c.Value, data) Select c.Value).FirstOrDefault

        If _result Is Nothing Then Return False

        Return True
    End Function

    ''' <summary>
    ''' проверит обьект в буфере. Если есть - запишет в _result.
    ''' </summary>
    Protected Overloads Shared Function CheckInBuffer(content As clsIDcontent, ByRef _result As IO.Stream) As Boolean

        'Return False
        Dim _id = content.GetID

        '    Return False

        If oStreamInMemBuffer.ContainsKey(_id) Then
            Dim _item = oStreamInMemBuffer.Item(_id)

            If _item.CanRead Then
                If _item.Length > 0 Then
                    _result = _item
                    Return True
                End If
            Else
                'поток не доступен
                oStreamInMemBuffer(_id).Close()
                oStreamInMemBuffer.Remove(_id)
            End If
        End If
        Return False
    End Function




    Public Event ContentWrited(sender As Object, e As ContentWritedEventArgs) Implements iSource.ContentWrited

    ''' <summary>
    ''' добавляет обьект в буфер. урезанный обьект не добавлять!!!!
    ''' </summary>
    Protected Shared Sub AddInBuffer(contentID As Integer, ByRef _data As Stream, RewriteBuffer As Boolean)
        'урезанный обьект не добавлять!!!!
        'Return
        SyncLock oStreamInMemBuffer
            If oStreamInMemBuffer.Count = clsIDcontent.cntBufferSize Then

                'очистим 
                Dim em = oStreamInMemBuffer.GetEnumerator
                Dim keysOfClosed As New List(Of Integer)
                For i = 0 To clsIDcontent.cntBufferSize - 1
                    em.MoveNext()
                    Dim _str = em.Current.Value
                    _str.Close()
                    _str.Dispose()

                    'em.Current.Value.Close()

                    keysOfClosed.Add(em.Current.Key)
                Next

                For Each k In keysOfClosed
                    'Dim _str = oStreamInMemBuffer(k)
                    oStreamInMemBuffer.Remove(k)
                    '_str.Close()
                    '_str.Dispose()
                Next
            End If

            If oStreamInMemBuffer.ContainsKey(contentID) Then
                'в потоке есть данные
                If RewriteBuffer Then
                    oStreamInMemBuffer(contentID).Close()
                    oStreamInMemBuffer.Remove(contentID)
                    'перезапишем
                    oStreamInMemBuffer.Add(contentID, _data)
                End If
            Else
                'добавим в буфер
                oStreamInMemBuffer.Add(contentID, _data)
            End If

        End SyncLock
    End Sub

    ''' <summary>
    ''' true - последовательность можно не трогать. False = надо переделывать
    ''' </summary>
    ''' <param name="_list"></param>
    ''' <param name="_status"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function CompareKeyNames(_list As List(Of String), ByRef _status As Boolean, Optional ByRef _compareList As List(Of KeyValuePair(Of String, Integer)) = Nothing) As List(Of String)
        'тут мы изменим номера файлов - добавим нумерацию типа 1-img.jpg
        'разобьем строку, где Value=имя файла до "-"=_cntSplitter; key= имя после штриха (с расширением) [{1}-{IMG2065.jpg}]
        '^\d\-
        _compareList = New List(Of KeyValuePair(Of String, Integer))
        'вернет 0 или индекс фото
        Dim _fn = Function(x As String) As KeyValuePair(Of String, Integer)
                      ' Dim _sh1 = "^\d\-"
                      Dim _sh1 = "\G\d{1,3}[-]{1}"
                      Dim _new = New KeyValuePair(Of String, Integer)(x, 0)
                      Dim _rg = New Regex(_sh1)
                      Dim _answ = _rg.Matches(x)
                      ''получим строку для вырезания из ключа
                      'Dim _exclude As String = ""
                      'For Each t As System.Text.RegularExpressions.Match In _answ
                      '    _exclude += t.Value
                      'Next
                      Select Case _answ.Count
                          Case 0
                              'вхождений нет
                              Return _new
                          Case 1
                              'одно вхождение, вернем отобранное
                              Dim _result As Integer
                              If Integer.TryParse(_answ(0).Value.Trim(_cntSplitter), _result) Then
                                  _new = New KeyValuePair(Of String, Integer)(x.Replace(_answ(0).Value, ""), _result)
                              End If
                          Case Is > 1
                              'видимо есть еще совпадения
                              'получим строку для вырезания из ключа
                              Dim _exclude As String = ""
                              For Each t As System.Text.RegularExpressions.Match In _answ
                                  _exclude += t.Value
                              Next
                              'берем первое - 
                              Dim _result As Integer
                              If Integer.TryParse(_answ(0).Value.Trim(_cntSplitter), _result) Then
                                  _new = New KeyValuePair(Of String, Integer)(x.Replace(_exclude, ""), _result)
                              End If
                      End Select
                      Return _new
                  End Function


        Dim _res = (From c In _list Select _fn.Invoke(c)).ToList
        'сортировка
        _res.Sort(Function(x, y)
                      Return x.Value.CompareTo(y.Value)
                  End Function)
        'поместим в стек
        Dim _stack As New Queue(Of String)
        For Each t In _res
            _stack.Enqueue(t.Key)
        Next

        'вынем со стека
        _status = True
        Dim _sorted As New List(Of KeyValuePair(Of String, Integer))
        For i = 1 To _stack.Count
            Dim _item = _stack.Dequeue
            _sorted.Add(New KeyValuePair(Of String, Integer)(_item, i))
            If Not _res.Item(i - 1).Value = i.ToString Then
                'последовательность Не верная - надо переиндексировать
                _status = False
            End If
        Next

        If _status Then
            _compareList = _res
            Return _list
            'Return (From c In _res Select (c.Value.ToString) & _cntSplitter & (c.Key)).ToList
        Else
            'вернем параметром отсортированную последовательнось, с переделанными индексами - для сохранение
            _status = False
            _compareList = _sorted
            Return _list
        End If


    End Function


    Public Const _cntSplitter = "-"
End Class

Public MustInherit Class clsFileSystemConnectionBase
    Inherits clsConnectionBase

    Protected Enum emCodeType
        NoFolder = 0
        ShotCode = 1
        FullCode = 2
        BothCode = 3
    End Enum






    Protected Sub New(DestinationSource As clsFilesSources)
        MyBase.New(DestinationSource)
    End Sub
    ''' <summary>
    ''' коренной уровень хранения подпапок с номерами образцов = путь к корню контейнера, определяется в процедурах InitConnection
    ''' </summary>
    ''' <remarks></remarks>
    Protected oRootPath As String









    ''' <summary>
    ''' проверяет наличие корневого пути у устройства
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public NotOverridable Overrides Function CheckConnection() As Boolean
        If Not oRootPath Is Nothing AndAlso oRootPath.Length > 0 Then Return True
        Return False
    End Function

    ''' <summary>
    '''базовая.вычисляет путь к папке в хранилище по серии, тому и длинному номеру образца. остальные классы должны переопределить метод для своего использования.
    ''' </summary>
    ''' <param name="IdContent">номер</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected MustOverride Function GetFolderByIdContent(IdContent As clsIDcontent, Optional EAN13Folder As Boolean = False) As String


    Public NotOverridable Overrides Function GetSampleList(Optional Filter As String = "") As System.Collections.Generic.List(Of Service.clsApplicationTypes.clsSampleNumber)
        Dim _sampleColl As New Generic.List(Of clsApplicationTypes.clsSampleNumber)
        If Not CheckConnection() Then Return _sampleColl

        Dim _filter As String = Filter

        If Not Filter.Length = 13 Then
            _filter = Filter & "*"
        End If

        'ищем директорию с номером  в корне
        For Each _tmpDir As String In IO.Directory.GetDirectories(oRootPath, _filter, IO.SearchOption.AllDirectories)
            'номер найден
            Dim _struct = clsApplicationTypes.clsSampleNumber.CreateFromString(IO.Path.GetFileName(_tmpDir))
            If Not _struct Is Nothing AndAlso _struct.CodeIsCorrect Then
                _sampleColl.Add(_struct)
            End If
        Next

        _sampleColl.Sort()
        Return _sampleColl
    End Function

    ''' <summary>
    ''' читает список имен файлов с расширениями в директории по шаблону. пример pattern ="*.jpg", pattern ="img_2454.jpg"
    ''' </summary>
    ''' <param name="path">путь</param>
    ''' <param name="pattern">фильтр файлов</param>
    ''' <returns>список имен файлов</returns>
    ''' <remarks></remarks>
    Private Shared Function GetFilesFromFolderByPattern(ByVal path As String, ByVal pattern As String) As String()
        Dim _list As New List(Of String)
        If IO.Directory.Exists(path) Then
            Dim _result = From c In My.Computer.FileSystem.GetFiles(path, FileIO.SearchOption.SearchTopLevelOnly, pattern) Where IO.Path.GetFileName(c).StartsWith("main_") = False Select IO.Path.GetFileName(c)
            Return _result.ToArray
        End If
        Return New String() {}
    End Function

    ''' <summary>
    ''' вернет путь к обьекту.обеспечит просмотр key="". соответственно, надо проверять на ""!!!
    ''' </summary>
    ''' <param name="Idcontent"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Overridable Function GetKeyPathByIdContent(Idcontent As clsIDcontent) As String
        Debug.Assert(Idcontent.ObjectKey.Length > 0, "не задан ключ в запросе для Idcontent")
        Return IO.Path.Combine(GetFolderByIdContent(Idcontent), Idcontent.ObjectKey)
    End Function

    ''' <summary>
    ''' проверяет существование папки образца.
    ''' </summary>
    Private Function Folder_Exists(IdContent As clsIDcontent) As Boolean
        Return IO.Directory.Exists(GetFolderByIdContent(IdContent))
    End Function

    ''' <summary>
    ''' создает папку на устройстве хранения. если папка есть, возвращает путь к ней
    ''' </summary>
    ''' <returns>путь к созданной папке</returns>
    Private Function Folder_Create(IdContent As clsIDcontent) As String
        Debug.Assert(Not Folder_Exists(IdContent), "проверку наличия папки нужно осуществить до вызова функции создания")
        Dim _root As String = GetFolderByIdContent(IdContent)
        Try
            My.Computer.FileSystem.CreateDirectory(_root)
            Return _root
        Catch ex As IO.IOException
            Debug.Fail("Не возможно создать директорию по пути: " & _root & " " & ex.Message)
            Return ""
        End Try

    End Function

    ''' <summary>
    ''' удаляет папку с устройства хранения
    ''' </summary>
    ''' <returns>-n = ошибка при удалении; 0 - ничего не удалено; +1 - удаление без ошибок.
    ''' </returns>
    ''' <remarks>отрицательные значения говорят об ошибке</remarks>
    Private Function Folder_Delete(IdContent As clsIDcontent) As Integer
        Debug.Assert(Folder_Exists(IdContent), "проверку наличия папки нужно осуществить до вызова функции удаления")
        Dim _path As String = GetFolderByIdContent(IdContent)
        Try
            If IO.Directory.Exists(_path) Then
                My.Computer.FileSystem.DeleteDirectory(_path, FileIO.DeleteDirectoryOption.DeleteAllContents)
                Return 1
            Else
                Throw New IO.IOException
            End If
        Catch ex As IO.IOException
            Debug.Fail("Не возможно удалить директорию по пути: " & _path & " " & ex.Message)
            Return -1
        End Try
    End Function

    ''' <summary>
    ''' находит все файлы, содержащие расширения, заданные content, используя фильтр по именам
    ''' </summary>
    ''' <param name="Idcontent"></param>
    ''' <param name="Filter"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public NotOverridable Overrides Function GetListKeys(Idcontent As clsIDcontent, Optional Filter() As String = Nothing) As System.Collections.Generic.List(Of String)
        Dim _list As New List(Of String)

        'список паттернов
        Dim _patterns = From c In clsIDcontent.GetExtentionListByContentType(Idcontent.ContentType) Select ("*." & c)
        'корень образца
        Dim _sampleRoot = GetFolderByIdContent(Idcontent)

        For Each _patt In _patterns
            _list.AddRange(clsFileSystemConnectionBase.GetFilesFromFolderByPattern(_sampleRoot, _patt))
        Next


        '--------------------------
        'для совместимости
        'проверка штрих-кода полного как имя папки образца
        If _list.Count = 0 Then
            _sampleRoot = GetFolderByIdContent(Idcontent, True)
            For Each _patt In _patterns
                _list.AddRange(clsFileSystemConnectionBase.GetFilesFromFolderByPattern(_sampleRoot, _patt))
            Next
        End If

        'проверка и преобразование главного изображения
        If Idcontent.ContentType = clsIDcontent.emContentType.mainImage Then
            If _list.Count = 0 Then
                'найдем старый вариант главного фото
                Dim _mainPattern = _constMainImagePrephics & "*.jpg"
                Dim _oldMainKeys = clsFileSystemConnectionBase.GetFilesFromFolderByPattern(_sampleRoot, _mainPattern)
                If _oldMainKeys.Length = 1 Then
                    'переименовать старый файл на новый
                    Dim _nk = IO.Path.GetFileNameWithoutExtension(String.Concat(_oldMainKeys(0).Skip(_constMainImagePrephics.Length))) & "." & clsIDcontent.GetExtentionListByContentType(clsIDcontent.emContentType.mainImage)(0)
                    'Dim _newKey = IO.Path.Combine(_path, _nk)
                    If RenameOldMainImageFile(IO.Path.Combine(_sampleRoot, _oldMainKeys(0)), _nk) Then
                        'добавить уже новый кей в список
                        _list.Add(_nk)
                    End If
                End If
            End If
        End If
        '------------------------

        If Not Filter Is Nothing Then
            Dim _result = From c In _list Where Filter.Contains(c) Select c
            Return MyBase.SortKeys(_result.ToList)
        End If

        'сортировка
        Return MyBase.SortKeys(_list.ToList)

    End Function


    'Public Overrides Function GetSeriesList() As List(Of String)
    '    ' clsApplicationTypes.SamplePhotoObject.GetSeriesList()
    '    Dim _result = From c In GetSampleList() Group By sr = c.Series Into tst = Group, Any() Select sr

    '    Return _result.ToList

    'End Function

    ' ''' <summary>
    ' ''' вернет URI или nothing. status -1 error, 0 content отсутствует, 1 все ок.
    ' ''' </summary>
    ' ''' <param name="Idcontent"></param>
    ' ''' <param name="_status"></param>
    ' ''' <returns></returns>
    ' ''' <remarks></remarks>
    'Public MustOverride Function GetContentURI(Idcontent As clsIDcontent, ByRef _status As Integer) As System.Uri
    'Dim _path = GetKeyPathByIdContent(Idcontent)
    '    If My.Computer.FileSystem.FileExists(_path) Then
    'Dim _result As Uri = Nothing
    '        If Uri.TryCreate(_path, UriKind.Absolute, _result) Then
    '            _status = 1
    '            Return _result
    '        Else
    '            _status = -1
    '        End If
    '    Else
    '        _status = 0
    '    End If
    '    Return Nothing
    'End Function
    ''' <summary>
    ''' для совместимости.переименует файл на диске. в случае неуспеха вернет false.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function RenameOldMainImageFile(_pathwithKeyOld As String, _newkey As String) As Boolean
        If Not IO.File.Exists(_pathwithKeyOld) Then Return ""
        Dim _dir = IO.Path.GetDirectoryName(_pathwithKeyOld)

        'переименуем
        Try
            My.Computer.FileSystem.RenameFile(_pathwithKeyOld, _newkey)
        Catch ex As IO.IOException
            Return False
        End Try

        Return True

        'For Each _p As String In GetFilesFromFolderByPattern(CalculatePathForSampleNumber(samplenumber), "*.jpg")
        '    If _p.StartsWith(_constMainImagePrephics) Then
        '        'главное фото есть
        '        Return IO.Path.Combine(CalculatePathForSampleNumber(samplenumber), _p)
        '    End If
        'Next

        'Return ""
    End Function


    ''' <summary>
    ''' проверить наличие файла
    ''' </summary>
    ''' <param name="Idcontent"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public NotOverridable Overrides Function ContainsContent(Idcontent As clsIDcontent) As Boolean
        Dim _path = GetKeyPathByIdContent(Idcontent)
        If _path = "" Then
            Debug.Fail("функция GetKeyPathByIdContent не может вычислить путь.")
            Return False
        End If
        'If _path = "" Then
        '    'контент отсутствует,
        '    'но совместимость со старой версией титульного изображения
        '    If Idcontent.ContentType = strId_content.emContentType.mainImage Then
        '        If Not GetOldMainImagePath(Idcontent.SampleNumber) = "" Then
        '            Return True
        '        End If
        '    End If
        '    'контент отсутствует
        '    Return False
        'End If

        Return My.Computer.FileSystem.FileExists(_path)
    End Function


    Public NotOverridable Overrides Function CountContent(Idcontent As clsIDcontent) As Integer
        Return GetListKeys(Idcontent).Count
    End Function
    ''' <summary>
    ''' переименовывает файл
    ''' </summary>
    ''' <param name="Idcontent"></param>
    ''' <param name="newKeyName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public NotOverridable Overrides Function RenameKey(Idcontent As clsIDcontent, newKeyName As String) As Integer
        'проверки
        Debug.Assert(Idcontent.ObjectKey.Length > 0, "ключ контента обязательно должен быть указан")
        If Idcontent.ObjectKey = "" Then Return -1
        Dim _oldpath = GetKeyPathByIdContent(Idcontent)
        Dim _newIdContent = clsIDcontent.CreateInstance(Idcontent.ContainerName, newKeyName, Idcontent.ContentType, False)
        Dim _newpath = GetKeyPathByIdContent(_newIdContent)
        If _oldpath = "" Then Return -1
        'проверить наличие
        If Not ContainsContent(Idcontent) Then
            Return 0
        End If
        If ContainsContent(_newIdContent) Then
            'файл уже существует
            Return -1
        End If

        'проверка в буфере
        Dim _result As IO.Stream = Nothing
        If CheckInBuffer(Idcontent, _result) Then
            If Not _result Is Nothing Then
                _result.Flush()
                _result.Close()
                'удалить из буфера
                DeleteFromBuffer(Idcontent)
            End If
        End If

        'проверка в буфере
        _result = Nothing
        If CheckInBuffer(_newIdContent, _result) Then
            If Not _result Is Nothing Then
                _result.Flush()
                _result.Close()
                'удалить из буфера
                DeleteFromBuffer(_newIdContent)
            End If
        End If

        'переименование
        Try
            My.Computer.FileSystem.RenameFile(_oldpath, newKeyName)
        Catch ex As IO.IOException
            Debug.Fail("Ошибка при переименовании файла. " & ex.Message)
            Return -1
        End Try

        Return 1
    End Function

    Public NotOverridable Overrides Function DeleteKey(Idcontent As clsIDcontent) As Integer
        'проверки
        Debug.Assert(Idcontent.ObjectKey.Length > 0, "ключ контента обязательно должен быть указан")
        If Idcontent.ObjectKey = "" Then Return -1
        Dim _path = GetKeyPathByIdContent(Idcontent)
        If _path = "" Then Return -1
        'проверить наличие
        If Not ContainsContent(Idcontent) Then
            Return 0
        End If
        'проверка в буфере
        Dim _result As IO.Stream = Nothing
        If CheckInBuffer(Idcontent, _result) Then
            If Not _result Is Nothing Then
                _result.Flush()
                _result.Close()
                'удалить из буфера
                DeleteFromBuffer(Idcontent)
            End If
        End If

        'удаление
        Try
            'IO.File.Delete(_path)
            My.Computer.FileSystem.DeleteFile(_path, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
        Catch ex As IO.IOException
            Debug.Fail("Ошибка при удалении файла. " & ex.Message)
            Return -1
        End Try

        Return 1
    End Function

    Public NotOverridable Overrides Function DeleteBlock(Idcontent As clsIDcontent) As Integer
        Dim _path = GetFolderByIdContent(Idcontent)
        If Not My.Computer.FileSystem.DirectoryExists(_path) Then
            'Debug.Fail("попытка удалить несуществующую директорию")
            Return 0
        End If
        Dim _count = My.Computer.FileSystem.GetFiles(_path).Count
        Try
            My.Computer.FileSystem.DeleteDirectory(_path, FileIO.DeleteDirectoryOption.DeleteAllContents)

        Catch ex As IO.IOException
            Return -1
            Debug.Fail("ошибка при попытке удалить директорию " & ex.Message)
        End Try

        Return _count
    End Function

    ''' <summary>
    ''' читает файл. преобразует его, вызвав функцию strIs_content -> convertToObject
    ''' </summary>
    ''' <param name="_path"></param>
    ''' <remarks></remarks>
    Private Shared Function ReadFile(ByVal _path As String, IdContent As clsIDcontent) As IO.Stream

        If Not IO.File.Exists(_path) Then
            Debug.Fail("запрошенный файл не существует " & _path)
            Return New MemoryStream({})
        End If

        Try
            Dim _fs = My.Computer.FileSystem.ReadAllBytes(_path)
            Dim _newstream As New MemoryStream(_fs)
            Return _newstream
        Catch ex As IOException
            Return New MemoryStream({})
        End Try
        'Try
        '    'прочитаем файл в поток
        '    Dim _stream As System.IO.FileStream = New IO.FileStream(_path, FileMode.Open, FileAccess.Read, FileShare.Read)
        '    Return _stream
        'Catch ex As IO.IOException
        '    Debug.Fail("Ошибка чтения файла " & _path)
        '    Return Nothing
        'End Try
    End Function

    Private Delegate Function WriteContentCall(_path As String, ByRef data As Stream) As Integer

    ''' <summary>
    ''' записывает файл на устройство. 0 - не записан; -1 - ошибка; 1 - записан
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function WriteFile(_path As String, ByRef data As Stream) As Integer
        'write
        Try
            If Not IO.Directory.Exists(IO.Path.GetDirectoryName(_path)) Then
                'create dir
                IO.Directory.CreateDirectory(IO.Path.GetDirectoryName(_path))
            End If
            'read stream
            data.Position = 0
            Dim bytes(data.Length - 1) As Byte
            Dim numBytesToRead As Integer = data.Length
            Dim numBytesRead As Integer = 0
            Dim n As Integer
            While numBytesToRead > 0
                ' Read may return anything from 0 to 10.
                n = data.Read(bytes, numBytesRead, numBytesToRead)
                ' The end of the file is reached.
                If n = 0 Then
                    Exit While
                End If
                numBytesRead += n
                numBytesToRead -= n
            End While

            If CheckInBuffer(data) Then
                DeleteFromBuffer(data)
            End If

            'data.Close()

            'If IO.File.Exists(_path) Then
            '    IO.File.Delete(_path)
            'End If

            Dim _f As New IO.FileStream(_path, FileMode.Create, FileAccess.Write, FileShare.Read)
            Using w As New BinaryWriter(_f)
                ' Write data 
                w.Write(bytes)
                w.Close()
                _f.Close()
            End Using
            'очистка
            bytes = Nothing
        Catch ex As IO.IOException
            Return -1
        End Try

        Return 1

    End Function




    Private Delegate Function ReadContentCall(_path As String, content As clsIDcontent) As Object


    'Private _oReadedObject As Object
    ''' <summary>
    ''' метод завершения асинхронного чтения
    ''' </summary>
    ''' <param name="ar"></param>
    ''' <remarks></remarks>
    Private Sub ReadContentCallBack(ByVal ar As IAsyncResult)
        Dim result As AsyncResult = CType(ar, AsyncResult)
        Dim caller As ReadContentCall = CType(result.AsyncDelegate, ReadContentCall)
        ' Call EndInvoke to retrieve the results.
        Dim returnValue As Stream = caller.EndInvoke(ar)
        'поместим обьект в переменную
        '_oReadedObject = returnValue
        If Not returnValue Is Nothing Then
            OnContentReadyForRead(returnValue, CType(ar.AsyncState, clsIDcontent))
        End If
        returnValue = Nothing
        caller = Nothing
    End Sub

    Private _oWriteResult As Integer
    ''' <summary>
    ''' метод завершения асинхронного чтения
    ''' </summary>
    ''' <param name="ar"></param>
    ''' <remarks></remarks>
    Private Sub WriteContentCallBack(ByVal ar As IAsyncResult)
        Dim result As AsyncResult = CType(ar, AsyncResult)
        Dim caller As WriteContentCall = CType(result.AsyncDelegate, WriteContentCall)
        ' Call EndInvoke to retrieve the results.
        Dim _data As Stream = Nothing
        Dim returnValue As Integer = caller.EndInvoke(_data, ar)
        '_data к этому моменту закрыт!
        'поместим обьект в переменную
        _oWriteResult = returnValue
        OnContentWrited(returnValue)
    End Sub


    ''' <summary>
    '''  если потока нет в буфере, то создает его из файла. Поток помещается в буфер асинхорным методом
    ''' </summary>
    ''' <param name="Idcontent"></param>
    ''' <param name="_status"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public NotOverridable Overrides Sub ReadKeyObj(ByVal Idcontent As clsIDcontent, ByRef _status As Integer, Optional ByVal _asynhronCall As Boolean = False, Optional ByRef _asynhResult As IAsyncResult = Nothing, Optional ByVal IgnoreBuffer As Boolean = False)
        '0 проверка буфера
        Dim _result As Stream = Nothing

        If CheckInBuffer(Idcontent, _result) Then
            If _result.CanRead Then
                If Not IgnoreBuffer Then
                    'венуть из буфера
                    _status = 1
                    OnContentReadyForRead(_result, Idcontent)
                    ' Return _result
                End If

                _result.Flush()
                _result.Close()
                'удалить из буфера
                DeleteFromBuffer(Idcontent)
                'удалить из буфера!!!
            End If
        End If

        '0.1 проверка существования файла
        Dim _path = GetKeyPathByIdContent(Idcontent)
        If _path = "" Then
            _status = -1
            ' Return Nothing
        End If

        Select Case _asynhronCall
            Case True
                'асинхронный вызов
                '1 вызов ReadFile  сделать асинхронным
                'он должен выдать обьект
                Dim _dg As New ReadContentCall(AddressOf ReadFile)
                'сообщим получателю контент
                Dim _param As Object = Idcontent
                'асинхронная установка соединения
                _asynhResult = _dg.BeginInvoke(_path, Idcontent, AddressOf ReadContentCallBack, _param)
                _status = -2
                ' Return Nothing

            Case False
                'синхронный вызов
                _result = ReadFile(_path, Idcontent)
                If _result Is Nothing OrElse _result.Length = 0 Then
                    _status = 0
                    ' Return Nothing
                End If
                'ok
                _status = 1

                'добавить в буфер
                If Idcontent.IsLoppedObject = False Then
                    AddInBuffer(Idcontent.GetID, _result, False)
                End If

                OnContentReadyForRead(_result, Idcontent)
                ' _result.Position = 0
                ' Return _result
        End Select
        '  Return Nothing


        'подождем чутка)) 100mc
        'If _asyncResult.AsyncWaitHandle.WaitOne(200) Then
        '    If _asyncResult.IsCompleted Then
        '        'операция завершена. событие уже прошло. необходимо простовернуть обьект
        '        'он помещен при вызове ReadContentCallBack во внутр. переменную

        '        _result = _oReadedObject
        '        _status = 1
        '        Return _result
        '    End If
        'End If
        'обьект еще не готов! вернем IAsyncResult
    End Sub






    ''' <summary>
    ''' реализация получает data из буфера родителя по определению. -2 - операция еще не завершена
    ''' </summary>
    ''' <param name="Idcontent"></param>
    ''' <param name="data"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public NotOverridable Overrides Function WriteKeyObj(ByVal Idcontent As clsIDcontent, ByRef data As Stream, Optional ByVal _asynhronCall As Boolean = False, Optional ByRef _asynhResult As IAsyncResult = Nothing) As Integer

        'получить путь для создания файла
        Dim _path = GetKeyPathByIdContent(Idcontent)
        If _path = "" Then
            Return -1
            Debug.Fail("Невозможно определить путь к файлу")
        End If

        'check file
        If IO.File.Exists(_path) Then
            'TODO нужна ли проверка на существование?
            '   IO.File.Delete(_fullpath)
        End If

        'проверить данные на вшивость
        If data Is Nothing OrElse data.CanRead = False Then
            Return -1
            Debug.Fail("Файл не может быть записан. Данные потока повреждены. Процедура WriteKeyObj. Обратитесь к администратору.")
        End If

        'проверка получателя данных
        Dim _result As Stream = Nothing

        If CheckInBuffer(Idcontent, _result) Then
            'поток открыт в буфере
            'If _result.CanRead Or _result.CanWrite Then
            '    _result.Close()
            'End If
            DeleteFromBuffer(Idcontent)
        End If

        ''все ок
        'поместим поток в буфер
        'AddInBuffer(Idcontent.GetID, data)

        Select Case _asynhronCall
            Case True
                'вызовем запись файла - асинхронно!!
                'он должен выдать обьект
                Dim _dg As New WriteContentCall(AddressOf WriteFile)
                'сообщим получателю контент
                Dim _param As Object = Idcontent
                'асинхронная установка соединения
                _asynhResult = _dg.BeginInvoke(_path, data, AddressOf WriteContentCallBack, _param)
                'подождем чутка)) 100mc
                If _asynhResult.AsyncWaitHandle.WaitOne(100) Then
                    If _asynhResult.IsCompleted Then
                        'операция завершена. событие уже прошло. необходимо простовернуть результат
                        'он помещен при вызове WriteContentCallBack во внутр. переменную
                        Return _oWriteResult
                    End If
                End If
                'обьект еще не готов! вернем статус незавершенной записи
                Return -2
            Case False
                'вызовем запись файла - синхронно!!
                Dim _result1 = WriteFile(_path, data)
                OnContentWrited(_result1)
                Return _result1
        End Select

        Return -1

    End Function
    ''' <summary>
    ''' вернет путь подключения
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overrides Function ToString() As String
        Return oRootPath
    End Function

End Class

Public Class clsFtpConnection
    Inherits clsConnectionBase

    Protected oRootURI As Uri
    Protected oCredential As NetworkCredential
    Protected oVirtualDirectory As String

    Public Sub New(DestinationSource As clsFilesSources)
        MyBase.New(DestinationSource)
    End Sub

    Public Overrides Function CallService(name As String) As Func(Of Object, MethodInfo)
        Return Nothing
    End Function

    Public Overrides Function CheckConnection() As Boolean
        If oCredential Is Nothing Then Return False
        Return True
    End Function

    Public Overrides Function ContainsContent(Idcontent As clsIDcontent) As Boolean
        Dim _result = (From c In Me.GetListKeys(Idcontent) Where c.Equals(Idcontent.ObjectKey) Select c).ToList
        If _result.Count > 0 Then Return True
        Return False
    End Function

    Public Overrides Function CountContent(Idcontent As clsIDcontent) As Integer
        Return GetListKeys(Idcontent).Count
    End Function

    Public Overrides Function DeleteBlock(Idcontent As clsIDcontent) As Integer
        If ContainsDir(Idcontent, False) Then
            Dim _w As New TrilboneFtpUpLoader
            Dim _target = Me.GetFolderByIdContent(Idcontent)
            Return _w.DeleteDirectory(_target, oCredential)
        End If
        Return 0
    End Function

    Public Overrides Function DeleteKey(Idcontent As clsIDcontent) As Integer
        Dim _out As Integer = 0
        If Me.ContainsContent(Idcontent) Then
            Dim _w As New TrilboneFtpUpLoader
            Dim _target = Me.GetKeyPathByIdContent(Idcontent)
            If _w.DeleteFile(_target, oCredential) > 0 Then
                _out += 1
                If Idcontent.IsLoppedObject Then
                    If Me.ContainsContent(Idcontent.GetAsBig) Then
                        _w = New TrilboneFtpUpLoader
                        _target = Me.GetKeyPathByIdContent(Idcontent.GetAsBig)
                        If _w.DeleteFile(_target, oCredential) > 0 Then
                            _out += 1
                        End If
                    End If
                Else
                    If Me.ContainsContent(Idcontent.GetAsLopped) Then
                        _w = New TrilboneFtpUpLoader
                        _target = Me.GetKeyPathByIdContent(Idcontent.GetAsLopped)
                        If _w.DeleteFile(_target, oCredential) > 0 Then
                            _out += 1
                        End If
                    End If
                End If
            Else
                _out = -1
            End If
        Else
            Return 0
        End If
        Return _out
    End Function

    Public Overrides Function RenameKey(Idcontent As clsIDcontent, newKeyName As String) As Integer
        If Me.ContainsContent(Idcontent) Then
            Dim _w As New TrilboneFtpUpLoader
            Dim _target = Me.GetKeyPathByIdContent(Idcontent)
            Return _w.RenameFile(_target, oCredential, newKeyName)
        End If
        Return 0
    End Function
    ''' <summary>
    ''' Не использовать для внутриклассового применения!!! Меняет схему с ftp на http!!!!
    ''' </summary>
    ''' <param name="Idcontent"></param>
    ''' <param name="_status"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overrides Function GetContentURI(Idcontent As clsIDcontent, ByRef _status As Integer) As System.Uri
        Dim _result = Me.GetKeyPathByIdContent(Idcontent)
        If _result Is Nothing Then _status = -1 : Return _result

        Dim _pth = _result.LocalPath '.Replace(Me.oRootURI.LocalPath, "")
        Dim _ur = New Uri(oVirtualDirectory)
        Dim _new1 = New UriBuilder
        With _new1
            .Scheme = "http"
            .Host = _ur.Host
            .Path = _ur.LocalPath & "/" & _pth.Trim("/")
            ' _ur.LocalPath & "/" & _pth
        End With
        'Dim _n = New Uri(oVirtualDirectory & "/" & Idcontent.ObjectKey)
        '_n = New Uri(_n, Idcontent.ObjectKey)
        'Dim _new1 = New UriBuilder
        'With _new1
        '    .Scheme = "http"
        '    .Host = _result.Host
        '    .Path = oVirtualDirectory & _result.AbsolutePath
        'End With
        _status = 1
        Return _new1.Uri
        'If Idcontent.IsNullContainer Then
        '    Return New Uri(oVirtualDirectory & "/" & Idcontent.ObjectKey)
        'Else
        '    Return New Uri(oVirtualDirectory & "/" & Idcontent.ContainerName & "/" & Idcontent.ObjectKey)
        'End If


    End Function

    Public Overrides Function GetListKeys(Idcontent As clsIDcontent, Optional Filter() As String = Nothing) As System.Collections.Generic.List(Of String)
        'это надо обязательно добавить
        'Return MyBase.SortKeys(_list)
        Dim _split = GetFullList(Idcontent)

        'применить фильтр по типу контента
        'список паттернов
        Dim _patterns = (From c In clsIDcontent.GetExtentionListByContentType(Idcontent.ContentType) Select ("." & c)).ToList

        _split = (From c In _split From p In _patterns Where c.ToLower.Contains(p.ToLower) Select c).Distinct.ToList

        'применить фильтр
        If Not Filter Is Nothing Then
            _split = _split.Intersect(Filter.ToList).ToList
        End If


        ''удалить из списка директорию small
        'If _split.Contains(_constLoppedObjectFolderName) Then
        '    _split.Remove(_constLoppedObjectFolderName)
        'End If
        'сортировка
        Return MyBase.SortKeys(_split)
    End Function
    ''' <summary>
    ''' вернет полный список и файлов, и директорий для контента
    ''' </summary>
    ''' <param name="Idcontent"></param>
    ''' <param name="Filter"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Function GetFullList(Idcontent As clsIDcontent) As List(Of String)
        Dim _uri = Me.GetFolderByIdContent(Idcontent)
        Dim _w As New TrilboneFtpUpLoader
        Dim _request = _w.GetListDir(_uri, oCredential)

        If _request = "" Then Return New List(Of String)

        Dim _result = (_request.Split({ChrW(13)}, System.StringSplitOptions.RemoveEmptyEntries) _
                      .Select(Function(x) x.Trim()).Where(Function(x) Not String.IsNullOrEmpty(x))).ToList


        Dim _split = (From c In _result Select c.Replace(_uri.Segments.Last, "").TrimStart("/")).ToList
        Return _split
    End Function

    Public Overrides Function GetSampleList(Optional Filter As String = "") As System.Collections.Generic.List(Of clsApplicationTypes.clsSampleNumber)
        Dim _sampleColl As New Generic.List(Of clsApplicationTypes.clsSampleNumber)
        If Not CheckConnection() Then Return _sampleColl

        'ищем в корне
        Dim _w As New TrilboneFtpUpLoader
        Dim _request = _w.GetListDir(oRootURI, oCredential)

        If _request = "" Then Return _sampleColl

        Dim _result = (_request.Split({ChrW(13)}, System.StringSplitOptions.RemoveEmptyEntries) _
                      .Select(Function(x) x.Trim()).Where(Function(x) String.IsNullOrEmpty(x))).ToList

        'фильтр
        If Not Filter = "" Then
            _result = _result.Where(Function(x) x.Equals(Filter))
        End If

        'ищем 
        For Each _tmpNum As String In _result
            'номер найден
            Dim _struct = clsApplicationTypes.clsSampleNumber.CreateFromString(IO.Path.GetFileName(_tmpNum))
            If Not _struct Is Nothing AndAlso _struct.CodeIsCorrect Then
                _sampleColl.Add(_struct)
            End If
        Next
        _sampleColl.Sort()
        Return _sampleColl
    End Function

    Public Overrides Function GetSeriesList() As System.Collections.Generic.List(Of String)
        'медленно!! переделать как в fsLocal
        Dim _result = From c In GetSampleList() Group By sr = c.Series Into tst = Group, Any() Select sr
        Return _result.ToList
    End Function

    Public Overrides Sub ReadKeyObj(ByVal Idcontent As clsIDcontent, ByRef _status As Integer, Optional ByVal _asynhronCall As Boolean = False, Optional ByRef _asynhResult As IAsyncResult = Nothing, Optional ByVal IgnoreBuffer As Boolean = False)
        '0 проверка буфера
        Dim _result As Stream = Nothing

        If CheckInBuffer(Idcontent, _result) Then
            If _result.CanRead Then
                If Not IgnoreBuffer Then
                    'венуть из буфера
                    _status = 1
                    OnContentReadyForRead(_result, Idcontent)
                    ' Return _result
                End If

                _result.Flush()
                _result.Close()
                'удалить из буфера
                DeleteFromBuffer(Idcontent)
                'удалить из буфера!!!
            End If
        End If

        '-проверка наличия директории-----------------
        If Not ContainsDir(Idcontent, False) Then
            '  Return Nothing
        End If
        '------------------

        '0.1 проверка существования файла
        Dim _target = Me.GetKeyPathByIdContent(Idcontent)
        Dim _exist = From c In Me.GetListKeys(Idcontent) Where c.Equals(Idcontent.ObjectKey) Select c

        If Not _exist.Count > 0 Then
            'файла нет
            ' Return Nothing
        End If

        Select Case _asynhronCall
            Case True
                ''асинхронный вызов
                ''1 вызов ReadFile  сделать асинхронным
                ''он должен выдать обьект
                'Dim _dg As New ReadContentCall(AddressOf ReadFile)
                ''сообщим получателю контент
                'Dim _param As Object = Idcontent
                ''асинхронная установка соединения
                '_asynhResult = _dg.BeginInvoke(_path, Idcontent, AddressOf ReadContentCallBack, _param)
                '_status = -2
                'Return Nothing
            Case False
                'синхронный вызов
                Dim _w As New TrilboneFtpUpLoader
                'цель -имя файла
                _result = _w.DownloadFile(_target, oCredential)
                '_result = ReadFile(Idcontent, oCredential)
                If _result Is Nothing OrElse _result.Length = 0 Then
                    _status = 0
                    ' Return Nothing
                End If
                'ok
                _status = 1

                'добавить в буфер
                If Idcontent.IsLoppedObject = False Then
                    AddInBuffer(Idcontent.GetID, _result, False)
                End If

                OnContentReadyForRead(_result, Idcontent)
                '  Return _result
        End Select
        ' Return Nothing


        'подождем чутка)) 100mc
        'If _asyncResult.AsyncWaitHandle.WaitOne(200) Then
        '    If _asyncResult.IsCompleted Then
        '        'операция завершена. событие уже прошло. необходимо простовернуть обьект
        '        'он помещен при вызове ReadContentCallBack во внутр. переменную

        '        _result = _oReadedObject
        '        _status = 1
        '        Return _result
        '    End If
        'End If
        'обьект еще не готов! вернем IAsyncResult


    End Sub

    ''' <summary>
    ''' вернет путь к папке с файлами/ короткий код
    ''' </summary>
    ''' <param name="IdContent"></param>
    ''' <param name="EAN13Folder"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Overridable Function GetFolderByIdContent(IdContent As clsIDcontent, Optional EAN13Folder As Boolean = False) As Uri

        Dim _out = New Uri(oRootURI, IdContent.ContainerSampleNumberHash)

        If IdContent.IsLoppedObject Then
            Return New Uri(oRootURI, IdContent.ContainerSampleNumberHash & "/" & _constLoppedObjectFolderName)
        Else
            Return _out
        End If
    End Function
    ''' <summary>
    ''' вернет путь к файлу IdContent
    ''' </summary>
    ''' <param name="IdContent"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetKeyPathByIdContent(IdContent As clsIDcontent) As Uri
        Dim _uri = GetFolderByIdContent(IdContent)
        Dim _new = New Uri(_uri, Uri.EscapeUriString(_uri.LocalPath & "/" & IdContent.ObjectKey))
        ' Dim _new1 = New Uri(_new, IdContent.ObjectKey)
        'используется внутри класса!!! Не менять схему ftp!!!
        Return _new
    End Function

    Protected Overridable Function ContainsDir(IdContent As clsIDcontent, Optional CreateIfNotExist As Boolean = False) As Boolean

        If IdContent.IsLoppedObject Then
            'будем искать small
            If Me.GetFullList(IdContent.GetAsBig).Contains(_constLoppedObjectFolderName) Then
                Return 1
            Else
                'создать папку
                GoTo ex
            End If
        End If

        'ищем в корне
        Dim _w As New TrilboneFtpUpLoader
        Dim _request = _w.GetListDir(oRootURI, oCredential)

        If _request = "" Then GoTo ex

        Dim _result = (_request.Split({ChrW(13)}, System.StringSplitOptions.RemoveEmptyEntries) _
                       .Select(Function(x) x.Trim()).Where(Function(x) Not String.IsNullOrEmpty(x))).ToList

        ''ЗАМЕНА HASH
        Dim _folder As String = IdContent.ContainerSampleNumberHash

        Dim _res = (From c In _result Where c.Equals(_folder) Select c).ToList
        If _res.Count > 0 Then
            Return 1
        End If
        If Not CreateIfNotExist Then
            Return 0
        End If
ex:
        'create dir
        Dim _path = GetFolderByIdContent(IdContent)
        _w = New TrilboneFtpUpLoader
        Return _w.CreateDirectory(_path, oCredential)
    End Function

    ''' <summary>
    ''' 100 - операция запущена
    ''' </summary>
    ''' <param name="Idcontent"></param>
    ''' <param name="data"></param>
    ''' <param name="_asynhronCall"></param>
    ''' <param name="_asynhResult"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overrides Function WriteKeyObj(ByVal Idcontent As clsIDcontent, ByRef data As Stream, Optional ByVal _asynhronCall As Boolean = False, Optional ByRef _asynhResult As IAsyncResult = Nothing) As Integer
        'проверить данные на вшивость
        If data Is Nothing OrElse data.Length = 0 Then
            Return -1
            Debug.Fail("Данные не переданы")
        End If

        'проверка получателя данных
        Dim _result As IO.Stream = Nothing

        If CheckInBuffer(Idcontent, _result) Then
            'поток открыт в буфере
            DeleteFromBuffer(Idcontent)
        End If

        '-проверка наличия директории-----------------
        If Not ContainsDir(Idcontent, True) Then
            Return -2
        End If
        '------------------

        Dim _target = GetKeyPathByIdContent(Idcontent)

        '_asynhronCall=false игнорим
        Dim _w = New TrilboneFtpUpLoader

        ''добавить проверку успешности закачки файла
        ' 0=свободен  1=в процессе 2=ок  -1=error
        oUploadStatusCode = 1

        _w.StartUpload(_target, data, oCredential, _asynhResult)

        Dim _eh = Sub(sender As Object, e As TrilboneFtpUpLoader.UploadEventArgs)
                      If e.Status = FtpStatusCode.ClosingData Then
                          oUploadStatusCode = 2
                      Else
                          oUploadStatusCode = -1
                          'MsgBox(String.Format("Ответ сервера об ошибке {2} ({1}). Сервер {0}", e.ObjectTargetURI.OriginalString, e.Status.ToString, e.Status))
                          'подробно в обработчике исключения в проц. EndGetStreamCallback
                      End If
                  End Sub

        AddHandler _w.ObjectUploaded, _eh

        Dim _start = clsApplicationTypes.GetCurrentTime
        Dim _ts As TimeSpan = clsApplicationTypes.GetCurrentTime - _start
        Do While oUploadStatusCode = 1 And _ts.Minutes = 0
            ''ждать окончания загрузки не более 60 секунд
            _ts = clsApplicationTypes.GetCurrentTime - _start
        Loop

        If oUploadStatusCode = 2 Then oUploadStatusCode = 0 : Return 1
        'сброс параметра

        oUploadStatusCode = 0
        'вернем ошибку
        Return -1

    End Function

    ''' <summary>
    ''' 0=свободен  1=в процессе 2=ок  -1=error
    ''' </summary>
    Public oUploadStatusCode As Integer


    Public Overrides Function ToString() As String
        If oRootURI Is Nothing Then Return "FTP (не подключено)"
        Return "FTP: " & oRootURI.ToString
    End Function

    ''' <summary>
    ''' login должен соответствовать VirtualDirectory= <UserLoginDirectory> как корню дальнейшей структуры каталогов. AccountDirectory содержит "" или путь к нужной рабочей директории относительно <UserLoginDirectory>
    ''' </summary>
    ''' <param name="DestinationSource"></param>
    ''' <param name="FTPServerPath"></param>
    ''' <param name="Password"></param>
    ''' <returns></returns>
    ''' <remarks> !!!!внимание! На сервере надо указать корневой каталог, соответствующий логину!!!!
    '''   т.е. все действия будут совершаться в предположении, что oRootURI=каталогу, заданному как корневой на сервере переданному логину!!!!
    '''   пример:
    '''   oRootURI(FTPServerPath) = "ftp://info.trilbone.com/"
    '''   работаем в серверной директории ftp://info.trilbone.com/img/arhive/, т.к. по установкам сервера для логина trilbone_arhive задана корневая директория  VirtualDirectory = /img/arhive</remarks>

    Friend Shared Function InitConnection(DestinationSource As clsFilesSources, FTPServerPath As String, login As String, Password As String, AccountDirectory As String, VirtualDirectory As String) As clsFtpConnection
        '!!!!внимание! На сервере надо указать корневой каталог, соответствующий логину!!!!
        'т.е. все действия будут совершаться в предположении, что oRootURI=каталогу, заданному как корневой на сервере переданному логину!!!!
        'пример:
        'oRootURI(FTPServerPath) = "ftp://info.trilbone.com/"
        '==работаем в серверной директории ftp://info.trilbone.com/img/arhive/, т.к. по установкам сервера для логина trilbone_arhive задан рабочий каталог WorkDirectory=/img/arhive/
        'если URI указан в форме "ftp://contoso.com/path", то сначала платформа .NET Framework регистрируется на FTP-сервере (используя имя пользователя и пароль, указанные в свойстве Credentials), затем текущий каталог задается как <UserLoginDirectory>/path.

        Dim _conn As New clsFtpConnection(DestinationSource)
        With _conn
            'это корень сервера = login directory
            Dim _ub = New UriBuilder
            With _ub
                .Scheme = "ftp://"
                .Host = FTPServerPath
            End With
            'это смещение на AccountDirectory
            .oRootURI = New Uri(_ub.Uri, AccountDirectory)
            .oCredential = New NetworkCredential(login, Password)
        End With
        'это VirtualDirectory=путь http для генерации URI контента
        _conn.oVirtualDirectory = VirtualDirectory
        Return _conn
    End Function


    Public Class TrilboneFtpUpLoader
        Private Class FtpState
            Private wait As ManualResetEvent
            Private m_request As FtpWebRequest
            Private m_fileName As Stream
            Private m_operationException As Exception = Nothing
            Private status As String

            Public Sub New()
                wait = New ManualResetEvent(False)
            End Sub

            Public ReadOnly Property OperationComplete() As ManualResetEvent
                Get
                    Return wait
                End Get
            End Property

            Public Property Request() As FtpWebRequest
                Get
                    Return m_request
                End Get
                Set(value As FtpWebRequest)
                    m_request = value
                End Set
            End Property

            Public Property FileStream() As Stream
                Get
                    Return m_fileName
                End Get
                Set(value As Stream)
                    m_fileName = value
                End Set
            End Property
            Public Property OperationException() As Exception
                Get
                    Return m_operationException
                End Get
                Set(value As Exception)
                    m_operationException = value
                End Set
            End Property
            Public Property StatusDescription() As String
                Get
                    Return status
                End Get
                Set(value As String)
                    status = value
                End Set
            End Property
        End Class

        Public Function RenameFile(target As Uri, credential As NetworkCredential, newname As String) As Integer
            '------------------
            Dim request As FtpWebRequest = DirectCast(WebRequest.Create(target), FtpWebRequest)
            request.Method = WebRequestMethods.Ftp.Rename
            request.RenameTo = newname
            request.Credentials = credential
            '10 скунд ждем запрос
            request.Timeout = 10000

            If clsApplicationTypes.FtpModeActive Then
                request.UsePassive = False
            Else
                request.UsePassive = True
            End If

            Try
                Dim response As FtpWebResponse = TryCast(request.GetResponse(), FtpWebResponse)
                Select Case response.StatusCode
                    Case FtpStatusCode.CommandOK, FtpStatusCode.FileActionOK, FtpStatusCode.PathnameCreated
                        response.Close()
                        Return 1
                    Case Else
                        response.Close()
                        Return -1
                End Select

            Catch ex As System.Net.WebException
                Return -2
                'Select Case ex.Status
                '    Case WebExceptionStatus.ProtocolError
                '        'файл не найден
                '        Return ""
                '    Case Else
                '        Throw ex
                'End Select
            End Try
        End Function


        Public Function DeleteFile(target As Uri, credential As NetworkCredential) As Integer
            '------------------
            Dim request As FtpWebRequest = DirectCast(WebRequest.Create(target), FtpWebRequest)
            request.Method = WebRequestMethods.Ftp.DeleteFile
            request.Credentials = credential
            '10 скунд ждем запрос
            request.Timeout = 10000
            If clsApplicationTypes.FtpModeActive Then
                request.UsePassive = False
            Else
                request.UsePassive = True
            End If

            Try
                Dim response As FtpWebResponse = TryCast(request.GetResponse(), FtpWebResponse)
                Select Case response.StatusCode
                    Case FtpStatusCode.CommandOK, FtpStatusCode.FileActionOK, FtpStatusCode.PathnameCreated
                        response.Close()
                        Return 1
                    Case Else
                        response.Close()
                        Return -1
                End Select

            Catch ex As System.Net.WebException
                Return -2
                'Select Case ex.Status
                '    Case WebExceptionStatus.ProtocolError
                '        'файл не найден
                '        Return ""
                '    Case Else
                '        Throw ex
                'End Select
            End Try
        End Function


        Public Function DeleteDirectory(target As Uri, credential As NetworkCredential) As Integer
            '------------------
            Dim request As FtpWebRequest = DirectCast(WebRequest.Create(target), FtpWebRequest)
            request.Method = WebRequestMethods.Ftp.RemoveDirectory
            request.Credentials = credential
            '10 скунд ждем запрос
            request.Timeout = 10000

            If clsApplicationTypes.FtpModeActive Then
                request.UsePassive = False
            Else
                request.UsePassive = True
            End If

            Try
                Dim response As FtpWebResponse = TryCast(request.GetResponse(), FtpWebResponse)
                Select Case response.StatusCode
                    Case FtpStatusCode.CommandOK, FtpStatusCode.FileActionOK, FtpStatusCode.PathnameCreated
                        response.Close()
                        Return 1
                    Case Else
                        response.Close()
                        Return -1
                End Select

            Catch ex As System.Net.WebException
                Return -2
                'Select Case ex.Status
                '    Case WebExceptionStatus.ProtocolError
                '        'файл не найден
                '        Return ""
                '    Case Else
                '        Throw ex
                'End Select
            End Try
        End Function


        Public Function CreateDirectory(target As Uri, credential As NetworkCredential) As Integer
            '------------------
            Dim request As FtpWebRequest = DirectCast(WebRequest.Create(target), FtpWebRequest)
            request.Method = WebRequestMethods.Ftp.MakeDirectory
            request.Credentials = credential
            '10 скунд ждем запрос
            request.Timeout = 10000
            If clsApplicationTypes.FtpModeActive Then
                request.UsePassive = False
            Else
                request.UsePassive = True
            End If

            Try
                Dim response As FtpWebResponse = TryCast(request.GetResponse(), FtpWebResponse)
                Select Case response.StatusCode
                    Case FtpStatusCode.CommandOK, FtpStatusCode.FileActionOK, FtpStatusCode.PathnameCreated
                        response.Close()
                        Return 1
                    Case Else
                        response.Close()
                        Return -1
                End Select

            Catch ex As System.Net.WebException
                Return -2
                'Select Case ex.Status
                '    Case WebExceptionStatus.ProtocolError
                '        'файл не найден
                '        Return ""
                '    Case Else
                '        Throw ex
                'End Select
            End Try

        End Function


        Public Function GetListDir(target As Uri, credential As NetworkCredential) As String
            '------------------
            Dim request As FtpWebRequest = DirectCast(WebRequest.Create(target), FtpWebRequest)
            request.Method = WebRequestMethods.Ftp.ListDirectory
            request.Credentials = credential
            '10 скунд ждем запрос
            request.Timeout = 10000
            If clsApplicationTypes.FtpModeActive Then
                request.UsePassive = False
            Else
                request.UsePassive = True
            End If

            Try
                Dim response As FtpWebResponse = TryCast(request.GetResponse(), FtpWebResponse)
                Dim sr As New StreamReader(response.GetResponseStream(), System.Text.Encoding.ASCII)
                Dim Datastring As String = sr.ReadToEnd()
                response.Close()
                Return Datastring
            Catch ex As System.Net.WebException
                Select Case ex.Status
                    Case WebExceptionStatus.ProtocolError
                        'файл не найден
                        Return ""
                    Case Else
                        Throw ex
                End Select
            End Try

        End Function


        Public Function DownloadFile(target As Uri, credential As NetworkCredential) As IO.Stream
            '------------------
            Dim request As WebClient = New WebClient

            request.Credentials = credential

            Try
                Dim newFileData As Byte() = request.DownloadData(target)

                Dim _stream As IO.Stream = New IO.MemoryStream(newFileData)

                Return _stream
            Catch ex As Exception
                Return Nothing
            End Try

        End Function

        ' Command line arguments are two strings:
        ' 1. The url that is the name of the file being uploaded to the server.
        ' 2. The name of the file on the local machine.
        '
        Public Sub StartUpload(target As Uri, data As Stream, credential As NetworkCredential, Optional asynhResult As IAsyncResult = Nothing)
            ' Create a Uri instance with the specified URI string.
            ' If the URI is not correctly formed, the Uri constructor
            ' will throw an exception.
            '  Dim waitObject As ManualResetEvent
            data.Position = 0
            'Dim target As New Uri(args(0))
            'Dim fileName As String = args(1)
            Dim state As New FtpState()
            Dim request As FtpWebRequest = DirectCast(WebRequest.Create(target), FtpWebRequest)
            request.Method = WebRequestMethods.Ftp.UploadFile
            request.UseBinary = True
            request.Credentials = credential
            '10 скунд ждем запрос
            request.Timeout = 10000
            If clsApplicationTypes.FtpModeActive Then
                request.UsePassive = False
            Else
                request.UsePassive = True
            End If
            ' This example uses anonymous logon.
            ' The request is anonymous by default; the credential does not have to be specified. 
            ' The example specifies the credential only to
            ' control how actions are logged on the server.



            ' Store the request in the object that we pass into the
            ' asynchronous operations.
            state.Request = request
            state.FileStream = data

            ' Get the event to wait on.
            ' waitObject = state.OperationComplete

            ' Asynchronously get the stream for the file contents.
            asynhResult = request.BeginGetRequestStream(New AsyncCallback(AddressOf EndGetStreamCallback), state)

            ' Block the current thread until all operations are complete.
            'waitObject.WaitOne()

            '' The operations either completed or threw an exception.
            'If state.OperationException IsNot Nothing Then
            '    Throw state.OperationException
            'Else
            '    Console.WriteLine("The operation completed - {0}", state.StatusDescription)
            'End If
        End Sub

        Private Sub EndGetStreamCallback(ar As IAsyncResult)
            Dim state As FtpState = DirectCast(ar.AsyncState, FtpState)

            Dim requestStream As Stream = Nothing
            ' End the asynchronous call to get the request stream.
            Try
                requestStream = state.Request.EndGetRequestStream(ar)
                ' Copy the file contents to the request stream.
                Const bufferLength As Integer = 2048
                Dim buffer As Byte() = New Byte(bufferLength - 1) {}
                Dim count As Integer = 0
                Dim readBytes As Integer = 0
                ' Dim stream As FileStream = File.OpenRead(state.FileName)
                Do
                    readBytes = state.FileStream.Read(buffer, 0, bufferLength)
                    requestStream.Write(buffer, 0, readBytes)
                    count += readBytes
                Loop While readBytes <> 0
                ' Console.WriteLine("Writing {0} bytes to the stream.", count)
                ' IMPORTANT: Close the request stream before sending the request.
                requestStream.Close()
                ' Asynchronously get the response to the upload request.
                state.Request.BeginGetResponse(New AsyncCallback(AddressOf EndGetResponseCallback), state)
                ' Return exceptions to the main application thread.
            Catch e As Exception
                ' Console.WriteLine("Could not get the request stream.")
                'при ошибке на сервере смотри здесь
                RaiseEvent ObjectUploaded(Me, New UploadEventArgs With {.Status = HttpStatusCode.InternalServerError, .StatusDescription = state.StatusDescription, .AsynhResult = ar, .UploadError = True, .ObjectTargetURI = state.Request.RequestUri})
                state.OperationException = e
                state.OperationComplete.[Set]()
                BeepNOT()
                Return
            End Try
        End Sub

        ' The EndGetResponseCallback method  
        ' completes a call to BeginGetResponse.
        Private Sub EndGetResponseCallback(ar As IAsyncResult)
            Dim state As FtpState = DirectCast(ar.AsyncState, FtpState)
            Dim response As FtpWebResponse = Nothing
            Try
                response = DirectCast(state.Request.EndGetResponse(ar), FtpWebResponse)
                response.Close()
                state.StatusDescription = response.StatusDescription
                ' Signal the main application thread that 
                ' the operation is complete.
                state.OperationComplete.[Set]()
                'событие окончания операции
                RaiseEvent ObjectUploaded(Me, New UploadEventArgs With {.Status = response.StatusCode, .StatusDescription = state.StatusDescription, .AsynhResult = ar, .UploadError = False, .ObjectTargetURI = state.Request.RequestUri})
                ' Return exceptions to the main application thread.
            Catch e As Exception
                '  Console.WriteLine("Error getting response.")
                state.OperationException = e
                state.OperationComplete.[Set]()
                BeepNOT()
                RaiseEvent ObjectUploaded(Me, New UploadEventArgs With {.Status = response.StatusCode, .StatusDescription = state.StatusDescription, .AsynhResult = ar, .UploadError = True, .ObjectTargetURI = state.Request.RequestUri})
            End Try
        End Sub

        Public Event ObjectUploadedError(sender As Object, e As UploadEventArgs)


        Public Event ObjectUploaded(sender As Object, e As UploadEventArgs)

        Public Class UploadEventArgs
            Inherits EventArgs
            Property Status As HttpStatusCode
            Property StatusDescription As String
            Property AsynhResult As IAsyncResult
            Property UploadError As Boolean
            Property ObjectTargetURI As Uri
        End Class

    End Class

End Class

''' <summary>
''' применяется для хранения в папке arhive
''' </summary>
''' <remarks></remarks>
Public Class clsFSlocal
    Inherits clsFileSystemConnectionBase

    Private Shared oPhotoDriveMarkerObject As PhotoDriveMarker.PHOTODRIVEMARKER
    Public Const cntLocalFolderName As String = "arhive_photo"


    Public Overrides Function GetSeriesList() As List(Of String)

        Dim _folder = (IO.Directory.EnumerateDirectories(oRootPath, "*", SearchOption.TopDirectoryOnly))
        _folder = _folder.Select(Function(x) IO.Path.GetFileName(x)).Where(Function(x) x.Length = 3)

        Return _folder.ToList


    End Function


    ''' <summary>
    ''' подключается к локальному хранилищу, ищет файл маркера, _message - сообщение о статусе подключения
    ''' </summary>
    ''' <param name="DestinationSource"></param>
    ''' <remarks></remarks>
    Protected Sub New(DestinationSource As clsFilesSources)
        MyBase.New(DestinationSource)
    End Sub
    ''' <summary>
    ''' create connection. пока только для устройства arhive!! В дальнейшем, будет определятся содержанием файла-маркера хранения.
    ''' </summary>
    ''' <param name="DestinationSource"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Shared Function InitConnection(DestinationSource As clsFilesSources) As clsFSlocal
        If DestinationSource.Source = clsFilesSources.emSources.Arhive Then
            Dim _tmp = New clsFSlocal(DestinationSource)
            _tmp.oRootPath = ArhiveContainerPath
            Return _tmp
        End If
        Return Nothing
    End Function

    ''' <summary>
    ''' переопределяет базовую функцию, используя только короткий код (для людей)
    ''' </summary>
    ''' <param name="IdContent"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Overrides Function GetFolderByIdContent(IdContent As clsIDcontent, Optional EAN13Folder As Boolean = False) As String
        Dim _path = IO.Path.Combine(oRootPath, clsSampleNumber.GetSeries(IdContent.ContainerName), clsSampleNumber.GetVolume(IdContent.ContainerName), IdContent.ContainerName)
        If IdContent.IsLoppedObject Then
            _path = IO.Path.Combine(_path, _constLoppedObjectFolderName)
        End If
        Return _path
    End Function

    ''' <summary>
    ''' вернет URI или nothing. status -1 error, 0 content отсутствует, 1 все ок.
    ''' </summary>
    ''' <param name="Idcontent"></param>
    ''' <param name="_status"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overrides Function GetContentURI(Idcontent As clsIDcontent, ByRef _status As Integer) As System.Uri
        Dim _path = GetKeyPathByIdContent(Idcontent)
        If My.Computer.FileSystem.FileExists(_path) Then
            Dim _result As Uri = Nothing
            If Uri.TryCreate(_path, UriKind.Absolute, _result) Then
                _status = 1
                Return _result
            Else
                _status = -1
            End If
        Else
            _status = 0
        End If
        Return Nothing
    End Function


End Class
''' <summary>
''' применяется для работы с номером образца в свободной папке
''' </summary>
''' <remarks></remarks>
Public Class clsFSFreePath
    Inherits clsFileSystemConnectionBase

    Public Overrides Function GetSeriesList() As List(Of String)

        'Dim _folder = (IO.Directory.EnumerateDirectories(oRootPath, "*", SearchOption.TopDirectoryOnly))
        '_folder = _folder.Select(Function(x) IO.Path.GetDirectoryName(x)).TakeWhile(Function(x) x.Length = 3)

        Return New List(Of String)



    End Function
    ''' <summary>
    ''' вернет URI или nothing. status -1 error, 0 content отсутствует, 1 все ок.
    ''' </summary>
    ''' <param name="Idcontent"></param>
    ''' <param name="_status"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overrides Function GetContentURI(Idcontent As clsIDcontent, ByRef _status As Integer) As System.Uri
        Dim _path = GetKeyPathByIdContent(Idcontent)
        If My.Computer.FileSystem.FileExists(_path) Then
            Dim _result As Uri = Nothing
            'исправлено Idcontent.ObjectKey, UriKind.Relative с целью получить нормальный путь 
            If Uri.TryCreate(_path, UriKind.Absolute, _result) Then
                _status = 1
                Return _result
            Else
                _status = -1
            End If
        Else
            _status = 0
        End If
        Return Nothing
    End Function


    ''' <summary>
    ''' init connection. корневуй путь береться из устройства! Будет проверка!
    ''' </summary>
    ''' <param name="DestinationSource"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Shared Function InitConnection(DestinationSource As clsFilesSources) As clsFSFreePath
        If DestinationSource.Source = clsFilesSources.emSources.FreeFolder Then
            Dim _tmp As New clsFSFreePath(DestinationSource)
            If DestinationSource.ContainerPath.Length > 0 AndAlso IO.Directory.Exists(DestinationSource.ContainerPath) Then
                _tmp.oRootPath = DestinationSource.ContainerPath
                '_tmp.OnRepositoryConnected("connect to Folder " & _tmp.oRootPath)
                Return _tmp
            End If
        End If
        Return Nothing
    End Function
    ''' <summary>
    ''' переопределяет базовую функцию, используя только короткий код (для людей)
    ''' </summary>
    ''' <param name="IdContent"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Overrides Function GetFolderByIdContent(IdContent As clsIDcontent, Optional EAN13Folder As Boolean = False) As String
        'проверим директорию на уровень выше, если она соответствует номеру образца - то вернем путь RootPath
        'если нет - добавим директорию с номером
        If IO.Directory.GetParent(oRootPath) Is Nothing Then
            'работаем в корне диска
            Return IO.Path.Combine(oRootPath, clsSampleNumber.GetShotCodeByFull(IdContent.ContainerName))
        ElseIf String.Equals(IO.Path.GetFileName(oRootPath), clsSampleNumber.GetShotCodeByFull(IdContent.ContainerName), StringComparison.OrdinalIgnoreCase) Or String.Equals(IO.Path.GetFileName(oRootPath), IdContent.ContainerName, StringComparison.OrdinalIgnoreCase) Then
            'работаем в директории с номером x-xxx или ean-13
            Return oRootPath
        Else
            'работаем в другой директории
            'Return IO.Path.Combine(oRootPath, clsSampleNumber.GetShotCodeByFull(IdContent.ContainerName))
            Return IO.Path.Combine(oRootPath)
        End If

    End Function










    ''' <summary>
    ''' создает обьект свободного устройства
    ''' </summary>
    ''' <param name="DestinationSource"></param>
    ''' <remarks></remarks>
    Protected Sub New(DestinationSource As clsFilesSources)
        MyBase.New(DestinationSource)
        'oDestinationFileSource = DestinationSource
    End Sub
End Class

''' <summary>
''' применяется для работы с файлами в заданной ContainerName папке
''' </summary>
''' <remarks></remarks>
Public Class clsFSSystemVolume
    Inherits clsFileSystemConnectionBase

    Public Overrides Function GetSeriesList() As List(Of String)
        Return New List(Of String)
    End Function


    ''' <summary>
    ''' вернет URI или nothing. status -1 error, 0 content отсутствует, 1 все ок.
    ''' </summary>
    ''' <param name="Idcontent"></param>
    ''' <param name="_status"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overrides Function GetContentURI(Idcontent As clsIDcontent, ByRef _status As Integer) As System.Uri
        Dim _path = GetKeyPathByIdContent(Idcontent)
        If My.Computer.FileSystem.FileExists(_path) Then
            Dim _result As Uri = Nothing
            If Uri.TryCreate(Idcontent.ObjectKey, UriKind.Relative, _result) Then
                _status = 1
                Return _result
            Else
                _status = -1
            End If
        Else
            _status = 0
        End If
        Return Nothing
    End Function


    ''' <summary>
    ''' init connection. корневуй путь береться из устройства! Будет проверка!
    ''' </summary>
    ''' <param name="DestinationSource"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Shared Function InitConnection(DestinationSource As clsFilesSources) As clsFSSystemVolume
        If DestinationSource.Source = clsFilesSources.emSources.SystemVolume Then
            Dim _tmp As New clsFSSystemVolume(DestinationSource)
            If DestinationSource.ContainerPath.Length = 0 Then
                Return Nothing
            End If
            If Not IO.Directory.Exists(DestinationSource.ContainerPath) Then
                Try
                    IO.Directory.CreateDirectory(DestinationSource.ContainerPath)
                Catch ex As Exception
                    Debug.Fail("Ошибка создания директории" & ex.Message)
                    MsgBox("Ошибка при чтении папки по пути:" & DestinationSource.ContainerPath & ". Ошибка: " & ex.Message, MsgBoxStyle.Critical)
                    Return Nothing
                End Try

            End If
            _tmp.oRootPath = DestinationSource.ContainerPath

            '_tmp.OnRepositoryConnected("connect to Folder " & _tmp.oRootPath)
            Return _tmp
        End If
        Return Nothing
    End Function
    ''' <summary>
    ''' переопределяет базовую функцию
    ''' </summary>
    ''' <param name="IdContent"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Overrides Function GetFolderByIdContent(IdContent As clsIDcontent, Optional EAN13Folder As Boolean = False) As String
        Return IO.Path.Combine(oRootPath, (IdContent.ContainerName))
    End Function

    Protected Overrides Function GetKeyPathByIdContent(Idcontent As clsIDcontent) As String
        Debug.Assert(Idcontent.ObjectKey.Length > 0, "не задан ключ в запросе для Idcontent")
        'замена / на \
        Dim _key = Idcontent.ObjectKey.Replace("/".ToCharArray, "\".ToCharArray)
        Return IO.Path.Combine(GetFolderByIdContent(Idcontent), _key)
    End Function


    ''' <summary>
    ''' создает обьект свободного устройства
    ''' </summary>
    ''' <param name="DestinationSource"></param>
    ''' <remarks></remarks>
    Protected Sub New(DestinationSource As clsFilesSources)
        MyBase.New(DestinationSource)
    End Sub
End Class

''' <summary>
''' применяется для работы в папе заказов
''' </summary>
''' <remarks></remarks>
Public Class clsFSOrder
    Inherits clsFileSystemConnectionBase
    ''' <summary>
    ''' init connection. корневуй путь береться из устройства! Будет проверка!
    ''' </summary>
    ''' <param name="DestinationSource"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Shared Function InitConnection(DestinationSource As clsFilesSources) As clsFSOrder
        If DestinationSource.Source = clsFilesSources.emSources.SpecificOrder Then
            Dim _tmp As New clsFSOrder(DestinationSource)
            If (Not DestinationSource.Order = Nothing) AndAlso DestinationSource.Order.IsValidOrder Then
                _tmp.oRootPath = IO.Path.Combine(clsApplicationTypes.OrdersPath, DestinationSource.Order.OrderID)
                '_tmp.OnRepositoryConnected("connect to Order " & _tmp.oRootPath)
                Return _tmp
            End If
        End If
        Return Nothing
    End Function

    Public Overrides Function GetSeriesList() As List(Of String)

        Dim _result = From c In GetSampleList() Group By sr = c.Series Into tst = Group, Any() Select sr

        Return _result.ToList

    End Function

    ''' <summary>
    ''' вернет URI или nothing. status -1 error, 0 content отсутствует, 1 все ок.
    ''' </summary>
    ''' <param name="Idcontent"></param>
    ''' <param name="_status"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overrides Function GetContentURI(Idcontent As clsIDcontent, ByRef _status As Integer) As System.Uri
        Dim _path = GetKeyPathByIdContent(Idcontent)
        Dim _v = IO.Path.Combine(IO.Directory.GetParent(_path).Name, Idcontent.ObjectKey)
        If My.Computer.FileSystem.FileExists(_path) Then
            Dim _result As Uri = Nothing
            If Uri.TryCreate(_v, UriKind.Relative, _result) Then
                _status = 1
                Return _result
            Else
                _status = -1
            End If
        Else
            _status = 0
        End If
        Return Nothing
    End Function

    ''' <summary>
    ''' переопределяет базовую функцию, используя только короткий код (для людей)
    ''' </summary>
    ''' <param name="IdContent"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Overrides Function GetFolderByIdContent(IdContent As clsIDcontent, Optional EAN13Folder As Boolean = False) As String
        Dim _path As String
        Select Case EAN13Folder
            Case True
                _path = IO.Path.Combine(oRootPath, IdContent.ContainerName)
                If IdContent.IsLoppedObject Then
                    _path = IO.Path.Combine(_path, _constLoppedObjectFolderName)
                End If
                Return _path

            Case Else
                _path = IO.Path.Combine(oRootPath, clsSampleNumber.GetShotCodeByFull(IdContent.ContainerName))
                If IdContent.IsLoppedObject Then
                    _path = IO.Path.Combine(_path, _constLoppedObjectFolderName)
                End If
                Return _path
        End Select


    End Function
    ''' <summary>
    ''' создает обьект свободного устройства
    ''' </summary>
    ''' <param name="DestinationSource"></param>
    ''' <remarks></remarks>
    Protected Sub New(DestinationSource As clsFilesSources)
        MyBase.New(DestinationSource)
    End Sub
End Class

Public Class clsFreeFtpConnection
    Inherits clsFtpConnection

    Protected Sub New(DestinationSource As clsFilesSources)
        MyBase.New(DestinationSource)
    End Sub
    ''' <summary>
    ''' директория всегда есть, т.к. мы в ней работаем
    ''' </summary>
    ''' <param name="IdContent"></param>
    ''' <param name="CreateIfNotExist"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Overrides Function ContainsDir(IdContent As clsIDcontent, Optional CreateIfNotExist As Boolean = False) As Boolean
        If IdContent.IsLoppedObject Then
            'будем искать small
            If Me.GetFullList(IdContent.GetAsBig).Contains(_constLoppedObjectFolderName) Then
                Return True
            Else
                'создать папку
                GoTo ex
            End If
        End If

        'при пустом контейнере работаем в корне
        If IdContent.IsNullContainer Then Return True

        'ищем в корне
        Dim _w As New TrilboneFtpUpLoader
        Dim _request = _w.GetListDir(oRootURI, oCredential)

        If _request = "" Then GoTo ex

        Dim _result = (_request.Split({ChrW(13)}, System.StringSplitOptions.RemoveEmptyEntries) _
                       .Select(Function(x) x.Trim()).Where(Function(x) Not String.IsNullOrEmpty(x))).ToList


        Dim _folder As String = IdContent.ContainerName

        Dim _res = (From c In _result Where c.Equals(_folder) Select c).ToList
        If _res.Count > 0 Then
            Return 1
        End If

        If Not CreateIfNotExist Then
            Return 0
        End If
ex:
        'create dir
        Dim _path = GetFolderByIdContent(IdContent)
        _w = New TrilboneFtpUpLoader
        Return _w.CreateDirectory(_path, oCredential)
    End Function

    ''' <summary>
    ''' IdContent.ContainerName '= папка относительно AccountDirectory
    ''' </summary>
    ''' <param name="IdContent"></param>
    ''' <param name="EAN13Folder"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Overrides Function GetFolderByIdContent(IdContent As clsIDcontent, Optional EAN13Folder As Boolean = False) As System.Uri

        Dim _out = New Uri(oRootURI, IdContent.ContainerName)

        If IdContent.IsLoppedObject Then
            Return New Uri(oRootURI, IdContent.ContainerName & "/" & _constLoppedObjectFolderName)
        Else
            Return _out
        End If
    End Function

    Public Overrides Function GetSeriesList() As System.Collections.Generic.List(Of String)
        Return New List(Of String)
    End Function

    ''' <summary>
    ''' login должен соответствовать <UserLoginDirectory> как корню дальнейшей структуры каталогов (типа Arhive в гугл диске)!! См описание 
    ''' </summary>
    ''' <param name="DestinationSource"></param>
    ''' <param name="FTPServerPath"></param>
    ''' <param name="Password"></param>
    ''' <returns></returns>
    ''' <remarks> !!!!внимание! На сервере надо указать корневой каталог, соответствующий логину!!!!
    '''   т.е. все действия будут совершаться в предположении, что oRootURI=каталогу, заданному как корневой на сервере переданному логину!!!!
    '''   пример:
    '''   oRootURI(FTPServerPath) = "ftp://info.trilbone.com/"
    '''   работаем в серверной директории ftp://info.trilbone.com/img/arhive/, т.к. по установкам сервера для логина trilbone_arhive задана корневая директория ../img/arhive</remarks>

    Friend Overloads Shared Function InitConnection(DestinationSource As clsFilesSources, FTPServerPath As String, login As String, Password As String, AccountDirectory As String, VirtualDirectory As String) As clsFreeFtpConnection
        '!!!!внимание! На сервере надо указать корневой каталог, соответствующий логину!!!!
        'т.е. все действия будут совершаться в предположении, что oRootURI=каталогу, заданному как корневой на сервере переданному логину!!!!
        'пример:
        'oRootURI(FTPServerPath) = "ftp://info.trilbone.com/"
        '==работаем в серверной директории ftp://info.trilbone.com/img/arhive/, т.к. по установкам сервера для логина trilbone_arhive задан рабочий каталог WorkDirectory=/img/arhive/

        Dim _conn As New clsFreeFtpConnection(DestinationSource)
        With _conn
            'это корень сервера = login directory
            Dim _ub = New UriBuilder
            With _ub
                .Scheme = "ftp://"
                .Host = FTPServerPath
            End With
            'это смещение на AccountDirectory - для AZURE нужен, т.к. там логину соответствует корень сервера
            .oRootURI = New Uri(_ub.Uri, AccountDirectory)
            .oCredential = New NetworkCredential(login, Password)
        End With
        'это VirtualDirectory=путь от корня ftp сервера к AccountDirectory - для генерации HTML пути
        _conn.oVirtualDirectory = VirtualDirectory
        Return _conn
    End Function

End Class
