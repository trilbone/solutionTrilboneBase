Imports System.Linq
Imports System.Drawing
Imports System.Windows.Forms

Public Class UC_siteCheck
    Private oSpash As Form = clsApplicationTypes.SplashScreen
    ''' <summary>
    ''' список товаров на сайте
    ''' </summary>
    ''' <remarks></remarks>
    Private oCurrentProductList As List(Of iNopDataProvider.clsNopProduct)
    Dim oSite As iNopDataProvider

    Public Property SampleNumber As String
        Get
            Return Me.tbSampleNumber.Text
        End Get
        Set(value As String)
            Me.tbSampleNumber.Text = value
            Me.lbResult.Text = "запрос"
            Me.lbResult.BackColor = Label.DefaultBackColor
        End Set
    End Property

    Sub New()

        ' Этот вызов является обязательным для конструктора.
        InitializeComponent()

        ' Добавьте все инициализирующие действия после вызова InitializeComponent().

    End Sub

    ''' <summary>
    ''' запустить
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub init()
        Me.lbResult.Text = "Запрос"
        'получить интерфейс
        oSite = clsApplicationTypes.NopInterface
        If oSite Is Nothing OrElse oSite.IsConnect = False Then
            MsgBox("Данные с сайта не удалось получить!", vbCritical)
            Return
        End If
    End Sub



    Private Sub btQuery_Click(sender As Object, e As EventArgs) Handles btQuery.Click
        Me.lbResult.Text = "Запрос"
        oSpash.Show()
        Application.DoEvents()
        If oSite Is Nothing Then init()
        Dim oCurrentProductList = oSite.GetProduct()

        Dim _origin = clsApplicationTypes.clsSampleNumber.CreateFromString(Me.tbSampleNumber.Text)
        If _origin Is Nothing Then GoTo no
        If _origin.CodeIsCorrect = False Then GoTo no

        Dim _result = oCurrentProductList.Where(Function(x) x.Sku.Trim.Equals(_origin.ShotCode)).FirstOrDefault

        oSpash.Hide()

        If _result Is Nothing Then
            GoTo no
        Else
            clsApplicationTypes.BeepYES()
            Me.lbResult.BackColor = Color.Green
            Me.lbResult.Text = "Выставлен на сайте"

            tbSampleNumber.Focus()
            tbSampleNumber.SelectAll()
            Return
        End If
        GoTo no

no:
        clsApplicationTypes.BeepNOT()
        Me.lbResult.BackColor = Color.Red
        Me.lbResult.Text = "НЕ выставлен на сайте"

        tbSampleNumber.Focus()
        tbSampleNumber.SelectAll()
        Return

    End Sub

    Private Sub tbSampleNumber_KeyPress(sender As Object, e As Windows.Forms.KeyPressEventArgs) Handles tbSampleNumber.KeyPress
        Me.lbResult.BackColor = Windows.Forms.Label.DefaultBackColor
        Me.lbResult.Text = "Запрос"

        If Asc(e.KeyChar) = 13 Then
            btQuery_Click(sender, e)
        End If
    End Sub


End Class
