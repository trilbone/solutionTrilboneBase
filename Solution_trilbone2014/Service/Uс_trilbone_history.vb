Imports System.Windows.Forms
Imports System.ComponentModel
Imports System.Linq
Imports Service.Agents

Public Class Uc_trilbone_history
    Private WithEvents oSampleNumber As clsApplicationTypes.clsSampleNumber
    Private Class SplashScreen1
        Inherits System.Windows.Forms.Form
        'Является обязательной для конструктора форм Windows Forms
        Private components As System.ComponentModel.IContainer
        Public Sub New()
            InitializeComponent()
        End Sub
        'Примечание: следующая процедура является обязательной для конструктора форм Windows Forms
        'Для ее изменения используйте конструктор форм Windows Form.  
        'Не изменяйте ее в редакторе исходного кода.
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.SuspendLayout()
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(47, 39)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(160, 13)
            Me.Label1.TabIndex = 0
            Me.Label1.Text = "Загрузка данных. Подождите."
            '
            'SplashScreen1
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BackColor = System.Drawing.SystemColors.Highlight
            Me.ClientSize = New System.Drawing.Size(251, 89)
            Me.ControlBox = False
            Me.Controls.Add(Me.Label1)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "SplashScreen1"
            Me.ShowInTaskbar = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.ResumeLayout(False)
            Me.PerformLayout()
        End Sub
        Friend WithEvents Label1 As System.Windows.Forms.Label

    End Class

    Private WithEvents oBackgroundWorkerMC As New BackgroundWorker
    Dim oMCinterface As iMoySkladDataProvider

    Private Sub backgroundWorker1_RunWorkerCompleted( _
  ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs) _
  Handles oBackgroundWorkerMC.RunWorkerCompleted

        ' First, handle the case where an exception was thrown.
        If (e.Error IsNot Nothing) Then
            MessageBox.Show("Ошибка асинхронной операции: " & e.Error.Message)
            '  Me.ToolStripStatusLabel1.Text = ""
        ElseIf e.Cancelled Then
            ' Next, handle the case where the user canceled the 
            ' operation.
            ' Note that due to a race condition in 
            ' the DoWork event handler, the Cancelled
            ' flag may not have been set, even though
            ' CancelAsync was called.
            MsgBox("Операция прервана пользователем", vbInformation)
            ' Me.ToolStripStatusLabel1.Text = ""
        Else
            ' Finally, handle the case where the operation succeeded.
            'отобразим результат операции
            '  Me.ToolStripStatusLabel1.Text = e.Result.ToString()
            'Me.cbxAddIfExists.Checked = False
            '  Me.lbSkladWarning.Text = "Проверь кол-во запросом"
            clsApplicationTypes.BeepYES()
        End If

    End Sub 'backgroundWorker1_RunWorkerCompleted

    ' This event handler is where the actual work is done.
    Private Sub backgroundWorker1_DoWork( _
    ByVal sender As Object, _
    ByVal e As DoWorkEventArgs) _
    Handles oBackgroundWorkerMC.DoWork
        Dim _answermsg As String = ""
        ' Get the BackgroundWorker object that raised this event.
        Dim worker As BackgroundWorker = _
            CType(sender, BackgroundWorker)

        e.Result = e.Argument.Invoke()

    End Sub 'backgroundWorker1_DoWork



    ''' <summary>
    ''' установит текущий образец
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SampleNumber(Optional FindInfo As Boolean = True) As String
        Get
            If oSampleNumber Is Nothing Then Return ""
            Return oSampleNumber.ShotCode
        End Get
        Set(value As String)
            oSampleNumber = clsApplicationTypes.clsSampleNumber.CreateFromString(value)
            tbSampleNumber.Text = oSampleNumber.ShotCode

            If FindInfo Then
                If Not oSampleNumber.CodeIsCorrect Then Return
                Me.LoadSample()
            End If
        End Set
    End Property

    Private Sub btSearchInfo_Click(sender As Object, e As EventArgs) Handles btSearchInfo.Click
        oSampleNumber = clsApplicationTypes.clsSampleNumber.CreateFromString(tbSampleNumber.Text)
        If oSampleNumber Is Nothing OrElse Not oSampleNumber.CodeIsCorrect Then rtb_info.Text += ChrW(13) & "Неверный номер: " & tbSampleNumber.Text : clsApplicationTypes.BeepNOT() : Return
        tbSampleNumber.Text = oSampleNumber.ShotCode
        Me.LoadSample()
    End Sub

    Sub LockCtl()
        Me.rtb_info.Text = ""
        Me.tbSampleNumber.Text = ""
        Me.PictureBox1.Image = Nothing
    End Sub

    ''' <summary>
    ''' устанавливает фокус
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub KeyPressRaise(KeyChar As Char)
        Me.tbSampleNumber.Focus()
        btSearchInfo_KeyPress(Me.tbSampleNumber, New KeyPressEventArgs(KeyChar))
    End Sub

