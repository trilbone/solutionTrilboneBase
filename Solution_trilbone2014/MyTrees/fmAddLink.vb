Friend Class fmAddLink
    Private oIncomingNode As NodeObject
    Private oSelectedNode As NodeObject
    Private oManager As clsTreeManager
    Private oCurrentCulture As System.Globalization.CultureInfo
    Private oCurrentTree As ClsTree

    Public Sub New()

        ' Этот вызов является обязательным для конструктора.
        InitializeComponent()

        ' Добавьте все инициализирующие действия после вызова InitializeComponent().

    End Sub

    Public Sub New(ByRef IncomingNode As NodeObject, Culture As System.Globalization.CultureInfo)
        InitializeComponent()

        Me.TreeView1.Enabled = False
        Me.lbLinks.Enabled = False


        oIncomingNode = IncomingNode
        oManager = IncomingNode.Parent.Parent
        oCurrentCulture = Culture

        Me.lbIncomingNode.Text = "Связать  " & GetNodeText(IncomingNode)

        If IncomingNode.HasTiedNodes Then
            Me.lbArticul.Text = IncomingNode.DataFolder
            Me.btDelArticul.Enabled = True
            Me.btCreateArticul.Enabled = False
        Else
            Me.lbArticul.Text = "Артикула нет"
            Me.btDelArticul.Enabled = False
            Me.btCreateArticul.Enabled = True

        End If

        Dim _tmpTree As New List(Of ClsTree)



        'запретить добавление дерева, которому принадлежит связываемый узел (связи внутри дерева - НЕ РАЗРЕШАТЬ!)
        'For Each c In oManager.TreeList
        '    If Not c.TreeName = IncomingNode.Parent.TreeName Then
        '        _tmpTree.Add(c)
        '    End If
        'Next

        'связи внутри дерева -  РАЗРЕШАТЬ!
        For Each c In oManager.TreeList
            _tmpTree.Add(c)
        Next
        Me.lbTrees.DataSource = _tmpTree
        Me.lbTrees.DisplayMember = "TreeName"

        If lbTrees.Items.Count > 0 Then
            lbTrees.SelectedIndex = 0
        Else
            MsgBox("Нет доступных деревьев", vbCritical)
            btCancel_Click(Me, EventArgs.Empty)
        End If



    End Sub

    Private Sub btCancel_Click(sender As System.Object, e As System.EventArgs) Handles btCancel.Click
        Me.Close()
    End Sub

    Private Sub lbTrees_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lbTrees.SelectedIndexChanged

        Me.TreeView1.Enabled = True

        If lbTrees.SelectedIndex = -1 Then Exit Sub
        Me.oCurrentTree = CType(lbTrees.SelectedItem, ClsTree)
        'заполнить дерево
        Call cbxShowLeaf_CheckedChanged(sender, e)

        'Me.TreeView1.Nodes.Clear()
        'Me.TreeView1.Nodes.AddRange(oCurrentTree.CreateNodesForTreeView(oCurrentCulture).ToArray)

        Dim _selnodeKey As String
        If Not Me.TreeView1.SelectedNode Is Nothing Then
            _selnodeKey = Me.TreeView1.SelectedNode.Name
        ElseIf Not Me.TreeView1.TopNode Is Nothing Then
            _selnodeKey = Me.TreeView1.TopNode.Name
        Else
            _selnodeKey = Me.TreeView1.Nodes.Item(0).Name
        End If

        Me.TreeView1.SelectedNode = Me.TreeView1.Nodes.Item(_selnodeKey)
        Me.TreeView1.SelectedNode.Expand()

        'отобразить связи
        Me.ReadLinks()


    End Sub
    ''' <summary>
    ''' читаем существующие связи
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ReadLinks()
        'читаем связи загруженного (incoming) узла с текущим деревом
        If IsNothing(Me.oIncomingNode.Link) Then Exit Sub
        If Not Me.oIncomingNode.Link.ContainsKey(Me.oCurrentTree.TreeKeyName) Then Exit Sub
        If IsNothing(Me.oIncomingNode.Link.Item(Me.oCurrentTree.TreeKeyName)) Then Exit Sub

        Dim _link = Me.oIncomingNode.Link.Item(Me.oCurrentTree.TreeKeyName)
        Me.lbLinks.Items.Clear()
        Dim _del As New List(Of Integer)
        For Each _i In _link
            If Not Me.oCurrentTree.Item(_i) Is Nothing Then
                Me.lbLinks.Items.Add(Me.oCurrentTree.Item(_i).NodeNameByCulture(Me.oCurrentCulture))
            Else
                'автоматическая очистка битых связей
                _del.Add(_i)
            End If
        Next

        For Each _j In _del
            Me.oIncomingNode.Link.Item(Me.oCurrentTree.TreeKeyName).Remove(_j)
            If Me.oIncomingNode.Link.Item(Me.oCurrentTree.TreeKeyName).Count = 0 Then
                Me.oIncomingNode.Link.Remove(Me.oCurrentTree.TreeKeyName)
            End If
        Next
    End Sub

    Private Sub TreeView1_AfterSelect(sender As System.Object, e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView1.AfterSelect
        If Me.TreeView1.SelectedNode Is Nothing Then Exit Sub

        'Me.lbLinks.Enabled = True

        Dim _node = CType(Me.TreeView1.SelectedNode.Tag, NodeObject)

        Me.ImageBindingSource.DataSource = _node.image

        Me.oSelectedNode = _node
        Me.lbSelectedNode.Text = "с узлом " & GetNodeText(_node)

        Dim _duallink As Boolean = False

        'проверить связи
        If Me.oIncomingNode.TestLink(Me.oSelectedNode) Then
            Me.btCreateLink.Enabled = False
        Else
            Me.btCreateLink.Enabled = True
            _duallink = True
        End If

        If Me.oSelectedNode.TestLink(Me.oIncomingNode) Then
            Me.btCreateDualLink.Enabled = False
            _duallink = False
        Else
            Me.btCreateDualLink.Enabled = True
            _duallink = True
        End If

        If _duallink Then
            Me.btMakeLink.Enabled = True
        Else
            Me.btMakeLink.Enabled = False
        End If


    End Sub

    Private Function GetNodeText(node As NodeObject) As String
        Dim _out As String
        _out = " " & node.NodeNameByCulture(oCurrentCulture) & "   (HierID:" & node.HierID.ToString & "    ID:" & node.id & ")"
        Return _out

    End Function

    Private Sub ImageBindingSource_CurrentChanged(sender As System.Object, e As System.EventArgs) Handles ImageBindingSource.CurrentChanged
        Me.PictureBox1.Image = ImageBindingSource.Current
    End Sub

    Private Sub btCreateLink_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCreateLink.Click
        'поиск повторов
        If Me.oIncomingNode.TestLink(Me.oSelectedNode) Then
            MsgBox("исходящая связь уже существует!", vbCritical)
            Exit Sub
        End If


        'If Me.oIncomingNode.Link Is Nothing Then
        '    'создать словарь связей
        '    Me.oIncomingNode.Link = New Dictionary(Of String, List(Of Integer))
        'End If

        'If Not Me.oIncomingNode.Link.ContainsKey(oCurrentTree.TreeName) Then
        '    'создать запись в словаре
        '    Me.oIncomingNode.Link.Add(oCurrentTree.TreeName, New List(Of Integer))
        'End If

        ''получить список ID
        'Dim _links = Me.oIncomingNode.Link.Item(oCurrentTree.TreeName)

        'добавить связь
        If Me.oIncomingNode.AddLink(oCurrentTree.TreeKeyName, oSelectedNode.id) Then
            Me.lbLinks.Items.Add(Me.oSelectedNode.NodeNameByCulture(Me.oCurrentCulture))

            btCreateLink.Enabled = False
            If btCreateDualLink.Enabled = False Then
                Me.btMakeLink.Enabled = False
            End If
        End If


        'Me.oIncomingNode.Link.Item(oCurrentTree.TreeName).Add(Me.oSelectedNode.id)
        'MsgBox("исходящая связь создана", vbInformation)




    End Sub



    Private Sub btRemoveLink_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btRemoveLink.Click
        'вход: выбрано имя связанного узла
        'есть входящий узел
        If Not Me.oSelectedNode Is Nothing Then
            If Me.oIncomingNode.RemoveLink(Me.oCurrentTree.TreeKeyName, Me.oSelectedNode.id) Then
                Me.btCreateLink.Enabled = True
            End If
            ''проверить наличие связи
            'Dim _ind = Me.oIncomingNode.Link.Item(Me.oCurrentTree.TreeName).IndexOf(Me.oSelectedNode.id)
            'If _ind >= 0 Then
            '    'удалить исходящую связь
            '    Me.oIncomingNode.Link.Item(Me.oCurrentTree.TreeName).RemoveAt(_ind)
            '    If Me.oIncomingNode.Link.Item(Me.oCurrentTree.TreeName).Count = 0 Then
            '        Me.oIncomingNode.Link.Remove(Me.oCurrentTree.TreeName)
            '    End If

            'End If
            'работа с привязанным узлом
            '??? удалять вторую сторону связи???
            If Me.oSelectedNode.RemoveLink(oIncomingNode) Then
                Me.btCreateDualLink.Enabled = True
            End If
            'If Not IsNothing(Me.oSelectedNode.Link) AndAlso Not IsNothing(Me.oSelectedNode.Link(Me.oIncomingNode.Parent.TreeName)) Then
            '    _ind = Me.oSelectedNode.Link(Me.oIncomingNode.Parent.TreeName).IndexOf(Me.oIncomingNode.id)
            '    If _ind >= 0 Then
            '        'удалить входящую связь
            '        Me.oSelectedNode.Link.Item(Me.oIncomingNode.Parent.TreeName).RemoveAt(_ind)
            '        If Me.oIncomingNode.Link.Item(Me.oIncomingNode.Parent.TreeName).Count = 0 Then
            '            Me.oIncomingNode.Link.Remove(Me.oIncomingNode.Parent.TreeName)
            '        End If

            '    End If
            'End If
            Me.btMakeLink.Enabled = True
        End If
        'refresh

        Me.ReadLinks()

    End Sub

    Private Sub lbLinks_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbLinks.SelectedIndexChanged
        'выделить выбранный узел
        Dim _key As String = lbLinks.SelectedValue
        Dim _item = Me.TreeView1.Nodes.Find(_key, True)
        If Not _item Is Nothing AndAlso _item.Count > 0 Then
            Me.TreeView1.SelectedNode = _item(0)
            Me.TreeView1.Invalidate(True)
        End If


    End Sub
    ' ''' <summary>
    ' ''' проверяет наличие связи в узле _from к узлу _to
    ' ''' </summary>
    ' ''' <param name="_from"></param>
    ' ''' <param name="_to"></param>
    ' ''' <returns></returns>
    ' ''' <remarks></remarks>
    'Private Function TestLink(ByVal _from As NodeObject, ByVal _to As NodeObject) As Boolean
    '    If Not IsNothing(_from.Link) AndAlso _from.Link.ContainsKey(_to.Parent.TreeName) AndAlso Not IsNothing(_from.Link.Item(_to.Parent.TreeName)) Then
    '        Dim _indx = _from.Link.Item(_to.Parent.TreeName).IndexOf(_to.id)
    '        If _indx >= 0 Then Return True
    '    End If
    '    Return False
    'End Function


    Private Sub btCreateDualLink_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCreateDualLink.Click

        If Not Me.oSelectedNode Is Nothing Then
            'это привязанный узел
            'поиск повторов
            If Me.oSelectedNode.TestLink(Me.oIncomingNode) Then
                MsgBox("входящая связь уже существует!", vbCritical)
                Exit Sub
            End If
           
            If Me.oSelectedNode.AddLink(oIncomingNode) > 0 Then
                'link was created
                btCreateDualLink.Enabled = False
                If btCreateLink.Enabled = False Then
                    Me.btMakeLink.Enabled = False
                End If
            End If
        End If



    End Sub
    ''' <summary>
    ''' создать обе связи
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btMakeLink_Click(sender As System.Object, e As System.EventArgs) Handles btMakeLink.Click
        Me.btCreateLink_Click(sender, e)
        Me.btCreateDualLink_Click(sender, e)

    End Sub

    Private Sub cbxShowLeaf_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles cbxShowLeaf.CheckedChanged
        Select Case cbxShowLeaf.Checked
            Case True
                Me.TreeView1.Nodes.Clear()
                Me.TreeView1.Nodes.AddRange(oCurrentTree.CreateNodesForTreeView(oCurrentCulture, True).ToArray)
            Case False
                RefreshList()
        End Select
    End Sub
    ''' <summary>
    ''' Обновить дерево
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RefreshList()
        If Not Me.oCurrentTree Is Nothing Then
            Dim _selnode = Me.TreeView1.SelectedNode

            If Not Me.TreeView1.SelectedNode Is Nothing Then
                _selnode = Me.TreeView1.SelectedNode
            End If

            Me.TreeView1.Nodes.Clear()
            Me.TreeView1.Nodes.AddRange(oCurrentTree.CreateNodesForTreeView(Me.oCurrentCulture).ToArray)

            If Not _selnode Is Nothing Then
                If Me.TreeView1.Nodes.Find(_selnode.Text, True).Count > 0 Then
                    Me.TreeView1.SelectedNode = Me.TreeView1.Nodes.Find(_selnode.Text, True)(0)
                    Me.TreeView1.SelectedNode.Expand()
                End If


            End If
        End If
    End Sub
    Private Sub btRefreshTree_Click(sender As System.Object, e As System.EventArgs) Handles btRefreshTree.Click
        Me.cbxShowLeaf.Checked = False
    End Sub

    Private Sub btShowAll_Click(sender As System.Object, e As System.EventArgs) Handles btShowAll.Click
        Me.TreeView1.ExpandAll()
    End Sub

    Private Sub btDelArticul_Click(sender As Object, e As EventArgs) Handles btDelArticul.Click
        If oIncomingNode.HasTiedNodes Then
            Select Case MsgBox("Действительно хотите удалить артикул? Это действие невозможно отменить или исправить!", vbYesNo)
                Case MsgBoxResult.Yes
                    oIncomingNode.ClearTiedNodes()
                    Me.lbArticul.Text = "Артикула нет"
                    Me.btDelArticul.Enabled = False
                    Me.btCreateArticul.Enabled = True

            End Select

        End If
    End Sub

    Private Sub btCreateArticul_Click(sender As Object, e As EventArgs) Handles btCreateArticul.Click
        If Me.oIncomingNode.SetTiedNodes({oIncomingNode}.ToList) Then
            Me.lbArticul.Text = oIncomingNode.DataFolder
            Me.btDelArticul.Enabled = True
            Me.btCreateArticul.Enabled = False
        End If

    End Sub
End Class