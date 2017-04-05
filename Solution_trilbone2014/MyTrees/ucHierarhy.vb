Imports System
Imports System.IO
Imports Microsoft.SqlServer.Types
Imports Service

Friend Class ucHierarhy
    Private WithEvents oTree As ClsTree
    Private oCulture As System.Globalization.CultureInfo = System.Globalization.CultureInfo.GetCultureInfo("en-US")

    ''' <summary>
    ''' задает порядковый номер при добавлении нового узла в дереве
    ''' </summary>
    ''' <remarks></remarks>
    Private _newCount As Integer = 0

    ''' <summary>
    ''' этот вызов нужен только для конструктора компонентов
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        ' Этот вызов является обязательным для конструктора.
        InitializeComponent()
    End Sub
    ''' <summary>
    ''' инициализует данными ЭУ
    ''' </summary>
    ''' <param name="data"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal data As ClsTree)
        Debug.Assert(Not data Is Nothing)
        InitializeComponent()
        oTree = data
        AddHandler oTree.NodeNameCorrected, AddressOf NodeNameCorrectedEventHandler
        'Me.BuildTreeView()
    End Sub


    ''' <summary>
    ''' вернет данные ЭУ
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Tree As ClsTree
        Get
            Return oTree
        End Get
    End Property

    Public ReadOnly Property CurrentCulture As System.Globalization.CultureInfo
        Get
            Return oCulture
        End Get
    End Property

    Public Property ParentPage As TabPage

    ''' <summary>
    ''' родительское окно
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ParentFmDescription As fmDescription


    ''' <summary>
    ''' после редакции метки
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TreeView1_AfterLabelEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.NodeLabelEditEventArgs) Handles TreeView1.AfterLabelEdit
        Dim _obj = CType(Me.BindingSourceNodeObject.Current, NodeObject)
        If e.Label = "" Then e.CancelEdit = True : Exit Sub
        _obj.Name = e.Label
        Me.BindingSourceNodeObject.ResetBindings(False)
    End Sub
    ''' <summary>
    ''' счелчек мышью по дереву
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TreeView1_NodeMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles TreeView1.NodeMouseClick
        Select Case e.Button
            Case Windows.Forms.MouseButtons.Right
                With Me.TreeView1
                    .SelectedNode = e.Node
                End With
                Me.cmsAddItem.Show(MousePosition)

                'MsgBox(e.Clicks)
        End Select
    End Sub


    'Private Sub cmsAddItem_ItemClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles cmsAddItem.ItemClicked
    '    'здесь добавим узел
    '    Dim node As NodeObject = Me.TreeView1.SelectedNode.Tag

    '    Select Case e.ClickedItem.Text
    '        Case "Добавить потомка"
    '            Dim _new = Me.oTree.AddChildrenToNode(node.HierID)
    '            _new.Name = "NewNode " & _newCount.ToString.Trim
    '            _newCount += 1
    '            'добавить узел в дерево
    '            Dim ParentNode = Me.TreeView1.SelectedNode
    '            Dim NewNode = ParentNode.Nodes.Add(_new.Name)
    '            NewNode.Tag = _new
    '            'установить новое значение активным
    '            Me.TreeView1.SelectedNode = NewNode

    '        Case "Добавить предка"
    '            Dim _new = Me.oTree.AddAncesorNode(node.HierID)
    '            If Not _new Is Nothing Then
    '                _new.Name = "NewNode " & _newCount.ToString.Trim
    '                _newCount += 1
    '                'добавить узел в дерево
    '                Dim ParentTreeNode = Me.TreeView1.SelectedNode.Parent.Parent
    '                Dim NewNode = ParentTreeNode.Nodes.Add(_new.Name)
    '                NewNode.Tag = _new
    '                'установить новое значение активным
    '                Me.TreeView1.SelectedNode = NewNode
    '            Else
    '                MsgBox("Для этого уровня добавление предка невозможно", vbCritical, clsTreeManager.AppHeader)
    '            End If

    '        Case "Добавить в тот же уровень"
    '            Dim _new = Me.oTree.AddSameLevelToNode(node.HierID)
    '            'попробуем угадать имя
    '            Dim _start = node.Name.Split(" ")
    '            If _start.Count > 1 Then
    '                _new.Name = _start(0) & " "
    '            End If
    '            _new.Name += "NewNode " & _newCount.ToString.Trim

    '            _newCount += 1
    '            'добавить узел в дерево
    '            Dim ParentNode = Me.TreeView1.SelectedNode
    '            Dim NewNode As TreeNode
    '            If Not ParentNode.Parent Is Nothing Then
    '                NewNode = ParentNode.Parent.Nodes.Add(_new.Name)
    '            Else
    '                'добавка в корень
    '                NewNode = Me.TreeView1.Nodes.Add(_new.Name)
    '            End If

    '            NewNode.Tag = _new
    '            'установить новое значение активным
    '            Me.TreeView1.SelectedNode = NewNode

    '        Case "Удалить узел"
    '            If Not Me.oTree.DeleteNode(node) Then
    '                MsgBox("Не удалось удалить узел", MsgBoxStyle.Critical, "Удаление узла")
    '            End If
    '            Me.RefreshList()
    '            Me.TreeView1.ExpandAll()

    '        Case "Добавить фото"
    '            Me.cmsAddItem.Hide()
    '            Dim _ofd = Me.OpenFileDialog1
    '            _ofd.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
    '            _ofd.Filter = "фото|" & clsTreeManager.ImagePattern
    '            Select Case _ofd.ShowDialog(Me)
    '                Case Windows.Forms.DialogResult.OK

    '                    Dim _image = clsTreeManager.GetResizedImageForTree(_ofd.FileName)

    '                    If Not _image Is Nothing Then
    '                        Me.oTree.AttachImage(Me.BindingSource1.Current.HierID, _image)
    '                        Me.BindingSource1.ResetCurrentItem()
    '                    Else
    '                        MsgBox("не удалось загрузить фото", vbCritical, "Загрузка фото")
    '                    End If

    '            End Select

    '        Case "Удалить фото"
    '            Me.BindingSource1.Current.image = Nothing
    '            Me.BindingSource1.ResetCurrentItem()

    '        Case "Создать связь.."
    '            If Me.BindingSource1.Current Is Nothing Then Exit Sub
    '            Dim _fm As New fmAddLink(Me.BindingSource1.Current, Me.oCulture)
    '            _fm.ShowDialog(Me)

    '        Case "Копировать"
    '            My.Computer.Clipboard.SetData("specialFormat", node)
    '            Me.ВставитьToolStripMenuItem.Enabled = True
    '        Case "Вырезать"
    '            My.Computer.Clipboard.SetData("specialFormat", node)
    '            Me.ВставитьToolStripMenuItem.Enabled = True
    '            'удалить узел


    '        Case "Вставить"
    '            'добавить узел в потомки узла


    '        Case Else
    '            Debug.Fail("Для новой строки выпадающего меню действие НЕ ЗАДАНО")
    '    End Select



    'End Sub

    Private oSelectedNode As NodeObject

    ''' <summary>
    ''' смена узла в дереве
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TreeView1_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView1.AfterSelect

        Dim _oldSelectedNode = oSelectedNode

        oSelectedNode = CType(Me.TreeView1.SelectedNode.Tag, NodeObject)
        If Not oSelectedNode Is Nothing Then
            Me.BindingSourceNodeObject.DataSource = oSelectedNode
            Me.CreateDescription(oSelectedNode)
            RaiseEvent SelectedNodeChanged(Me, New SelectedNodeChangedArgs With {.OldSelectedNode = _oldSelectedNode, .NewSelectedNode = oSelectedNode})
            Dim _ai = Me.oTree.Parent.GetCountAIFiles(Me.oTree, oSelectedNode)
            If _ai = 0 Then
                Me.rbExternalLabel.Text = "этикетки"
            Else
                Me.rbExternalLabel.Text = "этикетки(" & _ai & ")"
            End If
            'Me.cbxFilterNode.Text = oSelectedNode.GetNameStringByCulture(oCulture)
        Else
            'Me.BindingSourceNodeObject.DataSource = Nothing
        End If

    End Sub
    Private oCurrentDescription As XElement
    ''' <summary>
    ''' сгенерировать описание
    ''' </summary>
    ''' <param name="node"></param>
    ''' <remarks></remarks>
    Private Sub CreateDescription(ByVal node As NodeObject)
        Debug.Assert(Not node Is Nothing)
        oCurrentDescription = node.GetDescriptionElement(Me.oCulture, Me.NumericUpDown1.Value)
        Me.rtbReadyDescription.Text = clsApplicationTypes.ParseNodeXML(oCurrentDescription)
    End Sub
    ''' <summary>
    ''' Обновить дерево
    ''' </summary>
    ''' <remarks></remarks>
    Friend Sub BuildTreeView()
        If Me.oTree Is Nothing Then Exit Sub

        Dim _sp = New SplashScreen1
        _sp.StartPosition = FormStartPosition.CenterScreen
        _sp.Show(Me)
        Application.DoEvents()
        'запомнить выбранный узел
        Dim _node As NodeObject = Nothing
        If Not Me.TreeView1.SelectedNode Is Nothing Then
            _node = TreeView1.SelectedNode.Tag
        End If


        Me.TreeView1.Nodes.Clear()

        Select Case Me.cbxShowLeaf.Checked
            Case True
                Me.TreeView1.Nodes.AddRange(oTree.CreateNodesForTreeView(Me.oCulture, True, Me.ParentFmDescription.FilterNode).ToArray)

            Case Else
                Me.TreeView1.Nodes.AddRange(oTree.CreateNodesForTreeView(Me.oCulture, False, Me.ParentFmDescription.FilterNode).ToArray)
        End Select


        'найти выбранный узел
        If Not _node Is Nothing Then
            SelectNode(_node)
        Else
            Me.TreeView1.ExpandAll()
            If Me.TreeView1.Nodes.Count > 0 Then
                Me.TreeView1.SelectedNode = Me.TreeView1.Nodes(0)
            End If
        End If
        If Not _sp Is Nothing Then
            _sp.Close()
        End If
    End Sub
    Private Sub btRefreshTree_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btRefreshTree.Click
        Me.BuildTreeView()
    End Sub


    ''' <summary>
    ''' задает уровень чтения вверх
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub NumericUpDown1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericUpDown1.ValueChanged
        If Me.TreeView1.SelectedNode Is Nothing Then Exit Sub
        Me.CreateDescription(CType(Me.TreeView1.SelectedNode.Tag, NodeObject))
    End Sub
    ''' <summary>
    ''' выбор языка
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        Dim _old = Me.oCulture
        If Me.RadioButton1.Checked Then
            If Not _old.IetfLanguageTag = "en-US" Then
                Me.oCulture = System.Globalization.CultureInfo.GetCultureInfo("en-US")
                RaiseEvent CultureChanged(Me, New CultureChangedEventArgs With {.OldCulture = _old, .NewCulture = Me.oCulture})

            End If

        Else
            If Not _old.IetfLanguageTag = "ru-RU" Then
                Me.oCulture = System.Globalization.CultureInfo.GetCultureInfo("ru-RU")
                RaiseEvent CultureChanged(Me, New CultureChangedEventArgs With {.OldCulture = _old, .NewCulture = Me.oCulture})

            End If

        End If

        Me.cbxShowLeaf_CheckedChanged(Me, e)


    End Sub
    ''' <summary>
    ''' выбор языка
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged

        Dim _old = Me.oCulture

        'Me.cbxShowLeaf.Checked = False

        If Not Me.RadioButton2.Checked Then
            If Not _old.IetfLanguageTag = "en-US" Then
                Me.oCulture = System.Globalization.CultureInfo.GetCultureInfo("en-US")
                RaiseEvent CultureChanged(Me, New CultureChangedEventArgs With {.OldCulture = _old, .NewCulture = Me.oCulture})
            End If

        Else
            If Not _old.IetfLanguageTag = "ru-RU" Then
                Me.oCulture = System.Globalization.CultureInfo.GetCultureInfo("ru-RU")
                RaiseEvent CultureChanged(Me, New CultureChangedEventArgs With {.OldCulture = _old, .NewCulture = Me.oCulture})
            End If

        End If
        Me.cbxShowLeaf_CheckedChanged(Me, e)

        'Me.RefreshList()
    End Sub

    ''' <summary>
    ''' Описывает событие принятия описания узла
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Event DescriptionAcceptUcHierarhy(sender As Object, e As clsTreeService.DescriptionAcceptEventArg)
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Event CultureChanged(ByVal sender As Object, ByVal e As CultureChangedEventArgs)
    ''' <summary>
    ''' Описывает событие добавления узла в список печати этикеток
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Event AddNodeToPrint(sender As Object, e As clsTreeService.AddLabelToPrintEventArg)


    Public Event SelectedNodeChanged(sender As Object, e As SelectedNodeChangedArgs)


    Friend Class SelectedNodeChangedArgs
        Inherits EventArgs

        Public OldSelectedNode As NodeObject
        Public NewSelectedNode As NodeObject

    End Class


    ''' <summary>
    ''' описание принято
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btAddDescr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btAddDescr.Click
        'создать описание 
        If oSelectedNode Is Nothing Then Exit Sub
        Dim _nodeList As New List(Of NodeObject)
        Dim _arg As clsTreeService.DescriptionAcceptEventArg
        'если элемент имеет артикул, то вызвать для всех узлов из артикула
        If oSelectedNode.HasTiedNodes Then
            _nodeList = oSelectedNode.GetTiedNodes
        Else
            _nodeList.Add(oSelectedNode)
        End If

        For Each t In _nodeList
            _arg = New clsTreeService.DescriptionAcceptEventArg(t.GetDescriptionElement(Me.CurrentCulture, Me.NumericUpDown1.Value), Me.CurrentCulture)
            RaiseEvent DescriptionAcceptUcHierarhy(Me, _arg)
        Next
    End Sub

    Private Sub NameTextBox_LostFocus(sender As Object, e As System.EventArgs) Handles NameTextBox.LostFocus
        Dim _node = Me.TreeView1.SelectedNode
        Dim _oldName As String = NameTextBox.Text
        NameTextBox.Text = NameTextBox.Text.Trim
        'меняем текс выделеного узла
        If Not _node Is Nothing Then
            _node.Text = NameTextBox.Text
            'провека допустимости знаков в названии узла
            Dim _list = IO.Path.GetInvalidFileNameChars()
            Dim _newName As New List(Of Char)

            For Each s In _oldName.ToCharArray
                If _list.Contains(s) Then
                    _newName.Add(" ")
                Else
                    _newName.Add(s)
                End If
            Next

            If Not _oldName = String.Concat(_newName) Then
                'изменить имя
                NameTextBox.Text = String.Concat(_newName).Trim
                _node.Text = NameTextBox.Text
                BuildTreeView()
            End If
        End If
    End Sub

    Private Function ThumbnailCallback() As Boolean
        Return False
    End Function



    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BindingSourceNodeObject_CurrentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindingSourceNodeObject.CurrentChanged
        Select Case IsNothing(Me.BindingSourceNodeObject.Current)
            Case True
                'Dim _CurrNode As NodeObject = CType(Me.BindingSource1.Current, NodeObject)
                'Me.cmsAddItem.Enabled = True
            Case False
                Dim _tmpNodeObj = CType(Me.BindingSourceNodeObject.Current, Trilbone.NodeObject)
                Me.lbFullPath.Text = "Path: " & _tmpNodeObj.FullPath & "; ID: " & CType(Me.BindingSourceNodeObject.Current, Trilbone.NodeObject).id
                rbInnerImg.Checked = True
        End Select
    End Sub

    ''' <summary>
    ''' select image
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BindingNavigatorImages_RefreshItems(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindingNavigatorImages.RefreshItems
        If (Not Me.BindingNavigatorImages.BindingSource Is Nothing) AndAlso (Not Me.BindingNavigatorImages.BindingSource.Current Is Nothing) AndAlso TypeOf Me.BindingNavigatorImages.BindingSource.Current Is Image Then
            Me.PictureBox1.Image = Me.BindingNavigatorImages.BindingSource.Current
        Else
            Me.PictureBox1.Image = Nothing
        End If

    End Sub

    ''' <summary>
    ''' добавить фото
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ImageBindingSource_AddingNew(ByVal sender As Object, ByVal e As System.ComponentModel.AddingNewEventArgs) Handles ImageBindingSource.AddingNew
        If Me.BindingSourceNodeObject.Current Is Nothing Then Exit Sub
        Select Case ImageBindingSource.DataSource.GetType
            Case Me.BindingSourceNodeObject.GetType
                'привязано к внутреннему списку. Ничего не делаем.
            Case GetType(List(Of Image))
                MsgBox("Для добавления файла следует использовать кнопку доб. файл", vbInformation)
                Exit Sub
        End Select

        Dim _curr = CType(Me.BindingSourceNodeObject.Current, NodeObject)

        Dim _ofd = Me.OpenFileDialog1
        With _ofd
            .InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
            .Filter = "фото|*.jpg;*.jpeg;*.png;*.tiff;*.gif;*.bmp;*.tif"
            .Multiselect = True
        End With

        Select Case _ofd.ShowDialog(Me)
            Case Windows.Forms.DialogResult.OK
                Application.DoEvents()
                Me.Cursor = Cursors.WaitCursor
                For Each _selFile In _ofd.FileNames
                    Dim _image = clsApplicationTypes.GetResizedImageForTree(_selFile)
                    If Not _image Is Nothing Then
                        'скопировать файл в папку узла
                        Dim _newName = Me.oTree.Parent.AttachDataFile(Me.oTree, _curr, _selFile)
                        If _newName = "" Then
                            'проблема при копировании файла!
                            MsgBox("не удалось скопировать фото в папку данных", vbCritical, "Загрузка фото")
                        Else
                            'загрузить фото в дерево
                            If Me.oTree.AttachImage(_curr, _image, _newName) = True Then
                                e.NewObject = _image
                                Me.BindingSourceNodeObject.ResetCurrentItem()
                                Me.ImageBindingSource.MoveLast()
                            Else
                                'проблема при добавлении фото к дереву
                                MsgBox("не удалось добавить фото к дереву", vbCritical, "Загрузка фото")
                            End If
                        End If
                    Else
                        MsgBox("не удалось загрузить фото", vbCritical, "Загрузка фото")
                    End If
                Next
                Me.Cursor = Me.DefaultCursor

            Case Else

                Dim _pt As Image = New Bitmap(300, 300, Imaging.PixelFormat.Format24bppRgb)
                Dim _gr = Graphics.FromImage(_pt)

                _gr.DrawString("Удалите это изображение", New Font([Font].SystemFontName, 12), Brushes.Red, New PointF(10, 10))
                e.NewObject = _pt
        End Select
    End Sub


    Private Sub btCopyName_Click(sender As System.Object, e As System.EventArgs) Handles btCopyName.Click
        If Me.BindingSourceNodeObject.Current Is Nothing Then Exit Sub
        Dim _curr = CType(Me.BindingSourceNodeObject.Current, NodeObject)

        _curr.NameRUS = Me.NameTextBox.Text
    End Sub

    Private Sub btCopyDescr_Click(sender As System.Object, e As System.EventArgs) Handles btCopyDescr.Click
        If Me.BindingSourceNodeObject.Current Is Nothing Then Exit Sub
        Dim _curr = CType(Me.BindingSourceNodeObject.Current, NodeObject)
        _curr.DescrRUS = Me.DescrRichTextBox.Text
    End Sub

    Private Sub rbOnlyNodeName_CheckedChanged(sender As System.Object, e As System.EventArgs)
        If Me.BindingSourceNodeObject.Current Is Nothing Then Exit Sub
        Dim _curr = CType(Me.BindingSourceNodeObject.Current, NodeObject)
        Me.CreateDescription(_curr)
    End Sub

    Private Sub rbFullDescr_CheckedChanged(sender As System.Object, e As System.EventArgs)
        If Me.BindingSourceNodeObject.Current Is Nothing Then Exit Sub
        Dim _curr = CType(Me.BindingSourceNodeObject.Current, NodeObject)
        Me.CreateDescription(_curr)
    End Sub

    Private Sub InsertToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles InsertToolStripMenuItem.Click
        If TypeOf (cmsStandart.SourceControl) Is Windows.Forms.RichTextBox Then
            Dim _ctl = CType(cmsStandart.SourceControl, Windows.Forms.RichTextBox)
            If My.Computer.Clipboard.ContainsText Then
                _ctl.Paste()
            End If
        End If
        If TypeOf (cmsStandart.SourceControl) Is Windows.Forms.PictureBox Then
            If Me.BindingSourceNodeObject.Current Is Nothing Then Exit Sub

            Dim _ctl = CType(cmsStandart.SourceControl, Windows.Forms.PictureBox)
            If My.Computer.Clipboard.ContainsImage Then
                Dim _image = My.Computer.Clipboard.GetImage
                _ctl.Image = _image
                My.Computer.Clipboard.Clear()
                Dim _path = IO.Path.ChangeExtension(My.Computer.FileSystem.GetTempFileName, ".jpg")
                _image.Save(_path)

                Dim _curr = CType(Me.BindingSourceNodeObject.Current, NodeObject)
                'скопировать файл в папку узла
                Dim _newName = Me.oTree.Parent.AttachDataFile(Me.oTree, _curr, _path)

                If _newName = "" Then
                    'проблема при копировании файла!
                    MsgBox("не удалось скопировать фото в папку данных", vbCritical, "Загрузка фото")
                Else
                    'загрузить фото в дерево
                    If Me.oTree.AttachImage(_curr, _ctl.Image, _newName) = True Then
                        Me.BindingSourceNodeObject.ResetCurrentItem()
                        Me.ImageBindingSource.MoveLast()
                    Else
                        'проблема при добавлении фото к дереву
                        MsgBox("не удалось добавить фото к дереву", vbCritical, "Загрузка фото")
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub CopyToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles CopyToolStripMenuItem1.Click
        If TypeOf (cmsStandart.SourceControl) Is Windows.Forms.RichTextBox Then
            Dim _ctl = CType(cmsStandart.SourceControl, Windows.Forms.RichTextBox)
            _ctl.Copy()
        End If
    End Sub



    'Private Sub TreeView1_ItemDrag(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemDragEventArgs) Handles TreeView1.ItemDrag
    '    ' Move the dragged node when the left mouse button is used.
    '    If e.Button = MouseButtons.Left Then
    '        TreeView1.DoDragDrop(e.Item, DragDropEffects.All)

    '        ' Copy the dragged node when the right mouse button is used.
    '    ElseIf e.Button = MouseButtons.Right Then
    '        DoDragDrop(e.Item, DragDropEffects.Copy)
    '    End If
    'End Sub

    ''Private Sub TreeView1_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles TreeView1.DragEnter
    ''    e.Effect = e.AllowedEffect
    ''End Sub



    'Private Sub TreeView1_DragOver(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles TreeView1.DragOver
    '    ' Retrieve the client coordinates of the mouse position.
    '    Dim targetPoint As Point = TreeView1.PointToClient(New Point(e.X, e.Y))
    '    e.Effect = DragDropEffects.Copy
    '    ' Select the node at the mouse position.
    '    TreeView1.SelectedNode = TreeView1.GetNodeAt(targetPoint)
    'End Sub

    'Private Sub TreeView1_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles TreeView1.DragDrop
    '    ' Retrieve the client coordinates of the drop location.
    '    Dim targetPoint As Point = TreeView1.PointToClient(New Point(e.X, e.Y))

    '    ' Retrieve the node at the drop location.
    '    Dim targetNode As TreeNode = TreeView1.GetNodeAt(targetPoint)

    '    ' Retrieve the node that was dragged.
    '    Dim draggedNode As TreeNode = CType(e.Data.GetData(GetType(TreeNode)), TreeNode)

    '    ' Confirm that the node at the drop location is not 
    '    ' the dragged node or a descendant of the dragged node.
    '    If Not draggedNode.Equals(targetNode) AndAlso Not ContainsNode(draggedNode, targetNode) Then

    '        ' If it is a move operation, remove the node from its current 
    '        ' location and add it to the node at the drop location.
    '        If e.Effect = DragDropEffects.Move Then
    '            'draggedNode.Remove()
    '            'targetNode.Nodes.Add(draggedNode)
    '            MsgBox("will be remove " & CType(draggedNode.Tag, NodeObject).Name)
    '            MsgBox("be add to " & CType(targetNode.Tag, NodeObject).Name)
    '            ' If it is a copy operation, clone the dragged node 
    '            ' and add it to the node at the drop location.
    '        ElseIf e.Effect = DragDropEffects.Copy Then
    '            'targetNode.Nodes.Add(CType(draggedNode.Clone(), TreeNode))
    '            MsgBox("be add to " & CType(targetNode.Tag, NodeObject).Name)
    '        End If

    '        ' Expand the node at the location 
    '        ' to show the dropped node.
    '        targetNode.Expand()
    '    End If
    'End Sub

    ' Determine whether one node is a parent 
    ' or ancestor of a second node.
    Private Function ContainsNode(ByVal node1 As TreeNode, ByVal node2 As TreeNode) As Boolean

        ' Check the parent node of the second node.
        If node2.Parent Is Nothing Then
            Return False
        End If
        If node2.Parent.Equals(node1) Then
            Return True
        End If

        ' If the parent node is not null or equal to the first node, 
        ' call the ContainsNode method recursively using the parent of 
        ' the second node.
        Return ContainsNode(node1, node2.Parent)
    End Function 'ContainsNode
    ''' <summary>
    ''' добавить потомка
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ДобавитьДоУзлаToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ДобавитьДоУзлаToolStripMenuItem.Click
        Dim _new = Me.oTree.AddChildrenToNode(oSelectedNode, "NewNode" & _newCount.ToString.Trim)
        _newCount += 1
        'добавить узел в дерево
        Dim ParentNode = Me.TreeView1.SelectedNode
        Dim NewNode = ParentNode.Nodes.Add(_new.Name)
        NewNode.Tag = _new
        'установить новое значение активным
        Me.TreeView1.SelectedNode = NewNode
        Me.TreeView1.SelectedNode.Parent.Expand()
    End Sub

    Private Sub ДобавитьПослеУзлаToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ДобавитьПослеУзлаToolStripMenuItem.Click
        If oSelectedNode Is Nothing Then Return
        '-----------------------
        Dim _name As String = ""
        'попробуем угадать имя
        Dim _start = oSelectedNode.Name.Split(" ")
        If _start.Count > 1 Then
            _name = _start(0) & " "
        End If
        _name += "NewNode" & _newCount.ToString.Trim
        Dim _new = Me.oTree.AddSameLevelToNode(oSelectedNode, _name)
        _newCount += 1
        '--------------------
        'добавить узел в дерево
        Dim ParentNode = Me.TreeView1.SelectedNode
        Dim NewNode As TreeNode
        If Not ParentNode.Parent Is Nothing Then
            NewNode = ParentNode.Parent.Nodes.Add(_new.Name)
        Else
            'добавка в корень
            NewNode = Me.TreeView1.Nodes.Add(_new.Name)
        End If
        NewNode.Tag = _new

        'установить новое значение активным
        Me.TreeView1.SelectedNode = NewNode
        Me.TreeView1.SelectedNode.Parent.Expand()
    End Sub

    Private Sub УдалитьУзелToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles УдалитьУзелToolStripMenuItem.Click
        If Not Me.oTree.DeleteNode(oSelectedNode) Then
            MsgBox("Не удалось удалить узел", MsgBoxStyle.Critical, "Удаление узла")
        End If

        Dim _tmp = Me.TreeView1.SelectedNode.Parent
        Me.TreeView1.Nodes.Remove(Me.TreeView1.SelectedNode)
        Me.TreeView1.SelectedNode = _tmp
        Me.btRefreshTree_Click(sender, e)
        'Me.RefreshList()
        'Me.TreeView1.ExpandAll()
    End Sub

    Private Sub СоздатьСвязьToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles СоздатьСвязьToolStripMenuItem.Click
        If Me.BindingSourceNodeObject.Current Is Nothing Then Exit Sub
        Dim _fm As New fmAddLink(Me.BindingSourceNodeObject.Current, Me.oCulture)
        _fm.ShowDialog(Me)
    End Sub

    Private Sub ДобавитьПредкаToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ДобавитьПредкаToolStripMenuItem.Click
        If oSelectedNode Is Nothing Then Exit Sub
        Dim _new = Me.oTree.AddAncesorNode(oSelectedNode, "NewNode" & _newCount.ToString.Trim)
        If Not _new Is Nothing Then
            _newCount += 1
            Dim _newTreeNode As TreeNode
            'добавить узел в дерево
            Dim _ParentTreeNode = Me.TreeView1.SelectedNode.Parent
            Dim _sn = Me.TreeView1.SelectedNode

            If Not _ParentTreeNode Is Nothing Then
                _newTreeNode = _ParentTreeNode.Nodes.Add(_new.Name)
                _newTreeNode.Tag = _new
            Else
                ' добавка в корень
                _newTreeNode = Me.TreeView1.Nodes.Add(_new.Name)
                _newTreeNode.Tag = _new
            End If
            Dim _on = _newTreeNode.Nodes.Add(_sn.Text)
            _on.Tag = _sn.Tag
            Application.DoEvents()
            Me.TreeView1.Nodes.Remove(_sn)
            '-------------------------------------
            'установить новое значение активным
            Me.TreeView1.SelectedNode = _on

            Me.btRefreshTree_Click(sender, e)
        Else
            MsgBox("Для этого уровня добавление предка невозможно", vbCritical, clsTreeManager.AppHeader)
        End If
    End Sub

    Private Sub КопироватьToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        My.Computer.Clipboard.SetData("TreeNodeObj", oSelectedNode)
        'Me.ВставитьToolStripMenuItem.Enabled = True
    End Sub

    Private Sub ВырезатьToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ВырезатьToolStripMenuItem.Click
        My.Computer.Clipboard.SetData("TreeNodeObj", oSelectedNode)
        'Me.ВставитьToolStripMenuItem.Enabled = True
        ''"удалить" узел только из дерева))
        Me.TreeView1.Nodes.Remove(Me.TreeView1.SelectedNode)
        Me.ВырезатьToolStripMenuItem.Enabled = False

    End Sub

    Private Sub ВставитьToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ВставитьToolStripMenuItem.Click
        'извлечь обьект
        If My.Computer.Clipboard.ContainsData("TreeNodeObj") Then
            'принят узел из этого дерева
            Dim _obj As NodeObject
            _obj = CType(My.Computer.Clipboard.GetData("TreeNodeObj"), NodeObject)

            _obj = (From c In oTree.NodeCollection Where c.id = _obj.id).FirstOrDefault

            oTree.MoveSubTree(_obj, oSelectedNode, True)

            'Me.ВставитьToolStripMenuItem.Enabled = False
            Me.ВырезатьToolStripMenuItem.Enabled = True

        ElseIf My.Computer.Clipboard.ContainsData("TreeNodeObjSubTree") Then
            'принято поддерево из другого дерева!
            Using _obj As NodeObject.NodeObjectSubTree = CType(My.Computer.Clipboard.GetData("TreeNodeObjSubTree"), NodeObject.NodeObjectSubTree)
                _obj.PasteMeIntoParentTree(oSelectedNode)
            End Using
            '_obj = CType(My.Computer.Clipboard.GetData("TreeNodeObjSubTree"), NodeObject.NodeObjectSubTree)

        Else
            MsgBox("Данные не подходят для вставки!", vbCritical)
            Exit Sub
        End If


        My.Computer.Clipboard.Clear()

        'обновить дерево
        BuildTreeView()


    End Sub


    Private Sub TreeView1_NodeMouseDoubleClick(sender As Object, e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles TreeView1.NodeMouseDoubleClick
        'отображение связей
        If IsNothing(e.Node) Then Exit Sub
        If Me.TreeView1.SelectedNode Is Nothing Then Exit Sub
        Dim _node = CType(Me.TreeView1.SelectedNode.Tag, NodeObject)
        If _node Is Nothing Then Exit Sub

        Dim _fm = New fmLinks(_node, Me.oCulture)

        AddHandler _fm.SelectAcceptedfmLink, AddressOf Me.DescriptionAcceptfmLink_eventHandler
        AddHandler _fm.ArticulNodeCreated, AddressOf Me.ArticulNodeCreated_eventHandler
        _fm.ShowDialog(Me)


    End Sub

    Private Sub ArticulNodeCreated_eventHandler(sender As Object, e As clsTreeService.NodeCreatedEventArg)
        'добавить узел в дерево
        Dim ParentNode = Me.TreeView1.SelectedNode
        Dim NewNode = ParentNode.Nodes.Add(e.NewNode.Name)
        NewNode.Tag = e.NewNode
        ''установить новое значение активным
        'Me.TreeView1.SelectedNode = NewNode
        'Me.TreeView1.SelectedNode.Parent.Expand()
    End Sub



    ''' <summary>
    ''' handles event fmLinks
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub DescriptionAcceptfmLink_eventHandler(sender As Object, e As clsTreeService.DescriptionAcceptEventArg)
        RaiseEvent DescriptionAcceptUcHierarhy(Me, New clsTreeService.DescriptionAcceptEventArg(e.DescriptionXelements, CurrentCulture))
    End Sub

    ''' <summary>
    ''' поиск по дереву
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btSearch_Click(sender As System.Object, e As System.EventArgs) Handles btSearch.Click
        'Dim _node = (From c In Me.oTree.NodeCollection Where c.Name.Contains(Me.tbSearch.Text) Select c).ToList
        If Me.tbSearch.Text.Length = 0 Then
            Exit Sub
        End If

        Dim _res = Tree.SearchNodeByCulture(Me.tbSearch.Text.Trim, CurrentCulture)
        'выделим первый
        If _res.Count > 0 Then
            Me.lbSearchResult.Text = "найдено " & _res.Count & " вхождений"
            nudSearchResult.Maximum = _res.Count
            nudSearchResult.Minimum = 1
            nudSearchResult.Tag = _res
            nudSearchResult.Enabled = True
            nudSearchResult.Value = 1
            SelectNode(_res.First, Me.TreeView1.Nodes(0))
        Else
            Me.lbSearchResult.Text = "не найдено"
            nudSearchResult.Enabled = False
            nudSearchResult.Tag = Nothing
            nudSearchResult.Minimum = 0
            nudSearchResult.Maximum = 0
            nudSearchResult.Value = 0
            'MsgBox("Не найдено!", MsgBoxStyle.Critical)
        End If
    End Sub
    ''' <summary>
    ''' выделяет определенный узел дерева
    ''' </summary>
    ''' <param name="node"></param>
    ''' <remarks></remarks>
    Public Overloads Sub SelectNode(node As NodeObject, Optional _treeNode As Windows.Forms.TreeNode = Nothing)
        If Me.TreeView1.Nodes.Count = 0 Then Exit Sub

        'If _treeNode.Tag Is Nothing Then Exit Sub
        If _treeNode Is Nothing Then
            If Me.TreeView1.TopNode Is Nothing Then
                If Not Me.TreeView1.Nodes(0) Is Nothing Then
                    SelectNode(node, Me.TreeView1.Nodes(0))
                End If
            Else
                SelectNode(node, Me.TreeView1.TopNode)
            End If
        ElseIf Not _treeNode.Tag Is Nothing Then

            If _treeNode.Tag.Equals(node) Then
                Me.TreeView1.Select()
                Me.TreeView1.SelectedNode = _treeNode
                Me.TreeView1.SelectedNode.Expand()
                Exit Sub
            Else
                Select Case Me.cbxShowLeaf.Checked
                    Case True
                        'ищем в листьях
                        Dim _result = (From c As Windows.Forms.TreeNode In Me.TreeView1.Nodes Where c.Tag.Equals(node) Select c).FirstOrDefault
                        If Not _result Is Nothing Then
                            Me.TreeView1.Select()
                            Me.TreeView1.SelectedNode = _result
                            Me.TreeView1.SelectedNode.Expand()
                            Exit Sub
                        Else
                            'not found
                            Exit Sub
                        End If
                    Case False
                        'ищем в дереве
                        For Each c In _treeNode.Nodes
                            SelectNode(node, c)
                        Next
                End Select
            End If
        End If

    End Sub


    ' ''' <summary>
    ' ''' выделяет узел дерева по NodeObject
    ' ''' </summary>
    ' ''' <param name="node"></param>
    ' ''' <param name="_treeNode"></param>
    ' ''' <remarks></remarks>
    'Private Overloads Sub SelectNode(node As NodeObject, _treeNode As Windows.Forms.TreeNode)

    '    If _treeNode.Tag.Equals(node) Then
    '        Me.TreeView1.Select()
    '        Me.TreeView1.SelectedNode = _treeNode
    '        Me.TreeView1.SelectedNode.Expand()
    '        Exit Sub
    '    End If

    '    For Each c In _treeNode.Nodes
    '        SelectNode(node, c)
    '    Next
    'End Sub


    ' ''' <summary>
    ' ''' разворачивает узел и ищет в нем строку search. Если находит - вернет коллекцию узлов, если нет - вернет пустую
    ' ''' </summary>
    ' ''' <param name="search"></param>
    ' ''' <param name="treeNode"></param>
    ' ''' <returns></returns>
    ' ''' <remarks></remarks>
    'Private Function SearchInTree(search As String, treeNode As TreeNode, Optional start As Boolean = False) As List(Of TreeNode)
    '    Static _res As New List(Of TreeNode)
    '    If start Then
    '        _res.Clear()
    '    End If

    '    'ишем в узлах коллекции


    '    'Me.TreeView1.BeginUpdate()
    '    'treeNode.Expand()
    '    Dim _result = (From c As TreeNode In treeNode.Nodes Where c.Text.ToLower.Contains(search.ToLower) = True Select c).ToList



    '    If _result.Count > 0 Then
    '        _res.AddRange(_result)
    '    End If
    '    'рекурсия
    '    For Each c In treeNode.Nodes
    '        SearchInTree(search, c)
    '    Next

    '    If _result.Count = 0 Then
    '        'пробуем найти далее
    '        _result = (From c As TreeNode In Me.TreeView1.Nodes Where c.Text.ToLower.Contains(search) = True Select c).ToList
    '        If _result.Count > 0 Then
    '            _res.AddRange(_result)
    '        End If

    '    End If

    '    Return _res
    'End Function

    'Private Sub КоррекциявыбратьВерхнийToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles КоррекциявыбратьВерхнийToolStripMenuItem.Click
    '    Dim _right = oSelectedNode
    '    'выбрать братьев с тем же HierID
    '    Dim _corr = From c In oTree.NodeCollection Where c.HierID.Equals(_right.HierID) Select c

    '    If _corr.Count > 0 Then
    '        For Each _node In _corr
    '            Dim _t = Me.oTree.CorrectHierID(_right.HierID)
    '            oTree.MoveChild(_node.HierID, _t)
    '            _node.HierID = _t
    '        Next
    '    End If


    'End Sub

    Private Sub BindingNavigatorAddNewItem_Click(sender As System.Object, e As System.EventArgs) Handles BindingNavigatorAddNewItem.Click
        'смотри ImageBindingSource_AddingNew
    End Sub

    Private Sub NodeNameCorrectedEventHandler(sender As Object, e As EventArgs)
        BuildTreeView()
    End Sub


    Private Sub btShowAll_Click(sender As System.Object, e As System.EventArgs) Handles btShowAll.Click
        Me.TreeView1.ExpandAll()
    End Sub

    Private Sub cbxShowLeaf_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles cbxShowLeaf.CheckedChanged
        BuildTreeView()
    End Sub


    Private Sub КопироватьПоддеревоToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles КопироватьПоддеревоToolStripMenuItem.Click
        'копировать в буфер поддерево
        Dim _st = New NodeObject.NodeObjectSubTree
        _st.Add(oSelectedNode)
        My.Computer.Clipboard.SetData("TreeNodeObjSubTree", _st)
        Dim _out = CType(My.Computer.Clipboard.GetData("TreeNodeObjSubTree"), NodeObject.NodeObjectSubTree)
        MsgBox(_out.ToString, vbInformation, "Скопированные в буфер узлы")
    End Sub



    Private Sub btAddDescrMUI_Click(sender As System.Object, e As System.EventArgs) Handles btAddDescrMUI.Click
        'создать описание для двух языков
        If oSelectedNode Is Nothing Then Exit Sub
        Dim _nodeList As New List(Of NodeObject)
        Dim _arg As clsTreeService.DescriptionAcceptEventArg
        'если элемент имеет артикул из двух и более узлов, то вызвать для всех узлов из артикула
        If oSelectedNode.HasTiedNodes AndAlso oSelectedNode.GetTiedNodes.Count > 1 Then
            _nodeList = oSelectedNode.GetTiedNodes
        Else
            _nodeList.Add(oSelectedNode)
        End If

        For Each t In _nodeList
            _arg = New clsTreeService.DescriptionAcceptEventArg(t.GetDescriptionElement(clsTreeManager.EnglishCulture, Me.NumericUpDown1.Value), clsTreeManager.EnglishCulture)
            RaiseEvent DescriptionAcceptUcHierarhy(Me, _arg)

            _arg = New clsTreeService.DescriptionAcceptEventArg(t.GetDescriptionElement(clsTreeManager.RussianCulture, Me.NumericUpDown1.Value), clsTreeManager.RussianCulture)
            RaiseEvent DescriptionAcceptUcHierarhy(Me, _arg)
        Next

    End Sub

    Private Sub ucHierarhy_GotFocus(sender As Object, e As System.EventArgs) Handles Me.GotFocus
        'получение фокуса. проверка фильтра.
        If Me.ParentFmDescription.FilterNode Is Nothing Then Exit Sub
        Me.BuildTreeView()
        'применить фильтр

    End Sub

    Private Sub ucHierarhy_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btNodeImport_Click(sender As Object, e As EventArgs) Handles btNodeImport.Click
        'открыть форму импорта узлов и получить из нее коллекцию выбранных ImportsObject
        'присоединить каждый элемент (узел) коллекции к активному узлу Me.oSelectedNode как дочерний узел
        'присоединить к узлу после присоединения к дереву (для получения ID) коллекцию файлов


    End Sub

    Private Sub tbSearch_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tbSearch.KeyPress
        Select Case Asc(e.KeyChar)
            Case 13
                btSearch_Click(sender, EventArgs.Empty)
        End Select
    End Sub

    Private Sub tbSearch_TextChanged(sender As System.Object, e As System.EventArgs) Handles tbSearch.TextChanged

    End Sub

    Private Sub nudSearchResult_ValueChanged(sender As System.Object, e As System.EventArgs) Handles nudSearchResult.ValueChanged
        If Not nudSearchResult.Tag Is Nothing Then
            Dim _pos As List(Of NodeObject) = nudSearchResult.Tag
            If nudSearchResult.Maximum = _pos.Count AndAlso nudSearchResult.Value > 0 Then
                SelectNode(_pos(nudSearchResult.Value - 1), Me.TreeView1.Nodes(0))
            Else
                nudSearchResult.Maximum = 1
                nudSearchResult.Enabled = False
            End If

        End If
    End Sub

    Private Sub КопироватьУзелToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles КопироватьУзелToolStripMenuItem.Click
        Dim _new = Me.oTree.CopyNode(oSelectedNode)

        _newCount += 1
        'добавить узел в дерево
        Dim ParentNode = Me.TreeView1.SelectedNode
        Dim NewNode As TreeNode
        If Not ParentNode.Parent Is Nothing Then
            NewNode = ParentNode.Parent.Nodes.Add(_new.Name)
        Else
            'добавка в корень
            NewNode = Me.TreeView1.Nodes.Add(_new.Name)
        End If

        NewNode.Tag = _new
        'установить новое значение активным
        Me.TreeView1.SelectedNode = NewNode
        Me.TreeView1.SelectedNode.Parent.Expand()
    End Sub

    Private Sub rbInnerImg_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbInnerImg.CheckedChanged
        If rbInnerImg.Checked Then
            'показать внутренние изображения
            Me.ImageBindingSource.DataSource = Me.BindingSourceNodeObject
            Me.ImageBindingSource.DataMember = "image"
            Me.ImageBindingSource.ResetBindings(True)
        End If
    End Sub

    Private Sub rbExternalImage_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbExternalImage.CheckedChanged
        If rbExternalImage.Checked Then
            'показать внешние изображения
            'создать список файлов
            'получить лист фото
            Me.ImageBindingSource.DataSource = Me.oTree.Parent.GetDataFolderImagesForNode(Me.oTree, Me.oSelectedNode)
            'Me.ImageBindingSource.DataMember = "image"
            Me.ImageBindingSource.ResetBindings(True)
        End If

    End Sub

    Private Sub rbExternalLabel_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbExternalLabel.CheckedChanged
        If rbExternalLabel.Checked Then
            'показать этикетки
            'создать список файлов
            'получить лист фото
            Dim _sp = New SplashScreen1
            _sp.Show(Me)
            _sp.StartPosition = FormStartPosition.CenterParent
            Application.DoEvents()
            Me.ImageBindingSource.DataSource = Me.oTree.Parent.GetDataFolderAiImagesForNode(Me.oTree, Me.oSelectedNode, 200)
            _sp.Hide()

            Me.ImageBindingSource.ResetBindings(True)
        End If
    End Sub

    Private Sub BindingNavigatorDeleteItem_Click(sender As System.Object, e As System.EventArgs) Handles BindingNavigatorDeleteItem.Click
        'по умолчанию удаляет ImageBindingSource.current из списка
        Select Case ImageBindingSource.DataSource.GetType
            Case Me.BindingSourceNodeObject.GetType
                'привязано к внутреннему списку. Ничего не делаем.
            Case GetType(List(Of Image))
                Dim _imgPathInTag As String = ImageBindingSource.Current.tag
                MsgBox(_imgPathInTag)
        End Select
    End Sub

    Private Sub PrintDocument1_PrintPage(sender As System.Object, e As System.Drawing.Printing.PrintPageEventArgs)

    End Sub

    Private Sub ToolStripButton1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton1.Click
        Static _InitialDirectory As String
        If _InitialDirectory Is Nothing Then _InitialDirectory = ""

        If Me.BindingSourceNodeObject.Current Is Nothing Then Exit Sub
        Dim _curr = CType(Me.BindingSourceNodeObject.Current, NodeObject)

        Dim _fileDialog As New Windows.Forms.OpenFileDialog
        With _fileDialog
            .Title = "Папка для файлов " & _curr.Name
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
                    Me.oTree.Parent.AttachDataFile(Me.oTree, _curr, _file)
                Next
                MsgBox("Для узла " & _curr.Name & " добавлено " & _fileDialog.FileNames.Count & " файлов.", vbInformation, clsTreeManager.AppHeader)
        End Select
    End Sub

    Private Sub ToolStripButton2_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton2.Click
        If Me.BindingSourceNodeObject.Current Is Nothing Then Exit Sub
        Dim _curr = CType(Me.BindingSourceNodeObject.Current, NodeObject)

        Dim _path = _curr.Parent.Parent.GetDataFolderPathForNode(_curr.Parent, _curr, False)

        If _path.Length > 0 AndAlso IO.Directory.Exists(_path) Then
            System.Diagnostics.Process.Start(_path)
        Else
            MsgBox("Папка не существует или не задана", vbCritical, clsTreeManager.AppHeader)
        End If
    End Sub

    Private Sub btAddLabel_Click(sender As System.Object, e As System.EventArgs) Handles btAddLabel.Click
        If Me.ImageBindingSource.Current Is Nothing Then Exit Sub
        If oSelectedNode Is Nothing Then Exit Sub
        For i = 1 To Me.nudLabelsCountCopy.Value
            RaiseEvent AddNodeToPrint(Me, New clsTreeService.AddLabelToPrintEventArg With {.Node = oSelectedNode, .Image = Me.ImageBindingSource.Current
            })
            Application.DoEvents()
        Next
        Me.nudLabelsCountCopy.Value = 1
    End Sub

    Private Sub ImageBindingSource_CurrentChanged(sender As Object, e As System.EventArgs) Handles ImageBindingSource.CurrentChanged
        If ImageBindingSource.Current Is Nothing Then Exit Sub
        Select Case ImageBindingSource.Current.GetType
            Case GetType(Image), GetType(Bitmap)
                Dim _path As String = ImageBindingSource.Current.tag
                If Not _path Is Nothing AndAlso _path.Length > 0 Then
                    Me.lbLabelName.Text = IO.Path.GetFileName(_path)
                Else
                    Me.lbLabelName.Text = Nothing
                End If
            Case GetType(NodeObject)
                Dim _res = CType(ImageBindingSource.Current, NodeObject).NodeNameByCulture(Me.oCulture)
                Me.lbLabelName.Text = _res
            Case Else
                Me.lbLabelName.Text = Nothing
        End Select


    End Sub

    Private Sub NameTextBox_TextChanged(sender As System.Object, e As System.EventArgs) Handles NameTextBox.TextChanged

    End Sub

    Private Sub NameTextBox_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles NameTextBox.Validating
        NameTextBox.Text.Trim()
    End Sub


    Private Sub TextBox_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles DescrRUSRichTextBox.KeyUp, DescrRichTextBox.KeyUp, RichTextBox1.KeyUp, NameRUSTextBox.KeyUp, NameTextBox.KeyUp
        If e.Control Then
            'Dim _base As TextBoxBase = sender
            'Select Case e.KeyCode
            '    Case Keys.V
            '        _base.Paste()
            '        ' sender.Paste()
            '    Case Keys.C
            '        ' sender.Copy()
            '        _base.Copy()
            'End Select
        End If
    End Sub

    Private Sub NameRUSTextBox_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles NameRUSTextBox.Validating
        NameRUSTextBox.Text.Trim()
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripMenuItem2.Click
        If oSelectedNode.HasChildren Then
            If oSelectedNode.RemoveAllChildrens() Then
                MsgBox("Потомки узла удалены", MsgBoxStyle.Information)
            Else

                MsgBox("Не удалось удалить потомков", MsgBoxStyle.Critical)
            End If
        Else
            MsgBox("У данного узла потомков нет", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub УдалитьIDToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles УдалитьIDToolStripMenuItem1.Click
        Dim _id = InputBox("введите ID ", "ID для удаления", "")
        Dim _result As Integer
        If Integer.TryParse(_id, _result) Then
            Dim _node = (From c In oSelectedNode.Parent Where c.id = _id Select c).ToList
            Select Case _node.Count
                Case Is = 0
                    MsgBox("узла с ID " & _id & " не существует", MsgBoxStyle.Critical, "Удаление узла")
                Case Is = 1
                    If Not Me.oTree.DeleteNode(_node(0)) Then
                        MsgBox("Не удалось удалить узел", MsgBoxStyle.Critical, "Удаление узла")
                    Else
                        MsgBox("Удален узел " & _node(0).Name, MsgBoxStyle.Information)

                    End If
                    Exit Sub
                Case Is > 1
                    Select Case MsgBox("Обнаружено повторение ID! Удалить узлы с повторяющимися ID, кроме первого " & _node(0).Name, MsgBoxStyle.YesNo)
                        Case MsgBoxResult.Yes
                            For i = 1 To _node.Count - 1
                                If Not Me.oTree.DeleteNode(_node(i)) Then
                                    MsgBox("Не удалось удалить узел", MsgBoxStyle.Critical, "Удаление узла")
                                Else
                                    MsgBox("Удален узел " & _node(i).Name, MsgBoxStyle.Information)

                                End If

                            Next
                        Case MsgBoxResult.No
                            Exit Sub
                    End Select
            End Select
        End If
        MsgBox("Неверный ввод")
    End Sub

    Private Sub КоррекцияПереместитьНаМеньшийУровеньToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles КоррекцияПереместитьНаМеньшийУровеньToolStripMenuItem1.Click
        'уменьшаем порядок узла на 1
        Dim _node = oSelectedNode
        Dim _oldID = _node.HierID
        Dim _newID = _node.HierID.GetAncestor(1).GetDescendant(Nothing, _node.HierID)
        'проверим, не занято ли место
        Dim _corr = (From c In oTree.NodeCollection Where c.HierID.Equals(_newID) Select c).FirstOrDefault

        If _corr Is Nothing Then
            'место свободно, переместить
            _node.MoveDown()
            oTree.MoveChild(_oldID, _newID)
        Else
            'откат операции
            _node.HierID = _oldID
            MsgBox("Невозможно применить уровень. Узел с таким уровнем уже существует." & _newID.ToString)
        End If
    End Sub

    Private Sub КоррекцияУзловСОдинаковымHierIDилиПереместитьНаБольшийУровеньToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles КоррекцияУзловСОдинаковымHierIDилиПереместитьНаБольшийУровеньToolStripMenuItem.Click
        Dim _right = oSelectedNode
        'выбрать братьев с тем же HierID
        Dim _corr = From c In oTree.NodeCollection Where c.HierID.Equals(_right.HierID) Select c

        If _corr.Count > 0 Then
            For Each _node In _corr
                Dim _t = Me.oTree.CorrectHierID(_right.HierID)
                oTree.MoveChild(_node.HierID, _t)
                _node.HierID = _t
            Next
        End If
    End Sub

    Private Sub btCopyNameInBuffer_Click(sender As System.Object, e As System.EventArgs) Handles btCopyNameInBuffer.Click
        If oSelectedNode Is Nothing Then Exit Sub
        Dim _out = oSelectedNode.NodeNameByCulture(oCulture)
        If Not _out = "" Then
            '------------------
            Dim _data As String = _out
            Try
                My.Computer.Clipboard.Clear()
                My.Computer.Clipboard.SetText(_data)
            Catch ex As Exception
                MsgBox("Ошибка при помещении данных в буфер обмена.", vbCritical)
            End Try
            '-----------------

        Else
            MsgBox("Название узла в этой культуре пусто!", vbCritical)
        End If
    End Sub

    Private Sub btCopyNodeValue_Click(sender As System.Object, e As System.EventArgs) Handles btCopyNodeValue.Click
        If oSelectedNode Is Nothing Then Exit Sub
        Dim _a As XElement = <DATA></DATA>
        _a.Add(oSelectedNode.GetDescriptionElement(oCulture))
        Dim _out = clsTreeService.ParseDescriptionXML(oCulture, _a)
        If Not _out = "" Then
            '------------------
            Dim _data As String = _out
            Try
                My.Computer.Clipboard.Clear()
                My.Computer.Clipboard.SetText(_data)
            Catch ex As Exception
                MsgBox("Ошибка при помещении данных в буфер обмена.", vbCritical)
            End Try
            '-----------------
        Else
            MsgBox("Название узла в этой культуре пусто!", vbCritical)
        End If
    End Sub

    Private Sub ПрисвоитьНовыйIDToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ПрисвоитьНовыйIDToolStripMenuItem.Click
        Dim _node = oSelectedNode
        Dim _tree = oSelectedNode.Parent
        _node.Parent.Parent.CorrectIndividualID(_node, _tree.GetNodeIDForNewNode)
    End Sub



    Private Sub lbArticul_TextChanged(sender As Object, e As System.EventArgs) Handles lbArticul.TextChanged
        If lbArticul.Text = "" Then lbArticul.Text = "нет артикула"
    End Sub

    'Private Sub cbxFilterNode_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles cbxFilterNode.CheckedChanged
    '    Select Case cbxFilterNode.Checked
    '        Case True
    '            'грузим только связанные узлы

    '        Case Else



    '    End Select


    'End Sub

    Private odragBoxFromMouseDown As Rectangle

    Private Sub imgLwPhoto_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseDown
        ' Remember the point where the mouse down occurred. The DragSize indicates
        ' the size that the mouse can move before a drag event should be started.                
        Dim dragSize As Size = SystemInformation.DragSize

        ' Create a rectangle using the DragSize, with the mouse position being
        ' at the center of the rectangle.
        odragBoxFromMouseDown = New Rectangle(New System.Drawing.Point(e.X - (dragSize.Width / 2), _
                                                        e.Y - (dragSize.Height / 2)), dragSize)
    End Sub

    Private Sub imgLwPhoto_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseMove
        If ((e.Button And MouseButtons.Left) = MouseButtons.Left) Then

            ' If the mouse moves outside the rectangle, start the drag.
            If (Rectangle.op_Inequality(odragBoxFromMouseDown, Rectangle.Empty) And _
                Not odragBoxFromMouseDown.Contains(e.X, e.Y)) Then

                ' The screenOffset is used to account for any desktop bands 
                ' that may be at the top or left side of the screen when 
                ' determining when to cancel the drag drop operation.
                'найдем элемент списка
                'Dim _item = sender.GetItemAt(e.X, e.Y)
                If Me.ImageBindingSource.Current Is Nothing Then Return
                'в tag лежит путь к файлу
                Dim _image As Image = Me.ImageBindingSource.Current

                If rbExternalLabel.Checked Then
                    If _image.Tag Is Nothing Then Return
                    Dim _obg As New DataObject
                    Dim _coll As New Collections.Specialized.StringCollection
                    _coll.Add(_image.Tag)
                    With _obg
                        .SetFileDropList(_coll)
                    End With
                    ' Proceed with the drag-and-drop, passing in the list item.                    
                    Dim dropEffect As DragDropEffects = sender.DoDragDrop(_obg, DragDropEffects.Copy)
                End If
                If rbExternalImage.Checked Then
                    If _image.Tag Is Nothing Then Return
                    Dim _obg As New DataObject
                    Dim _coll As New Collections.Specialized.StringCollection
                    _coll.Add(_image.Tag)
                    With _obg
                        .SetFileDropList(_coll)
                    End With
                    ' Proceed with the drag-and-drop, passing in the list item.                    
                    Dim dropEffect As DragDropEffects = sender.DoDragDrop(_obg, DragDropEffects.Copy)
                End If

                If rbInnerImg.Checked Then
                    Dim ms As New IO.MemoryStream
                    Dim ms2 As New IO.MemoryStream
                    _image.Save(ms, Imaging.ImageFormat.Bmp)
                    Dim bytes() As Byte = ms.GetBuffer
                    ms2.Write(bytes, 14, CInt(ms.Length - 14))
                    ms.Position = 0
                    Dim obj As New DataObject
                    obj.SetData("DeviceIndependentBitmap", ms2)
                    sender.DoDragDrop(obj, DragDropEffects.Copy)
                    ms.Close()
                    ms2.Close()
                End If

                'Dim _name As String = Me.BindingSource1.Current.tag
                'If _name.Length > 0 AndAlso (Not Me.oSampleNumber Is Nothing) Then
                '    'найдем путь к обьекту
                '    Dim _source = clsFilesSources.CreateInstance(Service.clsFilesSources.emSources.Arhive)
                '    Dim _uri = Service.clsApplicationTypes.SamplePhotoObject.GetImagesURI(Me.oSampleNumber, _source, {_name})
                '    If _uri.Length > 0 Then
                '        Dim _obg As New DataObject
                '        Dim _coll As New Collections.Specialized.StringCollection
                '        _coll.Add(_uri(0).LocalPath)
                '        With _obg
                '            .SetFileDropList(_coll)
                '        End With

                '        ' Proceed with the drag-and-drop, passing in the list item.                    
                '        Dim dropEffect As DragDropEffects = sender.DoDragDrop(_obg, DragDropEffects.Copy)

                '    End If
                'End If
            End If
        End If
    End Sub

    Private Sub imgLwPhoto_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseUp
        ' Reset the drag rectangle when the mouse button is raised.
        odragBoxFromMouseDown = Rectangle.Empty
    End Sub

    Private Sub PictureBox1_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox1.Click

    End Sub
End Class
