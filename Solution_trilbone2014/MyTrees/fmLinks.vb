Imports Service

Friend Class fmLinks

    Private Sub fmLinks_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub
    Private Sub New()

        ' Этот вызов является обязательным для конструктора.
        InitializeComponent()

        ' Добавьте все инициализирующие действия после вызова InitializeComponent().

    End Sub
    Private oCulture As System.Globalization.CultureInfo
    ''' <summary>
    ''' сгенерированный обьект (представляет дерево формы)
    ''' </summary>
    ''' <remarks></remarks>
    Private oFormTree As ClsTree
    ''' <summary>
    ''' переданный форме обьект. Parent НЕ РАВЕН oFormTree!!
    ''' </summary>
    ''' <remarks></remarks>
    Private oOwnerNode As NodeObject

    Public Sub New(node As NodeObject, culture As System.Globalization.CultureInfo)
        InitializeComponent()
        'отображение связей
        oCulture = culture
        Debug.Assert(Not node Is Nothing)
        'запомнить узел
        Me.oOwnerNode = node
        Me.Text = "Связи " & node.NodeNameByCulture(culture)

        'создать узел для местного дерева
        Dim _node = node.Clone(True, False)
        Dim _linkedNodes As List(Of NodeObject) = _node.GetLinkedNodesCollection

        Dim _tree = ClsTree.CreateEmptyTreeFromNode("links", _node, _node.Parent.Parent, False)

        'группировка имя дерева -> массив NodeObject, НЕ исключить текущее дерево
        Dim _result = (From c In _linkedNodes Group c By c1 = c.Parent.RootNodeNameByCulture(Me.oCulture)
                    Into c2 = Group Where c2.Count > 0 Select New KeyValuePair(Of String, List(Of NodeObject))(c1, c2.ToList)).ToArray

        'создать узлы местного дерева
        For Each t1 In _result
            Dim _nodeAsTreeLevel1 As NodeObject
            If t1.Value.Count > 0 Then
                'level 1 создать узлы деревьев _tree.RootNode=_node
                _nodeAsTreeLevel1 = _tree.AddChildrenToNode(_tree.RootNode, t1.Key)
                '====level
                For Each _cn In t1.Value
                    'level 1 создать узлы привязанных узлов LEVEL 1
                    Dim _AsNodeLevel1 = _tree.AddChildrenToNode(_nodeAsTreeLevel1, _cn.Clone(False, False), True)
                    'level 1 проверить узел на наличие связей
                    If _AsNodeLevel1.HasLink Then
                        'создать 
                        Dim _tmplinkedNodes = _AsNodeLevel1.GetLinkedNodesCollection
                        'группировка имя дерева -> массив NodeObject, исключить текущее дерево
                        Dim _result2 = (From c In _tmplinkedNodes Group c By c1 = c.Parent.RootNodeNameByCulture(Me.oCulture)
                        Into c2 = Group Where (Not c1 = _node.Parent.RootNodeName) And c2.Count > 0 Select New KeyValuePair(Of String, List(Of NodeObject))(c1, c2.ToList)).ToArray
                        For Each t2 In _result2
                            Dim _nodeAsTreeLevel2 As NodeObject
                            If (Not t2.Key = node.Parent.RootNodeName) And t2.Value.Count > 0 Then
                                'создать узлы деревьев
                                _nodeAsTreeLevel2 = _tree.AddChildrenToNode(_AsNodeLevel1, t2.Key)
                                '===level
                                For Each _cn2 In t2.Value
                                    'создать привязанных узлов LEVEL 2
                                    Dim _AsNodeLevel2 = _tree.AddChildrenToNode(_nodeAsTreeLevel2, _cn2.Clone(False, False), True)
                                    '''new
                                    ''' 
                                    '
                                    'проверить узел на наличие связей
                                    If _AsNodeLevel2.HasLink Then
                                        'создать 
                                        Dim _tmplinkedNodes2 = _AsNodeLevel2.GetLinkedNodesCollection
                                        'группировка имя дерева -> массив NodeObject, исключить текущее дерево
                                        Dim _result3 = (From c In _tmplinkedNodes2 Group c By c1 = c.Parent.RootNodeNameByCulture(Me.oCulture)
Into c2 = Group Where (Not c1 = _node.Parent.RootNodeName) And c2.Count > 0 Select New KeyValuePair(Of String, List(Of NodeObject))(c1, c2.ToList)).ToArray

                                        For Each t3 In _result3
                                            Dim _nodeAsTreeLevel3 As NodeObject
                                            If (Not t3.Key = _AsNodeLevel1.Parent.RootNodeName) And t3.Value.Count > 0 Then
                                                'создать узлы деревьев
                                                _nodeAsTreeLevel3 = _tree.AddChildrenToNode(_AsNodeLevel2, t3.Key)
                                                '===level
                                                For Each _cn3 In t3.Value
                                                    'создать привязанных узлов LEVEL 3
                                                    Dim _AsNodeLevel3 = _tree.AddChildrenToNode(_nodeAsTreeLevel3, _cn3.Clone(False, False), True)
                                                Next
                                            End If
                                        Next
                                    End If
                                Next
                            End If

                        Next
                    End If
                Next
            End If
        Next

        If oOwnerNode.HasTiedNodes Then
            Me.lbArticulThis.Text = oOwnerNode.DataFolder
            Me.btDelArticul.Enabled = True
            Me.btCreateArticul.Enabled = False
        Else
            Me.lbArticulThis.Text = "Артикула нет"
            Me.btDelArticul.Enabled = False
            Me.btCreateArticul.Enabled = True
        End If

        'заполнение левого плоского списка
        Dim _FirstLevelNodes = (From c In _linkedNodes Order By c.Name Select New With {.ob = c, .line = c.NodeNameByCulture(Me.oCulture)}).ToList
        Me.lbLinks.DataSource = _FirstLevelNodes
        Me.lbLinks.DisplayMember = "line"
        Me.lbLinks.ValueMember = "ob"


        Me.lbArticul.Text = ""
        oFormTree = _tree
        cbxShowLeaf_CheckedChanged_1(Me, EventArgs.Empty)
    End Sub


    ''' <summary>
    ''' Обновить дерево
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RefreshList()
        If Not Me.oFormTree Is Nothing Then
            Dim _selnode = Me.TreeView1.SelectedNode

            If Not Me.TreeView1.SelectedNode Is Nothing Then
                _selnode = Me.TreeView1.SelectedNode
            End If

            Me.TreeView1.Nodes.Clear()
            Me.TreeView1.Nodes.AddRange(oFormTree.CreateNodesForTreeView(Me.oCulture).ToArray)

            If Not _selnode Is Nothing Then
                If Me.TreeView1.Nodes.Find(_selnode.Text, True).Count > 0 Then
                    Me.TreeView1.SelectedNode = Me.TreeView1.Nodes.Find(_selnode.Text, True)(0)
                    Me.TreeView1.SelectedNode.Expand()
                End If


            End If
        End If
    End Sub

    Private oCurrentDescription As XElement

    Private Sub lbLinks_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lbLinks.SelectedIndexChanged
        If lbLinks.SelectedItem Is Nothing Then Exit Sub
        Dim _node = CType(lbLinks.SelectedItem.ob, NodeObject)
        Me.oCurrentDescription = _node.GetDescriptionElement(oCulture, Me.NumericUpDown1.Value)
        'Me.tbDescription.Text = clsTreeService.ParseNodeXML(oCurrentDescription)
    End Sub

    Private Sub NumericUpDown1_ValueChanged(sender As System.Object, e As System.EventArgs) Handles NumericUpDown1.ValueChanged
        If lbLinks.SelectedItem Is Nothing Then Exit Sub
        Dim _node = CType(lbLinks.SelectedItem.ob, NodeObject)
        Me.oCurrentDescription = _node.GetDescriptionElement(oCulture, Me.NumericUpDown1.Value)
        'Me.tbDescription.Text = clsTreeService.ParseNodeXML(oCurrentDescription)
    End Sub

    Private Sub btClose_Click(sender As System.Object, e As System.EventArgs) Handles btClose.Click
        Me.Close()
    End Sub

    Friend Event SelectAcceptedfmLink(sender As Object, e As clsTreeService.DescriptionAcceptEventArg)

    'Private Sub btAccept_Click(sender As System.Object, e As System.EventArgs) Handles btAccept.Click
    '    RaiseEvent SelectAcceptedfmLink(Me, New clsTreeService.DescriptionAcceptEventArg(Me.oCurrentDescription, oCulture))
    '    If lbLinks.SelectedIndex + 1 < lbLinks.Items.Count Then
    '        lbLinks.SelectedIndex += 1
    '    End If
    'End Sub

    Private Sub btAcceptMUI_Click(sender As System.Object, e As System.EventArgs) Handles btAcceptMUI.Click, btAccept.Click
        ' If lbLinks.SelectedItem Is Nothing Then Exit Sub
        If Me.TreeView1.SelectedNode Is Nothing Then Exit Sub

        ' Dim _node = CType(lbLinks.SelectedItem.ob, NodeObject)
        Dim _treenode = CType(Me.TreeView1.SelectedNode.Tag, NodeObject)
        'If Not _node.Name = _treenode.Name Then
        '    Me.SelectNode(_treenode)
        'End If
        'добыть исходный узел
        Dim _targetNode = Me.oOwnerNode.Parent.Parent.FindNode(_treenode.Name)
        If _targetNode Is Nothing Then Return

        If Not Me.TreeView1.SelectedNode.ForeColor = Color.Blue Then
            Me.TreeView1.SelectedNode.ForeColor = Color.Blue
            RaiseEvent SelectAcceptedfmLink(Me, New clsTreeService.DescriptionAcceptEventArg(_targetNode.GetDescriptionElement(clsTreeManager.EnglishCulture, Me.NumericUpDown1.Value), clsTreeManager.EnglishCulture))

            If sender Is Me.btAcceptMUI Then
                RaiseEvent SelectAcceptedfmLink(Me, New clsTreeService.DescriptionAcceptEventArg(_targetNode.GetDescriptionElement(clsTreeManager.RussianCulture, Me.NumericUpDown1.Value), clsTreeManager.RussianCulture))
            End If

        Else
            MsgBox("Пункт уже добавлен в описание", vbCritical)
        End If
    End Sub

    Private Function CompareNode(x As NodeObject, y As NodeObject) As Integer
        Throw New NotImplementedException
    End Function

    Private Sub cbxShowLeaf_CheckedChanged_1(sender As Object, e As EventArgs) Handles cbxShowLeaf.CheckedChanged
        Dim _node As NodeObject = Nothing
        If Not Me.TreeView1.SelectedNode Is Nothing Then
            _node = TreeView1.SelectedNode.Tag
        End If

        Select Case cbxShowLeaf.Checked
            Case True
                Me.TreeView1.Nodes.Clear()
                Me.TreeView1.Nodes.AddRange(oFormTree.CreateNodesForTreeView(Me.oCulture, True).ToArray)
            Case False
                RefreshList()
                Me.TreeView1.Nodes(0).Expand()
                For Each t As Windows.Forms.TreeNode In Me.TreeView1.Nodes(0).Nodes
                    t.Expand()
                Next
        End Select
        If Not _node Is Nothing Then
            SelectNode(_node)
        End If
    End Sub


    ''' <summary>
    ''' выделяет определенный узел дерева
    ''' </summary>
    ''' <param name="node"></param>
    ''' <remarks></remarks>
    Public Overloads Sub SelectNode(node As NodeObject, Optional _treeNode As Windows.Forms.TreeNode = Nothing)
        If _treeNode Is Nothing Then
            If Me.TreeView1.TopNode Is Nothing Then
                If Not Me.TreeView1.Nodes(0) Is Nothing Then
                    SelectNode(node, Me.TreeView1.Nodes(0))
                End If
            Else
                SelectNode(node, Me.TreeView1.TopNode)
            End If
        Else
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
                        'Me.TreeView1.ExpandAll()
                        For Each c In _treeNode.Nodes
                            SelectNode(node, c)
                        Next
                End Select
            End If
        End If

    End Sub

    Private Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterSelect
        If Not e.Node Is Nothing Then
            Dim _node As NodeObject = e.Node.Tag
            Dim _childrens = _node.Parent.GetChildrens(_node)
            'заполнение левого плоского списка
            Dim _FirstLevelNodes = (From c In _childrens Order By c.Name Select New With {.ob = c, .line = c.NodeNameByCulture(Me.oCulture)}).ToList
            Me.lbLinks.DataSource = _FirstLevelNodes
            Me.lbLinks.DisplayMember = "line"
            Me.lbLinks.ValueMember = "ob"


            'тут выбираем анонимный тип (см. список)
            Dim _resul = From c In lbLinks.Items Where c.ob.name = _node.Name Select c
            oSelectedNode = _node
            If _resul.Count > 0 Then
                lbLinks.SelectedItem = _resul(0)
            End If

            'строка описания для выбранного узла
            Dim _targetNode = Me.oOwnerNode.Parent.Parent.FindNode(_node.Name)
            If _targetNode Is Nothing Then Me.tbDescription.Text = "узел не найден" : Return

            Dim _descr = _targetNode.GetDescriptionElement(oCulture, Me.NumericUpDown1.Value)
            Me.tbDescription.Text = clsApplicationTypes.ParseNodeXML(_descr)

        End If

    End Sub

    Private Sub btAddToArticul_Click(sender As System.Object, e As System.EventArgs) Handles btAddToArticul.Click
        If lbLinks.SelectedItem Is Nothing Then Exit Sub
        If Me.TreeView1.SelectedNode Is Nothing Then
            MsgBox("Выберете узел в дереве!", MsgBoxStyle.Critical)
            Exit Sub
        End If
        Me.btCreateNode.Enabled = True
        Dim _node = CType(lbLinks.SelectedItem.ob, NodeObject)
        Dim _treenode = CType(Me.TreeView1.SelectedNode.Tag, NodeObject)
        If Not _node.Name = _treenode.Name Then
            Me.SelectNode(_treenode)
        End If
        If Not Me.TreeView1.SelectedNode.ForeColor = Color.Red Then
            Me.TreeView1.SelectedNode.ForeColor = Color.Red
            'добавить узел _node в артикул
            AddToArticul(_node)

        Else
            MsgBox("Пункт уже добавлен в артикул", vbCritical)
        End If
    End Sub
    Private oArticul As New List(Of NodeObject)

    ''' <summary>
    ''' добавить узел к артикулу
    ''' </summary>
    ''' <param name="node"></param>
    ''' <remarks></remarks>
    Private Sub AddToArticul(node As NodeObject)
        If oArticul.Count = 0 Then
            'добавим первый обьект - узел-хозяин
            oArticul.Add(oOwnerNode)
            Me.lbArticul.Text = oOwnerNode.id.ToString
            Me.tbNodeName.Text = oOwnerNode.Name
            Me.tbNodeNameRUS.Text = oOwnerNode.NameRUS
        End If
        'добавим переданный узел
        oArticul.Add(node)
        Me.lbArticul.Text += "/" & node.id.ToString
        Me.tbNodeName.Text += ", " & node.Name
        Me.tbNodeNameRUS.Text += ", " & node.NameRUS
    End Sub

    Private Sub btClear_Click(sender As System.Object, e As System.EventArgs) Handles btClear.Click
        oArticul.Clear()
        Me.lbArticul.Text = ""
        Me.tbNodeName.Text = ""
        Me.tbNodeNameRUS.Text = ""
        Me.btCreateNode.Enabled = False
        For Each t As Windows.Forms.TreeNode In Me.TreeView1.Nodes
            If t.ForeColor = Color.Red Then t.ForeColor = Color.Black
            Dim a As Windows.Forms.TreeNode = t.NextVisibleNode
            Do
                If a Is Nothing Then Exit Do
                If a.ForeColor = Color.Red Then a.ForeColor = Color.Black
                a = a.NextVisibleNode

            Loop Until a Is Nothing
        Next
    End Sub

    Private Sub btCreateNode_Click(sender As System.Object, e As System.EventArgs) Handles btCreateNode.Click
        'добавить новый узел в дерево
        If Me.tbNodeName.Text = "" Then
            MsgBox("Следует ввести имя узла!", vbCritical)
            Exit Sub
        End If
        Dim _new = Me.oOwnerNode.Parent.AddChildrenToNode(oOwnerNode, Me.tbNodeName.Text)
        With _new
            .NameRUS = Me.tbNodeNameRUS.Text
            .Descr = oOwnerNode.Descr
            .DescrRUS = oOwnerNode.DescrRUS
            .info = oOwnerNode.info
            'работа со связями. удалить все связи для деревьев, которые есть в артикульных узлах
            'добавить артикульные узлы в связи
            '.Link = New Dictionary(Of String, List(Of Integer))
            For Each t In oOwnerNode.Link
                Dim t1 = t
                Dim _res1 = (From c In oArticul Where c.Parent.TreeKeyName = t1.Key Select c).Count
                If _res1 = 0 Then
                    'нет в артикуле дерева
                    For Each i In t.Value
                        .AddLink(t.Key, i)
                    Next
                End If
            Next

            'добавить артикульные связи
            For Each t In oArticul
                .AddLink(t)
            Next





            If .SetTiedNodes(oArticul) Then
                'скопировать файлы из родительского узла
                Dim _copies As Integer = 0
                Dim _notCopies As Integer = 0
                If oOwnerNode.Parent.Parent.TestDataFolderForNode(oOwnerNode) Then
                    For Each f In IO.Directory.EnumerateFiles(oOwnerNode.Parent.Parent.GetDataFolderPathForNode(oOwnerNode.Parent, oOwnerNode))
                        Try
                            IO.File.Copy(f, .Parent.Parent.GetDataFolderPathForNode(.Parent, _new, True))
                        Catch ex As Exception

                        End Try
                    Next
                End If
                RaiseEvent ArticulNodeCreated(Me, New clsTreeService.NodeCreatedEventArg With {.NewNode = _new})
                MsgBox("Узел успешно создан. Из папки родительского узла скопировано " & _copies & " файлов. Пропущено " & _notCopies & " файлов.", MsgBoxStyle.Information)

            Else
                MsgBox("Узел создан, но артикул создать не удалось!", MsgBoxStyle.Critical)
            End If
        End With

        For Each t As Windows.Forms.TreeNode In Me.TreeView1.Nodes
            t.ForeColor = Color.Black
        Next

        btClear_Click(Me, EventArgs.Empty)

    End Sub

    Friend Event ArticulNodeCreated(sender As Object, e As clsTreeService.NodeCreatedEventArg)


    Private Sub btCreateArticul_Click(sender As Object, e As EventArgs) Handles btCreateArticul.Click
        If Me.oOwnerNode.SetTiedNodes({oOwnerNode}.ToList) Then
            Me.lbArticulThis.Text = oOwnerNode.DataFolder
            Me.btDelArticul.Enabled = True
            Me.btCreateArticul.Enabled = False
        End If
    End Sub

    Private Sub btDelArticul_Click(sender As Object, e As EventArgs) Handles btDelArticul.Click
        If oOwnerNode.HasTiedNodes Then
            Select Case MsgBox("Действительно хотите удалить артикул? Это действие невозможно отменить или исправить!", vbYesNo)
                Case MsgBoxResult.Yes
                    oOwnerNode.ClearTiedNodes()
                    Me.lbArticulThis.Text = "Артикула нет"
                    Me.btDelArticul.Enabled = False
                    Me.btCreateArticul.Enabled = True

            End Select

        End If
    End Sub

    ''' <summary>
    ''' выбранный в списке обьект. Не имеет отношения к переданному при создании узлу!
    ''' </summary>
    ''' <remarks></remarks>
    Private oSelectedNode As NodeObject

    Private Sub btCopyName_Click(sender As System.Object, e As System.EventArgs) Handles btCopyName.Click
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
        'получим обьект из нужного дерева
        'ищем по имени TODO исправить на id
        Dim _coreObject As NodeObject = oOwnerNode.Parent.Parent.FindNode(oSelectedNode.Name)
        If _coreObject Is Nothing Then MsgBox("Не могу найти обьект в деревьях!", vbCritical) : Exit Sub

        _a.Add(_coreObject.GetDescriptionElement(oCulture))
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
End Class