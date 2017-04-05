Imports System.Windows.Forms
Imports System.Linq
Public Class ucPhotoList



    Private oActiveImagePopUp As Form
    Private oFreeSource As Service.clsFilesSources
    Private oActiveSource As clsFilesSources




    Private oSampleNumber As clsApplicationTypes.clsSampleNumber
    ''' <summary>
    ''' выдает/ устанавливает активный образец
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SampleNumber As clsApplicationTypes.clsSampleNumber
        Get
            Return oSampleNumber
        End Get
        Set(ByVal value As clsApplicationTypes.clsSampleNumber)
            oSampleNumber = value
            If Not oSampleNumber Is Nothing Then
                Me.lbSampleNumber.Text = oSampleNumber.EAN13
                Me.Source = clsFilesSources.CreateInstance(clsFilesSources.emSources.Arhive)
            End If

        End Set
    End Property
    ''' <summary>
    ''' устанавливает активный образец из строки
    ''' </summary>
    ''' <param name="SampleNumberString"></param>
    ''' <remarks></remarks>
    Public Sub SetSampleNumber(ByVal SampleNumberString As String, Optional ByVal FreeSourceFullPath As String = "")
        Dim num = clsApplicationTypes.clsSampleNumber.CreateFromString(SampleNumberString)

        If Not num Is Nothing Then
            Me.SampleNumber = num
            Me.oFreeSource = clsFilesSources.CreateInstance(clsFilesSources.emSources.FreeFolder, , , FreeSourceFullPath)

        End If
    End Sub

    ''' <summary>
    ''' получить/установит устройство-источник
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Source As clsFilesSources
        Get
            Return oActiveSource
        End Get
        Set(ByVal value As clsFilesSources)
            If Not value Is Nothing Then
                'oFreeSource = Nothing
                Select Case value.Source
                    Case clsFilesSources.emSources.Arhive
                        Me.rbDb.Checked = True
                        Me.RbOuter.Checked = False
                        oActiveSource = clsFilesSources.CreateInstance(clsFilesSources.emSources.Arhive)
                        Me.lbSource.Text = "источник - Arhive"
                    Case clsFilesSources.emSources.FreeFolder
                        Me.rbDb.Checked = False
                        Me.RbOuter.Checked = True
                        oActiveSource = value
                        Me.lbSource.Text = "источник - внешняя папка " & value.ContainerPath
                    Case clsFilesSources.emSources.AZURE, clsFilesSources.emSources.SpecificOrder
                        Me.rbDb.Checked = True
                        Me.RbOuter.Checked = False
                        '' в дальнейшем - изменить!
                        oActiveSource = clsFilesSources.CreateInstance(clsFilesSources.emSources.AZURE)
                        Me.lbSource.Text = "источник - Current"

                    Case clsFilesSources.emSources.AllSources, clsFilesSources.emSources.SpecificOrder
                        Me.rbDb.Checked = True
                        Me.RbOuter.Checked = False
                        ''TODO в дальнейшем - изменить!
                        oActiveSource = clsFilesSources.CreateInstance(clsFilesSources.emSources.AllSources)
                        Me.lbSource.Text = "источник - БД (все устройства)"
                End Select
                'обновить лист

                refreshList()

            End If



        End Set
    End Property

    Public Sub clear()
        Me.oActiveSource = Nothing
        Me.oFreeSource = Nothing
        Me.oSampleNumber = Nothing
        Me.lvBox.Clear()
        Me.pbTitle.Image = Nothing
        Me.tbPrevievTime.Text = "1"
        Me.lbSampleNumber.Text = ""
        Me.lbSource.Text = ""
        Me.cbxPopUp.Checked = False
        Me.cbxShowImages.Checked = False
        Me.rbDb.Checked = False
        Me.RbOuter.Checked = False
    End Sub



    Public Overrides Sub Refresh()
        MyBase.Refresh()

        If oSampleNumber Is Nothing Then Exit Sub

        If oActiveSource Is Nothing Then Exit Sub

        Me.refreshList()
    End Sub
    Public Event ImageLoaded(ByVal sender As Object, ByVal e As EventArgs)

    Private Sub refreshList()
        Debug.Assert(Not oSampleNumber Is Nothing)
        Debug.Assert(Not oActiveSource Is Nothing)

        'тут перерисовываем список
        Me.lvBox.Clear()
        Me.pbTitle.Image = Nothing
        If Me.cbxShowImages.Checked = False Then Exit Sub

        If oSampleNumber Is Nothing Then Exit Sub

        If oActiveSource Is Nothing Then Exit Sub

        'проверка в БД
        If clsApplicationTypes.SamplePhotoObject.HasImages(oSampleNumber, oActiveSource) Then
            'в БД фотки есть
            Me.Cursor = Cursors.WaitCursor
            ''image 160*120
            Dim _ImageList As Service.SampleSourceImageList = Service.clsApplicationTypes.SamplePhotoObject.GetSampleImageList(oSampleNumber, oActiveSource, New Drawing.Size(160, 120), False)

            If Not _ImageList Is Nothing Then

                With lvBox
                    .View = View.LargeIcon
                    .BeginUpdate()
                    .Items.AddRange(_ImageList.ListViewItems)
                    .SmallImageList = _ImageList.ImageList
                    .LargeImageList = _ImageList.ImageList
                    .EndUpdate()
                    Me.lbSource.Text += " //: " & .Items.Count & " фото"
                End With

                'отобразим окно с большой первой фоткой (или с титульной фото)

                Dim _tit = clsApplicationTypes.SamplePhotoObject.GetMainImage(oActiveSource, oSampleNumber)
                Dim _popName As String = ""
                If _tit Is Nothing Then
                    If Me.Items.Count > 0 Then
                        _popName = Me.Items(0)
                    Else
                        GoTo ex
                    End If

                Else
                    _popName = clsApplicationTypes.SamplePhotoObject.GetMainImageName(oSampleNumber, oActiveSource)
                    Me.pbTitle.Image = _tit
                End If

                If Me.cbxPopUp.Checked Then
                    Call Me.ShowImageForm(_popName)
                    Me.Timer1.Interval = CType(Me.tbPrevievTime.Text, Integer) * 1000
                    If Me.Timer1.Interval > 0 Then
                        Me.Timer1.Start()
                    End If
                End If
            Else

            End If


ex:
            Me.Cursor = Cursors.Default
            RaiseEvent ImageLoaded(Me, EventArgs.Empty)

        Else
            Me.lbSource.Text += ": НЕТ ФОТО"

        End If


    End Sub

    ''' <summary>
    ''' закрыть popup форму после срабатывания таймера
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If Not oActiveImagePopUp Is Nothing Then
            oActiveImagePopUp.Close()
        End If

        Timer1.Stop()
    End Sub

    ''' <summary>
    ''' показать увеличенное изображение
    ''' </summary>
    ''' <param name="ImageName"></param>
    ''' <param name="ShowAllImages"></param>
    ''' <remarks></remarks>
    Private Sub ShowImageForm(ByVal ImageName As String, Optional ByVal ShowAllImages As Boolean = False)


        Dim _prm As Object

        If ShowAllImages Then
            _prm = Service.clsApplicationTypes.SamplePhotoObject.GetSampleImageList(Me.oSampleNumber, oActiveSource, New Drawing.Size(160, 120), False)
        Else
            _prm = Service.clsApplicationTypes.SamplePhotoObject.GetImage(oActiveSource, Me.oSampleNumber, ImageName, False)
        End If

        'show image form
        'использование сервисов
        'по запросу выполняем вызов из сервиса

        Dim _param As Object
        _param = {_prm, oSampleNumber.EAN13}


        'если делегата нет, то сервис недоступен
        If Not Global.Service.clsApplicationTypes.DelegateStoreApplicationForm(Service.clsApplicationTypes.emFormsList.fmImage) Is Nothing Then
            'сервис зарегестрирован - вызываем
            oActiveImagePopUp = Global.Service.clsApplicationTypes.DelegateStoreApplicationForm(Service.clsApplicationTypes.emFormsList.fmImage).Invoke(_param)
            If Not oActiveImagePopUp Is Nothing Then
                'show form
                With oActiveImagePopUp
                    .Width = 640
                    .Height = 480

                    .Name = "ImageShowForm"
                    .StartPosition = FormStartPosition.CenterScreen
                    .Show()
                End With

            End If
        Else

        End If


    End Sub
    ''' <summary>
    ''' имена файлов выделенных фото
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property SelectedItems As List(Of String)
        Get
            Dim i = (From c As ListViewItem In lvBox.SelectedItems Select c.Name).ToList


            Return i
        End Get
    End Property
    ''' <summary>
    ''' имена файлов отмеченных фото
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property CheckedItems As List(Of String)
        Get
            Dim i = (From c As ListViewItem In lvBox.CheckedItems Select c.Name).ToList


            Return i
        End Get
    End Property
    ''' <summary>
    ''' имена файлов отображенных фото
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Items As List(Of String)
        Get

            Dim i = (From c As ListViewItem In lvBox.Items Select c.Name).ToList


            Return i

        End Get
    End Property
    ''' <summary>
    ''' показать окно фото
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub lvBox_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvBox.DoubleClick
        If lvBox.SelectedItems.Count = 0 Then Exit Sub
        Call Me.ShowImageForm(Me.SelectedItems(0), True)
    End Sub

    ''' <summary>
    ''' задать главное фото нажатием клавиши м
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub lvBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles lvBox.KeyPress
        If Char.ToString(e.KeyChar) = "m" Or Char.ToString(e.KeyChar) = "M" Then
            If Me.SelectedItems.Count = 0 Then
                MsgBox("Необходимо выделить главное фото", vbCritical)
                Exit Sub
            End If

            'задать главное фото
            Dim _imgName As String = Me.SelectedItems(0)
            If MsgBox("Задать главное фото " & _imgName & " ?", MsgBoxStyle.Question) = MsgBoxResult.No Then
                Exit Sub
            End If

            'записать на устройство
            'задать устройство принимающее
            'ПОДУМАТЬ ЕЩЕ НАД УСТРОЙСТВАМИ
            If oActiveSource.Source = clsFilesSources.emSources.AllSources Then
                'задать титул ТОЛЬКО в архиве или в текущих!
                Dim c = clsApplicationTypes.SamplePhotoObject.GetSourcesList(oSampleNumber, False)


                Dim d = clsFilesSources.CreateInstance(clsFilesSources.emSources.Arhive)
                Dim d1 = clsFilesSources.CreateInstance(clsFilesSources.emSources.AZURE)
                If c.Contains(d) Then
                    If Not clsApplicationTypes.SamplePhotoObject.CreateMainImageOnSource(Me.oSampleNumber, _imgName, d) Then
                        MsgBox("Главное фото не установлено!", MsgBoxStyle.Critical)
                    Else
                        'обновить титул
                        Me.pbTitle.Image = clsApplicationTypes.SamplePhotoObject.GetMainImage(oActiveSource, oSampleNumber)
                    End If
                    Exit Sub
                End If

                If c.Contains(d1) Then
                    If Not clsApplicationTypes.SamplePhotoObject.CreateMainImageOnSource(Me.oSampleNumber, _imgName, d1) Then
                        MsgBox("Главное фото не установлено!", MsgBoxStyle.Critical)
                    Else
                        'обновить титул
                        Me.pbTitle.Image = clsApplicationTypes.SamplePhotoObject.GetMainImage(oActiveSource, oSampleNumber)
                    End If
                    Exit Sub
                End If


            End If


        End If

    End Sub
    ''' <summary>
    ''' показывать фото?
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ShowPhoto As Boolean
        Set(ByVal value As Boolean)
            Me.cbxShowImages.Checked = value
            If value = False Then
                lvBox.Clear()
            End If

        End Set
        Get
            Return Me.cbxShowImages.Checked
        End Get
    End Property
    ''' <summary>
    ''' показывать всплывающее окно?
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ShowPopUp As Boolean
        Set(ByVal value As Boolean)
            cbxPopUp.Checked = value


        End Set
        Get
            Return cbxPopUp.Checked
        End Get
    End Property


    ''' <summary>
    ''' дополнительное устройство с фото. используется для запоминания свободного источника
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property FreeSource As clsFilesSources
        Set(ByVal value As clsFilesSources)
            oFreeSource = value
        End Set
        Get
            Return oFreeSource
        End Get
    End Property



    Private Sub rbDb_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbDb.CheckedChanged
        If oActiveSource Is Nothing Then Exit Sub
        If rbDb.Checked = True Then
            'переключиться в БД
            Select Case oActiveSource.Source
                Case clsFilesSources.emSources.FreeFolder
                    Me.Source = Service.clsFilesSources.CreateInstance(clsFilesSources.emSources.Arhive)
                Case Else


            End Select
        Else
            'переключиться в свободное устройство
            Me.Source = oFreeSource
        End If
    End Sub

    Private Sub cbxShowImages_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles cbxShowImages.CheckedChanged
        If Not (oSampleNumber Is Nothing And oActiveSource Is Nothing) Then
            Me.refreshList()

        End If
    End Sub
End Class
