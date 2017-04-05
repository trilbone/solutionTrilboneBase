Imports System.Drawing
Imports System.Xml.Serialization
Imports System.Linq
'Imports System.Data.Linq
'Imports System.Data.Linq.Mapping
Imports System.Xml.Linq
Imports System.Data.Objects
Imports System.Globalization
Imports System.Drawing.Printing
Imports System.Text.RegularExpressions
Imports System.Runtime.Remoting.Messaging
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Net
Imports Service

Partial Public Class clsApplicationTypes
    ' Private Shared oActiveUser As emUsers = 3
    Private Shared oCurrencyRateNow As Generic.Dictionary(Of emCurrencyList, Decimal)
    Private Shared WithEvents oSamplePhotoManager As clsSamplePhotoManager
    '///////////////////////
    'регистрация сервиса
    'в конструкторе сервисного класса соотв. проэкта
    ''привязываем делегат к функции
    'Dim _dg As New [Service_name]DelegateFunction(AddressOf [service_provider_function])
    ''сохраняем делегат (регистрируем) в сервисном классе
    'Global.Service.clsApplicationTypes.DelegatStore[Service_name] = _dg

    '(короткая форма)
    'Global.Service.clsApplicationTypes.DelegatStore[Service_name] = _
    ' New [Service_name]DelegateFunction(AddressOf [service_provider_function])

    '//////////////////////


    '///////////////////////
    ''использование сервисов
    ''выполняем вызов из сервиса
    '' dim _param as object={[parameters_list]}
    ''если делегата нет, то сервис недоступен
    'If Not Global.Service.clsApplicationTypes.DelegatStore[Service_name] Is Nothing Then
    ''сервис зарегестрирован - вызываем 
    'Return Global.Service.clsApplicationTypes.DelegatStore[Service_name].Invoke(_param)
    'Else
    'Return Nothing
    'End If
    '///////////////////////

    '////////////////////////
    'при публикации сервиса его надо запустить в ModuleMain.vb
    'инициализуем экземпляр сервисного класса
    'Dim _excelConnService As ConnectExcel.ExcelService
    ' и запускаем его
    '_excelConnService = New ConnectExcel.ExcelService
    'в конструкторе каждого сервисного класса должны быть определены методы привязки сервисов         'к соответствующим делегатам класса Service.clsApplicationTypes
    '===========sample======  
    '   Public Sub New()
    '       'регистрируем предоставляемые сервисы (смотри выше***)
    '       '1. сервис формы fmExcelConnect
    '       'привязываем делегат к функции
    '       'передаем делегат (регистрируем) и список в сервисном классе
    '       Global.Service.clsApplicationTypes.DelegateStoreApplicationForm(emFormsList.fmExcelConnection) = _
    'New ApplicationFormDelegateFunction(AddressOf GetGetfmExcelConnect_asForm)
    '   End Sub

    Public Shared ReadOnly cntDbImageSize As Drawing.Size = New Drawing.Size(228, 171)
    Shared oSiteExternalObject As Object
    Shared oRFIDmanager As clsRfidManager

    ''' <summary>
    ''' картинка отсутствия фото
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared ReadOnly Property NoImage As Image
        Get
            Dim _img = My.Resources.Resource.noimage
            _img.Tag = "noimage"
            Return _img
        End Get
    End Property


    ''' <summary>
    ''' пауза запросов МС
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared ReadOnly Property MCpause As Integer
        Get
            If CurrentUser Is Nothing Then Return 0
            Return CurrentUser.MCpause
        End Get
    End Property

    ''' <summary>
    ''' получить и конвертировать фото для узла
    ''' </summary>
    Public Shared Function GetResizedImageForTree(ByVal ImageFileFullPath As String, Optional original As Boolean = False) As Image
        Debug.Assert(ImageFileFullPath.Length > 0)
        'get image
        If Not IO.File.Exists(ImageFileFullPath) Then Return Nothing
        Try
            Using _img = Image.FromFile(ImageFileFullPath, True)
                Dim _x = _img.Width
                Dim _y = _img.Height
                Dim _x1 As Integer = 0
                Dim _y1 As Integer
                If original Then
                    Return _img.Clone
                Else
                    _y1 = cntDbImageSize.Height
                    Dim _prop = (_y / _y1)
                    _x1 = Math.Round(_x / _prop)
                    Return New Bitmap(_img.Clone, New Drawing.Size(_x1, _y1))
                End If
            End Using
        Catch ex As Exception
            Return Nothing
        End Try

        'Return _trb

    End Function

#Region "LabelDraw"
    ' ''' <summary>
    ' ''' создает этикетку из изображения. принимает в tag .eanlbl (путь).ai (путь).pdf    ''' </summary>
    ' ''' <param name="labelimage"></param>
    ' ''' <returns></returns>
    ' ''' <remarks></remarks>
    'Public Shared Function CreatePrintableLabel(labelimage As Image) As KeyValuePair(Of Image, SizeF)
    '    If labelimage Is Nothing Then Return New KeyValuePair(Of Image, SizeF)(New Bitmap(50, 50), New SizeF(50, 50))
    '    'а тут надо обработать фотки))
    '    ' преобразовывает размеры в мм!!
    '    Dim _size As SizeF = Nothing
    '    Dim _result As New KeyValuePair(Of Image, SizeF)

    '    If labelimage.Tag Is Nothing Then
    '        'так печатать внутренние фото, может изменить разрешение?
    '        Dim x = labelimage.Width / labelimage.HorizontalResolution * 25.4
    '        Dim y = labelimage.Height / labelimage.VerticalResolution * 25.4
    '        _size = New SizeF(x, y)
    '        Dim _img = labelimage
    '        _result = New KeyValuePair(Of Image, SizeF)(_img, _size)
    '    Else
    '        'получить полноразмерные фото - с папки данных
    '        Select Case IO.Path.GetExtension(labelimage.Tag)
    '            Case ".ai", ".pdf"
    '                'через парсер иллюстратора
    '                Dim _img = clsApplicationTypes.GetPdfImageFromAIFile(labelimage.Tag, 300, 1, _size)
    '                'привести 0,1мм в 1,0мм
    '                _size = New SizeF(_size.Width / 10, _size.Height / 10)
    '                _result = New KeyValuePair(Of Image, SizeF)(_img, _size)
    '            Case ".eanlbl"
    '                If Not labelimage Is Nothing Then
    '                    'размер этикеток - задать в мм 
    '                    'Dim x =25
    '                    'Dim y = 18
    '                    _size = New SizeF(25, 18)
    '                    _result = New KeyValuePair(Of Image, SizeF)(labelimage, _size)
    '                End If

    '            Case Else
    '                'через парсер стандартного изображения
    '                Dim x = labelimage.Width / labelimage.HorizontalResolution * 25.4
    '                Dim y = labelimage.Height / labelimage.VerticalResolution * 25.4
    '                _size = New SizeF(x, y)
    '                Dim _img = GetResizedImageForTree(labelimage.Tag, True)
    '                If _img Is Nothing Then Return _result
    '                _result = New KeyValuePair(Of Image, SizeF)(_img, _size)
    '        End Select
    '    End If
    '    Return _result
    'End Function

    ''' <summary>
    ''' найдет все фотки в папке FolderPath при указании OriginalSize можно вернуть полноразмерное фото
    ''' </summary>
    ''' <param name="FolderPath"></param>
    ''' <param name="OriginalSize"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetImagesFromFolder(ByVal FolderPath As String, Optional ByVal OriginalSize As Boolean = False, Optional cap As Boolean = False) As List(Of Image)
        Dim _out As New List(Of Image)
        Dim _files As New List(Of String)

        Dim _fl = IO.Directory.GetFiles(FolderPath, "*.jpg")
        _files.AddRange(_fl)

        _fl = IO.Directory.GetFiles(FolderPath, "*.jpeg")
        _files.AddRange(_fl)

        _fl = IO.Directory.GetFiles(FolderPath, "*.png")
        _files.AddRange(_fl)

        _fl = IO.Directory.GetFiles(FolderPath, "*.tiff")
        _files.AddRange(_fl)

        _fl = IO.Directory.GetFiles(FolderPath, "*.gif")
        _files.AddRange(_fl)

        _fl = IO.Directory.GetFiles(FolderPath, "*.bmp")
        _files.AddRange(_fl)

        _fl = IO.Directory.GetFiles(FolderPath, "*.tif")
        _files.AddRange(_fl)

        Dim _image As Image
        For Each t In _files
            If cap Then
                'вставим заглушку
                _image = New Bitmap(100, 100)
                _image.Tag = t
            Else
                _image = clsApplicationTypes.GetResizedImageForTree(t, OriginalSize)
                _image.Tag = t
            End If
            _out.Add(_image)
        Next
        Return _out
    End Function



    ''' <summary>
    ''' построитель стд этикетки из строки. Строки разделены переводом, внутристрочный разделитель - задан InLineSplitter
    ''' labelWidthInMM - ширина этикетки в мм
    ''' spaceInMM - зазор между строками в мм
    ''' fontname - системное имя шрифта, при его изменении потребуется изменения koeff
    ''' koeff - коэффициент сжатия строк (для уменьшения высоты этикетки)
    ''' </summary>
    ''' <param name="text"></param>
    ''' <param name="labelWidthInMM"></param>
    ''' <param name="spaceInMM"></param>
    ''' <param name="fontname"></param>
    ''' <param name="InLineSplitter"></param>
    ''' <param name="dpi"></param>
    ''' <param name="koeff"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetLabelImgByText(text As String, labelWidthInMM As Integer, spaceInMM As Integer, Optional fontname As String = "Times New Roman", Optional InLineSplitter As String = ",", Optional dpi As Integer = 300, Optional koeff As Single = 0.15) As Image
        'этикетка 60 (2,3622)* 30 (1,1811) мм, 300dpi
        If text = "" Then Return Nothing

        Dim _labelWidthInMM = labelWidthInMM
        Dim _spaceInMM As Integer = spaceInMM
        Dim _fontname = fontname
        'Dim _mk As Single = koeff
        Dim _splitter = InLineSplitter
        '----------------------
        Dim _dpi = 300

        Dim _size As New SizeF(_labelWidthInMM / 25.4 * _dpi, _labelWidthInMM / 2 / 25.4 * _dpi)
        Dim _img As New Bitmap(_size.Width, _size.Height, Imaging.PixelFormat.Format16bppRgb555)
        _img.SetResolution(_dpi, _dpi)
        Dim _minimumFont As Single
        Dim _fulldata As New List(Of String)
        Dim _fonts As New List(Of Single)


        Using _gr As Graphics = Graphics.FromImage(_img)
            _gr.FillRectangle(Brushes.White, _gr.ClipBounds)
            'рисуем строку
            'разбить на строки
            Dim _data = text.Split({ChrW(10)}, StringSplitOptions.RemoveEmptyEntries)

            For Each _d In _data

                Dim _sps = _d.Split({_splitter}, StringSplitOptions.RemoveEmptyEntries)

                Select Case _sps.Count
                    Case Is > 2
                        Dim _rs As String = _sps(0).Trim
                        Dim _i As Integer = 1
                        Do While _gr.MeasureString(_rs, New Font(_fontname, 11)).Width < _size.Width And _i < _sps.Count - 1
                            _rs = _rs + ", " + _sps(_i).Trim
                            _i += 1
                        Loop
                        _fulldata.Add(_rs)
                        For i = _i To _sps.Count - 1
                            _fulldata.Add(_sps(i))
                        Next
                    Case Is = 2
                        'проверить длину строки на 10 шрифте, если не влазить, то разбить по разделителям
                        If _gr.MeasureString(_d, New Font(_fontname, 10)).Width > _size.Width Then
                            _fulldata.AddRange(_d.Split({_splitter}, StringSplitOptions.RemoveEmptyEntries))
                        Else
                            _fulldata.Add(_d)
                        End If
                    Case Else
                        _fulldata.Add(_d)
                End Select


            Next

            Dim _needimgHight As Single = 0
            Dim _sizelbl As SizeF
            For Each _str In _fulldata
                'измерить шрифт
                Dim _lbWight As Single = 0
                Dim _font As Single = 16
                Do
                    _sizelbl = _gr.MeasureString(_str, New Font(_fontname, _font))
                    _lbWight = _sizelbl.Width
                    _font -= 1
                Loop Until _img.Width > _lbWight
                _needimgHight += _sizelbl.Height - koeff * _sizelbl.Height
                If _fonts.Count > 0 AndAlso _font - _fonts.Min > 2 Then
                    'ограничение шрифта
                    _font = _fonts.Min + 1
                ElseIf _fonts.Count = 0 AndAlso _font > 12 Then
                    'ограничить для заголовка
                    _font = 12
                End If
                _fonts.Add(_font + 1)
            Next
            'изменить размер изображения
            _img = New Bitmap(_size.Width, _needimgHight, Imaging.PixelFormat.Format16bppRgb555)
            _img.SetResolution(300, 300)
            _minimumFont = _fonts.Min
        End Using


        'рисуем этикетку
        Using _gr As Graphics = Graphics.FromImage(_img)
            _gr.FillRectangle(Brushes.White, _gr.ClipBounds)
            Dim _lastPoint As Integer = 0
            Dim _fnt = New Font(_fontname, _minimumFont)
            Dim _i As Integer = 0
            For Each _t In _fulldata
                Dim _start = (_img.Width - _gr.MeasureString(_t, New Font(_fontname, _fonts(_i))).Width) / 2

                _gr.DrawString(_t, New Font(_fontname, _fonts(_i)), Brushes.Black, New Point(_start, _lastPoint))
                _lastPoint += (_spaceInMM / 25.4 * _dpi / 4) + _gr.MeasureString(_t, New Font(_fontname, _fonts(_i))).Height
                _i += 1
            Next
        End Using

        Return _img
    End Function

    Friend Shared Function LocalRegisterTime(iD As Integer, endWork As clsSampleDataManager.emWTimeOperation, user As clsSampleDataManager.emWTimeRecordType) As Boolean
        Throw New NotImplementedException()
    End Function

    ''' <summary>
    ''' вернет пдф фотку
    ''' </summary>
    ''' <param name="path"></param>
    ''' <param name="dpi"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetAiImageByPath(path As String, dpi As Integer) As Image
        If Not IO.File.Exists(path) Then Return Nothing
        Return clsApplicationTypes.GetPdfImageFromAIFile(path, dpi)
    End Function

    Private Class _getImage
        Private WithEvents oPdf As PDFLibNet.PDFWrapper
        Private oDpi As Double
        Private oPageNumber As Integer
        Private oPageSize As SizeF
        Private oImage As Image
        Private oFilePath As String

        Public Sub New(ByVal filepath As String, ByVal dpi As Double, ByVal pagenumber As Integer)
            oImage = Nothing
            oPageSize = New Size

            LoadWrapper()
            oDpi = dpi
            oPageNumber = pagenumber
            oFilePath = filepath
        End Sub
        Private Sub LoadWrapper()
            Try
                oPdf = New PDFLibNet.PDFWrapper
            Catch ex As Exception
                oPdf = Nothing
                oImage = My.Resources.Resource.noimage
                oPageSize = New Size(100, 100)
                ' MsgBox("Показ pdf невозможен", vbInformation)
            End Try
        End Sub

        Public ReadOnly Property Image As Image
            Get
                Return oImage
            End Get
        End Property

        ''' <summary>
        ''' размер страницы в 0,1мм
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property PageSize As SizeF
            Get
                Return oPageSize
            End Get
        End Property

        Public Sub ThreadProc()
            If oPdf Is Nothing Then Return

            oPdf.RenderDPI = oDpi
            Try
                oPdf.LoadPDF(oFilePath)
            Catch ex As Exception
                Return
            End Try

            If oPdf.Pages.Keys.Count > 0 Then
                If oPdf.Pages.Keys.Count >= oPageNumber Then
                    Using page = oPdf.Pages(oPageNumber)
                        'размер страницы в 0,1мм !!
                        oPageSize = New SizeF(page.Width, page.Height)

                        Using bmp As Image = page.GetBitmap(oDpi)
                            Do While (oPdf.IsJpgBusy)

                            Loop
                            Do While oPdf.IsBusy

                            Loop
                            oImage = bmp.Clone
                        End Using
                    End Using
                End If
            End If
        End Sub


    End Class


    ''' <summary>
    ''' filepath = путь к файлу, dpi - разрешение на выходе, pagenumber - номер страницы в документе// PageSize получит размер страницы в 0,1мм
    ''' </summary>
    ''' <param name="filepath"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetPdfImageFromAIFile(filepath As String, Optional dpi As Double = 96, Optional pagenumber As Integer = 1, Optional ByRef PageSize As SizeF = Nothing) As Image
        If filepath.Length = 0 Then Return Nothing
        If Not IO.File.Exists(filepath) Then Return Nothing
        Dim tws As New _getImage(filepath, dpi, pagenumber)
        Dim t As Threading.Thread
        Try
            t = New Threading.Thread(New Threading.ThreadStart(AddressOf tws.ThreadProc))
            t.Start()
            'поток запущен
            'If t.IsAlive Then

            '    t.Abort()
            '    tws = Nothing
            '    t = Nothing
            '    Return Nothing
            'End If
            t.Join()
            'поток завершен
            PageSize = tws.PageSize
            Dim _img = tws.Image.Clone
            tws = Nothing
            t = Nothing
            Return _img
        Catch ex As Exception
            tws = Nothing
            t = Nothing
            Return Nothing
        End Try


    End Function


    ''' <summary>
    ''' создает этикетку из изображения. принимает в tag .eanlbl (путь).ai (путь).pdf    ''' </summary>
    ''' <param name="labelimage"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CreatePrintableLabel(labelimage As Image) As KeyValuePair(Of Image, SizeF)
        If labelimage Is Nothing Then Return New KeyValuePair(Of Image, SizeF)(New Bitmap(50, 50), New SizeF(50, 50))
        'а тут надо обработать фотки))
        ' преобразовывает размеры в мм!!
        Dim _size As SizeF = Nothing
        Dim _result As New KeyValuePair(Of Image, SizeF)

        If labelimage.Tag Is Nothing Then
            'так печатать внутренние фото, может изменить разрешение?
            Dim x = labelimage.Width / labelimage.HorizontalResolution * 25.4
            Dim y = labelimage.Height / labelimage.VerticalResolution * 25.4
            _size = New SizeF(x, y)
            Dim _img = labelimage
            _result = New KeyValuePair(Of Image, SizeF)(_img, _size)
        Else
            'получить полноразмерные фото - с папки данных
            Select Case IO.Path.GetExtension(labelimage.Tag)
                Case ".ai", ".pdf"
                    'через парсер иллюстратора
                    Dim _img = GetPdfImageFromAIFile(labelimage.Tag, 300, 1, _size)
                    'привести 0,1мм в 1,0мм
                    _size = New SizeF(_size.Width / 10, _size.Height / 10)
                    _result = New KeyValuePair(Of Image, SizeF)(_img, _size)
                Case ".eanlbl"
                    If Not labelimage Is Nothing Then
                        'размер этикеток - задать в мм 
                        'Dim x =25
                        'Dim y = 18
                        _size = New SizeF(25, 18)
                        _result = New KeyValuePair(Of Image, SizeF)(labelimage, _size)
                    End If

                Case Else
                    'через парсер стандартного изображения
                    Dim x = labelimage.Width / labelimage.HorizontalResolution * 25.4
                    Dim y = labelimage.Height / labelimage.VerticalResolution * 25.4
                    _size = New SizeF(x, y)
                    Dim _img = GetResizedImageForTree(labelimage.Tag, True)
                    If _img Is Nothing Then Return _result
                    _result = New KeyValuePair(Of Image, SizeF)(_img, _size)
            End Select
        End If
        Return _result
    End Function


    Public Overloads Shared Function CreateEANLabel(SampleNumber As String, SampleName As String, SamplePrice As String, Optional IsArticul As Boolean = False, Optional IsIncomingPrice As Boolean = False) As Image
        Dim _num = clsApplicationTypes.clsSampleNumber.CreateFromString(SampleNumber)
        If _num.CodeIsCorrect Then
            Return CreateEANLabel(_num, SampleName, SamplePrice, IsArticul, IsIncomingPrice)
        End If
        Return Nothing
    End Function

    ''' <summary>
    ''' прога создания этикетки
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Shared Function CreateEANLabel(SampleNumber As Service.clsApplicationTypes.clsSampleNumber, SampleName As String, SamplePrice As String, Optional IsArticul As Boolean = False, Optional IsIncomingPrice As Boolean = False) As Image
        'рисуем на копии панели
        Dim _koef = 8
        'этот параметр сжимет/растягивает этикетку по вертикали. значения 100..130
        Dim _lh = 120
        'после добавления этого параметра стали печататься этикеты маленькие при стд параметрах принтера
        Dim _sgatie = 50

        Dim _lblimg = New Bitmap(167 * _koef, _lh * _koef)
        DrawLabel(Graphics.FromImage(_lblimg), Color.White, SampleNumber, SampleName, SamplePrice, IsArticul, IsIncomingPrice, _koef)

        Dim _dx = 25 * _koef
        Dim _dy = 5 * _koef
        Dim _w = 167 * _koef - _dx - 5 * _koef

        Dim _h = _lh * _koef - _dy
        Dim _lblRect = New Rectangle(_dx, 0, _w + 2 * _koef, _h + 2 * _koef - _sgatie)

        'обрежем картинку
        Dim _outimg = New Bitmap(_w, _h)
        Dim _outRect = New Rectangle(0, 0, _w, _h)

        Dim _outgr = Graphics.FromImage(_outimg)
        _outgr.Clear(Color.White)

        _outgr.DrawImage(_lblimg, _outRect, _lblRect, GraphicsUnit.Pixel)

        _outgr.DrawRectangle(Pens.Black, _outRect)
        _outimg.Tag = ".eanlbl"
        _lblimg.Dispose()
        Return _outimg
    End Function



    ''' <summary>
    ''' _koeff = масштаб
    ''' </summary>
    ''' <param name="gr"></param>
    ''' <param name="Solidcolor"></param>
    ''' <param name="_koeff"></param>
    ''' <remarks></remarks>
    Private Shared Sub DrawLabel(ByRef gr As Graphics, Solidcolor As Color, SampleNumber As Service.clsApplicationTypes.clsSampleNumber, SampleName As String, SamplePrice As String, IsArticul As Boolean, IsIncomingPrice As Boolean, Optional _koeff As Integer = 1)
        If gr Is Nothing Then Return
        If SampleNumber Is Nothing Then Return
        gr.Clear(Solidcolor)

        'обрежем до {
        SampleName = SampleName.Split("{".ToArray, StringSplitOptions.RemoveEmptyEntries).FirstOrDefault

        Dim _eanFont = New Font("EanBwrP36xTt", 36 * _koeff)
        Dim _font = New Font("Arial", 10 * _koeff)
        If _eanFont Is Nothing Then
            gr.DrawString("шрифт не найден", _font, Brushes.Black, New Point(0, 10))
            Return
        End If
        '------------------------
        Dim _brush As New SolidBrush(Solidcolor)

        'по x
        Dim k2 = 32 * _koeff
        Dim k3 = 25 * _koeff
        Dim k6 = 80 * _koeff
        Dim k7 = 125 * _koeff
        Dim k8 = 138 * _koeff
        'по y
        Dim k1 = 10 * _koeff
        Dim k4 = 5 * _koeff
        Dim k9 = 20 * _koeff
        Dim k5 = 55 * _koeff
        'это высота печати прямоугольника названия. Надо согласовывать с размером этикетки.
        Dim k10 = 50 * _koeff
        Dim k11 = 95 * _koeff

        Dim _ptEAN13 = New PointF(0, k1)
        Dim _rtShotCodeF = New RectangleF(k2, k4, k6, k9)
        Dim _rtName = New RectangleF(k2, k5, k7, k10)
        Dim _rtMain = New RectangleF(k3, 0, k8, k11)
        Dim _shot = SampleNumber.ShotCode

        'добавляет префикс артикула к короткому номеру
        If IsArticul Then
            'артикул печатать курсивом
            _font = New Font("Georgia", 13 * _koeff, FontStyle.Italic)
        Else
            _font = New Font("Arial", 13 * _koeff)
        End If

        Dim _s = gr.MeasureString(_shot, _font)

        Dim _rtPrice = New RectangleF(k2 + _s.Width + _koeff, k4, k5, k9)
        'обводка
        ' gr.DrawRectangle(Pens.Black, Rectangle.Round(_rtMain))
        '----------ean13
        gr.DrawString(SampleNumber.EAN13p36TT, _eanFont, Brushes.Black, _ptEAN13)
        '--------shot
        gr.FillRectangle(_brush, _rtShotCodeF)

        gr.DrawString(_shot, _font, Brushes.Black, _rtShotCodeF)
        '-------name
        Dim _format = StringFormat.GenericDefault
        _format.FormatFlags = StringFormatFlags.LineLimit
        gr.FillRectangle(_brush, _rtName)

        _font = New Font("Arial", 8 * _koeff)
        gr.DrawString(SampleName, _font, Brushes.Black, _rtName, _format)
        '------- price
        If Not (SamplePrice = "" Or SamplePrice = "0") Then
            If SamplePrice.Contains("RUR") Then
                SamplePrice = SamplePrice.Replace("RUR", clsApplicationTypes.GetCurrencySymbol("RUR"))
            End If
            If SamplePrice.Contains("EUR") Then
                SamplePrice = SamplePrice.Replace("EUR", clsApplicationTypes.GetCurrencySymbol("EUR"))
            End If
            If SamplePrice.Contains("USD") Then
                SamplePrice = SamplePrice.Replace("USD", clsApplicationTypes.GetCurrencySymbol("USD"))
            End If

            gr.FillRectangle(_brush, _rtPrice)
            If IsIncomingPrice Then
                SamplePrice = "вх " & SamplePrice
            End If

            _font = New Font("Arial", 7 * _koeff)
            gr.DrawString(SamplePrice, _font, Brushes.Black, _rtPrice, _format)
        End If

        _eanFont.Dispose()
        _font.Dispose()
        _brush.Dispose()
    End Sub
#End Region

    ''' <summary>
    ''' вернет преобразованное изобр метки
    ''' </summary>
    ''' <param name="label"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ResizeLabelForClipboard(label As Image) As Image
        If label Is Nothing Then Return Nothing
        Dim _x = label.Width
        Dim _y = label.Height
        Dim _x1 As Integer = 0
        Dim _y1 As Integer
        _y1 = 300
        Dim _prop = (_y / _y1)
        _x1 = Math.Round(_x / _prop)
        Dim _rimg = New Bitmap(label, New Drawing.Size(_x1, _y1))
        _rimg.SetResolution(400, 400)
        Return _rimg
    End Function
    ''' <summary>
    ''' вернет обьект принтера по части его имени, либо откроет окно выбора принтера (при задании MustSelectPrinter - обязательно)
    ''' </summary>
    ''' <param name="DefaultPrinterNamePart"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function GetPrinterSettings(Optional MustSelectPrinter As Boolean = False, Optional DefaultPrinterNamePart As String = "") As PrinterSettings

        If DefaultPrinterNamePart = "" Then
            DefaultPrinterNamePart = My.Settings.DefaultPrinterName
        End If

        Static oCurrentPrinterSettings As PrinterSettings

        If MustSelectPrinter Then
            oCurrentPrinterSettings = Nothing
        End If

        If MustSelectPrinter = False And oCurrentPrinterSettings Is Nothing Then
            Dim _sc As PrinterSettings.StringCollection = PrinterSettings.InstalledPrinters
            For i = 0 To _sc.Count - 1
                If _sc(i).ToString.ToLower.Contains(DefaultPrinterNamePart.ToLower) Then
                    If _sc(i).ToLower.Contains("wi-fi".ToLower) Or _sc(i).ToLower.Contains("wifi".ToLower) Then
                        'предустановки для принтера по умолчанию
                        oCurrentPrinterSettings = New PrinterSettings
                        oCurrentPrinterSettings.PrinterName = _sc(i)
                        oCurrentPrinterSettings.DefaultPageSettings.Landscape = False
                        Dim _res = New PrinterResolution()
                        _res.X = 300
                        _res.Y = 300
                        ' oCurrentPrinterSettings.DefaultPageSettings.PrinterResolution = _res
                        '  oCurrentPrinterSettings.DefaultPageSettings.Landscape = False
                        'Dim _ps = New PageSettings(_prnSettings)
                        ''_ps.PaperSize.Width = 79
                        'Dim _p As New PaperSize("29mm", 79, 98)
                        '_p.RawKind = 258
                        ''_p.Width = 79
                        ''_p.Height = 98
                        '_ps.PaperSize = _p
                        '_ps.Landscape = False

                        '_documentToPrint.DefaultPageSettings.PaperSize = _p
                    End If
                End If
            Next
        End If

        If oCurrentPrinterSettings Is Nothing OrElse oCurrentPrinterSettings.IsValid = False OrElse (Not oCurrentPrinterSettings.PrinterName.ToLower.Contains(DefaultPrinterNamePart.ToLower)) Then
            Dim _pd As New PrintDialog
            _pd.UseEXDialog = True

            Select Case _pd.ShowDialog()
                Case Windows.Forms.DialogResult.OK
                    oCurrentPrinterSettings = _pd.PrinterSettings
                Case DialogResult.No, DialogResult.Cancel
                    Return Nothing
            End Select
        End If

        Return oCurrentPrinterSettings

    End Function


    ''' <summary>
    ''' формирует документ на печать из списка этикеток
    ''' </summary>
    ''' <param name="prnSettings"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function PrintLabel(LabelList As List(Of KeyValuePair(Of Image, SizeF)), Optional MustSelectPrinter As Boolean = False, Optional ByRef ZoomToPage As Boolean = False) As Printing.PrintDocument
        Dim _prnSettings As PrinterSettings = GetPrinterSettings(MustSelectPrinter)
        If _prnSettings Is Nothing Then Return Nothing

        Dim _unit = GraphicsUnit.Millimeter
        Dim _documentToPrint As New Printing.PrintDocument
        Dim _LabelPages As New List(Of clsPage)

        'настройка печати
        _documentToPrint.DocumentName = "Этикетки"
        _documentToPrint.PrinterSettings = _prnSettings
        'границы принтера по 2,54мм
        _documentToPrint.PrinterSettings.DefaultPageSettings.Margins = New Margins(10, 10, 10, 10)
        '------------источник бумаги
        Dim _smsg As String = "Выберете источник бумаги: " + ChrW(13)

        For i = 0 To _documentToPrint.PrinterSettings.PaperSources.Count - 1
            _smsg += i.ToString & ". " & _documentToPrint.PrinterSettings.PaperSources(i).SourceName & " ;" & ChrW(13)
        Next

        If _documentToPrint.PrinterSettings.PaperSources.Count > 1 Then
            Dim _result As Decimal
            If Not Decimal.TryParse(InputBox(_smsg, "Выбор источника бумаги: ", "1"), _result) Then
                _result = 1
            End If
            If _result = 0 Then _result = 1
            _documentToPrint.PrinterSettings.DefaultPageSettings.PaperSource = _documentToPrint.PrinterSettings.PaperSources(_result - 1)
        End If
        '-------------

        '------------------------
        'зададим границы панели класса clsPage, где будем рисовать вывод
        'это физический размер страницы
        Dim _printbounds As System.Drawing.Graphics

        Try
            _printbounds = _documentToPrint.PrinterSettings.CreateMeasurementGraphics
        Catch ex As Exception
            MsgBox("Ошибка принтера, проверте настройки", vbCritical)
            Return Nothing
        End Try
        _printbounds.PageUnit = _unit
        '-----------------------
        Dim _PaperRectangle = _printbounds.VisibleClipBounds

        ' Dim _ps = _documentToPrint.PrinterSettings.DefaultPageSettings.PaperSize
        ' _PaperRectangle = New RectangleF(0, 0, _ps.Width * 0.254, 79 * 0.254)
        ' Dim _psize = _documentToPrint.PrinterSettings.DefaultPageSettings.Bounds.Size
        'это драйвер говорит о возможной области печати на странице
        'Dim _drvSize = _documentToPrint.PrinterSettings.DefaultPageSettings.PrintableArea.Size
        'зададим наши поля 1мм=3,9 сотых дюйма (еденицы измерения)
        'давай 2 мм = 8ед
        'Dim _pk = 0
        '_psize = New Size(_psize.Width - 8, _psize.Height - 8 - _pk)



        'теперь класс размещения этикеток
        Dim _page = New clsPage(_PaperRectangle)
        _LabelPages.Add(_page)

        'По запросу растянем этикетки до целой страницы
        Dim _newstr As New List(Of KeyValuePair(Of Image, SizeF))
        Dim _size As SizeF
        For Each _str In LabelList
            _size = _str.Value
            If ZoomToPage = True Then
                'дополнительные поля печати
                Dim _mmoffset As Decimal = 0
                'задать размер этикетки в соответствии с размером страницы
                _size = New SizeF((_PaperRectangle.Width - _mmoffset) / 3.9, (_PaperRectangle.Height - _mmoffset) / 3.9)
            End If
            _newstr.Add(New KeyValuePair(Of Image, SizeF)(_str.Key, _size))
        Next

        LabelList = _newstr

        'тут формируем обьект для печати
        For Each _str In LabelList

            'добавить в существующий незаполненный
            Dim _result = (From c In _LabelPages Where c.IsFull = False Select c).FirstOrDefault

            If _result Is Nothing Then
                'все полны
                'создать новую страницу
                'GoTo cr
                _page = New clsPage(_PaperRectangle)
                _LabelPages.Add(_page)
                _page.AddLabel(_str)
            Else
                'пробуем
                If _result.AddLabel(_str) = False Then
                    'не влазит
                    'создать новую страницу
                    'GoTo cr
                    _page = New clsPage(_PaperRectangle)
                    _LabelPages.Add(_page)
                    _page.AddLabel(_str)
                End If
            End If
        Next

        Dim _index As Integer = 0

        AddHandler _documentToPrint.PrintPage, Sub(senderv As Object, ev As PrintPageEventArgs)

                                                   Dim _pagecount = _LabelPages.Count
                                                   If _pagecount = 0 Then Exit Sub

                                                   'print page
                                                   _LabelPages(_index).DrawLabels(ev.Graphics, _unit)
                                                   _index += 1
                                                   If (_index + 1) > _pagecount Then ev.HasMorePages = False : _index = 0 : Exit Sub

                                                   ev.HasMorePages = True
                                               End Sub

        Return _documentToPrint
    End Function


    '===========================

    '/////////////////////////
    Public Class fmImageDelEventArg
        Inherits EventArgs
        ''' <summary>
        ''' коллекция имен файлов для удаления
        ''' </summary>
        ''' <remarks></remarks>
        Public ImageNames As Collections.Specialized.StringCollection

    End Class
    Public Class fmImageCopyEventArg
        Inherits EventArgs
        ''' <summary>
        ''' коллекция полных имен файлов для копирования
        ''' </summary>
        ''' <remarks></remarks>
        Public ImageNames() As String
        Public ImagesPath As String
    End Class
    Shared oSampleDataManager As clsSampleDataManager
    'Shared oTreeService As Trilbone.clsTreeService


    Public Delegate Sub fmImageDeleteDelegat(ByVal sender As Object, ByVal e As Service.clsApplicationTypes.fmImageDelEventArg)
    Public Delegate Sub fmImageCopyDelegat(ByVal sender As Object, ByVal e As Service.clsApplicationTypes.fmImageCopyEventArg)

    Public Shared Property DelegatStorefmImageDeleteDelegate As fmImageDeleteDelegat
    Public Shared Property DelegatStorefmImageCopyDelegate As fmImageCopyDelegat

    ''' <summary>
    ''' описывает рассылку 
    ''' </summary>
    ''' <remarks></remarks>
    Public Class clsMailListItem
        Property SKU As clsApplicationTypes.clsSampleNumber
        Property client As iMoySkladDataProvider.clsClientInfo
        Property Price As Decimal
        Property Currency As String
    End Class


    Public Shared ReadOnly Property SendersMailList As clsMail()
        Get
            Dim _new = New List(Of clsMail)
            _new.Add(New clsApplicationTypes.clsMail With {.Mail = "paleotravel@gmail.com", .Password = "acidaspis7"})
            _new.Add(New clsApplicationTypes.clsMail With {.Mail = "fossilcollecting@gmail.com", .Password = "illaenus2009"})
            _new.Add(New clsApplicationTypes.clsMail With {.Mail = "nordstarservice@gmail.com", .Password = "smith1820"})
            _new.Add(New clsApplicationTypes.clsMail With {.Mail = "trilbone@mail.ru", .Password = "63617579illaenus"})
            _new.Add(New clsApplicationTypes.clsMail With {.Mail = "eugeny.litvinov@mail.ru", .Password = "illaenus2009"})
            Return _new.ToArray
        End Get
    End Property


    Public Class clsMail
        Property Mail As String
        Property Password As String
        Public Overrides Function ToString() As String
            Return Mail
        End Function
    End Class

    ''' <summary>
    ''' управляет Майл рассылкой
    ''' </summary>
    ''' <remarks></remarks>
    Public Class clsMailList
        Inherits List(Of clsMailListItem)

        Shadows Sub Add(item As clsMailListItem)
            If item.client Is Nothing Then Return
            If String.IsNullOrEmpty(item.client.Email) Then Return
            If item.SKU.CodeIsCorrect = False Then Return
            MyBase.Add(item)
        End Sub

        Dim omailserver As Service.clsEmailBase
        Dim oSendedParametrs As New List(Of Service.clsApplicationTypes.clsSendingParameter)
        Public Sub New(SendFrom As String, password As String)
            omailserver = Service.clsEmailBase.CreateInstance(SendFrom, password)
            If omailserver Is Nothing Then
                MsgBox("Проверте отправителя и пароль!!", vbCritical)
                Return
            End If
            ''привязка обработчика
            'AddHandler _mailserver.MailSend, AddressOf mailSended
        End Sub


        ''' <summary>
        ''' вставляет цену в HTML
        ''' </summary>
        ''' <remarks></remarks>
        Private Function InserPriceSKUToHTML(sku As String, price As Decimal, currency As String, HTML As String) As String
            If price = 0 Then Return HTML
            Dim _prefix As String = "Price for you:  "

            'вставка в HTML
            Dim _xe As XElement = <span style="border: 0px outset rgb(78,63,33); "><br/>
                                      <font class="alt"><%= _prefix %></font><%= Decimal.Ceiling(price).ToString & " " & currency %>
                                      <br/>
                                      <font class="alt"><%= "item no. " %></font><%= sku %>
                                      <br/>
                                  </span>
            Dim _xml = XElement.Parse(HTML)
            Dim _ins = (From c In _xml.Descendants("td") Where (Not c.Attribute("id") Is Nothing) AndAlso (c.Attribute("id").Value = "64") Select c)
            If _ins.Count > 0 Then
                _ins(0).RemoveNodes()
                _ins(0).AddFirst(_xe)
                Return _xml.ToString
            End If
            Return HTML
        End Function

        Public ReadOnly Property SendedParams As List(Of clsSendingParameter)
            Get
                Return oSendedParametrs
            End Get
        End Property


        Dim osendMailCount As Integer = 0

        ' ''' <summary>
        ' ''' формирует тело письма из добавленных в список номеров
        ' ''' </summary>
        ' ''' <param name="XSLTtemplateFileNameWithoutExtention"></param>
        ' ''' <param name="combineTemplates"></param>
        ' ''' <returns></returns>
        ' ''' <remarks></remarks>
        'Public Shared Function GetXML(Optional XSLTtemplateFileNameWithoutExtention As String = "Site_mail", Optional combineTemplates As Boolean = False) As String

        'End Function

        ''' <summary>
        ''' запускает отправку списка сообщений.Вернет кол-во удачно поставленных в очередь на отправку, -1 - ошибка
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function SendMailList(culture As System.Globalization.CultureInfo, sendAscatalog As Boolean, Optional MailCaption As String = "New offer from Trilbone", Optional XSLTtemplateFileNameWithoutExtention As String = "Site_mail") As Integer

            osendMailCount = 0

            Select Case sendAscatalog
                Case True

                    Dim _catNum As Integer = InputBox("Номер каталога сегодня", "Параметры каталога", "1")
                    Dim _catName As String = (Now.ToString("ddmmyy") & "-" & _catNum).Replace(".", "")
                    Dim _sampleList As New List(Of clsApplicationTypes.clsSampleNumber)
                    Dim _client As iMoySkladDataProvider.clsClientInfo = Nothing
                    For Each t In Me
                        _sampleList.Add(t.SKU)
                        _client = t.client
                        Dim _currency As String = t.Currency
                        Dim _price As Decimal = t.Price
                        Dim _param = New clsSendingParameter With {.SendFrom = omailserver.FromMail, .Client = _client, .Caption = MailCaption, .QualityText = "", .SendTo = _client.Email, .Currency = _currency, .Price = _price, .SampleNumber = {t.SKU}, .CatalogName = _catName}
                        oSendedParametrs.Add(_param)
                    Next

                    Dim _catalog = Catalog.CATALOG.CreateInstance(SampleList:=_sampleList, name:=_catName, title:=MailCaption, [date]:=Now.ToShortDateString, culture:=culture, folfertype:=clsApplicationTypes.emCatalogFolderType.hash, GetFromDB:=True, ShowPrices:=True, numberstring:="Use label for order: ")
                    'посмотреть результат
                    If Not _catalog Is Nothing Then
                        Dim _xml = _catalog.GetXML
                        Dim fm As New fmBrowser(_catalog.GetHTML(), _catName, MailCaption)
                        fm.ShowDialog()
                    Else
                        Return -1
                    End If

                    Select Case MsgBox("Отправить этот каталог?", vbYesNo)
                        Case vbNo
                            Return -1
                    End Select

                    Dim _paramCatalog = New clsSendingParameter With {.SendFrom = omailserver.FromMail, .Client = _client, .Caption = MailCaption, .QualityText = "", .SendTo = _client.Email, .CatalogName = _catName}

                    If Not _catalog Is Nothing Then
                        Dim _messagebody As String = _catalog.GetHTML

                        'проверки
                        If _client.Email = "" OrElse (Not _client.Email.Contains("@")) Then
                            _paramCatalog.error = "емайл получателя не правильный"
                            oSendedParametrs.Clear()
                            oSendedParametrs.Add(_paramCatalog)
                            Return osendMailCount
                        End If
                        If _messagebody = "" Then
                            _paramCatalog.error = "Текст сообщения-каталога пуст. Проблема в XSLT?"
                            oSendedParametrs.Clear()
                            oSendedParametrs.Add(_paramCatalog)
                            Return osendMailCount
                        End If

                        '---send mail---------
                        If omailserver.SendMail(_client.Email, MailCaption, _messagebody, Nothing, False, , True, _paramCatalog) Then
                            'резервация вызывается из обработчика факта отправки сообщения
                            osendMailCount += 1
                            _paramCatalog.Ok = True
                        Else
                            _paramCatalog.error = "сбой отправки сообщения: " & _catName
                        End If

                    Else
                        _paramCatalog.error = "сбой отправки сообщения, не удалсь создать каталог: " & _catName
                    End If
                    oSendedParametrs.Add(_paramCatalog)

                    'регистрация письма
                    ReserveSampleToMail(_paramCatalog)

                    Return osendMailCount
                    '=========================
                Case Else
                    'послать кучу писем
                    For Each t In Me
                        Dim _messagebody As String = ""
                        Dim _client As iMoySkladDataProvider.clsClientInfo = t.client
                        Dim _currency As String = t.Currency
                        Dim _price As Decimal = t.Price

                        Dim _param = New clsSendingParameter With {.SendFrom = omailserver.FromMail, .Client = _client, .Caption = MailCaption, .QualityText = "", .SendTo = _client.Email, .Currency = _currency, .Price = _price, .SampleNumber = {t.SKU}}

                        '--get html------------------
                        If String.IsNullOrEmpty(XSLTtemplateFileNameWithoutExtention) Then
                            'Dim _nop = clsApplicationTypes.NopInterface
                            'получить FullDescription и Shot из БД Nop???
                            _messagebody = ""
                            oSendedParametrs.Add(New clsSendingParameter With {.error = "Не реализовано получение с сайта HTML: " & t.SKU.ShotCode})
                            GoTo nx
                        Else
                            'получаем из Trilbone DB
                            Dim _result As Integer = 0
                            Dim _sdo = clsApplicationTypes.SampleDataObject.GetSampleOnSale(t.SKU, _result, CreateIfNotExist:=True)
                            If _result < 1 OrElse _sdo Is Nothing Then
                                oSendedParametrs.Add(New clsSendingParameter With {.error = "Невозможно извлечь карту образца из БД. Неудачная попытка запросить обьект с сервера.: " & t.SKU.ShotCode})
                                GoTo nx
                            End If
                            Dim _xml As String = ""

                            Select Case culture.Name
                                Case EnglishCulture.Name
                                    _xml = _sdo.SampleXMLFile
                                Case RussianCulture.Name
                                    _xml = _sdo.SampleXMLFileRU
                                    If String.IsNullOrEmpty(_xml) Then
                                        _xml = _sdo.SampleXMLFile
                                        MsgBox(String.Format("Русскоязычной карты нет в БД, в письмо будет вставлено англоязычное содержимое для {0}", t.SKU), vbInformation)
                                    End If
                                Case Else
                                    Debug.Fail("Надо добавить обработу языка")
                                    _xml = _sdo.SampleXMLFile
                            End Select

                            If Not String.IsNullOrEmpty(_xml) Then
                                'в БД есть сохраненная карта XML
                                'Dim _templateName As String = "Site_mail"
                                'получить HTML образца
                                _messagebody = clsApplicationTypes.DelegateStoreGetTransform.Invoke(_xml, emTemplateType.ByName, XSLTtemplateFileNameWithoutExtention)

                                If String.IsNullOrEmpty(_messagebody) Then
                                    oSendedParametrs.Add(New clsSendingParameter With {.error = "Ошибка при преобразовании XSLT: " & t.SKU.ShotCode & ". Шаблон " & XSLTtemplateFileNameWithoutExtention})
                                    GoTo nx
                                End If
                            Else
                                oSendedParametrs.Add(New clsSendingParameter With {.error = "Карта образца отсутствует в БД: " & t.SKU.ShotCode})
                                GoTo nx
                            End If
                        End If

                        '-------------------------------------
                        'проверки
                        If _client.Email = "" OrElse (Not _client.Email.Contains("@")) Then
                            _param.error = "емайл получателя не правильный"
                            GoTo nx
                        End If
                        If _messagebody = "" Then
                            _param.error = "Текст сообщения пуст. Проблема в XSLT?"
                            GoTo nx
                        End If

                        'вставить цену
                        _messagebody = InserPriceSKUToHTML(t.SKU.ShotCode, _price, _currency, _messagebody)
                        'TODO вставить короткое описание

                        '---send mail---------
                        If omailserver.SendMail(_client.Email, MailCaption, _messagebody, Nothing, False, , True, _param) Then
                            'резервация вызывается из обработчика факта отправки сообщения
                            osendMailCount += 1
                            _param.Ok = True
                        Else
                            _param.error = "сбой отправки сообщения: " & t.SKU.ShotCode
                        End If


