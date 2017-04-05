Imports Service.Agents
Imports Service
Imports System.Windows.Forms
Imports nopRestClient
Imports System.Drawing
Imports Service.Catalog
Imports Service.com.ebay.developer

Public Class UC_ebay
    Private Class ebaySplashScreen1
        Inherits System.Windows.Forms.Form
        'Является обязательной для конструктора форм Windows Forms
        Private components As System.ComponentModel.IContainer
        Public Sub New()
            InitializeComponent()
        End Sub
        'Примечание: следующая процедура является обязательной для конструктора форм Windows Forms
        'Для ее изменения используйте конструктор форм Windows Form.  
        'Не изменяйте ее в редакторе исходного кода.
        <System.Diagnostics.DebuggerStepThrough()>
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

#Region "Обьявления"

    Private oSplashscreen1 As ebaySplashScreen1

    Private oAuctionAgentList As AUCTIONAGENT
    ''' <summary>
    ''' текущий агент
    ''' </summary>
    ''' <remarks></remarks>
    Private oCurrentAgent As AUCTIONDATAAGENT
    ''' <summary>
    ''' для обработчиков событий currentitemchanged показывает, что метод не надо выполнять
    ''' </summary>
    ''' <remarks></remarks>
    Private oIsinitProcedure As Boolean

#Region "внешние"
    ''' <summary>
    ''' образец для выставления
    ''' </summary>
    ''' <remarks></remarks>
    Private oSampleNumber As Service.clsApplicationTypes.clsSampleNumber
    ''' <summary>
    ''' текущий обьект каталога
    ''' </summary>
    ''' <remarks></remarks>
    Private oCurrentCatalogSampleObj As CATALOGSAMPLE
    ''' <summary>
    ''' текущее устройство с фотками
    ''' </summary>
    ''' <remarks></remarks>
    Private oCurrentFileSource As Service.clsFilesSources
    ''' <summary>
    ''' текущий HTML образца для формы
    ''' </summary>
    ''' <remarks></remarks>
    Private oCurrentHTML As String
    ''' <summary>
    ''' выбранные фото для камня
    ''' </summary>
    ''' <remarks></remarks>
    Private oCurrentImagesPath As List(Of String)
    ''' <summary>
    ''' цена розницы из МС для тех, у кого доступа к ценам нет В USD!!!
    ''' </summary>
    ''' <remarks></remarks>
    Private oRecommendPrice As Decimal
    ' ''' <summary>
    ' ''' me.WebBrowser1.DocumentText
    ' ''' </summary>
    ' ''' <value></value>
    ' ''' <returns></returns>
    ' ''' <remarks></remarks>
    'Private Property oWebBrowser1DocumentText As String
    ''' <summary>
    ''' загружает эу к ebay
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub init(SampleNumber As Service.clsApplicationTypes.clsSampleNumber, CurrentCatalogSampleObj As CATALOGSAMPLE, CurrentFileSource As Service.clsFilesSources, CurrentHTML As String, CurrentImagesPath As List(Of String), RecommentPrice As Decimal)


        oSplashscreen1 = New ebaySplashScreen1

        oSampleNumber = SampleNumber
        oCurrentCatalogSampleObj = CurrentCatalogSampleObj
        oCurrentFileSource = CurrentFileSource
        Me.CurrentHTML = CurrentHTML
        Me.PicturePaths = CurrentImagesPath
        oRecommendPrice = RecommentPrice

        oIsinitProcedure = True

        oAuctionAgentList = clsApplicationTypes.AuctionAgent
        'выбрать агентов ебай
        Me.bs_AuctionAgentList.DataSource = (oAuctionAgentList.AGENT.Where(Function(x) x.name = "ebay")).ToList

        'генерация ЭУ для агентов
        Me.pnAccounts.Controls.Clear()
        For Each _agentAccount As AUCTIONDATAAGENT In Me.bs_AuctionAgentList.DataSource
            Dim _newrb As New RadioButton
            With _newrb
                .AutoSize = True
                .Name = "rb" & _agentAccount.account
                .TabStop = False
                .Text = _agentAccount.account
                .UseVisualStyleBackColor = True
            End With
            Me.pnAccounts.Controls.Add(_newrb)
            AddHandler _newrb.CheckedChanged, AddressOf Me.rbAgents_CheckedChanged
        Next

        oIsinitProcedure = False
        '  LockCtl()
    End Sub

#End Region

#End Region
    Sub New()
        ' Этот вызов является обязательным для конструктора.
        InitializeComponent()
        ' Добавьте все инициализирующие действия после вызова InitializeComponent().
    End Sub
