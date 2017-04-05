Imports System.Globalization.CultureInfo
Imports System.Xml.Linq
Imports System.Drawing
Imports System.Windows.Forms
Imports Service
Imports Service.clsApplicationTypes
Imports ModuleWebBrowser
Imports Service.Catalog
Public Class fmCreateMAP
#Region "определения"

    'коллекция сохраненных карт. ГДЕ ХРАНИМ?
    Private oStoredMap As New List(Of CATALOGELEMENTMAP)
    'коллекция выбранных карт. (свой список для каждого элемента описания)
    'Private oAddedMaps As New Dictionary(Of CATALOGSAMPLEELEMENT, CATALOGELEMENTMAP)
    'культура просмотра
    'Private oCulture As Globalization.CultureInfo = clsTreeService.EnglishCulture
    'текущий выбранный элемент описания
    'Private oCurrentDescriptionElement As KeyValuePair(Of CATALOGSAMPLEELEMENT, String)
    'загруженное описание
    'Private oLoadDescription As List(Of clsTreeService.clsDescriptionElement)

    Private oCurrentCatalogSample As CATALOGSAMPLE

    'эти переменные меняются при смене вкладок!
    'коллекция текущих слоев
    Private oCurrentOverLayCollection_tab1 As New List(Of CATALOGSAMPLEMAPOVERLAY)
    'коллекция текущих слоев
    Private oCurrentOverLayCollection_tab2 As New List(Of CATALOGSAMPLEMAPOVERLAY)
    'текущее изображение карты
    Private oCurrentMapImage As Image
    'текущее изображение слоя
    Private oCurentOverlayImage As Image
    'текущий прямоугольник отображения слоя
    Private oCurrentOverlayRectangle As Rectangle
    'пропорция вывода в файл
    Dim oKoeff_X As Single
    Dim oKoeff_Y As Single

    Private oOffsetMode As Boolean

    Private oimgColl As New Dictionary(Of Integer, Image)
    Private oNewIndex As Integer
    ' Private oCurrentTmpHtmlPath As String
    Private oManager As clsTemplateManager
    Private oShowAllOverlays As Boolean

    Public Event evAcceptChanges(sender As Object, e As Service.Catalog.CATALOGSAMPLE.clsCatalogSampleChangedEventArgs)

    'Public Class clsCatalogSampleChangedEventArgs
    '    Inherits EventArgs

    '    Public ChangedCatalogSample As CATALOGSAMPLE

    'End Class

    Friend Class clsSaveMapEventArgs
        Inherits EventArgs
        Public MapToSave As List(Of CATALOGELEMENTMAP)
    End Class

    Private oTemplateName As String

#End Region
#Region "Конструкторы и инициализация"
    Public Sub New()
        ' Этот вызов является обязательным для конструктора.
        InitializeComponent()
        Me.StartPosition = FormStartPosition.CenterParent
        Me.oCurrentCatalogSample = CATALOGSAMPLE.CreateInstance("", emCatalogFolderType.shot)
        init("")
    End Sub
    Public Sub New(sample As CATALOGSAMPLE, templateName As String)
        InitializeComponent()
        Me.StartPosition = FormStartPosition.CenterParent
        Me.oCurrentCatalogSample = sample
        init(templateName)
    End Sub

    Private Sub init(templateName As String)

        Me.oManager = New clsTemplateManager
        Dim _list = Me.oManager.TemplateNamesList

        'установка шаблона xslt
        Me.cbTemplates.DataSource = _list
        If String.IsNullOrEmpty(templateName) Then
            Me.cbTemplates.SelectedIndex = clsApplicationTypes.MainXMLTemplateIndex
            oTemplateName = Me.cbTemplates.SelectedItem
            'Me.cbTemplates.SelectedItem = _list.Find(Function(x) x.ToLower.Contains("mail")).FirstOrDefault
        Else
            oTemplateName = templateName
            Me.cbTemplates.SelectedItem = oTemplateName
        End If

        Me.WebBrowser1.Visible = False


        'загрузить имеющиеся XML карты
        Me.oStoredMap.AddRange(oManager.LoadMaps)

        'oCurrentTmpHtmlPath = My.Computer.FileSystem.GetTempFileName
        'oCurrentTmpHtmlPath = IO.Path.Combine(IO.Path.GetDirectoryName(oCurrentTmpHtmlPath), oCurrentCatalogSample.bar & "-tmp" & ".html")

        'добавим карты
        'привяжем
        Me.bs_MAP.DataSource = oStoredMap
        Me.bs_overlay.DataSource = oCurrentOverLayCollection_tab1
        Me.bs_selectedOverlay.DataSource = oCurrentOverLayCollection_tab2
        Me.bs_Description.DataSource = oCurrentCatalogSample.DATA

        Do
            If CType(Me.bs_Description.Current, CATALOGSAMPLEELEMENT).name = "NAME" Then
                Exit Do
            End If
            Me.bs_Description.MoveNext()
        Loop Until Me.bs_Description.Position < 5


        Dim _res = ([Enum].GetValues(GetType(CATALOGSAMPLEELEMENT.emPosition)).Cast(Of CATALOGSAMPLEELEMENT.emPosition).Select(Function(p)
                                                                                                                                   Return New With {.Name = [Enum].GetName(GetType(CATALOGSAMPLEELEMENT.emPosition), p), .Value = p}
                                                                                                                               End Function)).ToList


        Me.PositionComboBox.DataSource = _res
        Me.PositionComboBox.ValueMember = "Value"
        Me.PositionComboBox.DisplayMember = "Name"

    End Sub


