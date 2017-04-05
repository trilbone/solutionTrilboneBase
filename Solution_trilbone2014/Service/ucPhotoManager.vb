Imports System.Windows.Forms
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.IO
Imports System.Linq
Imports Service.ucPhotoManager.clsLayer
Imports System.Reflection
Imports System.ComponentModel


Public Class ucPhotoManager

#Region "внутренние классы"
    Friend Class clsLayerManager
        Inherits System.Collections.Generic.List(Of clsLayer)

        Private oOriginalImage As Image
        Private oImageName As String
        Public Const _cntLineThinLine As Integer = 2
        Private WithEvents oClientControl As Control

        Private oOriginalSize As SizeF
        Private oCurrentLineRectColl As New List(Of RectangleF)

        ''' <summary>
        ''' тут храним линии (обьекты рисования)
        ''' </summary>
        Private oLinesArr As New Dictionary(Of String, List(Of RectangleF))
        '==============================
        ''' <summary>
        ''' размер клиента (на ком рисуем)
        ''' </summary>
        Private Property ClientSize As SizeF

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
                _new.oImageName = Image.Tag.ToString
            End If
            _new.oOriginalImage = Image
            _new.ClientSize = client.ClientSize
            _new.oClientControl = client
            Return _new
        End Function

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
            If Me.ClientSize.Width = 0 Or Me.ClientSize.Height = 0 Then Return Nothing
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
                        Dim _imgs = My.Resources.Resource.ImageSaved
                        _gr.DrawImage(_imgs, GetSaveImageRectangle)
                    End If


                Else
                    _gr.DrawString("Фото не загружены в базу...", _
                   New Font("Arial", 10), Brushes.Green, New PointF(30.0F, 30.0F))
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
            Dim _out = New SizeF(size.Width / (KoeffX), size.Height / (KoeffY))
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

    Friend Class clsLayer

        Public Const _cntInflateStep As Integer = 10
        Private Const _cntInitialSizeF As Integer = 75
        Private Const _cntInitialThin As Integer = 3
        Public Const _cntInitialfontSize As Integer = 44
        Private Shared ReadOnly _cntYesColor As Color = Color.Red
        Private Shared ReadOnly _cntNoColore As Color = Color.Blue
        Private Shared ReadOnly _cntInitialType As emImageStyle = emImageStyle.Block
        Private oParent As clsLayerManager
        Private oLineColor As Color
        Private oImageLocation As PointF
        Private oImageSize As SizeF


        Public Enum emImageStyle
            Block
            Arrow
        End Enum


        Friend Shared Function CreateInstance(LayerLocation As PointF, ID As String, parent As clsLayerManager, Optional LayerStyle As emImageStyle = emImageStyle.Block) As clsLayer
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

        Friend ReadOnly Property Parent As clsLayerManager
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

    Private Class SplashScreen1
        Inherits System.Windows.Forms.Form
        'Является обязательной для конструктора форм Windows Forms
        Private components As System.ComponentModel.IContainer
        Public Sub New()
            InitializeComponent()
        End Sub
        'Примечание: следующая процедура является обязательной для конструктора форм Windows Forms
        'Для ее изменения используйте конструктор форм Windows Form.  
        'Не изменяйте ее в редакторе исходного кода.
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.SuspendLayout()
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(47, 39)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(160, 13)
            Me.Label1.TabIndex = 0
            Me.Label1.Text = "Загрузка данных. Подождите."
            '
            'SplashScreen1
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BackColor = System.Drawing.SystemColors.Highlight
            Me.ClientSize = New System.Drawing.Size(251, 89)
            Me.ControlBox = False
            Me.Controls.Add(Me.Label1)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "SplashScreen1"
            Me.ShowInTaskbar = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.ResumeLayout(False)
            Me.PerformLayout()
        End Sub
        Friend WithEvents Label1 As System.Windows.Forms.Label

    End Class

#End Region


    Private oIdCount As Integer
    Private oMouseMoving As Boolean
    'обьект текщего слоя 
    Private oCurrentLayer As clsLayer
    'коллекция слоев
    Private oLayerManagerCollection As List(Of clsLayerManager)
    Private oSampleNumber As clsApplicationTypes.clsSampleNumber
    Private oCurrentSource As clsFilesSources
    ' ''' <summary>
    ' ''' содержит текущий индекс выбранной фото
    ' ''' </summary>
    ' ''' <remarks></remarks>
    'Private oCurrentIndex As Integer
    Friend WithEvents Panel1 As MyPanel

