Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports System.Windows.Forms
Imports System.Drawing
Imports Service

<TestClass()> Public Class UnitTeststrLOT

    <TestMethod()> Public Sub TestMetodLotConvert()
        'Trilbone_load.ModuleMain.initService()
        'Dim _uc As New ucPriceCalc
        '_uc.Dock = DockStyle.Fill
        '_uc.init(euroRate:=70.11, usdEurRate:=1.13, bookPath:="E:\GoogleDrive_fossilcollecting\TrilboneTemplates\Рассчет продажи 2015.xlsx")
        '_uc.SetData(Hunt_cost:=100, Prep_cost:=100, Weight:=0.123, ClearProfit:=0.5)
        'Dim _fm As New Form
        'With _fm
        '    .Size = Size.Add(_uc.Size, New Size(10, 40))
        '    .Controls.Add(_uc)
        'End With

        '_fm.Show()
        'Application.Run(_fm)

        Dim _lot As New iMoySkladDataProvider.strLot
        Dim _lot2 As New iMoySkladDataProvider.strLot

        With _lot
            .LotQty = 10
            .LotUomName = "кг"
            .LotCurrency = "EUR"
            .LotCategory = 0
            .LotPrice = 50
            .AddPrice(.LotPrice / .LotQty, iMoySkladDataProvider.emPriceType.BuyPrice)
        End With

        With _lot2
            .LotQty = 200
            .LotUomName = "шт"
            .LotCurrency = "EUR"
            .LotCategory = 0
            .LotPrice = 0
            '.AddPrice(.LotPrice / .LotQty, iMoySkladDataProvider.emPriceType.BuyPrice)
        End With

        Dim _result = 0 '_lot.ConverLotToUom("шт", 500)

        '_lot = _lot - _lot2
        _lot = _lot.MinusLot(_lot2, 100)

        '_lot.CalculatedConvertToUom(0.023, "шт")
        '_lot.ConvertLotToCurrency()

        Dim _mess = String.Format("лот {1}{0} всего на {2}{3}, 1 поз: {4}{5}, koeff {6}", _lot.LotUomName, _lot.LotQty, _lot.LotPrice, _lot.LotCurrency, _lot.LotUnitPrices.FirstOrDefault.value, _lot.LotUnitPrices.FirstOrDefault.BaseCurrency, _result)

        MsgBox(_mess)
    End Sub

End Class