#Region "Управление вводом"
    'Private Sub SampleNumberTextBox_Enter(sender As Object, e As System.EventArgs) Handles tbSampleNumber.Enter
    '    If sender.text.ToString.Length >= 13 Then
    '        LockCtl()
    '    End If
    'End Sub

    Private Sub btSearchInfo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles btSearchInfo.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            'цифра
            'очистить поле и начать ввод
            Me.tbSampleNumber.Text = e.KeyChar.ToString
            Me.tbSampleNumber.Focus()
            Me.tbSampleNumber.SelectionStart = 1
        End If

        If Asc(e.KeyChar) = 13 Then
            btSearchInfo_Click(Me, New System.EventArgs)
        End If
    End Sub

    Private Sub SampleNumberTextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbSampleNumber.KeyPress, Me.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            'цифра
            'очистить поле и начать ввод
            If Me.tbSampleNumber.Text.Length = 13 Then
                Me.tbSampleNumber.Text = ""
            End If
        End If

        If Asc(e.KeyChar) = 13 Then
            Me.btSearchInfo_Click(sender, e)
        End If

    End Sub

    Private Sub SampleNumberTextBox_KeyUp(sender As Object, e As KeyEventArgs) Handles tbSampleNumber.KeyUp
        If e.Control Then
            If e.KeyValue = 86 Then
                'ctl+V
                If My.Computer.Clipboard.ContainsText Then
                    Dim _txt = My.Computer.Clipboard.GetText
                    If _txt.Length < 14 Then
                        Dim _sn = clsApplicationTypes.clsSampleNumber.CreateFromString(_txt)
                        If Not _sn Is Nothing AndAlso _sn.CodeIsCorrect Then
                            Me.tbSampleNumber.Text = _sn.EAN13
                            '------------------
                            Dim _data As String = _sn.EAN13
                            Try
                                My.Computer.Clipboard.Clear()
                                My.Computer.Clipboard.SetText(_data)
                            Catch ex As Exception
                                MsgBox("Ошибка при помещении данных в буфер обмена.", vbCritical)
                            End Try
                            '-----------------
                            Me.btSearchInfo_Click(Me, EventArgs.Empty)
                        End If
                    End If

                End If
            End If
            If e.KeyValue = 67 Then
                'ctl+c
                If Not oSampleNumber Is Nothing Then
                    '------------------
                    Dim _data As String = oSampleNumber.EAN13
                    Try
                        My.Computer.Clipboard.Clear()
                        My.Computer.Clipboard.SetText(_data)
                    Catch ex As Exception
                        MsgBox("Ошибка при помещении данных в буфер обмена.", vbCritical)
                    End Try
                    '-----------------
                    Me.tbSampleNumber.Text = oSampleNumber.EAN13
                End If

            End If
        End If
    End Sub

    'Private Sub SampleNumberLabel_Click(sender As System.Object, e As System.EventArgs) Handles SampleNumberLabel.MouseClick
    '    Me.tbSampleNumber.Text = ""
    '    CType(clsApplicationTypes.GetDigiKeyBoardForm, Object).connect(Me.tbSampleNumber)
    'End Sub
    Private Sub fmSampleData_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            'цифра
            'очистить поле и начать ввод
            Me.tbSampleNumber.Text = e.KeyChar.ToString
            ' Me.SampleNumberTextBox.Focus()
        End If
    End Sub
