Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports System.Windows.Forms
Imports System.Drawing
Imports Service
Imports Service.clsApplicationTypes
Imports Trilbone_load
Imports System.Text.RegularExpressions


<TestClass()> Public Class EbaySearch
    <TestMethod()> Public Sub TM_ebaySingleCalls()
        Trilbone_load.ModuleMain.initService()
        Dim _res2 = clsFindingService.GetSingleItem("201368585420") 'unsold 191545861598
        Dim _res = clsFindingService.GetSingleItem("191545861598")
        If _res2.WatchCountSpecified Then
            MsgBox("ok")
        End If
    End Sub

    <TestMethod()> Public Sub TM_ebayCalls()
        Trilbone_load.ModuleMain.initService()
        Dim _res = clsFindingService.FindByWord("trilbone")
        For Each t In _res

            Dim _res2 = clsFindingService.GetSingleItem(t.itemId)

            If _res2.WatchCountSpecified Then
                MsgBox("ok")
            End If
        Next

    End Sub
    <TestMethod()> Public Sub TM_word()
        'Trilbone_load.ModuleMain.initService()
        'Dim _uc As New ucActiveWord
        '_uc.Dock = DockStyle.Fill
        '_uc.init({"test1", "test2", "asaphus bottnicus"})
        'Dim _fm As New Form
        'With _fm
        '    .Size = Size.Add(_uc.Size, New Size(10, 40))
        '    .Controls.Add(_uc)
        'End With

        '_fm.Show()
        'Application.Run(_fm)

        Dim s As Decimal = 2.64

        MsgBox(s.ToString("#"))
    End Sub

    <TestMethod()> Public Sub TM_ebayInfo()
        Trilbone_load.ModuleMain.initService()
        Dim _uc As New ucEbayHistory
        _uc.Dock = DockStyle.Fill

        Dim _fm As New Form
        With _fm
            .Size = Size.Add(_uc.Size, New Size(10, 10))
            .Controls.Add(_uc)
        End With

        _fm.Show()
        Application.Run(_fm)
    End Sub



    <TestMethod()> Public Sub TM_ebaySearch()
        Trilbone_load.ModuleMain.initService()

        Dim _uc As New UserControlEbaySearch
        _uc.Dock = DockStyle.Fill

        Dim _fm As New Form
        With _fm
            .Size = New Size(1100, 510)
            .Controls.Add(_uc)
        End With


        _fm.Show()
        Application.Run(_fm)
    End Sub

    <TestMethod()> Public Sub TM_ebayfind()
        Dim _res = clsFindingService.FindByWord("bottnicus")
        Debug.WriteLine("collection received " & _res.Count)
    End Sub


End Class