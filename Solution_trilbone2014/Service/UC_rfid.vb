Imports RFID.cls_SDTAPI
Imports RFID
Imports System.Windows.Forms

Public Class UC_rfid
#Region "определения"
    Private WithEvents oManager As clsRfidManager

#End Region

    Public Property SampleNumber As String
        Get
            Return Me.tbResult.Text
        End Get
        Set(value As String)
            Me.tbWriteData.Text = value
        End Set
    End Property


#Region "Загрузка и выгрузка формы"
    Private Sub fm_main_Load(sender As Object, e As EventArgs) Handles Me.Load
        oManager = clsApplicationTypes.RFIDmanager
        Me.BindingSource1.DataSource = oManager
        Me.btWrite.Enabled = False
        Me.tbWriteData.Enabled = False
    End Sub

#End Region

#Region "работа с ЭУ"
    Private Sub btOpenReader_Click(sender As Object, e As EventArgs)
        oManager = New clsRfidManager
    End Sub

    Private Sub btRead_Click(sender As Object, e As EventArgs) Handles btRead.Click
        oManager.Read()

        Me.lbxCards.DataSource = oManager.CardInfo.CardCollection

        If Not oManager.HasCards Then
            Me.btWrite.Enabled = False
            Me.tbWriteData.Enabled = False
        Else
            Me.btWrite.Enabled = True
            Me.tbWriteData.Enabled = True
            If Me.cbxClearIfNew.Checked Then
                'очищать при новой метке
                Me.tbWriteData.Text = ""
            End If
        End If
    End Sub

    Private Sub btWrite_Click(sender As Object, e As EventArgs) Handles btWrite.Click
        If lbxCards.SelectedItem Is Nothing Then Return
        'Select Case MsgBox("Метка будет перезаписана. Уверен?", vbYesNo)
        '    Case MsgBoxResult.No
        '        Return
        'End Select
        Me.oManager.Write(lbxCards.SelectedIndex, Me.tbWriteData.Text)
    End Sub

   
 
#End Region

    Private Sub lbxCards_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbxCards.SelectedIndexChanged
        If lbxCards.SelectedItem Is Nothing Then Me.tbResult.Text = "" : Return

        Me.tbResult.Text = CType(lbxCards.SelectedItem, iRFIDDataProvider.clsCardInfo).Sector0Block1STR
    End Sub

    Private Sub oManager_TagStringCollectionChanged(sender As Object, e As clsRfidManager.TagsStringCollectionChangedEventArgs) Handles oManager.TagStringCollectionChanged
        If e.Count > 0 Then
            RaiseEvent TagReaded(Me, New TagReadedEventArgs With {.TagCollection = e.TagCollection})
        End If
    End Sub

    Private Sub oManager_TagWrited(sender As Object, e As EventArgs) Handles oManager.TagWrited
        btRead_Click(sender, e)
        Me.tbWriteData.Focus()
        RaiseEvent TagWrited(Me, EventArgs.Empty)
    End Sub

    Public Event TagWrited(sender As Object, e As EventArgs)

    Public Event TagReaded(sender As Object, e As TagReadedEventArgs)

    Public Class TagReadedEventArgs
        Inherits EventArgs

        Public Property TagCollection As String()

        Public ReadOnly Property Count As Integer
            Get
                If TagCollection Is Nothing Then Return 0
                Return TagCollection.Length
            End Get
        End Property
    End Class

    Private Sub tbWriteData_KeyPress(sender As Object, e As Windows.Forms.KeyPressEventArgs) Handles tbWriteData.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If tbWriteData.Text.Length = 13 Then
                Dim _code = ShotCodeConverter_Net.clsCode.CreateInstance(tbWriteData.Text)
                tbWriteData.Text = _code.ShotCode
                If Me.cbxClearIfNew.Checked Then
                    'автомат записи
                    Me.btWrite_Click(Me.btWrite, EventArgs.Empty)
                End If
            Else
                Dim _code = ShotCodeConverter_Net.clsCode.CreateInstance(tbWriteData.Text)
                If Not _code.CodeType = ShotCodeConverter_Net.clsCode.emCodeType.Incorrect Then
                    tbWriteData.Text = _code.ShotCode
                    If Me.cbxClearIfNew.Checked Then
                        'автомат записи
                        Me.btWrite_Click(Me.btWrite, EventArgs.Empty)
                    End If
                End If
            End If

        End If
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

    Private Sub Label1_MouseClick(sender As Object, e As Windows.Forms.MouseEventArgs) Handles Label1.MouseClick
        Dim _tb As TextBoxBase = tbWriteData
        _tb.Text = ""
        GetDigiKey.connect(_tb)
    End Sub

    Private Sub btSendKeys_Click(sender As Object, e As EventArgs) Handles btSendKeys.Click
        If btSendKeys.BackColor = Drawing.Color.Green Then
            btSendKeys.BackColor = Button.DefaultBackColor
        Else
            btSendKeys.BackColor = Drawing.Color.Green

        End If
    End Sub


    Private Sub UC_rfid_LostFocus(sender As Object, e As EventArgs) Handles btSendKeys.LostFocus
        If Not btSendKeys.BackColor = Drawing.Color.Green Then Return

        Dim _bg As New System.ComponentModel.BackgroundWorker

        AddHandler _bg.DoWork, Sub(sender1 As Object, e1 As System.ComponentModel.DoWorkEventArgs)
                                   e1.Result = SendKeysTo(Me.tbResult.Text)
                               End Sub
        AddHandler _bg.RunWorkerCompleted, Sub(sender2 As Object, e2 As System.ComponentModel.RunWorkerCompletedEventArgs)
                                               If (e2.Error IsNot Nothing) Then
                                                   MessageBox.Show(e2.Error.Message)
                                               ElseIf e2.Cancelled Then
                                                   ' Next, handle the case where the user canceled the 
                                                   ' operation.
                                                   ' Note that due to a race condition in 
                                                   ' the DoWork event handler, the Cancelled
                                                   ' flag may not have been set, even though
                                                   ' CancelAsync was called.
                                                   ' btSendKeys.BackColor = Button.DefaultBackColor
                                               Else
                                                   ' Finally, handle the case where the operation succeeded.
                                                   btSendKeys.BackColor = Button.DefaultBackColor
                                               End If
                                           End Sub

        _bg.RunWorkerAsync()

    End Sub

    Private Function SendKeysTo(value As String) As Boolean
        'пауза
        System.Threading.Thread.Sleep(100)
        'послать номер
        ''посылаю клавиши
        Dim _resultString = Me.tbResult.Text
        If _resultString = "131313" Then
            SendKeys.SendWait("{Backspace}{Backspace}{Backspace}{Backspace}{Backspace}{Backspace}{Backspace}{Backspace}{Backspace}")
        Else
            SendKeys.SendWait(_resultString & ChrW(13))
        End If
        Return True
    End Function

    Private Sub tbWriteData_TextChanged(sender As Object, e As EventArgs) Handles tbWriteData.TextChanged

    End Sub
End Class
