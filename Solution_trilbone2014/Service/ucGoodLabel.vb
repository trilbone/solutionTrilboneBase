Imports System.Windows.Forms
Imports System.Drawing
Imports System.Linq
Imports System.Drawing.Imaging
Imports Service

Public Class ucGoodLabel
    Private oLabelImages As New List(Of Image)
    Private oLabelImagesWithoutFilter As New List(Of Image)
    Private oCurrentElementsCollection As New List(Of String) 'Trilbone.clsTreeService.clsDescriptionElement
    Private oCurrentCulture As System.Globalization.CultureInfo = Service.clsApplicationTypes.EnglishCulture
    Private oLabel As clsLabelBase
    Private oLabelImageList As New List(Of KeyValuePair(Of Image, SizeF))
    Dim oNeedResetPrinters As Boolean = False

    ''' <summary>
    ''' показывает, что надо подгружать обьекты
    ''' </summary>
    ''' <remarks></remarks>
    Private oNeedLoadBigImage As Boolean
    Private ooldBigObjectIndex As Integer
    Private oNameForLabel As String



    Private Sub SetPatternForLabels()
        If oNameForLabel = "" Then Return
        'зададим шаблон поиска
        Dim _pattern = ""
        Dim _names = oNameForLabel.Split({" ".ToArray(0), "(".ToArray(0)})
        'берем два первых слова
        Select Case _names.Length
            Case Is < 1
                'выход
            Case 1
                _pattern = _names(0) & "*"
                Me.nudWorldCount.Value = 1
            Case Is > 1
                If Me.nudWorldCount.Value = 1 Then
                    _pattern = _names(0) & "*"
                Else
                    _pattern = _names(0) & " " & _names(1) & "*"
                End If
        End Select
        Me.tbPatternSearch.Text = _pattern
    End Sub
    ''' <summary>
    ''' добавляет этикетку в список печати
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub AddLabelToPrint()
        Dim _size As SizeF = Nothing
        If oLabelImageList Is Nothing Then
            oLabelImageList = New List(Of KeyValuePair(Of Image, SizeF))
        End If
        Dim _image As Image = PictureBox1.Image
        If Not _image Is Nothing Then
            'размер этикеток - задать в мм 
            Dim x = 25
            Dim y = 18
            _size = New SizeF(x, y)
            oLabelImageList.Add(New KeyValuePair(Of Image, SizeF)(_image, _size))
            Me.PictureBox1.Image = _image
        End If
        Me.btPrintLabel.Text = "Печать этикеток (" & oLabelImageList.Count & ")"
    End Sub