nx:
                        oSendedParametrs.Add(_param)
                        'регистрация письма
                        ReserveSampleToMail(_param)
                        'задержка
                        Threading.Thread.Sleep(500)

                    Next
            End Select



            Return osendMailCount
        End Function



        Public Event MailsSended(sender As Object, e As mailsended_eventArgs)

        ''' <summary>
        ''' резервирует камень при отправке eMAiL
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub ReserveSampleToMail(sendedParam As clsSendingParameter)
            ''Пересчет валют!!! Целевая = USD
            'курс выбранной валюты к рублю
            Dim _mailRate = clsApplicationTypes.GetRateByCurrencyCB103(sendedParam.Currency)
            'курс документа резервации
            Dim _ReservedRate = clsApplicationTypes.GetRateByCurrencyCB103("USD")
            Dim _convertprice = Math.Round(sendedParam.Price * _mailRate / _ReservedRate)

            '====регистрация в Мой Склад
            Dim _resultMC = clsApplicationTypes.MoySklad(True)
            If _resultMC Is Nothing Then
                MsgBox("Сервис MC недоступен", vbCritical)
                GoTo todb
            End If

            Dim _CurrentAgent = clsApplicationTypes.AuctionAgent.AGENT.Where(Function(x) x.name = "email").FirstOrDefault

            If _CurrentAgent Is Nothing Then
                MsgBox("Не удалось загрузить агента email. Резервация в МС отменена", vbCritical)
                GoTo todb
            End If

            '''убедись, то заказ существует!!!!
            Dim _auctUUID = _CurrentAgent.GetAgentID("moysklad", "ReservCustomerOrderUUID")

            If Not _auctUUID = "" Then
                For Each sm In sendedParam.SampleNumber
                    If _resultMC.SetSampleToAction(sm, _auctUUID, _convertprice, True) Then
                        BeepYES()
                        ' MsgBox("Образец зарезервирован в соответствующем заказе", MsgBoxStyle.Information)
                    Else
                        'будет другое предупреждение
                        'MsgBox("Образец не зарезервирован в соответствующем заказе Мой Склад, ошибка при помещении в заказ.", MsgBoxStyle.Critical)
                    End If
                Next
            Else
                MsgBox("Образец не зарезервирован в соответствующем заказе, ошибка при чтении параметра из файла агента.", MsgBoxStyle.Critical)
            End If
todb:
            '===записать в мою базу
            Dim _sendFrom As String = sendedParam.SendFrom & "/" & clsApplicationTypes.CurrentUser.UserShotName
            Dim _client As Service.iMoySkladDataProvider.clsClientInfo = sendedParam.Client
            Dim _clientName = ""
            Dim _clientMoySkladCode = ""
            If Not _client Is Nothing Then
                _clientName = _client.FullName
                _clientMoySkladCode = _client.MSCode
            End If

            'записвывает сумму и стоимость отправки письма))
            For Each sm In sendedParam.SampleNumber
                Dim _result = clsApplicationTypes.SampleDataObject.RegisterSampleToMailOffer(SampleNumber:=sm, SendFromMail:=_sendFrom, clientEmail:=sendedParam.SendTo, clientName:=_clientName, clientMoySkladCode:=_clientMoySkladCode, mailtitle:=sendedParam.Caption, itemcondition:=sendedParam.QualityText, itemamount:=sendedParam.Price, InsectionFee:=My.Settings.MailInsectionFee, currency:=sendedParam.Currency)
                If Not _result Then
                    MsgBox(String.Format("Образец {0} не зарезервирован в БД, ошибка при помещении в БД.", sm.ShotCode), MsgBoxStyle.Critical)
                Else
                    BeepYES()
                End If
            Next
        End Sub


        Public Class mailsended_eventArgs
            Inherits EventArgs

            ''' <summary>
            ''' параметры отправки
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Property Param As List(Of clsSendingParameter)

            ''' <summary>
            ''' кол-во поставленных
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            ReadOnly Property Count As Integer
                Get
                    If Param Is Nothing Then Return 0
                    Return Param.Count
                End Get
            End Property
            ''' <summary>
            ''' кол-во завершенных
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            ReadOnly Property SuccessCount As Integer
                Get
                    If Param Is Nothing Then Return 0
                    Return Param.Where(Function(x) x.Ok).Count
                End Get
            End Property
        End Class

    End Class

    Public Class clsSendingParameter
        Property SendFrom As String
        Property Client As iMoySkladDataProvider.clsClientInfo

        Property Caption As String
        Property QualityText As String
        Property SendTo As String
        Property Currency As String
        Property Price As Decimal

        Property [error] As String

        Property SampleNumber As clsSampleNumber()

        Property Ok As Boolean

        Property CatalogName As String
    End Class


    <Serializable()>
    Public Class clsSampleNumber
        Implements IComparable
        Implements IComparer(Of clsSampleNumber)
        Implements IComparable(Of clsSampleNumber)

        ''' <summary>
        ''' путь к папке - удалить в дальнейшем
        ''' </summary>
        ''' <remarks></remarks>
        Private oFolderPath As String

        Private oCode As String
        Private oEAN13 As Decimal
        Private oNumber As Integer
        Private oSeries As String

        ''' <summary>
        ''' структура - описатель цен
        ''' </summary>
        ''' <remarks></remarks>
        Public Structure strPrices
            Property Currency As String
            Property BasePrice As Decimal
            Property Discount As Decimal
            Property PriceWithDiscount As Decimal
        End Structure

        ''' <summary>
        ''' структура - описатель товара
        ''' </summary>
        ''' <remarks></remarks>
        Public Class strGoodInfo

            Dim ogoodWareInfo As List(Of String)

            Property Updated As Date
            Property UpdatedBy As String

            Property Name As String
            Property Code As String
            Property Articul As String
            Property UUID As String
            Property Weight As Decimal
            ''' <summary>
            ''' номер товара. выберет первым Code
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            ReadOnly Property ActualNumber As String
                Get
                    If Me.Code = "" Then Return Me.Articul.Trim
                    Return Me.Code.Trim
                End Get
            End Property
            Property BuyPrice As String
            Property BuyCurrency As String
            Property RetailPrice As String
            Property RetailCurrency As String

            ReadOnly Property RetailCurrencySymbol As String
                Get
                    If String.IsNullOrEmpty(RetailCurrency) Then Return ""
                    Select Case RetailCurrency.ToLower
                        Case "rur"
                            Return "p"
                        Case "usd"
                            Return "$"
                        Case "eur"
                            Return "eur"
                        Case Else
                            Return ""
                    End Select
                End Get
            End Property
            Property eBayPrice As Decimal
            Property eBayCurrecy As String

            Property InvocePrice As String
            Property UomName As String
            Property InvoceCurrency As String
            ''' <summary>
            ''' -1 = ошибка, 0 = пустая структура, 1 и больше = ок
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Property LoadStatus As Integer

            Property goodXML As String

            Property AsPosition As iMoySkladDataProvider.clsPosition

            ''' <summary>
            ''' Function(buyPrice As Decimal, buyCurrencyName As String, salePrice As Decimal, saleCurrencyName As String, specificPrice As Decimal, specificPriceCurrencyName As String, specificPriceName As String, uomName As String, goodname As String)
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Property updateGoodDelegate As Func(Of Decimal, String, Decimal, String, Decimal, String, String, String, String, Decimal, String)
            ''' <summary>
            ''' вернет коллекцию расположений. Передать можно любой параметр.
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Property goodLocationInfo As Func(Of Service.clsApplicationTypes.clsSampleNumber.strGoodInfo, String())

            ''' <summary>
            ''' имена складов, где есть товар
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Property goodWareInfo As List(Of String)
                Get
                    If ogoodWareInfo Is Nothing AndAlso (Not goodLocationInfo Is Nothing) Then
                        ogoodWareInfo = Me.goodLocationInfo(Me).ToList
                    End If
                    If ogoodWareInfo Is Nothing Then Return New List(Of String)
                    Return ogoodWareInfo
                End Get
                Set(value As List(Of String))
                    ogoodWareInfo = value
                End Set
            End Property

            Property goodSlotInfo As List(Of String())

            Property goodToSlot As System.Func(Of String, String, String)

            Public Overrides Function ToString() As String
                Dim _out As String = ""
                If Not Me.Code = "" Then _out += Me.Code + ", "
                If Not Me.Articul = "" Then _out += "ар. " + Me.Articul + ", "
                _out += Name + ", "
                _out += Me.RetailPrice + " " + Me.RetailCurrency
                Return _out
            End Function

        End Class

        ''' <summary>
        ''' в случае наличия подключения к БД при создании обьекта запишет в поля инфо об образце. Читайте свойства!!!
        ''' </summary>
        ''' <remarks></remarks>
        <Serializable()>
        Public Class clsExtendedSampleInfo
            Private oParentSampleNumber As clsSampleNumber
            ''' <summary>
            ''' создает обьект из БД и заменяет эти значения переданными внешними
            ''' </summary>
            ''' <remarks></remarks>
            Public Sub New(SampleNumber As clsSampleNumber, Prices As strPrices)
                Me.New(SampleNumber)
                'замена значений
                Me.oPrices = Prices
            End Sub
            ''' <summary>
            ''' перезапишет имя образца
            ''' </summary>
            ''' <param name="NewName"></param>
            ''' <remarks></remarks>
            Public Sub SetSampleName(NewName As String, Optional OverwriteNeed As Boolean = False)
                If Me.oSampleName = "" Then
                    Me.oSampleName = NewName
                ElseIf OverwriteNeed Then
                    Me.oSampleName = NewName
                End If
            End Sub



            ''' <summary>
            ''' создает новый обьект из БД
            ''' </summary>
            ''' <param name="SampleNumber"></param>
            ''' <remarks></remarks>
            Public Sub New(SampleNumber As clsSampleNumber)
                oParentSampleNumber = SampleNumber
                Try
                    init()
                Catch ex As Exception
                    MsgBox("Ошибка инициализации класса clsExtendedSampleInfo: " & ex.Message)
                End Try
            End Sub
            Private Sub init()
                Dim _contextPhoto As Service.DBOPHOTOEntities = Service.clsApplicationTypes.SampleDataObject.GetdbPhotoObjectContext
                Dim _contextReadySample As Service.DBREADYSAMPLEEntities = Service.clsApplicationTypes.SampleDataObject.GetdbReadySampleObjectContext
                If (_contextPhoto Is Nothing) Then Return

                'загрузим значения
                Dim key As EntityKey = New EntityKey("DBOPHOTOEntities.tb_Samples_photo_data", "SampleNumber", oParentSampleNumber.GetEan13)
                Dim _result As tb_Samples_photo_data = Nothing
                If _contextPhoto.TryGetObjectByKey(key, _result) Then
                    Me.oSampleName = _result.Sample_main_species
                    Me.oSampleNickName = _result.Sample_nickname
                    oHasPhotoData = True
                Else
                    ' образец не учтен в БД PhotoData
                    oHasPhotoData = False
                End If
                '--------------
                key = New EntityKey("DBREADYSAMPLEEntities.SamplesOnSale", "SampleNumber", oParentSampleNumber.GetEan13)
                Dim _result2 As SamplesOnSale = Nothing
                If _contextReadySample.TryGetObjectByKey(key, _result2) Then
                    Me.oPrices = New strPrices
                    With _result2
                        If .BasePrice Is Nothing Then .BasePrice = 0
                        Me.oPrices.BasePrice = .BasePrice

                        ' If .CurrencyName Is Nothing Then .CurrencyName = ""
                        Me.oPrices.Currency = ""  '.CurrencyName

                        'If .Profit Is Nothing Then .Profit = 0
                        Me.oPrices.PriceWithDiscount = 0 ' .Profit

                        If .Description Is Nothing Then .Description = ""
                        Me.oXMLDescription = .Description

                        Me.oSampleStatus = 0

                        'If .OnSaleFlag Then
                        '    Me.oSampleStatus = 1
                        'ElseIf .ReservedFlag Then
                        '    Me.oSampleStatus = 3
                        'ElseIf .SoldFlag Then
                        '    Me.oSampleStatus = 2
                        'Else
                        '    Me.oSampleStatus = 0
                        'End If
                    End With
                    oHasReadySample = True
                Else
                    ' образец не учтен в БД ReadySample
                    oHasReadySample = False
                End If

                'связь с источником в МС



            End Sub

            Private oHasReadySample As Boolean
            ''' <summary>
            ''' образец учтен в БД ReadySample
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public ReadOnly Property HasReadySample As Boolean
                Get
                    Return oHasReadySample
                End Get
            End Property

            Private oHasPhotoData As Boolean
            ''' <summary>
            ''' образец учтен в БД PhotoData
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public ReadOnly Property HasPhotoData As Boolean
                Get
                    Return oHasPhotoData
                End Get
            End Property

            ''' <summary>
            ''' список товаров с номером и артикулом из МойСклад/ если привязки к делегату нет, то вернет пустую структуру
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public ReadOnly Property GoodInfo As List(Of strGoodInfo)
                Get
                    Dim _obj = clsApplicationTypes.DelegatStoreMCGoodInfo
                    If Not _obj Is Nothing Then
                        Return _obj.Invoke(oParentSampleNumber.ShotCode)
                    End If
                    Return New List(Of strGoodInfo)
                End Get
            End Property



            ''' <summary>
            ''' вернет сформированный текст описания образца
            ''' </summary>
            ''' <param name="culture"></param>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public ReadOnly Property DescriptionString(Optional culture As Globalization.CultureInfo = Nothing) As String

                Get
                    If culture Is Nothing Then culture = clsApplicationTypes.EnglishCulture

                    ''read description from service
                    'check item in DB
                    '///////////////////////
                    Dim _res As Integer
                    'использование сервисов
                    'выполняем вызов из сервиса
                    ' dim _param as object={[parameters_list]}
                    'если делегата нет, то сервис недоступен
                    If Not Global.Service.clsApplicationTypes.DelegateStoreGetSampleInfoText Is Nothing Then
                        'сервис зарегестрирован - вызываем 
                        Dim _result3 = Global.Service.clsApplicationTypes.DelegateStoreGetSampleInfoText.Invoke(oParentSampleNumber, culture, _res)
                        Select Case _res
                            Case -1
                                'ошибка чтения БД
                                Return ""
                            Case 0
                                'данных нет
                                Return ""
                            Case 1, 2
                                'данные есть
                                Return _result3
                        End Select
                    End If
                    Return ""
                End Get
            End Property


            Private oXMLDescription As String
            ''' <summary>
            ''' описание образца в виде строки XML
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public ReadOnly Property XMLDescription As String
                Get
                    Return oXMLDescription
                End Get
            End Property



            Private oSampleStatus As Integer
            ''' <summary>
            ''' without any = 0 // onsale = 1 // sold = 2 // reserved = 3
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public ReadOnly Property SampleStatus As Integer
                Get
                    Return oSampleStatus
                End Get
            End Property


            'Private oCurrency As String
            ' ''' <summary>
            ' ''' валюта стоимости образца
            ' ''' </summary>
            ' ''' <value></value>
            ' ''' <returns></returns>
            ' ''' <remarks></remarks>
            'Public ReadOnly Property Currency As String
            '    Get
            '        Return oCurrency
            '    End Get
            'End Property
            ''' <summary>
            ''' строка со стоимостью образца
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Private ReadOnly Property StringPrice As String
                Get
                    'TODO make currency symbols!!!
                    Return oPrices.Currency + oPrices.BasePrice
                End Get
            End Property

            'Private oPrice As Decimal
            ' ''' <summary>
            ' ''' значение стоимости образца
            ' ''' </summary>
            ' ''' <value></value>
            ' ''' <returns></returns>
            ' ''' <remarks></remarks>
            'Public ReadOnly Property Price As Decimal
            '    Get
            '        Return oPrice
            '    End Get
            'End Property


            Private oSampleNickName As String
            ''' <summary>
            ''' короткое название образца
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public ReadOnly Property SampleNickName As String
                Get
                    Return oSampleNickName
                End Get
            End Property
            <NonSerializedAttribute>
            Dim oPrices As strPrices
            ''' <summary>
            ''' это поле содержит цены из БД трилбон. Для запроса цен из МС используй GoodInfo
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public ReadOnly Property Prices As strPrices
                Get
                    Return oPrices
                End Get
            End Property


            Private oSampleName As String
            ''' <summary>
            ''' основное название образца
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public ReadOnly Property SampleName As String
                Get
                    Return oSampleName
                End Get
            End Property
            ''' <summary>
            ''' Вернет любое значащее имя, предпочтение отдается полному имени образца. Если имен нет, то вернет номер образца
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public ReadOnly Property AnyName As String
                Get
                    Dim _name = Me.SampleName
                    If (_name Is Nothing) OrElse (_name.Count = 0) Then
                        _name = Me.SampleNickName
                        If (_name Is Nothing) OrElse (_name.Count = 0) Then
                            _name = Me.oParentSampleNumber.EAN13
                        End If
                    End If
                    Return _name
                End Get
            End Property



            Public ReadOnly Property Parent As clsSampleNumber
                Get
                    Return oParentSampleNumber
                End Get
            End Property

            ''' <summary>
            '''  вернет полное имя образца со списком фоссилий
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public ReadOnly Property FullName As String
                Get
                    Dim _result As Integer
                    Dim _out As String = ""
                    Dim _data = clsApplicationTypes.SampleDataObject.GetSampleData(oParentSampleNumber, _result)
                    If Not _result > 0 Then Return _out
                    Dim _res = (From c In _data.tb_Samples_Fossils Select c.Fossil_full_name).ToList
                    _out = clsApplicationTypes.FossilNamesParser(_res.ToArray)
                    Return _out
                End Get
            End Property

            ''' <summary>
            ''' вернет дату регистрации или мин.значение даты
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public ReadOnly Property RegisterTime As Date
                Get
                    If Me.HasPhotoData = False Then Return Date.MinValue

                    Dim _result As Integer
                    Dim _data = clsApplicationTypes.SampleDataObject.GetSampleData(oParentSampleNumber, _result)
                    If Not _result > 0 Then Return Date.MinValue

                    Return _data.Date_Photo
                End Get
            End Property
            ''' <summary>
            ''' кто записал в базу
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public ReadOnly Property RegisterWoker As String
                Get
                    If Me.HasPhotoData = False Then Return ""

                    Dim _result As Integer
                    Dim _data = clsApplicationTypes.SampleDataObject.GetSampleData(oParentSampleNumber, _result)
                    If Not _result > 0 Then Return ""

                    Return _data.Woker_full_name
                End Get
            End Property

            ''' <summary>
            ''' выдает строку в формате CSV (разделитель = ;)
            ''' </summary>
            ''' <param name="Currency"></param>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public ReadOnly Property CSVLine(Comma As String, Optional GoodTType As String = "", Optional Currency As String = "USD") As String
                Get
                    If Comma = "" Then Comma = ";"
                    If Me.Prices.Currency = "" Then
                        Me.oPrices.Currency = Currency
                    End If
                    'надо выяснить знак валюты
                    Dim a As String = ""
                    'Dim comma = My.Settings.CSVComma
                    If Not GoodTType = "" Then
                        a += GoodTType + Comma
                    End If
                    a += Me.oParentSampleNumber.EAN13 + Comma
                    a += Me.oParentSampleNumber.ShotCode + Comma
                    a += Me.SampleName + Comma
                    a += Me.SampleNickName + Comma
                    a += Me.Prices.BasePrice.ToString + Comma
                    a += Me.Prices.Currency
                    'в дальнейшем сделать комбинатор символа и валюты, а также конверсию
                    'a += Me.StringPrice + comma
                    a += ChrW(13)
                    Return a
                End Get
            End Property





        End Class

        '/////////////////////////////////////////////

        Private oExtendedSampleInfo As clsSampleNumber.clsExtendedSampleInfo

        Private oReadySampleDBContext As DBREADYSAMPLEEntities

        ''' <summary>
        ''' использовать для хранения цен в текущем контексте
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CurrentPrice As strPrices

        ''' <summary>
        ''' в случае наличия подключения к БД при создании обьекта запишет в поля инфо об образце. Читайте свойства!!!
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overloads Function GetExtendedInfo(Optional RefreshData As Boolean = False) As clsSampleNumber.clsExtendedSampleInfo
            If oExtendedSampleInfo Is Nothing Then
                oExtendedSampleInfo = New clsExtendedSampleInfo(Me)
            End If
            If RefreshData Then

                clsApplicationTypes.SampleDataObject.GetdbPhotoObjectContext.Refresh(Objects.RefreshMode.ClientWins, clsApplicationTypes.SampleDataObject.GetdbPhotoObjectContext.tb_Samples_photo_data)

                If oReadySampleDBContext Is Nothing Then
                    oReadySampleDBContext = clsApplicationTypes.SampleDataObject.GetdbReadySampleObjectContext
                End If


                oExtendedSampleInfo = New clsExtendedSampleInfo(Me)
            End If
            Return oExtendedSampleInfo
        End Function

        Public Overloads Function GetExtendedInfo(Prices As strPrices, Optional RefreshData As Boolean = False) As clsSampleNumber.clsExtendedSampleInfo
            If oExtendedSampleInfo Is Nothing Then
                oExtendedSampleInfo = New clsExtendedSampleInfo(Me, Prices)
            End If
            If RefreshData Then

                clsApplicationTypes.SampleDataObject.GetdbPhotoObjectContext.Refresh(Objects.RefreshMode.ClientWins, clsApplicationTypes.SampleDataObject.GetdbPhotoObjectContext.tb_Samples_photo_data)

                If oReadySampleDBContext Is Nothing Then
                    oReadySampleDBContext = clsApplicationTypes.SampleDataObject.GetdbReadySampleObjectContext
                End If
                oExtendedSampleInfo = New clsExtendedSampleInfo(Me, Prices)
            End If
            Return oExtendedSampleInfo
        End Function
        ''' <summary>
        ''' вернет папку на устройстве с фотками
        ''' </summary>
        ''' <param name="Filesource"></param>
        ''' <returns></returns>
        Public Function GetContainerPath(Filesource As clsFilesSources) As String
            Dim _path = clsApplicationTypes.SamplePhotoObject.GetURIFromContainer(Me.EAN13, clsIDcontent.emContentType.image, Filesource)
            If _path Is Nothing OrElse _path.Length = 0 Then
                Return ""
            End If
            Return IO.Path.GetDirectoryName(_path(0))
        End Function

        ''' <summary>
        ''' вернет список обьектов-описателей для имеющихся фоток образца.можно применить фильтр.
        ''' </summary>
        ''' <param name="Filesource"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetIdContentList(Filesource As clsFilesSources, Optional filter As String = "") As List(Of clsIDcontent)
            Dim _out As New List(Of clsIDcontent)
            Dim _keys = clsApplicationTypes.SamplePhotoObject.GetImageNamesList(Me, Filesource)
            If _keys.Count = 0 Then
                Return _out
            End If

            If Not filter = "" Then
                _keys = (From c In _keys Where c.Contains(filter) Select c).ToArray
            End If

            For Each _k In _keys
                _out.Add(clsIDcontent.CreateInstance(Me.EAN13, _k, clsIDcontent.emContentType.image, False))
            Next
            Return _out
        End Function

        ''' <summary>
        ''' ean13 в цифре, 0 - если код не EAN13
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetEan13() As Decimal
            Return oConverter.EAN13
        End Function


        ''' <summary>
        ''' возвращает номер
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function GetNumber(SampleNumber As String) As Integer
            Dim _result = ShotCodeConverter_Net.clsCode.CreateInstance(SampleNumber)
            If _result.CodeType = ShotCodeConverter_Net.clsCode.emCodeType.Incorrect Then Return 0
            Return _result.Number
        End Function



        ''' <summary>
        ''' возвращает серию
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function GetSeries(SampleNumber As String) As String
            Dim _result = ShotCodeConverter_Net.clsCode.CreateInstance(SampleNumber)
            If _result.CodeType = ShotCodeConverter_Net.clsCode.emCodeType.Incorrect Then Return ""

            Return _result.Series
        End Function

        Private Sub New()
            Me.oCorrectCodeStatus = False
        End Sub
        <NonSerializedAttribute>
        Private oConverter As ShotCodeConverter_Net.clsCode

        ''' <summary>
        ''' создает обьект из строки. Выполняет все проверки. Если нужно, преобразует короткий код. При ошибочном коде возвращает nothing.
        ''' </summary>
        ''' <param name="code"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function CreateFromString(ByVal code As String) As clsSampleNumber
            If code Is Nothing Then Return Nothing
            code = code.Trim
            Dim _code As New clsSampleNumber

            Dim _result = ShotCodeConverter_Net.clsCode.CreateInstance(code)
            _code.oConverter = _result

            If _result.CodeType = ShotCodeConverter_Net.clsCode.emCodeType.Incorrect Then Return _code
            'пока выключим поддержку других кодов, кроме ean13
            If _result.CodeType = ShotCodeConverter_Net.clsCode.emCodeType.EAN13 Then
                _code.oCode = _result.EAN13.ToString
                _code.oCorrectCodeStatus = True
                Return _code
            Else
                Return _code
            End If


        End Function
        ''' <summary>
        ''' код как строка
        ''' </summary>
        Public ReadOnly Property EAN13 As String
            Get
                Return Trim(oCode)
            End Get
        End Property
        ''' <summary>
        ''' true если код это EAN13
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property IsEAN13 As Boolean
            Get
                If Me.GetEan13 = 0 Then Return False
                Return True
            End Get
        End Property

        ''' <summary>
        ''' вернет набор символов шрифта EAN13p36TT
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property EAN13p36TT As String
            Get
                Return oConverter.EAN13p36TT
            End Get
        End Property
        ''' <summary>
        ''' показывает, можно ли читать расширенную инфо по образцу, либо оно будет создано
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property HasExtendedInfo As Boolean
            Get
                If oExtendedSampleInfo Is Nothing Then Return False
                Return True
            End Get
        End Property

        ''' <summary>
        ''' возвращает короткий код
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property ShotCode As String
            Get
                Return oConverter.ShotCode
            End Get
        End Property
        ''' <summary>
        ''' владелец (первая цифра кода для EAN13), для других кодов совпадает с серией
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property Owner As String
            Get
                Return oConverter.Owner
            End Get
        End Property

        ''' <summary>
        ''' символ-разделитель для короткого кода
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property CodeSplitter As String
            Get
                Return ShotCodeConverter_Net.clsCode.CodeSplitter
            End Get
        End Property


        ''' <summary>
        ''' артикул(доп номер) 1 знак
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property SubNumber As Integer
            Get
                Return oConverter.SubNumber
            End Get
        End Property


        ''' <summary>
        ''' вернет чистый номер
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property Number As Decimal
            Get

                Return oConverter.Number
            End Get
        End Property

        ''' <summary>
        ''' серия кода 1,3,4 знака
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property Series As String
            Get
                Return oConverter.Series
            End Get
        End Property

        ''' <summary>
        ''' увеличит номер и вернет короткий код
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function IncreaceNumber() As String
            Return oConverter.IncreaceNumber.ShotCode
        End Function

        ''' <summary>
        ''' уменьшит номер и вернет короткий код
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function DecreaceNumber() As String
            Return oConverter.DecreaceNumber.ShotCode
        End Function

        ''' <summary>
        ''' увеличит подномер и вернет короткий код
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function IncreaceSubNumber() As String
            Return oConverter.IncreaceSubnumber.ShotCode
        End Function



        ''' <summary>
        ''' уменьшит подномер и вернет короткий код
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function DecreaceSubNumber() As String
            Return oConverter.DecreaceSubnumber.ShotCode
        End Function

        Public Overrides Function Equals(ByVal obj As Object) As Boolean
            If Not TypeOf (obj) Is clsSampleNumber Then Return False

            Dim _s = CType(obj, clsSampleNumber)

            If _s.CodeIsCorrect = False Then Return MyBase.Equals(obj)
            If Me.CodeIsCorrect = False Then Return MyBase.Equals(obj)

            If Me.GetHashCode = _s.GetHashCode Then Return True

            Return MyBase.Equals(_s)

        End Function

        Public Function CompareTo(other As clsSampleNumber) As Integer Implements IComparable(Of clsSampleNumber).CompareTo
            Return Me.CompareTo1(other)
        End Function

        Private Function CompareTo1(ByVal obj As Object) As Integer Implements System.IComparable.CompareTo
            If Not TypeOf obj Is clsApplicationTypes.clsSampleNumber Then Return 0
            Return Me.Compare(Me, obj)
        End Function

        Private Function Compare(ByVal x As clsSampleNumber, ByVal y As clsSampleNumber) As Integer Implements System.Collections.Generic.IComparer(Of clsSampleNumber).Compare
            If x Is Nothing Then Return 0
            If y Is Nothing Then Return 0
            If Not x.Series.Equals(y.Series) Then Return x.Series.CompareTo(y.Series)
            Return x.Number.CompareTo(y.Number)
            'Return x.EAN13.CompareTo(y.EAN13)
        End Function

        ''' <summary>
        ''' восстанавливает код
        ''' </summary>
        Public Shared Function GetFullCodeByShot(ByVal ShotCode As String) As String
            Dim _result = ShotCodeConverter_Net.clsCode.CreateInstance(ShotCode)
            If _result.CodeType = ShotCodeConverter_Net.clsCode.emCodeType.Incorrect Then Return ""

            Return _result.EAN13.ToString

        End Function
        ''' <summary>
        ''' возвращает короткий код по полному
        ''' </summary>
        ''' <param name="FullCode"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function GetShotCodeByFull(ByVal FullCode As String) As String
            Dim _result = ShotCodeConverter_Net.clsCode.CreateInstance(FullCode)
            If _result.CodeType = ShotCodeConverter_Net.clsCode.emCodeType.Incorrect Then Return ""

            Return _result.ShotCode
        End Function



        ''' <summary>
        ''' возвращает том (раздел) для устройства хранения
        ''' </summary>
        ''' <param name="BaseBorder">граница тома 1-99. по умолчанию 99</param>
        Public Shared Function GetVolume(SampleNumber As String, Optional ByVal BaseBorder As Integer = 99) As String
            Dim _number As Integer = GetNumber(SampleNumber)
            Dim _base As Integer = Math.Truncate(_number * 0.01)
            Dim _rezult As String = Trim(Trim(_base.ToString) & Trim(BaseBorder))
            If _base = 0 Then _rezult = _rezult.Substring(1)
            Return _rezult
        End Function
        ''' <summary>
        ''' отмечается при создании кода
        ''' </summary>
        Private oCorrectCodeStatus As Boolean

        ''' <summary>
        ''' код прошел проверку
        ''' </summary>
        Public ReadOnly Property CodeIsCorrect As Boolean
            Get
                Return oCorrectCodeStatus
            End Get
        End Property

        Public Overrides Function ToString() As String
            Return Me.EAN13
        End Function

        Public Overrides Function GetHashCode() As Integer
            'использовать для нумерации папки
            'Math.Abs(_sample.GetHashCode).ToString
            Return Me.EAN13.GetHashCode
        End Function

        ''' <summary>
        ''' запрашивает и выдает информацию о судьбе камня
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetHistoryString() As String
            If oReadySampleDBContext Is Nothing Then
                oReadySampleDBContext = clsApplicationTypes.SampleDataObject.GetdbReadySampleObjectContext
            End If
            Dim _clients As String = "Клиенты: " & ChrW(13)
            Dim _history As String = String.Format("Образец номер: {0}", Me.ShotCode)
            _history = AskTrilboneDB(_history)
            _history = _history & ChrW(13)

            _history = AskTrilboneHistory(_history, _clients)
            _history = _history & ChrW(13)

            _history = AskCatalogHistory(_history, _clients)
            _history = _history & ChrW(13) & _clients & ChrW(13)

            'что знаем про клиентов
            '_history = _clients & ChrW(13)

            _history = AskMoySklad(_history)
            _history = _history & ChrW(13)

            RaiseEvent HistoryAfterChange(Me, New HistoryChangeEventArgs(_history))
            Return _history
        End Function
        ''' <summary>
        ''' история образца в базе движений
        ''' </summary>
        ''' <param name="history"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function AskTrilboneHistory(history As String, ByRef _clientHistory As String) As String
            Dim _partOfHistory As String = String.Format("{0}Запрашиваем базу движений образцов Trilbone...{0}", ChrW(13))
            RaiseEvent HistoryBeforeChange(Me, New HistoryChangeEventArgs(history & _partOfHistory))
            ' _partOfHistory = ""
            '------------------
            Dim _his = (oReadySampleDBContext.pSLGetSampleHistoryInfo(Me.GetEan13)).ToList
            If _his.Count = 0 Then
                'no info
                _partOfHistory += String.Format("{0}В базе движений образцов Trilbone не учтен", ChrW(13))

            Else
                For Each t In _his
                    Dim _operation As String = IIf(String.IsNullOrEmpty(t.Operation), "", t.Operation)
                    Dim _resource As String = IIf(String.IsNullOrEmpty(t.Resource), "", t.Resource)
                    Dim _ResourceInnerType As String = IIf(String.IsNullOrEmpty(t.ResourceInnerType), "", t.ResourceInnerType)
                    Dim _toClient As String = IIf(String.IsNullOrEmpty(t.clientName), "", "для " & t.clientName & " / " & t.clientEmail)
                    Dim _currency As String = IIf(String.IsNullOrEmpty(t.currency), "", t.currency).ToString.ToLower
                    Dim _email As String = IIf(t.emailSended.GetValueOrDefault, " //Email послан//", "")
                    _partOfHistory = _partOfHistory & String.Format("{0}{1} {2}[{3}]:{5} {6}{0} ({4}){0}{7}{8}{0}", ChrW(13), t.Date.ToShortDateString, _operation, _resource, _ResourceInnerType, t.startPrice.GetValueOrDefault, _currency, _toClient, _email)
                    _clientHistory += String.Format("{0}: {1}{2}{3}", _toClient, t.startPrice.GetValueOrDefault, _currency, ChrW(13))
                Next
            End If
            '------------------
            RaiseEvent HistoryAfterChange(Me, New HistoryChangeEventArgs(history & _partOfHistory))
            Return history & _partOfHistory
        End Function

        ''' <summary>
        ''' история в каталогах
        ''' </summary>
        ''' <param name="history"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function AskCatalogHistory(history As String, ByRef _clientHistory As String) As String
            Dim _partOfHistory As String = String.Format("{0}Запрашиваем каталоги Trilbone...", ChrW(13))
            RaiseEvent HistoryBeforeChange(Me, New HistoryChangeEventArgs(history & _partOfHistory))
            '_partOfHistory = ""
            '------------------
            Dim _orderinfo = (oReadySampleDBContext.OrderInfo(Me.GetEan13)).ToList 'New List(Of OrderInfo_Result) '
            If _orderinfo.Count = 0 Then
                'no info
                _partOfHistory = String.Format("{0}В каталогах Trilbone не предлагался", ChrW(13))
            Else
                For Each k In _orderinfo
                    Dim _offerPrice = Math.Round((k.Offer_Price.GetValueOrDefault - (k.Offer_Price.GetValueOrDefault * k.Offer_Discount.GetValueOrDefault / 100)), 2)
                    Dim _currency As String = IIf(String.IsNullOrEmpty(k.Currency), "", k.Currency).ToString.ToLower

                    _partOfHistory = _partOfHistory & String.Format("{0} {1} {2}: {3} {4}{0} (каталог {5})", ChrW(13), k.OrderDate.ToShortDateString, k.Client_full_name, _offerPrice, _currency, k.OrderID)
                    _partOfHistory = _partOfHistory & String.Format("{0}Результат: ", ChrW(13))

                    _clientHistory += String.Format("{0}: {1}{2}{3}", k.Client_full_name, _offerPrice, _currency, ChrW(13))

                    If k.Sample_Confirm_Status Then
                        'продан
                        _partOfHistory = _partOfHistory & String.Format("продан за {0}{1}", k.Sample_Confirm_Price.GetValueOrDefault, IIf(String.IsNullOrEmpty(k.Currency), "", k.Currency).ToString.ToLower)
                        _clientHistory += String.Format("ПРОДАН {0}: {1}{2}{3}", k.Client_full_name, k.Sample_Confirm_Price.GetValueOrDefault, IIf(String.IsNullOrEmpty(k.Currency), "", k.Currency).ToString.ToLower, ChrW(13))

                    ElseIf k.Order_Cancellation_Status = False And k.Order_CheckOut_Status = False And k.Order_StockOut_Status = False Then
                        'каталог активен
                        _partOfHistory = _partOfHistory & String.Format("в резерве за {0}{1}", _offerPrice, IIf(String.IsNullOrEmpty(k.Currency), "", k.Currency).ToString.ToLower)
                    ElseIf k.Order_Cancellation_Status = True Then
                        'каталог отменен
                        _partOfHistory = _partOfHistory & String.Format("не продан, отменено все предложение")
                    ElseIf k.Order_CheckOut_Status Or k.Order_StockOut_Status Then
                        'был предложен, но не куплен
                        _partOfHistory = _partOfHistory & String.Format("не продан, не выбран из предложения")
                    End If
                    _partOfHistory += ChrW(13)
                Next
            End If


            '------------------
            RaiseEvent HistoryAfterChange(Me, New HistoryChangeEventArgs(history & _partOfHistory))
            Return history & _partOfHistory
        End Function

        ''' <summary>
        ''' история в основной базе
        ''' </summary>
        ''' <param name="history"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function AskTrilboneDB(history As String) As String
            Dim _partOfHistory As String = String.Format("{0}Запрашиваем Trilbone...", ChrW(13))
            RaiseEvent HistoryBeforeChange(Me, New HistoryChangeEventArgs(history & _partOfHistory))
            _partOfHistory = ""
            '------------------
            Dim _date = Me.GetExtendedInfo.RegisterTime
            If _date = Date.MinValue Then
                'no info
                _partOfHistory = String.Format("{0}Нет в базе Trilbone", ChrW(13))
            Else
                Dim _photo = clsApplicationTypes.SamplePhotoObject.GetCountImages(Me, clsFilesSources.Arhive)
                _partOfHistory = String.Format("{0}{1} Записан в Trilbone как {4} ({2}){0}{3}", ChrW(13), _date.ToShortDateString, Me.oExtendedSampleInfo.RegisterWoker, IIf(_photo > 0, "фотки есть, " & _photo & "шт", "фоток нет"), Me.oExtendedSampleInfo.AnyName)
                If _photo > 0 Then
                    Dim _img = clsApplicationTypes.SamplePhotoObject.GetMainImage(clsFilesSources.Arhive, Me, True)
                    If Not _img Is Nothing Then
                        RaiseEvent HistoryImageReady(Me, New HistoryChangeEventArgs(_img))
                    End If
                End If
            End If
            '------------------
            RaiseEvent HistoryAfterChange(Me, New HistoryChangeEventArgs(history & _partOfHistory))
            Return history & _partOfHistory
        End Function

        Public Function AskName() As String
            Dim _num = Me.GetEan13

            Dim _name = (From c In clsApplicationTypes.SampleDataObject.GetdbPhotoObjectContext.tb_Samples_photo_data Where c.SampleNumber = _num Select c.Sample_main_species).ToList
            If _name.Count > 0 Then
                Return _name.FirstOrDefault
            End If
            Return ""
        End Function

        ''' <summary>
        ''' вернет список складов и инфо о резервации
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function AskLocations(Optional WareHouseName As String = "") As String
            Dim _msi = clsApplicationTypes.MoySklad(False)
            If _msi Is Nothing Then Return "мой склад в процессе загрузки"
            Dim _result = _msi.FindStokQuantity(PartName:="", ShotCode:=Me.ShotCode, WareHouseName:=WareHouseName, IncludeReserved:=True)
            Dim _out As String = ""
            For Each t In _result
                _out += t.ToString & ChrW(13)
            Next
            If String.IsNullOrEmpty(_out) Then
                _out = "нет информации"
            End If
            Return _out
        End Function

        ''' <summary>
        ''' вернет одну фотку камня
        ''' </summary>
        ''' <remarks></remarks>
        Public Function AskImage() As Image
            Dim _photo = clsApplicationTypes.SamplePhotoObject.GetCountImages(Me, clsFilesSources.Arhive)
            If _photo > 0 Then
                Dim _img = clsApplicationTypes.SamplePhotoObject.GetMainImage(clsFilesSources.Arhive, Me, True)
                If Not _img Is Nothing Then
                    Return _img
                    'RaiseEvent HistoryImageReady(Me, New HistoryChangeEventArgs(_img))
                End If
            End If
            Return Nothing
        End Function

        Private Function AskMoySklad(history As String) As String
            Dim _partOfHistory As String = String.Format("{0}Запрашиваем Мой Склад...", ChrW(13))
            RaiseEvent HistoryBeforeChange(Me, New HistoryChangeEventArgs(history & _partOfHistory))

            Return history & "Мой склад отключен" & ChrW(13)

            _partOfHistory = ""
            '------------------
            Dim _res = Me.GetExtendedInfo.GoodInfo

            If _res Is Nothing OrElse _res.Count = 0 Then
                'no info
                If clsApplicationTypes.MoySklad(False, False) Is Nothing Then
                    _partOfHistory = String.Format("{0}Мой Склад пока не готов к запросам..", ChrW(13))
                Else
                    _partOfHistory = String.Format("{0}Нет в Мой Склад", ChrW(13))
                End If
            Else
                For Each t In _res
                    If t.LoadStatus > 0 Then
                        Dim _buyString = IIf(t.BuyPrice > 0, String.Format("Цена закупки: {0}{1}", t.BuyPrice, IIf(String.IsNullOrEmpty(t.BuyCurrency), "(валюта не указана)", t.BuyCurrency).ToString.ToLower), "Цена закупки отсутствует")
                        Dim _retailString = IIf(t.RetailPrice > 0, String.Format("Розница: {0}{1}", t.RetailPrice, IIf(String.IsNullOrEmpty(t.RetailCurrency), "(валюта не указана)", t.RetailCurrency).ToString.ToLower), "Розничная цена не установлена")

                        _partOfHistory = _partOfHistory & String.Format("{0}{1} Записан в Мой Склад как {5} ({2}){0}{3}{0}{4}", ChrW(13), t.Updated.ToShortDateString, t.UpdatedBy, _buyString, _retailString, t.Name)
                        Dim _location = t.goodLocationInfo(t)
                        If _location Is Nothing OrElse _location.Count = 0 Then
                            _partOfHistory = _partOfHistory & String.Format("{0}На складах не зарегестрирован", ChrW(13))
                        Else
                            For Each l In _location
                                _partOfHistory = _partOfHistory & String.Format("{0}Находится: {1}", ChrW(13), l)
                            Next
                        End If
                    End If
                Next
            End If
            '-----------------
            RaiseEvent HistoryAfterChange(Me, New HistoryChangeEventArgs(history & _partOfHistory))
            Return history & _partOfHistory
        End Function

        Public Event HistoryAfterChange(sender As Object, e As HistoryChangeEventArgs)
        Public Event HistoryBeforeChange(sender As Object, e As HistoryChangeEventArgs)
        Public Event HistoryImageReady(sender As Object, e As HistoryChangeEventArgs)
        Public Class HistoryChangeEventArgs
            Inherits EventArgs
            Public ReadOnly Property ContainsImage As Boolean
                Get
                    If Image Is Nothing Then Return False
                    Return True
                End Get
            End Property
            Public Property HistoryString As String
            Public Property Image As Image
            Public Sub New(history As String)
                HistoryString = history
            End Sub
            Public Sub New(Img As Image)
                Image = Img
            End Sub
        End Class


    End Class

    Public Class clsOrder
        Implements IComparable
        Implements IComparer(Of clsOrder)
        Private oClientID As Decimal
        Private oClientFullName As String
        Private oOrderID As String
        Public Sub New(ByVal OrderID As String)
            oOrderID = Trim(OrderID)
            If oOrderID Is Nothing Then
                oOrderID = ""
            End If
        End Sub
        ''' <summary>
        ''' проверяет наличие OrderID
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property IsValidOrder As Boolean
            Get
                If Me.oOrderID = "" Then Return False
                If Me.oOrderID.Length = 0 Then Return False
                If Me.oOrderID.Length > 8 Then Return False
                Return True
            End Get
        End Property
        Public Property ClientID As Integer
            Get
                Return oClientID
            End Get
            Set(ByVal value As Integer)
                oClientID = value
            End Set
        End Property

        Public Property ClientFullName As String
            Get
                Return oClientFullName

            End Get
            Set(ByVal value As String)
                oClientFullName = value
            End Set
        End Property

        Public Property OrderID As String
            Get
                Return oOrderID

            End Get
            Set(ByVal value As String)
                Debug.Assert(value.Length < 8 Or value.Length > 0, "Длина ID заказа отлична от диапазона 1-8! OrderID=" & value)
                oOrderID = Trim(value)
            End Set
        End Property
        Public Shared Operator =(ByVal x As clsOrder, ByVal y As clsOrder) As Boolean
            If x Is Nothing Then Return False
            If y Is Nothing Then Return False

            If Not String.Compare(x.OrderID, y.OrderID, StringComparison.OrdinalIgnoreCase) Then Return False
            If Not x.ClientID = y.ClientID Then Return False
            If Not String.Compare(x.ClientFullName, y.ClientFullName, StringComparison.OrdinalIgnoreCase) Then Return False
            Return True
        End Operator
        Public Shared Operator <>(ByVal x As clsOrder, ByVal y As clsOrder) As Boolean
            If x Is Nothing Then Return True
            If y Is Nothing Then Return False
            If Not String.Compare(x.OrderID, y.OrderID, StringComparison.OrdinalIgnoreCase) Then Return True
            If Not x.ClientID = y.ClientID Then Return True
            If Not String.Compare(x.ClientFullName, y.ClientFullName, StringComparison.OrdinalIgnoreCase) Then Return True
            Return False
        End Operator

        Public Function CompareTo(obj As Object) As Integer Implements System.IComparable.CompareTo
            If Not TypeOf obj Is clsOrder Then Return 0
            Return Compare(Me, obj)
        End Function

        Public Function Compare(x As clsOrder, y As clsOrder) As Integer Implements System.Collections.Generic.IComparer(Of clsOrder).Compare
            Dim _dayx As String = "", _monthx As String = "", _yearx As String = "", _numx As String = ""
            Dim _dayy As String = "", _monthy As String = "", _yeary As String = "", _numy As String = ""


            'п  роверим первую букву - если цифра, то
            Select Case Char.IsDigit(x.oOrderID.Take(1).ToList.Item(0))
                Case True
                    'первая - цифра
                    If x.oOrderID.Contains("-") Then
                        'сортировка по стандарту 130313-1
                        _dayx = x.oOrderID.Substring(0, 2).Trim
                        _monthx = x.oOrderID.Substring(2, 2).Trim
                        _yearx = x.oOrderID.Substring(4, 2).Trim
                        _numx = x.oOrderID.Split("-")(1).Trim
                    Else
                        'сортировка по стандарту 13032013
                        _dayx = x.oOrderID.Substring(0, 2).Trim
                        _monthx = x.oOrderID.Substring(2, 2).Trim
                        _yearx = x.oOrderID.Substring(4, 4).Trim
                        _numx = "1"
                    End If
                Case False
                    'первая - буква
                    Return String.Compare(x.oOrderID, y.oOrderID)
            End Select

            'проверим первую букву - если цифра, то
            Select Case Char.IsDigit(y.oOrderID.Take(1).ToList.Item(0))
                Case True
                    'первая - цифра
                    If y.oOrderID.Contains("-") Then
                        'сортировка по стандарту 130313-1
                        _dayy = y.oOrderID.Substring(0, 2).Trim
                        _monthy = y.oOrderID.Substring(2, 2).Trim
                        _yeary = y.oOrderID.Substring(4, 2).Trim
                        _numy = y.oOrderID.Split("-")(1).Trim
                    Else
                        'сортировка по стандарту 13032013
                        _dayy = y.oOrderID.Substring(0, 2).Trim
                        _monthy = y.oOrderID.Substring(2, 2).Trim
                        _yeary = y.oOrderID.Substring(4, 4).Trim
                        _numy = "1"
                    End If
                Case False
                    'первая - буква
                    Return String.Compare(x.oOrderID, y.oOrderID)
            End Select

            'собственно сравнение
            If _dayx = _dayy And _monthx = _monthy And _yearx = _yeary Then Return 0
            If _yearx > _yeary Then Return 1
            If _yearx < _yeary Then Return -1
            'года равны - месяца
            If _monthx > _monthy Then Return 1
            If _monthx < _monthy Then Return -1
            'месяца равны сравним даты
            If _dayx > _dayy Then Return 1
            If _dayx < _dayy Then Return -1
            'дни равны, номера
            If _numx > _numy Then Return 1
            If _numx < _numy Then Return -1
            'заказы равны
            Return 0
        End Function

        Public Overrides Function Equals(obj As Object) As Boolean
            If obj Is Nothing Then Return False
            If Not TypeOf obj Is clsOrder Then Return False
            If CType(obj, clsOrder).OrderID.Equals(Me.oOrderID) Then Return True
            Return False
        End Function

        Public Overrides Function GetHashCode() As Integer
            If oOrderID Is Nothing Then oOrderID = ""
            Return oOrderID.GetHashCode
        End Function

        Public Overrides Function ToString() As String
            Return oOrderID
        End Function

    End Class

    Public Enum emTemplateType
        CatalogHTML = 1
        CatalogTXT = 2
        Site_mail_template = 3
        eBay_Nordstar_txt = 4
        Tribone_template_img = 5
        ByName = 6
    End Enum

    Public Enum emCatalogFolderType
        ''' <summary>
        ''' папка фоток названа коротким кодом
        ''' </summary>
        shot
        ''' <summary>
        ''' папка фоток названа полным кодом EAN13
        ''' </summary>
        ean13
        ''' <summary>
        ''' папка фоток названа хешем кода EAN13
        ''' </summary>
        hash
    End Enum


    Public Enum emCurrencyList As Integer
        USD = 0
        EUR = 1
        RUR = 2

    End Enum





    Public Enum emFormsList As Integer
        ''' <summary>
        '''параметр param{0} - тип cls
        ''' </summary>
        ''' <remarks></remarks>
        fmPhotoList = 0

        ''' <summary>
        ''' параметр param{0} - типы Image, Bitmap, List(of Image), ImageList, SampleSourceImageList
        ''' </summary>
        ''' <remarks></remarks>
        fmImage = 1

        ''' <summary>
        ''' параметр param{0} - SampleNumber (Decimal)
        ''' </summary>
        ''' <remarks></remarks>
        fmSampleData = 2

        ''' <summary>
        ''' параметр param{0} - SampleNumber (Decimal)
        ''' </summary>
        ''' <remarks></remarks>
        fmSampleOnSale = 3

        ''' <summary>
        ''' параметров нет
        ''' </summary>
        ''' <remarks></remarks>
        fmClients = 4

        ''' <summary>
        ''' параметр param{0} - orderID
        ''' </summary>
        ''' <remarks></remarks>
        fmOrders = 5

        ' ''' <summary>
        ' ''' параметр param{0} - (string) путь к файлу данных
        ' ''' </summary>
        ' ''' <remarks></remarks>
        'fmFossilData = 6

        ''' <summary>
        ''' параметр param{0} - SampleNumber (clsSampleNumber)
        ''' </summary>
        ''' <remarks></remarks>
        fmSampleInfo = 7

        ''' <summary>
        ''' параметров нет
        ''' </summary>
        ''' <remarks></remarks>
        fmExcelConnection = 8

        ''' <summary>
        ''' параметр param{0} - SampleNumber (Decimal); param{1} - ActiveFolder (string) (путь)
        ''' </summary>
        ''' <remarks></remarks>
        fmImageManager = 9

        ''' <summary>
        ''' параметров нет
        ''' </summary>
        ''' <remarks></remarks>
        fmCatalogConnect = 10

        ''' <summary>
        ''' параметров нет
        ''' </summary>
        ''' <remarks></remarks>
        fmDBInfo1

        ''' <summary>
        '''параметр param{0} - Trilbone.clsTreeService.clsDescriptionElement
        ''' </summary>
        ''' <remarks></remarks>
        fmDescriptionTreeBuilder

        ''' <summary>
        ''' параметр param{0} - string() список номеров; param{1} - заголовок окна (string); выбранный образец можно прочитать в свойстве SelectedNumber  (string)
        ''' </summary>
        ''' <remarks></remarks>
        fmSampleList

        ''' <summary>
        ''' параметр param{0} - обьект, реализующий iListSampleDataProvider или param{0} - string имя файла списков
        ''' </summary>
        ''' <remarks></remarks>
        fmListManager

        ''' <summary>
        ''' параметр param{0} - путь к XML файлу образца или строка XML 
        ''' </summary>
        ''' <remarks></remarks>
        fmCatalogSample


        ''' <summary>
        ''' параметр param{0} - (string)SampleNumber(короткий код); param{1} - (string)SampleName; 
        ''' param{2} - (string)Barcode; param{3} - (string)Articul; param{4} - (Dictionary(Of String, Decimal))Prices;param{5} - (string)Currency(USD|RUR|EUR)
        ''' </summary>
        ''' <remarks></remarks>
        fmMoySklad

        ''' <summary>
        '''  параметров нет
        ''' </summary>
        ''' <remarks></remarks>
        fmCalculator

        ''' <summary>
        '''  параметров нет
        ''' </summary>
        ''' <remarks></remarks>
        fmTrilboneEbay
        ''' <summary>
        ''' string Фраза для поиска
        ''' </summary>
        ''' <remarks></remarks>
        fmEbaySearch

        ''' <summary>
        ''' параметров нет
        ''' </summary>
        ''' <remarks></remarks>
        fmSite

    End Enum



    Public Enum emStoreSourses As Integer
        dbo = 0
        xml = 1
    End Enum

    Private Shared oConnection As clsConnectionBase
    Private Shared oCalculator As PriceCalculator.clsCalculatorService

#If DEBUG Then
    ''' <summary>
    ''' для отладки
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CreateInstance() As clsApplicationTypes
        Dim _service = New clsApplicationTypes
        'для отладки
        Service.clsApplicationTypes.LoadUsers()
        Service.clsApplicationTypes.LoadUsers(True)
        Dim _message As String = ""
        Dim _azurePhotoCONSTR = "Server=tcp:v0ecxr50yd.database.windows.net,1433;Database=DBOPHOTO;User ID=foto@v0ecxr50yd;Password=Asaphus2009;Trusted_Connection=false;TrustServerCertificate=True;Encrypt=True;Connection Timeout=30;"
        Dim _azureSampleCONSTR = "Server=tcp:v0ecxr50yd.database.windows.net,1433;Database=DBREADYSAMPLE;User ID=foto@v0ecxr50yd;Password=Asaphus2009;Trusted_Connection=false;TrustServerCertificate=True;Encrypt=True;Connection Timeout=30;"
        If _service.InitDbConnection(_message, True, _azurePhotoCONSTR, _azureSampleCONSTR) Then
            Return _service
        Else
            Return Nothing
        End If
    End Function
#End If

    Public Sub New()
        clsApplicationTypes.oSamplePhotoManager = clsSamplePhotoManager.CreateInstance
        clsApplicationTypes.oSampleDataManager = New clsSampleDataManager
        clsApplicationTypes.oCalculator = New PriceCalculator.clsCalculatorService
        oApplicationFormDelegateCollection = New Generic.SortedList(Of emFormsList, ApplicationFormDelegateFunction)

        Global.Service.clsApplicationTypes.DelegateStoreApplicationForm _
            (emFormsList.fmCalculator) =
            New ApplicationFormDelegateFunction(AddressOf oCalculator.GetCalculator)

    End Sub

    ''' <summary>
    ''' статус подключения
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Property NetworkStatus As Boolean


    ''' <summary>
    ''' запуск таймера
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub RunTimer()

        'подготовка запуска процесса eBay
        oeBayInvoker = New BackgroundWorker
        AddHandler oeBayInvoker.DoWork, AddressOf backgroundWorkerEbay_DoWork
        AddHandler oeBayInvoker.RunWorkerCompleted, AddressOf backgroundWorkereBAy_RunWorkerCompleted

        'таймер
        oTimer = New Timer
        With oTimer
            .Interval = 1000 * timerSecondsInterval
            AddHandler oTimer.Tick, AddressOf TimerTickEventHandler
        End With

        oActiveTicks = 0
        oTimer.Start()
        TimerTickEventHandler(oTimer, EventArgs.Empty)
    End Sub


    ''' <summary>
    ''' 600 seconds = 10 minut
    ''' </summary>
    ''' <remarks></remarks>
    Private Const timerSecondsInterval As Integer = 600

    Private Shared oTimer As Timer
    Private Shared oActiveTicks As Long
    Private Shared oeBayInvoker As BackgroundWorker

    ''' <summary>
    ''' можно запустить процесс ебай из вне
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property EbayInvoker As BackgroundWorker
        Get
            Return oeBayInvoker
        End Get
    End Property


    ''' <summary>
    ''' таймер и действия по времени
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Shared Sub TimerTickEventHandler(sender As Object, e As EventArgs)
        oActiveTicks += 1
        'интервал таймера 10 минут
        If Not NetworkStatus Then
            RaiseEvent InnerTimerTick(EventArgs.Empty)
            Return
        End If

        '------------------
        'опрос ebay
        If Not oeBayInvoker Is Nothing Then
            If oeBayInvoker.IsBusy Then
                'запрос eBay в процессе
                GoTo nx1
            Else
                'запуск процесса eBay только при указании в опциях или из окна управления словами ебай
                If My.Settings.EbayQuery Then
                    oeBayInvoker.RunWorkerAsync()
                End If
            End If
        End If
        '-------------------
nx1:
        'проверка отключения сотрудников после 23-30 до 7-59 +-10мин  ДОБАВИТЬ ОПЕРАЦИИ!!!
        If (Date.Now.TimeOfDay.Hours >= 23 AndAlso Date.Now.TimeOfDay.Minutes >= 30) Or (Date.Now.TimeOfDay.Hours <= 7) Then
#If DEBUG Then
            If oActiveTicks > 2 Then
                StopActiveUsers()

            End If
#Else
        Try
        If oActiveTicks > 2 Then
                StopActiveUsers()

         End If
        Catch ex As Exception
        'не удалось остановить сотрудников
        End Try
#End If
        End If

        RaiseEvent InnerTimerTick(EventArgs.Empty)
    End Sub

    ''' <summary>
    ''' срабатывает каждые 10 минут и при старте приложения
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Shared Event InnerTimerTick(e As EventArgs)


    ''' <summary>
    ''' отключить активных сотрудников  ДОБАВИТЬ ОПЕРАЦИИ!!!
    ''' </summary>
    ''' <remarks></remarks>
    Private Shared Sub StopActiveUsers()
        'проверка отключения сотрудников после 23-30 до 7-59 +-10мин
        If Not clsApplicationTypes.NetworkStatus Then
            'сети нет
            Return
        End If

        For Each u In clsApplicationTypes.Users
            u.RequestStatus()
            If (u.CurrentStatus = clsSampleDataManager.emWTimeOperation.BeginOnWork Or u.CurrentStatus = clsSampleDataManager.emWTimeOperation.SuspendWork) And (u.UserPermission.GetAccess("безлимитная работа") = False) Then
                ''TODO пока запись идет как от пользователя, в дальнейшем надо изменить!!!
                Dim _result = clsApplicationTypes.SampleDataObject.RegisterTime(u.Employee.ID, clsSampleDataManager.emWTimeOperation.EndWork, clsSampleDataManager.emWTimeRecordType.User)
                If Not _result Is Nothing Then
                    u.SetUserStatus(_result.TimeAccounting.Value, _result.WTimeOperationID.Value)
                    'остановить операции!!!
                    BeepYES()
                End If
            End If
        Next
    End Sub


    '===========================
    'Public Delegate Function ActiveOrderDelegateFunction() As Order
#Region "Сервис активного заказа: источник fmMain"

    Public Delegate Function ActiveOrderDelegateFunction() As clsOrder

    Private Shared oActiveOrderDelegate As ActiveOrderDelegateFunction
    Public Shared Property DelegatStoreActiveOrder As ActiveOrderDelegateFunction
        Get
            Select Case GetAccess("Доступ к заказам")
                Case True
                    If oActiveOrderDelegate Is Nothing Then
                        MsgBox("Сервис активного заказа недоступен.", MsgBoxStyle.Critical)
                    End If
                    Return oActiveOrderDelegate
                Case False
                    MsgBox("Сервис активного заказа недоступен. Нет прав доступа.", MsgBoxStyle.Critical)
                    Return Nothing
                Case Else
                    MsgBox("Сервис активного заказа недоступен. Нет прав доступа.", MsgBoxStyle.Critical)
                    Return Nothing
            End Select
        End Get
        Set(ByVal value As ActiveOrderDelegateFunction)
            oActiveOrderDelegate = value

        End Set
    End Property

#End Region

    '===========================
    '    Public Delegate Function SynchroSampleDataDboDelegateFunction(ByVal xml As String) As Boolean

#Region "Мой Склад"
    '-----------------------------
    Public Delegate Function GetClientsFromMSDelegateFunction(reload As Boolean) As iMoySkladDataProvider.clsClientInfo()

    Private Shared oDelegatStoreGetClientsFromMS As GetClientsFromMSDelegateFunction

    'ByRef Data As Dictionary(Of String, String), Optional ByRef servermessage As String = ""
    Public Shared Property DelegatStoreGetClientsFromMS As GetClientsFromMSDelegateFunction
        Get
            Return oDelegatStoreGetClientsFromMS
        End Get
        Set(value As GetClientsFromMSDelegateFunction)
            oDelegatStoreGetClientsFromMS = value
        End Set
    End Property
    '-----------------------------

    Private Shared oDelegatStoreMCGoodInfo As Func(Of String, List(Of clsSampleNumber.strGoodInfo))

    ''' <summary>
    ''' хранит делегат вызова МС Good
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Property DelegatStoreMCGoodInfo() As Func(Of String, List(Of clsSampleNumber.strGoodInfo))
        Get
            Return oDelegatStoreMCGoodInfo
        End Get
        Set(value As Func(Of String, List(Of clsSampleNumber.strGoodInfo)))
            oDelegatStoreMCGoodInfo = value
        End Set
    End Property

    ''' <summary>
    ''' возвращает обьект Менеджера МС принимая параметром пользователя и пароль
    ''' </summary>
    ''' <remarks></remarks>
    Private Shared oDelegatStoreMCCreateManager As Func(Of String, String, Object)

    ''' <summary>
    ''' хранит делегат вызова МС Good ("admin@trilbone", "illaenus2012")
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Property DelegatStoreMCCreateManager() As Func(Of String, String, Object)
        Get
            Return oDelegatStoreMCCreateManager
        End Get
        Set(value As Func(Of String, String, Object))
            oDelegatStoreMCCreateManager = value
        End Set
    End Property
    ''' <summary>
    ''' передаем true если требуется инициализация МС (для отладки)
    ''' </summary>
    ''' <remarks></remarks>
    Private Shared oDelegatStoreMCinterface As Func(Of Boolean, iMoySkladDataProvider)

    ''' <summary>
    ''' хранит делегат вызова МС interface. передаем true если требуется инициализация МС (для отладки)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Property DelegatStoreMCinterface() As Func(Of Boolean, iMoySkladDataProvider)
        Get
            Return oDelegatStoreMCinterface
        End Get
        Set(value As Func(Of Boolean, iMoySkladDataProvider))
            oDelegatStoreMCinterface = value
        End Set
    End Property


    Private Shared oDelegatStoreEbayinterface As Func(Of Boolean, ieBayDataProvider)
    ''' <summary>
    ''' хранит делегат вызова  interface. параметр не важен
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Property DelegatStoreEbayinterface() As Func(Of Boolean, Service.ieBayDataProvider)
        Get
            Return oDelegatStoreEbayinterface
        End Get
        Set(value As Func(Of Boolean, Service.ieBayDataProvider))
            oDelegatStoreEbayinterface = value
        End Set
    End Property

#End Region



#Region "Сервис синхронизации: источник fmSampleData"

    Public Delegate Function SynchroSampleDataDboDelegateFunction(ByVal xml As String) As Boolean

    Private Shared oSynchroSampleDataDboDelegate As SynchroSampleDataDboDelegateFunction
    Public Shared Property DelegatStoreSynchroSampleDataDbo As SynchroSampleDataDboDelegateFunction
        Get

            If oSynchroSampleDataDboDelegate Is Nothing Then
                MsgBox("Сервис синхронизации SampleData недоступен.", MsgBoxStyle.Critical)
            End If
            Return oSynchroSampleDataDboDelegate
        End Get
        Set(ByVal value As SynchroSampleDataDboDelegateFunction)
            oSynchroSampleDataDboDelegate = value

        End Set
    End Property

#End Region

#Region "FossilNamesList: источник TreeService"





    ''' <summary>
    ''' выдает список фоссилий в дереве treeName файла  treeFileName (список деревьев можно получить в DelegateStoreTreesNameListFromFile)
    ''' </summary>
    ''' <param name="treeFileName"></param>
    ''' <param name="treeName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Delegate Function TreeFossilNamesDelegateFunction(treeFilePath As String, TreeName As String, culture As Globalization.CultureInfo) As String()
    Private Shared oTreeFossilNamesDelegate As TreeFossilNamesDelegateFunction
    ''' <summary>
    ''' сигнатура (treeFileName As String, ByVal treeName As String) -> выдает список фоссилий
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Property DelegateStoreGetTreeLeafNodeNames As TreeFossilNamesDelegateFunction
        Get
            If oTreeFossilNamesDelegate Is Nothing Then
                MsgBox("Сервис деревьев недоступен.", MsgBoxStyle.Critical)
            End If
            Return oTreeFossilNamesDelegate

        End Get
        Set(ByVal value As TreeFossilNamesDelegateFunction)
            oTreeFossilNamesDelegate = value
        End Set
    End Property
    ''' <summary>
    ''' выдает список деревьев в файле treeFilePath(полный путь). Если аргумент "", то будет вызван диалог открытия файла
    ''' </summary>
    ''' <param name="treeFileName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Delegate Function TreesNameListFromFileDelegateFunction(ByRef treeFilePath As String) As String()
    Private Shared oTreesNameListFromFileDelegate As TreesNameListFromFileDelegateFunction
    ''' <summary>
    ''' сигнатура (treeFilePath (полный путь)) -> выдает список деревьев в файле. Если аргумент "", то будет вызван диалог открытия файла
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Property DelegateStoreGetTreesListFromFile As TreesNameListFromFileDelegateFunction
        Get
            If oTreesNameListFromFileDelegate Is Nothing Then
                MsgBox("Сервис деревьев недоступен.", MsgBoxStyle.Critical)
            End If
            Return oTreesNameListFromFileDelegate

        End Get
        Set(ByVal value As TreesNameListFromFileDelegateFunction)
            oTreesNameListFromFileDelegate = value
        End Set
    End Property

