Imports System.Linq
Imports Service.DataSet_oldGoodMapTableAdapters
Imports System.Data.SqlClient

Namespace DataSet_oldGoodMapTableAdapters
    Partial Class goodmapsTableAdapter

        Public Sub InitUpdateCommand()
            'If Not Me._adapter.UpdateCommand Is Nothing Then Return
            Dim _command = New Global.System.Data.SqlClient.SqlCommand()
            _command.Connection = Me.Connection
            _command.CommandText = "UPDATE [dbo].[goodmaps] SET " & _
                "[Артикул]=@Артикул,[Валюта (Закупочная цена)]=@currIncoming,[Валюта (Инвойс)]=@currInvoice,[Валюта (Розничная в офисе)]=@currInoffice,[Валюта (Розничная цена в магазине)]=@currInshop,[Группы]=@Группы,[Единица измерения]=@uom,[Закупочная цена]=@incomingPrice,[Инвойс]=@invoice,[Код]=@Код,[Наименование]=@Наименование,[Розничная в офисе]=@retailInOffice,[Розничная цена в магазине]=@retailInShop,[Буржуи на выставке]=@InShowEC,[Валюта (Буржуи на выставке)]=@CurrECShow,[EBAY]=@p1,[Валюта (EBAY)]=@p2,[Вес]=@p3,[Производственный номер или EAN13]=@p4,[Ответственный Препаратор]=@p5,[Время препарации в часах (общее)]=@p6,[Препараторы и время]=@p7,[Полная стоимость препарации в рублях]=@p8,[Полная стоимость закупки в рублях]=@p9,[Экспедиция (код)]=@p10,[Экспедиционный/закупочный номер]=@p11,[Экспедиционное/закупочное примечание]=@p12"

            _command.CommandText += " WHERE [Код] = @oldКод AND [Артикул]=@oldАртикул"
            '"WHERE [Внешний код] = @oldВнешний_код"

            _command.Parameters.Add("@p1", SqlDbType.NVarChar, 0, "EBAY")
            _command.Parameters.Add("@p2", SqlDbType.NVarChar, 0, "Валюта (EBAY)")
            _command.Parameters.Add("@p3", SqlDbType.NVarChar, 0, "Вес")
            _command.Parameters.Add("@p4", SqlDbType.NVarChar, 0, "Производственный номер или EAN13")
            _command.Parameters.Add("@p5", SqlDbType.NVarChar, 0, "Ответственный Препаратор")
            _command.Parameters.Add("@p6", SqlDbType.NVarChar, 0, "Время препарации в часах (общее)")
            _command.Parameters.Add("@p7", SqlDbType.NVarChar, 0, "Препараторы и время")
            _command.Parameters.Add("@p8", SqlDbType.NVarChar, 0, "Полная стоимость препарации в рублях")
            _command.Parameters.Add("@p9", SqlDbType.NVarChar, 0, "Полная стоимость закупки в рублях")
            _command.Parameters.Add("@p10", SqlDbType.NVarChar, 0, "Экспедиция (код)")
            _command.Parameters.Add("@p11", SqlDbType.NVarChar, 0, "Экспедиционный/закупочный номер")
            _command.Parameters.Add("@p12", SqlDbType.NVarChar, 0, "Экспедиционное/закупочное примечание")


            '_command.Parameters.Add("@CompanyName", SqlDbType.NVarChar, 0, "CompanyName")
            '_command.Parameters.Add("@CompanyName", SqlDbType.NVarChar, 0, "CompanyName")
            '_command.Parameters.Add("@CompanyName", SqlDbType.NVarChar, 0, "CompanyName")


            '[Буржуи в офисе], [Валюта (Буржуи в офисе)], [Почтовая(банк)], [Валюта (Почтовая(банк))], [Почтовая(PayPal)], [Валюта (Почтовая(PayPal))], [Неснижаемый остаток], [Штрихкод EAN13], [Штрихкод EAN8], [Штрихкод Code128], [Описание], [Минимальная цена], [Страна], [НДС], [Поставщик], [Архивный], [Объем], [Код модификации], [Образец взят на комиссию], [Схема расчета выплат],
            '[Процент прибыльности], [Требуется сделать фото], [Требуется сделать этикетку], [Требуется ремонт], [Требуется упаковка (коробочка)], [Требуется допрепарация], [Допрепарация подробно], [Код узла дерева описаний], [Тип упаковки], [Оформитель товара (сотрудник)], [Характеристика:Вырезанная фигурка], [Характеристика:Цвет и ассоциация], [Характеристика:Качество исходника], [Характеристика:Тип], [Характеристика:Кол-во кристаллов], [Характеристика:Color]) 

            'VALUES (@Гру" & _
            '    "ппы, @Код, @Наименование, @Внешний_код, @Артикул, @Единица_измерения, @Розничная" & _
            '    "_цена_в_магазине, @p1, @Розничная_в_офисе, @p4, @Буржуи_в_офисе, @p7, @p10, @p13" & _
            '    ", @p16, @p19, @Буржуи_на_выставке, @p22, @EBAY, @p25, @Инвойс, @p28, @Закупочная" & _
            '    "_цена, @p31, @Неснижаемый_остаток, @Штрихкод_EAN13, @Штрихкод_EAN8, @Штрихкод_Co" & _
            '    "de128, @Описание, @Минимальная_цена, @Страна, @НДС, @Поставщик, @Архивный, @Вес," & _
            '    " @Объем, @Код_модификации, @Образец_взят_на_комиссию, @Схема_расчета_выплат, @Пр" & _
            '    "оизводственный_номер_или_EAN13, @Ответственный_Препаратор, @p34, @Препараторы_и_" & _
            '    "время, @Полная_стоимость_препарации_в_рублях, @Полная_стоимость_закупки_в_рублях" & _
            '    ", @Процент_прибыльности, @p37, @p40, @p43, @Требуется_сделать_фото, @Требуется_с" & _
            '    "делать_этикетку, @Требуется_ремонт, @p46, @Требуется_допрепарация, @Допрепарация" & _
            '    "_подробно, @Код_узла_дерева_описаний, @Тип_упаковки, @p49, @p52, @p55, @p58, @p6" & _
            '    "1, @p64, @p67)

            _command.Parameters.Add("@Артикул", SqlDbType.NVarChar, 0, "Артикул")
            _command.Parameters.Add("@Код", SqlDbType.NVarChar, 0, "Код")
            _command.Parameters.Add("@Внешний_код", SqlDbType.NVarChar, 255, "Внешний код")
            _command.Parameters.Add("@currIncoming", SqlDbType.NVarChar, 0, "Валюта (Закупочная цена)")
            _command.Parameters.Add("@currInvoice", SqlDbType.NVarChar, 0, "Валюта (Инвойс)")
            _command.Parameters.Add("@currInoffice", SqlDbType.NVarChar, 0, "Валюта (Розничная в офисе)")
            _command.Parameters.Add("@currInshop", SqlDbType.NVarChar, 0, "Валюта (Розничная цена в магазине)")
            _command.Parameters.Add("@Группы", SqlDbType.NVarChar, 0, "Группы")
            _command.Parameters.Add("@uom", SqlDbType.NVarChar, 0, "Единица измерения")
            _command.Parameters.Add("@incomingPrice", SqlDbType.NVarChar, 0, "Закупочная цена")
            _command.Parameters.Add("@invoice", SqlDbType.NVarChar, 0, "Инвойс")
            _command.Parameters.Add("@Наименование", SqlDbType.NVarChar, 0, "Наименование")
            _command.Parameters.Add("@retailInOffice", SqlDbType.NVarChar, 0, "Розничная в офисе")
            _command.Parameters.Add("@retailInShop", SqlDbType.NVarChar, 0, "Розничная цена в магазине")
            _command.Parameters.Add("@InShowEC", SqlDbType.NVarChar, 0, "Буржуи на выставке")
            _command.Parameters.Add("@CurrECShow", SqlDbType.NVarChar, 0, "Валюта (Буржуи на выставке)")

            Dim _parameter = _command.Parameters.Add(
        "@oldКод", SqlDbType.NVarChar, 0, "Код")
            _parameter.SourceVersion = DataRowVersion.Original

            _parameter = _command.Parameters.Add(
         "@oldАртикул", SqlDbType.NVarChar, 0, "Артикул")
            _parameter.SourceVersion = DataRowVersion.Original
            Me._adapter.UpdateCommand = _command


        End Sub
    End Class