#Region "рисование на фото"
#Region "Управление мышой"
    ''' <summary>
    ''' это вместо перехвата события панели - прокрутка мышки
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Form_MouseWheel(sender As Object, e As MouseEventArgs) Handles Panel1.MouseWheel
        If Me.bs_images.Current Is Nothing Then Return
        If oLayerManagerCollection.Count = 0 Then Return
        Dim _CurrentLayerManager As clsLayerManager = Me.bs_images.Current

        Dim _ctl = Me.GetChildAtPoint(e.Location)

        If Not _ctl Is Panel1 Then Return

        oCurrentLayer = _CurrentLayerManager.GetChildAtPoint(e.Location).FirstOrDefault
        If oCurrentLayer Is Nothing Then Return

        _CurrentLayerManager.IsSaved = False

        Select Case e.Delta
            Case Is > 0

                If My.Computer.Keyboard.CtrlKeyDown = True Then
                    'в ширину
                    oCurrentLayer.IncreaseSize(New Point(clsLayer._cntInflateStep, 0))
                ElseIf My.Computer.Keyboard.AltKeyDown = True Then
                    'в высоту
                    oCurrentLayer.IncreaseSize(New Point(0, clsLayer._cntInflateStep))
                    ' nudFontSize.Value += clsLayer._cntInflateStep
                Else
                    'равномерно
                    oCurrentLayer.IncreaseSize(New Point(clsLayer._cntInflateStep, clsLayer._cntInflateStep))
                    ' nudFontSize.Value += clsLayer._cntInflateStep
                End If


            Case Is < 0
                If My.Computer.Keyboard.CtrlKeyDown = True Then
                    oCurrentLayer.DecreaseSize(New Point(clsLayer._cntInflateStep, 0))
                ElseIf My.Computer.Keyboard.AltKeyDown = True Then
                    oCurrentLayer.DecreaseSize(New Point(0, clsLayer._cntInflateStep))
                    ' nudFontSize.Value -= clsLayer._cntInflateStep
                Else
                    oCurrentLayer.DecreaseSize(New Point(clsLayer._cntInflateStep, clsLayer._cntInflateStep))
                    ' nudFontSize.Value -= clsLayer._cntInflateStep
                End If
        End Select
        Dim _rect = oCurrentLayer.ImageRectangle
        _rect.Inflate(New Size(clsLayer._cntInflateStep, clsLayer._cntInflateStep))
        Panel1.Invalidate(Rectangle.Ceiling(_rect), False)



    End Sub


    ''' <summary>
    ''' добавление/удаление слоев
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Panel1_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel1.MouseClick
        If Me.bs_images.Current Is Nothing Then Return
        If oLayerManagerCollection.Count = 0 Then Return

        Dim _CurrentLayerManager As clsLayerManager = Me.bs_images.Current
        'если перемещаем, то отменить
        If Me.oMouseMoving Then Return


        Select Case e.Button

            Case Windows.Forms.MouseButtons.Left

                If Not _CurrentLayerManager.HasChildAtPoint(e.Location) Then
                    _CurrentLayerManager.IsSaved = False

                    Dim _layerText As String = ""
                    Dim _layerStyle As emImageStyle = emImageStyle.Block
                    'выбран номер
                    If rbRectangle.Checked Or rbArrow.Checked Then
                        oIdCount += 1

                        'вызвать, если задана, функцию получения номера фоссилии
                        'передать планируемый номер вкладки
                        If Me.GetLayerTextNumberDelegate Is Nothing Then
                            _layerText = oIdCount
                        Else
                            _layerText = Me.GetLayerTextNumberDelegate.Invoke(oIdCount)
                        End If

                    End If

                    'выбран текст
                    If rbText.Checked Then
                        _layerText = tbTextPanel.Text
                    End If

                    'выбрана стрелка
                    If rbArrow.Checked Then
                        _layerStyle = emImageStyle.Arrow
                    End If

                    '---add layer
                    Me.oCurrentLayer = _CurrentLayerManager.Add(e.Location, _layerText, _layerStyle)

                    If _CurrentLayerManager.IsSaved = True Then
                        Me.Panel1.Invalidate(oCurrentLayer.ClientRectangle)
                    Else
                        Me.Panel1.Invalidate()
                    End If



                End If

            Case Windows.Forms.MouseButtons.Right
                If _CurrentLayerManager.HasChildAtPoint(e.Location) Then
                    _CurrentLayerManager.IsSaved = False
                    Dim _layer As clsLayer = Nothing
                    Me.oCurrentLayer = Nothing
                    _layer = _CurrentLayerManager.GetChildAtPoint(e.Location)(0)
                    _CurrentLayerManager.RemoveAt(e.Location)
                    oIdCount -= 1
                    If _CurrentLayerManager.Count = 0 Then Me.oIdCount = 0

                    If _CurrentLayerManager.IsSaved = True Then
                        Me.Panel1.Invalidate(_layer.ClientRectangle)
                    Else
                        Me.Panel1.Invalidate()
                    End If


                End If
        End Select

        If oCurrentLayer Is Nothing Then
            tbTextPanel.Text = ""
        Else
            tbTextPanel.Text = oCurrentLayer.IDText
        End If
    End Sub


    ''' <summary>
    ''' активировать/деактивировать слой
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Panel1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Panel1.MouseDoubleClick
        If Me.bs_images.Current Is Nothing Then Return
        If oLayerManagerCollection.Count = 0 Then Return

        Dim _CurrentLayerManager As clsLayerManager = Me.bs_images.Current

        If _CurrentLayerManager.HasChildAtPoint(e.Location) Then
            _CurrentLayerManager.IsSaved = False
            Me.oCurrentLayer = _CurrentLayerManager.GetChildAtPoint(e.Location)(0)
            oCurrentLayer.IsActive = Not oCurrentLayer.IsActive
            Me.Panel1.Invalidate(Rectangle.Ceiling(oCurrentLayer.ImageRectangle), False)
        End If
    End Sub