#Region "Обработка событий ЭУ"
    Private Sub tbWeightKG_TextChanged(sender As Object, e As EventArgs) Handles tbWeightKG.TextChanged

        Me.CalculateShipping()
    End Sub

    Private Sub tbStartAuctionPriceUSD_TextChanged(sender As Object, e As EventArgs) Handles tbStartAuctionPriceUSD.TextChanged
        'UC
        If tbStartAuctionPriceUSD.Text = "" Or tbStartAuctionPriceUSD.Text = "0" Then

        Else
            tbStartAuctionPriceUSD.BackColor = Color.FromKnownColor(KnownColor.Window)
        End If
    End Sub

    Private Sub cbxPrivateListing_CheckedChanged(sender As Object, e As EventArgs) Handles cbxPrivateListing.CheckedChanged
        If Me.cbxPrivateListing.DataBindings.Count > 0 Then
            Me.cbxPrivateListing.DataBindings(0).WriteValue()
        End If
    End Sub

    Private Sub cbxFreeShipping_CheckedChanged(sender As Object, e As EventArgs) Handles cbxFreeShipping.CheckedChanged
        If Me.cbxFreeShipping.DataBindings.Count > 0 Then
            Me.cbxFreeShipping.DataBindings(0).WriteValue()
        End If
    End Sub

    Private Sub cbxAcceptOffers_CheckedChanged(sender As Object, e As EventArgs) Handles cbxAcceptOffers.CheckedChanged
        If Me.cbxAcceptOffers.DataBindings.Count > 0 Then
            Me.cbxAcceptOffers.DataBindings(0).WriteValue()

        End If
    End Sub

    Private Sub tbBuyItNowPriceUSD_TextChanged(sender As Object, e As EventArgs) Handles tbBuyItNowPriceUSD.TextChanged
        If tbBuyItNowPriceUSD.Text = "" Or tbBuyItNowPriceUSD.Text = "0" Then

        Else
            tbBuyItNowPriceUSD.BackColor = Color.FromKnownColor(KnownColor.Window)
        End If
    End Sub

    Private Sub cbxBuyItNow_CheckedChanged(sender As Object, e As EventArgs) Handles cbxBuyItNow.CheckedChanged
        If Me.cbxBuyItNow.DataBindings.Count > 0 Then
            Me.cbxBuyItNow.DataBindings(0).WriteValue()

        End If
        If cbxBuyItNow.Checked = True Then
            Me.tbBuyItNowPriceUSD.Focus()
        End If
    End Sub

    Private Sub cbListingType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbListingType.SelectedIndexChanged
        If cbListingType.SelectedItem Is Nothing Then Return
        ' oCurrentAgent.AgentParameters.AuctionType = Nothing
        Dim _listingType As String = cbListingType.SelectedItem.value

        Select Case _listingType
            'Case "GTS"
            'Me.cbxBuyItNow.Checked = True
            'Me.cbxBuyItNow.DataBindings(0).WriteValue()
            'Me.rbAuction_nothing.Checked = True
            Case "Auction"
                pnAuctionType.Enabled = True
                Me.tbStartAuctionPriceUSD.Enabled = True

                ' Me.tbBuyItNowPriceUSD.Text = ""
                Me.tbBuyItNowPriceUSD.BackColor = Color.FromKnownColor(KnownColor.Window)

                Me.tbReserveAuctionPriceUSD.Enabled = True
                If Me.tbStartAuctionPriceUSD.Text = "" Or Me.tbStartAuctionPriceUSD.Text = "0" Then
                    Me.tbStartAuctionPriceUSD.BackColor = Drawing.Color.Red

                End If
                Me.tbStartAuctionPriceUSD.Focus()
                'Me.tbBuyItNowPriceUSD.Enabled = cbxBuyItNow.Checked
                'Me.cbxAcceptOffers.Enabled = cbxBuyItNow.Checked
                'If cbxBuyItNow.Checked = False Then
                '    Me.tbBuyItNowPriceUSD.Text = ""
                '    Me.cbxAcceptOffers.Checked = False
                '    Me.cbxAcceptOffers.DataBindings(0).WriteValue()
                'End If

                'Me.cbxBuyItNow.Checked = False
                'Me.cbxBuyItNow.DataBindings(0).WriteValue()

            Case Else
                'Me.cbxBuyItNow.Checked = True
                'Me.cbxBuyItNow.DataBindings(0).WriteValue()
                pnAuctionType.Enabled = False
                'Me.tbReserveAuctionPriceUSD.Text = ""
                Me.tbReserveAuctionPriceUSD.Enabled = False

                'Me.tbStartAuctionPriceUSD.Text = ""
                Me.tbStartAuctionPriceUSD.BackColor = Color.FromKnownColor(KnownColor.Window)
                Me.tbStartAuctionPriceUSD.Enabled = False

                If Me.tbBuyItNowPriceUSD.Text = "" Or Me.tbBuyItNowPriceUSD.Text = "0" Then
                    Me.tbBuyItNowPriceUSD.BackColor = Drawing.Color.Red

                End If
                Me.tbBuyItNowPriceUSD.Focus()


        End Select
    End Sub

    Private Sub cbGeologyAge_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbGeologyAge.SelectedIndexChanged
        If cbGeologyAge.SelectedItem Is Nothing Then Return
        If cbGeologyAge.SelectedItem.agentID = "0" Then Return
        Dim _itemSpecStr As String = ""
        _itemSpecStr += "Geological age: " & cbGeologyAge.SelectedItem.agentID & "; "
        Me.tbItemSpecificTotal.Text += _itemSpecStr
        Me.tbItemSpecificTotal.DataBindings(0).WriteValue()
    End Sub
    Private Sub cbGeologyAge_MouseDoubleClick(sender As Object, e As Windows.Forms.MouseEventArgs) Handles cbGeologyAge.MouseDoubleClick
        Dim _age = Me.GetCurrentSampleAge
        Me.tbTitleValue.Text += _age
        Me.tbTitleValue.DataBindings(0).WriteValue()
    End Sub

    Private Sub cbCountry_MouseDoubleClick(sender As Object, e As Windows.Forms.MouseEventArgs) Handles cbCountry.MouseDoubleClick
        Dim _country = Me.GetCurrentSampleOridginCountry
        Me.tbTitleValue.Text += _country
        Me.tbTitleValue.DataBindings(0).WriteValue()
    End Sub

    Private Sub cbCountry_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbCountry.SelectedIndexChanged
        If cbCountry.SelectedItem Is Nothing Then Return
        If cbCountry.SelectedItem.agentID = "0" Then Return
        Dim _itemSpecStr As String = ""
        _itemSpecStr += "Origin country: " & cbCountry.SelectedItem.agentID & "; "
        Me.tbItemSpecificTotal.Text += _itemSpecStr
        Me.tbItemSpecificTotal.DataBindings(0).WriteValue()
    End Sub

    Private Sub lblTitles_DoubleClick(sender As Object, e As EventArgs) Handles lblTitles.DoubleClick
        If lblTitles.SelectedItem Is Nothing Then Return
        Me.tbTitleValue.Text = Me.lblTitles.SelectedItem
        Me.tbTitleValue.DataBindings(0).WriteValue()
        Me.btAddName_Click(sender, e)
        'пробуем подобрать категорию eBay
        Dim _patt = clsTemplateManager.GetFirstWord(Me.tbTitleValue.Text)

        Dim _result = (From c As AUCTIONDATAAGENTFIELDITEM In Me.cbCategory.Items Where c.value.ToLower.Contains(_patt.ToLower.Substring(0, 4)) Select c).FirstOrDefault

        If Not _result Is Nothing Then
            Me.cbCategory.SelectedItem = _result
            Me.cbCategory.DataBindings(0).WriteValue()
        End If
    End Sub

    Private Sub cbxAddSuffics_CheckedChanged(sender As Object, e As EventArgs) Handles cbxAddSuffics.CheckedChanged
        If cbxAddSuffics.Checked = True Then
            If Not Me.tbTitleValue.Text.Contains("from Trilbone") Then
                Me.tbTitleValue.Text = Me.tbTitleValue.Text & " from Trilbone"
                Me.tbTitleValue.DataBindings(0).WriteValue()
            End If
        Else
            Me.tbTitleValue.Text.Replace(" from Trilbone", "")
            Me.tbTitleValue.DataBindings(0).WriteValue()
        End If
    End Sub

    Private Sub cbxRarePrefix_CheckedChanged(sender As Object, e As EventArgs) Handles cbxRarePrefix.CheckedChanged
        If cbxRarePrefix.Checked = True Then
            If Not Me.tbTitleValue.Text.StartsWith("RARE") Then
                Me.tbTitleValue.Text = "RARE " & Me.tbTitleValue.Text
                Me.tbTitleValue.DataBindings(0).WriteValue()
            End If
        Else
            Me.tbTitleValue.Text.Replace("RARE ", "")
            Me.tbTitleValue.DataBindings(0).WriteValue()
        End If
    End Sub

    Private Sub cbxEnableSubTitle_CheckedChanged(sender As Object, e As EventArgs) Handles cbxEnableSubTitle.CheckedChanged
        If cbxEnableSubTitle.Checked Then
            'cbxEnableSubTitle.BackColor = Drawing.Color.Green
            Me.cbSubTitles.BackColor = Drawing.Color.Green
        Else
            Me.cbSubTitles.BackColor = Color.FromKnownColor(KnownColor.Window)
        End If
    End Sub

    Private Sub cbSubTitles_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbSubTitles.SelectedIndexChanged
        Dim _count = Me.cbSubTitles.Text.Length
        Dim _control = Me.cbSubTitles
        Dim _maxvalue = oCurrentAgent.AgentParameters.CntMaxWorldSubTitleCount

        Me.lbWordRemainSub.Text = "Remain " & _maxvalue - _control.Text.Length

        If _count >= _maxvalue Then
            _control.ForeColor = Drawing.Color.Red
            '_control.Text = _control.Text.Substring(0, _maxvalue)
            '_control.DataBindings(0).WriteValue()
        Else
            _control.ForeColor = Control.DefaultForeColor
        End If

    End Sub
    Private Sub tbTitleValue_TextChanged(sender As Object, e As EventArgs) Handles tbTitleValue.TextChanged
        Dim _count = Me.tbTitleValue.Text.Length
        Dim _control = Me.tbTitleValue
        Dim _maxvalue = oCurrentAgent.AgentParameters.CntMaxWorldCount

        Me.lbWorldRemain.Text = "Remain " & _maxvalue - _control.Text.Length

        If _count >= _maxvalue Then
            _control.ForeColor = Drawing.Color.Red
        Else
            _control.ForeColor = Control.DefaultForeColor
        End If
    End Sub
    ''' <summary>
    ''' предварительная проверка
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function PreCheck() As Boolean
        Dim _result As Boolean = True
        If String.IsNullOrEmpty(oCurrentAgent.AgentParameters.CurrentHTML) Then
            MsgBox("Описание товара (Item description) не создано, отмена выставления", MsgBoxStyle.Critical)
            _result = False
        End If
        If oCurrentAgent.AgentParameters.Category Is Nothing Then
            MsgBox("Категория eBay не выбрана, отмена выставления", MsgBoxStyle.Critical)
            _result = False
        End If
        If String.IsNullOrEmpty(oCurrentAgent.AgentParameters.ItemSpecifics) Then
            MsgBox("Описание сохранности (ItemSpecifics) товара не создано, отмена выставления", MsgBoxStyle.Critical)
            _result = False
        End If
        If String.IsNullOrEmpty(oCurrentAgent.AgentParameters.Title) Or oCurrentAgent.AgentParameters.Title.Length > 80 Then

        End If
        If oCurrentAgent.AgentParameters.IsAcceptOffers = False Then
            Select Case MsgBox("Предложения цены в листинге приниматься не будут (кнопки Make Offer не будет). Оставить?", vbYesNo)
                Case MsgBoxResult.No
                    _result = False
            End Select
        End If
        If oCurrentAgent.AgentParameters.PrivateListing = False Then
            Select Case MsgBox("Листинг не будет Private. Оставить?", vbYesNo)
                Case MsgBoxResult.No
                    _result = False
            End Select
        End If
        If oCurrentAgent.AgentParameters.ShippingWeightKG > 5 Then
            Select Case MsgBox(String.Format("Стоимость шиппинга за образец весом {0}кг программно занижена (поставлена как за посылку весом 5 кг). Оставить?", oCurrentAgent.AgentParameters.ShippingWeightKG), vbYesNo)
                Case MsgBoxResult.No
                    _result = False
            End Select
        End If
        Return _result
    End Function


    Private Sub btToAuction_Click(sender As Object, e As EventArgs) Handles btToAuction.Click
        'UC
        'получить FEE и превью??
        'подтверждение текущего HTML
        oCurrentAgent.AgentParameters.CurrentHTML = oCurrentHTML

        'предварительная проверка
        If Not PreCheck() Then Return

        Select Case MsgBox("Сейчас образец будет проверен eBay перед помещением на аукцион eBay. Вы уверены в правильности параметров?", MsgBoxStyle.YesNo)
            Case MsgBoxResult.No
                Return
        End Select

        Dim _response As VerifyAddItemResponseType = Nothing
        Dim _fees As List(Of FeeType) = Nothing
        If oSplashscreen1.Visible = False Then
            oSplashscreen1.Show()
            Application.DoEvents()
        End If
        Dim _item = oCurrentAgent.AgentParameters.VerifyAnItem(_response, _fees)
        oSplashscreen1.Hide()

        If _item Is Nothing Then
            'проверка не пройдена
            Dim _mg As String = ""
            Me.btCopyTosourceFromArhive.Enabled = True
            If _response Is Nothing Then
                Me.btCopyTosourceFromArhive.Enabled = True
                _mg = "проверка листинга не пройдена: "
            Else
                _mg = "проверка листинга не пройдена: " & _response.Message
            End If
            MsgBox(_mg, vbCritical)
            Return
        End If

        If _response Is Nothing Then
            MsgBox("ответ сервера на запрос проверки листинга не получен или не распознан", vbCritical)
            Return
        End If

        'выставочные fee (предварительно)
        Dim _msg As String = ""
        If Not _fees Is Nothing Then
            Dim _msgfee = From c1 In (From c In _fees Select c.Name & " --> " & c.Fee.Value & " " & c.Fee.currencyID.ToString)
            For Each t In _msgfee
                _msg += t
            Next
        End If

        Dim _resultAuction As Boolean = True
        Dim _fee As Decimal

        Select Case MsgBox("Проверка выполнена УСПЕШНО" & ChrW(13) & "Будут начислены следующие fee: " & _msg & ChrW(13) & "ВЫСТАВИТЬ ЛИСТИНГ?", vbYesNo)
            Case vbYes
                'выставить
                If oSplashscreen1.Visible = False Then
                    oSplashscreen1.Show()
                    Application.DoEvents()
                End If
                _resultAuction = oCurrentAgent.AgentParameters.SendToeBay(_item, _fee)
                oSplashscreen1.Hide()
                Application.DoEvents()
            Case Else
                'отказ пользователя
                Return
        End Select

        If _resultAuction Then
            MsgBox("Листинг удачно выставлен. Было начислено " & _fee & " $ за выставление.", vbInformation)
            'записать в мой склад списание и fee в расходы???
            'есть - имя агента
            'номер камня
            'сумма денег за выставление
            'дата выставления
            ReserveSampleToEbay(_fee)
        End If
    End Sub

    Private Sub btShippingConvertation_Click(sender As Object, e As EventArgs) Handles btShippingConvertation.Click
        'UC
        Dim _rate As Decimal = Math.Round(clsApplicationTypes.GetRateByCurrencyCB103("EUR") / clsApplicationTypes.GetRateByCurrencyCB103("USD"), 2)
        Dim _domestic As Decimal
        Dim _international As Decimal
        If Not Decimal.TryParse(Me.tbDomesticShipCost.Text, _domestic) Then Return
        If Not Decimal.TryParse(Me.tbInterShipCost.Text, _international) Then Return

        Me.tbDomesticShipCostUSD.Text = Math.Round(_domestic * _rate, 0)
        Me.tbDomesticShipCostUSD.DataBindings(0).WriteValue()

        Me.tbInterShipCostUSD.Text = Math.Round(_international * _rate, 0)
        Me.tbInterShipCostUSD.DataBindings(0).WriteValue()
    End Sub

    Private Sub rbAuctions_CheckedChanged(sender As Object, e As EventArgs)
        'UC
        'задать
        oCurrentAgent.AgentParameters.AuctionType = Nothing
        Dim _text As String = sender.text
        Dim _rf = (From c As AUCTIONDATAAGENTFIELD In Me.oCurrentAgent.FIELD Where c.name = "AuctionType" Select c).FirstOrDefault

        If _rf Is Nothing Then
            MsgBox("В файле агента отсутствуют описание типа аукционов. Раздел FIELD name=AuctionType", vbCritical)
            Return
        End If

        Dim _ro = (From c As AUCTIONDATAAGENTFIELDITEM In _rf.ITEM Where c.value.ToLower = _text.ToLower Select c).FirstOrDefault
        If _ro Is Nothing Then
            MsgBox("В файле агента отсутствуют описание выбранного аукциона. Раздел ITEM value", vbCritical)
            Return
        End If


        oCurrentAgent.AgentParameters.AuctionType = _ro

        If sender.text Is "No Auction" Then
            Me.cbListingType.SelectedIndex = 0
        Else
            Me.cbListingType.SelectedIndex = 1
        End If

    End Sub

    Private Sub btCopyTosourceFromArhive_Click(sender As Object, e As EventArgs) Handles btCopyTosourceFromArhive.Click
        If lblPhotoSources.SelectedItem Is Nothing Then Return
        'фотки
        Dim _fs = CType(lblPhotoSources.SelectedItem, AUCTIONDATAAGENTFIELDITEM).value

        Select Case _fs
            Case "Ebay Storage"
                'закачать фото на ебай
                'там фотки лежать Me.oCurrentImagesURI
                'сюда положить пути для агента ImageURIListForAgent

                If Me.PicturePaths Is Nothing OrElse Me.PicturePaths.Count = 0 Then
                    MsgBox("Фотки для листинга не отобраны!!", vbCritical)
                    Return
                End If

                Try

                    If oSplashscreen1.Visible = False Then
                        oSplashscreen1.Show()
                        Application.DoEvents()
                    End If

                    Dim _list = oCurrentAgent.AgentParameters.UploadPictures(PicturePaths.ToArray, oSampleNumber.ShotCode)
                    oSplashscreen1.Hide()

                    If _list.Count > 0 Then
                        oCurrentAgent.AgentParameters.ImageURIList = _list

                        oCurrentAgent.AgentParameters.ImageSource = clsAgentEbayParameters.emImageSources.EPS

                        'главной будет первая
                        oCurrentAgent.AgentParameters.ImageMainURI = _list(0)

                        MsgBox("Успешно загружено " & _list.Count & " фото", vbInformation)
                        Me.btCopyTosourceFromArhive.Enabled = False
                    Else
                        MsgBox("Загрузчик фото не выдал ошибку, но вернул 0 загруженных фото!!", vbCritical)
                        oSplashscreen1.Hide()
                        Return
                    End If


                Catch ex As Exception
                    MsgBox("Загрузчик фото выдал ошибку при загрузке фото: " & ex.Message, vbCritical)
                    oSplashscreen1.Hide()
                    Return
                End Try

            '--------------
            Case "TrilboneFTP"
                If Me.PicturePaths Is Nothing OrElse Me.PicturePaths.Count = 0 Then
                    MsgBox("Фотки для листинга не отобраны!!", vbCritical)
                    Return
                End If
                'получить список uri для отобранных фото
                Dim _filesource = clsFilesSources.FTPinfoTRILBONE

                Dim _names = From c In Me.PicturePaths Select IO.Path.GetFileName(c)

                Dim _ulist = clsApplicationTypes.SamplePhotoObject.GetImagesURI(oSampleNumber, _filesource, _names.ToArray)
                If _ulist Is Nothing OrElse _ulist.Count = 0 Then
                    MsgBox("Фоток нет на ftp в папке " & Math.Abs(oSampleNumber.GetHashCode), vbCritical)
                    Return
                End If
                Dim _list As New List(Of String)

                'сортировка как в списке выбора фоток
                For i = 0 To _names.Count - 1
                    Dim j = i
                    Dim _res = (From c In _ulist Where c.AbsoluteUri.Contains(_names(j)) Select c).FirstOrDefault
                    If Not _res Is Nothing Then
                        _list.Add(_res.AbsoluteUri)
                    Else
                        MsgBox("Ошибка логики. Фото " & _names(i) & " не будет добавлена в листинг!", vbCritical)
                    End If
                Next



                oCurrentAgent.AgentParameters.ImageURIList = _list.ToArray
                oCurrentAgent.AgentParameters.ImageSource = clsAgentEbayParameters.emImageSources.FTP
                'главной будет первая
                oCurrentAgent.AgentParameters.ImageMainURI = _list(0)

                MsgBox("Успешно привязано " & _list.Count & " фото", vbInformation)

                Me.btCopyTosourceFromArhive.Enabled = False
            Case Else
                Debug.Fail("Обработка " & _fs & " типа устройств вывода фото не задана!")
                MsgBox("Обработка " & _fs & " типа устройств вывода фото не задана!", vbCritical)
        End Select


    End Sub

    ''' <summary>
    ''' тут вся обработка вызова редактора
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btCreateTextDescription_Click(sender As Object, e As EventArgs) Handles btCreateTextDescription.Click
        'UC
        'будет вызвана по окончании редактирования
        Dim _fnHTMLReady = Function(value As String) As Boolean
                               Me.CurrentHTML = value
                               clsApplicationTypes.BeepYES()
                               Return True
                           End Function

        ''передает параметры форме редактора
        Dim _fnprm = Function(inp As String) As String()
                         'путь к папке с шаблонами еБай
                         Dim _currentTemplatePath As String = IO.Path.Combine(Service.clsApplicationTypes.TemplateFolderPath, "eBay")
                         Dim _list As New List(Of String)
                         _list.Add(IO.Path.GetDirectoryName(Me.oCurrentFileSource.ContainerPath))
                         _list.Add(_currentTemplatePath)
                         Dim _out = _list.ToArray
                         Return _out
                     End Function

        Dim _fm As New LiveSwitch.TextControl.EditorForm(_fnprm, _fnHTMLReady)
        'установить HTML в редакторе
        If Not String.IsNullOrEmpty(Me.CurrentHTML) Then
            Dim _doc = XDocument.Parse(Me.CurrentHTML)
            Dim _text = _doc.ToString
            _fm.SetHTML(_text)
        End If
        _fm.Show()
    End Sub

    Private Sub btAddTitle_Click(sender As Object, e As EventArgs) Handles btAddTitle.Click
        If Me.tbTitleValue.Text = "" Then Return
        Dim _index = Me.lblTitles.Items.Count
        If Me.AddValueInSpecificAgentField("title", Me.tbTitleValue.Text) Then
            Service.clsApplicationTypes.BeepYES()
            oAuctionAgentList.SaveAgentsFile()
            With Me.lblTitles
                .DataSource = Me.GetSpecificAgentField("title").Select(Function(x)
                                                                           Return x.value
                                                                       End Function).ToList
                .DisplayMember = "value"
                .SelectedIndex = _index
            End With
        End If
    End Sub

    Private Sub btSetTitle_Click(sender As Object, e As EventArgs) Handles btSetTitle.Click
        'заменит выбранное значение в листбоксе на отображаемое в поле
        If Me.lblTitles.SelectedItem Is Nothing Then Return
        If Me.tbTitleValue.Text = "" Then Return
        Dim _index = Me.lblTitles.SelectedIndex
        If Me.ResetValueInSpecificAgentField("title", Me.lblTitles.SelectedItem, tbTitleValue.Text) Then
            Service.clsApplicationTypes.BeepYES()
            oAuctionAgentList.SaveAgentsFile()
            With Me.lblTitles
                .DataSource = Me.GetSpecificAgentField("title").Select(Function(x)
                                                                           Return x.value
                                                                       End Function).ToList
                .DisplayMember = "value"
                .SelectedIndex = _index
            End With
        End If
    End Sub

    Private Sub btRemoveTitle_Click(sender As Object, e As EventArgs) Handles btRemoveTitle.Click
        If Me.lblTitles.SelectedItem Is Nothing Then Return
        Dim _index = Me.lblTitles.SelectedIndex
        If RemoveItemFromSpecificAgentField("title", Me.lblTitles.SelectedItem) Then
            Service.clsApplicationTypes.BeepYES()
            oAuctionAgentList.SaveAgentsFile()
            With Me.lblTitles
                .DataSource = Me.GetSpecificAgentField("title").Select(Function(x)
                                                                           Return x.value
                                                                       End Function).ToList
                .DisplayMember = "value"
                .SelectedIndex = _index - 1
            End With
        End If
    End Sub

    Private Sub btAddName_Click(sender As Object, e As EventArgs) Handles btAddName.Click
        'UC
        'получить название и всавить его вместо #n
        Dim _name = Me.GetCurrentMainName
        Dim _instr = Me.tbTitleValue.Text
        Dim _out As String = ""
        If _instr.Contains("#n") Then
            _out = _instr.Replace("#n", _name.Trim)
        ElseIf _instr.Contains("RARE") Then
            'вставить после RARE
            _out = _instr.Insert(_instr.IndexOf("RARE") + "RARE".Length, _name.Trim)
        Else
            'вставить в начало строки
            _out = _name & _instr
        End If
        Me.tbTitleValue.Text = _out
        Me.tbTitleValue.DataBindings(0).WriteValue()
    End Sub

    Private Sub btAddSubTitle_Click(sender As Object, e As EventArgs) Handles btAddSubTitle.Click
        If Me.tbTitleValue.Text = "" Then Return
        If Me.AddValueInSpecificAgentField("subtitle", Me.cbSubTitles.Text) Then
            Service.clsApplicationTypes.BeepYES()
        End If
    End Sub

    Private Sub btSetSubTitle_Click(sender As Object, e As EventArgs) Handles btSetSubTitle.Click
        'заменит выбранное значение в листбоксе на отображаемое в поле
        If Me.cbSubTitles.SelectedItem Is Nothing Then Return
        If Me.cbSubTitles.Text = "" Then Return
        If Me.ResetValueInSpecificAgentField("subtitle", Me.cbSubTitles.SelectedItem, cbSubTitles.Text) Then
            Service.clsApplicationTypes.BeepYES()
        End If
    End Sub



    Private Sub UserControlQalityEbay_QualityTextChanged(sender As Object, e As UserControlQality.QualityTextChangedEventArgs) Handles UserControlQalityEbay.QualityTextChanged
        If Not Me.UserControlQalityEbay.DataBindings Is Nothing AndAlso Me.UserControlQalityEbay.DataBindings.Count > 0 Then
            Me.UserControlQalityEbay.DataBindings(0).WriteValue()
        End If
    End Sub
    ''' <summary>
    ''' ловит события для radiobutton аукционов Текст ЭУ должен соответствовать имени в файле описания. Регистр игнорируется.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub rbAgents_CheckedChanged(sender As Object, e As EventArgs)
        If sender.text = "" Then Return

        Dim _accountName As String = CType(sender, Windows.Forms.Control).Text

        If sender.Checked Then
            'сменить текущий элемент
            Dim _index = (From c In oAuctionAgentList.AGENT Where c.account.ToLower = _accountName.ToLower And c.name.ToLower = "ebay" Select bs_AuctionAgentList.IndexOf(c)).FirstOrDefault

            If _index < 0 Then
                'агент не найден
                MsgBox(String.Format("Агент {0} не найден в файле агентов. Для агента eBay следует задать параметр name='ebay'. Также проверте повтор агента по account и name.", _accountName), vbCritical)
                sender.Checked = False
                Return
            End If

            If bs_AuctionAgentList.CurrencyManager.Position = _index Then
                bs_AuctionAgentList_CurrentChanged(Me, EventArgs.Empty)
            Else
                bs_AuctionAgentList.CurrencyManager.Position = _index
            End If
            'параметры для агента задаются в процедуре bs_AuctionAgentList_CurrentChanged
            'блокировка ebay
            Me.btCopyTosourceFromArhive.Enabled = True
            Me.btToAuction.Enabled = True
            Me.gbTitle.Enabled = True
            Me.gbCategory.Enabled = True
            Me.UserControlQalityEbay.Enabled = True
            Me.gbListingtype.Enabled = True
            Me.gbReclama.Enabled = True
            Me.gbShipping.Enabled = True
        End If
    End Sub


    Private Sub cbSubTitles_TextChanged(sender As Object, e As EventArgs) Handles cbSubTitles.TextChanged
        Dim _count = Me.cbSubTitles.Text.Length
        Dim _control = Me.cbSubTitles
        Dim _maxvalue = oCurrentAgent.AgentParameters.CntMaxWorldSubTitleCount

        Me.lbWordRemainSub.Text = "Remain " & _maxvalue - _control.Text.Length

        If _count >= _maxvalue Then
            _control.ForeColor = Drawing.Color.Red
            '_control.Text = _control.Text.Substring(0, _maxvalue)
            '_control.DataBindings(0).WriteValue()
        Else
            _control.ForeColor = Control.DefaultForeColor
        End If
    End Sub

    ''' <summary>
    ''' поставит цены из МойСклад для не имеющих доступ к редактированию цен
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tbBuyItNowPriceUSD_GotFocus(sender As Object, e As EventArgs) Handles tbBuyItNowPriceUSD.GotFocus
        If oRecommendPrice > 0 Then
            sender.Text = oRecommendPrice
        End If
    End Sub

    Private Sub tbBuyItNowPriceUSD_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles tbBuyItNowPriceUSD.Validating

        Dim _control As Control = CType(sender, Windows.Forms.Control)

        'если путсто - то 0
        'If _control.Text = "" Then _control.Text = "0" : Return
        If _control.Text = " " Then _control.Text = "" : Return
        '--------------
        _control.Text = Service.clsApplicationTypes.ReplaceDecimalSplitter(_control.Text)


        'If sender Is Me.Sample_net_weightTextBox Then
        '    'замена гр на кг
        '    Dim _result As Decimal
        '    If Decimal.TryParse(_control.Text, _result) Then
        '        'проверить, есть ли точка
        '        For Each s In _control.Text
        '            If Char.IsPunctuation(s) Then
        '                'есть точка, выход
        '                Exit Sub
        '            End If
        '        Next
        '        'точки нет
        '        _result = _result / 1000
        '        _control.Text = _result.ToString

        '    End If
        'End If

    End Sub


    Private Sub tbWeightKG_Enter(sender As Object, e As System.EventArgs) Handles tbWeightKG.Enter
        If Not sender.text = "" Then
            '------------------
            Dim _data As String = sender.text
            Try
                My.Computer.Clipboard.Clear()
                My.Computer.Clipboard.SetText(sender.text)
            Catch ex As Exception
                MsgBox("Ошибка при помещении данных в буфер обмена.", vbCritical)
            End Try
            '-----------------

        End If
    End Sub
