Imports Service.clsApplicationTypes
Public Class clsExcelService
    Public Sub New()
        'регистрируем предоставляемые сервисы
        '1. сервис формы fmExcelConnect
        'привязываем делегат к функции
        'передаем делегат (регистрируем) и список в сервисном классе
        DelegateStoreApplicationForm(emFormsList.fmExcelConnection) = _
 New ApplicationFormDelegateFunction(AddressOf GetGetfmExcelConnect_asForm)

        DelegateStoreApplicationForm(emFormsList.fmCatalogConnect) = _
 New ApplicationFormDelegateFunction(AddressOf GetfmCatalogConnectt_asForm)


    End Sub
    Public Shared Function GetfmExcelConnect() As fmExcelConnect
        Return New fmExcelConnect
    End Function

    Public Shared Function GetfmCatalogConnect() As fmCatalogConnect
        Return New fmCatalogConnect
    End Function

    Private Shared Function GetGetfmExcelConnect_asForm(ByVal param As Object) As Form
        Return GetfmExcelConnect()
    End Function

    Private Shared Function GetfmCatalogConnectt_asForm(ByVal param As Object) As Form
        Return GetfmCatalogConnect()
    End Function

End Class
