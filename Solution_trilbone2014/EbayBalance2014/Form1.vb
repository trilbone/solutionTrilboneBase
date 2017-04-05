Public Class Form1
    Private oFolder As String

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click

        ' Dim _exploreFolder = My.Computer.FileSystem.CurrentDirectory

        Dim _connstr = "Provider=Microsoft.Jet.OLEDB.4.0;" & "Data Source=" & Me.oFolder & ";" & "Extended Properties='text;HDR=Yes;FMT=CSVDelimited'"
        Dim _sql1 = Me.RichTextBox1.Text

        'Dim b = "select ItemID,Gross,Fee,Net,[Shipping and Handling Amount], [Custom Label] from [PayPal.csv] as tab2 inner join [TurboLister.csv] as tab3 on str(tab2.[Item ID])=str(tab3.ItemID)"
        'Dim c = "select * from [TurboLister.csv]"

        Try
            Dim _conn As New OleDb.OleDbConnection(_connstr)
            Dim _adapter As New OleDb.OleDbDataAdapter(_sql1, _conn)
            Dim _datatable As New DataTable
            _datatable.TableName = "EbayResult"

            _adapter.Fill(_datatable)

            Me.BindingSource1.DataSource = _datatable
            Me.BindingSource1.ResetBindings(True)

           
            ''сохранить файл-результат
            Me.Button3.BackColor = Color.Red
        
        Catch ex As Exception

            MsgBox("Ошибка в запросе/файлах данных: " & ex.Message, vbCritical)
        End Try



    End Sub




    Private Sub Form1_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Me.RichTextBox1.Text = "select EbayNumber,  max(Title) as title,max([Custom Label]) as MyCode, max(tab4.Date) as PaidDate, max(Gross) as PaypalGross, sum(Amount) as EbayFee,max(Fee) as PaypalFee, max(Net) as PaypalNetto, max([Shipping and Handling Amount]) as Shipping, (PaypalNetto-EbayFee) as SellBalance,(SellBalance-Shipping) as ItemBalance, round(((PaypalGross-Shipping-ItemBalance)/(PaypalGross-Shipping)*100),0) as PercentFee, (ItemBalance/2) as 5050Value, round(ItemBalance*0.7,2) as ToOwners,round(ItemBalance*0.3,2) as ToTrilbone from [Ebay.csv] as tab1 left join (select Date,ItemID,Gross,Fee,Net,[Shipping and Handling Amount], [Custom Label] from [PayPal.csv] as tab2 right join [TurboLister.csv] as tab3 on str(tab2.[Item ID])=str(tab3.ItemID)) as tab4 on str(tab4.ItemID)=str(tab1.EbayNumber)  Group by EbayNumber"

        oFolder = My.Computer.FileSystem.CurrentDirectory

        With Me.DataGridView1
            .AutoGenerateColumns = True
            .DataSource = Me.BindingSource1
            .AutoSizeRowsMode = _
                      DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader

            .AllowUserToAddRows = True
            .AllowUserToDeleteRows = True
            '.AllowUserToOrderColumns = True
            .AllowUserToResizeColumns = True
            .AllowUserToResizeRows = True

            .BorderStyle = BorderStyle.Fixed3D
            .EditMode = DataGridViewEditMode.EditOnEnter
        End With
        With Me.OpenFileDialog1
            .InitialDirectory = My.Computer.FileSystem.CurrentDirectory
            .Multiselect = False
        End With

    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Dim _datatable As New DataTable

        With Me.OpenFileDialog1
            .Filter = "xsd файлы схемы|*.xsd"
            .Title = "Сначала выбрать схему"
        End With


        Select Case Me.OpenFileDialog1.ShowDialog
            Case Windows.Forms.DialogResult.OK
                Try
                    _datatable.ReadXmlSchema(Me.OpenFileDialog1.FileName)
                Catch ex As Exception
                    MsgBox("Ошибка загрузки файла схемы: " & ex.Message, vbCritical)
                    Exit Sub
                End Try
        End Select

        With Me.OpenFileDialog1
            .Filter = "xml файлы данных|*.xml"
            .Title = "Теперь необходимо выбрать файл данных"
        End With

        Select Case Me.OpenFileDialog1.ShowDialog
            Case Windows.Forms.DialogResult.OK
                Try
                    _datatable.ReadXml(Me.OpenFileDialog1.FileName)
                    Me.BindingSource1.DataSource = _datatable
                    Me.BindingSource1.ResetBindings(True)
                Catch ex As Exception
                    MsgBox("Ошибка загрузки файла данных: " & ex.Message, vbCritical)
                End Try
        End Select
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        If Not Me.BindingSource1.DataSource Is Nothing Then
            Dim _datatable = CType(Me.BindingSource1.DataSource, DataTable)
            'сохранить файл-результат
            Dim _fpath = IO.Path.Combine(Me.oFolder, Now.ToShortDateString & "_result.xml")
            Dim _schPath = IO.Path.Combine(Me.oFolder, Now.ToShortDateString & "_schema.xsd")

            If IO.File.Exists(_fpath) Then
                Select Case MsgBox("Файл существует. Заменить?", vbYesNo)
                    Case MsgBoxResult.No
                        Exit Sub
                End Select
            End If
            _datatable.WriteXml(_fpath)
            _datatable.WriteXmlSchema(_schPath)
            Me.Button3.BackColor = Control.DefaultBackColor
            MsgBox("Файл записан", vbInformation)
        End If
    End Sub
End Class