#Region "движение мышкой"

    Private Sub Panel1_MouseLeave(sender As Object, e As EventArgs) Handles Panel1.MouseLeave
        Panel1.Cursor = Cursors.Arrow
    End Sub

    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel1.MouseMove
        If Me.bs_images.Current Is Nothing Then Return
        If oLayerManagerCollection.Count = 0 Then Return

        Panel1.Focus()
        Dim _CurrentLayerManager As clsLayerManager = Me.bs_images.Current

        Select Case e.Button
            Case Windows.Forms.MouseButtons.None
                Panel1.Cursor = Cursors.Cross
            Case Windows.Forms.MouseButtons.Left
                _CurrentLayerManager.IsSaved = False

                'перемещаем
                If rbLine.Checked Then
                    Me.oMouseMoving = True
                    'рисуем линию
                    Using _gr = Panel1.CreateGraphics()
                        Dim _rect = New Rectangle(e.X, e.Y, clsLayerManager._cntLineThinLine, clsLayerManager._cntLineThinLine)
                        _CurrentLayerManager.AddLinePoint(e.Location)
                        _gr.DrawRectangle(New Pen(Color.Red), _rect)
                        ' Panel1.Invalidate(_rect, False)
                    End Using
                Else
                    Me.oCurrentLayer = _CurrentLayerManager.GetChildAtPoint(e.Location).FirstOrDefault
                    If Me.oCurrentLayer Is Nothing Then Return
                    Me.oMouseMoving = True
                    'двигаем слой
                    Panel1.Cursor = Cursors.Hand
                    Dim _rect = Rectangle.Ceiling(Me.oCurrentLayer.ImageRectangle)
                    ' _rect.Inflate(10, 10)
                    Dim _rec1 = Rectangle.Ceiling(Me.oCurrentLayer.ImageRectangle)
                    ' _rec1.Inflate(10, 10)

                    Me.oCurrentLayer.ImageLocation = e.Location

                    Panel1.Invalidate(_rect, False)
                    Panel1.Invalidate(_rec1, False)
                End If
        End Select
    End Sub
    ''' <summary>
    ''' запомнить обьекты в конце рисования
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Panel1_MouseUp(sender As Object, e As MouseEventArgs) Handles Panel1.MouseUp
        If Me.bs_images.Current Is Nothing Then Return
        If oLayerManagerCollection.Count = 0 Then Return
        Dim _CurrentLayerManager As clsLayerManager = Me.bs_images.Current
        _CurrentLayerManager.IsSaved = False
        oMouseMoving = False
        'запомнить линию
        _CurrentLayerManager.SaveLine()
        Panel1.Cursor = Cursors.Cross
    End Sub

#End Region


#End Region

#End Region


#Region "Прорисовка панели"
    ''' <summary>
    ''' прорисовка панели
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        If Me.bs_images.Current Is Nothing Then Return
        Using _gr = e.Graphics
            ' If Me.bs_images.Current Is Nothing Then
            If oLayerManagerCollection Is Nothing OrElse oLayerManagerCollection.Count = 0 Then
                _gr.DrawString("нет фото..", New Font("Arial", 10), Brushes.Red, New PointF(30.0F, 30.0F))
                Return
            End If

            Dim _CurrentLayerManager As clsLayerManager = Me.bs_images.Current

            _gr.PageUnit = GraphicsUnit.Pixel

            Dim _image = _CurrentLayerManager.GetClientImage

            If Not _image Is Nothing Then
                _gr.DrawImage(_image, 0, 0)
            End If

        End Using

        If Not Me.oCurrentLayer Is Nothing Then
            nudFontSize.Value = Me.oCurrentLayer.FontSize
        End If
        Me.Invalidate()
    End Sub


#End Region