#End Region


    '========================================
    'FossilNamesByTypeDelegateFunction(ByVal typename As String) As Specialized.StringCollection
#Region "Сервис FossilNames: источник FossilData"
    ' ''' <summary>
    ' ''' Сервис запроса списка видов по названию типов фоссилий
    ' ''' </summary>
    ' ''' <param name="typename"></param>
    ' ''' <returns></returns>
    ' ''' <remarks></remarks>
    'Public Delegate Function FossilNamesByTypeDelegateFunction(ByVal typename As String) As String()

    'Private Shared oFossilNamesByTypeDelegate As FossilNamesByTypeDelegateFunction

    'Public Shared Property DelegateStoreFossilNamesByType As FossilNamesByTypeDelegateFunction
    '    Get
    '        Select Case oActiveUser
    '            Case emUsers.Admin
    '                If oFossilNamesByTypeDelegate Is Nothing Then
    '                    MsgBox("Сервис имен фоссилий недоступен.", MsgBoxStyle.Critical)
    '                End If
    '                Return oFossilNamesByTypeDelegate
    '            Case emUsers.PhotoWoker
    '                If oFossilNamesByTypeDelegate Is Nothing Then
    '                    MsgBox("Сервис имен фоссилий недоступен.", MsgBoxStyle.Critical)
    '                End If
    '                Return oFossilNamesByTypeDelegate
    '            Case Else
    '                MsgBox("Сервис имен фоссилий недоступен. Нет прав доступа.", MsgBoxStyle.Critical)
    '                Return Nothing
    '        End Select

    '    End Get
    '    Set(ByVal value As FossilNamesByTypeDelegateFunction)
    '        oFossilNamesByTypeDelegate = value

    '    End Set
    'End Property

    ' ''' <summary>
    ' ''' получает список типов фоссилий
    ' ''' </summary>
    ' ''' <returns></returns>
    ' ''' <remarks></remarks>
    'Public Delegate Function FossilTypesDelegateFunction() As String()

    'Private Shared oFossilTypesDelegate As FossilTypesDelegateFunction

    'Public Shared Property DelegateStoreFossilTypes As FossilTypesDelegateFunction
    '    Get
    '        Select Case oActiveUser
    '            Case emUsers.Admin
    '                If oFossilTypesDelegate Is Nothing Then
    '                    MsgBox("Сервис имен фоссилий недоступен.", MsgBoxStyle.Critical)
    '                End If
    '                Return oFossilTypesDelegate
    '            Case emUsers.PhotoWoker
    '                If oFossilTypesDelegate Is Nothing Then
    '                    MsgBox("Сервис имен фоссилий недоступен.", MsgBoxStyle.Critical)
    '                End If
    '                Return oFossilTypesDelegate
    '            Case Else
    '                MsgBox("Сервис имен фоссилий недоступен. Нет прав доступа.", MsgBoxStyle.Critical)
    '                Return Nothing
    '        End Select

    '    End Get
    '    Set(ByVal value As FossilTypesDelegateFunction)
    '        oFossilTypesDelegate = value

    '    End Set
    'End Property

