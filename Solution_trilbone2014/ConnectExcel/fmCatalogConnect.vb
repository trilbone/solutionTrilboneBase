Imports Service.clsApplicationTypes
Imports Service
Imports Service.clsFilesSources
Public Class fmCatalogConnect
    Private oCatalog As clsCatalog
    'Private oSelectedSamplesList As New List(Of strSample)
    'Private oActiveSample As strSample

    Private _SamplecheckedIndexes As New List(Of Integer)
    Private _ImagecheckedIndexes As New List(Of Integer)

    Private Sub Clear()
        'locals
        oCatalog = Nothing
        _SamplecheckedIndexes = New List(Of Integer)
        _ImagecheckedIndexes = New List(Of Integer)
        UcPhotoList1.clear()

        'datasourses
        bdsImage.Clear()
        bdsSample.Clear()

        'lists
        lbSamplesList.DataSource = Nothing
        lbSamplesSelectedList.DataSource = Nothing
        lbImageList.DataSource = Nothing
        lbImageSelectedList.DataSource = Nothing

        'textboxes
        tbOrderName.Text = ""
        tbCatalogSampleSize.Text = ""
        tbFossilSizeA.Text = ""
        tbFossilSizeB.Text = ""
        tbSampleDescription.Text = ""
        tbSampleHeight.Text = ""
        tbSampleName.Text = ""
        tbSamplePrice.Text = ""
        tbSampleSizeA.Text = ""
        tbSampleSizeB.Text = ""
        tbWeight.Text = ""

        'cbx
        cbxOrderActive.Checked = False

        lbCatalogName.Text = "select catalog or image folder.."
    End Sub



    Private Sub btOpenCatalog_Click(sender As System.Object, e As System.EventArgs) Handles btOpenCatalog.Click
        Clear()

        Dim _initDir As String = Environment.SpecialFolder.MyComputer
        'If (Not My.Settings.LastCatalogPath = "") AndAlso IO.Directory.Exists(My.Settings.LastCatalogPath) Then
        '    _initDir = My.Settings.LastCatalogPath
        'Else
        '    _initDir = Environment.SpecialFolder.MyComputer
        'End If

        Me.fbdSelectCatalogFolder.RootFolder = Environment.SpecialFolder.MyComputer
        Me.fbdSelectCatalogFolder.SelectedPath = _initDir
        Me.fbdSelectCatalogFolder.ShowDialog()

        'My.Settings.LastCatalogPath = Me.fbdSelectCatalogFolder.SelectedPath
        'My.Settings.Save()



        'select catalog
        oCatalog = clsCatalog.CreateInstanse(Me.fbdSelectCatalogFolder.SelectedPath)

        If oCatalog Is Nothing Then
            MsgBox("Не удалось разобрать каталог!")
            Exit Sub
        End If
        'catalog in memory
        'If Not Service.clsApplicationTypes.SamplePhotoObject.IsConnected Then
        '    Service.clsApplicationTypes.SamplePhotoObject.Connect()
        'End If

        'data bindings
        lbSamplesList.DataSource = oCatalog.strSamples
        lbSamplesList.DisplayMember = "NUMBER"

        lbImageList.DataSource = oCatalog.strImages
        lbImageList.DisplayMember = "SampleNumber"

        lbSamplesList.DrawMode = DrawMode.OwnerDrawFixed
        'lbSamplesSelectedList.DrawMode = DrawMode.OwnerDrawFixed

        lbImageList.DrawMode = DrawMode.OwnerDrawFixed
        'lbImageSelectedList.DrawMode = DrawMode.OwnerDrawFixed

        AddHandler lbSamplesList.DrawItem, AddressOf SampleList_drawitem
        'AddHandler lbSamplesSelectedList.DrawItem, AddressOf SampleList_drawitem

        AddHandler lbImageList.DrawItem, AddressOf ImageList_drawitem
        'AddHandler lbImageSelectedList.DrawItem, AddressOf ImageList_drawitem




        'labels
        lbCatalogName.Text = oCatalog.Name

        CheckDB()

    End Sub



    Private Sub CheckDB()
        'check item in DB
        '///////////////////////
        For Each t As strSample In lbSamplesList.Items
            Dim num = Service.clsApplicationTypes.clsSampleNumber.CreateFromString(t.NUMBER)
            If Not num Is Nothing Then
                Dim _res As Integer
                'использование сервисов
                'выполняем вызов из сервиса
                ' dim _param as object={[parameters_list]}
                'если делегата нет, то сервис недоступен
                If Not Global.Service.clsApplicationTypes.DelegateStoreGetSampleInfoText Is Nothing Then
                    'сервис зарегестрирован - вызываем 
                    Dim res = Global.Service.clsApplicationTypes.DelegateStoreGetSampleInfoText.Invoke(num, Globalization.CultureInfo.CreateSpecificCulture("en-US"), _res)
                    Select Case _res
                        Case -1
                            'ошибка чтения БД
                        Case 0
                            'данных нет
                            _SamplecheckedIndexes.Add(lbSamplesList.Items.IndexOf(t))

                        Case 1, 2
                            'данные есть

                    End Select

                End If
            End If
        Next

        '///////////////////////

        'Images


        For Each t In lbImageList.Items
            Dim num = Service.clsApplicationTypes.clsSampleNumber.CreateFromString(t.SampleNumber)
            If Not num Is Nothing Then

                Dim c = clsFilesSources.CreateInstance(Service.clsFilesSources.emSources.Arhive)


                If Service.clsApplicationTypes.SamplePhotoObject.GetImageNamesList(num, c).Count > 0 Then
                    'есть фото в бд
                Else
                    'нет фото в бд
                    _ImagecheckedIndexes.Add(lbImageList.Items.IndexOf(t))
                End If
            End If
        Next




        'здесь есть массив индексов для красного

        '///////////////////////
    End Sub

    ''' <summary>
    ''' делает красными элементы, отсутствующие в БД
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub SampleList_drawitem(sender As Object, e As DrawItemEventArgs)
        e.DrawBackground()
        Dim mybrush As Brush = Brushes.Red

        If _SamplecheckedIndexes.Contains(e.Index) Then
            e.Graphics.DrawString(sender.Items(e.Index).ToString, e.Font, mybrush, e.Bounds, StringFormat.GenericDefault)
            e.DrawFocusRectangle()
        Else
            e.Graphics.DrawString(sender.Items(e.Index).ToString, e.Font, Brushes.Black, e.Bounds, StringFormat.GenericDefault)
            e.DrawFocusRectangle()
        End If

    End Sub
    ''' <summary>
    ''' делает красными элементы, отсутствующие в БД
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ImageList_drawitem(sender As Object, e As DrawItemEventArgs)
        e.DrawBackground()
        Dim mybrush As Brush = Brushes.Red

        If _ImagecheckedIndexes.Contains(e.Index) Then
            e.Graphics.DrawString(sender.Items(e.Index).ToString, e.Font, mybrush, e.Bounds, StringFormat.GenericDefault)
            e.DrawFocusRectangle()
        Else
            e.Graphics.DrawString(sender.Items(e.Index).ToString, e.Font, Brushes.Black, e.Bounds, StringFormat.GenericDefault)
            e.DrawFocusRectangle()
        End If

    End Sub



    Private Sub btSampleAddToSelected_Click(sender As System.Object, e As System.EventArgs) Handles btSampleAddToSelected.Click
        'check for list presets
        If Not Me.lbSamplesSelectedList.Items.Contains(lbSamplesList.SelectedItem) Then
            Me.lbSamplesSelectedList.Items.Add(lbSamplesList.SelectedItem)
        End If

    End Sub

    Private Sub btSampleRemoveFromSelected_Click(sender As System.Object, e As System.EventArgs) Handles btSampleRemoveFromSelected.Click
        Me.bdsSample.DataSource = Me.lbSamplesList.SelectedItem
        Me.lbSamplesSelectedList.Items.Remove(Me.lbSamplesSelectedList.SelectedItem)
    End Sub

    Private Sub lbSamplesList_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lbSamplesList.SelectedIndexChanged
        If Not lbSamplesList.SelectedItem Is Nothing Then
            Me.bdsSample.DataSource = lbSamplesList.SelectedItem
            Me.tbSampleSizeA.Text = 0
            Me.tbSampleSizeB.Text = 0
            Me.tbWeight.Text = 0
            Me.tbSampleHeight.Text = 0

        End If




    End Sub

    Private Sub lbImageList_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lbImageList.SelectedIndexChanged
        'If TypeOf lbImageList.SelectedItem Is strImage Then
        '    Me.bdsImage.DataSource = lbImageList.SelectedItem
        'End If
        If Not lbImageList.SelectedItem Is Nothing Then
            Me.bdsImage.DataSource = lbImageList.SelectedItem
        End If


    End Sub

    Private Sub lbSamplesSelectedList_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lbSamplesSelectedList.SelectedIndexChanged
        If Not lbSamplesSelectedList.SelectedItem Is Nothing Then
            Me.bdsSample.DataSource = lbSamplesSelectedList.SelectedItem
        End If
    End Sub

    Private Sub lbImageSelectedList_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lbImageSelectedList.SelectedIndexChanged
        If Not lbImageSelectedList.SelectedItem Is Nothing Then
            Me.bdsImage.DataSource = lbImageSelectedList.SelectedItem
        End If

    End Sub

    Private Sub btSampleMoveAll_Click(sender As System.Object, e As System.EventArgs) Handles btSampleMoveAll.Click
        Me.lbSamplesSelectedList.Items.Clear()

        Me.lbSamplesSelectedList.Items.AddRange(Me.lbSamplesList.Items)

    End Sub

    Private Sub bdsSample_DataSourceChanged(sender As Object, e As System.EventArgs) Handles bdsSample.DataSourceChanged
        If Not bdsSample.Current Is Nothing Then
            bdsImage.DataSource = oCatalog.GetstrImageByNumber(CType(bdsSample.Current, strSample).NUMBER)
        End If


    End Sub

    Private Sub btImageAddToSelected_Click(sender As System.Object, e As System.EventArgs) Handles btImageAddToSelected.Click
        'check for list presets
        If Not Me.lbImageSelectedList.Items.Contains(lbImageList.SelectedItem) Then
            Me.lbImageSelectedList.Items.Add(lbImageList.SelectedItem)
        End If

    End Sub

    Private Sub btImageRemoveFromSelected_Click(sender As System.Object, e As System.EventArgs) Handles btImageRemoveFromSelected.Click
        Me.bdsImage.DataSource = Me.lbImageList.SelectedItem
        Me.lbImageSelectedList.Items.Remove(Me.lbImageSelectedList.SelectedItem)
    End Sub

    Private Sub btImageMoveAll_Click(sender As System.Object, e As System.EventArgs) Handles btImageMoveAll.Click
        Me.lbImageSelectedList.Items.Clear()

        Me.lbImageSelectedList.Items.AddRange(Me.lbImageList.Items)
    End Sub



    Private Sub btSampleSaveInDB_Click(sender As System.Object, e As System.EventArgs) Handles btSampleSaveInDB.Click

        'TODO!!! проверить значения на входе!!

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

        'Function AddSampleInfo(ByVal Sample_parameter As Object, ByVal fossil_parameter As Object) As Integer
        '<param name="Sample_parameter">номер,основное название, длина, ширина, ВЫСОТА, вес в кг, исходная дата записи</param>
        '<param name="fossil_parameter">имена(), длины(), ш ирины()</param>
        '<returns>-3: ошибка в переданной структуре, -2: образец уже есть в базе, -1: переданных данных недостаточно для записи в БД, 0: некорректный номер, 1 и более: успешно добавлено </returns>
        Debug.Assert(Not Me.bdsSample.Current Is Nothing)

        If Me.bdsSample.Current Is Nothing Then Exit Sub


        Dim t = CType(Me.bdsSample.Current, strSample)
        Dim _result As Integer

        Dim _Sampleparam As Object = {t.NUMBER, t.NAME, tbSampleSizeA.Text, tbSampleSizeB.Text, tbSampleHeight.Text, tbWeight.Text, Now().ToString}
        Dim _Fossilparam As Object = {{t.NAME}, {tbFossilSizeA.Text}, {tbFossilSizeB.Text}}

        'если делегата нет, то сервис недоступен
        If Not Global.Service.clsApplicationTypes.DelegateStoreAddSampleDataIntoDB Is Nothing Then
            'сервис зарегестрирован - вызываем 
            _result = Global.Service.clsApplicationTypes.DelegateStoreAddSampleDataIntoDB.Invoke(_Sampleparam, _Fossilparam)
        Else
            _result = -4
        End If

        Select Case _result
            Case -4
                MsgBox("Сервис соединения с БД недоступен", MsgBoxStyle.Critical)
            Case -3
                MsgBox("ошибка в переданной структуре", MsgBoxStyle.Critical)
            Case -2
                MsgBox("образец уже есть в базе", MsgBoxStyle.Critical)
            Case -1
                MsgBox("переданных данных недостаточно для записи в БД", MsgBoxStyle.Critical)
            Case 0
                MsgBox("некорректный номер образца", MsgBoxStyle.Critical)
            Case Is >= 1
                MsgBox("успешно добавлено", MsgBoxStyle.Information)

        End Select


    End Sub



    Private Sub btSampleViewInfoFromDB_Click(sender As System.Object, e As System.EventArgs) Handles btSampleViewInfoFromDB.Click
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

        'Public Delegate Function GetSampleInfoTextDelegateFunction(ByVal SampleNumber As clsSampleNumber, ByRef _status As Integer) As String
        'свойство хранения делегата: текстовая инфо об образце. _status: (-1) - ошибка, (0) - данных нет, (1) - данные есть, (2) - данные есть полные

        Debug.Assert(Not Me.bdsSample.Current Is Nothing)

        If Me.bdsSample.Current Is Nothing Then Exit Sub

        Dim t = CType(Me.bdsSample.Current, strSample)
        Dim _result As Integer
        Dim _message As String = ""
        Dim _num = Service.clsApplicationTypes.clsSampleNumber.CreateFromString(t.NUMBER)

        If _num Is Nothing Then
            MsgBox("неккоректный номер " & t.NUMBER, MsgBoxStyle.Critical)
            Exit Sub
        End If

        'если делегата нет, то сервис недоступен
        If Not Global.Service.clsApplicationTypes.DelegateStoreGetSampleInfoText Is Nothing Then
            'сервис зарегестрирован - вызываем 
            _message = Global.Service.clsApplicationTypes.DelegateStoreGetSampleInfoText.Invoke(_num, Globalization.CultureInfo.CreateSpecificCulture("en-US"), _result)
        Else

        End If

        Select Case _result

            Case -1
                _message = "внутренняя ошибка" & t.NUMBER
            Case 0
                _message = "данных об образце нет " & t.NUMBER
            Case 1
                _message += "  НЕПОЛНЫЕ ДАННЫЕ"
            Case 2
                _message += "  ПОЛНЫЕ ДАННЫЕ"
        End Select
        MsgBox(_message)

    End Sub

    Private Sub btWritePrices_Click(sender As System.Object, e As System.EventArgs) Handles btWritePrices.Click
        Dim _arr As IList = Nothing


        Select Case MsgBox("Занести все образцы (нет - только текущий!)?", MsgBoxStyle.YesNo)
            Case MsgBoxResult.Yes
                _arr = Me.lbSamplesList.Items
            Case MsgBoxResult.No
                _arr = {Me.bdsSample.Current}
        End Select



        For Each t As strSample In _arr

            ' <summary>
            ' записывает в БД инфо об образце, принимая строгую структуру данных
            ' </summary>
            ' <param name="parameters">номер(decimal), начальная цена(decimal)</param>
            ' <returns>-3: ошибка в переданной структуре, -2: образец уже есть в базе, -1: переданных данных недостаточно для записи в БД, 0: некорректный номер, 1 и более: успешно добавлено </returns>



            Dim _result As Integer

            Dim _num = Service.clsApplicationTypes.clsSampleNumber.CreateFromString(t.NUMBER)

            If _num Is Nothing Then
                MsgBox("неккоректный номер " & t.NUMBER, MsgBoxStyle.Critical)
                Exit Sub
            End If

            If Me.tbSamplePrice.Text = "" Then Me.tbSamplePrice.Text = "0"

            'проверка
            Dim _price As Decimal
            Dim _res As Decimal
            If Not Decimal.TryParse(_price, _res) Then
                'пытаемся привести к нормали
                Dim r = Me.tbSamplePrice.Text.Split(" ")
                If r.Count > 1 Then
                    'две подстроки
                    'берем первую
                    If Not Decimal.TryParse(r(0), _res) Then
                        'преобразование невозможно
                        _res = 0
                        MsgBox("неккоректное значение цены " & t.NUMBER & " -->  " & Me.tbSamplePrice.Text, MsgBoxStyle.Critical)
                        GoTo nextsample
                    End If
                End If

            End If

            _res = Decimal.Parse(Me.tbSamplePrice.Text)

            Dim _param As Object = {_num.EAN13, _res}

            'если делегата нет, то сервис недоступен
            If Not Global.Service.clsApplicationTypes.DelegateStoreAddSampleOnSaleIntoDB Is Nothing Then
                'сервис зарегестрирован - вызываем 
                _result = Global.Service.clsApplicationTypes.DelegateStoreAddSampleOnSaleIntoDB.Invoke(_param)
            Else

            End If

            Dim _msg As String = ""

            Select Case _result
                Case -4
                    _msg = "Сервис соединения с БД недоступен " & t.NUMBER

                Case -3
                    _msg = "ошибка в переданной структуре " & t.NUMBER

                Case -2
                    _msg = "образец уже есть в базе " & t.NUMBER

                Case -1
                    _msg = "переданных данных недостаточно для записи в БД " & t.NUMBER

                Case 0
                    _msg = "некорректный номер образца  " & t.NUMBER

                Case Is >= 1

                    _msg = "успешно добавлено " & t.NUMBER
            End Select

            _msg += " Продолжить?"

            If MsgBox(_msg, vbYesNo) = MsgBoxResult.No Then
                Exit For
            End If