#End Region
    ''' <summary>
    ''' запрос инфо
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Sub LoadSample()
        PictureBox1.Image = Nothing
        Me.tbctl_main.SelectedTab = tpInfo
        oSampleNumber.GetHistoryString()
        oSampleNumber.AskName()
    End Sub

    Private Sub oSampleNumber_HistoryAfterChange(sender As Object, e As clsApplicationTypes.clsSampleNumber.HistoryChangeEventArgs) Handles oSampleNumber.HistoryAfterChange
        Me.rtb_info.Text = e.HistoryString
    End Sub

    Private Sub oSampleNumber_HistoryBeforeChange(sender As Object, e As clsApplicationTypes.clsSampleNumber.HistoryChangeEventArgs) Handles oSampleNumber.HistoryBeforeChange
        Me.rtb_info.Text = e.HistoryString
    End Sub

    Private Sub oSampleNumber_HistoryImageReady(sender As Object, e As clsApplicationTypes.clsSampleNumber.HistoryChangeEventArgs) Handles oSampleNumber.HistoryImageReady
        If e.ContainsImage Then
            PictureBox1.Image = e.Image
        Else
            PictureBox1.Image = Nothing
        End If
    End Sub
  
    Private Sub btUnpublishFromSite_Click(sender As Object, e As EventArgs) Handles btUnpublishFromSite.Click
        If clsApplicationTypes.DelegateStoreRemoveSampleOnSite Is Nothing Then
            MsgBox("Отсутствует делегат. Запрос с сайта не возможен.", vbCritical)
            Return
        End If
        Dim _serviceName = "StopProduct"
        Dim serverMessage As String = ""
        Dim _res = clsApplicationTypes.DelegateStoreRemoveSampleOnSite.Invoke(oSampleNumber.ShotCode, "trilbone", _serviceName, serverMessage)
        If _res = Net.HttpStatusCode.OK Then
            MsgBox(serverMessage, vbInformation)
            'добавить в бд Trilbone
            If clsApplicationTypes.SampleDataObject.RegisterDeleteSampleOnSiteTrilbone(oSampleNumber) Then
                MsgBox("Действие записано в БД Trilbone", vbInformation)
            Else
                MsgBox("Не удалось зарегестрировать действие в БД Trilbone", vbInformation)
            End If
        Else
            MsgBox(serverMessage, vbCritical)
        End If
    End Sub

    Private Sub tbDeleteFromSite_Click(sender As Object, e As EventArgs) Handles tbDeleteFromSite.Click
        If clsApplicationTypes.DelegateStoreRemoveSampleOnSite Is Nothing Then
            MsgBox("Отсутствует делегат. Запрос с сайта не возможен.", vbCritical)
            Return
        End If
        Dim _serviceName = "DeleteProduct"
        Dim serverMessage As String = ""
        Dim _res = clsApplicationTypes.DelegateStoreRemoveSampleOnSite.Invoke(oSampleNumber.ShotCode, "trilbone", _serviceName, serverMessage)
        If _res = Net.HttpStatusCode.OK Then
            MsgBox(serverMessage, vbInformation)
            'добавить в бд Trilbone
            If clsApplicationTypes.SampleDataObject.RegisterDeleteSampleOnSiteTrilbone(oSampleNumber) Then
                MsgBox("Действие записано в БД Trilbone", vbInformation)
            Else
                MsgBox("Не удалось зарегестрировать действие в БД Trilbone", vbInformation)
            End If
        Else
            MsgBox(serverMessage, vbCritical)
        End If
    End Sub

    Sub clear()
        Me.oSampleNumber = Nothing
        Me.rtb_info.Text = ""
        Me.tbSampleNumber.Text = ""
        Me.PictureBox1.Image = Nothing
    End Sub

    Private Sub Uс_trilbone_history_MouseClick(sender As Object, e As MouseEventArgs) Handles Me.MouseClick
        Me.tbSampleNumber.Focus()
    End Sub

    Private Sub LoadMC()
        If Not clsApplicationTypes.DelegatStoreMCinterface Is Nothing Then
            Me.oMCinterface = clsApplicationTypes.DelegatStoreMCinterface.Invoke(False)
            If Not Me.oMCinterface Is Nothing Then
                Return
            End If
        End If
        'не удалось получить интерфейс МС
        MsgBox("Не удалось получить интерфейс МС", vbCritical)
    End Sub

   

    Private Sub Label5_MouseClick(sender As Object, e As MouseEventArgs) Handles Label5.MouseClick
        Dim _tb As TextBoxBase = tbSampleNumber
        _tb.Text = ""
        GetDigiKey.connect(_tb)
    End Sub
    Public Shared ReadOnly Property GetDigiKey As Object
        Get
            Return Service.clsApplicationTypes.GetDigiKeyBoardForm
            'использование в событии mouseClick ЭУ
            'Dim _tb As TextBoxBase = mycontrol
            '_tb.Text = ""
            'GetDigiKey.connect(_tb)
        End Get
    End Property

    Private Sub btAskPriceHistory_Click(sender As Object, e As EventArgs) Handles btAskPriceHistory.Click
        Dim _namePart As String
        ' Dim _sm As clsApplicationTypes.clsSampleNumber = If(e.RowIndex >= 0, nop_DataGridView.Rows(e.RowIndex).Cells(oSKUColumnIndex).Tag, Nothing)
        'клиент 
        ' Dim _client = dgv_SampleResultByName.Columns(e.ColumnIndex).HeaderText.Trim.ToLower
        'берем часть имени из заголовка
        _namePart = oSampleNumber.AskName
        'If Not String.IsNullOrEmpty(Me.Sample_main_speciesComboBox.Text) Then
        '    _namePart = Me.Sample_main_speciesComboBox.Text.Trim
        'Else
        '    'или из значения ячейки
        '    _namePart = dgv_SampleResultByName.Rows(If(e.RowIndex < 0, 0, e.RowIndex)).Cells(2).Value.ToString.Split(" ").FirstOrDefault
        'End If

        If String.IsNullOrEmpty(_namePart) Then Return

        _namePart = _namePart.ToLower()

        Dim _fossilsize As Decimal = 0 ' Decimal.Parse(dgv_SampleResultByName.Rows(If(e.RowIndex < 0, 0, e.RowIndex)).Cells(4).Value)
        'Me.oSplashscreen.Show()
        'получить обьект-источник данных

        Dim _result = clsSellInfo.GetStatistic(_namePart, "", _fossilsize)
        'Me.oSplashscreen.Hide()


        Me.ContextMenuStrip1.Items.Clear()

        If _result.Count > 0 Then
            Me.ContextMenuStrip1.Items.AddRange(_result.GetMenuItems)
            Me.ContextMenuStrip1.Show(Me.rtb_info.PointToScreen(rtb_info.Location))
        Else
            MsgBox(String.Format("По образцам {0} размером около {1} данных нет", _namePart, _fossilsize), vbInformation)
        End If
    End Sub
End Class