#Region "Работа с источником данных"

    ''' <summary>
    ''' переключились на другую фото. Обновили панель.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub SampleImageBindingsource_CurrentChanged(sender As Object, e As EventArgs) Handles bs_images.CurrentItemChanged
        If bs_images.Current Is Nothing Then Return
        If oLayerManagerCollection.Count = 0 Then Return
        ' Me.oCurrentIndex = bs_images.CurrencyManager.Position
        Me.Panel1.Invalidate()
        Application.DoEvents()
    End Sub

    ''' <summary>
    ''' загрузка фото в ДС. создание коллекцию обьектов-контейнеров слоев
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadImagesToPanel(Optional ImageNameFilter As String() = Nothing)
        Debug.Assert(Not oSampleNumber Is Nothing, "Перерисовка панели невозможна.  oSampleNumber is Nothing")
        Debug.Assert(Not oCurrentSource Is Nothing, "Перерисовка панели невозможна.  oCurrentSource is Nothing")
        '---------------------очистка
        Me.cbLineColor.SelectedItem = "Red"
        Me.oIdCount = 0
        Me.oCurrentLayer = Nothing
        Me.bs_images.DataSource = Nothing
        '----------------получить фото
        Dim _imglist = clsApplicationTypes.SamplePhotoObject.GetImageCollection(Me.oSampleNumber, oCurrentSource, False, ImageNameFilter)

        oLayerManagerCollection.Clear()
        Dim _index As Integer = 0
        For Each _img In _imglist
            _index += 1
            Dim a = _img.Size
            oLayerManagerCollection.Add(clsLayerManager.CreateInstance(_img, Me.Panel1))
        Next
        '---привязка
        Me.bs_images.DataSource = oLayerManagerCollection
        Me.BindingNavigator1.ResetBindings()
    End Sub
#End Region



#Region "Фабрика конструктор и инициализация"
    Public Sub New()
        ' Этот вызов является обязательным для конструктора.
        InitializeComponent()

        'создание панели для отображения фото
        createPanel()
        ' Добавьте все инициализирующие действия после вызова InitializeComponent().
        Me.nudFontSize.Value = clsLayer._cntInitialfontSize

        'перехват фокуса элемента на панель
        AddHandler MyBase.GotFocus, AddressOf MeGotFocusEventHandler

        Me.cbLineColor.Items.AddRange([Enum].GetNames(GetType(Drawing.KnownColor)))

        'инициализация коллекции
        oLayerManagerCollection = New List(Of clsLayerManager)

        'доступные FTP
        Me.ToolStripComboBoxFtp.Items.Add(Service.clsFilesSources.emSources.FtpInfoTrilbone)
        Me.ToolStripComboBoxFtp.SelectedIndex = 0

    End Sub

    Private Sub createPanel()
        Me.Panel1 = New MyPanel
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(536, 386)
        Me.Panel1.TabIndex = 1
        Me.Controls.Add(Me.Panel1)
    End Sub

    Friend Class MyPanel
        Inherits Panel
        Public Sub New()
            MyBase.New()
            MyBase.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
            'MyBase.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
            MyBase.SetStyle(ControlStyles.UserPaint, True)
            'MyBase.SetStyle(ControlStyles.DoubleBuffer, True)
            'MyBase.DoubleBuffered = True
        End Sub
    End Class

    Private Sub MeGotFocusEventHandler(sender As Object, e As EventArgs)
        Me.Panel1.Focus()
    End Sub

    ''' <summary>
    ''' при указании должен вернуть текст слоя исходя из его порядкового номера
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property GetLayerTextNumberDelegate As Func(Of Integer, String)



#End Region

#Region "Открытые методы"

    ''' <summary>
    ''' загрузит фото в ЭУ. NumberLayerDelegate может быть Nothing
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub LoadImages(SampleNumber As clsApplicationTypes.clsSampleNumber, Source As clsFilesSources, NumberLayerDelegate As Func(Of Integer, String), Optional ImageNameFilter As String() = Nothing)
        Debug.Assert(Not SampleNumber Is Nothing, "Передан пустой параметр")
        Debug.Assert(Not Source Is Nothing, "Передан пустой параметр")

        If SampleNumber Is Nothing Then Return
        If Source Is Nothing Then Return

        oSampleNumber = SampleNumber
        oCurrentSource = Source
        Me.GetLayerTextNumberDelegate = NumberLayerDelegate

        Me.LoadImagesToPanel(ImageNameFilter)
        Me.btRefreshLayer.Enabled = True
    End Sub

    Public Event PhotoListChanged(sender As Object, e As EventArgs)

    Public Event PhotosDeleted(sender As Object, e As PhotoEventArgs)

    Public Event PhotosAdded(sender As Object, e As PhotoEventArgs)

    Public Class PhotoEventArgs
        Inherits EventArgs
        Property ImageNamesList() As String()
    End Class

#End Region