#End Region


#Region "Регистрация формы как источника для формы списка образцов"
    'Public Sub RegisterFormToSampleListService(fm As Windows.Forms.Form)
    '    If TypeOf fm Is Service.iListSampleDataProvider Then

    '    End If
    'End Sub
#End Region


#Region "Сервис Get Application Form: источники FossilData, Photo_list, Order_and_Client"
    '====================================
    '' fmImage:  Dim _param As Object = {imagetoshow as image, formcaption as string} 
    '' fmPhotoList: Dim _param As Object = {}
    '' fmSampleData: Dim _param As Object = {SampleNumber as decimal}
    '' fmSampleOnSale: Dim _param As Object = {SampleNumber as decimal}
    '' fmClients: Dim _param As Object = {}
    '' fmOrders: Dim _param As Object = {OrderID as string}
    '' fmFossilData: Dim _param As Object = {uriOfDataFile as string}
    '' fmExcelConnect: Dim _param As Object = {}
    '' fmImageManager: Optional Dim _param As Object = {SampleNumber as string, FreePath as string}
    'ApplicationFormDelegateFunction(ByVal formparam As Object) As Windows.Forms.Form

    'для вызова скопируй этот шаблон
    'Private Function CallAnyForm(ByVal formName As emFormsList, ByVal Parameter As Object) As Boolean
    '    Dim _fm As Form

    '    'по запросу выполняем вызов из сервиса
    '    'если делегата нет, то сервис недоступен
    '    If Not Global.Service.clsApplicationTypes.DelegateStoreApplicationForm _
    '        (formName) Is Nothing Then
    '        'сервис зарегестрирован - вызываем
    '        _fm = Global.Service.clsApplicationTypes.DelegateStoreApplicationForm _
    '            (formName).Invoke(Parameter)

    '        If Not _fm Is Nothing Then
    '            _fm.MdiParent = Me
    '            _fm.Show()
    '            Return True
    '        End If


    '    End If
    '    Return False
    'End Function
    '--------------------------------------------
    ''' <summary>
    ''' вернет делегат для пролучения нового номера
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property DelegatStoreGetNewNumber As Func(Of String, String)
        Get
            If oGetNewNumberDelegate Is Nothing Then
                If Not SampleDataObject Is Nothing Then
                    oGetNewNumberDelegate = (AddressOf SampleDataObject.GetNewNumberBySeries)
                End If
            End If
            Return oGetNewNumberDelegate
        End Get
    End Property

    Private Shared oGetNewNumberDelegate As Func(Of String, String)



    '------------------------------

    ''' <summary>
    ''' вернет делегат для проверки наличия фото на архивном носителе. 1 - есть; 0 - нет; -1 - нет доступа к БД; -2 - ошибка номера образца
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property DelegatStoreCheckImages As Func(Of String, Integer)
        Get
            If oHasImagesDelegate Is Nothing Then
                If Not SamplePhotoObject Is Nothing Then
                    oHasImagesDelegate = (AddressOf ChekImagesInArhive)
                End If
            End If
            Return oHasImagesDelegate
        End Get
    End Property
    ''' <summary>
    ''' проверит наличие фото в архиве. 1 - есть; 0 - нет; -1 - нет доступа к БД; -2 - ошибка номера образца
    ''' </summary>
    ''' <param name="shotnumber"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function ChekImagesInArhive(shotnumber As String) As Integer
        Dim _num = clsSampleNumber.CreateFromString(shotnumber)
        If SamplePhotoObject Is Nothing Then Return -1
        If _num.CodeIsCorrect Then
            If SamplePhotoObject.HasImages(_num, clsFilesSources.Arhive) Then
                Return 1
            Else
                Return 0
            End If
        End If
        Return -2
    End Function

    Private Shared oHasImagesDelegate As Func(Of String, Integer)
    '--------------------

    Public Delegate Function ApplicationFormDelegateFunction(ByVal formparam As Object) As Windows.Forms.Form

    Private Shared oApplicationFormDelegateCollection As Generic.SortedList(Of emFormsList, ApplicationFormDelegateFunction)
    ''' <summary>
    ''' поставляет делегат для получения формы
    ''' </summary>
    ''' <param name="FormName"></param>
    ''' <value>имя формы</value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Property DelegateStoreApplicationForm(ByVal FormName As emFormsList) As ApplicationFormDelegateFunction
        Get
            'общие формы
            Select Case GetAccess("Доступ к заказам")
                Case True
                    GoTo ReturnForm
                Case False
                    Select Case FormName
                        Case emFormsList.fmClients
                            MsgBox("Сервис формы 'Клиенты' недоступен. Нет прав доступа.", MsgBoxStyle.Critical)
                            Return Nothing
                        Case emFormsList.fmOrders
                            MsgBox("Сервис формы 'Заказы' недоступен. Нет прав доступа.", MsgBoxStyle.Critical)
                            Return Nothing
                        Case emFormsList.fmSampleOnSale
                            MsgBox("Сервис формы 'SampleOnSale' недоступен. Нет прав доступа.", MsgBoxStyle.Critical)
                            Return Nothing
                    End Select

                Case Else
                    MsgBox("Сервис клиентских форм недоступен. Нет прав доступа.", MsgBoxStyle.Critical)
                    Return Nothing
            End Select


ReturnForm:

            If Not oApplicationFormDelegateCollection.ContainsKey(FormName) OrElse oApplicationFormDelegateCollection(FormName) Is Nothing Then
                MsgBox("Сервис получения формы " & [Enum].GetName(GetType(emFormsList), FormName) &
                       " недоступен", MsgBoxStyle.Critical)
                Return Nothing
            Else
                Return oApplicationFormDelegateCollection(FormName)
            End If


        End Get

        Set(ByVal value As ApplicationFormDelegateFunction)
            If oApplicationFormDelegateCollection Is Nothing Then
                oApplicationFormDelegateCollection = New Generic.SortedList(Of emFormsList, ApplicationFormDelegateFunction)
            End If

            oApplicationFormDelegateCollection.Add(FormName, value)

        End Set
    End Property

#End Region


#Region "Сервис Add Sample In Order: источник Order_and_Client"
    Public Delegate Function AddSampleInOrderDelegateFunction _
        (ByVal OrderID As String, ByVal SampleNumber As Decimal, ByVal FileNames As String(), ByVal OptimizeImageWidth As Integer) As Boolean

    Private Shared oAddSampleInOrderDelegate As AddSampleInOrderDelegateFunction

    ''' <summary>
    ''' обьект культуры Русский
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property RussianCulture As Globalization.CultureInfo
        Get
            Return Globalization.CultureInfo.CreateSpecificCulture("ru-RU")
        End Get
    End Property

    ''' <summary>
    ''' обьект культуры по умолчанию (Английский)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property EnglishCulture As Globalization.CultureInfo
        Get
            Return Globalization.CultureInfo.CreateSpecificCulture("en-US")
        End Get
    End Property

    Public Shared Property DelegateStoreAddSampleToOrder As AddSampleInOrderDelegateFunction
        Get
            Select Case GetAccess("Доступ к заказам")
                Case True
                    If oAddSampleInOrderDelegate Is Nothing Then
                        MsgBox("Сервис OnSale образцов недоступен.", MsgBoxStyle.Critical)
                    End If
                    Return oAddSampleInOrderDelegate
                Case False
                    MsgBox("Сервис OnSale образцов недоступен. Нет прав доступа.", MsgBoxStyle.Critical)
                    Return Nothing
                Case Else
                    MsgBox("Сервис OnSale образцов недоступен. Нет прав доступа.", MsgBoxStyle.Critical)
                    Return Nothing
            End Select

        End Get
        Set(ByVal value As AddSampleInOrderDelegateFunction)
            oAddSampleInOrderDelegate = value

        End Set
    End Property

#End Region


#Region "сервис добавления данных образца в БД: источник OrderService.AddSampleOnSale"
    '    Public Shared Function AddSampleOnSale(parameters As Object) As Integer
    ' <summary>
    ' записывает в БД инфо об образце, принимая строгую структуру данных
    ' </summary>
    ' <param name="parameters">номер(decimal), начальная цена(decimal)</param>
    ' <returns>-3: ошибка в переданной структуре, -2: образец уже есть в базе, -1: переданных данных недостаточно для записи в БД, 0: некорректный номер, 1 и более: успешно добавлено </returns>

    Public Delegate Function AddSampleOnSaleIntoDBDelegateFunction(Sample_parameter As Object) As Integer
    Private Shared oAddSampleOnSaleIntoDBDelegate As AddSampleOnSaleIntoDBDelegateFunction
    Public Shared Property DelegateStoreAddSampleOnSaleIntoDB As AddSampleOnSaleIntoDBDelegateFunction
        Get
            If oAddSampleOnSaleIntoDBDelegate Is Nothing Then
                MsgBox("Сервис добавления данных образцов недоступен.", MsgBoxStyle.Critical)
            End If
            Return oAddSampleOnSaleIntoDBDelegate
        End Get
        Set(ByVal value As AddSampleOnSaleIntoDBDelegateFunction)
            oAddSampleOnSaleIntoDBDelegate = value

        End Set
    End Property


#End Region

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="shotCode">SKU</param>
    ''' <param name="serverName">сервер Nop из файла агентов</param>
    ''' <param name="serviceName">имя сервиса в плагине (который есть SKU), любого))</param>
    ''' <param name="serverMessage"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Delegate Function RemoveSampleOnSiteDelegateFunction _
      (shotCode As String, serverName As String, serviceName As String, ByRef serverMessage As String) As HttpStatusCode
    Private Shared oRemoveSampleOnSiteDelegateFunction As RemoveSampleOnSiteDelegateFunction
    Public Shared Property DelegateStoreRemoveSampleOnSite As RemoveSampleOnSiteDelegateFunction
        Get
            If oAddSampleInOrderDelegate Is Nothing Then
                MsgBox("Сервис добавления данных образцов недоступен.", MsgBoxStyle.Critical)
            End If
            Return oRemoveSampleOnSiteDelegateFunction
        End Get
        Set(ByVal value As RemoveSampleOnSiteDelegateFunction)
            oRemoveSampleOnSiteDelegateFunction = value
        End Set
    End Property

    Public Delegate Function GetTransformDelegateFunction _
     (ByRef XMLData As String, TemplateType As emTemplateType, TemplateName As String) As String
    Private Shared oGetTransformDelegateFunction As GetTransformDelegateFunction
    Public Shared Property DelegateStoreGetTransform As GetTransformDelegateFunction
        Get
            If oAddSampleInOrderDelegate Is Nothing Then
                MsgBox("Сервис получения преобразования шаблона не доступен.", MsgBoxStyle.Critical)
            End If
            Return oGetTransformDelegateFunction
        End Get
        Set(ByVal value As GetTransformDelegateFunction)
            oGetTransformDelegateFunction = value
        End Set
    End Property

    'Function AddSampleInfo(ByVal Sample_parameter As Object, ByVal fossil_parameter As Object) As Integer
    '<param name="Sample_parameter">номер,основное название, длина, ширина, ВЫСОТА, вес в кг, исходная дата записи</param>
    '<param name="fossil_parameter">имена(), длины(), ширины()</param>
    '<returns>-3: ошибка в переданной структуре, -2: образец уже есть в базе, -1: переданных данных недостаточно для записи в БД, 0: некорректный номер, 1 и более: успешно добавлено </returns>
