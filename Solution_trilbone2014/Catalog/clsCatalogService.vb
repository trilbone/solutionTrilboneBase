Imports System.Net
Imports Service.clsApplicationTypes
Imports Service.Catalog

Public Class clsCatalogService

    Public Sub New()
        ''привязка сервиса
        Service.clsApplicationTypes.DelegateStoreRemoveSampleOnSite = New Service.clsApplicationTypes.RemoveSampleOnSiteDelegateFunction(AddressOf RemoveProduct)

        Service.clsApplicationTypes.DelegateStoreGetTransform = New Service.clsApplicationTypes.GetTransformDelegateFunction(AddressOf GetTransform)

    End Sub


    ' ''' <summary>
    ' ''' вернет форму для создания маппинга для элементов образца
    ' ''' </summary>
    ' ''' <returns></returns>
    ' ''' <remarks></remarks>
    'Public Function GetMappingFormasForm() As Windows.Forms.Form
    '    Return GetMappingForm()
    'End Function

    'Private Sub MappingReady_EventHandler(sender As Object, e As fmCreateMAP.clsCatalogSampleChangedEventArgs)
    '    RaiseEvent MappingChanged(sender, e)
    'End Sub


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="templateName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetMappingForm(sample As CATALOGSAMPLE, templateName As String) As fmCreateMAP

        Dim _fm = New fmCreateMAP(sample, templateName)

        'добавить привязку события готовности маппинга
        AddHandler _fm.evAcceptChanges, AddressOf sample.MappingReady_EventHandler

        Return _fm
    End Function




    ''' <summary>
    ''' получить форму с каталогом
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetCatalogForm(catalog As Service.Catalog.CATALOG) As Windows.Forms.Form
        Dim _fm = New fmcatalog
        _fm.Text = catalog.name
        _fm.wbMain.DocumentText = catalog.GetHTML
        Return _fm
    End Function

    ''' <summary>
    ''' остановит продукт на сайте
    ''' </summary>
    ''' <param name="shotCode"></param>
    ''' <param name="serverMessage"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function RemoveProduct(shotCode As String, serverName As String, serviceName As String, ByRef serverMessage As String) As HttpStatusCode
        Dim _agent = Service.clsApplicationTypes.AuctionAgent.AGENT.FirstOrDefault(Function(x) x.name = "site" And x.account.ToLower.Equals(serverName.ToLower))
        If _agent Is Nothing Then
            serverMessage = String.Format("Не удалось найти агента {0} сервера, запрос невозможен", serverName)
            Return HttpStatusCode.NotFound
        Else
            Dim _httpStatus = nopRestClient.clsExternalData.RemoveProduct(RequestURI:=_agent.requestURI, apiToken:=_agent.token, serverMessage:=serverMessage, serviceName:=serviceName, SKU:=shotCode)

            If _httpStatus = Net.HttpStatusCode.OK Then
                serverMessage = String.Format("{2} остановлен на сайте, сервер: {0}. Сообщение: {1}", serverName, serverMessage, shotCode)
            Else
                serverMessage = String.Format("Ошибка в запросе: {0} ({1})", serverMessage, _httpStatus)
            End If
            Return _httpStatus
        End If
    End Function

    Public Shared Function GetTransform(ByRef XMLData As String, TemplateType As emTemplateType, Optional TemplateName As String = "")
        Dim oManager As New Service.Catalog.clsTemplateManager
        Return oManager.GetTransform(XMLData, TemplateType, TemplateName)
    End Function


    ''' <summary>
    ''' вернет форму управления XML образцов param={string,string,string} 
    ''' получим: _paramXMLFile=карта XML или путь к файлу с картой /  _paramXMLelements=полное Описание XML / _paramXMLLabel=xml из labelinfo
    ''' </summary>
    ''' <param name="param"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetFmCatalogSample(param As Object) As Windows.Forms.Form
        If param Is Nothing Then Return New fmcatalog
        If IsArray(param) Then
            Select Case CType(param, System.Array).Length
                Case 0
                    'параметров нет
                    Return New fmcatalog
                Case 1
                    If param(0) Is Nothing Then Return New fmcatalog

                    If TypeOf (param(0)) Is Array Then
                        Return New fmcatalog(param(0), "", "", Nothing)
                    End If
                Case Is > 1
                    If param(0) Is Nothing Then Return New fmcatalog

                    If TypeOf (param(0)) Is Array Then
                        Return New fmcatalog(param(0), param(1), param(2), param(3))
                    End If
                Case Else
                    Return New fmcatalog
            End Select
        Else
            If TypeOf (param) Is String Then
                Return New fmcatalog(param, "", "", Nothing)
            End If

        End If

        Return New fmcatalog


    End Function

End Class