#Region "Public members"

    Public Sub New()

        ' Этот вызов является обязательным для конструктора.
        InitializeComponent()

        ' Добавьте все инициализирующие действия после вызова InitializeComponent().
        ImageBindingSource.DataSource = oLabelImages
        Me.Source = emLabelSource.DrawAi
    End Sub



    ''' <summary>
    ''' Очистка ЭУ
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Clear()
        Me.PictureBox1.Image = Nothing
        Me.lbxLabelsTypes.Items.Clear()
        oLabelImages.Clear()
        oLabelImagesWithoutFilter.Clear()
        ImageBindingSource.DataSource = oLabelImages
        If Not Me.oCurrentElementsCollection Is Nothing Then
            Me.oCurrentElementsCollection.Clear()
        End If
        Me.Source = emLabelSource.DrawAi
    End Sub

    ''' <summary>
    ''' Добавить изображение в список
    ''' </summary>
    ''' <param name="label"></param>
    ''' <remarks></remarks>
    Public Sub AddLabel(label As Image)
        oLabelImages.Add(label)
        oLabelImagesWithoutFilter.Add(label)
        Me.ImageBindingSource.ResetBindings(False)
        Me.ImageBindingSource.MoveLast()
        Me.ImageBindingSource_CurrentChanged(Me, EventArgs.Empty)
    End Sub

    ''' <summary>
    ''' Установит имя для выбора этикетки
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property NameForLabel As String
        Get
            Return oNameForLabel
        End Get
        Set(value As String)
            oNameForLabel = value
            SetPatternForLabels()
        End Set
    End Property

    ''' <summary>
    ''' запуск поиска
    ''' </summary>
    Public Sub Search()
        btRequestLabelsts_Click(Me.btRequestLabelsts, EventArgs.Empty)
    End Sub


    ''' <summary>
    ''' источник этикеток
    ''' </summary>
    ''' <returns></returns>
    Public Property Source As emLabelSource
        Get
            Return oSource
        End Get
        Set(value As emLabelSource)
            oSource = value
            Select Case oSource
                Case emLabelSource.DrawAi
                    Me.rbDrawAndDescrFolder.Checked = True
                Case emLabelSource.DrawPhoto
                    Me.rbImagesFromDrawAndDescrFolder.Checked = True
            End Select
        End Set
    End Property

    Public Enum emLabelSource
        DrawAi
        DrawPhoto

    End Enum

    ''' <summary>
    ''' очистить очередь печати
    ''' </summary>
    Public Sub ClearPrint()
        oLabelImageList.Clear()
        Me.btPrintLabel.Text = "Печать"
    End Sub
#End Region

    Private Sub tbPatternSearch_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbPatternSearch.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Not tbPatternSearch.Text.Contains("*") Then
                tbPatternSearch.Text += "*"
            End If
            Me.btRequestLabelsts_Click(sender, e)
        End If
    End Sub

    Private Sub btRequestLabelsts_Click(sender As System.Object, e As System.EventArgs) Handles btRequestLabelsts.Click
        Dim _sp = New SplashScreen1
        _sp.Show()
        Application.DoEvents()
        oLabelImages.Clear()
        oLabelImagesWithoutFilter.Clear()
        ooldBigObjectIndex = 0

        '--------------------------------------------
        'этикетки из описаний
        ''If Me.rbLabelFromTrees.Checked Then
        ''    If Me.oCurrentElementsCollection Is Nothing Then _sp.Hide() : Return
        ''    If Me.oCurrentElementsCollection.Count = 0 Then _sp.Hide() : Return

        ''    Dim _elb = (From c In oCurrentElementsCollection Where c.Culture.Name = oCurrentCulture.Name Select New With {.treename = c.Name, .nodeid = c.LastNodeID}).ToList
        ''    If _elb.Count = 0 Then
        ''        clsApplicationTypes.BeepNOT()
        ''        Return
        ''    End If
        ''    'узел найден
        ''    Dim _TreeManager = clsTreeService.CreateInstance(oCurrentElementsCollection.First.FileName)

        ''    For Each t In _elb
        ''        Dim _il = _TreeManager.GetAiImagesByNodeID(t.treename, t.nodeid, 200)
        ''        If Not _il Is Nothing Then
        ''            Me.oLabelImages.AddRange(_il)
        ''            Me.oLabelImagesWithoutFilter.AddRange(_il)
        ''            ooldBigObjectIndex = 0
        ''        Else
        ''            clsApplicationTypes.BeepNOT()
        ''            Return
        ''        End If
        ''    Next
        ''    Return
        ''End If

        '----------------------------------------
        ''If Me.rbFromDB_Text.Checked Then
        ''    If Me.oLabel Is Nothing Then _sp.Hide() : Return
        ''    If Me.oLabel.LabelCollection Is Nothing Then _sp.Hide() : Return
        ''    If Me.oLabel.LabelCollection.Count = 0 Then _sp.Hide() : Return

        ''    'загрузим этикети
        ''    Dim _elb = (From c In Me.oLabel.GetLabelsByCulture(oCurrentCulture) From c1 In c.Files Select c1).ToList

        ''    If _elb.Count = 0 Then Return

        ''    Dim _path As String
        ''    For Each _file In _elb
        ''        'читаем файлы
        ''        _path = IO.Path.Combine(_file.Href, _file.Name)
        ''        Dim _im = clsApplicationTypes.GetAiImageByPath(_path, 200)
        ''        If Not _im Is Nothing Then
        ''            _im.Tag = ".ai"
        ''            Me.oLabelImages.Add(_im)
        ''            Me.oLabelImagesWithoutFilter.AddRange(_im)
        ''            ooldBigObjectIndex = 0
        ''        End If
        ''    Next

        ''    _sp.Hide()
        ''Else

        ''End If
        '-------------------------------------
        'фото  из  папки DrawAndDescription
        If rbImagesFromDrawAndDescrFolder.Checked Then

            If Not IO.Directory.Exists(clsApplicationTypes.LabelDrawDescriptionPath) Then
                MsgBox("Не могу найти папку draws and description. Проверте настройки приложения и правильно укажите путь к папке.", vbCritical)
                _sp.Hide()
                Return
            End If

            Dim _rootDrawDir As New IO.DirectoryInfo(clsApplicationTypes.LabelDrawDescriptionPath)

            'Dim _rootDrawDir = IO.Directory.GetParent(IO.Directory.GetParent(clsApplicationTypes.ArhiveContainerPath).FullName.TrimEnd(IO.Path.DirectorySeparatorChar)).GetDirectories("Labels*")
            'If _rootDrawDir.Count = 0 Then
            '    MsgBox("Не могу найти директорию: draws and description!!", vbCritical)
            '    _sp.Hide()
            '    Return
            'End If

            Dim _pattern = Me.tbPatternSearch.Text
            Dim _LabelFilePaths As New List(Of String)
            '     Dim _files As IO.FileInfo()
            '---------------
            'фильтрация

            'по файлам
            If Not cbxOnlyFolder.Checked Then
                Dim _filePattern As String
                'ищем и добавляем имена файлов по паттерну
                Dim _files As New List(Of IO.FileInfo)
                _filePattern = _pattern & ".jpg"
                _files.AddRange(_rootDrawDir.GetFiles(_filePattern, IO.SearchOption.AllDirectories))

                _filePattern = _pattern & ".jpeg"
                _files.AddRange(_rootDrawDir.GetFiles(_filePattern, IO.SearchOption.AllDirectories))

                _filePattern = _pattern & ".png"
                _files.AddRange(_rootDrawDir.GetFiles(_filePattern, IO.SearchOption.AllDirectories))

                _filePattern = _pattern & ".tiff"
                _files.AddRange(_rootDrawDir.GetFiles(_filePattern, IO.SearchOption.AllDirectories))

                _filePattern = _pattern & ".gif"
                _files.AddRange(_rootDrawDir.GetFiles(_filePattern, IO.SearchOption.AllDirectories))

                _filePattern = _pattern & ".bmp"
                _files.AddRange(_rootDrawDir.GetFiles(_filePattern, IO.SearchOption.AllDirectories))

                _filePattern = _pattern & ".tif"
                _files.AddRange(_rootDrawDir.GetFiles(_filePattern, IO.SearchOption.AllDirectories))

                For Each _f In _files
                    _LabelFilePaths.Add(_f.FullName)
                Next

                _LabelFilePaths.Sort()

                For Each _path In _LabelFilePaths
                    Dim _img As Image
                    If _LabelFilePaths.Count < 10 Then
                        _img = New Bitmap(100, 100)
                        _img.Tag = _path
                        oNeedLoadBigImage = True
                    Else
                        _img = clsApplicationTypes.GetResizedImageForTree(_path)
                        oNeedLoadBigImage = True
                    End If

                    If Not _img Is Nothing Then
                        _img.Tag = _path
                        Me.oLabelImages.Add(_img)
                        Me.oLabelImagesWithoutFilter.Add(_img)
                    End If
                Next
                ooldBigObjectIndex = 0

            End If

            'по папкам
            ' 'ищем папки по паттерну
            Dim _resultDirs = _rootDrawDir.GetDirectories(_pattern, IO.SearchOption.AllDirectories)
            For Each _dir In _resultDirs
                'из папки DrawAndDescription
                'внутри найденных папок соберем файлы
                Dim _img As List(Of Image)
                If _resultDirs.Length > 10 Then
                    _img = clsApplicationTypes.GetImagesFromFolder(_dir.FullName, False, True)
                    oNeedLoadBigImage = True
                Else
                    _img = clsApplicationTypes.GetImagesFromFolder(_dir.FullName)
                    oNeedLoadBigImage = False
                End If
                Me.oLabelImages.AddRange(_img)
                Me.oLabelImagesWithoutFilter.AddRange(_img)
                ooldBigObjectIndex = 0
            Next


        End If

        '--------------------------------------
        'этикетки из  папки DrawAndDescription
        If rbDrawAndDescrFolder.Checked Then

            If Not IO.Directory.Exists(clsApplicationTypes.LabelDrawDescriptionPath) Then
                MsgBox("Не могу найти папку draws and description. Проверте настройки приложения и правильно укажите путь к папке.", vbCritical)
                _sp.Hide()
                Return
            End If

            Dim _rootDrawDir As New IO.DirectoryInfo(clsApplicationTypes.LabelDrawDescriptionPath)

            Dim _pattern = Me.tbPatternSearch.Text
            Dim _filePattern As String = _pattern & ".ai"
            Dim _LabelFilePaths As New List(Of String)
            Dim _files As IO.FileInfo()

            '---------------
            'фильтрация

            'если указан просмотр всех подпапок (без фильтра по имени)
            If Not Me.cbxOnlyFolder.Checked Then
                ' 'ищем и добавляем имена файлов по паттерну
                _files = _rootDrawDir.GetFiles(_filePattern, IO.SearchOption.AllDirectories)
                For Each _f In _files
                    _LabelFilePaths.Add(_f.FullName)
                Next
                GoTo rd
            End If

            'филтр по названию папки
            'ищем папки по паттерну (фильтр по имени)
            Dim _resultDirs = _rootDrawDir.GetDirectories(_pattern, IO.SearchOption.AllDirectories)

            'внутри найденных папок соберем ВСЕ файлы
            For Each _dir In _resultDirs
                _files = _dir.GetFiles("*.ai", IO.SearchOption.AllDirectories)
                For Each _f In _files
                    _LabelFilePaths.Add(_f.FullName)
                Next
            Next

            ''из самой (корень) папки DrawAndDescription
            ''соберем файлы
            '_files = _rootDrawDir.GetFiles(_filePattern, IO.SearchOption.TopDirectoryOnly)
            'For Each _f In _files
            '    _LabelFilePaths.Add(_f.FullName)
            'Next


rd:

            'все найдено
            _LabelFilePaths.Sort()

            Dim _img As Image
            For Each _path In _LabelFilePaths
                Select Case _LabelFilePaths.Count
                    Case Is < 10
                        _img = clsApplicationTypes.GetAiImageByPath(_path, 200)
                        oNeedLoadBigImage = False
                    Case Else
                        _img = New Bitmap(100, 100)
                        _img.Tag = _path
                        oNeedLoadBigImage = True
                End Select
                If Not _img Is Nothing Then
                    _img.Tag = _path
                    Me.oLabelImages.Add(_img)
                    Me.oLabelImagesWithoutFilter.Add(_img)
                End If
            Next
            ooldBigObjectIndex = 0
        End If
        '-----------------------------
        'список этикеток
        Me.lbxLabelsTypes.Items.Clear()
        'Dim _items = From c In Me.oLabelImages Select clsApplicationTypes.GetLabelType(IO.Path.GetFileNameWithoutExtension(c.Tag.ToString))

        'Dim _it = (From c In _items Where c.Length > 0 Group c By c Into Group Where Group.Count > 0 Select Group.First).ToList

        Dim _result = From c In Me.oLabelImages Let q = clsApplicationTypes.GetLabelType(IO.Path.GetFileNameWithoutExtension(c.Tag.ToString)) Where q.Length > 0 Group q By q Into Group Where Group.Count > 0 Select Group.First

        Me.lbxLabelsTypes.Items.AddRange(_result.ToArray)
        '-----------------------------
        'покажем
        Me.ImageBindingSource.DataSource = oLabelImages
        Me.ImageBindingSource.ResetBindings(False)
        _sp.Hide()
        Me.ImageBindingSource.CurrencyManager.Position = 0
        Me.ImageBindingSource_CurrentChanged(sender, e)

    End Sub

    Private Sub ImageBindingSource_CurrentChanged(sender As Object, e As System.EventArgs) Handles ImageBindingSource.CurrentChanged
        If ImageBindingSource.Current Is Nothing Then Exit Sub
        Dim _obj = ImageBindingSource.Current
        Dim _pos = ImageBindingSource.CurrencyManager.Position
        Me.lbLabelName.Text = ""

        'предыдущая позиция в списке лежит в ooldBigObjectIndex
        Select Case _obj.GetType
            Case GetType(Image), GetType(Bitmap)
                Dim _path As String = _obj.tag

                If _path Is Nothing OrElse _path.Length = 0 Then
                    Me.lbLabelName.Text = "из памяти"
                    GoTo ex
                End If

                Me.lbLabelName.Text = IO.Path.GetFileName(_path)
                'разбор этикетки в событии TextChanged lbLabelName
                If oNeedLoadBigImage Then
                    'подгружаю полный обьект
                    Dim _img As Image = Nothing
                    Select Case IO.Path.GetExtension(CType(_path, String))
                        Case ".ai"
                            'загрузим обьект
                            _img = clsApplicationTypes.GetAiImageByPath(_path, 200)
                        Case ".jpg", ".jpeg", ".png", ".tiff", ".gif", ".bmp", ".tif"
                            'загрузим обьект
                            _img = clsApplicationTypes.GetResizedImageForTree(_path)
                    End Select

                    If _img Is Nothing Then
                        GoTo ex
                    End If

                    _img.Tag = _path
                    oLabelImages.Item(_pos) = _img

                    'сотрем прошлый биг обьект
                    If ooldBigObjectIndex < oLabelImages.Count And Not (_pos = ooldBigObjectIndex) Then
                        Dim _oldPath = oLabelImages.Item(ooldBigObjectIndex).Tag
                        _img = New Bitmap(100, 100)
                        _img.Tag = _oldPath
                        oLabelImages.Item(ooldBigObjectIndex) = Nothing
                        oLabelImages.Item(ooldBigObjectIndex) = _img
                    Else
                        '' Debug.Fail("попытка уничтожить обьект за пределами индекса")
                    End If

                    'запомнить позицию большого обьекта - пометить его на уничтожение
                    ooldBigObjectIndex = _pos
                End If
        End Select
ex:
        ' ImageBindingSource.ResetBindings(False)
        ImageBindingSource.ResetCurrentItem()
        Me.PictureBox1.Image = ImageBindingSource.Current
        Me.PictureBox1.Invalidate()
        Application.DoEvents()

    End Sub

    Private Sub BindingNavigatorDeleteItem_Click(sender As System.Object, e As System.EventArgs) Handles BindingNavigatorDeleteItem.Click
        ' Me.ooldBigObjectIndex = 0
        'Me.oNeedLoadBigImage = False
        'oLabelImages.Clear()
        oLabelImagesWithoutFilter.Clear()
        oLabelImagesWithoutFilter.AddRange(oLabelImages)
        'Me.ImageBindingSource.ResetBindings(False)
        ''зададим шаблон поиска
        'Me.tbPatternSearch.Text = ""
        'Me.SetPatternForLabels()


        'по умолчанию удаляет ImageBindingSource.current из списка
        'Select Case ImageBindingSource.DataSource.GetType
        '    Case GetType(List(Of Image))
        '        Dim _imgPathInTag As String = ImageBindingSource.Current.tag
        '        MsgBox(_imgPathInTag)
        'End Select
    End Sub

    Private Sub BindingNavigatorAddNewItem_Click(sender As System.Object, e As System.EventArgs) Handles BindingNavigatorAddNewItem.Click
        If Me.tbPatternSearch.Text = "" Then Return
        If ImageBindingSource.CurrencyManager.Position = -1 Then Return
        If Me.ImageBindingSource.Current Is Nothing Then Exit Sub

        If Me.ImageBindingSource.Count = 0 Then
            Dim _img = New Bitmap(100, 100)
            Me.oLabelImages.Add(_img)
            Me.oLabelImagesWithoutFilter.Add(_img)
        End If

        Static _InitialDirectory As String
        If _InitialDirectory Is Nothing Then _InitialDirectory = ""


        Dim _curr = CType(Me.ImageBindingSource.Current, Image)
        If _curr.Tag Is Nothing OrElse _curr.Tag = "" Then Return
        Dim _path = IO.Path.GetFullPath(_curr.Tag)



        Dim _fileDialog As New Windows.Forms.OpenFileDialog
        With _fileDialog
            .Title = "Папка для файлов, которые содержат также " & Me.tbPatternSearch.Text
            If _InitialDirectory.Length = 0 Then
                .InitialDirectory = Environment.SpecialFolder.MyComputer
            Else
                .InitialDirectory = _InitialDirectory
            End If
            .Multiselect = True
            .RestoreDirectory = True

        End With

        Select Case _fileDialog.ShowDialog(Me)
            Case DialogResult.OK
                For Each _file In _fileDialog.FileNames
                    If _file.Contains(Me.tbPatternSearch.Text) = False Then
                        Select Case MsgBox("Имя файла или папка " & _file & "  не содержат паттерна " & Me.tbPatternSearch.Text & ", таким образом файл не будет найден при следующем запросе. Добавить паттерн к имени файла? Cancel отменит операцию добавления.", vbQuestion + vbYesNoCancel)
                            Case MsgBoxResult.Yes

                                Dim _add As String
                                If Me.tbPatternSearch.Text.Contains("*") Then
                                    _add = Me.tbPatternSearch.Text.Split("*")(0)
                                Else
                                    _add = Me.tbPatternSearch.Text
                                End If
                                Dim _name = IO.Path.Combine(IO.Path.GetDirectoryName(_path), IO.Path.GetFileNameWithoutExtension(_file) & "_" & _add & IO.Path.GetExtension(_file))
                                My.Computer.FileSystem.CopyFile(_file, _name, FileIO.UIOption.OnlyErrorDialogs, FileIO.UICancelOption.DoNothing)

                            Case MsgBoxResult.No
                                Dim _name = IO.Path.Combine(IO.Path.GetDirectoryName(_path), IO.Path.GetFileName(_file))
                                My.Computer.FileSystem.CopyFile(_file, _name, FileIO.UIOption.OnlyErrorDialogs, FileIO.UICancelOption.DoNothing)
                            Case MsgBoxResult.Cancel

                                Return
                        End Select

                    End If

                Next

                'добавим обьекты в список


                MsgBox("Для имени " & Me.tbPatternSearch.Text & " добавлено " & _fileDialog.FileNames.Count & " файлов. Повторите запрос для отображения совпадающих имен.", vbInformation)
        End Select
    End Sub

    Private Sub lbxLabelsTypes_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lbxLabelsTypes.SelectedIndexChanged
        If lbxLabelsTypes.SelectedItem Is Nothing Then Return
        Dim _result = (From c In oLabelImagesWithoutFilter Let ta = IO.Path.GetFileNameWithoutExtension(c.Tag.ToString) Let res = ta.Contains(lbxLabelsTypes.SelectedItem.ToString) Where res = True Select c).ToList

        Me.oLabelImages = _result
        ImageBindingSource.DataSource = Me.oLabelImages
        ooldBigObjectIndex = 0

    End Sub


    Private Sub rbInnerImg_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbFromDB_Text.CheckedChanged
        Me.ooldBigObjectIndex = 0
        Me.oNeedLoadBigImage = False

        oLabelImages.Clear()
        oLabelImagesWithoutFilter.Clear()
        ooldBigObjectIndex = 0
        Me.ImageBindingSource.ResetBindings(False)
    End Sub

    Private Sub rbExternalLabel_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbLabelFromTrees.CheckedChanged
        Me.ooldBigObjectIndex = 0
        Me.oNeedLoadBigImage = False
        oLabelImages.Clear()
        oLabelImagesWithoutFilter.Clear()
        ooldBigObjectIndex = 0
        Me.ImageBindingSource.ResetBindings(False)
    End Sub

    Private Sub rbDrawAndDescrFolder_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbDrawAndDescrFolder.CheckedChanged
        If sender.Checked Then
            Me.ooldBigObjectIndex = 0
            Me.oNeedLoadBigImage = False
            oLabelImages.Clear()
            oLabelImagesWithoutFilter.Clear()
            ooldBigObjectIndex = 0
            Me.ImageBindingSource.ResetBindings(False)
            'зададим шаблон поиска
            Me.SetPatternForLabels()
        End If
    End Sub
    Private Sub rbImagesFromDrawAndDescrFolder_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbImagesFromDrawAndDescrFolder.CheckedChanged
        If sender.Checked Then
            Me.ooldBigObjectIndex = 0
            Me.oNeedLoadBigImage = False
            oLabelImages.Clear()
            oLabelImagesWithoutFilter.Clear()
            ooldBigObjectIndex = 0
            Me.ImageBindingSource.ResetBindings(False)
            'зададим шаблон поиска
            Me.SetPatternForLabels()
        End If
    End Sub
    Private Sub ToolStripButton2_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton2.Click
        If Me.ImageBindingSource.Current Is Nothing Then
            If IO.Directory.Exists(clsApplicationTypes.LabelDrawDescriptionPath) Then
                System.Diagnostics.Process.Start(clsApplicationTypes.LabelDrawDescriptionPath)
            Else
                MsgBox(String.Format("Каталог {0} не существует", clsApplicationTypes.LabelDrawDescriptionPath), vbCritical)
            End If
            Exit Sub
        End If
        Dim _curr = CType(Me.ImageBindingSource.Current, Image)
        If _curr.Tag Is Nothing OrElse _curr.Tag = "" Then Return
        Dim _path = IO.Path.GetDirectoryName(_curr.Tag)

        If _path.Length > 0 AndAlso IO.Directory.Exists(_path) Then
            System.Diagnostics.Process.Start(_path)
        Else
            MsgBox("Папка не существует или не задана", vbCritical)
        End If
    End Sub
    Private Sub nudWorldCount_ValueChanged(sender As System.Object, e As System.EventArgs) Handles nudWorldCount.ValueChanged
        Me.SetPatternForLabels()
    End Sub

    Private Sub btAddLabel_Click(sender As System.Object, e As System.EventArgs) Handles btAddLabel.Click
        If Me.ImageBindingSource.Current Is Nothing Then Exit Sub
        Dim _imglbl As Image = Me.ImageBindingSource.Current

        If oLabelImageList Is Nothing Then
            oLabelImageList = New List(Of KeyValuePair(Of Image, SizeF))
        End If

        Dim _lbl = clsApplicationTypes.CreatePrintableLabel(_imglbl)

        If _lbl.Value.Width = 0 Then
            MsgBox("Не удалось создать этикетку.В список печати НЕ добавлена!", vbCritical)
        End If
        oLabelImageList.Add(_lbl)
        Me.btPrintLabel.Text = "Печать (" & oLabelImageList.Count & ")"

    End Sub

    Private Sub btPrintLabel_Click(sender As System.Object, e As System.EventArgs) Handles btPrintLabel.Click
        If oLabelImageList Is Nothing Then Exit Sub
        Dim _unit = GraphicsUnit.Millimeter

        Dim _documentToPrint As New Printing.PrintDocument
        Dim _LabelPages As New List(Of clsPage)
        _documentToPrint.DocumentName = "Этикетки"
        _documentToPrint = Service.clsApplicationTypes.PrintLabel(Me.oLabelImageList, True, Me.cbxZoomToPage2.Checked)
        If Not _documentToPrint Is Nothing Then
            Me.PrintPreviewDialog1.Document = _documentToPrint
            Select Case PrintPreviewDialog1.ShowDialog()
                Case Windows.Forms.DialogResult.OK
            End Select
        End If

    End Sub

    Private Sub btPrinterClear_Click(sender As System.Object, e As System.EventArgs) Handles btPrinterClear.Click
        Me.oNeedResetPrinters = True
    End Sub

    Private Sub btClearPrintJob_Click(sender As System.Object, e As System.EventArgs) Handles btClearPrintJob.Click
        If oLabelImageList Is Nothing Then Exit Sub
        oLabelImageList.Clear()
        Me.btPrintLabel.Text = "Печать"
    End Sub

    Private Sub lbxLabelsTypes_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles lbxLabelsTypes.MouseClick
        If lbxLabelsTypes.SelectedItem Is Nothing Then Return
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim _txt = lbxLabelsTypes.SelectedItem.ToString
            '------------------
            Dim _data As String = _txt
            Try
                My.Computer.Clipboard.Clear()
                My.Computer.Clipboard.SetText(_data)
            Catch ex As Exception
                MsgBox("Ошибка при помещении данных в буфер обмена.", vbCritical)
            End Try
            '-----------------
        End If
    End Sub

    Private Sub lbLabelName_TextChanged(sender As Object, e As System.EventArgs) Handles lbLabelName.TextChanged
        'тут разберем из имени файла тип этикетки
        Dim _name = IO.Path.GetFileNameWithoutExtension(lbLabelName.Text)
        If _name = "" Then Return
        ' Me.lbLabelType.Text = clsApplicationTypes.GetLabelType(_name)
    End Sub

#Region "Drag Этикетка"

    Private odragBoxFromMouseDown As Rectangle
    Private oSource As emLabelSource

    Private Sub pbLabel_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseDown

        ' Remember the point where the mouse down occurred. The DragSize indicates
        ' the size that the mouse can move before a drag event should be started.                
        Dim dragSize As Size = SystemInformation.DragSize

        ' Create a rectangle using the DragSize, with the mouse position being
        ' at the center of the rectangle.
        odragBoxFromMouseDown = New Rectangle(New Point(e.X - (dragSize.Width / 2), _
                                                        e.Y - (dragSize.Height / 2)), dragSize)

    End Sub

    Private Sub pbLabel_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseMove
        If ((e.Button And MouseButtons.Left) = MouseButtons.Left) Then

            ' If the mouse moves outside the rectangle, start the drag.
            If (Rectangle.op_Inequality(odragBoxFromMouseDown, Rectangle.Empty) And _
                Not odragBoxFromMouseDown.Contains(e.X, e.Y)) Then

                'variant 1
                'Dim _obg As New DataObject
                '_obg.SetData(DataFormats.Dib, True, pbLabel.Image)
                'pbLabel.DoDragDrop(_obg, DragDropEffects.Copy)
                'variant 2 --OK!!
                If sender.image Is Nothing Then Return
                Dim ms As New IO.MemoryStream
                Dim ms2 As New IO.MemoryStream
                clsApplicationTypes.ResizeLabelForClipboard(sender.Image).Save(ms, ImageFormat.Bmp)
                Dim bytes() As Byte = ms.GetBuffer
                ms2.Write(bytes, 14, CInt(ms.Length - 14))
                ms.Position = 0
                Dim obj As New DataObject
                obj.SetData("DeviceIndependentBitmap", ms2)
                sender.DoDragDrop(obj, DragDropEffects.Copy)
                ms.Close()
                ms2.Close()

                'variant 3
                '                // declarations
                '[DllImport("user32.dll")]
                'static extern IntPtr SetClipboardData(uint uFormat, IntPtr hMem);

                '[DllImport("user32.dll")]
                'static extern bool OpenClipboard(IntPtr hWndNewOwner);

                '[DllImport("user32.dll")]
                'static extern bool EmptyClipboard();

                '[DllImport("user32.dll")]
                'static extern bool CloseClipboard();

                'public static uint CF_ENHMETAFILE = 14;

                '...

                'Bitmap img = (Bitmap)Bitmap.FromFile(@"c:\TestImage.jpg",true);
                '// create graphics object for metafile
                'Graphics g = CreateGraphics();
                'IntPtr hdc = g.GetHdc();
                'Metafile meta = new Metafile(@"SampleMetafilegdiplus.emf", hdc );
                'g.ReleaseHdc(hdc);
                'g.Dispose();
                '// create a metafile image from the jpeg image
                'g = Graphics.FromImage(meta);
                'g.DrawImage(img, new Point(0,0));
                'g.Dispose();
                '// get a handle to the metafile
                'IntPtr hEmf = meta.GetHenhmetafile();
                'meta.Dispose();
                '// open the clipboard
                'OpenClipboard(this.Handle); // your Form's Window handle
                'EmptyClipboard();
                '// place the handle to the metafile on to the clipboard
                'SetClipboardData(CF_ENHMETAFILE, hEmf);
                'CloseClipboard();
            End If
        End If
    End Sub


    Private Sub pbLabel_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseUp
        ' Reset the drag rectangle when the mouse button is raised.
        odragBoxFromMouseDown = Rectangle.Empty
    End Sub

#End Region

End Class
