Imports Service
Imports Service.clsApplicationTypes

Public Class clsSiteService
    Public Sub New()
        '. сервис формы fmMoySklad
        'привязываем делегат к функции
        'передаем делегат (регестрируем) и список в сервисном классе
        clsApplicationTypes.DelegateStoreApplicationForm _
            (emFormsList.fmSite) = _
            New ApplicationFormDelegateFunction(AddressOf GetSiteServiceFormAsForm)
    End Sub

    Private Function GetSiteServiceFormAsForm(param As Object) As Form
        Dim _new = New fmSite
        _new.fmMainLink = param
        Return _new
    End Function



End Class