nextsample:

        Next

    End Sub

    Private Sub btOpenFiles_Click(sender As System.Object, e As System.EventArgs) Handles btOpenFiles.Click
        Clear()
        Dim _initDir As String = Environment.SpecialFolder.MyComputer
        'If (Not My.Settings.LastCatalogPath = "") AndAlso IO.Directory.Exists(My.Settings.LastCatalogPath) Then
        '    _initDir = My.Settings.LastCatalogPath
        'Else
        '    _initDir = Environment.SpecialFolder.MyComputer
        'End If

        Me.fbdSelectCatalogFolder.RootFolder = Environment.SpecialFolder.MyComputer
        Me.fbdSelectCatalogFolder.SelectedPath = _initDir
        Me.fbdSelectCatalogFolder.Description = "выберете папку, содержащую папки с номерами образцов"
        Me.fbdSelectCatalogFolder.ShowDialog()

        'My.Settings.LastCatalogPath = Me.fbdSelectCatalogFolder.SelectedPath
        'My.Settings.Save()

        Dim t = IO.Directory.EnumerateDirectories(Me.fbdSelectCatalogFolder.SelectedPath)

        If t.Count = 0 Then
            MsgBox("Нет подпапок в указанной директории", vbCritical)
            Exit Sub
        End If


        Dim k = (From c In t Where (Not clsImageFolder.CreateInstanse(c) Is Nothing) Select clsImageFolder.CreateInstanse(c)).ToList

        'catalog in memory
        'If Not Service.clsApplicationTypes.SamplePhotoObject.IsConnected Then
        '    Service.clsApplicationTypes.SamplePhotoObject.Connect()
        'End If


        If Not k.Count = 0 Then
            lbImageList.DataSource = k
            lbImageList.DisplayMember = "SampleNumber"


            lbImageList.DrawMode = DrawMode.OwnerDrawFixed
            'lbImageSelectedList.DrawMode = DrawMode.OwnerDrawFixed

            AddHandler lbImageList.DrawItem, AddressOf ImageList_drawitem
            'AddHandler lbImageSelectedList.DrawItem, AddressOf ImageList_drawitem

            CheckDB()
        Else
            MsgBox("в папке нет ни одной подпапки с номером образца", MsgBoxStyle.Critical)
        End If



    End Sub


    ''' <summary>
    ''' привызывает обновление изображений к смене текста(номера) в лабеле
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btImageSelectedNumber_TextChanged(sender As Object, e As System.EventArgs) Handles lbImageSelectedNumber.TextChanged
        'обновить изображения в окне просмотра
        'покажем 
        If Not bdsImage.Count = 0 Then
            Me.UcPhotoList1.SetSampleNumber(lbImageSelectedNumber.Text, CType(bdsImage.Current, clsImageFolder).BasePath)
        End If


        ''покажем из каталога (или из папки)
        'If Not oCatalog Is Nothing Then
        '    'покажем из каталога


        '    If Not bdsImage.Count = 0 Then
        '        Me.UcPhotoList1.SetSampleNumber(lbImageSelectedNumber.Text, CType(bdsImage.Current, clsImageCatalog).BasePath)
        '        'Me.UcPhotoList1.Source = clsFilesSources.CreateInstance(Service.clsFilesSources.emSources.FreeFolder, , False, CType(bdsImage.Current, strImage).LowImagePath)
        '    End If
        'Else
        '    'покажем из папки
        '    If Not bdsImage.Count = 0 Then
        '        Me.UcPhotoList1.SetSampleNumber(lbImageSelectedNumber.Text, CType(bdsImage.Current, clsImageFolder).BasePath)
        '        'Me.UcPhotoList1.Source = clsFilesSources.CreateInstance(Service.clsFilesSources.emSources.FreeFolder, , False, CType(bdsImage.Current, strImageFolder).ImagePath)
        '    End If

        'End If




    End Sub

    'Private Sub cbxShowImages_CheckedChanged(sender As System.Object, e As System.EventArgs)
    '    lvImagePictureList.Items.Clear()
    'End Sub

    Private Sub bdsImage_CurrentChanged(sender As Object, e As System.EventArgs) Handles bdsImage.CurrentChanged
        If Not bdsImage.Current Is Nothing Then
            Me.lbImageSelectedNumber.Text = bdsImage.Current.SampleNumber

        End If
    End Sub
    ''' <summary>
    ''' копирование в устройство
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btImageSaveInDB_Click(sender As System.Object, e As System.EventArgs) Handles btImageSaveInDB.Click


        'задать устройство принимающее - arhive
        Dim _Tosource As clsFilesSources = clsFilesSources.CreateInstance(emSources.Arhive)


        'задать устройство источник
        Dim _Fromsource As clsFilesSources = UcPhotoList1.Source

        Debug.Assert(Not _Fromsource Is Nothing)
        If _Fromsource Is Nothing Then Exit Sub

        'проверить, сколько было выделено фото
        Dim _result As Integer
        If UcPhotoList1.SelectedItems.Count = 0 Then
            Select Case MsgBox("Не выделено ни одной фото, скопировать все?", MsgBoxStyle.YesNo)
                Case MsgBoxResult.Yes
                    _result = SamplePhotoObject.CopyImagesFromSourceToSource(UcPhotoList1.SampleNumber, _Fromsource, _Tosource, False, UcPhotoList1.Items.ToArray)
                Case MsgBoxResult.No
                    _result = 0
            End Select
        Else
            'copy selected
            _result = SamplePhotoObject.CopyImagesFromSourceToSource(UcPhotoList1.SampleNumber, _Fromsource, _Tosource, False, UcPhotoList1.SelectedItems.ToArray)
        End If

        'MsgBox("скопировано " & _result & " файлов")
        MsgBox("файлы скопированы")
    End Sub

    Private Sub btOpenManager_Click(sender As System.Object, e As System.EventArgs) Handles btOpenManager.Click
        '///////////////////////
        ''использование сервисов
        ''выполняем вызов из сервиса
        Dim _param As Object
        If Not bdsImage.Current Is Nothing Then
            _param = {CType(Me.bdsImage.Current, clsImageFolder).SampleNumber, CType(Me.bdsImage.Current, clsImageFolder).BasePath}
        Else
            _param = {}
        End If


        'если делегата нет, то сервис недоступен
        If Not Global.Service.clsApplicationTypes.DelegateStoreApplicationForm(emFormsList.fmImageManager) Is Nothing Then
            'сервис зарегестрирован - вызываем 
            Dim _fm = Global.Service.clsApplicationTypes.DelegateStoreApplicationForm(emFormsList.fmImageManager).Invoke(_param)
            _fm.ShowDialog()
        Else

        End If
        '///////////////////////


    End Sub


    Private Sub btEditSample_Click(sender As System.Object, e As System.EventArgs) Handles btEditSample.Click
        Dim _param As Object = {CType(Me.bdsSample.Current, strSample).NUMBER}
        Dim _fmSampleData As Form

        'по запросу выполняем вызов из сервиса
        'если делегата нет, то сервис недоступен
        If Not Global.Service.clsApplicationTypes.DelegateStoreApplicationForm _
            (Service.clsApplicationTypes.emFormsList.fmSampleData) Is Nothing Then
            'сервис зарегестрирован - вызываем
            _fmSampleData = Global.Service.clsApplicationTypes.DelegateStoreApplicationForm _
                (Service.clsApplicationTypes.emFormsList.fmSampleData).Invoke(_param)
        Else
            Exit Sub
        End If

        ''сохранить запись
        'Me.Select_tb_SamplesOnSaleBindingSource.EndEdit()
        'Me.TableAdapterManager1.UpdateAll(Me.SampleOnSale)
        ''открыть окно
        If Not _fmSampleData Is Nothing AndAlso _fmSampleData.IsDisposed = False Then
            _fmSampleData.ShowDialog()
        End If
    End Sub
    ''' <summary>
    ''' разбор длин
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tbCatalogSampleSize_TextChanged(sender As System.Object, e As System.EventArgs) Handles tbCatalogSampleSize.TextChanged
        If Not Me.bdsSample.Current Is Nothing Then
            tbFossilSizeA.Text = CType(Me.bdsSample.Current, strSample).parsedSIZE.First
            tbFossilSizeB.Text = CType(Me.bdsSample.Current, strSample).parsedSIZE.Last
        Else
            Me.tbFossilSizeA.Text = 0
            Me.tbFossilSizeB.Text = 0

        End If


    End Sub



    Private Sub bdsSample_CurrentChanged(sender As System.Object, e As System.EventArgs) Handles bdsSample.CurrentChanged

    End Sub
End Class
