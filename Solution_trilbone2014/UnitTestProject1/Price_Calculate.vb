Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports PriceCalculator
Imports Service
Imports System.Windows.Forms
Imports System.Drawing

<TestClass()> Public Class Price_Calculate

    <TestMethod()> Public Sub TestMethod_calcPrice()
        Dim a As New clsPriceCalculatorData(eurRate:=70, UsdEuroRate:=1.14, bookpath:="H:\Google Drive_fossilcollecting\КОНТОРА\Рассчет продажи 2015.xlsx")
        'добавка при продаже
        Dim _prdl As Decimal = 0
        a.SetValues(Weight:=0.04, RawCost:=70, PrepCost:=20, pribil:=0.5)

        Dim _cp = 0.5 ' a.TunePrices(tunePrice:=20, priceType:=clsPriceCalculatorData.emOutPriceType.Ebay, accuracy:=0.1, setZeroIfMinus:=True)
        '=============
        Dim _out As String = ""
        For Each t In a.Prices
            _out += String.Format("{0} - {2}{1}", [Enum].GetName(GetType(clsPriceCalculatorData.emOutPriceType), t.Key), t.Value.Key, t.Value.Value)
            _out += ChrW(13)
        Next
        MsgBox(_out, vbOKOnly, "Цены с прибылью " & _cp * 100 & "%")


        For Each sh As clsPriceCalculatorData.emScheme In [Enum].GetValues(GetType(clsPriceCalculatorData.emScheme))

            '=============
            Dim _outpr = a.GetPayOut(scheme:=sh, memBasePrice:=(From c In a.Prices Where c.Key = clsPriceCalculatorData.emOutPriceType.mainRusInOffice Select c.Value.Value).FirstOrDefault, memResPrice:=(From c In a.Prices Where c.Key = clsPriceCalculatorData.emOutPriceType.Ebay Select c.Value.Value).FirstOrDefault, RealPrice:=(From c In a.Prices Where c.Key = clsPriceCalculatorData.emOutPriceType.Ebay Select c.Value.Value).FirstOrDefault + _prdl)
            _out = ""
            For Each t In _outpr
                _out += String.Format("Выплата {0} для {1} = {3}{2}", [Enum].GetName(GetType(clsPriceCalculatorData.emPriceType), t.Key.PriceType), [Enum].GetName(GetType(clsPriceCalculatorData.emRole), t.Key.Role), t.Value.Key, t.Value.Value)
                _out += ChrW(13)
            Next
            MsgBox(_out, vbOKOnly, "Выплаты " & [Enum].GetName(GetType(clsPriceCalculatorData.emScheme), sh))

            '=================
            Dim _outOW = a.GetOwnersPrices(scheme:=sh, rawDoly:=0.2)
            _out = ""

            For Each t In _outOW
                _out += String.Format("Выкуп {0} для {1} = {3}{2}", [Enum].GetName(GetType(clsPriceCalculatorData.emPriceType), t.Key.PriceType), [Enum].GetName(GetType(clsPriceCalculatorData.emRole), t.Key.Role), t.Value.Key, t.Value.Value)
                _out += ChrW(13)
            Next
            MsgBox(_out, vbOKOnly, "Выкуп " & [Enum].GetName(GetType(clsPriceCalculatorData.emScheme), sh))
        Next

        '============
ex:

        a.showexcel()


    End Sub


    <TestMethod()> Public Sub ucPriceCalc()
        'Trilbone_load.ModuleMain.initService()
        Dim _uc As New ucPriceCalc
        _uc.Dock = DockStyle.Fill
        _uc.init(euroRate:=70.11, usdEurRate:=1.13, bookPath:="E:\GoogleDrive_fossilcollecting\TrilboneTemplates\Рассчет продажи 2015.xlsx")
        _uc.SetData(Hunt_cost:=100, Prep_cost:=100, Weight:=0.123, ClearProfit:=0.5)
        Dim _fm As New Form
        With _fm
            .Size = Size.Add(_uc.Size, New Size(10, 40))
            .Controls.Add(_uc)
        End With

        _fm.Show()
        Application.Run(_fm)

    End Sub


End Class