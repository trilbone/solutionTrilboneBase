Imports Service.clsApplicationTypes
Imports Service
Imports System.Linq
Imports Service.clsFilesSources


Public Class fmImageManager
    Private oSampleNumber As Service.clsApplicationTypes.clsSampleNumber
    Private WithEvents oPhotoDriveObj As Service.clsSamplePhotoManager
    ' Private oActiveFolder As String = ""
   
    ''' <summary>
    ''' показать увеличенное изображение. Вернет да, если были изменения в фотках
    ''' </summary>
    ''' <remarks></remarks>
    Private Function ShowImageForm(Source As clsFilesSources, ImageKey As String) As Boolean
        Dim _prm As Object = Service.clsApplicationTypes.SamplePhotoObject.GetImageCollection(oSampleNumber, Source, False)

        If _prm Is Nothing Then
            MsgBox("невозможно показать форму")
        End If


        Dim _fmImage As Form
        'show image form
        'использование сервисов
        'по запросу выполняем вызов из сервиса

        Dim _param As Object = {_prm, ImageKey}

        'если делегата нет, то сервис недоступен
        If Not Global.Service.clsApplicationTypes.DelegateStoreApplicationForm(Service.clsApplicationTypes.emFormsList.fmImage) Is Nothing Then
            'сервис зарегестрирован - вызываем
            _fmImage = Global.Service.clsApplicationTypes.DelegateStoreApplicationForm(Service.clsApplicationTypes.emFormsList.fmImage).Invoke(_param)
            If Not _fmImage Is Nothing Then
                'show form
                _fmImage.Width = 640
                _fmImage.Height = 480

                _fmImage.Name = "ImageShowForm"
                _fmImage.StartPosition = FormStartPosition.CenterScreen

                'привязка обработчика
                Me.oCurrentSource = Source
                Service.clsApplicationTypes.DelegatStorefmImageDeleteDelegate = New Service.clsApplicationTypes.fmImageDeleteDelegat(AddressOf DelImage_eventHandler)
                Service.clsApplicationTypes.DelegatStorefmImageCopyDelegate = New Service.clsApplicationTypes.fmImageCopyDelegat(AddressOf CopyImage_eventHandler)

                _fmImage.ShowDialog()
                Return CType(_fmImage, fmImage).HasChanges
            End If

        End If
        Return False

    End Function
    Private oCurrentSource As clsFilesSources

    Private Sub DelImage_eventHandler(ByVal sender As Object, ByVal e As Service.clsApplicationTypes.fmImageDelEventArg)
        If e.ImageNames.Count = 0 Then Exit Sub
        'удалить изображения, список имен в аргументе
        Dim _coll(e.ImageNames.Count - 1) As String
        e.ImageNames.CopyTo(_coll, 0)
        Dim _count As Integer = Service.clsApplicationTypes.SamplePhotoObject.DeleteImagesFromSource(Me.oSampleNumber, oCurrentSource, _coll, False, False)
        MsgBox("Удалено " & _count & " фото с устройства " & oCurrentSource.ToString(), vbInformation)
        Service.clsApplicationTypes.DelegatStorefmImageDeleteDelegate = Nothing
    End Sub
    Private Sub CopyImage_eventHandler(ByVal sender As Object, ByVal e As Service.clsApplicationTypes.fmImageCopyEventArg)
        If e.ImageNames.Length = 0 Then Exit Sub

        'скопировать изображения, список имен в аргументе
        'Dim _tmpSample As Decimal = Me.Dgv_SamplesINOrders.CurrentRow.Cells(0).Value
        'Dim _filesrc = clsFilesSources.CreateInstance(Service.clsFilesSources.emSources.SpecificOrder, Me.oCurrentOrder)
        Dim _sampleNumber = Me.oSampleNumber

        'задать устройство принимающее
        Dim _Tosource As clsFilesSources = oCurrentSource

        'задать устройство источник
        Dim _Fromsource As clsFilesSources = clsFilesSources.CreateInstance(Service.clsFilesSources.emSources.FreeFolder, , False, e.ImagesPath)


        'вычислить оптимизацию
        Dim _optimize As Integer = 1024
        Dim _message As String = "Копировать " & e.ImageNames.Length & " файлов "
        _message += "с оптимизацией по длинной стороне " & _optimize.ToString & "?"
        'задать вопрос
        Select Case MsgBox(_message, MsgBoxStyle.YesNo)
            Case MsgBoxResult.Yes
                'копировать
                Dim _count As Integer = Service.clsApplicationTypes.SamplePhotoObject.CopyImagesFromSourceToSource(_sampleNumber, _Fromsource, _Tosource, False, e.ImageNames, _optimize)
                MsgBox(_count & " фото скопированы для образца " & _sampleNumber.GetEan13 & " в уст-во " & Me.oCurrentSource.ToString(), vbInformation)
            Case MsgBoxResult.No
                Exit Sub
        End Select



    End Sub

    Public Sub New()

        ' Этот вызов является обязательным для конструктора.
        InitializeComponent()

        ' Добавьте все инициализирующие действия после вызова InitializeComponent().

        'заполнить список устройств
        Me.cbSelectSource_Left.Items.Add(clsFilesSources.Arhive())
        Me.cbSelectSource_Left.Items.Add(clsFilesSources.AZURE)
        Me.cbSelectSource_Left.SelectedIndex = -1

        'заполнить второй список устройств
        Me.cbSelectSource2_Right.Items.Add(clsFilesSources.Arhive())
        Me.cbSelectSource2_Right.Items.Add(clsFilesSources.AZURE)
        Me.cbSelectSource2_Right.Items.Add(clsFilesSources.FTPinfoTRILBONE)
        Me.cbSelectSource2_Right.SelectedIndex = -1
        init()
      
    End Sub

    Public Sub New(filesource As clsFilesSources, samplenumber As clsSampleNumber)
        InitializeComponent()
        init()
        Me.cbSelectSource_Left.Items.Add(filesource)
        Me.cbSelectSource_Left.SelectedItem = filesource
        Me.tbSampleNumber.Text = samplenumber.ShotCode
        btCheckNumber_Click(Me, EventArgs.Empty)
    End Sub

    Public Sub New(SampleNumber As clsSampleNumber)
        Me.New()
        ' Me.oSampleNumber = SampleNumber
        Me.tbSampleNumber.Text = SampleNumber.ShotCode
     
        btCheckNumber_Click(Me, EventArgs.Empty)
    End Sub

    Private Sub init()
        oPhotoDriveObj = Service.clsApplicationTypes.SamplePhotoObject
        'заполнить список оптимизации
        Me.cbOptimization.Items.Add("not")
        Me.cbOptimization.Items.Add("1600")
        Me.cbOptimization.Items.Add("2048")
        Me.cbOptimization.SelectedIndex = 0

        For Each _ctl As Control In Me.Controls
            _ctl.Enabled = False
        Next

        Me.tbSampleNumber.Enabled = True
        Me.btCheckNumber.Enabled = True
        Me.ToolStripStatusLabel1.Text = ""
    End Sub


    Private Sub btSelectFolder_Click(sender As System.Object, e As System.EventArgs) Handles btSelectFolder.Click
        'выбрать или создать устройство из папки
        Me.SelectFolder()
        'проверить наличие в списке
        Dim _res = (From c As clsFilesSources In cbSelectSource2_Right.Items Where c.Source = emSources.FreeFolder And c.ContainerPath = Me.lbActivePath.Text Select c).FirstOrDefault
        If Not _res Is Nothing Then
            'устройство уже есть в списке
            Me.cbSelectSource2_Right.SelectedItem = _res
        Else
            'устройства нет в списке
            Dim _res2 = (From c As clsFilesSources In cbSelectSource2_Right.Items Where c.Source = emSources.FreeFolder Select c).ToList
            For Each c In _res2
                Me.cbSelectSource2_Right.Items.Remove(c)
            Next
            Dim _new = clsFilesSources.CreateInstance(emSources.FreeFolder, Nothing, False, Me.lbActivePath.Text, False)
            Me.cbSelectSource2_Right.Items.Add(_new)
            Me.cbSelectSource2_Right.SelectedItem = _new
        End If

        btSourceView_Right_Click(sender, e)

    End Sub

    Public WriteOnly Property ActiveFolder As String
        Set(value As String)
            'Me.oActiveFolder = value
            Me.lbActivePath.Text = value
            'Me.lbActivePath.Text = PhotoManagerStarUpFolder
            'Me.btFolderView_Click(Me, New EventArgs)
        End Set

    End Property
    Private Sub UnlockAll()
        For Each _ctl As Control In Me.Controls
            _ctl.Enabled = True
        Next
        'clear controls
        Me.oSampleNumber = Nothing
        'Me.lbxSourcesList.Items.Clear()
        Me.lvSource.Items.Clear()
        Me.lvFolder.Items.Clear()
        Me.pbMainImage.Image = Nothing
        Me.pbMainImage2.Image = Nothing
        Me.ActiveFolder = ""
        Me.lbSampleInfoText.Text = ""
        Me.lbCountImages.Text = "нет фото?"
    End Sub

    Private Sub btCheckNumber_Click(sender As System.Object, e As System.EventArgs) Handles btCheckNumber.Click
        Dim _sp = New SplashScreen1
        Dim _clsn As clsSampleNumber = clsSampleNumber.CreateFromString(Me.tbSampleNumber.Text)
        If _clsn Is Nothing Then
            Me.ToolStripStatusLabel1.Text = "Неправильный номер"
            MsgBox("Неправильный номер", vbCritical)
            Me.tbSampleNumber.SelectAll()
            GoTo ex
        End If

        'number is correct
        UnlockAll()

        Me.tbSampleNumber.Text = _clsn.EAN13
        Me.oSampleNumber = _clsn
        Me.ToolStripStatusLabel1.Text = _clsn.EAN13 & " - получение данных..."
        Me.Enabled = False

        _sp.StartPosition = FormStartPosition.CenterScreen

        _sp.Show(Me)
        Application.DoEvents()

        Select Case clsApplicationTypes.GetAccess("Доступ к заказам")
            Case True
                'вывести инфо о камне
                Dim _info As String = ""
                Dim _param As clsSampleNumber = Me.oSampleNumber
                Dim _status As Integer
                'если делегата нет, то сервис недоступен
                If Not Global.Service.clsApplicationTypes.DelegateStoreGetSampleInfoText Is Nothing Then
                    'сервис зарегестрирован - вызываем 
                    _info = Global.Service.clsApplicationTypes.DelegateStoreGetSampleInfoText.Invoke(_param, Globalization.CultureInfo.CreateSpecificCulture("en-US"), _status)
                Else
                    _info = "Ошибка при получении значения из сервиса"
                End If
                Me.lbSampleInfoText.Text = _info
            Case Else
                ' MsgBox("Нет доступа: " & "Доступ к заказам", vbCritical)
                Me.lbSampleInfoText.Text = ""
                Me.lbSampleInfoText.Enabled = False
        End Select

        'проверка на наличие фото для этого образца на устройствах
        If Me.GetSourcesListBySampleNumber() Then
            'выбрать arhive или первое
            Dim _res = (From c As clsFilesSources In Me.cbSelectSource_Left.Items Where c.Source = emSources.Arhive Select c).FirstOrDefault
            Dim _flag As Integer = Me.cbSelectSource_Left.SelectedIndex
            If _res Is Nothing Then
                Me.cbSelectSource_Left.SelectedIndex = 0
            Else
                Me.cbSelectSource_Left.SelectedItem = _res
            End If

            If Me.cbSelectSource_Left.SelectedIndex = _flag Then
                Me.btSourceLeftView_Click(sender, e)
            End If

            clsApplicationTypes.BeepYES()
        Else
            ' фото нет
            Me.lbSampleInfoText.Text = "ФОТО НЕТ  " & Me.lbSampleInfoText.Text
            Me.cbSelectSource_Left.SelectedIndex = 0
            Me.ToolStripStatusLabel1.Text = _clsn.EAN13 & " - данные получены"
        End If
