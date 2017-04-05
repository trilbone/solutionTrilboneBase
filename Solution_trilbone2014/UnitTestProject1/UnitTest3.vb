Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Service

<TestClass()> Public Class SupplierDataParcer

    <TestMethod()> Public Sub SuppDataParse()
        Dim _buff As String
        If My.Computer.Clipboard.ContainsText Then
            _buff = My.Computer.Clipboard.GetText

            Dim _manager = New Service.clsImportManager
            Dim _data = _manager.Import(_buff)
            If _data.Count = 0 Then Return

            'выбрать поставщика
            Dim _supp As New clsImportManager.strDataImportIndividual
            With _supp
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
                .SupplierName = "Yakov"
                '.Weightlineindex = 6
                .WeightlineCaption = "Weight"
                .WeightUnit = clsImportManager.strDataImportIndividual.emWeightUnits.kg
            End With

            If _manager.ParseIndividual(_supp) Then
                'заполнить форму данными из _manager
                MsgBox("ok")
            End If



        End If
    End Sub

End Class