#Region "управление текущим индексом и кнопки на навигаторе"
    ''' <summary>
    ''' одиночное фото
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButtonAddOneImage.Click
        Me.CopyFilesToSource(Me.SelectFolderOrFile(False))
    End Sub
    ''' <summary>
    ''' копирует файлы
    ''' </summary>
    ''' <param name="files"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CopyFilesToSource(files As String()) As Boolean
        If files Is Nothing OrElse files.Count = 0 Then Return False
        Dim Tosource = oCurrentSource
        Dim _message As String = String.Format("Копировать {0} фотo в {1}?", files.Count, oCurrentSource.GetStringForUser)
        Dim _status As Integer
        Dim _filter = (From c In files Select IO.Path.GetFileName(c)).ToArray
        Dim Fromsource = clsFilesSources.CreateInstance(clsFilesSources.emSources.FreeFolder, Nothing, False, IO.Path.GetDirectoryName(files.FirstOrDefault), False)

        'задать вопрос
        Select Case MsgBox(_message, MsgBoxStyle.YesNo)
            Case MsgBoxResult.Yes
                'копировать
                _status = clsApplicationTypes.SamplePhotoObject.CopyImagesFromSourceToSource(Me.oSampleNumber, Fromsource, Tosource, False, _filter, 1600, False)
            Case MsgBoxResult.No
                Return False
        End Select
        Select Case _status
            Case Is > 0
                clsApplicationTypes.BeepYES()

                ''обновить список
                Me.LoadImagesToPanel()
                RaiseEvent PhotosAdded(Me, New PhotoEventArgs With {.ImageNamesList = _filter})
                RaiseEvent PhotoListChanged(Me, EventArgs.Empty)
                Return True
            Case 0
                MsgBox("Из источника файлы НЕ скопированы! Уже есть в  " & oCurrentSource.GetStringForUser, vbCritical)
            Case -1
                MsgBox("Из источника - ошибка при копировании файлов", vbCritical)
        End Select
        Return False
    End Function

    ''' <summary>
    ''' OneFile - отобразить окно для выбора одиночного файла; UseProgFolder-проверить сначала папку обработанные
    ''' </summary>
    ''' <param name="OneFile"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function SelectFolderOrFile(Optional OneFile As Boolean = False, Optional UseProgFolder As Boolean = False) As String()
        Dim _dg As New OpenFileDialog
        Static _path As String
        If _path Is Nothing OrElse _path = "" Then
            _path = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        End If
        With _dg
            .InitialDirectory = _path

            .Filter = clsIDcontent.GetSystemFilterStringByExtentionsByContentType(clsIDcontent.emContentType.image)
            .Title = "Выбор фото для добавления в базу"
            .CheckFileExists = True
        End With

        Select Case OneFile
            Case True
                _dg.Multiselect = False

                Select Case _dg.ShowDialog
                    Case Windows.Forms.DialogResult.OK, Windows.Forms.DialogResult.Yes
                        _path = IO.Path.GetFullPath(_dg.FileName)
                        Return New String() {_dg.FileName}
                    Case Else
                        Return New String() {}
                End Select
            Case False

                If UseProgFolder Then
                    'проверить наличие папки в ОБРАБОТАННЫЕ
                    Dim _folder As String = IO.Path.Combine(clsApplicationTypes.PhotoManagerStarUpFolder, Me.oSampleNumber.ShotCode)

                    If IO.Directory.Exists(_folder) Then
                        'все файлы в папке
                        Dim _out As New List(Of String)
                        For Each i In clsIDcontent.GetExtentionListByContentType(clsIDcontent.emContentType.image)
                            _out.AddRange(IO.Directory.EnumerateFiles(_folder, "*." & i))
                        Next
                        Return _out.ToArray
                    End If
                End If

                'открыть диалог выбора файлов
                _dg.Multiselect = True
                Select Case _dg.ShowDialog
                    Case Windows.Forms.DialogResult.OK, Windows.Forms.DialogResult.Yes
                        _path = IO.Path.GetFullPath(_dg.FileName)
                        Return _dg.FileNames
                    Case Else
                        Return New String() {}
                End Select

        End Select

        Return New String() {}


    End Function

    Private Sub BindingNavigatorAddNewItem_Click(sender As Object, e As EventArgs) Handles BindingNavigatorAddNewItem.Click
        Me.CopyFilesToSource(Me.SelectFolderOrFile(False, True))
        ''выбрать или создать устройство из папки
        'Dim _path = Me.SelectFolderOrFile(True, True)

        'If _path.Length = 0 OrElse IO.Directory.Exists(_path.FirstOrDefault) = False Then
        '    MsgBox("Папка с номером " & Me.oSampleNumber.ShotCode & " не существует в ОБРАБОТАННЫЕ! Нажали Ctl+Shift+S в Picasa??", vbCritical)
        '    Return
        'End If

        'Dim Fromsource = clsFilesSources.CreateInstance(clsFilesSources.emSources.FreeFolder, Nothing, False, _path, False)
        'Dim _photoList = clsApplicationTypes.SamplePhotoObject.GetImageNamesList(oSampleNumber, Fromsource)
        'Dim Tosource = oCurrentSource

        'Dim _message As String = "Копировать все фотки в  " & oCurrentSource.GetStringForUser & " из папки " & _path & " ?"
        'Dim _status As Integer

        ''задать вопрос
        'Select Case MsgBox(_message, MsgBoxStyle.YesNo)
        '    Case MsgBoxResult.Yes
        '        'копировать
        '        _status = clsApplicationTypes.SamplePhotoObject.CopyImagesFromSourceToSource(SampleNumber:=Me.oSampleNumber, FromSource:=Fromsource, ToSource:=Tosource, DeleteSourceFlag:=False, FileNamesFilter:=Nothing, OptimizeImageWight:=1600, includeSmallContainer:=True)
        '    Case MsgBoxResult.No
        '        Return
        'End Select
        'Select Case _status
        '    Case Is > 0
        '        clsApplicationTypes.BeepYES()
        '        ''обновить список
        '        Me.LoadImagesToPanel()
        '        RaiseEvent PhotosAdded(Me, New PhotoEventArgs With {.ImageNamesList = _photoList})
        '        RaiseEvent PhotoListChanged(Me, EventArgs.Empty)
        '    Case 0
        '        MsgBox("Из " & _path & " - файлы НЕ скопированы! Уже есть в " & oCurrentSource.GetStringForUser, vbCritical)
        '    Case -1
        '        MsgBox("Из " & _path & " - файлы НЕ скопированы! Ошибка при копировании файлов.", vbCritical)
        'End Select
    End Sub

    Private Sub BindingNavigatorDeleteItem_Click(sender As Object, e As EventArgs) Handles BindingNavigatorDeleteItem.Click
        Dim _obj = bs_images.Current
        If _obj Is Nothing Then clsApplicationTypes.BeepNOT() : Return

        Dim _item = CType(_obj, clsLayerManager)
        Dim _imageName = _item.ImageName
        If _imageName = "" Then clsApplicationTypes.BeepNOT() : Return
        'удалить изображения, список имен в аргументе
        Select Case MsgBox("Удалить фото " & _imageName & " из " & oCurrentSource.GetStringForUser & " ?", vbYesNo)
            Case MsgBoxResult.Yes
                Dim _count As Integer = Service.clsApplicationTypes.SamplePhotoObject.DeleteImagesFromSource(Me.oSampleNumber, oCurrentSource, {_imageName}, False, False)

                LoadImagesToPanel()
                clsApplicationTypes.BeepYES()
                RaiseEvent PhotosDeleted(Me, New PhotoEventArgs With {.ImageNamesList = {_imageName}})
                RaiseEvent PhotoListChanged(Me, EventArgs.Empty)
            Case MsgBoxResult.No
                Return
        End Select
    End Sub


