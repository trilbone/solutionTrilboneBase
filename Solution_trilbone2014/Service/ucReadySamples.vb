Imports System.Drawing
Imports System.Windows.Forms
Imports System.Linq
Public Class ucReadySamples


    Private oSplashscreen As Form = clsApplicationTypes.SplashScreen
    Dim oIsInit As Boolean
    Dim oFilterDate As Date
    Dim oPhotoColumnIndex As Integer = 0
    Dim oSKUColumnIndex As Integer = 2
    Dim oNameColumnIndex As Integer = 1
    Dim oBasePriceColumnIndex As Integer = 4
    Dim oSampleNumber As String

    Private Sub LoadData(input As List(Of clsReadySamplesItem))
        oIsInit = True
        oSampleNumber = ""
        With Me.OnSale_DataGridView
            .SuspendLayout()
            Me.ClsReadySamplesItemBindingSource.DataSource = input
            .ResumeLayout()
        End With
        oIsInit = False
    End Sub

   

    Private Sub tbRequest_Click(sender As Object, e As EventArgs) Handles tbRequest.Click
        oSplashscreen.Show()
        Application.DoEvents()
        Me.LoadData(clsApplicationTypes.SampleDataObject.GetReadySamplesInfo(oFilterDate))
        oSplashscreen.Hide()
        Me.tbRequest.Text = String.Format("Загружено ({0})", Me.ClsReadySamplesItemBindingSource.DataSource.count)
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Public Sub New()

        ' Этот вызов является обязательным для конструктора.
        InitializeComponent()

        ' Добавьте все инициализирующие действия после вызова InitializeComponent().
        Me.cbxTimeFilter.DisplayMember = "Name"
        Me.cbxTimeFilter.ValueMember = "Key"
        Me.cbxTimeFilter.Items.Add(New With {.Name = "за 3 дня", .key = 0})
        Me.cbxTimeFilter.Items.Add(New With {.Name = "за неделю", .key = 1})
        Me.cbxTimeFilter.Items.Add(New With {.Name = "за месяц", .key = 2})
        Me.cbxTimeFilter.Items.Add(New With {.Name = "за 2 месяца", .key = 3})
        Me.cbxTimeFilter.Items.Add(New With {.Name = "за 3 месяца", .key = 4})
        Me.cbxTimeFilter.Items.Add(New With {.Name = "за 6 месяцев", .key = 5})
        Me.cbxTimeFilter.Items.Add(New With {.Name = "все", .key = 6})
        Me.cbxTimeFilter.SelectedIndex = 6
    End Sub



    Private Sub cbxTimeFilter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxTimeFilter.SelectedIndexChanged
        Select Case cbxTimeFilter.SelectedIndex
            Case 0
                oFilterDate = New Date(Date.Now.Year, Date.Now.Month, Date.Now.Day - 3)
            Case 1
                oFilterDate = New Date(Date.Now.Year, Date.Now.Month, Date.Now.Day - 7)
            Case 2
                oFilterDate = New Date(Date.Now.Year, Date.Now.Month - 1, Date.Now.Day)
            Case 3
                oFilterDate = New Date(Date.Now.Year, Date.Now.Month - 2, Date.Now.Day)
            Case 4
                oFilterDate = New Date(Date.Now.Year, Date.Now.Month - 3, Date.Now.Day)
            Case 5
                oFilterDate = New Date(Date.Now.Year, Date.Now.Month - 6, Date.Now.Day)
            Case 6
                If Date.Now.Month = 2 Then
                    'проверка на високосный год (каждые 4 года)
                    If Date.IsLeapYear(Date.Now.Year) Then
                        oFilterDate = New Date(Date.Now.Year - (4 * 5), Date.Now.Month, Date.Now.Day)
                    End If
                Else
                    oFilterDate = New Date(Date.Now.Year - 20, Date.Now.Month, Date.Now.Day)
                End If
                'Try
                '    oFilterDate = New Date(Date.Now.Year - 20, Date.Now.Month, Date.Now.Day)
                'Catch ex As Exception
                '    'если год високосный, то возникнет это исключение
                '    oFilterDate = Date.Now
                'End Try

        End Select
    End Sub

    Public ReadOnly Property SampleNumber As String
        Get
            Return oSampleNumber
        End Get
    End Property

    Private Sub OnSale_DataGridView_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles OnSale_DataGridView.CellClick
        If e.ColumnIndex = oSKUColumnIndex Then
            oSampleNumber = OnSale_DataGridView.Rows(e.RowIndex).Cells(oSKUColumnIndex).Value
        Else
            oSampleNumber = ""
        End If
    End Sub


    Private Sub OnSale_DataGridView_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles OnSale_DataGridView.CellDoubleClick
        If Not (e.ColumnIndex > -1 AndAlso e.RowIndex > -1) Then Return
        Select Case e.ColumnIndex
            Case oPhotoColumnIndex
                Dim _code = clsApplicationTypes.clsSampleNumber.CreateFromString(Me.OnSale_DataGridView.Rows(e.RowIndex).Cells(oSKUColumnIndex).Value)
                If _code Is Nothing Then Return
                If Me.OnSale_DataGridView.Rows(e.RowIndex).Cells(oPhotoColumnIndex).Value Is Nothing Then Return
                Dim _prm = Service.clsApplicationTypes.SamplePhotoObject.GetImageCollection(_code, clsFilesSources.Arhive, False)
                If _prm Is Nothing Then
                    MsgBox("невозможно показать форму с изображениями", vbCritical)
                End If
                Dim _fmImage As Form
                'show image form
                Dim _param As Object = {_prm, ""}
                'если делегата нет, то сервис недоступен
                If Not Global.Service.clsApplicationTypes.DelegateStoreApplicationForm(Service.clsApplicationTypes.emFormsList.fmImage) Is Nothing Then
                    'сервис зарегестрирован - вызываем
                    _fmImage = Global.Service.clsApplicationTypes.DelegateStoreApplicationForm(Service.clsApplicationTypes.emFormsList.fmImage).Invoke(_param)
                    If Not _fmImage Is Nothing Then
                        'show form
                        _fmImage.Width = 640
                        _fmImage.Height = 480
                        _fmImage.StartPosition = FormStartPosition.CenterScreen
                        'привязка обработчика
                        'Service.clsApplicationTypes.DelegatStorefmImageDeleteDelegate = New Service.clsApplicationTypes.fmImageDeleteDelegat(AddressOf DelImage_eventHandler)
                        'Service.clsApplicationTypes.DelegatStorefmImageCopyDelegate = New Service.clsApplicationTypes.fmImageCopyDelegat(AddressOf CopyImage_eventHandler)
                        _fmImage.ShowDialog()
                    End If
                End If
                '=======
            Case Me.oSKUColumnIndex
                ''инфо по номеру
                'Me.oSplashscreen.Show()
                'Application.DoEvents()
                'Dim _sampleNumber = clsApplicationTypes.clsSampleNumber.CreateFromString(nop_DataGridView.Rows(e.RowIndex).Cells(e.ColumnIndex).Value)
                'If Not _sampleNumber.CodeIsCorrect Then Return
                'Me.tbShotNumber.Text = _sampleNumber.ShotCode
                'Me.UserControlMC1.SampleNumber = _sampleNumber
                'Me.Uc_trilbone_history1.SampleNumber = _sampleNumber.ShotCode
                'Me.UserControlEbaySearch1.SearchName = clsApplicationTypes.RejectSkobki(nop_DataGridView.Rows(e.RowIndex).Cells(oNameColumnIndex).Value)
                'Me.tbCtlMain.SelectedTab = Me.tpStatus
                'Me.btSeeLog_Click(sender, e)
                'Me.oSplashscreen.Hide()
        End Select

    End Sub

    Private Sub OnSale_DataGridView_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles OnSale_DataGridView.CellMouseClick
        Select Case e.Button
            Case Windows.Forms.MouseButtons.Right
             
        End Select

    End Sub
End Class
