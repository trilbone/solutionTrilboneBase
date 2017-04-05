Public Class clsImportManager
    Private oDataArray As New List(Of String)

    ''' <summary>
    ''' нераспределенные данные
    ''' </summary>
    ''' <returns></returns>
    Property OtherData As New Dictionary(Of String, String)
    ''' <summary>
    ''' основное название
    ''' </summary>
    ''' <returns></returns>
    Property Header As String = ""
    ''' <summary>
    ''' цена с валютой
    ''' </summary>
    ''' <returns></returns>
    Property Price As String = ""
    ''' <summary>
    ''' разбитые размеры
    ''' </summary>
    ''' <returns></returns>
    Property StoneSizes As New List(Of String)
    ''' <summary>
    ''' вес
    ''' </summary>
    ''' <returns></returns>
    Property Weight As String = ""

    ''' <summary>
    ''' размеры фоссилий, где ключ = название фоссилий
    ''' </summary>
    ''' <returns></returns>
    Property FossilSizes As New Dictionary(Of String, List(Of String))


    ''' <summary>
    ''' проверяет входной текст и разбивает на строки
    ''' </summary>
    ''' <param name="inp"></param>
    ''' <param name="splitter"></param>
    ''' <returns></returns>
    Public Function Import(inp As String, Optional splitter As Char() = Nothing) As List(Of String)
        'разделитель
        If splitter Is Nothing Then
            splitter = {ChrW(13), ChrW(10)}
        End If
        Dim _str = inp.Split(splitter, StringSplitOptions.RemoveEmptyEntries)
        oDataArray = New List(Of String)
        For Each t In _str
            If Not String.IsNullOrEmpty(t.Trim) Then
                oDataArray.Add(t.Trim)
            End If
        Next
        Return oDataArray
    End Function
    ''' <summary>
    ''' описывает формат текста конкретного поставщика
    ''' </summary>
    Public Structure strDataImportIndividual
        ' отсутствующие индексы в -1!!

        Property SupplierName As String

        Property datalinesplitter As Char()
        Property headerlineindex As Integer

        ''' <summary>
        ''' если цена в заголовке, то индекс поставить как заголовка
        ''' </summary>
        ''' <returns></returns>
        Property priceLineIndex As Integer
        Property pricesplitter As Char()
        'Property stoneSizelineindex As Integer
        Property stoneSizelineCaption As String

        Property stoneSizesplitter As Char()
        Property stoneSizeUnit As emSizeUnits
        'Property Weightlineindex As Integer
        Property WeightlineCaption As String

        Property WeightUnit As emWeightUnits
        Property fossilcount As Integer
        'Property fossilsizesstartlineindex As Integer
        Property fossilsizesCaption As String
        Property fossilSizesplitter As Char()
        Property fossilSizeUnit As emSizeUnits


        Public Enum emSizeUnits
            mm = 0
            cm = 1
        End Enum
        Public Enum emWeightUnits
            g = 0
            kg = 1
        End Enum

        Function PriceInHeader() As Boolean
            If priceLineIndex = headerlineindex Then
                Return True
            End If
            Return False
        End Function
    End Structure
    ''' <summary>
    ''' отсутствующие индексы в -1!!
    ''' </summary>
    ''' <param name="info"></param>
    ''' <returns></returns>
    Public Function ParseIndividual(info As strDataImportIndividual) As Boolean
        OtherData = New Dictionary(Of String, String)
        If oDataArray.Count = 0 Then Return False

        For i = 0 To oDataArray.Count - 1
            Select Case i
                Case info.headerlineindex
                    'заголовок=основной обьект
                    Header = oDataArray(i)
                    If info.PriceInHeader Then
                        'цена в заголовке
                        Dim _str = New List(Of String)
                        _str.AddRange(oDataArray(i).Split(info.pricesplitter, StringSplitOptions.RemoveEmptyEntries))
                        Header = _str(0).Trim
                        If _str.Count > 1 Then
                            Price = _str(1).Trim
                        End If

                    End If
                Case info.priceLineIndex
                    'цена
                    Dim _str = New List(Of String)
                    _str.AddRange(oDataArray(i).Split(info.pricesplitter, StringSplitOptions.RemoveEmptyEntries))
                    If _str.Count > 1 Then
                        Price = _str(1).Trim
                    End If

                Case Else
                    'поля данных не по индексу

                    If oDataArray(i).ToLower.StartsWith(info.stoneSizelineCaption.ToLower) Then
                        'размер образца
                        Dim _str = New List(Of String)
                        _str.AddRange(oDataArray(i).Split(info.datalinesplitter, StringSplitOptions.RemoveEmptyEntries))
                        If _str.Count > 1 Then
                            StoneSizes = New List(Of String)
                            Dim _res = _str(1).Split(info.stoneSizesplitter, StringSplitOptions.RemoveEmptyEntries)
                            StoneSizes.AddRange(_res)
                            StoneSizes.ForEach(Sub(x) x.Trim())
                        End If


                    ElseIf oDataArray(i).ToLower.StartsWith(info.WeightlineCaption.ToLower) Then
                        'вес
                        Dim _str = New List(Of String)
                        _str.AddRange(oDataArray(i).Split(info.datalinesplitter, StringSplitOptions.RemoveEmptyEntries))
                        If _str.Count > 1 Then
                            Weight = _str(1).Trim
                        End If


                    ElseIf oDataArray(i).ToLower.StartsWith(info.fossilsizesCaption.ToLower) Then
                        'отдельные фоссилы записаны подряд, сначала размер идет основной фоссилии, потом другие в формате [название][разделитель][строка размера]
                        FossilSizes = New Dictionary(Of String, List(Of String))
                        For j = i To i + info.fossilcount - 1
                            Dim _str = New List(Of String)
                            _str.AddRange(oDataArray(i).Split(info.datalinesplitter, StringSplitOptions.RemoveEmptyEntries))
                            If _str.Count > 1 Then
                                Dim _strfs = New List(Of String)
                                _strfs.AddRange(_str(1).Split(info.fossilSizesplitter, StringSplitOptions.RemoveEmptyEntries))
                                'TODO добавить исключение всяких скобок типа (with spines)
                                _strfs.ForEach(Sub(x) x.Trim())
                                If info.fossilcount <= 1 Then
                                    FossilSizes.Add(Header.Trim, _strfs)
                                Else
                                    FossilSizes.Add(_str(0), _strfs)
                                End If
                            End If
                        Next
                    Else
                        'прочие
                        Dim _str = New List(Of String)
                        _str.AddRange(oDataArray(i).Split(info.datalinesplitter, StringSplitOptions.RemoveEmptyEntries))
                        If _str.Count > 1 Then
                            OtherData.Add(_str(0).Trim, _str(1).Trim)
                        End If
                    End If
            End Select
        Next
        Return True
    End Function



End Class
