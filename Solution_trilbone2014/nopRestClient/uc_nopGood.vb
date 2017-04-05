Imports nopTypes.Nop.Plugin.Misc.panoRazziRestService

Public Class uc_nopGood

    Dim WithEvents oDataObj As clsDocumentObject
    Dim oExternalObj As clsExternalData

    Public Event ObjectListChanged(sender As Object, e As ObjectListChangedEventArgs)
    Public Event RequestWarehouse(sender As Object, e As RequestWarehouseEventArgs)

    Public Class ObjectListChangedEventArgs
        Inherits EventArgs

    End Class
    ''' <summary>
    ''' происходит при нажатии кнопки готово
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Event ObjectReady(sender As Object, e As ObjectReadyEventArgs)

    Public Class RequestWarehouseEventArgs
        Inherits EventArgs
        Public Property ShotNumber As String
    End Class


    Public Class ObjectReadyEventArgs
        Inherits EventArgs
        Public Property XML As String
    End Class

    Public Function GetXML() As String
        Return oDataObj.GetXML
    End Function

   

    ''' <summary>
    ''' обязательное для работы условие
    ''' </summary>
    ''' <param name="obj"></param>
    ''' <remarks></remarks>
    Public Sub init(obj As clsExternalData, culture As Globalization.CultureInfo)

        oExternalObj = obj
        oDataObj = obj.Document
        Dim ShowedLang = LangObject.GetLangByCulture(culture)

        Me.ClsDocumentSimpleBindingSource.DataSource = oDataObj.SimpleObjects

        'вкладка ru
        Dim _do = oDataObj.GetDescriptionObject(lng.ruRU)
        _do.SetAsInvariant = True
        Me.Uc_nopDescriptionFirst.init(_do)
        Me.tpDescrFirst.Text = "Русский" '_do.langName

        'вкладка en
        _do = oDataObj.GetDescriptionObject(lng.enUS)
        Me.Uc_nopDescriptionSecond.init(_do)
        Me.tpDescrSecond.Text = "Английский" ' _do.langName
        '.....

        'категории
        Me.Uc_langObjectCategory.init(ShowedLang, oDataObj.ProductCategories)

        'локалити
        Me.Uc_langObjectLocatlity.init(ShowedLang, oDataObj.Localities)
        'добавляем локалити
        Me.Uc_langObjectLocatlity.AddPreSelected(oDataObj.SelectedLocalities)

        'атрибуты(особенности, характеристики)
        Me.Uc_attributes1.init(ShowedLang, oDataObj.SpecificAttributes)
        ''добавляем атрибуты
        Me.Uc_attributes1.AddPreSelected(oDataObj.SelectedSpecificAttributes)

        'ACL
        Me.Uc_ACL1.init(ShowedLang, oDataObj.DocumentService.CustomerRoles, oDataObj.DocumentService.Stores)

        'Tier prices
        Me.Uc_tierPrice1.init(ShowedLang, oDataObj.DocumentService.SiteBaseCurrency, oDataObj.Customers, oDataObj.Stores)
        Me.Uc_tierPrice1.RateDelagate = oDataObj.RateDelagate

    End Sub


    Private Sub Uc_langObjectCategory_ObjectListChanged(sender As Object, e As EventArgs) Handles Uc_langObjectCategory.ObjectListChanged
        'изменились данные. ловит PropertyChanged
        oDataObj.SelectedProductCategories = clsCategoriesObjectCollection.CreateInstance(Uc_langObjectCategory.SelectedObjects)
    End Sub

    Private Sub Uc_langObjectLocatlity_ContextMenuStripChanged(sender As Object, e As EventArgs) Handles Uc_langObjectLocatlity.ObjectListChanged
        'изменились данные. ловит PropertyChanged
        oDataObj.SelectedLocalities = clsManufacturersObjectCollection.CreateInstance(Uc_langObjectLocatlity.SelectedObjects)
    End Sub

    Private Sub Uc_nopDescriptionEn_ObjectListChanged(sender As Object, e As EventArgs) Handles Uc_nopDescriptionFirst.ObjectListChanged, Uc_nopDescriptionSecond.ObjectListChanged
        'изменились данные на языковых вкладках 
        RaiseEvent ObjectListChanged(Me, New ObjectListChangedEventArgs)
    End Sub

    Private Sub Uc_attributes1_ObjectListChanged(sender As Object, e As EventArgs) Handles Uc_attributes1.ObjectListChanged
        'изменились данные. ловит PropertyChanged
        oDataObj.SelectedSpecificAttributes = Uc_attributes1.SelectedObjects
    End Sub

    Private Sub Uc_ACL1_ObjectListChanged(sender As Object, e As EventArgs) Handles Uc_ACL1.ObjectListChanged
        'изменились данные. ловит PropertyChanged
        oDataObj.CreatedProductACL = Uc_ACL1.SelectedObjects
    End Sub

    Private Sub Uc_tierPrice1_ObjectListChanged(sender As Object, e As EventArgs) Handles Uc_tierPrice1.ObjectListChanged
        'изменились данные. ловит PropertyChanged
        oDataObj.CreatedTierPrices = Uc_tierPrice1.SelectedObjects
    End Sub

    ''' <summary>
    ''' для этого обьекта
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub oDataObj_PropertyChanged(sender As Object, e As ComponentModel.PropertyChangedEventArgs) Handles oDataObj.PropertyChanged
        'изменились данные
        RaiseEvent ObjectListChanged(Me, New ObjectListChangedEventArgs)
    End Sub

  
    Private Sub btSendData_Click(sender As Object, e As EventArgs) Handles btSendData.Click
        If Me.oDataObj.SimpleObjects.WarehouseID = 0 Then
            Select Case MsgBox("Указание склада для образца не задано. Уверен в правильности?", vbYesNo)
                Case MsgBoxResult.No
                    Return
            End Select
        End If

        'передача xml
        Dim _xml = Me.GetXML
        'MsgBox(_xml)
        'My.Computer.Clipboard.SetText(_xml)
        If _xml.Contains("error") Then
            'ошибки в листинге
            'serverMessage = "Ошибка проверки листинга. Исправте ошибки и выставите заново."
            'Return HttpStatusCode.Forbidden
            MsgBox("Исправте ошибки в листинге!", vbCritical)
            Return
        End If
        RaiseEvent ObjectReady(Me, New ObjectReadyEventArgs With {.XML = _xml})
    End Sub

    Private Sub tbctl_LangPages_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tbctl_LangPages.SelectedIndexChanged
        'смена вкладки
        'перезагрузить доступные значения тегов и?? слов
        Select Case tbctl_LangPages.SelectedIndex
            Case 0
                'добавить в первую из второй
                Uc_nopDescriptionFirst.AddSelectedTag(Uc_nopDescriptionSecond.DataObj.SelectedProductTag)
               
            Case 1
                Uc_nopDescriptionSecond.AddSelectedTag(Uc_nopDescriptionFirst.DataObj.SelectedProductTag)
               
        End Select

        Uc_nopDescriptionFirst.RefreshInnerUC()
        Uc_nopDescriptionSecond.RefreshInnerUC()
    End Sub


   
  
    Private Sub Uc_langObjectLocatlity_ContextMenuStripChanged(sender As Object, e As uc_langObject.ItemEventArgs) Handles Uc_langObjectLocatlity.ObjectListChanged

    End Sub
   

    Private Sub btAskStore_Click(sender As Object, e As EventArgs) Handles btAskStore.Click
        RaiseEvent RequestWarehouse(Me, New RequestWarehouseEventArgs With {.ShotNumber = oExternalObj.ShotCode})
    End Sub

    Private Sub Uc_langObjectCategory_ObjectListChanged(sender As Object, e As uc_langObject.ItemEventArgs) Handles Uc_langObjectCategory.ObjectListChanged

    End Sub

    Private Sub Uc_nopDescriptionFirst_Load(sender As Object, e As EventArgs)

    End Sub

    Private Sub tbWarehouseName_TextChanged(sender As Object, e As EventArgs) Handles tbWarehouseName.TextChanged
        If tbWarehouseName.Text = "0" Then
            tbWarehouseName.BackColor = Windows.Forms.TextBox.DefaultBackColor
        Else
            tbWarehouseName.BackColor = Drawing.Color.Green
        End If
    End Sub
End Class
