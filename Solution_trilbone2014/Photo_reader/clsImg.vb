Imports System.Drawing.Drawing2D
Imports System.IO
Imports System.Linq
Imports Photo_reader.clsLayer

Public Class clsLayerManager
    Inherits System.Collections.Generic.List(Of clsLayer)



    ' ''' <summary>
    ' ''' тут храним поток оригинала
    ' ''' </summary>
    ' Private oImageStream As Stream
    Private oOriginalImage As Image
    Dim oImageName As String

    ''' <summary>
    ''' читает файл. преобразует его, вызвав функцию strIs_content -> convertToObject
    ''' </summary>
    ''' <param name="_path"></param>
    ''' <remarks></remarks>
    Private Shared Function ReadFile(ByVal _path As String) As IO.Stream

        If Not IO.File.Exists(_path) Then
            Debug.Fail("запрошенный файл не существует " & _path)
            Return Nothing
        End If

        Try
            'прочитаем файл в поток
            Dim _stream As System.IO.FileStream = New IO.FileStream(_path, FileMode.Open, FileAccess.Read, FileShare.Read)
            Return _stream
        Catch ex As IO.IOException
            Debug.Fail("Ошибка чтения файла " & _path)
            Return Nothing
        End Try
    End Function

    ' ''' <summary>
    ' ''' перерисовывает клиента
    ' ''' </summary>
    ' ''' <param name="rect"></param>
    ' ''' <remarks></remarks>
    'Public Sub InvalidateClient(Optional rect As Rectangle = Nothing)
    '    'добавить к области перерисовки прямоугольнок "сохранить"
    '    If Not rect = Nothing Then
    '        oClientControl.Invalidate(rect)
    '        ' oClientControl.Invalidate(GetSaveImageRectangle)
    '    Else
    '        oClientControl.Invalidate()
    '    End If
    'End Sub

    Public Const _cntLineThinLine As Integer = 2


    Private WithEvents oClientControl As Control

    ' ''' <summary>
    ' ''' прорисовка панели
    ' ''' </summary>
    ' ''' <param name="sender"></param>
    ' ''' <param name="e"></param>
    ' ''' <remarks></remarks>
    'Private Sub Client_Paint(sender As Object, e As PaintEventArgs) Handles oClientControl.Paint
    '    Using _gr = e.Graphics
    '        ' _gr.PageUnit = GraphicsUnit.Pixel
    '        Dim _image = Me.GetClientImage
    '        If Not _image Is Nothing Then
    '            _gr.DrawImage(_image, 0, 0)
    '        End If
    '    End Using
    'End Sub


    ''' <summary>
    ''' создаст класс из файла
    ''' </summary>
    ''' <param name="FilePath"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Shared Function CreateInstance(FilePath As String, client As Control) As clsLayerManager
        Dim _img As Image
        Try
            _img = Image.FromFile(FilePath)

        Catch ex As Exception
            Return Nothing
        End Try

        Return CreateInstance(_img, client)
    End Function

    ''' <summary>
    ''' создаст класс из фото
    ''' </summary>
    Public Overloads Shared Function CreateInstance(Image As Image, client As Control) As clsLayerManager
        Dim _new As New clsLayerManager
        _new.oOriginalSize = Image.Size
        If Image.Tag Is Nothing Then
            _new.oImageName = ""
        Else
            _new.oImageName = Image.Tag
        End If
        'Dim _cn = Service.clsIDcontent.CreateInstance("", Image.Tag.ToString, Service.clsIDcontent.emContentType.image, False)
        '_new.oImageStream = Service.clsIDcontent.ConvertToStream(_cn, Image)
        _new.oOriginalImage = Image
        'Dim _format As System.Drawing.Imaging.ImageFormat = System.Drawing.Imaging.ImageFormat.Jpeg
        'If _format Is Nothing Then
        '    _format = System.Drawing.Imaging.ImageFormat.Jpeg
        'End If

        'Dim _stream As IO.MemoryStream = New IO.MemoryStream
        'Image.Save(_stream, _format)
        '_stream.Flush()
        '_stream.Position = 0
        'If _stream.CanRead = False Then
        '    MsgBox("Ошибка в преобразовании потока файла. Функция ConvertToStream.", vbCritical)
        '    Return Nothing
        'End If
        _new.ClientSize = client.ClientSize
        '_new.oImageStream = _stream
        '   _new.CurrentLineRectColl = New List(Of RectangleF)
        _new.oClientControl = client
        ' AddHandler client.Paint, AddressOf _new.Client_Paint
        Return _new
    End Function


    ' ''' <summary>
    ' ''' создаст класс из потока в памяти
    ' ''' </summary>
    'Public Overloads Shared Function CreateInstance(StreamImage As Stream, client As Control) As clsLayerManager
    '    Dim _new As New clsLayerManager
    '    _new.oImageStream = StreamImage
    '    Dim _tmp As Image = Image.FromStream(StreamImage)
    '    _new.oOriginalSize = _tmp.Size
    '    _new.ClientSize = client.ClientSize
    '    _new.CurrentLineRectColl = New List(Of RectangleF)
    '    _new.oClientControl = client

    '    '  AddHandler client.Paint, AddressOf _new.Client_Paint
    '    Return _new
    'End Function


    ''' <summary>
    ''' размер клиента (на ком рисуем)
    ''' </summary>
    ''' размер клиента (ЭУ)
    Private Property ClientSize As SizeF

    Private oOriginalSize As SizeF



    ''' <summary>
    ''' размер источника
    ''' </summary>
    Private ReadOnly Property OriginalSize As SizeF
        Get
            Return oOriginalSize
        End Get
    End Property

    ''' <summary>
    ''' флаг ставится, если редактированное фото сохранено на источнике фото
    ''' </summary>
    Public Property IsSaved As Boolean
      
    ''' <summary>
    ''' ссылка на фото-источник
    ''' </summary>
    ReadOnly Property OriginalImage As Image
        Get
            Return Me.oOriginalImage
        End Get
    End Property
    ''' <summary>
    ''' добавляет точку к линии
    ''' </summary>
    ''' <param name="location"></param>
    ''' <remarks></remarks>
    Public Sub AddLinePoint(location As PointF, Optional LineThin As Integer = _cntLineThinLine)
        location = PointFToOriginal(location)
        Dim _r = New PointF(location.X - LineThin * Me.KoeffX / 2, location.Y - LineThin * Me.KoeffY / 2)
        Me.oCurrentLineRectColl.Add(New RectangleF With {.Location = _r, .Height = LineThin * Me.KoeffY, .Width = LineThin * Me.KoeffX})
    End Sub


    Private oCurrentLineRectColl As New List(Of RectangleF)
    ' ''' <summary>
    ' ''' коллекция текущих точек линии
    ' ''' </summary>
    ' ''' <value></value>
    ' ''' <returns></returns>
    ' ''' <remarks></remarks>
    'Private ReadOnly Property CurrentLineRectColl As List(Of RectangleF)
    '    Get
    '        ' Return Me.Parent.PointFToClient(oImageLocation)
    '        Dim _p As PointF
    '        For Each t In oCurrentLineRectColl
    '            _p = New PointF(t.X, t.Y)
    '            _p = PointFToClient(_p)
    '            t.X = _p.X
    '            t.Y = _p.Y
    '        Next

    '        Return oCurrentLineRectColl
    '    End Get

    'End Property


    ''' <summary>
    ''' тут храним линии (обьекты рисования)
    ''' </summary>
    Private oLinesArr As New Dictionary(Of String, List(Of RectangleF))


    ''' <summary>
    ''' Очистить коллекцию точек линии
    ''' </summary>
    Public Sub ClearLineCollection()
        oLinesArr.Clear()
    End Sub
    ''' <summary>
    ''' название файла фотки
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property ImageName As String
        Get
            Return oImageName
        End Get
    End Property


    Shadows ReadOnly Property Count As Integer
        Get
            If MyBase.Count = 0 Then
                If Me.oLinesArr.Count = 0 Then
                    Return 0
                Else
                    Return Me.oLinesArr.Count
                End If
            End If
            Return MyBase.Count
        End Get
    End Property


    ''' <summary>
    ''' запоминает коллекцию точек линии  в буфере для вывода
    ''' </summary>
    Public Sub SaveLine()
        If oCurrentLineRectColl Is Nothing Then Return

        'сохранит координаты оригинала
        Dim _newcoll As New List(Of RectangleF)
        For Each t In oCurrentLineRectColl
            _newcoll.Add(t)
        Next

        oLinesArr.Add(_newcoll.GetHashCode, _newcoll)
        oCurrentLineRectColl.Clear()
    End Sub


    ''' <summary>
    ''' масштаб по х
    ''' </summary>
    Public ReadOnly Property KoeffX As Double
        Get
            Return KoeffY ' Me.OriginalSizeF.Width / Me.ClientSizeF.Width
        End Get
    End Property


    ''' <summary>
    ''' масштаб по у
    ''' </summary>
    Public ReadOnly Property KoeffY As Double
        Get
            Return Me.OriginalSize.Height / Me.ClientSize.Height
        End Get
    End Property

    ''' <summary>
    ''' вернет фотку для сохранения
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetToSourceImage() As Image
        If Me.oOriginalImage Is Nothing Then Return Nothing

        Dim _new = New Bitmap(Me.OriginalSize.ToSize.Width, OriginalSize.ToSize.Height)

        Using _gr = Graphics.FromImage(_new)

            _gr.PageUnit = GraphicsUnit.Pixel

            Dim _destinationRect = New RectangleF(0, 0, Me.OriginalSize.Width, OriginalSize.Height)

            _gr.DrawImage(oOriginalImage, _destinationRect)

            'рисуем слои
            Dim _img As Image
            For Each t In Me
                _img = t.GetImage
                _destinationRect = Me.PointFToOriginal(t.ImageRectangle)
                _gr.DrawImage(_img, _destinationRect)
            Next

            'линия
            'это цвет линии
            Dim _pen As New Pen(Color.Red, _cntLineThinLine)

            For Each t In Me.oLinesArr
                Dim _coll As New List(Of RectangleF)
                For Each s In t.Value
                    '_coll.Add(Me.PointFToOriginal(s))
                    _coll.Add(s)
                Next
                If _coll.Count > 0 Then
                    _gr.DrawRectangles(_pen, _coll.ToArray)
                End If
            Next



        End Using
        Return _new


    End Function


    ''' <summary>
    ''' нарисует содержимое, учитывая флаги, на переданном изображении
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetClientImage() As Image

        Dim _new = New Bitmap(Me.ClientSize.ToSize.Width, ClientSize.ToSize.Height)

        Using _gr = Graphics.FromImage(_new)
            ' _gr.Clear(Color.Transparent)
            _gr.PageUnit = GraphicsUnit.Pixel
            If Not Me.oOriginalImage Is Nothing Then

                Dim _destinationRect = New RectangleF(0, 0, Me.PointFToClient(OriginalSize).Width, Me.PointFToClient(OriginalSize).Height)

                _gr.DrawImage(oOriginalImage, _destinationRect)
                'рисуем слои
                Dim _img As Image
                For Each t In Me
                    _img = t.GetImage
                    _gr.DrawImage(_img, t.ImageRectangle)
                Next

                'линия
                'это цвет линии
                Dim _pen As New Pen(Color.Red, _cntLineThinLine)
                _pen.Brush = Brushes.Red

                Dim _coll As New List(Of RectangleF)

                For Each t In Me.oLinesArr
                    For Each s In t.Value
                        _coll.Add(Me.PointFToClient(s))
                    Next
                Next
                If _coll.Count > 0 Then
                    _gr.DrawRectangles(_pen, _coll.ToArray)
                End If

                'значок сохранено - только для клиента

                If Me.IsSaved Then
                    Dim _imgs = My.Resources.ImageSaved
                    _gr.DrawImage(_imgs, GetSaveImageRectangle)
                End If


            Else
                _gr.DrawString("Загрузите фотку..", _
               New Font("Arial", 10), Brushes.Red, New PointF(30.0F, 30.0F))
            End If

        End Using
        Return _new
        'приведем Img к размеру клиента

        'Dim _clientNew = New Bitmap(_new, Me.ClientSizeF)
        'Return _clientNew

    End Function

    Private Function GetSaveImageRectangle() As Rectangle
        Dim _rec = Rectangle.Ceiling(New RectangleF(5, 5, Me.PointFToClient(OriginalSize).Width * 0.1, Me.PointFToClient(OriginalSize).Width * 0.1))
        Return _rec
    End Function


    ''' <summary>
    ''' вернет по точке слой (и)
    ''' </summary>
    ''' <param name="location"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetChildAtPoint(location As PointF) As List(Of clsLayer)
        Dim _result = From c In Me Where c.ImageRectangle.Contains(location) = True Select c
        Return _result.ToList
    End Function


    ''' <summary>
    ''' проверяет, есть ли по этой координате слой
    ''' </summary>
    Public Function HasChildAtPoint(location As PointF) As Boolean


        Dim _result = (From c In Me Where c.ImageRectangle.Contains(location) = True Select c).FirstOrDefault

        If _result Is Nothing Then Return False

        Return True

    End Function

    ''' <summary>
    ''' добавить слой
    ''' </summary>
    Public Shadows Function Add(location As PointF, ID As String, Optional LayerStyle As emImageStyle = emImageStyle.Block) As clsLayer
        Dim _new = clsLayer.CreateInstance(location, ID, Me, LayerStyle)
        MyBase.Add(_new)
        Return _new
    End Function

    ''' <summary>
    ''' удаляет слой по ID
    ''' </summary>
    Public Shadows Function RemoveAt(ID As String) As Boolean
        Dim _result = (From c In Me Where c.IDText = ID Select c).FirstOrDefault

        If _result Is Nothing Then Return False

        Return MyBase.Remove(_result)

    End Function

    ''' <summary>
    ''' удаляет слой по точке
    ''' </summary>
    Public Shadows Function RemoveAt(location As PointF) As Boolean
        Dim _res = Me.GetChildAtPoint(location)
        For Each t In _res
            MyBase.Remove(t)
        Next
        If _res.Count > 0 Then Return True
        Return False
    End Function

    ''' <summary>
    ''' пересчет в масштаб клиента (на ком рисуем)
    ''' </summary>
    Public Overloads Function PointFToClient(size As SizeF) As SizeF
        Dim _out = New SizeF(size.Width / KoeffX, size.Height / KoeffY)
        Return _out
    End Function

    Public Overloads Function PointFToClient(location As PointF) As PointF
        Dim _out = New PointF(location.X / KoeffX, location.Y / KoeffY)
        Return _out
    End Function
    ''' <summary>
    ''' сотрет все линии
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ClearLines()
        Me.oLinesArr.Clear()
    End Sub


    Public Overloads Function PointFToClient(rectangle As RectangleF) As RectangleF
        Dim _out = New RectangleF(rectangle.X / KoeffX, rectangle.Y / KoeffY, rectangle.Width / KoeffX, rectangle.Height / KoeffY)
        Return _out
    End Function

    ''' <summary>
    ''' пересчет в масштаб оригинального фото
    ''' </summary>
    Public Overloads Function PointFToOriginal(rectangle As RectangleF) As RectangleF
        Dim _out = New RectangleF(rectangle.X * KoeffX, rectangle.Y * KoeffY, rectangle.Width * KoeffX, rectangle.Height * KoeffY)
        Return _out
    End Function


    Public Overloads Function PointFToOriginal(size As SizeF) As SizeF
        Dim _out = New SizeF(size.Width * KoeffX, size.Height * KoeffY)
        Return _out
    End Function

    Public Overloads Function PointFToOriginal(location As PointF) As PointF
        Dim _out = New PointF(location.X * KoeffX, location.Y * KoeffY)
        Return _out
    End Function




End Class

Public Class clsLayer

    Public Const _cntInflateStep As Integer = 10

    Private Const _cntInitialSizeF As Integer = 75
    Private Const _cntInitialThin As Integer = 3
    Public Const _cntInitialfontSize As Integer = 44
    Private Shared ReadOnly _cntYesColor As Color = Color.Red
    Private Shared ReadOnly _cntNoColore As Color = Color.Blue
    Private Shared ReadOnly _cntInitialType As emImageStyle = emImageStyle.Block


    Public Enum emImageStyle
        Block
        Arrow
    End Enum


    Public Shared Function CreateInstance(LayerLocation As PointF, ID As String, parent As clsLayerManager, Optional LayerStyle As emImageStyle = emImageStyle.Block) As clsLayer
        Dim _new As New clsLayer
        With _new
            .oParent = parent
            .Background = Color.Transparent
            .BackgroundPercent = 0
            .IDText = ID
            .ImageSize = New SizeF(_cntInitialSizeF, _cntInitialSizeF)
            .ImageLocation = LayerLocation

            .LineColor = _cntYesColor
            .LineThin = _cntInitialThin
            .IsActive = True
            .ImageStyle = LayerStyle
            .FontSize = _cntInitialfontSize
        End With

        Return _new
    End Function

    ''' <summary>
    ''' процент прозрачности заливки от 100(непрозрачно) до 0(прозрачно)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property BackgroundPercent As Integer

    Private oParent
    Public ReadOnly Property Parent As clsLayerManager
        Get
            Return oParent
        End Get
    End Property

    ''' <summary>
    ''' цвет заливки
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Background As Color

    Private oLineColor As Color
    ''' <summary>
    ''' цвет линии
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property LineColor As Color
        Get
            If IsActive Then Return oLineColor
            'переопределит цвет неактивного слоя
            Return _cntNoColore
        End Get
        Set(value As Color)
            oLineColor = value
            IsActive = True
        End Set
    End Property


    ''' <summary>
    ''' толщина линии
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property LineThin As Integer


    Public Property ImageStyle As emImageStyle

    Public Property FontSize As Integer


    ''' <summary>
    ''' вернет изображение для наложения
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetImage() As Image
        Dim _new = New Bitmap(Me.ImageSize.ToSize.Width, Me.ImageSize.ToSize.Height)
        Dim _gr = Graphics.FromImage(_new)
        _gr.PageUnit = GraphicsUnit.Pixel

        Dim _pen As New Pen(Me.LineColor, Me.LineThin)

        'посчитаем шрифт
        Dim _fs = FontSize
        Dim _font = New Font("Arial", _fs)
        _gr.PageUnit = GraphicsUnit.Pixel

        Do While _gr.MeasureString(Me.IDText, _font).Height > (_new.Size.Height / 2)
            _fs -= 1
            _font = New Font("Arial", _fs)
        Loop

        Me.FontSize = _fs


        Select Case ImageStyle
            Case emImageStyle.Arrow
                Dim _point As New List(Of PointF)

                Dim _dx = Me.ImageSize.Width
                Dim _dy = Me.ImageSize.Height

                Dim _base = New Point(_dx * 0.6, _dy * 0.3)
                With _point
                    .Add(_base)
                    Dim _base2 = New Point(_dx * 0.5, _dy * 0.5)
                    Dim _base3 = New Point(_dx * 0.71, _dy * 0.39)
                    .Add(_base2)
                    .Add(_base3)
                End With
                Dim _arr = _point.ToArray
                _gr.DrawPolygon(_pen, _arr)
                _gr.FillPolygon(_pen.Brush, _arr)
                _gr.DrawString(Me.IDText, _font, _pen.Brush, New PointF(_dx * 0.65, _dy * 0))
            Case emImageStyle.Block

                _gr.DrawRectangle(_pen, 0, 0, Me.ImageSize.Width, oImageSize.Height)
                _gr.DrawString(Me.IDText, _font, _pen.Brush, New PointF(0, 0))

        End Select


        Return _new
    End Function

    Public ReadOnly Property ClientRectangle As Rectangle
        Get
            Dim _r = New RectangleF(ImageLocation, (ImageSize))

            Return Rectangle.Ceiling(_r)
        End Get
    End Property


    ''' <summary>
    ''' вернет прямоугольник для рисования клиента
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property ImageRectangle As RectangleF
        Get
            Return New RectangleF(ImageLocation, ImageSize)
        End Get
    End Property
    Private oImageLocation As PointF
    ''' <summary>
    ''' ОТ 0,0 оригинала
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property ImageLocation As PointF
        Get
            'перевести координаты в клиента
            Return Me.Parent.PointFToClient(oImageLocation)
        End Get
        Set(value As PointF)
            value = Me.Parent.PointFToOriginal(value)
            'oImageLocation = PointF.Subtract(, New SizeF(Me.ImageSizeF.Width / 2, Me.ImageSizeF.Height / 2))
            oImageLocation = New PointF(value.X - Me.ImageSize.Width * Me.Parent.KoeffX / 2, value.Y - Me.ImageSize.Height * Me.Parent.KoeffY / 2)
        End Set
    End Property

    ''' <summary>
    ''' номер фоссилии
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property IDText As String

    Private oImageSize As SizeF
    ''' <summary>
    ''' размер изображения. Будет менятся
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property ImageSize As SizeF
        Get
            Return oImageSize
        End Get
        Set(value As SizeF)
            oImageSize = value

            ' oImageLocation = PointF.Subtract(New PointF(oImageLocation.X, oImageLocation.Y), New SizeF(Me.ImageSizeF.Width / 2, Me.ImageSizeF.Height / 2))


        End Set
    End Property

    ''' <summary>
    ''' увеличит размер прямоугольника
    ''' </summary>
    ''' <param name="stepI"></param>
    ''' <remarks></remarks>
    Public Sub IncreaseSize(stepI As PointF)
        Dim _newSize = SizeF.Add(Me.ImageSize, New SizeF(stepI))
        Me.ImageSize = _newSize
        Me.FontSize += 1
    End Sub
    ''' <summary>
    ''' уменьшит размер прямоугольника
    ''' </summary>
    ''' <param name="stepI"></param>
    ''' <remarks></remarks>
    Public Sub DecreaseSize(stepI As PointF)
        Dim _newSizeF = SizeF.Subtract(Me.ImageSize, New SizeF(stepI))
        Me.ImageSize = _newSizeF
        Me.FontSize -= 1
        If Me.FontSize < 4 Then Me.FontSize = 4

    End Sub


    ''' <summary>
    ''' если активный, в другом случае цвет линии будет переопределен (НЕ ЗАМЕНЕН!!!) на красный
    ''' </summary>
    Public Property IsActive As Boolean





End Class
