Imports Service.clsApplicationTypes
Imports Service
Imports System.Linq
Imports Service.clsFilesSources
Public Class fmPhotoList
    'Private oConnection As String
    Private oCurrentSampleCollection As New Collections.Generic.List(Of Service.clsApplicationTypes.clsSampleNumber)
    Private WithEvents oCurrentListViewItemCollection As SampleSourceImageList
    Private oCurrentSource As clsFilesSources
    Private oCurrentSample As clsSampleNumber
    Private oCurrentSeries As String


    Private Sub cbSeriesSelect_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbSeriesSelect.SelectedIndexChanged

        oCurrentSeries = Me.cbSeriesSelect.SelectedItem.ToString
        oCurrentSampleCollection.Clear()
        Dim _filter As String = oCurrentSeries
        'If oCurrentSeries.Length = 3 Then
        '    'если серии из 3 букв, тогда
        '    _filter = oCurrentSeries.First
        'Else
        '    Return
        'End If

        'заполнить коллекцию образцов
        'oCurrentSampleCollection.AddRange _
        '   (PhotoService.GetSamplesNumberListWithPhotoFilter(_filter, Me.oCurrentSource.Source))
        oCurrentSampleCollection.AddRange(clsApplicationTypes.SamplePhotoObject.GetSampleListFromSource(Me.oCurrentSource, oCurrentSeries))
        oCurrentSampleCollection.Sort(Function(x, y)
                                          If x.Number < y.Number Then Return -1
                                          If x.Number = y.Number Then Return 0
                                          Return 1
                                      End Function)
        'поменять order 
        If Me.oCurrentSource.Source = emSources.SpecificOrder Then
            'поменять в основной форме order
            'todo
        End If

        Me.LoadSampleList()

    End Sub


    Private Sub LoadSampleList()
        Dim _collection As New Collections.Generic.List(Of Service.clsApplicationTypes.clsSampleNumber)
        Dim _source As clsFilesSources
        'заполнить коллекцию
        'переделаем коллекцию номеров с учетом флага готовности
        Select Case Me.CbOnlyReadyForSale.Checked
            Case True
                'получаем образцы с флагом OnSale
                Dim _OnsaleSamlesList As String()
                'по запросу выполняем вызов из сервиса
                'если делегата нет, то сервис недоступен
                If Not Global.Service.clsApplicationTypes.DelegateStoreOnSaleSampleList Is Nothing Then
                    'сервис зарегестрирован - вызываем
                    _OnsaleSamlesList = Global.Service.clsApplicationTypes.DelegateStoreOnSaleSampleList.Invoke()
                    For Each _OnSaleSample As String In _OnsaleSamlesList
                        Dim _sampl As clsSampleNumber = clsSampleNumber.CreateFromString(_OnSaleSample)
                        'проверим, есть ли он в списке
                        If Me.oCurrentSampleCollection.Contains(_sampl) Then
                            'если есть, добавим в новый список
                            _collection.Add _
                                (Me.oCurrentSampleCollection.Item(Me.oCurrentSampleCollection.IndexOf(_sampl)))
                        End If
                    Next
                    Me.oCurrentSampleCollection = _collection
                Else
                    'образцов на продажу нет
                    'покажем все образцы
                    '=============
                End If
            Case False
                'покажем все образцы
        End Select
        '--------------------------------

        Select Case Me.cbOnlyArhiveAbsent.Checked
            Case True
                _collection.Clear()
                _source = clsFilesSources.CreateInstance(emSources.Arhive)
                For Each _s In Me.oCurrentSampleCollection
                    If Not clsApplicationTypes.SamplePhotoObject.HasImages(_s, _source) Then
                        _collection.Add(_s)
                    End If
                Next
                Me.oCurrentSampleCollection = _collection
        End Select

        '--------------------------------

        Select Case Me.cbOnlyAzureAbsent.Checked
            Case True
                _collection.Clear()
                _source = clsFilesSources.CreateInstance(emSources.AZURE)
                For Each _s In Me.oCurrentSampleCollection
                    If Not clsApplicationTypes.SamplePhotoObject.HasImages(_s, _source) Then
                        _collection.Add(_s)
                    End If
                Next
                Me.oCurrentSampleCollection = _collection
        End Select

        '---------------------------------------
        With Me.ClsSampleNumberBindingSource
            .DataSource = oCurrentSampleCollection
            .ResetBindings(True)
        End With

        Me.lbLoadFile.Text = "Samples count: " & oCurrentSampleCollection.Count
        If Me.lbNumbers.Items.Count > 0 Then
            'Me.lbNumbers.Select()
            Me.lbNumbers.SelectedIndex = 0
            lbNumbers_SelectedIndexChanged(lbNumbers, EventArgs.Empty)
        End If
    End Sub



    Private Sub lbNumbers_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbNumbers.SelectedIndexChanged
        If Not lbNumbers.SelectedItem Is Nothing Then
            Me.oCurrentSample = CType(lbNumbers.SelectedItem, clsSampleNumber)
            Me.LoadImages(OnlyOneImage:=True)

            Me.LoadImages(OnlyOneImage:=True)
        End If
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="SampleNumber"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetSource(SampleNumber As clsSampleNumber) As clsFilesSources
        Dim _destination As clsFilesSources
        Select Case Me.oCurrentSource.Source
            Case emSources.FreeFolder
                _destination = clsFilesSources.CreateInstance(emSources.FreeFolder, , False, IO.Path.Combine(Me.oCurrentSource.ContainerPath, SampleNumber.ShotCode))

                If _destination Is Nothing Then
                    _destination = clsFilesSources.CreateInstance(emSources.FreeFolder, , False, IO.Path.Combine(Me.oCurrentSource.ContainerPath, SampleNumber.EAN13))
                End If

                If _destination Is Nothing Then
                    _destination = clsFilesSources.CreateInstance(emSources.FreeFolder, , False, IO.Path.Combine(Me.oCurrentSource.ContainerPath, SampleNumber.Owner & "-" & SampleNumber.Number))
                End If
                If _destination Is Nothing Then
                    _destination = clsFilesSources.CreateInstance(emSources.FreeFolder, , False, IO.Path.Combine(Me.oCurrentSource.ContainerPath, SampleNumber.Owner & "-0" & SampleNumber.Number))
                End If
                If _destination Is Nothing Then
                    _destination = clsFilesSources.CreateInstance(emSources.FreeFolder, , False, IO.Path.Combine(Me.oCurrentSource.ContainerPath, SampleNumber.Owner & "-00" & SampleNumber.Number))
                End If
            Case Else
                _destination = Me.oCurrentSource
        End Select
        Return _destination
    End Function


    Private Sub LoadImages(ByVal OnlyOneImage As Boolean)
        If Me.oCurrentSample Is Nothing Then Exit Sub

        Me.ToolStripStatusLabel1.Text = "Загрузим образец " & Me.oCurrentSample.ShotCode

        Dim _destination As clsFilesSources = Me.GetSource(CType(Me.oCurrentSample, clsSampleNumber))
      

        If _destination Is Nothing Then
            Debug.Fail("Текущее устройство не задано!")
            Exit Sub
        End If

        Me.ListViewMain.View = View.LargeIcon
        Me.ListViewMain.Clear()
        Me.lbLoadFile.Text = "load images. Please wait.. "
        Me.lbLoadFile.Refresh()

        Dim _coll As New List(Of clsSampleNumber)
        For i = Me.lbNumbers.SelectedIndex - NumericUpDown1.Value To Me.lbNumbers.SelectedIndex + NumericUpDown1.Value
            If i < Me.lbNumbers.Items.Count - 1 And Not (i < 0) Then
                _coll.Add(Me.lbNumbers.Items(i))
            End If
        Next

        If OnlyOneImage And _coll.Count > 0 Then
            Me.oCurrentListViewItemCollection = Service.clsApplicationTypes.SamplePhotoObject.GetSampleCollectionImageList(_coll.ToArray, _destination, New Size(160, 120))
            Me.ListViewMain.Items.AddRange(oCurrentListViewItemCollection.ListViewItems)
            'Me.ListViewMain.SmallImageList = oCurrentListViewItemCollection.ImageList
            Me.ListViewMain.LargeImageList = oCurrentListViewItemCollection.ImageList
            Me.lbLoadFile.Text = "sample count: " & oCurrentListViewItemCollection.CountImages
            Me.lbLoadFile.Refresh()
            Me.oShowManySamplesType = True
            Return
        End If

        Me.oCurrentListViewItemCollection = Service.clsApplicationTypes.SamplePhotoObject.GetSampleImageList(CType(Me.oCurrentSample, clsSampleNumber), _destination, New Size(160, 120), OnlyOneImage)

        Me.ListViewMain.Items.AddRange(oCurrentListViewItemCollection.ListViewItems)
        'тут возникает ошибка
