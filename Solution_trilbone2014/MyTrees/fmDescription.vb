Imports <xmlns:treeout="http://www.trilbone.com/treeout">
Imports System.Xml.Linq
Imports System.Drawing.Printing
Imports Service


<Serializable()>
Friend Class fmDescription
    Private WithEvents oManager As clsTreeManager
    Private oNeedToSave As Boolean
    Private oInitProc As Boolean
    Private Class TreeFiles
        Implements IComparable
        Implements IComparable(Of TreeFiles)

        Property Path As String
        Property BlockName As String
        Public Overrides Function ToString() As String
            Return BlockName
        End Function

        Public Function CompareTo(obj As Object) As Integer Implements IComparable.CompareTo
            If obj Is Nothing Then Return 0
            If Not TypeOf (obj) Is TreeFiles Then Return 0
            Dim _obj = CType(obj, TreeFiles)
            Return Me.BlockName.CompareTo(_obj.BlockName)
        End Function

        Public Function CompareTo1(other As TreeFiles) As Integer Implements IComparable(Of TreeFiles).CompareTo
            Return Me.CompareTo(other)
        End Function

        Public Overrides Function GetHashCode() As Integer
            If Me.BlockName = "" Then
                Return MyBase.GetHashCode()
            End If
            Return Me.BlockName.GetHashCode
        End Function
        Public Overrides Function Equals(obj As Object) As Boolean
            If obj Is Nothing Then Return False
            If Not TypeOf (obj) Is TreeFiles Then Return False
            Dim _obj = CType(obj, TreeFiles)
            If Me.BlockName = "" Then
                Return MyBase.Equals(obj)
            End If
            Return Me.BlockName.Equals(_obj.BlockName)
        End Function
    End Class

    Private Sub Init()

        'поиск и загрузка всех файлов
        Dim _root = Service.clsApplicationTypes.TreeFolderPath
        Dim _files = IO.Directory.EnumerateFiles(_root, "*.tree").Select(Function(x) New TreeFiles With {.BlockName = IO.Path.GetFileName(x), .Path = x}).ToList
        _files.Sort()
        oInitProc = True
        Me.cbFiles.DisplayMember = "BlockName"
        Me.cbFiles.ValueMember = "Path"
        Me.cbFiles.DataSource = _files

        oInitProc = False
        Dim _selected = _files.FirstOrDefault(Function(x) x.BlockName = oManager.LoadedGroupName)
        If Not _selected Is Nothing Then
            Me.cbFiles.SelectedItem = _selected
        Else
            If Not oManager Is Nothing Then
                _selected = _files.FirstOrDefault(Function(x) x.BlockName = oManager.DataBlockName)
                If Not _selected Is Nothing Then
                    Me.cbFiles.SelectedItem = _selected
                End If
            End If
        End If

        '   oManager.Parent = Me
        If Not oManager.FileLoaded Then
            oManager.LoadFile()
        End If

        Me.ClsHierManagerBindingSource.DataSource = oManager

        Me.oNeedToSave = False
        Me.Text = clsTreeManager.AppHeader

        InitTabs()
    End Sub
    Private Sub InitTabs()
        Me.RefreshTabs()
        'выбрать дерево систематика и включить листья
        If oManager.ContainsTree("Systematica") Then
            Me.TabControl1.SelectedTab = Me.TabControl1.TabPages("Systematica")
            'получить ссылку на эу
            Dim _control = Me.TabControl1.TabPages("Systematica").Controls(0)
            If (Not _control Is Nothing) AndAlso _control.GetType = GetType(ucHierarhy) Then
                CType(_control, ucHierarhy).cbxShowLeaf.Checked = True
                CType(_control, ucHierarhy).Select()
            End If
        End If
    End Sub


    Public Sub New()
        InitializeComponent()
        Me.oManager = New clsTreeManager
        Init()
    End Sub
    Public Sub New(manager As clsTreeManager)
        ' Этот вызов является обязательным для конструктора.
        InitializeComponent()
        Me.oManager = manager
        Init()
    End Sub

    ''' <summary>
    ''' показывает изменение в деревьях
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub oManager_TreeChanged(ByVal sender As Object, ByVal e As clsTreeManager.TreeChangedEventArg) Handles oManager.TreeChanged
        Me.btSaveFile.BackColor = Color.Red
        oNeedToSave = True
    End Sub

    Private Sub btSaveFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSaveFile.Click
        If Me.cbFiles.SelectedItem Is Nothing Then
            'это новое дерево
            Dim s As New SaveFileDialog
            With s
                'откроем диалог
                .InitialDirectory = Service.clsApplicationTypes.TreeFolderPath
                .Filter = " Tree files|*.tree"
                .DefaultExt = "tree"
                .AddExtension = True
                .OverwritePrompt = True
                .RestoreDirectory = True
                .Title = "Создать файл с деревьями"
            End With
            Select Case s.ShowDialog(Me)
                Case DialogResult.OK, DialogResult.Yes
                    Dim _list As List(Of TreeFiles) = Me.cbFiles.DataSource
                    Dim _nf = New TreeFiles With {.Path = s.FileName, .BlockName = IO.Path.GetFileName(s.FileName)}
                    _list.Add(_nf)
                    MsgBox(Me.oManager.SaveFile(s.FileName, True), vbInformation, clsTreeManager.AppHeader)
                    _list.Sort()
                    Me.cbFiles.DataSource = _list
                    Me.cbFiles.SelectedItem = _nf
                    Me.oNeedToSave = False
            End Select
            Return
        End If

        'это старое дерево
        Dim _path = Me.cbFiles.SelectedValue
        Select Case MsgBox(String.Format("Сохранить дерево {0}?", IO.Path.GetFileNameWithoutExtension(_path)), vbYesNo)
            Case MsgBoxResult.Yes

                MsgBox(Me.oManager.SaveFile(_path, False), vbInformation, clsTreeManager.AppHeader)
                Me.oNeedToSave = False
                Me.btSaveFile.BackColor = Button.DefaultBackColor
        End Select

    End Sub
    ''' <summary>
    ''' сделать вкладки
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RefreshTabs()
        If Me.TabControl1.TabPages.Count > 0 Then
            Me.TabControl1.TabPages.Clear()

        End If
        Me.oTabFlags.Clear()
        'сделать вкладки под деревья
        Application.DoEvents()
        For Each t In oManager.TreeCollection
            Me.AddTabPage(t.Key, t.Value.TreeKeyNameRUS, t.Value)
        Next
    End Sub



    Private Sub AddTabPage(ByVal Name As String, ByVal NameRUS As String, ByVal data As ClsTree)
        'создать вкладку
        Dim _tab = New Windows.Forms.TabPage
        _tab.Name = Name
        'по умолчанию, англицкое имя пишется в св-во text, а русское в tag
        _tab.Text = Name
        _tab.Tag = NameRUS
        'создать мой ЭУ
        Dim _hi = New ucHierarhy(data)
        _hi.ParentPage = _tab
        _hi.ParentFmDescription = Me
        AddHandler _hi.DescriptionAcceptUcHierarhy, AddressOf DescriptionAcceptUcHierarhyEventHandler
        AddHandler _hi.AddNodeToPrint, AddressOf AddNodeToPrintEventHandler
        AddHandler _hi.SelectedNodeChanged, AddressOf UcHierarhySelectedNodeChangedEventHandler

        _hi.Name = Name
        _hi.Dock = DockStyle.Top
        _hi.Visible = True

        Me.oTabFlags.Add(Name, True)
        _hi.BuildTreeView()
        'добавить на вкладку
        _tab.Controls.Add(_hi)
        'добавить вкладку в коллекцию
        Me.TabControl1.TabPages.Add(_tab)
    End Sub


    Private Sub DescriptionAcceptUcHierarhyEventHandler(ByVal sender As Object, ByVal e As clsTreeService.DescriptionAcceptEventArg)
        'построить описание
        Me.oManager.AddElementToDescription(e.DescriptionXelements)
        Me.ClsHierManagerBindingSource.ResetBindings(False)
        'RaiseEvent DescriptionAcceptedfmDescription(Me, e)
        'RaiseEvent DescriptionChanged(Me, New ucHierarhy.DescriptionAcceptEventArg(Me.oManager.Description, e.Culture))
    End Sub
    ''' <summary>
    ''' ловит изменение культуры
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CultureChangedEventHandler(ByVal sender As Object, ByVal e As CultureChangedEventArgs)
        'тут надо поменять имя вкладки
        Dim _hi = CType(sender, ucHierarhy)
        Dim _ENName As String, _RUSName As String
        Select Case e.NewCulture.IetfLanguageTag
            Case "en-US"
                With _hi.ParentPage
                    _ENName = .Tag
                    _RUSName = .Text
                    'меняем
                    .Text = _ENName
                    .Tag = _RUSName
                End With
            Case "ru-RU"
                With _hi.ParentPage
                    _ENName = .Text
                    _RUSName = .Tag
                    'меняем
                    .Tag = _ENName
                    .Text = _RUSName
                End With

        End Select

    End Sub


    ''' <summary>
    ''' открыть файл
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btOpenFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btOpenFile.Click
        If Me.cbFiles.SelectedItem Is Nothing Then Return
        Dim _path As String = Me.cbFiles.SelectedValue
        If Me.TabControl1.TabPages.Count > 0 Then
            Me.TabControl1.TabPages.Clear()
        End If
        oManager.GroupFilePath = _path
        Me.oManager.LoadFile()
        If Me.oManager.FileLoaded Then
            Me.RefreshTabs()
        End If
        Me.Text = clsTreeManager.AppHeader
    End Sub


    Private Sub btCreateTree_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCreateTree.Click
        'Me.cbFiles.SelectedIndex = -1
        Dim _name As String = InputBox("Новое дерево. Введите имя АНГЛИЙСКОЕ. Это имя будет уникальным ключем для дерева", "Новое дерево")
        Dim _nameRUS As String = _name
        If _name.Length > 0 Then
            Dim _tree = Me.oManager.CreateTree(_name)
            Me.AddTabPage(_name, _nameRUS, _tree)
        End If
    End Sub

    Private Sub btClearDescription_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btClearDescription.Click
        If oManager Is Nothing Then Return
        Me.oManager.ClearDescription()
        Me.rtbDescription_parced.Text = ""
        Me.rtbDescription_parced.Refresh()
        Me.ClsHierManagerBindingSource.ResetBindings(False)
    End Sub
    ' ''' <summary>
    ' ''' 
    ' ''' </summary>
    ' ''' <param name="sender"></param>
    ' ''' <param name="e"></param>
    ' ''' <remarks></remarks>
    'Private Sub rtbDescription_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rtbDescription.TextChanged
    '    'изменено описание в текстбоксе
    '    RaiseEvent DescriptionChanged(Me, New ucHierarhy.DescriptionAcceptEventArg(rtbDescription.Text, System.Globalization.CultureInfo.CurrentCulture))
    'End Sub

    ' ''' <summary>
    ' ''' паблик свойство для поля с сгенерированным описанием
    ' ''' </summary>
    ' ''' <value></value>
    ' ''' <returns></returns>
    ' ''' <remarks></remarks>
    'Public ReadOnly Property Description As String
    '    Get
    '        Return Me.rtbDescription.Text
    '    End Get

    'End Property

    ' ''' <summary>
    ' ''' вернет активный менеджер управления деревьями. Он будет создан при создании формы.
    ' ''' </summary>
    ' ''' <value></value>
    ' ''' <returns></returns>
    ' ''' <remarks></remarks>
    'Public ReadOnly Property TreeManager As clsTreeManager
    '    Get
    '        Return oManager
    '    End Get
    'End Property

    ''' <summary>
    ''' создать блок файлов xml и htm
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btSaveXML_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSaveXML.Click

        If Me.cbxImageInclude.Checked Then
            MsgBox(Me.oManager.Save_XML_HTML(True, True, Me.cbxInternet.Checked), vbInformation, clsTreeManager.AppHeader)
        Else
            MsgBox(Me.oManager.Save_XML_HTML(True, False, Me.cbxInternet.Checked), vbInformation, clsTreeManager.AppHeader)
        End If

        ' Me.oManager.ShowBrowser()


    End Sub

    Private Sub oManager_TreeNameChanged(ByVal sender As Object, ByVal e As ClsTree.TreeNameChangedEventArgs) Handles oManager.TreeNameChanged
        'изменилось имя дерева
        'найти вкладку
        Dim _tabs = (From q As TabPage In Me.TabControl1.TabPages Where q.Name = e.OldName Select q).ToList

        'подтвердить изменение именно в ней, найдя мой ЭУ по новому имени
        Dim _mytab As Control = Nothing
        For Each w In _tabs
            Dim _tcc As TabPage.TabPageControlCollection = w.Controls

            If _tcc.ContainsKey(e.OldName) Then
                _mytab = _tcc.Owner
            End If
        Next

        'изменить название вкладки
        If Not _mytab Is Nothing Then
            _mytab.Name = e.NewName
            _mytab.Text = e.NewName
        End If

    End Sub

    ''' <summary>
    ''' load формы
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub fmDescription_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.btClearDescription_Click(Me, EventArgs.Empty)
    End Sub
    ''' <summary>
    ''' активирует вкладку определенного дерева
    ''' </summary>
    ''' <param name="TreeName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Function SelectTab(TreeName As String) As ucHierarhy
        If oManager.ContainsTree("Systematica") Then
            Me.TabControl1.SelectedTab = Me.TabControl1.TabPages("Systematica")
            If Me.TabControl1.SelectedTab Is Nothing Then Return Nothing
            'получить ссылку на эу
            Dim _control = Me.TabControl1.SelectedTab.Controls(0)
            If (Not _control Is Nothing) AndAlso _control.GetType = GetType(ucHierarhy) Then
                CType(_control, ucHierarhy).Select()
            End If
            Return CType(_control, ucHierarhy)
        End If
        Return Nothing
    End Function


    Private Sub btReadXML_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btReadXML.Click
        'загрузить файл
        Dim _dg As New OpenFileDialog
        _dg.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        _dg.Filter = "XML files|*.xml"
        _dg.RestoreDirectory = True
        Select Case _dg.ShowDialog(Me)
            Case DialogResult.OK
                'Dim _dirFile = IO.Directory.GetParent(_dg.FileName).Parent.FullName
                oManager.GroupFilePath = _dg.FileName
                If Not Me.oManager.LoadFromXML(_dg.FileName) Then
                    MsgBox("Не удалось распознать XML файл", vbInformation, clsTreeManager.AppHeader)
                End If

                Me.RefreshTabs()
            Case Else
                Exit Sub
        End Select
    End Sub



    Private Sub btShowHtml_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btShowHtml.Click
        Me.oManager.ShowBrowser(Me.cbxInternet.Checked)
    End Sub

    Private Sub btAccept_Click(sender As System.Object, e As System.EventArgs) Handles btAccept.Click
        If oNeedToSave Then
            Me.btSaveFile_Click(sender, e)
        End If

        If oManager.XMLDescriptionElement Is Nothing Then
            MsgBox("Следует добавить хотя бы один узел в описание", vbCritical)
            Exit Sub
        End If

        Dim _culture As System.Globalization.CultureInfo = clsTreeManager.EnglishCulture
        If rbRussian.Checked Then
            _culture = clsTreeManager.RussianCulture
        End If

        Dim _out = New clsTreeService.DescriptionAcceptEventArg(oManager.XMLDescriptionElement, _culture)
        RaiseEvent DescriptionAcceptedfmDescription(Me, _out)
        btClearDescription_Click(sender, e)
        Me.Close()
    End Sub
    ' ''' <summary>
    ' ''' вернет путь к выбранному файлу
    ' ''' </summary>
    ' ''' <value></value>
    ' ''' <returns></returns>
    ' ''' <remarks></remarks>
    'Public ReadOnly Property LoadedFilePath As String
    '    Get
    '        Return oManager.BlockFilePath
    '    End Get
    'End Property

    ''' <summary>
    ''' текущее описание в виде строки с xml
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Description As String
        Get
            If Not oManager.XMLDescriptionElement Is Nothing Then
                Return oManager.XMLDescriptionElement.ToString
            End If
            Return Nothing
        End Get
    End Property
    ''' <summary>
    ''' вернет узел, если требуется сортировка
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property FilterNode As NodeObject
        Get
            If cbxFilterNode.Checked Then
                Return cbxFilterNode.Tag
            End If
            Return Nothing
        End Get
    End Property


    Private Sub btbtCloseFile_Click(sender As System.Object, e As System.EventArgs) Handles btCloseFile.Click
        '  Me.tbFilePath.Text = ""
        Me.cbFiles.SelectedIndex = -1

        Me.btSaveFile.BackColor = Control.DefaultBackColor
        Me.oManager.ClearTreeCollection()
        If Me.TabControl1.TabPages.Count > 0 Then
            Me.TabControl1.TabPages.Clear()
            Me.oTabFlags.Clear()
        End If

    End Sub

    Private Sub btHelp_Click(sender As System.Object, e As System.EventArgs)
        Dim _f = New fmHelp
        _f.ShowDialog(Me)
    End Sub
    ''' <summary>
    ''' изменить название дерева
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub bRenameTree_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bRenameTree.Click

        'ловим открытую вкладку
        Dim _tabTree = CType(Me.TabControl1.SelectedTab.Controls(0), ucHierarhy)

        Dim _name As String = InputBox("Новое имя. Введите имя АНГЛИЙСКОЕ. Это имя будет уникальным ключем для дерева", "переименовать дерево " & _tabTree.Tree.TreeKeyName & " (" & _tabTree.Tree.TreeKeyNameRUS & ")", _tabTree.Tree.TreeKeyName)
        Dim _nameRUS As String = InputBox("Новое имя. Введите имя РУССКОЕ. Это имя будет отображаться при выборе русского языка", "переименовать дерево " & _tabTree.Tree.TreeKeyName & " (" & _tabTree.Tree.TreeKeyNameRUS & ")", _tabTree.Tree.TreeKeyNameRUS)
        If _name.Length > 0 Then
            If Not _tabTree.Tree.TreeKeyName = _name Then
                With _tabTree.Tree
                    .TreeKeyNameRUS = _nameRUS
                    .TreeKeyName = _name
                End With

            ElseIf Not _tabTree.Tree.TreeKeyNameRUS = _nameRUS Then
                With _tabTree.Tree
                    .TreeKeyNameRUS = _nameRUS
                End With

            End If

        End If

        Me.CultureChangedEventHandler(_tabTree, New CultureChangedEventArgs With {.NewCulture = _tabTree.CurrentCulture, .OldCulture = _tabTree.CurrentCulture})

    End Sub
    Private Sub btClose_Click(sender As System.Object, e As System.EventArgs) Handles btClose.Click
        If oNeedToSave Then
            Me.btSaveFile_Click(sender, e)
        End If
        Me.Close()
    End Sub

    Private Sub btOpenTree_Click(sender As System.Object, e As System.EventArgs) Handles btOpenTree.Click
        Dim _fm = New fmDescription
        _fm.Show()
    End Sub

    Private oCulture As System.Globalization.CultureInfo

    Private Sub rtbDescription_Enter(sender As Object, e As System.EventArgs) Handles rtbDescription.Enter
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

    Private Sub rtbDescription_TextChanged(sender As System.Object, e As System.EventArgs) Handles rtbDescription.TextChanged
        If oManager Is Nothing Then Exit Sub
        If oManager.XMLDescriptionElement Is Nothing Then Return
        rtbDescription_parced.Text = clsTreeService.ParseDescriptionXML(oCulture, oManager.XMLDescriptionElement)

    End Sub

    Private Sub rbEngland_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbEngland.CheckedChanged
        If rbEngland.Checked Then
            oCulture = clsTreeManager.EnglishCulture
        Else
            oCulture = clsTreeManager.RussianCulture
        End If

        Call rtbDescription_TextChanged(sender, e)
    End Sub

    Private Sub rbRussian_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbRussian.CheckedChanged
        If rbRussian.Checked Then
            oCulture = clsTreeManager.RussianCulture
        Else
            oCulture = clsTreeManager.EnglishCulture
        End If

        Call rtbDescription_TextChanged(sender, e)
    End Sub




    Friend Event DescriptionAcceptedfmDescription(sender As Object, e As clsTreeService.DescriptionAcceptEventArg)

    Private Sub btCorrectID_Click(sender As Object, e As EventArgs) Handles btCorrectID.Click
        Select Case MsgBox("Эта СЛУЖЕБНАЯ операция изменит ID узлов дерева. Вы уверены?", MsgBoxStyle.YesNo)
            Case MsgBoxResult.Yes
                Dim _initialId = Integer.Parse(InputBox("Начать с ID", "", 0))
                Dim _lastID As Integer = 0
                Dim _respond = Me.oManager.CorrectIdTMP(_initialId, _lastID)
                MsgBox("начато с " & _initialId & " , следующий свободный " & _lastID & ", обработано связей " & _respond)
        End Select



    End Sub

    Private Sub rtbDescription_parced_Click(sender As Object, e As EventArgs) Handles rtbDescription_parced.Click

    End Sub

    Private Sub rtbDescription_parced_Enter(sender As Object, e As EventArgs) Handles rtbDescription_parced.Enter
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

    Private Sub rtbDescription_parced_TextChanged(sender As Object, e As EventArgs) Handles rtbDescription_parced.TextChanged

    End Sub
    ''' <summary>
    ''' сохраняет фото на печать
    ''' </summary>
    ''' <remarks></remarks>
    Private oLabelImageList As List(Of KeyValuePair(Of Image, SizeF))
    'Private ol As List(Of KeyValuePair(Of Image, SizeF))

    ''' <summary>
    ''' ловит событие добавления этикетки в печать
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub AddNodeToPrintEventHandler(sender As Object, e As clsTreeService.AddLabelToPrintEventArg)
        ' преобразовывает размеры в мм!!
        Dim _size As SizeF = Nothing
        If oLabelImageList Is Nothing Then
            oLabelImageList = New List(Of KeyValuePair(Of Image, SizeF))
        End If

        'а тут надо обработать фотки))
        If e.Image.Tag Is Nothing Then
            'так печатать внутренние фото, может изменить разрешение?
            Dim x = e.Image.Width / e.Image.HorizontalResolution * 25.4
            Dim y = e.Image.Height / e.Image.VerticalResolution * 25.4
            _size = New SizeF(x, y)
            Dim _img = e.Image
            oLabelImageList.Add(New KeyValuePair(Of Image, SizeF)(_img, _size))
        Else
            'получить полноразмерные фото - с папки данных
            Select Case IO.Path.GetExtension(e.Image.Tag)
                Case ".ai", ".pdf"
                    'через парсер иллюстратора
                    Dim _img = Service.clsApplicationTypes.GetPdfImageFromAIFile(e.Image.Tag, 300, 1, _size)
                    'привести 0,1мм в 1,0мм
                    _size = New SizeF(_size.Width / 10, _size.Height / 10)
                    oLabelImageList.Add(New KeyValuePair(Of Image, SizeF)(_img, _size))
                Case Else
                    'через парсер стандартного изображения
                    Dim x = e.Image.Width / e.Image.HorizontalResolution * 25.4
                    Dim y = e.Image.Height / e.Image.VerticalResolution * 25.4
                    _size = New SizeF(x, y)
                    Dim _img = clsApplicationTypes.GetResizedImageForTree(e.Image.Tag, True)
                    If _img Is Nothing Then Exit Sub
                    oLabelImageList.Add(New KeyValuePair(Of Image, SizeF)(_img, _size))
            End Select
        End If

        Me.btPrintLabel.Text = "Печать этикеток (" & oLabelImageList.Count & ")"


    End Sub


    Private Sub btPrintLabel_Click(sender As System.Object, e As System.EventArgs) Handles btPrintLabel.Click
        If oLabelImageList Is Nothing Then Exit Sub
        Dim _unit = GraphicsUnit.Millimeter

        Dim _pd As New Printing.PrintDocument
        Dim _LabelPages As New List(Of Service.clsPage)
        _pd.DocumentName = "Этикетки"

        'тут надо добавить настройку принтера
        Select Case Me.PrintDialog1.ShowDialog()
            Case Windows.Forms.DialogResult.OK
                _pd.PrinterSettings = Me.PrintDialog1.PrinterSettings
                '_pd.DefaultPageSettings.Margins = New Margins(50, 50, 50, 50)

                Dim _printbounds = _pd.PrinterSettings.CreateMeasurementGraphics
                _printbounds.PageUnit = _unit
                'теперь класс размещения этикеток
                Dim _page = New Service.clsPage(_printbounds.VisibleClipBounds)
                _LabelPages.Add(_page)

                'тут формируем обьект для печати
                For Each _str In Me.oLabelImageList

                    'добавить в существующий незаполненный
                    Dim _result = (From c In _LabelPages Where c.IsFull = False Select c).FirstOrDefault

                    If _result Is Nothing Then
                        'все полны
                        'создать новую страницу
                        'GoTo cr
                        _page = New Service.clsPage(_printbounds.VisibleClipBounds)
                        _LabelPages.Add(_page)
                        _page.AddLabel(_str)
                    Else
                        'пробуем
                        If _result.AddLabel(_str) = False Then
                            'не влазит
                            'создать новую страницу
                            'GoTo cr
                            _page = New Service.clsPage(_printbounds.VisibleClipBounds)
                            _LabelPages.Add(_page)
                            _page.AddLabel(_str)
                        End If
                    End If
                Next

                Dim _index As Integer = 0

                AddHandler _pd.PrintPage, Sub(senderv As Object, ev As PrintPageEventArgs)

                                              Dim _pagecount = _LabelPages.Count
                                              If _pagecount = 0 Then Exit Sub

                                              'print page
                                              _LabelPages(_index).DrawLabels(ev.Graphics, _unit)
                                              _index += 1
                                              If (_index + 1) > _pagecount Then ev.HasMorePages = False : _index = 0 : Exit Sub

                                              ev.HasMorePages = True
                                          End Sub

                Me.PrintPreviewDialog1.Document = _pd

                Select Case PrintPreviewDialog1.ShowDialog()
                    Case Windows.Forms.DialogResult.OK

                End Select
                ' PrintPreviewDialog1.Close()
        End Select



    End Sub

    'Private Sub pd_PrintPage(ByVal sender As Object, ByVal e As PrintPageEventArgs)
    '    Static _index As Integer = 0

    '    Dim _pagecount = oLabelPages.Count
    '    If _pagecount = 0 Then Exit Sub

    '    'print page
    '    oLabelPages(_index).DrawLabels(e.Graphics)
    '    _index += 1
    '    If (_index + 1) > _pagecount Then e.HasMorePages = False : _index = 0 : Exit Sub

    '    e.HasMorePages = True

    'End Sub




    Private Sub btClearPrintJob_Click(sender As System.Object, e As System.EventArgs) Handles btClearPrintJob.Click
        If oLabelImageList Is Nothing Then Exit Sub

        oLabelImageList.Clear()
        '_tmpGrafics.Clear()
        Me.btPrintLabel.Text = "Печать этикеток"
    End Sub

    Private Sub PrintPreviewDialog1_Load(sender As System.Object, e As System.EventArgs) Handles PrintPreviewDialog1.Load

    End Sub

    Private Sub UcHierarhySelectedNodeChangedEventHandler(sender As Object, e As ucHierarhy.SelectedNodeChangedArgs)
        'в эу изменилось выбранный узел
        If Not cbxFilterNode.Checked Then
            Me.cbxFilterNode.Text = e.NewSelectedNode.NodeNameByCulture(oCulture)
            Me.cbxFilterNode.Tag = e.NewSelectedNode
        End If
    End Sub
    Private oTabFlags As New Dictionary(Of String, Boolean)
    Private Sub cbxFilterNode_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles cbxFilterNode.CheckedChanged
        If Me.TabControl1.SelectedTab Is Nothing Then Exit Sub

        Dim _new As New Dictionary(Of String, Boolean)
        For Each t In oTabFlags.Keys
            _new.Add(t, False)
        Next
        oTabFlags = _new
        CType(Me.TabControl1.SelectedTab.Controls(0), ucHierarhy).BuildTreeView()
        oTabFlags(Me.TabControl1.SelectedTab.Name) = True
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        If Me.TabControl1.SelectedTab Is Nothing Then Exit Sub
        If oTabFlags(Me.TabControl1.SelectedTab.Name) = False Then
            CType(Me.TabControl1.SelectedTab.Controls(0), ucHierarhy).BuildTreeView()
            oTabFlags(Me.TabControl1.SelectedTab.Name) = True
        End If
    End Sub

    Private Sub cbFiles_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbFiles.SelectedIndexChanged
        'close file
        If oInitProc Then Return
        Me.btSaveFile.BackColor = Control.DefaultBackColor
        Me.oManager.ClearTreeCollection()
        If Me.TabControl1.TabPages.Count > 0 Then
            Me.TabControl1.TabPages.Clear()
            Me.oTabFlags.Clear()
        End If
        'open file
        btOpenFile_Click(Me, EventArgs.Empty)
    End Sub


End Class