#End Region

#Region "События биндингов"
    Private Sub BindingSourceMAP_CurrentChanged(sender As Object, e As System.EventArgs) Handles bs_MAP.CurrentItemChanged
        Me.bs_overlay.SuspendBinding()
        Me.oCurrentOverLayCollection_tab1.Clear()
        If Me.bs_MAP.Current Is Nothing Then
            Me.bs_overlay.ResumeBinding()
            Me.ReadMapImage()
            'Me.oCurrentMapImage = Nothing
            GoTo ex
        End If
        'привяжем коллекцию слоев
        Dim _currmap = CType(Me.bs_MAP.Current, CATALOGELEMENTMAP)

        If Not _currmap.LAYERS Is Nothing Then
            Me.oCurrentOverLayCollection_tab1.AddRange(_currmap.LAYERS)
        End If
        Me.bs_overlay.ResetBindings(False)
        Me.bs_overlay.ResumeBinding()
        'пробуем читать изображение
        Me.ReadMapImage()

ex:
        Me.oOffsetMode = False
    End Sub

    Private Sub bs_overlay_CurrentChanged(sender As Object, e As EventArgs) Handles bs_overlay.CurrentChanged
        If Me.bs_overlay.Current Is Nothing Then Return
        'Dim _curr As CATALOGSAMPLEMAPOVERLAY = Me.bs_overlay.Current
        Me.Panel1.Invalidate()
    End Sub

    Private Sub OVERLAYBindingSource_CurrentChanged(sender As Object, e As System.EventArgs) Handles bs_overlay.CurrentItemChanged
        If Me.bs_overlay.Current Is Nothing Then Exit Sub
        'отобразить оверлей
        Me.oOffsetMode = False
        Me.Panel1.Invalidate()
    End Sub

    Private Sub bs_SelectedMap_CurrentChanged(sender As Object, e As System.EventArgs) Handles bs_SelectedMap.CurrentItemChanged
        Me.bs_selectedOverlay.SuspendBinding()
        Me.oCurrentOverLayCollection_tab2.Clear()

        If Me.bs_SelectedMap.Current Is Nothing Then
            Me.bs_selectedOverlay.ResumeBinding()
            Me.ReadMapImage()
            GoTo ex
        End If

        'привяжем коллекцию слоев

        Dim _currmap = CType(Me.bs_SelectedMap.Current, CATALOGELEMENTMAP)
        If Not _currmap.LAYERS Is Nothing Then
            Me.oCurrentOverLayCollection_tab2.AddRange(_currmap.LAYERS)
        End If
        Me.bs_selectedOverlay.ResetBindings(False)
        Me.bs_selectedOverlay.ResumeBinding()
        'пробуем читать изображение
        Me.ReadMapImage()

ex:
        Me.oOffsetMode = False

        'Me.Panel1.Invalidate()
    End Sub

    Private Sub bs_selectedOverlay_CurrentChanged(sender As Object, e As System.EventArgs) Handles bs_selectedOverlay.CurrentItemChanged
        If Me.bs_selectedOverlay.Current Is Nothing Then Exit Sub
        'отобразить оверлей
        'Me.readOverlay(Me.bs_selectedOverlay.Current)
        Me.oOffsetMode = False

        Me.Panel1.Invalidate()
    End Sub



#End Region

