Imports nopTypes.Nop.Plugin.Misc.panoRazziRestService

Public Class uc_attributes


#Region "Enabled for visual constructor"

#End Region

#Region "Data bindings"

    Dim oData As clsSAObjectCollection
    Dim oDefaultLang As lng
    Private oSelectedObjects As clsSAObjectCollection

    Public Sub init(lang As lng, DataSource As clsSAObjectCollection)
        oData = DataSource
        oDefaultLang = lang
        oSelectedObjects = clsSAObjectCollection.CreateInstance("Attributes")
        'коллекция аттрибутов

        Me.Uc_langObjectAttributes.init(oDefaultLang, DataSource)
        Me.Uc_langObjectAttributesValues.init(oDefaultLang, clsSAObjectCollection.CreateInstance("Attributes"))
        Me.cbAttributeType.Items.AddRange([Enum].GetNames(GetType(clsSAObject.emAttributeType)))
    End Sub

    ''' <summary>
    ''' выбранные значения
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property SelectedObjects As clsSAObjectCollection
        Get
            Return oSelectedObjects
        End Get
    End Property
    ''' <summary>
    ''' Изменение списка выбранных значений
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Event ObjectListChanged(sender As Object, e As EventArgs)

    Public Function GetXML() As String
        If oSelectedObjects Is Nothing Then Return "no selected"
        Return oSelectedObjects.GetXML
    End Function

    ''' <summary>
    ''' добавит значения в выбранные (список выбранных содержится только внутри класса)
    ''' </summary>
    ''' <param name="collection"></param>
    ''' <remarks></remarks>
    Public Sub AddPreSelected(collection As IEnumerable(Of LangObject))
        If collection Is Nothing Then Return
        If collection.Count = 0 Then Return

        'добавлено 29.07.2015 = очистка
        oSelectedObjects.Clear()
        Me.Uc_langObjectAttributes.ClearSelected()
        Me.Uc_langObjectAttributesValues.ClearSelected()

        'добавление атрибута в выбранные
        'дублировать значение для выходного массива
        For Each t As clsSAObject In collection
            If t.Value Is Nothing Then Continue For

            ''добавлено 29.07.2015 = пропуск начинающихся с цифр
            'If Not String.IsNullOrEmpty(t.CustomValue) AndAlso Char.IsDigit(t.CustomValue.First()) Then Continue For

            oCurrentSelectedAttribute = t
            oSelectedObjects.Add(oCurrentSelectedAttribute)

            Me.Uc_langObjectAttributes.AddPreSelected({t})

            'добавить значения
            Me.Uc_langObjectAttributesValues.AddPreSelected({oCurrentSelectedAttribute.Value})

        Next

        RenewEU()
        RaiseEvent ObjectListChanged(Me, EventArgs.Empty)
    End Sub

#End Region
    Private oCurrentSelectedAttribute As clsSAObject
    ''' <summary>
    ''' при выборе доступного атрибута
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Uc_langObjectAttributes_SourceItemChanged(sender As Object, e As uc_langObject.ItemEventArgs) Handles Uc_langObjectAttributes.SourceItemChanged
        'смена выбора атрибута и
        ''загрузка значений для выбранного в списке атрибута
        Dim _target As clsSAObject
        If TypeOf e.Item Is clsSAObject Then
            _target = oData.FirstOrDefault(Function(x) x.Equals(e.Item))
        Else
            _target = clsSAObject.CreateInstance(e.Item)
        End If

        If _target Is Nothing Then
            'ошибка выбора атрибута
            MsgBox(String.Format("Атрибута {0} нет во входящем списке", e.Item.ToString))
            Return
        Else
            'значения из источника
            Me.Uc_langObjectAttributesValues.init(oDefaultLang, _target.ValuesCollection)

            ''уже выбранные значения
            Dim _val As clsSAObject = oSelectedObjects.GetItem(e.Item)

            If Not _val Is Nothing Then
                oCurrentSelectedAttribute = _val

                If Not _val.Value Is Nothing Then
                    'добавить значения из получателя (ранее выбранные)
                    Me.Uc_langObjectAttributesValues.AddPreSelected({_val.Value})
                End If

            End If
        End If
        RenewEU()
        Me.flp_center.Enabled = False
        Me.Uc_langObjectAttributesValues.Enabled = False
    End Sub

    ''' <summary>
    ''' при выборе добавленного атрибута
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Uc_langObjectAttributes_SelectedItemChanged(sender As Object, e As uc_langObject.ItemEventArgs) Handles Uc_langObjectAttributes.SelectedItemChanged
        'смена выбора атрибута и
        ''загрузка значений для выбранного в списке атрибута
        Dim _target As clsSAObject
        If TypeOf e.Item Is clsSAObject Then
            _target = oSelectedObjects.FirstOrDefault(Function(x) x.Equals(e.Item))
        Else
            _target = clsSAObject.CreateInstance(e.Item)
        End If

        If _target Is Nothing Then
            'ошибка выбора атрибута
            MsgBox(String.Format("Атрибута {0} нет в списке", e.Item.ToString))
            Return
        Else
            'установить текущий атрибут
            oCurrentSelectedAttribute = _target
            'значения из источника
            Dim _source As clsSAObject = oData.FirstOrDefault(Function(x) x.Equals(e.Item))
            If Not _source Is Nothing Then
                Me.Uc_langObjectAttributesValues.init(oDefaultLang, _source.ValuesCollection)
            Else
                Me.Uc_langObjectAttributesValues.init(oDefaultLang, clsLangObjectCollection.CreateInstance("Attributes"))
            End If

            ''уже выбранные значения
            If Not oCurrentSelectedAttribute.Value Is Nothing Then
                'добавить значения из получателя (ранее выбранные)
                Me.Uc_langObjectAttributesValues.AddPreSelected({oCurrentSelectedAttribute.Value})
            End If

            If oSelectedObjects.GetItem(oCurrentSelectedAttribute) Is Nothing Then
                MsgBox(String.Format("в коллекции выбранных обьектов {0} нет запрашиваемого атрибута {1}", oSelectedObjects.Count, oCurrentSelectedAttribute.InvariantValue))
            End If

            'Dim _val As clsSAObject = _target '' oSelectedObjects.GetItem(e.Item)
            'oCurrentSelectedAttribute = _val
            'If Not _val Is Nothing Then
            '    If Not _val.Value Is Nothing Then
            '        'добавить значения из получателя (ранее выбранные)
            '        Me.Uc_langObjectAttributesValues.AddPreSelected({_val.Value})
            '    End If
            'End If
        End If
        RenewEU()
        Me.flp_center.Enabled = True
        Me.Uc_langObjectAttributesValues.Enabled = True
    End Sub

    Private Sub Uc_langObjectAttributes_ObjectListChanged(sender As Object, e As uc_langObject.ItemEventArgs) Handles Uc_langObjectAttributes.ObjectListChanged
        If Uc_langObjectAttributes.SelectedObjects.Count = 0 Then Return
        ' MsgBox("попытка добавить атрибут в выбраные " & e.Item.ToString)
        If e.Added Then
            'добавление атрибута в выбранные
            'дублировать значение для выходного массива
            oCurrentSelectedAttribute = clsSAObject.CreateInstance(e.Item, "Attributes")
            With oCurrentSelectedAttribute
                .ValueType = clsSAObject.emAttributeType.Option
                .CustomValue = ""
                .DisplayOrder = 0
                .ShowOnProductPage = True
            End With

            oSelectedObjects.Add(oCurrentSelectedAttribute)
            Uc_langObjectAttributes_SelectedItemChanged(Me, New uc_langObject.ItemEventArgs With {.Item = e.Item})

        End If

        If e.Deleted Then
            oSelectedObjects.Remove(e.Item)
        End If

        RenewEU()

        RaiseEvent ObjectListChanged(Me, EventArgs.Empty)
    End Sub

    

    Private Sub RenewEU()
        Me.cbAttributeType.SelectedItem = [Enum].GetName(GetType(clsSAObject.emAttributeType), oCurrentSelectedAttribute.ValueType)
        Me.tbAttributeCustomValue.Text = oCurrentSelectedAttribute.CustomValue
        Me.NumericUpDown1.Value = oCurrentSelectedAttribute.DisplayOrder
        Me.cbx_ShowOnPage.Checked = oCurrentSelectedAttribute.ShowOnProductPage
        Me.Uc_langObjectAttributes.RefreshCaptions()
        Me.Uc_langObjectAttributesValues.RefreshCaptions()
    End Sub

    Private Sub Uc_langObjectAttributesValues_ObjectListChanged(sender As Object, e As uc_langObject.ItemEventArgs) Handles Uc_langObjectAttributesValues.ObjectListChanged
        'добавление значения в выбраные
        If Uc_langObjectAttributesValues.SelectedObjects.Count = 0 Then Return
        If e.Added Then
            Dim _in As LangObject = Uc_langObjectAttributesValues.SelectedObjects.First
            'дублировать значение для выходного массива
            Dim _val As clsSAObjectValue = clsSAObjectValue.CreateInstance(oCurrentSelectedAttribute, _in)
            ' MsgBox("значение добавлено")
            If Not oCurrentSelectedAttribute.ValuesCollection.Contains(_val) Then
                oSelectedObjects.AddValue(_val)
            End If
            '  MsgBox("значение добавлено 2")
            oCurrentSelectedAttribute.Value = _val

        End If
        If e.Deleted Then
            oSelectedObjects.Remove(e.Item)
        End If
        RaiseEvent ObjectListChanged(Me, EventArgs.Empty)
    End Sub

    Private Sub cbAttributeType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbAttributeType.SelectedIndexChanged
        If oCurrentSelectedAttribute Is Nothing Then Return
        Dim _v = cbAttributeType.SelectedItem.ToString

        oSelectedObjects.GetItem(oCurrentSelectedAttribute).ValueType = [Enum].Parse(GetType(clsSAObject.emAttributeType), _v)

        RaiseEvent ObjectListChanged(Me, EventArgs.Empty)
    End Sub

    Private Sub tbAttributeCustomValue_TextChanged(sender As Object, e As EventArgs) Handles tbAttributeCustomValue.TextChanged
        If oCurrentSelectedAttribute Is Nothing Then Return

        oCurrentSelectedAttribute.CustomValue = tbAttributeCustomValue.Text
        RaiseEvent ObjectListChanged(Me, EventArgs.Empty)
    End Sub

    Private Sub cbAttributeOrder_CheckedChanged(sender As Object, e As EventArgs) Handles cbx_ShowOnPage.CheckedChanged
        If oCurrentSelectedAttribute Is Nothing Then Return

        oCurrentSelectedAttribute.ShowOnProductPage = cbx_ShowOnPage.Checked
        RaiseEvent ObjectListChanged(Me, EventArgs.Empty)
    End Sub

    Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown1.ValueChanged
        If oCurrentSelectedAttribute Is Nothing Then Return

        oCurrentSelectedAttribute.DisplayOrder = NumericUpDown1.Value
        RaiseEvent ObjectListChanged(Me, EventArgs.Empty)
    End Sub

   
    Private Sub Uc_langObjectAttributes_Load(sender As Object, e As EventArgs)

    End Sub
End Class