#End Region

#Region "События Биндингов"

    ''' <summary>
    ''' изменился текущий агент
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub bs_AuctionAgentList_CurrentChanged(sender As Object, e As EventArgs) Handles bs_AuctionAgentList.CurrentItemChanged
        'UC
        If bs_AuctionAgentList.Current Is Nothing Then Return
        If oIsinitProcedure Then Return


        Me.gbCategory.Enabled = True
        Me.gbTitle.Enabled = True
        Me.UserControlQalityEbay.Enabled = True
        Me.gbListingtype.Enabled = True
        Me.gbReclama.Enabled = True
        Me.gbShipping.Enabled = True
        Me.lblPhotoSources.Enabled = True
        Me.btCopyTosourceFromArhive.Enabled = True

        oCurrentAgent = CType(bs_AuctionAgentList.Current, AUCTIONDATAAGENT)

        If oCurrentAgent.AgentParameters Is Nothing Then
            'создать обьект-агент API из файла агента
            oCurrentAgent.AgentParameters = clsAgentEbayParameters.CreateInstance(oCurrentAgent)
        End If

        Me.bs_AgentFieldList.DataSource = oCurrentAgent
        Me.bs_AgentParameters.DataSource = oCurrentAgent.AgentParameters

        Init_Component()

        oCurrentAgent.AgentParameters.ShotNumber = oSampleNumber.ShotCode

        oCurrentAgent.AgentParameters.CurrentHTML = oCurrentHTML
        '=========================
        'тут oCurrentAgent.AgentParameters полностью ИНИЦИАЛИЗОВАН
        'задать параметры

        'стоимость шиппинга
        Me.CalculateShipping()
        'конвертация в USD
        Me.btShippingConvertation_Click(sender, e)

        '--------------
        'построить титульную строку
        Dim _titleString As String = Me.GetCurrentMainName
        Dim _result As AUCTIONDATAAGENTFIELDITEM
        'вытащить страну
        Dim _country = Me.GetCurrentSampleOridginCountry

        If Not String.IsNullOrEmpty(_country) Then
            _result = (From c As AUCTIONDATAAGENTFIELDITEM In Me.cbCountry.Items Where c.value.ToLower.StartsWith(_country.ToLower.Trim.Substring(0, 4)) Select c).FirstOrDefault
            Me.cbCountry.SelectedItem = _result
            _titleString += _country
        End If



        'вытащить возраст
        Dim _age = clsApplicationTypes.RejectSkobki(Me.GetCurrentSampleAge)

        If Not String.IsNullOrEmpty(_age) Then
            Dim _f = If(_age.Length >= 4, _age.ToLower.Trim.Substring(0, 4), _age.ToLower)
            _result = (From c As AUCTIONDATAAGENTFIELDITEM In Me.cbGeologyAge.Items Where c.value.ToLower.StartsWith(_f) Select c).FirstOrDefault
            Me.cbGeologyAge.SelectedItem = _result
        End If

        'построить титул
        _titleString += _age
        _titleString += " fossil from Trilbone"
        Me.tbTitleValue.Text = _titleString
        Me.tbTitleValue.DataBindings(0).WriteValue()

    End Sub