#Region "События сеток"

    Private Sub CATALOGSAMPLEMAPOVERLAYDataGridView_DataError(sender As Object, e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvOverlay.DataError
        Debug.Fail("data error " & e.Exception.Message)
    End Sub

    Private Sub CATALOGSAMPLEMAPOVERLAYDataGridView_UserAddedRow(sender As Object, e As System.Windows.Forms.DataGridViewRowEventArgs) Handles dgvOverlay.UserAddedRow
        'add other values current=newrow
        Dim _curr As CATALOGSAMPLEMAPOVERLAY = Me.bs_overlay.Current
        Dim _pr = Me.bs_overlay.CurrencyManager.Position - 1
        If _pr >= 0 Then
            Dim _prev As CATALOGSAMPLEMAPOVERLAY = Me.bs_overlay.List(_pr)
            _curr.width = _prev.width
            _curr.height = _prev.height
        Else
            _curr.width = 40
            _curr.height = 40
        End If
        _curr.visible = True

        Me.bs_overlay.SuspendBinding()
        CType(Me.bs_MAP.Current, CATALOGELEMENTMAP).AddOverlay(_curr)
        Me.bs_overlay.ResumeBinding()
        Me.btSaveMaps.BackColor = Color.Red
        'Me.bs_overlay.ResetCurrentItem()
    End Sub

    Private Sub CATALOGSAMPLEMAPOVERLAYDataGridView_DefaultValuesNeeded(sender As Object, e As System.Windows.Forms.DataGridViewRowEventArgs) Handles dgvOverlay.DefaultValuesNeeded
        With e.Row
            If e.Row.Index > 0 Then
                'id
                .Cells(0).Value = clsTemplateManager.ReplaceParenthesis(Me.rtbElementText.Text)
                'type
                .Cells(1).Value = Me.oCurrentOverLayCollection_tab1(e.Row.Index - 1).type
                'overlayhref
                .Cells(2).Value = Me.oCurrentOverLayCollection_tab1(e.Row.Index - 1).overlayhref
                'position
                'size
                .Cells(5).Value = Me.oCurrentOverLayCollection_tab1(e.Row.Index - 1).opacity
                'text
                .Cells(6).Value = ""
            Else
                'id
                .Cells(0).Value = clsTemplateManager.ReplaceParenthesis(Me.rtbElementText.Text)
                'type
                .Cells(1).Value = CATALOGSAMPLEMAPOVERLAY.emOverlayType.arrow
                'overlayhref
                .Cells(2).Value = ""
                'position
                'size
                .Cells(5).Value = "1"
                'text
                .Cells(6).Value = ""
            End If



        End With
    End Sub
    Private Sub dgvSelectedOverlay_DataError(sender As Object, e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvSelectedOverlay.DataError
        MsgBox(e.Exception.Message)
    End Sub


    Private Sub dgvSelectedOverlay_DefaultValuesNeeded(sender As Object, e As System.Windows.Forms.DataGridViewRowEventArgs) Handles dgvSelectedOverlay.DefaultValuesNeeded
        With e.Row
            If e.Row.Index > 0 Then
                'id
                .Cells(0).Value = clsTemplateManager.ReplaceParenthesis(Me.rtbElementText.Text)
                'type
                .Cells(1).Value = Me.oCurrentOverLayCollection_tab2(e.Row.Index - 1).type
                'overlayhref
                .Cells(2).Value = Me.oCurrentOverLayCollection_tab2(e.Row.Index - 1).overlayhref
                'position
                'size
                .Cells(5).Value = Me.oCurrentOverLayCollection_tab2(e.Row.Index - 1).opacity
                'text
                .Cells(6).Value = ""
            Else
                'id
                .Cells(0).Value = clsTemplateManager.ReplaceParenthesis(Me.rtbElementText.Text)
                'type
                .Cells(1).Value = CATALOGSAMPLEMAPOVERLAY.emOverlayType.arrow
                'overlayhref
                .Cells(2).Value = ""
                'position
                'size
                .Cells(5).Value = "1"
                'text
                .Cells(6).Value = ""
            End If



        End With
    End Sub

    Private Sub dgvSelectedOverlay_UserAddedRow(sender As Object, e As System.Windows.Forms.DataGridViewRowEventArgs) Handles dgvSelectedOverlay.UserAddedRow
        'add other values current=newrow
        Dim _curr As CATALOGSAMPLEMAPOVERLAY = Me.bs_selectedOverlay.Current
        Dim _pr = Me.bs_selectedOverlay.CurrencyManager.Position - 1
        If _pr >= 0 Then
            Dim _prev As CATALOGSAMPLEMAPOVERLAY = Me.bs_selectedOverlay.List(_pr)
            _curr.width = _prev.width
            _curr.height = _prev.height
        Else
            _curr.width = 40
            _curr.height = 40
        End If
        _curr.visible = True

        Me.bs_selectedOverlay.SuspendBinding()
        CType(Me.bs_SelectedMap.Current, CATALOGELEMENTMAP).AddOverlay(_curr)
        Me.bs_selectedOverlay.ResumeBinding()
    End Sub


#End Region

#Region "События ЭУ"

#Region "кнопки"

    Private Sub btSetPoint_Click(sender As System.Object, e As System.EventArgs) Handles btSetPoint.Click
        If Not Me.bs_overlay.Current Is Nothing Then
            Dim _over = CType(Me.bs_overlay.Current, CATALOGSAMPLEMAPOVERLAY)
            _over.dx = Me.oCurrentOverlayRectangle.X * oKoeff_X
            _over.dy = Me.oCurrentOverlayRectangle.Y * oKoeff_Y
            Me.dgvOverlay.Refresh()
            Me.btSaveMaps.BackColor = Color.Red
        End If

    End Sub

    Private Sub btSetPoint2_Click(sender As System.Object, e As System.EventArgs) Handles btSetPointLayer.Click
        If Me.bs_selectedOverlay.Current Is Nothing Then Exit Sub
        Dim _over = CType(Me.bs_selectedOverlay.Current, CATALOGSAMPLEMAPOVERLAY)
        _over.dx = Me.oCurrentOverlayRectangle.X * oKoeff_X
        _over.dy = Me.oCurrentOverlayRectangle.Y * oKoeff_Y
        Me.dgvSelectedOverlay.Refresh()
        Me.btSaveMaps.BackColor = Color.Red
    End Sub


    Private Sub btReady_Click(sender As System.Object, e As System.EventArgs) Handles btReady.Click
        'должен вернуть обьекты CATALOGELEMENTMAP для добавления в конкретный образец!
        'надо использовать и модифицировать Service.clsApplicationTypes.DescriptionParser для получения описания образца
        RaiseEvent evAcceptChanges(Me, New Service.Catalog.CATALOGSAMPLE.clsCatalogSampleChangedEventArgs With {.ChangedCatalogSample = oCurrentCatalogSample})
        Me.Close()
    End Sub

    Private Sub btSaveMaps_Click(sender As System.Object, e As System.EventArgs) Handles btSaveMaps.Click
        oManager.SaveMaps(Me.bs_MAP.DataSource)
        Me.btSaveMaps.BackColor = Control.DefaultBackColor
    End Sub
    Private Sub btAddToElement_Click(sender As System.Object, e As System.EventArgs) Handles btAddToElement.Click
        If lbDescriptionElement.SelectedItem Is Nothing Then Exit Sub
        If Me.bs_MAP.Current Is Nothing Then Exit Sub
        If Me.bs_overlay.Current Is Nothing Then Exit Sub
        '-----------------------------------------------------------------
        Dim _over = CType(Me.bs_overlay.Current, CATALOGSAMPLEMAPOVERLAY)
        Dim _newover = _over.Clone
        _newover.id = _over.id & "_" & (oNewIndex)
        Dim _message As String = ""
        If bs_SelectedMap.DataSource(0) Is Nothing Then
            Dim _new = CType(Me.bs_MAP.Current, CATALOGELEMENTMAP).Clone(True)
            _new.AddOverlay(_newover)
            CType(lbDescriptionElement.SelectedItem, CATALOGSAMPLEELEMENT).MAP = _new
            _message = "Карта " & _new.id & " со слоем " & _newover.id & " добавлена"
        Else
            CType(Me.bs_SelectedMap.Current, CATALOGELEMENTMAP).AddOverlay(_newover)
            _message = "Слой " & _newover.id & " добавлен к карте " & CType(Me.bs_SelectedMap.Current, CATALOGELEMENTMAP).id
        End If
        oNewIndex += 1
        Me.bs_selectedOverlay.ResetBindings(False)
        Me.bs_SelectedMap.ResetBindings(False)
        MsgBox(_message, vbInformation)
        Me.tbctlMain.SelectedIndex = 1
    End Sub
    Private Sub btDeleteMapFromElement_Click(sender As System.Object, e As System.EventArgs) Handles btDeleteMapFromElement.Click
        If lbDescriptionElement.SelectedItem Is Nothing Then Exit Sub
        CType(lbDescriptionElement.SelectedItem, CATALOGSAMPLEELEMENT).MAP = Nothing
        Me.bs_SelectedMap.ResetBindings(False)
    End Sub

    Private Sub btDeleteLayerFromMaps_Click(sender As System.Object, e As System.EventArgs) Handles btDeleteLayerFromMaps.Click
        If Me.bs_selectedOverlay.Current Is Nothing Then Exit Sub
        Dim _over = CType(Me.bs_selectedOverlay.Current, CATALOGSAMPLEMAPOVERLAY)
        bs_selectedOverlay.RemoveCurrent()
        Me.oCurrentOverLayCollection_tab2.Remove(_over)
        CType(bs_SelectedMap.Current, CATALOGELEMENTMAP).RemoveOverlay(_over)
        Me.dgvSelectedOverlay.Refresh()
    End Sub

    Private Sub btDelOverlay_Click(sender As System.Object, e As System.EventArgs) Handles btDelOverlay.Click
        If Me.bs_overlay.Current Is Nothing Then Exit Sub
        Dim _over = CType(Me.bs_overlay.Current, CATALOGSAMPLEMAPOVERLAY)
        bs_overlay.RemoveCurrent()
        Me.oCurrentOverLayCollection_tab1.Remove(_over)
        CType(bs_MAP.Current, CATALOGELEMENTMAP).RemoveOverlay(_over)
        Me.dgvOverlay.Refresh()
        Me.btSaveMaps.BackColor = Color.Red
    End Sub

    Private Sub btDelSelectedMap_Click(sender As System.Object, e As System.EventArgs) Handles btDelSelectedMap.Click
        If Me.bs_MAP.Current Is Nothing Then Exit Sub

        Select Case MsgBox("Удалить карту " & bs_MAP.Current.ToString & " ?", vbYesNo)
            Case MsgBoxResult.Yes, MsgBoxResult.Ok

                'Me.oStoredMap.Remove(bs_MAP.Current)
                Dim _filename = IO.Path.GetFileName(CType(Me.bs_MAP.Current, CATALOGELEMENTMAP).href)
                Dim _idContent As clsIDcontent = clsIDcontent.CreateInstance("", _filename, clsIDcontent.emContentType.image, False)
                Dim _fromSource = clsFilesSources.MapOnTRILBONE
                If clsApplicationTypes.SamplePhotoObject.DeleteFileFromContainer(_fromSource, _idContent) Then
                    Me.bs_MAP.RemoveCurrent()
                    Me.dgvMAP.Refresh()
                    Me.btSaveMaps.BackColor = Color.Red
                Else
                    MsgBox("Не удалось удалить карту с сервера", vbCritical)
                End If


        End Select


    End Sub

    Private Sub btSaveLayerToMaps_Click(sender As System.Object, e As System.EventArgs) Handles btSaveLayerToMaps.Click
        If Me.bs_SelectedMap.Current Is Nothing Then Return
        If Me.bs_selectedOverlay.Current Is Nothing Then Return
        'найти карту, отображенную в выбранных
        Dim _currentmap As CATALOGELEMENTMAP = Me.bs_SelectedMap.Current
        Dim _map = From c In Me.oStoredMap Where c.Equals(_currentmap) Select c
        If _map.Count = 0 Then
            Select Case MsgBox("Карты " & _currentmap.ToString & " не существует. Добавить?", vbYesNo)
                Case vbYes
                    _map = {_currentmap.Clone(True)}
                    Me.oStoredMap.Add(_map.FirstOrDefault)
                    Me.bs_MAP.ResetBindings(False)
                    Me.dgvMAP.Refresh()
                Case vbNo
                    Return
            End Select
        End If

        'add overlay
        Dim _newover = CType(Me.bs_selectedOverlay.Current, CATALOGSAMPLEMAPOVERLAY).Clone
        _newover.id = CType(Me.bs_selectedOverlay.Current, CATALOGSAMPLEMAPOVERLAY).id & "_" & oNewIndex
        _map(0).AddOverlay(_newover)
        Me.bs_overlay.ResetBindings(False)
        MsgBox("Слой " & _newover.id & " добавлен к карте " & CType(_map(0), CATALOGELEMENTMAP).id, vbInformation)

        Me.dgvOverlay.Refresh()
        Me.tbctlMain.SelectedIndex = 0


    End Sub

    Private Sub btCreateOverlay_Click(sender As System.Object, e As System.EventArgs) Handles btCreateOverlay.Click
        Dim _curr As CATALOGSAMPLEMAPOVERLAY = Me.bs_overlay.Current
        Dim _name = clsTemplateManager.ReplaceParenthesis(rtbElementText.Text)
        If _curr Is Nothing Then
            CType(Me.bs_MAP.Current, CATALOGELEMENTMAP).AddOverlay(_name, "http://www.trilbone.com/maps/ArrowGreen_40.png", CATALOGSAMPLEMAPOVERLAY.emOverlayType.arrow, True, 1, oCurrentOverlayRectangle.Location, New Size(40, 40), "")
        Else
            CType(Me.bs_MAP.Current, CATALOGELEMENTMAP).AddOverlay(_name, _curr.overlayhref, _curr.type, True, _curr.opacity, oCurrentOverlayRectangle.Location, _curr.Size, "")
        End If
        Me.bs_MAP.ResetBindings(False)
        Me.bs_overlay.ResetBindings(False)
        Me.bs_overlay.MoveLast()
        Me.btSaveMaps.BackColor = Color.Red
    End Sub

    Private Sub btCreateOverlaySelected_Click(sender As System.Object, e As System.EventArgs) Handles btCreateOverlaySelected.Click
        Dim _curr As CATALOGSAMPLEMAPOVERLAY = Me.bs_selectedOverlay.Current
        Me.bs_selectedOverlay.SuspendBinding()
        CType(Me.bs_SelectedMap.Current, CATALOGELEMENTMAP).AddOverlay(clsTemplateManager.ReplaceParenthesis(Me.rtbElementText.Text), _curr.overlayhref, _curr.type, True, _curr.opacity, oCurrentOverlayRectangle.Location, _curr.Size, "")
        Me.bs_SelectedMap.ResetBindings(False)
        Me.bs_selectedOverlay.ResumeBinding()
        Me.bs_selectedOverlay.MoveLast()
    End Sub


    Private Sub btDeleteElement_Click(sender As System.Object, e As System.EventArgs) Handles btDeleteElement.Click
        Dim _curr As CATALOGSAMPLEELEMENT = Me.bs_Description.Current
        Dim _currindex = Me.bs_Description.IndexOf(_curr)

        If Me.oCurrentCatalogSample.RemoveDataElement(Me.bs_Description.Current) Then
            Me.bs_Description.DataSource = oCurrentCatalogSample.DATA
            Me.bs_Description.MovePrevious()
            Me.lbDescriptionElement.Refresh()
            Me.tbctlMain.SelectedIndex = 2
        End If
    End Sub

    Private Sub btAddElement_Click(sender As System.Object, e As System.EventArgs) Handles btAddElement.Click
        Me.oCurrentCatalogSample.AddDataElement("userdescr", "", CATALOGSAMPLEELEMENT.emPosition.title, "", , , )
        Me.bs_Description.DataSource = oCurrentCatalogSample.DATA
        Me.bs_Description.MoveLast()
        Me.lbDescriptionElement.Refresh()
        Me.tbctlMain.SelectedIndex = 2
        Me.rtbElementText.Focus()
    End Sub
    ''' <summary>
    ''' обновит текущий HTML
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RefreshHTML()
        If oCurrentCatalogSample Is Nothing Then
            Return
        End If
      
        If String.IsNullOrEmpty(oTemplateName) Then Return

        Dim _xml = oManager.GetTransform(Me.oCurrentCatalogSample.GetXML, emTemplateType.ByName, oTemplateName)
        Me.WebBrowser1.DocumentText = _xml
        Me.WebBrowser1.Visible = True
        'If oManager.WriteFile(oCurrentTmpHtmlPath, _xml) Then
        '    Me.WebBrowser1.Navigate(oCurrentTmpHtmlPath)
        'End If
    End Sub

    Private Sub btRefreshBrowser_Click(sender As System.Object, e As System.EventArgs) Handles btRefreshBrowser.Click
        Me.oOffsetMode = False
        If Me.WebBrowser1.Visible Then
            RefreshHTML()
        Else
            draw()
        End If
    End Sub

#End Region

#Region "Комбо, списки и чекбоксы"
    Private Sub lbDescriptionElement_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lbDescriptionElement.SelectedIndexChanged
        If lbDescriptionElement.SelectedItem Is Nothing Then Exit Sub
        Me.bs_SelectedMap.DataSource = {CType(lbDescriptionElement.SelectedItem, CATALOGSAMPLEELEMENT).MAP}
        Me.bs_SelectedMap.ResetBindings(False)
        Me.bs_selectedOverlay.ResetBindings(False)

        If (Not Me.bs_SelectedMap.DataSource Is Nothing) AndAlso (Not Me.bs_SelectedMap.DataSource(0) Is Nothing) Then
            If Me.tbctlMain.SelectedIndex = 0 Then
                Me.tbctlMain.SelectedIndex = 1

            End If
        Else
            If Me.tbctlMain.SelectedIndex = 1 Then
                Me.tbctlMain.SelectedIndex = 0

            End If
        End If

    End Sub

    Private Sub cbSowAllOverlays_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles cbSowAllOverlays.CheckedChanged
        oShowAllOverlays = cbSowAllOverlays.Checked
        If cbSowAllOverlays.Checked Then
            Me.oOffsetMode = False
        End If
        draw()
    End Sub

#End Region


    Private Sub Panel1_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseClick
        If cbSowAllOverlays.Checked = True Then Return

        Me.oCurrentOverlayRectangle.X = e.X - Me.oCurrentOverlayRectangle.Width
        Me.oCurrentOverlayRectangle.Y = e.Y - Me.oCurrentOverlayRectangle.Height / 2
        oOffsetMode = True
        draw()
        Me.btSetPoint_Click(sender, e)
        Me.btSetPoint2_Click(sender, e)
    End Sub

    Private Sub Panel1_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint
        Me.draw()
    End Sub


    Private Sub tbctlMain_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles tbctlMain.SelectedIndexChanged
        'Private oCurrentOverLayCollection As New List(Of CATALOGSAMPLEMAPOVERLAY)
        ''текущее изображение карты
        'Private oCurrentMapImage As Image
        ''текущее изображение слоя
        'Private oCurentOverlayImage As Image
        ''текущий прямоугольник отображения слоя
        'Private oCurrentOverlayRectangle As Rectangle
        Me.oCurrentMapImage = Nothing
        Me.oCurentOverlayImage = Nothing
        Me.oCurrentOverlayRectangle = New Rectangle(0, 0, 0, 0)
        Me.Panel1.Invalidate()
        Select Case tbctlMain.SelectedIndex
            Case 0
                'stored maps
                Me.oCurrentOverLayCollection_tab1.Clear()
                Me.bs_MAP.ResetBindings(False)
                Me.bs_overlay.ResetBindings(False)
                Me.btAddToElement.Enabled = True
                Me.WebBrowser1.Visible = False
            Case 1
                'element's map
                Me.oCurrentOverLayCollection_tab2.Clear()
                Me.bs_SelectedMap.ResetBindings(False)
                Me.bs_selectedOverlay.ResetBindings(False)
                Me.btAddToElement.Enabled = False
                Me.WebBrowser1.Visible = False
            Case 2
                Me.oCurrentOverLayCollection_tab2.Clear()
                Me.bs_SelectedMap.ResetBindings(False)
                Me.bs_selectedOverlay.ResetBindings(False)
                Me.btAddToElement.Enabled = False
                Me.WebBrowser1.Visible = True
                'показать содержимое
                RefreshHTML()
        End Select
    End Sub


    Private Sub fmCreateMAP_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        rbArrow.Checked = True
    End Sub

    ''' <summary>
    ''' обновляет значения в других боксах
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tbAltTag_Validated(sender As Object, e As System.EventArgs) Handles tbAltTag.Validated, AltTextBox.Validated, TextRichTextBox.Validated, rtbElementText.Validated
        Me.bs_Description.ResetCurrentItem()
    End Sub

    Private Sub NumericUpDown1_Validated(sender As Object, e As System.EventArgs) Handles nudElementPosition.Validated, PositionComboBox.Validated
        Me.btRefreshBrowser_Click(sender, e)
    End Sub

#End Region


#Region "утилиты"

    Private Sub draw()
        If Me.oCurrentMapImage Is Nothing Then Return
        Dim _overlays As List(Of CATALOGSAMPLEMAPOVERLAY) = Nothing
        Dim _gr = Me.Panel1.CreateGraphics


        Dim _clientRect = Me.Panel1.ClientRectangle
        Dim _origRec = New Rectangle(0, 0, oCurrentMapImage.Width, oCurrentMapImage.Height)

        oKoeff_X = 800 / _clientRect.Width
        oKoeff_Y = (_origRec.Height * (800 / _origRec.Width)) / _clientRect.Height

        'oKoeff_XV = 600 / _imgRec.Width

        'рисуем карту
        _gr.DrawImage(oCurrentMapImage, _clientRect, _origRec, GraphicsUnit.Pixel)

        'рисуем слои
        If oShowAllOverlays Then
            Select Case Me.tbctlMain.SelectedIndex
                Case 0
                    _overlays = Me.oCurrentOverLayCollection_tab1
                Case 1
                    _overlays = Me.oCurrentOverLayCollection_tab2
            End Select

        Else
            _overlays = New List(Of CATALOGSAMPLEMAPOVERLAY)
            Select Case Me.tbctlMain.SelectedIndex
                Case 0
                    If Not bs_overlay.Current Is Nothing AndAlso CType(bs_overlay.Current, CATALOGSAMPLEMAPOVERLAY).visible Then
                        _overlays.Add(bs_overlay.Current)
                    End If
                Case 1
                    If Not bs_selectedOverlay.Current Is Nothing Then
                        _overlays.Add(bs_selectedOverlay.Current)
                    End If
            End Select
        End If

        For Each _ov In _overlays
            Me.readOverlayImage(_ov)
            If Not oCurentOverlayImage Is Nothing Then
                _gr.DrawImage(oCurentOverlayImage, Me.oCurrentOverlayRectangle)
            End If
        Next

    End Sub

    Private Sub readOverlayImage(CurrentOverlay As CATALOGSAMPLEMAPOVERLAY)

        If CurrentOverlay Is Nothing Then Return

        If oimgColl.ContainsKey(CurrentOverlay.GetHashCode) Then
            oCurentOverlayImage = oimgColl(CurrentOverlay.GetHashCode)
        Else
            oCurentOverlayImage = Nothing
            'пробуем читать изображение
            Dim _uri As Uri = Nothing
            If Uri.TryCreate(CurrentOverlay.overlayhref, UriKind.Absolute, _uri) Then

                Select Case _uri.Scheme
                    Case "http"
                        'вызвать загрузку изображения
                        Dim _status As Integer
                        _uri = clsTemplateManager.loadHttpImage(_uri, _status)
                        If _status <= 0 Then
                            oCurentOverlayImage = Service.clsApplicationTypes.NoImage
                            Return
                        End If
                End Select

                If IO.File.Exists(_uri.LocalPath) Then
                    oCurentOverlayImage = Drawing.Image.FromFile(_uri.LocalPath)
                    oimgColl.Add(CurrentOverlay.GetHashCode, oCurentOverlayImage)
                Else
                    oCurentOverlayImage = Service.clsApplicationTypes.NoImage
                    Return
                End If

            Else
                oCurentOverlayImage = Service.clsApplicationTypes.NoImage
                Return
            End If
        End If

        'rectangle
        If Not oOffsetMode Then
            Me.oCurrentOverlayRectangle = New Rectangle(((CurrentOverlay.dx / oKoeff_X)), (CurrentOverlay.dy / oKoeff_Y), CurrentOverlay.Size.Width / oKoeff_X, CurrentOverlay.Size.Height / oKoeff_Y)
        End If
    End Sub

    Private Sub ReadMapImage()
        Dim currentmap As CATALOGELEMENTMAP = Nothing
        Me.oCurrentMapImage = Nothing
        Select Case Me.tbctlMain.SelectedIndex
            Case 0
                currentmap = Me.bs_MAP.Current
            Case 1
                currentmap = Me.bs_SelectedMap.Current
        End Select

        'пробуем читать изображение
        If currentmap Is Nothing Then Me.oCurrentMapImage = Nothing : Return

        If Me.oimgColl.ContainsKey(currentmap.GetHashCode) Then
            Me.oCurrentMapImage = Me.oimgColl(currentmap.GetHashCode)
        Else
            Dim _uri As Uri = Nothing
            If Uri.TryCreate(currentmap.href, UriKind.Absolute, _uri) Then
                Select Case _uri.Scheme
                    Case "http"
                        'вызвать загрузку изображения
                        Select Case _uri.Scheme
                            Case "http"
                                'вызвать загрузку изображения
                                Dim _status As Integer
                                _uri = clsTemplateManager.loadHttpImage(_uri, _status)
                                If _status <= 0 Then MsgBox("Не могу загрузить файл схемы из интернета", vbCritical) : Return
                        End Select
                End Select

                If IO.File.Exists(_uri.LocalPath) Then
                    Dim _img = Drawing.Image.FromFile(_uri.LocalPath)
                    Me.oCurrentMapImage = _img
                    Me.oimgColl.Add(currentmap.GetHashCode, oCurrentMapImage)
                Else
                    Return
                End If

            Else
                Return
            End If
        End If

        Panel1.Invalidate()

    End Sub

#End Region

    Private Sub btAddMap_Click(sender As Object, e As EventArgs) Handles btAddMap.Click
        Dim _curr As CATALOGELEMENTMAP = Me.bs_MAP.Current
        Dim _new = New CATALOGELEMENTMAP

        Dim _dg As New OpenFileDialog
        Static _path As String
        If _path Is Nothing OrElse _path = "" Then
            _path = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        End If

        With _dg
            .Multiselect = False
            .InitialDirectory = _path
            .Filter = clsIDcontent.GetSystemFilterStringByExtentionsByContentType(clsIDcontent.emContentType.image)
            .Title = "Выбор карты для загрузки на сервер"
            .CheckFileExists = True
        End With

        Select Case _dg.ShowDialog
            Case Windows.Forms.DialogResult.OK, Windows.Forms.DialogResult.Yes
                Dim _fullPath = _dg.FileName
                Dim _filename = IO.Path.GetFileName(_fullPath)

                Dim _idContent As clsIDcontent = clsIDcontent.CreateInstance("", _filename, clsIDcontent.emContentType.image, False)
                Dim _fromSource = clsFilesSources.CreateInstance(clsFilesSources.emSources.FreeFolder, , , IO.Path.GetDirectoryName(_fullPath))
                Dim _toSource = clsFilesSources.MapOnTRILBONE

                Dim _data = clsApplicationTypes.SamplePhotoObject.ReadFileFromContainer(_fromSource, _idContent)
                'пишем
                If clsApplicationTypes.SamplePhotoObject.WriteFileToContainer(_toSource, _idContent, _data) > 0 Then
                    MsgBox("Файл успешно записан на сервер", vbInformation)
                Else
                    MsgBox("Не удалось записать файл", vbCritical)
                    Return
                End If

                Dim _uri = clsApplicationTypes.SamplePhotoObject.GetContentURI(_idContent, _toSource)
                _new.href = _uri.AbsoluteUri
                _new.id = IO.Path.GetFileNameWithoutExtension(_fullPath)
                _new.Text = "строка заголовка - замените!"
                Me.oStoredMap.Add(_new)

                Me.bs_MAP.ResetBindings(False)
                Me.bs_overlay.ResetBindings(False)
                Me.bs_MAP.MoveLast()
                Me.btSaveMaps.BackColor = Color.Red
            Case Else
                Return
        End Select

    End Sub


    Private Sub btPreView_Click(sender As Object, e As EventArgs) Handles btPreView.Click
        If Me.cbTemplates.SelectedItem Is Nothing Then Return
        Dim _html = oCurrentCatalogSample.GetTransform(emTemplateType.ByName, Me.cbTemplates.SelectedItem)
        Dim _caption = oCurrentCatalogSample.DATA.Where(Function(x) x.name.ToLower = "name").FirstOrDefault.Text
        Dim _catname = String.Format("{0} {1}", clsApplicationTypes.RejectSkobki(_caption), oCurrentCatalogSample.DATA.Where(Function(x) x.name.ToLower = "number").FirstOrDefault.Text)
        Dim _fm = clsApplicationTypes.Browser(_html, _caption, _catname)
        _fm.ShowDialog()
    End Sub

    Private Sub cbTemplates_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbTemplates.SelectedIndexChanged
        If Me.cbTemplates.SelectedIndex < 0 Then Return
        oTemplateName = Me.cbTemplates.SelectedItem
        RefreshHTML()
    End Sub
    ''' <summary>
    ''' изменение масштаба
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub WebBrowser1_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted
        Me.WebBrowser1.Zoom(60)
    End Sub
End Class