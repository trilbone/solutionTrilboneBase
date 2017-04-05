Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Service
Imports Service.clsApplicationTypes
Imports System.Windows.Forms
Imports System.Drawing

<TestClass()> Public Class UnitTest_SellInfo

    <TestMethod()> Public Sub ucSellGood()
        Trilbone_load.ModuleMain.initService()
        Dim _uc As New ucSellGood
        _uc.Dock = DockStyle.Fill
        _uc.init()
        Dim _fm As New Form
        With _fm
            .Size = Size.Add(_uc.Size, New Size(10, 40))
            .Controls.Add(_uc)
        End With

        _fm.Show()
        Application.Run(_fm)

    End Sub

    <TestMethod()> Public Sub ucClient()
        Trilbone_load.ModuleMain.initService()
        Dim _uc As New ucClient
        _uc.Dock = DockStyle.Fill
        Dim _msi As iMoySkladDataProvider = Nothing
        Do Until Not _msi Is Nothing
            _msi = clsApplicationTypes.MoySklad(False)
        Loop

        Dim _sp = Sub(sender As Object, e As ucClient.CustomerSelectedEventArgs)
                      MsgBox(String.Format("Клиент выбран: {0} {1}", e.Customer.FullName, e.Customer.UUID))
                  End Sub
        AddHandler _uc.CustomerSelected, _sp

        _uc.init(_msi)
        Dim _fm As New Form
        With _fm
            .Size = Size.Add(_uc.Size, New Size(10, 40))
            .Controls.Add(_uc)
        End With

        _fm.Show()
        Application.Run(_fm)


    End Sub
    <TestMethod()> Public Sub ucGoodList()
        Trilbone_load.ModuleMain.initService()
        Dim _uc As New ucGoodList
        _uc.Dock = DockStyle.Fill
        Dim _msi As iMoySkladDataProvider = Nothing
        Do Until Not _msi Is Nothing
            _msi = clsApplicationTypes.MoySklad(False)
        Loop

        Dim _sp = Sub(sender As Object, e As ucGoodList.GoodListCreatedEventArgs)
                      MsgBox(String.Format("список заполнен: {0}поз. на сумму {1}{2}", e.GoodList.Count, e.ListAmount, e.ListCurrency))
                  End Sub
        AddHandler _uc.GoodListCreated, _sp

        _uc.init(_msi)
        Dim _fm As New Form
        With _fm
            .Size = Size.Add(_uc.Size, New Size(10, 40))
            .Controls.Add(_uc)
        End With

        _fm.Show()
        Application.Run(_fm)
    End Sub

    <TestMethod()> Public Sub uciMyTreeTest()
        Trilbone_load.ModuleMain.initService()

        Dim _result = clsApplicationTypes.MyTrees.GetAllNamesByVolume("Sys")

        MsgBox(_result.Count)

    End Sub

    <TestMethod()> Public Sub ucCell()
        Trilbone_load.ModuleMain.initService()
        Dim _uc As New uc_Cell
        _uc.Dock = DockStyle.Fill
        Dim _msi As iMoySkladDataProvider = Nothing
        Do Until Not _msi Is Nothing
            _msi = clsApplicationTypes.MoySklad(False)
        Loop

        'Dim _sp = Sub(sender As Object, e As ucGoodList.GoodListCreatedEventArgs)
        '              MsgBox(String.Format("список заполнен: {0}поз. на сумму {1}{2}", e.GoodList.Count, e.ListAmount, e.ListCurrency))
        '          End Sub
        'AddHandler _uc.GoodListCreated, _sp

        _uc.init(_msi)
        Dim _fm As New Form
        With _fm
            .Size = Size.Add(_uc.Size, New Size(10, 40))
            .Controls.Add(_uc)
        End With

        _fm.Show()
        Application.Run(_fm)

    End Sub

End Class