#End Region

#Region "Вспомогательные"

    Private Sub LockCtl()
        For Each ctl As Windows.Forms.Control In Me.Controls
            ctl.Enabled = False
        Next
        Me.tbDomesticShipCost.Text = ""
        Me.tbInterShipCost.Text = ""
        Me.tbWeightKG.Text = ""
        Me.tbWeightLBS.Text = ""
        Me.tbWeightOZ.Text = ""

        Me.gbCategory.Enabled = False
        Me.gbTitle.Enabled = False
        Me.UserControlQalityEbay.Enabled = False
        Me.gbListingtype.Enabled = False
        Me.gbReclama.Enabled = False
        Me.gbShipping.Enabled = False
        Me.lblPhotoSources.Enabled = False

        'блокировка ebay
        Me.btCopyTosourceFromArhive.Enabled = False
        Me.btToAuction.Enabled = False
        Me.gbTitle.Enabled = False
        Me.gbCategory.Enabled = False
        Me.gbListingtype.Enabled = False
        Me.gbReclama.Enabled = False
        Me.gbShipping.Enabled = False
    End Sub

    Private Sub UnlockCtl()
        For Each ctl As Windows.Forms.Control In Me.Controls
            ctl.Enabled = True
        Next
    End Sub
#End Region


    ''' <summary>
    ''' запись в БД и МС о выставлении на eBay
    ''' </summary>
    ''' <param name="insectionFee"></param>
    ''' <remarks></remarks>
    Private Sub ReserveSampleToEbay(insectionFee As Decimal)
        'по запросу выполняем вызов из сервиса
        'если делегата нет, то сервис недоступен
        If clsApplicationTypes.DelegatStoreMCinterface Is Nothing Then
            MsgBox("Сервис MC недоступен", vbCritical)
            GoTo trdb
        End If

        'сервис зарегестрирован - вызываем
        'надо добавить, если на требуемом устройстве нет фото, то скопировать из архива
        'надо добавить выбор шаблона для каталога
        If oSplashscreen1.Visible = False Then
            oSplashscreen1.Show()
            Application.DoEvents()
        End If

        Dim _MCinterface = clsApplicationTypes.DelegatStoreMCinterface().Invoke(False)

        oSplashscreen1.Hide()
        Application.DoEvents()

        If _MCinterface Is Nothing Then
            MsgBox("Сервис MC недоступен", vbCritical)
            GoTo trdb
        End If
        '----------------------
        'занесение в МС
        Dim _auctUUID = oCurrentAgent.GetAgentID("moysklad", "ReservCustomerOrderUUID")

        If Not _auctUUID = "" Then
            If _MCinterface.SetSampleToAction(oSampleNumber, _auctUUID, oCurrentAgent.AgentParameters.ResultPrice, True) Then
                MsgBox("Образец зарезервирован в соответствующем заказе", MsgBoxStyle.Information)
            Else
                MsgBox("Образец не зарезервирован в соответствующем заказе, ошибка при помещении в заказ.", MsgBoxStyle.Critical)
            End If
        Else
            MsgBox("Образец не зарезервирован в соответствующем заказе, ошибка при чтении параметра ReservCustomerOrderUUID из файла агента.", MsgBoxStyle.Critical)
        End If

        'пробуем обновить цену и вес в МС
        If Not _MCinterface.UpdateGoodPrice(oSampleNumber.ShotCode, 0, "", oCurrentAgent.AgentParameters.ResultPrice, "USD", "шт", "", clsApplicationTypes.ReplaceDecimalSplitter(tbWeightKG)) = "" Then
            MsgBox("Цена товара обновлена", MsgBoxStyle.Information)
        Else
            MsgBox("Цена товара не обновлена, ошибка при обновлении.", MsgBoxStyle.Critical)
        End If


trdb:
        'записать в мою базу
        Dim _auctionType = oCurrentAgent.AgentParameters.ItemListingTypeString & "/" & clsApplicationTypes.CurrentUser.UserShotName
        Dim _amount = oCurrentAgent.AgentParameters.ItemAmount
        'Записано: сумма выстановки, сбор аукциона
        Dim _account As clsSampleDataManager.emSLResource = clsSampleDataManager.emSLResource.eBayTrilbone
        Select Case oCurrentAgent.account
            Case "trilbone"
                _account = clsSampleDataManager.emSLResource.eBayTrilbone
            Case "nordstarfossils"
                _account = clsSampleDataManager.emSLResource.eBayNordstar
        End Select

        Dim _result = clsApplicationTypes.SampleDataObject.RegisterSampleToEbaySale(SampleNumber:=oSampleNumber, EbayAccount:=_account, AuctionTypeName:=_auctionType, InsectionFee:=insectionFee, itemamount:=_amount, itemcondition:=oCurrentAgent.AgentParameters.ConditionDescription, itemtitle:=oCurrentAgent.AgentParameters.Title, currency:="USD", receivedMoneyPayPal:=oCurrentAgent.AgentParameters.PayPalAccount)

        If _result Then
            clsApplicationTypes.BeepYES()
            MsgBox("Образец зарезервирован в БД, можно сохранить карту образца и закрыть окно", MsgBoxStyle.Information)
            Return
        Else
            MsgBox("Образец не зарезервирован в БД, ошибка при помещении в БД.", MsgBoxStyle.Critical)
        End If
    End Sub

    ''' <summary>
    ''' вытащит из описание корневой узел в TIMESCALE
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetCurrentSampleAge() As String
        'UC
        Dim _res = (From c In oCurrentCatalogSampleObj.DATA Where c.name = "TIMESCALE" Select c.Text).FirstOrDefault
        If Not _res Is Nothing Then
            'извлечь первое слово
            Return clsTemplateManager.GetFirstWord(_res) & " "
        End If
        Return ""
    End Function

    ''' <summary>
    ''' вытащит из описание корневой узел в LOCALITY
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetCurrentSampleOridginCountry() As String
        'UC
        Dim _res = (From c In oCurrentCatalogSampleObj.DATA Where c.name = "LOCALITY" Select c.Text).FirstOrDefault
        If Not _res Is Nothing Then
            'извлечь первое слово
            Return clsTemplateManager.GetFirstWord(_res) & " "
        End If
        Return ""
    End Function

    ''' <summary>
    ''' вернет имя текущего образца без скобок
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetCurrentMainName() As String
        Dim _res = (From c In oCurrentCatalogSampleObj.DATA Where c.name = "NAME" Select c.Text).FirstOrDefault
        If Not _res Is Nothing Then
            'удалить скобки
            Return clsTemplateManager.ReplaceParenthesis(_res) & " "
        End If
        Return ""
    End Function

    ''' <summary>
    ''' вычисляет вес и стоимость шиппинга из XML образца
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CalculateShipping()
        'UC
        If Me.tbWeightOZ.DataBindings.Count = 0 Then
            Return
        End If
        'вес камня
        Dim _wt = (From c In oCurrentCatalogSampleObj.DATA Where c.name = "WEIGHT" Select c.Text).FirstOrDefault
        Dim _parcedWeightKG As Decimal

        If Not _wt Is Nothing Then
            Dim _value = _wt.Split("kg".ToCharArray)
            If _value.Length > 0 Then
                Decimal.TryParse(_value(0), _parcedWeightKG)
            Else
                _value = _wt.Split("кг", 1, System.StringSplitOptions.RemoveEmptyEntries)
                Decimal.TryParse(_value(0), _parcedWeightKG)
            End If
            '-----------------------
            'перевод в брутто и в граммы
            Dim _brutto = _parcedWeightKG * 1000 * 1.15
            Me.tbWeightKG.Text = Math.Round(_brutto / 1000, 3).ToString

            If Me.tbWeightKG.DataBindings.Count > 0 Then
                Me.tbWeightKG.DataBindings(0).WriteValue()
            End If
            'конверсия в америку
            If _brutto < 453.59 Then
                'считаем только oz  унции = 28.35 гр (1/16 lbs)
                Dim _oz = Math.Round((_brutto / 28.35), 1)
                If _oz > 16 Then
                    'ошибка
                    _oz = 16
                End If

                Me.tbWeightOZ.Text = _oz
                Me.tbWeightOZ.DataBindings(0).WriteValue()
                Me.tbWeightLBS.Text = "0"
                Me.tbWeightLBS.DataBindings(0).WriteValue()
            Else
                'считаем и фунты lbs 453.592
                Dim _lbs = Math.Round((_brutto / 453.59), 1)
                Dim _s = _brutto Mod 453.59
                Dim _oz = Math.Round(_s / 28.35, 0)
                If _oz > 16 Then
                    'ошибка
                    _oz = 16
                End If

                Me.tbWeightLBS.Text = _lbs
                Me.tbWeightLBS.DataBindings(0).WriteValue()
                Me.tbWeightOZ.Text = _oz
                Me.tbWeightOZ.DataBindings(0).WriteValue()
            End If

            'рассчет шиппинга +30%
            Dim _fullBrutto = _parcedWeightKG * 1000 * 1.3
            'цены заданы в mySettings = 20 значений подряд
            Select Case _fullBrutto
                Case Is <= 50
                    Me.tbDomesticShipCost.Text = My.Settings.ShippingCosts(0)
                    Me.tbInterShipCost.Text = My.Settings.ShippingCosts(1)

                Case 51 To 100
                    Me.tbDomesticShipCost.Text = My.Settings.ShippingCosts(2)
                    Me.tbInterShipCost.Text = My.Settings.ShippingCosts(3)


                Case 101 To 250
                    Me.tbDomesticShipCost.Text = My.Settings.ShippingCosts(4)
                    Me.tbInterShipCost.Text = My.Settings.ShippingCosts(5)


                Case 251 To 500
                    Me.tbDomesticShipCost.Text = My.Settings.ShippingCosts(6)
                    Me.tbInterShipCost.Text = My.Settings.ShippingCosts(7)

                Case 501 To 1000
                    Me.tbDomesticShipCost.Text = My.Settings.ShippingCosts(8)
                    Me.tbInterShipCost.Text = My.Settings.ShippingCosts(9)


                Case 1001 To 2000
                    Me.tbDomesticShipCost.Text = My.Settings.ShippingCosts(10)
                    Me.tbInterShipCost.Text = My.Settings.ShippingCosts(11)


                Case 2001 To 3000
                    Me.tbDomesticShipCost.Text = My.Settings.ShippingCosts(12)
                    Me.tbInterShipCost.Text = My.Settings.ShippingCosts(13)


                Case 3001 To 4000
                    Me.tbDomesticShipCost.Text = My.Settings.ShippingCosts(14)
                    Me.tbInterShipCost.Text = My.Settings.ShippingCosts(15)


                Case 4001 To 5000
                    Me.tbDomesticShipCost.Text = My.Settings.ShippingCosts(16)
                    Me.tbInterShipCost.Text = My.Settings.ShippingCosts(17)


                Case Is > 5001
                    Me.tbDomesticShipCost.Text = My.Settings.ShippingCosts(18)
                    Me.tbInterShipCost.Text = My.Settings.ShippingCosts(19)


            End Select
        End If


    End Sub

    ''' <summary>
    ''' Очищает ЭУ
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Clear()
        If Not oCurrentAgent Is Nothing Then
            oCurrentAgent.AgentParameters.Clear()
            'предустановка значения
            oCurrentAgent.AgentParameters.PrivateListing = True
            Me.UserControlQalityEbay.Clear()
        End If
    End Sub

    Private Sub Init_Component()
        'загрузка списков в ЭУ
        'порядок процедур ВАЖЕН!!!

        'генерация ЭУ для аукционов
        For Each _auctionType In Me.GetSpecificAgentField("AuctionType")
            Dim _newrb As New RadioButton
            With _newrb
                .AutoSize = True
                .Name = "rb" & _auctionType.value
                .TabStop = False
                .Text = _auctionType.value
                .UseVisualStyleBackColor = True
            End With
            Me.pnAuctionType.Controls.Add(_newrb)
            AddHandler _newrb.CheckedChanged, AddressOf Me.rbAuctions_CheckedChanged
        Next
        '=======================
        oCurrentAgent.AgentParameters.Clear()
        '=======================
        'текстовые поля
        'Title
        With Me.lblTitles
            Dim _list = Me.GetSpecificAgentField("title").Select(Function(x)
                                                                     Return x.value
                                                                 End Function).ToList

            _list.Sort()
            .DataSource = _list
            .DisplayMember = "value"
        End With

        'фотки
        With Me.lblPhotoSources
            .DataSource = Me.GetSpecificAgentField("ImageSource")
            .DisplayMember = "value"
        End With


        'платный субтитл
        With Me.cbSubTitles
            .DataSource = Me.GetSpecificAgentField("subtitle").Select(Function(x)
                                                                          Return x.value
                                                                      End Function).ToList
            .DisplayMember = "value"
            .DataBindings.Clear()
            .DataBindings.Add("SelectedItem", oCurrentAgent.AgentParameters, "SubTitle", False, Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, "")
            .DataBindings(0).WriteValue()
        End With

        With Me.cbPayPal
            .DataSource = Me.GetSpecificAgentField("paypal").Select(Function(x)
                                                                        Return x.value
                                                                    End Function).ToList
            .DisplayMember = "value"
            .DataBindings.Clear()
            .DataBindings.Add("SelectedItem", oCurrentAgent.AgentParameters, "PayPalAccount", False, Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, "")
            .DataBindings(0).WriteValue()
        End With

        '=============================
        'обьектные поля
        'категория ебай главная
        With Me.cbCategory
            .DataSource = Me.GetSpecificAgentField("category")
            .DisplayMember = "value"
            .DataBindings.Clear()
            .DataBindings.Add("SelectedItem", oCurrentAgent.AgentParameters, "Category", False, Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, "")
            .DataBindings(0).WriteValue()
        End With

        'категория ebay вторая
        With Me.cbCategory2
            .DataSource = Me.GetSpecificAgentField("category")
            .DisplayMember = "value"
            .DataBindings.Clear()
            .DataBindings.Add("SelectedItem", oCurrentAgent.AgentParameters, "Category2", False, Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, "")
            .DataBindings(0).WriteValue()
        End With

        'Item specific field
        Me.tbItemSpecificTotal.DataBindings.Clear()
        oCurrentAgent.AgentParameters.ItemSpecifics = ""
        Me.tbItemSpecificTotal.DataBindings.Add("Text", oCurrentAgent.AgentParameters, "ItemSpecifics", False, Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, "")
        Me.tbItemSpecificTotal.DataBindings(0).WriteValue()

        'страна
        With Me.cbCountry
            .DataSource = Me.GetSpecificAgentField("Origin country")
            .DisplayMember = "value"
        End With

        'возраст
        With Me.cbGeologyAge
            .DataSource = Me.GetSpecificAgentField("Geological age")
            .DisplayMember = "value"
        End With

        'Store Category
        With Me.cbStoreCategory
            .DataSource = Me.GetSpecificAgentField("storecategory")
            .DisplayMember = "value"
            .DataBindings.Clear()
            .DataBindings.Add("SelectedItem", oCurrentAgent.AgentParameters, "StoreCategory", False, Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, "")
            .DataBindings(0).WriteValue()
        End With

        'Store Category2
        With Me.cbStoreCategory2
            .DataSource = Me.GetSpecificAgentField("storecategory")
            .DisplayMember = "value"
            .DataBindings.Clear()
            .DataBindings.Add("SelectedItem", oCurrentAgent.AgentParameters, "StoreCategory2", False, Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, "")
            .DataBindings(0).WriteValue()
        End With

        'IsBuyItNow
        Me.cbxBuyItNow.DataBindings.Clear()
        Me.cbxBuyItNow.DataBindings.Add("Checked", oCurrentAgent.AgentParameters, "IsBuyItNow", False, Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, "")
        Me.cbxBuyItNow.DataBindings(0).WriteValue()

        'PrivateListing
        Me.cbxPrivateListing.DataBindings.Clear()
        oCurrentAgent.AgentParameters.PrivateListing = True
        Me.cbxPrivateListing.DataBindings.Add("Checked", oCurrentAgent.AgentParameters, "PrivateListing", False, Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, "")
        Me.cbxPrivateListing.DataBindings(0).WriteValue()

        'FreeShipping
        Me.cbxFreeShipping.DataBindings.Clear()
        Me.cbxFreeShipping.DataBindings.Add("Checked", oCurrentAgent.AgentParameters, "FreeShipping", False, Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, "")
        Me.cbxFreeShipping.DataBindings(0).WriteValue()

        'ListigType
        With Me.cbListingType
            .DataSource = Me.GetSpecificAgentField("ListigType")
            .DisplayMember = "value"
            .DataBindings.Clear()
            .DataBindings.Add("SelectedItem", oCurrentAgent.AgentParameters, "ListingType", False, Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, "")
            .DataBindings(0).WriteValue()
        End With

        'Title
        Me.tbTitleValue.DataBindings.Clear()
        Me.tbTitleValue.DataBindings.Add("Text", oCurrentAgent.AgentParameters, "Title", False, Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, "")
        Me.tbTitleValue.DataBindings(0).WriteValue()

        'ConditionDescription
        Me.UserControlQalityEbay.DataBindings.Clear()
        oCurrentAgent.AgentParameters.ConditionDescription = ""
        Me.UserControlQalityEbay.Clear()
        Me.UserControlQalityEbay.DataBindings.Add("QualityText", oCurrentAgent.AgentParameters, "ConditionDescription", False, Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, "")
        Me.UserControlQalityEbay.DataBindings(0).WriteValue()

        'PriceBuyItNow
        Me.tbBuyItNowPriceUSD.DataBindings.Clear()
        Me.tbBuyItNowPriceUSD.DataBindings.Add("Text", oCurrentAgent.AgentParameters, "PriceBuyItNow", False, Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, "")
        Me.tbBuyItNowPriceUSD.DataBindings(0).WriteValue()

        'PriceReserve
        Me.tbReserveAuctionPriceUSD.DataBindings.Clear()
        Me.tbReserveAuctionPriceUSD.DataBindings.Add("Text", oCurrentAgent.AgentParameters, "PriceReserve", False, Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, "")
        Me.tbReserveAuctionPriceUSD.DataBindings(0).WriteValue()

        Me.tbStartAuctionPriceUSD.DataBindings.Clear()
        Me.tbStartAuctionPriceUSD.DataBindings.Add("Text", oCurrentAgent.AgentParameters, "PriceStart", False, Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, "")
        Me.tbStartAuctionPriceUSD.DataBindings(0).WriteValue()

        'ShippingInternationalCostUSD
        Me.tbInterShipCostUSD.DataBindings.Clear()
        Me.tbInterShipCostUSD.DataBindings.Add("Text", oCurrentAgent.AgentParameters, "ShippingInternationalCostUSD", False, Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, "")
        Me.tbInterShipCostUSD.DataBindings(0).WriteValue()

        'ShippingDomesticCostUSD
        Me.tbDomesticShipCostUSD.DataBindings.Clear()
        Me.tbDomesticShipCostUSD.DataBindings.Add("Text", oCurrentAgent.AgentParameters, "ShippingDomesticCostUSD", False, Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, "")
        Me.tbDomesticShipCostUSD.DataBindings(0).WriteValue()

        'ShippingWeightKG
        Me.tbWeightKG.DataBindings.Clear()
        Me.tbWeightKG.DataBindings.Add("Text", oCurrentAgent.AgentParameters, "ShippingWeightKG", False, Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, "")
        Me.tbWeightKG.DataBindings(0).WriteValue()

        'ShippingWeightLBS
        Me.tbWeightLBS.DataBindings.Clear()
        Me.tbWeightLBS.DataBindings.Add("Text", oCurrentAgent.AgentParameters, "ShippingWeightLBS", False, Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, "")
        Me.tbWeightLBS.DataBindings(0).WriteValue()

        'ShippingWeightOZ
        Me.tbWeightOZ.DataBindings.Clear()
        Me.tbWeightOZ.DataBindings.Add("Text", oCurrentAgent.AgentParameters, "ShippingWeightOZ", False, Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, "")
        Me.tbWeightOZ.DataBindings(0).WriteValue()

        'ExtendedBold
        Me.cbxBoldTitle.DataBindings.Clear()
        Me.cbxBoldTitle.DataBindings.Add("Checked", oCurrentAgent.AgentParameters, "ExtendedBold", False, Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, "")
        Me.cbxBoldTitle.DataBindings(0).WriteValue()

        'eBayUK
        Me.cbxeBayUK.DataBindings.Clear()
        Me.cbxeBayUK.DataBindings.Add("Checked", oCurrentAgent.AgentParameters, "eBayUK", False, Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, "")
        Me.cbxeBayUK.DataBindings(0).WriteValue()

        'ExtendedGalleryPlus
        Me.cbxGalleryPlus.DataBindings.Clear()
        Me.cbxGalleryPlus.DataBindings.Add("Checked", oCurrentAgent.AgentParameters, "ExtendedGalleryPlus", False, Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, "")
        Me.cbxGalleryPlus.DataBindings(0).WriteValue()

        'ExtendedPicturePack
        Me.cbxPicturePack.DataBindings.Clear()
        Me.cbxPicturePack.DataBindings.Add("Checked", oCurrentAgent.AgentParameters, "ExtendedPicturePack", False, Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, "")
        Me.cbxPicturePack.DataBindings(0).WriteValue()

        'ExtendedSubTitle
        Me.cbxEnableSubTitle.DataBindings.Clear()
        Me.cbxEnableSubTitle.DataBindings.Add("Checked", oCurrentAgent.AgentParameters, "ExtendedSubTitle", False, Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, "")
        Me.cbxEnableSubTitle.DataBindings(0).WriteValue()

        'ExtendedValuePack
        Me.cbxValuePack.DataBindings.Clear()
        Me.cbxValuePack.DataBindings.Add("Checked", oCurrentAgent.AgentParameters, "ExtendedValuePack", False, Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, "")
        Me.cbxValuePack.DataBindings(0).WriteValue()

        'IsAcceptOffers
        Me.cbxAcceptOffers.DataBindings.Clear()
        oCurrentAgent.AgentParameters.IsAcceptOffers = True
        Me.cbxAcceptOffers.DataBindings.Add("Checked", oCurrentAgent.AgentParameters, "IsAcceptOffers", False, Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, "")
        Me.cbxAcceptOffers.DataBindings(0).WriteValue()

    End Sub

    ''' <summary>
    ''' HTML строка описания
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property CurrentHTML As String
        Get
            Return oCurrentHTML
        End Get
        Set(value As String)
            oCurrentHTML = value
            'сохранить описание, отображенное в окне
            If Not oCurrentAgent Is Nothing Then
                oCurrentAgent.AgentParameters.CurrentHTML = oCurrentHTML
            End If
        End Set
    End Property
    ''' <summary>
    ''' список путей фото для загрузки
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property PicturePaths As List(Of String)
        Get
            Return Me.oCurrentImagesPath
        End Get
        Set(value As List(Of String))
            Me.oCurrentImagesPath = value
        End Set
    End Property


    ''' <summary>
    ''' запрос определенного FIELD для заполнения списков определенных ЭУ
    ''' </summary>
    ''' <param name="fieldname"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetSpecificAgentField(fieldname As String) As List(Of AUCTIONDATAAGENTFIELDITEM)
        'запросит только в момент привязки, т.е. при изменении bs_AuctionAgentList.Current функция даст результат для нужного агента
        Dim _result = (From c In oCurrentAgent.FIELD Where String.Equals(c.name.ToLower, fieldname.ToLower, StringComparison.OrdinalIgnoreCase) Select c.ITEM.ToList)

        Dim _out = _result.FirstOrDefault

        If _out.Count = 0 Then
            'запрошенное имя FIELD не найдено в источнике данных
            Debug.Fail("запрошенное имя FIELD не найдено в источнике данных")
            ''тут надо добавить новую коллекцию к источнику данных и потом ее же и вернуть
            'Dim _new = CType(bs_AuctionAgentList.AddNew(), AUCTIONDATAAGENTFIELD)
            'With _new
            '    .name = fieldname
            '    .agentIDDataType = "string"
            '    .datatype = "string"
            '    .requered = False
            '    .ITEM = New AUCTIONDATAAGENTFIELDITEM() {}
            'End With
            'Return _new.ITEM.ToList
            'список без привязки к источнику
            Return New List(Of AUCTIONDATAAGENTFIELDITEM)
        Else
            Return _out.ToList
        End If

    End Function

    Private Function AddValueInSpecificAgentField(fieldname As String, value As String, Optional agentID As String = "", Optional Order As String = "0") As Boolean
        Dim _result = (From c In oCurrentAgent.FIELD Where c.name.ToLower.Equals(fieldname.ToLower) Select c)
        If _result.Count = 0 Then
            'запрошенное имя FIELD не найдено в источнике данных
            Debug.Fail("запрошенное имя FIELD не найдено в файле Agents")
        End If

        If oCurrentAgent.AddITEMtoFIELD(fieldname, value, agentID, Order) Then
            MsgBox(String.Format("В поле {0} добавлено значение {1} с ID {2}", fieldname, value, agentID), vbInformation)
            Return True
        Else
            MsgBox(String.Format("В поле {0} не удалось добавить значение {1} с ID {2}", fieldname, value, agentID), vbCritical)
            Return False
        End If
    End Function
    Private Function ResetValueInSpecificAgentField(fieldname As String, oldvalue As String, newvalue As String) As Boolean
        Dim _result = (From c In oCurrentAgent.FIELD Where String.Equals(c.name.ToLower, fieldname.ToLower, StringComparison.OrdinalIgnoreCase) Select c)
        Dim _out = _result.FirstOrDefault

        If _out Is Nothing Then
            'запрошенное имя FIELD не найдено в источнике данных
            Debug.Fail("запрошенное имя FIELD не найдено в источнике данных")
            Return False
        Else
            Return _out.UpdateItem(oldvalue, newvalue)
        End If
    End Function
    Private Function RemoveItemFromSpecificAgentField(fieldname As String, itemValue As String) As Boolean
        Dim _result = (From c In oCurrentAgent.FIELD Where String.Equals(c.name.ToLower, fieldname.ToLower, StringComparison.OrdinalIgnoreCase) Select c)
        If _result.Count = 0 Then Return False

        If oCurrentAgent.RemoveITEMFromFIELD(fieldname, itemValue) > 0 Then Return True
        Return False

    End Function

    Private Sub Label11_Click(sender As Object, e As EventArgs) Handles Label11.Click

    End Sub
    Public Shared ReadOnly Property GetDigiKey As Object
        Get
            Return Service.clsApplicationTypes.GetDigiKeyBoardForm
            'использование в событии mouseClick ЭУ
            'Dim _tb As TextBoxBase = Me.mycontrol
            '_tb.Text = ""
            'GetDigiKey.connect(_tb)
        End Get
    End Property

    Private Sub Label13_Click(sender As Object, e As EventArgs) Handles Label13.Click

    End Sub

    Private Sub Label11_MouseClick(sender As Object, e As MouseEventArgs) Handles Label11.MouseClick
        Dim _tb As TextBoxBase = tbBuyItNowPriceUSD
        _tb.Text = ""
        GetDigiKey.connect(_tb)
    End Sub

    Private Sub Label13_MouseClick(sender As Object, e As MouseEventArgs) Handles Label13.MouseClick
        Dim _tb As TextBoxBase = Me.tbStartAuctionPriceUSD
        _tb.Text = ""
        GetDigiKey.connect(_tb)
    End Sub

    Private Sub Label14_Click(sender As Object, e As EventArgs) Handles Label14.Click

    End Sub

    Private Sub Label14_MouseClick(sender As Object, e As MouseEventArgs) Handles Label14.MouseClick
        Dim _tb As TextBoxBase = Me.tbReserveAuctionPriceUSD
        _tb.Text = ""
        GetDigiKey.connect(_tb)
    End Sub

    Private Sub btGetPrice_Click(sender As Object, e As EventArgs) Handles btGetPrice.Click
        Me.tbBuyItNowPriceUSD.Text = oRecommendPrice
    End Sub

    Private Sub btOpenCategoryForm_Click(sender As Object, e As EventArgs) Handles btOpenCategoryForm.Click

    End Sub
End Class