#If Not Debug Then
 Try
            Me.ListViewMain.SmallImageList = oCurrentListViewItemCollection.ImageList
            Me.ListViewMain.LargeImageList = oCurrentListViewItemCollection.ImageList
        Catch ex As Exception
        Me.ListViewMain.SmallImageList =nothing
        Me.ListViewMain.LargeImageList =nothing
        End Try
#End If

        Me.ListViewMain.SmallImageList = oCurrentListViewItemCollection.ImageList
        Me.ListViewMain.LargeImageList = oCurrentListViewItemCollection.ImageList

        Me.lbLoadFile.Text = "image count: " & oCurrentListViewItemCollection.CountImages
        Me.lbLoadFile.Refresh()
        Me.oShowManySamplesType = False
    End Sub


    Private Sub btShowImages_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btShowImages.Click
        Dim _SampleNumber As clsSampleNumber

        Select Case oShowManySamplesType
            Case True
                If Me.ListViewMain.SelectedItems.Count = 0 Then Exit Sub
                Dim _imageKey As String = ListViewMain.SelectedItems.Item(0).Name
                _SampleNumber = clsSampleNumber.CreateFromString(_imageKey)
            Case Else
                If lbNumbers.SelectedItem Is Nothing Then Exit Sub
                _SampleNumber = CType(lbNumbers.SelectedItem, clsSampleNumber)
        End Select

        Me.oCurrentSample = _SampleNumber
        Me.LoadImages(OnlyOneImage:=False)

    End Sub
    Private Function GetImagePath(ByVal item As Windows.Forms.ListViewItem) As String
        Return item.ImageList.Images.Keys(item.ImageIndex)
    End Function
    Private Sub btCopySelected_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim _countCopies As Integer = 0
        Dim _destinationRoot As String = Global.Service.clsApplicationTypes.OrdersPath
        Dim _ToOrder As clsOrder

        'по запросу выполняем вызов из сервиса
        'если делегата нет, то сервис недоступен
        If Not Global.Service.clsApplicationTypes.DelegatStoreActiveOrder Is Nothing Then
            'сервис зарегестрирован - вызываем
            _ToOrder = Global.Service.clsApplicationTypes.DelegatStoreActiveOrder.Invoke()

            Select Case MsgBox("Фото будут скопированы в заказ " & _ToOrder.OrderID, MsgBoxStyle.OkCancel)
                Case MsgBoxResult.Cancel
                    Exit Sub
            End Select
        Else
            'MsgBox("Надо выбрать заказ!", MsgBoxStyle.Critical)
            Exit Sub
        End If

        ''check order name
        Dim _orderName As String = Trim(_ToOrder.OrderID)

        ''===================================================
        'copy images

        '(Me.ProgressBarImageLoad.Maximum = Me.ListViewMain.CheckedIndices.Count)
        'вынуть отмеченные
        Dim _SelectedNames As String()
        Dim _selNamColl As New Collections.Specialized.StringCollection
        For Each _tmp As Windows.Forms.ListViewItem In Me.ListViewMain.CheckedItems
            _selNamColl.Add(_tmp.Name)
        Next
        ReDim _SelectedNames(_selNamColl.Count - 1)
        _selNamColl.CopyTo(_SelectedNames, 0)

        '--------new version--------
        Dim _FromSource As clsFilesSources = Me.oCurrentSource

        Dim _ToSource = clsFilesSources.CreateInstance(Service.clsFilesSources.emSources.SpecificOrder, _ToOrder)

        Dim _CurrentSample As clsApplicationTypes.clsSampleNumber = Me.oCurrentListViewItemCollection.SampleNumber

        Select Case _countCopies
            Case 0
                Me.lbLoadFile.Text = "ready"
                MsgBox("Файлов не скопировано", MsgBoxStyle.Critical)
            Case Is < 0
                Me.lbLoadFile.Text = "ready"
                MsgBox("Файлы не скопированы. Ошибка.", MsgBoxStyle.Critical)
            Case Is > 0

                'add sample in order
                Dim _result As Boolean
                'использование сервисов
                'по запросу выполняем вызов из сервиса
                'если делегата нет, то сервис недоступен
                If Not Global.Service.clsApplicationTypes.DelegateStoreAddSampleToOrder Is Nothing Then
                    'сервис зарегестрирован - вызываем
                    _result = Global.Service.clsApplicationTypes.DelegateStoreAddSampleToOrder. _
                        Invoke(_orderName, _CurrentSample.GetEan13, _SelectedNames, clsApplicationTypes.OptimizeImageWight)
                    Me.lbLoadFile.Text = "Writing complete."
                    MsgBox(_countCopies & " files copied.", MsgBoxStyle.Information)
                Else
                    _result = False
                    Me.lbLoadFile.Text = "ready"
                    MsgBox("Не удалось добавить образец в БД", MsgBoxStyle.Critical)
                    Exit Sub
                End If
        End Select

        'Me.ProgressBarImageLoad.Value = 0



        '----------------

        'For Each _index As Integer In Me.ListViewMain.CheckedIndices

        'Dim _source As String = Me.GetImagePath(Me.ListViewMain.Items(_index))

        'Dim _samplenumber As String = ""
        ' ''half-check barcode ean13
        'For Each _dir As String In IO.Path.GetDirectoryName(_source).Split(IO.Path.DirectorySeparatorChar)
        'If _dir.Length = 13 Then

        'Dim _test As Boolean = True
        'For Each _char As Char In _dir
        'If Not Char.IsDigit(_char) Then
        ' ''find non-digit
        '_test = False
        'End If
        'Next
        'If _test Then
        '_samplenumber = _dir
        'Exit For
        'Else
        '_samplenumber = ""
        'End If
        'End If
        'Next

        'Select Case _samplenumber

        'Case ""
        'MsgBox("Не могу найти номер образца в пути источника " & _source)
        'Case Else

        ''add sample in order
        'Dim _result As Boolean
        ''использование сервисов
        ''по запросу выполняем вызов из сервиса
        ''если делегата нет, то сервис недоступен
        'If Not Global.Service.clsApplicationTypes.DelegateStoreAddSampleToOrder Is Nothing Then
        ''сервис зарегестрирован - вызываем
        '_result = Global.Service.clsApplicationTypes.DelegateStoreAddSampleToOrder. _
        'Invoke(_orderName, _samplenumber)
        'Else
        '_result = False
        'MsgBox("Не удалось добавить образец в БД", MsgBoxStyle.Critical)
        'Exit Sub
        'End If
        '''''==================================================================
        ' ''copy file to destination

        'Dim _destinationWithNumber As String = IO.Path.Combine(_destinationRoot, IO.Path.Combine(_orderName, _samplenumber))

        ' ''check dir
        'If Not IO.Directory.Exists(_destinationWithNumber) Then
        ' ''create dir
        'IO.Directory.CreateDirectory(_destinationWithNumber)
        'End If

        ' ''copy file
        'If Not IO.File.Exists(IO.Path.Combine(_destinationWithNumber, IO.Path.GetFileName(_source))) Then
        ' ''check optimization
        'Select Case Me.cbxOptimization.Checked
        'Case True
        ' ''optimize image to specific size
        'Dim _image As Image = Image.FromFile(_source)
        'Dim _resizedImage As Bitmap
        'Dim _optimizeImageWight As Integer = Global.Service.clsApplicationTypes.OptimizeImageWight
        'Dim _optimizeImageHeight As Integer
        'Dim _JpegQuatly As emJpegQuality = emJpegQuality.High

        '_optimizeImageHeight = CType(_optimizeImageWight / _image.Size.Width * _image.Size.Height, Integer)
        '_resizedImage = New Bitmap(_image, New Size(_optimizeImageWight, _optimizeImageHeight))
        '_image = CType(_resizedImage, Image)

        'Dim jpgEncoder As System.Drawing.Imaging.ImageCodecInfo = GetEncoder(Imaging.ImageFormat.Jpeg)
        'Dim MyEncoder As System.Drawing.Imaging.Encoder = System.Drawing.Imaging.Encoder.Quality
        'Dim MyEncoderParameters As New System.Drawing.Imaging.EncoderParameters(1)
        'Dim MyEncoderParameter As New System.Drawing.Imaging.EncoderParameter(MyEncoder, _JpegQuatly)
        'MyEncoderParameters.Param(0) = MyEncoderParameter

        '_image.Save(IO.Path.Combine(_destinationWithNumber, IO.Path.GetFileName(_source)), jpgEncoder, MyEncoderParameters)

        'Case False
        ' ''copy image as is
        'IO.File.Copy(_source, IO.Path.Combine(_destinationWithNumber, IO.Path.GetFileName(_source)))
        'End Select


        '_countCopies += 1
        'Me.lbLoadFile.Text = "Write " & IO.Path.GetFileName(_source)
        'Me.lbLoadFile.Refresh()
        'Me.ProgressBarImageLoad.PerformStep()
        'End If
        ' ''=======================================================================
        'End Select

        'Next
    End Sub
    Public Enum emJpegQuality
        Fine = 100&
        High = 85&
        Normal = 75&
        Low = 50&
        VeryLow = 0&
    End Enum
    Private Shared Function GetEncoder(ByVal format As System.Drawing.Imaging.ImageFormat) As System.Drawing.Imaging.ImageCodecInfo

        Dim codecs As System.Drawing.Imaging.ImageCodecInfo() = System.Drawing.Imaging.ImageCodecInfo.GetImageDecoders()

        Dim codec As System.Drawing.Imaging.ImageCodecInfo
        For Each codec In codecs
            If codec.FormatID = format.Guid Then
                Return codec
            End If
        Next codec
        Return Nothing

    End Function


    Private Sub btSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSelectAll.Click
        For Each _tmpItem As ListViewItem In Me.ListViewMain.Items
            _tmpItem.Checked = True
        Next
    End Sub

    Private Sub btUnSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btUnSelectAll.Click
        For Each _tmpItem As ListViewItem In Me.ListViewMain.Items
            _tmpItem.Checked = False
        Next
    End Sub


    ''' <summary>
    ''' показать увеличенное изображение
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ShowImageForm(ImageKey As String)

        Dim _prm As Object
        Dim _source = clsFilesSources.CreateInstance(Service.clsFilesSources.emSources.Arhive)
        Dim _key = ImageKey
        Select Case oShowManySamplesType
            Case True
                Dim _num = clsSampleNumber.CreateFromString(_key)
                _prm = Service.clsApplicationTypes.SamplePhotoObject.GetImageCollection(_num, oCurrentSource, False)
                _key = ""
            Case Else
                _prm = Service.clsApplicationTypes.SamplePhotoObject.GetImageCollection(oCurrentSample, oCurrentSource, False)
        End Select

        If _prm Is Nothing Then
            MsgBox("невозможно показать форму")
        End If


        'show image form
        'использование сервисов
        'по запросу выполняем вызов из сервиса
        Dim _param As Object
        _param = {_prm, _key}


        Dim _fmImage As Form
        'show image form
        'использование сервисов
        'по запросу выполняем вызов из сервиса


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
                _fmImage.Show()

            End If
        Else

        End If
    End Sub


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ListViewMain_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListViewMain.DoubleClick
        If sender.SelectedItems.Count = 0 Then Exit Sub
        Call Me.ShowImageForm(sender.SelectedItems.Item(0).Name)

        
    End Sub

    Private Sub btRunFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btRunFind.Click
        If Me.tbFindNumber.Text = "" Then Exit Sub

        For Each _item As clsSampleNumber In Me.lbNumbers.Items
            If _item.EAN13 = clsSampleNumber.GetFullCodeByShot(Me.tbFindNumber.Text) Then
                Me.lbNumbers.Focus()
                Me.lbNumbers.SelectedItem = _item
                Exit Sub
            End If
        Next
        MsgBox("Номер " & Me.tbFindNumber.Text & " не найден.", MsgBoxStyle.Critical)
    End Sub

    Private Sub tbFindNumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbFindNumber.KeyPress
        If Char.IsControl(e.KeyChar) Then
            btRunFind_Click(sender, e)
        End If
    End Sub


    Private Sub fmPhotoList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'window position
        'If Not Me.ParentForm Is Nothing Then
        '    Me.Location = New Point(Me.ParentForm.ClientRectangle.Left, Me.ParentForm.ClientRectangle.Top)
        'Else
        '    Me.StartPosition = FormStartPosition.CenterScreen
        'End If

        'Me.CbFolderSelect.DataSource = [Enum].GetNames(GetType(emSources))

        'Select Case Global.Service.clsApplicationTypes.ActiveUser
        'Case emUsers.Admin
        ''Me.CbFolderSelect.Items.AddRange({"Current", "Arhive", "Order"})
        'Me.CbFolderSelect.Items.AddRange({emSources.Current, emSources.Arhive, emSources.SpecificOrder})

        'Case emUsers.PhotoWoker
        ''Me.CbFolderSelect.Items.AddRange({"Current", "Arhive"})
        'Me.CbFolderSelect.Items.AddRange({emSources.Current, emSources.Arhive})
        'End Select

        Me.LockAll()
    End Sub

    Private Sub LockAll()
        For Each _ctl As Control In Me.Controls
            _ctl.Enabled = False
        Next
        Me.CbFolderSelect.Enabled = True
    End Sub

    Private Sub unlockAll()
        For Each _ctl As Control In Me.Controls
            _ctl.Enabled = True
            _ctl.Refresh()
        Next
        Select Case Global.Service.clsApplicationTypes.GetAccess("Доступ к заказам")
            Case False
                Me.CbOnlyReadyForSale.Enabled = False
                Me.btReadyForSale.Enabled = False
                Me.cbxOptimization.Enabled = False
        End Select

    End Sub
    Public Sub New(startUpSource As clsFilesSources)
        Me.New()

        Me.CbFolderSelect.DataSource = [Enum].GetNames(GetType(emSources))
        If Not startUpSource Is Nothing Then
            Me.CbFolderSelect.SelectedItem = [Enum].GetName(GetType(clsFilesSources.emSources), startUpSource.Source)
            oCurrentSource = startUpSource
        Else
            Me.CbFolderSelect.SelectedItem = [Enum].GetName(GetType(clsFilesSources.emSources), clsFilesSources.emSources.Arhive)
        End If

    End Sub


    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Me.cbxOptimization.Text = "Оптимизация " & Global.Service.clsApplicationTypes.OptimizeImageWight.ToString

        If Not Me.ParentForm Is Nothing Then
            Me.Location = New Point(Me.ParentForm.ClientRectangle.Left, Me.ParentForm.ClientRectangle.Top)
        Else
            Me.StartPosition = FormStartPosition.CenterScreen
        End If
    End Sub

    Private Sub btShowSampleData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btShowSampleData.Click
        Dim _SampleNumber As clsSampleNumber

        Select Case oShowManySamplesType
            Case True
                If Me.ListViewMain.SelectedItems.Count = 0 Then Exit Sub
                Dim _imageKey As String = ListViewMain.SelectedItems.Item(0).Name
                _SampleNumber = clsSampleNumber.CreateFromString(_imageKey)
            Case Else
                If lbNumbers.SelectedItem Is Nothing Then Exit Sub
                _SampleNumber = CType(lbNumbers.SelectedItem, clsSampleNumber)
        End Select


        Dim _fmSampleData As Form = clsPhotoService.GetfmSampleData(_SampleNumber.GetEan13)

        If Not (_fmSampleData.IsDisposed) Or (_fmSampleData.Disposing) Then
            _fmSampleData.MdiParent = Me.ParentForm
            _fmSampleData.Show()
        End If
    End Sub

    Private Sub CbOnlyReadyForSale_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CbOnlyReadyForSale.CheckedChanged
        Me.cbOnlyArhiveAbsent.Checked = False
        Me.cbOnlyAzureAbsent.Checked = False
        Me.LoadSampleList()
    End Sub

    Private Sub CbFolderSelect_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CbFolderSelect.SelectedIndexChanged
        If Me.Visible = False Then Exit Sub

        'очистить ресурсы
        oCurrentSampleCollection.Clear()

        With Me.ClsSampleNumberBindingSource
            .ResetBindings(True)
        End With
        Me.LockAll()

        'set current source
        Dim _source = [Enum].Parse(GetType(emSources), CbFolderSelect.SelectedItem)

        Select Case _source
            Case emSources.FreeFolder
                'выбрать папку
                Me.FolderBrowserDialog1.SelectedPath = Environment.SpecialFolder.MyComputer

                Select Case Me.FolderBrowserDialog1.ShowDialog()
                    Case Windows.Forms.DialogResult.OK
                        'получить список образцов из папки
                        oCurrentSource = clsFilesSources.CreateInstance(_source, , , Me.FolderBrowserDialog1.SelectedPath)
                    Case Else
                        oCurrentSource = clsFilesSources.CreateInstance(emSources.Arhive)
                End Select
            Case Else
                oCurrentSource = clsFilesSources.CreateInstance(CbFolderSelect.SelectedItem)
        End Select






        'fill combobox
        Dim _message As String = ""
        Me.cbSeriesSelect.DataSource = Service.clsApplicationTypes.SamplePhotoObject.GetSeriesList(oCurrentSource, _message)
        Me.cbSeriesSelect.Refresh()
        If Me.cbSeriesSelect.Items.Count > 0 Then
            Me.cbSeriesSelect.SelectedIndex = 0
        End If
        Me.Text = _message
        '/////////////////////
        Me.unlockAll()
    End Sub

    Private Sub btReadyForSale_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btReadyForSale.Click



        Dim _SampleNumber As clsSampleNumber

        Select Case oShowManySamplesType
            Case True
                If Me.ListViewMain.SelectedItems.Count = 0 Then Exit Sub
                Dim _imageKey As String = ListViewMain.SelectedItems.Item(0).Name
                _SampleNumber = clsSampleNumber.CreateFromString(_imageKey)
            Case Else
                If lbNumbers.SelectedItem Is Nothing Then Exit Sub
                _SampleNumber = CType(lbNumbers.SelectedItem, clsSampleNumber)
        End Select

        'по запросу выполняем вызов из сервиса
        'если делегата нет, то сервис недоступен
        Dim _fmSampleOnSale As Form
        Dim _param As Object = {_SampleNumber.GetEan13}

        If Not Global.Service.clsApplicationTypes.DelegateStoreApplicationForm _
(emFormsList.fmSampleOnSale) Is Nothing Then
            'сервис зарегестрирован - вызываем
            _fmSampleOnSale = Global.Service.clsApplicationTypes.DelegateStoreApplicationForm(emFormsList.fmSampleOnSale).Invoke(_param)
        Else
            Exit Sub
        End If

        _fmSampleOnSale.MdiParent = Me.ParentForm
        _fmSampleOnSale.Show()

    End Sub

    Private Sub ListViewMain_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ListViewMain.SelectedIndexChanged

    End Sub

    Private Sub btImageManager_Click(sender As System.Object, e As System.EventArgs) Handles btImageManager.Click

        Dim _SampleNumber As clsSampleNumber

        Select Case oShowManySamplesType
            Case True
                If Me.ListViewMain.SelectedItems.Count = 0 Then Exit Sub
                Dim _imageKey As String = ListViewMain.SelectedItems.Item(0).Name
                _SampleNumber = clsSampleNumber.CreateFromString(_imageKey)
            Case Else
                If lbNumbers.SelectedItem Is Nothing Then Exit Sub
                _SampleNumber = CType(lbNumbers.SelectedItem, clsSampleNumber)
        End Select


        Dim _fmImageManager As Form = clsPhotoService.GetfmImageManager(_SampleNumber)

        If Not (_fmImageManager.IsDisposed) Or (_fmImageManager.Disposing) Then
            _fmImageManager.MdiParent = Me.ParentForm
            _fmImageManager.Show()
        End If
    End Sub

    Private Sub cbOnlyArhiveAbsent_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles cbOnlyArhiveAbsent.CheckedChanged
        Me.CbOnlyReadyForSale.Checked = False
        Me.cbOnlyAzureAbsent.Checked = False
        If cbOnlyArhiveAbsent.Checked = False Then
            cbSeriesSelect_SelectedIndexChanged(sender, e)
            Exit Sub
        End If
        Me.LoadSampleList()
    End Sub

    Private Sub cbOnlyAzureAbsent_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles cbOnlyAzureAbsent.CheckedChanged
        Me.cbOnlyArhiveAbsent.Checked = False
        Me.CbOnlyReadyForSale.Checked = False
        Me.LoadSampleList()
    End Sub
    '''<summary>копирует файлы на устройство</summary>
    ''' <param name="FileNames"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Overloads Function CopyFiles(ByVal FileNames() As String, Fromsource As clsFilesSources, Tosource As clsFilesSources) As Integer

        'вычислить оптимизацию
        Dim _optimize As Integer = Global.Service.clsApplicationTypes.OptimizeImageWight
        Dim _message As String = "Копировать " & FileNames.Length & " файлов "
        If Me.cbxOptimization.Checked Then
            _message += "с оптимизацией по длинной стороне " & _optimize.ToString & "?"
        Else
            _message += "без изменения размера?"
        End If

        'задать вопрос
        Select Case MsgBox(_message, MsgBoxStyle.YesNo)
            Case MsgBoxResult.Yes
                'копировать
                Return clsApplicationTypes.SamplePhotoObject.CopyImagesFromSourceToSource(Me.oCurrentSample, Fromsource, Tosource, False, FileNames, _optimize)
            Case MsgBoxResult.No
                Return 0
        End Select
        Return -1


    End Function

    Private Sub btCopyToSource_Click(sender As System.Object, e As System.EventArgs) Handles btCopyToSource.Click
        If Me.oCurrentSource.Source = emSources.Arhive Then
            MsgBox("Уже в архиве!", MsgBoxStyle.Critical)
            Exit Sub
        End If

        'получить устройство-источник
        Dim _fromSource As clsFilesSources = Me.GetSource(CType(Me.oCurrentSample, clsSampleNumber))


        'получить устройство назначения
        Dim _destination As clsFilesSources
        _destination = clsFilesSources.CreateInstance(emSources.Arhive)



        Me.ToolStripStatusLabel1.Text = "copy images. Please wait.. "
        Me.ToolStripStatusLabel1.Invalidate()


        Dim _sp = New SplashScreen1
        _sp.StartPosition = FormStartPosition.CenterScreen
        Select Case Me.oShowManySamplesType
            Case True
                Select Case MsgBox("Скопировать " & Me.ListViewMain.CheckedItems.Count & " образцов в архив?", MsgBoxStyle.YesNo)
                    Case MsgBoxResult.No
                        Exit Sub
                End Select


                _sp.Show(Me)
                Application.DoEvents()
                Dim _count As Integer = 0
                For Each _tmp As ListViewItem In Me.ListViewMain.CheckedItems
                    Me.ToolStripStatusLabel1.Text = "copy " & _tmp.Name
                    Dim _num = clsSampleNumber.CreateFromString(_tmp.Name)
                    'получить устройство-источник
                    _fromSource = Me.GetSource(_num)
                    Me.ToolStripStatusLabel1.Text = _num.EAN13 & " - копирование из " & _fromSource.ToString & " в " & _destination.ToString
                    'Me.ToolStripStatusLabel1.Invalidate()
                    Me.StatusStrip1.Refresh()
                    If Not _num Is Nothing Then
                        'clsApplicationTypes.SamplePhotoObject.DeleteImagesFromSource(_num, _destination, {}, True, False)
                        If clsApplicationTypes.SamplePhotoObject.HasImages(_num, _destination) Then
                            'фотки уже есть
                            MsgBox("Для образца " & _num.ShotCode & " фотки уже есть!", vbCritical)
                            _count += 1
                        Else
                            If clsApplicationTypes.SamplePhotoObject.CopyImagesFromSourceToSource(_num, _fromSource, _destination, False) > 0 Then
                                _count += 1
                            End If
                        End If

                    End If
                Next

                Select Case Me.ListViewMain.CheckedItems.Count - _count
                    Case 0
                        'все образцы скопированы
                        Me.ToolStripStatusLabel1.Text = "все образцы скопированы"
                    Case Is > 0
                        '
                        Me.ToolStripStatusLabel1.Text = "при копировании были ошибки"
                    Case Is < 0
                        '
                End Select



            Case False
                Select Case MsgBox("Скопировать " & Me.ListViewMain.CheckedItems.Count & " файлов в архив?", MsgBoxStyle.YesNo)
                    Case MsgBoxResult.No
                        Exit Sub
                End Select
                _sp.Show(Me)
                'получить список файлов копирования
                Dim _coll As New List(Of String)
                Dim _FileNames() As String = {}

                For Each _tmp As ListViewItem In Me.ListViewMain.CheckedItems
                    _coll.Add(_tmp.Name)
                Next
                ReDim _FileNames(_coll.Count - 1)
                _coll.CopyTo(_FileNames, 0)

                Dim _status = Me.CopyFiles(_FileNames, _fromSource, _destination)

                Select Case _status
                    Case Is > 0

                        'снять флажки с скопированных
                        For Each _tmp As ListViewItem In Me.ListViewMain.CheckedItems
                            _tmp.Checked = False
                        Next

                        Me.ToolStripStatusLabel1.Text = Me.oCurrentSample.EAN13 & " - файлы скопированы"

                    Case 0
                        Me.ToolStripStatusLabel1.Text = Me.oCurrentSample.EAN13 & " - файлы НЕ скопированы!"

                    Case -1
                        Me.ToolStripStatusLabel1.Text = Me.oCurrentSample.EAN13 & " - ошибка при копировании файлов"

                End Select
        End Select



        If Not _sp Is Nothing Then
            _sp.Close()
        End If




    End Sub

    Private Sub lbLoadFile_Click(sender As System.Object, e As System.EventArgs) Handles lbLoadFile.Click

    End Sub

    Private Sub cbxOptimization_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles cbxOptimization.CheckedChanged

    End Sub


    ''' <summary>
    ''' автозанесение фото из папки с масштабированием до 1600 ширины
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btAutoImages_Click(sender As System.Object, e As System.EventArgs) Handles btAutoImages.Click
        'предучловия
        If Me.lbNumbers.SelectedItems.Count <= 0 Then
            MsgBox("Необходимо отметить номера для занесения в БД", vbCritical)
            Exit Sub
        End If

        If Me.oCurrentSource.Source = emSources.Arhive Then
            MsgBox("Занести в БД можно с любого устройства, кроме Arhive (самой БД)", vbCritical)
            Exit Sub
        End If

        Dim _manager = clsApplicationTypes.SamplePhotoObject
        Dim _destination = clsFilesSources.CreateInstance(emSources.Arhive)
        Dim _countresult As Integer = 0
        Dim _result As String = "Обработка номеров " & Me.lbNumbers.SelectedItems.Count & " pcs" & Chr(13)

        Dim _source As clsFilesSources

        'берем список номеров в боксе
        For Each _num As clsSampleNumber In Me.lbNumbers.SelectedItems
            _result += " Номер " & _num.ShotCode
            Me.ToolStripStatusLabel1.Text = "подключение к " & _destination.ToString()
            If Not _manager.HasImages(_num, _destination) Then
                'занести фото
                Me.ToolStripStatusLabel1.Text = " записываем из " & oCurrentSource.ToString() & " образец " & _num.ShotCode

                _source = Me.GetSource(CType(Me.oCurrentSample, clsSampleNumber))

                '_source = clsFilesSources.CreateInstance(emSources.FreeFolder, , False, IO.Path.Combine(Me.oCurrentSource.ContainerPath, CType(lbNumbers.SelectedItem, clsSampleNumber).ShotCode))
                'If _source Is Nothing Then
                '    _source = clsFilesSources.CreateInstance(emSources.FreeFolder, , False, IO.Path.Combine(Me.oCurrentSource.ContainerPath, CType(lbNumbers.SelectedItem, clsSampleNumber).code))
                'End If

                If _source Is Nothing Then
                    _result += " --> ошибка при записи!" & Chr(13)
                Else
                    Select Case _manager.CopyImagesFromSourceToSource(_num, _source, _destination, False, , 1600)
                        Case Is = 0
                            _result += " --> не записан!" & Chr(13)
                        Case Is <= -1
                            _result += " --> ошибка при записи!" & Chr(13)
                        Case Is >= 1
                            _result += " --> ок. записан" & Chr(13)
                            _countresult += 1
                    End Select
                End If
            Else
                _result += " --> есть фотки. Пропущен" & Chr(13)
            End If
            Me.ToolStripStatusLabel1.Invalidate()
        Next

        Me.ToolStripStatusLabel1.Text = "В БД записано из " & oCurrentSource.ToString() & "  " & _countresult & " образцов"
        MsgBox("В БД записано из " & oCurrentSource.ToString() & "  " & _countresult & " образцов", vbInformation)
        _result += "В БД записано из " & oCurrentSource.ToString() & "  " & _countresult & " образцов"
        GoTo jour
        ''указать папку-источник
        ''перебрать поддиректории
        ''те, что с номером, и нет в базе фоток, занести в БД
        ''писать отчет в текст и сохранить в мои документы
        'Dim _root = PhotoManagerStarUpFolder
        'Dim _dialog = New Windows.Forms.FolderBrowserDialog
        '_dialog.Description = "Укажите папку - источник фоток"
        'If IO.Directory.Exists(_root) Then
        '    _dialog.SelectedPath = _root
        'ElseIf IO.Directory.Exists(PhotoManagerStarUpFolder) Then
        '    _dialog.SelectedPath = PhotoManagerStarUpFolder
        'Else
        '    _dialog.SelectedPath = Environment.SpecialFolder.MyComputer
        'End If

        'Select Case _dialog.ShowDialog()
        '    Case Windows.Forms.DialogResult.OK
        '        _root = _dialog.SelectedPath
        '    Case Else
        '        Exit Sub
        'End Select
        ''путь выбран. перебрать поддиректории
        ''Dim _number As clsSampleNumber
        ''Dim _destination = clsFilesSources.CreateInstance(emSources.Arhive)
        '' Dim _manager = clsApplicationTypes.SamplePhotoObject
        'Dim _source As clsFilesSources
        ''Dim _result As String = "Обработка  " & _root
        'For Each _dir In IO.Directory.EnumerateDirectories(_root)
        '    _result += Chr(13) & "подключение к " & _dir
        '    'MsgBox("подключение к " & _dir)
        '    Me.ToolStripStatusLabel1.Text = "подключение к " & _dir
        '    _number = clsSampleNumber.CreateFromString(IO.Path.GetFileName(_dir))
        '    If Not _number Is Nothing AndAlso _number.CodeIsCorrect Then
        '        'директория с номером
        '        _source = clsFilesSources.CreateInstance(emSources.FreeFolder, , , _dir)
        '        If _source Is Nothing Then
        '            _result += "--> " & " ошибка инициализации устройства"
        '        Else
        '            Dim _destList = _manager.GetImageNamesList(_number, _destination)
        '            Dim _soursList = _manager.GetImageNamesList(_number, _source)
        '            Dim _compareList = (From cin In _soursList Where (From cout In _destList Where (Not String.Compare(cin, cout, True) = 0) Select cout).Count = 0 Select cin).ToList

        '            If _compareList.Count > 0 Then
        '                'имаджей в БД нет
        '                'вычислить сколько есть фото
        '                _result += "--> " & " записываем " & _compareList.Count
        '                If _compareList.Count > 15 Then
        '                    Debug.Fail("подозрительно много фоток")
        '                End If
        '                _result += _soursList.Length & " фоток"
        '                Me.ToolStripStatusLabel1.Text = " записываем " & _soursList.Length & " фоток " & " для " & _dir
        '                'MsgBox(" записываем " & _list.Length & " фоток")
        '                Try
        '                    'запись фото!!
        '                    Select Case _manager.CopyImagesFromSourceToSource(_number, _source, _destination, False, _compareList.ToArray, 1600)
        '                        Case Is = 0
        '                            _result += Chr(13) & " --> не записан!"
        '                        Case Is <= -1
        '                            _result += Chr(13) & " --> ошибка при записи!"
        '                        Case Is >= 1
        '                            _result += Chr(13) & " --> ок. записан"
        '                    End Select

        '                Catch ex As Exception
        '                    _result += Chr(13) & ex.Message & " --> общая ошибка"
        '                    GoTo jour
        '                End Try
        '            Else
        '                'имаджи в БД есть
        '                _result += "--> " & " в БД уже есть фото!"
        '            End If


        '        End If

        '    Else
        '        'директория - не номер
        '        _result += "--> " & " номер не распознан!"
        '    End If
        '    Me.ToolStripStatusLabel1.Invalidate()
        'Next

jour:

        'запись журнала
        Dim _path = IO.Path.Combine(My.Computer.FileSystem.SpecialDirectories.MyDocuments, "TrilboneAutoImageResult" & Date.Today.ToShortDateString & ".txt")
        Using _f = IO.File.CreateText(_path)
            _f.Write(_result)
            _f.Flush()
        End Using
        'Dim c = New SHDocVw.InternetExplorer
        'c.Visible = True
        'c.Navigate(_path)

    End Sub


    Private Sub btShowAllMainImages_Click(sender As System.Object, e As System.EventArgs) Handles btShowAllMainImages.Click
        Dim _sp = New SplashScreen1
        _sp.StartPosition = FormStartPosition.CenterScreen
        _sp.Show(Me)
        Application.DoEvents()

        Dim _destination As clsFilesSources


        Me.ListViewMain.Clear()

        Me.ListViewMain.View = View.LargeIcon

        Me.lbLoadFile.Text = "load images. Please wait.. "
        Me.lbLoadFile.Refresh()
        Dim _list As New ImageList
        Dim _size = New Size(clsIDcontent.constMainImageWidth, clsIDcontent.constMainImageWidth * 3 / 4)
        If _size.Width > 256 Then
            _size = New Size(256, clsIDcontent.constMainImageWidth * 3 / 4 / (clsIDcontent.constMainImageWidth / 256))
        End If
        _list.ImageSize = _size
        _list.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit

        Dim _lvItems As New List(Of ListViewItem)

        'list samples
        For Each _num As clsSampleNumber In Me.lbNumbers.SelectedItems
            _destination = Me.GetSource(_num)


            'взять главное фото
            Dim _img = clsApplicationTypes.SamplePhotoObject.GetMainImage(_destination, _num, True)
            Application.DoEvents()
            If Not _img Is Nothing Then
                _list.Images.Add(_num.EAN13, _img)
                Dim _lvi As New ListViewItem(_num.ShotCode, _num.EAN13)
                _lvi.Name = _num.EAN13
                _lvItems.Add(_lvi)
            End If
            Me.lbLoadFile.Text = _num.ShotCode
            Me.lbLoadFile.Refresh()
        Next

        _lvItems.Sort(Function(x, y) x.ImageKey > y.ImageKey)
        Me.ListViewMain.Items.AddRange(_lvItems.ToArray)
        Me.ListViewMain.SmallImageList = _list
        Me.ListViewMain.LargeImageList = _list
        Me.lbLoadFile.Text = "samples count: " & _list.Images.Count
        Me.lbLoadFile.Refresh()
        Me.ListViewMain.Refresh()
        oShowManySamplesType = True
        If Not _sp Is Nothing Then
            _sp.Close()
        End If
    End Sub
    ''' <summary>
    ''' в значении да показывает, что отображены фотки образцов
    ''' </summary>
    ''' <remarks></remarks>
    Private oShowManySamplesType As Boolean

    Private Sub btCopyToAZURE_Click(sender As System.Object, e As System.EventArgs) Handles btCopyToAZURE.Click
        If Me.oCurrentSource.Source = emSources.AZURE Then
            MsgBox("Уже в архиве!", MsgBoxStyle.Critical)
            Exit Sub
        End If
        'получить устройство назначения
        Dim _destination As clsFilesSources
        _destination = clsFilesSources.CreateInstance(emSources.AZURE)
        Dim _fromSource = Me.GetSource(CType(Me.oCurrentSample, clsSampleNumber))
        Me.ToolStripStatusLabel1.Text = Me.oCurrentSample.EAN13 & " - копирование из " & _fromSource.ToString & " в " & _destination.ToString

        Me.ToolStripStatusLabel1.Text = "copy images. Please wait.. "
        Me.ToolStripStatusLabel1.Invalidate()
        For Each _tmp As ListViewItem In Me.ListViewMain.CheckedItems
            Me.ToolStripStatusLabel1.Text = "copy " & _tmp.Name
            Dim _num = clsSampleNumber.CreateFromString(_tmp.Name)
            If Not _num Is Nothing Then
                clsApplicationTypes.SamplePhotoObject.CopyImagesFromSourceToSource(_num, _fromSource, _destination, False)
            End If

        Next

        Me.ToolStripStatusLabel1.Text = "файлы скопированы"
    End Sub

    Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown1.ValueChanged
        LoadImages(True)
    End Sub
End Class
