<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Uc_trilbone_history
    Inherits System.Windows.Forms.UserControl

    'Пользовательский элемент управления (UserControl) переопределяет метод Dispose для очистки списка компонентов.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Является обязательной для конструктора форм Windows Forms
    Private components As System.ComponentModel.IContainer

    'Примечание: следующая процедура является обязательной для конструктора форм Windows Forms
    'Для ее изменения используйте конструктор форм Windows Form.  
    'Не изменяйте ее в редакторе исходного кода.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.tbSampleNumber = New System.Windows.Forms.TextBox()
        Me.tbctl_main = New System.Windows.Forms.TabControl()
        Me.tpInfo = New System.Windows.Forms.TabPage()
        Me.rtb_info = New System.Windows.Forms.RichTextBox()
        Me.tbSite = New System.Windows.Forms.TabPage()
        Me.UC_siteCheck1 = New Service.UC_siteCheck()
        Me.tbDeleteFromSite = New System.Windows.Forms.Button()
        Me.btUnpublishFromSite = New System.Windows.Forms.Button()
        Me.btSearchInfo = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btAskPriceHistory = New System.Windows.Forms.Button()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.TableLayoutPanel1.SuspendLayout()
        Me.tbctl_main.SuspendLayout()
        Me.tpInfo.SuspendLayout()
        Me.tbSite.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 6
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 62.33766!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.66234!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 82.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 95.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 98.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 158.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.tbSampleNumber, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.tbctl_main, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.tbDeleteFromSite, 5, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btUnpublishFromSite, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btSearchInfo, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label5, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.PictureBox1, 5, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.btAskPriceHistory, 3, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.76596!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 87.23404!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(559, 235)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'tbSampleNumber
        '
        Me.tbSampleNumber.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbSampleNumber.Location = New System.Drawing.Point(3, 3)
        Me.tbSampleNumber.Name = "tbSampleNumber"
        Me.tbSampleNumber.Size = New System.Drawing.Size(72, 20)
        Me.tbSampleNumber.TabIndex = 0
        '
        'tbctl_main
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.tbctl_main, 5)
        Me.tbctl_main.Controls.Add(Me.tpInfo)
        Me.tbctl_main.Controls.Add(Me.tbSite)
        Me.tbctl_main.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbctl_main.Location = New System.Drawing.Point(3, 33)
        Me.tbctl_main.Name = "tbctl_main"
        Me.tbctl_main.SelectedIndex = 0
        Me.tbctl_main.Size = New System.Drawing.Size(394, 199)
        Me.tbctl_main.TabIndex = 4
        '
        'tpInfo
        '
        Me.tpInfo.Controls.Add(Me.rtb_info)
        Me.tpInfo.Location = New System.Drawing.Point(4, 22)
        Me.tpInfo.Name = "tpInfo"
        Me.tpInfo.Padding = New System.Windows.Forms.Padding(3)
        Me.tpInfo.Size = New System.Drawing.Size(386, 173)
        Me.tpInfo.TabIndex = 0
        Me.tpInfo.Text = "Инфо"
        Me.tpInfo.UseVisualStyleBackColor = True
        '
        'rtb_info
        '
        Me.rtb_info.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rtb_info.Location = New System.Drawing.Point(3, 3)
        Me.rtb_info.Name = "rtb_info"
        Me.rtb_info.Size = New System.Drawing.Size(380, 167)
        Me.rtb_info.TabIndex = 0
        Me.rtb_info.Text = ""
        '
        'tbSite
        '
        Me.tbSite.Controls.Add(Me.UC_siteCheck1)
        Me.tbSite.Location = New System.Drawing.Point(4, 22)
        Me.tbSite.Name = "tbSite"
        Me.tbSite.Padding = New System.Windows.Forms.Padding(3)
        Me.tbSite.Size = New System.Drawing.Size(387, 173)
        Me.tbSite.TabIndex = 2
        Me.tbSite.Text = "На сайте"
        Me.tbSite.UseVisualStyleBackColor = True
        '
        'UC_siteCheck1
        '
        Me.UC_siteCheck1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.UC_siteCheck1.Location = New System.Drawing.Point(6, 6)
        Me.UC_siteCheck1.Name = "UC_siteCheck1"
        Me.UC_siteCheck1.SampleNumber = ""
        Me.UC_siteCheck1.Size = New System.Drawing.Size(271, 89)
        Me.UC_siteCheck1.TabIndex = 0
        '
        'tbDeleteFromSite
        '
        Me.tbDeleteFromSite.Location = New System.Drawing.Point(403, 3)
        Me.tbDeleteFromSite.Name = "tbDeleteFromSite"
        Me.tbDeleteFromSite.Size = New System.Drawing.Size(92, 23)
        Me.tbDeleteFromSite.TabIndex = 7
        Me.tbDeleteFromSite.Text = "Удал. с сайта"
        Me.tbDeleteFromSite.UseVisualStyleBackColor = True
        '
        'btUnpublishFromSite
        '
        Me.btUnpublishFromSite.Location = New System.Drawing.Point(305, 3)
        Me.btUnpublishFromSite.Name = "btUnpublishFromSite"
        Me.btUnpublishFromSite.Size = New System.Drawing.Size(89, 23)
        Me.btUnpublishFromSite.TabIndex = 3
        Me.btUnpublishFromSite.Text = "Снять с сайта"
        Me.btUnpublishFromSite.UseVisualStyleBackColor = True
        '
        'btSearchInfo
        '
        Me.btSearchInfo.Location = New System.Drawing.Point(128, 3)
        Me.btSearchInfo.Name = "btSearchInfo"
        Me.btSearchInfo.Size = New System.Drawing.Size(76, 23)
        Me.btSearchInfo.TabIndex = 1
        Me.btSearchInfo.Text = "Запрос"
        Me.btSearchInfo.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(81, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(29, 23)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Cb"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.PictureBox1.Location = New System.Drawing.Point(403, 77)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(122, 110)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 6
        Me.PictureBox1.TabStop = False
        '
        'btAskPriceHistory
        '
        Me.btAskPriceHistory.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btAskPriceHistory.Location = New System.Drawing.Point(210, 3)
        Me.btAskPriceHistory.Name = "btAskPriceHistory"
        Me.btAskPriceHistory.Size = New System.Drawing.Size(89, 24)
        Me.btAskPriceHistory.TabIndex = 9
        Me.btAskPriceHistory.Text = "Name history"
        Me.btAskPriceHistory.UseVisualStyleBackColor = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(61, 4)
        '
        'Uc_trilbone_history
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "Uc_trilbone_history"
        Me.Size = New System.Drawing.Size(559, 235)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.tbctl_main.ResumeLayout(False)
        Me.tpInfo.ResumeLayout(False)
        Me.tbSite.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tbSampleNumber As System.Windows.Forms.TextBox
    Friend WithEvents btSearchInfo As System.Windows.Forms.Button
    Friend WithEvents btUnpublishFromSite As System.Windows.Forms.Button
    Friend WithEvents tbctl_main As System.Windows.Forms.TabControl
    Friend WithEvents tpInfo As System.Windows.Forms.TabPage
    Friend WithEvents rtb_info As System.Windows.Forms.RichTextBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents tbDeleteFromSite As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tbSite As System.Windows.Forms.TabPage
    Friend WithEvents UC_siteCheck1 As Service.UC_siteCheck
    Friend WithEvents btAskPriceHistory As Windows.Forms.Button
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
End Class