End Namespace

'// Create the UpdateCommand.
'   command = new SqlCommand(
'       "UPDATE Customers SET CustomerID = @CustomerID, CompanyName = @CompanyName " +
'       "WHERE CustomerID = @oldCustomerID", connection);

'   // Add the parameters for the UpdateCommand.
'   command.Parameters.Add("@CustomerID", SqlDbType.NChar, 5, "CustomerID");
'   command.Parameters.Add("@CompanyName", SqlDbType.NVarChar, 40, "CompanyName");
'   SqlParameter parameter = command.Parameters.Add(
'       "@oldCustomerID", SqlDbType.NChar, 5, "CustomerID");
'   parameter.SourceVersion = DataRowVersion.Original;

'   adapter.UpdateCommand = command;


Partial Class DataSet_oldGoodMap


    Public Function GetMcOld_result(shotcode As String, partname As String, groupname As String) As List(Of oldGoodMap_Result)
        If Me.goodmaps.Count = 0 Then Return New List(Of oldGoodMap_Result)
        Dim _res As System.Data.EnumerableRowCollection(Of goodmapsRow)
        If Not String.IsNullOrEmpty(shotcode) Then
            'фильтр по коду
            _res = From c In Me.goodmaps Where c.ActualCode.Contains(shotcode) Or IIf(String.IsNullOrEmpty(partname), False, c.Наименование.ToLower.Contains(partname.ToLower)) Or IIf(String.IsNullOrEmpty(groupname.ToLower), False, c.Группы.ToLower.Contains(groupname.ToLower))

        ElseIf Not String.IsNullOrEmpty(partname) Then
            'фильтр по имени
            _res = From c In Me.goodmaps Where c.Наименование.ToLower.Contains(partname.ToLower) Or IIf(String.IsNullOrEmpty(groupname), False, c.Группы.ToLower.Contains(groupname.ToLower))
        ElseIf Not String.IsNullOrEmpty(groupname) Then
            'фильтр по группе
            _res = From c In Me.goodmaps Where c.Группы.ToLower.Contains(groupname.ToLower)

        Else
            Return New List(Of oldGoodMap_Result)
        End If

        Dim _out As New List(Of oldGoodMap_Result)
        _out.AddRange(From c In _res Select c.GetOldMapResult)

        For Each t In _out
            t.IsNew = False
        Next

        Return _out


    End Function
    ''' <summary>
    ''' запись значения таблицы в датасет
    ''' </summary>
    ''' <param name="row"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function UpdateMcOld(row As oldGoodMap_Result) As Integer
        If row.IsNew Then
            If row.SampleNumberObj Is Nothing OrElse row.SampleNumberObj.CodeIsCorrect = False Then
                MsgBox("Необходимо ввести код или артикул.", vbCritical)
                Return -1
            End If
            row.Внешний_код = row.ActualCode.GetHashCode Xor Date.Now.GetHashCode
            'If String.IsNullOrEmpty(row.Группы) Then row.Группы = ""
            'If String.IsNullOrEmpty(row.Код) Then row.Код = ""
            'If String.IsNullOrEmpty(row.Наименование) Then row.Наименование = ""
            'If String.IsNullOrEmpty(row.Внешний_код) Then row.Внешний_код = ""
            'If String.IsNullOrEmpty(row.Артикул) Then row.Валюта__Инвойс_ = ""
            'If String.IsNullOrEmpty(row.Валюта__Инвойс_) Then row.Валюта__Инвойс_ = ""
            'If String.IsNullOrEmpty(row.Валюта__Инвойс_) Then row.Валюта__Инвойс_ = ""




            'добавить сюда
            With row
                Me.goodmaps.AddgoodmapsRow(Группы:=.Группы, EBAY:=.EBAY, Артикул:=.Артикул, Архивный:="", Буржуи_в_офисе:="", Буржуи_на_выставке:=.Буржуи_на_выставке, Вес:=.Вес, Внешний_код:=.Внешний_код, Допрепарация_подробно:="", Единица_измерения:=.Единица_измерения, Закупочная_цена:=.Закупочная_цена, Инвойс:=.Инвойс, Код:=.Код, Код_модификации:="", Код_узла_дерева_описаний:="", Минимальная_цена:="", Наименование:=.Наименование, НДС:="", Неснижаемый_остаток:="", Образец_взят_на_комиссию:="", Объем:="", Описание:="", Ответственный_Препаратор:=.Ответственный_Препаратор, Полная_стоимость_закупки_в_рублях:=.Полная_стоимость_закупки_в_рублях, Полная_стоимость_препарации_в_рублях:=.Полная_стоимость_препарации_в_рублях, Поставщик:="", Препараторы_и_время:=.Препараторы_и_время, Производственный_номер_или_EAN13:=.Производственный_номер_или_EAN13, Процент_прибыльности:="", Розничная_в_офисе:=.Розничная_в_офисе, Розничная_цена_в_магазине:=.Розничная_цена_в_магазине, Страна:="", Схема_расчета_выплат:="", Тип_упаковки:="", Требуется_допрепарация:="", Требуется_ремонт:="", Требуется_сделать_фото:="", Требуется_сделать_этикетку:="", Штрихкод_Code128:="", Штрихкод_EAN13:="", Штрихкод_EAN8:="", _Валюта__EBAY_:=.Валюта__EBAY_, _Валюта__Буржуи_в_офисе_:="", _Валюта__Буржуи_на_выставке_:=.Валюта__Буржуи_на_выставке_, _Валюта__Закупочная_цена_:=.Валюта__Закупочная_цена_, _Валюта__Инвойс_:=.Валюта__Инвойс_, _Валюта__Почтовая_PayPal__:="", _Валюта__Почтовая_банк__:="", _Валюта__Розничная_в_офисе_:=.Валюта__Розничная_в_офисе_, _Валюта__Розничная_цена_в_магазине_:=.Валюта__Розничная_цена_в_магазине_, _Время_препарации_в_часах__общее_:=.Время_препарации_в_часах__общее_, _Оформитель_товара__сотрудник_:="", _Почтовая_PayPal_:="", _Почтовая_банк_:="", _Требуется_упаковка__коробочка_:="", _Характеристика_Color:="", _Характеристика_Вырезанная_фигурка:="", _Характеристика_Качество_исходника:="", _Характеристика_Кол_во_кристаллов:="", _Характеристика_Тип:="", _Характеристика_Цвет_и_ассоциация:="", _Экспедиционное_закупочное_примечание:=.Экспедиционное_закупочное_примечание, _Экспедиционный_закупочный_номер:=.Экспедиционный_закупочный_номер, _Экспедиция__код_:=.Экспедиция__код_)
            End With


            row.IsNew = False

            Return 1
        Else
            Dim _dw = From c In Me.goodmaps Where c.ActualCode = IIf(row.CodeChanged, row.oldActualCode, row.ActualCode)
            Select Case _dw.Count
                Case 0
                    Return 0
                Case 1
                    'ok only one record
                    Dim _ch = _dw.First
                    _ch.BeginEdit()
                    With _ch
                        .Артикул = row.Артикул
                        ._Валюта__Закупочная_цена_ = row.Валюта__Закупочная_цена_
                        ._Валюта__Инвойс_ = row.Валюта__Инвойс_
                        ._Валюта__Розничная_в_офисе_ = row.Валюта__Розничная_в_офисе_
                        ._Валюта__Розничная_цена_в_магазине_ = row.Валюта__Розничная_цена_в_магазине_
                        .Внешний_код = row.Внешний_код
                        .Группы = row.Группы
                        .Единица_измерения = row.Единица_измерения
                        .Закупочная_цена = row.Закупочная_цена
                        .Инвойс = row.Инвойс
                        .Код = row.Код
                        .Наименование = row.Наименование
                        .Розничная_в_офисе = row.Розничная_в_офисе
                        .Розничная_цена_в_магазине = row.Розничная_цена_в_магазине

                        .Буржуи_на_выставке = row.Буржуи_на_выставке
                        ._Валюта__Буржуи_на_выставке_ = row.Валюта__Буржуи_на_выставке_
                        .EBAY = row.EBAY
                        ._Валюта__EBAY_ = row.Валюта__EBAY_
                        ._Валюта__Закупочная_цена_ = row.Валюта__Закупочная_цена_
                        .Вес = row.Вес
                        ._Время_препарации_в_часах__общее_ = row.Время_препарации_в_часах__общее_
                        .Закупочная_цена = row.Закупочная_цена
                        .Ответственный_Препаратор = row.Ответственный_Препаратор
                        .Полная_стоимость_закупки_в_рублях = row.Полная_стоимость_закупки_в_рублях
                        .Полная_стоимость_препарации_в_рублях = row.Полная_стоимость_препарации_в_рублях
                        .Препараторы_и_время = row.Препараторы_и_время
                        .Производственный_номер_или_EAN13 = row.Производственный_номер_или_EAN13
                        ._Экспедиционное_закупочное_примечание = row.Экспедиционное_закупочное_примечание
                        ._Экспедиционный_закупочный_номер = row.Экспедиционный_закупочный_номер
                        ._Экспедиция__код_ = row.Экспедиция__код_
                        '._Валюта__Перевозка_= row.Валюта__Перевозка_
                        '.Перевозка = row.Перевозка

                    End With
                    _ch.EndEdit()
                    Return 1
                Case Else
                    'several record on one code!
                    If row.CodeChanged Then
                        'сравнить по другим полям и вытащить именно эту строку
                        _dw = From c In Me.goodmaps Where c.ActualCode = IIf(row.CodeChanged, row.oldActualCode, row.ActualCode) And c.Наименование.Equals(row.Наименование) And c.Единица_измерения.Equals(row.Единица_измерения)
                        'иначе меняем все строки с одинаковым номером
                    End If
                    For Each t In _dw
                        t.BeginEdit()
                        With t
                            .Артикул = row.Артикул
                            ._Валюта__Закупочная_цена_ = row.Валюта__Закупочная_цена_
                            ._Валюта__Инвойс_ = row.Валюта__Инвойс_
                            ._Валюта__Розничная_в_офисе_ = row.Валюта__Розничная_в_офисе_
                            ._Валюта__Розничная_цена_в_магазине_ = row.Валюта__Розничная_цена_в_магазине_
                            .Внешний_код = row.Внешний_код
                            .Группы = row.Группы
                            .Единица_измерения = row.Единица_измерения
                            .Закупочная_цена = row.Закупочная_цена
                            .Инвойс = row.Инвойс
                            .Код = row.Код
                            .Наименование = row.Наименование
                            .Розничная_в_офисе = row.Розничная_в_офисе
                            .Розничная_цена_в_магазине = row.Розничная_цена_в_магазине

                            .Буржуи_на_выставке = row.Буржуи_на_выставке
                            ._Валюта__Буржуи_на_выставке_ = row.Валюта__Буржуи_на_выставке_
                            .EBAY = row.EBAY
                            ._Валюта__EBAY_ = row.Валюта__EBAY_
                            ._Валюта__Закупочная_цена_ = row.Валюта__Закупочная_цена_
                            .Вес = row.Вес
                            ._Время_препарации_в_часах__общее_ = row.Время_препарации_в_часах__общее_
                            .Закупочная_цена = row.Закупочная_цена
                            .Ответственный_Препаратор = row.Ответственный_Препаратор
                            .Полная_стоимость_закупки_в_рублях = row.Полная_стоимость_закупки_в_рублях
                            .Полная_стоимость_препарации_в_рублях = row.Полная_стоимость_препарации_в_рублях
                            .Препараторы_и_время = row.Препараторы_и_время
                            .Производственный_номер_или_EAN13 = row.Производственный_номер_или_EAN13
                            ._Экспедиционное_закупочное_примечание = row.Экспедиционное_закупочное_примечание
                            ._Экспедиционный_закупочный_номер = row.Экспедиционный_закупочный_номер
                            ._Экспедиция__код_ = row.Экспедиция__код_
                            '._Валюта__Перевозка_= row.Валюта__Перевозка_
                            '.Перевозка = row.Перевозка

                        End With
                        t.EndEdit()
                    Next
                    Return _dw.Count
            End Select
        End If

        

    End Function


    Partial Public Class goodmapsRow
        Public ReadOnly Property ActualCode As String
            Get
                If String.IsNullOrEmpty(Me.Артикул) Then
                    Return Me.Код
                End If
                Return Me.Артикул
            End Get
        End Property

        Public Function GetOldMapResult() As oldGoodMap_Result
            Dim _out As New oldGoodMap_Result
            With _out
                .Артикул = Me.Артикул
                .Валюта__Закупочная_цена_ = Me._Валюта__Закупочная_цена_
                .Валюта__Инвойс_ = Me._Валюта__Инвойс_
                .Валюта__Розничная_в_офисе_ = Me._Валюта__Розничная_в_офисе_
                .Валюта__Розничная_цена_в_магазине_ = Me._Валюта__Розничная_цена_в_магазине_
                .Внешний_код = Me.Внешний_код
                .Группы = Me.Группы
                .Единица_измерения = Me.Единица_измерения
                .Закупочная_цена = Me.Закупочная_цена
                .Инвойс = Me.Инвойс
                .Код = Me.Код
                .Наименование = Me.Наименование
                .Розничная_в_офисе = Me.Розничная_в_офисе
                .Розничная_цена_в_магазине = Me.Розничная_цена_в_магазине
                .Буржуи_на_выставке = Me.Буржуи_на_выставке
                .Валюта__Буржуи_на_выставке_ = Me._Валюта__Буржуи_на_выставке_
                .EBAY = Me.EBAY
                .Валюта__EBAY_ = Me._Валюта__EBAY_
                .Валюта__Закупочная_цена_ = Me._Валюта__Закупочная_цена_
                .Вес = Me.Вес
                .Время_препарации_в_часах__общее_ = Me._Время_препарации_в_часах__общее_
                .Закупочная_цена = Me.Закупочная_цена
                .Ответственный_Препаратор = Me.Ответственный_Препаратор
                .Полная_стоимость_закупки_в_рублях = Me.Полная_стоимость_закупки_в_рублях
                .Полная_стоимость_препарации_в_рублях = Me.Полная_стоимость_препарации_в_рублях
                .Препараторы_и_время = Me.Препараторы_и_время
                .Производственный_номер_или_EAN13 = Me.Производственный_номер_или_EAN13
                .Экспедиционное_закупочное_примечание = Me._Экспедиционное_закупочное_примечание
                .Экспедиционный_закупочный_номер = Me._Экспедиционный_закупочный_номер
                .Экспедиция__код_ = Me._Экспедиция__код_
                '._Валюта__Перевозка_= row.Валюта__Перевозка_
                '.Перевозка = row.Перевозка
            End With

            Return _out
        End Function
    End Class

End Class