#Region "сервис добавления данных образца в БД: источник PotoService.AddSampleInfo"
    Public Delegate Function AddSampleDataIntoDBDelegateFunction _
       (ByVal Sample_parameter As Object, ByVal fossil_parameter As Object) As Integer

    Private Shared oAddSampleDataIntoDBDelegate As AddSampleDataIntoDBDelegateFunction

    Public Shared Property DelegateStoreAddSampleDataIntoDB As AddSampleDataIntoDBDelegateFunction
        Get
            If oAddSampleInOrderDelegate Is Nothing Then
                MsgBox("Сервис добавления данных образцов недоступен.", MsgBoxStyle.Critical)
            End If
            Return oAddSampleDataIntoDBDelegate

        End Get
        Set(ByVal value As AddSampleDataIntoDBDelegateFunction)
            oAddSampleDataIntoDBDelegate = value

        End Set
    End Property
#End Region


    '=============================
    'OnSaleSampleListDelegateFunction() As String()
#Region "Сервис OnSale образцов: источник Order_and_Client"
    Public Delegate Function OnSaleSampleListDelegateFunction() As String()

    Private Shared oOnSaleSampleListDelegate As OnSaleSampleListDelegateFunction

    Public Shared Property DelegateStoreOnSaleSampleList As OnSaleSampleListDelegateFunction
        Get
            If oOnSaleSampleListDelegate Is Nothing Then
                MsgBox("Сервис OnSale образцов недоступен.", MsgBoxStyle.Critical)
            End If
            Return oOnSaleSampleListDelegate

        End Get
        Set(ByVal value As OnSaleSampleListDelegateFunction)
            oOnSaleSampleListDelegate = value

        End Set
    End Property