#End Region

#Region "Управление кнопками и тп"


    Private Sub btClearLines_Click(sender As Object, e As EventArgs) Handles btClearLines.Click
        If Me.bs_images.Current Is Nothing Then Return
        If oLayerManagerCollection.Count = 0 Then Return
        Dim _CurrentLayerManager As clsLayerManager = Me.bs_images.Current
        _CurrentLayerManager.ClearLines()
        If _CurrentLayerManager.IsSaved = True Then
            Me.Panel1.Invalidate(oCurrentLayer.ClientRectangle)
        Else
            Me.Panel1.Invalidate()
        End If
    End Sub

    Private Sub rbLine_CheckedChanged(sender As Object, e As EventArgs) Handles rbLine.CheckedChanged
        If rbLine.Checked Then
            Me.tbTextPanel.Text = ""
        End If
    End Sub

    Private Sub cbLineColor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbLineColor.SelectedIndexChanged
        If Me.bs_images.Current Is Nothing Then Return
        If oLayerManagerCollection.Count = 0 Then Return
        Dim _CurrentLayerManager As clsLayerManager = Me.bs_images.Current
        If oCurrentLayer Is Nothing Then Return
        If cbLineColor.SelectedItem Is Nothing Then Return
        _CurrentLayerManager.IsSaved = False

        Dim _em As KnownColor

        Dim _res = [Enum].TryParse(Of Drawing.KnownColor)(cbLineColor.SelectedItem, _em)
        If _res Then
            oCurrentLayer.LineColor = System.Drawing.Color.FromKnownColor(_em)
        End If
        If _CurrentLayerManager.IsSaved = True Then
            Me.Panel1.Invalidate(oCurrentLayer.ClientRectangle)
        Else
            Me.Panel1.Invalidate()
        End If
    End Sub

    Private Sub rbText_CheckedChanged(sender As Object, e As EventArgs) Handles rbText.CheckedChanged
        If rbText.Checked Then
            Me.tbTextPanel.Text = ""
        End If
    End Sub

    Private Sub nudFontSize_ValueChanged(sender As Object, e As EventArgs) Handles nudFontSize.ValueChanged
        If oCurrentLayer Is Nothing Then Return
        Me.oCurrentLayer.FontSize = nudFontSize.Value

        'это для ловли кручения колесика
        Panel1.Focus()
        Me.Panel1.Invalidate(Me.oCurrentLayer.ClientRectangle, False)
    End Sub

    ''' <summary>
    ''' обновление фото
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btRefreshLayer_Click(sender As Object, e As EventArgs) Handles btRefreshLayer.Click
        If Me.bs_images.Current Is Nothing Then Return
        If oLayerManagerCollection.Count = 0 Then Return

        Dim _CurrentLayerManager As clsLayerManager = Me.bs_images.Current
        _CurrentLayerManager.IsSaved = False
        _CurrentLayerManager.Clear()
        _CurrentLayerManager.ClearLines()
        Me.oIdCount = 0
        Me.Panel1.Invalidate()
        'RaiseEvent PhotoListChanged(Me, EventArgs.Empty)
    End Sub


    ''' <summary>
    ''' сохранить изображение
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btSaveMaps_Click(sender As Object, e As EventArgs) Handles btSaveMaps.Click
        If Me.bs_images.Current Is Nothing Then Return
        If oLayerManagerCollection.Count = 0 Then Return
        Dim _CurrentLayerManager As clsLayerManager = Me.bs_images.Current

        Dim _image = _CurrentLayerManager.GetToSourceImage

        If _CurrentLayerManager.ImageName Is Nothing Then
            'нет у фотки имени
            clsApplicationTypes.BeepNOT()
            Return
        ElseIf _CurrentLayerManager.Count = 0 Then
            clsApplicationTypes.BeepNOT()
            Return
        End If
        If _image Is Nothing Then Return

        '-----
        Dim _originalName = _CurrentLayerManager.ImageName
        Dim _name = IO.Path.GetFileNameWithoutExtension(_originalName) & "_m" & IO.Path.GetExtension(_originalName)

        Dim _index As Integer = 0
        Do While clsApplicationTypes.SamplePhotoObject.ContainsImage(oCurrentSource, oSampleNumber, _name, False)
            'уже есть такой файл
            _name = IO.Path.GetFileNameWithoutExtension(_originalName) & "_m" & _index & IO.Path.GetExtension(_originalName)
            _index += 1
        Loop

        Dim _cont = clsIDcontent.CreateInstance(oSampleNumber.EAN13, _name, clsIDcontent.emContentType.image, False)

        Dim _res = clsApplicationTypes.SamplePhotoObject.WriteFileToContainer(oCurrentSource, _cont, _image)
        If _res > 0 Then
            _CurrentLayerManager.IsSaved = True
            Me.Panel1.Invalidate()
            clsApplicationTypes.BeepYES()
            Me.LoadImagesToPanel()
            RaiseEvent PhotosAdded(Me, New PhotoEventArgs With {.ImageNamesList = {_name}})
            RaiseEvent PhotoListChanged(Me, EventArgs.Empty)
        End If
    End Sub

    ''' <summary>
    ''' изменение метки
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tbTextPanel_TextChanged(sender As Object, e As EventArgs) Handles tbTextPanel.TextChanged
        If oCurrentLayer Is Nothing Then Return
        Me.oCurrentLayer.IDText = tbTextPanel.Text
        Panel1.Invalidate()
    End Sub

    Private Sub btMainImage_Click(sender As Object, e As EventArgs) Handles btMainImage.Click
        Dim _curr As clsLayerManager = Me.bs_images.Current
        If _curr Is Nothing Then Return
        'задать главное фото
        'записать на устройство
        If Not clsApplicationTypes.SamplePhotoObject.CreateMainImageOnSource(Me.oSampleNumber, _curr.ImageName, oCurrentSource) Then
            clsApplicationTypes.BeepNOT()
            Return
        Else
            'обновить вывод
            RaiseEvent PhotoListChanged(Me, EventArgs.Empty)
            clsApplicationTypes.BeepYES()
        End If
    End Sub

