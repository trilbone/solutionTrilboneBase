Imports Service
Imports System.Linq
Imports Trilbone
Imports Service.clsApplicationTypes
Imports System.Drawing.Printing
Imports System.Drawing.Imaging
Imports System.Runtime.InteropServices
Imports System.Text.RegularExpressions
Imports System.Reflection
Imports Photo_reader.clsLayer
Imports Service.clsFilesSources
Imports System.Xml.Linq

Public Class fmSampleData
    Implements iListSampleDataProvider
    Private oSampleNumber As clsApplicationTypes.clsSampleNumber
    Dim oNeedResetPrinters As Boolean = False
    Dim oInit As Boolean
    Private oReadySampleDBContext As DBREADYSAMPLEEntities
    ''' <summary>
    ''' флаг будет усановлен, если описание прочитано из БД
    ''' </summary>
    ''' <remarks></remarks>
    Private oDescriptionFromBDFlag As Boolean
    Private ReadOnly oCurrentSource As clsFilesSources = clsFilesSources.CreateInstance(clsFilesSources.emSources.Arhive)
    Private oImageLoaded As Boolean
    ''' <summary>
    ''' если есть фотки у текущего
    ''' </summary>
    ''' <remarks></remarks>
    Private oCurrentHasImages As Boolean


    Public Event SampleNumberAccepted(sender As Object, e As clsWriteSampleToListEventsArg) Implements iListSampleDataProvider.WriteSampleToList

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()



        init()

        'load frases
        If My.Settings.FraseBuffer Is Nothing Then
            My.Settings.FraseBuffer = New Collections.Specialized.StringCollection
        End If
        For Each t In My.Settings.FraseBuffer
            Me.lbFrase.Items.Add(t)
        Next

    End Sub

    Public Sub New(ByVal SampleNumber As Decimal)
        InitializeComponent()
        'fill from table
        init()
        Select Case Global.Service.clsApplicationTypes.DataStoreSource

            Case Service.clsApplicationTypes.emStoreSourses.dbo
                'при использовании бд dsPhotoData заполняется в методе LoadSample

            Case Service.clsApplicationTypes.emStoreSourses.xml
                'прочитать файл
                Dim _FillPath As String = Service.clsApplicationTypes.xmldboPhotoStorePath
                If IO.File.Exists(_FillPath) Then
                    Me.DsPhotoData.ReadXml(_FillPath, XmlReadMode.Auto)
                End If
        End Select
        'загрузка списка работников
        Me.Woker_full_nameComboBox.Items.Clear()
        Me.Woker_full_nameComboBox.Items.Add(Global.Service.clsApplicationTypes.CurrentUser.UserShotName)
        'загрузка списка фоссилий
        'список фоссилий
        'грузим словарь
        If Me.cbMaterial.Items.Count = 0 Then
            If clsApplicationTypes.CurrentNamesList.Count > 0 Then
                Me.cbMaterial.Items.AddRange(clsApplicationTypes.CurrentNamesList.Keys.ToArray)
            End If
        End If
        '------load sample
        Me.oSampleNumber = clsApplicationTypes.clsSampleNumber.CreateFromString(SampleNumber.ToString)

        If Not oSampleNumber Is Nothing AndAlso oSampleNumber.CodeIsCorrect Then
            Me.LoadSample()
        Else
            'неправильный номер
            Me.lbSampleStatus.Text = "Номер ?"
            Me.LockedAll()
            Me.SampleNumberTextBox.Focus()
            Me.btGetNumber.Enabled = True
            btDescriptionForm.Enabled = True
        End If

        'load frases
        If My.Settings.FraseBuffer Is Nothing Then
            My.Settings.FraseBuffer = New Collections.Specialized.StringCollection
        End If
        For Each t In My.Settings.FraseBuffer
            Me.lbFrase.Items.Add(t)
        Next

    End Sub

    Private Sub init()
        oReadySampleDBContext = clsApplicationTypes.SampleDataObject.GetdbReadySampleObjectContext
        'заполним префиксы
        Me.cbPrefixElement.Items.Clear()
        Me.cbTagOfElement.Items.Clear()
        Select Case oCurrentCulture.Name
            Case clsApplicationTypes.EnglishCulture.Name
                Me.cbPrefixElement.Items.AddRange({"Additional info", "Reconstruction", ""})
            Case clsApplicationTypes.EnglishCulture.Name
                Me.cbPrefixElement.Items.AddRange({"Доп.инфо", "Реконструкция", ""})
            Case Else
                Me.cbPrefixElement.Items.AddRange({"Additional info", "Reconstruction", ""})
        End Select

        Me.cbTagOfElement.Items.AddRange({"USERDESCR", "ITEM"})

        Me.cbPrefixElement.SelectedIndex = 0
        Me.cbTagOfElement.SelectedIndex = 0
    End Sub

    Private Function SaveToDB(showmessage As Boolean) As String
        Dim _message As String = ""

        Me.Select_tb_Samples_photo_dataBindingSource.EndEdit()
        Me.Select_tb_Samples_FossilsBindingSource.EndEdit()
        Dim _description As String = ""
        Dim _labeldescription As String = ""


        If Not oSampleDataObj Is Nothing Then
            If Not oCurrentXMLDescription Is Nothing Then
                _description = oCurrentXMLDescription.ToString
                oSampleDataObj.Description = _description
            End If

            If Not oLabel Is Nothing Then
                oCurrentLabelDescription = oLabel.GetXElements
                If Not oCurrentLabelDescription Is Nothing Then
                    _labeldescription = oCurrentLabelDescription.ToString
                    oSampleDataObj.SampleXMLDescription = _labeldescription
                End If
            End If
        End If


        Select Case Global.Service.clsApplicationTypes.DataStoreSource
            Case Service.clsApplicationTypes.emStoreSourses.dbo
                If clsApplicationTypes.SampleDataObject.SaveReadySampleContext() > 0 Then
                    _message += "Сохранено описание." & ChrW(13)
                    Me.lbSampleStatus.BackColor = Label.DefaultBackColor
                    clsApplicationTypes.BeepYES()
                End If

                Dim _result2 = Me.TableAdapterManager.UpdateAll(Me.DsPhotoData)
                If _result2 > 0 Then
                    _message += "Сохранено " & _result2.ToString & " записей в БД."
                    Me.lbSampleStatus.BackColor = Color.Green
                    clsApplicationTypes.BeepYES()
                End If

            Case Service.clsApplicationTypes.emStoreSourses.xml

                Me.DsPhotoData.WriteXml(Service.clsApplicationTypes.xmldboPhotoStorePath, XmlWriteMode.DiffGram)
                _message += "Файл данных сохранен локально. Описание не сохранено"
                clsApplicationTypes.BeepYES()
        End Select



        If showmessage Then
            MsgBox(_message, MsgBoxStyle.Information, "Сохранение в базе данных")
        End If

        Return _message
    End Function

    Private Sub btSaveAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSaveAll.Click
        Me.Validate()
        SaveToDB(False)
    End Sub

    Private Sub SampleNumberTextBox_Enter(sender As Object, e As EventArgs) Handles SampleNumberTextBox.Enter
        If oInit Then Return
        Me.SampleNumberTextBox.Text = ""
    End Sub

    Private Sub SampleNumberTextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles SampleNumberTextBox.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            If Me.SampleNumberTextBox.Text.Length = 13 Then
                Me.SampleNumberTextBox.Text = ""
            End If
        End If

        If Asc(e.KeyChar) = 13 Then
            Me.btSearchInfo_Click(sender, e)
        End If
    End Sub

    ''' <summary>
    ''' проверка и загрузка из БД. Вернет фальш, если данных нет
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function LoadSample() As Boolean


        If oSampleNumber Is Nothing Then Return False
        oInit = True
        Me.SuspendLayout()

        If Not Me.UcFossilTabPage1 Is Nothing Then
            Me.UcFossilTabPage1.Clear()
        End If
        Me.Sample_main_speciesComboBox.Items.Clear()

        If Me.cbMaterial.Items.Count > 0 Then
            'перезагрузить список имен из загруженных
            Me.cbMaterial_DropDownClosed(Me, EventArgs.Empty)
        Else
            'добавить список всех имен
            Me.Sample_main_speciesComboBox.Items.AddRange(clsApplicationTypes.MyTreesSystematicaNames.ToArray)
            Me.Sample_main_speciesComboBox.SelectedIndex = -1
        End If

        Me.Uc_trilbone_history1.clear()
        Me.pbMainImage.Image = Nothing
        Me.UserDescriptionRichTextBox.Text = ""
        Me.oSampleDataObj = Nothing
        Me.lbElements.DataSource = Nothing
        Me.ClsLabelInfoBindingSource.DataSource = Nothing
        Me.DescriptionRichTextBox.Text = ""
        Me.rtbLabel.Text = ""
        Me.btRecToDB.BackColor = Control.DefaultBackColor
        Me.btSearchLabels.Text = "Искать этикетку в БД"
        Me.btCopyToLabelinfo.BackColor = Control.DefaultBackColor
        Me.btCopyToLabel.BackColor = Control.DefaultBackColor
        Me.btRecToDB.BackColor = Control.DefaultBackColor
        Me.oLabelinfoToRecinDB.Clear()
        oCurrentElementsCollection = Nothing
        Me.cbSearchLabelsResult.DataSource = Nothing
        Me.btCreateDescription.Enabled = False
        Me.UcGoodLabel1.Clear()
        oLabelImages.Clear()
        oLabelImagesWithoutFilter.Clear()
        ooldBigObjectIndex = 0
        oCurrentHasImages = False

        For Each _ctl As Control In Me.tpPhoto.Controls
            _ctl.Enabled = False
        Next

        Me.tpctlMain.SelectedIndex = 0

        SampleNumberTextBox.Text = oSampleNumber.EAN13
        Me.lbSampleStatus.Text = oSampleNumber.ShotCode


        Dim _recordCount As Integer = 0
        Select Case Global.Service.clsApplicationTypes.DataStoreSource
            Case Service.clsApplicationTypes.emStoreSourses.dbo
                'работаем с бд
                Try
                    Me.Select_tb_Samples_photo_dataTableAdapter.Fill _
                                  (Me.DsPhotoData.Select_tb_Samples_photo_data, oSampleNumber.GetEan13)
                    Me.Select_tb_Samples_FossilsTableAdapter.Fill _
                        (Me.DsPhotoData.Select_tb_Samples_Fossils, oSampleNumber.GetEan13)
                    Me.GetFossilsCountInSampleTableAdapter.Fill _
                        (Me.DsPhotoData.GetFossilsCountInSample, oSampleNumber.GetEan13)
                Catch ex As Exception
                    MsgBox("Can't connect to DB", vbCritical)
                    oInit = False
                    Return False
                End Try

                Me.Select_tb_Samples_photo_dataBindingSource.ResetBindings(False)
                _recordCount = Me.Select_tb_Samples_photo_dataBindingSource.Count

            Case Service.clsApplicationTypes.emStoreSourses.xml
                'работаем отсоединенно
                'найти в таблице номер или создать новый
                Dim _rows As DataRow() = Me.DsPhotoData.Select_tb_Samples_photo_data.Select _