#End Region


    '========================
    ' OrdersListDelegateFunction() As Collections.Generic.List(Of Order)
#Region "Сервис список заказов: источник Order_and_Client"
    ''' <summary>
    ''' делегат информация об образце  из сервиса Order_and_Client в текстовом виде
    ''' </summary>
    ''' <param name="SampleNumber"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Delegate Function GetSampleInfoTextDelegateFunction(ByVal SampleNumber As clsSampleNumber, culture As System.Globalization.CultureInfo, ByRef _status As Integer) As String
    Private Shared oGetSampleInfoTextDelegate As GetSampleInfoTextDelegateFunction

    ''' <summary>
    ''' свойство хранения делегата: текстовая инфо об образце. _status: (-1) - ошибка, (0) - данных нет, (1) - данные есть, (2) - данные есть полные
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Property DelegateStoreGetSampleInfoText As GetSampleInfoTextDelegateFunction
        Get
            Select Case GetAccess("Доступ к заказам")
                Case True
                    If oGetSampleInfoTextDelegate Is Nothing Then
                        MsgBox("Сервис информация об образце недоступен", MsgBoxStyle.Critical)
                    End If
                    Return oGetSampleInfoTextDelegate
                Case False
                    If oGetSampleInfoTextDelegate Is Nothing Then
                        MsgBox("Сервис информация об образце недоступен", MsgBoxStyle.Critical)
                    End If
                    Return oGetSampleInfoTextDelegate
                Case Else
                    MsgBox("Сервис информация об образце недоступен. Нет прав доступа.", MsgBoxStyle.Critical)
                    Return Nothing
            End Select


        End Get
        Set(ByVal value As GetSampleInfoTextDelegateFunction)
            oGetSampleInfoTextDelegate = value

        End Set
    End Property


    'Private Shared Function GetSampleInfoTransformed(SampleNumber As clsSampleNumber, TemplateName As String, ByRef _status As Integer, Optional source As clsFilesSources = Nothing) As String
    ''' <summary>
    ''' сервис получения преобразованной строки описания образца по заданному шаблону с ссылками на заданное устройство
    ''' </summary>
    ''' <param name="SampleNumber"></param>
    ''' <param name="TemplateName"></param>
    ''' <param name="_status"></param>
    ''' <param name="ImagesSource"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Delegate Function GetSampleInfoTransformedDelegateFunction(SampleNumber As clsSampleNumber, TemplateName As String, ByRef _status As Integer, ImagesSource As clsFilesSources, ImageNamesFilter As String(), culture As System.Globalization.CultureInfo, NeedMapping As Boolean) As String
    Private Shared oGetSampleInfoTransformedDelegate As GetSampleInfoTransformedDelegateFunction

    ''' <summary>
    ''' сервис получения преобразованной строки описания образца по заданному шаблону с ссылками на заданное устройство
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Property DelegateStoreGetSampleInfoTransformed As GetSampleInfoTransformedDelegateFunction
        Get
            If oGetSampleInfoTransformedDelegate Is Nothing Then
                MsgBox("Сервис получения преобразованной строки описания образца недоступен", MsgBoxStyle.Critical)
            End If
            Return oGetSampleInfoTransformedDelegate

        End Get
        Set(ByVal value As GetSampleInfoTransformedDelegateFunction)
            oGetSampleInfoTransformedDelegate = value

        End Set
    End Property

    ''' <summary>
    ''' сервис получения списка шаблонов преобразования. Вернет имя шаблона.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Delegate Function GetTemplatesListDelegateFunction() As String()
    Private Shared oGetTemplatesListDelegate As GetTemplatesListDelegateFunction
    ''' <summary>
    ''' свойство хранения делегата: список шаблонов преобразования. Вернет имя шаблона.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Property DelegateStoreGetTemplatesList As GetTemplatesListDelegateFunction
        Get
            If oGetTemplatesListDelegate Is Nothing Then
                MsgBox("Сервис список шаблонов преобразования недоступен", MsgBoxStyle.Critical)
            End If
            Return oGetTemplatesListDelegate


        End Get
        Set(ByVal value As GetTemplatesListDelegateFunction)
            oGetTemplatesListDelegate = value

        End Set
    End Property
    ''' <summary>
    ''' сервис получения номеров образцов из заказа МС. Номер неверен - вернет пустой список
    ''' </summary>
    ''' <param name="MoySkladOrderNumber"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Delegate Function GetSampleListFromMSDelegateFunction(MoySkladOrderNumber As String, ByRef CustomerName As String) As List(Of clsSampleNumber)
    Private Shared oGetSampleListFromMSDelegate As GetSampleListFromMSDelegateFunction
    Public Shared Property DelegateStoreGetSampleListFromMS As GetSampleListFromMSDelegateFunction
        Get
            If oGetSampleListFromMSDelegate Is Nothing Then
                MsgBox("Сервис МС недоступен", MsgBoxStyle.Critical)
            End If
            Return oGetSampleListFromMSDelegate


        End Get
        Set(ByVal value As GetSampleListFromMSDelegateFunction)
            oGetSampleListFromMSDelegate = value
        End Set
    End Property


    ''' <summary>
    ''' сервис занесения аукционных образцов в соответствующую отгрузку
    ''' </summary>
    ''' <param name="MoySkladOrderNumber"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Delegate Function SetSampleToDemandMSDelegateFunction(ShotNumber As String, AgentName As String, AgentAccount As String, FeeAmount As Decimal, ItemFirstPrice As Decimal) As Integer
    Private Shared oSetSampleToDemandMSDelegate As SetSampleToDemandMSDelegateFunction
    Public Shared Property DelegateStoreSetSampleToDemandMS As SetSampleToDemandMSDelegateFunction
        Get
            If oGetSampleListFromMSDelegate Is Nothing Then
                MsgBox("Сервис МС недоступен", MsgBoxStyle.Critical)
            End If
            Return oSetSampleToDemandMSDelegate


        End Get
        Set(ByVal value As SetSampleToDemandMSDelegateFunction)
            oSetSampleToDemandMSDelegate = value
        End Set
    End Property






    ''' <summary>
    ''' делегат список заказов  из сервиса Order_and_Client
    ''' </summary>
    Public Delegate Function OrdersListDelegateFunction() As Collections.Generic.List(Of clsOrder)


    Private Shared oOrdersListDelegate As OrdersListDelegateFunction
    ''' <summary>
    ''' свойство хранения делегата
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Property DelegateStoreOrdersList As OrdersListDelegateFunction
        Get
            Select Case GetAccess("Доступ к заказам")
                Case True
                    If oOrdersListDelegate Is Nothing Then
                        MsgBox("Сервис заказов недоступен", MsgBoxStyle.Critical)
                    End If
                    Return oOrdersListDelegate
                Case False
                    MsgBox("Сервис заказов недоступен. Нет прав доступа.", MsgBoxStyle.Critical)
                    Return Nothing
                Case Else
                    MsgBox("Сервис заказов недоступен. Нет прав доступа.", MsgBoxStyle.Critical)
                    Return Nothing
            End Select


        End Get
        Set(ByVal value As OrdersListDelegateFunction)
            oOrdersListDelegate = value

        End Set
    End Property

#End Region

#Region "Сервис список не закрытых заказов: источник Order_and_Client"



    ''' <summary>
    ''' делегат список заказов  из сервиса Order_and_Client
    ''' </summary>
    Public Delegate Function OrdersNonClosedListDelegateFunction() As Collections.Generic.List(Of clsOrder)


    Private Shared oOrdersNonClosedListDelegate As OrdersNonClosedListDelegateFunction
    ''' <summary>
    ''' свойство хранения делегата
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Property DelegateStoreOrdersNonClosedList As OrdersNonClosedListDelegateFunction
        Get
            Select Case GetAccess("Доступ к заказам")
                Case True
                    If oOrdersListDelegate Is Nothing Then
                        MsgBox("Сервис заказов недоступен", MsgBoxStyle.Critical)
                    End If
                    Return oOrdersNonClosedListDelegate
                Case False
                    MsgBox("Сервис заказов недоступен. Нет прав доступа.", MsgBoxStyle.Critical)
                    Return Nothing
                Case Else
                    MsgBox("Сервис заказов недоступен. Нет прав доступа.", MsgBoxStyle.Critical)
                    Return Nothing
            End Select


        End Get
        Set(ByVal value As OrdersNonClosedListDelegateFunction)
            oOrdersNonClosedListDelegate = value

        End Set
    End Property

#End Region


#Region "собственные сервисные функции"

    ' ''' <summary>
    ' ''' возвращает строку с данными товара по номеру из МС/ status (-1) - error, (0) - data of sample is abscent, (1) - data present, (2) - full data present
    ' ''' </summary>
    ' ''' <returns></returns>
    ' ''' <remarks></remarks>
    'Public Shared Function GetGoodInfo(SampleNumber As clsApplicationTypes.clsSampleNumber, ByRef _status As Integer) As clsSampleNumber.strGoodInfo


    'End Function





    ''' <summary>
    ''' создаст папку на DestinationSource, запишет фото. При указании TemplateName оптимизация фото будет взята из шаблона (ImageWidth). Вернет кол-во скопир фото или код ошибки (меньше ноля)
    ''' </summary>
    ''' <param name="SampleNumber"></param>
    ''' <param name="DestinationSource">куда пишем файлы</param>
    ''' <param name="ImageNameCollection"></param>
    ''' <param name="TemplateName">При указании TemplateName оптимизация фото будет взята из шаблона. (ImageWidth)</param>
    ''' <param name="ReplaceAllImages">перезапишет все фото на новые</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CreateFolderForSampleWithImages(SampleNumber As clsSampleNumber, DestinationSource As clsFilesSources, Optional ImageNameCollection As List(Of String) = Nothing, Optional TemplateImageWidth As Integer = 1600, Optional ReplaceAllImages As Boolean = False, Optional TemplateNeedSmallFolder As Boolean = False) As Integer
        'проверить наличие этих фото на устройстве
        'фото на устройстве-ссылке
        Dim _onSource = (From c In Service.clsApplicationTypes.SamplePhotoObject.GetImageNamesList(SampleNumber, DestinationSource) Select c).ToList
        Dim _except() As String = Nothing

        If ImageNameCollection Is Nothing Then
            _except = Nothing
        Else
            If ReplaceAllImages Then
                'заменить все
                _except = ImageNameCollection.ToArray
            Else
                'найти разность множеств
                _except = ImageNameCollection.Except(_onSource).ToArray
            End If
        End If

        If (_except Is Nothing) OrElse (_except.Count > 0) Then
            'копируем недостающие фото
            Dim _status1 As Integer

            Dim _res = clsApplicationTypes.SamplePhotoObject.CreateSampleImagesContainerOnSource(SampleNumber, DestinationSource, _status1, , , _except, TemplateImageWidth, TemplateNeedSmallFolder)

            Select Case _status1
                Case Is > 0
                    Dim _text = DestinationSource.ContainerPath
                    If _text = "" Then _text = DestinationSource.ToString
                    ' MsgBox("Недостающие " & _status1 & " фото скопированы в " & _text, MsgBoxStyle.Information)
                Case 0
                    MsgBox("Все фото есть на получателе, либо отсутствуют также и на источнике.", MsgBoxStyle.Critical)
                Case -1
                    MsgBox("Фото не скопированы. Ошибка устройства.", MsgBoxStyle.Critical)
                Case -2
                    MsgBox("Фото не скопированы. Ошибка параметров вызова функции.", MsgBoxStyle.Critical)
                Case -3
                    MsgBox("Фото не скопированы. Ошибка интерфейса iSource.", MsgBoxStyle.Critical)
            End Select
            Return _status1
        Else
            Return 0
        End If
    End Function


    ''' <summary>
    '''  создаст папку на DestinationSource, запишет файл. При указании пустого шаблона запишет xml. При указании шаблона запишет HTML. Файл будет перезаписан. DestinationHTMLFileLink будет содержать данные о пути записанного файла/ при указании флага SetLinkToPhotoInArhive ссылки будут на фотки архива.
    ''' </summary>
    ''' <param name="SampleNumber">номер образца</param>
    ''' <param name="DestinationSource">куда пишем файлы</param>
    ''' <param name="ImageNameCollection">список имен изображений для добавления/проверки наличия на LinkedImagesSource. Nothing если копируем все с Arhive</param>
    ''' <param name="TemplateName">имя используемого шаблона, если пусто - то будет прописан XML файл</param>
    ''' <param name="Culture">культура вывода</param>
    ''' <param name="CreateText">если флаг задан, то пишем текстовй файл, иначе по шаблону генерим HTML</param>
    ''' <param name="DestinationHTMLFileLink">ссылка на созданный файл (текст или HTML или XML)</param>
    ''' <returns></returns>
    ''' <remarks>DestinationSource и LinkedImagesSource могут совпадать</remarks>
    Public Shared Function CreateFolderForSampleWithDataFile(SampleNumber As clsSampleNumber, DestinationSource As clsFilesSources, Optional ImageNameCollection As List(Of String) = Nothing, Optional TemplateName As String = "", Optional Culture As System.Globalization.CultureInfo = Nothing, Optional CreateText As Boolean = False, Optional ByRef DestinationHTMLFileLink As String = "", Optional SetLinkToPhotoInArhive As Boolean = False) As Boolean
        If DestinationSource Is Nothing Then Return False

        If TemplateName Is Nothing Then TemplateName = ""

        'english
        If Culture Is Nothing Then
            Culture = clsApplicationTypes.EnglishCulture
        End If
        '----------------------------------------


        '---------------------------------------------
        'работа с строкой данных (Требует культуру)
        Dim _status As Integer = 0
        Dim _textextention As String = ""
        Dim _Data As String = ""
        '---------------------
        Select Case CreateText
            Case False
                'генерим HTML и XML
                'получить трансформацию по выбранному шаблону
                If Not clsApplicationTypes.DelegateStoreGetSampleInfoTransformed Is Nothing Then
                    Dim _imgSours = clsFilesSources.Arhive
                    If SetLinkToPhotoInArhive = False Then
                        _imgSours = DestinationSource
                    End If

                    Dim _arrName As String() = Nothing
                    If Not ImageNameCollection Is Nothing Then
                        _arrName = ImageNameCollection.ToArray
                    End If

                    'тут далее идет речь про ссылки в XML
                    'сервис зарегестрирован - вызываем
                    _Data = clsApplicationTypes.DelegateStoreGetSampleInfoTransformed.Invoke(SampleNumber, TemplateName, _status, _imgSours, _arrName, Culture, False)
                End If
                'пишем HTML или XML
                If TemplateName = "" Then
                    _textextention = "xml"
                Else
                    _textextention = "html"
                End If
                '---------------
            Case True
                'сгенерить текстовую строку
                'использование сервисов
                'выполняем вызов из сервиса
                'если делегата нет, то сервис недоступен
                If Not Global.Service.clsApplicationTypes.DelegateStoreGetSampleInfoText Is Nothing Then
                    'сервис зарегестрирован - вызываем 
                    _Data = Global.Service.clsApplicationTypes.DelegateStoreGetSampleInfoText.Invoke(SampleNumber, Culture, _status)
                End If
                _textextention = "txt"
        End Select

        '---------------------
        ''пишем файл
        If _status > 0 AndAlso Not (_Data = "") Then
            'create file на текущем усторйстве DestinationSource 
            Select Case DestinationSource.Source
                Case clsFilesSources.emSources.Arhive, clsFilesSources.emSources.AZURE, clsFilesSources.emSources.SpecificOrder
                    'создать файл данных во временной директ
                    Dim _tmppath = IO.Path.GetTempPath
                    Dim _tmpsource = clsFilesSources.CreateInstance(clsFilesSources.emSources.FreeFolder, , , _tmppath, True)
                    Service.clsApplicationTypes.SamplePhotoObject.WriteSampleInfoToFile(_tmpsource, SampleNumber, _Data, _textextention)
                    DestinationHTMLFileLink = IO.Path.Combine(_tmpsource.ContainerPath, SampleNumber.ShotCode & "." & _textextention)
                    Return True
                Case clsFilesSources.emSources.FreeFolder
                    Service.clsApplicationTypes.SamplePhotoObject.WriteSampleInfoToFile(DestinationSource, SampleNumber, _Data, _textextention)
                    DestinationHTMLFileLink = IO.Path.Combine(DestinationSource.ContainerPath, SampleNumber.ShotCode & "." & _textextention)
                    Return True

                Case clsFilesSources.emSources.AllSources
                    'создать файл данных во временной директ
                    Dim _tmppath = IO.Path.GetTempPath
                    Dim _tmpsource = clsFilesSources.CreateInstance(clsFilesSources.emSources.FreeFolder, , , _tmppath, True)
                    Service.clsApplicationTypes.SamplePhotoObject.WriteSampleInfoToFile(_tmpsource, SampleNumber, _Data, _textextention)
                    DestinationHTMLFileLink = IO.Path.Combine(_tmpsource.ContainerPath, SampleNumber.ShotCode & "." & _textextention)
                    Return False

            End Select


        Else
            MsgBox("Ошибка при копировании файлов", MsgBoxStyle.Critical)
        End If
ex:

        Return False
    End Function



    ''' <summary>
    ''' округлитель цены до конечных нулей (zerous) --> 151.23=150 при zerous=1.  zerous=-1 = умное округление
    ''' </summary>
    ''' <param name="price"></param>
    ''' <param name="digits"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function RoundPrice(price As Decimal, Optional zerous As Integer = -1) As Decimal
        Dim _tmp As Decimal

        If zerous = -2 Then
            Return Decimal.Round(price, 1)
        End If

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





    ''' <summary>
    ''' вернет строку полного названия образца из списка названий по стд. алгоритму
    ''' </summary>
    ''' <param name="names"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function FossilNamesParser(names As String()) As String
        'вернет список фоссилий через запятую, у всех, кроме первой инфа в скобках будет убрана.
        Dim _out As String = ""

        For Each t In names
            If Not _out = "" Then
                _out += ", "
            End If
            _out += clsApplicationTypes.RejectSkobki(t)
        Next

        Return _out
    End Function





    ''' <summary>
    ''' хранит курс валют для текущего сеанса Где используется??? Только в заказах???
    ''' </summary>
    ''' <param name="currency"></param>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Property CurrencyRateNow(ByVal currency As Object) As Decimal

        Get
            If (Not currency Is Nothing) AndAlso (Not oCurrencyRateNow Is Nothing) AndAlso
                (currency.GetType Is GetType(String)) AndAlso (CType(currency, String).Length > 2) Then
                If oCurrencyRateNow.ContainsKey([Enum].Parse(GetType(emCurrencyList), currency)) Then
                    Return oCurrencyRateNow([Enum].Parse(GetType(emCurrencyList), currency))
                Else
                    Return 1
                End If
            Else
                Return 1
            End If
        End Get

        Set(ByVal value As Decimal)

            If (Not currency Is Nothing) AndAlso (currency.GetType Is GetType(String)) AndAlso (CType(currency, String).Length > 2) Then
                If oCurrencyRateNow Is Nothing Then
                    oCurrencyRateNow = New Generic.Dictionary(Of emCurrencyList, Decimal)
                End If
                ''проверка наличия ключа
                If Not oCurrencyRateNow.ContainsKey([Enum].Parse(GetType(emCurrencyList), currency)) Then
                    ''ключа нет, добавить значение
                    oCurrencyRateNow.Add([Enum].Parse(GetType(emCurrencyList), currency), value)

                Else
                    ''ключ есть, изменить значение
                    oCurrencyRateNow.Item([Enum].Parse(GetType(emCurrencyList), currency)) = value

                End If



            End If
        End Set
    End Property
    Private Shared oMaterialDictionary As New Dictionary(Of String, String())
    ''' <summary>
    ''' текущий список имен для БД в виде ключ=имя_материала   значение=массив_имен
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property CurrentNamesList As Dictionary(Of String, String())
        Get
            Return oMaterialDictionary
        End Get
    End Property

    ''' <summary>
    ''' все имена из загруженных списков имен
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property AllCurrentNames As String()
        Get
            Dim _out As New List(Of String)

            For Each c In oMaterialDictionary
                _out.AddRange(c.Value)
            Next
            Return _out.ToArray
        End Get
    End Property

    ''' <summary>
    ''' текущее устройство хранения данных
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property DataStoreSource As emStoreSourses
        Get
            Return (emStoreSourses.dbo)
            'Select Case oActiveUser
            '    Case emUsers.Admin
            '        MsgBox("Связь с основной БД", vbInformation)
            '        Return (emStoreSourses.dbo)
            '    Case emUsers.PhotoWoker
            '        MsgBox("Связь с xml БД", vbInformation)
            '        Return emStoreSourses.xml
            '    Case Else
            '        Return emStoreSourses.xml
            'End Select
        End Get
    End Property
    ' ''' <summary>
    ' ''' текущий пользователь
    ' ''' </summary>
    ' ''' <value></value>
    ' ''' <returns></returns>
    ' ''' <remarks></remarks>
    'Public Shared ReadOnly Property ActiveUser As emUsers
    '    Get
    '        Return oActiveUser
    '    End Get
    'End Property

    ''' <summary>
    ''' получает разрешение доступа пользователя к ресурсу по названию ресурса
    ''' </summary>
    ''' <param name="clusterName"></param>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property GetAccess(ResourceName As String) As Boolean
        Get
            If CurrentUser Is Nothing Then Return False
            Return CurrentUser.UserPermission.GetAccess(ResourceName)
        End Get
    End Property

    Private Shared Sub backgroundWorkerEbay_DoWork(ByVal sender As System.Object,
  ByVal e As DoWorkEventArgs)
#If DEBUG Then
        e.Result = clsFindingService.WordsProceessing()
#Else
 Try
            e.Result = clsFindingService.WordsProceessing()
        Catch ex As Exception
            'проблемы с подключением


        End Try
#End If


    End Sub

    Private Shared Sub backgroundWorkereBAy_RunWorkerCompleted(ByVal sender As System.Object,
    ByVal e As RunWorkerCompletedEventArgs)
        If e.Error Is Nothing Then
            If e.Result > 0 Then
                BeepYES()
            End If
        Else
            BeepNOT()
#If DEBUG Then
            MsgBox("Возникла ошибка при запросе eBAY", vbInformation)