#End Region

#Region "FTP"


    ''' <summary>
    ''' копирование на ftp
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ToolStripButtonUploadToFtp_Click(sender As Object, e As EventArgs) Handles ToolStripButtonUploadToFtp.Click
        If ToolStripComboBoxFtp.SelectedItem Is Nothing Then
            MsgBox("Выберете ftp соединение для загрузки", vbCritical)
            Return
        End If

        Dim _toSource As clsFilesSources
        Select Case CType(ToolStripComboBoxFtp.SelectedItem, Service.clsFilesSources.emSources)
            Case clsFilesSources.emSources.FtpInfoTrilbone
                _toSource = clsFilesSources.FTPinfoTRILBONE
            Case Else
                Debug.Fail("Для элемента перечисления действие не задано")
                Return
        End Select

        If oBackgroundWorkerMC.IsBusy Then
            MsgBox("Необходимо дождаться завершения запущенной операции!", vbCritical)
            Return
        End If

        Dim _fromSource = oCurrentSource

        'проверка размера фоток
        For Each t In clsApplicationTypes.SamplePhotoObject.GetImageCollection(oSampleNumber, _fromSource, False)
            If t.Size.Width < 600 Then
                MsgBox(String.Format("Размер фото {0} меньше допустимого для загрузки в сеть (600пикс минимум)! Проверте размер фоток в папке образца {1} в GoogleDrive, исправте и повторите попытку!", t.Tag, oSampleNumber.ShotCode))
                Return
            End If
        Next

        Dim _copySub = Function() As Integer
                           Return clsApplicationTypes.SamplePhotoObject.CopyImagesFromSourceToSource(oSampleNumber, _fromSource, _toSource, False, Nothing, 1600, True)
                       End Function

        oBackgroundWorkerMC.RunWorkerAsync(_copySub)
        Me.ToolStripLabel1.Text = "копируем.."
        clsApplicationTypes.BeepYES()
    End Sub

    ''' <summary>
    ''' удаление с ftp
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tsbDeleteFtp_Click(sender As Object, e As EventArgs) Handles tsbDeleteFtp.Click
        If ToolStripComboBoxFtp.SelectedItem Is Nothing Then
            MsgBox("Выберете ftp соединение для удаления!", vbCritical)
            Return
        End If

        Dim _destSource As clsFilesSources
        Select Case CType(ToolStripComboBoxFtp.SelectedItem, Service.clsFilesSources.emSources)
            Case clsFilesSources.emSources.FtpInfoTrilbone
                _destSource = clsFilesSources.FTPinfoTRILBONE
            Case Else
                Debug.Fail("Для элемента перечисления действие не задано")
                Return
        End Select


        Select Case MsgBox(String.Format("Удалить все фото {0} с  {1}", oSampleNumber.ShotCode, _destSource.GetStringForUser), vbYesNo)
            Case MsgBoxResult.No
                Return
        End Select
        Me.ToolStripLabel1.Text = "удаляем.."
        Application.DoEvents()
        Dim _out = clsApplicationTypes.SamplePhotoObject.DeleteImagesFromSource(SampleNumber:=oSampleNumber, FileSource:=_destSource, DeleteAllImageFiles:=True, DeleteFolder:=True, FileNamesFilter:=Nothing)

    


        If _out > 0 Then
            clsApplicationTypes.BeepYES()
            Me.ToolStripLabel1.Text = ""
        Else
            MsgBox("Не удалось удалить файлы!", vbCritical)
        End If

    End Sub

    Private WithEvents oBackgroundWorkerMC As New System.ComponentModel.BackgroundWorker

    Private Sub oBackgroundWorkerMC_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles oBackgroundWorkerMC.DoWork
        Dim _answermsg As String = ""
        ' Get the BackgroundWorker object that raised this event.
        Dim worker As BackgroundWorker = _
            CType(sender, BackgroundWorker)

        e.Result = e.Argument.Invoke()
    End Sub


    Private Sub oBackgroundWorkerMC_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles oBackgroundWorkerMC.RunWorkerCompleted
        ' First, handle the case where an exception was thrown.
        Me.ToolStripLabel1.Text = ""
        If (e.Error IsNot Nothing) Then
            MessageBox.Show("Ошибка асинхронной операции: " & e.Error.Message)
            ' Me.ToolStripStatusLabel1.Text = ""
        ElseIf e.Cancelled Then
            ' Next, handle the case where the user canceled the 
            ' operation.
            ' Note that due to a race condition in 
            ' the DoWork event handler, the Cancelled
            ' flag may not have been set, even though
            ' CancelAsync was called.
            MsgBox("Операция прервана пользователем", vbInformation)
            ' Me.ToolStripStatusLabel1.Text = ""
        Else
            ' Finally, handle the case where the operation succeeded.
            'отобразим результат операции
            Dim _result As Integer = e.Result
            ' Me.ToolStripStatusLabel1.Text = e.Result.ToString()

            If _result > 0 Then
                MsgBox(String.Format("Скопировано {0} файлов", _result), vbInformation)
            ElseIf _result = 0 Then
                MsgBox("Скопировано 0 файлов. Файлы уже есть на ftp?", vbInformation)
                'If Not clsApplicationTypes.SamplePhotoObject.HasImages(oSampleNumber, _toSource) Then
                '    MsgBox("Файлы НЕ скопированы! Ошибка!", vbCritical)
                'Else
                '    MsgBox("Файлы уже есть на FTP", vbInformation)
                'End If
            Else
                MsgBox("Файлы НЕ скопированы! Ошибка сети.", vbCritical)
            End If
            'Me.cbxAddIfExists.Checked = False
            'Me.lbSkladWarning.Text = "Проверь кол-во запросом"
        End If
    End Sub

    Private Sub ToolStripButtonOpenFolder_Click(sender As Object, e As EventArgs) Handles ToolStripButtonOpenFolder.Click
        Dim _path = oSampleNumber.GetContainerPath(clsFilesSources.Arhive)
        If String.IsNullOrEmpty(_path) Then Return
        System.Diagnostics.Process.Start(_path)
    End Sub
#End Region




End Class