("SampleNumber = " & oSampleNumber.EAN13)
                _recordCount = _rows.Length
                Select Case _recordCount
                    Case 0
                        'номера нет, создать запись
                    Case 1
                        'номер есть, настроить binding_sourse
                        Me.Select_tb_Samples_photo_dataBindingSource.Position = _
                            Me.Select_tb_Samples_photo_dataBindingSource.Find("SampleNumber", oSampleNumber.EAN13)

                    Case Else
                        'в таблице несколько повторяющихся записей
                        MsgBox("В таблице несколько повторяющихся записей!", MsgBoxStyle.Critical)
                        'номер есть, настроить binding_sourse
                        Me.Select_tb_Samples_photo_dataBindingSource.Position = _
                            Me.Select_tb_Samples_photo_dataBindingSource.Find("SampleNumber", oSampleNumber.EAN13)
                End Select
        End Select

        Me.UcPhotoManager1.Enabled = True

        'проверка записи
        If _recordCount = 0 Then
            'будет новый камень
            Dim _version() As Byte = {0}
            Dim _row As DataRow = Me.DsPhotoData.Select_tb_Samples_photo_data. _
                AddSelect_tb_Samples_photo_dataRow _
                (oSampleNumber.GetEan13, 0, 0, 0, 0, "", "", 0, "", Date.Now, _version)
            Me.Select_tb_Samples_photo_dataBindingSource.Position = _
                Me.Select_tb_Samples_photo_dataBindingSource.Find("SampleNumber", oSampleNumber.EAN13)
            Me.Woker_full_nameComboBox.SelectedIndex = -1
            clsApplicationTypes.BeepNOT()

        Else
            '---запись есть
            If Me.cbMaterial.Items.Count > 0 Then
                Me.cbMaterial.SelectedIndex = Me.cbMaterial.Items.Count - 1
            End If

            'проверка подготовки к продаже
            Dim _result As Integer
            Dim _sdo = clsApplicationTypes.SampleDataObject.GetSampleOnSale(oSampleNumber, _result, CreateIfNotExist:=True)
            If Not _sdo Is Nothing AndAlso _result > 0 Then
                Me.cbReadyForSale.Checked = _sdo.OnSaleFlag.GetValueOrDefault
                'If Me.cbReadyForSale.Checked Then
                '    Me.cbxGetXMLFromDB.Checked = True
                'End If
                Me.lblOnSaleCreator.Text = IIf(Me.cbReadyForSale.Checked, _sdo.OnSaleCreator, "не готов")

                If _sdo.SampleXMLFile = "" Then
                    'карты нет
                    Me.btShowMap.BackColor = Color.Red
                    Me.cbReadyForSale.Checked = False
                    Me.cbxGetXMLFromDB.Checked = False
                Else
                    Me.btShowMap.BackColor = Color.Green
                    Me.cbxGetXMLFromDB.Checked = True
                    Me.cbReadyForSale.Checked = True
                End If
            End If


            'загрузка страниц фоссилий
            Me.CreateFossilPages()
        End If

        'check photos
        ReadPhotos()

        'загрузить описание
        ' описание
        ReadDescription()

        'перенесено на изменение вкладки
        ' Box_Calculate()

        Me.UnlockedAll()

        Me.ResumeLayout()

        Me.lbSampleStatus.Text = oSampleNumber.ShotCode



        If _recordCount > 0 Then
            'этикетка
            Me.UcGoodLabel1.NameForLabel = Me.Sample_main_speciesComboBox.Text
            Me.UcGoodLabel1.Source = ucGoodLabel.emLabelSource.DrawAi
            Me.btDrawLabel_Click(Me, EventArgs.Empty)

            If Me.Sample_net_weightTextBox.Text = "" OrElse Me.Sample_net_weightTextBox.Text = "0" Then
                Me.Sample_net_weightTextBox.Focus()
            End If

            Me.lbSampleStatus.BackColor = Color.Green

            'залинковать к спискам
            'If Me.oRegisterFlag Then
            '    RaiseEvent SampleNumberAccepted(Me, New clsWriteSampleToListEventsArg With {.SampleNumber = oSampleNumber, .AutoWrite = False})
            'End If

            Me.Focus()
            oInit = False
            Return True
        Else
            'нет в бд, вводим данные  'будет новый камень
            Me.lbSampleStatus.BackColor = Color.Red
            Me.Sample_net_weightTextBox.Focus()
            Me.Focus()
            oInit = False
            Return False
        End If
    End Function

    Public Sub Box_Calculate()
        Dim _message As String = ""
        'очистка ЭУ
        If Me.Sample_lengthTextBox.Text = "" Then GoTo ex
        Dim _leight = Decimal.Parse(Me.Sample_lengthTextBox.Text) * 10
        If _leight = 0 Then _message = "длина" : GoTo ex

        If Me.Sample_widthTextBox.Text = "" Then GoTo ex
        Dim _width = Decimal.Parse(Me.Sample_widthTextBox.Text) * 10
        If _width = 0 Then _message = "ширина" : GoTo ex

        If Me.Sample_heightTextBox.Text = "" Then GoTo ex
        Dim _height = Decimal.Parse(Me.Sample_heightTextBox.Text) * 10
        If _height = 0 Then _message = "высота" : GoTo ex

        Dim _weight As Decimal = 0
        If Not Me.Sample_net_weightTextBox.Text = "" Then
            _weight = Decimal.Parse(Me.Sample_net_weightTextBox.Text)
        End If


        Dim _volumeoffset As Decimal = 10
        If Me.tbVolumeOffset.Text = "" Then
            Me.tbVolumeOffset.Text = _volumeoffset
        Else
            _volumeoffset = Decimal.Parse(Me.tbVolumeOffset.Text)
        End If

        '-----------------------------

        Me.tbFullSize.Text = _leight.ToString + "x" + _width.ToString + "x" + _height.ToString
        Me.tbVolume.Text = Math.Round(_leight * _width * _height / 1000000, 4)
        Me.tbVolumeWeight.Text = Math.Round(_weight / (_leight * _width * _height / 1000000000), 1)

        Dim _fbox = New Service.clsBoxes.FlavioBox
        _fbox.calculate(_leight + _volumeoffset, _width + _volumeoffset, _height + _volumeoffset)

        With _fbox
            Me.tbReikaThin.Text = .ReikaThin
            Me.tbFaneraThin.Text = .FaneraThin
            Me.tbSideA.Text = .SideA.Width.ToString + "x" + .SideA.Height.ToString
            Me.tbSideB.Text = .SideB.Width.ToString + "x" + .SideB.Height.ToString
            Me.tbCover.Text = .Cover.Width.ToString + "x" + .Cover.Height.ToString
            Me.tbReikaA.Text = .ReikaA
            Me.tbReikaB.Text = .ReikaB
            Me.tb_Fanera_qty.Text = .FaneraVolume
            Me.tbFanera_percent.Text = .FaneraPercent
            Me.tbReika_leight.Text = .ReikaLen
            Me.tb_weightBox.Text = .Weight
        End With

        'вычислим тип упаковки

        Dim _koeff = _leight / _width
        _leight = _leight / 10
        _height = _height / 10
        Dim _boxType As String
        Dim _plw As String = "(основание больше чем надо)"
        Select Case _leight
            '------k0-4
            Case Is <= 4.6
                Select Case _height
                    Case Is <= 4.6
                        _boxType = "k0-4"
                    Case 4.7 To 7.6
                        _boxType = "k1-4"
                        _boxType += "(основание больше чем надо)"
                    Case 7.7 To 9.6
                        _boxType = "k6-4"
                        _boxType += "(основание больше чем надо)"
                    Case 9.7 To 10.6
                        _boxType = "k7-4"
                        _boxType += "(основание больше чем надо)"
                    Case 10.7 To 12.8
                        _boxType = "k8-6"
                        _boxType += "(основание больше чем надо)"
                    Case 12.9 To 16.8
                        _boxType = "k9-6"
                        _boxType += "(основание больше чем надо)"
                    Case 16.9 To 21
                        _boxType = "k10-8"
                        _boxType += "(основание больше чем надо)"
                    Case Else
                        _boxType = "нет стандартной"
                End Select
            Case 4.7 To 5.5
                If _koeff >= 1.2 Then
                    'узкий камень
                    Select Case _height
                        Case Is <= 4.6
                            _boxType = "k0-4"
                        Case 4.7 To 7.6
                            _boxType = "k1-4"
                            _boxType += "(основание больше чем надо)"
                        Case 7.7 To 9.6
                            _boxType = "k6-4"
                            _boxType += "(основание больше чем надо)"
                        Case 9.7 To 10.6
                            _boxType = "k7-4"
                            _boxType += "(основание больше чем надо)"
                        Case 10.7 To 12.8
                            _boxType = "k8-6"
                            _boxType += "(основание больше чем надо)"
                        Case 12.9 To 16.8
                            _boxType = "k9-6"
                            _boxType += "(основание больше чем надо)"
                        Case 16.9 To 21
                            _boxType = "k10-8"
                            _boxType += "(основание больше чем надо)"
                        Case Else
                            _boxType = "нет стандартной"
                    End Select
                Else
                    'изометричный камень
                    Select Case _height
                        Case Is <= 4.6
                            _boxType = "k1-4"
                        Case 4.7 To 7.6
                            _boxType = "k1-4"
                        Case 7.7 To 9.6
                            _boxType = "k6-4"
                        Case 9.7 To 10.6
                            _boxType = "k7-4"
                            _boxType += "(основание больше чем надо)"
                        Case 10.7 To 12.8
                            _boxType = "k8-6"
                            _boxType += "(основание больше чем надо)"
                        Case 12.9 To 16.8
                            _boxType = "k9-6"
                            _boxType += "(основание больше чем надо)"
                        Case 16.9 To 21
                            _boxType = "k10-8"
                            _boxType += "(основание больше чем надо)"
                        Case Else
                            _boxType = "нет стандартной"
                    End Select
                End If
                '--k1-4 k6-4 ----------
            Case 5.6 To 7.6
                Select Case _height
                    Case Is <= 4.6
                        _boxType = "k1-4"
                    Case 4.7 To 7.6
                        _boxType = "k1-4"
                    Case 7.7 To 9.6
                        _boxType = "k6-4"
                    Case 9.7 To 10.6
                        _boxType = "k7-4"
                        _boxType += "(основание больше чем надо)"
                    Case 10.7 To 12.8
                        _boxType = "k8-6"
                        _boxType += "(основание больше чем надо)"
                    Case 12.9 To 16.8
                        _boxType = "k9-6"
                        _boxType += "(основание больше чем надо)"
                    Case 16.9 To 21
                        _boxType = "k10-8"
                        _boxType += "(основание больше чем надо)"
                    Case Else
                        _boxType = "нет стандартной"
                End Select
            Case 7.7 To 9.1
                If _koeff >= 1.2 Then
                    'узкий камень
                    Select Case _height
                        Case Is <= 4.6
                            _boxType = "k1-4"
                        Case 4.7 To 7.6
                            _boxType = "k1-4"
                        Case 7.7 To 9.6
                            _boxType = "k6-4"
                        Case 9.7 To 10.6
                            _boxType = "k7-4"
                            _boxType += "(основание больше чем надо)"
                        Case 10.7 To 12.8
                            _boxType = "k8-6"
                            _boxType += "(основание больше чем надо)"
                        Case 12.9 To 16.8
                            _boxType = "k9-6"
                            _boxType += "(основание больше чем надо)"
                        Case 16.9 To 21
                            _boxType = "k10-8"
                            _boxType += "(основание больше чем надо)"
                        Case Else
                            _boxType = "нет стандартной"
                    End Select
                Else
                    'изометричный камень
                    Select Case _height
                        Case Is <= 4.6
                            _boxType = "k2-4"
                        Case 4.7 To 7.6
                            _boxType = "k2-4"
                        Case 7.7 To 9.6
                            _boxType = "k7-4"
                        Case 9.7 To 10.6
                            _boxType = "k7-4"
                        Case 10.7 To 12.8
                            _boxType = "k8-6"
                            _boxType += "(основание больше чем надо)"
                        Case 12.9 To 16.8
                            _boxType = "k9-6"
                            _boxType += "(основание больше чем надо)"
                        Case 16.9 To 21
                            _boxType = "k10-8"
                            _boxType += "(основание больше чем надо)"
                        Case Else
                            _boxType = "нет стандартной"
                    End Select
                End If
                '---k2-4 k7-4------
            Case 9.2 To 12.6
                Select Case _height
                    Case Is <= 4.6
                        _boxType = "k2-4"
                    Case 4.7 To 7.6
                        _boxType = "k2-4"
                    Case 7.7 To 9.6
                        _boxType = "k7-4"
                    Case 9.7 To 10.6
                        _boxType = "k7-4"
                    Case 10.7 To 12.8
                        _boxType = "k8-6"
                        _boxType += "(основание больше чем надо)"
                    Case 12.9 To 16.8
                        _boxType = "k9-6"
                        _boxType += "(основание больше чем надо)"
                    Case 16.9 To 21
                        _boxType = "k10-8"
                        _boxType += "(основание больше чем надо)"
                    Case Else
                        _boxType = "нет стандартной"
                End Select
            Case 12.6 To 15.1
                If _koeff >= 1.2 Then
                    'узкий камень
                    Select Case _height
                        Case Is <= 4.6
                            _boxType = "k2-4"
                        Case 4.7 To 7.6
                            _boxType = "k2-4"
                        Case 7.7 To 9.6
                            _boxType = "k7-4"
                        Case 9.7 To 10.6
                            _boxType = "k7-4"
                        Case 10.7 To 12.8
                            _boxType = "k8-6"
                            _boxType += "(основание больше чем надо)"
                        Case 12.9 To 16.8
                            _boxType = "k9-6"
                            _boxType += "(основание больше чем надо)"
                        Case 16.9 To 21
                            _boxType = "k10-8"
                            _boxType += "(основание больше чем надо)"
                        Case Else
                            _boxType = "нет стандартной"
                    End Select
                Else
                    'изометричный камень
                    Select Case _height
                        Case Is <= 4.6
                            _boxType = "k3-6"
                        Case 4.7 To 7.8
                            _boxType = "k3-6"
                        Case 7.9 To 9.6
                            _boxType = "k8-6"
                        Case 9.7 To 10.6
                            _boxType = "k8-6"
                        Case 10.7 To 12.8
                            _boxType = "k8-6"
                        Case 12.9 To 16.8
                            _boxType = "k9-6"
                            _boxType += "(основание больше чем надо)"
                        Case 16.9 To 21
                            _boxType = "k10-8"
                            _boxType += "(основание больше чем надо)"
                        Case Else
                            _boxType = "нет стандартной"
                    End Select
                End If
                '---k3-6  k8-6-------------
            Case 15.2 To 16.8
                Select Case _height
                    Case Is <= 4.6
                        _boxType = "k3-6"
                    Case 4.7 To 7.8
                        _boxType = "k3-6"
                    Case 7.9 To 9.6
                        _boxType = "k8-6"
                    Case 9.7 To 10.6
                        _boxType = "k8-6"
                    Case 10.7 To 12.8
                        _boxType = "k8-6"
                    Case 12.9 To 16.8
                        _boxType = "k9-6"
                        _boxType += "(основание больше чем надо)"
                    Case 16.9 To 21
                        _boxType = "k10-8"
                        _boxType += "(основание больше чем надо)"
                    Case Else
                        _boxType = "нет стандартной"
                End Select
            Case 16.9 To 20.2
                If _koeff >= 1.2 Then
                    'узкий камень
                    Select Case _height
                        Case Is <= 4.6
                            _boxType = "k3-6"
                        Case 4.7 To 7.8
                            _boxType = "k3-6"
                        Case 7.9 To 9.6
                            _boxType = "k8-6"
                        Case 9.7 To 10.6
                            _boxType = "k8-6"
                        Case 10.7 To 12.8
                            _boxType = "k8-6"
                        Case 12.9 To 16.8
                            _boxType = "k9-6"
                            _boxType += "(основание больше чем надо)"
                        Case 16.9 To 21
                            _boxType = "k10-8"
                            _boxType += "(основание больше чем надо)"
                        Case Else
                            _boxType = "нет стандартной"
                    End Select
                Else
                    'изометричный камень
                    Select Case _height
                        Case Is <= 4.6
                            _boxType = "k4-6"
                        Case 4.7 To 7.8
                            _boxType = "k4-6"
                        Case 7.9 To 9.6
                            _boxType = "k9-6"
                        Case 9.7 To 10.6
                            _boxType = "k9-6"
                        Case 10.7 To 12.8
                            _boxType = "k9-6"
                        Case 12.9 To 16.8
                            _boxType = "k9-6"
                        Case 16.9 To 21
                            _boxType = "k10-8"
                            _boxType += "(основание больше чем надо)"
                        Case Else
                            _boxType = "нет стандартной"
                    End Select
                End If
                '---k4-6 k9-6------------
            Case 20.3 To 21.8
                Select Case _height
                    Case Is <= 4.6
                        _boxType = "k4-6"
                    Case 4.7 To 7.8
                        _boxType = "k4-6"
                    Case 7.9 To 9.6
                        _boxType = "k9-6"
                    Case 9.7 To 10.6
                        _boxType = "k9-6"
                    Case 10.7 To 12.8
                        _boxType = "k9-6"
                    Case 12.9 To 16.8
                        _boxType = "k9-6"
                    Case 16.9 To 21
                        _boxType = "k10-8"
                        _boxType += "(основание больше чем надо)"
                    Case Else
                        _boxType = "нет стандартной"
                End Select
            Case 21.9 To 26.2
                If _koeff >= 1.2 Then
                    'узкий камень
                    Select Case _height
                        Case Is <= 4.6
                            _boxType = "k4-6"
                        Case 4.7 To 7.8
                            _boxType = "k4-6"
                        Case 7.9 To 9.6
                            _boxType = "k9-6"
                        Case 9.7 To 10.6
                            _boxType = "k9-6"
                        Case 10.7 To 12.8
                            _boxType = "k9-6"
                        Case 12.9 To 16.8
                            _boxType = "k9-6"
                        Case 16.9 To 21
                            _boxType = "k10-8"
                            _boxType += "(основание больше чем надо)"
                        Case Else
                            _boxType = "нет стандартной"
                    End Select
                Else
                    'изометричный камень
                    Select Case _height
                        Case Is <= 8.0
                            _boxType = "k5-8"
                        Case 8.1 To 21
                            _boxType = "k10-8"
                        Case Else
                            _boxType = "нет стандартной"
                    End Select
                End If

                '---k5-8 k10-8----------------
            Case 26.3 To 28
                Select Case _height
                    Case Is <= 8
                        _boxType = "k5-8"
                    Case 8 To 21
                        _boxType = "k10-8"
                    Case Else
                        _boxType = "нет стандартной"
                End Select
            Case 28.1 To 33.6
                If _koeff >= 1.2 Then
                    'узкий камень
                    Select Case _height
                        Case Is <= 8
                            _boxType = "k5-8"
                        Case 8 To 21
                            _boxType = "k10-8"
                        Case Else
                            _boxType = "нет стандартной"
                    End Select
                Else
                    'изометричный камень
                    _boxType = "нет стандартной"
                End If
            Case Else
                _boxType = "нет стандартной"
        End Select
        'отобразим
        Me.lbPackageType.Text = _boxType
        'Me.lbPackageType2.Text = _boxType
        Return

ex:
        'Me.BindingSource_BOXES.DataSource = Nothing
        'Me.lbPackageType2.Text = ""
        Me.lbPackageType.Text = ""
        Me.tbFullSize.Text = "не задан размер " & _message
        Me.tbVolume.Text = ""
        Me.tbVolumeWeight.Text = ""
        Me.tbVolumeOffset.Text = "10"
        Me.tbReikaThin.Text = ""
        Me.tbFaneraThin.Text = ""
        Me.tbSideA.Text = ""
        Me.tbSideB.Text = ""
        Me.tbCover.Text = ""
        Me.tbReikaA.Text = ""
        Me.tbReikaB.Text = ""
        Me.tb_Fanera_qty.Text = ""
        Me.tbFanera_percent.Text = ""
        Me.tbReika_leight.Text = ""
        Me.tb_weightBox.Text = ""

    End Sub

    ''' <summary>
    ''' проверка описания
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ReadDescription()
        If oSampleNumber Is Nothing Then Exit Sub

        Me.oLabel = Nothing
        Me.oCurrentLabelDescription = Nothing
        Me.oLabelinfoToRecinDB.Clear()
        Me.cbxGetLabelInfoFromDB.Checked = False

        Dim _result1 As Boolean
        Dim _xml As String
        oSampleDataObj = clsApplicationTypes.SampleDataObject.GetSampleOnSale(oSampleNumber, _result1, True)
        If _result1 Then
            'описание общее
            oDescriptionFromBDFlag = True
            _xml = oSampleDataObj.Description
            Dim _status As Integer
            Dim _result = clsLabelBase.ParseTextToXElement(_xml, _status)
            If _status > 0 Then
                'описание есть
                Me.oCurrentXMLDescription = _result
                '-----------------
                'пробуем получить описание этикетки
                _xml = oSampleDataObj.SampleXMLDescription
                _result = clsLabelBase.ParseTextToXElement(_xml, _status)
                If _status > 0 Then
                    'описание этикетки есть
                    Me.oCurrentLabelDescription = _result
                Else
                    'описание этикетки нет
                    Me.oCurrentLabelDescription = Nothing
                    Me.ClsLabelInfoBindingSource.DataSource = Nothing
                    Me.cbxGetLabelInfoFromDB.Checked = True
                End If
                '---------------
                Me.btToSite.Enabled = True
            Else
                Me.oCurrentXMLDescription = Nothing
                Me.btToSite.Enabled = False
            End If

            'работа с ЭУ
            Me.oIndexlbElements = -1
            '-------????-------
            If rbRussian.Checked Then
                oCurrentCulture = Service.clsApplicationTypes.RussianCulture
            Else
                oCurrentCulture = Service.clsApplicationTypes.EnglishCulture
            End If
            '------------
        Else
            'oSampleDataObj = Nothing
            oDescriptionFromBDFlag = False
            oCurrentXMLDescription = Nothing
            oCurrentLabelDescription = Nothing
            Me.btToSite.Enabled = False
        End If

        '--------------------
        Me.BuildDescription(True)
    End Sub

    ''' <summary>
    ''' проверка фото
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ReadPhotos()
        'check photos
        If oSampleNumber Is Nothing Then Exit Sub
        'отображение главного фото образца
        Dim _img As Image = Service.clsApplicationTypes.SamplePhotoObject.GetMainImage(oCurrentSource, oSampleNumber, False)
        Dim _imgInSample = clsApplicationTypes.SamplePhotoObject.GetCountImages(oSampleNumber, oCurrentSource)
        If _imgInSample > 0 Then
            oCurrentHasImages = True
        Else
            oCurrentHasImages = False
        End If

        'отобразить главное фото
        If Not _img.Tag = "noimage" Then
            'ок - есть главное фото
            Try
                Dim _gr = Graphics.FromImage(_img)
                _gr.DrawString(_imgInSample, New System.Drawing.Font("Tahoma", 20, FontStyle.Regular), Brushes.Red, 10, 10)
                pbMainImage.Image = _img
            Catch ex As Exception
                pbMainImage.Image = _img
            End Try

            For Each _ctl As Control In Me.tpPhoto.Controls
                _ctl.Enabled = True
            Next
        Else
            'вернули фотку-заглушку, т.е. главного фото нет
            If _imgInSample > 0 Then
                'у образца есть фотки
                'сообщить о необходимости задать главное фото
                Dim _i = New Bitmap(216, 174)
                Dim _gr = Graphics.FromImage(_i)
                _gr.DrawString("Нет главного фото", New System.Drawing.Font("Arial", 16, FontStyle.Regular), Brushes.Black, 2, 10)
                _gr.DrawString("всего " & _imgInSample & " фото", New System.Drawing.Font("Arial", 16, FontStyle.Regular), Brushes.Black, 2, 30)
                _gr.DrawString("необходимо задать", New System.Drawing.Font("Arial", 16, FontStyle.Regular), Brushes.Black, 2, 50)
                pbMainImage.Image = _i
                For Each _ctl As Control In Me.tpPhoto.Controls
                    _ctl.Enabled = True
                Next
            Else
                'у образца нет фото вовсе
                pbMainImage.Image = clsApplicationTypes.NoImage
            End If
        End If

        oImageLoaded = False
        pbMainImage.Refresh()
    End Sub


    ''' <summary>
    ''' обработает запрос номера вкладки
    ''' </summary>
    ''' <param name="reccomended"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetNumberOfFossil(reccomended As Integer) As String
        'TODO запросить при нумерации большей, чем вкладок фоссилий новую вкладку
        Dim _layerText As String = reccomended.ToString
        If reccomended > Me.UcFossilTabPage1.FossilCount Then
            Select Case MsgBox("Создать вкладку для обьекта?", vbYesNo)
                Case MsgBoxResult.Yes
                    _layerText = (Me.UcFossilTabPage1.FossilCount + 1).ToString
                    Me.AddNewFossil(_layerText, "нет")
                Case MsgBoxResult.No
                    _layerText = Me.UcFossilTabPage1.FossilSelectedNumber
            End Select
        Else
            'добавить с номером по выбранной вкладке
            _layerText = Me.UcFossilTabPage1.FossilSelectedNumber
        End If
        Return _layerText
    End Function


    Private Function LockCtl(control As Control) As Boolean
        Dim _flag As Boolean = False
        For Each _tmpctl As Control In control.Controls
            _tmpctl.Enabled = False

            If TypeOf _tmpctl Is Windows.Forms.TextBox Or TypeOf _tmpctl Is Windows.Forms.RichTextBox Then
                _tmpctl.Text = ""
            End If
            If TypeOf _tmpctl Is Windows.Forms.ComboBox Then
                CType(_tmpctl, Windows.Forms.ComboBox).SelectedIndex = -1
            End If

            If _tmpctl.Controls.Count > 0 Then
                _flag = True
            End If
        Next
        Return _flag
    End Function

    Private Sub LockedAll()
        LockCtl(Me)
        Me.SampleNumberTextBox.Enabled = True
        Me.btSearchInfo.Enabled = True
        Me.btReadRFID.Enabled = True
        Me.btGetNumber.Enabled = True
        SampleNumberLabel.Enabled = True

        Me.tpctlMain.Enabled = True
        Me.tpctlMain.TabPages.Clear()
        Me.tpctlMain.TabPages.Add(Me.tpndescription)
        Me.gbDBLabel.Enabled = False

        Me.pbMainImage.Image = Nothing
        Me.UcGoodLabel1.Clear()
        Me.UserDescriptionRichTextBox.Text = ""
        Me.oSampleDataObj = Nothing
        Me.lbElements.DataSource = Nothing
        Me.DescriptionRichTextBox.Text = ""
        Me.rtbLabel.Text = ""

        btDescriptionForm.Enabled = True
    End Sub
    ''' <summary>
    ''' проверка доступа
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub UnlockedAll()
        For Each _tmpctl As Control In Me.Controls
            If _tmpctl.Name = Me.btToSite.Name Then GoTo ex

            _tmpctl.Enabled = True