#End If
        End If
    End Sub


    ' Private Shared Sub backgroundWorkerCurrency_DoWork(ByVal sender As System.Object, _
    'ByVal e As DoWorkEventArgs)
    '     oCBRateReady = -1
    '     Try
    '         oXMLRateCB = XElement.Load("http://www.cbr.ru/scripts/XML_daily.asp")
    '     Catch ex As Exception
    '         oCBRateReady = -2
    '         MsgBox("Возникла ошибка при запросе курсов валют, будут использованы из установок приложения", vbInformation)
    '     End Try

    ' End Sub

    ' Private Shared Sub backgroundWorkerCurrency_RunWorkerCompleted(ByVal sender As System.Object, _
    ' ByVal e As RunWorkerCompletedEventArgs)
    '     If e.Error Is Nothing Then
    '         oCBRateReady = 1
    '     Else
    '         oCBRateReady = -2
    '         MsgBox("Возникла ошибка при запросе курсов валют, будут использованы из установок приложения", vbInformation)
    '     End If
    ' End Sub

    Private Shared oXMLRateCB As XElement
    ''' <summary>
    ''' 0 - небыло запроса -1 в процессе >0 готово  -2 ошибка запроса
    ''' </summary>
    ''' <remarks></remarks>
    Private Shared oCBRateReady As Integer = 0


    ''' <summary>
    ''' функция конвертации суммы из валюты в валюту
    ''' </summary>
    ''' <param name="InCurrencyUUID">из валюты</param>
    ''' <param name="OutCurrencyUUID">в валюту</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CurrencyConvert(InAmount As Decimal, InCurrencyID As String, OutCurrencyID As String, Optional Decimals As Integer = 2) As Decimal
        If String.IsNullOrEmpty(InCurrencyID) Then Return InAmount
        If String.IsNullOrEmpty(OutCurrencyID) Then Return InAmount
        'в рубли по ЦБ
        Dim _inrate = clsApplicationTypes.GetRateByCurrencyCB103(InCurrencyID)
        Dim _outrate = clsApplicationTypes.GetRateByCurrencyCB103(OutCurrencyID)
        Dim _inrur = _inrate * InAmount
        'защита
        If _outrate = 0 Then
            MsgBox("Курс " & OutCurrencyID & " установлен неверно. Проверте результат конвертации из " & InCurrencyID & " вручную.", vbCritical)
            _outrate = 1
        End If
        'умное округление
        Select Case _inrur / _outrate
            Case < 3
                Decimals = 2
            Case < 5
                If Decimals < 1 Then
                    Decimals = 1
                End If
            Case < 10
                If Decimals < 1 Then
                    Decimals = 1
                End If
        End Select

        Return Math.Round(_inrur / _outrate, Decimals)

    End Function


    ''' <summary>
    ''' вернет текущий курс ЦБ по валюте +3% или ничего
    ''' </summary>
    ''' <param name="CurrencyID"></param>
    ''' <param name="_actual">курсы актуальные, обновленные</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetRateByCurrencyCB103(CurrencyID As String, Optional ByRef _actual As Boolean = False) As Decimal

        Select Case oCBRateReady
            Case 0
                'запиустить запрос курса
                Dim _woker As New BackgroundWorker
                Dim _do = Sub(sender As System.Object, e As DoWorkEventArgs)
                              oCBRateReady = -1
                              Try
                                  oXMLRateCB = XElement.Load("http://www.cbr.ru/scripts/XML_daily.asp")
                              Catch ex As Exception
                                  oCBRateReady = -2
                                  MsgBox("Возникла ошибка при запросе курсов валют, будут использованы из установок приложения", vbInformation)
                              End Try
                          End Sub

                Dim _complete = Sub(sender As System.Object, e As RunWorkerCompletedEventArgs)
                                    If e.Error Is Nothing Then
                                        oCBRateReady = 1
                                    Else
                                        oCBRateReady = -2
                                        MsgBox("Возникла ошибка при запросе курсов валют, будут использованы из установок приложения", vbInformation)
                                    End If
                                End Sub

                'AddHandler _woker.DoWork, AddressOf backgroundWorkerCurrency_DoWork
                'AddHandler _woker.RunWorkerCompleted, AddressOf backgroundWorkerCurrency_RunWorkerCompleted
                AddHandler _woker.DoWork, _do
                AddHandler _woker.RunWorkerCompleted, _complete
                _woker.RunWorkerAsync()
                oCBRateReady = -1

            Case -1
                'в процессе получения


            Case Else
                'получен
                If oXMLRateCB Is Nothing Then Exit Select

                Dim _curr = (From c In oXMLRateCB...<Valute> Where c...<CharCode>.Value = CurrencyID Select c...<Value>.Value).FirstOrDefault

                If _curr Is Nothing Then _actual = False : Return 1

                Dim _currd As Decimal = 0
                If Not Decimal.TryParse(ReplaceDecimalSplitter(_curr), _currd) Then
                    _actual = False
                    Return 1
                End If
                If _currd = 0 Then _actual = False : Return 1

                _actual = True
                Dim _cv = Math.Round(_curr + _curr * 0.03, 2)

                'запомнить курсы валют
                Select Case CurrencyID

                    Case "USD"
                        If Not My.Settings.RateUSD = _cv Then

                            My.Settings.RateUSD = _cv
                            My.Settings.Save()

                        End If
                    Case "EUR"

                        If Not My.Settings.RateEUR = _cv Then
                            My.Settings.RateEUR = _cv
                            My.Settings.Save()
                        End If
                End Select

                Return _cv
        End Select

        'курсы по умолчанию
        _actual = False
        Select Case CurrencyID
            Case "USD"
                Return My.Settings.RateUSD
            Case "EUR"
                Return My.Settings.RateEUR
            Case "RUR"
                Return 1
        End Select

        Return 1

    End Function


    ''' <summary>
    ''' венет имя компа, на котором выполняется программа
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property MachineName As String
        Get
            Return My.Computer.Name
        End Get
    End Property


    Public Shared ReadOnly Property FossilTypeNameBySeries(ByVal series As String) As String
        Get
            Select Case series
                Case "220", "101"
                    Return "Венд"
                Case "201"

                    Return "Кембрий"
                Case "612"
                    Return "Ежи"

                Case Else
                    Return "Трилобиты"
            End Select
        End Get
    End Property
    ''' <summary>
    ''' вернет вес в кг
    ''' </summary>
    ''' <param name="weightvalue"></param>
    ''' <param name="INunit"></param>
    ''' <returns></returns>
    Public Shared Function WeightConvert(weightvalue As String, INunit As String) As String

        If String.IsNullOrEmpty(INunit.Trim) Then Return weightvalue

        Dim _out As String = ""

        Select Case INunit.Trim.ToUpper
            Case "ГР"
                _out += Math.Round(clsApplicationTypes.ReplaceDecimalSplitter(weightvalue) / 1000, 5).ToString
            Case "КАР"
                _out += Math.Round((clsApplicationTypes.ReplaceDecimalSplitter(weightvalue) / 5) / 1000, 6).ToString
            Case "УНЦ"
                _out += Math.Round((clsApplicationTypes.ReplaceDecimalSplitter(weightvalue) * 29.8) / 1000, 3).ToString
            Case "ФУНТ"
                _out += Math.Round((clsApplicationTypes.ReplaceDecimalSplitter(weightvalue) * 453.59) / 1000, 3).ToString
            Case Else
                _out = weightvalue
        End Select
        Return _out
    End Function



    ''' <summary>
    ''' вернет преобразованное значение текста в число. Если ошибка, вернет 0.
    ''' </summary>
    ''' <param name="text"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Shared Function ReplaceDecimalSplitter(ByVal textcontrol As TextBoxBase) As Decimal
        Dim _out As Decimal = 0
        If Decimal.TryParse(ReplaceDecimalSplitter(textcontrol.Text), _out) Then
            Return _out
        End If
        Return 0
    End Function

    ''' <summary>
    ''' замена . на ,
    ''' </summary>
    ''' <param name="text"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Shared Function ReplaceDecimalSplitter(ByVal text As String) As String
        Dim _needsep = Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator
        If String.IsNullOrEmpty(text) Then Return "0"
        text = text.Replace(",", _needsep)
        text = text.Replace(".", _needsep)
        Return text
    End Function
    ''' <summary>
    ''' Вынет из названия файла код этикетки, localization по умолчанию EnglishCulture, или разберет из кода этикетки
    ''' допустимый формат кода упаковки _S[тип]_[ru,rus,en,eng].[ai,jpg,tiff,gif,bmp]
    ''' </summary>
    ''' <param name="FilenameWithExtention"></param>
    ''' <param name="localization"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetLabelType(FilenameWithExtention As String, Optional ByRef localization As CultureInfo = Nothing, Optional ByRef LocalizationString As String = "") As String
        Dim _sh1 = "[_]{1}[S]{1}\d*\D?\d*[.]?[_]?\w{0,3}"
        Dim _rg = New Regex(_sh1)
        For Each s As Match In _rg.Matches(FilenameWithExtention)
            Dim _result = s.Value.Split("_")

            Select Case _result.Length
                Case 0
                    Return ""
                Case 1
                    Return _result(0)
                Case 2
                    'нет локализации, только текст
                    LocalizationString = ""
                    Return _result(1)
                Case 3
                    'есть локализация
                    Select Case _result(2).ToLower
                        Case "ru", "rur"
                            localization = RussianCulture
                            LocalizationString = "ru"
                        Case "en", "eng"
                            localization = EnglishCulture
                            LocalizationString = "en"
                        Case Else
                            LocalizationString = "error"
                    End Select
                    Return _result(1) & "_" & _result(2)
            End Select

            'разберем тип коробочки
            'TODO

        Next

        Return ""

    End Function


    ''' <summary>
    ''' Возвращает строку форматирования в зависимости от переданной валюты
    ''' 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetCultureByCurrency(ByVal currencyText As String) As System.Globalization.CultureInfo
        If currencyText Is Nothing Then Return clsApplicationTypes.EnglishCulture
        currencyText = currencyText.Trim
        If currencyText = "" Then currencyText = "USD"
        'Debug.Assert(Not currencyText = "")
        If currencyText = "" Then currencyText = "USD"
        Dim _tmp As emCurrencyList = [Enum].Parse(GetType(emCurrencyList), currencyText, True)
        Select Case _tmp
            Case emCurrencyList.EUR
                Return System.Globalization.CultureInfo.CreateSpecificCulture("de-DE")
            Case emCurrencyList.USD
                Return clsApplicationTypes.EnglishCulture
            Case emCurrencyList.RUR
                Return clsApplicationTypes.RussianCulture

            Case Else
                Return System.Globalization.CultureInfo.CurrentCulture
        End Select


    End Function

    'Public Class KeyPressEventArgsWithTarget
    '    Inherits System.Windows.Forms.KeyPressEventArgs
    '    Sub New(e As Char)
    '        MyBase.New(e)
    '    End Sub
    '    Public Property Target As System.Windows.Forms.TextBox
    'End Class


    ''' <summary>
    ''' для ввода со сканера - надо прицепить события
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Shared Sub Control_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If CType(sender, Windows.Forms.Control).Tag Is Nothing Then Return
        Dim _obj = CType(sender, Windows.Forms.Control).Tag
        If Char.IsDigit(e.KeyChar) Then
            'цифра
            'очистить поле и начать ввод
            _obj.Text = e.KeyChar.ToString
            _obj.Focus()
        End If
    End Sub

    Public Shared Function GetCurrentTimeString() As String
        Dim _format = "ddd  HH:mm"
        Return GetCurrentTime.ToString(_format)
    End Function


    Public Shared Function GetCurrentTime() As Date
        Return clsNetworkTime.GetTime
    End Function

    Private Shared oUsers As New List(Of clsUser)



    ''' <summary>
    ''' это текущий пользователь приложения
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Property CurrentUser As clsUser

    ''' <summary>
    ''' вернет всех записанных в файле пользователей
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property Users As List(Of clsUser)
        Get
            Return oUsers
        End Get
    End Property

    ''' <summary>
    ''' создает пользователя
    ''' </summary>
    ''' <param name="id"></param>
    ''' <param name="name"></param>
    ''' <param name="pin"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CreateUser(id As Integer, name As String, pin As String) As clsUser
        If oUserFile Is Nothing Then Return Nothing
        Dim _result = oUserFile.CreateUser(id, name, pin)
        If Not _result Is Nothing Then
            oUserFile.SaveFile()
        End If
        Return _result
    End Function

    'Public Shared Sub SaveUserFile()
    '    oUserFile.SaveFile()
    'End Sub


    ''' <summary>
    ''' хранит external object
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Property SiteExternalObject As Object
        Get
            Return oSiteExternalObject
        End Get
        Set(value As Object)
            oSiteExternalObject = value
        End Set
    End Property

    Private Shared Property oUserFile As User.USER

    ''' <summary>
    '''  можно пользовать файлы excel (офис установлен)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Property ExcelEnabled As Boolean
        Get
            Return My.Settings.ExcelEnabled
        End Get
        Set(value As Boolean)
            My.Settings.ExcelEnabled = value
            My.Settings.Save()
        End Set
    End Property
    ''' <summary>
    ''' Режим обмена ftp
    ''' </summary>
    ''' <returns></returns>
    Public Shared Property FtpModeActive As Boolean
        Get
            Return My.Settings.FtpModeActive
        End Get
        Set(value As Boolean)
            My.Settings.FtpModeActive = value
            My.Settings.Save()
        End Set
    End Property


    Public Shared Function LoadUser(userID As String, Optional LoadDB As Boolean = False) As Boolean
        Dim _u = (From c In oUsers Where c.UserPermission.id = userID Select c).FirstOrDefault
        If _u Is Nothing Then Return False

        If LoadDB Then
            Dim _res = (From c In clsApplicationTypes.SampleDataObject.GetdbPhotoObjectContext.tbEmployee Where c.ID = _u.UserPermission.id Select c).FirstOrDefault
            If Not _res Is Nothing Then
                _u.Employee = _res
                Return True
            Else
                'удалить без записи в БД
                oUsers.Remove(_u)
                Return False
            End If
        Else
            'загружаем список пользователей из локального файла xml
            Dim _us = User.USER.CreateInstance

            If _us Is Nothing Then Return False

            If _us.UserCount = 0 Then Return False

            oUserFile = _us
            oUsers = _us.GetUsers
            Return True
        End If
    End Function

    ''' <summary>
    ''' загружает пользователей из файла (БД)
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function LoadUsers(Optional LoadDB As Boolean = False) As Boolean
        If LoadDB Then
            'загрузить из БД (через сеть)
            Dim _status As Integer = 0
            Dim _nonDbUserID As New List(Of Integer)

            For Each u In oUsers
                Dim _res = (From c In clsApplicationTypes.SampleDataObject.GetdbPhotoObjectContext.tbEmployee Where c.ID = u.UserPermission.id Select c).FirstOrDefault
                If Not _res Is Nothing AndAlso String.IsNullOrEmpty(_res.UUID) = False Then
                    _status += 1
                    u.Employee = _res
                Else
                    _nonDbUserID.Add(u.UserPermission.id)
                End If
            Next

            If _status = 0 Then Return False

            'удалить всех без записи в БД
            For Each t In _nonDbUserID
                Dim _u = From c In oUsers Where c.UserPermission.id = t Select c
                oUsers.Remove(_u.FirstOrDefault)
            Next
            Return True
        Else
            'загружаем список пользователей из локального файла xml
            Dim _us = User.USER.CreateInstance

            If _us Is Nothing Then Return False

            If _us.UserCount = 0 Then Return False

            oUserFile = _us
            oUsers = _us.GetUsers
            Return True
        End If
    End Function

    ''' <summary>
    ''' проверка подключения как строка
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property IsConnected As String
        Get
            Select Case Service.clsApplicationTypes.SampleDataObject.IsConnected
                Case True
                    Return "online"
                Case Else
                    Return "offline"
            End Select
            'Return Service.clsApplicationTypes.SampleDataObject.IsConnected
        End Get
    End Property


    ''' <summary>
    ''' состояние запроса eBay (см fmOption в fmMain)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Property EbayBackgroundQueryEnabled As Boolean


    ''' <summary>
    ''' проверяет возможность подключения к серверам, перечисленным в настройках. Если находит доступный сервер, то настраивает приложение на подключение к нему.
    ''' 
    ''' </summary>
    ''' <returns>сообщение</returns>
    ''' <remarks></remarks>
    Public Function InitDbConnection(ByRef message As String, AsureRequered As Boolean, Optional AzureConnStringDBOPHOTO As String = "", Optional AzureConnStringDBREADYSAMPLE As String = "") As Boolean
        'Dim _azurePhotoCONSTR = "Server=tcp:v0ecxr50yd.database.windows.net,1433;Database=DBOPHOTO;User ID=foto@v0ecxr50yd;Password=Asaphus2009;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;"
        'Dim _azureSampleCONSTR = "Server=tcp:v0ecxr50yd.database.windows.net,1433;Database=DBREADYSAMPLE;User ID=foto@v0ecxr50yd;Password=Asaphus2009;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;"
        Dim _serversForLook As Collections.Specialized.StringCollection

        If AsureRequered Then
            _serversForLook = New Collections.Specialized.StringCollection
            _serversForLook.Add("AZURE")
        Else
            _serversForLook = My.Settings.DbServersNames
        End If

        Dim _CheckServers As String = ""

        'перебрать все зарегестрированные сервера
        For Each _server As String In _serversForLook

            Dim _ReadySamplesConnString As String = "Data Source=" & _server & ";Initial Catalog=DBREADYSAMPLE;Integrated Security=True"
            Dim _DBPhotoConnectionString As String = "Data Source=" & _server & ";Initial Catalog=DBOPHOTO;Integrated Security=True"

            If _server = "AZURE" Then
                _ReadySamplesConnString = AzureConnStringDBREADYSAMPLE
                _DBPhotoConnectionString = AzureConnStringDBOPHOTO
            End If

            _CheckServers += _server

            Dim _errorStatus As Boolean = False


            'проверить подключение
            Dim _conn As New Data.SqlClient.SqlConnection(_ReadySamplesConnString)
            Dim _servermess As String = "Ok"
            Dim _errHandler = Function(sender As Object, args As Data.SqlClient.SqlInfoMessageEventArgs) As Boolean
                                  If args.Errors.Count > 0 Then
                                      _errorStatus = True
                                      _servermess = args.Message
                                      Return True
                                  Else
                                      _errorStatus = False
                                      Return False
                                  End If

                              End Function
            AddHandler _conn.InfoMessage, _errHandler

            Try
                _conn.Open()
                If _conn.State = ConnectionState.Open And _errorStatus = False Then
                    'угадали, ошибок нет. Подключение есть. запомнить строку.
                    dboPhotoConnectionString = _DBPhotoConnectionString
                    dbReadySampleConnectionString = _ReadySamplesConnString
                    message = "Подключились к: " & _server & ";"

                    'пробуем подключить context
                    Dim _contextMessage As String = ""
                    If Not Service.clsApplicationTypes.SampleDataObject.Connect(_contextMessage) Then
                        'соединение через objectcontext НЕ УСТАНОВЛЕНО!
                        message += "; соединение через objectcontext НЕ УСТАНОВЛЕНО;"
                        Return False
                    End If
                    message += "; context:" & _contextMessage & ";"
                    'завершаем подключение
                    _conn.Close()
                    Return True
                Else
                    message += String.Format("{1}: ошибка - {0}{2} ", _servermess, _server, ChrW(13))
                End If
            Catch ex As Exception
                _conn.Close()
                message += "При подключении к: " & _server & " произошла ошибка: " & ex.Message & ";" & ChrW(13)
            End Try

            _conn.Close()
            _CheckServers += ", "
        Next


        'подключение установить не удалось
        Return False
    End Function

    ''' <summary>
    ''' добавляет в настройки новый сервер
    ''' </summary>
    ''' <param name="name"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function AddServerName(ByVal name As String) As Boolean


        Dim _coll = My.Settings.DbServersNames
        If name.Length > 0 AndAlso name.Length < 255 Then
            _coll.Add(name)
        End If
        My.Settings.DbServersNames = _coll
        My.Settings.Save()
        Return True
    End Function

    Public Function RemoveServerName(ByVal name As String) As Boolean
        Dim _coll = My.Settings.DbServersNames
        If _coll.Contains(name) Then
            _coll.Remove(name)
            My.Settings.DbServersNames = _coll
            My.Settings.Save()
            Return True
        End If
        Return False
    End Function

#End Region


#Region "параметры my.Settings"

    Public Shared Property ExcelBookPath As String
        Get
            Return My.Settings.ExcelBookPath
        End Get
        Set(value As String)
            My.Settings.ExcelBookPath = value
            My.Settings.Save()
        End Set
    End Property

    ''' <summary>
    ''' фотоменеджер - папка по умолчанию
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Property PhotoManagerStarUpFolder As String
        Get
            If My.Settings.PhotoManagerStarUpFolder = "" OrElse IO.Directory.Exists(My.Settings.PhotoManagerStarUpFolder) = False Then
                My.Settings.PhotoManagerStarUpFolder = SelectAnyFolder("Выбор папки ОБРАБОТАННЫЕ")
                My.Settings.Save()
            End If
            Return My.Settings.PhotoManagerStarUpFolder

            ' Return My.Settings.PhotoManagerStarUpFolder
        End Get
        Set(value As String)
            My.Settings.PhotoManagerStarUpFolder = value
            My.Settings.Save()
        End Set
    End Property


    ''' <summary>
    ''' путь к офф-лайн xml файлу, если БД не доступна
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Property xmldboPhotoStorePath As String
        Get
            If My.Settings.xmldboPhotoStorePath = "" OrElse IO.Directory.Exists(My.Settings.xmldboPhotoStorePath) = False Then
                My.Settings.xmldboPhotoStorePath = SelectAnyFolder("Выбор папки для файла режима off-line (не обязательно, можно выбрать любую папку)")
                My.Settings.Save()
            End If
            Return My.Settings.xmldboPhotoStorePath

        End Get
        Set(ByVal value As String)
            My.Settings.xmldboPhotoStorePath = value
            My.Settings.Save()
        End Set

    End Property
    ''' <summary>
    ''' возвращает обьект для работы с фотографиями
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property SamplePhotoObject As clsSamplePhotoManager
        Get
            Return oSamplePhotoManager
        End Get
    End Property
    ' ''' <summary>
    ' ''' вернет обьект для работы с деревьями
    ' ''' </summary>
    ' ''' <value></value>
    ' ''' <returns></returns>
    ' ''' <remarks></remarks>
    'Public Shared ReadOnly Property TreeServiceObject As Trilbone.clsTreeService
    '    Get
    '        Return oTreeService
    '    End Get
    'End Property

    ''' <summary>
    ''' вернет интерфейс сайта
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property NopInterface As iNopDataProvider
        Get
            Return oSampleDataManager.GetNopInterface
        End Get
    End Property


    ''' <summary>
    ''' возвращает обьект для работы с БД
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property SampleDataObject As clsSampleDataManager
        Get
            Return oSampleDataManager
        End Get
    End Property
    ' ''' <summary>
    ' ''' вернет обьект соединения
    ' ''' </summary>
    ' ''' <value></value>
    ' ''' <returns></returns>
    ' ''' <remarks></remarks>
    'Public Shared ReadOnly Property Connection As clsConnectionBase
    '    Get
    '        Return oConnection
    '    End Get
    'End Property
    ''' <summary>
    ''' регистрирует форму как провайдера списка образцов и открывает форму списков
    ''' </summary>
    ''' <param name="fm"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function RegisterFormToFormSampleList(fm As Windows.Forms.Form) As Boolean
        Dim _param As Object = {fm}
        Dim _form = Service.clsApplicationTypes.DelegateStoreApplicationForm(clsApplicationTypes.emFormsList.fmListManager).Invoke(_param)
        If Not _form Is Nothing Then
            If _form.Visible = False Then
                _form.Show(fm.MdiParent)
            End If
            Dim _client = FormMain.ClientRectangle
            Dim _r = _client.Right
            Dim _t = _client.Top
            _form.Location = New Point(_r - _form.Width, _form.Height)
            Return True
        End If
        Return False
    End Function

    ''' <summary>
    ''' индекс по умолчанию в списке шаблонов для преобразования XML(для отображения шаблона при открытии форм)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property MainXMLTemplateIndex As Integer
        Get
            Return 3
        End Get
    End Property


    ''' <summary>
    ''' вернет цифровую клавиатуру
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property GetDigiKeyBoardForm As Windows.Forms.Form
        Get
            Static _fm As PriceCalculator.spDigitalBoard
            'формат вызова GetDigiKeyBoardForm.connect(Me.tbPin(TextBoxBase), 0, "Ok")
            '"Ok"- надпись на кнопке
            If _fm Is Nothing Then
                _fm = New PriceCalculator.spDigitalBoard
            End If
            If _fm.OkKayTextNotStandart Then
                _fm = New PriceCalculator.spDigitalBoard
            End If
            Return _fm
            'использование в событии mouseClick ЭУ
            'Dim _tb As TextBoxBase = Me.mycontrol
            '_tb.Text = ""
            'GetDigiKey.connect(_tb)
        End Get
    End Property

    ''' <summary>
    ''' Коллекция загруженных форм приложения
    ''' </summary>
    ''' <remarks></remarks>
    Private Shared oFormList As New Dictionary(Of emFormsList, Form)

    ''' <summary>
    ''' вызовет любую дочернюю форму
    ''' </summary>
    ''' <param name="formName"></param>
    ''' <param name="Parameter"></param>
    ''' <param name="isMDIchildren"></param>
    ''' <remarks></remarks>
    Public Shared Function CallAnyForm(ByVal formName As emFormsList, ByVal Parameter As Object) As Form
        If oFormList.ContainsKey(formName) Then
            Dim _fmt = oFormList(formName)
            If _fmt.Visible = False And _fmt.Created = True Then
                _fmt.Show()
                If formName = emFormsList.fmMoySklad Then
                    If TypeOf Parameter Is Array AndAlso CType(Parameter, Array).Length > 0 Then
                        CType(_fmt, Object).SetSample(Parameter(0), "")
                    End If
                End If

                Return _fmt
            End If
            If _fmt.Created = False Then
                oFormList.Remove(formName)
            Else
                _fmt.WindowState = FormWindowState.Normal
                Return _fmt
            End If
        End If
        Dim _fm As Form
        'Static _horiz As Integer = -10
        'по запросу выполняем вызов из сервиса
        'если делегата нет, то сервис недоступен
        If Not Global.Service.clsApplicationTypes.DelegateStoreApplicationForm _
            (formName) Is Nothing Then
            'сервис зарегестрирован - вызываем
            _fm = Global.Service.clsApplicationTypes.DelegateStoreApplicationForm _
                (formName).Invoke(Parameter)

            If Not _fm Is Nothing Then
                'If isMDIchildren Then
                '    _fm.MdiParent = Me
                '    _fm.StartPosition = FormStartPosition.Manual
                '    Dim _active = Me.ActiveMdiChild
                '    If _active Is Nothing Then
                '        _fm.SetDesktopLocation(0, 0)
                '    Else
                '        Dim _loc = _active.Location
                '        _loc.Offset(30, 0)
                '        _fm.Location = _loc
                '    End If
                'Else
                '    _fm.StartPosition = FormStartPosition.CenterScreen
                'End If
                _fm.StartPosition = FormStartPosition.CenterScreen
                If Not oFormList.ContainsKey(formName) Then
                    oFormList.Add(formName, _fm)
                End If
                Return _fm
                'Try
                '    _fm.Show()
                '    If formName = emFormsList.fmMoySklad Then
                '        If TypeOf Parameter Is Array AndAlso CType(Parameter, Array).Length > 0 Then
                '            CType(_fm, Object).SetSample(Parameter(0), "")
                '        End If
                '    End If
                '    Return _fm
                'Catch ex As Exception
                '    Return Nothing
                'End Try
            End If


        End If
        Return Nothing
    End Function


    ''' <summary>
    ''' основная форма приложения
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Property FormMain As Windows.Forms.Form

    ''' <summary>
    ''' загружает образец в открытую форму оформления
    ''' </summary>
    ''' <param name="SampleNumber"></param>
    ''' <remarks></remarks>
    Public Shared Sub ExternalLoadSample(SampleNumber As String)
        Dim _fm = clsApplicationTypes.FormMain

        If _fm Is Nothing Then Return
        If CType(_fm, Object).SampleData Is Nothing Then Return

        CType(_fm, Object).SampleData.ExternalLoadSample(SampleNumber)
        _fm.WindowState = FormWindowState.Maximized

    End Sub

    'Private Shared oFormMOYSKLAD As Windows.Forms.Form

    ' ''' <summary>
    ' ''' перехватывает окончание загруки формы МС
    ' ''' </summary>
    ' ''' <param name="sender"></param>
    ' ''' <param name="e"></param>
    ' ''' <remarks></remarks>
    'Private Shared Sub BackgroundWorkerFormMC_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs)

    '    ' First, handle the case where an exception was thrown.
    '    If (e.Error IsNot Nothing) Then
    '        MessageBox.Show("Ошибка асинхронной операции: " & e.Error.Message)
    '    ElseIf e.Cancelled Then
    '        ' Next, handle the case where the user canceled the 
    '        ' operation.
    '        ' Note that due to a race condition in 
    '        ' the DoWork event handler, the Cancelled
    '        ' flag may not have been set, even though
    '        ' CancelAsync was called.
    '        MsgBox("Операция прервана пользователем", vbInformation)
    '    Else
    '        ' Finally, handle the case where the operation succeeded.
    '        'отобразим результат операции
    '        oFormMOYSKLAD = CType(e.Result, Windows.Forms.Form)
    '        If Not oFormMOYSKLAD Is Nothing Then
    '            oBackgroundMCStatus = 2
    '            BeepYES()
    '        Else
    '            oBackgroundMCStatus = -1
    '            BeepNOT()
    '        End If
    '    End If

    'End Sub
    ' ''' <summary>
    ' ''' запускает вызов делегата (переданного в параметре)
    ' ''' </summary>
    ' ''' <param name="sender"></param>
    ' ''' <param name="e"></param>
    ' ''' <remarks></remarks>
    'Private Shared Sub BackgroundWorkerService_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs)
    '    Dim _answermsg As String = ""
    '    ' Get the BackgroundWorker object that raised this event.
    '    Dim worker As BackgroundWorker = _
    '        CType(sender, BackgroundWorker)
    '    If TypeOf (e.Argument) Is ApplicationFormDelegateFunction Then
    '        e.Result = e.Argument.Invoke("")
    '    End If
    'End Sub
    ' ''' <summary>
    ' ''' 0 - неопределенное состояние(не запускали) -1=ошибка при выполнении 1=в работе 2=завершено и обьект готов
    ' ''' </summary>
    ' ''' <remarks></remarks>
    'Private Shared oBackgroundMCStatus As Integer

    ' ''' <summary>
    ' ''' показывает статус загрузки формы мс 0 - неопределенное состояние(не запускали) -1=ошибка при выполнении 1=в работе 2=завершено и обьект готов
    ' ''' </summary>
    ' ''' <value></value>
    ' ''' <returns></returns>
    ' ''' <remarks></remarks>
    'Public Shared ReadOnly Property FormMoySKLADLoadedStatus As Integer
    '    Get
    '        If oFormMOYSKLAD Is Nothing Then
    '            Return oBackgroundMCStatus
    '        End If
    '        Return 2
    '    End Get
    'End Property

    ''' <summary>
    ''' менеджер рфид
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property RFIDmanager(Optional _restart As Boolean = False) As clsRfidManager
        Get
            If oRFIDmanager Is Nothing Then
                oRFIDmanager = New clsRfidManager
            End If
            If _restart Then
                oRFIDmanager.Dispose()
                oRFIDmanager = New clsRfidManager
            End If
            Return oRFIDmanager
        End Get
    End Property
    ''' <summary>
    ''' вернет форму браузера
    ''' </summary>
    ''' <param name="html"></param>
    ''' <param name="Caption"></param>
    ''' <param name="culture"></param>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property Browser(html As String, Caption As String, CatalogName As String, Optional culture As CultureInfo = Nothing) As Form
        Get
            Dim _fm = New fmBrowser(html:=html, Title:=Caption, culture:=IIf(culture Is Nothing, EnglishCulture, culture), CatalogName:=CatalogName)
            Return _fm
        End Get
    End Property


    Public Shared ReadOnly Property MoySkladUser As String
        Get
            Return "admin@trilbone"
        End Get
    End Property

    Public Shared ReadOnly Property MoySkladPass As String
        Get
            Return "illaenus2012"
        End Get
    End Property

    Private Shared oMoySkladDataProvider As iMoySkladDataProvider

    ''' <summary>
    ''' представляет интерфей работы с МС/ showMessage показать сообщение, если не доступен / needInit - принудительня инициализация (если точно не запущен процесс инициализации)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Property MoySklad(showMessage As Boolean, Optional needInit As Boolean = False, Optional onlyCheckObject As Boolean = False) As iMoySkladDataProvider
        Get
            If onlyCheckObject And oMoySkladDataProvider Is Nothing Then Return Nothing

            If oMoySkladDataProvider Is Nothing Then
                Dim _result = DelegatStoreMCinterface.Invoke(needInit)
                If _result Is Nothing Then
                    If showMessage Then
                        MsgBox("Мой склад еще загружается.. попробуйте еще раз после звукового сигнала (через 20-30 секунд)", vbInformation)
                    End If
                    Return Nothing
                End If
                'мс загружен
                oMoySkladDataProvider = _result
            End If
            Return oMoySkladDataProvider
        End Get
        Set(value As iMoySkladDataProvider)
            If Not value Is Nothing And oMoySkladDataProvider Is Nothing Then
                'установка МС
                oMoySkladDataProvider = value
                If showMessage Then
                    MsgBox("Мой склад загружен", vbInformation)
                Else
                    clsApplicationTypes.BeepYES()
                End If
            End If
        End Set
    End Property

    Public Shared ReadOnly Property eBayDataProvider() As ieBayDataProvider
        Get
            If DelegatStoreEbayinterface Is Nothing Then Return Nothing
            Dim _result = DelegatStoreEbayinterface.Invoke(False)
            If _result Is Nothing Then
                'If showMessage Then
                '    MsgBox("еще загружается.. попробуйте еще раз после звукового сигнала (через 20-30 секунд)", vbInformation)
                'End If
                Return Nothing
            End If
            'мс загружен
            Return _result
        End Get
    End Property

    ''' <summary>
    ''' интерфейс деревьев
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Property MyTrees As iMyTreesDataProvider

    ''' <summary>
    ''' список имен
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Property MyTreesSystematicaNames As List(Of String)
        Get
            If oMyTreesSystematicaNames Is Nothing Then Return New List(Of String)
            Return oMyTreesSystematicaNames
        End Get
        Set(value As List(Of String))
            Dim _new = From c In value Select clsApplicationTypes.NameStringParcer(c)
            oMyTreesSystematicaNames = _new.ToList
        End Set
    End Property

    Public Shared Property MyTreesLocalityNames As List(Of String)

    Public Shared Property MyTreesTimeScaleNames As List(Of String)



    ''' <summary>
    ''' вернет сплеш скрин
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property SplashScreen As Form
        Get
            Return New SplashScreen1
        End Get
    End Property

    Private Shared oAuctionAgent As Agents.AUCTIONAGENT
    ''' <summary>
    ''' обьект для работы с файлом Агентов аукционов
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property AuctionAgent As Agents.AUCTIONAGENT
        Get
            If oAuctionAgent Is Nothing Then
                oAuctionAgent = Agents.AUCTIONAGENT.CreateInstance()
            End If
            Return oAuctionAgent
        End Get
    End Property

    ''' <summary>
    ''' агент по умолчанию
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property DefaultAgent As Agents.AUCTIONDATAAGENT
        Get
            Return oAuctionAgent.GetAgentByNameAccount("default", "trilbone")
        End Get
    End Property


    Private Shared oFormMOYSKLAD As Windows.Forms.Form
    Private Shared oMyTreesSystematicaNames As List(Of String)

    ''' <summary>
    ''' форма мой склад
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property FormMOYSKLAD(Optional getnew As Boolean = False) As Windows.Forms.Form
        Get
            Dim _param As Object = ""
            If Not getnew Then
                If Not oFormMOYSKLAD Is Nothing Then
                    Return oFormMOYSKLAD
                End If
            End If

            'если делегата нет, то сервис недоступен
            If Not DelegateStoreApplicationForm(emFormsList.fmMoySklad) Is Nothing Then
                'сервис зарегестрирован - вызываем  (асинхронный вызов)
                oFormMOYSKLAD = Global.Service.clsApplicationTypes.DelegateStoreApplicationForm(emFormsList.fmMoySklad).Invoke(_param)
            End If

            If Not oFormMOYSKLAD Is Nothing Then
                Return oFormMOYSKLAD
            Else
                MsgBox("Мой склад еще загружается.. попробуйте еще раз после звукового сигнала (через 20-30 секунд)", vbInformation)
                Return Nothing
            End If

        End Get
    End Property




    ''' <summary>
    ''' ширина в пикс. для оптимизации фото
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Property OptimizeImageWight As Integer
        Get
            Return My.Settings.OptimizeImageWight
        End Get
        Set(ByVal value As Integer)
            My.Settings.OptimizeImageWight = value
            My.Settings.Save()
        End Set

    End Property
    ''' <summary>
    ''' путь к gdrive
    ''' </summary>
    ''' <returns></returns>
    Public Shared Property GDriveFolderPath As String
        Get
            Return My.Settings.GdriveFolderPath
        End Get
        Set(value As String)
            My.Settings.GdriveFolderPath = value
            My.Settings.Save()
        End Set
    End Property


    ''' <summary>
    ''' путь к папке с шаблонами
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Property TemplateFolderPath As String
        Get
            If My.Settings.TemplateFolderPath = "" OrElse IO.Directory.Exists(My.Settings.TemplateFolderPath) = False Then
                My.Settings.TemplateFolderPath = SelectAnyFolder("Выбор папки с шаблонами")
                My.Settings.Save()
            End If
            Return My.Settings.TemplateFolderPath
        End Get
        Set(value As String)
            My.Settings.TemplateFolderPath = value
            My.Settings.Save()
        End Set
    End Property





    ''' <summary>
    ''' путь к файлу рассчета цен
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property GetPriceFilePath As String
        Get
            Dim _path = IO.Path.Combine(TemplateFolderPath, My.Settings.PriceFileName)
            If IO.File.Exists(_path) Then
                Return _path
            End If
            _path = SelectAnyFile("Укажите файл рассчета цен", "xlsx")
            Return _path
        End Get
    End Property



    ''' <summary>
    ''' путь к папке с деревьями
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Property TreeFolderPath As String
        Get
            Static _nullrequest As Boolean

            If My.Settings.TreeFolderPath = "" OrElse IO.Directory.Exists(My.Settings.TreeFolderPath) = False Then
                My.Settings.TreeFolderPath = SelectAnyFolder("Выбор папки с описаниями (деревьями)")
                If Not My.Settings.TreeFolderPath = "" Then
                    My.Settings.Save()
                Else
                    If Not _nullrequest Then
                        _nullrequest = True
                        MsgBox("Пропишите путь к папке с описаниями в настройках", vbCritical)
                    End If
                End If
            End If
            Return My.Settings.TreeFolderPath
        End Get
        Set(value As String)
            My.Settings.TreeFolderPath = value
            My.Settings.Save()
        End Set
    End Property


    Private Shared Function SelectAnyFile(message As String, FileExtention As String) As String
        ' вывести форму для указания папки
