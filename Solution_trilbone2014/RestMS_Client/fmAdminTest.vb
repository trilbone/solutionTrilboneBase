Public Class fmAdminTest

    Private ocurrentType As clsMoyScladManager.emMoySkladObjectTypes
    Private ocurrentFilterType As clsMoyScladManager.emMoySkladFilterTypes
    Private oManager As clsMoyScladManager
    Private Const cntempty As String = "aaa-empty"

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        If ocurrentType = clsMoyScladManager.emMoySkladObjectTypes.Empty Then Return
        Me.RichTextBox1.Text = ""
        Me.RichTextBox3.Text = ""
        Dim _out As IEnumerable(Of Object) = Nothing
        Dim _message As String = ""
        Dim _rawdata As String = ""
        Dim _reqbody As String = ""
        Dim _status = oManager.RequestAnyCollection(ocurrentType, _out, Me.TextBox1.Text, ocurrentFilterType, _message, _rawdata, _reqbody)
        If _status = Net.HttpStatusCode.OK Then
            Me.RichTextBox1.Text = "Count " & _out.Count & Chr(13)
            Me.RichTextBox2.Text = _rawdata
            Me.RichTextBox3.Text = _reqbody
            If _out.Count > 200 Then
                Me.RichTextBox1.Text += "Запрос вернул более 200 обьектов - не выводим!"
                Return
            End If

            For Each t In _out

                If Not t.GetType Is GetType(RestMS_Client.MoySkladAPI.priceType) Then
                    Me.RichTextBox1.Text += "objectAPI: " & t.GetType.ToString & " ==>  Code: " & t.code & "  --  Name: " & t.name & "  -- uuid: " & t.uuid.ToString & Chr(13)
                Else
                    Me.RichTextBox1.Text += "objectAPI: " & t.GetType.ToString & "  --  Name: " & t.name & "  -- uuid: " & t.uuid.ToString & Chr(13)
                End If


                If (t.GetType Is GetType(RestMS_Client.MoySkladAPI.good)) Or (t.GetType Is GetType(RestMS_Client.MoySkladAPI.company)) AndAlso (Not t.attribute Is Nothing) Then
                    For Each a In t.attribute
                        Me.RichTextBox1.Text += Chr(13)
                        Me.RichTextBox1.Text += "attribute: " & a.ToString & ";   MetaUUID: " & a.uuid
                    Next
                End If

            Next
        Else
            Me.RichTextBox1.Text = _message
            Me.RichTextBox2.Text = _rawdata
            Me.RichTextBox3.Text = _reqbody
        End If

    End Sub

    Public Sub New()

        ' Этот вызов является обязательным для конструктора.
        InitializeComponent()

        ' Добавьте все инициализирующие действия после вызова InitializeComponent().
        init()
    End Sub
    Private Sub init()
        Dim _fm As New SplashScreen1
        _fm.Show()
        Application.DoEvents()
        Me.oManager = clsRestMS_service.CreateManager("admin@trilbone", "illaenus2012")
        If Me.oManager Is Nothing Then
            Me.Close()
            MsgBox("Склад не подключен.", vbInformation)
            Return
        End If

        Me.cbObjects.Items.AddRange([Enum].GetNames(GetType(clsMoyScladManager.emMoySkladObjectTypes)))
        Me.cbObjects.Items.Add(cntempty)
        Me.cbObjects.Sorted = True
        Me.cbFilters.Items.Add(cntempty)
        Me.cbFilters.Items.AddRange([Enum].GetNames(GetType(clsMoyScladManager.emMoySkladFilterTypes)))
        Me.cbFilters.Sorted = True
        _fm.Hide()

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbObjects.SelectedIndexChanged
        If cbObjects.SelectedItem Is Nothing Then Return
        Me.RichTextBox1.Text = ""
        Me.RichTextBox2.Text = ""
        Dim _obj As String = cbObjects.SelectedItem
        If _obj = cntempty Then
            _obj = Me.tbManualObject.Text
            If String.IsNullOrEmpty(_obj) Then
                Me.ocurrentType = Nothing
                Return
            End If
            'пока так, посколбку обьект надо добавить в перечисление
            Me.ocurrentType = clsMoyScladManager.emMoySkladObjectTypes.Empty
            Return
        End If

        Me.ocurrentType = [Enum].Parse(GetType(clsMoyScladManager.emMoySkladObjectTypes), cbObjects.SelectedItem)
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbFilters.SelectedIndexChanged
        Me.RichTextBox1.Text = ""
        Me.RichTextBox2.Text = ""
        Dim _filter As String = cbFilters.SelectedItem
        If _filter = cntempty Then
            'взять фильтр из текстбокса
            _filter = Me.tbManualFilter.Text
            If String.IsNullOrEmpty(_filter) Then
                Me.ocurrentFilterType = Nothing
                Return
            End If
            'пока так, посколбку фильтр надо добавить в перечисление
            Me.ocurrentFilterType = Nothing
            Return
        End If

        Me.ocurrentFilterType = [Enum].Parse(GetType(clsMoyScladManager.emMoySkladFilterTypes), _filter)
    End Sub



    Private Sub TextBox1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles TextBox1.MouseDoubleClick
        TextBox1.Text = ""
    End Sub

    Private Sub btDirectRequest_Click(sender As Object, e As EventArgs) Handles btDirectRequest.Click

    End Sub
End Class