ex:

        Next

        Me.tpctlMain.TabPages.Clear()
        Me.SampleNumberTextBox.Text = oSampleNumber.ShotCode
        'добавление вкладок
        Me.tpctlMain.Controls.Add(Me.tpndescription)
        Me.tpctlMain.TabPages.Add(Me.tpPhoto)
        Me.tpctlMain.TabPages.Add(Me.tpOldDescription)
        Me.tpctlMain.TabPages.Add(Me.tpPakage)
        Me.tpctlMain.TabPages.Add(Me.tpMoySklad)

        Me.UserControlMC1.SampleNumber = oSampleNumber

        If clsApplicationTypes.GetAccess("Доступ к заказам") Then
            Me.tpctlMain.TabPages.Add(Me.tpTrilboneInfo)
            Me.Uc_trilbone_history1.SampleNumber(False) = Me.oSampleNumber.EAN13
        End If

        Me.tpctlMain.TabPages.Add(Me.tpRFID)
        Me.UC_rfid1.SampleNumber = oSampleNumber.ShotCode

        Me.gbDBLabel.Enabled = True
    End Sub
    ''' <summary>
    ''' создает вкладки с фоссилиями
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CreateFossilPages()
        Me.UcFossilTabPage1.Clear()

        Dim _row As Data.DataRowView
        Dim _childRow As Data.DataRow()

        _row = CType(Me.Select_tb_Samples_photo_dataBindingSource.Current, Data.DataRowView)

        If Not _row Is Nothing Then
            _childRow = _row.Row.GetChildRows(DsPhotoData.Relations("Select_tb_Samples_photo_data_Select_tb_Samples_Fossils"))

            'инициал страниц
            Me.UcFossilTabPage1.LoadData(_childRow)
            ' Me.Fossil_countTextBox.Text = Me.UcFossilTabPage1.TabCount.ToString

            'загрузка списка фоссилий
            Me.UcFossilTabPage1.FossilNamesSource = (From c In Me.Sample_main_speciesComboBox.Items.Cast(Of String)() Select c).ToArray
            'Me.UcFossilTabPage1.FossilNamesSource = _list
            Me.oTabCreated = True
            ' ReadFossilIDList()
        End If
    End Sub

    Private Sub btAddFossil_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btAddFossil.Click

        Dim _countFoss = Me.DsPhotoData.Select_tb_Samples_Fossils.Count + 1
        If clsApplicationTypes.GetAccess("Установка номера фоссилии") Then
            Dim _result = InputBox("Номер фоссилии:", "Добавить фоссилию", _countFoss)

            If Not _result.Length = 0 Then
                Dim _code = Global.Service.clsApplicationTypes.clsSampleNumber.CreateFromString(_result)
                If Not _code Is Nothing AndAlso _code.CodeIsCorrect Then
                    Me.AddNewFossil(_code.EAN13, "")
                Else
                    Dim _number As Decimal = New System.Nullable(Of Decimal)(CType(_result, Decimal))
                    Me.AddNewFossil(_number, "")
                End If
            End If
        Else
            Select Case MsgBox("Добавить обьект номер " & _countFoss & " ?", vbYesNo + vbQuestion, "Добавление вкладки обьекта")
                Case MsgBoxResult.Yes
                    Me.AddNewFossil(_countFoss, "")
            End Select
        End If

    End Sub

    Private Sub AddNewFossil(ByVal FossilNumber As Decimal, ByVal FossilFullName As String, Optional leight As Decimal = 0, Optional width As Decimal = 0, Optional height As Decimal = 0)
        Dim _parentRow As dsPhotoData.Select_tb_Samples_photo_dataRow =
          CType(Me.Select_tb_Samples_photo_dataBindingSource.Current, Data.DataRowView).Row

        Me.DsPhotoData.Select_tb_Samples_Fossils.AddSelect_tb_Samples_FossilsRow _
           (_parentRow, FossilFullName, _parentRow.Version, leight, width, height, FossilNumber)

        Me.CreateFossilPages()
    End Sub

    Sub Sample_heightTextBox_Enter(sender As Object, e As System.EventArgs) Handles Sample_heightTextBox.Enter, Sample_net_weightTextBox.Enter, Sample_lengthTextBox.Enter, Sample_widthTextBox.Enter
        Dim _result As Decimal
        If Decimal.TryParse(sender.text, _result) Then
            If _result = 0 Then
                sender.text = ""
            End If
        End If

    End Sub



    Private Sub Sample_heightTextBox_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles Sample_net_weightTextBox.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Sample_lengthTextBox.Focus()
        End If
    End Sub
    Private Sub Sample_heightTextBox_KeyPress1(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles Sample_heightTextBox.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Sample_main_speciesComboBox.Focus()
        End If
    End Sub
    Private Sub Sample_heightTextBox_KeyPress2(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles Sample_lengthTextBox.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Sample_widthTextBox.Focus()
        End If
    End Sub
    Private Sub Sample_heightTextBox_KeyPress3(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles Sample_widthTextBox.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Sample_heightTextBox.Focus()
        End If
    End Sub


    ''' <summary>
    ''' замена . на ,
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Sample_digit_TextBox_Validating(ByVal sender As Object, _
           ByVal e As System.ComponentModel.CancelEventArgs) Handles _
       Sample_net_weightTextBox.Validating, Sample_heightTextBox.Validating, _
       Sample_lengthTextBox.Validating, Sample_widthTextBox.Validating, tbVolumeOffset.Validating

        Dim _control As Control = CType(sender, Windows.Forms.Control)

        'если путсто - то 0
        If _control.Text = "" Then _control.Text = "0" : Return
        If _control.Text = " " Then _control.Text = "0" : Return
        '--------------
        _control.Text = Service.clsApplicationTypes.ReplaceDecimalSplitter(_control.Text)


        If sender Is Me.Sample_net_weightTextBox Then
            'замена гр на кг
            Dim _result As Decimal
            If Decimal.TryParse(_control.Text, _result) Then
                'проверить, есть ли точка
                For Each s In _control.Text
                    If Char.IsPunctuation(s) Then
                        'есть точка, выход
                        GoTo ex
                    End If
                Next
                'точки нет
                _result = _result / 1000
                _control.Text = _result.ToString
            End If
        End If

ex:
        If clsApplicationTypes.ReplaceDecimalSplitter(_control) > 100 Then
            Select Case MsgBox(String.Format("Значение {0} подозрительно велико, исправить?", _control.Text), vbYesNo)
                Case MsgBoxResult.Yes
                    CType(_control, Windows.Forms.TextBoxBase).SelectAll()
                    _control.Focus()
            End Select
        End If



    End Sub

    Private Sub Sample_main_speciesComboBox_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles Sample_main_speciesComboBox.KeyPress
        Select Case Char.IsControl(e.KeyChar)
            Case True
                If Asc(e.KeyChar) = 13 Then
                    Me.NameAccepting(Sample_main_speciesComboBox.Text)
                    Me.CreateFossilTab(Sample_main_speciesComboBox.Text, 1)
                End If
        End Select
    End Sub
    ''' <summary>
    ''' после ввода имени
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub NameAccepting(FullName As String)
        If FullName = "" Then Exit Sub

        Me.Sample_nicknameTextBox.Text = clsApplicationTypes.RejectSkobki(FullName).Split(" ").FirstOrDefault
        Me.Woker_full_nameComboBox.Focus()
        If Me.Woker_full_nameComboBox.SelectedIndex = -1 AndAlso Me.Woker_full_nameComboBox.Items.Count >= 1 Then
            Me.Woker_full_nameComboBox.SelectedIndex = 0
        End If
        'выбрать работника в зависимости от пользователя
        'If Me.Woker_full_nameComboBox.SelectedIndex = -1 AndAlso Me.Woker_full_nameComboBox.Items.Count > 1 Then
        '    Select Case clsApplicationTypes.ActiveUser
        '        Case clsApplicationTypes.emUsers.Admin
        '            Me.Woker_full_nameComboBox.SelectedIndex = 2
        '            Me.Woker_full_nameComboBox.BackColor = Color.Red
        '        Case emUsers.NarvaWoker
        '            Me.Woker_full_nameComboBox.SelectedIndex = 1
        '            Me.Woker_full_nameComboBox.BackColor = Color.Red
        '        Case emUsers.PetrogradkaWoker
        '            Me.Woker_full_nameComboBox.SelectedIndex = 0
        '            Me.Woker_full_nameComboBox.BackColor = Color.Red
        '    End Select

        'End If
    End Sub

    ''' <summary>
    ''' создать вкладку с фоссилой
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CreateFossilTab(FullName As String, FossilNumber As Decimal)
        If FullName = "" Then Exit Sub
        FullName = FullName.Replace("'", " ")
        '
        'проверить, есть ли така фоссилия
        If Me.DsPhotoData.Select_tb_Samples_Fossils.Select(String.Format("Fossil_full_name='{0}'", FullName)).Length = 0 Then
            'проверить наличие фоссилий
            Dim _row As Data.DataRowView
            Dim _childRow As Data.DataRow()

            _row = CType(Me.Select_tb_Samples_photo_dataBindingSource.Current, Data.DataRowView)

            If Not _row Is Nothing Then
                _childRow = _row.Row.GetChildRows(DsPhotoData.Relations("Select_tb_Samples_photo_data_Select_tb_Samples_Fossils"))
                If _childRow.Length = 0 Then
                    'фоссилий нет - добавить фоссилию с таким же названием
                    Me.AddNewFossil(FossilNumber, FullName)
                End If
            End If
        Else
            'така фосиля есть уже
        End If


    End Sub


    Private oTabCreated As Boolean

    ''' <summary>
    ''' создание объекта с основным названием
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Sample_main_speciesComboBox_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Sample_main_speciesComboBox.LostFocus

        If Sample_main_speciesComboBox.Text = "" Then Return

        If Not oTabCreated Then
            'название
            Me.CreateFossilTab(Sample_main_speciesComboBox.Text, 1)
        End If

        'меняем первую вкладку
        ' Me.UcFossilTabPage1.SetFossilNameInFirstTab = Sample_main_speciesComboBox.Text
        'название
        Me.NameAccepting(Sample_main_speciesComboBox.Text)
    End Sub


    ''' <summary>
    ''' удаление нуля
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Sample_DataTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles Sample_net_weightTextBox.GotFocus, Sample_heightTextBox.GotFocus, Sample_lengthTextBox.GotFocus, _
        Sample_widthTextBox.GotFocus
        Dim _control As Control = CType(sender, Control)
        _control.BackColor = Color.Red

        If _control.Text = "" Then Exit Sub
        Dim _result As Decimal
        If Decimal.TryParse(_control.Text, _result) = False Then
            _control.Text = ""
        End If

    End Sub
    Private Sub Sample_main_speciesComboBox_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles Sample_main_speciesComboBox.SelectedIndexChanged
        If Sample_main_speciesComboBox.Text = "" Then Return
        If Not oTabCreated Then
            'название
            Me.CreateFossilTab(Sample_main_speciesComboBox.Text, 1)
        End If
        'меняем первую вкладку
        Me.UcFossilTabPage1.SetFossilNameInFirstTab = Sample_main_speciesComboBox.Text
        'название
        Me.NameAccepting(Sample_main_speciesComboBox.Text)
    End Sub


    Private Sub cbMaterial_DropDownClosed(sender As Object, e As System.EventArgs) Handles cbMaterial.DropDownClosed
        If Me.cbMaterial.SelectedItem = Nothing Then Return
        Dim _list As String()
        Dim _name As String = Me.cbMaterial.SelectedItem
        Me.Sample_main_speciesComboBox.Items.Clear()
        'проверка буфера
        If clsApplicationTypes.CurrentNamesList.ContainsKey(_name) Then
            'загрузить из буфера
            _list = clsApplicationTypes.CurrentNamesList.Item(_name)
        Else
            _list = {""}
        End If
        'загрузка списка
        With Me.Sample_main_speciesComboBox
            Me.Sample_main_speciesComboBox.Items.AddRange(_list)
            .AutoCompleteMode = AutoCompleteMode.SuggestAppend
            .AutoCompleteSource = AutoCompleteSource.ListItems
        End With
        Me.UcFossilTabPage1.FossilNamesSource = _list
        Me.lbTreeName.Text = Trilbone.clsTreeService.CurrentGroupName
    End Sub



    Private Sub cbMaterial_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbMaterial.SelectedIndexChanged
        If Me.cbMaterial.SelectedItem Is Nothing Then Return
        Dim _list As String()
        Dim _name As String = Me.cbMaterial.SelectedItem
        Me.Sample_main_speciesComboBox.Items.Clear()

        'проверка буфера
        If clsApplicationTypes.CurrentNamesList.ContainsKey(_name) Then
            'загрузить из буфера
            _list = clsApplicationTypes.CurrentNamesList.Item(_name)
        Else
            _list = {""}
        End If

        'загрузка списка
        With Me.Sample_main_speciesComboBox
            Me.Sample_main_speciesComboBox.Items.AddRange(_list)
            .AutoCompleteMode = AutoCompleteMode.SuggestAppend
            .AutoCompleteSource = AutoCompleteSource.ListItems
        End With
        Me.UcFossilTabPage1.FossilNamesSource = _list
        Me.lbTreeName.Text = Trilbone.clsTreeService.CurrentGroupName
        '  Me.lbTreeName.Tag = Trilbone.clsTreeService.CurrentFilePath

    End Sub







    ''' <summary>
    ''' загружает названия в Sample_main_speciesComboBox. В cbMaterial заносится название дерева.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btLoadTree_Click(sender As System.Object, e As System.EventArgs) Handles btLoadTree.Click

        Me.cbxLoadAllNames.Checked = False

        Dim _sp As New SplashScreen1
        _sp.Show()

        Application.DoEvents()

        ' загружает названия в Sample_main_speciesComboBox. В cbMaterial заносится название дерева.
        'использование сервисов
        'выполняем вызов из сервиса
        Dim _param As Object = Nothing
        'если делегата нет, то сервис недоступен
        If Not Global.Service.clsApplicationTypes.DelegateStoreApplicationForm(emFormsList.fmDescriptionTreeBuilder) Is Nothing Then
            'сервис зарегестрирован - вызываем 
            Dim _fm = Global.Service.clsApplicationTypes.DelegateStoreApplicationForm(emFormsList.fmDescriptionTreeBuilder).Invoke(_param)

            If _fm Is Nothing Then Return
            ' Dim _fm = Trilbone.clsTreeService.TreeManager.GetformDescriptionBuilder
            _fm.StartPosition = FormStartPosition.CenterScreen
            _fm.ShowDialog()
            _sp.Hide()
        Else
            Return
        End If

        Dim _result As String() = Nothing ' = Trilbone.clsTreeService.TreeManager.GetTreesListFromFile
        'использование сервисов
        'выполняем вызов из сервиса
        ' dim _param as object={[parameters_list]}
        _param = Nothing
        'если делегата нет, то сервис недоступен
        If Not Global.Service.clsApplicationTypes.DelegateStoreGetTreesListFromFile Is Nothing Then
            'сервис зарегестрирован - вызываем 
            _result = Global.Service.clsApplicationTypes.DelegateStoreGetTreesListFromFile.Invoke(_param)
        Else
            ' Return Nothing
        End If



        If _result Is Nothing Then
            'With Me.cbListOfTree
            '    .Items.Clear()
            '    .Visible = False
            'End With
            BeepNOT()
            Return
        End If
        _sp.Hide()
        Application.DoEvents()

        'записать список деревьев. выбрать начинающееся с "Sy"
        With Me.cbListOfTree
            .Visible = True
            .Items.Clear()
            Dim _filter = (From c As String In _result Where c.StartsWith("Sy", StringComparison.OrdinalIgnoreCase) Select c).ToList
            If Not _filter Is Nothing AndAlso _filter.Count > 0 Then
                For Each c In _filter
                    .Items.Add(c)
                    Dim _old = Me.cbListOfTree.SelectedItem
                    If c = _old Then
                        cbListOfTree_SelectedIndexChanged(sender, e)
                    Else
                        Me.cbListOfTree.SelectedItem = c
                    End If
                Next
                Me.lbTreeName.Text = Trilbone.clsTreeService.CurrentGroupName
            Else
                'если таких нет, то записать все деревья в список
                .Items.AddRange(_result)
            End If
            .SelectedIndex = 0
        End With

        Application.DoEvents()

    End Sub
    ''' <summary>
    ''' загрузка списка имен из описания
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cbListOfTree_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbListOfTree.SelectedIndexChanged
        If cbListOfTree.SelectedItem Is Nothing Then Exit Sub
        'загрузим список из выбранного дерева
        Dim _name = Me.cbListOfTree.SelectedItem.ToString
        Dim _treeFileName As String = Trilbone.clsTreeService.CurrentGroupName
        Dim _KeyName = IO.Path.GetFileNameWithoutExtension(_treeFileName) & "_" & _name

        If clsApplicationTypes.CurrentNamesList.ContainsKey(_KeyName) Then
            'заменить названия
            clsApplicationTypes.CurrentNamesList.Remove(_KeyName)
            Me.cbMaterial.Items.Remove(_KeyName)
        End If


        Dim _result As String() = Nothing
        'использование сервисов
        'выполняем вызов из сервиса
        ' dim _param as object={[parameters_list]}
        'если делегата нет, то сервис недоступен
        If Not Global.Service.clsApplicationTypes.DelegateStoreGetTreeLeafNodeNames Is Nothing Then
            'сервис зарегестрирован - вызываем 
            _result = Global.Service.clsApplicationTypes.DelegateStoreGetTreeLeafNodeNames.Invoke(_treeFileName, _name, oCurrentCulture)
        Else
            'Return Nothing
        End If

        'загрузить имена в лист
        Me.Sample_main_speciesComboBox.Items.Clear()
        If Not _result Is Nothing Then
            If (Not clsApplicationTypes.CurrentNamesList.ContainsKey(_KeyName)) Then
                'занести в буфер и в список материала
                clsApplicationTypes.CurrentNamesList.Add(_KeyName, _result)
            End If

            If Not cbMaterial.Items.Contains(_KeyName) Then
                'записать имя дерева в список материала
                Me.cbMaterial.Items.Add(_KeyName)
                Me.cbMaterial.SelectedItem = _KeyName
            End If

        End If

    End Sub

    Private Sub btPhotoManager_Click(sender As System.Object, e As System.EventArgs)
        'Dim _param As Object = {Me.oSampleNumber.GetEan13}
        'Dim _form = Service.clsApplicationTypes.DelegateStoreApplicationForm(clsApplicationTypes.emFormsList.fmImageManager).Invoke(_param)
        'If Not _form Is Nothing Then
        '    _form.StartPosition = FormStartPosition.CenterParent
        '    _form.ShowDialog(Me.Parent)
        '    'Dim _sample = clsApplicationTypes.clsSampleNumber.CreateFromString(oSampleNumber.ToString)
        '    If oSampleNumber Is Nothing Then Exit Sub
        '    'check photos
        '    ReadPhotos()
        'End If
    End Sub
    Dim oRegisterFlag As Boolean

    ''' <summary>
    ''' создает устройство для записи файлов.Запоминает последнюю выбранную папку
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CreateFreeFolderSource() As clsFilesSources
        'выбрать папку для сохранения
        Static _pathTo As String
        'Dim _ToSource As clsFilesSources
        Dim _fd As New Windows.Forms.FolderBrowserDialog
        With _fd
            If _pathTo = "" Then
                If My.Settings.FreeFolderPath = "" Then
                    .RootFolder = Environment.SpecialFolder.MyComputer
                ElseIf Not IO.Directory.Exists(My.Settings.FreeFolderPath) Then
                    .RootFolder = Environment.SpecialFolder.MyComputer
                Else
                    .SelectedPath = My.Settings.FreeFolderPath
                End If
            Else
                .SelectedPath = _pathTo
            End If
            .Description = "Укажите путь, куда копировать инфо. Папка с номером будет создана."
            .ShowNewFolderButton = True
        End With
        Select Case _fd.ShowDialog(Me)
            Case Windows.Forms.DialogResult.OK
                _pathTo = _fd.SelectedPath
                If Not _pathTo = My.Settings.FreeFolderPath Then
                    My.Settings.FreeFolderPath = _pathTo
                    My.Settings.Save()
                End If

                'проверить наличие старой папки
                If IO.Directory.Exists(IO.Path.Combine(_pathTo, oSampleNumber.ShotCode)) Then
                    'удалить старую
                    IO.Directory.Delete(IO.Path.Combine(_pathTo, oSampleNumber.ShotCode), True)
                End If

            Case Windows.Forms.DialogResult.Cancel
                Return Nothing
            Case Else
                Return Nothing
        End Select

        Dim _numberedfolder = IO.Path.Combine(_pathTo, Me.oSampleNumber.ShotCode)

        Return clsFilesSources.CreateInstance(clsFilesSources.emSources.FreeFolder, , , _numberedfolder, True)
    End Function




    ''' <summary>
    ''' вызов формы eBay и передача двух параметров
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btInList_Click(sender As Object, e As EventArgs) Handles btToSite.Click
        '------
        'сохранить
        Me.Validate()
        SaveToDB(False)

        '----------------------
        'Полное XML описание образца (текущее)
        Dim _paramXMLelements As String = ""
        'лабел -описание
        Dim _paramXMLLabel As String = ""
        'XML карта для преобразований
        Dim _paramXMLFile(1) As String

        Dim _flagXMLFromDb As Boolean = False
        Dim _result As Integer = -1
        '--------------------
        '===========================
        'ДАННЫЕ
        'записать в параметры лабел инфо
        If Not oLabel Is Nothing Then
            _paramXMLLabel = oLabel.GetXElements.ToString()
        End If
        'записать текущее описание
        If Not oCurrentXMLDescription Is Nothing Then
            _paramXMLelements = oCurrentXMLDescription.ToString
        End If

        Dim _number = oSampleNumber.GetEan13
        clsApplicationTypes.SampleDataObject.GetdbPhotoObjectContext.Refresh(Objects.RefreshMode.ClientWins, clsApplicationTypes.SampleDataObject.GetdbPhotoObjectContext.tb_Samples_Fossils.Where(Function(x) x.ID_Sample_number = _number))
        clsApplicationTypes.SampleDataObject.GetdbPhotoObjectContext.Refresh(Objects.RefreshMode.ClientWins, clsApplicationTypes.SampleDataObject.GetdbPhotoObjectContext.tb_Samples_photo_data.Where(Function(x) x.SampleNumber = _number))

        Dim _sdo = clsApplicationTypes.SampleDataObject.GetSampleOnSale(oSampleNumber, _result, CreateIfNotExist:=True)

        '-----требуют взять карту XML из БД и она есть-----------------
        If Me.cbxGetXMLFromDB.Checked Then
            If _result < 1 OrElse _sdo Is Nothing Then
                MsgBox("Невозможно извлечь карту образца из БД. Неудачная попытка запросить обьект с сервера.", vbCritical)
                Return
            End If
            If Not String.IsNullOrEmpty(_sdo.SampleXMLFile) Then
                'в БД есть сохраненная карта XML
                _paramXMLFile(1) = _sdo.SampleXMLFile
                _paramXMLFile(0) = _sdo.SampleXMLFileRU
                _flagXMLFromDb = True
            End If

      
        End If
        '=============================
        'карта будет сгенерирована = передать путь к файлу
        If Not _flagXMLFromDb Then
            ''создать устройство назначения (папку), куда пишем все файлы
            Dim _LinkedSource = Me.CreateFreeFolderSource
            If _LinkedSource Is Nothing Then Return
          
            'Путь к папке
            _paramXMLFile(0) = _LinkedSource.ContainerPath
            _paramXMLFile(1) = _LinkedSource.ContainerPath
            '' получить коллекцию имен ВСЕХ изображений из Архива
            Dim _imgList = clsApplicationTypes.SamplePhotoObject.GetImageNamesList(Me.oSampleNumber, clsFilesSources.Arhive).ToList
            ''добавим в папку фотки
            If _imgList.Count > 0 Then
                clsApplicationTypes.CreateFolderForSampleWithImages(Me.oSampleNumber, _LinkedSource, _imgList)
            End If
        End If
        '============================
        'покажем форму и передадим: _paramXMLFile=карта XML /  _paramXMLelements=полное Описание XML / _paramXMLLabel=xml из labelinfo
        'если первый пуст, то надо генерировать xml карту
        Dim _fm As Object = clsApplicationTypes.DelegateStoreApplicationForm(clsApplicationTypes.emFormsList.fmCatalogSample).Invoke({_paramXMLFile, _paramXMLelements, _paramXMLLabel, oSampleNumber})

        If _fm Is Nothing Then
            MsgBox("Не удалось передать форме Каталог параметр.", vbCritical)
            Return
        End If
        'делегат сохранения карты образца в БД
        Dim _fnsave = Function(xmldoc() As XDocument) As Boolean
                          '{ru,en}
                          If xmldoc Is Nothing Then Return False
                          If xmldoc.Count = 0 Then Return False
                          If String.IsNullOrWhiteSpace(xmldoc(0).ToString) Then Return False

                          '
                          If _flagXMLFromDb Then
                              'перезаписать файл в БД
                              Select Case MsgBox("В БД уже есть карта образца, перезаписать на отредактированную?", vbYesNo)
                                  Case MsgBoxResult.No
                                      Return False
                              End Select
                          End If

                          'запись карты
                          Select Case xmldoc.Length
                              Case 1
                                  'исключительный случай
                                  _sdo.SampleXMLFile = xmldoc(0).ToString
                                  MsgBox("Вместо двух ru,en карт образца передана только одна. Она будет записана как en карта образца.", vbInformation)
                              Case 2
                                  'ru
                                  _sdo.SampleXMLFileRU = xmldoc(0).ToString
                                  'en
                                  _sdo.SampleXMLFile = xmldoc(1).ToString
                          End Select

                          If clsApplicationTypes.SampleDataObject.SaveReadySampleContext() > 0 Then
                              Me.btShowMap.BackColor = Color.Green
                              BeepYES()
                              Return True
                          Else
                              MsgBox("Невозможно сохранить карту образца в БД. Неудачная попытка вернуть обьект серверу.", vbCritical)
                              Return False
                          End If
                      End Function
        'так надо!
        Dim _delg As Func(Of XDocument(), Boolean) = _fnsave
        _fm.SaveDelegate = _delg
        '------------
        _fm.StartPosition = FormStartPosition.CenterScreen
        _fm.Show()
    End Sub
    Private Function SaveMap(xmldoc() As XDocument) As Boolean
        Return False
    End Function

    ''' <summary>
    ''' подгружает номер
    ''' </summary>
    ''' <param name="SampleNumber"></param>
    ''' <remarks></remarks>
    Public Sub ExternalLoadSample(SampleNumber As String)
        SampleNumberTextBox.Text = SampleNumber
        btSearchInfo_Click(Me, EventArgs.Empty)
    End Sub


    Private Sub btSearchInfo_Click(sender As System.Object, e As System.EventArgs) Handles btSearchInfo.Click
        Me.oTabCreated = False
        oSampleNumber = Nothing
        Dim _code = Global.Service.clsApplicationTypes.clsSampleNumber.CreateFromString(SampleNumberTextBox.Text)
        If Not _code Is Nothing AndAlso _code.CodeIsCorrect Then
            oSampleNumber = _code
        End If

        If oSampleNumber Is Nothing OrElse Not oSampleNumber.CodeIsCorrect Then
            Me.lbSampleStatus.Text = "Номер ?"
            Me.LockedAll()
            clsApplicationTypes.BeepNOT()
            Exit Sub
        End If

        Me.LoadSample()

    End Sub

    Private Sub TextBox_TextChanged_LostFocus(sender As System.Object, e As System.EventArgs) Handles Sample_net_weightTextBox.TextChanged, Sample_heightTextBox.TextChanged, Sample_lengthTextBox.TextChanged, Sample_widthTextBox.TextChanged, Sample_net_weightTextBox.LostFocus, Sample_heightTextBox.LostFocus, Sample_lengthTextBox.LostFocus, Sample_widthTextBox.LostFocus
        CType(sender, Control).BackColor = Color.White
    End Sub

    Private Sub SampleDataChanged_HandlesDataElement(sender As System.Object, e As System.EventArgs) Handles Sample_net_weightTextBox.TextChanged, Sample_heightTextBox.TextChanged, Sample_lengthTextBox.TextChanged, Sample_widthTextBox.TextChanged, Sample_main_speciesComboBox.TextChanged, Sample_main_speciesComboBox.SelectedIndexChanged
        Me.lbSampleStatus.BackColor = Color.Red
    End Sub


    Private Sub Woker_full_nameComboBox_Enter(sender As Object, e As System.EventArgs) Handles Woker_full_nameComboBox.Enter
        Me.Woker_full_nameComboBox.BackColor = Color.White
    End Sub

    Private Sub Woker_full_nameComboBox_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles Woker_full_nameComboBox.SelectedIndexChanged, Woker_full_nameComboBox.LostFocus
        Me.Woker_full_nameComboBox.BackColor = Color.White
    End Sub

#Region "description"

    ''' <summary>
    ''' передать в деревья инфо о описании
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btGetDescriptionBuilder_Click(sender As Object, e As EventArgs) Handles btGetDescriptionBuilder.Click
        Dim _fm As Windows.Forms.Form = Nothing
        If Me.lbElements.Items.Count = 0 Then
            'описания еще нет - ориентируемся на название объекта
            Dim _list = Me.UcFossilTabPage1.GetFossilsList(0)
            Dim _name As String = Me.Sample_main_speciesComboBox.Text
            If _list.Count > 0 Then
                _name = _list(0)
            End If


            'использование сервисов
            'выполняем вызов из сервиса
            Dim _param1 As Object = _name
            'если делегата нет, то сервис недоступен
            If Not Global.Service.clsApplicationTypes.DelegateStoreApplicationForm(emFormsList.fmDescriptionTreeBuilder) Is Nothing Then
                'сервис зарегестрирован - вызываем 
                _fm = Global.Service.clsApplicationTypes.DelegateStoreApplicationForm(emFormsList.fmDescriptionTreeBuilder).Invoke(_param1)

                If _fm Is Nothing Then Return
                ' Dim _fm = Trilbone.clsTreeService.TreeManager.GetformDescriptionBuilder
                '_fm.StartPosition = FormStartPosition.CenterScreen
                '_fm.Show()
                ' _sp.Hide()
            Else
                Return
            End If

            ' _fm = Trilbone.clsTreeService.TreeManager.GetformDescriptionBuilder(_name)
            GoTo ex

        ElseIf Me.lbElements.SelectedItem Is Nothing Then
            Me.lbElements.SelectedIndex = 0
        End If

        'в описателе выбран элемент
        Dim _elem = CType(Me.lbElements.SelectedItem, Trilbone.clsTreeService.clsDescriptionElement)
        'использование сервисов
        'выполняем вызов из сервиса
        Dim _param As Object = _elem
        'если делегата нет, то сервис недоступен
        If Not Global.Service.clsApplicationTypes.DelegateStoreApplicationForm(emFormsList.fmDescriptionTreeBuilder) Is Nothing Then
            'сервис зарегестрирован - вызываем 
            _fm = Global.Service.clsApplicationTypes.DelegateStoreApplicationForm(emFormsList.fmDescriptionTreeBuilder).Invoke(_param)

            If _fm Is Nothing Then Return
            ' Dim _fm = Trilbone.clsTreeService.TreeManager.GetformDescriptionBuilder
            '_fm.StartPosition = FormStartPosition.CenterScreen
            '_fm.Show()
            ' _sp.Hide()
        Else
            Return
        End If
        ' _fm = Trilbone.clsTreeService.TreeManager.GetformDescriptionBuilder(_elem)

ex:

        If Not _fm Is Nothing Then
            If oDg = False Then
                RemoveHandler Trilbone.clsTreeService.DescriptionAccepted, AddressOf Me.DescriptionChanged_EventHandler
                AddHandler Trilbone.clsTreeService.DescriptionAccepted, AddressOf Me.DescriptionChanged_EventHandler
                oDg = True
            End If


            _fm.StartPosition = FormStartPosition.CenterScreen
            _fm.Show()
        End If

    End Sub
    Private oDg As Boolean
    ''' <summary>
    ''' ловит построенное описание
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub DescriptionChanged_EventHandler(sender As Object, e As Trilbone.clsTreeService.DescriptionAcceptEventArg)
        Dim _status As Integer

        Dim _result = Trilbone.clsTreeService.JoinDescriptionElements(Me.oCurrentXMLDescription, e.DescriptionXelements, _status)
        If _status > 0 Then
            'описание сгенерировано
            Me.oCurrentXMLDescription = _result
            Me.oDescriptionFromBDFlag = False
            'Me.tpctlMain.SelectedTab = Me.tpOldDescription
            Me.lbSampleStatus.BackColor = Color.Red
            Me.btToSite.Enabled = True
        Else
            MsgBox("Не удалось присоединить добавленное описание")
            If Me.oCurrentXMLDescription Is Nothing Then
                Return
            Else
                'Me.tpctlMain.SelectedTab = Me.tpOldDescription
                Me.btToSite.Enabled = True
            End If
        End If
        'описание есть
        ''читать Этикетки из БД
        Me.cbxGetLabelInfoFromDB.Checked = True
        Me.BuildDescription(True)
        btCopyToLabel_Click(sender, e)
    End Sub
    Private oCurrentXMLDescription As Xml.Linq.XElement
    Private oCurrentLabelDescription As Xml.Linq.XElement
    ''' <summary>
    ''' сотержит текущую коллекцию элементов для всех языков
    ''' </summary>
    ''' <remarks></remarks>
    Private oCurrentElementsCollection As New List(Of Trilbone.clsTreeService.clsDescriptionElement)
    Private oIndexlbElements As Integer
    Private oCurrentCulture As System.Globalization.CultureInfo = Service.clsApplicationTypes.EnglishCulture

    Private oSampleDataObj As Service.SamplesOnSale
    Private oLabel As clsLabelBase
    Private oLabelinfoToRecinDB As New List(Of Integer)

    ''' <summary>
    '''!!! строит LabelINFO  для текущей культуры
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ReadLabelInfo(culture As Globalization.CultureInfo, Optional allculture As Boolean = False)
        Select Case Me.cbxGetLabelInfoFromDB.Checked
            Case True
                'ПОЛУЧИТЬ из БД???
                For Each t In Trilbone.clsTreeService.CreateElementCollection(oCurrentXMLDescription, culture, allculture)
                    Dim _requestID = t.CalculateLabelInfoID()
                    Dim _result = (oReadySampleDBContext.GetLabelInfoByID(_requestID)).FirstOrDefault
                    'тут запрос в бд
                    If Not _result Is Nothing Then
                        'тут создадим обьект лабелинфо изБД
                        With _result
                            Me.oLabel.LabelInfoCollection.Add(clsLabelInfo.CreateInstance(.nodeID, Globalization.CultureInfo.CreateSpecificCulture(.lang), .group, .treename, .rootnode, .value))
                        End With
                    Else
                        'нет в базе = создать из описания
                        Dim _new = t.CreateLabelInfoObject
                        Me.oLabel.LabelInfoCollection.Add(_new)
                        'и ОТМЕТИТЬ, что нет в БД!!!
                        Me.oLabelinfoToRecinDB.Add(_new.iD)
                        Me.btRecToDB.BackColor = Color.Red
                    End If
                Next
            Case Else
                'создать лабелинфо из элементов
                Me.oLabel.LabelInfoCollection = (From c In Trilbone.clsTreeService.CreateElementCollection(oCurrentXMLDescription, culture, allculture) Select c.CreateLabelInfoObject).ToList
        End Select
    End Sub


    Private Sub BuildDescription(readimages As Boolean)

        If oCurrentXMLDescription Is Nothing Then
            'если описание не xml, то покажем исходник
            If Not oSampleDataObj Is Nothing Then
                Me.DescriptionRichTextBox.Text = oSampleDataObj.Description
                'Me.DescriptionRichTextBox.ForeColor = Color.Red
            End If
            Me.rtbLabel.Text = "Создайте описание"
            Me.rtbLabel.Enabled = False
            Return
        End If

        'описание есть xml
        Me.rtbLabel.Enabled = True
        Me.rtbLabel.Text = ""
        'Me.DescriptionRichTextBox.ForeColor = ForeColor

        'заполним список элементов
        oCurrentElementsCollection = Trilbone.clsTreeService.CreateElementCollection(oCurrentXMLDescription, Me.oCurrentCulture, True)
        'привяжем listbox к коллекции из текущей культуры
        Me.lbElements.DataSource = Trilbone.clsTreeService.CreateElementCollection(oCurrentXMLDescription, Me.oCurrentCulture)

        'покажем описание
        If cbxRawXMLView.Checked Then
            'покажем сырой xml
            Me.DescriptionRichTextBox.Text = oCurrentXMLDescription.ToString
            'и разрешим редактировать..
            Me.DescriptionRichTextBox.ReadOnly = False
        ElseIf cbxLabelXML.Checked = False Then
            'иначе покажем разобранное описание
            Dim _status As Integer
            Dim _result = Trilbone.clsTreeService.ParseDescriptionXML(oCurrentCulture, oCurrentXMLDescription.ToString, _status)
            If _status > 0 Then
                Me.DescriptionRichTextBox.Text = _result
            Else
                Me.DescriptionRichTextBox.Text = "Не удалось разобрать описание"
                Me.rtbLabel.Text = "Не удалось разобрать описание"
                Me.rtbLabel.Enabled = False
                Return
            End If
            ' и запретим редактировать
            Me.DescriptionRichTextBox.ReadOnly = True
        End If




        '---------ЭТИКЕТКА-----------------------------------------
        If Me.oLabel Is Nothing Then

            If oCurrentXMLDescription Is Nothing Then
                'описатель элементов отсутствует = выход
                Me.rtbLabel.Text = "необходимо создать описание"
                Return
            End If

            'этикетки нет = сгенерируем для всех языков
            Me.oLabelinfoToRecinDB.Clear()
            Me.oLabel = New clsLabelBase
            If oCurrentLabelDescription Is Nothing Then
                'и описатель отсутствует - сгенерим labelinfo
                Me.ReadLabelInfo(oCurrentCulture, True)
                'создать этикетки для всех языков
                Me.oLabel.LabelCollection = (clsLabelBase.CreateLabelObjCollection(Me.oLabel.LabelInfoCollection, EnglishCulture, Nothing, True))
            Else
                'описатель этикетки присутствует
                'разобрать этикетку из описателя
                Me.oLabel.LabelInfoCollection = clsLabelBase.CreateLabelInfoCollection(oCurrentLabelDescription, oCurrentCulture, True)
                Me.rtbLabel.BackColor = Control.DefaultBackColor
                'разобрать этикетку из описателя
                Me.oLabel.LabelCollection = clsLabelBase.CreateLabelObjCollection(oCurrentLabelDescription, oCurrentCulture, True)
            End If

        Else
            'этикетка присутствует
            If Me.oLabel.GetInfoByCulture(oCurrentCulture).Count = 0 Then
                Me.ReadLabelInfo(oCurrentCulture)
            End If
            If Me.oLabel.GetLabelsByCulture(oCurrentCulture).Count = 0 Then
                'создать этикетки
                Me.oLabel.LabelCollection.AddRange(clsLabelBase.CreateLabelObjCollection(Me.oLabel.LabelInfoCollection, oCurrentCulture))
            End If
        End If

        Me.oCurrentLabelDescription = Me.oLabel.GetXElements

        'изображения
        If readimages Then
            'проверим наличие запомненных
            Dim _elb = (From c In Me.oLabel.GetLabelsByCulture(oCurrentCulture) Where IsNothing(c.Files) = False AndAlso c.Files.Count > 0 Select c.Files).ToList
            'выбрать тип этикеток в ЭУ???
            'If Not _elb Is Nothing AndAlso _elb.Count > 0 Then
            '    'есть запомненные этикетки
            '    Me.rbFromDB_Text.Checked = True
            '    Me.rbLabelFromTrees.Checked = False
            'Else
            '    'нет запомненных, читаем из папок узлов
            '    Me.rbFromDB_Text.Checked = False
            '    Me.rbLabelFromTrees.Checked = True
            'End If
        End If

        'работа с ЭУ
        If Me.cbxLabelXML.Checked Then
            Me.DescriptionRichTextBox.Text = Me.oCurrentLabelDescription.ToString
        End If
        Me.ClsLabelInfoBindingSource.DataSource = Me.oLabel.GetInfoByCulture(oCurrentCulture)
        Me.DataGridView1.Refresh()

        Me.rtbLabel.Text = Me.oLabel.ToString(oCurrentCulture)


        Dim _img = clsApplicationTypes.GetLabelImgByText(rtbLabel.Text, 60, 1, , , , 0)

        UcGoodLabel1.AddLabel(_img)

        'oLabelImages.Add(_img)
        'oLabelImagesWithoutFilter.Add(_img)
        'Me.ImageBindingSource.ResetBindings(False)


        MarkUnsavedLabelInDB()

    End Sub
    Private oLabelImages As New List(Of Image)
    ''' <summary>
    ''' показывает, что надо подгружать обьекты
    ''' </summary>
    ''' <remarks></remarks>
    Private oNeedLoadBigImage As Boolean
    Private ooldBigObjectIndex As Integer


    Private Sub btClearAll_Click(sender As Object, e As EventArgs) Handles btClearAll.Click
        Me.oCurrentLabelDescription = Nothing
        Me.oCurrentXMLDescription = Nothing
        Me.ClsLabelInfoBindingSource.DataSource = Nothing
        Me.DescriptionRichTextBox.Text = ""
        Me.UserDescriptionRichTextBox.Text = ""
        Me.rtbLabel.Text = ""
        'Me.lbElements.BindingContext.Item(Me.oCurrentElementsCollection).SuspendBinding()
        If Not Me.oCurrentElementsCollection Is Nothing Then
            Me.oCurrentElementsCollection.Clear()
        End If
        Me.oCurrentXMLDescription = Nothing
        Me.oCurrentLabelDescription = Nothing
        Me.oLabel = Nothing
        Me.lbElements.DataSource = Nothing
        Me.lbSampleStatus.BackColor = Color.Red
        'Me.lbElements.BindingContext.Item(Me.oCurrentElementsCollection).ResumeBinding()
    End Sub

    Private Sub btSaveElement_Click(sender As Object, e As EventArgs) Handles btSaveElement.Click
        If lbElements.SelectedItem Is Nothing Then Exit Sub
        Dim _curr = CType(lbElements.SelectedItem, Trilbone.clsTreeService.clsDescriptionElement)
        If _curr.Equals(Me.UserDescriptionRichTextBox.Tag) Then
            'все ок текст относится к нужному элементу
            _curr.Value = Me.UserDescriptionRichTextBox.Text
            Me.oIndexlbElements = Me.lbElements.SelectedIndex
        End If

        btSaveElement.ForeColor = Control.DefaultForeColor
        Me.BuildDescription(False)
        Me.lbSampleStatus.BackColor = Color.Red
    End Sub

    Private Sub btDelElement_Click(sender As Object, e As EventArgs) Handles btDelElement.Click
        If lbElements.SelectedItem Is Nothing Then Exit Sub
        Dim _curr = CType(lbElements.SelectedItem, Trilbone.clsTreeService.clsDescriptionElement)

        If MsgBox("Удалить элемент описания " & _curr.ElementName & "?", vbYesNo) = MsgBoxResult.Yes Then
            Me.oCurrentElementsCollection.Remove(_curr)
            ''а теперь добавить все другой культуры
            'Select Case oCurrentCulture.Name
            '    Case EnglishCulture.Name
            '        oCurrentElementsCollection.AddRange(clsTreeService.CreateElementCollection(Me.oCurrentXMLDescription, RussianCulture))
            '    Case RussianCulture.Name
            '        oCurrentElementsCollection.AddRange(clsTreeService.CreateElementCollection(Me.oCurrentXMLDescription, EnglishCulture))
            'End Select
            ''а теперь вернуть на место
            'Me.oCurrentElementsCollection = clsTreeService.CreateElementCollection(Me.oCurrentXMLDescription, oCurrentCulture)
            Me.oCurrentXMLDescription = Trilbone.clsTreeService.GetDescriptionFromElementCollection(Me.oCurrentElementsCollection)

            'удаление из этикетки - копия функции есть дальшеЁ!!
            Dim _ind As Integer = Me.oLabel.LabelInfoCollection.FindIndex(Function(c) c.parentNodeID = _curr.LastNodeID And c.culture.Name = _curr.Culture.Name)

            Do While _ind > -1
                Dim _ai = Me.oLabel.LabelCollection.FindIndex(Function(c) c.culture.Name = oCurrentCulture.Name)

                Me.oLabel.LabelCollection(_ai).NodeCollection.RemoveAll(Function(c)
                                                                            Dim _res = (From s In c.NodeIDCollection Where s.LabelinfoID = Me.oLabel.LabelInfoCollection(_ind).iD Select s).Count

                                                                            If _res > 0 Then Return True
                                                                            Return False
                                                                        End Function)

                Me.oLabelinfoToRecinDB.Remove(Me.oLabel.LabelInfoCollection(_ind).iD)
                Me.oLabel.LabelInfoCollection.RemoveAt(_ind)
                _ind = Me.oLabel.LabelInfoCollection.FindIndex(Function(c) c.parentNodeID = _curr.LastNodeID And c.culture.Name = _curr.Culture.Name)
            Loop

            Me.rtbLabel.Text = oLabel.ToString
            Me.DataGridView1.Refresh()
            Me.oIndexlbElements = -1
            Me.lbSampleStatus.BackColor = Color.Red
            Me.BuildDescription(False)
        End If


    End Sub

    Private Sub btAddUserDescr_Click(sender As Object, e As EventArgs) Handles btAddUserDescr.Click
        If Me.UserDescriptionRichTextBox.Text = "" Then Exit Sub

        Dim _tag = cbTagOfElement.Text
        If _tag = "" Then
            _tag = "USERDESCR"
            cbTagOfElement.SelectedIndex = 0
        End If

        Dim _n = Trilbone.clsTreeService.clsDescriptionElement.CreateInstance(0, "notfile", _tag, Me.cbPrefixElement.Text, oCurrentCulture, "no info ")

        Me.oCurrentXMLDescription = Trilbone.clsTreeService.AddElementToDescription(Me.oCurrentXMLDescription, {_n})
        Me.oIndexlbElements = Me.lbElements.Items.Count
        Me.lbSampleStatus.BackColor = Color.Red
        Me.BuildDescription(False)
    End Sub

    Private Sub cbxRawXMLView_CheckedChanged(sender As Object, e As EventArgs) Handles cbxRawXMLView.Click
        If cbxRawXMLView.Checked Then
            Me.cbxLabelXML.Checked = False
        End If
        BuildDescription(False)
    End Sub

    Private Sub rbEnglish_CheckedChanged(sender As Object, e As EventArgs) Handles rbEnglish.CheckedChanged
        Dim _old = oCurrentCulture
        If rbEnglish.Checked Then
            oCurrentCulture = Service.clsApplicationTypes.EnglishCulture
        Else
            oCurrentCulture = Service.clsApplicationTypes.RussianCulture
        End If
        If Not _old.Name = oCurrentCulture.Name Then
            Me.BuildDescription(True)

        Else
            Me.BuildDescription(False)
        End If

        init()
        cbListOfTree_SelectedIndexChanged(sender, e)

    End Sub

    Private Sub rbRussian_CheckedChanged(sender As Object, e As EventArgs) Handles rbRussian.CheckedChanged
        Dim _old = oCurrentCulture

        If rbRussian.Checked Then
            oCurrentCulture = Service.clsApplicationTypes.RussianCulture
        Else
            oCurrentCulture = Service.clsApplicationTypes.EnglishCulture
        End If
        If Not _old.Name = oCurrentCulture.Name Then
            Me.BuildDescription(True)
        Else
            Me.BuildDescription(False)
        End If
        init()
        cbListOfTree_SelectedIndexChanged(sender, e)
    End Sub

    Private Sub DescriptionRichTextBox_Enter(sender As Object, e As EventArgs) Handles DescriptionRichTextBox.Enter
        If sender.Text.Length > 0 Then
            '------------------
            Dim _data As String = sender.Text
            Try
                My.Computer.Clipboard.Clear()
                My.Computer.Clipboard.SetText(_data)
            Catch ex As Exception
                MsgBox("Ошибка при помещении данных в буфер обмена.", vbCritical)
            End Try
            '-----------------
            MsgBox("Данные скопированы", vbInformation)
        End If
    End Sub

    Private Sub DescriptionRichTextBox_TextChanged(sender As Object, e As EventArgs) Handles DescriptionRichTextBox.TextChanged
        If Me.oCurrentXMLDescription Is Nothing Then Exit Sub
        'был изменен текст
        If cbxRawXMLView.Checked Then
            'в окне-сырой xml
            'пробуем преобразовать в xml
            Dim _status As Integer
            Dim _result = clsLabelBase.ParseTextToXElement(Me.DescriptionRichTextBox.Text, _status)
            If _status <= 0 Then
                'неудачно изменен
                MsgBox("Неправильно форматированный xml!", vbCritical)
                Me.DescriptionRichTextBox.Text = Me.oCurrentXMLDescription.ToString
            Else
                Me.oCurrentXMLDescription = _result
                Me.DescriptionRichTextBox.Text = _result.ToString
                Me.BuildDescription(False)
            End If
        End If
    End Sub



    Private Sub UserDescriptionRichTextBox_KeyUp(sender As Object, e As KeyEventArgs) Handles UserDescriptionRichTextBox.KeyUp
        If lbElements.SelectedItem Is Nothing Then Exit Sub
        Dim _curr = CType(lbElements.SelectedItem, Trilbone.clsTreeService.clsDescriptionElement)
        If _curr.Equals(Me.UserDescriptionRichTextBox.Tag) Then
            If Not _curr.Value = Me.UserDescriptionRichTextBox.Text Then
                'текст узла изменен
                btSaveElement.ForeColor = Color.Red
            End If
        End If
    End Sub



    Private Sub lbElements_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbElements.SelectedIndexChanged
        If lbElements.SelectedItem Is Nothing Then Exit Sub
        Dim _curr = CType(lbElements.SelectedItem, Trilbone.clsTreeService.clsDescriptionElement)
        Me.UserDescriptionRichTextBox.Text = _curr.Value
        Me.UserDescriptionRichTextBox.Tag = _curr
        Me.btSaveElement.ForeColor = Control.DefaultForeColor
        'oIndexlbElements = -1
    End Sub
#End Region


    Private Sub btAddInListOfFrase_Click(sender As Object, e As EventArgs) Handles btAddInListOfFrase.Click
        Me.lbFrase.Items.Add(Me.UserDescriptionRichTextBox.Text)
        My.Settings.FraseBuffer.Add(Me.UserDescriptionRichTextBox.Text)
        My.Settings.Save()
    End Sub

    Private Sub btAddInElement_Click(sender As Object, e As EventArgs) Handles btAddInElement.Click
        If Not Me.lbFrase.SelectedItem Is Nothing Then
            Me.UserDescriptionRichTextBox.Text = Me.lbFrase.SelectedItem
        End If


    End Sub

    Private Sub btRemoveFromList_Click(sender As Object, e As EventArgs) Handles btRemoveFromList.Click
        If Not Me.lbFrase.SelectedItem Is Nothing Then
            My.Settings.FraseBuffer.RemoveAt(Me.lbFrase.SelectedIndex)
            Me.lbFrase.Items.RemoveAt(Me.lbFrase.SelectedIndex)
            My.Settings.Save()
        End If
    End Sub





    Private Sub pbMainImage_Click(sender As Object, e As EventArgs) Handles pbMainImage.Click
        If oSampleNumber Is Nothing Then Exit Sub
        If pbMainImage.Image Is Nothing Then Exit Sub

        Dim _prm = Service.clsApplicationTypes.SamplePhotoObject.GetImageCollection(oSampleNumber, Me.oCurrentSource, False)
        If _prm Is Nothing Then
            MsgBox("невозможно показать форму")
        End If


        Dim _fmImage As Form
        'show image form
        'использование сервисов
        'по запросу выполняем вызов из сервиса

        Dim _param As Object = {_prm, ""}

        'если делегата нет, то сервис недоступен
        If Not Global.Service.clsApplicationTypes.DelegateStoreApplicationForm(Service.clsApplicationTypes.emFormsList.fmImage) Is Nothing Then
            'сервис зарегестрирован - вызываем
            _fmImage = Global.Service.clsApplicationTypes.DelegateStoreApplicationForm(Service.clsApplicationTypes.emFormsList.fmImage).Invoke(_param)
            If Not _fmImage Is Nothing Then
                'show form
                _fmImage.Width = 640
                _fmImage.Height = 480

                '_fmImage.Name = "ImageShowForm"
                _fmImage.StartPosition = FormStartPosition.CenterScreen

                'привязка обработчика

                Service.clsApplicationTypes.DelegatStorefmImageDeleteDelegate = New Service.clsApplicationTypes.fmImageDeleteDelegat(AddressOf DelImage_eventHandler)
                Service.clsApplicationTypes.DelegatStorefmImageCopyDelegate = New Service.clsApplicationTypes.fmImageCopyDelegat(AddressOf CopyImage_eventHandler)

                _fmImage.ShowDialog()

                If CType(_fmImage, fmImage).HasChanges Then
                    Me.ReadPhotos()
                End If
            End If

        End If


    End Sub

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
                Dim _count As Integer = Service.clsApplicationTypes.SamplePhotoObject.CopyImagesFromSourceToSource(oSampleNumber, _Fromsource, _Tosource, False, e.ImageNames, _optimize)
                MsgBox(_count & " фото скопированы для образца " & oSampleNumber.GetEan13 & " в уст-во " & Me.oCurrentSource.ToString(), vbInformation)
            Case MsgBoxResult.No
                Exit Sub
        End Select
    End Sub

#Region "Drag"

    Private odragBoxFromMouseDown As Rectangle

    Private Sub pbMainImage_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles pbMainImage.MouseDown

        ' Remember the point where the mouse down occurred. The DragSize indicates
        ' the size that the mouse can move before a drag event should be started.                
        Dim dragSize As Size = SystemInformation.DragSize

        ' Create a rectangle using the DragSize, with the mouse position being
        ' at the center of the rectangle.
        odragBoxFromMouseDown = New Rectangle(New Point(e.X - (dragSize.Width / 2), _
                                                        e.Y - (dragSize.Height / 2)), dragSize)

    End Sub

    Private Sub pbMainImage_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles pbMainImage.MouseMove
        If ((e.Button And MouseButtons.Left) = MouseButtons.Left) Then

            ' If the mouse moves outside the rectangle, start the drag.
            If (Rectangle.op_Inequality(odragBoxFromMouseDown, Rectangle.Empty) And _
                Not odragBoxFromMouseDown.Contains(e.X, e.Y)) Then

                'variant 1
                'Dim _obg As New DataObject
                '_obg.SetData(DataFormats.Dib, True, pbLabel.Image)
                'pbLabel.DoDragDrop(_obg, DragDropEffects.Copy)

                'variant 2 --OK!!
                Dim ms As New IO.MemoryStream
                Dim ms2 As New IO.MemoryStream
                sender.Image.Save(ms, ImageFormat.Bmp)
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


    Private Sub pbMainImage_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles pbMainImage.MouseUp
        ' Reset the drag rectangle when the mouse button is raised.
        odragBoxFromMouseDown = Rectangle.Empty
    End Sub

#End Region


    Private Sub rtbLabel_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles rtbLabel.KeyDown
        Select Case e.KeyCode
            Case Keys.Back, Keys.Delete
                Dim _ind = rtbLabel.SelectionStart
                If _ind = 0 Then Exit Sub
                'ловим попытку удаления переноса строки
                If AscW(rtbLabel.Text.ToCharArray(_ind - 1, 1)(0)) = 10 Then
                    e.SuppressKeyPress = True
                End If
            Case Keys.Enter
                'ловим попытку ввода перевода строки
                e.SuppressKeyPress = True
        End Select
    End Sub

    Private Sub rtbLabel_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles rtbLabel.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Right Then
            If Me.rtbLabel.Text.Length > 0 Then
                '------------------
                Dim _data As String = rtbLabel.Text
                Try
                    My.Computer.Clipboard.Clear()
                    My.Computer.Clipboard.SetText(_data)
                Catch ex As Exception
                    MsgBox("Ошибка при помещении данных в буфер обмена.", vbCritical)
                End Try
                '-----------------
                MsgBox("Данные скопированы", vbInformation)
            End If
        End If
    End Sub



    Private Sub rtbLabel_TextChanged(sender As Object, e As EventArgs) Handles rtbLabel.TextChanged
        'обновить обьект
        If Me.oLabel Is Nothing Then Return
        'If oNotChangedTable Then Exit Sub

        'разбить на строки
        Dim _data = rtbLabel.Text.Split({ChrW(10)}, StringSplitOptions.RemoveEmptyEntries)
        If _data.Length = 0 OrElse _data(0).Length = 0 Then Exit Sub

        'фильтр по ордеру
        Dim _res = (From c In oLabel.GetLabelsByCulture(oCurrentCulture).FirstOrDefault.NodeCollection Group By c.Order Into ab = Group, obj = FirstOrDefault()).ToList

        If _data.Length <> _res.Count Then
            If _data.Length > _res.Count Then
                'добавлена новая строка
                Exit Sub
            End If
            Exit Sub
        End If

        'найдем активный индекс
        Dim _indx = Me.rtbLabel.GetLineFromCharIndex(Me.rtbLabel.SelectionStart)
        If _indx > _res.Count - 1 Then
            'новая строка пуста и пытаемся ее удалить
            Exit Sub
        End If

        If _res(_indx).ab.Count = 1 Then
            If Not _res(_indx).obj.Value = _data(_indx) Then
                _res(_indx).obj.Value = _data(_indx)
                Me.btCopyToLabelinfo.BackColor = Color.Red
                Me.rtbLabel.BackColor = Control.DefaultBackColor
            End If

        End If


    End Sub

    Private Sub SampleNumberTextBox_KeyUp(sender As Object, e As KeyEventArgs) Handles SampleNumberTextBox.KeyUp
        If e.Control Then
            If e.KeyValue = 86 Then
                'ctl+V
                If My.Computer.Clipboard.ContainsText Then
                    Dim _txt = My.Computer.Clipboard.GetText
                    If _txt.Length < 14 Then
                        Dim _sn = clsApplicationTypes.clsSampleNumber.CreateFromString(_txt)
                        If Not _sn Is Nothing AndAlso _sn.CodeIsCorrect Then
                            Me.SampleNumberTextBox.Text = _sn.EAN13
                            '------------------
                            Dim _data As String = _sn.EAN13
                            Try
                                My.Computer.Clipboard.Clear()
                                My.Computer.Clipboard.SetText(_data)
                            Catch ex As Exception
                                MsgBox("Ошибка при помещении данных в буфер обмена.", vbCritical)
                            End Try
                            '-----------------
                            Me.btSearchInfo_Click(Me, EventArgs.Empty)
                        End If
                    End If

                End If
            End If
            If e.KeyValue = 67 Then
                'ctl+c
                If Not oSampleNumber Is Nothing Then
                    '------------------
                    Dim _data As String = oSampleNumber.EAN13
                    Try
                        My.Computer.Clipboard.Clear()
                        My.Computer.Clipboard.SetText(_data)
                    Catch ex As Exception
                        MsgBox("Ошибка при помещении данных в буфер обмена.", vbCritical)
                    End Try
                    '-----------------
                    Me.SampleNumberTextBox.Text = oSampleNumber.EAN13
                End If

            End If
        End If
    End Sub




    Private oTipTool_DBlabels As New ToolTip

    Private Sub fmSampleData_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With oTipTool_DBlabels
            .AutoPopDelay = 15000
            .InitialDelay = 50
            .ReshowDelay = 50
            .ToolTipTitle = "этикетка из базы данных"
            .ToolTipIcon = ToolTipIcon.Info
        End With
        Me.lbTreeName.Text = Trilbone.clsTreeService.CurrentGroupName
    End Sub

    Private Sub btSearchInfo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles btSearchInfo.KeyPress, Me.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            'цифра
            If Me.SampleNumberTextBox.Text.Length = 13 Then
                Me.SampleNumberTextBox.Text = ""
            End If
            'очистить поле и начать ввод
            Me.SampleNumberTextBox.Text = e.KeyChar.ToString
            Me.SampleNumberTextBox.Focus()

            Me.SampleNumberTextBox.SelectionStart = 1
        End If

        If Asc(e.KeyChar) = 13 Then
            btSearchInfo_Click(Me, New System.EventArgs)
        End If
    End Sub



    Private Sub btCopyNumber_Click(sender As System.Object, e As System.EventArgs) Handles btCopyNumber.Click

        If Not Me.oSampleNumber Is Nothing Then
            '------------------
            Dim _data As String = Me.oSampleNumber.EAN13p36TT
            Try
                My.Computer.Clipboard.Clear()
                My.Computer.Clipboard.SetText(_data)
            Catch ex As Exception
                MsgBox("Ошибка при помещении данных в буфер обмена.", vbCritical)
            End Try
            '-----------------
        Else
            MsgBox("Не задан номер!", vbCritical)
        End If

    End Sub

    Private Sub btCopyArticul_Click(sender As System.Object, e As System.EventArgs) Handles btCopyArticul.Click
        If Not Me.oSampleNumber Is Nothing Then
            'TODO хеш-код папки
            '------------------
            Dim _data As String = Me.oSampleNumber.EAN13
            Try
                My.Computer.Clipboard.Clear()
                My.Computer.Clipboard.SetText(_data)
            Catch ex As Exception
                MsgBox("Ошибка при помещении данных в буфер обмена.", vbCritical)
            End Try
            '-----------------
        Else
            MsgBox("Не задан номер!", vbCritical)
        End If
    End Sub


    Private Sub cbTagOfElement_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbTagOfElement.SelectedIndexChanged
        If cbTagOfElement.SelectedItem Is Nothing Then Exit Sub
        If cbTagOfElement.Text = "ITEM" Then
            Dim _index = Me.cbPrefixElement.Items.Count - 1
            Me.cbPrefixElement.SelectedIndex = _index
        Else
            Me.cbPrefixElement.SelectedIndex = 0
        End If
    End Sub


    Private Sub btDescriptionForm_Click(sender As System.Object, e As System.EventArgs) Handles btDescriptionForm.Click
        Dim _sp As New SplashScreen1
        _sp.Show()
        Application.DoEvents()

        'использование сервисов
        'выполняем вызов из сервиса
        Dim _param As Object = Nothing
        'если делегата нет, то сервис недоступен
        If Not Global.Service.clsApplicationTypes.DelegateStoreApplicationForm(emFormsList.fmDescriptionTreeBuilder) Is Nothing Then
            'сервис зарегестрирован - вызываем 
            Dim _fm = Global.Service.clsApplicationTypes.DelegateStoreApplicationForm(emFormsList.fmDescriptionTreeBuilder).Invoke(_param)

            If _fm Is Nothing Then Return
            ' Dim _fm = Trilbone.clsTreeService.TreeManager.GetformDescriptionBuilder
            _fm.StartPosition = FormStartPosition.CenterScreen
            _fm.Show()
            _sp.Hide()
        Else
            Return
        End If

    End Sub


    Private Sub btToMoySklad_Click(sender As System.Object, e As System.EventArgs) Handles btToMoySklad.Click

        If Not clsApplicationTypes.GetAccess("Вход в Мой Склад") Then
            MsgBox("Вход в Мой склад запрещен. Обратись к админу.", vbCritical)
            Return
        End If

        SaveToDB(False)

        Dim _fmMoySklad = clsApplicationTypes.FormMOYSKLAD
        If _fmMoySklad Is Nothing Then Return



        '-------------
        'размер образца
        Dim _leight As Decimal = UcFossilTabPage1.GetFirstFossilLen
        If _leight = 0 And (Not Me.Sample_lengthTextBox.Text = "") Then
            _leight = Decimal.Parse(Me.Sample_lengthTextBox.Text)
        End If
        'вес образца
        Dim _weight As Decimal = 0
        If Not Me.Sample_net_weightTextBox.Text = "" Then
            _weight = Decimal.Parse(Me.Sample_net_weightTextBox.Text)
        End If

        'вынуть номер первой объекта
        Dim _firstfossilnumber As String
        If Me.UcFossilTabPage1.TabCount > 0 Then
            _firstfossilnumber = Me.UcFossilTabPage1.GetFirstFossilNumber
        Else
            _firstfossilnumber = ""
        End If


        If _fmMoySklad.Visible = False Then
            If _fmMoySklad.IsHandleCreated Then
                _fmMoySklad.Visible = True
            Else
                Try
                    _fmMoySklad.Show()
                Catch ex As Exception
                    '_fmMoySklad = clsApplicationTypes.FormMOYSKLAD(True)
                    Return
                End Try
            End If
        End If

        ''установить значения в МС
        'SampleNumber As String, SampleName As String, Optional FirstFossilNumber As String = "", Optional Articul As String = "", Optional Barcode As String = "", Optional Prices As Dictionary(Of String, Decimal) = Nothing, Optional Currency As String = "", Optional directWeight As Decimal = 0, Optional directSizeInCm As Decimal = 0, Optional NotHasPhoto As Integer = -1
        CType(_fmMoySklad, Object).SetSample(Me.oSampleNumber.ShotCode, GetParcedName(), _firstfossilnumber, , Me.oSampleNumber.EAN13, , , _weight, _leight, oCurrentHasImages)
        Me.SampleNumberTextBox.Focus()
        _fmMoySklad.Focus()
    End Sub
    ''' <summary>
    ''' разбирает имя
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetParcedName() As String
        'вес образца в кг
        Dim _weight As Decimal = 0
        If Not Me.Sample_net_weightTextBox.Text = "" Then
            _weight = Decimal.Parse(Me.Sample_net_weightTextBox.Text)
        End If

        'длина образца в см
        Dim _sampleLenght As Decimal = 0
        If Not Me.Sample_lengthTextBox.Text = "" Then
            _sampleLenght = Decimal.Parse(Me.Sample_lengthTextBox.Text)
        End If

        'длина первой фоссилии - получаем по ссылке
        Dim _firstLen As Decimal
        Dim _fossList = Me.UcFossilTabPage1.GetFossilsList(_firstLen)
        If _fossList.Count = 0 Then
            _fossList.Add(Sample_main_speciesComboBox.Text)
        End If

        'имя (имена)
        Dim _name As String
        If _fossList.Count = 1 Then
            _name = Sample_main_speciesComboBox.Text
            'задать строку параметра
            If _firstLen > 0 Then
                _name += " [" & _firstLen & "cm]"
            ElseIf _sampleLenght > 0 Then
                _name += " [" & _sampleLenght & "cm]"
            ElseIf _weight > 0 Then
                _name += "[" & _weight & "kg]"
            End If
        Else
            _name = clsApplicationTypes.FossilNamesParser(_fossList.ToArray)
            'задать строку параметра
            If _sampleLenght > 0 Then
                _name += " [" & _sampleLenght & "cm]"
            ElseIf _weight > 0 Then
                _name += " [" & _weight & "cm]"
            ElseIf _firstLen > 0 Then
                _name += "[" & _firstLen & "kg]"
            End If
        End If


        Return _name
    End Function


    Private Sub btReadFromDescripElem_Click(sender As System.Object, e As System.EventArgs) Handles btReadFromDescripElem.Click
        'сгенерим labelinfo

        'чистим этикетку
        oLabel = Nothing
        oCurrentLabelDescription = Nothing
        Me.BuildDescription(False)
    End Sub


    Private Sub btCopyToLabelinfo_Click(sender As System.Object, e As System.EventArgs) Handles btCopyToLabelinfo.Click
        If Me.btCopyToLabelinfo.BackColor = Color.Red Then
            'копировать строки из лабел обьекта в лабелинфо
            Dim _Labelinfo = Me.oLabel.GetInfoByCulture(oCurrentCulture)
            Dim _labelNode = Me.oLabel.GetLabelsByCulture(oCurrentCulture).First.NodeCollection


            Select Case _labelNode.Count - _Labelinfo.Count
                Case 0
                    'число обьектов равно - copy
                    For i = 0 To _Labelinfo.Count - 1
                        If Not _Labelinfo(i).Value = _labelNode(i).Value Then
                            'значение будет изменено
                            If (Not Me.oLabelinfoToRecinDB.Contains(_Labelinfo(i).iD)) Then
                                Me.oLabelinfoToRecinDB.Add(_Labelinfo(i).iD)
                                Me.btRecToDB.BackColor = Color.Red
                            End If
                        End If
                        _Labelinfo(i).Value = _labelNode(i).Value
                    Next

                Case Is <= -1
                    'лабелинфо больше, значит комбинировали узлы
                    For Each t In _labelNode
                        Dim t1 = t
                        If Not t.Combined Then
                            'меняем только некомбинированные узлы
                            Dim _target = From c In _Labelinfo Where c.iD = t1.NodeIDCollection.First.LabelinfoID Select c
                            If _target.Count > 0 Then
                                _target.First.Value = t.Value
                            End If
                        End If
                    Next


                Case Is >= 1
                    'узлов в этикетке больше, значит добавляли узлы
                    MsgBox("узлов в этикетке больше, значит добавляли узлы/ Не реализовано")

            End Select

            Me.btCopyToLabelinfo.BackColor = Control.DefaultBackColor
            Me.DataGridView1.Refresh()
            MarkUnsavedLabelInDB()

        End If
    End Sub

    Private Sub btCopyToLabel_Click(sender As System.Object, e As System.EventArgs) Handles btCopyToLabel.Click
        'создать этикетки
        Dim _ind = Me.oLabel.LabelCollection.FindIndex(Function(c) c.culture.Name = oCurrentCulture.Name)
        Me.oLabel.LabelCollection(_ind) = clsLabelBase.CreateLabelObjCollection(Me.oLabel.LabelInfoCollection, oCurrentCulture).FirstOrDefault

        Me.oCurrentLabelDescription = Me.oLabel.GetXElements

        'работа с ЭУ
        Me.rtbLabel.Text = Me.oLabel.ToString(oCurrentCulture)
        Me.rtbLabel.BackColor = Control.DefaultBackColor
        UcGoodLabel1.AddLabel(clsApplicationTypes.GetLabelImgByText(rtbLabel.Text, 60, 1))

    End Sub



    Dim otmpLabelInfo As clsLabelInfo

    Private oClickedLabelInfo As clsLabelInfo
    Private Sub DataGridView1_CellMouseClick(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        Select Case e.Button
            Case Windows.Forms.MouseButtons.Right
                Me.cmsLabelInfo.Show(MousePosition)
                oClickedLabelInfo = Me.DataGridView1.Rows(e.RowIndex).DataBoundItem
        End Select
    End Sub

    Private Sub DataGridView1_CellValueChanged(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellValueChanged

        Dim _obj As clsLabelInfo = Me.ClsLabelInfoBindingSource.Current
        If (Not _obj Is Nothing) AndAlso (Not Me.oLabelinfoToRecinDB.Contains(_obj.iD)) Then
            Me.oLabelinfoToRecinDB.Add(_obj.iD)
            Me.btRecToDB.BackColor = Color.Red
            MarkUnsavedLabelInDB()
        End If
    End Sub

    Private Sub btRecToDB_Click(sender As System.Object, e As System.EventArgs) Handles btRecToDB.Click
        If Me.oLabelinfoToRecinDB.Count = 0 Then Exit Sub

        Select Case MsgBox("Записать данные в БД?", vbYesNo)
            Case MsgBoxResult.No
                Exit Sub
        End Select

        Dim _txt As String = ""


        For Each t In Me.oLabelinfoToRecinDB
            Dim t1 = t
            Dim _rec = (From c In Me.oLabel.LabelInfoCollection Where c.iD = t1).FirstOrDefault

            If Not _rec Is Nothing Then
                'проверка наличия в бд

                Dim _result = (oReadySampleDBContext.GetLabelInfoByID(_rec.iD)).FirstOrDefault
                'тут запрос в бд
                If Not _result Is Nothing Then
                    'в бд есть - обновим
                    Dim _result1 = (From c In oReadySampleDBContext.tb_labelInfo Where c.labelInfoID = _rec.iD Select c).FirstOrDefault
                    If Not _result1 Is Nothing Then
                        With _result1
                            .group = _rec.parentGroup
                            .lang = _rec.culture.Name
                            .nodeID = _rec.parentNodeID
                            .order = _rec.Order
                            .rootnode = _rec.rootnode
                            .treename = _rec.parentTreename
                            .value = _rec.Value
                        End With
                    End If

                Else
                    'запись в бд
                    Dim _new = Service.tb_labelInfo.Createtb_labelInfo(0, _rec.iD)
                    With _new
                        .group = _rec.parentGroup
                        .lang = _rec.culture.Name
                        .nodeID = _rec.parentNodeID
                        .order = _rec.Order
                        .rootnode = _rec.rootnode
                        .treename = _rec.parentTreename
                        .value = _rec.Value
                    End With
                    oReadySampleDBContext.tb_labelInfo.AddObject(_new)
                End If

            End If
            _txt += t & ChrW(13)
        Next

        Dim _st = oReadySampleDBContext.SaveChanges()


        Me.oLabelinfoToRecinDB.Clear()
        Me.btRecToDB.BackColor = Control.DefaultBackColor
        Me.MarkUnsavedLabelInDB()
        MsgBox("Записано записей " & _st, MsgBoxStyle.OkOnly)
    End Sub

    Private Sub MarkUnsavedLabelInDB()
        For Each t As DataGridViewRow In Me.DataGridView1.Rows
            If Me.oLabelinfoToRecinDB.Contains(t.DataBoundItem.id) Then
                t.DefaultCellStyle.BackColor = Color.Red
            Else
                t.DefaultCellStyle.BackColor = DefaultBackColor
            End If
        Next
    End Sub

    Private Sub cbxGetLabelInfoFromDB_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles cbxGetLabelInfoFromDB.CheckedChanged

        If cbxGetLabelInfoFromDB.Checked = True Then
            Me.btRecToDB.BackColor = Control.DefaultBackColor
        End If

        If Not Me.oLabel Is Nothing Then
            Me.oLabelinfoToRecinDB.Clear()
            Me.oLabel.LabelInfoCollection.Clear()
            Me.ReadLabelInfo(oCurrentCulture)
            Me.ClsLabelInfoBindingSource.DataSource = Me.oLabel.GetInfoByCulture(oCurrentCulture)
            Me.DataGridView1.Refresh()
            Me.MarkUnsavedLabelInDB()
        End If

    End Sub

    Private Sub cbxLabelXML_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles cbxLabelXML.CheckedChanged
        If cbxLabelXML.Checked Then
            cbxRawXMLView.Checked = False
        End If
        Me.BuildDescription(False)
    End Sub

    Private Class oCompar
        Implements IEqualityComparer(Of Service.pc_GetLabelsByIndexName_2_Result)

        Public Function Equals1(x As Service.pc_GetLabelsByIndexName_2_Result, y As Service.pc_GetLabelsByIndexName_2_Result) As Boolean Implements System.Collections.Generic.IEqualityComparer(Of Service.pc_GetLabelsByIndexName_2_Result).Equals
            If x Is y Then Return True
            If x Is Nothing OrElse y Is Nothing Then Return False

            If (x.LblID = y.LblID) Then Return True
            Return False
        End Function

        Public Function GetHashCode1(obj As Service.pc_GetLabelsByIndexName_2_Result) As Integer Implements System.Collections.Generic.IEqualityComparer(Of Service.pc_GetLabelsByIndexName_2_Result).GetHashCode
            If obj Is Nothing Then Return 0
            Return obj.LblID.GetHashCode
        End Function
    End Class


    Private Sub btSearchLabels_Click(sender As System.Object, e As System.EventArgs) Handles btSearchLabels.Click
        'тут предложим выбрать из БД имеющиеся этикетки для основного ключевого имени
        '
        Dim _comp As New oCompar
        Dim _KeyName = Me.Sample_nicknameTextBox.Text

        Dim _labelresult As New List(Of Service.pc_GetLabelsByIndexName_2_Result)
        'разберем строку на поиск +
        Dim _keyarr = _KeyName.Split("+".ToCharArray, StringSplitOptions.RemoveEmptyEntries)

        If _keyarr Is Nothing Then GoTo ex
        If _keyarr.Length = 0 Then GoTo ex

        For Each _key In _keyarr
            'ключ задан, запрос в БД
            Dim _result = (oReadySampleDBContext.pc_GetLabelsByIndexName_2(_key)).ToList
            'исключить повторения
            If _labelresult.Count > 0 Then
                Dim _sort = (_labelresult.Except(_result, _comp)).ToArray

                _labelresult.AddRange(_sort)
            Else
                _labelresult.AddRange(_result)
            End If

        Next

        If Not _labelresult Is Nothing AndAlso _labelresult.Count > 0 Then
            Me.cbSearchLabelsResult.Enabled = True
            'загрузить в список
            With Me.cbSearchLabelsResult
                .DataSource = _labelresult
                .AutoCompleteMode = AutoCompleteMode.SuggestAppend
                .AutoCompleteSource = AutoCompleteSource.ListItems
            End With
            'в value будет отображено локалити
            Me.cbSearchLabelsResult.DisplayMember = "value"
            'это labelID
            Me.cbSearchLabelsResult.ValueMember = "LblID"
            Me.btCreateDescription.Enabled = True

            Me.btSearchLabels.Text = "Искать этикетку в БД (" & Me.cbSearchLabelsResult.Items.Count & ")"
        Else
            'совпадений нет
            With Me.cbSearchLabelsResult
                .DataSource = Nothing
                .Items.Add("Для запрашиваемого имени этикеток нет")
                .SelectedIndex = 0
                .Enabled = False
            End With
            Me.btCreateDescription.Enabled = False
            Me.btSearchLabels.Text = "Искать этикетку в БД"
        End If
        Return

ex:
        MsgBox("Задайте короткое название, по нему будет найдена этикетка", vbCritical)
    End Sub


    Private Sub btCreateDescription_Click(sender As System.Object, e As System.EventArgs) Handles btCreateDescription.Click
        Dim _fm = New SplashScreen1
        _fm.Show()
        Application.DoEvents()
        'создать описание на основе выбранной этикетки
        If Me.cbSearchLabelsResult.SelectedIndex < 0 Then Return
        Dim _labelID As Integer = Me.cbSearchLabelsResult.SelectedItem.LblID
        ' тут восстановить из БД обьект лабела 
        Dim _label As clsLabel

        Dim _dblabel = (From c In oReadySampleDBContext.tb_label Where c.labelid = _labelID).FirstOrDefault


        If Not _dblabel Is Nothing Then
            _label = New clsLabel(_dblabel.labelid, _dblabel.group, Globalization.CultureInfo.CreateSpecificCulture(_dblabel.lang))
            _dblabel.tb_node.Load()
            Dim _ncc As New List(Of clsLabel.clsNode)

            For Each _dbNode In _dblabel.tb_node
                _dbNode.tb_nodeid.Load()

                Dim _labelNodeIDlist = (From c1 In _dbNode.tb_nodeid Select New clsLabel.strNodeID With {.NodeID = c1.nodeid, .LabelinfoID = c1.labelinfoid}).ToList

                Dim _labelnode = New clsLabel.clsNode With {.Order = _dbNode.order, .Rootnode = _dbNode.rootnode, .Treename = _dbNode.treename, .Value = _dbNode.value, .NodeIDCollection = _labelNodeIDlist}
                _ncc.Add(_labelnode)
            Next

            _label.SetNodeCollection(_ncc)

            Dim _manager = clsTreeService.CreateInstance(_label.group)
            Dim _descr As Xml.Linq.XElement
            Dim _descr1 As Xml.Linq.XElement
            Dim _fullDescr As Xml.Linq.XElement = clsTreeService.GetRootDescriptionTag
            For Each k In _label.NodeCollection
                Dim _listNodeID = (From c1 In k.NodeIDCollection Select c1).ToList
                For Each t In _listNodeID
                    _descr = _manager.GetDescriptionElementByNodeID(t.NodeID, k.Treename, EnglishCulture)
                    _descr1 = _manager.GetDescriptionElementByNodeID(t.NodeID, k.Treename, RussianCulture)
                    _fullDescr.Add(_descr)
                    _fullDescr.Add(_descr1)
                Next
            Next

            If Me.oCurrentXMLDescription Is Nothing Then
                Me.oCurrentXMLDescription = _fullDescr
            Else
                clsTreeService.JoinDescriptionElements(Me.oCurrentXMLDescription, _fullDescr)
            End If

            Me.cbxGetLabelInfoFromDB.Checked = True
            Me.btToSite.Enabled = True
            Me.oIndexlbElements = -1
            Me.BuildDescription(True)

            'получить название
            Dim _nm = (From c In Me.oCurrentElementsCollection Where c.Culture.Name = Me.oCurrentCulture.Name AndAlso c.ElementName.ToLower.StartsWith("systema") Select c.Value).FirstOrDefault

            If Me.Sample_main_speciesComboBox.Text = "" Then
                Me.Sample_main_speciesComboBox.Text = _nm
                Sample_main_speciesComboBox_LostFocus(sender, e)
            End If

        End If

        _fm.Hide()
    End Sub

    Private Sub btSaveLabelToDB_Click(sender As System.Object, e As System.EventArgs) Handles btSaveLabelToDB.Click
        If Me.oLabel Is Nothing Then Exit Sub
        'сохранить в БД
        Dim _txt As String = ""
        For Each lbl In Me.oLabel.LabelCollection
            Dim _label = lbl

            'проверка наличия в бд. для индексного имени будет использовано значение короткого имени
            Dim _result = (oReadySampleDBContext.pc_GetLabelsByIndexName(Me.Sample_nicknameTextBox.Text)).FirstOrDefault
            'тут запрос в бд
            If Not _result Is Nothing Then
                'в бд есть - обновим
                Dim _result1 = (From c In oReadySampleDBContext.tb_label Where c.labelid = _label.iD Select c).FirstOrDefault
                If Not _result1 Is Nothing Then
                    With _result1
                        MsgBox("Обновление этикеток в БД пока не доступно", vbCritical)
                        Return
                    End With
                End If

            Else
                'запись в бд
                Dim _new = Service.tb_label.Createtb_label(0, _label.iD)
                With _new
                    .group = _label.group
                    .IndexName = Me.Sample_nicknameTextBox.Text
                    .lang = _label.culture.Name
                    .labelid = _label.iD
                    'node
                    For Each t In _label.NodeCollection
                        Dim _new1 = Service.tb_node.Createtb_node(0, 0)
                        With _new1
                            .combined = t.Combined
                            .order = t.Order
                            .rootnode = t.Rootnode
                            .treename = t.Treename
                            .value = t.Value
                            For Each r In t.NodeIDCollection
                                Dim _new2 = Service.tb_nodeid.Createtb_nodeid(0, 0)
                                With _new2
                                    .labelinfoid = r.LabelinfoID
                                    .nodeid = r.NodeID
                                End With
                                _new1.tb_nodeid.Add(_new2)
                            Next
                        End With
                        _new.tb_node.Add(_new1)
                        _txt += _label.iD & ChrW(13)
                    Next
                End With
                oReadySampleDBContext.tb_label.AddObject(_new)


                Dim _st = oReadySampleDBContext.SaveChanges()


                ' Me.oLabelinfoToRecinDB.Clear()
                ' Me.btRecToDB.BackColor = Control.DefaultBackColor
                ' Me.MarkUnsavedLabelInDB()
                MsgBox(_txt & ChrW(13) & "status: " & _st, MsgBoxStyle.OkOnly)
            End If
        Next
    End Sub





    Private Sub Sample_nicknameTextBox_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles Sample_nicknameTextBox.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Me.btSearchLabels_Click(sender, e)
        End If
    End Sub


    Private Sub cbSearchLabelsResult_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbSearchLabelsResult.SelectedIndexChanged
        If Not TypeOf (Me.cbSearchLabelsResult.SelectedItem) Is Service.pc_GetLabelsByIndexName_2_Result Then
            Me.oTipTool_DBlabels.SetToolTip(Me.cbSearchLabelsResult, Me.cbSearchLabelsResult.Text)
            Return
        End If

        If Me.cbSearchLabelsResult.SelectedIndex >= 0 Then
            Me.oTipTool_DBlabels.SetToolTip(Me.cbSearchLabelsResult, Me.cbSearchLabelsResult.SelectedItem.value.ToString)
        End If
    End Sub



    Private oLabelImageList As List(Of KeyValuePair(Of Image, SizeF))


    Private Sub tsmiUp_Click(sender As System.Object, e As System.EventArgs) Handles tsmiUp.Click
        If oClickedLabelInfo Is Nothing Then Return
        If oClickedLabelInfo.Order = oLabel.LabelInfoCollection.Count Then Return
        Dim _oldOrder = oClickedLabelInfo.Order
        oClickedLabelInfo.Order += 1
        'передвинуть вниз такую же
        Dim _res = (From c In Me.oLabel.LabelInfoCollection Where c.Order = _oldOrder Select c).ToList
        If _res.Count > 0 Then
            If _res.First.Order > 0 Then
                _res.First.Order = _oldOrder
            End If
        End If

        Me.DataGridView1.Refresh()
        Me.BuildDescription(False)
    End Sub

    Private Sub tsmiDown_Click(sender As System.Object, e As System.EventArgs) Handles tsmiDown.Click
        'уменьшть индекс
        If oClickedLabelInfo Is Nothing Then Return
        If oClickedLabelInfo.Order <= 1 Then Return
        Dim _oldOrder = oClickedLabelInfo.Order
        oClickedLabelInfo.Order -= 1
        'передвинуть вверх такую же
        Dim _res = (From c In Me.oLabel.LabelInfoCollection Where c.Order = _oldOrder Select c).ToList
        If _res.Count > 0 Then
            If _res.First.Order < oLabel.LabelInfoCollection.Count Then
                _res.First.Order = _oldOrder
            End If
        End If

        Me.DataGridView1.Refresh()
        Me.BuildDescription(False)
    End Sub




    Private Sub tbVolumeOffset_TextChanged(sender As System.Object, e As System.EventArgs) Handles tbVolumeOffset.TextChanged
        Box_Calculate()
    End Sub




    Private Sub btDrawLabel_Click(sender As System.Object, e As System.EventArgs) Handles btDrawLabel.Click
        Dim _result As New List(Of clsApplicationTypes.clsSampleNumber.strGoodInfo)
        If Not clsApplicationTypes.DelegatStoreMCGoodInfo Is Nothing Then
            _result = clsApplicationTypes.DelegatStoreMCGoodInfo.Invoke(oSampleNumber.ShotCode)
        End If

        Dim _name As String = Me.Sample_main_speciesComboBox.Text
        Dim _price As String = ""
        Select Case _result.Count
            Case 0

            Case 1
                'из МС
                _name = _result(0).Name
                _price = _result(0).RetailPrice & _result(0).RetailCurrency
            Case Else

        End Select
        If Not Me.cbPrintPrice.Checked Then
            _price = ""
        End If
        Dim _img = clsApplicationTypes.CreateEANLabel(oSampleNumber, _name, _price)
        UcGoodLabel1.AddLabel(_img)

    End Sub




    Private Sub btQuickPrint_Click(sender As System.Object, e As System.EventArgs) Handles btQuickPrint.Click


        Dim _price As String = ""
        Dim _name As String = Me.Sample_main_speciesComboBox.Text

        If Not clsApplicationTypes.DelegatStoreMCGoodInfo Is Nothing Then
            Dim _result = clsApplicationTypes.DelegatStoreMCGoodInfo.Invoke(oSampleNumber.ShotCode)
            Select Case _result.Count
                Case 0

                Case 1
                    'из МС
                    _name = _result(0).Name
                    _price = _result(0).RetailPrice & _result(0).RetailCurrencySymbol
                Case Else
            End Select

            If Not Me.cbPrintPrice.Checked Then
                _price = ""
            End If
        End If


        Dim _img = clsApplicationTypes.CreateEANLabel(oSampleNumber, _name, _price)
        Dim _lbl = clsApplicationTypes.CreatePrintableLabel(_img)
        Dim _pd = Service.clsApplicationTypes.PrintLabel({_lbl}.ToList, oNeedResetPrinters, False)
        If Not _pd Is Nothing Then
            oNeedResetPrinters = False
            _pd.Print()
        Else
            MsgBox("Не удалось напечатать документ", vbCritical)
        End If

    End Sub

    Private Sub btGetNumber_Click(sender As System.Object, e As System.EventArgs) Handles btGetNumber.Click
        Me.oTabCreated = False
        Dim _series As String = "802"

        If clsApplicationTypes.GetAccess("Изменение серии добавляемого номера") Then
            _series = InputBox("Введите серию", "Серия для нового номера", _series)
            If _series = "" Then
                MsgBox("Необходимо ввести серию", vbCritical)
                Return
            End If
        End If

        'показат сплеш
        Dim _sp As New SplashScreen1
        _sp.Show()
        Application.DoEvents()
nxnr:
        Dim _res = Service.clsApplicationTypes.DelegatStoreGetNewNumber.Invoke(_series)
        If _res.Length > 0 Then
            'проверка фото
            If Service.clsApplicationTypes.DelegatStoreCheckImages Is Nothing Then
                'проверить фото невозможно
                _sp.Hide()
                MsgBox("Невозможно проверить фото для номера " & _res & "!", vbCritical)
                Return
            Else
                Dim _result = Service.clsApplicationTypes.DelegatStoreCheckImages.Invoke(_res)
                Select Case _result
                    Case 1
                        'фотки есть - получить следующий номер
                        MsgBox("Для номера " & _res & " есть фото, будет выдан следующий номер.", vbInformation)
                        GoTo nxnr
                    Case 0
                        'фоток нет, все ок
                    Case -1
                        'номер неверен, внутренняя ошибка
                        _sp.Hide()
                        MsgBox("Номер неверен, внутренняя ошибка!", vbCritical)
                        Return
                    Case -2
                        'нет доступа к БД, внутренняя ошибка
                        _sp.Hide()
                        MsgBox("Нет доступа к БД, внутренняя ошибка!", vbCritical)
                        Return
                End Select
            End If
            _sp.Hide()
            Me.SampleNumberTextBox.Text = _res

            My.Computer.Clipboard.SetText(_res)

            Me.btSearchInfo_Click(sender, e)
        Else
            _sp.Hide()
            MsgBox("Не удалось получить номер, внутренняя ошибка!", vbCritical)
        End If
    End Sub






    Private Sub SampleNumberLabel_Click(sender As System.Object, e As System.EventArgs) Handles SampleNumberLabel.MouseClick
        Me.SampleNumberTextBox.Text = ""
        clsPhotoService.GetDigiKey.connect(SampleNumberTextBox)
    End Sub

    Private Sub Sample_net_weightLabel_Click(sender As System.Object, e As System.EventArgs) Handles Sample_net_weightLabel.MouseClick
        Me.Sample_net_weightTextBox.Text = ""
        clsPhotoService.GetDigiKey.connect(Me.Sample_net_weightTextBox)
    End Sub

    Private Sub Sample_lengthLabel_Click(sender As System.Object, e As System.EventArgs) Handles Sample_lengthLabel.MouseClick
        Me.Sample_lengthTextBox.Text = ""
        clsPhotoService.GetDigiKey.connect(Me.Sample_lengthTextBox)
    End Sub

    Private Sub Sample_widthLabel_Click(sender As System.Object, e As System.EventArgs) Handles Sample_widthLabel.MouseClick
        Me.Sample_widthTextBox.Text = ""
        clsPhotoService.GetDigiKey.connect(Me.Sample_widthTextBox)
    End Sub

    Private Sub Sample_heightLabel_Click(sender As System.Object, e As System.EventArgs) Handles Sample_heightLabel.MouseClick
        Me.Sample_heightTextBox.Text = ""
        clsPhotoService.GetDigiKey.connect(Me.Sample_heightTextBox)
    End Sub

    ''' <summary>
    ''' запись названия из МС
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btFromMoySclad_Click(sender As System.Object, e As System.EventArgs) Handles btFromMoySclad.Click

        If clsApplicationTypes.DelegatStoreMCGoodInfo Is Nothing Then
            MsgBox("Мой склад еще загружается, попробуйте через несколько минут", vbCritical)
            Return
        End If

        Dim _result = clsApplicationTypes.DelegatStoreMCGoodInfo.Invoke(oSampleNumber.ShotCode)
        If _result.Count > 0 AndAlso _result(0).LoadStatus > 0 Then
            clsApplicationTypes.BeepYES()
            If _result(0).Weight > 0 Then
                Me.Sample_net_weightTextBox.Text = _result(0).Weight
            End If
        Else
            clsApplicationTypes.BeepNOT()
        End If
        Dim _old As String = Me.Sample_main_speciesComboBox.Text
        'загрузим имена, кроме совпадающих
        Dim _nmresult = (From c In _result Where (Not c.Name = _old) Select c.Name).ToArray
        'загрузка списка
        With Me.Sample_main_speciesComboBox
            .AutoCompleteMode = AutoCompleteMode.SuggestAppend
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .Items.Clear()
            If Not _old = "" Then
                .Items.Add(_old)
            End If
            .Items.AddRange(_nmresult)

            If .Items.Count > 0 Then
                If .Items.Count > 1 Then
                    .SelectedIndex = 1
                Else
                    .SelectedIndex = 0
                End If

            End If
            .Refresh()
            .Tag = _result
        End With


        Me.UcFossilTabPage1.FossilNamesSource = _nmresult

    End Sub









    Private oLabelImagesWithoutFilter As New List(Of Image)





    Private Sub cbxRewritefile_CheckedChanged(sender As Object, e As EventArgs) Handles cbxGetXMLFromDB.CheckedChanged
        Me.btToSite.Enabled = True
    End Sub


#Region "рисование на фото"

    ''' <summary>
    ''' это вместо перехвата события панели - прокрутка мышки
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Form_MouseWheel(sender As Object, e As MouseEventArgs) Handles tpPhoto.MouseWheel
        'перевести фокус на ЭУ фото
        Me.UcPhotoManager1.Focus()
    End Sub

#End Region

    Private Sub cbxLoadAllNames_CheckedChanged(sender As Object, e As EventArgs) Handles cbxLoadAllNames.CheckedChanged
        Select Case cbxLoadAllNames.Checked
            Case True
                'загрузить все доступные названия
                Me.Sample_main_speciesComboBox.Items.Clear()
                'загрузка списка
                Dim _list = clsApplicationTypes.AllCurrentNames

                With Me.Sample_main_speciesComboBox
                    Me.Sample_main_speciesComboBox.Items.AddRange(_list)
                    .AutoCompleteMode = AutoCompleteMode.SuggestAppend
                    .AutoCompleteSource = AutoCompleteSource.ListItems
                End With
                Me.UcFossilTabPage1.FossilNamesSource = _list
                Me.lbTreeName.Text = Trilbone.clsTreeService.CurrentGroupName
                '    Me.lbTreeName.Tag = Trilbone.clsTreeService.CurrentFilePath
                Me.cbMaterial.Enabled = False
                Me.cbListOfTree.Enabled = False
                cbxLoadAllNames.Text = "все(" & _list.Count & ")"
            Case Else
                Me.Sample_main_speciesComboBox.Items.Clear()
                Me.cbMaterial.Enabled = True
                Me.cbListOfTree.Enabled = True
                cbxLoadAllNames.Text = "все"
                cbListOfTree_SelectedIndexChanged(sender, e)
                cbMaterial_SelectedIndexChanged(sender, e)

        End Select
    End Sub



    Private Sub tpPhoto_Click(sender As Object, e As EventArgs) Handles tpPhoto.Click
        tpPhoto.Focus()
    End Sub

    Private Sub btMainName_Click(sender As Object, e As EventArgs) Handles btMainName.Click
        'длина первой фоссилии - получаем по ссылке
        Dim _firstLen As Decimal
        Dim _fossList = Me.UcFossilTabPage1.GetFossilsList(_firstLen)
        If _fossList.Count = 0 Then
            _fossList.Add(Sample_main_speciesComboBox.Text)
        End If
        'для более одной фоссилии
        If _fossList.Count > 1 Then
            'имя (имена)
            Dim _name As String = clsApplicationTypes.FossilNamesParser(_fossList.ToArray)
            Me.Sample_main_speciesComboBox.Text = _name
            clsApplicationTypes.BeepYES()
        End If
        '------------------
        Dim _data As String = Me.Sample_main_speciesComboBox.Text
        Try
            My.Computer.Clipboard.Clear()
            My.Computer.Clipboard.SetText(_data, TextDataFormat.Text)
        Catch ex As Exception
            MsgBox("Ошибка при помещении данных в буфер обмена.", vbCritical)
        End Try
        '-----------------
    End Sub







    ''' <summary>
    ''' запомнить цену в МС
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub UserControlMC1_PriceSet(sender As Object, e As UserControlMC.PriceSetEventArgs) Handles UserControlMC1.PriceSet
        Dim _status As Integer
        Dim _result = clsApplicationTypes.SampleDataObject.GetSampleOnSale(oSampleNumber, _status, True)
        If _status > 0 Then
            _result.BasePrice = e.Price
            ' _result.CurrencyName = e.Currency
            BeepYES()
        End If
    End Sub
    ''' <summary>
    ''' вес в МС
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btAddWeightToMC_Click(sender As Object, e As EventArgs) Handles btAddWeightToMC.Click
        Me.UserControlMC1.SampleWeight = clsApplicationTypes.ReplaceDecimalSplitter(Me.Sample_net_weightTextBox)
    End Sub
    ''' <summary>
    ''' Название в МС
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btNameToMC_Click(sender As Object, e As EventArgs) Handles btNameToMC.Click
        Me.UserControlMC1.SampleName = Me.Sample_main_speciesComboBox.Text
    End Sub



    Private Sub btReadRFID_Click(sender As Object, e As EventArgs) Handles btReadRFID.Click
        Dim _rfid = clsApplicationTypes.RFIDmanager

        If _rfid.IsScannerMode Then
            Return
        End If
        'убедиться в присутствии метки
        _rfid.Read()
        'тут возможно надо вычесть 1, чтобы получить корректное CardCount/ Проверить на карте.
        Select Case _rfid.CardInfo.CardCount
            Case 0
                MsgBox("Нет метки или она не читается", vbCritical)
            Case Else
                If Not String.IsNullOrEmpty(_rfid.FirstCardData) Then
                    Me.SampleNumberTextBox.Text = _rfid.FirstCardData
                    Me.btSearchInfo_Click(sender, e)
                Else
                    MsgBox("Метка не читается. Не подключен ридер? Если ридер подключен, то нажми Restart RFID и попробуй заново.", vbInformation)
                End If

                'Case Else
                '    MsgBox("Оставте только одну метку, множественная запись не поддерживается", vbCritical)
        End Select
    End Sub


    Private Sub cbReadyForSale_CheckedChanged(sender As Object, e As EventArgs) Handles cbReadyForSale.CheckedChanged
        If oInit Then Return


        If cbReadyForSale.Checked Then
            Select Case MsgBox("Подтверждаете готовность описания и заполнение всех полей образца для выставления на сайт?", vbYesNo)
                Case MsgBoxResult.No
                    Return
            End Select

            Dim _result As Integer
            Dim _sdo = clsApplicationTypes.SampleDataObject.GetSampleOnSale(oSampleNumber, _result, CreateIfNotExist:=True)
            If Not _sdo Is Nothing AndAlso _result > 0 Then
                With _sdo
                    .OnSaleDate = Date.Now
                    .OnSaleCreator = clsApplicationTypes.CurrentUser.UserShotName
                    .OnSaleFlag = True
                End With
                If clsApplicationTypes.SampleDataObject.SaveReadySampleContext > 0 Then
                    Me.lblOnSaleCreator.Text = clsApplicationTypes.CurrentUser.UserShotName
                End If
            End If
        Else
            Select Case MsgBox("Убрать образец из готовых для выставления?", vbYesNo)
                Case MsgBoxResult.No
                    Return
            End Select
            Dim _result As Integer
            Dim _sdo = clsApplicationTypes.SampleDataObject.GetSampleOnSale(oSampleNumber, _result, CreateIfNotExist:=True)
            If Not _sdo Is Nothing AndAlso _result > 0 Then
                With _sdo
                    .OnSaleDate = Date.Now
                    .OnSaleCreator = clsApplicationTypes.CurrentUser.UserShotName
                    .OnSaleFlag = False
                End With
                If clsApplicationTypes.SampleDataObject.SaveReadySampleContext > 0 Then
                    Me.lblOnSaleCreator.Text = "не готов"
                End If
            End If
        End If
    End Sub

    Private Sub tpctlMain_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tpctlMain.SelectedIndexChanged
        If tpctlMain.SelectedTab Is Me.tpPhoto Then
            'вкладка ФОТО 
            'Загрузить фото в панель
            If oImageLoaded = False Then
                Me.UcPhotoManager1.LoadImages(oSampleNumber, clsFilesSources.Arhive, AddressOf GetNumberOfFossil)
            End If
            oImageLoaded = True
        End If

        If tpctlMain.SelectedTab Is Me.tpMoySklad Then
            'вкладка Мой склад 
            Me.UC_siteCheck1.SampleNumber = oSampleNumber.EAN13
            Me.UserControlMC1.SampleNumber = oSampleNumber
        End If

        If tpctlMain.SelectedTab Is Me.tpRFID Then
            'вкладка RFID
            Me.UC_rfid1.SampleNumber = oSampleNumber.ShotCode
        End If

        If tpctlMain.SelectedTab Is Me.tpTrilboneInfo Then
            'вкладка Info
            Me.Uc_trilbone_history1.SampleNumber(False) = oSampleNumber.EAN13
        End If

        If tpctlMain.SelectedTab Is Me.tpPakage Then
            'вкладка УПАКОВКИ
            Box_Calculate()
        End If
    End Sub


    Private Sub btShowMap_Click(sender As Object, e As EventArgs) Handles btShowMap.Click
        Dim _result As Integer
        Dim _sdo = clsApplicationTypes.SampleDataObject.GetSampleOnSale(oSampleNumber, _result, CreateIfNotExist:=True)

        If _result < 1 OrElse _sdo Is Nothing Then
            MsgBox("Невозможно извлечь карту образца из БД. Неудачная попытка запросить обьект с сервера.", vbCritical)
            Return
        End If
        If Not _sdo.SampleXMLFile = "" Then
            'в БД есть сохраненная карта XML

            Dim _html = clsApplicationTypes.DelegateStoreGetTransform.Invoke(_sdo.SampleXMLFile, emTemplateType.Site_mail_template, "")
            Dim _caption = Me.Sample_main_speciesComboBox.Text
            Dim _catname = String.Format("{0} {1}", clsApplicationTypes.RejectSkobki(Me.Sample_main_speciesComboBox.Text), Me.oSampleNumber.ShotCode)
            Dim _fm = clsApplicationTypes.Browser(_html, _caption, _catname)

            _fm.ShowDialog()

        Else
            MsgBox("Карты образца в БД нет", vbInformation)
        End If

    End Sub

    Private Sub UcPhotoManager1_PhotoListChanged(sender As Object, e As EventArgs) Handles UcPhotoManager1.PhotoListChanged
        Me.ReadPhotos()
    End Sub

    Private Sub btSizeString_Click(sender As Object, e As EventArgs) Handles btSizeString.Click
        Dim _out As String = ""
        Select Case Me.rbEnglish.Checked
            Case False
                _out = String.Format("Размер образца: {0}х{1}х{2} см.  Вес образца: {3} кг.", clsApplicationTypes.ReplaceDecimalSplitter(Me.Sample_lengthTextBox).ToString("###.0"), clsApplicationTypes.ReplaceDecimalSplitter(Me.Sample_widthTextBox).ToString("###.0"), clsApplicationTypes.ReplaceDecimalSplitter(Me.Sample_heightTextBox).ToString("###.0"), clsApplicationTypes.ReplaceDecimalSplitter(Me.Sample_net_weightTextBox).ToString("##0.000"))

            Case True
                _out = String.Format("Speciment size: {0}х{1}х{2} cm.  Speciment weight: {3} kg.", clsApplicationTypes.ReplaceDecimalSplitter(Me.Sample_lengthTextBox).ToString("###.0"), clsApplicationTypes.ReplaceDecimalSplitter(Me.Sample_widthTextBox).ToString("###.0"), clsApplicationTypes.ReplaceDecimalSplitter(Me.Sample_heightTextBox).ToString("###.0"), clsApplicationTypes.ReplaceDecimalSplitter(Me.Sample_net_weightTextBox).ToString("##0.000"))

        End Select
        Try
            My.Computer.Clipboard.SetText(_out)
            clsApplicationTypes.BeepYES()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub UcPhotoManager1_Load(sender As Object, e As EventArgs) Handles UcPhotoManager1.Load

    End Sub

    Private Sub Sample_main_speciesComboBox_MouseClick(sender As Object, e As MouseEventArgs) Handles Sample_main_speciesComboBox.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim _namePart As String
            ' Dim _sm As clsApplicationTypes.clsSampleNumber = If(e.RowIndex >= 0, nop_DataGridView.Rows(e.RowIndex).Cells(oSKUColumnIndex).Tag, Nothing)
            'клиент 
            ' Dim _client = dgv_SampleResultByName.Columns(e.ColumnIndex).HeaderText.Trim.ToLower
            'берем часть имени из заголовка
            _namePart = Me.Sample_main_speciesComboBox.Text.Trim
            'If Not String.IsNullOrEmpty(Me.Sample_main_speciesComboBox.Text) Then
            '    _namePart = Me.Sample_main_speciesComboBox.Text.Trim
            'Else
            '    'или из значения ячейки
            '    _namePart = dgv_SampleResultByName.Rows(If(e.RowIndex < 0, 0, e.RowIndex)).Cells(2).Value.ToString.Split(" ").FirstOrDefault
            'End If

            If String.IsNullOrEmpty(_namePart) Then Return

            _namePart = _namePart.ToLower()

            Dim _fossilsize As Decimal = 0 ' Decimal.Parse(dgv_SampleResultByName.Rows(If(e.RowIndex < 0, 0, e.RowIndex)).Cells(4).Value)
            'Me.oSplashscreen.Show()
            'получить обьект-источник данных

            Dim _result = clsSellInfo.GetStatistic(_namePart, "", _fossilsize)
            'Me.oSplashscreen.Hide()


            Me.ContextMenuStrip1.Items.Clear()

            If _result.Count > 0 Then
                Me.ContextMenuStrip1.Items.AddRange(_result.GetMenuItems)
                Me.ContextMenuStrip1.Show(Sample_main_speciesComboBox.PointToScreen(e.Location))
            Else
                MsgBox(String.Format("По образцам {0} размером около {1} данных нет", _namePart, _fossilsize), vbInformation)
            End If

        End If
    End Sub

    Private Sub Uc_trilbone_history1_Load(sender As Object, e As EventArgs) Handles Uc_trilbone_history1.Load

    End Sub

    Private Sub ContextMenuStrip1_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening

    End Sub

    Private Sub btCopyEAN_Click(sender As Object, e As EventArgs) Handles btCopyEAN.Click

        If Not Me.oSampleNumber Is Nothing Then
            '------------------
            Dim _data As String = Me.oSampleNumber.EAN13
            Try
                My.Computer.Clipboard.Clear()
                My.Computer.Clipboard.SetText(_data)
            Catch ex As Exception
                MsgBox("Ошибка при помещении данных в буфер обмена.", vbCritical)
            End Try
            '-----------------
        Else
            MsgBox("Не задан номер!", vbCritical)
        End If
    End Sub

    Private Sub SampleNumberTextBox_TextChanged(sender As Object, e As EventArgs) Handles SampleNumberTextBox.TextChanged

    End Sub

    Private Sub btImportData_Click(sender As Object, e As EventArgs) Handles btImportData.Click
        Dim _buff As String
        If My.Computer.Clipboard.ContainsText Then
            _buff = My.Computer.Clipboard.GetText

            Dim _manager = New Service.clsImportManager
            Dim _data = _manager.Import(_buff)
            If _data.Count = 0 Then Return

            'TODO выбрать поставщика
            Dim _supp As New clsImportManager.strDataImportIndividual
            With _supp
                .SupplierName = "Yakov"
                .datalinesplitter = {":"}
                .fossilcount = 1
                .fossilSizesplitter = {"x"}
                '.fossilsizesstartlineindex = 4
                .fossilsizesCaption = "Trilobite"
                .fossilSizeUnit = clsImportManager.strDataImportIndividual.emSizeUnits.cm
                .headerlineindex = 0
                .priceLineIndex = 0
                .pricesplitter = {"-"}
                '.stoneSizelineindex = 5
                .stoneSizelineCaption = "Stone"
                .stoneSizesplitter = {"x"}
                .stoneSizeUnit = clsImportManager.strDataImportIndividual.emSizeUnits.cm

                '.Weightlineindex = 6
                .WeightlineCaption = "Weight"
                .WeightUnit = clsImportManager.strDataImportIndividual.emWeightUnits.g
            End With

            If _manager.ParseIndividual(_supp) Then
                'заполнить форму данными из _manager
                With _manager
                    Me.Sample_main_speciesComboBox.Text = .Header
                    Me.Sample_net_weightTextBox.Text = If(_supp.WeightUnit = clsImportManager.strDataImportIndividual.emWeightUnits.g, (clsApplicationTypes.ReplaceDecimalSplitter(.Weight) / 1000).ToString, clsApplicationTypes.ReplaceDecimalSplitter(.Weight).ToString)
                    If Not .StoneSizes Is Nothing Then
                        Select Case .StoneSizes.Count
                            Case 1
                                Me.Sample_lengthTextBox.Text = clsApplicationTypes.ReplaceDecimalSplitter(.StoneSizes(0)).ToString
                            Case 2
                                Me.Sample_lengthTextBox.Text = clsApplicationTypes.ReplaceDecimalSplitter(.StoneSizes(0)).ToString
                                Me.Sample_heightTextBox.Text = clsApplicationTypes.ReplaceDecimalSplitter(.StoneSizes(1)).ToString
                            Case 3
                                Me.Sample_lengthTextBox.Text = clsApplicationTypes.ReplaceDecimalSplitter(.StoneSizes(0)).ToString
                                Me.Sample_heightTextBox.Text = clsApplicationTypes.ReplaceDecimalSplitter(.StoneSizes(1)).ToString
                                Me.Sample_widthTextBox.Text = clsApplicationTypes.ReplaceDecimalSplitter(.StoneSizes(2)).ToString
                        End Select
                    End If

                    If Not .FossilSizes Is Nothing Then
                        Dim _ln = New List(Of tb_Samples_Fossils)

                        For Each t In .FossilSizes
                            Dim _lg As Decimal = 0
                            Dim _wd As Decimal = 0
                            Dim _hd As Decimal = 0
                            If Not t.Value Is Nothing Then
                                Select Case t.Value.Count
                                    Case 1
                                        _lg = clsApplicationTypes.ReplaceDecimalSplitter(t.Value(0))
                                    Case 2
                                        _lg = clsApplicationTypes.ReplaceDecimalSplitter(t.Value(0))
                                        _wd = clsApplicationTypes.ReplaceDecimalSplitter(t.Value(1))
                                    Case 3
                                        _lg = clsApplicationTypes.ReplaceDecimalSplitter(t.Value(0))

                                        _wd = clsApplicationTypes.ReplaceDecimalSplitter(t.Value(1))
                                        _hd = clsApplicationTypes.ReplaceDecimalSplitter(t.Value(2))
                                End Select
                            End If

                            Me.AddNewFossil(Me.UcFossilTabPage1.FossilCount + 1, t.Key, _lg, _wd, _hd)

                            Me.CreateFossilTab(t.Key, Me.UcFossilTabPage1.FossilCount + 1)
                        Next
                    End If

                End With
            End If

            Me.NameAccepting(_manager.Header)


        End If
    End Sub
End Class