ex:
        Dim _out As String = ""
        Dim _fm = New Windows.Forms.OpenFileDialog
        With _fm
            .InitialDirectory = TemplateFolderPath
            .Multiselect = False
            .DefaultExt = FileExtention
            .Filter = "*." & FileExtention & "|"
            .RestoreDirectory = True
            .Title = message
        End With

        Try
            Dim _result = _fm.ShowDialog

            Select Case _result
                Case Windows.Forms.DialogResult.OK
                    _out = _fm.FileName
                Case Else
                    MsgBox("При следующем запросе необходимо выбрать путь к файлу. Иначе программа может работать неверно.", vbCritical)
                    'GoTo ex
            End Select
            Return _out
        Catch ex As Exception
            Return _out
        End Try


    End Function



    ''' <summary>
    ''' поможет выбрать папку для настроек
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <STAThread>
    Public Shared Function SelectAnyFolder(message As String) As String
        ' вывести форму для указания папки
exs:
        Dim _out As String = ""
        Dim _fm = New Windows.Forms.FolderBrowserDialog
        With _fm
            .Description = message
            .RootFolder = Environment.SpecialFolder.MyComputer
            .ShowNewFolderButton = True
        End With

#If DEBUG Then
        Try
            Select Case _fm.ShowDialog
                Case Windows.Forms.DialogResult.OK
                    _out = _fm.SelectedPath
                Case Else
                    MsgBox("Необходимо выбрать путь к папке. Иначе программа будет работать неверно.", vbCritical)
                    GoTo exs
            End Select
        Catch ex As Exception
            _out = ""
        End Try
#Else
  Select Case _fm.ShowDialog
            Case Windows.Forms.DialogResult.OK
                _out = _fm.SelectedPath
            Case Else
                MsgBox("Необходимо выбрать путь к папке. Иначе программа будет работать неверно.", vbCritical)
                GoTo exs
        End Select
#End If


        Return _out
    End Function




    Public Shared Property dboPhotoConnectionString As String
        Get
            Return My.Settings.dboPhotoConnectionString
        End Get
        Set(ByVal value As String)
            My.Settings.Item("dboPhotoConnectionString") = value
            My.Settings.Save()
        End Set

    End Property
    Public Shared Property dbReadySampleConnectionString As String
        Get
            Return My.Settings.dbReadySampleConnectionString
        End Get
        Set(ByVal value As String)
            My.Settings.Item("dbReadySampleConnectionString") = value
            My.Settings.Save()
        End Set
    End Property

    Public Shared Property dbNopConnectionString As String
        Get
            Return My.Settings.dbNopConnectionString
        End Get
        Set(ByVal value As String)
            My.Settings.Item("dbNopConnectionString") = value
            My.Settings.Save()
        End Set
    End Property

    Public Shared Property dbMyTreesConnectionString As String
        Get
            Return My.Settings.dbMyTreesConnectionString
        End Get
        Set(ByVal value As String)
            My.Settings.Item("dbMyTreesConnectionString") = value
            My.Settings.Save()
        End Set
    End Property
    ''' <summary>
    ''' вернет список запросов из ресурса
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property dbQweryList As String()
        Get
            Dim _resxfile As String = ".\Resource_sql.resx"
            Dim _out As New List(Of String)
            Using _resxread As New System.Resources.ResXResourceReader(_resxfile)
                For Each t As DictionaryEntry In _resxread
                    _out.Add(t.Key)
                Next
            End Using
            Return _out.ToArray
        End Get
    End Property
    ''' <summary>
    ''' вернет sql из ресурса
    ''' </summary>
    ''' <param name="resourceName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetSqlByResourceName(resourceName As String) As String
        Dim _resxfile As String = ".\Resource_sql.resx"
        Using _resxSet As New System.Resources.ResXResourceSet(_resxfile)
            Return _resxSet.GetString(resourceName)
        End Using
    End Function

    Public Shared Sub BeepNOT()
        Console.Beep(500, 400)
    End Sub

    Public Shared Sub BeepYES()
        Console.Beep(2000, 200)
    End Sub


    Public Shared ReadOnly Property CurrencyList As String()
        Get
            Return [Enum].GetNames(GetType(emCurrencyList))
        End Get
    End Property
    ''' <summary>
    ''' ПОЛНЫЙ путь к текущей папке с заказами
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Property OrdersPath As String
        Get
            If My.Settings.OrdersPath = "" OrElse IO.Directory.Exists(My.Settings.OrdersPath) = False Then
                My.Settings.OrdersPath = SelectAnyFolder("Выбор папки с заказами")
                My.Settings.Save()
            End If
            Return My.Settings.OrdersPath
        End Get
        Set(ByVal value As String)
            My.Settings.OrdersPath = value
            My.Settings.Save()
        End Set
    End Property
    ''' <summary>
    ''' путь к Arhive_folder
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Property ArhiveContainerPath() As String
        Get
            If My.Settings.ArhivePhotoPath = "" OrElse IO.Directory.Exists(My.Settings.ArhivePhotoPath) = False Then
                My.Settings.ArhivePhotoPath = SelectAnyFolder("Выбор папки с фотками")
                My.Settings.Save()
                ' SelectArhiveFolder()
            End If
            Return My.Settings.ArhivePhotoPath
        End Get
        Set(value As String)
            My.Settings.ArhivePhotoPath = value
            My.Settings.Save()
        End Set
    End Property
    Public Shared Property LabelDrawDescriptionPath As String
        Get
            'LabelDrawPhotoPath
            If My.Settings.LabelDrawPhotoPath = "" OrElse IO.Directory.Exists(My.Settings.LabelDrawPhotoPath) = False Then
                My.Settings.LabelDrawPhotoPath = SelectAnyFolder("Выбор папки с этикетками")
                My.Settings.Save()
            End If
            Return My.Settings.LabelDrawPhotoPath
        End Get
        Set(value As String)
            My.Settings.LabelDrawPhotoPath = value
            My.Settings.Save()
        End Set
    End Property
    ''' <summary>
    ''' название аккаунта для агента в файле agents.xml
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property SiteAgentAccount As String
        Get
            Return My.Settings.SiteAccount
        End Get
    End Property

    ''' <summary>
    ''' путь 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Property LocalDataFilePath() As String
        Get
            If My.Settings.DataFilePath = "" OrElse IO.Directory.Exists(My.Settings.DataFilePath) = False Then
                My.Settings.DataFilePath = SelectAnyFolder("Выбор папки для записи данных приложения при отсутствии Интернета")
                My.Settings.Save()
            End If
            Return My.Settings.DataFilePath
        End Get
        Set(ByVal value As String)
            My.Settings.DataFilePath = value
        End Set
    End Property
#End Region

    ''' <summary>
    '''  вернет текстовое описание узла (как в первой версии). separator - разделитель значений, includeRootName - включить название корня с двоеточием (root: item0 -> item1 -> и тд с сепаратором по умолчанию " -> ")
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ParseNodeXML(xml As XElement, Optional separator As String = " -> ", Optional includeRootName As Boolean = True) As String
        If xml Is Nothing Then Return ""
        Dim _out As New List(Of String)
        Dim _nodeColl = (xml...<NODE>).ToList

        Dim _index As Integer = 0
        For Each nd In _nodeColl
            _index += 1

            Dim _val = nd.FirstNode.ToString
            'преобразвание текста узла:
            If _index = _nodeColl.Count Then
                'преобразование имени работает ТОЛЬКО на последнем узле NODE
                _val = NameStringParcer(_val)
            End If
            _out.Add(_val)
        Next
        If includeRootName Then
            'добавит имя дерева в строку узла описания и обьеденить значения узлов
            Return xml.Attribute("root").Value & ": " & String.Join(separator, _out)
        Else
            Return String.Join(separator, _out)
        End If

    End Function

    ''' <summary>
    ''' заменяет некоторые слова и фразы в разбираемой строке описания !!ВЫЗЫВАЕТСЯ, ЕСЛИ УЗЕЛ ПОСЛЕДНИЙ
    ''' </summary>
    ''' <param name="input"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function NameStringParcer(input As String) As String
        input = input.Replace("†", "")
        If input.ToLower.StartsWith("genus") Then
            Dim _warr = input.Split(" ".ToCharArray, StringSplitOptions.RemoveEmptyEntries).ToList
            If _warr.Count > 1 Then
                'удалить первое слово genus
                Dim _we = _warr.Skip(2).ToList
                Dim _name = _warr(1)
                _warr.Clear()
                _warr.Add(_name)
                _warr.Add("sp.")
                _warr.AddRange(_we)
                Return String.Join(" ", _warr)
            End If
        End If
        If input.ToLower.StartsWith("family") Then
            Dim _warr = input.Split(" ".ToCharArray, StringSplitOptions.RemoveEmptyEntries).ToList
            If _warr.Count > 1 Then
                'удалить первое слово genus
                Dim _we = _warr.Skip(2).ToList
                Dim _name = _warr(1)
                _warr.Clear()
                _warr.Add(_name)
                ' _warr.Add("sp.")
                _warr.AddRange(_we)
                Return String.Join(" ", _warr)
            End If
        End If
        If input.ToLower.StartsWith("class") Then
            Dim _warr = input.Split(" ".ToCharArray, StringSplitOptions.RemoveEmptyEntries).ToList
            If _warr.Count > 1 Then
                'удалить первое слово genus
                Dim _we = _warr.Skip(2).ToList
                Dim _name = _warr(1)
                _warr.Clear()
                _warr.Add(_name)
                ' _warr.Add("sp.")
                _warr.AddRange(_we)
                Return String.Join(" ", _warr)
            End If
        End If
        If input.ToLower.StartsWith("order") Then
            Dim _warr = input.Split(" ".ToCharArray, StringSplitOptions.RemoveEmptyEntries).ToList
            If _warr.Count > 1 Then
                'удалить первое слово genus
                Dim _we = _warr.Skip(2).ToList
                Dim _name = _warr(1)
                _warr.Clear()
                _warr.Add(_name)
                ' _warr.Add("sp.")
                _warr.AddRange(_we)
                Return String.Join(" ", _warr)
            End If
        End If
        Return input
    End Function

    ''' <summary>
    ''' разпознает текстовый список номеров с разделителями , ; [CR] [LF]
    ''' </summary>
    ''' <param name="data"></param>
    ''' <returns></returns>
    Shared Function ParseNumberList(data As String) As List(Of Service.clsApplicationTypes.clsSampleNumber)
        Dim _out As New List(Of clsApplicationTypes.clsSampleNumber)
        Dim _pattern = {ChrW(13), ChrW(10), ",", ";"}
        Dim _result = data.Split(_pattern, StringSplitOptions.RemoveEmptyEntries)
        For Each t In _result
            If t.Length <= 13 Then
                Dim _num = clsApplicationTypes.clsSampleNumber.CreateFromString(t)
                If _num.CodeIsCorrect Then
                    _out.Add(_num)
                End If
            End If
        Next
        Return _out
    End Function

    ''' <summary>
    ''' уберет скобки
    ''' </summary>
    ''' <param name="value"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function RejectSkobki(value As String) As String
        If String.IsNullOrEmpty(value) Then Return value
        Dim _out As String = ""

        Dim _split = value.Split({","}, StringSplitOptions.RemoveEmptyEntries)
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
        If String.IsNullOrEmpty(_out) Then _out = value
        _out = _out.TrimEnd(",")


        Return _out

    End Function

    ''' <summary>
    ''' заменяет текст в последних скобках/ count число вхождений/ 1=нет скобок
    ''' </summary>
    ''' <param name="value"></param>
    ''' <param name="replaceText"></param>
    ''' <param name="skobka"></param>
    ''' <param name="count"></param>
    ''' <returns></returns>
    Shared Function ReplaceInSkobki(value As String, replaceText As String, Optional startchar As Char = "(", Optional endchar As Char = ")", Optional ByRef count As Integer = 0) As String
        Dim _splitter = New Char() {startchar, endchar}

        Dim _arr = value.Split(_splitter, StringSplitOptions.RemoveEmptyEntries)

        Dim _out As String = ""

        count = _arr.Count

        Select Case _arr.Count
            Case 1
                'нет скобок
                _out = value
            Case 2
                'есть одна скобка
                _out = String.Format("{0} {2}{1}{3}", _arr(0).Trim, replaceText, startchar.ToString, endchar.ToString)

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


    ''' <summary>
    ''' вернет символ валюты
    ''' </summary>
    ''' <param name="currency"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Overloads Shared Function GetCurrencySymbol(currency As String) As String
        If String.IsNullOrEmpty(currency) Then Return ""
        Select Case currency.ToLower
            Case "rur"
                Return clsApplicationTypes.RussianCulture.NumberFormat.CurrencySymbol
            Case "eur"
                Return CultureInfo.GetCultureInfo("de-DE").NumberFormat.CurrencySymbol
            Case "usd"
                Return clsApplicationTypes.EnglishCulture.NumberFormat.CurrencySymbol
            Case Else
                Return currency.ToLower
        End Select
    End Function






End Class


Public Class clsReadySamplesItem

    Dim oShotCode As String

    ''' <summary>
    ''' 'колонка фото
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property TitleImage As Image

    ''' <summary>
    ''' колонка имени
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property MainName As String
    ''' <summary>
    ''' колонка номера
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property ShotCode As String
        Get
            Return oShotCode
        End Get
        Set(value As String)
            If value.Length = 13 Then
                Dim _sn = clsApplicationTypes.clsSampleNumber.CreateFromString(value)
                If _sn.CodeIsCorrect Then
                    oShotCode = _sn.ShotCode
                    Return
                End If
            End If
            oShotCode = value
        End Set
    End Property

    ''' <summary>
    ''' колонка имени склада
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Warehouse As String

    ''' <summary>
    ''' колонка базовой цены из МС
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property BasePrice As String
End Class

