Imports nopTypes.Nop.Plugin.Misc.panoRazziRestService
Imports System.Runtime.InteropServices
Imports System.Windows.Forms
Imports System.Reflection
Imports LiveSwitch.TextHelper
Imports System.Text.RegularExpressions
Imports System.Drawing
Imports System.Globalization

Public Class uc_nopDescription
#Region "visual constructor"

    Public Property DataLangString As String
        Get
            Return Me.cbx_dataLang.Text
        End Get
        Set(value As String)
            Me.cbx_dataLang.Text = value
        End Set
    End Property

    Public Property DataLangCheckedStatus As Boolean
        Get
            Return Me.cbx_dataLang.Checked
        End Get
        Set(value As Boolean)
            Me.cbx_dataLang.Checked = value
        End Set
    End Property
#End Region

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



    Public Event ObjectListChanged(sender As Object, e As EventArgs)
    Private WithEvents oDataObj As clsDescriptionObject

    Public Sub New()
        ' Этот вызов является обязательным для конструктора.
        InitializeComponent()
        ' Добавьте все инициализирующие действия после вызова InitializeComponent().
        Me.tb_NameEng.Text = "Не инициализован"
    End Sub

    Public Sub init(obj As clsDescriptionObject)
        oDataObj = obj
        Me.bs_description.DataSource = oDataObj

        Me.Uc_langObjectTag.init(oDataObj.DataLang, oDataObj.ProductTag)
        Me.Uc_SimpleObjectWords.Init(oDataObj.DataLang, "MetaKeywordsValue", oDataObj.ProductMetaWord)

        Dim _html As XElement = <html><body>Добавте описание</body></html>

        If String.IsNullOrEmpty(oDataObj.FullDescriptions) Then
            oDataObj.FullDescriptions = _html.ToString
        End If

        Me.DataLangString = oDataObj.LangString

        Me.rtb_ShotDescrEng.Text = ""
        Me.rtb_ShotMetaEng.Text = ""

        If String.IsNullOrEmpty(tb_NameEng.Text) Then
            tb_NameEng.BackColor = Color.Red
        End If
        If String.IsNullOrEmpty(Me.rtb_ShotDescrEng.Text) Then
            Me.rtb_ShotDescrEng.BackColor = Color.Yellow
        End If


        'oDataObj.SelectedProductTag = clsLangObjectCollection.CreateInstance("ProductTag")
        'oDataObj.SelectedProductMetaWord = clsLangObjectCollection.CreateInstance("MetaKeywordsValue")
        'MsgBox(XElement.Parse(oDataObj.FullDescriptions).ToString)
        ' Me.wb_FullDescriptionEn = New Windows.Forms.WebBrowser
    End Sub

    Public Sub RefreshInnerUC()
        'обновить значения из источника для ЭУ теги и слова
        Uc_langObjectTag.RefreshSource()
        Uc_langObjectTag.RefreshSelected()
    End Sub



    Public ReadOnly Property GetXML As String
        Get
            Dim _err As XElement = <error>Не инициализован</error>
            If oDataObj Is Nothing Then Return _err.ToString
            If Me.cbx_dataLang.Checked Then
                oDataObj.SetAsInvariant = True
            End If
            If oDataObj.Parent Is Nothing Then Return _err.ToString
            Return oDataObj.Parent.GetXML
        End Get
    End Property

    Public ReadOnly Property DataObj As clsDescriptionObject
        Get
            Return oDataObj
        End Get
    End Property

    Private Sub Uc_langObjectTag_ObjectListChanged(sender As Object, e As EventArgs) Handles Uc_langObjectTag.ObjectListChanged
        oDataObj.SelectedProductTag = Uc_langObjectTag.SelectedObjects
    End Sub

    Private Sub Uc_SimpleObjectWords_ObjectListChanged(sender As Object, e As EventArgs) Handles Uc_SimpleObjectWords.ObjectListChanged
        oDataObj.SelectedProductMetaWord.AddRange(Uc_SimpleObjectWords.SelectedObjects)
    End Sub

    Private Sub bt_acceptTemplate_Click(sender As Object, e As EventArgs) Handles bt_acceptTemplate.Click
        If Me.lb_Templates.SelectedItem Is Nothing Then Return
        ' TODO

        Dim _template As clsExternalData.clsxslTemplate = Me.lb_Templates.SelectedItem
        Dim _templateBody As String = Me.lb_Templates.SelectedValue
        Dim _result As String = ""

        If _template.Name = "оригинал" Then
            'шаблоны с именем оригинал хранят переданное описание
            _result = _templateBody
        Else
            'тут применить шаблон
            '_templateBody содержит шаблон, который применяется к оригинальному HTML
            Dim _html As XElement = <template>
                                        <%= _templateBody %>
                                    </template>

            _result = _html.ToString
        End If

        ' При любом изменении HTML внести изменение в FullDescription!!!
        oDataObj.FullDescriptions = _result
        Me.wb_FullDescriptionEn.DocumentText = oDataObj.FullDescriptions.ToString
    End Sub

    Private Sub bt_showHTML_Click(sender As Object, e As EventArgs) Handles bt_showHTML.Click
        'TODO показать чистый HTML
        'глючит без перезапуска отладки (закрыть студию)
        Me.wb_FullDescriptionEn.DocumentText = oDataObj.FullDescriptions.ToString
    End Sub

    Private Sub oDataObj_PropertyChanged(sender As Object, e As System.ComponentModel.PropertyChangedEventArgs) Handles oDataObj.PropertyChanged
        'изменения в обьекте
        RaiseEvent ObjectListChanged(Me, EventArgs.Empty)
    End Sub

    Public Sub AddSelectedTag(tags As IEnumerable(Of LangObject))
        Me.Uc_langObjectTag.AddPreSelected(tags)
    End Sub

    Public Sub AddSelectedWord(words As IEnumerable(Of LangObject))
        Me.Uc_SimpleObjectWords.AddPreSelected(words)
    End Sub



    Private Sub textBox_MouseUp(sender As Object, e As MouseEventArgs) Handles tb_NameEng.MouseUp, tb_MetaNameEng.MouseUp, rtb_ShotDescrEng.MouseUp, rtb_ShotMetaEng.MouseUp

        If e.Button = MouseButtons.Right Then
            ToolStripTextBoxWord.Text = ""
            Dim TextBox As TextBoxBase = sender
            Dim _text As String = ""
            Dim global_char_index As Integer = TextBox.GetCharIndexFromPosition(New Point(e.X, e.Y))
            Dim line_index As Integer = TextBox.GetLineFromCharIndex(global_char_index)
            Dim line_start As Integer = TextBox.GetFirstCharIndexFromLine(line_index)
            Dim char_index As Integer = global_char_index - line_start
            Dim line As String = TextBoxtHelper.GetTextBoxLine(TextBox, line_index)
            For Each match As Match In word_searcher.Matches(line)
                If match.Success AndAlso match.Index <= char_index AndAlso char_index <= match.Index + match.Length Then
                    TextBox.SelectionStart = line_start + match.Index
                    TextBox.SelectionLength = match.Length
                    _text = TextBox.SelectedText.Trim.ToLower
                    Exit For
                End If
            Next
            ToolStripTextBoxWord.Text = _text
            If Uc_langObjectTag.ContainsInvariantValue(_text) Then
                ToolStripMenuItemToTags.Enabled = False
            Else
                ToolStripMenuItemToTags.Enabled = True
            End If

            If Uc_SimpleObjectWords.ContainsInvariantValue(_text) Then
                ToolStripMenuItemToWords.Enabled = False
            Else
                ToolStripMenuItemToWords.Enabled = True
            End If
        End If
    End Sub

    Private Shared word_searcher As New Regex("\w+", RegexOptions.Compiled Or RegexOptions.IgnoreCase)

    Private Sub ToolStripMenuItemToTags_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemToTags.Click
        Dim _word = ToolStripTextBoxWord.Text
        Uc_langObjectTag.Insert(_word)
    End Sub

    Private Sub ToolStripMenuItemToWords_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemToWords.Click
        Dim _word = ToolStripTextBoxWord.Text
        Uc_SimpleObjectWords.Insert(_word)
    End Sub

    Private Sub ToolStripMenuItemCopyWord_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemCopyWord.Click
        '------------------
        Dim _data As String = ToolStripTextBoxWord.Text
        Try
            My.Computer.Clipboard.Clear()
            My.Computer.Clipboard.SetText(_data)
        Catch ex As Exception
            MsgBox("Ошибка при помещении данных в буфер обмена.", vbCritical)
        End Try
        '-----------------
    End Sub

    Private Sub ToolStripMenuItemCopyAll_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemCopyAll.Click
        Dim _control As TextBoxBase = ContextMenuStripTags.SourceControl
        '------------------
        Dim _data As String = _control.Text
        Try
            My.Computer.Clipboard.Clear()
            My.Computer.Clipboard.SetText(_data)
        Catch ex As Exception
            MsgBox("Ошибка при помещении данных в буфер обмена.", vbCritical)
        End Try
        '-----------------
    End Sub

    Private Sub ToolStripMenuItemInsertWord_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemInsertWord.Click
        Dim _control As TextBoxBase = ContextMenuStripTags.SourceControl
        If My.Computer.Clipboard.ContainsText Then
            Dim _text = My.Computer.Clipboard.GetText
            _control.SelectedText = _text
        End If
    End Sub

    Private Sub ToolStripMenuItemInsertAll_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemInsertAll.Click
        Dim _control As TextBoxBase = ContextMenuStripTags.SourceControl
        If My.Computer.Clipboard.ContainsText Then
            Dim _text = My.Computer.Clipboard.GetText
            Dim _position = _control.SelectionStart + _control.SelectionLength
            Dim _nt = _control.Text.Insert(_position, " " & _text)
            _control.Text = _nt
        End If
    End Sub

    Private Sub btCondition_Click(sender As Object, e As EventArgs) Handles btCondition.Click
        Dim _lang As CultureInfo = CultureInfo.CreateSpecificCulture("en-US")
        If oDataObj Is Nothing Then Return
      
        Dim _fm As New fmCondition(oDataObj.Culture)
        _fm.StartPosition = FormStartPosition.Manual
        Dim _loc = Me.rtb_ShotDescrEng.Location
        _fm.Location = _loc
        AddHandler _fm.TextDataChanged, AddressOf ShotDescriptionChanged_eventHandler
        _fm.ShowDialog()
    End Sub

    Private Sub ShotDescriptionChanged_eventHandler(sender As Object, e As fmCondition.TextDataChangedEventArgs)
        Me.oDataObj.ShortDescriptions = e.Text
        Me.oDataObj.Parent.ChangeAllDescription(e.Values, e.GetText, Me.oDataObj)
    End Sub

    Private Sub tb_NameEng_TextChanged(sender As Object, e As EventArgs) Handles tb_NameEng.TextChanged
        If Not String.IsNullOrEmpty(tb_NameEng.Text) Then
            tb_NameEng.BackColor = Color.FromKnownColor(KnownColor.Window)
        End If
    End Sub

    Private Sub rtb_ShotDescrEng_TextChanged(sender As Object, e As EventArgs) Handles rtb_ShotDescrEng.TextChanged
        If Not String.IsNullOrEmpty(Me.rtb_ShotDescrEng.Text) Then
            Me.rtb_ShotDescrEng.BackColor = Color.FromKnownColor(KnownColor.Window)
        End If
    End Sub

  
End Class
