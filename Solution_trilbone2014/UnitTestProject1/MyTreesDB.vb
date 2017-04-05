Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Trilbone
Imports Microsoft.SqlServer.Types
<TestClass()> Public Class UnitTestMyTreesDB
    'триггер в таблицу узла для создания hierId
    '   CREATE TRIGGER [HierTrigger]
    'ON [dbo].[edmNodeObjectSet]
    'FOR  INSERT, UPDATE
    'AS
    'BEGIN
    '	SET NOCOUNT ON;
    '	UPDATE T
    'SET T.HierID=sys.hierarchyid::Parse(T.VirtualFullPath)
    '   FROM [dbo].[edmNodeObjectSet] T
    '   JOIN inserted i ON T.Id = i.Id
    '   --LEFT JOIN deleted d ON T.id = d.id WHERE d.id IS NULL
    'END

    'последний потомок
    '    declare @input int;
    'set @input=4
    'declare @parent as sys.hierarchyid;
    '--получить поле HierID для id родителя
    'SELECT @parent= HierID from edmnodeobjectset n
    'WHERE n.id=@input

    'declare @Last sys.hierarchyid;
    'declare @id int;

    'SELECT @Last = MAX(HierID) FROM edmnodeobjectset WHERE HierID.GetAncestor(1) = @Parent


    '--получить последнего потомка
    'select @mhr=max(HierID), @id=Id from edmnodeobjectset n
    'where HierID=(@hr.GetAncestor(1))
    'group by Id


    'select * from edmnodeobjectset n
    'where Id=@id

    'CREATE TABLE [dbo].[Test]([Id] [hierarchyid] NOT NULL,  [Name] [nvarchar](50) NULL)
    'DECLARE @Parent AS HierarchyID = CAST('/2/1/' AS HierarchyID) -- Get Current Parent
    'DECLARE @Last AS HierarchyID
    'SELECT @Last = MAX(Id) FROM Test WHERE Id.GetAncestor(1) = @Parent -- Find Last Id for this Parent

    'INSERT INTO Test(Id,Name) VALUES(@Parent.GetDescendant(@Last, NULL),'Sydney') -- Insert after Last Id


    <TestMethod()> Public Sub TestMethod_CreateUser()
        'Dim _mess As String = ""
        'clsTreeService.Connect(_mess)
        'MsgBox(_mess, MsgBoxStyle.OkOnly)
        'Dim a = clsTreeService.MyTreeContext
        'Dim _us = edmUser.CreateedmUser(id:=0, name:="default")
        'a.AddToedmUserSet(_us)
        'a.SaveChanges()
    End Sub

    <TestMethod()> Public Sub TestMethod_CreateedmFile()
        'Dim _mess As String = ""
        'If Not clsTreeService.Connect(_mess) Then
        '    MsgBox("Нет подключения! " & _mess, vbCritical)
        '    Return
        'End If
        'Dim a = clsTreeService.MyTreeContext
        'Dim _us = edmFile.CreateedmFile(id:=0, edmUserID:=1, name:="Vend")
        'a.AddToedmFileSet(_us)
        'a.SaveChanges()
    End Sub
    <TestMethod()> Public Sub TestMethod_CreateedmVirtualTree()
        'Dim _mess As String = ""
        'If Not clsTreeService.Connect(_mess) Then
        '    MsgBox("Нет подключения! " & _mess, vbCritical)
        '    Return
        'End If
        'Dim a = clsTreeService.MyTreeContext
        'Dim _us = edmVirtualTree.CreateedmVirtualTree(id:=0, nameEN:="Systematica", nameRUS:="Систематика")
        'a.AddToedmVirtualTreeSet(_us)
        ''необходимо создать корневой узел
        'Dim _nd = edmNodeObject.CreateedmNodeObject(id:=0, parentNodeID:=0, complexDescription:=New Trilbone.Description With {.DescriptionEN = "virtual tree systematica", .DescriptionRUS = "виртуальное дерево систематики", .Info = "", .NameEN = "Systematica", .NameRUS = "Систематика"})
        '_nd.VirtualFullPath = "/"
        ''и привязать его к виртуальному дереву
        '_nd.edmVirtualTree = _us

        'a.AddToedmNodeObjectSet(_nd)
        'a.SaveChanges()
    End Sub
    <TestMethod()> Public Sub TestMethod_CreateedmNodeTree()
        'Dim _mess As String = ""
        'If Not clsTreeService.Connect(_mess) Then
        '    MsgBox("Нет подключения! " & _mess, vbCritical)
        '    Return
        'End If
        'Dim a = clsTreeService.MyTreeContext
        ''---------------------
        'Dim _nd = edmNodeObject.CreateedmNodeObject(id:=0, parentNodeID:=0, complexDescription:=New Trilbone.Description With {.DescriptionEN = "virtual tree systematica", .DescriptionRUS = "виртуальное дерево систематики", .Info = "", .NameEN = "Systematica", .NameRUS = "Систематика"})
        ''необходимо запросить узел-родитель
        ''созать у узла
        'Dim _ndr As edmNodeObject = Nothing

        'Dim _ho = Microsoft.SqlServer.Types.SqlHierarchyId.Parse(_ndr.VirtualFullPath)
        ''узнать кол-во всех потомков узла
        ''выбрать самого большого потомка узла


        ''и привязать новый узел к узлу-родителю
        '_nd.VirtualFullPath = "/"
        ''скопировать деревья родителя (виртуальное либо частнЫЕ(коллекция))
        'If Not _ndr.edmVirtualTree Is Nothing Then
        '    'если родитель виртуальный
        '    _nd.edmVirtualTree = _ndr.edmVirtualTree
        'Else
        '    'если родитель частный
        '    'то указать файл, куда добавить узел???? -- добавить для всех файлов, где есть родитель
        '    _nd.edmPrivateTreeList = _ndr.edmPrivateTreeList ' From c In _ndr.edmPrivateTreeList Where c.edmFileID = 0
        'End If

    End Sub



    <TestMethod()> Public Sub TestMethod_CreateedmPrivateTree()
        ''создание поддерева систематики
        'Dim _mess As String = ""
        'If Not clsTreeService.Connect(_mess) Then
        '    MsgBox("Нет подключения! " & _mess, vbCritical)
        '    Return
        'End If
        'Dim a = clsTreeService.MyTreeContext
        'Dim _us = edmPrivateTree.CreateedmPrivateTree(id:=0, name:="Systematica", edmFileID:=1)
        '_us.edmVirtualTree = (From c In a.edmVirtualTreeSet Where c.NameEN.Equals("Systematica")).FirstOrDefault
        ''необходимо создать/привязать корневой узел
        'a.AddToedmPrivateTreeSet(_us)
        'a.SaveChanges()
    End Sub

End Class