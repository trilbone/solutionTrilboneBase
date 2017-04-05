Public Class ucExpence
    Private oMsi As iMoySkladDataProvider
    Private oPayer As iMoySkladDataProvider.clsEntity

    Public Sub init(msi As iMoySkladDataProvider, Payer As iMoySkladDataProvider.clsEntity)
        oMsi = msi
        oPayer = Payer
        Me.lbPayer.Text = oPayer.Value
        'заполнение списков
        'организация
        With Me.cbOrganization
            .DataSource = oMsi.GetCompanyList
            .DisplayMember = "Value"
            .ValueMember = "UUID"
        End With

        'контрагент-получатель
        With Me.cbReceiver
            .DataSource = oMsi.GetClients
            .DisplayMember = "FullName"
            .ValueMember = "UUID"
        End With

        'счета оплаты
        With Me.lbxAccount
            .DataSource = oMsi.GetUserEntityListByName("Счета")
            .DisplayMember = "Value"
            .ValueMember = "UUID"
        End With

        'статья расхода
        With Me.lbxPurpose
            '.DataSource = oMsi.GetUserEntityListByName("Счета")
            '.DisplayMember = "Value"
            '.ValueMember = "UUID"
        End With

        'статусы
        With Me.cbStatus
            '.DataSource = oMsi.GetUserEntityListByName("Счета")
            '.DisplayMember = "Value"
            '.ValueMember = "UUID"
        End With
    End Sub

    Private Sub tbCreatePayment_Click(sender As Object, e As EventArgs) Handles tbCreatePayment.Click
        ' oMsi.CreateIncomingPayment()

    End Sub
End Class