ex:
        If Not _sp Is Nothing Then
            _sp.Close()
        End If
        Me.Enabled = True
        Me.Activate()

    End Sub
    ''' <summary>
    ''' копирование в устройство
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btCopyToSource_Click(sender As System.Object, e As System.EventArgs) Handles btCopyToSource.Click
        'получить список файлов копирования
        Dim _coll As New List(Of String)
        Dim _arr() As String = {}

        For Each _tmp As ListViewItem In Me.lvFolder.CheckedItems
            _coll.Add(_tmp.Name)
        Next
        ReDim _arr(_coll.Count - 1)
        _coll.CopyTo(_arr, 0)

        Me.ToolStripStatusLabel1.Text = Me.oSampleNumber.EAN13 & " - копирование из " & Me.cbSelectSource2_Right.SelectedItem.ToString & " в " & Me.cbSelectSource_Left.SelectedItem.ToString
        Dim _status = Me.CopyFiles(_arr, Me.cbSelectSource2_Right.SelectedItem, Me.cbSelectSource_Left.SelectedItem)

        Select Case _status
            Case Is > 0
                Me.ToolStripStatusLabel1.Text = Me.oSampleNumber.EAN13 & " - файлы скопированы"
                'снять флажки с скопированных
                For Each _tmp As ListViewItem In Me.lvFolder.CheckedItems
                    _tmp.Checked = False
                Next


                'обновить список
                btSourceLeftView_Click(Me, New EventArgs)
            Case 0
                Me.ToolStripStatusLabel1.Text = Me.oSampleNumber.EAN13 & " - файлы НЕ скопированы!"

            Case -1
                Me.ToolStripStatusLabel1.Text = Me.oSampleNumber.EAN13 & " - ошибка при копировании файлов"

        End Select






    End Sub
    ''' <summary>
    ''' запрашивает список устройств с фото. вернет да или нет
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetSourcesListBySampleNumber() As Boolean
        ''обновить устройства 
        Me.lbxSourcesList.DataSource = Nothing
        'проверка на наличие фото для этого образца
        Dim _listsources = Me.oPhotoDriveObj.GetSourcesList(Me.oSampleNumber, Me.cbxRemoteConnections.Checked)
        Me.lbxSourcesList.DataSource = _listsources
        Me.lbxSourcesList.Refresh()
        If _listsources.Count = 0 Then Return False

        For Each t In _listsources
            If Not Me.cbSelectSource_Left.Items.Contains(t) Then
                Me.cbSelectSource_Left.Items.Add(t)
            End If
        Next

        Return True
   
    End Function


    ' ''' <summary>
    ' ''' копирует главное фото на устройство
    ' ''' </summary>
    ' ''' <param name="FileName"></param>
    ' ''' <returns></returns>
    ' ''' <remarks></remarks>
    'Private Overloads Function CopyFiles(ByVal FileName As String) As Boolean
    '    'задать устройство принимающее
    '    Dim _Tosource As clsFilesSources = Me.cbSelectSource_Left.SelectedItem
    '    'задать источник
    '    Dim _Fromsource As clsFilesSources = Me.cbSelectSource_Left.SelectedItem

    '    Dim _optimize As Integer = 160
    '    If clsApplicationTypes.SamplePhotoObject.CopyImagesFromSourceToSource(Me.oSampleNumber, _Fromsource, _Tosource, False, {FileName}, _optimize) = 1 Then Return True
    '    Return False

    'End Function


    '
    '''<summary>копирует файлы на устройство</summary>
    ''' <param name="FileNames"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Overloads Function CopyFiles(ByVal FileNames() As String, Fromsource As clsFilesSources, Tosource As clsFilesSources) As Integer
        'задать устройство принимающее
        'Dim _Tosource As clsFilesSources = clsFilesSources.CreateInstance(Me.cbSelectSource.SelectedItem)
        'Dim _Fromsource As clsFilesSources = clsFilesSources.CreateInstance(Service.clsFilesSources.emSources.FreeFolder, , False, Me.ActiveFolder)
        If FileNames Is Nothing OrElse FileNames.Length = 0 Then
            MsgBox("Фото не выбраны!", vbCritical)
            Return 0
        End If

        Dim _optimize As Integer = 0
        Dim _message As String = "Копировать " & FileNames.Length & " файлов "
        'включить обязательную оптимизацию
        If Tosource.Source = emSources.Arhive Or Tosource.Source = emSources.AZURE Then
            Me.cbOptimization.SelectedItem = "1600"
            _message += "c  обязательной "
        Else
            _message += "c "
        End If

        'вычислить оптимизацию

        If Not Me.cbOptimization.SelectedItem = "not" Then
            If Integer.TryParse(Me.cbOptimization.SelectedItem, _optimize) = False Then
                Debug.Fail("Неправильное значение в текстбоксе. Допустимо только целое число.")
            End If
            _message += "оптимизацией по длинной стороне " & _optimize.ToString & "?"
        Else
            _message = "Копировать " & FileNames.Length & " файлов " & "без изменения размера?"
        End If

        'задать вопрос
        Select Case MsgBox(_message, MsgBoxStyle.YesNo)
            Case MsgBoxResult.Yes
                'копировать
                Return clsApplicationTypes.SamplePhotoObject.CopyImagesFromSourceToSource(Me.oSampleNumber, Fromsource, Tosource, False, FileNames, _optimize, True)

            Case MsgBoxResult.No
                Return 0
        End Select
        Return -1


    End Function

    Private Sub btDeleteFromSource_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btDeleteFromSource.Click
        If Me.cbSelectSource_Left.SelectedItem Is Nothing Then Return
        Me.DeleteFiles(Me.lvSource, Me.cbSelectSource_Left.SelectedItem)
    End Sub

    Private Sub DeleteFiles(fromList As Windows.Forms.ListView, source As clsFilesSources)
        If source Is Nothing Then Return
        'получить список файлов 
        Dim _coll As New List(Of String)
        Dim _arr() As String = {}
        Dim _delColl As New List(Of ListViewItem)

        For Each _tmp As ListViewItem In fromList.CheckedItems
            _coll.Add(_tmp.Name)
            _delColl.Add(_tmp)
        Next
        ReDim _arr(_coll.Count - 1)
        _coll.CopyTo(_arr, 0)

        Dim _status As Integer

        Dim _message As String = "Удалить " & _arr.Length & " фото с устройства " & source.ToString() & " ?"
        'задать вопрос
        Select Case MsgBox(_message, MsgBoxStyle.YesNo)
            Case MsgBoxResult.Yes
                'удалить
                _status = clsApplicationTypes.SamplePhotoObject.DeleteImagesFromSource(Me.oSampleNumber, source, _arr, False, False)
                Me.GetSourcesListBySampleNumber()
            Case MsgBoxResult.No
                _status = 0
        End Select

        Select Case _status
            Case -1
                'error
                MsgBox("ошибка при удалении. фото не удалены", vbCritical)
                _delColl.Clear()
            Case Is > 0
                'удалим их из списка
                For Each _tmp As ListViewItem In _delColl
                    Dim _key = _tmp.Name
                    fromList.Items.Remove(_tmp)
                    If Not CType(fromList.Tag, Service.SampleSourceImageList).RemoveImageItem(_key) Then
                        Debug.Fail("не удалось удалить элемент из списка SampleSourceImageList")
                    End If
                Next
                _delColl.Clear()
                MsgBox("Удалено " & _status & " фото с устройства " & source.ToString(), vbInformation)

            Case 0
                MsgBox("не удалено ни одного фото", vbInformation)
                _delColl.Clear()
        End Select

    End Sub

    ''' <summary>
    ''' показывает файлы на устройстве
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btSourceLeftView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSourceShow_Left.Click
        If Me.cbSelectSource_Left.SelectedItem Is Nothing Then Return
        Me.ToolStripStatusLabel1.Text = Me.oSampleNumber.EAN13 & " - получение фото из " & Me.cbSelectSource_Left.SelectedItem.ToString & "..."
        Me.FillList(Me.cbSelectSource_Left.SelectedItem, Me.lvSource)
        Me.pbMainImage.Image = Me.oPhotoDriveObj.GetMainImage(Me.cbSelectSource_Left.SelectedItem, Me.oSampleNumber)
        Me.ToolStripStatusLabel1.Text = Me.oSampleNumber.EAN13 & " - фото получены"
        Me.lbCountImages.Text = Me.lvSource.Items.Count
    End Sub
    ''' <summary>
    ''' отобразить фото из папки
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btSourceView_Right_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSourceShow_Right.Click
        If Me.cbSelectSource2_Right.SelectedItem Is Nothing Then Return
       
        Me.ToolStripStatusLabel1.Text = Me.oSampleNumber.EAN13 & " - получение фото из " & Me.cbSelectSource2_Right.SelectedItem.ToString() & "..."
        Me.FillList(Me.cbSelectSource2_Right.SelectedItem, Me.lvFolder)
        Me.pbMainImage2.Image = Me.oPhotoDriveObj.GetMainImage(Me.cbSelectSource2_Right.SelectedItem, Me.oSampleNumber)
        Me.ToolStripStatusLabel1.Text = Me.oSampleNumber.EAN13 & " - фото получены"
       
    End Sub

    Private Sub btSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSourceSelectAll.Click

        For Each _tmpItem As ListViewItem In Me.lvSource.Items
            _tmpItem.Checked = True
        Next

    End Sub

    Private Sub btDeselectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSourceDeselectAll.Click
        For Each _tmpItem As ListViewItem In Me.lvSource.Items
            _tmpItem.Checked = False
        Next
    End Sub


    Private Sub cbSelectSource_Left_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbSelectSource_Left.SelectedIndexChanged
        Me.lvSource.Items.Clear()
        Me.pbMainImage.Image = Nothing
        If Me.cbSelectSource_Left.SelectedItem Is Nothing Then Return
        'задать левое активное устройство
        If Not Me.oSampleNumber Is Nothing Then
            Me.btSourceLeftView_Click(Me, New EventArgs)
        End If
    End Sub

    Private Sub FillList(ByVal Source As clsFilesSources, ByVal _Control As ListView)
        Dim _tmpImageList = Me.oPhotoDriveObj.GetSampleImageList(Me.oSampleNumber, Source, New Size(160, 120), False)
        If _tmpImageList Is Nothing Then Return

        If _tmpImageList.CountImages = 0 Then
            If Not Me.lbActivePath.Text = "" Then
                Dim _message As String = _tmpImageList.FileSource.ToString() + " - на устройстве фото образца нет!"
                MsgBox(_message, vbCritical)
            End If
            Return
        End If

        'тут надо восстановить папку, записанную в сеттингс
        ' Me.lbActivePath.Text = PhotoManagerStarUpFolder

        With _Control
            .BeginUpdate()
            .ListViewItemSorter = Me.oPhotoDriveObj.GetListViewComparier
            .View = View.LargeIcon
            .Clear()
            For Each t In _tmpImageList.ListViewItems
                t.Remove()
            Next
            .Items.AddRange(_tmpImageList.ListViewItems)
            .SmallImageList = _tmpImageList.ImageList
            .LargeImageList = _tmpImageList.ImageList
            'тут лежит ссылка на SampleSourceImageList
            .Tag = _tmpImageList
            .EndUpdate()
        End With
        'вычислить максимальный размер изображения
        'Внимание Размер обьекта определяется функцией ConverToObject clsIDcontent
        If _tmpImageList.Images.Count > 0 Then
            Dim _imageWight = Aggregate c In _tmpImageList.Images Into Max(c.Width)

            If _Control.Equals(Me.lvSource) Then
                Me.LbImageWidth.Text = "<<Ширина MAX = " & _imageWight
            Else
                Me.LbImageWidth.Text = ">>Ширина MAX = " & _imageWight
            End If
            If _imageWight > 1600 Then
                'имеются фото с шириной более оптимальной
                Me.LbImageWidth.ForeColor = Color.Red
            Else
                Me.LbImageWidth.ForeColor = Windows.Forms.Control.DefaultForeColor
            End If
        Else
            Me.LbImageWidth.Text = "Нет фото"
        End If

    End Sub

    Private Sub btFolderSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btFolderSelectAll.Click
        For Each _tmpItem As ListViewItem In Me.lvFolder.Items
            _tmpItem.Checked = True
        Next
    End Sub

    Private Sub btFolderDeselectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btFolderDeselectAll.Click
        For Each _tmpItem As ListViewItem In Me.lvFolder.Items
            _tmpItem.Checked = False
        Next
    End Sub

    Private Sub tbSampleNumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbSampleNumber.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Me.btCheckNumber_Click(Me, New EventArgs)
        End If
    End Sub

    Private Sub lvFolder_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvFolder.DoubleClick
        If sender.SelectedItem Is Nothing Then Return
        If cbSelectSource2_Right.SelectedItem Is Nothing Then Return
        Dim _source As clsFilesSources = CType(cbSelectSource2_Right.SelectedItem, clsFilesSources)
        'Select Case CType(cbSelectSource2_Right.SelectedItem, clsFilesSources).Source
        '    Case emSources.FreeFolder
        '        _source = clsFilesSources.CreateInstance(Service.clsFilesSources.emSources.FreeFolder, , , oActiveFolder)
        '    Case emSources.SpecificOrder
        '        '03.04.2013
        '        Exit Sub
        '    Case Else
        '        _source = clsFilesSources.CreateInstance(cbSelectSource2_Right.SelectedItem)
        'End Select

        If Me.ShowImageForm(_source, sender.SelectedItems.Item(0).Name) Then
            Me.btSourceView_Right_Click(sender, e)
        End If
    End Sub
    Private Sub lvSource_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvSource.DoubleClick
        If sender.SelectedItems.Count = 0 Then Exit Sub
        Dim _source As clsFilesSources = cbSelectSource_Left.SelectedItem
        If Me.ShowImageForm(_source, sender.SelectedItems.Item(0).Name) Then
            Me.btSourceLeftView_Click(sender, e)
        End If

    End Sub
    Private oPrivedDrag As Boolean
    Private Sub lvSource_DragEnter(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles lvSource.DragEnter
        If oPrivedDrag Then
            e.Effect = e.AllowedEffect
        End If
    End Sub

    Private Sub lvSource_DragOver(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles lvSource.DragOver
        Return
        'Dim _dragitem = CType(e.Data.GetData(GetType(ListViewItem)), ListViewItem)


        'Dim _pos = lvSource.PointToClient(New Point(e.X, e.Y))
        'Dim _hit = lvSource.HitTest(_pos)
        'If _hit.Item Is Nothing Then Return
        'If _hit.Item Is _dragitem Then Return


        'Dim _source = _dragitem.Text
        '' _hit.Item  - это цель
        'Dim _target = _hit.Item.Text

        'Dim _comp = oPhotoDriveObj.GetListViewComparier

        'Select Case _comp.Compare(_dragitem, _hit.Item)
        '    Case 0

        '    Case Is > 0
        '        'источник больше чем цель
        '        Dim _status As Boolean
        '        Dim _res = clsConnectionBase.CompareKeyNames({_dragitem.Text, _hit.Item.Text}.ToList, _status)
        '        If _status Then
        '            Dim _tmp = _res(0).Value
        '            _hit.Item.Text = Decimal.Parse(_res(1).Value) + 1 & clsConnectionBase._cntSplitter & _res(1).Key
        '            _dragitem.Text = Decimal.Parse(_res(0).Value) - 1 & clsConnectionBase._cntSplitter & _res(0).Key
        '            'запись новых значений
        '            'Me.oPhotoDriveObj.RenameImage(Me.cbSelectSource_Left.SelectedItem, oSampleNumber, _source, _dragitem.Text)
        '            'Me.oPhotoDriveObj.RenameImage(Me.cbSelectSource_Left.SelectedItem, oSampleNumber, _target, _hit.Item.Text)

        '        End If

        '    Case Is < 0
        '        'источник меньше чем цель
        '        Dim _status As Boolean
        '        Dim _res = clsConnectionBase.CompareKeyNames({_dragitem.Text, _hit.Item.Text}.ToList, _status)
        '        If _status Then
        '            Dim _tmp = _res(0).Value
        '            _hit.Item.Text = _res(1).Value & clsConnectionBase._cntSplitter & _res(0).Key
        '            _dragitem.Text = _res(0).Value & clsConnectionBase._cntSplitter & _res(1).Key
        '            'запись новых значений
        '            'Me.oPhotoDriveObj.RenameImage(Me.cbSelectSource_Left.SelectedItem, oSampleNumber, _source, _dragitem.Text)
        '            'Me.oPhotoDriveObj.RenameImage(Me.cbSelectSource_Left.SelectedItem, oSampleNumber, _target, _hit.Item.Text)

        '        End If
        'End Select
        ' ''запись новых значений
        ''Me.oPhotoDriveObj.RenameImage(Me.cbSelectSource_Left.SelectedItem, oSampleNumber, _source, _dragitem.Text)
        ''Me.oPhotoDriveObj.RenameImage(Me.cbSelectSource_Left.SelectedItem, oSampleNumber, _target, _hit.Item.Text)

        'lvSource.ListViewItemSorter = oPhotoDriveObj.GetListViewComparier


        'If Not _hit.Item Is Nothing Then
        '    _pos = lvSource.PointToClient(New Point(Control.MousePosition.X, Control.MousePosition.Y))
        '    Dim destItem As ListViewItem = (lvSource.GetItemAt(_pos.X, _pos.Y))

        '    If Not _dragitem Is destItem Then

        '        Dim a = "5"

        '    End If

        'End If

    End Sub

    Private Sub lvSource_ItemDrag(sender As Object, e As System.Windows.Forms.ItemDragEventArgs) Handles lvSource.ItemDrag
        oPrivedDrag = True
        DoDragDrop(e.Item, DragDropEffects.Move)
        oPrivedDrag = False
    End Sub

    Private Sub lvSource_ItemSelectionChanged(sender As Object, e As System.Windows.Forms.ListViewItemSelectionChangedEventArgs) Handles lvSource.ItemSelectionChanged
        'вычислить максимальный размер изображения
        'Внимание Размер обьекта определяется функцией ConverToObject clsIDcontent
        Dim _key = e.Item.Text
        If Not CType(lvSource.Tag, Service.SampleSourceImageList).Item(_key) Is Nothing Then
            Dim _imageWight = CType(lvSource.Tag, Service.SampleSourceImageList).Item(_key).Width

            Me.LbImageWidth.Text = "<<Ширина " & _key & " = " & _imageWight
            If _imageWight > 1600 Then
                'фото с шириной более оптимальной
                Me.LbImageWidth.ForeColor = Color.Red
            Else
                Me.LbImageWidth.ForeColor = Windows.Forms.Control.DefaultForeColor
            End If

        End If
    End Sub

    ''' <summary>
    ''' задать главное фото нажатием клавиши м
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub lvSource_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles lvSource.KeyPress
        If Char.ToString(e.KeyChar) = "m" Or Char.ToString(e.KeyChar) = "M" Or Char.ToString(e.KeyChar) = "ь" Or Char.ToString(e.KeyChar) = "Ь" Then
            If Me.lvSource.SelectedItems.Count = 0 Then
                MsgBox("Необходимо выделить фото, чтобы задать его главным", vbCritical)
                Exit Sub
            End If
            'задать главное фото
            Dim _imgName As String = lvSource.SelectedItems(0).Name
            If MsgBox("Задать слева главное фото " & _imgName & " ?", MsgBoxStyle.Question) = MsgBoxResult.No Then
                Exit Sub
            End If

            'записать на устройство
            'задать устройство принимающее
            'Dim _source As clsFilesSources = clsFilesSources.CreateInstance(Me.cbSelectSource.SelectedItem)
            If Not clsApplicationTypes.SamplePhotoObject.CreateMainImageOnSource(Me.oSampleNumber, _imgName, Me.cbSelectSource_Left.SelectedItem) Then
                Debug.Fail("Главное фото не скопировано!")
            Else
                'обновить вывод
                btSourceLeftView_Click(sender, e)
            End If
        End If

    End Sub

    Private Sub cbSelectSource2_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbSelectSource2_Right.SelectedIndexChanged
        If Me.cbSelectSource2_Right.SelectedItem Is Nothing Then Return
        Me.lvFolder.Items.Clear()
        Me.pbMainImage2.Image = Nothing

        If CType(Me.cbSelectSource2_Right.SelectedItem, clsFilesSources).Source = emSources.FreeFolder Then
            Me.lbActivePath.Text = CType(Me.cbSelectSource2_Right.SelectedItem, clsFilesSources).ContainerPath
        End If

        If Not Me.oSampleNumber Is Nothing Then
            Me.btSourceView_Right_Click(Me, New EventArgs)
        End If

    End Sub

    Private Sub SelectFolder()
        Me.lvFolder.Items.Clear()
      
        'проверить наличие папки

        Dim _folder As String = IO.Path.Combine(PhotoManagerStarUpFolder, clsSampleNumber.GetShotCodeByFull(Me.tbSampleNumber.Text))

        If IO.Directory.Exists(_folder) Then
            Me.lbActivePath.Text = _folder
        ElseIf IO.Directory.Exists(PhotoManagerStarUpFolder) Then
            Me.lbActivePath.Text = PhotoManagerStarUpFolder
        Else

            Select Case Me.FolderBrowserDialog1.ShowDialog()
                Case Windows.Forms.DialogResult.OK
                    Me.lbActivePath.Text = Me.FolderBrowserDialog1.SelectedPath
                Case Else
            End Select
        End If

    End Sub

    Private Sub btDeleteFromSource2_Click(sender As System.Object, e As System.EventArgs) Handles btDeleteFromSource2.Click
        Me.DeleteFiles(Me.lvFolder, Me.cbSelectSource2_Right.SelectedItem)
    End Sub



    Private Sub lvFolder_ItemSelectionChanged(sender As Object, e As System.Windows.Forms.ListViewItemSelectionChangedEventArgs) Handles lvFolder.ItemSelectionChanged
        'вычислить максимальный размер изображения
        'Внимание Размер обьекта определяется функцией ConverToObject clsIDcontent
        Dim _key = e.Item.Text
        If lvSource.Tag Is Nothing OrElse CType(lvSource.Tag, Service.SampleSourceImageList).Item(_key) Is Nothing Then
            Exit Sub
        End If
        Dim _imageWight = CType(lvSource.Tag, Service.SampleSourceImageList).Item(_key).Width

        Me.LbImageWidth.Text = ">>Ширина " & _key & " = " & _imageWight
        If _imageWight > 1600 Then
            'фото с шириной более оптимальной
            Me.LbImageWidth.ForeColor = Color.Red
        Else
            Me.LbImageWidth.ForeColor = Windows.Forms.Control.DefaultForeColor
        End If
    End Sub

    Private Sub lvFolder_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles lvFolder.KeyPress
        If Char.ToString(e.KeyChar) = "m" Or Char.ToString(e.KeyChar) = "M" Or Char.ToString(e.KeyChar) = "ь" Or Char.ToString(e.KeyChar) = "Ь" Then
            If Me.lvFolder.SelectedItems.Count = 0 Then
                MsgBox("Необходимо выделить фото, чтобы задать его главным", vbCritical)
                Exit Sub
            End If
            'задать главное фото
            Dim _imgName As String = lvFolder.SelectedItems(0).Name
            If MsgBox("Задать справа главное фото " & _imgName & " ?", MsgBoxStyle.Question) = MsgBoxResult.No Then
                Exit Sub
            End If

            'записать на устройство
            'задать устройство принимающее
            'Dim _source As clsFilesSources = clsFilesSources.CreateInstance(Me.cbSelectSource.SelectedItem)
            If Not clsApplicationTypes.SamplePhotoObject.CreateMainImageOnSource(Me.oSampleNumber, _imgName, Me.cbSelectSource2_Right.SelectedItem) Then
                Debug.Fail("Главное фото не скопировано!")
            Else
                'обновить вывод
                btSourceView_Right_Click(sender, e)
            End If
        End If
    End Sub

   

    Private Sub lvFolder_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles lvFolder.MouseDown
        ' Remember the point where the mouse down occurred. The DragSize indicates
        ' the size that the mouse can move before a drag event should be started.                
        Dim dragSize As Size = SystemInformation.DragSize

        ' Create a rectangle using the DragSize, with the mouse position being
        ' at the center of the rectangle.
        odragBoxFromMouseDown = New Rectangle(New Point(e.X - (dragSize.Width / 2), _
                                                        e.Y - (dragSize.Height / 2)), dragSize)
    End Sub

    Private Sub lvFolder_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles lvFolder.MouseMove
        If ((e.Button And MouseButtons.Left) = MouseButtons.Left) Then

            ' If the mouse moves outside the rectangle, start the drag.
            If (Rectangle.op_Inequality(odragBoxFromMouseDown, Rectangle.Empty) And _
                Not odragBoxFromMouseDown.Contains(e.X, e.Y)) Then

                ' The screenOffset is used to account for any desktop bands 
                ' that may be at the top or left side of the screen when 
                ' determining when to cancel the drag drop operation.
                'найдем элемент списка
                Dim _item = sender.GetItemAt(e.X, e.Y)

                If Not _item Is Nothing Then
                    'найдем путь к обьекту
                    Dim _source = clsFilesSources.CreateInstance(Service.clsFilesSources.emSources.Arhive)
                    Dim _uri = Service.clsApplicationTypes.SamplePhotoObject.GetImagesURI(Me.oSampleNumber, _source, {_item.Name})
                    If _uri.Length > 0 Then
                        Dim _obg As New DataObject
                        Dim _coll As New Collections.Specialized.StringCollection
                        _coll.Add(_uri(0).LocalPath)
                        With _obg
                            .SetFileDropList(_coll)
                        End With

                        ' Proceed with the drag-and-drop, passing in the list item.                    
                        Dim dropEffect As DragDropEffects = sender.DoDragDrop(_obg, DragDropEffects.Copy)

                    End If
                End If
            End If
        End If
    End Sub

    Private Sub lvFolder_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles lvFolder.MouseUp
        ' Reset the drag rectangle when the mouse button is raised.
        odragBoxFromMouseDown = Rectangle.Empty
    End Sub

    Private Sub lvFolder_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lvFolder.SelectedIndexChanged


    End Sub

    Private Sub btCopyToRight_Click(sender As System.Object, e As System.EventArgs) Handles btCopyToRight.Click
        'получить список файлов копирования
        If Me.cbSelectSource2_Right.SelectedItem Is Nothing Then
            MsgBox("Не задано устройство-получатель", vbCritical)
            Exit Sub
        End If
        If Me.cbSelectSource_Left.SelectedItem Is Nothing Then
            MsgBox("Не задано устройство-источник", vbCritical)
            Exit Sub
        End If

        Dim _coll As New List(Of String)
        Dim _arr() As String = {}

        For Each _tmp As ListViewItem In Me.lvSource.CheckedItems
            _coll.Add(_tmp.Name)
        Next
        ReDim _arr(_coll.Count - 1)
        _coll.CopyTo(_arr, 0)

        Me.ToolStripStatusLabel1.Text = Me.oSampleNumber.EAN13 & " - копирование из " & Me.cbSelectSource_Left.SelectedItem.ToString & " в " & Me.cbSelectSource2_Right.SelectedItem.ToString
        Dim _status = Me.CopyFiles(_arr, Me.cbSelectSource_Left.SelectedItem, Me.cbSelectSource2_Right.SelectedItem)

        Select Case _status
            Case Is > 0
                Me.ToolStripStatusLabel1.Text = Me.oSampleNumber.EAN13 & " - файлы скопированы"

                'снять флажки с скопированных
                For Each _tmp As ListViewItem In Me.lvSource.CheckedItems
                    _tmp.Checked = False
                Next


                'обновить список
                btSourceView_Right_Click(Me, New EventArgs)
            Case 0
                Me.ToolStripStatusLabel1.Text = Me.oSampleNumber.EAN13 & " - файлы НЕ скопированы!"

            Case -1
                Me.ToolStripStatusLabel1.Text = Me.oSampleNumber.EAN13 & " - ошибка при копировании файлов"

        End Select




    End Sub


    Private Sub cbxRemoteConnections_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles cbxRemoteConnections.CheckedChanged
        Call btCheckNumber_Click(sender, e)
    End Sub
    Private odragBoxFromMouseDown As Rectangle
    Private Sub lvSource_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles lvSource.MouseDown
        ' Remember the point where the mouse down occurred. The DragSize indicates
        ' the size that the mouse can move before a drag event should be started.                
        Dim dragSize As Size = SystemInformation.DragSize

        ' Create a rectangle using the DragSize, with the mouse position being
        ' at the center of the rectangle.
        odragBoxFromMouseDown = New Rectangle(New Point(e.X - (dragSize.Width / 2), _
                                                        e.Y - (dragSize.Height / 2)), dragSize)
    End Sub

    Private Sub lvSource_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles lvSource.MouseMove
        If ((e.Button And MouseButtons.Left) = MouseButtons.Left) Then

            ' If the mouse moves outside the rectangle, start the drag.
            If (Rectangle.op_Inequality(odragBoxFromMouseDown, Rectangle.Empty) And _
                Not odragBoxFromMouseDown.Contains(e.X, e.Y)) Then

                ' The screenOffset is used to account for any desktop bands 
                ' that may be at the top or left side of the screen when 
                ' determining when to cancel the drag drop operation.
                'найдем элемент списка
                Dim _item As ListViewItem = sender.GetItemAt(e.X, e.Y)

                If Not _item Is Nothing Then
                    'найдем путь к обьекту
                    Dim _source = clsFilesSources.CreateInstance(Service.clsFilesSources.emSources.Arhive)
                    Dim _uri = Service.clsApplicationTypes.SamplePhotoObject.GetImagesURI(Me.oSampleNumber, _source, {_item.Name})
                    If _uri.Length > 0 Then
                        Dim _obg As New DataObject
                        Dim _coll As New Collections.Specialized.StringCollection
                        _coll.Add(_uri(0).LocalPath)
                        With _obg
                            .SetFileDropList(_coll)
                        End With

                        ' Proceed with the drag-and-drop, passing in the list item.                    
                        Dim dropEffect As DragDropEffects = sender.DoDragDrop(_obg, DragDropEffects.Copy)

                    End If
                End If
            End If
        End If
    End Sub

    Private Sub lvSource_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles lvSource.MouseUp
        ' Reset the drag rectangle when the mouse button is raised.
        odragBoxFromMouseDown = Rectangle.Empty
    End Sub

    Private Sub lvSource_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lvSource.SelectedIndexChanged

    End Sub

    'Protected Overrides Sub Finalize()
    '    MyBase.Finalize()
    'End Sub

    Private Sub lbxSourcesList_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lbxSourcesList.SelectedIndexChanged

    End Sub



    'Private Sub fmImageManager_Load(sender As Object, e As System.EventArgs) Handles Me.Load
    '    'активировать образец
    '    If Not Me.oSampleNumber Is Nothing Then
    '        Me.tbSampleNumber.Text = Me.oSampleNumber.EAN13
    '        'btCheckNumber_Click(Me, EventArgs.Empty)
    '        'Application.DoEvents()
    '        'Me.Enabled = False
    '        'Dim _sp = New SplashScreen1
    '        '_sp.StartPosition = FormStartPosition.CenterParent
    '        '_sp.ShowDialog(Me)
    '        'Me.ToolStripStatusLabel1.Text = "Загрузка образца " + oSampleNumber.code
    '        '_sp.Close()
    '        'Me.Enabled = True
    '    End If
    'End Sub

    Private Sub cbOptimization_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbOptimization.SelectedIndexChanged

    End Sub

    Private Sub btRename_Click(sender As System.Object, e As System.EventArgs) Handles btRename.Click
        If Me.cbSelectSource_Left.SelectedItem Is Nothing Then Return

        Dim _source = CType(Me.cbSelectSource_Left.SelectedItem, clsFilesSources)

        Dim _result = clsApplicationTypes.SamplePhotoObject.ReorderPhoto(_source, Me.oSampleNumber)

        '-2 = ошибка инициализации сервиса, -1= ошибка при переименовании, 0 = переименование не требуется, >1 кол-во переименованных файлов
        Dim _message As String = ""
        Select Case _result
            Case -2
                _message = "ошибка инициализации сервиса;"
            Case -1
                _message = "ошибка при переименовании;"
            Case 0
                _message = "переименование не требуется;"
            Case Is > 0
                _message = "переименовано " & _result & "  файлов;"
        End Select

        'Lopped images
        _result = clsApplicationTypes.SamplePhotoObject.ReorderLoppedPhoto(_source, Me.oSampleNumber)
        Select Case _result

            Case -2
                _message += " ошибка инициализации сервиса (урезанные фото)."
            Case -1
                _message += " ошибка при переименовании(урезанные фото)."
            Case 0
                _message += " переименование не требуется(урезанные фото)."
            Case Is > 0
                _message += " переименовано " & _result & "  файлов(урезанные фото)."

        End Select

        MsgBox(_message, vbInformation)
        Me.btSourceLeftView_Click(sender, e)
    End Sub
End Class