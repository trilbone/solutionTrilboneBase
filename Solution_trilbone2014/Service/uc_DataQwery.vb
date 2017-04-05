Public Class uc_DataQwery

    Public Sub New()

        ' Этот вызов является обязательным для конструктора.
        InitializeComponent()

        ' Добавьте все инициализирующие действия после вызова InitializeComponent().

    End Sub

    Public Sub init()
        Me.cbQwlist.DataSource = clsApplicationTypes.dbQweryList
    End Sub

    Private Sub btExec_Click(sender As Object, e As EventArgs) Handles btExec.Click
        'для добавления sql запроса к базе надо добавить его в файл Resoure_sql проекта service  и дать ему имя, которое отобразится в списке
        'место в запросе для подстановки параметра пометить как #n
        'результаты запроса МОГУТ соответствовать названиям и типу свойств класса clsFindSamleTable_Result
        'также допустимо, чтобы в классе присутствовали лишние поля, отсутствующие в запросе!
        'если поле запроса будет отсутствовать в классе - оно просто не отобразится в результатах!
        '
        'соответственно - это универсальный класс, который обеспечивает все запросы, добавленные в файл ресурсов
        '
        'проверка параметра
        If String.IsNullOrEmpty(Me.tbParam.Text) Then
            MsgBox("Введите параметр запроса!", vbCritical)
            Return
        End If

        'запрос к БД
        Try
            Dim _res = clsSampleDataManager.clsDataQweryHelper(Of clsFreeDbQwery_Result).GetResult(Me.tbParam.Text, clsApplicationTypes.SampleDataObject.GetdbReadySampleObjectContext, Me.RichTextBox1.Text)

            'отображение результатов
            Me.DataGridView1.DataSource = _res
            Me.lbRecord.Text = String.Format("записей: {0}", _res.Count)
        Catch ex As Exception
            Me.DataGridView1.DataSource = Nothing
            Me.lbRecord.Text = "ошибка в запросе"
            MsgBox("Ошибка в запросе!", vbCritical)
        End Try

    End Sub

    ''' <summary>
    ''' класс результатов запроса - потом перенести в service??
    ''' </summary>
    ''' <remarks></remarks>
    Public Class clsFreeDbQwery_Result
        'tr.Name as resource,sm.TimeMarker as date,sm.SampleNumber,sm.Title,sm.amount,sm.currency
        Property resource As String
        Property [date] As Date
        Property SampleNumber As Decimal
        Property Title As String
        Property amount As Decimal
        Property currency As String
        'Property test As String
    End Class

    
    Private Sub cbQwlist_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbQwlist.SelectedIndexChanged
        If Me.cbQwlist.SelectedItem Is Nothing Then Return
        'получить sql для выбранного запроса
        Dim _sql = clsApplicationTypes.GetSqlByResourceName(Me.cbQwlist.SelectedItem)

        Me.RichTextBox1.Text = _sql
    End Sub

   
End Class

